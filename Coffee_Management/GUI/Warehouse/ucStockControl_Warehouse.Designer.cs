using System.Drawing;
using System.Windows.Forms;

namespace GUI
{
    partial class ucStockControl_Warehouse
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
            btnNewImport = new Button();
            btnNewExport = new Button();
            btnNewWaste = new Button();
            btnAttachPhoto = new Button();
            pnlGrid = new Panel();
            dgvStock = new DataGridView();
            pnlSummary = new Panel();
            lblTotalItems = new Label();
            lblTotalItemsTitle = new Label();
            lblLowStock = new Label();
            lblLowStockTitle = new Label();
            lblLastUpdate = new Label();
            lblLastUpdateTitle = new Label();
            lblEstCupsTitle = new Label();
            lblEstCups = new Label();
            btnReport = new Button();
            pnlHeader.SuspendLayout();
            pnlGrid.SuspendLayout();
            pnlSummary.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvStock).BeginInit();
            SuspendLayout();
            //
            // pnlHeader
            //
            pnlHeader.BackColor = Color.FromArgb(30, 30, 30);
            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Controls.Add(btnNewImport);
            pnlHeader.Controls.Add(btnNewExport);
            pnlHeader.Controls.Add(btnNewWaste);
            pnlHeader.Controls.Add(btnAttachPhoto);
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
            lblTitle.Text = "Kiểm soát kho";
            //
            // btnNewImport
            //
            btnNewImport.BackColor = Color.MediumSeaGreen;
            btnNewImport.Cursor = Cursors.Hand;
            btnNewImport.FlatAppearance.BorderSize = 0;
            btnNewImport.FlatStyle = FlatStyle.Flat;
            btnNewImport.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnNewImport.ForeColor = Color.White;
            btnNewImport.Location = new Point(300, 12);
            btnNewImport.Name = "btnNewImport";
            btnNewImport.Size = new Size(100, 32);
            btnNewImport.TabIndex = 1;
            btnNewImport.Text = "+ Nhập kho";
            btnNewImport.UseVisualStyleBackColor = false;
            btnNewImport.Click += btnNewImport_Click;
            //
            // btnNewExport
            //
            btnNewExport.BackColor = Color.SteelBlue;
            btnNewExport.Cursor = Cursors.Hand;
            btnNewExport.FlatAppearance.BorderSize = 0;
            btnNewExport.FlatStyle = FlatStyle.Flat;
            btnNewExport.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnNewExport.ForeColor = Color.White;
            btnNewExport.Location = new Point(410, 12);
            btnNewExport.Name = "btnNewExport";
            btnNewExport.Size = new Size(100, 32);
            btnNewExport.TabIndex = 2;
            btnNewExport.Text = "Xuất kho";
            btnNewExport.UseVisualStyleBackColor = false;
            btnNewExport.Click += btnNewExport_Click;
            //
            // btnNewWaste
            //
            btnNewWaste.BackColor = Color.IndianRed;
            btnNewWaste.Cursor = Cursors.Hand;
            btnNewWaste.FlatAppearance.BorderSize = 0;
            btnNewWaste.FlatStyle = FlatStyle.Flat;
            btnNewWaste.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnNewWaste.ForeColor = Color.White;
            btnNewWaste.Location = new Point(520, 12);
            btnNewWaste.Name = "btnNewWaste";
            btnNewWaste.Size = new Size(100, 32);
            btnNewWaste.TabIndex = 3;
            btnNewWaste.Text = "Hao phí";
            btnNewWaste.UseVisualStyleBackColor = false;
            btnNewWaste.Click += btnNewWaste_Click;
            //
            // btnAttachPhoto
            //
            btnAttachPhoto.BackColor = Color.FromArgb(45, 45, 48);
            btnAttachPhoto.Cursor = Cursors.Hand;
            btnAttachPhoto.FlatAppearance.BorderSize = 0;
            btnAttachPhoto.FlatStyle = FlatStyle.Flat;
            btnAttachPhoto.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnAttachPhoto.ForeColor = Color.White;
            btnAttachPhoto.Location = new Point(640, 12);
            btnAttachPhoto.Name = "btnAttachPhoto";
            btnAttachPhoto.Size = new Size(105, 32);
            btnAttachPhoto.TabIndex = 4;
            btnAttachPhoto.Text = "Đính kèm ảnh";
            btnAttachPhoto.UseVisualStyleBackColor = false;
            btnAttachPhoto.Click += btnAttachPhoto_Click;
            //
            // pnlSummary
            //
            pnlSummary.BackColor = Color.FromArgb(30, 30, 30);
            pnlSummary.Controls.Add(lblTotalItems);
            pnlSummary.Controls.Add(lblTotalItemsTitle);
            pnlSummary.Controls.Add(lblLowStock);
            pnlSummary.Controls.Add(lblLowStockTitle);
            pnlSummary.Controls.Add(lblLastUpdate);
            pnlSummary.Controls.Add(lblLastUpdateTitle);
            pnlSummary.Controls.Add(lblEstCupsTitle);
            pnlSummary.Controls.Add(lblEstCups);
            pnlSummary.Controls.Add(btnReport);
            pnlSummary.Location = new Point(20, 80);
            pnlSummary.Name = "pnlSummary";
            pnlSummary.Size = new Size(764, 65);
            pnlSummary.TabIndex = 1;
            //
            // lblTotalItemsTitle
            //
            lblTotalItemsTitle.AutoSize = true;
            lblTotalItemsTitle.Font = new Font("Segoe UI", 9.75F);
            lblTotalItemsTitle.ForeColor = Color.Gray;
            lblTotalItemsTitle.Location = new Point(20, 10);
            lblTotalItemsTitle.Name = "lblTotalItemsTitle";
            lblTotalItemsTitle.Size = new Size(80, 17);
            lblTotalItemsTitle.TabIndex = 0;
            lblTotalItemsTitle.Text = "Tổng mặt hàng";
            //
            // lblTotalItems
            //
            lblTotalItems.AutoSize = true;
            lblTotalItems.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTotalItems.ForeColor = Color.MediumSeaGreen;
            lblTotalItems.Location = new Point(20, 32);
            lblTotalItems.Name = "lblTotalItems";
            lblTotalItems.Size = new Size(30, 25);
            lblTotalItems.TabIndex = 1;
            lblTotalItems.Text = "48";
            //
            // lblLowStockTitle
            //
            lblLowStockTitle.AutoSize = true;
            lblLowStockTitle.Font = new Font("Segoe UI", 9.75F);
            lblLowStockTitle.ForeColor = Color.Gray;
            lblLowStockTitle.Location = new Point(250, 10);
            lblLowStockTitle.Name = "lblLowStockTitle";
            lblLowStockTitle.Size = new Size(80, 17);
            lblLowStockTitle.TabIndex = 2;
            lblLowStockTitle.Text = "Sắp hết hàng";
            //
            // lblLowStock
            //
            lblLowStock.AutoSize = true;
            lblLowStock.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblLowStock.ForeColor = Color.IndianRed;
            lblLowStock.Location = new Point(250, 32);
            lblLowStock.Name = "lblLowStock";
            lblLowStock.Size = new Size(20, 25);
            lblLowStock.TabIndex = 3;
            lblLowStock.Text = "5";
            //
            // lblLastUpdateTitle
            //
            lblLastUpdateTitle.AutoSize = true;
            lblLastUpdateTitle.Font = new Font("Segoe UI", 9.75F);
            lblLastUpdateTitle.ForeColor = Color.Gray;
            lblLastUpdateTitle.Location = new Point(500, 10);
            lblLastUpdateTitle.Name = "lblLastUpdateTitle";
            lblLastUpdateTitle.Size = new Size(100, 17);
            lblLastUpdateTitle.TabIndex = 4;
            lblLastUpdateTitle.Text = "Cập nhật cuối";
            //
            // lblLastUpdate
            //
            lblLastUpdate.AutoSize = true;
            lblLastUpdate.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblLastUpdate.ForeColor = Color.SteelBlue;
            lblLastUpdate.Location = new Point(500, 32);
            lblLastUpdate.Name = "lblLastUpdate";
            lblLastUpdate.Size = new Size(120, 21);
            lblLastUpdate.TabIndex = 5;
            lblLastUpdate.Text = "02/05/2026";
            //
            // lblEstCupsTitle
            //
            lblEstCupsTitle.AutoSize = true;
            lblEstCupsTitle.Font = new Font("Segoe UI", 9.75F);
            lblEstCupsTitle.ForeColor = Color.Gray;
            lblEstCupsTitle.Location = new Point(650, 10);
            lblEstCupsTitle.Name = "lblEstCupsTitle";
            lblEstCupsTitle.Text = "Ly dự kiến";
            //
            // lblEstCups
            //
            lblEstCups.AutoSize = true;
            lblEstCups.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblEstCups.ForeColor = Color.Orange;
            lblEstCups.Location = new Point(650, 32);
            lblEstCups.Name = "lblEstCups";
            lblEstCups.Text = "~0 ly";
            //
            // btnReport
            //
            btnReport.BackColor = Color.FromArgb(70, 130, 180);
            btnReport.Cursor = Cursors.Hand;
            btnReport.FlatAppearance.BorderSize = 0;
            btnReport.FlatStyle = FlatStyle.Flat;
            btnReport.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            btnReport.ForeColor = Color.White;
            btnReport.Location = new Point(380, 22);
            btnReport.Name = "btnReport";
            btnReport.Size = new Size(100, 28);
            btnReport.Text = "Báo cáo";
            btnReport.Click += btnReport_Click;
            //
            // pnlGrid
            //
            pnlGrid.BackColor = Color.FromArgb(30, 30, 30);
            pnlGrid.Controls.Add(dgvStock);
            pnlGrid.Location = new Point(20, 155);
            pnlGrid.Name = "pnlGrid";
            pnlGrid.Size = new Size(764, 360);
            pnlGrid.TabIndex = 2;
            //
            // dgvStock
            //
            dgvStock.AllowUserToAddRows = false;
            dgvStock.BackgroundColor = Color.FromArgb(45, 45, 48);
            dgvStock.BorderStyle = BorderStyle.None;
            dgvStock.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvStyle.BackColor = Color.FromArgb(45, 45, 48);
            dgvStyle.Font = new Font("Segoe UI", 9F);
            dgvStyle.ForeColor = Color.White;
            dgvStyle.SelectionBackColor = Color.Gray;
            dgvStyle.SelectionForeColor = Color.White;
            dgvStock.DefaultCellStyle = dgvStyle;
            dgvStock.Location = new Point(15, 15);
            dgvStock.Name = "dgvStock";
            dgvStock.ReadOnly = true;
            dgvStock.RowHeadersWidth = 51;
            dgvStock.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvStock.Size = new Size(734, 330);
            dgvStock.TabIndex = 0;
            //
            // ucStockControl_Warehouse
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(45, 45, 48);
            Controls.Add(pnlGrid);
            Controls.Add(pnlSummary);
            Controls.Add(pnlHeader);
            Name = "ucStockControl_Warehouse";
            Size = new Size(804, 530);
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            pnlSummary.ResumeLayout(false);
            pnlSummary.PerformLayout();
            pnlGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvStock).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlHeader;
        private Label lblTitle;
        private Button btnNewImport;
        private Button btnNewExport;
        private Button btnNewWaste;
        private Button btnAttachPhoto;
        private Panel pnlSummary;
        private Label lblTotalItemsTitle;
        private Label lblTotalItems;
        private Label lblLowStockTitle;
        private Label lblLowStock;
        private Label lblLastUpdateTitle;
        private Label lblLastUpdate;
        private Panel pnlGrid;
        private DataGridView dgvStock;
        private Label lblEstCupsTitle;
        private Label lblEstCups;
        private Button btnReport;
    }
}
