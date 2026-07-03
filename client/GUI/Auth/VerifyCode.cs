using BUS;
using System;
using System.Windows.Forms;

namespace GUI
{
    public partial class VerifyCode : Form
    {
        // Bộ đếm thời gian cho phép gửi lại mã (60s)
        private int timeLeft = 60;

        // Email nhận từ form ConfirmEmail (mã KHÔNG còn nằm ở client — server giữ và tự so sánh)
        private readonly string _userEmail;

        public VerifyCode(string userEmail)
        {
            InitializeComponent();
            FormCorners.Round(this);
            WindowChrome.Apply(this, close: false, host: pnlCard);

            _userEmail = userEmail;
        }

        // Quay lại form ConfirmEmail
        private void lblBackToLogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form ConfirmForm = new ConfirmEmail();
            ConfirmForm.Show();
            this.Close();
        }

        // Kiểm tra mã xác nhận — gửi mã lên SERVER để so sánh (server kiểm hạn dùng + số lần thử)
        private async void btnVerify_Click(object sender, EventArgs e)
        {
            string userCode = txtCode.Text;

            btnVerify.Enabled = false;
            var (success, resetToken, message) = await EmailBUS.VerifyOtpAsync(_userEmail, userCode);
            btnVerify.Enabled = true;

            if (success)
            {
                // Mang theo reset-token sang bước đặt mật khẩu
                ResetPassword reset = new(_userEmail, resetToken ?? string.Empty);
                reset.Show();
                this.Close();
            }
            else
            {
                MsgBox.Show(this, message, "Lỗi", MsgBox.MessageBoxType.Error);
            }
        }

        private async void lblResend_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            lblResend.Enabled = false;
            lblResend.Text = "Đang gửi...";

            try
            {

                var result = await EmailBUS.ProcessPasswordResetAsync(_userEmail);

                if (result.IsSuccess)
                {
                    // Server đã tạo + lưu mã mới; client chỉ khởi động lại bộ đếm
                    MsgBox.Show(this, "Một mã mới đã được gửi đến email của bạn.", "Thành công",
                                    MsgBox.MessageBoxType.Success);

                    // Reset và khởi động lại bộ đếm
                    timeLeft          = 60;
                    lblResend.Enabled = false;
                    resendTimer.Start();
                }
                else
                {
                    MsgBox.Show(this, result.Message, "Lỗi", MsgBox.MessageBoxType.Error);
                    lblResend.Enabled = true;
                    lblResend.Text = "Gửi lại mã";
                }
            }
            catch (Exception ex)
            {
                MsgBox.Show(this, "Đã xảy ra lỗi: " + ex.Message, "Lỗi",
                                MsgBox.MessageBoxType.Error);
                lblResend.Enabled = true;
                lblResend.Text = "Gửi lại mã";
            }
        }

        private void VerifyCode_Load(object sender, EventArgs e)
        {
            // Tự động đếm ngược ngay khi form mở (mã vừa được gửi)
            lblResend.Enabled = false;
            resendTimer.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (timeLeft > 0)
            {
                // Mỗi giây trôi qua, trừ đi 1
                timeLeft--;
                // Cập nhật chữ trên nút bấm để người dùng thấy
                lblResend.Text = $"Gửi lại sau ({timeLeft}s)";
            }
            else
            {
                // Khi hết thời gian (về 0)
                resendTimer.Stop(); // Dừng bộ đếm
                lblResend.Enabled = true; // Cho phép bấm lại
                lblResend.Text = "Gửi lại mã"; // Trả lại chữ ban đầu
                timeLeft = 60; // Reset lại biến thời gian cho lần sau
            }
        }
    }
}
