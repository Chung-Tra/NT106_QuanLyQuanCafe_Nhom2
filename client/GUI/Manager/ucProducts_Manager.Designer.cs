using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace GUI
{
    partial class ucProducts_Manager
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
            pnlSummary = new Guna2Panel();
            btnShowChart = new Guna2Button();
            lblExpenseValue = new Label();
            lblExpenseTitle = new Label();
            lblIncomeValue = new Label();
            lblIncomeTitle = new Label();
            pnlMenu = new Guna2Panel();
            txtSearch = new Guna2TextBox();
            txtMinPrice = new Guna2TextBox();
            lblTilde = new Label();
            txtMaxPrice = new Guna2TextBox();
            btnFilter = new Guna2Button();
            btnClearFilter = new Guna2Button();
            btnDeleteMenu = new Guna2Button();
            btnEditMenu = new Guna2Button();
            btnAddMenu = new Guna2Button();
            dgvMenu = new Guna2DataGridView();
            lblMenuTitle = new Label();
            pnlInventory = new Guna2Panel();
            btnImportMaterial = new Guna2Button();
            dgvInventory = new Guna2DataGridView();
            lblInventoryTitle = new Label();
            pnlSummary.SuspendLayout();
            pnlMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMenu).BeginInit();
            pnlInventory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvInventory).BeginInit();
            SuspendLayout();

            // ====== pnlSummary ======
            pnlSummary.BackColor = Color.FromArgb(31, 31, 34);
            pnlSummary.BorderRadius = 14;
            pnlSummary.Controls.Add(btnShowChart);
            pnlSummary.Controls.Add(lblExpenseValue);
            pnlSummary.Controls.Add(lblExpenseTitle);
            pnlSummary.Controls.Add(lblIncomeValue);
            pnlSummary.Controls.Add(lblIncomeTitle);
            pnlSummary.Location = new Point(20, 20);
            pnlSummary.Size = new Size(960, 90);

            // lblIncomeTitle
            lblIncomeTitle.AutoSize = true;
            lblIncomeTitle.Font = new Font("Segoe UI", 9F);
            lblIncomeTitle.ForeColor = Color.FromArgb(160, 160, 166);
            lblIncomeTitle.Location = new Point(20, 16);
            lblIncomeTitle.Text = "Tiền bán hàng (Đầu vào) 🔺";

            // lblIncomeValue
            lblIncomeValue.AutoSize = true;
            lblIncomeValue.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblIncomeValue.ForeColor = Color.FromArgb(34, 197, 94);
            lblIncomeValue.Location = new Point(20, 40);
            lblIncomeValue.Text = "+ 5,200,000 đ";

            // lblExpenseTitle
            lblExpenseTitle.AutoSize = true;
            lblExpenseTitle.Font = new Font("Segoe UI", 9F);
            lblExpenseTitle.ForeColor = Color.FromArgb(160, 160, 166);
            lblExpenseTitle.Location = new Point(280, 16);
            lblExpenseTitle.Text = "Tiền nhập NL (Đầu ra) 🔻";

            // lblExpenseValue
            lblExpenseValue.AutoSize = true;
            lblExpenseValue.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblExpenseValue.ForeColor = Color.FromArgb(220, 80, 80);
            lblExpenseValue.Location = new Point(280, 40);
            lblExpenseValue.Text = "- 850,000 đ";

            // btnShowChart
            btnShowChart.BorderRadius = 10;
            btnShowChart.Cursor = Cursors.Hand;
            btnShowChart.FillColor = Color.FromArgb(31, 138, 154);
            btnShowChart.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnShowChart.ForeColor = Color.White;
            btnShowChart.HoverState.FillColor = Color.FromArgb(45, 158, 174);
            btnShowChart.Location = new Point(780, 28);
            btnShowChart.Size = new Size(160, 34);
            btnShowChart.Text = "📊  Xem Biểu Đồ";

            // ====== pnlMenu ======
            pnlMenu.BackColor = Color.FromArgb(31, 31, 34);
            pnlMenu.BorderRadius = 14;
            pnlMenu.Controls.Add(lblMenuTitle);
            pnlMenu.Controls.Add(btnAddMenu);
            pnlMenu.Controls.Add(btnEditMenu);
            pnlMenu.Controls.Add(btnDeleteMenu);
            pnlMenu.Controls.Add(txtSearch);
            pnlMenu.Controls.Add(txtMinPrice);
            pnlMenu.Controls.Add(lblTilde);
            pnlMenu.Controls.Add(txtMaxPrice);
            pnlMenu.Controls.Add(btnFilter);
            pnlMenu.Controls.Add(btnClearFilter);
            pnlMenu.Controls.Add(dgvMenu);
            pnlMenu.Location = new Point(20, 125);
            pnlMenu.Size = new Size(475, 525);

            // lblMenuTitle
            lblMenuTitle.AutoSize = true;
            lblMenuTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblMenuTitle.ForeColor = Color.White;
            lblMenuTitle.Location = new Point(18, 16);
            lblMenuTitle.Text = "🍽  Quản lý Menu";

            // btnAddMenu
            btnAddMenu.BorderRadius = 8;
            btnAddMenu.Cursor = Cursors.Hand;
            btnAddMenu.FillColor = Color.FromArgb(31, 138, 154);
            btnAddMenu.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnAddMenu.ForeColor = Color.White;
            btnAddMenu.HoverState.FillColor = Color.FromArgb(45, 158, 174);
            btnAddMenu.Location = new Point(220, 12);
            btnAddMenu.Size = new Size(78, 30);
            btnAddMenu.Text = "+ Thêm";
            btnAddMenu.Click += BtnAddMenu_Click;

            // btnEditMenu
            btnEditMenu.BorderColor = Color.FromArgb(80, 80, 90);
            btnEditMenu.BorderRadius = 8;
            btnEditMenu.BorderThickness = 1;
            btnEditMenu.Cursor = Cursors.Hand;
            btnEditMenu.FillColor = Color.Transparent;
            btnEditMenu.Font = new Font("Segoe UI", 9F);
            btnEditMenu.ForeColor = Color.FromArgb(220, 220, 225);
            btnEditMenu.HoverState.FillColor = Color.FromArgb(45, 45, 50);
            btnEditMenu.HoverState.ForeColor = Color.White;
            btnEditMenu.Location = new Point(304, 12);
            btnEditMenu.Size = new Size(76, 30);
            btnEditMenu.Text = "✏  Sửa";
            btnEditMenu.Click += BtnEditMenu_Click;

            // btnDeleteMenu
            btnDeleteMenu.BorderColor = Color.FromArgb(180, 60, 60);
            btnDeleteMenu.BorderRadius = 8;
            btnDeleteMenu.BorderThickness = 1;
            btnDeleteMenu.Cursor = Cursors.Hand;
            btnDeleteMenu.FillColor = Color.Transparent;
            btnDeleteMenu.Font = new Font("Segoe UI", 9F);
            btnDeleteMenu.ForeColor = Color.FromArgb(220, 80, 80);
            btnDeleteMenu.HoverState.FillColor = Color.FromArgb(180, 60, 60);
            btnDeleteMenu.HoverState.ForeColor = Color.White;
            btnDeleteMenu.Location = new Point(386, 12);
            btnDeleteMenu.Size = new Size(72, 30);
            btnDeleteMenu.Text = "✖  Xóa";
            btnDeleteMenu.Click += BtnDeleteMenu_Click;

            // txtSearch
            txtSearch.BorderColor = Color.FromArgb(63, 63, 70);
            txtSearch.BorderRadius = 10;
            txtSearch.DisabledState.BorderColor = Color.FromArgb(63, 63, 70);
            txtSearch.FillColor = Color.FromArgb(30, 30, 33);
            txtSearch.FocusedState.BorderColor = Color.FromArgb(31, 138, 154);
            txtSearch.Font = new Font("Segoe UI", 9.5F);
            txtSearch.ForeColor = Color.White;
            txtSearch.HoverState.BorderColor = Color.FromArgb(120, 120, 130);
            txtSearch.Location = new Point(18, 54);
            txtSearch.PlaceholderForeColor = Color.FromArgb(110, 110, 120);
            txtSearch.PlaceholderText = "🔍  Tên, loại...";
            txtSearch.Size = new Size(160, 32);
            txtSearch.TextChanged += btnFilter_Click;

            // txtMinPrice
            txtMinPrice.BorderColor = Color.FromArgb(63, 63, 70);
            txtMinPrice.BorderRadius = 10;
            txtMinPrice.DisabledState.BorderColor = Color.FromArgb(63, 63, 70);
            txtMinPrice.FillColor = Color.FromArgb(30, 30, 33);
            txtMinPrice.FocusedState.BorderColor = Color.FromArgb(31, 138, 154);
            txtMinPrice.Font = new Font("Segoe UI", 9.5F);
            txtMinPrice.ForeColor = Color.White;
            txtMinPrice.HoverState.BorderColor = Color.FromArgb(120, 120, 130);
            txtMinPrice.Location = new Point(184, 54);
            txtMinPrice.PlaceholderForeColor = Color.FromArgb(110, 110, 120);
            txtMinPrice.PlaceholderText = "Giá từ";
            txtMinPrice.Size = new Size(78, 32);
            txtMinPrice.TextChanged += btnFilter_Click;

            // lblTilde
            lblTilde.AutoSize = true;
            lblTilde.Font = new Font("Segoe UI", 10F);
            lblTilde.ForeColor = Color.FromArgb(160, 160, 166);
            lblTilde.Location = new Point(267, 62);
            lblTilde.Text = "-";

            // txtMaxPrice
            txtMaxPrice.BorderColor = Color.FromArgb(63, 63, 70);
            txtMaxPrice.BorderRadius = 10;
            txtMaxPrice.DisabledState.BorderColor = Color.FromArgb(63, 63, 70);
            txtMaxPrice.FillColor = Color.FromArgb(30, 30, 33);
            txtMaxPrice.FocusedState.BorderColor = Color.FromArgb(31, 138, 154);
            txtMaxPrice.Font = new Font("Segoe UI", 9.5F);
            txtMaxPrice.ForeColor = Color.White;
            txtMaxPrice.HoverState.BorderColor = Color.FromArgb(120, 120, 130);
            txtMaxPrice.Location = new Point(282, 54);
            txtMaxPrice.PlaceholderForeColor = Color.FromArgb(110, 110, 120);
            txtMaxPrice.PlaceholderText = "Đến...";
            txtMaxPrice.Size = new Size(78, 32);
            txtMaxPrice.TextChanged += btnFilter_Click;

            // btnFilter
            btnFilter.BorderRadius = 8;
            btnFilter.Cursor = Cursors.Hand;
            btnFilter.FillColor = Color.FromArgb(31, 138, 154);
            btnFilter.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnFilter.ForeColor = Color.White;
            btnFilter.HoverState.FillColor = Color.FromArgb(45, 158, 174);
            btnFilter.Location = new Point(366, 54);
            btnFilter.Size = new Size(48, 32);
            btnFilter.Text = "🔍";
            btnFilter.Click += btnFilter_Click;

            // btnClearFilter
            btnClearFilter.BorderColor = Color.FromArgb(180, 60, 60);
            btnClearFilter.BorderRadius = 8;
            btnClearFilter.BorderThickness = 1;
            btnClearFilter.Cursor = Cursors.Hand;
            btnClearFilter.FillColor = Color.Transparent;
            btnClearFilter.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnClearFilter.ForeColor = Color.FromArgb(220, 80, 80);
            btnClearFilter.HoverState.FillColor = Color.FromArgb(180, 60, 60);
            btnClearFilter.HoverState.ForeColor = Color.White;
            btnClearFilter.Location = new Point(418, 54);
            btnClearFilter.Size = new Size(40, 32);
            btnClearFilter.Text = "✖";
            btnClearFilter.Click += btnClearFilter_Click;

            // dgvMenu
            dgvMenu.BackgroundColor = Color.FromArgb(24, 24, 27);
            dgvMenu.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(31, 31, 34);
            dgvMenu.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(160, 160, 166);
            dgvMenu.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dgvMenu.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(31, 31, 34);
            dgvMenu.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.FromArgb(160, 160, 166);
            dgvMenu.DefaultCellStyle.BackColor = Color.FromArgb(24, 24, 27);
            dgvMenu.DefaultCellStyle.ForeColor = Color.FromArgb(220, 220, 225);
            dgvMenu.DefaultCellStyle.SelectionBackColor = Color.FromArgb(31, 138, 154);
            dgvMenu.DefaultCellStyle.SelectionForeColor = Color.FromArgb(240, 240, 245);
            dgvMenu.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(24, 24, 27);
            dgvMenu.AlternatingRowsDefaultCellStyle.ForeColor = Color.FromArgb(220, 220, 225);
            dgvMenu.GridColor = Color.FromArgb(45, 45, 48);
            ConfigureGrid(dgvMenu);
            dgvMenu.Location = new Point(18, 100);
            dgvMenu.Size = new Size(440, 410);
            dgvMenu.CellDoubleClick += DgvMenu_CellDoubleClick;

            // ====== pnlInventory ======
            pnlInventory.BackColor = Color.FromArgb(31, 31, 34);
            pnlInventory.BorderRadius = 14;
            pnlInventory.Controls.Add(lblInventoryTitle);
            pnlInventory.Controls.Add(btnImportMaterial);
            pnlInventory.Controls.Add(dgvInventory);
            pnlInventory.Location = new Point(510, 125);
            pnlInventory.Size = new Size(470, 525);

            // lblInventoryTitle
            lblInventoryTitle.AutoSize = true;
            lblInventoryTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblInventoryTitle.ForeColor = Color.White;
            lblInventoryTitle.Location = new Point(18, 16);
            lblInventoryTitle.Text = "📦  Nguyên Liệu / Kho";

            // btnImportMaterial
            btnImportMaterial.BorderRadius = 8;
            btnImportMaterial.Cursor = Cursors.Hand;
            btnImportMaterial.FillColor = Color.FromArgb(34, 197, 94);
            btnImportMaterial.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnImportMaterial.ForeColor = Color.White;
            btnImportMaterial.HoverState.FillColor = Color.FromArgb(50, 210, 110);
            btnImportMaterial.Location = new Point(320, 12);
            btnImportMaterial.Size = new Size(132, 30);
            btnImportMaterial.Text = "Quản lý kho";
            btnImportMaterial.Click += BtnImportMaterial_Click;

            // dgvInventory
            dgvInventory.BackgroundColor = Color.FromArgb(24, 24, 27);
            dgvInventory.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(31, 31, 34);
            dgvInventory.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(160, 160, 166);
            dgvInventory.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dgvInventory.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(31, 31, 34);
            dgvInventory.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.FromArgb(160, 160, 166);
            dgvInventory.DefaultCellStyle.BackColor = Color.FromArgb(24, 24, 27);
            dgvInventory.DefaultCellStyle.ForeColor = Color.FromArgb(220, 220, 225);
            dgvInventory.DefaultCellStyle.SelectionBackColor = Color.FromArgb(31, 138, 154);
            dgvInventory.DefaultCellStyle.SelectionForeColor = Color.FromArgb(240, 240, 245);
            dgvInventory.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(24, 24, 27);
            dgvInventory.AlternatingRowsDefaultCellStyle.ForeColor = Color.FromArgb(220, 220, 225);
            dgvInventory.GridColor = Color.FromArgb(45, 45, 48);
            ConfigureGrid(dgvInventory);
            dgvInventory.Location = new Point(18, 54);
            dgvInventory.Size = new Size(434, 456);

            // ====== ucProducts_Manager ======
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(39, 39, 42);
            Controls.Add(pnlSummary);
            Controls.Add(pnlMenu);
            Controls.Add(pnlInventory);
            Name = "ucProducts_Manager";
            Size = new Size(1000, 665);
            pnlSummary.ResumeLayout(false);
            pnlSummary.PerformLayout();
            pnlMenu.ResumeLayout(false);
            pnlMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMenu).EndInit();
            pnlInventory.ResumeLayout(false);
            pnlInventory.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvInventory).EndInit();
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

        private Guna2Panel pnlSummary;
        private Label lblIncomeTitle;
        private Label lblIncomeValue;
        private Label lblExpenseTitle;
        private Label lblExpenseValue;
        private Guna2Button btnShowChart;

        private Guna2Panel pnlMenu;
        private Label lblMenuTitle;
        private Guna2DataGridView dgvMenu;
        private Guna2Button btnAddMenu;
        private Guna2Button btnEditMenu;
        private Guna2Button btnDeleteMenu;
        private Guna2TextBox txtSearch;
        private Guna2TextBox txtMinPrice;
        private Label lblTilde;
        private Guna2TextBox txtMaxPrice;
        private Guna2Button btnFilter;
        private Guna2Button btnClearFilter;

        private Guna2Panel pnlInventory;
        private Label lblInventoryTitle;
        private Guna2DataGridView dgvInventory;
        private Guna2Button btnImportMaterial;
    }
}
