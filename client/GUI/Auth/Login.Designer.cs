using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace GUI
{
    partial class Login
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges13 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges14 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges11 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges12 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges15 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges16 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            pnlLeft = new Guna2Panel();
            pictureBox1 = new PictureBox();
            pnlRight = new Panel();
            pnlCard = new Guna2Panel();
            lblWelcome = new Label();
            lblSubtitle = new Label();
            txtEmail = new Guna2TextBox();
            txtPassword = new Guna2TextBox();
            btnShowPass = new Guna2Button();
            chkRememberMe = new Guna2CustomCheckBox();
            lblRememberMe = new Label();
            lblForgotPass = new LinkLabel();
            btnSignIn = new Guna2Button();
            btnClose = new Guna2Button();
            shadow = new Guna2ShadowForm(components);
            pnlLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            pnlRight.SuspendLayout();
            pnlCard.SuspendLayout();
            SuspendLayout();
            // 
            // pnlLeft
            // 
            pnlLeft.BackColor = Color.FromArgb(24, 24, 27);
            pnlLeft.Controls.Add(pictureBox1);
            pnlLeft.CustomizableEdges = customizableEdges1;
            pnlLeft.Dock = DockStyle.Left;
            pnlLeft.Location = new Point(0, 0);
            pnlLeft.Name = "pnlLeft";
            pnlLeft.ShadowDecoration.CustomizableEdges = customizableEdges2;
            pnlLeft.Size = new Size(380, 560);
            pnlLeft.TabIndex = 0;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.FromArgb(40, 30, 25);
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(-221, -3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(610, 560);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // pnlRight
            // 
            pnlRight.BackColor = Color.FromArgb(24, 24, 27);
            pnlRight.Controls.Add(pnlCard);
            pnlRight.Controls.Add(btnClose);
            pnlRight.Dock = DockStyle.Fill;
            pnlRight.Location = new Point(380, 0);
            pnlRight.Name = "pnlRight";
            pnlRight.Size = new Size(580, 560);
            pnlRight.TabIndex = 1;
            // 
            // pnlCard
            // 
            pnlCard.BackColor = Color.FromArgb(39, 39, 42);
            pnlCard.BorderRadius = 18;
            pnlCard.Controls.Add(btnShowPass);
            pnlCard.Controls.Add(lblWelcome);
            pnlCard.Controls.Add(lblSubtitle);
            pnlCard.Controls.Add(txtEmail);
            pnlCard.Controls.Add(txtPassword);
            pnlCard.Controls.Add(chkRememberMe);
            pnlCard.Controls.Add(lblRememberMe);
            pnlCard.Controls.Add(lblForgotPass);
            pnlCard.Controls.Add(btnSignIn);
            pnlCard.CustomizableEdges = customizableEdges13;
            pnlCard.ForeColor = SystemColors.WindowText;
            pnlCard.Location = new Point(70, 70);
            pnlCard.Name = "pnlCard";
            pnlCard.ShadowDecoration.CustomizableEdges = customizableEdges14;
            pnlCard.Size = new Size(440, 430);
            pnlCard.TabIndex = 1;
            // 
            // lblWelcome
            // 
            lblWelcome.AutoSize = true;
            lblWelcome.Font = new Font("Segoe UI", 19F, FontStyle.Bold);
            lblWelcome.ForeColor = Color.White;
            lblWelcome.Location = new Point(40, 39);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(279, 36);
            lblWelcome.TabIndex = 0;
            lblWelcome.Text = "Chào mừng trở lại 👋";
            // 
            // lblSubtitle
            // 
            lblSubtitle.AutoSize = true;
            lblSubtitle.Font = new Font("Segoe UI", 9.5F);
            lblSubtitle.ForeColor = Color.FromArgb(160, 160, 166);
            lblSubtitle.Location = new Point(40, 75);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.Size = new Size(242, 17);
            lblSubtitle.TabIndex = 1;
            lblSubtitle.Text = "Vui lòng đăng nhập tài khoản nhân viên.";
            // 
            // txtEmail
            // 
            txtEmail.BorderColor = Color.FromArgb(63, 63, 70);
            txtEmail.BorderRadius = 10;
            txtEmail.CustomizableEdges = customizableEdges5;
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
            txtEmail.Location = new Point(40, 130);
            txtEmail.Name = "txtEmail";
            txtEmail.PasswordChar = '\0';
            txtEmail.PlaceholderForeColor = Color.FromArgb(110, 110, 120);
            txtEmail.PlaceholderText = "📧  Email nhân viên";
            txtEmail.SelectedText = "";
            txtEmail.ShadowDecoration.CustomizableEdges = customizableEdges6;
            txtEmail.Size = new Size(360, 46);
            txtEmail.TabIndex = 0;
            // 
            // txtPassword
            // 
            txtPassword.BorderColor = Color.FromArgb(63, 63, 70);
            txtPassword.BorderRadius = 10;
            txtPassword.CustomizableEdges = customizableEdges7;
            txtPassword.DefaultText = "";
            txtPassword.DisabledState.BorderColor = Color.FromArgb(63, 63, 70);
            txtPassword.DisabledState.FillColor = Color.FromArgb(45, 45, 48);
            txtPassword.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            txtPassword.DisabledState.PlaceholderForeColor = Color.FromArgb(125, 137, 149);
            txtPassword.FillColor = Color.FromArgb(30, 30, 33);
            txtPassword.FocusedState.BorderColor = Color.FromArgb(31, 138, 154);
            txtPassword.Font = new Font("Segoe UI", 10.5F);
            txtPassword.ForeColor = Color.White;
            txtPassword.HoverState.BorderColor = Color.FromArgb(120, 120, 130);
            txtPassword.Location = new Point(40, 195);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '●';
            txtPassword.PlaceholderForeColor = Color.FromArgb(110, 110, 120);
            txtPassword.PlaceholderText = "🔒  Mật khẩu";
            txtPassword.SelectedText = "";
            txtPassword.ShadowDecoration.CustomizableEdges = customizableEdges8;
            txtPassword.Size = new Size(297, 46);
            txtPassword.TabIndex = 1;
            txtPassword.UseSystemPasswordChar = true;
            // 
            // btnShowPass
            // 
            btnShowPass.BorderRadius = 8;
            btnShowPass.BorderColor = Color.FromArgb(63, 63, 70);
            btnShowPass.BorderThickness = 1;
            btnShowPass.Cursor = Cursors.Hand;
            btnShowPass.CustomizableEdges = customizableEdges3;
            btnShowPass.FillColor = Color.FromArgb(30, 30, 33);
            btnShowPass.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            btnShowPass.ForeColor = Color.FromArgb(200, 200, 205);
            btnShowPass.HoverState.FillColor = Color.FromArgb(55, 55, 60);
            btnShowPass.HoverState.ForeColor = Color.White;
            btnShowPass.Location = new Point(343, 195);
            btnShowPass.Name = "btnShowPass";
            btnShowPass.ShadowDecoration.CustomizableEdges = customizableEdges4;
            btnShowPass.Size = new Size(54, 46);
            btnShowPass.TabIndex = 2;
            btnShowPass.Text = "Hiện";
            btnShowPass.MouseDown += BtnShowPass_MouseDown;
            btnShowPass.MouseUp   += BtnShowPass_MouseUp;
            // 
            // chkRememberMe
            // 
            chkRememberMe.Animated = true;
            chkRememberMe.CheckedState.BorderColor = Color.FromArgb(31, 138, 154);
            chkRememberMe.CheckedState.BorderRadius = 4;
            chkRememberMe.CheckedState.BorderThickness = 0;
            chkRememberMe.CheckedState.FillColor = Color.FromArgb(31, 138, 154);
            chkRememberMe.CustomizableEdges = customizableEdges9;
            chkRememberMe.Location = new Point(40, 265);
            chkRememberMe.Name = "chkRememberMe";
            chkRememberMe.ShadowDecoration.CustomizableEdges = customizableEdges10;
            chkRememberMe.Size = new Size(20, 20);
            chkRememberMe.TabIndex = 3;
            chkRememberMe.UncheckedState.BorderColor = Color.FromArgb(100, 100, 110);
            chkRememberMe.UncheckedState.BorderRadius = 4;
            chkRememberMe.UncheckedState.BorderThickness = 1;
            chkRememberMe.UncheckedState.FillColor = Color.Transparent;
            // 
            // lblRememberMe
            // 
            lblRememberMe.AutoSize = true;
            lblRememberMe.Font = new Font("Segoe UI", 9.5F);
            lblRememberMe.ForeColor = Color.FromArgb(180, 180, 185);
            lblRememberMe.Location = new Point(66, 266);
            lblRememberMe.Name = "lblRememberMe";
            lblRememberMe.Size = new Size(120, 17);
            lblRememberMe.TabIndex = 4;
            lblRememberMe.Text = "Ghi nhớ đăng nhập";
            // 
            // lblForgotPass
            // 
            lblForgotPass.ActiveLinkColor = Color.FromArgb(45, 158, 174);
            lblForgotPass.AutoSize = true;
            lblForgotPass.Font = new Font("Segoe UI", 9.5F);
            lblForgotPass.LinkBehavior = LinkBehavior.HoverUnderline;
            lblForgotPass.LinkColor = Color.FromArgb(31, 138, 154);
            lblForgotPass.Location = new Point(295, 266);
            lblForgotPass.Name = "lblForgotPass";
            lblForgotPass.Size = new Size(102, 17);
            lblForgotPass.TabIndex = 5;
            lblForgotPass.TabStop = true;
            lblForgotPass.Text = "Quên mật khẩu?";
            lblForgotPass.LinkClicked += LblForgotPass_LinkClicked;
            // 
            // btnSignIn
            // 
            btnSignIn.BorderRadius = 10;
            btnSignIn.Cursor = Cursors.Hand;
            btnSignIn.CustomizableEdges = customizableEdges11;
            btnSignIn.DisabledState.BorderColor = Color.DarkGray;
            btnSignIn.DisabledState.CustomBorderColor = Color.DarkGray;
            btnSignIn.DisabledState.FillColor = Color.FromArgb(80, 80, 80);
            btnSignIn.DisabledState.ForeColor = Color.FromArgb(190, 190, 190);
            btnSignIn.FillColor = Color.FromArgb(31, 138, 154);
            btnSignIn.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnSignIn.ForeColor = Color.White;
            btnSignIn.HoverState.FillColor = Color.FromArgb(45, 158, 174);
            btnSignIn.Location = new Point(40, 320);
            btnSignIn.Name = "btnSignIn";
            btnSignIn.ShadowDecoration.CustomizableEdges = customizableEdges12;
            btnSignIn.Size = new Size(360, 48);
            btnSignIn.TabIndex = 4;
            btnSignIn.Text = "Đăng nhập";
            btnSignIn.Click += BtnSignIn_Click;
            // 
            // btnClose
            // 
            btnClose.BorderRadius = 8;
            btnClose.Cursor = Cursors.Hand;
            btnClose.CustomizableEdges = customizableEdges15;
            btnClose.FillColor = Color.Transparent;
            btnClose.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnClose.ForeColor = Color.FromArgb(220, 220, 225);
            btnClose.HoverState.FillColor = Color.FromArgb(180, 60, 60);
            btnClose.HoverState.ForeColor = Color.White;
            btnClose.Location = new Point(536, 14);
            btnClose.Name = "btnClose";
            btnClose.ShadowDecoration.CustomizableEdges = customizableEdges16;
            btnClose.Size = new Size(30, 32);
            btnClose.TabIndex = 10;
            btnClose.Text = "✕";
            btnClose.Click += BtnClose_Click;
            // 
            // shadow
            // 
            shadow.TargetForm = this;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(24, 24, 27);
            ClientSize = new Size(960, 560);
            Controls.Add(pnlRight);
            Controls.Add(pnlLeft);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Login";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Đăng nhập - QLCafe";
            pnlLeft.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            pnlRight.ResumeLayout(false);
            pnlCard.ResumeLayout(false);
            pnlCard.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Guna2Panel pnlLeft;
        private PictureBox pictureBox1;
        private Panel pnlRight;
        private Guna2Panel pnlCard;
        private Label lblWelcome;
        private Label lblSubtitle;
        private Guna2TextBox txtEmail;
        private Guna2TextBox txtPassword;
        private Guna2Button btnShowPass;
        private Guna2CustomCheckBox chkRememberMe;
        private Label lblRememberMe;
        private LinkLabel lblForgotPass;
        private Guna2Button btnSignIn;
        private Guna2ShadowForm shadow;
        private Guna2Button btnClose;
    }
}
