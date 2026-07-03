using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace GUI
{
    partial class ucManagers_Admin
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges17 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges18 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges11 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges12 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges13 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges14 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges15 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges16 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges21 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges22 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges19 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges20 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges23 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges24 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle8 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle9 = new DataGridViewCellStyle();
            tblRoot = new TableLayoutPanel();
            pnlSummary = new Guna2Panel();
            tblSummary = new TableLayoutPanel();
            pnlStatTotal = new Guna2Panel();
            lblTotalManagerTitle = new Label();
            lblTotalManagerValue = new Label();
            pnlStatPresent = new Guna2Panel();
            lblPresentTitle = new Label();
            lblPresentValue = new Label();
            pnlStatLeave = new Guna2Panel();
            lblLeaveTitle = new Label();
            lblLeaveValue = new Label();
            btnSwitchRole = new Guna2Button();
            tblMid = new TableLayoutPanel();
            pnlManagerList = new Guna2Panel();
            lblManagerTitle = new Label();
            txtSearchManager = new Guna2TextBox();
            btnAddManager = new Guna2Button();
            btnEditManager = new Guna2Button();
            dgvManagers = new Guna2DataGridView();
            colMgrId = new DataGridViewTextBoxColumn();
            colMgrName = new DataGridViewTextBoxColumn();
            colMgrEmail = new DataGridViewTextBoxColumn();
            colMgrStatus = new DataGridViewTextBoxColumn();
            colMgrPhone = new DataGridViewTextBoxColumn();
            colMgrRole = new DataGridViewTextBoxColumn();
            colMgrStatusRaw = new DataGridViewTextBoxColumn();
            colMgrAuthUid = new DataGridViewTextBoxColumn();
            pnlLeaveRequests = new Guna2Panel();
            lblLeaveReqTitle = new Label();
            btnApproveLeave = new Guna2Button();
            dgvLeaveReq = new Guna2DataGridView();
            colLeaveStaff = new DataGridViewTextBoxColumn();
            colLeaveDate = new DataGridViewTextBoxColumn();
            colLeaveReason = new DataGridViewTextBoxColumn();
            pnlAuditLog = new Guna2Panel();
            lblAuditTitle = new Label();
            dgvAuditLog = new Guna2DataGridView();
            colAuditTime = new DataGridViewTextBoxColumn();
            colAuditManager = new DataGridViewTextBoxColumn();
            colAuditAction = new DataGridViewTextBoxColumn();
            colAuditReason = new DataGridViewTextBoxColumn();
            tblRoot.SuspendLayout();
            pnlSummary.SuspendLayout();
            tblSummary.SuspendLayout();
            pnlStatTotal.SuspendLayout();
            pnlStatPresent.SuspendLayout();
            pnlStatLeave.SuspendLayout();
            tblMid.SuspendLayout();
            pnlManagerList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvManagers).BeginInit();
            pnlLeaveRequests.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvLeaveReq).BeginInit();
            pnlAuditLog.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAuditLog).BeginInit();
            SuspendLayout();
            // 
            // tblRoot
            // 
            tblRoot.BackColor = Color.Transparent;
            tblRoot.ColumnCount = 1;
            tblRoot.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tblRoot.Controls.Add(pnlSummary, 0, 0);
            tblRoot.Controls.Add(tblMid, 0, 1);
            tblRoot.Controls.Add(pnlAuditLog, 0, 2);
            tblRoot.Dock = DockStyle.Fill;
            tblRoot.Location = new Point(0, 0);
            tblRoot.Name = "tblRoot";
            tblRoot.Padding = new Padding(20);
            tblRoot.RowCount = 3;
            tblRoot.RowStyles.Add(new RowStyle(SizeType.Absolute, 110F));
            tblRoot.RowStyles.Add(new RowStyle(SizeType.Percent, 47F));
            tblRoot.RowStyles.Add(new RowStyle(SizeType.Percent, 53F));
            tblRoot.Size = new Size(1000, 665);
            tblRoot.TabIndex = 0;
            // 
            // pnlSummary
            // 
            pnlSummary.BackColor = Color.Transparent;
            pnlSummary.Controls.Add(tblSummary);
            pnlSummary.CustomizableEdges = customizableEdges9;
            pnlSummary.Dock = DockStyle.Fill;
            pnlSummary.Location = new Point(20, 20);
            pnlSummary.Margin = new Padding(0, 0, 0, 16);
            pnlSummary.Name = "pnlSummary";
            pnlSummary.ShadowDecoration.CustomizableEdges = customizableEdges10;
            pnlSummary.Size = new Size(960, 94);
            pnlSummary.TabIndex = 0;
            // 
            // tblSummary
            // 
            tblSummary.BackColor = Color.Transparent;
            tblSummary.ColumnCount = 4;
            tblSummary.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33F));
            tblSummary.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33F));
            tblSummary.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.34F));
            tblSummary.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 280F));
            tblSummary.Controls.Add(pnlStatTotal, 0, 0);
            tblSummary.Controls.Add(pnlStatPresent, 1, 0);
            tblSummary.Controls.Add(pnlStatLeave, 2, 0);
            tblSummary.Controls.Add(btnSwitchRole, 3, 0);
            tblSummary.Dock = DockStyle.Fill;
            tblSummary.Location = new Point(0, 0);
            tblSummary.Name = "tblSummary";
            tblSummary.RowCount = 1;
            tblSummary.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tblSummary.Size = new Size(960, 94);
            tblSummary.TabIndex = 0;
            // 
            // pnlStatTotal
            // 
            pnlStatTotal.BackColor = Color.FromArgb(31, 31, 34);
            pnlStatTotal.BorderRadius = 14;
            pnlStatTotal.Controls.Add(lblTotalManagerTitle);
            pnlStatTotal.Controls.Add(lblTotalManagerValue);
            pnlStatTotal.CustomizableEdges = customizableEdges1;
            pnlStatTotal.Dock = DockStyle.Fill;
            pnlStatTotal.Location = new Point(0, 0);
            pnlStatTotal.Margin = new Padding(0, 0, 10, 0);
            pnlStatTotal.Name = "pnlStatTotal";
            pnlStatTotal.ShadowDecoration.CustomizableEdges = customizableEdges2;
            pnlStatTotal.Size = new Size(216, 94);
            pnlStatTotal.TabIndex = 0;
            // 
            // lblTotalManagerTitle
            // 
            lblTotalManagerTitle.AutoSize = true;
            lblTotalManagerTitle.Font = new Font("Segoe UI", 9F);
            lblTotalManagerTitle.ForeColor = Color.FromArgb(160, 160, 166);
            lblTotalManagerTitle.Location = new Point(18, 18);
            lblTotalManagerTitle.Name = "lblTotalManagerTitle";
            lblTotalManagerTitle.Size = new Size(94, 15);
            lblTotalManagerTitle.TabIndex = 0;
            lblTotalManagerTitle.Text = "Tổng số Quản lý";
            // 
            // lblTotalManagerValue
            // 
            lblTotalManagerValue.AutoSize = true;
            lblTotalManagerValue.Font = new Font("Segoe UI", 17F, FontStyle.Bold);
            lblTotalManagerValue.ForeColor = Color.White;
            lblTotalManagerValue.Location = new Point(18, 42);
            lblTotalManagerValue.Name = "lblTotalManagerValue";
            lblTotalManagerValue.Size = new Size(97, 31);
            lblTotalManagerValue.TabIndex = 1;
            lblTotalManagerValue.Text = "0 người";
            // 
            // pnlStatPresent
            // 
            pnlStatPresent.BackColor = Color.FromArgb(31, 31, 34);
            pnlStatPresent.BorderRadius = 14;
            pnlStatPresent.Controls.Add(lblPresentTitle);
            pnlStatPresent.Controls.Add(lblPresentValue);
            pnlStatPresent.CustomizableEdges = customizableEdges3;
            pnlStatPresent.Dock = DockStyle.Fill;
            pnlStatPresent.Location = new Point(226, 0);
            pnlStatPresent.Margin = new Padding(0, 0, 10, 0);
            pnlStatPresent.Name = "pnlStatPresent";
            pnlStatPresent.ShadowDecoration.CustomizableEdges = customizableEdges4;
            pnlStatPresent.Size = new Size(216, 94);
            pnlStatPresent.TabIndex = 1;
            // 
            // lblPresentTitle
            // 
            lblPresentTitle.AutoSize = true;
            lblPresentTitle.Font = new Font("Segoe UI", 9F);
            lblPresentTitle.ForeColor = Color.FromArgb(160, 160, 166);
            lblPresentTitle.Location = new Point(18, 18);
            lblPresentTitle.Name = "lblPresentTitle";
            lblPresentTitle.Size = new Size(97, 15);
            lblPresentTitle.TabIndex = 0;
            lblPresentTitle.Text = "Đang làm việc";
            // 
            // lblPresentValue
            // 
            lblPresentValue.AutoSize = true;
            lblPresentValue.Font = new Font("Segoe UI", 17F, FontStyle.Bold);
            lblPresentValue.ForeColor = Color.FromArgb(34, 197, 94);
            lblPresentValue.Location = new Point(18, 42);
            lblPresentValue.Name = "lblPresentValue";
            lblPresentValue.Size = new Size(97, 31);
            lblPresentValue.TabIndex = 1;
            lblPresentValue.Text = "0 người";
            // 
            // pnlStatLeave
            // 
            pnlStatLeave.BackColor = Color.FromArgb(31, 31, 34);
            pnlStatLeave.BorderRadius = 14;
            pnlStatLeave.Controls.Add(lblLeaveTitle);
            pnlStatLeave.Controls.Add(lblLeaveValue);
            pnlStatLeave.CustomizableEdges = customizableEdges5;
            pnlStatLeave.Dock = DockStyle.Fill;
            pnlStatLeave.Location = new Point(452, 0);
            pnlStatLeave.Margin = new Padding(0, 0, 10, 0);
            pnlStatLeave.Name = "pnlStatLeave";
            pnlStatLeave.ShadowDecoration.CustomizableEdges = customizableEdges6;
            pnlStatLeave.Size = new Size(216, 94);
            pnlStatLeave.TabIndex = 2;
            // 
            // lblLeaveTitle
            // 
            lblLeaveTitle.AutoSize = true;
            lblLeaveTitle.Font = new Font("Segoe UI", 9F);
            lblLeaveTitle.ForeColor = Color.FromArgb(160, 160, 166);
            lblLeaveTitle.Location = new Point(18, 18);
            lblLeaveTitle.Name = "lblLeaveTitle";
            lblLeaveTitle.Size = new Size(93, 15);
            lblLeaveTitle.TabIndex = 0;
            lblLeaveTitle.Text = "Quản lý xin nghỉ";
            // 
            // lblLeaveValue
            // 
            lblLeaveValue.AutoSize = true;
            lblLeaveValue.Font = new Font("Segoe UI", 17F, FontStyle.Bold);
            lblLeaveValue.ForeColor = Color.FromArgb(245, 158, 11);
            lblLeaveValue.Location = new Point(18, 42);
            lblLeaveValue.Name = "lblLeaveValue";
            lblLeaveValue.Size = new Size(97, 31);
            lblLeaveValue.TabIndex = 1;
            lblLeaveValue.Text = "0 người";
            // 
            // btnSwitchRole
            // 
            btnSwitchRole.BorderRadius = 14;
            btnSwitchRole.Cursor = Cursors.Hand;
            btnSwitchRole.CustomizableEdges = customizableEdges7;
            btnSwitchRole.Dock = DockStyle.Fill;
            btnSwitchRole.FillColor = Color.FromArgb(245, 158, 11);
            btnSwitchRole.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnSwitchRole.ForeColor = Color.FromArgb(33, 33, 36);
            btnSwitchRole.HoverState.FillColor = Color.FromArgb(255, 173, 36);
            btnSwitchRole.Location = new Point(678, 0);
            btnSwitchRole.Margin = new Padding(0);
            btnSwitchRole.Name = "btnSwitchRole";
            btnSwitchRole.ShadowDecoration.CustomizableEdges = customizableEdges8;
            btnSwitchRole.Size = new Size(282, 94);
            btnSwitchRole.TabIndex = 6;
            btnSwitchRole.Text = "Đóng vai Quản lý";
            btnSwitchRole.Click += BtnSwitchRole_Click;
            // 
            // tblMid
            // 
            tblMid.BackColor = Color.Transparent;
            tblMid.ColumnCount = 2;
            tblMid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60F));
            tblMid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            tblMid.Controls.Add(pnlManagerList, 0, 0);
            tblMid.Controls.Add(pnlLeaveRequests, 1, 0);
            tblMid.Dock = DockStyle.Fill;
            tblMid.Location = new Point(20, 130);
            tblMid.Margin = new Padding(0, 0, 0, 16);
            tblMid.Name = "tblMid";
            tblMid.RowCount = 1;
            tblMid.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tblMid.Size = new Size(960, 226);
            tblMid.TabIndex = 1;
            // 
            // pnlManagerList
            // 
            pnlManagerList.BackColor = Color.FromArgb(31, 31, 34);
            pnlManagerList.BorderRadius = 14;
            pnlManagerList.Controls.Add(lblManagerTitle);
            pnlManagerList.Controls.Add(txtSearchManager);
            pnlManagerList.Controls.Add(btnAddManager);
            pnlManagerList.Controls.Add(btnEditManager);
            pnlManagerList.Controls.Add(dgvManagers);
            pnlManagerList.CustomizableEdges = customizableEdges17;
            pnlManagerList.Dock = DockStyle.Fill;
            pnlManagerList.Location = new Point(0, 0);
            pnlManagerList.Margin = new Padding(0, 0, 10, 0);
            pnlManagerList.Name = "pnlManagerList";
            pnlManagerList.ShadowDecoration.CustomizableEdges = customizableEdges18;
            pnlManagerList.Size = new Size(566, 226);
            pnlManagerList.TabIndex = 1;
            // 
            // lblManagerTitle
            // 
            lblManagerTitle.AutoSize = true;
            lblManagerTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblManagerTitle.ForeColor = Color.White;
            lblManagerTitle.Location = new Point(18, 16);
            lblManagerTitle.Name = "lblManagerTitle";
            lblManagerTitle.Size = new Size(136, 20);
            lblManagerTitle.TabIndex = 0;
            lblManagerTitle.Text = "Hồ sơ Quản lý";
            lblManagerTitle.Click += LblManagerTitle_Click;
            // 
            // txtSearchManager
            // 
            txtSearchManager.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            txtSearchManager.BorderColor = Color.FromArgb(63, 63, 70);
            txtSearchManager.BorderRadius = 8;
            txtSearchManager.CustomizableEdges = customizableEdges11;
            txtSearchManager.DefaultText = "";
            txtSearchManager.FillColor = Color.FromArgb(24, 24, 27);
            txtSearchManager.FocusedState.BorderColor = Color.FromArgb(31, 138, 154);
            txtSearchManager.Font = new Font("Segoe UI", 9F);
            txtSearchManager.ForeColor = Color.FromArgb(220, 220, 225);
            txtSearchManager.HoverState.BorderColor = Color.FromArgb(120, 120, 130);
            txtSearchManager.Location = new Point(166, 14);
            txtSearchManager.Name = "txtSearchManager";
            txtSearchManager.PasswordChar = '\0';
            txtSearchManager.PlaceholderForeColor = Color.FromArgb(110, 110, 120);
            txtSearchManager.PlaceholderText = "Tìm tên / email / trạng thái...";
            txtSearchManager.SelectedText = "";
            txtSearchManager.ShadowDecoration.CustomizableEdges = customizableEdges12;
            txtSearchManager.Size = new Size(180, 30);
            txtSearchManager.TabIndex = 2;
            // 
            // btnAddManager
            // 
            btnAddManager.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            btnAddManager.BorderRadius = 8;
            btnAddManager.Cursor = Cursors.Hand;
            btnAddManager.CustomizableEdges = customizableEdges13;
            btnAddManager.FillColor = Color.FromArgb(31, 138, 154);
            btnAddManager.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnAddManager.ForeColor = Color.White;
            btnAddManager.HoverState.FillColor = Color.FromArgb(45, 158, 174);
            btnAddManager.Location = new Point(354, 13);
            btnAddManager.Name = "btnAddManager";
            btnAddManager.ShadowDecoration.CustomizableEdges = customizableEdges14;
            btnAddManager.Size = new Size(128, 30);
            btnAddManager.TabIndex = 1;
            btnAddManager.Text = "+ Thêm Quản lý";
            btnAddManager.Click += BtnAddManager_Click;
            // 
            // btnEditManager
            // 
            btnEditManager.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            btnEditManager.BorderColor = Color.FromArgb(80, 80, 90);
            btnEditManager.BorderRadius = 8;
            btnEditManager.BorderThickness = 1;
            btnEditManager.Cursor = Cursors.Hand;
            btnEditManager.CustomizableEdges = customizableEdges15;
            btnEditManager.FillColor = Color.Transparent;
            btnEditManager.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnEditManager.ForeColor = Color.FromArgb(220, 220, 225);
            btnEditManager.HoverState.FillColor = Color.FromArgb(45, 45, 50);
            btnEditManager.Location = new Point(492, 13);
            btnEditManager.Name = "btnEditManager";
            btnEditManager.ShadowDecoration.CustomizableEdges = customizableEdges16;
            btnEditManager.Size = new Size(66, 30);
            btnEditManager.TabIndex = 0;
            btnEditManager.Text = "Sửa";
            btnEditManager.Click += BtnEditManager_Click;
            // 
            // dgvManagers
            // 
            dataGridViewCellStyle1.BackColor = Color.FromArgb(24, 24, 27);
            dataGridViewCellStyle1.ForeColor = Color.FromArgb(220, 220, 225);
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(31, 138, 154);
            dataGridViewCellStyle1.SelectionForeColor = Color.FromArgb(240, 240, 245);
            dgvManagers.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvManagers.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvManagers.BackgroundColor = Color.FromArgb(24, 24, 27);
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(31, 31, 34);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(160, 160, 166);
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(31, 31, 34);
            dataGridViewCellStyle2.SelectionForeColor = Color.FromArgb(160, 160, 166);
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvManagers.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvManagers.ColumnHeadersHeight = 32;
            dgvManagers.Columns.AddRange(new DataGridViewColumn[] { colMgrId, colMgrName, colMgrEmail, colMgrStatus, colMgrPhone, colMgrRole, colMgrStatusRaw, colMgrAuthUid });
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.FromArgb(24, 24, 27);
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(220, 220, 225);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(31, 138, 154);
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(240, 240, 245);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvManagers.DefaultCellStyle = dataGridViewCellStyle3;
            dgvManagers.GridColor = Color.FromArgb(45, 45, 48);
            dgvManagers.Location = new Point(18, 56);
            dgvManagers.MultiSelect = false;
            dgvManagers.Name = "dgvManagers";
            dgvManagers.ReadOnly = true;
            dgvManagers.RowHeadersVisible = false;
            dgvManagers.RowTemplate.Height = 28;
            dgvManagers.Size = new Size(545, 167);
            dgvManagers.TabIndex = 1;
            dgvManagers.ThemeStyle.AlternatingRowsStyle.BackColor = Color.FromArgb(24, 24, 27);
            dgvManagers.ThemeStyle.AlternatingRowsStyle.Font = null;
            dgvManagers.ThemeStyle.AlternatingRowsStyle.ForeColor = Color.FromArgb(220, 220, 225);
            dgvManagers.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.Empty;
            dgvManagers.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.Empty;
            dgvManagers.ThemeStyle.BackColor = Color.FromArgb(24, 24, 27);
            dgvManagers.ThemeStyle.GridColor = Color.FromArgb(45, 45, 48);
            dgvManagers.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(31, 31, 34);
            dgvManagers.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvManagers.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dgvManagers.ThemeStyle.HeaderStyle.ForeColor = Color.FromArgb(160, 160, 166);
            dgvManagers.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvManagers.ThemeStyle.HeaderStyle.Height = 32;
            dgvManagers.ThemeStyle.ReadOnly = true;
            dgvManagers.ThemeStyle.RowsStyle.BackColor = Color.FromArgb(24, 24, 27);
            dgvManagers.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvManagers.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 9F);
            dgvManagers.ThemeStyle.RowsStyle.ForeColor = Color.FromArgb(220, 220, 225);
            dgvManagers.ThemeStyle.RowsStyle.Height = 28;
            dgvManagers.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(31, 138, 154);
            dgvManagers.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(240, 240, 245);
            dgvManagers.CellDoubleClick += DgvManagers_CellDoubleClick;
            // 
            // colMgrId
            // 
            colMgrId.DataPropertyName = "Mã QL";
            colMgrId.HeaderText = "Mã QL";
            colMgrId.Name = "colMgrId";
            colMgrId.ReadOnly = true;
            // 
            // colMgrName
            // 
            colMgrName.DataPropertyName = "Họ tên";
            colMgrName.HeaderText = "Họ tên";
            colMgrName.Name = "colMgrName";
            colMgrName.ReadOnly = true;
            // 
            // colMgrEmail
            // 
            colMgrEmail.DataPropertyName = "Email";
            colMgrEmail.HeaderText = "Email";
            colMgrEmail.Name = "colMgrEmail";
            colMgrEmail.ReadOnly = true;
            // 
            // colMgrStatus
            // 
            colMgrStatus.DataPropertyName = "Trạng thái";
            colMgrStatus.HeaderText = "Trạng thái";
            colMgrStatus.Name = "colMgrStatus";
            colMgrStatus.ReadOnly = true;
            // 
            // colMgrPhone
            // 
            colMgrPhone.DataPropertyName = "Số điện thoại";
            colMgrPhone.HeaderText = "Số điện thoại";
            colMgrPhone.Name = "colMgrPhone";
            colMgrPhone.ReadOnly = true;
            colMgrPhone.Visible = false;
            // 
            // colMgrRole
            // 
            colMgrRole.DataPropertyName = "VaiTro";
            colMgrRole.HeaderText = "VaiTro";
            colMgrRole.Name = "colMgrRole";
            colMgrRole.ReadOnly = true;
            colMgrRole.Visible = false;
            // 
            // colMgrStatusRaw
            // 
            colMgrStatusRaw.DataPropertyName = "TrangThaiRaw";
            colMgrStatusRaw.HeaderText = "TrangThaiRaw";
            colMgrStatusRaw.Name = "colMgrStatusRaw";
            colMgrStatusRaw.ReadOnly = true;
            colMgrStatusRaw.Visible = false;
            // 
            // colMgrAuthUid
            // 
            colMgrAuthUid.DataPropertyName = "AuthUid";
            colMgrAuthUid.HeaderText = "AuthUid";
            colMgrAuthUid.Name = "colMgrAuthUid";
            colMgrAuthUid.ReadOnly = true;
            colMgrAuthUid.Visible = false;
            // 
            // pnlLeaveRequests
            // 
            pnlLeaveRequests.BackColor = Color.FromArgb(31, 31, 34);
            pnlLeaveRequests.BorderRadius = 14;
            pnlLeaveRequests.Controls.Add(lblLeaveReqTitle);
            pnlLeaveRequests.Controls.Add(btnApproveLeave);
            pnlLeaveRequests.Controls.Add(dgvLeaveReq);
            pnlLeaveRequests.CustomizableEdges = customizableEdges21;
            pnlLeaveRequests.Dock = DockStyle.Fill;
            pnlLeaveRequests.Location = new Point(576, 0);
            pnlLeaveRequests.Margin = new Padding(0);
            pnlLeaveRequests.Name = "pnlLeaveRequests";
            pnlLeaveRequests.ShadowDecoration.CustomizableEdges = customizableEdges22;
            pnlLeaveRequests.Size = new Size(384, 226);
            pnlLeaveRequests.TabIndex = 3;
            // 
            // lblLeaveReqTitle
            // 
            lblLeaveReqTitle.AutoSize = true;
            lblLeaveReqTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblLeaveReqTitle.ForeColor = Color.White;
            lblLeaveReqTitle.Location = new Point(18, 16);
            lblLeaveReqTitle.Name = "lblLeaveReqTitle";
            lblLeaveReqTitle.Size = new Size(128, 20);
            lblLeaveReqTitle.TabIndex = 0;
            lblLeaveReqTitle.Text = "Đơn xin nghỉ";
            lblLeaveReqTitle.Click += LblLeaveReqTitle_Click;
            // 
            // btnApproveLeave
            // 
            btnApproveLeave.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnApproveLeave.BorderRadius = 8;
            btnApproveLeave.Cursor = Cursors.Hand;
            btnApproveLeave.CustomizableEdges = customizableEdges19;
            btnApproveLeave.FillColor = Color.FromArgb(34, 197, 94);
            btnApproveLeave.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnApproveLeave.ForeColor = Color.White;
            btnApproveLeave.HoverState.FillColor = Color.FromArgb(50, 217, 110);
            btnApproveLeave.Location = new Point(464, 14);
            btnApproveLeave.Name = "btnApproveLeave";
            btnApproveLeave.ShadowDecoration.CustomizableEdges = customizableEdges20;
            btnApproveLeave.Size = new Size(82, 28);
            btnApproveLeave.TabIndex = 0;
            btnApproveLeave.Text = "Duyệt (0)";
            btnApproveLeave.Click += BtnApproveLeave_Click;
            // 
            // dgvLeaveReq
            // 
            dgvLeaveReq.AllowUserToAddRows = false;
            dgvLeaveReq.AllowUserToResizeRows = false;
            dataGridViewCellStyle4.BackColor = Color.FromArgb(24, 24, 27);
            dataGridViewCellStyle4.ForeColor = Color.FromArgb(220, 220, 225);
            dgvLeaveReq.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            dgvLeaveReq.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvLeaveReq.BackgroundColor = Color.FromArgb(24, 24, 27);
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = Color.FromArgb(31, 31, 34);
            dataGridViewCellStyle5.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dataGridViewCellStyle5.ForeColor = Color.FromArgb(160, 160, 166);
            dataGridViewCellStyle5.SelectionBackColor = Color.FromArgb(31, 31, 34);
            dataGridViewCellStyle5.SelectionForeColor = Color.FromArgb(160, 160, 166);
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.True;
            dgvLeaveReq.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            dgvLeaveReq.ColumnHeadersHeight = 17;
            dgvLeaveReq.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dgvLeaveReq.Columns.AddRange(new DataGridViewColumn[] { colLeaveStaff, colLeaveDate, colLeaveReason });
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = Color.FromArgb(24, 24, 27);
            dataGridViewCellStyle6.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle6.ForeColor = Color.FromArgb(220, 220, 225);
            dataGridViewCellStyle6.SelectionBackColor = Color.FromArgb(31, 138, 154);
            dataGridViewCellStyle6.SelectionForeColor = Color.FromArgb(240, 240, 245);
            dataGridViewCellStyle6.WrapMode = DataGridViewTriState.False;
            dgvLeaveReq.DefaultCellStyle = dataGridViewCellStyle6;
            dgvLeaveReq.GridColor = Color.FromArgb(45, 45, 48);
            dgvLeaveReq.Location = new Point(18, 56);
            dgvLeaveReq.MultiSelect = false;
            dgvLeaveReq.Name = "dgvLeaveReq";
            dgvLeaveReq.ReadOnly = true;
            dgvLeaveReq.RowHeadersVisible = false;
            dgvLeaveReq.RowTemplate.Height = 28;
            dgvLeaveReq.Size = new Size(363, 167);
            dgvLeaveReq.TabIndex = 1;
            dgvLeaveReq.ThemeStyle.AlternatingRowsStyle.BackColor = Color.FromArgb(24, 24, 27);
            dgvLeaveReq.ThemeStyle.AlternatingRowsStyle.Font = null;
            dgvLeaveReq.ThemeStyle.AlternatingRowsStyle.ForeColor = Color.FromArgb(220, 220, 225);
            dgvLeaveReq.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.Empty;
            dgvLeaveReq.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.Empty;
            dgvLeaveReq.ThemeStyle.BackColor = Color.FromArgb(24, 24, 27);
            dgvLeaveReq.ThemeStyle.GridColor = Color.FromArgb(45, 45, 48);
            dgvLeaveReq.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(31, 31, 34);
            dgvLeaveReq.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvLeaveReq.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dgvLeaveReq.ThemeStyle.HeaderStyle.ForeColor = Color.FromArgb(160, 160, 166);
            dgvLeaveReq.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dgvLeaveReq.ThemeStyle.HeaderStyle.Height = 17;
            dgvLeaveReq.ThemeStyle.ReadOnly = true;
            dgvLeaveReq.ThemeStyle.RowsStyle.BackColor = Color.FromArgb(24, 24, 27);
            dgvLeaveReq.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvLeaveReq.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 9F);
            dgvLeaveReq.ThemeStyle.RowsStyle.ForeColor = Color.FromArgb(220, 220, 225);
            dgvLeaveReq.ThemeStyle.RowsStyle.Height = 28;
            dgvLeaveReq.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(31, 138, 154);
            dgvLeaveReq.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(240, 240, 245);
            dgvLeaveReq.CellDoubleClick += DgvLeaveReq_CellDoubleClick;
            // 
            // colLeaveStaff
            // 
            colLeaveStaff.DataPropertyName = "Nhân viên";
            colLeaveStaff.HeaderText = "Nhân viên";
            colLeaveStaff.Name = "colLeaveStaff";
            colLeaveStaff.ReadOnly = true;
            // 
            // colLeaveDate
            // 
            colLeaveDate.DataPropertyName = "Ngày nghỉ";
            colLeaveDate.HeaderText = "Ngày nghỉ";
            colLeaveDate.Name = "colLeaveDate";
            colLeaveDate.ReadOnly = true;
            // 
            // colLeaveReason
            // 
            colLeaveReason.DataPropertyName = "Lý do";
            colLeaveReason.HeaderText = "Lý do";
            colLeaveReason.Name = "colLeaveReason";
            colLeaveReason.ReadOnly = true;
            // 
            // pnlAuditLog
            // 
            pnlAuditLog.BackColor = Color.FromArgb(31, 31, 34);
            pnlAuditLog.BorderRadius = 14;
            pnlAuditLog.Controls.Add(lblAuditTitle);
            pnlAuditLog.Controls.Add(dgvAuditLog);
            pnlAuditLog.CustomizableEdges = customizableEdges23;
            pnlAuditLog.Dock = DockStyle.Fill;
            pnlAuditLog.Location = new Point(20, 372);
            pnlAuditLog.Margin = new Padding(0);
            pnlAuditLog.Name = "pnlAuditLog";
            pnlAuditLog.ShadowDecoration.CustomizableEdges = customizableEdges24;
            pnlAuditLog.Size = new Size(960, 273);
            pnlAuditLog.TabIndex = 4;
            // 
            // lblAuditTitle
            // 
            lblAuditTitle.AutoSize = true;
            lblAuditTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblAuditTitle.ForeColor = Color.FromArgb(245, 158, 11);
            lblAuditTitle.Location = new Point(18, 16);
            lblAuditTitle.Name = "lblAuditTitle";
            lblAuditTitle.Size = new Size(234, 20);
            lblAuditTitle.TabIndex = 0;
            lblAuditTitle.Text = "Lịch sử thao tác của Quản lý";
            lblAuditTitle.Click += LblAuditTitle_Click;
            // 
            // dgvAuditLog
            // 
            dataGridViewCellStyle7.BackColor = Color.FromArgb(24, 24, 27);
            dataGridViewCellStyle7.ForeColor = Color.FromArgb(220, 220, 225);
            dataGridViewCellStyle7.SelectionBackColor = Color.FromArgb(31, 138, 154);
            dataGridViewCellStyle7.SelectionForeColor = Color.FromArgb(240, 240, 245);
            dgvAuditLog.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle7;
            dgvAuditLog.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvAuditLog.BackgroundColor = Color.FromArgb(24, 24, 27);
            dataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = Color.FromArgb(31, 31, 34);
            dataGridViewCellStyle8.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dataGridViewCellStyle8.ForeColor = Color.FromArgb(160, 160, 166);
            dataGridViewCellStyle8.SelectionBackColor = Color.FromArgb(31, 31, 34);
            dataGridViewCellStyle8.SelectionForeColor = Color.FromArgb(160, 160, 166);
            dataGridViewCellStyle8.WrapMode = DataGridViewTriState.True;
            dgvAuditLog.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
            dgvAuditLog.ColumnHeadersHeight = 32;
            dgvAuditLog.Columns.AddRange(new DataGridViewColumn[] { colAuditTime, colAuditManager, colAuditAction, colAuditReason });
            dataGridViewCellStyle9.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = Color.FromArgb(24, 24, 27);
            dataGridViewCellStyle9.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle9.ForeColor = Color.FromArgb(220, 220, 225);
            dataGridViewCellStyle9.SelectionBackColor = Color.FromArgb(31, 138, 154);
            dataGridViewCellStyle9.SelectionForeColor = Color.FromArgb(240, 240, 245);
            dataGridViewCellStyle9.WrapMode = DataGridViewTriState.False;
            dgvAuditLog.DefaultCellStyle = dataGridViewCellStyle9;
            dgvAuditLog.GridColor = Color.FromArgb(45, 45, 48);
            dgvAuditLog.Location = new Point(18, 50);
            dgvAuditLog.MultiSelect = false;
            dgvAuditLog.Name = "dgvAuditLog";
            dgvAuditLog.ReadOnly = true;
            dgvAuditLog.RowHeadersVisible = false;
            dgvAuditLog.RowTemplate.DefaultCellStyle.SelectionBackColor = Color.FromArgb(31, 138, 154);
            dgvAuditLog.RowTemplate.DefaultCellStyle.SelectionForeColor = Color.FromArgb(240, 240, 245);
            dgvAuditLog.RowTemplate.Height = 28;
            dgvAuditLog.Size = new Size(939, 223);
            dgvAuditLog.TabIndex = 3;
            dgvAuditLog.ThemeStyle.AlternatingRowsStyle.BackColor = Color.FromArgb(24, 24, 27);
            dgvAuditLog.ThemeStyle.AlternatingRowsStyle.Font = null;
            dgvAuditLog.ThemeStyle.AlternatingRowsStyle.ForeColor = Color.FromArgb(220, 220, 225);
            dgvAuditLog.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.Empty;
            dgvAuditLog.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.Empty;
            dgvAuditLog.ThemeStyle.BackColor = Color.FromArgb(24, 24, 27);
            dgvAuditLog.ThemeStyle.GridColor = Color.FromArgb(45, 45, 48);
            dgvAuditLog.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(31, 31, 34);
            dgvAuditLog.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvAuditLog.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dgvAuditLog.ThemeStyle.HeaderStyle.ForeColor = Color.FromArgb(160, 160, 166);
            dgvAuditLog.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvAuditLog.ThemeStyle.HeaderStyle.Height = 32;
            dgvAuditLog.ThemeStyle.ReadOnly = true;
            dgvAuditLog.ThemeStyle.RowsStyle.BackColor = Color.FromArgb(24, 24, 27);
            dgvAuditLog.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvAuditLog.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 9F);
            dgvAuditLog.ThemeStyle.RowsStyle.ForeColor = Color.FromArgb(220, 220, 225);
            dgvAuditLog.ThemeStyle.RowsStyle.Height = 28;
            dgvAuditLog.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(180, 60, 60);
            dgvAuditLog.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(240, 240, 245);
            dgvAuditLog.CellDoubleClick += DgvAuditLog_CellDoubleClick;
            // 
            // colAuditTime
            // 
            colAuditTime.DataPropertyName = "Thời gian";
            colAuditTime.HeaderText = "Thời gian";
            colAuditTime.Name = "colAuditTime";
            colAuditTime.ReadOnly = true;
            // 
            // colAuditManager
            // 
            colAuditManager.DataPropertyName = "Quản lý";
            colAuditManager.HeaderText = "Quản lý";
            colAuditManager.Name = "colAuditManager";
            colAuditManager.ReadOnly = true;
            // 
            // colAuditAction
            // 
            colAuditAction.DataPropertyName = "Hành động";
            colAuditAction.HeaderText = "Hành động";
            colAuditAction.Name = "colAuditAction";
            colAuditAction.ReadOnly = true;
            // 
            // colAuditReason
            // 
            colAuditReason.DataPropertyName = "Lý do";
            colAuditReason.HeaderText = "Lý do";
            colAuditReason.Name = "colAuditReason";
            colAuditReason.ReadOnly = true;
            // 
            // ucManagers_Admin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(39, 39, 42);
            Controls.Add(tblRoot);
            Name = "ucManagers_Admin";
            Size = new Size(1000, 665);
            Load += UcManagers_Admin_Load;
            tblRoot.ResumeLayout(false);
            pnlSummary.ResumeLayout(false);
            tblSummary.ResumeLayout(false);
            pnlStatTotal.ResumeLayout(false);
            pnlStatTotal.PerformLayout();
            pnlStatPresent.ResumeLayout(false);
            pnlStatPresent.PerformLayout();
            pnlStatLeave.ResumeLayout(false);
            pnlStatLeave.PerformLayout();
            tblMid.ResumeLayout(false);
            pnlManagerList.ResumeLayout(false);
            pnlManagerList.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvManagers).EndInit();
            pnlLeaveRequests.ResumeLayout(false);
            pnlLeaveRequests.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvLeaveReq).EndInit();
            pnlAuditLog.ResumeLayout(false);
            pnlAuditLog.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAuditLog).EndInit();
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
            dgv.ReadOnly = true;
            dgv.RowHeadersVisible = false;
            dgv.RowTemplate.DefaultCellStyle.SelectionBackColor = Color.FromArgb(31, 138, 154);
            dgv.RowTemplate.DefaultCellStyle.SelectionForeColor = Color.FromArgb(240, 240, 245);
            dgv.RowTemplate.Height = 28;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DgvDarkScroll.Apply(dgv);
        }

        #endregion

        private TableLayoutPanel tblRoot;     // bảng gốc: summary / giữa / audit
        private TableLayoutPanel tblSummary;   // 3 thẻ co giãn + nút cố định 280px
        private TableLayoutPanel tblMid;       // 2 cột: danh sách QL | đơn xin nghỉ
        private Guna2Panel pnlSummary;
        private Guna2Panel pnlStatTotal;
        private Label lblTotalManagerTitle;
        private Label lblTotalManagerValue;
        private Guna2Panel pnlStatPresent;
        private Label lblPresentTitle;
        private Label lblPresentValue;
        private Guna2Panel pnlStatLeave;
        private Label lblLeaveTitle;
        private Label lblLeaveValue;
        private Guna2Button btnSwitchRole;

        private Guna2Panel pnlManagerList;
        private Label lblManagerTitle;
        private Guna2Button btnAddManager;
        private Guna2Button btnEditManager;
        private Guna2DataGridView dgvManagers;
        private DataGridViewTextBoxColumn colMgrId;
        private DataGridViewTextBoxColumn colMgrName;
        private DataGridViewTextBoxColumn colMgrEmail;
        private DataGridViewTextBoxColumn colMgrStatus;
        private DataGridViewTextBoxColumn colMgrPhone;
        private DataGridViewTextBoxColumn colMgrRole;
        private DataGridViewTextBoxColumn colMgrStatusRaw;
        private DataGridViewTextBoxColumn colMgrAuthUid;
        private Guna2TextBox txtSearchManager;

        private Guna2Panel pnlLeaveRequests;
        private Label lblLeaveReqTitle;
        private Guna2Button btnApproveLeave;
        private Guna2DataGridView dgvLeaveReq;
        private DataGridViewTextBoxColumn colLeaveStaff;
        private DataGridViewTextBoxColumn colLeaveDate;
        private DataGridViewTextBoxColumn colLeaveReason;

        private Guna2Panel pnlAuditLog;
        private Label lblAuditTitle;
        private Guna2DataGridView dgvAuditLog;
        private DataGridViewTextBoxColumn colAuditTime;
        private DataGridViewTextBoxColumn colAuditManager;
        private DataGridViewTextBoxColumn colAuditAction;
        private DataGridViewTextBoxColumn colAuditReason;
    }
}
