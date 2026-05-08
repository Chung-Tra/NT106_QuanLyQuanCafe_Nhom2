using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace GUI
{
    /// <summary>
    /// Trang xem thất thoát / hao phí của quán cho Manager.
    /// Hiển thị theo ngày / tháng / năm, bảng chi tiết từng khoản.
    /// </summary>
    public class ucLoss_Manager : UserControl
    {
        private string _mode = "month";

        private Button btnDay = null!;
        private Button btnMonth = null!;
        private Button btnYear = null!;
        private Panel pnlChart = null!;
        private DataGridView dgvLossDetail = null!;
        private Label lblTotalLoss = null!;
        private Label lblTitle = null!;
        private Button btnReport = null!;

        public ucLoss_Manager()
        {
            BackColor = Color.FromArgb(37, 37, 38);
            ForeColor = Color.White;
            Font = new Font("Segoe UI", 9F);
            Dock = DockStyle.Fill;

            BuildUI();
            LoadData();
        }

        private void BuildUI()
        {
            int pad = 16;

            lblTitle = new Label
            {
                Text = "Thất thoát & Hao phí",
                Location = new Point(pad, 12),
                Font = new Font("Segoe UI", 13F, FontStyle.Bold),
                ForeColor = Color.White,
                AutoSize = true
            };

            // Period buttons
            btnDay = MakePeriodBtn("Ngày", pad, 46, true);
            btnMonth = MakePeriodBtn("Tháng", pad + 78, 46, false);
            btnYear = MakePeriodBtn("Năm", pad + 156, 46, false);

            btnDay.Click   += (s, e) => { _mode = "day";   HighlightBtn(btnDay, btnMonth, btnYear); LoadData(); };
            btnMonth.Click += (s, e) => { _mode = "month"; HighlightBtn(btnMonth, btnDay, btnYear); LoadData(); };
            btnYear.Click  += (s, e) => { _mode = "year";  HighlightBtn(btnYear, btnDay, btnMonth); LoadData(); };

            // Summary cards
            lblTotalLoss = new Label
            {
                Text = "Tổng thất thoát: 0 đ",
                Location = new Point(pad + 260, 52),
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                ForeColor = Color.IndianRed,
                AutoSize = true
            };

            // Chart area
            pnlChart = new Panel
            {
                Location = new Point(pad, 86),
                Size = new Size(760, 170),
                BackColor = Color.FromArgb(45, 45, 48)
            };
            pnlChart.Paint += PnlChart_Paint;

            // Detail grid
            var lblDetail = new Label
            {
                Text = "Chi tiết từng khoản thất thoát:",
                Location = new Point(pad, 268),
                ForeColor = Color.Silver,
                AutoSize = true
            };

            dgvLossDetail = new DataGridView
            {
                Location = new Point(pad, 288),
                Size = new Size(760, 190),
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
                    SelectionBackColor = Color.DimGray
                },
                ReadOnly = true,
                AllowUserToAddRows = false,
                RowHeadersVisible = false,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect
            };

            btnReport = new Button
            {
                Text = "Báo cáo sự cố",
                Location = new Point(pad + 640, 488),
                Size = new Size(138, 30),
                BackColor = Color.FromArgb(160, 80, 80),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btnReport.Click += (s, e) =>
            {
                var dlg = new ReportDialog("Thất thoát hao phí");
                var dr = dlg.ShowDialog(MsgBox.OwnerWindow(this));
                if (dr == DialogResult.OK || dr == DialogResult.Yes)
                    MsgBox.Show(MsgBox.OwnerWindow(this), "Đã gửi báo cáo!", "Thành công", MsgBox.MessageBoxType.Success);
            };

            Controls.AddRange([
                lblTitle, btnDay, btnMonth, btnYear, lblTotalLoss,
                pnlChart, lblDetail, dgvLossDetail, btnReport
            ]);
        }

        private Button MakePeriodBtn(string text, int x, int y, bool active) => new()
        {
            Text = text,
            Location = new Point(x, y),
            Size = new Size(72, 26),
            BackColor = active ? Color.SteelBlue : Color.FromArgb(60, 60, 65),
            ForeColor = Color.White,
            FlatStyle = FlatStyle.Flat,
            Cursor = Cursors.Hand
        };

        private void HighlightBtn(Button active, Button b1, Button b2)
        {
            active.BackColor = Color.SteelBlue;
            b1.BackColor = Color.FromArgb(60, 60, 65);
            b2.BackColor = Color.FromArgb(60, 60, 65);
        }

        private void LoadData()
        {
            var dt = new DataTable();
            dt.Columns.Add("Khoản mục");
            dt.Columns.Add("Số lượng");
            dt.Columns.Add("Giá trị", typeof(decimal));
            dt.Columns.Add("Nguyên nhân");
            dt.Columns.Add("Người phát hiện");

            switch (_mode)
            {
                case "day":
                    lblTotalLoss.Text = "Tổng thất thoát: 320,000 đ";
                    dt.Rows.Add("Nguyên liệu hỏng",    "0.5 kg sữa",   80000m,  "Hết hạn",         "Kho A");
                    dt.Rows.Add("Chênh lệch quỹ",       "—",            120000m, "Kiểm quỹ cuối ca","Thu ngân");
                    dt.Rows.Add("Dụng cụ bị vỡ",        "1 ly thủy tinh", 45000m,"Nhân viên đánh vỡ","Quầy bar");
                    dt.Rows.Add("Hao hụt nguyên liệu",  "100g bột cacao",75000m, "Pha sai công thức","Pha chế");
                    break;
                case "year":
                    lblTotalLoss.Text = "Tổng thất thoát: 28,500,000 đ";
                    dt.Rows.Add("Nguyên liệu hết hạn",  "85 kg",        12500000m,"Quản lý kho kém","Kho");
                    dt.Rows.Add("Dụng cụ hỏng / vỡ",   "42 món",       4200000m, "Sử dụng",        "Barista");
                    dt.Rows.Add("Chênh lệch tiền quỹ",  "—",            6800000m, "Kiểm quỹ",       "Thu ngân");
                    dt.Rows.Add("Pha sai công thức",    "~350 ly",      5000000m, "Thiếu đào tạo",  "Barista");
                    break;
                default: // month
                    lblTotalLoss.Text = "Tổng thất thoát: 2,500,000 đ";
                    dt.Rows.Add("Nguyên liệu hỏng",    "3.2 kg",       800000m,  "Hết hạn",         "Kho A");
                    dt.Rows.Add("Chênh lệch quỹ",       "—",            700000m,  "Kiểm quỹ cuối ca","Thu ngân");
                    dt.Rows.Add("Dụng cụ bị vỡ",        "5 ly + 2 đĩa", 450000m, "Nhân viên",       "Quầy bar");
                    dt.Rows.Add("Hao hụt nguyên liệu",  "1.2 kg bột",   350000m, "Pha sai CT",      "Pha chế");
                    dt.Rows.Add("Mất tài sản nhỏ",      "3 muỗng cafe", 200000m,  "Không rõ",        "—");
                    break;
            }

            dgvLossDetail.DataSource = dt;
            dgvLossDetail.Columns["Giá trị"].DefaultCellStyle.Format = "N0";
            dgvLossDetail.Columns["Giá trị"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            foreach (DataGridViewRow row in dgvLossDetail.Rows)
                row.DefaultCellStyle.ForeColor = Color.IndianRed;

            pnlChart.Invalidate();
        }

        private void PnlChart_Paint(object? sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            g.Clear(Color.FromArgb(45, 45, 48));

            int[] values = _mode switch
            {
                "day"  => new[] { 320, 280, 410, 190, 350, 320, 300 },
                "year" => new[] { 18500, 22000, 25000, 28500 },
                _      => new[] { 1800, 2100, 2800, 2200, 2500, 2300 }
            };
            string[] labels = _mode switch
            {
                "day"  => new[] { "T2", "T3", "T4", "T5", "T6", "T7", "CN" },
                "year" => new[] { "2023", "2024", "2025", "2026" },
                _      => new[] { "T10", "T11", "T12", "T1", "T2", "T3" }
            };
            string title = _mode switch
            {
                "day"  => "Thất thoát 7 ngày gần nhất (nghìn đ)",
                "year" => "Thất thoát theo năm (nghìn đ)",
                _      => "Thất thoát 6 tháng gần nhất (nghìn đ)"
            };

            int maxVal = 0;
            foreach (var v in values) maxVal = Math.Max(maxVal, v);
            maxVal = (int)(maxVal * 1.2);

            int chartH = 120, chartY = 28, barW = 34, gap = 18;
            int totalW = values.Length * barW + (values.Length - 1) * gap;
            int startX = (pnlChart.Width - totalW) / 2;

            using var fontS  = new Font("Segoe UI", 7.5F);
            using var titleF = new Font("Segoe UI", 8F, FontStyle.Italic);
            using var red    = new SolidBrush(Color.IndianRed);
            using var gray   = new SolidBrush(Color.Gray);
            using var white  = new SolidBrush(Color.White);
            using var line   = new Pen(Color.FromArgb(60, 60, 65), 1);

            g.DrawString(title, titleF, gray, 6, 6);
            for (int i = 0; i <= 4; i++)
            {
                int y = chartY + (int)(chartH * i / 4.0);
                g.DrawLine(line, startX - 5, y, startX + totalW, y);
            }

            for (int i = 0; i < values.Length; i++)
            {
                int x = startX + i * (barW + gap);
                int h = maxVal > 0 ? (int)((double)values[i] / maxVal * chartH) : 0;
                g.FillRectangle(red, x, chartY + chartH - h, barW, h);
                g.DrawString(labels[i], fontS, gray, x + 8, chartY + chartH + 4);
            }
        }
    }
}
