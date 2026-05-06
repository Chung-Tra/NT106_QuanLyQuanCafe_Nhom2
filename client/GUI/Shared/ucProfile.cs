using System;
using System.Drawing;
using System.Windows.Forms;
using DTO;

namespace GUI
{
    public partial class ucProfile : UserControl
    {
        public ucProfile()
        {
            InitializeComponent();
            this.Load += (s, e) => LoadProfileData();
            btnUpdateInfo.Click += btnUpdateInfo_Click;
            btnChangePass.Click += btnChangePass_Click;
            btnChangeAvatar.Click += btnChangeAvatar_Click;
        }

        private void LoadProfileData()
        {
            var user = GlobalSession.CurrentUser;
            if (user != null)
            {
                lblUserName.Text = user.FullName ?? "Nhân viên";
                lblUserRole.Text = user.Role ?? "Staff";
                txtEmployeeId.Text = user.EmployeeId ?? "";
                txtEmail.Text = user.Email ?? "";
                txtPhone.Text = "";
                txtAddress.Text = "";
            }
            else
            {
                lblUserName.Text = "Nguyễn Văn An";
                lblUserRole.Text = "Pha chế";
                txtEmployeeId.Text = "NV002";
                txtEmail.Text = "an.nguyen@cafe.com";
                txtPhone.Text = "0901234567";
                txtAddress.Text = "123 Nguyễn Huệ, Q.1, TP.HCM";
            }
        }

        private void btnUpdateInfo_Click(object? sender, EventArgs e)
        {
            MsgBox.Show("Đã cập nhật thông tin cá nhân!", "Thành công", MsgBox.MessageBoxType.Success);
        }

        private void btnChangePass_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtOldPass.Text) || string.IsNullOrWhiteSpace(txtNewPass.Text))
            {
                MsgBox.Show("Vui lòng nhập đầy đủ mật khẩu cũ và mới!", "Thông báo", MsgBox.MessageBoxType.Warning);
                return;
            }
            if (txtNewPass.Text.Length < 6)
            {
                MsgBox.Show("Mật khẩu mới phải có ít nhất 6 ký tự!", "Thông báo", MsgBox.MessageBoxType.Warning);
                return;
            }
            MsgBox.Show("Đã đổi mật khẩu thành công!", "Thành công", MsgBox.MessageBoxType.Success);
            txtOldPass.Clear();
            txtNewPass.Clear();
        }

        private void btnChangeAvatar_Click(object? sender, EventArgs e)
        {
            using OpenFileDialog ofd = new();
            ofd.Title = "Chọn ảnh đại diện";
            ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    picAvatar.Image?.Dispose();
                    picAvatar.Image = Image.FromFile(ofd.FileName);
                    MsgBox.Show("Đã cập nhật ảnh đại diện!", "Thành công", MsgBox.MessageBoxType.Success);
                }
                catch
                {
                    MsgBox.Show("Không thể đọc file ảnh!", "Lỗi", MsgBox.MessageBoxType.Error);
                }
            }
        }

        private void grpSecurity_Enter(object sender, EventArgs e)
        {
        }
    }
}
