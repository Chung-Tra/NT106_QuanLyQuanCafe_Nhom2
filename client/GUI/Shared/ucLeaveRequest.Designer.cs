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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlSummary = new System.Windows.Forms.Panel();
            this.lblRemainingValue = new System.Windows.Forms.Label();
            this.lblRemainingTitle = new System.Windows.Forms.Label();
            this.lblPendingValue = new System.Windows.Forms.Label();
            this.lblPendingTitle = new System.Windows.Forms.Label();
            this.pnlNewRequest = new System.Windows.Forms.Panel();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.txtReason = new System.Windows.Forms.TextBox();
            this.lblReason = new System.Windows.Forms.Label();
            this.dtpToDate = new System.Windows.Forms.DateTimePicker();
            this.lblToDate = new System.Windows.Forms.Label();
            this.dtpFromDate = new System.Windows.Forms.DateTimePicker();
            this.lblFromDate = new System.Windows.Forms.Label();
            this.lblNewRequestTitle = new System.Windows.Forms.Label();
            this.pnlHistory = new System.Windows.Forms.Panel();
            this.dgvHistory = new System.Windows.Forms.DataGridView();
            this.lblHistoryTitle = new System.Windows.Forms.Label();
            this.pnlSummary.SuspendLayout();
            this.pnlNewRequest.SuspendLayout();
            this.pnlHistory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistory)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlSummary
            // 
            this.pnlSummary.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.btnReport = new System.Windows.Forms.Button();
            this.pnlSummary.Controls.Add(this.lblRemainingValue);
            this.pnlSummary.Controls.Add(this.lblRemainingTitle);
            this.pnlSummary.Controls.Add(this.lblPendingValue);
            this.pnlSummary.Controls.Add(this.lblPendingTitle);
            this.pnlSummary.Controls.Add(this.btnReport);
            this.pnlSummary.Location = new System.Drawing.Point(20, 20);
            this.pnlSummary.Name = "pnlSummary";
            this.pnlSummary.Size = new System.Drawing.Size(764, 80);
            this.pnlSummary.TabIndex = 0;
            // 
            // lblRemainingValue
            // 
            this.lblRemainingValue.AutoSize = true;
            this.lblRemainingValue.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold);
            this.lblRemainingValue.ForeColor = System.Drawing.Color.MediumSeaGreen;
            this.lblRemainingValue.Location = new System.Drawing.Point(20, 35);
            this.lblRemainingValue.Name = "lblRemainingValue";
            this.lblRemainingValue.Size = new System.Drawing.Size(84, 30);
            this.lblRemainingValue.TabIndex = 0;
            this.lblRemainingValue.Text = "12 ngày";
            // 
            // lblRemainingTitle
            // 
            this.lblRemainingTitle.AutoSize = true;
            this.lblRemainingTitle.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lblRemainingTitle.ForeColor = System.Drawing.Color.Gray;
            this.lblRemainingTitle.Location = new System.Drawing.Point(20, 15);
            this.lblRemainingTitle.Name = "lblRemainingTitle";
            this.lblRemainingTitle.Size = new System.Drawing.Size(121, 17);
            this.lblRemainingTitle.TabIndex = 1;
            this.lblRemainingTitle.Text = "Ngày phép còn lại";
            // 
            // lblPendingValue
            // 
            this.lblPendingValue.AutoSize = true;
            this.lblPendingValue.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold);
            this.lblPendingValue.ForeColor = System.Drawing.Color.Orange;
            this.lblPendingValue.Location = new System.Drawing.Point(260, 35);
            this.lblPendingValue.Name = "lblPendingValue";
            this.lblPendingValue.Size = new System.Drawing.Size(68, 30);
            this.lblPendingValue.TabIndex = 2;
            this.lblPendingValue.Text = "2 đơn";
            // 
            // lblPendingTitle
            // 
            this.lblPendingTitle.AutoSize = true;
            this.lblPendingTitle.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lblPendingTitle.ForeColor = System.Drawing.Color.Gray;
            this.lblPendingTitle.Location = new System.Drawing.Point(260, 15);
            this.lblPendingTitle.Name = "lblPendingTitle";
            this.lblPendingTitle.Size = new System.Drawing.Size(113, 17);
            this.lblPendingTitle.TabIndex = 3;
            this.lblPendingTitle.Text = "Đang chờ duyệt";
            //
            // btnReport
            //
            this.btnReport.BackColor = System.Drawing.Color.FromArgb(70, 130, 180);
            this.btnReport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReport.FlatAppearance.BorderSize = 0;
            this.btnReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReport.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnReport.ForeColor = System.Drawing.Color.White;
            this.btnReport.Location = new System.Drawing.Point(620, 25);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(120, 32);
            this.btnReport.Text = "Báo cáo";
            //
            // pnlNewRequest
            // 
            this.pnlNewRequest.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.pnlNewRequest.Controls.Add(this.btnSubmit);
            this.pnlNewRequest.Controls.Add(this.txtReason);
            this.pnlNewRequest.Controls.Add(this.lblReason);
            this.pnlNewRequest.Controls.Add(this.dtpToDate);
            this.pnlNewRequest.Controls.Add(this.lblToDate);
            this.pnlNewRequest.Controls.Add(this.dtpFromDate);
            this.pnlNewRequest.Controls.Add(this.lblFromDate);
            this.pnlNewRequest.Controls.Add(this.lblNewRequestTitle);
            this.pnlNewRequest.Location = new System.Drawing.Point(20, 120);
            this.pnlNewRequest.Name = "pnlNewRequest";
            this.pnlNewRequest.Size = new System.Drawing.Size(300, 390);
            this.pnlNewRequest.TabIndex = 1;
            // 
            // btnSubmit
            // 
            this.btnSubmit.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnSubmit.FlatAppearance.BorderSize = 0;
            this.btnSubmit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSubmit.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSubmit.ForeColor = System.Drawing.Color.White;
            this.btnSubmit.Location = new System.Drawing.Point(20, 330);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(260, 40);
            this.btnSubmit.TabIndex = 7;
            this.btnSubmit.Text = "GỬI YÊU CẦU";
            this.btnSubmit.UseVisualStyleBackColor = false;
            // 
            // txtReason
            // 
            this.txtReason.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.txtReason.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtReason.ForeColor = System.Drawing.Color.White;
            this.txtReason.Location = new System.Drawing.Point(20, 190);
            this.txtReason.Multiline = true;
            this.txtReason.Name = "txtReason";
            this.txtReason.Size = new System.Drawing.Size(260, 120);
            this.txtReason.TabIndex = 6;
            // 
            // lblReason
            // 
            this.lblReason.AutoSize = true;
            this.lblReason.ForeColor = System.Drawing.Color.Gray;
            this.lblReason.Location = new System.Drawing.Point(20, 170);
            this.lblReason.Name = "lblReason";
            this.lblReason.Size = new System.Drawing.Size(73, 15);
            this.lblReason.TabIndex = 5;
            this.lblReason.Text = "Lý do nghỉ:";
            // 
            // dtpToDate
            // 
            this.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpToDate.Location = new System.Drawing.Point(20, 130);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.Size = new System.Drawing.Size(260, 23);
            this.dtpToDate.TabIndex = 4;
            // 
            // lblToDate
            // 
            this.lblToDate.AutoSize = true;
            this.lblToDate.ForeColor = System.Drawing.Color.Gray;
            this.lblToDate.Location = new System.Drawing.Point(20, 110);
            this.lblToDate.Name = "lblToDate";
            this.lblToDate.Size = new System.Drawing.Size(60, 15);
            this.lblToDate.TabIndex = 3;
            this.lblToDate.Text = "Đến ngày:";
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFromDate.Location = new System.Drawing.Point(20, 75);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.Size = new System.Drawing.Size(260, 23);
            this.dtpFromDate.TabIndex = 2;
            // 
            // lblFromDate
            // 
            this.lblFromDate.AutoSize = true;
            this.lblFromDate.ForeColor = System.Drawing.Color.Gray;
            this.lblFromDate.Location = new System.Drawing.Point(20, 55);
            this.lblFromDate.Name = "lblFromDate";
            this.lblFromDate.Size = new System.Drawing.Size(52, 15);
            this.lblFromDate.TabIndex = 1;
            this.lblFromDate.Text = "Từ ngày:";
            // 
            // lblNewRequestTitle
            // 
            this.lblNewRequestTitle.AutoSize = true;
            this.lblNewRequestTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblNewRequestTitle.ForeColor = System.Drawing.Color.White;
            this.lblNewRequestTitle.Location = new System.Drawing.Point(15, 15);
            this.lblNewRequestTitle.Name = "lblNewRequestTitle";
            this.lblNewRequestTitle.Size = new System.Drawing.Size(155, 21);
            this.lblNewRequestTitle.TabIndex = 0;
            this.lblNewRequestTitle.Text = "Tạo yêu cầu nghỉ";
            // 
            // pnlHistory
            // 
            this.pnlHistory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.pnlHistory.Controls.Add(this.dgvHistory);
            this.pnlHistory.Controls.Add(this.lblHistoryTitle);
            this.pnlHistory.Location = new System.Drawing.Point(340, 120);
            this.pnlHistory.Name = "pnlHistory";
            this.pnlHistory.Size = new System.Drawing.Size(444, 390);
            this.pnlHistory.TabIndex = 2;
            // 
            // dgvHistory
            // 
            this.dgvHistory.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.dgvHistory.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvHistory.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvHistory.Location = new System.Drawing.Point(15, 50);
            this.dgvHistory.Name = "dgvHistory";
            this.dgvHistory.Size = new System.Drawing.Size(414, 320);
            this.dgvHistory.TabIndex = 1;
            // 
            // lblHistoryTitle
            // 
            this.lblHistoryTitle.AutoSize = true;
            this.lblHistoryTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblHistoryTitle.ForeColor = System.Drawing.Color.White;
            this.lblHistoryTitle.Location = new System.Drawing.Point(15, 15);
            this.lblHistoryTitle.Name = "lblHistoryTitle";
            this.lblHistoryTitle.Size = new System.Drawing.Size(133, 21);
            this.lblHistoryTitle.TabIndex = 0;
            this.lblHistoryTitle.Text = "Lịch sử yêu cầu";
            // 
            // ucLeaveRequest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.Controls.Add(this.pnlHistory);
            this.Controls.Add(this.pnlNewRequest);
            this.Controls.Add(this.pnlSummary);
            this.Name = "ucLeaveRequest";
            this.Size = new System.Drawing.Size(804, 530);
            this.pnlSummary.ResumeLayout(false);
            this.pnlSummary.PerformLayout();
            this.pnlNewRequest.ResumeLayout(false);
            this.pnlNewRequest.PerformLayout();
            this.pnlHistory.ResumeLayout(false);
            this.pnlHistory.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistory)).EndInit();
            this.ResumeLayout(false);

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