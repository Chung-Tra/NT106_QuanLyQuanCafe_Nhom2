using System;
using System.Drawing;
using System.Windows.Forms;

namespace GUI
{
    internal static class AutoFadeScroll
    {
        // DataGridView: scroll wheel di chuyển selection row + hiện thanh teal fade
        public static void Attach(DataGridView dgv)
        {
            if (dgv.Parent == null) return;

            dgv.ScrollBars = ScrollBars.None;

            // Che thanh scrollbar gốc
            var cover = new Panel { BackColor = dgv.BackgroundColor, Width = 18, Visible = true };
            dgv.Parent.Controls.Add(cover);
            cover.Location = new Point(dgv.Right - 18, dgv.Top);
            cover.Height = dgv.Height;
            cover.BringToFront();

            dgv.SizeChanged += (s, e) =>
            {
                cover.Location = new Point(dgv.Right - 18, dgv.Top);
                cover.Height = dgv.Height;
            };

            // Thanh teal indicator
            var indicator = new Panel { BackColor = Color.FromArgb(31, 138, 154), Width = 4, Visible = false };
            dgv.Parent.Controls.Add(indicator);
            indicator.BringToFront();

            var fadeTimer = new System.Windows.Forms.Timer { Interval = 900 };
            fadeTimer.Tick += (s, e) => { fadeTimer.Stop(); indicator.Visible = false; };

            void UpdateIndicator()
            {
                if (dgv.RowCount == 0) { indicator.Visible = false; return; }
                int displayed = dgv.DisplayedRowCount(false);
                if (displayed >= dgv.RowCount) { indicator.Visible = false; return; }

                int first = Math.Max(0, dgv.FirstDisplayedScrollingRowIndex);
                int scrollable = dgv.RowCount - displayed;
                float ratio = scrollable > 0 ? (float)first / scrollable : 0f;

                int trackH = dgv.Height - 8;
                int thumbH = Math.Max(20, trackH * displayed / Math.Max(1, dgv.RowCount));
                int thumbY = (int)((trackH - thumbH) * Math.Clamp(ratio, 0f, 1f));

                indicator.Bounds = new Rectangle(dgv.Right - 8, dgv.Top + 4 + thumbY, 4, thumbH);
                indicator.Visible = true;
                fadeTimer.Stop();
                fadeTimer.Start();
            }

            dgv.MouseWheel += (s, e) =>
            {
                if (dgv.RowCount == 0) return;
                int step = e.Delta > 0 ? -1 : 1;
                int current = dgv.CurrentCell?.RowIndex ?? (step > 0 ? 0 : dgv.RowCount - 1);
                current = Math.Clamp(current + step, 0, dgv.RowCount - 1);
                int col = dgv.CurrentCell?.ColumnIndex ?? 0;
                dgv.CurrentCell = dgv.Rows[current].Cells[col];
                dgv.Rows[current].Selected = true;
                UpdateIndicator();
            };

            dgv.MouseEnter += (s, e) => dgv.Focus();
            dgv.Scroll += (s, e) => UpdateIndicator();

            dgv.Disposed += (s, e) =>
            {
                fadeTimer.Stop();
                fadeTimer.Dispose();
                indicator.Dispose();
                cover.Dispose();
            };
        }
    }
}
