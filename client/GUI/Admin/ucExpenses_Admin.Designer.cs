using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace GUI
{
    partial class ucExpenses_Admin
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges15 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges16 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges13 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges14 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges25 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges26 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges17 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges18 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges19 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges20 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges21 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges22 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges23 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges24 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges27 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges28 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            lblTitle = new Label();
            lblSub = new Label();
            tblCards = new TableLayoutPanel();
            pnlCardTotal = new Guna2Panel();
            pnlBarTotal = new Guna2Panel();
            lblCapTotal = new Label();
            _lblTotal = new Label();
            pnlCardPersonnel = new Guna2Panel();
            pnlBarPersonnel = new Guna2Panel();
            lblCapPersonnel = new Label();
            _lblPersonnel = new Label();
            pnlCardIngredient = new Guna2Panel();
            pnlBarIngredient = new Guna2Panel();
            lblCapIngredient = new Label();
            _lblIngredient = new Label();
            pnlCardOther = new Guna2Panel();
            pnlBarOther = new Guna2Panel();
            lblCapOther = new Label();
            _lblOther = new Label();
            pnlBar = new Guna2Panel();
            lblMonth = new Label();
            _cmbMonth = new Guna2ComboBox();
            btnAdd = new Guna2Button();
            btnExport = new Guna2Button();
            btnEditExpense = new Guna2Button();
            pnlGrid = new Guna2Panel();
            _dgv = new Guna2DataGridView();
            colDate = new DataGridViewTextBoxColumn();
            colCategory = new DataGridViewTextBoxColumn();
            colDesc = new DataGridViewTextBoxColumn();
            colAmount = new DataGridViewTextBoxColumn();
            colPayer = new DataGridViewTextBoxColumn();
            colVoucher = new DataGridViewTextBoxColumn();
            colNote = new DataGridViewTextBoxColumn();
            tblCards.SuspendLayout();
            pnlCardTotal.SuspendLayout();
            pnlCardPersonnel.SuspendLayout();
            pnlCardIngredient.SuspendLayout();
            pnlCardOther.SuspendLayout();
            pnlBar.SuspendLayout();
            pnlGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_dgv).BeginInit();
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
            lblTitle.Size = new Size(176, 25);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Tiền chi chi tiết";
            // 
            // lblSub
            // 
            lblSub.AutoSize = true;
            lblSub.BackColor = Color.Transparent;
            lblSub.Font = new Font("Segoe UI", 9F);
            lblSub.ForeColor = Color.FromArgb(160, 160, 166);
            lblSub.Location = new Point(22, 46);
            lblSub.Name = "lblSub";
            lblSub.Size = new Size(279, 15);
            lblSub.TabIndex = 1;
            lblSub.Text = "Theo dõi toàn bộ khoản chi ra của quán theo tháng";
            // 
            // tblCards
            // 
            tblCards.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tblCards.ColumnCount = 4;
            tblCards.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tblCards.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tblCards.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tblCards.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tblCards.Controls.Add(pnlCardTotal, 0, 0);
            tblCards.Controls.Add(pnlCardPersonnel, 1, 0);
            tblCards.Controls.Add(pnlCardIngredient, 2, 0);
            tblCards.Controls.Add(pnlCardOther, 3, 0);
            tblCards.Location = new Point(16, 70);
            tblCards.Name = "tblCards";
            tblCards.RowCount = 1;
            tblCards.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tblCards.Size = new Size(968, 96);
            tblCards.TabIndex = 2;
            // 
            // pnlCardTotal
            // 
            pnlCardTotal.BackColor = Color.Transparent;
            pnlCardTotal.BorderRadius = 14;
            pnlCardTotal.Controls.Add(pnlBarTotal);
            pnlCardTotal.Controls.Add(lblCapTotal);
            pnlCardTotal.Controls.Add(_lblTotal);
            pnlCardTotal.CustomizableEdges = customizableEdges3;
            pnlCardTotal.Dock = DockStyle.Fill;
            pnlCardTotal.FillColor = Color.FromArgb(31, 31, 34);
            pnlCardTotal.Location = new Point(0, 0);
            pnlCardTotal.Margin = new Padding(0, 0, 12, 0);
            pnlCardTotal.Name = "pnlCardTotal";
            pnlCardTotal.ShadowDecoration.CustomizableEdges = customizableEdges4;
            pnlCardTotal.Size = new Size(230, 96);
            pnlCardTotal.TabIndex = 2;
            // 
            // pnlBarTotal
            // 
            pnlBarTotal.BorderRadius = 4;
            pnlBarTotal.CustomizableEdges = customizableEdges1;
            pnlBarTotal.FillColor = Color.FromArgb(220, 80, 80);
            pnlBarTotal.Location = new Point(14, 16);
            pnlBarTotal.Name = "pnlBarTotal";
            pnlBarTotal.ShadowDecoration.CustomizableEdges = customizableEdges2;
            pnlBarTotal.Size = new Size(4, 64);
            pnlBarTotal.TabIndex = 0;
            // 
            // lblCapTotal
            // 
            lblCapTotal.AutoSize = true;
            lblCapTotal.BackColor = Color.Transparent;
            lblCapTotal.Font = new Font("Segoe UI", 9.5F);
            lblCapTotal.ForeColor = Color.FromArgb(160, 160, 166);
            lblCapTotal.Location = new Point(28, 16);
            lblCapTotal.Name = "lblCapTotal";
            lblCapTotal.Size = new Size(119, 17);
            lblCapTotal.TabIndex = 1;
            lblCapTotal.Text = "Tổng chi tháng này";
            // 
            // _lblTotal
            // 
            _lblTotal.AutoSize = true;
            _lblTotal.BackColor = Color.Transparent;
            _lblTotal.Font = new Font("Segoe UI", 19F, FontStyle.Bold);
            _lblTotal.ForeColor = Color.FromArgb(240, 240, 245);
            _lblTotal.Location = new Point(26, 38);
            _lblTotal.Name = "_lblTotal";
            _lblTotal.Size = new Size(53, 36);
            _lblTotal.TabIndex = 2;
            _lblTotal.Text = "0 đ";
            // 
            // pnlCardPersonnel
            // 
            pnlCardPersonnel.BackColor = Color.Transparent;
            pnlCardPersonnel.BorderRadius = 14;
            pnlCardPersonnel.Controls.Add(pnlBarPersonnel);
            pnlCardPersonnel.Controls.Add(lblCapPersonnel);
            pnlCardPersonnel.Controls.Add(_lblPersonnel);
            pnlCardPersonnel.CustomizableEdges = customizableEdges7;
            pnlCardPersonnel.Dock = DockStyle.Fill;
            pnlCardPersonnel.FillColor = Color.FromArgb(31, 31, 34);
            pnlCardPersonnel.Location = new Point(242, 0);
            pnlCardPersonnel.Margin = new Padding(0, 0, 12, 0);
            pnlCardPersonnel.Name = "pnlCardPersonnel";
            pnlCardPersonnel.ShadowDecoration.CustomizableEdges = customizableEdges8;
            pnlCardPersonnel.Size = new Size(230, 96);
            pnlCardPersonnel.TabIndex = 3;
            // 
            // pnlBarPersonnel
            // 
            pnlBarPersonnel.BorderRadius = 4;
            pnlBarPersonnel.CustomizableEdges = customizableEdges5;
            pnlBarPersonnel.FillColor = Color.FromArgb(245, 158, 11);
            pnlBarPersonnel.Location = new Point(14, 16);
            pnlBarPersonnel.Name = "pnlBarPersonnel";
            pnlBarPersonnel.ShadowDecoration.CustomizableEdges = customizableEdges6;
            pnlBarPersonnel.Size = new Size(4, 64);
            pnlBarPersonnel.TabIndex = 0;
            // 
            // lblCapPersonnel
            // 
            lblCapPersonnel.AutoSize = true;
            lblCapPersonnel.BackColor = Color.Transparent;
            lblCapPersonnel.Font = new Font("Segoe UI", 9.5F);
            lblCapPersonnel.ForeColor = Color.FromArgb(160, 160, 166);
            lblCapPersonnel.Location = new Point(28, 16);
            lblCapPersonnel.Name = "lblCapPersonnel";
            lblCapPersonnel.Size = new Size(76, 17);
            lblCapPersonnel.TabIndex = 1;
            lblCapPersonnel.Text = "Chi nhân sự";
            // 
            // _lblPersonnel
            // 
            _lblPersonnel.AutoSize = true;
            _lblPersonnel.BackColor = Color.Transparent;
            _lblPersonnel.Font = new Font("Segoe UI", 19F, FontStyle.Bold);
            _lblPersonnel.ForeColor = Color.FromArgb(240, 240, 245);
            _lblPersonnel.Location = new Point(26, 38);
            _lblPersonnel.Name = "_lblPersonnel";
            _lblPersonnel.Size = new Size(53, 36);
            _lblPersonnel.TabIndex = 2;
            _lblPersonnel.Text = "0 đ";
            // 
            // pnlCardIngredient
            // 
            pnlCardIngredient.BackColor = Color.Transparent;
            pnlCardIngredient.BorderRadius = 14;
            pnlCardIngredient.Controls.Add(pnlBarIngredient);
            pnlCardIngredient.Controls.Add(lblCapIngredient);
            pnlCardIngredient.Controls.Add(_lblIngredient);
            pnlCardIngredient.CustomizableEdges = customizableEdges11;
            pnlCardIngredient.Dock = DockStyle.Fill;
            pnlCardIngredient.FillColor = Color.FromArgb(31, 31, 34);
            pnlCardIngredient.Location = new Point(484, 0);
            pnlCardIngredient.Margin = new Padding(0, 0, 12, 0);
            pnlCardIngredient.Name = "pnlCardIngredient";
            pnlCardIngredient.ShadowDecoration.CustomizableEdges = customizableEdges12;
            pnlCardIngredient.Size = new Size(230, 96);
            pnlCardIngredient.TabIndex = 4;
            // 
            // pnlBarIngredient
            // 
            pnlBarIngredient.BorderRadius = 4;
            pnlBarIngredient.CustomizableEdges = customizableEdges9;
            pnlBarIngredient.FillColor = Color.FromArgb(31, 138, 154);
            pnlBarIngredient.Location = new Point(14, 16);
            pnlBarIngredient.Name = "pnlBarIngredient";
            pnlBarIngredient.ShadowDecoration.CustomizableEdges = customizableEdges10;
            pnlBarIngredient.Size = new Size(4, 64);
            pnlBarIngredient.TabIndex = 0;
            // 
            // lblCapIngredient
            // 
            lblCapIngredient.AutoSize = true;
            lblCapIngredient.BackColor = Color.Transparent;
            lblCapIngredient.Font = new Font("Segoe UI", 9.5F);
            lblCapIngredient.ForeColor = Color.FromArgb(160, 160, 166);
            lblCapIngredient.Location = new Point(28, 16);
            lblCapIngredient.Name = "lblCapIngredient";
            lblCapIngredient.Size = new Size(96, 17);
            lblCapIngredient.TabIndex = 1;
            lblCapIngredient.Text = "Chi nguyên liệu";
            // 
            // _lblIngredient
            // 
            _lblIngredient.AutoSize = true;
            _lblIngredient.BackColor = Color.Transparent;
            _lblIngredient.Font = new Font("Segoe UI", 19F, FontStyle.Bold);
            _lblIngredient.ForeColor = Color.FromArgb(240, 240, 245);
            _lblIngredient.Location = new Point(26, 38);
            _lblIngredient.Name = "_lblIngredient";
            _lblIngredient.Size = new Size(53, 36);
            _lblIngredient.TabIndex = 2;
            _lblIngredient.Text = "0 đ";
            // 
            // pnlCardOther
            // 
            pnlCardOther.BackColor = Color.Transparent;
            pnlCardOther.BorderRadius = 14;
            pnlCardOther.Controls.Add(pnlBarOther);
            pnlCardOther.Controls.Add(lblCapOther);
            pnlCardOther.Controls.Add(_lblOther);
            pnlCardOther.CustomizableEdges = customizableEdges15;
            pnlCardOther.Dock = DockStyle.Fill;
            pnlCardOther.FillColor = Color.FromArgb(31, 31, 34);
            pnlCardOther.Location = new Point(726, 0);
            pnlCardOther.Margin = new Padding(0);
            pnlCardOther.Name = "pnlCardOther";
            pnlCardOther.ShadowDecoration.CustomizableEdges = customizableEdges16;
            pnlCardOther.Size = new Size(242, 96);
            pnlCardOther.TabIndex = 5;
            // 
            // pnlBarOther
            // 
            pnlBarOther.BorderRadius = 4;
            pnlBarOther.CustomizableEdges = customizableEdges13;
            pnlBarOther.FillColor = Color.FromArgb(139, 110, 220);
            pnlBarOther.Location = new Point(14, 16);
            pnlBarOther.Name = "pnlBarOther";
            pnlBarOther.ShadowDecoration.CustomizableEdges = customizableEdges14;
            pnlBarOther.Size = new Size(4, 64);
            pnlBarOther.TabIndex = 0;
            // 
            // lblCapOther
            // 
            lblCapOther.AutoSize = true;
            lblCapOther.BackColor = Color.Transparent;
            lblCapOther.Font = new Font("Segoe UI", 9.5F);
            lblCapOther.ForeColor = Color.FromArgb(160, 160, 166);
            lblCapOther.Location = new Point(28, 16);
            lblCapOther.Name = "lblCapOther";
            lblCapOther.Size = new Size(56, 17);
            lblCapOther.TabIndex = 1;
            lblCapOther.Text = "Chi khác";
            // 
            // _lblOther
            // 
            _lblOther.AutoSize = true;
            _lblOther.BackColor = Color.Transparent;
            _lblOther.Font = new Font("Segoe UI", 19F, FontStyle.Bold);
            _lblOther.ForeColor = Color.FromArgb(240, 240, 245);
            _lblOther.Location = new Point(26, 38);
            _lblOther.Name = "_lblOther";
            _lblOther.Size = new Size(53, 36);
            _lblOther.TabIndex = 2;
            _lblOther.Text = "0 đ";
            // 
            // pnlBar
            // 
            pnlBar.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlBar.BackColor = Color.Transparent;
            pnlBar.BorderRadius = 14;
            pnlBar.Controls.Add(lblMonth);
            pnlBar.Controls.Add(_cmbMonth);
            pnlBar.Controls.Add(btnAdd);
            pnlBar.Controls.Add(btnExport);
            pnlBar.Controls.Add(btnEditExpense);
            pnlBar.CustomizableEdges = customizableEdges25;
            pnlBar.FillColor = Color.FromArgb(31, 31, 34);
            pnlBar.Location = new Point(16, 182);
            pnlBar.Name = "pnlBar";
            pnlBar.ShadowDecoration.CustomizableEdges = customizableEdges26;
            pnlBar.Size = new Size(968, 56);
            pnlBar.TabIndex = 6;
            // 
            // lblMonth
            // 
            lblMonth.AutoSize = true;
            lblMonth.BackColor = Color.Transparent;
            lblMonth.Font = new Font("Segoe UI", 9.5F);
            lblMonth.ForeColor = Color.FromArgb(160, 160, 166);
            lblMonth.Location = new Point(12, 18);
            lblMonth.Name = "lblMonth";
            lblMonth.Size = new Size(47, 17);
            lblMonth.TabIndex = 0;
            lblMonth.Text = "Tháng:";
            // 
            // _cmbMonth
            // 
            _cmbMonth.BackColor = Color.Transparent;
            _cmbMonth.BorderColor = Color.FromArgb(63, 63, 70);
            _cmbMonth.BorderRadius = 8;
            _cmbMonth.CustomizableEdges = customizableEdges17;
            _cmbMonth.DrawMode = DrawMode.OwnerDrawFixed;
            _cmbMonth.DropDownStyle = ComboBoxStyle.DropDownList;
            _cmbMonth.FillColor = Color.FromArgb(24, 24, 27);
            _cmbMonth.FocusedColor = Color.Empty;
            _cmbMonth.Font = new Font("Segoe UI", 9.5F);
            _cmbMonth.ForeColor = Color.FromArgb(220, 220, 225);
            _cmbMonth.ItemHeight = 30;
            _cmbMonth.Location = new Point(62, 10);
            _cmbMonth.Name = "_cmbMonth";
            _cmbMonth.ShadowDecoration.CustomizableEdges = customizableEdges18;
            _cmbMonth.Size = new Size(140, 36);
            _cmbMonth.TabIndex = 1;
            // 
            // btnAdd
            // 
            btnAdd.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAdd.BorderRadius = 10;
            btnAdd.Cursor = Cursors.Hand;
            btnAdd.CustomizableEdges = customizableEdges19;
            btnAdd.FillColor = Color.FromArgb(31, 138, 154);
            btnAdd.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnAdd.ForeColor = Color.White;
            btnAdd.HoverState.FillColor = Color.FromArgb(47, 154, 170);
            btnAdd.Location = new Point(656, 10);
            btnAdd.Name = "btnAdd";
            btnAdd.ShadowDecoration.CustomizableEdges = customizableEdges20;
            btnAdd.Size = new Size(160, 36);
            btnAdd.TabIndex = 2;
            btnAdd.Text = "+ Thêm khoản chi";
            btnAdd.Click += BtnAdd_Click;
            // 
            // btnExport
            // 
            btnExport.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnExport.BorderColor = Color.FromArgb(63, 63, 70);
            btnExport.BorderRadius = 10;
            btnExport.BorderThickness = 1;
            btnExport.Cursor = Cursors.Hand;
            btnExport.CustomizableEdges = customizableEdges21;
            btnExport.FillColor = Color.Transparent;
            btnExport.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnExport.ForeColor = Color.FromArgb(220, 220, 225);
            btnExport.HoverState.BorderColor = Color.FromArgb(103, 103, 110);
            btnExport.HoverState.FillColor = Color.FromArgb(45, 45, 50);
            btnExport.Location = new Point(824, 10);
            btnExport.Name = "btnExport";
            btnExport.ShadowDecoration.CustomizableEdges = customizableEdges22;
            btnExport.Size = new Size(132, 36);
            btnExport.TabIndex = 3;
            btnExport.Text = "Xuất Excel";
            // 
            // btnEditExpense
            // 
            btnEditExpense.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnEditExpense.BorderColor = Color.FromArgb(63, 63, 70);
            btnEditExpense.BorderRadius = 10;
            btnEditExpense.BorderThickness = 1;
            btnEditExpense.Cursor = Cursors.Hand;
            btnEditExpense.CustomizableEdges = customizableEdges23;
            btnEditExpense.FillColor = Color.Transparent;
            btnEditExpense.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnEditExpense.ForeColor = Color.FromArgb(220, 220, 225);
            btnEditExpense.HoverState.FillColor = Color.FromArgb(45, 45, 50);
            btnEditExpense.Location = new Point(490, 10);
            btnEditExpense.Name = "btnEditExpense";
            btnEditExpense.ShadowDecoration.CustomizableEdges = customizableEdges24;
            btnEditExpense.Size = new Size(158, 36);
            btnEditExpense.TabIndex = 4;
            btnEditExpense.Text = "Sửa khoản chọn";
            btnEditExpense.Click += BtnEditExpense_Click;
            // 
            // pnlGrid
            // 
            pnlGrid.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnlGrid.BackColor = Color.Transparent;
            pnlGrid.BorderRadius = 14;
            pnlGrid.Controls.Add(_dgv);
            pnlGrid.CustomizableEdges = customizableEdges27;
            pnlGrid.FillColor = Color.FromArgb(24, 24, 27);
            pnlGrid.Location = new Point(16, 252);
            pnlGrid.Name = "pnlGrid";
            pnlGrid.ShadowDecoration.CustomizableEdges = customizableEdges28;
            pnlGrid.Size = new Size(968, 393);
            pnlGrid.TabIndex = 7;
            // 
            // _dgv
            // 
            dataGridViewCellStyle1.BackColor = Color.White;
            _dgv.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(100, 88, 255);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            _dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            _dgv.ColumnHeadersHeight = 17;
            _dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            _dgv.Columns.AddRange(new DataGridViewColumn[] { colDate, colCategory, colDesc, colAmount, colPayer, colVoucher, colNote });
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            _dgv.DefaultCellStyle = dataGridViewCellStyle3;
            _dgv.Dock = DockStyle.Fill;
            _dgv.GridColor = Color.FromArgb(231, 229, 255);
            _dgv.Location = new Point(0, 0);
            _dgv.Name = "_dgv";
            _dgv.RowHeadersVisible = false;
            _dgv.RowHeadersWidth = 51;
            _dgv.Size = new Size(968, 393);
            _dgv.TabIndex = 0;
            _dgv.ThemeStyle.AlternatingRowsStyle.BackColor = Color.White;
            _dgv.ThemeStyle.AlternatingRowsStyle.Font = null;
            _dgv.ThemeStyle.AlternatingRowsStyle.ForeColor = Color.Empty;
            _dgv.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.Empty;
            _dgv.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.Empty;
            _dgv.ThemeStyle.BackColor = Color.White;
            _dgv.ThemeStyle.GridColor = Color.FromArgb(231, 229, 255);
            _dgv.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(100, 88, 255);
            _dgv.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.None;
            _dgv.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI", 9F);
            _dgv.ThemeStyle.HeaderStyle.ForeColor = Color.White;
            _dgv.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            _dgv.ThemeStyle.HeaderStyle.Height = 17;
            _dgv.ThemeStyle.ReadOnly = false;
            _dgv.ThemeStyle.RowsStyle.BackColor = Color.White;
            _dgv.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            _dgv.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 9F);
            _dgv.ThemeStyle.RowsStyle.ForeColor = Color.FromArgb(71, 69, 94);
            _dgv.ThemeStyle.RowsStyle.Height = 25;
            _dgv.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(231, 229, 255);
            _dgv.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(71, 69, 94);
            // 
            // colDate
            // 
            colDate.DataPropertyName = "Ngày";
            colDate.HeaderText = "Ngày";
            colDate.Name = "colDate";
            // 
            // colCategory
            // 
            colCategory.DataPropertyName = "Danh mục";
            colCategory.HeaderText = "Danh mục";
            colCategory.Name = "colCategory";
            // 
            // colDesc
            // 
            colDesc.DataPropertyName = "Mô tả";
            colDesc.HeaderText = "Mô tả";
            colDesc.Name = "colDesc";
            // 
            // colAmount
            // 
            colAmount.DataPropertyName = "Số tiền";
            colAmount.HeaderText = "Số tiền";
            colAmount.Name = "colAmount";
            // 
            // colPayer
            // 
            colPayer.DataPropertyName = "Người chi";
            colPayer.HeaderText = "Người chi";
            colPayer.Name = "colPayer";
            // 
            // colVoucher
            // 
            colVoucher.DataPropertyName = "Chứng từ";
            colVoucher.HeaderText = "Chứng từ";
            colVoucher.Name = "colVoucher";
            // 
            // colNote
            // 
            colNote.DataPropertyName = "Ghi chú";
            colNote.HeaderText = "Ghi chú";
            colNote.Name = "colNote";
            // 
            // ucExpenses_Admin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(39, 39, 42);
            Controls.Add(lblTitle);
            Controls.Add(lblSub);
            Controls.Add(tblCards);
            Controls.Add(pnlBar);
            Controls.Add(pnlGrid);
            Name = "ucExpenses_Admin";
            Size = new Size(1000, 665);
            tblCards.ResumeLayout(false);
            pnlCardTotal.ResumeLayout(false);
            pnlCardTotal.PerformLayout();
            pnlCardPersonnel.ResumeLayout(false);
            pnlCardPersonnel.PerformLayout();
            pnlCardIngredient.ResumeLayout(false);
            pnlCardIngredient.PerformLayout();
            pnlCardOther.ResumeLayout(false);
            pnlCardOther.PerformLayout();
            pnlBar.ResumeLayout(false);
            pnlBar.PerformLayout();
            pnlGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)_dgv).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private Label lblSub;
        private TableLayoutPanel tblCards;
        private Guna2Panel pnlCardTotal;
        private Guna2Panel pnlBarTotal;
        private Label lblCapTotal;
        private Label _lblTotal;
        private Guna2Panel pnlCardPersonnel;
        private Guna2Panel pnlBarPersonnel;
        private Label lblCapPersonnel;
        private Label _lblPersonnel;
        private Guna2Panel pnlCardIngredient;
        private Guna2Panel pnlBarIngredient;
        private Label lblCapIngredient;
        private Label _lblIngredient;
        private Guna2Panel pnlCardOther;
        private Guna2Panel pnlBarOther;
        private Label lblCapOther;
        private Label _lblOther;
        private Guna2Panel pnlBar;
        private Label lblMonth;
        private Guna2ComboBox _cmbMonth;
        private Guna2Button btnAdd;
        private Guna2Button btnExport;
        private Guna2Button btnEditExpense;
        private Guna2Panel pnlGrid;
        private Guna2DataGridView _dgv;
        private DataGridViewTextBoxColumn colDate;
        private DataGridViewTextBoxColumn colCategory;
        private DataGridViewTextBoxColumn colDesc;
        private DataGridViewTextBoxColumn colAmount;
        private DataGridViewTextBoxColumn colPayer;
        private DataGridViewTextBoxColumn colVoucher;
        private DataGridViewTextBoxColumn colNote;
    }
}
