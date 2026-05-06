using System.Drawing;
using System.Windows.Forms;

namespace GUI
{
    partial class ReplyFeedback
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
            lblCustomer = new Label();
            lblOriginal = new Label();
            txtOriginalContent = new TextBox();
            lblReply = new Label();
            txtReply = new TextBox();
            btnSend = new Button();
            btnCancel = new Button();
            SuspendLayout();
            //
            // lblTitle
            //
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(25, 20);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(230, 25);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Trả lời phản hồi";
            //
            // lblCustomer
            //
            lblCustomer.AutoSize = true;
            lblCustomer.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblCustomer.ForeColor = Color.Orange;
            lblCustomer.Location = new Point(25, 55);
            lblCustomer.Name = "lblCustomer";
            lblCustomer.Size = new Size(200, 19);
            lblCustomer.TabIndex = 1;
            lblCustomer.Text = "Khách hàng: ---";
            //
            // lblOriginal
            //
            lblOriginal.AutoSize = true;
            lblOriginal.Font = new Font("Segoe UI", 10F);
            lblOriginal.ForeColor = Color.Gray;
            lblOriginal.Location = new Point(25, 85);
            lblOriginal.Name = "lblOriginal";
            lblOriginal.Size = new Size(100, 19);
            lblOriginal.TabIndex = 2;
            lblOriginal.Text = "Nội dung gốc:";
            //
            // txtOriginalContent
            //
            txtOriginalContent.BackColor = Color.FromArgb(60, 60, 65);
            txtOriginalContent.BorderStyle = BorderStyle.None;
            txtOriginalContent.Font = new Font("Segoe UI", 10F);
            txtOriginalContent.ForeColor = Color.LightGray;
            txtOriginalContent.Location = new Point(25, 110);
            txtOriginalContent.Multiline = true;
            txtOriginalContent.Name = "txtOriginalContent";
            txtOriginalContent.ReadOnly = true;
            txtOriginalContent.Size = new Size(430, 70);
            txtOriginalContent.TabIndex = 3;
            //
            // lblReply
            //
            lblReply.AutoSize = true;
            lblReply.Font = new Font("Segoe UI", 10F);
            lblReply.ForeColor = Color.Gray;
            lblReply.Location = new Point(25, 195);
            lblReply.Name = "lblReply";
            lblReply.Size = new Size(100, 19);
            lblReply.TabIndex = 4;
            lblReply.Text = "Nội dung trả lời:";
            //
            // txtReply
            //
            txtReply.BackColor = Color.FromArgb(60, 60, 65);
            txtReply.BorderStyle = BorderStyle.FixedSingle;
            txtReply.Font = new Font("Segoe UI", 10F);
            txtReply.ForeColor = Color.White;
            txtReply.Location = new Point(25, 220);
            txtReply.Multiline = true;
            txtReply.Name = "txtReply";
            txtReply.PlaceholderText = "Nhập nội dung trả lời...";
            txtReply.Size = new Size(430, 90);
            txtReply.TabIndex = 5;
            //
            // btnSend
            //
            btnSend.BackColor = Color.SteelBlue;
            btnSend.Cursor = Cursors.Hand;
            btnSend.FlatAppearance.BorderSize = 0;
            btnSend.FlatStyle = FlatStyle.Flat;
            btnSend.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnSend.ForeColor = Color.White;
            btnSend.Location = new Point(25, 330);
            btnSend.Name = "btnSend";
            btnSend.Size = new Size(210, 40);
            btnSend.TabIndex = 6;
            btnSend.Text = "Gửi trả lời";
            btnSend.UseVisualStyleBackColor = false;
            btnSend.Click += btnSend_Click;
            //
            // btnCancel
            //
            btnCancel.BackColor = Color.FromArgb(70, 70, 75);
            btnCancel.Cursor = Cursors.Hand;
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnCancel.ForeColor = Color.White;
            btnCancel.Location = new Point(245, 330);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(210, 40);
            btnCancel.TabIndex = 7;
            btnCancel.Text = "Hủy";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            //
            // ReplyFeedback
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(45, 45, 48);
            ClientSize = new Size(480, 390);
            Controls.Add(btnCancel);
            Controls.Add(btnSend);
            Controls.Add(txtReply);
            Controls.Add(lblReply);
            Controls.Add(txtOriginalContent);
            Controls.Add(lblOriginal);
            Controls.Add(lblCustomer);
            Controls.Add(lblTitle);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ReplyFeedback";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Trả lời phản hồi";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private Label lblCustomer;
        private Label lblOriginal;
        private TextBox txtOriginalContent;
        private Label lblReply;
        private TextBox txtReply;
        private Button btnSend;
        private Button btnCancel;
    }
}
