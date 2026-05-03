using System.Drawing;
using System.Windows.Forms;

namespace GUI
{
    partial class ucCRM_OrderStaff
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
            DataGridViewCellStyle dgvStyle = new DataGridViewCellStyle();
            pnlSearch = new Panel();
            lblTitle = new Label();
            txtSearch = new TextBox();
            btnSearch = new Button();
            btnAddCustomer = new Button();
            btnReport = new Button();
            pnlGrid = new Panel();
            dgvCustomers = new DataGridView();
            pnlDetail = new Panel();
            lblDetailTitle = new Label();
            lblName = new Label();
            txtName = new TextBox();
            lblPhone = new Label();
            txtPhone = new TextBox();
            lblEmail = new Label();
            txtEmail = new TextBox();
            lblPoints = new Label();
            lblPointsValue = new Label();
            btnSaveCustomer = new Button();
            pnlSearch.SuspendLayout();
            pnlGrid.SuspendLayout();
            pnlDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCustomers).BeginInit();
            SuspendLayout();
            //
            // pnlSearch
            //
            pnlSearch.BackColor = Color.FromArgb(30, 30, 30);
            pnlSearch.Controls.Add(lblTitle);
            pnlSearch.Controls.Add(txtSearch);
            pnlSearch.Controls.Add(btnSearch);
            pnlSearch.Controls.Add(btnAddCustomer);
            pnlSearch.Controls.Add(btnReport);
            pnlSearch.Location = new Point(20, 15);
            pnlSearch.Name = "pnlSearch";
            pnlSearch.Size = new Size(764, 55);
            pnlSearch.TabIndex = 0;
            //
            // lblTitle
            //
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(15, 14);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(200, 25);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Khách hàng thân thiết";
            //
            // txtSearch
            //
            txtSearch.BackColor = Color.FromArgb(45, 45, 48);
            txtSearch.BorderStyle = BorderStyle.FixedSingle;
            txtSearch.Font = new Font("Segoe UI", 11F);
            txtSearch.ForeColor = Color.White;
            txtSearch.Location = new Point(300, 14);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Tìm theo tên hoặc SĐT...";
            txtSearch.Size = new Size(230, 27);
            txtSearch.TabIndex = 1;
            //
            // btnSearch
            //
            btnSearch.BackColor = Color.SteelBlue;
            btnSearch.Cursor = Cursors.Hand;
            btnSearch.FlatAppearance.BorderSize = 0;
            btnSearch.FlatStyle = FlatStyle.Flat;
            btnSearch.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            btnSearch.ForeColor = Color.White;
            btnSearch.Location = new Point(540, 13);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(90, 30);
            btnSearch.TabIndex = 2;
            btnSearch.Text = "Tìm";
            btnSearch.UseVisualStyleBackColor = false;
            btnSearch.Click += btnSearch_Click;
            //
            // btnAddCustomer
            //
            btnAddCustomer.BackColor = Color.MediumSeaGreen;
            btnAddCustomer.Cursor = Cursors.Hand;
            btnAddCustomer.FlatAppearance.BorderSize = 0;
            btnAddCustomer.FlatStyle = FlatStyle.Flat;
            btnAddCustomer.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            btnAddCustomer.ForeColor = Color.White;
            btnAddCustomer.Location = new Point(645, 13);
            btnAddCustomer.Name = "btnAddCustomer";
            btnAddCustomer.Size = new Size(100, 30);
            btnAddCustomer.TabIndex = 3;
            btnAddCustomer.Text = "+ Thêm KH";
            btnAddCustomer.UseVisualStyleBackColor = false;
            btnAddCustomer.Click += btnAddCustomer_Click;
            //
            // btnReport
            //
            btnReport.BackColor = Color.FromArgb(70, 130, 180);
            btnReport.Cursor = Cursors.Hand;
            btnReport.FlatAppearance.BorderSize = 0;
            btnReport.FlatStyle = FlatStyle.Flat;
            btnReport.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            btnReport.ForeColor = Color.White;
            btnReport.Location = new Point(200, 14);
            btnReport.Name = "btnReport";
            btnReport.Size = new Size(90, 28);
            btnReport.TabIndex = 4;
            btnReport.Text = "Báo cáo";
            btnReport.UseVisualStyleBackColor = false;
            //
            // pnlGrid
            //
            pnlGrid.BackColor = Color.FromArgb(30, 30, 30);
            pnlGrid.Controls.Add(dgvCustomers);
            pnlGrid.Location = new Point(20, 80);
            pnlGrid.Name = "pnlGrid";
            pnlGrid.Size = new Size(764, 250);
            pnlGrid.TabIndex = 1;
            //
            // dgvCustomers
            //
            dgvCustomers.AllowUserToAddRows = false;
            dgvCustomers.AllowUserToDeleteRows = false;
            dgvCustomers.BackgroundColor = Color.FromArgb(45, 45, 48);
            dgvCustomers.BorderStyle = BorderStyle.None;
            dgvCustomers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvStyle.BackColor = Color.FromArgb(45, 45, 48);
            dgvStyle.Font = new Font("Segoe UI", 9F);
            dgvStyle.ForeColor = Color.White;
            dgvStyle.SelectionBackColor = Color.Gray;
            dgvStyle.SelectionForeColor = Color.White;
            dgvStyle.WrapMode = DataGridViewTriState.False;
            dgvCustomers.DefaultCellStyle = dgvStyle;
            dgvCustomers.Location = new Point(15, 15);
            dgvCustomers.Name = "dgvCustomers";
            dgvCustomers.ReadOnly = true;
            dgvCustomers.RowHeadersWidth = 51;
            dgvCustomers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCustomers.Size = new Size(734, 220);
            dgvCustomers.TabIndex = 0;
            //
            // pnlDetail
            //
            pnlDetail.BackColor = Color.FromArgb(30, 30, 30);
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
            pnlDetail.Location = new Point(20, 340);
            pnlDetail.Name = "pnlDetail";
            pnlDetail.Size = new Size(764, 175);
            pnlDetail.TabIndex = 2;
            //
            // lblDetailTitle
            //
            lblDetailTitle.AutoSize = true;
            lblDetailTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblDetailTitle.ForeColor = Color.White;
            lblDetailTitle.Location = new Point(15, 12);
            lblDetailTitle.Name = "lblDetailTitle";
            lblDetailTitle.Size = new Size(170, 20);
            lblDetailTitle.TabIndex = 0;
            lblDetailTitle.Text = "Thông tin khách hàng";
            //
            // lblName
            //
            lblName.AutoSize = true;
            lblName.Font = new Font("Segoe UI", 10F);
            lblName.ForeColor = Color.Gray;
            lblName.Location = new Point(15, 45);
            lblName.Name = "lblName";
            lblName.Size = new Size(65, 19);
            lblName.TabIndex = 1;
            lblName.Text = "Họ tên:";
            //
            // txtName
            //
            txtName.BackColor = Color.FromArgb(45, 45, 48);
            txtName.BorderStyle = BorderStyle.FixedSingle;
            txtName.Font = new Font("Segoe UI", 10F);
            txtName.ForeColor = Color.White;
            txtName.Location = new Point(90, 43);
            txtName.Name = "txtName";
            txtName.Size = new Size(200, 25);
            txtName.TabIndex = 2;
            //
            // lblPhone
            //
            lblPhone.AutoSize = true;
            lblPhone.Font = new Font("Segoe UI", 10F);
            lblPhone.ForeColor = Color.Gray;
            lblPhone.Location = new Point(310, 45);
            lblPhone.Name = "lblPhone";
            lblPhone.Size = new Size(35, 19);
            lblPhone.TabIndex = 3;
            lblPhone.Text = "SDT:";
            //
            // txtPhone
            //
            txtPhone.BackColor = Color.FromArgb(45, 45, 48);
            txtPhone.BorderStyle = BorderStyle.FixedSingle;
            txtPhone.Font = new Font("Segoe UI", 10F);
            txtPhone.ForeColor = Color.White;
            txtPhone.Location = new Point(355, 43);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(160, 25);
            txtPhone.TabIndex = 4;
            //
            // lblEmail
            //
            lblEmail.AutoSize = true;
            lblEmail.Font = new Font("Segoe UI", 10F);
            lblEmail.ForeColor = Color.Gray;
            lblEmail.Location = new Point(15, 80);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(48, 19);
            lblEmail.TabIndex = 5;
            lblEmail.Text = "Email:";
            //
            // txtEmail
            //
            txtEmail.BackColor = Color.FromArgb(45, 45, 48);
            txtEmail.BorderStyle = BorderStyle.FixedSingle;
            txtEmail.Font = new Font("Segoe UI", 10F);
            txtEmail.ForeColor = Color.White;
            txtEmail.Location = new Point(90, 78);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(200, 25);
            txtEmail.TabIndex = 6;
            //
            // lblPoints
            //
            lblPoints.AutoSize = true;
            lblPoints.Font = new Font("Segoe UI", 10F);
            lblPoints.ForeColor = Color.Gray;
            lblPoints.Location = new Point(310, 80);
            lblPoints.Name = "lblPoints";
            lblPoints.Size = new Size(85, 19);
            lblPoints.TabIndex = 7;
            lblPoints.Text = "Tích điểm:";
            //
            // lblPointsValue
            //
            lblPointsValue.AutoSize = true;
            lblPointsValue.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblPointsValue.ForeColor = Color.Orange;
            lblPointsValue.Location = new Point(400, 77);
            lblPointsValue.Name = "lblPointsValue";
            lblPointsValue.Size = new Size(50, 21);
            lblPointsValue.TabIndex = 8;
            lblPointsValue.Text = "0 pt";
            //
            // btnSaveCustomer
            //
            btnSaveCustomer.BackColor = Color.MediumSeaGreen;
            btnSaveCustomer.Cursor = Cursors.Hand;
            btnSaveCustomer.FlatAppearance.BorderSize = 0;
            btnSaveCustomer.FlatStyle = FlatStyle.Flat;
            btnSaveCustomer.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnSaveCustomer.ForeColor = Color.White;
            btnSaveCustomer.Location = new Point(580, 120);
            btnSaveCustomer.Name = "btnSaveCustomer";
            btnSaveCustomer.Size = new Size(160, 40);
            btnSaveCustomer.TabIndex = 9;
            btnSaveCustomer.Text = "Lưu khách hàng";
            btnSaveCustomer.UseVisualStyleBackColor = false;
            btnSaveCustomer.Click += btnSaveCustomer_Click;
            //
            // ucCRM_OrderStaff
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(45, 45, 48);
            Controls.Add(pnlDetail);
            Controls.Add(pnlGrid);
            Controls.Add(pnlSearch);
            Name = "ucCRM_OrderStaff";
            Size = new Size(804, 530);
            pnlSearch.ResumeLayout(false);
            pnlSearch.PerformLayout();
            pnlGrid.ResumeLayout(false);
            pnlDetail.ResumeLayout(false);
            pnlDetail.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCustomers).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlSearch;
        private Label lblTitle;
        private TextBox txtSearch;
        private Button btnSearch;
        private Button btnAddCustomer;
        private Panel pnlGrid;
        private DataGridView dgvCustomers;
        private Panel pnlDetail;
        private Label lblDetailTitle;
        private Label lblName;
        private TextBox txtName;
        private Label lblPhone;
        private TextBox txtPhone;
        private Label lblEmail;
        private TextBox txtEmail;
        private Label lblPoints;
        private Label lblPointsValue;
        private Button btnSaveCustomer;
        private Button btnReport;
    }
}
