namespace GUI
{
    partial class ucNotification_Manager
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

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            pnlPendingRequests = new Panel();
            lblPendingTitle = new Label();
            dgvPendingLeave = new DataGridView();
            btnApprove = new Button();
            btnReject = new Button();
            btnChatStaff = new Button();
            pnlSchedule = new Panel();
            lblScheduleTitle = new Label();
            dgvSchedule = new DataGridView();
            btnSaveSchedule = new Button();
            pnlPendingRequests.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPendingLeave).BeginInit();
            pnlSchedule.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSchedule).BeginInit();
            SuspendLayout();
            //
            // pnlPendingRequests
            //
            pnlPendingRequests.BackColor = Color.FromArgb(30, 30, 30);
            pnlPendingRequests.Controls.Add(lblPendingTitle);
            pnlPendingRequests.Controls.Add(dgvPendingLeave);
            pnlPendingRequests.Controls.Add(btnApprove);
            pnlPendingRequests.Controls.Add(btnReject);
            pnlPendingRequests.Controls.Add(btnChatStaff);
            pnlPendingRequests.Location = new Point(20, 15);
            pnlPendingRequests.Name = "pnlPendingRequests";
            pnlPendingRequests.Size = new Size(764, 250);
            pnlPendingRequests.TabIndex = 0;
            //
            // lblPendingTitle
            //
            lblPendingTitle.AutoSize = true;
            lblPendingTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblPendingTitle.ForeColor = Color.Orange;
            lblPendingTitle.Location = new Point(15, 15);
            lblPendingTitle.Name = "lblPendingTitle";
            lblPendingTitle.Size = new Size(232, 21);
            lblPendingTitle.TabIndex = 0;
            lblPendingTitle.Text = "Đơn xin nghỉ chờ duyệt";
            //
            // dgvPendingLeave
            //
            dgvPendingLeave.BackgroundColor = Color.FromArgb(45, 45, 48);
            dgvPendingLeave.BorderStyle = BorderStyle.None;
            dgvPendingLeave.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(45, 45, 48);
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = Color.Gray;
            dataGridViewCellStyle1.SelectionForeColor = Color.White;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
            dgvPendingLeave.DefaultCellStyle = dataGridViewCellStyle1;
            dgvPendingLeave.GridColor = Color.FromArgb(60, 60, 60);
            dgvPendingLeave.Location = new Point(15, 45);
            dgvPendingLeave.Name = "dgvPendingLeave";
            dgvPendingLeave.RowHeadersVisible = false;
            dgvPendingLeave.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPendingLeave.Size = new Size(550, 190);
            dgvPendingLeave.TabIndex = 1;
            dgvPendingLeave.SelectionChanged += dgvPendingLeave_SelectionChanged;
            //
            // btnApprove
            //
            btnApprove.BackColor = Color.MediumSeaGreen;
            btnApprove.FlatAppearance.BorderSize = 0;
            btnApprove.FlatStyle = FlatStyle.Flat;
            btnApprove.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            btnApprove.ForeColor = Color.White;
            btnApprove.Location = new Point(585, 45);
            btnApprove.Name = "btnApprove";
            btnApprove.Size = new Size(160, 40);
            btnApprove.TabIndex = 2;
            btnApprove.Text = "Duyệt";
            btnApprove.UseVisualStyleBackColor = false;
            btnApprove.Click += btnApprove_Click;
            //
            // btnReject
            //
            btnReject.BackColor = Color.IndianRed;
            btnReject.FlatAppearance.BorderSize = 0;
            btnReject.FlatStyle = FlatStyle.Flat;
            btnReject.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            btnReject.ForeColor = Color.White;
            btnReject.Location = new Point(585, 100);
            btnReject.Name = "btnReject";
            btnReject.Size = new Size(160, 40);
            btnReject.TabIndex = 3;
            btnReject.Text = "Từ chối";
            btnReject.UseVisualStyleBackColor = false;
            btnReject.Click += btnReject_Click;
            //
            // btnChatStaff
            //
            btnChatStaff.BackColor = Color.SteelBlue;
            btnChatStaff.FlatAppearance.BorderSize = 0;
            btnChatStaff.FlatStyle = FlatStyle.Flat;
            btnChatStaff.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            btnChatStaff.ForeColor = Color.White;
            btnChatStaff.Location = new Point(585, 155);
            btnChatStaff.Name = "btnChatStaff";
            btnChatStaff.Size = new Size(160, 40);
            btnChatStaff.TabIndex = 4;
            btnChatStaff.Text = "Chat";
            btnChatStaff.UseVisualStyleBackColor = false;
            btnChatStaff.Click += btnChatStaff_Click;
            //
            // pnlSchedule
            //
            pnlSchedule.BackColor = Color.FromArgb(30, 30, 30);
            pnlSchedule.Controls.Add(lblScheduleTitle);
            pnlSchedule.Controls.Add(dgvSchedule);
            pnlSchedule.Controls.Add(btnSaveSchedule);
            pnlSchedule.Location = new Point(20, 275);
            pnlSchedule.Name = "pnlSchedule";
            pnlSchedule.Size = new Size(764, 240);
            pnlSchedule.TabIndex = 1;
            //
            // lblScheduleTitle
            //
            lblScheduleTitle.AutoSize = true;
            lblScheduleTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblScheduleTitle.ForeColor = Color.White;
            lblScheduleTitle.Location = new Point(15, 15);
            lblScheduleTitle.Name = "lblScheduleTitle";
            lblScheduleTitle.Size = new Size(229, 21);
            lblScheduleTitle.TabIndex = 0;
            lblScheduleTitle.Text = "Xếp lịch làm việc tuần";
            //
            // dgvSchedule
            //
            dgvSchedule.BackgroundColor = Color.FromArgb(45, 45, 48);
            dgvSchedule.BorderStyle = BorderStyle.None;
            dgvSchedule.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(45, 45, 48);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = Color.Gray;
            dataGridViewCellStyle2.SelectionForeColor = Color.White;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvSchedule.DefaultCellStyle = dataGridViewCellStyle2;
            dgvSchedule.GridColor = Color.FromArgb(60, 60, 60);
            dgvSchedule.Location = new Point(15, 45);
            dgvSchedule.Name = "dgvSchedule";
            dgvSchedule.RowHeadersVisible = false;
            dgvSchedule.Size = new Size(550, 180);
            dgvSchedule.TabIndex = 1;
            dgvSchedule.CellValueChanged += dgvSchedule_CellValueChanged;
            //
            // btnSaveSchedule
            //
            btnSaveSchedule.BackColor = Color.MediumSeaGreen;
            btnSaveSchedule.FlatAppearance.BorderSize = 0;
            btnSaveSchedule.FlatStyle = FlatStyle.Flat;
            btnSaveSchedule.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            btnSaveSchedule.ForeColor = Color.White;
            btnSaveSchedule.Location = new Point(585, 45);
            btnSaveSchedule.Name = "btnSaveSchedule";
            btnSaveSchedule.Size = new Size(160, 40);
            btnSaveSchedule.TabIndex = 2;
            btnSaveSchedule.Text = "Lưu lịch";
            btnSaveSchedule.UseVisualStyleBackColor = false;
            btnSaveSchedule.Click += btnSaveSchedule_Click;
            //
            // ucNotification_Manager
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(45, 45, 48);
            Controls.Add(pnlSchedule);
            Controls.Add(pnlPendingRequests);
            Name = "ucNotification_Manager";
            Size = new Size(804, 530);
            pnlPendingRequests.ResumeLayout(false);
            pnlPendingRequests.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPendingLeave).EndInit();
            pnlSchedule.ResumeLayout(false);
            pnlSchedule.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSchedule).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlPendingRequests;
        private System.Windows.Forms.Label lblPendingTitle;
        private System.Windows.Forms.DataGridView dgvPendingLeave;
        private System.Windows.Forms.Button btnApprove;
        private System.Windows.Forms.Button btnReject;
        private System.Windows.Forms.Button btnChatStaff;
        private System.Windows.Forms.Panel pnlSchedule;
        private System.Windows.Forms.Label lblScheduleTitle;
        private System.Windows.Forms.DataGridView dgvSchedule;
        private System.Windows.Forms.Button btnSaveSchedule;
    }
}
