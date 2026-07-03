using BUS;
using DTO;
using System;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI2.WinForms;

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
            _cmbMonth.SelectedIndexChanged += (s, e) => _ = LoadData();

            btnExport.Click += (s, e) =>
                GridExporter.ExportExcel(_dgv, MsgBox.OwnerWindow(this),
                    $"TienChi_{DateTime.Now:yyyyMM}", $"Tiền chi tháng {DateTime.Now.Month}");

            // Double-click 1 dòng -> form chi tiết read-only đủ field (kể cả cột ẩn)
            _dgv.CellDoubleClick += Dgv_CellDoubleClick;

            DgvRefresh.Attach(_dgv, () => _ = LoadData());

            Load += (s, e) => _ = LoadData();
        }

        private int SelectedMonth() => _cmbMonth.SelectedIndex >= 0 ? _cmbMonth.SelectedIndex + 1 : DateTime.Now.Month;

        private async Task LoadData()
        {
            int month = SelectedMonth();
            _dt = new DataTable();
            _dt.Columns.Add("Mã");   // ẩn (đọc qua DataRowView)
            _dt.Columns.Add("Ngày");
            _dt.Columns.Add("Danh mục");
            _dt.Columns.Add("Mô tả");
            _dt.Columns.Add("Số tiền", typeof(long));
            _dt.Columns.Add("Người chi");
            _dt.Columns.Add("Chứng từ");
            _dt.Columns.Add("Ghi chú");

            try
            {
                var all = await ExpenseBUS.GetAll();
                var emps = (await EmployeeBUS.GetAllEmployeesAsync())
                    .Where(x => x.EmployeeId != null).ToDictionary(x => x.EmployeeId!, x => x.FullName ?? x.EmployeeId!);

                foreach (var kv in all.OrderByDescending(x => x.Value.Timestamp))
                {
                    var ex = kv.Value;
                    if (DateTime.TryParseExact(ex.Ngay, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out var d)
                        && d.Month != month) continue;
                    string payer = ex.NguoiChi ?? "";
                    if (payer != null && emps.TryGetValue(payer, out var n)) payer = n;
                    _dt.Rows.Add(kv.Key, ex.Ngay, ex.DanhMuc, ex.MoTa, ex.SoTien, payer, ex.ChungTu, ex.GhiChu);
                }
            }
            catch { /* offline */ }

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

        // Sửa khoản chi đang chọn (lưu thật)
        private async void BtnEditExpense_Click(object? sender, EventArgs e)
        {
            if (_dgv.CurrentRow == null || _dgv.CurrentRow.Index < 0)
            {
                MsgBox.Show(MsgBox.OwnerWindow(this), "Vui lòng chọn một khoản chi để sửa!", "Thông báo", MsgBox.MessageBoxType.Warning);
                return;
            }
            string id = (_dgv.CurrentRow.DataBoundItem as DataRowView)?["Mã"]?.ToString() ?? "";
            if (RecordEdit.EditRow(_dgv.CurrentRow, "Sửa khoản chi", MsgBox.OwnerWindow(this)))
            {
                var rv = _dgv.CurrentRow.DataBoundItem as DataRowView;
                if (rv != null && !string.IsNullOrEmpty(id))
                {
                    long.TryParse(rv["Số tiền"]?.ToString(), out long amt);
                    await ExpenseBUS.Update(id, new
                    {
                        ngay = rv["Ngày"]?.ToString() ?? "",
                        danh_muc = rv["Danh mục"]?.ToString() ?? "",
                        mo_ta = rv["Mô tả"]?.ToString() ?? "",
                        so_tien = amt,
                        chung_tu = rv["Chứng từ"]?.ToString() ?? "",
                        ghi_chu = rv["Ghi chú"]?.ToString() ?? ""
                    });
                }
                await LoadData();
            }
        }

        private async void BtnAdd_Click(object? sender, EventArgs e)
        {
            string? desc = InputDialog.Show(MsgBox.OwnerWindow(this), "Thêm khoản chi", "Mô tả khoản chi", "VD: Nhập nguyên liệu...");
            if (string.IsNullOrEmpty(desc)) return;
            string? amtStr = InputDialog.Show(MsgBox.OwnerWindow(this), "Thêm khoản chi", "Số tiền (đồng)", "VD: 500000");
            long.TryParse((amtStr ?? "").Replace(",", "").Replace(".", ""), out long amt);
            string? cat = InputDialog.Show(MsgBox.OwnerWindow(this), "Thêm khoản chi", "Danh mục (Nhân sự / Nguyên liệu / Chi khác)", "Chi khác");

            var dto = new ExpenseDTO
            {
                Ngay = DateTime.Now.ToString("dd/MM/yyyy"),
                DanhMuc = string.IsNullOrWhiteSpace(cat) ? "Chi khác" : cat,
                MoTa = desc,
                SoTien = amt,
                NguoiChi = GlobalSession.CurrentUser?.EmployeeId ?? "",
                ChungTu = "",
                GhiChu = "",
                Timestamp = DateTimeOffset.Now.ToUnixTimeMilliseconds()
            };
            var (ok, msg, _) = await ExpenseBUS.Add(dto);
            if (ok)
            {
                MsgBox.Show(MsgBox.OwnerWindow(this), "Đã thêm khoản chi!", "Thành công", MsgBox.MessageBoxType.Success);
                await LoadData();
            }
            else MsgBox.Show(MsgBox.OwnerWindow(this), msg, "Lỗi", MsgBox.MessageBoxType.Error);
        }
    }
}
