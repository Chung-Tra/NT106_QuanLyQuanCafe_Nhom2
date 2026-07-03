using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using Guna.Charts.WinForms;

namespace GUI
{
    partial class ucLoss_Manager
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        private void InitializeComponent()
        {
            Guna.UI2.WinForms.Suite.CustomizableEdges ce1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges ce2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges ce3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges ce4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges ce5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges ce6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges ce7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges ce8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges ce9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges ce10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges ce11 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges ce12 = new Guna.UI2.WinForms.Suite.CustomizableEdges();

            pnlHeader = new Guna2Panel();
            lblTitle = new Label();
            btnDay = new Guna2Button();
            btnMonth = new Guna2Button();
            btnYear = new Guna2Button();
            lblTotalLoss = new Label();
            btnReport = new Guna2Button();
            btnEditLoss = new Guna2Button();
            pnlChart = new Guna2Panel();
            chartLoss = new GunaChart();
            pnlDetail = new Guna2Panel();
            lblDetail = new Label();
            dgvLossDetail = new Guna2DataGridView();
            colItem = new DataGridViewTextBoxColumn();
            colQty = new DataGridViewTextBoxColumn();
            colValue = new DataGridViewTextBoxColumn();
            colCause = new DataGridViewTextBoxColumn();
            colReporter = new DataGridViewTextBoxColumn();

            pnlHeader.SuspendLayout();
            pnlChart.SuspendLayout();
            pnlDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvLossDetail).BeginInit();
            SuspendLayout();

            // ====== pnlHeader ======
            pnlHeader.BackColor = Color.FromArgb(31, 31, 34);
            pnlHeader.BorderRadius = 14;
            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Controls.Add(btnDay);
            pnlHeader.Controls.Add(btnMonth);
            pnlHeader.Controls.Add(btnYear);
            pnlHeader.Controls.Add(lblTotalLoss);
            pnlHeader.Controls.Add(btnReport);
            pnlHeader.Controls.Add(btnEditLoss);
            pnlHeader.CustomizableEdges = ce1;
            pnlHeader.Location = new Point(20, 20);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.ShadowDecoration.CustomizableEdges = ce2;
            pnlHeader.Size = new Size(960, 90);
            pnlHeader.TabIndex = 0;

            // ------ lblTitle ------
            lblTitle.AutoSize = true;
            lblTitle.BackColor = Color.Transparent;
            lblTitle.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(18, 16);
            lblTitle.Name = "lblTitle";
            lblTitle.Text = "Thất thoát & Hao phí";

            // ------ btnDay ------
            btnDay.BorderRadius = 8;
            btnDay.Cursor = Cursors.Hand;
            btnDay.CustomizableEdges = ce3;
            btnDay.FillColor = Color.FromArgb(45, 45, 48);
            btnDay.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnDay.ForeColor = Color.White;
            btnDay.HoverState.FillColor = Color.FromArgb(60, 60, 65);
            btnDay.Location = new Point(18, 50);
            btnDay.Name = "btnDay";
            btnDay.ShadowDecoration.CustomizableEdges = ce4;
            btnDay.Size = new Size(80, 30);
            btnDay.TabIndex = 1;
            btnDay.Text = "Ngày";
            btnDay.Click += BtnDay_Click;

            // ------ btnMonth ------
            btnMonth.BorderRadius = 8;
            btnMonth.Cursor = Cursors.Hand;
            btnMonth.CustomizableEdges = ce5;
            btnMonth.FillColor = Color.FromArgb(31, 138, 154);
            btnMonth.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnMonth.ForeColor = Color.White;
            btnMonth.HoverState.FillColor = Color.FromArgb(45, 158, 174);
            btnMonth.Location = new Point(104, 50);
            btnMonth.Name = "btnMonth";
            btnMonth.ShadowDecoration.CustomizableEdges = ce6;
            btnMonth.Size = new Size(80, 30);
            btnMonth.TabIndex = 2;
            btnMonth.Text = "Tháng";
            btnMonth.Click += BtnMonth_Click;

            // ------ btnYear ------
            btnYear.BorderRadius = 8;
            btnYear.Cursor = Cursors.Hand;
            btnYear.CustomizableEdges = ce7;
            btnYear.FillColor = Color.FromArgb(45, 45, 48);
            btnYear.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnYear.ForeColor = Color.White;
            btnYear.HoverState.FillColor = Color.FromArgb(60, 60, 65);
            btnYear.Location = new Point(190, 50);
            btnYear.Name = "btnYear";
            btnYear.ShadowDecoration.CustomizableEdges = ce8;
            btnYear.Size = new Size(80, 30);
            btnYear.TabIndex = 3;
            btnYear.Text = "Năm";
            btnYear.Click += BtnYear_Click;

            // ------ lblTotalLoss ------
            lblTotalLoss.AutoSize = true;
            lblTotalLoss.BackColor = Color.Transparent;
            lblTotalLoss.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblTotalLoss.ForeColor = Color.FromArgb(220, 80, 80);
            lblTotalLoss.Location = new Point(310, 56);
            lblTotalLoss.Name = "lblTotalLoss";
            lblTotalLoss.Text = "Tổng thất thoát: 0 đ";

            // ------ btnReport ------
            btnReport.BorderColor = Color.FromArgb(180, 60, 60);
            btnReport.BorderRadius = 8;
            btnReport.BorderThickness = 1;
            btnReport.Cursor = Cursors.Hand;
            btnReport.CustomizableEdges = ce9;
            btnReport.FillColor = Color.Transparent;
            btnReport.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnReport.ForeColor = Color.FromArgb(220, 80, 80);
            btnReport.HoverState.FillColor = Color.FromArgb(180, 60, 60);
            btnReport.HoverState.ForeColor = Color.White;
            btnReport.Location = new Point(790, 50);
            btnReport.Name = "btnReport";
            btnReport.ShadowDecoration.CustomizableEdges = ce10;
            btnReport.Size = new Size(150, 30);
            btnReport.TabIndex = 4;
            btnReport.Text = "Báo cáo sự cố";
            btnReport.Click += BtnReport_Click;

            // ------ btnEditLoss ------
            btnEditLoss.BorderColor = Color.FromArgb(80, 80, 90);
            btnEditLoss.BorderRadius = 8;
            btnEditLoss.BorderThickness = 1;
            btnEditLoss.Cursor = Cursors.Hand;
            btnEditLoss.FillColor = Color.Transparent;
            btnEditLoss.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnEditLoss.ForeColor = Color.FromArgb(220, 220, 225);
            btnEditLoss.HoverState.FillColor = Color.FromArgb(45, 45, 50);
            btnEditLoss.Location = new Point(628, 50);
            btnEditLoss.Name = "btnEditLoss";
            btnEditLoss.Size = new Size(150, 30);
            btnEditLoss.TabIndex = 5;
            btnEditLoss.Text = "Sửa khoản chọn";
            btnEditLoss.Click += BtnEditLoss_Click;

            // ====== chartLoss ======
            chartLoss.BackColor = Color.FromArgb(31, 31, 34);
            chartLoss.Dock = DockStyle.Fill;
            chartLoss.Legend.Display = false;
            chartLoss.XAxes.GridLines.Display = false;
            chartLoss.XAxes.Ticks.ForeColor = Color.FromArgb(160, 160, 166);
            chartLoss.YAxes.GridLines.Display = true;
            chartLoss.YAxes.GridLines.Color = Color.FromArgb(63, 63, 70);
            chartLoss.YAxes.Ticks.ForeColor = Color.FromArgb(160, 160, 166);
            chartLoss.YAxes.Ticks.BeginAtZero = true;
            chartLoss.Name = "chartLoss";

            // ====== pnlChart ======
            pnlChart.BackColor = Color.FromArgb(31, 31, 34);
            pnlChart.BorderRadius = 14;
            pnlChart.Controls.Add(chartLoss);
            pnlChart.CustomizableEdges = ce11;
            pnlChart.Location = new Point(20, 125);
            pnlChart.Name = "pnlChart";
            pnlChart.Padding = new System.Windows.Forms.Padding(10, 8, 10, 8);
            pnlChart.ShadowDecoration.CustomizableEdges = ce12;
            pnlChart.Size = new Size(960, 200);
            pnlChart.TabIndex = 1;

            // ====== pnlDetail ======
            pnlDetail.BackColor = Color.FromArgb(31, 31, 34);
            pnlDetail.BorderRadius = 14;
            pnlDetail.Controls.Add(lblDetail);
            pnlDetail.Controls.Add(dgvLossDetail);
            pnlDetail.Location = new Point(20, 340);
            pnlDetail.Name = "pnlDetail";
            pnlDetail.Size = new Size(960, 310);
            pnlDetail.TabIndex = 2;

            // ------ lblDetail ------
            lblDetail.AutoSize = true;
            lblDetail.BackColor = Color.Transparent;
            lblDetail.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblDetail.ForeColor = Color.FromArgb(160, 160, 166);
            lblDetail.Location = new Point(18, 14);
            lblDetail.Name = "lblDetail";
            lblDetail.Text = "Chi tiết từng khoản thất thoát:";

            // ------ dgvLossDetail ------
            dgvLossDetail.BackgroundColor = Color.FromArgb(24, 24, 27);
            dgvLossDetail.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(31, 31, 34);
            dgvLossDetail.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(160, 160, 166);
            dgvLossDetail.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dgvLossDetail.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(31, 31, 34);
            dgvLossDetail.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.FromArgb(160, 160, 166);
            dgvLossDetail.DefaultCellStyle.BackColor = Color.FromArgb(24, 24, 27);
            dgvLossDetail.DefaultCellStyle.ForeColor = Color.FromArgb(220, 220, 225);
            dgvLossDetail.DefaultCellStyle.SelectionBackColor = Color.FromArgb(31, 138, 154);
            dgvLossDetail.DefaultCellStyle.SelectionForeColor = Color.FromArgb(240, 240, 245);
            dgvLossDetail.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(24, 24, 27);
            dgvLossDetail.AlternatingRowsDefaultCellStyle.ForeColor = Color.FromArgb(220, 220, 225);
            dgvLossDetail.GridColor = Color.FromArgb(45, 45, 48);
            ConfigureGrid(dgvLossDetail);            dgvLossDetail.Columns.AddRange(new DataGridViewColumn[] { colItem, colQty, colValue, colCause, colReporter });
            colItem.HeaderText = "Khoản mục"; colItem.Name = "Khoản mục"; colItem.DataPropertyName = "Khoản mục";
            colQty.HeaderText = "Số lượng"; colQty.Name = "Số lượng"; colQty.DataPropertyName = "Số lượng";
            colValue.HeaderText = "Giá trị"; colValue.Name = "Giá trị"; colValue.DataPropertyName = "Giá trị";
            colCause.HeaderText = "Nguyên nhân"; colCause.Name = "Nguyên nhân"; colCause.DataPropertyName = "Nguyên nhân";
            colReporter.HeaderText = "Người phát hiện"; colReporter.Name = "Người phát hiện"; colReporter.DataPropertyName = "Người phát hiện";
            dgvLossDetail.Location = new Point(18, 42);
            dgvLossDetail.Name = "dgvLossDetail";
            dgvLossDetail.Size = new Size(924, 254);
            dgvLossDetail.TabIndex = 0;
            dgvLossDetail.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvLossDetail.CellDoubleClick += DgvLossDetail_CellDoubleClick;

            // ====== ucLoss_Manager ======
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(39, 39, 42);
            Controls.Add(pnlHeader);
            Controls.Add(pnlChart);
            Controls.Add(pnlDetail);
            Font = new Font("Segoe UI", 9F);
            ForeColor = Color.White;
            Name = "ucLoss_Manager";
            Size = new Size(1000, 665);

            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            pnlChart.ResumeLayout(false);
            pnlDetail.ResumeLayout(false);
            pnlDetail.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvLossDetail).EndInit();
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
        private Guna2Button btnDay;
        private Guna2Button btnMonth;
        private Guna2Button btnYear;
        private Label lblTotalLoss;
        private Guna2Button btnReport;
        private Guna2Button btnEditLoss;
        private Guna2Panel pnlChart;
        private GunaChart chartLoss;
        private Guna2Panel pnlDetail;
        private Label lblDetail;
        private Guna2DataGridView dgvLossDetail;
        private DataGridViewTextBoxColumn colItem;
        private DataGridViewTextBoxColumn colQty;
        private DataGridViewTextBoxColumn colValue;
        private DataGridViewTextBoxColumn colCause;
        private DataGridViewTextBoxColumn colReporter;
    }
}
