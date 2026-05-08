using BUS;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace GUI
{
    public partial class ucStockControl_Warehouse : UserControl
    {
        public ucStockControl_Warehouse()
        {
            InitializeComponent();
            this.Load += async (s, e) => await LoadDataAsync();
        }

        private async System.Threading.Tasks.Task LoadDataAsync()
        {
            try
            {
                var ingredients = await IngredientBUS.GetAll();

                DataTable dt = new();
                dt.Columns.Add("Mã NL");
                dt.Columns.Add("Tên nguyên liệu");
                dt.Columns.Add("Đơn vị");
                dt.Columns.Add("Tồn kho", typeof(decimal));
                dt.Columns.Add("Tối thiểu", typeof(decimal));
                dt.Columns.Add("Trạng thái");

                int lowStockCount = 0;
                foreach (var item in ingredients)
                {
                    string status = item.TonKho < item.TonKhoToiThieu ? "Sắp hết" : "Đủ hàng";
                    if (status == "Sắp hết") lowStockCount++;
                    dt.Rows.Add(item.Id, item.TenNguyenLieu, item.DonVi,
                        (decimal)item.TonKho, (decimal)item.TonKhoToiThieu, status);
                }

                dgvStock.DataSource = dt;
                dgvStock.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvStock.RowHeadersVisible = false;

                foreach (DataGridViewRow row in dgvStock.Rows)
                {
                    string status = row.Cells["Trạng thái"].Value?.ToString() ?? "";
                    if (status == "Sắp hết")
                        row.DefaultCellStyle.ForeColor = Color.IndianRed;
                }

                lblTotalItems.Text = ingredients.Count.ToString();
                lblLowStock.Text = lowStockCount.ToString();
                lblLastUpdate.Text = DateTime.Now.ToString("dd/MM/yyyy");
                lblEstCups.Text = "--";
            }
            catch (Exception ex)
            {
                MsgBox.Show(MsgBox.OwnerWindow(this), $"Lỗi tải dữ liệu kho: {ex.Message}", "Lỗi", MsgBox.MessageBoxType.Error);
            }
        }

        private void btnNewImport_Click(object sender, EventArgs e)
        {
            using AddInventoryImport frm = new();
            if (frm.ShowDialog(MsgBox.OwnerWindow(this)) == DialogResult.OK)
                _ = LoadDataAsync();
        }

        private void btnAttachPhoto_Click(object sender, EventArgs e)
        {
            using OpenFileDialog ofd = new();
            ofd.Filter = "Image files|*.jpg;*.jpeg;*.png;*.bmp";
            ofd.Title = "Chọn ảnh đính kèm";
            if (ofd.ShowDialog(MsgBox.OwnerWindow(this)) == DialogResult.OK)
            {
                MsgBox.Show(MsgBox.OwnerWindow(this), $"Đã đính kèm ảnh: {System.IO.Path.GetFileName(ofd.FileName)}", "Thành công", MsgBox.MessageBoxType.Success);
            }
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            string report =
                "BÁO CÁO KHO HÀNG\n" +
                $"Ngày: {DateTime.Now:dd/MM/yyyy}\n" +
                "──────────────────\n" +
                $"• Tổng mặt hàng: {lblTotalItems.Text}\n" +
                $"• Sắp hết: {lblLowStock.Text}\n" +
                "──────────────────\n" +
                "Gửi báo cáo cho quản lý qua Chat?";

            var result = MsgBox.Show(MsgBox.OwnerWindow(this), report, "Báo cáo kho", MsgBox.MessageBoxType.Warning);
            if (result == DialogResult.Yes)
            {
                MsgBox.Show(
                    MsgBox.OwnerWindow(this),
                    "Đã gửi báo cáo kho cho quản lý!\nQuản lý sẽ duyệt qua Chat nội bộ.",
                    "Thành công", MsgBox.MessageBoxType.Success);
            }
        }
    }
}
