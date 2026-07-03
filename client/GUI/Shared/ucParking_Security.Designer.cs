using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;

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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges13 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges14 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges11 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges12 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges15 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges16 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            pnlHeader = new Guna2Panel();
            lblTitle = new Label();
            btnReport = new Guna2Button();
            btnVehicleIn = new Guna2Button();
            btnVehicleOut = new Guna2Button();
            pnlInfo = new Guna2Panel();
            lblPlate = new Label();
            txtPlate = new Guna2TextBox();
            lblType = new Label();
            cmbVehicleType = new Guna2ComboBox();
            lblSlots = new Label();
            lblSlotsValue = new Label();
            pnlGrid = new Guna2Panel();
            lblLogTitle = new Label();
            dgvParkingLog = new Guna2DataGridView();
            colPlate = new DataGridViewTextBoxColumn();
            colVehicleType = new DataGridViewTextBoxColumn();
            colTimeIn = new DataGridViewTextBoxColumn();
            colTimeOut = new DataGridViewTextBoxColumn();
            colStatus = new DataGridViewTextBoxColumn();
            pnlHeader.SuspendLayout();
            pnlInfo.SuspendLayout();
            pnlGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvParkingLog).BeginInit();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlHeader.BackColor = Color.FromArgb(31, 31, 34);
            pnlHeader.BorderRadius = 14;
            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Controls.Add(btnReport);
            pnlHeader.Controls.Add(btnVehicleIn);
            pnlHeader.Controls.Add(btnVehicleOut);
            pnlHeader.CustomizableEdges = customizableEdges7;
            pnlHeader.Location = new Point(20, 20);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.ShadowDecoration.CustomizableEdges = customizableEdges8;
            pnlHeader.Size = new Size(960, 70);
            pnlHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(18, 22);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(170, 25);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Quản lý bãi xe";
            // 
            // btnReport
            // 
            btnReport.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnReport.BorderRadius = 10;
            btnReport.Cursor = Cursors.Hand;
            btnReport.CustomizableEdges = customizableEdges1;
            btnReport.FillColor = Color.FromArgb(31, 138, 154);
            btnReport.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnReport.ForeColor = Color.White;
            btnReport.HoverState.FillColor = Color.FromArgb(45, 158, 174);
            btnReport.Location = new Point(588, 18);
            btnReport.Name = "btnReport";
            btnReport.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnReport.Size = new Size(110, 34);
            btnReport.TabIndex = 1;
            btnReport.Text = "Báo cáo";
            btnReport.Click += btnReport_Click;
            // 
            // btnVehicleIn
            // 
            btnVehicleIn.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnVehicleIn.BorderRadius = 10;
            btnVehicleIn.Cursor = Cursors.Hand;
            btnVehicleIn.CustomizableEdges = customizableEdges3;
            btnVehicleIn.FillColor = Color.FromArgb(34, 197, 94);
            btnVehicleIn.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnVehicleIn.ForeColor = Color.White;
            btnVehicleIn.HoverState.FillColor = Color.FromArgb(45, 207, 104);
            btnVehicleIn.Location = new Point(708, 18);
            btnVehicleIn.Name = "btnVehicleIn";
            btnVehicleIn.ShadowDecoration.CustomizableEdges = customizableEdges4;
            btnVehicleIn.Size = new Size(110, 34);
            btnVehicleIn.TabIndex = 2;
            btnVehicleIn.Text = "Xe vào";
            btnVehicleIn.Click += btnVehicleIn_Click;
            // 
            // btnVehicleOut
            // 
            btnVehicleOut.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnVehicleOut.BorderRadius = 10;
            btnVehicleOut.Cursor = Cursors.Hand;
            btnVehicleOut.CustomizableEdges = customizableEdges5;
            btnVehicleOut.FillColor = Color.FromArgb(220, 80, 80);
            btnVehicleOut.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnVehicleOut.ForeColor = Color.White;
            btnVehicleOut.HoverState.FillColor = Color.FromArgb(180, 60, 60);
            btnVehicleOut.Location = new Point(828, 18);
            btnVehicleOut.Name = "btnVehicleOut";
            btnVehicleOut.ShadowDecoration.CustomizableEdges = customizableEdges6;
            btnVehicleOut.Size = new Size(110, 34);
            btnVehicleOut.TabIndex = 3;
            btnVehicleOut.Text = "Xe ra";
            btnVehicleOut.Click += btnVehicleOut_Click;
            // 
            // pnlInfo
            // 
            pnlInfo.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlInfo.BackColor = Color.FromArgb(31, 31, 34);
            pnlInfo.BorderRadius = 14;
            pnlInfo.Controls.Add(lblPlate);
            pnlInfo.Controls.Add(txtPlate);
            pnlInfo.Controls.Add(lblType);
            pnlInfo.Controls.Add(cmbVehicleType);
            pnlInfo.Controls.Add(lblSlots);
            pnlInfo.Controls.Add(lblSlotsValue);
            pnlInfo.CustomizableEdges = customizableEdges13;
            pnlInfo.Location = new Point(20, 105);
            pnlInfo.Name = "pnlInfo";
            pnlInfo.ShadowDecoration.CustomizableEdges = customizableEdges14;
            pnlInfo.Size = new Size(960, 95);
            pnlInfo.TabIndex = 1;
            // 
            // lblPlate
            // 
            lblPlate.AutoSize = true;
            lblPlate.Font = new Font("Segoe UI", 9F);
            lblPlate.ForeColor = Color.FromArgb(160, 160, 166);
            lblPlate.Location = new Point(20, 18);
            lblPlate.Name = "lblPlate";
            lblPlate.Size = new Size(45, 15);
            lblPlate.TabIndex = 0;
            lblPlate.Text = "Biển số";
            // 
            // txtPlate
            // 
            txtPlate.BorderColor = Color.FromArgb(63, 63, 70);
            txtPlate.BorderRadius = 10;
            txtPlate.CustomizableEdges = customizableEdges9;
            txtPlate.DefaultText = "";
            txtPlate.FillColor = Color.FromArgb(30, 30, 33);
            txtPlate.FocusedState.BorderColor = Color.FromArgb(31, 138, 154);
            txtPlate.Font = new Font("Segoe UI", 10F);
            txtPlate.ForeColor = Color.White;
            txtPlate.HoverState.BorderColor = Color.FromArgb(120, 120, 130);
            txtPlate.Location = new Point(20, 40);
            txtPlate.Name = "txtPlate";
            txtPlate.PasswordChar = '\0';
            txtPlate.PlaceholderForeColor = Color.FromArgb(110, 110, 120);
            txtPlate.PlaceholderText = "VD: 59A-12345";
            txtPlate.SelectedText = "";
            txtPlate.ShadowDecoration.CustomizableEdges = customizableEdges10;
            txtPlate.Size = new Size(240, 36);
            txtPlate.TabIndex = 1;
            // 
            // lblType
            // 
            lblType.AutoSize = true;
            lblType.Font = new Font("Segoe UI", 9F);
            lblType.ForeColor = Color.FromArgb(160, 160, 166);
            lblType.Location = new Point(290, 18);
            lblType.Name = "lblType";
            lblType.Size = new Size(43, 15);
            lblType.TabIndex = 2;
            lblType.Text = "Loại xe";
            // 
            // cmbVehicleType
            // 
            cmbVehicleType.BackColor = Color.Transparent;
            cmbVehicleType.BorderColor = Color.FromArgb(63, 63, 70);
            cmbVehicleType.BorderRadius = 8;
            cmbVehicleType.CustomizableEdges = customizableEdges11;
            cmbVehicleType.DrawMode = DrawMode.OwnerDrawFixed;
            cmbVehicleType.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbVehicleType.FillColor = Color.FromArgb(30, 30, 33);
            cmbVehicleType.FocusedColor = Color.FromArgb(31, 138, 154);
            cmbVehicleType.FocusedState.BorderColor = Color.FromArgb(31, 138, 154);
            cmbVehicleType.Font = new Font("Segoe UI", 10F);
            cmbVehicleType.ForeColor = Color.White;
            cmbVehicleType.HoverState.BorderColor = Color.FromArgb(120, 120, 130);
            cmbVehicleType.ItemHeight = 26;
            cmbVehicleType.Items.AddRange(new object[] { "Xe máy", "Xe đạp", "Ô tô" });
            cmbVehicleType.Location = new Point(290, 40);
            cmbVehicleType.Name = "cmbVehicleType";
            cmbVehicleType.ShadowDecoration.CustomizableEdges = customizableEdges12;
            cmbVehicleType.Size = new Size(180, 32);
            cmbVehicleType.TabIndex = 3;
            // 
            // lblSlots
            // 
            lblSlots.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblSlots.AutoSize = true;
            lblSlots.Font = new Font("Segoe UI", 9F);
            lblSlots.ForeColor = Color.FromArgb(160, 160, 166);
            lblSlots.Location = new Point(780, 18);
            lblSlots.Name = "lblSlots";
            lblSlots.Size = new Size(61, 15);
            lblSlots.TabIndex = 4;
            lblSlots.Text = "Chỗ trống";
            // 
            // lblSlotsValue
            // 
            lblSlotsValue.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblSlotsValue.AutoSize = true;
            lblSlotsValue.Font = new Font("Segoe UI", 17F, FontStyle.Bold);
            lblSlotsValue.ForeColor = Color.FromArgb(34, 197, 94);
            lblSlotsValue.Location = new Point(780, 40);
            lblSlotsValue.Name = "lblSlotsValue";
            lblSlotsValue.Size = new Size(88, 31);
            lblSlotsValue.TabIndex = 5;
            lblSlotsValue.Text = "15 / 30";
            // 
            // pnlGrid
            // 
            pnlGrid.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnlGrid.BackColor = Color.FromArgb(31, 31, 34);
            pnlGrid.BorderRadius = 14;
            pnlGrid.Controls.Add(lblLogTitle);
            pnlGrid.Controls.Add(dgvParkingLog);
            pnlGrid.CustomizableEdges = customizableEdges15;
            pnlGrid.Location = new Point(20, 215);
            pnlGrid.Name = "pnlGrid";
            pnlGrid.ShadowDecoration.CustomizableEdges = customizableEdges16;
            pnlGrid.Size = new Size(960, 430);
            pnlGrid.TabIndex = 2;
            // 
            // lblLogTitle
            // 
            lblLogTitle.AutoSize = true;
            lblLogTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblLogTitle.ForeColor = Color.White;
            lblLogTitle.Location = new Point(20, 16);
            lblLogTitle.Name = "lblLogTitle";
            lblLogTitle.Size = new Size(105, 20);
            lblLogTitle.TabIndex = 0;
            lblLogTitle.Text = "Lịch sử ra vào";
            // 
            // dgvParkingLog
            // 
            dataGridViewCellStyle1.BackColor = Color.FromArgb(24, 24, 27);
            dataGridViewCellStyle1.ForeColor = Color.FromArgb(220, 220, 225);
            dgvParkingLog.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvParkingLog.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvParkingLog.BackgroundColor = Color.FromArgb(24, 24, 27);
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(31, 31, 34);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(160, 160, 166);
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(31, 31, 34);
            dataGridViewCellStyle2.SelectionForeColor = Color.FromArgb(160, 160, 166);
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvParkingLog.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvParkingLog.Columns.AddRange(new DataGridViewColumn[] { colPlate, colVehicleType, colTimeIn, colTimeOut, colStatus });
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.FromArgb(24, 24, 27);
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(220, 220, 225);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(31, 138, 154);
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(240, 240, 245);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvParkingLog.DefaultCellStyle = dataGridViewCellStyle3;
            dgvParkingLog.GridColor = Color.FromArgb(45, 45, 48);
            dgvParkingLog.Location = new Point(18, 52);
            dgvParkingLog.Name = "dgvParkingLog";
            dgvParkingLog.RowHeadersVisible = false;
            dgvParkingLog.Size = new Size(924, 360);
            dgvParkingLog.TabIndex = 1;
            dgvParkingLog.ThemeStyle.AlternatingRowsStyle.BackColor = Color.FromArgb(24, 24, 27);
            dgvParkingLog.ThemeStyle.AlternatingRowsStyle.Font = null;
            dgvParkingLog.ThemeStyle.AlternatingRowsStyle.ForeColor = Color.FromArgb(220, 220, 225);
            dgvParkingLog.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.Empty;
            dgvParkingLog.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.Empty;
            dgvParkingLog.ThemeStyle.BackColor = Color.FromArgb(24, 24, 27);
            dgvParkingLog.ThemeStyle.GridColor = Color.FromArgb(45, 45, 48);
            dgvParkingLog.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(31, 31, 34);
            dgvParkingLog.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvParkingLog.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dgvParkingLog.ThemeStyle.HeaderStyle.ForeColor = Color.FromArgb(160, 160, 166);
            dgvParkingLog.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvParkingLog.ThemeStyle.HeaderStyle.Height = 23;
            dgvParkingLog.ThemeStyle.ReadOnly = false;
            dgvParkingLog.ThemeStyle.RowsStyle.BackColor = Color.FromArgb(24, 24, 27);
            dgvParkingLog.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvParkingLog.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 9F);
            dgvParkingLog.ThemeStyle.RowsStyle.ForeColor = Color.FromArgb(220, 220, 225);
            dgvParkingLog.ThemeStyle.RowsStyle.Height = 25;
            dgvParkingLog.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(31, 138, 154);
            dgvParkingLog.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(240, 240, 245);
            // 
            // colPlate
            // 
            colPlate.DataPropertyName = "Biển số";
            colPlate.HeaderText = "Biển số";
            colPlate.Name = "Biển số";
            // 
            // colVehicleType
            // 
            colVehicleType.DataPropertyName = "Loại xe";
            colVehicleType.HeaderText = "Loại xe";
            colVehicleType.Name = "Loại xe";
            // 
            // colTimeIn
            // 
            colTimeIn.DataPropertyName = "Giờ vào";
            colTimeIn.HeaderText = "Giờ vào";
            colTimeIn.Name = "Giờ vào";
            // 
            // colTimeOut
            // 
            colTimeOut.DataPropertyName = "Giờ ra";
            colTimeOut.HeaderText = "Giờ ra";
            colTimeOut.Name = "Giờ ra";
            // 
            // colStatus
            // 
            colStatus.DataPropertyName = "Trạng thái";
            colStatus.HeaderText = "Trạng thái";
            colStatus.Name = "Trạng thái";
            // 
            // ucParking_Security
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(39, 39, 42);
            Controls.Add(pnlHeader);
            Controls.Add(pnlInfo);
            Controls.Add(pnlGrid);
            Name = "ucParking_Security";
            Size = new Size(1000, 665);
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            pnlInfo.ResumeLayout(false);
            pnlInfo.PerformLayout();
            pnlGrid.ResumeLayout(false);
            pnlGrid.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvParkingLog).EndInit();
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

        private Guna2Panel pnlHeader;
        private Label lblTitle;
        private Guna2Button btnVehicleIn;
        private Guna2Button btnVehicleOut;
        private Guna2Panel pnlInfo;
        private Label lblPlate;
        private Guna2TextBox txtPlate;
        private Label lblType;
        private Guna2ComboBox cmbVehicleType;
        private Label lblSlots;
        private Label lblSlotsValue;
        private Guna2Panel pnlGrid;
        private Label lblLogTitle;
        private Guna2DataGridView dgvParkingLog;
        private DataGridViewTextBoxColumn colPlate;
        private DataGridViewTextBoxColumn colVehicleType;
        private DataGridViewTextBoxColumn colTimeIn;
        private DataGridViewTextBoxColumn colTimeOut;
        private DataGridViewTextBoxColumn colStatus;
        private Guna2Button btnReport;
    }
}
