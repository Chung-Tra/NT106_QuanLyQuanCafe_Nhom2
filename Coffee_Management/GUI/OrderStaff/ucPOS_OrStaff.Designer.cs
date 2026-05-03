namespace GUI
{
    partial class ucPOS_OrStaff
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pnlSubTabs = new Panel();
            btnReport = new Button();
            btnTabHistory = new Button();
            btnTabTables = new Button();
            btnTabOrder = new Button();
            pnlMainTabContainer = new Panel();
            pnlCenterMenu = new Panel();
            flpProducts = new FlowLayoutPanel();
            pnlRightBill = new Panel();
            pnlStaffInfo = new Panel();
            lblCurrentStaff = new Label();
            dgvCurrentOrder = new DataGridView();
            pnlBillFooter = new Panel();
            btnVoidOrder = new Button();
            txtDiscount = new TextBox();
            lblDiscountTitle = new Label();
            btnPay = new Button();
            lblTotalAmount = new Label();
            lblTotalTitle = new Label();
            lblOrderTitle = new Label();
            pnlSubTabs.SuspendLayout();
            pnlMainTabContainer.SuspendLayout();
            pnlCenterMenu.SuspendLayout();
            pnlRightBill.SuspendLayout();
            pnlStaffInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCurrentOrder).BeginInit();
            pnlBillFooter.SuspendLayout();
            SuspendLayout();
            // 
            // pnlSubTabs
            // 
            pnlSubTabs.BackColor = Color.FromArgb(25, 25, 25);
            pnlSubTabs.Controls.Add(btnTabOrder);
            pnlSubTabs.Controls.Add(btnTabHistory);
            pnlSubTabs.Controls.Add(btnTabTables);
            pnlSubTabs.Controls.Add(btnReport);
            pnlSubTabs.Dock = DockStyle.Top;
            pnlSubTabs.Location = new Point(0, 0);
            pnlSubTabs.Name = "pnlSubTabs";
            pnlSubTabs.Size = new Size(504, 40);
            pnlSubTabs.TabIndex = 3;
            // 
            // btnTabHistory
            // 
            btnTabHistory.FlatAppearance.BorderSize = 0;
            btnTabHistory.FlatStyle = FlatStyle.Flat;
            btnTabHistory.Font = new Font("Segoe UI", 10F);
            btnTabHistory.ForeColor = Color.White;
            btnTabHistory.Location = new Point(252, 0);
            btnTabHistory.Name = "btnTabHistory";
            btnTabHistory.Size = new Size(120, 40);
            btnTabHistory.TabIndex = 0;
            btnTabHistory.Text = "📜 LỊCH SỬ";
            btnTabHistory.UseVisualStyleBackColor = true;
            btnTabHistory.Click += btnTabHistory_Click;
            //
            // btnReport
            //
            btnReport.BackColor = Color.FromArgb(70, 130, 180);
            btnReport.Cursor = Cursors.Hand;
            btnReport.FlatAppearance.BorderSize = 0;
            btnReport.FlatStyle = FlatStyle.Flat;
            btnReport.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnReport.ForeColor = Color.White;
            btnReport.Location = new Point(400, 5);
            btnReport.Name = "btnReport";
            btnReport.Size = new Size(90, 30);
            btnReport.Text = "Báo cáo";
            // 
            // btnTabTables
            // 
            btnTabTables.FlatAppearance.BorderSize = 0;
            btnTabTables.FlatStyle = FlatStyle.Flat;
            btnTabTables.Font = new Font("Segoe UI", 10F);
            btnTabTables.ForeColor = Color.White;
            btnTabTables.Location = new Point(126, -3);
            btnTabTables.Name = "btnTabTables";
            btnTabTables.Size = new Size(120, 40);
            btnTabTables.TabIndex = 1;
            btnTabTables.Text = "\U0001fa91 SƠ ĐỒ BÀN";
            btnTabTables.UseVisualStyleBackColor = true;
            btnTabTables.Click += btnTabTables_Click;
            // 
            // btnTabOrder
            // 
            btnTabOrder.FlatAppearance.BorderSize = 0;
            btnTabOrder.FlatStyle = FlatStyle.Flat;
            btnTabOrder.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnTabOrder.ForeColor = Color.MediumSeaGreen;
            btnTabOrder.Location = new Point(0, -3);
            btnTabOrder.Name = "btnTabOrder";
            btnTabOrder.Size = new Size(120, 40);
            btnTabOrder.TabIndex = 2;
            btnTabOrder.Text = "📝 ORDER";
            btnTabOrder.UseVisualStyleBackColor = true;
            // 
            // pnlMainTabContainer
            // 
            pnlMainTabContainer.Controls.Add(pnlCenterMenu);
            pnlMainTabContainer.Dock = DockStyle.Fill;
            pnlMainTabContainer.Location = new Point(0, 40);
            pnlMainTabContainer.Name = "pnlMainTabContainer";
            pnlMainTabContainer.Size = new Size(504, 490);
            pnlMainTabContainer.TabIndex = 4;
            // 
            // pnlCenterMenu
            // 
            pnlCenterMenu.BackColor = Color.FromArgb(45, 45, 48);
            pnlCenterMenu.Controls.Add(flpProducts);
            pnlCenterMenu.Dock = DockStyle.Fill;
            pnlCenterMenu.Location = new Point(0, 0);
            pnlCenterMenu.Name = "pnlCenterMenu";
            pnlCenterMenu.Size = new Size(504, 490);
            pnlCenterMenu.TabIndex = 1;
            // 
            // flpProducts
            // 
            flpProducts.AutoScroll = true;
            flpProducts.Dock = DockStyle.Fill;
            flpProducts.Location = new Point(0, 0);
            flpProducts.Name = "flpProducts";
            flpProducts.Padding = new Padding(10);
            flpProducts.Size = new Size(504, 490);
            flpProducts.TabIndex = 0;
            // 
            // pnlRightBill
            // 
            pnlRightBill.BackColor = Color.FromArgb(35, 35, 35);
            pnlRightBill.Controls.Add(pnlStaffInfo);
            pnlRightBill.Controls.Add(dgvCurrentOrder);
            pnlRightBill.Controls.Add(pnlBillFooter);
            pnlRightBill.Controls.Add(lblOrderTitle);
            pnlRightBill.Dock = DockStyle.Right;
            pnlRightBill.Location = new Point(504, 0);
            pnlRightBill.Name = "pnlRightBill";
            pnlRightBill.Size = new Size(300, 530);
            pnlRightBill.TabIndex = 2;
            // 
            // pnlStaffInfo
            // 
            pnlStaffInfo.BackColor = Color.FromArgb(25, 25, 25);
            pnlStaffInfo.Controls.Add(lblCurrentStaff);
            pnlStaffInfo.Dock = DockStyle.Top;
            pnlStaffInfo.Location = new Point(0, 0);
            pnlStaffInfo.Name = "pnlStaffInfo";
            pnlStaffInfo.Size = new Size(300, 30);
            pnlStaffInfo.TabIndex = 0;
            // 
            // lblCurrentStaff
            // 
            lblCurrentStaff.AutoSize = true;
            lblCurrentStaff.ForeColor = Color.DarkGray;
            lblCurrentStaff.Location = new Point(10, 5);
            lblCurrentStaff.Name = "lblCurrentStaff";
            lblCurrentStaff.Size = new Size(162, 15);
            lblCurrentStaff.TabIndex = 0;
            lblCurrentStaff.Text = "Nhân viên: [Hệ thống tự nạp]";
            // 
            // dgvCurrentOrder
            // 
            dgvCurrentOrder.BackgroundColor = Color.FromArgb(45, 45, 48);
            dgvCurrentOrder.BorderStyle = BorderStyle.None;
            dgvCurrentOrder.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCurrentOrder.Location = new Point(5, 80);
            dgvCurrentOrder.Name = "dgvCurrentOrder";
            dgvCurrentOrder.Size = new Size(290, 260);
            dgvCurrentOrder.TabIndex = 1;
            // 
            // pnlBillFooter
            // 
            pnlBillFooter.Controls.Add(btnVoidOrder);
            pnlBillFooter.Controls.Add(txtDiscount);
            pnlBillFooter.Controls.Add(lblDiscountTitle);
            pnlBillFooter.Controls.Add(btnPay);
            pnlBillFooter.Controls.Add(lblTotalAmount);
            pnlBillFooter.Controls.Add(lblTotalTitle);
            pnlBillFooter.Dock = DockStyle.Bottom;
            pnlBillFooter.Location = new Point(0, 350);
            pnlBillFooter.Name = "pnlBillFooter";
            pnlBillFooter.Size = new Size(300, 180);
            pnlBillFooter.TabIndex = 2;
            // 
            // btnVoidOrder
            // 
            btnVoidOrder.FlatStyle = FlatStyle.Flat;
            btnVoidOrder.ForeColor = Color.IndianRed;
            btnVoidOrder.Location = new Point(15, 140);
            btnVoidOrder.Name = "btnVoidOrder";
            btnVoidOrder.Size = new Size(80, 25);
            btnVoidOrder.TabIndex = 0;
            btnVoidOrder.Text = "Hủy Đơn 🗑";
            // 
            // txtDiscount
            // 
            txtDiscount.Location = new Point(0, -4);
            txtDiscount.Name = "txtDiscount";
            txtDiscount.Size = new Size(100, 23);
            txtDiscount.TabIndex = 1;
            // 
            // lblDiscountTitle
            // 
            lblDiscountTitle.Location = new Point(0, 0);
            lblDiscountTitle.Name = "lblDiscountTitle";
            lblDiscountTitle.Size = new Size(100, 23);
            lblDiscountTitle.TabIndex = 2;
            // 
            // btnPay
            // 
            btnPay.Location = new Point(0, 0);
            btnPay.Name = "btnPay";
            btnPay.Size = new Size(75, 23);
            btnPay.TabIndex = 3;
            // 
            // lblTotalAmount
            // 
            lblTotalAmount.Location = new Point(0, 0);
            lblTotalAmount.Name = "lblTotalAmount";
            lblTotalAmount.Size = new Size(100, 23);
            lblTotalAmount.TabIndex = 4;
            // 
            // lblTotalTitle
            // 
            lblTotalTitle.Location = new Point(0, 0);
            lblTotalTitle.Name = "lblTotalTitle";
            lblTotalTitle.Size = new Size(100, 23);
            lblTotalTitle.TabIndex = 5;
            // 
            // lblOrderTitle
            // 
            lblOrderTitle.Location = new Point(0, 0);
            lblOrderTitle.Name = "lblOrderTitle";
            lblOrderTitle.Size = new Size(100, 23);
            lblOrderTitle.TabIndex = 3;
            // 
            // ucPOS_OrStaff
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(45, 45, 48);
            Controls.Add(pnlMainTabContainer);
            Controls.Add(pnlSubTabs);
            Controls.Add(pnlRightBill);
            Name = "ucPOS_OrStaff";
            Size = new Size(804, 530);
            pnlSubTabs.ResumeLayout(false);
            pnlMainTabContainer.ResumeLayout(false);
            pnlCenterMenu.ResumeLayout(false);
            pnlRightBill.ResumeLayout(false);
            pnlStaffInfo.ResumeLayout(false);
            pnlStaffInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCurrentOrder).EndInit();
            pnlBillFooter.ResumeLayout(false);
            pnlBillFooter.PerformLayout();
            ResumeLayout(false);
        }
        #endregion
        private Panel pnlSubTabs;
        private Button btnTabOrder;
        private Button btnTabTables;
        private Button btnTabHistory;
        private Panel pnlMainTabContainer;
        private Panel pnlCenterMenu;
        private Panel pnlRightBill;
        private FlowLayoutPanel flpProducts;
        private Label lblOrderTitle;
        private DataGridView dgvCurrentOrder;
        private Panel pnlBillFooter;
        private Button btnPay;
        private Label lblTotalAmount;
        private Label lblTotalTitle;
        private TextBox txtDiscount;
        private Label lblDiscountTitle;
        private Panel pnlStaffInfo;
        private Label lblCurrentStaff;
        private Button btnVoidOrder;
        private Button btnReport;
    }
}