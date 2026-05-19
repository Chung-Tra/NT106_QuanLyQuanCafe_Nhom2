using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace GUI
{
    partial class MainDashboard
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges18 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges19 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges16 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges17 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainDashboard));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges14 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges15 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            pnlSidebar = new Guna2Panel();
            pnlMenuScroll = new Panel();
            pnlLogoutWrap = new Panel();
            btnLogout = new Guna2Button();
            pnlMainContent = new Guna2Panel();
            pnlContentHost = new Panel();
            lblWelcome = new Label();
            pnlSubHeader = new Panel();
            lblTitle = new Label();
            pnlUserCard = new Guna2Panel();
            picAvatar = new Guna2CirclePictureBox();
            lblUserName = new Label();
            lblUserRole = new Label();
            lblSubtitle = new Label();
            pnlHeader = new Guna2Panel();
            pnlLogoBlock = new Panel();
            pictureBox2 = new PictureBox();
            lblBrand = new Label();
            lblTagline = new Label();
            lblDate = new Label();
            btnClose = new Guna2Button();
            pnlSidebar.SuspendLayout();
            pnlLogoutWrap.SuspendLayout();
            pnlMainContent.SuspendLayout();
            pnlContentHost.SuspendLayout();
            pnlSubHeader.SuspendLayout();
            pnlUserCard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picAvatar).BeginInit();
            pnlHeader.SuspendLayout();
            pnlLogoBlock.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // pnlSidebar
            // 
            pnlSidebar.BackColor = Color.FromArgb(31, 31, 34);
            pnlSidebar.Controls.Add(pnlMenuScroll);
            pnlSidebar.Controls.Add(pnlLogoutWrap);
            pnlSidebar.CustomizableEdges = customizableEdges3;
            pnlSidebar.Dock = DockStyle.Left;
            pnlSidebar.Location = new Point(0, 0);
            pnlSidebar.Name = "pnlSidebar";
            pnlSidebar.ShadowDecoration.CustomizableEdges = customizableEdges4;
            pnlSidebar.Size = new Size(240, 820);
            pnlSidebar.TabIndex = 0;
            // 
            // pnlMenuScroll
            // 
            pnlMenuScroll.BackColor = Color.FromArgb(31, 31, 34);
            pnlMenuScroll.Dock = DockStyle.Fill;
            pnlMenuScroll.Location = new Point(0, 0);
            pnlMenuScroll.Name = "pnlMenuScroll";
            pnlMenuScroll.Padding = new Padding(14, 18, 14, 8);
            pnlMenuScroll.Size = new Size(240, 750);
            pnlMenuScroll.TabIndex = 0;
            pnlMenuScroll.Resize += PnlMenuScroll_Resize;
            // 
            // pnlLogoutWrap
            // 
            pnlLogoutWrap.BackColor = Color.FromArgb(31, 31, 34);
            pnlLogoutWrap.Controls.Add(btnLogout);
            pnlLogoutWrap.Dock = DockStyle.Bottom;
            pnlLogoutWrap.Location = new Point(0, 750);
            pnlLogoutWrap.Name = "pnlLogoutWrap";
            pnlLogoutWrap.Padding = new Padding(14, 6, 14, 14);
            pnlLogoutWrap.Size = new Size(240, 70);
            pnlLogoutWrap.TabIndex = 1;
            // 
            // btnLogout
            // 
            btnLogout.BorderRadius = 10;
            btnLogout.Cursor = Cursors.Hand;
            btnLogout.CustomizableEdges = customizableEdges1;
            btnLogout.Dock = DockStyle.Fill;
            btnLogout.FillColor = Color.Transparent;
            btnLogout.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnLogout.ForeColor = Color.FromArgb(220, 80, 80);
            btnLogout.HoverState.FillColor = Color.FromArgb(180, 60, 60);
            btnLogout.HoverState.ForeColor = Color.White;
            btnLogout.Location = new Point(14, 6);
            btnLogout.Name = "btnLogout";
            btnLogout.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnLogout.Size = new Size(212, 50);
            btnLogout.TabIndex = 0;
            btnLogout.Text = "🚪  Đăng xuất";
            btnLogout.Click += BtnLogout_Click;
            // 
            // pnlMainContent
            // 
            pnlMainContent.BackColor = Color.FromArgb(39, 39, 42);
            pnlMainContent.Controls.Add(pnlContentHost);
            pnlMainContent.Controls.Add(pnlSubHeader);
            pnlMainContent.Controls.Add(pnlHeader);
            pnlMainContent.CustomizableEdges = customizableEdges18;
            pnlMainContent.Dock = DockStyle.Fill;
            pnlMainContent.Location = new Point(240, 0);
            pnlMainContent.Name = "pnlMainContent";
            pnlMainContent.ShadowDecoration.CustomizableEdges = customizableEdges19;
            pnlMainContent.Size = new Size(1000, 820);
            pnlMainContent.TabIndex = 1;
            // 
            // pnlContentHost
            // 
            pnlContentHost.BackColor = Color.FromArgb(39, 39, 42);
            pnlContentHost.Controls.Add(lblWelcome);
            pnlContentHost.Dock = DockStyle.Fill;
            pnlContentHost.Location = new Point(0, 140);
            pnlContentHost.Name = "pnlContentHost";
            pnlContentHost.Padding = new Padding(20);
            pnlContentHost.Size = new Size(1000, 680);
            pnlContentHost.TabIndex = 2;
            // 
            // lblWelcome
            // 
            lblWelcome.AutoSize = true;
            lblWelcome.Font = new Font("Segoe UI", 13F);
            lblWelcome.ForeColor = Color.FromArgb(110, 110, 115);
            lblWelcome.Location = new Point(315, 265);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(386, 25);
            lblWelcome.TabIndex = 0;
            lblWelcome.Text = "Vui lòng chọn một mục từ thanh menu bên trái";
            // 
            // pnlSubHeader
            // 
            pnlSubHeader.BackColor = Color.FromArgb(39, 39, 42);
            pnlSubHeader.Controls.Add(lblTitle);
            pnlSubHeader.Controls.Add(pnlUserCard);
            pnlSubHeader.Controls.Add(lblSubtitle);
            pnlSubHeader.Dock = DockStyle.Top;
            pnlSubHeader.Location = new Point(0, 80);
            pnlSubHeader.Name = "pnlSubHeader";
            pnlSubHeader.Size = new Size(1000, 60);
            pnlSubHeader.TabIndex = 1;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 17F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(28, 8);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(129, 31);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Tổng quan";
            // 
            // pnlUserCard
            // 
            pnlUserCard.BackColor = Color.FromArgb(31, 31, 34);
            pnlUserCard.BorderRadius = 22;
            pnlUserCard.Controls.Add(picAvatar);
            pnlUserCard.Controls.Add(lblUserName);
            pnlUserCard.Controls.Add(lblUserRole);
            pnlUserCard.CustomizableEdges = customizableEdges6;
            pnlUserCard.Location = new Point(780, 0);
            pnlUserCard.Name = "pnlUserCard";
            pnlUserCard.ShadowDecoration.CustomizableEdges = customizableEdges7;
            pnlUserCard.Size = new Size(220, 60);
            pnlUserCard.TabIndex = 5;
            // 
            // picAvatar
            // 
            picAvatar.BackColor = Color.Transparent;
            picAvatar.FillColor = Color.FromArgb(232, 217, 196);
            picAvatar.ImageRotate = 0F;
            picAvatar.Location = new Point(6, 5);
            picAvatar.Name = "picAvatar";
            picAvatar.ShadowDecoration.CustomizableEdges = customizableEdges5;
            picAvatar.Size = new Size(34, 34);
            picAvatar.SizeMode = PictureBoxSizeMode.Zoom;
            picAvatar.TabIndex = 0;
            picAvatar.TabStop = false;
            // 
            // lblUserName
            // 
            lblUserName.AutoSize = true;
            lblUserName.BackColor = Color.Transparent;
            lblUserName.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblUserName.ForeColor = Color.White;
            lblUserName.Location = new Point(50, 5);
            lblUserName.Name = "lblUserName";
            lblUserName.Size = new Size(89, 19);
            lblUserName.TabIndex = 1;
            lblUserName.Text = "Người dùng";
            // 
            // lblUserRole
            // 
            lblUserRole.AutoSize = true;
            lblUserRole.BackColor = Color.Transparent;
            lblUserRole.Font = new Font("Segoe UI", 8.5F);
            lblUserRole.ForeColor = Color.FromArgb(160, 160, 166);
            lblUserRole.Location = new Point(50, 24);
            lblUserRole.Name = "lblUserRole";
            lblUserRole.Size = new Size(40, 15);
            lblUserRole.TabIndex = 2;
            lblUserRole.Text = "Vai trò";
            // 
            // lblSubtitle
            // 
            lblSubtitle.AutoSize = true;
            lblSubtitle.Font = new Font("Segoe UI", 9F);
            lblSubtitle.ForeColor = Color.FromArgb(150, 150, 155);
            lblSubtitle.Location = new Point(30, 40);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.Size = new Size(134, 15);
            lblSubtitle.TabIndex = 1;
            lblSubtitle.Text = "Bảng điều khiển QLCafe";
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.FromArgb(39, 39, 42);
            pnlHeader.Controls.Add(pnlLogoBlock);
            pnlHeader.Controls.Add(lblDate);
            pnlHeader.Controls.Add(btnClose);
            pnlHeader.CustomizableEdges = customizableEdges16;
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.ShadowDecoration.CustomizableEdges = customizableEdges17;
            pnlHeader.Size = new Size(1000, 80);
            pnlHeader.TabIndex = 0;
            // 
            // pnlLogoBlock
            // 
            pnlLogoBlock.BackColor = Color.Transparent;
            pnlLogoBlock.Controls.Add(pictureBox2);
            pnlLogoBlock.Controls.Add(lblBrand);
            pnlLogoBlock.Controls.Add(lblTagline);
            pnlLogoBlock.Location = new Point(20, 14);
            pnlLogoBlock.Name = "pnlLogoBlock";
            pnlLogoBlock.Size = new Size(200, 52);
            pnlLogoBlock.TabIndex = 0;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(0, 0);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(51, 52);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 10;
            pictureBox2.TabStop = false;
            // 
            // lblBrand
            // 
            lblBrand.AutoSize = true;
            lblBrand.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblBrand.ForeColor = Color.White;
            lblBrand.Location = new Point(56, 6);
            lblBrand.Name = "lblBrand";
            lblBrand.Size = new Size(73, 25);
            lblBrand.TabIndex = 1;
            lblBrand.Text = "QLCafe";
            // 
            // lblTagline
            // 
            lblTagline.AutoSize = true;
            lblTagline.Enabled = false;
            lblTagline.Font = new Font("Segoe UI", 8F, FontStyle.Italic);
            lblTagline.ForeColor = Color.FromArgb(140, 140, 145);
            lblTagline.Location = new Point(57, 32);
            lblTagline.Name = "lblTagline";
            lblTagline.Size = new Size(101, 13);
            lblTagline.TabIndex = 2;
            lblTagline.Text = "Tinh Tế & Công Nghệ";
            // 
            // lblDate
            // 
            lblDate.AutoSize = true;
            lblDate.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblDate.ForeColor = Color.FromArgb(200, 200, 205);
            lblDate.Location = new Point(240, 30);
            lblDate.Name = "lblDate";
            lblDate.Size = new Size(156, 19);
            lblDate.TabIndex = 1;
            lblDate.Text = "Thứ Năm, 08 tháng 05";
            //
            // btnClose
            // 
            btnClose.BorderRadius = 8;
            btnClose.Cursor = Cursors.Hand;
            btnClose.CustomizableEdges = customizableEdges14;
            btnClose.FillColor = Color.Transparent;
            btnClose.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnClose.ForeColor = Color.FromArgb(220, 220, 225);
            btnClose.HoverState.FillColor = Color.FromArgb(180, 60, 60);
            btnClose.HoverState.ForeColor = Color.White;
            btnClose.Location = new Point(956, 24);
            btnClose.Name = "btnClose";
            btnClose.ShadowDecoration.CustomizableEdges = customizableEdges15;
            btnClose.Size = new Size(30, 32);
            btnClose.TabIndex = 7;
            btnClose.Text = "✕";
            btnClose.Click += BtnClose_Click;
            // 
            // MainDashboard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(39, 39, 42);
            ClientSize = new Size(1240, 820);
            Controls.Add(pnlMainContent);
            Controls.Add(pnlSidebar);
            FormBorderStyle = FormBorderStyle.None;
            Name = "MainDashboard";
            Load += MainDashboard_Load;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "QLCafe";
            pnlSidebar.ResumeLayout(false);
            pnlLogoutWrap.ResumeLayout(false);
            pnlMainContent.ResumeLayout(false);
            pnlContentHost.ResumeLayout(false);
            pnlContentHost.PerformLayout();
            pnlSubHeader.ResumeLayout(false);
            pnlSubHeader.PerformLayout();
            pnlUserCard.ResumeLayout(false);
            pnlUserCard.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picAvatar).EndInit();
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            pnlLogoBlock.ResumeLayout(false);
            pnlLogoBlock.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Guna2Panel pnlSidebar;
        private Panel pnlMenuScroll;
        private Panel pnlLogoutWrap;
        private Guna2Button btnLogout;
        private Guna2Panel pnlMainContent;
        private Guna2Panel pnlHeader;
        private Panel pnlLogoBlock;
        private Label lblBrand;
        private Label lblTagline;
        private Label lblDate;
        private Guna2Panel pnlUserCard;
        private Guna2CirclePictureBox picAvatar;
        private Label lblUserName;
        private Label lblUserRole;
        private Guna2Button btnClose;
        private Panel pnlSubHeader;
        private Label lblTitle;
        private Label lblSubtitle;
        private Panel pnlContentHost;
        private Label lblWelcome;
        private PictureBox pictureBox2;
    }
}
