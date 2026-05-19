using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Windows.Forms;

namespace GUI
{
    /// <summary>
    /// Load font Lora từ Resources/Fonts/ và áp dụng cho controls.
    /// Gọi <see cref="Initialize"/> 1 lần ở Program.Main trước Application.Run.
    /// </summary>
    internal static class AppFonts
    {
        private static readonly PrivateFontCollection _collection = new();
        private static FontFamily? _loraFamily;

        public static FontFamily? Lora => _loraFamily;

        public static void Initialize()
        {
            try
            {
                string baseDir = AppDomain.CurrentDomain.BaseDirectory;
                string fontsDir = Path.Combine(baseDir, "Resources", "Fonts");
                if (!Directory.Exists(fontsDir)) return;

                foreach (string file in Directory.GetFiles(fontsDir, "Lora*.ttf"))
                {
                    _collection.AddFontFile(file);
                }

                foreach (FontFamily fam in _collection.Families)
                {
                    if (fam.Name.StartsWith("Lora", StringComparison.OrdinalIgnoreCase))
                    {
                        _loraFamily = fam;
                        break;
                    }
                }
            }
            catch
            {
                // Không có font cũng không sao — controls dùng font mặc định
            }
        }

        public static Font CreateLora(float size, FontStyle style = FontStyle.Regular)
        {
            if (_loraFamily == null) return new Font("Segoe UI", size, style);

            // Một số style có thể không có trong file — fallback Regular
            if (!_loraFamily.IsStyleAvailable(style)) style = FontStyle.Regular;
            return new Font(_loraFamily, size, style);
        }

        /// <summary>Áp dụng Lora cho danh sách control (heading, brand). Giữ nguyên size/style cũ.</summary>
        public static void ApplyTo(params Control[] controls)
        {
            if (_loraFamily == null) return;

            foreach (var c in controls)
            {
                if (c == null || c.Font == null) continue;
                try
                {
                    var oldFont = c.Font;
                    var newStyle = _loraFamily.IsStyleAvailable(oldFont.Style) ? oldFont.Style : FontStyle.Regular;
                    c.Font = new Font(_loraFamily, oldFont.Size, newStyle);
                }
                catch { /* skip */ }
            }
        }
    }
}
