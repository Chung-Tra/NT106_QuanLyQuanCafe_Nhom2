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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            pnlSummary = new Panel();
            btnManager = new Button();
            lblTotalShiftsValue = new Label();
            lblTotalShiftsTitle = new Label();
            lblTotalHoursValue = new Label();
            lblTotalHoursTitle = new Label();
            lblLateValue = new Label();
            lblLateTitle = new Label();
            lblAbsentValue = new Label();
            lblAbsentTitle = new Label();
            lblFilterTitle = new Label();
            dtpFilterMonth = new DateTimePicker();
            btnReport = new Button();
            pnlLog = new Panel();
            dgvWorkTracking = new DataGridView();
            lblLogTitle = new Label();
            pnlSummary.SuspendLayout();
            pnlLog.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvWorkTracking).BeginInit();
            SuspendLayout();
            // 
            // pnlSummary
            // 
            pnlSummary.BackColor = Color.FromArgb(30, 30, 30);
            pnlSummary.Controls.Add(btnManager);
            pnlSummary.Controls.Add(lblTotalShiftsValue);
            pnlSummary.Controls.Add(lblTotalShiftsTitle);
            pnlSummary.Controls.Add(lblTotalHoursValue);
            pnlSummary.Controls.Add(lblTotalHoursTitle);
            pnlSummary.Controls.Add(lblLateValue);
            pnlSummary.Controls.Add(lblLateTitle);
            pnlSummary.Controls.Add(lblAbsentValue);
            pnlSummary.Controls.Add(lblAbsentTitle);
            pnlSummary.Controls.Add(lblFilterTitle);
            pnlSummary.Controls.Add(dtpFilterMonth);
            pnlSummary.Controls.Add(btnReport);
            pnlSummary.Location = new Point(23, 20);
            pnlSummary.Margin = new Padding(3, 4, 3, 4);
            pnlSummary.Name = "pnlSummary";
            pnlSummary.Size = new Size(873, 133);
            pnlSummary.TabIndex = 1;
            // 
            // btnManager
            // 
            btnManager.BackColor = Color.FromArgb(70, 130, 180);
            btnManager.Cursor = Cursors.Hand;
            btnManager.FlatAppearance.BorderSize = 0;
            btnManager.FlatStyle = FlatStyle.Flat;
            btnManager.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnManager.ForeColor = Color.White;
            btnManager.Location = new Point(696, 73);
            btnManager.Margin = new Padding(3, 4, 3, 4);
            btnManager.Name = "btnManager";
            btnManager.Size = new Size(160, 47);
            btnManager.TabIndex = 11;
            btnManager.Text = "Quản lý";
            btnManager.UseVisualStyleBackColor = false;
            btnManager.Click += btnManager_Click;
            // 
            // lblTotalShiftsValue
            // 
            lblTotalShiftsValue.AutoSize = true;
            lblTotalShiftsValue.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTotalShiftsValue.ForeColor = Color.MediumSeaGreen;
            lblTotalShiftsValue.Location = new Point(17, 47);
            lblTotalShiftsValue.Name = "lblTotalShiftsValue";
            lblTotalShiftsValue.Size = new Size(90, 41);
            lblTotalShiftsValue.TabIndex = 0;
            lblTotalShiftsValue.Text = "22 ca";
            // 
            // lblTotalShiftsTitle
            // 
            lblTotalShiftsTitle.AutoSize = true;
            lblTotalShiftsTitle.Font = new Font("Segoe UI", 9F);
            lblTotalShiftsTitle.ForeColor = Color.Gray;
            lblTotalShiftsTitle.Location = new Point(17, 16);
            lblTotalShiftsTitle.Name = "lblTotalShiftsTitle";
            lblTotalShiftsTitle.Size = new Size(62, 20);
            lblTotalShiftsTitle.TabIndex = 1;
            lblTotalShiftsTitle.Text = "Tổng ca";
            // 
            // lblTotalHoursValue
            // 
            lblTotalHoursValue.AutoSize = true;
            lblTotalHoursValue.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTotalHoursValue.ForeColor = Color.Orange;
            lblTotalHoursValue.Location = new Point(171, 47);
            lblTotalHoursValue.Name = "lblTotalHoursValue";
            lblTotalHoursValue.Size = new Size(87, 41);
            lblTotalHoursValue.TabIndex = 2;
            lblTotalHoursValue.Text = "176h";
            // 
            // lblTotalHoursTitle
            // 
            lblTotalHoursTitle.AutoSize = true;
            lblTotalHoursTitle.Font = new Font("Segoe UI", 9F);
            lblTotalHoursTitle.ForeColor = Color.Gray;
            lblTotalHoursTitle.Location = new Point(171, 16);
            lblTotalHoursTitle.Name = "lblTotalHoursTitle";
            lblTotalHoursTitle.Size = new Size(69, 20);
            lblTotalHoursTitle.TabIndex = 3;
            lblTotalHoursTitle.Text = "Tổng giờ";
            // 
            // lblLateValue
            // 
            lblLateValue.AutoSize = true;
            lblLateValue.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblLateValue.ForeColor = Color.IndianRed;
            lblLateValue.Location = new Point(331, 47);
            lblLateValue.Name = "lblLateValue";
            lblLateValue.Size = new Size(86, 41);
            lblLateValue.TabIndex = 4;
            lblLateValue.Text = "2 lần";
            // 
            // lblLateTitle
            // 
            lblLateTitle.AutoSize = true;
            lblLateTitle.Font = new Font("Segoe UI", 9F);
            lblLateTitle.ForeColor = Color.Gray;
            lblLateTitle.Location = new Point(331, 16);
            lblLateTitle.Name = "lblLateTitle";
            lblLateTitle.Size = new Size(66, 20);
            lblLateTitle.TabIndex = 5;
            lblLateTitle.Text = "Đi muộn";
            // 
            // lblAbsentValue
            // 
            lblAbsentValue.AutoSize = true;
            lblAbsentValue.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblAbsentValue.ForeColor = Color.SteelBlue;
            lblAbsentValue.Location = new Point(480, 47);
            lblAbsentValue.Name = "lblAbsentValue";
            lblAbsentValue.Size = new Size(112, 41);
            lblAbsentValue.TabIndex = 6;
            lblAbsentValue.Text = "1 ngày";
            // 
            // lblAbsentTitle
            // 
            lblAbsentTitle.AutoSize = true;
            lblAbsentTitle.Font = new Font("Segoe UI", 9F);
            lblAbsentTitle.ForeColor = Color.Gray;
            lblAbsentTitle.Location = new Point(480, 16);
            lblAbsentTitle.Name = "lblAbsentTitle";
            lblAbsentTitle.Size = new Size(79, 20);
            lblAbsentTitle.TabIndex = 7;
            lblAbsentTitle.Text = "Nghỉ phép";
            // 
            // lblFilterTitle
            // 
            lblFilterTitle.AutoSize = true;
            lblFilterTitle.Font = new Font("Segoe UI", 9.5F);
            lblFilterTitle.ForeColor = Color.White;
            lblFilterTitle.Location = new Point(17, 96);
            lblFilterTitle.Name = "lblFilterTitle";
            lblFilterTitle.Size = new Size(56, 21);
            lblFilterTitle.TabIndex = 8;
            lblFilterTitle.Text = "Tháng:";
            // 
            // dtpFilterMonth
            // 
            dtpFilterMonth.CustomFormat = "MM/yyyy";
            dtpFilterMonth.Font = new Font("Segoe UI", 9.5F);
            dtpFilterMonth.Format = DateTimePickerFormat.Custom;
            dtpFilterMonth.Location = new Point(74, 91);
            dtpFilterMonth.Margin = new Padding(3, 4, 3, 4);
            dtpFilterMonth.Name = "dtpFilterMonth";
            dtpFilterMonth.ShowUpDown = true;
            dtpFilterMonth.Size = new Size(148, 29);
            dtpFilterMonth.TabIndex = 9;
            // 
            // btnReport
            // 
            btnReport.BackColor = Color.FromArgb(70, 130, 180);
            btnReport.Cursor = Cursors.Hand;
            btnReport.FlatAppearance.BorderSize = 0;
            btnReport.FlatStyle = FlatStyle.Flat;
            btnReport.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnReport.ForeColor = Color.White;
            btnReport.Location = new Point(696, 16);
            btnReport.Margin = new Padding(3, 4, 3, 4);
            btnReport.Name = "btnReport";
            btnReport.Size = new Size(160, 47);
            btnReport.TabIndex = 10;
            btnReport.Text = "Báo cáo";
            btnReport.UseVisualStyleBackColor = false;
            // 
            // pnlLog
            // 
            pnlLog.BackColor = Color.FromArgb(30, 30, 30);
            pnlLog.Controls.Add(dgvWorkTracking);
            pnlLog.Controls.Add(lblLogTitle);
            pnlLog.Location = new Point(23, 167);
            pnlLog.Margin = new Padding(3, 4, 3, 4);
            pnlLog.Name = "pnlLog";
            pnlLog.Size = new Size(873, 520);
            pnlLog.TabIndex = 0;
            // 
            // dgvWorkTracking
            // 
            dgvWorkTracking.AllowUserToAddRows = false;
            dgvWorkTracking.BackgroundColor = Color.FromArgb(45, 45, 48);
            dgvWorkTracking.BorderStyle = BorderStyle.None;
            dgvWorkTracking.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(45, 45, 48);
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9.5F);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(60, 60, 65);
            dataGridViewCellStyle1.SelectionForeColor = Color.White;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
            dgvWorkTracking.DefaultCellStyle = dataGridViewCellStyle1;
            dgvWorkTracking.Location = new Point(17, 56);
            dgvWorkTracking.Margin = new Padding(3, 4, 3, 4);
            dgvWorkTracking.Name = "dgvWorkTracking";
            dgvWorkTracking.ReadOnly = true;
            dgvWorkTracking.RowHeadersVisible = false;
            dgvWorkTracking.RowHeadersWidth = 51;
            dgvWorkTracking.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvWorkTracking.Size = new Size(839, 447);
            dgvWorkTracking.TabIndex = 0;
            // 
            // lblLogTitle
            // 
            lblLogTitle.AutoSize = true;
            lblLogTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblLogTitle.ForeColor = Color.White;
            lblLogTitle.Location = new Point(17, 16);
            lblLogTitle.Name = "lblLogTitle";
            lblLogTitle.Size = new Size(187, 28);
            lblLogTitle.TabIndex = 1;
            lblLogTitle.Text = "Lịch sử chấm công";
            // 
            // ucWorkTracking
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(45, 45, 48);
            Controls.Add(pnlLog);
            Controls.Add(pnlSummary);
            Margin = new Padding(3, 4, 3, 4);
            Name = "ucWorkTracking";
            Size = new Size(919, 707);
            pnlSummary.ResumeLayout(false);
            pnlSummary.PerformLayout();
            pnlLog.ResumeLayout(false);
            pnlLog.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvWorkTracking).EndInit();
            ResumeLayout(false);
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
        private Button btnManager;
    }
}
