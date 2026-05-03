using System.Drawing;
using System.Windows.Forms;

namespace GUI
{
    partial class ucAlert_Barista
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        private void InitializeComponent()
        {
            DataGridViewCellStyle dgvStyle = new DataGridViewCellStyle();
            pnlSend = new Panel();
            lblTitle = new Label();
            cmbAlertType = new ComboBox();
            lblAlertType = new Label();
            txtMessage = new TextBox();
            btnSendAlert = new Button();
            btnReport = new Button();
            pnlHistory = new Panel();
            lblHistoryTitle = new Label();
            dgvAlertHistory = new DataGridView();
            pnlSend.SuspendLayout();
            pnlHistory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAlertHistory).BeginInit();
            SuspendLayout();
            //
            // pnlSend
            //
            pnlSend.BackColor = Color.FromArgb(30, 30, 30);
            pnlSend.Controls.Add(lblTitle);
            pnlSend.Controls.Add(cmbAlertType);
            pnlSend.Controls.Add(lblAlertType);
            pnlSend.Controls.Add(txtMessage);
            pnlSend.Controls.Add(btnSendAlert);
            pnlSend.Controls.Add(btnReport);
            pnlSend.Location = new Point(20, 15);
            pnlSend.Name = "pnlSend";
            pnlSend.Size = new Size(764, 200);
            pnlSend.TabIndex = 0;
            //
            // lblTitle
            //
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(15, 12);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(200, 25);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Cảnh báo hết nguyên liệu";
            //
            // lblAlertType
            //
            lblAlertType.AutoSize = true;
            lblAlertType.Font = new Font("Segoe UI", 10F);
            lblAlertType.ForeColor = Color.Gray;
            lblAlertType.Location = new Point(15, 50);
            lblAlertType.Name = "lblAlertType";
            lblAlertType.Size = new Size(80, 19);
            lblAlertType.TabIndex = 1;
            lblAlertType.Text = "Loai:";
            //
            // cmbAlertType
            //
            cmbAlertType.BackColor = Color.FromArgb(45, 45, 48);
            cmbAlertType.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbAlertType.FlatStyle = FlatStyle.Flat;
            cmbAlertType.Font = new Font("Segoe UI", 10F);
            cmbAlertType.ForeColor = Color.White;
            cmbAlertType.Items.AddRange(new object[] { "Hết nguyên liệu", "Sắp hết nguyên liệu", "Thiết bị hỏng", "Khác" });
            cmbAlertType.Location = new Point(70, 48);
            cmbAlertType.Name = "cmbAlertType";
            cmbAlertType.Size = new Size(250, 25);
            cmbAlertType.TabIndex = 2;
            //
            // txtMessage
            //
            txtMessage.BackColor = Color.FromArgb(45, 45, 48);
            txtMessage.BorderStyle = BorderStyle.FixedSingle;
            txtMessage.Font = new Font("Segoe UI", 10F);
            txtMessage.ForeColor = Color.White;
            txtMessage.Location = new Point(15, 85);
            txtMessage.Multiline = true;
            txtMessage.Name = "txtMessage";
            txtMessage.PlaceholderText = "Nhập nội dung cảnh báo...";
            txtMessage.Size = new Size(580, 95);
            txtMessage.TabIndex = 3;
            //
            // btnSendAlert
            //
            btnSendAlert.BackColor = Color.IndianRed;
            btnSendAlert.Cursor = Cursors.Hand;
            btnSendAlert.FlatAppearance.BorderSize = 0;
            btnSendAlert.FlatStyle = FlatStyle.Flat;
            btnSendAlert.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnSendAlert.ForeColor = Color.White;
            btnSendAlert.Location = new Point(615, 85);
            btnSendAlert.Name = "btnSendAlert";
            btnSendAlert.Size = new Size(130, 95);
            btnSendAlert.TabIndex = 4;
            btnSendAlert.Text = "GỬI CẢNH BÁO";
            btnSendAlert.UseVisualStyleBackColor = false;
            btnSendAlert.Click += btnSendAlert_Click;
            //
            // btnReport
            //
            btnReport.BackColor = Color.FromArgb(70, 130, 180);
            btnReport.Cursor = Cursors.Hand;
            btnReport.FlatAppearance.BorderSize = 0;
            btnReport.FlatStyle = FlatStyle.Flat;
            btnReport.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            btnReport.ForeColor = Color.White;
            btnReport.Location = new Point(350, 12);
            btnReport.Name = "btnReport";
            btnReport.Size = new Size(90, 28);
            btnReport.TabIndex = 5;
            btnReport.Text = "Báo cáo";
            btnReport.UseVisualStyleBackColor = false;
            //
            // pnlHistory
            //
            pnlHistory.BackColor = Color.FromArgb(30, 30, 30);
            pnlHistory.Controls.Add(lblHistoryTitle);
            pnlHistory.Controls.Add(dgvAlertHistory);
            pnlHistory.Location = new Point(20, 225);
            pnlHistory.Name = "pnlHistory";
            pnlHistory.Size = new Size(764, 290);
            pnlHistory.TabIndex = 1;
            //
            // lblHistoryTitle
            //
            lblHistoryTitle.AutoSize = true;
            lblHistoryTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblHistoryTitle.ForeColor = Color.White;
            lblHistoryTitle.Location = new Point(15, 12);
            lblHistoryTitle.Name = "lblHistoryTitle";
            lblHistoryTitle.Size = new Size(170, 20);
            lblHistoryTitle.TabIndex = 0;
            lblHistoryTitle.Text = "Lịch sử cảnh báo";
            //
            // dgvAlertHistory
            //
            dgvAlertHistory.AllowUserToAddRows = false;
            dgvAlertHistory.BackgroundColor = Color.FromArgb(45, 45, 48);
            dgvAlertHistory.BorderStyle = BorderStyle.None;
            dgvAlertHistory.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvStyle.BackColor = Color.FromArgb(45, 45, 48);
            dgvStyle.Font = new Font("Segoe UI", 9F);
            dgvStyle.ForeColor = Color.White;
            dgvStyle.SelectionBackColor = Color.Gray;
            dgvStyle.SelectionForeColor = Color.White;
            dgvAlertHistory.DefaultCellStyle = dgvStyle;
            dgvAlertHistory.Location = new Point(15, 40);
            dgvAlertHistory.Name = "dgvAlertHistory";
            dgvAlertHistory.ReadOnly = true;
            dgvAlertHistory.RowHeadersWidth = 51;
            dgvAlertHistory.Size = new Size(734, 235);
            dgvAlertHistory.TabIndex = 1;
            //
            // ucAlert_Barista
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(45, 45, 48);
            Controls.Add(pnlHistory);
            Controls.Add(pnlSend);
            Name = "ucAlert_Barista";
            Size = new Size(804, 530);
            pnlSend.ResumeLayout(false);
            pnlSend.PerformLayout();
            pnlHistory.ResumeLayout(false);
            pnlHistory.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAlertHistory).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlSend;
        private Label lblTitle;
        private ComboBox cmbAlertType;
        private Label lblAlertType;
        private TextBox txtMessage;
        private Button btnSendAlert;
        private Panel pnlHistory;
        private Label lblHistoryTitle;
        private DataGridView dgvAlertHistory;
        private Button btnReport;
    }
}
