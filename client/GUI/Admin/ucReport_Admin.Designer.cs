using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace GUI
{
    partial class ucReport_Admin
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges19 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges20 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges11 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges12 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges13 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges14 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges15 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges16 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges17 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges18 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges21 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges22 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges23 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges24 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            lblTitle = new Label();
            lblSub = new Label();
            pnlType = new Guna2Panel();
            lblTypeCaption = new Label();
            btnRevenue = new Guna2Button();
            btnPayroll = new Guna2Button();
            btnInventory = new Guna2Button();
            btnFeedback = new Guna2Button();
            pnlAction = new Guna2Panel();
            lblPeriodCaption = new Label();
            cmbMonth = new Guna2ComboBox();
            btnExcelExport = new Guna2Button();
            btnPdfExport = new Guna2Button();
            pnlPreview = new Guna2Panel();
            lblPreviewTitle = new Label();
            dgvPreview = new Guna2DataGridView();
            colRpDate = new DataGridViewTextBoxColumn();
            colRpOrders = new DataGridViewTextBoxColumn();
            colRpRevenue = new DataGridViewTextBoxColumn();
            colRpDiscount = new DataGridViewTextBoxColumn();
            colRpNet = new DataGridViewTextBoxColumn();
            colRpPayment = new DataGridViewTextBoxColumn();
            pnlType.SuspendLayout();
            pnlAction.SuspendLayout();
            pnlPreview.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPreview).BeginInit();
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
            lblTitle.Size = new Size(160, 25);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Xuất báo cáo";
            // 
            // lblSub
            // 
            lblSub.AutoSize = true;
            lblSub.BackColor = Color.Transparent;
            lblSub.Font = new Font("Segoe UI", 9F);
            lblSub.ForeColor = Color.FromArgb(160, 160, 166);
            lblSub.Location = new Point(22, 46);
            lblSub.Name = "lblSub";
            lblSub.Size = new Size(222, 15);
            lblSub.TabIndex = 1;
            lblSub.Text = "Xuất Excel / PDF";
            // 
            // pnlType
            // 
            pnlType.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlType.BackColor = Color.Transparent;
            pnlType.BorderRadius = 14;
            pnlType.Controls.Add(lblTypeCaption);
            pnlType.Controls.Add(btnRevenue);
            pnlType.Controls.Add(btnPayroll);
            pnlType.Controls.Add(btnInventory);
            pnlType.Controls.Add(btnFeedback);
            pnlType.CustomizableEdges = customizableEdges9;
            pnlType.FillColor = Color.FromArgb(31, 31, 34);
            pnlType.Location = new Point(16, 70);
            pnlType.Name = "pnlType";
            pnlType.ShadowDecoration.CustomizableEdges = customizableEdges10;
            pnlType.Size = new Size(968, 64);
            pnlType.TabIndex = 0;
            // 
            // lblTypeCaption
            // 
            lblTypeCaption.AutoSize = true;
            lblTypeCaption.BackColor = Color.Transparent;
            lblTypeCaption.Font = new Font("Segoe UI", 9.5F);
            lblTypeCaption.ForeColor = Color.FromArgb(160, 160, 166);
            lblTypeCaption.Location = new Point(14, 22);
            lblTypeCaption.Name = "lblTypeCaption";
            lblTypeCaption.Size = new Size(87, 17);
            lblTypeCaption.TabIndex = 0;
            lblTypeCaption.Text = "Loại báo cáo:";
            // 
            // btnRevenue
            // 
            btnRevenue.BorderColor = Color.FromArgb(63, 63, 70);
            btnRevenue.BorderRadius = 10;
            btnRevenue.BorderThickness = 1;
            btnRevenue.Cursor = Cursors.Hand;
            btnRevenue.CustomizableEdges = customizableEdges1;
            btnRevenue.FillColor = Color.Transparent;
            btnRevenue.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnRevenue.ForeColor = Color.FromArgb(220, 220, 225);
            btnRevenue.HoverState.BorderColor = Color.FromArgb(103, 103, 110);
            btnRevenue.HoverState.FillColor = Color.FromArgb(45, 45, 50);
            btnRevenue.Location = new Point(107, 12);
            btnRevenue.Name = "btnRevenue";
            btnRevenue.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnRevenue.Size = new Size(160, 40);
            btnRevenue.TabIndex = 1;
            btnRevenue.Tag = "revenue";
            btnRevenue.Text = "Doanh thu";
            // 
            // btnPayroll
            // 
            btnPayroll.BorderColor = Color.FromArgb(63, 63, 70);
            btnPayroll.BorderRadius = 10;
            btnPayroll.BorderThickness = 1;
            btnPayroll.Cursor = Cursors.Hand;
            btnPayroll.CustomizableEdges = customizableEdges3;
            btnPayroll.FillColor = Color.Transparent;
            btnPayroll.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnPayroll.ForeColor = Color.FromArgb(220, 220, 225);
            btnPayroll.HoverState.BorderColor = Color.FromArgb(103, 103, 110);
            btnPayroll.HoverState.FillColor = Color.FromArgb(45, 45, 50);
            btnPayroll.Location = new Point(330, 12);
            btnPayroll.Name = "btnPayroll";
            btnPayroll.ShadowDecoration.CustomizableEdges = customizableEdges4;
            btnPayroll.Size = new Size(160, 40);
            btnPayroll.TabIndex = 2;
            btnPayroll.Tag = "payroll";
            btnPayroll.Text = "Bảng lương";
            // 
            // btnInventory
            // 
            btnInventory.BorderColor = Color.FromArgb(63, 63, 70);
            btnInventory.BorderRadius = 10;
            btnInventory.BorderThickness = 1;
            btnInventory.Cursor = Cursors.Hand;
            btnInventory.CustomizableEdges = customizableEdges5;
            btnInventory.FillColor = Color.Transparent;
            btnInventory.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnInventory.ForeColor = Color.FromArgb(220, 220, 225);
            btnInventory.HoverState.BorderColor = Color.FromArgb(103, 103, 110);
            btnInventory.HoverState.FillColor = Color.FromArgb(45, 45, 50);
            btnInventory.Location = new Point(563, 12);
            btnInventory.Name = "btnInventory";
            btnInventory.ShadowDecoration.CustomizableEdges = customizableEdges6;
            btnInventory.Size = new Size(160, 40);
            btnInventory.TabIndex = 3;
            btnInventory.Tag = "inventory";
            btnInventory.Text = "Kho hàng";
            // 
            // btnFeedback
            // 
            btnFeedback.BorderColor = Color.FromArgb(63, 63, 70);
            btnFeedback.BorderRadius = 10;
            btnFeedback.BorderThickness = 1;
            btnFeedback.Cursor = Cursors.Hand;
            btnFeedback.CustomizableEdges = customizableEdges7;
            btnFeedback.FillColor = Color.Transparent;
            btnFeedback.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnFeedback.ForeColor = Color.FromArgb(220, 220, 225);
            btnFeedback.HoverState.BorderColor = Color.FromArgb(103, 103, 110);
            btnFeedback.HoverState.FillColor = Color.FromArgb(45, 45, 50);
            btnFeedback.Location = new Point(795, 12);
            btnFeedback.Name = "btnFeedback";
            btnFeedback.ShadowDecoration.CustomizableEdges = customizableEdges8;
            btnFeedback.Size = new Size(160, 40);
            btnFeedback.TabIndex = 4;
            btnFeedback.Tag = "feedback";
            btnFeedback.Text = "Feedback";
            // 
            // pnlAction
            // 
            pnlAction.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlAction.BackColor = Color.Transparent;
            pnlAction.BorderRadius = 14;
            pnlAction.Controls.Add(lblPeriodCaption);
            pnlAction.Controls.Add(cmbMonth);
            pnlAction.Controls.Add(btnExcelExport);
            pnlAction.Controls.Add(btnPdfExport);
            pnlAction.CustomizableEdges = customizableEdges19;
            pnlAction.FillColor = Color.FromArgb(31, 31, 34);
            pnlAction.Location = new Point(16, 148);
            pnlAction.Name = "pnlAction";
            pnlAction.ShadowDecoration.CustomizableEdges = customizableEdges20;
            pnlAction.Size = new Size(968, 60);
            pnlAction.TabIndex = 5;
            // 
            // lblPeriodCaption
            // 
            lblPeriodCaption.AutoSize = true;
            lblPeriodCaption.BackColor = Color.Transparent;
            lblPeriodCaption.Font = new Font("Segoe UI", 9.5F);
            lblPeriodCaption.ForeColor = Color.FromArgb(160, 160, 166);
            lblPeriodCaption.Location = new Point(14, 20);
            lblPeriodCaption.Name = "lblPeriodCaption";
            lblPeriodCaption.Size = new Size(76, 17);
            lblPeriodCaption.TabIndex = 0;
            lblPeriodCaption.Text = "Kỳ báo cáo:";
            // 
            // cmbMonth
            // 
            cmbMonth.BackColor = Color.Transparent;
            cmbMonth.BorderColor = Color.FromArgb(63, 63, 70);
            cmbMonth.BorderRadius = 8;
            cmbMonth.CustomizableEdges = customizableEdges11;
            cmbMonth.DrawMode = DrawMode.OwnerDrawFixed;
            cmbMonth.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMonth.FillColor = Color.FromArgb(24, 24, 27);
            cmbMonth.FocusedColor = Color.Empty;
            cmbMonth.Font = new Font("Segoe UI", 9.5F);
            cmbMonth.ForeColor = Color.FromArgb(220, 220, 225);
            cmbMonth.ItemHeight = 30;
            cmbMonth.Location = new Point(104, 12);
            cmbMonth.Name = "cmbMonth";
            cmbMonth.ShadowDecoration.CustomizableEdges = customizableEdges12;
            cmbMonth.Size = new Size(150, 36);
            cmbMonth.TabIndex = 6;
            // 
            // btnExcelExport
            // 
            btnExcelExport.BorderRadius = 10;
            btnExcelExport.Cursor = Cursors.Hand;
            btnExcelExport.CustomizableEdges = customizableEdges13;
            btnExcelExport.FillColor = Color.FromArgb(31, 138, 154);
            btnExcelExport.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnExcelExport.ForeColor = Color.White;
            btnExcelExport.HoverState.FillColor = Color.FromArgb(47, 154, 170);
            btnExcelExport.Location = new Point(340, 11);
            btnExcelExport.Name = "btnExcelExport";
            btnExcelExport.ShadowDecoration.CustomizableEdges = customizableEdges14;
            btnExcelExport.Size = new Size(136, 38);
            btnExcelExport.TabIndex = 7;
            btnExcelExport.Text = "Xuất Excel";
            // 
            // btnPdfExport
            // 
            btnPdfExport.BorderRadius = 10;
            btnPdfExport.Cursor = Cursors.Hand;
            btnPdfExport.CustomizableEdges = customizableEdges15;
            btnPdfExport.FillColor = Color.FromArgb(70, 130, 180);
            btnPdfExport.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnPdfExport.ForeColor = Color.White;
            btnPdfExport.HoverState.FillColor = Color.FromArgb(86, 146, 196);
            btnPdfExport.Location = new Point(484, 11);
            btnPdfExport.Name = "btnPdfExport";
            btnPdfExport.ShadowDecoration.CustomizableEdges = customizableEdges16;
            btnPdfExport.Size = new Size(136, 38);
            btnPdfExport.TabIndex = 8;
            btnPdfExport.Text = "Xuất PDF";
            //
            // pnlPreview
            //
            pnlPreview.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnlPreview.BackColor = Color.Transparent;
            pnlPreview.BorderRadius = 14;
            pnlPreview.Controls.Add(lblPreviewTitle);
            pnlPreview.Controls.Add(dgvPreview);
            pnlPreview.CustomizableEdges = customizableEdges21;
            pnlPreview.FillColor = Color.FromArgb(24, 24, 27);
            pnlPreview.Location = new Point(16, 224);
            pnlPreview.Name = "pnlPreview";
            pnlPreview.ShadowDecoration.CustomizableEdges = customizableEdges22;
            pnlPreview.Size = new Size(968, 425);
            pnlPreview.TabIndex = 10;
            // 
            // lblPreviewTitle
            // 
            lblPreviewTitle.AutoSize = true;
            lblPreviewTitle.BackColor = Color.Transparent;
            lblPreviewTitle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblPreviewTitle.ForeColor = Color.FromArgb(240, 240, 245);
            lblPreviewTitle.Location = new Point(14, 12);
            lblPreviewTitle.Name = "lblPreviewTitle";
            lblPreviewTitle.Size = new Size(226, 19);
            lblPreviewTitle.TabIndex = 0;
            lblPreviewTitle.Text = "Xem trước — Báo cáo doanh thu";
            // 
            // dgvPreview
            // 
            dataGridViewCellStyle1.BackColor = Color.White;
            dgvPreview.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvPreview.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(100, 88, 255);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvPreview.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvPreview.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPreview.Columns.AddRange(new DataGridViewColumn[] { colRpDate, colRpOrders, colRpRevenue, colRpDiscount, colRpNet, colRpPayment });
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvPreview.DefaultCellStyle = dataGridViewCellStyle3;
            dgvPreview.GridColor = Color.FromArgb(231, 229, 255);
            dgvPreview.Location = new Point(0, 40);
            dgvPreview.Name = "dgvPreview";
            dgvPreview.RowHeadersVisible = false;
            dgvPreview.RowHeadersWidth = 51;
            dgvPreview.Size = new Size(968, 381);
            dgvPreview.TabIndex = 11;
            dgvPreview.ThemeStyle.AlternatingRowsStyle.BackColor = Color.White;
            dgvPreview.ThemeStyle.AlternatingRowsStyle.Font = null;
            dgvPreview.ThemeStyle.AlternatingRowsStyle.ForeColor = Color.Empty;
            dgvPreview.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.Empty;
            dgvPreview.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.Empty;
            dgvPreview.ThemeStyle.BackColor = Color.White;
            dgvPreview.ThemeStyle.GridColor = Color.FromArgb(231, 229, 255);
            dgvPreview.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(100, 88, 255);
            dgvPreview.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvPreview.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI", 9F);
            dgvPreview.ThemeStyle.HeaderStyle.ForeColor = Color.White;
            dgvPreview.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPreview.ThemeStyle.HeaderStyle.Height = 17;
            dgvPreview.ThemeStyle.ReadOnly = false;
            dgvPreview.ThemeStyle.RowsStyle.BackColor = Color.White;
            dgvPreview.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvPreview.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 9F);
            dgvPreview.ThemeStyle.RowsStyle.ForeColor = Color.FromArgb(71, 69, 94);
            dgvPreview.ThemeStyle.RowsStyle.Height = 25;
            dgvPreview.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dgvPreview.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(71, 69, 94);
            // 
            // colRpDate
            // 
            colRpDate.DataPropertyName = "Ngày";
            colRpDate.HeaderText = "Ngày";
            colRpDate.Name = "colRpDate";
            // 
            // colRpOrders
            // 
            colRpOrders.DataPropertyName = "Số đơn";
            colRpOrders.HeaderText = "Số đơn";
            colRpOrders.Name = "colRpOrders";
            // 
            // colRpRevenue
            // 
            colRpRevenue.DataPropertyName = "Doanh thu";
            colRpRevenue.HeaderText = "Doanh thu";
            colRpRevenue.Name = "colRpRevenue";
            // 
            // colRpDiscount
            // 
            colRpDiscount.DataPropertyName = "Giảm giá";
            colRpDiscount.HeaderText = "Giảm giá";
            colRpDiscount.Name = "colRpDiscount";
            // 
            // colRpNet
            // 
            colRpNet.DataPropertyName = "Thực thu";
            colRpNet.HeaderText = "Thực thu";
            colRpNet.Name = "colRpNet";
            // 
            // colRpPayment
            // 
            colRpPayment.DataPropertyName = "Hình thức TT";
            colRpPayment.HeaderText = "Hình thức TT";
            colRpPayment.Name = "colRpPayment";
            //
            // ucReport_Admin
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(39, 39, 42);
            Controls.Add(lblTitle);
            Controls.Add(lblSub);
            Controls.Add(pnlType);
            Controls.Add(pnlAction);
            Controls.Add(pnlPreview);
            Name = "ucReport_Admin";
            Size = new Size(1000, 665);
            pnlType.ResumeLayout(false);
            pnlType.PerformLayout();
            pnlAction.ResumeLayout(false);
            pnlAction.PerformLayout();
            pnlPreview.ResumeLayout(false);
            pnlPreview.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPreview).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private Label lblSub;
        private Guna2Panel pnlType;
        private Label lblTypeCaption;
        private Guna2Button btnRevenue;
        private Guna2Button btnPayroll;
        private Guna2Button btnInventory;
        private Guna2Button btnFeedback;
        private Guna2Panel pnlAction;
        private Label lblPeriodCaption;
        private Guna2ComboBox cmbMonth;
        private Guna2Button btnExcelExport;
        private Guna2Button btnPdfExport;
        private Guna2Panel pnlPreview;
        private Label lblPreviewTitle;
        private Guna2DataGridView dgvPreview;
        private DataGridViewTextBoxColumn colRpDate;
        private DataGridViewTextBoxColumn colRpOrders;
        private DataGridViewTextBoxColumn colRpRevenue;
        private DataGridViewTextBoxColumn colRpDiscount;
        private DataGridViewTextBoxColumn colRpNet;
        private DataGridViewTextBoxColumn colRpPayment;
    }
}
