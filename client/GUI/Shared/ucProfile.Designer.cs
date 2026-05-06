namespace GUI
{
    partial class ucProfile
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pnlLeft = new Panel();
            lblUserRole = new Label();
            lblUserName = new Label();
            picAvatar = new PictureBox();
            pnlRight = new Panel();
            btnUpdateInfo = new Button();
            grpSecurity = new GroupBox();
            btnChangePass = new Button();
            txtNewPass = new TextBox();
            lblNewPass = new Label();
            txtOldPass = new TextBox();
            lblOldPass = new Label();
            grpPersonalInfo = new GroupBox();
            txtAddress = new TextBox();
            lblAddress = new Label();
            txtPhone = new TextBox();
            lblPhone = new Label();
            txtEmail = new TextBox();
            lblEmail = new Label();
            txtEmployeeId = new TextBox();
            lblEmployeeId = new Label();
            pnlLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picAvatar).BeginInit();
            pnlRight.SuspendLayout();
            grpSecurity.SuspendLayout();
            grpPersonalInfo.SuspendLayout();
            SuspendLayout();
            // 
            // pnlLeft
            // 
            btnChangeAvatar = new Button();
            pnlLeft.BackColor = Color.FromArgb(30, 30, 30);
            pnlLeft.Controls.Add(btnChangeAvatar);
            pnlLeft.Controls.Add(lblUserRole);
            pnlLeft.Controls.Add(lblUserName);
            pnlLeft.Controls.Add(picAvatar);
            pnlLeft.Location = new Point(20, 20);
            pnlLeft.Name = "pnlLeft";
            pnlLeft.Size = new Size(250, 490);
            pnlLeft.TabIndex = 0;
            // 
            // lblUserRole
            // 
            lblUserRole.Font = new Font("Segoe UI", 10F);
            lblUserRole.ForeColor = Color.Gray;
            lblUserRole.Location = new Point(0, 240);
            lblUserRole.Name = "lblUserRole";
            lblUserRole.Size = new Size(250, 23);
            lblUserRole.TabIndex = 2;
            lblUserRole.Text = "Barista / Staff";
            lblUserRole.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblUserName
            // 
            lblUserName.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblUserName.ForeColor = Color.White;
            lblUserName.Location = new Point(0, 205);
            lblUserName.Name = "lblUserName";
            lblUserName.Size = new Size(250, 30);
            lblUserName.TabIndex = 1;
            lblUserName.Text = "NGUYỄN PHA CHẾ";
            lblUserName.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // picAvatar
            // 
            picAvatar.BackColor = Color.FromArgb(45, 45, 48);
            picAvatar.Location = new Point(50, 40);
            picAvatar.Name = "picAvatar";
            picAvatar.Size = new Size(150, 150);
            picAvatar.SizeMode = PictureBoxSizeMode.Zoom;
            picAvatar.TabIndex = 0;
            picAvatar.TabStop = false;
            //
            // btnChangeAvatar
            //
            btnChangeAvatar.BackColor = Color.FromArgb(60, 60, 65);
            btnChangeAvatar.Cursor = Cursors.Hand;
            btnChangeAvatar.FlatAppearance.BorderSize = 0;
            btnChangeAvatar.FlatStyle = FlatStyle.Flat;
            btnChangeAvatar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnChangeAvatar.ForeColor = Color.White;
            btnChangeAvatar.Location = new Point(60, 270);
            btnChangeAvatar.Name = "btnChangeAvatar";
            btnChangeAvatar.Size = new Size(130, 30);
            btnChangeAvatar.Text = "Đổi ảnh đại diện";
            //
            // pnlRight
            // 
            pnlRight.BackColor = Color.FromArgb(30, 30, 30);
            pnlRight.Controls.Add(btnUpdateInfo);
            pnlRight.Controls.Add(grpSecurity);
            pnlRight.Controls.Add(grpPersonalInfo);
            pnlRight.Location = new Point(290, 20);
            pnlRight.Name = "pnlRight";
            pnlRight.Size = new Size(494, 490);
            pnlRight.TabIndex = 1;
            // 
            // btnUpdateInfo
            // 
            btnUpdateInfo.BackColor = Color.MediumSeaGreen;
            btnUpdateInfo.FlatAppearance.BorderSize = 0;
            btnUpdateInfo.FlatStyle = FlatStyle.Flat;
            btnUpdateInfo.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnUpdateInfo.ForeColor = Color.White;
            btnUpdateInfo.Location = new Point(320, 430);
            btnUpdateInfo.Name = "btnUpdateInfo";
            btnUpdateInfo.Size = new Size(150, 40);
            btnUpdateInfo.TabIndex = 2;
            btnUpdateInfo.Text = "LƯU THAY ĐỔI";
            btnUpdateInfo.UseVisualStyleBackColor = false;
            // 
            // grpSecurity
            // 
            grpSecurity.Controls.Add(btnChangePass);
            grpSecurity.Controls.Add(txtNewPass);
            grpSecurity.Controls.Add(lblNewPass);
            grpSecurity.Controls.Add(txtOldPass);
            grpSecurity.Controls.Add(lblOldPass);
            grpSecurity.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            grpSecurity.ForeColor = Color.IndianRed;
            grpSecurity.Location = new Point(20, 260);
            grpSecurity.Name = "grpSecurity";
            grpSecurity.Size = new Size(450, 150);
            grpSecurity.TabIndex = 1;
            grpSecurity.TabStop = false;
            grpSecurity.Text = "Đổi mật khẩu";
            grpSecurity.Enter += grpSecurity_Enter;
            // 
            // btnChangePass
            // 
            btnChangePass.BackColor = Color.FromArgb(45, 45, 48);
            btnChangePass.FlatAppearance.BorderSize = 0;
            btnChangePass.FlatStyle = FlatStyle.Flat;
            btnChangePass.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnChangePass.ForeColor = Color.White;
            btnChangePass.Location = new Point(300, 100);
            btnChangePass.Name = "btnChangePass";
            btnChangePass.Size = new Size(130, 30);
            btnChangePass.TabIndex = 4;
            btnChangePass.Text = "Đổi mật khẩu";
            btnChangePass.UseVisualStyleBackColor = false;
            // 
            // txtNewPass
            // 
            txtNewPass.BackColor = Color.FromArgb(45, 45, 48);
            txtNewPass.BorderStyle = BorderStyle.None;
            txtNewPass.Font = new Font("Segoe UI", 10F);
            txtNewPass.ForeColor = Color.White;
            txtNewPass.Location = new Point(150, 70);
            txtNewPass.Name = "txtNewPass";
            txtNewPass.PasswordChar = '●';
            txtNewPass.Size = new Size(280, 18);
            txtNewPass.TabIndex = 3;
            // 
            // lblNewPass
            // 
            lblNewPass.AutoSize = true;
            lblNewPass.Font = new Font("Segoe UI", 9F);
            lblNewPass.ForeColor = Color.Gray;
            lblNewPass.Location = new Point(20, 70);
            lblNewPass.Name = "lblNewPass";
            lblNewPass.Size = new Size(84, 15);
            lblNewPass.TabIndex = 2;
            lblNewPass.Text = "Mật khẩu mới:";
            // 
            // txtOldPass
            // 
            txtOldPass.BackColor = Color.FromArgb(45, 45, 48);
            txtOldPass.BorderStyle = BorderStyle.None;
            txtOldPass.Font = new Font("Segoe UI", 10F);
            txtOldPass.ForeColor = Color.White;
            txtOldPass.Location = new Point(150, 40);
            txtOldPass.Name = "txtOldPass";
            txtOldPass.PasswordChar = '●';
            txtOldPass.Size = new Size(280, 18);
            txtOldPass.TabIndex = 1;
            // 
            // lblOldPass
            // 
            lblOldPass.AutoSize = true;
            lblOldPass.Font = new Font("Segoe UI", 9F);
            lblOldPass.ForeColor = Color.Gray;
            lblOldPass.Location = new Point(20, 40);
            lblOldPass.Name = "lblOldPass";
            lblOldPass.Size = new Size(76, 15);
            lblOldPass.TabIndex = 0;
            lblOldPass.Text = "Mật khẩu cũ:";
            // 
            // grpPersonalInfo
            // 
            grpPersonalInfo.Controls.Add(txtAddress);
            grpPersonalInfo.Controls.Add(lblAddress);
            grpPersonalInfo.Controls.Add(txtPhone);
            grpPersonalInfo.Controls.Add(lblPhone);
            grpPersonalInfo.Controls.Add(txtEmail);
            grpPersonalInfo.Controls.Add(lblEmail);
            grpPersonalInfo.Controls.Add(txtEmployeeId);
            grpPersonalInfo.Controls.Add(lblEmployeeId);
            grpPersonalInfo.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            grpPersonalInfo.ForeColor = Color.MediumSeaGreen;
            grpPersonalInfo.Location = new Point(20, 20);
            grpPersonalInfo.Name = "grpPersonalInfo";
            grpPersonalInfo.Size = new Size(450, 220);
            grpPersonalInfo.TabIndex = 0;
            grpPersonalInfo.TabStop = false;
            grpPersonalInfo.Text = "Thông tin chi tiết";
            // 
            // txtAddress
            // 
            txtAddress.BackColor = Color.FromArgb(45, 45, 48);
            txtAddress.BorderStyle = BorderStyle.None;
            txtAddress.Font = new Font("Segoe UI", 10F);
            txtAddress.ForeColor = Color.White;
            txtAddress.Location = new Point(150, 160);
            txtAddress.Multiline = true;
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(280, 40);
            txtAddress.TabIndex = 7;
            // 
            // lblAddress
            // 
            lblAddress.AutoSize = true;
            lblAddress.Font = new Font("Segoe UI", 9F);
            lblAddress.ForeColor = Color.Gray;
            lblAddress.Location = new Point(20, 160);
            lblAddress.Name = "lblAddress";
            lblAddress.Size = new Size(46, 15);
            lblAddress.TabIndex = 6;
            lblAddress.Text = "Địa chỉ:";
            // 
            // txtPhone
            // 
            txtPhone.BackColor = Color.FromArgb(45, 45, 48);
            txtPhone.BorderStyle = BorderStyle.None;
            txtPhone.Font = new Font("Segoe UI", 10F);
            txtPhone.ForeColor = Color.White;
            txtPhone.Location = new Point(150, 120);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(280, 18);
            txtPhone.TabIndex = 5;
            // 
            // lblPhone
            // 
            lblPhone.AutoSize = true;
            lblPhone.Font = new Font("Segoe UI", 9F);
            lblPhone.ForeColor = Color.Gray;
            lblPhone.Location = new Point(20, 120);
            lblPhone.Name = "lblPhone";
            lblPhone.Size = new Size(79, 15);
            lblPhone.TabIndex = 4;
            lblPhone.Text = "Số điện thoại:";
            // 
            // txtEmail
            // 
            txtEmail.BackColor = Color.FromArgb(45, 45, 48);
            txtEmail.BorderStyle = BorderStyle.None;
            txtEmail.Font = new Font("Segoe UI", 10F);
            txtEmail.ForeColor = Color.White;
            txtEmail.Location = new Point(150, 80);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(280, 18);
            txtEmail.TabIndex = 3;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Font = new Font("Segoe UI", 9F);
            lblEmail.ForeColor = Color.Gray;
            lblEmail.Location = new Point(20, 80);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(39, 15);
            lblEmail.TabIndex = 2;
            lblEmail.Text = "Email:";
            // 
            // txtEmployeeId
            // 
            txtEmployeeId.BackColor = Color.FromArgb(45, 45, 48);
            txtEmployeeId.BorderStyle = BorderStyle.None;
            txtEmployeeId.Enabled = false;
            txtEmployeeId.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            txtEmployeeId.ForeColor = Color.Gray;
            txtEmployeeId.Location = new Point(150, 40);
            txtEmployeeId.Name = "txtEmployeeId";
            txtEmployeeId.Size = new Size(280, 18);
            txtEmployeeId.TabIndex = 1;
            // 
            // lblEmployeeId
            // 
            lblEmployeeId.AutoSize = true;
            lblEmployeeId.Font = new Font("Segoe UI", 9F);
            lblEmployeeId.ForeColor = Color.Gray;
            lblEmployeeId.Location = new Point(20, 40);
            lblEmployeeId.Name = "lblEmployeeId";
            lblEmployeeId.Size = new Size(82, 15);
            lblEmployeeId.TabIndex = 0;
            lblEmployeeId.Text = "Mã nhân viên:";
            // 
            // ucProfile
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(45, 45, 48);
            Controls.Add(pnlRight);
            Controls.Add(pnlLeft);
            Name = "ucProfile";
            Size = new Size(804, 530);
            pnlLeft.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picAvatar).EndInit();
            pnlRight.ResumeLayout(false);
            grpSecurity.ResumeLayout(false);
            grpSecurity.PerformLayout();
            grpPersonalInfo.ResumeLayout(false);
            grpPersonalInfo.PerformLayout();
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlLeft;
        private System.Windows.Forms.PictureBox picAvatar;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Label lblUserRole;
        private System.Windows.Forms.Panel pnlRight;
        private System.Windows.Forms.GroupBox grpPersonalInfo;
        private System.Windows.Forms.Label lblEmployeeId;
        private System.Windows.Forms.TextBox txtEmployeeId;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.GroupBox grpSecurity;
        private System.Windows.Forms.Label lblOldPass;
        private System.Windows.Forms.TextBox txtOldPass;
        private System.Windows.Forms.Label lblNewPass;
        private System.Windows.Forms.TextBox txtNewPass;
        private System.Windows.Forms.Button btnChangePass;
        private System.Windows.Forms.Button btnUpdateInfo;
        private System.Windows.Forms.Button btnChangeAvatar;
    }
}