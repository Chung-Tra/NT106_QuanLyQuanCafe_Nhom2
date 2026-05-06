namespace GUI
{
    partial class EditEmployee
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
            lblTitle = new Label();
            lblEmpId = new Label();
            txtEmpId = new TextBox();
            lblFullName = new Label();
            txtFullName = new TextBox();
            lblPhone = new Label();
            txtPhone = new TextBox();
            lblRole = new Label();
            cboRole = new ComboBox();
            lblStatus = new Label();
            cboStatus = new ComboBox();
            btnSave = new Button();
            btnCancel = new Button();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(120, 23);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(178, 30);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "SỬA NHÂN VIÊN";
            // 
            // lblEmpId
            // 
            lblEmpId.AutoSize = true;
            lblEmpId.Font = new Font("Segoe UI", 10F);
            lblEmpId.ForeColor = Color.LightGray;
            lblEmpId.Location = new Point(30, 80);
            lblEmpId.Name = "lblEmpId";
            lblEmpId.Size = new Size(89, 19);
            lblEmpId.TabIndex = 1;
            lblEmpId.Text = "Mã nhân viên:";
            // 
            // txtEmpId
            // 
            txtEmpId.BackColor = Color.FromArgb(45, 45, 48);
            txtEmpId.BorderStyle = BorderStyle.FixedSingle;
            txtEmpId.Font = new Font("Segoe UI", 11F);
            txtEmpId.ForeColor = Color.Gray;
            txtEmpId.Location = new Point(34, 102);
            txtEmpId.Name = "txtEmpId";
            txtEmpId.ReadOnly = true;
            txtEmpId.Size = new Size(350, 27);
            txtEmpId.TabIndex = 2;
            // 
            // lblFullName
            // 
            lblFullName.AutoSize = true;
            lblFullName.Font = new Font("Segoe UI", 10F);
            lblFullName.ForeColor = Color.LightGray;
            lblFullName.Location = new Point(30, 140);
            lblFullName.Name = "lblFullName";
            lblFullName.Size = new Size(73, 19);
            lblFullName.TabIndex = 3;
            lblFullName.Text = "Họ và tên:";
            // 
            // txtFullName
            // 
            txtFullName.BackColor = Color.FromArgb(30, 30, 30);
            txtFullName.BorderStyle = BorderStyle.FixedSingle;
            txtFullName.Font = new Font("Segoe UI", 11F);
            txtFullName.ForeColor = Color.White;
            txtFullName.Location = new Point(34, 162);
            txtFullName.Name = "txtFullName";
            txtFullName.Size = new Size(350, 27);
            txtFullName.TabIndex = 4;
            // 
            // lblPhone
            // 
            lblPhone.AutoSize = true;
            lblPhone.Font = new Font("Segoe UI", 10F);
            lblPhone.ForeColor = Color.LightGray;
            lblPhone.Location = new Point(30, 200);
            lblPhone.Name = "lblPhone";
            lblPhone.Size = new Size(105, 19);
            lblPhone.TabIndex = 5;
            lblPhone.Text = "Số điện thoại:";
            // 
            // txtPhone
            // 
            txtPhone.BackColor = Color.FromArgb(30, 30, 30);
            txtPhone.BorderStyle = BorderStyle.FixedSingle;
            txtPhone.Font = new Font("Segoe UI", 11F);
            txtPhone.ForeColor = Color.White;
            txtPhone.Location = new Point(34, 222);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(350, 27);
            txtPhone.TabIndex = 6;
            // 
            // lblRole
            // 
            lblRole.AutoSize = true;
            lblRole.Font = new Font("Segoe UI", 10F);
            lblRole.ForeColor = Color.LightGray;
            lblRole.Location = new Point(30, 260);
            lblRole.Name = "lblRole";
            lblRole.Size = new Size(38, 19);
            lblRole.TabIndex = 7;
            lblRole.Text = "Chức vụ:";
            // 
            // cboRole
            // 
            cboRole.BackColor = Color.FromArgb(30, 30, 30);
            cboRole.DropDownStyle = ComboBoxStyle.DropDownList;
            cboRole.FlatStyle = FlatStyle.Flat;
            cboRole.Font = new Font("Segoe UI", 11F);
            cboRole.ForeColor = Color.White;
            cboRole.FormattingEnabled = true;
            cboRole.Location = new Point(34, 282);
            cboRole.Name = "cboRole";
            cboRole.Size = new Size(160, 28);
            cboRole.TabIndex = 8;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Font = new Font("Segoe UI", 10F);
            lblStatus.ForeColor = Color.LightGray;
            lblStatus.Location = new Point(220, 260);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(50, 19);
            lblStatus.TabIndex = 9;
            lblStatus.Text = "Trạng thái:";
            // 
            // cboStatus
            // 
            cboStatus.BackColor = Color.FromArgb(30, 30, 30);
            cboStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cboStatus.FlatStyle = FlatStyle.Flat;
            cboStatus.Font = new Font("Segoe UI", 11F);
            cboStatus.ForeColor = Color.White;
            cboStatus.FormattingEnabled = true;
            cboStatus.Location = new Point(224, 282);
            cboStatus.Name = "cboStatus";
            cboStatus.Size = new Size(160, 28);
            cboStatus.TabIndex = 10;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(46, 204, 113);
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(234, 340);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(150, 40);
            btnSave.TabIndex = 11;
            btnSave.Text = "LƯU THAY ĐỔI";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += BtnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.FromArgb(60, 60, 60);
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnCancel.ForeColor = Color.White;
            btnCancel.Location = new Point(34, 340);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(120, 40);
            btnCancel.TabIndex = 12;
            btnCancel.Text = "HỦY";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += BtnCancel_Click;
            // 
            // EditEmployee
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(25, 25, 25);
            ClientSize = new Size(420, 420);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(cboStatus);
            Controls.Add(lblStatus);
            Controls.Add(cboRole);
            Controls.Add(lblRole);
            Controls.Add(txtPhone);
            Controls.Add(lblPhone);
            Controls.Add(txtFullName);
            Controls.Add(lblFullName);
            Controls.Add(txtEmpId);
            Controls.Add(lblEmpId);
            Controls.Add(lblTitle);
            FormBorderStyle = FormBorderStyle.None;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "EditEmployee";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Sửa nhân viên";
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblEmpId;
        private System.Windows.Forms.TextBox txtEmpId;
        private System.Windows.Forms.Label lblFullName;
        private System.Windows.Forms.TextBox txtFullName;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Label lblRole;
        private System.Windows.Forms.ComboBox cboRole;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ComboBox cboStatus;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
    }
}