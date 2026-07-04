using BUS;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GUI
{
#pragma warning disable IDE1006
    public partial class ucProfile : UserControl
#pragma warning restore IDE1006
    {
        public ucProfile()
        {
            InitializeComponent();
        }

        private void UcProfile_Load(object? sender, EventArgs e) => LoadProfileData();

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
                txtPhone.Text = user.PhoneNumber ?? "";
                txtAddress.Text = "";
                lblJoinValue.Text = string.IsNullOrWhiteSpace(user.HireDate) ? "—" : user.HireDate;
                lblShiftValue.Text = "—";
                if (!string.IsNullOrWhiteSpace(user.AvatarUrl))
                    ImageLoader.SetImageAsync(picAvatar, user.AvatarUrl);
                _ = LoadShiftAsync(user.EmployeeId);
            }
            else
            {
                lblUserName.Text = "—";
                lblUserRole.Text = "—";
                txtEmployeeId.Text = "";
                txtFullName.Text = "";
                txtEmail.Text = "";
                txtPhone.Text = "";
                txtAddress.Text = "";
                lblJoinValue.Text = "—";
                lblShiftValue.Text = "—";
            }
        }

        private async Task LoadShiftAsync(string? employeeId)
        {
            if (string.IsNullOrEmpty(employeeId)) return;
            try
            {
                string weekKey = GetMonday(DateTime.Today).ToString("dd/MM/yyyy");
                var sched = (await ScheduleBUS.GetAll()).Values
                    .FirstOrDefault(s => s.EmployeeId == employeeId && s.Tuan == weekKey);
                if (sched == null) return;

                var parts = new List<string>();
                string[] days = { "T2", "T3", "T4", "T5", "T6", "T7", "CN" };
                string[] codes = { sched.T2, sched.T3, sched.T4, sched.T5, sched.T6, sched.T7, sched.CN };
                for (int i = 0; i < days.Length; i++)
                {
                    string c = codes[i]?.Trim().ToUpperInvariant() ?? "";
                    if (c == "S") parts.Add($"{days[i]} sáng");
                    else if (c == "C") parts.Add($"{days[i]} chiều");
                    else if (c == "N") parts.Add($"{days[i]} đêm");
                }
                if (parts.Count > 0 && !IsDisposed)
                    lblShiftValue.Text = string.Join(", ", parts.Take(3)) + (parts.Count > 3 ? "…" : "");
            }
            catch { /* offline */ }
        }

        private static DateTime GetMonday(DateTime d)
        {
            int dow = (int)d.DayOfWeek;
            int back = dow == 0 ? 6 : dow - 1;
            return d.AddDays(-back).Date;
        }

        private static string RoleDisplay(string? role) => (role ?? "").ToLower() switch
        {
            "admin" => "Quản trị viên / Admin",
            "manager" => "Quản lý / Manager",
            _ => "Barista / Staff"
        };

        private async void BtnUpdateInfo_Click(object? sender, EventArgs e)
        {
            var user = GlobalSession.CurrentUser;
            if (user?.EmployeeId == null)
            {
                MsgBox.Show(MsgBox.OwnerWindow(this), "Không xác định được tài khoản đang đăng nhập.", "Lỗi", MsgBox.MessageBoxType.Error);
                return;
            }

            var owner = MsgBox.OwnerWindow(this);
            btnUpdateInfo.Enabled = false;
            try
            {
                var data = new EmployeeDTO
                {
                    FullName = txtFullName.Text.Trim(),
                    PhoneNumber = txtPhone.Text.Trim(),
                    Role = user.Role,
                    Status = user.Status
                };
                var (ok, msg) = await EmployeeBUS.UpdateEmployeeAsync(user.EmployeeId, data);
                if (ok)
                {
                    user.FullName = data.FullName;
                    user.PhoneNumber = data.PhoneNumber;
                    lblUserName.Text = (user.FullName ?? "Nhân viên").ToUpper();
                    MsgBox.Show(owner, "Đã cập nhật thông tin cá nhân!", "Thành công", MsgBox.MessageBoxType.Success);
                }
                else
                {
                    MsgBox.Show(owner, msg, "Không thể cập nhật", MsgBox.MessageBoxType.Warning);
                }
            }
            catch (Exception ex)
            {
                MsgBox.Show(owner, ex.Message, "Lỗi", MsgBox.MessageBoxType.Error);
            }
            finally { btnUpdateInfo.Enabled = true; }
        }

        private async void BtnChangePass_Click(object? sender, EventArgs e)
        {
            var owner = MsgBox.OwnerWindow(this);
            string email = GlobalSession.CurrentUser?.Email ?? "";

            btnChangePass.Enabled = false;
            try
            {
                var (ok, msg) = await AuthBUS.ChangePasswordBUS(email, txtOldPass.Text, txtNewPass.Text, txtConfirmPass.Text);
                MsgBox.Show(owner, msg, ok ? "Thành công" : "Thông báo",
                    ok ? MsgBox.MessageBoxType.Success : MsgBox.MessageBoxType.Warning);
                if (ok)
                {
                    txtOldPass.Clear();
                    txtNewPass.Clear();
                    txtConfirmPass.Clear();
                }
            }
            catch (Exception ex)
            {
                MsgBox.Show(owner, ex.Message, "Lỗi", MsgBox.MessageBoxType.Error);
            }
            finally { btnChangePass.Enabled = true; }
        }

        private async void BtnChangeAvatar_Click(object? sender, EventArgs e)
        {
            var owner = MsgBox.OwnerWindow(this);
            using OpenFileDialog ofd = new()
            {
                Title = "Chọn ảnh đại diện",
                Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif"
            };
            if (ofd.ShowDialog(owner) != DialogResult.OK) return;

            var user = GlobalSession.CurrentUser;
            btnChangeAvatar.Enabled = false;
            try
            {
                // Xem trước ngay
                try { picAvatar.Image?.Dispose(); picAvatar.Image = Image.FromFile(ofd.FileName); } catch { }

                // Tải lên Firebase Storage
                var (ok, msg, url) = await UploadBUS.UploadImage(ofd.FileName, "avatar");
                if (!ok || string.IsNullOrEmpty(url))
                {
                    MsgBox.Show(owner, msg, "Lỗi tải ảnh", MsgBox.MessageBoxType.Error);
                    return;
                }

                // Lưu URL vào hồ sơ nhân viên
                if (user?.EmployeeId != null)
                {
                    var (uok, umsg) = await EmployeeBUS.UpdateAvatarAsync(user.EmployeeId, url);
                    if (uok) user.AvatarUrl = url;
                    else { MsgBox.Show(owner, umsg, "Lỗi lưu ảnh", MsgBox.MessageBoxType.Warning); return; }
                }

                MsgBox.Show(owner, "Đã cập nhật ảnh đại diện!", "Thành công", MsgBox.MessageBoxType.Success);
            }
            catch (Exception ex)
            {
                MsgBox.Show(owner, "Không thể cập nhật ảnh: " + ex.Message, "Lỗi", MsgBox.MessageBoxType.Error);
            }
            finally { btnChangeAvatar.Enabled = true; }
        }
    }
}
