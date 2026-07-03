using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace GUI
{
    partial class ucBroadcastCenter
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        private void InitializeComponent()
        {
            Guna.UI2.WinForms.Suite.CustomizableEdges ce1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges ce2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges ce3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges ce4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges ce5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges ce6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges ce7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges ce8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges ce9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges ce10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();

            pnlHeader = new Guna2Panel();
            lblTitle = new Label();
            lblTotal = new Label();
            lblToday = new Label();
            txtSearch = new Guna2TextBox();
            btnNew = new Guna2Button();
            btnRefresh = new Guna2Button();
            pnlGrid = new Guna2Panel();
            dgvHistory = new Guna2DataGridView();
            colTime = new DataGridViewTextBoxColumn();
            colReceiver = new DataGridViewTextBoxColumn();
            colTitle = new DataGridViewTextBoxColumn();
            colLevel = new DataGridViewTextBoxColumn();
            colRead = new DataGridViewTextBoxColumn();
            colStatus = new DataGridViewTextBoxColumn();

            pnlHeader.SuspendLayout();
            pnlGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvHistory).BeginInit();
            SuspendLayout();

            // ====== pnlHeader ======
            pnlHeader.BackColor = Color.FromArgb(31, 31, 34);
            pnlHeader.BorderRadius = 14;
            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Controls.Add(lblTotal);
            pnlHeader.Controls.Add(lblToday);
            pnlHeader.Controls.Add(txtSearch);
            pnlHeader.Controls.Add(btnNew);
            pnlHeader.Controls.Add(btnRefresh);
            pnlHeader.CustomizableEdges = ce1;
            pnlHeader.Location = new Point(20, 20);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.ShadowDecoration.CustomizableEdges = ce2;
            pnlHeader.Size = new Size(960, 130);
            pnlHeader.TabIndex = 0;

            // ------ lblTitle ------
            lblTitle.AutoSize = true;
            lblTitle.BackColor = Color.Transparent;
            lblTitle.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(18, 16);
            lblTitle.Name = "lblTitle";
            lblTitle.Text = "Trung tâm phát thông báo";

            // ------ lblTotal ------
            lblTotal.AutoSize = true;
            lblTotal.BackColor = Color.Transparent;
            lblTotal.Font = new Font("Segoe UI", 9.5F);
            lblTotal.ForeColor = Color.FromArgb(34, 197, 94);
            lblTotal.Location = new Point(18, 52);
            lblTotal.Name = "lblTotal";
            lblTotal.Text = "Tổng đã gửi: 0";

            // ------ lblToday ------
            lblToday.AutoSize = true;
            lblToday.BackColor = Color.Transparent;
            lblToday.Font = new Font("Segoe UI", 9.5F);
            lblToday.ForeColor = Color.FromArgb(31, 138, 154);
            lblToday.Location = new Point(180, 52);
            lblToday.Name = "lblToday";
            lblToday.Text = "Hôm nay: 0";

            // ------ txtSearch ------
            txtSearch.BorderColor = Color.FromArgb(63, 63, 70);
            txtSearch.BorderRadius = 10;
            txtSearch.CustomizableEdges = ce3;
            txtSearch.DefaultText = "";
            txtSearch.DisabledState.BorderColor = Color.FromArgb(63, 63, 70);
            txtSearch.DisabledState.FillColor = Color.FromArgb(45, 45, 48);
            txtSearch.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            txtSearch.DisabledState.PlaceholderForeColor = Color.FromArgb(125, 137, 149);
            txtSearch.FillColor = Color.FromArgb(30, 30, 33);
            txtSearch.FocusedState.BorderColor = Color.FromArgb(31, 138, 154);
            txtSearch.Font = new Font("Segoe UI", 9.5F);
            txtSearch.ForeColor = Color.White;
            txtSearch.HoverState.BorderColor = Color.FromArgb(120, 120, 130);
            txtSearch.Location = new Point(18, 84);
            txtSearch.Name = "txtSearch";
            txtSearch.PasswordChar = '\0';
            txtSearch.PlaceholderForeColor = Color.FromArgb(110, 110, 120);
            txtSearch.PlaceholderText = "Tìm theo mọi trường...";
            txtSearch.SelectedText = "";
            txtSearch.ShadowDecoration.CustomizableEdges = ce4;
            txtSearch.Size = new Size(360, 34);
            txtSearch.TabIndex = 1;
            txtSearch.TextChanged += txtSearch_TextChanged;

            // ------ btnNew ------
            btnNew.BorderRadius = 10;
            btnNew.Cursor = Cursors.Hand;
            btnNew.CustomizableEdges = ce5;
            btnNew.FillColor = Color.FromArgb(31, 138, 154);
            btnNew.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnNew.ForeColor = Color.White;
            btnNew.HoverState.FillColor = Color.FromArgb(45, 158, 174);
            btnNew.Location = new Point(394, 84);
            btnNew.Name = "btnNew";
            btnNew.ShadowDecoration.CustomizableEdges = ce6;
            btnNew.Size = new Size(220, 34);
            btnNew.TabIndex = 2;
            btnNew.Text = "+  Soạn thông báo mới";
            btnNew.Click += BtnNew_Click;

            // ------ btnRefresh ------
            btnRefresh.BorderColor = Color.FromArgb(63, 63, 70);
            btnRefresh.BorderRadius = 10;
            btnRefresh.BorderThickness = 1;
            btnRefresh.Cursor = Cursors.Hand;
            btnRefresh.CustomizableEdges = ce7;
            btnRefresh.FillColor = Color.Transparent;
            btnRefresh.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnRefresh.ForeColor = Color.White;
            btnRefresh.HoverState.FillColor = Color.FromArgb(45, 45, 48);
            btnRefresh.Location = new Point(626, 84);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.ShadowDecoration.CustomizableEdges = ce8;
            btnRefresh.Size = new Size(110, 34);
            btnRefresh.TabIndex = 3;
            btnRefresh.Text = "Làm mới";
            btnRefresh.Click += BtnRefresh_Click;

            // ====== pnlGrid ======
            pnlGrid.BackColor = Color.FromArgb(31, 31, 34);
            pnlGrid.BorderRadius = 14;
            pnlGrid.Controls.Add(dgvHistory);
            pnlGrid.CustomizableEdges = ce9;
            pnlGrid.Location = new Point(20, 160);
            pnlGrid.Name = "pnlGrid";
            pnlGrid.ShadowDecoration.CustomizableEdges = ce10;
            pnlGrid.Size = new Size(960, 490);
            pnlGrid.TabIndex = 1;

            dgvHistory.BackgroundColor = Color.FromArgb(24, 24, 27);
            dgvHistory.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(31, 31, 34);
            dgvHistory.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(160, 160, 166);
            dgvHistory.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dgvHistory.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(31, 31, 34);
            dgvHistory.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.FromArgb(160, 160, 166);
            dgvHistory.DefaultCellStyle.BackColor = Color.FromArgb(24, 24, 27);
            dgvHistory.DefaultCellStyle.ForeColor = Color.FromArgb(220, 220, 225);
            dgvHistory.DefaultCellStyle.SelectionBackColor = Color.FromArgb(31, 138, 154);
            dgvHistory.DefaultCellStyle.SelectionForeColor = Color.FromArgb(240, 240, 245);
            dgvHistory.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(24, 24, 27);
            dgvHistory.AlternatingRowsDefaultCellStyle.ForeColor = Color.FromArgb(220, 220, 225);
            dgvHistory.GridColor = Color.FromArgb(45, 45, 48);
            ConfigureGrid(dgvHistory);            dgvHistory.Columns.AddRange(new DataGridViewColumn[] { colTime, colReceiver, colTitle, colLevel, colRead, colStatus });
            colTime.HeaderText = "Thời gian"; colTime.Name = "Thời gian"; colTime.DataPropertyName = "Thời gian";
            colReceiver.HeaderText = "Người nhận"; colReceiver.Name = "Người nhận"; colReceiver.DataPropertyName = "Người nhận";
            colTitle.HeaderText = "Tiêu đề"; colTitle.Name = "Tiêu đề"; colTitle.DataPropertyName = "Tiêu đề";
            colLevel.HeaderText = "Mức độ"; colLevel.Name = "Mức độ"; colLevel.DataPropertyName = "Mức độ";
            colRead.HeaderText = "Đã đọc"; colRead.Name = "Đã đọc"; colRead.DataPropertyName = "Đã đọc";
            colStatus.HeaderText = "Trạng thái"; colStatus.Name = "Trạng thái"; colStatus.DataPropertyName = "Trạng thái";
            dgvHistory.Location = new Point(18, 18);
            dgvHistory.Name = "dgvHistory";
            dgvHistory.Size = new Size(924, 454);
            dgvHistory.TabIndex = 0;
            dgvHistory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // ====== ucBroadcastCenter ======
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(39, 39, 42);
            Controls.Add(pnlHeader);
            Controls.Add(pnlGrid);
            Font = new Font("Segoe UI", 9F);
            ForeColor = Color.White;
            Name = "ucBroadcastCenter";
            Size = new Size(1000, 665);

            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            pnlGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvHistory).EndInit();
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

        private Guna2Panel pnlHeader;
        private Label lblTitle;
        private Label lblTotal;
        private Label lblToday;
        private Guna2TextBox txtSearch;
        private Guna2Button btnNew;
        private Guna2Button btnRefresh;
        private Guna2Panel pnlGrid;
        private Guna2DataGridView dgvHistory;
        private DataGridViewTextBoxColumn colTime;
        private DataGridViewTextBoxColumn colReceiver;
        private DataGridViewTextBoxColumn colTitle;
        private DataGridViewTextBoxColumn colLevel;
        private DataGridViewTextBoxColumn colRead;
        private DataGridViewTextBoxColumn colStatus;
    }
}
