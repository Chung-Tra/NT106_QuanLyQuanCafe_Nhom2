using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Runtime.CompilerServices.RuntimeHelpers;
using static System.Runtime.InteropServices.JavaScript.JSType;
using BUS;

namespace GUI
{
    public partial class ResetPassword : Form
    {
        private readonly string userEmail;
        public ResetPassword(string email)
        {
            InitializeComponent();
            this.userEmail = email;
        }

        private void TxtConfirmPass_Enter(object sender, EventArgs e)
        {
            txtConfirmPass.UseSystemPasswordChar = true;
        }

        private void BtnShowConfirmPass_MouseDown(object sender, MouseEventArgs e)
        {
            txtConfirmPass.UseSystemPasswordChar = false;
        }

        private void BtnShowConfirmPass_MouseUp(object sender, MouseEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtConfirmPass.Text))
            {
                txtConfirmPass.UseSystemPasswordChar = true;
            }
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
                MsgBox.Show("Cập nhật mật khẩu thành công!", "Thành công", MsgBox.MessageBoxType.Success);
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
                MsgBox.Show("Lỗi: " + result.Message, "Thất bại", MsgBox.MessageBoxType.Error);
            }

            btnSave.Text = "Lưu";
            btnSave.Enabled = true;

        }

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