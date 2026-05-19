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
                lblUserName.Text = (user.FullName ?? "Nhân viên").ToUpper();
                lblUserRole.Text = RoleDisplay(user.Role);
                txtEmployeeId.Text = user.EmployeeId ?? "";
                txtFullName.Text = user.FullName ?? "";
                txtEmail.Text = user.Email ?? "";
                txtPhone.Text = "";
                txtAddress.Text = "";
            }
            else
            {
                lblUserName.Text = "NGUYỄN VĂN AN";
                lblUserRole.Text = "Barista / Staff";
                txtEmployeeId.Text = "NV002";
                txtFullName.Text = "Nguyễn Văn An";
                txtEmail.Text = "an.nguyen@cafe.com";
                txtPhone.Text = "0901234567";
                txtAddress.Text = "123 Nguyễn Huệ, Q.1, TP.HCM";
            }
        }

        private static string RoleDisplay(string? role) => (role ?? "").ToLower() switch
        {
            "admin" => "Quản trị viên / Admin",
            "manager" => "Quản lý / Manager",
            _ => "Barista / Staff"
        };

        private void btnUpdateInfo_Click(object? sender, EventArgs e)
        {
            MsgBox.Show(MsgBox.OwnerWindow(this), "Đã cập nhật thông tin cá nhân!", "Thành công", MsgBox.MessageBoxType.Success);
        }

        private void btnChangePass_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtOldPass.Text) ||
                string.IsNullOrWhiteSpace(txtNewPass.Text) ||
                string.IsNullOrWhiteSpace(txtConfirmPass.Text))
            {
                MsgBox.Show(MsgBox.OwnerWindow(this), "Vui lòng nhập đầy đủ các trường mật khẩu!", "Thông báo", MsgBox.MessageBoxType.Warning);
                return;
            }
            if (txtNewPass.Text.Length < 6)
            {
                MsgBox.Show(MsgBox.OwnerWindow(this), "Mật khẩu mới phải có ít nhất 6 ký tự!", "Thông báo", MsgBox.MessageBoxType.Warning);
                return;
            }
            if (txtNewPass.Text != txtConfirmPass.Text)
            {
                MsgBox.Show(MsgBox.OwnerWindow(this), "Mật khẩu xác nhận không khớp!", "Thông báo", MsgBox.MessageBoxType.Warning);
                return;
            }
            MsgBox.Show(MsgBox.OwnerWindow(this), "Đã đổi mật khẩu thành công!", "Thành công", MsgBox.MessageBoxType.Success);
            txtOldPass.Clear();
            txtNewPass.Clear();
            txtConfirmPass.Clear();
        }

        private void btnChangeAvatar_Click(object? sender, EventArgs e)
        {
            using OpenFileDialog ofd = new();
            ofd.Title = "Chọn ảnh đại diện";
            ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
            if (ofd.ShowDialog(MsgBox.OwnerWindow(this)) == DialogResult.OK)
            {
                try
                {
                    picAvatar.Image?.Dispose();
                    picAvatar.Image = Image.FromFile(ofd.FileName);
                    MsgBox.Show(MsgBox.OwnerWindow(this), "Đã cập nhật ảnh đại diện!", "Thành công", MsgBox.MessageBoxType.Success);
                }
                catch
                {
                    MsgBox.Show(MsgBox.OwnerWindow(this), "Không thể đọc file ảnh!", "Lỗi", MsgBox.MessageBoxType.Error);
                }
            }
        }

    }
}
