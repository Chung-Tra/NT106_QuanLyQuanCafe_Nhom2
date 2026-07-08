using BUS;
using DTO;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class ucCashManagement_Order : UserControl
    {
        private bool _shiftStarted = false;
        // Tiền đầu ca mặc định lấy từ App.config (CashOpenShift), thu ngân có thể sửa khi mở ca.
        private static decimal DefaultOpenCash =>
            decimal.TryParse(System.Configuration.ConfigurationManager.AppSettings["CashOpenShift"], out var v) ? v : 2000000m;
        private decimal _openCash = DefaultOpenCash;
        private decimal _cashIn;      // tiền mặt thu trong ngày
        private decimal _revenue;     // tổng doanh thu trong ngày (mọi hình thức)

        public ucCashManagement_Order()
        {
            InitializeComponent();
            GridColumnGuard.SyncColumnNames(dgvTransactions);
            DgvRefresh.Attach(dgvTransactions, () => _ = LoadRealData());
        }

        private void ucCashManagement_Order_Load(object? sender, EventArgs e) => _ = LoadRealData();

        private void dgvTransactions_CellDoubleClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            RecordDetail.FromRow(dgvTransactions.Rows[e.RowIndex], "Chi tiết giao dịch tiền mặt")
                        .ShowDialog(MsgBox.OwnerWindow(this));
        }

        private static string MethodVi(string? code) => code switch
        {
            "tien_mat" => "Tiền mặt",
            "the" => "Thẻ",
            "vietqr" => "VietQR",
            "momo" => "Momo",
            "chuyen_khoan" => "Chuyển khoản",
            _ => code ?? ""
        };

        private async Task LoadRealData()
        {
            DataTable dt = new();
            dt.Columns.Add("Thời gian");
            dt.Columns.Add("Loại");
            dt.Columns.Add("Số tiền", typeof(decimal));
            dt.Columns.Add("Ghi chú");

            dt.Rows.Add(DateTime.Today.ToString("dd/MM/yyyy 08:00"), "Mở ca", _openCash, "Tiền đầu ca");

            _cashIn = 0;
            _revenue = 0;
            try
            {
                var payments = await PaymentBUS.GetAll();
                foreach (var p in payments.Values
                    .Where(x => x.Timestamp > 0 &&
                                DateTimeOffset.FromUnixTimeMilliseconds(x.Timestamp).LocalDateTime.Date == DateTime.Today)
                    .OrderBy(x => x.Timestamp))
                {
                    string time = DateTimeOffset.FromUnixTimeMilliseconds(p.Timestamp).LocalDateTime.ToString("dd/MM/yyyy HH:mm");
                    dt.Rows.Add(time, "Thu", p.ActualReceived, $"Đơn {p.OrderId} - {MethodVi(p.Method)}");
                    _revenue += p.ActualReceived;
                    if (p.Method == "tien_mat") _cashIn += p.ActualReceived;
                }
            }
            catch { /* offline */ }

            lblOpenCash.Text = _openCash.ToString("N0") + " đ";
            lblCurrentCash.Text = (_openCash + _cashIn).ToString("N0") + " đ";
            lblRevenue.Text = _revenue.ToString("N0") + " đ";
            // Chênh lệch chỉ biết khi KẾT CA (đếm tiền thật so với sổ) — không bịa "0 đ".
            lblDifference.Text = "— (kết ca để đối soát)";
            lblDifference.ForeColor = Color.Gray;

            dgvTransactions.DataSource = dt;
            dgvTransactions.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTransactions.RowHeadersVisible = false;
            dgvTransactions.Columns["Số tiền"].DefaultCellStyle.Format = "N0";
            dgvTransactions.Columns["Số tiền"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvTransactions.Columns["Thời gian"].FillWeight = 22;
            dgvTransactions.Columns["Loại"].FillWeight     = 13;
            dgvTransactions.Columns["Số tiền"].FillWeight  = 22;
            dgvTransactions.Columns["Ghi chú"].FillWeight  = 43;
        }

        private async void btnReport_Click(object? sender, EventArgs e)
        {
            string report =
                "BÁO CÁO TIỀN MẶT\n" +
                $"Thời gian: {DateTime.Now:HH:mm dd/MM/yyyy}\n" +
                "──────────────────\n" +
                $"• Tiền đầu ca: {lblOpenCash.Text}\n" +
                $"• Tiền hiện tại: {lblCurrentCash.Text}\n" +
                $"• Doanh thu ca: {lblRevenue.Text}";

            if (MsgBox.Show(MsgBox.OwnerWindow(this), report + "\n──────────────────\nGửi báo cáo cho quản lý?",
                            "Báo cáo tiền mặt", MsgBox.MessageBoxType.Warning) != DialogResult.Yes) return;

            var (ok, msg) = await ManagerReport.SendAsync(report, "bao_cao", "cash");
            MsgBox.Show(MsgBox.OwnerWindow(this), msg, ok ? "Thành công" : "Lỗi",
                        ok ? MsgBox.MessageBoxType.Success : MsgBox.MessageBoxType.Error);
        }

        // Mở ca: thu ngân xác nhận/đếm tiền đầu ca thật (mặc định theo App.config CashOpenShift)
        private void btnStartShift_Click(object sender, EventArgs e)
        {
            if (_shiftStarted)
            {
                MsgBox.Show(MsgBox.OwnerWindow(this), "Ca làm việc đã được bắt đầu rồi!", "Thông báo", MsgBox.MessageBoxType.Warning);
                return;
            }
            string? input = InputDialog.Show(MsgBox.OwnerWindow(this), "Mở ca — đếm tiền đầu ca",
                "Tiền mặt đầu ca (đ)", preset: DefaultOpenCash.ToString("0"));
            if (input == null) return;
            if (!decimal.TryParse(input.Replace(".", "").Replace(",", ""), out var opening) || opening < 0)
            {
                MsgBox.Show(MsgBox.OwnerWindow(this), "Số tiền không hợp lệ!", "Thông báo", MsgBox.MessageBoxType.Warning);
                return;
            }

            _openCash = opening;
            _shiftStarted = true;
            btnStartShift.Enabled = false;
            _ = LoadRealData();
            MsgBox.Show(MsgBox.OwnerWindow(this),
                $"Đã bắt đầu ca làm việc!\nTiền đầu ca: {_openCash:N0} đ",
                "Thành công", MsgBox.MessageBoxType.Success);
        }

        // Kết ca: đếm tiền thật trong két → chênh lệch = thực đếm − sổ sách, gửi báo cáo cho quản lý.
        private async void btnEndShift_Click(object sender, EventArgs e)
        {
            if (!_shiftStarted)
            {
                MsgBox.Show(MsgBox.OwnerWindow(this), "Chưa bắt đầu ca làm việc!", "Thông báo", MsgBox.MessageBoxType.Warning);
                return;
            }

            decimal expected = _openCash + _cashIn;
            string? input = InputDialog.Show(MsgBox.OwnerWindow(this), "Kết ca — đếm tiền mặt",
                $"Tiền mặt đếm được trong két (sổ sách: {expected:N0} đ)", preset: expected.ToString("0"));
            if (input == null) return;
            if (!decimal.TryParse(input.Replace(".", "").Replace(",", ""), out var counted) || counted < 0)
            {
                MsgBox.Show(MsgBox.OwnerWindow(this), "Số tiền không hợp lệ!", "Thông báo", MsgBox.MessageBoxType.Warning);
                return;
            }

            decimal diff = counted - expected;
            lblDifference.Text = diff.ToString("N0") + " đ";
            lblDifference.ForeColor = diff == 0 ? Color.MediumSeaGreen : (diff < 0 ? Color.IndianRed : Color.Orange);

            _shiftStarted = false;
            btnStartShift.Enabled = true;

            string report =
                "BÁO CÁO KẾT CA TIỀN MẶT\n" +
                $"Thời gian: {DateTime.Now:HH:mm dd/MM/yyyy}\n" +
                $"Thu ngân: {GlobalSession.CurrentUser?.FullName ?? GlobalSession.CurrentUser?.EmployeeId}\n" +
                "──────────────────\n" +
                $"• Tiền đầu ca: {_openCash:N0} đ\n" +
                $"• Tiền mặt thu trong ca: {_cashIn:N0} đ\n" +
                $"• Doanh thu ca (mọi hình thức): {_revenue:N0} đ\n" +
                $"• Sổ sách: {expected:N0} đ · Thực đếm: {counted:N0} đ\n" +
                $"• Chênh lệch: {diff:N0} đ";

            var (ok, msg) = await ManagerReport.SendAsync(report, "ket_ca", "cash");
            MsgBox.Show(MsgBox.OwnerWindow(this),
                report + "\n──────────────────\n" + (ok ? msg : $"⚠ {msg}"),
                "Kết ca", diff == 0 ? MsgBox.MessageBoxType.Success : MsgBox.MessageBoxType.Warning);
        }
    }
}
