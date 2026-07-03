using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace GUI
{
    partial class AddEmployee
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges17 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges18 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
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
            textBox1 = new Label();
            txtFullName = new Guna2TextBox();
            txtEmail = new Guna2TextBox();
            txtPhone = new Guna2TextBox();
            dtpHireDate = new Guna2DateTimePicker();
            cboRole = new Guna2ComboBox();
            txtPassword = new Guna2TextBox();
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
            panel1.Controls.Add(textBox1);
            panel1.Controls.Add(txtFullName);
            panel1.Controls.Add(txtEmail);
            panel1.Controls.Add(txtPhone);
            panel1.Controls.Add(dtpHireDate);
            panel1.Controls.Add(cboRole);
            panel1.Controls.Add(txtPassword);
            panel1.Controls.Add(btnSave);
            panel1.Controls.Add(btnCancel);
            panel1.CustomizableEdges = customizableEdges17;
            panel1.Location = new Point(16, 16);
            panel1.Name = "panel1";
            panel1.ShadowDecoration.CustomizableEdges = customizableEdges18;
            panel1.Size = new Size(448, 528);
            panel1.TabIndex = 0;
            // 
            // textBox1
            // 
            textBox1.BackColor = Color.Transparent;
            textBox1.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            textBox1.ForeColor = Color.White;
            textBox1.Location = new Point(12, 22);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(424, 32);
            textBox1.TabIndex = 0;
            textBox1.Text = "TẠO ACCOUNT NHÂN VIÊN";
            textBox1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txtFullName
            // 
            txtFullName.BorderColor = Color.FromArgb(63, 63, 70);
            txtFullName.BorderRadius = 10;
            txtFullName.CustomizableEdges = customizableEdges1;
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
            txtFullName.Location = new Point(40, 80);
            txtFullName.Name = "txtFullName";
            txtFullName.PasswordChar = '\0';
            txtFullName.PlaceholderForeColor = Color.FromArgb(110, 110, 120);
            txtFullName.PlaceholderText = "Họ và tên";
            txtFullName.SelectedText = "";
            txtFullName.ShadowDecoration.CustomizableEdges = customizableEdges2;
            txtFullName.Size = new Size(365, 46);
            txtFullName.TabIndex = 1;
            // 
            // txtEmail
            // 
            txtEmail.BorderColor = Color.FromArgb(63, 63, 70);
            txtEmail.BorderRadius = 10;
            txtEmail.CustomizableEdges = customizableEdges3;
            txtEmail.DefaultText = "";
            txtEmail.DisabledState.BorderColor = Color.FromArgb(63, 63, 70);
            txtEmail.DisabledState.FillColor = Color.FromArgb(45, 45, 48);
            txtEmail.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            txtEmail.DisabledState.PlaceholderForeColor = Color.FromArgb(125, 137, 149);
            txtEmail.FillColor = Color.FromArgb(30, 30, 33);
            txtEmail.FocusedState.BorderColor = Color.FromArgb(31, 138, 154);
            txtEmail.Font = new Font("Segoe UI", 10.5F);
            txtEmail.ForeColor = Color.White;
            txtEmail.HoverState.BorderColor = Color.FromArgb(120, 120, 130);
            txtEmail.Location = new Point(40, 138);
            txtEmail.Name = "txtEmail";
            txtEmail.PasswordChar = '\0';
            txtEmail.PlaceholderForeColor = Color.FromArgb(110, 110, 120);
            txtEmail.PlaceholderText = "Email";
            txtEmail.SelectedText = "";
            txtEmail.ShadowDecoration.CustomizableEdges = customizableEdges4;
            txtEmail.Size = new Size(365, 46);
            txtEmail.TabIndex = 2;
            // 
            // txtPhone
            // 
            txtPhone.BorderColor = Color.FromArgb(63, 63, 70);
            txtPhone.BorderRadius = 10;
            txtPhone.CustomizableEdges = customizableEdges5;
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
            txtPhone.Location = new Point(40, 196);
            txtPhone.Name = "txtPhone";
            txtPhone.PasswordChar = '\0';
            txtPhone.PlaceholderForeColor = Color.FromArgb(110, 110, 120);
            txtPhone.PlaceholderText = "Số điện thoại";
            txtPhone.SelectedText = "";
            txtPhone.ShadowDecoration.CustomizableEdges = customizableEdges6;
            txtPhone.Size = new Size(365, 46);
            txtPhone.TabIndex = 3;
            // 
            // dtpHireDate
            // 
            dtpHireDate.BorderRadius = 10;
            dtpHireDate.Checked = true;
            dtpHireDate.CustomizableEdges = customizableEdges7;
            dtpHireDate.FillColor = Color.FromArgb(30, 30, 33);
            dtpHireDate.Font = new Font("Segoe UI", 10.5F);
            dtpHireDate.Format = DateTimePickerFormat.Short;
            dtpHireDate.Location = new Point(40, 254);
            dtpHireDate.MaxDate = new DateTime(9998, 12, 31, 0, 0, 0, 0);
            dtpHireDate.MinDate = new DateTime(1900, 1, 1, 0, 0, 0, 0);
            dtpHireDate.Name = "dtpHireDate";
            dtpHireDate.ShadowDecoration.CustomizableEdges = customizableEdges8;
            dtpHireDate.Size = new Size(365, 46);
            dtpHireDate.TabIndex = 4;
            dtpHireDate.Value = new DateTime(2026, 5, 26, 0, 0, 0, 0);
            // 
            // cboRole
            // 
            cboRole.BackColor = Color.Transparent;
            cboRole.BorderColor = Color.FromArgb(63, 63, 70);
            cboRole.BorderRadius = 10;
            cboRole.CustomizableEdges = customizableEdges9;
            cboRole.DrawMode = DrawMode.OwnerDrawFixed;
            cboRole.DropDownStyle = ComboBoxStyle.DropDownList;
            cboRole.FillColor = Color.FromArgb(30, 30, 33);
            cboRole.FocusedColor = Color.FromArgb(31, 138, 154);
            cboRole.FocusedState.BorderColor = Color.FromArgb(31, 138, 154);
            cboRole.Font = new Font("Segoe UI", 10.5F);
            cboRole.ForeColor = Color.White;
            cboRole.HoverState.BorderColor = Color.FromArgb(120, 120, 130);
            cboRole.ItemHeight = 30;
            cboRole.Location = new Point(40, 312);
            cboRole.Name = "cboRole";
            cboRole.ShadowDecoration.CustomizableEdges = customizableEdges10;
            cboRole.Size = new Size(365, 36);
            cboRole.TabIndex = 5;
            // 
            // txtPassword
            // 
            txtPassword.BorderColor = Color.FromArgb(63, 63, 70);
            txtPassword.BorderRadius = 10;
            txtPassword.CustomizableEdges = customizableEdges11;
            txtPassword.DefaultText = "";
            txtPassword.DisabledState.BorderColor = Color.FromArgb(63, 63, 70);
            txtPassword.DisabledState.FillColor = Color.FromArgb(45, 45, 48);
            txtPassword.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            txtPassword.DisabledState.PlaceholderForeColor = Color.FromArgb(125, 137, 149);
            txtPassword.FillColor = Color.FromArgb(30, 30, 33);
            txtPassword.FocusedState.BorderColor = Color.FromArgb(31, 138, 154);
            txtPassword.Font = new Font("Segoe UI", 10.5F);
            txtPassword.ForeColor = Color.White;
            txtPassword.HoverState.BorderColor = Color.FromArgb(120, 120, 130);
            txtPassword.Location = new Point(40, 366);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '●';
            txtPassword.PlaceholderForeColor = Color.FromArgb(110, 110, 120);
            txtPassword.PlaceholderText = "Mật khẩu đăng nhập";
            txtPassword.SelectedText = "";
            txtPassword.ShadowDecoration.CustomizableEdges = customizableEdges12;
            txtPassword.Size = new Size(365, 46);
            txtPassword.TabIndex = 6;
            txtPassword.UseSystemPasswordChar = true;
            // 
            // btnSave
            // 
            btnSave.BorderRadius = 10;
            btnSave.Cursor = Cursors.Hand;
            btnSave.CustomizableEdges = customizableEdges13;
            btnSave.DisabledState.BorderColor = Color.DarkGray;
            btnSave.DisabledState.CustomBorderColor = Color.DarkGray;
            btnSave.DisabledState.FillColor = Color.FromArgb(80, 80, 80);
            btnSave.DisabledState.ForeColor = Color.FromArgb(190, 190, 190);
            btnSave.FillColor = Color.FromArgb(31, 138, 154);
            btnSave.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnSave.ForeColor = Color.White;
            btnSave.HoverState.FillColor = Color.FromArgb(45, 158, 174);
            btnSave.Location = new Point(80, 444);
            btnSave.Name = "btnSave";
            btnSave.ShadowDecoration.CustomizableEdges = customizableEdges14;
            btnSave.Size = new Size(130, 46);
            btnSave.TabIndex = 7;
            btnSave.Text = "Lưu";
            btnSave.Click += BtnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.BorderColor = Color.FromArgb(180, 60, 60);
            btnCancel.BorderRadius = 10;
            btnCancel.BorderThickness = 1;
            btnCancel.CausesValidation = false;
            btnCancel.Cursor = Cursors.Hand;
            btnCancel.CustomizableEdges = customizableEdges15;
            btnCancel.FillColor = Color.Transparent;
            btnCancel.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnCancel.ForeColor = Color.FromArgb(220, 80, 80);
            btnCancel.HoverState.FillColor = Color.FromArgb(180, 60, 60);
            btnCancel.HoverState.ForeColor = Color.White;
            btnCancel.Location = new Point(235, 444);
            btnCancel.Name = "btnCancel";
            btnCancel.ShadowDecoration.CustomizableEdges = customizableEdges16;
            btnCancel.Size = new Size(130, 46);
            btnCancel.TabIndex = 8;
            btnCancel.Text = "Hủy";
            btnCancel.Click += BtnCancel_Click;
            // 
            // shadow
            // 
            shadow.TargetForm = this;
            // 
            // AddEmployee
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(24, 24, 27);
            ClientSize = new Size(480, 560);
            Controls.Add(panel1);
            Font = new Font("Segoe UI", 10F);
            FormBorderStyle = FormBorderStyle.None;
            Name = "AddEmployee";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Thêm nhân viên";
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Guna2Panel panel1;
        private Label textBox1;
        private Guna2TextBox txtFullName;
        private Guna2TextBox txtEmail;
        private Guna2TextBox txtPhone;
        private Guna2DateTimePicker dtpHireDate;
        private Guna2ComboBox cboRole;
        private Guna2TextBox txtPassword;
        private Guna2Button btnSave;
        private Guna2Button btnCancel;
        private Guna2ShadowForm shadow;
    }
}
