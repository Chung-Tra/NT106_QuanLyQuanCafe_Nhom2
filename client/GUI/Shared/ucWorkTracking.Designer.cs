namespace GUI
{
    partial class ucWorkTracking
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlSummary = new System.Windows.Forms.Panel();
            this.lblTotalShiftsValue = new System.Windows.Forms.Label();
            this.lblTotalShiftsTitle = new System.Windows.Forms.Label();
            this.lblTotalHoursValue = new System.Windows.Forms.Label();
            this.lblTotalHoursTitle = new System.Windows.Forms.Label();
            this.lblLateValue = new System.Windows.Forms.Label();
            this.lblLateTitle = new System.Windows.Forms.Label();
            this.lblAbsentValue = new System.Windows.Forms.Label();
            this.lblAbsentTitle = new System.Windows.Forms.Label();
            this.lblFilterTitle = new System.Windows.Forms.Label();
            this.dtpFilterMonth = new System.Windows.Forms.DateTimePicker();
            this.pnlLog = new System.Windows.Forms.Panel();
            this.dgvWorkTracking = new System.Windows.Forms.DataGridView();
            this.lblLogTitle = new System.Windows.Forms.Label();
            this.btnReport = new System.Windows.Forms.Button();
            this.pnlSummary.SuspendLayout();
            this.pnlLog.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWorkTracking)).BeginInit();
            this.SuspendLayout();
            //
            // pnlSummary
            //
            this.pnlSummary.BackColor = System.Drawing.Color.FromArgb(30, 30, 30);
            this.pnlSummary.Controls.Add(this.lblTotalShiftsValue);
            this.pnlSummary.Controls.Add(this.lblTotalShiftsTitle);
            this.pnlSummary.Controls.Add(this.lblTotalHoursValue);
            this.pnlSummary.Controls.Add(this.lblTotalHoursTitle);
            this.pnlSummary.Controls.Add(this.lblLateValue);
            this.pnlSummary.Controls.Add(this.lblLateTitle);
            this.pnlSummary.Controls.Add(this.lblAbsentValue);
            this.pnlSummary.Controls.Add(this.lblAbsentTitle);
            this.pnlSummary.Controls.Add(this.lblFilterTitle);
            this.pnlSummary.Controls.Add(this.dtpFilterMonth);
            this.pnlSummary.Controls.Add(this.btnReport);
            this.pnlSummary.Location = new System.Drawing.Point(20, 15);
            this.pnlSummary.Name = "pnlSummary";
            this.pnlSummary.Size = new System.Drawing.Size(764, 100);
            //
            // lblTotalShiftsTitle
            //
            this.lblTotalShiftsTitle.AutoSize = true;
            this.lblTotalShiftsTitle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTotalShiftsTitle.ForeColor = System.Drawing.Color.Gray;
            this.lblTotalShiftsTitle.Location = new System.Drawing.Point(15, 12);
            this.lblTotalShiftsTitle.Name = "lblTotalShiftsTitle";
            this.lblTotalShiftsTitle.Text = "Tổng ca";
            //
            // lblTotalShiftsValue
            //
            this.lblTotalShiftsValue.AutoSize = true;
            this.lblTotalShiftsValue.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTotalShiftsValue.ForeColor = System.Drawing.Color.MediumSeaGreen;
            this.lblTotalShiftsValue.Location = new System.Drawing.Point(15, 35);
            this.lblTotalShiftsValue.Name = "lblTotalShiftsValue";
            this.lblTotalShiftsValue.Text = "22 ca";
            //
            // lblTotalHoursTitle
            //
            this.lblTotalHoursTitle.AutoSize = true;
            this.lblTotalHoursTitle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTotalHoursTitle.ForeColor = System.Drawing.Color.Gray;
            this.lblTotalHoursTitle.Location = new System.Drawing.Point(150, 12);
            this.lblTotalHoursTitle.Name = "lblTotalHoursTitle";
            this.lblTotalHoursTitle.Text = "Tổng giờ";
            //
            // lblTotalHoursValue
            //
            this.lblTotalHoursValue.AutoSize = true;
            this.lblTotalHoursValue.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTotalHoursValue.ForeColor = System.Drawing.Color.Orange;
            this.lblTotalHoursValue.Location = new System.Drawing.Point(150, 35);
            this.lblTotalHoursValue.Name = "lblTotalHoursValue";
            this.lblTotalHoursValue.Text = "176h";
            //
            // lblLateTitle
            //
            this.lblLateTitle.AutoSize = true;
            this.lblLateTitle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblLateTitle.ForeColor = System.Drawing.Color.Gray;
            this.lblLateTitle.Location = new System.Drawing.Point(290, 12);
            this.lblLateTitle.Name = "lblLateTitle";
            this.lblLateTitle.Text = "Đi muộn";
            //
            // lblLateValue
            //
            this.lblLateValue.AutoSize = true;
            this.lblLateValue.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblLateValue.ForeColor = System.Drawing.Color.IndianRed;
            this.lblLateValue.Location = new System.Drawing.Point(290, 35);
            this.lblLateValue.Name = "lblLateValue";
            this.lblLateValue.Text = "2 lần";
            //
            // lblAbsentTitle
            //
            this.lblAbsentTitle.AutoSize = true;
            this.lblAbsentTitle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblAbsentTitle.ForeColor = System.Drawing.Color.Gray;
            this.lblAbsentTitle.Location = new System.Drawing.Point(420, 12);
            this.lblAbsentTitle.Name = "lblAbsentTitle";
            this.lblAbsentTitle.Text = "Nghỉ phép";
            //
            // lblAbsentValue
            //
            this.lblAbsentValue.AutoSize = true;
            this.lblAbsentValue.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblAbsentValue.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblAbsentValue.Location = new System.Drawing.Point(420, 35);
            this.lblAbsentValue.Name = "lblAbsentValue";
            this.lblAbsentValue.Text = "1 ngày";
            //
            // lblFilterTitle
            //
            this.lblFilterTitle.AutoSize = true;
            this.lblFilterTitle.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblFilterTitle.ForeColor = System.Drawing.Color.White;
            this.lblFilterTitle.Location = new System.Drawing.Point(15, 72);
            this.lblFilterTitle.Name = "lblFilterTitle";
            this.lblFilterTitle.Text = "Tháng:";
            //
            // dtpFilterMonth
            //
            this.dtpFilterMonth.CustomFormat = "MM/yyyy";
            this.dtpFilterMonth.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.dtpFilterMonth.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFilterMonth.Location = new System.Drawing.Point(65, 68);
            this.dtpFilterMonth.Name = "dtpFilterMonth";
            this.dtpFilterMonth.ShowUpDown = true;
            this.dtpFilterMonth.Size = new System.Drawing.Size(130, 25);
            //
            // btnReport
            //
            this.btnReport.BackColor = System.Drawing.Color.FromArgb(70, 130, 180);
            this.btnReport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReport.FlatAppearance.BorderSize = 0;
            this.btnReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReport.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnReport.ForeColor = System.Drawing.Color.White;
            this.btnReport.Location = new System.Drawing.Point(610, 15);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(140, 35);
            this.btnReport.Text = "Báo cáo";
            //
            // pnlLog
            //
            this.pnlLog.BackColor = System.Drawing.Color.FromArgb(30, 30, 30);
            this.pnlLog.Controls.Add(this.dgvWorkTracking);
            this.pnlLog.Controls.Add(this.lblLogTitle);
            this.pnlLog.Location = new System.Drawing.Point(20, 125);
            this.pnlLog.Name = "pnlLog";
            this.pnlLog.Size = new System.Drawing.Size(764, 390);
            //
            // lblLogTitle
            //
            this.lblLogTitle.AutoSize = true;
            this.lblLogTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblLogTitle.ForeColor = System.Drawing.Color.White;
            this.lblLogTitle.Location = new System.Drawing.Point(15, 12);
            this.lblLogTitle.Name = "lblLogTitle";
            this.lblLogTitle.Text = "Lịch sử chấm công";
            //
            // dgvWorkTracking
            //
            this.dgvWorkTracking.BackgroundColor = System.Drawing.Color.FromArgb(45, 45, 48);
            this.dgvWorkTracking.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvWorkTracking.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(45, 45, 48);
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(60, 60, 65);
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            this.dgvWorkTracking.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvWorkTracking.Location = new System.Drawing.Point(15, 42);
            this.dgvWorkTracking.Name = "dgvWorkTracking";
            this.dgvWorkTracking.ReadOnly = true;
            this.dgvWorkTracking.RowHeadersVisible = false;
            this.dgvWorkTracking.AllowUserToAddRows = false;
            this.dgvWorkTracking.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvWorkTracking.Size = new System.Drawing.Size(734, 335);
            //
            // ucWorkTracking
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(45, 45, 48);
            this.Controls.Add(this.pnlLog);
            this.Controls.Add(this.pnlSummary);
            this.Name = "ucWorkTracking";
            this.Size = new System.Drawing.Size(804, 530);
            this.pnlSummary.ResumeLayout(false);
            this.pnlSummary.PerformLayout();
            this.pnlLog.ResumeLayout(false);
            this.pnlLog.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWorkTracking)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlSummary;
        private System.Windows.Forms.Label lblTotalShiftsTitle;
        private System.Windows.Forms.Label lblTotalShiftsValue;
        private System.Windows.Forms.Label lblTotalHoursTitle;
        private System.Windows.Forms.Label lblTotalHoursValue;
        private System.Windows.Forms.Label lblLateTitle;
        private System.Windows.Forms.Label lblLateValue;
        private System.Windows.Forms.Label lblAbsentTitle;
        private System.Windows.Forms.Label lblAbsentValue;
        private System.Windows.Forms.Label lblFilterTitle;
        private System.Windows.Forms.DateTimePicker dtpFilterMonth;
        private System.Windows.Forms.Button btnReport;
        private System.Windows.Forms.Panel pnlLog;
        private System.Windows.Forms.Label lblLogTitle;
        private System.Windows.Forms.DataGridView dgvWorkTracking;
    }
}
