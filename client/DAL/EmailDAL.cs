using System.Threading.Tasks;

namespace DAL
{
    /// <summary>
    /// EmailDAL — chuyển tiếp sang AuthDAL vì Express API gộp chung auth + email.
    /// Giữ lại class này để BUS/GUI cũ không bị lỗi biên dịch.
    /// </summary>
    public static class EmailDAL
    {
        public static async Task<(bool Exists, string Message)> CheckEmailAsync(string email)
        {
            bool exists = await AuthDAL.CheckEmailExistsAsync(email);
            return (exists, exists ? "Email hợp lệ." : "Email không tồn tại trong hệ thống.");
        }

        public static async Task<(bool Success, string Code, string Message)> SendOtpAsync(string email)
        {
            string? code = await AuthDAL.GenerateOtpAsync(email);
            return code != null
                ? (true, code, "Đã gửi mã OTP tới email.")
                : (false, "", "Không thể gửi OTP. Vui lòng thử lại.");
        }
    }
}
