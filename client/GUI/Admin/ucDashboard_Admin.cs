using System;
using System.Drawing;
using System.Windows.Forms;

namespace GUI
{
    public partial class ucDashboard_Admin : UserControl
    {
        public ucDashboard_Admin()
        {
            InitializeComponent();
            // Style + cột bảng đã đặt trong Designer; chỉ còn helper runtime:
            DgvDarkScroll.Apply(dgvRevenue);
            DgvDarkScroll.Apply(dgvFeedback);
            ThemedScroll.AttachVertical(this, tblRoot, 500);

            // Double-click 1 dòng -> form chi tiết read-only
            dgvRevenue.CellDoubleClick  += (s, e) => ShowRowDetail(dgvRevenue, e, "Chi tiết doanh thu");
            dgvFeedback.CellDoubleClick += (s, e) => ShowRowDetail(dgvFeedback, e, "Chi tiết feedback");
        }

        private void ShowRowDetail(DataGridView dgv, DataGridViewCellEventArgs e, string title)
        {
            if (e.RowIndex < 0) return;
            RecordDetail.FromRow(dgv.Rows[e.RowIndex], title).ShowDialog(MsgBox.OwnerWindow(this));
        }

        private void ucDashboard_Admin_Load(object sender, EventArgs e)
        {
            FillRevenueRows();
            FillFeedbackRows();
        }

        // --- Đổ dữ liệu vào 2 bảng (mock) ---
        private void FillRevenueRows()
        {
            dgvRevenue.Rows.Clear();
            dgvRevenue.Rows.Add("Bán đồ uống", Theme.Vnd(38_500_000));
            dgvRevenue.Rows.Add("Bán bánh / snack", Theme.Vnd(5_200_000));
            dgvRevenue.Rows.Add("Phí gửi xe", Theme.Vnd(2_100_000));
            int t = dgvRevenue.Rows.Add("Tổng doanh thu", Theme.Vnd(45_800_000));
            dgvRevenue.Rows[t].DefaultCellStyle.Font = Theme.F(9.5F, FontStyle.Bold);
            dgvRevenue.Rows[t].DefaultCellStyle.ForeColor = Theme.Green;
        }

        private void FillFeedbackRows()
        {
            dgvFeedback.Rows.Clear();
            int rG = dgvFeedback.Rows.Add("● Tốt", "42");
            dgvFeedback.Rows[rG].Cells[0].Style.ForeColor = Theme.Green;
            int rB = dgvFeedback.Rows.Add("● Xấu", "8");
            dgvFeedback.Rows[rB].Cells[0].Style.ForeColor = Theme.Red;
            int rT = dgvFeedback.Rows.Add("Tổng", "50");
            dgvFeedback.Rows[rT].DefaultCellStyle.Font = Theme.F(9.5F, FontStyle.Bold);
        }

        // --- Bấm "Chi tiết →" cạnh tiêu đề bảng → form biểu đồ cột theo tháng + chọn khoảng thời gian ---
        private void BtnRevenueDetail_Click(object sender, EventArgs e)
        {
            using var f = new ChartDetail("Doanh thu theo tháng (triệu VNĐ)", Theme.Green,
                "Doanh thu", Color.MediumSeaGreen, "Chi phí", Color.IndianRed, RevenueMonthly);
            f.ShowDialog(FindForm());
        }

        private void BtnFeedbackDetail_Click(object sender, EventArgs e)
        {
            using var f = new ChartDetail("Feedback theo tháng", Theme.Teal,
                "Tốt", Color.MediumSeaGreen, "Xấu", Color.IndianRed, FeedbackMonthly);
            f.ShowDialog(FindForm());
        }

        // --- Bấm "Chi tiết →" trên thẻ → form cấu thành + số tiền theo tháng ---
        private void BtnRevenueMore_Click(object sender, EventArgs e) => OpenKhoan(
            "Chi tiết Doanh thu", Theme.Green,
            new (string, long)[] { ("Bán đồ uống", 38_500_000), ("Bán bánh / snack", 5_200_000), ("Phí gửi xe", 2_100_000) },
            "Doanh thu = tổng tiền thu được từ bán hàng & dịch vụ trong kỳ (cộng các khoản trên).",
            Monthly(38.0, 40.5, 42.0, 39.5, 44.0, 48.0, 41.0, 38.5, 45.0, 42.0, 45.0, 45.8));

        private void BtnProfitMore_Click(object sender, EventArgs e) => OpenKhoan(
            "Chi tiết Lợi nhuận ròng", Theme.Teal,
            new (string, long)[] { ("Doanh thu", 45_800_000), ("Tổng chi phí", -25_100_000), ("Thất thoát", -2_500_000) },
            "Lợi nhuận ròng = Doanh thu − Tổng chi phí − Thất thoát.",
            Monthly(14.0, 14.8, 16.1, 14.1, 16.4, 18.4, 14.2, 14.0, 16.5, 14.8, 16.6, 18.2));

        private void BtnExpenseMore_Click(object sender, EventArgs e) => OpenKhoan(
            "Chi tiết Chi phí", Theme.Red,
            new (string, long)[] { ("Nguyên liệu", 15_200_000), ("Lương nhân viên", 7_800_000), ("Điện nước", 1_200_000), ("Thuê mặt bằng", 900_000) },
            "Tổng chi phí = tổng các khoản phải chi để vận hành quán trong kỳ.",
            Monthly(22.0, 23.5, 24.0, 23.0, 25.5, 27.0, 24.5, 22.5, 26.0, 25.0, 26.0, 25.1));

        private void BtnLossMore_Click(object sender, EventArgs e) => OpenKhoan(
            "Chi tiết Thất thoát", Theme.Amber,
            new (string, long)[] { ("Hao phí nguyên liệu", 1_800_000), ("Chênh lệch tiền", 700_000) },
            "Thất thoát = giá trị hao hụt / mất mát ngoài kế hoạch trong kỳ.",
            Monthly(2.0, 2.2, 1.9, 2.4, 2.1, 2.6, 2.3, 2.0, 2.5, 2.2, 2.4, 2.5));

        private void OpenKhoan(string title, Color accent, (string, long)[] rows, string note, (string, long)[] monthly)
        {
            using var f = new MetricDetail(title, accent, rows, note, monthly);
            f.ShowDialog(FindForm());
        }

        // --- Mock data ---

        // (Năm, Tháng, A, B) — A/B đơn vị triệu đ hoặc số lượt; dùng cho ChartDetail
        private static readonly (int, int, double, double)[] RevenueMonthly =
        {
            (2025, 7, 38.0, 22.0), (2025, 8, 40.5, 23.5), (2025, 9, 42.0, 24.0),
            (2025, 10, 39.5, 23.0), (2025, 11, 44.0, 25.5), (2025, 12, 48.0, 27.0),
            (2026, 1, 41.0, 24.5), (2026, 2, 38.5, 22.5), (2026, 3, 45.0, 26.0),
            (2026, 4, 42.0, 25.0), (2026, 5, 45.0, 26.0), (2026, 6, 45.8, 25.1),
        };

        private static readonly (int, int, double, double)[] FeedbackMonthly =
        {
            (2025, 7, 35, 8), (2025, 8, 38, 7), (2025, 9, 40, 9),
            (2025, 10, 37, 10), (2025, 11, 42, 6), (2025, 12, 45, 5),
            (2026, 1, 39, 8), (2026, 2, 36, 9), (2026, 3, 44, 6),
            (2026, 4, 40, 10), (2026, 5, 45, 5), (2026, 6, 42, 8),
        };

        // Tạo 12 (tháng, số tiền VND) từ mảng triệu đồng — dùng cho MetricDetail
        private static readonly string[] _months =
        {
            "T7/25", "T8/25", "T9/25", "T10/25", "T11/25", "T12/25",
            "T1/26", "T2/26", "T3/26", "T4/26",  "T5/26",  "T6/26",
        };
        private static (string, long)[] Monthly(params double[] millions)
        {
            var arr = new (string, long)[millions.Length];
            for (int i = 0; i < millions.Length; i++)
                arr[i] = (_months[i], (long)(millions[i] * 1_000_000));
            return arr;
        }

        private void dgvRevenue_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
