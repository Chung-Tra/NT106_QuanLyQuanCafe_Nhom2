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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
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
            colTime = new DataGridViewTextBoxColumn();
            colType = new DataGridViewTextBoxColumn();
            colDesc = new DataGridViewTextBoxColumn();
            colReporter = new DataGridViewTextBoxColumn();
            colStatus = new DataGridViewTextBoxColumn();
            pnlSOS.SuspendLayout();
            pnlEmergencyInfo.SuspendLayout();
            pnlLog.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvIncidents).BeginInit();
            SuspendLayout();
            // 
            // pnlSOS
            // 
            pnlSOS.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlSOS.BackColor = Color.FromArgb(31, 31, 34);
            pnlSOS.BorderRadius = 14;
            pnlSOS.Controls.Add(lblTitle);
            pnlSOS.Controls.Add(lblSOSInfo);
            pnlSOS.Controls.Add(btnSOS);
            pnlSOS.Controls.Add(btnReport);
            pnlSOS.CustomizableEdges = customizableEdges5;
            pnlSOS.Location = new Point(20, 20);
            pnlSOS.Name = "pnlSOS";
            pnlSOS.ShadowDecoration.CustomizableEdges = customizableEdges6;
            pnlSOS.Size = new Size(960, 220);
            pnlSOS.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(220, 38, 38);
            lblTitle.Location = new Point(20, 18);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(178, 25);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "SOS - Khẩn cấp";
            // 
            // lblSOSInfo
            // 
            lblSOSInfo.AutoSize = true;
            lblSOSInfo.Font = new Font("Segoe UI", 10F);
            lblSOSInfo.ForeColor = Color.FromArgb(160, 160, 166);
            lblSOSInfo.Location = new Point(334, 183);
            lblSOSInfo.Name = "lblSOSInfo";
            lblSOSInfo.Size = new Size(228, 19);
            lblSOSInfo.TabIndex = 1;
            lblSOSInfo.Text = "Nhấn nút để gửi cảnh báo khẩn cấp";
            // 
            // btnSOS
            // 
            btnSOS.BorderRadius = 16;
            btnSOS.Cursor = Cursors.Hand;
            btnSOS.CustomizableEdges = customizableEdges1;
            btnSOS.FillColor = Color.FromArgb(220, 38, 38);
            btnSOS.Font = new Font("Segoe UI", 26F, FontStyle.Bold);
            btnSOS.ForeColor = Color.White;
            btnSOS.HoverState.FillColor = Color.FromArgb(248, 60, 60);
            btnSOS.Location = new Point(310, 60);
            btnSOS.Name = "btnSOS";
            btnSOS.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnSOS.Size = new Size(280, 120);
            btnSOS.TabIndex = 2;
            btnSOS.Text = "SOS";
            btnSOS.Click += btnSOS_Click;
            // 
            // btnReport
            // 
            btnReport.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnReport.BorderRadius = 10;
            btnReport.Cursor = Cursors.Hand;
            btnReport.CustomizableEdges = customizableEdges3;
            btnReport.FillColor = Color.FromArgb(31, 138, 154);
            btnReport.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnReport.ForeColor = Color.White;
            btnReport.HoverState.FillColor = Color.FromArgb(45, 158, 174);
            btnReport.Location = new Point(830, 16);
            btnReport.Name = "btnReport";
            btnReport.ShadowDecoration.CustomizableEdges = customizableEdges4;
            btnReport.Size = new Size(110, 32);
            btnReport.TabIndex = 3;
            btnReport.Text = "Báo cáo";
            btnReport.Click += btnReport_Click;
            // 
            // pnlEmergencyInfo
            // 
            pnlEmergencyInfo.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlEmergencyInfo.BackColor = Color.FromArgb(31, 31, 34);
            pnlEmergencyInfo.BorderRadius = 14;
            pnlEmergencyInfo.Controls.Add(lblContactTitle);
            pnlEmergencyInfo.Controls.Add(lblPolice);
            pnlEmergencyInfo.Controls.Add(lblFire);
            pnlEmergencyInfo.Controls.Add(lblAmbulance);
            pnlEmergencyInfo.Controls.Add(lblManagerPhone);
            pnlEmergencyInfo.CustomizableEdges = customizableEdges7;
            pnlEmergencyInfo.Location = new Point(20, 255);
            pnlEmergencyInfo.Name = "pnlEmergencyInfo";
            pnlEmergencyInfo.ShadowDecoration.CustomizableEdges = customizableEdges8;
            pnlEmergencyInfo.Size = new Size(960, 80);
            pnlEmergencyInfo.TabIndex = 1;
            // 
            // lblContactTitle
            // 
            lblContactTitle.AutoSize = true;
            lblContactTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblContactTitle.ForeColor = Color.White;
            lblContactTitle.Location = new Point(20, 14);
            lblContactTitle.Name = "lblContactTitle";
            lblContactTitle.Size = new Size(125, 20);
            lblContactTitle.TabIndex = 0;
            lblContactTitle.Text = "Liên hệ khẩn cấp";
            // 
            // lblPolice
            // 
            lblPolice.AutoSize = true;
            lblPolice.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblPolice.ForeColor = Color.FromArgb(220, 38, 38);
            lblPolice.Location = new Point(20, 45);
            lblPolice.Name = "lblPolice";
            lblPolice.Size = new Size(96, 19);
            lblPolice.TabIndex = 1;
            lblPolice.Text = "Công an: 113";
            // 
            // lblFire
            // 
            lblFire.AutoSize = true;
            lblFire.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblFire.ForeColor = Color.FromArgb(245, 158, 11);
            lblFire.Location = new Point(200, 45);
            lblFire.Name = "lblFire";
            lblFire.Size = new Size(96, 19);
            lblFire.TabIndex = 2;
            lblFire.Text = "Cứu hỏa: 114";
            // 
            // lblAmbulance
            // 
            lblAmbulance.AutoSize = true;
            lblAmbulance.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblAmbulance.ForeColor = Color.FromArgb(31, 138, 154);
            lblAmbulance.Location = new Point(400, 45);
            lblAmbulance.Name = "lblAmbulance";
            lblAmbulance.Size = new Size(95, 19);
            lblAmbulance.TabIndex = 3;
            lblAmbulance.Text = "Cấp cứu: 115";
            // 
            // lblManagerPhone
            // 
            lblManagerPhone.AutoSize = true;
            lblManagerPhone.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblManagerPhone.ForeColor = Color.FromArgb(34, 197, 94);
            lblManagerPhone.Location = new Point(600, 45);
            lblManagerPhone.Name = "lblManagerPhone";
            lblManagerPhone.Size = new Size(127, 19);
            lblManagerPhone.TabIndex = 4;
            lblManagerPhone.Text = "QL: 0901-234-567";
            // 
            // pnlLog
            // 
            pnlLog.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnlLog.BackColor = Color.FromArgb(31, 31, 34);
            pnlLog.BorderRadius = 14;
            pnlLog.Controls.Add(lblLogTitle);
            pnlLog.Controls.Add(dgvIncidents);
            pnlLog.CustomizableEdges = customizableEdges9;
            pnlLog.Location = new Point(20, 350);
            pnlLog.Name = "pnlLog";
            pnlLog.ShadowDecoration.CustomizableEdges = customizableEdges10;
            pnlLog.Size = new Size(960, 295);
            pnlLog.TabIndex = 2;
            // 
            // lblLogTitle
            // 
            lblLogTitle.AutoSize = true;
            lblLogTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblLogTitle.ForeColor = Color.White;
            lblLogTitle.Location = new Point(20, 16);
            lblLogTitle.Name = "lblLogTitle";
            lblLogTitle.Size = new Size(99, 20);
            lblLogTitle.TabIndex = 0;
            lblLogTitle.Text = "Lịch sử sự cố";
            // 
            // dgvIncidents
            // 
            dataGridViewCellStyle1.BackColor = Color.FromArgb(24, 24, 27);
            dataGridViewCellStyle1.ForeColor = Color.FromArgb(220, 220, 225);
            dgvIncidents.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvIncidents.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvIncidents.BackgroundColor = Color.FromArgb(24, 24, 27);
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(31, 31, 34);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(160, 160, 166);
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(31, 31, 34);
            dataGridViewCellStyle2.SelectionForeColor = Color.FromArgb(160, 160, 166);
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvIncidents.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvIncidents.Columns.AddRange(new DataGridViewColumn[] { colTime, colType, colDesc, colReporter, colStatus });
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.FromArgb(24, 24, 27);
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(220, 220, 225);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(31, 138, 154);
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(240, 240, 245);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvIncidents.DefaultCellStyle = dataGridViewCellStyle3;
            dgvIncidents.GridColor = Color.FromArgb(45, 45, 48);
            dgvIncidents.Location = new Point(18, 52);
            dgvIncidents.Name = "dgvIncidents";
            dgvIncidents.RowHeadersVisible = false;
            dgvIncidents.Size = new Size(924, 225);
            dgvIncidents.TabIndex = 1;
            dgvIncidents.ThemeStyle.AlternatingRowsStyle.BackColor = Color.FromArgb(24, 24, 27);
            dgvIncidents.ThemeStyle.AlternatingRowsStyle.Font = null;
            dgvIncidents.ThemeStyle.AlternatingRowsStyle.ForeColor = Color.FromArgb(220, 220, 225);
            dgvIncidents.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.Empty;
            dgvIncidents.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.Empty;
            dgvIncidents.ThemeStyle.BackColor = Color.FromArgb(24, 24, 27);
            dgvIncidents.ThemeStyle.GridColor = Color.FromArgb(45, 45, 48);
            dgvIncidents.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(31, 31, 34);
            dgvIncidents.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvIncidents.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dgvIncidents.ThemeStyle.HeaderStyle.ForeColor = Color.FromArgb(160, 160, 166);
            dgvIncidents.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvIncidents.ThemeStyle.HeaderStyle.Height = 23;
            dgvIncidents.ThemeStyle.ReadOnly = false;
            dgvIncidents.ThemeStyle.RowsStyle.BackColor = Color.FromArgb(24, 24, 27);
            dgvIncidents.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvIncidents.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 9F);
            dgvIncidents.ThemeStyle.RowsStyle.ForeColor = Color.FromArgb(220, 220, 225);
            dgvIncidents.ThemeStyle.RowsStyle.Height = 25;
            dgvIncidents.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(31, 138, 154);
            dgvIncidents.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(240, 240, 245);
            // 
            // colTime
            // 
            colTime.DataPropertyName = "Thời gian";
            colTime.HeaderText = "Thời gian";
            colTime.Name = "Thời gian";
            // 
            // colType
            // 
            colType.DataPropertyName = "Loại sự cố";
            colType.HeaderText = "Loại sự cố";
            colType.Name = "Loại sự cố";
            // 
            // colDesc
            // 
            colDesc.DataPropertyName = "Mô tả";
            colDesc.HeaderText = "Mô tả";
            colDesc.Name = "Mô tả";
            // 
            // colReporter
            // 
            colReporter.DataPropertyName = "Người báo";
            colReporter.HeaderText = "Người báo";
            colReporter.Name = "Người báo";
            // 
            // colStatus
            // 
            colStatus.DataPropertyName = "Trạng thái";
            colStatus.HeaderText = "Trạng thái";
            colStatus.Name = "Trạng thái";
            // 
            // ucSOS_Security
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(39, 39, 42);
            Controls.Add(pnlSOS);
            Controls.Add(pnlEmergencyInfo);
            Controls.Add(pnlLog);
            Name = "ucSOS_Security";
            Size = new Size(1000, 665);
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
            dgv.AutoGenerateColumns = false;
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
        private DataGridViewTextBoxColumn colTime;
        private DataGridViewTextBoxColumn colType;
        private DataGridViewTextBoxColumn colDesc;
        private DataGridViewTextBoxColumn colReporter;
        private DataGridViewTextBoxColumn colStatus;
        private Guna2Button btnReport;
    }
}
