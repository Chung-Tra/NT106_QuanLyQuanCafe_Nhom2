using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace GUI
{
    partial class ucPayroll_Admin
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges15 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges16 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges11 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges12 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges13 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges14 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges17 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges18 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            pnlHeader = new Guna2Panel();
            lblTitle = new Label();
            lblMonth = new Label();
            cmbMonth = new Guna2ComboBox();
            btnApplyBP = new Guna2Button();
            btnLockDays = new Guna2Button();
            btnEditPayroll = new Guna2Button();
            pnlSummary = new Guna2Panel();
            tblSummary = new TableLayoutPanel();
            pnlStatTotal = new Guna2Panel();
            lblTotalSalaryTitle = new Label();
            lblTotalSalary = new Label();
            pnlStatCount = new Guna2Panel();
            lblEmployeeCountTitle = new Label();
            lblEmployeeCount = new Label();
            pnlGrid = new Guna2Panel();
            dgvPayroll = new Guna2DataGridView();
            colEmpId = new DataGridViewTextBoxColumn();
            colName = new DataGridViewTextBoxColumn();
            colDept = new DataGridViewTextBoxColumn();
            colWorkDays = new DataGridViewTextBoxColumn();
            colBaseSalary = new DataGridViewTextBoxColumn();
            colAllowance = new DataGridViewTextBoxColumn();
            colBonusFb = new DataGridViewTextBoxColumn();
            colBonusHoliday = new DataGridViewTextBoxColumn();
            colDeduction = new DataGridViewTextBoxColumn();
            colDeductReason = new DataGridViewTextBoxColumn();
            colTotalSalary = new DataGridViewTextBoxColumn();
            pnlHeader.SuspendLayout();
            pnlSummary.SuspendLayout();
            tblSummary.SuspendLayout();
            pnlStatTotal.SuspendLayout();
            pnlStatCount.SuspendLayout();
            pnlGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPayroll).BeginInit();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlHeader.BackColor = Color.FromArgb(31, 31, 34);
            pnlHeader.BorderRadius = 14;
            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Controls.Add(lblMonth);
            pnlHeader.Controls.Add(cmbMonth);
            pnlHeader.Controls.Add(btnApplyBP);
            pnlHeader.Controls.Add(btnLockDays);
            pnlHeader.Controls.Add(btnEditPayroll);
            pnlHeader.CustomizableEdges = customizableEdges9;
            pnlHeader.Location = new Point(20, 20);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.ShadowDecoration.CustomizableEdges = customizableEdges10;
            pnlHeader.Size = new Size(960, 70);
            pnlHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(18, 22);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(200, 25);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Bảng lương nhân viên";
            // 
            // lblMonth
            // 
            lblMonth.AutoSize = true;
            lblMonth.Font = new Font("Segoe UI", 9.5F);
            lblMonth.ForeColor = Color.FromArgb(160, 160, 166);
            lblMonth.Location = new Point(450, 27);
            lblMonth.Name = "lblMonth";
            lblMonth.Size = new Size(47, 17);
            lblMonth.TabIndex = 1;
            lblMonth.Text = "Tháng:";
            // 
            // cmbMonth
            // 
            cmbMonth.BackColor = Color.Transparent;
            cmbMonth.BorderColor = Color.FromArgb(63, 63, 70);
            cmbMonth.BorderRadius = 8;
            cmbMonth.CustomizableEdges = customizableEdges1;
            cmbMonth.DrawMode = DrawMode.OwnerDrawFixed;
            cmbMonth.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMonth.FillColor = Color.FromArgb(24, 24, 27);
            cmbMonth.FocusedColor = Color.FromArgb(31, 138, 154);
            cmbMonth.FocusedState.BorderColor = Color.FromArgb(31, 138, 154);
            cmbMonth.Font = new Font("Segoe UI", 9.5F);
            cmbMonth.ForeColor = Color.White;
            cmbMonth.HoverState.BorderColor = Color.FromArgb(120, 120, 130);
            cmbMonth.ItemHeight = 26;
            cmbMonth.Items.AddRange(new object[] { "Tháng 1", "Tháng 2", "Tháng 3", "Tháng 4", "Tháng 5", "Tháng 6", "Tháng 7", "Tháng 8", "Tháng 9", "Tháng 10", "Tháng 11", "Tháng 12" });
            cmbMonth.Location = new Point(508, 21);
            cmbMonth.Name = "cmbMonth";
            cmbMonth.ShadowDecoration.CustomizableEdges = customizableEdges2;
            cmbMonth.Size = new Size(150, 32);
            cmbMonth.TabIndex = 2;
            cmbMonth.SelectedIndexChanged += cmbMonth_SelectedIndexChanged;
            // 
            // btnApplyBP
            // 
            btnApplyBP.BorderRadius = 10;
            btnApplyBP.Cursor = Cursors.Hand;
            btnApplyBP.CustomizableEdges = customizableEdges3;
            btnApplyBP.FillColor = Color.FromArgb(31, 138, 154);
            btnApplyBP.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnApplyBP.ForeColor = Color.White;
            btnApplyBP.HoverState.FillColor = Color.FromArgb(45, 158, 174);
            btnApplyBP.Location = new Point(818, 18);
            btnApplyBP.Name = "btnApplyBP";
            btnApplyBP.ShadowDecoration.CustomizableEdges = customizableEdges4;
            btnApplyBP.Size = new Size(130, 34);
            btnApplyBP.TabIndex = 3;
            btnApplyBP.Text = "Tính lương";
            btnApplyBP.Click += btnApplyBP_Click;
            // 
            // btnLockDays
            // 
            btnLockDays.BorderRadius = 10;
            btnLockDays.Cursor = Cursors.Hand;
            btnLockDays.CustomizableEdges = customizableEdges5;
            btnLockDays.FillColor = Color.FromArgb(245, 158, 11);
            btnLockDays.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnLockDays.ForeColor = Color.White;
            btnLockDays.HoverState.FillColor = Color.FromArgb(255, 178, 40);
            btnLockDays.Location = new Point(668, 18);
            btnLockDays.Name = "btnLockDays";
            btnLockDays.ShadowDecoration.CustomizableEdges = customizableEdges6;
            btnLockDays.Size = new Size(140, 34);
            btnLockDays.TabIndex = 4;
            btnLockDays.Text = "Chốt công";
            btnLockDays.Click += BtnLockDays_Click;
            // 
            // btnEditPayroll
            // 
            btnEditPayroll.BorderColor = Color.FromArgb(80, 80, 90);
            btnEditPayroll.BorderRadius = 10;
            btnEditPayroll.BorderThickness = 1;
            btnEditPayroll.Cursor = Cursors.Hand;
            btnEditPayroll.CustomizableEdges = customizableEdges7;
            btnEditPayroll.FillColor = Color.Transparent;
            btnEditPayroll.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnEditPayroll.ForeColor = Color.FromArgb(220, 220, 225);
            btnEditPayroll.HoverState.FillColor = Color.FromArgb(45, 45, 50);
            btnEditPayroll.Location = new Point(290, 18);
            btnEditPayroll.Name = "btnEditPayroll";
            btnEditPayroll.ShadowDecoration.CustomizableEdges = customizableEdges8;
            btnEditPayroll.Size = new Size(150, 34);
            btnEditPayroll.TabIndex = 5;
            btnEditPayroll.Text = "Sửa dòng chọn";
            btnEditPayroll.Click += BtnEditPayroll_Click;
            // 
            // pnlSummary
            // 
            pnlSummary.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlSummary.BackColor = Color.Transparent;
            pnlSummary.Controls.Add(tblSummary);
            pnlSummary.CustomizableEdges = customizableEdges15;
            pnlSummary.Location = new Point(20, 105);
            pnlSummary.Name = "pnlSummary";
            pnlSummary.ShadowDecoration.CustomizableEdges = customizableEdges16;
            pnlSummary.Size = new Size(960, 90);
            pnlSummary.TabIndex = 1;
            // 
            // tblSummary
            // 
            tblSummary.BackColor = Color.Transparent;
            tblSummary.ColumnCount = 2;
            tblSummary.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tblSummary.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tblSummary.Controls.Add(pnlStatTotal, 0, 0);
            tblSummary.Controls.Add(pnlStatCount, 1, 0);
            tblSummary.Dock = DockStyle.Fill;
            tblSummary.Location = new Point(0, 0);
            tblSummary.Name = "tblSummary";
            tblSummary.RowCount = 1;
            tblSummary.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tblSummary.Size = new Size(960, 90);
            tblSummary.TabIndex = 0;
            // 
            // pnlStatTotal
            // 
            pnlStatTotal.BackColor = Color.FromArgb(31, 31, 34);
            pnlStatTotal.BorderRadius = 14;
            pnlStatTotal.Controls.Add(lblTotalSalaryTitle);
            pnlStatTotal.Controls.Add(lblTotalSalary);
            pnlStatTotal.CustomizableEdges = customizableEdges11;
            pnlStatTotal.Dock = DockStyle.Fill;
            pnlStatTotal.Location = new Point(0, 0);
            pnlStatTotal.Margin = new Padding(0, 0, 10, 0);
            pnlStatTotal.Name = "pnlStatTotal";
            pnlStatTotal.ShadowDecoration.CustomizableEdges = customizableEdges12;
            pnlStatTotal.Size = new Size(470, 90);
            pnlStatTotal.TabIndex = 0;
            // 
            // lblTotalSalaryTitle
            // 
            lblTotalSalaryTitle.AutoSize = true;
            lblTotalSalaryTitle.Font = new Font("Segoe UI", 9F);
            lblTotalSalaryTitle.ForeColor = Color.FromArgb(160, 160, 166);
            lblTotalSalaryTitle.Location = new Point(18, 16);
            lblTotalSalaryTitle.Name = "lblTotalSalaryTitle";
            lblTotalSalaryTitle.Size = new Size(92, 15);
            lblTotalSalaryTitle.TabIndex = 0;
            lblTotalSalaryTitle.Text = "Tổng quỹ lương";
            // 
            // lblTotalSalary
            // 
            lblTotalSalary.AutoSize = true;
            lblTotalSalary.Font = new Font("Segoe UI", 17F, FontStyle.Bold);
            lblTotalSalary.ForeColor = Color.FromArgb(34, 197, 94);
            lblTotalSalary.Location = new Point(18, 40);
            lblTotalSalary.Name = "lblTotalSalary";
            lblTotalSalary.Size = new Size(48, 31);
            lblTotalSalary.TabIndex = 1;
            lblTotalSalary.Text = "0 đ";
            // 
            // pnlStatCount
            // 
            pnlStatCount.BackColor = Color.FromArgb(31, 31, 34);
            pnlStatCount.BorderRadius = 14;
            pnlStatCount.Controls.Add(lblEmployeeCountTitle);
            pnlStatCount.Controls.Add(lblEmployeeCount);
            pnlStatCount.CustomizableEdges = customizableEdges13;
            pnlStatCount.Dock = DockStyle.Fill;
            pnlStatCount.Location = new Point(480, 0);
            pnlStatCount.Margin = new Padding(0);
            pnlStatCount.Name = "pnlStatCount";
            pnlStatCount.ShadowDecoration.CustomizableEdges = customizableEdges14;
            pnlStatCount.Size = new Size(480, 90);
            pnlStatCount.TabIndex = 1;
            // 
            // lblEmployeeCountTitle
            // 
            lblEmployeeCountTitle.AutoSize = true;
            lblEmployeeCountTitle.Font = new Font("Segoe UI", 9F);
            lblEmployeeCountTitle.ForeColor = Color.FromArgb(160, 160, 166);
            lblEmployeeCountTitle.Location = new Point(18, 16);
            lblEmployeeCountTitle.Name = "lblEmployeeCountTitle";
            lblEmployeeCountTitle.Size = new Size(75, 15);
            lblEmployeeCountTitle.TabIndex = 0;
            lblEmployeeCountTitle.Text = "Số nhân viên";
            // 
            // lblEmployeeCount
            // 
            lblEmployeeCount.AutoSize = true;
            lblEmployeeCount.Font = new Font("Segoe UI", 17F, FontStyle.Bold);
            lblEmployeeCount.ForeColor = Color.FromArgb(31, 138, 154);
            lblEmployeeCount.Location = new Point(18, 40);
            lblEmployeeCount.Name = "lblEmployeeCount";
            lblEmployeeCount.Size = new Size(97, 31);
            lblEmployeeCount.TabIndex = 1;
            lblEmployeeCount.Text = "0 người";
            // 
            // pnlGrid
            // 
            pnlGrid.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnlGrid.BackColor = Color.FromArgb(31, 31, 34);
            pnlGrid.BorderRadius = 14;
            pnlGrid.Controls.Add(dgvPayroll);
            pnlGrid.CustomizableEdges = customizableEdges17;
            pnlGrid.Location = new Point(20, 210);
            pnlGrid.Name = "pnlGrid";
            pnlGrid.ShadowDecoration.CustomizableEdges = customizableEdges18;
            pnlGrid.Size = new Size(960, 435);
            pnlGrid.TabIndex = 2;
            // 
            // dgvPayroll
            // 
            dataGridViewCellStyle1.BackColor = Color.FromArgb(24, 24, 27);
            dataGridViewCellStyle1.ForeColor = Color.FromArgb(220, 220, 225);
            dgvPayroll.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvPayroll.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvPayroll.BackgroundColor = Color.FromArgb(24, 24, 27);
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(31, 31, 34);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(160, 160, 166);
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(31, 31, 34);
            dataGridViewCellStyle2.SelectionForeColor = Color.FromArgb(160, 160, 166);
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvPayroll.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvPayroll.Columns.AddRange(new DataGridViewColumn[] { colEmpId, colName, colDept, colWorkDays, colBaseSalary, colAllowance, colBonusFb, colBonusHoliday, colDeduction, colDeductReason, colTotalSalary });
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.FromArgb(24, 24, 27);
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(220, 220, 225);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(31, 138, 154);
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(240, 240, 245);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvPayroll.DefaultCellStyle = dataGridViewCellStyle3;
            dgvPayroll.GridColor = Color.FromArgb(45, 45, 48);
            dgvPayroll.Location = new Point(18, 18);
            dgvPayroll.Name = "dgvPayroll";
            dgvPayroll.RowHeadersVisible = false;
            dgvPayroll.Size = new Size(924, 399);
            dgvPayroll.TabIndex = 0;
            dgvPayroll.ThemeStyle.AlternatingRowsStyle.BackColor = Color.FromArgb(24, 24, 27);
            dgvPayroll.ThemeStyle.AlternatingRowsStyle.Font = null;
            dgvPayroll.ThemeStyle.AlternatingRowsStyle.ForeColor = Color.FromArgb(220, 220, 225);
            dgvPayroll.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.Empty;
            dgvPayroll.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.Empty;
            dgvPayroll.ThemeStyle.BackColor = Color.FromArgb(24, 24, 27);
            dgvPayroll.ThemeStyle.GridColor = Color.FromArgb(45, 45, 48);
            dgvPayroll.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(31, 31, 34);
            dgvPayroll.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvPayroll.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dgvPayroll.ThemeStyle.HeaderStyle.ForeColor = Color.FromArgb(160, 160, 166);
            dgvPayroll.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvPayroll.ThemeStyle.HeaderStyle.Height = 23;
            dgvPayroll.ThemeStyle.ReadOnly = false;
            dgvPayroll.ThemeStyle.RowsStyle.BackColor = Color.FromArgb(24, 24, 27);
            dgvPayroll.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvPayroll.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 9F);
            dgvPayroll.ThemeStyle.RowsStyle.ForeColor = Color.FromArgb(220, 220, 225);
            dgvPayroll.ThemeStyle.RowsStyle.Height = 25;
            dgvPayroll.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(31, 138, 154);
            dgvPayroll.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(240, 240, 245);
            dgvPayroll.CellDoubleClick += DgvPayroll_CellDoubleClick;
            dgvPayroll.SelectionChanged += dgvPayroll_SelectionChanged;
            // 
            // colEmpId
            // 
            colEmpId.DataPropertyName = "Mã NV";
            colEmpId.HeaderText = "Mã NV";
            colEmpId.Name = "colEmpId";
            // 
            // colName
            // 
            colName.DataPropertyName = "Họ tên";
            colName.HeaderText = "Họ tên";
            colName.Name = "colName";
            // 
            // colDept
            // 
            colDept.DataPropertyName = "Bộ phận";
            colDept.HeaderText = "Bộ phận";
            colDept.Name = "colDept";
            // 
            // colWorkDays
            // 
            colWorkDays.DataPropertyName = "Ngày công";
            colWorkDays.HeaderText = "Ngày công";
            colWorkDays.Name = "colWorkDays";
            // 
            // colBaseSalary
            // 
            colBaseSalary.DataPropertyName = "Lương CB";
            colBaseSalary.HeaderText = "Lương CB";
            colBaseSalary.Name = "colBaseSalary";
            // 
            // colAllowance
            // 
            colAllowance.DataPropertyName = "Phụ cấp";
            colAllowance.HeaderText = "Phụ cấp";
            colAllowance.Name = "colAllowance";
            // 
            // colBonusFb
            // 
            colBonusFb.DataPropertyName = "Thưởng FB";
            colBonusFb.HeaderText = "Thưởng FB";
            colBonusFb.Name = "colBonusFb";
            // 
            // colBonusHoliday
            // 
            colBonusHoliday.DataPropertyName = "Thưởng lễ";
            colBonusHoliday.HeaderText = "Thưởng lễ";
            colBonusHoliday.Name = "colBonusHoliday";
            // 
            // colDeduction
            // 
            colDeduction.DataPropertyName = "Trừ lương";
            colDeduction.HeaderText = "Trừ lương";
            colDeduction.Name = "colDeduction";
            // 
            // colDeductReason
            // 
            colDeductReason.DataPropertyName = "Lý do trừ";
            colDeductReason.HeaderText = "Lý do trừ";
            colDeductReason.Name = "colDeductReason";
            colDeductReason.Visible = false;
            // 
            // colTotalSalary
            // 
            colTotalSalary.DataPropertyName = "Tổng lương";
            colTotalSalary.HeaderText = "Tổng lương";
            colTotalSalary.Name = "colTotalSalary";
            // 
            // ucPayroll_Admin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(39, 39, 42);
            Controls.Add(pnlHeader);
            Controls.Add(pnlSummary);
            Controls.Add(pnlGrid);
            Name = "ucPayroll_Admin";
            Size = new Size(1000, 665);
            Load += ucPayroll_Admin_Load;
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            pnlSummary.ResumeLayout(false);
            tblSummary.ResumeLayout(false);
            pnlStatTotal.ResumeLayout(false);
            pnlStatTotal.PerformLayout();
            pnlStatCount.ResumeLayout(false);
            pnlStatCount.PerformLayout();
            pnlGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvPayroll).EndInit();
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
        private Guna2ComboBox cmbMonth;
        private Label lblMonth;
        private Guna2Button btnApplyBP;
        private Guna2Button btnLockDays;
        private Guna2Button btnEditPayroll;
        private Guna2Panel pnlSummary;
        private TableLayoutPanel tblSummary;
        private Guna2Panel pnlStatTotal;
        private Label lblTotalSalaryTitle;
        private Label lblTotalSalary;
        private Guna2Panel pnlStatCount;
        private Label lblEmployeeCountTitle;
        private Label lblEmployeeCount;
        private Guna2Panel pnlGrid;
        private Guna2DataGridView dgvPayroll;
        private DataGridViewTextBoxColumn colEmpId;
        private DataGridViewTextBoxColumn colName;
        private DataGridViewTextBoxColumn colDept;
        private DataGridViewTextBoxColumn colWorkDays;
        private DataGridViewTextBoxColumn colBaseSalary;
        private DataGridViewTextBoxColumn colAllowance;
        private DataGridViewTextBoxColumn colBonusFb;
        private DataGridViewTextBoxColumn colBonusHoliday;
        private DataGridViewTextBoxColumn colDeduction;
        private DataGridViewTextBoxColumn colDeductReason;
        private DataGridViewTextBoxColumn colTotalSalary;
    }
}
