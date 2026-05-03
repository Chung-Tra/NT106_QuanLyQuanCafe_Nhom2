using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using DTO;

namespace GUI
{
    public partial class ucAdmin_Managers : UserControl
    {
        public ucAdmin_Managers()
        {
            InitializeComponent();
        }

        private void ucAdmin_Managers_Load(object sender, EventArgs e)
        {
            LoadManagerList();
            LoadLeaveRequests();
            LoadAuditLog();

            btnSwitchRole.Click += btnSwitchRole_Click;
            btnAddManager.Click += btnAddManager_Click;
            btnEditManager.Click += btnEditManager_Click;
            btnApproveLeave.Click += btnApproveLeave_Click;
        }

        private void LoadManagerList()
        {
            DataTable dt = new();
            dt.Columns.Add("Mã QL");
            dt.Columns.Add("Họ tên");
            dt.Columns.Add("Email");
            dt.Columns.Add("Trạng thái");

            dt.Rows.Add("QL001", "Nguyễn Văn An", "an.nguyen@cafe.com", "Đang làm");
            dt.Rows.Add("QL002", "Trần Minh", "minh.tran@cafe.com", "Đang làm");
            dt.Rows.Add("QL003", "Phạm Thu Hà", "ha.pham@cafe.com", "Xin nghỉ");

            dgvManagers.DataSource = dt;
            dgvManagers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvManagers.RowHeadersVisible = false;
            dgvManagers.ReadOnly = true;
            dgvManagers.AllowUserToAddRows = false;
            dgvManagers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            foreach (DataGridViewRow row in dgvManagers.Rows)
            {
                string status = row.Cells["Trạng thái"].Value?.ToString() ?? "";
                if (status == "Đang làm")
                    row.Cells["Trạng thái"].Style.ForeColor = Color.MediumSeaGreen;
                else if (status == "Xin nghỉ")
                    row.Cells["Trạng thái"].Style.ForeColor = Color.Orange;
            }

            lblTotalManagerValue.Text = "3 người";
            lblPresentValue.Text = "2 người";
            lblLeaveValue.Text = "1 người";
        }

        private void LoadLeaveRequests()
        {
            lstLeaveReq.Items.Clear();
            lstLeaveReq.Items.Add("Phạm Thu Hà - Nghỉ 05/05 → 06/05");
            lstLeaveReq.Items.Add("  Lý do: Việc gia đình cần giải quyết gấp");
            btnApproveLeave.Text = "Duyệt (1)";
        }

        private void LoadAuditLog()
        {
            DataTable dt = new();
            dt.Columns.Add("Thời gian");
            dt.Columns.Add("Quản lý");
            dt.Columns.Add("Hành động");
            dt.Columns.Add("Lý do");

            dt.Rows.Add("02/05 09:15", "QL Trần Minh", "Sửa giá NL 'Cà phê Arabica' 250K→280K", "Nhà cung cấp tăng giá");
            dt.Rows.Add("01/05 16:20", "QL Nguyễn Văn An", "Xóa NL 'Syrup dâu'", "Ngừng kinh doanh dòng dâu");
            dt.Rows.Add("01/05 14:00", "QL Trần Minh", "Sửa check-in NV Đỗ Hương 08:30→07:55", "Hệ thống ghi nhận sai");
            dt.Rows.Add("01/05 10:30", "QL Nguyễn Văn An", "Thêm NL 'Bột matcha Nhật'", "Bổ sung menu mới");
            dt.Rows.Add("30/04 11:00", "QL Trần Minh", "Sửa giá NL 'Sữa tươi' 35K→38K", "Giá thị trường tăng");

            dgvAuditLog.DataSource = dt;
            dgvAuditLog.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvAuditLog.RowHeadersVisible = false;
            dgvAuditLog.ReadOnly = true;
            dgvAuditLog.AllowUserToAddRows = false;

            dgvAuditLog.Columns["Thời gian"].FillWeight = 12;
            dgvAuditLog.Columns["Quản lý"].FillWeight = 18;
            dgvAuditLog.Columns["Hành động"].FillWeight = 40;
            dgvAuditLog.Columns["Lý do"].FillWeight = 30;
        }

        private void btnSwitchRole_Click(object? sender, EventArgs e)
        {
            var result = MessageBox.Show(
                "Bạn muốn chuyển sang giao diện Quản lý?\n\n" +
                "Tính năng này dùng khi Quản lý nghỉ,\nAdmin cần trực tiếp xử lý công việc.",
                "Đóng vai Quản lý",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Tìm MainDashboard và rebuild sidebar với role "manager"
                Form? dashboard = this.FindForm();
                if (dashboard is MainDashboard mainDash)
                {
                    // Đóng dashboard hiện tại và mở lại với role manager
                    MsgBox.Show(
                        "Đang chuyển sang giao diện Quản lý...\n\n" +
                        "Bạn sẽ có quyền truy cập:\n" +
                        "• Sản phẩm và Thực đơn\n" +
                        "• Đơn hàng và Hóa đơn\n" +
                        "• Quản lý Nhân viên\n" +
                        "• Feedback khách hàng",
                        "Chuyển vai trò", MsgBox.MessageBoxType.Success);

                    // Lưu role tạm thời
                    if (GlobalSession.CurrentUser != null)
                    {
                        GlobalSession.CurrentUser.Role = "manager";
                    }

                    // Mở MainDashboard mới với role manager
                    MainDashboard newDash = new();
                    newDash.Show();
                    dashboard.Close();
                }
            }
        }

        private void btnAddManager_Click(object? sender, EventArgs e)
        {
            AddEmployee frm = new();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                MsgBox.Show("Đã thêm Quản lý mới!", "Thành công", MsgBox.MessageBoxType.Success);
                LoadManagerList();
            }
        }

        private void btnEditManager_Click(object? sender, EventArgs e)
        {
            if (dgvManagers.CurrentRow == null) return;
            string name = dgvManagers.CurrentRow.Cells["Họ tên"].Value?.ToString() ?? "";
            MsgBox.Show($"Mở form chỉnh sửa thông tin Quản lý: {name}", "Sửa QL", MsgBox.MessageBoxType.Info);
        }

        private void btnApproveLeave_Click(object? sender, EventArgs e)
        {
            if (lstLeaveReq.Items.Count == 0)
            {
                MsgBox.Show("Không có đơn xin nghỉ nào!", "Thông báo", MsgBox.MessageBoxType.Warning);
                return;
            }

            var result = MessageBox.Show(
                "Duyệt đơn xin nghỉ của QL Phạm Thu Hà?\n05/05 - 06/05 (2 ngày)\nLý do: Việc gia đình",
                "Duyệt đơn xin nghỉ",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                lstLeaveReq.Items.Clear();
                lstLeaveReq.Items.Add("[ĐÃ DUYỆT] Phạm Thu Hà - 05/05 → 06/05");
                btnApproveLeave.Text = "Duyệt (0)";
                MsgBox.Show("Đã duyệt đơn xin nghỉ!", "Thành công", MsgBox.MessageBoxType.Success);
            }
        }
    }
}
