using DTO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace DAL
{
    public static class AuthDAL
    {
        public static async Task<(EmployeeDTO? User, string? Token)> LoginAsync(string email, string password)
        {
            try
            {
                var response = await DalHelper.Client.SendAsync(
                    DalHelper.Build(HttpMethod.Post, "auth/login", new { email, password }));

                if (!response.IsSuccessStatusCode) 
                    return (null, null);

                var json = JObject.Parse(await response.Content.ReadAsStringAsync());
                return (json["user"]?.ToObject<EmployeeDTO>(), json["token"]?.ToString());
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi kết nối khi đăng nhập: " + ex.Message);
            }
        }

        public static async Task<bool> CheckEmailExistsAsync(string email)
        {
            try
            {
                var response = await DalHelper.Client.SendAsync(
                    DalHelper.Build(HttpMethod.Post, "auth/check-email", new { email }));
                return response.IsSuccessStatusCode;
            }
            catch { return false; }
        }

        // Backend tạo mã, gửi email và LƯU mã ở server. Client chỉ nhận thông báo, không nhận mã.
        public static async Task<(bool Success, string Message)> GenerateOtpAsync(string toEmail)
        {
            try
            {
                var response = await DalHelper.Client.SendAsync(
                    DalHelper.Build(HttpMethod.Post, "auth/otp/generate", new { toEmail }));
                string body = await response.Content.ReadAsStringAsync();
                return response.IsSuccessStatusCode
                    ? (true, "Đã gửi mã OTP tới email.")
                    : (false, DalHelper.ParseErrorMessage(body));
            }
            catch (Exception ex)
            {
                return (false, "Lỗi kết nối: " + ex.Message);
            }
        }

        // Gửi mã người dùng nhập lên server để so sánh. Đúng -> server trả reset-token dùng 1 lần.
        public static async Task<(bool Success, string? ResetToken, string Message)> VerifyOtpAsync(string email, string code)
        {
            try
            {
                var response = await DalHelper.Client.SendAsync(
                    DalHelper.Build(HttpMethod.Post, "auth/otp/verify", new { email, code }));
                string body = await response.Content.ReadAsStringAsync();
                if (!response.IsSuccessStatusCode)
                    return (false, null, DalHelper.ParseErrorMessage(body));

                var json = JObject.Parse(body);
                return (true, json["resetToken"]?.ToString(), "Xác thực thành công.");
            }
            catch (Exception ex)
            {
                return (false, null, "Lỗi kết nối: " + ex.Message);
            }
        }

        // Đổi mật khẩu: bắt buộc kèm reset-token (server đã xác thực OTP). Không còn dùng secretKey tĩnh.
        public static async Task<(bool Success, string Message)> UpdatePasswordAsync(string email, string newPassword, string resetToken)
        {
            try
            {
                var response = await DalHelper.Client.SendAsync(
                    DalHelper.Build(HttpMethod.Put, "auth/password",
                        new { email, newPassword, resetToken }));

                string body = await response.Content.ReadAsStringAsync();
                return response.IsSuccessStatusCode
                    ? (true, "Đổi mật khẩu thành công!")
                    : (false, DalHelper.ParseErrorMessage(body));
            }
            catch (Exception ex)
            {
                return (false, "Lỗi kết nối: " + ex.Message);
            }
        }
    }
}
