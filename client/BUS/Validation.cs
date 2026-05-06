using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BUS
{ 
    public static class Validation
    {
        public static bool IsValidPassword(string? password)
        {
            if (password == null)
                return false;
            string pattern = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&]).{8,}$";
            return Regex.IsMatch(password, pattern);
        }

        public static bool IsValidEmail(string? email)
        {
            if (email == null) 
                return false;
            // Kiểm tra định dạng: chữ/số/dấu_chấm @ chữ/số . chữ/số
            string pattern = @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$";
            return Regex.IsMatch(email, pattern);
        }
        public static bool IsValidVerificationCode(string? code)
        {
            // Giải thích Regex:
            // ^      : Bắt đầu chuỗi
            // \d{8}  : Chính xác 8 chữ số (từ 0-9)
            // $      : Kết thúc chuỗi
            if (code == null) 
                return false;
            string pattern = @"^\d{8}$";
            return Regex.IsMatch(code, pattern);
        }
        
        public static bool IsValidPhoneNumber(string? phoneNumber)
        {
            if (string.IsNullOrWhiteSpace(phoneNumber)) 
                return false;
            string pattern = @"^0[35789]\d{8}$";
            return Regex.IsMatch(phoneNumber, pattern);
        }
        public static bool IsValidHireDate(string? hireDateStr)
        {
            if (string.IsNullOrWhiteSpace(hireDateStr)) 
                return false;

            // Ép kiểu chuỗi thành ngày thực tế. Nếu thành công, gán vào biến 'parsedDate'
            if (DateTime.TryParse(hireDateStr, out DateTime parsedDate))
            {
                // 2. Kiểm tra: Ngày nhập vào (.Date) phải nhỏ hơn hoặc bằng ngày hôm nay (DateTime.Today)
                // Lưu ý: Dùng .Today thay vì .Now để bỏ qua phần giờ/phút/giây, so sánh cho chuẩn xác.
                return parsedDate.Date <= DateTime.Today;
            }

            // Nếu nhập tào lao (ví dụ "abc", "32/13/2026") thì trả về false
            return false;
        }
        public static bool IsAnyEmpty(params string?[]? inputs)
        {
            if (inputs == null || inputs.Length == 0)
                return true;
            foreach (var input in inputs)
            {
                if (string.IsNullOrWhiteSpace(input))
                    return true;
            }
            return false;
        }
    }
}
