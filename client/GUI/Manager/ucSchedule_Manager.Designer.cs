using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace GUI
{
    partial class ucSchedule_Manager
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges11 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges12 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges19 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges20 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges13 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges14 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges15 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges16 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges17 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges18 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges21 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges22 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges23 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges24 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            lblTitle = new Label();
            lblSub = new Label();
            pnlCardStaff = new Guna2Panel();
            barStaff = new Guna2Panel();
            lblCardStaffCap = new Label();
            lblCardStaffVal = new Label();
            pnlCardShortage = new Guna2Panel();
            barShortage = new Guna2Panel();
            lblCardShortageCap = new Label();
            lblCardShortageVal = new Label();
            pnlCardLeave = new Guna2Panel();
            barLeave = new Guna2Panel();
            lblCardLeaveCap = new Label();
            lblCardLeaveVal = new Label();
            pnlNav = new Guna2Panel();
            btnPrev = new Guna2Button();
            lblWeek = new Label();
            btnPublish = new Guna2Button();
            btnNext = new Guna2Button();
            pnlGrid = new Guna2Panel();
            grid = new TableLayoutPanel();
            pnlWarn = new Guna2Panel();
            lblWarn = new Label();
            pnlCardStaff.SuspendLayout();
            pnlCardShortage.SuspendLayout();
            pnlCardLeave.SuspendLayout();
            pnlNav.SuspendLayout();
            pnlGrid.SuspendLayout();
            pnlWarn.SuspendLayout();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.BackColor = Color.Transparent;
            lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(240, 240, 245);
            lblTitle.Location = new Point(20, 20);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(174, 25);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Xếp lịch ca làm";
            // 
            // lblSub
            // 
            lblSub.AutoSize = true;
            lblSub.BackColor = Color.Transparent;
            lblSub.Font = new Font("Segoe UI", 9F);
            lblSub.ForeColor = Color.FromArgb(160, 160, 166);
            lblSub.Location = new Point(22, 46);
            lblSub.Name = "lblSub";
            lblSub.Size = new Size(276, 15);
            lblSub.TabIndex = 1;
            lblSub.Text = "Phân công ca theo tuần · Cảnh báo khi thiếu người";
            // 
            // pnlCardStaff
            // 
            pnlCardStaff.BackColor = Color.Transparent;
            pnlCardStaff.BorderRadius = 14;
            pnlCardStaff.Controls.Add(barStaff);
            pnlCardStaff.Controls.Add(lblCardStaffCap);
            pnlCardStaff.Controls.Add(lblCardStaffVal);
            pnlCardStaff.CustomizableEdges = customizableEdges3;
            pnlCardStaff.FillColor = Color.FromArgb(31, 31, 34);
            pnlCardStaff.Location = new Point(16, 70);
            pnlCardStaff.Name = "pnlCardStaff";
            pnlCardStaff.ShadowDecoration.CustomizableEdges = customizableEdges4;
            pnlCardStaff.Size = new Size(220, 96);
            pnlCardStaff.TabIndex = 0;
            // 
            // barStaff
            // 
            barStaff.BorderRadius = 4;
            barStaff.CustomizableEdges = customizableEdges1;
            barStaff.FillColor = Color.FromArgb(31, 138, 154);
            barStaff.Location = new Point(14, 16);
            barStaff.Name = "barStaff";
            barStaff.ShadowDecoration.CustomizableEdges = customizableEdges2;
            barStaff.Size = new Size(4, 64);
            barStaff.TabIndex = 0;
            // 
            // lblCardStaffCap
            // 
            lblCardStaffCap.AutoSize = true;
            lblCardStaffCap.BackColor = Color.Transparent;
            lblCardStaffCap.Font = new Font("Segoe UI", 9.5F);
            lblCardStaffCap.ForeColor = Color.FromArgb(160, 160, 166);
            lblCardStaffCap.Location = new Point(28, 16);
            lblCardStaffCap.Name = "lblCardStaffCap";
            lblCardStaffCap.Size = new Size(119, 17);
            lblCardStaffCap.TabIndex = 1;
            lblCardStaffCap.Text = "Nhân viên trong ca";
            // 
            // lblCardStaffVal
            // 
            lblCardStaffVal.AutoSize = true;
            lblCardStaffVal.BackColor = Color.Transparent;
            lblCardStaffVal.Font = new Font("Segoe UI", 19F, FontStyle.Bold);
            lblCardStaffVal.ForeColor = Color.FromArgb(240, 240, 245);
            lblCardStaffVal.Location = new Point(26, 38);
            lblCardStaffVal.Name = "lblCardStaffVal";
            lblCardStaffVal.Size = new Size(45, 36);
            lblCardStaffVal.TabIndex = 2;
            lblCardStaffVal.Text = "12";
            // 
            // pnlCardShortage
            // 
            pnlCardShortage.BackColor = Color.Transparent;
            pnlCardShortage.BorderRadius = 14;
            pnlCardShortage.Controls.Add(barShortage);
            pnlCardShortage.Controls.Add(lblCardShortageCap);
            pnlCardShortage.Controls.Add(lblCardShortageVal);
            pnlCardShortage.CustomizableEdges = customizableEdges7;
            pnlCardShortage.FillColor = Color.FromArgb(31, 31, 34);
            pnlCardShortage.Location = new Point(248, 70);
            pnlCardShortage.Name = "pnlCardShortage";
            pnlCardShortage.ShadowDecoration.CustomizableEdges = customizableEdges8;
            pnlCardShortage.Size = new Size(220, 96);
            pnlCardShortage.TabIndex = 1;
            // 
            // barShortage
            // 
            barShortage.BorderRadius = 4;
            barShortage.CustomizableEdges = customizableEdges5;
            barShortage.FillColor = Color.FromArgb(220, 80, 80);
            barShortage.Location = new Point(14, 16);
            barShortage.Name = "barShortage";
            barShortage.ShadowDecoration.CustomizableEdges = customizableEdges6;
            barShortage.Size = new Size(4, 64);
            barShortage.TabIndex = 0;
            // 
            // lblCardShortageCap
            // 
            lblCardShortageCap.AutoSize = true;
            lblCardShortageCap.BackColor = Color.Transparent;
            lblCardShortageCap.Font = new Font("Segoe UI", 9.5F);
            lblCardShortageCap.ForeColor = Color.FromArgb(160, 160, 166);
            lblCardShortageCap.Location = new Point(28, 16);
            lblCardShortageCap.Name = "lblCardShortageCap";
            lblCardShortageCap.Size = new Size(93, 17);
            lblCardShortageCap.TabIndex = 1;
            lblCardShortageCap.Text = "Ca thiếu người";
            // 
            // lblCardShortageVal
            // 
            lblCardShortageVal.AutoSize = true;
            lblCardShortageVal.BackColor = Color.Transparent;
            lblCardShortageVal.Font = new Font("Segoe UI", 19F, FontStyle.Bold);
            lblCardShortageVal.ForeColor = Color.FromArgb(240, 240, 245);
            lblCardShortageVal.Location = new Point(26, 38);
            lblCardShortageVal.Name = "lblCardShortageVal";
            lblCardShortageVal.Size = new Size(63, 36);
            lblCardShortageVal.TabIndex = 2;
            lblCardShortageVal.Text = "2 ca";
            // 
            // pnlCardLeave
            // 
            pnlCardLeave.BackColor = Color.Transparent;
            pnlCardLeave.BorderRadius = 14;
            pnlCardLeave.Controls.Add(barLeave);
            pnlCardLeave.Controls.Add(lblCardLeaveCap);
            pnlCardLeave.Controls.Add(lblCardLeaveVal);
            pnlCardLeave.CustomizableEdges = customizableEdges11;
            pnlCardLeave.FillColor = Color.FromArgb(31, 31, 34);
            pnlCardLeave.Location = new Point(480, 70);
            pnlCardLeave.Name = "pnlCardLeave";
            pnlCardLeave.ShadowDecoration.CustomizableEdges = customizableEdges12;
            pnlCardLeave.Size = new Size(220, 96);
            pnlCardLeave.TabIndex = 2;
            // 
            // barLeave
            // 
            barLeave.BorderRadius = 4;
            barLeave.CustomizableEdges = customizableEdges9;
            barLeave.FillColor = Color.FromArgb(245, 158, 11);
            barLeave.Location = new Point(14, 16);
            barLeave.Name = "barLeave";
            barLeave.ShadowDecoration.CustomizableEdges = customizableEdges10;
            barLeave.Size = new Size(4, 64);
            barLeave.TabIndex = 0;
            // 
            // lblCardLeaveCap
            // 
            lblCardLeaveCap.AutoSize = true;
            lblCardLeaveCap.BackColor = Color.Transparent;
            lblCardLeaveCap.Font = new Font("Segoe UI", 9.5F);
            lblCardLeaveCap.ForeColor = Color.FromArgb(160, 160, 166);
            lblCardLeaveCap.Location = new Point(28, 16);
            lblCardLeaveCap.Name = "lblCardLeaveCap";
            lblCardLeaveCap.Size = new Size(102, 17);
            lblCardLeaveCap.TabIndex = 1;
            lblCardLeaveCap.Text = "Đang nghỉ phép";
            // 
            // lblCardLeaveVal
            // 
            lblCardLeaveVal.AutoSize = true;
            lblCardLeaveVal.BackColor = Color.Transparent;
            lblCardLeaveVal.Font = new Font("Segoe UI", 19F, FontStyle.Bold);
            lblCardLeaveVal.ForeColor = Color.FromArgb(240, 240, 245);
            lblCardLeaveVal.Location = new Point(26, 38);
            lblCardLeaveVal.Name = "lblCardLeaveVal";
            lblCardLeaveVal.Size = new Size(75, 36);
            lblCardLeaveVal.TabIndex = 2;
            lblCardLeaveVal.Text = "1 NV";
            // 
            // pnlNav
            // 
            pnlNav.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlNav.BackColor = Color.Transparent;
            pnlNav.BorderRadius = 14;
            pnlNav.Controls.Add(btnPrev);
            pnlNav.Controls.Add(lblWeek);
            pnlNav.Controls.Add(btnPublish);
            pnlNav.Controls.Add(btnNext);
            pnlNav.CustomizableEdges = customizableEdges19;
            pnlNav.FillColor = Color.FromArgb(31, 31, 34);
            pnlNav.Location = new Point(16, 182);
            pnlNav.Name = "pnlNav";
            pnlNav.ShadowDecoration.CustomizableEdges = customizableEdges20;
            pnlNav.Size = new Size(968, 52);
            pnlNav.TabIndex = 3;
            // 
            // btnPrev
            // 
            btnPrev.BorderColor = Color.FromArgb(63, 63, 70);
            btnPrev.BorderRadius = 10;
            btnPrev.BorderThickness = 1;
            btnPrev.Cursor = Cursors.Hand;
            btnPrev.CustomizableEdges = customizableEdges13;
            btnPrev.FillColor = Color.Transparent;
            btnPrev.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnPrev.ForeColor = Color.FromArgb(220, 220, 225);
            btnPrev.HoverState.BorderColor = Color.FromArgb(103, 103, 110);
            btnPrev.HoverState.FillColor = Color.FromArgb(45, 45, 50);
            btnPrev.Location = new Point(12, 8);
            btnPrev.Name = "btnPrev";
            btnPrev.ShadowDecoration.CustomizableEdges = customizableEdges14;
            btnPrev.Size = new Size(128, 36);
            btnPrev.TabIndex = 0;
            btnPrev.Text = "◀  Tuần trước";
            // 
            // lblWeek
            // 
            lblWeek.AutoSize = true;
            lblWeek.BackColor = Color.Transparent;
            lblWeek.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblWeek.ForeColor = Color.FromArgb(240, 240, 245);
            lblWeek.Location = new Point(160, 15);
            lblWeek.Name = "lblWeek";
            lblWeek.Size = new Size(0, 19);
            lblWeek.TabIndex = 1;
            // 
            // btnPublish
            // 
            btnPublish.BorderRadius = 10;
            btnPublish.Cursor = Cursors.Hand;
            btnPublish.CustomizableEdges = customizableEdges15;
            btnPublish.FillColor = Color.FromArgb(31, 138, 154);
            btnPublish.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnPublish.ForeColor = Color.White;
            btnPublish.HoverState.FillColor = Color.FromArgb(47, 154, 170);
            btnPublish.Location = new Point(480, 8);
            btnPublish.Name = "btnPublish";
            btnPublish.ShadowDecoration.CustomizableEdges = customizableEdges16;
            btnPublish.Size = new Size(120, 36);
            btnPublish.TabIndex = 2;
            btnPublish.Text = "Đăng lịch";
            // 
            // btnNext
            // 
            btnNext.BorderColor = Color.FromArgb(63, 63, 70);
            btnNext.BorderRadius = 10;
            btnNext.BorderThickness = 1;
            btnNext.Cursor = Cursors.Hand;
            btnNext.CustomizableEdges = customizableEdges17;
            btnNext.FillColor = Color.Transparent;
            btnNext.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnNext.ForeColor = Color.FromArgb(220, 220, 225);
            btnNext.HoverState.BorderColor = Color.FromArgb(103, 103, 110);
            btnNext.HoverState.FillColor = Color.FromArgb(45, 45, 50);
            btnNext.Location = new Point(620, 8);
            btnNext.Name = "btnNext";
            btnNext.ShadowDecoration.CustomizableEdges = customizableEdges18;
            btnNext.Size = new Size(128, 36);
            btnNext.TabIndex = 3;
            btnNext.Text = "Tuần sau  ▶";
            // 
            // pnlGrid
            // 
            pnlGrid.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnlGrid.BackColor = Color.Transparent;
            pnlGrid.BorderRadius = 14;
            pnlGrid.Controls.Add(grid);
            pnlGrid.CustomizableEdges = customizableEdges21;
            pnlGrid.FillColor = Color.FromArgb(24, 24, 27);
            pnlGrid.Location = new Point(16, 248);
            pnlGrid.Name = "pnlGrid";
            pnlGrid.ShadowDecoration.CustomizableEdges = customizableEdges22;
            pnlGrid.Size = new Size(968, 345);
            pnlGrid.TabIndex = 4;
            // 
            // grid
            // 
            grid.BackColor = Color.Transparent;
            grid.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            grid.ColumnCount = 8;
            grid.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            grid.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            grid.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            grid.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            grid.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            grid.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            grid.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            grid.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            grid.Dock = DockStyle.Fill;
            grid.Location = new Point(0, 0);
            grid.Name = "grid";
            grid.RowCount = 4;
            grid.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            grid.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            grid.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            grid.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            grid.Size = new Size(968, 345);
            grid.TabIndex = 0;
            // 
            // pnlWarn
            // 
            pnlWarn.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnlWarn.BorderRadius = 10;
            pnlWarn.Controls.Add(lblWarn);
            pnlWarn.CustomizableEdges = customizableEdges23;
            pnlWarn.FillColor = Color.FromArgb(60, 38, 41);
            pnlWarn.Location = new Point(16, 605);
            pnlWarn.Name = "pnlWarn";
            pnlWarn.ShadowDecoration.CustomizableEdges = customizableEdges24;
            pnlWarn.Size = new Size(968, 40);
            pnlWarn.TabIndex = 5;
            // 
            // lblWarn
            // 
            lblWarn.AutoSize = true;
            lblWarn.BackColor = Color.Transparent;
            lblWarn.Font = new Font("Segoe UI", 9.5F);
            lblWarn.ForeColor = Color.FromArgb(220, 80, 80);
            lblWarn.Location = new Point(12, 10);
            lblWarn.Name = "lblWarn";
            lblWarn.Size = new Size(577, 17);
            lblWarn.TabIndex = 0;
            lblWarn.Text = "Cảnh báo: Ca chiều Thứ 4 và Ca sáng Chủ nhật chưa đủ người — cần ít nhất 2 barista mỗi ca.";
            // 
            // ucSchedule_Manager
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(39, 39, 42);
            Controls.Add(lblTitle);
            Controls.Add(lblSub);
            Controls.Add(pnlCardStaff);
            Controls.Add(pnlCardShortage);
            Controls.Add(pnlCardLeave);
            Controls.Add(pnlNav);
            Controls.Add(pnlGrid);
            Controls.Add(pnlWarn);
            Name = "ucSchedule_Manager";
            Size = new Size(1000, 665);
            pnlCardStaff.ResumeLayout(false);
            pnlCardStaff.PerformLayout();
            pnlCardShortage.ResumeLayout(false);
            pnlCardShortage.PerformLayout();
            pnlCardLeave.ResumeLayout(false);
            pnlCardLeave.PerformLayout();
            pnlNav.ResumeLayout(false);
            pnlNav.PerformLayout();
            pnlGrid.ResumeLayout(false);
            pnlWarn.ResumeLayout(false);
            pnlWarn.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private Label lblSub;
        private Guna2Panel pnlCardStaff;
        private Guna2Panel barStaff;
        private Label lblCardStaffCap;
        private Label lblCardStaffVal;
        private Guna2Panel pnlCardShortage;
        private Guna2Panel barShortage;
        private Label lblCardShortageCap;
        private Label lblCardShortageVal;
        private Guna2Panel pnlCardLeave;
        private Guna2Panel barLeave;
        private Label lblCardLeaveCap;
        private Label lblCardLeaveVal;
        private Guna2Panel pnlNav;
        private Guna2Button btnPrev;
        private Label lblWeek;
        private Guna2Button btnPublish;
        private Guna2Button btnNext;
        private Guna2Panel pnlGrid;
        private TableLayoutPanel grid;
        private Guna2Panel pnlWarn;
        private Label lblWarn;
    }
}
