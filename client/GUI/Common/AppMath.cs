using System;
using System.Globalization;

namespace GUI
{
    // Các phép tính tiền/nghiệp vụ THUẦN (không phụ thuộc UI/mạng) — tách riêng ở đây
    // để nhiều màn hình dùng chung một công thức và để viết unit-test được.
    public static class AppMath
    {
        // Đọc SỐ TIỀN (VNĐ) từ chuỗi người dùng: chỉ giữ chữ số, bỏ mọi dấu phân cách
        // (".", ",", khoảng trắng, "đ"…). "1.500.000 đ" -> 1500000.
        public static long ParseVndDigits(string? s)
        {
            if (string.IsNullOrEmpty(s)) return 0;
            long v = 0;
            foreach (char c in s)
                if (c >= '0' && c <= '9')
                    v = checked(v * 10 + (c - '0'));
            return v;
        }

        // Đọc SỐ LƯỢNG (có thể lẻ) từ chuỗi người dùng: "," và "." đều là dấu thập phân.
        // "0,5" / "0.5" -> 0.5 ; "2" -> 2. Chuỗi rỗng/không hợp lệ -> 0.
        public static decimal ParseQuantity(string? s)
        {
            if (string.IsNullOrWhiteSpace(s)) return 0m;
            string cleaned = s.Trim().Replace(",", ".").Replace(" ", "");
            return decimal.TryParse(cleaned, NumberStyles.AllowDecimalPoint | NumberStyles.AllowLeadingSign,
                                    CultureInfo.InvariantCulture, out var q)
                ? q : 0m;
        }

        // Số lượng làm tròn về số nguyên (DTO nhập kho dùng int). Trước đây strip cả dấu "."
        // khiến "1.5" biến thành 15 — nay parse đúng dạng thập phân rồi làm tròn.
        public static int ParseQuantityToInt(string? s)
            => (int)Math.Round(ParseQuantity(s), MidpointRounding.AwayFromZero);

        // Tổng phải trả sau giảm giá (không bao giờ âm; giảm giá âm bị coi như 0).
        public static long OrderTotal(long subtotal, long discount)
            => Math.Max(0, subtotal - Math.Max(0, discount));

        // Tiền thối cho khách (dương = thối lại, âm = còn thiếu).
        public static long ChangeDue(long received, long total) => received - total;

        // Ngày công chuẩn của 1 tháng — quy đổi lương cơ bản tháng thành đơn giá ngày.
        public const int StandardWorkDays = 26;

        // Lương cơ bản THỰC theo ngày công: (LCB tháng ÷ 26) × ngày công, làm tròn đồng.
        // Ngày công âm coi như 0; trên 26 ngày trả thêm theo cùng đơn giá (làm vượt chuẩn).
        public static decimal ProratedBase(decimal baseMonthly, decimal workDays)
            => Math.Round(baseMonthly / StandardWorkDays * Math.Max(0, workDays), 0, MidpointRounding.AwayFromZero);

        // Tổng lương = LCB quy theo ngày công + Phụ cấp + Thưởng FB + Thưởng lễ − |Trừ lương|.
        // Khoản trừ LUÔN bị trừ dù người dùng nhập số dương hay âm. Trước 2026-07-08 lương CB
        // là số cố định tháng (ngày công chỉ hiển thị) — làm bao nhiêu ca lương cũng như nhau.
        public static decimal PayrollTotal(decimal baseSalary, decimal workDays, decimal allowance,
                                           decimal feedbackBonus, decimal holidayBonus, decimal deduction)
            => ProratedBase(baseSalary, workDays) + allowance + feedbackBonus + holidayBonus - Math.Abs(deduction);

        // Điểm tích lũy: 1 điểm cho mỗi 3.000đ trên hóa đơn (làm tròn xuống).
        public static int LoyaltyPoints(long invoiceAmount)
            => invoiceAmount <= 0 ? 0 : (int)(invoiceAmount / 3000);
    }
}
