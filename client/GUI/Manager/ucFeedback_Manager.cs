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

            if (dgvFeedback.Columns.Contains("Mã"))
                dgvFeedback.Columns["Mã"].FillWeight = 10;
            if (dgvFeedback.Columns.Contains("Nội dung"))
                dgvFeedback.Columns["Nội dung"].FillWeight = 35;
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

        private void btnReply_Click(object sender, EventArgs e)
        {
            if (dgvFeedback.CurrentRow == null) return;
            string customer = dgvFeedback.CurrentRow.Cells["Khách hàng"].Value?.ToString() ?? "";
            string content = dgvFeedback.CurrentRow.Cells["Nội dung"].Value?.ToString() ?? "";
            ReplyFeedback frm = new(customer, content);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                dgvFeedback.CurrentRow.Cells["Trạng thái"].Value = "Đã trả lời";
                MsgBox.Show($"Đã gửi phản hồi đến khách hàng {customer}!", "Thành công", MsgBox.MessageBoxType.Success);
            }
        }
    }
}