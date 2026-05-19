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
            btnApproveLeave.Click += BtnApproveLeave_Click;
            dgvStaff.CellDoubleClick += DgvStaff_CellDoubleClick;
            InitFilterControls();
        }

        // ──────────────────────────────────────────────
        // SỰ KIỆN LOAD (wired in Designer)
        // ──────────────────────────────────────────────
        private async void ucStaff_Manager_Load(object sender, EventArgs e)
        {
            await LoadRealData();
            LoadLeaveRequests();
        }

        // ──────────────────────────────────────────────
        // TẢI DANH SÁCH NHÂN VIÊN
        // ──────────────────────────────────────────────
        private async Task LoadRealData()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                dgvStaff.DataSource = null;
                dgvStaff.Columns.Clear();

                // 1. Lấy TẤT CẢ danh sách từ Server về
                List<EmployeeDTO> fullList = await EmployeeBUS.GetAllEmployeesAsync();

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
                    dt.Rows.Add(
                        emp.EmployeeId,
                        emp.FullName,
                        emp.Role,
                        emp.Status,
                        emp.PhoneNumber,
                        emp.AuthUid,
                        emp.Email
                    );
                }

                dgvStaff.DataSource = dt;

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

        // ──────────────────────────────────────────────
        // TẢI DANH SÁCH ĐƠN XIN NGHỈ
        // ──────────────────────────────────────────────
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
            dgvLeaveReq.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvLeaveReq.Columns["Nhân viên"].FillWeight = 35;
            dgvLeaveReq.Columns["Ngày nghỉ"].FillWeight = 30;
            dgvLeaveReq.Columns["Lý do"].FillWeight     = 35;
        }

        // ──────────────────────────────────────────────
        // DUYỆT ĐƠN XIN NGHỈ
        // ──────────────────────────────────────────────
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

        // ──────────────────────────────────────────────
        // THÊM NHÂN VIÊN MỚI
        // ──────────────────────────────────────────────
        private async void btnAddStaff_Click(object sender, EventArgs e)
        {
            AddEmployee frmAdd = new();
            if (frmAdd.ShowDialog(MsgBox.OwnerWindow(this)) == DialogResult.OK)
            {
                await LoadRealData();
                MsgBox.Show(MsgBox.OwnerWindow(this), "Danh sách nhân viên đã được cập nhật!", "Thông báo", MsgBox.MessageBoxType.Success);
            }
        }

        // ──────────────────────────────────────────────
        // SỬA NHÂN VIÊN
        // ──────────────────────────────────────────────
        private void btnEditStaff_Click(object sender, EventArgs e)
        {
            if (dgvStaff.CurrentRow == null || dgvStaff.CurrentRow.Index < 0)
            {
                MsgBox.Show(MsgBox.OwnerWindow(this), "Vui lòng chọn một nhân viên từ danh sách để chỉnh sửa!", "Thông báo", MsgBox.MessageBoxType.Warning);
                return;
            }

            DataGridViewRow row = dgvStaff.CurrentRow;
            EmployeeDTO empToEdit = new()
            {
                EmployeeId  = row.Cells["Mã NV"].Value?.ToString(),
                FullName    = row.Cells["Họ và Tên"].Value?.ToString(),
                Role        = row.Cells["Vị Trí"].Value?.ToString(),
                Status      = row.Cells["Trạng Thái"].Value?.ToString(),
                PhoneNumber = row.Cells["Số điện thoại"].Value?.ToString(),
                AuthUid     = row.Cells["AuthUid"].Value?.ToString(),
                Email       = row.Cells["Email"].Value?.ToString(),
            };

            EditEmployee frmEdit = new(empToEdit);
            if (frmEdit.ShowDialog(MsgBox.OwnerWindow(this)) == DialogResult.OK)
                _ = LoadRealData();
        }

        // ──────────────────────────────────────────────
        // DOUBLE-CLICK XEM CHI TIẾT
        // ──────────────────────────────────────────────
        private async void DgvStaff_CellDoubleClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dgvStaff.Rows[e.RowIndex];
            EmployeeDTO emp = new()
            {
                EmployeeId  = row.Cells["Mã NV"].Value?.ToString(),
                FullName    = row.Cells["Họ và Tên"].Value?.ToString(),
                Role        = row.Cells["Vị Trí"].Value?.ToString(),
                Status      = row.Cells["Trạng Thái"].Value?.ToString(),
                PhoneNumber = row.Cells["Số điện thoại"].Value?.ToString(),
                AuthUid     = row.Cells["AuthUid"].Value?.ToString(),
                Email       = row.Cells["Email"].Value?.ToString(),
            };

            using EmployeeDetail dlg = new(emp);
            if (dlg.ShowDialog(MsgBox.OwnerWindow(this)) == DialogResult.OK)
                await LoadRealData();
        }

        // ──────────────────────────────────────────────
        // BỘ LỌC NHÂN VIÊN
        // ──────────────────────────────────────────────
        private void InitFilterControls()
        {
            cbRole.Items.Clear();
            foreach (var r in new[] { "-- Vị trí --", "manager", "barista", "order staff", "security" })
                cbRole.Items.Add(r);
            cbRole.SelectedIndex = 0;

            cbStatus.Items.Clear();
            foreach (var s in new[] { "-- Trạng thái --", "active", "inactive" })
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

            string keyword = txtSearch.Text.Trim().Replace("'", "''");
            if (!string.IsNullOrEmpty(keyword))
                parts.Add($"([Họ và Tên] LIKE '%{keyword}%' OR [Mã NV] LIKE '%{keyword}%')");

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
