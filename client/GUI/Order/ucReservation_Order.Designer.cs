using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace GUI
{
    partial class ucReservation_Order
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges11 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges12 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges21 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges22 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges13 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges14 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges15 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges16 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges17 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges18 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges19 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges20 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges23 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges24 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            lblTitle = new Label();
            lblSub = new Label();
            tblCards = new TableLayoutPanel();
            cardToday = new Guna2Panel();
            barToday = new Guna2Panel();
            capToday = new Label();
            lblToday = new Label();
            cardPending = new Guna2Panel();
            barPending = new Guna2Panel();
            capPending = new Label();
            lblPending = new Label();
            cardDone = new Guna2Panel();
            barDone = new Guna2Panel();
            capDone = new Label();
            lblDone = new Label();
            pnlBar = new Guna2Panel();
            txtSearch = new Guna2TextBox();
            cmbStatus = new Guna2ComboBox();
            lblCount = new Label();
            btnAdd = new Guna2Button();
            btnSendReminder = new Guna2Button();
            btnEditRes = new Guna2Button();
            pnlGridCard = new Guna2Panel();
            dgv = new Guna2DataGridView();
            colCode = new DataGridViewTextBoxColumn();
            colName = new DataGridViewTextBoxColumn();
            colPhone = new DataGridViewTextBoxColumn();
            colDateTime = new DataGridViewTextBoxColumn();
            colTable = new DataGridViewTextBoxColumn();
            colGuests = new DataGridViewTextBoxColumn();
            colNote = new DataGridViewTextBoxColumn();
            colStatus = new DataGridViewTextBoxColumn();
            tblCards.SuspendLayout();
            cardToday.SuspendLayout();
            cardPending.SuspendLayout();
            cardDone.SuspendLayout();
            pnlBar.SuspendLayout();
            pnlGridCard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgv).BeginInit();
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
            lblTitle.Size = new Size(168, 25);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Đặt bàn trước";
            // 
            // lblSub
            // 
            lblSub.AutoSize = true;
            lblSub.BackColor = Color.Transparent;
            lblSub.Font = new Font("Segoe UI", 9F);
            lblSub.ForeColor = Color.FromArgb(160, 160, 166);
            lblSub.Location = new Point(22, 46);
            lblSub.Name = "lblSub";
            lblSub.Size = new Size(254, 15);
            lblSub.TabIndex = 1;
            lblSub.Text = "Quản lý đặt bàn · Nhắc nhở qua email trước 2h";
            //
            // tblCards — hàng 3 thẻ giãn đều theo bề ngang
            //
            tblCards.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tblCards.ColumnCount = 3;
            tblCards.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.34F));
            tblCards.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33F));
            tblCards.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33F));
            tblCards.RowCount = 1;
            tblCards.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tblCards.Location = new Point(16, 70);
            tblCards.Size = new Size(968, 96);
            tblCards.Controls.Add(cardToday, 0, 0);
            tblCards.Controls.Add(cardPending, 1, 0);
            tblCards.Controls.Add(cardDone, 2, 0);
            //
            // cardToday
            //
            cardToday.BackColor = Color.Transparent;
            cardToday.BorderRadius = 14;
            cardToday.Controls.Add(barToday);
            cardToday.Controls.Add(capToday);
            cardToday.Controls.Add(lblToday);
            cardToday.CustomizableEdges = customizableEdges3;
            cardToday.FillColor = Color.FromArgb(31, 31, 34);
            cardToday.Dock = DockStyle.Fill;
            cardToday.Margin = new Padding(0, 0, 12, 0);
            cardToday.Name = "cardToday";
            cardToday.ShadowDecoration.CustomizableEdges = customizableEdges4;
            cardToday.TabIndex = 2;
            // 
            // barToday
            // 
            barToday.BorderRadius = 4;
            barToday.CustomizableEdges = customizableEdges1;
            barToday.FillColor = Color.FromArgb(31, 138, 154);
            barToday.Location = new Point(14, 16);
            barToday.Name = "barToday";
            barToday.ShadowDecoration.CustomizableEdges = customizableEdges2;
            barToday.Size = new Size(4, 64);
            barToday.TabIndex = 0;
            // 
            // capToday
            // 
            capToday.AutoSize = true;
            capToday.BackColor = Color.Transparent;
            capToday.Font = new Font("Segoe UI", 9.5F);
            capToday.ForeColor = Color.FromArgb(160, 160, 166);
            capToday.Location = new Point(28, 16);
            capToday.Name = "capToday";
            capToday.Size = new Size(60, 17);
            capToday.TabIndex = 1;
            capToday.Text = "Hôm nay";
            // 
            // lblToday
            // 
            lblToday.AutoSize = true;
            lblToday.BackColor = Color.Transparent;
            lblToday.Font = new Font("Segoe UI", 19F, FontStyle.Bold);
            lblToday.ForeColor = Color.FromArgb(240, 240, 245);
            lblToday.Location = new Point(26, 38);
            lblToday.Name = "lblToday";
            lblToday.Size = new Size(83, 36);
            lblToday.TabIndex = 2;
            lblToday.Text = "0 bàn";
            // 
            // cardPending
            // 
            cardPending.BackColor = Color.Transparent;
            cardPending.BorderRadius = 14;
            cardPending.Controls.Add(barPending);
            cardPending.Controls.Add(capPending);
            cardPending.Controls.Add(lblPending);
            cardPending.CustomizableEdges = customizableEdges7;
            cardPending.FillColor = Color.FromArgb(31, 31, 34);
            cardPending.Dock = DockStyle.Fill;
            cardPending.Margin = new Padding(0, 0, 12, 0);
            cardPending.Name = "cardPending";
            cardPending.ShadowDecoration.CustomizableEdges = customizableEdges8;
            cardPending.TabIndex = 3;
            // 
            // barPending
            // 
            barPending.BorderRadius = 4;
            barPending.CustomizableEdges = customizableEdges5;
            barPending.FillColor = Color.FromArgb(245, 158, 11);
            barPending.Location = new Point(14, 16);
            barPending.Name = "barPending";
            barPending.ShadowDecoration.CustomizableEdges = customizableEdges6;
            barPending.Size = new Size(4, 64);
            barPending.TabIndex = 0;
            // 
            // capPending
            // 
            capPending.AutoSize = true;
            capPending.BackColor = Color.Transparent;
            capPending.Font = new Font("Segoe UI", 9.5F);
            capPending.ForeColor = Color.FromArgb(160, 160, 166);
            capPending.Location = new Point(28, 16);
            capPending.Name = "capPending";
            capPending.Size = new Size(86, 17);
            capPending.TabIndex = 1;
            capPending.Text = "Chờ xác nhận";
            // 
            // lblPending
            // 
            lblPending.AutoSize = true;
            lblPending.BackColor = Color.Transparent;
            lblPending.Font = new Font("Segoe UI", 19F, FontStyle.Bold);
            lblPending.ForeColor = Color.FromArgb(240, 240, 245);
            lblPending.Location = new Point(26, 38);
            lblPending.Name = "lblPending";
            lblPending.Size = new Size(83, 36);
            lblPending.TabIndex = 2;
            lblPending.Text = "0 bàn";
            // 
            // cardDone
            // 
            cardDone.BackColor = Color.Transparent;
            cardDone.BorderRadius = 14;
            cardDone.Controls.Add(barDone);
            cardDone.Controls.Add(capDone);
            cardDone.Controls.Add(lblDone);
            cardDone.CustomizableEdges = customizableEdges11;
            cardDone.FillColor = Color.FromArgb(31, 31, 34);
            cardDone.Dock = DockStyle.Fill;
            cardDone.Margin = new Padding(0, 0, 0, 0);
            cardDone.Name = "cardDone";
            cardDone.ShadowDecoration.CustomizableEdges = customizableEdges12;
            cardDone.TabIndex = 4;
            // 
            // barDone
            // 
            barDone.BorderRadius = 4;
            barDone.CustomizableEdges = customizableEdges9;
            barDone.FillColor = Color.FromArgb(34, 197, 94);
            barDone.Location = new Point(14, 16);
            barDone.Name = "barDone";
            barDone.ShadowDecoration.CustomizableEdges = customizableEdges10;
            barDone.Size = new Size(4, 64);
            barDone.TabIndex = 0;
            // 
            // capDone
            // 
            capDone.AutoSize = true;
            capDone.BackColor = Color.Transparent;
            capDone.Font = new Font("Segoe UI", 9.5F);
            capDone.ForeColor = Color.FromArgb(160, 160, 166);
            capDone.Location = new Point(28, 16);
            capDone.Name = "capDone";
            capDone.Size = new Size(93, 17);
            capDone.TabIndex = 1;
            capDone.Text = "Đã hoàn thành";
            // 
            // lblDone
            // 
            lblDone.AutoSize = true;
            lblDone.BackColor = Color.Transparent;
            lblDone.Font = new Font("Segoe UI", 19F, FontStyle.Bold);
            lblDone.ForeColor = Color.FromArgb(240, 240, 245);
            lblDone.Location = new Point(26, 38);
            lblDone.Name = "lblDone";
            lblDone.Size = new Size(83, 36);
            lblDone.TabIndex = 2;
            lblDone.Text = "0 bàn";
            // 
            // pnlBar
            // 
            pnlBar.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlBar.BackColor = Color.Transparent;
            pnlBar.BorderRadius = 14;
            pnlBar.Controls.Add(txtSearch);
            pnlBar.Controls.Add(cmbStatus);
            pnlBar.Controls.Add(lblCount);
            pnlBar.Controls.Add(btnAdd);
            pnlBar.Controls.Add(btnSendReminder);
            pnlBar.Controls.Add(btnEditRes);
            pnlBar.CustomizableEdges = customizableEdges21;
            pnlBar.FillColor = Color.FromArgb(31, 31, 34);
            pnlBar.Location = new Point(16, 182);
            pnlBar.Name = "pnlBar";
            pnlBar.ShadowDecoration.CustomizableEdges = customizableEdges22;
            pnlBar.Size = new Size(968, 56);
            pnlBar.TabIndex = 5;
            // 
            // txtSearch
            // 
            txtSearch.BorderColor = Color.FromArgb(63, 63, 70);
            txtSearch.BorderRadius = 8;
            txtSearch.CustomizableEdges = customizableEdges13;
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
            txtSearch.ShadowDecoration.CustomizableEdges = customizableEdges14;
            txtSearch.Size = new Size(220, 36);
            txtSearch.TabIndex = 0;
            // 
            // cmbStatus
            // 
            cmbStatus.BackColor = Color.Transparent;
            cmbStatus.BorderColor = Color.FromArgb(63, 63, 70);
            cmbStatus.BorderRadius = 8;
            cmbStatus.CustomizableEdges = customizableEdges15;
            cmbStatus.DrawMode = DrawMode.OwnerDrawFixed;
            cmbStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbStatus.FillColor = Color.FromArgb(24, 24, 27);
            cmbStatus.FocusedColor = Color.Empty;
            cmbStatus.Font = new Font("Segoe UI", 9.5F);
            cmbStatus.ForeColor = Color.FromArgb(220, 220, 225);
            cmbStatus.ItemHeight = 30;
            cmbStatus.Items.AddRange(new object[] { "-- Trạng thái --", "Chờ xác nhận", "Đã xác nhận", "Đã đến", "Hủy" });
            cmbStatus.Location = new Point(244, 10);
            cmbStatus.Name = "cmbStatus";
            cmbStatus.ShadowDecoration.CustomizableEdges = customizableEdges16;
            cmbStatus.Size = new Size(160, 36);
            cmbStatus.TabIndex = 1;
            // 
            // lblCount
            // 
            lblCount.AutoSize = true;
            lblCount.BackColor = Color.Transparent;
            lblCount.Font = new Font("Segoe UI", 9F);
            lblCount.ForeColor = Color.FromArgb(160, 160, 166);
            lblCount.Location = new Point(420, 20);
            lblCount.Name = "lblCount";
            lblCount.Size = new Size(57, 15);
            lblCount.TabIndex = 2;
            lblCount.Text = "0 lượt đặt";
            // 
            // btnAdd
            // 
            btnAdd.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAdd.BorderRadius = 10;
            btnAdd.Cursor = Cursors.Hand;
            btnAdd.CustomizableEdges = customizableEdges17;
            btnAdd.FillColor = Color.FromArgb(31, 138, 154);
            btnAdd.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnAdd.ForeColor = Color.White;
            btnAdd.HoverState.FillColor = Color.FromArgb(47, 154, 170);
            btnAdd.Location = new Point(654, 10);
            btnAdd.Name = "btnAdd";
            btnAdd.ShadowDecoration.CustomizableEdges = customizableEdges18;
            btnAdd.Size = new Size(148, 36);
            btnAdd.TabIndex = 2;
            btnAdd.Text = "+ Đặt bàn mới";
            btnAdd.Click += BtnAdd_Click;
            // 
            // btnSendReminder
            // 
            btnSendReminder.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSendReminder.BorderColor = Color.FromArgb(63, 63, 70);
            btnSendReminder.BorderRadius = 10;
            btnSendReminder.BorderThickness = 1;
            btnSendReminder.Cursor = Cursors.Hand;
            btnSendReminder.CustomizableEdges = customizableEdges19;
            btnSendReminder.FillColor = Color.Transparent;
            btnSendReminder.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnSendReminder.ForeColor = Color.FromArgb(220, 220, 225);
            btnSendReminder.HoverState.BorderColor = Color.FromArgb(103, 103, 110);
            btnSendReminder.HoverState.FillColor = Color.FromArgb(45, 45, 50);
            btnSendReminder.Location = new Point(808, 10);
            btnSendReminder.Name = "btnSendReminder";
            btnSendReminder.ShadowDecoration.CustomizableEdges = customizableEdges20;
            btnSendReminder.Size = new Size(148, 36);
            btnSendReminder.TabIndex = 3;
            btnSendReminder.Text = "Nhắc hôm nay";
            //
            // btnEditRes
            //
            btnEditRes.BorderColor = Color.FromArgb(80, 80, 90);
            btnEditRes.BorderRadius = 10;
            btnEditRes.BorderThickness = 1;
            btnEditRes.Cursor = Cursors.Hand;
            btnEditRes.FillColor = Color.Transparent;
            btnEditRes.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnEditRes.ForeColor = Color.FromArgb(220, 220, 225);
            btnEditRes.HoverState.FillColor = Color.FromArgb(45, 45, 50);
            btnEditRes.Location = new Point(500, 10);
            btnEditRes.Name = "btnEditRes";
            btnEditRes.Size = new Size(145, 36);
            btnEditRes.Text = "Sửa dòng chọn";
            btnEditRes.Click += BtnEditRes_Click;
            //
            // pnlGridCard
            // 
            pnlGridCard.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnlGridCard.BackColor = Color.Transparent;
            pnlGridCard.BorderRadius = 14;
            pnlGridCard.Controls.Add(dgv);
            pnlGridCard.CustomizableEdges = customizableEdges23;
            pnlGridCard.FillColor = Color.FromArgb(24, 24, 27);
            pnlGridCard.Location = new Point(16, 252);
            pnlGridCard.Name = "pnlGridCard";
            pnlGridCard.ShadowDecoration.CustomizableEdges = customizableEdges24;
            pnlGridCard.Size = new Size(968, 393);
            pnlGridCard.TabIndex = 6;
            // 
            // dgv
            // 
            dataGridViewCellStyle1.BackColor = Color.White;
            dgv.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(100, 88, 255);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgv.DefaultCellStyle = dataGridViewCellStyle3;
            dgv.Dock = DockStyle.Fill;
            dgv.GridColor = Color.FromArgb(231, 229, 255);
            dgv.Location = new Point(0, 0);
            dgv.Name = "dgv";
            dgv.RowHeadersVisible = false;
            dgv.Size = new Size(968, 393);
            dgv.TabIndex = 0;
            dgv.ThemeStyle.AlternatingRowsStyle.BackColor = Color.White;
            dgv.ThemeStyle.AlternatingRowsStyle.Font = null;
            dgv.ThemeStyle.AlternatingRowsStyle.ForeColor = Color.Empty;
            dgv.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.Empty;
            dgv.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.Empty;
            dgv.ThemeStyle.BackColor = Color.White;
            dgv.ThemeStyle.GridColor = Color.FromArgb(231, 229, 255);
            dgv.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(100, 88, 255);
            dgv.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.None;
            dgv.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI", 9F);
            dgv.ThemeStyle.HeaderStyle.ForeColor = Color.White;
            dgv.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgv.ThemeStyle.HeaderStyle.Height = 23;
            dgv.ThemeStyle.ReadOnly = false;
            dgv.ThemeStyle.RowsStyle.BackColor = Color.White;
            dgv.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgv.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 9F);
            dgv.ThemeStyle.RowsStyle.ForeColor = Color.FromArgb(71, 69, 94);
            dgv.ThemeStyle.RowsStyle.Height = 25;
            dgv.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dgv.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dgv.CellDoubleClick += DgvRes_CellDoubleClick;
            // 
            // colCode
            // 
            colCode.DataPropertyName = "Mã đặt";
            colCode.HeaderText = "Mã đặt";
            colCode.Name = "Mã đặt";
            // 
            // colName
            // 
            colName.DataPropertyName = "Họ tên";
            colName.HeaderText = "Họ tên";
            colName.Name = "Họ tên";
            // 
            // colPhone
            // 
            colPhone.DataPropertyName = "SĐT";
            colPhone.HeaderText = "SĐT";
            colPhone.Name = "SĐT";
            // 
            // colDateTime
            // 
            colDateTime.DataPropertyName = "Ngày & Giờ";
            colDateTime.HeaderText = "Ngày & Giờ";
            colDateTime.Name = "Ngày & Giờ";
            // 
            // colTable
            // 
            colTable.DataPropertyName = "Bàn";
            colTable.HeaderText = "Bàn";
            colTable.Name = "Bàn";
            // 
            // colGuests
            // 
            colGuests.DataPropertyName = "Số khách";
            colGuests.HeaderText = "Số khách";
            colGuests.Name = "Số khách";
            // 
            // colNote
            // 
            colNote.DataPropertyName = "Ghi chú";
            colNote.HeaderText = "Ghi chú";
            colNote.Name = "Ghi chú";
            // 
            // colStatus
            // 
            colStatus.DataPropertyName = "Trạng thái";
            colStatus.HeaderText = "Trạng thái";
            colStatus.Name = "Trạng thái";
            // 
            // ucReservation_Order
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(39, 39, 42);
            Controls.Add(lblTitle);
            Controls.Add(lblSub);
            Controls.Add(tblCards);
            Controls.Add(pnlBar);
            Controls.Add(pnlGridCard);
            Name = "ucReservation_Order";
            Size = new Size(1000, 665);
            cardToday.ResumeLayout(false);
            cardToday.PerformLayout();
            cardPending.ResumeLayout(false);
            cardPending.PerformLayout();
            cardDone.ResumeLayout(false);
            cardDone.PerformLayout();
            tblCards.ResumeLayout(false);
            pnlBar.ResumeLayout(false);
            pnlBar.PerformLayout();
            pnlGridCard.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgv).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private Label lblSub;
        private TableLayoutPanel tblCards;
        private Guna2Panel cardToday;
        private Guna2Panel barToday;
        private Label capToday;
        private Label lblToday;
        private Guna2Panel cardPending;
        private Guna2Panel barPending;
        private Label capPending;
        private Label lblPending;
        private Guna2Panel cardDone;
        private Guna2Panel barDone;
        private Label capDone;
        private Label lblDone;
        private Guna2Panel pnlBar;
        private Guna2TextBox txtSearch;
        private Guna2ComboBox cmbStatus;
        private Label lblCount;
        private Guna2Button btnAdd;
        private Guna2Button btnSendReminder;
        private Guna2Button btnEditRes;
        private Guna2Panel pnlGridCard;
        private Guna2DataGridView dgv;
        private DataGridViewTextBoxColumn colCode;
        private DataGridViewTextBoxColumn colName;
        private DataGridViewTextBoxColumn colPhone;
        private DataGridViewTextBoxColumn colDateTime;
        private DataGridViewTextBoxColumn colTable;
        private DataGridViewTextBoxColumn colGuests;
        private DataGridViewTextBoxColumn colNote;
        private DataGridViewTextBoxColumn colStatus;
    }
}
