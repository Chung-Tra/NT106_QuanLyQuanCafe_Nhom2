using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using Guna.Charts.WinForms;

namespace GUI
{
    partial class ChartDetail
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            ChartFont chartFont1 = new ChartFont();
            ChartFont chartFont2 = new ChartFont();
            ChartFont chartFont3 = new ChartFont();
            ChartFont chartFont4 = new ChartFont();
            Grid grid1 = new Grid();
            Tick tick1 = new Tick();
            ChartFont chartFont5 = new ChartFont();
            Grid grid2 = new Grid();
            Tick tick2 = new Tick();
            ChartFont chartFont6 = new ChartFont();
            Grid grid3 = new Grid();
            PointLabel pointLabel1 = new PointLabel();
            ChartFont chartFont7 = new ChartFont();
            Tick tick3 = new Tick();
            ChartFont chartFont8 = new ChartFont();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            card = new Guna2Panel();
            accentBar = new Guna2Panel();
            lblTitle = new Label();
            lblFromCap = new Label();
            cboFrom = new Guna2ComboBox();
            lblToCap = new Label();
            cboTo = new Guna2ComboBox();
            chartArea = new Panel();
            chart = new GunaChart();
            btnClose = new Guna2Button();
            card.SuspendLayout();
            chartArea.SuspendLayout();
            SuspendLayout();
            // 
            // card
            // 
            card.BackColor = Color.Transparent;
            card.BorderRadius = 16;
            card.Controls.Add(accentBar);
            card.Controls.Add(lblTitle);
            card.Controls.Add(lblFromCap);
            card.Controls.Add(cboFrom);
            card.Controls.Add(lblToCap);
            card.Controls.Add(cboTo);
            card.Controls.Add(chartArea);
            card.Controls.Add(btnClose);
            card.CustomizableEdges = customizableEdges9;
            card.Dock = DockStyle.Fill;
            card.FillColor = Color.FromArgb(31, 31, 34);
            card.Location = new Point(0, 0);
            card.Name = "card";
            card.ShadowDecoration.CustomizableEdges = customizableEdges10;
            card.Size = new Size(880, 560);
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
            // lblFromCap
            // 
            lblFromCap.AutoSize = true;
            lblFromCap.BackColor = Color.Transparent;
            lblFromCap.Font = new Font("Segoe UI", 9.5F);
            lblFromCap.ForeColor = Color.FromArgb(160, 160, 166);
            lblFromCap.Location = new Point(36, 64);
            lblFromCap.Name = "lblFromCap";
            lblFromCap.Size = new Size(63, 17);
            lblFromCap.TabIndex = 2;
            lblFromCap.Text = "Từ tháng:";
            // 
            // cboFrom
            // 
            cboFrom.BackColor = Color.Transparent;
            cboFrom.BorderColor = Color.FromArgb(63, 63, 70);
            cboFrom.BorderRadius = 6;
            cboFrom.CustomizableEdges = customizableEdges3;
            cboFrom.DrawMode = DrawMode.OwnerDrawFixed;
            cboFrom.DropDownStyle = ComboBoxStyle.DropDownList;
            cboFrom.FillColor = Color.FromArgb(30, 30, 33);
            cboFrom.FocusedColor = Color.FromArgb(31, 138, 154);
            cboFrom.FocusedState.BorderColor = Color.FromArgb(31, 138, 154);
            cboFrom.Font = new Font("Segoe UI", 9F);
            cboFrom.ForeColor = Color.FromArgb(240, 240, 245);
            cboFrom.ItemHeight = 26;
            cboFrom.Location = new Point(110, 60);
            cboFrom.Name = "cboFrom";
            cboFrom.ShadowDecoration.CustomizableEdges = customizableEdges4;
            cboFrom.Size = new Size(150, 32);
            cboFrom.TabIndex = 3;
            // 
            // lblToCap
            // 
            lblToCap.AutoSize = true;
            lblToCap.BackColor = Color.Transparent;
            lblToCap.Font = new Font("Segoe UI", 9.5F);
            lblToCap.ForeColor = Color.FromArgb(160, 160, 166);
            lblToCap.Location = new Point(276, 64);
            lblToCap.Name = "lblToCap";
            lblToCap.Size = new Size(33, 17);
            lblToCap.TabIndex = 4;
            lblToCap.Text = "đến:";
            // 
            // cboTo
            // 
            cboTo.BackColor = Color.Transparent;
            cboTo.BorderColor = Color.FromArgb(63, 63, 70);
            cboTo.BorderRadius = 6;
            cboTo.CustomizableEdges = customizableEdges5;
            cboTo.DrawMode = DrawMode.OwnerDrawFixed;
            cboTo.DropDownStyle = ComboBoxStyle.DropDownList;
            cboTo.FillColor = Color.FromArgb(30, 30, 33);
            cboTo.FocusedColor = Color.FromArgb(31, 138, 154);
            cboTo.FocusedState.BorderColor = Color.FromArgb(31, 138, 154);
            cboTo.Font = new Font("Segoe UI", 9F);
            cboTo.ForeColor = Color.FromArgb(240, 240, 245);
            cboTo.ItemHeight = 26;
            cboTo.Location = new Point(312, 60);
            cboTo.Name = "cboTo";
            cboTo.ShadowDecoration.CustomizableEdges = customizableEdges6;
            cboTo.Size = new Size(150, 32);
            cboTo.TabIndex = 5;
            // 
            // chartArea
            // 
            chartArea.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            chartArea.BackColor = Color.FromArgb(24, 24, 27);
            chartArea.Controls.Add(chart);
            chartArea.Location = new Point(22, 104);
            chartArea.Name = "chartArea";
            // Kích thước phải nằm GỌN trong ClientSize 880x560 của form — trước đây bị lưu
            // 1516x856 (Designer mở ở form to) làm chart tràn khỏi mép dưới, cột thấp "biến mất".
            chartArea.Size = new Size(836, 396);
            chartArea.TabIndex = 6;
            // 
            // chart
            // 
            chart.BackColor = Color.FromArgb(24, 24, 27);
            chartFont1.FontName = "Arial";
            chart.Legend.LabelFont = chartFont1;
            chart.Legend.LabelForeColor = Color.FromArgb(220, 220, 225);
            // Dock=Fill như chartLoss (ucLoss_Manager) — KHÔNG tự SetBounds/FitChart:
            // canvas GunaChart tự khớp control khi dock, tự bố trí lại lúc form resize.
            chart.Dock = DockStyle.Fill;
            chart.Location = new Point(0, 0);
            chart.Name = "chart";
            chart.Size = new Size(836, 396);
            chart.TabIndex = 0;
            chartFont2.FontName = "Arial";
            chartFont2.Size = 12;
            chartFont2.Style = ChartFontStyle.Bold;
            chart.Title.Font = chartFont2;
            chartFont3.FontName = "Arial";
            chart.Tooltips.BodyFont = chartFont3;
            chartFont4.FontName = "Arial";
            chartFont4.Size = 9;
            chartFont4.Style = ChartFontStyle.Bold;
            chart.Tooltips.TitleFont = chartFont4;
            grid1.Display = false;
            chart.XAxes.GridLines = grid1;
            chartFont5.FontName = "Arial";
            tick1.Font = chartFont5;
            tick1.ForeColor = Color.FromArgb(160, 160, 166);
            chart.XAxes.Ticks = tick1;
            grid2.Color = Color.FromArgb(55, 55, 60);
            chart.YAxes.GridLines = grid2;
            chartFont6.FontName = "Arial";
            tick2.Font = chartFont6;
            tick2.ForeColor = Color.FromArgb(160, 160, 166);
            chart.YAxes.Ticks = tick2;
            chart.ZAxes.GridLines = grid3;
            chartFont7.FontName = "Arial";
            pointLabel1.Font = chartFont7;
            chart.ZAxes.PointLabels = pointLabel1;
            chartFont8.FontName = "Arial";
            tick3.Font = chartFont8;
            chart.ZAxes.Ticks = tick3;
            // 
            // btnClose
            // 
            btnClose.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnClose.BorderRadius = 10;
            btnClose.Cursor = Cursors.Hand;
            btnClose.CustomizableEdges = customizableEdges7;
            btnClose.FillColor = Color.FromArgb(31, 138, 154);
            btnClose.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnClose.ForeColor = Color.White;
            btnClose.Location = new Point(748, 502);
            btnClose.Name = "btnClose";
            btnClose.ShadowDecoration.CustomizableEdges = customizableEdges8;
            btnClose.Size = new Size(110, 36);
            btnClose.TabIndex = 7;
            btnClose.Text = "Đóng";
            btnClose.Click += btnClose_Click;
            // 
            // ChartDetail
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(39, 39, 42);
            ClientSize = new Size(880, 560);
            Controls.Add(card);
            FormBorderStyle = FormBorderStyle.None;
            Name = "ChartDetail";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            card.ResumeLayout(false);
            card.PerformLayout();
            chartArea.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Guna2Panel card;
        private Guna2Panel accentBar;
        private Label      lblTitle;
        private Label      lblFromCap;
        private Guna2ComboBox cboFrom;
        private Label      lblToCap;
        private Guna2ComboBox cboTo;
        private Panel      chartArea;
        private GunaChart  chart;
        private Guna2Button btnClose;
    }
}
