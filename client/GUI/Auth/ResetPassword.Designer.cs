using System.Drawing;
using System.Windows.Forms;

namespace GUI
{
    partial class ResetPassword
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
            pnlNewPassBg = new Panel();
            txtNewPass = new TextBox();
            pnlConfirmPassBg = new Panel();
            btnShowConfirmPass = new Button();
            txtConfirmPass = new TextBox();
            btnSave = new Button();
            lblBackToLogin = new LinkLabel();
            pnlNewPassBg.SuspendLayout();
            pnlConfirmPassBg.SuspendLayout();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(220, 80);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(239, 30);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Tạo mật khẩu mới";
            // 
            // lblDescription
            // 
            lblDescription.AutoSize = true;
            lblDescription.Font = new Font("Segoe UI", 10F);
            lblDescription.ForeColor = Color.LightGray;
            lblDescription.Location = new Point(220, 120);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(249, 19);
            lblDescription.TabIndex = 1;
            lblDescription.Text = "Vui lòng nhập mật khẩu mới của bạn dưới đây.";
            // 
            // pnlNewPassBg
            // 
            pnlNewPassBg.BackColor = Color.FromArgb(45, 45, 48);
            pnlNewPassBg.Controls.Add(txtNewPass);
            pnlNewPassBg.Location = new Point(220, 160);
            pnlNewPassBg.Name = "pnlNewPassBg";
            pnlNewPassBg.Size = new Size(350, 40);
            pnlNewPassBg.TabIndex = 2;
            // 
            // txtNewPass
            // 
            txtNewPass.BackColor = Color.FromArgb(45, 45, 48);
            txtNewPass.BorderStyle = BorderStyle.None;
            txtNewPass.Font = new Font("Segoe UI", 12F);
            txtNewPass.ForeColor = Color.White;
            txtNewPass.Location = new Point(15, 9);
            txtNewPass.Name = "txtNewPass";
            txtNewPass.PlaceholderText = "12345678";
            txtNewPass.Size = new Size(280, 22);
            txtNewPass.TabIndex = 0;
            txtNewPass.TextChanged += TxtNewPass_TextChanged;
            // 
            // pnlConfirmPassBg
            // 
            pnlConfirmPassBg.BackColor = Color.FromArgb(45, 45, 48);
            pnlConfirmPassBg.Controls.Add(btnShowConfirmPass);
            pnlConfirmPassBg.Controls.Add(txtConfirmPass);
            pnlConfirmPassBg.Location = new Point(220, 220);
            pnlConfirmPassBg.Name = "pnlConfirmPassBg";
            pnlConfirmPassBg.Size = new Size(350, 40);
            pnlConfirmPassBg.TabIndex = 3;
            // 
            // btnShowConfirmPass
            // 
            btnShowConfirmPass.Cursor = Cursors.Hand;
            btnShowConfirmPass.FlatAppearance.BorderSize = 0;
            btnShowConfirmPass.FlatStyle = FlatStyle.Flat;
            btnShowConfirmPass.ForeColor = Color.White;
            btnShowConfirmPass.Location = new Point(310, 5);
            btnShowConfirmPass.Name = "btnShowConfirmPass";
            btnShowConfirmPass.Size = new Size(30, 30);
            btnShowConfirmPass.TabIndex = 1;
            btnShowConfirmPass.Text = "👁️";
            btnShowConfirmPass.UseVisualStyleBackColor = true;
            btnShowConfirmPass.MouseDown += BtnShowConfirmPass_MouseDown;
            btnShowConfirmPass.MouseUp += BtnShowConfirmPass_MouseUp;
            // 
            // txtConfirmPass
            // 
            txtConfirmPass.BackColor = Color.FromArgb(45, 45, 48);
            txtConfirmPass.BorderStyle = BorderStyle.None;
            txtConfirmPass.Font = new Font("Segoe UI", 12F);
            txtConfirmPass.ForeColor = Color.White;
            txtConfirmPass.Location = new Point(15, 9);
            txtConfirmPass.Name = "txtConfirmPass";
            txtConfirmPass.PlaceholderText = "12345678";
            txtConfirmPass.Size = new Size(280, 22);
            txtConfirmPass.TabIndex = 0;
            txtConfirmPass.UseSystemPasswordChar = true;
            txtConfirmPass.Enter += TxtConfirmPass_Enter;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.White;
            btnSave.Cursor = Cursors.Hand;
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnSave.ForeColor = Color.Black;
            btnSave.Location = new Point(220, 290);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(120, 40);
            btnSave.TabIndex = 4;
            btnSave.Text = "Lưu";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += BtnSave_Click;
            // 
            // lblBackToLogin
            // 
            lblBackToLogin.AutoSize = true;
            lblBackToLogin.Font = new Font("Segoe UI", 10F);
            lblBackToLogin.LinkColor = Color.LightSkyBlue;
            lblBackToLogin.Location = new Point(478, 290);
            lblBackToLogin.Name = "lblBackToLogin";
            lblBackToLogin.Size = new Size(92, 19);
            lblBackToLogin.TabIndex = 6;
            lblBackToLogin.TabStop = true;
            lblBackToLogin.Text = "Quay lại đăng nhập";
            lblBackToLogin.LinkClicked += LblBackToLogin_LinkClicked;
            // 
            // ResetPassword
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(30, 30, 30);
            ClientSize = new Size(800, 450);
            Controls.Add(lblBackToLogin);
            Controls.Add(btnSave);
            Controls.Add(pnlConfirmPassBg);
            Controls.Add(pnlNewPassBg);
            Controls.Add(lblDescription);
            Controls.Add(lblTitle);
            FormBorderStyle = FormBorderStyle.None;
            Name = "ResetPassword";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Tạo mật khẩu mới";
            pnlNewPassBg.ResumeLayout(false);
            pnlNewPassBg.PerformLayout();
            pnlConfirmPassBg.ResumeLayout(false);
            pnlConfirmPassBg.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private Label lblDescription;
        private Panel pnlNewPassBg;
        private TextBox txtNewPass;
        private Panel pnlConfirmPassBg;
        private Button btnShowConfirmPass;
        private TextBox txtConfirmPass;
        private Button btnSave;
        private LinkLabel lblBackToLogin;
    }
}