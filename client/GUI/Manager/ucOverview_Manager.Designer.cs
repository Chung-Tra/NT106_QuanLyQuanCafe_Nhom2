using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace GUI
{
    partial class ucOverview_Manager
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        private void InitializeComponent()
        {
            tblCards = new TableLayoutPanel();
            pnlDailyRev = new Guna2Panel();
            lblDailyRevTitle = new Label();
            lblDailyRevValue = new Label();
            pnlMonthlyRev = new Guna2Panel();
            lblMonthlyRevTitle = new Label();
            lblMonthlyRevValue = new Label();
            pnlDailyFeed = new Guna2Panel();
            lblDailyFeedTitle = new Label();
            lblDailyFeedValue = new Label();
            pnlMonthlyFeed = new Guna2Panel();
            lblMonthlyFeedTitle = new Label();
            lblMonthlyFeedValue = new Label();
            pnlNotif = new Guna2Panel();
            lblNotifTitle = new Label();
            lstNotifications = new ListBox();
            btnRefreshFeed = new Guna2Button();
            pnlDailyRev.SuspendLayout();
            pnlMonthlyRev.SuspendLayout();
            pnlDailyFeed.SuspendLayout();
            pnlMonthlyFeed.SuspendLayout();
            pnlNotif.SuspendLayout();
            tblCards.SuspendLayout();
            SuspendLayout();

            // ====== tblCards — hàng 4 thẻ giãn đều theo bề ngang ======
            tblCards.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tblCards.ColumnCount = 4;
            tblCards.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tblCards.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tblCards.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tblCards.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tblCards.RowCount = 1;
            tblCards.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tblCards.Location = new Point(20, 20);
            tblCards.Size = new Size(960, 110);
            tblCards.Controls.Add(pnlDailyRev, 0, 0);
            tblCards.Controls.Add(pnlMonthlyRev, 1, 0);
            tblCards.Controls.Add(pnlDailyFeed, 2, 0);
            tblCards.Controls.Add(pnlMonthlyFeed, 3, 0);

            // ====== pnlDailyRev ======
            pnlDailyRev.BackColor = Color.FromArgb(31, 31, 34);
            pnlDailyRev.BorderRadius = 14;
            pnlDailyRev.Controls.Add(lblDailyRevTitle);
            pnlDailyRev.Controls.Add(lblDailyRevValue);
            pnlDailyRev.Dock = DockStyle.Fill;
            pnlDailyRev.Margin = new Padding(0, 0, 10, 0);
            lblDailyRevTitle.AutoSize = true;
            lblDailyRevTitle.Font = new Font("Segoe UI", 9F);
            lblDailyRevTitle.ForeColor = Color.FromArgb(160, 160, 166);
            lblDailyRevTitle.Location = new Point(18, 18);
            lblDailyRevTitle.Text = "Doanh thu hôm nay";
            lblDailyRevValue.AutoSize = true;
            lblDailyRevValue.Font = new Font("Segoe UI", 17F, FontStyle.Bold);
            lblDailyRevValue.ForeColor = Color.White;
            lblDailyRevValue.Location = new Point(18, 50);
            lblDailyRevValue.Text = "0 đ";
            lblDailyRevValue.Click += lblDailyRevValue_Click;

            // ====== pnlMonthlyRev ======
            pnlMonthlyRev.BackColor = Color.FromArgb(31, 31, 34);
            pnlMonthlyRev.BorderRadius = 14;
            pnlMonthlyRev.Controls.Add(lblMonthlyRevTitle);
            pnlMonthlyRev.Controls.Add(lblMonthlyRevValue);
            pnlMonthlyRev.Dock = DockStyle.Fill;
            pnlMonthlyRev.Margin = new Padding(0, 0, 10, 0);
            lblMonthlyRevTitle.AutoSize = true;
            lblMonthlyRevTitle.Font = new Font("Segoe UI", 9F);
            lblMonthlyRevTitle.ForeColor = Color.FromArgb(160, 160, 166);
            lblMonthlyRevTitle.Location = new Point(18, 18);
            lblMonthlyRevTitle.Text = "Doanh thu tháng này";
            lblMonthlyRevValue.AutoSize = true;
            lblMonthlyRevValue.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblMonthlyRevValue.ForeColor = Color.FromArgb(31, 138, 154);
            lblMonthlyRevValue.Location = new Point(18, 50);
            lblMonthlyRevValue.Text = "0 đ";

            // ====== pnlDailyFeed ======
            pnlDailyFeed.BackColor = Color.FromArgb(31, 31, 34);
            pnlDailyFeed.BorderRadius = 14;
            pnlDailyFeed.Controls.Add(lblDailyFeedTitle);
            pnlDailyFeed.Controls.Add(lblDailyFeedValue);
            pnlDailyFeed.Dock = DockStyle.Fill;
            pnlDailyFeed.Margin = new Padding(0, 0, 10, 0);
            lblDailyFeedTitle.AutoSize = true;
            lblDailyFeedTitle.Font = new Font("Segoe UI", 9F);
            lblDailyFeedTitle.ForeColor = Color.FromArgb(160, 160, 166);
            lblDailyFeedTitle.Location = new Point(18, 18);
            lblDailyFeedTitle.Text = "Khen ngợi hôm nay";
            lblDailyFeedValue.AutoSize = true;
            lblDailyFeedValue.Font = new Font("Segoe UI", 17F, FontStyle.Bold);
            lblDailyFeedValue.ForeColor = Color.FromArgb(34, 197, 94);
            lblDailyFeedValue.Location = new Point(18, 50);
            lblDailyFeedValue.Text = "0";

            // ====== pnlMonthlyFeed ======
            pnlMonthlyFeed.BackColor = Color.FromArgb(31, 31, 34);
            pnlMonthlyFeed.BorderRadius = 14;
            pnlMonthlyFeed.Controls.Add(lblMonthlyFeedTitle);
            pnlMonthlyFeed.Controls.Add(lblMonthlyFeedValue);
            pnlMonthlyFeed.Dock = DockStyle.Fill;
            pnlMonthlyFeed.Margin = new Padding(0, 0, 0, 0);
            lblMonthlyFeedTitle.AutoSize = true;
            lblMonthlyFeedTitle.Font = new Font("Segoe UI", 9F);
            lblMonthlyFeedTitle.ForeColor = Color.FromArgb(160, 160, 166);
            lblMonthlyFeedTitle.Location = new Point(18, 18);
            lblMonthlyFeedTitle.Text = "Khen ngợi tháng này";
            lblMonthlyFeedValue.AutoSize = true;
            lblMonthlyFeedValue.Font = new Font("Segoe UI", 17F, FontStyle.Bold);
            lblMonthlyFeedValue.ForeColor = Color.FromArgb(34, 197, 94);
            lblMonthlyFeedValue.Location = new Point(18, 50);
            lblMonthlyFeedValue.Text = "0";

            // ====== pnlNotif ======
            pnlNotif.BackColor = Color.FromArgb(31, 31, 34);
            pnlNotif.BorderRadius = 14;
            pnlNotif.Controls.Add(lblNotifTitle);
            pnlNotif.Controls.Add(btnRefreshFeed);
            pnlNotif.Controls.Add(lstNotifications);
            pnlNotif.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnlNotif.Location = new Point(20, 145);
            pnlNotif.Size = new Size(960, 505);

            // lblNotifTitle
            lblNotifTitle.AutoSize = true;
            lblNotifTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblNotifTitle.ForeColor = Color.White;
            lblNotifTitle.Location = new Point(18, 16);
            lblNotifTitle.Text = "Bảng tin và Thông báo";
            lblNotifTitle.Click += lblNotifTitle_Click;

            // lstNotifications
            lstNotifications.BackColor = Color.FromArgb(24, 24, 27);
            lstNotifications.BorderStyle = BorderStyle.None;
            lstNotifications.Font = new Font("Segoe UI", 11F);
            lstNotifications.ForeColor = Color.FromArgb(220, 220, 225);
            lstNotifications.FormattingEnabled = true;
            lstNotifications.ItemHeight = 22;
            // Items nạp ở code-behind qua NotificationFeed (đã đọc/chưa đọc + click đánh dấu)
            lstNotifications.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lstNotifications.Location = new Point(18, 54);
            lstNotifications.Size = new Size(924, 432);

            // btnRefreshFeed
            btnRefreshFeed.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnRefreshFeed.BorderRadius = 8;
            btnRefreshFeed.Cursor = Cursors.Hand;
            btnRefreshFeed.FillColor = Color.FromArgb(45, 45, 50);
            btnRefreshFeed.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            btnRefreshFeed.ForeColor = Color.FromArgb(31, 138, 154);
            btnRefreshFeed.HoverState.FillColor = Color.FromArgb(31, 138, 154);
            btnRefreshFeed.HoverState.ForeColor = Color.White;
            btnRefreshFeed.Location = new Point(842, 14);
            btnRefreshFeed.Name = "btnRefreshFeed";
            btnRefreshFeed.Size = new Size(100, 30);
            btnRefreshFeed.Text = "🔄  Làm mới";

            // ====== ucOverview_Manager ======
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(39, 39, 42);
            Controls.Add(tblCards);
            Controls.Add(pnlNotif);
            Name = "ucOverview_Manager";
            Size = new Size(1000, 665);
            pnlDailyRev.ResumeLayout(false);
            pnlDailyRev.PerformLayout();
            pnlMonthlyRev.ResumeLayout(false);
            pnlMonthlyRev.PerformLayout();
            pnlDailyFeed.ResumeLayout(false);
            pnlDailyFeed.PerformLayout();
            pnlMonthlyFeed.ResumeLayout(false);
            pnlMonthlyFeed.PerformLayout();
            pnlNotif.ResumeLayout(false);
            pnlNotif.PerformLayout();
            tblCards.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tblCards;
        private Guna2Panel pnlDailyRev;
        private Label lblDailyRevTitle;
        private Label lblDailyRevValue;

        private Guna2Panel pnlMonthlyRev;
        private Label lblMonthlyRevTitle;
        private Label lblMonthlyRevValue;

        private Guna2Panel pnlDailyFeed;
        private Label lblDailyFeedTitle;
        private Label lblDailyFeedValue;

        private Guna2Panel pnlMonthlyFeed;
        private Label lblMonthlyFeedTitle;
        private Label lblMonthlyFeedValue;

        private Guna2Panel pnlNotif;
        private Label lblNotifTitle;
        private ListBox lstNotifications;
        private Guna2Button btnRefreshFeed;
    }
}
