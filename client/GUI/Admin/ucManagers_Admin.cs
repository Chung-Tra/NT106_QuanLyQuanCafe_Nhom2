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
            DgvRefresh.Attach(dgvLeaveReq, LoadLeaveRequestsAsync);
            DgvRefresh.Attach(dgvAuditLog, LoadAuditLog);
        }

        private async void UcManagers_Admin_Load(object sender, EventArgs e)
        {
            await LoadManagerList();
            await LoadLeaveRequestsAsync();
            await LoadAuditLog();

            dgvManagers.ClearSelection();
            dgvAuditLog.ClearSelection();

            lblManagerTitle.Cursor  = Cursors.Hand;
            lblLeaveReqTitle.Cursor = Cursors.Hand;
            lblAuditTitle.Cursor    = Cursors.Hand;
        }

        private void LblManagerTitle_Click(object? sender, EventArgs e)
            => new ManagerProfileDetail().ShowDialog(MsgBox.OwnerWindow(this));

        private static string LeaveStatusVi(string? s) => s switch
        {
            "cho_duyet" => "Chờ duyệt",
            "da_duyet"  => "Đã duyệt",
            "tu_choi"   => "Từ chối",
            _           => s ?? ""
        };

        // Đơn xin nghỉ THẬT của các Quản lý (mọi trạng thái) từ node leave-requests.
        private async void LblLeaveReqTitle_Click(object? sender, EventArgs e)
        {
            var items = new List<LeaveItem>();
            try
            {
                var all  = await LeaveRequestBUS.GetAll();
                var emps = (await Task.Run(EmployeeBUS.GetAllEmployeesAsync))
                           .Where(x => x.EmployeeId != null).ToDictionary(x => x.EmployeeId!, x => x);

                foreach (var l in all.Values.OrderByDescending(x => x.SentAt))
                {
                    emps.TryGetValue(l.EmployeeId ?? "", out var emp);
                    if ((emp?.Role ?? "").ToLower() != "manager") continue;   // màn này chỉ đơn của Quản lý
                    string name = emp?.FullName ?? l.EmployeeId ?? "";
                    items.Add(new LeaveItem(name, l.FromDate ?? "", l.ToDate ?? "", l.Reason ?? "", LeaveStatusVi(l.Status)));
                }
            }
            catch { /* offline → danh sách trống */ }

            new LeaveRequestDetail(items, "Đơn xin nghỉ của Quản lý").ShowDialog(MsgBox.OwnerWindow(this));
        }

        private async void LblAuditTitle_Click(object? sender, EventArgs e)
            => new AuditLogDetail(await BuildAuditTableAsync(), "Lịch sử thao tác của Quản lý")
                   .ShowDialog(MsgBox.OwnerWindow(this));

        // Bảng nhật ký thao tác THẬT (node audit-logs) — dùng chung cho lưới tóm tắt và popup chi tiết.
        private static async Task<DataTable> BuildAuditTableAsync()
        {
            var dt = new DataTable();
            dt.Columns.Add("Thời gian");
            dt.Columns.Add("Quản lý");
            dt.Columns.Add("Hành động");
            dt.Columns.Add("Lý do");
            try
            {
                var logs = await AuditLogBUS.GetAll();
                foreach (var l in logs.Values.OrderByDescending(x => x.Timestamp))
                {
                    string time = l.Timestamp > 0
                        ? DateTimeOffset.FromUnixTimeMilliseconds(l.Timestamp).LocalDateTime.ToString("dd/MM HH:mm")
                        : "";
                    string who    = string.IsNullOrWhiteSpace(l.Ten) ? (l.EmployeeId ?? "") : l.Ten!;
                    string action = string.IsNullOrWhiteSpace(l.DoiTuong) ? (l.ThaoTac ?? "") : $"{l.ThaoTac}: {l.DoiTuong}";
                    dt.Rows.Add(time, who, action, l.LyDo);
                }
            }
            catch { /* offline */ }
            return dt;
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

        // Đơn xin nghỉ ĐANG CHỜ DUYỆT của các Quản lý (thật, từ Firebase)
        private async Task LoadLeaveRequestsAsync()
        {
            DataTable dt = new();
            dt.Columns.Add("Mã đơn");   // cột dữ liệu ẩn (grid không có cột này)
            dt.Columns.Add("Nhân viên");
            dt.Columns.Add("Ngày nghỉ");
            dt.Columns.Add("Lý do");

            int count = 0;
            try
            {
                var all = await LeaveRequestBUS.GetAll();
                var emps = (await Task.Run(EmployeeBUS.GetAllEmployeesAsync))
                    .Where(x => x.EmployeeId != null).ToDictionary(x => x.EmployeeId!, x => x);

                foreach (var kv in all.Where(l => l.Value.Status == "cho_duyet").OrderBy(l => l.Value.SentAt))
                {
                    var l = kv.Value;
                    emps.TryGetValue(l.EmployeeId ?? "", out var emp);
                    // Màn này chỉ hiển thị đơn của Quản lý
                    if ((emp?.Role ?? "").ToLower() != "manager") continue;
                    string name = emp?.FullName ?? l.EmployeeId ?? "";
                    string ngay = l.FromDate == l.ToDate ? (l.FromDate ?? "") : $"{l.FromDate} → {l.ToDate}";
                    dt.Rows.Add(kv.Key, name, ngay, l.Reason);
                    count++;
                }
            }
            catch { /* offline */ }

            dgvLeaveReq.DataSource = dt;
            dgvLeaveReq.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            if (dgvLeaveReq.Columns.Contains("Nhân viên")) dgvLeaveReq.Columns["Nhân viên"].FillWeight = 30;
            if (dgvLeaveReq.Columns.Contains("Ngày nghỉ")) dgvLeaveReq.Columns["Ngày nghỉ"].FillWeight = 28;
            if (dgvLeaveReq.Columns.Contains("Lý do")) dgvLeaveReq.Columns["Lý do"].FillWeight = 42;

            btnApproveLeave.Text = $"Duyệt ({count})";
        }

        private async Task LoadAuditLog()
        {
            dgvAuditLog.DataSource = await BuildAuditTableAsync();
            dgvAuditLog.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvAuditLog.RowHeadersVisible = false;
            dgvAuditLog.ReadOnly = true;
            dgvAuditLog.AllowUserToAddRows = false;

            if (dgvAuditLog.Columns.Contains("Thời gian")) dgvAuditLog.Columns["Thời gian"].FillWeight = 12;
            if (dgvAuditLog.Columns.Contains("Quản lý"))   dgvAuditLog.Columns["Quản lý"].FillWeight   = 18;
            if (dgvAuditLog.Columns.Contains("Hành động")) dgvAuditLog.Columns["Hành động"].FillWeight = 40;
            if (dgvAuditLog.Columns.Contains("Lý do"))     dgvAuditLog.Columns["Lý do"].FillWeight     = 30;
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

        private async void BtnApproveLeave_Click(object? sender, EventArgs e)
        {
            var rowView = (dgvLeaveReq.CurrentRow?.DataBoundItem as DataRowView)
                          ?? (dgvLeaveReq.Rows.Count > 0 ? dgvLeaveReq.Rows[0].DataBoundItem as DataRowView : null);
            if (rowView == null)
            {
                MsgBox.Show(MsgBox.OwnerWindow(this), "Không có đơn xin nghỉ nào!", "Thông báo", MsgBox.MessageBoxType.Warning);
                return;
            }

            string id   = rowView["Mã đơn"]?.ToString() ?? "";
            string name = rowView["Nhân viên"]?.ToString() ?? "";
            string ngay = rowView["Ngày nghỉ"]?.ToString() ?? "";

            var result = MsgBox.Show(this,
                $"Duyệt đơn xin nghỉ của {name}?\n{ngay}",
                "Duyệt đơn xin nghỉ", MsgBox.MessageBoxType.Warning);

            if (result == DialogResult.Yes)
            {
                var (ok, msg) = await LeaveRequestBUS.Update(id, new
                {
                    trang_thai = "da_duyet",
                    nguoi_duyet_id = GlobalSession.CurrentUser?.EmployeeId ?? "",
                    thoi_gian_duyet = DateTimeOffset.Now.ToUnixTimeMilliseconds()
                });
                if (ok)
                {
                    MsgBox.Show(MsgBox.OwnerWindow(this), "Đã duyệt đơn xin nghỉ!", "Thành công", MsgBox.MessageBoxType.Success);
                    await LoadLeaveRequestsAsync();
                }
                else MsgBox.Show(MsgBox.OwnerWindow(this), msg, "Lỗi", MsgBox.MessageBoxType.Error);
            }
        }
    }
}
