using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace GUI
{
    public partial class ucLeaveRequest : UserControl
    {
        public ucLeaveRequest()
        {
            InitializeComponent();
            this.Load += (s, e) => LoadMockData();
            btnSubmit.Click += btnSubmit_Click;
            btnReport.Click += btnReport_Click;
        }

        private void LoadMockData()
        {
            lblRemainingValue.Text = "8 ngày";
            lblPendingValue.Text = "1 đơn";

            DataTable dt = new();
            dt.Columns.Add("Từ ngày");
            dt.Columns.Add("Đến ngày");
            dt.Columns.Add("Số ngày", typeof(int));
            dt.Columns.Add("Lý do");
            dt.Columns.Add("Trạng thái");

            dt.Rows.Add("15/04/2026", "16/04/2026", 2, "Việc gia đình", "Đã duyệt");
            dt.Rows.Add("20/03/2026", "20/03/2026", 1, "Khám bệnh", "Đã duyệt");
            dt.Rows.Add("10/03/2026", "10/03/2026", 1, "Việc cá nhân", "Đã duyệt");
            dt.Rows.Add("05/05/2026", "05/05/2026", 1, "Đi thi", "Chờ duyệt");

            dgvHistory.DataSource = dt;
            dgvHistory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvHistory.RowHeadersVisible = false;
            dgvHistory.ReadOnly = true;
            dgvHistory.AllowUserToAddRows = false;
            dgvHistory.Columns["Lý do"].FillWeight = 30;

            foreach (DataGridViewRow row in dgvHistory.Rows)
            {
                string status = row.Cells["Trạng thái"].Value?.ToString() ?? "";
                if (status == "Đã duyệt")
                    row.DefaultCellStyle.ForeColor = Color.MediumSeaGreen;
                else if (status == "Chờ duyệt")
                    row.DefaultCellStyle.ForeColor = Color.Orange;
                else if (status == "Từ chối")
                    row.DefaultCellStyle.ForeColor = Color.IndianRed;
            }
        }

        private void btnSubmit_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtReason.Text))
            {
                MsgBox.Show("Vui lòng nhập lý do nghỉ phép!", "Thông báo", MsgBox.MessageBoxType.Warning);
                return;
            }

            if (dtpToDate.Value < dtpFromDate.Value)
            {
                MsgBox.Show("Ngày kết thúc phải sau ngày bắt đầu!", "Thông báo", MsgBox.MessageBoxType.Warning);
                return;
            }

            int days = (dtpToDate.Value - dtpFromDate.Value).Days + 1;

            if (dgvHistory.DataSource is DataTable dt)
            {
                DataRow newRow = dt.NewRow();
                newRow["Từ ngày"] = dtpFromDate.Value.ToString("dd/MM/yyyy");
                newRow["Đến ngày"] = dtpToDate.Value.ToString("dd/MM/yyyy");
                newRow["Số ngày"] = days;
                newRow["Lý do"] = txtReason.Text;
                newRow["Trạng thái"] = "Chờ duyệt";
                dt.Rows.InsertAt(newRow, 0);
            }

            MsgBox.Show($"Đã gửi đơn xin nghỉ {days} ngày!\nTừ: {dtpFromDate.Value:dd/MM/yyyy}\nĐến: {dtpToDate.Value:dd/MM/yyyy}", "Gửi thành công", MsgBox.MessageBoxType.Success);
            txtReason.Clear();
        }

        private void btnReport_Click(object? sender, EventArgs e)
        {
            string report =
                $"BÁO CÁO NGHỈ PHÉP\n" +
                $"──────────────────\n" +
                $"• Ngày phép còn lại: {lblRemainingValue.Text}\n" +
                $"• Đang chờ duyệt: {lblPendingValue.Text}\n" +
                $"──────────────────\n" +
                $"Gửi báo cáo cho quản lý qua Chat?";

            var result = MessageBox.Show(report, "Báo cáo nghỉ phép",
                MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (result == DialogResult.Yes)
            {
                MsgBox.Show(
                    "Đã gửi báo cáo cho quản lý!\nQuản lý sẽ duyệt qua Chat nội bộ.",
                    "Thành công", MsgBox.MessageBoxType.Success);
            }
        }
    }
}
