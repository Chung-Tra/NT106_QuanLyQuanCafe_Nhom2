using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace GUI
{
    partial class ucAdmin_Managers
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges15 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges16 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges11 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges12 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges13 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges14 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges19 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges20 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges17 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges18 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges21 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges22 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            pnlSummary = new Guna2Panel();
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
            pnlManagerList = new Guna2Panel();
            lblManagerTitle = new Label();
            btnAddManager = new Guna2Button();
            btnEditManager = new Guna2Button();
            dgvManagers = new Guna2DataGridView();
            pnlLeaveRequests = new Guna2Panel();
            lblLeaveReqTitle = new Label();
            btnApproveLeave = new Guna2Button();
            lstLeaveReq = new ListBox();
            pnlAuditLog = new Guna2Panel();
            lblAuditTitle = new Label();
            dgvAuditLog = new Guna2DataGridView();
            pnlSummary.SuspendLayout();
            pnlStatTotal.SuspendLayout();
            pnlStatPresent.SuspendLayout();
            pnlStatLeave.SuspendLayout();
            pnlManagerList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvManagers).BeginInit();
            pnlLeaveRequests.SuspendLayout();
            pnlAuditLog.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAuditLog).BeginInit();
            SuspendLayout();
            // 
            // pnlSummary
            // 
            pnlSummary.BackColor = Color.Transparent;
            pnlSummary.Controls.Add(pnlStatTotal);
            pnlSummary.Controls.Add(pnlStatPresent);
            pnlSummary.Controls.Add(pnlStatLeave);
            pnlSummary.Controls.Add(btnSwitchRole);
            pnlSummary.CustomizableEdges = customizableEdges9;
            pnlSummary.Location = new Point(20, 20);
            pnlSummary.Name = "pnlSummary";
            pnlSummary.ShadowDecoration.CustomizableEdges = customizableEdges10;
            pnlSummary.Size = new Size(920, 100);
            pnlSummary.TabIndex = 0;
            // 
            // pnlStatTotal
            // 
            pnlStatTotal.BackColor = Color.FromArgb(31, 31, 34);
            pnlStatTotal.BorderRadius = 14;
            pnlStatTotal.Controls.Add(lblTotalManagerTitle);
            pnlStatTotal.Controls.Add(lblTotalManagerValue);
            pnlStatTotal.CustomizableEdges = customizableEdges1;
            pnlStatTotal.Location = new Point(0, 0);
            pnlStatTotal.Name = "pnlStatTotal";
            pnlStatTotal.ShadowDecoration.CustomizableEdges = customizableEdges2;
            pnlStatTotal.Size = new Size(200, 100);
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
            pnlStatPresent.Location = new Point(210, 0);
            pnlStatPresent.Name = "pnlStatPresent";
            pnlStatPresent.ShadowDecoration.CustomizableEdges = customizableEdges4;
            pnlStatPresent.Size = new Size(200, 100);
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
            lblPresentTitle.Text = "Đang làm việc \U0001f7e2";
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
            pnlStatLeave.Location = new Point(420, 0);
            pnlStatLeave.Name = "pnlStatLeave";
            pnlStatLeave.ShadowDecoration.CustomizableEdges = customizableEdges6;
            pnlStatLeave.Size = new Size(200, 100);
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
            btnSwitchRole.FillColor = Color.FromArgb(245, 158, 11);
            btnSwitchRole.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnSwitchRole.ForeColor = Color.FromArgb(33, 33, 36);
            btnSwitchRole.HoverState.FillColor = Color.FromArgb(255, 173, 36);
            btnSwitchRole.Location = new Point(640, 0);
            btnSwitchRole.Name = "btnSwitchRole";
            btnSwitchRole.ShadowDecoration.CustomizableEdges = customizableEdges8;
            btnSwitchRole.Size = new Size(280, 100);
            btnSwitchRole.TabIndex = 6;
            btnSwitchRole.Text = "⚡  Đóng vai Quản lý";
            // 
            // pnlManagerList
            // 
            pnlManagerList.BackColor = Color.FromArgb(31, 31, 34);
            pnlManagerList.BorderRadius = 14;
            pnlManagerList.Controls.Add(lblManagerTitle);
            pnlManagerList.Controls.Add(btnAddManager);
            pnlManagerList.Controls.Add(btnEditManager);
            pnlManagerList.Controls.Add(dgvManagers);
            pnlManagerList.CustomizableEdges = customizableEdges15;
            pnlManagerList.Location = new Point(20, 140);
            pnlManagerList.Name = "pnlManagerList";
            pnlManagerList.ShadowDecoration.CustomizableEdges = customizableEdges16;
            pnlManagerList.Size = new Size(560, 240);
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
            lblManagerTitle.Text = "📇  Hồ sơ Quản lý";
            // 
            // btnAddManager
            // 
            btnAddManager.BorderRadius = 8;
            btnAddManager.Cursor = Cursors.Hand;
            btnAddManager.CustomizableEdges = customizableEdges11;
            btnAddManager.FillColor = Color.FromArgb(31, 138, 154);
            btnAddManager.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnAddManager.ForeColor = Color.White;
            btnAddManager.HoverState.FillColor = Color.FromArgb(45, 158, 174);
            btnAddManager.Location = new Point(365, 14);
            btnAddManager.Name = "btnAddManager";
            btnAddManager.ShadowDecoration.CustomizableEdges = customizableEdges12;
            btnAddManager.Size = new Size(115, 28);
            btnAddManager.TabIndex = 1;
            btnAddManager.Text = "+ Thêm Quản lý";
            // 
            // btnEditManager
            // 
            btnEditManager.BorderColor = Color.FromArgb(80, 80, 90);
            btnEditManager.BorderRadius = 8;
            btnEditManager.BorderThickness = 1;
            btnEditManager.Cursor = Cursors.Hand;
            btnEditManager.CustomizableEdges = customizableEdges13;
            btnEditManager.FillColor = Color.Transparent;
            btnEditManager.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnEditManager.ForeColor = Color.FromArgb(220, 220, 225);
            btnEditManager.HoverState.FillColor = Color.FromArgb(45, 45, 50);
            btnEditManager.Location = new Point(486, 14);
            btnEditManager.Name = "btnEditManager";
            btnEditManager.ShadowDecoration.CustomizableEdges = customizableEdges14;
            btnEditManager.Size = new Size(60, 28);
            btnEditManager.TabIndex = 0;
            btnEditManager.Text = "Sửa";
            // 
            // dgvManagers
            // 
            dataGridViewCellStyle1.BackColor = Color.FromArgb(34, 44, 47);
            dataGridViewCellStyle1.ForeColor = Color.FromArgb(220, 230, 232);
            dgvManagers.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvManagers.BackgroundColor = Color.FromArgb(28, 36, 38);
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(34, 44, 47);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(31, 138, 154);
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(34, 44, 47);
            dataGridViewCellStyle2.SelectionForeColor = Color.FromArgb(31, 138, 154);
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvManagers.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.FromArgb(28, 36, 38);
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(220, 230, 232);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvManagers.DefaultCellStyle = dataGridViewCellStyle3;
            dgvManagers.GridColor = Color.FromArgb(45, 60, 64);
            dgvManagers.Location = new Point(18, 56);
            dgvManagers.MultiSelect = false;
            dgvManagers.Name = "dgvManagers";
            dgvManagers.RowHeadersVisible = false;
            dgvManagers.Size = new Size(528, 170);
            dgvManagers.TabIndex = 1;
            dgvManagers.ThemeStyle.AlternatingRowsStyle.BackColor = Color.FromArgb(34, 44, 47);
            dgvManagers.ThemeStyle.AlternatingRowsStyle.Font = null;
            dgvManagers.ThemeStyle.AlternatingRowsStyle.ForeColor = Color.FromArgb(220, 230, 232);
            dgvManagers.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.Empty;
            dgvManagers.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.Empty;
            dgvManagers.ThemeStyle.BackColor = Color.FromArgb(28, 36, 38);
            dgvManagers.ThemeStyle.GridColor = Color.FromArgb(45, 60, 64);
            dgvManagers.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(34, 44, 47);
            dgvManagers.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvManagers.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI", 9F);
            dgvManagers.ThemeStyle.HeaderStyle.ForeColor = Color.FromArgb(31, 138, 154);
            dgvManagers.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvManagers.ThemeStyle.HeaderStyle.Height = 23;
            dgvManagers.ThemeStyle.ReadOnly = false;
            dgvManagers.ThemeStyle.RowsStyle.BackColor = Color.FromArgb(28, 36, 38);
            dgvManagers.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvManagers.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 9F);
            dgvManagers.ThemeStyle.RowsStyle.ForeColor = Color.FromArgb(220, 230, 232);
            dgvManagers.ThemeStyle.RowsStyle.Height = 25;
            dgvManagers.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dgvManagers.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(71, 69, 94);
            // 
            // pnlLeaveRequests
            // 
            pnlLeaveRequests.BackColor = Color.FromArgb(31, 31, 34);
            pnlLeaveRequests.BorderRadius = 14;
            pnlLeaveRequests.Controls.Add(lblLeaveReqTitle);
            pnlLeaveRequests.Controls.Add(btnApproveLeave);
            pnlLeaveRequests.Controls.Add(lstLeaveReq);
            pnlLeaveRequests.CustomizableEdges = customizableEdges19;
            pnlLeaveRequests.Location = new Point(600, 140);
            pnlLeaveRequests.Name = "pnlLeaveRequests";
            pnlLeaveRequests.ShadowDecoration.CustomizableEdges = customizableEdges20;
            pnlLeaveRequests.Size = new Size(340, 240);
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
            lblLeaveReqTitle.Text = "🏖  Đơn xin nghỉ";
            // 
            // btnApproveLeave
            // 
            btnApproveLeave.BorderRadius = 8;
            btnApproveLeave.Cursor = Cursors.Hand;
            btnApproveLeave.CustomizableEdges = customizableEdges17;
            btnApproveLeave.FillColor = Color.FromArgb(34, 197, 94);
            btnApproveLeave.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnApproveLeave.ForeColor = Color.White;
            btnApproveLeave.HoverState.FillColor = Color.FromArgb(50, 217, 110);
            btnApproveLeave.Location = new Point(240, 14);
            btnApproveLeave.Name = "btnApproveLeave";
            btnApproveLeave.ShadowDecoration.CustomizableEdges = customizableEdges18;
            btnApproveLeave.Size = new Size(82, 28);
            btnApproveLeave.TabIndex = 0;
            btnApproveLeave.Text = "Duyệt (0)";
            // 
            // lstLeaveReq
            // 
            lstLeaveReq.BackColor = Color.FromArgb(24, 24, 27);
            lstLeaveReq.BorderStyle = BorderStyle.None;
            lstLeaveReq.Font = new Font("Segoe UI", 9.5F);
            lstLeaveReq.ForeColor = Color.FromArgb(220, 220, 225);
            lstLeaveReq.FormattingEnabled = true;
            lstLeaveReq.IntegralHeight = false;
            lstLeaveReq.ItemHeight = 17;
            lstLeaveReq.Location = new Point(18, 56);
            lstLeaveReq.Name = "lstLeaveReq";
            lstLeaveReq.Size = new Size(304, 170);
            lstLeaveReq.TabIndex = 1;
            // 
            // pnlAuditLog
            // 
            pnlAuditLog.BackColor = Color.FromArgb(31, 31, 34);
            pnlAuditLog.BorderRadius = 14;
            pnlAuditLog.Controls.Add(lblAuditTitle);
            pnlAuditLog.Controls.Add(dgvAuditLog);
            pnlAuditLog.CustomizableEdges = customizableEdges21;
            pnlAuditLog.Location = new Point(20, 400);
            pnlAuditLog.Name = "pnlAuditLog";
            pnlAuditLog.ShadowDecoration.CustomizableEdges = customizableEdges22;
            pnlAuditLog.Size = new Size(920, 240);
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
            lblAuditTitle.Text = "🔔  Lịch sử thao tác của Quản lý";
            // 
            // dgvAuditLog
            // 
            dataGridViewCellStyle4.BackColor = Color.FromArgb(58, 34, 34);
            dataGridViewCellStyle4.ForeColor = Color.FromArgb(230, 200, 200);
            dgvAuditLog.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            dgvAuditLog.BackgroundColor = Color.FromArgb(48, 28, 28);
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = Color.FromArgb(58, 34, 34);
            dataGridViewCellStyle5.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle5.ForeColor = Color.FromArgb(245, 158, 11);
            dataGridViewCellStyle5.SelectionBackColor = Color.FromArgb(58, 34, 34);
            dataGridViewCellStyle5.SelectionForeColor = Color.FromArgb(245, 158, 11);
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.True;
            dgvAuditLog.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = Color.FromArgb(48, 28, 28);
            dataGridViewCellStyle6.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle6.ForeColor = Color.FromArgb(230, 200, 200);
            dataGridViewCellStyle6.SelectionBackColor = Color.FromArgb(180, 60, 60);
            dataGridViewCellStyle6.SelectionForeColor = Color.White;
            dataGridViewCellStyle6.WrapMode = DataGridViewTriState.False;
            dgvAuditLog.DefaultCellStyle = dataGridViewCellStyle6;
            dgvAuditLog.GridColor = Color.FromArgb(70, 40, 40);
            dgvAuditLog.Location = new Point(18, 50);
            dgvAuditLog.MultiSelect = false;
            dgvAuditLog.Name = "dgvAuditLog";
            dgvAuditLog.RowHeadersVisible = false;
            dgvAuditLog.RowTemplate.DefaultCellStyle.SelectionBackColor = Color.FromArgb(180, 60, 60);
            dgvAuditLog.RowTemplate.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvAuditLog.Size = new Size(884, 175);
            dgvAuditLog.TabIndex = 3;
            dgvAuditLog.ThemeStyle.AlternatingRowsStyle.BackColor = Color.FromArgb(58, 34, 34);
            dgvAuditLog.ThemeStyle.AlternatingRowsStyle.Font = null;
            dgvAuditLog.ThemeStyle.AlternatingRowsStyle.ForeColor = Color.FromArgb(230, 200, 200);
            dgvAuditLog.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.Empty;
            dgvAuditLog.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.Empty;
            dgvAuditLog.ThemeStyle.BackColor = Color.FromArgb(48, 28, 28);
            dgvAuditLog.ThemeStyle.GridColor = Color.FromArgb(70, 40, 40);
            dgvAuditLog.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(58, 34, 34);
            dgvAuditLog.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvAuditLog.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI", 9F);
            dgvAuditLog.ThemeStyle.HeaderStyle.ForeColor = Color.FromArgb(245, 158, 11);
            dgvAuditLog.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvAuditLog.ThemeStyle.HeaderStyle.Height = 23;
            dgvAuditLog.ThemeStyle.ReadOnly = false;
            dgvAuditLog.ThemeStyle.RowsStyle.BackColor = Color.FromArgb(48, 28, 28);
            dgvAuditLog.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvAuditLog.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 9F);
            dgvAuditLog.ThemeStyle.RowsStyle.ForeColor = Color.FromArgb(230, 200, 200);
            dgvAuditLog.ThemeStyle.RowsStyle.Height = 25;
            dgvAuditLog.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(180, 60, 60);
            dgvAuditLog.ThemeStyle.RowsStyle.SelectionForeColor = Color.White;
            // 
            // ucAdmin_Managers
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(39, 39, 42);
            Controls.Add(pnlSummary);
            Controls.Add(pnlManagerList);
            Controls.Add(pnlLeaveRequests);
            Controls.Add(pnlAuditLog);
            Name = "ucAdmin_Managers";
            Size = new Size(960, 660);
            Load += ucAdmin_Managers_Load;
            pnlSummary.ResumeLayout(false);
            pnlStatTotal.ResumeLayout(false);
            pnlStatTotal.PerformLayout();
            pnlStatPresent.ResumeLayout(false);
            pnlStatPresent.PerformLayout();
            pnlStatLeave.ResumeLayout(false);
            pnlStatLeave.PerformLayout();
            pnlManagerList.ResumeLayout(false);
            pnlManagerList.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvManagers).EndInit();
            pnlLeaveRequests.ResumeLayout(false);
            pnlLeaveRequests.PerformLayout();
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
            dgv.DefaultCellStyle.SelectionForeColor = Color.White;
            dgv.EnableHeadersVisualStyles = false;
            dgv.GridColor = Color.FromArgb(45, 45, 48);
            dgv.ReadOnly = true;
            dgv.RowHeadersVisible = false;
            dgv.RowTemplate.DefaultCellStyle.SelectionBackColor = Color.FromArgb(31, 138, 154);
            dgv.RowTemplate.DefaultCellStyle.SelectionForeColor = Color.White;
            dgv.RowTemplate.Height = 28;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        #endregion

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

        private Guna2Panel pnlLeaveRequests;
        private Label lblLeaveReqTitle;
        private Guna2Button btnApproveLeave;
        private ListBox lstLeaveReq;

        private Guna2Panel pnlAuditLog;
        private Label lblAuditTitle;
        private Guna2DataGridView dgvAuditLog;
    }
}
