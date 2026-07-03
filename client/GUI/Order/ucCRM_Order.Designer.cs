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
            pnlSearch = new Guna2Panel();
            lblTitle = new Label();
            btnReport = new Guna2Button();
            txtSearch = new Guna2TextBox();
            btnSearch = new Guna2Button();
            btnAddCustomer = new Guna2Button();
            pnlGrid = new Guna2Panel();
            dgvCustomers = new Guna2DataGridView();
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
            pnlDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCustomers).BeginInit();
            SuspendLayout();

            // ====== pnlSearch ======
            pnlSearch.BackColor = Color.FromArgb(31, 31, 34);
            pnlSearch.BorderRadius = 14;
            pnlSearch.Controls.Add(lblTitle);
            pnlSearch.Controls.Add(btnReport);
            pnlSearch.Controls.Add(txtSearch);
            pnlSearch.Controls.Add(btnSearch);
            pnlSearch.Controls.Add(btnAddCustomer);
            pnlSearch.Location = new Point(20, 15);
            pnlSearch.Size = new Size(764, 70);

            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(18, 22);
            lblTitle.Text = "💝  Khách hàng thân thiết";

            btnReport.BorderRadius = 8;
            btnReport.Cursor = Cursors.Hand;
            btnReport.FillColor = Color.FromArgb(70, 130, 180);
            btnReport.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnReport.ForeColor = Color.White;
            btnReport.HoverState.FillColor = Color.FromArgb(90, 150, 200);
            btnReport.Location = new Point(245, 20);
            btnReport.Size = new Size(95, 32);
            btnReport.Text = "📊 Báo cáo";

            txtSearch.BorderColor = Color.FromArgb(63, 63, 70);
            txtSearch.BorderRadius = 8;
            txtSearch.DefaultText = "";
            txtSearch.FillColor = Color.FromArgb(30, 30, 33);
            txtSearch.FocusedState.BorderColor = Color.FromArgb(31, 138, 154);
            txtSearch.Font = new Font("Segoe UI", 9.5F);
            txtSearch.ForeColor = Color.White;
            txtSearch.HoverState.BorderColor = Color.FromArgb(120, 120, 130);
            txtSearch.Location = new Point(355, 20);
            txtSearch.PlaceholderForeColor = Color.FromArgb(110, 110, 120);
            txtSearch.PlaceholderText = "Tìm theo tên hoặc SĐT...";
            txtSearch.Size = new Size(220, 32);

            btnSearch.BorderRadius = 8;
            btnSearch.Cursor = Cursors.Hand;
            btnSearch.FillColor = Color.FromArgb(31, 138, 154);
            btnSearch.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnSearch.ForeColor = Color.White;
            btnSearch.HoverState.FillColor = Color.FromArgb(45, 158, 174);
            btnSearch.Location = new Point(585, 20);
            btnSearch.Size = new Size(75, 32);
            btnSearch.Text = "🔍  Tìm";
            btnSearch.Click += btnSearch_Click;

            btnAddCustomer.BorderRadius = 8;
            btnAddCustomer.Cursor = Cursors.Hand;
            btnAddCustomer.FillColor = Color.FromArgb(34, 197, 94);
            btnAddCustomer.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnAddCustomer.ForeColor = Color.White;
            btnAddCustomer.HoverState.FillColor = Color.FromArgb(54, 217, 114);
            btnAddCustomer.Location = new Point(665, 20);
            btnAddCustomer.Size = new Size(85, 32);
            btnAddCustomer.Text = "+ Thêm";
            btnAddCustomer.Click += btnAddCustomer_Click;

            // ====== pnlGrid ======
            pnlGrid.BackColor = Color.FromArgb(31, 31, 34);
            pnlGrid.BorderRadius = 14;
            pnlGrid.Controls.Add(dgvCustomers);
            pnlGrid.Location = new Point(20, 95);
            pnlGrid.Size = new Size(764, 235);

            dgvCustomers.BackgroundColor = Color.FromArgb(24, 24, 27);
            dgvCustomers.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(31, 31, 34);
            dgvCustomers.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(160, 160, 166);
            dgvCustomers.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dgvCustomers.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(31, 31, 34);
            dgvCustomers.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.FromArgb(160, 160, 166);
            dgvCustomers.DefaultCellStyle.BackColor = Color.FromArgb(24, 24, 27);
            dgvCustomers.DefaultCellStyle.ForeColor = Color.FromArgb(220, 220, 225);
            dgvCustomers.DefaultCellStyle.SelectionBackColor = Color.FromArgb(31, 138, 154);
            dgvCustomers.DefaultCellStyle.SelectionForeColor = Color.FromArgb(240, 240, 245);
            dgvCustomers.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(24, 24, 27);
            dgvCustomers.AlternatingRowsDefaultCellStyle.ForeColor = Color.FromArgb(220, 220, 225);
            dgvCustomers.GridColor = Color.FromArgb(45, 45, 48);
            ConfigureGrid(dgvCustomers);
            dgvCustomers.Location = new Point(15, 15);
            dgvCustomers.Size = new Size(734, 205);

            // ====== pnlDetail ======
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
            pnlDetail.Location = new Point(20, 340);
            pnlDetail.Size = new Size(764, 175);

            lblDetailTitle.AutoSize = true;
            lblDetailTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblDetailTitle.ForeColor = Color.White;
            lblDetailTitle.Location = new Point(18, 14);
            lblDetailTitle.Text = "Thông tin khách hàng";

            lblName.AutoSize = true;
            lblName.Font = new Font("Segoe UI", 9F);
            lblName.ForeColor = Color.FromArgb(160, 160, 166);
            lblName.Location = new Point(18, 50);
            lblName.Text = "Họ tên";

            txtName.BorderColor = Color.FromArgb(63, 63, 70);
            txtName.BorderRadius = 8;
            txtName.DefaultText = "";
            txtName.FillColor = Color.FromArgb(30, 30, 33);
            txtName.FocusedState.BorderColor = Color.FromArgb(31, 138, 154);
            txtName.Font = new Font("Segoe UI", 9.5F);
            txtName.ForeColor = Color.White;
            txtName.HoverState.BorderColor = Color.FromArgb(120, 120, 130);
            txtName.Location = new Point(18, 72);
            txtName.PlaceholderForeColor = Color.FromArgb(110, 110, 120);
            txtName.PlaceholderText = "Nhập họ tên";
            txtName.Size = new Size(220, 32);

            lblPhone.AutoSize = true;
            lblPhone.Font = new Font("Segoe UI", 9F);
            lblPhone.ForeColor = Color.FromArgb(160, 160, 166);
            lblPhone.Location = new Point(258, 50);
            lblPhone.Text = "Số điện thoại";

            txtPhone.BorderColor = Color.FromArgb(63, 63, 70);
            txtPhone.BorderRadius = 8;
            txtPhone.DefaultText = "";
            txtPhone.FillColor = Color.FromArgb(30, 30, 33);
            txtPhone.FocusedState.BorderColor = Color.FromArgb(31, 138, 154);
            txtPhone.Font = new Font("Segoe UI", 9.5F);
            txtPhone.ForeColor = Color.White;
            txtPhone.HoverState.BorderColor = Color.FromArgb(120, 120, 130);
            txtPhone.Location = new Point(258, 72);
            txtPhone.PlaceholderForeColor = Color.FromArgb(110, 110, 120);
            txtPhone.PlaceholderText = "0xxxxxxxxx";
            txtPhone.Size = new Size(180, 32);

            lblEmail.AutoSize = true;
            lblEmail.Font = new Font("Segoe UI", 9F);
            lblEmail.ForeColor = Color.FromArgb(160, 160, 166);
            lblEmail.Location = new Point(18, 115);
            lblEmail.Text = "Email";

            txtEmail.BorderColor = Color.FromArgb(63, 63, 70);
            txtEmail.BorderRadius = 8;
            txtEmail.DefaultText = "";
            txtEmail.FillColor = Color.FromArgb(30, 30, 33);
            txtEmail.FocusedState.BorderColor = Color.FromArgb(31, 138, 154);
            txtEmail.Font = new Font("Segoe UI", 9.5F);
            txtEmail.ForeColor = Color.White;
            txtEmail.HoverState.BorderColor = Color.FromArgb(120, 120, 130);
            txtEmail.Location = new Point(18, 135);
            txtEmail.PlaceholderForeColor = Color.FromArgb(110, 110, 120);
            txtEmail.PlaceholderText = "email@domain.com";
            txtEmail.Size = new Size(220, 30);

            lblPoints.AutoSize = true;
            lblPoints.Font = new Font("Segoe UI", 9F);
            lblPoints.ForeColor = Color.FromArgb(160, 160, 166);
            lblPoints.Location = new Point(258, 115);
            lblPoints.Text = "Tích điểm";

            lblPointsValue.AutoSize = true;
            lblPointsValue.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblPointsValue.ForeColor = Color.FromArgb(245, 158, 11);
            lblPointsValue.Location = new Point(258, 135);
            lblPointsValue.Text = "0 pt";

            btnSaveCustomer.BorderRadius = 10;
            btnSaveCustomer.Cursor = Cursors.Hand;
            btnSaveCustomer.FillColor = Color.FromArgb(31, 138, 154);
            btnSaveCustomer.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnSaveCustomer.ForeColor = Color.White;
            btnSaveCustomer.HoverState.FillColor = Color.FromArgb(45, 158, 174);
            btnSaveCustomer.Location = new Point(580, 115);
            btnSaveCustomer.Size = new Size(170, 42);
            btnSaveCustomer.Text = "💾  Lưu khách hàng";
            btnSaveCustomer.Click += btnSaveCustomer_Click;

            // ====== ucCRM_Order ======
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(39, 39, 42);
            Controls.Add(pnlSearch);
            Controls.Add(pnlGrid);
            Controls.Add(pnlDetail);
            Name = "ucCRM_Order";
            Size = new Size(804, 530);
            pnlSearch.ResumeLayout(false);
            pnlSearch.PerformLayout();
            pnlGrid.ResumeLayout(false);
            pnlDetail.ResumeLayout(false);
            pnlDetail.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCustomers).EndInit();
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

        private Guna2Panel pnlSearch;
        private Label lblTitle;
        private Guna2Button btnReport;
        private Guna2TextBox txtSearch;
        private Guna2Button btnSearch;
        private Guna2Button btnAddCustomer;
        private Guna2Panel pnlGrid;
        private Guna2DataGridView dgvCustomers;
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
