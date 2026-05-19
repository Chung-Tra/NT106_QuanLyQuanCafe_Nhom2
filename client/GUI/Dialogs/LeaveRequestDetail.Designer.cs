using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace GUI
{
    partial class LeaveRequestDetail
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            flpLeaves = new FlowLayoutPanel();
            btnClose  = new Guna2Button();
            lblTitle  = new Label();
            SuspendLayout();

            // lblTitle
            lblTitle.Text      = "🏖  Danh sách đơn xin nghỉ";
            lblTitle.Font      = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.AutoSize  = true;
            lblTitle.Location  = new Point(20, 18);

            // flpLeaves
            flpLeaves.FlowDirection    = FlowDirection.TopDown;
            flpLeaves.AutoScroll       = true;
            flpLeaves.WrapContents     = false;
            flpLeaves.BackColor        = Color.Transparent;
            flpLeaves.Location         = new Point(20, 56);
            flpLeaves.Size             = new Size(560, 330);

            // btnClose
            btnClose.Text         = "Đóng";
            btnClose.Size         = new Size(100, 36);
            btnClose.Location     = new Point(480, 402);
            btnClose.BorderRadius = 8;
            btnClose.Cursor       = Cursors.Hand;
            btnClose.FillColor    = Color.FromArgb(31, 138, 154);
            btnClose.ForeColor    = Color.White;
            btnClose.Font         = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnClose.HoverState.FillColor = Color.FromArgb(45, 158, 174);
            btnClose.Click       += btnClose_Click;

            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode       = AutoScaleMode.Font;
            BackColor           = Color.FromArgb(31, 31, 34);
            ClientSize          = new System.Drawing.Size(600, 454);
            FormBorderStyle     = FormBorderStyle.None;
            StartPosition       = FormStartPosition.CenterParent;
            Controls.Add(lblTitle);
            Controls.Add(flpLeaves);
            Controls.Add(btnClose);
            ResumeLayout(false);
        }

        private FlowLayoutPanel flpLeaves;
        private Guna2Button     btnClose;
        private Label           lblTitle;
    }
}
