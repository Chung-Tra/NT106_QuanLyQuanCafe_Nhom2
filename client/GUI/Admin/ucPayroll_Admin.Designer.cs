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

            // ====== pnlHeader ======
            pnlHeader.BackColor = Color.FromArgb(31, 31, 34);
            pnlHeader.BorderRadius = 14;
            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Controls.Add(lblMonth);
            pnlHeader.Controls.Add(cmbMonth);
            pnlHeader.Controls.Add(btnApplyBP);
            pnlHeader.Controls.Add(btnLockDays);
            pnlHeader.Controls.Add(btnEditPayroll);
            pnlHeader.Location = new Point(20, 20);
            pnlHeader.Size = new Size(960, 70);
            pnlHeader.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(18, 22);
            lblTitle.Text = "Bảng lương nhân viên";

            lblMonth.AutoSize = true;
            lblMonth.Font = new Font("Segoe UI", 9.5F);
            lblMonth.ForeColor = Color.FromArgb(160, 160, 166);
            lblMonth.Location = new Point(450, 27);
            lblMonth.Text = "Tháng:";

            cmbMonth.BackColor = Color.Transparent;
            cmbMonth.BorderColor = Color.FromArgb(63, 63, 70);
            cmbMonth.BorderRadius = 8;
            cmbMonth.DrawMode = DrawMode.OwnerDrawFixed;
            cmbMonth.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMonth.FillColor = Color.FromArgb(24, 24, 27);
            cmbMonth.FocusedColor = Color.FromArgb(31, 138, 154);
            cmbMonth.FocusedState.BorderColor = Color.FromArgb(31, 138, 154);
            cmbMonth.Font = new Font("Segoe UI", 9.5F);
            cmbMonth.ForeColor = Color.White;
            cmbMonth.HoverState.BorderColor = Color.FromArgb(120, 120, 130);
            cmbMonth.ItemHeight = 26;
            cmbMonth.Items.AddRange(new object[] {
                "Tháng 1", "Tháng 2", "Tháng 3", "Tháng 4", "Tháng 5", "Tháng 6",
                "Tháng 7", "Tháng 8", "Tháng 9", "Tháng 10", "Tháng 11", "Tháng 12" });
            cmbMonth.Location = new Point(508, 21);
            cmbMonth.Size = new Size(150, 28);
            cmbMonth.SelectedIndexChanged += cmbMonth_SelectedIndexChanged;

            btnApplyBP.BorderRadius = 10;
            btnApplyBP.Cursor = Cursors.Hand;
            btnApplyBP.FillColor = Color.FromArgb(31, 138, 154);
            btnApplyBP.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnApplyBP.ForeColor = Color.White;
            btnApplyBP.HoverState.FillColor = Color.FromArgb(45, 158, 174);
            btnApplyBP.Location = new Point(818, 18);
            btnApplyBP.Size = new Size(130, 34);
            btnApplyBP.Text = "Tính lương";
            btnApplyBP.Click += btnApplyBP_Click;

            // btnLockDays — đếm ngày công từ chấm công (node cham_cong) rồi ghi vào bảng lương
            btnLockDays.BorderRadius = 10;
            btnLockDays.Cursor = Cursors.Hand;
            btnLockDays.FillColor = Color.FromArgb(245, 158, 11);
            btnLockDays.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnLockDays.ForeColor = Color.White;
            btnLockDays.HoverState.FillColor = Color.FromArgb(255, 178, 40);
            btnLockDays.Location = new Point(668, 18);
            btnLockDays.Size = new Size(140, 34);
            btnLockDays.Text = "Chốt công";
            btnLockDays.Click += BtnLockDays_Click;

            btnEditPayroll.BorderColor = Color.FromArgb(80, 80, 90);
            btnEditPayroll.BorderRadius = 10;
            btnEditPayroll.BorderThickness = 1;
            btnEditPayroll.Cursor = Cursors.Hand;
            btnEditPayroll.FillColor = Color.Transparent;
            btnEditPayroll.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnEditPayroll.ForeColor = Color.FromArgb(220, 220, 225);
            btnEditPayroll.HoverState.FillColor = Color.FromArgb(45, 45, 50);
            btnEditPayroll.Location = new Point(290, 18);
            btnEditPayroll.Name = "btnEditPayroll";
            btnEditPayroll.Size = new Size(150, 34);
            btnEditPayroll.Text = "Sửa dòng chọn";
            btnEditPayroll.Click += BtnEditPayroll_Click;

            // ====== pnlSummary ======
            pnlSummary.BackColor = Color.Transparent;
            pnlSummary.Controls.Add(tblSummary);
            pnlSummary.Location = new Point(20, 105);
            pnlSummary.Size = new Size(960, 90);
            pnlSummary.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

            // tblSummary — 2 thẻ chia đôi 50%, hết hở giữa khi phóng to
            tblSummary.BackColor = Color.Transparent;
            tblSummary.ColumnCount = 2;
            tblSummary.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tblSummary.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tblSummary.Controls.Add(pnlStatTotal, 0, 0);
            tblSummary.Controls.Add(pnlStatCount, 1, 0);
            tblSummary.Dock = DockStyle.Fill;
            tblSummary.RowCount = 1;
            tblSummary.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));

            // -- pnlStatTotal --
            pnlStatTotal.BackColor = Color.FromArgb(31, 31, 34);
            pnlStatTotal.BorderRadius = 14;
            pnlStatTotal.Controls.Add(lblTotalSalaryTitle);
            pnlStatTotal.Controls.Add(lblTotalSalary);
            pnlStatTotal.Dock = DockStyle.Fill;
            pnlStatTotal.Margin = new Padding(0, 0, 10, 0);
            lblTotalSalaryTitle.AutoSize = true;
            lblTotalSalaryTitle.Font = new Font("Segoe UI", 9F);
            lblTotalSalaryTitle.ForeColor = Color.FromArgb(160, 160, 166);
            lblTotalSalaryTitle.Location = new Point(18, 16);
            lblTotalSalaryTitle.Text = "Tổng quỹ lương";
            lblTotalSalary.AutoSize = true;
            lblTotalSalary.Font = new Font("Segoe UI", 17F, FontStyle.Bold);
            lblTotalSalary.ForeColor = Color.FromArgb(34, 197, 94);
            lblTotalSalary.Location = new Point(18, 40);
            lblTotalSalary.Text = "0 đ";

            // -- pnlStatCount --
            pnlStatCount.BackColor = Color.FromArgb(31, 31, 34);
            pnlStatCount.BorderRadius = 14;
            pnlStatCount.Controls.Add(lblEmployeeCountTitle);
            pnlStatCount.Controls.Add(lblEmployeeCount);
            pnlStatCount.Dock = DockStyle.Fill;
            pnlStatCount.Margin = new Padding(0, 0, 0, 0);
            lblEmployeeCountTitle.AutoSize = true;
            lblEmployeeCountTitle.Font = new Font("Segoe UI", 9F);
            lblEmployeeCountTitle.ForeColor = Color.FromArgb(160, 160, 166);
            lblEmployeeCountTitle.Location = new Point(18, 16);
            lblEmployeeCountTitle.Text = "Số nhân viên";
            lblEmployeeCount.AutoSize = true;
            lblEmployeeCount.Font = new Font("Segoe UI", 17F, FontStyle.Bold);
            lblEmployeeCount.ForeColor = Color.FromArgb(31, 138, 154);
            lblEmployeeCount.Location = new Point(18, 40);
            lblEmployeeCount.Text = "0 người";

            // ====== pnlGrid ======
            pnlGrid.BackColor = Color.FromArgb(31, 31, 34);
            pnlGrid.BorderRadius = 14;
            pnlGrid.Controls.Add(dgvPayroll);
            pnlGrid.Location = new Point(20, 210);
            pnlGrid.Size = new Size(960, 435);
            pnlGrid.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            dgvPayroll.BackgroundColor = Color.FromArgb(24, 24, 27);
            dgvPayroll.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(31, 31, 34);
            dgvPayroll.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(160, 160, 166);
            dgvPayroll.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dgvPayroll.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(31, 31, 34);
            dgvPayroll.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.FromArgb(160, 160, 166);
            dgvPayroll.DefaultCellStyle.BackColor = Color.FromArgb(24, 24, 27);
            dgvPayroll.DefaultCellStyle.ForeColor = Color.FromArgb(220, 220, 225);
            dgvPayroll.DefaultCellStyle.SelectionBackColor = Color.FromArgb(31, 138, 154);
            dgvPayroll.DefaultCellStyle.SelectionForeColor = Color.FromArgb(240, 240, 245);
            dgvPayroll.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(24, 24, 27);
            dgvPayroll.AlternatingRowsDefaultCellStyle.ForeColor = Color.FromArgb(220, 220, 225);
            dgvPayroll.GridColor = Color.FromArgb(45, 45, 48);
            ConfigureGrid(dgvPayroll);            dgvPayroll.Columns.AddRange(new DataGridViewColumn[] { colEmpId, colName, colDept, colWorkDays, colBaseSalary, colAllowance, colBonusFb, colBonusHoliday, colDeduction, colDeductReason, colTotalSalary });
            colEmpId.HeaderText = "Mã NV"; colEmpId.Name = "Mã NV"; colEmpId.DataPropertyName = "Mã NV";
            colName.HeaderText = "Họ tên"; colName.Name = "Họ tên"; colName.DataPropertyName = "Họ tên";
            colDept.HeaderText = "Bộ phận"; colDept.Name = "Bộ phận"; colDept.DataPropertyName = "Bộ phận";
            colWorkDays.HeaderText = "Ngày công"; colWorkDays.Name = "Ngày công"; colWorkDays.DataPropertyName = "Ngày công";
            colBaseSalary.HeaderText = "Lương CB"; colBaseSalary.Name = "Lương CB"; colBaseSalary.DataPropertyName = "Lương CB";
            colAllowance.HeaderText = "Phụ cấp"; colAllowance.Name = "Phụ cấp"; colAllowance.DataPropertyName = "Phụ cấp";
            colBonusFb.HeaderText = "Thưởng FB"; colBonusFb.Name = "Thưởng FB"; colBonusFb.DataPropertyName = "Thưởng FB";
            colBonusHoliday.HeaderText = "Thưởng lễ"; colBonusHoliday.Name = "Thưởng lễ"; colBonusHoliday.DataPropertyName = "Thưởng lễ";
            colDeduction.HeaderText = "Trừ lương"; colDeduction.Name = "Trừ lương"; colDeduction.DataPropertyName = "Trừ lương";
            colDeductReason.HeaderText = "Lý do trừ"; colDeductReason.Name = "Lý do trừ"; colDeductReason.DataPropertyName = "Lý do trừ";
            colTotalSalary.HeaderText = "Tổng lương"; colTotalSalary.Name = "Tổng lương"; colTotalSalary.DataPropertyName = "Tổng lương";
            dgvPayroll.Location = new Point(18, 18);
            dgvPayroll.Size = new Size(924, 399);
            dgvPayroll.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvPayroll.SelectionChanged += dgvPayroll_SelectionChanged;
            dgvPayroll.CellDoubleClick += DgvPayroll_CellDoubleClick;

            // ====== ucPayroll_Admin ======
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
