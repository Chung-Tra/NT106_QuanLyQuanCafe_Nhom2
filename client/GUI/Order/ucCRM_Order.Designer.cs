using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace GUI
{
    partial class ucCRM_Order
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges11 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges12 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges21 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges22 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges13 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges14 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges15 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges16 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges17 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges18 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges19 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges20 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            pnlSearch = new Guna2Panel();
            lblTitle = new Label();
            btnReport = new Guna2Button();
            txtSearch = new Guna2TextBox();
            btnSearch = new Guna2Button();
            btnAddCustomer = new Guna2Button();
            btnEditCustomer = new Guna2Button();
            pnlGrid = new Guna2Panel();
            dgvCustomers = new Guna2DataGridView();
            colCode = new DataGridViewTextBoxColumn();
            colName = new DataGridViewTextBoxColumn();
            colPhone = new DataGridViewTextBoxColumn();
            colEmail = new DataGridViewTextBoxColumn();
            colPoints = new DataGridViewTextBoxColumn();
            colTotalOrders = new DataGridViewTextBoxColumn();
            pnlDetail = new Guna2Panel();
            lblDetailTitle = new Label();
            lblName = new Label();
            txtName = new Guna2TextBox();
            lblPhone = new Label();
            txtPhone = new Guna2TextBox();
            lblEmail = new Label();
            txtEmail = new Guna2TextBox();
            lblPoints = new Label();
            lblPointsValue = new Label();
            btnSaveCustomer = new Guna2Button();
            pnlSearch.SuspendLayout();
            pnlGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCustomers).BeginInit();
            pnlDetail.SuspendLayout();
            SuspendLayout();
            // 
            // pnlSearch
            // 
            pnlSearch.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlSearch.BackColor = Color.FromArgb(31, 31, 34);
            pnlSearch.BorderRadius = 14;
            pnlSearch.Controls.Add(lblTitle);
            pnlSearch.Controls.Add(btnReport);
            pnlSearch.Controls.Add(txtSearch);
            pnlSearch.Controls.Add(btnSearch);
            pnlSearch.Controls.Add(btnAddCustomer);
            pnlSearch.Controls.Add(btnEditCustomer);
            pnlSearch.CustomizableEdges = customizableEdges9;
            pnlSearch.Location = new Point(20, 15);
            pnlSearch.Name = "pnlSearch";
            pnlSearch.ShadowDecoration.CustomizableEdges = customizableEdges10;
            pnlSearch.Size = new Size(960, 70);
            pnlSearch.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(18, 22);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(238, 25);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Khách hàng thân thiết";
            // 
            // btnReport
            // 
            btnReport.BorderRadius = 8;
            btnReport.Cursor = Cursors.Hand;
            btnReport.CustomizableEdges = customizableEdges1;
            btnReport.FillColor = Color.FromArgb(70, 130, 180);
            btnReport.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnReport.ForeColor = Color.White;
            btnReport.HoverState.FillColor = Color.FromArgb(90, 150, 200);
            btnReport.Location = new Point(281, 20);
            btnReport.Name = "btnReport";
            btnReport.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnReport.Size = new Size(95, 32);
            btnReport.TabIndex = 1;
            btnReport.Text = "Báo cáo";
            btnReport.Click += BtnReport_Click;
            // 
            // txtSearch
            // 
            txtSearch.BorderColor = Color.FromArgb(63, 63, 70);
            txtSearch.BorderRadius = 8;
            txtSearch.CustomizableEdges = customizableEdges3;
            txtSearch.DefaultText = "";
            txtSearch.FillColor = Color.FromArgb(30, 30, 33);
            txtSearch.FocusedState.BorderColor = Color.FromArgb(31, 138, 154);
            txtSearch.Font = new Font("Segoe UI", 9.5F);
            txtSearch.ForeColor = Color.White;
            txtSearch.HoverState.BorderColor = Color.FromArgb(120, 120, 130);
            txtSearch.Location = new Point(407, 20);
            txtSearch.Name = "txtSearch";
            txtSearch.PasswordChar = '\0';
            txtSearch.PlaceholderForeColor = Color.FromArgb(110, 110, 120);
            txtSearch.PlaceholderText = "Tìm tên / SĐT / email / mã KH...";
            txtSearch.SelectedText = "";
            txtSearch.ShadowDecoration.CustomizableEdges = customizableEdges4;
            txtSearch.Size = new Size(220, 32);
            txtSearch.TabIndex = 2;
            // 
            // btnSearch
            // 
            btnSearch.BorderRadius = 8;
            btnSearch.Cursor = Cursors.Hand;
            btnSearch.CustomizableEdges = customizableEdges5;
            btnSearch.FillColor = Color.FromArgb(31, 138, 154);
            btnSearch.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnSearch.ForeColor = Color.White;
            btnSearch.HoverState.FillColor = Color.FromArgb(45, 158, 174);
            btnSearch.Location = new Point(660, 20);
            btnSearch.Name = "btnSearch";
            btnSearch.ShadowDecoration.CustomizableEdges = customizableEdges6;
            btnSearch.Size = new Size(75, 32);
            btnSearch.TabIndex = 3;
            btnSearch.Text = "Tìm";
            btnSearch.Click += BtnSearch_Click;
            // 
            // btnAddCustomer
            // 
            btnAddCustomer.BorderRadius = 8;
            btnAddCustomer.Cursor = Cursors.Hand;
            btnAddCustomer.CustomizableEdges = customizableEdges7;
            btnAddCustomer.FillColor = Color.FromArgb(34, 197, 94);
            btnAddCustomer.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnAddCustomer.ForeColor = Color.White;
            btnAddCustomer.HoverState.FillColor = Color.FromArgb(54, 217, 114);
            btnAddCustomer.Location = new Point(762, 20);
            btnAddCustomer.Name = "btnAddCustomer";
            btnAddCustomer.ShadowDecoration.CustomizableEdges = customizableEdges8;
            btnAddCustomer.Size = new Size(85, 32);
            btnAddCustomer.TabIndex = 4;
            btnAddCustomer.Text = "+ Thêm";
            btnAddCustomer.Click += BtnAddCustomer_Click;
            //
            // btnEditCustomer
            //
            btnEditCustomer.BorderColor = Color.FromArgb(80, 80, 90);
            btnEditCustomer.BorderRadius = 8;
            btnEditCustomer.BorderThickness = 1;
            btnEditCustomer.Cursor = Cursors.Hand;
            btnEditCustomer.FillColor = Color.Transparent;
            btnEditCustomer.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnEditCustomer.ForeColor = Color.FromArgb(220, 220, 225);
            btnEditCustomer.HoverState.FillColor = Color.FromArgb(45, 45, 50);
            btnEditCustomer.Location = new Point(855, 20);
            btnEditCustomer.Name = "btnEditCustomer";
            btnEditCustomer.Size = new Size(90, 32);
            btnEditCustomer.Text = "Sửa";
            btnEditCustomer.Click += BtnEditCustomer_Click;
            // 
            // pnlGrid
            // 
            pnlGrid.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnlGrid.BackColor = Color.FromArgb(31, 31, 34);
            pnlGrid.BorderRadius = 14;
            pnlGrid.Controls.Add(dgvCustomers);
            pnlGrid.CustomizableEdges = customizableEdges11;
            pnlGrid.Location = new Point(20, 95);
            pnlGrid.Name = "pnlGrid";
            pnlGrid.ShadowDecoration.CustomizableEdges = customizableEdges12;
            pnlGrid.Size = new Size(960, 360);
            pnlGrid.TabIndex = 1;
            // 
            // dgvCustomers
            // 
            dataGridViewCellStyle1.BackColor = Color.FromArgb(24, 24, 27);
            dataGridViewCellStyle1.ForeColor = Color.FromArgb(220, 220, 225);
            dgvCustomers.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvCustomers.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvCustomers.BackgroundColor = Color.FromArgb(24, 24, 27);
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(31, 31, 34);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(160, 160, 166);
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(31, 31, 34);
            dataGridViewCellStyle2.SelectionForeColor = Color.FromArgb(160, 160, 166);
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvCustomers.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvCustomers.Columns.AddRange(new DataGridViewColumn[] { colCode, colName, colPhone, colEmail, colPoints, colTotalOrders });
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.FromArgb(24, 24, 27);
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(220, 220, 225);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(31, 138, 154);
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(240, 240, 245);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvCustomers.DefaultCellStyle = dataGridViewCellStyle3;
            dgvCustomers.GridColor = Color.FromArgb(45, 45, 48);
            dgvCustomers.Location = new Point(15, 15);
            dgvCustomers.Name = "dgvCustomers";
            dgvCustomers.RowHeadersVisible = false;
            dgvCustomers.Size = new Size(930, 330);
            dgvCustomers.TabIndex = 0;
            dgvCustomers.CellDoubleClick += DgvCustomers_CellDoubleClick;
            dgvCustomers.ThemeStyle.AlternatingRowsStyle.BackColor = Color.FromArgb(24, 24, 27);
            dgvCustomers.ThemeStyle.AlternatingRowsStyle.Font = null;
            dgvCustomers.ThemeStyle.AlternatingRowsStyle.ForeColor = Color.FromArgb(220, 220, 225);
            dgvCustomers.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.Empty;
            dgvCustomers.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.Empty;
            dgvCustomers.ThemeStyle.BackColor = Color.FromArgb(24, 24, 27);
            dgvCustomers.ThemeStyle.GridColor = Color.FromArgb(45, 45, 48);
            dgvCustomers.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(31, 31, 34);
            dgvCustomers.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvCustomers.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dgvCustomers.ThemeStyle.HeaderStyle.ForeColor = Color.FromArgb(160, 160, 166);
            dgvCustomers.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvCustomers.ThemeStyle.HeaderStyle.Height = 23;
            dgvCustomers.ThemeStyle.ReadOnly = false;
            dgvCustomers.ThemeStyle.RowsStyle.BackColor = Color.FromArgb(24, 24, 27);
            dgvCustomers.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvCustomers.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 9F);
            dgvCustomers.ThemeStyle.RowsStyle.ForeColor = Color.FromArgb(220, 220, 225);
            dgvCustomers.ThemeStyle.RowsStyle.Height = 25;
            dgvCustomers.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(31, 138, 154);
            dgvCustomers.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(240, 240, 245);
            // 
            // colCode
            // 
            colCode.DataPropertyName = "Mã KH";
            colCode.HeaderText = "Mã KH";
            colCode.Name = "Mã KH";
            // 
            // colName
            // 
            colName.DataPropertyName = "Tên khách hàng";
            colName.HeaderText = "Tên khách hàng";
            colName.Name = "Tên khách hàng";
            // 
            // colPhone
            // 
            colPhone.DataPropertyName = "Số điện thoại";
            colPhone.HeaderText = "Số điện thoại";
            colPhone.Name = "Số điện thoại";
            // 
            // colEmail
            // 
            colEmail.DataPropertyName = "Email";
            colEmail.HeaderText = "Email";
            colEmail.Name = "Email";
            // 
            // colPoints
            // 
            colPoints.DataPropertyName = "Điểm tích lũy";
            colPoints.HeaderText = "Điểm tích lũy";
            colPoints.Name = "Điểm tích lũy";
            // 
            // colTotalOrders
            // 
            colTotalOrders.DataPropertyName = "Tổng đơn";
            colTotalOrders.HeaderText = "Tổng đơn";
            colTotalOrders.Name = "Tổng đơn";
            // 
            // pnlDetail
            // 
            pnlDetail.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnlDetail.BackColor = Color.FromArgb(31, 31, 34);
            pnlDetail.BorderRadius = 14;
            pnlDetail.Controls.Add(lblDetailTitle);
            pnlDetail.Controls.Add(lblName);
            pnlDetail.Controls.Add(txtName);
            pnlDetail.Controls.Add(lblPhone);
            pnlDetail.Controls.Add(txtPhone);
            pnlDetail.Controls.Add(lblEmail);
            pnlDetail.Controls.Add(txtEmail);
            pnlDetail.Controls.Add(lblPoints);
            pnlDetail.Controls.Add(lblPointsValue);
            pnlDetail.Controls.Add(btnSaveCustomer);
            pnlDetail.CustomizableEdges = customizableEdges21;
            pnlDetail.Location = new Point(20, 470);
            pnlDetail.Name = "pnlDetail";
            pnlDetail.ShadowDecoration.CustomizableEdges = customizableEdges22;
            pnlDetail.Size = new Size(960, 175);
            pnlDetail.TabIndex = 2;
            // 
            // lblDetailTitle
            // 
            lblDetailTitle.AutoSize = true;
            lblDetailTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblDetailTitle.ForeColor = Color.White;
            lblDetailTitle.Location = new Point(18, 14);
            lblDetailTitle.Name = "lblDetailTitle";
            lblDetailTitle.Size = new Size(161, 20);
            lblDetailTitle.TabIndex = 0;
            lblDetailTitle.Text = "Thông tin khách hàng";
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Font = new Font("Segoe UI", 9F);
            lblName.ForeColor = Color.FromArgb(160, 160, 166);
            lblName.Location = new Point(18, 50);
            lblName.Name = "lblName";
            lblName.Size = new Size(43, 15);
            lblName.TabIndex = 1;
            lblName.Text = "Họ tên";
            // 
            // txtName
            // 
            txtName.BorderColor = Color.FromArgb(63, 63, 70);
            txtName.BorderRadius = 8;
            txtName.CustomizableEdges = customizableEdges13;
            txtName.DefaultText = "";
            txtName.FillColor = Color.FromArgb(30, 30, 33);
            txtName.FocusedState.BorderColor = Color.FromArgb(31, 138, 154);
            txtName.Font = new Font("Segoe UI", 9.5F);
            txtName.ForeColor = Color.White;
            txtName.HoverState.BorderColor = Color.FromArgb(120, 120, 130);
            txtName.Location = new Point(18, 72);
            txtName.Name = "txtName";
            txtName.PasswordChar = '\0';
            txtName.PlaceholderForeColor = Color.FromArgb(110, 110, 120);
            txtName.PlaceholderText = "Nhập họ tên";
            txtName.SelectedText = "";
            txtName.ShadowDecoration.CustomizableEdges = customizableEdges14;
            txtName.Size = new Size(220, 32);
            txtName.TabIndex = 2;
            // 
            // lblPhone
            // 
            lblPhone.AutoSize = true;
            lblPhone.Font = new Font("Segoe UI", 9F);
            lblPhone.ForeColor = Color.FromArgb(160, 160, 166);
            lblPhone.Location = new Point(258, 50);
            lblPhone.Name = "lblPhone";
            lblPhone.Size = new Size(76, 15);
            lblPhone.TabIndex = 3;
            lblPhone.Text = "Số điện thoại";
            // 
            // txtPhone
            // 
            txtPhone.BorderColor = Color.FromArgb(63, 63, 70);
            txtPhone.BorderRadius = 8;
            txtPhone.CustomizableEdges = customizableEdges15;
            txtPhone.DefaultText = "";
            txtPhone.FillColor = Color.FromArgb(30, 30, 33);
            txtPhone.FocusedState.BorderColor = Color.FromArgb(31, 138, 154);
            txtPhone.Font = new Font("Segoe UI", 9.5F);
            txtPhone.ForeColor = Color.White;
            txtPhone.HoverState.BorderColor = Color.FromArgb(120, 120, 130);
            txtPhone.Location = new Point(258, 72);
            txtPhone.Name = "txtPhone";
            txtPhone.PasswordChar = '\0';
            txtPhone.PlaceholderForeColor = Color.FromArgb(110, 110, 120);
            txtPhone.PlaceholderText = "0xxxxxxxxx";
            txtPhone.SelectedText = "";
            txtPhone.ShadowDecoration.CustomizableEdges = customizableEdges16;
            txtPhone.Size = new Size(180, 32);
            txtPhone.TabIndex = 4;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Font = new Font("Segoe UI", 9F);
            lblEmail.ForeColor = Color.FromArgb(160, 160, 166);
            lblEmail.Location = new Point(18, 115);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(36, 15);
            lblEmail.TabIndex = 5;
            lblEmail.Text = "Email";
            // 
            // txtEmail
            // 
            txtEmail.BorderColor = Color.FromArgb(63, 63, 70);
            txtEmail.BorderRadius = 8;
            txtEmail.CustomizableEdges = customizableEdges17;
            txtEmail.DefaultText = "";
            txtEmail.FillColor = Color.FromArgb(30, 30, 33);
            txtEmail.FocusedState.BorderColor = Color.FromArgb(31, 138, 154);
            txtEmail.Font = new Font("Segoe UI", 9.5F);
            txtEmail.ForeColor = Color.White;
            txtEmail.HoverState.BorderColor = Color.FromArgb(120, 120, 130);
            txtEmail.Location = new Point(18, 135);
            txtEmail.Name = "txtEmail";
            txtEmail.PasswordChar = '\0';
            txtEmail.PlaceholderForeColor = Color.FromArgb(110, 110, 120);
            txtEmail.PlaceholderText = "email@domain.com";
            txtEmail.SelectedText = "";
            txtEmail.ShadowDecoration.CustomizableEdges = customizableEdges18;
            txtEmail.Size = new Size(220, 30);
            txtEmail.TabIndex = 6;
            // 
            // lblPoints
            // 
            lblPoints.AutoSize = true;
            lblPoints.Font = new Font("Segoe UI", 9F);
            lblPoints.ForeColor = Color.FromArgb(160, 160, 166);
            lblPoints.Location = new Point(258, 115);
            lblPoints.Name = "lblPoints";
            lblPoints.Size = new Size(60, 15);
            lblPoints.TabIndex = 7;
            lblPoints.Text = "Tích điểm";
            // 
            // lblPointsValue
            // 
            lblPointsValue.AutoSize = true;
            lblPointsValue.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblPointsValue.ForeColor = Color.FromArgb(245, 158, 11);
            lblPointsValue.Location = new Point(258, 135);
            lblPointsValue.Name = "lblPointsValue";
            lblPointsValue.Size = new Size(47, 25);
            lblPointsValue.TabIndex = 8;
            lblPointsValue.Text = "0 pt";
            // 
            // btnSaveCustomer
            // 
            btnSaveCustomer.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSaveCustomer.BorderRadius = 10;
            btnSaveCustomer.Cursor = Cursors.Hand;
            btnSaveCustomer.CustomizableEdges = customizableEdges19;
            btnSaveCustomer.FillColor = Color.FromArgb(31, 138, 154);
            btnSaveCustomer.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnSaveCustomer.ForeColor = Color.White;
            btnSaveCustomer.HoverState.FillColor = Color.FromArgb(45, 158, 174);
            btnSaveCustomer.Location = new Point(776, 115);
            btnSaveCustomer.Name = "btnSaveCustomer";
            btnSaveCustomer.ShadowDecoration.CustomizableEdges = customizableEdges20;
            btnSaveCustomer.Size = new Size(170, 42);
            btnSaveCustomer.TabIndex = 9;
            btnSaveCustomer.Text = "Lưu khách hàng";
            btnSaveCustomer.Click += BtnSaveCustomer_Click;
            // 
            // ucCRM_Order
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(39, 39, 42);
            Controls.Add(pnlSearch);
            Controls.Add(pnlGrid);
            Controls.Add(pnlDetail);
            Name = "ucCRM_Order";
            Size = new Size(1000, 665);
            Load += UcCRM_Order_Load;
            pnlSearch.ResumeLayout(false);
            pnlSearch.PerformLayout();
            pnlGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvCustomers).EndInit();
            pnlDetail.ResumeLayout(false);
            pnlDetail.PerformLayout();
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

        private Guna2Panel pnlSearch;
        private Label lblTitle;
        private Guna2Button btnReport;
        private Guna2TextBox txtSearch;
        private Guna2Button btnSearch;
        private Guna2Button btnAddCustomer;
        private Guna2Button btnEditCustomer;
        private Guna2Panel pnlGrid;
        private Guna2DataGridView dgvCustomers;
        private DataGridViewTextBoxColumn colCode;
        private DataGridViewTextBoxColumn colName;
        private DataGridViewTextBoxColumn colPhone;
        private DataGridViewTextBoxColumn colEmail;
        private DataGridViewTextBoxColumn colPoints;
        private DataGridViewTextBoxColumn colTotalOrders;
        private Guna2Panel pnlDetail;
        private Label lblDetailTitle;
        private Label lblName;
        private Guna2TextBox txtName;
        private Label lblPhone;
        private Guna2TextBox txtPhone;
        private Label lblEmail;
        private Guna2TextBox txtEmail;
        private Label lblPoints;
        private Label lblPointsValue;
        private Guna2Button btnSaveCustomer;
    }
}
