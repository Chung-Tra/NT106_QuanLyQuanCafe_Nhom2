using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace GUI
{
    public partial class ucAlert_Barista : UserControl
    {
        public ucAlert_Barista()
        {
            InitializeComponent();
            btnReport.Click += btnReport_Click;
            this.Load += (s, e) => LoadMockData();
        }

        private void LoadMockData()
        {
            cmbAlertType.SelectedIndex = 0;

            DataTable dt = new();
            dt.Columns.Add("Thời gian");
            dt.Columns.Add("Loại");
            dt.Columns.Add("Nội dung");
            dt.Columns.Add("Trạng thái");

            dt.Rows.Add("02/05/2026 10:30", "Hết nguyên liệu", "Sữa tươi đã hết, cần bổ sung gấp", "Đã xử lý");
            dt.Rows.Add("02/05/2026 09:15", "Thiết bị hỏng", "Máy xay sinh tố #2 bị kẹt", "Chờ xử lý");
            dt.Rows.Add("01/05/2026 14:20", "Sắp hết nguyên liệu", "Bột cacao còn dưới 500g", "Đã xử lý");
            dt.Rows.Add("01/05/2026 08:00", "Hết nguyên liệu", "Đá viên đã hết", "Đã xử lý");
            dt.Rows.Add("30/04/2026 16:45", "Khác", "Cần vệ sinh máy pha cà phê", "Đã xử lý");

            dgvAlertHistory.DataSource = dt;
            dgvAlertHistory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvAlertHistory.RowHeadersVisible = false;
            dgvAlertHistory.Columns["Nội dung"].FillWeight = 35;
        }

        private void btnReport_Click(object? sender, EventArgs e)
        {
            int totalAlerts = 0;
            int pendingAlerts = 0;
            if (dgvAlertHistory.DataSource is DataTable dt)
            {
                totalAlerts = dt.Rows.Count;
                foreach (DataRow row in dt.Rows)
                {
                    if (row["Trạng thái"]?.ToString() == "Chờ xử lý")
                        pendingAlerts++;
                }
            }

            string report =
                $"BÁO CÁO CẢNH BÁO\n" +
                $"Thời gian: {DateTime.Now:HH:mm dd/MM/yyyy}\n" +
                $"──────────────────\n" +
                $"• Tổng cảnh báo: {totalAlerts}\n" +
                $"• Đang chờ xử lý: {pendingAlerts}\n" +
                $"• Đã xử lý: {totalAlerts - pendingAlerts}\n" +
                $"──────────────────\n" +
                $"Gửi báo cáo cho quản lý qua Chat?";

            var result = MessageBox.Show(report, "Báo cáo cảnh báo",
                MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (result == DialogResult.Yes)
            {
                MsgBox.Show(
                    "Đã gửi báo cáo cho quản lý!\nQuản lý sẽ duyệt qua Chat nội bộ.",
                    "Thành công", MsgBox.MessageBoxType.Success);
            }
        }

        private void btnSendAlert_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMessage.Text))
            {
                MsgBox.Show("Vui lòng nhập nội dung cảnh báo!", "Thông báo", MsgBox.MessageBoxType.Warning);
                return;
            }

            string alertType = cmbAlertType.SelectedItem?.ToString() ?? "Khác";
            MsgBox.Show($"Đã gửi cảnh báo [{alertType}] đến quản lý!\nNội dung: {txtMessage.Text}", "Gửi thành công", MsgBox.MessageBoxType.Success);

            // Add to grid
            if (dgvAlertHistory.DataSource is DataTable dt)
            {
                DataRow newRow = dt.NewRow();
                newRow["Thời gian"] = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
                newRow["Loại"] = alertType;
                newRow["Nội dung"] = txtMessage.Text;
                newRow["Trạng thái"] = "Chờ xử lý";
                dt.Rows.InsertAt(newRow, 0);
            }

            txtMessage.Clear();
        }
    }
}
