using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace GUI
{
    partial class ucOverview_Staff
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1  = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2  = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3  = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4  = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5  = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6  = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7  = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8  = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9  = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges11 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges12 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges13 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges14 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            pnlUnreadMsg         = new Guna2Panel();
            lblUnreadMsgTitle    = new Label();
            lblUnreadMsgValue    = new Label();
            btnDetailMsg         = new Guna2Button();
            pnlWorkingDays       = new Guna2Panel();
            lblWorkingDaysTitle  = new Label();
            lblWorkingDaysValue  = new Label();
            btnDetailWorkingDays = new Guna2Button();
            pnlDaysOff           = new Guna2Panel();
            lblDaysOffTitle      = new Label();
            lblDaysOffValue      = new Label();
            btnDetailDaysOff     = new Guna2Button();
            pnlNotif             = new Guna2Panel();
            lblNotifTitle        = new Label();
            lstNotifications     = new ListBox();
            pnlUnreadMsg.SuspendLayout();
            pnlWorkingDays.SuspendLayout();
            pnlDaysOff.SuspendLayout();
            pnlNotif.SuspendLayout();
            SuspendLayout();
            //
            // pnlUnreadMsg
            //
            pnlUnreadMsg.BackColor = Color.FromArgb(31, 31, 34);
            pnlUnreadMsg.BorderRadius = 14;
            pnlUnreadMsg.Controls.Add(lblUnreadMsgTitle);
            pnlUnreadMsg.Controls.Add(lblUnreadMsgValue);
            pnlUnreadMsg.Controls.Add(btnDetailMsg);
            pnlUnreadMsg.CustomizableEdges = customizableEdges1;
            pnlUnreadMsg.Location = new Point(20, 20);
            pnlUnreadMsg.Name = "pnlUnreadMsg";
            pnlUnreadMsg.ShadowDecoration.CustomizableEdges = customizableEdges2;
            pnlUnreadMsg.Size = new Size(290, 110);
            pnlUnreadMsg.TabIndex = 0;
            //
            // lblUnreadMsgTitle
            //
            lblUnreadMsgTitle.AutoSize = true;
            lblUnreadMsgTitle.Font = new Font("Segoe UI", 9F);
            lblUnreadMsgTitle.ForeColor = Color.FromArgb(160, 160, 166);
            lblUnreadMsgTitle.Location = new Point(18, 16);
            lblUnreadMsgTitle.Name = "lblUnreadMsgTitle";
            lblUnreadMsgTitle.Size = new Size(85, 15);
            lblUnreadMsgTitle.TabIndex = 0;
            lblUnreadMsgTitle.Text = "Tin chưa xem";
            //
            // lblUnreadMsgValue
            //
            lblUnreadMsgValue.AutoSize = true;
            lblUnreadMsgValue.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblUnreadMsgValue.ForeColor = Color.FromArgb(239, 68, 68);
            lblUnreadMsgValue.Location = new Point(18, 40);
            lblUnreadMsgValue.Name = "lblUnreadMsgValue";
            lblUnreadMsgValue.Size = new Size(76, 37);
            lblUnreadMsgValue.TabIndex = 1;
            lblUnreadMsgValue.Text = "5 tin";
            //
            // btnDetailMsg
            //
            btnDetailMsg.BorderRadius = 8;
            btnDetailMsg.Cursor = Cursors.Hand;
            btnDetailMsg.CustomizableEdges = customizableEdges3;
            btnDetailMsg.FillColor = Color.FromArgb(39, 39, 50);
            btnDetailMsg.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            btnDetailMsg.ForeColor = Color.FromArgb(31, 138, 154);
            btnDetailMsg.HoverState.FillColor = Color.FromArgb(31, 138, 154);
            btnDetailMsg.HoverState.ForeColor = Color.White;
            btnDetailMsg.Location = new Point(196, 16);
            btnDetailMsg.Name = "btnDetailMsg";
            btnDetailMsg.ShadowDecoration.CustomizableEdges = customizableEdges4;
            btnDetailMsg.Size = new Size(76, 28);
            btnDetailMsg.TabIndex = 2;
            btnDetailMsg.Text = "Cụ thể";
            //
            // pnlWorkingDays
            //
            pnlWorkingDays.BackColor = Color.FromArgb(31, 31, 34);
            pnlWorkingDays.BorderRadius = 14;
            pnlWorkingDays.Controls.Add(lblWorkingDaysTitle);
            pnlWorkingDays.Controls.Add(lblWorkingDaysValue);
            pnlWorkingDays.Controls.Add(btnDetailWorkingDays);
            pnlWorkingDays.CustomizableEdges = customizableEdges5;
            pnlWorkingDays.Location = new Point(325, 20);
            pnlWorkingDays.Name = "pnlWorkingDays";
            pnlWorkingDays.ShadowDecoration.CustomizableEdges = customizableEdges6;
            pnlWorkingDays.Size = new Size(290, 110);
            pnlWorkingDays.TabIndex = 1;
            //
            // lblWorkingDaysTitle
            //
            lblWorkingDaysTitle.AutoSize = true;
            lblWorkingDaysTitle.Font = new Font("Segoe UI", 9F);
            lblWorkingDaysTitle.ForeColor = Color.FromArgb(160, 160, 166);
            lblWorkingDaysTitle.Location = new Point(18, 16);
            lblWorkingDaysTitle.Name = "lblWorkingDaysTitle";
            lblWorkingDaysTitle.Size = new Size(152, 15);
            lblWorkingDaysTitle.TabIndex = 0;
            lblWorkingDaysTitle.Text = "Ngày đi làm trong tháng";
            //
            // lblWorkingDaysValue
            //
            lblWorkingDaysValue.AutoSize = true;
            lblWorkingDaysValue.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblWorkingDaysValue.ForeColor = Color.FromArgb(34, 197, 94);
            lblWorkingDaysValue.Location = new Point(18, 40);
            lblWorkingDaysValue.Name = "lblWorkingDaysValue";
            lblWorkingDaysValue.Size = new Size(110, 37);
            lblWorkingDaysValue.TabIndex = 1;
            lblWorkingDaysValue.Text = "23 ngày";
            //
            // btnDetailWorkingDays
            //
            btnDetailWorkingDays.BorderRadius = 8;
            btnDetailWorkingDays.Cursor = Cursors.Hand;
            btnDetailWorkingDays.CustomizableEdges = customizableEdges7;
            btnDetailWorkingDays.FillColor = Color.FromArgb(39, 39, 50);
            btnDetailWorkingDays.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            btnDetailWorkingDays.ForeColor = Color.FromArgb(34, 197, 94);
            btnDetailWorkingDays.HoverState.FillColor = Color.FromArgb(22, 163, 74);
            btnDetailWorkingDays.HoverState.ForeColor = Color.White;
            btnDetailWorkingDays.Location = new Point(196, 16);
            btnDetailWorkingDays.Name = "btnDetailWorkingDays";
            btnDetailWorkingDays.ShadowDecoration.CustomizableEdges = customizableEdges8;
            btnDetailWorkingDays.Size = new Size(76, 28);
            btnDetailWorkingDays.TabIndex = 2;
            btnDetailWorkingDays.Text = "Cụ thể";
            //
            // pnlDaysOff
            //
            pnlDaysOff.BackColor = Color.FromArgb(31, 31, 34);
            pnlDaysOff.BorderRadius = 14;
            pnlDaysOff.Controls.Add(lblDaysOffTitle);
            pnlDaysOff.Controls.Add(lblDaysOffValue);
            pnlDaysOff.Controls.Add(btnDetailDaysOff);
            pnlDaysOff.CustomizableEdges = customizableEdges9;
            pnlDaysOff.Location = new Point(630, 20);
            pnlDaysOff.Name = "pnlDaysOff";
            pnlDaysOff.ShadowDecoration.CustomizableEdges = customizableEdges10;
            pnlDaysOff.Size = new Size(290, 110);
            pnlDaysOff.TabIndex = 2;
            //
            // lblDaysOffTitle
            //
            lblDaysOffTitle.AutoSize = true;
            lblDaysOffTitle.Font = new Font("Segoe UI", 9F);
            lblDaysOffTitle.ForeColor = Color.FromArgb(160, 160, 166);
            lblDaysOffTitle.Location = new Point(18, 16);
            lblDaysOffTitle.Name = "lblDaysOffTitle";
            lblDaysOffTitle.Size = new Size(141, 15);
            lblDaysOffTitle.TabIndex = 0;
            lblDaysOffTitle.Text = "Ngày nghỉ trong tháng";
            //
            // lblDaysOffValue
            //
            lblDaysOffValue.AutoSize = true;
            lblDaysOffValue.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblDaysOffValue.ForeColor = Color.FromArgb(56, 139, 204);
            lblDaysOffValue.Location = new Point(18, 40);
            lblDaysOffValue.Name = "lblDaysOffValue";
            lblDaysOffValue.Size = new Size(95, 37);
            lblDaysOffValue.TabIndex = 1;
            lblDaysOffValue.Text = "7 ngày";
            //
            // btnDetailDaysOff
            //
            btnDetailDaysOff.BorderRadius = 8;
            btnDetailDaysOff.Cursor = Cursors.Hand;
            btnDetailDaysOff.CustomizableEdges = customizableEdges11;
            btnDetailDaysOff.FillColor = Color.FromArgb(39, 39, 50);
            btnDetailDaysOff.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            btnDetailDaysOff.ForeColor = Color.FromArgb(56, 139, 204);
            btnDetailDaysOff.HoverState.FillColor = Color.FromArgb(37, 99, 235);
            btnDetailDaysOff.HoverState.ForeColor = Color.White;
            btnDetailDaysOff.Location = new Point(196, 16);
            btnDetailDaysOff.Name = "btnDetailDaysOff";
            btnDetailDaysOff.ShadowDecoration.CustomizableEdges = customizableEdges12;
            btnDetailDaysOff.Size = new Size(76, 28);
            btnDetailDaysOff.TabIndex = 2;
            btnDetailDaysOff.Text = "Cụ thể";
            //
            // pnlNotif
            //
            pnlNotif.BackColor = Color.FromArgb(31, 31, 34);
            pnlNotif.BorderRadius = 14;
            pnlNotif.Controls.Add(lblNotifTitle);
            pnlNotif.Controls.Add(lstNotifications);
            pnlNotif.CustomizableEdges = customizableEdges13;
            pnlNotif.Location = new Point(20, 142);
            pnlNotif.Name = "pnlNotif";
            pnlNotif.ShadowDecoration.CustomizableEdges = customizableEdges14;
            pnlNotif.Size = new Size(920, 490);
            pnlNotif.TabIndex = 3;
            //
            // lblNotifTitle
            //
            lblNotifTitle.AutoSize = true;
            lblNotifTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblNotifTitle.ForeColor = Color.White;
            lblNotifTitle.Location = new Point(18, 16);
            lblNotifTitle.Name = "lblNotifTitle";
            lblNotifTitle.Size = new Size(182, 20);
            lblNotifTitle.TabIndex = 0;
            lblNotifTitle.Text = "🔔  Bảng tin và Thông báo";
            //
            // lstNotifications
            //
            lstNotifications.BackColor = Color.FromArgb(24, 24, 27);
            lstNotifications.BorderStyle = BorderStyle.None;
            lstNotifications.Font = new Font("Segoe UI", 10F);
            lstNotifications.ForeColor = Color.FromArgb(220, 220, 225);
            lstNotifications.FormattingEnabled = true;
            lstNotifications.ItemHeight = 24;
            lstNotifications.Location = new Point(18, 50);
            lstNotifications.Name = "lstNotifications";
            lstNotifications.SelectionMode = SelectionMode.None;
            lstNotifications.Size = new Size(884, 424);
            lstNotifications.TabIndex = 1;
            //
            // ucOverview_Staff
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(39, 39, 42);
            Controls.Add(pnlNotif);
            Controls.Add(pnlDaysOff);
            Controls.Add(pnlWorkingDays);
            Controls.Add(pnlUnreadMsg);
            Name = "ucOverview_Staff";
            Size = new Size(960, 648);
            pnlUnreadMsg.ResumeLayout(false);
            pnlUnreadMsg.PerformLayout();
            pnlWorkingDays.ResumeLayout(false);
            pnlWorkingDays.PerformLayout();
            pnlDaysOff.ResumeLayout(false);
            pnlDaysOff.PerformLayout();
            pnlNotif.ResumeLayout(false);
            pnlNotif.PerformLayout();
            ResumeLayout(false);
        }

        private Guna2Panel  pnlUnreadMsg;
        private Label       lblUnreadMsgTitle;
        private Label       lblUnreadMsgValue;
        private Guna2Button btnDetailMsg;
        private Guna2Panel  pnlWorkingDays;
        private Label       lblWorkingDaysTitle;
        private Label       lblWorkingDaysValue;
        private Guna2Button btnDetailWorkingDays;
        private Guna2Panel  pnlDaysOff;
        private Label       lblDaysOffTitle;
        private Label       lblDaysOffValue;
        private Guna2Button btnDetailDaysOff;
        private Guna2Panel  pnlNotif;
        private Label       lblNotifTitle;
        private ListBox     lstNotifications;
    }
}
