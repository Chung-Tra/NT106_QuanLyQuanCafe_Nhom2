using System.Drawing;
using System.Windows.Forms;

namespace GUI
{
    partial class StockTransaction
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            lblTitle = new Label();
            lblItem = new Label();
            cmbItem = new ComboBox();
            lblQuantity = new Label();
            nudQuantity = new NumericUpDown();
            lblUnit = new Label();
            cmbUnit = new ComboBox();
            lblNote = new Label();
            txtNote = new TextBox();
            btnConfirm = new Button();
            btnCancel = new Button();
            ((System.ComponentModel.ISupportInitialize)nudQuantity).BeginInit();
            SuspendLayout();
            //
            // lblTitle
            //
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(25, 20);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(200, 25);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Nhập kho nguyên liệu";
            //
            // lblItem
            //
            lblItem.AutoSize = true;
            lblItem.Font = new Font("Segoe UI", 10F);
            lblItem.ForeColor = Color.Gray;
            lblItem.Location = new Point(25, 65);
            lblItem.Name = "lblItem";
            lblItem.Size = new Size(85, 19);
            lblItem.TabIndex = 1;
            lblItem.Text = "Nguyên liệu:";
            //
            // cmbItem
            //
            cmbItem.BackColor = Color.FromArgb(60, 60, 65);
            cmbItem.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbItem.FlatStyle = FlatStyle.Flat;
            cmbItem.Font = new Font("Segoe UI", 11F);
            cmbItem.ForeColor = Color.White;
            cmbItem.Location = new Point(25, 90);
            cmbItem.Name = "cmbItem";
            cmbItem.Size = new Size(340, 28);
            cmbItem.TabIndex = 2;
            //
            // lblQuantity
            //
            lblQuantity.AutoSize = true;
            lblQuantity.Font = new Font("Segoe UI", 10F);
            lblQuantity.ForeColor = Color.Gray;
            lblQuantity.Location = new Point(25, 130);
            lblQuantity.Name = "lblQuantity";
            lblQuantity.Size = new Size(70, 19);
            lblQuantity.TabIndex = 3;
            lblQuantity.Text = "Số lượng:";
            //
            // nudQuantity
            //
            nudQuantity.BackColor = Color.FromArgb(60, 60, 65);
            nudQuantity.DecimalPlaces = 1;
            nudQuantity.Font = new Font("Segoe UI", 11F);
            nudQuantity.ForeColor = Color.White;
            nudQuantity.Location = new Point(25, 155);
            nudQuantity.Maximum = 99999;
            nudQuantity.Name = "nudQuantity";
            nudQuantity.Size = new Size(160, 27);
            nudQuantity.TabIndex = 4;
            nudQuantity.Value = 1;
            //
            // lblUnit
            //
            lblUnit.AutoSize = true;
            lblUnit.Font = new Font("Segoe UI", 10F);
            lblUnit.ForeColor = Color.Gray;
            lblUnit.Location = new Point(205, 130);
            lblUnit.Name = "lblUnit";
            lblUnit.Size = new Size(55, 19);
            lblUnit.TabIndex = 5;
            lblUnit.Text = "Đơn vị:";
            //
            // cmbUnit
            //
            cmbUnit.BackColor = Color.FromArgb(60, 60, 65);
            cmbUnit.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbUnit.FlatStyle = FlatStyle.Flat;
            cmbUnit.Font = new Font("Segoe UI", 11F);
            cmbUnit.ForeColor = Color.White;
            cmbUnit.Location = new Point(205, 155);
            cmbUnit.Name = "cmbUnit";
            cmbUnit.Size = new Size(160, 28);
            cmbUnit.TabIndex = 6;
            //
            // lblNote
            //
            lblNote.AutoSize = true;
            lblNote.Font = new Font("Segoe UI", 10F);
            lblNote.ForeColor = Color.Gray;
            lblNote.Location = new Point(25, 195);
            lblNote.Name = "lblNote";
            lblNote.Size = new Size(55, 19);
            lblNote.TabIndex = 7;
            lblNote.Text = "Ghi chú:";
            //
            // txtNote
            //
            txtNote.BackColor = Color.FromArgb(60, 60, 65);
            txtNote.BorderStyle = BorderStyle.FixedSingle;
            txtNote.Font = new Font("Segoe UI", 10F);
            txtNote.ForeColor = Color.White;
            txtNote.Location = new Point(25, 220);
            txtNote.Multiline = true;
            txtNote.Name = "txtNote";
            txtNote.Size = new Size(340, 60);
            txtNote.TabIndex = 8;
            //
            // btnConfirm
            //
            btnConfirm.BackColor = Color.MediumSeaGreen;
            btnConfirm.Cursor = Cursors.Hand;
            btnConfirm.FlatAppearance.BorderSize = 0;
            btnConfirm.FlatStyle = FlatStyle.Flat;
            btnConfirm.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnConfirm.ForeColor = Color.White;
            btnConfirm.Location = new Point(25, 300);
            btnConfirm.Name = "btnConfirm";
            btnConfirm.Size = new Size(165, 40);
            btnConfirm.TabIndex = 9;
            btnConfirm.Text = "Xác nhận";
            btnConfirm.UseVisualStyleBackColor = false;
            btnConfirm.Click += btnConfirm_Click;
            //
            // btnCancel
            //
            btnCancel.BackColor = Color.FromArgb(70, 70, 75);
            btnCancel.Cursor = Cursors.Hand;
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnCancel.ForeColor = Color.White;
            btnCancel.Location = new Point(200, 300);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(165, 40);
            btnCancel.TabIndex = 10;
            btnCancel.Text = "Hủy";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            //
            // StockTransaction
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(45, 45, 48);
            ClientSize = new Size(390, 360);
            Controls.Add(btnCancel);
            Controls.Add(btnConfirm);
            Controls.Add(txtNote);
            Controls.Add(lblNote);
            Controls.Add(cmbUnit);
            Controls.Add(lblUnit);
            Controls.Add(nudQuantity);
            Controls.Add(lblQuantity);
            Controls.Add(cmbItem);
            Controls.Add(lblItem);
            Controls.Add(lblTitle);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "StockTransaction";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Giao dịch kho";
            ((System.ComponentModel.ISupportInitialize)nudQuantity).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private Label lblItem;
        private ComboBox cmbItem;
        private Label lblQuantity;
        private NumericUpDown nudQuantity;
        private Label lblUnit;
        private ComboBox cmbUnit;
        private Label lblNote;
        private TextBox txtNote;
        private Button btnConfirm;
        private Button btnCancel;
    }
}
