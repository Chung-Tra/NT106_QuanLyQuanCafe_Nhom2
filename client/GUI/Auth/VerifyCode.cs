using BUS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class VerifyCode : Form
    {
        private readonly DateTime _expiryTime; // Biến lưu thời điểm mã sẽ hết hạn
        private int timeLeft = 60;
        // 2 Biến toàn cục để hứng dữ liệu từ Form 1 truyền sang
        private string _systemCode;
        private readonly string _userEmail;

        // Sửa lại hàm khởi tạo để nhận dữ liệu
        public VerifyCode(string systemCode, string userEmail)
        {
            InitializeComponent();

            // Cất dữ liệu nhận được vào biến toàn cục để dùng cho nút Xác nhận
            _systemCode = systemCode;
            _userEmail = userEmail;
            _expiryTime = DateTime.Now.AddSeconds(60);
        }

        private void lblBackToLogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form ConfirmForm = new ConfirmEmail();
            ConfirmForm.Show();
            this.Close();
        }

        private void btnVerify_Click(object sender, EventArgs e)
        {
            string userCode = txtCode.Text;

            if (!Validation.IsAnyEmpty(userCode))
            {
                if (!Validation.IsValidVerificationCode(userCode))
                {
                    MsgBox.Show("Mã xác nhận không hợp lệ!\nMã phải có đúng 8 ký tự, bao gồm cả chữ và số.", "Sai định dạng", MsgBox.MessageBoxType.Warning);
                    return;
                }
            }
            else
            {
                MsgBox.Show("Vui lòng nhập mã xác nhận!", "Cảnh báo", MsgBox.MessageBoxType.Warning);
                return;
            }

            // KIỂM TRA THỜI GIAN HẾT HẠN
            if (DateTime.Now > _expiryTime)
            {
                MsgBox.Show("Mã xác nhận đã hết hạn (60s).\nVui lòng nhấn 'Gửi lại mã' để nhận mã mới.",
                                "Mã hết hạn", MsgBox.MessageBoxType.Warning);

                // Có thể xóa mã hệ thống để đảm bảo người dùng không thể dùng lại mã cũ
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
                MsgBox.Show("Mã xác nhận không đúng.\nVui lòng thử lại!", "Lỗi", MsgBox.MessageBoxType.Error);
            }
        }

        private async void lblResend_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // 1. Vô hiệu hóa nút để tránh người dùng bấm nhiều lần
            lblResend.Enabled = false;
            lblResend.Text = "Đang gửi...";

            try
            {
                // 2. Gọi lại hàm gửi mã từ BUS (sử dụng email đã nhận từ Form trước)
                // result.Code sẽ là mã mới được sinh ra
                var result = await EmailBUS.ProcessPasswordResetAsync(_userEmail);

                if (result.IsSuccess)
                {
                    // 3. QUAN TRỌNG: Cập nhật lại mã hệ thống mới vào biến cục bộ
                    _systemCode = result.Code ?? string.Empty;

                    MsgBox.Show("Một mã mới đã được gửi đến email của bạn.", "Thành công",
                                    MsgBox.MessageBoxType.Success);

                    // 4. Bắt đầu đếm ngược (Optional - xem hướng dẫn ở mục 2)
                    lblResend.Enabled = false;
                    resendTimer.Start();
                }
                else
                {
                    MsgBox.Show(result.Message, "Lỗi", MsgBox.MessageBoxType.Error);
                    lblResend.Enabled = true;
                    lblResend.Text = "Gửi lại mã";
                }
            }
            catch (Exception ex)
            {
                MsgBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi",
                                MsgBox.MessageBoxType.Error);
                lblResend.Enabled = true;
                lblResend.Text = "Gửi lại mã";
            }
        }

        private void VerifyCode_Load(object sender, EventArgs e)
        {

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