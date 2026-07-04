using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace GUI
{
    partial class ucLoyalty_Order
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges11 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges12 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges13 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges14 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges15 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges16 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges17 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges18 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges19 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges20 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges21 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges22 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            lblTitle = new Label();
            lblSub = new Label();
            pnlSearch = new Guna2Panel();
            lblPhoneCap = new Label();
            txtPhone = new Guna2TextBox();
            btnSearch = new Guna2Button();
            btnRegister = new Guna2Button();
            pnlCustomer = new Panel();
            pnlInfo = new Guna2Panel();
            lblName = new Label();
            lblTier = new Label();
            lblPhoneTag = new Label();
            lblPhone = new Label();
            pnlPoint = new Guna2Panel();
            lblPointCap = new Label();
            lblPoints = new Label();
            lblPointUnit = new Label();
            lblVisits = new Label();
            btnAddPoints = new Guna2Button();
            btnRedeem = new Guna2Button();
            lblTierHead = new Label();
            lblHistHead = new Label();
            pnlTier = new Guna2Panel();
            dgvTier = new Guna2DataGridView();
            colTierName = new DataGridViewTextBoxColumn();
            colTierReq = new DataGridViewTextBoxColumn();
            colTierPerk = new DataGridViewTextBoxColumn();
            pnlHist = new Guna2Panel();
            dgvHistory = new Guna2DataGridView();
            colHistDate = new DataGridViewTextBoxColumn();
            colHistAction = new DataGridViewTextBoxColumn();
            colHistPoints = new DataGridViewTextBoxColumn();
            colHistNote = new DataGridViewTextBoxColumn();
            hintCard = new Guna2Panel();
            lblHint = new Label();
            pnlSearch.SuspendLayout();
            pnlCustomer.SuspendLayout();
            pnlInfo.SuspendLayout();
            pnlPoint.SuspendLayout();
            pnlTier.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTier).BeginInit();
            pnlHist.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvHistory).BeginInit();
            hintCard.SuspendLayout();
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
            lblTitle.Size = new Size(374, 25);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Loyalty — Tích điểm & Hạng thành viên";
            // 
            // lblSub
            // 
            lblSub.AutoSize = true;
            lblSub.BackColor = Color.Transparent;
            lblSub.Font = new Font("Segoe UI", 9F);
            lblSub.ForeColor = Color.FromArgb(160, 160, 166);
            lblSub.Location = new Point(22, 46);
            lblSub.Name = "lblSub";
            lblSub.Size = new Size(285, 15);
            lblSub.TabIndex = 1;
            lblSub.Text = "Tìm kiếm khách hàng theo SĐT · Tích điểm · Đổi quà";
            // 
            // pnlSearch
            // 
            pnlSearch.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlSearch.BackColor = Color.Transparent;
            pnlSearch.BorderRadius = 14;
            pnlSearch.Controls.Add(lblPhoneCap);
            pnlSearch.Controls.Add(txtPhone);
            pnlSearch.Controls.Add(btnSearch);
            pnlSearch.Controls.Add(btnRegister);
            pnlSearch.CustomizableEdges = customizableEdges7;
            pnlSearch.FillColor = Color.FromArgb(31, 31, 34);
            pnlSearch.Location = new Point(16, 70);
            pnlSearch.Name = "pnlSearch";
            pnlSearch.ShadowDecoration.CustomizableEdges = customizableEdges8;
            pnlSearch.Size = new Size(968, 60);
            pnlSearch.TabIndex = 2;
            // 
            // lblPhoneCap
            // 
            lblPhoneCap.AutoSize = true;
            lblPhoneCap.BackColor = Color.Transparent;
            lblPhoneCap.Font = new Font("Segoe UI", 9.5F);
            lblPhoneCap.ForeColor = Color.FromArgb(160, 160, 166);
            lblPhoneCap.Location = new Point(14, 20);
            lblPhoneCap.Name = "lblPhoneCap";
            lblPhoneCap.Size = new Size(88, 17);
            lblPhoneCap.TabIndex = 0;
            lblPhoneCap.Text = "Số điện thoại:";
            // 
            // txtPhone
            // 
            txtPhone.BorderColor = Color.FromArgb(63, 63, 70);
            txtPhone.BorderRadius = 8;
            txtPhone.CustomizableEdges = customizableEdges1;
            txtPhone.DefaultText = "";
            txtPhone.FillColor = Color.FromArgb(30, 30, 33);
            txtPhone.FocusedState.BorderColor = Color.FromArgb(31, 138, 154);
            txtPhone.Font = new Font("Segoe UI", 9.5F);
            txtPhone.ForeColor = Color.FromArgb(240, 240, 245);
            txtPhone.HoverState.BorderColor = Color.FromArgb(120, 120, 130);
            txtPhone.Location = new Point(120, 12);
            txtPhone.Name = "txtPhone";
            txtPhone.PasswordChar = '\0';
            txtPhone.PlaceholderForeColor = Color.FromArgb(110, 110, 120);
            txtPhone.PlaceholderText = "VD: 0901234567";
            txtPhone.SelectedText = "";
            txtPhone.ShadowDecoration.CustomizableEdges = customizableEdges2;
            txtPhone.Size = new Size(220, 36);
            txtPhone.TabIndex = 1;
            // 
            // btnSearch
            // 
            btnSearch.BorderRadius = 10;
            btnSearch.Cursor = Cursors.Hand;
            btnSearch.CustomizableEdges = customizableEdges3;
            btnSearch.FillColor = Color.FromArgb(31, 138, 154);
            btnSearch.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnSearch.ForeColor = Color.White;
            btnSearch.HoverState.FillColor = Color.FromArgb(47, 154, 170);
            btnSearch.Location = new Point(352, 12);
            btnSearch.Name = "btnSearch";
            btnSearch.ShadowDecoration.CustomizableEdges = customizableEdges4;
            btnSearch.Size = new Size(130, 36);
            btnSearch.TabIndex = 2;
            btnSearch.Text = "Tìm khách";
            btnSearch.Click += BtnSearch_Click;
            // 
            // btnRegister
            // 
            btnRegister.BorderColor = Color.FromArgb(63, 63, 70);
            btnRegister.BorderRadius = 10;
            btnRegister.BorderThickness = 1;
            btnRegister.Cursor = Cursors.Hand;
            btnRegister.CustomizableEdges = customizableEdges5;
            btnRegister.FillColor = Color.Transparent;
            btnRegister.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnRegister.ForeColor = Color.FromArgb(220, 220, 225);
            btnRegister.HoverState.BorderColor = Color.FromArgb(103, 103, 110);
            btnRegister.HoverState.FillColor = Color.FromArgb(45, 45, 50);
            btnRegister.Location = new Point(494, 12);
            btnRegister.Name = "btnRegister";
            btnRegister.ShadowDecoration.CustomizableEdges = customizableEdges6;
            btnRegister.Size = new Size(130, 36);
            btnRegister.TabIndex = 3;
            btnRegister.Text = "+ Đăng ký mới";
            btnRegister.Click += BtnRegister_Click;
            // 
            // pnlCustomer
            // 
            pnlCustomer.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnlCustomer.BackColor = Color.Transparent;
            pnlCustomer.Controls.Add(pnlInfo);
            pnlCustomer.Controls.Add(pnlPoint);
            pnlCustomer.Controls.Add(btnAddPoints);
            pnlCustomer.Controls.Add(btnRedeem);
            pnlCustomer.Controls.Add(lblTierHead);
            pnlCustomer.Controls.Add(lblHistHead);
            pnlCustomer.Controls.Add(pnlTier);
            pnlCustomer.Controls.Add(pnlHist);
            pnlCustomer.Location = new Point(16, 144);
            pnlCustomer.Name = "pnlCustomer";
            pnlCustomer.Size = new Size(968, 505);
            pnlCustomer.TabIndex = 3;
            pnlCustomer.Visible = false;
            // 
            // pnlInfo
            // 
            pnlInfo.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlInfo.BackColor = Color.Transparent;
            pnlInfo.BorderRadius = 14;
            pnlInfo.Controls.Add(lblName);
            pnlInfo.Controls.Add(lblTier);
            pnlInfo.Controls.Add(lblPhoneTag);
            pnlInfo.Controls.Add(lblPhone);
            pnlInfo.CustomizableEdges = customizableEdges9;
            pnlInfo.FillColor = Color.FromArgb(31, 31, 34);
            pnlInfo.Location = new Point(0, 0);
            pnlInfo.Name = "pnlInfo";
            pnlInfo.ShadowDecoration.CustomizableEdges = customizableEdges10;
            pnlInfo.Size = new Size(698, 110);
            pnlInfo.TabIndex = 0;
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.BackColor = Color.Transparent;
            lblName.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblName.ForeColor = Color.FromArgb(240, 240, 245);
            lblName.Location = new Point(16, 14);
            lblName.Name = "lblName";
            lblName.Size = new Size(185, 25);
            lblName.TabIndex = 0;
            lblName.Text = "NGUYỄN MINH TRÍ";
            // 
            // lblTier
            // 
            lblTier.AutoSize = true;
            lblTier.BackColor = Color.Transparent;
            lblTier.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblTier.ForeColor = Color.FromArgb(245, 158, 11);
            lblTier.Location = new Point(16, 42);
            lblTier.Name = "lblTier";
            lblTier.Size = new Size(146, 19);
            lblTier.TabIndex = 1;
            lblTier.Text = "\U0001f947  Thành viên Vàng";
            // 
            // lblPhoneTag
            // 
            lblPhoneTag.AutoSize = true;
            lblPhoneTag.BackColor = Color.Transparent;
            lblPhoneTag.Font = new Font("Segoe UI", 9F);
            lblPhoneTag.ForeColor = Color.FromArgb(160, 160, 166);
            lblPhoneTag.Location = new Point(16, 70);
            lblPhoneTag.Name = "lblPhoneTag";
            lblPhoneTag.Size = new Size(34, 15);
            lblPhoneTag.TabIndex = 2;
            lblPhoneTag.Text = "SĐT: ";
            // 
            // lblPhone
            // 
            lblPhone.AutoSize = true;
            lblPhone.BackColor = Color.Transparent;
            lblPhone.Font = new Font("Segoe UI", 9F);
            lblPhone.ForeColor = Color.FromArgb(220, 220, 225);
            lblPhone.Location = new Point(48, 70);
            lblPhone.Name = "lblPhone";
            lblPhone.Size = new Size(22, 15);
            lblPhone.TabIndex = 3;
            lblPhone.Text = "---";
            // 
            // pnlPoint
            // 
            pnlPoint.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pnlPoint.BackColor = Color.Transparent;
            pnlPoint.BorderRadius = 14;
            pnlPoint.Controls.Add(lblPointCap);
            pnlPoint.Controls.Add(lblPoints);
            pnlPoint.Controls.Add(lblPointUnit);
            pnlPoint.Controls.Add(lblVisits);
            pnlPoint.CustomizableEdges = customizableEdges11;
            pnlPoint.FillColor = Color.FromArgb(56, 46, 28);
            pnlPoint.Location = new Point(708, 0);
            pnlPoint.Name = "pnlPoint";
            pnlPoint.ShadowDecoration.CustomizableEdges = customizableEdges12;
            pnlPoint.Size = new Size(260, 110);
            pnlPoint.TabIndex = 1;
            // 
            // lblPointCap
            // 
            lblPointCap.AutoSize = true;
            lblPointCap.BackColor = Color.Transparent;
            lblPointCap.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            lblPointCap.ForeColor = Color.FromArgb(245, 158, 11);
            lblPointCap.Location = new Point(14, 10);
            lblPointCap.Name = "lblPointCap";
            lblPointCap.Size = new Size(92, 15);
            lblPointCap.TabIndex = 0;
            lblPointCap.Text = "ĐIỂM TÍCH LŨY";
            // 
            // lblPoints
            // 
            lblPoints.AutoSize = true;
            lblPoints.BackColor = Color.Transparent;
            lblPoints.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            lblPoints.ForeColor = Color.FromArgb(240, 240, 245);
            lblPoints.Location = new Point(14, 32);
            lblPoints.Name = "lblPoints";
            lblPoints.Size = new Size(94, 41);
            lblPoints.TabIndex = 1;
            lblPoints.Text = "—";
            // 
            // lblPointUnit
            // 
            lblPointUnit.AutoSize = true;
            lblPointUnit.BackColor = Color.Transparent;
            lblPointUnit.Font = new Font("Segoe UI", 9F);
            lblPointUnit.ForeColor = Color.FromArgb(160, 160, 166);
            lblPointUnit.Location = new Point(114, 58);
            lblPointUnit.Name = "lblPointUnit";
            lblPointUnit.Size = new Size(34, 15);
            lblPointUnit.TabIndex = 2;
            lblPointUnit.Text = "điểm";
            // 
            // lblVisits
            // 
            lblVisits.AutoSize = true;
            lblVisits.BackColor = Color.Transparent;
            lblVisits.Font = new Font("Segoe UI", 8.5F);
            lblVisits.ForeColor = Color.FromArgb(245, 158, 11);
            lblVisits.Location = new Point(14, 84);
            lblVisits.Name = "lblVisits";
            lblVisits.Size = new Size(97, 15);
            lblVisits.TabIndex = 3;
            lblVisits.Text = "—";
            // 
            // btnAddPoints
            // 
            btnAddPoints.BorderRadius = 10;
            btnAddPoints.Cursor = Cursors.Hand;
            btnAddPoints.CustomizableEdges = customizableEdges13;
            btnAddPoints.FillColor = Color.FromArgb(31, 138, 154);
            btnAddPoints.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnAddPoints.ForeColor = Color.White;
            btnAddPoints.HoverState.FillColor = Color.FromArgb(47, 154, 170);
            btnAddPoints.Location = new Point(0, 120);
            btnAddPoints.Name = "btnAddPoints";
            btnAddPoints.ShadowDecoration.CustomizableEdges = customizableEdges14;
            btnAddPoints.Size = new Size(180, 38);
            btnAddPoints.TabIndex = 2;
            btnAddPoints.Text = "+ Tích điểm đơn này";
            btnAddPoints.Click += BtnAddPoints_Click;
            // 
            // btnRedeem
            // 
            btnRedeem.BorderRadius = 10;
            btnRedeem.Cursor = Cursors.Hand;
            btnRedeem.CustomizableEdges = customizableEdges15;
            btnRedeem.FillColor = Color.FromArgb(245, 158, 11);
            btnRedeem.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnRedeem.ForeColor = Color.White;
            btnRedeem.HoverState.FillColor = Color.FromArgb(255, 174, 27);
            btnRedeem.Location = new Point(192, 120);
            btnRedeem.Name = "btnRedeem";
            btnRedeem.ShadowDecoration.CustomizableEdges = customizableEdges16;
            btnRedeem.Size = new Size(130, 38);
            btnRedeem.TabIndex = 3;
            btnRedeem.Text = "Đổi quà";
            btnRedeem.Click += BtnRedeem_Click;
            // 
            // lblTierHead
            // 
            lblTierHead.AutoSize = true;
            lblTierHead.BackColor = Color.Transparent;
            lblTierHead.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblTierHead.ForeColor = Color.FromArgb(240, 240, 245);
            lblTierHead.Location = new Point(0, 172);
            lblTierHead.Name = "lblTierHead";
            lblTierHead.Size = new Size(118, 19);
            lblTierHead.TabIndex = 4;
            lblTierHead.Text = "Hạng thành viên";
            // 
            // lblHistHead
            // 
            lblHistHead.AutoSize = true;
            lblHistHead.BackColor = Color.Transparent;
            lblHistHead.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblHistHead.ForeColor = Color.FromArgb(240, 240, 245);
            lblHistHead.Location = new Point(362, 172);
            lblHistHead.Name = "lblHistHead";
            lblHistHead.Size = new Size(164, 19);
            lblHistHead.TabIndex = 5;
            lblHistHead.Text = "Lịch sử điểm (gần nhất)";
            // 
            // pnlTier
            // 
            pnlTier.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            pnlTier.BackColor = Color.Transparent;
            pnlTier.BorderRadius = 14;
            pnlTier.Controls.Add(dgvTier);
            pnlTier.CustomizableEdges = customizableEdges17;
            pnlTier.FillColor = Color.FromArgb(24, 24, 27);
            pnlTier.Location = new Point(0, 192);
            pnlTier.Name = "pnlTier";
            pnlTier.ShadowDecoration.CustomizableEdges = customizableEdges18;
            pnlTier.Size = new Size(350, 305);
            pnlTier.TabIndex = 6;
            // 
            // dgvTier
            // 
            dgvTier.AllowUserToAddRows = false;
            dgvTier.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = Color.White;
            dgvTier.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvTier.BackgroundColor = Color.FromArgb(24, 24, 27);
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(100, 88, 255);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvTier.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvTier.Columns.AddRange(new DataGridViewColumn[] { colTierName, colTierReq, colTierPerk });
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvTier.DefaultCellStyle = dataGridViewCellStyle3;
            dgvTier.Dock = DockStyle.Fill;
            dgvTier.GridColor = Color.FromArgb(231, 229, 255);
            dgvTier.Location = new Point(0, 0);
            dgvTier.Name = "dgvTier";
            dgvTier.ReadOnly = true;
            dgvTier.RowHeadersVisible = false;
            dgvTier.RowTemplate.Height = 28;
            dgvTier.Size = new Size(350, 305);
            dgvTier.TabIndex = 0;
            dgvTier.ThemeStyle.AlternatingRowsStyle.BackColor = Color.White;
            dgvTier.ThemeStyle.AlternatingRowsStyle.Font = null;
            dgvTier.ThemeStyle.AlternatingRowsStyle.ForeColor = Color.Empty;
            dgvTier.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.Empty;
            dgvTier.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.Empty;
            dgvTier.ThemeStyle.BackColor = Color.FromArgb(24, 24, 27);
            dgvTier.ThemeStyle.GridColor = Color.FromArgb(231, 229, 255);
            dgvTier.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(100, 88, 255);
            dgvTier.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvTier.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI", 9F);
            dgvTier.ThemeStyle.HeaderStyle.ForeColor = Color.White;
            dgvTier.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvTier.ThemeStyle.HeaderStyle.Height = 23;
            dgvTier.ThemeStyle.ReadOnly = true;
            dgvTier.ThemeStyle.RowsStyle.BackColor = Color.White;
            dgvTier.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvTier.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 9F);
            dgvTier.ThemeStyle.RowsStyle.ForeColor = Color.FromArgb(71, 69, 94);
            dgvTier.ThemeStyle.RowsStyle.Height = 28;
            dgvTier.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dgvTier.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(71, 69, 94);
            // 
            // colTierName
            // 
            colTierName.DataPropertyName = "Hạng";
            colTierName.HeaderText = "Hạng";
            colTierName.Name = "Hạng";
            colTierName.ReadOnly = true;
            // 
            // colTierReq
            // 
            colTierReq.DataPropertyName = "Điểm yêu cầu";
            colTierReq.HeaderText = "Điểm yêu cầu";
            colTierReq.Name = "Điểm yêu cầu";
            colTierReq.ReadOnly = true;
            // 
            // colTierPerk
            // 
            colTierPerk.DataPropertyName = "Ưu đãi";
            colTierPerk.HeaderText = "Ưu đãi";
            colTierPerk.Name = "Ưu đãi";
            colTierPerk.ReadOnly = true;
            // 
            // pnlHist
            // 
            pnlHist.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnlHist.BackColor = Color.Transparent;
            pnlHist.BorderRadius = 14;
            pnlHist.Controls.Add(dgvHistory);
            pnlHist.CustomizableEdges = customizableEdges19;
            pnlHist.FillColor = Color.FromArgb(24, 24, 27);
            pnlHist.Location = new Point(362, 192);
            pnlHist.Name = "pnlHist";
            pnlHist.ShadowDecoration.CustomizableEdges = customizableEdges20;
            pnlHist.Size = new Size(606, 305);
            pnlHist.TabIndex = 7;
            // 
            // dgvHistory
            // 
            dgvHistory.AllowUserToAddRows = false;
            dgvHistory.AllowUserToResizeRows = false;
            dataGridViewCellStyle4.BackColor = Color.White;
            dgvHistory.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            dgvHistory.BackgroundColor = Color.FromArgb(24, 24, 27);
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = Color.FromArgb(100, 88, 255);
            dataGridViewCellStyle5.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle5.ForeColor = Color.White;
            dataGridViewCellStyle5.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.True;
            dgvHistory.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            dgvHistory.Columns.AddRange(new DataGridViewColumn[] { colHistDate, colHistAction, colHistPoints, colHistNote });
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = Color.White;
            dataGridViewCellStyle6.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle6.ForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle6.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dataGridViewCellStyle6.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle6.WrapMode = DataGridViewTriState.False;
            dgvHistory.DefaultCellStyle = dataGridViewCellStyle6;
            dgvHistory.Dock = DockStyle.Fill;
            dgvHistory.GridColor = Color.FromArgb(231, 229, 255);
            dgvHistory.Location = new Point(0, 0);
            dgvHistory.Name = "dgvHistory";
            dgvHistory.ReadOnly = true;
            dgvHistory.RowHeadersVisible = false;
            dgvHistory.RowTemplate.Height = 28;
            dgvHistory.Size = new Size(606, 305);
            dgvHistory.TabIndex = 0;
            dgvHistory.ThemeStyle.AlternatingRowsStyle.BackColor = Color.White;
            dgvHistory.ThemeStyle.AlternatingRowsStyle.Font = null;
            dgvHistory.ThemeStyle.AlternatingRowsStyle.ForeColor = Color.Empty;
            dgvHistory.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.Empty;
            dgvHistory.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.Empty;
            dgvHistory.ThemeStyle.BackColor = Color.FromArgb(24, 24, 27);
            dgvHistory.ThemeStyle.GridColor = Color.FromArgb(231, 229, 255);
            dgvHistory.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(100, 88, 255);
            dgvHistory.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvHistory.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI", 9F);
            dgvHistory.ThemeStyle.HeaderStyle.ForeColor = Color.White;
            dgvHistory.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvHistory.ThemeStyle.HeaderStyle.Height = 23;
            dgvHistory.ThemeStyle.ReadOnly = true;
            dgvHistory.ThemeStyle.RowsStyle.BackColor = Color.White;
            dgvHistory.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvHistory.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 9F);
            dgvHistory.ThemeStyle.RowsStyle.ForeColor = Color.FromArgb(71, 69, 94);
            dgvHistory.ThemeStyle.RowsStyle.Height = 28;
            dgvHistory.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dgvHistory.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(71, 69, 94);
            // 
            // colHistDate
            // 
            colHistDate.DataPropertyName = "Ngày";
            colHistDate.HeaderText = "Ngày";
            colHistDate.Name = "Ngày";
            colHistDate.ReadOnly = true;
            // 
            // colHistAction
            // 
            colHistAction.DataPropertyName = "Thao tác";
            colHistAction.HeaderText = "Thao tác";
            colHistAction.Name = "Thao tác";
            colHistAction.ReadOnly = true;
            // 
            // colHistPoints
            // 
            colHistPoints.DataPropertyName = "Điểm";
            colHistPoints.HeaderText = "Điểm";
            colHistPoints.Name = "Điểm";
            colHistPoints.ReadOnly = true;
            // 
            // colHistNote
            // 
            colHistNote.DataPropertyName = "Ghi chú";
            colHistNote.HeaderText = "Ghi chú";
            colHistNote.Name = "Ghi chú";
            colHistNote.ReadOnly = true;
            // 
            // hintCard
            // 
            hintCard.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            hintCard.BackColor = Color.Transparent;
            hintCard.BorderRadius = 14;
            hintCard.Controls.Add(lblHint);
            hintCard.CustomizableEdges = customizableEdges21;
            hintCard.FillColor = Color.FromArgb(31, 31, 34);
            hintCard.Location = new Point(16, 144);
            hintCard.Name = "hintCard";
            hintCard.ShadowDecoration.CustomizableEdges = customizableEdges22;
            hintCard.Size = new Size(968, 60);
            hintCard.TabIndex = 4;
            // 
            // lblHint
            // 
            lblHint.AutoSize = true;
            lblHint.BackColor = Color.Transparent;
            lblHint.Font = new Font("Segoe UI", 9.5F);
            lblHint.ForeColor = Color.FromArgb(160, 160, 166);
            lblHint.Location = new Point(14, 20);
            lblHint.Name = "lblHint";
            lblHint.Size = new Size(426, 17);
            lblHint.TabIndex = 0;
            lblHint.Text = "Nhập số điện thoại và nhấn 'Tìm khách' để xem thông tin tích điểm.";
            // 
            // ucLoyalty_Order
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(39, 39, 42);
            Controls.Add(lblTitle);
            Controls.Add(lblSub);
            Controls.Add(pnlSearch);
            Controls.Add(pnlCustomer);
            Controls.Add(hintCard);
            Name = "ucLoyalty_Order";
            Size = new Size(1000, 665);
            pnlSearch.ResumeLayout(false);
            pnlSearch.PerformLayout();
            pnlCustomer.ResumeLayout(false);
            pnlCustomer.PerformLayout();
            pnlInfo.ResumeLayout(false);
            pnlInfo.PerformLayout();
            pnlPoint.ResumeLayout(false);
            pnlPoint.PerformLayout();
            pnlTier.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvTier).EndInit();
            pnlHist.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvHistory).EndInit();
            hintCard.ResumeLayout(false);
            hintCard.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private Label lblSub;
        private Guna2Panel pnlSearch;
        private Label lblPhoneCap;
        private Guna2TextBox txtPhone;
        private Guna2Button btnSearch;
        private Guna2Button btnRegister;
        private Panel pnlCustomer;
        private Guna2Panel pnlInfo;
        private Label lblName;
        private Label lblTier;
        private Label lblPhoneTag;
        private Label lblPhone;
        private Guna2Panel pnlPoint;
        private Label lblPointCap;
        private Label lblPoints;
        private Label lblPointUnit;
        private Label lblVisits;
        private Guna2Button btnAddPoints;
        private Guna2Button btnRedeem;
        private Label lblTierHead;
        private Label lblHistHead;
        private Guna2Panel pnlTier;
        private Guna2DataGridView dgvTier;
        private DataGridViewTextBoxColumn colTierName;
        private DataGridViewTextBoxColumn colTierReq;
        private DataGridViewTextBoxColumn colTierPerk;
        private Guna2Panel pnlHist;
        private Guna2DataGridView dgvHistory;
        private DataGridViewTextBoxColumn colHistDate;
        private DataGridViewTextBoxColumn colHistAction;
        private DataGridViewTextBoxColumn colHistPoints;
        private DataGridViewTextBoxColumn colHistNote;
        private Guna2Panel hintCard;
        private Label lblHint;
    }
}
