using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace GUI
{
    // Detail form for one Dashboard metric (Revenue / Profit / Expense / Loss):
    //  - Left: BREAKDOWN (the small amounts that sum to the figure) + how-it's-computed note.
    //  - Right: AMOUNT PER MONTH (dữ liệu thật, do ucDashboard_Admin tổng hợp 12 tháng gần nhất).
    public partial class MetricDetail : Form
    {
        // Ctor không tham số: chỉ để VS Designer mở được form (runtime luôn dùng ctor có tham số bên dưới)
        public MetricDetail()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object? sender, EventArgs e) => Close();

        public MetricDetail(string title, Color accent,
                                IReadOnlyList<(string Label, long Amount)> rows, string note,
                                IReadOnlyList<(string Month, long Amount)> monthly)
        {
            InitializeComponent();
            FormCorners.Round(this);

            // Dynamic: accent colour + title (from ctor args)
            accentBar.FillColor  = accent;
            lblTitle.Text        = title;
            btnClose.FillColor   = accent;
            btnClose.HoverState.FillColor = Theme.Lighten(accent, 16);

            const int leftX = 22, rightX = 374, gridTop = 84;

            // Left grid — breakdown
            Theme.StyleGrid(dgvBreakdown);
            dgvBreakdown.Location = new Point(leftX, gridTop);
            dgvBreakdown.Columns.Add("Khoan", "Khoản mục");
            dgvBreakdown.Columns.Add("Tien",  "Số tiền");
            dgvBreakdown.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvBreakdown.Columns["Khoan"].FillWeight = 56;
            dgvBreakdown.Columns["Tien"].FillWeight  = 44;
            dgvBreakdown.Columns["Tien"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvBreakdown.Columns["Tien"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;

            long total = 0;
            foreach (var (label, amount) in rows)
            {
                int idx = dgvBreakdown.Rows.Add(label, Theme.Vnd(amount));
                dgvBreakdown.Rows[idx].Cells["Tien"].Style.ForeColor = amount < 0 ? Theme.Red : Theme.TextPri;
                total += amount;
            }
            int totalIdx = dgvBreakdown.Rows.Add("Tổng cộng", Theme.Vnd(total));
            var totalRow = dgvBreakdown.Rows[totalIdx];
            totalRow.DefaultCellStyle.Font      = Theme.F(10F, FontStyle.Bold);
            totalRow.DefaultCellStyle.BackColor = Theme.SurfaceAlt;
            totalRow.Cells["Khoan"].Style.ForeColor = Theme.TextHi;
            totalRow.Cells["Tien"].Style.ForeColor  = accent;
            dgvBreakdown.Size = new Size(330, dgvBreakdown.ColumnHeadersHeight + (rows.Count + 1) * dgvBreakdown.RowTemplate.Height + 2);

            // Right grid — monthly
            Theme.StyleGrid(dgvMonthly);
            dgvMonthly.Location = new Point(rightX, gridTop);
            dgvMonthly.Columns.Add("Thang", "Tháng");
            dgvMonthly.Columns.Add("MTien", "Số tiền");
            dgvMonthly.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvMonthly.Columns["Thang"].FillWeight = 40;
            dgvMonthly.Columns["MTien"].FillWeight = 60;
            dgvMonthly.Columns["MTien"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvMonthly.Columns["MTien"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            // (Lề phải tránh bị dải scrollbar che: nay do AutoFadeScroll tự chừa cho mọi lưới.)
            foreach (var (month, amount) in monthly)
            {
                int idx = dgvMonthly.Rows.Add(month, Theme.Vnd(amount));
                dgvMonthly.Rows[idx].Cells["MTien"].Style.ForeColor = amount < 0 ? Theme.Red : Theme.TextPri;
            }
            int mFull = dgvMonthly.ColumnHeadersHeight + monthly.Count * dgvMonthly.RowTemplate.Height + 2;
            dgvMonthly.Size = new Size(360, Math.Min(mFull, 360));

            // Thanh cuộn native (trắng) lệch theme → thay bằng indicator teal đồng bộ app
            // (giống các dialog khác: AuditLogDetail, AddInventoryImport, ManagerProfileDetail).
            // Chỉ dgvMonthly mới tràn & hiện scrollbar; dgvBreakdown vừa khít nên không cần.
            AutoFadeScroll.Attach(dgvMonthly);

            int contentBottom = Math.Max(dgvBreakdown.Bottom, dgvMonthly.Bottom);

            lblNote.Text     = "ⓘ  " + note;
            lblNote.Location = new Point(leftX, contentBottom + 14);
            btnClose.Location = new Point(614, lblNote.Bottom + 10);

            ClientSize = new Size(756, btnClose.Bottom + 18);

            WindowChrome.Apply(this, host: card, dragHandle: card);
        }
    }
}
