using BUS;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class ucRecipe_Barista : UserControl
    {
        private List<RecipeDTO> _recipes = new();

        public ucRecipe_Barista()
        {
            InitializeComponent();
            this.Load += (s, e) => _ = LoadRealData();
            txtSearchRecipe.TextChanged += (s, e) => FilterRecipes();

            DgvRefresh.Attach(dgvIngredients, () => lstRecipes_SelectedIndexChanged(lstRecipes, EventArgs.Empty));

            dgvIngredients.CellDoubleClick += (s, e) =>
            {
                if (e.RowIndex < 0) return;
                RecordDetail.FromRow(dgvIngredients.Rows[e.RowIndex], "Chi tiết nguyên liệu")
                            .ShowDialog(MsgBox.OwnerWindow(this));
            };
            btnReport.Click += (s, e) =>
            {
                string currentRecipe = lblRecipeName.Text;
                string report =
                    "BÁO CÁO CÔNG THỨC\n" +
                    $"Thời gian: {DateTime.Now:HH:mm dd/MM/yyyy}\n" +
                    "──────────────────\n" +
                    $"• Tổng công thức: {lstRecipes.Items.Count}\n" +
                    $"• Đang xem: {currentRecipe}\n" +
                    "──────────────────\n" +
                    "Gửi báo cáo cho quản lý?";

                if (MsgBox.Show(MsgBox.OwnerWindow(this), report, "Báo cáo công thức", MsgBox.MessageBoxType.Warning) == DialogResult.Yes)
                    MsgBox.Show(MsgBox.OwnerWindow(this), "Đã gửi báo cáo cho quản lý!", "Thành công", MsgBox.MessageBoxType.Success);
            };
        }

        private static string CategoryVi(string? c) => c switch
        {
            "ca_phe" => "Cà phê",
            "tra" => "Trà",
            "sinh_to" => "Sinh tố",
            _ => "Khác"
        };
        private static string IngTypeVi(string? t) => t switch
        {
            "chinh" => "Chính",
            "phu" => "Phụ",
            "topping" => "Topping",
            "trang_tri" => "Trang trí",
            _ => t ?? ""
        };

        private async Task LoadRealData()
        {
            try
            {
                _recipes = (await RecipeBUS.GetAll()).Values
                    .OrderBy(r => r.Name).ToList();
            }
            catch { _recipes = new(); }

            FilterRecipes();
        }

        private void FilterRecipes()
        {
            string kw = txtSearchRecipe.Text.Trim();
            lstRecipes.BeginUpdate();
            lstRecipes.Items.Clear();
            foreach (var r in _recipes)
                if (kw.Length == 0 || (r.Name ?? "").Contains(kw, StringComparison.CurrentCultureIgnoreCase))
                    lstRecipes.Items.Add(r.Name ?? "");
            lstRecipes.EndUpdate();

            if (lstRecipes.Items.Count > 0)
                lstRecipes.SelectedIndex = 0;
            else
            {
                lblRecipeName.Text = "(Không có công thức)";
                lblCategory.Text = "";
                txtSteps.Text = "";
                dgvIngredients.DataSource = null;
            }
        }

        private void lstRecipes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstRecipes.SelectedIndex < 0) return;
            string name = lstRecipes.SelectedItem?.ToString() ?? "";
            var recipe = _recipes.FirstOrDefault(r => r.Name == name);
            if (recipe == null) return;

            lblRecipeName.Text = recipe.Name ?? "";
            lblCategory.Text = CategoryVi(recipe.Category);
            txtSteps.Text = (recipe.Steps ?? "").Replace("\n", "\r\n");

            var dt = new DataTable();
            dt.Columns.Add("Nguyên liệu");
            dt.Columns.Add("Định lượng");
            dt.Columns.Add("Loại");
            if (recipe.Ingredients != null)
                foreach (var ing in recipe.Ingredients.Values)
                    dt.Rows.Add(ing.Name, ing.Quantity, IngTypeVi(ing.Type));

            dgvIngredients.DataSource = dt;
            dgvIngredients.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvIngredients.RowHeadersVisible = false;
        }
    }
}
