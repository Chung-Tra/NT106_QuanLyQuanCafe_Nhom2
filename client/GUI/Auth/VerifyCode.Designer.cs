namespace GUI
{
    partial class VerifyCode
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

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            lblTitle = new Label();
            lblDescription = new Label();
            pnlCodeBg = new Panel();
            txtCode = new TextBox();
            btnVerify = new Button();
            lblResend = new LinkLabel();
            lblBackToLogin = new LinkLabel();
            resendTimer = new System.Windows.Forms.Timer(components);
            pnlCodeBg.SuspendLayout();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(220, 100);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(191, 30);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Mã xác nhận";
            // 
            // lblDescription
            // 
            lblDescription.AutoSize = true;
            lblDescription.Font = new Font("Segoe UI", 10F);
            lblDescription.ForeColor = Color.LightGray;
            lblDescription.Location = new Point(220, 140);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(307, 19);
            lblDescription.TabIndex = 1;
            lblDescription.Text = "Vui lòng nhập mã 8 số được gửi đến email của bạn.";
            // 
            // pnlCodeBg
            // 
            pnlCodeBg.BackColor = Color.FromArgb(45, 45, 48);
            pnlCodeBg.Controls.Add(txtCode);
            pnlCodeBg.Location = new Point(220, 180);
            pnlCodeBg.Name = "pnlCodeBg";
            pnlCodeBg.Size = new Size(350, 40);
            pnlCodeBg.TabIndex = 2;
            // 
            // txtCode
            // 
            txtCode.BackColor = Color.FromArgb(45, 45, 48);
            txtCode.BorderStyle = BorderStyle.None;
            txtCode.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            txtCode.ForeColor = Color.White;
            txtCode.Location = new Point(15, 8);
            txtCode.Name = "txtCode";
            txtCode.Size = new Size(320, 25);
            txtCode.TabIndex = 0;
            txtCode.TextAlign = HorizontalAlignment.Center;
            // 
            // btnVerify
            // 
            btnVerify.BackColor = Color.White;
            btnVerify.Cursor = Cursors.Hand;
            btnVerify.FlatAppearance.BorderSize = 0;
            btnVerify.FlatStyle = FlatStyle.Flat;
            btnVerify.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnVerify.ForeColor = Color.Black;
            btnVerify.Location = new Point(220, 240);
            btnVerify.Name = "btnVerify";
            btnVerify.Size = new Size(120, 40);
            btnVerify.TabIndex = 3;
            btnVerify.Text = "Xác nhận";
            btnVerify.UseVisualStyleBackColor = false;
            btnVerify.Click += btnVerify_Click;
            // 
            // lblResend
            // 
            lblResend.AutoSize = true;
            lblResend.Font = new Font("Segoe UI", 10F);
            lblResend.LinkColor = Color.LightSkyBlue;
            lblResend.Location = new Point(360, 251);
            lblResend.Name = "lblResend";
            lblResend.Size = new Size(89, 19);
            lblResend.TabIndex = 4;
            lblResend.TabStop = true;
            lblResend.Text = "Gửi lại mã";
            lblResend.LinkClicked += lblResend_LinkClicked;
            // 
            // lblBackToLogin
            // 
            lblBackToLogin.AutoSize = true;
            lblBackToLogin.Font = new Font("Segoe UI", 10F);
            lblBackToLogin.LinkColor = Color.LightSkyBlue;
            lblBackToLogin.Location = new Point(216, 300);
            lblBackToLogin.Name = "lblBackToLogin";
            lblBackToLogin.Size = new Size(92, 19);
            lblBackToLogin.TabIndex = 5;
            lblBackToLogin.TabStop = true;
            lblBackToLogin.Text = "Quay lại đăng nhập";
            lblBackToLogin.LinkClicked += lblBackToLogin_LinkClicked;
            // 
            // resendTimer
            // 
            resendTimer.Interval = 1000;
            resendTimer.Tick += timer1_Tick;
            // 
            // VerifyCode
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(30, 30, 30);
            ClientSize = new Size(800, 450);
            Controls.Add(lblBackToLogin);
            Controls.Add(lblResend);
            Controls.Add(btnVerify);
            Controls.Add(pnlCodeBg);
            Controls.Add(lblDescription);
            Controls.Add(lblTitle);
            FormBorderStyle = FormBorderStyle.None;
            Name = "VerifyCode";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Xác nhận mã";
            pnlCodeBg.ResumeLayout(false);
            pnlCodeBg.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private Label lblDescription;
        private Panel pnlCodeBg;
        private TextBox txtCode;
        private Button btnVerify;
        private LinkLabel lblResend;
        private LinkLabel lblBackToLogin;
        private System.Windows.Forms.Timer resendTimer;
    }
}