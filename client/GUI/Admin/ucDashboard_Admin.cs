using BUS;
using DTO;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
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

        private void ucDashboard_Admin_Load(object sender, EventArgs e) => _ = LoadRealAsync();

        // --- Đổ dữ liệu THẬT từ Firebase vào 2 bảng tổng hợp ---
        private async Task LoadRealAsync()
        {
            decimal sales = 0, parkingFee = 0;
            int good = 0, bad = 0, totalFb = 0;
            try
            {
                var payments = await PaymentBUS.GetAll();
                sales = payments.Values.Sum(p => p.ActualReceived);

                var parking = await ParkingBUS.GetAll();
                parkingFee = parking.Values.Where(p => p.Status == "da_ra").Sum(p => p.Fee);

                var fbs = await FeedbackBUS.GetAll();
                totalFb = fbs.Count;
                good = fbs.Values.Count(f => f.Rating >= 4);
                bad = fbs.Values.Count(f => f.Rating <= 2);
            }
            catch { /* offline */ }

            dgvRevenue.Rows.Clear();
            dgvRevenue.Rows.Add("Bán hàng (đơn)", Theme.Vnd((long)sales));
            dgvRevenue.Rows.Add("Phí gửi xe", Theme.Vnd((long)parkingFee));
            int t = dgvRevenue.Rows.Add("Tổng doanh thu", Theme.Vnd((long)(sales + parkingFee)));
            dgvRevenue.Rows[t].DefaultCellStyle.Font = Theme.F(9.5F, FontStyle.Bold);
            dgvRevenue.Rows[t].DefaultCellStyle.ForeColor = Theme.Green;

            dgvFeedback.Rows.Clear();
            int rG = dgvFeedback.Rows.Add("● Tốt (4-5★)", good.ToString());
            dgvFeedback.Rows[rG].Cells[0].Style.ForeColor = Theme.Green;
            int rB = dgvFeedback.Rows.Add("● Xấu (1-2★)", bad.ToString());
            dgvFeedback.Rows[rB].Cells[0].Style.ForeColor = Theme.Red;
            int rT = dgvFeedback.Rows.Add("Tổng", totalFb.ToString());
            dgvFeedback.Rows[rT].DefaultCellStyle.Font = Theme.F(9.5F, FontStyle.Bold);
        }

        // --- "Chi tiết →" cạnh tiêu đề bảng → biểu đồ cột 12 tháng gần nhất (dữ liệu THẬT) ---
        private async void BtnRevenueDetail_Click(object sender, EventArgs e)
        {
            var months = Last12Months();
            var rev = new double[12]; var exp = new double[12];
            try
            {
                foreach (var p in (await PaymentBUS.GetAll()).Values)
                { int i = MonthIdx(months, p.Timestamp); if (i >= 0) rev[i] += (double)p.ActualReceived / 1_000_000; }
                foreach (var x in (await ExpenseBUS.GetAll()).Values)
                { int i = MonthIdx(months, x.Timestamp); if (i >= 0) exp[i] += (double)x.SoTien / 1_000_000; }
            }
            catch { /* offline → cột 0 */ }

            var data = new (int, int, double, double)[12];
            for (int i = 0; i < 12; i++) data[i] = (months[i].Year, months[i].Month, Math.Round(rev[i], 1), Math.Round(exp[i], 1));
            using var f = new ChartDetail("Doanh thu theo tháng (triệu VNĐ)", Theme.Green,
                "Doanh thu", Color.MediumSeaGreen, "Chi phí", Color.IndianRed, data);
            f.ShowDialog(FindForm());
        }

        private async void BtnFeedbackDetail_Click(object sender, EventArgs e)
        {
            var months = Last12Months();
            var good = new double[12]; var bad = new double[12];
            try
            {
                foreach (var fb in (await FeedbackBUS.GetAll()).Values)
                {
                    int i = MonthIdx(months, fb.Timestamp); if (i < 0) continue;
                    if (fb.Rating >= 4) good[i]++; else if (fb.Rating <= 2) bad[i]++;
                }
            }
            catch { /* offline */ }

            var data = new (int, int, double, double)[12];
            for (int i = 0; i < 12; i++) data[i] = (months[i].Year, months[i].Month, good[i], bad[i]);
            using var f = new ChartDetail("Feedback theo tháng", Theme.Teal,
                "Tốt", Color.MediumSeaGreen, "Xấu", Color.IndianRed, data);
            f.ShowDialog(FindForm());
        }

        // --- "Chi tiết →" trên thẻ → cấu thành + số tiền theo tháng (dữ liệu THẬT) ---
        private async void BtnRevenueMore_Click(object sender, EventArgs e)
        {
            var months = Last12Months();
            long sales = 0, park = 0;
            (string, long)[] monthly = MonthlyVnd(months, Enumerable.Empty<(long, decimal)>());
            try
            {
                var payments = (await PaymentBUS.GetAll()).Values;
                sales   = (long)payments.Sum(p => p.ActualReceived);
                park    = (long)(await ParkingBUS.GetAll()).Values.Where(p => p.Status == "da_ra").Sum(p => p.Fee);
                monthly = MonthlyVnd(months, payments.Select(p => (p.Timestamp, p.ActualReceived)));
            }
            catch { }
            OpenKhoan("Chi tiết Doanh thu", Theme.Green,
                new (string, long)[] { ("Bán hàng", sales), ("Phí gửi xe", park) },
                "Doanh thu = tổng tiền thu được từ bán hàng & dịch vụ trong kỳ.", monthly);
        }

        private async void BtnProfitMore_Click(object sender, EventArgs e)
        {
            var months = Last12Months();
            long rev = 0, exp = 0, loss = 0;
            (string, long)[] monthly = MonthlyVnd(months, Enumerable.Empty<(long, decimal)>());
            try
            {
                var payments = (await PaymentBUS.GetAll()).Values;
                var expenses = (await ExpenseBUS.GetAll()).Values;
                var losses   = (await LossBUS.GetAll()).Values;
                rev  = (long)payments.Sum(p => p.ActualReceived);
                exp  = expenses.Sum(x => x.SoTien);
                loss = (long)losses.Sum(l => l.GiaTri);

                var revM  = MonthlyVnd(months, payments.Select(p => (p.Timestamp, p.ActualReceived)));
                var expM  = MonthlyVnd(months, expenses.Select(x => (x.Timestamp, (decimal)x.SoTien)));
                var lossM = MonthlyVnd(months, losses.Select(l => (l.Timestamp, l.GiaTri)));
                var arr = new (string, long)[months.Length];
                for (int i = 0; i < months.Length; i++)
                    arr[i] = (months[i].Label, revM[i].Amount - expM[i].Amount - lossM[i].Amount);
                monthly = arr;
            }
            catch { }
            OpenKhoan("Chi tiết Lợi nhuận ròng", Theme.Teal,
                new (string, long)[] { ("Doanh thu", rev), ("Tổng chi phí", -exp), ("Thất thoát", -loss) },
                "Lợi nhuận ròng = Doanh thu − Tổng chi phí − Thất thoát.", monthly);
        }

        private async void BtnExpenseMore_Click(object sender, EventArgs e)
        {
            var months = Last12Months();
            var rows = new List<(string, long)>();
            (string, long)[] monthly = MonthlyVnd(months, Enumerable.Empty<(long, decimal)>());
            try
            {
                var expenses = (await ExpenseBUS.GetAll()).Values;
                rows = expenses.GroupBy(x => string.IsNullOrWhiteSpace(x.DanhMuc) ? "Khác" : x.DanhMuc!)
                               .Select(g => (g.Key, g.Sum(x => x.SoTien)))
                               .OrderByDescending(r => r.Item2).ToList();
                monthly = MonthlyVnd(months, expenses.Select(x => (x.Timestamp, (decimal)x.SoTien)));
            }
            catch { }
            if (rows.Count == 0) rows.Add(("(chưa có chi phí)", 0));
            OpenKhoan("Chi tiết Chi phí", Theme.Red, rows.ToArray(),
                "Tổng chi phí = tổng các khoản phải chi để vận hành quán trong kỳ.", monthly);
        }

        private async void BtnLossMore_Click(object sender, EventArgs e)
        {
            var months = Last12Months();
            var rows = new List<(string, long)>();
            (string, long)[] monthly = MonthlyVnd(months, Enumerable.Empty<(long, decimal)>());
            try
            {
                var losses = (await LossBUS.GetAll()).Values;
                rows = losses.GroupBy(l => string.IsNullOrWhiteSpace(l.KhoanMuc) ? "Khác" : l.KhoanMuc!)
                             .Select(g => (g.Key, (long)g.Sum(l => l.GiaTri)))
                             .OrderByDescending(r => r.Item2).ToList();
                monthly = MonthlyVnd(months, losses.Select(l => (l.Timestamp, l.GiaTri)));
            }
            catch { }
            if (rows.Count == 0) rows.Add(("(chưa có thất thoát)", 0));
            OpenKhoan("Chi tiết Thất thoát", Theme.Amber, rows.ToArray(),
                "Thất thoát = giá trị hao hụt / mất mát ngoài kế hoạch trong kỳ.", monthly);
        }

        private void OpenKhoan(string title, Color accent, (string, long)[] rows, string note, (string, long)[] monthly)
        {
            using var f = new MetricDetail(title, accent, rows, note, monthly);
            f.ShowDialog(FindForm());
        }

        // --- Helper gom nhóm 12 tháng gần nhất từ dữ liệu THẬT ---

        // 12 tháng gần nhất (cũ → mới) kèm nhãn "T{m}/{yy}".
        private static (int Year, int Month, string Label)[] Last12Months()
        {
            var first = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            var arr = new (int, int, string)[12];
            for (int i = 0; i < 12; i++)
            {
                var d = first.AddMonths(-11 + i);
                arr[i] = (d.Year, d.Month, $"T{d.Month}/{d:yy}");
            }
            return arr;
        }

        private static int MonthIdx((int Year, int Month, string Label)[] months, long ts)
        {
            if (ts <= 0) return -1;
            var d = DateTimeOffset.FromUnixTimeMilliseconds(ts).LocalDateTime;
            for (int i = 0; i < months.Length; i++)
                if (months[i].Year == d.Year && months[i].Month == d.Month) return i;
            return -1;
        }

        // Gom tổng tiền (VND) theo tháng từ danh sách (mốc thời gian ms, số tiền).
        private static (string Month, long Amount)[] MonthlyVnd(
            (int Year, int Month, string Label)[] months, IEnumerable<(long Ts, decimal Amount)> items)
        {
            var sums = new long[months.Length];
            foreach (var (ts, amt) in items)
            {
                int i = MonthIdx(months, ts);
                if (i >= 0) sums[i] += (long)amt;
            }
            var arr = new (string, long)[months.Length];
            for (int i = 0; i < months.Length; i++) arr[i] = (months[i].Label, sums[i]);
            return arr;
        }

        private void dgvRevenue_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
