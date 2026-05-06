using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace GUI
{
    public partial class ucDashboard_Admin : UserControl
    {
        private string _chartMode = "day";   // day | month | year
        private string _fbMode = "month";    // month | quarter | year

        public ucDashboard_Admin()
        {
            InitializeComponent();
        }

        private void ucDashboard_Admin_Load(object sender, EventArgs e)
        {
            LoadSummary();
            LoadRevenueDetail();
            DrawRevenueChart();
            DrawFeedbackChart();
        }

        // =================== SUMMARY ===================
        private void LoadSummary()
        {
            lblRevenueValue.Text = "45,800,000 đ";
            lblProfitValue.Text = "18,200,000 đ";
            lblExpensesValue.Text = "25,100,000 đ";
            lblLossValue.Text = "2,500,000 đ";
        }

        // =================== REVENUE DETAIL GRID ===================
        private void LoadRevenueDetail()
        {
            DataTable dt = new();
            dt.Columns.Add("Khoản mục");
            dt.Columns.Add("Số tiền", typeof(decimal));
            dt.Columns.Add("Ghi chú");

            // Thu
            dt.Rows.Add("Bán đồ uống", 38500000m, "782 đơn");
            dt.Rows.Add("Bán bánh/snack", 5200000m, "156 đơn");
            dt.Rows.Add("Phí gửi xe", 2100000m, "1,400 lượt");

            // Chi
            dt.Rows.Add("Nguyên liệu", -15200000m, "12 nhà cung cấp");
            dt.Rows.Add("Lương nhân viên", -7800000m, "7 nhân viên");
            dt.Rows.Add("Điện nước", -1200000m, "");
            dt.Rows.Add("Thuê mặt bằng", -900000m, "");

            // Thất thoát
            dt.Rows.Add("Hao phí NL", -1800000m, "Đổ/hết hạn");
            dt.Rows.Add("Chênh lệch tiền", -700000m, "Kiểm quỹ");

            dgvRevenueDetail.DataSource = dt;
            dgvRevenueDetail.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvRevenueDetail.Columns["Khoản mục"].FillWeight = 30;
            dgvRevenueDetail.Columns["Số tiền"].FillWeight = 30;
            dgvRevenueDetail.Columns["Ghi chú"].FillWeight = 25;
            dgvRevenueDetail.Columns["Số tiền"].DefaultCellStyle.Format = "N0";
            dgvRevenueDetail.Columns["Số tiền"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            // Color positive/negative
            foreach (DataGridViewRow row in dgvRevenueDetail.Rows)
            {
                if (row.Cells["Số tiền"].Value is decimal val)
                {
                    if (val >= 0)
                        row.Cells["Số tiền"].Style.ForeColor = Color.MediumSeaGreen;
                    else
                        row.Cells["Số tiền"].Style.ForeColor = Color.IndianRed;
                }
            }
        }

        // =================== REVENUE CHART ===================
        private void btnDay_Click(object sender, EventArgs e)
        {
            _chartMode = "day";
            HighlightChartBtn(btnDay, btnMonth, btnYear);
            DrawRevenueChart();
        }
        private void btnMonth_Click(object sender, EventArgs e)
        {
            _chartMode = "month";
            HighlightChartBtn(btnMonth, btnDay, btnYear);
            DrawRevenueChart();
        }
        private void btnYear_Click(object sender, EventArgs e)
        {
            _chartMode = "year";
            HighlightChartBtn(btnYear, btnDay, btnMonth);
            DrawRevenueChart();
        }

        private void HighlightChartBtn(Button active, Button b1, Button b2)
        {
            active.BackColor = Color.SteelBlue;
            b1.BackColor = Color.FromArgb(60, 60, 65);
            b2.BackColor = Color.FromArgb(60, 60, 65);
        }

        private void DrawRevenueChart()
        {
            // Remove old handler then add fresh
            pnlChartArea.Paint -= PnlChartArea_Paint;
            pnlChartArea.Paint += PnlChartArea_Paint;
            pnlChartArea.Invalidate();
        }

        private void PnlChartArea_Paint(object? sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            g.Clear(Color.FromArgb(45, 45, 48));

            int[] revenue;
            int[] expenses;
            string[] labels;
            string title;

            switch (_chartMode)
            {
                case "month":
                    revenue = new[] { 38, 41, 45, 42, 48, 45 };
                    expenses = new[] { 22, 24, 27, 25, 28, 25 };
                    labels = new[] { "T10", "T11", "T12", "T1", "T2", "T3" };
                    title = "Doanh thu vs Chi phí (6 tháng gần nhất) - triệu đ";
                    break;
                case "year":
                    revenue = new[] { 380, 420, 510, 485 };
                    expenses = new[] { 230, 260, 300, 290 };
                    labels = new[] { "2023", "2024", "2025", "2026" };
                    title = "Doanh thu vs Chi phí (theo năm) - triệu đ";
                    break;
                default: // day
                    revenue = new[] { 5, 7, 6, 8, 9, 7, 10 };
                    expenses = new[] { 3, 4, 3, 5, 5, 4, 6 };
                    labels = new[] { "T2", "T3", "T4", "T5", "T6", "T7", "CN" };
                    title = "Doanh thu vs Chi phí (7 ngày) - triệu đ";
                    break;
            }

            int maxVal = 0;
            for (int i = 0; i < revenue.Length; i++)
                maxVal = Math.Max(maxVal, Math.Max(revenue[i], expenses[i]));
            maxVal = (int)(maxVal * 1.2);

            int chartH = 105;
            int chartY = 30;
            int barW = 18;
            int groupW = barW * 2 + 8;
            int totalW = revenue.Length * groupW + (revenue.Length - 1) * 15;
            int startX = (pnlChartArea.Width - totalW) / 2;

            using var fontS = new Font("Segoe UI", 7F);
            using var titleFont = new Font("Segoe UI", 7.5F, FontStyle.Italic);
            using var whiteBrush = new SolidBrush(Color.White);
            using var grayBrush = new SolidBrush(Color.Gray);
            using var greenBrush = new SolidBrush(Color.MediumSeaGreen);
            using var redBrush = new SolidBrush(Color.IndianRed);
            using var linePen = new Pen(Color.FromArgb(60, 60, 65), 1);

            g.DrawString(title, titleFont, grayBrush, 5, 5);

            // Grid lines
            for (int i = 0; i <= 4; i++)
            {
                int y = chartY + (int)(chartH * i / 4.0);
                g.DrawLine(linePen, startX - 5, y, startX + totalW, y);
            }

            for (int i = 0; i < revenue.Length; i++)
            {
                int x = startX + i * (groupW + 15);

                int h1 = maxVal > 0 ? (int)((double)revenue[i] / maxVal * chartH) : 0;
                int h2 = maxVal > 0 ? (int)((double)expenses[i] / maxVal * chartH) : 0;

                g.FillRectangle(greenBrush, x, chartY + chartH - h1, barW, h1);
                g.FillRectangle(redBrush, x + barW + 4, chartY + chartH - h2, barW, h2);

                g.DrawString(labels[i], fontS, grayBrush, x + 5, chartY + chartH + 4);
            }

            // Legend
            g.FillRectangle(greenBrush, pnlChartArea.Width - 130, 8, 10, 10);
            g.DrawString("Doanh thu", fontS, whiteBrush, pnlChartArea.Width - 117, 7);
            g.FillRectangle(redBrush, pnlChartArea.Width - 130, 22, 10, 10);
            g.DrawString("Chi phí", fontS, whiteBrush, pnlChartArea.Width - 117, 21);
        }

        // =================== FEEDBACK CHART ===================
        private void btnFBMonth_Click(object sender, EventArgs e)
        {
            _fbMode = "month";
            HighlightChartBtn(btnFBMonth, btnFBQuarter, btnFBYear);
            UpdateFeedbackSummary();
            DrawFeedbackChart();
        }
        private void btnFBQuarter_Click(object sender, EventArgs e)
        {
            _fbMode = "quarter";
            HighlightChartBtn(btnFBQuarter, btnFBMonth, btnFBYear);
            UpdateFeedbackSummary();
            DrawFeedbackChart();
        }
        private void btnFBYear_Click(object sender, EventArgs e)
        {
            _fbMode = "year";
            HighlightChartBtn(btnFBYear, btnFBMonth, btnFBQuarter);
            UpdateFeedbackSummary();
            DrawFeedbackChart();
        }

        private void UpdateFeedbackSummary()
        {
            switch (_fbMode)
            {
                case "quarter":
                    lblGoodFeedback.Text = "Tốt: 128 (82%)";
                    lblBadFeedback.Text = "Xấu: 28 (18%)";
                    break;
                case "year":
                    lblGoodFeedback.Text = "Tốt: 486 (85%)";
                    lblBadFeedback.Text = "Xấu: 86 (15%)";
                    break;
                default:
                    lblGoodFeedback.Text = "Tốt: 42 (84%)";
                    lblBadFeedback.Text = "Xấu: 8 (16%)";
                    break;
            }
        }

        private void DrawFeedbackChart()
        {
            pnlFBChartArea.Paint -= PnlFBChartArea_Paint;
            pnlFBChartArea.Paint += PnlFBChartArea_Paint;
            pnlFBChartArea.Invalidate();
        }

        private void PnlFBChartArea_Paint(object? sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            g.Clear(Color.FromArgb(45, 45, 48));

            int[] good;
            int[] bad;
            string[] labels;

            switch (_fbMode)
            {
                case "quarter":
                    good = new[] { 110, 125, 128, 120 };
                    bad = new[] { 22, 18, 28, 20 };
                    labels = new[] { "Q1", "Q2", "Q3", "Q4" };
                    break;
                case "year":
                    good = new[] { 320, 380, 450, 486 };
                    bad = new[] { 60, 72, 80, 86 };
                    labels = new[] { "2023", "2024", "2025", "2026" };
                    break;
                default: // month
                    good = new[] { 35, 38, 40, 42, 45, 42 };
                    bad = new[] { 8, 6, 10, 8, 5, 8 };
                    labels = new[] { "T10", "T11", "T12", "T1", "T2", "T3" };
                    break;
            }

            int maxVal = 0;
            for (int i = 0; i < good.Length; i++)
                maxVal = Math.Max(maxVal, good[i] + bad[i]);
            maxVal = (int)(maxVal * 1.15);

            int chartH = 95;
            int chartY = 15;
            int barW = 40;
            int gap = 20;
            int totalW = good.Length * barW + (good.Length - 1) * gap;
            int startX = (pnlFBChartArea.Width - totalW) / 2;

            using var fontS = new Font("Segoe UI", 7.5F);
            using var grayBrush = new SolidBrush(Color.Gray);
            using var greenBrush = new SolidBrush(Color.MediumSeaGreen);
            using var redBrush = new SolidBrush(Color.IndianRed);
            using var whiteBrush = new SolidBrush(Color.White);
            using var linePen = new Pen(Color.FromArgb(60, 60, 65), 1);

            for (int i = 0; i <= 3; i++)
            {
                int y = chartY + (int)(chartH * i / 3.0);
                g.DrawLine(linePen, startX - 5, y, startX + totalW, y);
            }

            for (int i = 0; i < good.Length; i++)
            {
                int x = startX + i * (barW + gap);
                int hGood = maxVal > 0 ? (int)((double)good[i] / maxVal * chartH) : 0;
                int hBad = maxVal > 0 ? (int)((double)bad[i] / maxVal * chartH) : 0;

                // Stack: bad on top of good
                g.FillRectangle(greenBrush, x, chartY + chartH - hGood - hBad, barW, hGood);
                g.FillRectangle(redBrush, x, chartY + chartH - hBad, barW, hBad);

                // Values
                g.DrawString(good[i].ToString(), fontS, whiteBrush, x + 5, chartY + chartH - hGood - hBad - 13);

                g.DrawString(labels[i], fontS, grayBrush, x + 8, chartY + chartH + 4);
            }

            // Legend
            g.FillRectangle(greenBrush, pnlFBChartArea.Width - 120, 5, 10, 10);
            g.DrawString("Tốt", fontS, whiteBrush, pnlFBChartArea.Width - 107, 4);
            g.FillRectangle(redBrush, pnlFBChartArea.Width - 120, 19, 10, 10);
            g.DrawString("Xấu", fontS, whiteBrush, pnlFBChartArea.Width - 107, 18);
        }
    }
}
