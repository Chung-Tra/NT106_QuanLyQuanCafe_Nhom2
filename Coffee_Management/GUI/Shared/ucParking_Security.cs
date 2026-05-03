using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace GUI
{
    public partial class ucParking_Security : UserControl
    {
        private int _currentSlots = 15;
        private const int _maxSlots = 30;

        public ucParking_Security()
        {
            InitializeComponent();
            btnReport.Click += btnReport_Click;
            this.Load += (s, e) => LoadMockData();
        }

        private void LoadMockData()
        {
            cmbVehicleType.SelectedIndex = 0;
            UpdateSlots();

            DataTable dt = new();
            dt.Columns.Add("Biển số");
            dt.Columns.Add("Loại xe");
            dt.Columns.Add("Giờ vào");
            dt.Columns.Add("Giờ ra");
            dt.Columns.Add("Trạng thái");

            dt.Rows.Add("59A-12345", "Xe máy", "02/05/2026 07:30", "", "Đang gửi");
            dt.Rows.Add("59C-67890", "Xe máy", "02/05/2026 07:45", "", "Đang gửi");
            dt.Rows.Add("51G-11111", "Ô tô", "02/05/2026 08:00", "", "Đang gửi");
            dt.Rows.Add("59B-22222", "Xe đạp", "02/05/2026 08:10", "", "Đang gửi");
            dt.Rows.Add("59A-33333", "Xe máy", "02/05/2026 06:30", "02/05/2026 07:15", "Đã ra");
            dt.Rows.Add("59D-44444", "Xe máy", "01/05/2026 14:00", "01/05/2026 16:30", "Đã ra");

            dgvParkingLog.DataSource = dt;
            dgvParkingLog.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvParkingLog.RowHeadersVisible = false;

            // Color active vs done
            foreach (DataGridViewRow row in dgvParkingLog.Rows)
            {
                if (row.Cells["Trạng thái"].Value?.ToString() == "Đang gửi")
                    row.DefaultCellStyle.ForeColor = Color.MediumSeaGreen;
                else
                    row.DefaultCellStyle.ForeColor = Color.Gray;
            }
        }

        private void UpdateSlots()
        {
            lblSlotsValue.Text = $"{_currentSlots} / {_maxSlots}";
            lblSlotsValue.ForeColor = _currentSlots <= 5 ? Color.IndianRed : Color.MediumSeaGreen;
        }

        private void btnReport_Click(object? sender, EventArgs e)
        {
            int parked = 0;
            int exited = 0;
            if (dgvParkingLog.DataSource is DataTable dt)
            {
                foreach (DataRow row in dt.Rows)
                {
                    if (row["Trạng thái"]?.ToString() == "Đang gửi")
                        parked++;
                    else
                        exited++;
                }
            }

            string report =
                $"BÁO CÁO BÃI XE\n" +
                $"Thời gian: {DateTime.Now:HH:mm dd/MM/yyyy}\n" +
                $"──────────────────\n" +
                $"• Chỗ trống: {lblSlotsValue.Text}\n" +
                $"• Xe đang gửi: {parked}\n" +
                $"• Xe đã ra: {exited}\n" +
                $"──────────────────\n" +
                $"Gửi báo cáo cho quản lý qua Chat?";

            var result = MessageBox.Show(report, "Báo cáo bãi xe",
                MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (result == DialogResult.Yes)
            {
                MsgBox.Show(
                    "Đã gửi báo cáo cho quản lý!\nQuản lý sẽ duyệt qua Chat nội bộ.",
                    "Thành công", MsgBox.MessageBoxType.Success);
            }
        }

        private void btnVehicleIn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPlate.Text))
            {
                MsgBox.Show("Vui lòng nhập biển số xe!", "Thông báo", MsgBox.MessageBoxType.Warning);
                return;
            }

            if (_currentSlots <= 0)
            {
                MsgBox.Show("Bãi xe đã đầy!", "Thông báo", MsgBox.MessageBoxType.Error);
                return;
            }

            string vehicleType = cmbVehicleType.SelectedItem?.ToString() ?? "Xe máy";

            if (dgvParkingLog.DataSource is DataTable dt)
            {
                DataRow newRow = dt.NewRow();
                newRow["Biển số"] = txtPlate.Text.Trim().ToUpper();
                newRow["Loại xe"] = vehicleType;
                newRow["Giờ vào"] = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
                newRow["Giờ ra"] = "";
                newRow["Trạng thái"] = "Đang gửi";
                dt.Rows.InsertAt(newRow, 0);
            }

            _currentSlots--;
            UpdateSlots();
            MsgBox.Show($"Xe {txtPlate.Text.Trim().ToUpper()} ({vehicleType}) đã vào bãi!", "Xe vào", MsgBox.MessageBoxType.Success);
            txtPlate.Clear();
        }

        private void btnVehicleOut_Click(object sender, EventArgs e)
        {
            if (dgvParkingLog.CurrentRow == null)
            {
                MsgBox.Show("Vui lòng chọn xe cần ra!", "Thông báo", MsgBox.MessageBoxType.Warning);
                return;
            }

            var row = dgvParkingLog.CurrentRow;
            if (row.Cells["Trạng thái"].Value?.ToString() != "Đang gửi")
            {
                MsgBox.Show("Xe này đã ra rồi!", "Thông báo", MsgBox.MessageBoxType.Warning);
                return;
            }

            string plate = row.Cells["Biển số"].Value?.ToString() ?? "";
            row.Cells["Giờ ra"].Value = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            row.Cells["Trạng thái"].Value = "Đã ra";
            row.DefaultCellStyle.ForeColor = Color.Gray;

            _currentSlots++;
            UpdateSlots();
            MsgBox.Show($"Xe {plate} đã ra khỏi bãi!", "Xe ra", MsgBox.MessageBoxType.Success);
        }
    }
}
