using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace GUI
{
#pragma warning disable IDE1006
    public partial class ucCRM_Order : UserControl
#pragma warning restore IDE1006
    {
        public ucCRM_Order()
        {
            InitializeComponent();
            GridColumnGuard.SyncColumnNames(dgvCustomers);

            // Lọc trực tiếp khi gõ, không cần bấm nút Tìm
            txtSearch.TextChanged += BtnSearch_Click;

            DgvRefresh.Attach(dgvCustomers, LoadMockData);
        }

        // Double-click 1 dòng -> form chi tiết read-only đủ field
        private void DgvCustomers_CellDoubleClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            RecordDetail.FromRow(dgvCustomers.Rows[e.RowIndex], "Chi tiết khách hàng")
                        .ShowDialog(MsgBox.OwnerWindow(this));
        }

        // Sửa khách hàng đang chọn (khoá Mã KH)
        private void BtnEditCustomer_Click(object? sender, EventArgs e)
        {
            if (dgvCustomers.CurrentRow == null || dgvCustomers.CurrentRow.Index < 0)
            {
                MsgBox.Show(MsgBox.OwnerWindow(this), "Vui lòng chọn một khách hàng để sửa!", "Thông báo", MsgBox.MessageBoxType.Warning);
                return;
            }
            RecordEdit.EditRow(dgvCustomers.CurrentRow, "Sửa khách hàng", MsgBox.OwnerWindow(this));
        }

        private void UcCRM_Order_Load(object? sender, EventArgs e) => LoadMockData();

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

            // Cân bề rộng cho MỌI cột (nếu chỉ set vài cột, các cột còn lại giữ mặc định 100
            // và nuốt hết chỗ → Mã KH / Tên khách bị bóp, tên bị cắt "Nguyễn T...").
            dgvCustomers.Columns["Mã KH"].FillWeight          = 9;
            dgvCustomers.Columns["Tên khách hàng"].FillWeight = 24;
            dgvCustomers.Columns["Số điện thoại"].FillWeight  = 17;
            dgvCustomers.Columns["Email"].FillWeight          = 32;
            dgvCustomers.Columns["Điểm tích lũy"].FillWeight  = 10;
            dgvCustomers.Columns["Tổng đơn"].FillWeight       = 8;
            dgvCustomers.Columns["Điểm tích lũy"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvCustomers.Columns["Tổng đơn"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private void BtnSearch_Click(object? sender, EventArgs e)
        {
            // Quét mọi cột: mã KH, tên, SĐT, email, điểm tích lũy, tổng đơn
            if (dgvCustomers.DataSource is DataTable dt)
                dt.DefaultView.RowFilter = SearchFilter.AllColumnsFilter(dt, txtSearch.Text);
        }

        private void BtnAddCustomer_Click(object sender, EventArgs e)
        {
            txtName.Clear();
            txtPhone.Clear();
            txtEmail.Clear();
            lblPointsValue.Text = "0";
            txtName.Focus();
        }

        private void BtnReport_Click(object? sender, EventArgs e)
        {
            int totalCustomers = 0;
            if (dgvCustomers.DataSource is DataTable dt)
                totalCustomers = dt.DefaultView.Count;

            string report =
                "BÁO CÁO KHÁCH HÀNG\n" +
                $"Thời gian: {DateTime.Now:HH:mm dd/MM/yyyy}\n" +
                "──────────────────\n" +
                $"• Tổng khách hàng: {totalCustomers}\n" +
                $"• Từ khóa tìm kiếm: {(string.IsNullOrEmpty(txtSearch.Text) ? "(không)" : txtSearch.Text)}\n" +
                "──────────────────\n" +
                "Gửi báo cáo cho quản lý qua Chat?";

            var result = MsgBox.Show(MsgBox.OwnerWindow(this), report, "Báo cáo khách hàng", MsgBox.MessageBoxType.Warning);

            if (result == DialogResult.Yes)
            {
                MsgBox.Show(
                    MsgBox.OwnerWindow(this),
                    "Đã gửi báo cáo cho quản lý!\nQuản lý sẽ duyệt qua Chat nội bộ.",
                    "Thành công", MsgBox.MessageBoxType.Success);
            }
        }

        private void BtnSaveCustomer_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text) || string.IsNullOrWhiteSpace(txtPhone.Text))
            {
                MsgBox.Show(MsgBox.OwnerWindow(this), "Vui lòng nhập tên và số điện thoại!", "Thông báo", MsgBox.MessageBoxType.Warning);
                return;
            }
            MsgBox.Show(MsgBox.OwnerWindow(this), $"Đã lưu thông tin khách hàng {txtName.Text}!", "Thành công", MsgBox.MessageBoxType.Success);
        }
    }
}
