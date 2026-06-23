using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace GUI
{
    partial class ucOrders_Manager
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
            pnlSummary = new Guna2Panel();
            pnlStatEmpty = new Guna2Panel();
            lblEmptyTablesTitle = new Label();
            lblEmptyTablesValue = new Label();
            pnlStatPending = new Guna2Panel();
            lblPendingTitle = new Label();
            lblPendingValue = new Label();
            pnlStatSoldOut = new Guna2Panel();
            lblSoldOutTitle = new Label();
            lblSoldOutValue = new Label();
            pnlTableStatus = new Guna2Panel();
            lblTableStatusTitle = new Label();
            btnStatus = new Guna2Button();
            cboTableStatus = new Guna2ComboBox();
            btnFilterTable = new Guna2Button();
            dgvTableStatus = new Guna2DataGridView();
            pnlSoldOut = new Guna2Panel();
            lblSoldOutListTitle = new Label();
            btnUpdateSoldOut = new Guna2Button();
            lstSoldOut = new ListBox();
            pnlKitchenWarning = new Guna2Panel();
            lblKitchenWarningTitle = new Label();
            lstKitchenWarning = new ListBox();
            pnlSummary.SuspendLayout();
            pnlStatEmpty.SuspendLayout();
            pnlStatPending.SuspendLayout();
            pnlStatSoldOut.SuspendLayout();
            pnlTableStatus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTableStatus).BeginInit();
            pnlSoldOut.SuspendLayout();
            pnlKitchenWarning.SuspendLayout();
            SuspendLayout();

            // ====== pnlSummary (wrapper) ======
            pnlSummary.BackColor = Color.Transparent;
            pnlSummary.Controls.Add(pnlStatEmpty);
            pnlSummary.Controls.Add(pnlStatPending);
            pnlSummary.Controls.Add(pnlStatSoldOut);
            pnlSummary.Location = new Point(20, 20);
            pnlSummary.Size = new Size(960, 90);

            // pnlStatEmpty
            pnlStatEmpty.BackColor = Color.FromArgb(31, 31, 34);
            pnlStatEmpty.BorderRadius = 14;
            pnlStatEmpty.Controls.Add(lblEmptyTablesTitle);
            pnlStatEmpty.Controls.Add(lblEmptyTablesValue);
            pnlStatEmpty.Location = new Point(0, 0);
            pnlStatEmpty.Size = new Size(310, 90);
            lblEmptyTablesTitle.AutoSize = true;
            lblEmptyTablesTitle.Font = new Font("Segoe UI", 9F);
            lblEmptyTablesTitle.ForeColor = Color.FromArgb(160, 160, 166);
            lblEmptyTablesTitle.Location = new Point(18, 16);
            lblEmptyTablesTitle.Text = "Trạng thái Bàn trống";
            lblEmptyTablesValue.AutoSize = true;
            lblEmptyTablesValue.Font = new Font("Segoe UI", 17F, FontStyle.Bold);
            lblEmptyTablesValue.ForeColor = Color.FromArgb(34, 197, 94);
            lblEmptyTablesValue.Location = new Point(18, 40);
            lblEmptyTablesValue.Text = "12 / 20 bàn";

            // pnlStatPending
            pnlStatPending.BackColor = Color.FromArgb(31, 31, 34);
            pnlStatPending.BorderRadius = 14;
            pnlStatPending.Controls.Add(lblPendingTitle);
            pnlStatPending.Controls.Add(lblPendingValue);
            pnlStatPending.Location = new Point(320, 0);
            pnlStatPending.Size = new Size(310, 90);
            lblPendingTitle.AutoSize = true;
            lblPendingTitle.Font = new Font("Segoe UI", 9F);
            lblPendingTitle.ForeColor = Color.FromArgb(160, 160, 166);
            lblPendingTitle.Location = new Point(18, 16);
            lblPendingTitle.Text = "Bàn đang chờ lên món";
            lblPendingValue.AutoSize = true;
            lblPendingValue.Font = new Font("Segoe UI", 17F, FontStyle.Bold);
            lblPendingValue.ForeColor = Color.FromArgb(245, 158, 11);
            lblPendingValue.Location = new Point(18, 40);
            lblPendingValue.Text = "3 bàn";

            // pnlStatSoldOut
            pnlStatSoldOut.BackColor = Color.FromArgb(31, 31, 34);
            pnlStatSoldOut.BorderRadius = 14;
            pnlStatSoldOut.Controls.Add(lblSoldOutTitle);
            pnlStatSoldOut.Controls.Add(lblSoldOutValue);
            pnlStatSoldOut.Location = new Point(640, 0);
            pnlStatSoldOut.Size = new Size(320, 90);
            lblSoldOutTitle.AutoSize = true;
            lblSoldOutTitle.Font = new Font("Segoe UI", 9F);
            lblSoldOutTitle.ForeColor = Color.FromArgb(160, 160, 166);
            lblSoldOutTitle.Location = new Point(18, 16);
            lblSoldOutTitle.Text = "Món Đã Hết (Sold Out)";
            lblSoldOutValue.AutoSize = true;
            lblSoldOutValue.Font = new Font("Segoe UI", 17F, FontStyle.Bold);
            lblSoldOutValue.ForeColor = Color.FromArgb(220, 80, 80);
            lblSoldOutValue.Location = new Point(18, 40);
            lblSoldOutValue.Text = "2 món";

            // ====== pnlTableStatus ======
            pnlTableStatus.BackColor = Color.FromArgb(31, 31, 34);
            pnlTableStatus.BorderRadius = 14;
            pnlTableStatus.Controls.Add(lblTableStatusTitle);
            pnlTableStatus.Controls.Add(btnStatus);
            pnlTableStatus.Controls.Add(cboTableStatus);
            pnlTableStatus.Controls.Add(btnFilterTable);
            pnlTableStatus.Controls.Add(dgvTableStatus);
            pnlTableStatus.Location = new Point(20, 125);
            pnlTableStatus.Size = new Size(560, 525);

            // lblTableStatusTitle
            lblTableStatusTitle.AutoSize = true;
            lblTableStatusTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblTableStatusTitle.ForeColor = Color.White;
            lblTableStatusTitle.Location = new Point(18, 16);
            lblTableStatusTitle.Text = "🪑  Trạng thái Phục vụ các Bàn";

            // btnStatus
            btnStatus.BorderRadius = 8;
            btnStatus.Cursor = Cursors.Hand;
            btnStatus.FillColor = Color.FromArgb(31, 138, 154);
            btnStatus.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnStatus.ForeColor = Color.White;
            btnStatus.HoverState.FillColor = Color.FromArgb(45, 158, 174);
            btnStatus.Location = new Point(438, 12);
            btnStatus.Size = new Size(106, 30);
            btnStatus.Text = "Cập nhật";

            // dgvTableStatus
            dgvTableStatus.BackgroundColor = Color.FromArgb(24, 24, 27);
            dgvTableStatus.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(31, 31, 34);
            dgvTableStatus.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(160, 160, 166);
            dgvTableStatus.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dgvTableStatus.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(31, 31, 34);
            dgvTableStatus.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.FromArgb(160, 160, 166);
            dgvTableStatus.DefaultCellStyle.BackColor = Color.FromArgb(24, 24, 27);
            dgvTableStatus.DefaultCellStyle.ForeColor = Color.FromArgb(220, 220, 225);
            dgvTableStatus.DefaultCellStyle.SelectionBackColor = Color.FromArgb(31, 138, 154);
            dgvTableStatus.DefaultCellStyle.SelectionForeColor = Color.FromArgb(240, 240, 245);
            dgvTableStatus.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(24, 24, 27);
            dgvTableStatus.AlternatingRowsDefaultCellStyle.ForeColor = Color.FromArgb(220, 220, 225);
            dgvTableStatus.GridColor = Color.FromArgb(45, 45, 48);
            ConfigureGrid(dgvTableStatus);
            dgvTableStatus.Location = new Point(18, 54);
            dgvTableStatus.Size = new Size(526, 410);

            // cboTableStatus
            cboTableStatus.BackColor = Color.Transparent;
            cboTableStatus.BorderColor = Color.FromArgb(63, 63, 70);
            cboTableStatus.BorderRadius = 8;
            cboTableStatus.DrawMode = DrawMode.OwnerDrawFixed;
            cboTableStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cboTableStatus.FillColor = Color.FromArgb(30, 30, 33);
            cboTableStatus.FocusedColor = Color.FromArgb(31, 138, 154);
            cboTableStatus.FocusedState.BorderColor = Color.FromArgb(31, 138, 154);
            cboTableStatus.Font = new Font("Segoe UI", 9.5F);
            cboTableStatus.ForeColor = Color.White;
            cboTableStatus.HoverState.BorderColor = Color.FromArgb(120, 120, 130);
            cboTableStatus.ItemHeight = 26;
            cboTableStatus.Location = new Point(18, 478);
            cboTableStatus.Size = new Size(420, 32);

            // btnFilterTable
            btnFilterTable.BorderRadius = 8;
            btnFilterTable.Cursor = Cursors.Hand;
            btnFilterTable.FillColor = Color.FromArgb(31, 138, 154);
            btnFilterTable.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnFilterTable.ForeColor = Color.White;
            btnFilterTable.HoverState.FillColor = Color.FromArgb(45, 158, 174);
            btnFilterTable.Location = new Point(444, 478);
            btnFilterTable.Size = new Size(100, 32);
            btnFilterTable.Text = "🔍  Lọc";
            btnFilterTable.Click += btnFilterTable_Click;

            // ====== pnlSoldOut ======
            pnlSoldOut.BackColor = Color.FromArgb(31, 31, 34);
            pnlSoldOut.BorderRadius = 14;
            pnlSoldOut.Controls.Add(lblSoldOutListTitle);
            pnlSoldOut.Controls.Add(btnUpdateSoldOut);
            pnlSoldOut.Controls.Add(lstSoldOut);
            pnlSoldOut.Location = new Point(595, 125);
            pnlSoldOut.Size = new Size(385, 250);
            lblSoldOutListTitle.AutoSize = true;
            lblSoldOutListTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblSoldOutListTitle.ForeColor = Color.FromArgb(220, 80, 80);
            lblSoldOutListTitle.Location = new Point(18, 16);
            lblSoldOutListTitle.Text = "❌  Danh sách món đã hết";

            // btnUpdateSoldOut
            btnUpdateSoldOut.BorderRadius = 8;
            btnUpdateSoldOut.Cursor = Cursors.Hand;
            btnUpdateSoldOut.FillColor = Color.FromArgb(31, 138, 154);
            btnUpdateSoldOut.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnUpdateSoldOut.ForeColor = Color.White;
            btnUpdateSoldOut.HoverState.FillColor = Color.FromArgb(45, 158, 174);
            btnUpdateSoldOut.Location = new Point(255, 12);
            btnUpdateSoldOut.Size = new Size(112, 30);

            btnUpdateSoldOut.Text = "Cập nhật";

            // lstSoldOut
            lstSoldOut.BackColor = Color.FromArgb(24, 24, 27);
            lstSoldOut.BorderStyle = BorderStyle.None;
            lstSoldOut.Font = new Font("Segoe UI", 10F);
            lstSoldOut.ForeColor = Color.FromArgb(220, 220, 225);
            lstSoldOut.FormattingEnabled = true;
            lstSoldOut.ItemHeight = 20;
            lstSoldOut.Location = new Point(18, 54);
            lstSoldOut.Size = new Size(349, 180);
            lstSoldOut.SelectedIndexChanged += lstSoldOut_SelectedIndexChanged;

            // ====== pnlKitchenWarning ======
            pnlKitchenWarning.BackColor = Color.FromArgb(31, 31, 34);
            pnlKitchenWarning.BorderRadius = 14;
            pnlKitchenWarning.Controls.Add(lblKitchenWarningTitle);
            pnlKitchenWarning.Controls.Add(lstKitchenWarning);
            pnlKitchenWarning.Location = new Point(595, 390);
            pnlKitchenWarning.Size = new Size(385, 260);
            lblKitchenWarningTitle.AutoSize = true;
            lblKitchenWarningTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblKitchenWarningTitle.ForeColor = Color.FromArgb(245, 158, 11);
            lblKitchenWarningTitle.Location = new Point(18, 16);
            lblKitchenWarningTitle.Text = "⚠  Cảnh báo Món chờ quá lâu";

            // lstKitchenWarning
            lstKitchenWarning.AccessibleRole = AccessibleRole.Sound;
            lstKitchenWarning.BackColor = Color.FromArgb(24, 24, 27);
            lstKitchenWarning.BorderStyle = BorderStyle.None;
            lstKitchenWarning.Font = new Font("Segoe UI", 10F);
            lstKitchenWarning.ForeColor = Color.FromArgb(220, 220, 225);
            lstKitchenWarning.FormattingEnabled = true;
            lstKitchenWarning.ItemHeight = 20;
            lstKitchenWarning.Location = new Point(18, 54);
            lstKitchenWarning.Size = new Size(349, 190);
            lstKitchenWarning.DoubleClick += lstKitchenWarning_DoubleClick;

            // ====== ucOrders_Manager ======
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(39, 39, 42);
            Controls.Add(pnlSummary);
            Controls.Add(pnlTableStatus);
            Controls.Add(pnlSoldOut);
            Controls.Add(pnlKitchenWarning);
            Name = "ucOrders_Manager";
            Size = new Size(1000, 665);
            pnlSummary.ResumeLayout(false);
            pnlStatEmpty.ResumeLayout(false);
            pnlStatEmpty.PerformLayout();
            pnlStatPending.ResumeLayout(false);
            pnlStatPending.PerformLayout();
            pnlStatSoldOut.ResumeLayout(false);
            pnlStatSoldOut.PerformLayout();
            pnlTableStatus.ResumeLayout(false);
            pnlTableStatus.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTableStatus).EndInit();
            pnlSoldOut.ResumeLayout(false);
            pnlSoldOut.PerformLayout();
            pnlKitchenWarning.ResumeLayout(false);
            pnlKitchenWarning.PerformLayout();
            ResumeLayout(false);
        }

        private static void ConfigureGrid(Guna2DataGridView dgv)
        {
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

        private Guna2Panel pnlSummary;
        private Guna2Panel pnlStatEmpty;
        private Label lblEmptyTablesTitle;
        private Label lblEmptyTablesValue;
        private Guna2Panel pnlStatPending;
        private Label lblPendingTitle;
        private Label lblPendingValue;
        private Guna2Panel pnlStatSoldOut;
        private Label lblSoldOutTitle;
        private Label lblSoldOutValue;
        private Guna2Panel pnlTableStatus;
        private Label lblTableStatusTitle;
        private Guna2DataGridView dgvTableStatus;
        private Guna2Panel pnlSoldOut;
        private Label lblSoldOutListTitle;
        private ListBox lstSoldOut;
        private Guna2Button btnUpdateSoldOut;
        private Guna2Panel pnlKitchenWarning;
        private Label lblKitchenWarningTitle;
        private ListBox lstKitchenWarning;
        private Guna2ComboBox cboTableStatus;
        private Guna2Button btnFilterTable;
        private Guna2Button btnStatus;
    }
}
