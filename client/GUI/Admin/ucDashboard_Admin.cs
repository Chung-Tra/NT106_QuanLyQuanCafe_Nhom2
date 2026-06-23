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
        private string _viewMode = "income"; // income | expense | loss

        public ucDashboard_Admin()
        {
            InitializeComponent();
            cboTimeRange.SelectedIndex = 2; // "Tháng này"
        }

        private void ucDashboard_Admin_Load(object sender, EventArgs e)
        {
            LoadSummary();
            LoadRevenueDetail();
            AutoFadeScroll.Attach(dgvRevenueDetail);
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
        // Màu sắc dùng cho từng nhóm
        private static readonly Color CIncome   = Color.FromArgb(34, 197, 94);
        private static readonly Color CExpense  = Color.FromArgb(220, 80, 80);
        private static readonly Color CLoss     = Color.FromArgb(245, 158, 11);
        private static readonly Color CMuted    = Color.FromArgb(160, 160, 166);
        private static readonly Color CGroupBg  = Color.FromArgb(38, 38, 42);

        private void LoadRevenueDetail()
        {
            dgvRevenueDetail.DataSource = null;
            dgvRevenueDetail.Rows.Clear();
            dgvRevenueDetail.Columns.Clear();

            dgvRevenueDetail.Columns.Add("KhoanMuc", "Khoản mục");
            dgvRevenueDetail.Columns.Add("SoTien",   "Số tiền");
            dgvRevenueDetail.Columns.Add("PhanTram", "%");
            dgvRevenueDetail.Columns.Add("SoSanh",   "vs Kỳ trước");

            dgvRevenueDetail.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvRevenueDetail.Columns["KhoanMuc"].FillWeight = 42;
            dgvRevenueDetail.Columns["SoTien"].FillWeight   = 23;
            dgvRevenueDetail.Columns["PhanTram"].FillWeight = 13;
            dgvRevenueDetail.Columns["SoSanh"].FillWeight   = 22;

            dgvRevenueDetail.Columns["SoTien"].DefaultCellStyle.Alignment   = DataGridViewContentAlignment.MiddleRight;
            dgvRevenueDetail.Columns["PhanTram"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvRevenueDetail.Columns["SoSanh"].DefaultCellStyle.Alignment   = DataGridViewContentAlignment.MiddleCenter;

            int itemCount = 0;
            string groupLabel;

            switch (_viewMode)
            {
                case "income":
                    AddGroupHeader("━━ Thu ━━━━━━━━━━━━━━━━━━");
                    AddDataRow("Bán đồ uống",      "+38,500,000", "84%",  "+12% ↑", CIncome, CIncome);
                    AddDataRow("Bán bánh / snack", "+5,200,000",  "11%",  "-3% ↓",  CIncome, CExpense);
                    AddDataRow("Phí gửi xe",       "+2,100,000",  "5%",   "+8% ↑",  CIncome, CIncome);
                    AddSubtotal("Tổng Thu",        "+45,800,000", "100%", "+9% ↑",  CIncome);
                    itemCount = 3; groupLabel = "Thu";
                    break;

                case "expense":
                    AddGroupHeader("━━ Chi ━━━━━━━━━━━━━━━━━━");
                    AddDataRow("Nguyên liệu",     "-15,200,000", "61%",  "+5% ↑",  CExpense, CExpense);
                    AddDataRow("Lương nhân viên", "-7,800,000",  "31%",  "0% —",   CExpense, CMuted);
                    AddDataRow("Điện nước",       "-1,200,000",  "5%",   "+2% ↑",  CExpense, CExpense);
                    AddDataRow("Thuê mặt bằng",   "-900,000",    "3%",   "0% —",   CExpense, CMuted);
                    AddSubtotal("Tổng Chi",       "-25,100,000", "100%", "+4% ↑",  CExpense);
                    itemCount = 4; groupLabel = "Chi";
                    break;

                case "loss":
                default:
                    AddGroupHeader("━━ Thất thoát ━━━━━━━━━━━━");
                    AddDataRow("Hao phí nguyên liệu", "-1,800,000", "72%",  "+18% ↑", CLoss, CExpense);
                    AddDataRow("Chênh lệch tiền",     "-700,000",   "28%",  "-5% ↓",  CLoss, CIncome);
                    AddSubtotal("Tổng Thất thoát",    "-2,500,000", "100%", "+13% ↑", CLoss);
                    itemCount = 2; groupLabel = "Thất thoát";
                    break;
            }

            string range = cboTimeRange.SelectedItem?.ToString() ?? "Tháng 5/2026";
            lblRevenueSubtitle.Text = $"{range} · Nhóm {groupLabel} · {itemCount} khoản mục";
        }

        private void AddGroupHeader(string text)
        {
            int idx = dgvRevenueDetail.Rows.Add(text, "", "", "");
            var row = dgvRevenueDetail.Rows[idx];
            row.DefaultCellStyle.BackColor = CGroupBg;
            row.DefaultCellStyle.SelectionBackColor = CGroupBg;
            row.DefaultCellStyle.ForeColor = CMuted;
            row.DefaultCellStyle.SelectionForeColor = CMuted;
            row.DefaultCellStyle.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            row.Height = 22;
            row.ReadOnly = true;
        }

        private void AddDataRow(string label, string amount, string percent, string compare,
                                 Color amountColor, Color compareColor)
        {
            int idx = dgvRevenueDetail.Rows.Add(label, amount, percent, compare);
            var row = dgvRevenueDetail.Rows[idx];
            row.Cells["SoTien"].Style.ForeColor   = amountColor;
            row.Cells["SoTien"].Style.SelectionForeColor = amountColor;
            row.Cells["SoSanh"].Style.ForeColor   = compareColor;
            row.Cells["SoSanh"].Style.SelectionForeColor = compareColor;
            row.Cells["PhanTram"].Style.ForeColor = CMuted;
            row.Cells["PhanTram"].Style.SelectionForeColor = CMuted;
        }

        private void AddSubtotal(string label, string amount, string percent, string compare, Color color)
        {
            int idx = dgvRevenueDetail.Rows.Add(label, amount, percent, compare);
            var row = dgvRevenueDetail.Rows[idx];
            row.DefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            row.DefaultCellStyle.BackColor = Color.FromArgb(28, 28, 31);
            row.DefaultCellStyle.SelectionBackColor = Color.FromArgb(28, 28, 31);
            row.Cells["KhoanMuc"].Style.ForeColor = CMuted;
            row.Cells["KhoanMuc"].Style.SelectionForeColor = CMuted;
            row.Cells["SoTien"].Style.ForeColor = color;
            row.Cells["SoTien"].Style.SelectionForeColor = color;
            row.Cells["SoSanh"].Style.ForeColor = color;
            row.Cells["SoSanh"].Style.SelectionForeColor = color;
        }

        // =================== ACTION BUTTONS (UI ONLY) ===================
        private void CboTimeRange_SelectedIndexChanged(object? sender, EventArgs e)
        {
            // Chỉ cập nhật subtitle — chưa có logic load lại data theo khoảng thời gian
            string range = cboTimeRange.SelectedItem?.ToString() ?? "Tháng này";
            lblRevenueSubtitle.Text = $"{range} · 9 khoản mục · 3 nhóm";
        }

        private void BtnExportExcel_Click(object? sender, EventArgs e)
        {
            using SaveFileDialog sfd = new()
            {
                Title         = "Xuất báo cáo doanh thu chi tiết",
                Filter        = "Excel Workbook (*.xlsx)|*.xlsx|CSV UTF-8 (*.csv)|*.csv|Tất cả (*.*)|*.*",
                FileName      = $"BaoCao_DoanhThu_{DateTime.Now:yyyyMMdd_HHmm}.xlsx",
                DefaultExt    = "xlsx",
                AddExtension  = true,
                OverwritePrompt = true,
            };

            if (sfd.ShowDialog(this) == DialogResult.OK)
            {
                MsgBox.Show(this,
                    $"Đã chọn vị trí lưu:\n{sfd.FileName}\n\n(Chức năng xuất file đang được phát triển)",
                    "Xuất báo cáo", MsgBox.MessageBoxType.Info);
            }
        }

        private void BtnPrintReport_Click(object? sender, EventArgs e)
        {
            using PrintDialog pd = new()
            {
                AllowSomePages = true,
                AllowSelection = true,
                UseEXDialog = true,
            };

            if (pd.ShowDialog(this) == DialogResult.OK)
            {
                MsgBox.Show(this,
                    $"Đã chọn máy in: {pd.PrinterSettings.PrinterName}\nSố bản: {pd.PrinterSettings.Copies}\n\n(Chức năng in đang được phát triển)",
                    "In báo cáo", MsgBox.MessageBoxType.Info);
            }
        }

        private void BtnImportExcel_Click(object? sender, EventArgs e)
        {
            using OpenFileDialog ofd = new()
            {
                Title  = "Nhập dữ liệu từ Excel / CSV",
                Filter = "Excel Workbook (*.xlsx)|*.xlsx|CSV UTF-8 (*.csv)|*.csv|Tất cả (*.*)|*.*",
                CheckFileExists = true,
                Multiselect = false,
            };

            if (ofd.ShowDialog(this) == DialogResult.OK)
            {
                MsgBox.Show(this,
                    $"Đã chọn tệp:\n{ofd.FileName}\n\n(Chức năng đọc và nhập dữ liệu đang được phát triển)",
                    "Nhập từ Excel", MsgBox.MessageBoxType.Info);
            }
        }

        // ───────── View tabs (Mức 2 - chọn nhóm) ─────────
        private void BtnViewIncome_Click(object? sender, EventArgs e)  => SwitchView("income",  btnViewIncome);
        private void BtnViewExpense_Click(object? sender, EventArgs e) => SwitchView("expense", btnViewExpense);
        private void BtnViewLoss_Click(object? sender, EventArgs e)    => SwitchView("loss",    btnViewLoss);

        private void SwitchView(string mode, Guna.UI2.WinForms.Guna2Button activeTab)
        {
            _viewMode = mode;
            HighlightTab(activeTab, btnViewIncome, btnViewExpense, btnViewLoss);
            LoadRevenueDetail();
        }

        private void HighlightTab(Guna.UI2.WinForms.Guna2Button active,
                                   params Guna.UI2.WinForms.Guna2Button[] all)
        {
            foreach (var b in all)
            {
                if (b == active)
                {
                    b.FillColor = Color.FromArgb(31, 138, 154);
                    b.ForeColor = Color.White;
                    b.HoverState.FillColor = Color.FromArgb(45, 158, 174);
                }
                else
                {
                    b.FillColor = Color.Transparent;
                    b.ForeColor = Color.FromArgb(160, 160, 166);
                    b.HoverState.FillColor = Color.FromArgb(45, 45, 50);
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

        private void HighlightChartBtn(Guna.UI2.WinForms.Guna2Button active, Guna.UI2.WinForms.Guna2Button b1, Guna.UI2.WinForms.Guna2Button b2)
        {
            active.FillColor = Color.FromArgb(31, 138, 154);
            active.ForeColor = Color.White;
            active.HoverState.FillColor = Color.FromArgb(45, 158, 174);

            foreach (var b in new[] { b1, b2 })
            {
                b.FillColor = Color.Transparent;
                b.ForeColor = Color.FromArgb(160, 160, 166);
                b.HoverState.FillColor = Color.FromArgb(45, 45, 50);
            }
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
