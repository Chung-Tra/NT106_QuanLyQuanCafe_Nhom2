using System.Drawing;
using System.Windows.Forms;

namespace GUI
{
    partial class FoodForm
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
            btnAdd = new Button();
            txtMoTa = new TextBox();
            txtTenMon = new TextBox();
            txtGia = new TextBox();
            bttnClose = new Button();
            cmLoai = new ComboBox();
            lblTitle = new Label();
            SuspendLayout();
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.MediumSeaGreen;
            btnAdd.Cursor = Cursors.Hand;
            btnAdd.FlatAppearance.BorderSize = 0;
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnAdd.ForeColor = Color.White;
            btnAdd.Location = new Point(49, 276);
            btnAdd.Margin = new Padding(3, 2, 3, 2);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(105, 30);
            btnAdd.TabIndex = 0;
            btnAdd.Text = "Thêm";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += BtnAdd_Click;
            // 
            // txtMoTa
            // 
            txtMoTa.BackColor = Color.FromArgb(30, 30, 30);
            txtMoTa.BorderStyle = BorderStyle.FixedSingle;
            txtMoTa.Font = new Font("Segoe UI", 11F);
            txtMoTa.ForeColor = Color.White;
            txtMoTa.Location = new Point(49, 208);
            txtMoTa.Margin = new Padding(3, 2, 3, 2);
            txtMoTa.Multiline = true;
            txtMoTa.Name = "txtMoTa";
            txtMoTa.PlaceholderText = " Mô tả món ăn...";
            txtMoTa.ScrollBars = ScrollBars.Vertical;
            txtMoTa.Size = new Size(228, 56);
            txtMoTa.TabIndex = 2;
            // 
            // txtTenMon
            // 
            txtTenMon.BackColor = Color.FromArgb(30, 30, 30);
            txtTenMon.BorderStyle = BorderStyle.FixedSingle;
            txtTenMon.Font = new Font("Segoe UI", 11F);
            txtTenMon.ForeColor = Color.White;
            txtTenMon.AcceptsReturn = false;
            txtTenMon.Location = new Point(49, 96);
            txtTenMon.Margin = new Padding(3, 2, 3, 2);
            txtTenMon.Multiline = true;
            txtTenMon.Name = "txtTenMon";
            txtTenMon.PlaceholderText = " Tên món";
            txtTenMon.ScrollBars = ScrollBars.None;
            txtTenMon.Size = new Size(228, 32);
            txtTenMon.TabIndex = 4;
            txtTenMon.WordWrap = true;
            // 
            // txtGia
            // 
            txtGia.BackColor = Color.FromArgb(30, 30, 30);
            txtGia.BorderStyle = BorderStyle.FixedSingle;
            txtGia.Font = new Font("Segoe UI", 11F);
            txtGia.ForeColor = Color.White;
            txtGia.Location = new Point(49, 133);
            txtGia.Margin = new Padding(3, 2, 3, 2);
            txtGia.Name = "txtGia";
            txtGia.PlaceholderText = " Giá (VNĐ)";
            txtGia.Size = new Size(228, 27);
            txtGia.TabIndex = 5;
            // 
            // bttnClose
            // 
            bttnClose.BackColor = Color.IndianRed;
            bttnClose.Cursor = Cursors.Hand;
            bttnClose.FlatAppearance.BorderSize = 0;
            bttnClose.FlatStyle = FlatStyle.Flat;
            bttnClose.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            bttnClose.ForeColor = Color.White;
            bttnClose.Location = new Point(172, 276);
            bttnClose.Margin = new Padding(3, 2, 3, 2);
            bttnClose.Name = "bttnClose";
            bttnClose.Size = new Size(105, 30);
            bttnClose.TabIndex = 6;
            bttnClose.Text = "Hủy bỏ";
            bttnClose.UseVisualStyleBackColor = false;
            bttnClose.Click += BtnClose_Click;
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
            cmLoai.Location = new Point(49, 170);
            cmLoai.Margin = new Padding(3, 2, 3, 2);
            cmLoai.Name = "cmLoai";
            cmLoai.Size = new Size(228, 28);
            cmLoai.TabIndex = 7;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitle.ForeColor = Color.Goldenrod;
            lblTitle.Location = new Point(66, 41);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(188, 30);
            lblTitle.TabIndex = 8;
            lblTitle.Text = "THÊM MÓN MỚI";
            // 
            // AddMonUong
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(45, 45, 48);
            ClientSize = new Size(323, 375);
            Controls.Add(lblTitle);
            Controls.Add(cmLoai);
            Controls.Add(bttnClose);
            Controls.Add(txtGia);
            Controls.Add(txtTenMon);
            Controls.Add(txtMoTa);
            Controls.Add(btnAdd);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 2, 3, 2);
            Name = "AddMonUong";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Thêm Món Mới";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TextBox txtMoTa;
        private System.Windows.Forms.TextBox txtTenMon;
        private System.Windows.Forms.TextBox txtGia;
        private System.Windows.Forms.Button bttnClose;
        private System.Windows.Forms.ComboBox cmLoai;
        private System.Windows.Forms.Label lblTitle;
    }
}