namespace GUI
{
    partial class ucOverview_Manager
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pnlDailyRev = new Panel();
            lblDailyRevValue = new Label();
            lblDailyRevTitle = new Label();
            pnlMonthlyRev = new Panel();
            lblMonthlyRevValue = new Label();
            lblMonthlyRevTitle = new Label();
            pnlDailyFeed = new Panel();
            lblDailyFeedValue = new Label();
            lblDailyFeedTitle = new Label();
            pnlMonthlyFeed = new Panel();
            lblMonthlyFeedValue = new Label();
            lblMonthlyFeedTitle = new Label();
            pnlNotif = new Panel();
            lstNotifications = new ListBox();
            lblNotifTitle = new Label();
            pnlDailyRev.SuspendLayout();
            pnlMonthlyRev.SuspendLayout();
            pnlDailyFeed.SuspendLayout();
            pnlMonthlyFeed.SuspendLayout();
            pnlNotif.SuspendLayout();
            SuspendLayout();
            // 
            // pnlDailyRev
            // 
            pnlDailyRev.BackColor = Color.FromArgb(30, 30, 30);
            pnlDailyRev.Controls.Add(lblDailyRevValue);
            pnlDailyRev.Controls.Add(lblDailyRevTitle);
            pnlDailyRev.Location = new Point(20, 20);
            pnlDailyRev.Name = "pnlDailyRev";
            pnlDailyRev.Size = new Size(180, 100);
            pnlDailyRev.TabIndex = 0;
            // 
            // lblDailyRevValue
            // 
            lblDailyRevValue.AutoSize = true;
            lblDailyRevValue.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold);
            lblDailyRevValue.ForeColor = Color.White;
            lblDailyRevValue.Location = new Point(15, 45);
            lblDailyRevValue.Name = "lblDailyRevValue";
            lblDailyRevValue.Size = new Size(128, 30);
            lblDailyRevValue.TabIndex = 1;
            lblDailyRevValue.Text = "5,200,000 đ";
            lblDailyRevValue.Click += lblDailyRevValue_Click;
            // 
            // lblDailyRevTitle
            // 
            lblDailyRevTitle.AutoSize = true;
            lblDailyRevTitle.Font = new Font("Segoe UI", 9.75F);
            lblDailyRevTitle.ForeColor = Color.Gray;
            lblDailyRevTitle.Location = new Point(15, 15);
            lblDailyRevTitle.Name = "lblDailyRevTitle";
            lblDailyRevTitle.Size = new Size(122, 17);
            lblDailyRevTitle.TabIndex = 0;
            lblDailyRevTitle.Text = "Doanh thu hôm nay";
            // 
            // pnlMonthlyRev
            // 
            pnlMonthlyRev.BackColor = Color.FromArgb(30, 30, 30);
            pnlMonthlyRev.Controls.Add(lblMonthlyRevValue);
            pnlMonthlyRev.Controls.Add(lblMonthlyRevTitle);
            pnlMonthlyRev.Location = new Point(215, 20);
            pnlMonthlyRev.Name = "pnlMonthlyRev";
            pnlMonthlyRev.Size = new Size(180, 100);
            pnlMonthlyRev.TabIndex = 1;
            // 
            // lblMonthlyRevValue
            // 
            lblMonthlyRevValue.AutoSize = true;
            lblMonthlyRevValue.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold);
            lblMonthlyRevValue.ForeColor = Color.White;
            lblMonthlyRevValue.Location = new Point(15, 45);
            lblMonthlyRevValue.Name = "lblMonthlyRevValue";
            lblMonthlyRevValue.Size = new Size(152, 30);
            lblMonthlyRevValue.TabIndex = 1;
            lblMonthlyRevValue.Text = "142,500,000 đ";
            // 
            // lblMonthlyRevTitle
            // 
            lblMonthlyRevTitle.AutoSize = true;
            lblMonthlyRevTitle.Font = new Font("Segoe UI", 9.75F);
            lblMonthlyRevTitle.ForeColor = Color.Gray;
            lblMonthlyRevTitle.Location = new Point(15, 15);
            lblMonthlyRevTitle.Name = "lblMonthlyRevTitle";
            lblMonthlyRevTitle.Size = new Size(129, 17);
            lblMonthlyRevTitle.TabIndex = 0;
            lblMonthlyRevTitle.Text = "Doanh thu tháng này";
            // 
            // pnlDailyFeed
            // 
            pnlDailyFeed.BackColor = Color.FromArgb(30, 30, 30);
            pnlDailyFeed.Controls.Add(lblDailyFeedValue);
            pnlDailyFeed.Controls.Add(lblDailyFeedTitle);
            pnlDailyFeed.Location = new Point(410, 20);
            pnlDailyFeed.Name = "pnlDailyFeed";
            pnlDailyFeed.Size = new Size(180, 100);
            pnlDailyFeed.TabIndex = 2;
            // 
            // lblDailyFeedValue
            // 
            lblDailyFeedValue.AutoSize = true;
            lblDailyFeedValue.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold);
            lblDailyFeedValue.ForeColor = Color.MediumSeaGreen;
            lblDailyFeedValue.Location = new Point(15, 45);
            lblDailyFeedValue.Name = "lblDailyFeedValue";
            lblDailyFeedValue.Size = new Size(37, 30);
            lblDailyFeedValue.TabIndex = 1;
            lblDailyFeedValue.Text = "15";
            // 
            // lblDailyFeedTitle
            // 
            lblDailyFeedTitle.AutoSize = true;
            lblDailyFeedTitle.Font = new Font("Segoe UI", 9.75F);
            lblDailyFeedTitle.ForeColor = Color.Gray;
            lblDailyFeedTitle.Location = new Point(15, 15);
            lblDailyFeedTitle.Name = "lblDailyFeedTitle";
            lblDailyFeedTitle.Size = new Size(121, 17);
            lblDailyFeedTitle.TabIndex = 0;
            lblDailyFeedTitle.Text = "Khen ngợi hôm nay";
            // 
            // pnlMonthlyFeed
            // 
            pnlMonthlyFeed.BackColor = Color.FromArgb(30, 30, 30);
            pnlMonthlyFeed.Controls.Add(lblMonthlyFeedValue);
            pnlMonthlyFeed.Controls.Add(lblMonthlyFeedTitle);
            pnlMonthlyFeed.Location = new Point(605, 20);
            pnlMonthlyFeed.Name = "pnlMonthlyFeed";
            pnlMonthlyFeed.Size = new Size(180, 100);
            pnlMonthlyFeed.TabIndex = 3;
            // 
            // lblMonthlyFeedValue
            // 
            lblMonthlyFeedValue.AutoSize = true;
            lblMonthlyFeedValue.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold);
            lblMonthlyFeedValue.ForeColor = Color.MediumSeaGreen;
            lblMonthlyFeedValue.Location = new Point(15, 45);
            lblMonthlyFeedValue.Name = "lblMonthlyFeedValue";
            lblMonthlyFeedValue.Size = new Size(49, 30);
            lblMonthlyFeedValue.TabIndex = 1;
            lblMonthlyFeedValue.Text = "342";
            // 
            // lblMonthlyFeedTitle
            // 
            lblMonthlyFeedTitle.AutoSize = true;
            lblMonthlyFeedTitle.Font = new Font("Segoe UI", 9.75F);
            lblMonthlyFeedTitle.ForeColor = Color.Gray;
            lblMonthlyFeedTitle.Location = new Point(15, 15);
            lblMonthlyFeedTitle.Name = "lblMonthlyFeedTitle";
            lblMonthlyFeedTitle.Size = new Size(128, 17);
            lblMonthlyFeedTitle.TabIndex = 0;
            lblMonthlyFeedTitle.Text = "Khen ngợi tháng này";
            // 
            // pnlNotif
            // 
            pnlNotif.BackColor = Color.FromArgb(30, 30, 30);
            pnlNotif.Controls.Add(lstNotifications);
            pnlNotif.Controls.Add(lblNotifTitle);
            pnlNotif.Location = new Point(20, 140);
            pnlNotif.Name = "pnlNotif";
            pnlNotif.Size = new Size(765, 370);
            pnlNotif.TabIndex = 4;
            // 
            // lstNotifications
            // 
            lstNotifications.BackColor = Color.FromArgb(45, 45, 48);
            lstNotifications.BorderStyle = BorderStyle.None;
            lstNotifications.Font = new Font("Segoe UI", 11F);
            lstNotifications.ForeColor = Color.White;
            lstNotifications.FormattingEnabled = true;
            lstNotifications.ItemHeight = 20;
            lstNotifications.Items.AddRange(new object[] { "🔴 [08:30] Nhân viên phục vụ Nguyễn Văn A xin phép nghỉ ốm ngày hôm nay.", "⭐ [09:15] Feedback Bàn số 5: \"Cà phê muối rất ngon, nhân viên nhiệt tình, 5 sao!\"", "⚠️ [10:00] Kho hàng cảnh báo: Hết nguyên liệu Sữa tươi, cần nhập gấp.", "⭐ [11:20] Feedback Bàn số 12: \"Quán decor đẹp, đồ uống lên nhanh.\"", "\U0001f7e2 [12:00] Quản lý đã duyệt đơn xin nghỉ của Nguyễn Văn A." });
            lstNotifications.Location = new Point(20, 50);
            lstNotifications.Name = "lstNotifications";
            lstNotifications.Size = new Size(725, 300);
            lstNotifications.TabIndex = 1;
            // 
            // lblNotifTitle
            // 
            lblNotifTitle.AutoSize = true;
            lblNotifTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblNotifTitle.ForeColor = Color.White;
            lblNotifTitle.Location = new Point(15, 15);
            lblNotifTitle.Name = "lblNotifTitle";
            lblNotifTitle.Size = new Size(182, 21);
            lblNotifTitle.TabIndex = 0;
            lblNotifTitle.Text = "Bảng tin và Thông báo";
            lblNotifTitle.Click += lblNotifTitle_Click;
            // 
            // ucOverview_Manager
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(45, 45, 48);
            Controls.Add(pnlNotif);
            Controls.Add(pnlMonthlyFeed);
            Controls.Add(pnlDailyFeed);
            Controls.Add(pnlMonthlyRev);
            Controls.Add(pnlDailyRev);
            Name = "ucOverview_Manager";
            Size = new Size(804, 530);
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
            // --- KẾT THÚC ĐOẠN CODE VIẾT THÊM TRONG HÀM ---
        }

        #endregion

        // --- KHAI BÁO CÁC BIẾN CONTROL GIAO DIỆN ---
        private System.Windows.Forms.Panel pnlDailyRev;
        private System.Windows.Forms.Label lblDailyRevTitle;
        private System.Windows.Forms.Label lblDailyRevValue;

        private System.Windows.Forms.Panel pnlMonthlyRev;
        private System.Windows.Forms.Label lblMonthlyRevTitle;
        private System.Windows.Forms.Label lblMonthlyRevValue;

        private System.Windows.Forms.Panel pnlDailyFeed;
        private System.Windows.Forms.Label lblDailyFeedTitle;
        private System.Windows.Forms.Label lblDailyFeedValue;

        private System.Windows.Forms.Panel pnlMonthlyFeed;
        private System.Windows.Forms.Label lblMonthlyFeedTitle;
        private System.Windows.Forms.Label lblMonthlyFeedValue;

        private System.Windows.Forms.Panel pnlNotif;
        private System.Windows.Forms.Label lblNotifTitle;
        private System.Windows.Forms.ListBox lstNotifications;
    }
}