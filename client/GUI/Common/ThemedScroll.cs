using System;
using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace GUI
{
    // Thanh cuộn dọc theme tối/teal (Guna2VScrollBar) cho 1 viewport chứa content cao hơn nó.
    // - Khi viewport cao >= minContentHeight: content giãn lấp đầy, ẩn thanh cuộn.
    // - Khi viewport thấp hơn: content giữ chiều cao tối thiểu, hiện thanh cuộn để xem hết.
    // Lưu ý: ĐỪNG Dock control content — helper tự quản Bounds của nó.
    internal static class ThemedScroll
    {
        public static void AttachVertical(Control viewport, Control content, int minContentHeight)
        {
            var bar = new Guna2VScrollBar
            {
                Width        = 9,
                BorderRadius = 4,
                ThumbColor   = Color.FromArgb(31, 138, 154),  // teal (đồng bộ app)
                FillColor    = Color.FromArgb(24, 24, 27),    // rãnh tối
                Minimum      = 0,
                Maximum      = 0,
                Visible      = false,
            };
            viewport.Controls.Add(bar);
            bar.BringToFront();

            bool laying = false;

            void Relayout()
            {
                if (laying || viewport.IsDisposed) return;
                laying = true;
                try
                {
                    int vw = viewport.ClientSize.Width;
                    int vh = viewport.ClientSize.Height;
                    if (vw <= 0 || vh <= 0) return;

                    int contentH = Math.Max(vh, minContentHeight);
                    bool need = contentH > vh;
                    int barW = need ? bar.Width : 0;

                    content.SetBounds(0, content.Top, Math.Max(1, vw - barW), contentH);
                    bar.Visible = need;

                    if (need)
                    {
                        bar.SetBounds(vw - bar.Width, 0, bar.Width, vh);
                        bar.BringToFront();
                        bar.LargeChange = vh;
                        bar.Maximum     = contentH - 1;       // theo quy ước ScrollBar .NET: max value dùng được = contentH - vh
                        int val = Math.Clamp(-content.Top, 0, contentH - vh);
                        bar.Value   = val;
                        content.Top = -val;
                    }
                    else
                    {
                        content.Top = 0;
                        bar.Value   = 0;
                    }
                }
                finally { laying = false; }
            }

            bar.ValueChanged += (s, e) =>
            {
                if (laying) return;
                int maxScroll = Math.Max(0, content.Height - viewport.ClientSize.Height);
                content.Top = -Math.Clamp(bar.Value, 0, maxScroll);
            };

            viewport.Resize += (s, e) => Relayout();
            if (viewport.IsHandleCreated) Relayout();
            else viewport.HandleCreated += (s, e) => Relayout();

            // Lăn chuột cuộn được dù con trỏ đang trên chart/thẻ (route qua message filter)
            var filter = new WheelFilter(viewport, bar,
                () => Math.Max(0, content.Height - viewport.ClientSize.Height));
            Application.AddMessageFilter(filter);
            viewport.Disposed += (s, e) => Application.RemoveMessageFilter(filter);
        }

        private sealed class WheelFilter : IMessageFilter
        {
            private readonly Control _viewport;
            private readonly Guna2VScrollBar _bar;
            private readonly Func<int> _maxScroll;

            public WheelFilter(Control viewport, Guna2VScrollBar bar, Func<int> maxScroll)
            {
                _viewport = viewport; _bar = bar; _maxScroll = maxScroll;
            }

            public bool PreFilterMessage(ref Message m)
            {
                const int WM_MOUSEWHEEL = 0x020A;
                if (m.Msg != WM_MOUSEWHEEL || !_bar.Visible || _viewport.IsDisposed || !_viewport.Visible)
                    return false;
                if (!_viewport.RectangleToScreen(_viewport.ClientRectangle).Contains(Control.MousePosition))
                    return false;

                int delta   = (short)(m.WParam.ToInt64() >> 16);
                int notches = delta / 120;
                _bar.Value  = Math.Clamp(_bar.Value - notches * 60, 0, _maxScroll());
                return true; // đã xử lý, không cho chart zoom
            }
        }
    }
}
