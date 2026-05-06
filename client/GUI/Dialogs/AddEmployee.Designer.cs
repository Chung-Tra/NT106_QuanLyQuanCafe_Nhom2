namespace GUI
{
    partial class AddEmployee
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtPassword = new TextBox();
            btnSave = new Button();
            dtpHireDate = new DateTimePicker();
            cboRole = new ComboBox();
            txtPhone = new TextBox();
            txtEmail = new TextBox();
            txtFullName = new TextBox();
            btnCancel = new Button();
            textBox1 = new TextBox();
            panel1 = new Panel();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // txtPassword
            // 
            txtPassword.BackColor = Color.FromArgb(43, 43, 43);
            txtPassword.BorderStyle = BorderStyle.None;
            txtPassword.Font = new Font("Segoe UI", 11F);
            txtPassword.ForeColor = Color.White;
            txtPassword.Location = new Point(40, 330);
            txtPassword.Name = "txtPassword";
            txtPassword.PlaceholderText = "Mật khẩu đăng nhập";
            txtPassword.Size = new Size(365, 20);
            txtPassword.TabIndex = 17;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(46, 204, 113);
            btnSave.Cursor = Cursors.Hand;
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(194, 390);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(79, 45);
            btnSave.TabIndex = 15;
            btnSave.Text = "Lưu";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += BtnSave_Click;
            // 
            // dtpHireDate
            // 
            dtpHireDate.Font = new Font("Segoe UI", 11F);
            dtpHireDate.Format = DateTimePickerFormat.Short;
            dtpHireDate.Location = new Point(40, 230);
            dtpHireDate.Name = "dtpHireDate";
            dtpHireDate.Size = new Size(365, 27);
            dtpHireDate.TabIndex = 14;
            // 
            // cboRole
            // 
            cboRole.BackColor = Color.FromArgb(43, 43, 43);
            cboRole.FlatStyle = FlatStyle.Flat;
            cboRole.Font = new Font("Segoe UI", 11F);
            cboRole.ForeColor = Color.White;
            cboRole.FormattingEnabled = true;
            cboRole.Location = new Point(40, 280);
            cboRole.Name = "cboRole";
            cboRole.Size = new Size(365, 28);
            cboRole.TabIndex = 13;
            // 
            // txtPhone
            // 
            txtPhone.BackColor = Color.FromArgb(43, 43, 43);
            txtPhone.BorderStyle = BorderStyle.None;
            txtPhone.Font = new Font("Segoe UI", 11F);
            txtPhone.ForeColor = Color.White;
            txtPhone.Location = new Point(40, 180);
            txtPhone.Name = "txtPhone";
            txtPhone.PlaceholderText = "Số điện thoại";
            txtPhone.Size = new Size(365, 20);
            txtPhone.TabIndex = 12;
            // 
            // txtEmail
            // 
            txtEmail.BackColor = Color.FromArgb(43, 43, 43);
            txtEmail.BorderStyle = BorderStyle.None;
            txtEmail.Font = new Font("Segoe UI", 11F);
            txtEmail.ForeColor = Color.White;
            txtEmail.Location = new Point(40, 130);
            txtEmail.Name = "txtEmail";
            txtEmail.PlaceholderText = "Email Address";
            txtEmail.Size = new Size(365, 20);
            txtEmail.TabIndex = 11;
            // 
            // txtFullName
            // 
            txtFullName.BackColor = Color.FromArgb(43, 43, 43);
            txtFullName.BorderStyle = BorderStyle.None;
            txtFullName.Font = new Font("Segoe UI", 11F);
            txtFullName.ForeColor = Color.White;
            txtFullName.Location = new Point(40, 80);
            txtFullName.Name = "txtFullName";
            txtFullName.PlaceholderText = "Họ và tên";
            txtFullName.Size = new Size(365, 20);
            txtFullName.TabIndex = 10;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.FromArgb(231, 76, 60);
            btnCancel.Cursor = Cursors.Hand;
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnCancel.ForeColor = Color.White;
            btnCancel.Location = new Point(298, 390);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(107, 45);
            btnCancel.TabIndex = 18;
            btnCancel.Text = "Hủy bỏ";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += BtnCancel_Click;
            // 
            // textBox1
            // 
            textBox1.BackColor = Color.FromArgb(33, 33, 33);
            textBox1.BorderStyle = BorderStyle.None;
            textBox1.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            textBox1.ForeColor = Color.White;
            textBox1.Location = new Point(-3, 16);
            textBox1.Name = "textBox1";
            textBox1.ReadOnly = true;
            textBox1.Size = new Size(448, 29);
            textBox1.TabIndex = 19;
            textBox1.Text = "TẠO ACCOUNT NHÂN VIÊN";
            textBox1.TextAlign = HorizontalAlignment.Center;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(33, 33, 33);
            panel1.Controls.Add(textBox1);
            panel1.Controls.Add(btnCancel);
            panel1.Controls.Add(txtFullName);
            panel1.Controls.Add(txtPassword);
            panel1.Controls.Add(txtEmail);
            panel1.Controls.Add(btnSave);
            panel1.Controls.Add(txtPhone);
            panel1.Controls.Add(dtpHireDate);
            panel1.Controls.Add(cboRole);
            panel1.Location = new Point(12, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(448, 480);
            panel1.TabIndex = 20;
            // 
            // AddEmployee
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(18, 18, 18);
            ClientSize = new Size(474, 503);
            Controls.Add(panel1);
            Font = new Font("Segoe UI", 10.2F);
            FormBorderStyle = FormBorderStyle.None;
            Name = "AddEmployee";
            StartPosition = FormStartPosition.CenterParent;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TextBox txtPassword;
        private Button btnSave;
        private DateTimePicker dtpHireDate;
        private ComboBox cboRole;
        private TextBox txtPhone;
        private TextBox txtEmail;
        private TextBox txtFullName;
        private Button btnCancel;
        private TextBox textBox1;
        private Panel panel1;
    }
}