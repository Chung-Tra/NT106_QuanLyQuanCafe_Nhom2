using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace GUI
{
    public partial class ucCRM_OrderStaff : UserControl
    {
        public ucCRM_OrderStaff()
        {
            InitializeComponent();
            btnReport.Click += btnReport_Click;
            this.Load += (s, e) => LoadMockData();
        }

        private void LoadMockData()
        {
            DataTable dt = new();
            dt.Columns.Add("Mã KH");
            dt.Columns.Add("Tên khách hàng");
            dt.Columns.Add("Số điện thoại");
            dt.Columns.Add("Email");
            dt.Columns.Add("Điểm tích lũy", typeof(int));
            dt.Columns.Add("Tổng đơn", typeof(int));

            dt.Rows.Add("KH001", "Nguyễn Thị Lan", "0901234567", "lan.nguyen@email.com", 1520, 45);
            dt.Rows.Add("KH002", "Trần Văn Minh", "0912345678", "minh.tran@email.com", 850, 28);
            dt.Rows.Add("KH003", "Lê Hồng Phúc", "0923456789", "phuc.le@email.com", 2100, 62);
            dt.Rows.Add("KH004", "Phạm Thanh Hà", "0934567890", "ha.pham@email.com", 450, 15);
            dt.Rows.Add("KH005", "Đỗ Minh Quân", "0945678901", "quan.do@email.com", 3200, 95);
            dt.Rows.Add("KH006", "Võ Thị Hương", "0956789012", "huong.vo@email.com", 680, 22);

            dgvCustomers.DataSource = dt;
            dgvCustomers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCustomers.RowHeadersVisible = false;

            dgvCustomers.Columns["Mã KH"].FillWeight = 10;
            dgvCustomers.Columns["Tên khách hàng"].FillWeight = 25;
            dgvCustomers.Columns["Điểm tích lũy"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvCustomers.Columns["Tổng đơn"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (dgvCustomers.DataSource is DataTable dt)
            {
                string keyword = txtSearch.Text.Trim().Replace("'", "''");
                if (string.IsNullOrEmpty(keyword))
                    dt.DefaultView.RowFilter = "";
                else
                    dt.DefaultView.RowFilter = $"[Tên khách hàng] LIKE '%{keyword}%' OR [Số điện thoại] LIKE '%{keyword}%'";
            }
        }

        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            txtName.Clear();
            txtPhone.Clear();
            txtEmail.Clear();
            lblPointsValue.Text = "0";
            txtName.Focus();
        }

        private void btnReport_Click(object? sender, EventArgs e)
        {
            int totalCustomers = 0;
            if (dgvCustomers.DataSource is DataTable dt)
                totalCustomers = dt.DefaultView.Count;

            string report =
                $"BÁO CÁO KHÁCH HÀNG\n" +
                $"Thời gian: {DateTime.Now:HH:mm dd/MM/yyyy}\n" +
                $"──────────────────\n" +
                $"• Tổng khách hàng: {totalCustomers}\n" +
                $"• Từ khóa tìm kiếm: {(string.IsNullOrEmpty(txtSearch.Text) ? "(không)" : txtSearch.Text)}\n" +
                $"──────────────────\n" +
                $"Gửi báo cáo cho quản lý qua Chat?";

            var result = MessageBox.Show(report, "Báo cáo khách hàng",
                MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (result == DialogResult.Yes)
            {
                MsgBox.Show(
                    "Đã gửi báo cáo cho quản lý!\nQuản lý sẽ duyệt qua Chat nội bộ.",
                    "Thành công", MsgBox.MessageBoxType.Success);
            }
        }

        private void btnSaveCustomer_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text) || string.IsNullOrWhiteSpace(txtPhone.Text))
            {
                MsgBox.Show("Vui lòng nhập tên và số điện thoại!", "Thông báo", MsgBox.MessageBoxType.Warning);
                return;
            }
            MsgBox.Show($"Đã lưu thông tin khách hàng {txtName.Text}!", "Thành công", MsgBox.MessageBoxType.Success);
        }
    }
}
