using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace GUI
{
    public partial class ucSOS_Security : UserControl
    {
        public ucSOS_Security()
        {
            InitializeComponent();
            btnReport.Click += btnReport_Click;
            this.Load += (s, e) => LoadMockData();
        }

        private void LoadMockData()
        {
            DataTable dt = new();
            dt.Columns.Add("Thời gian");
            dt.Columns.Add("Loại sự cố");
            dt.Columns.Add("Mô tả");
            dt.Columns.Add("Người báo");
            dt.Columns.Add("Trạng thái");

            dt.Rows.Add("01/05/2026 22:30", "An ninh", "Khách hàng gây rối tại quầy bar", "Nguyễn Văn Tuấn", "Đã xử lý");
            dt.Rows.Add("30/04/2026 15:20", "Y tế", "Nhân viên bị bỏng nước nóng", "Trần Thị Mai", "Đã xử lý");
            dt.Rows.Add("28/04/2026 19:45", "Cháy nổ", "Khói bốc từ khu bếp", "Lê Hoàng Nam", "Đã xử lý");
            dt.Rows.Add("25/04/2026 10:10", "An ninh", "Phát hiện trộm cắp ở khu vực gửi xe", "Phạm Minh Tuấn", "Đã xử lý");

            dgvIncidents.DataSource = dt;
            dgvIncidents.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvIncidents.RowHeadersVisible = false;
            dgvIncidents.Columns["Mô tả"].FillWeight = 30;
        }

        private void btnReport_Click(object? sender, EventArgs e)
        {
            int totalIncidents = 0;
            int activeIncidents = 0;
            if (dgvIncidents.DataSource is DataTable dt)
            {
                totalIncidents = dt.Rows.Count;
                foreach (DataRow row in dt.Rows)
                {
                    if (row["Trạng thái"]?.ToString() == "Đang xử lý")
                        activeIncidents++;
                }
            }

            string report =
                $"BÁO CÁO AN NINH\n" +
                $"Thời gian: {DateTime.Now:HH:mm dd/MM/yyyy}\n" +
                $"──────────────────\n" +
                $"• Tổng sự cố: {totalIncidents}\n" +
                $"• Đang xử lý: {activeIncidents}\n" +
                $"• Đã xử lý: {totalIncidents - activeIncidents}\n" +
                $"──────────────────\n" +
                $"Gửi báo cáo cho quản lý qua Chat?";

            var result = MessageBox.Show(report, "Báo cáo an ninh",
                MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (result == DialogResult.Yes)
            {
                MsgBox.Show(
                    "Đã gửi báo cáo cho quản lý!\nQuản lý sẽ duyệt qua Chat nội bộ.",
                    "Thành công", MsgBox.MessageBoxType.Success);
            }
        }

        private void btnSOS_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show(
                "BẠN CÓ CHẮC MUỐN GỬI TÍN HIỆU KHẨN CẤP?\n\nThao tác này sẽ thông báo ngay đến:\n- Quản lý\n- Tất cả nhân viên bảo vệ\n- Hệ thống giám sát",
                "XÁC NHẬN SOS",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (result == DialogResult.Yes)
            {
                // Add incident to log
                if (dgvIncidents.DataSource is DataTable dt)
                {
                    DataRow newRow = dt.NewRow();
                    newRow["Thời gian"] = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
                    newRow["Loại sự cố"] = "SOS Khẩn cấp";
                    newRow["Mô tả"] = "Tín hiệu SOS được kích hoạt";
                    newRow["Người báo"] = "Bảo vệ trực ca";
                    newRow["Trạng thái"] = "Đang xử lý";
                    dt.Rows.InsertAt(newRow, 0);
                }

                MsgBox.Show("ĐÃ GỬI TÍN HIỆU KHẨN CẤP!\n\nQuản lý và đội bảo vệ đã được thông báo.", "SOS", MsgBox.MessageBoxType.Warning);
            }
        }
    }
}
