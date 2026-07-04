using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace GUI
{
    partial class ucCashManagement_Order
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
            pnlHeader = new Guna2Panel();
            lblTitle = new Label();
            btnReport = new Guna2Button();
            btnStartShift = new Guna2Button();
            btnEndShift = new Guna2Button();
            pnlSummary = new Guna2Panel();
            lblOpenCashTitle = new Label();
            lblOpenCash = new Label();
            lblCurrentCashTitle = new Label();
            lblCurrentCash = new Label();
            lblRevenueTitle = new Label();
            lblRevenue = new Label();
            lblDifferenceTitle = new Label();
            lblDifference = new Label();
            pnlGrid = new Guna2Panel();
            lblLogTitle = new Label();
            dgvTransactions = new Guna2DataGridView();
            colTime = new DataGridViewTextBoxColumn();
            colType = new DataGridViewTextBoxColumn();
            colAmount = new DataGridViewTextBoxColumn();
            colNote = new DataGridViewTextBoxColumn();
            pnlHeader.SuspendLayout();
            pnlSummary.SuspendLayout();
            pnlGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTransactions).BeginInit();
            SuspendLayout();

            // ====== pnlHeader ======
            pnlHeader.BackColor = Color.FromArgb(31, 31, 34);
            pnlHeader.BorderRadius = 14;
            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Controls.Add(btnReport);
            pnlHeader.Controls.Add(btnStartShift);
            pnlHeader.Controls.Add(btnEndShift);
            pnlHeader.Location = new Point(20, 15);
            pnlHeader.Size = new Size(960, 70);
            pnlHeader.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(18, 22);
            lblTitle.Text = "Quản lý tiền mặt";

            btnReport.BorderRadius = 8;
            btnReport.Cursor = Cursors.Hand;
            btnReport.FillColor = Color.FromArgb(70, 130, 180);
            btnReport.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnReport.ForeColor = Color.White;
            btnReport.HoverState.FillColor = Color.FromArgb(90, 150, 200);
            btnReport.Location = new Point(320, 20);
            btnReport.Size = new Size(95, 32);
            btnReport.Text = "Báo cáo";

            btnStartShift.BorderRadius = 10;
            btnStartShift.Cursor = Cursors.Hand;
            btnStartShift.FillColor = Color.FromArgb(34, 197, 94);
            btnStartShift.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnStartShift.ForeColor = Color.White;
            btnStartShift.HoverState.FillColor = Color.FromArgb(54, 217, 114);
            btnStartShift.Location = new Point(430, 18);
            btnStartShift.Size = new Size(150, 36);
            btnStartShift.Text = "▶  Bắt đầu ca";
            btnStartShift.Click += btnStartShift_Click;

            btnEndShift.BorderColor = Color.FromArgb(180, 60, 60);
            btnEndShift.BorderRadius = 10;
            btnEndShift.BorderThickness = 1;
            btnEndShift.Cursor = Cursors.Hand;
            btnEndShift.FillColor = Color.Transparent;
            btnEndShift.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnEndShift.ForeColor = Color.FromArgb(220, 80, 80);
            btnEndShift.HoverState.FillColor = Color.FromArgb(180, 60, 60);
            btnEndShift.HoverState.ForeColor = Color.White;
            btnEndShift.Location = new Point(595, 18);
            btnEndShift.Size = new Size(150, 36);
            btnEndShift.Text = "■  Kết thúc ca";
            btnEndShift.Click += btnEndShift_Click;

            // ====== pnlSummary ======
            pnlSummary.BackColor = Color.FromArgb(31, 31, 34);
            pnlSummary.BorderRadius = 14;
            pnlSummary.Controls.Add(lblOpenCashTitle);
            pnlSummary.Controls.Add(lblOpenCash);
            pnlSummary.Controls.Add(lblCurrentCashTitle);
            pnlSummary.Controls.Add(lblCurrentCash);
            pnlSummary.Controls.Add(lblRevenueTitle);
            pnlSummary.Controls.Add(lblRevenue);
            pnlSummary.Controls.Add(lblDifferenceTitle);
            pnlSummary.Controls.Add(lblDifference);
            pnlSummary.Location = new Point(20, 95);
            pnlSummary.Size = new Size(960, 90);
            pnlSummary.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

            lblOpenCashTitle.AutoSize = true;
            lblOpenCashTitle.Font = new Font("Segoe UI", 9F);
            lblOpenCashTitle.ForeColor = Color.FromArgb(160, 160, 166);
            lblOpenCashTitle.Location = new Point(22, 16);
            lblOpenCashTitle.Text = "Tiền đầu ca";

            lblOpenCash.AutoSize = true;
            lblOpenCash.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblOpenCash.ForeColor = Color.FromArgb(31, 138, 154);
            lblOpenCash.Location = new Point(22, 40);
            lblOpenCash.Text = "0 đ";

            lblCurrentCashTitle.AutoSize = true;
            lblCurrentCashTitle.Font = new Font("Segoe UI", 9F);
            lblCurrentCashTitle.ForeColor = Color.FromArgb(160, 160, 166);
            lblCurrentCashTitle.Location = new Point(212, 16);
            lblCurrentCashTitle.Text = "Tiền hiện tại";

            lblCurrentCash.AutoSize = true;
            lblCurrentCash.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblCurrentCash.ForeColor = Color.FromArgb(34, 197, 94);
            lblCurrentCash.Location = new Point(212, 40);
            lblCurrentCash.Text = "0 đ";

            lblRevenueTitle.AutoSize = true;
            lblRevenueTitle.Font = new Font("Segoe UI", 9F);
            lblRevenueTitle.ForeColor = Color.FromArgb(160, 160, 166);
            lblRevenueTitle.Location = new Point(402, 16);
            lblRevenueTitle.Text = "Doanh thu ca";

            lblRevenue.AutoSize = true;
            lblRevenue.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblRevenue.ForeColor = Color.FromArgb(245, 158, 11);
            lblRevenue.Location = new Point(402, 40);
            lblRevenue.Text = "0 đ";

            lblDifferenceTitle.AutoSize = true;
            lblDifferenceTitle.Font = new Font("Segoe UI", 9F);
            lblDifferenceTitle.ForeColor = Color.FromArgb(160, 160, 166);
            lblDifferenceTitle.Location = new Point(592, 16);
            lblDifferenceTitle.Text = "Chênh lệch";

            lblDifference.AutoSize = true;
            lblDifference.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblDifference.ForeColor = Color.FromArgb(34, 197, 94);
            lblDifference.Location = new Point(592, 40);
            lblDifference.Text = "0 đ";

            // ====== pnlGrid ======
            pnlGrid.BackColor = Color.FromArgb(31, 31, 34);
            pnlGrid.BorderRadius = 14;
            pnlGrid.Controls.Add(lblLogTitle);
            pnlGrid.Controls.Add(dgvTransactions);
            pnlGrid.Location = new Point(20, 195);
            pnlGrid.Size = new Size(960, 450);
            pnlGrid.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            lblLogTitle.AutoSize = true;
            lblLogTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblLogTitle.ForeColor = Color.White;
            lblLogTitle.Location = new Point(18, 14);
            lblLogTitle.Text = "Lịch sử giao dịch";

            dgvTransactions.BackgroundColor = Color.FromArgb(24, 24, 27);
            dgvTransactions.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(31, 31, 34);
            dgvTransactions.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(160, 160, 166);
            dgvTransactions.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dgvTransactions.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(31, 31, 34);
            dgvTransactions.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.FromArgb(160, 160, 166);
            dgvTransactions.DefaultCellStyle.BackColor = Color.FromArgb(24, 24, 27);
            dgvTransactions.DefaultCellStyle.ForeColor = Color.FromArgb(220, 220, 225);
            dgvTransactions.DefaultCellStyle.SelectionBackColor = Color.FromArgb(31, 138, 154);
            dgvTransactions.DefaultCellStyle.SelectionForeColor = Color.FromArgb(240, 240, 245);
            dgvTransactions.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(24, 24, 27);
            dgvTransactions.AlternatingRowsDefaultCellStyle.ForeColor = Color.FromArgb(220, 220, 225);
            dgvTransactions.GridColor = Color.FromArgb(45, 45, 48);
            ConfigureGrid(dgvTransactions);            dgvTransactions.Columns.AddRange(new DataGridViewColumn[] { colTime, colType, colAmount, colNote });
            colTime.HeaderText = "Thời gian"; colTime.Name = "Thời gian"; colTime.DataPropertyName = "Thời gian";
            colType.HeaderText = "Loại"; colType.Name = "Loại"; colType.DataPropertyName = "Loại";
            colAmount.HeaderText = "Số tiền"; colAmount.Name = "Số tiền"; colAmount.DataPropertyName = "Số tiền";
            colNote.HeaderText = "Ghi chú"; colNote.Name = "Ghi chú"; colNote.DataPropertyName = "Ghi chú";
            dgvTransactions.Location = new Point(18, 44);
            dgvTransactions.Size = new Size(924, 388);
            dgvTransactions.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            // ====== ucCashManagement_Order ======
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(39, 39, 42);
            Controls.Add(pnlHeader);
            Controls.Add(pnlSummary);
            Controls.Add(pnlGrid);
            Name = "ucCashManagement_Order";
            Size = new Size(1000, 665);
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            pnlSummary.ResumeLayout(false);
            pnlSummary.PerformLayout();
            pnlGrid.ResumeLayout(false);
            pnlGrid.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTransactions).EndInit();
            btnReport.Click += btnReport_Click;
            dgvTransactions.CellDoubleClick += dgvTransactions_CellDoubleClick;
            Load += ucCashManagement_Order_Load;
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

        private Guna2Panel pnlHeader;
        private Label lblTitle;
        private Guna2Button btnReport;
        private Guna2Button btnStartShift;
        private Guna2Button btnEndShift;
        private Guna2Panel pnlSummary;
        private Label lblOpenCashTitle;
        private Label lblOpenCash;
        private Label lblCurrentCashTitle;
        private Label lblCurrentCash;
        private Label lblRevenueTitle;
        private Label lblRevenue;
        private Label lblDifferenceTitle;
        private Label lblDifference;
        private Guna2Panel pnlGrid;
        private Label lblLogTitle;
        private Guna2DataGridView dgvTransactions;
        private DataGridViewTextBoxColumn colTime;
        private DataGridViewTextBoxColumn colType;
        private DataGridViewTextBoxColumn colAmount;
        private DataGridViewTextBoxColumn colNote;
    }
}
