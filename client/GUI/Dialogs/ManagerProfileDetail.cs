using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace GUI
{
    public partial class ManagerProfileDetail : Form
    {
        public ManagerProfileDetail()
        {
            InitializeComponent();
            LoadData();
            AutoFadeScroll.Attach(dgvManagers);
        }

        private void LoadData()
        {
            var dt = new DataTable();
            dt.Columns.Add("Mã QL");
            dt.Columns.Add("Họ tên");
            dt.Columns.Add("Email");
            dt.Columns.Add("SĐT");
            dt.Columns.Add("Ngày vào");
            dt.Columns.Add("Trạng thái");
            dt.Columns.Add("Đơn tháng này", typeof(int));

            dt.Rows.Add("QL001", "Nguyễn Văn An", "an.nguyen@cafe.com",  "0901 234 567", "01/01/2023", "Đang làm", 142);
            dt.Rows.Add("QL002", "Trần Minh",      "minh.tran@cafe.com",  "0912 345 678", "15/03/2022", "Đang làm", 98);
            dt.Rows.Add("QL003", "Phạm Thu Hà",    "ha.pham@cafe.com",    "0923 456 789", "10/06/2023", "Xin nghỉ", 74);

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
