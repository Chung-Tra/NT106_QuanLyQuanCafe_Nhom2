using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace GUI
{
    partial class ucRecipe_Barista
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        private void InitializeComponent()
        {
            pnlLeft = new Guna2Panel();
            lblRecipeListTitle = new Label();
            btnReport = new Guna2Button();
            txtSearchRecipe = new Guna2TextBox();
            lstRecipes = new ListBox();
            pnlRight = new Guna2Panel();
            lblRecipeName = new Label();
            lblCategory = new Label();
            pnlIngredients = new Guna2Panel();
            lblIngredientsTitle = new Label();
            dgvIngredients = new Guna2DataGridView();
            pnlSteps = new Guna2Panel();
            lblStepsTitle = new Label();
            txtSteps = new Guna2TextBox();
            pnlLeft.SuspendLayout();
            pnlRight.SuspendLayout();
            pnlIngredients.SuspendLayout();
            pnlSteps.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvIngredients).BeginInit();
            SuspendLayout();

            // ====== pnlLeft ======
            pnlLeft.BackColor = Color.FromArgb(31, 31, 34);
            pnlLeft.BorderRadius = 14;
            pnlLeft.Controls.Add(lblRecipeListTitle);
            pnlLeft.Controls.Add(btnReport);
            pnlLeft.Controls.Add(txtSearchRecipe);
            pnlLeft.Controls.Add(lstRecipes);
            pnlLeft.Location = new Point(20, 15);
            pnlLeft.Size = new Size(250, 500);

            lblRecipeListTitle.AutoSize = true;
            lblRecipeListTitle.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblRecipeListTitle.ForeColor = Color.White;
            lblRecipeListTitle.Location = new Point(18, 14);
            lblRecipeListTitle.Text = "📖  Công thức";

            btnReport.BorderRadius = 8;
            btnReport.Cursor = Cursors.Hand;
            btnReport.FillColor = Color.FromArgb(70, 130, 180);
            btnReport.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            btnReport.ForeColor = Color.White;
            btnReport.HoverState.FillColor = Color.FromArgb(90, 150, 200);
            btnReport.Location = new Point(160, 12);
            btnReport.Size = new Size(75, 28);
            btnReport.Text = "📊 Báo cáo";

            txtSearchRecipe.BorderColor = Color.FromArgb(63, 63, 70);
            txtSearchRecipe.BorderRadius = 8;
            txtSearchRecipe.DefaultText = "";
            txtSearchRecipe.FillColor = Color.FromArgb(30, 30, 33);
            txtSearchRecipe.FocusedState.BorderColor = Color.FromArgb(31, 138, 154);
            txtSearchRecipe.Font = new Font("Segoe UI", 9.5F);
            txtSearchRecipe.ForeColor = Color.White;
            txtSearchRecipe.HoverState.BorderColor = Color.FromArgb(120, 120, 130);
            txtSearchRecipe.IconLeft = null;
            txtSearchRecipe.Location = new Point(18, 50);
            txtSearchRecipe.PlaceholderForeColor = Color.FromArgb(110, 110, 120);
            txtSearchRecipe.PlaceholderText = "🔍  Tìm công thức...";
            txtSearchRecipe.Size = new Size(214, 32);

            lstRecipes.BackColor = Color.FromArgb(24, 24, 27);
            lstRecipes.BorderStyle = BorderStyle.None;
            lstRecipes.Font = new Font("Segoe UI", 10F);
            lstRecipes.ForeColor = Color.White;
            lstRecipes.ItemHeight = 22;
            lstRecipes.Location = new Point(18, 92);
            lstRecipes.Size = new Size(214, 396);
            lstRecipes.SelectedIndexChanged += lstRecipes_SelectedIndexChanged;

            // ====== pnlRight ======
            pnlRight.BackColor = Color.FromArgb(31, 31, 34);
            pnlRight.BorderRadius = 14;
            pnlRight.Controls.Add(lblRecipeName);
            pnlRight.Controls.Add(lblCategory);
            pnlRight.Controls.Add(pnlIngredients);
            pnlRight.Controls.Add(pnlSteps);
            pnlRight.Location = new Point(280, 15);
            pnlRight.Size = new Size(504, 500);

            lblRecipeName.AutoSize = true;
            lblRecipeName.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblRecipeName.ForeColor = Color.White;
            lblRecipeName.Location = new Point(18, 14);
            lblRecipeName.Text = "Chọn công thức";

            lblCategory.AutoSize = true;
            lblCategory.Font = new Font("Segoe UI", 9.5F);
            lblCategory.ForeColor = Color.FromArgb(160, 160, 166);
            lblCategory.Location = new Point(18, 46);
            lblCategory.Text = "Loại: ---";

            // -- pnlIngredients --
            pnlIngredients.BackColor = Color.FromArgb(24, 24, 27);
            pnlIngredients.BorderRadius = 10;
            pnlIngredients.Controls.Add(lblIngredientsTitle);
            pnlIngredients.Controls.Add(dgvIngredients);
            pnlIngredients.Location = new Point(18, 75);
            pnlIngredients.Size = new Size(470, 195);

            lblIngredientsTitle.AutoSize = true;
            lblIngredientsTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblIngredientsTitle.ForeColor = Color.FromArgb(245, 158, 11);
            lblIngredientsTitle.Location = new Point(12, 8);
            lblIngredientsTitle.Text = "🧂  Nguyên liệu";

            dgvIngredients.BackgroundColor = Color.FromArgb(24, 24, 27);
            dgvIngredients.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(31, 31, 34);
            dgvIngredients.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(160, 160, 166);
            dgvIngredients.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dgvIngredients.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(31, 31, 34);
            dgvIngredients.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.FromArgb(160, 160, 166);
            dgvIngredients.DefaultCellStyle.BackColor = Color.FromArgb(24, 24, 27);
            dgvIngredients.DefaultCellStyle.ForeColor = Color.FromArgb(220, 220, 225);
            dgvIngredients.DefaultCellStyle.SelectionBackColor = Color.FromArgb(31, 138, 154);
            dgvIngredients.DefaultCellStyle.SelectionForeColor = Color.FromArgb(240, 240, 245);
            dgvIngredients.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(24, 24, 27);
            dgvIngredients.AlternatingRowsDefaultCellStyle.ForeColor = Color.FromArgb(220, 220, 225);
            dgvIngredients.GridColor = Color.FromArgb(45, 45, 48);
            ConfigureGrid(dgvIngredients);
            dgvIngredients.Location = new Point(12, 36);
            dgvIngredients.Size = new Size(446, 150);

            // -- pnlSteps --
            pnlSteps.BackColor = Color.FromArgb(24, 24, 27);
            pnlSteps.BorderRadius = 10;
            pnlSteps.Controls.Add(lblStepsTitle);
            pnlSteps.Controls.Add(txtSteps);
            pnlSteps.Location = new Point(18, 282);
            pnlSteps.Size = new Size(470, 200);

            lblStepsTitle.AutoSize = true;
            lblStepsTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblStepsTitle.ForeColor = Color.FromArgb(245, 158, 11);
            lblStepsTitle.Location = new Point(12, 8);
            lblStepsTitle.Text = "📝  Cách làm";

            txtSteps.BorderColor = Color.FromArgb(63, 63, 70);
            txtSteps.BorderRadius = 8;
            txtSteps.DefaultText = "";
            txtSteps.FillColor = Color.FromArgb(30, 30, 33);
            txtSteps.FocusedState.BorderColor = Color.FromArgb(31, 138, 154);
            txtSteps.Font = new Font("Segoe UI", 10F);
            txtSteps.ForeColor = Color.White;
            txtSteps.HoverState.BorderColor = Color.FromArgb(120, 120, 130);
            txtSteps.Location = new Point(12, 36);
            txtSteps.Multiline = true;
            txtSteps.ReadOnly = true;
            txtSteps.ScrollBars = ScrollBars.None;
            txtSteps.Size = new Size(446, 152);

            // ====== ucRecipe_Barista ======
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(39, 39, 42);
            Controls.Add(pnlLeft);
            Controls.Add(pnlRight);
            Name = "ucRecipe_Barista";
            Size = new Size(804, 530);
            pnlLeft.ResumeLayout(false);
            pnlLeft.PerformLayout();
            pnlRight.ResumeLayout(false);
            pnlRight.PerformLayout();
            pnlIngredients.ResumeLayout(false);
            pnlIngredients.PerformLayout();
            pnlSteps.ResumeLayout(false);
            pnlSteps.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvIngredients).EndInit();
            ResumeLayout(false);
        }

        private static void ConfigureGrid(Guna2DataGridView dgv)
        {
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToResizeRows = false;
            dgv.BackgroundColor = Color.FromArgb(24, 24, 27);
            dgv.BorderStyle = BorderStyle.None;
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgv.ColumnHeadersHeight = 32;
            dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(31, 31, 34);
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(160, 160, 166);
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dgv.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(31, 31, 34);
            dgv.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.FromArgb(160, 160, 166);
            dgv.DefaultCellStyle.BackColor = Color.FromArgb(24, 24, 27);
            dgv.DefaultCellStyle.ForeColor = Color.FromArgb(220, 220, 225);
            dgv.DefaultCellStyle.Font = new Font("Segoe UI", 9F);
            dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(31, 138, 154);
            dgv.DefaultCellStyle.SelectionForeColor = Color.FromArgb(240, 240, 245);
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(24, 24, 27);
            dgv.AlternatingRowsDefaultCellStyle.ForeColor = Color.FromArgb(220, 220, 225);
            dgv.AlternatingRowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(31, 138, 154);
            dgv.AlternatingRowsDefaultCellStyle.SelectionForeColor = Color.FromArgb(240, 240, 245);
            dgv.EnableHeadersVisualStyles = false;
            dgv.GridColor = Color.FromArgb(45, 45, 48);
            dgv.MultiSelect = false;
            dgv.ReadOnly = true;
            dgv.RowHeadersVisible = false;
            dgv.RowTemplate.Height = 28;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DgvDarkScroll.Apply(dgv);
        }

        #endregion

        private Guna2Panel pnlLeft;
        private Label lblRecipeListTitle;
        private Guna2Button btnReport;
        private Guna2TextBox txtSearchRecipe;
        private ListBox lstRecipes;
        private Guna2Panel pnlRight;
        private Label lblRecipeName;
        private Label lblCategory;
        private Guna2Panel pnlIngredients;
        private Label lblIngredientsTitle;
        private Guna2DataGridView dgvIngredients;
        private Guna2Panel pnlSteps;
        private Label lblStepsTitle;
        private Guna2TextBox txtSteps;
    }
}
