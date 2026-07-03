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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
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
            pnlGrid = new Guna2Panel();
            lblGridTitle = new Label();
            dgvAttendance = new Guna2DataGridView();
            colAttEmployee = new DataGridViewTextBoxColumn();
            colAttDate = new DataGridViewTextBoxColumn();
            colAttCheckIn = new DataGridViewTextBoxColumn();
            colAttCheckOut = new DataGridViewTextBoxColumn();
            colAttHours = new DataGridViewTextBoxColumn();
            colAttStatus = new DataGridViewTextBoxColumn();
            colAttNote = new DataGridViewTextBoxColumn();
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
            pnlHeader.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlHeader.BackColor = Color.FromArgb(31, 31, 34);
            pnlHeader.BorderRadius = 14;
            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.CustomizableEdges = customizableEdges1;
            pnlHeader.Location = new Point(20, 20);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.ShadowDecoration.CustomizableEdges = customizableEdges2;
            pnlHeader.Size = new Size(835, 58);
            pnlHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(18, 16);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(205, 25);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Lịch sử chấm công";
            // 
            // pnlFilter
            // 
            pnlFilter.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
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
            pnlFilter.Location = new Point(20, 88);
            pnlFilter.Name = "pnlFilter";
            pnlFilter.ShadowDecoration.CustomizableEdges = customizableEdges12;
            pnlFilter.Size = new Size(835, 62);
            pnlFilter.TabIndex = 1;
            // 
            // lblEmpFilter
            // 
            lblEmpFilter.AutoSize = true;
            lblEmpFilter.Font = new Font("Segoe UI", 9F);
            lblEmpFilter.ForeColor = Color.FromArgb(160, 160, 166);
            lblEmpFilter.Location = new Point(18, 10);
            lblEmpFilter.Name = "lblEmpFilter";
            lblEmpFilter.Size = new Size(64, 15);
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
            cboEmployee.Location = new Point(18, 30);
            cboEmployee.Name = "cboEmployee";
            cboEmployee.ShadowDecoration.CustomizableEdges = customizableEdges4;
            cboEmployee.Size = new Size(210, 32);
            cboEmployee.TabIndex = 1;
            // 
            // lblEmployeeName
            // 
            lblEmployeeName.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblEmployeeName.ForeColor = Color.White;
            lblEmployeeName.Location = new Point(18, 30);
            lblEmployeeName.Name = "lblEmployeeName";
            lblEmployeeName.Size = new Size(210, 22);
            lblEmployeeName.TabIndex = 7;
            lblEmployeeName.Visible = false;
            // 
            // lblFrom
            // 
            lblFrom.AutoSize = true;
            lblFrom.Font = new Font("Segoe UI", 9F);
            lblFrom.ForeColor = Color.FromArgb(160, 160, 166);
            lblFrom.Location = new Point(248, 24);
            lblFrom.Name = "lblFrom";
            lblFrom.Size = new Size(53, 15);
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
            dtpFrom.Location = new Point(308, 13);
            dtpFrom.MaxDate = new DateTime(9998, 12, 31, 0, 0, 0, 0);
            dtpFrom.MinDate = new DateTime(1753, 1, 1, 0, 0, 0, 0);
            dtpFrom.Name = "dtpFrom";
            dtpFrom.ShadowDecoration.CustomizableEdges = customizableEdges6;
            dtpFrom.Size = new Size(140, 36);
            dtpFrom.TabIndex = 3;
            dtpFrom.Value = new DateTime(2026, 5, 24, 9, 33, 32, 284);
            // 
            // lblTo
            // 
            lblTo.AutoSize = true;
            lblTo.Font = new Font("Segoe UI", 9F);
            lblTo.ForeColor = Color.FromArgb(160, 160, 166);
            lblTo.Location = new Point(464, 24);
            lblTo.Name = "lblTo";
            lblTo.Size = new Size(60, 15);
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
            dtpTo.Location = new Point(530, 13);
            dtpTo.MaxDate = new DateTime(9998, 12, 31, 0, 0, 0, 0);
            dtpTo.MinDate = new DateTime(1753, 1, 1, 0, 0, 0, 0);
            dtpTo.Name = "dtpTo";
            dtpTo.ShadowDecoration.CustomizableEdges = customizableEdges8;
            dtpTo.Size = new Size(140, 36);
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
            btnFilter.Location = new Point(690, 14);
            btnFilter.Name = "btnFilter";
            btnFilter.ShadowDecoration.CustomizableEdges = customizableEdges10;
            btnFilter.Size = new Size(110, 34);
            btnFilter.TabIndex = 6;
            btnFilter.Text = "Lọc";
            btnFilter.Click += btnFilter_Click;
            // 
            // pnlSummary
            // 
            pnlSummary.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlSummary.BackColor = Color.Transparent;
            pnlSummary.Controls.Add(pnlStatShifts);
            pnlSummary.Controls.Add(pnlStatAbsent);
            pnlSummary.Controls.Add(pnlStatLate);
            pnlSummary.CustomizableEdges = customizableEdges21;
            pnlSummary.Location = new Point(20, 160);
            pnlSummary.Name = "pnlSummary";
            pnlSummary.ShadowDecoration.CustomizableEdges = customizableEdges22;
            pnlSummary.Size = new Size(835, 96);
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
            pnlStatShifts.Name = "pnlStatShifts";
            pnlStatShifts.ShadowDecoration.CustomizableEdges = customizableEdges14;
            pnlStatShifts.Size = new Size(220, 96);
            pnlStatShifts.TabIndex = 0;
            // 
            // lblShiftsTitle
            // 
            lblShiftsTitle.AutoSize = true;
            lblShiftsTitle.Font = new Font("Segoe UI", 9F);
            lblShiftsTitle.ForeColor = Color.FromArgb(160, 160, 166);
            lblShiftsTitle.Location = new Point(18, 16);
            lblShiftsTitle.Name = "lblShiftsTitle";
            lblShiftsTitle.Size = new Size(65, 15);
            lblShiftsTitle.TabIndex = 0;
            lblShiftsTitle.Text = "Ngày công";
            // 
            // lblShiftsValue
            // 
            lblShiftsValue.AutoSize = true;
            lblShiftsValue.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblShiftsValue.ForeColor = Color.FromArgb(34, 197, 94);
            lblShiftsValue.Location = new Point(18, 38);
            lblShiftsValue.Name = "lblShiftsValue";
            lblShiftsValue.Size = new Size(103, 37);
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
            pnlStatAbsent.Location = new Point(230, 0);
            pnlStatAbsent.Name = "pnlStatAbsent";
            pnlStatAbsent.ShadowDecoration.CustomizableEdges = customizableEdges16;
            pnlStatAbsent.Size = new Size(220, 96);
            pnlStatAbsent.TabIndex = 1;
            // 
            // lblAbsentTitle
            // 
            lblAbsentTitle.AutoSize = true;
            lblAbsentTitle.Font = new Font("Segoe UI", 9F);
            lblAbsentTitle.ForeColor = Color.FromArgb(160, 160, 166);
            lblAbsentTitle.Location = new Point(18, 16);
            lblAbsentTitle.Name = "lblAbsentTitle";
            lblAbsentTitle.Size = new Size(63, 15);
            lblAbsentTitle.TabIndex = 0;
            lblAbsentTitle.Text = "Nghỉ phép";
            // 
            // lblAbsentValue
            // 
            lblAbsentValue.AutoSize = true;
            lblAbsentValue.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblAbsentValue.ForeColor = Color.FromArgb(70, 130, 180);
            lblAbsentValue.Location = new Point(18, 38);
            lblAbsentValue.Name = "lblAbsentValue";
            lblAbsentValue.Size = new Size(103, 37);
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
            pnlStatLate.Location = new Point(460, 0);
            pnlStatLate.Name = "pnlStatLate";
            pnlStatLate.ShadowDecoration.CustomizableEdges = customizableEdges18;
            pnlStatLate.Size = new Size(220, 96);
            pnlStatLate.TabIndex = 2;
            // 
            // lblLateTitle
            // 
            lblLateTitle.AutoSize = true;
            lblLateTitle.Font = new Font("Segoe UI", 9F);
            lblLateTitle.ForeColor = Color.FromArgb(160, 160, 166);
            lblLateTitle.Location = new Point(18, 16);
            lblLateTitle.Name = "lblLateTitle";
            lblLateTitle.Size = new Size(53, 15);
            lblLateTitle.TabIndex = 0;
            lblLateTitle.Text = "Đi muộn";
            // 
            // lblLateValue
            // 
            lblLateValue.AutoSize = true;
            lblLateValue.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblLateValue.ForeColor = Color.FromArgb(245, 158, 11);
            lblLateValue.Location = new Point(18, 38);
            lblLateValue.Name = "lblLateValue";
            lblLateValue.Size = new Size(79, 37);
            lblLateValue.TabIndex = 1;
            lblLateValue.Text = "0 lần";
            //
            // pnlGrid
            //
            pnlGrid.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnlGrid.BackColor = Color.FromArgb(31, 31, 34);
            pnlGrid.BorderRadius = 14;
            pnlGrid.Controls.Add(lblGridTitle);
            pnlGrid.Controls.Add(dgvAttendance);
            pnlGrid.CustomizableEdges = customizableEdges23;
            pnlGrid.Location = new Point(20, 266);
            pnlGrid.Name = "pnlGrid";
            pnlGrid.ShadowDecoration.CustomizableEdges = customizableEdges24;
            pnlGrid.Size = new Size(835, 215);
            pnlGrid.TabIndex = 3;
            // 
            // lblGridTitle
            // 
            lblGridTitle.AutoSize = true;
            lblGridTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblGridTitle.ForeColor = Color.White;
            lblGridTitle.Location = new Point(18, 14);
            lblGridTitle.Name = "lblGridTitle";
            lblGridTitle.Size = new Size(169, 20);
            lblGridTitle.TabIndex = 0;
            lblGridTitle.Text = "Chi tiết chấm công";
            // 
            // dgvAttendance
            // 
            dataGridViewCellStyle1.BackColor = Color.FromArgb(24, 24, 27);
            dataGridViewCellStyle1.ForeColor = Color.FromArgb(220, 220, 225);
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(31, 138, 154);
            dataGridViewCellStyle1.SelectionForeColor = Color.FromArgb(240, 240, 245);
            dgvAttendance.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvAttendance.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvAttendance.BackgroundColor = Color.FromArgb(24, 24, 27);
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(31, 31, 34);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(160, 160, 166);
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(31, 31, 34);
            dataGridViewCellStyle2.SelectionForeColor = Color.FromArgb(160, 160, 166);
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvAttendance.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvAttendance.ColumnHeadersHeight = 32;
            dgvAttendance.Columns.AddRange(new DataGridViewColumn[] { colAttEmployee, colAttDate, colAttCheckIn, colAttCheckOut, colAttHours, colAttStatus, colAttNote });
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.FromArgb(24, 24, 27);
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(220, 220, 225);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(31, 138, 154);
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(240, 240, 245);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvAttendance.DefaultCellStyle = dataGridViewCellStyle3;
            dgvAttendance.GridColor = Color.FromArgb(45, 45, 48);
            dgvAttendance.Location = new Point(18, 46);
            dgvAttendance.Name = "dgvAttendance";
            dgvAttendance.ReadOnly = true;
            dgvAttendance.RowHeadersVisible = false;
            dgvAttendance.RowHeadersWidth = 51;
            dgvAttendance.RowTemplate.Height = 29;
            dgvAttendance.Size = new Size(798, 154);
            dgvAttendance.TabIndex = 1;
            dgvAttendance.ThemeStyle.AlternatingRowsStyle.BackColor = Color.FromArgb(24, 24, 27);
            dgvAttendance.ThemeStyle.AlternatingRowsStyle.Font = null;
            dgvAttendance.ThemeStyle.AlternatingRowsStyle.ForeColor = Color.Empty;
            dgvAttendance.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.Empty;
            dgvAttendance.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.Empty;
            dgvAttendance.ThemeStyle.BackColor = Color.FromArgb(24, 24, 27);
            dgvAttendance.ThemeStyle.GridColor = Color.FromArgb(45, 45, 48);
            dgvAttendance.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(31, 31, 34);
            dgvAttendance.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvAttendance.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dgvAttendance.ThemeStyle.HeaderStyle.ForeColor = Color.FromArgb(160, 160, 166);
            dgvAttendance.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvAttendance.ThemeStyle.HeaderStyle.Height = 32;
            dgvAttendance.ThemeStyle.ReadOnly = true;
            dgvAttendance.ThemeStyle.RowsStyle.BackColor = Color.FromArgb(24, 24, 27);
            dgvAttendance.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvAttendance.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 9F);
            dgvAttendance.ThemeStyle.RowsStyle.ForeColor = Color.FromArgb(240, 240, 245);
            dgvAttendance.ThemeStyle.RowsStyle.Height = 29;
            dgvAttendance.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(31, 138, 154);
            dgvAttendance.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(240, 240, 245);
            // 
            // colAttEmployee
            // 
            colAttEmployee.DataPropertyName = "Nhân viên";
            colAttEmployee.FillWeight = 18F;
            colAttEmployee.HeaderText = "Nhân viên";
            colAttEmployee.Name = "colAttEmployee";
            colAttEmployee.ReadOnly = true;
            // 
            // colAttDate
            // 
            colAttDate.DataPropertyName = "Ngày";
            colAttDate.FillWeight = 12F;
            colAttDate.HeaderText = "Ngày";
            colAttDate.Name = "colAttDate";
            colAttDate.ReadOnly = true;
            // 
            // colAttCheckIn
            // 
            colAttCheckIn.DataPropertyName = "Giờ vào";
            colAttCheckIn.FillWeight = 10F;
            colAttCheckIn.HeaderText = "Giờ vào";
            colAttCheckIn.Name = "colAttCheckIn";
            colAttCheckIn.ReadOnly = true;
            // 
            // colAttCheckOut
            // 
            colAttCheckOut.DataPropertyName = "Giờ ra";
            colAttCheckOut.FillWeight = 10F;
            colAttCheckOut.HeaderText = "Giờ ra";
            colAttCheckOut.Name = "colAttCheckOut";
            colAttCheckOut.ReadOnly = true;
            // 
            // colAttHours
            // 
            colAttHours.DataPropertyName = "Số giờ";
            colAttHours.FillWeight = 9F;
            colAttHours.HeaderText = "Số giờ";
            colAttHours.Name = "colAttHours";
            colAttHours.ReadOnly = true;
            // 
            // colAttStatus
            // 
            colAttStatus.DataPropertyName = "Trạng thái";
            colAttStatus.FillWeight = 14F;
            colAttStatus.HeaderText = "Trạng thái";
            colAttStatus.Name = "colAttStatus";
            colAttStatus.ReadOnly = true;
            // 
            // colAttNote
            // 
            colAttNote.DataPropertyName = "Ghi chú";
            colAttNote.FillWeight = 27F;
            colAttNote.HeaderText = "Ghi chú";
            colAttNote.Name = "colAttNote";
            colAttNote.ReadOnly = true;
            // 
            // ucAttendanceHistory
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(39, 39, 42);
            Controls.Add(pnlGrid);
            Controls.Add(pnlSummary);
            Controls.Add(pnlFilter);
            Controls.Add(pnlHeader);
            Name = "ucAttendanceHistory";
            Size = new Size(875, 499);
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
            dgv.RowTemplate.Height = 30;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DgvDarkScroll.Apply(dgv);
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
        private Guna2Panel        pnlGrid;
        private Label             lblGridTitle;
        private Guna2DataGridView dgvAttendance;
        private DataGridViewTextBoxColumn colAttEmployee;
        private DataGridViewTextBoxColumn colAttDate;
        private DataGridViewTextBoxColumn colAttCheckIn;
        private DataGridViewTextBoxColumn colAttCheckOut;
        private DataGridViewTextBoxColumn colAttHours;
        private DataGridViewTextBoxColumn colAttStatus;
        private DataGridViewTextBoxColumn colAttNote;
    }
}
