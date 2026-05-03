using System.Drawing;
using System.Windows.Forms;

namespace GUI
{
    partial class FoodDetail
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
            lblFoodId = new Label();
            txtFoodId = new TextBox();
            lblFoodName = new Label();
            txtFoodName = new TextBox();
            lblPrice = new Label();
            txtPrice = new TextBox();
            lblCategory = new Label();
            txtCategory = new TextBox();
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
            lblTitle.Location = new Point(95, 22);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(235, 30);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "THÔNG TIN MÓN ĂN";
            // 
            // lblFoodId
            // 
            lblFoodId.AutoSize = true;
            lblFoodId.Font = new Font("Segoe UI", 10F);
            lblFoodId.ForeColor = Color.LightGray;
            lblFoodId.Location = new Point(30, 80);
            lblFoodId.Name = "lblFoodId";
            lblFoodId.Size = new Size(83, 19);
            lblFoodId.TabIndex = 1;
            lblFoodId.Text = "Mã món ăn:";
            // 
            // txtFoodId
            // 
            txtFoodId.BackColor = Color.FromArgb(45, 45, 48);
            txtFoodId.BorderStyle = BorderStyle.FixedSingle;
            txtFoodId.Font = new Font("Segoe UI", 11F);
            txtFoodId.ForeColor = Color.White;
            txtFoodId.Location = new Point(34, 102);
            txtFoodId.Name = "txtFoodId";
            txtFoodId.ReadOnly = true;
            txtFoodId.Size = new Size(350, 27);
            txtFoodId.TabIndex = 2;
            // 
            // lblFoodName
            // 
            lblFoodName.AutoSize = true;
            lblFoodName.Font = new Font("Segoe UI", 10F);
            lblFoodName.ForeColor = Color.LightGray;
            lblFoodName.Location = new Point(30, 140);
            lblFoodName.Name = "lblFoodName";
            lblFoodName.Size = new Size(65, 19);
            lblFoodName.TabIndex = 3;
            lblFoodName.Text = "Tên món:";
            // 
            // txtFoodName
            // 
            txtFoodName.BackColor = Color.FromArgb(45, 45, 48);
            txtFoodName.BorderStyle = BorderStyle.FixedSingle;
            txtFoodName.Font = new Font("Segoe UI", 11F);
            txtFoodName.ForeColor = Color.White;
            txtFoodName.Location = new Point(34, 162);
            txtFoodName.Name = "txtFoodName";
            txtFoodName.ReadOnly = true;
            txtFoodName.Size = new Size(350, 27);
            txtFoodName.TabIndex = 4;
            // 
            // lblPrice
            // 
            lblPrice.AutoSize = true;
            lblPrice.Font = new Font("Segoe UI", 10F);
            lblPrice.ForeColor = Color.LightGray;
            lblPrice.Location = new Point(30, 200);
            lblPrice.Name = "lblPrice";
            lblPrice.Size = new Size(59, 19);
            lblPrice.TabIndex = 5;
            lblPrice.Text = "Giá bán:";
            // 
            // txtPrice
            // 
            txtPrice.BackColor = Color.FromArgb(45, 45, 48);
            txtPrice.BorderStyle = BorderStyle.FixedSingle;
            txtPrice.Font = new Font("Segoe UI", 11F);
            txtPrice.ForeColor = Color.White;
            txtPrice.Location = new Point(34, 222);
            txtPrice.Name = "txtPrice";
            txtPrice.ReadOnly = true;
            txtPrice.Size = new Size(350, 27);
            txtPrice.TabIndex = 6;
            // 
            // lblCategory
            // 
            lblCategory.AutoSize = true;
            lblCategory.Font = new Font("Segoe UI", 10F);
            lblCategory.ForeColor = Color.LightGray;
            lblCategory.Location = new Point(30, 260);
            lblCategory.Name = "lblCategory";
            lblCategory.Size = new Size(69, 19);
            lblCategory.TabIndex = 7;
            lblCategory.Text = "Loại món:";
            // 
            // txtCategory
            // 
            txtCategory.BackColor = Color.FromArgb(45, 45, 48);
            txtCategory.BorderStyle = BorderStyle.FixedSingle;
            txtCategory.Font = new Font("Segoe UI", 11F);
            txtCategory.ForeColor = Color.White;
            txtCategory.Location = new Point(34, 282);
            txtCategory.Name = "txtCategory";
            txtCategory.ReadOnly = true;
            txtCategory.Size = new Size(160, 27);
            txtCategory.TabIndex = 8;
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
            BtnRemove.BackColor = Color.FromArgb(220, 53, 69);
            BtnRemove.FlatAppearance.BorderSize = 0;
            BtnRemove.FlatStyle = FlatStyle.Flat;
            BtnRemove.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            BtnRemove.ForeColor = Color.White;
            BtnRemove.Location = new Point(34, 342);
            BtnRemove.Name = "BtnRemove";
            BtnRemove.Size = new Size(150, 40);
            BtnRemove.TabIndex = 12;
            BtnRemove.Text = "XÓA MÓN";
            BtnRemove.UseVisualStyleBackColor = false;
            BtnRemove.Click += BtnRemove_Click;
            // 
            // FoodDetail
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(25, 25, 25);
            ClientSize = new Size(420, 420);
            Controls.Add(BtnRemove);
            Controls.Add(btnClose);
            Controls.Add(txtStatus);
            Controls.Add(lblStatus);
            Controls.Add(txtCategory);
            Controls.Add(lblCategory);
            Controls.Add(txtPrice);
            Controls.Add(lblPrice);
            Controls.Add(txtFoodName);
            Controls.Add(lblFoodName);
            Controls.Add(txtFoodId);
            Controls.Add(lblFoodId);
            Controls.Add(lblTitle);
            FormBorderStyle = FormBorderStyle.None;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FoodDetail";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Thông tin món ăn";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblFoodId;
        private System.Windows.Forms.TextBox txtFoodId;
        private System.Windows.Forms.Label lblFoodName;
        private System.Windows.Forms.TextBox txtFoodName;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.TextBox txtCategory;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.TextBox txtStatus;
        private System.Windows.Forms.Button btnClose;
        private Button BtnRemove;
    }
}