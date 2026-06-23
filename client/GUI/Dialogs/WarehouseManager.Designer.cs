using System.Drawing;
using System.Windows.Forms;

namespace GUI
{
    partial class WarehouseManagerForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            pnlMain = new Panel();
            lblTitle = new Label();
            lblHuongDan = new Label();
            btnTaoPhieu = new Button();
            btnTuExcel = new Button();
            btnDong = new Button();
            pnlMain.SuspendLayout();
            SuspendLayout();
            //
            // pnlMain
            //
            pnlMain.BackColor = Color.FromArgb(45, 45, 48);
            pnlMain.Controls.Add(lblTitle);
            pnlMain.Controls.Add(lblHuongDan);
            pnlMain.Controls.Add(btnTaoPhieu);
            pnlMain.Controls.Add(btnTuExcel);
            pnlMain.Controls.Add(btnDong);
            pnlMain.Dock = DockStyle.Fill;
            pnlMain.Padding = new Padding(20);
            //
            // lblTitle
            //
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(24, 20);
            lblTitle.Text = "Quản lý kho — Phiếu nhập";
            //
            // lblHuongDan
            //
            lblHuongDan.Font = new Font("Segoe UI", 9.5F);
            lblHuongDan.ForeColor = Color.Gainsboro;
            lblHuongDan.Location = new Point(26, 58);
            lblHuongDan.Size = new Size(428, 80);
            lblHuongDan.Text = "• Tạo phiếu nhập: chọn nhân viên và nhập tay từng dòng trong lưới.\r\n"
                + "• Từ Excel/CSV: mẫu cột khuyến nghị: MaNL, SoLuong, GiaNhap (Gia tùy chọn — lấy theo đơn giá kho nếu trống).";
            //
            // btnTaoPhieu
            //
            btnTaoPhieu.FlatStyle = FlatStyle.Flat;
            btnTaoPhieu.BackColor = Color.SteelBlue;
            btnTaoPhieu.ForeColor = Color.White;
            btnTaoPhieu.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnTaoPhieu.Location = new Point(26, 152);
            btnTaoPhieu.Size = new Size(208, 40);
            btnTaoPhieu.Text = "Tạo phiếu nhập (nhập tay)";
            btnTaoPhieu.UseVisualStyleBackColor = false;
            btnTaoPhieu.Cursor = Cursors.Hand;
            btnTaoPhieu.Click += BtnTaoPhieu_Click;
            //
            // btnTuExcel
            //
            btnTuExcel.FlatStyle = FlatStyle.Flat;
            btnTuExcel.BackColor = Color.SeaGreen;
            btnTuExcel.ForeColor = Color.White;
            btnTuExcel.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnTuExcel.Location = new Point(246, 152);
            btnTuExcel.Size = new Size(208, 40);
            btnTuExcel.Text = "Điền từ Excel / CSV…";
            btnTuExcel.UseVisualStyleBackColor = false;
            btnTuExcel.Cursor = Cursors.Hand;
            btnTuExcel.Click += BtnTuExcel_Click;
            //
            // btnDong
            //
            btnDong.FlatStyle = FlatStyle.Flat;
            btnDong.BackColor = Color.FromArgb(70, 70, 74);
            btnDong.ForeColor = Color.White;
            btnDong.Location = new Point(26, 208);
            btnDong.Size = new Size(100, 32);
            btnDong.Text = "Đóng";
            btnDong.UseVisualStyleBackColor = false;
            btnDong.Cursor = Cursors.Hand;
            btnDong.Click += (_, _) => Close();
            //
            // WarehouseManagerForm
            //
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(480, 270);
            ControlBox = true;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            StartPosition = FormStartPosition.CenterParent;
            BackColor = Color.FromArgb(45, 45, 48);
            Text = "Quản lý kho";
            Controls.Add(pnlMain);
            pnlMain.ResumeLayout(false);
            pnlMain.PerformLayout();
            ResumeLayout(false);

        }

        private Panel pnlMain;
        private Label lblTitle;
        private Label lblHuongDan;
        private Button btnTaoPhieu;
        private Button btnTuExcel;
        private Button btnDong;
    }
}
