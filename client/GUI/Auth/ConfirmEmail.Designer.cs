using System.Drawing;
using System.Windows.Forms;

namespace GUI
{
    partial class ConfirmEmail
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
            lblTitle = new Label();
            lblDescription = new Label();
            pnlEmailBg = new Panel();
            txtEmail = new TextBox();
            btnSendCode = new Button();
            lblBackToLogin = new LinkLabel();
            pnlEmailBg.SuspendLayout();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(220, 100);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(187, 30);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Quên mật khẩu";
            // 
            // lblDescription
            // 
            lblDescription.AutoSize = true;
            lblDescription.Font = new Font("Segoe UI", 10F);
            lblDescription.ForeColor = Color.LightGray;
            lblDescription.Location = new Point(220, 140);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(253, 19);
            lblDescription.TabIndex = 1;
            lblDescription.Text = "Nhập email của bạn để nhận mã khôi phục.";
            // 
            // pnlEmailBg
            // 
            pnlEmailBg.BackColor = Color.FromArgb(45, 45, 48);
            pnlEmailBg.Controls.Add(txtEmail);
            pnlEmailBg.Location = new Point(220, 180);
            pnlEmailBg.Name = "pnlEmailBg";
            pnlEmailBg.Size = new Size(350, 40);
            pnlEmailBg.TabIndex = 2;
            // 
            // txtEmail
            // 
            txtEmail.BackColor = Color.FromArgb(45, 45, 48);
            txtEmail.BorderStyle = BorderStyle.None;
            txtEmail.Font = new Font("Segoe UI", 12F);
            txtEmail.ForeColor = Color.White;
            txtEmail.Location = new Point(15, 9);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(320, 22);
            txtEmail.TabIndex = 0;
            // 
            // btnSendCode
            // 
            btnSendCode.BackColor = Color.White;
            btnSendCode.Cursor = Cursors.Hand;
            btnSendCode.FlatAppearance.BorderSize = 0;
            btnSendCode.FlatStyle = FlatStyle.Flat;
            btnSendCode.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnSendCode.ForeColor = Color.Black;
            btnSendCode.Location = new Point(220, 240);
            btnSendCode.Name = "btnSendCode";
            btnSendCode.Size = new Size(120, 40);
            btnSendCode.TabIndex = 3;
            btnSendCode.Text = "Gửi mã";
            btnSendCode.UseVisualStyleBackColor = false;
            btnSendCode.Click += BtnSendCode_Click;
            // 
            // lblBackToLogin
            // 
            lblBackToLogin.AutoSize = true;
            lblBackToLogin.Font = new Font("Segoe UI", 10F);
            lblBackToLogin.LinkColor = Color.LightSkyBlue;
            lblBackToLogin.Location = new Point(360, 251);
            lblBackToLogin.Name = "lblBackToLogin";
            lblBackToLogin.Size = new Size(92, 19);
            lblBackToLogin.TabIndex = 4;
            lblBackToLogin.TabStop = true;
            lblBackToLogin.Text = "Quay lại đăng nhập";
            lblBackToLogin.LinkClicked += LblBackToLogin_LinkClicked;
            // 
            // ConfirmEmail
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(30, 30, 30);
            ClientSize = new Size(800, 450);
            Controls.Add(lblBackToLogin);
            Controls.Add(btnSendCode);
            Controls.Add(pnlEmailBg);
            Controls.Add(lblDescription);
            Controls.Add(lblTitle);
            FormBorderStyle = FormBorderStyle.None;
            Name = "ConfirmEmail";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quên mật khẩu";
            pnlEmailBg.ResumeLayout(false);
            pnlEmailBg.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private Label lblDescription;
        private Panel pnlEmailBg;
        private TextBox txtEmail;
        private Button btnSendCode;
        private LinkLabel lblBackToLogin;
    }
}