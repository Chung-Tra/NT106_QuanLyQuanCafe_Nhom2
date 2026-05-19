using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace GUI
{
    partial class ucInternalChat
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges17 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges18 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges15 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges16 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges21 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges22 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges19 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges20 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges27 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges28 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges23 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges24 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges25 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges26 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            pnlLeft = new Guna2Panel();
            lblChatTitle = new Label();
            lblContactsHint = new Label();
            cmbChatTarget = new ComboBox();
            btnBroadcast = new Guna2Button();
            pnlRight = new Panel();
            pnlChatHeader = new Guna2Panel();
            lblCurrentChat = new Label();
            btnOpenChatWindow = new Guna2Button();
            pnlInputBar = new Guna2Panel();
            txtMessage = new Guna2TextBox();
            btnSend = new Guna2Button();
            lstChatHistory = new ListBox();
            pnlLeft.SuspendLayout();
            pnlRight.SuspendLayout();
            pnlChatHeader.SuspendLayout();
            pnlInputBar.SuspendLayout();
            SuspendLayout();
            // 
            // pnlLeft
            // 
            pnlLeft.BackColor = Color.FromArgb(24, 24, 27);
            pnlLeft.Controls.Add(lblChatTitle);
            pnlLeft.Controls.Add(lblContactsHint);
            pnlLeft.Controls.Add(cmbChatTarget);
            pnlLeft.Controls.Add(btnBroadcast);
            pnlLeft.CustomizableEdges = customizableEdges17;
            pnlLeft.Dock = DockStyle.Left;
            pnlLeft.Location = new Point(0, 0);
            pnlLeft.Name = "pnlLeft";
            pnlLeft.ShadowDecoration.CustomizableEdges = customizableEdges18;
            pnlLeft.Size = new Size(230, 648);
            pnlLeft.TabIndex = 1;
            // 
            // lblChatTitle
            // 
            lblChatTitle.AutoSize = true;
            lblChatTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblChatTitle.ForeColor = Color.White;
            lblChatTitle.Location = new Point(16, 20);
            lblChatTitle.Name = "lblChatTitle";
            lblChatTitle.Size = new Size(129, 21);
            lblChatTitle.TabIndex = 0;
            lblChatTitle.Text = "💭  Chat nội bộ";
            // 
            // lblContactsHint
            // 
            lblContactsHint.AutoSize = true;
            lblContactsHint.Font = new Font("Segoe UI", 7.5F, FontStyle.Bold);
            lblContactsHint.ForeColor = Color.FromArgb(100, 100, 108);
            lblContactsHint.Location = new Point(16, 60);
            lblContactsHint.Name = "lblContactsHint";
            lblContactsHint.Size = new Size(106, 12);
            lblContactsHint.TabIndex = 1;
            lblContactsHint.Text = "CHỌN NGƯỜI NHẬN";
            // 
            // cmbChatTarget
            // 
            cmbChatTarget.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cmbChatTarget.BackColor = Color.FromArgb(38, 38, 42);
            cmbChatTarget.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbChatTarget.FlatStyle = FlatStyle.Flat;
            cmbChatTarget.Font = new Font("Segoe UI", 9.5F);
            cmbChatTarget.ForeColor = Color.White;
            cmbChatTarget.IntegralHeight = false;
            cmbChatTarget.Location = new Point(12, 82);
            cmbChatTarget.MaxDropDownItems = 12;
            cmbChatTarget.Name = "cmbChatTarget";
            cmbChatTarget.Size = new Size(206, 25);
            cmbChatTarget.TabIndex = 2;
            cmbChatTarget.SelectedIndexChanged += cmbChatTarget_SelectedIndexChanged;
            // 
            // btnBroadcast
            // 
            btnBroadcast.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnBroadcast.BorderRadius = 10;
            btnBroadcast.Cursor = Cursors.Hand;
            btnBroadcast.CustomizableEdges = customizableEdges15;
            btnBroadcast.FillColor = Color.FromArgb(120, 80, 10);
            btnBroadcast.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnBroadcast.ForeColor = Color.FromArgb(253, 186, 116);
            btnBroadcast.HoverState.FillColor = Color.FromArgb(146, 64, 14);
            btnBroadcast.Location = new Point(12, 598);
            btnBroadcast.Name = "btnBroadcast";
            btnBroadcast.ShadowDecoration.CustomizableEdges = customizableEdges16;
            btnBroadcast.Size = new Size(206, 38);
            btnBroadcast.TabIndex = 3;
            btnBroadcast.Text = "📢  Thông báo toàn bộ";
            btnBroadcast.Visible = false;
            btnBroadcast.Click += btnBroadcast_Click_1;
            // 
            // pnlRight
            // 
            pnlRight.BackColor = Color.FromArgb(39, 39, 42);
            pnlRight.Controls.Add(pnlChatHeader);
            pnlRight.Controls.Add(pnlInputBar);
            pnlRight.Controls.Add(lstChatHistory);
            pnlRight.Dock = DockStyle.Fill;
            pnlRight.Location = new Point(230, 0);
            pnlRight.Name = "pnlRight";
            pnlRight.Size = new Size(730, 648);
            pnlRight.TabIndex = 0;
            // 
            // pnlChatHeader
            // 
            pnlChatHeader.BackColor = Color.FromArgb(31, 31, 34);
            pnlChatHeader.Controls.Add(lblCurrentChat);
            pnlChatHeader.Controls.Add(btnOpenChatWindow);
            pnlChatHeader.CustomizableEdges = customizableEdges21;
            pnlChatHeader.Dock = DockStyle.Top;
            pnlChatHeader.Location = new Point(0, 0);
            pnlChatHeader.Name = "pnlChatHeader";
            pnlChatHeader.ShadowDecoration.CustomizableEdges = customizableEdges22;
            pnlChatHeader.Size = new Size(730, 54);
            pnlChatHeader.TabIndex = 2;
            // 
            // lblCurrentChat
            // 
            lblCurrentChat.AutoSize = true;
            lblCurrentChat.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblCurrentChat.ForeColor = Color.White;
            lblCurrentChat.Location = new Point(18, 17);
            lblCurrentChat.Name = "lblCurrentChat";
            lblCurrentChat.Size = new Size(171, 19);
            lblCurrentChat.TabIndex = 0;
            lblCurrentChat.Text = "🌐  Chat nhóm — Tất cả";
            // 
            // btnOpenChatWindow
            // 
            btnOpenChatWindow.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnOpenChatWindow.BorderRadius = 8;
            btnOpenChatWindow.Cursor = Cursors.Hand;
            btnOpenChatWindow.CustomizableEdges = customizableEdges19;
            btnOpenChatWindow.FillColor = Color.FromArgb(45, 45, 50);
            btnOpenChatWindow.Font = new Font("Segoe UI", 8.5F);
            btnOpenChatWindow.ForeColor = Color.FromArgb(160, 160, 166);
            btnOpenChatWindow.HoverState.FillColor = Color.FromArgb(60, 60, 66);
            btnOpenChatWindow.Location = new Point(1140, 12);
            btnOpenChatWindow.Name = "btnOpenChatWindow";
            btnOpenChatWindow.ShadowDecoration.CustomizableEdges = customizableEdges20;
            btnOpenChatWindow.Size = new Size(100, 30);
            btnOpenChatWindow.TabIndex = 1;
            btnOpenChatWindow.Text = "↗  Mở rộng";
            // 
            // pnlInputBar
            // 
            pnlInputBar.BackColor = Color.FromArgb(31, 31, 34);
            pnlInputBar.Controls.Add(txtMessage);
            pnlInputBar.Controls.Add(btnSend);
            pnlInputBar.CustomizableEdges = customizableEdges27;
            pnlInputBar.Dock = DockStyle.Bottom;
            pnlInputBar.Location = new Point(0, 588);
            pnlInputBar.Name = "pnlInputBar";
            pnlInputBar.ShadowDecoration.CustomizableEdges = customizableEdges28;
            pnlInputBar.Size = new Size(730, 60);
            pnlInputBar.TabIndex = 1;
            // 
            // txtMessage
            // 
            txtMessage.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtMessage.BorderColor = Color.FromArgb(60, 60, 66);
            txtMessage.BorderRadius = 10;
            txtMessage.CustomizableEdges = customizableEdges23;
            txtMessage.DefaultText = "";
            txtMessage.FillColor = Color.FromArgb(45, 45, 50);
            txtMessage.FocusedState.BorderColor = Color.FromArgb(31, 138, 154);
            txtMessage.Font = new Font("Segoe UI", 10.5F);
            txtMessage.ForeColor = Color.White;
            txtMessage.Location = new Point(12, 12);
            txtMessage.Name = "txtMessage";
            txtMessage.PasswordChar = '\0';
            txtMessage.PlaceholderForeColor = Color.FromArgb(100, 100, 108);
            txtMessage.PlaceholderText = "Nhập tin nhắn...";
            txtMessage.SelectedText = "";
            txtMessage.ShadowDecoration.CustomizableEdges = customizableEdges24;
            txtMessage.Size = new Size(610, 36);
            txtMessage.TabIndex = 0;
            // 
            // btnSend
            // 
            btnSend.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSend.BorderRadius = 10;
            btnSend.Cursor = Cursors.Hand;
            btnSend.CustomizableEdges = customizableEdges25;
            btnSend.FillColor = Color.FromArgb(31, 138, 154);
            btnSend.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnSend.ForeColor = Color.White;
            btnSend.HoverState.FillColor = Color.FromArgb(45, 158, 174);
            btnSend.Location = new Point(632, 12);
            btnSend.Name = "btnSend";
            btnSend.ShadowDecoration.CustomizableEdges = customizableEdges26;
            btnSend.Size = new Size(86, 36);
            btnSend.TabIndex = 1;
            btnSend.Text = "Gửi ➤";
            // 
            // lstChatHistory
            // 
            lstChatHistory.BackColor = Color.FromArgb(39, 39, 42);
            lstChatHistory.BorderStyle = BorderStyle.None;
            lstChatHistory.Dock = DockStyle.Fill;
            lstChatHistory.Font = new Font("Segoe UI", 10F);
            lstChatHistory.ForeColor = Color.FromArgb(220, 220, 225);
            lstChatHistory.ItemHeight = 17;
            lstChatHistory.Location = new Point(0, 0);
            lstChatHistory.Name = "lstChatHistory";
            lstChatHistory.SelectionMode = SelectionMode.None;
            lstChatHistory.Size = new Size(730, 648);
            lstChatHistory.TabIndex = 0;
            lstChatHistory.SelectedIndexChanged += lstChatHistory_SelectedIndexChanged;
            // 
            // ucInternalChat
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(39, 39, 42);
            Controls.Add(pnlRight);
            Controls.Add(pnlLeft);
            Name = "ucInternalChat";
            Size = new Size(960, 648);
            Load += ucInternalChat_Load;
            pnlLeft.ResumeLayout(false);
            pnlLeft.PerformLayout();
            pnlRight.ResumeLayout(false);
            pnlChatHeader.ResumeLayout(false);
            pnlChatHeader.PerformLayout();
            pnlInputBar.ResumeLayout(false);
            ResumeLayout(false);
        }

        private Guna2Panel   pnlLeft;
        private Label        lblChatTitle;
        private Label        lblContactsHint;
        private ComboBox     cmbChatTarget;
        private Panel        pnlRight;
        private Guna2Panel   pnlChatHeader;
        private Label        lblCurrentChat;
        private Guna2Button  btnOpenChatWindow;
        private ListBox      lstChatHistory;
        private Guna2Panel   pnlInputBar;
        private Guna2TextBox txtMessage;
        private Guna2Button  btnSend;
        private Guna2Button  btnBroadcast;
    }
}
