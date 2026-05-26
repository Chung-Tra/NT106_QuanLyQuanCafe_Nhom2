using DTO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Configuration;
using System.Net.Http;
using System.Threading.Tasks;

namespace DAL
{
    public static class AuthDAL
    {
        private static readonly string? _secretKey = ConfigurationManager.AppSettings["FirebaseSecretKey"];

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

        public static async Task<string?> GenerateOtpAsync(string toEmail)
        {
            try
            {
                var response = await DalHelper.Client.SendAsync(
                    DalHelper.Build(HttpMethod.Post, "auth/otp/generate", new { toEmail }));
                if (!response.IsSuccessStatusCode) return null;

                var json = JObject.Parse(await response.Content.ReadAsStringAsync());
                return json["code"]?.ToString();
            }
            catch { return null; }
        }

        public static async Task<(bool Success, string Message)> UpdatePasswordAsync(string email, string newPassword)
        {
            try
            {
                var response = await DalHelper.Client.SendAsync(
                    DalHelper.Build(HttpMethod.Put, "auth/password",
                        new { email, newPassword, secretKey = _secretKey }));

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