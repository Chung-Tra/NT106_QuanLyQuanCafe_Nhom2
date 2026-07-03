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
            pnlDailyRev.SuspendLayout();
            pnlMonthlyRev.SuspendLayout();
            pnlDailyFeed.SuspendLayout();
            pnlMonthlyFeed.SuspendLayout();
            pnlNotif.SuspendLayout();
            SuspendLayout();

            // ====== pnlDailyRev ======
            pnlDailyRev.BackColor = Color.FromArgb(31, 31, 34);
            pnlDailyRev.BorderRadius = 14;
            pnlDailyRev.Controls.Add(lblDailyRevTitle);
            pnlDailyRev.Controls.Add(lblDailyRevValue);
            pnlDailyRev.Location = new Point(20, 20);
            pnlDailyRev.Size = new Size(235, 110);
            lblDailyRevTitle.AutoSize = true;
            lblDailyRevTitle.Font = new Font("Segoe UI", 9F);
            lblDailyRevTitle.ForeColor = Color.FromArgb(160, 160, 166);
            lblDailyRevTitle.Location = new Point(18, 18);
            lblDailyRevTitle.Text = "Doanh thu hôm nay";
            lblDailyRevValue.AutoSize = true;
            lblDailyRevValue.Font = new Font("Segoe UI", 17F, FontStyle.Bold);
            lblDailyRevValue.ForeColor = Color.White;
            lblDailyRevValue.Location = new Point(18, 50);
            lblDailyRevValue.Text = "5,200,000 đ";
            lblDailyRevValue.Click += lblDailyRevValue_Click;

            // ====== pnlMonthlyRev ======
            pnlMonthlyRev.BackColor = Color.FromArgb(31, 31, 34);
            pnlMonthlyRev.BorderRadius = 14;
            pnlMonthlyRev.Controls.Add(lblMonthlyRevTitle);
            pnlMonthlyRev.Controls.Add(lblMonthlyRevValue);
            pnlMonthlyRev.Location = new Point(265, 20);
            pnlMonthlyRev.Size = new Size(235, 110);
            lblMonthlyRevTitle.AutoSize = true;
            lblMonthlyRevTitle.Font = new Font("Segoe UI", 9F);
            lblMonthlyRevTitle.ForeColor = Color.FromArgb(160, 160, 166);
            lblMonthlyRevTitle.Location = new Point(18, 18);
            lblMonthlyRevTitle.Text = "Doanh thu tháng này";
            lblMonthlyRevValue.AutoSize = true;
            lblMonthlyRevValue.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblMonthlyRevValue.ForeColor = Color.FromArgb(31, 138, 154);
            lblMonthlyRevValue.Location = new Point(18, 50);
            lblMonthlyRevValue.Text = "142,500,000 đ";

            // ====== pnlDailyFeed ======
            pnlDailyFeed.BackColor = Color.FromArgb(31, 31, 34);
            pnlDailyFeed.BorderRadius = 14;
            pnlDailyFeed.Controls.Add(lblDailyFeedTitle);
            pnlDailyFeed.Controls.Add(lblDailyFeedValue);
            pnlDailyFeed.Location = new Point(510, 20);
            pnlDailyFeed.Size = new Size(235, 110);
            lblDailyFeedTitle.AutoSize = true;
            lblDailyFeedTitle.Font = new Font("Segoe UI", 9F);
            lblDailyFeedTitle.ForeColor = Color.FromArgb(160, 160, 166);
            lblDailyFeedTitle.Location = new Point(18, 18);
            lblDailyFeedTitle.Text = "Khen ngợi hôm nay";
            lblDailyFeedValue.AutoSize = true;
            lblDailyFeedValue.Font = new Font("Segoe UI", 17F, FontStyle.Bold);
            lblDailyFeedValue.ForeColor = Color.FromArgb(34, 197, 94);
            lblDailyFeedValue.Location = new Point(18, 50);
            lblDailyFeedValue.Text = "15";

            // ====== pnlMonthlyFeed ======
            pnlMonthlyFeed.BackColor = Color.FromArgb(31, 31, 34);
            pnlMonthlyFeed.BorderRadius = 14;
            pnlMonthlyFeed.Controls.Add(lblMonthlyFeedTitle);
            pnlMonthlyFeed.Controls.Add(lblMonthlyFeedValue);
            pnlMonthlyFeed.Location = new Point(755, 20);
            pnlMonthlyFeed.Size = new Size(225, 110);
            lblMonthlyFeedTitle.AutoSize = true;
            lblMonthlyFeedTitle.Font = new Font("Segoe UI", 9F);
            lblMonthlyFeedTitle.ForeColor = Color.FromArgb(160, 160, 166);
            lblMonthlyFeedTitle.Location = new Point(18, 18);
            lblMonthlyFeedTitle.Text = "Khen ngợi tháng này";
            lblMonthlyFeedValue.AutoSize = true;
            lblMonthlyFeedValue.Font = new Font("Segoe UI", 17F, FontStyle.Bold);
            lblMonthlyFeedValue.ForeColor = Color.FromArgb(34, 197, 94);
            lblMonthlyFeedValue.Location = new Point(18, 50);
            lblMonthlyFeedValue.Text = "342";

            // ====== pnlNotif ======
            pnlNotif.BackColor = Color.FromArgb(31, 31, 34);
            pnlNotif.BorderRadius = 14;
            pnlNotif.Controls.Add(lblNotifTitle);
            pnlNotif.Controls.Add(lstNotifications);
            pnlNotif.Location = new Point(20, 145);
            pnlNotif.Size = new Size(960, 505);

            // lblNotifTitle
            lblNotifTitle.AutoSize = true;
            lblNotifTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblNotifTitle.ForeColor = Color.White;
            lblNotifTitle.Location = new Point(18, 16);
            lblNotifTitle.Text = "🔔  Bảng tin và Thông báo";
            lblNotifTitle.Click += lblNotifTitle_Click;

            // lstNotifications
            lstNotifications.BackColor = Color.FromArgb(24, 24, 27);
            lstNotifications.BorderStyle = BorderStyle.None;
            lstNotifications.Font = new Font("Segoe UI", 11F);
            lstNotifications.ForeColor = Color.FromArgb(220, 220, 225);
            lstNotifications.FormattingEnabled = true;
            lstNotifications.ItemHeight = 22;
            lstNotifications.Items.AddRange(new object[] {
                "🔴 [08:30] Nhân viên phục vụ Nguyễn Văn A xin phép nghỉ ốm ngày hôm nay.",
                "⭐ [09:15] Feedback Bàn số 5: \"Cà phê muối rất ngon, nhân viên nhiệt tình, 5 sao!\"",
                "⚠️ [10:00] Kho hàng cảnh báo: Hết nguyên liệu Sữa tươi, cần nhập gấp.",
                "⭐ [11:20] Feedback Bàn số 12: \"Quán decor đẹp, đồ uống lên nhanh.\"",
                "\U0001f7e2 [12:00] Quản lý đã duyệt đơn xin nghỉ của Nguyễn Văn A." });
            lstNotifications.Location = new Point(18, 54);
            lstNotifications.Size = new Size(924, 432);

            // ====== ucOverview_Manager ======
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(39, 39, 42);
            Controls.Add(pnlDailyRev);
            Controls.Add(pnlMonthlyRev);
            Controls.Add(pnlDailyFeed);
            Controls.Add(pnlMonthlyFeed);
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
            ResumeLayout(false);
        }

        #endregion

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
    }
}
