using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace GUI
{
    partial class MetricDetail
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            card = new Guna2Panel();
            accentBar = new Guna2Panel();
            lblTitle = new Label();
            lblCapLeft = new Label();
            lblCapRight = new Label();
            dgvBreakdown = new Guna2DataGridView();
            dgvMonthly = new Guna2DataGridView();
            lblNote = new Label();
            btnClose = new Guna2Button();
            card.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvBreakdown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvMonthly).BeginInit();
            SuspendLayout();
            // 
            // card
            // 
            card.BackColor = Color.Transparent;
            card.BorderRadius = 16;
            card.Controls.Add(accentBar);
            card.Controls.Add(lblTitle);
            card.Controls.Add(lblCapLeft);
            card.Controls.Add(lblCapRight);
            card.Controls.Add(dgvBreakdown);
            card.Controls.Add(dgvMonthly);
            card.Controls.Add(lblNote);
            card.Controls.Add(btnClose);
            card.CustomizableEdges = customizableEdges5;
            card.Dock = DockStyle.Fill;
            card.FillColor = Color.FromArgb(31, 31, 34);
            card.Location = new Point(0, 0);
            card.Name = "card";
            card.ShadowDecoration.CustomizableEdges = customizableEdges6;
            card.Size = new Size(756, 500);
            card.TabIndex = 0;
            // 
            // accentBar
            // 
            accentBar.BorderRadius = 3;
            accentBar.CustomizableEdges = customizableEdges1;
            accentBar.FillColor = Color.FromArgb(31, 138, 154);
            accentBar.Location = new Point(22, 22);
            accentBar.Name = "accentBar";
            accentBar.ShadowDecoration.CustomizableEdges = customizableEdges2;
            accentBar.Size = new Size(5, 24);
            accentBar.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.BackColor = Color.Transparent;
            lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(240, 240, 245);
            lblTitle.Location = new Point(36, 21);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(87, 25);
            lblTitle.TabIndex = 1;
            lblTitle.Text = "(tiêu đề)";
            // 
            // lblCapLeft
            // 
            lblCapLeft.AutoSize = true;
            lblCapLeft.BackColor = Color.Transparent;
            lblCapLeft.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblCapLeft.ForeColor = Color.FromArgb(160, 160, 166);
            lblCapLeft.Location = new Point(22, 60);
            lblCapLeft.Name = "lblCapLeft";
            lblCapLeft.Size = new Size(62, 15);
            lblCapLeft.TabIndex = 2;
            lblCapLeft.Text = "Cấu thành";
            // 
            // lblCapRight
            // 
            lblCapRight.AutoSize = true;
            lblCapRight.BackColor = Color.Transparent;
            lblCapRight.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblCapRight.ForeColor = Color.FromArgb(160, 160, 166);
            lblCapRight.Location = new Point(374, 60);
            lblCapRight.Name = "lblCapRight";
            lblCapRight.Size = new Size(70, 15);
            lblCapRight.TabIndex = 3;
            lblCapRight.Text = "Theo tháng";
            // 
            // dgvBreakdown
            // 
            dataGridViewCellStyle1.BackColor = Color.White;
            dgvBreakdown.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvBreakdown.BackgroundColor = Color.FromArgb(24, 24, 27);
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(100, 88, 255);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvBreakdown.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvBreakdown.DefaultCellStyle = dataGridViewCellStyle3;
            dgvBreakdown.GridColor = Color.FromArgb(231, 229, 255);
            dgvBreakdown.Location = new Point(0, 0);
            dgvBreakdown.Name = "dgvBreakdown";
            dgvBreakdown.ReadOnly = true;
            dgvBreakdown.RowHeadersVisible = false;
            dgvBreakdown.ScrollBars = ScrollBars.Vertical;
            dgvBreakdown.Size = new Size(756, 500);
            dgvBreakdown.TabIndex = 4;
            dgvBreakdown.ThemeStyle.AlternatingRowsStyle.BackColor = Color.White;
            dgvBreakdown.ThemeStyle.AlternatingRowsStyle.Font = null;
            dgvBreakdown.ThemeStyle.AlternatingRowsStyle.ForeColor = Color.Empty;
            dgvBreakdown.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.Empty;
            dgvBreakdown.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.Empty;
            dgvBreakdown.ThemeStyle.BackColor = Color.FromArgb(24, 24, 27);
            dgvBreakdown.ThemeStyle.GridColor = Color.FromArgb(231, 229, 255);
            dgvBreakdown.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(100, 88, 255);
            dgvBreakdown.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvBreakdown.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI", 9F);
            dgvBreakdown.ThemeStyle.HeaderStyle.ForeColor = Color.White;
            dgvBreakdown.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvBreakdown.ThemeStyle.HeaderStyle.Height = 23;
            dgvBreakdown.ThemeStyle.ReadOnly = true;
            dgvBreakdown.ThemeStyle.RowsStyle.BackColor = Color.White;
            dgvBreakdown.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvBreakdown.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 9F);
            dgvBreakdown.ThemeStyle.RowsStyle.ForeColor = Color.FromArgb(71, 69, 94);
            dgvBreakdown.ThemeStyle.RowsStyle.Height = 25;
            dgvBreakdown.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dgvBreakdown.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(71, 69, 94);
            // 
            // dgvMonthly
            // 
            dataGridViewCellStyle4.BackColor = Color.White;
            dgvMonthly.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            dgvMonthly.BackgroundColor = Color.FromArgb(24, 24, 27);
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = Color.FromArgb(100, 88, 255);
            dataGridViewCellStyle5.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle5.ForeColor = Color.White;
            dataGridViewCellStyle5.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.True;
            dgvMonthly.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = Color.White;
            dataGridViewCellStyle6.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle6.ForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle6.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dataGridViewCellStyle6.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle6.WrapMode = DataGridViewTriState.False;
            dgvMonthly.DefaultCellStyle = dataGridViewCellStyle6;
            dgvMonthly.GridColor = Color.FromArgb(231, 229, 255);
            dgvMonthly.Location = new Point(0, 0);
            dgvMonthly.Name = "dgvMonthly";
            dgvMonthly.ReadOnly = true;
            dgvMonthly.RowHeadersVisible = false;
            dgvMonthly.ScrollBars = ScrollBars.Vertical;
            dgvMonthly.Size = new Size(240, 150);
            dgvMonthly.TabIndex = 5;
            dgvMonthly.ThemeStyle.AlternatingRowsStyle.BackColor = Color.White;
            dgvMonthly.ThemeStyle.AlternatingRowsStyle.Font = null;
            dgvMonthly.ThemeStyle.AlternatingRowsStyle.ForeColor = Color.Empty;
            dgvMonthly.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.Empty;
            dgvMonthly.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.Empty;
            dgvMonthly.ThemeStyle.BackColor = Color.FromArgb(24, 24, 27);
            dgvMonthly.ThemeStyle.GridColor = Color.FromArgb(231, 229, 255);
            dgvMonthly.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(100, 88, 255);
            dgvMonthly.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvMonthly.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI", 9F);
            dgvMonthly.ThemeStyle.HeaderStyle.ForeColor = Color.White;
            dgvMonthly.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvMonthly.ThemeStyle.HeaderStyle.Height = 23;
            dgvMonthly.ThemeStyle.ReadOnly = true;
            dgvMonthly.ThemeStyle.RowsStyle.BackColor = Color.White;
            dgvMonthly.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvMonthly.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 9F);
            dgvMonthly.ThemeStyle.RowsStyle.ForeColor = Color.FromArgb(71, 69, 94);
            dgvMonthly.ThemeStyle.RowsStyle.Height = 25;
            dgvMonthly.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dgvMonthly.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(71, 69, 94);
            // 
            // lblNote
            // 
            lblNote.BackColor = Color.Transparent;
            lblNote.Font = new Font("Segoe UI", 8.75F, FontStyle.Italic);
            lblNote.ForeColor = Color.FromArgb(160, 160, 166);
            lblNote.Location = new Point(0, 0);
            lblNote.Name = "lblNote";
            lblNote.Size = new Size(712, 40);
            lblNote.TabIndex = 6;
            lblNote.Text = "ⓘ  (ghi chú)";
            // 
            // btnClose
            // 
            btnClose.BorderRadius = 10;
            btnClose.Cursor = Cursors.Hand;
            btnClose.CustomizableEdges = customizableEdges3;
            btnClose.FillColor = Color.FromArgb(31, 138, 154);
            btnClose.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnClose.ForeColor = Color.White;
            btnClose.Location = new Point(0, 0);
            btnClose.Name = "btnClose";
            btnClose.ShadowDecoration.CustomizableEdges = customizableEdges4;
            btnClose.Size = new Size(120, 38);
            btnClose.TabIndex = 7;
            btnClose.Text = "Đóng";
            btnClose.Click += btnClose_Click;
            // 
            // MetricDetail
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(39, 39, 42);
            ClientSize = new Size(756, 500);
            Controls.Add(card);
            FormBorderStyle = FormBorderStyle.None;
            Name = "MetricDetail";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            card.ResumeLayout(false);
            card.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvBreakdown).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvMonthly).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Guna2Panel   card;
        private Guna2Panel   accentBar;
        private Label        lblTitle;
        private Label        lblCapLeft;
        private Label        lblCapRight;
        private Guna2DataGridView dgvBreakdown;
        private Guna2DataGridView dgvMonthly;
        private Label        lblNote;
        private Guna2Button  btnClose;
    }
}
