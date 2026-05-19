using BUS;
using System;
using System.Windows.Forms;

namespace GUI
{
    public partial class VerifyCode : Form
    {
        // ──────────────────────────────────────────────
        // Biên đếm thời gian cho phép gửi lại mã (60s)
        // ──────────────────────────────────────────────
        private DateTime _expiryTime; // Biến lưu thời điểm mã sẽ hết hạn
        private int timeLeft = 60;

        // ──────────────────────────────────────────────
        // Biến lấy giá trị từ form ConfirmEmail
        // ──────────────────────────────────────────────
        private string _systemCode;
        private readonly string _userEmail;

        public VerifyCode(string systemCode, string userEmail)
        {
            InitializeComponent();
            FormCorners.Round(this);
            AppFonts.ApplyTo(lblTitle, lblDescription);

            _systemCode = systemCode;
            _userEmail = userEmail;
            _expiryTime = DateTime.Now.AddSeconds(60);
        }

        // ──────────────────────────────────────────────
        // Quay lại form ConfirmEmail
        // ──────────────────────────────────────────────
        private void lblBackToLogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form ConfirmForm = new ConfirmEmail();
            ConfirmForm.Show();
            this.Close();
        }

        // ──────────────────────────────────────────────
        // Kiểm tra mã xác nhận
        // ──────────────────────────────────────────────
        private void btnVerify_Click(object sender, EventArgs e)
        {
            string userCode = txtCode.Text;

            if (!Validation.IsAnyEmpty(userCode))
            {
                if (!Validation.IsValidVerificationCode(userCode))
                {
                    MsgBox.Show(
                        this,
                        "Mã xác nhận không hợp lệ!\nMã phải có đúng 8 ký tự, bao gồm cả chữ và số.",
                        "Sai định dạng", MsgBox.MessageBoxType.Warning);
                    return;
                }
            }
            else
            {
                MsgBox.Show(this, "Vui lòng nhập mã xác nhận!", "Cảnh báo", MsgBox.MessageBoxType.Warning);
                return;
            }

            // Kiểm tra thời gian hết hạn
            if (DateTime.Now > _expiryTime)
            {
                MsgBox.Show(
                    this,
                    "Mã xác nhận đã hết hạn (60s).\nVui lòng nhấn 'Gửi lại mã' để nhận mã mới.",
                    "Mã hết hạn", MsgBox.MessageBoxType.Warning);

                //Reset về mã trống để tránh nhầm lẫn nếu người dùng cố gắng nhập mã cũ
                _systemCode = "";
                return;
            }

            if (userCode == _systemCode)
            {
                ResetPassword reset = new(_userEmail);
                reset.Show();
                this.Close();
            }
            else
            {
                MsgBox.Show(
                    this,
                    "Mã xác nhận không đúng.\nVui lòng thử lại!",
                    "Lỗi",
                    MsgBox.MessageBoxType.Error);
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
                    // Cập nhật mã mới + reset thời hạn
                    _systemCode  = result.Code ?? string.Empty;
                    _expiryTime  = DateTime.Now.AddSeconds(60);

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