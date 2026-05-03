using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace GUI
{
    public partial class ucRecipe_Barista : UserControl
    {
        public ucRecipe_Barista()
        {
            InitializeComponent();
            this.Load += (s, e) => LoadMockData();
            btnReport.Click += (s, e) =>
            {
                string currentRecipe = lblRecipeName.Text;
                string report =
                    $"BÁO CÁO CÔNG THỨC\n" +
                    $"Thời gian: {DateTime.Now:HH:mm dd/MM/yyyy}\n" +
                    $"──────────────────\n" +
                    $"• Tổng công thức: {lstRecipes.Items.Count}\n" +
                    $"• Đang xem: {currentRecipe}\n" +
                    $"──────────────────\n" +
                    $"Gửi báo cáo cho quản lý?";

                if (MessageBox.Show(report, "Báo cáo công thức", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    MsgBox.Show("Đã gửi báo cáo cho quản lý!", "Thành công", MsgBox.MessageBoxType.Success);
            };
        }

        private void LoadMockData()
        {
            lstRecipes.Items.AddRange(new object[]
            {
                "Cà phê sữa đá",
                "Americano",
                "Cappuccino",
                "Latte",
                "Mocha",
                "Espresso",
                "Trà đào cam sả",
                "Trà sữa trân châu",
                "Sinh tố bơ",
                "Matcha Latte"
            });

            if (lstRecipes.Items.Count > 0)
                lstRecipes.SelectedIndex = 0;
        }

        private void lstRecipes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstRecipes.SelectedIndex < 0) return;
            string recipe = lstRecipes.SelectedItem?.ToString() ?? "";

            lblRecipeName.Text = recipe;

            switch (recipe)
            {
                case "Cà phê sữa đá":
                    lblCategory.Text = "Cà phê";
                    LoadIngredients(new[] {
                        new object[] { "Cà phê phin", "25ml", "Chính" },
                        new object[] { "Sữa đặc", "20ml", "Phụ" },
                        new object[] { "Đá viên", "200g", "Phụ" }
                    });
                    txtSteps.Text = "1. Pha cà phê phin với 25ml cà phê\r\n2. Cho 20ml sữa đặc vào ly\r\n3. Thêm đá viên\r\n4. Rót cà phê vào, khuấy đều";
                    break;
                case "Cappuccino":
                    lblCategory.Text = "Cà phê";
                    LoadIngredients(new[] {
                        new object[] { "Espresso", "30ml", "Chính" },
                        new object[] { "Sữa tươi", "150ml", "Chính" },
                        new object[] { "Bột cacao", "2g", "Trang trí" }
                    });
                    txtSteps.Text = "1. Chiết xuất 30ml espresso\r\n2. Đánh bọt sữa tươi (60-65°C)\r\n3. Rót espresso vào ly\r\n4. Đổ sữa bọt lên trên\r\n5. Rắc bột cacao trang trí";
                    break;
                case "Trà đào cam sả":
                    lblCategory.Text = "Trà";
                    LoadIngredients(new[] {
                        new object[] { "Trà đào", "200ml", "Chính" },
                        new object[] { "Nước cam", "50ml", "Chính" },
                        new object[] { "Sả", "2 cây", "Phụ" },
                        new object[] { "Đào ngâm", "3 miếng", "Topping" },
                        new object[] { "Đá viên", "200g", "Phụ" }
                    });
                    txtSteps.Text = "1. Pha trà đào 200ml\r\n2. Vắt 50ml nước cam\r\n3. Đập dập 2 cây sả\r\n4. Trộn trà + cam + sả\r\n5. Thêm đá và đào ngâm";
                    break;
                default:
                    lblCategory.Text = "Cà phê";
                    LoadIngredients(new[] {
                        new object[] { "Espresso", "30ml", "Chính" },
                        new object[] { "Sữa tươi", "100ml", "Phụ" }
                    });
                    txtSteps.Text = "1. Chiết xuất espresso\r\n2. Thêm nguyên liệu phụ\r\n3. Khuấy đều và phục vụ";
                    break;
            }
        }

        private void LoadIngredients(object[][] data)
        {
            DataTable dt = new();
            dt.Columns.Add("Nguyên liệu");
            dt.Columns.Add("Định lượng");
            dt.Columns.Add("Loại");

            foreach (var row in data)
                dt.Rows.Add(row);

            dgvIngredients.DataSource = dt;
            dgvIngredients.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvIngredients.RowHeadersVisible = false;
        }
    }
}
