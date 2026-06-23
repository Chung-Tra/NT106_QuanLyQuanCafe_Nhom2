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
