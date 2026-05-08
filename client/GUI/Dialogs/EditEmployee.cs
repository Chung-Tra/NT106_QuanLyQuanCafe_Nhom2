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
            txtFullName.Multiline = true;
            txtFullName.WordWrap = true;
            txtFullName.AcceptsReturn = false;
            txtFullName.TextChanged += (_, _) => RecalcEditEmployeeLayout();
            BindData(emp);
        }

        private void RecalcEditEmployeeLayout()
        {
            const int lx = 30;
            const int fx = 34;
            const int fw = 350;
            const int g = 8;

            int y = lblTitle.Bottom + 14;

            lblEmpId.Location = new Point(lx, y);
            y += lblEmpId.Height + 2;
            txtEmpId.Location = new Point(fx, y);
            txtEmpId.Width = fw;
            y = txtEmpId.Bottom + g;

            lblEmail.Location = new Point(lx, y);
            y += lblEmail.Height + 2;
            txtEmail.Location = new Point(fx, y);
            txtEmail.Width = fw;
            DialogAutosizeHelper.SetWrappedTextBoxHeight(txtEmail, 30, 80);
            y = txtEmail.Bottom + g;

            lblFullName.Location = new Point(lx, y);
            y += lblFullName.Height + 2;
            txtFullName.Location = new Point(fx, y);
            txtFullName.Width = fw;
            DialogAutosizeHelper.SetWrappedTextBoxHeight(txtFullName, 32, 120);
            y = txtFullName.Bottom + g;

            lblPhone.Location = new Point(lx, y);
            y += lblPhone.Height + 2;
            txtPhone.Location = new Point(fx, y);
            txtPhone.Width = fw;
            y = txtPhone.Bottom + g;

            lblRole.Location = new Point(lx, y);
            lblStatus.Location = new Point(220, y);
            y += Math.Max(lblRole.Height, lblStatus.Height) + 2;

            cboRole.Location = new Point(fx, y);
            cboStatus.Location = new Point(224, y);
            y = Math.Max(cboRole.Bottom, cboStatus.Bottom) + g + 8;

            btnCancel.Location = new Point(fx, y);
            btnSave.Location = new Point(234, y);

            int bottom = y + btnSave.Height + 30;
            if (bottom > ClientSize.Height || ClientSize.Width < 420)
                ClientSize = new Size(Math.Max(ClientSize.Width, 420), bottom);

            lblTitle.Location = new Point(Math.Max(30, (ClientSize.Width - lblTitle.Width) / 2), 23);
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
            txtEmail.Text = emp.Email ?? "—";
            txtFullName.Text = emp.FullName;
            txtPhone.Text = emp.PhoneNumber;

            cboRole.SelectedValue = emp.Role ?? "";
            cboStatus.SelectedValue = emp.Status ?? "active";
            RecalcEditEmployeeLayout();
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
                    MsgBox.Show(this, "Cập nhật thông tin nhân viên thành công!", "Thành công", MsgBox.MessageBoxType.Success);
                    this.DialogResult = DialogResult.OK; // Báo hiệu cho Form cha biết đã sửa xong
                    this.Close();
                }
                else
                {
                    // Trả ra lỗi từ Validation hoặc từ Server
                    MsgBox.Show(this, result.Message, "Lỗi xác thực", MsgBox.MessageBoxType.Warning);
                    btnSave.Enabled = true;
                    btnSave.Text = "LƯU THAY ĐỔI";
                }
            }
            catch (Exception ex)
            {
                MsgBox.Show(this, ex.Message, "Lỗi hệ thống", MsgBox.MessageBoxType.Error);
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