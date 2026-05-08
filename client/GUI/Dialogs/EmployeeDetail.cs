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
    public partial class EmployeeDetail : Form
    {
        private readonly EmployeeDTO _currentEmp;
        public EmployeeDetail(EmployeeDTO emp)
        {
            InitializeComponent();
            _currentEmp = emp;
            BindData(emp);
        }

        private void BindData(EmployeeDTO emp)
        {
            txtEmpId.Text = emp.EmployeeId;
            txtEmail.Text = emp.Email ?? "—";
            txtFullName.Text = emp.FullName;
            txtPhone.Text = emp.PhoneNumber ?? "—";

            txtRole.Text = emp.Role switch
            {
                "manager" => "Quản lý",
                "staff" => "Nhân viên order",
                "order staff" => "Nhân viên Order",
                "barista" => "Nhân viên pha chế",
                "security" => "Bảo vệ",
                _ => emp.Role ?? "—"
            };

            if (emp.Status == "active")
            {
                txtStatus.Text = "Đang hoạt động";
            }
            else
            {
                txtStatus.Text = "Không hoạt động";
            }

            RecalcEmployeeDetailLayout();
        }

        private void RecalcEmployeeDetailLayout()
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
            DialogAutosizeHelper.SetWrappedTextBoxHeight(txtEmail, 32, 100);
            y = txtEmail.Bottom + g;

            lblFullName.Location = new Point(lx, y);
            y += lblFullName.Height + 2;
            txtFullName.Location = new Point(fx, y);
            txtFullName.Width = fw;
            DialogAutosizeHelper.SetWrappedTextBoxHeight(txtFullName, 36, 120);
            y = txtFullName.Bottom + g;

            lblPhone.Location = new Point(lx, y);
            y += lblPhone.Height + 2;
            txtPhone.Location = new Point(fx, y);
            txtPhone.Width = fw;
            DialogAutosizeHelper.SetWrappedTextBoxHeight(txtPhone, 28, 72);
            y = txtPhone.Bottom + g;

            lblRole.Location = new Point(lx, y);
            lblStatus.Location = new Point(220, y);
            y += Math.Max(lblRole.Height, lblStatus.Height) + 2;

            txtRole.Location = new Point(fx, y);
            txtRole.Width = 160;
            txtStatus.Location = new Point(224, y);
            txtStatus.Width = 160;
            DialogAutosizeHelper.SetWrappedTextBoxHeight(txtRole, 28, 80);
            if (txtStatus.Height < txtRole.Height)
                txtStatus.Height = txtRole.Height;
            y = Math.Max(txtRole.Bottom, txtStatus.Bottom) + g + 8;

            BtnRemove.Location = new Point(fx, y);
            btnClose.Location = new Point(234, y);

            int bottom = y + BtnRemove.Height + 32;
            int preferredW = Math.Max(ClientSize.Width, 420);
            int maxH = DialogAutosizeHelper.MaxDialogClientHeight(this);
            DialogAutosizeHelper.CapFormHeightWithAutoScroll(this, bottom, preferredW, maxH);

            lblTitle.Location = new Point(Math.Max(24, (ClientSize.Width - lblTitle.Width) / 2), 22);
        }

        private async void BtnRemove_Click(object sender, EventArgs e)
        {
            DialogResult confirm = MsgBox.Show(
                this,
                $"Sếp có chắc chắn muốn XÓA VĨNH VIỄN nhân viên [{_currentEmp.FullName}] không?\nHành động này không thể hoàn tác!",
                "Cảnh báo xóa",
                MsgBox.MessageBoxType.Warning);

            // Nếu bấm YES thì tiến hành xóa
            if (confirm == DialogResult.Yes)
            {
                // Gọi BUS thực thi xóa (Truyền ID và Uid Firebase)
                var (Success, Message) = await EmployeeBUS.DeleteEmployeeAsync(_currentEmp.EmployeeId ?? "", _currentEmp.AuthUid ?? "");

                // Xử lý kết quả
                if (Success)
                {
                    // MsgBox Xanh Lá
                    MsgBox.Show(this, "Đã xóa nhân viên thành công khỏi hệ thống!", "Thông báo", MsgBox.MessageBoxType.Success);
                    this.DialogResult = DialogResult.OK;
                    // Xóa xong thì tự động đóng cái Form này lại
                    this.Close();
                }
                else
                {
                    // MsgBox Đỏ
                    MsgBox.Show(this, Message, "Lỗi khi xóa", MsgBox.MessageBoxType.Error);
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
