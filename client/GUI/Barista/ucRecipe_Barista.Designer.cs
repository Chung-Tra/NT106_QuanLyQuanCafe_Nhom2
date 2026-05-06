using System.Drawing;
using System.Windows.Forms;

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
            pnlLeft = new Panel();
            lblRecipeListTitle = new Label();
            txtSearchRecipe = new TextBox();
            lstRecipes = new ListBox();
            pnlRight = new Panel();
            lblRecipeName = new Label();
            lblCategory = new Label();
            pnlIngredients = new Panel();
            lblIngredientsTitle = new Label();
            dgvIngredients = new DataGridView();
            pnlSteps = new Panel();
            lblStepsTitle = new Label();
            txtSteps = new TextBox();
            pnlLeft.SuspendLayout();
            pnlRight.SuspendLayout();
            pnlIngredients.SuspendLayout();
            pnlSteps.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvIngredients).BeginInit();
            SuspendLayout();
            //
            // pnlLeft
            //
            pnlLeft.BackColor = Color.FromArgb(30, 30, 30);
            btnReport = new Button();
            pnlLeft.Controls.Add(lblRecipeListTitle);
            pnlLeft.Controls.Add(btnReport);
            pnlLeft.Controls.Add(txtSearchRecipe);
            pnlLeft.Controls.Add(lstRecipes);
            pnlLeft.Location = new Point(20, 15);
            pnlLeft.Name = "pnlLeft";
            pnlLeft.Size = new Size(250, 500);
            pnlLeft.TabIndex = 0;
            //
            // lblRecipeListTitle
            //
            lblRecipeListTitle.AutoSize = true;
            lblRecipeListTitle.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblRecipeListTitle.ForeColor = Color.White;
            lblRecipeListTitle.Location = new Point(15, 12);
            lblRecipeListTitle.Name = "lblRecipeListTitle";
            lblRecipeListTitle.Size = new Size(130, 25);
            lblRecipeListTitle.TabIndex = 0;
            lblRecipeListTitle.Text = "Công thức";
            //
            // btnReport
            //
            btnReport.BackColor = Color.FromArgb(70, 130, 180);
            btnReport.Cursor = Cursors.Hand;
            btnReport.FlatAppearance.BorderSize = 0;
            btnReport.FlatStyle = FlatStyle.Flat;
            btnReport.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            btnReport.ForeColor = Color.White;
            btnReport.Location = new Point(155, 14);
            btnReport.Name = "btnReport";
            btnReport.Size = new Size(80, 25);
            btnReport.Text = "Báo cáo";
            //
            // txtSearchRecipe
            //
            txtSearchRecipe.BackColor = Color.FromArgb(45, 45, 48);
            txtSearchRecipe.BorderStyle = BorderStyle.FixedSingle;
            txtSearchRecipe.Font = new Font("Segoe UI", 10F);
            txtSearchRecipe.ForeColor = Color.White;
            txtSearchRecipe.Location = new Point(15, 45);
            txtSearchRecipe.Name = "txtSearchRecipe";
            txtSearchRecipe.PlaceholderText = "Tìm công thức...";
            txtSearchRecipe.Size = new Size(220, 25);
            txtSearchRecipe.TabIndex = 1;
            //
            // lstRecipes
            //
            lstRecipes.BackColor = Color.FromArgb(45, 45, 48);
            lstRecipes.BorderStyle = BorderStyle.None;
            lstRecipes.Font = new Font("Segoe UI", 10F);
            lstRecipes.ForeColor = Color.White;
            lstRecipes.ItemHeight = 17;
            lstRecipes.Location = new Point(15, 80);
            lstRecipes.Name = "lstRecipes";
            lstRecipes.Size = new Size(220, 408);
            lstRecipes.TabIndex = 2;
            lstRecipes.SelectedIndexChanged += lstRecipes_SelectedIndexChanged;
            //
            // pnlRight
            //
            pnlRight.BackColor = Color.FromArgb(30, 30, 30);
            pnlRight.Controls.Add(lblRecipeName);
            pnlRight.Controls.Add(lblCategory);
            pnlRight.Controls.Add(pnlIngredients);
            pnlRight.Controls.Add(pnlSteps);
            pnlRight.Location = new Point(280, 15);
            pnlRight.Name = "pnlRight";
            pnlRight.Size = new Size(504, 500);
            pnlRight.TabIndex = 1;
            //
            // lblRecipeName
            //
            lblRecipeName.AutoSize = true;
            lblRecipeName.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblRecipeName.ForeColor = Color.White;
            lblRecipeName.Location = new Point(15, 12);
            lblRecipeName.Name = "lblRecipeName";
            lblRecipeName.Size = new Size(200, 25);
            lblRecipeName.TabIndex = 0;
            lblRecipeName.Text = "Chọn công thức";
            //
            // lblCategory
            //
            lblCategory.AutoSize = true;
            lblCategory.Font = new Font("Segoe UI", 10F);
            lblCategory.ForeColor = Color.Gray;
            lblCategory.Location = new Point(15, 42);
            lblCategory.Name = "lblCategory";
            lblCategory.Size = new Size(100, 19);
            lblCategory.TabIndex = 1;
            lblCategory.Text = "Loại: ---";
            //
            // pnlIngredients
            //
            pnlIngredients.Controls.Add(lblIngredientsTitle);
            pnlIngredients.Controls.Add(dgvIngredients);
            pnlIngredients.Location = new Point(15, 70);
            pnlIngredients.Name = "pnlIngredients";
            pnlIngredients.Size = new Size(475, 200);
            pnlIngredients.TabIndex = 2;
            //
            // lblIngredientsTitle
            //
            lblIngredientsTitle.AutoSize = true;
            lblIngredientsTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblIngredientsTitle.ForeColor = Color.Orange;
            lblIngredientsTitle.Location = new Point(0, 5);
            lblIngredientsTitle.Name = "lblIngredientsTitle";
            lblIngredientsTitle.Size = new Size(120, 20);
            lblIngredientsTitle.TabIndex = 0;
            lblIngredientsTitle.Text = "Nguyên liệu";
            //
            // dgvIngredients
            //
            dgvIngredients.AllowUserToAddRows = false;
            dgvIngredients.BackgroundColor = Color.FromArgb(45, 45, 48);
            dgvIngredients.BorderStyle = BorderStyle.None;
            dgvIngredients.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvIngredients.Location = new Point(0, 30);
            dgvIngredients.Name = "dgvIngredients";
            dgvIngredients.ReadOnly = true;
            dgvIngredients.RowHeadersVisible = false;
            dgvIngredients.Size = new Size(475, 165);
            dgvIngredients.TabIndex = 1;
            //
            // pnlSteps
            //
            pnlSteps.Controls.Add(lblStepsTitle);
            pnlSteps.Controls.Add(txtSteps);
            pnlSteps.Location = new Point(15, 280);
            pnlSteps.Name = "pnlSteps";
            pnlSteps.Size = new Size(475, 210);
            pnlSteps.TabIndex = 3;
            //
            // lblStepsTitle
            //
            lblStepsTitle.AutoSize = true;
            lblStepsTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblStepsTitle.ForeColor = Color.Orange;
            lblStepsTitle.Location = new Point(0, 5);
            lblStepsTitle.Name = "lblStepsTitle";
            lblStepsTitle.Size = new Size(120, 20);
            lblStepsTitle.TabIndex = 0;
            lblStepsTitle.Text = "Cách làm";
            //
            // txtSteps
            //
            txtSteps.BackColor = Color.FromArgb(45, 45, 48);
            txtSteps.BorderStyle = BorderStyle.None;
            txtSteps.Font = new Font("Segoe UI", 10F);
            txtSteps.ForeColor = Color.White;
            txtSteps.Location = new Point(0, 30);
            txtSteps.Multiline = true;
            txtSteps.Name = "txtSteps";
            txtSteps.ReadOnly = true;
            txtSteps.ScrollBars = ScrollBars.Vertical;
            txtSteps.Size = new Size(475, 175);
            txtSteps.TabIndex = 1;
            //
            // ucRecipe_Barista
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(45, 45, 48);
            Controls.Add(pnlRight);
            Controls.Add(pnlLeft);
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

        #endregion

        private Panel pnlLeft;
        private Label lblRecipeListTitle;
        private TextBox txtSearchRecipe;
        private ListBox lstRecipes;
        private Panel pnlRight;
        private Label lblRecipeName;
        private Label lblCategory;
        private Panel pnlIngredients;
        private Label lblIngredientsTitle;
        private DataGridView dgvIngredients;
        private Panel pnlSteps;
        private Label lblStepsTitle;
        private TextBox txtSteps;
        private Button btnReport;
    }
}
