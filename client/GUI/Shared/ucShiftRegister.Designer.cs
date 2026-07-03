using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace GUI
{
    partial class ucShiftRegister
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
            pnlSummary = new Guna2Panel();
            lblMineTitle = new Label();
            lblMineValue = new Label();
            pnlDivider1 = new Panel();
            lblOpenTitle = new Label();
            lblOpenValue = new Label();
            pnlDivider2 = new Panel();
            lblSwapPendingTitle = new Label();
            lblSwapPendingValue = new Label();
            lblWeek = new Label();

            pnlOpen = new Guna2Panel();
            lblOpenPanelTitle = new Label();
            dgvOpen = new Guna2DataGridView();
            colOpenDay = new DataGridViewTextBoxColumn();
            colOpenShift = new DataGridViewTextBoxColumn();
            colOpenTime = new DataGridViewTextBoxColumn();
            btnPickShift = new Guna2Button();

            pnlMine = new Guna2Panel();
            lblMinePanelTitle = new Label();
            dgvMine = new Guna2DataGridView();
            colMineDay = new DataGridViewTextBoxColumn();
            colMineShift = new DataGridViewTextBoxColumn();
            colMineTime = new DataGridViewTextBoxColumn();
            colMineStatus = new DataGridViewTextBoxColumn();
            btnSwap = new Guna2Button();
            lblSwapPanelTitle = new Label();
            dgvSwap = new Guna2DataGridView();
            colSwapDay = new DataGridViewTextBoxColumn();
            colSwapShift = new DataGridViewTextBoxColumn();
            colSwapWith = new DataGridViewTextBoxColumn();
            colSwapStatus = new DataGridViewTextBoxColumn();

            pnlSummary.SuspendLayout();
            pnlOpen.SuspendLayout();
            pnlMine.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvOpen).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvMine).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvSwap).BeginInit();
            SuspendLayout();

            // ====== pnlSummary ======
            pnlSummary.BackColor = Color.FromArgb(31, 31, 34);
            pnlSummary.BorderRadius = 14;
            pnlSummary.Controls.Add(lblMineTitle);
            pnlSummary.Controls.Add(lblMineValue);
            pnlSummary.Controls.Add(pnlDivider1);
            pnlSummary.Controls.Add(lblOpenTitle);
            pnlSummary.Controls.Add(lblOpenValue);
            pnlSummary.Controls.Add(pnlDivider2);
            pnlSummary.Controls.Add(lblSwapPendingTitle);
            pnlSummary.Controls.Add(lblSwapPendingValue);
            pnlSummary.Controls.Add(lblWeek);
            pnlSummary.Location = new Point(20, 20);
            pnlSummary.Size = new Size(960, 100);
            pnlSummary.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

            lblMineTitle.AutoSize = true;
            lblMineTitle.Font = new Font("Segoe UI", 9F);
            lblMineTitle.ForeColor = Color.FromArgb(160, 160, 166);
            lblMineTitle.Location = new Point(20, 18);
            lblMineTitle.Text = "Ca của tôi tuần này";

            lblMineValue.AutoSize = true;
            lblMineValue.Font = new Font("Segoe UI", 17F, FontStyle.Bold);
            lblMineValue.ForeColor = Color.FromArgb(34, 197, 94);
            lblMineValue.Location = new Point(20, 42);
            lblMineValue.Text = "0 ca";

            pnlDivider1.BackColor = Color.FromArgb(63, 63, 70);
            pnlDivider1.Location = new Point(230, 22);
            pnlDivider1.Size = new Size(1, 58);

            lblOpenTitle.AutoSize = true;
            lblOpenTitle.Font = new Font("Segoe UI", 9F);
            lblOpenTitle.ForeColor = Color.FromArgb(160, 160, 166);
            lblOpenTitle.Location = new Point(260, 18);
            lblOpenTitle.Text = "Ca trống có thể nhận";

            lblOpenValue.AutoSize = true;
            lblOpenValue.Font = new Font("Segoe UI", 17F, FontStyle.Bold);
            lblOpenValue.ForeColor = Color.FromArgb(245, 158, 11);
            lblOpenValue.Location = new Point(260, 42);
            lblOpenValue.Text = "0 ca";

            pnlDivider2.BackColor = Color.FromArgb(63, 63, 70);
            pnlDivider2.Location = new Point(500, 22);
            pnlDivider2.Size = new Size(1, 58);

            lblSwapPendingTitle.AutoSize = true;
            lblSwapPendingTitle.Font = new Font("Segoe UI", 9F);
            lblSwapPendingTitle.ForeColor = Color.FromArgb(160, 160, 166);
            lblSwapPendingTitle.Location = new Point(530, 18);
            lblSwapPendingTitle.Text = "Đổi ca chờ duyệt";

            lblSwapPendingValue.AutoSize = true;
            lblSwapPendingValue.Font = new Font("Segoe UI", 17F, FontStyle.Bold);
            lblSwapPendingValue.ForeColor = Color.FromArgb(59, 130, 246);
            lblSwapPendingValue.Location = new Point(530, 42);
            lblSwapPendingValue.Text = "0 yêu cầu";

            lblWeek.AutoSize = true;
            lblWeek.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblWeek.ForeColor = Color.FromArgb(220, 220, 225);
            lblWeek.Location = new Point(760, 42);
            lblWeek.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblWeek.Text = "Tuần —";

            // ====== pnlOpen (left) ======
            pnlOpen.BackColor = Color.FromArgb(31, 31, 34);
            pnlOpen.BorderRadius = 14;
            pnlOpen.Controls.Add(lblOpenPanelTitle);
            pnlOpen.Controls.Add(dgvOpen);
            pnlOpen.Controls.Add(btnPickShift);
            pnlOpen.Location = new Point(20, 135);
            pnlOpen.Size = new Size(340, 510);
            pnlOpen.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;

            lblOpenPanelTitle.AutoSize = true;
            lblOpenPanelTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblOpenPanelTitle.ForeColor = Color.FromArgb(245, 158, 11);
            lblOpenPanelTitle.Location = new Point(20, 18);
            lblOpenPanelTitle.Text = "🟢  Ca trống trong tuần";

            dgvOpen.BackgroundColor = Color.FromArgb(24, 24, 27);
            dgvOpen.GridColor = Color.FromArgb(45, 45, 48);
            ConfigureGrid(dgvOpen);
            dgvOpen.Columns.AddRange(new DataGridViewColumn[] { colOpenDay, colOpenShift, colOpenTime });
            colOpenDay.HeaderText = "Ngày"; colOpenDay.Name = "Ngày"; colOpenDay.DataPropertyName = "Ngày";
            colOpenShift.HeaderText = "Ca"; colOpenShift.Name = "Ca"; colOpenShift.DataPropertyName = "Ca";
            colOpenTime.HeaderText = "Giờ"; colOpenTime.Name = "Giờ"; colOpenTime.DataPropertyName = "Giờ";
            dgvOpen.Location = new Point(18, 56);
            dgvOpen.Size = new Size(304, 384);
            dgvOpen.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            btnPickShift.BorderRadius = 10;
            btnPickShift.Cursor = Cursors.Hand;
            btnPickShift.FillColor = Color.FromArgb(34, 197, 94);
            btnPickShift.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnPickShift.ForeColor = Color.White;
            btnPickShift.HoverState.FillColor = Color.FromArgb(45, 207, 104);
            btnPickShift.Location = new Point(18, 452);
            btnPickShift.Size = new Size(304, 44);
            btnPickShift.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnPickShift.Text = "Nhận ca này";

            // ====== pnlMine (right) ======
            pnlMine.BackColor = Color.FromArgb(31, 31, 34);
            pnlMine.BorderRadius = 14;
            pnlMine.Controls.Add(lblMinePanelTitle);
            pnlMine.Controls.Add(dgvMine);
            pnlMine.Controls.Add(btnSwap);
            pnlMine.Controls.Add(lblSwapPanelTitle);
            pnlMine.Controls.Add(dgvSwap);
            pnlMine.Location = new Point(380, 135);
            pnlMine.Size = new Size(600, 510);
            pnlMine.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            lblMinePanelTitle.AutoSize = true;
            lblMinePanelTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblMinePanelTitle.ForeColor = Color.White;
            lblMinePanelTitle.Location = new Point(20, 18);
            lblMinePanelTitle.Text = "Ca của tôi tuần này";

            dgvMine.BackgroundColor = Color.FromArgb(24, 24, 27);
            dgvMine.GridColor = Color.FromArgb(45, 45, 48);
            ConfigureGrid(dgvMine);
            dgvMine.Columns.AddRange(new DataGridViewColumn[] { colMineDay, colMineShift, colMineTime, colMineStatus });
            colMineDay.HeaderText = "Ngày"; colMineDay.Name = "Ngày"; colMineDay.DataPropertyName = "Ngày";
            colMineShift.HeaderText = "Ca"; colMineShift.Name = "Ca"; colMineShift.DataPropertyName = "Ca";
            colMineTime.HeaderText = "Giờ"; colMineTime.Name = "Giờ"; colMineTime.DataPropertyName = "Giờ";
            colMineStatus.HeaderText = "Trạng thái"; colMineStatus.Name = "Trạng thái"; colMineStatus.DataPropertyName = "Trạng thái";
            dgvMine.Location = new Point(18, 56);
            dgvMine.Size = new Size(564, 196);
            dgvMine.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

            btnSwap.BorderRadius = 10;
            btnSwap.Cursor = Cursors.Hand;
            btnSwap.FillColor = Color.FromArgb(31, 138, 154);
            btnSwap.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnSwap.ForeColor = Color.White;
            btnSwap.HoverState.FillColor = Color.FromArgb(45, 158, 174);
            btnSwap.Location = new Point(18, 262);
            btnSwap.Size = new Size(210, 40);
            btnSwap.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            btnSwap.Text = "🔄  Xin đổi ca này";

            lblSwapPanelTitle.AutoSize = true;
            lblSwapPanelTitle.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            lblSwapPanelTitle.ForeColor = Color.FromArgb(59, 130, 246);
            lblSwapPanelTitle.Location = new Point(20, 318);
            lblSwapPanelTitle.Text = "🔄  Yêu cầu đổi ca đã gửi";

            dgvSwap.BackgroundColor = Color.FromArgb(24, 24, 27);
            dgvSwap.GridColor = Color.FromArgb(45, 45, 48);
            ConfigureGrid(dgvSwap);
            dgvSwap.Columns.AddRange(new DataGridViewColumn[] { colSwapDay, colSwapShift, colSwapWith, colSwapStatus });
            colSwapDay.HeaderText = "Ngày"; colSwapDay.Name = "Ngày"; colSwapDay.DataPropertyName = "Ngày";
            colSwapShift.HeaderText = "Ca"; colSwapShift.Name = "Ca"; colSwapShift.DataPropertyName = "Ca";
            colSwapWith.HeaderText = "Đổi cho"; colSwapWith.Name = "Đổi cho"; colSwapWith.DataPropertyName = "Đổi cho";
            colSwapStatus.HeaderText = "Trạng thái"; colSwapStatus.Name = "Trạng thái"; colSwapStatus.DataPropertyName = "Trạng thái";
            dgvSwap.Location = new Point(18, 352);
            dgvSwap.Size = new Size(564, 140);
            dgvSwap.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            // ====== ucShiftRegister ======
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(39, 39, 42);
            Controls.Add(pnlSummary);
            Controls.Add(pnlOpen);
            Controls.Add(pnlMine);
            Name = "ucShiftRegister";
            Size = new Size(1000, 665);

            pnlSummary.ResumeLayout(false);
            pnlSummary.PerformLayout();
            pnlOpen.ResumeLayout(false);
            pnlOpen.PerformLayout();
            pnlMine.ResumeLayout(false);
            pnlMine.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvOpen).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvMine).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvSwap).EndInit();
            this.Load += UcShiftRegister_Load;
            btnPickShift.Click += BtnPickShift_Click;
            btnSwap.Click += BtnSwap_Click;
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

        private Guna2Panel pnlSummary;
        private Label lblMineTitle;
        private Label lblMineValue;
        private Panel pnlDivider1;
        private Label lblOpenTitle;
        private Label lblOpenValue;
        private Panel pnlDivider2;
        private Label lblSwapPendingTitle;
        private Label lblSwapPendingValue;
        private Label lblWeek;

        private Guna2Panel pnlOpen;
        private Label lblOpenPanelTitle;
        private Guna2DataGridView dgvOpen;
        private DataGridViewTextBoxColumn colOpenDay;
        private DataGridViewTextBoxColumn colOpenShift;
        private DataGridViewTextBoxColumn colOpenTime;
        private Guna2Button btnPickShift;

        private Guna2Panel pnlMine;
        private Label lblMinePanelTitle;
        private Guna2DataGridView dgvMine;
        private DataGridViewTextBoxColumn colMineDay;
        private DataGridViewTextBoxColumn colMineShift;
        private DataGridViewTextBoxColumn colMineTime;
        private DataGridViewTextBoxColumn colMineStatus;
        private Guna2Button btnSwap;
        private Label lblSwapPanelTitle;
        private Guna2DataGridView dgvSwap;
        private DataGridViewTextBoxColumn colSwapDay;
        private DataGridViewTextBoxColumn colSwapShift;
        private DataGridViewTextBoxColumn colSwapWith;
        private DataGridViewTextBoxColumn colSwapStatus;
    }
}
