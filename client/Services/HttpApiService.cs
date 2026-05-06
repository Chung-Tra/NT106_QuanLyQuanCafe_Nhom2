using Newtonsoft.Json;
using System;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    /// <summary>
    /// HTTP client dùng chung cho tất cả DAL.
    /// Tự động đính kèm Bearer token, base URL lấy từ App.config.
    /// </summary>
    public static class HttpApiService
    {
        private static readonly HttpClient _client = new();

        public static string BaseUrl =>
            ConfigurationManager.AppSettings["ApiBaseUrl"] ?? "http://localhost:3000/api/";

        private static string? _token;

        /// <summary>Đặt token sau khi đăng nhập thành công.</summary>
        public static void SetToken(string token) => _token = token;

        /// <summary>Xóa token khi đăng xuất.</summary>
        public static void ClearToken() => _token = null;

        public static HttpRequestMessage Build(HttpMethod method, string relativeUrl, object? body = null)
        {
            var request = new HttpRequestMessage(method, BaseUrl + relativeUrl);

            if (!string.IsNullOrEmpty(_token))
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _token);

            if (body != null)
                request.Content = new StringContent(
                    JsonConvert.SerializeObject(body), Encoding.UTF8, "application/json");

            return request;
        }

        public static async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request)
        {
            return await _client.SendAsync(request);
        }

        public static async Task<T?> GetAsync<T>(string relativeUrl)
        {
            var response = await _client.SendAsync(Build(HttpMethod.Get, relativeUrl));
            if (!response.IsSuccessStatusCode) return default;
            var json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(json);
        }

        public static async Task<(bool Success, string Message)> PostAsync(string relativeUrl, object body)
        {
            var response = await _client.SendAsync(Build(HttpMethod.Post, relativeUrl, body));
            var content = await response.Content.ReadAsStringAsync();
            return (response.IsSuccessStatusCode, content);
        }

        public static async Task<(bool Success, string Message)> PutAsync(string relativeUrl, object body)
        {
            var response = await _client.SendAsync(Build(HttpMethod.Put, relativeUrl, body));
            var content = await response.Content.ReadAsStringAsync();
            return (response.IsSuccessStatusCode, content);
        }

        public static async Task<(bool Success, string Message)> DeleteAsync(string relativeUrl, object? body = null)
        {
            var response = await _client.SendAsync(Build(HttpMethod.Delete, relativeUrl, body));
            var content = await response.Content.ReadAsStringAsync();
            return (response.IsSuccessStatusCode, content);
        }

        public static async Task<(bool Success, string Message)> PatchAsync(string relativeUrl, object body)
        {
            var response = await _client.SendAsync(Build(HttpMethod.Patch, relativeUrl, body));
            var content = await response.Content.ReadAsStringAsync();
            return (response.IsSuccessStatusCode, content);
        }
    }
}
