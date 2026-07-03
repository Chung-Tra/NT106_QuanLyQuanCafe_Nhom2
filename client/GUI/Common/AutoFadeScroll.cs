using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace GUI
{
    internal static class AutoFadeScroll
    {
        // Khử trùng: mỗi DataGridView chỉ gắn 1 lần (UC gọi qua AttachAll + form gọi qua
        // hook ở WindowChrome có thể trùng nhau). Gắn 2 lần sẽ nhân đôi cover + cuộn chuột.
        private static readonly ConditionalWeakTable<DataGridView, object> _attached = new();
        private static readonly ConditionalWeakTable<ScrollableControl, object> _attachedPanels = new();

        // Quét đệ quy mọi DataGridView + Panel AutoScroll trong 1 container và attach.
        public static void AttachAll(Control container)
        {
            if (container == null) return;
            foreach (var dgv in FindAllDgvs(container))
                Attach(dgv);
            foreach (var panel in FindAllScrollPanels(container))
                AttachPanel(panel);
        }

        private static IEnumerable<DataGridView> FindAllDgvs(Control parent)
        {
            foreach (Control c in parent.Controls)
            {
                if (c is DataGridView dgv) yield return dgv;
                foreach (var nested in FindAllDgvs(c)) yield return nested;
            }
        }

        // Chỉ nhắm Panel/FlowLayoutPanel có AutoScroll (đó là nơi hiện scrollbar trắng);
        // không đụng Form/UserControl/SplitContainer để tránh phá layout đặc thù.
        private static IEnumerable<ScrollableControl> FindAllScrollPanels(Control parent)
        {
            foreach (Control c in parent.Controls)
            {
                if (c is Panel p && p.AutoScroll) yield return p;
                foreach (var nested in FindAllScrollPanels(c)) yield return nested;
            }
        }

        // DataGridView: scroll wheel di chuyển selection row + hiện thanh teal fade
        public static void Attach(DataGridView dgv)
        {
            if (dgv == null || dgv.Parent == null) return;
            if (_attached.TryGetValue(dgv, out _)) return; // đã gắn rồi → bỏ qua
            _attached.Add(dgv, new object());

            dgv.ScrollBars = ScrollBars.None;

            // Tự canh lề dữ liệu hợp lý (ít → giữa, nhiều → trái); cột số tiền canh phải
            // tường minh sẽ được giữ nguyên.
            GridAutoAlign.Enable(dgv);

            // Chừa sẵn 1 dải bên phải đúng bằng bề rộng dải 'cover' (che scrollbar gốc).
            // dgv.Padding KHÔNG được cột AutoSizeColumnsMode.Fill trừ vào khi tính bề rộng
            // (đã kiểm chứng: cột Fill vẫn tràn hết ClientSize dù có Padding), nên chỉ set
            // Padding ở đây là chưa đủ — vẫn phải chừa lề ngay trong cột cuối (bên dưới).
            const int rail = 18;
            dgv.Padding = new Padding(dgv.Padding.Left, dgv.Padding.Top,
                                      Math.Max(dgv.Padding.Right, rail), dgv.Padding.Bottom);

            // Chừa lề phải NGAY TRONG cell của cột cuối (thường là cột canh phải như
            // "Số tiền"/"Lương") để nội dung dừng lại trước khi chạm dải 'cover' — cách
            // này không phụ thuộc việc DataGridView có thật sự trừ Padding cho cột Fill hay
            // không. Gọi lại mỗi khi grid đổi kích thước vì cột thường được Add SAU Attach
            // (lúc đó dgv.Columns rỗng) rồi mới Size được set.
            void EnsureTailGutter()
            {
                DataGridViewColumn? last = null;
                for (int i = dgv.Columns.Count - 1; i >= 0; i--)
                {
                    if (dgv.Columns[i].Visible) { last = dgv.Columns[i]; break; }
                }
                if (last == null) return;

                var p = last.DefaultCellStyle.Padding;
                if (p.Right < rail) last.DefaultCellStyle.Padding = new Padding(p.Left, p.Top, rail, p.Bottom);

                var hp = last.HeaderCell.Style.Padding;
                if (hp.Right < rail) last.HeaderCell.Style.Padding = new Padding(hp.Left, hp.Top, rail, hp.Bottom);
            }
            EnsureTailGutter();

            // Che thanh scrollbar gốc
            var cover = new Panel { BackColor = dgv.BackgroundColor, Width = rail, Visible = true };
            dgv.Parent.Controls.Add(cover);
            cover.Location = new Point(dgv.Right - 18, dgv.Top);
            cover.Height = dgv.Height;
            cover.BringToFront();

            dgv.SizeChanged += (s, e) =>
            {
                cover.Location = new Point(dgv.Right - 18, dgv.Top);
                cover.Height = dgv.Height;
                EnsureTailGutter();
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
                _attached.Remove(dgv);
                fadeTimer.Stop();
                fadeTimer.Dispose();
                indicator.Dispose();
                cover.Dispose();
            };
        }

        // ------------------------------------------------------------------
        // Panel/FlowLayoutPanel AutoScroll: giấu scrollbar trắng của Windows,
        // thay bằng thanh teal fade (đồng bộ với DataGridView ở trên).
        // Cuộn bằng lăn chuột vẫn hoạt động bình thường (AutoScroll giữ nguyên,
        // chỉ ẩn phần vẽ scrollbar gốc).
        // ------------------------------------------------------------------

        [DllImport("user32.dll")]
        private static extern int GetWindowLong(IntPtr hWnd, int nIndex);
        [DllImport("user32.dll")]
        private static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);
        [DllImport("user32.dll")]
        private static extern bool SetWindowPos(IntPtr hWnd, IntPtr after, int x, int y, int w, int h, uint flags);

        private const int GWL_STYLE = -16;
        private const int WS_VSCROLL = 0x00200000;
        private const uint SWP_FRAMECHANGED_FLAGS = 0x0001 | 0x0002 | 0x0004 | 0x0010 | 0x0020;
        // SWP_NOSIZE | SWP_NOMOVE | SWP_NOZORDER | SWP_NOACTIVATE | SWP_FRAMECHANGED

        // Gỡ style WS_VSCROLL ngay tại WM_NCCALCSIZE — thời điểm Windows tính khung
        // cửa sổ, TRƯỚC khi scrollbar được vẽ. Cách ẩn bằng ShowScrollBar sau sự kiện
        // không đủ: khi cuộn nhanh, SetScrollInfo vẽ lại thanh trắng ngay giữa hai
        // event → bị lóe. Chặn ở đây thì thanh gốc không bao giờ xuất hiện.
        private sealed class VScrollStripper : NativeWindow
        {
            private const int WM_NCCALCSIZE = 0x0083;

            protected override void WndProc(ref Message m)
            {
                if (m.Msg == WM_NCCALCSIZE)
                {
                    int style = GetWindowLong(Handle, GWL_STYLE);
                    if ((style & WS_VSCROLL) != 0)
                        SetWindowLong(Handle, GWL_STYLE, style & ~WS_VSCROLL);
                }
                base.WndProc(ref m);
            }
        }

        public static void AttachPanel(ScrollableControl sc)
        {
            if (sc == null || sc.Parent == null || sc.IsDisposed) return;
            if (_attachedPanels.TryGetValue(sc, out _)) return; // đã gắn rồi → bỏ qua
            _attachedPanels.Add(sc, new object());

            var stripper = new VScrollStripper();

            void Hook()
            {
                if (!sc.IsHandleCreated || sc.IsDisposed) return;
                stripper.AssignHandle(sc.Handle);
                // Ép tính lại khung ngay để gỡ scrollbar đang hiển thị (nếu có)
                SetWindowPos(sc.Handle, IntPtr.Zero, 0, 0, 0, 0, SWP_FRAMECHANGED_FLAGS);
            }

            sc.HandleCreated   += (s, e) => Hook(); // handle tạo lại → subclass lại
            sc.HandleDestroyed += (s, e) => stripper.ReleaseHandle();
            Hook();

            // Thanh teal indicator (nằm đè mép phải panel, tự mờ sau khi ngừng cuộn)
            var indicator = new Panel { BackColor = Color.FromArgb(31, 138, 154), Width = 4, Visible = false };
            sc.Parent.Controls.Add(indicator);
            indicator.BringToFront();

            var fadeTimer = new System.Windows.Forms.Timer { Interval = 900 };
            fadeTimer.Tick += (s, e) => { fadeTimer.Stop(); indicator.Visible = false; };

            void UpdateIndicator()
            {
                var vs = sc.VerticalScroll;
                if (!vs.Visible || vs.Maximum <= vs.LargeChange)
                {
                    indicator.Visible = false;
                    return;
                }

                int range = Math.Max(1, vs.Maximum - vs.LargeChange + 1); // Value tối đa đạt được
                float ratio = Math.Clamp((float)vs.Value / range, 0f, 1f);

                int trackH = sc.Height - 8;
                int thumbH = Math.Max(20, (int)((long)trackH * vs.LargeChange / Math.Max(1, vs.Maximum + 1)));
                int thumbY = (int)((trackH - thumbH) * ratio);

                indicator.Bounds = new Rectangle(sc.Right - 8, sc.Top + 4 + thumbY, 4, thumbH);
                indicator.Visible = true;
                indicator.BringToFront();
                fadeTimer.Stop();
                fadeTimer.Start();
            }

            sc.Scroll     += (s, e) => UpdateIndicator();
            sc.MouseWheel += (s, e) => UpdateIndicator();

            sc.Disposed += (s, e) =>
            {
                _attachedPanels.Remove(sc);
                stripper.ReleaseHandle();
                fadeTimer.Stop();
                fadeTimer.Dispose();
                indicator.Dispose();
            };
        }
    }
}
