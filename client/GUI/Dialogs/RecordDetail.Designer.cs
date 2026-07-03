using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace GUI
{
    partial class RecordDetail
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
            panel1 = new Guna2Panel();
            lblTitle = new Label();
            pnlScroll = new Panel();
            btnClose = new Guna2Button();
            shadow = new Guna2ShadowForm(components);
            panel1.SuspendLayout();
            SuspendLayout();
            //
            // panel1
            //
            panel1.BackColor = Color.FromArgb(39, 39, 42);
            panel1.BorderRadius = 18;
            panel1.Controls.Add(lblTitle);
            panel1.Controls.Add(pnlScroll);
            panel1.Controls.Add(btnClose);
            panel1.Location = new Point(16, 16);
            panel1.Name = "panel1";
            panel1.Size = new Size(468, 568);
            panel1.TabIndex = 0;
            //
            // lblTitle
            //
            lblTitle.BackColor = Color.Transparent;
            lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(16, 18);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(436, 32);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "CHI TIẾT";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            //
            // pnlScroll
            //
            pnlScroll.AutoScroll = true;
            pnlScroll.BackColor = Color.Transparent;
            pnlScroll.Location = new Point(24, 64);
            pnlScroll.Name = "pnlScroll";
            pnlScroll.Size = new Size(420, 436);
            pnlScroll.TabIndex = 1;
            //
            // btnClose
            //
            btnClose.BorderRadius = 10;
            btnClose.Cursor = Cursors.Hand;
            btnClose.FillColor = Color.FromArgb(31, 138, 154);
            btnClose.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnClose.ForeColor = Color.White;
            btnClose.HoverState.FillColor = Color.FromArgb(45, 158, 174);
            btnClose.Location = new Point(24, 510);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(420, 44);
            btnClose.TabIndex = 2;
            btnClose.Text = "Đóng";
            btnClose.Click += btnClose_Click;
            //
            // shadow
            //
            shadow.TargetForm = this;
            //
            // RecordDetail
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(24, 24, 27);
            ClientSize = new Size(500, 600);
            Controls.Add(panel1);
            Font = new Font("Segoe UI", 10F);
            FormBorderStyle = FormBorderStyle.None;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "RecordDetail";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Chi tiết";
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Guna2Panel panel1;
        private Label lblTitle;
        private Panel pnlScroll;
        private Guna2Button btnClose;
        private Guna2ShadowForm shadow;
    }
}
