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
    public partial class ucParking_Security : UserControl
    {
        private int _currentSlots = 30;
        private const int _maxSlots = 30;

        public ucParking_Security()
        {
            InitializeComponent();
            GridColumnGuard.SyncColumnNames(dgvParkingLog);
            DgvRefresh.Attach(dgvParkingLog, () => _ = LoadRealData());
            this.Load += (s, e) => _ = LoadRealData();

            dgvParkingLog.CellDoubleClick += (s, e) =>
            {
                if (e.RowIndex < 0) return;
                RecordDetail.FromRow(dgvParkingLog.Rows[e.RowIndex], "Chi tiết gửi xe")
                            .ShowDialog(MsgBox.OwnerWindow(this));
            };
        }

        private static (string code, decimal fee) VehicleInfo(string display) => display switch
        {
            "Ô tô" => ("o_to", 20000m),
            "Xe đạp" => ("xe_dap", 2000m),
            _ => ("xe_may", 5000m)
        };
        private static string VehicleDisplay(string? code) => code switch
        {
            "o_to" => "Ô tô",
            "xe_dap" => "Xe đạp",
            _ => "Xe máy"
        };
        private static string TimeStr(long ms) => ms > 0
            ? DateTimeOffset.FromUnixTimeMilliseconds(ms).LocalDateTime.ToString("dd/MM/yyyy HH:mm") : "";

        private async Task LoadRealData()
        {
            if (cmbVehicleType.Items.Count > 0 && cmbVehicleType.SelectedIndex < 0)
                cmbVehicleType.SelectedIndex = 0;

            DataTable dt = new();
            dt.Columns.Add("Mã");
            dt.Columns.Add("Biển số");
            dt.Columns.Add("Loại xe");
            dt.Columns.Add("Giờ vào");
            dt.Columns.Add("Giờ ra");
            dt.Columns.Add("Trạng thái");

            int parked = 0;
            try
            {
                var all = await ParkingBUS.GetAll();
                foreach (var kv in all.OrderByDescending(p => p.Value.EntryTime))
                {
                    var p = kv.Value;
                    bool active = p.Status == "dang_gui";
                    if (active) parked++;
                    dt.Rows.Add(kv.Key, p.LicensePlate, VehicleDisplay(p.VehicleType),
                        TimeStr(p.EntryTime), TimeStr(p.ExitTime), active ? "Đang gửi" : "Đã ra");
                }
            }
            catch { /* offline */ }

            dgvParkingLog.DataSource = dt;
            dgvParkingLog.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvParkingLog.RowHeadersVisible = false;
            if (dgvParkingLog.Columns.Contains("Mã")) dgvParkingLog.Columns["Mã"].Visible = false;

            foreach (DataGridViewRow row in dgvParkingLog.Rows)
                row.DefaultCellStyle.ForeColor =
                    row.Cells["Trạng thái"].Value?.ToString() == "Đang gửi" ? Color.MediumSeaGreen : Color.Gray;

            _currentSlots = Math.Max(0, _maxSlots - parked);
            UpdateSlots();
        }

        private void UpdateSlots()
        {
            lblSlotsValue.Text = $"{_currentSlots} / {_maxSlots}";
            lblSlotsValue.ForeColor = _currentSlots <= 5 ? Color.IndianRed : Color.MediumSeaGreen;
        }

        private void btnReport_Click(object? sender, EventArgs e)
        {
            int parked = 0, exited = 0;
            if (dgvParkingLog.DataSource is DataTable dt)
                foreach (DataRow row in dt.Rows)
                    if (row["Trạng thái"]?.ToString() == "Đang gửi") parked++; else exited++;

            string report =
                "BÁO CÁO BÃI XE\n" +
                $"Thời gian: {DateTime.Now:HH:mm dd/MM/yyyy}\n" +
                "──────────────────\n" +
                $"• Chỗ trống: {lblSlotsValue.Text}\n" +
                $"• Xe đang gửi: {parked}\n" +
                $"• Xe đã ra: {exited}\n" +
                "──────────────────\n" +
                "Gửi báo cáo cho quản lý qua Chat?";

            if (MsgBox.Show(MsgBox.OwnerWindow(this), report, "Báo cáo bãi xe", MsgBox.MessageBoxType.Warning) == DialogResult.Yes)
                MsgBox.Show(MsgBox.OwnerWindow(this), "Đã gửi báo cáo cho quản lý!", "Thành công", MsgBox.MessageBoxType.Success);
        }

        private async void btnVehicleIn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPlate.Text))
            {
                MsgBox.Show(MsgBox.OwnerWindow(this), "Vui lòng nhập biển số xe!", "Thông báo", MsgBox.MessageBoxType.Warning);
                return;
            }
            if (_currentSlots <= 0)
            {
                MsgBox.Show(MsgBox.OwnerWindow(this), "Bãi xe đã đầy!", "Thông báo", MsgBox.MessageBoxType.Error);
                return;
            }

            string vehicleType = cmbVehicleType.SelectedItem?.ToString() ?? "Xe máy";
            var (code, fee) = VehicleInfo(vehicleType);
            string plate = txtPlate.Text.Trim().ToUpper();

            var dto = new ParkingDTO
            {
                LicensePlate = plate,
                VehicleType = code,
                EntryTime = DateTimeOffset.Now.ToUnixTimeMilliseconds(),
                ExitTime = 0,
                Status = "dang_gui",
                EmployeeId = GlobalSession.CurrentUser?.EmployeeId,
                Fee = fee
            };
            var (ok, msg, _) = await ParkingBUS.Add(dto);
            if (ok)
            {
                MsgBox.Show(MsgBox.OwnerWindow(this), $"Xe {plate} ({vehicleType}) đã vào bãi!\nPhí gửi: {fee:N0}đ", "Xe vào", MsgBox.MessageBoxType.Success);
                txtPlate.Clear();
                await LoadRealData();
            }
            else MsgBox.Show(MsgBox.OwnerWindow(this), msg, "Lỗi", MsgBox.MessageBoxType.Error);
        }

        private async void btnVehicleOut_Click(object sender, EventArgs e)
        {
            if (dgvParkingLog.CurrentRow == null)
            {
                MsgBox.Show(MsgBox.OwnerWindow(this), "Vui lòng chọn xe cần ra!", "Thông báo", MsgBox.MessageBoxType.Warning);
                return;
            }
            var row = dgvParkingLog.CurrentRow;
            if (row.Cells["Trạng thái"].Value?.ToString() != "Đang gửi")
            {
                MsgBox.Show(MsgBox.OwnerWindow(this), "Xe này đã ra rồi!", "Thông báo", MsgBox.MessageBoxType.Warning);
                return;
            }

            string id = (row.DataBoundItem as DataRowView)?["Mã"]?.ToString() ?? "";
            string plate = row.Cells["Biển số"].Value?.ToString() ?? "";
            var (ok, msg) = await ParkingBUS.Update(id, new
            {
                gio_ra = DateTimeOffset.Now.ToUnixTimeMilliseconds(),
                trang_thai = "da_ra"
            });
            if (ok)
            {
                MsgBox.Show(MsgBox.OwnerWindow(this), $"Xe {plate} đã ra khỏi bãi!", "Xe ra", MsgBox.MessageBoxType.Success);
                await LoadRealData();
            }
            else MsgBox.Show(MsgBox.OwnerWindow(this), msg, "Lỗi", MsgBox.MessageBoxType.Error);
        }
    }
}
