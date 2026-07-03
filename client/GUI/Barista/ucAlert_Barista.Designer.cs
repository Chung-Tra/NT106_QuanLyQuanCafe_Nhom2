using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace GUI
{
    partial class ucAlert_Barista
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges11 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges12 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            pnlSend = new Guna2Panel();
            lblTitle = new Label();
            lblAlertType = new Label();
            cmbAlertType = new Guna2ComboBox();
            txtMessage = new Guna2TextBox();
            btnSendAlert = new Guna2Button();
            pnlHistory = new Guna2Panel();
            lblHistoryTitle = new Label();
            dgvAlertHistory = new Guna2DataGridView();
            colTime = new DataGridViewTextBoxColumn();
            colType = new DataGridViewTextBoxColumn();
            colContent = new DataGridViewTextBoxColumn();
            colStatus = new DataGridViewTextBoxColumn();
            btnReport = new Guna2Button();
            pnlSend.SuspendLayout();
            pnlHistory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAlertHistory).BeginInit();
            SuspendLayout();
            // 
            // pnlSend
            // 
            pnlSend.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlSend.BackColor = Color.FromArgb(31, 31, 34);
            pnlSend.BorderRadius = 14;
            pnlSend.Controls.Add(lblTitle);
            pnlSend.Controls.Add(btnReport);
            pnlSend.Controls.Add(lblAlertType);
            pnlSend.Controls.Add(cmbAlertType);
            pnlSend.Controls.Add(txtMessage);
            pnlSend.Controls.Add(btnSendAlert);
            pnlSend.CustomizableEdges = customizableEdges9;
            pnlSend.Location = new Point(20, 15);
            pnlSend.Name = "pnlSend";
            pnlSend.ShadowDecoration.CustomizableEdges = customizableEdges10;
            pnlSend.Size = new Size(960, 210);
            pnlSend.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(18, 14);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(266, 25);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Cảnh báo hết nguyên liệu";
            // 
            // lblAlertType
            // 
            lblAlertType.AutoSize = true;
            lblAlertType.Font = new Font("Segoe UI", 9.5F);
            lblAlertType.ForeColor = Color.FromArgb(160, 160, 166);
            lblAlertType.Location = new Point(18, 60);
            lblAlertType.Name = "lblAlertType";
            lblAlertType.Size = new Size(35, 17);
            lblAlertType.TabIndex = 2;
            lblAlertType.Text = "Loại:";
            // 
            // cmbAlertType
            // 
            cmbAlertType.BackColor = Color.Transparent;
            cmbAlertType.BorderColor = Color.FromArgb(63, 63, 70);
            cmbAlertType.BorderRadius = 8;
            cmbAlertType.CustomizableEdges = customizableEdges3;
            cmbAlertType.DrawMode = DrawMode.OwnerDrawFixed;
            cmbAlertType.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbAlertType.FillColor = Color.FromArgb(30, 30, 33);
            cmbAlertType.FocusedColor = Color.FromArgb(31, 138, 154);
            cmbAlertType.FocusedState.BorderColor = Color.FromArgb(31, 138, 154);
            cmbAlertType.Font = new Font("Segoe UI", 9.5F);
            cmbAlertType.ForeColor = Color.White;
            cmbAlertType.HoverState.BorderColor = Color.FromArgb(120, 120, 130);
            cmbAlertType.ItemHeight = 26;
            cmbAlertType.Items.AddRange(new object[] { "Hết nguyên liệu", "Sắp hết nguyên liệu", "Thiết bị hỏng", "Khác" });
            cmbAlertType.Location = new Point(80, 56);
            cmbAlertType.Name = "cmbAlertType";
            cmbAlertType.ShadowDecoration.CustomizableEdges = customizableEdges4;
            cmbAlertType.Size = new Size(250, 32);
            cmbAlertType.TabIndex = 3;
            // 
            // txtMessage
            // 
            txtMessage.BorderColor = Color.FromArgb(63, 63, 70);
            txtMessage.BorderRadius = 10;
            txtMessage.CustomizableEdges = customizableEdges5;
            txtMessage.DefaultText = "";
            txtMessage.FillColor = Color.FromArgb(30, 30, 33);
            txtMessage.FocusedState.BorderColor = Color.FromArgb(31, 138, 154);
            txtMessage.Font = new Font("Segoe UI", 10F);
            txtMessage.ForeColor = Color.White;
            txtMessage.HoverState.BorderColor = Color.FromArgb(120, 120, 130);
            txtMessage.Location = new Point(18, 100);
            txtMessage.Multiline = true;
            txtMessage.Name = "txtMessage";
            txtMessage.PasswordChar = '\0';
            txtMessage.PlaceholderForeColor = Color.FromArgb(110, 110, 120);
            txtMessage.PlaceholderText = "Nhập nội dung cảnh báo...";
            txtMessage.SelectedText = "";
            txtMessage.ShadowDecoration.CustomizableEdges = customizableEdges6;
            txtMessage.Size = new Size(580, 95);
            txtMessage.TabIndex = 4;
            // 
            // btnSendAlert
            // 
            btnSendAlert.BorderColor = Color.FromArgb(180, 60, 60);
            btnSendAlert.BorderRadius = 10;
            btnSendAlert.BorderThickness = 1;
            btnSendAlert.Cursor = Cursors.Hand;
            btnSendAlert.CustomizableEdges = customizableEdges7;
            btnSendAlert.FillColor = Color.Transparent;
            btnSendAlert.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            btnSendAlert.ForeColor = Color.FromArgb(220, 80, 80);
            btnSendAlert.HoverState.FillColor = Color.FromArgb(180, 60, 60);
            btnSendAlert.HoverState.ForeColor = Color.White;
            btnSendAlert.Location = new Point(615, 100);
            btnSendAlert.Name = "btnSendAlert";
            btnSendAlert.ShadowDecoration.CustomizableEdges = customizableEdges8;
            btnSendAlert.Size = new Size(130, 95);
            btnSendAlert.TabIndex = 5;
            btnSendAlert.Text = "Gửi cảnh báo";
            btnSendAlert.Click += BtnSendAlert_Click;
            // 
            // pnlHistory
            // 
            pnlHistory.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnlHistory.BackColor = Color.FromArgb(31, 31, 34);
            pnlHistory.BorderRadius = 14;
            pnlHistory.Controls.Add(lblHistoryTitle);
            pnlHistory.Controls.Add(dgvAlertHistory);
            pnlHistory.CustomizableEdges = customizableEdges11;
            pnlHistory.Location = new Point(20, 235);
            pnlHistory.Name = "pnlHistory";
            pnlHistory.ShadowDecoration.CustomizableEdges = customizableEdges12;
            pnlHistory.Size = new Size(960, 410);
            pnlHistory.TabIndex = 1;
            // 
            // lblHistoryTitle
            // 
            lblHistoryTitle.AutoSize = true;
            lblHistoryTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblHistoryTitle.ForeColor = Color.White;
            lblHistoryTitle.Location = new Point(18, 14);
            lblHistoryTitle.Name = "lblHistoryTitle";
            lblHistoryTitle.Size = new Size(155, 20);
            lblHistoryTitle.TabIndex = 0;
            lblHistoryTitle.Text = "Lịch sử cảnh báo";
            // 
            // dgvAlertHistory
            // 
            dataGridViewCellStyle1.BackColor = Color.FromArgb(24, 24, 27);
            dataGridViewCellStyle1.ForeColor = Color.FromArgb(220, 220, 225);
            dgvAlertHistory.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvAlertHistory.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvAlertHistory.BackgroundColor = Color.FromArgb(24, 24, 27);
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(31, 31, 34);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(160, 160, 166);
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(31, 31, 34);
            dataGridViewCellStyle2.SelectionForeColor = Color.FromArgb(160, 160, 166);
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvAlertHistory.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvAlertHistory.Columns.AddRange(new DataGridViewColumn[] { colTime, colType, colContent, colStatus });
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.FromArgb(24, 24, 27);
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(220, 220, 225);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(31, 138, 154);
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(240, 240, 245);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvAlertHistory.DefaultCellStyle = dataGridViewCellStyle3;
            dgvAlertHistory.GridColor = Color.FromArgb(45, 45, 48);
            dgvAlertHistory.Location = new Point(18, 44);
            dgvAlertHistory.Name = "dgvAlertHistory";
            dgvAlertHistory.RowHeadersVisible = false;
            dgvAlertHistory.Size = new Size(924, 348);
            dgvAlertHistory.TabIndex = 1;
            dgvAlertHistory.ThemeStyle.AlternatingRowsStyle.BackColor = Color.FromArgb(24, 24, 27);
            dgvAlertHistory.ThemeStyle.AlternatingRowsStyle.Font = null;
            dgvAlertHistory.ThemeStyle.AlternatingRowsStyle.ForeColor = Color.FromArgb(220, 220, 225);
            dgvAlertHistory.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.Empty;
            dgvAlertHistory.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.Empty;
            dgvAlertHistory.ThemeStyle.BackColor = Color.FromArgb(24, 24, 27);
            dgvAlertHistory.ThemeStyle.GridColor = Color.FromArgb(45, 45, 48);
            dgvAlertHistory.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(31, 31, 34);
            dgvAlertHistory.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvAlertHistory.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dgvAlertHistory.ThemeStyle.HeaderStyle.ForeColor = Color.FromArgb(160, 160, 166);
            dgvAlertHistory.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvAlertHistory.ThemeStyle.HeaderStyle.Height = 23;
            dgvAlertHistory.ThemeStyle.ReadOnly = false;
            dgvAlertHistory.ThemeStyle.RowsStyle.BackColor = Color.FromArgb(24, 24, 27);
            dgvAlertHistory.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvAlertHistory.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 9F);
            dgvAlertHistory.ThemeStyle.RowsStyle.ForeColor = Color.FromArgb(220, 220, 225);
            dgvAlertHistory.ThemeStyle.RowsStyle.Height = 25;
            dgvAlertHistory.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(31, 138, 154);
            dgvAlertHistory.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(240, 240, 245);
            // 
            // colTime
            // 
            colTime.DataPropertyName = "Thời gian";
            colTime.HeaderText = "Thời gian";
            colTime.Name = "Thời gian";
            // 
            // colType
            // 
            colType.DataPropertyName = "Loại";
            colType.HeaderText = "Loại";
            colType.Name = "Loại";
            // 
            // colContent
            // 
            colContent.DataPropertyName = "Nội dung";
            colContent.HeaderText = "Nội dung";
            colContent.Name = "Nội dung";
            // 
            // colStatus
            // 
            colStatus.DataPropertyName = "Trạng thái";
            colStatus.HeaderText = "Trạng thái";
            colStatus.Name = "Trạng thái";
            // 
            // btnReport
            // 
            btnReport.BorderRadius = 8;
            btnReport.Cursor = Cursors.Hand;
            btnReport.CustomizableEdges = customizableEdges1;
            btnReport.FillColor = Color.FromArgb(70, 130, 180);
            btnReport.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnReport.ForeColor = Color.White;
            btnReport.HoverState.FillColor = Color.FromArgb(90, 150, 200);
            btnReport.Location = new Point(847, 14);
            btnReport.Name = "btnReport";
            btnReport.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnReport.Size = new Size(95, 32);
            btnReport.TabIndex = 1;
            btnReport.Text = "Báo cáo";
            btnReport.Click += BtnReport_Click;
            // 
            // ucAlert_Barista
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(39, 39, 42);
            Controls.Add(pnlSend);
            Controls.Add(pnlHistory);
            Name = "ucAlert_Barista";
            Size = new Size(1000, 665);
            Load += UcAlert_Barista_Load;
            pnlSend.ResumeLayout(false);
            pnlSend.PerformLayout();
            pnlHistory.ResumeLayout(false);
            pnlHistory.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAlertHistory).EndInit();
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

        private Guna2Panel pnlSend;
        private Label lblTitle;
        private Label lblAlertType;
        private Guna2ComboBox cmbAlertType;
        private Guna2TextBox txtMessage;
        private Guna2Button btnSendAlert;
        private Guna2Panel pnlHistory;
        private Label lblHistoryTitle;
        private Guna2DataGridView dgvAlertHistory;
        private DataGridViewTextBoxColumn colTime;
        private DataGridViewTextBoxColumn colType;
        private DataGridViewTextBoxColumn colContent;
        private DataGridViewTextBoxColumn colStatus;
        private Guna2Button btnReport;
    }
}
