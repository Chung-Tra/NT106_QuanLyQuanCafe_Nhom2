using DTO;
using Newtonsoft.Json;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace DAL
{
    /// <summary>
    /// Shared HTTP helper dùng chung cho tất cả DAL.
    /// - Một HttpClient duy nhất (best practice)
    /// - Tự động đính Bearer token từ GlobalSession
    /// - BaseUrl lấy từ App.config
    /// </summary>
    internal static class DalHelper
    {
        internal static readonly HttpClient Client = new();
        internal static string BaseUrl =>
            ConfigurationManager.AppSettings["ApiBaseUrl"] ?? "http://localhost:3000/api/";

        internal static HttpRequestMessage Build(HttpMethod method, string relativeUrl, object? body = null)
        {
            var request = new HttpRequestMessage(method, BaseUrl + relativeUrl);
            if (!string.IsNullOrEmpty(GlobalSession.Token))
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", GlobalSession.Token);
            if (body != null)
                request.Content = new StringContent(
                    JsonConvert.SerializeObject(body), Encoding.UTF8, "application/json");
            return request;
        }

        /// <summary>Đọc message/error từ JSON response body của server.</summary>
        internal static string ParseErrorMessage(string responseBody)
        {
            try
            {
                dynamic? obj = JsonConvert.DeserializeObject(responseBody);
                return (string?)(obj?.message ?? obj?.error) ?? responseBody;
            }
            catch
            {
                return responseBody;
            }
        }
    }
}
