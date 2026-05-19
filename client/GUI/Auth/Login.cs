using System;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using DTO;
using BUS;

namespace GUI
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            FormCorners.Round(this);
            AppFonts.ApplyTo(lblWelcome, lblSubtitle);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            string savedEmail = Properties.Settings.Default.SavedEmail;
            string savedPass  = Properties.Settings.Default.SavedPassword;

            if (!Validation.IsAnyEmpty(savedEmail, savedPass))
            {
                string decrypted = Decrypt(savedPass);
                if (!string.IsNullOrEmpty(decrypted))
                {
                    txtEmail.Text         = savedEmail;
                    txtPassword.Text      = decrypted;
                    chkRememberMe.Checked = true;
                }
            }
            txtPassword.UseSystemPasswordChar = true;
            btnShowPass.BringToFront();
        }

        // ──────────────────────────────────────────────
        // DPAPI — mã hóa/giải mã mật khẩu
        // ──────────────────────────────────────────────
        private static string Encrypt(string plainText)
        {
            try
            {
                byte[] encrypted = ProtectedData.Protect(
                    Encoding.UTF8.GetBytes(plainText),
                    null,
                    DataProtectionScope.CurrentUser);
                return Convert.ToBase64String(encrypted);
            }
            catch { return ""; }
        }

        private static string Decrypt(string encryptedText)
        {
            try
            {
                byte[] decrypted = ProtectedData.Unprotect(
                    Convert.FromBase64String(encryptedText),
                    null,
                    DataProtectionScope.CurrentUser);
                return Encoding.UTF8.GetString(decrypted);
            }
            catch { return ""; }
        }

        // ──────────────────────────────────────────────
        // Sự kiện hiện/ẩn mật khẩu
        // ──────────────────────────────────────────────
        private void BtnShowPass_MouseDown(object sender, MouseEventArgs e)
        {
            txtPassword.PasswordChar          = '\0';
            txtPassword.UseSystemPasswordChar = false;
            btnShowPass.Text                  = "Ẩn";
        }

        private void BtnShowPass_MouseUp(object sender, MouseEventArgs e)
        {
            txtPassword.PasswordChar          = '●';
            txtPassword.UseSystemPasswordChar = true;
            btnShowPass.Text                  = "Hiện";
        }

        // ──────────────────────────────────────────────
        // Sự kiện click "Quên mật khẩu"
        // ──────────────────────────────────────────────
        private void LblForgotPass_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ConfirmEmail frmConfirm = new();
            this.Hide();
            frmConfirm.ShowDialog(this);
        }

        // ──────────────────────────────────────────────
        // Sự kiện click "Đăng nhập"
        // ──────────────────────────────────────────────
        private async void BtnSignIn_Click(object sender, EventArgs e)
        {
            string email    = txtEmail.Text;
            string password = txtPassword.Text;

            btnSignIn.Enabled = false;
            btnSignIn.Text    = "Đang xử lý...";

            var result = await AuthBUS.LoginBUS(email, password);

            if (result.IsSuccess == true)
            {
                GlobalSession.CurrentUser = result.UserData!;

                if (chkRememberMe.Checked)
                {
                    Properties.Settings.Default.SavedEmail    = txtEmail.Text;
                    Properties.Settings.Default.SavedPassword = Encrypt(txtPassword.Text);
                }
                else
                {
                    Properties.Settings.Default.SavedEmail    = "";
                    Properties.Settings.Default.SavedPassword = "";
                }
                Properties.Settings.Default.Save();

                string role = GlobalSession.CurrentUser.Role?.ToLowerInvariant() ?? "";

                string welcomePrefix = role switch
                {
                    "admin"       => "Quản trị viên",
                    "manager"     => "Quản lý",
                    "order staff" => "Nhân viên Order",
                    "barista"     => "Pha chế",
                    "security"    => "Bảo vệ",
                    _             => "Người dùng"
                };

                string greeting = $"Xin chào {welcomePrefix} {GlobalSession.CurrentUser.FullName}!";

                MsgBox.Show(this, "\n" + greeting, "Đăng nhập thành công", MsgBox.MessageBoxType.Success);

                new MainDashboard().Show();
                this.Hide();
                return;
            }

            MsgBox.Show(this, "\n" + result.Message, "Đăng nhập thất bại", MsgBox.MessageBoxType.Error);
            btnSignIn.Enabled = true;
            btnSignIn.Text    = "Đăng nhập";
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
