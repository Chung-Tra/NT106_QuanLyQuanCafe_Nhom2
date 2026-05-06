namespace GUI
{
    partial class ucProducts_Manager
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            pnlSummary = new Panel();
            btnShowChart = new Button();
            lblExpenseValue = new Label();
            lblExpenseTitle = new Label();
            lblIncomeValue = new Label();
            lblIncomeTitle = new Label();
            pnlMenu = new Panel();

            // Khởi tạo các Control mới cho bộ lọc
            txtSearch = new TextBox();
            txtMinPrice = new TextBox();
            lblTilde = new Label();
            txtMaxPrice = new TextBox();
            btnFilter = new Button();
            btnClearFilter = new Button();

            btnEditMenu = new Button();
            btnAddMenu = new Button();
            dgvMenu = new DataGridView();
            lblMenuTitle = new Label();
            pnlInventory = new Panel();
            btnImportMaterial = new Button();
            dgvInventory = new DataGridView();
            lblInventoryTitle = new Label();
            pnlSummary.SuspendLayout();
            pnlMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMenu).BeginInit();
            pnlInventory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvInventory).BeginInit();
            SuspendLayout();
            // 
            // pnlSummary
            // 
            pnlSummary.BackColor = Color.FromArgb(30, 30, 30);
            pnlSummary.Controls.Add(btnShowChart);
            pnlSummary.Controls.Add(lblExpenseValue);
            pnlSummary.Controls.Add(lblExpenseTitle);
            pnlSummary.Controls.Add(lblIncomeValue);
            pnlSummary.Controls.Add(lblIncomeTitle);
            pnlSummary.Location = new Point(20, 20);
            pnlSummary.Name = "pnlSummary";
            pnlSummary.Size = new Size(764, 80);
            pnlSummary.TabIndex = 0;
            // 
            // btnShowChart
            // 
            btnShowChart.BackColor = Color.White;
            btnShowChart.Cursor = Cursors.Hand;
            btnShowChart.FlatAppearance.BorderSize = 0;
            btnShowChart.FlatStyle = FlatStyle.Flat;
            btnShowChart.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            btnShowChart.ForeColor = Color.Black;
            btnShowChart.Location = new Point(600, 22);
            btnShowChart.Name = "btnShowChart";
            btnShowChart.Size = new Size(140, 35);
            btnShowChart.TabIndex = 4;
            btnShowChart.Text = "Xem Biểu Đồ 📊";
            btnShowChart.UseVisualStyleBackColor = false;
            // 
            // lblExpenseValue
            // 
            lblExpenseValue.AutoSize = true;
            lblExpenseValue.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold);
            lblExpenseValue.ForeColor = Color.IndianRed;
            lblExpenseValue.Location = new Point(220, 35);
            lblExpenseValue.Name = "lblExpenseValue";
            lblExpenseValue.Size = new Size(124, 30);
            lblExpenseValue.TabIndex = 3;
            lblExpenseValue.Text = "- 850,000 đ";
            // 
            // lblExpenseTitle
            // 
            lblExpenseTitle.AutoSize = true;
            lblExpenseTitle.Font = new Font("Segoe UI", 9.75F);
            lblExpenseTitle.ForeColor = Color.Gray;
            lblExpenseTitle.Location = new Point(220, 15);
            lblExpenseTitle.Name = "lblExpenseTitle";
            lblExpenseTitle.Size = new Size(158, 17);
            lblExpenseTitle.TabIndex = 2;
            lblExpenseTitle.Text = "Tiền nhập NL (Đầu ra) 🔻";
            // 
            // lblIncomeValue
            // 
            lblIncomeValue.AutoSize = true;
            lblIncomeValue.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold);
            lblIncomeValue.ForeColor = Color.MediumSeaGreen;
            lblIncomeValue.Location = new Point(20, 35);
            lblIncomeValue.Name = "lblIncomeValue";
            lblIncomeValue.Size = new Size(149, 30);
            lblIncomeValue.TabIndex = 1;
            lblIncomeValue.Text = "+ 5,200,000 đ";
            // 
            // lblIncomeTitle
            // 
            lblIncomeTitle.AutoSize = true;
            lblIncomeTitle.Font = new Font("Segoe UI", 9.75F);
            lblIncomeTitle.ForeColor = Color.Gray;
            lblIncomeTitle.Location = new Point(20, 15);
            lblIncomeTitle.Name = "lblIncomeTitle";
            lblIncomeTitle.Size = new Size(173, 17);
            lblIncomeTitle.TabIndex = 0;
            lblIncomeTitle.Text = "Tiền bán hàng (Đầu vào) 🔺";
            // 
            // pnlMenu
            // 
            pnlMenu.BackColor = Color.FromArgb(30, 30, 30);
            pnlMenu.Controls.Add(txtSearch);
            pnlMenu.Controls.Add(txtMinPrice);
            pnlMenu.Controls.Add(lblTilde);
            pnlMenu.Controls.Add(txtMaxPrice);
            pnlMenu.Controls.Add(btnFilter);
            pnlMenu.Controls.Add(btnClearFilter);
            pnlMenu.Controls.Add(btnDeleteMenu);
            pnlMenu.Controls.Add(btnEditMenu);
            pnlMenu.Controls.Add(btnAddMenu);
            pnlMenu.Controls.Add(dgvMenu);
            pnlMenu.Controls.Add(lblMenuTitle);
            pnlMenu.Location = new Point(20, 120);
            pnlMenu.Name = "pnlMenu";
            pnlMenu.Size = new Size(370, 390);
            pnlMenu.TabIndex = 1;
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(20, 45);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Tên, loại...";
            txtSearch.Size = new Size(110, 23);
            txtSearch.TabIndex = 5;
            txtSearch.TextChanged += btnFilter_Click; // Lọc real-time
            // 
            // txtMinPrice
            // 
            txtMinPrice.Location = new Point(135, 45);
            txtMinPrice.Name = "txtMinPrice";
            txtMinPrice.PlaceholderText = "Giá từ";
            txtMinPrice.Size = new Size(60, 23);
            txtMinPrice.TabIndex = 6;
            txtMinPrice.TextChanged += btnFilter_Click; // Lọc real-time
            // 
            // lblTilde
            // 
            lblTilde.AutoSize = true;
            lblTilde.ForeColor = Color.White;
            lblTilde.Location = new Point(198, 48);
            lblTilde.Name = "lblTilde";
            lblTilde.Size = new Size(12, 15);
            lblTilde.TabIndex = 7;
            lblTilde.Text = "-";
            // 
            // txtMaxPrice
            // 
            txtMaxPrice.Location = new Point(213, 45);
            txtMaxPrice.Name = "txtMaxPrice";
            txtMaxPrice.PlaceholderText = "Đến...";
            txtMaxPrice.Size = new Size(60, 23);
            txtMaxPrice.TabIndex = 8;
            txtMaxPrice.TextChanged += btnFilter_Click; // Lọc real-time
            // 
            // btnFilter
            // 
            btnFilter.BackColor = Color.DodgerBlue;
            btnFilter.Cursor = Cursors.Hand;
            btnFilter.FlatAppearance.BorderSize = 0;
            btnFilter.FlatStyle = FlatStyle.Flat;
            btnFilter.ForeColor = Color.White;
            btnFilter.Location = new Point(280, 44);
            btnFilter.Name = "btnFilter";
            btnFilter.Size = new Size(40, 25);
            btnFilter.TabIndex = 9;
            btnFilter.Text = "🔍";
            btnFilter.UseVisualStyleBackColor = false;
            btnFilter.Click += btnFilter_Click;
            // 
            // btnClearFilter
            // 
            btnClearFilter.BackColor = Color.IndianRed;
            btnClearFilter.Cursor = Cursors.Hand;
            btnClearFilter.FlatAppearance.BorderSize = 0;
            btnClearFilter.FlatStyle = FlatStyle.Flat;
            btnClearFilter.ForeColor = Color.White;
            btnClearFilter.Location = new Point(326, 45);
            btnClearFilter.Name = "btnClearFilter";
            btnClearFilter.Size = new Size(25, 25);
            btnClearFilter.TabIndex = 10;
            btnClearFilter.Text = "✖";
            btnClearFilter.UseVisualStyleBackColor = false;
            btnClearFilter.Click += btnClearFilter_Click;
            // 
            // btnEditMenu
            // 
            btnDeleteMenu = new Button();
            //
            // btnDeleteMenu
            //
            btnDeleteMenu.BackColor = Color.IndianRed;
            btnDeleteMenu.Cursor = Cursors.Hand;
            btnDeleteMenu.FlatAppearance.BorderSize = 0;
            btnDeleteMenu.FlatStyle = FlatStyle.Flat;
            btnDeleteMenu.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            btnDeleteMenu.ForeColor = Color.White;
            btnDeleteMenu.Location = new Point(130, 15);
            btnDeleteMenu.Name = "btnDeleteMenu";
            btnDeleteMenu.Size = new Size(60, 25);
            btnDeleteMenu.TabIndex = 11;
            btnDeleteMenu.Text = "Xóa";
            btnDeleteMenu.UseVisualStyleBackColor = false;
            btnDeleteMenu.Click += BtnDeleteMenu_Click;
            //
            // btnEditMenu
            //
            btnEditMenu.BackColor = Color.FromArgb(45, 45, 48);
            btnEditMenu.FlatAppearance.BorderSize = 0;
            btnEditMenu.FlatStyle = FlatStyle.Flat;
            btnEditMenu.ForeColor = Color.Orange;
            btnEditMenu.Location = new Point(280, 15);
            btnEditMenu.Name = "btnEditMenu";
            btnEditMenu.Size = new Size(70, 25);
            btnEditMenu.TabIndex = 3;
            btnEditMenu.Text = "Sửa món";
            btnEditMenu.UseVisualStyleBackColor = false;
            btnEditMenu.Click += BtnEditMenu_Click;
            // 
            // btnAddMenu
            // 
            btnAddMenu.BackColor = Color.FromArgb(45, 45, 48);
            btnAddMenu.FlatAppearance.BorderSize = 0;
            btnAddMenu.FlatStyle = FlatStyle.Flat;
            btnAddMenu.ForeColor = Color.MediumSeaGreen;
            btnAddMenu.Location = new Point(200, 15);
            btnAddMenu.Name = "btnAddMenu";
            btnAddMenu.Size = new Size(70, 25);
            btnAddMenu.TabIndex = 2;
            btnAddMenu.Text = "+ Thêm";
            btnAddMenu.UseVisualStyleBackColor = false;
            btnAddMenu.Click += BtnAddMenu_Click;
            // 
            // dgvMenu
            // 
            dgvMenu.BackgroundColor = Color.FromArgb(45, 45, 48);
            dgvMenu.BorderStyle = BorderStyle.None;
            dgvMenu.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.FromArgb(45, 45, 48);
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = Color.White;
            dataGridViewCellStyle3.SelectionBackColor = Color.Gray;
            dataGridViewCellStyle3.SelectionForeColor = Color.White;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvMenu.DefaultCellStyle = dataGridViewCellStyle3;
            dgvMenu.Location = new Point(20, 80);
            dgvMenu.Name = "dgvMenu";
            dgvMenu.RowHeadersWidth = 51;
            dgvMenu.Size = new Size(330, 290);
            dgvMenu.TabIndex = 1;
            dgvMenu.CellDoubleClick += DgvMenu_CellDoubleClick;
            // 
            // lblMenuTitle
            // 
            lblMenuTitle.AutoSize = true;
            lblMenuTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblMenuTitle.ForeColor = Color.White;
            lblMenuTitle.Location = new Point(15, 15);
            lblMenuTitle.Name = "lblMenuTitle";
            lblMenuTitle.Size = new Size(117, 21);
            lblMenuTitle.TabIndex = 0;
            lblMenuTitle.Text = "Quản lý Menu";
            // 
            // pnlInventory
            // 
            pnlInventory.BackColor = Color.FromArgb(30, 30, 30);
            pnlInventory.Controls.Add(btnImportMaterial);
            pnlInventory.Controls.Add(dgvInventory);
            pnlInventory.Controls.Add(lblInventoryTitle);
            pnlInventory.Location = new Point(414, 120);
            pnlInventory.Name = "pnlInventory";
            pnlInventory.Size = new Size(370, 390);
            pnlInventory.TabIndex = 2;
            // 
            // btnImportMaterial
            // 
            btnImportMaterial.BackColor = Color.MediumSeaGreen;
            btnImportMaterial.FlatAppearance.BorderSize = 0;
            btnImportMaterial.FlatStyle = FlatStyle.Flat;
            btnImportMaterial.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnImportMaterial.ForeColor = Color.White;
            btnImportMaterial.Location = new Point(235, 15);
            btnImportMaterial.Name = "btnImportMaterial";
            btnImportMaterial.Size = new Size(115, 25);
            btnImportMaterial.TabIndex = 4;
            btnImportMaterial.Text = "+ Nhập Hàng";
            btnImportMaterial.UseVisualStyleBackColor = false;
            btnImportMaterial.Click += BtnImportMaterial_Click;
            // 
            // dgvInventory
            // 
            dgvInventory.BackgroundColor = Color.FromArgb(45, 45, 48);
            dgvInventory.BorderStyle = BorderStyle.None;
            dgvInventory.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = Color.FromArgb(45, 45, 48);
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle4.ForeColor = Color.White;
            dataGridViewCellStyle4.SelectionBackColor = Color.Gray;
            dataGridViewCellStyle4.SelectionForeColor = Color.White;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.False;
            dgvInventory.DefaultCellStyle = dataGridViewCellStyle4;
            dgvInventory.Location = new Point(20, 50);
            dgvInventory.Name = "dgvInventory";
            dgvInventory.RowHeadersWidth = 51;
            dgvInventory.Size = new Size(330, 320);
            dgvInventory.TabIndex = 2;
            // 
            // lblInventoryTitle
            // 
            lblInventoryTitle.AutoSize = true;
            lblInventoryTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblInventoryTitle.ForeColor = Color.White;
            lblInventoryTitle.Location = new Point(15, 15);
            lblInventoryTitle.Name = "lblInventoryTitle";
            lblInventoryTitle.Size = new Size(152, 21);
            lblInventoryTitle.TabIndex = 1;
            lblInventoryTitle.Text = "Nguyên Liệu / Kho";
            // 
            // ucProducts_Manager
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(45, 45, 48);
            Controls.Add(pnlInventory);
            Controls.Add(pnlMenu);
            Controls.Add(pnlSummary);
            Name = "ucProducts_Manager";
            Size = new Size(804, 530);
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

        #endregion

        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.TextBox txtMinPrice;
        private System.Windows.Forms.Label lblTilde;
        private System.Windows.Forms.TextBox txtMaxPrice;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.Button btnClearFilter;

        private System.Windows.Forms.Panel pnlSummary;
        private System.Windows.Forms.Label lblIncomeTitle;
        private System.Windows.Forms.Label lblIncomeValue;
        private System.Windows.Forms.Label lblExpenseTitle;
        private System.Windows.Forms.Label lblExpenseValue;
        private System.Windows.Forms.Button btnShowChart;

        private System.Windows.Forms.Panel pnlMenu;
        private System.Windows.Forms.Label lblMenuTitle;
        private System.Windows.Forms.DataGridView dgvMenu;
        private System.Windows.Forms.Button btnAddMenu;
        private System.Windows.Forms.Button btnEditMenu;
        private System.Windows.Forms.Button btnDeleteMenu;

        private System.Windows.Forms.Panel pnlInventory;
        private System.Windows.Forms.Label lblInventoryTitle;
        private System.Windows.Forms.DataGridView dgvInventory;
        private System.Windows.Forms.Button btnImportMaterial;
    }
}