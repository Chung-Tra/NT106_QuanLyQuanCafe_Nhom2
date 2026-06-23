using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace GUI
{
    partial class ReportIncident
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges11 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges12 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges13 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges14 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges15 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges16 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges17 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges18 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            panel1 = new Guna2Panel();
            lblHeader = new Label();
            lblPage = new Label();
            lblType = new Label();
            cboType = new Guna2ComboBox();
            lblSubject = new Label();
            txtSubject = new Guna2TextBox();
            lblLocation = new Label();
            txtLocation = new Guna2TextBox();
            lblDesc = new Label();
            rtxDescription = new Guna2TextBox();
            chkUrgent = new Guna2CustomCheckBox();
            lblUrgent = new Label();
            btnSubmit = new Guna2Button();
            btnSubmitAndChat = new Guna2Button();
            btnCancel = new Guna2Button();
            lblStatus = new Label();
            shadow = new Guna2ShadowForm(components);
            panel1.SuspendLayout();
            SuspendLayout();
            //
            // panel1
            //
            panel1.BackColor = Color.FromArgb(39, 39, 42);
            panel1.BorderRadius = 18;
            panel1.Controls.Add(lblHeader);
            panel1.Controls.Add(lblPage);
            panel1.Controls.Add(lblType);
            panel1.Controls.Add(cboType);
            panel1.Controls.Add(lblSubject);
            panel1.Controls.Add(txtSubject);
            panel1.Controls.Add(lblLocation);
            panel1.Controls.Add(txtLocation);
            panel1.Controls.Add(lblDesc);
            panel1.Controls.Add(rtxDescription);
            panel1.Controls.Add(chkUrgent);
            panel1.Controls.Add(lblUrgent);
            panel1.Controls.Add(btnSubmit);
            panel1.Controls.Add(btnSubmitAndChat);
            panel1.Controls.Add(btnCancel);
            panel1.Controls.Add(lblStatus);
            panel1.CustomizableEdges = customizableEdges1;
            panel1.Location = new Point(16, 16);
            panel1.Name = "panel1";
            panel1.ShadowDecoration.CustomizableEdges = customizableEdges2;
            panel1.Size = new Size(528, 590);
            panel1.TabIndex = 0;
            //
            // lblHeader
            //
            lblHeader.AutoSize = false;
            lblHeader.BackColor = Color.Transparent;
            lblHeader.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblHeader.ForeColor = Color.White;
            lblHeader.Location = new Point(12, 18);
            lblHeader.Name = "lblHeader";
            lblHeader.Size = new Size(504, 30);
            lblHeader.TabIndex = 0;
            lblHeader.Text = "📋  Báo cáo sự cố / sai sót";
            lblHeader.TextAlign = ContentAlignment.MiddleCenter;
            //
            // lblPage
            //
            lblPage.AutoSize = true;
            lblPage.BackColor = Color.Transparent;
            lblPage.Font = new Font("Segoe UI", 9F, FontStyle.Italic);
            lblPage.ForeColor = Color.FromArgb(160, 160, 166);
            lblPage.Location = new Point(28, 52);
            lblPage.Name = "lblPage";
            lblPage.Size = new Size(46, 15);
            lblPage.TabIndex = 1;
            lblPage.Text = "Trang:";
            //
            // lblType
            //
            lblType.AutoSize = true;
            lblType.BackColor = Color.Transparent;
            lblType.Font = new Font("Segoe UI", 9.5F);
            lblType.ForeColor = Color.FromArgb(160, 160, 166);
            lblType.Location = new Point(28, 80);
            lblType.Name = "lblType";
            lblType.Size = new Size(64, 17);
            lblType.TabIndex = 2;
            lblType.Text = "Loại sự cố:";
            //
            // cboType
            //
            cboType.BackColor = Color.Transparent;
            cboType.BorderColor = Color.FromArgb(63, 63, 70);
            cboType.BorderRadius = 10;
            cboType.CustomizableEdges = customizableEdges3;
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
                "Sai sót dữ liệu (chấm công, nguyên liệu, ...)",
                "Thiết bị hỏng / bể vỡ",
                "Hành vi không phù hợp của nhân viên",
                "Sự cố hệ thống phần mềm",
                "Mất mát / thất thoát tài sản",
                "Phàn nàn từ khách hàng",
                "Khác"
            });
            cboType.Location = new Point(28, 102);
            cboType.Name = "cboType";
            cboType.ShadowDecoration.CustomizableEdges = customizableEdges4;
            cboType.Size = new Size(472, 36);
            cboType.TabIndex = 3;
            //
            // lblSubject
            //
            lblSubject.AutoSize = true;
            lblSubject.BackColor = Color.Transparent;
            lblSubject.Font = new Font("Segoe UI", 9.5F);
            lblSubject.ForeColor = Color.FromArgb(160, 160, 166);
            lblSubject.Location = new Point(28, 150);
            lblSubject.Name = "lblSubject";
            lblSubject.Size = new Size(48, 17);
            lblSubject.TabIndex = 4;
            lblSubject.Text = "Tiêu đề:";
            //
            // txtSubject
            //
            txtSubject.BorderColor = Color.FromArgb(63, 63, 70);
            txtSubject.BorderRadius = 10;
            txtSubject.CustomizableEdges = customizableEdges5;
            txtSubject.DefaultText = "";
            txtSubject.DisabledState.BorderColor = Color.FromArgb(63, 63, 70);
            txtSubject.DisabledState.FillColor = Color.FromArgb(45, 45, 48);
            txtSubject.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            txtSubject.DisabledState.PlaceholderForeColor = Color.FromArgb(125, 137, 149);
            txtSubject.FillColor = Color.FromArgb(30, 30, 33);
            txtSubject.FocusedState.BorderColor = Color.FromArgb(31, 138, 154);
            txtSubject.Font = new Font("Segoe UI", 10F);
            txtSubject.ForeColor = Color.White;
            txtSubject.HoverState.BorderColor = Color.FromArgb(120, 120, 130);
            txtSubject.Location = new Point(28, 172);
            txtSubject.Name = "txtSubject";
            txtSubject.PasswordChar = '\0';
            txtSubject.PlaceholderForeColor = Color.FromArgb(110, 110, 120);
            txtSubject.PlaceholderText = "Mô tả ngắn gọn vấn đề...";
            txtSubject.SelectedText = "";
            txtSubject.ShadowDecoration.CustomizableEdges = customizableEdges6;
            txtSubject.Size = new Size(472, 42);
            txtSubject.TabIndex = 5;
            //
            // lblLocation
            //
            lblLocation.AutoSize = true;
            lblLocation.BackColor = Color.Transparent;
            lblLocation.Font = new Font("Segoe UI", 9.5F);
            lblLocation.ForeColor = Color.FromArgb(160, 160, 166);
            lblLocation.Location = new Point(28, 226);
            lblLocation.Name = "lblLocation";
            lblLocation.Size = new Size(72, 17);
            lblLocation.TabIndex = 6;
            lblLocation.Text = "Nơi xảy ra:";
            //
            // txtLocation
            //
            txtLocation.BorderColor = Color.FromArgb(63, 63, 70);
            txtLocation.BorderRadius = 10;
            txtLocation.CustomizableEdges = customizableEdges7;
            txtLocation.DefaultText = "";
            txtLocation.DisabledState.BorderColor = Color.FromArgb(63, 63, 70);
            txtLocation.DisabledState.FillColor = Color.FromArgb(45, 45, 48);
            txtLocation.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            txtLocation.DisabledState.PlaceholderForeColor = Color.FromArgb(125, 137, 149);
            txtLocation.FillColor = Color.FromArgb(30, 30, 33);
            txtLocation.FocusedState.BorderColor = Color.FromArgb(31, 138, 154);
            txtLocation.Font = new Font("Segoe UI", 10F);
            txtLocation.ForeColor = Color.White;
            txtLocation.HoverState.BorderColor = Color.FromArgb(120, 120, 130);
            txtLocation.Location = new Point(28, 248);
            txtLocation.Name = "txtLocation";
            txtLocation.PasswordChar = '\0';
            txtLocation.PlaceholderForeColor = Color.FromArgb(110, 110, 120);
            txtLocation.PlaceholderText = "Ví dụ: Quầy bar, bàn số 5, kho A...";
            txtLocation.SelectedText = "";
            txtLocation.ShadowDecoration.CustomizableEdges = customizableEdges8;
            txtLocation.Size = new Size(472, 42);
            txtLocation.TabIndex = 7;
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
            rtxDescription.CustomizableEdges = customizableEdges9;
            rtxDescription.DefaultText = "";
            rtxDescription.DisabledState.BorderColor = Color.FromArgb(63, 63, 70);
            rtxDescription.DisabledState.FillColor = Color.FromArgb(45, 45, 48);
            rtxDescription.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            rtxDescription.DisabledState.PlaceholderForeColor = Color.FromArgb(125, 137, 149);
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
            rtxDescription.PlaceholderText = "Mô tả chi tiết vấn đề, nguyên nhân, ảnh hưởng...";
            rtxDescription.SelectedText = "";
            rtxDescription.ShadowDecoration.CustomizableEdges = customizableEdges10;
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
            chkUrgent.CustomizableEdges = customizableEdges11;
            chkUrgent.Location = new Point(28, 448);
            chkUrgent.Name = "chkUrgent";
            chkUrgent.ShadowDecoration.CustomizableEdges = customizableEdges12;
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
            lblUrgent.Size = new Size(266, 17);
            lblUrgent.TabIndex = 11;
            lblUrgent.Text = "⚠  Sự cố KHẨN CẤP — cần xử lý ngay";
            //
            // btnSubmit
            //
            btnSubmit.BorderRadius = 10;
            btnSubmit.Cursor = Cursors.Hand;
            btnSubmit.CustomizableEdges = customizableEdges13;
            btnSubmit.FillColor = Color.FromArgb(31, 138, 154);
            btnSubmit.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnSubmit.ForeColor = Color.White;
            btnSubmit.HoverState.FillColor = Color.FromArgb(45, 158, 174);
            btnSubmit.Location = new Point(28, 488);
            btnSubmit.Name = "btnSubmit";
            btnSubmit.ShadowDecoration.CustomizableEdges = customizableEdges14;
            btnSubmit.Size = new Size(140, 44);
            btnSubmit.TabIndex = 12;
            btnSubmit.Text = "Gửi báo cáo";
            //
            // btnSubmitAndChat
            //
            btnSubmitAndChat.BorderRadius = 10;
            btnSubmitAndChat.Cursor = Cursors.Hand;
            btnSubmitAndChat.CustomizableEdges = customizableEdges15;
            btnSubmitAndChat.FillColor = Color.FromArgb(34, 197, 94);
            btnSubmitAndChat.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnSubmitAndChat.ForeColor = Color.White;
            btnSubmitAndChat.HoverState.FillColor = Color.FromArgb(50, 210, 110);
            btnSubmitAndChat.Location = new Point(180, 488);
            btnSubmitAndChat.Name = "btnSubmitAndChat";
            btnSubmitAndChat.ShadowDecoration.CustomizableEdges = customizableEdges16;
            btnSubmitAndChat.Size = new Size(208, 44);
            btnSubmitAndChat.TabIndex = 13;
            btnSubmitAndChat.Text = "Gửi + Chat Manager";
            //
            // btnCancel
            //
            btnCancel.BorderColor = Color.FromArgb(180, 60, 60);
            btnCancel.BorderRadius = 10;
            btnCancel.BorderThickness = 1;
            btnCancel.Cursor = Cursors.Hand;
            btnCancel.CustomizableEdges = customizableEdges17;
            btnCancel.FillColor = Color.Transparent;
            btnCancel.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnCancel.ForeColor = Color.FromArgb(220, 80, 80);
            btnCancel.HoverState.FillColor = Color.FromArgb(180, 60, 60);
            btnCancel.HoverState.ForeColor = Color.White;
            btnCancel.Location = new Point(400, 488);
            btnCancel.Name = "btnCancel";
            btnCancel.ShadowDecoration.CustomizableEdges = customizableEdges18;
            btnCancel.Size = new Size(100, 44);
            btnCancel.TabIndex = 14;
            btnCancel.Text = "Hủy";
            //
            // lblStatus
            //
            lblStatus.AutoSize = true;
            lblStatus.BackColor = Color.Transparent;
            lblStatus.Font = new Font("Segoe UI", 9F);
            lblStatus.ForeColor = Color.FromArgb(34, 197, 94);
            lblStatus.Location = new Point(28, 548);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(0, 15);
            lblStatus.TabIndex = 15;
            //
            // shadow
            //
            shadow.TargetForm = this;
            //
            // ReportIncident
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
            Name = "ReportIncident";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Báo cáo sự cố";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Guna2Panel panel1;
        private Label lblHeader;
        private Label lblPage;
        private Label lblType;
        private Guna2ComboBox cboType;
        private Label lblSubject;
        private Guna2TextBox txtSubject;
        private Label lblLocation;
        private Guna2TextBox txtLocation;
        private Label lblDesc;
        private Guna2TextBox rtxDescription;
        private Guna2CustomCheckBox chkUrgent;
        private Label lblUrgent;
        private Guna2Button btnSubmit;
        private Guna2Button btnSubmitAndChat;
        private Guna2Button btnCancel;
        private Label lblStatus;
        private Guna2ShadowForm shadow;
    }
}
