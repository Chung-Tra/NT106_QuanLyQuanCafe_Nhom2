using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace GUI
{
#pragma warning disable IDE1006
    public partial class ucAlert_Barista : UserControl
#pragma warning restore IDE1006
    {
        public ucAlert_Barista()
        {
            InitializeComponent();
            GridColumnGuard.SyncColumnNames(dgvAlertHistory);
            DgvRefresh.Attach(dgvAlertHistory, LoadMockData);

            // Double-click 1 cảnh báo -> form chi tiết read-only
            dgvAlertHistory.CellDoubleClick += (s, e) =>
            {
                if (e.RowIndex < 0) return;
                RecordDetail.FromRow(dgvAlertHistory.Rows[e.RowIndex], "Chi tiết cảnh báo")
                            .ShowDialog(MsgBox.OwnerWindow(this));
            };
        }

        private void UcAlert_Barista_Load(object? sender, EventArgs e) => LoadMockData();

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
            // "Nội dung" là cột dài nhất → phải RỘNG nhất. Set cho mọi cột, vì nếu chỉ set
            // riêng "Nội dung"=35 thì 3 cột kia giữ mặc định 100 → Nội dung hoá hẹp nhất, cắt chữ.
            dgvAlertHistory.Columns["Thời gian"].FillWeight  = 20;
            dgvAlertHistory.Columns["Loại"].FillWeight       = 22;
            dgvAlertHistory.Columns["Nội dung"].FillWeight   = 42;
            dgvAlertHistory.Columns["Trạng thái"].FillWeight = 16;
        }

        private void BtnReport_Click(object? sender, EventArgs e)
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
                "BÁO CÁO CẢNH BÁO\n" +
                $"Thời gian: {DateTime.Now:HH:mm dd/MM/yyyy}\n" +
                "──────────────────\n" +
                $"• Tổng cảnh báo: {totalAlerts}\n" +
                $"• Đang chờ xử lý: {pendingAlerts}\n" +
                $"• Đã xử lý: {totalAlerts - pendingAlerts}\n" +
                "──────────────────\n" +
                "Gửi báo cáo cho quản lý qua Chat?";

            var result = MsgBox.Show(MsgBox.OwnerWindow(this), report, "Báo cáo cảnh báo", MsgBox.MessageBoxType.Warning);

            if (result == DialogResult.Yes)
            {
                MsgBox.Show(
                    MsgBox.OwnerWindow(this),
                    "Đã gửi báo cáo cho quản lý!\nQuản lý sẽ duyệt qua Chat nội bộ.",
                    "Thành công", MsgBox.MessageBoxType.Success);
            }
        }

        private void BtnSendAlert_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMessage.Text))
            {
                MsgBox.Show(MsgBox.OwnerWindow(this), "Vui lòng nhập nội dung cảnh báo!", "Thông báo", MsgBox.MessageBoxType.Warning);
                return;
            }

            string alertType = cmbAlertType.SelectedItem?.ToString() ?? "Khác";
            MsgBox.Show(
                MsgBox.OwnerWindow(this),
                $"Đã gửi cảnh báo [{alertType}] đến quản lý!\nNội dung: {txtMessage.Text}",
                "Gửi thành công", MsgBox.MessageBoxType.Success);

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
