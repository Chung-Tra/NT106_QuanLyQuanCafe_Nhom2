using BUS;
using DTO;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace GUI
{
    public partial class ucReservation_Order : UserControl
    {
        private DataTable _dt = null!;

        public ucReservation_Order()
        {
            InitializeComponent();
            Theme.StyleGrid(dgv);

            cmbStatus.SelectedIndex = 0;
            txtSearch.TextChanged += (s, e) => ApplyFilter();
            cmbStatus.SelectedIndexChanged += (s, e) => ApplyFilter();
            btnSendReminder.Click += (s, e) => SendReminder();

            DgvRefresh.Attach(dgv, () => _ = LoadData());
            Load += (s, e) => _ = LoadData();
        }

        private async Task LoadData()
        {
            _dt = new DataTable();
            _dt.Columns.Add("Mã đặt");
            _dt.Columns.Add("Họ tên");
            _dt.Columns.Add("SĐT");
            _dt.Columns.Add("Ngày & Giờ");
            _dt.Columns.Add("Bàn");
            _dt.Columns.Add("Số khách", typeof(int));
            _dt.Columns.Add("Ghi chú");
            _dt.Columns.Add("Trạng thái");

            try
            {
                var all = await ReservationBUS.GetAll();
                foreach (var kv in all.OrderByDescending(x => x.Value.Timestamp))
                {
                    var r = kv.Value;
                    _dt.Rows.Add(kv.Key, r.HoTen, r.SoDienThoai, r.NgayGio, r.Ban, r.SoKhach, r.GhiChu, r.TrangThai);
                }
            }
            catch { /* offline */ }

            UpdateStatCards();
            ApplyFilter();
        }

        private void UpdateStatCards()
        {
            if (_dt == null) return;
            string today = DateTime.Today.ToString("dd/MM/yyyy");
            int todayCount = 0, pending = 0, done = 0;
            foreach (DataRow r in _dt.Rows)
            {
                string status = r["Trạng thái"]?.ToString() ?? "";
                string when = r["Ngày & Giờ"]?.ToString() ?? "";
                if (when.Contains(today)) todayCount++;
                if (status == "Chờ xác nhận") pending++;
                if (status == "Đã đến") done++;
            }
            lblToday.Text = $"{todayCount} bàn";
            lblPending.Text = $"{pending} bàn";
            lblDone.Text = $"{done} bàn";
        }

        private void ApplyFilter()
        {
            if (_dt == null) return;
            string status = cmbStatus.SelectedIndex > 0 ? cmbStatus.SelectedItem?.ToString() ?? "" : "";

            var parts = new System.Collections.Generic.List<string>();
            string kwFilter = SearchFilter.AllColumnsFilter(_dt, txtSearch.Text);
            if (!string.IsNullOrEmpty(kwFilter)) parts.Add(kwFilter);
            if (!string.IsNullOrEmpty(status)) parts.Add($"[Trạng thái] = '{status}'");

            try { _dt.DefaultView.RowFilter = string.Join(" AND ", parts); }
            catch { _dt.DefaultView.RowFilter = ""; }

            dgv.DataSource = _dt.DefaultView.ToTable();

            if (dgv.Columns.Count > 0)
            {
                dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                if (dgv.Columns.Contains("Mã đặt"))      dgv.Columns["Mã đặt"].FillWeight      = 7;
                if (dgv.Columns.Contains("Họ tên"))      dgv.Columns["Họ tên"].FillWeight      = 14;
                if (dgv.Columns.Contains("SĐT"))         dgv.Columns["SĐT"].FillWeight         = 10;
                if (dgv.Columns.Contains("Ngày & Giờ"))  dgv.Columns["Ngày & Giờ"].FillWeight  = 14;
                if (dgv.Columns.Contains("Bàn"))         dgv.Columns["Bàn"].FillWeight         = 11;
                if (dgv.Columns.Contains("Số khách"))    dgv.Columns["Số khách"].FillWeight    = 7;
                if (dgv.Columns.Contains("Ghi chú"))     dgv.Columns["Ghi chú"].FillWeight     = 20;
                if (dgv.Columns.Contains("Trạng thái"))  dgv.Columns["Trạng thái"].FillWeight  = 12;
                ColorStatusColumn();
            }

            lblCount.Text = $"{dgv.Rows.Count} lượt đặt";
        }

        private void ColorStatusColumn()
        {
            foreach (DataGridViewRow row in dgv.Rows)
            {
                string s = row.Cells["Trạng thái"].Value?.ToString() ?? "";
                row.Cells["Trạng thái"].Style.ForeColor = s switch
                {
                    "Đã xác nhận"  => Theme.Green,
                    "Chờ xác nhận" => Theme.Amber,
                    "Đã đến"       => Theme.Teal,
                    "Hủy"          => Theme.Red,
                    _              => Theme.TextPri,
                };
            }
        }

        private void DgvRes_CellDoubleClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            RecordDetail.FromRow(dgv.Rows[e.RowIndex], "Chi tiết đặt bàn")
                        .ShowDialog(MsgBox.OwnerWindow(this));
        }

        private async void BtnEditRes_Click(object? sender, EventArgs e)
        {
            if (dgv.CurrentRow == null || dgv.CurrentRow.Index < 0)
            {
                MsgBox.Show(MsgBox.OwnerWindow(this), "Vui lòng chọn một lượt đặt để sửa!", "Thông báo", MsgBox.MessageBoxType.Warning);
                return;
            }

            string code = dgv.CurrentRow.Cells["Mã đặt"].Value?.ToString() ?? "";
            if (!RecordEdit.EditRow(dgv.CurrentRow, "Sửa đặt bàn", MsgBox.OwnerWindow(this))) return;

            var row = dgv.CurrentRow;
            int.TryParse(row.Cells["Số khách"].Value?.ToString(), out int sk);
            await ReservationBUS.Update(code, new
            {
                ho_ten = row.Cells["Họ tên"].Value?.ToString() ?? "",
                so_dien_thoai = row.Cells["SĐT"].Value?.ToString() ?? "",
                ngay_gio = row.Cells["Ngày & Giờ"].Value?.ToString() ?? "",
                ban = row.Cells["Bàn"].Value?.ToString() ?? "",
                so_khach = sk,
                ghi_chu = row.Cells["Ghi chú"].Value?.ToString() ?? "",
                trang_thai = row.Cells["Trạng thái"].Value?.ToString() ?? ""
            });
            await LoadData();
        }

        private async void BtnAdd_Click(object? sender, EventArgs e)
        {
            string? name = InputDialog.Show(MsgBox.OwnerWindow(this), "Đặt bàn mới", "Họ tên khách hàng", "VD: Nguyễn Văn A");
            if (string.IsNullOrEmpty(name)) return;
            string? phone = InputDialog.Show(MsgBox.OwnerWindow(this), "Đặt bàn mới", "Số điện thoại", "VD: 09xxxxxxxx");
            string? when = InputDialog.Show(MsgBox.OwnerWindow(this), "Đặt bàn mới", "Ngày & giờ (dd/MM/yyyy HH:mm)", DateTime.Now.AddHours(2).ToString("dd/MM/yyyy HH:mm"));
            string? ban = InputDialog.Show(MsgBox.OwnerWindow(this), "Đặt bàn mới", "Bàn", "VD: Bàn 05");
            string? skStr = InputDialog.Show(MsgBox.OwnerWindow(this), "Đặt bàn mới", "Số khách", "2");
            int.TryParse(skStr, out int sk);

            var dto = new ReservationDTO
            {
                HoTen = name,
                SoDienThoai = phone ?? "",
                NgayGio = string.IsNullOrWhiteSpace(when) ? DateTime.Now.AddHours(2).ToString("dd/MM/yyyy HH:mm") : when,
                Ban = ban ?? "",
                SoKhach = sk <= 0 ? 2 : sk,
                GhiChu = "",
                TrangThai = "Chờ xác nhận",
                Timestamp = DateTimeOffset.Now.ToUnixTimeMilliseconds()
            };
            var (ok, msg, _) = await ReservationBUS.Add(dto);
            if (ok)
            {
                MsgBox.Show(MsgBox.OwnerWindow(this), $"Đã tạo đặt bàn cho {name}!", "Thành công", MsgBox.MessageBoxType.Success);
                await LoadData();
            }
            else MsgBox.Show(MsgBox.OwnerWindow(this), msg, "Lỗi", MsgBox.MessageBoxType.Error);
        }

        private void SendReminder()
        {
            string today = DateTime.Today.ToString("dd/MM/yyyy");
            int cnt = 0;
            if (_dt != null)
                foreach (DataRow r in _dt.Rows)
                    if ((r["Ngày & Giờ"]?.ToString() ?? "").Contains(today) &&
                        (r["Trạng thái"]?.ToString() ?? "") != "Hủy") cnt++;

            MsgBox.Show(MsgBox.OwnerWindow(this),
                cnt > 0 ? $"Đã gửi nhắc đến {cnt} khách có đặt bàn hôm nay ({today})!"
                        : "Hôm nay không có lượt đặt bàn nào cần nhắc.",
                "Gửi nhắc", MsgBox.MessageBoxType.Info);
        }
    }
}
