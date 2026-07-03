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
    public partial class ucAttendanceHistory : UserControl
    {
        private bool _filterReady;
        private Dictionary<string, string> _empNames = new();

        public ucAttendanceHistory()
        {
            InitializeComponent();
            dgvAttendance.AutoGenerateColumns = false; // cột khai trong Designer; tắt auto-gen ở .cs cho an toàn round-trip
            GridColumnGuard.SyncColumnNames(dgvAttendance);

            // Double-click 1 dòng -> form chi tiết read-only đủ field
            dgvAttendance.CellDoubleClick += (s, e) =>
            {
                if (e.RowIndex < 0) return;
                RecordDetail.FromRow(dgvAttendance.Rows[e.RowIndex], "Chi tiết chấm công")
                            .ShowDialog(MsgBox.OwnerWindow(this));
            };

            DgvRefresh.Attach(dgvAttendance, () => _ = LoadDataAsync());
        }

        private async void ucAttendanceHistory_Load(object sender, EventArgs e) => await InitFilterAsync();
        private void btnFilter_Click(object sender, EventArgs e) => _ = LoadDataAsync();

        // Khởi tạo bộ lọc
        private async Task InitFilterAsync()
        {
            var user = GlobalSession.CurrentUser;
            bool isPrivileged = user?.Role?.ToLower() is "admin" or "manager";

            if (isPrivileged)
            {
                cboEmployee.Visible = true;
                lblEmployeeName.Visible = false;
                btnFilter.Visible = true;

                try
                {
                    var dsNhanVien = await Task.Run(InventoryImportBUS.GetEmployees);
                    _empNames = dsNhanVien.Where(nv => nv.EmployeeId != null)
                                          .ToDictionary(nv => nv.EmployeeId!, nv => nv.FullName ?? nv.EmployeeId!);

                    var comboData = dsNhanVien.Select(nv => new
                    {
                        Id = nv.EmployeeId,
                        Display = $"{nv.EmployeeId} - {nv.FullName}"
                    }).ToList();
                    comboData.Insert(0, new { Id = "ALL", Display = "Tất cả" });

                    cboEmployee.DataSource = comboData;
                    cboEmployee.DisplayMember = "Display";
                    cboEmployee.ValueMember = "Id";
                }
                catch (Exception ex)
                {
                    MsgBox.Show(MsgBox.OwnerWindow(this), "Lỗi tải nhân viên: " + ex.Message, "Lỗi", MsgBox.MessageBoxType.Error);
                }
            }
            else
            {
                cboEmployee.Visible = false;
                btnFilter.Visible = false;
                lblEmployeeName.Visible = true;

                string display = string.IsNullOrWhiteSpace(user?.FullName)
                    ? "Nhân viên"
                    : $"{user!.EmployeeId} - {user.FullName}";
                lblEmployeeName.Text = display;
                if (user?.EmployeeId != null) _empNames[user.EmployeeId] = user.FullName ?? user.EmployeeId;

                var singleUserList = new List<object> { new { Id = user?.EmployeeId ?? "", Display = display } };
                cboEmployee.DataSource = singleUserList;
                cboEmployee.DisplayMember = "Display";
                cboEmployee.ValueMember = "Id";
            }

            dtpFrom.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtpTo.Value = DateTime.Now;

            _filterReady = true;
            await LoadDataAsync();
        }

        private static string AttStatus(string? s) => s switch
        {
            "du_gio" => "Đủ giờ",
            "di_muon" => "Đi muộn",
            "nghi_phep" => "Nghỉ phép",
            "nua_ca" => "Nửa ca",
            _ => s ?? ""
        };

        private static string HourMin(long ms) => ms > 0
            ? DateTimeOffset.FromUnixTimeMilliseconds(ms).LocalDateTime.ToString("HH:mm")
            : "--";

        // Tải dữ liệu chấm công thật từ Firebase
        private async Task LoadDataAsync()
        {
            if (!_filterReady) return;
            if (dtpFrom.Value.Date > dtpTo.Value.Date)
            {
                MsgBox.Show(MsgBox.OwnerWindow(this), "Ngày bắt đầu phải trước ngày kết thúc!", "Thông báo", MsgBox.MessageBoxType.Warning);
                return;
            }

            DateTime tuNgay = dtpFrom.Value.Date;
            DateTime denNgay = dtpTo.Value.Date;
            string empId = cboEmployee.SelectedValue?.ToString() ?? "ALL";

            var dt = new DataTable();
            dt.Columns.Add("Nhân viên");
            dt.Columns.Add("Ngày");
            dt.Columns.Add("Giờ vào");
            dt.Columns.Add("Giờ ra");
            dt.Columns.Add("Số giờ");
            dt.Columns.Add("Trạng thái");
            dt.Columns.Add("Ghi chú");

            int shifts = 0, absent = 0, late = 0;
            try
            {
                var all = await AttendanceBUS.GetAll();
                foreach (var cc in all.Values
                    .Where(a => empId == "ALL" || a.EmployeeId == empId)
                    .OrderByDescending(a => a.Date))
                {
                    if (!DateTime.TryParse(cc.Date, out DateTime d)) continue;
                    if (d.Date < tuNgay || d.Date > denNgay) continue;

                    string name = (cc.EmployeeId != null && _empNames.TryGetValue(cc.EmployeeId, out var n))
                        ? $"{cc.EmployeeId} - {n}" : (cc.EmployeeId ?? "");
                    dt.Rows.Add(name, cc.Date, HourMin(cc.CheckIn), HourMin(cc.CheckOut),
                                cc.WorkHours.ToString("0.#"), AttStatus(cc.Status), cc.Note);

                    if (cc.Status == "nghi_phep") absent++;
                    else shifts++;
                    if (cc.Status == "di_muon") late++;
                }
            }
            catch { /* offline */ }

            dgvAttendance.DataSource = dt;

            lblShiftsValue.Text = shifts.ToString();
            lblAbsentValue.Text = absent.ToString();
            lblLateValue.Text = late.ToString();
        }

        private void cboEmployee_SelectedIndexChanged(object sender, EventArgs e) => _ = LoadDataAsync();
    }
}
