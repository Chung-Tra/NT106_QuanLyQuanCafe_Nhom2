using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace GUI
{
    /// <summary>
    /// Trang xem thất thoát / hao phí của quán cho Manager.
    /// Hiển thị theo ngày / tháng / năm, bảng chi tiết từng khoản.
    /// </summary>
    public partial class ucLoss_Manager : UserControl
    {
        private string _mode = "month";

        public ucLoss_Manager()
        {
            InitializeComponent();
            LoadData();
        }

        private void BtnDay_Click(object? sender, EventArgs e)
        {
            _mode = "day";
            HighlightBtn(btnDay, btnMonth, btnYear);
            LoadData();
        }

        private void BtnMonth_Click(object? sender, EventArgs e)
        {
            _mode = "month";
            HighlightBtn(btnMonth, btnDay, btnYear);
            LoadData();
        }

        private void BtnYear_Click(object? sender, EventArgs e)
        {
            _mode = "year";
            HighlightBtn(btnYear, btnDay, btnMonth);
            LoadData();
        }

        private void BtnReport_Click(object? sender, EventArgs e)
        {
            var dlg = new ReportIncident("Thất thoát hao phí");
            var dr = dlg.ShowDialog(MsgBox.OwnerWindow(this));
            if (dr == DialogResult.OK || dr == DialogResult.Yes)
                MsgBox.Show(MsgBox.OwnerWindow(this), "Đã gửi báo cáo!", "Thành công", MsgBox.MessageBoxType.Success);
        }

        private static void HighlightBtn(Guna2Button active, Guna2Button b1, Guna2Button b2)
        {
            active.FillColor = Color.FromArgb(31, 138, 154);
            active.HoverState.FillColor = Color.FromArgb(45, 158, 174);
            b1.FillColor = Color.FromArgb(45, 45, 48);
            b1.HoverState.FillColor = Color.FromArgb(60, 60, 65);
            b2.FillColor = Color.FromArgb(45, 45, 48);
            b2.HoverState.FillColor = Color.FromArgb(60, 60, 65);
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
                row.DefaultCellStyle.ForeColor = Color.FromArgb(220, 80, 80);

            pnlChart.Invalidate();
        }

        private void PnlChart_Paint(object? sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            g.Clear(Color.FromArgb(31, 31, 34));

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

            int chartH = 140, chartY = 36, barW = 46, gap = 24;
            int totalW = values.Length * barW + (values.Length - 1) * gap;
            int startX = (pnlChart.Width - totalW) / 2;

            using var fontS  = new Font("Segoe UI", 8F);
            using var titleF = new Font("Segoe UI", 9F, FontStyle.Italic);
            using var red    = new SolidBrush(Color.FromArgb(220, 80, 80));
            using var gray   = new SolidBrush(Color.FromArgb(160, 160, 166));
            using var line   = new Pen(Color.FromArgb(63, 63, 70), 1);

            g.DrawString(title, titleF, gray, 18, 12);
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
                g.DrawString(labels[i], fontS, gray, x + 12, chartY + chartH + 6);
            }
        }
    }
}
