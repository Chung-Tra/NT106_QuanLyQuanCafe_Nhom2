using BUS;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
#pragma warning disable IDE1006
    public partial class ucManagers_Admin : UserControl
#pragma warning restore IDE1006
    {
        public ucManagers_Admin()
        {
            InitializeComponent();
            // cột khai trong Designer; tắt auto-gen ở .cs cho an toàn round-trip
            dgvManagers.AutoGenerateColumns = false;
            dgvLeaveReq.AutoGenerateColumns = false;
            dgvAuditLog.AutoGenerateColumns = false;

            // Chống VS đổi Name cột -> khôi phục Name == DataPropertyName để lookup theo tên không lỗi
            GridColumnGuard.SyncColumnNames(dgvManagers);
            GridColumnGuard.SyncColumnNames(dgvLeaveReq);
            GridColumnGuard.SyncColumnNames(dgvAuditLog);

            // Bộ lọc tìm kiếm (logic ở .cs, control khai ở Designer)
            txtSearchManager.TextChanged += TxtSearchManager_TextChanged;

            // Nút làm mới từng bảng: chỉ tải lại dữ liệu của bảng đó
            DgvRefresh.Attach(dgvManagers, LoadManagerList);
            DgvRefresh.Attach(dgvLeaveReq, LoadLeaveRequests);
            DgvRefresh.Attach(dgvAuditLog, LoadAuditLog);
        }

        private async void UcManagers_Admin_Load(object sender, EventArgs e)
        {
            await LoadManagerList();
            LoadLeaveRequests();
            LoadAuditLog();

            dgvManagers.ClearSelection();
            dgvAuditLog.ClearSelection();

            lblManagerTitle.Cursor  = Cursors.Hand;
            lblLeaveReqTitle.Cursor = Cursors.Hand;
            lblAuditTitle.Cursor    = Cursors.Hand;
        }

        private void LblManagerTitle_Click(object? sender, EventArgs e)
            => new ManagerProfileDetail().ShowDialog(MsgBox.OwnerWindow(this));

        private void LblLeaveReqTitle_Click(object? sender, EventArgs e)
        {
            var items = new[]
            {
                new LeaveItem("Phạm Thu Hà",   "05/05/2026", "06/05/2026", "Việc gia đình cần giải quyết gấp", "Chờ duyệt"),
                new LeaveItem("Trần Minh",     "12/04/2026", "12/04/2026", "Khám sức khỏe định kỳ",            "Đã duyệt"),
                new LeaveItem("Nguyễn Văn An", "20/03/2026", "21/03/2026", "Đám cưới người thân",              "Đã duyệt"),
            };
            new LeaveRequestDetail(items, "Đơn xin nghỉ của Quản lý").ShowDialog(MsgBox.OwnerWindow(this));
        }

        private void LblAuditTitle_Click(object? sender, EventArgs e)
        {
            var dt = new System.Data.DataTable();
            dt.Columns.Add("Thời gian"); dt.Columns.Add("Quản lý"); dt.Columns.Add("Hành động"); dt.Columns.Add("Lý do");
            dt.Rows.Add("02/05 09:15", "QL Trần Minh",     "Sửa giá NL 'Cà phê Arabica' 250K→280K",  "Nhà cung cấp tăng giá");
            dt.Rows.Add("01/05 16:20", "QL Nguyễn Văn An", "Xóa NL 'Syrup dâu'",                     "Ngừng kinh doanh dòng dâu");
            dt.Rows.Add("01/05 14:00", "QL Trần Minh",     "Sửa check-in NV Đỗ Hương 08:30→07:55",   "Hệ thống ghi nhận sai");
            dt.Rows.Add("01/05 10:30", "QL Nguyễn Văn An", "Thêm NL 'Bột matcha Nhật'",              "Bổ sung menu mới");
            dt.Rows.Add("30/04 11:00", "QL Trần Minh",     "Sửa giá NL 'Sữa tươi' 35K→38K",         "Giá thị trường tăng");
            new AuditLogDetail(dt, "Lịch sử thao tác của Quản lý").ShowDialog(MsgBox.OwnerWindow(this));
        }

        // Tải danh sách Quản lý (lọc Role == "manager" từ dữ liệu thật)
        private async Task LoadManagerList()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                dgvManagers.DataSource = null;

                // Task.Run: HTTP + parse JSON chạy ở thread pool, không chiếm luồng UI
                List<EmployeeDTO> fullList = await Task.Run(EmployeeBUS.GetAllEmployeesAsync);
                var managerList = (fullList ?? new List<EmployeeDTO>())
                    .Where(emp => emp.Role == "manager")
                    .ToList();

                // Cấu trúc bảng: 4 cột hiển thị + 4 cột ẩn mang đủ field DTO cho form chi tiết
                DataTable dt = new();
                dt.Columns.Add("Mã QL");
                dt.Columns.Add("Họ tên");
                dt.Columns.Add("Email");
                dt.Columns.Add("Trạng thái");
                dt.Columns.Add("Số điện thoại");
                dt.Columns.Add("VaiTro");
                dt.Columns.Add("TrangThaiRaw");
                dt.Columns.Add("AuthUid");

                foreach (var emp in managerList)
                {
                    dt.Rows.Add(
                        emp.EmployeeId,
                        emp.FullName,
                        emp.Email,
                        emp.Status == "active" ? "Đang làm" : "Xin nghỉ",
                        emp.PhoneNumber,
                        emp.Role,
                        emp.Status,
                        emp.AuthUid
                    );
                }

                dgvManagers.DataSource = dt;
                dgvManagers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvManagers.Columns["Mã QL"].FillWeight     = 18;
                dgvManagers.Columns["Họ tên"].FillWeight    = 32;
                dgvManagers.Columns["Email"].FillWeight     = 32;
                dgvManagers.Columns["Trạng thái"].FillWeight = 18;
                dgvManagers.Columns["Trạng thái"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                foreach (DataGridViewRow row in dgvManagers.Rows)
                {
                    string status = row.Cells["Trạng thái"].Value?.ToString() ?? "";
                    if (status == "Đang làm")
                        row.Cells["Trạng thái"].Style.ForeColor = Color.MediumSeaGreen;
                    else if (status == "Xin nghỉ")
                        row.Cells["Trạng thái"].Style.ForeColor = Color.Orange;
                }

                int total  = managerList.Count;
                int active = managerList.Count(m => m.Status == "active");
                lblTotalManagerValue.Text = $"{total} người";
                lblPresentValue.Text      = $"{active} người";
                lblLeaveValue.Text        = $"{total - active} người";
            }
            catch (Exception ex)
            {
                MsgBox.Show(MsgBox.OwnerWindow(this), $"Lỗi tải danh sách Quản lý: {ex.Message}", "Lỗi hệ thống", MsgBox.MessageBoxType.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void LoadLeaveRequests()
        {
            DataTable dt = new();
            dt.Columns.Add("Nhân viên");
            dt.Columns.Add("Ngày nghỉ");
            dt.Columns.Add("Lý do");

            dt.Rows.Add("Phạm Thu Hà", "05/05 → 06/05", "Việc gia đình cần giải quyết gấp");

            dgvLeaveReq.DataSource = dt;
            dgvLeaveReq.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvLeaveReq.Columns["Nhân viên"].FillWeight = 30;
            dgvLeaveReq.Columns["Ngày nghỉ"].FillWeight = 28;
            dgvLeaveReq.Columns["Lý do"].FillWeight     = 42;

            btnApproveLeave.Text = $"Duyệt ({dt.Rows.Count})";
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

        // Double-click 1 dòng Quản lý -> form chi tiết read-only đủ field
        private async void DgvManagers_CellDoubleClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            EmployeeDTO emp = BuildEmployeeFromRow(dgvManagers.Rows[e.RowIndex]);

            using EmployeeDetail dlg = new(emp);
            if (dlg.ShowDialog(MsgBox.OwnerWindow(this)) == DialogResult.OK)
                await LoadManagerList();
        }

        // Double-click mở chi tiết đơn xin nghỉ / nhật ký thao tác
        private void DgvLeaveReq_CellDoubleClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            LblLeaveReqTitle_Click(sender, e);
        }

        private void DgvAuditLog_CellDoubleClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            LblAuditTitle_Click(sender, e);
        }

        private static EmployeeDTO BuildEmployeeFromRow(DataGridViewRow row) => new()
        {
            EmployeeId  = row.Cells["Mã QL"].Value?.ToString(),
            FullName    = row.Cells["Họ tên"].Value?.ToString(),
            Email       = row.Cells["Email"].Value?.ToString(),
            PhoneNumber = row.Cells["Số điện thoại"].Value?.ToString(),
            Role        = row.Cells["VaiTro"].Value?.ToString(),
            Status      = row.Cells["TrangThaiRaw"].Value?.ToString(),
            AuthUid     = row.Cells["AuthUid"].Value?.ToString(),
        };

        // Bộ lọc theo từ khóa — quét mọi trường hiển thị (kể cả Trạng thái, SĐT),
        // chỉ bỏ các cột kỹ thuật mang giá trị raw tiếng Anh
        private void TxtSearchManager_TextChanged(object? sender, EventArgs e)
        {
            if (dgvManagers.DataSource is not DataTable dt) return;

            try
            {
                dt.DefaultView.RowFilter =
                    SearchFilter.AllColumnsFilter(dt, txtSearchManager.Text, "VaiTro", "TrangThaiRaw", "AuthUid");
            }
            catch (Exception ex) { Console.WriteLine("Lỗi bộ lọc QL: " + ex.Message); }
        }

        private void BtnSwitchRole_Click(object? sender, EventArgs e)
        {
            string switchPrompt =
                "Bạn muốn chuyển sang giao diện Quản lý?" + Environment.NewLine + Environment.NewLine +
                "Tính năng này dùng khi Quản lý nghỉ," + Environment.NewLine +
                "Admin cần trực tiếp xử lý công việc.";

            var result = MsgBox.Show(
                this,
                switchPrompt,
                "Đóng vai Quản lý",
                MsgBox.MessageBoxType.Warning);

            if (result == DialogResult.Yes)
            {
                // Tìm MainDashboard và rebuild sidebar với role "manager"
                Form? dashboard = this.FindForm();
                if (dashboard is MainDashboard mainDash)
                {
                    // Đóng dashboard hiện tại và mở lại với role manager
                    MsgBox.Show(
                        mainDash,
                        "Đang chuyển sang giao diện Quản lý...\n\nBạn sẽ có quyền truy cập:\n• Sản phẩm và Thực đơn\n• Đơn hàng và Hóa đơn\n• Quản lý Nhân viên\n• Feedback khách hàng",
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

        // Thêm Quản lý mới
        private async void BtnAddManager_Click(object? sender, EventArgs e)
        {
            AddEmployee frm = new();
            if (frm.ShowDialog(MsgBox.OwnerWindow(this)) == DialogResult.OK)
            {
                MsgBox.Show(MsgBox.OwnerWindow(this), "Đã thêm Quản lý mới!", "Thành công", MsgBox.MessageBoxType.Success);
                await LoadManagerList();
            }
        }

        // Sửa Quản lý đang chọn
        private async void BtnEditManager_Click(object? sender, EventArgs e)
        {
            if (dgvManagers.CurrentRow == null || dgvManagers.CurrentRow.Index < 0)
            {
                MsgBox.Show(MsgBox.OwnerWindow(this), "Vui lòng chọn một Quản lý để chỉnh sửa!", "Thông báo", MsgBox.MessageBoxType.Warning);
                return;
            }

            EmployeeDTO emp = BuildEmployeeFromRow(dgvManagers.CurrentRow);

            EditEmployee frm = new(emp);
            if (frm.ShowDialog(MsgBox.OwnerWindow(this)) == DialogResult.OK)
                await LoadManagerList();
        }

        private void BtnApproveLeave_Click(object? sender, EventArgs e)
        {
            if (dgvLeaveReq.Rows.Count == 0)
            {
                MsgBox.Show(MsgBox.OwnerWindow(this), "Không có đơn xin nghỉ nào!", "Thông báo", MsgBox.MessageBoxType.Warning);
                return;
            }

            var result = MsgBox.Show(
                this,
                "Duyệt đơn xin nghỉ của QL Phạm Thu Hà?\n05/05 - 06/05 (2 ngày)\nLý do: Việc gia đình",
                "Duyệt đơn xin nghỉ",
                MsgBox.MessageBoxType.Warning);

            if (result == DialogResult.Yes)
            {
                DataTable dt = new();
                dt.Columns.Add("Nhân viên");
                dt.Columns.Add("Ngày nghỉ");
                dt.Columns.Add("Lý do");
                dt.Rows.Add("✓ Phạm Thu Hà (đã duyệt)", "05/05 → 06/05", "Việc gia đình");

                dgvLeaveReq.DataSource = dt;
                btnApproveLeave.Text = "Duyệt (0)";
                MsgBox.Show(MsgBox.OwnerWindow(this), "Đã duyệt đơn xin nghỉ!", "Thành công", MsgBox.MessageBoxType.Success);
            }
        }
    }
}
