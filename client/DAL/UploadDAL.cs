using DTO;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace DAL
{
    /// <summary>
    /// Tải ảnh lên Firebase Storage thông qua backend (POST /api/upload).
    /// Trả về URL tải công khai để lưu vào hinh_anh_url / avatar_url.
    /// </summary>
    public static class UploadDAL
    {
        public static async Task<(bool Success, string Message, string? Url)> UploadImageAsync(string filePath, string folder)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(filePath) || !File.Exists(filePath))
                    return (false, "Không tìm thấy file ảnh.", null);

                using var form = new MultipartFormDataContent();
                var bytes = await Task.Run(() => File.ReadAllBytes(filePath));
                var fileContent = new ByteArrayContent(bytes);
                fileContent.Headers.ContentType = new MediaTypeHeaderValue(GuessMime(filePath));
                form.Add(fileContent, "file", Path.GetFileName(filePath));
                form.Add(new StringContent(folder ?? "misc"), "folder");

                var request = new HttpRequestMessage(HttpMethod.Post, DalHelper.BaseUrl + "upload")
                {
                    Content = form
                };
                if (!string.IsNullOrEmpty(GlobalSession.Token))
                    request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", GlobalSession.Token);

                var response = await DalHelper.Client.SendAsync(request);
                string body = await response.Content.ReadAsStringAsync();
                if (!response.IsSuccessStatusCode)
                    return (false, DalHelper.ParseErrorMessage(body), null);

                string? url = null;
                try { dynamic? o = JsonConvert.DeserializeObject(body); url = (string?)o?.url; } catch { }
                return (true, "Tải ảnh thành công!", url);
            }
            catch (Exception ex) { return (false, "Lỗi tải ảnh: " + ex.Message, null); }
        }

        private static string GuessMime(string path)
        {
            return Path.GetExtension(path).ToLowerInvariant() switch
            {
                ".png" => "image/png",
                ".gif" => "image/gif",
                ".webp" => "image/webp",
                ".bmp" => "image/bmp",
                _ => "image/jpeg",
            };
        }
    }
}
