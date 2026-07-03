using BUS;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace GUI
{
    public partial class ManagerProfileDetail : Form
    {
        public ManagerProfileDetail()
        {
            InitializeComponent();
            dgvManagers.AutoGenerateColumns = false; // cột khai trong Designer; tắt auto-gen ở .cs cho an toàn round-trip
            WindowChrome.Apply(this);
            LoadData();
            AutoFadeScroll.Attach(dgvManagers);
        }

        private async void LoadData()
        {
            var dt = new DataTable();
            dt.Columns.Add("Mã QL");
            dt.Columns.Add("Họ tên");
            dt.Columns.Add("Email");
            dt.Columns.Add("SĐT");
            dt.Columns.Add("Ngày vào");
            dt.Columns.Add("Trạng thái");
            dt.Columns.Add("Đơn tháng này", typeof(int));

            try
            {
                var emps   = await Task.Run(EmployeeBUS.GetAllEmployeesAsync);
                var orders = await OrderBUS.GetAll();
                var now = DateTime.Now;
                long monthStart = new DateTimeOffset(new DateTime(now.Year, now.Month, 1)).ToUnixTimeMilliseconds();

                foreach (var m in emps.Where(x => (x.Role ?? "").ToLower() == "manager"))
                {
                    int cnt = orders.Values.Count(o => o.EmployeeId == m.EmployeeId && o.CreatedAt >= monthStart);
                    dt.Rows.Add(m.EmployeeId, m.FullName, m.Email, m.PhoneNumber,
                                m.HireDate ?? "", m.Status == "active" ? "Đang làm" : "Nghỉ", cnt);
                }
            }
            catch { /* offline → bảng trống */ }

            dgvManagers.DataSource = dt;
            dgvManagers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvManagers.Columns[0].FillWeight = 8;
            dgvManagers.Columns[1].FillWeight = 16;
            dgvManagers.Columns[2].FillWeight = 22;
            dgvManagers.Columns[3].FillWeight = 13;
            dgvManagers.Columns[4].FillWeight = 12;
            dgvManagers.Columns[5].FillWeight = 11;
            dgvManagers.Columns[6].FillWeight = 10;

            foreach (DataGridViewRow row in dgvManagers.Rows)
            {
                string st = row.Cells[5].Value?.ToString() ?? "";
                row.Cells[5].Style.ForeColor = st == "Đang làm"
                    ? Color.MediumSeaGreen : Color.Orange;
            }
        }

        private void btnClose_Click(object sender, EventArgs e) => Close();
    }
}
