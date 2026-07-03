using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace GUI
{
    partial class FoodDetail
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges11 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges12 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges13 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges14 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges15 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges16 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            panel1 = new Guna2Panel();
            lblTitle = new Label();
            lblFoodId = new Label();
            txtFoodId = new Guna2TextBox();
            lblFoodName = new Label();
            txtFoodName = new Guna2TextBox();
            lblPrice = new Label();
            txtPrice = new Guna2TextBox();
            lblCategory = new Label();
            txtCategory = new Guna2TextBox();
            lblStatus = new Label();
            txtStatus = new Guna2TextBox();
            lblMoTa = new Label();
            txtMoTa = new Guna2TextBox();
            btnClose = new Guna2Button();
            BtnRemove = new Guna2Button();
            shadow = new Guna2ShadowForm(components);
            panel1.SuspendLayout();
            SuspendLayout();
            //
            // panel1
            //
            panel1.BackColor = Color.FromArgb(39, 39, 42);
            panel1.BorderRadius = 18;
            panel1.Controls.Add(lblTitle);
            panel1.Controls.Add(lblFoodId);
            panel1.Controls.Add(txtFoodId);
            panel1.Controls.Add(lblFoodName);
            panel1.Controls.Add(txtFoodName);
            panel1.Controls.Add(lblPrice);
            panel1.Controls.Add(txtPrice);
            panel1.Controls.Add(lblCategory);
            panel1.Controls.Add(txtCategory);
            panel1.Controls.Add(lblStatus);
            panel1.Controls.Add(txtStatus);
            panel1.Controls.Add(lblMoTa);
            panel1.Controls.Add(txtMoTa);
            panel1.Controls.Add(btnClose);
            panel1.Controls.Add(BtnRemove);
            panel1.CustomizableEdges = customizableEdges1;
            panel1.Location = new Point(16, 16);
            panel1.Name = "panel1";
            panel1.ShadowDecoration.CustomizableEdges = customizableEdges2;
            panel1.Size = new Size(448, 620);
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
            lblTitle.Size = new Size(424, 32);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "THÔNG TIN MÓN ĂN";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            //
            // lblFoodId
            //
            lblFoodId.AutoSize = true;
            lblFoodId.BackColor = Color.Transparent;
            lblFoodId.Font = new Font("Segoe UI", 9.5F);
            lblFoodId.ForeColor = Color.FromArgb(160, 160, 166);
            lblFoodId.Location = new Point(40, 72);
            lblFoodId.Name = "lblFoodId";
            lblFoodId.Size = new Size(82, 17);
            lblFoodId.TabIndex = 1;
            lblFoodId.Text = "Mã món ăn:";
            //
            // txtFoodId
            //
            txtFoodId.BorderColor = Color.FromArgb(63, 63, 70);
            txtFoodId.BorderRadius = 10;
            txtFoodId.CustomizableEdges = customizableEdges3;
            txtFoodId.DefaultText = "";
            txtFoodId.DisabledState.BorderColor = Color.FromArgb(63, 63, 70);
            txtFoodId.DisabledState.FillColor = Color.FromArgb(45, 45, 48);
            txtFoodId.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            txtFoodId.DisabledState.PlaceholderForeColor = Color.FromArgb(125, 137, 149);
            txtFoodId.FillColor = Color.FromArgb(45, 45, 48);
            txtFoodId.FocusedState.BorderColor = Color.FromArgb(31, 138, 154);
            txtFoodId.Font = new Font("Segoe UI", 10.5F);
            txtFoodId.ForeColor = Color.White;
            txtFoodId.HoverState.BorderColor = Color.FromArgb(120, 120, 130);
            txtFoodId.Location = new Point(40, 92);
            txtFoodId.Name = "txtFoodId";
            txtFoodId.PasswordChar = '\0';
            txtFoodId.PlaceholderForeColor = Color.FromArgb(110, 110, 120);
            txtFoodId.PlaceholderText = "";
            txtFoodId.ReadOnly = true;
            txtFoodId.SelectedText = "";
            txtFoodId.ShadowDecoration.CustomizableEdges = customizableEdges4;
            txtFoodId.Size = new Size(365, 42);
            txtFoodId.TabIndex = 2;
            //
            // lblFoodName
            //
            lblFoodName.AutoSize = true;
            lblFoodName.BackColor = Color.Transparent;
            lblFoodName.Font = new Font("Segoe UI", 9.5F);
            lblFoodName.ForeColor = Color.FromArgb(160, 160, 166);
            lblFoodName.Location = new Point(40, 142);
            lblFoodName.Name = "lblFoodName";
            lblFoodName.Size = new Size(64, 17);
            lblFoodName.TabIndex = 3;
            lblFoodName.Text = "Tên món:";
            //
            // txtFoodName
            //
            txtFoodName.BorderColor = Color.FromArgb(63, 63, 70);
            txtFoodName.BorderRadius = 10;
            txtFoodName.CustomizableEdges = customizableEdges5;
            txtFoodName.DefaultText = "";
            txtFoodName.DisabledState.BorderColor = Color.FromArgb(63, 63, 70);
            txtFoodName.DisabledState.FillColor = Color.FromArgb(45, 45, 48);
            txtFoodName.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            txtFoodName.DisabledState.PlaceholderForeColor = Color.FromArgb(125, 137, 149);
            txtFoodName.FillColor = Color.FromArgb(45, 45, 48);
            txtFoodName.FocusedState.BorderColor = Color.FromArgb(31, 138, 154);
            txtFoodName.Font = new Font("Segoe UI", 10.5F);
            txtFoodName.ForeColor = Color.White;
            txtFoodName.HoverState.BorderColor = Color.FromArgb(120, 120, 130);
            txtFoodName.Location = new Point(40, 162);
            txtFoodName.Name = "txtFoodName";
            txtFoodName.PasswordChar = '\0';
            txtFoodName.PlaceholderForeColor = Color.FromArgb(110, 110, 120);
            txtFoodName.PlaceholderText = "";
            txtFoodName.ReadOnly = true;
            txtFoodName.SelectedText = "";
            txtFoodName.ShadowDecoration.CustomizableEdges = customizableEdges6;
            txtFoodName.Size = new Size(365, 42);
            txtFoodName.TabIndex = 4;
            //
            // lblPrice
            //
            lblPrice.AutoSize = true;
            lblPrice.BackColor = Color.Transparent;
            lblPrice.Font = new Font("Segoe UI", 9.5F);
            lblPrice.ForeColor = Color.FromArgb(160, 160, 166);
            lblPrice.Location = new Point(40, 212);
            lblPrice.Name = "lblPrice";
            lblPrice.Size = new Size(57, 17);
            lblPrice.TabIndex = 5;
            lblPrice.Text = "Giá bán:";
            //
            // txtPrice
            //
            txtPrice.BorderColor = Color.FromArgb(63, 63, 70);
            txtPrice.BorderRadius = 10;
            txtPrice.CustomizableEdges = customizableEdges7;
            txtPrice.DefaultText = "";
            txtPrice.DisabledState.BorderColor = Color.FromArgb(63, 63, 70);
            txtPrice.DisabledState.FillColor = Color.FromArgb(45, 45, 48);
            txtPrice.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            txtPrice.DisabledState.PlaceholderForeColor = Color.FromArgb(125, 137, 149);
            txtPrice.FillColor = Color.FromArgb(45, 45, 48);
            txtPrice.FocusedState.BorderColor = Color.FromArgb(31, 138, 154);
            txtPrice.Font = new Font("Segoe UI", 10.5F);
            txtPrice.ForeColor = Color.White;
            txtPrice.HoverState.BorderColor = Color.FromArgb(120, 120, 130);
            txtPrice.Location = new Point(40, 232);
            txtPrice.Name = "txtPrice";
            txtPrice.PasswordChar = '\0';
            txtPrice.PlaceholderForeColor = Color.FromArgb(110, 110, 120);
            txtPrice.PlaceholderText = "";
            txtPrice.ReadOnly = true;
            txtPrice.SelectedText = "";
            txtPrice.ShadowDecoration.CustomizableEdges = customizableEdges8;
            txtPrice.Size = new Size(365, 42);
            txtPrice.TabIndex = 6;
            //
            // lblCategory
            //
            lblCategory.AutoSize = true;
            lblCategory.BackColor = Color.Transparent;
            lblCategory.Font = new Font("Segoe UI", 9.5F);
            lblCategory.ForeColor = Color.FromArgb(160, 160, 166);
            lblCategory.Location = new Point(40, 282);
            lblCategory.Name = "lblCategory";
            lblCategory.Size = new Size(65, 17);
            lblCategory.TabIndex = 7;
            lblCategory.Text = "Loại món:";
            //
            // txtCategory
            //
            txtCategory.BorderColor = Color.FromArgb(63, 63, 70);
            txtCategory.BorderRadius = 10;
            txtCategory.CustomizableEdges = customizableEdges9;
            txtCategory.DefaultText = "";
            txtCategory.DisabledState.BorderColor = Color.FromArgb(63, 63, 70);
            txtCategory.DisabledState.FillColor = Color.FromArgb(45, 45, 48);
            txtCategory.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            txtCategory.DisabledState.PlaceholderForeColor = Color.FromArgb(125, 137, 149);
            txtCategory.FillColor = Color.FromArgb(45, 45, 48);
            txtCategory.FocusedState.BorderColor = Color.FromArgb(31, 138, 154);
            txtCategory.Font = new Font("Segoe UI", 10.5F);
            txtCategory.ForeColor = Color.White;
            txtCategory.HoverState.BorderColor = Color.FromArgb(120, 120, 130);
            txtCategory.Location = new Point(40, 302);
            txtCategory.Name = "txtCategory";
            txtCategory.PasswordChar = '\0';
            txtCategory.PlaceholderForeColor = Color.FromArgb(110, 110, 120);
            txtCategory.PlaceholderText = "";
            txtCategory.ReadOnly = true;
            txtCategory.SelectedText = "";
            txtCategory.ShadowDecoration.CustomizableEdges = customizableEdges10;
            txtCategory.Size = new Size(170, 42);
            txtCategory.TabIndex = 8;
            //
            // lblStatus
            //
            lblStatus.AutoSize = true;
            lblStatus.BackColor = Color.Transparent;
            lblStatus.Font = new Font("Segoe UI", 9.5F);
            lblStatus.ForeColor = Color.FromArgb(160, 160, 166);
            lblStatus.Location = new Point(235, 282);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(70, 17);
            lblStatus.TabIndex = 9;
            lblStatus.Text = "Trạng thái:";
            //
            // txtStatus
            //
            txtStatus.BorderColor = Color.FromArgb(63, 63, 70);
            txtStatus.BorderRadius = 10;
            txtStatus.CustomizableEdges = customizableEdges11;
            txtStatus.DefaultText = "";
            txtStatus.DisabledState.BorderColor = Color.FromArgb(63, 63, 70);
            txtStatus.DisabledState.FillColor = Color.FromArgb(45, 45, 48);
            txtStatus.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            txtStatus.DisabledState.PlaceholderForeColor = Color.FromArgb(125, 137, 149);
            txtStatus.FillColor = Color.FromArgb(45, 45, 48);
            txtStatus.FocusedState.BorderColor = Color.FromArgb(31, 138, 154);
            txtStatus.Font = new Font("Segoe UI", 10.5F);
            txtStatus.ForeColor = Color.White;
            txtStatus.HoverState.BorderColor = Color.FromArgb(120, 120, 130);
            txtStatus.Location = new Point(235, 302);
            txtStatus.Name = "txtStatus";
            txtStatus.PasswordChar = '\0';
            txtStatus.PlaceholderForeColor = Color.FromArgb(110, 110, 120);
            txtStatus.PlaceholderText = "";
            txtStatus.ReadOnly = true;
            txtStatus.SelectedText = "";
            txtStatus.ShadowDecoration.CustomizableEdges = customizableEdges12;
            txtStatus.Size = new Size(170, 42);
            txtStatus.TabIndex = 10;
            //
            // lblMoTa
            //
            lblMoTa.AutoSize = true;
            lblMoTa.BackColor = Color.Transparent;
            lblMoTa.Font = new Font("Segoe UI", 9.5F);
            lblMoTa.ForeColor = Color.FromArgb(160, 160, 166);
            lblMoTa.Location = new Point(40, 352);
            lblMoTa.Name = "lblMoTa";
            lblMoTa.Size = new Size(50, 17);
            lblMoTa.TabIndex = 11;
            lblMoTa.Text = "Mô tả:";
            //
            // txtMoTa
            //
            txtMoTa.BorderColor = Color.FromArgb(63, 63, 70);
            txtMoTa.BorderRadius = 10;
            txtMoTa.CustomizableEdges = customizableEdges13;
            txtMoTa.DefaultText = "";
            txtMoTa.DisabledState.BorderColor = Color.FromArgb(63, 63, 70);
            txtMoTa.DisabledState.FillColor = Color.FromArgb(45, 45, 48);
            txtMoTa.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            txtMoTa.DisabledState.PlaceholderForeColor = Color.FromArgb(125, 137, 149);
            txtMoTa.FillColor = Color.FromArgb(45, 45, 48);
            txtMoTa.FocusedState.BorderColor = Color.FromArgb(31, 138, 154);
            txtMoTa.Font = new Font("Segoe UI", 10.5F);
            txtMoTa.ForeColor = Color.White;
            txtMoTa.HoverState.BorderColor = Color.FromArgb(120, 120, 130);
            txtMoTa.Location = new Point(40, 372);
            txtMoTa.Multiline = true;
            txtMoTa.Name = "txtMoTa";
            txtMoTa.PasswordChar = '\0';
            txtMoTa.PlaceholderForeColor = Color.FromArgb(110, 110, 120);
            txtMoTa.PlaceholderText = "";
            txtMoTa.ReadOnly = true;
            txtMoTa.ScrollBars = ScrollBars.None;
            txtMoTa.SelectedText = "";
            txtMoTa.ShadowDecoration.CustomizableEdges = customizableEdges14;
            txtMoTa.Size = new Size(365, 90);
            txtMoTa.TabIndex = 12;
            //
            // btnClose
            //
            btnClose.BorderRadius = 10;
            btnClose.Cursor = Cursors.Hand;
            btnClose.CustomizableEdges = customizableEdges15;
            btnClose.DisabledState.BorderColor = Color.DarkGray;
            btnClose.DisabledState.CustomBorderColor = Color.DarkGray;
            btnClose.DisabledState.FillColor = Color.FromArgb(80, 80, 80);
            btnClose.DisabledState.ForeColor = Color.FromArgb(190, 190, 190);
            btnClose.FillColor = Color.FromArgb(31, 138, 154);
            btnClose.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnClose.ForeColor = Color.White;
            btnClose.HoverState.FillColor = Color.FromArgb(45, 158, 174);
            btnClose.Location = new Point(235, 510);
            btnClose.Name = "btnClose";
            btnClose.ShadowDecoration.CustomizableEdges = customizableEdges16;
            btnClose.Size = new Size(170, 46);
            btnClose.TabIndex = 13;
            btnClose.Text = "Đóng";
            btnClose.Click += btnClose_Click;
            //
            // BtnRemove
            //
            BtnRemove.BorderColor = Color.FromArgb(180, 60, 60);
            BtnRemove.BorderRadius = 10;
            BtnRemove.BorderThickness = 1;
            BtnRemove.Cursor = Cursors.Hand;
            BtnRemove.FillColor = Color.Transparent;
            BtnRemove.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            BtnRemove.ForeColor = Color.FromArgb(220, 80, 80);
            BtnRemove.HoverState.FillColor = Color.FromArgb(180, 60, 60);
            BtnRemove.HoverState.ForeColor = Color.White;
            BtnRemove.Location = new Point(40, 510);
            BtnRemove.Name = "BtnRemove";
            BtnRemove.Size = new Size(170, 46);
            BtnRemove.TabIndex = 14;
            BtnRemove.Text = "Xóa món";
            BtnRemove.Click += BtnRemove_Click;
            //
            // shadow
            //
            shadow.TargetForm = this;
            //
            // FoodDetail
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(24, 24, 27);
            ClientSize = new Size(480, 652);
            Controls.Add(panel1);
            Font = new Font("Segoe UI", 10F);
            FormBorderStyle = FormBorderStyle.None;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FoodDetail";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Thông tin món ăn";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Guna2Panel panel1;
        private Label lblTitle;
        private Label lblFoodId;
        private Guna2TextBox txtFoodId;
        private Label lblFoodName;
        private Guna2TextBox txtFoodName;
        private Label lblPrice;
        private Guna2TextBox txtPrice;
        private Label lblCategory;
        private Guna2TextBox txtCategory;
        private Label lblStatus;
        private Guna2TextBox txtStatus;
        private Label lblMoTa;
        private Guna2TextBox txtMoTa;
        private Guna2Button btnClose;
        private Guna2Button BtnRemove;
        private Guna2ShadowForm shadow;
    }
}
