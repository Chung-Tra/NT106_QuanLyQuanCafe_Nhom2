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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges25 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges26 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges11 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges12 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges13 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges14 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges15 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges16 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges17 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges18 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges19 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges20 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges21 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges22 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges23 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges24 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges29 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges30 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges27 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges28 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            pnlSummary = new Guna2Panel();
            pnlStatTotal = new Guna2Panel();
            lblTotalStaffTitle = new Label();
            lblTotalStaffValue = new Label();
            pnlStatPresent = new Guna2Panel();
            lblPresentTitle = new Label();
            lblPresentValue = new Label();
            pnlStatLeave = new Guna2Panel();
            lblLeaveTitle = new Label();
            lblLeaveValue = new Label();
            pnlStatPayroll = new Guna2Panel();
            lblPayrollTitle = new Label();
            lblPayrollValue = new Label();
            pnlStaffList = new Guna2Panel();
            lblStaffTitle = new Label();
            btnAddStaff = new Guna2Button();
            btnEditStaff = new Guna2Button();
            txtSearch = new Guna2TextBox();
            cbRole = new Guna2ComboBox();
            cbStatus = new Guna2ComboBox();
            btnFilter = new Guna2Button();
            btnClearFilter = new Guna2Button();
            dgvStaff = new Guna2DataGridView();
            colStaffId = new DataGridViewTextBoxColumn();
            colStaffName = new DataGridViewTextBoxColumn();
            colStaffPosition = new DataGridViewTextBoxColumn();
            colStaffStatus = new DataGridViewTextBoxColumn();
            colStaffPhone = new DataGridViewTextBoxColumn();
            colStaffAuthUid = new DataGridViewTextBoxColumn();
            colStaffEmail = new DataGridViewTextBoxColumn();
            pnlLeaveRequests = new Guna2Panel();
            lblLeaveReqTitle = new Label();
            btnApproveLeave = new Guna2Button();
            dgvLeaveReq = new Guna2DataGridView();
            colLeaveStaff = new DataGridViewTextBoxColumn();
            colLeaveDate = new DataGridViewTextBoxColumn();
            colLeaveReason = new DataGridViewTextBoxColumn();
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
            // 
            // pnlSummary
            // 
            pnlSummary.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlSummary.BackColor = Color.Transparent;
            pnlSummary.Controls.Add(pnlStatTotal);
            pnlSummary.Controls.Add(pnlStatPresent);
            pnlSummary.Controls.Add(pnlStatLeave);
            pnlSummary.Controls.Add(pnlStatPayroll);
            pnlSummary.CustomizableEdges = customizableEdges9;
            pnlSummary.Location = new Point(0, 0);
            pnlSummary.Name = "pnlSummary";
            pnlSummary.ShadowDecoration.CustomizableEdges = customizableEdges10;
            pnlSummary.Size = new Size(1000, 100);
            pnlSummary.TabIndex = 0;
            // 
            // pnlStatTotal
            // 
            pnlStatTotal.BackColor = Color.FromArgb(31, 31, 34);
            pnlStatTotal.BorderRadius = 14;
            pnlStatTotal.Controls.Add(lblTotalStaffTitle);
            pnlStatTotal.Controls.Add(lblTotalStaffValue);
            pnlStatTotal.CustomizableEdges = customizableEdges1;
            pnlStatTotal.Location = new Point(18, 18);
            pnlStatTotal.Name = "pnlStatTotal";
            pnlStatTotal.ShadowDecoration.CustomizableEdges = customizableEdges2;
            pnlStatTotal.Size = new Size(210, 79);
            pnlStatTotal.TabIndex = 0;
            // 
            // lblTotalStaffTitle
            // 
            lblTotalStaffTitle.AutoSize = true;
            lblTotalStaffTitle.Font = new Font("Segoe UI", 9F);
            lblTotalStaffTitle.ForeColor = Color.FromArgb(160, 160, 166);
            lblTotalStaffTitle.Location = new Point(18, 18);
            lblTotalStaffTitle.Name = "lblTotalStaffTitle";
            lblTotalStaffTitle.Size = new Size(109, 15);
            lblTotalStaffTitle.TabIndex = 0;
            lblTotalStaffTitle.Text = "Tổng Số Nhân Viên";
            // 
            // lblTotalStaffValue
            // 
            lblTotalStaffValue.AutoSize = true;
            lblTotalStaffValue.Font = new Font("Segoe UI", 17F, FontStyle.Bold);
            lblTotalStaffValue.ForeColor = Color.White;
            lblTotalStaffValue.Location = new Point(18, 42);
            lblTotalStaffValue.Name = "lblTotalStaffValue";
            lblTotalStaffValue.Size = new Size(97, 31);
            lblTotalStaffValue.TabIndex = 1;
            lblTotalStaffValue.Text = "0 người";
            // 
            // pnlStatPresent
            // 
            pnlStatPresent.BackColor = Color.FromArgb(31, 31, 34);
            pnlStatPresent.BorderRadius = 14;
            pnlStatPresent.Controls.Add(lblPresentTitle);
            pnlStatPresent.Controls.Add(lblPresentValue);
            pnlStatPresent.CustomizableEdges = customizableEdges3;
            pnlStatPresent.Location = new Point(234, 15);
            pnlStatPresent.Name = "pnlStatPresent";
            pnlStatPresent.ShadowDecoration.CustomizableEdges = customizableEdges4;
            pnlStatPresent.Size = new Size(228, 82);
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
            pnlStatLeave.Location = new Point(468, 15);
            pnlStatLeave.Name = "pnlStatLeave";
            pnlStatLeave.ShadowDecoration.CustomizableEdges = customizableEdges6;
            pnlStatLeave.Size = new Size(228, 82);
            pnlStatLeave.TabIndex = 2;
            // 
            // lblLeaveTitle
            // 
            lblLeaveTitle.AutoSize = true;
            lblLeaveTitle.Font = new Font("Segoe UI", 9F);
            lblLeaveTitle.ForeColor = Color.FromArgb(160, 160, 166);
            lblLeaveTitle.Location = new Point(18, 18);
            lblLeaveTitle.Name = "lblLeaveTitle";
            lblLeaveTitle.Size = new Size(123, 15);
            lblLeaveTitle.TabIndex = 0;
            lblLeaveTitle.Text = "Nghỉ phép (Hôm nay)";
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
            // pnlStatPayroll
            // 
            pnlStatPayroll.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlStatPayroll.BackColor = Color.FromArgb(31, 31, 34);
            pnlStatPayroll.BorderRadius = 14;
            pnlStatPayroll.Controls.Add(lblPayrollTitle);
            pnlStatPayroll.Controls.Add(lblPayrollValue);
            pnlStatPayroll.CustomizableEdges = customizableEdges7;
            pnlStatPayroll.Location = new Point(702, 15);
            pnlStatPayroll.Name = "pnlStatPayroll";
            pnlStatPayroll.ShadowDecoration.CustomizableEdges = customizableEdges8;
            pnlStatPayroll.Size = new Size(280, 82);
            pnlStatPayroll.TabIndex = 3;
            // 
            // lblPayrollTitle
            // 
            lblPayrollTitle.AutoSize = true;
            lblPayrollTitle.Font = new Font("Segoe UI", 9F);
            lblPayrollTitle.ForeColor = Color.FromArgb(160, 160, 166);
            lblPayrollTitle.Location = new Point(18, 18);
            lblPayrollTitle.Name = "lblPayrollTitle";
            lblPayrollTitle.Size = new Size(122, 15);
            lblPayrollTitle.TabIndex = 0;
            lblPayrollTitle.Text = "Quỹ lương (Tạm tính)";
            // 
            // lblPayrollValue
            // 
            lblPayrollValue.AutoSize = true;
            lblPayrollValue.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            lblPayrollValue.ForeColor = Color.IndianRed;
            lblPayrollValue.Location = new Point(18, 42);
            lblPayrollValue.Name = "lblPayrollValue";
            lblPayrollValue.Size = new Size(137, 28);
            lblPayrollValue.TabIndex = 1;
            lblPayrollValue.Text = "42,500,000 đ";
            // 
            // pnlStaffList
            // 
            pnlStaffList.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
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
            pnlStaffList.CustomizableEdges = customizableEdges25;
            pnlStaffList.Location = new Point(0, 110);
            pnlStaffList.Name = "pnlStaffList";
            pnlStaffList.ShadowDecoration.CustomizableEdges = customizableEdges26;
            pnlStaffList.Size = new Size(685, 555);
            pnlStaffList.TabIndex = 1;
            // 
            // lblStaffTitle
            // 
            lblStaffTitle.AutoSize = true;
            lblStaffTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblStaffTitle.ForeColor = Color.White;
            lblStaffTitle.Location = new Point(18, 16);
            lblStaffTitle.Name = "lblStaffTitle";
            lblStaffTitle.Size = new Size(154, 20);
            lblStaffTitle.TabIndex = 0;
            lblStaffTitle.Text = "Hồ sơ Nhân viên";
            // 
            // btnAddStaff
            // 
            btnAddStaff.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAddStaff.BorderRadius = 8;
            btnAddStaff.Cursor = Cursors.Hand;
            btnAddStaff.CustomizableEdges = customizableEdges11;
            btnAddStaff.FillColor = Color.FromArgb(31, 138, 154);
            btnAddStaff.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnAddStaff.ForeColor = Color.White;
            btnAddStaff.HoverState.FillColor = Color.FromArgb(45, 158, 174);
            btnAddStaff.HoverState.ForeColor = Color.White;
            btnAddStaff.Location = new Point(390, 14);
            btnAddStaff.Name = "btnAddStaff";
            btnAddStaff.ShadowDecoration.CustomizableEdges = customizableEdges12;
            btnAddStaff.Size = new Size(130, 28);
            btnAddStaff.TabIndex = 1;
            btnAddStaff.Text = "+ Thêm NV Mới";
            btnAddStaff.Click += btnAddStaff_Click;
            // 
            // btnEditStaff
            // 
            btnEditStaff.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnEditStaff.BorderColor = Color.FromArgb(80, 80, 90);
            btnEditStaff.BorderRadius = 8;
            btnEditStaff.BorderThickness = 1;
            btnEditStaff.Cursor = Cursors.Hand;
            btnEditStaff.CustomizableEdges = customizableEdges13;
            btnEditStaff.FillColor = Color.Transparent;
            btnEditStaff.Font = new Font("Segoe UI", 9F);
            btnEditStaff.ForeColor = Color.FromArgb(220, 220, 225);
            btnEditStaff.HoverState.FillColor = Color.FromArgb(45, 45, 50);
            btnEditStaff.HoverState.ForeColor = Color.White;
            btnEditStaff.Location = new Point(528, 14);
            btnEditStaff.Name = "btnEditStaff";
            btnEditStaff.ShadowDecoration.CustomizableEdges = customizableEdges14;
            btnEditStaff.Size = new Size(100, 28);
            btnEditStaff.TabIndex = 2;
            btnEditStaff.Text = "Sửa";
            btnEditStaff.Click += btnEditStaff_Click;
            // 
            // txtSearch
            // 
            txtSearch.BorderColor = Color.FromArgb(63, 63, 70);
            txtSearch.BorderRadius = 8;
            txtSearch.CustomizableEdges = customizableEdges15;
            txtSearch.DefaultText = "";
            txtSearch.DisabledState.BorderColor = Color.FromArgb(63, 63, 70);
            txtSearch.DisabledState.FillColor = Color.FromArgb(45, 45, 48);
            txtSearch.FillColor = Color.FromArgb(24, 24, 27);
            txtSearch.FocusedState.BorderColor = Color.FromArgb(31, 138, 154);
            txtSearch.Font = new Font("Segoe UI", 9.5F);
            txtSearch.ForeColor = Color.White;
            txtSearch.HoverState.BorderColor = Color.FromArgb(80, 80, 90);
            txtSearch.Location = new Point(18, 54);
            txtSearch.Name = "txtSearch";
            txtSearch.PasswordChar = '\0';
            txtSearch.PlaceholderText = "Tên, mã NV, vị trí, SĐT...";
            txtSearch.SelectedText = "";
            txtSearch.ShadowDecoration.CustomizableEdges = customizableEdges16;
            txtSearch.Size = new Size(155, 36);
            txtSearch.TabIndex = 3;
            // 
            // cbRole
            // 
            cbRole.BackColor = Color.Transparent;
            cbRole.BorderColor = Color.FromArgb(63, 63, 70);
            cbRole.BorderRadius = 8;
            cbRole.CustomizableEdges = customizableEdges17;
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
            cbRole.ShadowDecoration.CustomizableEdges = customizableEdges18;
            cbRole.Size = new Size(130, 32);
            cbRole.TabIndex = 4;
            // 
            // cbStatus
            // 
            cbStatus.BackColor = Color.Transparent;
            cbStatus.BorderColor = Color.FromArgb(63, 63, 70);
            cbStatus.BorderRadius = 8;
            cbStatus.CustomizableEdges = customizableEdges19;
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
            cbStatus.ShadowDecoration.CustomizableEdges = customizableEdges20;
            cbStatus.Size = new Size(130, 32);
            cbStatus.TabIndex = 5;
            // 
            // btnFilter
            // 
            btnFilter.BorderRadius = 8;
            btnFilter.Cursor = Cursors.Hand;
            btnFilter.CustomizableEdges = customizableEdges21;
            btnFilter.FillColor = Color.FromArgb(31, 138, 154);
            btnFilter.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnFilter.ForeColor = Color.White;
            btnFilter.HoverState.FillColor = Color.FromArgb(45, 158, 174);
            btnFilter.HoverState.ForeColor = Color.White;
            btnFilter.Location = new Point(457, 54);
            btnFilter.Name = "btnFilter";
            btnFilter.ShadowDecoration.CustomizableEdges = customizableEdges22;
            btnFilter.Size = new Size(82, 36);
            btnFilter.TabIndex = 6;
            btnFilter.Text = "Lọc";
            // 
            // btnClearFilter
            // 
            btnClearFilter.BorderRadius = 8;
            btnClearFilter.Cursor = Cursors.Hand;
            btnClearFilter.CustomizableEdges = customizableEdges23;
            btnClearFilter.FillColor = Color.FromArgb(127, 29, 29);
            btnClearFilter.Font = new Font("Segoe UI", 9F);
            btnClearFilter.ForeColor = Color.FromArgb(252, 165, 165);
            btnClearFilter.HoverState.FillColor = Color.FromArgb(185, 28, 28);
            btnClearFilter.HoverState.ForeColor = Color.White;
            btnClearFilter.Location = new Point(547, 54);
            btnClearFilter.Name = "btnClearFilter";
            btnClearFilter.ShadowDecoration.CustomizableEdges = customizableEdges24;
            btnClearFilter.Size = new Size(82, 36);
            btnClearFilter.TabIndex = 7;
            btnClearFilter.Text = "Xóa";
            btnClearFilter.Click += btnClearFilter_Click;
            // 
            // dgvStaff
            // 
            dataGridViewCellStyle1.BackColor = Color.FromArgb(24, 24, 27);
            dataGridViewCellStyle1.ForeColor = Color.FromArgb(220, 220, 225);
            dgvStaff.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvStaff.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvStaff.BackgroundColor = Color.FromArgb(24, 24, 27);
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(31, 31, 34);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(160, 160, 166);
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(31, 31, 34);
            dataGridViewCellStyle2.SelectionForeColor = Color.FromArgb(160, 160, 166);
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvStaff.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvStaff.Columns.AddRange(new DataGridViewColumn[] { colStaffId, colStaffName, colStaffPosition, colStaffStatus, colStaffPhone, colStaffAuthUid, colStaffEmail });
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.FromArgb(24, 24, 27);
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(220, 220, 225);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(31, 138, 154);
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(240, 240, 245);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvStaff.DefaultCellStyle = dataGridViewCellStyle3;
            dgvStaff.GridColor = Color.FromArgb(45, 45, 48);
            dgvStaff.Location = new Point(18, 100);
            dgvStaff.Name = "dgvStaff";
            dgvStaff.RowHeadersVisible = false;
            dgvStaff.Size = new Size(649, 440);
            dgvStaff.TabIndex = 8;
            dgvStaff.ThemeStyle.AlternatingRowsStyle.BackColor = Color.FromArgb(24, 24, 27);
            dgvStaff.ThemeStyle.AlternatingRowsStyle.Font = null;
            dgvStaff.ThemeStyle.AlternatingRowsStyle.ForeColor = Color.FromArgb(220, 220, 225);
            dgvStaff.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.Empty;
            dgvStaff.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.Empty;
            dgvStaff.ThemeStyle.BackColor = Color.FromArgb(24, 24, 27);
            dgvStaff.ThemeStyle.GridColor = Color.FromArgb(45, 45, 48);
            dgvStaff.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(31, 31, 34);
            dgvStaff.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvStaff.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dgvStaff.ThemeStyle.HeaderStyle.ForeColor = Color.FromArgb(160, 160, 166);
            dgvStaff.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvStaff.ThemeStyle.HeaderStyle.Height = 23;
            dgvStaff.ThemeStyle.ReadOnly = false;
            dgvStaff.ThemeStyle.RowsStyle.BackColor = Color.FromArgb(24, 24, 27);
            dgvStaff.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvStaff.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 9F);
            dgvStaff.ThemeStyle.RowsStyle.ForeColor = Color.FromArgb(220, 220, 225);
            dgvStaff.ThemeStyle.RowsStyle.Height = 25;
            dgvStaff.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(31, 138, 154);
            dgvStaff.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(240, 240, 245);
            dgvStaff.CellDoubleClick += DgvStaff_CellDoubleClick;
            // 
            // colStaffId
            // 
            colStaffId.DataPropertyName = "Mã NV";
            colStaffId.HeaderText = "Mã NV";
            colStaffId.Name = "colStaffId";
            // 
            // colStaffName
            // 
            colStaffName.DataPropertyName = "Họ và Tên";
            colStaffName.HeaderText = "Họ và Tên";
            colStaffName.Name = "colStaffName";
            // 
            // colStaffPosition
            // 
            colStaffPosition.DataPropertyName = "Vị Trí";
            colStaffPosition.HeaderText = "Vị Trí";
            colStaffPosition.Name = "colStaffPosition";
            // 
            // colStaffStatus
            // 
            colStaffStatus.DataPropertyName = "Trạng Thái";
            colStaffStatus.HeaderText = "Trạng Thái";
            colStaffStatus.Name = "colStaffStatus";
            // 
            // colStaffPhone
            // 
            colStaffPhone.DataPropertyName = "Số điện thoại";
            colStaffPhone.HeaderText = "Số điện thoại";
            colStaffPhone.Name = "colStaffPhone";
            colStaffPhone.Visible = false;
            // 
            // colStaffAuthUid
            // 
            colStaffAuthUid.DataPropertyName = "AuthUid";
            colStaffAuthUid.HeaderText = "AuthUid";
            colStaffAuthUid.Name = "colStaffAuthUid";
            colStaffAuthUid.Visible = false;
            // 
            // colStaffEmail
            // 
            colStaffEmail.DataPropertyName = "Email";
            colStaffEmail.HeaderText = "Email";
            colStaffEmail.Name = "colStaffEmail";
            colStaffEmail.Visible = false;
            // 
            // pnlLeaveRequests
            // 
            pnlLeaveRequests.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            pnlLeaveRequests.BackColor = Color.FromArgb(31, 31, 34);
            pnlLeaveRequests.BorderRadius = 14;
            pnlLeaveRequests.Controls.Add(lblLeaveReqTitle);
            pnlLeaveRequests.Controls.Add(btnApproveLeave);
            pnlLeaveRequests.Controls.Add(dgvLeaveReq);
            pnlLeaveRequests.CustomizableEdges = customizableEdges29;
            pnlLeaveRequests.Location = new Point(695, 110);
            pnlLeaveRequests.Name = "pnlLeaveRequests";
            pnlLeaveRequests.ShadowDecoration.CustomizableEdges = customizableEdges30;
            pnlLeaveRequests.Size = new Size(305, 555);
            pnlLeaveRequests.TabIndex = 2;
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
            // 
            // btnApproveLeave
            // 
            btnApproveLeave.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnApproveLeave.BorderRadius = 8;
            btnApproveLeave.Cursor = Cursors.Hand;
            btnApproveLeave.CustomizableEdges = customizableEdges27;
            btnApproveLeave.FillColor = Color.FromArgb(34, 197, 94);
            btnApproveLeave.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnApproveLeave.ForeColor = Color.White;
            btnApproveLeave.HoverState.FillColor = Color.FromArgb(50, 217, 110);
            btnApproveLeave.HoverState.ForeColor = Color.White;
            btnApproveLeave.Location = new Point(196, 14);
            btnApproveLeave.Name = "btnApproveLeave";
            btnApproveLeave.ShadowDecoration.CustomizableEdges = customizableEdges28;
            btnApproveLeave.Size = new Size(95, 28);
            btnApproveLeave.TabIndex = 1;
            btnApproveLeave.Text = "Duyệt";
            btnApproveLeave.Click += BtnApproveLeave_Click;
            // 
            // dgvLeaveReq
            // 
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
            dgvLeaveReq.Name = "dgvLeaveReq";
            dgvLeaveReq.RowHeadersVisible = false;
            dgvLeaveReq.Size = new Size(269, 485);
            dgvLeaveReq.TabIndex = 2;
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
            dgvLeaveReq.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvLeaveReq.ThemeStyle.HeaderStyle.Height = 23;
            dgvLeaveReq.ThemeStyle.ReadOnly = false;
            dgvLeaveReq.ThemeStyle.RowsStyle.BackColor = Color.FromArgb(24, 24, 27);
            dgvLeaveReq.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvLeaveReq.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 9F);
            dgvLeaveReq.ThemeStyle.RowsStyle.ForeColor = Color.FromArgb(220, 220, 225);
            dgvLeaveReq.ThemeStyle.RowsStyle.Height = 25;
            dgvLeaveReq.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(31, 138, 154);
            dgvLeaveReq.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(240, 240, 245);
            // 
            // colLeaveStaff
            // 
            colLeaveStaff.DataPropertyName = "Nhân viên";
            colLeaveStaff.HeaderText = "Nhân viên";
            colLeaveStaff.Name = "colLeaveStaff";
            // 
            // colLeaveDate
            // 
            colLeaveDate.DataPropertyName = "Ngày nghỉ";
            colLeaveDate.HeaderText = "Ngày nghỉ";
            colLeaveDate.Name = "colLeaveDate";
            // 
            // colLeaveReason
            // 
            colLeaveReason.DataPropertyName = "Lý do";
            colLeaveReason.HeaderText = "Lý do";
            colLeaveReason.Name = "colLeaveReason";
            // 
            // ucStaff_Manager
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(39, 39, 42);
            Controls.Add(pnlSummary);
            Controls.Add(pnlStaffList);
            Controls.Add(pnlLeaveRequests);
            Name = "ucStaff_Manager";
            Size = new Size(1000, 665);
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
            dgv.AutoGenerateColumns   = false;
            dgv.AllowUserToAddRows    = false;
            dgv.AllowUserToResizeRows = false;
            dgv.BackgroundColor       = Color.FromArgb(24, 24, 27);
            dgv.BorderStyle           = BorderStyle.None;
            dgv.CellBorderStyle       = DataGridViewCellBorderStyle.SingleHorizontal;
            dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgv.ColumnHeadersHeight   = 32;
            dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgv.ColumnHeadersDefaultCellStyle.BackColor         = Color.FromArgb(31, 31, 34);
            dgv.ColumnHeadersDefaultCellStyle.ForeColor         = Color.FromArgb(160, 160, 166);
            dgv.ColumnHeadersDefaultCellStyle.Font              = new Font("Segoe UI", 9F, FontStyle.Bold);
            dgv.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(31, 31, 34);
            dgv.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.FromArgb(160, 160, 166);
            dgv.DefaultCellStyle.BackColor         = Color.FromArgb(24, 24, 27);
            dgv.DefaultCellStyle.ForeColor         = Color.FromArgb(220, 220, 225);
            dgv.DefaultCellStyle.Font              = new Font("Segoe UI", 9F);
            dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(31, 138, 154);
            dgv.DefaultCellStyle.SelectionForeColor = Color.FromArgb(240, 240, 245);
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(24, 24, 27);
            dgv.AlternatingRowsDefaultCellStyle.ForeColor = Color.FromArgb(220, 220, 225);
            dgv.AlternatingRowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(31, 138, 154);
            dgv.AlternatingRowsDefaultCellStyle.SelectionForeColor = Color.FromArgb(240, 240, 245);
            dgv.EnableHeadersVisualStyles = false;
            dgv.GridColor     = Color.FromArgb(45, 45, 48);
            dgv.MultiSelect   = false;
            dgv.ReadOnly      = true;
            dgv.RowHeadersVisible = false;
            dgv.RowTemplate.DefaultCellStyle.SelectionBackColor = Color.FromArgb(31, 138, 154);
            dgv.RowTemplate.DefaultCellStyle.SelectionForeColor = Color.FromArgb(240, 240, 245);
            dgv.RowTemplate.Height = 28;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DgvDarkScroll.Apply(dgv);
            // ThemeStyle
            dgv.ThemeStyle.AlternatingRowsStyle.BackColor = Color.FromArgb(24, 24, 27);
            dgv.ThemeStyle.AlternatingRowsStyle.Font             = null;
            dgv.ThemeStyle.AlternatingRowsStyle.ForeColor        = Color.FromArgb(220, 220, 225);
            dgv.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.Empty;
            dgv.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.Empty;
            dgv.ThemeStyle.BackColor  = Color.FromArgb(24, 24, 27);
            dgv.ThemeStyle.GridColor  = Color.FromArgb(45, 45, 48);
            dgv.ThemeStyle.HeaderStyle.BackColor    = Color.FromArgb(31, 31, 34);
            dgv.ThemeStyle.HeaderStyle.BorderStyle  = DataGridViewHeaderBorderStyle.None;
            dgv.ThemeStyle.HeaderStyle.Font         = new Font("Segoe UI", 9F, FontStyle.Bold);
            dgv.ThemeStyle.HeaderStyle.ForeColor    = Color.FromArgb(160, 160, 166);
            dgv.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgv.ThemeStyle.HeaderStyle.Height       = 32;
            dgv.ThemeStyle.ReadOnly = true;
            dgv.ThemeStyle.RowsStyle.BackColor         = Color.FromArgb(24, 24, 27);
            dgv.ThemeStyle.RowsStyle.BorderStyle       = DataGridViewCellBorderStyle.SingleHorizontal;
            dgv.ThemeStyle.RowsStyle.Font              = new Font("Segoe UI", 9F);
            dgv.ThemeStyle.RowsStyle.ForeColor         = Color.FromArgb(220, 220, 225);
            dgv.ThemeStyle.RowsStyle.Height            = 28;
            dgv.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(31, 138, 154);
            dgv.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(240, 240, 245);
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
        private DataGridViewTextBoxColumn colStaffId;
        private DataGridViewTextBoxColumn colStaffName;
        private DataGridViewTextBoxColumn colStaffPosition;
        private DataGridViewTextBoxColumn colStaffStatus;
        private DataGridViewTextBoxColumn colStaffPhone;
        private DataGridViewTextBoxColumn colStaffAuthUid;
        private DataGridViewTextBoxColumn colStaffEmail;

        private Guna2Panel        pnlLeaveRequests;
        private Label             lblLeaveReqTitle;
        private Guna2Button       btnApproveLeave;
        private Guna2DataGridView dgvLeaveReq;
        private DataGridViewTextBoxColumn colLeaveStaff;
        private DataGridViewTextBoxColumn colLeaveDate;
        private DataGridViewTextBoxColumn colLeaveReason;

        #endregion
    }
}
