using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using DTO;

namespace GUI
{
#pragma warning disable IDE1006
    public partial class ucExpenses_Admin : UserControl
#pragma warning restore IDE1006
    {
        private DataTable _dt = null!;

        public ucExpenses_Admin()
        {
            InitializeComponent();

            // Runtime styling of the Designer-declared grid
            Theme.StyleGrid(_dgv);

            // Month combo content + default selection derived from runtime date
            string[] months = ["Tháng 1","Tháng 2","Tháng 3","Tháng 4","Tháng 5","Tháng 6",
                                "Tháng 7","Tháng 8","Tháng 9","Tháng 10","Tháng 11","Tháng 12"];
            _cmbMonth.Items.AddRange(months);
            _cmbMonth.SelectedIndex = DateTime.Now.Month - 1;
            _cmbMonth.SelectedIndexChanged += (s, e) => LoadData();

            btnExport.Click += (s, e) =>
                GridExporter.ExportExcel(_dgv, MsgBox.OwnerWindow(this),
                    $"TienChi_{DateTime.Now:yyyyMM}", $"Tiền chi tháng {DateTime.Now.Month}");

            // Double-click 1 dòng -> form chi tiết read-only đủ field (kể cả cột ẩn)
            _dgv.CellDoubleClick += Dgv_CellDoubleClick;

            DgvRefresh.Attach(_dgv, LoadData);

            Load += (s, e) => LoadData();
        }

        private void LoadData()
        {
            _dt = new DataTable();
            _dt.Columns.Add("Ngày");
            _dt.Columns.Add("Danh mục");
            _dt.Columns.Add("Mô tả");
            _dt.Columns.Add("Số tiền", typeof(long));
            _dt.Columns.Add("Người chi");
            _dt.Columns.Add("Chứng từ");
            _dt.Columns.Add("Ghi chú");

            _dt.Rows.Add("01/06/2026", "Nhân sự",       "Lương tháng 6 — Nguyễn Văn An (Manager)",   15200000L, "Admin",     "PH-001", "Đã chuyển khoản");
            _dt.Rows.Add("02/06/2026", "Nguyên liệu",   "Nhập cà phê Arabica 50kg — Công ty ABC",     8500000L,  "Manager",   "PH-002", "Hóa đơn VAT");
            _dt.Rows.Add("03/06/2026", "Nguyên liệu",   "Nhập sữa tươi 200L — Vinamilk",              3200000L,  "Manager",   "PH-003", "");
            _dt.Rows.Add("05/06/2026", "Chi khác",      "Sửa chữa máy espresso #1",                   2800000L,  "Admin",     "PH-004", "Bảo hành 3 tháng");
            _dt.Rows.Add("07/06/2026", "Nhân sự",       "Lương tháng 6 — Toàn bộ barista (6 người)", 42000000L, "Admin",     "PH-005", "Đã chuyển khoản");
            _dt.Rows.Add("10/06/2026", "Chi khác",      "Tiền điện tháng 6",                          4500000L,  "Admin",     "PH-006", "Hóa đơn EVNHCM");
            _dt.Rows.Add("12/06/2026", "Nguyên liệu",   "Nhập đường, ly, ống hút",                    1800000L,  "Manager",   "PH-007", "");
            _dt.Rows.Add("15/06/2026", "Chi khác",      "Tiền thuê mặt bằng T6",                     30000000L,  "Admin",     "PH-008", "Thanh toán trực tiếp");
            _dt.Rows.Add("18/06/2026", "Nguyên liệu",   "Nhập trà các loại",                          2200000L,  "Manager",   "PH-009", "");
            _dt.Rows.Add("20/06/2026", "Chi khác",      "Internet + điện thoại",                        850000L,  "Admin",     "PH-010", "");

            _dgv.DataSource = _dt;
            _dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            _dgv.Columns["colDate"].FillWeight     = 9;
            _dgv.Columns["colCategory"].FillWeight = 12;
            _dgv.Columns["colDesc"].FillWeight     = 30;
            _dgv.Columns["colAmount"].FillWeight   = 12;
            _dgv.Columns["colPayer"].FillWeight    = 9;
            _dgv.Columns["colVoucher"].FillWeight  = 8;
            _dgv.Columns["colNote"].FillWeight     = 20;

            _dgv.Columns["colAmount"].DefaultCellStyle.Format    = "N0";
            _dgv.Columns["colAmount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            ColorRows();
            UpdateStats();
        }

        private void ColorRows()
        {
            foreach (DataGridViewRow row in _dgv.Rows)
            {
                string cat = row.Cells["colCategory"].Value?.ToString() ?? "";
                Color c = cat switch
                {
                    "Nhân sự"      => Theme.Amber,
                    "Nguyên liệu"  => Theme.Teal,
                    _              => Theme.Purple,
                };
                row.Cells["colCategory"].Style.ForeColor = c;
                row.Cells["colCategory"].Style.Font      = Theme.F(9F, FontStyle.Bold);
            }
        }

        private void UpdateStats()
        {
            long total = 0, personnel = 0, ingredient = 0, other = 0;
            foreach (DataRow row in _dt.Rows)
            {
                long amt = (long)row["Số tiền"];
                total += amt;
                switch (row["Danh mục"].ToString())
                {
                    case "Nhân sự":     personnel  += amt; break;
                    case "Nguyên liệu": ingredient += amt; break;
                    default:            other      += amt; break;
                }
            }
            _lblTotal.Text      = Theme.Vnd(total);
            _lblPersonnel.Text  = Theme.Vnd(personnel);
            _lblIngredient.Text = Theme.Vnd(ingredient);
            _lblOther.Text      = Theme.Vnd(other);
        }

        private void Dgv_CellDoubleClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            RecordDetail.FromRow(_dgv.Rows[e.RowIndex], "Chi tiết khoản chi")
                        .ShowDialog(MsgBox.OwnerWindow(this));
        }

        // Sửa khoản chi đang chọn
        private void BtnEditExpense_Click(object? sender, EventArgs e)
        {
            if (_dgv.CurrentRow == null || _dgv.CurrentRow.Index < 0)
            {
                MsgBox.Show(MsgBox.OwnerWindow(this), "Vui lòng chọn một khoản chi để sửa!", "Thông báo", MsgBox.MessageBoxType.Warning);
                return;
            }
            if (RecordEdit.EditRow(_dgv.CurrentRow, "Sửa khoản chi", MsgBox.OwnerWindow(this)))
                UpdateStats();
        }

        private void BtnAdd_Click(object? sender, EventArgs e)
        {
            string? desc = InputDialog.Show(MsgBox.OwnerWindow(this), "Thêm khoản chi", "Mô tả khoản chi", "VD: Nhập nguyên liệu...");
            if (string.IsNullOrEmpty(desc)) return;

            _dt.Rows.Add(DateTime.Now.ToString("dd/MM/yyyy"), "Chi khác", desc, 0L, GlobalSession.CurrentUser?.FullName ?? "Admin", "---", "Mới thêm");
            UpdateStats();
            MsgBox.Show(MsgBox.OwnerWindow(this), "Đã thêm khoản chi. Vui lòng nhập số tiền vào cột 'Số tiền'.", "Thêm thành công", MsgBox.MessageBoxType.Success);
        }
    }
}
