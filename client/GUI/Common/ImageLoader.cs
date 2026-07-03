using System;
using System.Drawing;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace GUI
{
    /// <summary>
    /// Tải ảnh từ URL (Firebase Storage) hoặc đường dẫn file cục bộ để hiển thị lên PictureBox.
    /// Có cache nhỏ trong bộ nhớ để tránh tải lại nhiều lần.
    /// </summary>
    public static class ImageLoader
    {
        private static readonly HttpClient _http = new() { Timeout = TimeSpan.FromSeconds(15) };
        private static readonly System.Collections.Concurrent.ConcurrentDictionary<string, Image> _cache = new();

        public static async Task<Image?> FromUrlAsync(string? url)
        {
            if (string.IsNullOrWhiteSpace(url)) return null;
            if (_cache.TryGetValue(url, out var cached)) return cached;

            try
            {
                Image? img = null;
                if (url.StartsWith("http", StringComparison.OrdinalIgnoreCase))
                {
                    var bytes = await _http.GetByteArrayAsync(url);
                    using var ms = new MemoryStream(bytes);
                    img = Image.FromStream(ms);
                }
                else if (File.Exists(url))
                {
                    using var fs = new FileStream(url, FileMode.Open, FileAccess.Read);
                    img = Image.FromStream(fs);
                }

                if (img != null) _cache[url] = img;
                return img;
            }
            catch { return null; }
        }

        /// <summary>Gán ảnh vào PictureBox an toàn (chạy async, không chặn UI). Bỏ qua nếu tải lỗi.</summary>
        public static async void SetImageAsync(System.Windows.Forms.PictureBox pic, string? url)
        {
            var img = await FromUrlAsync(url);
            if (img != null && !pic.IsDisposed)
            {
                try { pic.Image = img; } catch { }
            }
        }
    }
}
