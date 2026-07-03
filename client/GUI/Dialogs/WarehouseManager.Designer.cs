using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace GUI
{
    partial class WarehouseManager
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            pnlMain = new Guna2Panel();
            lblTitle = new Label();
            lblHuongDan = new Label();
            btnTaoPhieu = new Guna2Button();
            btnTuExcel = new Guna2Button();
            btnDong = new Guna2Button();
            btnClose = new Guna2Button();
            shadow = new Guna2ShadowForm(components);
            pnlMain.SuspendLayout();
            SuspendLayout();
            //
            // pnlMain
            //
            pnlMain.BackColor = Color.FromArgb(39, 39, 42);
            pnlMain.BorderRadius = 18;
            pnlMain.Controls.Add(lblTitle);
            pnlMain.Controls.Add(btnClose);
            pnlMain.Controls.Add(lblHuongDan);
            pnlMain.Controls.Add(btnTaoPhieu);
            pnlMain.Controls.Add(btnTuExcel);
            pnlMain.Controls.Add(btnDong);
            pnlMain.CustomizableEdges = customizableEdges1;
            pnlMain.Location = new Point(16, 16);
            pnlMain.Name = "pnlMain";
            pnlMain.ShadowDecoration.CustomizableEdges = customizableEdges2;
            pnlMain.Size = new Size(528, 290);
            pnlMain.TabIndex = 0;
            //
            // lblTitle
            //
            lblTitle.AutoSize = false;
            lblTitle.BackColor = Color.Transparent;
            lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(12, 22);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(504, 32);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Quản lý kho — Phiếu nhập";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            //
            // lblHuongDan
            //
            lblHuongDan.BackColor = Color.Transparent;
            lblHuongDan.Font = new Font("Segoe UI", 9.5F);
            lblHuongDan.ForeColor = Color.FromArgb(200, 200, 205);
            lblHuongDan.Location = new Point(28, 70);
            lblHuongDan.Name = "lblHuongDan";
            lblHuongDan.Size = new Size(472, 80);
            lblHuongDan.TabIndex = 1;
            lblHuongDan.Text = "• Tạo phiếu nhập: chọn nhân viên và nhập tay từng dòng trong lưới.\r\n"
                + "• Từ Excel/CSV: mẫu cột khuyến nghị: MaNL, SoLuong, GiaNhap (Gia tùy chọn — lấy theo đơn giá kho nếu trống).";
            //
            // btnTaoPhieu
            //
            btnTaoPhieu.BorderRadius = 10;
            btnTaoPhieu.Cursor = Cursors.Hand;
            btnTaoPhieu.CustomizableEdges = customizableEdges3;
            btnTaoPhieu.DisabledState.BorderColor = Color.DarkGray;
            btnTaoPhieu.DisabledState.CustomBorderColor = Color.DarkGray;
            btnTaoPhieu.DisabledState.FillColor = Color.FromArgb(80, 80, 80);
            btnTaoPhieu.DisabledState.ForeColor = Color.FromArgb(190, 190, 190);
            btnTaoPhieu.FillColor = Color.FromArgb(31, 138, 154);
            btnTaoPhieu.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnTaoPhieu.ForeColor = Color.White;
            btnTaoPhieu.HoverState.FillColor = Color.FromArgb(45, 158, 174);
            btnTaoPhieu.Location = new Point(28, 170);
            btnTaoPhieu.Name = "btnTaoPhieu";
            btnTaoPhieu.ShadowDecoration.CustomizableEdges = customizableEdges4;
            btnTaoPhieu.Size = new Size(228, 46);
            btnTaoPhieu.TabIndex = 2;
            btnTaoPhieu.Text = "Tạo phiếu nhập (nhập tay)";
            btnTaoPhieu.Click += BtnTaoPhieu_Click;
            //
            // btnTuExcel
            //
            btnTuExcel.BorderRadius = 10;
            btnTuExcel.Cursor = Cursors.Hand;
            btnTuExcel.CustomizableEdges = customizableEdges5;
            btnTuExcel.DisabledState.BorderColor = Color.DarkGray;
            btnTuExcel.DisabledState.CustomBorderColor = Color.DarkGray;
            btnTuExcel.DisabledState.FillColor = Color.FromArgb(80, 80, 80);
            btnTuExcel.DisabledState.ForeColor = Color.FromArgb(190, 190, 190);
            btnTuExcel.FillColor = Color.FromArgb(34, 197, 94);
            btnTuExcel.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnTuExcel.ForeColor = Color.White;
            btnTuExcel.HoverState.FillColor = Color.FromArgb(50, 210, 110);
            btnTuExcel.Location = new Point(272, 170);
            btnTuExcel.Name = "btnTuExcel";
            btnTuExcel.ShadowDecoration.CustomizableEdges = customizableEdges6;
            btnTuExcel.Size = new Size(228, 46);
            btnTuExcel.TabIndex = 3;
            btnTuExcel.Text = "Điền từ Excel / CSV…";
            btnTuExcel.Click += BtnTuExcel_Click;
            //
            // btnDong
            //
            btnDong.BorderColor = Color.FromArgb(180, 60, 60);
            btnDong.BorderRadius = 10;
            btnDong.BorderThickness = 1;
            btnDong.Cursor = Cursors.Hand;
            btnDong.CustomizableEdges = customizableEdges7;
            btnDong.FillColor = Color.Transparent;
            btnDong.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnDong.ForeColor = Color.FromArgb(220, 80, 80);
            btnDong.HoverState.FillColor = Color.FromArgb(180, 60, 60);
            btnDong.HoverState.ForeColor = Color.White;
            btnDong.Location = new Point(204, 230);
            btnDong.Name = "btnDong";
            btnDong.ShadowDecoration.CustomizableEdges = customizableEdges8;
            btnDong.Size = new Size(120, 40);
            btnDong.TabIndex = 4;
            btnDong.Text = "Đóng";
            btnDong.Click += BtnDong_Click;
            //
            // btnClose
            //
            btnClose.BorderRadius = 6;
            btnClose.Cursor = Cursors.Hand;
            btnClose.CustomizableEdges = customizableEdges9;
            btnClose.FillColor = Color.Transparent;
            btnClose.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnClose.ForeColor = Color.FromArgb(180, 180, 185);
            btnClose.HoverState.FillColor = Color.FromArgb(180, 60, 60);
            btnClose.HoverState.ForeColor = Color.White;
            btnClose.Location = new Point(488, 12);
            btnClose.Name = "btnClose";
            btnClose.ShadowDecoration.CustomizableEdges = customizableEdges10;
            btnClose.Size = new Size(28, 28);
            btnClose.TabIndex = 5;
            btnClose.Text = "✕";
            btnClose.Click += BtnClose_Click;
            //
            // shadow
            //
            shadow.TargetForm = this;
            //
            // WarehouseManager
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(24, 24, 27);
            ClientSize = new Size(560, 322);
            Controls.Add(pnlMain);
            ControlBox = true;
            Font = new Font("Segoe UI", 10F);
            FormBorderStyle = FormBorderStyle.None;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "WarehouseManager";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Quản lý kho";
            pnlMain.ResumeLayout(false);
            pnlMain.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Guna2Panel pnlMain;
        private Label lblTitle;
        private Label lblHuongDan;
        private Guna2Button btnTaoPhieu;
        private Guna2Button btnTuExcel;
        private Guna2Button btnDong;
        private Guna2Button btnClose;
        private Guna2ShadowForm shadow;
    }
}
