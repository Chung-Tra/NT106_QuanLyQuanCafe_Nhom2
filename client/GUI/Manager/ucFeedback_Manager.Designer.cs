using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;

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
            pnlHeader = new Guna2Panel();
            lblTitle = new Label();
            pnlGrid = new Guna2Panel();
            dgvFeedback = new Guna2DataGridView();
            colCode = new DataGridViewTextBoxColumn();
            colCustomer = new DataGridViewTextBoxColumn();
            colDate = new DataGridViewTextBoxColumn();
            colRating = new DataGridViewTextBoxColumn();
            colContent = new DataGridViewTextBoxColumn();
            colStatus = new DataGridViewTextBoxColumn();
            pnlDetail = new Guna2Panel();
            lblDetailTitle = new Label();
            lblCustomerName = new Label();
            lblDate = new Label();
            lblRating = new Label();
            txtContent = new Guna2TextBox();
            btnReply = new Guna2Button();
            btnEditFeedback = new Guna2Button();
            pnlHeader.SuspendLayout();
            pnlGrid.SuspendLayout();
            pnlDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvFeedback).BeginInit();
            SuspendLayout();

            // ====== pnlHeader ======
            pnlHeader.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlHeader.BackColor = Color.FromArgb(31, 31, 34);
            pnlHeader.BorderRadius = 14;
            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Location = new Point(20, 20);
            pnlHeader.Size = new Size(960, 60);
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(18, 16);
            lblTitle.Text = "Phản hồi khách hàng";

            // ====== pnlGrid ======
            pnlGrid.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnlGrid.BackColor = Color.FromArgb(31, 31, 34);
            pnlGrid.BorderRadius = 14;
            pnlGrid.Controls.Add(dgvFeedback);
            pnlGrid.Location = new Point(20, 95);
            pnlGrid.Size = new Size(960, 320);

            // dgvFeedback
            dgvFeedback.BackgroundColor = Color.FromArgb(24, 24, 27);
            dgvFeedback.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(31, 31, 34);
            dgvFeedback.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(160, 160, 166);
            dgvFeedback.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dgvFeedback.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(31, 31, 34);
            dgvFeedback.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.FromArgb(160, 160, 166);
            dgvFeedback.DefaultCellStyle.BackColor = Color.FromArgb(24, 24, 27);
            dgvFeedback.DefaultCellStyle.ForeColor = Color.FromArgb(220, 220, 225);
            dgvFeedback.DefaultCellStyle.SelectionBackColor = Color.FromArgb(31, 138, 154);
            dgvFeedback.DefaultCellStyle.SelectionForeColor = Color.FromArgb(240, 240, 245);
            dgvFeedback.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(24, 24, 27);
            dgvFeedback.AlternatingRowsDefaultCellStyle.ForeColor = Color.FromArgb(220, 220, 225);
            dgvFeedback.GridColor = Color.FromArgb(45, 45, 48);
            ConfigureGrid(dgvFeedback);            dgvFeedback.Columns.AddRange(new DataGridViewColumn[] { colCode, colCustomer, colDate, colRating, colContent, colStatus });
            colCode.HeaderText = "Mã"; colCode.Name = "Mã"; colCode.DataPropertyName = "Mã";
            colCustomer.HeaderText = "Khách hàng"; colCustomer.Name = "Khách hàng"; colCustomer.DataPropertyName = "Khách hàng";
            colDate.HeaderText = "Ngày"; colDate.Name = "Ngày"; colDate.DataPropertyName = "Ngày";
            colRating.HeaderText = "Đánh giá"; colRating.Name = "Đánh giá"; colRating.DataPropertyName = "Đánh giá";
            colContent.HeaderText = "Nội dung"; colContent.Name = "Nội dung"; colContent.DataPropertyName = "Nội dung";
            colStatus.HeaderText = "Trạng thái"; colStatus.Name = "Trạng thái"; colStatus.DataPropertyName = "Trạng thái";
            dgvFeedback.AllowUserToDeleteRows = false;
            dgvFeedback.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvFeedback.Location = new Point(18, 18);
            dgvFeedback.Size = new Size(924, 284);
            dgvFeedback.SelectionChanged += dgvFeedback_SelectionChanged;
            dgvFeedback.CellDoubleClick += DgvFeedback_CellDoubleClick;

            // ====== pnlDetail ======
            pnlDetail.BackColor = Color.FromArgb(31, 31, 34);
            pnlDetail.BorderRadius = 14;
            pnlDetail.Controls.Add(lblDetailTitle);
            pnlDetail.Controls.Add(lblCustomerName);
            pnlDetail.Controls.Add(lblDate);
            pnlDetail.Controls.Add(lblRating);
            pnlDetail.Controls.Add(txtContent);
            pnlDetail.Controls.Add(btnReply);
            pnlDetail.Controls.Add(btnEditFeedback);
            pnlDetail.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnlDetail.Location = new Point(20, 430);
            pnlDetail.Size = new Size(960, 220);

            lblDetailTitle.AutoSize = true;
            lblDetailTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblDetailTitle.ForeColor = Color.White;
            lblDetailTitle.Location = new Point(18, 14);
            lblDetailTitle.Text = "Chi tiết phản hồi";

            lblCustomerName.AutoSize = true;
            lblCustomerName.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblCustomerName.ForeColor = Color.FromArgb(245, 158, 11);
            lblCustomerName.Location = new Point(18, 50);
            lblCustomerName.Text = "Khách hàng: ---";

            lblDate.AutoSize = true;
            lblDate.Font = new Font("Segoe UI", 9.5F);
            lblDate.ForeColor = Color.FromArgb(160, 160, 166);
            lblDate.Location = new Point(360, 52);
            lblDate.Text = "Ngày: ---";

            lblRating.AutoSize = true;
            lblRating.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblRating.ForeColor = Color.Gold;
            lblRating.Location = new Point(580, 48);
            lblRating.Text = "---";

            // txtContent
            txtContent.BorderColor = Color.FromArgb(63, 63, 70);
            txtContent.BorderRadius = 10;
            txtContent.DisabledState.BorderColor = Color.FromArgb(63, 63, 70);
            txtContent.FillColor = Color.FromArgb(30, 30, 33);
            txtContent.FocusedState.BorderColor = Color.FromArgb(31, 138, 154);
            txtContent.Font = new Font("Segoe UI", 10F);
            txtContent.ForeColor = Color.White;
            txtContent.HoverState.BorderColor = Color.FromArgb(120, 120, 130);
            txtContent.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtContent.Location = new Point(18, 84);
            txtContent.Multiline = true;
            txtContent.PlaceholderForeColor = Color.FromArgb(110, 110, 120);
            txtContent.ReadOnly = true;
            txtContent.Size = new Size(720, 110);

            // btnReply
            btnReply.BorderRadius = 10;
            btnReply.Cursor = Cursors.Hand;
            btnReply.FillColor = Color.FromArgb(31, 138, 154);
            btnReply.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnReply.ForeColor = Color.White;
            btnReply.HoverState.FillColor = Color.FromArgb(45, 158, 174);
            btnReply.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnReply.Location = new Point(760, 84);
            btnReply.Size = new Size(180, 50);
            btnReply.Text = "Trả lời";
            btnReply.Click += btnReply_Click;

            // btnEditFeedback
            btnEditFeedback.BorderColor = Color.FromArgb(80, 80, 90);
            btnEditFeedback.BorderRadius = 10;
            btnEditFeedback.BorderThickness = 1;
            btnEditFeedback.Cursor = Cursors.Hand;
            btnEditFeedback.FillColor = Color.Transparent;
            btnEditFeedback.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnEditFeedback.ForeColor = Color.FromArgb(220, 220, 225);
            btnEditFeedback.HoverState.FillColor = Color.FromArgb(45, 45, 50);
            btnEditFeedback.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnEditFeedback.Location = new Point(760, 144);
            btnEditFeedback.Name = "btnEditFeedback";
            btnEditFeedback.Size = new Size(180, 44);
            btnEditFeedback.Text = "Sửa dòng chọn";
            btnEditFeedback.Click += BtnEditFeedback_Click;

            // ====== ucFeedback_Manager ======
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(39, 39, 42);
            Controls.Add(pnlHeader);
            Controls.Add(pnlGrid);
            Controls.Add(pnlDetail);
            Name = "ucFeedback_Manager";
            Size = new Size(1000, 665);
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            pnlGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvFeedback).EndInit();
            pnlDetail.ResumeLayout(false);
            pnlDetail.PerformLayout();
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
        private Guna2Panel pnlGrid;
        private Guna2DataGridView dgvFeedback;
        private DataGridViewTextBoxColumn colCode;
        private DataGridViewTextBoxColumn colCustomer;
        private DataGridViewTextBoxColumn colDate;
        private DataGridViewTextBoxColumn colRating;
        private DataGridViewTextBoxColumn colContent;
        private DataGridViewTextBoxColumn colStatus;
        private Guna2Panel pnlDetail;
        private Label lblDetailTitle;
        private Label lblCustomerName;
        private Label lblDate;
        private Label lblRating;
        private Guna2TextBox txtContent;
        private Guna2Button btnReply;
        private Guna2Button btnEditFeedback;
    }
}
