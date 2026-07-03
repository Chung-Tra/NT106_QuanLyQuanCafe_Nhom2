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
            pnlHeader.SuspendLayout();
            pnlInfo.SuspendLayout();
            pnlGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvParkingLog).BeginInit();
            SuspendLayout();

            // ====== pnlHeader ======
            pnlHeader.BackColor = Color.FromArgb(31, 31, 34);
            pnlHeader.BorderRadius = 14;
            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Controls.Add(btnReport);
            pnlHeader.Controls.Add(btnVehicleIn);
            pnlHeader.Controls.Add(btnVehicleOut);
            pnlHeader.Location = new Point(20, 20);
            pnlHeader.Size = new Size(900, 70);

            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(18, 22);
            lblTitle.Text = "🅿️  Quản lý bãi xe";

            btnReport.BorderRadius = 10;
            btnReport.Cursor = Cursors.Hand;
            btnReport.FillColor = Color.FromArgb(31, 138, 154);
            btnReport.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnReport.ForeColor = Color.White;
            btnReport.HoverState.FillColor = Color.FromArgb(45, 158, 174);
            btnReport.Location = new Point(528, 18);
            btnReport.Size = new Size(110, 34);
            btnReport.Text = "📊 Báo cáo";

            btnVehicleIn.BorderRadius = 10;
            btnVehicleIn.Cursor = Cursors.Hand;
            btnVehicleIn.FillColor = Color.FromArgb(34, 197, 94);
            btnVehicleIn.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnVehicleIn.ForeColor = Color.White;
            btnVehicleIn.HoverState.FillColor = Color.FromArgb(45, 207, 104);
            btnVehicleIn.Location = new Point(648, 18);
            btnVehicleIn.Size = new Size(110, 34);
            btnVehicleIn.Text = "Xe vào";
            btnVehicleIn.Click += btnVehicleIn_Click;

            btnVehicleOut.BorderRadius = 10;
            btnVehicleOut.Cursor = Cursors.Hand;
            btnVehicleOut.FillColor = Color.FromArgb(220, 80, 80);
            btnVehicleOut.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnVehicleOut.ForeColor = Color.White;
            btnVehicleOut.HoverState.FillColor = Color.FromArgb(180, 60, 60);
            btnVehicleOut.Location = new Point(768, 18);
            btnVehicleOut.Size = new Size(110, 34);
            btnVehicleOut.Text = "Xe ra";
            btnVehicleOut.Click += btnVehicleOut_Click;

            // ====== pnlInfo ======
            pnlInfo.BackColor = Color.FromArgb(31, 31, 34);
            pnlInfo.BorderRadius = 14;
            pnlInfo.Controls.Add(lblPlate);
            pnlInfo.Controls.Add(txtPlate);
            pnlInfo.Controls.Add(lblType);
            pnlInfo.Controls.Add(cmbVehicleType);
            pnlInfo.Controls.Add(lblSlots);
            pnlInfo.Controls.Add(lblSlotsValue);
            pnlInfo.Location = new Point(20, 105);
            pnlInfo.Size = new Size(900, 95);

            lblPlate.AutoSize = true;
            lblPlate.Font = new Font("Segoe UI", 9F);
            lblPlate.ForeColor = Color.FromArgb(160, 160, 166);
            lblPlate.Location = new Point(20, 18);
            lblPlate.Text = "Biển số";

            txtPlate.BorderColor = Color.FromArgb(63, 63, 70);
            txtPlate.BorderRadius = 10;
            txtPlate.FillColor = Color.FromArgb(30, 30, 33);
            txtPlate.FocusedState.BorderColor = Color.FromArgb(31, 138, 154);
            txtPlate.Font = new Font("Segoe UI", 10F);
            txtPlate.ForeColor = Color.White;
            txtPlate.HoverState.BorderColor = Color.FromArgb(120, 120, 130);
            txtPlate.Location = new Point(20, 40);
            txtPlate.PlaceholderForeColor = Color.FromArgb(110, 110, 120);
            txtPlate.PlaceholderText = "VD: 59A-12345";
            txtPlate.Size = new Size(240, 36);

            lblType.AutoSize = true;
            lblType.Font = new Font("Segoe UI", 9F);
            lblType.ForeColor = Color.FromArgb(160, 160, 166);
            lblType.Location = new Point(290, 18);
            lblType.Text = "Loại xe";

            cmbVehicleType.BackColor = Color.Transparent;
            cmbVehicleType.BorderColor = Color.FromArgb(63, 63, 70);
            cmbVehicleType.BorderRadius = 8;
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
            cmbVehicleType.Size = new Size(180, 36);

            lblSlots.AutoSize = true;
            lblSlots.Font = new Font("Segoe UI", 9F);
            lblSlots.ForeColor = Color.FromArgb(160, 160, 166);
            lblSlots.Location = new Point(720, 18);
            lblSlots.Text = "Chỗ trống";

            lblSlotsValue.AutoSize = true;
            lblSlotsValue.Font = new Font("Segoe UI", 17F, FontStyle.Bold);
            lblSlotsValue.ForeColor = Color.FromArgb(34, 197, 94);
            lblSlotsValue.Location = new Point(720, 40);
            lblSlotsValue.Text = "15 / 30";

            // ====== pnlGrid ======
            pnlGrid.BackColor = Color.FromArgb(31, 31, 34);
            pnlGrid.BorderRadius = 14;
            pnlGrid.Controls.Add(lblLogTitle);
            pnlGrid.Controls.Add(dgvParkingLog);
            pnlGrid.Location = new Point(20, 215);
            pnlGrid.Size = new Size(900, 425);

            lblLogTitle.AutoSize = true;
            lblLogTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblLogTitle.ForeColor = Color.White;
            lblLogTitle.Location = new Point(20, 16);
            lblLogTitle.Text = "Lịch sử ra vào";

            dgvParkingLog.BackgroundColor = Color.FromArgb(24, 24, 27);
            dgvParkingLog.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(31, 31, 34);
            dgvParkingLog.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(160, 160, 166);
            dgvParkingLog.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dgvParkingLog.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(31, 31, 34);
            dgvParkingLog.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.FromArgb(160, 160, 166);
            dgvParkingLog.DefaultCellStyle.BackColor = Color.FromArgb(24, 24, 27);
            dgvParkingLog.DefaultCellStyle.ForeColor = Color.FromArgb(220, 220, 225);
            dgvParkingLog.DefaultCellStyle.SelectionBackColor = Color.FromArgb(31, 138, 154);
            dgvParkingLog.DefaultCellStyle.SelectionForeColor = Color.FromArgb(240, 240, 245);
            dgvParkingLog.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(24, 24, 27);
            dgvParkingLog.AlternatingRowsDefaultCellStyle.ForeColor = Color.FromArgb(220, 220, 225);
            dgvParkingLog.GridColor = Color.FromArgb(45, 45, 48);
            ConfigureGrid(dgvParkingLog);
            dgvParkingLog.Location = new Point(18, 52);
            dgvParkingLog.Size = new Size(864, 355);

            // ====== ucParking_Security ======
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(39, 39, 42);
            Controls.Add(pnlHeader);
            Controls.Add(pnlInfo);
            Controls.Add(pnlGrid);
            Name = "ucParking_Security";
            Size = new Size(940, 660);
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
        private Guna2Button btnReport;
    }
}
