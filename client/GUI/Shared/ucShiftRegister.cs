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
    // Nhân viên tự phục vụ lịch ca (node dang_ky_ca):
    //   • Chọn ca  — nhận một ca còn trống (open -> mine, chờ xác nhận).
    //   • Đổi ca   — xin đổi một ca của mình cho đồng nghiệp (tạo yêu cầu swap).
    public partial class ucShiftRegister : UserControl
    {
        public ucShiftRegister()
        {
            InitializeComponent();
        }

        private async void UcShiftRegister_Load(object? sender, EventArgs e)
        {
            DateTime monday = StartOfWeek(DateTime.Today);
            lblWeek.Text = $"Tuần {monday:dd/MM} – {monday.AddDays(6):dd/MM/yyyy}";
            await LoadAll();
        }

        private string MyId => GlobalSession.CurrentUser?.EmployeeId ?? "";

        private async Task LoadAll()
        {
            System.Collections.Generic.Dictionary<string, ShiftDTO> all;
            try { all = await ShiftBUS.GetAll(); }
            catch { all = new(); }

            // ----- Ca trống -----
            var dtOpen = new DataTable();
            dtOpen.Columns.Add("Mã"); dtOpen.Columns.Add("Ngày"); dtOpen.Columns.Add("Ca"); dtOpen.Columns.Add("Giờ");
            foreach (var kv in all.Where(x => x.Value.Loai == "open"))
                dtOpen.Rows.Add(kv.Key, kv.Value.Ngay, kv.Value.Ca, kv.Value.Gio);
            dgvOpen.DataSource = dtOpen;
            GridColumnGuard.SyncColumnNames(dgvOpen);
            if (dgvOpen.Columns.Contains("Mã")) dgvOpen.Columns["Mã"].Visible = false;
            dgvOpen.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            if (dgvOpen.Columns.Contains("Ngày")) dgvOpen.Columns["Ngày"].FillWeight = 30;
            if (dgvOpen.Columns.Contains("Ca")) dgvOpen.Columns["Ca"].FillWeight = 30;
            if (dgvOpen.Columns.Contains("Giờ")) dgvOpen.Columns["Giờ"].FillWeight = 40;

            // ----- Ca của tôi -----
            var dtMine = new DataTable();
            dtMine.Columns.Add("Mã"); dtMine.Columns.Add("Ngày"); dtMine.Columns.Add("Ca"); dtMine.Columns.Add("Giờ"); dtMine.Columns.Add("Trạng thái");
            foreach (var kv in all.Where(x => x.Value.Loai == "mine" && x.Value.EmployeeId == MyId))
                dtMine.Rows.Add(kv.Key, kv.Value.Ngay, kv.Value.Ca, kv.Value.Gio, kv.Value.TrangThai);
            dgvMine.DataSource = dtMine;
            GridColumnGuard.SyncColumnNames(dgvMine);
            if (dgvMine.Columns.Contains("Mã")) dgvMine.Columns["Mã"].Visible = false;
            dgvMine.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            if (dgvMine.Columns.Contains("Ngày")) dgvMine.Columns["Ngày"].FillWeight = 24;
            if (dgvMine.Columns.Contains("Ca")) dgvMine.Columns["Ca"].FillWeight = 22;
            if (dgvMine.Columns.Contains("Giờ")) dgvMine.Columns["Giờ"].FillWeight = 32;
            if (dgvMine.Columns.Contains("Trạng thái")) dgvMine.Columns["Trạng thái"].FillWeight = 22;

            // ----- Yêu cầu đổi ca -----
            var dtSwap = new DataTable();
            dtSwap.Columns.Add("Mã"); dtSwap.Columns.Add("Ngày"); dtSwap.Columns.Add("Ca"); dtSwap.Columns.Add("Đổi cho"); dtSwap.Columns.Add("Trạng thái");
            foreach (var kv in all.Where(x => x.Value.Loai == "swap" && x.Value.EmployeeId == MyId))
                dtSwap.Rows.Add(kv.Key, kv.Value.Ngay, kv.Value.Ca, kv.Value.DoiCho, kv.Value.TrangThai);
            dgvSwap.DataSource = dtSwap;
            GridColumnGuard.SyncColumnNames(dgvSwap);
            if (dgvSwap.Columns.Contains("Mã")) dgvSwap.Columns["Mã"].Visible = false;
            dgvSwap.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            if (dgvSwap.Columns.Contains("Ngày")) dgvSwap.Columns["Ngày"].FillWeight = 22;
            if (dgvSwap.Columns.Contains("Ca")) dgvSwap.Columns["Ca"].FillWeight = 20;
            if (dgvSwap.Columns.Contains("Đổi cho")) dgvSwap.Columns["Đổi cho"].FillWeight = 36;
            if (dgvSwap.Columns.Contains("Trạng thái")) dgvSwap.Columns["Trạng thái"].FillWeight = 22;

            RecolorStatuses();
            lblMineValue.Text = $"{dtMine.Rows.Count} ca";
            lblOpenValue.Text = $"{dtOpen.Rows.Count} ca";
            lblSwapPendingValue.Text = $"{dtSwap.AsEnumerable().Count(r => (r.Field<string>("Trạng thái") ?? "") == "Chờ duyệt")} yêu cầu";
        }

        private static string RowId(DataGridView dgv) =>
            (dgv.CurrentRow?.DataBoundItem as DataRowView)?["Mã"]?.ToString() ?? "";

        private async void BtnPickShift_Click(object? sender, EventArgs e)
        {
            if (dgvOpen.CurrentRow == null || dgvOpen.CurrentRow.Index < 0)
            {
                MsgBox.Show(MsgBox.OwnerWindow(this), "Vui lòng chọn một ca trống để nhận!", "Thông báo", MsgBox.MessageBoxType.Warning);
                return;
            }
            string id = RowId(dgvOpen);
            string ngay = dgvOpen.CurrentRow.Cells["Ngày"].Value?.ToString() ?? "";
            string ca = dgvOpen.CurrentRow.Cells["Ca"].Value?.ToString() ?? "";
            string gio = dgvOpen.CurrentRow.Cells["Giờ"].Value?.ToString() ?? "";

            if (MsgBox.Show(MsgBox.OwnerWindow(this), $"Nhận ca {ca} ngày {ngay} ({gio})?", "Xác nhận nhận ca", MsgBox.MessageBoxType.Warning) != DialogResult.Yes)
                return;

            var (ok, msg) = await ShiftBUS.Update(id, new { loai = "mine", nhanvien_id = MyId, trang_thai = "Chờ xác nhận" });
            if (ok) { await LoadAll(); MsgBox.Show(MsgBox.OwnerWindow(this), "Đã gửi yêu cầu nhận ca!", "Thành công", MsgBox.MessageBoxType.Success); }
            else MsgBox.Show(MsgBox.OwnerWindow(this), msg, "Lỗi", MsgBox.MessageBoxType.Error);
        }

        private async void BtnSwap_Click(object? sender, EventArgs e)
        {
            if (dgvMine.CurrentRow == null || dgvMine.CurrentRow.Index < 0)
            {
                MsgBox.Show(MsgBox.OwnerWindow(this), "Vui lòng chọn một ca của bạn để xin đổi!", "Thông báo", MsgBox.MessageBoxType.Warning);
                return;
            }
            string mineId = RowId(dgvMine);
            string ngay = dgvMine.CurrentRow.Cells["Ngày"].Value?.ToString() ?? "";
            string ca = dgvMine.CurrentRow.Cells["Ca"].Value?.ToString() ?? "";
            string gio = dgvMine.CurrentRow.Cells["Giờ"].Value?.ToString() ?? "";

            string? colleague = InputDialog.Show(MsgBox.OwnerWindow(this), "Xin đổi ca", $"Đổi ca {ca} ({ngay}) cho đồng nghiệp nào?", "Nhập tên đồng nghiệp…");
            if (string.IsNullOrWhiteSpace(colleague)) return;

            await ShiftBUS.Add(new ShiftDTO { Loai = "swap", Ngay = ngay, Ca = ca, Gio = gio, EmployeeId = MyId, DoiCho = colleague, TrangThai = "Chờ duyệt" });
            if (!string.IsNullOrEmpty(mineId)) await ShiftBUS.Update(mineId, new { trang_thai = "Chờ đổi" });
            await LoadAll();
            MsgBox.Show(MsgBox.OwnerWindow(this), $"Đã gửi yêu cầu đổi ca cho {colleague}.", "Thành công", MsgBox.MessageBoxType.Success);
        }

        private void RecolorStatuses()
        {
            foreach (DataGridViewRow row in dgvMine.Rows)
                if (row.Cells["Trạng thái"] != null)
                    row.Cells["Trạng thái"].Style.ForeColor = StatusColor(row.Cells["Trạng thái"].Value?.ToString());
            foreach (DataGridViewRow row in dgvSwap.Rows)
                if (row.Cells["Trạng thái"] != null)
                    row.Cells["Trạng thái"].Style.ForeColor = StatusColor(row.Cells["Trạng thái"].Value?.ToString());
        }

        private static Color StatusColor(string? status) => status switch
        {
            "Đã xếp" or "Đã xác nhận" or "Đã duyệt" => Color.FromArgb(34, 197, 94),
            "Chờ xác nhận" or "Chờ duyệt" or "Chờ đổi" => Color.FromArgb(245, 158, 11),
            "Từ chối" => Color.FromArgb(220, 80, 80),
            _ => Color.FromArgb(220, 220, 225),
        };

        private static DateTime StartOfWeek(DateTime d)
        {
            int dow = (int)d.DayOfWeek;
            int back = dow == 0 ? 6 : dow - 1;
            return d.AddDays(-back).Date;
        }
    }
}
