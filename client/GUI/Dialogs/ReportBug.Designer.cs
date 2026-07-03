using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace GUI
{
    partial class ReportBug
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        // Controls khai báo ở Designer (VS thấy được); style/data set trong .cs.
        private void InitializeComponent()
        {
            components       = new System.ComponentModel.Container();
            panel1           = new Guna2Panel();
            lblHeader        = new Label();
            lblReporter      = new Label();
            lblType          = new Label();
            cboType          = new Guna2ComboBox();
            lblScreen        = new Label();
            txtScreen        = new Guna2TextBox();
            lblSubject       = new Label();
            txtSubject       = new Guna2TextBox();
            lblDesc          = new Label();
            rtxDescription   = new Guna2TextBox();
            chkUrgent        = new Guna2CustomCheckBox();
            lblUrgent        = new Label();
            btnSubmit        = new Guna2Button();
            btnCancel        = new Guna2Button();
            shadow           = new Guna2ShadowForm(components);
            panel1.SuspendLayout();
            SuspendLayout();
            //
            // panel1
            //
            panel1.BackColor = Color.FromArgb(39, 39, 42);
            panel1.BorderRadius = 18;
            panel1.Controls.Add(lblHeader);
            panel1.Controls.Add(lblReporter);
            panel1.Controls.Add(lblType);
            panel1.Controls.Add(cboType);
            panel1.Controls.Add(lblScreen);
            panel1.Controls.Add(txtScreen);
            panel1.Controls.Add(lblSubject);
            panel1.Controls.Add(txtSubject);
            panel1.Controls.Add(lblDesc);
            panel1.Controls.Add(rtxDescription);
            panel1.Controls.Add(chkUrgent);
            panel1.Controls.Add(lblUrgent);
            panel1.Controls.Add(btnSubmit);
            panel1.Controls.Add(btnCancel);
            panel1.Location = new Point(16, 16);
            panel1.Name = "panel1";
            panel1.Size = new Size(528, 590);
            panel1.TabIndex = 0;
            //
            // lblHeader
            //
            lblHeader.BackColor = Color.Transparent;
            lblHeader.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblHeader.ForeColor = Color.White;
            lblHeader.Location = new Point(12, 18);
            lblHeader.Name = "lblHeader";
            lblHeader.Size = new Size(504, 30);
            lblHeader.TabIndex = 0;
            lblHeader.Text = "Báo cáo lỗi cho Admin";
            lblHeader.TextAlign = ContentAlignment.MiddleCenter;
            //
            // lblReporter
            //
            lblReporter.AutoSize = true;
            lblReporter.BackColor = Color.Transparent;
            lblReporter.Font = new Font("Segoe UI", 9F, FontStyle.Italic);
            lblReporter.ForeColor = Color.FromArgb(160, 160, 166);
            lblReporter.Location = new Point(28, 52);
            lblReporter.Name = "lblReporter";
            lblReporter.Size = new Size(72, 15);
            lblReporter.TabIndex = 1;
            lblReporter.Text = "Người gửi:";
            //
            // lblType
            //
            lblType.AutoSize = true;
            lblType.BackColor = Color.Transparent;
            lblType.Font = new Font("Segoe UI", 9.5F);
            lblType.ForeColor = Color.FromArgb(160, 160, 166);
            lblType.Location = new Point(28, 80);
            lblType.Name = "lblType";
            lblType.Size = new Size(56, 17);
            lblType.TabIndex = 2;
            lblType.Text = "Loại lỗi:";
            //
            // cboType
            //
            cboType.BackColor = Color.Transparent;
            cboType.BorderColor = Color.FromArgb(63, 63, 70);
            cboType.BorderRadius = 10;
            cboType.DrawMode = DrawMode.OwnerDrawFixed;
            cboType.DropDownStyle = ComboBoxStyle.DropDownList;
            cboType.FillColor = Color.FromArgb(30, 30, 33);
            cboType.FocusedColor = Color.FromArgb(31, 138, 154);
            cboType.FocusedState.BorderColor = Color.FromArgb(31, 138, 154);
            cboType.Font = new Font("Segoe UI", 10F);
            cboType.ForeColor = Color.White;
            cboType.HoverState.BorderColor = Color.FromArgb(120, 120, 130);
            cboType.ItemHeight = 30;
            cboType.Items.AddRange(new object[] {
                "Lỗi giao diện (hiển thị, layout)",
                "Lỗi chức năng (nút bấm, thao tác)",
                "Sai dữ liệu / số liệu",
                "Lỗi đăng nhập / phân quyền",
                "Hiệu năng (chậm, treo, lag)",
                "Khác"
            });
            cboType.Location = new Point(28, 102);
            cboType.Name = "cboType";
            cboType.Size = new Size(472, 36);
            cboType.TabIndex = 3;
            //
            // lblScreen
            //
            lblScreen.AutoSize = true;
            lblScreen.BackColor = Color.Transparent;
            lblScreen.Font = new Font("Segoe UI", 9.5F);
            lblScreen.ForeColor = Color.FromArgb(160, 160, 166);
            lblScreen.Location = new Point(28, 150);
            lblScreen.Name = "lblScreen";
            lblScreen.Size = new Size(168, 17);
            lblScreen.TabIndex = 4;
            lblScreen.Text = "Màn hình / chức năng bị lỗi:";
            //
            // txtScreen
            //
            txtScreen.BorderColor = Color.FromArgb(63, 63, 70);
            txtScreen.BorderRadius = 10;
            txtScreen.DefaultText = "";
            txtScreen.FillColor = Color.FromArgb(30, 30, 33);
            txtScreen.FocusedState.BorderColor = Color.FromArgb(31, 138, 154);
            txtScreen.Font = new Font("Segoe UI", 10F);
            txtScreen.ForeColor = Color.White;
            txtScreen.HoverState.BorderColor = Color.FromArgb(120, 120, 130);
            txtScreen.Location = new Point(28, 172);
            txtScreen.Name = "txtScreen";
            txtScreen.PasswordChar = '\0';
            txtScreen.PlaceholderForeColor = Color.FromArgb(110, 110, 120);
            txtScreen.PlaceholderText = "Ví dụ: POS, Tiền lương, Đặt bàn...";
            txtScreen.SelectedText = "";
            txtScreen.Size = new Size(472, 42);
            txtScreen.TabIndex = 5;
            //
            // lblSubject
            //
            lblSubject.AutoSize = true;
            lblSubject.BackColor = Color.Transparent;
            lblSubject.Font = new Font("Segoe UI", 9.5F);
            lblSubject.ForeColor = Color.FromArgb(160, 160, 166);
            lblSubject.Location = new Point(28, 226);
            lblSubject.Name = "lblSubject";
            lblSubject.Size = new Size(48, 17);
            lblSubject.TabIndex = 6;
            lblSubject.Text = "Tiêu đề:";
            //
            // txtSubject
            //
            txtSubject.BorderColor = Color.FromArgb(63, 63, 70);
            txtSubject.BorderRadius = 10;
            txtSubject.DefaultText = "";
            txtSubject.FillColor = Color.FromArgb(30, 30, 33);
            txtSubject.FocusedState.BorderColor = Color.FromArgb(31, 138, 154);
            txtSubject.Font = new Font("Segoe UI", 10F);
            txtSubject.ForeColor = Color.White;
            txtSubject.HoverState.BorderColor = Color.FromArgb(120, 120, 130);
            txtSubject.Location = new Point(28, 248);
            txtSubject.Name = "txtSubject";
            txtSubject.PasswordChar = '\0';
            txtSubject.PlaceholderForeColor = Color.FromArgb(110, 110, 120);
            txtSubject.PlaceholderText = "Mô tả ngắn gọn lỗi gặp phải...";
            txtSubject.SelectedText = "";
            txtSubject.Size = new Size(472, 42);
            txtSubject.TabIndex = 7;
            //
            // lblDesc
            //
            lblDesc.AutoSize = true;
            lblDesc.BackColor = Color.Transparent;
            lblDesc.Font = new Font("Segoe UI", 9.5F);
            lblDesc.ForeColor = Color.FromArgb(160, 160, 166);
            lblDesc.Location = new Point(28, 302);
            lblDesc.Name = "lblDesc";
            lblDesc.Size = new Size(88, 17);
            lblDesc.TabIndex = 8;
            lblDesc.Text = "Mô tả chi tiết:";
            //
            // rtxDescription
            //
            rtxDescription.BorderColor = Color.FromArgb(63, 63, 70);
            rtxDescription.BorderRadius = 10;
            rtxDescription.DefaultText = "";
            rtxDescription.FillColor = Color.FromArgb(30, 30, 33);
            rtxDescription.FocusedState.BorderColor = Color.FromArgb(31, 138, 154);
            rtxDescription.Font = new Font("Segoe UI", 10F);
            rtxDescription.ForeColor = Color.White;
            rtxDescription.HoverState.BorderColor = Color.FromArgb(120, 120, 130);
            rtxDescription.Location = new Point(28, 324);
            rtxDescription.Multiline = true;
            rtxDescription.Name = "rtxDescription";
            rtxDescription.PasswordChar = '\0';
            rtxDescription.PlaceholderForeColor = Color.FromArgb(110, 110, 120);
            rtxDescription.PlaceholderText = "Các bước tái hiện lỗi, kết quả mong đợi vs thực tế...";
            rtxDescription.SelectedText = "";
            rtxDescription.Size = new Size(472, 110);
            rtxDescription.TabIndex = 9;
            //
            // chkUrgent
            //
            chkUrgent.Animated = true;
            chkUrgent.CheckedState.BorderColor = Color.FromArgb(220, 53, 69);
            chkUrgent.CheckedState.BorderRadius = 4;
            chkUrgent.CheckedState.BorderThickness = 0;
            chkUrgent.CheckedState.FillColor = Color.FromArgb(220, 53, 69);
            chkUrgent.Location = new Point(28, 448);
            chkUrgent.Name = "chkUrgent";
            chkUrgent.Size = new Size(20, 20);
            chkUrgent.TabIndex = 10;
            chkUrgent.UncheckedState.BorderColor = Color.FromArgb(100, 100, 110);
            chkUrgent.UncheckedState.BorderRadius = 4;
            chkUrgent.UncheckedState.BorderThickness = 1;
            chkUrgent.UncheckedState.FillColor = Color.Transparent;
            //
            // lblUrgent
            //
            lblUrgent.AutoSize = true;
            lblUrgent.BackColor = Color.Transparent;
            lblUrgent.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblUrgent.ForeColor = Color.FromArgb(220, 80, 80);
            lblUrgent.Location = new Point(56, 448);
            lblUrgent.Name = "lblUrgent";
            lblUrgent.Size = new Size(286, 17);
            lblUrgent.TabIndex = 11;
            lblUrgent.Text = "Lỗi NGHIÊM TRỌNG — cần xử lý gấp";
            //
            // btnSubmit
            //
            btnSubmit.BorderRadius = 10;
            btnSubmit.Cursor = Cursors.Hand;
            btnSubmit.FillColor = Color.FromArgb(31, 138, 154);
            btnSubmit.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnSubmit.ForeColor = Color.White;
            btnSubmit.HoverState.FillColor = Color.FromArgb(45, 158, 174);
            btnSubmit.Location = new Point(28, 488);
            btnSubmit.Name = "btnSubmit";
            btnSubmit.Size = new Size(340, 44);
            btnSubmit.TabIndex = 12;
            btnSubmit.Text = "Gửi cho Admin";
            //
            // btnCancel
            //
            btnCancel.BorderColor = Color.FromArgb(180, 60, 60);
            btnCancel.BorderRadius = 10;
            btnCancel.BorderThickness = 1;
            btnCancel.Cursor = Cursors.Hand;
            btnCancel.FillColor = Color.Transparent;
            btnCancel.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnCancel.ForeColor = Color.FromArgb(220, 80, 80);
            btnCancel.HoverState.FillColor = Color.FromArgb(180, 60, 60);
            btnCancel.HoverState.ForeColor = Color.White;
            btnCancel.Location = new Point(400, 488);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(100, 44);
            btnCancel.TabIndex = 13;
            btnCancel.Text = "Hủy";
            //
            // shadow
            //
            shadow.TargetForm = this;
            //
            // ReportBug
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(24, 24, 27);
            ClientSize = new Size(560, 622);
            Controls.Add(panel1);
            Font = new Font("Segoe UI", 10F);
            FormBorderStyle = FormBorderStyle.None;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ReportBug";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Báo cáo lỗi";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        private Guna2Panel          panel1;
        private Label               lblHeader;
        private Label               lblReporter;
        private Label               lblType;
        private Guna2ComboBox       cboType;
        private Label               lblScreen;
        private Guna2TextBox        txtScreen;
        private Label               lblSubject;
        private Guna2TextBox        txtSubject;
        private Label               lblDesc;
        private Guna2TextBox        rtxDescription;
        private Guna2CustomCheckBox chkUrgent;
        private Label               lblUrgent;
        private Guna2Button         btnSubmit;
        private Guna2Button         btnCancel;
        private Guna2ShadowForm     shadow;
    }
}
