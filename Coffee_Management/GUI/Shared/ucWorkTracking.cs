using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace GUI
{
    public partial class ucWorkTracking : UserControl
    {
        public ucWorkTracking()
        {
            InitializeComponent();
            this.Load += (s, e) => LoadAttendanceHistory();
            btnReport.Click += btnReport_Click;
            dtpFilterMonth.ValueChanged += (s, e) => LoadAttendanceHistory();
        }

        private void LoadAttendanceHistory()
        {
            DataTable dt = new();
            dt.Columns.Add("Ngày");
            dt.Columns.Add("Thứ");
            dt.Columns.Add("Check-in");
            dt.Columns.Add("Check-out");
            dt.Columns.Add("Số giờ", typeof(double));
            dt.Columns.Add("Trạng thái");
            dt.Columns.Add("Ghi chú");

            dt.Rows.Add("02/05/2026", "T7", "07:55", "16:05", 8.2, "Đủ giờ", "");
            dt.Rows.Add("01/05/2026", "T6", "08:10", "16:00", 7.8, "Đủ giờ", "");
            dt.Rows.Add("30/04/2026", "T5", "07:50", "12:00", 4.2, "Nửa ca", "Xin về sớm");
            dt.Rows.Add("29/04/2026", "T4", "08:00", "16:15", 8.3, "Đủ giờ", "");
            dt.Rows.Add("28/04/2026", "T3", "08:35", "16:00", 7.4, "Đi muộn", "Muộn 35 phút");
            dt.Rows.Add("27/04/2026", "T2", "--", "--", 0.0, "Nghỉ phép", "Đã duyệt");
            dt.Rows.Add("26/04/2026", "CN", "07:45", "16:10", 8.4, "Đủ giờ", "Tăng ca CN");
            dt.Rows.Add("25/04/2026", "T7", "07:50", "16:00", 8.2, "Đủ giờ", "");
            dt.Rows.Add("24/04/2026", "T6", "08:20", "16:05", 7.8, "Đi muộn", "Muộn 20 phút");
            dt.Rows.Add("23/04/2026", "T5", "07:55", "16:00", 8.1, "Đủ giờ", "");
            dt.Rows.Add("22/04/2026", "T4", "08:00", "16:10", 8.2, "Đủ giờ", "");
            dt.Rows.Add("21/04/2026", "T3", "07:50", "16:00", 8.2, "Đủ giờ", "");
            dt.Rows.Add("20/04/2026", "T2", "07:55", "16:05", 8.2, "Đủ giờ", "");

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

            // Color by status
            int totalShifts = 0, lateCount = 0, absentCount = 0;
            double totalHours = 0;

            foreach (DataGridViewRow row in dgvWorkTracking.Rows)
            {
                string status = row.Cells["Trạng thái"].Value?.ToString() ?? "";
                double hours = row.Cells["Số giờ"].Value is double h ? h : 0;

                switch (status)
                {
                    case "Đủ giờ":
                        row.DefaultCellStyle.ForeColor = Color.MediumSeaGreen;
                        totalShifts++;
                        totalHours += hours;
                        break;
                    case "Nửa ca":
                        row.DefaultCellStyle.ForeColor = Color.Orange;
                        totalShifts++;
                        totalHours += hours;
                        break;
                    case "Đi muộn":
                        row.DefaultCellStyle.ForeColor = Color.IndianRed;
                        row.Cells["Ghi chú"].Style.ForeColor = Color.IndianRed;
                        totalShifts++;
                        lateCount++;
                        totalHours += hours;
                        break;
                    case "Nghỉ phép":
                        row.DefaultCellStyle.ForeColor = Color.SteelBlue;
                        absentCount++;
                        break;
                }
            }

            // Update summary
            lblTotalShiftsValue.Text = $"{totalShifts} ca";
            lblTotalHoursValue.Text = $"{totalHours:F0}h";
            lblLateValue.Text = $"{lateCount} lần";
            lblAbsentValue.Text = $"{absentCount} ngày";

            lblLateValue.ForeColor = lateCount > 0 ? Color.IndianRed : Color.MediumSeaGreen;
        }

        private void btnReport_Click(object? sender, EventArgs e)
        {
            string report =
                $"BÁO CÁO CHẤM CÔNG\n" +
                $"Tháng: {dtpFilterMonth.Value:MM/yyyy}\n" +
                $"──────────────────\n" +
                $"• Tổng ca: {lblTotalShiftsValue.Text}\n" +
                $"• Tổng giờ: {lblTotalHoursValue.Text}\n" +
                $"• Đi muộn: {lblLateValue.Text}\n" +
                $"• Nghỉ phép: {lblAbsentValue.Text}\n" +
                $"──────────────────\n" +
                $"Gửi báo cáo này cho quản lý qua Chat?";

            var result = MessageBox.Show(report, "Báo cáo chấm công",
                MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (result == DialogResult.Yes)
            {
                MsgBox.Show(
                    "Đã gửi báo cáo chấm công cho quản lý!\nQuản lý sẽ duyệt và phản hồi qua Chat nội bộ.",
                    "Thành công", MsgBox.MessageBoxType.Success);
            }
        }
    }
}
