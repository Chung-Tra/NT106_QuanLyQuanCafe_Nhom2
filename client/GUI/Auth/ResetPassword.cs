using System;
using System.Windows.Forms;
using BUS;

namespace GUI
{
    public partial class ResetPassword : Form
    {
        private readonly string userEmail;
        public ResetPassword(string email)
        {
            InitializeComponent();
            FormCorners.Round(this);
            AppFonts.ApplyTo(lblTitle, lblDescription);
            this.userEmail = email;
            btnShowNewPass.BringToFront();
            btnShowConfirmPass.BringToFront();
        }

        // ──────────────────────────────────────────────
        // Hiện/ẩn mật khẩu mới
        // ──────────────────────────────────────────────
        private void BtnShowNewPass_MouseDown(object sender, MouseEventArgs e)
        {
            txtNewPass.PasswordChar          = '\0';
            txtNewPass.UseSystemPasswordChar = false;
            btnShowNewPass.Text              = "Ẩn";
        }

        private void BtnShowNewPass_MouseUp(object sender, MouseEventArgs e)
        {
            txtNewPass.PasswordChar          = '●';
            txtNewPass.UseSystemPasswordChar = true;
            btnShowNewPass.Text              = "Hiện";
        }

        // ──────────────────────────────────────────────
        // Hiện/ẩn xác nhận mật khẩu
        // ──────────────────────────────────────────────
        private void BtnShowConfirmPass_MouseDown(object sender, MouseEventArgs e)
        {
            txtConfirmPass.PasswordChar          = '\0';
            txtConfirmPass.UseSystemPasswordChar = false;
            btnShowConfirmPass.Text              = "Ẩn";
        }

        private void BtnShowConfirmPass_MouseUp(object sender, MouseEventArgs e)
        {
            txtConfirmPass.PasswordChar          = '●';
            txtConfirmPass.UseSystemPasswordChar = true;
            btnShowConfirmPass.Text              = "Hiện";
        }

        private async void BtnSave_Click(object sender, EventArgs e)
        {
            string newPass = txtNewPass.Text.Trim();
            string confirmPass = txtConfirmPass.Text.Trim();

            btnSave.Text = "Đang lưu...";
            btnSave.Enabled = false;

            // Gọi hàm xử lý (truyền email, pass mới, và xác nhận pass)
            var result = await AuthBUS.HandlePasswordReset(userEmail, newPass, confirmPass);

            if (result.IsValid)
            {
                MsgBox.Show(this, "Cập nhật mật khẩu thành công!", "Thành công", MsgBox.MessageBoxType.Success);
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
            else
            {
                MsgBox.Show(this, "Lỗi: " + result.Message, "Thất bại", MsgBox.MessageBoxType.Error);
            }

            btnSave.Text = "Lưu mật khẩu mới";
            btnSave.Enabled = true;

        }

        // ──────────────────────────────────────────────
        // Quay lại form VerifyCode
        // ──────────────────────────────────────────────
        private void LblBackToLogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form? VerifyForm = Application.OpenForms["VerifyCode"];
            if (VerifyForm != null)
            {
                VerifyForm.Show();
            }
            else
            {
                VerifyCode veri = new(string.Empty, string.Empty);
                veri.Show();
            }
            this.Close();
        }

        private void TxtNewPass_TextChanged(object sender, EventArgs e)
        {

        }
    }
}