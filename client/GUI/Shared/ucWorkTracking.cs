using BUS;
using DTO;
using System;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class ucWorkTracking : UserControl
    {
        public ucWorkTracking()
        {
            InitializeComponent();
            GridColumnGuard.SyncColumnNames(dgvWorkTracking);
            DgvRefresh.Attach(dgvWorkTracking, LoadAttendanceHistoryAsync);
            this.Load += (s, e) => _ = LoadAttendanceHistoryAsync();
            dtpFilterMonth.ValueChanged += (s, e) => _ = LoadAttendanceHistoryAsync();

            dgvWorkTracking.CellDoubleClick += (s, e) =>
            {
                if (e.RowIndex < 0) return;
                RecordDetail.FromRow(dgvWorkTracking.Rows[e.RowIndex], "Chi tiết ngày công")
                            .ShowDialog(MsgBox.OwnerWindow(this));
            };
        }

        private static string DowVi(DateTime d) => d.DayOfWeek switch
        {
            DayOfWeek.Monday => "T2",
            DayOfWeek.Tuesday => "T3",
            DayOfWeek.Wednesday => "T4",
            DayOfWeek.Thursday => "T5",
            DayOfWeek.Friday => "T6",
            DayOfWeek.Saturday => "T7",
            _ => "CN"
        };
        private static string StatusVi(string? s) => s switch
        {
            "du_gio" => "Đủ giờ",
            "di_muon" => "Đi muộn",
            "nghi_phep" => "Nghỉ phép",
            "nua_ca" => "Nửa ca",
            _ => s ?? ""
        };
        private static string HourMin(long ms) => ms > 0
            ? DateTimeOffset.FromUnixTimeMilliseconds(ms).LocalDateTime.ToString("HH:mm") : "--";

        private async Task LoadAttendanceHistoryAsync()
        {
            DataTable dt = new();
            dt.Columns.Add("Ngày");
            dt.Columns.Add("Thứ");
            dt.Columns.Add("Check-in");
            dt.Columns.Add("Check-out");
            dt.Columns.Add("Số giờ", typeof(double));
            dt.Columns.Add("Trạng thái");
            dt.Columns.Add("Ghi chú");

            string myId = GlobalSession.CurrentUser?.EmployeeId ?? "";
            int month = dtpFilterMonth.Value.Month, year = dtpFilterMonth.Value.Year;
            try
            {
                var all = await AttendanceBUS.GetAll();
                foreach (var cc in all.Values
                    .Where(a => a.EmployeeId == myId)
                    .OrderByDescending(a => a.Date))
                {
                    if (!DateTime.TryParse(cc.Date, out DateTime d)) continue;
                    if (d.Month != month || d.Year != year) continue;
                    dt.Rows.Add(d.ToString("dd/MM/yyyy"), DowVi(d), HourMin(cc.CheckIn), HourMin(cc.CheckOut),
                                cc.WorkHours, StatusVi(cc.Status), cc.Note);
                }
            }
            catch { /* offline */ }

            dgvWorkTracking.AutoGenerateColumns = true;
            dgvWorkTracking.Columns.Clear();
            dgvWorkTracking.DataSource = dt;
            dgvWorkTracking.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvWorkTracking.Columns["Ngày"].FillWeight = 14;
            dgvWorkTracking.Columns["Thứ"].FillWeight = 8;
            dgvWorkTracking.Columns["Check-in"].FillWeight = 10;
            dgvWorkTracking.Columns["Check-out"].FillWeight = 10;
            dgvWorkTracking.Columns["Số giờ"].FillWeight = 10;
            dgvWorkTracking.Columns["Trạng thái"].FillWeight = 14;
            dgvWorkTracking.Columns["Ghi chú"].FillWeight = 20;

            dgvWorkTracking.Columns["Số giờ"].DefaultCellStyle.Format = "F1";
            dgvWorkTracking.Columns["Số giờ"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvWorkTracking.Columns["Thứ"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            int totalShifts = 0, lateCount = 0, absentCount = 0;
            double totalHours = 0;
            foreach (DataGridViewRow row in dgvWorkTracking.Rows)
            {
                string status = row.Cells["Trạng thái"].Value?.ToString() ?? "";
                double hours = row.Cells["Số giờ"].Value is double h ? h : 0;
                switch (status)
                {
                    case "Đủ giờ": row.DefaultCellStyle.ForeColor = Color.MediumSeaGreen; totalShifts++; totalHours += hours; break;
                    case "Nửa ca": row.DefaultCellStyle.ForeColor = Color.Orange; totalShifts++; totalHours += hours; break;
                    case "Đi muộn":
                        row.DefaultCellStyle.ForeColor = Color.IndianRed;
                        row.Cells["Ghi chú"].Style.ForeColor = Color.IndianRed;
                        totalShifts++; lateCount++; totalHours += hours; break;
                    case "Nghỉ phép": row.DefaultCellStyle.ForeColor = Color.SteelBlue; absentCount++; break;
                }
            }

            lblTotalShiftsValue.Text = $"{totalShifts} ca";
            lblTotalHoursValue.Text = $"{totalHours:F0}h";
            lblLateValue.Text = $"{lateCount} lần";
            lblAbsentValue.Text = $"{absentCount} ngày";
            lblLateValue.ForeColor = lateCount > 0 ? Color.IndianRed : Color.MediumSeaGreen;
        }

        private void btnReport_Click(object? sender, EventArgs e)
        {
            string report =
                "BÁO CÁO CHẤM CÔNG\n" +
                $"Tháng: {dtpFilterMonth.Value:MM/yyyy}\n" +
                "──────────────────\n" +
                $"• Tổng ca: {lblTotalShiftsValue.Text}\n" +
                $"• Tổng giờ: {lblTotalHoursValue.Text}\n" +
                $"• Đi muộn: {lblLateValue.Text}\n" +
                $"• Nghỉ phép: {lblAbsentValue.Text}\n" +
                "──────────────────\n" +
                "Gửi báo cáo này cho quản lý qua Chat?";

            if (MsgBox.Show(MsgBox.OwnerWindow(this), report, "Báo cáo chấm công", MsgBox.MessageBoxType.Warning) == DialogResult.Yes)
                MsgBox.Show(MsgBox.OwnerWindow(this), "Đã gửi báo cáo chấm công cho quản lý!", "Thành công", MsgBox.MessageBoxType.Success);
        }
    }
}
