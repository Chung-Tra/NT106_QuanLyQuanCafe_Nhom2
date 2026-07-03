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
            tblRows = new TableLayoutPanel();
            pnlPendingRequests = new Guna2Panel();
            lblPendingTitle = new Label();
            dgvPendingLeave = new Guna2DataGridView();
            colLeaveStaff = new DataGridViewTextBoxColumn();
            colLeaveRole = new DataGridViewTextBoxColumn();
            colLeaveDate = new DataGridViewTextBoxColumn();
            colLeaveReason = new DataGridViewTextBoxColumn();
            colLeaveStatus = new DataGridViewTextBoxColumn();
            btnApprove = new Guna2Button();
            btnReject = new Guna2Button();
            btnChatStaff = new Guna2Button();
            btnEditLeave = new Guna2Button();
            pnlSchedule = new Guna2Panel();
            lblScheduleTitle = new Label();
            dgvSchedule = new Guna2DataGridView();
            colSchStaff = new DataGridViewTextBoxColumn();
            colSchT2 = new DataGridViewTextBoxColumn();
            colSchT3 = new DataGridViewTextBoxColumn();
            colSchT4 = new DataGridViewTextBoxColumn();
            colSchT5 = new DataGridViewTextBoxColumn();
            colSchT6 = new DataGridViewTextBoxColumn();
            colSchT7 = new DataGridViewTextBoxColumn();
            colSchCN = new DataGridViewTextBoxColumn();
            btnSaveSchedule = new Guna2Button();
            tblRows.SuspendLayout();
            pnlPendingRequests.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPendingLeave).BeginInit();
            pnlSchedule.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSchedule).BeginInit();
            SuspendLayout();

            // ====== tblRows — 2 hàng 50/50 giãn theo cả hai chiều ======
            tblRows.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tblRows.ColumnCount = 1;
            tblRows.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tblRows.RowCount = 2;
            tblRows.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tblRows.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tblRows.Location = new Point(20, 20);
            tblRows.Size = new Size(960, 630);
            tblRows.Controls.Add(pnlPendingRequests, 0, 0);
            tblRows.Controls.Add(pnlSchedule, 0, 1);

            // ====== pnlPendingRequests ======
            pnlPendingRequests.BackColor = Color.FromArgb(31, 31, 34);
            pnlPendingRequests.BorderRadius = 14;
            pnlPendingRequests.Controls.Add(lblPendingTitle);
            pnlPendingRequests.Controls.Add(dgvPendingLeave);
            pnlPendingRequests.Controls.Add(btnApprove);
            pnlPendingRequests.Controls.Add(btnReject);
            pnlPendingRequests.Controls.Add(btnChatStaff);
            pnlPendingRequests.Controls.Add(btnEditLeave);
            pnlPendingRequests.Dock = DockStyle.Fill;
            pnlPendingRequests.Margin = new Padding(0, 0, 0, 5);
            // Giữ Size thiết kế để con neo (Anchor) tính đúng khoảng bù trước khi TLP giãn
            pnlPendingRequests.Size = new Size(960, 310);

            // lblPendingTitle
            lblPendingTitle.AutoSize = true;
            lblPendingTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblPendingTitle.ForeColor = Color.FromArgb(245, 158, 11);
            lblPendingTitle.Location = new Point(18, 16);
            lblPendingTitle.Text = "Đơn xin nghỉ chờ duyệt";

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
            ConfigureGrid(dgvPendingLeave);            dgvPendingLeave.Columns.AddRange(new DataGridViewColumn[] { colLeaveStaff, colLeaveRole, colLeaveDate, colLeaveReason, colLeaveStatus });
            colLeaveStaff.HeaderText = "Nhân viên"; colLeaveStaff.Name = "Nhân viên"; colLeaveStaff.DataPropertyName = "Nhân viên";
            colLeaveRole.HeaderText = "Chức vụ"; colLeaveRole.Name = "Chức vụ"; colLeaveRole.DataPropertyName = "Chức vụ";
            colLeaveDate.HeaderText = "Ngày nghỉ"; colLeaveDate.Name = "Ngày nghỉ"; colLeaveDate.DataPropertyName = "Ngày nghỉ";
            colLeaveReason.HeaderText = "Lý do"; colLeaveReason.Name = "Lý do"; colLeaveReason.DataPropertyName = "Lý do";
            colLeaveStatus.HeaderText = "Trạng thái"; colLeaveStatus.Name = "Trạng thái"; colLeaveStatus.DataPropertyName = "Trạng thái";
            dgvPendingLeave.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvPendingLeave.Location = new Point(18, 54);
            dgvPendingLeave.Size = new Size(720, 240);
            dgvPendingLeave.SelectionChanged += dgvPendingLeave_SelectionChanged;
            dgvPendingLeave.CellDoubleClick += DgvPendingLeave_CellDoubleClick;

            // btnApprove
            btnApprove.BorderRadius = 10;
            btnApprove.Cursor = Cursors.Hand;
            btnApprove.FillColor = Color.FromArgb(34, 197, 94);
            btnApprove.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnApprove.ForeColor = Color.White;
            btnApprove.HoverState.FillColor = Color.FromArgb(50, 210, 110);
            btnApprove.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnApprove.Location = new Point(758, 54);
            btnApprove.Size = new Size(184, 44);
            btnApprove.Text = "Duyệt";
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
            btnReject.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnReject.Location = new Point(758, 110);
            btnReject.Size = new Size(184, 44);
            btnReject.Text = "Từ chối";
            btnReject.Click += btnReject_Click;

            // btnChatStaff
            btnChatStaff.BorderRadius = 10;
            btnChatStaff.Cursor = Cursors.Hand;
            btnChatStaff.FillColor = Color.FromArgb(31, 138, 154);
            btnChatStaff.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnChatStaff.ForeColor = Color.White;
            btnChatStaff.HoverState.FillColor = Color.FromArgb(45, 158, 174);
            btnChatStaff.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnChatStaff.Location = new Point(758, 166);
            btnChatStaff.Size = new Size(184, 44);
            btnChatStaff.Text = "Chat";
            btnChatStaff.Click += btnChatStaff_Click;

            // btnEditLeave
            btnEditLeave.BorderColor = Color.FromArgb(80, 80, 90);
            btnEditLeave.BorderRadius = 10;
            btnEditLeave.BorderThickness = 1;
            btnEditLeave.Cursor = Cursors.Hand;
            btnEditLeave.FillColor = Color.Transparent;
            btnEditLeave.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnEditLeave.ForeColor = Color.FromArgb(220, 220, 225);
            btnEditLeave.HoverState.FillColor = Color.FromArgb(45, 45, 50);
            btnEditLeave.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnEditLeave.Location = new Point(758, 222);
            btnEditLeave.Name = "btnEditLeave";
            btnEditLeave.Size = new Size(184, 44);
            btnEditLeave.Text = "Sửa dòng chọn";
            btnEditLeave.Click += BtnEditLeave_Click;

            // ====== pnlSchedule ======
            pnlSchedule.BackColor = Color.FromArgb(31, 31, 34);
            pnlSchedule.BorderRadius = 14;
            pnlSchedule.Controls.Add(lblScheduleTitle);
            pnlSchedule.Controls.Add(dgvSchedule);
            pnlSchedule.Controls.Add(btnSaveSchedule);
            pnlSchedule.Dock = DockStyle.Fill;
            pnlSchedule.Margin = new Padding(0, 5, 0, 0);
            pnlSchedule.Size = new Size(960, 310);

            // lblScheduleTitle
            lblScheduleTitle.AutoSize = true;
            lblScheduleTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblScheduleTitle.ForeColor = Color.White;
            lblScheduleTitle.Location = new Point(18, 16);
            lblScheduleTitle.Text = "Xếp lịch làm việc tuần";

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
            ConfigureGrid(dgvSchedule);            dgvSchedule.Columns.AddRange(new DataGridViewColumn[] { colSchStaff, colSchT2, colSchT3, colSchT4, colSchT5, colSchT6, colSchT7, colSchCN });
            colSchStaff.HeaderText = "Nhân viên"; colSchStaff.Name = "Nhân viên"; colSchStaff.DataPropertyName = "Nhân viên";
            colSchT2.HeaderText = "T2"; colSchT2.Name = "T2"; colSchT2.DataPropertyName = "T2";
            colSchT3.HeaderText = "T3"; colSchT3.Name = "T3"; colSchT3.DataPropertyName = "T3";
            colSchT4.HeaderText = "T4"; colSchT4.Name = "T4"; colSchT4.DataPropertyName = "T4";
            colSchT5.HeaderText = "T5"; colSchT5.Name = "T5"; colSchT5.DataPropertyName = "T5";
            colSchT6.HeaderText = "T6"; colSchT6.Name = "T6"; colSchT6.DataPropertyName = "T6";
            colSchT7.HeaderText = "T7"; colSchT7.Name = "T7"; colSchT7.DataPropertyName = "T7";
            colSchCN.HeaderText = "CN"; colSchCN.Name = "CN"; colSchCN.DataPropertyName = "CN";
            dgvSchedule.ReadOnly = false;
            dgvSchedule.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
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
            btnSaveSchedule.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSaveSchedule.Location = new Point(758, 54);
            btnSaveSchedule.Size = new Size(184, 44);
            btnSaveSchedule.Text = "Lưu lịch";
            btnSaveSchedule.Click += btnSaveSchedule_Click;

            // ====== ucNotification_Manager ======
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(39, 39, 42);
            Controls.Add(tblRows);
            Name = "ucNotification_Manager";
            Size = new Size(1000, 665);
            pnlPendingRequests.ResumeLayout(false);
            pnlPendingRequests.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPendingLeave).EndInit();
            pnlSchedule.ResumeLayout(false);
            pnlSchedule.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSchedule).EndInit();
            tblRows.ResumeLayout(false);
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

        private TableLayoutPanel tblRows;
        private Guna2Panel pnlPendingRequests;
        private Label lblPendingTitle;
        private Guna2DataGridView dgvPendingLeave;
        private DataGridViewTextBoxColumn colLeaveStaff;
        private DataGridViewTextBoxColumn colLeaveRole;
        private DataGridViewTextBoxColumn colLeaveDate;
        private DataGridViewTextBoxColumn colLeaveReason;
        private DataGridViewTextBoxColumn colLeaveStatus;
        private Guna2Button btnApprove;
        private Guna2Button btnReject;
        private Guna2Button btnChatStaff;
        private Guna2Button btnEditLeave;
        private Guna2Panel pnlSchedule;
        private Label lblScheduleTitle;
        private Guna2DataGridView dgvSchedule;
        private DataGridViewTextBoxColumn colSchStaff;
        private DataGridViewTextBoxColumn colSchT2;
        private DataGridViewTextBoxColumn colSchT3;
        private DataGridViewTextBoxColumn colSchT4;
        private DataGridViewTextBoxColumn colSchT5;
        private DataGridViewTextBoxColumn colSchT6;
        private DataGridViewTextBoxColumn colSchT7;
        private DataGridViewTextBoxColumn colSchCN;
        private Guna2Button btnSaveSchedule;
    }
}
