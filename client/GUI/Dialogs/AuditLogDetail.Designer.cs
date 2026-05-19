using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace GUI
{
    partial class AuditLogDetail
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            dgvAuditLog = new Guna2DataGridView();
            btnClose    = new Guna2Button();
            lblTitle    = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvAuditLog).BeginInit();
            SuspendLayout();

            // lblTitle
            lblTitle.Text      = "🔔  Lịch sử thao tác của Quản lý";
            lblTitle.Font      = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(245, 158, 11);
            lblTitle.AutoSize  = true;
            lblTitle.Location  = new Point(20, 18);

            // dgvAuditLog
            dgvAuditLog.AllowUserToAddRows    = false;
            dgvAuditLog.ReadOnly              = true;
            dgvAuditLog.RowHeadersVisible     = false;
            dgvAuditLog.SelectionMode         = DataGridViewSelectionMode.FullRowSelect;
            dgvAuditLog.ScrollBars            = ScrollBars.None;
            dgvAuditLog.BorderStyle           = BorderStyle.None;
            dgvAuditLog.CellBorderStyle       = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvAuditLog.BackgroundColor       = Color.FromArgb(28, 28, 30);
            dgvAuditLog.GridColor             = Color.FromArgb(50, 50, 54);
            dgvAuditLog.RowTemplate.Height    = 32;
            dgvAuditLog.EnableHeadersVisualStyles = false;
            dgvAuditLog.DefaultCellStyle.BackColor          = Color.FromArgb(28, 28, 30);
            dgvAuditLog.DefaultCellStyle.ForeColor          = Color.FromArgb(220, 220, 225);
            dgvAuditLog.DefaultCellStyle.SelectionBackColor = Color.FromArgb(31, 138, 154);
            dgvAuditLog.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvAuditLog.DefaultCellStyle.Font               = new Font("Segoe UI", 9F);
            dgvAuditLog.ColumnHeadersDefaultCellStyle.BackColor          = Color.FromArgb(35, 35, 38);
            dgvAuditLog.ColumnHeadersDefaultCellStyle.ForeColor          = Color.FromArgb(245, 158, 11);
            dgvAuditLog.ColumnHeadersDefaultCellStyle.Font               = new Font("Segoe UI", 9F, FontStyle.Bold);
            dgvAuditLog.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(35, 35, 38);
            dgvAuditLog.Location = new Point(20, 58);
            dgvAuditLog.Size     = new Size(820, 340);

            // btnClose
            btnClose.Text         = "Đóng";
            btnClose.Size         = new Size(100, 36);
            btnClose.Location     = new Point(740, 414);
            btnClose.BorderRadius = 8;
            btnClose.Cursor       = Cursors.Hand;
            btnClose.FillColor    = Color.FromArgb(31, 138, 154);
            btnClose.ForeColor    = Color.White;
            btnClose.Font         = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnClose.HoverState.FillColor = Color.FromArgb(45, 158, 174);
            btnClose.Click       += btnClose_Click;

            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode       = AutoScaleMode.Font;
            BackColor           = Color.FromArgb(31, 31, 34);
            ClientSize          = new System.Drawing.Size(860, 464);
            FormBorderStyle     = FormBorderStyle.None;
            StartPosition       = FormStartPosition.CenterParent;
            Controls.Add(lblTitle);
            Controls.Add(dgvAuditLog);
            Controls.Add(btnClose);

            ((System.ComponentModel.ISupportInitialize)dgvAuditLog).EndInit();
            ResumeLayout(false);
        }

        private Guna2DataGridView dgvAuditLog;
        private Guna2Button       btnClose;
        private Label             lblTitle;
    }
}
