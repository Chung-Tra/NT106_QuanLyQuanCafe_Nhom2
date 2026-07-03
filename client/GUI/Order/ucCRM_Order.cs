using BUS;
using DTO;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
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

            DgvRefresh.Attach(dgvCustomers, () => _ = LoadRealData());
        }

        // Double-click 1 dòng -> form chi tiết read-only đủ field
        private void DgvCustomers_CellDoubleClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            RecordDetail.FromRow(dgvCustomers.Rows[e.RowIndex], "Chi tiết khách hàng")
                        .ShowDialog(MsgBox.OwnerWindow(this));
        }

        // Sửa khách hàng đang chọn (khoá Mã KH) — lưu thật lên Firebase
        private async void BtnEditCustomer_Click(object? sender, EventArgs e)
        {
            if (dgvCustomers.CurrentRow == null || dgvCustomers.CurrentRow.Index < 0)
            {
                MsgBox.Show(MsgBox.OwnerWindow(this), "Vui lòng chọn một khách hàng để sửa!", "Thông báo", MsgBox.MessageBoxType.Warning);
                return;
            }
            string id = dgvCustomers.CurrentRow.Cells["Mã KH"].Value?.ToString() ?? "";
            if (RecordEdit.EditRow(dgvCustomers.CurrentRow, "Sửa khách hàng", MsgBox.OwnerWindow(this)))
            {
                var row = dgvCustomers.CurrentRow;
                int.TryParse(row.Cells["Điểm tích lũy"].Value?.ToString(), out int pts);
                int.TryParse(row.Cells["Tổng đơn"].Value?.ToString(), out int orders);
                var payload = new
                {
                    ten_khach_hang = row.Cells["Tên khách hàng"].Value?.ToString() ?? "",
                    so_dien_thoai = row.Cells["Số điện thoại"].Value?.ToString() ?? "",
                    email = row.Cells["Email"].Value?.ToString() ?? "",
                    diem_tich_luy = pts,
                    tong_don = orders
                };
                var (ok, msg) = await CustomerBUS.Update(id, payload);
                if (!ok) MsgBox.Show(MsgBox.OwnerWindow(this), msg, "Lỗi lưu", MsgBox.MessageBoxType.Error);
                await LoadRealData();
            }
        }

        private void UcCRM_Order_Load(object? sender, EventArgs e) => _ = LoadRealData();

        private async Task LoadRealData()
        {
            DataTable dt = new();
            dt.Columns.Add("Mã KH");
            dt.Columns.Add("Tên khách hàng");
            dt.Columns.Add("Số điện thoại");
            dt.Columns.Add("Email");
            dt.Columns.Add("Điểm tích lũy", typeof(int));
            dt.Columns.Add("Tổng đơn", typeof(int));

            try
            {
                var customers = await CustomerBUS.GetAll();
                foreach (var kv in customers.OrderBy(c => c.Key))
                {
                    var c = kv.Value;
                    dt.Rows.Add(kv.Key, c.Name, c.PhoneNumber, c.Email, c.LoyaltyPoints, c.TotalOrders);
                }
            }
            catch { /* offline: bảng rỗng */ }

            dgvCustomers.DataSource = dt;
            dgvCustomers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCustomers.RowHeadersVisible = false;

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

        private async void BtnSaveCustomer_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text) || string.IsNullOrWhiteSpace(txtPhone.Text))
            {
                MsgBox.Show(MsgBox.OwnerWindow(this), "Vui lòng nhập tên và số điện thoại!", "Thông báo", MsgBox.MessageBoxType.Warning);
                return;
            }

            var owner = MsgBox.OwnerWindow(this);
            var dto = new CustomerDTO
            {
                Name = txtName.Text.Trim(),
                PhoneNumber = txtPhone.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                LoyaltyPoints = 0,
                TotalOrders = 0,
                CreatedAt = DateTimeOffset.Now.ToUnixTimeMilliseconds()
            };
            var (ok, msg, _) = await CustomerBUS.Add(dto);
            if (ok)
            {
                MsgBox.Show(owner, $"Đã lưu khách hàng {dto.Name}!", "Thành công", MsgBox.MessageBoxType.Success);
                txtName.Clear(); txtPhone.Clear(); txtEmail.Clear();
                await LoadRealData();
            }
            else
            {
                MsgBox.Show(owner, msg, "Lỗi lưu", MsgBox.MessageBoxType.Error);
            }
        }
    }
}
