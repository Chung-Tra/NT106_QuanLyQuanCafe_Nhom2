using GUI;
using Xunit;

namespace Logic.Tests
{
    // Kiểm thử các phép tính tiền/nghiệp vụ dùng chung ở POS, PaymentDialog, Payroll,
    // Loyalty, AddInventoryImport — chính là logic đứng sau các nút Thanh toán / Tích điểm /
    // Tạo phiếu nhập / Tính lương.
    public class AppMathTests
    {
        // ---------- ParseVndDigits (đọc số tiền: bỏ mọi dấu phân cách) ----------
        [Theory]
        [InlineData("1.500.000", 1500000)]   // dấu chấm = phân cách nghìn (VN)
        [InlineData("1,500,000", 1500000)]   // dấu phẩy cũng bị bỏ
        [InlineData("50000", 50000)]
        [InlineData("200.000 đ", 200000)]    // có ký tự "đ" và khoảng trắng
        [InlineData("", 0)]
        [InlineData(null, 0)]
        [InlineData("abc", 0)]
        public void ParseVndDigits_StripsSeparators(string? input, long expected)
            => Assert.Equal(expected, AppMath.ParseVndDigits(input));

        // ---------- ParseQuantity / ParseQuantityToInt (số lượng nhập kho) ----------
        [Theory]
        [InlineData("0.5", 0.5)]
        [InlineData("0,5", 0.5)]   // dấu phẩy = dấu thập phân
        [InlineData("2", 2)]
        [InlineData("2.75", 2.75)]
        [InlineData("", 0)]
        [InlineData("abc", 0)]
        public void ParseQuantity_HandlesDecimalSeparator(string input, double expected)
            => Assert.Equal((decimal)expected, AppMath.ParseQuantity(input));

        [Theory]
        [InlineData("1.5", 2)]    // REGRESSION: trước đây "1.5" bị biến thành 15
        [InlineData("0.5", 1)]    // làm tròn ra xa 0
        [InlineData("2.4", 2)]
        [InlineData("3", 3)]
        [InlineData("10", 10)]
        public void ParseQuantityToInt_RoundsInsteadOfCorrupting(string input, int expected)
            => Assert.Equal(expected, AppMath.ParseQuantityToInt(input));

        [Fact]
        public void ParseQuantityToInt_DoesNotTurnOnePointFiveIntoFifteen()
            => Assert.NotEqual(15, AppMath.ParseQuantityToInt("1.5"));

        // ---------- OrderTotal (tổng sau giảm giá, không âm) ----------
        [Theory]
        [InlineData(100000, 20000, 80000)]
        [InlineData(100000, 0, 100000)]
        [InlineData(100000, 200000, 0)]     // giảm quá tay -> kẹp về 0
        [InlineData(100000, -5000, 100000)] // giảm âm -> coi như 0
        public void OrderTotal_ClampsToZero(long subtotal, long discount, long expected)
            => Assert.Equal(expected, AppMath.OrderTotal(subtotal, discount));

        // ---------- ChangeDue (tiền thối) ----------
        [Theory]
        [InlineData(100000, 80000, 20000)]   // thối 20k
        [InlineData(80000, 80000, 0)]
        [InlineData(50000, 80000, -30000)]   // còn thiếu 30k
        public void ChangeDue_MayBeNegative(long received, long total, long expected)
            => Assert.Equal(expected, AppMath.ChangeDue(received, total));

        // ---------- ProratedBase (lương CB quy theo ngày công, chuẩn 26 ngày) ----------
        [Theory]
        [InlineData(2600000, 26, 2600000)]  // đủ công → nhận đủ lương CB
        [InlineData(2600000, 13, 1300000)]  // nửa tháng → nửa lương CB
        [InlineData(2600000, 0, 0)]         // không đi làm → không có lương CB
        [InlineData(2600000, -3, 0)]        // ngày công âm coi như 0
        [InlineData(2600000, 28, 2800000)]  // vượt chuẩn → trả thêm cùng đơn giá
        public void ProratedBase_ScalesByWorkDays(decimal baseMonthly, decimal days, decimal expected)
            => Assert.Equal(expected, AppMath.ProratedBase(baseMonthly, days));

        [Fact]
        public void ProratedBase_RoundsToDong()
            => Assert.Equal(230769m, AppMath.ProratedBase(6000000m, 1)); // 6tr/26 = 230769.23 → 230769

        // ---------- PayrollTotal (LCB theo ngày công; khoản trừ LUÔN bị trừ) ----------
        [Fact]
        public void PayrollTotal_SubtractsDeduction_WhenPositive()
            => Assert.Equal(6300000m, AppMath.PayrollTotal(6000000m, 26, 500000m, 0m, 0m, 200000m));

        [Fact]
        public void PayrollTotal_SubtractsDeduction_WhenNegative_SameResult()
            => Assert.Equal(6300000m, AppMath.PayrollTotal(6000000m, 26, 500000m, 0m, 0m, -200000m));

        [Fact]
        public void PayrollTotal_NoDeduction()
            => Assert.Equal(6500000m, AppMath.PayrollTotal(6000000m, 26, 500000m, 0m, 0m, 0m));

        [Fact]
        public void PayrollTotal_HalfWorkDays_HalvesBaseOnly()
            // LCB 5.2tr/26 ngày × 13 ngày = 2.6tr; phụ cấp/thưởng giữ nguyên, trừ 100k
            => Assert.Equal(2900000m, AppMath.PayrollTotal(5200000m, 13, 300000m, 100000m, 0m, 100000m));

        [Fact]
        public void PayrollTotal_ZeroWorkDays_OnlyAllowancesMinusDeduction()
            => Assert.Equal(400000m, AppMath.PayrollTotal(6000000m, 0, 500000m, 0m, 0m, 100000m));

        // ---------- LoyaltyPoints (1 điểm / 3.000đ) ----------
        [Theory]
        [InlineData(150000, 50)]
        [InlineData(3000, 1)]
        [InlineData(2999, 0)]
        [InlineData(0, 0)]
        [InlineData(-5000, 0)]
        public void LoyaltyPoints_OnePer3000(long amount, int expected)
            => Assert.Equal(expected, AppMath.LoyaltyPoints(amount));
    }
}
