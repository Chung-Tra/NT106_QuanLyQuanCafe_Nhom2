using System.Drawing;
using System.Windows.Forms;

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
            pnlHeader = new Panel();
            lblTitle = new Label();
            lblPending = new Label();
            lblInProgress = new Label();
            lblDone = new Label();
            pnlOrders = new Panel();
            flpPendingOrders = new FlowLayoutPanel();
            flpInProgressOrders = new FlowLayoutPanel();
            flpDoneOrders = new FlowLayoutPanel();
            lblPendingCol = new Label();
            lblInProgressCol = new Label();
            lblDoneCol = new Label();
            pnlHeader.SuspendLayout();
            pnlOrders.SuspendLayout();
            SuspendLayout();
            //
            // pnlHeader
            //
            pnlHeader.BackColor = Color.FromArgb(30, 30, 30);
            btnReport = new Button();
            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Controls.Add(lblPending);
            pnlHeader.Controls.Add(lblInProgress);
            pnlHeader.Controls.Add(lblDone);
            pnlHeader.Controls.Add(btnReport);
            pnlHeader.Location = new Point(20, 15);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(764, 55);
            pnlHeader.TabIndex = 0;
            //
            // lblTitle
            //
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(15, 14);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(250, 25);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Kitchen Display System";
            //
            // lblPending
            //
            lblPending.AutoSize = true;
            lblPending.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblPending.ForeColor = Color.Orange;
            lblPending.Location = new Point(400, 18);
            lblPending.Name = "lblPending";
            lblPending.Size = new Size(90, 19);
            lblPending.TabIndex = 1;
            lblPending.Text = "Chờ: 5";
            //
            // lblInProgress
            //
            lblInProgress.AutoSize = true;
            lblInProgress.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblInProgress.ForeColor = Color.SteelBlue;
            lblInProgress.Location = new Point(530, 18);
            lblInProgress.Name = "lblInProgress";
            lblInProgress.Size = new Size(100, 19);
            lblInProgress.TabIndex = 2;
            lblInProgress.Text = "Đang làm: 2";
            //
            // lblDone
            //
            lblDone.AutoSize = true;
            lblDone.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblDone.ForeColor = Color.MediumSeaGreen;
            lblDone.Location = new Point(670, 18);
            lblDone.Name = "lblDone";
            lblDone.Size = new Size(70, 19);
            lblDone.TabIndex = 3;
            lblDone.Text = "Xong: 8";
            //
            // btnReport
            //
            btnReport.BackColor = Color.FromArgb(70, 130, 180);
            btnReport.Cursor = Cursors.Hand;
            btnReport.FlatAppearance.BorderSize = 0;
            btnReport.FlatStyle = FlatStyle.Flat;
            btnReport.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            btnReport.ForeColor = Color.White;
            btnReport.Location = new Point(280, 14);
            btnReport.Name = "btnReport";
            btnReport.Size = new Size(90, 28);
            btnReport.Text = "Báo cáo";
            //
            // pnlOrders
            //
            pnlOrders.BackColor = Color.FromArgb(30, 30, 30);
            pnlOrders.Controls.Add(lblPendingCol);
            pnlOrders.Controls.Add(lblInProgressCol);
            pnlOrders.Controls.Add(lblDoneCol);
            pnlOrders.Controls.Add(flpPendingOrders);
            pnlOrders.Controls.Add(flpInProgressOrders);
            pnlOrders.Controls.Add(flpDoneOrders);
            pnlOrders.Location = new Point(20, 80);
            pnlOrders.Name = "pnlOrders";
            pnlOrders.Size = new Size(764, 435);
            pnlOrders.TabIndex = 1;
            //
            // lblPendingCol
            //
            lblPendingCol.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblPendingCol.ForeColor = Color.Orange;
            lblPendingCol.Location = new Point(15, 10);
            lblPendingCol.Name = "lblPendingCol";
            lblPendingCol.Size = new Size(235, 22);
            lblPendingCol.TabIndex = 0;
            lblPendingCol.Text = "CHỜ XỬ LÝ";
            lblPendingCol.TextAlign = ContentAlignment.MiddleCenter;
            //
            // lblInProgressCol
            //
            lblInProgressCol.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblInProgressCol.ForeColor = Color.SteelBlue;
            lblInProgressCol.Location = new Point(265, 10);
            lblInProgressCol.Name = "lblInProgressCol";
            lblInProgressCol.Size = new Size(235, 22);
            lblInProgressCol.TabIndex = 1;
            lblInProgressCol.Text = "ĐANG PHA CHẾ";
            lblInProgressCol.TextAlign = ContentAlignment.MiddleCenter;
            //
            // lblDoneCol
            //
            lblDoneCol.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblDoneCol.ForeColor = Color.MediumSeaGreen;
            lblDoneCol.Location = new Point(515, 10);
            lblDoneCol.Name = "lblDoneCol";
            lblDoneCol.Size = new Size(235, 22);
            lblDoneCol.TabIndex = 2;
            lblDoneCol.Text = "HOÀN THÀNH";
            lblDoneCol.TextAlign = ContentAlignment.MiddleCenter;
            //
            // flpPendingOrders
            //
            flpPendingOrders.AutoScroll = true;
            flpPendingOrders.BackColor = Color.FromArgb(45, 45, 48);
            flpPendingOrders.FlowDirection = FlowDirection.TopDown;
            flpPendingOrders.Location = new Point(15, 38);
            flpPendingOrders.Name = "flpPendingOrders";
            flpPendingOrders.Size = new Size(235, 385);
            flpPendingOrders.TabIndex = 3;
            flpPendingOrders.WrapContents = false;
            //
            // flpInProgressOrders
            //
            flpInProgressOrders.AutoScroll = true;
            flpInProgressOrders.BackColor = Color.FromArgb(45, 45, 48);
            flpInProgressOrders.FlowDirection = FlowDirection.TopDown;
            flpInProgressOrders.Location = new Point(265, 38);
            flpInProgressOrders.Name = "flpInProgressOrders";
            flpInProgressOrders.Size = new Size(235, 385);
            flpInProgressOrders.TabIndex = 4;
            flpInProgressOrders.WrapContents = false;
            //
            // flpDoneOrders
            //
            flpDoneOrders.AutoScroll = true;
            flpDoneOrders.BackColor = Color.FromArgb(45, 45, 48);
            flpDoneOrders.FlowDirection = FlowDirection.TopDown;
            flpDoneOrders.Location = new Point(515, 38);
            flpDoneOrders.Name = "flpDoneOrders";
            flpDoneOrders.Size = new Size(235, 385);
            flpDoneOrders.TabIndex = 5;
            flpDoneOrders.WrapContents = false;
            //
            // ucKDS_Barista
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(45, 45, 48);
            Controls.Add(pnlOrders);
            Controls.Add(pnlHeader);
            Name = "ucKDS_Barista";
            Size = new Size(804, 530);
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            pnlOrders.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlHeader;
        private Label lblTitle;
        private Label lblPending;
        private Label lblInProgress;
        private Label lblDone;
        private Panel pnlOrders;
        private Label lblPendingCol;
        private Label lblInProgressCol;
        private Label lblDoneCol;
        private FlowLayoutPanel flpPendingOrders;
        private FlowLayoutPanel flpInProgressOrders;
        private FlowLayoutPanel flpDoneOrders;
        private Button btnReport;
    }
}
