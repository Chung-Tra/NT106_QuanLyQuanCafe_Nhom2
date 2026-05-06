using BUS;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class ucOrders_Manager : UserControl
    {
        private static readonly string[] TableStatusOptions = { "Tất cả", "Đang phục vụ", "Chờ lên món", "Chờ thanh toán" };
        private List<TableModelDTO>? _originalTableData;
        private List<WarningWaitModelDTO> _kitchenWarnings = new();

        public ucOrders_Manager()
        {
            InitializeComponent();
            LoadDummyData();
        }

        private void LoadDummyData()
        {
            // Thêm các trạng thái vào ComboBox
            cboTableStatus.Items.Clear();
            cboTableStatus.Items.AddRange(TableStatusOptions);
            cboTableStatus.SelectedIndex = 0;
            // Tạo dữ liệu mẫu cho DataGridView
            _originalTableData = new()
            {
                new TableModelDTO { TableId = 1, TableName = "Bàn 01", Status = "Đang phục vụ", Progress = "Đã lên đủ", TotalAmount = "150,000 đ" },
                new TableModelDTO { TableId = 2, TableName = "Bàn 02", Status = "Chờ lên món", Progress = "Thiếu 2 món", TotalAmount = "85,000 đ" },
                new TableModelDTO { TableId = 5, TableName = "Bàn 05", Status = "Chờ lên món", Progress = "Thiếu 1 món", TotalAmount = "45,000 đ" },
                new TableModelDTO { TableId = 8, TableName = "Bàn 08", Status = "Đang phục vụ", Progress = "Đã lên đủ", TotalAmount = "210,000 đ" },
                new TableModelDTO { TableId = 12, TableName = "Bàn 12", Status = "Chờ thanh toán", Progress = "Đã xong", TotalAmount = "320,000 đ" }
            };

            dgvTableStatus.DataSource = _originalTableData;
            dgvTableStatus.Columns["TableId"].Visible = false;
            dgvTableStatus.Columns["TableName"].HeaderText = "Bàn";
            dgvTableStatus.Columns["Status"].HeaderText = "Trạng Thái";
            dgvTableStatus.Columns["Progress"].HeaderText = "Tiến độ món";
            dgvTableStatus.Columns["TotalAmount"].HeaderText = "Tạm Tính";

            dgvTableStatus.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTableStatus.RowHeadersVisible = false;

            _kitchenWarnings = new()
            {
                new WarningWaitModelDTO { TableName = "Bàn 02", DrinkName = "Cà phê sữa đá", WaitTimeMinutes = 18 },
                new WarningWaitModelDTO { TableName = "Bàn 05", DrinkName = "Trà đào cam sả", WaitTimeMinutes = 15 },
                new WarningWaitModelDTO { TableName = "Bàn 15", DrinkName = "Sinh tố dâu", WaitTimeMinutes = 25 },
                new WarningWaitModelDTO { TableName = "Bàn VIP 1", DrinkName = "Bò bít tết", WaitTimeMinutes = 30 }
            };
            lstKitchenWarning.DataSource = null;
            lstKitchenWarning.DataSource = _kitchenWarnings;
            lstKitchenWarning.DisplayMember = "DisplayText";
        }

        private void btnFilterTable_Click(object sender, EventArgs e)
        {
            if (cboTableStatus.SelectedItem == null || _originalTableData == null) return;

            string? selectedStatus = cboTableStatus.SelectedItem.ToString();

            if (selectedStatus == "Tất cả")
            {
                dgvTableStatus.DataSource = _originalTableData;
            }
            else
            {
                var filteredData = _originalTableData
                                    .Where(table => table.Status == selectedStatus)
                                    .ToList();

                dgvTableStatus.DataSource = filteredData;
            }
        }

        private void lstSoldOut_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cboTableStatus_TextChanged(object sender, EventArgs e)
        {

        }

        private void lstKitchenWarning_DoubleClick(object sender, EventArgs e)
        {
            // Kiểm tra xem người dùng có đang bấm vào một dòng dữ liệu hợp lệ hay không
            if (lstKitchenWarning.SelectedItem != null)
            {
                // 1. Lấy thông tin dòng vừa được double-click và ép kiểu về WarningWaitModel
                var monDaXong = (WarningWaitModelDTO)lstKitchenWarning.SelectedItem;

                // 2. Xóa món này khỏi danh sách dữ liệu gốc
                _kitchenWarnings.Remove(monDaXong);

                // 3. Cập nhật (Refresh) lại ListBox để dòng chữ biến mất khỏi màn hình
                lstKitchenWarning.DataSource = null;
                lstKitchenWarning.DataSource = _kitchenWarnings;
                lstKitchenWarning.DisplayMember = "DisplayText";
            }
        }
    }
}