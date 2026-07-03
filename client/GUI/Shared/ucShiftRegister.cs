using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace GUI
{
    // Nhân viên tự phục vụ lịch ca:
    //   • Chọn ca  — nhận một ca còn trống trong tuần (chuyển sang "Ca của tôi").
    //   • Đổi ca   — xin đổi một ca của mình cho đồng nghiệp (tạo yêu cầu chờ duyệt).
    // Dữ liệu mock phía frontend; thao tác cập nhật ngay trên lưới cho đúng cảm giác thực tế.
    public partial class ucShiftRegister : UserControl
    {
        private readonly DataTable _dtOpen = new();
        private readonly DataTable _dtMine = new();
        private readonly DataTable _dtSwap = new();

        public ucShiftRegister()
        {
            InitializeComponent();
        }

        private void UcShiftRegister_Load(object? sender, EventArgs e)
        {
            DateTime monday = StartOfWeek(DateTime.Today);
            lblWeek.Text = $"Tuần {monday:dd/MM} – {monday.AddDays(6):dd/MM/yyyy}";

            // ----- Ca trống trong tuần -----
            _dtOpen.Columns.Add("Ngày");
            _dtOpen.Columns.Add("Ca");
            _dtOpen.Columns.Add("Giờ");
            _dtOpen.Rows.Add($"T4 {monday.AddDays(2):dd/MM}", "Ca chiều", "14:00 – 22:00");
            _dtOpen.Rows.Add($"T6 {monday.AddDays(4):dd/MM}", "Ca sáng", "06:00 – 14:00");
            _dtOpen.Rows.Add($"CN {monday.AddDays(6):dd/MM}", "Ca sáng", "06:00 – 14:00");
            dgvOpen.DataSource = _dtOpen;
            GridColumnGuard.SyncColumnNames(dgvOpen);
            dgvOpen.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvOpen.Columns["Ngày"].FillWeight = 30;
            dgvOpen.Columns["Ca"].FillWeight   = 30;
            dgvOpen.Columns["Giờ"].FillWeight  = 40;

            // ----- Ca của tôi tuần này -----
            _dtMine.Columns.Add("Ngày");
            _dtMine.Columns.Add("Ca");
            _dtMine.Columns.Add("Giờ");
            _dtMine.Columns.Add("Trạng thái");
            _dtMine.Rows.Add($"T2 {monday:dd/MM}",          "Ca sáng",  "06:00 – 14:00", "Đã xếp");
            _dtMine.Rows.Add($"T3 {monday.AddDays(1):dd/MM}", "Ca sáng",  "06:00 – 14:00", "Đã xếp");
            _dtMine.Rows.Add($"T5 {monday.AddDays(3):dd/MM}", "Ca chiều", "14:00 – 22:00", "Đã xếp");
            dgvMine.DataSource = _dtMine;
            GridColumnGuard.SyncColumnNames(dgvMine);
            dgvMine.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvMine.Columns["Ngày"].FillWeight       = 24;
            dgvMine.Columns["Ca"].FillWeight         = 22;
            dgvMine.Columns["Giờ"].FillWeight        = 32;
            dgvMine.Columns["Trạng thái"].FillWeight = 22;
            dgvMine.Columns["Trạng thái"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // ----- Yêu cầu đổi ca đã gửi -----
            _dtSwap.Columns.Add("Ngày");
            _dtSwap.Columns.Add("Ca");
            _dtSwap.Columns.Add("Đổi cho");
            _dtSwap.Columns.Add("Trạng thái");
            _dtSwap.Rows.Add($"T5 {monday.AddDays(3):dd/MM}", "Ca chiều", "Hoàng Thị Mai", "Chờ duyệt");
            dgvSwap.DataSource = _dtSwap;
            GridColumnGuard.SyncColumnNames(dgvSwap);
            dgvSwap.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSwap.Columns["Ngày"].FillWeight       = 22;
            dgvSwap.Columns["Ca"].FillWeight         = 20;
            dgvSwap.Columns["Đổi cho"].FillWeight    = 36;
            dgvSwap.Columns["Trạng thái"].FillWeight = 22;
            dgvSwap.Columns["Trạng thái"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            RecolorStatuses();
            UpdateSummary();
        }

        // ----- Chọn ca: nhận một ca trống -----
        private void BtnPickShift_Click(object? sender, EventArgs e)
        {
            if (dgvOpen.CurrentRow == null || dgvOpen.CurrentRow.Index < 0)
            {
                MsgBox.Show(MsgBox.OwnerWindow(this), "Vui lòng chọn một ca trống để nhận!", "Thông báo", MsgBox.MessageBoxType.Warning);
                return;
            }

            string ngay = dgvOpen.CurrentRow.Cells["Ngày"].Value?.ToString() ?? "";
            string ca   = dgvOpen.CurrentRow.Cells["Ca"].Value?.ToString() ?? "";
            string gio  = dgvOpen.CurrentRow.Cells["Giờ"].Value?.ToString() ?? "";

            var confirm = MsgBox.Show(MsgBox.OwnerWindow(this),
                $"Nhận ca {ca} ngày {ngay} ({gio})?", "Xác nhận nhận ca", MsgBox.MessageBoxType.Warning);
            if (confirm != DialogResult.Yes) return;

            // Bỏ khỏi danh sách trống, thêm vào ca của tôi (chờ quản lý xác nhận).
            if (dgvOpen.CurrentRow.DataBoundItem is DataRowView drv)
                _dtOpen.Rows.Remove(drv.Row);
            _dtMine.Rows.Add(ngay, ca, gio, "Chờ xác nhận");

            RecolorStatuses();
            UpdateSummary();
            MsgBox.Show(MsgBox.OwnerWindow(this),
                "Đã gửi yêu cầu nhận ca! Quản lý sẽ xác nhận trong lịch tuần.", "Thành công", MsgBox.MessageBoxType.Success);
        }

        // ----- Đổi ca: xin đổi một ca của mình cho đồng nghiệp -----
        private void BtnSwap_Click(object? sender, EventArgs e)
        {
            if (dgvMine.CurrentRow == null || dgvMine.CurrentRow.Index < 0)
            {
                MsgBox.Show(MsgBox.OwnerWindow(this), "Vui lòng chọn một ca của bạn để xin đổi!", "Thông báo", MsgBox.MessageBoxType.Warning);
                return;
            }

            string ngay = dgvMine.CurrentRow.Cells["Ngày"].Value?.ToString() ?? "";
            string ca   = dgvMine.CurrentRow.Cells["Ca"].Value?.ToString() ?? "";

            string? colleague = InputDialog.Show(MsgBox.OwnerWindow(this),
                "Xin đổi ca", $"Đổi ca {ca} ({ngay}) cho đồng nghiệp nào?", "Nhập tên đồng nghiệp…");
            if (string.IsNullOrWhiteSpace(colleague)) return;

            // Tránh gửi trùng một ca đang chờ đổi.
            bool dup = _dtSwap.AsEnumerable().Any(r =>
                r.Field<string>("Ngày") == ngay && r.Field<string>("Ca") == ca &&
                (r.Field<string>("Trạng thái") ?? "") == "Chờ duyệt");
            if (dup)
            {
                MsgBox.Show(MsgBox.OwnerWindow(this), "Ca này đã có yêu cầu đổi đang chờ duyệt!", "Thông báo", MsgBox.MessageBoxType.Warning);
                return;
            }

            _dtSwap.Rows.Add(ngay, ca, colleague, "Chờ duyệt");
            dgvMine.CurrentRow.Cells["Trạng thái"].Value = "Chờ đổi";

            RecolorStatuses();
            UpdateSummary();
            MsgBox.Show(MsgBox.OwnerWindow(this),
                $"Đã gửi yêu cầu đổi ca cho {colleague}. Chờ đồng nghiệp và quản lý duyệt.", "Thành công", MsgBox.MessageBoxType.Success);
        }

        // Tô màu trạng thái cho dễ đọc, đồng bộ tông màu app.
        private void RecolorStatuses()
        {
            foreach (DataGridViewRow row in dgvMine.Rows)
                row.Cells["Trạng thái"].Style.ForeColor = StatusColor(row.Cells["Trạng thái"].Value?.ToString());
            foreach (DataGridViewRow row in dgvSwap.Rows)
                row.Cells["Trạng thái"].Style.ForeColor = StatusColor(row.Cells["Trạng thái"].Value?.ToString());
        }

        private static Color StatusColor(string? status) => status switch
        {
            "Đã xếp" or "Đã xác nhận" or "Đã duyệt" => Color.FromArgb(34, 197, 94),
            "Chờ xác nhận" or "Chờ duyệt" or "Chờ đổi" => Color.FromArgb(245, 158, 11),
            "Từ chối" => Color.FromArgb(220, 80, 80),
            _ => Color.FromArgb(220, 220, 225),
        };

        private void UpdateSummary()
        {
            lblMineValue.Text = $"{_dtMine.Rows.Count} ca";
            lblOpenValue.Text = $"{_dtOpen.Rows.Count} ca";
            int pending = _dtSwap.AsEnumerable().Count(r => (r.Field<string>("Trạng thái") ?? "") == "Chờ duyệt");
            lblSwapPendingValue.Text = $"{pending} yêu cầu";
        }

        private static DateTime StartOfWeek(DateTime d)
        {
            int dow  = (int)d.DayOfWeek;        // Chủ nhật=0, Thứ 2=1, … Thứ 7=6
            int back = dow == 0 ? 6 : dow - 1;
            return d.AddDays(-back).Date;
        }
    }
}
