using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace GUI
{
    partial class ucSelfOrder_Order
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
            lblTitle = new Label();
            lblSub = new Label();
            pnlQRCard = new Guna2Panel();
            lblQRPrompt = new Label();
            _cmbTable = new Guna2ComboBox();
            _pnlQR = new Panel();
            lblQRTable = new Label();
            lblQRUrl = new Label();
            btnPrint = new Guna2Button();
            pnlIncomingCard = new Guna2Panel();
            lblIncomingTitle = new Label();
            _lblIncomingCount = new Label();
            lblLive = new Label();
            btnSim = new Guna2Button();
            pnlDgvHost = new Panel();
            _dgvIncoming = new Guna2DataGridView();
            colTime = new DataGridViewTextBoxColumn();
            colTable = new DataGridViewTextBoxColumn();
            colItem = new DataGridViewTextBoxColumn();
            colQty = new DataGridViewTextBoxColumn();
            colStatus = new DataGridViewTextBoxColumn();
            pnlBanner = new Guna2Panel();
            lblBanner = new Label();
            pnlQRCard.SuspendLayout();
            pnlIncomingCard.SuspendLayout();
            pnlDgvHost.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_dgvIncoming).BeginInit();
            pnlBanner.SuspendLayout();
            SuspendLayout();
            //
            // lblTitle
            //
            lblTitle.AutoSize = true;
            lblTitle.BackColor = Color.Transparent;
            lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(240, 240, 245);
            lblTitle.Location = new Point(20, 20);
            lblTitle.Name = "lblTitle";
            lblTitle.Text = "Đặt món tại bàn — QR Self-Order";
            //
            // lblSub
            //
            lblSub.AutoSize = true;
            lblSub.BackColor = Color.Transparent;
            lblSub.Font = new Font("Segoe UI", 9F);
            lblSub.ForeColor = Color.FromArgb(160, 160, 166);
            lblSub.Location = new Point(22, 46);
            lblSub.Name = "lblSub";
            lblSub.Text = "Khách quét QR tại bàn → đơn hiện về POS realtime · SignalR /hubs/pos";
            //
            // pnlQRCard
            //
            pnlQRCard.BackColor = Color.Transparent;
            pnlQRCard.BorderRadius = 14;
            pnlQRCard.Controls.Add(lblQRPrompt);
            pnlQRCard.Controls.Add(_cmbTable);
            pnlQRCard.Controls.Add(_pnlQR);
            pnlQRCard.Controls.Add(lblQRTable);
            pnlQRCard.Controls.Add(lblQRUrl);
            pnlQRCard.Controls.Add(btnPrint);
            pnlQRCard.FillColor = Color.FromArgb(31, 31, 34);
            pnlQRCard.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            pnlQRCard.Location = new Point(16, 70);
            pnlQRCard.Name = "pnlQRCard";
            pnlQRCard.Size = new Size(340, 511);
            pnlQRCard.TabIndex = 0;
            //
            // lblQRPrompt
            //
            lblQRPrompt.AutoSize = true;
            lblQRPrompt.BackColor = Color.Transparent;
            lblQRPrompt.Font = new Font("Segoe UI", 9.5F);
            lblQRPrompt.ForeColor = Color.FromArgb(160, 160, 166);
            lblQRPrompt.Location = new Point(14, 16);
            lblQRPrompt.Name = "lblQRPrompt";
            lblQRPrompt.Text = "Hiển thị QR cho bàn:";
            //
            // _cmbTable
            //
            _cmbTable.BorderColor = Color.FromArgb(63, 63, 70);
            _cmbTable.BorderRadius = 8;
            _cmbTable.DrawMode = DrawMode.OwnerDrawFixed;
            _cmbTable.DropDownStyle = ComboBoxStyle.DropDownList;
            _cmbTable.FillColor = Color.FromArgb(24, 24, 27);
            _cmbTable.Font = new Font("Segoe UI", 9.5F);
            _cmbTable.ForeColor = Color.FromArgb(220, 220, 225);
            _cmbTable.ItemHeight = 30;
            _cmbTable.Location = new Point(14, 44);
            _cmbTable.Name = "_cmbTable";
            _cmbTable.Size = new Size(200, 36);
            _cmbTable.TabIndex = 0;
            //
            // _pnlQR
            //
            _pnlQR.BackColor = Color.White;
            _pnlQR.Location = new Point(50, 94);
            _pnlQR.Name = "_pnlQR";
            _pnlQR.Size = new Size(240, 240);
            _pnlQR.TabIndex = 1;
            //
            // lblQRTable
            //
            lblQRTable.AutoSize = true;
            lblQRTable.BackColor = Color.Transparent;
            lblQRTable.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblQRTable.ForeColor = Color.FromArgb(220, 220, 225);
            lblQRTable.Location = new Point(100, 344);
            lblQRTable.Name = "lblQRTable";
            lblQRTable.Text = "Bàn:";
            //
            // lblQRUrl
            //
            lblQRUrl.AutoSize = true;
            lblQRUrl.BackColor = Color.Transparent;
            lblQRUrl.Font = new Font("Segoe UI", 8F);
            lblQRUrl.ForeColor = Color.FromArgb(160, 160, 166);
            lblQRUrl.Location = new Point(60, 368);
            lblQRUrl.Name = "lblQRUrl";
            lblQRUrl.Text = "cafe.vn/order?table=...";
            //
            // btnPrint
            //
            btnPrint.BorderColor = Color.FromArgb(63, 63, 70);
            btnPrint.BorderRadius = 10;
            btnPrint.BorderThickness = 1;
            btnPrint.Cursor = Cursors.Hand;
            btnPrint.FillColor = Color.Transparent;
            btnPrint.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnPrint.ForeColor = Color.FromArgb(220, 220, 225);
            btnPrint.HoverState.BorderColor = Color.FromArgb(103, 103, 110);
            btnPrint.HoverState.FillColor = Color.FromArgb(45, 45, 50);
            btnPrint.Location = new Point(108, 400);
            btnPrint.Name = "btnPrint";
            btnPrint.Size = new Size(120, 34);
            btnPrint.TabIndex = 2;
            btnPrint.Text = "In QR";
            //
            // pnlIncomingCard
            //
            pnlIncomingCard.BackColor = Color.Transparent;
            pnlIncomingCard.BorderRadius = 14;
            pnlIncomingCard.Controls.Add(lblIncomingTitle);
            pnlIncomingCard.Controls.Add(_lblIncomingCount);
            pnlIncomingCard.Controls.Add(lblLive);
            pnlIncomingCard.Controls.Add(btnSim);
            pnlIncomingCard.Controls.Add(pnlDgvHost);
            pnlIncomingCard.FillColor = Color.FromArgb(31, 31, 34);
            pnlIncomingCard.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnlIncomingCard.Location = new Point(368, 70);
            pnlIncomingCard.Name = "pnlIncomingCard";
            pnlIncomingCard.Size = new Size(616, 511);
            pnlIncomingCard.TabIndex = 1;
            //
            // lblIncomingTitle
            //
            lblIncomingTitle.AutoSize = true;
            lblIncomingTitle.BackColor = Color.Transparent;
            lblIncomingTitle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblIncomingTitle.ForeColor = Color.FromArgb(240, 240, 245);
            lblIncomingTitle.Location = new Point(14, 14);
            lblIncomingTitle.Name = "lblIncomingTitle";
            lblIncomingTitle.Text = "Đơn vào realtime";
            //
            // _lblIncomingCount
            //
            _lblIncomingCount.AutoSize = true;
            _lblIncomingCount.BackColor = Color.Transparent;
            _lblIncomingCount.Font = new Font("Segoe UI", 9F);
            _lblIncomingCount.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _lblIncomingCount.ForeColor = Color.FromArgb(31, 138, 154);
            _lblIncomingCount.Location = new Point(418, 16);
            _lblIncomingCount.Name = "_lblIncomingCount";
            _lblIncomingCount.Text = "0 đơn hôm nay";
            //
            // lblLive
            //
            lblLive.AutoSize = true;
            lblLive.BackColor = Color.Transparent;
            lblLive.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            lblLive.ForeColor = Color.FromArgb(34, 197, 94);
            lblLive.Location = new Point(14, 46);
            lblLive.Name = "lblLive";
            lblLive.Text = "● LIVE";
            //
            // btnSim
            //
            btnSim.BorderRadius = 10;
            btnSim.Cursor = Cursors.Hand;
            btnSim.FillColor = Color.FromArgb(31, 138, 154);
            btnSim.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnSim.ForeColor = Color.White;
            btnSim.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSim.HoverState.FillColor = Color.FromArgb(47, 154, 170);
            btnSim.Location = new Point(420, 40);
            btnSim.Name = "btnSim";
            btnSim.Size = new Size(178, 34);
            btnSim.TabIndex = 0;
            btnSim.Text = "▶  Nhận đơn mới (test)";
            btnSim.Click += BtnSimulate_Click;
            //
            // pnlDgvHost
            //
            pnlDgvHost.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnlDgvHost.BackColor = Color.Transparent;
            pnlDgvHost.Controls.Add(_dgvIncoming);
            pnlDgvHost.Location = new Point(0, 86);
            pnlDgvHost.Name = "pnlDgvHost";
            pnlDgvHost.Size = new Size(616, 425);
            pnlDgvHost.TabIndex = 1;
            //
            // _dgvIncoming
            //            _dgvIncoming.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            _dgvIncoming.Columns.AddRange(new DataGridViewColumn[] { colTime, colTable, colItem, colQty, colStatus });
            colTime.HeaderText = "Thời gian"; colTime.Name = "Thời gian"; colTime.DataPropertyName = "Thời gian";
            colTable.HeaderText = "Bàn"; colTable.Name = "Bàn"; colTable.DataPropertyName = "Bàn";
            colItem.HeaderText = "Món đặt"; colItem.Name = "Món đặt"; colItem.DataPropertyName = "Món đặt";
            colQty.HeaderText = "SL"; colQty.Name = "SL"; colQty.DataPropertyName = "SL";
            colStatus.HeaderText = "Trạng thái"; colStatus.Name = "Trạng thái"; colStatus.DataPropertyName = "Trạng thái";
            _dgvIncoming.Dock = DockStyle.Fill;
            _dgvIncoming.Location = new Point(0, 0);
            _dgvIncoming.Name = "_dgvIncoming";
            _dgvIncoming.RowHeadersWidth = 51;
            _dgvIncoming.Size = new Size(616, 425);
            _dgvIncoming.TabIndex = 0;
            //
            // pnlBanner
            //
            pnlBanner.BackColor = Color.Transparent;
            pnlBanner.BorderRadius = 14;
            pnlBanner.Controls.Add(lblBanner);
            pnlBanner.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnlBanner.FillColor = Color.FromArgb(31, 47, 39);
            pnlBanner.Location = new Point(16, 597);
            pnlBanner.Name = "pnlBanner";
            pnlBanner.Size = new Size(968, 48);
            pnlBanner.TabIndex = 2;
            //
            // lblBanner
            //
            lblBanner.AutoSize = true;
            lblBanner.BackColor = Color.Transparent;
            lblBanner.Font = new Font("Segoe UI", 9F);
            lblBanner.ForeColor = Color.FromArgb(34, 197, 94);
            lblBanner.Location = new Point(14, 15);
            lblBanner.Name = "lblBanner";
            lblBanner.Text = "SignalR Hub đã kết nối · Lắng nghe sự kiện 'NewSelfOrder' từ /hubs/pos";
            //
            // ucSelfOrder_Order
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(39, 39, 42);
            Controls.Add(lblTitle);
            Controls.Add(lblSub);
            Controls.Add(pnlQRCard);
            Controls.Add(pnlIncomingCard);
            Controls.Add(pnlBanner);
            Name = "ucSelfOrder_Order";
            Size = new Size(1000, 665);
            pnlQRCard.ResumeLayout(false);
            pnlQRCard.PerformLayout();
            pnlIncomingCard.ResumeLayout(false);
            pnlIncomingCard.PerformLayout();
            pnlDgvHost.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)_dgvIncoming).EndInit();
            pnlBanner.ResumeLayout(false);
            pnlBanner.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private Label lblSub;
        private Guna2Panel pnlQRCard;
        private Label lblQRPrompt;
        private Guna2ComboBox _cmbTable;
        private Panel _pnlQR;
        private Label lblQRTable;
        private Label lblQRUrl;
        private Guna2Button btnPrint;
        private Guna2Panel pnlIncomingCard;
        private Label lblIncomingTitle;
        private Label _lblIncomingCount;
        private Label lblLive;
        private Guna2Button btnSim;
        private Panel pnlDgvHost;
        private Guna2DataGridView _dgvIncoming;
        private DataGridViewTextBoxColumn colTime;
        private DataGridViewTextBoxColumn colTable;
        private DataGridViewTextBoxColumn colItem;
        private DataGridViewTextBoxColumn colQty;
        private DataGridViewTextBoxColumn colStatus;
        private Guna2Panel pnlBanner;
        private Label lblBanner;
    }
}
