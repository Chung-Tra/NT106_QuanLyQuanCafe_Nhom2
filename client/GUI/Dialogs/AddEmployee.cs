using BUS;
using DTO;
using System;
using System.Collections.Generic;
using System.Drawing;
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
            ConfigureWrapFields();
            RelayoutAddEmployeePanel();
            txtFullName.TextChanged += (_, _) => RelayoutAddEmployeePanel();
            txtEmail.TextChanged += (_, _) => RelayoutAddEmployeePanel();
            txtPhone.TextChanged += (_, _) => RelayoutAddEmployeePanel();
        }

        private void ConfigureWrapFields()
        {
            txtFullName.BorderStyle = BorderStyle.FixedSingle;
            txtEmail.BorderStyle = BorderStyle.FixedSingle;
            txtPhone.BorderStyle = BorderStyle.FixedSingle;
            txtPassword.BorderStyle = BorderStyle.FixedSingle;
            txtFullName.Multiline = true;
            txtFullName.WordWrap = true;
            txtFullName.AcceptsReturn = false;
            txtEmail.Multiline = true;
            txtEmail.WordWrap = true;
            txtEmail.AcceptsReturn = false;
            txtPhone.Multiline = true;
            txtPhone.WordWrap = true;
            txtPhone.AcceptsReturn = false;
        }

        /// <summary>Sắp xếp lại chiều cao các ô và panel theo độ dài chữ.</summary>
        private void RelayoutAddEmployeePanel()
        {
            const int left = 40;
            const int w = 365;
            const int g = 12;
            int y = 80;

            txtFullName.SetBounds(left, y, w, txtFullName.Height);
            DialogAutosizeHelper.SetWrappedTextBoxHeight(txtFullName, 28, 90);
            y = txtFullName.Bottom + g;

            txtEmail.SetBounds(left, y, w, txtEmail.Height);
            DialogAutosizeHelper.SetWrappedTextBoxHeight(txtEmail, 28, 90);
            y = txtEmail.Bottom + g;

            txtPhone.SetBounds(left, y, w, txtPhone.Height);
            DialogAutosizeHelper.SetWrappedTextBoxHeight(txtPhone, 28, 80);
            y = txtPhone.Bottom + g;

            dtpHireDate.Left = left;
            dtpHireDate.Width = w;
            dtpHireDate.Top = y;
            y = dtpHireDate.Bottom + g;

            cboRole.Left = left;
            cboRole.Width = w;
            cboRole.Top = y;
            y = cboRole.Bottom + g;

            txtPassword.Left = left;
            txtPassword.Width = w;
            txtPassword.Multiline = false;
            txtPassword.Height = 28;
            txtPassword.Top = y;
            txtPassword.PasswordChar = '*';
            y = txtPassword.Bottom + g + 8;

            FixAddEmployeeButtonRow(left, w, y);
        }

        private void FixAddEmployeeButtonRow(int left, int w, int y)
        {
            int gapBtn = Math.Max(24, Math.Min(72, (w - btnSave.Width - btnCancel.Width) / 2));
            int startX = left + Math.Max(0, (w - btnSave.Width - gapBtn - btnCancel.Width) / 2);
            btnSave.Location = new Point(startX, y);
            btnCancel.Location = new Point(btnSave.Right + gapBtn, y);

            panel1.Height = btnSave.Bottom + 28;
            ClientSize = new Size(ClientSize.Width, panel1.Bottom + panel1.Top);
            textBox1.Width = panel1.Width - 24;
            textBox1.Left = (panel1.Width - textBox1.Width) / 2;
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

            ConfigureWrapFields();
            RelayoutAddEmployeePanel();
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
                    MsgBox.Show(this, $"Nhân viên {newEmp.FullName} đã được thêm thành công.", "Thông báo", MsgBox.MessageBoxType.Info);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                // Bất kỳ lỗi nào (Form rỗng, Email sai, Mật khẩu yếu...) từ Server Cloud Functions trả về sẽ hiển thị tại đây
                MsgBox.Show(this, ex.Message, "Lỗi", MsgBox.MessageBoxType.Error);
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