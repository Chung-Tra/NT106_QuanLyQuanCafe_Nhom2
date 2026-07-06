using BUS;
using DTO;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace GUI
{
    public partial class ucLoyalty_Order : UserControl
    {
        private string? _currentCustomerId;
        private CustomerDTO? _currentCustomer;

        public ucLoyalty_Order()
        {
            InitializeComponent();
            Theme.StyleGrid(dgvTier);
            Theme.StyleGrid(dgvHistory);
            LoadData();

            // Double-click 1 dòng -> form chi tiết read-only đủ field
            dgvTier.CellDoubleClick    += (s, e) => ShowDetail(dgvTier, e, "Chi tiết hạng thành viên");
            dgvHistory.CellDoubleClick += (s, e) => ShowDetail(dgvHistory, e, "Chi tiết giao dịch điểm");

            // Nút làm mới: bảng hạng là cấu hình cố định; bảng lịch sử nạp lại theo khách đang chọn.
            DgvRefresh.Attach(dgvTier, LoadData);
            DgvRefresh.Attach(dgvHistory, () =>
            {
                if (_currentCustomerId != null) _ = LoadHistoryAsync(_currentCustomerId);
                else RenderHistory(System.Linq.Enumerable.Empty<PointLogDTO>());
            });
        }

        private void ShowDetail(DataGridView dgv, DataGridViewCellEventArgs e, string title)
        {
            if (e.RowIndex < 0) return;
            RecordDetail.FromRow(dgv.Rows[e.RowIndex], title).ShowDialog(MsgBox.OwnerWindow(this));
        }

        private void LoadData()
        {
            // Hạng thành viên = cấu hình nghiệp vụ (ngưỡng điểm + ưu đãi), không phải dữ liệu mock.
            var dtTier = new DataTable();
            dtTier.Columns.Add("Hạng");
            dtTier.Columns.Add("Điểm yêu cầu");
            dtTier.Columns.Add("Ưu đãi");
            dtTier.Rows.Add("🥉  Đồng",    "0 – 499",    "Không có");
            dtTier.Rows.Add("🥈  Bạc",     "500 – 999",  "Giảm 5%");
            dtTier.Rows.Add("🥇  Vàng",    "1000 – 2499","Giảm 10% + 1 nước miễn phí/tháng");
            dtTier.Rows.Add("💎  Kim cương","2500+",      "Giảm 15% + sinh nhật free");
            dgvTier.DataSource = dtTier;
            dgvTier.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Lịch sử điểm trống đến khi tra cứu 1 khách hàng cụ thể.
            RenderHistory(System.Linq.Enumerable.Empty<PointLogDTO>());
        }

        // Vẽ bảng lịch sử điểm từ các giao dịch THẬT (node point-logs) của khách đang chọn.
        private void RenderHistory(System.Collections.Generic.IEnumerable<PointLogDTO> logs)
        {
            var dtHist = new DataTable();
            dtHist.Columns.Add("Ngày");
            dtHist.Columns.Add("Thao tác");
            dtHist.Columns.Add("Điểm", typeof(int));
            dtHist.Columns.Add("Ghi chú");
            foreach (var l in logs.OrderByDescending(x => x.Timestamp))
            {
                string day = l.Timestamp > 0
                    ? DateTimeOffset.FromUnixTimeMilliseconds(l.Timestamp).LocalDateTime.ToString("dd/MM/yyyy")
                    : "";
                dtHist.Rows.Add(day, l.Delta >= 0 ? "+" : "–", Math.Abs(l.Delta), l.Note ?? "");
            }
            dgvHistory.DataSource = dtHist;
            GridColumnGuard.SyncColumnNames(dgvHistory);
            dgvHistory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            foreach (DataGridViewRow r in dgvHistory.Rows)
            {
                string op = r.Cells["Thao tác"].Value?.ToString() ?? "";
                r.Cells["Thao tác"].Style.ForeColor = op == "+" ? Theme.Green : Theme.Red;
                r.Cells["Điểm"].Style.ForeColor     = op == "+" ? Theme.Green : Theme.Red;
            }
        }

        private async Task LoadHistoryAsync(string customerId)
        {
            try
            {
                var logs = (await PointLogBUS.GetAll()).Values.Where(l => l.CustomerId == customerId);
                RenderHistory(logs);
            }
            catch { RenderHistory(System.Linq.Enumerable.Empty<PointLogDTO>()); }
        }

        private static string TierName(int p) =>
            p >= 2500 ? "💎 Kim cương" : p >= 1000 ? "🥇 Vàng" : p >= 500 ? "🥈 Bạc" : "🥉 Đồng";

        private void ShowCustomer(CustomerDTO c, string id)
        {
            _currentCustomer = c;
            _currentCustomerId = id;
            hintCard.Visible = false;
            pnlCustomer.Visible = true;
            lblName.Text = c.Name ?? "(khách)";
            lblPhone.Text = c.PhoneNumber ?? "";
            lblTier.Text = TierName(c.LoyaltyPoints);
            lblPoints.Text = c.LoyaltyPoints.ToString("N0");
            lblVisits.Text = $"{c.TotalOrders} đơn";
            _ = LoadHistoryAsync(id);   // lịch sử điểm THẬT của khách này
        }

        private async void BtnSearch_Click(object? sender, EventArgs e)
        {
            string phone = txtPhone.Text.Trim();
            if (string.IsNullOrEmpty(phone) || phone.Length < 9)
            {
                MsgBox.Show(MsgBox.OwnerWindow(this), "Vui lòng nhập số điện thoại hợp lệ!", "Thông báo", MsgBox.MessageBoxType.Warning);
                return;
            }

            try
            {
                var customers = await CustomerBUS.GetAll();
                var hit = customers.FirstOrDefault(kv => kv.Value.PhoneNumber == phone);
                if (hit.Value != null)
                {
                    ShowCustomer(hit.Value, hit.Key);
                }
                else
                {
                    _currentCustomer = null;
                    _currentCustomerId = null;
                    pnlCustomer.Visible = false;
                    hintCard.Visible = true;
                    if (MsgBox.Show(MsgBox.OwnerWindow(this), "Không tìm thấy khách hàng với SĐT này.\nĐăng ký thành viên mới?", "Không tìm thấy", MsgBox.MessageBoxType.Warning) == DialogResult.Yes)
                        BtnRegister_Click(sender, e);
                }
            }
            catch (Exception ex)
            {
                MsgBox.Show(MsgBox.OwnerWindow(this), "Lỗi tải khách hàng: " + ex.Message, "Lỗi", MsgBox.MessageBoxType.Error);
            }
        }

        private async void BtnRegister_Click(object? sender, EventArgs e)
        {
            string phone = txtPhone.Text.Trim();
            string? name = InputDialog.Show(MsgBox.OwnerWindow(this), "Đăng ký thành viên mới", "Họ tên khách hàng", "VD: Nguyễn Văn A");
            if (string.IsNullOrEmpty(name)) return;

            var dto = new CustomerDTO
            {
                Name = name,
                PhoneNumber = phone,
                Email = "",
                LoyaltyPoints = 0,
                TotalOrders = 0,
                CreatedAt = DateTimeOffset.Now.ToUnixTimeMilliseconds()
            };
            var (ok, msg, id) = await CustomerBUS.Add(dto);
            if (ok)
            {
                MsgBox.Show(MsgBox.OwnerWindow(this), $"Đã đăng ký thành viên mới:\n{name} — SĐT: {phone}\nHạng: 🥉 Đồng | Điểm: 0", "Đăng ký thành công", MsgBox.MessageBoxType.Success);
                if (id != null) ShowCustomer(dto, id);
            }
            else MsgBox.Show(MsgBox.OwnerWindow(this), msg, "Lỗi đăng ký", MsgBox.MessageBoxType.Error);
        }

        private async void BtnAddPoints_Click(object? sender, EventArgs e)
        {
            if (_currentCustomer == null || _currentCustomerId == null)
            {
                MsgBox.Show(MsgBox.OwnerWindow(this), "Vui lòng tìm khách hàng trước khi tích điểm.", "Thông báo", MsgBox.MessageBoxType.Warning);
                return;
            }
            string? amtStr = InputDialog.Show(MsgBox.OwnerWindow(this), "Tích điểm", "Số tiền hóa đơn (đồng)", "VD: 150000");
            if (string.IsNullOrEmpty(amtStr)) return;
            long amt = AppMath.ParseVndDigits(amtStr);
            if (amt <= 0) return;

            int pts = AppMath.LoyaltyPoints(amt);
            int newPoints = _currentCustomer.LoyaltyPoints + pts;
            int newOrders = _currentCustomer.TotalOrders + 1;
            var (ok, msg) = await CustomerBUS.Update(_currentCustomerId, new { diem_tich_luy = newPoints, tong_don = newOrders });
            if (ok)
            {
                _currentCustomer.LoyaltyPoints = newPoints;
                _currentCustomer.TotalOrders = newOrders;
                await PointLogBUS.Add(new PointLogDTO
                {
                    CustomerId = _currentCustomerId,
                    Delta = pts,
                    Note = $"Tích điểm hóa đơn {amt:#,##0}đ",
                    Timestamp = DateTimeOffset.Now.ToUnixTimeMilliseconds()
                });
                ShowCustomer(_currentCustomer, _currentCustomerId);   // reload lịch sử gồm giao dịch mới
                MsgBox.Show(MsgBox.OwnerWindow(this), $"Đã tích {pts} điểm cho hóa đơn {amt:#,##0}đ!\nTổng điểm: {newPoints:N0}", "Tích điểm thành công", MsgBox.MessageBoxType.Success);
            }
            else MsgBox.Show(MsgBox.OwnerWindow(this), msg, "Lỗi", MsgBox.MessageBoxType.Error);
        }

        private async void BtnRedeem_Click(object? sender, EventArgs e)
        {
            if (_currentCustomer == null || _currentCustomerId == null)
            {
                MsgBox.Show(MsgBox.OwnerWindow(this), "Vui lòng tìm khách hàng trước khi đổi quà.", "Thông báo", MsgBox.MessageBoxType.Warning);
                return;
            }
            string? redeemStr = InputDialog.Show(MsgBox.OwnerWindow(this),
                "Đổi điểm lấy quà",
                $"Điểm hiện có: {_currentCustomer.LoyaltyPoints:N0}\n• 100đ → Giảm 5,000đ\n• 200đ → 1 nước nhỏ\n• 500đ → Giảm 25,000đ\nNhập số điểm muốn đổi:",
                "VD: 100");
            if (string.IsNullOrEmpty(redeemStr)) return;
            if (!int.TryParse(redeemStr.Replace(",", "").Replace(".", ""), out int redeem) || redeem <= 0) return;

            if (redeem > _currentCustomer.LoyaltyPoints)
            {
                MsgBox.Show(MsgBox.OwnerWindow(this), "Số điểm không đủ để đổi!", "Thông báo", MsgBox.MessageBoxType.Warning);
                return;
            }

            int newPoints = _currentCustomer.LoyaltyPoints - redeem;
            var (ok, msg) = await CustomerBUS.Update(_currentCustomerId, new { diem_tich_luy = newPoints });
            if (ok)
            {
                _currentCustomer.LoyaltyPoints = newPoints;
                await PointLogBUS.Add(new PointLogDTO
                {
                    CustomerId = _currentCustomerId,
                    Delta = -redeem,
                    Note = "Đổi điểm lấy quà",
                    Timestamp = DateTimeOffset.Now.ToUnixTimeMilliseconds()
                });
                ShowCustomer(_currentCustomer, _currentCustomerId);
                MsgBox.Show(MsgBox.OwnerWindow(this), $"Đã đổi {redeem} điểm!\nĐiểm còn lại: {newPoints:N0}", "Đổi quà thành công", MsgBox.MessageBoxType.Success);
            }
            else MsgBox.Show(MsgBox.OwnerWindow(this), msg, "Lỗi", MsgBox.MessageBoxType.Error);
        }
    }
}
