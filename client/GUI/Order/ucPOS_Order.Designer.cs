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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges13 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges14 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges11 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges12 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges29 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges30 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges15 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges16 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges17 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges18 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges27 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges28 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges19 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges20 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges21 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges22 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges23 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges24 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges25 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges26 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
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
            btnTableBadge = new Guna2Button();
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
            btnSendKitchen = new Guna2Button();
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
            // 
            // pnlSubTabs
            // 
            pnlSubTabs.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlSubTabs.BackColor = Color.FromArgb(31, 31, 34);
            pnlSubTabs.BorderRadius = 14;
            pnlSubTabs.Controls.Add(btnTabOrder);
            pnlSubTabs.Controls.Add(btnTabTables);
            pnlSubTabs.Controls.Add(btnTabHistory);
            pnlSubTabs.Controls.Add(btnReport);
            pnlSubTabs.CustomizableEdges = customizableEdges9;
            pnlSubTabs.Location = new Point(15, 15);
            pnlSubTabs.Name = "pnlSubTabs";
            pnlSubTabs.ShadowDecoration.CustomizableEdges = customizableEdges10;
            pnlSubTabs.Size = new Size(970, 55);
            pnlSubTabs.TabIndex = 0;
            // 
            // btnTabOrder
            // 
            btnTabOrder.BorderRadius = 8;
            btnTabOrder.Cursor = Cursors.Hand;
            btnTabOrder.CustomizableEdges = customizableEdges1;
            btnTabOrder.FillColor = Color.FromArgb(31, 138, 154);
            btnTabOrder.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnTabOrder.ForeColor = Color.White;
            btnTabOrder.HoverState.FillColor = Color.FromArgb(45, 158, 174);
            btnTabOrder.Location = new Point(12, 12);
            btnTabOrder.Name = "btnTabOrder";
            btnTabOrder.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnTabOrder.Size = new Size(110, 32);
            btnTabOrder.TabIndex = 0;
            btnTabOrder.Text = "Order";
            btnTabOrder.Click += BtnTabOrder_Click;
            // 
            // btnTabTables
            // 
            btnTabTables.BorderColor = Color.FromArgb(63, 63, 70);
            btnTabTables.BorderRadius = 8;
            btnTabTables.BorderThickness = 1;
            btnTabTables.Cursor = Cursors.Hand;
            btnTabTables.CustomizableEdges = customizableEdges3;
            btnTabTables.FillColor = Color.FromArgb(31, 31, 34);
            btnTabTables.Font = new Font("Segoe UI", 9.5F);
            btnTabTables.ForeColor = Color.White;
            btnTabTables.HoverState.BorderColor = Color.FromArgb(120, 120, 130);
            btnTabTables.HoverState.FillColor = Color.FromArgb(45, 45, 48);
            btnTabTables.Location = new Point(128, 12);
            btnTabTables.Name = "btnTabTables";
            btnTabTables.ShadowDecoration.CustomizableEdges = customizableEdges4;
            btnTabTables.Size = new Size(120, 32);
            btnTabTables.TabIndex = 1;
            btnTabTables.Text = "Sơ đồ bàn";
            btnTabTables.Click += btnTabTables_Click;
            // 
            // btnTabHistory
            // 
            btnTabHistory.BorderColor = Color.FromArgb(63, 63, 70);
            btnTabHistory.BorderRadius = 8;
            btnTabHistory.BorderThickness = 1;
            btnTabHistory.Cursor = Cursors.Hand;
            btnTabHistory.CustomizableEdges = customizableEdges5;
            btnTabHistory.FillColor = Color.FromArgb(31, 31, 34);
            btnTabHistory.Font = new Font("Segoe UI", 9.5F);
            btnTabHistory.ForeColor = Color.White;
            btnTabHistory.HoverState.BorderColor = Color.FromArgb(120, 120, 130);
            btnTabHistory.HoverState.FillColor = Color.FromArgb(45, 45, 48);
            btnTabHistory.Location = new Point(254, 12);
            btnTabHistory.Name = "btnTabHistory";
            btnTabHistory.ShadowDecoration.CustomizableEdges = customizableEdges6;
            btnTabHistory.Size = new Size(110, 32);
            btnTabHistory.TabIndex = 2;
            btnTabHistory.Text = "Lịch sử";
            btnTabHistory.Click += btnTabHistory_Click;
            // 
            // btnReport
            // 
            btnReport.BorderRadius = 8;
            btnReport.Cursor = Cursors.Hand;
            btnReport.CustomizableEdges = customizableEdges7;
            btnReport.FillColor = Color.FromArgb(70, 130, 180);
            btnReport.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnReport.ForeColor = Color.White;
            btnReport.HoverState.FillColor = Color.FromArgb(90, 150, 200);
            btnReport.Location = new Point(370, 12);
            btnReport.Name = "btnReport";
            btnReport.ShadowDecoration.CustomizableEdges = customizableEdges8;
            btnReport.Size = new Size(95, 32);
            btnReport.TabIndex = 3;
            btnReport.Text = "Báo cáo";
            btnReport.Click += BtnReport_Click;
            // 
            // pnlMainTabContainer
            // 
            pnlMainTabContainer.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnlMainTabContainer.BackColor = Color.FromArgb(31, 31, 34);
            pnlMainTabContainer.BorderRadius = 14;
            pnlMainTabContainer.Controls.Add(pnlCenterMenu);
            pnlMainTabContainer.CustomizableEdges = customizableEdges13;
            pnlMainTabContainer.Location = new Point(15, 80);
            pnlMainTabContainer.Name = "pnlMainTabContainer";
            pnlMainTabContainer.ShadowDecoration.CustomizableEdges = customizableEdges14;
            pnlMainTabContainer.Size = new Size(670, 570);
            pnlMainTabContainer.TabIndex = 1;
            // 
            // pnlCenterMenu
            // 
            pnlCenterMenu.BackColor = Color.FromArgb(31, 31, 34);
            pnlCenterMenu.BorderRadius = 14;
            pnlCenterMenu.Controls.Add(flpProducts);
            pnlCenterMenu.CustomizableEdges = customizableEdges11;
            pnlCenterMenu.Dock = DockStyle.Fill;
            pnlCenterMenu.Location = new Point(0, 0);
            pnlCenterMenu.Name = "pnlCenterMenu";
            pnlCenterMenu.ShadowDecoration.CustomizableEdges = customizableEdges12;
            pnlCenterMenu.Size = new Size(670, 570);
            pnlCenterMenu.TabIndex = 0;
            // 
            // flpProducts
            // 
            flpProducts.AutoScroll = true;
            flpProducts.BackColor = Color.Transparent;
            flpProducts.Dock = DockStyle.Fill;
            flpProducts.Location = new Point(0, 0);
            flpProducts.Name = "flpProducts";
            flpProducts.Padding = new Padding(12);
            flpProducts.Size = new Size(670, 570);
            flpProducts.TabIndex = 0;
            // 
            // pnlRightBill
            // 
            pnlRightBill.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            pnlRightBill.BackColor = Color.FromArgb(31, 31, 34);
            pnlRightBill.BorderRadius = 14;
            pnlRightBill.Controls.Add(pnlStaffInfo);
            pnlRightBill.Controls.Add(lblOrderTitle);
            pnlRightBill.Controls.Add(btnTableBadge);
            pnlRightBill.Controls.Add(dgvCurrentOrder);
            pnlRightBill.Controls.Add(pnlBillFooter);
            pnlRightBill.CustomizableEdges = customizableEdges29;
            pnlRightBill.Location = new Point(700, 15);
            pnlRightBill.Name = "pnlRightBill";
            pnlRightBill.ShadowDecoration.CustomizableEdges = customizableEdges30;
            pnlRightBill.Size = new Size(285, 635);
            pnlRightBill.TabIndex = 2;
            // 
            // pnlStaffInfo
            // 
            pnlStaffInfo.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlStaffInfo.BackColor = Color.FromArgb(24, 24, 27);
            pnlStaffInfo.BorderRadius = 8;
            pnlStaffInfo.Controls.Add(lblCurrentStaff);
            pnlStaffInfo.CustomizableEdges = customizableEdges15;
            pnlStaffInfo.Location = new Point(12, 12);
            pnlStaffInfo.Name = "pnlStaffInfo";
            pnlStaffInfo.ShadowDecoration.CustomizableEdges = customizableEdges16;
            pnlStaffInfo.Size = new Size(261, 30);
            pnlStaffInfo.TabIndex = 0;
            // 
            // lblCurrentStaff
            // 
            lblCurrentStaff.AutoSize = true;
            lblCurrentStaff.Font = new Font("Segoe UI", 9F);
            lblCurrentStaff.ForeColor = Color.FromArgb(160, 160, 166);
            lblCurrentStaff.Location = new Point(10, 7);
            lblCurrentStaff.Name = "lblCurrentStaff";
            lblCurrentStaff.Size = new Size(162, 15);
            lblCurrentStaff.TabIndex = 0;
            lblCurrentStaff.Text = "Nhân viên: [Hệ thống tự nạp]";
            // 
            // lblOrderTitle
            // 
            lblOrderTitle.AutoSize = true;
            lblOrderTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblOrderTitle.ForeColor = Color.White;
            lblOrderTitle.Location = new Point(12, 61);
            lblOrderTitle.Name = "lblOrderTitle";
            lblOrderTitle.Size = new Size(77, 20);
            lblOrderTitle.TabIndex = 1;
            lblOrderTitle.Text = "Đơn hàng";
            // 
            // btnTableBadge
            // 
            btnTableBadge.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnTableBadge.BorderRadius = 8;
            btnTableBadge.Cursor = Cursors.Hand;
            btnTableBadge.CustomizableEdges = customizableEdges17;
            btnTableBadge.FillColor = Color.FromArgb(45, 45, 48);
            btnTableBadge.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            btnTableBadge.ForeColor = Color.White;
            btnTableBadge.Location = new Point(104, 61);
            btnTableBadge.Name = "btnTableBadge";
            btnTableBadge.ShadowDecoration.CustomizableEdges = customizableEdges18;
            btnTableBadge.Size = new Size(169, 26);
            btnTableBadge.TabIndex = 2;
            btnTableBadge.Text = "Mang đi (chưa chọn bàn)";
            btnTableBadge.Click += btnTabTables_Click;
            // 
            // dgvCurrentOrder
            // 
            dataGridViewCellStyle1.BackColor = Color.FromArgb(24, 24, 27);
            dataGridViewCellStyle1.ForeColor = Color.FromArgb(220, 220, 225);
            dgvCurrentOrder.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvCurrentOrder.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvCurrentOrder.BackgroundColor = Color.FromArgb(24, 24, 27);
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(31, 31, 34);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(160, 160, 166);
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(31, 31, 34);
            dataGridViewCellStyle2.SelectionForeColor = Color.FromArgb(160, 160, 166);
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvCurrentOrder.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvCurrentOrder.Columns.AddRange(new DataGridViewColumn[] { colOrderItem, colOrderQty, colOrderPrice, colOrderTotal });
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.FromArgb(24, 24, 27);
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(220, 220, 225);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(31, 138, 154);
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(240, 240, 245);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvCurrentOrder.DefaultCellStyle = dataGridViewCellStyle3;
            dgvCurrentOrder.GridColor = Color.FromArgb(45, 45, 48);
            dgvCurrentOrder.Location = new Point(12, 96);
            dgvCurrentOrder.Name = "dgvCurrentOrder";
            dgvCurrentOrder.RowHeadersVisible = false;
            dgvCurrentOrder.Size = new Size(261, 319);
            dgvCurrentOrder.TabIndex = 3;
            dgvCurrentOrder.ThemeStyle.AlternatingRowsStyle.BackColor = Color.FromArgb(24, 24, 27);
            dgvCurrentOrder.ThemeStyle.AlternatingRowsStyle.Font = null;
            dgvCurrentOrder.ThemeStyle.AlternatingRowsStyle.ForeColor = Color.FromArgb(220, 220, 225);
            dgvCurrentOrder.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.Empty;
            dgvCurrentOrder.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.Empty;
            dgvCurrentOrder.ThemeStyle.BackColor = Color.FromArgb(24, 24, 27);
            dgvCurrentOrder.ThemeStyle.GridColor = Color.FromArgb(45, 45, 48);
            dgvCurrentOrder.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(31, 31, 34);
            dgvCurrentOrder.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvCurrentOrder.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dgvCurrentOrder.ThemeStyle.HeaderStyle.ForeColor = Color.FromArgb(160, 160, 166);
            dgvCurrentOrder.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvCurrentOrder.ThemeStyle.HeaderStyle.Height = 23;
            dgvCurrentOrder.ThemeStyle.ReadOnly = false;
            dgvCurrentOrder.ThemeStyle.RowsStyle.BackColor = Color.FromArgb(24, 24, 27);
            dgvCurrentOrder.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvCurrentOrder.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 9F);
            dgvCurrentOrder.ThemeStyle.RowsStyle.ForeColor = Color.FromArgb(220, 220, 225);
            dgvCurrentOrder.ThemeStyle.RowsStyle.Height = 25;
            dgvCurrentOrder.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(31, 138, 154);
            dgvCurrentOrder.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(240, 240, 245);
            // 
            // colOrderItem
            // 
            colOrderItem.DataPropertyName = "Món";
            colOrderItem.HeaderText = "Món";
            colOrderItem.Name = "colOrderItem";
            // 
            // colOrderQty
            // 
            colOrderQty.DataPropertyName = "SL";
            colOrderQty.HeaderText = "SL";
            colOrderQty.Name = "colOrderQty";
            // 
            // colOrderPrice
            // 
            colOrderPrice.DataPropertyName = "Đơn giá";
            colOrderPrice.HeaderText = "Đơn giá";
            colOrderPrice.Name = "colOrderPrice";
            // 
            // colOrderTotal
            // 
            colOrderTotal.DataPropertyName = "Thành tiền";
            colOrderTotal.HeaderText = "Thành tiền";
            colOrderTotal.Name = "colOrderTotal";
            // 
            // pnlBillFooter
            // 
            pnlBillFooter.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnlBillFooter.BackColor = Color.FromArgb(24, 24, 27);
            pnlBillFooter.BorderRadius = 10;
            pnlBillFooter.Controls.Add(lblTotalTitle);
            pnlBillFooter.Controls.Add(lblTotalAmount);
            pnlBillFooter.Controls.Add(lblDiscountTitle);
            pnlBillFooter.Controls.Add(txtDiscount);
            pnlBillFooter.Controls.Add(btnSendKitchen);
            pnlBillFooter.Controls.Add(btnVoidOrder);
            pnlBillFooter.Controls.Add(btnPay);
            pnlBillFooter.CustomizableEdges = customizableEdges27;
            pnlBillFooter.Location = new Point(12, 423);
            pnlBillFooter.Name = "pnlBillFooter";
            pnlBillFooter.ShadowDecoration.CustomizableEdges = customizableEdges28;
            pnlBillFooter.Size = new Size(261, 200);
            pnlBillFooter.TabIndex = 4;
            // 
            // lblTotalTitle
            // 
            lblTotalTitle.AutoSize = true;
            lblTotalTitle.Font = new Font("Segoe UI", 9.5F);
            lblTotalTitle.ForeColor = Color.FromArgb(160, 160, 166);
            lblTotalTitle.Location = new Point(12, 12);
            lblTotalTitle.Name = "lblTotalTitle";
            lblTotalTitle.Size = new Size(71, 17);
            lblTotalTitle.TabIndex = 0;
            lblTotalTitle.Text = "Tổng cộng";
            // 
            // lblTotalAmount
            // 
            lblTotalAmount.AutoSize = true;
            lblTotalAmount.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            lblTotalAmount.ForeColor = Color.FromArgb(34, 197, 94);
            lblTotalAmount.Location = new Point(12, 30);
            lblTotalAmount.Name = "lblTotalAmount";
            lblTotalAmount.Size = new Size(43, 28);
            lblTotalAmount.TabIndex = 1;
            lblTotalAmount.Text = "0 đ";
            // 
            // lblDiscountTitle
            // 
            lblDiscountTitle.AutoSize = true;
            lblDiscountTitle.Font = new Font("Segoe UI", 9F);
            lblDiscountTitle.ForeColor = Color.FromArgb(160, 160, 166);
            lblDiscountTitle.Location = new Point(12, 70);
            lblDiscountTitle.Name = "lblDiscountTitle";
            lblDiscountTitle.Size = new Size(57, 15);
            lblDiscountTitle.TabIndex = 2;
            lblDiscountTitle.Text = "Giảm giá:";
            // 
            // txtDiscount
            // 
            txtDiscount.BorderColor = Color.FromArgb(63, 63, 70);
            txtDiscount.BorderRadius = 8;
            txtDiscount.CustomizableEdges = customizableEdges19;
            txtDiscount.DefaultText = "";
            txtDiscount.FillColor = Color.FromArgb(30, 30, 33);
            txtDiscount.FocusedState.BorderColor = Color.FromArgb(31, 138, 154);
            txtDiscount.Font = new Font("Segoe UI", 9.5F);
            txtDiscount.ForeColor = Color.White;
            txtDiscount.HoverState.BorderColor = Color.FromArgb(120, 120, 130);
            txtDiscount.Location = new Point(82, 66);
            txtDiscount.Name = "txtDiscount";
            txtDiscount.PasswordChar = '\0';
            txtDiscount.PlaceholderForeColor = Color.FromArgb(110, 110, 120);
            txtDiscount.PlaceholderText = "0";
            txtDiscount.SelectedText = "";
            txtDiscount.ShadowDecoration.CustomizableEdges = customizableEdges20;
            txtDiscount.Size = new Size(165, 28);
            txtDiscount.TabIndex = 3;
            txtDiscount.TextChanged += TxtDiscount_TextChanged;
            // 
            // btnSendKitchen
            // 
            btnSendKitchen.BorderRadius = 10;
            btnSendKitchen.Cursor = Cursors.Hand;
            btnSendKitchen.CustomizableEdges = customizableEdges21;
            btnSendKitchen.FillColor = Color.FromArgb(70, 130, 180);
            btnSendKitchen.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnSendKitchen.ForeColor = Color.White;
            btnSendKitchen.HoverState.FillColor = Color.FromArgb(90, 150, 200);
            btnSendKitchen.Location = new Point(12, 104);
            btnSendKitchen.Name = "btnSendKitchen";
            btnSendKitchen.ShadowDecoration.CustomizableEdges = customizableEdges22;
            btnSendKitchen.Size = new Size(237, 38);
            btnSendKitchen.TabIndex = 4;
            btnSendKitchen.Text = "Gửi pha chế";
            btnSendKitchen.Click += BtnSendKitchen_Click;
            // 
            // btnVoidOrder
            // 
            btnVoidOrder.BorderColor = Color.FromArgb(180, 60, 60);
            btnVoidOrder.BorderRadius = 10;
            btnVoidOrder.BorderThickness = 1;
            btnVoidOrder.Cursor = Cursors.Hand;
            btnVoidOrder.CustomizableEdges = customizableEdges23;
            btnVoidOrder.FillColor = Color.Transparent;
            btnVoidOrder.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnVoidOrder.ForeColor = Color.FromArgb(220, 80, 80);
            btnVoidOrder.HoverState.FillColor = Color.FromArgb(180, 60, 60);
            btnVoidOrder.HoverState.ForeColor = Color.White;
            btnVoidOrder.Location = new Point(12, 150);
            btnVoidOrder.Name = "btnVoidOrder";
            btnVoidOrder.ShadowDecoration.CustomizableEdges = customizableEdges24;
            btnVoidOrder.Size = new Size(100, 38);
            btnVoidOrder.TabIndex = 5;
            btnVoidOrder.Text = "Hủy đơn";
            btnVoidOrder.Click += BtnVoidOrder_Click;
            // 
            // btnPay
            // 
            btnPay.BorderRadius = 10;
            btnPay.Cursor = Cursors.Hand;
            btnPay.CustomizableEdges = customizableEdges25;
            btnPay.FillColor = Color.FromArgb(31, 138, 154);
            btnPay.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnPay.ForeColor = Color.White;
            btnPay.HoverState.FillColor = Color.FromArgb(45, 158, 174);
            btnPay.Location = new Point(116, 150);
            btnPay.Name = "btnPay";
            btnPay.ShadowDecoration.CustomizableEdges = customizableEdges26;
            btnPay.Size = new Size(133, 38);
            btnPay.TabIndex = 6;
            btnPay.Text = "Thanh toán";
            btnPay.Click += BtnPay_Click;
            // 
            // ucPOS_Order
            // 
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
        private Guna2Button btnTableBadge;
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
        private Guna2Button btnSendKitchen;
        private Guna2Button btnVoidOrder;
        private Guna2Button btnPay;
    }
}
