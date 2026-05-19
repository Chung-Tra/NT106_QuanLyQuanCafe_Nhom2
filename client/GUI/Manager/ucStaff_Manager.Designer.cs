using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace GUI
{
    partial class ucStaff_Manager
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            Guna.UI2.WinForms.Suite.CustomizableEdges ce1  = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges ce2  = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges ce3  = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges ce4  = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges ce5  = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges ce6  = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges ce7  = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges ce8  = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges ce9  = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges ce10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges ce11 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges ce12 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges ce13 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges ce14 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges ce15 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges ce16 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges ce17 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges ce18 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges ce19 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges ce20 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges ce21 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges ce22 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges ce23 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges ce24 = new Guna.UI2.WinForms.Suite.CustomizableEdges();

            // Stat summary row
            pnlSummary     = new Guna2Panel();
            pnlStatTotal   = new Guna2Panel();
            lblTotalStaffTitle = new Label();
            lblTotalStaffValue = new Label();
            pnlStatPresent = new Guna2Panel();
            lblPresentTitle = new Label();
            lblPresentValue = new Label();
            pnlStatLeave   = new Guna2Panel();
            lblLeaveTitle  = new Label();
            lblLeaveValue  = new Label();
            pnlStatPayroll = new Guna2Panel();
            lblPayrollTitle = new Label();
            lblPayrollValue = new Label();

            // Staff list panel
            pnlStaffList   = new Guna2Panel();
            lblStaffTitle  = new Label();
            btnAddStaff    = new Guna2Button();
            btnEditStaff   = new Guna2Button();
            txtSearch      = new Guna2TextBox();
            cbRole         = new Guna2ComboBox();
            cbStatus       = new Guna2ComboBox();
            btnFilter      = new Guna2Button();
            btnClearFilter = new Guna2Button();
            dgvStaff       = new Guna2DataGridView();

            // Leave requests panel
            pnlLeaveRequests = new Guna2Panel();
            lblLeaveReqTitle = new Label();
            btnApproveLeave  = new Guna2Button();
            dgvLeaveReq      = new Guna2DataGridView();

            pnlSummary.SuspendLayout();
            pnlStatTotal.SuspendLayout();
            pnlStatPresent.SuspendLayout();
            pnlStatLeave.SuspendLayout();
            pnlStatPayroll.SuspendLayout();
            pnlStaffList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvStaff).BeginInit();
            pnlLeaveRequests.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvLeaveReq).BeginInit();
            SuspendLayout();

            // ──────────────────────────────────────────────
            // pnlSummary — wrapper trong suốt chứa 4 stat card
            // ──────────────────────────────────────────────
            pnlSummary.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlSummary.BackColor = Color.Transparent;
            pnlSummary.Controls.Add(pnlStatTotal);
            pnlSummary.Controls.Add(pnlStatPresent);
            pnlSummary.Controls.Add(pnlStatLeave);
            pnlSummary.Controls.Add(pnlStatPayroll);
            pnlSummary.CustomizableEdges = ce1;
            pnlSummary.Location = new Point(0, 0);
            pnlSummary.Name = "pnlSummary";
            pnlSummary.ShadowDecoration.CustomizableEdges = ce2;
            pnlSummary.Size = new Size(960, 100);
            pnlSummary.TabIndex = 0;

            // pnlStatTotal
            pnlStatTotal.BackColor = Color.FromArgb(31, 31, 34);
            pnlStatTotal.BorderRadius = 14;
            pnlStatTotal.Controls.Add(lblTotalStaffTitle);
            pnlStatTotal.Controls.Add(lblTotalStaffValue);
            pnlStatTotal.CustomizableEdges = ce3;
            pnlStatTotal.Location = new Point(0, 0);
            pnlStatTotal.Name = "pnlStatTotal";
            pnlStatTotal.ShadowDecoration.CustomizableEdges = ce4;
            pnlStatTotal.Size = new Size(228, 100);
            pnlStatTotal.TabIndex = 0;

            lblTotalStaffTitle.AutoSize = true;
            lblTotalStaffTitle.Font = new Font("Segoe UI", 9F);
            lblTotalStaffTitle.ForeColor = Color.FromArgb(160, 160, 166);
            lblTotalStaffTitle.Location = new Point(18, 18);
            lblTotalStaffTitle.Name = "lblTotalStaffTitle";
            lblTotalStaffTitle.TabIndex = 0;
            lblTotalStaffTitle.Text = "Tổng Số Nhân Viên";

            lblTotalStaffValue.AutoSize = true;
            lblTotalStaffValue.Font = new Font("Segoe UI", 17F, FontStyle.Bold);
            lblTotalStaffValue.ForeColor = Color.White;
            lblTotalStaffValue.Location = new Point(18, 42);
            lblTotalStaffValue.Name = "lblTotalStaffValue";
            lblTotalStaffValue.TabIndex = 1;
            lblTotalStaffValue.Text = "0 người";

            // pnlStatPresent
            pnlStatPresent.BackColor = Color.FromArgb(31, 31, 34);
            pnlStatPresent.BorderRadius = 14;
            pnlStatPresent.Controls.Add(lblPresentTitle);
            pnlStatPresent.Controls.Add(lblPresentValue);
            pnlStatPresent.CustomizableEdges = ce5;
            pnlStatPresent.Location = new Point(238, 0);
            pnlStatPresent.Name = "pnlStatPresent";
            pnlStatPresent.ShadowDecoration.CustomizableEdges = ce6;
            pnlStatPresent.Size = new Size(228, 100);
            pnlStatPresent.TabIndex = 1;

            lblPresentTitle.AutoSize = true;
            lblPresentTitle.Font = new Font("Segoe UI", 9F);
            lblPresentTitle.ForeColor = Color.FromArgb(160, 160, 166);
            lblPresentTitle.Location = new Point(18, 18);
            lblPresentTitle.Name = "lblPresentTitle";
            lblPresentTitle.TabIndex = 0;
            lblPresentTitle.Text = "Đang làm việc \U0001f7e2";

            lblPresentValue.AutoSize = true;
            lblPresentValue.Font = new Font("Segoe UI", 17F, FontStyle.Bold);
            lblPresentValue.ForeColor = Color.FromArgb(34, 197, 94);
            lblPresentValue.Location = new Point(18, 42);
            lblPresentValue.Name = "lblPresentValue";
            lblPresentValue.TabIndex = 1;
            lblPresentValue.Text = "0 người";

            // pnlStatLeave
            pnlStatLeave.BackColor = Color.FromArgb(31, 31, 34);
            pnlStatLeave.BorderRadius = 14;
            pnlStatLeave.Controls.Add(lblLeaveTitle);
            pnlStatLeave.Controls.Add(lblLeaveValue);
            pnlStatLeave.CustomizableEdges = ce7;
            pnlStatLeave.Location = new Point(476, 0);
            pnlStatLeave.Name = "pnlStatLeave";
            pnlStatLeave.ShadowDecoration.CustomizableEdges = ce8;
            pnlStatLeave.Size = new Size(228, 100);
            pnlStatLeave.TabIndex = 2;

            lblLeaveTitle.AutoSize = true;
            lblLeaveTitle.Font = new Font("Segoe UI", 9F);
            lblLeaveTitle.ForeColor = Color.FromArgb(160, 160, 166);
            lblLeaveTitle.Location = new Point(18, 18);
            lblLeaveTitle.Name = "lblLeaveTitle";
            lblLeaveTitle.TabIndex = 0;
            lblLeaveTitle.Text = "Nghỉ phép (Hôm nay)";

            lblLeaveValue.AutoSize = true;
            lblLeaveValue.Font = new Font("Segoe UI", 17F, FontStyle.Bold);
            lblLeaveValue.ForeColor = Color.FromArgb(245, 158, 11);
            lblLeaveValue.Location = new Point(18, 42);
            lblLeaveValue.Name = "lblLeaveValue";
            lblLeaveValue.TabIndex = 1;
            lblLeaveValue.Text = "0 người";

            // pnlStatPayroll
            pnlStatPayroll.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlStatPayroll.BackColor = Color.FromArgb(31, 31, 34);
            pnlStatPayroll.BorderRadius = 14;
            pnlStatPayroll.Controls.Add(lblPayrollTitle);
            pnlStatPayroll.Controls.Add(lblPayrollValue);
            pnlStatPayroll.CustomizableEdges = ce9;
            pnlStatPayroll.Location = new Point(714, 0);
            pnlStatPayroll.Name = "pnlStatPayroll";
            pnlStatPayroll.ShadowDecoration.CustomizableEdges = ce10;
            pnlStatPayroll.Size = new Size(246, 100);
            pnlStatPayroll.TabIndex = 3;

            lblPayrollTitle.AutoSize = true;
            lblPayrollTitle.Font = new Font("Segoe UI", 9F);
            lblPayrollTitle.ForeColor = Color.FromArgb(160, 160, 166);
            lblPayrollTitle.Location = new Point(18, 18);
            lblPayrollTitle.Name = "lblPayrollTitle";
            lblPayrollTitle.TabIndex = 0;
            lblPayrollTitle.Text = "Quỹ lương (Tạm tính)";

            lblPayrollValue.AutoSize = true;
            lblPayrollValue.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            lblPayrollValue.ForeColor = Color.IndianRed;
            lblPayrollValue.Location = new Point(18, 42);
            lblPayrollValue.Name = "lblPayrollValue";
            lblPayrollValue.TabIndex = 1;
            lblPayrollValue.Text = "42,500,000 đ";

            // ──────────────────────────────────────────────
            // pnlStaffList — danh sách nhân viên
            // ──────────────────────────────────────────────
            pnlStaffList.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Right;
            pnlStaffList.BackColor = Color.FromArgb(31, 31, 34);
            pnlStaffList.BorderRadius = 14;
            pnlStaffList.Controls.Add(lblStaffTitle);
            pnlStaffList.Controls.Add(btnAddStaff);
            pnlStaffList.Controls.Add(btnEditStaff);
            pnlStaffList.Controls.Add(txtSearch);
            pnlStaffList.Controls.Add(cbRole);
            pnlStaffList.Controls.Add(cbStatus);
            pnlStaffList.Controls.Add(btnFilter);
            pnlStaffList.Controls.Add(btnClearFilter);
            pnlStaffList.Controls.Add(dgvStaff);
            pnlStaffList.CustomizableEdges = ce11;
            pnlStaffList.Location = new Point(0, 110);
            pnlStaffList.Name = "pnlStaffList";
            pnlStaffList.ShadowDecoration.CustomizableEdges = ce12;
            pnlStaffList.Size = new Size(645, 530);
            pnlStaffList.TabIndex = 1;

            // lblStaffTitle
            lblStaffTitle.AutoSize = true;
            lblStaffTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblStaffTitle.ForeColor = Color.White;
            lblStaffTitle.Location = new Point(18, 16);
            lblStaffTitle.Name = "lblStaffTitle";
            lblStaffTitle.TabIndex = 0;
            lblStaffTitle.Text = "📇  Hồ sơ Nhân viên";

            // btnAddStaff
            btnAddStaff.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAddStaff.BorderRadius = 8;
            btnAddStaff.Cursor = Cursors.Hand;
            btnAddStaff.CustomizableEdges = ce13;
            btnAddStaff.FillColor = Color.FromArgb(31, 138, 154);
            btnAddStaff.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnAddStaff.ForeColor = Color.White;
            btnAddStaff.HoverState.FillColor = Color.FromArgb(45, 158, 174);
            btnAddStaff.HoverState.ForeColor = Color.White;
            btnAddStaff.Location = new Point(390, 14);
            btnAddStaff.Name = "btnAddStaff";
            btnAddStaff.ShadowDecoration.CustomizableEdges = ce14;
            btnAddStaff.Size = new Size(130, 28);
            btnAddStaff.TabIndex = 1;
            btnAddStaff.Text = "+ Thêm NV Mới";
            btnAddStaff.Click += btnAddStaff_Click;

            // btnEditStaff
            btnEditStaff.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnEditStaff.BorderColor = Color.FromArgb(80, 80, 90);
            btnEditStaff.BorderRadius = 8;
            btnEditStaff.BorderThickness = 1;
            btnEditStaff.Cursor = Cursors.Hand;
            btnEditStaff.CustomizableEdges = ce15;
            btnEditStaff.FillColor = Color.Transparent;
            btnEditStaff.Font = new Font("Segoe UI", 9F);
            btnEditStaff.ForeColor = Color.FromArgb(220, 220, 225);
            btnEditStaff.HoverState.FillColor = Color.FromArgb(45, 45, 50);
            btnEditStaff.HoverState.ForeColor = Color.White;
            btnEditStaff.Location = new Point(528, 14);
            btnEditStaff.Name = "btnEditStaff";
            btnEditStaff.ShadowDecoration.CustomizableEdges = ce16;
            btnEditStaff.Size = new Size(100, 28);
            btnEditStaff.TabIndex = 2;
            btnEditStaff.Text = "✏  Sửa";
            btnEditStaff.Click += btnEditStaff_Click;

            // txtSearch
            txtSearch.BorderColor = Color.FromArgb(63, 63, 70);
            txtSearch.BorderRadius = 8;
            txtSearch.DisabledState.BorderColor = Color.FromArgb(63, 63, 70);
            txtSearch.DisabledState.FillColor = Color.FromArgb(45, 45, 48);
            txtSearch.FillColor = Color.FromArgb(24, 24, 27);
            txtSearch.FocusedState.BorderColor = Color.FromArgb(31, 138, 154);
            txtSearch.Font = new Font("Segoe UI", 9.5F);
            txtSearch.ForeColor = Color.White;
            txtSearch.HoverState.BorderColor = Color.FromArgb(80, 80, 90);
            txtSearch.Location = new Point(18, 54);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "🔍  Tên, Mã NV...";
            txtSearch.Size = new Size(155, 36);
            txtSearch.TabIndex = 3;

            // cbRole
            cbRole.BackColor = Color.Transparent;
            cbRole.BorderColor = Color.FromArgb(63, 63, 70);
            cbRole.BorderRadius = 8;
            cbRole.DrawMode = DrawMode.OwnerDrawFixed;
            cbRole.DropDownStyle = ComboBoxStyle.DropDownList;
            cbRole.FillColor = Color.FromArgb(24, 24, 27);
            cbRole.FocusedColor = Color.FromArgb(31, 138, 154);
            cbRole.FocusedState.BorderColor = Color.FromArgb(31, 138, 154);
            cbRole.Font = new Font("Segoe UI", 9.5F);
            cbRole.ForeColor = Color.White;
            cbRole.HoverState.BorderColor = Color.FromArgb(80, 80, 90);
            cbRole.ItemHeight = 26;
            cbRole.Location = new Point(181, 54);
            cbRole.Name = "cbRole";
            cbRole.Size = new Size(130, 36);
            cbRole.TabIndex = 4;

            // cbStatus
            cbStatus.BackColor = Color.Transparent;
            cbStatus.BorderColor = Color.FromArgb(63, 63, 70);
            cbStatus.BorderRadius = 8;
            cbStatus.DrawMode = DrawMode.OwnerDrawFixed;
            cbStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cbStatus.FillColor = Color.FromArgb(24, 24, 27);
            cbStatus.FocusedColor = Color.FromArgb(31, 138, 154);
            cbStatus.FocusedState.BorderColor = Color.FromArgb(31, 138, 154);
            cbStatus.Font = new Font("Segoe UI", 9.5F);
            cbStatus.ForeColor = Color.White;
            cbStatus.HoverState.BorderColor = Color.FromArgb(80, 80, 90);
            cbStatus.ItemHeight = 26;
            cbStatus.Location = new Point(319, 54);
            cbStatus.Name = "cbStatus";
            cbStatus.Size = new Size(130, 36);
            cbStatus.TabIndex = 5;

            // btnFilter
            btnFilter.BorderRadius = 8;
            btnFilter.Cursor = Cursors.Hand;
            btnFilter.CustomizableEdges = ce17;
            btnFilter.FillColor = Color.FromArgb(31, 138, 154);
            btnFilter.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnFilter.ForeColor = Color.White;
            btnFilter.HoverState.FillColor = Color.FromArgb(45, 158, 174);
            btnFilter.HoverState.ForeColor = Color.White;
            btnFilter.Location = new Point(457, 54);
            btnFilter.Name = "btnFilter";
            btnFilter.ShadowDecoration.CustomizableEdges = ce18;
            btnFilter.Size = new Size(82, 36);
            btnFilter.TabIndex = 6;
            btnFilter.Text = "🔍  Lọc";

            // btnClearFilter
            btnClearFilter.BorderRadius = 8;
            btnClearFilter.Cursor = Cursors.Hand;
            btnClearFilter.CustomizableEdges = ce19;
            btnClearFilter.FillColor = Color.FromArgb(127, 29, 29);
            btnClearFilter.Font = new Font("Segoe UI", 9F);
            btnClearFilter.ForeColor = Color.FromArgb(252, 165, 165);
            btnClearFilter.HoverState.FillColor = Color.FromArgb(185, 28, 28);
            btnClearFilter.HoverState.ForeColor = Color.White;
            btnClearFilter.Location = new Point(547, 54);
            btnClearFilter.Name = "btnClearFilter";
            btnClearFilter.ShadowDecoration.CustomizableEdges = ce20;
            btnClearFilter.Size = new Size(82, 36);
            btnClearFilter.TabIndex = 7;
            btnClearFilter.Text = "✖  Xóa";
            btnClearFilter.Click += btnClearFilter_Click;

            // dgvStaff
            ConfigureGrid(dgvStaff);
            dgvStaff.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Right;
            dgvStaff.Location = new Point(18, 100);
            dgvStaff.Name = "dgvStaff";
            dgvStaff.Size = new Size(609, 415);
            dgvStaff.TabIndex = 8;

            // ──────────────────────────────────────────────
            // pnlLeaveRequests — duyệt đơn nghỉ phép
            // ──────────────────────────────────────────────
            pnlLeaveRequests.Anchor = AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Bottom;
            pnlLeaveRequests.BackColor = Color.FromArgb(31, 31, 34);
            pnlLeaveRequests.BorderRadius = 14;
            pnlLeaveRequests.Controls.Add(lblLeaveReqTitle);
            pnlLeaveRequests.Controls.Add(btnApproveLeave);
            pnlLeaveRequests.Controls.Add(dgvLeaveReq);
            pnlLeaveRequests.CustomizableEdges = ce21;
            pnlLeaveRequests.Location = new Point(655, 110);
            pnlLeaveRequests.Name = "pnlLeaveRequests";
            pnlLeaveRequests.ShadowDecoration.CustomizableEdges = ce22;
            pnlLeaveRequests.Size = new Size(305, 530);
            pnlLeaveRequests.TabIndex = 2;

            // lblLeaveReqTitle
            lblLeaveReqTitle.AutoSize = true;
            lblLeaveReqTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblLeaveReqTitle.ForeColor = Color.White;
            lblLeaveReqTitle.Location = new Point(18, 16);
            lblLeaveReqTitle.Name = "lblLeaveReqTitle";
            lblLeaveReqTitle.TabIndex = 0;
            lblLeaveReqTitle.Text = "🏖  Đơn xin nghỉ";

            // btnApproveLeave
            btnApproveLeave.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnApproveLeave.BorderRadius = 8;
            btnApproveLeave.Cursor = Cursors.Hand;
            btnApproveLeave.CustomizableEdges = ce23;
            btnApproveLeave.FillColor = Color.FromArgb(34, 197, 94);
            btnApproveLeave.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnApproveLeave.ForeColor = Color.White;
            btnApproveLeave.HoverState.FillColor = Color.FromArgb(50, 217, 110);
            btnApproveLeave.HoverState.ForeColor = Color.White;
            btnApproveLeave.Location = new Point(196, 14);
            btnApproveLeave.Name = "btnApproveLeave";
            btnApproveLeave.ShadowDecoration.CustomizableEdges = ce24;
            btnApproveLeave.Size = new Size(95, 28);
            btnApproveLeave.TabIndex = 1;
            btnApproveLeave.Text = "✔  Duyệt";

            // dgvLeaveReq
            ConfigureGrid(dgvLeaveReq);
            dgvLeaveReq.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Right;
            dgvLeaveReq.Location = new Point(18, 56);
            dgvLeaveReq.Name = "dgvLeaveReq";
            dgvLeaveReq.Size = new Size(269, 460);
            dgvLeaveReq.TabIndex = 2;

            // ──────────────────────────────────────────────
            // ucStaff_Manager
            // ──────────────────────────────────────────────
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(39, 39, 42);
            Controls.Add(pnlSummary);
            Controls.Add(pnlStaffList);
            Controls.Add(pnlLeaveRequests);
            Name = "ucStaff_Manager";
            Size = new Size(960, 640);
            Load += ucStaff_Manager_Load;
            pnlSummary.ResumeLayout(false);
            pnlStatTotal.ResumeLayout(false);
            pnlStatTotal.PerformLayout();
            pnlStatPresent.ResumeLayout(false);
            pnlStatPresent.PerformLayout();
            pnlStatLeave.ResumeLayout(false);
            pnlStatLeave.PerformLayout();
            pnlStatPayroll.ResumeLayout(false);
            pnlStatPayroll.PerformLayout();
            pnlStaffList.ResumeLayout(false);
            pnlStaffList.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvStaff).EndInit();
            pnlLeaveRequests.ResumeLayout(false);
            pnlLeaveRequests.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvLeaveReq).EndInit();
            ResumeLayout(false);
        }

        // ──────────────────────────────────────────────
        // CHUẨN HÓA STYLE GUNA2DATAGRIDVIEW (theo ucAdmin_Managers)
        // ──────────────────────────────────────────────
        private static void ConfigureGrid(Guna2DataGridView dgv)
        {
            dgv.AllowUserToAddRows    = false;
            dgv.AllowUserToResizeRows = false;
            dgv.BackgroundColor       = Color.FromArgb(24, 24, 27);
            dgv.BorderStyle           = BorderStyle.None;
            dgv.CellBorderStyle       = DataGridViewCellBorderStyle.SingleHorizontal;
            dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgv.ColumnHeadersHeight   = 32;
            dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgv.ColumnHeadersDefaultCellStyle.BackColor         = Color.FromArgb(31, 31, 34);
            dgv.ColumnHeadersDefaultCellStyle.ForeColor         = Color.FromArgb(31, 138, 154);
            dgv.ColumnHeadersDefaultCellStyle.Font              = new Font("Segoe UI", 9F, FontStyle.Bold);
            dgv.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(31, 31, 34);
            dgv.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.FromArgb(31, 138, 154);
            dgv.DefaultCellStyle.BackColor         = Color.FromArgb(24, 24, 27);
            dgv.DefaultCellStyle.ForeColor         = Color.FromArgb(220, 220, 225);
            dgv.DefaultCellStyle.Font              = new Font("Segoe UI", 9F);
            dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(31, 138, 154);
            dgv.DefaultCellStyle.SelectionForeColor = Color.White;
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(34, 34, 38);
            dgv.AlternatingRowsDefaultCellStyle.ForeColor = Color.FromArgb(220, 220, 225);
            dgv.EnableHeadersVisualStyles = false;
            dgv.GridColor     = Color.FromArgb(45, 45, 48);
            dgv.MultiSelect   = false;
            dgv.ReadOnly      = true;
            dgv.RowHeadersVisible = false;
            dgv.RowTemplate.DefaultCellStyle.SelectionBackColor = Color.FromArgb(31, 138, 154);
            dgv.RowTemplate.DefaultCellStyle.SelectionForeColor = Color.White;
            dgv.RowTemplate.Height = 28;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            // ThemeStyle
            dgv.ThemeStyle.AlternatingRowsStyle.BackColor        = Color.FromArgb(34, 34, 38);
            dgv.ThemeStyle.AlternatingRowsStyle.Font             = null;
            dgv.ThemeStyle.AlternatingRowsStyle.ForeColor        = Color.FromArgb(220, 220, 225);
            dgv.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.Empty;
            dgv.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.Empty;
            dgv.ThemeStyle.BackColor  = Color.FromArgb(24, 24, 27);
            dgv.ThemeStyle.GridColor  = Color.FromArgb(45, 45, 48);
            dgv.ThemeStyle.HeaderStyle.BackColor    = Color.FromArgb(31, 31, 34);
            dgv.ThemeStyle.HeaderStyle.BorderStyle  = DataGridViewHeaderBorderStyle.None;
            dgv.ThemeStyle.HeaderStyle.Font         = new Font("Segoe UI", 9F, FontStyle.Bold);
            dgv.ThemeStyle.HeaderStyle.ForeColor    = Color.FromArgb(31, 138, 154);
            dgv.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgv.ThemeStyle.HeaderStyle.Height       = 32;
            dgv.ThemeStyle.ReadOnly = true;
            dgv.ThemeStyle.RowsStyle.BackColor         = Color.FromArgb(24, 24, 27);
            dgv.ThemeStyle.RowsStyle.BorderStyle       = DataGridViewCellBorderStyle.SingleHorizontal;
            dgv.ThemeStyle.RowsStyle.Font              = new Font("Segoe UI", 9F);
            dgv.ThemeStyle.RowsStyle.ForeColor         = Color.FromArgb(220, 220, 225);
            dgv.ThemeStyle.RowsStyle.Height            = 28;
            dgv.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(31, 138, 154);
            dgv.ThemeStyle.RowsStyle.SelectionForeColor = Color.White;
        }

        #region Field declarations

        private Guna2Panel pnlSummary;
        private Guna2Panel pnlStatTotal;
        private Label      lblTotalStaffTitle;
        private Label      lblTotalStaffValue;
        private Guna2Panel pnlStatPresent;
        private Label      lblPresentTitle;
        private Label      lblPresentValue;
        private Guna2Panel pnlStatLeave;
        private Label      lblLeaveTitle;
        private Label      lblLeaveValue;
        private Guna2Panel pnlStatPayroll;
        private Label      lblPayrollTitle;
        private Label      lblPayrollValue;

        private Guna2Panel        pnlStaffList;
        private Label             lblStaffTitle;
        private Guna2Button       btnAddStaff;
        private Guna2Button       btnEditStaff;
        private Guna2TextBox      txtSearch;
        private Guna2ComboBox     cbRole;
        private Guna2ComboBox     cbStatus;
        private Guna2Button       btnFilter;
        private Guna2Button       btnClearFilter;
        private Guna2DataGridView dgvStaff;

        private Guna2Panel        pnlLeaveRequests;
        private Label             lblLeaveReqTitle;
        private Guna2Button       btnApproveLeave;
        private Guna2DataGridView dgvLeaveReq;

        #endregion
    }
}
