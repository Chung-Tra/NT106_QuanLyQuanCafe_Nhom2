using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using Guna.Charts.WinForms;

namespace GUI
{
    // Detail form: monthly COLUMN CHART with a from-month → to-month range picker.
    // Chart is fitted to a 2:1 box centred in the area so it is never clipped.
    public partial class ChartDetail : Form
    {
        private readonly (int Year, int Month, double A, double B)[] _data;
        private readonly string _nameA, _nameB;
        private readonly Color _colorA, _colorB;

        // Ctor không tham số: chỉ để VS Designer mở được form (runtime luôn dùng ctor có tham số bên dưới)
        public ChartDetail()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object? sender, EventArgs e) => Close();

        public ChartDetail(string title, Color accent,
            string nameA, Color colorA, string nameB, Color colorB,
            IReadOnlyList<(int Year, int Month, double A, double B)> monthly)
        {
            _data = monthly.ToArray();
            _nameA = nameA; _colorA = colorA; _nameB = nameB; _colorB = colorB;

            InitializeComponent();
            FormCorners.Round(this);

            // Dynamic: set accent-colour bar + title (depend on constructor args)
            accentBar.FillColor = accent;
            lblTitle.Text       = title;
            btnClose.FillColor  = accent;
            btnClose.HoverState.FillColor = Theme.Lighten(accent, 16);

            // Populate month combos
            for (int i = 0; i < _data.Length; i++)
            {
                string s = $"T{_data[i].Month}/{_data[i].Year}";
                cboFrom.Items.Add(s);
                cboTo.Items.Add(s);
            }
            cboFrom.SelectedIndex = 0;
            cboTo.SelectedIndex   = _data.Length - 1;
            cboFrom.SelectedIndexChanged += (s, e) => Redraw();
            cboTo.SelectedIndexChanged   += (s, e) => Redraw();

            chartArea.Resize += (s, e) => FitChart();
            Load += (s, e) => { FitChart(); Redraw(); };

            WindowChrome.Apply(this, host: card, dragHandle: card);
        }

        // Ép chart vào ô 2:1 canh giữa → không bị che/cắt
        private void FitChart()
        {
            int pw = chartArea.ClientSize.Width, ph = chartArea.ClientSize.Height;
            if (pw <= 8 || ph <= 8) return;
            int w, h;
            if (pw <= ph * 2) { w = pw; h = pw / 2; }
            else              { h = ph; w = ph * 2; }
            chart.SetBounds((pw - w) / 2, (ph - h) / 2, w, h);
            chart.Update();
        }

        private void Redraw()
        {
            int from = Math.Min(cboFrom.SelectedIndex, cboTo.SelectedIndex);
            int to   = Math.Max(cboFrom.SelectedIndex, cboTo.SelectedIndex);

            var dsA = new GunaBarDataset { Label = _nameA };
            var dsB = new GunaBarDataset { Label = _nameB };
            for (int i = from; i <= to; i++)
            {
                string lbl = $"T{_data[i].Month}";
                dsA.DataPoints.Add(lbl, _data[i].A);
                dsB.DataPoints.Add(lbl, _data[i].B);
            }
            dsA.FillColors.Add(_colorA);
            dsB.FillColors.Add(_colorB);

            chart.Datasets.Clear();
            chart.Datasets.Add(dsA);
            chart.Datasets.Add(dsB);
            chart.Update();
        }
    }
}
