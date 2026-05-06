namespace GUI
{
    partial class ucSettings_Manager
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pnlProfile = new Panel();
            btnSwitchDashboard = new Button();
            picAvatar = new PictureBox();
            btnUpdateProfile = new Button();
            btnChangePassword = new Button();
            lblMyRole = new Label();
            lblMyName = new Label();
            lblProfileTitle = new Label();
            pnlChat = new Panel();
            btnOpenChatWindow = new Button();
            cmbChatTarget = new ComboBox();
            btnSend = new Button();
            txtMessage = new TextBox();
            lstChatHistory = new ListBox();
            lblChatTitle = new Label();
            pnlProfile.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picAvatar).BeginInit();
            pnlChat.SuspendLayout();
            SuspendLayout();
            // 
            // pnlProfile
            // 
            pnlProfile.BackColor = Color.FromArgb(30, 30, 30);
            pnlProfile.Controls.Add(btnSwitchDashboard);
            pnlProfile.Controls.Add(picAvatar);
            pnlProfile.Controls.Add(btnUpdateProfile);
            pnlProfile.Controls.Add(btnChangePassword);
            pnlProfile.Controls.Add(lblMyRole);
            pnlProfile.Controls.Add(lblMyName);
            pnlProfile.Controls.Add(lblProfileTitle);
            pnlProfile.Location = new Point(20, 20);
            pnlProfile.Name = "pnlProfile";
            pnlProfile.Size = new Size(240, 490);
            pnlProfile.TabIndex = 0;
            // 
            // btnSwitchDashboard
            // 
            btnSwitchDashboard.BackColor = Color.FromArgb(45, 45, 48);
            btnSwitchDashboard.FlatAppearance.BorderSize = 0;
            btnSwitchDashboard.FlatStyle = FlatStyle.Flat;
            btnSwitchDashboard.ForeColor = Color.White;
            btnSwitchDashboard.Location = new Point(26, 448);
            btnSwitchDashboard.Name = "btnSwitchDashboard";
            btnSwitchDashboard.Size = new Size(200, 35);
            btnSwitchDashboard.TabIndex = 6;
            btnSwitchDashboard.Text = "Quay về giao diện ban đầu";
            btnSwitchDashboard.UseVisualStyleBackColor = false;
            // 
            // picAvatar
            // 
            picAvatar.BackColor = Color.FromArgb(45, 45, 48);
            picAvatar.Location = new Point(38, 89);
            picAvatar.Name = "picAvatar";
            picAvatar.Size = new Size(150, 150);
            picAvatar.SizeMode = PictureBoxSizeMode.Zoom;
            picAvatar.TabIndex = 5;
            picAvatar.TabStop = false;
            // 
            // btnUpdateProfile
            // 
            btnUpdateProfile.BackColor = Color.FromArgb(45, 45, 48);
            btnUpdateProfile.FlatAppearance.BorderSize = 0;
            btnUpdateProfile.FlatStyle = FlatStyle.Flat;
            btnUpdateProfile.ForeColor = Color.White;
            btnUpdateProfile.Location = new Point(26, 396);
            btnUpdateProfile.Name = "btnUpdateProfile";
            btnUpdateProfile.Size = new Size(200, 35);
            btnUpdateProfile.TabIndex = 4;
            btnUpdateProfile.Text = "Cập nhật Thông tin";
            btnUpdateProfile.UseVisualStyleBackColor = false;
            // 
            // btnChangePassword
            // 
            btnChangePassword.BackColor = Color.FromArgb(45, 45, 48);
            btnChangePassword.FlatAppearance.BorderSize = 0;
            btnChangePassword.FlatStyle = FlatStyle.Flat;
            btnChangePassword.ForeColor = Color.Orange;
            btnChangePassword.Location = new Point(26, 346);
            btnChangePassword.Name = "btnChangePassword";
            btnChangePassword.Size = new Size(200, 35);
            btnChangePassword.TabIndex = 3;
            btnChangePassword.Text = "Đổi Mật Khẩu 🔑";
            btnChangePassword.UseVisualStyleBackColor = false;
            // 
            // lblMyRole
            // 
            lblMyRole.AutoSize = true;
            lblMyRole.Font = new Font("Segoe UI", 10F);
            lblMyRole.ForeColor = Color.Gray;
            lblMyRole.Location = new Point(22, 286);
            lblMyRole.Name = "lblMyRole";
            lblMyRole.Size = new Size(183, 38);
            lblMyRole.TabIndex = 2;
            lblMyRole.Text = "Chức vụ: Manager (Ca Sáng)\r\nID: MNG-001";
            // 
            // lblMyName
            // 
            lblMyName.AutoSize = true;
            lblMyName.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblMyName.ForeColor = Color.MediumSeaGreen;
            lblMyName.Location = new Point(22, 256);
            lblMyName.Name = "lblMyName";
            lblMyName.Size = new Size(193, 25);
            lblMyName.TabIndex = 1;
            lblMyName.Text = "Trần Trọng Quản Lý ";
            // 
            // lblProfileTitle
            // 
            lblProfileTitle.AutoSize = true;
            lblProfileTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblProfileTitle.ForeColor = Color.White;
            lblProfileTitle.Location = new Point(15, 15);
            lblProfileTitle.Name = "lblProfileTitle";
            lblProfileTitle.Size = new Size(142, 21);
            lblProfileTitle.TabIndex = 0;
            lblProfileTitle.Text = "Hồ Sơ Của Tôi 👤";
            // 
            // pnlChat
            // 
            pnlChat.BackColor = Color.FromArgb(30, 30, 30);
            pnlChat.Controls.Add(btnOpenChatWindow);
            pnlChat.Controls.Add(cmbChatTarget);
            pnlChat.Controls.Add(btnSend);
            pnlChat.Controls.Add(txtMessage);
            pnlChat.Controls.Add(lstChatHistory);
            pnlChat.Controls.Add(lblChatTitle);
            pnlChat.Location = new Point(284, 20);
            pnlChat.Name = "pnlChat";
            pnlChat.Size = new Size(500, 490);
            pnlChat.TabIndex = 2;
            // 
            // btnOpenChatWindow
            // 
            btnOpenChatWindow.BackColor = Color.FromArgb(45, 45, 48);
            btnOpenChatWindow.FlatAppearance.BorderSize = 0;
            btnOpenChatWindow.FlatStyle = FlatStyle.Flat;
            btnOpenChatWindow.Font = new Font("Segoe UI", 8F);
            btnOpenChatWindow.ForeColor = Color.White;
            btnOpenChatWindow.Location = new Point(412, 11);
            btnOpenChatWindow.Name = "btnOpenChatWindow";
            btnOpenChatWindow.Size = new Size(85, 25);
            btnOpenChatWindow.TabIndex = 4;
            btnOpenChatWindow.Text = "Trang mới ↗";
            btnOpenChatWindow.UseVisualStyleBackColor = false;
            // 
            // cmbChatTarget
            // 
            cmbChatTarget.BackColor = Color.FromArgb(45, 45, 48);
            cmbChatTarget.FlatStyle = FlatStyle.Flat;
            cmbChatTarget.ForeColor = Color.White;
            cmbChatTarget.FormattingEnabled = true;
            cmbChatTarget.Items.AddRange(new object[] { "Tất cả nhân sự" });
            cmbChatTarget.Location = new Point(15, 45);
            cmbChatTarget.Name = "cmbChatTarget";
            cmbChatTarget.Size = new Size(470, 23);
            cmbChatTarget.TabIndex = 6;
            cmbChatTarget.Text = "Tất cả nhân sự";
            // 
            // btnSend
            // 
            btnSend.BackColor = Color.MediumSeaGreen;
            btnSend.FlatAppearance.BorderSize = 0;
            btnSend.FlatStyle = FlatStyle.Flat;
            btnSend.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnSend.ForeColor = Color.White;
            btnSend.Location = new Point(431, 450);
            btnSend.Name = "btnSend";
            btnSend.Size = new Size(54, 30);
            btnSend.TabIndex = 3;
            btnSend.Text = "GỬI";
            btnSend.UseVisualStyleBackColor = false;
            // 
            // txtMessage
            // 
            txtMessage.BackColor = Color.FromArgb(45, 45, 48);
            txtMessage.BorderStyle = BorderStyle.None;
            txtMessage.Font = new Font("Segoe UI", 11F);
            txtMessage.ForeColor = Color.White;
            txtMessage.Location = new Point(15, 450);
            txtMessage.Name = "txtMessage";
            txtMessage.Size = new Size(410, 20);
            txtMessage.TabIndex = 2;
            // 
            // lstChatHistory
            // 
            lstChatHistory.BackColor = Color.FromArgb(45, 45, 48);
            lstChatHistory.BorderStyle = BorderStyle.None;
            lstChatHistory.Font = new Font("Segoe UI", 9.5F);
            lstChatHistory.ForeColor = Color.LightGray;
            lstChatHistory.FormattingEnabled = true;
            lstChatHistory.ItemHeight = 17;
            lstChatHistory.Location = new Point(15, 74);
            lstChatHistory.Name = "lstChatHistory";
            lstChatHistory.Size = new Size(470, 357);
            lstChatHistory.TabIndex = 1;
            // 
            // lblChatTitle
            // 
            lblChatTitle.AutoSize = true;
            lblChatTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblChatTitle.ForeColor = Color.White;
            lblChatTitle.Location = new Point(15, 15);
            lblChatTitle.Name = "lblChatTitle";
            lblChatTitle.Size = new Size(128, 21);
            lblChatTitle.TabIndex = 0;
            lblChatTitle.Text = "Chat Nội Bộ 💬";
            // 
            // ucSettings_Manager
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(45, 45, 48);
            Controls.Add(pnlChat);
            Controls.Add(pnlProfile);
            Name = "ucSettings_Manager";
            Size = new Size(804, 530);
            Load += ucSettings_Manager_Load;
            pnlProfile.ResumeLayout(false);
            pnlProfile.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picAvatar).EndInit();
            pnlChat.ResumeLayout(false);
            pnlChat.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlProfile;
        private Label lblProfileTitle;
        private Label lblMyName;
        private Label lblMyRole;
        private Button btnChangePassword;
        private Button btnUpdateProfile;
        private Panel pnlChat;
        private Label lblChatTitle;
        private ListBox lstChatHistory;
        private TextBox txtMessage;
        private Button btnSend;
        private ComboBox cmbChatTarget;
        private Button btnOpenChatWindow;
        private PictureBox picAvatar;
        private Button btnSwitchDashboard;
    }
}