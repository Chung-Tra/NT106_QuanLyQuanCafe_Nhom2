using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace GUI
{
    partial class ucKDS_Barista
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        private void InitializeComponent()
        {
            pnlHeader = new Guna2Panel();
            lblTitle = new Label();
            btnReport = new Guna2Button();
            lblPending = new Label();
            lblInProgress = new Label();
            lblDone = new Label();
            pnlOrders = new Guna2Panel();
            lblPendingCol = new Label();
            lblInProgressCol = new Label();
            lblDoneCol = new Label();
            flpPendingOrders = new FlowLayoutPanel();
            flpInProgressOrders = new FlowLayoutPanel();
            flpDoneOrders = new FlowLayoutPanel();
            pnlHeader.SuspendLayout();
            pnlOrders.SuspendLayout();
            SuspendLayout();

            // ====== pnlHeader ======
            pnlHeader.BackColor = Color.FromArgb(31, 31, 34);
            pnlHeader.BorderRadius = 14;
            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Controls.Add(btnReport);
            pnlHeader.Controls.Add(lblPending);
            pnlHeader.Controls.Add(lblInProgress);
            pnlHeader.Controls.Add(lblDone);
            pnlHeader.Location = new Point(20, 15);
            pnlHeader.Size = new Size(764, 60);

            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(18, 18);
            lblTitle.Text = "🍳  Kitchen Display System";

            btnReport.BorderRadius = 8;
            btnReport.Cursor = Cursors.Hand;
            btnReport.FillColor = Color.FromArgb(70, 130, 180);
            btnReport.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnReport.ForeColor = Color.White;
            btnReport.HoverState.FillColor = Color.FromArgb(90, 150, 200);
            btnReport.Location = new Point(290, 14);
            btnReport.Size = new Size(95, 32);
            btnReport.Text = "📊 Báo cáo";

            lblPending.AutoSize = true;
            lblPending.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblPending.ForeColor = Color.FromArgb(245, 158, 11);
            lblPending.Location = new Point(420, 22);
            lblPending.Text = "Chờ: 5";

            lblInProgress.AutoSize = true;
            lblInProgress.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblInProgress.ForeColor = Color.FromArgb(31, 138, 154);
            lblInProgress.Location = new Point(530, 22);
            lblInProgress.Text = "Đang làm: 2";

            lblDone.AutoSize = true;
            lblDone.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblDone.ForeColor = Color.FromArgb(34, 197, 94);
            lblDone.Location = new Point(660, 22);
            lblDone.Text = "Xong: 8";

            // ====== pnlOrders ======
            pnlOrders.BackColor = Color.FromArgb(31, 31, 34);
            pnlOrders.BorderRadius = 14;
            pnlOrders.Controls.Add(lblPendingCol);
            pnlOrders.Controls.Add(lblInProgressCol);
            pnlOrders.Controls.Add(lblDoneCol);
            pnlOrders.Controls.Add(flpPendingOrders);
            pnlOrders.Controls.Add(flpInProgressOrders);
            pnlOrders.Controls.Add(flpDoneOrders);
            pnlOrders.Location = new Point(20, 85);
            pnlOrders.Size = new Size(764, 430);

            lblPendingCol.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblPendingCol.ForeColor = Color.FromArgb(245, 158, 11);
            lblPendingCol.Location = new Point(18, 14);
            lblPendingCol.Size = new Size(235, 22);
            lblPendingCol.Text = "CHỜ XỬ LÝ";
            lblPendingCol.TextAlign = ContentAlignment.MiddleCenter;

            lblInProgressCol.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblInProgressCol.ForeColor = Color.FromArgb(31, 138, 154);
            lblInProgressCol.Location = new Point(265, 14);
            lblInProgressCol.Size = new Size(235, 22);
            lblInProgressCol.Text = "ĐANG PHA CHẾ";
            lblInProgressCol.TextAlign = ContentAlignment.MiddleCenter;

            lblDoneCol.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblDoneCol.ForeColor = Color.FromArgb(34, 197, 94);
            lblDoneCol.Location = new Point(512, 14);
            lblDoneCol.Size = new Size(235, 22);
            lblDoneCol.Text = "HOÀN THÀNH";
            lblDoneCol.TextAlign = ContentAlignment.MiddleCenter;

            flpPendingOrders.AutoScroll = true;
            flpPendingOrders.BackColor = Color.FromArgb(24, 24, 27);
            flpPendingOrders.FlowDirection = FlowDirection.TopDown;
            flpPendingOrders.Location = new Point(18, 44);
            flpPendingOrders.Padding = new Padding(4);
            flpPendingOrders.Size = new Size(235, 372);
            flpPendingOrders.WrapContents = false;

            flpInProgressOrders.AutoScroll = true;
            flpInProgressOrders.BackColor = Color.FromArgb(24, 24, 27);
            flpInProgressOrders.FlowDirection = FlowDirection.TopDown;
            flpInProgressOrders.Location = new Point(265, 44);
            flpInProgressOrders.Padding = new Padding(4);
            flpInProgressOrders.Size = new Size(235, 372);
            flpInProgressOrders.WrapContents = false;

            flpDoneOrders.AutoScroll = true;
            flpDoneOrders.BackColor = Color.FromArgb(24, 24, 27);
            flpDoneOrders.FlowDirection = FlowDirection.TopDown;
            flpDoneOrders.Location = new Point(512, 44);
            flpDoneOrders.Padding = new Padding(4);
            flpDoneOrders.Size = new Size(235, 372);
            flpDoneOrders.WrapContents = false;

            // ====== ucKDS_Barista ======
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(39, 39, 42);
            Controls.Add(pnlHeader);
            Controls.Add(pnlOrders);
            Name = "ucKDS_Barista";
            Size = new Size(804, 530);
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            pnlOrders.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Guna2Panel pnlHeader;
        private Label lblTitle;
        private Guna2Button btnReport;
        private Label lblPending;
        private Label lblInProgress;
        private Label lblDone;
        private Guna2Panel pnlOrders;
        private Label lblPendingCol;
        private Label lblInProgressCol;
        private Label lblDoneCol;
        private FlowLayoutPanel flpPendingOrders;
        private FlowLayoutPanel flpInProgressOrders;
        private FlowLayoutPanel flpDoneOrders;
    }
}
