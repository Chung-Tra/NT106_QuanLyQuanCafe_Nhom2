using System.Drawing;
using System.Windows.Forms;

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
            DataGridViewCellStyle dgvStyle = new DataGridViewCellStyle();
            pnlHeader = new Panel();
            lblTitle = new Label();
            cmbMonth = new ComboBox();
            lblMonth = new Label();
            btnApplyBP = new Button();
            pnlSummary = new Panel();
            lblTotalSalary = new Label();
            lblTotalSalaryTitle = new Label();
            lblEmployeeCount = new Label();
            lblEmployeeCountTitle = new Label();
            pnlGrid = new Panel();
            dgvPayroll = new DataGridView();
            pnlHeader.SuspendLayout();
            pnlSummary.SuspendLayout();
            pnlGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPayroll).BeginInit();
            SuspendLayout();
            //
            // pnlHeader
            //
            pnlHeader.BackColor = Color.FromArgb(30, 30, 30);
            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Controls.Add(cmbMonth);
            pnlHeader.Controls.Add(lblMonth);
            pnlHeader.Controls.Add(btnApplyBP);
            pnlHeader.Location = new Point(20, 15);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(764, 55);
            pnlHeader.TabIndex = 0;
            //
            // lblTitle
            //
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(15, 14);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(180, 25);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Bảng lương nhân viên";
            //
            // lblMonth
            //
            lblMonth.AutoSize = true;
            lblMonth.Font = new Font("Segoe UI", 10F);
            lblMonth.ForeColor = Color.Gray;
            lblMonth.Location = new Point(350, 18);
            lblMonth.Name = "lblMonth";
            lblMonth.Size = new Size(50, 19);
            lblMonth.TabIndex = 1;
            lblMonth.Text = "Tháng:";
            //
            // cmbMonth
            //
            cmbMonth.BackColor = Color.FromArgb(45, 45, 48);
            cmbMonth.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMonth.FlatStyle = FlatStyle.Flat;
            cmbMonth.Font = new Font("Segoe UI", 10F);
            cmbMonth.ForeColor = Color.White;
            cmbMonth.Items.AddRange(new object[] { "Tháng 1", "Tháng 2", "Tháng 3", "Tháng 4", "Tháng 5", "Tháng 6", "Tháng 7", "Tháng 8", "Tháng 9", "Tháng 10", "Tháng 11", "Tháng 12" });
            cmbMonth.Location = new Point(410, 15);
            cmbMonth.Name = "cmbMonth";
            cmbMonth.Size = new Size(130, 25);
            cmbMonth.TabIndex = 2;
            cmbMonth.SelectedIndexChanged += cmbMonth_SelectedIndexChanged;
            //
            // btnApplyBP
            //
            btnApplyBP.BackColor = Color.MediumSeaGreen;
            btnApplyBP.Cursor = Cursors.Hand;
            btnApplyBP.FlatAppearance.BorderSize = 0;
            btnApplyBP.FlatStyle = FlatStyle.Flat;
            btnApplyBP.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            btnApplyBP.ForeColor = Color.White;
            btnApplyBP.Location = new Point(570, 12);
            btnApplyBP.Name = "btnApplyBP";
            btnApplyBP.Size = new Size(175, 32);
            btnApplyBP.TabIndex = 3;
            btnApplyBP.Text = "Tính lương tự động";
            btnApplyBP.UseVisualStyleBackColor = false;
            btnApplyBP.Click += btnApplyBP_Click;
            //
            // pnlSummary
            //
            pnlSummary.BackColor = Color.FromArgb(30, 30, 30);
            pnlSummary.Controls.Add(lblTotalSalary);
            pnlSummary.Controls.Add(lblTotalSalaryTitle);
            pnlSummary.Controls.Add(lblEmployeeCount);
            pnlSummary.Controls.Add(lblEmployeeCountTitle);
            pnlSummary.Location = new Point(20, 80);
            pnlSummary.Name = "pnlSummary";
            pnlSummary.Size = new Size(764, 65);
            pnlSummary.TabIndex = 1;
            //
            // lblTotalSalaryTitle
            //
            lblTotalSalaryTitle.AutoSize = true;
            lblTotalSalaryTitle.Font = new Font("Segoe UI", 9.75F);
            lblTotalSalaryTitle.ForeColor = Color.Gray;
            lblTotalSalaryTitle.Location = new Point(20, 10);
            lblTotalSalaryTitle.Name = "lblTotalSalaryTitle";
            lblTotalSalaryTitle.Size = new Size(100, 17);
            lblTotalSalaryTitle.TabIndex = 0;
            lblTotalSalaryTitle.Text = "Tổng quỹ lương";
            //
            // lblTotalSalary
            //
            lblTotalSalary.AutoSize = true;
            lblTotalSalary.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold);
            lblTotalSalary.ForeColor = Color.MediumSeaGreen;
            lblTotalSalary.Location = new Point(20, 30);
            lblTotalSalary.Name = "lblTotalSalary";
            lblTotalSalary.Size = new Size(160, 30);
            lblTotalSalary.TabIndex = 1;
            lblTotalSalary.Text = "125,000,000 đ";
            //
            // lblEmployeeCountTitle
            //
            lblEmployeeCountTitle.AutoSize = true;
            lblEmployeeCountTitle.Font = new Font("Segoe UI", 9.75F);
            lblEmployeeCountTitle.ForeColor = Color.Gray;
            lblEmployeeCountTitle.Location = new Point(400, 10);
            lblEmployeeCountTitle.Name = "lblEmployeeCountTitle";
            lblEmployeeCountTitle.Size = new Size(100, 17);
            lblEmployeeCountTitle.TabIndex = 2;
            lblEmployeeCountTitle.Text = "Số nhân viên";
            //
            // lblEmployeeCount
            //
            lblEmployeeCount.AutoSize = true;
            lblEmployeeCount.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold);
            lblEmployeeCount.ForeColor = Color.SteelBlue;
            lblEmployeeCount.Location = new Point(400, 30);
            lblEmployeeCount.Name = "lblEmployeeCount";
            lblEmployeeCount.Size = new Size(80, 30);
            lblEmployeeCount.TabIndex = 3;
            lblEmployeeCount.Text = "12 người";
            //
            // pnlGrid
            //
            pnlGrid.BackColor = Color.FromArgb(30, 30, 30);
            pnlGrid.Controls.Add(dgvPayroll);
            pnlGrid.Location = new Point(20, 155);
            pnlGrid.Name = "pnlGrid";
            pnlGrid.Size = new Size(764, 360);
            pnlGrid.TabIndex = 2;
            //
            // dgvPayroll
            //
            dgvPayroll.AllowUserToAddRows = false;
            dgvPayroll.AllowUserToDeleteRows = false;
            dgvPayroll.BackgroundColor = Color.FromArgb(45, 45, 48);
            dgvPayroll.BorderStyle = BorderStyle.None;
            dgvPayroll.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvStyle.BackColor = Color.FromArgb(45, 45, 48);
            dgvStyle.Font = new Font("Segoe UI", 9F);
            dgvStyle.ForeColor = Color.White;
            dgvStyle.SelectionBackColor = Color.Gray;
            dgvStyle.SelectionForeColor = Color.White;
            dgvStyle.WrapMode = DataGridViewTriState.False;
            dgvPayroll.DefaultCellStyle = dgvStyle;
            dgvPayroll.Location = new Point(15, 15);
            dgvPayroll.Name = "dgvPayroll";
            dgvPayroll.ReadOnly = true;
            dgvPayroll.RowHeadersWidth = 51;
            dgvPayroll.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPayroll.Size = new Size(734, 330);
            dgvPayroll.TabIndex = 0;
            dgvPayroll.SelectionChanged += dgvPayroll_SelectionChanged;
            //
            // ucPayroll_Admin
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(45, 45, 48);
            Controls.Add(pnlGrid);
            Controls.Add(pnlSummary);
            Controls.Add(pnlHeader);
            Name = "ucPayroll_Admin";
            Size = new Size(804, 530);
            Load += ucPayroll_Admin_Load;
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            pnlSummary.ResumeLayout(false);
            pnlSummary.PerformLayout();
            pnlGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvPayroll).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlHeader;
        private Label lblTitle;
        private ComboBox cmbMonth;
        private Label lblMonth;
        private Button btnApplyBP;
        private Panel pnlSummary;
        private Label lblTotalSalaryTitle;
        private Label lblTotalSalary;
        private Label lblEmployeeCountTitle;
        private Label lblEmployeeCount;
        private Panel pnlGrid;
        private DataGridView dgvPayroll;
    }
}
