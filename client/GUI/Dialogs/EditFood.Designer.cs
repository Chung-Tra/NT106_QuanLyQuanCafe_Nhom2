using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace GUI
{
    partial class EditFood
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            panel1 = new Guna2Panel();
            lblTitle = new Label();
            txtTenMon = new Guna2TextBox();
            txtGia = new Guna2TextBox();
            cmLoai = new Guna2ComboBox();
            txtMoTa = new Guna2TextBox();
            btnUpdate = new Guna2Button();
            btnCancel = new Guna2Button();
            shadow = new Guna2ShadowForm(components);
            panel1.SuspendLayout();
            SuspendLayout();
            //
            // panel1
            //
            panel1.BackColor = Color.FromArgb(39, 39, 42);
            panel1.BorderRadius = 18;
            panel1.Controls.Add(lblTitle);
            panel1.Controls.Add(txtTenMon);
            panel1.Controls.Add(txtGia);
            panel1.Controls.Add(cmLoai);
            panel1.Controls.Add(txtMoTa);
            panel1.Controls.Add(btnUpdate);
            panel1.Controls.Add(btnCancel);
            panel1.CustomizableEdges = customizableEdges1;
            panel1.Location = new Point(16, 16);
            panel1.Name = "panel1";
            panel1.ShadowDecoration.CustomizableEdges = customizableEdges2;
            panel1.Size = new Size(388, 460);
            panel1.TabIndex = 0;
            //
            // lblTitle
            //
            lblTitle.AutoSize = false;
            lblTitle.BackColor = Color.Transparent;
            lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(12, 22);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(364, 32);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "SỬA THÔNG TIN MÓN";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            //
            // txtTenMon
            //
            txtTenMon.BorderColor = Color.FromArgb(63, 63, 70);
            txtTenMon.BorderRadius = 10;
            txtTenMon.CustomizableEdges = customizableEdges3;
            txtTenMon.DefaultText = "";
            txtTenMon.DisabledState.BorderColor = Color.FromArgb(63, 63, 70);
            txtTenMon.DisabledState.FillColor = Color.FromArgb(45, 45, 48);
            txtTenMon.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            txtTenMon.DisabledState.PlaceholderForeColor = Color.FromArgb(125, 137, 149);
            txtTenMon.FillColor = Color.FromArgb(30, 30, 33);
            txtTenMon.FocusedState.BorderColor = Color.FromArgb(31, 138, 154);
            txtTenMon.Font = new Font("Segoe UI", 10.5F);
            txtTenMon.ForeColor = Color.White;
            txtTenMon.HoverState.BorderColor = Color.FromArgb(120, 120, 130);
            txtTenMon.Location = new Point(36, 75);
            txtTenMon.Name = "txtTenMon";
            txtTenMon.PasswordChar = '\0';
            txtTenMon.PlaceholderForeColor = Color.FromArgb(110, 110, 120);
            txtTenMon.PlaceholderText = "Tên món";
            txtTenMon.SelectedText = "";
            txtTenMon.ShadowDecoration.CustomizableEdges = customizableEdges4;
            txtTenMon.Size = new Size(316, 46);
            txtTenMon.TabIndex = 1;
            //
            // txtGia
            //
            txtGia.BorderColor = Color.FromArgb(63, 63, 70);
            txtGia.BorderRadius = 10;
            txtGia.CustomizableEdges = customizableEdges5;
            txtGia.DefaultText = "";
            txtGia.DisabledState.BorderColor = Color.FromArgb(63, 63, 70);
            txtGia.DisabledState.FillColor = Color.FromArgb(45, 45, 48);
            txtGia.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            txtGia.DisabledState.PlaceholderForeColor = Color.FromArgb(125, 137, 149);
            txtGia.FillColor = Color.FromArgb(30, 30, 33);
            txtGia.FocusedState.BorderColor = Color.FromArgb(31, 138, 154);
            txtGia.Font = new Font("Segoe UI", 10.5F);
            txtGia.ForeColor = Color.White;
            txtGia.HoverState.BorderColor = Color.FromArgb(120, 120, 130);
            txtGia.Location = new Point(36, 131);
            txtGia.Name = "txtGia";
            txtGia.PasswordChar = '\0';
            txtGia.PlaceholderForeColor = Color.FromArgb(110, 110, 120);
            txtGia.PlaceholderText = "Giá (VNĐ)";
            txtGia.SelectedText = "";
            txtGia.ShadowDecoration.CustomizableEdges = customizableEdges6;
            txtGia.Size = new Size(316, 46);
            txtGia.TabIndex = 2;
            //
            // cmLoai
            //
            cmLoai.BackColor = Color.Transparent;
            cmLoai.BorderColor = Color.FromArgb(63, 63, 70);
            cmLoai.BorderRadius = 10;
            cmLoai.CustomizableEdges = customizableEdges7;
            cmLoai.DrawMode = DrawMode.OwnerDrawFixed;
            cmLoai.DropDownStyle = ComboBoxStyle.DropDownList;
            cmLoai.FillColor = Color.FromArgb(30, 30, 33);
            cmLoai.FocusedColor = Color.FromArgb(31, 138, 154);
            cmLoai.FocusedState.BorderColor = Color.FromArgb(31, 138, 154);
            cmLoai.Font = new Font("Segoe UI", 10.5F);
            cmLoai.ForeColor = Color.White;
            cmLoai.HoverState.BorderColor = Color.FromArgb(120, 120, 130);
            cmLoai.ItemHeight = 30;
            cmLoai.Items.AddRange(new object[] { "Đồ uống", "Đồ ăn", "Khác" });
            cmLoai.Location = new Point(36, 187);
            cmLoai.Name = "cmLoai";
            cmLoai.ShadowDecoration.CustomizableEdges = customizableEdges8;
            cmLoai.Size = new Size(316, 36);
            cmLoai.TabIndex = 3;
            //
            // txtMoTa
            //
            txtMoTa.BorderColor = Color.FromArgb(63, 63, 70);
            txtMoTa.BorderRadius = 10;
            txtMoTa.CustomizableEdges = customizableEdges9;
            txtMoTa.DefaultText = "";
            txtMoTa.DisabledState.BorderColor = Color.FromArgb(63, 63, 70);
            txtMoTa.DisabledState.FillColor = Color.FromArgb(45, 45, 48);
            txtMoTa.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            txtMoTa.DisabledState.PlaceholderForeColor = Color.FromArgb(125, 137, 149);
            txtMoTa.FillColor = Color.FromArgb(30, 30, 33);
            txtMoTa.FocusedState.BorderColor = Color.FromArgb(31, 138, 154);
            txtMoTa.Font = new Font("Segoe UI", 10.5F);
            txtMoTa.ForeColor = Color.White;
            txtMoTa.HoverState.BorderColor = Color.FromArgb(120, 120, 130);
            txtMoTa.Location = new Point(36, 233);
            txtMoTa.Multiline = true;
            txtMoTa.Name = "txtMoTa";
            txtMoTa.PasswordChar = '\0';
            txtMoTa.PlaceholderForeColor = Color.FromArgb(110, 110, 120);
            txtMoTa.PlaceholderText = "Mô tả món ăn...";
            txtMoTa.ScrollBars = ScrollBars.None;
            txtMoTa.SelectedText = "";
            txtMoTa.ShadowDecoration.CustomizableEdges = customizableEdges10;
            txtMoTa.Size = new Size(316, 90);
            txtMoTa.TabIndex = 4;
            //
            // btnUpdate
            //
            btnUpdate.BorderRadius = 10;
            btnUpdate.Cursor = Cursors.Hand;
            btnUpdate.DisabledState.BorderColor = Color.DarkGray;
            btnUpdate.DisabledState.CustomBorderColor = Color.DarkGray;
            btnUpdate.DisabledState.FillColor = Color.FromArgb(80, 80, 80);
            btnUpdate.DisabledState.ForeColor = Color.FromArgb(190, 190, 190);
            btnUpdate.FillColor = Color.FromArgb(31, 138, 154);
            btnUpdate.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnUpdate.ForeColor = Color.White;
            btnUpdate.HoverState.FillColor = Color.FromArgb(45, 158, 174);
            btnUpdate.Location = new Point(36, 360);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(140, 46);
            btnUpdate.TabIndex = 5;
            btnUpdate.Text = "Cập nhật";
            btnUpdate.Click += BtnUpdate_Click;
            //
            // btnCancel
            //
            btnCancel.BorderColor = Color.FromArgb(180, 60, 60);
            btnCancel.BorderRadius = 10;
            btnCancel.BorderThickness = 1;
            btnCancel.CausesValidation = false;
            btnCancel.Cursor = Cursors.Hand;
            btnCancel.FillColor = Color.Transparent;
            btnCancel.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnCancel.ForeColor = Color.FromArgb(220, 80, 80);
            btnCancel.HoverState.FillColor = Color.FromArgb(180, 60, 60);
            btnCancel.HoverState.ForeColor = Color.White;
            btnCancel.Location = new Point(212, 360);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(140, 46);
            btnCancel.TabIndex = 6;
            btnCancel.Text = "Hủy";
            btnCancel.Click += BtnCancel_Click;
            //
            // shadow
            //
            shadow.TargetForm = this;
            //
            // EditFood
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(24, 24, 27);
            ClientSize = new Size(420, 492);
            Controls.Add(panel1);
            Font = new Font("Segoe UI", 10F);
            FormBorderStyle = FormBorderStyle.None;
            Name = "EditFood";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Sửa Món";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Guna2Panel panel1;
        private Label lblTitle;
        private Guna2TextBox txtTenMon;
        private Guna2TextBox txtGia;
        private Guna2ComboBox cmLoai;
        private Guna2TextBox txtMoTa;
        private Guna2Button btnUpdate;
        private Guna2Button btnCancel;
        private Guna2ShadowForm shadow;
    }
}
