using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace GUI
{
    partial class ucNotification_Manager
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
            pnlPendingRequests = new Guna2Panel();
            lblPendingTitle = new Label();
            dgvPendingLeave = new Guna2DataGridView();
            btnApprove = new Guna2Button();
            btnReject = new Guna2Button();
            btnChatStaff = new Guna2Button();
            pnlSchedule = new Guna2Panel();
            lblScheduleTitle = new Label();
            dgvSchedule = new Guna2DataGridView();
            btnSaveSchedule = new Guna2Button();
            pnlPendingRequests.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPendingLeave).BeginInit();
            pnlSchedule.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSchedule).BeginInit();
            SuspendLayout();

            // ====== pnlPendingRequests ======
            pnlPendingRequests.BackColor = Color.FromArgb(31, 31, 34);
            pnlPendingRequests.BorderRadius = 14;
            pnlPendingRequests.Controls.Add(lblPendingTitle);
            pnlPendingRequests.Controls.Add(dgvPendingLeave);
            pnlPendingRequests.Controls.Add(btnApprove);
            pnlPendingRequests.Controls.Add(btnReject);
            pnlPendingRequests.Controls.Add(btnChatStaff);
            pnlPendingRequests.Location = new Point(20, 20);
            pnlPendingRequests.Size = new Size(960, 310);

            // lblPendingTitle
            lblPendingTitle.AutoSize = true;
            lblPendingTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblPendingTitle.ForeColor = Color.FromArgb(245, 158, 11);
            lblPendingTitle.Location = new Point(18, 16);
            lblPendingTitle.Text = "📋  Đơn xin nghỉ chờ duyệt";

            // dgvPendingLeave
            dgvPendingLeave.BackgroundColor = Color.FromArgb(24, 24, 27);
            dgvPendingLeave.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(31, 31, 34);
            dgvPendingLeave.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(160, 160, 166);
            dgvPendingLeave.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dgvPendingLeave.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(31, 31, 34);
            dgvPendingLeave.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.FromArgb(160, 160, 166);
            dgvPendingLeave.DefaultCellStyle.BackColor = Color.FromArgb(24, 24, 27);
            dgvPendingLeave.DefaultCellStyle.ForeColor = Color.FromArgb(220, 220, 225);
            dgvPendingLeave.DefaultCellStyle.SelectionBackColor = Color.FromArgb(31, 138, 154);
            dgvPendingLeave.DefaultCellStyle.SelectionForeColor = Color.FromArgb(240, 240, 245);
            dgvPendingLeave.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(24, 24, 27);
            dgvPendingLeave.AlternatingRowsDefaultCellStyle.ForeColor = Color.FromArgb(220, 220, 225);
            dgvPendingLeave.GridColor = Color.FromArgb(45, 45, 48);
            ConfigureGrid(dgvPendingLeave);
            dgvPendingLeave.Location = new Point(18, 54);
            dgvPendingLeave.Size = new Size(720, 240);
            dgvPendingLeave.SelectionChanged += dgvPendingLeave_SelectionChanged;

            // btnApprove
            btnApprove.BorderRadius = 10;
            btnApprove.Cursor = Cursors.Hand;
            btnApprove.FillColor = Color.FromArgb(34, 197, 94);
            btnApprove.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnApprove.ForeColor = Color.White;
            btnApprove.HoverState.FillColor = Color.FromArgb(50, 210, 110);
            btnApprove.Location = new Point(758, 54);
            btnApprove.Size = new Size(184, 44);
            btnApprove.Text = "✓  Duyệt";
            btnApprove.Click += btnApprove_Click;

            // btnReject
            btnReject.BorderColor = Color.FromArgb(180, 60, 60);
            btnReject.BorderRadius = 10;
            btnReject.BorderThickness = 1;
            btnReject.Cursor = Cursors.Hand;
            btnReject.FillColor = Color.Transparent;
            btnReject.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnReject.ForeColor = Color.FromArgb(220, 80, 80);
            btnReject.HoverState.FillColor = Color.FromArgb(180, 60, 60);
            btnReject.HoverState.ForeColor = Color.White;
            btnReject.Location = new Point(758, 110);
            btnReject.Size = new Size(184, 44);
            btnReject.Text = "✕ Từ chối";
            btnReject.Click += btnReject_Click;

            // btnChatStaff
            btnChatStaff.BorderRadius = 10;
            btnChatStaff.Cursor = Cursors.Hand;
            btnChatStaff.FillColor = Color.FromArgb(31, 138, 154);
            btnChatStaff.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnChatStaff.ForeColor = Color.White;
            btnChatStaff.HoverState.FillColor = Color.FromArgb(45, 158, 174);
            btnChatStaff.Location = new Point(758, 166);
            btnChatStaff.Size = new Size(184, 44);
            btnChatStaff.Text = "💬  Chat";
            btnChatStaff.Click += btnChatStaff_Click;

            // ====== pnlSchedule ======
            pnlSchedule.BackColor = Color.FromArgb(31, 31, 34);
            pnlSchedule.BorderRadius = 14;
            pnlSchedule.Controls.Add(lblScheduleTitle);
            pnlSchedule.Controls.Add(dgvSchedule);
            pnlSchedule.Controls.Add(btnSaveSchedule);
            pnlSchedule.Location = new Point(20, 340);
            pnlSchedule.Size = new Size(960, 310);

            // lblScheduleTitle
            lblScheduleTitle.AutoSize = true;
            lblScheduleTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblScheduleTitle.ForeColor = Color.White;
            lblScheduleTitle.Location = new Point(18, 16);
            lblScheduleTitle.Text = "📅  Xếp lịch làm việc tuần";

            // dgvSchedule
            dgvSchedule.BackgroundColor = Color.FromArgb(24, 24, 27);
            dgvSchedule.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(31, 31, 34);
            dgvSchedule.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(160, 160, 166);
            dgvSchedule.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dgvSchedule.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(31, 31, 34);
            dgvSchedule.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.FromArgb(160, 160, 166);
            dgvSchedule.DefaultCellStyle.BackColor = Color.FromArgb(24, 24, 27);
            dgvSchedule.DefaultCellStyle.ForeColor = Color.FromArgb(220, 220, 225);
            dgvSchedule.DefaultCellStyle.SelectionBackColor = Color.FromArgb(31, 138, 154);
            dgvSchedule.DefaultCellStyle.SelectionForeColor = Color.FromArgb(240, 240, 245);
            dgvSchedule.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(24, 24, 27);
            dgvSchedule.AlternatingRowsDefaultCellStyle.ForeColor = Color.FromArgb(220, 220, 225);
            dgvSchedule.GridColor = Color.FromArgb(45, 45, 48);
            ConfigureGrid(dgvSchedule);
            dgvSchedule.ReadOnly = false;
            dgvSchedule.Location = new Point(18, 54);
            dgvSchedule.Size = new Size(720, 240);
            dgvSchedule.CellValueChanged += dgvSchedule_CellValueChanged;

            // btnSaveSchedule
            btnSaveSchedule.BorderRadius = 10;
            btnSaveSchedule.Cursor = Cursors.Hand;
            btnSaveSchedule.FillColor = Color.FromArgb(34, 197, 94);
            btnSaveSchedule.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnSaveSchedule.ForeColor = Color.White;
            btnSaveSchedule.HoverState.FillColor = Color.FromArgb(50, 210, 110);
            btnSaveSchedule.Location = new Point(758, 54);
            btnSaveSchedule.Size = new Size(184, 44);
            btnSaveSchedule.Text = "💾  Lưu lịch";
            btnSaveSchedule.Click += btnSaveSchedule_Click;

            // ====== ucNotification_Manager ======
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(39, 39, 42);
            Controls.Add(pnlPendingRequests);
            Controls.Add(pnlSchedule);
            Name = "ucNotification_Manager";
            Size = new Size(1000, 665);
            pnlPendingRequests.ResumeLayout(false);
            pnlPendingRequests.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPendingLeave).EndInit();
            pnlSchedule.ResumeLayout(false);
            pnlSchedule.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSchedule).EndInit();
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

        private Guna2Panel pnlPendingRequests;
        private Label lblPendingTitle;
        private Guna2DataGridView dgvPendingLeave;
        private Guna2Button btnApprove;
        private Guna2Button btnReject;
        private Guna2Button btnChatStaff;
        private Guna2Panel pnlSchedule;
        private Label lblScheduleTitle;
        private Guna2DataGridView dgvSchedule;
        private Guna2Button btnSaveSchedule;
    }
}
