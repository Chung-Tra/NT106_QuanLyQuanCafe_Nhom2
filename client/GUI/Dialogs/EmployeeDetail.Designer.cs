using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace GUI
{
    partial class EmployeeDetail
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
            lblEmpId = new Label();
            txtEmpId = new Guna2TextBox();
            lblEmail = new Label();
            txtEmail = new Guna2TextBox();
            lblFullName = new Label();
            txtFullName = new Guna2TextBox();
            lblPhone = new Label();
            txtPhone = new Guna2TextBox();
            lblRole = new Label();
            txtRole = new Guna2TextBox();
            lblStatus = new Label();
            txtStatus = new Guna2TextBox();
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
            panel1.Controls.Add(lblEmpId);
            panel1.Controls.Add(txtEmpId);
            panel1.Controls.Add(lblEmail);
            panel1.Controls.Add(txtEmail);
            panel1.Controls.Add(lblFullName);
            panel1.Controls.Add(txtFullName);
            panel1.Controls.Add(lblPhone);
            panel1.Controls.Add(txtPhone);
            panel1.Controls.Add(lblRole);
            panel1.Controls.Add(txtRole);
            panel1.Controls.Add(lblStatus);
            panel1.Controls.Add(txtStatus);
            panel1.Controls.Add(btnClose);
            panel1.Controls.Add(BtnRemove);
            panel1.CustomizableEdges = customizableEdges1;
            panel1.Location = new Point(16, 16);
            panel1.Name = "panel1";
            panel1.ShadowDecoration.CustomizableEdges = customizableEdges2;
            panel1.Size = new Size(448, 528);
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
            lblTitle.Text = "THÔNG TIN NHÂN VIÊN";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            //
            // lblEmpId
            //
            lblEmpId.AutoSize = true;
            lblEmpId.BackColor = Color.Transparent;
            lblEmpId.Font = new Font("Segoe UI", 9.5F);
            lblEmpId.ForeColor = Color.FromArgb(160, 160, 166);
            lblEmpId.Location = new Point(40, 72);
            lblEmpId.Name = "lblEmpId";
            lblEmpId.Size = new Size(90, 17);
            lblEmpId.TabIndex = 1;
            lblEmpId.Text = "Mã nhân viên:";
            //
            // txtEmpId
            //
            txtEmpId.BorderColor = Color.FromArgb(63, 63, 70);
            txtEmpId.BorderRadius = 10;
            txtEmpId.CustomizableEdges = customizableEdges3;
            txtEmpId.DefaultText = "";
            txtEmpId.DisabledState.BorderColor = Color.FromArgb(63, 63, 70);
            txtEmpId.DisabledState.FillColor = Color.FromArgb(45, 45, 48);
            txtEmpId.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            txtEmpId.DisabledState.PlaceholderForeColor = Color.FromArgb(125, 137, 149);
            txtEmpId.FillColor = Color.FromArgb(45, 45, 48);
            txtEmpId.FocusedState.BorderColor = Color.FromArgb(31, 138, 154);
            txtEmpId.Font = new Font("Segoe UI", 10.5F);
            txtEmpId.ForeColor = Color.White;
            txtEmpId.HoverState.BorderColor = Color.FromArgb(120, 120, 130);
            txtEmpId.Location = new Point(40, 92);
            txtEmpId.Name = "txtEmpId";
            txtEmpId.PasswordChar = '\0';
            txtEmpId.PlaceholderForeColor = Color.FromArgb(110, 110, 120);
            txtEmpId.PlaceholderText = "";
            txtEmpId.ReadOnly = true;
            txtEmpId.SelectedText = "";
            txtEmpId.ShadowDecoration.CustomizableEdges = customizableEdges4;
            txtEmpId.Size = new Size(365, 42);
            txtEmpId.TabIndex = 2;
            //
            // lblEmail
            //
            lblEmail.AutoSize = true;
            lblEmail.BackColor = Color.Transparent;
            lblEmail.Font = new Font("Segoe UI", 9.5F);
            lblEmail.ForeColor = Color.FromArgb(160, 160, 166);
            lblEmail.Location = new Point(40, 142);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(44, 17);
            lblEmail.TabIndex = 3;
            lblEmail.Text = "Email:";
            //
            // txtEmail
            //
            txtEmail.BorderColor = Color.FromArgb(63, 63, 70);
            txtEmail.BorderRadius = 10;
            txtEmail.CustomizableEdges = customizableEdges5;
            txtEmail.DefaultText = "";
            txtEmail.DisabledState.BorderColor = Color.FromArgb(63, 63, 70);
            txtEmail.DisabledState.FillColor = Color.FromArgb(45, 45, 48);
            txtEmail.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            txtEmail.DisabledState.PlaceholderForeColor = Color.FromArgb(125, 137, 149);
            txtEmail.FillColor = Color.FromArgb(45, 45, 48);
            txtEmail.FocusedState.BorderColor = Color.FromArgb(31, 138, 154);
            txtEmail.Font = new Font("Segoe UI", 10.5F);
            txtEmail.ForeColor = Color.White;
            txtEmail.HoverState.BorderColor = Color.FromArgb(120, 120, 130);
            txtEmail.Location = new Point(40, 162);
            txtEmail.Name = "txtEmail";
            txtEmail.PasswordChar = '\0';
            txtEmail.PlaceholderForeColor = Color.FromArgb(110, 110, 120);
            txtEmail.PlaceholderText = "";
            txtEmail.ReadOnly = true;
            txtEmail.SelectedText = "";
            txtEmail.ShadowDecoration.CustomizableEdges = customizableEdges6;
            txtEmail.Size = new Size(365, 42);
            txtEmail.TabIndex = 4;
            //
            // lblFullName
            //
            lblFullName.AutoSize = true;
            lblFullName.BackColor = Color.Transparent;
            lblFullName.Font = new Font("Segoe UI", 9.5F);
            lblFullName.ForeColor = Color.FromArgb(160, 160, 166);
            lblFullName.Location = new Point(40, 212);
            lblFullName.Name = "lblFullName";
            lblFullName.Size = new Size(72, 17);
            lblFullName.TabIndex = 5;
            lblFullName.Text = "Họ và tên:";
            //
            // txtFullName
            //
            txtFullName.BorderColor = Color.FromArgb(63, 63, 70);
            txtFullName.BorderRadius = 10;
            txtFullName.CustomizableEdges = customizableEdges7;
            txtFullName.DefaultText = "";
            txtFullName.DisabledState.BorderColor = Color.FromArgb(63, 63, 70);
            txtFullName.DisabledState.FillColor = Color.FromArgb(45, 45, 48);
            txtFullName.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            txtFullName.DisabledState.PlaceholderForeColor = Color.FromArgb(125, 137, 149);
            txtFullName.FillColor = Color.FromArgb(45, 45, 48);
            txtFullName.FocusedState.BorderColor = Color.FromArgb(31, 138, 154);
            txtFullName.Font = new Font("Segoe UI", 10.5F);
            txtFullName.ForeColor = Color.White;
            txtFullName.HoverState.BorderColor = Color.FromArgb(120, 120, 130);
            txtFullName.Location = new Point(40, 232);
            txtFullName.Name = "txtFullName";
            txtFullName.PasswordChar = '\0';
            txtFullName.PlaceholderForeColor = Color.FromArgb(110, 110, 120);
            txtFullName.PlaceholderText = "";
            txtFullName.ReadOnly = true;
            txtFullName.SelectedText = "";
            txtFullName.ShadowDecoration.CustomizableEdges = customizableEdges8;
            txtFullName.Size = new Size(365, 42);
            txtFullName.TabIndex = 6;
            //
            // lblPhone
            //
            lblPhone.AutoSize = true;
            lblPhone.BackColor = Color.Transparent;
            lblPhone.Font = new Font("Segoe UI", 9.5F);
            lblPhone.ForeColor = Color.FromArgb(160, 160, 166);
            lblPhone.Location = new Point(40, 282);
            lblPhone.Name = "lblPhone";
            lblPhone.Size = new Size(92, 17);
            lblPhone.TabIndex = 7;
            lblPhone.Text = "Số điện thoại:";
            //
            // txtPhone
            //
            txtPhone.BorderColor = Color.FromArgb(63, 63, 70);
            txtPhone.BorderRadius = 10;
            txtPhone.CustomizableEdges = customizableEdges9;
            txtPhone.DefaultText = "";
            txtPhone.DisabledState.BorderColor = Color.FromArgb(63, 63, 70);
            txtPhone.DisabledState.FillColor = Color.FromArgb(45, 45, 48);
            txtPhone.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            txtPhone.DisabledState.PlaceholderForeColor = Color.FromArgb(125, 137, 149);
            txtPhone.FillColor = Color.FromArgb(45, 45, 48);
            txtPhone.FocusedState.BorderColor = Color.FromArgb(31, 138, 154);
            txtPhone.Font = new Font("Segoe UI", 10.5F);
            txtPhone.ForeColor = Color.White;
            txtPhone.HoverState.BorderColor = Color.FromArgb(120, 120, 130);
            txtPhone.Location = new Point(40, 302);
            txtPhone.Name = "txtPhone";
            txtPhone.PasswordChar = '\0';
            txtPhone.PlaceholderForeColor = Color.FromArgb(110, 110, 120);
            txtPhone.PlaceholderText = "";
            txtPhone.ReadOnly = true;
            txtPhone.SelectedText = "";
            txtPhone.ShadowDecoration.CustomizableEdges = customizableEdges10;
            txtPhone.Size = new Size(365, 42);
            txtPhone.TabIndex = 8;
            //
            // lblRole
            //
            lblRole.AutoSize = true;
            lblRole.BackColor = Color.Transparent;
            lblRole.Font = new Font("Segoe UI", 9.5F);
            lblRole.ForeColor = Color.FromArgb(160, 160, 166);
            lblRole.Location = new Point(40, 352);
            lblRole.Name = "lblRole";
            lblRole.Size = new Size(58, 17);
            lblRole.TabIndex = 9;
            lblRole.Text = "Chức vụ:";
            //
            // txtRole
            //
            txtRole.BorderColor = Color.FromArgb(63, 63, 70);
            txtRole.BorderRadius = 10;
            txtRole.CustomizableEdges = customizableEdges11;
            txtRole.DefaultText = "";
            txtRole.DisabledState.BorderColor = Color.FromArgb(63, 63, 70);
            txtRole.DisabledState.FillColor = Color.FromArgb(45, 45, 48);
            txtRole.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            txtRole.DisabledState.PlaceholderForeColor = Color.FromArgb(125, 137, 149);
            txtRole.FillColor = Color.FromArgb(45, 45, 48);
            txtRole.FocusedState.BorderColor = Color.FromArgb(31, 138, 154);
            txtRole.Font = new Font("Segoe UI", 10.5F);
            txtRole.ForeColor = Color.White;
            txtRole.HoverState.BorderColor = Color.FromArgb(120, 120, 130);
            txtRole.Location = new Point(40, 372);
            txtRole.Name = "txtRole";
            txtRole.PasswordChar = '\0';
            txtRole.PlaceholderForeColor = Color.FromArgb(110, 110, 120);
            txtRole.PlaceholderText = "";
            txtRole.ReadOnly = true;
            txtRole.SelectedText = "";
            txtRole.ShadowDecoration.CustomizableEdges = customizableEdges12;
            txtRole.Size = new Size(170, 42);
            txtRole.TabIndex = 10;
            //
            // lblStatus
            //
            lblStatus.AutoSize = true;
            lblStatus.BackColor = Color.Transparent;
            lblStatus.Font = new Font("Segoe UI", 9.5F);
            lblStatus.ForeColor = Color.FromArgb(160, 160, 166);
            lblStatus.Location = new Point(235, 352);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(70, 17);
            lblStatus.TabIndex = 11;
            lblStatus.Text = "Trạng thái:";
            //
            // txtStatus
            //
            txtStatus.BorderColor = Color.FromArgb(63, 63, 70);
            txtStatus.BorderRadius = 10;
            txtStatus.CustomizableEdges = customizableEdges13;
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
            txtStatus.Location = new Point(235, 372);
            txtStatus.Name = "txtStatus";
            txtStatus.PasswordChar = '\0';
            txtStatus.PlaceholderForeColor = Color.FromArgb(110, 110, 120);
            txtStatus.PlaceholderText = "";
            txtStatus.ReadOnly = true;
            txtStatus.SelectedText = "";
            txtStatus.ShadowDecoration.CustomizableEdges = customizableEdges14;
            txtStatus.Size = new Size(170, 42);
            txtStatus.TabIndex = 12;
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
            btnClose.Location = new Point(235, 444);
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
            BtnRemove.Location = new Point(40, 444);
            BtnRemove.Name = "BtnRemove";
            BtnRemove.Size = new Size(170, 46);
            BtnRemove.TabIndex = 14;
            BtnRemove.Text = "Xóa";
            BtnRemove.Click += BtnRemove_Click;
            //
            // shadow
            //
            shadow.TargetForm = this;
            //
            // EmployeeDetail
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(24, 24, 27);
            ClientSize = new Size(480, 560);
            Controls.Add(panel1);
            Font = new Font("Segoe UI", 10F);
            FormBorderStyle = FormBorderStyle.None;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "EmployeeDetail";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Thông tin nhân viên";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Guna2Panel panel1;
        private Label lblTitle;
        private Label lblEmpId;
        private Guna2TextBox txtEmpId;
        private Label lblEmail;
        private Guna2TextBox txtEmail;
        private Label lblFullName;
        private Guna2TextBox txtFullName;
        private Label lblPhone;
        private Guna2TextBox txtPhone;
        private Label lblRole;
        private Guna2TextBox txtRole;
        private Label lblStatus;
        private Guna2TextBox txtStatus;
        private Guna2Button btnClose;
        private Guna2Button BtnRemove;
        private Guna2ShadowForm shadow;
    }
}
