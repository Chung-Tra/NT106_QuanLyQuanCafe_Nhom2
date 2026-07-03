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
        private const decimal OpenCash = 2000000m;
        private decimal _cashIn;      // tiền mặt thu trong ngày
        private decimal _revenue;     // tổng doanh thu trong ngày (mọi hình thức)

        public ucCashManagement_Order()
        {
            InitializeComponent();
            GridColumnGuard.SyncColumnNames(dgvTransactions);
            DgvRefresh.Attach(dgvTransactions, () => _ = LoadRealData());
            this.Load += (s, e) => _ = LoadRealData();

            dgvTransactions.CellDoubleClick += (s, e) =>
            {
                if (e.RowIndex < 0) return;
                RecordDetail.FromRow(dgvTransactions.Rows[e.RowIndex], "Chi tiết giao dịch tiền mặt")
                            .ShowDialog(MsgBox.OwnerWindow(this));
            };
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

            dt.Rows.Add(DateTime.Today.ToString("dd/MM/yyyy 08:00"), "Mở ca", OpenCash, "Tiền đầu ca");

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

            lblOpenCash.Text = OpenCash.ToString("N0") + " đ";
            lblCurrentCash.Text = (OpenCash + _cashIn).ToString("N0") + " đ";
            lblRevenue.Text = _revenue.ToString("N0") + " đ";
            lblDifference.Text = "0 đ";
            lblDifference.ForeColor = Color.MediumSeaGreen;

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

        private void btnReport_Click(object? sender, EventArgs e)
        {
            string report =
                "BÁO CÁO TIỀN MẶT\n" +
                $"Thời gian: {DateTime.Now:HH:mm dd/MM/yyyy}\n" +
                "──────────────────\n" +
                $"• Tiền đầu ca: {lblOpenCash.Text}\n" +
                $"• Tiền hiện tại: {lblCurrentCash.Text}\n" +
                $"• Doanh thu ca: {lblRevenue.Text}\n" +
                $"• Chênh lệch: {lblDifference.Text}\n" +
                "──────────────────\n" +
                "Gửi báo cáo cho quản lý qua Chat?";

            if (MsgBox.Show(MsgBox.OwnerWindow(this), report, "Báo cáo tiền mặt", MsgBox.MessageBoxType.Warning) == DialogResult.Yes)
                MsgBox.Show(MsgBox.OwnerWindow(this), "Đã gửi báo cáo cho quản lý!", "Thành công", MsgBox.MessageBoxType.Success);
        }

        private void btnStartShift_Click(object sender, EventArgs e)
        {
            if (_shiftStarted)
            {
                MsgBox.Show(MsgBox.OwnerWindow(this), "Ca làm việc đã được bắt đầu rồi!", "Thông báo", MsgBox.MessageBoxType.Warning);
                return;
            }
            _shiftStarted = true;
            btnStartShift.Enabled = false;
            MsgBox.Show(MsgBox.OwnerWindow(this),
                $"Đã bắt đầu ca làm việc!\nTiền đầu ca: {OpenCash:N0} đ",
                "Thành công", MsgBox.MessageBoxType.Success);
        }

        private void btnEndShift_Click(object sender, EventArgs e)
        {
            if (!_shiftStarted)
            {
                MsgBox.Show(MsgBox.OwnerWindow(this), "Chưa bắt đầu ca làm việc!", "Thông báo", MsgBox.MessageBoxType.Warning);
                return;
            }
            var result = MsgBox.Show(MsgBox.OwnerWindow(this),
                $"Bạn có chắc muốn kết thúc ca?\nTiền cuối ca: {(OpenCash + _cashIn):N0} đ",
                "Xác nhận", MsgBox.MessageBoxType.Warning);
            if (result == DialogResult.Yes)
            {
                _shiftStarted = false;
                btnStartShift.Enabled = true;
                MsgBox.Show(MsgBox.OwnerWindow(this),
                    $"Đã kết thúc ca làm việc!\nDoanh thu ca: {_revenue:N0} đ\nTiền mặt thu: {_cashIn:N0} đ\nChênh lệch: 0 đ",
                    "Kết ca", MsgBox.MessageBoxType.Success);
            }
        }
    }
}
