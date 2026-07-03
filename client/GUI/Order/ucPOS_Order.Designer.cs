using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace GUI
{
    partial class ucPOS_Order
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
            pnlSubTabs = new Guna2Panel();
            btnTabOrder = new Guna2Button();
            btnTabTables = new Guna2Button();
            btnTabHistory = new Guna2Button();
            btnReport = new Guna2Button();
            pnlMainTabContainer = new Guna2Panel();
            pnlCenterMenu = new Guna2Panel();
            flpProducts = new FlowLayoutPanel();
            pnlRightBill = new Guna2Panel();
            pnlStaffInfo = new Guna2Panel();
            lblCurrentStaff = new Label();
            lblOrderTitle = new Label();
            dgvCurrentOrder = new Guna2DataGridView();
            colOrderItem = new DataGridViewTextBoxColumn();
            colOrderQty = new DataGridViewTextBoxColumn();
            colOrderPrice = new DataGridViewTextBoxColumn();
            colOrderTotal = new DataGridViewTextBoxColumn();
            pnlBillFooter = new Guna2Panel();
            lblTotalTitle = new Label();
            lblTotalAmount = new Label();
            lblDiscountTitle = new Label();
            txtDiscount = new Guna2TextBox();
            btnVoidOrder = new Guna2Button();
            btnPay = new Guna2Button();
            pnlSubTabs.SuspendLayout();
            pnlMainTabContainer.SuspendLayout();
            pnlCenterMenu.SuspendLayout();
            pnlRightBill.SuspendLayout();
            pnlStaffInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCurrentOrder).BeginInit();
            pnlBillFooter.SuspendLayout();
            SuspendLayout();

            // ====== pnlSubTabs ======
            pnlSubTabs.BackColor = Color.FromArgb(31, 31, 34);
            pnlSubTabs.BorderRadius = 14;
            pnlSubTabs.Controls.Add(btnTabOrder);
            pnlSubTabs.Controls.Add(btnTabTables);
            pnlSubTabs.Controls.Add(btnTabHistory);
            pnlSubTabs.Controls.Add(btnReport);
            pnlSubTabs.Location = new Point(15, 15);
            pnlSubTabs.Size = new Size(970, 55);
            pnlSubTabs.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

            btnTabOrder.BorderRadius = 8;
            btnTabOrder.Cursor = Cursors.Hand;
            btnTabOrder.FillColor = Color.FromArgb(31, 138, 154);
            btnTabOrder.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnTabOrder.ForeColor = Color.White;
            btnTabOrder.HoverState.FillColor = Color.FromArgb(45, 158, 174);
            btnTabOrder.Location = new Point(12, 12);
            btnTabOrder.Size = new Size(110, 32);
            btnTabOrder.Text = "Order";

            btnTabTables.BorderColor = Color.FromArgb(63, 63, 70);
            btnTabTables.BorderRadius = 8;
            btnTabTables.BorderThickness = 1;
            btnTabTables.Cursor = Cursors.Hand;
            btnTabTables.FillColor = Color.FromArgb(31, 31, 34);
            btnTabTables.Font = new Font("Segoe UI", 9.5F);
            btnTabTables.ForeColor = Color.White;
            btnTabTables.HoverState.BorderColor = Color.FromArgb(120, 120, 130);
            btnTabTables.HoverState.FillColor = Color.FromArgb(45, 45, 48);
            btnTabTables.Location = new Point(128, 12);
            btnTabTables.Size = new Size(120, 32);
            btnTabTables.Text = "Sơ đồ bàn";
            btnTabTables.Click += btnTabTables_Click;

            btnTabHistory.BorderColor = Color.FromArgb(63, 63, 70);
            btnTabHistory.BorderRadius = 8;
            btnTabHistory.BorderThickness = 1;
            btnTabHistory.Cursor = Cursors.Hand;
            btnTabHistory.FillColor = Color.FromArgb(31, 31, 34);
            btnTabHistory.Font = new Font("Segoe UI", 9.5F);
            btnTabHistory.ForeColor = Color.White;
            btnTabHistory.HoverState.BorderColor = Color.FromArgb(120, 120, 130);
            btnTabHistory.HoverState.FillColor = Color.FromArgb(45, 45, 48);
            btnTabHistory.Location = new Point(254, 12);
            btnTabHistory.Size = new Size(110, 32);
            btnTabHistory.Text = "Lịch sử";
            btnTabHistory.Click += btnTabHistory_Click;

            btnReport.BorderRadius = 8;
            btnReport.Cursor = Cursors.Hand;
            btnReport.FillColor = Color.FromArgb(70, 130, 180);
            btnReport.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnReport.ForeColor = Color.White;
            btnReport.HoverState.FillColor = Color.FromArgb(90, 150, 200);
            btnReport.Location = new Point(370, 12);
            btnReport.Size = new Size(95, 32);
            btnReport.Text = "Báo cáo";

            // ====== pnlMainTabContainer ======
            pnlMainTabContainer.BackColor = Color.FromArgb(31, 31, 34);
            pnlMainTabContainer.BorderRadius = 14;
            pnlMainTabContainer.Controls.Add(pnlCenterMenu);
            pnlMainTabContainer.Location = new Point(15, 80);
            pnlMainTabContainer.Size = new Size(670, 570);
            pnlMainTabContainer.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            // ====== pnlCenterMenu ======
            pnlCenterMenu.BackColor = Color.FromArgb(31, 31, 34);
            pnlCenterMenu.BorderRadius = 14;
            pnlCenterMenu.Controls.Add(flpProducts);
            pnlCenterMenu.Dock = DockStyle.Fill;
            pnlCenterMenu.Location = new Point(0, 0);
            pnlCenterMenu.Size = new Size(475, 435);

            flpProducts.AutoScroll = true;
            flpProducts.BackColor = Color.Transparent;
            flpProducts.Dock = DockStyle.Fill;
            flpProducts.Location = new Point(0, 0);
            flpProducts.Padding = new Padding(12);
            flpProducts.Size = new Size(475, 435);

            // ====== pnlRightBill ======
            pnlRightBill.BackColor = Color.FromArgb(31, 31, 34);
            pnlRightBill.BorderRadius = 14;
            pnlRightBill.Controls.Add(pnlStaffInfo);
            pnlRightBill.Controls.Add(lblOrderTitle);
            pnlRightBill.Controls.Add(dgvCurrentOrder);
            pnlRightBill.Controls.Add(pnlBillFooter);
            pnlRightBill.Location = new Point(700, 15);
            pnlRightBill.Size = new Size(285, 635);
            pnlRightBill.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;

            // -- pnlStaffInfo --
            pnlStaffInfo.BackColor = Color.FromArgb(24, 24, 27);
            pnlStaffInfo.BorderRadius = 8;
            pnlStaffInfo.Controls.Add(lblCurrentStaff);
            pnlStaffInfo.Location = new Point(12, 12);
            pnlStaffInfo.Size = new Size(261, 30);
            pnlStaffInfo.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

            lblCurrentStaff.AutoSize = true;
            lblCurrentStaff.Font = new Font("Segoe UI", 9F);
            lblCurrentStaff.ForeColor = Color.FromArgb(160, 160, 166);
            lblCurrentStaff.Location = new Point(10, 7);
            lblCurrentStaff.Text = "Nhân viên: [Hệ thống tự nạp]";

            lblOrderTitle.AutoSize = true;
            lblOrderTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblOrderTitle.ForeColor = Color.White;
            lblOrderTitle.Location = new Point(12, 52);
            lblOrderTitle.Text = "Đơn hàng hiện tại";

            // -- dgvCurrentOrder --
            dgvCurrentOrder.BackgroundColor = Color.FromArgb(24, 24, 27);
            dgvCurrentOrder.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(31, 31, 34);
            dgvCurrentOrder.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(160, 160, 166);
            dgvCurrentOrder.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dgvCurrentOrder.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(31, 31, 34);
            dgvCurrentOrder.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.FromArgb(160, 160, 166);
            dgvCurrentOrder.DefaultCellStyle.BackColor = Color.FromArgb(24, 24, 27);
            dgvCurrentOrder.DefaultCellStyle.ForeColor = Color.FromArgb(220, 220, 225);
            dgvCurrentOrder.DefaultCellStyle.SelectionBackColor = Color.FromArgb(31, 138, 154);
            dgvCurrentOrder.DefaultCellStyle.SelectionForeColor = Color.FromArgb(240, 240, 245);
            dgvCurrentOrder.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(24, 24, 27);
            dgvCurrentOrder.AlternatingRowsDefaultCellStyle.ForeColor = Color.FromArgb(220, 220, 225);
            dgvCurrentOrder.GridColor = Color.FromArgb(45, 45, 48);
            ConfigureGrid(dgvCurrentOrder);            dgvCurrentOrder.Columns.AddRange(new DataGridViewColumn[] { colOrderItem, colOrderQty, colOrderPrice, colOrderTotal });
            colOrderItem.HeaderText = "Món"; colOrderItem.Name = "Món"; colOrderItem.DataPropertyName = "Món";
            colOrderQty.HeaderText = "SL"; colOrderQty.Name = "SL"; colOrderQty.DataPropertyName = "SL";
            colOrderPrice.HeaderText = "Đơn giá"; colOrderPrice.Name = "Đơn giá"; colOrderPrice.DataPropertyName = "Đơn giá";
            colOrderTotal.HeaderText = "Thành tiền"; colOrderTotal.Name = "Thành tiền"; colOrderTotal.DataPropertyName = "Thành tiền";
            dgvCurrentOrder.Location = new Point(12, 82);
            dgvCurrentOrder.Size = new Size(261, 365);
            dgvCurrentOrder.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            // -- pnlBillFooter --
            pnlBillFooter.BackColor = Color.FromArgb(24, 24, 27);
            pnlBillFooter.BorderRadius = 10;
            pnlBillFooter.Controls.Add(lblTotalTitle);
            pnlBillFooter.Controls.Add(lblTotalAmount);
            pnlBillFooter.Controls.Add(lblDiscountTitle);
            pnlBillFooter.Controls.Add(txtDiscount);
            pnlBillFooter.Controls.Add(btnVoidOrder);
            pnlBillFooter.Controls.Add(btnPay);
            pnlBillFooter.Location = new Point(12, 455);
            pnlBillFooter.Size = new Size(261, 168);
            pnlBillFooter.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            lblTotalTitle.AutoSize = true;
            lblTotalTitle.Font = new Font("Segoe UI", 9.5F);
            lblTotalTitle.ForeColor = Color.FromArgb(160, 160, 166);
            lblTotalTitle.Location = new Point(12, 12);
            lblTotalTitle.Text = "Tổng cộng";

            lblTotalAmount.AutoSize = true;
            lblTotalAmount.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            lblTotalAmount.ForeColor = Color.FromArgb(34, 197, 94);
            lblTotalAmount.Location = new Point(12, 30);
            lblTotalAmount.Text = "0 đ";

            lblDiscountTitle.AutoSize = true;
            lblDiscountTitle.Font = new Font("Segoe UI", 9F);
            lblDiscountTitle.ForeColor = Color.FromArgb(160, 160, 166);
            lblDiscountTitle.Location = new Point(12, 70);
            lblDiscountTitle.Text = "Giảm giá:";

            txtDiscount.BorderColor = Color.FromArgb(63, 63, 70);
            txtDiscount.BorderRadius = 8;
            txtDiscount.DefaultText = "";
            txtDiscount.FillColor = Color.FromArgb(30, 30, 33);
            txtDiscount.FocusedState.BorderColor = Color.FromArgb(31, 138, 154);
            txtDiscount.Font = new Font("Segoe UI", 9.5F);
            txtDiscount.ForeColor = Color.White;
            txtDiscount.HoverState.BorderColor = Color.FromArgb(120, 120, 130);
            txtDiscount.Location = new Point(82, 66);
            txtDiscount.PlaceholderForeColor = Color.FromArgb(110, 110, 120);
            txtDiscount.PlaceholderText = "0";
            txtDiscount.Size = new Size(165, 28);

            btnVoidOrder.BorderColor = Color.FromArgb(180, 60, 60);
            btnVoidOrder.BorderRadius = 10;
            btnVoidOrder.BorderThickness = 1;
            btnVoidOrder.Cursor = Cursors.Hand;
            btnVoidOrder.FillColor = Color.Transparent;
            btnVoidOrder.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnVoidOrder.ForeColor = Color.FromArgb(220, 80, 80);
            btnVoidOrder.HoverState.FillColor = Color.FromArgb(180, 60, 60);
            btnVoidOrder.HoverState.ForeColor = Color.White;
            btnVoidOrder.Location = new Point(12, 110);
            btnVoidOrder.Size = new Size(100, 38);
            btnVoidOrder.Text = "Hủy đơn";

            btnPay.BorderRadius = 10;
            btnPay.Cursor = Cursors.Hand;
            btnPay.FillColor = Color.FromArgb(31, 138, 154);
            btnPay.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnPay.ForeColor = Color.White;
            btnPay.HoverState.FillColor = Color.FromArgb(45, 158, 174);
            btnPay.Location = new Point(116, 110);
            btnPay.Size = new Size(133, 38);
            btnPay.Text = "Thanh toán";

            // ====== ucPOS_Order ======
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(39, 39, 42);
            Controls.Add(pnlSubTabs);
            Controls.Add(pnlMainTabContainer);
            Controls.Add(pnlRightBill);
            Name = "ucPOS_Order";
            Size = new Size(1000, 665);
            pnlSubTabs.ResumeLayout(false);
            pnlMainTabContainer.ResumeLayout(false);
            pnlCenterMenu.ResumeLayout(false);
            pnlRightBill.ResumeLayout(false);
            pnlRightBill.PerformLayout();
            pnlStaffInfo.ResumeLayout(false);
            pnlStaffInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCurrentOrder).EndInit();
            pnlBillFooter.ResumeLayout(false);
            pnlBillFooter.PerformLayout();
            btnPay.Click += BtnPay_Click;
            btnVoidOrder.Click += BtnVoidOrder_Click;
            btnTabOrder.Click += BtnTabOrder_Click;
            btnReport.Click += BtnReport_Click;
            txtDiscount.TextChanged += TxtDiscount_TextChanged;
            ResumeLayout(false);
        }

        private static void ConfigureGrid(Guna2DataGridView dgv)
        {
            dgv.AutoGenerateColumns = false;
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToResizeRows = false;
            dgv.BackgroundColor = Color.FromArgb(24, 24, 27);
            dgv.BorderStyle = BorderStyle.None;
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgv.ColumnHeadersHeight = 32;
            dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(31, 31, 34);
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(160, 160, 166);
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dgv.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(31, 31, 34);
            dgv.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.FromArgb(160, 160, 166);
            dgv.DefaultCellStyle.BackColor = Color.FromArgb(24, 24, 27);
            dgv.DefaultCellStyle.ForeColor = Color.FromArgb(220, 220, 225);
            dgv.DefaultCellStyle.Font = new Font("Segoe UI", 9F);
            dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(31, 138, 154);
            dgv.DefaultCellStyle.SelectionForeColor = Color.FromArgb(240, 240, 245);
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(24, 24, 27);
            dgv.AlternatingRowsDefaultCellStyle.ForeColor = Color.FromArgb(220, 220, 225);
            dgv.AlternatingRowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(31, 138, 154);
            dgv.AlternatingRowsDefaultCellStyle.SelectionForeColor = Color.FromArgb(240, 240, 245);
            dgv.EnableHeadersVisualStyles = false;
            dgv.GridColor = Color.FromArgb(45, 45, 48);
            dgv.MultiSelect = false;
            dgv.ReadOnly = true;
            dgv.RowHeadersVisible = false;
            dgv.RowTemplate.Height = 28;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DgvDarkScroll.Apply(dgv);
        }

        #endregion

        private Guna2Panel pnlSubTabs;
        private Guna2Button btnTabOrder;
        private Guna2Button btnTabTables;
        private Guna2Button btnTabHistory;
        private Guna2Button btnReport;
        private Guna2Panel pnlMainTabContainer;
        private Guna2Panel pnlCenterMenu;
        private FlowLayoutPanel flpProducts;
        private Guna2Panel pnlRightBill;
        private Guna2Panel pnlStaffInfo;
        private Label lblCurrentStaff;
        private Label lblOrderTitle;
        private Guna2DataGridView dgvCurrentOrder;
        private DataGridViewTextBoxColumn colOrderItem;
        private DataGridViewTextBoxColumn colOrderQty;
        private DataGridViewTextBoxColumn colOrderPrice;
        private DataGridViewTextBoxColumn colOrderTotal;
        private Guna2Panel pnlBillFooter;
        private Label lblTotalTitle;
        private Label lblTotalAmount;
        private Label lblDiscountTitle;
        private Guna2TextBox txtDiscount;
        private Guna2Button btnVoidOrder;
        private Guna2Button btnPay;
    }
}
