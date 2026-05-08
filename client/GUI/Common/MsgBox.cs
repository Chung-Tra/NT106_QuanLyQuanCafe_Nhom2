using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace GUI
{
    internal partial class MsgBox : Form
    {
        private const int FormWidthPx = 400;

        [DllImport("user32.dll")]
        private static extern bool ReleaseCapture();
        [DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        public MsgBox()
        {
            InitializeComponent();
            SetStyle(
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.UserPaint |
                ControlStyles.DoubleBuffer,
                true);
            DoubleBuffered = true;
        }

        public static DialogResult Show(string message, string title = "Thông báo", MessageBoxType type = MessageBoxType.Info) =>
            Show(null, message, title, type);

        /// <summary>Form chứa control (FindForm hoặc TopLevelControl) — làm owner cho ShowDialog / MsgBox.</summary>
        public static IWin32Window? OwnerWindow(Control? control)
        {
            if (control == null) return null;
            return control.FindForm() ?? control.TopLevelControl as IWin32Window;
        }

        public static DialogResult Show(IWin32Window? owner, string message, string title = "Thông báo", MessageBoxType type = MessageBoxType.Info)
        {
            using MsgBox msg = new MsgBox();
            msg.lblTitle.Text = title;
            msg.ApplyTypeStyle(type);
            msg.LayoutForContent(message ?? string.Empty, type);
            RefreshRoundedRegion(msg);

            return owner == null ? msg.ShowDialog() : msg.ShowDialog(owner);
        }

        private static void RefreshRoundedRegion(MsgBox msg)
        {
            if (msg.IsDisposed || msg.ClientSize.Width < 10 || msg.ClientSize.Height < 10)
                return;

            msg.Region?.Dispose();
            msg.Region = RoundedCornerRegion(msg.ClientRectangle, radius: 16);
        }

        private static Region RoundedCornerRegion(Rectangle bounds, float radius)
        {
            using GraphicsPath gp = CreateRoundRect(bounds, radius);
            return new Region(gp);
        }

        private static GraphicsPath CreateRoundRect(Rectangle b, float r)
        {
            float diameter = Math.Min(Math.Min(Math.Abs(r) * 2, b.Width), b.Height);
            var path = new GraphicsPath();

            RectangleF arc = new(b.X, b.Y, diameter, diameter);
            path.AddArc(arc, 180, 90);

            arc.X = b.Right - diameter;
            path.AddArc(arc, 270, 90);

            arc.Y = b.Bottom - diameter;
            path.AddArc(arc, 0, 90);

            arc.X = b.X;
            path.AddArc(arc, 90, 90);
            path.CloseFigure();
            return path;
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            RefreshRoundedRegion(this);
        }

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
            int padX = 20;
            int innerW = FormWidthPx - padX * 2;

            // Có handle + kích thước thật trước khi MeasureText (tránh ClientSize.Width = 0 khi chưa layout)
            if (!IsHandleCreated)
                CreateControl();
            txtMessage.CreateControl();

            txtMessage.Location = new Point(padX, 10);
            txtMessage.Width = innerW;
            txtMessage.WordWrap = true;
            // TextBox WinForms hiển thị/đo chiều cao đúng với CRLF; message ở call site vẫn có thể chỉ dùng \n.
            string m = message ?? string.Empty;
            m = m.Replace("\r\n", "\n").Replace('\r', '\n');
            txtMessage.Text = m.Replace("\n", Environment.NewLine);

            int maxViewport = GetMaxMessageViewportPx();
            DialogAutosizeHelper.SetWrappedTextBoxHeight(txtMessage, minHeight: 56, maxHeight: maxViewport);

            const int gapBeforeButtons = 14;
            const int bottomMargin = 16;
            int btnY = txtMessage.Bottom + gapBeforeButtons;

            if (type == MessageBoxType.Warning)
            {
                btnOk.Text = "CÓ";
                btnOk.DialogResult = DialogResult.Yes;

                btnCancel.Visible = true;
                btnCancel.Text = "KHÔNG";
                btnCancel.DialogResult = DialogResult.No;

                btnOk.Location = new Point(70, btnY);
                btnCancel.Location = new Point(210, btnY);
            }
            else
            {
                btnOk.Text = "ĐỒNG Ý";
                btnOk.DialogResult = DialogResult.OK;
                btnCancel.Visible = false;

                int cx = Math.Max(padX, (pnlBody.Width - btnOk.Width) / 2);
                btnOk.Location = new Point(cx, btnY);
            }

            int bodyHeight = btnY + btnOk.Height + bottomMargin;
            ClientSize = new Size(FormWidthPx, pnlHeader.Height + bodyHeight);
        }

        private void ApplyTypeStyle(MessageBoxType type)
        {
            Color themeColor = type switch
            {
                MessageBoxType.Success => Color.FromArgb(40, 167, 69),
                MessageBoxType.Error => Color.FromArgb(220, 53, 69),
                MessageBoxType.Warning => Color.FromArgb(255, 193, 7),
                _ => Color.FromArgb(0, 123, 255),
            };

            pnlHeader.BackColor = themeColor;
            btnOk.BackColor = themeColor;
            btnOk.ForeColor = type == MessageBoxType.Warning ? Color.Black : Color.White;
        }

        public enum MessageBoxType { Info, Success, Error, Warning }

        private void PnlHeader_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;

            ReleaseCapture();
            _ = SendMessage(Handle, 0xA1, 0x2, 0);
        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
        }
    }
}
