using System.Drawing;
using System.Windows.Forms;

namespace GUI
{
    partial class ucCashManagement_OrderStaff
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
            pnlHeader = new Panel();
            lblTitle = new Label();
            btnStartShift = new Button();
            btnEndShift = new Button();
            btnReport = new Button();
            pnlSummary = new Panel();
            lblOpenCash = new Label();
            lblOpenCashTitle = new Label();
            lblCurrentCash = new Label();
            lblCurrentCashTitle = new Label();
            lblRevenue = new Label();
            lblRevenueTitle = new Label();
            lblDifference = new Label();
            lblDifferenceTitle = new Label();
            pnlGrid = new Panel();
            lblLogTitle = new Label();
            dgvTransactions = new DataGridView();
            pnlHeader.SuspendLayout();
            pnlSummary.SuspendLayout();
            pnlGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTransactions).BeginInit();
            SuspendLayout();
            //
            // pnlHeader
            //
            pnlHeader.BackColor = Color.FromArgb(30, 30, 30);
            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Controls.Add(btnStartShift);
            pnlHeader.Controls.Add(btnEndShift);
            pnlHeader.Controls.Add(btnReport);
            pnlHeader.Location = new Point(20, 15);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(764, 55);
            pnlHeader.TabIndex = 0;
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
            lblTitle.Text = "Quản lý tiền mặt";
            //
            // btnStartShift
            //
            btnStartShift.BackColor = Color.MediumSeaGreen;
            btnStartShift.Cursor = Cursors.Hand;
            btnStartShift.FlatAppearance.BorderSize = 0;
            btnStartShift.FlatStyle = FlatStyle.Flat;
            btnStartShift.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            btnStartShift.ForeColor = Color.White;
            btnStartShift.Location = new Point(430, 12);
            btnStartShift.Name = "btnStartShift";
            btnStartShift.Size = new Size(150, 32);
            btnStartShift.TabIndex = 1;
            btnStartShift.Text = "Bắt đầu ca";
            btnStartShift.UseVisualStyleBackColor = false;
            btnStartShift.Click += btnStartShift_Click;
            //
            // btnEndShift
            //
            btnEndShift.BackColor = Color.IndianRed;
            btnEndShift.Cursor = Cursors.Hand;
            btnEndShift.FlatAppearance.BorderSize = 0;
            btnEndShift.FlatStyle = FlatStyle.Flat;
            btnEndShift.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            btnEndShift.ForeColor = Color.White;
            btnEndShift.Location = new Point(595, 12);
            btnEndShift.Name = "btnEndShift";
            btnEndShift.Size = new Size(150, 32);
            btnEndShift.TabIndex = 2;
            btnEndShift.Text = "Kết thúc ca";
            btnEndShift.UseVisualStyleBackColor = false;
            btnEndShift.Click += btnEndShift_Click;
            //
            // btnReport
            //
            btnReport.BackColor = Color.FromArgb(70, 130, 180);
            btnReport.Cursor = Cursors.Hand;
            btnReport.FlatAppearance.BorderSize = 0;
            btnReport.FlatStyle = FlatStyle.Flat;
            btnReport.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            btnReport.ForeColor = Color.White;
            btnReport.Location = new Point(330, 14);
            btnReport.Name = "btnReport";
            btnReport.Size = new Size(90, 28);
            btnReport.TabIndex = 3;
            btnReport.Text = "Báo cáo";
            btnReport.UseVisualStyleBackColor = false;
            //
            // pnlSummary
            //
            pnlSummary.BackColor = Color.FromArgb(30, 30, 30);
            pnlSummary.Controls.Add(lblOpenCash);
            pnlSummary.Controls.Add(lblOpenCashTitle);
            pnlSummary.Controls.Add(lblCurrentCash);
            pnlSummary.Controls.Add(lblCurrentCashTitle);
            pnlSummary.Controls.Add(lblRevenue);
            pnlSummary.Controls.Add(lblRevenueTitle);
            pnlSummary.Controls.Add(lblDifference);
            pnlSummary.Controls.Add(lblDifferenceTitle);
            pnlSummary.Location = new Point(20, 80);
            pnlSummary.Name = "pnlSummary";
            pnlSummary.Size = new Size(764, 80);
            pnlSummary.TabIndex = 1;
            //
            // lblOpenCashTitle
            //
            lblOpenCashTitle.AutoSize = true;
            lblOpenCashTitle.Font = new Font("Segoe UI", 9.75F);
            lblOpenCashTitle.ForeColor = Color.Gray;
            lblOpenCashTitle.Location = new Point(20, 12);
            lblOpenCashTitle.Name = "lblOpenCashTitle";
            lblOpenCashTitle.Size = new Size(90, 17);
            lblOpenCashTitle.TabIndex = 0;
            lblOpenCashTitle.Text = "Tiền đầu ca";
            //
            // lblOpenCash
            //
            lblOpenCash.AutoSize = true;
            lblOpenCash.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblOpenCash.ForeColor = Color.SteelBlue;
            lblOpenCash.Location = new Point(20, 35);
            lblOpenCash.Name = "lblOpenCash";
            lblOpenCash.Size = new Size(130, 25);
            lblOpenCash.TabIndex = 1;
            lblOpenCash.Text = "2,000,000 đ";
            //
            // lblCurrentCashTitle
            //
            lblCurrentCashTitle.AutoSize = true;
            lblCurrentCashTitle.Font = new Font("Segoe UI", 9.75F);
            lblCurrentCashTitle.ForeColor = Color.Gray;
            lblCurrentCashTitle.Location = new Point(200, 12);
            lblCurrentCashTitle.Name = "lblCurrentCashTitle";
            lblCurrentCashTitle.Size = new Size(100, 17);
            lblCurrentCashTitle.TabIndex = 2;
            lblCurrentCashTitle.Text = "Tiền hiện tại";
            //
            // lblCurrentCash
            //
            lblCurrentCash.AutoSize = true;
            lblCurrentCash.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblCurrentCash.ForeColor = Color.MediumSeaGreen;
            lblCurrentCash.Location = new Point(200, 35);
            lblCurrentCash.Name = "lblCurrentCash";
            lblCurrentCash.Size = new Size(130, 25);
            lblCurrentCash.TabIndex = 3;
            lblCurrentCash.Text = "5,350,000 đ";
            //
            // lblRevenueTitle
            //
            lblRevenueTitle.AutoSize = true;
            lblRevenueTitle.Font = new Font("Segoe UI", 9.75F);
            lblRevenueTitle.ForeColor = Color.Gray;
            lblRevenueTitle.Location = new Point(400, 12);
            lblRevenueTitle.Name = "lblRevenueTitle";
            lblRevenueTitle.Size = new Size(80, 17);
            lblRevenueTitle.TabIndex = 4;
            lblRevenueTitle.Text = "Doanh thu ca";
            //
            // lblRevenue
            //
            lblRevenue.AutoSize = true;
            lblRevenue.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblRevenue.ForeColor = Color.Orange;
            lblRevenue.Location = new Point(400, 35);
            lblRevenue.Name = "lblRevenue";
            lblRevenue.Size = new Size(130, 25);
            lblRevenue.TabIndex = 5;
            lblRevenue.Text = "3,350,000 đ";
            //
            // lblDifferenceTitle
            //
            lblDifferenceTitle.AutoSize = true;
            lblDifferenceTitle.Font = new Font("Segoe UI", 9.75F);
            lblDifferenceTitle.ForeColor = Color.Gray;
            lblDifferenceTitle.Location = new Point(600, 12);
            lblDifferenceTitle.Name = "lblDifferenceTitle";
            lblDifferenceTitle.Size = new Size(70, 17);
            lblDifferenceTitle.TabIndex = 6;
            lblDifferenceTitle.Text = "Chênh lệch";
            //
            // lblDifference
            //
            lblDifference.AutoSize = true;
            lblDifference.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblDifference.ForeColor = Color.MediumSeaGreen;
            lblDifference.Location = new Point(600, 35);
            lblDifference.Name = "lblDifference";
            lblDifference.Size = new Size(40, 25);
            lblDifference.TabIndex = 7;
            lblDifference.Text = "0 đ";
            //
            // pnlGrid
            //
            pnlGrid.BackColor = Color.FromArgb(30, 30, 30);
            pnlGrid.Controls.Add(lblLogTitle);
            pnlGrid.Controls.Add(dgvTransactions);
            pnlGrid.Location = new Point(20, 170);
            pnlGrid.Name = "pnlGrid";
            pnlGrid.Size = new Size(764, 345);
            pnlGrid.TabIndex = 2;
            //
            // lblLogTitle
            //
            lblLogTitle.AutoSize = true;
            lblLogTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblLogTitle.ForeColor = Color.White;
            lblLogTitle.Location = new Point(15, 12);
            lblLogTitle.Name = "lblLogTitle";
            lblLogTitle.Size = new Size(150, 20);
            lblLogTitle.TabIndex = 0;
            lblLogTitle.Text = "Lịch sử giao dịch";
            //
            // dgvTransactions
            //
            dgvTransactions.AllowUserToAddRows = false;
            dgvTransactions.AllowUserToDeleteRows = false;
            dgvTransactions.BackgroundColor = Color.FromArgb(45, 45, 48);
            dgvTransactions.BorderStyle = BorderStyle.None;
            dgvTransactions.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvStyle.BackColor = Color.FromArgb(45, 45, 48);
            dgvStyle.Font = new Font("Segoe UI", 9F);
            dgvStyle.ForeColor = Color.White;
            dgvStyle.SelectionBackColor = Color.Gray;
            dgvStyle.SelectionForeColor = Color.White;
            dgvStyle.WrapMode = DataGridViewTriState.False;
            dgvTransactions.DefaultCellStyle = dgvStyle;
            dgvTransactions.Location = new Point(15, 40);
            dgvTransactions.Name = "dgvTransactions";
            dgvTransactions.ReadOnly = true;
            dgvTransactions.RowHeadersWidth = 51;
            dgvTransactions.Size = new Size(734, 290);
            dgvTransactions.TabIndex = 1;
            //
            // ucCashManagement_OrderStaff
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(45, 45, 48);
            Controls.Add(pnlGrid);
            Controls.Add(pnlSummary);
            Controls.Add(pnlHeader);
            Name = "ucCashManagement_OrderStaff";
            Size = new Size(804, 530);
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            pnlSummary.ResumeLayout(false);
            pnlSummary.PerformLayout();
            pnlGrid.ResumeLayout(false);
            pnlGrid.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTransactions).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlHeader;
        private Label lblTitle;
        private Button btnStartShift;
        private Button btnEndShift;
        private Panel pnlSummary;
        private Label lblOpenCashTitle;
        private Label lblOpenCash;
        private Label lblCurrentCashTitle;
        private Label lblCurrentCash;
        private Label lblRevenueTitle;
        private Label lblRevenue;
        private Label lblDifferenceTitle;
        private Label lblDifference;
        private Panel pnlGrid;
        private Label lblLogTitle;
        private DataGridView dgvTransactions;
        private Button btnReport;
    }
}
