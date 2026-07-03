using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace GUI
{
    partial class AddInventoryImport
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
            components = new System.ComponentModel.Container();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
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
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges17 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges18 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges13 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges14 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges15 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges16 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            pnlHeader = new Guna2Panel();
            lblTitle = new Label();
            lblSubtitle = new Label();
            pnlInfo = new Guna2Panel();
            lblInfoTitle = new Label();
            lblNgayNhap = new Label();
            dtpNgayNhap = new Guna2DateTimePicker();
            lblNhanVien = new Label();
            cboNhanVien = new Guna2ComboBox();
            lblGhiChu = new Label();
            txtGhiChu = new Guna2TextBox();
            pnlDetail = new Guna2Panel();
            lblDetailTitle = new Label();
            lblHint = new Label();
            dgvChiTietNhap = new Guna2DataGridView();
            colMaNL = new DataGridViewComboBoxColumn();
            colSoLuong = new DataGridViewTextBoxColumn();
            colGiaNhap = new DataGridViewTextBoxColumn();
            pnlFooter = new Guna2Panel();
            lblTongTien = new Label();
            btnHuy = new Guna2Button();
            btnLuu = new Guna2Button();
            shadow = new Guna2ShadowForm(components);
            pnlHeader.SuspendLayout();
            pnlInfo.SuspendLayout();
            pnlDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvChiTietNhap).BeginInit();
            pnlFooter.SuspendLayout();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.FromArgb(31, 31, 34);
            pnlHeader.BorderRadius = 14;
            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Controls.Add(lblSubtitle);
            pnlHeader.CustomizableEdges = customizableEdges1;
            pnlHeader.Location = new Point(18, 16);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.ShadowDecoration.CustomizableEdges = customizableEdges2;
            pnlHeader.Size = new Size(736, 70);
            pnlHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.BackColor = Color.Transparent;
            lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(18, 12);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(175, 25);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "PHIẾU NHẬP KHO";
            // 
            // lblSubtitle
            // 
            lblSubtitle.AutoSize = true;
            lblSubtitle.BackColor = Color.Transparent;
            lblSubtitle.Font = new Font("Segoe UI", 9F, FontStyle.Italic);
            lblSubtitle.ForeColor = Color.FromArgb(160, 160, 166);
            lblSubtitle.Location = new Point(18, 42);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.Size = new Size(255, 15);
            lblSubtitle.TabIndex = 1;
            lblSubtitle.Text = "Ghi nhận nguyên liệu nhập vào kho theo phiếu";
            // 
            // pnlInfo
            // 
            pnlInfo.BackColor = Color.FromArgb(39, 39, 42);
            pnlInfo.BorderRadius = 14;
            pnlInfo.Controls.Add(lblInfoTitle);
            pnlInfo.Controls.Add(lblNgayNhap);
            pnlInfo.Controls.Add(dtpNgayNhap);
            pnlInfo.Controls.Add(lblNhanVien);
            pnlInfo.Controls.Add(cboNhanVien);
            pnlInfo.Controls.Add(lblGhiChu);
            pnlInfo.Controls.Add(txtGhiChu);
            pnlInfo.CustomizableEdges = customizableEdges9;
            pnlInfo.Location = new Point(18, 96);
            pnlInfo.Name = "pnlInfo";
            pnlInfo.ShadowDecoration.CustomizableEdges = customizableEdges10;
            pnlInfo.Size = new Size(736, 120);
            pnlInfo.TabIndex = 1;
            // 
            // lblInfoTitle
            // 
            lblInfoTitle.AutoSize = true;
            lblInfoTitle.BackColor = Color.Transparent;
            lblInfoTitle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblInfoTitle.ForeColor = Color.FromArgb(31, 138, 154);
            lblInfoTitle.Location = new Point(18, 10);
            lblInfoTitle.Name = "lblInfoTitle";
            lblInfoTitle.Size = new Size(113, 19);
            lblInfoTitle.TabIndex = 0;
            lblInfoTitle.Text = "Thông tin phiếu";
            // 
            // lblNgayNhap
            // 
            lblNgayNhap.AutoSize = true;
            lblNgayNhap.BackColor = Color.Transparent;
            lblNgayNhap.Font = new Font("Segoe UI", 9.5F);
            lblNgayNhap.ForeColor = Color.FromArgb(200, 200, 205);
            lblNgayNhap.Location = new Point(18, 38);
            lblNgayNhap.Name = "lblNgayNhap";
            lblNgayNhap.Size = new Size(75, 17);
            lblNgayNhap.TabIndex = 1;
            lblNgayNhap.Text = "Ngày nhập:";
            // 
            // dtpNgayNhap
            // 
            dtpNgayNhap.BorderRadius = 10;
            dtpNgayNhap.Checked = true;
            dtpNgayNhap.CustomFormat = "dd/MM/yyyy   HH:mm";
            dtpNgayNhap.CustomizableEdges = customizableEdges3;
            dtpNgayNhap.FillColor = Color.FromArgb(30, 30, 33);
            dtpNgayNhap.Font = new Font("Segoe UI", 10F);
            dtpNgayNhap.Format = DateTimePickerFormat.Custom;
            dtpNgayNhap.Location = new Point(18, 60);
            dtpNgayNhap.MaxDate = new DateTime(9998, 12, 31, 0, 0, 0, 0);
            dtpNgayNhap.MinDate = new DateTime(1900, 1, 1, 0, 0, 0, 0);
            dtpNgayNhap.Name = "dtpNgayNhap";
            dtpNgayNhap.ShadowDecoration.CustomizableEdges = customizableEdges4;
            dtpNgayNhap.Size = new Size(216, 42);
            dtpNgayNhap.TabIndex = 2;
            dtpNgayNhap.Value = new DateTime(2026, 5, 26, 0, 0, 0, 0);
            // 
            // lblNhanVien
            // 
            lblNhanVien.AutoSize = true;
            lblNhanVien.BackColor = Color.Transparent;
            lblNhanVien.Font = new Font("Segoe UI", 9.5F);
            lblNhanVien.ForeColor = Color.FromArgb(200, 200, 205);
            lblNhanVien.Location = new Point(252, 38);
            lblNhanVien.Name = "lblNhanVien";
            lblNhanVien.Size = new Size(126, 17);
            lblNhanVien.TabIndex = 3;
            lblNhanVien.Text = "Nhân viên thực hiện:";
            // 
            // cboNhanVien
            // 
            cboNhanVien.BackColor = Color.Transparent;
            cboNhanVien.BorderColor = Color.FromArgb(63, 63, 70);
            cboNhanVien.BorderRadius = 10;
            cboNhanVien.CustomizableEdges = customizableEdges5;
            cboNhanVien.DrawMode = DrawMode.OwnerDrawFixed;
            cboNhanVien.DropDownStyle = ComboBoxStyle.DropDownList;
            cboNhanVien.FillColor = Color.FromArgb(30, 30, 33);
            cboNhanVien.FocusedColor = Color.FromArgb(31, 138, 154);
            cboNhanVien.FocusedState.BorderColor = Color.FromArgb(31, 138, 154);
            cboNhanVien.Font = new Font("Segoe UI", 10F);
            cboNhanVien.ForeColor = Color.White;
            cboNhanVien.HoverState.BorderColor = Color.FromArgb(120, 120, 130);
            cboNhanVien.ItemHeight = 30;
            cboNhanVien.Location = new Point(252, 60);
            cboNhanVien.Name = "cboNhanVien";
            cboNhanVien.ShadowDecoration.CustomizableEdges = customizableEdges6;
            cboNhanVien.Size = new Size(216, 36);
            cboNhanVien.TabIndex = 4;
            // 
            // lblGhiChu
            // 
            lblGhiChu.AutoSize = true;
            lblGhiChu.BackColor = Color.Transparent;
            lblGhiChu.Font = new Font("Segoe UI", 9.5F);
            lblGhiChu.ForeColor = Color.FromArgb(200, 200, 205);
            lblGhiChu.Location = new Point(486, 38);
            lblGhiChu.Name = "lblGhiChu";
            lblGhiChu.Size = new Size(54, 17);
            lblGhiChu.TabIndex = 5;
            lblGhiChu.Text = "Ghi chú:";
            // 
            // txtGhiChu
            // 
            txtGhiChu.BorderColor = Color.FromArgb(63, 63, 70);
            txtGhiChu.BorderRadius = 10;
            txtGhiChu.CustomizableEdges = customizableEdges7;
            txtGhiChu.DefaultText = "";
            txtGhiChu.DisabledState.BorderColor = Color.FromArgb(63, 63, 70);
            txtGhiChu.DisabledState.FillColor = Color.FromArgb(45, 45, 48);
            txtGhiChu.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            txtGhiChu.DisabledState.PlaceholderForeColor = Color.FromArgb(125, 137, 149);
            txtGhiChu.FillColor = Color.FromArgb(30, 30, 33);
            txtGhiChu.FocusedState.BorderColor = Color.FromArgb(31, 138, 154);
            txtGhiChu.Font = new Font("Segoe UI", 10F);
            txtGhiChu.ForeColor = Color.White;
            txtGhiChu.HoverState.BorderColor = Color.FromArgb(120, 120, 130);
            txtGhiChu.Location = new Point(486, 60);
            txtGhiChu.Name = "txtGhiChu";
            txtGhiChu.PasswordChar = '\0';
            txtGhiChu.PlaceholderForeColor = Color.FromArgb(110, 110, 120);
            txtGhiChu.PlaceholderText = "Lý do nhập / nhà cung cấp...";
            txtGhiChu.SelectedText = "";
            txtGhiChu.ShadowDecoration.CustomizableEdges = customizableEdges8;
            txtGhiChu.Size = new Size(232, 42);
            txtGhiChu.TabIndex = 6;
            // 
            // pnlDetail
            // 
            pnlDetail.BackColor = Color.FromArgb(39, 39, 42);
            pnlDetail.BorderRadius = 14;
            pnlDetail.Controls.Add(lblDetailTitle);
            pnlDetail.Controls.Add(lblHint);
            pnlDetail.Controls.Add(dgvChiTietNhap);
            pnlDetail.CustomizableEdges = customizableEdges11;
            pnlDetail.Location = new Point(18, 226);
            pnlDetail.Name = "pnlDetail";
            pnlDetail.ShadowDecoration.CustomizableEdges = customizableEdges12;
            pnlDetail.Size = new Size(736, 260);
            pnlDetail.TabIndex = 2;
            // 
            // lblDetailTitle
            // 
            lblDetailTitle.AutoSize = true;
            lblDetailTitle.BackColor = Color.Transparent;
            lblDetailTitle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblDetailTitle.ForeColor = Color.FromArgb(31, 138, 154);
            lblDetailTitle.Location = new Point(18, 10);
            lblDetailTitle.Name = "lblDetailTitle";
            lblDetailTitle.Size = new Size(174, 19);
            lblDetailTitle.TabIndex = 0;
            lblDetailTitle.Text = "Chi tiết nguyên liệu nhập";
            // 
            // lblHint
            // 
            lblHint.AutoSize = true;
            lblHint.BackColor = Color.Transparent;
            lblHint.Font = new Font("Segoe UI", 8.5F, FontStyle.Italic);
            lblHint.ForeColor = Color.FromArgb(160, 160, 166);
            lblHint.Location = new Point(18, 32);
            lblHint.Name = "lblHint";
            lblHint.Size = new Size(482, 15);
            lblHint.TabIndex = 1;
            lblHint.Text = "Thêm dòng → chọn mã nguyên liệu → giá nhập tự động điền (có thể sửa) → nhập số lượng";
            // 
            // dgvChiTietNhap
            // 
            dataGridViewCellStyle1.BackColor = Color.FromArgb(24, 24, 27);
            dataGridViewCellStyle1.ForeColor = Color.FromArgb(220, 220, 225);
            dgvChiTietNhap.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvChiTietNhap.BackgroundColor = Color.FromArgb(24, 24, 27);
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(31, 31, 34);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(160, 160, 166);
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(31, 31, 34);
            dataGridViewCellStyle2.SelectionForeColor = Color.FromArgb(160, 160, 166);
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvChiTietNhap.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvChiTietNhap.Columns.AddRange(new DataGridViewColumn[] { colMaNL, colSoLuong, colGiaNhap });
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = Color.FromArgb(24, 24, 27);
            dataGridViewCellStyle5.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle5.ForeColor = Color.FromArgb(220, 220, 225);
            dataGridViewCellStyle5.SelectionBackColor = Color.FromArgb(31, 138, 154);
            dataGridViewCellStyle5.SelectionForeColor = Color.FromArgb(240, 240, 245);
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.False;
            dgvChiTietNhap.DefaultCellStyle = dataGridViewCellStyle5;
            dgvChiTietNhap.GridColor = Color.FromArgb(45, 45, 48);
            dgvChiTietNhap.Location = new Point(14, 56);
            dgvChiTietNhap.Name = "dgvChiTietNhap";
            dgvChiTietNhap.RowHeadersVisible = false;
            dgvChiTietNhap.Size = new Size(708, 192);
            dgvChiTietNhap.TabIndex = 2;
            dgvChiTietNhap.ThemeStyle.AlternatingRowsStyle.BackColor = Color.FromArgb(24, 24, 27);
            dgvChiTietNhap.ThemeStyle.AlternatingRowsStyle.Font = null;
            dgvChiTietNhap.ThemeStyle.AlternatingRowsStyle.ForeColor = Color.FromArgb(220, 220, 225);
            dgvChiTietNhap.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.Empty;
            dgvChiTietNhap.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.Empty;
            dgvChiTietNhap.ThemeStyle.BackColor = Color.FromArgb(24, 24, 27);
            dgvChiTietNhap.ThemeStyle.GridColor = Color.FromArgb(45, 45, 48);
            dgvChiTietNhap.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(31, 31, 34);
            dgvChiTietNhap.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvChiTietNhap.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dgvChiTietNhap.ThemeStyle.HeaderStyle.ForeColor = Color.FromArgb(160, 160, 166);
            dgvChiTietNhap.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvChiTietNhap.ThemeStyle.HeaderStyle.Height = 23;
            dgvChiTietNhap.ThemeStyle.ReadOnly = false;
            dgvChiTietNhap.ThemeStyle.RowsStyle.BackColor = Color.FromArgb(24, 24, 27);
            dgvChiTietNhap.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvChiTietNhap.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 9F);
            dgvChiTietNhap.ThemeStyle.RowsStyle.ForeColor = Color.FromArgb(220, 220, 225);
            dgvChiTietNhap.ThemeStyle.RowsStyle.Height = 25;
            dgvChiTietNhap.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(31, 138, 154);
            dgvChiTietNhap.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(240, 240, 245);
            dgvChiTietNhap.CellEndEdit += DgvChiTietNhap_CellEndEdit;
            // 
            // colMaNL
            // 
            colMaNL.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colMaNL.FillWeight = 50F;
            colMaNL.HeaderText = "Mã nguyên liệu";
            colMaNL.MinimumWidth = 6;
            colMaNL.Name = "colMaNL";
            // 
            // colSoLuong
            // 
            colSoLuong.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleRight;
            colSoLuong.DefaultCellStyle = dataGridViewCellStyle3;
            colSoLuong.FillWeight = 20F;
            colSoLuong.HeaderText = "Số lượng";
            colSoLuong.MinimumWidth = 6;
            colSoLuong.Name = "colSoLuong";
            // 
            // colGiaNhap
            // 
            colGiaNhap.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N0";
            colGiaNhap.DefaultCellStyle = dataGridViewCellStyle4;
            colGiaNhap.FillWeight = 30F;
            colGiaNhap.HeaderText = "Giá nhập (VNĐ)";
            colGiaNhap.MinimumWidth = 6;
            colGiaNhap.Name = "colGiaNhap";
            // 
            // pnlFooter
            // 
            pnlFooter.BackColor = Color.FromArgb(31, 31, 34);
            pnlFooter.BorderRadius = 14;
            pnlFooter.Controls.Add(lblTongTien);
            pnlFooter.Controls.Add(btnHuy);
            pnlFooter.Controls.Add(btnLuu);
            pnlFooter.CustomizableEdges = customizableEdges17;
            pnlFooter.Location = new Point(18, 496);
            pnlFooter.Name = "pnlFooter";
            pnlFooter.ShadowDecoration.CustomizableEdges = customizableEdges18;
            pnlFooter.Size = new Size(736, 66);
            pnlFooter.TabIndex = 3;
            // 
            // lblTongTien
            // 
            lblTongTien.AutoSize = true;
            lblTongTien.BackColor = Color.Transparent;
            lblTongTien.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblTongTien.ForeColor = Color.FromArgb(34, 197, 94);
            lblTongTien.Location = new Point(18, 18);
            lblTongTien.Name = "lblTongTien";
            lblTongTien.Size = new Size(168, 25);
            lblTongTien.TabIndex = 0;
            lblTongTien.Text = "Thành tiền: 0 VNĐ";
            // 
            // btnHuy
            // 
            btnHuy.BorderColor = Color.FromArgb(180, 60, 60);
            btnHuy.BorderRadius = 10;
            btnHuy.BorderThickness = 1;
            btnHuy.Cursor = Cursors.Hand;
            btnHuy.CustomizableEdges = customizableEdges13;
            btnHuy.DialogResult = DialogResult.Cancel;
            btnHuy.FillColor = Color.Transparent;
            btnHuy.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnHuy.ForeColor = Color.FromArgb(220, 80, 80);
            btnHuy.HoverState.FillColor = Color.FromArgb(180, 60, 60);
            btnHuy.HoverState.ForeColor = Color.White;
            btnHuy.Location = new Point(458, 16);
            btnHuy.Name = "btnHuy";
            btnHuy.ShadowDecoration.CustomizableEdges = customizableEdges14;
            btnHuy.Size = new Size(110, 36);
            btnHuy.TabIndex = 1;
            btnHuy.Text = "Hủy";
            // 
            // btnLuu
            // 
            btnLuu.BorderRadius = 10;
            btnLuu.Cursor = Cursors.Hand;
            btnLuu.CustomizableEdges = customizableEdges15;
            btnLuu.DisabledState.BorderColor = Color.DarkGray;
            btnLuu.DisabledState.CustomBorderColor = Color.DarkGray;
            btnLuu.DisabledState.FillColor = Color.FromArgb(80, 80, 80);
            btnLuu.DisabledState.ForeColor = Color.FromArgb(190, 190, 190);
            btnLuu.FillColor = Color.FromArgb(31, 138, 154);
            btnLuu.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnLuu.ForeColor = Color.White;
            btnLuu.HoverState.FillColor = Color.FromArgb(45, 158, 174);
            btnLuu.Location = new Point(574, 16);
            btnLuu.Name = "btnLuu";
            btnLuu.ShadowDecoration.CustomizableEdges = customizableEdges16;
            btnLuu.Size = new Size(146, 36);
            btnLuu.TabIndex = 2;
            btnLuu.Text = "Tạo phiếu nhập";
            btnLuu.Click += BtnLuu_Click;
            // 
            // shadow
            // 
            shadow.TargetForm = this;
            // 
            // AddInventoryImport
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(24, 24, 27);
            CancelButton = btnHuy;
            ClientSize = new Size(772, 580);
            Controls.Add(pnlFooter);
            Controls.Add(pnlDetail);
            Controls.Add(pnlInfo);
            Controls.Add(pnlHeader);
            Font = new Font("Segoe UI", 9F);
            ForeColor = Color.White;
            FormBorderStyle = FormBorderStyle.None;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AddInventoryImport";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Tạo phiếu nhập kho";
            Load += AddInventoryImport_Load;
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            pnlInfo.ResumeLayout(false);
            pnlInfo.PerformLayout();
            pnlDetail.ResumeLayout(false);
            pnlDetail.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvChiTietNhap).EndInit();
            pnlFooter.ResumeLayout(false);
            pnlFooter.PerformLayout();
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

        private Guna2Panel pnlHeader;
        private Label lblTitle;
        private Label lblSubtitle;
        private Guna2Panel pnlInfo;
        private Label lblInfoTitle;
        private Label lblNgayNhap;
        private Guna2DateTimePicker dtpNgayNhap;
        private Label lblNhanVien;
        private Guna2ComboBox cboNhanVien;
        private Label lblGhiChu;
        private Guna2TextBox txtGhiChu;
        private Guna2Panel pnlDetail;
        private Label lblDetailTitle;
        private Label lblHint;
        private Guna2DataGridView dgvChiTietNhap;
        private DataGridViewComboBoxColumn colMaNL;
        private DataGridViewTextBoxColumn colSoLuong;
        private DataGridViewTextBoxColumn colGiaNhap;
        private Guna2Panel pnlFooter;
        private Label lblTongTien;
        private Guna2Button btnHuy;
        private Guna2Button btnLuu;
        private Guna2ShadowForm shadow;
    }
}
