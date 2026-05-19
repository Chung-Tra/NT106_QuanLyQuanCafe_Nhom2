using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace GUI
{
    /// <summary>
    /// Hộp thoại thông báo tùy chỉnh, thay thế MessageBox mặc định của Windows.
    /// Hỗ trợ 4 kiểu: Info, Success, Error, Warning.
    /// - Warning : hiện 2 nút (Có / Không), trả về DialogResult.Yes / No
    /// - Còn lại  : hiện 1 nút (Đồng ý),    trả về DialogResult.OK
    /// Form tự động co giãn chiều cao theo độ dài nội dung.
    /// </summary>
    internal partial class MsgBox : Form
    {
        // Chiều rộng cố định của hộp thoại (px)
        private const int FormWidthPx = 420;

        // ────────────────────────────────────────────────
        // Win32 API — cho phép kéo form không có title bar
        // ────────────────────────────────────────────────
        [DllImport("user32.dll")]
        private static extern bool ReleaseCapture();

        [DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        public MsgBox()
        {
            InitializeComponent();

            // Bật double-buffer để tránh nhấp nháy khi vẽ lại form
            SetStyle(
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.UserPaint            |
                ControlStyles.DoubleBuffer,
                true);
            DoubleBuffered = true;
        }

        // ──────────────────────────────────────────────
        // PUBLIC API
        // ──────────────────────────────────────────────
        public static DialogResult Show(
            string message,
            string title        = "Thông báo",
            MessageBoxType type = MessageBoxType.Info) =>
            Show(null, message, title, type);

        public static DialogResult Show(
            IWin32Window? owner,
            string message,
            string title        = "Thông báo",
            MessageBoxType type = MessageBoxType.Info)
        {
            using MsgBox msg = new MsgBox();
            msg.lblTitle.Text = title;
            msg.ApplyTypeStyle(type);
            msg.LayoutForContent(message ?? string.Empty, type);
            RefreshRoundedRegion(msg);

            return owner == null ? msg.ShowDialog() : msg.ShowDialog(owner);
        }

  
        public static IWin32Window? OwnerWindow(Control? control)
        {
            if (control == null) return null;
            return control.FindForm() ?? control.TopLevelControl as IWin32Window;
        }

        // ──────────────────────────────────────────────
        // BO GÓC TRÒN
        // ──────────────────────────────────────────────
        private static void RefreshRoundedRegion(MsgBox msg)
        {
            if (msg.IsDisposed || msg.ClientSize.Width < 10 || msg.ClientSize.Height < 10)
                return;

            msg.Region?.Dispose();
            msg.Region = RoundedCornerRegion(msg.ClientRectangle, radius: 18);
        }

        private static Region RoundedCornerRegion(Rectangle bounds, float radius)
        {
            using GraphicsPath gp = CreateRoundRect(bounds, radius);
            return new Region(gp);
        }

        /// <summary>
        /// Xây dựng GraphicsPath hình chữ nhật bo 4 góc theo chiều kim đồng hồ.
        /// diameter bị clamp để không vượt quá chiều rộng/cao thực tế của form.
        /// </summary>
        private static GraphicsPath CreateRoundRect(Rectangle b, float r)
        {
            float diameter = Math.Min(Math.Min(Math.Abs(r) * 2, b.Width), b.Height);
            var path = new GraphicsPath();

            RectangleF arc = new(b.X, b.Y, diameter, diameter);
            path.AddArc(arc, 180, 90); // góc trên-trái

            arc.X = b.Right - diameter;
            path.AddArc(arc, 270, 90); // góc trên-phải

            arc.Y = b.Bottom - diameter;
            path.AddArc(arc, 0, 90);   // góc dưới-phải

            arc.X = b.X;
            path.AddArc(arc, 90, 90);  // góc dưới-trái

            path.CloseFigure();
            return path;
        }

        // Cập nhật lại Region khi form thay đổi kích thước
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            RefreshRoundedRegion(this);
        }

        // ──────────────────────────────────────────────
        // TỰ ĐỘNG CO GIÃN THEO NỘI DUNG
        // ──────────────────────────────────────────────
        private static int GetMaxMessageViewportPx()
        {
            try
            {
                int h = Screen.PrimaryScreen?.WorkingArea.Height ?? 800;
                return Math.Min(520, Math.Max(200, (int)(h * 0.45)));
            }
            catch
            {
                return 420; 
            }
        }

        private void LayoutForContent(string message, MessageBoxType type)
        {
            int padX   = 24;                      // khoảng cách lề trái/phải
            int innerW = FormWidthPx - padX * 2;  // chiều rộng nội dung

            // Đảm bảo handle được tạo trước khi đo kích thước text
            if (!IsHandleCreated) CreateControl();
            txtMessage.CreateControl();

            txtMessage.Location = new Point(padX, 18);
            txtMessage.Width    = innerW;
            txtMessage.WordWrap = true;

            // Chuẩn hóa ký tự xuống dòng (tránh lẫn lộn \r\n / \n / \r)
            string m = (message ?? string.Empty)
                       .Replace("\r\n", "\n")
                       .Replace('\r', '\n');
            txtMessage.Text = m.Replace("\n", Environment.NewLine);

            // Tự động điều chỉnh chiều cao TextBox vừa đủ với nội dung
            int maxViewport = GetMaxMessageViewportPx();
            DialogAutosizeHelper.SetWrappedTextBoxHeight(txtMessage, minHeight: 56, maxHeight: maxViewport);

            const int gapBeforeButtons = 18; 
            const int bottomMargin     = 20; 
            int btnY = txtMessage.Bottom + gapBeforeButtons;

            if (type == MessageBoxType.Warning)
            {
                btnOk.Text         = "Có";
                btnOk.DialogResult = DialogResult.Yes;

                btnCancel.Visible      = true;
                btnCancel.Text         = "Không";
                btnCancel.DialogResult = DialogResult.No;

                int totalW = btnOk.Width + 14 + btnCancel.Width;
                int leftX  = (FormWidthPx - totalW) / 2;
                btnOk.Location     = new Point(leftX, btnY);
                btnCancel.Location = new Point(leftX + btnOk.Width + 14, btnY);
            }
            else
            {
                btnOk.Text         = "Đồng ý";
                btnOk.DialogResult = DialogResult.OK;
                btnCancel.Visible  = false;

                int cx = Math.Max(padX, (FormWidthPx - btnOk.Width) / 2);
                btnOk.Location = new Point(cx, btnY);
            }

            // Điều chỉnh chiều cao tổng thể của form
            int bodyHeight = btnY + btnOk.Height + bottomMargin;
            ClientSize = new Size(FormWidthPx, pnlHeader.Height + bodyHeight);
        }

        // ──────────────────────────────────────────────
        // ÁP DỤNG STYLE THEO LOẠI THÔNG BÁO
        // ──────────────────────────────────────────────
        private void ApplyTypeStyle(MessageBoxType type)
        {
            (Color themeColor, string icon) = type switch
            {
                MessageBoxType.Success => (Color.FromArgb(34,  167, 94),  "✓"),
                MessageBoxType.Error   => (Color.FromArgb(220, 53,  69),  "✕"),
                MessageBoxType.Warning => (Color.FromArgb(245, 158, 11),  "⚠"),
                _                      => (Color.FromArgb(31,  138, 154), "ℹ"),
            };

            pnlHeader.BackColor        = themeColor;
            lblIcon.Text               = icon;
            btnOk.FillColor            = themeColor;
            btnOk.HoverState.FillColor = LightenColor(themeColor, 0.1f);
            btnOk.ForeColor            = Color.White;
        }

        private static Color LightenColor(Color c, float factor)
        {
            int r = (int)Math.Min(255, c.R + (255 - c.R) * factor);
            int g = (int)Math.Min(255, c.G + (255 - c.G) * factor);
            int b = (int)Math.Min(255, c.B + (255 - c.B) * factor);
            return Color.FromArgb(r, g, b);
        }

        // ──────────────────────────────────────────────
        // ENUM LOẠI THÔNG BÁO
        // ──────────────────────────────────────────────
        public enum MessageBoxType { Info, Success, Error, Warning }

        // ──────────────────────────────────────────────
        // SỰ KIỆN
        // ──────────────────────────────────────────────

        private void PnlHeader_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            ReleaseCapture();
            _ = SendMessage(Handle, 0xA1, 0x2, 0);
        }

        // ────────────────────────────────────
        // Sự kiện click của nút OK và Cancel. 
        // ────────────────────────────────────
        private void BtnOk_Click(object sender, EventArgs e)
        {
            DialogResult = btnOk.DialogResult == DialogResult.None
                ? DialogResult.OK
                : btnOk.DialogResult;
            Close();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = btnCancel.DialogResult == DialogResult.None
                ? DialogResult.Cancel
                : btnCancel.DialogResult;
            Close();
        }
    }
}
