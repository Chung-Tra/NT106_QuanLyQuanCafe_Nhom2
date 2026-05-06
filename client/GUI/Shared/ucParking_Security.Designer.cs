using System.Drawing;
using System.Windows.Forms;

namespace GUI
{
    partial class ucParking_Security
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
            pnlHeader = new Panel();
            lblTitle = new Label();
            btnVehicleIn = new Button();
            btnVehicleOut = new Button();
            btnReport = new Button();
            pnlInfo = new Panel();
            lblPlate = new Label();
            txtPlate = new TextBox();
            lblType = new Label();
            cmbVehicleType = new ComboBox();
            lblSlots = new Label();
            lblSlotsValue = new Label();
            pnlGrid = new Panel();
            lblLogTitle = new Label();
            dgvParkingLog = new DataGridView();
            pnlHeader.SuspendLayout();
            pnlInfo.SuspendLayout();
            pnlGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvParkingLog).BeginInit();
            SuspendLayout();
            //
            // pnlHeader
            //
            pnlHeader.BackColor = Color.FromArgb(30, 30, 30);
            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Controls.Add(btnVehicleIn);
            pnlHeader.Controls.Add(btnVehicleOut);
            pnlHeader.Controls.Add(btnReport);
            pnlHeader.Location = new Point(20, 15);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(764, 55);
            pnlHeader.TabIndex = 0;
            //
            // lblTitle
            //
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(15, 14);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(200, 25);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Quản lý bãi xe";
            //
            // btnVehicleIn
            //
            btnVehicleIn.BackColor = Color.MediumSeaGreen;
            btnVehicleIn.Cursor = Cursors.Hand;
            btnVehicleIn.FlatAppearance.BorderSize = 0;
            btnVehicleIn.FlatStyle = FlatStyle.Flat;
            btnVehicleIn.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnVehicleIn.ForeColor = Color.White;
            btnVehicleIn.Location = new Point(430, 10);
            btnVehicleIn.Name = "btnVehicleIn";
            btnVehicleIn.Size = new Size(150, 35);
            btnVehicleIn.TabIndex = 1;
            btnVehicleIn.Text = "XE VÀO";
            btnVehicleIn.UseVisualStyleBackColor = false;
            btnVehicleIn.Click += btnVehicleIn_Click;
            //
            // btnVehicleOut
            //
            btnVehicleOut.BackColor = Color.IndianRed;
            btnVehicleOut.Cursor = Cursors.Hand;
            btnVehicleOut.FlatAppearance.BorderSize = 0;
            btnVehicleOut.FlatStyle = FlatStyle.Flat;
            btnVehicleOut.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnVehicleOut.ForeColor = Color.White;
            btnVehicleOut.Location = new Point(595, 10);
            btnVehicleOut.Name = "btnVehicleOut";
            btnVehicleOut.Size = new Size(150, 35);
            btnVehicleOut.TabIndex = 2;
            btnVehicleOut.Text = "XE RA";
            btnVehicleOut.UseVisualStyleBackColor = false;
            btnVehicleOut.Click += btnVehicleOut_Click;
            //
            // btnReport
            //
            btnReport.BackColor = Color.FromArgb(70, 130, 180);
            btnReport.Cursor = Cursors.Hand;
            btnReport.FlatAppearance.BorderSize = 0;
            btnReport.FlatStyle = FlatStyle.Flat;
            btnReport.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            btnReport.ForeColor = Color.White;
            btnReport.Location = new Point(330, 14);
            btnReport.Name = "btnReport";
            btnReport.Size = new Size(90, 28);
            btnReport.TabIndex = 3;
            btnReport.Text = "Báo cáo";
            btnReport.UseVisualStyleBackColor = false;
            //
            // pnlInfo
            //
            pnlInfo.BackColor = Color.FromArgb(30, 30, 30);
            pnlInfo.Controls.Add(lblPlate);
            pnlInfo.Controls.Add(txtPlate);
            pnlInfo.Controls.Add(lblType);
            pnlInfo.Controls.Add(cmbVehicleType);
            pnlInfo.Controls.Add(lblSlots);
            pnlInfo.Controls.Add(lblSlotsValue);
            pnlInfo.Location = new Point(20, 80);
            pnlInfo.Name = "pnlInfo";
            pnlInfo.Size = new Size(764, 65);
            pnlInfo.TabIndex = 1;
            //
            // lblPlate
            //
            lblPlate.AutoSize = true;
            lblPlate.Font = new Font("Segoe UI", 10F);
            lblPlate.ForeColor = Color.Gray;
            lblPlate.Location = new Point(20, 22);
            lblPlate.Name = "lblPlate";
            lblPlate.Size = new Size(65, 19);
            lblPlate.TabIndex = 0;
            lblPlate.Text = "Biển số:";
            //
            // txtPlate
            //
            txtPlate.BackColor = Color.FromArgb(45, 45, 48);
            txtPlate.BorderStyle = BorderStyle.FixedSingle;
            txtPlate.Font = new Font("Segoe UI", 11F);
            txtPlate.ForeColor = Color.White;
            txtPlate.Location = new Point(95, 19);
            txtPlate.Name = "txtPlate";
            txtPlate.PlaceholderText = "VD: 59A-12345";
            txtPlate.Size = new Size(180, 27);
            txtPlate.TabIndex = 1;
            //
            // lblType
            //
            lblType.AutoSize = true;
            lblType.Font = new Font("Segoe UI", 10F);
            lblType.ForeColor = Color.Gray;
            lblType.Location = new Point(300, 22);
            lblType.Name = "lblType";
            lblType.Size = new Size(60, 19);
            lblType.TabIndex = 2;
            lblType.Text = "Loại xe:";
            //
            // cmbVehicleType
            //
            cmbVehicleType.BackColor = Color.FromArgb(45, 45, 48);
            cmbVehicleType.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbVehicleType.FlatStyle = FlatStyle.Flat;
            cmbVehicleType.Font = new Font("Segoe UI", 10F);
            cmbVehicleType.ForeColor = Color.White;
            cmbVehicleType.Items.AddRange(new object[] { "Xe máy", "Xe đạp", "Ô tô" });
            cmbVehicleType.Location = new Point(370, 19);
            cmbVehicleType.Name = "cmbVehicleType";
            cmbVehicleType.Size = new Size(120, 25);
            cmbVehicleType.TabIndex = 3;
            //
            // lblSlots
            //
            lblSlots.AutoSize = true;
            lblSlots.Font = new Font("Segoe UI", 10F);
            lblSlots.ForeColor = Color.Gray;
            lblSlots.Location = new Point(550, 12);
            lblSlots.Name = "lblSlots";
            lblSlots.Size = new Size(60, 19);
            lblSlots.TabIndex = 4;
            lblSlots.Text = "Chỗ trống:";
            //
            // lblSlotsValue
            //
            lblSlotsValue.AutoSize = true;
            lblSlotsValue.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblSlotsValue.ForeColor = Color.MediumSeaGreen;
            lblSlotsValue.Location = new Point(550, 32);
            lblSlotsValue.Name = "lblSlotsValue";
            lblSlotsValue.Size = new Size(80, 25);
            lblSlotsValue.TabIndex = 5;
            lblSlotsValue.Text = "15 / 30";
            //
            // pnlGrid
            //
            pnlGrid.BackColor = Color.FromArgb(30, 30, 30);
            pnlGrid.Controls.Add(lblLogTitle);
            pnlGrid.Controls.Add(dgvParkingLog);
            pnlGrid.Location = new Point(20, 155);
            pnlGrid.Name = "pnlGrid";
            pnlGrid.Size = new Size(764, 360);
            pnlGrid.TabIndex = 2;
            //
            // lblLogTitle
            //
            lblLogTitle.AutoSize = true;
            lblLogTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblLogTitle.ForeColor = Color.White;
            lblLogTitle.Location = new Point(15, 12);
            lblLogTitle.Name = "lblLogTitle";
            lblLogTitle.Size = new Size(160, 20);
            lblLogTitle.TabIndex = 0;
            lblLogTitle.Text = "Lịch sử ra vào";
            //
            // dgvParkingLog
            //
            dgvParkingLog.AllowUserToAddRows = false;
            dgvParkingLog.BackgroundColor = Color.FromArgb(45, 45, 48);
            dgvParkingLog.BorderStyle = BorderStyle.None;
            dgvParkingLog.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvStyle.BackColor = Color.FromArgb(45, 45, 48);
            dgvStyle.Font = new Font("Segoe UI", 9F);
            dgvStyle.ForeColor = Color.White;
            dgvStyle.SelectionBackColor = Color.Gray;
            dgvStyle.SelectionForeColor = Color.White;
            dgvParkingLog.DefaultCellStyle = dgvStyle;
            dgvParkingLog.Location = new Point(15, 40);
            dgvParkingLog.Name = "dgvParkingLog";
            dgvParkingLog.ReadOnly = true;
            dgvParkingLog.RowHeadersWidth = 51;
            dgvParkingLog.Size = new Size(734, 305);
            dgvParkingLog.TabIndex = 1;
            //
            // ucParking_Security
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(45, 45, 48);
            Controls.Add(pnlGrid);
            Controls.Add(pnlInfo);
            Controls.Add(pnlHeader);
            Name = "ucParking_Security";
            Size = new Size(804, 530);
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            pnlInfo.ResumeLayout(false);
            pnlInfo.PerformLayout();
            pnlGrid.ResumeLayout(false);
            pnlGrid.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvParkingLog).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlHeader;
        private Label lblTitle;
        private Button btnVehicleIn;
        private Button btnVehicleOut;
        private Panel pnlInfo;
        private Label lblPlate;
        private TextBox txtPlate;
        private Label lblType;
        private ComboBox cmbVehicleType;
        private Label lblSlots;
        private Label lblSlotsValue;
        private Panel pnlGrid;
        private Label lblLogTitle;
        private DataGridView dgvParkingLog;
        private Button btnReport;
    }
}
