using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace GUI
{
    public partial class ucPayroll_Admin : UserControl
    {
        // Lương cố định theo bộ phận (Admin không cần nhập lại)
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
        }

        private void ucPayroll_Admin_Load(object? sender, EventArgs e)
        {
            cmbMonth.SelectedIndex = DateTime.Now.Month - 1;
            LoadMockPayroll();
        }

        private void LoadMockPayroll()
        {
            DataTable dt = new();
            dt.Columns.Add("Mã NV");
            dt.Columns.Add("Họ tên");
            dt.Columns.Add("Bộ phận");
            dt.Columns.Add("Ngày công", typeof(int));
            dt.Columns.Add("Lương CB", typeof(decimal));       // Lương cơ bản (tự tính theo bộ phận)
            dt.Columns.Add("Phụ cấp", typeof(decimal));
            dt.Columns.Add("Thưởng FB", typeof(decimal));      // Thưởng feedback tốt
            dt.Columns.Add("Thưởng lễ", typeof(decimal));      // Thưởng lễ
            dt.Columns.Add("Trừ lương", typeof(decimal));       // Trừ (nghỉ nhiều, đổ bể)
            dt.Columns.Add("Lý do trừ");
            dt.Columns.Add("Tổng lương", typeof(decimal));

            // NV1 - Manager, feedback tốt, thưởng lễ
            AddEmployee(dt, "NV001", "Nguyễn Văn An", "Quản lý", 26, 2000000m, 1500000m, 500000m, 0m, "");
            // NV2 - Barista, bị trừ vì nghỉ 5 ngày
            AddEmployee(dt, "NV002", "Trần Thị Bích", "Pha chế", 21, 500000m, 800000m, 500000m, -700000m, "Nghỉ 5 ngày (vượt 2 ngày)");
            // NV3 - Order Staff, bình thường
            AddEmployee(dt, "NV003", "Lê Hoàng Nam", "Order Staff", 25, 500000m, 600000m, 500000m, 0m, "");
            // NV4 - Security, thưởng lễ
            AddEmployee(dt, "NV004", "Phạm Minh Tuấn", "Bảo vệ", 28, 1000000m, 0m, 500000m, 0m, "");
            // NV5 - Barista, bị trừ vì làm vỡ máy xay
            AddEmployee(dt, "NV005", "Đỗ Thị Hương", "Pha chế", 24, 500000m, 400000m, 500000m, -1200000m, "Làm hỏng máy xay #2");
            // NV6 - Stockkeeper
            AddEmployee(dt, "NV006", "Võ Thanh Tùng", "Thủ kho", 26, 800000m, 700000m, 500000m, 0m, "");
            // NV7 - Order Staff, nhiều feedback tốt
            AddEmployee(dt, "NV007", "Hoàng Thị Mai", "Order Staff", 25, 500000m, 1200000m, 500000m, 0m, "");

            dgvPayroll.DataSource = dt;
            dgvPayroll.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPayroll.RowHeadersVisible = false;

            // Size columns
            dgvPayroll.Columns["Mã NV"].FillWeight = 7;
            dgvPayroll.Columns["Họ tên"].FillWeight = 16;
            dgvPayroll.Columns["Bộ phận"].FillWeight = 10;
            dgvPayroll.Columns["Ngày công"].FillWeight = 7;
            dgvPayroll.Columns["Lương CB"].FillWeight = 10;
            dgvPayroll.Columns["Phụ cấp"].FillWeight = 8;
            dgvPayroll.Columns["Thưởng FB"].FillWeight = 8;
            dgvPayroll.Columns["Thưởng lễ"].FillWeight = 8;
            dgvPayroll.Columns["Trừ lương"].FillWeight = 8;
            dgvPayroll.Columns["Lý do trừ"].FillWeight = 16;
            dgvPayroll.Columns["Tổng lương"].FillWeight = 10;

            foreach (string col in new[] { "Lương CB", "Phụ cấp", "Thưởng FB", "Thưởng lễ", "Trừ lương", "Tổng lương" })
            {
                dgvPayroll.Columns[col].DefaultCellStyle.Format = "N0";
                dgvPayroll.Columns[col].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
            dgvPayroll.Columns["Ngày công"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Color deductions red
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

            // Update summary
            decimal total = 0;
            foreach (DataRow row in dt.Rows)
                total += (decimal)row["Tổng lương"];

            lblTotalSalary.Text = total.ToString("N0") + " đ";
            lblEmployeeCount.Text = dt.Rows.Count + " nhân viên";
        }

        private void AddEmployee(DataTable dt, string id, string name, string dept, int days,
            decimal allowance, decimal fbBonus, decimal holidayBonus, decimal deduction, string deductReason)
        {
            decimal baseSalary = BaseSalaryByRole.GetValueOrDefault(dept, 6000000m);
            // Tính lương theo ngày công (26 ngày chuẩn)
            decimal actualBase = baseSalary * days / 26m;
            decimal total = actualBase + allowance + fbBonus + holidayBonus + deduction; // deduction is negative

            dt.Rows.Add(id, name, dept, days,
                Math.Round(actualBase), allowance, fbBonus, holidayBonus,
                deduction, deductReason, Math.Round(total));
        }

        private void cmbMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadMockPayroll();
        }

        private void btnApplyBP_Click(object sender, EventArgs e)
        {
            MsgBox.Show(
                "Đã tính lương tự động cho tất cả nhân viên!\n\n" +
                "• Lương cơ bản: Tự tính theo bộ phận\n" +
                "• Thưởng feedback: Dựa trên số feedback tốt\n" +
                "• Trừ lương: Tự trừ nếu nghỉ quá 3 ngày/tháng\n" +
                "• Thưởng lễ: Áp dụng cho tháng có ngày lễ",
                "Tính lương tự động",
                MsgBox.MessageBoxType.Success
            );
            LoadMockPayroll();
        }

        private void dgvPayroll_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvPayroll.CurrentRow == null) return;
            var row = dgvPayroll.CurrentRow;
            string name = row.Cells["Họ tên"].Value?.ToString() ?? "";
            string dept = row.Cells["Bộ phận"].Value?.ToString() ?? "";
            decimal baseSalary = BaseSalaryByRole.GetValueOrDefault(dept, 6000000m);

            // Show tooltip-like info (could be status bar)
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
