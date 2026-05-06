using System.Drawing;
using System.Windows.Forms;

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
            // ---- Form ----
            txtGhiChu      = new TextBox();
            dtpNgayNhap    = new DateTimePicker();
            cboNhanVien    = new ComboBox();
            dgvChiTietNhap = new DataGridView();
            colMaNL        = new DataGridViewComboBoxColumn();
            colSoLuong     = new DataGridViewTextBoxColumn();
            colGiaNhap     = new DataGridViewTextBoxColumn();
            lblTongTien    = new Label();
            btnLuu         = new Button();
            btnHuy         = new Button();

            var pnlHeader      = new Panel();
            var lblTitle       = new Label();
            var lblSubtitle    = new Label();

            var pnlInfo        = new Panel();
            var lblInfoTitle   = new Label();
            var lblNgayNhap    = new Label();
            var lblNhanVien    = new Label();
            var lblGhiChu      = new Label();

            var pnlDetail      = new Panel();
            var lblDetailTitle = new Label();
            var lblHint        = new Label();

            var pnlFooter      = new Panel();

            ((System.ComponentModel.ISupportInitialize)dgvChiTietNhap).BeginInit();
            SuspendLayout();

            // ====================================================
            // HEADER PANEL (banner)
            // ====================================================
            pnlHeader.Dock      = DockStyle.Top;
            pnlHeader.Height    = 70;
            pnlHeader.BackColor = Color.FromArgb(30, 30, 30);

            lblTitle.Text      = "PHIẾU NHẬP KHO";
            lblTitle.Font      = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location  = new Point(20, 12);
            lblTitle.AutoSize  = true;

            lblSubtitle.Text      = "Ghi nhận nguyên liệu nhập vào kho theo phiếu";
            lblSubtitle.Font      = new Font("Segoe UI", 9F, FontStyle.Italic);
            lblSubtitle.ForeColor = Color.Silver;
            lblSubtitle.Location  = new Point(22, 42);
            lblSubtitle.AutoSize  = true;

            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Controls.Add(lblSubtitle);

            // ====================================================
            // INFO PANEL (thông tin chung phiếu)
            // ====================================================
            pnlInfo.Location  = new Point(20, 86);
            pnlInfo.Size      = new Size(840, 130);
            pnlInfo.BackColor = Color.FromArgb(45, 45, 48);

            lblInfoTitle.Text      = "Thông tin phiếu";
            lblInfoTitle.Font      = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblInfoTitle.ForeColor = Color.SteelBlue;
            lblInfoTitle.Location  = new Point(14, 8);
            lblInfoTitle.AutoSize  = true;

            // Ngày nhập
            lblNgayNhap.Text      = "Ngày nhập:";
            lblNgayNhap.Font      = new Font("Segoe UI", 9.5F);
            lblNgayNhap.ForeColor = Color.White;
            lblNgayNhap.Location  = new Point(14, 40);
            lblNgayNhap.AutoSize  = true;

            dtpNgayNhap.Location = new Point(14, 62);
            dtpNgayNhap.Size     = new Size(220, 26);
            dtpNgayNhap.Format   = DateTimePickerFormat.Custom;
            dtpNgayNhap.CustomFormat = "dd/MM/yyyy   HH:mm";
            dtpNgayNhap.Font     = new Font("Segoe UI", 10F);

            // Nhân viên
            lblNhanVien.Text      = "Nhân viên thực hiện:";
            lblNhanVien.Font      = new Font("Segoe UI", 9.5F);
            lblNhanVien.ForeColor = Color.White;
            lblNhanVien.Location  = new Point(260, 40);
            lblNhanVien.AutoSize  = true;

            cboNhanVien.Location      = new Point(260, 62);
            cboNhanVien.Size          = new Size(280, 26);
            cboNhanVien.Font          = new Font("Segoe UI", 10F);
            cboNhanVien.DropDownStyle = ComboBoxStyle.DropDownList;
            cboNhanVien.FlatStyle     = FlatStyle.Flat;
            cboNhanVien.BackColor     = Color.FromArgb(60, 60, 65);
            cboNhanVien.ForeColor     = Color.White;

            // Ghi chú
            lblGhiChu.Text      = "Ghi chú:";
            lblGhiChu.Font      = new Font("Segoe UI", 9.5F);
            lblGhiChu.ForeColor = Color.White;
            lblGhiChu.Location  = new Point(566, 40);
            lblGhiChu.AutoSize  = true;

            txtGhiChu.Location        = new Point(566, 62);
            txtGhiChu.Size            = new Size(258, 26);
            txtGhiChu.Font            = new Font("Segoe UI", 10F);
            txtGhiChu.PlaceholderText = "Lý do nhập / nhà cung cấp...";
            txtGhiChu.BackColor       = Color.FromArgb(60, 60, 65);
            txtGhiChu.ForeColor       = Color.White;
            txtGhiChu.BorderStyle     = BorderStyle.FixedSingle;

            pnlInfo.Controls.Add(lblInfoTitle);
            pnlInfo.Controls.Add(lblNgayNhap);
            pnlInfo.Controls.Add(dtpNgayNhap);
            pnlInfo.Controls.Add(lblNhanVien);
            pnlInfo.Controls.Add(cboNhanVien);
            pnlInfo.Controls.Add(lblGhiChu);
            pnlInfo.Controls.Add(txtGhiChu);

            // ====================================================
            // DETAIL PANEL (grid chi tiết nguyên liệu)
            // ====================================================
            pnlDetail.Location  = new Point(20, 226);
            pnlDetail.Size      = new Size(840, 296);
            pnlDetail.BackColor = Color.FromArgb(45, 45, 48);

            lblDetailTitle.Text      = "Chi tiết nguyên liệu nhập";
            lblDetailTitle.Font      = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblDetailTitle.ForeColor = Color.SteelBlue;
            lblDetailTitle.Location  = new Point(14, 8);
            lblDetailTitle.AutoSize  = true;

            lblHint.Text      = "Thêm dòng → chọn mã nguyên liệu → giá nhập tự động điền (có thể sửa) → nhập số lượng";
            lblHint.Font      = new Font("Segoe UI", 8.5F, FontStyle.Italic);
            lblHint.ForeColor = Color.LightGray;
            lblHint.Location  = new Point(14, 30);
            lblHint.AutoSize  = true;

            // ---- DataGridView ----
            colMaNL.HeaderText   = "Mã nguyên liệu";
            colMaNL.Name         = "colMaNL";
            colMaNL.MinimumWidth = 6;
            colMaNL.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colMaNL.FillWeight   = 50;

            colSoLuong.HeaderText = "Số lượng";
            colSoLuong.Name       = "colSoLuong";
            colSoLuong.MinimumWidth = 6;
            colSoLuong.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colSoLuong.FillWeight   = 20;
            colSoLuong.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            colGiaNhap.HeaderText = "Giá nhập (VNĐ)";
            colGiaNhap.Name       = "colGiaNhap";
            colGiaNhap.MinimumWidth = 6;
            colGiaNhap.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colGiaNhap.FillWeight   = 30;
            colGiaNhap.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            colGiaNhap.DefaultCellStyle.Format    = "N0";

            dgvChiTietNhap.Location          = new Point(14, 56);
            dgvChiTietNhap.Size              = new Size(812, 226);
            dgvChiTietNhap.BackgroundColor   = Color.FromArgb(45, 45, 48);
            dgvChiTietNhap.BorderStyle       = BorderStyle.None;
            dgvChiTietNhap.RowHeadersWidth   = 30;
            dgvChiTietNhap.GridColor         = Color.FromArgb(70, 70, 75);
            dgvChiTietNhap.EnableHeadersVisualStyles = false;
            dgvChiTietNhap.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvChiTietNhap.ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = Color.FromArgb(30, 30, 30),
                ForeColor = Color.White,
                Alignment = DataGridViewContentAlignment.MiddleCenter,
                Font = new Font("Segoe UI", 9.5F, FontStyle.Bold),
                Padding = new Padding(4)
            };
            dgvChiTietNhap.DefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = Color.FromArgb(50, 50, 55),
                ForeColor = Color.White,
                SelectionBackColor = Color.SteelBlue,
                SelectionForeColor = Color.White,
                Font = new Font("Segoe UI", 9.5F),
                Padding = new Padding(2)
            };
            dgvChiTietNhap.AlternatingRowsDefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = Color.FromArgb(45, 45, 48),
                ForeColor = Color.White
            };
            dgvChiTietNhap.RowTemplate.Height = 30;
            dgvChiTietNhap.Columns.AddRange(new DataGridViewColumn[] { colMaNL, colSoLuong, colGiaNhap });

            pnlDetail.Controls.Add(lblDetailTitle);
            pnlDetail.Controls.Add(lblHint);
            pnlDetail.Controls.Add(dgvChiTietNhap);

            // ====================================================
            // FOOTER PANEL (tổng tiền + actions)
            // ====================================================
            pnlFooter.Location  = new Point(20, 532);
            pnlFooter.Size      = new Size(840, 56);
            pnlFooter.BackColor = Color.FromArgb(30, 30, 30);

            lblTongTien.Text      = "Thành tiền: 0 VNĐ";
            lblTongTien.Font      = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTongTien.ForeColor = Color.MediumSeaGreen;
            lblTongTien.Location  = new Point(14, 14);
            lblTongTien.AutoSize  = true;

            btnHuy.Text      = "Hủy";
            btnHuy.Location  = new Point(606, 11);
            btnHuy.Size      = new Size(100, 36);
            btnHuy.Font      = new Font("Segoe UI", 10F);
            btnHuy.FlatStyle = FlatStyle.Flat;
            btnHuy.BackColor = Color.FromArgb(60, 60, 65);
            btnHuy.ForeColor = Color.White;
            btnHuy.Cursor    = Cursors.Hand;
            btnHuy.DialogResult = DialogResult.Cancel;
            btnHuy.FlatAppearance.BorderSize = 0;

            btnLuu.Text      = "Tạo phiếu nhập";
            btnLuu.Location  = new Point(712, 11);
            btnLuu.Size      = new Size(120, 36);
            btnLuu.Font      = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnLuu.FlatStyle = FlatStyle.Flat;
            btnLuu.BackColor = Color.SteelBlue;
            btnLuu.ForeColor = Color.White;
            btnLuu.Cursor    = Cursors.Hand;
            btnLuu.FlatAppearance.BorderSize = 0;

            pnlFooter.Controls.Add(lblTongTien);
            pnlFooter.Controls.Add(btnHuy);
            pnlFooter.Controls.Add(btnLuu);

            // ====================================================
            // FORM
            // ====================================================
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode       = AutoScaleMode.Font;
            ClientSize          = new Size(880, 608);
            BackColor           = Color.FromArgb(37, 37, 38);
            ForeColor           = Color.White;
            Font                = new Font("Segoe UI", 9F);
            FormBorderStyle     = FormBorderStyle.FixedDialog;
            MaximizeBox         = false;
            MinimizeBox         = false;
            StartPosition       = FormStartPosition.CenterParent;
            CancelButton        = btnHuy;
            Text                = "Tạo phiếu nhập kho";
            Name                = "AddInventoryImport";

            Controls.Add(pnlFooter);
            Controls.Add(pnlDetail);
            Controls.Add(pnlInfo);
            Controls.Add(pnlHeader);

            ((System.ComponentModel.ISupportInitialize)dgvChiTietNhap).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox        txtGhiChu;
        private DateTimePicker dtpNgayNhap;
        private ComboBox       cboNhanVien;
        private DataGridView   dgvChiTietNhap;
        private Label          lblTongTien;
        private Button         btnLuu;
        private Button         btnHuy;
        private DataGridViewComboBoxColumn colMaNL;
        private DataGridViewTextBoxColumn  colSoLuong;
        private DataGridViewTextBoxColumn  colGiaNhap;
    }
}
