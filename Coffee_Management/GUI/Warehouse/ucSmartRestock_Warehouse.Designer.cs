using System.Drawing;
using System.Windows.Forms;

namespace GUI
{
    partial class ucSmartRestock_Warehouse
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
            btnApproveAll = new Button();
            btnApproveSelected = new Button();
            pnlInfo = new Panel();
            lblSuggestionsCount = new Label();
            lblSuggestionsTitle = new Label();
            lblEstimatedCost = new Label();
            lblEstimatedCostTitle = new Label();
            pnlGrid = new Panel();
            dgvSuggestions = new DataGridView();
            pnlHeader.SuspendLayout();
            pnlInfo.SuspendLayout();
            pnlGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSuggestions).BeginInit();
            SuspendLayout();
            //
            // pnlHeader
            //
            pnlHeader.BackColor = Color.FromArgb(30, 30, 30);
            btnReport = new Button();
            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Controls.Add(btnApproveAll);
            pnlHeader.Controls.Add(btnApproveSelected);
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
            lblTitle.Size = new Size(250, 25);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Đề xuất nhập kho thông minh";
            //
            // btnApproveAll
            //
            btnApproveAll.BackColor = Color.MediumSeaGreen;
            btnApproveAll.Cursor = Cursors.Hand;
            btnApproveAll.FlatAppearance.BorderSize = 0;
            btnApproveAll.FlatStyle = FlatStyle.Flat;
            btnApproveAll.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            btnApproveAll.ForeColor = Color.White;
            btnApproveAll.Location = new Point(470, 12);
            btnApproveAll.Name = "btnApproveAll";
            btnApproveAll.Size = new Size(130, 32);
            btnApproveAll.TabIndex = 1;
            btnApproveAll.Text = "Duyệt tất cả";
            btnApproveAll.UseVisualStyleBackColor = false;
            btnApproveAll.Click += btnApproveAll_Click;
            //
            // btnApproveSelected
            //
            btnApproveSelected.BackColor = Color.SteelBlue;
            btnApproveSelected.Cursor = Cursors.Hand;
            btnApproveSelected.FlatAppearance.BorderSize = 0;
            btnApproveSelected.FlatStyle = FlatStyle.Flat;
            btnApproveSelected.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            btnApproveSelected.ForeColor = Color.White;
            btnApproveSelected.Location = new Point(615, 12);
            btnApproveSelected.Name = "btnApproveSelected";
            btnApproveSelected.Size = new Size(130, 32);
            btnApproveSelected.TabIndex = 2;
            btnApproveSelected.Text = "Duyệt đã chọn";
            btnApproveSelected.UseVisualStyleBackColor = false;
            btnApproveSelected.Click += btnApproveSelected_Click;
            //
            // btnReport
            //
            btnReport.BackColor = Color.FromArgb(70, 130, 180);
            btnReport.Cursor = Cursors.Hand;
            btnReport.FlatAppearance.BorderSize = 0;
            btnReport.FlatStyle = FlatStyle.Flat;
            btnReport.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            btnReport.ForeColor = Color.White;
            btnReport.Location = new Point(360, 14);
            btnReport.Name = "btnReport";
            btnReport.Size = new Size(90, 28);
            btnReport.Text = "Báo cáo";
            //
            // pnlInfo
            //
            pnlInfo.BackColor = Color.FromArgb(30, 30, 30);
            pnlInfo.Controls.Add(lblSuggestionsCount);
            pnlInfo.Controls.Add(lblSuggestionsTitle);
            pnlInfo.Controls.Add(lblEstimatedCost);
            pnlInfo.Controls.Add(lblEstimatedCostTitle);
            pnlInfo.Location = new Point(20, 80);
            pnlInfo.Name = "pnlInfo";
            pnlInfo.Size = new Size(764, 65);
            pnlInfo.TabIndex = 1;
            //
            // lblSuggestionsTitle
            //
            lblSuggestionsTitle.AutoSize = true;
            lblSuggestionsTitle.Font = new Font("Segoe UI", 9.75F);
            lblSuggestionsTitle.ForeColor = Color.Gray;
            lblSuggestionsTitle.Location = new Point(20, 10);
            lblSuggestionsTitle.Name = "lblSuggestionsTitle";
            lblSuggestionsTitle.Size = new Size(90, 17);
            lblSuggestionsTitle.TabIndex = 0;
            lblSuggestionsTitle.Text = "Số đề xuất";
            //
            // lblSuggestionsCount
            //
            lblSuggestionsCount.AutoSize = true;
            lblSuggestionsCount.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblSuggestionsCount.ForeColor = Color.Orange;
            lblSuggestionsCount.Location = new Point(20, 32);
            lblSuggestionsCount.Name = "lblSuggestionsCount";
            lblSuggestionsCount.Size = new Size(60, 25);
            lblSuggestionsCount.TabIndex = 1;
            lblSuggestionsCount.Text = "7 mục";
            //
            // lblEstimatedCostTitle
            //
            lblEstimatedCostTitle.AutoSize = true;
            lblEstimatedCostTitle.Font = new Font("Segoe UI", 9.75F);
            lblEstimatedCostTitle.ForeColor = Color.Gray;
            lblEstimatedCostTitle.Location = new Point(350, 10);
            lblEstimatedCostTitle.Name = "lblEstimatedCostTitle";
            lblEstimatedCostTitle.Size = new Size(100, 17);
            lblEstimatedCostTitle.TabIndex = 2;
            lblEstimatedCostTitle.Text = "Chi phí ước tính";
            //
            // lblEstimatedCost
            //
            lblEstimatedCost.AutoSize = true;
            lblEstimatedCost.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblEstimatedCost.ForeColor = Color.MediumSeaGreen;
            lblEstimatedCost.Location = new Point(350, 32);
            lblEstimatedCost.Name = "lblEstimatedCost";
            lblEstimatedCost.Size = new Size(150, 25);
            lblEstimatedCost.TabIndex = 3;
            lblEstimatedCost.Text = "15,200,000 đ";
            //
            // pnlGrid
            //
            pnlGrid.BackColor = Color.FromArgb(30, 30, 30);
            pnlGrid.Controls.Add(dgvSuggestions);
            pnlGrid.Location = new Point(20, 155);
            pnlGrid.Name = "pnlGrid";
            pnlGrid.Size = new Size(764, 360);
            pnlGrid.TabIndex = 2;
            //
            // dgvSuggestions
            //
            dgvSuggestions.AllowUserToAddRows = false;
            dgvSuggestions.BackgroundColor = Color.FromArgb(45, 45, 48);
            dgvSuggestions.BorderStyle = BorderStyle.None;
            dgvSuggestions.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvStyle.BackColor = Color.FromArgb(45, 45, 48);
            dgvStyle.Font = new Font("Segoe UI", 9F);
            dgvStyle.ForeColor = Color.White;
            dgvStyle.SelectionBackColor = Color.Gray;
            dgvStyle.SelectionForeColor = Color.White;
            dgvSuggestions.DefaultCellStyle = dgvStyle;
            dgvSuggestions.Location = new Point(15, 15);
            dgvSuggestions.Name = "dgvSuggestions";
            dgvSuggestions.ReadOnly = true;
            dgvSuggestions.RowHeadersWidth = 51;
            dgvSuggestions.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSuggestions.Size = new Size(734, 330);
            dgvSuggestions.TabIndex = 0;
            //
            // ucSmartRestock_Warehouse
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(45, 45, 48);
            Controls.Add(pnlGrid);
            Controls.Add(pnlInfo);
            Controls.Add(pnlHeader);
            Name = "ucSmartRestock_Warehouse";
            Size = new Size(804, 530);
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            pnlInfo.ResumeLayout(false);
            pnlInfo.PerformLayout();
            pnlGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvSuggestions).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlHeader;
        private Label lblTitle;
        private Button btnApproveAll;
        private Button btnApproveSelected;
        private Panel pnlInfo;
        private Label lblSuggestionsTitle;
        private Label lblSuggestionsCount;
        private Label lblEstimatedCostTitle;
        private Label lblEstimatedCost;
        private Panel pnlGrid;
        private DataGridView dgvSuggestions;
        private Button btnReport;
    }
}
