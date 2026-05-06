using BUS;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class EditEmployee : Form
    {

        // Lưu trữ thông tin cũ để gọi API sau khi người dùng sửa xong 
        private string _currentEmpId = string.Empty;
        private string _currentAuthUid = string.Empty;

        // Constructor nhận dữ liệu từ Form Main truyền sang
        public EditEmployee(EmployeeDTO emp)
        {
            InitializeComponent();
            LoadRolesAndStatus();
            BindData(emp);
        }

        private void LoadRolesAndStatus()
        {
            // Binding Chức vụ (Roles)
            Dictionary<string, string> roles = new()
            {
                { "manager", "Quản lý" },
                { "order staff", "Nhân viên Order" },
                { "barista", "Pha chế" },
                { "security", "Bảo vệ" }
            };
            cboRole.DataSource = new BindingSource(roles, null);
            cboRole.DisplayMember = "Value";
            cboRole.ValueMember = "Key";

            // Binding Trạng thái (Status)
            Dictionary<string, string> status = new()
            {
                { "active", "Hoạt động" },
                { "inactive", "Ngừng hoạt động / Khóa" }
            };
            cboStatus.DataSource = new BindingSource(status, null);
            cboStatus.DisplayMember = "Value";
            cboStatus.ValueMember = "Key";
        }

        private void BindData(EmployeeDTO emp)
        {
            _currentEmpId = emp.EmployeeId ?? ""; // Lưu ID để lát gọi API
            _currentAuthUid = emp.AuthUid ?? ""; // Lưu AuthUid để lát gọi API
            txtEmpId.Text = emp.EmployeeId;
            txtFullName.Text = emp.FullName;
            txtPhone.Text = emp.PhoneNumber;

            cboRole.SelectedValue = emp.Role ?? "";
            cboStatus.SelectedValue = emp.Status ?? "active";
        }

        private async void BtnSave_Click(object sender, EventArgs e)
        {
            btnSave.Enabled = false;
            btnSave.Text = "ĐANG LƯU...";

            try
            {
                // Sử dụng DTO để truyền xuống BUS thay vì tạo object ẩn danh
                EmployeeDTO empUpdate = new()
                {
                    FullName = txtFullName.Text.Trim(),
                    PhoneNumber = txtPhone.Text.Trim(),
                    Role = cboRole.SelectedValue?.ToString(),
                    Status = cboStatus.SelectedValue?.ToString()
                };

                Task<(bool Success, string Message)> task;

                if (empUpdate.Status == "active")
                    task = EmployeeBUS.UpdateEmployeeAsync(_currentEmpId, empUpdate);
                else
                    task = EmployeeBUS.LockEmployeeAsync(_currentEmpId, _currentAuthUid);

                var result = await task;

                if (result.Success)
                {
                    MsgBox.Show("Cập nhật thông tin nhân viên thành công!", "Thành công", MsgBox.MessageBoxType.Success);
                    this.DialogResult = DialogResult.OK; // Báo hiệu cho Form cha biết đã sửa xong
                    this.Close();
                }
                else
                {
                    // Trả ra lỗi từ Validation hoặc từ Server
                    MsgBox.Show(result.Message, "Lỗi xác thực", MsgBox.MessageBoxType.Warning);
                    btnSave.Enabled = true;
                    btnSave.Text = "LƯU THAY ĐỔI";
                }
            }
            catch (Exception ex)
            {
                MsgBox.Show(ex.Message, "Lỗi hệ thống", MsgBox.MessageBoxType.Error);
                btnSave.Enabled = true;
                btnSave.Text = "LƯU THAY ĐỔI";
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}