using BUS;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class ucPayroll_Admin : UserControl
    {
        // Lương cơ bản mặc định theo bộ phận (dùng khi hiển thị nhanh ở selection)
        private static readonly Dictionary<string, decimal> BaseSalaryByRole = new()
        {
            ["Quản lý"] = 12000000m,
            ["Pha chế"] = 7000000m,
            ["Order Staff"] = 6500000m,
            ["Bảo vệ"] = 6000000m,
            ["Thủ kho"] = 7500000m,
        };

        public ucPayroll_Admin()
        {
            InitializeComponent();
            GridColumnGuard.SyncColumnNames(dgvPayroll);
            DgvRefresh.Attach(dgvPayroll, () => _ = LoadRealPayroll());
        }

        private void DgvPayroll_CellDoubleClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            RecordDetail.FromRow(dgvPayroll.Rows[e.RowIndex], "Chi tiết bảng lương")
                        .ShowDialog(MsgBox.OwnerWindow(this));
        }

        // Sửa dòng lương đang chọn (khoá Mã NV) — lưu thật lên Firebase
        private async void BtnEditPayroll_Click(object? sender, EventArgs e)
        {
            if (dgvPayroll.CurrentRow == null || dgvPayroll.CurrentRow.Index < 0)
            {
                MsgBox.Show(MsgBox.OwnerWindow(this), "Vui lòng chọn một nhân viên để sửa!", "Thông báo", MsgBox.MessageBoxType.Warning);
                return;
            }
            string id = (dgvPayroll.CurrentRow?.DataBoundItem as DataRowView)?["Mã lương"]?.ToString() ?? "";
            if (string.IsNullOrEmpty(id)) return;

            if (RecordEdit.EditRow(dgvPayroll.CurrentRow, "Sửa bảng lương", MsgBox.OwnerWindow(this)))
            {
                var row = dgvPayroll.CurrentRow;
                decimal D(string c) => decimal.TryParse(row.Cells[c].Value?.ToString(), out var v) ? v : 0;
                decimal total = AppMath.PayrollTotal(D("Lương CB"), D("Phụ cấp"), D("Thưởng FB"), D("Thưởng lễ"), D("Trừ lương"));
                int.TryParse(row.Cells["Ngày công"].Value?.ToString(), out int days);

                var payload = new
                {
                    ngay_cong = days,
                    luong_co_ban = D("Lương CB"),
                    phu_cap = D("Phụ cấp"),
                    thuong_feedback = D("Thưởng FB"),
                    thuong_le = D("Thưởng lễ"),
                    tru_luong = D("Trừ lương"),
                    ly_do_tru = row.Cells["Lý do trừ"].Value?.ToString() ?? "",
                    tong_luong = total
                };
                await SalaryBUS.Update(id, payload);
                await LoadRealPayroll();
            }
        }

        private void ucPayroll_Admin_Load(object? sender, EventArgs e)
        {
            if (cmbMonth.Items.Count >= 12)
                cmbMonth.SelectedIndex = DateTime.Now.Month - 1;
            _ = LoadRealPayroll();
        }

        private int SelectedMonth() => cmbMonth.SelectedIndex >= 0 ? cmbMonth.SelectedIndex + 1 : DateTime.Now.Month;

        private async Task LoadRealPayroll()
        {
            int month = SelectedMonth();
            DataTable dt = new();
            dt.Columns.Add("Mã lương");
            dt.Columns.Add("Mã NV");
            dt.Columns.Add("Họ tên");
            dt.Columns.Add("Bộ phận");
            dt.Columns.Add("Ngày công", typeof(int));
            dt.Columns.Add("Lương CB", typeof(decimal));
            dt.Columns.Add("Phụ cấp", typeof(decimal));
            dt.Columns.Add("Thưởng FB", typeof(decimal));
            dt.Columns.Add("Thưởng lễ", typeof(decimal));
            dt.Columns.Add("Trừ lương", typeof(decimal));
            dt.Columns.Add("Lý do trừ");
            dt.Columns.Add("Tổng lương", typeof(decimal));

            decimal total = 0;
            int count = 0;
            try
            {
                var salaries = await SalaryBUS.GetAll();
                var emps = (await EmployeeBUS.GetAllEmployeesAsync())
                    .Where(x => x.EmployeeId != null)
                    .ToDictionary(x => x.EmployeeId!, x => x);

                foreach (var kv in salaries.Where(s => s.Value.Month == month).OrderBy(s => s.Key))
                {
                    var s = kv.Value;
                    string name = "", dept = "";
                    if (s.EmployeeId != null && emps.TryGetValue(s.EmployeeId, out var emp))
                    {
                        name = emp.FullName ?? "";
                        dept = EmployeeText.RoleVi(emp.Role);
                    }
                    dt.Rows.Add(kv.Key, s.EmployeeId, name, dept, s.WorkDays,
                        s.BaseSalary, s.Allowance, s.FeedbackBonus, s.HolidayBonus,
                        s.Deduction, s.DeductionReason, s.TotalSalary);
                    total += s.TotalSalary;
                    count++;
                }
            }
            catch { /* offline */ }

            dgvPayroll.DataSource = dt;
            dgvPayroll.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPayroll.RowHeadersVisible = false;
            if (dgvPayroll.Columns.Contains("Mã lương")) dgvPayroll.Columns["Mã lương"].Visible = false;

            dgvPayroll.Columns["Mã NV"].FillWeight = 7;
            dgvPayroll.Columns["Họ tên"].FillWeight = 16;
            dgvPayroll.Columns["Bộ phận"].FillWeight = 10;
            dgvPayroll.Columns["Ngày công"].FillWeight = 7;
            dgvPayroll.Columns["Lương CB"].FillWeight = 10;
            dgvPayroll.Columns["Phụ cấp"].FillWeight = 8;
            dgvPayroll.Columns["Thưởng FB"].FillWeight = 8;
            dgvPayroll.Columns["Thưởng lễ"].FillWeight = 8;
            dgvPayroll.Columns["Trừ lương"].FillWeight = 8;
            dgvPayroll.Columns["Lý do trừ"].FillWeight = 14;
            dgvPayroll.Columns["Tổng lương"].FillWeight = 12;

            foreach (string col in new[] { "Lương CB", "Phụ cấp", "Thưởng FB", "Thưởng lễ", "Trừ lương", "Tổng lương" })
            {
                dgvPayroll.Columns[col].DefaultCellStyle.Format = "N0";
                dgvPayroll.Columns[col].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
            dgvPayroll.Columns["Ngày công"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            foreach (DataGridViewRow row in dgvPayroll.Rows)
            {
                if (row.Cells["Trừ lương"].Value is decimal val && val < 0)
                {
                    row.Cells["Trừ lương"].Style.ForeColor = Color.IndianRed;
                    row.Cells["Lý do trừ"].Style.ForeColor = Color.IndianRed;
                }
                if (row.Cells["Thưởng FB"].Value is decimal fbVal && fbVal >= 1000000)
                    row.Cells["Thưởng FB"].Style.ForeColor = Color.Gold;
            }

            lblTotalSalary.Text = total.ToString("N0") + " đ";
            lblEmployeeCount.Text = count + " nhân viên";
        }

        private void cmbMonth_SelectedIndexChanged(object sender, EventArgs e) => _ = LoadRealPayroll();

        // Tính lại tổng lương cho tất cả bản ghi của tháng đang chọn rồi lưu.
        private async void btnApplyBP_Click(object sender, EventArgs e)
        {
            int month = SelectedMonth();
            int updated = 0;
            try
            {
                var salaries = await SalaryBUS.GetAll();
                foreach (var kv in salaries.Where(s => s.Value.Month == month))
                {
                    var s = kv.Value;
                    decimal total = AppMath.PayrollTotal(s.BaseSalary, s.Allowance, s.FeedbackBonus, s.HolidayBonus, s.Deduction);
                    if (total != s.TotalSalary)
                    {
                        await SalaryBUS.Update(kv.Key, new { tong_luong = total });
                        updated++;
                    }
                }
            }
            catch (Exception ex)
            {
                MsgBox.Show(MsgBox.OwnerWindow(this), "Lỗi tính lương: " + ex.Message, "Lỗi", MsgBox.MessageBoxType.Error);
                return;
            }

            MsgBox.Show(MsgBox.OwnerWindow(this),
                $"Đã tính lại tổng lương cho tháng {month}.\nCập nhật {updated} bản ghi.\n\nTổng lương = Lương CB + Phụ cấp + Thưởng FB + Thưởng lễ − Trừ lương.",
                "Tính lương", MsgBox.MessageBoxType.Success);
            await LoadRealPayroll();
        }

        private void dgvPayroll_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvPayroll.CurrentRow == null) return;
            var row = dgvPayroll.CurrentRow;
            string name = row.Cells["Họ tên"].Value?.ToString() ?? "";
            string deductReason = row.Cells["Lý do trừ"].Value?.ToString() ?? "";
            if (!string.IsNullOrEmpty(deductReason))
            {
                lblTitle.Text = $"Bảng lương — {name} (Trừ: {deductReason})";
                lblTitle.ForeColor = Color.IndianRed;
            }
            else
            {
                lblTitle.Text = "Bảng lương nhân viên";
                lblTitle.ForeColor = Color.White;
            }
        }
    }
}
