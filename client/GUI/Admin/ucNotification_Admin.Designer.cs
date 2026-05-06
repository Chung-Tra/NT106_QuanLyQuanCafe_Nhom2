using System.Drawing;
using System.Windows.Forms;

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
            DataGridViewCellStyle dgvStyle = new DataGridViewCellStyle();
            pnlHeader = new Panel();
            lblTitle = new Label();
            lblUnreadCount = new Label();
            btnMarkAllRead = new Button();
            pnlNotifications = new Panel();
            dgvNotifications = new DataGridView();
            pnlDetail = new Panel();
            lblDetailTitle = new Label();
            lblNotifType = new Label();
            lblNotifFrom = new Label();
            lblNotifTime = new Label();
            txtNotifContent = new TextBox();
            btnAccept = new Button();
            btnReject = new Button();
            btnGoToChat = new Button();
            btnGoToPage = new Button();
            pnlHeader.SuspendLayout();
            pnlNotifications.SuspendLayout();
            pnlDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvNotifications).BeginInit();
            SuspendLayout();

            // === HEADER ===
            pnlHeader.BackColor = Color.FromArgb(30, 30, 30);
            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Controls.Add(lblUnreadCount);
            pnlHeader.Controls.Add(btnMarkAllRead);
            pnlHeader.Location = new Point(20, 10);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(764, 45);

            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(12, 10);
            lblTitle.Name = "lblTitle";
            lblTitle.Text = "Thông báo";

            lblUnreadCount.AutoSize = true;
            lblUnreadCount.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblUnreadCount.ForeColor = Color.IndianRed;
            lblUnreadCount.Location = new Point(160, 14);
            lblUnreadCount.Name = "lblUnreadCount";
            lblUnreadCount.Text = "5 chưa đọc";

            btnMarkAllRead.BackColor = Color.FromArgb(60, 60, 65);
            btnMarkAllRead.FlatAppearance.BorderSize = 0;
            btnMarkAllRead.FlatStyle = FlatStyle.Flat;
            btnMarkAllRead.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            btnMarkAllRead.ForeColor = Color.White;
            btnMarkAllRead.Location = new Point(610, 8);
            btnMarkAllRead.Name = "btnMarkAllRead";
            btnMarkAllRead.Size = new Size(140, 28);
            btnMarkAllRead.Text = "Đọc tất cả";
            btnMarkAllRead.Cursor = Cursors.Hand;
            btnMarkAllRead.Click += btnMarkAllRead_Click;

            // === NOTIFICATIONS GRID ===
            pnlNotifications.BackColor = Color.FromArgb(30, 30, 30);
            pnlNotifications.Controls.Add(dgvNotifications);
            pnlNotifications.Location = new Point(20, 62);
            pnlNotifications.Name = "pnlNotifications";
            pnlNotifications.Size = new Size(764, 230);

            dgvStyle.BackColor = Color.FromArgb(45, 45, 48);
            dgvStyle.Font = new Font("Segoe UI", 9F);
            dgvStyle.ForeColor = Color.White;
            dgvStyle.SelectionBackColor = Color.FromArgb(60, 60, 65);
            dgvStyle.SelectionForeColor = Color.White;

            dgvNotifications.AllowUserToAddRows = false;
            dgvNotifications.BackgroundColor = Color.FromArgb(45, 45, 48);
            dgvNotifications.BorderStyle = BorderStyle.None;
            dgvNotifications.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvNotifications.DefaultCellStyle = dgvStyle;
            dgvNotifications.Location = new Point(12, 10);
            dgvNotifications.Name = "dgvNotifications";
            dgvNotifications.ReadOnly = true;
            dgvNotifications.RowHeadersVisible = false;
            dgvNotifications.RowHeadersWidth = 51;
            dgvNotifications.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvNotifications.Size = new Size(740, 210);
            dgvNotifications.SelectionChanged += dgvNotifications_SelectionChanged;
            dgvNotifications.CellDoubleClick += dgvNotifications_CellDoubleClick;

            // === DETAIL PANEL ===
            pnlDetail.BackColor = Color.FromArgb(30, 30, 30);
            pnlDetail.Controls.Add(lblDetailTitle);
            pnlDetail.Controls.Add(lblNotifType);
            pnlDetail.Controls.Add(lblNotifFrom);
            pnlDetail.Controls.Add(lblNotifTime);
            pnlDetail.Controls.Add(txtNotifContent);
            pnlDetail.Controls.Add(btnAccept);
            pnlDetail.Controls.Add(btnReject);
            pnlDetail.Controls.Add(btnGoToChat);
            pnlDetail.Controls.Add(btnGoToPage);
            pnlDetail.Location = new Point(20, 300);
            pnlDetail.Name = "pnlDetail";
            pnlDetail.Size = new Size(764, 220);

            lblDetailTitle.AutoSize = true;
            lblDetailTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblDetailTitle.ForeColor = Color.White;
            lblDetailTitle.Location = new Point(12, 10);
            lblDetailTitle.Name = "lblDetailTitle";
            lblDetailTitle.Text = "Chi tiết thông báo";

            lblNotifType.AutoSize = true;
            lblNotifType.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblNotifType.ForeColor = Color.Orange;
            lblNotifType.Location = new Point(12, 38);
            lblNotifType.Name = "lblNotifType";
            lblNotifType.Text = "Loại: ---";

            lblNotifFrom.AutoSize = true;
            lblNotifFrom.Font = new Font("Segoe UI", 9.5F);
            lblNotifFrom.ForeColor = Color.SteelBlue;
            lblNotifFrom.Location = new Point(200, 40);
            lblNotifFrom.Name = "lblNotifFrom";
            lblNotifFrom.Text = "Từ: ---";

            lblNotifTime.AutoSize = true;
            lblNotifTime.Font = new Font("Segoe UI", 9F);
            lblNotifTime.ForeColor = Color.Gray;
            lblNotifTime.Location = new Point(400, 40);
            lblNotifTime.Name = "lblNotifTime";
            lblNotifTime.Text = "";

            txtNotifContent.BackColor = Color.FromArgb(50, 50, 55);
            txtNotifContent.BorderStyle = BorderStyle.None;
            txtNotifContent.Font = new Font("Segoe UI", 10F);
            txtNotifContent.ForeColor = Color.White;
            txtNotifContent.Location = new Point(12, 65);
            txtNotifContent.Multiline = true;
            txtNotifContent.Name = "txtNotifContent";
            txtNotifContent.ReadOnly = true;
            txtNotifContent.Size = new Size(530, 70);

            // Buttons
            btnAccept.BackColor = Color.MediumSeaGreen;
            btnAccept.FlatAppearance.BorderSize = 0;
            btnAccept.FlatStyle = FlatStyle.Flat;
            btnAccept.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnAccept.ForeColor = Color.White;
            btnAccept.Location = new Point(560, 65);
            btnAccept.Name = "btnAccept";
            btnAccept.Size = new Size(90, 32);
            btnAccept.Text = "Duyệt";
            btnAccept.Cursor = Cursors.Hand;
            btnAccept.Click += btnAccept_Click;

            btnReject.BackColor = Color.IndianRed;
            btnReject.FlatAppearance.BorderSize = 0;
            btnReject.FlatStyle = FlatStyle.Flat;
            btnReject.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnReject.ForeColor = Color.White;
            btnReject.Location = new Point(660, 65);
            btnReject.Name = "btnReject";
            btnReject.Size = new Size(90, 32);
            btnReject.Text = "Từ chối";
            btnReject.Cursor = Cursors.Hand;
            btnReject.Click += btnReject_Click;

            btnGoToChat.BackColor = Color.SteelBlue;
            btnGoToChat.FlatAppearance.BorderSize = 0;
            btnGoToChat.FlatStyle = FlatStyle.Flat;
            btnGoToChat.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnGoToChat.ForeColor = Color.White;
            btnGoToChat.Location = new Point(560, 105);
            btnGoToChat.Name = "btnGoToChat";
            btnGoToChat.Size = new Size(190, 32);
            btnGoToChat.Text = "Chat với quản lý";
            btnGoToChat.Cursor = Cursors.Hand;
            btnGoToChat.Click += btnGoToChat_Click;

            btnGoToPage.BackColor = Color.FromArgb(70, 70, 75);
            btnGoToPage.FlatAppearance.BorderSize = 0;
            btnGoToPage.FlatStyle = FlatStyle.Flat;
            btnGoToPage.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnGoToPage.ForeColor = Color.White;
            btnGoToPage.Location = new Point(560, 145);
            btnGoToPage.Name = "btnGoToPage";
            btnGoToPage.Size = new Size(190, 32);
            btnGoToPage.Text = "Đi tới trang liên quan";
            btnGoToPage.Cursor = Cursors.Hand;
            btnGoToPage.Click += btnGoToPage_Click;

            // === MAIN ===
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(45, 45, 48);
            Controls.Add(pnlDetail);
            Controls.Add(pnlNotifications);
            Controls.Add(pnlHeader);
            Name = "ucNotification_Admin";
            Size = new Size(804, 530);
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            pnlNotifications.ResumeLayout(false);
            pnlDetail.ResumeLayout(false);
            pnlDetail.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvNotifications).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlHeader;
        private Label lblTitle;
        private Label lblUnreadCount;
        private Button btnMarkAllRead;
        private Panel pnlNotifications;
        private DataGridView dgvNotifications;
        private Panel pnlDetail;
        private Label lblDetailTitle;
        private Label lblNotifType;
        private Label lblNotifFrom;
        private Label lblNotifTime;
        private TextBox txtNotifContent;
        private Button btnAccept;
        private Button btnReject;
        private Button btnGoToChat;
        private Button btnGoToPage;
    }
}
