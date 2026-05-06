using System.Drawing;
using System.Windows.Forms;

namespace GUI
{
    partial class ucSOS_Security
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
            pnlSOS = new Panel();
            lblTitle = new Label();
            btnSOS = new Button();
            lblSOSInfo = new Label();
            btnReport = new Button();
            pnlEmergencyInfo = new Panel();
            lblContactTitle = new Label();
            lblPolice = new Label();
            lblFire = new Label();
            lblAmbulance = new Label();
            lblManagerPhone = new Label();
            pnlLog = new Panel();
            lblLogTitle = new Label();
            dgvIncidents = new DataGridView();
            pnlSOS.SuspendLayout();
            pnlEmergencyInfo.SuspendLayout();
            pnlLog.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvIncidents).BeginInit();
            SuspendLayout();
            //
            // pnlSOS
            //
            pnlSOS.BackColor = Color.FromArgb(30, 30, 30);
            pnlSOS.Controls.Add(lblTitle);
            pnlSOS.Controls.Add(btnSOS);
            pnlSOS.Controls.Add(lblSOSInfo);
            pnlSOS.Controls.Add(btnReport);
            pnlSOS.Location = new Point(20, 15);
            pnlSOS.Name = "pnlSOS";
            pnlSOS.Size = new Size(764, 180);
            pnlSOS.TabIndex = 0;
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
            lblTitle.Text = "SOS - Khẩn cấp";
            //
            // btnSOS
            //
            btnSOS.BackColor = Color.Red;
            btnSOS.Cursor = Cursors.Hand;
            btnSOS.FlatAppearance.BorderSize = 0;
            btnSOS.FlatStyle = FlatStyle.Flat;
            btnSOS.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            btnSOS.ForeColor = Color.White;
            btnSOS.Location = new Point(250, 50);
            btnSOS.Name = "btnSOS";
            btnSOS.Size = new Size(250, 110);
            btnSOS.TabIndex = 1;
            btnSOS.Text = "SOS";
            btnSOS.UseVisualStyleBackColor = false;
            btnSOS.Click += btnSOS_Click;
            //
            // lblSOSInfo
            //
            lblSOSInfo.AutoSize = true;
            lblSOSInfo.Font = new Font("Segoe UI", 10F);
            lblSOSInfo.ForeColor = Color.Gray;
            lblSOSInfo.Location = new Point(240, 165);
            lblSOSInfo.Name = "lblSOSInfo";
            lblSOSInfo.Size = new Size(300, 19);
            lblSOSInfo.TabIndex = 2;
            lblSOSInfo.Text = "Nhấn nút để gửi cảnh báo khẩn cấp";
            //
            // btnReport
            //
            btnReport.BackColor = Color.FromArgb(70, 130, 180);
            btnReport.Cursor = Cursors.Hand;
            btnReport.FlatAppearance.BorderSize = 0;
            btnReport.FlatStyle = FlatStyle.Flat;
            btnReport.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            btnReport.ForeColor = Color.White;
            btnReport.Location = new Point(650, 12);
            btnReport.Name = "btnReport";
            btnReport.Size = new Size(95, 30);
            btnReport.TabIndex = 3;
            btnReport.Text = "Báo cáo";
            btnReport.UseVisualStyleBackColor = false;
            //
            // pnlEmergencyInfo
            //
            pnlEmergencyInfo.BackColor = Color.FromArgb(30, 30, 30);
            pnlEmergencyInfo.Controls.Add(lblContactTitle);
            pnlEmergencyInfo.Controls.Add(lblPolice);
            pnlEmergencyInfo.Controls.Add(lblFire);
            pnlEmergencyInfo.Controls.Add(lblAmbulance);
            pnlEmergencyInfo.Controls.Add(lblManagerPhone);
            pnlEmergencyInfo.Location = new Point(20, 205);
            pnlEmergencyInfo.Name = "pnlEmergencyInfo";
            pnlEmergencyInfo.Size = new Size(764, 65);
            pnlEmergencyInfo.TabIndex = 1;
            //
            // lblContactTitle
            //
            lblContactTitle.AutoSize = true;
            lblContactTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblContactTitle.ForeColor = Color.White;
            lblContactTitle.Location = new Point(15, 8);
            lblContactTitle.Name = "lblContactTitle";
            lblContactTitle.Size = new Size(120, 20);
            lblContactTitle.TabIndex = 0;
            lblContactTitle.Text = "Liên hệ khẩn cấp:";
            //
            // lblPolice
            //
            lblPolice.AutoSize = true;
            lblPolice.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblPolice.ForeColor = Color.IndianRed;
            lblPolice.Location = new Point(15, 35);
            lblPolice.Name = "lblPolice";
            lblPolice.Size = new Size(100, 19);
            lblPolice.TabIndex = 1;
            lblPolice.Text = "Công an: 113";
            //
            // lblFire
            //
            lblFire.AutoSize = true;
            lblFire.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblFire.ForeColor = Color.Orange;
            lblFire.Location = new Point(180, 35);
            lblFire.Name = "lblFire";
            lblFire.Size = new Size(120, 19);
            lblFire.TabIndex = 2;
            lblFire.Text = "Cứu hỏa: 114";
            //
            // lblAmbulance
            //
            lblAmbulance.AutoSize = true;
            lblAmbulance.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblAmbulance.ForeColor = Color.SteelBlue;
            lblAmbulance.Location = new Point(370, 35);
            lblAmbulance.Name = "lblAmbulance";
            lblAmbulance.Size = new Size(120, 19);
            lblAmbulance.TabIndex = 3;
            lblAmbulance.Text = "Cấp cứu: 115";
            //
            // lblManagerPhone
            //
            lblManagerPhone.AutoSize = true;
            lblManagerPhone.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblManagerPhone.ForeColor = Color.MediumSeaGreen;
            lblManagerPhone.Location = new Point(550, 35);
            lblManagerPhone.Name = "lblManagerPhone";
            lblManagerPhone.Size = new Size(180, 19);
            lblManagerPhone.TabIndex = 4;
            lblManagerPhone.Text = "QL: 0901-234-567";
            //
            // pnlLog
            //
            pnlLog.BackColor = Color.FromArgb(30, 30, 30);
            pnlLog.Controls.Add(lblLogTitle);
            pnlLog.Controls.Add(dgvIncidents);
            pnlLog.Location = new Point(20, 280);
            pnlLog.Name = "pnlLog";
            pnlLog.Size = new Size(764, 235);
            pnlLog.TabIndex = 2;
            //
            // lblLogTitle
            //
            lblLogTitle.AutoSize = true;
            lblLogTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblLogTitle.ForeColor = Color.White;
            lblLogTitle.Location = new Point(15, 12);
            lblLogTitle.Name = "lblLogTitle";
            lblLogTitle.Size = new Size(150, 20);
            lblLogTitle.TabIndex = 0;
            lblLogTitle.Text = "Lịch sử sự cố";
            //
            // dgvIncidents
            //
            dgvIncidents.AllowUserToAddRows = false;
            dgvIncidents.BackgroundColor = Color.FromArgb(45, 45, 48);
            dgvIncidents.BorderStyle = BorderStyle.None;
            dgvIncidents.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvStyle.BackColor = Color.FromArgb(45, 45, 48);
            dgvStyle.Font = new Font("Segoe UI", 9F);
            dgvStyle.ForeColor = Color.White;
            dgvStyle.SelectionBackColor = Color.Gray;
            dgvStyle.SelectionForeColor = Color.White;
            dgvIncidents.DefaultCellStyle = dgvStyle;
            dgvIncidents.Location = new Point(15, 40);
            dgvIncidents.Name = "dgvIncidents";
            dgvIncidents.ReadOnly = true;
            dgvIncidents.RowHeadersWidth = 51;
            dgvIncidents.Size = new Size(734, 180);
            dgvIncidents.TabIndex = 1;
            //
            // ucSOS_Security
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(45, 45, 48);
            Controls.Add(pnlLog);
            Controls.Add(pnlEmergencyInfo);
            Controls.Add(pnlSOS);
            Name = "ucSOS_Security";
            Size = new Size(804, 530);
            pnlSOS.ResumeLayout(false);
            pnlSOS.PerformLayout();
            pnlEmergencyInfo.ResumeLayout(false);
            pnlEmergencyInfo.PerformLayout();
            pnlLog.ResumeLayout(false);
            pnlLog.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvIncidents).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlSOS;
        private Label lblTitle;
        private Button btnSOS;
        private Label lblSOSInfo;
        private Panel pnlEmergencyInfo;
        private Label lblContactTitle;
        private Label lblPolice;
        private Label lblFire;
        private Label lblAmbulance;
        private Label lblManagerPhone;
        private Panel pnlLog;
        private Label lblLogTitle;
        private DataGridView dgvIncidents;
        private Button btnReport;
    }
}
