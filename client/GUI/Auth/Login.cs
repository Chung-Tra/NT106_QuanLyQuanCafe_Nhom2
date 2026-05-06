using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Drawing.Drawing2D;
using System.Text.RegularExpressions;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System;
using DTO;
using BUS;


namespace GUI
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();

            //Khi nhập pass chuyển thành dấu chấm
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (!string.IsNullOrEmpty(Properties.Settings.Default.SavedEmail))
            {
                txtEmail.Text = Properties.Settings.Default.SavedEmail;
                txtPassword.Text = Properties.Settings.Default.SavedPassword;
                chkRememberMe.Checked = true;
            }
            txtPassword.UseSystemPasswordChar = true;
        }

        //Hàm tạo sự kiện cho UI
        private void PictureBox1_Paint(object sender, PaintEventArgs e)
        {
            int fadeWidth = 60;
            Rectangle fadeArea = new(pictureBox1.Width - fadeWidth, 0, fadeWidth, pictureBox1.Height);
            Color pnlRightColor = Color.FromArgb(30, 30, 30);
            using LinearGradientBrush brush = new(
                fadeArea,
                Color.Transparent,
                pnlRightColor,
                LinearGradientMode.Horizontal);

            e.Graphics.FillRectangle(brush, fadeArea);
        }
        private void TxtPassword_Enter(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = true;
        }
        private void BtnShowPass_MouseDown(object sender, MouseEventArgs e)
        {
            txtPassword.UseSystemPasswordChar = false;
        }

        private void BtnShowPass_MouseUp(object sender, MouseEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                txtPassword.UseSystemPasswordChar = true;
            }
        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void LblSignUp_Click(object sender, EventArgs e)
        {

        }

        private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ConfirmEmail frmConfirm = new();
            this.Hide();
            frmConfirm.ShowDialog();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private async void BtnSignIn_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text;
            string password = txtPassword.Text;

            //Khóa nút bấm trong lúc chờ mạng
            btnSignIn.Enabled = false;
            btnSignIn.Text = "Đang xử lý...";

            //Gọi BUS thực hiện đăng nhập
            // Vì BUS trả về 1 Tuple (IsSuccess, Message, UserData), ta dùng 'var result' để hứng
            var result = await AuthBUS.LoginBUS(email, password);

            // 4. Xử lý kết quả và Phân quyền
            if (result.IsSuccess == true)
            {

                // Đăng nhập và qua các ải kiểm tra nghiệp vụ thành công
                GlobalSession.CurrentUser = result.UserData!; // Lưu vào biến hệ thống
                // BẮT ĐẦU THÊM ĐOẠN NÀ NÀY ĐỂ LƯU MẬT KHẨU
                if (chkRememberMe.Checked)
                {
                    Properties.Settings.Default.SavedEmail = txtEmail.Text;
                    Properties.Settings.Default.SavedPassword = txtPassword.Text;
                }
                else
                {
                    Properties.Settings.Default.SavedEmail = "";
                    Properties.Settings.Default.SavedPassword = "";
                }
                Properties.Settings.Default.Save();
                // KẾT THÚC THÊM ĐOẠN LƯU MẬT KHẨU
                // Điều hướng dựa vào Role - 1 MainDashboard duy nhất cho tất cả role
                string welcomePrefix = GlobalSession.CurrentUser.Role switch
                {
                    "admin"       => "Admin",
                    "manager"     => "Quản lý",
                    "order staff" => "Nhân viên Order",
                    "barista"     => "Pha chế",
                    "stockkeeper" => "Thủ kho",
                    "security"    => "Bảo vệ",
                    _             => "User"
                };

                MsgBox.Show(
                    $"Xin chào {welcomePrefix} {GlobalSession.CurrentUser.FullName}!\n{result.Message}",
                    "Đăng nhập thành công",
                    MsgBox.MessageBoxType.Success
                );

                MainDashboard dashboard = new();
                dashboard.Show();
                this.Hide();
            }
            else
            {
                // Nếu IsSuccess == false (Sai pass, tài khoản bị khóa, rỗng...)
                // Chỉ cần lấy đúng câu Message từ lớp BUS và in ra
                MsgBox.Show(result.Message, "Đăng nhập thất bại", MsgBox.MessageBoxType.Error);
            }

            // 5. Mở lại nút bấm
            btnSignIn.Enabled = true;
            btnSignIn.Text = "Đăng nhập";

        }
    }
}