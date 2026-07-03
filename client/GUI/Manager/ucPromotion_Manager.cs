using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace GUI
{
    public partial class ucPromotion_Manager : UserControl
    {
        public ucPromotion_Manager()
        {
            InitializeComponent();

            // Tab switching
            btnHappy.Click += (s, e) => SwitchTab(btnHappy, pnlHappy);
            btnCombo.Click += (s, e) => SwitchTab(btnCombo, pnlCombo);
            btnVoucher.Click += (s, e) => SwitchTab(btnVoucher, pnlVoucher);

            // Happy Hour panel runtime wiring
            btnHappyEdit.Click += (s, e) => EditCurrent(dgvHappy, "Sửa Happy Hour");
            btnHappyAdd.Click += (s, e) => MsgBox.Show(MsgBox.OwnerWindow(this), "Thêm Happy Hour thành công!", "Thành công", MsgBox.MessageBoxType.Success);

            // Combo panel runtime wiring
            btnComboAdd.Click += (s, e) => MsgBox.Show(MsgBox.OwnerWindow(this), "Tính năng thêm combo đang phát triển.", "Thông báo", MsgBox.MessageBoxType.Info);

            // Voucher panel runtime wiring
            btnVoucherGen.Click += (s, e) =>
            {
                string code = txtVoucherCode.Text.Trim().ToUpper();
                string disc = txtVoucherDiscount.Text.Trim();
                if (string.IsNullOrEmpty(code))
                {
                    MsgBox.Show(MsgBox.OwnerWindow(this), "Vui lòng nhập mã voucher!", "Thông báo", MsgBox.MessageBoxType.Warning);
                    return;
                }
                MsgBox.Show(MsgBox.OwnerWindow(this), $"Đã tạo voucher: {code} — Giảm {disc}%", "Thành công", MsgBox.MessageBoxType.Success);
            };

            // Runtime grid styling + data binding
            LoadHappyGrid();
            LoadComboGrid();
            LoadVoucherGrid();

            // Nút làm mới từng bảng: chỉ tải lại dữ liệu của bảng đó
            DgvRefresh.Attach(dgvHappy, LoadHappyGrid);
            DgvRefresh.Attach(dgvCombo, LoadComboGrid);
            DgvRefresh.Attach(dgvVoucher, LoadVoucherGrid);

            // Double-click 1 dòng -> form chi tiết read-only (đủ field, kể cả cột ẩn)
            dgvHappy.CellDoubleClick   += (s, e) => ShowDetail(dgvHappy, e, "Chi tiết Happy Hour");
            dgvCombo.CellDoubleClick   += (s, e) => ShowDetail(dgvCombo, e, "Chi tiết Combo");
            dgvVoucher.CellDoubleClick += (s, e) => ShowDetail(dgvVoucher, e, "Chi tiết Voucher");

            Load += (s, e) => SwitchTab(btnHappy, pnlHappy);
        }

        // Mở chi tiết read-only của dòng được double-click
        private void ShowDetail(Guna2DataGridView dgv, DataGridViewCellEventArgs e, string title)
        {
            if (e.RowIndex < 0) return;
            RecordDetail.FromRow(dgv.Rows[e.RowIndex], title).ShowDialog(MsgBox.OwnerWindow(this));
        }

        // Sửa dòng đang chọn (form sửa, khoá cột mã/ID)
        private void EditCurrent(Guna2DataGridView dgv, string title)
        {
            if (dgv.CurrentRow == null || dgv.CurrentRow.Index < 0)
            {
                MsgBox.Show(MsgBox.OwnerWindow(this), "Vui lòng chọn một dòng để sửa!", "Thông báo", MsgBox.MessageBoxType.Warning);
                return;
            }
            RecordEdit.EditRow(dgv.CurrentRow, title, MsgBox.OwnerWindow(this));
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

        private void LoadHappyGrid()
        {
            Theme.StyleGrid(dgvHappy);

            var dt = new DataTable();
            dt.Columns.Add("Tên chương trình");
            dt.Columns.Add("Khung giờ");
            dt.Columns.Add("Ngày áp dụng");
            dt.Columns.Add("Giảm (%)");
            dt.Columns.Add("Trạng thái");
            dt.Rows.Add("Happy Hour Chiều", "14:00 – 16:00", "T2, T3, T4, T5, T6", "20%", "🟢 Đang chạy");
            dt.Rows.Add("Sáng sớm Tươi", "07:00 – 09:00", "T2, T3, T4, T5, T6", "10%", "🟡 Tạm dừng");
            dt.Rows.Add("Cuối tuần vui", "10:00 – 12:00", "T7, CN", "15%", "🟢 Đang chạy");
            dgvHappy.DataSource = dt;
            dgvHappy.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvHappy.Columns["Tên chương trình"].FillWeight = 26;
            dgvHappy.Columns["Khung giờ"].FillWeight        = 16;
            dgvHappy.Columns["Ngày áp dụng"].FillWeight     = 26;
            dgvHappy.Columns["Giảm (%)"].FillWeight         = 12;
            dgvHappy.Columns["Trạng thái"].FillWeight       = 20;
        }

        private void LoadComboGrid()
        {
            Theme.StyleGrid(dgvCombo);

            var dt = new DataTable();
            dt.Columns.Add("Tên combo");
            dt.Columns.Add("Bao gồm");
            dt.Columns.Add("Giá gốc", typeof(long));
            dt.Columns.Add("Giá combo", typeof(long));
            dt.Columns.Add("Tiết kiệm", typeof(long));
            dt.Columns.Add("Trạng thái");
            dt.Rows.Add("Combo Sáng", "Cà phê đen + Bánh mì", 55000L, 45000L, 10000L, "Đang bán");
            dt.Rows.Add("Combo Sinh Tố", "2x Sinh tố + Bánh flan", 85000L, 70000L, 15000L, "Đang bán");
            dt.Rows.Add("Combo Đôi", "2 Latte + 1 Cookie", 90000L, 75000L, 15000L, "Đang bán");
            dt.Rows.Add("Combo Gia đình", "4x Trà sữa trân châu + 1 Bánh", 200000L, 170000L, 30000L, "Tạm dừng");
            dgvCombo.DataSource = dt;
            dgvCombo.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCombo.Columns["Giá gốc"].DefaultCellStyle.Format = "N0";
            dgvCombo.Columns["Giá combo"].DefaultCellStyle.Format = "N0";
            dgvCombo.Columns["Tiết kiệm"].DefaultCellStyle.Format = "N0";
            dgvCombo.Columns["Giá gốc"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvCombo.Columns["Giá combo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvCombo.Columns["Tiết kiệm"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvCombo.Columns["Tên combo"].FillWeight  = 20;
            dgvCombo.Columns["Bao gồm"].FillWeight    = 32;
            dgvCombo.Columns["Giá gốc"].FillWeight    = 12;
            dgvCombo.Columns["Giá combo"].FillWeight  = 12;
            dgvCombo.Columns["Tiết kiệm"].FillWeight  = 12;
            dgvCombo.Columns["Trạng thái"].FillWeight = 12;
        }

        private void LoadVoucherGrid()
        {
            Theme.StyleGrid(dgvVoucher);

            var dt = new DataTable();
            dt.Columns.Add("Mã voucher");
            dt.Columns.Add("Giảm");
            dt.Columns.Add("Hạn sử dụng");
            dt.Columns.Add("Đã dùng", typeof(int));
            dt.Columns.Add("Còn lại", typeof(int));
            dt.Columns.Add("Trạng thái");
            dt.Rows.Add("WELCOME10", "10%", "30/06/2026", 8, 42, "🟢 Hoạt động");
            dt.Rows.Add("CAFE20", "20%", "15/06/2026", 25, 0, "🔴 Hết hạn");
            dt.Rows.Add("SUMMER15", "15%", "31/08/2026", 3, 47, "🟢 Hoạt động");
            dt.Rows.Add("BIRTHDAY50", "50%", "24/07/2026", 1, 9, "🟢 Hoạt động");
            dt.Rows.Add("FREESHIP", "10K ship", "31/12/2026", 0, 100, "🟡 Chưa dùng");
            dgvVoucher.DataSource = dt;
            dgvVoucher.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvVoucher.Columns["Mã voucher"].FillWeight  = 22;
            dgvVoucher.Columns["Giảm"].FillWeight        = 12;
            dgvVoucher.Columns["Hạn sử dụng"].FillWeight = 18;
            dgvVoucher.Columns["Đã dùng"].FillWeight     = 12;
            dgvVoucher.Columns["Còn lại"].FillWeight     = 12;
            dgvVoucher.Columns["Trạng thái"].FillWeight  = 24;
        }
    }
}
