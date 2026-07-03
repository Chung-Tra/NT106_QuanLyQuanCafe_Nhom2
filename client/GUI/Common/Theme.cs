using System;
using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace GUI
{
    internal static class Theme
    {
        // Palette
        public static readonly Color AppBg        = Color.FromArgb(39, 39, 42);
        public static readonly Color Surface      = Color.FromArgb(31, 31, 34);
        public static readonly Color SurfaceAlt   = Color.FromArgb(24, 24, 27);
        public static readonly Color SurfaceHover = Color.FromArgb(45, 45, 50);
        public static readonly Color Border       = Color.FromArgb(63, 63, 70);
        public static readonly Color BorderSoft   = Color.FromArgb(50, 50, 56);

        public static readonly Color Teal       = Color.FromArgb(31, 138, 154);
        public static readonly Color TealHover  = Color.FromArgb(45, 158, 174);
        public static readonly Color Green      = Color.FromArgb(34, 197, 94);
        public static readonly Color GreenHover = Color.FromArgb(54, 211, 112);
        public static readonly Color Red        = Color.FromArgb(220, 80, 80);
        public static readonly Color RedHover   = Color.FromArgb(235, 100, 100);
        public static readonly Color Amber      = Color.FromArgb(245, 158, 11);
        public static readonly Color Blue       = Color.FromArgb(70, 130, 180);
        public static readonly Color Purple     = Color.FromArgb(139, 110, 220);

        public static readonly Color TextHi    = Color.FromArgb(240, 240, 245);
        public static readonly Color TextPri   = Color.FromArgb(220, 220, 225);
        public static readonly Color TextMuted = Color.FromArgb(160, 160, 166);
        public static readonly Color TextFaint = Color.FromArgb(110, 110, 120);

        // Fonts
        public static Font F(float size, FontStyle style = FontStyle.Regular) => new("Segoe UI", size, style);

        // Card / panel
        public static Guna2Panel Card(Color? fill = null, int radius = 14)
        {
            return new Guna2Panel
            {
                FillColor    = fill ?? Surface,
                BackColor    = Color.Transparent,
                BorderRadius = radius,
            };
        }

        public static Guna2Panel StatCard(string caption, string value, Color accent,
                                          out Label valueLabel, string? sub = null)
        {
            var card = Card(Surface);
            card.Size = new Size(220, 96);

            var bar = new Guna2Panel
            {
                FillColor    = accent,
                BorderRadius = 4,
                Location     = new Point(14, 16),
                Size         = new Size(4, 64),
            };

            var cap = new Label
            {
                Text      = caption,
                AutoSize  = true,
                Font      = F(9.5F),
                ForeColor = TextMuted,
                Location  = new Point(28, 16),
                BackColor = Color.Transparent,
            };

            var val = new Label
            {
                Text      = value,
                AutoSize  = true,
                Font      = F(19F, FontStyle.Bold),
                ForeColor = TextHi,
                Location  = new Point(26, 38),
                BackColor = Color.Transparent,
            };

            card.Controls.Add(bar);
            card.Controls.Add(cap);
            card.Controls.Add(val);

            if (!string.IsNullOrEmpty(sub))
            {
                card.Controls.Add(new Label
                {
                    Text      = sub,
                    AutoSize  = true,
                    Font      = F(8.5F),
                    ForeColor = accent,
                    Location  = new Point(28, 72),
                    BackColor = Color.Transparent,
                });
            }

            valueLabel = val;
            return card;
        }

        // Buttons
        public static Guna2Button PrimaryButton(string text, Color? fill = null)
        {
            var b = new Guna2Button
            {
                Text         = text,
                BorderRadius = 10,
                FillColor    = fill ?? Teal,
                ForeColor    = Color.White,
                Font         = F(9.5F, FontStyle.Bold),
                Cursor       = Cursors.Hand,
            };
            b.HoverState.FillColor = Lighten(fill ?? Teal, 16);
            return b;
        }

        public static Guna2Button GhostButton(string text, Color? line = null, Color? fg = null)
        {
            var c = line ?? Border;
            var b = new Guna2Button
            {
                Text             = text,
                BorderRadius     = 10,
                BorderThickness  = 1,
                BorderColor      = c,
                FillColor        = Color.Transparent,
                ForeColor        = fg ?? TextPri,
                Font             = F(9.5F, FontStyle.Bold),
                Cursor           = Cursors.Hand,
            };
            b.HoverState.FillColor    = SurfaceHover;
            b.HoverState.BorderColor  = Lighten(c, 40);
            return b;
        }

        // Textbox
        public static Guna2TextBox Input(string placeholder = "", int width = 200)
        {
            return new Guna2TextBox
            {
                BorderColor          = Border,
                BorderRadius         = 8,
                FillColor            = Color.FromArgb(30, 30, 33),
                Font                 = F(9.5F),
                ForeColor            = TextHi,
                PlaceholderText      = placeholder,
                PlaceholderForeColor = TextFaint,
                Size                 = new Size(width, 36),
                FocusedState         = { BorderColor = Teal },
                HoverState           = { BorderColor = Color.FromArgb(120, 120, 130) },
            };
        }

        // Labels
        public static Label Heading(string text, float size = 13F) => new()
        {
            Text      = text,
            AutoSize  = true,
            Font      = F(size, FontStyle.Bold),
            ForeColor = TextHi,
            BackColor = Color.Transparent,
        };

        public static Label Caption(string text, float size = 9F) => new()
        {
            Text      = text,
            AutoSize  = true,
            Font      = F(size),
            ForeColor = TextMuted,
            BackColor = Color.Transparent,
        };

        public static Guna2Button Badge(string text, Color color)
        {
            return new Guna2Button
            {
                Text         = text,
                BorderRadius = 10,
                FillColor    = Fade(color, 38),
                ForeColor    = Lighten(color, 30),
                Font         = F(8F, FontStyle.Bold),
                Cursor       = Cursors.Default,
                Enabled      = false,
                AutoSize     = false,
                Size         = new Size(78, 24),
                DisabledState = { FillColor = Fade(color, 38), ForeColor = Lighten(color, 30), BorderColor = Color.Transparent },
            };
        }

        // Grid styling
        public static void StyleGrid(Guna2DataGridView dgv)
        {
            // Cột được khai trong .Designer.cs (để thấy trong VS Designer) → tắt auto-gen ở đây
            // (runtime helper, Designer không serialize lại nên không bị mất khi round-trip).
            dgv.AutoGenerateColumns   = false;
            dgv.AllowUserToAddRows    = false;
            dgv.AllowUserToResizeRows = false;
            dgv.BackgroundColor       = SurfaceAlt;
            dgv.BorderStyle           = BorderStyle.None;
            dgv.CellBorderStyle       = DataGridViewCellBorderStyle.SingleHorizontal;
            dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgv.ColumnHeadersHeight   = 36;
            dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgv.ColumnHeadersDefaultCellStyle.BackColor        = Surface;
            dgv.ColumnHeadersDefaultCellStyle.ForeColor        = TextMuted;
            dgv.ColumnHeadersDefaultCellStyle.Font             = F(9F, FontStyle.Bold);
            dgv.ColumnHeadersDefaultCellStyle.SelectionBackColor = Surface;
            dgv.ColumnHeadersDefaultCellStyle.SelectionForeColor = TextMuted;
            dgv.ColumnHeadersDefaultCellStyle.Padding          = new Padding(8, 0, 0, 0);
            dgv.DefaultCellStyle.BackColor       = SurfaceAlt;
            dgv.DefaultCellStyle.ForeColor       = TextPri;
            dgv.DefaultCellStyle.Font            = F(9F);
            dgv.DefaultCellStyle.SelectionBackColor = Teal;
            dgv.DefaultCellStyle.SelectionForeColor = TextHi;
            dgv.DefaultCellStyle.Padding         = new Padding(8, 0, 0, 0);
            dgv.AlternatingRowsDefaultCellStyle.BackColor       = Color.FromArgb(28, 28, 31);
            dgv.AlternatingRowsDefaultCellStyle.ForeColor       = TextPri;
            dgv.AlternatingRowsDefaultCellStyle.SelectionBackColor = Teal;
            dgv.AlternatingRowsDefaultCellStyle.SelectionForeColor = TextHi;
            dgv.EnableHeadersVisualStyles = false;
            dgv.GridColor       = Color.FromArgb(45, 45, 48);
            dgv.MultiSelect     = false;
            dgv.ReadOnly        = true;
            dgv.RowHeadersVisible = false;
            dgv.RowTemplate.Height = 34;
            dgv.SelectionMode   = DataGridViewSelectionMode.FullRowSelect;
            try
            {
                DgvDarkScroll.Apply(dgv);
            }
            catch { }

            // Tự canh lề dữ liệu hợp lý sau mỗi lần bind (ít → giữa, nhiều → trái).
            GridAutoAlign.Enable(dgv);
        }

        // Color utils
        public static Color Lighten(Color c, int amt) => Color.FromArgb(
            Math.Min(255, c.R + amt), Math.Min(255, c.G + amt), Math.Min(255, c.B + amt));

        public static Color Darken(Color c, int amt) => Color.FromArgb(
            Math.Max(0, c.R - amt), Math.Max(0, c.G - amt), Math.Max(0, c.B - amt));

        public static Color Fade(Color c, int alpha)
        {
            double a = alpha / 255.0;
            return Color.FromArgb(
                (int)(c.R * a + Surface.R * (1 - a)),
                (int)(c.G * a + Surface.G * (1 - a)),
                (int)(c.B * a + Surface.B * (1 - a)));
        }

        public static string Vnd(long amount) =>
            amount.ToString("#,##0", System.Globalization.CultureInfo.GetCultureInfo("vi-VN")) + " đ";

        // Gắn scroll teal + bỏ viền panel/card thừa trên toàn bộ cây control của UC/Form.
        public static void PolishContainer(Control root)
        {
            if (root == null || root.IsDisposed) return;
            try { AutoFadeScroll.AttachAll(root); } catch { }
            ApplySurfacePolish(root);
        }

        private static void ApplySurfacePolish(Control c)
        {
            if (c is Guna2Panel p)
                p.BorderThickness = 0;

            if (c is Guna2DataGridView g)
            {
                try { StyleGrid(g); } catch { }
            }

            foreach (Control child in c.Controls)
                ApplySurfacePolish(child);
        }
    }
}
