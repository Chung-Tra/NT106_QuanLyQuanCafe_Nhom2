using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace GUI
{
    // Hộp thoại thông báo dark-theme tự xuống dòng + tự giãn chiều cao theo nội dung.
    // Giữ nguyên API MsgBox.Show(...) để các call site không phải đổi.
    internal static class MsgBox
    {
        public enum MessageBoxType { Info, Success, Error, Warning }

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
            Form? parent = owner switch
            {
                Form f      => f,
                Control c   => c.FindForm(),
                _           => Application.OpenForms.Cast<Form>().LastOrDefault()
            };

            using var dlg = new MessageForm(message ?? string.Empty, title ?? string.Empty, type);
            if (parent != null && !parent.IsDisposed)
                return dlg.ShowDialog(parent);

            dlg.StartPosition = FormStartPosition.CenterScreen;
            return dlg.ShowDialog();
        }

        // Lấy IWin32Window an toàn từ một Control bất kỳ (UC, Form, ...).
        public static IWin32Window? OwnerWindow(Control? control)
        {
            if (control == null) return null;
            return control.FindForm() ?? control.TopLevelControl as IWin32Window;
        }

        // Form thông báo tự dựng bằng code: icon + tiêu đề + nội dung wrap + nút.
        private sealed class MessageForm : Form
        {
            private static readonly Color Surface   = Color.FromArgb(31, 31, 34);
            private static readonly Color Border    = Color.FromArgb(63, 63, 70);
            private static readonly Color Teal       = Color.FromArgb(31, 138, 154);
            private static readonly Color TealHover  = Color.FromArgb(45, 158, 174);
            private static readonly Color SurfaceHov = Color.FromArgb(45, 45, 50);
            private static readonly Color TextHi     = Color.FromArgb(240, 240, 245);
            private static readonly Color TextPri    = Color.FromArgb(220, 220, 225);

            private const int Pad = 24;
            private const int IconSize = 42;
            private const int Gap = 16;
            private const int MinContentW = 230;
            private const int MaxContentW = 400;

            public MessageForm(string message, string title, MessageBoxType type)
            {
                if (message.Length == 0) message = " ";

                (string glyph, Color accent) = type switch
                {
                    MessageBoxType.Success => ("✓", Color.FromArgb(34, 197, 94)),
                    MessageBoxType.Error   => ("✕", Color.FromArgb(220, 80, 80)),
                    MessageBoxType.Warning => ("!", Color.FromArgb(245, 158, 11)),
                    _                      => ("i", Teal),
                };

                FormBorderStyle = FormBorderStyle.None;
                StartPosition   = FormStartPosition.CenterParent;
                BackColor       = Surface;
                ShowInTaskbar   = false;
                MinimizeBox     = false;
                MaximizeBox     = false;
                KeyPreview      = true;
                Font            = new Font("Segoe UI", 10F);

                var titleFont = new Font("Segoe UI", 13F, FontStyle.Bold);
                var msgFont   = new Font("Segoe UI", 10.5F);

                int leftContent = Pad + IconSize + Gap;

                // Bề rộng vùng nội dung: vừa với chữ ngắn, wrap với chữ dài.
                int naturalMsgW = TextRenderer.MeasureText(message, msgFont).Width;
                int titleW      = TextRenderer.MeasureText(title, titleFont).Width;
                int contentW    = Math.Min(MaxContentW, Math.Max(MinContentW, Math.Max(naturalMsgW, titleW)));

                int formW = leftContent + contentW + Pad;
                int titleY = Pad + 2;
                int msgY   = titleY + (string.IsNullOrWhiteSpace(title) ? 0 : 34);

                // Icon tròn màu theo loại.
                var icon = new Guna2Button
                {
                    Size         = new Size(IconSize, IconSize),
                    BorderRadius = IconSize / 2,
                    FillColor    = Blend(accent, Surface, 0.22),
                    ForeColor    = accent,
                    Text         = glyph,
                    Font         = new Font("Segoe UI", 15F, FontStyle.Bold),
                    Location     = new Point(Pad, Pad),
                    Enabled      = false,
                    TabStop      = false,
                };
                icon.DisabledState.FillColor   = Blend(accent, Surface, 0.22);
                icon.DisabledState.ForeColor   = accent;
                icon.DisabledState.BorderColor = Color.Transparent;
                Controls.Add(icon);

                // Tiêu đề.
                if (!string.IsNullOrWhiteSpace(title))
                {
                    var lblTitle = new Label
                    {
                        AutoSize    = false,
                        Size        = new Size(contentW, 28),
                        Location    = new Point(leftContent, titleY),
                        Text        = title,
                        Font        = titleFont,
                        ForeColor   = TextHi,
                        BackColor   = Color.Transparent,
                        UseMnemonic = false,
                        AutoEllipsis = true,
                    };
                    Controls.Add(lblTitle);
                }

                // Nội dung: wrap + giãn cao; nếu quá cao thì cho cuộn.
                int maxMsgH = Math.Max(80, DialogAutosizeHelper.MaxDialogClientHeight(this) - (msgY + 22 + 44 + Pad));
                int msgH = DialogAutosizeHelper.MeasureWrappedHeight(message, msgFont, contentW);

                Control msgArea;
                if (msgH <= maxMsgH)
                {
                    msgArea = new Label
                    {
                        AutoSize    = false,
                        Size        = new Size(contentW, msgH),
                        Location    = new Point(leftContent, msgY),
                        Text        = message,
                        Font        = msgFont,
                        ForeColor   = TextPri,
                        BackColor   = Color.Transparent,
                        UseMnemonic = false,
                        TextAlign   = ContentAlignment.TopLeft,
                    };
                }
                else
                {
                    int innerW = contentW - 18; // chừa chỗ thanh cuộn
                    int innerH = DialogAutosizeHelper.MeasureWrappedHeight(message, msgFont, innerW);
                    var lblMsg = new Label
                    {
                        AutoSize    = false,
                        Size        = new Size(innerW, innerH),
                        Location    = new Point(0, 0),
                        Text        = message,
                        Font        = msgFont,
                        ForeColor   = TextPri,
                        BackColor   = Color.Transparent,
                        UseMnemonic = false,
                        TextAlign   = ContentAlignment.TopLeft,
                    };
                    var pnl = new Panel
                    {
                        Size      = new Size(contentW, maxMsgH),
                        Location  = new Point(leftContent, msgY),
                        AutoScroll = true,
                        BackColor = Color.Transparent,
                    };
                    pnl.Controls.Add(lblMsg);
                    msgArea = pnl;
                }
                Controls.Add(msgArea);

                // Nút.
                int btnY = msgArea.Bottom + 22;
                int btnW = 112, btnH = 42;

                if (type == MessageBoxType.Warning)
                {
                    var btnYes = MakePrimary("Có");
                    var btnNo  = MakeGhost("Không");
                    btnYes.Size = new Size(btnW, btnH);
                    btnNo.Size  = new Size(btnW, btnH);
                    btnYes.Location = new Point(formW - Pad - btnW, btnY);
                    btnNo.Location  = new Point(btnYes.Left - 12 - btnW, btnY);
                    btnYes.Click += (s, e) => CloseWith(DialogResult.Yes);
                    btnNo.Click  += (s, e) => CloseWith(DialogResult.No);
                    Controls.Add(btnYes);
                    Controls.Add(btnNo);
                    AcceptButton = btnYes;
                    CancelButton = btnNo;
                }
                else
                {
                    var btnOk = MakePrimary("OK");
                    btnOk.Size = new Size(btnW, btnH);
                    btnOk.Location = new Point(formW - Pad - btnW, btnY);
                    btnOk.Click += (s, e) => CloseWith(DialogResult.OK);
                    Controls.Add(btnOk);
                    AcceptButton = btnOk;
                    CancelButton = btnOk;
                }

                ClientSize = new Size(formW, btnY + btnH + Pad);
                FormCorners.Round(this, 16);
            }

            private void CloseWith(DialogResult result)
            {
                DialogResult = result;
                Close();
            }

            private static Guna2Button MakePrimary(string text) => new()
            {
                Text         = text,
                BorderRadius = 10,
                FillColor    = Teal,
                ForeColor    = Color.White,
                Font         = new Font("Segoe UI", 10F, FontStyle.Bold),
                Cursor       = Cursors.Hand,
                HoverState   = { FillColor = TealHover },
            };

            private static Guna2Button MakeGhost(string text) => new()
            {
                Text            = text,
                BorderRadius    = 10,
                BorderThickness = 1,
                BorderColor     = Border,
                FillColor       = Color.Transparent,
                ForeColor       = TextPri,
                Font            = new Font("Segoe UI", 10F, FontStyle.Bold),
                Cursor          = Cursors.Hand,
                HoverState      = { FillColor = SurfaceHov, BorderColor = Color.FromArgb(103, 103, 110) },
            };

            private static Color Blend(Color fg, Color bg, double a) => Color.FromArgb(
                (int)(fg.R * a + bg.R * (1 - a)),
                (int)(fg.G * a + bg.G * (1 - a)),
                (int)(fg.B * a + bg.B * (1 - a)));
        }
    }
}
