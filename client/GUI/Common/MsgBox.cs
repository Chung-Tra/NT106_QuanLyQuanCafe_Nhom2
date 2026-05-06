using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    internal partial class MsgBox : Form
    {

        // --- CÁC HÀM DLL ĐỂ LÀM GIAO DIỆN XỊN ---
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(int nLeftRect, int nTopRect, int nRightRect, int nBottomRect, int nWidthEllipse, int nHeightEllipse);
        [DllImport("user32.dll")]
        private static extern bool ReleaseCapture();
        [DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        public MsgBox()
        {
            InitializeComponent();
            // Bo góc Form 15 pixel cho nó "mượt"
            this.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 15, 15));
        }

        // --- HÀM TĨNH (STATIC) ĐỂ GỌI NHANH ---
        public static DialogResult Show(string message, string title = "Thông báo", MessageBoxType type = MessageBoxType.Info)
        {
            using (MsgBox msg = new MsgBox())
            {
                msg.lblTitle.Text = title;
                msg.lblMessage.Text = message;
                msg.ApplyTypeStyle(type);

                if (type == MessageBoxType.Warning)
                {
                    // Chế độ 2 nút: Xác nhận xóa
                    msg.btnOk.Text = "CÓ";
                    msg.btnOk.DialogResult = DialogResult.Yes;

                    msg.btnCancel.Visible = true;
                    msg.btnCancel.Text = "KHÔNG";
                    msg.btnCancel.DialogResult = DialogResult.No;

                    // Đặt vị trí 2 nút cân đối
                    msg.btnOk.Location = new Point(70, 110);
                    msg.btnCancel.Location = new Point(210, 110);
                }
                else
                {
                    // Chế độ 1 nút: Thông báo thường
                    msg.btnOk.Text = "ĐỒNG Ý";
                    msg.btnOk.DialogResult = DialogResult.OK;
                    msg.btnCancel.Visible = false;

                    // CĂN GIỮA NÚT OK: (Chiều rộng Panel - Chiều rộng Nút) / 2
                    int centerX = (msg.pnlBody.Width - msg.btnOk.Width) / 2;
                    msg.btnOk.Location = new Point(centerX, 110);
                }

                return msg.ShowDialog();
            }
        }

        // Đổi màu Header và Button theo loại thông báo
        private void ApplyTypeStyle(MessageBoxType type)
        {
            Color themeColor;
            switch (type)
            {
                case MessageBoxType.Success:
                    themeColor = Color.FromArgb(40, 167, 69); // Xanh lá
                    break;
                case MessageBoxType.Error:
                    themeColor = Color.FromArgb(220, 53, 69); // Đỏ
                    break;
                case MessageBoxType.Warning:
                    themeColor = Color.FromArgb(255, 193, 7); // Vàng
                    btnOk.ForeColor = Color.Black;
                    break;
                default:
                    themeColor = Color.FromArgb(0, 123, 255); // Xanh dương (Info)
                    break;
            }
            pnlHeader.BackColor = themeColor;
            btnOk.BackColor = themeColor;
        }

        public enum MessageBoxType { Info, Success, Error, Warning }

        // Sự kiện di chuyển Form khi nhấn giữ Header
        private void PnlHeader_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            _ = SendMessage(this.Handle, 0xA1, 0x2, 0);
        }

        // Sự kiện nút OK
        private void BtnOk_Click(object sender, EventArgs e)
        {
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
        }
    }
}
