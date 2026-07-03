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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges21 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges22 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges11 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges12 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges13 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges14 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges15 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges16 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges17 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges18 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges19 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges20 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges25 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges26 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges23 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges24 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            tblMain = new TableLayoutPanel();
            pnlSummary = new Guna2Panel();
            btnShowChart = new Guna2Button();
            lblExpenseValue = new Label();
            lblExpenseTitle = new Label();
            lblIncomeValue = new Label();
            lblIncomeTitle = new Label();
            pnlMenu = new Guna2Panel();
            lblMenuTitle = new Label();
            btnAddMenu = new Guna2Button();
            btnEditMenu = new Guna2Button();
            btnDeleteMenu = new Guna2Button();
            txtSearch = new Guna2TextBox();
            txtMinPrice = new Guna2TextBox();
            lblTilde = new Label();
            txtMaxPrice = new Guna2TextBox();
            btnFilter = new Guna2Button();
            btnClearFilter = new Guna2Button();
            dgvMenu = new Guna2DataGridView();
            colFoodId = new DataGridViewTextBoxColumn();
            colFoodName = new DataGridViewTextBoxColumn();
            colPrice = new DataGridViewTextBoxColumn();
            colCategory = new DataGridViewTextBoxColumn();
            colStatus = new DataGridViewTextBoxColumn();
            colDescription = new DataGridViewTextBoxColumn();
            colImageUrl = new DataGridViewTextBoxColumn();
            colInStock = new DataGridViewTextBoxColumn();
            pnlInventory = new Guna2Panel();
            lblInventoryTitle = new Label();
            btnImportMaterial = new Guna2Button();
            dgvInventory = new Guna2DataGridView();
            colInvName = new DataGridViewTextBoxColumn();
            colInvStock = new DataGridViewTextBoxColumn();
            colInvUnit = new DataGridViewTextBoxColumn();
            colInvMinStock = new DataGridViewTextBoxColumn();
            colInvStatus = new DataGridViewTextBoxColumn();
            tblMain.SuspendLayout();
            pnlSummary.SuspendLayout();
            pnlMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMenu).BeginInit();
            pnlInventory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvInventory).BeginInit();
            SuspendLayout();
            //
            // tblMain — 2 cột 50/50: Quản lý Menu + Nguyên Liệu / Kho
            //
            tblMain.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tblMain.ColumnCount = 2;
            tblMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tblMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tblMain.RowCount = 1;
            tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tblMain.Location = new Point(20, 125);
            tblMain.Size = new Size(960, 525);
            tblMain.Controls.Add(pnlMenu, 0, 0);
            tblMain.Controls.Add(pnlInventory, 1, 0);
            //
            // pnlSummary
            //
            pnlSummary.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlSummary.BackColor = Color.FromArgb(31, 31, 34);
            pnlSummary.BorderRadius = 14;
            pnlSummary.Controls.Add(btnShowChart);
            pnlSummary.Controls.Add(lblExpenseValue);
            pnlSummary.Controls.Add(lblExpenseTitle);
            pnlSummary.Controls.Add(lblIncomeValue);
            pnlSummary.Controls.Add(lblIncomeTitle);
            pnlSummary.CustomizableEdges = customizableEdges3;
            pnlSummary.Location = new Point(20, 20);
            pnlSummary.Name = "pnlSummary";
            pnlSummary.ShadowDecoration.CustomizableEdges = customizableEdges4;
            pnlSummary.Size = new Size(960, 90);
            pnlSummary.TabIndex = 0;
            // 
            // btnShowChart
            // 
            btnShowChart.BorderRadius = 10;
            btnShowChart.Cursor = Cursors.Hand;
            btnShowChart.CustomizableEdges = customizableEdges1;
            btnShowChart.FillColor = Color.FromArgb(31, 138, 154);
            btnShowChart.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnShowChart.ForeColor = Color.White;
            btnShowChart.HoverState.FillColor = Color.FromArgb(45, 158, 174);
            btnShowChart.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnShowChart.Location = new Point(780, 28);
            btnShowChart.Name = "btnShowChart";
            btnShowChart.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnShowChart.Size = new Size(160, 34);
            btnShowChart.TabIndex = 0;
            btnShowChart.Text = "Xem Biểu Đồ";
            // 
            // lblExpenseValue
            // 
            lblExpenseValue.AutoSize = true;
            lblExpenseValue.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblExpenseValue.ForeColor = Color.FromArgb(220, 80, 80);
            lblExpenseValue.Location = new Point(280, 40);
            lblExpenseValue.Name = "lblExpenseValue";
            lblExpenseValue.Size = new Size(132, 30);
            lblExpenseValue.TabIndex = 1;
            lblExpenseValue.Text = "- 850,000 đ";
            // 
            // lblExpenseTitle
            // 
            lblExpenseTitle.AutoSize = true;
            lblExpenseTitle.Font = new Font("Segoe UI", 9F);
            lblExpenseTitle.ForeColor = Color.FromArgb(160, 160, 166);
            lblExpenseTitle.Location = new Point(280, 16);
            lblExpenseTitle.Name = "lblExpenseTitle";
            lblExpenseTitle.Size = new Size(138, 15);
            lblExpenseTitle.TabIndex = 2;
            lblExpenseTitle.Text = "Tiền nhập NL (Đầu ra)";
            // 
            // lblIncomeValue
            // 
            lblIncomeValue.AutoSize = true;
            lblIncomeValue.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblIncomeValue.ForeColor = Color.FromArgb(34, 197, 94);
            lblIncomeValue.Location = new Point(20, 40);
            lblIncomeValue.Name = "lblIncomeValue";
            lblIncomeValue.Size = new Size(158, 30);
            lblIncomeValue.TabIndex = 3;
            lblIncomeValue.Text = "+ 5,200,000 đ";
            // 
            // lblIncomeTitle
            // 
            lblIncomeTitle.AutoSize = true;
            lblIncomeTitle.Font = new Font("Segoe UI", 9F);
            lblIncomeTitle.ForeColor = Color.FromArgb(160, 160, 166);
            lblIncomeTitle.Location = new Point(20, 16);
            lblIncomeTitle.Name = "lblIncomeTitle";
            lblIncomeTitle.Size = new Size(152, 15);
            lblIncomeTitle.TabIndex = 4;
            lblIncomeTitle.Text = "Tiền bán hàng (Đầu vào)";
            // 
            // pnlMenu
            // 
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
            pnlMenu.CustomizableEdges = customizableEdges21;
            pnlMenu.Dock = DockStyle.Fill;
            pnlMenu.Margin = new Padding(0, 0, 8, 0);
            // Giữ Size thiết kế để con neo (Anchor) tính đúng khoảng bù trước khi TLP giãn
            pnlMenu.Size = new Size(475, 525);
            pnlMenu.Name = "pnlMenu";
            pnlMenu.ShadowDecoration.CustomizableEdges = customizableEdges22;
            pnlMenu.TabIndex = 1;
            // 
            // lblMenuTitle
            // 
            lblMenuTitle.AutoSize = true;
            lblMenuTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblMenuTitle.ForeColor = Color.White;
            lblMenuTitle.Location = new Point(18, 16);
            lblMenuTitle.Name = "lblMenuTitle";
            lblMenuTitle.Size = new Size(136, 20);
            lblMenuTitle.TabIndex = 0;
            lblMenuTitle.Text = "Quản lý Menu";
            // 
            // btnAddMenu
            // 
            btnAddMenu.BorderRadius = 8;
            btnAddMenu.Cursor = Cursors.Hand;
            btnAddMenu.CustomizableEdges = customizableEdges5;
            btnAddMenu.FillColor = Color.FromArgb(31, 138, 154);
            btnAddMenu.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnAddMenu.ForeColor = Color.White;
            btnAddMenu.HoverState.FillColor = Color.FromArgb(45, 158, 174);
            btnAddMenu.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAddMenu.Location = new Point(220, 12);
            btnAddMenu.Name = "btnAddMenu";
            btnAddMenu.ShadowDecoration.CustomizableEdges = customizableEdges6;
            btnAddMenu.Size = new Size(78, 30);
            btnAddMenu.TabIndex = 1;
            btnAddMenu.Text = "+ Thêm";
            btnAddMenu.Click += BtnAddMenu_Click;
            // 
            // btnEditMenu
            // 
            btnEditMenu.BorderColor = Color.FromArgb(80, 80, 90);
            btnEditMenu.BorderRadius = 8;
            btnEditMenu.BorderThickness = 1;
            btnEditMenu.Cursor = Cursors.Hand;
            btnEditMenu.CustomizableEdges = customizableEdges7;
            btnEditMenu.FillColor = Color.Transparent;
            btnEditMenu.Font = new Font("Segoe UI", 9F);
            btnEditMenu.ForeColor = Color.FromArgb(220, 220, 225);
            btnEditMenu.HoverState.FillColor = Color.FromArgb(45, 45, 50);
            btnEditMenu.HoverState.ForeColor = Color.White;
            btnEditMenu.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnEditMenu.Location = new Point(304, 12);
            btnEditMenu.Name = "btnEditMenu";
            btnEditMenu.ShadowDecoration.CustomizableEdges = customizableEdges8;
            btnEditMenu.Size = new Size(76, 30);
            btnEditMenu.TabIndex = 2;
            btnEditMenu.Text = "Sửa";
            btnEditMenu.Click += BtnEditMenu_Click;
            // 
            // btnDeleteMenu
            // 
            btnDeleteMenu.BorderColor = Color.FromArgb(180, 60, 60);
            btnDeleteMenu.BorderRadius = 8;
            btnDeleteMenu.BorderThickness = 1;
            btnDeleteMenu.Cursor = Cursors.Hand;
            btnDeleteMenu.CustomizableEdges = customizableEdges9;
            btnDeleteMenu.FillColor = Color.Transparent;
            btnDeleteMenu.Font = new Font("Segoe UI", 9F);
            btnDeleteMenu.ForeColor = Color.FromArgb(220, 80, 80);
            btnDeleteMenu.HoverState.FillColor = Color.FromArgb(180, 60, 60);
            btnDeleteMenu.HoverState.ForeColor = Color.White;
            btnDeleteMenu.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnDeleteMenu.Location = new Point(386, 12);
            btnDeleteMenu.Name = "btnDeleteMenu";
            btnDeleteMenu.ShadowDecoration.CustomizableEdges = customizableEdges10;
            btnDeleteMenu.Size = new Size(72, 30);
            btnDeleteMenu.TabIndex = 3;
            btnDeleteMenu.Text = "Xóa";
            btnDeleteMenu.Click += BtnDeleteMenu_Click;
            // 
            // txtSearch
            // 
            txtSearch.BorderColor = Color.FromArgb(63, 63, 70);
            txtSearch.BorderRadius = 10;
            txtSearch.CustomizableEdges = customizableEdges11;
            txtSearch.DefaultText = "";
            txtSearch.DisabledState.BorderColor = Color.FromArgb(63, 63, 70);
            txtSearch.FillColor = Color.FromArgb(30, 30, 33);
            txtSearch.FocusedState.BorderColor = Color.FromArgb(31, 138, 154);
            txtSearch.Font = new Font("Segoe UI", 9.5F);
            txtSearch.ForeColor = Color.White;
            txtSearch.HoverState.BorderColor = Color.FromArgb(120, 120, 130);
            txtSearch.Location = new Point(18, 54);
            txtSearch.Name = "txtSearch";
            txtSearch.PasswordChar = '\0';
            txtSearch.PlaceholderForeColor = Color.FromArgb(110, 110, 120);
            txtSearch.PlaceholderText = "Tên, loại, giá, trạng thái...";
            txtSearch.SelectedText = "";
            txtSearch.ShadowDecoration.CustomizableEdges = customizableEdges12;
            txtSearch.Size = new Size(160, 32);
            txtSearch.TabIndex = 4;
            txtSearch.TextChanged += BtnFilter_Click;
            // 
            // txtMinPrice
            // 
            txtMinPrice.BorderColor = Color.FromArgb(63, 63, 70);
            txtMinPrice.BorderRadius = 10;
            txtMinPrice.CustomizableEdges = customizableEdges13;
            txtMinPrice.DefaultText = "";
            txtMinPrice.DisabledState.BorderColor = Color.FromArgb(63, 63, 70);
            txtMinPrice.FillColor = Color.FromArgb(30, 30, 33);
            txtMinPrice.FocusedState.BorderColor = Color.FromArgb(31, 138, 154);
            txtMinPrice.Font = new Font("Segoe UI", 9.5F);
            txtMinPrice.ForeColor = Color.White;
            txtMinPrice.HoverState.BorderColor = Color.FromArgb(120, 120, 130);
            txtMinPrice.Location = new Point(184, 54);
            txtMinPrice.Name = "txtMinPrice";
            txtMinPrice.PasswordChar = '\0';
            txtMinPrice.PlaceholderForeColor = Color.FromArgb(110, 110, 120);
            txtMinPrice.PlaceholderText = "Giá từ";
            txtMinPrice.SelectedText = "";
            txtMinPrice.ShadowDecoration.CustomizableEdges = customizableEdges14;
            txtMinPrice.Size = new Size(78, 32);
            txtMinPrice.TabIndex = 5;
            txtMinPrice.TextChanged += BtnFilter_Click;
            // 
            // lblTilde
            // 
            lblTilde.AutoSize = true;
            lblTilde.Font = new Font("Segoe UI", 10F);
            lblTilde.ForeColor = Color.FromArgb(160, 160, 166);
            lblTilde.Location = new Point(267, 62);
            lblTilde.Name = "lblTilde";
            lblTilde.Size = new Size(15, 19);
            lblTilde.TabIndex = 6;
            lblTilde.Text = "-";
            // 
            // txtMaxPrice
            // 
            txtMaxPrice.BorderColor = Color.FromArgb(63, 63, 70);
            txtMaxPrice.BorderRadius = 10;
            txtMaxPrice.CustomizableEdges = customizableEdges15;
            txtMaxPrice.DefaultText = "";
            txtMaxPrice.DisabledState.BorderColor = Color.FromArgb(63, 63, 70);
            txtMaxPrice.FillColor = Color.FromArgb(30, 30, 33);
            txtMaxPrice.FocusedState.BorderColor = Color.FromArgb(31, 138, 154);
            txtMaxPrice.Font = new Font("Segoe UI", 9.5F);
            txtMaxPrice.ForeColor = Color.White;
            txtMaxPrice.HoverState.BorderColor = Color.FromArgb(120, 120, 130);
            txtMaxPrice.Location = new Point(282, 54);
            txtMaxPrice.Name = "txtMaxPrice";
            txtMaxPrice.PasswordChar = '\0';
            txtMaxPrice.PlaceholderForeColor = Color.FromArgb(110, 110, 120);
            txtMaxPrice.PlaceholderText = "Đến...";
            txtMaxPrice.SelectedText = "";
            txtMaxPrice.ShadowDecoration.CustomizableEdges = customizableEdges16;
            txtMaxPrice.Size = new Size(78, 32);
            txtMaxPrice.TabIndex = 7;
            txtMaxPrice.TextChanged += BtnFilter_Click;
            // 
            // btnFilter
            // 
            btnFilter.BorderRadius = 8;
            btnFilter.Cursor = Cursors.Hand;
            btnFilter.CustomizableEdges = customizableEdges17;
            btnFilter.FillColor = Color.FromArgb(31, 138, 154);
            btnFilter.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnFilter.ForeColor = Color.White;
            btnFilter.HoverState.FillColor = Color.FromArgb(45, 158, 174);
            btnFilter.Location = new Point(366, 54);
            btnFilter.Name = "btnFilter";
            btnFilter.ShadowDecoration.CustomizableEdges = customizableEdges18;
            btnFilter.Size = new Size(48, 32);
            btnFilter.TabIndex = 8;
            btnFilter.Text = "Lọc";
            btnFilter.Click += BtnFilter_Click;
            // 
            // btnClearFilter
            // 
            btnClearFilter.BorderColor = Color.FromArgb(180, 60, 60);
            btnClearFilter.BorderRadius = 8;
            btnClearFilter.BorderThickness = 1;
            btnClearFilter.Cursor = Cursors.Hand;
            btnClearFilter.CustomizableEdges = customizableEdges19;
            btnClearFilter.FillColor = Color.Transparent;
            btnClearFilter.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnClearFilter.ForeColor = Color.FromArgb(220, 80, 80);
            btnClearFilter.HoverState.FillColor = Color.FromArgb(180, 60, 60);
            btnClearFilter.HoverState.ForeColor = Color.White;
            btnClearFilter.Location = new Point(418, 54);
            btnClearFilter.Name = "btnClearFilter";
            btnClearFilter.ShadowDecoration.CustomizableEdges = customizableEdges20;
            btnClearFilter.Size = new Size(56, 32);
            btnClearFilter.TabIndex = 9;
            btnClearFilter.Text = "Xóa";
            btnClearFilter.Click += BtnClearFilter_Click;
            // 
            // dgvMenu
            // 
            dataGridViewCellStyle1.BackColor = Color.FromArgb(24, 24, 27);
            dataGridViewCellStyle1.ForeColor = Color.FromArgb(220, 220, 225);
            dgvMenu.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvMenu.BackgroundColor = Color.FromArgb(24, 24, 27);
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(31, 31, 34);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(160, 160, 166);
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(31, 31, 34);
            dataGridViewCellStyle2.SelectionForeColor = Color.FromArgb(160, 160, 166);
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvMenu.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvMenu.Columns.AddRange(new DataGridViewColumn[] { colFoodId, colFoodName, colPrice, colCategory, colStatus, colDescription, colImageUrl, colInStock });
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.FromArgb(24, 24, 27);
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(220, 220, 225);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(31, 138, 154);
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(240, 240, 245);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvMenu.DefaultCellStyle = dataGridViewCellStyle3;
            dgvMenu.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvMenu.GridColor = Color.FromArgb(45, 45, 48);
            dgvMenu.Location = new Point(18, 100);
            dgvMenu.Name = "dgvMenu";
            dgvMenu.RowHeadersVisible = false;
            dgvMenu.Size = new Size(440, 410);
            dgvMenu.TabIndex = 10;
            dgvMenu.ThemeStyle.AlternatingRowsStyle.BackColor = Color.FromArgb(24, 24, 27);
            dgvMenu.ThemeStyle.AlternatingRowsStyle.Font = null;
            dgvMenu.ThemeStyle.AlternatingRowsStyle.ForeColor = Color.FromArgb(220, 220, 225);
            dgvMenu.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.Empty;
            dgvMenu.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.Empty;
            dgvMenu.ThemeStyle.BackColor = Color.FromArgb(24, 24, 27);
            dgvMenu.ThemeStyle.GridColor = Color.FromArgb(45, 45, 48);
            dgvMenu.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(31, 31, 34);
            dgvMenu.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvMenu.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dgvMenu.ThemeStyle.HeaderStyle.ForeColor = Color.FromArgb(160, 160, 166);
            dgvMenu.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvMenu.ThemeStyle.HeaderStyle.Height = 23;
            dgvMenu.ThemeStyle.ReadOnly = false;
            dgvMenu.ThemeStyle.RowsStyle.BackColor = Color.FromArgb(24, 24, 27);
            dgvMenu.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvMenu.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 9F);
            dgvMenu.ThemeStyle.RowsStyle.ForeColor = Color.FromArgb(220, 220, 225);
            dgvMenu.ThemeStyle.RowsStyle.Height = 25;
            dgvMenu.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(31, 138, 154);
            dgvMenu.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(240, 240, 245);
            dgvMenu.CellDoubleClick += DgvMenu_CellDoubleClick;
            // 
            // colFoodId
            // 
            colFoodId.DataPropertyName = "Mã món";
            colFoodId.HeaderText = "Mã món";
            colFoodId.Name = "colFoodId";
            colFoodId.Visible = false;
            // 
            // colFoodName
            // 
            colFoodName.DataPropertyName = "Tên món ăn";
            colFoodName.HeaderText = "Tên món ăn";
            colFoodName.Name = "colFoodName";
            // 
            // colPrice
            // 
            colPrice.DataPropertyName = "Giá bán";
            colPrice.HeaderText = "Giá bán";
            colPrice.Name = "colPrice";
            // 
            // colCategory
            // 
            colCategory.DataPropertyName = "Loại";
            colCategory.HeaderText = "Loại";
            colCategory.Name = "colCategory";
            // 
            // colStatus
            // 
            colStatus.DataPropertyName = "Trạng thái";
            colStatus.HeaderText = "Trạng thái";
            colStatus.Name = "colStatus";
            // 
            // colDescription
            // 
            colDescription.DataPropertyName = "MoTa";
            colDescription.HeaderText = "MoTa";
            colDescription.Name = "colDescription";
            colDescription.Visible = false;
            // 
            // colImageUrl
            // 
            colImageUrl.DataPropertyName = "HinhAnhUrl";
            colImageUrl.HeaderText = "HinhAnhUrl";
            colImageUrl.Name = "colImageUrl";
            colImageUrl.Visible = false;
            // 
            // colInStock
            // 
            colInStock.DataPropertyName = "ConHang";
            colInStock.HeaderText = "ConHang";
            colInStock.Name = "colInStock";
            colInStock.Visible = false;
            // 
            // pnlInventory
            // 
            pnlInventory.BackColor = Color.FromArgb(31, 31, 34);
            pnlInventory.BorderRadius = 14;
            pnlInventory.Controls.Add(lblInventoryTitle);
            pnlInventory.Controls.Add(btnImportMaterial);
            pnlInventory.Controls.Add(dgvInventory);
            pnlInventory.CustomizableEdges = customizableEdges25;
            pnlInventory.Dock = DockStyle.Fill;
            pnlInventory.Margin = new Padding(7, 0, 0, 0);
            pnlInventory.Size = new Size(470, 525);
            pnlInventory.Name = "pnlInventory";
            pnlInventory.ShadowDecoration.CustomizableEdges = customizableEdges26;
            pnlInventory.TabIndex = 2;
            // 
            // lblInventoryTitle
            // 
            lblInventoryTitle.AutoSize = true;
            lblInventoryTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblInventoryTitle.ForeColor = Color.White;
            lblInventoryTitle.Location = new Point(18, 16);
            lblInventoryTitle.Name = "lblInventoryTitle";
            lblInventoryTitle.Size = new Size(170, 20);
            lblInventoryTitle.TabIndex = 0;
            lblInventoryTitle.Text = "Nguyên Liệu / Kho";
            // 
            // btnImportMaterial
            // 
            btnImportMaterial.BorderRadius = 8;
            btnImportMaterial.Cursor = Cursors.Hand;
            btnImportMaterial.CustomizableEdges = customizableEdges23;
            btnImportMaterial.FillColor = Color.FromArgb(34, 197, 94);
            btnImportMaterial.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnImportMaterial.ForeColor = Color.White;
            btnImportMaterial.HoverState.FillColor = Color.FromArgb(50, 210, 110);
            btnImportMaterial.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnImportMaterial.Location = new Point(320, 12);
            btnImportMaterial.Name = "btnImportMaterial";
            btnImportMaterial.ShadowDecoration.CustomizableEdges = customizableEdges24;
            btnImportMaterial.Size = new Size(132, 30);
            btnImportMaterial.TabIndex = 1;
            btnImportMaterial.Text = "Quản lý kho";
            btnImportMaterial.Click += BtnImportMaterial_Click;
            // 
            // dgvInventory
            // 
            dataGridViewCellStyle4.BackColor = Color.FromArgb(24, 24, 27);
            dataGridViewCellStyle4.ForeColor = Color.FromArgb(220, 220, 225);
            dgvInventory.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            dgvInventory.BackgroundColor = Color.FromArgb(24, 24, 27);
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = Color.FromArgb(31, 31, 34);
            dataGridViewCellStyle5.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dataGridViewCellStyle5.ForeColor = Color.FromArgb(160, 160, 166);
            dataGridViewCellStyle5.SelectionBackColor = Color.FromArgb(31, 31, 34);
            dataGridViewCellStyle5.SelectionForeColor = Color.FromArgb(160, 160, 166);
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.True;
            dgvInventory.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            dgvInventory.Columns.AddRange(new DataGridViewColumn[] { colInvName, colInvStock, colInvUnit, colInvMinStock, colInvStatus });
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = Color.FromArgb(24, 24, 27);
            dataGridViewCellStyle6.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle6.ForeColor = Color.FromArgb(220, 220, 225);
            dataGridViewCellStyle6.SelectionBackColor = Color.FromArgb(31, 138, 154);
            dataGridViewCellStyle6.SelectionForeColor = Color.FromArgb(240, 240, 245);
            dataGridViewCellStyle6.WrapMode = DataGridViewTriState.False;
            dgvInventory.DefaultCellStyle = dataGridViewCellStyle6;
            dgvInventory.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvInventory.GridColor = Color.FromArgb(45, 45, 48);
            dgvInventory.Location = new Point(18, 54);
            dgvInventory.Name = "dgvInventory";
            dgvInventory.RowHeadersVisible = false;
            dgvInventory.Size = new Size(434, 456);
            dgvInventory.TabIndex = 2;
            dgvInventory.ThemeStyle.AlternatingRowsStyle.BackColor = Color.FromArgb(24, 24, 27);
            dgvInventory.ThemeStyle.AlternatingRowsStyle.Font = null;
            dgvInventory.ThemeStyle.AlternatingRowsStyle.ForeColor = Color.FromArgb(220, 220, 225);
            dgvInventory.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.Empty;
            dgvInventory.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.Empty;
            dgvInventory.ThemeStyle.BackColor = Color.FromArgb(24, 24, 27);
            dgvInventory.ThemeStyle.GridColor = Color.FromArgb(45, 45, 48);
            dgvInventory.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(31, 31, 34);
            dgvInventory.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvInventory.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dgvInventory.ThemeStyle.HeaderStyle.ForeColor = Color.FromArgb(160, 160, 166);
            dgvInventory.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvInventory.ThemeStyle.HeaderStyle.Height = 23;
            dgvInventory.ThemeStyle.ReadOnly = false;
            dgvInventory.ThemeStyle.RowsStyle.BackColor = Color.FromArgb(24, 24, 27);
            dgvInventory.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvInventory.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 9F);
            dgvInventory.ThemeStyle.RowsStyle.ForeColor = Color.FromArgb(220, 220, 225);
            dgvInventory.ThemeStyle.RowsStyle.Height = 25;
            dgvInventory.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(31, 138, 154);
            dgvInventory.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(240, 240, 245);
            // 
            // colInvName
            // 
            colInvName.DataPropertyName = "Tên Nguyên liệu";
            colInvName.FillWeight = 32F;
            colInvName.HeaderText = "Tên NL";
            colInvName.Name = "colInvName";
            // 
            // colInvStock
            // 
            colInvStock.DataPropertyName = "Tồn kho";
            colInvStock.FillWeight = 14F;
            colInvStock.HeaderText = "Tồn kho";
            colInvStock.Name = "colInvStock";
            // 
            // colInvUnit
            // 
            colInvUnit.DataPropertyName = "Đơn vị";
            colInvUnit.FillWeight = 12F;
            colInvUnit.HeaderText = "Đơn vị";
            colInvUnit.Name = "colInvUnit";
            // 
            // colInvMinStock
            // 
            colInvMinStock.DataPropertyName = "Tồn tối thiểu";
            colInvMinStock.FillWeight = 16F;
            colInvMinStock.HeaderText = "Tồn tối thiểu";
            colInvMinStock.Name = "colInvMinStock";
            // 
            // colInvStatus
            // 
            colInvStatus.DataPropertyName = "Trạng thái";
            colInvStatus.FillWeight = 26F;
            colInvStatus.HeaderText = "Trạng thái";
            colInvStatus.Name = "colInvStatus";
            // 
            // ucProducts_Manager
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(39, 39, 42);
            Controls.Add(pnlSummary);
            Controls.Add(tblMain);
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
            tblMain.ResumeLayout(false);
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

        private TableLayoutPanel tblMain;
        private Guna2Panel pnlSummary;
        private Label lblIncomeTitle;
        private Label lblIncomeValue;
        private Label lblExpenseTitle;
        private Label lblExpenseValue;
        private Guna2Button btnShowChart;

        private Guna2Panel pnlMenu;
        private Label lblMenuTitle;
        private Guna2DataGridView dgvMenu;
        private DataGridViewTextBoxColumn colFoodId;
        private DataGridViewTextBoxColumn colFoodName;
        private DataGridViewTextBoxColumn colPrice;
        private DataGridViewTextBoxColumn colCategory;
        private DataGridViewTextBoxColumn colStatus;
        private DataGridViewTextBoxColumn colDescription;
        private DataGridViewTextBoxColumn colImageUrl;
        private DataGridViewTextBoxColumn colInStock;
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
        private DataGridViewTextBoxColumn colInvName;
        private DataGridViewTextBoxColumn colInvStock;
        private DataGridViewTextBoxColumn colInvUnit;
        private DataGridViewTextBoxColumn colInvMinStock;
        private DataGridViewTextBoxColumn colInvStatus;
    }
}
