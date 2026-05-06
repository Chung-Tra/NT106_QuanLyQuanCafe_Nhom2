namespace GUI
{
    partial class ucOverview_Staff
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
            pnlUnreadMsg = new Panel();
            btnDetailMsg = new Button();
            lblUnreadMsgValue = new Label();
            lblUnreadMsgTitle = new Label();
            pnlWorkingDays = new Panel();
            btnDetailWorkingDays = new Button();
            lblWorkingDaysValue = new Label();
            lblWorkingDaysTitle = new Label();
            pnlDaysOff = new Panel();
            btnDetailDaysOff = new Button();
            lblDaysOffValue = new Label();
            lblDaysOffTitle = new Label();
            pnlNotif = new Panel();
            lstNotifications = new ListBox();
            lblNotifTitle = new Label();
            pnlUnreadMsg.SuspendLayout();
            pnlWorkingDays.SuspendLayout();
            pnlDaysOff.SuspendLayout();
            pnlNotif.SuspendLayout();
            SuspendLayout();
            // 
            // pnlUnreadMsg
            // 
            pnlUnreadMsg.BackColor = Color.FromArgb(30, 30, 30);
            pnlUnreadMsg.Controls.Add(btnDetailMsg);
            pnlUnreadMsg.Controls.Add(lblUnreadMsgValue);
            pnlUnreadMsg.Controls.Add(lblUnreadMsgTitle);
            pnlUnreadMsg.Location = new Point(35, 20);
            pnlUnreadMsg.Name = "pnlUnreadMsg";
            pnlUnreadMsg.Size = new Size(180, 100);
            pnlUnreadMsg.TabIndex = 0;
            // 
            // btnDetailMsg
            // 
            btnDetailMsg.BackColor = Color.MediumSeaGreen;
            btnDetailMsg.FlatAppearance.BorderSize = 0;
            btnDetailMsg.FlatStyle = FlatStyle.Flat;
            btnDetailMsg.ForeColor = Color.White;
            btnDetailMsg.Location = new Point(106, 12);
            btnDetailMsg.Name = "btnDetailMsg";
            btnDetailMsg.Size = new Size(57, 25);
            btnDetailMsg.TabIndex = 2;
            btnDetailMsg.Text = "Cụ thể";
            btnDetailMsg.UseVisualStyleBackColor = false;
            // 
            // lblUnreadMsgValue
            // 
            lblUnreadMsgValue.AutoSize = true;
            lblUnreadMsgValue.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold);
            lblUnreadMsgValue.ForeColor = Color.IndianRed;
            lblUnreadMsgValue.Location = new Point(15, 45);
            lblUnreadMsgValue.Name = "lblUnreadMsgValue";
            lblUnreadMsgValue.Size = new Size(58, 30);
            lblUnreadMsgValue.TabIndex = 1;
            lblUnreadMsgValue.Text = "5 tin";
            // 
            // lblUnreadMsgTitle
            // 
            lblUnreadMsgTitle.AutoSize = true;
            lblUnreadMsgTitle.Font = new Font("Segoe UI", 9.75F);
            lblUnreadMsgTitle.ForeColor = Color.Gray;
            lblUnreadMsgTitle.Location = new Point(15, 15);
            lblUnreadMsgTitle.Name = "lblUnreadMsgTitle";
            lblUnreadMsgTitle.Size = new Size(85, 17);
            lblUnreadMsgTitle.TabIndex = 0;
            lblUnreadMsgTitle.Text = "Tin chưa xem";
            // 
            // pnlWorkingDays
            // 
            pnlWorkingDays.BackColor = Color.FromArgb(30, 30, 30);
            pnlWorkingDays.Controls.Add(btnDetailWorkingDays);
            pnlWorkingDays.Controls.Add(lblWorkingDaysValue);
            pnlWorkingDays.Controls.Add(lblWorkingDaysTitle);
            pnlWorkingDays.Location = new Point(249, 20);
            pnlWorkingDays.Name = "pnlWorkingDays";
            pnlWorkingDays.Size = new Size(247, 100);
            pnlWorkingDays.TabIndex = 2;
            // 
            // btnDetailWorkingDays
            // 
            btnDetailWorkingDays.BackColor = Color.MediumSeaGreen;
            btnDetailWorkingDays.FlatAppearance.BorderSize = 0;
            btnDetailWorkingDays.FlatStyle = FlatStyle.Flat;
            btnDetailWorkingDays.ForeColor = Color.White;
            btnDetailWorkingDays.Location = new Point(173, 12);
            btnDetailWorkingDays.Name = "btnDetailWorkingDays";
            btnDetailWorkingDays.Size = new Size(57, 25);
            btnDetailWorkingDays.TabIndex = 3;
            btnDetailWorkingDays.Text = "Cụ thể";
            btnDetailWorkingDays.UseVisualStyleBackColor = false;
            // 
            // lblWorkingDaysValue
            // 
            lblWorkingDaysValue.AutoSize = true;
            lblWorkingDaysValue.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold);
            lblWorkingDaysValue.ForeColor = Color.MediumSeaGreen;
            lblWorkingDaysValue.Location = new Point(15, 45);
            lblWorkingDaysValue.Name = "lblWorkingDaysValue";
            lblWorkingDaysValue.Size = new Size(91, 30);
            lblWorkingDaysValue.TabIndex = 1;
            lblWorkingDaysValue.Text = "23 ngày";
            // 
            // lblWorkingDaysTitle
            // 
            lblWorkingDaysTitle.AutoSize = true;
            lblWorkingDaysTitle.Font = new Font("Segoe UI", 9.75F);
            lblWorkingDaysTitle.ForeColor = Color.Gray;
            lblWorkingDaysTitle.Location = new Point(15, 15);
            lblWorkingDaysTitle.Name = "lblWorkingDaysTitle";
            lblWorkingDaysTitle.Size = new Size(152, 17);
            lblWorkingDaysTitle.TabIndex = 0;
            lblWorkingDaysTitle.Text = "Ngày đi làm trong tháng";
            // 
            // pnlDaysOff
            // 
            pnlDaysOff.BackColor = Color.FromArgb(30, 30, 30);
            pnlDaysOff.Controls.Add(btnDetailDaysOff);
            pnlDaysOff.Controls.Add(lblDaysOffValue);
            pnlDaysOff.Controls.Add(lblDaysOffTitle);
            pnlDaysOff.Location = new Point(531, 20);
            pnlDaysOff.Name = "pnlDaysOff";
            pnlDaysOff.Size = new Size(234, 100);
            pnlDaysOff.TabIndex = 3;
            // 
            // btnDetailDaysOff
            // 
            btnDetailDaysOff.BackColor = Color.MediumSeaGreen;
            btnDetailDaysOff.FlatAppearance.BorderSize = 0;
            btnDetailDaysOff.FlatStyle = FlatStyle.Flat;
            btnDetailDaysOff.ForeColor = Color.White;
            btnDetailDaysOff.Location = new Point(162, 12);
            btnDetailDaysOff.Name = "btnDetailDaysOff";
            btnDetailDaysOff.Size = new Size(57, 25);
            btnDetailDaysOff.TabIndex = 3;
            btnDetailDaysOff.Text = "Cụ thể";
            btnDetailDaysOff.UseVisualStyleBackColor = false;
            // 
            // lblDaysOffValue
            // 
            lblDaysOffValue.AutoSize = true;
            lblDaysOffValue.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold);
            lblDaysOffValue.ForeColor = Color.MediumSeaGreen;
            lblDaysOffValue.Location = new Point(15, 45);
            lblDaysOffValue.Name = "lblDaysOffValue";
            lblDaysOffValue.Size = new Size(79, 30);
            lblDaysOffValue.TabIndex = 1;
            lblDaysOffValue.Text = "7 ngày";
            // 
            // lblDaysOffTitle
            // 
            lblDaysOffTitle.AutoSize = true;
            lblDaysOffTitle.Font = new Font("Segoe UI", 9.75F);
            lblDaysOffTitle.ForeColor = Color.Gray;
            lblDaysOffTitle.Location = new Point(15, 15);
            lblDaysOffTitle.Name = "lblDaysOffTitle";
            lblDaysOffTitle.Size = new Size(141, 17);
            lblDaysOffTitle.TabIndex = 0;
            lblDaysOffTitle.Text = "Ngày nghỉ trong tháng";
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
            // 
            // ucOverview_Staff
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(45, 45, 48);
            Controls.Add(pnlNotif);
            Controls.Add(pnlDaysOff);
            Controls.Add(pnlWorkingDays);
            Controls.Add(pnlUnreadMsg);
            Name = "ucOverview_Staff";
            Size = new Size(804, 530);
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

        #endregion

        private System.Windows.Forms.Panel pnlUnreadMsg;
        private System.Windows.Forms.Label lblUnreadMsgTitle;
        private System.Windows.Forms.Label lblUnreadMsgValue;
        private Button btnDetailMsg;
        private System.Windows.Forms.Panel pnlWorkingDays;
        private System.Windows.Forms.Label lblWorkingDaysTitle;
        private System.Windows.Forms.Label lblWorkingDaysValue;
        private Button btnDetailWorkingDays;
        private System.Windows.Forms.Panel pnlDaysOff;
        private System.Windows.Forms.Label lblDaysOffTitle;
        private System.Windows.Forms.Label lblDaysOffValue;
        private Button btnDetailDaysOff;
        private System.Windows.Forms.Panel pnlNotif;
        private System.Windows.Forms.Label lblNotifTitle;
        private System.Windows.Forms.ListBox lstNotifications;
    }
}