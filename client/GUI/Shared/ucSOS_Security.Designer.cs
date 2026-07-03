using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;

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
            pnlSOS = new Guna2Panel();
            lblTitle = new Label();
            lblSOSInfo = new Label();
            btnSOS = new Guna2Button();
            btnReport = new Guna2Button();
            pnlEmergencyInfo = new Guna2Panel();
            lblContactTitle = new Label();
            lblPolice = new Label();
            lblFire = new Label();
            lblAmbulance = new Label();
            lblManagerPhone = new Label();
            pnlLog = new Guna2Panel();
            lblLogTitle = new Label();
            dgvIncidents = new Guna2DataGridView();
            pnlSOS.SuspendLayout();
            pnlEmergencyInfo.SuspendLayout();
            pnlLog.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvIncidents).BeginInit();
            SuspendLayout();

            // ====== pnlSOS ======
            pnlSOS.BackColor = Color.FromArgb(31, 31, 34);
            pnlSOS.BorderRadius = 14;
            pnlSOS.Controls.Add(lblTitle);
            pnlSOS.Controls.Add(lblSOSInfo);
            pnlSOS.Controls.Add(btnSOS);
            pnlSOS.Controls.Add(btnReport);
            pnlSOS.Location = new Point(20, 20);
            pnlSOS.Size = new Size(900, 220);

            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(220, 38, 38);
            lblTitle.Location = new Point(20, 18);
            lblTitle.Text = "🚨  SOS - Khẩn cấp";

            lblSOSInfo.AutoSize = true;
            lblSOSInfo.Font = new Font("Segoe UI", 10F);
            lblSOSInfo.ForeColor = Color.FromArgb(160, 160, 166);
            lblSOSInfo.Location = new Point(310, 188);
            lblSOSInfo.Text = "Nhấn nút để gửi cảnh báo khẩn cấp";

            btnSOS.BorderRadius = 16;
            btnSOS.Cursor = Cursors.Hand;
            btnSOS.FillColor = Color.FromArgb(220, 38, 38);
            btnSOS.Font = new Font("Segoe UI", 26F, FontStyle.Bold);
            btnSOS.ForeColor = Color.White;
            btnSOS.HoverState.FillColor = Color.FromArgb(248, 60, 60);
            btnSOS.Location = new Point(310, 60);
            btnSOS.Size = new Size(280, 120);
            btnSOS.Text = "SOS";
            btnSOS.Click += btnSOS_Click;

            btnReport.BorderRadius = 10;
            btnReport.Cursor = Cursors.Hand;
            btnReport.FillColor = Color.FromArgb(31, 138, 154);
            btnReport.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnReport.ForeColor = Color.White;
            btnReport.HoverState.FillColor = Color.FromArgb(45, 158, 174);
            btnReport.Location = new Point(770, 16);
            btnReport.Size = new Size(110, 32);
            btnReport.Text = "📊 Báo cáo";

            // ====== pnlEmergencyInfo ======
            pnlEmergencyInfo.BackColor = Color.FromArgb(31, 31, 34);
            pnlEmergencyInfo.BorderRadius = 14;
            pnlEmergencyInfo.Controls.Add(lblContactTitle);
            pnlEmergencyInfo.Controls.Add(lblPolice);
            pnlEmergencyInfo.Controls.Add(lblFire);
            pnlEmergencyInfo.Controls.Add(lblAmbulance);
            pnlEmergencyInfo.Controls.Add(lblManagerPhone);
            pnlEmergencyInfo.Location = new Point(20, 255);
            pnlEmergencyInfo.Size = new Size(900, 80);

            lblContactTitle.AutoSize = true;
            lblContactTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblContactTitle.ForeColor = Color.White;
            lblContactTitle.Location = new Point(20, 14);
            lblContactTitle.Text = "Liên hệ khẩn cấp";

            lblPolice.AutoSize = true;
            lblPolice.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblPolice.ForeColor = Color.FromArgb(220, 38, 38);
            lblPolice.Location = new Point(20, 45);
            lblPolice.Text = "Công an: 113";

            lblFire.AutoSize = true;
            lblFire.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblFire.ForeColor = Color.FromArgb(245, 158, 11);
            lblFire.Location = new Point(200, 45);
            lblFire.Text = "Cứu hỏa: 114";

            lblAmbulance.AutoSize = true;
            lblAmbulance.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblAmbulance.ForeColor = Color.FromArgb(31, 138, 154);
            lblAmbulance.Location = new Point(400, 45);
            lblAmbulance.Text = "Cấp cứu: 115";

            lblManagerPhone.AutoSize = true;
            lblManagerPhone.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblManagerPhone.ForeColor = Color.FromArgb(34, 197, 94);
            lblManagerPhone.Location = new Point(600, 45);
            lblManagerPhone.Text = "QL: 0901-234-567";

            // ====== pnlLog ======
            pnlLog.BackColor = Color.FromArgb(31, 31, 34);
            pnlLog.BorderRadius = 14;
            pnlLog.Controls.Add(lblLogTitle);
            pnlLog.Controls.Add(dgvIncidents);
            pnlLog.Location = new Point(20, 350);
            pnlLog.Size = new Size(900, 290);

            lblLogTitle.AutoSize = true;
            lblLogTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblLogTitle.ForeColor = Color.White;
            lblLogTitle.Location = new Point(20, 16);
            lblLogTitle.Text = "Lịch sử sự cố";

            dgvIncidents.BackgroundColor = Color.FromArgb(24, 24, 27);
            dgvIncidents.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(31, 31, 34);
            dgvIncidents.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(160, 160, 166);
            dgvIncidents.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dgvIncidents.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(31, 31, 34);
            dgvIncidents.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.FromArgb(160, 160, 166);
            dgvIncidents.DefaultCellStyle.BackColor = Color.FromArgb(24, 24, 27);
            dgvIncidents.DefaultCellStyle.ForeColor = Color.FromArgb(220, 220, 225);
            dgvIncidents.DefaultCellStyle.SelectionBackColor = Color.FromArgb(31, 138, 154);
            dgvIncidents.DefaultCellStyle.SelectionForeColor = Color.FromArgb(240, 240, 245);
            dgvIncidents.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(24, 24, 27);
            dgvIncidents.AlternatingRowsDefaultCellStyle.ForeColor = Color.FromArgb(220, 220, 225);
            dgvIncidents.GridColor = Color.FromArgb(45, 45, 48);
            ConfigureGrid(dgvIncidents);
            dgvIncidents.Location = new Point(18, 52);
            dgvIncidents.Size = new Size(864, 220);

            // ====== ucSOS_Security ======
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(39, 39, 42);
            Controls.Add(pnlSOS);
            Controls.Add(pnlEmergencyInfo);
            Controls.Add(pnlLog);
            Name = "ucSOS_Security";
            Size = new Size(940, 660);
            pnlSOS.ResumeLayout(false);
            pnlSOS.PerformLayout();
            pnlEmergencyInfo.ResumeLayout(false);
            pnlEmergencyInfo.PerformLayout();
            pnlLog.ResumeLayout(false);
            pnlLog.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvIncidents).EndInit();
            ResumeLayout(false);
        }

        private static void ConfigureGrid(Guna2DataGridView dgv)
        {
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToResizeRows = false;
            dgv.BackgroundColor = Color.FromArgb(24, 24, 27);
            dgv.BorderStyle = BorderStyle.None;
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgv.ColumnHeadersHeight = 32;
            dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(31, 31, 34);
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(160, 160, 166);
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dgv.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(31, 31, 34);
            dgv.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.FromArgb(160, 160, 166);
            dgv.DefaultCellStyle.BackColor = Color.FromArgb(24, 24, 27);
            dgv.DefaultCellStyle.ForeColor = Color.FromArgb(220, 220, 225);
            dgv.DefaultCellStyle.Font = new Font("Segoe UI", 9F);
            dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(31, 138, 154);
            dgv.DefaultCellStyle.SelectionForeColor = Color.FromArgb(240, 240, 245);
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(24, 24, 27);
            dgv.AlternatingRowsDefaultCellStyle.ForeColor = Color.FromArgb(220, 220, 225);
            dgv.AlternatingRowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(31, 138, 154);
            dgv.AlternatingRowsDefaultCellStyle.SelectionForeColor = Color.FromArgb(240, 240, 245);
            dgv.EnableHeadersVisualStyles = false;
            dgv.GridColor = Color.FromArgb(45, 45, 48);
            dgv.MultiSelect = false;
            dgv.ReadOnly = true;
            dgv.RowHeadersVisible = false;
            dgv.RowTemplate.Height = 28;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DgvDarkScroll.Apply(dgv);
        }

        #endregion

        private Guna2Panel pnlSOS;
        private Label lblTitle;
        private Guna2Button btnSOS;
        private Label lblSOSInfo;
        private Guna2Panel pnlEmergencyInfo;
        private Label lblContactTitle;
        private Label lblPolice;
        private Label lblFire;
        private Label lblAmbulance;
        private Label lblManagerPhone;
        private Guna2Panel pnlLog;
        private Label lblLogTitle;
        private Guna2DataGridView dgvIncidents;
        private Guna2Button btnReport;
    }
}
