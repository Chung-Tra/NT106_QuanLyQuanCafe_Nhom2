using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace GUI
{
    partial class ucAuditLog
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges11 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges12 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            lblTitle = new Label();
            lblSub = new Label();
            pnlFilter = new Guna2Panel();
            txtSearch = new Guna2TextBox();
            cmbAction = new Guna2ComboBox();
            cmbUser = new Guna2ComboBox();
            btnClear = new Guna2Button();
            lblCount = new Label();
            pnlGrid = new Guna2Panel();
            dgvAudit = new Guna2DataGridView();
            colTime = new DataGridViewTextBoxColumn();
            colStaff = new DataGridViewTextBoxColumn();
            colRole = new DataGridViewTextBoxColumn();
            colAction = new DataGridViewTextBoxColumn();
            colTarget = new DataGridViewTextBoxColumn();
            colReason = new DataGridViewTextBoxColumn();
            colIP = new DataGridViewTextBoxColumn();
            pnlFilter.SuspendLayout();
            pnlGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAudit).BeginInit();
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
            lblTitle.Size = new Size(207, 25);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Nhật ký kiểm toán";
            // 
            // lblSub
            // 
            lblSub.AutoSize = true;
            lblSub.BackColor = Color.Transparent;
            lblSub.Font = new Font("Segoe UI", 9F);
            lblSub.ForeColor = Color.FromArgb(160, 160, 166);
            lblSub.Location = new Point(22, 46);
            lblSub.Name = "lblSub";
            lblSub.Size = new Size(275, 15);
            lblSub.TabIndex = 1;
            lblSub.Text = "Ghi lại mọi thao tác nhạy cảm — bắt buộc có lý do";
            // 
            // pnlFilter
            // 
            pnlFilter.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlFilter.BackColor = Color.Transparent;
            pnlFilter.BorderRadius = 14;
            pnlFilter.Controls.Add(txtSearch);
            pnlFilter.Controls.Add(cmbAction);
            pnlFilter.Controls.Add(cmbUser);
            pnlFilter.Controls.Add(btnClear);
            pnlFilter.CustomizableEdges = customizableEdges9;
            pnlFilter.FillColor = Color.FromArgb(31, 31, 34);
            pnlFilter.Location = new Point(16, 70);
            pnlFilter.Name = "pnlFilter";
            pnlFilter.ShadowDecoration.CustomizableEdges = customizableEdges10;
            pnlFilter.Size = new Size(968, 56);
            pnlFilter.TabIndex = 2;
            // 
            // txtSearch
            // 
            txtSearch.BorderColor = Color.FromArgb(63, 63, 70);
            txtSearch.BorderRadius = 8;
            txtSearch.CustomizableEdges = customizableEdges1;
            txtSearch.DefaultText = "";
            txtSearch.FillColor = Color.FromArgb(30, 30, 33);
            txtSearch.FocusedState.BorderColor = Color.FromArgb(31, 138, 154);
            txtSearch.Font = new Font("Segoe UI", 9.5F);
            txtSearch.ForeColor = Color.FromArgb(240, 240, 245);
            txtSearch.HoverState.BorderColor = Color.FromArgb(120, 120, 130);
            txtSearch.Location = new Point(12, 10);
            txtSearch.Name = "txtSearch";
            txtSearch.PasswordChar = '\0';
            txtSearch.PlaceholderForeColor = Color.FromArgb(110, 110, 120);
            txtSearch.PlaceholderText = "Tìm theo mọi trường...";
            txtSearch.SelectedText = "";
            txtSearch.ShadowDecoration.CustomizableEdges = customizableEdges2;
            txtSearch.Size = new Size(260, 36);
            txtSearch.TabIndex = 0;
            // 
            // cmbAction
            // 
            cmbAction.BackColor = Color.Transparent;
            cmbAction.BorderColor = Color.FromArgb(63, 63, 70);
            cmbAction.BorderRadius = 8;
            cmbAction.CustomizableEdges = customizableEdges3;
            cmbAction.DrawMode = DrawMode.OwnerDrawFixed;
            cmbAction.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbAction.FillColor = Color.FromArgb(24, 24, 27);
            cmbAction.FocusedColor = Color.FromArgb(31, 138, 154);
            cmbAction.FocusedState.BorderColor = Color.FromArgb(31, 138, 154);
            cmbAction.Font = new Font("Segoe UI", 9.5F);
            cmbAction.ForeColor = Color.FromArgb(220, 220, 225);
            cmbAction.ItemHeight = 30;
            cmbAction.Items.AddRange(new object[] { "-- Loại thao tác --", "Đăng nhập", "Sửa thông tin", "Xóa", "Phê duyệt", "Thanh toán", "Xuất báo cáo" });
            cmbAction.Location = new Point(282, 10);
            cmbAction.Name = "cmbAction";
            cmbAction.ShadowDecoration.CustomizableEdges = customizableEdges4;
            cmbAction.Size = new Size(160, 36);
            cmbAction.TabIndex = 1;
            // 
            // cmbUser
            // 
            cmbUser.BackColor = Color.Transparent;
            cmbUser.BorderColor = Color.FromArgb(63, 63, 70);
            cmbUser.BorderRadius = 8;
            cmbUser.CustomizableEdges = customizableEdges5;
            cmbUser.DrawMode = DrawMode.OwnerDrawFixed;
            cmbUser.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbUser.FillColor = Color.FromArgb(24, 24, 27);
            cmbUser.FocusedColor = Color.FromArgb(31, 138, 154);
            cmbUser.FocusedState.BorderColor = Color.FromArgb(31, 138, 154);
            cmbUser.Font = new Font("Segoe UI", 9.5F);
            cmbUser.ForeColor = Color.FromArgb(220, 220, 225);
            cmbUser.ItemHeight = 30;
            cmbUser.Items.AddRange(new object[] { "-- Tất cả nhân viên --", "Quản trị viên", "Quản lý", "Pha chế", "Nhân viên Order" });
            cmbUser.Location = new Point(448, 10);
            cmbUser.Name = "cmbUser";
            cmbUser.ShadowDecoration.CustomizableEdges = customizableEdges6;
            cmbUser.Size = new Size(166, 36);
            cmbUser.TabIndex = 2;
            // 
            // btnClear
            // 
            btnClear.BorderColor = Color.FromArgb(63, 63, 70);
            btnClear.BorderRadius = 10;
            btnClear.BorderThickness = 1;
            btnClear.Cursor = Cursors.Hand;
            btnClear.CustomizableEdges = customizableEdges7;
            btnClear.FillColor = Color.Transparent;
            btnClear.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnClear.ForeColor = Color.FromArgb(220, 220, 225);
            btnClear.HoverState.BorderColor = Color.FromArgb(103, 103, 110);
            btnClear.HoverState.FillColor = Color.FromArgb(45, 45, 50);
            btnClear.Location = new Point(624, 10);
            btnClear.Name = "btnClear";
            btnClear.ShadowDecoration.CustomizableEdges = customizableEdges8;
            btnClear.Size = new Size(100, 36);
            btnClear.TabIndex = 3;
            btnClear.Text = "Xóa lọc";
            // 
            // lblCount
            // 
            lblCount.AutoSize = true;
            lblCount.BackColor = Color.Transparent;
            lblCount.Font = new Font("Segoe UI", 9F);
            lblCount.ForeColor = Color.FromArgb(160, 160, 166);
            lblCount.Location = new Point(22, 136);
            lblCount.Name = "lblCount";
            lblCount.Size = new Size(56, 15);
            lblCount.TabIndex = 3;
            lblCount.Text = "0 bản ghi";
            // 
            // pnlGrid
            // 
            pnlGrid.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnlGrid.BackColor = Color.Transparent;
            pnlGrid.BorderRadius = 14;
            pnlGrid.Controls.Add(dgvAudit);
            pnlGrid.CustomizableEdges = customizableEdges11;
            pnlGrid.FillColor = Color.FromArgb(24, 24, 27);
            pnlGrid.Location = new Point(16, 156);
            pnlGrid.Name = "pnlGrid";
            pnlGrid.ShadowDecoration.CustomizableEdges = customizableEdges12;
            pnlGrid.Size = new Size(968, 489);
            pnlGrid.TabIndex = 4;
            // 
            // dgvAudit
            // 
            dataGridViewCellStyle1.BackColor = Color.White;
            dgvAudit.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(100, 88, 255);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvAudit.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvAudit.Columns.AddRange(new DataGridViewColumn[] { colTime, colStaff, colRole, colAction, colTarget, colReason, colIP });
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvAudit.DefaultCellStyle = dataGridViewCellStyle3;
            dgvAudit.Dock = DockStyle.Fill;
            dgvAudit.GridColor = Color.FromArgb(231, 229, 255);
            dgvAudit.Location = new Point(0, 0);
            dgvAudit.Name = "dgvAudit";
            dgvAudit.RowHeadersVisible = false;
            dgvAudit.RowHeadersWidth = 51;
            dgvAudit.Size = new Size(968, 489);
            dgvAudit.TabIndex = 0;
            dgvAudit.ThemeStyle.AlternatingRowsStyle.BackColor = Color.White;
            dgvAudit.ThemeStyle.AlternatingRowsStyle.Font = null;
            dgvAudit.ThemeStyle.AlternatingRowsStyle.ForeColor = Color.Empty;
            dgvAudit.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.Empty;
            dgvAudit.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.Empty;
            dgvAudit.ThemeStyle.BackColor = Color.White;
            dgvAudit.ThemeStyle.GridColor = Color.FromArgb(231, 229, 255);
            dgvAudit.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(100, 88, 255);
            dgvAudit.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvAudit.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI", 9F);
            dgvAudit.ThemeStyle.HeaderStyle.ForeColor = Color.White;
            dgvAudit.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvAudit.ThemeStyle.HeaderStyle.Height = 23;
            dgvAudit.ThemeStyle.ReadOnly = false;
            dgvAudit.ThemeStyle.RowsStyle.BackColor = Color.White;
            dgvAudit.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvAudit.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 9F);
            dgvAudit.ThemeStyle.RowsStyle.ForeColor = Color.FromArgb(71, 69, 94);
            dgvAudit.ThemeStyle.RowsStyle.Height = 25;
            dgvAudit.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dgvAudit.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(71, 69, 94);
            // 
            // colTime
            // 
            colTime.DataPropertyName = "Thời gian";
            colTime.HeaderText = "Thời gian";
            colTime.Name = "Thời gian";
            // 
            // colStaff
            // 
            colStaff.DataPropertyName = "Nhân viên";
            colStaff.HeaderText = "Nhân viên";
            colStaff.Name = "Nhân viên";
            // 
            // colRole
            // 
            colRole.DataPropertyName = "Vai trò";
            colRole.HeaderText = "Vai trò";
            colRole.Name = "Vai trò";
            // 
            // colAction
            // 
            colAction.DataPropertyName = "Thao tác";
            colAction.HeaderText = "Thao tác";
            colAction.Name = "Thao tác";
            // 
            // colTarget
            // 
            colTarget.DataPropertyName = "Đối tượng";
            colTarget.HeaderText = "Đối tượng";
            colTarget.Name = "Đối tượng";
            // 
            // colReason
            // 
            colReason.DataPropertyName = "Lý do";
            colReason.HeaderText = "Lý do";
            colReason.Name = "Lý do";
            // 
            // colIP
            // 
            colIP.DataPropertyName = "IP";
            colIP.HeaderText = "IP";
            colIP.Name = "IP";
            // 
            // ucAuditLog
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(39, 39, 42);
            Controls.Add(lblTitle);
            Controls.Add(lblSub);
            Controls.Add(pnlFilter);
            Controls.Add(lblCount);
            Controls.Add(pnlGrid);
            Name = "ucAuditLog";
            Size = new Size(1000, 665);
            pnlFilter.ResumeLayout(false);
            pnlGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvAudit).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private Label lblSub;
        private Guna2Panel pnlFilter;
        private Guna2TextBox txtSearch;
        private Guna2ComboBox cmbAction;
        private Guna2ComboBox cmbUser;
        private Guna2Button btnClear;
        private Label lblCount;
        private Guna2Panel pnlGrid;
        private Guna2DataGridView dgvAudit;
        private DataGridViewTextBoxColumn colTime;
        private DataGridViewTextBoxColumn colStaff;
        private DataGridViewTextBoxColumn colRole;
        private DataGridViewTextBoxColumn colAction;
        private DataGridViewTextBoxColumn colTarget;
        private DataGridViewTextBoxColumn colReason;
        private DataGridViewTextBoxColumn colIP;
    }
}
