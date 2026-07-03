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

        // Dựng 1 Form KHÔNG viền theo đúng theme app (thay cho các popup `new Form` viền
        // Windows trắng + scrollbar gốc). Có: nền tối, bo góc, thanh tiêu đề mảnh (kéo di
        // chuyển + nút đóng) và tự ẩn scrollbar gốc (AutoFadeScroll qua Apply → Shown).
        //
        // `content` trả ra là vùng NỘI DUNG (dưới thanh tiêu đề), cao đúng bằng `size` để
        // layout toạ độ tuyệt đối của popup cũ không bị lệch — chỉ việc add control vào đây
        // thay cho add vào form.
        public static Form CreateDialog(string title, Size size, out Panel content,
                                        IWin32Window? owner = null, bool minimize = false, bool maximize = false)
        {
            const int barH = 40;
            var form = new Form
            {
                Text            = title,
                FormBorderStyle = FormBorderStyle.None,
                StartPosition   = owner != null ? FormStartPosition.CenterParent : FormStartPosition.CenterScreen,
                Size            = new Size(size.Width, size.Height + barH),
                BackColor       = Color.FromArgb(24, 24, 27),
                ShowInTaskbar   = owner == null,
            };

            var bar = new Panel { Dock = DockStyle.Top, Height = barH, BackColor = Color.FromArgb(31, 31, 34) };
            bar.Controls.Add(new Label
            {
                Text      = title,
                AutoSize  = false,
                Dock      = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleLeft,
                Padding   = new Padding(16, 0, 108, 0),   // chừa chỗ cho cụm nút bên phải
                Font      = new Font("Segoe UI", 10.5F, FontStyle.Bold),
                ForeColor = Color.FromArgb(230, 230, 235),
                BackColor = Color.Transparent,
            });

            content = new Panel { Dock = DockStyle.Fill, BackColor = Color.FromArgb(24, 24, 27) };

            // Thêm content (Fill) TRƯỚC, thanh tiêu đề (Top) SAU: layout engine chừa mép trên
            // cho thanh tiêu đề rồi mới cho content lấp phần còn lại (công thức Dock chuẩn).
            form.Controls.Add(content);
            form.Controls.Add(bar);

            FormCorners.Round(form, 14);
            Apply(form, minimize: minimize, maximize: maximize, close: true, host: bar, dragHandle: bar);
            return form;
        }

        // Bọc 1 UserControl full-size trong dialog theme app (dùng cho các màn phụ mở dạng
        // popup: Lịch sử chấm công, Chat pop-out…). modal=false → Show (không chặn UI).
        public static void ShowUc(UserControl uc, string title, Size size,
                                  IWin32Window? owner = null, bool modal = true)
        {
            var form = CreateDialog(title, size, out var content, owner);
            uc.Dock = DockStyle.Fill;
            content.Controls.Add(uc);
            if (modal) form.ShowDialog(owner);
            else form.Show();
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
