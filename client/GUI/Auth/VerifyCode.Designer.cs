using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace GUI
{
    partial class VerifyCode
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VerifyCode));
            pnlCard = new Guna2Panel();
            lblTitle = new Label();
            lblDescription = new Label();
            txtCode = new Guna2TextBox();
            btnVerify = new Guna2Button();
            lblResend = new LinkLabel();
            lblBackToLogin = new LinkLabel();
            resendTimer = new System.Windows.Forms.Timer(components);
            shadow = new Guna2ShadowForm(components);
            pictureBox2 = new PictureBox();
            label1 = new Label();
            pnlCard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // pnlCard
            // 
            pnlCard.BackColor = Color.FromArgb(39, 39, 42);
            pnlCard.BorderRadius = 18;
            pnlCard.Controls.Add(pictureBox2);
            pnlCard.Controls.Add(label1);
            pnlCard.Controls.Add(lblTitle);
            pnlCard.Controls.Add(lblDescription);
            pnlCard.Controls.Add(txtCode);
            pnlCard.Controls.Add(btnVerify);
            pnlCard.Controls.Add(lblResend);
            pnlCard.Controls.Add(lblBackToLogin);
            pnlCard.CustomizableEdges = customizableEdges5;
            pnlCard.Location = new Point(170, 30);
            pnlCard.Name = "pnlCard";
            pnlCard.ShadowDecoration.CustomizableEdges = customizableEdges6;
            pnlCard.Size = new Size(460, 510);
            pnlCard.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 17F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(50, 200);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(150, 31);
            lblTitle.TabIndex = 3;
            lblTitle.Text = "Mã xác nhận";
            // 
            // lblDescription
            // 
            lblDescription.AutoSize = true;
            lblDescription.Font = new Font("Segoe UI", 9.5F);
            lblDescription.ForeColor = Color.FromArgb(160, 160, 166);
            lblDescription.Location = new Point(50, 235);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(311, 17);
            lblDescription.TabIndex = 4;
            lblDescription.Text = "Vui lòng nhập mã 8 số được gửi đến email của bạn.";
            // 
            // txtCode
            // 
            txtCode.BorderColor = Color.FromArgb(63, 63, 70);
            txtCode.BorderRadius = 10;
            txtCode.CustomizableEdges = customizableEdges1;
            txtCode.DefaultText = "";
            txtCode.DisabledState.BorderColor = Color.FromArgb(63, 63, 70);
            txtCode.DisabledState.FillColor = Color.FromArgb(45, 45, 48);
            txtCode.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            txtCode.DisabledState.PlaceholderForeColor = Color.FromArgb(125, 137, 149);
            txtCode.FillColor = Color.FromArgb(30, 30, 33);
            txtCode.FocusedState.BorderColor = Color.FromArgb(31, 138, 154);
            txtCode.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            txtCode.ForeColor = Color.White;
            txtCode.HoverState.BorderColor = Color.FromArgb(120, 120, 130);
            txtCode.Location = new Point(50, 280);
            txtCode.Name = "txtCode";
            txtCode.PasswordChar = '\0';
            txtCode.PlaceholderForeColor = Color.FromArgb(110, 110, 120);
            txtCode.PlaceholderText = "Nhập mã 8 số";
            txtCode.SelectedText = "";
            txtCode.ShadowDecoration.CustomizableEdges = customizableEdges2;
            txtCode.Size = new Size(360, 50);
            txtCode.TabIndex = 5;
            txtCode.TextAlign = HorizontalAlignment.Center;
            // 
            // btnVerify
            // 
            btnVerify.BorderRadius = 10;
            btnVerify.Cursor = Cursors.Hand;
            btnVerify.CustomizableEdges = customizableEdges3;
            btnVerify.DisabledState.BorderColor = Color.DarkGray;
            btnVerify.DisabledState.CustomBorderColor = Color.DarkGray;
            btnVerify.DisabledState.FillColor = Color.FromArgb(80, 80, 80);
            btnVerify.DisabledState.ForeColor = Color.FromArgb(190, 190, 190);
            btnVerify.FillColor = Color.FromArgb(31, 138, 154);
            btnVerify.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnVerify.ForeColor = Color.White;
            btnVerify.HoverState.FillColor = Color.FromArgb(45, 158, 174);
            btnVerify.Location = new Point(50, 350);
            btnVerify.Name = "btnVerify";
            btnVerify.ShadowDecoration.CustomizableEdges = customizableEdges4;
            btnVerify.Size = new Size(360, 46);
            btnVerify.TabIndex = 6;
            btnVerify.Text = "Xác nhận";
            btnVerify.Click += btnVerify_Click;
            // 
            // lblResend
            // 
            lblResend.ActiveLinkColor = Color.FromArgb(220, 190, 120);
            lblResend.AutoSize = true;
            lblResend.Font = new Font("Segoe UI", 9.5F);
            lblResend.LinkBehavior = LinkBehavior.HoverUnderline;
            lblResend.LinkColor = Color.FromArgb(201, 169, 97);
            lblResend.Location = new Point(80, 420);
            lblResend.Name = "lblResend";
            lblResend.Size = new Size(67, 17);
            lblResend.TabIndex = 7;
            lblResend.TabStop = true;
            lblResend.Text = "Gửi lại mã";
            lblResend.LinkClicked += lblResend_LinkClicked;
            // 
            // lblBackToLogin
            // 
            lblBackToLogin.ActiveLinkColor = Color.FromArgb(31, 138, 154);
            lblBackToLogin.AutoSize = true;
            lblBackToLogin.Font = new Font("Segoe UI", 9.5F);
            lblBackToLogin.LinkBehavior = LinkBehavior.HoverUnderline;
            lblBackToLogin.LinkColor = Color.FromArgb(160, 160, 166);
            lblBackToLogin.Location = new Point(265, 420);
            lblBackToLogin.Name = "lblBackToLogin";
            lblBackToLogin.Size = new Size(137, 17);
            lblBackToLogin.TabIndex = 8;
            lblBackToLogin.TabStop = true;
            lblBackToLogin.Text = "← Quay lại đăng nhập";
            lblBackToLogin.LinkClicked += lblBackToLogin_LinkClicked;
            // 
            // resendTimer
            // 
            resendTimer.Interval = 1000;
            resendTimer.Tick += timer1_Tick;
            // 
            // shadow
            // 
            shadow.TargetForm = this;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(3, 30);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(460, 113);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 11;
            pictureBox2.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            label1.ForeColor = Color.White;
            label1.Location = new Point(183, 146);
            label1.Name = "label1";
            label1.Size = new Size(107, 37);
            label1.TabIndex = 10;
            label1.Text = "QLCafe";
            // 
            // VerifyCode
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(24, 24, 27);
            ClientSize = new Size(800, 580);
            Controls.Add(pnlCard);
            FormBorderStyle = FormBorderStyle.None;
            Name = "VerifyCode";
            Load += VerifyCode_Load;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Xác nhận mã - QLCafe";
            pnlCard.ResumeLayout(false);
            pnlCard.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Guna2Panel pnlCard;
        private Guna2CirclePictureBox picLogo;
        private Label lblBrand;
        private Label lblTagline;
        private Label lblTitle;
        private Label lblDescription;
        private Guna2TextBox txtCode;
        private Guna2Button btnVerify;
        private LinkLabel lblResend;
        private LinkLabel lblBackToLogin;
        private System.Windows.Forms.Timer resendTimer;
        private Guna2ShadowForm shadow;
        private PictureBox pictureBox2;
        private Label label1;
    }
}
