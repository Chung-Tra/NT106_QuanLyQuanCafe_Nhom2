using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace GUI
{
    // Nút "🔄 làm mới" nổi ở góc trên-phải của TỪNG DataGridView: chỉ tải lại dữ liệu
    // của đúng grid đó, không dựng lại cả UserControl (dựng lại UC rất chậm vì layout
    // + fetch mọi bảng). Nút được add làm CON của dgv (không add vào Parent — nếu
    // Parent là TableLayoutPanel thì control lạ sẽ bị xếp vào ô và vỡ layout).
    public static class DgvRefresh
    {
        public static void Attach(DataGridView dgv, Action reload) =>
            Attach(dgv, () => { reload(); return Task.CompletedTask; });

        public static void Attach(DataGridView dgv, Func<Task> reloadAsync)
        {
            var btn = new Guna2Button
            {
                Text         = "🔄",
                FillColor    = Color.FromArgb(45, 45, 50),
                ForeColor    = Color.FromArgb(31, 138, 154),
                Cursor       = Cursors.Hand,
                // Neo Top|Right trong lòng dgv -> tự bám góc khi grid giãn theo layout
                Anchor       = AnchorStyles.Top | AnchorStyles.Right,
            };
            btn.HoverState.FillColor = Color.FromArgb(31, 138, 154);
            new ToolTip().SetToolTip(btn, "Làm mới dữ liệu bảng này");

            // Chip phải nằm GỌN trong hàng header, nếu không sẽ đè chữ của dòng dữ liệu
            // đầu tiên. Chiều cao header chỉ chốt SAU khi Guna áp ThemeStyle / StyleGrid
            // chạy -> tính lại mỗi khi nó đổi (và khi grid đổi cỡ, cách mép phải 24px
            // để né right-rail). Đồng thời CHỪA CHỖ cho chip: tiêu đề cột cuối thụt vào
            // đúng bề rộng chip để không có chữ nào bị chip che (AutoFadeScroll/GridAutoAlign
            // chỉ NÂNG padding khi nhỏ hơn nên giá trị lớn hơn ở đây không bị ghi đè).
            void Fit()
            {
                int headerH = Math.Max(dgv.ColumnHeadersHeight, 22);
                int side    = Math.Min(26, headerH - 4);
                btn.Font         = new Font("Segoe UI Emoji", side < 24 ? 7F : 8.5F);
                btn.Size         = new Size(side, side);
                btn.BorderRadius = Math.Max(4, side / 2 - 1);
                btn.Location     = new Point(dgv.ClientSize.Width - side - 24, Math.Max(2, (headerH - side) / 2));

                DataGridViewColumn? last = null;
                for (int i = dgv.Columns.Count - 1; i >= 0; i--)
                    if (dgv.Columns[i].Visible) { last = dgv.Columns[i]; break; }
                if (last != null)
                {
                    int reserve = side + 24 + 6; // chip + lề phải + khe hở
                    var hp = last.HeaderCell.Style.Padding;
                    if (hp.Right < reserve)
                        last.HeaderCell.Style.Padding = new Padding(hp.Left, hp.Top, reserve, hp.Bottom);
                }
            }
            Fit();
            dgv.ColumnHeadersHeightChanged += (s, e) => Fit();
            dgv.SizeChanged                += (s, e) => Fit();
            // Cột thường được bind/Add SAU Attach; BeginInvoke để chạy SAU các handler
            // khác của DataBindingComplete (GridAutoAlign đặt Padding.Empty cho cột giữa).
            dgv.DataBindingComplete += (s, e) =>
            {
                if (dgv.IsHandleCreated) dgv.BeginInvoke(new Action(Fit));
                else Fit();
            };
            dgv.Controls.Add(btn);
            btn.BringToFront();

            btn.Click += async (s, e) =>
            {
                btn.Enabled = false;
                btn.Text = "…";
                try { await reloadAsync(); }
                catch { /* các hàm load đã tự MsgBox lỗi */ }
                finally
                {
                    btn.Text = "🔄";
                    btn.Enabled = true;
                    btn.BringToFront();
                }
            };
        }
    }
}
