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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges11 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges12 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges13 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges14 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            tblCards = new TableLayoutPanel();
            pnlUnreadMsg = new Guna2Panel();
            lblUnreadMsgTitle = new Label();
            lblUnreadMsgValue = new Label();
            btnDetailMsg = new Guna2Button();
            pnlWorkingDays = new Guna2Panel();
            lblWorkingDaysTitle = new Label();
            lblWorkingDaysValue = new Label();
            btnDetailWorkingDays = new Guna2Button();
            pnlDaysOff = new Guna2Panel();
            lblDaysOffTitle = new Label();
            lblDaysOffValue = new Label();
            btnDetailDaysOff = new Guna2Button();
            pnlNotif = new Guna2Panel();
            lblNotifTitle = new Label();
            lstNotifications = new ListBox();
            btnRefreshFeed = new Guna2Button();
            pnlUnreadMsg.SuspendLayout();
            pnlWorkingDays.SuspendLayout();
            pnlDaysOff.SuspendLayout();
            pnlNotif.SuspendLayout();
            tblCards.SuspendLayout();
            SuspendLayout();
            //
            // tblCards — hàng 3 thẻ giãn đều theo bề ngang
            //
            tblCards.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tblCards.ColumnCount = 3;
            tblCards.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.34F));
            tblCards.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33F));
            tblCards.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33F));
            tblCards.RowCount = 1;
            tblCards.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tblCards.Location = new Point(20, 20);
            tblCards.Size = new Size(960, 110);
            tblCards.Controls.Add(pnlUnreadMsg, 0, 0);
            tblCards.Controls.Add(pnlWorkingDays, 1, 0);
            tblCards.Controls.Add(pnlDaysOff, 2, 0);
            //
            // pnlUnreadMsg
            //
            pnlUnreadMsg.BackColor = Color.FromArgb(31, 31, 34);
            pnlUnreadMsg.BorderRadius = 14;
            pnlUnreadMsg.Controls.Add(lblUnreadMsgTitle);
            pnlUnreadMsg.Controls.Add(lblUnreadMsgValue);
            pnlUnreadMsg.Controls.Add(btnDetailMsg);
            pnlUnreadMsg.CustomizableEdges = customizableEdges3;
            pnlUnreadMsg.Dock = DockStyle.Fill;
            pnlUnreadMsg.Margin = new Padding(0, 0, 14, 0);
            // Giữ Size thiết kế để nút "Chi tiết" neo phải tính đúng khoảng bù
            pnlUnreadMsg.Size = new Size(290, 110);
            pnlUnreadMsg.Name = "pnlUnreadMsg";
            pnlUnreadMsg.ShadowDecoration.CustomizableEdges = customizableEdges4;
            pnlUnreadMsg.TabIndex = 0;
            // 
            // lblUnreadMsgTitle
            // 
            lblUnreadMsgTitle.AutoSize = true;
            lblUnreadMsgTitle.Font = new Font("Segoe UI", 9F);
            lblUnreadMsgTitle.ForeColor = Color.FromArgb(160, 160, 166);
            lblUnreadMsgTitle.Location = new Point(18, 16);
            lblUnreadMsgTitle.Name = "lblUnreadMsgTitle";
            lblUnreadMsgTitle.Size = new Size(78, 15);
            lblUnreadMsgTitle.TabIndex = 0;
            lblUnreadMsgTitle.Text = "Tin chưa xem";
            // 
            // lblUnreadMsgValue
            // 
            lblUnreadMsgValue.AutoSize = true;
            lblUnreadMsgValue.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblUnreadMsgValue.ForeColor = Color.FromArgb(220, 80, 80);
            lblUnreadMsgValue.Location = new Point(18, 40);
            lblUnreadMsgValue.Name = "lblUnreadMsgValue";
            lblUnreadMsgValue.Size = new Size(75, 37);
            lblUnreadMsgValue.TabIndex = 1;
            lblUnreadMsgValue.Text = "0 tin";
            // 
            // btnDetailMsg
            // 
            btnDetailMsg.BorderRadius = 8;
            btnDetailMsg.Cursor = Cursors.Hand;
            btnDetailMsg.CustomizableEdges = customizableEdges1;
            btnDetailMsg.FillColor = Color.FromArgb(45, 45, 50);
            btnDetailMsg.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            btnDetailMsg.ForeColor = Color.FromArgb(31, 138, 154);
            btnDetailMsg.HoverState.FillColor = Color.FromArgb(31, 138, 154);
            btnDetailMsg.HoverState.ForeColor = Color.White;
            btnDetailMsg.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnDetailMsg.Location = new Point(196, 16);
            btnDetailMsg.Name = "btnDetailMsg";
            btnDetailMsg.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnDetailMsg.Size = new Size(76, 28);
            btnDetailMsg.TabIndex = 2;
            btnDetailMsg.Text = "Chi tiết";
            // 
            // pnlWorkingDays
            // 
            pnlWorkingDays.BackColor = Color.FromArgb(31, 31, 34);
            pnlWorkingDays.BorderRadius = 14;
            pnlWorkingDays.Controls.Add(lblWorkingDaysTitle);
            pnlWorkingDays.Controls.Add(lblWorkingDaysValue);
            pnlWorkingDays.Controls.Add(btnDetailWorkingDays);
            pnlWorkingDays.CustomizableEdges = customizableEdges7;
            pnlWorkingDays.Dock = DockStyle.Fill;
            pnlWorkingDays.Margin = new Padding(0, 0, 14, 0);
            pnlWorkingDays.Size = new Size(290, 110);
            pnlWorkingDays.Name = "pnlWorkingDays";
            pnlWorkingDays.ShadowDecoration.CustomizableEdges = customizableEdges8;
            pnlWorkingDays.TabIndex = 1;
            // 
            // lblWorkingDaysTitle
            // 
            lblWorkingDaysTitle.AutoSize = true;
            lblWorkingDaysTitle.Font = new Font("Segoe UI", 9F);
            lblWorkingDaysTitle.ForeColor = Color.FromArgb(160, 160, 166);
            lblWorkingDaysTitle.Location = new Point(18, 16);
            lblWorkingDaysTitle.Name = "lblWorkingDaysTitle";
            lblWorkingDaysTitle.Size = new Size(137, 15);
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
            lblWorkingDaysValue.Size = new Size(119, 37);
            lblWorkingDaysValue.TabIndex = 1;
            lblWorkingDaysValue.Text = "0 ngày";
            // 
            // btnDetailWorkingDays
            // 
            btnDetailWorkingDays.BorderRadius = 8;
            btnDetailWorkingDays.Cursor = Cursors.Hand;
            btnDetailWorkingDays.CustomizableEdges = customizableEdges5;
            btnDetailWorkingDays.FillColor = Color.FromArgb(45, 45, 50);
            btnDetailWorkingDays.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            btnDetailWorkingDays.ForeColor = Color.FromArgb(34, 197, 94);
            btnDetailWorkingDays.HoverState.FillColor = Color.FromArgb(22, 163, 74);
            btnDetailWorkingDays.HoverState.ForeColor = Color.White;
            btnDetailWorkingDays.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnDetailWorkingDays.Location = new Point(196, 16);
            btnDetailWorkingDays.Name = "btnDetailWorkingDays";
            btnDetailWorkingDays.ShadowDecoration.CustomizableEdges = customizableEdges6;
            btnDetailWorkingDays.Size = new Size(76, 28);
            btnDetailWorkingDays.TabIndex = 2;
            btnDetailWorkingDays.Text = "Chi tiết";
            // 
            // pnlDaysOff
            // 
            pnlDaysOff.BackColor = Color.FromArgb(31, 31, 34);
            pnlDaysOff.BorderRadius = 14;
            pnlDaysOff.Controls.Add(lblDaysOffTitle);
            pnlDaysOff.Controls.Add(lblDaysOffValue);
            pnlDaysOff.Controls.Add(btnDetailDaysOff);
            pnlDaysOff.CustomizableEdges = customizableEdges11;
            pnlDaysOff.Dock = DockStyle.Fill;
            pnlDaysOff.Margin = new Padding(0, 0, 0, 0);
            pnlDaysOff.Size = new Size(290, 110);
            pnlDaysOff.Name = "pnlDaysOff";
            pnlDaysOff.ShadowDecoration.CustomizableEdges = customizableEdges12;
            pnlDaysOff.TabIndex = 2;
            // 
            // lblDaysOffTitle
            // 
            lblDaysOffTitle.AutoSize = true;
            lblDaysOffTitle.Font = new Font("Segoe UI", 9F);
            lblDaysOffTitle.ForeColor = Color.FromArgb(160, 160, 166);
            lblDaysOffTitle.Location = new Point(18, 16);
            lblDaysOffTitle.Name = "lblDaysOffTitle";
            lblDaysOffTitle.Size = new Size(128, 15);
            lblDaysOffTitle.TabIndex = 0;
            lblDaysOffTitle.Text = "Ngày nghỉ trong tháng";
            // 
            // lblDaysOffValue
            // 
            lblDaysOffValue.AutoSize = true;
            lblDaysOffValue.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblDaysOffValue.ForeColor = Color.FromArgb(70, 130, 180);
            lblDaysOffValue.Location = new Point(18, 40);
            lblDaysOffValue.Name = "lblDaysOffValue";
            lblDaysOffValue.Size = new Size(103, 37);
            lblDaysOffValue.TabIndex = 1;
            lblDaysOffValue.Text = "0 ngày";
            // 
            // btnDetailDaysOff
            // 
            btnDetailDaysOff.BorderRadius = 8;
            btnDetailDaysOff.Cursor = Cursors.Hand;
            btnDetailDaysOff.CustomizableEdges = customizableEdges9;
            btnDetailDaysOff.FillColor = Color.FromArgb(45, 45, 50);
            btnDetailDaysOff.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            btnDetailDaysOff.ForeColor = Color.FromArgb(70, 130, 180);
            btnDetailDaysOff.HoverState.FillColor = Color.FromArgb(70, 130, 180);
            btnDetailDaysOff.HoverState.ForeColor = Color.White;
            btnDetailDaysOff.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnDetailDaysOff.Location = new Point(196, 16);
            btnDetailDaysOff.Name = "btnDetailDaysOff";
            btnDetailDaysOff.ShadowDecoration.CustomizableEdges = customizableEdges10;
            btnDetailDaysOff.Size = new Size(76, 28);
            btnDetailDaysOff.TabIndex = 2;
            btnDetailDaysOff.Text = "Chi tiết";
            // 
            // pnlNotif
            // 
            pnlNotif.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnlNotif.BackColor = Color.FromArgb(31, 31, 34);
            pnlNotif.BorderRadius = 14;
            pnlNotif.Controls.Add(lblNotifTitle);
            pnlNotif.Controls.Add(btnRefreshFeed);
            pnlNotif.Controls.Add(lstNotifications);
            pnlNotif.CustomizableEdges = customizableEdges13;
            pnlNotif.Location = new Point(20, 142);
            pnlNotif.Name = "pnlNotif";
            pnlNotif.ShadowDecoration.CustomizableEdges = customizableEdges14;
            pnlNotif.Size = new Size(960, 503);
            pnlNotif.TabIndex = 3;
            // 
            // lblNotifTitle
            // 
            lblNotifTitle.AutoSize = true;
            lblNotifTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblNotifTitle.ForeColor = Color.White;
            lblNotifTitle.Location = new Point(18, 16);
            lblNotifTitle.Name = "lblNotifTitle";
            lblNotifTitle.Size = new Size(197, 20);
            lblNotifTitle.TabIndex = 0;
            lblNotifTitle.Text = "Bảng tin và Thông báo";
            // 
            // lstNotifications
            // 
            lstNotifications.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lstNotifications.BackColor = Color.FromArgb(24, 24, 27);
            lstNotifications.BorderStyle = BorderStyle.None;
            lstNotifications.Font = new Font("Segoe UI", 10F);
            lstNotifications.ForeColor = Color.FromArgb(220, 220, 225);
            lstNotifications.FormattingEnabled = true;
            lstNotifications.ItemHeight = 17;
            lstNotifications.Location = new Point(18, 50);
            lstNotifications.Name = "lstNotifications";
            lstNotifications.SelectionMode = SelectionMode.None;
            lstNotifications.Size = new Size(924, 425);
            lstNotifications.TabIndex = 1;
            //
            // btnRefreshFeed
            //
            btnRefreshFeed.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnRefreshFeed.BorderRadius = 8;
            btnRefreshFeed.Cursor = Cursors.Hand;
            btnRefreshFeed.FillColor = Color.FromArgb(45, 45, 50);
            btnRefreshFeed.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            btnRefreshFeed.ForeColor = Color.FromArgb(31, 138, 154);
            btnRefreshFeed.HoverState.FillColor = Color.FromArgb(31, 138, 154);
            btnRefreshFeed.HoverState.ForeColor = Color.White;
            btnRefreshFeed.Location = new Point(842, 12);
            btnRefreshFeed.Name = "btnRefreshFeed";
            btnRefreshFeed.Size = new Size(100, 30);
            btnRefreshFeed.TabIndex = 2;
            btnRefreshFeed.Text = "🔄  Làm mới";
            //
            // ucOverview_Staff
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(39, 39, 42);
            Controls.Add(pnlNotif);
            Controls.Add(tblCards);
            Name = "ucOverview_Staff";
            Size = new Size(1000, 665);
            pnlUnreadMsg.ResumeLayout(false);
            pnlUnreadMsg.PerformLayout();
            pnlWorkingDays.ResumeLayout(false);
            pnlWorkingDays.PerformLayout();
            pnlDaysOff.ResumeLayout(false);
            pnlDaysOff.PerformLayout();
            pnlNotif.ResumeLayout(false);
            pnlNotif.PerformLayout();
            tblCards.ResumeLayout(false);
            ResumeLayout(false);
        }

        private TableLayoutPanel tblCards;
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
        private Guna2Button btnRefreshFeed;
    }
}
