using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;

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
            pnlSummary = new Guna2Panel();
            lblTotalShiftsTitle = new Label();
            lblTotalShiftsValue = new Label();
            lblTotalHoursTitle = new Label();
            lblTotalHoursValue = new Label();
            lblLateTitle = new Label();
            lblLateValue = new Label();
            lblAbsentTitle = new Label();
            lblAbsentValue = new Label();
            lblFilterTitle = new Label();
            dtpFilterMonth = new Guna2DateTimePicker();
            btnReport = new Guna2Button();
            pnlLog = new Guna2Panel();
            lblLogTitle = new Label();
            dgvWorkTracking = new Guna2DataGridView();
            pnlSummary.SuspendLayout();
            pnlLog.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvWorkTracking).BeginInit();
            SuspendLayout();

            // ====== pnlSummary ======
            pnlSummary.BackColor = Color.FromArgb(31, 31, 34);
            pnlSummary.BorderRadius = 14;
            pnlSummary.Controls.Add(lblTotalShiftsTitle);
            pnlSummary.Controls.Add(lblTotalShiftsValue);
            pnlSummary.Controls.Add(lblTotalHoursTitle);
            pnlSummary.Controls.Add(lblTotalHoursValue);
            pnlSummary.Controls.Add(lblLateTitle);
            pnlSummary.Controls.Add(lblLateValue);
            pnlSummary.Controls.Add(lblAbsentTitle);
            pnlSummary.Controls.Add(lblAbsentValue);
            pnlSummary.Controls.Add(lblFilterTitle);
            pnlSummary.Controls.Add(dtpFilterMonth);
            pnlSummary.Controls.Add(btnReport);
            pnlSummary.Location = new Point(20, 20);
            pnlSummary.Size = new Size(900, 130);

            lblTotalShiftsTitle.AutoSize = true;
            lblTotalShiftsTitle.Font = new Font("Segoe UI", 9F);
            lblTotalShiftsTitle.ForeColor = Color.FromArgb(160, 160, 166);
            lblTotalShiftsTitle.Location = new Point(20, 14);
            lblTotalShiftsTitle.Text = "Tổng ca";

            lblTotalShiftsValue.AutoSize = true;
            lblTotalShiftsValue.Font = new Font("Segoe UI", 17F, FontStyle.Bold);
            lblTotalShiftsValue.ForeColor = Color.FromArgb(34, 197, 94);
            lblTotalShiftsValue.Location = new Point(20, 36);
            lblTotalShiftsValue.Text = "22 ca";

            lblTotalHoursTitle.AutoSize = true;
            lblTotalHoursTitle.Font = new Font("Segoe UI", 9F);
            lblTotalHoursTitle.ForeColor = Color.FromArgb(160, 160, 166);
            lblTotalHoursTitle.Location = new Point(170, 14);
            lblTotalHoursTitle.Text = "Tổng giờ";

            lblTotalHoursValue.AutoSize = true;
            lblTotalHoursValue.Font = new Font("Segoe UI", 17F, FontStyle.Bold);
            lblTotalHoursValue.ForeColor = Color.FromArgb(245, 158, 11);
            lblTotalHoursValue.Location = new Point(170, 36);
            lblTotalHoursValue.Text = "176h";

            lblLateTitle.AutoSize = true;
            lblLateTitle.Font = new Font("Segoe UI", 9F);
            lblLateTitle.ForeColor = Color.FromArgb(160, 160, 166);
            lblLateTitle.Location = new Point(330, 14);
            lblLateTitle.Text = "Đi muộn";

            lblLateValue.AutoSize = true;
            lblLateValue.Font = new Font("Segoe UI", 17F, FontStyle.Bold);
            lblLateValue.ForeColor = Color.FromArgb(220, 80, 80);
            lblLateValue.Location = new Point(330, 36);
            lblLateValue.Text = "2 lần";

            lblAbsentTitle.AutoSize = true;
            lblAbsentTitle.Font = new Font("Segoe UI", 9F);
            lblAbsentTitle.ForeColor = Color.FromArgb(160, 160, 166);
            lblAbsentTitle.Location = new Point(480, 14);
            lblAbsentTitle.Text = "Nghỉ phép";

            lblAbsentValue.AutoSize = true;
            lblAbsentValue.Font = new Font("Segoe UI", 17F, FontStyle.Bold);
            lblAbsentValue.ForeColor = Color.FromArgb(31, 138, 154);
            lblAbsentValue.Location = new Point(480, 36);
            lblAbsentValue.Text = "1 ngày";

            lblFilterTitle.AutoSize = true;
            lblFilterTitle.Font = new Font("Segoe UI", 9.5F);
            lblFilterTitle.ForeColor = Color.FromArgb(160, 160, 166);
            lblFilterTitle.Location = new Point(20, 92);
            lblFilterTitle.Text = "Tháng:";

            dtpFilterMonth.BorderColor = Color.FromArgb(63, 63, 70);
            dtpFilterMonth.BorderRadius = 10;
            dtpFilterMonth.CustomFormat = "MM/yyyy";
            dtpFilterMonth.FillColor = Color.FromArgb(30, 30, 33);
            dtpFilterMonth.Font = new Font("Segoe UI", 9.5F);
            dtpFilterMonth.ForeColor = Color.White;
            dtpFilterMonth.Format = DateTimePickerFormat.Custom;
            dtpFilterMonth.Location = new Point(72, 86);
            dtpFilterMonth.ShowUpDown = true;
            dtpFilterMonth.Size = new Size(160, 32);

            btnReport.BorderRadius = 10;
            btnReport.Cursor = Cursors.Hand;
            btnReport.FillColor = Color.FromArgb(31, 138, 154);
            btnReport.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnReport.ForeColor = Color.White;
            btnReport.HoverState.FillColor = Color.FromArgb(45, 158, 174);
            btnReport.Location = new Point(740, 86);
            btnReport.Size = new Size(140, 36);
            btnReport.Text = "📊 Báo cáo";

            // ====== pnlLog ======
            pnlLog.BackColor = Color.FromArgb(31, 31, 34);
            pnlLog.BorderRadius = 14;
            pnlLog.Controls.Add(lblLogTitle);
            pnlLog.Controls.Add(dgvWorkTracking);
            pnlLog.Location = new Point(20, 165);
            pnlLog.Size = new Size(900, 475);

            lblLogTitle.AutoSize = true;
            lblLogTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblLogTitle.ForeColor = Color.White;
            lblLogTitle.Location = new Point(20, 16);
            lblLogTitle.Text = "Lịch sử chấm công";

            dgvWorkTracking.BackgroundColor = Color.FromArgb(24, 24, 27);
            dgvWorkTracking.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(31, 31, 34);
            dgvWorkTracking.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(160, 160, 166);
            dgvWorkTracking.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dgvWorkTracking.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(31, 31, 34);
            dgvWorkTracking.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.FromArgb(160, 160, 166);
            dgvWorkTracking.DefaultCellStyle.BackColor = Color.FromArgb(24, 24, 27);
            dgvWorkTracking.DefaultCellStyle.ForeColor = Color.FromArgb(220, 220, 225);
            dgvWorkTracking.DefaultCellStyle.SelectionBackColor = Color.FromArgb(31, 138, 154);
            dgvWorkTracking.DefaultCellStyle.SelectionForeColor = Color.FromArgb(240, 240, 245);
            dgvWorkTracking.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(24, 24, 27);
            dgvWorkTracking.AlternatingRowsDefaultCellStyle.ForeColor = Color.FromArgb(220, 220, 225);
            dgvWorkTracking.GridColor = Color.FromArgb(45, 45, 48);
            ConfigureGrid(dgvWorkTracking);
            dgvWorkTracking.Location = new Point(18, 52);
            dgvWorkTracking.Size = new Size(864, 405);

            // ====== ucWorkTracking ======
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(39, 39, 42);
            Controls.Add(pnlSummary);
            Controls.Add(pnlLog);
            Name = "ucWorkTracking";
            Size = new Size(940, 660);
            pnlSummary.ResumeLayout(false);
            pnlSummary.PerformLayout();
            pnlLog.ResumeLayout(false);
            pnlLog.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvWorkTracking).EndInit();
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

        private Guna2Panel pnlSummary;
        private Label lblTotalShiftsTitle;
        private Label lblTotalShiftsValue;
        private Label lblTotalHoursTitle;
        private Label lblTotalHoursValue;
        private Label lblLateTitle;
        private Label lblLateValue;
        private Label lblAbsentTitle;
        private Label lblAbsentValue;
        private Label lblFilterTitle;
        private Guna2DateTimePicker dtpFilterMonth;
        private Guna2Button btnReport;
        private Guna2Panel pnlLog;
        private Label lblLogTitle;
        private Guna2DataGridView dgvWorkTracking;
    }
}
