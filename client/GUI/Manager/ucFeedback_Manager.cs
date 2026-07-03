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
    public partial class ucFeedback_Manager : UserControl
    {
        public ucFeedback_Manager()
        {
            InitializeComponent();
            GridColumnGuard.SyncColumnNames(dgvFeedback);
            DgvRefresh.Attach(dgvFeedback, () => _ = LoadRealData());
            this.Load += (s, e) => _ = LoadRealData();
        }

        private static string StarString(int rating)
        {
            rating = Math.Max(0, Math.Min(5, rating));
            return new string('★', rating) + new string('☆', 5 - rating);
        }

        private static string StatusOf(FeedbackDTO f)
            => f.IsHandled ? "Đã xử lý" : (!string.IsNullOrWhiteSpace(f.Reply) ? "Đã trả lời" : "Chờ xử lý");

        private async Task LoadRealData()
        {
            DataTable dt = new();
            dt.Columns.Add("Mã");
            dt.Columns.Add("Khách hàng");
            dt.Columns.Add("Ngày");
            dt.Columns.Add("Đánh giá");
            dt.Columns.Add("Nội dung");
            dt.Columns.Add("Trạng thái");

            try
            {
                var fbs = await FeedbackBUS.GetAll();
                foreach (var kv in fbs.OrderByDescending(f => f.Value.Timestamp))
                {
                    var f = kv.Value;
                    string date = f.Timestamp > 0
                        ? DateTimeOffset.FromUnixTimeMilliseconds(f.Timestamp).LocalDateTime.ToString("dd/MM/yyyy")
                        : "";
                    dt.Rows.Add(kv.Key, f.CustomerName, date, StarString(f.Rating), f.Content, StatusOf(f));
                }
            }
            catch { /* offline */ }

            dgvFeedback.DataSource = dt;
            dgvFeedback.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvFeedback.RowHeadersVisible = false;

            dgvFeedback.Columns["Mã"].FillWeight         = 7;
            dgvFeedback.Columns["Khách hàng"].FillWeight = 18;
            dgvFeedback.Columns["Ngày"].FillWeight       = 11;
            dgvFeedback.Columns["Đánh giá"].FillWeight   = 13;
            dgvFeedback.Columns["Nội dung"].FillWeight   = 35;
            dgvFeedback.Columns["Trạng thái"].FillWeight = 16;

            dgvFeedback.Columns["Mã"].DefaultCellStyle.Alignment         = DataGridViewContentAlignment.MiddleCenter;
            dgvFeedback.Columns["Ngày"].DefaultCellStyle.Alignment       = DataGridViewContentAlignment.MiddleCenter;
            dgvFeedback.Columns["Đánh giá"].DefaultCellStyle.Alignment   = DataGridViewContentAlignment.MiddleCenter;
            dgvFeedback.Columns["Trạng thái"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private void dgvFeedback_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvFeedback.CurrentRow == null) return;
            var row = dgvFeedback.CurrentRow;
            lblCustomerName.Text = "Khách hàng: " + (row.Cells["Khách hàng"].Value?.ToString() ?? "---");
            lblDate.Text = "Ngày: " + (row.Cells["Ngày"].Value?.ToString() ?? "---");
            lblRating.Text = row.Cells["Đánh giá"].Value?.ToString() ?? "---";
            txtContent.Text = row.Cells["Nội dung"].Value?.ToString() ?? "";
        }

        // Double-click 1 dòng -> form chi tiết read-only đủ field
        private void DgvFeedback_CellDoubleClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            RecordDetail.FromRow(dgvFeedback.Rows[e.RowIndex], "Chi tiết phản hồi")
                        .ShowDialog(MsgBox.OwnerWindow(this));
        }

        // Sửa dòng đang chọn (khoá cột Mã) — lưu thật
        private async void BtnEditFeedback_Click(object? sender, EventArgs e)
        {
            if (dgvFeedback.CurrentRow == null || dgvFeedback.CurrentRow.Index < 0)
            {
                MsgBox.Show(MsgBox.OwnerWindow(this), "Vui lòng chọn một phản hồi để sửa!", "Thông báo", MsgBox.MessageBoxType.Warning);
                return;
            }
            string id = dgvFeedback.CurrentRow.Cells["Mã"].Value?.ToString() ?? "";
            if (RecordEdit.EditRow(dgvFeedback.CurrentRow, "Sửa phản hồi", MsgBox.OwnerWindow(this)))
            {
                string content = dgvFeedback.CurrentRow.Cells["Nội dung"].Value?.ToString() ?? "";
                await FeedbackBUS.Update(id, new { noi_dung = content });
                await LoadRealData();
            }
        }

        private async void btnReply_Click(object sender, EventArgs e)
        {
            if (dgvFeedback.CurrentRow == null) return;
            string id = dgvFeedback.CurrentRow.Cells["Mã"].Value?.ToString() ?? "";
            string customer = dgvFeedback.CurrentRow.Cells["Khách hàng"].Value?.ToString() ?? "";
            string content = dgvFeedback.CurrentRow.Cells["Nội dung"].Value?.ToString() ?? "";
            ReplyFeedback frm = new(customer, content);
            if (frm.ShowDialog(MsgBox.OwnerWindow(this)) == DialogResult.OK)
            {
                var (ok, msg) = await FeedbackBUS.Update(id, new
                {
                    phan_hoi = frm.ReplyText,
                    thoi_gian_phan_hoi = DateTimeOffset.Now.ToUnixTimeMilliseconds(),
                    nguoi_xu_ly_id = GlobalSession.CurrentUser?.EmployeeId ?? "",
                    da_xu_ly = true
                });
                if (ok)
                {
                    MsgBox.Show(MsgBox.OwnerWindow(this), $"Đã gửi phản hồi đến khách hàng {customer}!", "Thành công", MsgBox.MessageBoxType.Success);
                    await LoadRealData();
                }
                else MsgBox.Show(MsgBox.OwnerWindow(this), msg, "Lỗi", MsgBox.MessageBoxType.Error);
            }
        }
    }
}
