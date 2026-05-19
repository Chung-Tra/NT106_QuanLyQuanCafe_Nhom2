using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace GUI
{
    partial class MsgBox
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
            pnlHeader = new Guna2Panel();
            lblIcon = new Label();
            lblTitle = new Label();
            pnlBody = new Guna2Panel();
            txtMessage = new TextBox();
            btnOk = new Guna2Button();
            btnCancel = new Guna2Button();
            shadow = new Guna2ShadowForm(components);
            pnlHeader.SuspendLayout();
            pnlBody.SuspendLayout();
            SuspendLayout();
            //
            // pnlHeader
            //
            pnlHeader.BackColor = Color.FromArgb(31, 138, 154);
            pnlHeader.Controls.Add(lblIcon);
            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(420, 60);
            pnlHeader.TabIndex = 0;
            pnlHeader.MouseDown += PnlHeader_MouseDown;
            //
            // lblIcon
            //
            lblIcon.AutoSize = true;
            lblIcon.BackColor = Color.Transparent;
            lblIcon.Font = new Font("Segoe UI Emoji", 18F);
            lblIcon.ForeColor = Color.White;
            lblIcon.Location = new Point(20, 14);
            lblIcon.Name = "lblIcon";
            lblIcon.Text = "ℹ";
            lblIcon.MouseDown += PnlHeader_MouseDown;
            //
            // lblTitle
            //
            lblTitle.AutoSize = true;
            lblTitle.BackColor = Color.Transparent;
            lblTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(60, 19);
            lblTitle.Name = "lblTitle";
            lblTitle.Text = "Thông báo";
            lblTitle.MouseDown += PnlHeader_MouseDown;
            //
            // pnlBody
            //
            pnlBody.BackColor = Color.FromArgb(39, 39, 42);
            pnlBody.Controls.Add(btnCancel);
            pnlBody.Controls.Add(txtMessage);
            pnlBody.Controls.Add(btnOk);
            pnlBody.Dock = DockStyle.Fill;
            pnlBody.Location = new Point(0, 60);
            pnlBody.Name = "pnlBody";
            pnlBody.Size = new Size(420, 180);
            pnlBody.TabIndex = 1;
            //
            // txtMessage
            //
            txtMessage.BackColor = Color.FromArgb(39, 39, 42);
            txtMessage.BorderStyle = BorderStyle.None;
            txtMessage.Font = new Font("Segoe UI", 10.5F);
            txtMessage.ForeColor = Color.FromArgb(220, 220, 225);
            txtMessage.Location = new Point(24, 15);
            txtMessage.Multiline = true;
            txtMessage.Name = "txtMessage";
            txtMessage.ReadOnly = true;
            txtMessage.ScrollBars = ScrollBars.None;
            txtMessage.ShortcutsEnabled = true;
            txtMessage.Size = new Size(372, 90);
            txtMessage.TabIndex = 1;
            txtMessage.TabStop = true;
            txtMessage.Text = "Nội dung thông báo...";
            txtMessage.TextAlign = HorizontalAlignment.Center;
            txtMessage.WordWrap = true;
            //
            // btnOk
            //
            btnOk.BorderRadius = 10;
            btnOk.Cursor = Cursors.Hand;
            btnOk.FillColor = Color.FromArgb(31, 138, 154);
            btnOk.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnOk.ForeColor = Color.White;
            btnOk.HoverState.FillColor = Color.FromArgb(45, 158, 174);
            btnOk.Location = new Point(70, 120);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(130, 42);
            btnOk.TabIndex = 0;
            btnOk.Text = "Đồng ý";
            btnOk.Click += BtnOk_Click;
            //
            // btnCancel
            //
            btnCancel.BorderColor = Color.FromArgb(80, 80, 90);
            btnCancel.BorderRadius = 10;
            btnCancel.BorderThickness = 1;
            btnCancel.Cursor = Cursors.Hand;
            btnCancel.FillColor = Color.Transparent;
            btnCancel.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnCancel.ForeColor = Color.FromArgb(200, 200, 205);
            btnCancel.HoverState.FillColor = Color.FromArgb(55, 55, 60);
            btnCancel.Location = new Point(220, 120);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(130, 42);
            btnCancel.TabIndex = 2;
            btnCancel.Text = "Hủy";
            btnCancel.Visible = false;
            btnCancel.Click += BtnCancel_Click;
            //
            // shadow
            //
            shadow.TargetForm = this;
            //
            // MsgBox
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(39, 39, 42);
            ClientSize = new Size(420, 240);
            Controls.Add(pnlBody);
            Controls.Add(pnlHeader);
            FormBorderStyle = FormBorderStyle.None;
            Name = "MsgBox";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Message Box";
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            pnlBody.ResumeLayout(false);
            pnlBody.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Guna2Panel pnlHeader;
        private Label lblIcon;
        private Label lblTitle;
        private Guna2Panel pnlBody;
        internal TextBox txtMessage;
        private Guna2Button btnOk;
        private Guna2Button btnCancel;
        private Guna2ShadowForm shadow;
    }
}
