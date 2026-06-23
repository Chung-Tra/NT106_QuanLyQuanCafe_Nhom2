using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace GUI
{
    partial class EditEmployee
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
            cboRole = new Guna2ComboBox();
            lblStatus = new Label();
            cboStatus = new Guna2ComboBox();
            btnSave = new Guna2Button();
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
            panel1.Controls.Add(lblEmpId);
            panel1.Controls.Add(txtEmpId);
            panel1.Controls.Add(lblEmail);
            panel1.Controls.Add(txtEmail);
            panel1.Controls.Add(lblFullName);
            panel1.Controls.Add(txtFullName);
            panel1.Controls.Add(lblPhone);
            panel1.Controls.Add(txtPhone);
            panel1.Controls.Add(lblRole);
            panel1.Controls.Add(cboRole);
            panel1.Controls.Add(lblStatus);
            panel1.Controls.Add(cboStatus);
            panel1.Controls.Add(btnSave);
            panel1.Controls.Add(btnCancel);
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
            lblTitle.Text = "SỬA NHÂN VIÊN";
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
            lblEmpId.Size = new Size(89, 17);
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
            txtEmpId.ForeColor = Color.Gray;
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
            txtEmail.ForeColor = Color.Gainsboro;
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
            lblFullName.Size = new Size(73, 17);
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
            txtFullName.FillColor = Color.FromArgb(30, 30, 33);
            txtFullName.FocusedState.BorderColor = Color.FromArgb(31, 138, 154);
            txtFullName.Font = new Font("Segoe UI", 10.5F);
            txtFullName.ForeColor = Color.White;
            txtFullName.HoverState.BorderColor = Color.FromArgb(120, 120, 130);
            txtFullName.Location = new Point(40, 232);
            txtFullName.Name = "txtFullName";
            txtFullName.PasswordChar = '\0';
            txtFullName.PlaceholderForeColor = Color.FromArgb(110, 110, 120);
            txtFullName.PlaceholderText = "";
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
            lblPhone.Size = new Size(105, 17);
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
            txtPhone.FillColor = Color.FromArgb(30, 30, 33);
            txtPhone.FocusedState.BorderColor = Color.FromArgb(31, 138, 154);
            txtPhone.Font = new Font("Segoe UI", 10.5F);
            txtPhone.ForeColor = Color.White;
            txtPhone.HoverState.BorderColor = Color.FromArgb(120, 120, 130);
            txtPhone.Location = new Point(40, 302);
            txtPhone.Name = "txtPhone";
            txtPhone.PasswordChar = '\0';
            txtPhone.PlaceholderForeColor = Color.FromArgb(110, 110, 120);
            txtPhone.PlaceholderText = "";
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
            // cboRole
            //
            cboRole.BackColor = Color.Transparent;
            cboRole.BorderColor = Color.FromArgb(63, 63, 70);
            cboRole.BorderRadius = 10;
            cboRole.CustomizableEdges = customizableEdges11;
            cboRole.DrawMode = DrawMode.OwnerDrawFixed;
            cboRole.DropDownStyle = ComboBoxStyle.DropDownList;
            cboRole.FillColor = Color.FromArgb(30, 30, 33);
            cboRole.FocusedColor = Color.FromArgb(31, 138, 154);
            cboRole.FocusedState.BorderColor = Color.FromArgb(31, 138, 154);
            cboRole.Font = new Font("Segoe UI", 10.5F);
            cboRole.ForeColor = Color.White;
            cboRole.HoverState.BorderColor = Color.FromArgb(120, 120, 130);
            cboRole.ItemHeight = 30;
            cboRole.Location = new Point(40, 372);
            cboRole.Name = "cboRole";
            cboRole.ShadowDecoration.CustomizableEdges = customizableEdges12;
            cboRole.Size = new Size(170, 36);
            cboRole.TabIndex = 10;
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
            // cboStatus
            //
            cboStatus.BackColor = Color.Transparent;
            cboStatus.BorderColor = Color.FromArgb(63, 63, 70);
            cboStatus.BorderRadius = 10;
            cboStatus.CustomizableEdges = customizableEdges13;
            cboStatus.DrawMode = DrawMode.OwnerDrawFixed;
            cboStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cboStatus.FillColor = Color.FromArgb(30, 30, 33);
            cboStatus.FocusedColor = Color.FromArgb(31, 138, 154);
            cboStatus.FocusedState.BorderColor = Color.FromArgb(31, 138, 154);
            cboStatus.Font = new Font("Segoe UI", 10.5F);
            cboStatus.ForeColor = Color.White;
            cboStatus.HoverState.BorderColor = Color.FromArgb(120, 120, 130);
            cboStatus.ItemHeight = 30;
            cboStatus.Location = new Point(235, 372);
            cboStatus.Name = "cboStatus";
            cboStatus.ShadowDecoration.CustomizableEdges = customizableEdges14;
            cboStatus.Size = new Size(170, 36);
            cboStatus.TabIndex = 12;
            //
            // btnSave
            //
            btnSave.BorderRadius = 10;
            btnSave.Cursor = Cursors.Hand;
            btnSave.CustomizableEdges = customizableEdges15;
            btnSave.DisabledState.BorderColor = Color.DarkGray;
            btnSave.DisabledState.CustomBorderColor = Color.DarkGray;
            btnSave.DisabledState.FillColor = Color.FromArgb(80, 80, 80);
            btnSave.DisabledState.ForeColor = Color.FromArgb(190, 190, 190);
            btnSave.FillColor = Color.FromArgb(31, 138, 154);
            btnSave.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnSave.ForeColor = Color.White;
            btnSave.HoverState.FillColor = Color.FromArgb(45, 158, 174);
            btnSave.Location = new Point(235, 444);
            btnSave.Name = "btnSave";
            btnSave.ShadowDecoration.CustomizableEdges = customizableEdges16;
            btnSave.Size = new Size(170, 46);
            btnSave.TabIndex = 13;
            btnSave.Text = "Lưu thay đổi";
            btnSave.Click += BtnSave_Click;
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
            btnCancel.Location = new Point(40, 444);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(140, 46);
            btnCancel.TabIndex = 14;
            btnCancel.Text = "Hủy";
            btnCancel.Click += BtnCancel_Click;
            //
            // shadow
            //
            shadow.TargetForm = this;
            //
            // EditEmployee
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
            Name = "EditEmployee";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Sửa nhân viên";
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
        private Guna2ComboBox cboRole;
        private Label lblStatus;
        private Guna2ComboBox cboStatus;
        private Guna2Button btnSave;
        private Guna2Button btnCancel;
        private Guna2ShadowForm shadow;
    }
}
