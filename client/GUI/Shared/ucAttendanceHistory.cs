using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace GUI
{
    /// <summary>
    /// Xem lịch sử chấm công (read-only).
    /// Nếu phát hiện sai sót → nút "Báo cáo" mở ReportDialog + chat Manager.
    /// </summary>
    public class ucAttendanceHistory : UserControl
    {
        private ComboBox cboEmployee = null!;
        private DateTimePicker dtpFrom = null!;
        private DateTimePicker dtpTo = null!;
        private Button btnFilter = null!;
        private DataGridView dgvAttendance = null!;
        private Label lblSummary = null!;
        private Label lblAbsent = null!;
        private Label lblLate = null!;
        private Button btnReport = null!;
        private Label lblTitle = null!;

        public ucAttendanceHistory()
        {
            BackColor = Color.FromArgb(37, 37, 38);
            ForeColor = Color.White;
            Font = new Font("Segoe UI", 9F);
            Dock = DockStyle.Fill;

            BuildUI();
            LoadDummyData();
        }

        private void BuildUI()
        {
            int pad = 16;

            lblTitle = new Label
            {
                Text = "Lịch sử chấm công",
                Location = new Point(pad, 12),
                Font = new Font("Segoe UI", 13F, FontStyle.Bold),
                ForeColor = Color.White,
                AutoSize = true
            };

            // Bộ lọc
            var lblEmp = new Label { Text = "Nhân viên:", Location = new Point(pad, 48), ForeColor = Color.Silver, AutoSize = true };
            cboEmployee = new ComboBox
            {
                Location = new Point(pad, 68),
                Width = 200,
                BackColor = Color.FromArgb(60, 60, 65),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            cboEmployee.Items.AddRange(["Tất cả", "NV001 - Nguyễn Văn An", "NV002 - Trần Thị Bích", "NV003 - Lê Hoàng Nam"]);
            cboEmployee.SelectedIndex = 0;

            var lblFrom = new Label { Text = "Từ ngày:", Location = new Point(pad + 220, 48), ForeColor = Color.Silver, AutoSize = true };
            dtpFrom = new DateTimePicker
            {
                Location = new Point(pad + 220, 68),
                Width = 140,
                Format = DateTimePickerFormat.Short,
                Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1),
                CalendarForeColor = Color.White
            };
            var lblTo = new Label { Text = "Đến ngày:", Location = new Point(pad + 375, 48), ForeColor = Color.Silver, AutoSize = true };
            dtpTo = new DateTimePicker
            {
                Location = new Point(pad + 375, 68),
                Width = 140,
                Format = DateTimePickerFormat.Short,
                Value = DateTime.Now,
                CalendarForeColor = Color.White
            };

            btnFilter = new Button
            {
                Text = "Lọc",
                Location = new Point(pad + 530, 66),
                Size = new Size(70, 26),
                BackColor = Color.SteelBlue,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };

            // Lưới dữ liệu
            dgvAttendance = new DataGridView
            {
                Location = new Point(pad, 108),
                Width = 740,
                Height = 300,
                BackgroundColor = Color.FromArgb(45, 45, 48),
                ForeColor = Color.White,
                ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle
                {
                    BackColor = Color.FromArgb(30, 30, 30),
                    ForeColor = Color.White,
                    Font = new Font("Segoe UI", 9F, FontStyle.Bold)
                },
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    BackColor = Color.FromArgb(45, 45, 48),
                    ForeColor = Color.White,
                    SelectionBackColor = Color.SteelBlue
                },
                ReadOnly = true,
                AllowUserToAddRows = false,
                RowHeadersVisible = false,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect
            };

            // Tổng kết
            lblSummary = new Label
            {
                Text = "Ngày công: 0",
                Location = new Point(pad, 420),
                ForeColor = Color.Silver,
                AutoSize = true
            };
            lblAbsent = new Label
            {
                Text = "Nghỉ: 0 ngày",
                Location = new Point(pad + 130, 420),
                ForeColor = Color.IndianRed,
                AutoSize = true
            };
            lblLate = new Label
            {
                Text = "Đi muộn: 0 lần",
                Location = new Point(pad + 230, 420),
                ForeColor = Color.Orange,
                AutoSize = true
            };

            btnReport = new Button
            {
                Text = "Báo cáo sai sót",
                Location = new Point(pad + 520, 416),
                Size = new Size(138, 30),
                BackColor = Color.FromArgb(160, 80, 80),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btnReport.Click += (s, e) =>
            {
                var dlg = new ReportDialog("Lịch sử chấm công");
                var result = dlg.ShowDialog(MsgBox.OwnerWindow(this));
                if (result == DialogResult.Yes)
                    MsgBox.Show(MsgBox.OwnerWindow(this), "Đã gửi báo cáo và mở chat với Manager!", "Thông báo", MsgBox.MessageBoxType.Success);
                else if (result == DialogResult.OK)
                    MsgBox.Show(MsgBox.OwnerWindow(this), "Đã gửi báo cáo tới Manager!", "Thông báo", MsgBox.MessageBoxType.Success);
            };

            btnFilter.Click += (s, e) => LoadDummyData();

            Controls.AddRange([
                lblTitle, lblEmp, cboEmployee,
                lblFrom, dtpFrom, lblTo, dtpTo, btnFilter,
                dgvAttendance, lblSummary, lblAbsent, lblLate, btnReport
            ]);
        }

        private void LoadDummyData()
        {
            var dt = new DataTable();
            dt.Columns.Add("Ngày");
            dt.Columns.Add("Nhân viên");
            dt.Columns.Add("Giờ vào");
            dt.Columns.Add("Giờ ra");
            dt.Columns.Add("Số giờ", typeof(double));
            dt.Columns.Add("Trạng thái");
            dt.Columns.Add("Ghi chú");

            dt.Rows.Add("01/05/2026", "NV001 - Nguyễn Văn An", "07:58", "17:02", 9.1, "Đúng giờ", "");
            dt.Rows.Add("01/05/2026", "NV002 - Trần Thị Bích", "08:35", "17:00", 8.4, "Đi muộn", "Muộn 35 phút");
            dt.Rows.Add("01/05/2026", "NV003 - Lê Hoàng Nam", "", "", 0, "Nghỉ phép", "Đã xin phép");
            dt.Rows.Add("02/05/2026", "NV001 - Nguyễn Văn An", "07:55", "18:10", 10.3, "Đúng giờ", "Tăng ca");
            dt.Rows.Add("02/05/2026", "NV002 - Trần Thị Bích", "08:00", "17:00", 9.0, "Đúng giờ", "");
            dt.Rows.Add("02/05/2026", "NV003 - Lê Hoàng Nam", "08:10", "17:00", 8.8, "Đúng giờ", "");
            dt.Rows.Add("03/05/2026", "NV001 - Nguyễn Văn An", "08:50", "17:00", 8.2, "Đi muộn", "Muộn 50 phút");
            dt.Rows.Add("03/05/2026", "NV002 - Trần Thị Bích", "", "", 0, "Nghỉ không phép", "");
            dt.Rows.Add("03/05/2026", "NV003 - Lê Hoàng Nam", "07:45", "17:30", 9.8, "Đúng giờ", "Đến sớm");

            dgvAttendance.DataSource = dt;

            foreach (DataGridViewRow row in dgvAttendance.Rows)
            {
                string status = row.Cells["Trạng thái"].Value?.ToString() ?? "";
                row.DefaultCellStyle.ForeColor = status switch
                {
                    "Nghỉ không phép" => Color.IndianRed,
                    "Đi muộn" => Color.Orange,
                    "Nghỉ phép" => Color.SkyBlue,
                    _ => Color.White
                };
            }

            int absent = 0, late = 0, present = 0;
            foreach (DataRow row in dt.Rows)
            {
                string st = row["Trạng thái"].ToString() ?? "";
                if (st.StartsWith("Nghỉ")) absent++;
                else if (st == "Đi muộn") { late++; present++; }
                else present++;
            }
            lblSummary.Text = $"Ngày công: {present}";
            lblAbsent.Text  = $"Nghỉ: {absent} ngày";
            lblLate.Text    = $"Đi muộn: {late} lần";
        }
    }
}
