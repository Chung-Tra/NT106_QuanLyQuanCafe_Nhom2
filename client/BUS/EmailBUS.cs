using System;
using System.Threading.Tasks;
using DAL;

namespace BUS
{
    public class EmailBUS
    {
        // Gửi mã OTP. Mã do backend tạo + lưu ở server; client KHÔNG nhận mã.
        public static async Task<(bool IsSuccess, string Message)> ProcessPasswordResetAsync(string email)
        {
            try
            {
                if (Validation.IsAnyEmpty(email))
                    return (false, "Vui lòng nhập địa chỉ email!");

                if (!Validation.IsValidEmail(email))
                    return (false, "Email không hợp lệ.\nVui lòng nhập lại địa chỉ email!");

                var (exists, checkMsg) = await EmailDAL.CheckEmailAsync(email);
                if (!exists)
                    return (false, checkMsg);

                return await EmailDAL.SendOtpAsync(email);
            }
            catch (Exception ex)
            {
                return (false, "Lỗi trong quá trình gửi mã xác thực: " + ex.Message);
            }
        }

        // Xác thực mã OTP ở server. Đúng -> trả reset-token để dùng cho bước đổi mật khẩu.
        public static async Task<(bool IsSuccess, string? ResetToken, string Message)> VerifyOtpAsync(string email, string code)
        {
            try
            {
                if (Validation.IsAnyEmpty(code))
                    return (false, null, "Vui lòng nhập mã xác nhận!");

                if (!Validation.IsValidVerificationCode(code))
                    return (false, null, "Mã xác nhận không hợp lệ!\nMã phải có đúng 8 ký tự, bao gồm cả chữ và số.");

                return await EmailDAL.VerifyOtpAsync(email, code);
            }
            catch (Exception ex)
            {
                return (false, null, "Lỗi trong quá trình xác thực mã: " + ex.Message);
            }
        }
    }
}
