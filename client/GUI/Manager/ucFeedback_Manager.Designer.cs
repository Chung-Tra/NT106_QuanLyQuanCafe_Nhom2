using System.Drawing;
using System.Windows.Forms;

namespace GUI
{
    partial class ucFeedback_Manager
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
            pnlGrid = new Panel();
            dgvFeedback = new DataGridView();
            pnlDetail = new Panel();
            lblDetailTitle = new Label();
            lblCustomerName = new Label();
            lblDate = new Label();
            lblRating = new Label();
            txtContent = new TextBox();
            btnReply = new Button();
            pnlHeader.SuspendLayout();
            pnlGrid.SuspendLayout();
            pnlDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvFeedback).BeginInit();
            SuspendLayout();
            pnlHeader.BackColor = Color.FromArgb(30, 30, 30);
            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Location = new Point(20, 15);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(764, 45);
            pnlHeader.TabIndex = 0;
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(15, 10);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(250, 25);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Phản hồi khách hàng";
            pnlGrid.BackColor = Color.FromArgb(30, 30, 30);
            pnlGrid.Controls.Add(dgvFeedback);
            pnlGrid.Location = new Point(20, 70);
            pnlGrid.Name = "pnlGrid";
            pnlGrid.Size = new Size(764, 270);
            pnlGrid.TabIndex = 1;
            dgvFeedback.AllowUserToAddRows = false;
            dgvFeedback.AllowUserToDeleteRows = false;
            dgvFeedback.BackgroundColor = Color.FromArgb(45, 45, 48);
            dgvFeedback.BorderStyle = BorderStyle.None;
            dgvFeedback.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvStyle.BackColor = Color.FromArgb(45, 45, 48);
            dgvStyle.Font = new Font("Segoe UI", 9F);
            dgvStyle.ForeColor = Color.White;
            dgvStyle.SelectionBackColor = Color.Gray;
            dgvStyle.SelectionForeColor = Color.White;
            dgvFeedback.DefaultCellStyle = dgvStyle;
            dgvFeedback.Location = new Point(15, 15);
            dgvFeedback.Name = "dgvFeedback";
            dgvFeedback.ReadOnly = true;
            dgvFeedback.RowHeadersWidth = 51;
            dgvFeedback.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvFeedback.Size = new Size(734, 240);
            dgvFeedback.TabIndex = 0;
            dgvFeedback.SelectionChanged += dgvFeedback_SelectionChanged;
            pnlDetail.BackColor = Color.FromArgb(30, 30, 30);
            pnlDetail.Controls.Add(lblDetailTitle);
            pnlDetail.Controls.Add(lblCustomerName);
            pnlDetail.Controls.Add(lblDate);
            pnlDetail.Controls.Add(lblRating);
            pnlDetail.Controls.Add(txtContent);
            pnlDetail.Controls.Add(btnReply);
            pnlDetail.Location = new Point(20, 350);
            pnlDetail.Name = "pnlDetail";
            pnlDetail.Size = new Size(764, 165);
            pnlDetail.TabIndex = 2;
            lblDetailTitle.AutoSize = true;
            lblDetailTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblDetailTitle.ForeColor = Color.White;
            lblDetailTitle.Location = new Point(15, 12);
            lblDetailTitle.Name = "lblDetailTitle";
            lblDetailTitle.Size = new Size(120, 20);
            lblDetailTitle.TabIndex = 0;
            lblDetailTitle.Text = "Chi tiết phản hồi";
            lblCustomerName.AutoSize = true;
            lblCustomerName.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblCustomerName.ForeColor = Color.Orange;
            lblCustomerName.Location = new Point(15, 40);
            lblCustomerName.Name = "lblCustomerName";
            lblCustomerName.Size = new Size(150, 19);
            lblCustomerName.TabIndex = 1;
            lblCustomerName.Text = "Khách hàng: ---";
            lblDate.AutoSize = true;
            lblDate.Font = new Font("Segoe UI", 9F);
            lblDate.ForeColor = Color.Gray;
            lblDate.Location = new Point(300, 42);
            lblDate.Name = "lblDate";
            lblDate.Size = new Size(80, 15);
            lblDate.TabIndex = 2;
            lblDate.Text = "Ngày: ---";
            lblRating.AutoSize = true;
            lblRating.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblRating.ForeColor = Color.Gold;
            lblRating.Location = new Point(500, 38);
            lblRating.Name = "lblRating";
            lblRating.Size = new Size(50, 21);
            lblRating.TabIndex = 3;
            lblRating.Text = "---";
            txtContent.BackColor = Color.FromArgb(45, 45, 48);
            txtContent.BorderStyle = BorderStyle.None;
            txtContent.Font = new Font("Segoe UI", 10F);
            txtContent.ForeColor = Color.White;
            txtContent.Location = new Point(15, 68);
            txtContent.Multiline = true;
            txtContent.Name = "txtContent";
            txtContent.ReadOnly = true;
            txtContent.Size = new Size(540, 80);
            txtContent.TabIndex = 4;
            btnReply.BackColor = Color.SteelBlue;
            btnReply.Cursor = Cursors.Hand;
            btnReply.FlatAppearance.BorderSize = 0;
            btnReply.FlatStyle = FlatStyle.Flat;
            btnReply.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnReply.ForeColor = Color.White;
            btnReply.Location = new Point(580, 68);
            btnReply.Name = "btnReply";
            btnReply.Size = new Size(160, 40);
            btnReply.TabIndex = 5;
            btnReply.Text = "Trả lời";
            btnReply.UseVisualStyleBackColor = false;
            btnReply.Click += btnReply_Click;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(45, 45, 48);
            Controls.Add(pnlDetail);
            Controls.Add(pnlGrid);
            Controls.Add(pnlHeader);
            Name = "ucFeedback_Manager";
            Size = new Size(804, 530);
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            pnlGrid.ResumeLayout(false);
            pnlDetail.ResumeLayout(false);
            pnlDetail.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvFeedback).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlHeader;
        private Label lblTitle;
        private Panel pnlGrid;
        private DataGridView dgvFeedback;
        private Panel pnlDetail;
        private Label lblDetailTitle;
        private Label lblCustomerName;
        private Label lblDate;
        private Label lblRating;
        private TextBox txtContent;
        private Button btnReply;
    }
}