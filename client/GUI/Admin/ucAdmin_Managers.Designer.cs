using System.Drawing;
using System.Windows.Forms;
using System.Xml.Linq;

namespace GUI
{
    partial class ucAdmin_Managers
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            pnlSummary = new Panel();
            btnSwitchRole = new Button();
            lblLeaveValue = new Label();
            lblLeaveTitle = new Label();
            lblPresentValue = new Label();
            lblPresentTitle = new Label();
            lblTotalManagerValue = new Label();
            lblTotalManagerTitle = new Label();
            pnlManagerList = new Panel();
            btnEditManager = new Button();
            btnAddManager = new Button();
            dgvManagers = new DataGridView();
            lblManagerTitle = new Label();
            pnlLeaveRequests = new Panel();
            btnApproveLeave = new Button();
            lstLeaveReq = new ListBox();
            lblLeaveReqTitle = new Label();
            pnlAuditLog = new Panel();
            dgvAuditLog = new DataGridView();
            lblAuditTitle = new Label();
            pnlSummary.SuspendLayout();
            pnlManagerList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvManagers).BeginInit();
            pnlLeaveRequests.SuspendLayout();
            pnlAuditLog.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAuditLog).BeginInit();
            SuspendLayout();
            // 
            // pnlSummary
            // 
            pnlSummary.BackColor = Color.FromArgb(30, 30, 30);
            pnlSummary.Controls.Add(btnSwitchRole);
            pnlSummary.Controls.Add(lblLeaveValue);
            pnlSummary.Controls.Add(lblLeaveTitle);
            pnlSummary.Controls.Add(lblPresentValue);
            pnlSummary.Controls.Add(lblPresentTitle);
            pnlSummary.Controls.Add(lblTotalManagerValue);
            pnlSummary.Controls.Add(lblTotalManagerTitle);
            pnlSummary.Location = new Point(20, 20);
            pnlSummary.Name = "pnlSummary";
            pnlSummary.Size = new Size(764, 80);
            pnlSummary.TabIndex = 0;
            // 
            // btnSwitchRole
            // 
            btnSwitchRole.BackColor = Color.Goldenrod;
            btnSwitchRole.Cursor = Cursors.Hand;
            btnSwitchRole.FlatAppearance.BorderSize = 0;
            btnSwitchRole.FlatStyle = FlatStyle.Flat;
            btnSwitchRole.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnSwitchRole.ForeColor = Color.White;
            btnSwitchRole.Location = new Point(540, 15);
            btnSwitchRole.Name = "btnSwitchRole";
            btnSwitchRole.Size = new Size(200, 50);
            btnSwitchRole.TabIndex = 6;
            btnSwitchRole.Text = "⚡ Đóng vai Quản lý";
            btnSwitchRole.UseVisualStyleBackColor = false;
            // 
            // lblLeaveValue
            // 
            lblLeaveValue.AutoSize = true;
            lblLeaveValue.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold);
            lblLeaveValue.ForeColor = Color.Orange;
            lblLeaveValue.Location = new Point(350, 35);
            lblLeaveValue.Name = "lblLeaveValue";
            lblLeaveValue.Size = new Size(90, 30);
            lblLeaveValue.TabIndex = 2;
            lblLeaveValue.Text = "1 người";
            // 
            // lblLeaveTitle
            // 
            lblLeaveTitle.AutoSize = true;
            lblLeaveTitle.Font = new Font("Segoe UI", 9.75F);
            lblLeaveTitle.ForeColor = Color.Gray;
            lblLeaveTitle.Location = new Point(350, 15);
            lblLeaveTitle.Name = "lblLeaveTitle";
            lblLeaveTitle.Size = new Size(101, 17);
            lblLeaveTitle.TabIndex = 3;
            lblLeaveTitle.Text = "Quản lý xin nghỉ";
            // 
            // lblPresentValue
            // 
            lblPresentValue.AutoSize = true;
            lblPresentValue.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold);
            lblPresentValue.ForeColor = Color.MediumSeaGreen;
            lblPresentValue.Location = new Point(180, 35);
            lblPresentValue.Name = "lblPresentValue";
            lblPresentValue.Size = new Size(90, 30);
            lblPresentValue.TabIndex = 4;
            lblPresentValue.Text = "2 người";
            // 
            // lblPresentTitle
            // 
            lblPresentTitle.AutoSize = true;
            lblPresentTitle.Font = new Font("Segoe UI", 9.75F);
            lblPresentTitle.ForeColor = Color.Gray;
            lblPresentTitle.Location = new Point(180, 15);
            lblPresentTitle.Name = "lblPresentTitle";
            lblPresentTitle.Size = new Size(131, 17);
            lblPresentTitle.TabIndex = 5;
            lblPresentTitle.Text = "QL đang làm việc \U0001f7e2";
            // 
            // lblTotalManagerValue
            // 
            lblTotalManagerValue.AutoSize = true;
            lblTotalManagerValue.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold);
            lblTotalManagerValue.ForeColor = Color.White;
            lblTotalManagerValue.Location = new Point(20, 35);
            lblTotalManagerValue.Name = "lblTotalManagerValue";
            lblTotalManagerValue.Size = new Size(90, 30);
            lblTotalManagerValue.TabIndex = 6;
            lblTotalManagerValue.Text = "3 người";
            // 
            // lblTotalManagerTitle
            // 
            lblTotalManagerTitle.AutoSize = true;
            lblTotalManagerTitle.Font = new Font("Segoe UI", 9.75F);
            lblTotalManagerTitle.ForeColor = Color.Gray;
            lblTotalManagerTitle.Location = new Point(20, 15);
            lblTotalManagerTitle.Name = "lblTotalManagerTitle";
            lblTotalManagerTitle.Size = new Size(105, 17);
            lblTotalManagerTitle.TabIndex = 7;
            lblTotalManagerTitle.Text = "Tổng Số Quản lý";
            // 
            // pnlManagerList
            // 
            pnlManagerList.BackColor = Color.FromArgb(30, 30, 30);
            pnlManagerList.Controls.Add(btnEditManager);
            pnlManagerList.Controls.Add(btnAddManager);
            pnlManagerList.Controls.Add(dgvManagers);
            pnlManagerList.Controls.Add(lblManagerTitle);
            pnlManagerList.Location = new Point(20, 120);
            pnlManagerList.Name = "pnlManagerList";
            pnlManagerList.Size = new Size(450, 190);
            pnlManagerList.TabIndex = 1;
            // 
            // btnEditManager
            // 
            btnEditManager.BackColor = Color.FromArgb(45, 45, 48);
            btnEditManager.FlatAppearance.BorderSize = 0;
            btnEditManager.FlatStyle = FlatStyle.Flat;
            btnEditManager.ForeColor = Color.IndianRed;
            btnEditManager.Location = new Point(360, 15);
            btnEditManager.Name = "btnEditManager";
            btnEditManager.Size = new Size(70, 25);
            btnEditManager.TabIndex = 0;
            btnEditManager.Text = "Sửa QL";
            btnEditManager.UseVisualStyleBackColor = false;
            // 
            // btnAddManager
            // 
            btnAddManager.BackColor = Color.MediumSeaGreen;
            btnAddManager.FlatAppearance.BorderSize = 0;
            btnAddManager.FlatStyle = FlatStyle.Flat;
            btnAddManager.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnAddManager.ForeColor = Color.White;
            btnAddManager.Location = new Point(235, 15);
            btnAddManager.Name = "btnAddManager";
            btnAddManager.Size = new Size(115, 25);
            btnAddManager.TabIndex = 1;
            btnAddManager.Text = "+ Thêm Quản lý";
            btnAddManager.UseVisualStyleBackColor = false;
            // 
            // dgvManagers
            // 
            dgvManagers.BackgroundColor = Color.FromArgb(45, 45, 48);
            dgvManagers.BorderStyle = BorderStyle.None;
            dgvManagers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(45, 45, 48);
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = Color.Gray;
            dataGridViewCellStyle1.SelectionForeColor = Color.White;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
            dgvManagers.DefaultCellStyle = dataGridViewCellStyle1;
            dgvManagers.Location = new Point(20, 50);
            dgvManagers.Name = "dgvManagers";
            dgvManagers.RowHeadersWidth = 51;
            dgvManagers.Size = new Size(410, 120);
            dgvManagers.TabIndex = 1;
            // 
            // lblManagerTitle
            // 
            lblManagerTitle.AutoSize = true;
            lblManagerTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblManagerTitle.ForeColor = Color.Goldenrod;
            lblManagerTitle.Location = new Point(15, 15);
            lblManagerTitle.Name = "lblManagerTitle";
            lblManagerTitle.Size = new Size(143, 21);
            lblManagerTitle.TabIndex = 2;
            lblManagerTitle.Text = "Hồ sơ Quản lý 📇";
            // 
            // pnlLeaveRequests
            // 
            pnlLeaveRequests.BackColor = Color.FromArgb(30, 30, 30);
            pnlLeaveRequests.Controls.Add(btnApproveLeave);
            pnlLeaveRequests.Controls.Add(lstLeaveReq);
            pnlLeaveRequests.Controls.Add(lblLeaveReqTitle);
            pnlLeaveRequests.Location = new Point(490, 120);
            pnlLeaveRequests.Name = "pnlLeaveRequests";
            pnlLeaveRequests.Size = new Size(294, 190);
            pnlLeaveRequests.TabIndex = 3;
            // 
            // btnApproveLeave
            // 
            btnApproveLeave.BackColor = Color.MediumSeaGreen;
            btnApproveLeave.FlatAppearance.BorderSize = 0;
            btnApproveLeave.FlatStyle = FlatStyle.Flat;
            btnApproveLeave.ForeColor = Color.White;
            btnApproveLeave.Location = new Point(194, 12);
            btnApproveLeave.Name = "btnApproveLeave";
            btnApproveLeave.Size = new Size(85, 25);
            btnApproveLeave.TabIndex = 0;
            btnApproveLeave.Text = "Duyệt (1)";
            btnApproveLeave.UseVisualStyleBackColor = false;
            // 
            // lstLeaveReq
            // 
            lstLeaveReq.BackColor = Color.FromArgb(45, 45, 48);
            lstLeaveReq.BorderStyle = BorderStyle.None;
            lstLeaveReq.Font = new Font("Segoe UI", 9.75F);
            lstLeaveReq.ForeColor = Color.White;
            lstLeaveReq.FormattingEnabled = true;
            lstLeaveReq.ItemHeight = 17;
            lstLeaveReq.Location = new Point(20, 50);
            lstLeaveReq.Name = "lstLeaveReq";
            lstLeaveReq.Size = new Size(254, 119);
            lstLeaveReq.TabIndex = 1;
            // 
            // lblLeaveReqTitle
            // 
            lblLeaveReqTitle.AutoSize = true;
            lblLeaveReqTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblLeaveReqTitle.ForeColor = Color.Orange;
            lblLeaveReqTitle.Location = new Point(15, 15);
            lblLeaveReqTitle.Name = "lblLeaveReqTitle";
            lblLeaveReqTitle.Size = new Size(167, 20);
            lblLeaveReqTitle.TabIndex = 2;
            lblLeaveReqTitle.Text = "Đơn xin nghỉ (Quản lý)";
            // 
            // pnlAuditLog
            // 
            pnlAuditLog.BackColor = Color.FromArgb(30, 30, 30);
            pnlAuditLog.Controls.Add(dgvAuditLog);
            pnlAuditLog.Controls.Add(lblAuditTitle);
            pnlAuditLog.Location = new Point(20, 330);
            pnlAuditLog.Name = "pnlAuditLog";
            pnlAuditLog.Size = new Size(764, 180);
            pnlAuditLog.TabIndex = 4;
            // 
            // dgvAuditLog
            // 
            dgvAuditLog.BackgroundColor = Color.FromArgb(45, 45, 48);
            dgvAuditLog.BorderStyle = BorderStyle.None;
            dgvAuditLog.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(45, 45, 48);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = Color.IndianRed;
            dataGridViewCellStyle2.SelectionForeColor = Color.White;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvAuditLog.DefaultCellStyle = dataGridViewCellStyle2;
            dgvAuditLog.Location = new Point(20, 45);
            dgvAuditLog.Name = "dgvAuditLog";
            dgvAuditLog.RowHeadersWidth = 51;
            dgvAuditLog.Size = new Size(720, 115);
            dgvAuditLog.TabIndex = 3;
            // 
            // lblAuditTitle
            // 
            lblAuditTitle.AutoSize = true;
            lblAuditTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblAuditTitle.ForeColor = Color.IndianRed;
            lblAuditTitle.Location = new Point(15, 15);
            lblAuditTitle.Name = "lblAuditTitle";
            lblAuditTitle.Size = new Size(385, 20);
            lblAuditTitle.TabIndex = 2;
            lblAuditTitle.Text = "🔔 Nhắc nhở: Lịch sử thay đổi chấm công của Quản lý";
            // 
            // ucAdmin_Managers
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(45, 45, 48);
            Controls.Add(pnlAuditLog);
            Controls.Add(pnlLeaveRequests);
            Controls.Add(pnlManagerList);
            Controls.Add(pnlSummary);
            Name = "ucAdmin_Managers";
            Size = new Size(804, 530);
            Load += this.ucAdmin_Managers_Load;
            pnlSummary.ResumeLayout(false);
            pnlSummary.PerformLayout();
            pnlManagerList.ResumeLayout(false);
            pnlManagerList.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvManagers).EndInit();
            pnlLeaveRequests.ResumeLayout(false);
            pnlLeaveRequests.PerformLayout();
            pnlAuditLog.ResumeLayout(false);
            pnlAuditLog.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAuditLog).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlSummary;
        private System.Windows.Forms.Label lblTotalManagerTitle;
        private System.Windows.Forms.Label lblTotalManagerValue;
        private System.Windows.Forms.Label lblPresentTitle;
        private System.Windows.Forms.Label lblPresentValue;
        private System.Windows.Forms.Label lblLeaveTitle;
        private System.Windows.Forms.Label lblLeaveValue;
        private System.Windows.Forms.Button btnSwitchRole;

        private System.Windows.Forms.Panel pnlManagerList;
        private System.Windows.Forms.Label lblManagerTitle;
        private System.Windows.Forms.DataGridView dgvManagers;
        private System.Windows.Forms.Button btnAddManager;
        private System.Windows.Forms.Button btnEditManager;

        private System.Windows.Forms.Panel pnlLeaveRequests;
        private System.Windows.Forms.Label lblLeaveReqTitle;
        private System.Windows.Forms.ListBox lstLeaveReq;
        private System.Windows.Forms.Button btnApproveLeave;

        private System.Windows.Forms.Panel pnlAuditLog;
        private System.Windows.Forms.Label lblAuditTitle;
        private System.Windows.Forms.DataGridView dgvAuditLog;
    }
}