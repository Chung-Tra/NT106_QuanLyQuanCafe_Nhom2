using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace GUI
{
    partial class ManagerProfileDetail
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            dgvManagers = new Guna2DataGridView();
            colMgrId = new DataGridViewTextBoxColumn();
            colMgrName = new DataGridViewTextBoxColumn();
            colMgrEmail = new DataGridViewTextBoxColumn();
            colMgrPhone = new DataGridViewTextBoxColumn();
            colMgrJoinDate = new DataGridViewTextBoxColumn();
            colMgrStatus = new DataGridViewTextBoxColumn();
            colMgrMonthOrders = new DataGridViewTextBoxColumn();
            btnClose    = new Guna2Button();
            lblTitle    = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvManagers).BeginInit();
            SuspendLayout();

            // lblTitle
            lblTitle.Text      = "Hồ sơ đầy đủ Quản lý";
            lblTitle.Font      = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.AutoSize  = true;
            lblTitle.Location  = new Point(20, 18);

            // dgvManagers
            dgvManagers.AllowUserToAddRows    = false;
            dgvManagers.ReadOnly              = true;
            dgvManagers.RowHeadersVisible     = false;
            dgvManagers.SelectionMode         = DataGridViewSelectionMode.FullRowSelect;
            DgvDarkScroll.Apply(dgvManagers);
            dgvManagers.ScrollBars            = ScrollBars.None;
            dgvManagers.BorderStyle           = BorderStyle.None;
            dgvManagers.CellBorderStyle       = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvManagers.BackgroundColor       = Color.FromArgb(31, 31, 34);
            dgvManagers.GridColor             = Color.FromArgb(63, 63, 70);
            dgvManagers.RowTemplate.Height    = 32;
            dgvManagers.EnableHeadersVisualStyles = false;
            dgvManagers.DefaultCellStyle.BackColor          = Color.FromArgb(31, 31, 34);
            dgvManagers.DefaultCellStyle.ForeColor          = Color.FromArgb(220, 220, 225);
            dgvManagers.DefaultCellStyle.SelectionBackColor = Color.FromArgb(31, 138, 154);
            dgvManagers.DefaultCellStyle.SelectionForeColor = Color.FromArgb(240, 240, 245);
            dgvManagers.DefaultCellStyle.Font               = new Font("Segoe UI", 9F);
            dgvManagers.ColumnHeadersDefaultCellStyle.BackColor          = Color.FromArgb(24, 24, 27);
            dgvManagers.ColumnHeadersDefaultCellStyle.ForeColor          = Color.FromArgb(160, 160, 166);
            dgvManagers.ColumnHeadersDefaultCellStyle.Font               = new Font("Segoe UI", 9F, FontStyle.Bold);
            dgvManagers.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(24, 24, 27);
            dgvManagers.Location = new Point(20, 58);
            dgvManagers.Size     = new Size(820, 340);            dgvManagers.Columns.AddRange(new DataGridViewColumn[] { colMgrId, colMgrName, colMgrEmail, colMgrPhone, colMgrJoinDate, colMgrStatus, colMgrMonthOrders });
            colMgrId.HeaderText = "Mã QL"; colMgrId.Name = "Mã QL"; colMgrId.DataPropertyName = "Mã QL";
            colMgrName.HeaderText = "Họ tên"; colMgrName.Name = "Họ tên"; colMgrName.DataPropertyName = "Họ tên";
            colMgrEmail.HeaderText = "Email"; colMgrEmail.Name = "Email"; colMgrEmail.DataPropertyName = "Email";
            colMgrPhone.HeaderText = "SĐT"; colMgrPhone.Name = "SĐT"; colMgrPhone.DataPropertyName = "SĐT";
            colMgrJoinDate.HeaderText = "Ngày vào"; colMgrJoinDate.Name = "Ngày vào"; colMgrJoinDate.DataPropertyName = "Ngày vào";
            colMgrStatus.HeaderText = "Trạng thái"; colMgrStatus.Name = "Trạng thái"; colMgrStatus.DataPropertyName = "Trạng thái";
            colMgrMonthOrders.HeaderText = "Đơn tháng này"; colMgrMonthOrders.Name = "Đơn tháng này"; colMgrMonthOrders.DataPropertyName = "Đơn tháng này";

            // btnClose
            btnClose.Text        = "Đóng";
            btnClose.Size        = new Size(100, 36);
            btnClose.Location    = new Point(740, 414);
            btnClose.BorderRadius = 8;
            btnClose.Cursor      = Cursors.Hand;
            btnClose.FillColor   = Color.FromArgb(31, 138, 154);
            btnClose.ForeColor   = Color.White;
            btnClose.Font        = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnClose.HoverState.FillColor = Color.FromArgb(45, 158, 174);
            btnClose.Click      += btnClose_Click;

            // Form
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode       = AutoScaleMode.Font;
            BackColor           = Color.FromArgb(31, 31, 34);
            ClientSize          = new System.Drawing.Size(860, 464);
            FormBorderStyle     = FormBorderStyle.None;
            StartPosition       = FormStartPosition.CenterParent;
            Controls.Add(lblTitle);
            Controls.Add(dgvManagers);
            Controls.Add(btnClose);

            ((System.ComponentModel.ISupportInitialize)dgvManagers).EndInit();
            ResumeLayout(false);
        }

        private Guna2DataGridView dgvManagers;
        private DataGridViewTextBoxColumn colMgrId;
        private DataGridViewTextBoxColumn colMgrName;
        private DataGridViewTextBoxColumn colMgrEmail;
        private DataGridViewTextBoxColumn colMgrPhone;
        private DataGridViewTextBoxColumn colMgrJoinDate;
        private DataGridViewTextBoxColumn colMgrStatus;
        private DataGridViewTextBoxColumn colMgrMonthOrders;
        private Guna2Button       btnClose;
        private Label             lblTitle;
    }
}
