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
            pnlSend = new Guna2Panel();
            lblTitle = new Label();
            btnReport = new Guna2Button();
            lblAlertType = new Label();
            cmbAlertType = new Guna2ComboBox();
            txtMessage = new Guna2TextBox();
            btnSendAlert = new Guna2Button();
            pnlHistory = new Guna2Panel();
            lblHistoryTitle = new Label();
            dgvAlertHistory = new Guna2DataGridView();
            pnlSend.SuspendLayout();
            pnlHistory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAlertHistory).BeginInit();
            SuspendLayout();

            // ====== pnlSend ======
            pnlSend.BackColor = Color.FromArgb(31, 31, 34);
            pnlSend.BorderRadius = 14;
            pnlSend.Controls.Add(lblTitle);
            pnlSend.Controls.Add(btnReport);
            pnlSend.Controls.Add(lblAlertType);
            pnlSend.Controls.Add(cmbAlertType);
            pnlSend.Controls.Add(txtMessage);
            pnlSend.Controls.Add(btnSendAlert);
            pnlSend.Location = new Point(20, 15);
            pnlSend.Size = new Size(764, 210);

            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(18, 14);
            lblTitle.Text = "⚠️  Cảnh báo hết nguyên liệu";

            btnReport.BorderRadius = 8;
            btnReport.Cursor = Cursors.Hand;
            btnReport.FillColor = Color.FromArgb(70, 130, 180);
            btnReport.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnReport.ForeColor = Color.White;
            btnReport.HoverState.FillColor = Color.FromArgb(90, 150, 200);
            btnReport.Location = new Point(340, 12);
            btnReport.Size = new Size(95, 32);
            btnReport.Text = "📊 Báo cáo";

            lblAlertType.AutoSize = true;
            lblAlertType.Font = new Font("Segoe UI", 9.5F);
            lblAlertType.ForeColor = Color.FromArgb(160, 160, 166);
            lblAlertType.Location = new Point(18, 60);
            lblAlertType.Text = "Loại:";

            cmbAlertType.BackColor = Color.Transparent;
            cmbAlertType.BorderColor = Color.FromArgb(63, 63, 70);
            cmbAlertType.BorderRadius = 8;
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
            cmbAlertType.Size = new Size(250, 32);

            txtMessage.BorderColor = Color.FromArgb(63, 63, 70);
            txtMessage.BorderRadius = 10;
            txtMessage.DefaultText = "";
            txtMessage.FillColor = Color.FromArgb(30, 30, 33);
            txtMessage.FocusedState.BorderColor = Color.FromArgb(31, 138, 154);
            txtMessage.Font = new Font("Segoe UI", 10F);
            txtMessage.ForeColor = Color.White;
            txtMessage.HoverState.BorderColor = Color.FromArgb(120, 120, 130);
            txtMessage.Location = new Point(18, 100);
            txtMessage.Multiline = true;
            txtMessage.PlaceholderForeColor = Color.FromArgb(110, 110, 120);
            txtMessage.PlaceholderText = "Nhập nội dung cảnh báo...";
            txtMessage.Size = new Size(580, 95);

            btnSendAlert.BorderColor = Color.FromArgb(180, 60, 60);
            btnSendAlert.BorderRadius = 10;
            btnSendAlert.BorderThickness = 1;
            btnSendAlert.Cursor = Cursors.Hand;
            btnSendAlert.FillColor = Color.Transparent;
            btnSendAlert.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            btnSendAlert.ForeColor = Color.FromArgb(220, 80, 80);
            btnSendAlert.HoverState.FillColor = Color.FromArgb(180, 60, 60);
            btnSendAlert.HoverState.ForeColor = Color.White;
            btnSendAlert.Location = new Point(615, 100);
            btnSendAlert.Size = new Size(130, 95);
            btnSendAlert.Text = "🚨 Gửi cảnh báo";
            btnSendAlert.Click += btnSendAlert_Click;

            // ====== pnlHistory ======
            pnlHistory.BackColor = Color.FromArgb(31, 31, 34);
            pnlHistory.BorderRadius = 14;
            pnlHistory.Controls.Add(lblHistoryTitle);
            pnlHistory.Controls.Add(dgvAlertHistory);
            pnlHistory.Location = new Point(20, 235);
            pnlHistory.Size = new Size(764, 280);

            lblHistoryTitle.AutoSize = true;
            lblHistoryTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblHistoryTitle.ForeColor = Color.White;
            lblHistoryTitle.Location = new Point(18, 14);
            lblHistoryTitle.Text = "📜  Lịch sử cảnh báo";

            dgvAlertHistory.BackgroundColor = Color.FromArgb(24, 24, 27);
            dgvAlertHistory.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(31, 31, 34);
            dgvAlertHistory.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(160, 160, 166);
            dgvAlertHistory.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dgvAlertHistory.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(31, 31, 34);
            dgvAlertHistory.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.FromArgb(160, 160, 166);
            dgvAlertHistory.DefaultCellStyle.BackColor = Color.FromArgb(24, 24, 27);
            dgvAlertHistory.DefaultCellStyle.ForeColor = Color.FromArgb(220, 220, 225);
            dgvAlertHistory.DefaultCellStyle.SelectionBackColor = Color.FromArgb(31, 138, 154);
            dgvAlertHistory.DefaultCellStyle.SelectionForeColor = Color.FromArgb(240, 240, 245);
            dgvAlertHistory.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(24, 24, 27);
            dgvAlertHistory.AlternatingRowsDefaultCellStyle.ForeColor = Color.FromArgb(220, 220, 225);
            dgvAlertHistory.GridColor = Color.FromArgb(45, 45, 48);
            ConfigureGrid(dgvAlertHistory);
            dgvAlertHistory.Location = new Point(18, 44);
            dgvAlertHistory.Size = new Size(728, 220);

            // ====== ucAlert_Barista ======
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(39, 39, 42);
            Controls.Add(pnlSend);
            Controls.Add(pnlHistory);
            Name = "ucAlert_Barista";
            Size = new Size(804, 530);
            pnlSend.ResumeLayout(false);
            pnlSend.PerformLayout();
            pnlHistory.ResumeLayout(false);
            pnlHistory.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAlertHistory).EndInit();
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

        private Guna2Panel pnlSend;
        private Label lblTitle;
        private Guna2Button btnReport;
        private Label lblAlertType;
        private Guna2ComboBox cmbAlertType;
        private Guna2TextBox txtMessage;
        private Guna2Button btnSendAlert;
        private Guna2Panel pnlHistory;
        private Label lblHistoryTitle;
        private Guna2DataGridView dgvAlertHistory;
    }
}
