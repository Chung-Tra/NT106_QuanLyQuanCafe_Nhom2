namespace GUI
{
    partial class ucInternalChat
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
            pnlChat = new Panel();
            btnOpenChatWindow = new Button();
            cmbChatTarget = new ComboBox();
            btnSend = new Button();
            txtMessage = new TextBox();
            lstChatHistory = new ListBox();
            lblChatTitle = new Label();
            pnlChat.SuspendLayout();
            SuspendLayout();
            // 
            // pnlChat
            // 
            pnlChat.BackColor = Color.FromArgb(30, 30, 30);
            btnBroadcast = new Button();
            pnlChat.Controls.Add(btnBroadcast);
            pnlChat.Controls.Add(btnOpenChatWindow);
            pnlChat.Controls.Add(cmbChatTarget);
            pnlChat.Controls.Add(btnSend);
            pnlChat.Controls.Add(txtMessage);
            pnlChat.Controls.Add(lstChatHistory);
            pnlChat.Controls.Add(lblChatTitle);
            pnlChat.Dock = DockStyle.Fill;
            pnlChat.Location = new Point(0, 0);
            pnlChat.Name = "pnlChat";
            pnlChat.Padding = new Padding(20);
            pnlChat.Size = new Size(800, 530);
            pnlChat.TabIndex = 0;
            // 
            // btnOpenChatWindow
            // 
            btnOpenChatWindow.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnOpenChatWindow.BackColor = Color.FromArgb(45, 45, 48);
            btnOpenChatWindow.FlatAppearance.BorderSize = 0;
            btnOpenChatWindow.FlatStyle = FlatStyle.Flat;
            btnOpenChatWindow.ForeColor = Color.White;
            btnOpenChatWindow.Location = new Point(685, 15);
            btnOpenChatWindow.Name = "btnOpenChatWindow";
            btnOpenChatWindow.Size = new Size(100, 30);
            btnOpenChatWindow.TabIndex = 0;
            btnOpenChatWindow.Text = "Trang mới ↗";
            btnOpenChatWindow.UseVisualStyleBackColor = false;
            // 
            // cmbChatTarget
            // 
            cmbChatTarget.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cmbChatTarget.BackColor = Color.FromArgb(45, 45, 48);
            cmbChatTarget.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbChatTarget.FlatStyle = FlatStyle.Flat;
            cmbChatTarget.ForeColor = Color.White;
            cmbChatTarget.FormattingEnabled = true;
            cmbChatTarget.Location = new Point(20, 55);
            cmbChatTarget.Name = "cmbChatTarget";
            cmbChatTarget.Size = new Size(760, 23);
            cmbChatTarget.TabIndex = 1;
            // 
            // btnSend
            // 
            btnSend.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnSend.BackColor = Color.MediumSeaGreen;
            btnSend.FlatAppearance.BorderSize = 0;
            btnSend.FlatStyle = FlatStyle.Flat;
            btnSend.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnSend.ForeColor = Color.White;
            btnSend.Location = new Point(710, 480);
            btnSend.Name = "btnSend";
            btnSend.Size = new Size(70, 30);
            btnSend.TabIndex = 2;
            btnSend.Text = "GỬI";
            btnSend.UseVisualStyleBackColor = false;
            // 
            // txtMessage
            // 
            txtMessage.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtMessage.BackColor = Color.FromArgb(45, 45, 48);
            txtMessage.BorderStyle = BorderStyle.None;
            txtMessage.Font = new Font("Segoe UI", 11F);
            txtMessage.ForeColor = Color.White;
            txtMessage.Location = new Point(20, 480);
            txtMessage.Name = "txtMessage";
            txtMessage.Size = new Size(680, 20);
            txtMessage.TabIndex = 2;
            // 
            // lstChatHistory
            // 
            lstChatHistory.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lstChatHistory.BackColor = Color.FromArgb(45, 45, 48);
            lstChatHistory.BorderStyle = BorderStyle.None;
            lstChatHistory.Font = new Font("Segoe UI", 10F);
            lstChatHistory.ForeColor = Color.LightGray;
            lstChatHistory.FormattingEnabled = true;
            lstChatHistory.ItemHeight = 17;
            lstChatHistory.Location = new Point(20, 90);
            lstChatHistory.Name = "lstChatHistory";
            lstChatHistory.Size = new Size(760, 374);
            lstChatHistory.TabIndex = 3;
            // 
            // lblChatTitle
            // 
            lblChatTitle.AutoSize = true;
            lblChatTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblChatTitle.ForeColor = Color.White;
            lblChatTitle.Location = new Point(18, 15);
            lblChatTitle.Name = "lblChatTitle";
            lblChatTitle.Size = new Size(111, 21);
            lblChatTitle.TabIndex = 4;
            lblChatTitle.Text = "CHAT NỘI BỘ";
            lblChatTitle.Click += lblChatTitle_Click;
            //
            // btnBroadcast
            //
            btnBroadcast.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnBroadcast.BackColor = Color.Goldenrod;
            btnBroadcast.Cursor = Cursors.Hand;
            btnBroadcast.FlatAppearance.BorderSize = 0;
            btnBroadcast.FlatStyle = FlatStyle.Flat;
            btnBroadcast.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            btnBroadcast.ForeColor = Color.White;
            btnBroadcast.Location = new Point(555, 15);
            btnBroadcast.Name = "btnBroadcast";
            btnBroadcast.Size = new Size(120, 30);
            btnBroadcast.Text = "Thông báo toàn bộ";
            btnBroadcast.Visible = false;
            //
            // ucInternalChat
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(pnlChat);
            Name = "ucInternalChat";
            Size = new Size(800, 530);
            pnlChat.ResumeLayout(false);
            pnlChat.PerformLayout();
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlChat;
        private System.Windows.Forms.Label lblChatTitle;
        private System.Windows.Forms.ListBox lstChatHistory;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.ComboBox cmbChatTarget;
        private System.Windows.Forms.Button btnOpenChatWindow;
        private System.Windows.Forms.Button btnBroadcast;
    }
}
