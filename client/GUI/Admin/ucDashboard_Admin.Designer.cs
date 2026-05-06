using System.Drawing;
using System.Windows.Forms;

namespace GUI
{
    partial class ucDashboard_Admin
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
            // === TOP SUMMARY ===
            pnlSummary = new Panel();
            lblRevenueTitle = new Label();
            lblRevenueValue = new Label();
            lblProfitTitle = new Label();
            lblProfitValue = new Label();
            lblExpensesTitle = new Label();
            lblExpensesValue = new Label();
            lblLossTitle = new Label();
            lblLossValue = new Label();

            // === REVENUE DETAIL PANEL ===
            pnlRevenueDetail = new Panel();
            lblRevenueDetailTitle = new Label();
            dgvRevenueDetail = new DataGridView();

            // === CHART PANEL ===
            pnlChart = new Panel();
            lblChartTitle = new Label();
            btnDay = new Button();
            btnMonth = new Button();
            btnYear = new Button();
            pnlChartArea = new Panel();

            // === FEEDBACK SUMMARY ===
            pnlFeedbackSummary = new Panel();
            lblFeedbackSummaryTitle = new Label();
            btnFBMonth = new Button();
            btnFBQuarter = new Button();
            btnFBYear = new Button();
            lblGoodFeedback = new Label();
            lblBadFeedback = new Label();
            pnlFBChartArea = new Panel();

            pnlSummary.SuspendLayout();
            pnlRevenueDetail.SuspendLayout();
            pnlChart.SuspendLayout();
            pnlFeedbackSummary.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRevenueDetail).BeginInit();
            SuspendLayout();

            // =====================
            // pnlSummary (4 cards)
            // =====================
            pnlSummary.BackColor = Color.FromArgb(30, 30, 30);
            pnlSummary.Controls.Add(lblLossValue);
            pnlSummary.Controls.Add(lblLossTitle);
            pnlSummary.Controls.Add(lblExpensesValue);
            pnlSummary.Controls.Add(lblExpensesTitle);
            pnlSummary.Controls.Add(lblProfitValue);
            pnlSummary.Controls.Add(lblProfitTitle);
            pnlSummary.Controls.Add(lblRevenueValue);
            pnlSummary.Controls.Add(lblRevenueTitle);
            pnlSummary.Location = new Point(20, 10);
            pnlSummary.Name = "pnlSummary";
            pnlSummary.Size = new Size(764, 70);
            pnlSummary.TabIndex = 0;

            // Revenue
            lblRevenueTitle.AutoSize = true;
            lblRevenueTitle.Font = new Font("Segoe UI", 9F);
            lblRevenueTitle.ForeColor = Color.Gray;
            lblRevenueTitle.Location = new Point(15, 8);
            lblRevenueTitle.Name = "lblRevenueTitle";
            lblRevenueTitle.Text = "Doanh thu";
            lblRevenueValue.AutoSize = true;
            lblRevenueValue.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblRevenueValue.ForeColor = Color.MediumSeaGreen;
            lblRevenueValue.Location = new Point(15, 30);
            lblRevenueValue.Name = "lblRevenueValue";
            lblRevenueValue.Text = "0 đ";

            // Profit
            lblProfitTitle.AutoSize = true;
            lblProfitTitle.Font = new Font("Segoe UI", 9F);
            lblProfitTitle.ForeColor = Color.Gray;
            lblProfitTitle.Location = new Point(200, 8);
            lblProfitTitle.Name = "lblProfitTitle";
            lblProfitTitle.Text = "Lợi nhuận ròng";
            lblProfitValue.AutoSize = true;
            lblProfitValue.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblProfitValue.ForeColor = Color.SteelBlue;
            lblProfitValue.Location = new Point(200, 30);
            lblProfitValue.Name = "lblProfitValue";
            lblProfitValue.Text = "0 đ";

            // Expenses
            lblExpensesTitle.AutoSize = true;
            lblExpensesTitle.Font = new Font("Segoe UI", 9F);
            lblExpensesTitle.ForeColor = Color.Gray;
            lblExpensesTitle.Location = new Point(400, 8);
            lblExpensesTitle.Name = "lblExpensesTitle";
            lblExpensesTitle.Text = "Tổng chi phí";
            lblExpensesValue.AutoSize = true;
            lblExpensesValue.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblExpensesValue.ForeColor = Color.IndianRed;
            lblExpensesValue.Location = new Point(400, 30);
            lblExpensesValue.Name = "lblExpensesValue";
            lblExpensesValue.Text = "0 đ";

            // Loss
            lblLossTitle.AutoSize = true;
            lblLossTitle.Font = new Font("Segoe UI", 9F);
            lblLossTitle.ForeColor = Color.Gray;
            lblLossTitle.Location = new Point(600, 8);
            lblLossTitle.Name = "lblLossTitle";
            lblLossTitle.Text = "Thất thoát";
            lblLossValue.AutoSize = true;
            lblLossValue.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblLossValue.ForeColor = Color.Orange;
            lblLossValue.Location = new Point(600, 30);
            lblLossValue.Name = "lblLossValue";
            lblLossValue.Text = "0 đ";

            // ========================
            // pnlRevenueDetail (grid)
            // ========================
            pnlRevenueDetail.BackColor = Color.FromArgb(30, 30, 30);
            pnlRevenueDetail.Controls.Add(lblRevenueDetailTitle);
            pnlRevenueDetail.Controls.Add(dgvRevenueDetail);
            pnlRevenueDetail.Location = new Point(20, 88);
            pnlRevenueDetail.Name = "pnlRevenueDetail";
            pnlRevenueDetail.Size = new Size(370, 200);
            pnlRevenueDetail.TabIndex = 1;

            lblRevenueDetailTitle.AutoSize = true;
            lblRevenueDetailTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblRevenueDetailTitle.ForeColor = Color.White;
            lblRevenueDetailTitle.Location = new Point(12, 10);
            lblRevenueDetailTitle.Name = "lblRevenueDetailTitle";
            lblRevenueDetailTitle.Text = "Chi tiết từng khoản";

            dgvStyle.BackColor = Color.FromArgb(45, 45, 48);
            dgvStyle.Font = new Font("Segoe UI", 9F);
            dgvStyle.ForeColor = Color.White;
            dgvStyle.SelectionBackColor = Color.Gray;
            dgvStyle.SelectionForeColor = Color.White;

            dgvRevenueDetail.AllowUserToAddRows = false;
            dgvRevenueDetail.BackgroundColor = Color.FromArgb(45, 45, 48);
            dgvRevenueDetail.BorderStyle = BorderStyle.None;
            dgvRevenueDetail.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRevenueDetail.DefaultCellStyle = dgvStyle;
            dgvRevenueDetail.Location = new Point(12, 35);
            dgvRevenueDetail.Name = "dgvRevenueDetail";
            dgvRevenueDetail.ReadOnly = true;
            dgvRevenueDetail.RowHeadersVisible = false;
            dgvRevenueDetail.RowHeadersWidth = 51;
            dgvRevenueDetail.Size = new Size(346, 155);
            dgvRevenueDetail.TabIndex = 1;

            // ========================
            // pnlChart (biểu đồ doanh thu)
            // ========================
            pnlChart.BackColor = Color.FromArgb(30, 30, 30);
            pnlChart.Controls.Add(pnlChartArea);
            pnlChart.Controls.Add(btnYear);
            pnlChart.Controls.Add(btnMonth);
            pnlChart.Controls.Add(btnDay);
            pnlChart.Controls.Add(lblChartTitle);
            pnlChart.Location = new Point(400, 88);
            pnlChart.Name = "pnlChart";
            pnlChart.Size = new Size(384, 200);
            pnlChart.TabIndex = 2;

            lblChartTitle.AutoSize = true;
            lblChartTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblChartTitle.ForeColor = Color.White;
            lblChartTitle.Location = new Point(12, 10);
            lblChartTitle.Name = "lblChartTitle";
            lblChartTitle.Text = "Biểu đồ doanh thu";

            btnDay.BackColor = Color.SteelBlue;
            btnDay.FlatAppearance.BorderSize = 0;
            btnDay.FlatStyle = FlatStyle.Flat;
            btnDay.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            btnDay.ForeColor = Color.White;
            btnDay.Location = new Point(220, 8);
            btnDay.Name = "btnDay";
            btnDay.Size = new Size(48, 24);
            btnDay.TabIndex = 1;
            btnDay.Text = "Ngày";
            btnDay.Cursor = Cursors.Hand;
            btnDay.Click += btnDay_Click;

            btnMonth.BackColor = Color.FromArgb(60, 60, 65);
            btnMonth.FlatAppearance.BorderSize = 0;
            btnMonth.FlatStyle = FlatStyle.Flat;
            btnMonth.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            btnMonth.ForeColor = Color.White;
            btnMonth.Location = new Point(275, 8);
            btnMonth.Name = "btnMonth";
            btnMonth.Size = new Size(48, 24);
            btnMonth.TabIndex = 2;
            btnMonth.Text = "Tháng";
            btnMonth.Cursor = Cursors.Hand;
            btnMonth.Click += btnMonth_Click;

            btnYear.BackColor = Color.FromArgb(60, 60, 65);
            btnYear.FlatAppearance.BorderSize = 0;
            btnYear.FlatStyle = FlatStyle.Flat;
            btnYear.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            btnYear.ForeColor = Color.White;
            btnYear.Location = new Point(330, 8);
            btnYear.Name = "btnYear";
            btnYear.Size = new Size(42, 24);
            btnYear.TabIndex = 3;
            btnYear.Text = "Năm";
            btnYear.Cursor = Cursors.Hand;
            btnYear.Click += btnYear_Click;

            pnlChartArea.BackColor = Color.FromArgb(45, 45, 48);
            pnlChartArea.Location = new Point(12, 40);
            pnlChartArea.Name = "pnlChartArea";
            pnlChartArea.Size = new Size(360, 150);
            pnlChartArea.TabIndex = 4;

            // ========================
            // pnlFeedbackSummary
            // ========================
            pnlFeedbackSummary.BackColor = Color.FromArgb(30, 30, 30);
            pnlFeedbackSummary.Controls.Add(lblFeedbackSummaryTitle);
            pnlFeedbackSummary.Controls.Add(btnFBMonth);
            pnlFeedbackSummary.Controls.Add(btnFBQuarter);
            pnlFeedbackSummary.Controls.Add(btnFBYear);
            pnlFeedbackSummary.Controls.Add(lblGoodFeedback);
            pnlFeedbackSummary.Controls.Add(lblBadFeedback);
            pnlFeedbackSummary.Controls.Add(pnlFBChartArea);
            pnlFeedbackSummary.Location = new Point(20, 296);
            pnlFeedbackSummary.Name = "pnlFeedbackSummary";
            pnlFeedbackSummary.Size = new Size(764, 225);
            pnlFeedbackSummary.TabIndex = 3;

            lblFeedbackSummaryTitle.AutoSize = true;
            lblFeedbackSummaryTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblFeedbackSummaryTitle.ForeColor = Color.White;
            lblFeedbackSummaryTitle.Location = new Point(12, 10);
            lblFeedbackSummaryTitle.Name = "lblFeedbackSummaryTitle";
            lblFeedbackSummaryTitle.Text = "Feedback tốt / xấu";

            btnFBMonth.BackColor = Color.SteelBlue;
            btnFBMonth.FlatAppearance.BorderSize = 0;
            btnFBMonth.FlatStyle = FlatStyle.Flat;
            btnFBMonth.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            btnFBMonth.ForeColor = Color.White;
            btnFBMonth.Location = new Point(560, 8);
            btnFBMonth.Name = "btnFBMonth";
            btnFBMonth.Size = new Size(55, 24);
            btnFBMonth.Text = "Tháng";
            btnFBMonth.Cursor = Cursors.Hand;
            btnFBMonth.Click += btnFBMonth_Click;

            btnFBQuarter.BackColor = Color.FromArgb(60, 60, 65);
            btnFBQuarter.FlatAppearance.BorderSize = 0;
            btnFBQuarter.FlatStyle = FlatStyle.Flat;
            btnFBQuarter.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            btnFBQuarter.ForeColor = Color.White;
            btnFBQuarter.Location = new Point(622, 8);
            btnFBQuarter.Name = "btnFBQuarter";
            btnFBQuarter.Size = new Size(42, 24);
            btnFBQuarter.Text = "Quý";
            btnFBQuarter.Cursor = Cursors.Hand;
            btnFBQuarter.Click += btnFBQuarter_Click;

            btnFBYear.BackColor = Color.FromArgb(60, 60, 65);
            btnFBYear.FlatAppearance.BorderSize = 0;
            btnFBYear.FlatStyle = FlatStyle.Flat;
            btnFBYear.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            btnFBYear.ForeColor = Color.White;
            btnFBYear.Location = new Point(671, 8);
            btnFBYear.Name = "btnFBYear";
            btnFBYear.Size = new Size(42, 24);
            btnFBYear.Text = "Năm";
            btnFBYear.Cursor = Cursors.Hand;
            btnFBYear.Click += btnFBYear_Click;

            lblGoodFeedback.AutoSize = true;
            lblGoodFeedback.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblGoodFeedback.ForeColor = Color.MediumSeaGreen;
            lblGoodFeedback.Location = new Point(12, 42);
            lblGoodFeedback.Name = "lblGoodFeedback";
            lblGoodFeedback.Text = "Tốt: 42 (84%)";

            lblBadFeedback.AutoSize = true;
            lblBadFeedback.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblBadFeedback.ForeColor = Color.IndianRed;
            lblBadFeedback.Location = new Point(180, 42);
            lblBadFeedback.Name = "lblBadFeedback";
            lblBadFeedback.Text = "Xấu: 8 (16%)";

            pnlFBChartArea.BackColor = Color.FromArgb(45, 45, 48);
            pnlFBChartArea.Location = new Point(12, 68);
            pnlFBChartArea.Name = "pnlFBChartArea";
            pnlFBChartArea.Size = new Size(740, 145);
            pnlFBChartArea.TabIndex = 6;

            // ========================
            // ucDashboard_Admin
            // ========================
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(45, 45, 48);
            Controls.Add(pnlFeedbackSummary);
            Controls.Add(pnlChart);
            Controls.Add(pnlRevenueDetail);
            Controls.Add(pnlSummary);
            Name = "ucDashboard_Admin";
            Size = new Size(804, 530);
            Load += ucDashboard_Admin_Load;
            pnlSummary.ResumeLayout(false);
            pnlSummary.PerformLayout();
            pnlRevenueDetail.ResumeLayout(false);
            pnlRevenueDetail.PerformLayout();
            pnlChart.ResumeLayout(false);
            pnlChart.PerformLayout();
            pnlFeedbackSummary.ResumeLayout(false);
            pnlFeedbackSummary.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRevenueDetail).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlSummary;
        private Label lblRevenueTitle;
        private Label lblRevenueValue;
        private Label lblProfitTitle;
        private Label lblProfitValue;
        private Label lblExpensesTitle;
        private Label lblExpensesValue;
        private Label lblLossTitle;
        private Label lblLossValue;

        private Panel pnlRevenueDetail;
        private Label lblRevenueDetailTitle;
        private DataGridView dgvRevenueDetail;

        private Panel pnlChart;
        private Label lblChartTitle;
        private Button btnDay;
        private Button btnMonth;
        private Button btnYear;
        private Panel pnlChartArea;

        private Panel pnlFeedbackSummary;
        private Label lblFeedbackSummaryTitle;
        private Button btnFBMonth;
        private Button btnFBQuarter;
        private Button btnFBYear;
        private Label lblGoodFeedback;
        private Label lblBadFeedback;
        private Panel pnlFBChartArea;
    }
}
