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

        public static Task<(bool Success, string Message)> SendOtpAsync(string email)
            => AuthDAL.GenerateOtpAsync(email);

        public static Task<(bool Success, string? ResetToken, string Message)> VerifyOtpAsync(string email, string code)
            => AuthDAL.VerifyOtpAsync(email, code);
    }
}
