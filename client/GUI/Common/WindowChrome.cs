using System;
using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using Guna.UI2.WinForms.Enums;

namespace GUI
{
    // Gắn nút điều khiển cửa sổ (Minimize / Maximize / Close) bằng Guna2ControlBox
    // và cho phép kéo di chuyển form bằng Guna2DragControl.
    // Dùng cho MỌI Form (không dùng cho UserControl). Gọi sau InitializeComponent().
    internal static class WindowChrome
    {
        // host: nơi đặt các nút (mặc định = form; truyền panel card nếu muốn nút nằm trên card).
        // dragHandle: control để kéo form (mặc định = host).
        // onClose: nếu set, nút Close sẽ chạy hành động này (vd Application.Exit) thay vì chỉ đóng form.
        public static void Apply(Form form, bool minimize = false, bool maximize = false,
                                 bool close = true, Control? host = null, Control? dragHandle = null,
                                 Action? onClose = null)
        {
            host ??= form;

            // Kéo form (giữ tham chiếu sống theo vòng đời form, tự dispose khi form đóng).
            var drag = new Guna2DragControl
            {
                TargetControl      = dragHandle ?? host,
                UseTransparentDrag = true,
            };
            form.Disposed += (s, e) => drag.Dispose();

            // Các nút điều khiển, xếp từ phải sang trái.
            const int w = 36, h = 28, top = 8, gap = 2, margin = 10;
            int right = host.ClientSize.Width - margin;

            if (close)
            {
                var box = MakeBox(ControlBoxType.CloseBox, right - w, top, w, h, isClose: true);
                if (onClose != null) box.Click += (s, e) => onClose();
                host.Controls.Add(box);
                box.BringToFront();
                right -= w + gap;
            }
            if (maximize)
            {
                var box = MakeBox(ControlBoxType.MaximizeBox, right - w, top, w, h);
                host.Controls.Add(box);
                box.BringToFront();
                right -= w + gap;
            }
            if (minimize)
            {
                var box = MakeBox(ControlBoxType.MinimizeBox, right - w, top, w, h);
                host.Controls.Add(box);
                box.BringToFront();
            }

            // '&' trong Text bị WinForms vẽ thành '_' (mnemonic) — tắt ngay cho các control
            // đã dựng trong InitializeComponent, và tắt lại lúc Shown cho các control dựng
            // động sau constructor. Mọi Form đều qua WindowChrome.Apply nên áp dụng toàn cục.
            try { MnemonicFix.Apply(form); } catch { }

            // Tự gắn AutoFadeScroll (thanh teal + chừa lề phải tránh che số tiền + canh lề
            // dữ liệu hợp lý) cho MỌI DataGridView + panel AutoScroll trong form, ngay khi
            // form hiển thị — lúc lưới đã có dữ liệu và đã layout xong. Attach có khử trùng
            // nên không ngại form đã tự gọi Attach.
            form.Shown += (s, e) =>
            {
                try { AutoFadeScroll.AttachAll(form); } catch { }
                try { MnemonicFix.Apply(form); } catch { }
            };
        }

        private static Guna2ControlBox MakeBox(ControlBoxType type, int x, int y, int w, int h, bool isClose = false)
        {
            var box = new Guna2ControlBox
            {
                ControlBoxType = type,
                Size           = new Size(w, h),
                Location       = new Point(x, y),
                Anchor         = AnchorStyles.Top | AnchorStyles.Right,
                FillColor      = Color.Transparent,
                IconColor      = Color.FromArgb(190, 190, 196),
            };
            box.HoverState.FillColor = isClose ? Color.FromArgb(220, 80, 80) : Color.FromArgb(55, 55, 62);
            return box;
        }
    }
}
