using System.Drawing;
using System.Windows.Forms;

namespace GUI
{
    partial class EmployeeDetail
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
            txtRole = new TextBox();
            lblStatus = new Label();
            txtStatus = new TextBox();
            btnClose = new Button();
            BtnRemove = new Button();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(83, 22);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(265, 30);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "THÔNG TIN NHÂN VIÊN";
            // 
            // lblEmpId
            // 
            lblEmpId.AutoSize = true;
            lblEmpId.Font = new Font("Segoe UI", 10F);
            lblEmpId.ForeColor = Color.LightGray;
            lblEmpId.Location = new Point(30, 80);
            lblEmpId.Name = "lblEmpId";
            lblEmpId.Size = new Size(96, 19);
            lblEmpId.TabIndex = 1;
            lblEmpId.Text = "Mã nhân viên:";
            // 
            // txtEmpId
            // 
            txtEmpId.BackColor = Color.FromArgb(45, 45, 48);
            txtEmpId.BorderStyle = BorderStyle.FixedSingle;
            txtEmpId.Font = new Font("Segoe UI", 11F);
            txtEmpId.ForeColor = Color.White;
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
            lblFullName.Size = new Size(72, 19);
            lblFullName.TabIndex = 3;
            lblFullName.Text = "Họ và tên:";
            // 
            // txtFullName
            // 
            txtFullName.BackColor = Color.FromArgb(45, 45, 48);
            txtFullName.BorderStyle = BorderStyle.FixedSingle;
            txtFullName.Font = new Font("Segoe UI", 11F);
            txtFullName.ForeColor = Color.White;
            txtFullName.Location = new Point(34, 162);
            txtFullName.Name = "txtFullName";
            txtFullName.ReadOnly = true;
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
            lblPhone.Size = new Size(92, 19);
            lblPhone.TabIndex = 5;
            lblPhone.Text = "Số điện thoại:";
            // 
            // txtPhone
            // 
            txtPhone.BackColor = Color.FromArgb(45, 45, 48);
            txtPhone.BorderStyle = BorderStyle.FixedSingle;
            txtPhone.Font = new Font("Segoe UI", 11F);
            txtPhone.ForeColor = Color.White;
            txtPhone.Location = new Point(34, 222);
            txtPhone.Name = "txtPhone";
            txtPhone.ReadOnly = true;
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
            lblRole.Size = new Size(62, 19);
            lblRole.TabIndex = 7;
            lblRole.Text = "Chức vụ:";
            // 
            // txtRole
            // 
            txtRole.BackColor = Color.FromArgb(45, 45, 48);
            txtRole.BorderStyle = BorderStyle.FixedSingle;
            txtRole.Font = new Font("Segoe UI", 11F);
            txtRole.ForeColor = Color.White;
            txtRole.Location = new Point(34, 282);
            txtRole.Name = "txtRole";
            txtRole.ReadOnly = true;
            txtRole.Size = new Size(160, 27);
            txtRole.TabIndex = 8;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Font = new Font("Segoe UI", 10F);
            lblStatus.ForeColor = Color.LightGray;
            lblStatus.Location = new Point(220, 260);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(73, 19);
            lblStatus.TabIndex = 9;
            lblStatus.Text = "Trạng thái:";
            // 
            // txtStatus
            // 
            txtStatus.BackColor = Color.FromArgb(45, 45, 48);
            txtStatus.BorderStyle = BorderStyle.FixedSingle;
            txtStatus.Font = new Font("Segoe UI", 11F);
            txtStatus.ForeColor = Color.White;
            txtStatus.Location = new Point(224, 282);
            txtStatus.Name = "txtStatus";
            txtStatus.ReadOnly = true;
            txtStatus.Size = new Size(160, 27);
            txtStatus.TabIndex = 10;
            // 
            // btnClose
            // 
            btnClose.BackColor = Color.FromArgb(60, 60, 60);
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnClose.ForeColor = Color.White;
            btnClose.Location = new Point(234, 342);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(150, 40);
            btnClose.TabIndex = 11;
            btnClose.Text = "ĐÓNG";
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += btnClose_Click;
            // 
            // BtnRemove
            // 
            BtnRemove.BackColor = Color.FromArgb(60, 60, 60);
            BtnRemove.FlatAppearance.BorderSize = 0;
            BtnRemove.FlatStyle = FlatStyle.Flat;
            BtnRemove.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            BtnRemove.ForeColor = Color.White;
            BtnRemove.Location = new Point(34, 342);
            BtnRemove.Name = "BtnRemove";
            BtnRemove.Size = new Size(150, 40);
            BtnRemove.TabIndex = 12;
            BtnRemove.Text = "XÓA";
            BtnRemove.UseVisualStyleBackColor = false;
            BtnRemove.Click += BtnRemove_Click;
            // 
            // InformationStaff
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(25, 25, 25);
            ClientSize = new Size(420, 420);
            Controls.Add(BtnRemove);
            Controls.Add(btnClose);
            Controls.Add(txtStatus);
            Controls.Add(lblStatus);
            Controls.Add(txtRole);
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
            Name = "InformationStaff";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Thông tin nhân viên";
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
        private System.Windows.Forms.TextBox txtRole;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.TextBox txtStatus;
        private System.Windows.Forms.Button btnClose;
        private Button BtnRemove;
    }
}