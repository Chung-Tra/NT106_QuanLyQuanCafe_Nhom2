using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace GUI
{
    partial class ucAttendanceHistory
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges11 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges12 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges21 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges22 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges13 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges14 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges15 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges16 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges17 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges18 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges19 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges20 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges23 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges24 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            pnlHeader = new Guna2Panel();
            lblTitle = new Label();
            pnlFilter = new Guna2Panel();
            lblEmpFilter = new Label();
            cboEmployee = new Guna2ComboBox();
            lblEmployeeName = new Label();
            lblFrom = new Label();
            dtpFrom = new Guna2DateTimePicker();
            lblTo = new Label();
            dtpTo = new Guna2DateTimePicker();
            btnFilter = new Guna2Button();
            pnlSummary = new Guna2Panel();
            pnlStatShifts = new Guna2Panel();
            lblShiftsTitle = new Label();
            lblShiftsValue = new Label();
            pnlStatAbsent = new Guna2Panel();
            lblAbsentTitle = new Label();
            lblAbsentValue = new Label();
            pnlStatLate = new Guna2Panel();
            lblLateTitle = new Label();
            lblLateValue = new Label();
            btnReport = new Guna2Button();
            pnlGrid = new Guna2Panel();
            dgvAttendance = new DataGridView();
            lblGridTitle = new Label();
            pnlHeader.SuspendLayout();
            pnlFilter.SuspendLayout();
            pnlSummary.SuspendLayout();
            pnlStatShifts.SuspendLayout();
            pnlStatAbsent.SuspendLayout();
            pnlStatLate.SuspendLayout();
            pnlGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAttendance).BeginInit();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.FromArgb(31, 31, 34);
            pnlHeader.BorderRadius = 14;
            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.CustomizableEdges = customizableEdges1;
            pnlHeader.Location = new Point(23, 27);
            pnlHeader.Margin = new Padding(3, 4, 3, 4);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.ShadowDecoration.CustomizableEdges = customizableEdges2;
            pnlHeader.Size = new Size(1051, 77);
            pnlHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(21, 21);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(246, 30);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "📅  Lịch sử chấm công";
            // 
            // pnlFilter
            // 
            pnlFilter.BackColor = Color.FromArgb(31, 31, 34);
            pnlFilter.BorderRadius = 14;
            pnlFilter.Controls.Add(lblEmpFilter);
            pnlFilter.Controls.Add(cboEmployee);
            pnlFilter.Controls.Add(lblEmployeeName);
            pnlFilter.Controls.Add(lblFrom);
            pnlFilter.Controls.Add(dtpFrom);
            pnlFilter.Controls.Add(lblTo);
            pnlFilter.Controls.Add(dtpTo);
            pnlFilter.Controls.Add(btnFilter);
            pnlFilter.CustomizableEdges = customizableEdges11;
            pnlFilter.Location = new Point(23, 117);
            pnlFilter.Margin = new Padding(3, 4, 3, 4);
            pnlFilter.Name = "pnlFilter";
            pnlFilter.ShadowDecoration.CustomizableEdges = customizableEdges12;
            pnlFilter.Size = new Size(1051, 83);
            pnlFilter.TabIndex = 1;
            // 
            // lblEmpFilter
            // 
            lblEmpFilter.AutoSize = true;
            lblEmpFilter.Font = new Font("Segoe UI", 9F);
            lblEmpFilter.ForeColor = Color.FromArgb(160, 160, 166);
            lblEmpFilter.Location = new Point(21, 13);
            lblEmpFilter.Name = "lblEmpFilter";
            lblEmpFilter.Size = new Size(78, 20);
            lblEmpFilter.TabIndex = 0;
            lblEmpFilter.Text = "Nhân viên:";
            // 
            // cboEmployee
            // 
            cboEmployee.BackColor = Color.Transparent;
            cboEmployee.BorderColor = Color.FromArgb(63, 63, 70);
            cboEmployee.BorderRadius = 8;
            cboEmployee.CustomizableEdges = customizableEdges3;
            cboEmployee.DrawMode = DrawMode.OwnerDrawFixed;
            cboEmployee.DropDownStyle = ComboBoxStyle.DropDownList;
            cboEmployee.FillColor = Color.FromArgb(24, 24, 27);
            cboEmployee.FocusedColor = Color.FromArgb(31, 138, 154);
            cboEmployee.FocusedState.BorderColor = Color.FromArgb(31, 138, 154);
            cboEmployee.Font = new Font("Segoe UI", 9.5F);
            cboEmployee.ForeColor = Color.White;
            cboEmployee.HoverState.BorderColor = Color.FromArgb(80, 80, 90);
            cboEmployee.ItemHeight = 26;
            cboEmployee.Location = new Point(21, 40);
            cboEmployee.Margin = new Padding(3, 4, 3, 4);
            cboEmployee.Name = "cboEmployee";
            cboEmployee.ShadowDecoration.CustomizableEdges = customizableEdges4;
            cboEmployee.Size = new Size(239, 32);
            cboEmployee.TabIndex = 1;
            // 
            // lblEmployeeName
            // 
            lblEmployeeName.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblEmployeeName.ForeColor = Color.White;
            lblEmployeeName.Location = new Point(21, 40);
            lblEmployeeName.Name = "lblEmployeeName";
            lblEmployeeName.Size = new Size(240, 29);
            lblEmployeeName.TabIndex = 7;
            lblEmployeeName.Visible = false;
            // 
            // lblFrom
            // 
            lblFrom.AutoSize = true;
            lblFrom.Font = new Font("Segoe UI", 9F);
            lblFrom.ForeColor = Color.FromArgb(160, 160, 166);
            lblFrom.Location = new Point(283, 11);
            lblFrom.Name = "lblFrom";
            lblFrom.Size = new Size(65, 20);
            lblFrom.TabIndex = 2;
            lblFrom.Text = "Từ ngày:";
            // 
            // dtpFrom
            // 
            dtpFrom.BorderColor = Color.FromArgb(63, 63, 70);
            dtpFrom.BorderRadius = 8;
            dtpFrom.Checked = true;
            dtpFrom.CustomizableEdges = customizableEdges5;
            dtpFrom.FillColor = Color.FromArgb(24, 24, 27);
            dtpFrom.Font = new Font("Segoe UI", 9.5F);
            dtpFrom.ForeColor = Color.White;
            dtpFrom.Format = DateTimePickerFormat.Short;
            dtpFrom.Location = new Point(283, 17);
            dtpFrom.Margin = new Padding(3, 4, 3, 4);
            dtpFrom.MaxDate = new DateTime(9998, 12, 31, 0, 0, 0, 0);
            dtpFrom.MinDate = new DateTime(1753, 1, 1, 0, 0, 0, 0);
            dtpFrom.Name = "dtpFrom";
            dtpFrom.ShadowDecoration.CustomizableEdges = customizableEdges6;
            dtpFrom.Size = new Size(160, 48);
            dtpFrom.TabIndex = 3;
            dtpFrom.Value = new DateTime(2026, 5, 24, 9, 33, 32, 284);
            // 
            // lblTo
            // 
            lblTo.AutoSize = true;
            lblTo.Font = new Font("Segoe UI", 9F);
            lblTo.ForeColor = Color.FromArgb(160, 160, 166);
            lblTo.Location = new Point(462, 11);
            lblTo.Name = "lblTo";
            lblTo.Size = new Size(75, 20);
            lblTo.TabIndex = 4;
            lblTo.Text = "Đến ngày:";
            // 
            // dtpTo
            // 
            dtpTo.BorderColor = Color.FromArgb(63, 63, 70);
            dtpTo.BorderRadius = 8;
            dtpTo.Checked = true;
            dtpTo.CustomizableEdges = customizableEdges7;
            dtpTo.FillColor = Color.FromArgb(24, 24, 27);
            dtpTo.Font = new Font("Segoe UI", 9.5F);
            dtpTo.ForeColor = Color.White;
            dtpTo.Format = DateTimePickerFormat.Short;
            dtpTo.Location = new Point(462, 17);
            dtpTo.Margin = new Padding(3, 4, 3, 4);
            dtpTo.MaxDate = new DateTime(9998, 12, 31, 0, 0, 0, 0);
            dtpTo.MinDate = new DateTime(1753, 1, 1, 0, 0, 0, 0);
            dtpTo.Name = "dtpTo";
            dtpTo.ShadowDecoration.CustomizableEdges = customizableEdges8;
            dtpTo.Size = new Size(160, 48);
            dtpTo.TabIndex = 5;
            dtpTo.Value = new DateTime(2026, 5, 24, 9, 33, 32, 308);
            // 
            // btnFilter
            // 
            btnFilter.BorderRadius = 10;
            btnFilter.Cursor = Cursors.Hand;
            btnFilter.CustomizableEdges = customizableEdges9;
            btnFilter.FillColor = Color.FromArgb(31, 138, 154);
            btnFilter.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnFilter.ForeColor = Color.White;
            btnFilter.HoverState.FillColor = Color.FromArgb(45, 158, 174);
            btnFilter.Location = new Point(642, 19);
            btnFilter.Margin = new Padding(3, 4, 3, 4);
            btnFilter.Name = "btnFilter";
            btnFilter.ShadowDecoration.CustomizableEdges = customizableEdges10;
            btnFilter.Size = new Size(126, 45);
            btnFilter.TabIndex = 6;
            btnFilter.Text = "🔍  Lọc";
            // 
            // pnlSummary
            // 
            pnlSummary.BackColor = Color.Transparent;
            pnlSummary.Controls.Add(pnlStatShifts);
            pnlSummary.Controls.Add(pnlStatAbsent);
            pnlSummary.Controls.Add(pnlStatLate);
            pnlSummary.Controls.Add(btnReport);
            pnlSummary.CustomizableEdges = customizableEdges21;
            pnlSummary.Location = new Point(23, 213);
            pnlSummary.Margin = new Padding(3, 4, 3, 4);
            pnlSummary.Name = "pnlSummary";
            pnlSummary.ShadowDecoration.CustomizableEdges = customizableEdges22;
            pnlSummary.Size = new Size(1051, 128);
            pnlSummary.TabIndex = 2;
            // 
            // pnlStatShifts
            // 
            pnlStatShifts.BackColor = Color.FromArgb(31, 31, 34);
            pnlStatShifts.BorderRadius = 14;
            pnlStatShifts.Controls.Add(lblShiftsTitle);
            pnlStatShifts.Controls.Add(lblShiftsValue);
            pnlStatShifts.CustomizableEdges = customizableEdges13;
            pnlStatShifts.Location = new Point(0, 0);
            pnlStatShifts.Margin = new Padding(3, 4, 3, 4);
            pnlStatShifts.Name = "pnlStatShifts";
            pnlStatShifts.ShadowDecoration.CustomizableEdges = customizableEdges14;
            pnlStatShifts.Size = new Size(251, 128);
            pnlStatShifts.TabIndex = 0;
            // 
            // lblShiftsTitle
            // 
            lblShiftsTitle.AutoSize = true;
            lblShiftsTitle.Font = new Font("Segoe UI", 9F);
            lblShiftsTitle.ForeColor = Color.FromArgb(160, 160, 166);
            lblShiftsTitle.Location = new Point(21, 21);
            lblShiftsTitle.Name = "lblShiftsTitle";
            lblShiftsTitle.Size = new Size(81, 20);
            lblShiftsTitle.TabIndex = 0;
            lblShiftsTitle.Text = "Ngày công";
            // 
            // lblShiftsValue
            // 
            lblShiftsValue.AutoSize = true;
            lblShiftsValue.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblShiftsValue.ForeColor = Color.FromArgb(34, 197, 94);
            lblShiftsValue.Location = new Point(21, 51);
            lblShiftsValue.Name = "lblShiftsValue";
            lblShiftsValue.Size = new Size(127, 46);
            lblShiftsValue.TabIndex = 1;
            lblShiftsValue.Text = "0 ngày";
            // 
            // pnlStatAbsent
            // 
            pnlStatAbsent.BackColor = Color.FromArgb(31, 31, 34);
            pnlStatAbsent.BorderRadius = 14;
            pnlStatAbsent.Controls.Add(lblAbsentTitle);
            pnlStatAbsent.Controls.Add(lblAbsentValue);
            pnlStatAbsent.CustomizableEdges = customizableEdges15;
            pnlStatAbsent.Location = new Point(263, 0);
            pnlStatAbsent.Margin = new Padding(3, 4, 3, 4);
            pnlStatAbsent.Name = "pnlStatAbsent";
            pnlStatAbsent.ShadowDecoration.CustomizableEdges = customizableEdges16;
            pnlStatAbsent.Size = new Size(251, 128);
            pnlStatAbsent.TabIndex = 1;
            // 
            // lblAbsentTitle
            // 
            lblAbsentTitle.AutoSize = true;
            lblAbsentTitle.Font = new Font("Segoe UI", 9F);
            lblAbsentTitle.ForeColor = Color.FromArgb(160, 160, 166);
            lblAbsentTitle.Location = new Point(21, 21);
            lblAbsentTitle.Name = "lblAbsentTitle";
            lblAbsentTitle.Size = new Size(79, 20);
            lblAbsentTitle.TabIndex = 0;
            lblAbsentTitle.Text = "Nghỉ phép";
            // 
            // lblAbsentValue
            // 
            lblAbsentValue.AutoSize = true;
            lblAbsentValue.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblAbsentValue.ForeColor = Color.FromArgb(56, 139, 204);
            lblAbsentValue.Location = new Point(21, 51);
            lblAbsentValue.Name = "lblAbsentValue";
            lblAbsentValue.Size = new Size(127, 46);
            lblAbsentValue.TabIndex = 1;
            lblAbsentValue.Text = "0 ngày";
            // 
            // pnlStatLate
            // 
            pnlStatLate.BackColor = Color.FromArgb(31, 31, 34);
            pnlStatLate.BorderRadius = 14;
            pnlStatLate.Controls.Add(lblLateTitle);
            pnlStatLate.Controls.Add(lblLateValue);
            pnlStatLate.CustomizableEdges = customizableEdges17;
            pnlStatLate.Location = new Point(526, 0);
            pnlStatLate.Margin = new Padding(3, 4, 3, 4);
            pnlStatLate.Name = "pnlStatLate";
            pnlStatLate.ShadowDecoration.CustomizableEdges = customizableEdges18;
            pnlStatLate.Size = new Size(251, 128);
            pnlStatLate.TabIndex = 2;
            // 
            // lblLateTitle
            // 
            lblLateTitle.AutoSize = true;
            lblLateTitle.Font = new Font("Segoe UI", 9F);
            lblLateTitle.ForeColor = Color.FromArgb(160, 160, 166);
            lblLateTitle.Location = new Point(21, 21);
            lblLateTitle.Name = "lblLateTitle";
            lblLateTitle.Size = new Size(66, 20);
            lblLateTitle.TabIndex = 0;
            lblLateTitle.Text = "Đi muộn";
            // 
            // lblLateValue
            // 
            lblLateValue.AutoSize = true;
            lblLateValue.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblLateValue.ForeColor = Color.FromArgb(234, 179, 8);
            lblLateValue.Location = new Point(21, 51);
            lblLateValue.Name = "lblLateValue";
            lblLateValue.Size = new Size(98, 46);
            lblLateValue.TabIndex = 1;
            lblLateValue.Text = "0 lần";
            // 
            // btnReport
            // 
            btnReport.BorderRadius = 10;
            btnReport.Cursor = Cursors.Hand;
            btnReport.CustomizableEdges = customizableEdges19;
            btnReport.FillColor = Color.FromArgb(127, 29, 29);
            btnReport.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnReport.ForeColor = Color.FromArgb(252, 165, 165);
            btnReport.HoverState.FillColor = Color.FromArgb(185, 28, 28);
            btnReport.HoverState.ForeColor = Color.White;
            btnReport.Location = new Point(789, 37);
            btnReport.Margin = new Padding(3, 4, 3, 4);
            btnReport.Name = "btnReport";
            btnReport.ShadowDecoration.CustomizableEdges = customizableEdges20;
            btnReport.Size = new Size(240, 53);
            btnReport.TabIndex = 3;
            btnReport.Text = "⚠  Báo cáo sai sót";
            // 
            // pnlGrid
            // 
            pnlGrid.BackColor = Color.FromArgb(31, 31, 34);
            pnlGrid.BorderRadius = 14;
            pnlGrid.Controls.Add(dgvAttendance);
            pnlGrid.Controls.Add(lblGridTitle);
            pnlGrid.CustomizableEdges = customizableEdges23;
            pnlGrid.Location = new Point(23, 355);
            pnlGrid.Margin = new Padding(3, 4, 3, 4);
            pnlGrid.Name = "pnlGrid";
            pnlGrid.ShadowDecoration.CustomizableEdges = customizableEdges24;
            pnlGrid.Size = new Size(1051, 483);
            pnlGrid.TabIndex = 3;
            // 
            // dgvAttendance
            // 
            dgvAttendance.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAttendance.Location = new Point(21, 61);
            dgvAttendance.Name = "dgvAttendance";
            dgvAttendance.RowHeadersWidth = 51;
            dgvAttendance.Size = new Size(990, 372);
            dgvAttendance.TabIndex = 1;
            // 
            // lblGridTitle
            // 
            lblGridTitle.AutoSize = true;
            lblGridTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblGridTitle.ForeColor = Color.White;
            lblGridTitle.Location = new Point(21, 19);
            lblGridTitle.Name = "lblGridTitle";
            lblGridTitle.Size = new Size(204, 25);
            lblGridTitle.TabIndex = 0;
            lblGridTitle.Text = "📋  Chi tiết chấm công";
            // 
            // ucAttendanceHistory
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(39, 39, 42);
            Controls.Add(pnlGrid);
            Controls.Add(pnlSummary);
            Controls.Add(pnlFilter);
            Controls.Add(pnlHeader);
            Margin = new Padding(3, 4, 3, 4);
            Name = "ucAttendanceHistory";
            Size = new Size(1097, 864);
            Load += ucAttendanceHistory_Load;
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            pnlFilter.ResumeLayout(false);
            pnlFilter.PerformLayout();
            pnlSummary.ResumeLayout(false);
            pnlStatShifts.ResumeLayout(false);
            pnlStatShifts.PerformLayout();
            pnlStatAbsent.ResumeLayout(false);
            pnlStatAbsent.PerformLayout();
            pnlStatLate.ResumeLayout(false);
            pnlStatLate.PerformLayout();
            pnlGrid.ResumeLayout(false);
            pnlGrid.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAttendance).EndInit();
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
            dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(31, 31, 34);
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(160, 160, 166);
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dgv.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(31, 31, 34);
            dgv.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.FromArgb(160, 160, 166);
            dgv.DefaultCellStyle.BackColor = Color.FromArgb(24, 24, 27);
            dgv.DefaultCellStyle.ForeColor = Color.FromArgb(220, 220, 225);
            dgv.DefaultCellStyle.Font = new Font("Segoe UI", 9.5F);
            dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(31, 138, 154);
            dgv.DefaultCellStyle.SelectionForeColor = Color.White;
            dgv.EnableHeadersVisualStyles = false;
            dgv.GridColor = Color.FromArgb(45, 45, 48);
            dgv.MultiSelect = false;
            dgv.ReadOnly = true;
            dgv.RowHeadersVisible = false;
            dgv.RowTemplate.Height = 30;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private Guna2Panel        pnlHeader;
        private Label             lblTitle;
        private Guna2Panel        pnlFilter;
        private Label             lblEmpFilter;
        private Guna2ComboBox     cboEmployee;
        private Label                 lblEmployeeName;
        private Label                 lblFrom;
        private Guna2DateTimePicker   dtpFrom;
        private Label                 lblTo;
        private Guna2DateTimePicker   dtpTo;
        private Guna2Button       btnFilter;
        private Guna2Panel        pnlSummary;
        private Guna2Panel        pnlStatShifts;
        private Label             lblShiftsTitle;
        private Label             lblShiftsValue;
        private Guna2Panel        pnlStatAbsent;
        private Label             lblAbsentTitle;
        private Label             lblAbsentValue;
        private Guna2Panel        pnlStatLate;
        private Label             lblLateTitle;
        private Label             lblLateValue;
        private Guna2Button       btnReport;
        private Guna2Panel        pnlGrid;
        private Label             lblGridTitle;
        private DataGridView dgvAttendance;
    }
}
