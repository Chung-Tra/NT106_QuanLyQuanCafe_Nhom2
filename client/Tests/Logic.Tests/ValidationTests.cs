using BUS;
using Xunit;

namespace Logic.Tests
{
    // Kiểm thử bộ validate đầu vào dùng ở mọi form nhập liệu: Login, AddEmployee,
    // ConfirmEmail/VerifyCode/ResetPassword (luồng OTP), AddFood… — chính là logic
    // quyết định nút Lưu/Đăng nhập có được bấm tiếp hay chặn lại với thông báo lỗi.
    public class ValidationTests
    {
        // ---------- IsValidPassword (khớp STRONG_PASSWORD phía server) ----------
        [Theory]
        [InlineData("Abc@1234", true)]      // đủ hoa + thường + số + ký tự đặc biệt, 8 ký tự
        [InlineData("Aa1@aaaa", true)]
        [InlineData("abc@1234", false)]     // thiếu chữ hoa
        [InlineData("ABC@1234", false)]     // thiếu chữ thường
        [InlineData("Abcd@efg", false)]     // thiếu chữ số
        [InlineData("Abc12345", false)]     // thiếu ký tự đặc biệt
        [InlineData("Ab@1", false)]         // quá ngắn (< 8)
        [InlineData("", false)]
        [InlineData(null, false)]
        public void IsValidPassword_RequiresStrongPassword(string? password, bool expected)
            => Assert.Equal(expected, Validation.IsValidPassword(password));

        // ---------- IsValidEmail ----------
        [Theory]
        [InlineData("user@cafe.com", true)]
        [InlineData("ten.ho+tag@sub-domain.vn", true)]
        [InlineData("user@cafe", false)]     // thiếu phần .tld
        [InlineData("usercafe.com", false)]  // thiếu @
        [InlineData("user @cafe.com", false)]
        [InlineData("", false)]
        [InlineData(null, false)]
        public void IsValidEmail_ChecksBasicFormat(string? email, bool expected)
            => Assert.Equal(expected, Validation.IsValidEmail(email));

        // ---------- IsValidVerificationCode (mã OTP 8 số của luồng quên mật khẩu) ----------
        [Theory]
        [InlineData("12345678", true)]
        [InlineData("00000000", true)]
        [InlineData("1234567", false)]      // 7 số
        [InlineData("123456789", false)]    // 9 số
        [InlineData("12a45678", false)]     // lẫn chữ
        [InlineData("", false)]
        [InlineData(null, false)]
        public void IsValidVerificationCode_Exactly8Digits(string? code, bool expected)
            => Assert.Equal(expected, Validation.IsValidVerificationCode(code));

        // ---------- IsValidPhoneNumber (di động VN: 0 + đầu số 3/5/7/8/9 + 8 số) ----------
        [Theory]
        [InlineData("0901234567", true)]
        [InlineData("0351234567", true)]
        [InlineData("0781234567", true)]
        [InlineData("0201234567", false)]    // đầu số 2 không hợp lệ
        [InlineData("0121234567", false)]    // đầu số 1 không hợp lệ
        [InlineData("090123456", false)]     // 9 chữ số (thiếu)
        [InlineData("09012345678", false)]   // 11 chữ số (thừa)
        [InlineData("090123456a", false)]
        [InlineData("  ", false)]
        [InlineData(null, false)]
        public void IsValidPhoneNumber_VietnameseMobileOnly(string? phone, bool expected)
            => Assert.Equal(expected, Validation.IsValidPhoneNumber(phone));

        // ---------- IsValidHireDate (không cho ngày vào làm ở tương lai) ----------
        [Fact]
        public void IsValidHireDate_TodayIsValid()
            => Assert.True(Validation.IsValidHireDate(System.DateTime.Today.ToString("yyyy-MM-dd")));

        [Fact]
        public void IsValidHireDate_PastIsValid()
            => Assert.True(Validation.IsValidHireDate(System.DateTime.Today.AddDays(-30).ToString("yyyy-MM-dd")));

        [Fact]
        public void IsValidHireDate_FutureIsInvalid()
            => Assert.False(Validation.IsValidHireDate(System.DateTime.Today.AddDays(1).ToString("yyyy-MM-dd")));

        [Theory]
        [InlineData("abc")]
        [InlineData("32/13/2026")]  // ngày/tháng không tồn tại
        [InlineData("")]
        [InlineData(null)]
        public void IsValidHireDate_GarbageIsInvalid(string? input)
            => Assert.False(Validation.IsValidHireDate(input));

        // ---------- IsAnyEmpty (guard chung "điền đủ các trường") ----------
        [Fact]
        public void IsAnyEmpty_AllFilled_ReturnsFalse()
            => Assert.False(Validation.IsAnyEmpty("a", "b", "c"));

        [Fact]
        public void IsAnyEmpty_OneWhitespace_ReturnsTrue()
            => Assert.True(Validation.IsAnyEmpty("a", "  ", "c"));

        [Fact]
        public void IsAnyEmpty_OneNull_ReturnsTrue()
            => Assert.True(Validation.IsAnyEmpty("a", null, "c"));

        [Fact]
        public void IsAnyEmpty_NoArgs_ReturnsTrue()
            => Assert.True(Validation.IsAnyEmpty());

        [Fact]
        public void IsAnyEmpty_NullArray_ReturnsTrue()
            => Assert.True(Validation.IsAnyEmpty(null));
    }
}
