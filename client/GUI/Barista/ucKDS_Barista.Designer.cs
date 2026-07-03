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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            pnlHeader = new Guna2Panel();
            lblTitle = new Label();
            lblPending = new Label();
            lblInProgress = new Label();
            lblDone = new Label();
            pnlOrders = new Guna2Panel();
            tblCols = new TableLayoutPanel();
            lblPendingCol = new Label();
            lblInProgressCol = new Label();
            lblDoneCol = new Label();
            flpPendingOrders = new FlowLayoutPanel();
            flpInProgressOrders = new FlowLayoutPanel();
            flpDoneOrders = new FlowLayoutPanel();
            pnlHeader.SuspendLayout();
            pnlOrders.SuspendLayout();
            tblCols.SuspendLayout();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlHeader.BackColor = Color.FromArgb(31, 31, 34);
            pnlHeader.BorderRadius = 14;
            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Controls.Add(lblPending);
            pnlHeader.Controls.Add(lblInProgress);
            pnlHeader.Controls.Add(lblDone);
            pnlHeader.CustomizableEdges = customizableEdges1;
            pnlHeader.Location = new Point(20, 15);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.ShadowDecoration.CustomizableEdges = customizableEdges2;
            pnlHeader.Size = new Size(960, 60);
            pnlHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(18, 18);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(246, 25);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Kitchen Display System";
            // 
            // lblPending
            // 
            lblPending.AutoSize = true;
            lblPending.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblPending.ForeColor = Color.FromArgb(245, 158, 11);
            lblPending.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblPending.Location = new Point(602, 22);
            lblPending.Name = "lblPending";
            lblPending.Size = new Size(51, 19);
            lblPending.TabIndex = 2;
            lblPending.Text = "Chờ: 5";
            // 
            // lblInProgress
            // 
            lblInProgress.AutoSize = true;
            lblInProgress.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblInProgress.ForeColor = Color.FromArgb(31, 138, 154);
            lblInProgress.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblInProgress.Location = new Point(702, 22);
            lblInProgress.Name = "lblInProgress";
            lblInProgress.Size = new Size(89, 19);
            lblInProgress.TabIndex = 3;
            lblInProgress.Text = "Đang làm: 2";
            // 
            // lblDone
            // 
            lblDone.AutoSize = true;
            lblDone.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblDone.ForeColor = Color.FromArgb(34, 197, 94);
            lblDone.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblDone.Location = new Point(832, 22);
            lblDone.Name = "lblDone";
            lblDone.Size = new Size(60, 19);
            lblDone.TabIndex = 4;
            lblDone.Text = "Xong: 8";
            // 
            // pnlOrders
            // 
            pnlOrders.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnlOrders.BackColor = Color.FromArgb(31, 31, 34);
            pnlOrders.BorderRadius = 14;
            pnlOrders.Controls.Add(tblCols);
            pnlOrders.CustomizableEdges = customizableEdges3;
            pnlOrders.Location = new Point(20, 85);
            pnlOrders.Name = "pnlOrders";
            pnlOrders.ShadowDecoration.CustomizableEdges = customizableEdges4;
            pnlOrders.Size = new Size(960, 560);
            pnlOrders.TabIndex = 1;
            //
            // tblCols — 3 cột kanban giãn đều theo bề ngang
            //
            tblCols.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tblCols.ColumnCount = 3;
            tblCols.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.34F));
            tblCols.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33F));
            tblCols.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33F));
            tblCols.RowCount = 2;
            tblCols.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tblCols.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tblCols.Location = new Point(18, 14);
            tblCols.Size = new Size(924, 528);
            tblCols.Controls.Add(lblPendingCol, 0, 0);
            tblCols.Controls.Add(lblInProgressCol, 1, 0);
            tblCols.Controls.Add(lblDoneCol, 2, 0);
            tblCols.Controls.Add(flpPendingOrders, 0, 1);
            tblCols.Controls.Add(flpInProgressOrders, 1, 1);
            tblCols.Controls.Add(flpDoneOrders, 2, 1);
            //
            // lblPendingCol
            //
            lblPendingCol.Dock = DockStyle.Fill;
            lblPendingCol.Margin = new Padding(0, 0, 9, 0);
            lblPendingCol.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblPendingCol.ForeColor = Color.FromArgb(245, 158, 11);
            lblPendingCol.Name = "lblPendingCol";
            lblPendingCol.TabIndex = 0;
            lblPendingCol.Text = "CHỜ XỬ LÝ";
            lblPendingCol.TextAlign = ContentAlignment.MiddleCenter;
            //
            // lblInProgressCol
            //
            lblInProgressCol.Dock = DockStyle.Fill;
            lblInProgressCol.Margin = new Padding(9, 0, 9, 0);
            lblInProgressCol.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblInProgressCol.ForeColor = Color.FromArgb(31, 138, 154);
            lblInProgressCol.Name = "lblInProgressCol";
            lblInProgressCol.TabIndex = 1;
            lblInProgressCol.Text = "ĐANG PHA CHẾ";
            lblInProgressCol.TextAlign = ContentAlignment.MiddleCenter;
            //
            // lblDoneCol
            //
            lblDoneCol.Dock = DockStyle.Fill;
            lblDoneCol.Margin = new Padding(9, 0, 0, 0);
            lblDoneCol.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblDoneCol.ForeColor = Color.FromArgb(34, 197, 94);
            lblDoneCol.Name = "lblDoneCol";
            lblDoneCol.TabIndex = 2;
            lblDoneCol.Text = "HOÀN THÀNH";
            lblDoneCol.TextAlign = ContentAlignment.MiddleCenter;
            //
            // flpPendingOrders
            //
            flpPendingOrders.Dock = DockStyle.Fill;
            flpPendingOrders.Margin = new Padding(0, 0, 9, 0);
            flpPendingOrders.AutoScroll = true;
            flpPendingOrders.BackColor = Color.FromArgb(24, 24, 27);
            flpPendingOrders.FlowDirection = FlowDirection.TopDown;
            flpPendingOrders.Name = "flpPendingOrders";
            flpPendingOrders.Padding = new Padding(4);
            flpPendingOrders.TabIndex = 3;
            flpPendingOrders.WrapContents = false;
            //
            // flpInProgressOrders
            //
            flpInProgressOrders.Dock = DockStyle.Fill;
            flpInProgressOrders.Margin = new Padding(9, 0, 9, 0);
            flpInProgressOrders.AutoScroll = true;
            flpInProgressOrders.BackColor = Color.FromArgb(24, 24, 27);
            flpInProgressOrders.FlowDirection = FlowDirection.TopDown;
            flpInProgressOrders.Name = "flpInProgressOrders";
            flpInProgressOrders.Padding = new Padding(4);
            flpInProgressOrders.TabIndex = 4;
            flpInProgressOrders.WrapContents = false;
            //
            // flpDoneOrders
            //
            flpDoneOrders.Dock = DockStyle.Fill;
            flpDoneOrders.Margin = new Padding(9, 0, 0, 0);
            flpDoneOrders.AutoScroll = true;
            flpDoneOrders.BackColor = Color.FromArgb(24, 24, 27);
            flpDoneOrders.FlowDirection = FlowDirection.TopDown;
            flpDoneOrders.Name = "flpDoneOrders";
            flpDoneOrders.Padding = new Padding(4);
            flpDoneOrders.TabIndex = 5;
            flpDoneOrders.WrapContents = false;
            // 
            // ucKDS_Barista
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(39, 39, 42);
            Controls.Add(pnlHeader);
            Controls.Add(pnlOrders);
            Name = "ucKDS_Barista";
            Size = new Size(1000, 665);
            Load += UcKDS_Barista_Load;
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            pnlOrders.ResumeLayout(false);
            tblCols.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Guna2Panel pnlHeader;
        private Label lblTitle;
        private Label lblPending;
        private Label lblInProgress;
        private Label lblDone;
        private Guna2Panel pnlOrders;
        private TableLayoutPanel tblCols;
        private Label lblPendingCol;
        private Label lblInProgressCol;
        private Label lblDoneCol;
        private FlowLayoutPanel flpPendingOrders;
        private FlowLayoutPanel flpInProgressOrders;
        private FlowLayoutPanel flpDoneOrders;
    }
}
