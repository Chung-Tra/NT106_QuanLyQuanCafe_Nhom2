using System;
using System.Windows.Forms;
using BUS;

namespace GUI
{
    public partial class ConfirmEmail : Form
    {
        public ConfirmEmail()
        {
            InitializeComponent();
            FormCorners.Round(this);
            WindowChrome.Apply(this, close: false, host: pnlCard);
        }

        // Label "Quay lại đăng nhập" click event handler
        private void LblBackToLogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form? loginForm = Application.OpenForms["Login"];
            if (loginForm != null)
                loginForm.Show();
            else
                new Login().Show();

            this.Close();
        }

        // Nút "Gửi mã xác nhận" click event handler
        private async void BtnSendCode_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();

            btnSendCode.Enabled = false;
            btnSendCode.Text    = "Đang gửi...";

            var result = await EmailBUS.ProcessPasswordResetAsync(email);

            if (result.IsSuccess)
            {
                MsgBox.Show(this, "\n" + result.Message, "Thành công", MsgBox.MessageBoxType.Info);
                new VerifyCode(email).Show();
                this.Close();
            }
            else
            {
                MsgBox.Show(this, "\n" + result.Message, "Lỗi", MsgBox.MessageBoxType.Error);
                btnSendCode.Enabled = true;
                btnSendCode.Text    = "Gửi mã xác nhận";
            }
        }
    }
}
