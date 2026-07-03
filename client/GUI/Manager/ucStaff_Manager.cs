using BUS;
using DTO;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class ucStaff_Manager : UserControl
    {
        public ucStaff_Manager()
        {
            InitializeComponent();
            InitFilterControls();

            // Nút làm mới từng bảng: chỉ tải lại dữ liệu của bảng đó
            DgvRefresh.Attach(dgvStaff, LoadRealData);
            DgvRefresh.Attach(dgvLeaveReq, LoadLeaveRequests);

            // Đơn xin nghỉ hiện dạng thẻ giống màn "Quản lý" của Admin: bấm tiêu đề
            // hoặc double-click dòng để mở dialog LeaveRequestDetail (tái dùng, không dựng lại).
            lblLeaveReqTitle.Cursor = Cursors.Hand;
            lblLeaveReqTitle.Click     += (s, e) => ShowLeaveRequestsDialog();
            dgvLeaveReq.CellDoubleClick += (s, e) => ShowLeaveRequestsDialog();
        }

        // Mở dialog thẻ đơn xin nghỉ của nhân viên (cùng giao diện với đơn của Quản lý).
        private void ShowLeaveRequestsDialog()
        {
            var items = new List<LeaveItem>();
            if (dgvLeaveReq.DataSource is DataTable dt)
                foreach (DataRow r in dt.Rows)
                {
                    string date = r["Ngày nghỉ"]?.ToString() ?? "";
                    items.Add(new LeaveItem(
                        r["Nhân viên"]?.ToString() ?? "",
                        date, date,
                        r["Lý do"]?.ToString() ?? "",
                        "Chờ duyệt"));
                }

            new LeaveRequestDetail(items, "Đơn xin nghỉ của nhân viên")
                .ShowDialog(MsgBox.OwnerWindow(this));
        }

        // Sự kiện load (wired in Designer)
        private async void ucStaff_Manager_Load(object sender, EventArgs e)
        {
            await LoadRealData();
            LoadLeaveRequests();
        }

        // Tải danh sách nhân viên
        private async Task LoadRealData()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                // Cột dgvStaff đã khai sẵn trong Designer (Name + DataPropertyName).
                // KHÔNG Clear cột: vì AutoGenerateColumns=false, xoá cột sẽ làm grid trống
                // và Columns["Mã NV"] = null → NullReferenceException. Chỉ cần reset DataSource.
                dgvStaff.DataSource = null;

                // 1. Lấy TẤT CẢ danh sách từ Server về (Task.Run: HTTP + parse JSON
                // chạy ở thread pool để không chiếm luồng UI trong lúc chờ server)
                List<EmployeeDTO> fullList = await Task.Run(EmployeeBUS.GetAllEmployeesAsync);

                if (fullList == null || fullList.Count == 0) return;

                // 2. Lọc: không lấy admin
                var staffList = fullList.Where(emp => emp.Role != "admin").ToList();

                // 3. Tạo cấu trúc bảng
                DataTable dt = new();
                dt.Columns.Add("Mã NV");
                dt.Columns.Add("Họ và Tên");
                dt.Columns.Add("Vị Trí");
                dt.Columns.Add("Trạng Thái");
                dt.Columns.Add("Số điện thoại");
                dt.Columns.Add("AuthUid");
                dt.Columns.Add("Email");

                foreach (var emp in staffList)
                {
                    // Hiển thị tiếng Việt; dialog Edit/Detail cần raw nên dịch ngược qua EmployeeText
                    dt.Rows.Add(
                        emp.EmployeeId,
                        emp.FullName,
                        EmployeeText.RoleVi(emp.Role),
                        EmployeeText.StatusVi(emp.Status),
                        emp.PhoneNumber,
                        emp.AuthUid,
                        emp.Email
                    );
                }

                dgvStaff.DataSource = dt;

                // Bảo hiểm: nếu VS round-trip đổi Name cột thành "colStaff…" thì mọi
                // Columns["Mã NV"]/Cells["…"] sẽ null → crash. Đồng bộ lại Name == DataPropertyName.
                GridColumnGuard.SyncColumnNames(dgvStaff);

                // Ẩn cột không cần hiển thị
                foreach (string col in new[] { "AuthUid", "Số điện thoại", "Email" })
                    if (dgvStaff.Columns.Contains(col))
                        dgvStaff.Columns[col].Visible = false;

                dgvStaff.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvStaff.Columns["Mã NV"].FillWeight     = 15;
                dgvStaff.Columns["Họ và Tên"].FillWeight = 40;
                dgvStaff.Columns["Vị Trí"].FillWeight    = 25;
                dgvStaff.Columns["Trạng Thái"].FillWeight = 20;

                dgvStaff.Columns["Mã NV"].DefaultCellStyle.Alignment      = DataGridViewContentAlignment.MiddleCenter;
                dgvStaff.Columns["Vị Trí"].DefaultCellStyle.Alignment     = DataGridViewContentAlignment.MiddleCenter;
                dgvStaff.Columns["Trạng Thái"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                foreach (DataGridViewRow row in dgvStaff.Rows)
                {
                    string status = row.Cells["Trạng Thái"].Value?.ToString() ?? "";
                    row.Cells["Trạng Thái"].Style.ForeColor =
                        status == "Đang làm" ? System.Drawing.Color.MediumSeaGreen : System.Drawing.Color.Orange;
                }

                // Cập nhật stat card
                var activeList = staffList.Where(emp => emp.Status == "active").ToList();
                var leaveList  = staffList.Where(emp => emp.Status != "active").ToList();
                lblTotalStaffValue.Text = $"{staffList.Count} người";
                lblPresentValue.Text    = $"{activeList.Count} người";
                lblLeaveValue.Text      = $"{leaveList.Count} người";
            }
            catch (Exception ex)
            {
                MsgBox.Show(MsgBox.OwnerWindow(this), $"Lỗi tải dữ liệu: {ex.Message}", "Lỗi hệ thống", MsgBox.MessageBoxType.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        // Tải danh sách đơn xin nghỉ
        private void LoadLeaveRequests()
        {
            var dt = new DataTable();
            dt.Columns.Add("Nhân viên");
            dt.Columns.Add("Ngày nghỉ");
            dt.Columns.Add("Lý do");

            // Dữ liệu mẫu — thay bằng API call thực tế khi có endpoint
            dt.Rows.Add("NV03 Lê Văn C",   "20/05/2026", "Việc gia đình");
            dt.Rows.Add("NV07 Trần Thị B",  "21/05/2026", "Khám bệnh");

            dgvLeaveReq.DataSource = dt;
            GridColumnGuard.SyncColumnNames(dgvLeaveReq);
            dgvLeaveReq.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvLeaveReq.Columns["Nhân viên"].FillWeight = 35;
            dgvLeaveReq.Columns["Ngày nghỉ"].FillWeight = 30;
            dgvLeaveReq.Columns["Lý do"].FillWeight     = 35;
        }

        // Duyệt đơn xin nghỉ
        private void BtnApproveLeave_Click(object? sender, EventArgs e)
        {
            if (dgvLeaveReq.CurrentRow == null || dgvLeaveReq.CurrentRow.Index < 0)
            {
                MsgBox.Show(MsgBox.OwnerWindow(this), "Vui lòng chọn một đơn xin nghỉ để duyệt!", "Thông báo", MsgBox.MessageBoxType.Warning);
                return;
            }

            string tenNV    = dgvLeaveReq.CurrentRow.Cells["Nhân viên"].Value?.ToString() ?? "";
            string ngayNghi = dgvLeaveReq.CurrentRow.Cells["Ngày nghỉ"].Value?.ToString() ?? "";

            MsgBox.Show(
                MsgBox.OwnerWindow(this),
                $"Đã DUYỆT đơn xin nghỉ của [{tenNV}] ngày {ngayNghi}.\nDữ liệu đã cập nhật vào tính lương cuối tháng.",
                "Duyệt Nghỉ Phép",
                MsgBox.MessageBoxType.Success);

            // Xóa dòng đã duyệt khỏi grid
            if (dgvLeaveReq.DataSource is DataTable dt)
            {
                dt.Rows.RemoveAt(dgvLeaveReq.CurrentRow.Index);
            }

            if (dgvLeaveReq.Rows.Count == 0)
                btnApproveLeave.Enabled = false;
        }

        // Thêm nhân viên mới
        private async void btnAddStaff_Click(object sender, EventArgs e)
        {
            AddEmployee frmAdd = new();
            if (frmAdd.ShowDialog(MsgBox.OwnerWindow(this)) == DialogResult.OK)
            {
                await LoadRealData();
                MsgBox.Show(MsgBox.OwnerWindow(this), "Danh sách nhân viên đã được cập nhật!", "Thông báo", MsgBox.MessageBoxType.Success);
            }
        }

        // Sửa nhân viên
        private void btnEditStaff_Click(object sender, EventArgs e)
        {
            if (dgvStaff.CurrentRow == null || dgvStaff.CurrentRow.Index < 0)
            {
                MsgBox.Show(MsgBox.OwnerWindow(this), "Vui lòng chọn một nhân viên từ danh sách để chỉnh sửa!", "Thông báo", MsgBox.MessageBoxType.Warning);
                return;
            }

            EmployeeDTO empToEdit = BuildEmployeeFromRow(dgvStaff.CurrentRow);

            EditEmployee frmEdit = new(empToEdit);
            if (frmEdit.ShowDialog(MsgBox.OwnerWindow(this)) == DialogResult.OK)
                _ = LoadRealData();
        }

        // Double-click xem chi tiết
        private async void DgvStaff_CellDoubleClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            EmployeeDTO emp = BuildEmployeeFromRow(dgvStaff.Rows[e.RowIndex]);

            using EmployeeDetail dlg = new(emp);
            if (dlg.ShowDialog(MsgBox.OwnerWindow(this)) == DialogResult.OK)
                await LoadRealData();
        }

        // Grid hiển thị Vị Trí/Trạng Thái tiếng Việt -> dịch ngược về raw
        // vì EditEmployee/EmployeeDetail bind theo "manager"/"active"…
        private static EmployeeDTO BuildEmployeeFromRow(DataGridViewRow row) => new()
        {
            EmployeeId  = row.Cells["Mã NV"].Value?.ToString(),
            FullName    = row.Cells["Họ và Tên"].Value?.ToString(),
            Role        = EmployeeText.RoleRaw(row.Cells["Vị Trí"].Value?.ToString()),
            Status      = EmployeeText.StatusRaw(row.Cells["Trạng Thái"].Value?.ToString()),
            PhoneNumber = row.Cells["Số điện thoại"].Value?.ToString(),
            AuthUid     = row.Cells["AuthUid"].Value?.ToString(),
            Email       = row.Cells["Email"].Value?.ToString(),
        };

        // Bộ lọc nhân viên
        private void InitFilterControls()
        {
            cbRole.Items.Clear();
            foreach (var r in new[] { "-- Vị trí --", "Quản lý", "Pha chế", "Nhân viên Order", "Bảo vệ" })
                cbRole.Items.Add(r);
            cbRole.SelectedIndex = 0;

            cbStatus.Items.Clear();
            foreach (var s in new[] { "-- Trạng thái --", "Đang làm", "Xin nghỉ" })
                cbStatus.Items.Add(s);
            cbStatus.SelectedIndex = 0;

            txtSearch.TextChanged        += (s, e) => ApplyStaffFilter();
            cbRole.SelectedIndexChanged  += (s, e) => ApplyStaffFilter();
            cbStatus.SelectedIndexChanged += (s, e) => ApplyStaffFilter();
        }

        private void ApplyStaffFilter()
        {
            if (dgvStaff.DataSource is not DataTable dt) return;

            List<string> parts = new();

            // Từ khóa quét mọi trường (tên, mã, vị trí, trạng thái, SĐT, email) — trừ cột kỹ thuật
            string kwFilter = SearchFilter.AllColumnsFilter(dt, txtSearch.Text, "AuthUid");
            if (!string.IsNullOrEmpty(kwFilter))
                parts.Add(kwFilter);

            if (cbRole.SelectedIndex > 0)
                parts.Add($"[Vị Trí] = '{cbRole.SelectedItem}'");

            if (cbStatus.SelectedIndex > 0)
                parts.Add($"[Trạng Thái] = '{cbStatus.SelectedItem}'");

            try { dt.DefaultView.RowFilter = string.Join(" AND ", parts); }
            catch (Exception ex) { Console.WriteLine("Lỗi bộ lọc: " + ex.Message); }
        }

        private void btnClearFilter_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            cbRole.SelectedIndex   = 0;
            cbStatus.SelectedIndex = 0;

            if (dgvStaff.DataSource is DataTable dt)
                dt.DefaultView.RowFilter = string.Empty;
        }
    }
}
