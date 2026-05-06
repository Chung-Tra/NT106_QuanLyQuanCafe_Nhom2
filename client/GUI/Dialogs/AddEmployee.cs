using BUS;
using DTO;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace GUI
{
    public partial class AddEmployee : Form
    {

        public AddEmployee()
        {
            InitializeComponent();
            LoadRoles();
        }

        public AddEmployee(EmployeeDTO emp)
        {
            InitializeComponent();
            btnCancel.CausesValidation = false;

            // Đã thêm: Nạp lại Dictionary cho ComboBox ở hàm cập nhật để không bị trống
            Dictionary<string, string> roleData = new()
            {
                { "manager", "Quản lý" },
                { "barista", "Pha chế" },
                { "order staff", "Nhân viên Order" },
                { "security", "Bảo vệ" }
            };
            cboRole.DataSource = new BindingSource(roleData, null);
            cboRole.DisplayMember = "Value";
            cboRole.ValueMember = "Key";

            // Đổi tiêu đề giao diện
            textBox1.Text = "Cập nhật Account";
            btnSave.Text = "Cập nhật";

            // Đổ dữ liệu cũ lên giao diện 
            txtEmail.Text = emp.Email;
            txtFullName.Text = emp.FullName;
            txtPhone.Text = emp.PhoneNumber;
            txtPassword.Text = emp.Password;

            // Đã sửa: Dùng SelectedValue thay vì SelectedItem
            if (!string.IsNullOrEmpty(emp.Role))
                cboRole.SelectedValue = emp.Role;

            if (DateTime.TryParse(emp.HireDate, out DateTime parsedDate))
                dtpHireDate.Value = parsedDate;
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private async void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                //Khóa nút để tránh spam click
                btnSave.Enabled = false;
                btnSave.Text = "Đang lưu...";
                //Thu thập dữ liệu từ Form
                EmployeeDTO newEmp = new()
                {
                    Email = txtEmail.Text.Trim(),
                    FullName = txtFullName.Text.Trim(),
                    HireDate = dtpHireDate.Value.ToString("yyyy-MM-dd"),
                    PhoneNumber = txtPhone.Text.Trim(),
                    // Đã sửa: Dùng SelectedValue để lấy đúng chữ tiếng Anh đem đi lưu
                    Role = cboRole.SelectedValue?.ToString() ?? "Staff",
                    Password = txtPassword.Text.Trim(),
                    AvatarUrl = ""
                };

                bool result = await EmployeeBUS.AddEmployeeAsync(newEmp);
                if (result)
                {
                    MsgBox.Show($"Nhân viên {newEmp.FullName} đã được thêm thành công.", "Thông báo", MsgBox.MessageBoxType.Info);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                // Bất kỳ lỗi nào (Form rỗng, Email sai, Mật khẩu yếu...) từ Server Cloud Functions trả về sẽ hiển thị tại đây
                MsgBox.Show(ex.Message, "Lỗi", MsgBox.MessageBoxType.Error);
            }
            finally
            {
                btnSave.Enabled = true;
                btnSave.Text = "Lưu";
            }
        }
        private void LoadRoles()
        {
            Dictionary<string, string> roleData = new()
            {
                { "manager", "Quản lý" },
                { "barista", "Pha chế" },
                { "order staff", "Nhân viên Order" },
                { "security", "Bảo vệ" }
            };
            cboRole.DataSource = new BindingSource(roleData, null);
            cboRole.DisplayMember = "Value";
            cboRole.ValueMember = "Key";
        }
    }
}