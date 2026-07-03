using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace GUI
{
    partial class ucNotification_Admin
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
            lblUnreadCount = new Label();
            btnMarkAllRead = new Guna2Button();
            pnlNotifications = new Guna2Panel();
            dgvNotifications = new Guna2DataGridView();
            colId = new DataGridViewTextBoxColumn();
            colType = new DataGridViewTextBoxColumn();
            colFrom = new DataGridViewTextBoxColumn();
            colContent = new DataGridViewTextBoxColumn();
            colTime = new DataGridViewTextBoxColumn();
            colRead = new DataGridViewTextBoxColumn();
            colPage = new DataGridViewTextBoxColumn();
            pnlDetail = new Guna2Panel();
            lblDetailTitle = new Label();
            lblNotifType = new Label();
            lblNotifFrom = new Label();
            lblNotifTime = new Label();
            txtNotifContent = new Guna2TextBox();
            btnAccept = new Guna2Button();
            btnReject = new Guna2Button();
            btnGoToChat = new Guna2Button();
            pnlHeader.SuspendLayout();
            pnlNotifications.SuspendLayout();
            pnlDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvNotifications).BeginInit();
            SuspendLayout();

            // ====== pnlHeader ======
            pnlHeader.BackColor = Color.FromArgb(31, 31, 34);
            pnlHeader.BorderRadius = 14;
            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Controls.Add(lblUnreadCount);
            pnlHeader.Controls.Add(btnMarkAllRead);
            pnlHeader.Location = new Point(20, 20);
            pnlHeader.Size = new Size(960, 60);
            pnlHeader.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(18, 18);
            lblTitle.Text = "Thông báo";

            lblUnreadCount.AutoSize = true;
            lblUnreadCount.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblUnreadCount.ForeColor = Color.FromArgb(220, 80, 80);
            lblUnreadCount.Location = new Point(180, 23);
            lblUnreadCount.Text = "0 chưa đọc";

            btnMarkAllRead.BorderColor = Color.FromArgb(80, 80, 90);
            btnMarkAllRead.BorderRadius = 8;
            btnMarkAllRead.BorderThickness = 1;
            btnMarkAllRead.Cursor = Cursors.Hand;
            btnMarkAllRead.FillColor = Color.Transparent;
            btnMarkAllRead.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnMarkAllRead.ForeColor = Color.FromArgb(220, 220, 225);
            btnMarkAllRead.HoverState.FillColor = Color.FromArgb(45, 45, 50);
            btnMarkAllRead.Location = new Point(800, 14);
            btnMarkAllRead.Size = new Size(140, 30);
            btnMarkAllRead.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnMarkAllRead.Text = "Đọc tất cả";
            btnMarkAllRead.Click += BtnMarkAllRead_Click;

            // ====== pnlNotifications ======
            pnlNotifications.BackColor = Color.FromArgb(31, 31, 34);
            pnlNotifications.BorderRadius = 14;
            pnlNotifications.Controls.Add(dgvNotifications);
            pnlNotifications.Location = new Point(20, 95);
            pnlNotifications.Size = new Size(960, 290);
            pnlNotifications.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

            dgvNotifications.BackgroundColor = Color.FromArgb(24, 24, 27);
            dgvNotifications.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(31, 31, 34);
            dgvNotifications.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(160, 160, 166);
            dgvNotifications.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dgvNotifications.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(31, 31, 34);
            dgvNotifications.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.FromArgb(160, 160, 166);
            dgvNotifications.DefaultCellStyle.BackColor = Color.FromArgb(24, 24, 27);
            dgvNotifications.DefaultCellStyle.ForeColor = Color.FromArgb(220, 220, 225);
            dgvNotifications.DefaultCellStyle.SelectionBackColor = Color.FromArgb(31, 138, 154);
            dgvNotifications.DefaultCellStyle.SelectionForeColor = Color.FromArgb(240, 240, 245);
            dgvNotifications.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(24, 24, 27);
            dgvNotifications.AlternatingRowsDefaultCellStyle.ForeColor = Color.FromArgb(220, 220, 225);
            dgvNotifications.GridColor = Color.FromArgb(45, 45, 48);
            ConfigureGrid(dgvNotifications);            dgvNotifications.Columns.AddRange(new DataGridViewColumn[] { colId, colType, colFrom, colContent, colTime, colRead, colPage });
            colId.HeaderText = "ID"; colId.Name = "ID"; colId.DataPropertyName = "ID"; colId.Visible = false;
            colType.HeaderText = "Loại"; colType.Name = "Loại"; colType.DataPropertyName = "Loại";
            colFrom.HeaderText = "Từ"; colFrom.Name = "Từ"; colFrom.DataPropertyName = "Từ";
            colContent.HeaderText = "Nội dung"; colContent.Name = "Nội dung"; colContent.DataPropertyName = "Nội dung";
            colTime.HeaderText = "Thời gian"; colTime.Name = "Thời gian"; colTime.DataPropertyName = "Thời gian";
            colRead.HeaderText = "Đã đọc"; colRead.Name = "Đã đọc"; colRead.DataPropertyName = "Đã đọc"; colRead.Visible = false;
            colPage.HeaderText = "Trang liên quan"; colPage.Name = "Trang liên quan"; colPage.DataPropertyName = "Trang liên quan"; colPage.Visible = false;
            dgvNotifications.Location = new Point(18, 18);
            dgvNotifications.Size = new Size(924, 254);
            dgvNotifications.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvNotifications.SelectionChanged += DgvNotifications_SelectionChanged;
            dgvNotifications.CellDoubleClick += DgvNotifications_CellDoubleClick;

            // ====== pnlDetail ======
            pnlDetail.BackColor = Color.FromArgb(31, 31, 34);
            pnlDetail.BorderRadius = 14;
            pnlDetail.Controls.Add(lblDetailTitle);
            pnlDetail.Controls.Add(lblNotifType);
            pnlDetail.Controls.Add(lblNotifFrom);
            pnlDetail.Controls.Add(lblNotifTime);
            pnlDetail.Controls.Add(txtNotifContent);
            pnlDetail.Controls.Add(btnAccept);
            pnlDetail.Controls.Add(btnReject);
            pnlDetail.Controls.Add(btnGoToChat);
            pnlDetail.Location = new Point(20, 400);
            pnlDetail.Size = new Size(960, 245);
            pnlDetail.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            lblDetailTitle.AutoSize = true;
            lblDetailTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblDetailTitle.ForeColor = Color.White;
            lblDetailTitle.Location = new Point(18, 16);
            lblDetailTitle.Text = "Chi tiết thông báo";

            lblNotifType.AutoSize = true;
            lblNotifType.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblNotifType.ForeColor = Color.FromArgb(245, 158, 11);
            lblNotifType.Location = new Point(18, 50);
            lblNotifType.Text = "Loại: ---";

            lblNotifFrom.AutoSize = true;
            lblNotifFrom.Font = new Font("Segoe UI", 9.5F);
            lblNotifFrom.ForeColor = Color.FromArgb(31, 138, 154);
            lblNotifFrom.Location = new Point(180, 52);
            lblNotifFrom.Text = "Từ: ---";

            lblNotifTime.AutoSize = true;
            lblNotifTime.Font = new Font("Segoe UI", 9F);
            lblNotifTime.ForeColor = Color.FromArgb(160, 160, 166);
            lblNotifTime.Location = new Point(380, 53);
            lblNotifTime.Text = "";

            txtNotifContent.BorderColor = Color.FromArgb(63, 63, 70);
            txtNotifContent.BorderRadius = 8;
            txtNotifContent.FillColor = Color.FromArgb(24, 24, 27);
            txtNotifContent.Font = new Font("Segoe UI", 10F);
            txtNotifContent.ForeColor = Color.FromArgb(220, 220, 225);
            txtNotifContent.Location = new Point(18, 84);
            txtNotifContent.Multiline = true;
            txtNotifContent.PasswordChar = '\0';
            txtNotifContent.ReadOnly = true;
            txtNotifContent.Size = new Size(700, 143);
            txtNotifContent.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            btnAccept.BorderRadius = 10;
            btnAccept.Cursor = Cursors.Hand;
            btnAccept.FillColor = Color.FromArgb(34, 197, 94);
            btnAccept.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnAccept.ForeColor = Color.White;
            btnAccept.HoverState.FillColor = Color.FromArgb(50, 217, 110);
            btnAccept.Location = new Point(740, 84);
            btnAccept.Size = new Size(95, 38);
            btnAccept.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAccept.Text = "Duyệt";
            btnAccept.Click += BtnAccept_Click;

            btnReject.BorderRadius = 10;
            btnReject.Cursor = Cursors.Hand;
            btnReject.FillColor = Color.FromArgb(220, 80, 80);
            btnReject.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnReject.ForeColor = Color.White;
            btnReject.HoverState.FillColor = Color.FromArgb(240, 100, 100);
            btnReject.Location = new Point(845, 84);
            btnReject.Size = new Size(95, 38);
            btnReject.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnReject.Text = "Từ chối";
            btnReject.Click += BtnReject_Click;

            btnGoToChat.BorderRadius = 10;
            btnGoToChat.Cursor = Cursors.Hand;
            btnGoToChat.FillColor = Color.FromArgb(31, 138, 154);
            btnGoToChat.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnGoToChat.ForeColor = Color.White;
            btnGoToChat.HoverState.FillColor = Color.FromArgb(45, 158, 174);
            btnGoToChat.Location = new Point(740, 132);
            btnGoToChat.Size = new Size(200, 38);
            btnGoToChat.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnGoToChat.Text = "Chat với quản lý";
            btnGoToChat.Click += BtnGoToChat_Click;

            // ====== ucNotification_Admin ======
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(39, 39, 42);
            Controls.Add(pnlHeader);
            Controls.Add(pnlNotifications);
            Controls.Add(pnlDetail);
            Name = "ucNotification_Admin";
            Size = new Size(1000, 665);
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            pnlNotifications.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvNotifications).EndInit();
            pnlDetail.ResumeLayout(false);
            pnlDetail.PerformLayout();
            this.Load += UcNotification_Admin_Load;
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
        private Label lblUnreadCount;
        private Guna2Button btnMarkAllRead;
        private Guna2Panel pnlNotifications;
        private Guna2DataGridView dgvNotifications;
        private DataGridViewTextBoxColumn colId;
        private DataGridViewTextBoxColumn colType;
        private DataGridViewTextBoxColumn colFrom;
        private DataGridViewTextBoxColumn colContent;
        private DataGridViewTextBoxColumn colTime;
        private DataGridViewTextBoxColumn colRead;
        private DataGridViewTextBoxColumn colPage;
        private Guna2Panel pnlDetail;
        private Label lblDetailTitle;
        private Label lblNotifType;
        private Label lblNotifFrom;
        private Label lblNotifTime;
        private Guna2TextBox txtNotifContent;
        private Guna2Button btnAccept;
        private Guna2Button btnReject;
        private Guna2Button btnGoToChat;
    }
}
