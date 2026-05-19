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
            pnlSummary = new Guna2Panel();
            pnlStatTotal = new Guna2Panel();
            lblTotalSalaryTitle = new Label();
            lblTotalSalary = new Label();
            pnlStatCount = new Guna2Panel();
            lblEmployeeCountTitle = new Label();
            lblEmployeeCount = new Label();
            pnlGrid = new Guna2Panel();
            dgvPayroll = new Guna2DataGridView();
            pnlHeader.SuspendLayout();
            pnlSummary.SuspendLayout();
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
            pnlHeader.Location = new Point(20, 20);
            pnlHeader.Size = new Size(920, 70);

            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(18, 22);
            lblTitle.Text = "💰  Bảng lương nhân viên";

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
            btnApplyBP.Location = new Point(690, 18);
            btnApplyBP.Size = new Size(210, 34);
            btnApplyBP.Text = "⚡  Tính lương tự động";
            btnApplyBP.Click += btnApplyBP_Click;

            // ====== pnlSummary ======
            pnlSummary.BackColor = Color.Transparent;
            pnlSummary.Controls.Add(pnlStatTotal);
            pnlSummary.Controls.Add(pnlStatCount);
            pnlSummary.Location = new Point(20, 105);
            pnlSummary.Size = new Size(920, 90);

            // -- pnlStatTotal --
            pnlStatTotal.BackColor = Color.FromArgb(31, 31, 34);
            pnlStatTotal.BorderRadius = 14;
            pnlStatTotal.Controls.Add(lblTotalSalaryTitle);
            pnlStatTotal.Controls.Add(lblTotalSalary);
            pnlStatTotal.Location = new Point(0, 0);
            pnlStatTotal.Size = new Size(455, 90);
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
            pnlStatCount.Location = new Point(465, 0);
            pnlStatCount.Size = new Size(455, 90);
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
            pnlGrid.Size = new Size(920, 430);

            ConfigureGrid(dgvPayroll);
            dgvPayroll.Location = new Point(18, 18);
            dgvPayroll.Size = new Size(884, 394);
            dgvPayroll.SelectionChanged += dgvPayroll_SelectionChanged;

            // ====== ucPayroll_Admin ======
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(39, 39, 42);
            Controls.Add(pnlHeader);
            Controls.Add(pnlSummary);
            Controls.Add(pnlGrid);
            Name = "ucPayroll_Admin";
            Size = new Size(960, 660);
            Load += ucPayroll_Admin_Load;
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            pnlSummary.ResumeLayout(false);
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
            dgv.DefaultCellStyle.SelectionForeColor = Color.White;
            dgv.EnableHeadersVisualStyles = false;
            dgv.GridColor = Color.FromArgb(45, 45, 48);
            dgv.MultiSelect = false;
            dgv.ReadOnly = true;
            dgv.RowHeadersVisible = false;
            dgv.RowTemplate.Height = 28;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        #endregion

        private Guna2Panel pnlHeader;
        private Label lblTitle;
        private Guna2ComboBox cmbMonth;
        private Label lblMonth;
        private Guna2Button btnApplyBP;
        private Guna2Panel pnlSummary;
        private Guna2Panel pnlStatTotal;
        private Label lblTotalSalaryTitle;
        private Label lblTotalSalary;
        private Guna2Panel pnlStatCount;
        private Label lblEmployeeCountTitle;
        private Label lblEmployeeCount;
        private Guna2Panel pnlGrid;
        private Guna2DataGridView dgvPayroll;
    }
}
