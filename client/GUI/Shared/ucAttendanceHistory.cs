using DTO;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace GUI
{
    public partial class ucAttendanceHistory : UserControl
    {
        public ucAttendanceHistory()
        {
            InitializeComponent();
        }

        private void ucAttendanceHistory_Load(object sender, EventArgs e) => InitFilter();
        private void btnFilter_Click(object sender, EventArgs e)          => LoadData();

        // ──────────────────────────────────────────────
        // KHỞI TẠO BỘ LỌC
        // ──────────────────────────────────────────────
        private void InitFilter()
        {
            var user = GlobalSession.CurrentUser;
            bool isPrivileged = user?.Role?.ToLower() is "admin" or "manager";

            if (isPrivileged)
            {
                // Admin/Manager: hiện ComboBox, ẩn label tên
                cboEmployee.Visible     = true;
                lblEmployeeName.Visible = false;
                btnFilter.Visible       = true;

                cboEmployee.Items.Clear();
                cboEmployee.Items.Add("Tất cả");
                cboEmployee.Items.Add("NV001 - Nguyễn Văn An");
                cboEmployee.Items.Add("NV002 - Trần Thị Bích");
                cboEmployee.Items.Add("NV003 - Lê Hoàng Nam");
                cboEmployee.SelectedIndex = 0;
            }
            else
            {
                // Nhân viên: ẩn ComboBox, hiện label tên + ẩn nút lọc
                cboEmployee.Visible     = false;
                btnFilter.Visible       = false;
                lblEmployeeName.Visible = true;

                string display = string.IsNullOrWhiteSpace(user?.FullName)
                    ? "Nhân viên"
                    : $"{user!.EmployeeId} - {user.FullName}";

                lblEmployeeName.Text = display;

                cboEmployee.Items.Clear();
                cboEmployee.Items.Add(display);
                cboEmployee.SelectedIndex = 0;
            }

            dtpFrom.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtpTo.Value   = DateTime.Now;

            LoadData();
        }

        // ──────────────────────────────────────────────
        // TẢI DỮ LIỆU
        // ──────────────────────────────────────────────
        private void LoadData()
        {
            if (dtpFrom.Value.Date > dtpTo.Value.Date)
            {
                MsgBox.Show(MsgBox.OwnerWindow(this),
                    "Ngày bắt đầu phải trước ngày kết thúc!",
                    "Thông báo", MsgBox.MessageBoxType.Warning);
                return;
            }

            DataTable dt = new();
            dt.Columns.Add("Ngày");
            dt.Columns.Add("Thứ");
            dt.Columns.Add("Nhân viên");
            dt.Columns.Add("Check-in");
            dt.Columns.Add("Check-out");
            dt.Columns.Add("Số giờ", typeof(double));
            dt.Columns.Add("Trạng thái");
            dt.Columns.Add("Ghi chú");

            dt.Rows.Add("01/05/2026", "T6", "NV001 - Nguyễn Văn An", "07:58", "17:02",  9.1, "Đúng giờ",        "");
            dt.Rows.Add("01/05/2026", "T6", "NV002 - Trần Thị Bích",  "08:35", "17:00",  8.4, "Đi muộn",        "Muộn 35 phút");
            dt.Rows.Add("01/05/2026", "T6", "NV003 - Lê Hoàng Nam",   "",      "",        0.0, "Nghỉ phép",       "Đã xin phép");
            dt.Rows.Add("02/05/2026", "T7", "NV001 - Nguyễn Văn An", "07:55", "18:10",  10.3, "Đúng giờ",        "Tăng ca");
            dt.Rows.Add("02/05/2026", "T7", "NV002 - Trần Thị Bích",  "08:00", "17:00",   9.0, "Đúng giờ",       "");
            dt.Rows.Add("02/05/2026", "T7", "NV003 - Lê Hoàng Nam",   "08:10", "17:00",   8.8, "Đúng giờ",       "");
            dt.Rows.Add("03/05/2026", "CN", "NV001 - Nguyễn Văn An", "08:50", "17:00",   8.2, "Đi muộn",        "Muộn 50 phút");
            dt.Rows.Add("03/05/2026", "CN", "NV002 - Trần Thị Bích",  "",      "",         0.0, "Nghỉ không phép", "");
            dt.Rows.Add("03/05/2026", "CN", "NV003 - Lê Hoàng Nam",   "07:45", "17:30",   9.8, "Đúng giờ",       "Đến sớm");

            // Lọc nhân viên
            string filter = cboEmployee.SelectedItem?.ToString() ?? "Tất cả";
            if (filter != "Tất cả")
            {
                DataTable filtered = dt.Clone();
                foreach (DataRow row in dt.Rows)
                    if (row["Nhân viên"].ToString() == filter)
                        filtered.ImportRow(row);
                dt = filtered;
            }

            dgvAttendance.DataSource = dt;
            dgvAttendance.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            if (dgvAttendance.Columns.Count == 0) return;

            dgvAttendance.Columns["Ngày"].FillWeight        = 10;
            dgvAttendance.Columns["Thứ"].FillWeight          = 6;
            dgvAttendance.Columns["Nhân viên"].FillWeight   = 22;
            dgvAttendance.Columns["Check-in"].FillWeight    = 9;
            dgvAttendance.Columns["Check-out"].FillWeight   = 9;
            dgvAttendance.Columns["Số giờ"].FillWeight      = 8;
            dgvAttendance.Columns["Trạng thái"].FillWeight  = 14;
            dgvAttendance.Columns["Ghi chú"].FillWeight     = 18;

            dgvAttendance.Columns["Số giờ"].DefaultCellStyle.Format    = "F1";
            dgvAttendance.Columns["Số giờ"].DefaultCellStyle.Alignment    = DataGridViewContentAlignment.MiddleCenter;
            dgvAttendance.Columns["Thứ"].DefaultCellStyle.Alignment       = DataGridViewContentAlignment.MiddleCenter;
            dgvAttendance.Columns["Check-in"].DefaultCellStyle.Alignment  = DataGridViewContentAlignment.MiddleCenter;
            dgvAttendance.Columns["Check-out"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Tô màu + đếm thống kê
            int shifts = 0, leaveApproved = 0, leaveUnauthorized = 0, late = 0;

            foreach (DataGridViewRow row in dgvAttendance.Rows)
            {
                if (row.IsNewRow) continue; // bỏ qua hàng rỗng cuối DataGridView

                string status = row.Cells["Trạng thái"].Value?.ToString() ?? "";
                switch (status)
                {
                    case "Đúng giờ":
                        row.DefaultCellStyle.ForeColor = Color.FromArgb(34, 197, 94);
                        shifts++;
                        break;
                    case "Đi muộn":
                        row.DefaultCellStyle.ForeColor = Color.FromArgb(234, 179, 8);
                        row.Cells["Ghi chú"].Style.ForeColor = Color.FromArgb(234, 179, 8);
                        shifts++; 
                        late++;
                        break;
                    case "Nghỉ phép":
                        row.DefaultCellStyle.ForeColor = Color.FromArgb(56, 139, 204);
                        leaveApproved++; 
                        break;
                    case "Nghỉ không phép":
                        row.DefaultCellStyle.ForeColor = Color.FromArgb(239, 68, 68);
                        leaveUnauthorized++; 
                        break;
                }
            }

            int totalAbsent = leaveApproved + leaveUnauthorized;

            lblShiftsValue.Text = $"{shifts} ngày";
            lblAbsentValue.Text = $"{totalAbsent} ngày"; // tổng nghỉ (phép + không phép)
            lblLateValue.Text   = $"{late} lần";

            lblLateValue.ForeColor   = late             > 0 ? Color.FromArgb(239, 68, 68)  : Color.FromArgb(34, 197, 94);
            lblAbsentValue.ForeColor = leaveUnauthorized > 0 ? Color.FromArgb(239, 68, 68)  // có nghỉ không phép → đỏ
                                     : totalAbsent       > 0 ? Color.FromArgb(56, 139, 204) // chỉ nghỉ có phép → xanh
                                                             : Color.FromArgb(34, 197, 94);  // không nghỉ → xanh lá
        }

        // ──────────────────────────────────────────────
        // NÚT BÁO CÁO SAI SÓT
        // ──────────────────────────────────────────────
        private void BtnReport_Click(object? sender, EventArgs e)
        {
            string report =
                "BÁO CÁO CHẤM CÔNG\n"                                          +
                $"Từ: {dtpFrom.Value:dd/MM/yyyy}  →  Đến: {dtpTo.Value:dd/MM/yyyy}\n" +
                "──────────────────\n"                                          +
                $"• Ngày công : {lblShiftsValue.Text}\n"                        +
                $"• Nghỉ phép : {lblAbsentValue.Text}\n"                        +
                $"• Đi muộn  : {lblLateValue.Text}\n"                           +
                "──────────────────\n"                                          +
                "Gửi báo cáo này cho quản lý qua Chat?";

            var result = MsgBox.Show(
                MsgBox.OwnerWindow(this), report,
                "Báo cáo chấm công", MsgBox.MessageBoxType.Warning);

            if (result == DialogResult.Yes)
            {
                MsgBox.Show(
                    MsgBox.OwnerWindow(this),
                    "Đã gửi báo cáo chấm công cho quản lý!\nQuản lý sẽ duyệt và phản hồi qua Chat nội bộ.",
                    "Thành công", MsgBox.MessageBoxType.Success);
            }
        }
    }
}
