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
    public partial class ucPromotion_Manager : UserControl
    {
        public ucPromotion_Manager()
        {
            InitializeComponent();

            btnHappy.Click += (s, e) => SwitchTab(btnHappy, pnlHappy);
            btnCombo.Click += (s, e) => SwitchTab(btnCombo, pnlCombo);
            btnVoucher.Click += (s, e) => SwitchTab(btnVoucher, pnlVoucher);

            btnHappyEdit.Click += (s, e) => _ = EditHappy();
            btnHappyAdd.Click += (s, e) => _ = AddHappyHour();
            btnComboAdd.Click += (s, e) => _ = AddCombo();
            btnVoucherGen.Click += (s, e) => _ = AddVoucher();

            _ = LoadHappyGrid();
            _ = LoadComboGrid();
            _ = LoadVoucherGrid();

            DgvRefresh.Attach(dgvHappy, () => _ = LoadHappyGrid());
            DgvRefresh.Attach(dgvCombo, () => _ = LoadComboGrid());
            DgvRefresh.Attach(dgvVoucher, () => _ = LoadVoucherGrid());

            dgvHappy.CellDoubleClick   += (s, e) => ShowDetail(dgvHappy, e, "Chi tiết Happy Hour");
            dgvCombo.CellDoubleClick   += (s, e) => ShowDetail(dgvCombo, e, "Chi tiết Combo");
            dgvVoucher.CellDoubleClick += (s, e) => ShowDetail(dgvVoucher, e, "Chi tiết Voucher");

            Load += (s, e) => SwitchTab(btnHappy, pnlHappy);
        }

        private void ShowDetail(Guna2DataGridView dgv, DataGridViewCellEventArgs e, string title)
        {
            if (e.RowIndex < 0) return;
            RecordDetail.FromRow(dgv.Rows[e.RowIndex], title).ShowDialog(MsgBox.OwnerWindow(this));
        }

        private static string RowId(DataGridView dgv) =>
            (dgv.CurrentRow?.DataBoundItem as DataRowView)?["Mã"]?.ToString() ?? "";

        // ---------------- HAPPY HOUR ----------------
        private async Task LoadHappyGrid()
        {
            Theme.StyleGrid(dgvHappy);
            var dt = new DataTable();
            dt.Columns.Add("Mã");
            dt.Columns.Add("Tên chương trình");
            dt.Columns.Add("Khung giờ");
            dt.Columns.Add("Ngày áp dụng");
            dt.Columns.Add("Giảm (%)");
            dt.Columns.Add("Trạng thái");
            try
            {
                foreach (var kv in (await PromotionBUS.GetAll()).Where(x => x.Value.Loai == "happy_hour"))
                {
                    var p = kv.Value;
                    dt.Rows.Add(kv.Key, p.Ten, p.KhungGio, p.NgayApDung, p.GiamPct, p.TrangThai);
                }
            }
            catch { }
            dgvHappy.DataSource = dt;
            if (dgvHappy.Columns.Contains("Mã")) dgvHappy.Columns["Mã"].Visible = false;
            dgvHappy.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            if (dgvHappy.Columns.Contains("Tên chương trình")) dgvHappy.Columns["Tên chương trình"].FillWeight = 26;
            if (dgvHappy.Columns.Contains("Khung giờ")) dgvHappy.Columns["Khung giờ"].FillWeight = 16;
            if (dgvHappy.Columns.Contains("Ngày áp dụng")) dgvHappy.Columns["Ngày áp dụng"].FillWeight = 26;
            if (dgvHappy.Columns.Contains("Giảm (%)")) dgvHappy.Columns["Giảm (%)"].FillWeight = 12;
            if (dgvHappy.Columns.Contains("Trạng thái")) dgvHappy.Columns["Trạng thái"].FillWeight = 20;
        }

        private async Task AddHappyHour()
        {
            string? name = InputDialog.Show(MsgBox.OwnerWindow(this), "Thêm Happy Hour", "Tên chương trình", "VD: Happy Hour Tối");
            if (string.IsNullOrWhiteSpace(name)) return;
            string? gio = InputDialog.Show(MsgBox.OwnerWindow(this), "Thêm Happy Hour", "Khung giờ", "VD: 14:00 – 16:00");
            string? ngay = InputDialog.Show(MsgBox.OwnerWindow(this), "Thêm Happy Hour", "Ngày áp dụng", "VD: T2, T3, T4, T5, T6");
            string? disc = InputDialog.Show(MsgBox.OwnerWindow(this), "Thêm Happy Hour", "Mức giảm (%)", "VD: 20");

            var (ok, msg, _) = await PromotionBUS.Add(new PromotionDTO
            {
                Loai = "happy_hour",
                Ten = name,
                KhungGio = gio ?? "14:00 – 16:00",
                NgayApDung = ngay ?? "T2 - T6",
                GiamPct = (string.IsNullOrWhiteSpace(disc) ? "10" : disc) + "%",
                TrangThai = "🟢 Đang chạy"
            });
            if (ok) { await LoadHappyGrid(); MsgBox.Show(MsgBox.OwnerWindow(this), "Đã thêm Happy Hour!", "Thành công", MsgBox.MessageBoxType.Success); }
            else MsgBox.Show(MsgBox.OwnerWindow(this), msg, "Lỗi", MsgBox.MessageBoxType.Error);
        }

        private async Task EditHappy()
        {
            if (dgvHappy.CurrentRow == null || dgvHappy.CurrentRow.Index < 0)
            {
                MsgBox.Show(MsgBox.OwnerWindow(this), "Vui lòng chọn một chương trình để sửa!", "Thông báo", MsgBox.MessageBoxType.Warning);
                return;
            }
            string id = RowId(dgvHappy);
            if (RecordEdit.EditRow(dgvHappy.CurrentRow, "Sửa Happy Hour", MsgBox.OwnerWindow(this)) && !string.IsNullOrEmpty(id))
            {
                var r = dgvHappy.CurrentRow;
                await PromotionBUS.Update(id, new
                {
                    ten = r.Cells["Tên chương trình"].Value?.ToString() ?? "",
                    khung_gio = r.Cells["Khung giờ"].Value?.ToString() ?? "",
                    ngay_ap_dung = r.Cells["Ngày áp dụng"].Value?.ToString() ?? "",
                    giam_pct = r.Cells["Giảm (%)"].Value?.ToString() ?? "",
                    trang_thai = r.Cells["Trạng thái"].Value?.ToString() ?? ""
                });
                await LoadHappyGrid();
            }
        }

        // ---------------- COMBO ----------------
        private async Task LoadComboGrid()
        {
            Theme.StyleGrid(dgvCombo);
            var dt = new DataTable();
            dt.Columns.Add("Mã");
            dt.Columns.Add("Tên combo");
            dt.Columns.Add("Bao gồm");
            dt.Columns.Add("Giá gốc", typeof(long));
            dt.Columns.Add("Giá combo", typeof(long));
            dt.Columns.Add("Tiết kiệm", typeof(long));
            dt.Columns.Add("Trạng thái");
            try
            {
                foreach (var kv in (await PromotionBUS.GetAll()).Where(x => x.Value.Loai == "combo"))
                {
                    var p = kv.Value;
                    dt.Rows.Add(kv.Key, p.Ten, p.BaoGom, p.GiaGoc, p.GiaCombo, p.TietKiem, p.TrangThai);
                }
            }
            catch { }
            dgvCombo.DataSource = dt;
            if (dgvCombo.Columns.Contains("Mã")) dgvCombo.Columns["Mã"].Visible = false;
            dgvCombo.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            foreach (var c in new[] { "Giá gốc", "Giá combo", "Tiết kiệm" })
                if (dgvCombo.Columns.Contains(c))
                {
                    dgvCombo.Columns[c].DefaultCellStyle.Format = "N0";
                    dgvCombo.Columns[c].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }
        }

        private async Task AddCombo()
        {
            string? name = InputDialog.Show(MsgBox.OwnerWindow(this), "Thêm Combo", "Tên combo", "VD: Combo Trưa");
            if (string.IsNullOrWhiteSpace(name)) return;
            string? items = InputDialog.Show(MsgBox.OwnerWindow(this), "Thêm Combo", "Bao gồm", "VD: 1 Cà phê + 1 Bánh");
            string? priceStr = InputDialog.Show(MsgBox.OwnerWindow(this), "Thêm Combo", "Giá combo (đồng)", "VD: 50000");
            long.TryParse((priceStr ?? "").Replace(",", "").Replace(".", ""), out long price);

            var (ok, msg, _) = await PromotionBUS.Add(new PromotionDTO
            {
                Loai = "combo",
                Ten = name,
                BaoGom = items ?? "",
                GiaCombo = price,
                GiaGoc = price + 15000,
                TietKiem = 15000,
                TrangThai = "Đang bán"
            });
            if (ok) { await LoadComboGrid(); MsgBox.Show(MsgBox.OwnerWindow(this), "Đã thêm combo!", "Thành công", MsgBox.MessageBoxType.Success); }
            else MsgBox.Show(MsgBox.OwnerWindow(this), msg, "Lỗi", MsgBox.MessageBoxType.Error);
        }

        // ---------------- VOUCHER ----------------
        private async Task LoadVoucherGrid()
        {
            Theme.StyleGrid(dgvVoucher);
            var dt = new DataTable();
            dt.Columns.Add("Mã");
            dt.Columns.Add("Mã voucher");
            dt.Columns.Add("Giảm");
            dt.Columns.Add("Hạn sử dụng");
            dt.Columns.Add("Đã dùng", typeof(int));
            dt.Columns.Add("Còn lại", typeof(int));
            dt.Columns.Add("Trạng thái");
            try
            {
                foreach (var kv in (await PromotionBUS.GetAll()).Where(x => x.Value.Loai == "voucher"))
                {
                    var p = kv.Value;
                    dt.Rows.Add(kv.Key, p.Ma, p.Giam, p.HanSuDung, p.DaDung, p.ConLai, p.TrangThai);
                }
            }
            catch { }
            dgvVoucher.DataSource = dt;
            if (dgvVoucher.Columns.Contains("Mã")) dgvVoucher.Columns["Mã"].Visible = false;
            dgvVoucher.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private async Task AddVoucher()
        {
            string code = txtVoucherCode.Text.Trim().ToUpper();
            string disc = txtVoucherDiscount.Text.Trim();
            if (string.IsNullOrEmpty(code))
            {
                MsgBox.Show(MsgBox.OwnerWindow(this), "Vui lòng nhập mã voucher!", "Thông báo", MsgBox.MessageBoxType.Warning);
                return;
            }
            var (ok, msg, _) = await PromotionBUS.Add(new PromotionDTO
            {
                Loai = "voucher",
                Ma = code,
                Giam = string.IsNullOrEmpty(disc) ? "10%" : disc + "%",
                HanSuDung = DateTime.Now.AddMonths(1).ToString("dd/MM/yyyy"),
                DaDung = 0,
                ConLai = 50,
                TrangThai = "🟢 Hoạt động"
            });
            if (ok)
            {
                txtVoucherCode.Clear();
                txtVoucherDiscount.Clear();
                await LoadVoucherGrid();
                MsgBox.Show(MsgBox.OwnerWindow(this), $"Đã tạo voucher: {code} — Giảm {disc}%", "Thành công", MsgBox.MessageBoxType.Success);
            }
            else MsgBox.Show(MsgBox.OwnerWindow(this), msg, "Lỗi", MsgBox.MessageBoxType.Error);
        }

        private void SwitchTab(Guna2Button active, Panel panel)
        {
            foreach (var b in new[] { btnHappy, btnCombo, btnVoucher })
            {
                b.FillColor = Color.Transparent;
                b.ForeColor = Theme.TextPri;
                b.BorderColor = Theme.Border;
            }
            active.FillColor = Theme.Teal;
            active.ForeColor = Color.White;
            active.BorderColor = Theme.Teal;

            foreach (var p in new[] { pnlHappy, pnlCombo, pnlVoucher })
                p.Visible = false;
            panel.Visible = true;
        }
    }
}
