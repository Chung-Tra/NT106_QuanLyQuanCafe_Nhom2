using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace GUI
{
    partial class SendBroadcast
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
            Guna.UI2.WinForms.Suite.CustomizableEdges ce1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges ce2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges ce3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges ce4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges ce5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges ce6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges ce7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges ce8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges ce9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges ce10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges ce11 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges ce12 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges ce13 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges ce14 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges ce15 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges ce16 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges ce17 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges ce18 = new Guna.UI2.WinForms.Suite.CustomizableEdges();

            panel1 = new Guna2Panel();
            lblHeader = new Label();
            pnlRecipient = new Guna2Panel();
            lblRecipientGroup = new Label();
            rdoAll = new Guna2CustomRadioButton();
            lblRdoAll = new Label();
            rdoIndividual = new Guna2CustomRadioButton();
            lblRdoIndividual = new Label();
            lblRecipient = new Label();
            cboRecipient = new Guna2ComboBox();
            lblPriority = new Label();
            cboPriority = new Guna2ComboBox();
            lblTitle = new Label();
            txtTitle = new Guna2TextBox();
            lblContent = new Label();
            rtxContent = new Guna2TextBox();
            lblCharCount = new Label();
            chkSendChat = new Guna2CustomCheckBox();
            lblSendChat = new Label();
            btnSend = new Guna2Button();
            btnCancel = new Guna2Button();
            shadow = new Guna2ShadowForm(components);

            panel1.SuspendLayout();
            pnlRecipient.SuspendLayout();
            SuspendLayout();

            // ====== panel1 (card) ======
            panel1.BackColor = Color.FromArgb(39, 39, 42);
            panel1.BorderRadius = 18;
            panel1.Controls.Add(lblHeader);
            panel1.Controls.Add(pnlRecipient);
            panel1.Controls.Add(lblPriority);
            panel1.Controls.Add(cboPriority);
            panel1.Controls.Add(lblTitle);
            panel1.Controls.Add(txtTitle);
            panel1.Controls.Add(lblContent);
            panel1.Controls.Add(rtxContent);
            panel1.Controls.Add(lblCharCount);
            panel1.Controls.Add(chkSendChat);
            panel1.Controls.Add(lblSendChat);
            panel1.Controls.Add(btnSend);
            panel1.Controls.Add(btnCancel);
            panel1.CustomizableEdges = ce1;
            panel1.Location = new Point(16, 16);
            panel1.Name = "panel1";
            panel1.ShadowDecoration.CustomizableEdges = ce2;
            panel1.Size = new Size(528, 588);
            panel1.TabIndex = 0;

            // ------ lblHeader ------
            lblHeader.AutoSize = false;
            lblHeader.BackColor = Color.Transparent;
            lblHeader.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblHeader.ForeColor = Color.White;
            lblHeader.Location = new Point(12, 18);
            lblHeader.Name = "lblHeader";
            lblHeader.Size = new Size(504, 30);
            lblHeader.TabIndex = 0;
            lblHeader.Text = "📨  Gửi thông báo";
            lblHeader.TextAlign = ContentAlignment.MiddleCenter;

            // ====== pnlRecipient (group card) ======
            pnlRecipient.BackColor = Color.FromArgb(31, 31, 34);
            pnlRecipient.BorderRadius = 12;
            pnlRecipient.Controls.Add(lblRecipientGroup);
            pnlRecipient.Controls.Add(rdoAll);
            pnlRecipient.Controls.Add(lblRdoAll);
            pnlRecipient.Controls.Add(rdoIndividual);
            pnlRecipient.Controls.Add(lblRdoIndividual);
            pnlRecipient.Controls.Add(lblRecipient);
            pnlRecipient.Controls.Add(cboRecipient);
            pnlRecipient.CustomizableEdges = ce3;
            pnlRecipient.Location = new Point(20, 58);
            pnlRecipient.Name = "pnlRecipient";
            pnlRecipient.ShadowDecoration.CustomizableEdges = ce4;
            pnlRecipient.Size = new Size(488, 96);
            pnlRecipient.TabIndex = 1;

            // ------ lblRecipientGroup ------
            lblRecipientGroup.AutoSize = true;
            lblRecipientGroup.BackColor = Color.Transparent;
            lblRecipientGroup.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblRecipientGroup.ForeColor = Color.FromArgb(160, 160, 166);
            lblRecipientGroup.Location = new Point(12, 8);
            lblRecipientGroup.Name = "lblRecipientGroup";
            lblRecipientGroup.Text = "Người nhận:";

            // ------ rdoAll ------
            rdoAll.Animated = true;
            rdoAll.CheckedState.BorderColor = Color.FromArgb(31, 138, 154);
            rdoAll.CheckedState.BorderThickness = 0;
            rdoAll.CheckedState.FillColor = Color.FromArgb(31, 138, 154);
            rdoAll.CheckedState.InnerColor = Color.White;
            rdoAll.CheckedState.InnerOffset = -4;
            rdoAll.Checked = true;
            rdoAll.Location = new Point(14, 36);
            rdoAll.Name = "rdoAll";
            rdoAll.Size = new Size(20, 20);
            rdoAll.TabIndex = 0;
            rdoAll.UncheckedState.BorderColor = Color.FromArgb(100, 100, 110);
            rdoAll.UncheckedState.BorderThickness = 1;
            rdoAll.UncheckedState.FillColor = Color.Transparent;
            rdoAll.UncheckedState.InnerColor = Color.Transparent;

            // ------ lblRdoAll ------
            lblRdoAll.AutoSize = true;
            lblRdoAll.BackColor = Color.Transparent;
            lblRdoAll.Font = new Font("Segoe UI", 9.5F);
            lblRdoAll.ForeColor = Color.White;
            lblRdoAll.Location = new Point(38, 38);
            lblRdoAll.Name = "lblRdoAll";
            lblRdoAll.Text = "Toàn bộ nhân viên";

            // ------ rdoIndividual ------
            rdoIndividual.Animated = true;
            rdoIndividual.CheckedState.BorderColor = Color.FromArgb(31, 138, 154);
            rdoIndividual.CheckedState.BorderThickness = 0;
            rdoIndividual.CheckedState.FillColor = Color.FromArgb(31, 138, 154);
            rdoIndividual.CheckedState.InnerColor = Color.White;
            rdoIndividual.CheckedState.InnerOffset = -4;
            rdoIndividual.Location = new Point(14, 66);
            rdoIndividual.Name = "rdoIndividual";
            rdoIndividual.Size = new Size(20, 20);
            rdoIndividual.TabIndex = 1;
            rdoIndividual.UncheckedState.BorderColor = Color.FromArgb(100, 100, 110);
            rdoIndividual.UncheckedState.BorderThickness = 1;
            rdoIndividual.UncheckedState.FillColor = Color.Transparent;
            rdoIndividual.UncheckedState.InnerColor = Color.Transparent;
            rdoIndividual.CheckedChanged += RdoIndividual_CheckedChanged;

            // ------ lblRdoIndividual ------
            lblRdoIndividual.AutoSize = true;
            lblRdoIndividual.BackColor = Color.Transparent;
            lblRdoIndividual.Font = new Font("Segoe UI", 9.5F);
            lblRdoIndividual.ForeColor = Color.White;
            lblRdoIndividual.Location = new Point(38, 68);
            lblRdoIndividual.Name = "lblRdoIndividual";
            lblRdoIndividual.Text = "Nhắn riêng:";

            // ------ lblRecipient ------
            lblRecipient.AutoSize = true;
            lblRecipient.BackColor = Color.Transparent;
            lblRecipient.Font = new Font("Segoe UI", 9F);
            lblRecipient.ForeColor = Color.FromArgb(110, 110, 120);
            lblRecipient.Location = new Point(150, 68);
            lblRecipient.Name = "lblRecipient";
            lblRecipient.Text = "Nhân viên:";

            // ------ cboRecipient ------
            cboRecipient.BackColor = Color.Transparent;
            cboRecipient.BorderColor = Color.FromArgb(63, 63, 70);
            cboRecipient.BorderRadius = 8;
            cboRecipient.CustomizableEdges = ce9;
            cboRecipient.DrawMode = DrawMode.OwnerDrawFixed;
            cboRecipient.DropDownStyle = ComboBoxStyle.DropDownList;
            cboRecipient.Enabled = false;
            cboRecipient.FillColor = Color.FromArgb(30, 30, 33);
            cboRecipient.FocusedColor = Color.FromArgb(31, 138, 154);
            cboRecipient.FocusedState.BorderColor = Color.FromArgb(31, 138, 154);
            cboRecipient.Font = new Font("Segoe UI", 9.5F);
            cboRecipient.ForeColor = Color.White;
            cboRecipient.HoverState.BorderColor = Color.FromArgb(120, 120, 130);
            cboRecipient.ItemHeight = 26;
            cboRecipient.Items.AddRange(new object[] {
                "NV001 - Nguyễn Văn An (Quản lý)",
                "NV002 - Trần Thị Bích (Pha chế)",
                "NV003 - Lê Hoàng Nam (Order Staff)",
                "NV004 - Phạm Minh Tuấn (Bảo vệ)",
                "NV005 - Đỗ Thị Hương (Pha chế)"
            });
            cboRecipient.Location = new Point(218, 64);
            cboRecipient.Name = "cboRecipient";
            cboRecipient.ShadowDecoration.CustomizableEdges = ce10;
            cboRecipient.Size = new Size(252, 28);
            cboRecipient.TabIndex = 2;

            // ------ lblPriority ------
            lblPriority.AutoSize = true;
            lblPriority.BackColor = Color.Transparent;
            lblPriority.Font = new Font("Segoe UI", 9.5F);
            lblPriority.ForeColor = Color.FromArgb(160, 160, 166);
            lblPriority.Location = new Point(20, 170);
            lblPriority.Name = "lblPriority";
            lblPriority.Text = "Mức độ:";

            // ------ cboPriority ------
            cboPriority.BackColor = Color.Transparent;
            cboPriority.BorderColor = Color.FromArgb(63, 63, 70);
            cboPriority.BorderRadius = 10;
            cboPriority.CustomizableEdges = ce11;
            cboPriority.DrawMode = DrawMode.OwnerDrawFixed;
            cboPriority.DropDownStyle = ComboBoxStyle.DropDownList;
            cboPriority.FillColor = Color.FromArgb(30, 30, 33);
            cboPriority.FocusedColor = Color.FromArgb(31, 138, 154);
            cboPriority.FocusedState.BorderColor = Color.FromArgb(31, 138, 154);
            cboPriority.Font = new Font("Segoe UI", 10F);
            cboPriority.ForeColor = Color.White;
            cboPriority.HoverState.BorderColor = Color.FromArgb(120, 120, 130);
            cboPriority.ItemHeight = 30;
            cboPriority.Items.AddRange(new object[] { "Thông báo thường", "Quan trọng !", "Khẩn cấp !!!" });
            cboPriority.Location = new Point(86, 166);
            cboPriority.Name = "cboPriority";
            cboPriority.ShadowDecoration.CustomizableEdges = ce12;
            cboPriority.Size = new Size(200, 36);
            cboPriority.TabIndex = 2;

            // ------ lblTitle ------
            lblTitle.AutoSize = true;
            lblTitle.BackColor = Color.Transparent;
            lblTitle.Font = new Font("Segoe UI", 9.5F);
            lblTitle.ForeColor = Color.FromArgb(160, 160, 166);
            lblTitle.Location = new Point(20, 218);
            lblTitle.Name = "lblTitle";
            lblTitle.Text = "Tiêu đề thông báo:";

            // ------ txtTitle ------
            txtTitle.BorderColor = Color.FromArgb(63, 63, 70);
            txtTitle.BorderRadius = 10;
            txtTitle.CustomizableEdges = ce13;
            txtTitle.DefaultText = "";
            txtTitle.DisabledState.BorderColor = Color.FromArgb(63, 63, 70);
            txtTitle.DisabledState.FillColor = Color.FromArgb(45, 45, 48);
            txtTitle.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            txtTitle.DisabledState.PlaceholderForeColor = Color.FromArgb(125, 137, 149);
            txtTitle.FillColor = Color.FromArgb(30, 30, 33);
            txtTitle.FocusedState.BorderColor = Color.FromArgb(31, 138, 154);
            txtTitle.Font = new Font("Segoe UI", 10F);
            txtTitle.ForeColor = Color.White;
            txtTitle.HoverState.BorderColor = Color.FromArgb(120, 120, 130);
            txtTitle.Location = new Point(20, 240);
            txtTitle.MaxLength = 120;
            txtTitle.Name = "txtTitle";
            txtTitle.PasswordChar = '\0';
            txtTitle.PlaceholderForeColor = Color.FromArgb(110, 110, 120);
            txtTitle.PlaceholderText = "Nhập tiêu đề thông báo...";
            txtTitle.SelectedText = "";
            txtTitle.ShadowDecoration.CustomizableEdges = ce14;
            txtTitle.Size = new Size(488, 40);
            txtTitle.TabIndex = 3;

            // ------ lblContent ------
            lblContent.AutoSize = true;
            lblContent.BackColor = Color.Transparent;
            lblContent.Font = new Font("Segoe UI", 9.5F);
            lblContent.ForeColor = Color.FromArgb(160, 160, 166);
            lblContent.Location = new Point(20, 292);
            lblContent.Name = "lblContent";
            lblContent.Text = "Nội dung:";

            // ------ rtxContent ------
            rtxContent.BorderColor = Color.FromArgb(63, 63, 70);
            rtxContent.BorderRadius = 10;
            rtxContent.CustomizableEdges = ce15;
            rtxContent.DefaultText = "";
            rtxContent.DisabledState.BorderColor = Color.FromArgb(63, 63, 70);
            rtxContent.DisabledState.FillColor = Color.FromArgb(45, 45, 48);
            rtxContent.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            rtxContent.DisabledState.PlaceholderForeColor = Color.FromArgb(125, 137, 149);
            rtxContent.FillColor = Color.FromArgb(30, 30, 33);
            rtxContent.FocusedState.BorderColor = Color.FromArgb(31, 138, 154);
            rtxContent.Font = new Font("Segoe UI", 10F);
            rtxContent.ForeColor = Color.White;
            rtxContent.HoverState.BorderColor = Color.FromArgb(120, 120, 130);
            rtxContent.Location = new Point(20, 314);
            rtxContent.Multiline = true;
            rtxContent.Name = "rtxContent";
            rtxContent.PasswordChar = '\0';
            rtxContent.PlaceholderForeColor = Color.FromArgb(110, 110, 120);
            rtxContent.PlaceholderText = "Nội dung chi tiết của thông báo...";
            rtxContent.SelectedText = "";
            rtxContent.ShadowDecoration.CustomizableEdges = ce16;
            rtxContent.Size = new Size(488, 130);
            rtxContent.TabIndex = 4;
            rtxContent.TextChanged += RtxContent_TextChanged;

            // ------ lblCharCount ------
            lblCharCount.AutoSize = true;
            lblCharCount.BackColor = Color.Transparent;
            lblCharCount.Font = new Font("Segoe UI", 8.5F);
            lblCharCount.ForeColor = Color.FromArgb(110, 110, 120);
            lblCharCount.Location = new Point(410, 448);
            lblCharCount.Name = "lblCharCount";
            lblCharCount.Text = "0 / 500 ký tự";

            // ------ chkSendChat ------
            chkSendChat.Animated = true;
            chkSendChat.CheckedState.BorderColor = Color.FromArgb(31, 138, 154);
            chkSendChat.CheckedState.BorderRadius = 4;
            chkSendChat.CheckedState.BorderThickness = 0;
            chkSendChat.CheckedState.FillColor = Color.FromArgb(31, 138, 154);
            chkSendChat.CustomizableEdges = ce17;
            chkSendChat.Location = new Point(20, 478);
            chkSendChat.Name = "chkSendChat";
            chkSendChat.ShadowDecoration.CustomizableEdges = ce18;
            chkSendChat.Size = new Size(20, 20);
            chkSendChat.TabIndex = 5;
            chkSendChat.UncheckedState.BorderColor = Color.FromArgb(100, 100, 110);
            chkSendChat.UncheckedState.BorderRadius = 4;
            chkSendChat.UncheckedState.BorderThickness = 1;
            chkSendChat.UncheckedState.FillColor = Color.Transparent;

            // ------ lblSendChat ------
            lblSendChat.AutoSize = true;
            lblSendChat.BackColor = Color.Transparent;
            lblSendChat.Font = new Font("Segoe UI", 9.5F);
            lblSendChat.ForeColor = Color.FromArgb(220, 220, 225);
            lblSendChat.Location = new Point(46, 478);
            lblSendChat.Name = "lblSendChat";
            lblSendChat.Text = "Đồng thời gửi vào Chat nội bộ";

            // ------ btnSend ------
            btnSend.BorderRadius = 10;
            btnSend.Cursor = Cursors.Hand;
            btnSend.FillColor = Color.FromArgb(31, 138, 154);
            btnSend.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnSend.ForeColor = Color.White;
            btnSend.HoverState.FillColor = Color.FromArgb(45, 158, 174);
            btnSend.Location = new Point(248, 524);
            btnSend.Name = "btnSend";
            btnSend.Size = new Size(140, 44);
            btnSend.TabIndex = 6;
            btnSend.Text = "Gửi thông báo";
            btnSend.Click += BtnSend_Click;

            // ------ btnCancel ------
            btnCancel.BorderColor = Color.FromArgb(180, 60, 60);
            btnCancel.BorderRadius = 10;
            btnCancel.BorderThickness = 1;
            btnCancel.Cursor = Cursors.Hand;
            btnCancel.FillColor = Color.Transparent;
            btnCancel.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnCancel.ForeColor = Color.FromArgb(220, 80, 80);
            btnCancel.HoverState.FillColor = Color.FromArgb(180, 60, 60);
            btnCancel.HoverState.ForeColor = Color.White;
            btnCancel.Location = new Point(398, 524);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(110, 44);
            btnCancel.TabIndex = 7;
            btnCancel.Text = "Hủy";
            btnCancel.Click += BtnCancel_Click;

            // ====== shadow ======
            shadow.TargetForm = this;

            // ====== SendBroadcast ======
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(24, 24, 27);
            ClientSize = new Size(560, 620);
            Controls.Add(panel1);
            Font = new Font("Segoe UI", 10F);
            FormBorderStyle = FormBorderStyle.None;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "SendBroadcast";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Gửi thông báo";

            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            pnlRecipient.ResumeLayout(false);
            pnlRecipient.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Guna2Panel panel1;
        private Label lblHeader;
        private Guna2Panel pnlRecipient;
        private Label lblRecipientGroup;
        private Guna2CustomRadioButton rdoAll;
        private Label lblRdoAll;
        private Guna2CustomRadioButton rdoIndividual;
        private Label lblRdoIndividual;
        private Label lblRecipient;
        private Guna2ComboBox cboRecipient;
        private Label lblPriority;
        private Guna2ComboBox cboPriority;
        private Label lblTitle;
        private Guna2TextBox txtTitle;
        private Label lblContent;
        private Guna2TextBox rtxContent;
        private Label lblCharCount;
        private Guna2CustomCheckBox chkSendChat;
        private Label lblSendChat;
        private Guna2Button btnSend;
        private Guna2Button btnCancel;
        private Guna2ShadowForm shadow;
    }
}
