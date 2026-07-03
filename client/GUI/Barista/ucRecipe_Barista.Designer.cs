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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges11 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges12 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            pnlLeft = new Guna2Panel();
            lblRecipeListTitle = new Label();
            txtSearchRecipe = new Guna2TextBox();
            lstRecipes = new ListBox();
            pnlRight = new Guna2Panel();
            lblRecipeName = new Label();
            lblCategory = new Label();
            btnReport = new Guna2Button();
            pnlIngredients = new Guna2Panel();
            lblIngredientsTitle = new Label();
            dgvIngredients = new Guna2DataGridView();
            colIngredient = new DataGridViewTextBoxColumn();
            colAmount = new DataGridViewTextBoxColumn();
            colType = new DataGridViewTextBoxColumn();
            pnlSteps = new Guna2Panel();
            lblStepsTitle = new Label();
            txtSteps = new Guna2TextBox();
            pnlLeft.SuspendLayout();
            pnlRight.SuspendLayout();
            pnlIngredients.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvIngredients).BeginInit();
            pnlSteps.SuspendLayout();
            SuspendLayout();
            // 
            // pnlLeft
            // 
            pnlLeft.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            pnlLeft.BackColor = Color.FromArgb(31, 31, 34);
            pnlLeft.BorderRadius = 14;
            pnlLeft.Controls.Add(lblRecipeListTitle);
            pnlLeft.Controls.Add(txtSearchRecipe);
            pnlLeft.Controls.Add(lstRecipes);
            pnlLeft.CustomizableEdges = customizableEdges3;
            pnlLeft.Location = new Point(20, 15);
            pnlLeft.Name = "pnlLeft";
            pnlLeft.ShadowDecoration.CustomizableEdges = customizableEdges4;
            pnlLeft.Size = new Size(250, 635);
            pnlLeft.TabIndex = 0;
            // 
            // lblRecipeListTitle
            // 
            lblRecipeListTitle.AutoSize = true;
            lblRecipeListTitle.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblRecipeListTitle.ForeColor = Color.White;
            lblRecipeListTitle.Location = new Point(18, 14);
            lblRecipeListTitle.Name = "lblRecipeListTitle";
            lblRecipeListTitle.Size = new Size(136, 25);
            lblRecipeListTitle.TabIndex = 0;
            lblRecipeListTitle.Text = "Công thức";
            // 
            // txtSearchRecipe
            // 
            txtSearchRecipe.BorderColor = Color.FromArgb(63, 63, 70);
            txtSearchRecipe.BorderRadius = 8;
            txtSearchRecipe.CustomizableEdges = customizableEdges1;
            txtSearchRecipe.DefaultText = "";
            txtSearchRecipe.FillColor = Color.FromArgb(30, 30, 33);
            txtSearchRecipe.FocusedState.BorderColor = Color.FromArgb(31, 138, 154);
            txtSearchRecipe.Font = new Font("Segoe UI", 9.5F);
            txtSearchRecipe.ForeColor = Color.White;
            txtSearchRecipe.HoverState.BorderColor = Color.FromArgb(120, 120, 130);
            txtSearchRecipe.Location = new Point(18, 50);
            txtSearchRecipe.Name = "txtSearchRecipe";
            txtSearchRecipe.PasswordChar = '\0';
            txtSearchRecipe.PlaceholderForeColor = Color.FromArgb(110, 110, 120);
            txtSearchRecipe.PlaceholderText = "Tìm công thức...";
            txtSearchRecipe.SelectedText = "";
            txtSearchRecipe.ShadowDecoration.CustomizableEdges = customizableEdges2;
            txtSearchRecipe.Size = new Size(214, 32);
            txtSearchRecipe.TabIndex = 2;
            // 
            // lstRecipes
            // 
            lstRecipes.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lstRecipes.BackColor = Color.FromArgb(24, 24, 27);
            lstRecipes.BorderStyle = BorderStyle.None;
            lstRecipes.Font = new Font("Segoe UI", 10F);
            lstRecipes.ForeColor = Color.White;
            lstRecipes.ItemHeight = 17;
            lstRecipes.Location = new Point(18, 92);
            lstRecipes.Name = "lstRecipes";
            lstRecipes.Size = new Size(214, 527);
            lstRecipes.TabIndex = 3;
            lstRecipes.SelectedIndexChanged += lstRecipes_SelectedIndexChanged;
            // 
            // pnlRight
            // 
            pnlRight.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnlRight.BackColor = Color.FromArgb(31, 31, 34);
            pnlRight.BorderRadius = 14;
            pnlRight.Controls.Add(lblRecipeName);
            pnlRight.Controls.Add(lblCategory);
            pnlRight.Controls.Add(btnReport);
            pnlRight.Controls.Add(pnlIngredients);
            pnlRight.Controls.Add(pnlSteps);
            pnlRight.CustomizableEdges = customizableEdges11;
            pnlRight.Location = new Point(280, 15);
            pnlRight.Name = "pnlRight";
            pnlRight.ShadowDecoration.CustomizableEdges = customizableEdges12;
            pnlRight.Size = new Size(700, 635);
            pnlRight.TabIndex = 1;
            // 
            // lblRecipeName
            // 
            lblRecipeName.AutoSize = true;
            lblRecipeName.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblRecipeName.ForeColor = Color.White;
            lblRecipeName.Location = new Point(18, 14);
            lblRecipeName.Name = "lblRecipeName";
            lblRecipeName.Size = new Size(154, 25);
            lblRecipeName.TabIndex = 0;
            lblRecipeName.Text = "Chọn công thức";
            // 
            // lblCategory
            // 
            lblCategory.AutoSize = true;
            lblCategory.Font = new Font("Segoe UI", 9.5F);
            lblCategory.ForeColor = Color.FromArgb(160, 160, 166);
            lblCategory.Location = new Point(18, 46);
            lblCategory.Name = "lblCategory";
            lblCategory.Size = new Size(54, 17);
            lblCategory.TabIndex = 1;
            lblCategory.Text = "Loại: ---";
            //
            // btnReport
            //
            btnReport.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnReport.BorderRadius = 8;
            btnReport.Cursor = Cursors.Hand;
            btnReport.FillColor = Color.FromArgb(70, 130, 180);
            btnReport.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnReport.ForeColor = Color.White;
            btnReport.HoverState.FillColor = Color.FromArgb(90, 150, 200);
            btnReport.Location = new Point(587, 14);
            btnReport.Name = "btnReport";
            btnReport.Size = new Size(95, 32);
            btnReport.TabIndex = 4;
            btnReport.Text = "Báo cáo";
            //
            // pnlIngredients
            // 
            pnlIngredients.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlIngredients.BackColor = Color.FromArgb(24, 24, 27);
            pnlIngredients.BorderRadius = 10;
            pnlIngredients.Controls.Add(lblIngredientsTitle);
            pnlIngredients.Controls.Add(dgvIngredients);
            pnlIngredients.CustomizableEdges = customizableEdges5;
            pnlIngredients.Location = new Point(18, 75);
            pnlIngredients.Name = "pnlIngredients";
            pnlIngredients.ShadowDecoration.CustomizableEdges = customizableEdges6;
            pnlIngredients.Size = new Size(664, 260);
            pnlIngredients.TabIndex = 2;
            // 
            // lblIngredientsTitle
            // 
            lblIngredientsTitle.AutoSize = true;
            lblIngredientsTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblIngredientsTitle.ForeColor = Color.FromArgb(245, 158, 11);
            lblIngredientsTitle.Location = new Point(12, 8);
            lblIngredientsTitle.Name = "lblIngredientsTitle";
            lblIngredientsTitle.Size = new Size(123, 20);
            lblIngredientsTitle.TabIndex = 0;
            lblIngredientsTitle.Text = "Nguyên liệu";
            // 
            // dgvIngredients
            // 
            dataGridViewCellStyle1.BackColor = Color.FromArgb(24, 24, 27);
            dataGridViewCellStyle1.ForeColor = Color.FromArgb(220, 220, 225);
            dgvIngredients.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvIngredients.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvIngredients.BackgroundColor = Color.FromArgb(24, 24, 27);
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(31, 31, 34);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(160, 160, 166);
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(31, 31, 34);
            dataGridViewCellStyle2.SelectionForeColor = Color.FromArgb(160, 160, 166);
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvIngredients.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvIngredients.Columns.AddRange(new DataGridViewColumn[] { colIngredient, colAmount, colType });
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.FromArgb(24, 24, 27);
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(220, 220, 225);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(31, 138, 154);
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(240, 240, 245);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvIngredients.DefaultCellStyle = dataGridViewCellStyle3;
            dgvIngredients.GridColor = Color.FromArgb(45, 45, 48);
            dgvIngredients.Location = new Point(12, 36);
            dgvIngredients.Name = "dgvIngredients";
            dgvIngredients.RowHeadersVisible = false;
            dgvIngredients.Size = new Size(640, 212);
            dgvIngredients.TabIndex = 1;
            dgvIngredients.ThemeStyle.AlternatingRowsStyle.BackColor = Color.FromArgb(24, 24, 27);
            dgvIngredients.ThemeStyle.AlternatingRowsStyle.Font = null;
            dgvIngredients.ThemeStyle.AlternatingRowsStyle.ForeColor = Color.FromArgb(220, 220, 225);
            dgvIngredients.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.Empty;
            dgvIngredients.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.Empty;
            dgvIngredients.ThemeStyle.BackColor = Color.FromArgb(24, 24, 27);
            dgvIngredients.ThemeStyle.GridColor = Color.FromArgb(45, 45, 48);
            dgvIngredients.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(31, 31, 34);
            dgvIngredients.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvIngredients.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dgvIngredients.ThemeStyle.HeaderStyle.ForeColor = Color.FromArgb(160, 160, 166);
            dgvIngredients.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvIngredients.ThemeStyle.HeaderStyle.Height = 23;
            dgvIngredients.ThemeStyle.ReadOnly = false;
            dgvIngredients.ThemeStyle.RowsStyle.BackColor = Color.FromArgb(24, 24, 27);
            dgvIngredients.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvIngredients.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 9F);
            dgvIngredients.ThemeStyle.RowsStyle.ForeColor = Color.FromArgb(220, 220, 225);
            dgvIngredients.ThemeStyle.RowsStyle.Height = 25;
            dgvIngredients.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(31, 138, 154);
            dgvIngredients.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(240, 240, 245);
            // 
            // colIngredient
            // 
            colIngredient.DataPropertyName = "Nguyên liệu";
            colIngredient.HeaderText = "Nguyên liệu";
            colIngredient.Name = "colIngredient";
            // 
            // colAmount
            // 
            colAmount.DataPropertyName = "Định lượng";
            colAmount.HeaderText = "Định lượng";
            colAmount.Name = "colAmount";
            // 
            // colType
            // 
            colType.DataPropertyName = "Loại";
            colType.HeaderText = "Loại";
            colType.Name = "colType";
            // 
            // pnlSteps
            // 
            pnlSteps.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnlSteps.BackColor = Color.FromArgb(24, 24, 27);
            pnlSteps.BorderRadius = 10;
            pnlSteps.Controls.Add(lblStepsTitle);
            pnlSteps.Controls.Add(txtSteps);
            pnlSteps.CustomizableEdges = customizableEdges9;
            pnlSteps.Location = new Point(18, 347);
            pnlSteps.Name = "pnlSteps";
            pnlSteps.ShadowDecoration.CustomizableEdges = customizableEdges10;
            pnlSteps.Size = new Size(664, 270);
            pnlSteps.TabIndex = 3;
            // 
            // lblStepsTitle
            // 
            lblStepsTitle.AutoSize = true;
            lblStepsTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblStepsTitle.ForeColor = Color.FromArgb(245, 158, 11);
            lblStepsTitle.Location = new Point(12, 8);
            lblStepsTitle.Name = "lblStepsTitle";
            lblStepsTitle.Size = new Size(102, 20);
            lblStepsTitle.TabIndex = 0;
            lblStepsTitle.Text = "Cách làm";
            // 
            // txtSteps
            // 
            txtSteps.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtSteps.BorderColor = Color.FromArgb(63, 63, 70);
            txtSteps.BorderRadius = 8;
            txtSteps.CustomizableEdges = customizableEdges7;
            txtSteps.DefaultText = "";
            txtSteps.FillColor = Color.FromArgb(30, 30, 33);
            txtSteps.FocusedState.BorderColor = Color.FromArgb(31, 138, 154);
            txtSteps.Font = new Font("Segoe UI", 10F);
            txtSteps.ForeColor = Color.White;
            txtSteps.HoverState.BorderColor = Color.FromArgb(120, 120, 130);
            txtSteps.Location = new Point(12, 36);
            txtSteps.Multiline = true;
            txtSteps.Name = "txtSteps";
            txtSteps.PasswordChar = '\0';
            txtSteps.PlaceholderText = "";
            txtSteps.ReadOnly = true;
            txtSteps.SelectedText = "";
            txtSteps.ShadowDecoration.CustomizableEdges = customizableEdges8;
            txtSteps.Size = new Size(640, 222);
            txtSteps.TabIndex = 1;
            // 
            // ucRecipe_Barista
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(39, 39, 42);
            Controls.Add(pnlLeft);
            Controls.Add(pnlRight);
            Name = "ucRecipe_Barista";
            Size = new Size(1000, 665);
            pnlLeft.ResumeLayout(false);
            pnlLeft.PerformLayout();
            pnlRight.ResumeLayout(false);
            pnlRight.PerformLayout();
            pnlIngredients.ResumeLayout(false);
            pnlIngredients.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvIngredients).EndInit();
            pnlSteps.ResumeLayout(false);
            pnlSteps.PerformLayout();
            ResumeLayout(false);
        }

        private static void ConfigureGrid(Guna2DataGridView dgv)
        {
            dgv.AutoGenerateColumns = false;
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
        private Guna2TextBox txtSearchRecipe;
        private ListBox lstRecipes;
        private Guna2Panel pnlRight;
        private Label lblRecipeName;
        private Label lblCategory;
        private Guna2Button btnReport;
        private Guna2Panel pnlIngredients;
        private Label lblIngredientsTitle;
        private Guna2DataGridView dgvIngredients;
        private DataGridViewTextBoxColumn colIngredient;
        private DataGridViewTextBoxColumn colAmount;
        private DataGridViewTextBoxColumn colType;
        private Guna2Panel pnlSteps;
        private Label lblStepsTitle;
        private Guna2TextBox txtSteps;
    }
}
