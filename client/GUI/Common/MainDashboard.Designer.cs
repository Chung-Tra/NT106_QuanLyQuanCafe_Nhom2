using System.Drawing;
using System.Windows.Forms;

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
            pnlSidebar = new Panel();
            btnLogout = new Button();
            pnlLogo = new Panel();
            lblLogo = new Label();
            pnlMainContent = new Panel();
            pnlHeader = new Panel();
            btnClose = new Button();
            lblTitle = new Label();
            lblWelcome = new Label();
            pnlSidebar.SuspendLayout();
            pnlLogo.SuspendLayout();
            pnlMainContent.SuspendLayout();
            pnlHeader.SuspendLayout();
            SuspendLayout();
            //
            // pnlSidebar
            //
            pnlSidebar.BackColor = Color.FromArgb(30, 30, 30);
            pnlSidebar.Controls.Add(btnLogout);
            pnlSidebar.Controls.Add(pnlLogo);
            pnlSidebar.Dock = DockStyle.Left;
            pnlSidebar.Location = new Point(0, 0);
            pnlSidebar.Name = "pnlSidebar";
            pnlSidebar.Size = new Size(220, 600);
            pnlSidebar.TabIndex = 0;
            //
            // btnLogout
            //
            btnLogout.Cursor = Cursors.Hand;
            btnLogout.Dock = DockStyle.Bottom;
            btnLogout.FlatAppearance.BorderSize = 0;
            btnLogout.FlatStyle = FlatStyle.Flat;
            btnLogout.Font = new Font("Segoe UI", 11F);
            btnLogout.ForeColor = Color.Gray;
            btnLogout.Location = new Point(0, 550);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(220, 50);
            btnLogout.TabIndex = 6;
            btnLogout.Text = "Đăng xuất";
            btnLogout.UseVisualStyleBackColor = true;
            btnLogout.Click += BtnLogout_Click;
            //
            // pnlLogo
            //
            pnlLogo.BackColor = Color.FromArgb(20, 20, 20);
            pnlLogo.Controls.Add(lblLogo);
            pnlLogo.Dock = DockStyle.Top;
            pnlLogo.Location = new Point(0, 0);
            pnlLogo.Name = "pnlLogo";
            pnlLogo.Size = new Size(220, 70);
            pnlLogo.TabIndex = 0;
            //
            // lblLogo
            //
            lblLogo.AutoSize = true;
            lblLogo.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblLogo.ForeColor = Color.Firebrick;
            lblLogo.Location = new Point(47, 19);
            lblLogo.Name = "lblLogo";
            lblLogo.Size = new Size(92, 30);
            lblLogo.TabIndex = 0;
            lblLogo.Text = "Dashboard";
            //
            // pnlMainContent
            //
            pnlMainContent.BackColor = Color.FromArgb(45, 45, 48);
            pnlMainContent.Controls.Add(pnlHeader);
            pnlMainContent.Controls.Add(lblWelcome);
            pnlMainContent.Dock = DockStyle.Fill;
            pnlMainContent.Location = new Point(220, 0);
            pnlMainContent.Name = "pnlMainContent";
            pnlMainContent.Size = new Size(804, 600);
            pnlMainContent.TabIndex = 2;
            //
            // pnlHeader
            //
            pnlHeader.BackColor = Color.FromArgb(30, 30, 30);
            pnlHeader.Controls.Add(btnClose);
            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(804, 70);
            pnlHeader.TabIndex = 2;
            //
            // btnClose
            //
            btnClose.Dock = DockStyle.Right;
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnClose.ForeColor = Color.IndianRed;
            btnClose.Location = new Point(754, 0);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(50, 70);
            btnClose.TabIndex = 0;
            btnClose.Text = "X";
            btnClose.Click += BtnClose_Click;
            //
            // lblTitle
            //
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(25, 23);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(178, 25);
            lblTitle.TabIndex = 1;
            lblTitle.Text = "BẢNG ĐIỀU KHIỂN";
            //
            // lblWelcome
            //
            lblWelcome.AutoSize = true;
            lblWelcome.Font = new Font("Segoe UI", 18F);
            lblWelcome.ForeColor = Color.Gray;
            lblWelcome.Location = new Point(153, 288);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(522, 32);
            lblWelcome.TabIndex = 0;
            lblWelcome.Text = "Vui lòng chọn một mục từ thanh menu bên trái";
            //
            // MainDashboard
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1024, 600);
            Controls.Add(pnlMainContent);
            Controls.Add(pnlSidebar);
            FormBorderStyle = FormBorderStyle.None;
            Name = "MainDashboard";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Coffee Management Dashboard";
            pnlSidebar.ResumeLayout(false);
            pnlLogo.ResumeLayout(false);
            pnlLogo.PerformLayout();
            pnlMainContent.ResumeLayout(false);
            pnlMainContent.PerformLayout();
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlSidebar;
        private Panel pnlLogo;
        private Label lblLogo;
        private Button btnLogout;
        private Panel pnlMainContent;
        private Label lblWelcome;
        private Panel pnlHeader;
        private Button btnClose;
        private Label lblTitle;
    }
}
