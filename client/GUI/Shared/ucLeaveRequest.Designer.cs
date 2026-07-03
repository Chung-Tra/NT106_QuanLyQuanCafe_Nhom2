using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace GUI
{
    partial class ucLeaveRequest
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
            lblRemainingTitle = new Label();
            lblRemainingValue = new Label();
            pnlDivider1 = new Panel();
            lblPendingTitle = new Label();
            lblPendingValue = new Label();
            btnManager = new Guna2Button();
            btnReport = new Guna2Button();
            pnlNewRequest = new Guna2Panel();
            lblNewRequestTitle = new Label();
            lblFromDate = new Label();
            dtpFromDate = new Guna2DateTimePicker();
            lblToDate = new Label();
            dtpToDate = new Guna2DateTimePicker();
            lblReason = new Label();
            txtReason = new Guna2TextBox();
            btnSubmit = new Guna2Button();
            pnlHistory = new Guna2Panel();
            lblHistoryTitle = new Label();
            dgvHistory = new Guna2DataGridView();
            colFrom = new DataGridViewTextBoxColumn();
            colTo = new DataGridViewTextBoxColumn();
            colDays = new DataGridViewTextBoxColumn();
            colReason = new DataGridViewTextBoxColumn();
            colStatus = new DataGridViewTextBoxColumn();
            pnlSummary.SuspendLayout();
            pnlNewRequest.SuspendLayout();
            pnlHistory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvHistory).BeginInit();
            SuspendLayout();

            // ====== pnlSummary ======
            pnlSummary.BackColor = Color.FromArgb(31, 31, 34);
            pnlSummary.BorderRadius = 14;
            pnlSummary.Controls.Add(lblRemainingTitle);
            pnlSummary.Controls.Add(lblRemainingValue);
            pnlSummary.Controls.Add(pnlDivider1);
            pnlSummary.Controls.Add(lblPendingTitle);
            pnlSummary.Controls.Add(lblPendingValue);
            pnlSummary.Controls.Add(btnManager);
            pnlSummary.Controls.Add(btnReport);
            pnlSummary.Location = new Point(20, 20);
            pnlSummary.Size = new Size(960, 100);
            pnlSummary.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

            lblRemainingTitle.AutoSize = true;
            lblRemainingTitle.Font = new Font("Segoe UI", 9F);
            lblRemainingTitle.ForeColor = Color.FromArgb(160, 160, 166);
            lblRemainingTitle.Location = new Point(20, 18);
            lblRemainingTitle.Text = "Ngày phép còn lại";

            lblRemainingValue.AutoSize = true;
            lblRemainingValue.Font = new Font("Segoe UI", 17F, FontStyle.Bold);
            lblRemainingValue.ForeColor = Color.FromArgb(34, 197, 94);
            lblRemainingValue.Location = new Point(20, 42);
            lblRemainingValue.Text = "12 ngày";

            pnlDivider1.BackColor = Color.FromArgb(63, 63, 70);
            pnlDivider1.Location = new Point(270, 22);
            pnlDivider1.Size = new Size(1, 58);

            lblPendingTitle.AutoSize = true;
            lblPendingTitle.Font = new Font("Segoe UI", 9F);
            lblPendingTitle.ForeColor = Color.FromArgb(160, 160, 166);
            lblPendingTitle.Location = new Point(300, 18);
            lblPendingTitle.Text = "Đang chờ duyệt";

            lblPendingValue.AutoSize = true;
            lblPendingValue.Font = new Font("Segoe UI", 17F, FontStyle.Bold);
            lblPendingValue.ForeColor = Color.FromArgb(245, 158, 11);
            lblPendingValue.Location = new Point(300, 42);
            lblPendingValue.Text = "2 đơn";

            btnManager.BorderRadius = 10;
            btnManager.Cursor = Cursors.Hand;
            btnManager.FillColor = Color.FromArgb(31, 138, 154);
            btnManager.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnManager.ForeColor = Color.White;
            btnManager.HoverState.FillColor = Color.FromArgb(45, 158, 174);
            btnManager.Location = new Point(632, 32);
            btnManager.Size = new Size(150, 36);
            btnManager.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnManager.Text = "Quản lý nghỉ";
            btnManager.Click += BtnManager_Click;

            btnReport.BorderRadius = 10;
            btnReport.Cursor = Cursors.Hand;
            btnReport.FillColor = Color.FromArgb(31, 138, 154);
            btnReport.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnReport.ForeColor = Color.White;
            btnReport.HoverState.FillColor = Color.FromArgb(45, 158, 174);
            btnReport.Location = new Point(792, 32);
            btnReport.Size = new Size(150, 36);
            btnReport.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnReport.Text = "Báo cáo";

            // ====== pnlNewRequest ======
            pnlNewRequest.BackColor = Color.FromArgb(31, 31, 34);
            pnlNewRequest.BorderRadius = 14;
            pnlNewRequest.Controls.Add(lblNewRequestTitle);
            pnlNewRequest.Controls.Add(lblFromDate);
            pnlNewRequest.Controls.Add(dtpFromDate);
            pnlNewRequest.Controls.Add(lblToDate);
            pnlNewRequest.Controls.Add(dtpToDate);
            pnlNewRequest.Controls.Add(lblReason);
            pnlNewRequest.Controls.Add(txtReason);
            pnlNewRequest.Controls.Add(btnSubmit);
            pnlNewRequest.Location = new Point(20, 135);
            pnlNewRequest.Size = new Size(340, 510);
            pnlNewRequest.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;

            lblNewRequestTitle.AutoSize = true;
            lblNewRequestTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblNewRequestTitle.ForeColor = Color.FromArgb(31, 138, 154);
            lblNewRequestTitle.Location = new Point(20, 18);
            lblNewRequestTitle.Text = "Tạo yêu cầu nghỉ";

            lblFromDate.AutoSize = true;
            lblFromDate.Font = new Font("Segoe UI", 9F);
            lblFromDate.ForeColor = Color.FromArgb(160, 160, 166);
            lblFromDate.Location = new Point(20, 70);
            lblFromDate.Text = "Từ ngày";

            dtpFromDate.BorderColor = Color.FromArgb(63, 63, 70);
            dtpFromDate.BorderRadius = 10;
            dtpFromDate.FillColor = Color.FromArgb(30, 30, 33);
            dtpFromDate.Font = new Font("Segoe UI", 10F);
            dtpFromDate.ForeColor = Color.White;
            dtpFromDate.Format = DateTimePickerFormat.Short;
            dtpFromDate.Location = new Point(20, 92);
            dtpFromDate.Size = new Size(300, 36);

            lblToDate.AutoSize = true;
            lblToDate.Font = new Font("Segoe UI", 9F);
            lblToDate.ForeColor = Color.FromArgb(160, 160, 166);
            lblToDate.Location = new Point(20, 144);
            lblToDate.Text = "Đến ngày";

            dtpToDate.BorderColor = Color.FromArgb(63, 63, 70);
            dtpToDate.BorderRadius = 10;
            dtpToDate.FillColor = Color.FromArgb(30, 30, 33);
            dtpToDate.Font = new Font("Segoe UI", 10F);
            dtpToDate.ForeColor = Color.White;
            dtpToDate.Format = DateTimePickerFormat.Short;
            dtpToDate.Location = new Point(20, 166);
            dtpToDate.Size = new Size(300, 36);

            lblReason.AutoSize = true;
            lblReason.Font = new Font("Segoe UI", 9F);
            lblReason.ForeColor = Color.FromArgb(160, 160, 166);
            lblReason.Location = new Point(20, 218);
            lblReason.Text = "Lý do nghỉ";

            txtReason.BorderColor = Color.FromArgb(63, 63, 70);
            txtReason.BorderRadius = 10;
            txtReason.FillColor = Color.FromArgb(30, 30, 33);
            txtReason.FocusedState.BorderColor = Color.FromArgb(31, 138, 154);
            txtReason.Font = new Font("Segoe UI", 10F);
            txtReason.ForeColor = Color.White;
            txtReason.HoverState.BorderColor = Color.FromArgb(120, 120, 130);
            txtReason.Location = new Point(20, 240);
            txtReason.Multiline = true;
            txtReason.PlaceholderForeColor = Color.FromArgb(110, 110, 120);
            txtReason.PlaceholderText = "Nhập lý do nghỉ phép...";
            txtReason.Size = new Size(300, 160);

            btnSubmit.BorderRadius = 10;
            btnSubmit.Cursor = Cursors.Hand;
            btnSubmit.FillColor = Color.FromArgb(34, 197, 94);
            btnSubmit.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnSubmit.ForeColor = Color.White;
            btnSubmit.HoverState.FillColor = Color.FromArgb(45, 207, 104);
            btnSubmit.Location = new Point(20, 420);
            btnSubmit.Size = new Size(300, 44);
            btnSubmit.Text = "Gửi yêu cầu";

            // ====== pnlHistory ======
            pnlHistory.BackColor = Color.FromArgb(31, 31, 34);
            pnlHistory.BorderRadius = 14;
            pnlHistory.Controls.Add(lblHistoryTitle);
            pnlHistory.Controls.Add(dgvHistory);
            pnlHistory.Location = new Point(380, 135);
            pnlHistory.Size = new Size(600, 510);
            pnlHistory.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            lblHistoryTitle.AutoSize = true;
            lblHistoryTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblHistoryTitle.ForeColor = Color.White;
            lblHistoryTitle.Location = new Point(20, 18);
            lblHistoryTitle.Text = "Lịch sử yêu cầu";

            dgvHistory.BackgroundColor = Color.FromArgb(24, 24, 27);
            dgvHistory.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(31, 31, 34);
            dgvHistory.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(160, 160, 166);
            dgvHistory.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dgvHistory.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(31, 31, 34);
            dgvHistory.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.FromArgb(160, 160, 166);
            dgvHistory.DefaultCellStyle.BackColor = Color.FromArgb(24, 24, 27);
            dgvHistory.DefaultCellStyle.ForeColor = Color.FromArgb(220, 220, 225);
            dgvHistory.DefaultCellStyle.SelectionBackColor = Color.FromArgb(31, 138, 154);
            dgvHistory.DefaultCellStyle.SelectionForeColor = Color.FromArgb(240, 240, 245);
            dgvHistory.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(24, 24, 27);
            dgvHistory.AlternatingRowsDefaultCellStyle.ForeColor = Color.FromArgb(220, 220, 225);
            dgvHistory.GridColor = Color.FromArgb(45, 45, 48);
            ConfigureGrid(dgvHistory);            dgvHistory.Columns.AddRange(new DataGridViewColumn[] { colFrom, colTo, colDays, colReason, colStatus });
            colFrom.HeaderText = "Từ ngày"; colFrom.Name = "Từ ngày"; colFrom.DataPropertyName = "Từ ngày";
            colTo.HeaderText = "Đến ngày"; colTo.Name = "Đến ngày"; colTo.DataPropertyName = "Đến ngày";
            colDays.HeaderText = "Số ngày"; colDays.Name = "Số ngày"; colDays.DataPropertyName = "Số ngày";
            colReason.HeaderText = "Lý do"; colReason.Name = "Lý do"; colReason.DataPropertyName = "Lý do";
            colStatus.HeaderText = "Trạng thái"; colStatus.Name = "Trạng thái"; colStatus.DataPropertyName = "Trạng thái";
            dgvHistory.Location = new Point(18, 56);
            dgvHistory.Size = new Size(564, 436);
            dgvHistory.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            // ====== ucLeaveRequest ======
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(39, 39, 42);
            Controls.Add(pnlSummary);
            Controls.Add(pnlNewRequest);
            Controls.Add(pnlHistory);
            Name = "ucLeaveRequest";
            Size = new Size(1000, 665);
            pnlSummary.ResumeLayout(false);
            pnlSummary.PerformLayout();
            pnlNewRequest.ResumeLayout(false);
            pnlNewRequest.PerformLayout();
            pnlHistory.ResumeLayout(false);
            pnlHistory.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvHistory).EndInit();
            this.Load += UcLeaveRequest_Load;
            btnSubmit.Click += BtnSubmit_Click;
            btnReport.Click += BtnReport_Click;
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

        private Guna2Panel pnlSummary;
        private Label lblRemainingTitle;
        private Label lblRemainingValue;
        private Panel pnlDivider1;
        private Label lblPendingTitle;
        private Label lblPendingValue;
        private Guna2Button btnManager;
        private Guna2Button btnReport;
        private Guna2Panel pnlNewRequest;
        private Label lblNewRequestTitle;
        private Label lblFromDate;
        private Guna2DateTimePicker dtpFromDate;
        private Label lblToDate;
        private Guna2DateTimePicker dtpToDate;
        private Label lblReason;
        private Guna2TextBox txtReason;
        private Guna2Button btnSubmit;
        private Guna2Panel pnlHistory;
        private Label lblHistoryTitle;
        private Guna2DataGridView dgvHistory;
        private DataGridViewTextBoxColumn colFrom;
        private DataGridViewTextBoxColumn colTo;
        private DataGridViewTextBoxColumn colDays;
        private DataGridViewTextBoxColumn colReason;
        private DataGridViewTextBoxColumn colStatus;
    }
}
