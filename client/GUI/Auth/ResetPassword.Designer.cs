using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace GUI
{
    partial class ResetPassword
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges11 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges12 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ResetPassword));
            pnlCard = new Guna2Panel();
            lblTitle = new Label();
            lblDescription = new Label();
            txtNewPass = new Guna2TextBox();
            txtConfirmPass = new Guna2TextBox();
            btnShowNewPass = new Guna2Button();
            btnShowConfirmPass = new Guna2Button();
            btnSave = new Guna2Button();
            lblBackToLogin = new LinkLabel();
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
            pnlCard.Controls.Add(txtNewPass);
            pnlCard.Controls.Add(btnShowNewPass);
            pnlCard.Controls.Add(txtConfirmPass);
            pnlCard.Controls.Add(btnShowConfirmPass);
            pnlCard.Controls.Add(btnSave);
            pnlCard.Controls.Add(lblBackToLogin);
            pnlCard.CustomizableEdges = customizableEdges9;
            pnlCard.Location = new Point(170, 20);
            pnlCard.Name = "pnlCard";
            pnlCard.ShadowDecoration.CustomizableEdges = customizableEdges10;
            pnlCard.Size = new Size(460, 560);
            pnlCard.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 17F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(50, 200);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(208, 31);
            lblTitle.TabIndex = 3;
            lblTitle.Text = "Tạo mật khẩu mới";
            // 
            // lblDescription
            // 
            lblDescription.AutoSize = true;
            lblDescription.Font = new Font("Segoe UI", 9.5F);
            lblDescription.ForeColor = Color.FromArgb(160, 160, 166);
            lblDescription.Location = new Point(50, 235);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(281, 17);
            lblDescription.TabIndex = 4;
            lblDescription.Text = "Vui lòng nhập mật khẩu mới của bạn dưới đây.";
            // 
            // txtNewPass
            // 
            txtNewPass.BorderColor = Color.FromArgb(63, 63, 70);
            txtNewPass.BorderRadius = 10;
            txtNewPass.CustomizableEdges = customizableEdges1;
            txtNewPass.DefaultText = "";
            txtNewPass.DisabledState.BorderColor = Color.FromArgb(63, 63, 70);
            txtNewPass.DisabledState.FillColor = Color.FromArgb(45, 45, 48);
            txtNewPass.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            txtNewPass.DisabledState.PlaceholderForeColor = Color.FromArgb(125, 137, 149);
            txtNewPass.FillColor = Color.FromArgb(30, 30, 33);
            txtNewPass.FocusedState.BorderColor = Color.FromArgb(31, 138, 154);
            txtNewPass.Font = new Font("Segoe UI", 10.5F);
            txtNewPass.ForeColor = Color.White;
            txtNewPass.HoverState.BorderColor = Color.FromArgb(120, 120, 130);
            txtNewPass.Location = new Point(50, 280);
            txtNewPass.Name = "txtNewPass";
            txtNewPass.PasswordChar = '●';
            txtNewPass.PlaceholderForeColor = Color.FromArgb(110, 110, 120);
            txtNewPass.PlaceholderText = "Mật khẩu mới";
            txtNewPass.SelectedText = "";
            txtNewPass.ShadowDecoration.CustomizableEdges = customizableEdges2;
            txtNewPass.Size = new Size(297, 46);
            txtNewPass.TabIndex = 5;
            txtNewPass.UseSystemPasswordChar = true;
            txtNewPass.TextChanged += TxtNewPass_TextChanged;
            //
            // btnShowNewPass
            //
            btnShowNewPass.BorderRadius = 8;
            btnShowNewPass.BorderColor = Color.FromArgb(63, 63, 70);
            btnShowNewPass.BorderThickness = 1;
            btnShowNewPass.Cursor = Cursors.Hand;
            btnShowNewPass.CustomizableEdges = customizableEdges11;
            btnShowNewPass.FillColor = Color.FromArgb(30, 30, 33);
            btnShowNewPass.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            btnShowNewPass.ForeColor = Color.FromArgb(200, 200, 205);
            btnShowNewPass.HoverState.FillColor = Color.FromArgb(55, 55, 60);
            btnShowNewPass.HoverState.ForeColor = Color.White;
            btnShowNewPass.Location = new Point(353, 280);
            btnShowNewPass.Name = "btnShowNewPass";
            btnShowNewPass.ShadowDecoration.CustomizableEdges = customizableEdges12;
            btnShowNewPass.Size = new Size(54, 46);
            btnShowNewPass.TabIndex = 12;
            btnShowNewPass.Text = "Hiện";
            btnShowNewPass.MouseDown += BtnShowNewPass_MouseDown;
            btnShowNewPass.MouseUp   += BtnShowNewPass_MouseUp;
            //
            // txtConfirmPass
            //
            txtConfirmPass.BorderColor = Color.FromArgb(63, 63, 70);
            txtConfirmPass.BorderRadius = 10;
            txtConfirmPass.CustomizableEdges = customizableEdges3;
            txtConfirmPass.DefaultText = "";
            txtConfirmPass.DisabledState.BorderColor = Color.FromArgb(63, 63, 70);
            txtConfirmPass.DisabledState.FillColor = Color.FromArgb(45, 45, 48);
            txtConfirmPass.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            txtConfirmPass.DisabledState.PlaceholderForeColor = Color.FromArgb(125, 137, 149);
            txtConfirmPass.FillColor = Color.FromArgb(30, 30, 33);
            txtConfirmPass.FocusedState.BorderColor = Color.FromArgb(31, 138, 154);
            txtConfirmPass.Font = new Font("Segoe UI", 10.5F);
            txtConfirmPass.ForeColor = Color.White;
            txtConfirmPass.HoverState.BorderColor = Color.FromArgb(120, 120, 130);
            txtConfirmPass.Location = new Point(50, 345);
            txtConfirmPass.Name = "txtConfirmPass";
            txtConfirmPass.PasswordChar = '●';
            txtConfirmPass.PlaceholderForeColor = Color.FromArgb(110, 110, 120);
            txtConfirmPass.PlaceholderText = "Xác nhận mật khẩu";
            txtConfirmPass.SelectedText = "";
            txtConfirmPass.ShadowDecoration.CustomizableEdges = customizableEdges4;
            txtConfirmPass.Size = new Size(297, 46);
            txtConfirmPass.TabIndex = 6;
            txtConfirmPass.UseSystemPasswordChar = true;
            // 
            // btnShowConfirmPass
            // 
            btnShowConfirmPass.BorderRadius = 8;
            btnShowConfirmPass.BorderColor = Color.FromArgb(63, 63, 70);
            btnShowConfirmPass.BorderThickness = 1;
            btnShowConfirmPass.Cursor = Cursors.Hand;
            btnShowConfirmPass.CustomizableEdges = customizableEdges5;
            btnShowConfirmPass.FillColor = Color.FromArgb(30, 30, 33);
            btnShowConfirmPass.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            btnShowConfirmPass.ForeColor = Color.FromArgb(200, 200, 205);
            btnShowConfirmPass.HoverState.FillColor = Color.FromArgb(55, 55, 60);
            btnShowConfirmPass.HoverState.ForeColor = Color.White;
            btnShowConfirmPass.Location = new Point(353, 345);
            btnShowConfirmPass.Name = "btnShowConfirmPass";
            btnShowConfirmPass.ShadowDecoration.CustomizableEdges = customizableEdges6;
            btnShowConfirmPass.Size = new Size(54, 46);
            btnShowConfirmPass.TabIndex = 7;
            btnShowConfirmPass.Text = "Hiện";
            btnShowConfirmPass.MouseDown += BtnShowConfirmPass_MouseDown;
            btnShowConfirmPass.MouseUp   += BtnShowConfirmPass_MouseUp;
            // 
            // btnSave
            // 
            btnSave.BorderRadius = 10;
            btnSave.Cursor = Cursors.Hand;
            btnSave.CustomizableEdges = customizableEdges7;
            btnSave.DisabledState.BorderColor = Color.DarkGray;
            btnSave.DisabledState.CustomBorderColor = Color.DarkGray;
            btnSave.DisabledState.FillColor = Color.FromArgb(80, 80, 80);
            btnSave.DisabledState.ForeColor = Color.FromArgb(190, 190, 190);
            btnSave.FillColor = Color.FromArgb(31, 138, 154);
            btnSave.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnSave.ForeColor = Color.White;
            btnSave.HoverState.FillColor = Color.FromArgb(45, 158, 174);
            btnSave.Location = new Point(50, 415);
            btnSave.Name = "btnSave";
            btnSave.ShadowDecoration.CustomizableEdges = customizableEdges8;
            btnSave.Size = new Size(360, 46);
            btnSave.TabIndex = 8;
            btnSave.Text = "Lưu mật khẩu mới";
            btnSave.Click += BtnSave_Click;
            // 
            // lblBackToLogin
            // 
            lblBackToLogin.ActiveLinkColor = Color.FromArgb(31, 138, 154);
            lblBackToLogin.AutoSize = true;
            lblBackToLogin.Font = new Font("Segoe UI", 9.5F);
            lblBackToLogin.LinkBehavior = LinkBehavior.HoverUnderline;
            lblBackToLogin.LinkColor = Color.FromArgb(160, 160, 166);
            lblBackToLogin.Location = new Point(150, 495);
            lblBackToLogin.Name = "lblBackToLogin";
            lblBackToLogin.Size = new Size(137, 17);
            lblBackToLogin.TabIndex = 9;
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
            pictureBox2.Location = new Point(0, 27);
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
            label1.Location = new Point(180, 143);
            label1.Name = "label1";
            label1.Size = new Size(107, 37);
            label1.TabIndex = 10;
            label1.Text = "QLCafe";
            // 
            // ResetPassword
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(24, 24, 27);
            ClientSize = new Size(800, 620);
            Controls.Add(pnlCard);
            FormBorderStyle = FormBorderStyle.None;
            Name = "ResetPassword";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Tạo mật khẩu mới - QLCafe";
            pnlCard.ResumeLayout(false);
            pnlCard.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Guna2Panel pnlCard;
        private Guna2CirclePictureBox picLogo;
        private Label lblTitle;
        private Label lblDescription;
        private Guna2TextBox txtNewPass;
        private Guna2TextBox txtConfirmPass;
        private Guna2Button btnShowNewPass;
        private Guna2Button btnShowConfirmPass;
        private Guna2Button btnSave;
        private LinkLabel lblBackToLogin;
        private Guna2ShadowForm shadow;
        private PictureBox pictureBox2;
        private Label label1;
    }
}
