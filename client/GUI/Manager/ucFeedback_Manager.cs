using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace GUI
{
    public partial class ucFeedback_Manager : UserControl
    {
        public ucFeedback_Manager()
        {
            InitializeComponent();
            GridColumnGuard.SyncColumnNames(dgvFeedback);
            DgvRefresh.Attach(dgvFeedback, LoadMockData);
            this.Load += (s, e) => LoadMockData();
        }

        private void LoadMockData()
        {
            DataTable dt = new();
            dt.Columns.Add("Mã");
            dt.Columns.Add("Khách hàng");
            dt.Columns.Add("Ngày");
            dt.Columns.Add("Đánh giá");
            dt.Columns.Add("Nội dung");
            dt.Columns.Add("Trạng thái");

            dt.Rows.Add("FB001", "Nguyễn Thị Lan", "01/05/2026", "★★★★★", "Cà phê rất ngon, nhân viên thân thiện!", "Đã trả lời");
            dt.Rows.Add("FB002", "Trần Văn Minh", "01/05/2026", "★★★☆☆", "Đồ uống hơi ngọt, cần giảm đường", "Chờ xử lý");
            dt.Rows.Add("FB003", "Lê Hồng Phúc", "30/04/2026", "★★☆☆☆", "Chờ quá lâu, nhân viên không nhiệt tình", "Chờ xử lý");
            dt.Rows.Add("FB004", "Phạm Thanh Hà", "29/04/2026", "★★★★☆", "Không gian đẹp, wifi mạnh", "Đã trả lời");

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

        // Sửa dòng đang chọn (khoá cột Mã)
        private void BtnEditFeedback_Click(object? sender, EventArgs e)
        {
            if (dgvFeedback.CurrentRow == null || dgvFeedback.CurrentRow.Index < 0)
            {
                MsgBox.Show(MsgBox.OwnerWindow(this), "Vui lòng chọn một phản hồi để sửa!", "Thông báo", MsgBox.MessageBoxType.Warning);
                return;
            }
            if (RecordEdit.EditRow(dgvFeedback.CurrentRow, "Sửa phản hồi", MsgBox.OwnerWindow(this)))
                dgvFeedback_SelectionChanged(dgvFeedback, EventArgs.Empty);
        }

        private void btnReply_Click(object sender, EventArgs e)
        {
            if (dgvFeedback.CurrentRow == null) return;
            string customer = dgvFeedback.CurrentRow.Cells["Khách hàng"].Value?.ToString() ?? "";
            string content = dgvFeedback.CurrentRow.Cells["Nội dung"].Value?.ToString() ?? "";
            ReplyFeedback frm = new(customer, content);
            if (frm.ShowDialog(MsgBox.OwnerWindow(this)) == DialogResult.OK)
            {
                dgvFeedback.CurrentRow.Cells["Trạng thái"].Value = "Đã trả lời";
                MsgBox.Show(MsgBox.OwnerWindow(this), $"Đã gửi phản hồi đến khách hàng {customer}!", "Thành công", MsgBox.MessageBoxType.Success);
            }
        }
    }
}
