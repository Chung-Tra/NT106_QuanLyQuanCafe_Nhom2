using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace GUI
{
    partial class ucFeedback_Admin
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges13 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges14 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges11 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges12 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            pnlFilter = new Guna2Panel();
            lblTitle = new Label();
            lblFilterStatus = new Label();
            cmbFilterStatus = new Guna2ComboBox();
            pnlGrid = new Guna2Panel();
            dgvFeedback = new Guna2DataGridView();
            pnlDetail = new Guna2Panel();
            lblDetailTitle = new Label();
            lblCustomerName = new Label();
            lblFeedbackDate = new Label();
            lblRating = new Label();
            txtFeedbackContent = new TextBox();
            btnReply = new Guna2Button();
            btnMarkResolved = new Guna2Button();
            btnDeleteFeedback = new Guna2Button();
            pnlFilter.SuspendLayout();
            pnlGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvFeedback).BeginInit();
            pnlDetail.SuspendLayout();
            SuspendLayout();
            // 
            // pnlFilter
            // 
            pnlFilter.BackColor = Color.FromArgb(31, 31, 34);
            pnlFilter.BorderRadius = 14;
            pnlFilter.Controls.Add(lblTitle);
            pnlFilter.Controls.Add(lblFilterStatus);
            pnlFilter.Controls.Add(cmbFilterStatus);
            pnlFilter.CustomizableEdges = customizableEdges3;
            pnlFilter.Location = new Point(20, 20);
            pnlFilter.Name = "pnlFilter";
            pnlFilter.ShadowDecoration.CustomizableEdges = customizableEdges4;
            pnlFilter.Size = new Size(920, 60);
            pnlFilter.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(18, 18);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(227, 25);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "💬  Phản hồi khách hàng";
            // 
            // lblFilterStatus
            // 
            lblFilterStatus.AutoSize = true;
            lblFilterStatus.Font = new Font("Segoe UI", 9.5F);
            lblFilterStatus.ForeColor = Color.FromArgb(160, 160, 166);
            lblFilterStatus.Location = new Point(620, 22);
            lblFilterStatus.Name = "lblFilterStatus";
            lblFilterStatus.Size = new Size(69, 17);
            lblFilterStatus.TabIndex = 1;
            lblFilterStatus.Text = "Trạng thái:";
            // 
            // cmbFilterStatus
            // 
            cmbFilterStatus.BackColor = Color.Transparent;
            cmbFilterStatus.BorderColor = Color.FromArgb(63, 63, 70);
            cmbFilterStatus.BorderRadius = 8;
            cmbFilterStatus.CustomizableEdges = customizableEdges1;
            cmbFilterStatus.DrawMode = DrawMode.OwnerDrawFixed;
            cmbFilterStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFilterStatus.FillColor = Color.FromArgb(24, 24, 27);
            cmbFilterStatus.FocusedColor = Color.FromArgb(31, 138, 154);
            cmbFilterStatus.FocusedState.BorderColor = Color.FromArgb(31, 138, 154);
            cmbFilterStatus.Font = new Font("Segoe UI", 9.5F);
            cmbFilterStatus.ForeColor = Color.White;
            cmbFilterStatus.HoverState.BorderColor = Color.FromArgb(120, 120, 130);
            cmbFilterStatus.ItemHeight = 26;
            cmbFilterStatus.Location = new Point(700, 16);
            cmbFilterStatus.Name = "cmbFilterStatus";
            cmbFilterStatus.ShadowDecoration.CustomizableEdges = customizableEdges2;
            cmbFilterStatus.Size = new Size(200, 32);
            cmbFilterStatus.TabIndex = 2;
            cmbFilterStatus.SelectedIndexChanged += cmbFilterStatus_SelectedIndexChanged;
            // 
            // pnlGrid
            // 
            pnlGrid.BackColor = Color.FromArgb(31, 31, 34);
            pnlGrid.BorderRadius = 14;
            pnlGrid.Controls.Add(dgvFeedback);
            pnlGrid.CustomizableEdges = customizableEdges5;
            pnlGrid.Location = new Point(20, 95);
            pnlGrid.Name = "pnlGrid";
            pnlGrid.ShadowDecoration.CustomizableEdges = customizableEdges6;
            pnlGrid.Size = new Size(920, 280);
            pnlGrid.TabIndex = 1;
            // 
            // dgvFeedback
            // 
            dataGridViewCellStyle1.BackColor = Color.White;
            dgvFeedback.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(100, 88, 255);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvFeedback.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvFeedback.DefaultCellStyle = dataGridViewCellStyle3;
            dgvFeedback.GridColor = Color.FromArgb(231, 229, 255);
            dgvFeedback.Location = new Point(18, 18);
            dgvFeedback.Name = "dgvFeedback";
            dgvFeedback.RowHeadersVisible = false;
            dgvFeedback.Size = new Size(884, 244);
            dgvFeedback.TabIndex = 0;
            dgvFeedback.ThemeStyle.AlternatingRowsStyle.BackColor = Color.White;
            dgvFeedback.ThemeStyle.AlternatingRowsStyle.Font = null;
            dgvFeedback.ThemeStyle.AlternatingRowsStyle.ForeColor = Color.Empty;
            dgvFeedback.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.Empty;
            dgvFeedback.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.Empty;
            dgvFeedback.ThemeStyle.BackColor = Color.White;
            dgvFeedback.ThemeStyle.GridColor = Color.FromArgb(231, 229, 255);
            dgvFeedback.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(100, 88, 255);
            dgvFeedback.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvFeedback.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI", 9F);
            dgvFeedback.ThemeStyle.HeaderStyle.ForeColor = Color.White;
            dgvFeedback.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvFeedback.ThemeStyle.HeaderStyle.Height = 23;
            dgvFeedback.ThemeStyle.ReadOnly = false;
            dgvFeedback.ThemeStyle.RowsStyle.BackColor = Color.White;
            dgvFeedback.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvFeedback.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 9F);
            dgvFeedback.ThemeStyle.RowsStyle.ForeColor = Color.FromArgb(71, 69, 94);
            dgvFeedback.ThemeStyle.RowsStyle.Height = 25;
            dgvFeedback.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dgvFeedback.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dgvFeedback.SelectionChanged += dgvFeedback_SelectionChanged;
            // 
            // pnlDetail
            // 
            pnlDetail.BackColor = Color.FromArgb(31, 31, 34);
            pnlDetail.BorderRadius = 14;
            pnlDetail.Controls.Add(lblDetailTitle);
            pnlDetail.Controls.Add(lblCustomerName);
            pnlDetail.Controls.Add(lblFeedbackDate);
            pnlDetail.Controls.Add(lblRating);
            pnlDetail.Controls.Add(txtFeedbackContent);
            pnlDetail.Controls.Add(btnReply);
            pnlDetail.Controls.Add(btnMarkResolved);
            pnlDetail.Controls.Add(btnDeleteFeedback);
            pnlDetail.CustomizableEdges = customizableEdges13;
            pnlDetail.Location = new Point(20, 390);
            pnlDetail.Name = "pnlDetail";
            pnlDetail.ShadowDecoration.CustomizableEdges = customizableEdges14;
            pnlDetail.Size = new Size(920, 250);
            pnlDetail.TabIndex = 2;
            // 
            // lblDetailTitle
            // 
            lblDetailTitle.AutoSize = true;
            lblDetailTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblDetailTitle.ForeColor = Color.White;
            lblDetailTitle.Location = new Point(18, 16);
            lblDetailTitle.Name = "lblDetailTitle";
            lblDetailTitle.Size = new Size(154, 20);
            lblDetailTitle.TabIndex = 0;
            lblDetailTitle.Text = "📝  Chi tiết phản hồi";
            // 
            // lblCustomerName
            // 
            lblCustomerName.AutoSize = true;
            lblCustomerName.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblCustomerName.ForeColor = Color.FromArgb(245, 158, 11);
            lblCustomerName.Location = new Point(18, 50);
            lblCustomerName.Name = "lblCustomerName";
            lblCustomerName.Size = new Size(112, 19);
            lblCustomerName.TabIndex = 1;
            lblCustomerName.Text = "Khách hàng: ---";
            // 
            // lblFeedbackDate
            // 
            lblFeedbackDate.AutoSize = true;
            lblFeedbackDate.Font = new Font("Segoe UI", 9F);
            lblFeedbackDate.ForeColor = Color.FromArgb(160, 160, 166);
            lblFeedbackDate.Location = new Point(280, 52);
            lblFeedbackDate.Name = "lblFeedbackDate";
            lblFeedbackDate.Size = new Size(56, 15);
            lblFeedbackDate.TabIndex = 2;
            lblFeedbackDate.Text = "Ngày: ---";
            // 
            // lblRating
            // 
            lblRating.AutoSize = true;
            lblRating.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblRating.ForeColor = Color.Gold;
            lblRating.Location = new Point(450, 48);
            lblRating.Name = "lblRating";
            lblRating.Size = new Size(28, 21);
            lblRating.TabIndex = 3;
            lblRating.Text = "---";
            // 
            // txtFeedbackContent
            // 
            txtFeedbackContent.BackColor = Color.FromArgb(24, 24, 27);
            txtFeedbackContent.BorderStyle = BorderStyle.None;
            txtFeedbackContent.Font = new Font("Segoe UI", 10F);
            txtFeedbackContent.ForeColor = Color.FromArgb(220, 220, 225);
            txtFeedbackContent.Location = new Point(18, 84);
            txtFeedbackContent.Multiline = true;
            txtFeedbackContent.Name = "txtFeedbackContent";
            txtFeedbackContent.ReadOnly = true;
            txtFeedbackContent.Size = new Size(660, 145);
            txtFeedbackContent.TabIndex = 4;
            // 
            // btnReply
            // 
            btnReply.BorderRadius = 10;
            btnReply.Cursor = Cursors.Hand;
            btnReply.CustomizableEdges = customizableEdges7;
            btnReply.FillColor = Color.FromArgb(31, 138, 154);
            btnReply.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnReply.ForeColor = Color.White;
            btnReply.HoverState.FillColor = Color.FromArgb(45, 158, 174);
            btnReply.Location = new Point(700, 84);
            btnReply.Name = "btnReply";
            btnReply.ShadowDecoration.CustomizableEdges = customizableEdges8;
            btnReply.Size = new Size(200, 38);
            btnReply.TabIndex = 5;
            btnReply.Text = "💬  Trả lời";
            btnReply.Click += btnReply_Click;
            // 
            // btnMarkResolved
            // 
            btnMarkResolved.BorderRadius = 10;
            btnMarkResolved.Cursor = Cursors.Hand;
            btnMarkResolved.CustomizableEdges = customizableEdges9;
            btnMarkResolved.FillColor = Color.FromArgb(34, 197, 94);
            btnMarkResolved.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnMarkResolved.ForeColor = Color.White;
            btnMarkResolved.HoverState.FillColor = Color.FromArgb(50, 217, 110);
            btnMarkResolved.Location = new Point(700, 132);
            btnMarkResolved.Name = "btnMarkResolved";
            btnMarkResolved.ShadowDecoration.CustomizableEdges = customizableEdges10;
            btnMarkResolved.Size = new Size(200, 38);
            btnMarkResolved.TabIndex = 6;
            btnMarkResolved.Text = "✓  Đã xử lý";
            btnMarkResolved.Click += btnMarkResolved_Click;
            // 
            // btnDeleteFeedback
            // 
            btnDeleteFeedback.BorderColor = Color.FromArgb(180, 60, 60);
            btnDeleteFeedback.BorderRadius = 10;
            btnDeleteFeedback.BorderThickness = 1;
            btnDeleteFeedback.Cursor = Cursors.Hand;
            btnDeleteFeedback.CustomizableEdges = customizableEdges11;
            btnDeleteFeedback.FillColor = Color.Transparent;
            btnDeleteFeedback.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnDeleteFeedback.ForeColor = Color.FromArgb(220, 80, 80);
            btnDeleteFeedback.HoverState.FillColor = Color.FromArgb(180, 60, 60);
            btnDeleteFeedback.HoverState.ForeColor = Color.White;
            btnDeleteFeedback.Location = new Point(700, 180);
            btnDeleteFeedback.Name = "btnDeleteFeedback";
            btnDeleteFeedback.ShadowDecoration.CustomizableEdges = customizableEdges12;
            btnDeleteFeedback.Size = new Size(200, 38);
            btnDeleteFeedback.TabIndex = 7;
            btnDeleteFeedback.Text = "🗑  Xóa";
            btnDeleteFeedback.Click += btnDeleteFeedback_Click;
            // 
            // ucFeedback_Admin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(39, 39, 42);
            Controls.Add(pnlFilter);
            Controls.Add(pnlGrid);
            Controls.Add(pnlDetail);
            Name = "ucFeedback_Admin";
            Size = new Size(960, 660);
            pnlFilter.ResumeLayout(false);
            pnlFilter.PerformLayout();
            pnlGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvFeedback).EndInit();
            pnlDetail.ResumeLayout(false);
            pnlDetail.PerformLayout();
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
            dgv.DefaultCellStyle.SelectionForeColor = Color.White;
            dgv.EnableHeadersVisualStyles = false;
            dgv.GridColor = Color.FromArgb(45, 45, 48);
            dgv.MultiSelect = false;
            dgv.ReadOnly = true;
            dgv.RowHeadersVisible = false;
            dgv.RowTemplate.Height = 28;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        #endregion

        private Guna2Panel pnlFilter;
        private Label lblTitle;
        private Guna2ComboBox cmbFilterStatus;
        private Label lblFilterStatus;
        private Guna2Panel pnlGrid;
        private Guna2DataGridView dgvFeedback;
        private Guna2Panel pnlDetail;
        private Label lblDetailTitle;
        private Label lblCustomerName;
        private Label lblFeedbackDate;
        private TextBox txtFeedbackContent;
        private Label lblRating;
        private Guna2Button btnReply;
        private Guna2Button btnMarkResolved;
        private Guna2Button btnDeleteFeedback;
    }
}
