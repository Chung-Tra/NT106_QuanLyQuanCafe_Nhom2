namespace GUI
{
    partial class ucLeaveRequest
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            pnlSummary = new Panel();
            lblRemainingValue = new Label();
            lblRemainingTitle = new Label();
            lblPendingValue = new Label();
            lblPendingTitle = new Label();
            btnReport = new Button();
            pnlNewRequest = new Panel();
            btnSubmit = new Button();
            txtReason = new TextBox();
            lblReason = new Label();
            dtpToDate = new DateTimePicker();
            lblToDate = new Label();
            dtpFromDate = new DateTimePicker();
            lblFromDate = new Label();
            lblNewRequestTitle = new Label();
            pnlHistory = new Panel();
            dgvHistory = new DataGridView();
            lblHistoryTitle = new Label();
            pnlSummary.SuspendLayout();
            pnlNewRequest.SuspendLayout();
            pnlHistory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvHistory).BeginInit();
            SuspendLayout();
            // 
            // pnlSummary
            // 
            pnlSummary.BackColor = Color.FromArgb(30, 30, 30);
            pnlSummary.Controls.Add(lblRemainingValue);
            pnlSummary.Controls.Add(lblRemainingTitle);
            pnlSummary.Controls.Add(lblPendingValue);
            pnlSummary.Controls.Add(lblPendingTitle);
            pnlSummary.Controls.Add(btnReport);
            pnlSummary.Location = new Point(23, 27);
            pnlSummary.Margin = new Padding(3, 4, 3, 4);
            pnlSummary.Name = "pnlSummary";
            pnlSummary.Size = new Size(873, 107);
            pnlSummary.TabIndex = 0;
            // 
            // lblRemainingValue
            // 
            lblRemainingValue.AutoSize = true;
            lblRemainingValue.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold);
            lblRemainingValue.ForeColor = Color.MediumSeaGreen;
            lblRemainingValue.Location = new Point(23, 47);
            lblRemainingValue.Name = "lblRemainingValue";
            lblRemainingValue.Size = new Size(119, 37);
            lblRemainingValue.TabIndex = 0;
            lblRemainingValue.Text = "12 ngày";
            // 
            // lblRemainingTitle
            // 
            lblRemainingTitle.AutoSize = true;
            lblRemainingTitle.Font = new Font("Segoe UI", 9.75F);
            lblRemainingTitle.ForeColor = Color.Gray;
            lblRemainingTitle.Location = new Point(23, 20);
            lblRemainingTitle.Name = "lblRemainingTitle";
            lblRemainingTitle.Size = new Size(149, 23);
            lblRemainingTitle.TabIndex = 1;
            lblRemainingTitle.Text = "Ngày phép còn lại";
            // 
            // lblPendingValue
            // 
            lblPendingValue.AutoSize = true;
            lblPendingValue.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold);
            lblPendingValue.ForeColor = Color.Orange;
            lblPendingValue.Location = new Point(297, 47);
            lblPendingValue.Name = "lblPendingValue";
            lblPendingValue.Size = new Size(90, 37);
            lblPendingValue.TabIndex = 2;
            lblPendingValue.Text = "2 đơn";
            // 
            // lblPendingTitle
            // 
            lblPendingTitle.AutoSize = true;
            lblPendingTitle.Font = new Font("Segoe UI", 9.75F);
            lblPendingTitle.ForeColor = Color.Gray;
            lblPendingTitle.Location = new Point(297, 20);
            lblPendingTitle.Name = "lblPendingTitle";
            lblPendingTitle.Size = new Size(132, 23);
            lblPendingTitle.TabIndex = 3;
            lblPendingTitle.Text = "Đang chờ duyệt";
            // 
            // btnReport
            // 
            btnReport.BackColor = Color.FromArgb(70, 130, 180);
            btnReport.Cursor = Cursors.Hand;
            btnReport.FlatAppearance.BorderSize = 0;
            btnReport.FlatStyle = FlatStyle.Flat;
            btnReport.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnReport.ForeColor = Color.White;
            btnReport.Location = new Point(709, 33);
            btnReport.Margin = new Padding(3, 4, 3, 4);
            btnReport.Name = "btnReport";
            btnReport.Size = new Size(137, 43);
            btnReport.TabIndex = 4;
            btnReport.Text = "Báo cáo";
            btnReport.UseVisualStyleBackColor = false;
            // 
            // pnlNewRequest
            // 
            pnlNewRequest.BackColor = Color.FromArgb(30, 30, 30);
            pnlNewRequest.Controls.Add(btnSubmit);
            pnlNewRequest.Controls.Add(txtReason);
            pnlNewRequest.Controls.Add(lblReason);
            pnlNewRequest.Controls.Add(dtpToDate);
            pnlNewRequest.Controls.Add(lblToDate);
            pnlNewRequest.Controls.Add(dtpFromDate);
            pnlNewRequest.Controls.Add(lblFromDate);
            pnlNewRequest.Controls.Add(lblNewRequestTitle);
            pnlNewRequest.Location = new Point(23, 160);
            pnlNewRequest.Margin = new Padding(3, 4, 3, 4);
            pnlNewRequest.Name = "pnlNewRequest";
            pnlNewRequest.Size = new Size(343, 520);
            pnlNewRequest.TabIndex = 1;
            // 
            // btnSubmit
            // 
            btnSubmit.BackColor = Color.MediumSeaGreen;
            btnSubmit.FlatAppearance.BorderSize = 0;
            btnSubmit.FlatStyle = FlatStyle.Flat;
            btnSubmit.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnSubmit.ForeColor = Color.White;
            btnSubmit.Location = new Point(23, 440);
            btnSubmit.Margin = new Padding(3, 4, 3, 4);
            btnSubmit.Name = "btnSubmit";
            btnSubmit.Size = new Size(297, 53);
            btnSubmit.TabIndex = 7;
            btnSubmit.Text = "GỬI YÊU CẦU";
            btnSubmit.UseVisualStyleBackColor = false;
            // 
            // txtReason
            // 
            txtReason.BackColor = Color.FromArgb(45, 45, 48);
            txtReason.BorderStyle = BorderStyle.None;
            txtReason.ForeColor = Color.White;
            txtReason.Location = new Point(23, 253);
            txtReason.Margin = new Padding(3, 4, 3, 4);
            txtReason.Multiline = true;
            txtReason.Name = "txtReason";
            txtReason.Size = new Size(297, 160);
            txtReason.TabIndex = 6;
            // 
            // lblReason
            // 
            lblReason.AutoSize = true;
            lblReason.ForeColor = Color.Gray;
            lblReason.Location = new Point(23, 227);
            lblReason.Name = "lblReason";
            lblReason.Size = new Size(80, 20);
            lblReason.TabIndex = 5;
            lblReason.Text = "Lý do nghỉ:";
            // 
            // dtpToDate
            // 
            dtpToDate.Format = DateTimePickerFormat.Short;
            dtpToDate.Location = new Point(23, 173);
            dtpToDate.Margin = new Padding(3, 4, 3, 4);
            dtpToDate.Name = "dtpToDate";
            dtpToDate.Size = new Size(297, 27);
            dtpToDate.TabIndex = 4;
            // 
            // lblToDate
            // 
            lblToDate.AutoSize = true;
            lblToDate.ForeColor = Color.Gray;
            lblToDate.Location = new Point(23, 147);
            lblToDate.Name = "lblToDate";
            lblToDate.Size = new Size(75, 20);
            lblToDate.TabIndex = 3;
            lblToDate.Text = "Đến ngày:";
            // 
            // dtpFromDate
            // 
            dtpFromDate.Format = DateTimePickerFormat.Short;
            dtpFromDate.Location = new Point(23, 100);
            dtpFromDate.Margin = new Padding(3, 4, 3, 4);
            dtpFromDate.Name = "dtpFromDate";
            dtpFromDate.Size = new Size(297, 27);
            dtpFromDate.TabIndex = 2;
            // 
            // lblFromDate
            // 
            lblFromDate.AutoSize = true;
            lblFromDate.ForeColor = Color.Gray;
            lblFromDate.Location = new Point(23, 73);
            lblFromDate.Name = "lblFromDate";
            lblFromDate.Size = new Size(65, 20);
            lblFromDate.TabIndex = 1;
            lblFromDate.Text = "Từ ngày:";
            // 
            // lblNewRequestTitle
            // 
            lblNewRequestTitle.AutoSize = true;
            lblNewRequestTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblNewRequestTitle.ForeColor = Color.White;
            lblNewRequestTitle.Location = new Point(17, 20);
            lblNewRequestTitle.Name = "lblNewRequestTitle";
            lblNewRequestTitle.Size = new Size(174, 28);
            lblNewRequestTitle.TabIndex = 0;
            lblNewRequestTitle.Text = "Tạo yêu cầu nghỉ";
            // 
            // pnlHistory
            // 
            pnlHistory.BackColor = Color.FromArgb(30, 30, 30);
            pnlHistory.Controls.Add(dgvHistory);
            pnlHistory.Controls.Add(lblHistoryTitle);
            pnlHistory.Location = new Point(389, 160);
            pnlHistory.Margin = new Padding(3, 4, 3, 4);
            pnlHistory.Name = "pnlHistory";
            pnlHistory.Size = new Size(507, 520);
            pnlHistory.TabIndex = 2;
            // 
            // dgvHistory
            // 
            dgvHistory.BackgroundColor = Color.FromArgb(45, 45, 48);
            dgvHistory.BorderStyle = BorderStyle.None;
            dgvHistory.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(45, 45, 48);
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = Color.Gray;
            dataGridViewCellStyle1.SelectionForeColor = Color.White;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
            dgvHistory.DefaultCellStyle = dataGridViewCellStyle1;
            dgvHistory.Location = new Point(17, 67);
            dgvHistory.Margin = new Padding(3, 4, 3, 4);
            dgvHistory.Name = "dgvHistory";
            dgvHistory.RowHeadersWidth = 51;
            dgvHistory.Size = new Size(473, 427);
            dgvHistory.TabIndex = 1;
            // 
            // lblHistoryTitle
            // 
            lblHistoryTitle.AutoSize = true;
            lblHistoryTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblHistoryTitle.ForeColor = Color.White;
            lblHistoryTitle.Location = new Point(17, 20);
            lblHistoryTitle.Name = "lblHistoryTitle";
            lblHistoryTitle.Size = new Size(157, 28);
            lblHistoryTitle.TabIndex = 0;
            lblHistoryTitle.Text = "Lịch sử yêu cầu";
            // 
            // ucLeaveRequest
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(45, 45, 48);
            Controls.Add(pnlHistory);
            Controls.Add(pnlNewRequest);
            Controls.Add(pnlSummary);
            Margin = new Padding(3, 4, 3, 4);
            Name = "ucLeaveRequest";
            Size = new Size(919, 707);
            pnlSummary.ResumeLayout(false);
            pnlSummary.PerformLayout();
            pnlNewRequest.ResumeLayout(false);
            pnlNewRequest.PerformLayout();
            pnlHistory.ResumeLayout(false);
            pnlHistory.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvHistory).EndInit();
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlSummary;
        private System.Windows.Forms.Label lblRemainingTitle;
        private System.Windows.Forms.Label lblRemainingValue;
        private System.Windows.Forms.Label lblPendingTitle;
        private System.Windows.Forms.Label lblPendingValue;
        private System.Windows.Forms.Panel pnlNewRequest;
        private System.Windows.Forms.Label lblNewRequestTitle;
        private System.Windows.Forms.Label lblFromDate;
        private System.Windows.Forms.DateTimePicker dtpFromDate;
        private System.Windows.Forms.Label lblToDate;
        private System.Windows.Forms.DateTimePicker dtpToDate;
        private System.Windows.Forms.Label lblReason;
        private System.Windows.Forms.TextBox txtReason;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Panel pnlHistory;
        private System.Windows.Forms.Label lblHistoryTitle;
        private System.Windows.Forms.DataGridView dgvHistory;
        private System.Windows.Forms.Button btnReport;
    }
}