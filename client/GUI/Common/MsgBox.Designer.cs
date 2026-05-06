namespace GUI
{
    partial class MsgBox
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
            pnlHeader = new Panel();
            lblTitle = new Label();
            pnlBody = new Panel();
            btnCancel = new Button();
            lblMessage = new Label();
            btnOk = new Button();
            pnlHeader.SuspendLayout();
            pnlBody.SuspendLayout();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.FromArgb(0, 123, 255);
            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(400, 35);
            pnlHeader.TabIndex = 0;
            pnlHeader.MouseDown += PnlHeader_MouseDown;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(12, 8);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(88, 19);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Thông báo";
            // 
            // pnlBody
            // 
            pnlBody.Controls.Add(btnCancel);
            pnlBody.Controls.Add(lblMessage);
            pnlBody.Controls.Add(btnOk);
            pnlBody.Dock = DockStyle.Fill;
            pnlBody.Location = new Point(0, 35);
            pnlBody.Name = "pnlBody";
            pnlBody.Size = new Size(400, 165);
            pnlBody.TabIndex = 1;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.FromArgb(108, 117, 125);
            btnCancel.Cursor = Cursors.Hand;
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnCancel.ForeColor = Color.White;
            btnCancel.Location = new Point(210, 110);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(120, 40);
            btnCancel.TabIndex = 2;
            btnCancel.Text = "HỦY";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Visible = false;
            btnCancel.Click += BtnCancel_Click;
            // 
            // lblMessage
            // 
            lblMessage.Font = new Font("Segoe UI", 11F);
            lblMessage.ForeColor = Color.White;
            lblMessage.Location = new Point(20, 10);
            lblMessage.Name = "lblMessage";
            lblMessage.Size = new Size(360, 90);
            lblMessage.TabIndex = 1;
            lblMessage.Text = "Nội dung thông báo...";
            lblMessage.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnOk
            // 
            btnOk.BackColor = Color.FromArgb(0, 123, 255);
            btnOk.Cursor = Cursors.Hand;
            btnOk.FlatAppearance.BorderSize = 0;
            btnOk.FlatStyle = FlatStyle.Flat;
            btnOk.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnOk.ForeColor = Color.White;
            btnOk.Location = new Point(70, 110);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(120, 40);
            btnOk.TabIndex = 0;
            btnOk.Text = "OK";
            btnOk.UseVisualStyleBackColor = false;
            btnOk.Click += BtnOk_Click;
            // 
            // MsgBox
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(35, 35, 38);
            ClientSize = new Size(400, 200);
            Controls.Add(pnlBody);
            Controls.Add(pnlHeader);
            FormBorderStyle = FormBorderStyle.None;
            Name = "MsgBox";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Message Box";
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            pnlBody.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnlBody;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
    }
}