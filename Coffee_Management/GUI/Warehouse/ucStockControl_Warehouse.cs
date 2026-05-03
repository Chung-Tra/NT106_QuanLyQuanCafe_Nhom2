using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace GUI
{
    public partial class ucStockControl_Warehouse : UserControl
    {
        // Công thức: mỗi ly cần bao nhiêu đơn vị NL (đơn vị gốc)
        // Key = Mã NL, Value = (tên đồ uống chính, lượng NL / ly)
        private static readonly Dictionary<string, (string DrinkName, decimal PerCup, string Unit)> RecipePerCup = new()
        {
            ["NL001"] = ("Cà phê đen",     0.015m, "kg"),    // 15g / ly
            ["NL002"] = ("Latte",           0.15m,  "lít"),   // 150ml / ly
            ["NL003"] = ("Bạc xỉu",        0.03m,  "lon"),   // 30ml ≈ 0.03 lon
            ["NL004"] = ("Đồ uống ngọt",   0.02m,  "kg"),    // 20g / ly
            ["NL005"] = ("Cacao nóng",      0.025m, "kg"),    // 25g / ly
            ["NL006"] = ("Trà đào",         0.5m,   "gói"),   // 0.5 gói / ly
            ["NL007"] = ("Trà sả",          0.2m,   "bó"),    // 0.2 bó / ly
            ["NL008"] = ("Trà đào topping", 0.1m,   "hộp"),   // 0.1 hộp / ly
            ["NL009"] = ("Trà sữa TC",      0.03m,  "kg"),    // 30g / ly
            ["NL010"] = ("Vanilla Latte",   0.05m,  "chai"),  // 0.05 chai / ly
            ["NL011"] = ("Đồ uống đá",     0.1m,   "bao"),   // 0.1 bao / ly
            ["NL012"] = ("Sinh tố bơ",      0.1m,   "kg"),    // 100g / ly
        };

        public ucStockControl_Warehouse()
        {
            InitializeComponent();
            this.Load += (s, e) => LoadMockData();
        }

        private void LoadMockData()
        {
            DataTable dt = new();
            dt.Columns.Add("Mã NL");
            dt.Columns.Add("Tên nguyên liệu");
            dt.Columns.Add("Đơn vị");
            dt.Columns.Add("Tồn kho", typeof(decimal));
            dt.Columns.Add("Tối thiểu", typeof(decimal));
            dt.Columns.Add("Ly dự kiến", typeof(int));
            dt.Columns.Add("Đồ uống", typeof(string));
            dt.Columns.Add("Trạng thái");
            dt.Columns.Add("Cập nhật");

            AddStockRow(dt, "NL001", "Cà phê hạt Arabica", "kg",  25.5m, 10m, "02/05/2026");
            AddStockRow(dt, "NL002", "Sữa tươi",           "lít", 8m,    15m, "02/05/2026");
            AddStockRow(dt, "NL003", "Sữa đặc",            "lon", 45m,   20m, "01/05/2026");
            AddStockRow(dt, "NL004", "Đường",               "kg",  18m,   10m, "01/05/2026");
            AddStockRow(dt, "NL005", "Bột cacao",           "kg",  2.5m,  5m,  "02/05/2026");
            AddStockRow(dt, "NL006", "Trà đào",             "gói", 30m,   10m, "30/04/2026");
            AddStockRow(dt, "NL007", "Sả tươi",             "bó",  3m,    5m,  "02/05/2026");
            AddStockRow(dt, "NL008", "Đào ngâm",            "hộp", 12m,   5m,  "30/04/2026");
            AddStockRow(dt, "NL009", "Trân châu",           "kg",  1.2m,  3m,  "02/05/2026");
            AddStockRow(dt, "NL010", "Syrup vanilla",       "chai", 8m,   3m,  "01/05/2026");
            AddStockRow(dt, "NL011", "Đá viên",             "bao", 4m,    10m, "02/05/2026");
            AddStockRow(dt, "NL012", "Bơ",                  "kg",  6m,    3m,  "01/05/2026");

            dgvStock.DataSource = dt;
            dgvStock.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvStock.RowHeadersVisible = false;

            dgvStock.Columns["Mã NL"].FillWeight = 7;
            dgvStock.Columns["Tên nguyên liệu"].FillWeight = 18;
            dgvStock.Columns["Đơn vị"].FillWeight = 6;
            dgvStock.Columns["Tồn kho"].FillWeight = 9;
            dgvStock.Columns["Tối thiểu"].FillWeight = 9;
            dgvStock.Columns["Ly dự kiến"].FillWeight = 10;
            dgvStock.Columns["Đồ uống"].FillWeight = 14;
            dgvStock.Columns["Trạng thái"].FillWeight = 10;
            dgvStock.Columns["Cập nhật"].FillWeight = 10;

            dgvStock.Columns["Tồn kho"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvStock.Columns["Tối thiểu"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvStock.Columns["Ly dự kiến"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Color rows
            int lowStockCount = 0;
            int totalCups = 0;
            foreach (DataGridViewRow row in dgvStock.Rows)
            {
                string status = row.Cells["Trạng thái"].Value?.ToString() ?? "";
                int cups = row.Cells["Ly dự kiến"].Value is int c ? c : 0;
                totalCups += cups;

                if (status == "Sắp hết")
                {
                    row.DefaultCellStyle.ForeColor = Color.IndianRed;
                    lowStockCount++;
                }

                // Highlight cups column
                if (cups < 50)
                    row.Cells["Ly dự kiến"].Style.ForeColor = Color.IndianRed;
                else if (cups < 150)
                    row.Cells["Ly dự kiến"].Style.ForeColor = Color.Orange;
                else
                    row.Cells["Ly dự kiến"].Style.ForeColor = Color.MediumSeaGreen;
            }

            lblTotalItems.Text = dt.Rows.Count.ToString();
            lblLowStock.Text = lowStockCount.ToString();
            lblLastUpdate.Text = DateTime.Now.ToString("dd/MM/yyyy");
            lblEstCups.Text = $"~{totalCups} ly";
        }

        private void AddStockRow(DataTable dt, string id, string name, string unit,
            decimal stock, decimal minQty, string updateDate)
        {
            string status = stock < minQty ? "Sắp hết" : "Đủ hàng";
            int cups = 0;
            string drink = "--";

            if (RecipePerCup.TryGetValue(id, out var recipe) && recipe.PerCup > 0)
            {
                cups = (int)Math.Floor(stock / recipe.PerCup);
                drink = recipe.DrinkName;
            }

            dt.Rows.Add(id, name, unit, stock, minQty, cups, drink, status, updateDate);
        }

        private void btnNewImport_Click(object sender, EventArgs e)
        {
            StockTransaction frm = new(StockTransaction.TransactionType.Import);
            if (frm.ShowDialog() == DialogResult.OK)
                LoadMockData();
        }

        private void btnNewExport_Click(object sender, EventArgs e)
        {
            StockTransaction frm = new(StockTransaction.TransactionType.Export);
            if (frm.ShowDialog() == DialogResult.OK)
                LoadMockData();
        }

        private void btnNewWaste_Click(object sender, EventArgs e)
        {
            StockTransaction frm = new(StockTransaction.TransactionType.Waste);
            if (frm.ShowDialog() == DialogResult.OK)
                LoadMockData();
        }

        private void btnAttachPhoto_Click(object sender, EventArgs e)
        {
            using OpenFileDialog ofd = new();
            ofd.Filter = "Image files|*.jpg;*.jpeg;*.png;*.bmp";
            ofd.Title = "Chọn ảnh đính kèm";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                MsgBox.Show($"Đã đính kèm ảnh: {System.IO.Path.GetFileName(ofd.FileName)}", "Thành công", MsgBox.MessageBoxType.Success);
            }
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            string report =
                $"BÁO CÁO KHO HÀNG\n" +
                $"Ngày: {DateTime.Now:dd/MM/yyyy}\n" +
                $"──────────────────\n" +
                $"• Tổng mặt hàng: {lblTotalItems.Text}\n" +
                $"• Sắp hết: {lblLowStock.Text}\n" +
                $"• Ly dự kiến: {lblEstCups.Text}\n" +
                $"──────────────────\n" +
                $"Gửi báo cáo cho quản lý qua Chat?";

            var result = MessageBox.Show(report, "Báo cáo kho",
                MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (result == DialogResult.Yes)
            {
                MsgBox.Show(
                    "Đã gửi báo cáo kho cho quản lý!\nQuản lý sẽ duyệt qua Chat nội bộ.",
                    "Thành công", MsgBox.MessageBoxType.Success);
            }
        }
    }
}
