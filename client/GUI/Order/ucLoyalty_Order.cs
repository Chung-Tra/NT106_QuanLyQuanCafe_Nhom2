using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace GUI
{
    public partial class ucLoyalty_Order : UserControl
    {
        public ucLoyalty_Order()
        {
            InitializeComponent();
            Theme.StyleGrid(dgvTier);
            Theme.StyleGrid(dgvHistory);
            LoadData();

            // Double-click 1 dòng -> form chi tiết read-only đủ field
            dgvTier.CellDoubleClick    += (s, e) => ShowDetail(dgvTier, e, "Chi tiết hạng thành viên");
            dgvHistory.CellDoubleClick += (s, e) => ShowDetail(dgvHistory, e, "Chi tiết giao dịch điểm");

            // Nút làm mới từng bảng (LoadData nạp lại cả hai bảng, nhẹ vì là mock)
            DgvRefresh.Attach(dgvTier, LoadData);
            DgvRefresh.Attach(dgvHistory, LoadData);
        }

        private void ShowDetail(DataGridView dgv, DataGridViewCellEventArgs e, string title)
        {
            if (e.RowIndex < 0) return;
            RecordDetail.FromRow(dgv.Rows[e.RowIndex], title).ShowDialog(MsgBox.OwnerWindow(this));
        }

        private void LoadData()
        {
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

            var dtHist = new DataTable();
            dtHist.Columns.Add("Ngày");
            dtHist.Columns.Add("Thao tác");
            dtHist.Columns.Add("Điểm", typeof(int));
            dtHist.Columns.Add("Ghi chú");
            dtHist.Rows.Add("22/06/2026", "+", 45, "Đơn #HD0622 — 135,000đ");
            dtHist.Rows.Add("18/06/2026", "+", 60, "Đơn #HD0618 — 180,000đ");
            dtHist.Rows.Add("15/06/2026", "–", 200, "Đổi 1 nước miễn phí");
            dtHist.Rows.Add("10/06/2026", "+", 35, "Đơn #HD0610 — 105,000đ");
            dtHist.Rows.Add("05/06/2026", "+", 50, "Đơn #HD0605 — 150,000đ");
            dgvHistory.DataSource = dtHist;
            // Đồng bộ Name == DataPropertyName để Cells["Thao tác"]/["Điểm"] không null nếu
            // VS đã đổi Name cột thành col*.
            GridColumnGuard.SyncColumnNames(dgvHistory);
            dgvHistory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            foreach (DataGridViewRow r in dgvHistory.Rows)
            {
                string op = r.Cells["Thao tác"].Value?.ToString() ?? "";
                r.Cells["Thao tác"].Style.ForeColor = op == "+" ? Theme.Green : Theme.Red;
                r.Cells["Điểm"].Style.ForeColor     = op == "+" ? Theme.Green : Theme.Red;
            }
        }

        private void BtnSearch_Click(object? sender, EventArgs e)
        {
            string phone = txtPhone.Text.Trim();
            if (string.IsNullOrEmpty(phone) || phone.Length < 9)
            {
                MsgBox.Show(MsgBox.OwnerWindow(this), "Vui lòng nhập số điện thoại hợp lệ!", "Thông báo", MsgBox.MessageBoxType.Warning);
                return;
            }

            // Ẩn hint, hiện panel khách
            hintCard.Visible = false;

            // Cập nhật thông tin giả lập
            lblPhone.Text = phone;

            pnlCustomer.Visible = true;
        }

        private void BtnRegister_Click(object? sender, EventArgs e)
        {
            string? name = InputDialog.Show(MsgBox.OwnerWindow(this), "Đăng ký thành viên mới", "Họ tên khách hàng", "VD: Nguyễn Văn A");
            if (string.IsNullOrEmpty(name)) return;
            MsgBox.Show(MsgBox.OwnerWindow(this), $"Đã đăng ký thành viên mới:\n{name}  —  SĐT: {txtPhone.Text.Trim()}\nHạng: 🥉 Đồng  |  Điểm: 0", "Đăng ký thành công", MsgBox.MessageBoxType.Success);
        }

        private void BtnAddPoints_Click(object? sender, EventArgs e)
        {
            string? amtStr = InputDialog.Show(MsgBox.OwnerWindow(this), "Tích điểm", "Số tiền hóa đơn (đồng)", "VD: 150000");
            if (string.IsNullOrEmpty(amtStr)) return;
            if (!long.TryParse(amtStr.Replace(",", "").Replace(".", ""), out long amt)) return;
            int pts = (int)(amt / 3000);
            MsgBox.Show(MsgBox.OwnerWindow(this), $"Đã tích {pts} điểm cho hóa đơn {amt:#,##0}đ!", "Tích điểm thành công", MsgBox.MessageBoxType.Success);
        }

        private void BtnRedeem_Click(object? sender, EventArgs e)
        {
            MsgBox.Show(MsgBox.OwnerWindow(this),
                "Danh sách quà có thể đổi:\n• 100 điểm → Giảm 5,000đ\n• 200 điểm → 1 nước nhỏ miễn phí\n• 500 điểm → Giảm 25,000đ\n\nTính năng đổi quà đang hoàn thiện.",
                "Đổi điểm lấy quà", MsgBox.MessageBoxType.Info);
        }
    }
}
