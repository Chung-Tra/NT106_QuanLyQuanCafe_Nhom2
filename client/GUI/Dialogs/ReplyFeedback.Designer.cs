using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace GUI
{
    partial class ReplyFeedback
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
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
            panel1 = new Guna2Panel();
            lblTitle = new Label();
            lblCustomer = new Label();
            lblOriginal = new Label();
            txtOriginalContent = new Guna2TextBox();
            lblReply = new Label();
            txtReply = new Guna2TextBox();
            btnSend = new Guna2Button();
            btnCancel = new Guna2Button();
            shadow = new Guna2ShadowForm(components);
            panel1.SuspendLayout();
            SuspendLayout();
            //
            // panel1
            //
            panel1.BackColor = Color.FromArgb(39, 39, 42);
            panel1.BorderRadius = 18;
            panel1.Controls.Add(lblTitle);
            panel1.Controls.Add(lblCustomer);
            panel1.Controls.Add(lblOriginal);
            panel1.Controls.Add(txtOriginalContent);
            panel1.Controls.Add(lblReply);
            panel1.Controls.Add(txtReply);
            panel1.Controls.Add(btnSend);
            panel1.Controls.Add(btnCancel);
            panel1.CustomizableEdges = customizableEdges1;
            panel1.Location = new Point(16, 16);
            panel1.Name = "panel1";
            panel1.ShadowDecoration.CustomizableEdges = customizableEdges2;
            panel1.Size = new Size(508, 478);
            panel1.TabIndex = 0;
            //
            // lblTitle
            //
            lblTitle.AutoSize = false;
            lblTitle.BackColor = Color.Transparent;
            lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(12, 22);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(484, 32);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Trả lời phản hồi";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            //
            // lblCustomer
            //
            lblCustomer.AutoSize = true;
            lblCustomer.BackColor = Color.Transparent;
            lblCustomer.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblCustomer.ForeColor = Color.FromArgb(245, 158, 11);
            lblCustomer.Location = new Point(30, 68);
            lblCustomer.Name = "lblCustomer";
            lblCustomer.Size = new Size(120, 19);
            lblCustomer.TabIndex = 1;
            lblCustomer.Text = "Khách hàng: ---";
            //
            // lblOriginal
            //
            lblOriginal.AutoSize = true;
            lblOriginal.BackColor = Color.Transparent;
            lblOriginal.Font = new Font("Segoe UI", 9.5F);
            lblOriginal.ForeColor = Color.FromArgb(160, 160, 166);
            lblOriginal.Location = new Point(30, 100);
            lblOriginal.Name = "lblOriginal";
            lblOriginal.Size = new Size(90, 17);
            lblOriginal.TabIndex = 2;
            lblOriginal.Text = "Nội dung gốc:";
            //
            // txtOriginalContent
            //
            txtOriginalContent.BorderColor = Color.FromArgb(63, 63, 70);
            txtOriginalContent.BorderRadius = 10;
            txtOriginalContent.CustomizableEdges = customizableEdges3;
            txtOriginalContent.DefaultText = "";
            txtOriginalContent.DisabledState.BorderColor = Color.FromArgb(63, 63, 70);
            txtOriginalContent.DisabledState.FillColor = Color.FromArgb(45, 45, 48);
            txtOriginalContent.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            txtOriginalContent.DisabledState.PlaceholderForeColor = Color.FromArgb(125, 137, 149);
            txtOriginalContent.FillColor = Color.FromArgb(45, 45, 48);
            txtOriginalContent.FocusedState.BorderColor = Color.FromArgb(31, 138, 154);
            txtOriginalContent.Font = new Font("Segoe UI", 10F);
            txtOriginalContent.ForeColor = Color.FromArgb(220, 220, 225);
            txtOriginalContent.HoverState.BorderColor = Color.FromArgb(120, 120, 130);
            txtOriginalContent.Location = new Point(30, 122);
            txtOriginalContent.Multiline = true;
            txtOriginalContent.Name = "txtOriginalContent";
            txtOriginalContent.PasswordChar = '\0';
            txtOriginalContent.PlaceholderForeColor = Color.FromArgb(110, 110, 120);
            txtOriginalContent.PlaceholderText = "";
            txtOriginalContent.ReadOnly = true;
            txtOriginalContent.ScrollBars = ScrollBars.None;
            txtOriginalContent.SelectedText = "";
            txtOriginalContent.ShadowDecoration.CustomizableEdges = customizableEdges4;
            txtOriginalContent.Size = new Size(448, 90);
            txtOriginalContent.TabIndex = 3;
            //
            // lblReply
            //
            lblReply.AutoSize = true;
            lblReply.BackColor = Color.Transparent;
            lblReply.Font = new Font("Segoe UI", 9.5F);
            lblReply.ForeColor = Color.FromArgb(160, 160, 166);
            lblReply.Location = new Point(30, 212);
            lblReply.Name = "lblReply";
            lblReply.Size = new Size(105, 17);
            lblReply.TabIndex = 4;
            lblReply.Text = "Nội dung trả lời:";
            //
            // txtReply
            //
            txtReply.BorderColor = Color.FromArgb(63, 63, 70);
            txtReply.BorderRadius = 10;
            txtReply.CustomizableEdges = customizableEdges5;
            txtReply.DefaultText = "";
            txtReply.DisabledState.BorderColor = Color.FromArgb(63, 63, 70);
            txtReply.DisabledState.FillColor = Color.FromArgb(45, 45, 48);
            txtReply.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            txtReply.DisabledState.PlaceholderForeColor = Color.FromArgb(125, 137, 149);
            txtReply.FillColor = Color.FromArgb(30, 30, 33);
            txtReply.FocusedState.BorderColor = Color.FromArgb(31, 138, 154);
            txtReply.Font = new Font("Segoe UI", 10F);
            txtReply.ForeColor = Color.White;
            txtReply.HoverState.BorderColor = Color.FromArgb(120, 120, 130);
            txtReply.Location = new Point(30, 234);
            txtReply.Multiline = true;
            txtReply.Name = "txtReply";
            txtReply.PasswordChar = '\0';
            txtReply.PlaceholderForeColor = Color.FromArgb(110, 110, 120);
            txtReply.PlaceholderText = "Nhập nội dung trả lời...";
            txtReply.ScrollBars = ScrollBars.None;
            txtReply.SelectedText = "";
            txtReply.ShadowDecoration.CustomizableEdges = customizableEdges6;
            txtReply.Size = new Size(448, 140);
            txtReply.TabIndex = 5;
            //
            // btnSend
            //
            btnSend.BorderRadius = 10;
            btnSend.Cursor = Cursors.Hand;
            btnSend.CustomizableEdges = customizableEdges7;
            btnSend.DisabledState.BorderColor = Color.DarkGray;
            btnSend.DisabledState.CustomBorderColor = Color.DarkGray;
            btnSend.DisabledState.FillColor = Color.FromArgb(80, 80, 80);
            btnSend.DisabledState.ForeColor = Color.FromArgb(190, 190, 190);
            btnSend.FillColor = Color.FromArgb(31, 138, 154);
            btnSend.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnSend.ForeColor = Color.White;
            btnSend.HoverState.FillColor = Color.FromArgb(45, 158, 174);
            btnSend.Location = new Point(30, 392);
            btnSend.Name = "btnSend";
            btnSend.ShadowDecoration.CustomizableEdges = customizableEdges8;
            btnSend.Size = new Size(216, 46);
            btnSend.TabIndex = 6;
            btnSend.Text = "Gửi trả lời";
            btnSend.Click += btnSend_Click;
            //
            // btnCancel
            //
            btnCancel.BorderColor = Color.FromArgb(180, 60, 60);
            btnCancel.BorderRadius = 10;
            btnCancel.BorderThickness = 1;
            btnCancel.CausesValidation = false;
            btnCancel.Cursor = Cursors.Hand;
            btnCancel.FillColor = Color.Transparent;
            btnCancel.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnCancel.ForeColor = Color.FromArgb(220, 80, 80);
            btnCancel.HoverState.FillColor = Color.FromArgb(180, 60, 60);
            btnCancel.HoverState.ForeColor = Color.White;
            btnCancel.Location = new Point(262, 392);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(216, 46);
            btnCancel.TabIndex = 7;
            btnCancel.Text = "Hủy";
            btnCancel.Click += btnCancel_Click;
            //
            // shadow
            //
            shadow.TargetForm = this;
            //
            // ReplyFeedback
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(24, 24, 27);
            ClientSize = new Size(540, 510);
            Controls.Add(panel1);
            Font = new Font("Segoe UI", 10F);
            FormBorderStyle = FormBorderStyle.None;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ReplyFeedback";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Trả lời phản hồi";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Guna2Panel panel1;
        private Label lblTitle;
        private Label lblCustomer;
        private Label lblOriginal;
        private Guna2TextBox txtOriginalContent;
        private Label lblReply;
        private Guna2TextBox txtReply;
        private Guna2Button btnSend;
        private Guna2Button btnCancel;
        private Guna2ShadowForm shadow;
    }
}
