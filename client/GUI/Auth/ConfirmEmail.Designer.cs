using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace GUI
{
    partial class ConfirmEmail
    {
        private System.ComponentModel.IContainer components = null;

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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfirmEmail));
            pnlCard = new Guna2Panel();
            lblBrand = new Label();
            lblTitle = new Label();
            lblDescription = new Label();
            txtEmail = new Guna2TextBox();
            btnSendCode = new Guna2Button();
            lblBackToLogin = new LinkLabel();
            shadow = new Guna2ShadowForm(components);
            pictureBox2 = new PictureBox();
            pnlCard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // pnlCard
            // 
            pnlCard.BackColor = Color.FromArgb(39, 39, 42);
            pnlCard.BorderRadius = 18;
            pnlCard.Controls.Add(pictureBox2);
            pnlCard.Controls.Add(lblBrand);
            pnlCard.Controls.Add(lblTitle);
            pnlCard.Controls.Add(lblDescription);
            pnlCard.Controls.Add(txtEmail);
            pnlCard.Controls.Add(btnSendCode);
            pnlCard.Controls.Add(lblBackToLogin);
            pnlCard.CustomizableEdges = customizableEdges5;
            pnlCard.Location = new Point(170, 30);
            pnlCard.Name = "pnlCard";
            pnlCard.ShadowDecoration.CustomizableEdges = customizableEdges6;
            pnlCard.Size = new Size(460, 510);
            pnlCard.TabIndex = 0;
            // 
            // lblBrand
            // 
            lblBrand.AutoSize = true;
            lblBrand.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblBrand.ForeColor = Color.White;
            lblBrand.Location = new Point(180, 138);
            lblBrand.Name = "lblBrand";
            lblBrand.Size = new Size(107, 37);
            lblBrand.TabIndex = 1;
            lblBrand.Text = "QLCafe";
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 17F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(50, 200);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(178, 31);
            lblTitle.TabIndex = 3;
            lblTitle.Text = "Quên mật khẩu";
            // 
            // lblDescription
            // 
            lblDescription.AutoSize = true;
            lblDescription.Font = new Font("Segoe UI", 9.5F);
            lblDescription.ForeColor = Color.FromArgb(160, 160, 166);
            lblDescription.Location = new Point(50, 235);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(268, 17);
            lblDescription.TabIndex = 4;
            lblDescription.Text = "Nhập email để nhận mã khôi phục mật khẩu.";
            // 
            // txtEmail
            // 
            txtEmail.BorderColor = Color.FromArgb(63, 63, 70);
            txtEmail.BorderRadius = 10;
            txtEmail.CustomizableEdges = customizableEdges1;
            txtEmail.DefaultText = "";
            txtEmail.DisabledState.BorderColor = Color.FromArgb(63, 63, 70);
            txtEmail.DisabledState.FillColor = Color.FromArgb(45, 45, 48);
            txtEmail.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            txtEmail.DisabledState.PlaceholderForeColor = Color.FromArgb(125, 137, 149);
            txtEmail.FillColor = Color.FromArgb(30, 30, 33);
            txtEmail.FocusedState.BorderColor = Color.FromArgb(31, 138, 154);
            txtEmail.Font = new Font("Segoe UI", 10.5F);
            txtEmail.ForeColor = Color.White;
            txtEmail.HoverState.BorderColor = Color.FromArgb(120, 120, 130);
            txtEmail.Location = new Point(50, 280);
            txtEmail.Name = "txtEmail";
            txtEmail.PasswordChar = '\0';
            txtEmail.PlaceholderForeColor = Color.FromArgb(110, 110, 120);
            txtEmail.PlaceholderText = "Nhập địa chỉ email...";
            txtEmail.SelectedText = "";
            txtEmail.ShadowDecoration.CustomizableEdges = customizableEdges2;
            txtEmail.Size = new Size(360, 46);
            txtEmail.TabIndex = 5;
            // 
            // btnSendCode
            // 
            btnSendCode.BorderRadius = 10;
            btnSendCode.Cursor = Cursors.Hand;
            btnSendCode.CustomizableEdges = customizableEdges3;
            btnSendCode.DisabledState.BorderColor = Color.DarkGray;
            btnSendCode.DisabledState.CustomBorderColor = Color.DarkGray;
            btnSendCode.DisabledState.FillColor = Color.FromArgb(80, 80, 80);
            btnSendCode.DisabledState.ForeColor = Color.FromArgb(190, 190, 190);
            btnSendCode.FillColor = Color.FromArgb(31, 138, 154);
            btnSendCode.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnSendCode.ForeColor = Color.White;
            btnSendCode.HoverState.FillColor = Color.FromArgb(45, 158, 174);
            btnSendCode.Location = new Point(50, 350);
            btnSendCode.Name = "btnSendCode";
            btnSendCode.ShadowDecoration.CustomizableEdges = customizableEdges4;
            btnSendCode.Size = new Size(360, 46);
            btnSendCode.TabIndex = 6;
            btnSendCode.Text = "Gửi mã xác nhận";
            btnSendCode.Click += BtnSendCode_Click;
            // 
            // lblBackToLogin
            // 
            lblBackToLogin.ActiveLinkColor = Color.FromArgb(31, 138, 154);
            lblBackToLogin.AutoSize = true;
            lblBackToLogin.Font = new Font("Segoe UI", 9.5F);
            lblBackToLogin.LinkBehavior = LinkBehavior.HoverUnderline;
            lblBackToLogin.LinkColor = Color.FromArgb(160, 160, 166);
            lblBackToLogin.Location = new Point(150, 440);
            lblBackToLogin.Name = "lblBackToLogin";
            lblBackToLogin.Size = new Size(137, 17);
            lblBackToLogin.TabIndex = 7;
            lblBackToLogin.TabStop = true;
            lblBackToLogin.Text = "← Quay lại đăng nhập";
            lblBackToLogin.LinkClicked += LblBackToLogin_LinkClicked;
            //
            // shadow
            //
            shadow.TargetForm = this;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(0, 22);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(460, 113);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 9;
            pictureBox2.TabStop = false;
            // 
            // ConfirmEmail
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(24, 24, 27);
            ClientSize = new Size(800, 580);
            Controls.Add(pnlCard);
            FormBorderStyle = FormBorderStyle.None;
            Name = "ConfirmEmail";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quên mật khẩu - QLCafe";
            pnlCard.ResumeLayout(false);
            pnlCard.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Guna2Panel pnlCard;
        private Label lblBrand;
        private Label lblTitle;
        private Label lblDescription;
        private Guna2TextBox txtEmail;
        private Guna2Button btnSendCode;
        private LinkLabel lblBackToLogin;
        private Guna2ShadowForm shadow;
        private PictureBox pictureBox2;
    }
}
