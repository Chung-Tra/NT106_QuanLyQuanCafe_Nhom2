using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace GUI
{
    partial class RecordEdit
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
            btnSave = new Guna2Button();
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
            panel1.Controls.Add(pnlScroll);
            panel1.Controls.Add(btnSave);
            panel1.Controls.Add(btnCancel);
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
            lblTitle.Text = "SỬA THÔNG TIN";
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
            // btnSave
            //
            btnSave.BorderRadius = 10;
            btnSave.Cursor = Cursors.Hand;
            btnSave.FillColor = Color.FromArgb(31, 138, 154);
            btnSave.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnSave.ForeColor = Color.White;
            btnSave.HoverState.FillColor = Color.FromArgb(45, 158, 174);
            btnSave.Location = new Point(238, 510);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(206, 44);
            btnSave.TabIndex = 2;
            btnSave.Text = "Lưu thay đổi";
            btnSave.Click += btnSave_Click;
            //
            // btnCancel
            //
            btnCancel.BorderColor = Color.FromArgb(80, 80, 90);
            btnCancel.BorderRadius = 10;
            btnCancel.BorderThickness = 1;
            btnCancel.Cursor = Cursors.Hand;
            btnCancel.FillColor = Color.Transparent;
            btnCancel.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnCancel.ForeColor = Color.FromArgb(220, 220, 225);
            btnCancel.HoverState.FillColor = Color.FromArgb(55, 55, 62);
            btnCancel.Location = new Point(24, 510);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(200, 44);
            btnCancel.TabIndex = 3;
            btnCancel.Text = "Hủy";
            btnCancel.Click += btnCancel_Click;
            //
            // shadow
            //
            shadow.TargetForm = this;
            //
            // RecordEdit
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
            Name = "RecordEdit";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Sửa thông tin";
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Guna2Panel panel1;
        private Label lblTitle;
        private Panel pnlScroll;
        private Guna2Button btnSave;
        private Guna2Button btnCancel;
        private Guna2ShadowForm shadow;
    }
}
