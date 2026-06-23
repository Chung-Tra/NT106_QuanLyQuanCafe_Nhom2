namespace GUI
{
    partial class FoodEditForm
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
            btnUpdate = new Button();
            txtMoTa = new TextBox();
            txtTenMon = new TextBox();
            txtGia = new TextBox();
            btnCancel = new Button();
            cmLoai = new ComboBox();
            lblTitle = new Label();
            SuspendLayout();
            // 
            // btnUpdate
            // 
            btnUpdate.BackColor = Color.MediumSeaGreen;
            btnUpdate.Cursor = Cursors.Hand;
            btnUpdate.FlatAppearance.BorderSize = 0;
            btnUpdate.FlatStyle = FlatStyle.Flat;
            btnUpdate.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnUpdate.ForeColor = Color.White;
            btnUpdate.Location = new Point(36, 280);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(100, 35);
            btnUpdate.TabIndex = 0;
            btnUpdate.Text = "Cập nhật";
            btnUpdate.UseVisualStyleBackColor = false;
            btnUpdate.Click += BtnUpdate_Click;
            // 
            // txtMoTa
            // 
            txtMoTa.BackColor = Color.FromArgb(30, 30, 30);
            txtMoTa.BorderStyle = BorderStyle.FixedSingle;
            txtMoTa.Font = new Font("Segoe UI", 11F);
            txtMoTa.ForeColor = Color.White;
            txtMoTa.Location = new Point(36, 195);
            txtMoTa.Multiline = true;
            txtMoTa.Name = "txtMoTa";
            txtMoTa.PlaceholderText = " Mô tả món ăn...";
            txtMoTa.ScrollBars = ScrollBars.Vertical;
            txtMoTa.Size = new Size(228, 60);
            txtMoTa.TabIndex = 2;
            // 
            // txtTenMon
            // 
            txtTenMon.BackColor = Color.FromArgb(30, 30, 30);
            txtTenMon.BorderStyle = BorderStyle.FixedSingle;
            txtTenMon.Font = new Font("Segoe UI", 11F);
            txtTenMon.ForeColor = Color.White;
            txtTenMon.Location = new Point(36, 75);
            txtTenMon.Multiline = true;
            txtTenMon.Name = "txtTenMon";
            txtTenMon.PlaceholderText = " Tên món";
            txtTenMon.Size = new Size(228, 32);
            txtTenMon.TabIndex = 4;
            // 
            // txtGia
            // 
            txtGia.BackColor = Color.FromArgb(30, 30, 30);
            txtGia.BorderStyle = BorderStyle.FixedSingle;
            txtGia.Font = new Font("Segoe UI", 11F);
            txtGia.ForeColor = Color.White;
            txtGia.Location = new Point(36, 115);
            txtGia.Name = "txtGia";
            txtGia.PlaceholderText = " Giá (VNĐ)";
            txtGia.Size = new Size(228, 27);
            txtGia.TabIndex = 5;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.IndianRed;
            btnCancel.Cursor = Cursors.Hand;
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnCancel.ForeColor = Color.White;
            btnCancel.Location = new Point(164, 280);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(100, 35);
            btnCancel.TabIndex = 6;
            btnCancel.Text = "Hủy";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += BtnCancel_Click;
            // 
            // cmLoai
            // 
            cmLoai.BackColor = Color.FromArgb(30, 30, 30);
            cmLoai.DropDownStyle = ComboBoxStyle.DropDownList;
            cmLoai.FlatStyle = FlatStyle.Flat;
            cmLoai.Font = new Font("Segoe UI", 11F);
            cmLoai.ForeColor = Color.White;
            cmLoai.FormattingEnabled = true;
            cmLoai.Items.AddRange(new object[] { "Đồ uống", "Đồ ăn", "Khác" });
            cmLoai.Location = new Point(36, 155);
            cmLoai.Name = "cmLoai";
            cmLoai.Size = new Size(228, 28);
            cmLoai.TabIndex = 7;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblTitle.ForeColor = Color.Goldenrod;
            lblTitle.Location = new Point(48, 25);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(206, 25);
            lblTitle.TabIndex = 8;
            lblTitle.Text = "SỬA THÔNG TIN MÓN";
            // 
            // FoodEditForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(45, 45, 48);
            ClientSize = new Size(300, 340);
            Controls.Add(lblTitle);
            Controls.Add(cmLoai);
            Controls.Add(btnCancel);
            Controls.Add(txtGia);
            Controls.Add(txtTenMon);
            Controls.Add(txtMoTa);
            Controls.Add(btnUpdate);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FoodEditForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Sửa Món";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.TextBox txtMoTa;
        private System.Windows.Forms.TextBox txtTenMon;
        private System.Windows.Forms.TextBox txtGia;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ComboBox cmLoai;
        private System.Windows.Forms.Label lblTitle;
    }
}