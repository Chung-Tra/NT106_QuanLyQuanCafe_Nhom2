namespace GUI
{
    partial class ucOrders_Manager
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
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            pnlSummary = new Panel();
            lblEmptyTablesValue = new Label();
            lblEmptyTablesTitle = new Label();
            lblPendingValue = new Label();
            lblPendingTitle = new Label();
            lblSoldOutValue = new Label();
            lblSoldOutTitle = new Label();
            pnlTableStatus = new Panel();
            btnStatus = new Button();
            btnFilterTable = new Button();
            cboTableStatus = new ComboBox();
            dgvTableStatus = new DataGridView();
            lblTableStatusTitle = new Label();
            pnlSoldOut = new Panel();
            btnUpdateSoldOut = new Button();
            lstSoldOut = new ListBox();
            lblSoldOutListTitle = new Label();
            pnlKitchenWarning = new Panel();
            lstKitchenWarning = new ListBox();
            lblKitchenWarningTitle = new Label();
            pnlSummary.SuspendLayout();
            pnlTableStatus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTableStatus).BeginInit();
            pnlSoldOut.SuspendLayout();
            pnlKitchenWarning.SuspendLayout();
            SuspendLayout();
            // 
            // pnlSummary
            // 
            pnlSummary.BackColor = Color.FromArgb(30, 30, 30);
            pnlSummary.Controls.Add(lblEmptyTablesValue);
            pnlSummary.Controls.Add(lblEmptyTablesTitle);
            pnlSummary.Controls.Add(lblPendingValue);
            pnlSummary.Controls.Add(lblPendingTitle);
            pnlSummary.Controls.Add(lblSoldOutValue);
            pnlSummary.Controls.Add(lblSoldOutTitle);
            pnlSummary.Location = new Point(20, 20);
            pnlSummary.Name = "pnlSummary";
            pnlSummary.Size = new Size(764, 80);
            pnlSummary.TabIndex = 0;
            // 
            // lblEmptyTablesValue
            // 
            lblEmptyTablesValue.AutoSize = true;
            lblEmptyTablesValue.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold);
            lblEmptyTablesValue.ForeColor = Color.MediumSeaGreen;
            lblEmptyTablesValue.Location = new Point(20, 35);
            lblEmptyTablesValue.Name = "lblEmptyTablesValue";
            lblEmptyTablesValue.Size = new Size(125, 30);
            lblEmptyTablesValue.TabIndex = 0;
            lblEmptyTablesValue.Text = "12 / 20 bàn";
            // 
            // lblEmptyTablesTitle
            // 
            lblEmptyTablesTitle.AutoSize = true;
            lblEmptyTablesTitle.Font = new Font("Segoe UI", 9.75F);
            lblEmptyTablesTitle.ForeColor = Color.Gray;
            lblEmptyTablesTitle.Location = new Point(20, 15);
            lblEmptyTablesTitle.Name = "lblEmptyTablesTitle";
            lblEmptyTablesTitle.Size = new Size(127, 17);
            lblEmptyTablesTitle.TabIndex = 1;
            lblEmptyTablesTitle.Text = "Trạng thái Bàn trống";
            // 
            // lblPendingValue
            // 
            lblPendingValue.AutoSize = true;
            lblPendingValue.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold);
            lblPendingValue.ForeColor = Color.Orange;
            lblPendingValue.Location = new Point(260, 35);
            lblPendingValue.Name = "lblPendingValue";
            lblPendingValue.Size = new Size(68, 30);
            lblPendingValue.TabIndex = 2;
            lblPendingValue.Text = "3 bàn";
            // 
            // lblPendingTitle
            // 
            lblPendingTitle.AutoSize = true;
            lblPendingTitle.Font = new Font("Segoe UI", 9.75F);
            lblPendingTitle.ForeColor = Color.Gray;
            lblPendingTitle.Location = new Point(260, 15);
            lblPendingTitle.Name = "lblPendingTitle";
            lblPendingTitle.Size = new Size(139, 17);
            lblPendingTitle.TabIndex = 3;
            lblPendingTitle.Text = "Bàn đang chờ lên món";
            // 
            // lblSoldOutValue
            // 
            lblSoldOutValue.AutoSize = true;
            lblSoldOutValue.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold);
            lblSoldOutValue.ForeColor = Color.IndianRed;
            lblSoldOutValue.Location = new Point(500, 35);
            lblSoldOutValue.Name = "lblSoldOutValue";
            lblSoldOutValue.Size = new Size(76, 30);
            lblSoldOutValue.TabIndex = 4;
            lblSoldOutValue.Text = "2 món";
            // 
            // lblSoldOutTitle
            // 
            lblSoldOutTitle.AutoSize = true;
            lblSoldOutTitle.Font = new Font("Segoe UI", 9.75F);
            lblSoldOutTitle.ForeColor = Color.Gray;
            lblSoldOutTitle.Location = new Point(500, 15);
            lblSoldOutTitle.Name = "lblSoldOutTitle";
            lblSoldOutTitle.Size = new Size(142, 17);
            lblSoldOutTitle.TabIndex = 5;
            lblSoldOutTitle.Text = "Món Đã Hết (Sold Out)";
            // 
            // pnlTableStatus
            // 
            pnlTableStatus.BackColor = Color.FromArgb(30, 30, 30);
            pnlTableStatus.Controls.Add(btnStatus);
            pnlTableStatus.Controls.Add(btnFilterTable);
            pnlTableStatus.Controls.Add(cboTableStatus);
            pnlTableStatus.Controls.Add(dgvTableStatus);
            pnlTableStatus.Controls.Add(lblTableStatusTitle);
            pnlTableStatus.Location = new Point(20, 120);
            pnlTableStatus.Name = "pnlTableStatus";
            pnlTableStatus.Size = new Size(450, 390);
            pnlTableStatus.TabIndex = 1;
            // 
            // btnStatus
            // 
            btnStatus.BackColor = Color.FromArgb(45, 45, 48);
            btnStatus.FlatAppearance.BorderSize = 0;
            btnStatus.FlatStyle = FlatStyle.Flat;
            btnStatus.ForeColor = Color.White;
            btnStatus.Location = new Point(345, 12);
            btnStatus.Name = "btnStatus";
            btnStatus.Size = new Size(85, 25);
            btnStatus.TabIndex = 3;
            btnStatus.Text = "Cập nhật";
            btnStatus.UseVisualStyleBackColor = false;
            // 
            // btnFilterTable
            // 
            btnFilterTable.BackColor = Color.FromArgb(45, 45, 48);
            btnFilterTable.FlatAppearance.BorderSize = 0;
            btnFilterTable.FlatStyle = FlatStyle.Flat;
            btnFilterTable.ForeColor = Color.White;
            btnFilterTable.Location = new Point(345, 345);
            btnFilterTable.Name = "btnFilterTable";
            btnFilterTable.Size = new Size(85, 25);
            btnFilterTable.TabIndex = 4;
            btnFilterTable.Text = "Lọc";
            btnFilterTable.UseVisualStyleBackColor = false;
            btnFilterTable.Click += btnFilterTable_Click;
            // 
            // cboTableStatus
            // 
            cboTableStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cboTableStatus.FormattingEnabled = true;
            cboTableStatus.Location = new Point(20, 346);
            cboTableStatus.Name = "cboTableStatus";
            cboTableStatus.Size = new Size(315, 23);
            cboTableStatus.TabIndex = 3;
            // 
            // dgvTableStatus
            // 
            dgvTableStatus.BackgroundColor = Color.FromArgb(45, 45, 48);
            dgvTableStatus.BorderStyle = BorderStyle.None;
            dgvTableStatus.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(45, 45, 48);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = Color.Gray;
            dataGridViewCellStyle2.SelectionForeColor = Color.White;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvTableStatus.DefaultCellStyle = dataGridViewCellStyle2;
            dgvTableStatus.Location = new Point(20, 50);
            dgvTableStatus.Name = "dgvTableStatus";
            dgvTableStatus.Size = new Size(410, 320);
            dgvTableStatus.TabIndex = 1;
            // 
            // lblTableStatusTitle
            // 
            lblTableStatusTitle.AutoSize = true;
            lblTableStatusTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTableStatusTitle.ForeColor = Color.White;
            lblTableStatusTitle.Location = new Point(15, 15);
            lblTableStatusTitle.Name = "lblTableStatusTitle";
            lblTableStatusTitle.Size = new Size(214, 21);
            lblTableStatusTitle.TabIndex = 2;
            lblTableStatusTitle.Text = "Trạng thái Phục vụ các Bàn";
            // 
            // pnlSoldOut
            // 
            pnlSoldOut.BackColor = Color.FromArgb(30, 30, 30);
            pnlSoldOut.Controls.Add(btnUpdateSoldOut);
            pnlSoldOut.Controls.Add(lstSoldOut);
            pnlSoldOut.Controls.Add(lblSoldOutListTitle);
            pnlSoldOut.Location = new Point(490, 120);
            pnlSoldOut.Name = "pnlSoldOut";
            pnlSoldOut.Size = new Size(294, 180);
            pnlSoldOut.TabIndex = 2;
            // 
            // btnUpdateSoldOut
            // 
            btnUpdateSoldOut.BackColor = Color.FromArgb(45, 45, 48);
            btnUpdateSoldOut.FlatAppearance.BorderSize = 0;
            btnUpdateSoldOut.FlatStyle = FlatStyle.Flat;
            btnUpdateSoldOut.ForeColor = Color.White;
            btnUpdateSoldOut.Location = new Point(194, 12);
            btnUpdateSoldOut.Name = "btnUpdateSoldOut";
            btnUpdateSoldOut.Size = new Size(85, 25);
            btnUpdateSoldOut.TabIndex = 0;
            btnUpdateSoldOut.Text = "Cập nhật";
            btnUpdateSoldOut.UseVisualStyleBackColor = false;
            // 
            // lstSoldOut
            // 
            lstSoldOut.BackColor = Color.FromArgb(45, 45, 48);
            lstSoldOut.BorderStyle = BorderStyle.None;
            lstSoldOut.Font = new Font("Segoe UI", 9.75F);
            lstSoldOut.ForeColor = Color.White;
            lstSoldOut.FormattingEnabled = true;
            lstSoldOut.ItemHeight = 17;
            lstSoldOut.Location = new Point(20, 50);
            lstSoldOut.Name = "lstSoldOut";
            lstSoldOut.Size = new Size(254, 102);
            lstSoldOut.TabIndex = 1;
            lstSoldOut.SelectedIndexChanged += lstSoldOut_SelectedIndexChanged;
            // 
            // lblSoldOutListTitle
            // 
            lblSoldOutListTitle.AutoSize = true;
            lblSoldOutListTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblSoldOutListTitle.ForeColor = Color.IndianRed;
            lblSoldOutListTitle.Location = new Point(15, 15);
            lblSoldOutListTitle.Name = "lblSoldOutListTitle";
            lblSoldOutListTitle.Size = new Size(165, 20);
            lblSoldOutListTitle.TabIndex = 2;
            lblSoldOutListTitle.Text = "Danh sách món đã hết";
            // 
            // pnlKitchenWarning
            // 
            pnlKitchenWarning.BackColor = Color.FromArgb(30, 30, 30);
            pnlKitchenWarning.Controls.Add(lstKitchenWarning);
            pnlKitchenWarning.Controls.Add(lblKitchenWarningTitle);
            pnlKitchenWarning.Location = new Point(490, 320);
            pnlKitchenWarning.Name = "pnlKitchenWarning";
            pnlKitchenWarning.Size = new Size(294, 190);
            pnlKitchenWarning.TabIndex = 3;
            // 
            // lstKitchenWarning
            // 
            lstKitchenWarning.AccessibleRole = AccessibleRole.Sound;
            lstKitchenWarning.BackColor = Color.FromArgb(45, 45, 48);
            lstKitchenWarning.BorderStyle = BorderStyle.None;
            lstKitchenWarning.Font = new Font("Segoe UI", 9.75F);
            lstKitchenWarning.ForeColor = Color.White;
            lstKitchenWarning.FormattingEnabled = true;
            lstKitchenWarning.ItemHeight = 17;
            lstKitchenWarning.Location = new Point(20, 50);
            lstKitchenWarning.Name = "lstKitchenWarning";
            lstKitchenWarning.Size = new Size(254, 119);
            lstKitchenWarning.TabIndex = 0;
            lstKitchenWarning.DoubleClick += lstKitchenWarning_DoubleClick;
            // 
            // lblKitchenWarningTitle
            // 
            lblKitchenWarningTitle.AutoSize = true;
            lblKitchenWarningTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblKitchenWarningTitle.ForeColor = Color.Orange;
            lblKitchenWarningTitle.Location = new Point(15, 15);
            lblKitchenWarningTitle.Name = "lblKitchenWarningTitle";
            lblKitchenWarningTitle.Size = new Size(194, 20);
            lblKitchenWarningTitle.TabIndex = 1;
            lblKitchenWarningTitle.Text = "Cảnh báo Món chờ quá lâu";
            // 
            // ucOrders_Manager
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(45, 45, 48);
            Controls.Add(pnlKitchenWarning);
            Controls.Add(pnlSoldOut);
            Controls.Add(pnlTableStatus);
            Controls.Add(pnlSummary);
            Name = "ucOrders_Manager";
            Size = new Size(804, 530);
            pnlSummary.ResumeLayout(false);
            pnlSummary.PerformLayout();
            pnlTableStatus.ResumeLayout(false);
            pnlTableStatus.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTableStatus).EndInit();
            pnlSoldOut.ResumeLayout(false);
            pnlSoldOut.PerformLayout();
            pnlKitchenWarning.ResumeLayout(false);
            pnlKitchenWarning.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlSummary;
        private System.Windows.Forms.Label lblEmptyTablesTitle;
        private System.Windows.Forms.Label lblEmptyTablesValue;
        private System.Windows.Forms.Label lblPendingTitle;
        private System.Windows.Forms.Label lblPendingValue;
        private System.Windows.Forms.Label lblSoldOutTitle;
        private System.Windows.Forms.Label lblSoldOutValue;
        private System.Windows.Forms.Panel pnlTableStatus;
        private System.Windows.Forms.Label lblTableStatusTitle;
        private System.Windows.Forms.DataGridView dgvTableStatus;
        private System.Windows.Forms.Panel pnlSoldOut;
        private System.Windows.Forms.Label lblSoldOutListTitle;
        private System.Windows.Forms.ListBox lstSoldOut;
        private System.Windows.Forms.Button btnUpdateSoldOut;
        private System.Windows.Forms.Panel pnlKitchenWarning;
        private System.Windows.Forms.Label lblKitchenWarningTitle;
        private System.Windows.Forms.ListBox lstKitchenWarning;
        private ComboBox cboTableStatus;
        private System.Windows.Forms.Button btnFilterTable;
        private Button btnStatus;
    }
}