using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;

namespace GUI
{
    public partial class ConfirmEmail : Form
    {
        public ConfirmEmail()
        {
            InitializeComponent();
        }

        private void LblBackToLogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form? loginForm = Application.OpenForms["Login"];
            if (loginForm != null)
            {
                loginForm.Show();
            }
            else
            {
                 Login login = new();
                 login.Show();
            }
            this.Close();
        }

        private async void BtnSendCode_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();

            btnSendCode.Enabled = false;
            btnSendCode.Text = "Đang gửi...";

            // Gọi BUS gửi mail
            var result = await EmailBUS.ProcessPasswordResetAsync(email);

            if (result.IsSuccess)
            {
                MsgBox.Show(result.Message, "Thành công", MsgBox.MessageBoxType.Info);
                // QUAN TRỌNG: Mở Form 2 và truyền Mã code + Email sang đó
                VerifyCode verifyForm = new (result.Code ?? "", email);
                verifyForm.Show();
                this.Hide(); // Ẩn Form 1 đi
            }
            else
            {
                MsgBox.Show(result.Message, "Lỗi", MsgBox.MessageBoxType.Error);
                btnSendCode.Enabled = true;
                btnSendCode.Text = "Gửi Code";
            }
        }
    }
}
