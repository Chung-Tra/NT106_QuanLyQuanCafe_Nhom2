using System;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace GUI
{
    // Canh lề "hợp lý" cho dữ liệu trong DataGridView:
    //   • cột dữ liệu NGẮN (mã, ngày, số đếm, trạng thái…) -> căn giữa,
    //   • cột dữ liệu DÀI  (tên, mô tả, nội dung, ghi chú…) -> căn trái.
    //
    // KHÔNG đụng tới cột đã canh tường minh trong code (vd. "Số tiền"/"Lương" căn phải):
    // chỉ xử lý cột còn ở mặc định (Alignment == NotSet).
    //
    // Độ dài nội dung chỉ biết được sau khi có dữ liệu nên chạy lại mỗi lần lưới bind
    // (DataBindingComplete) + 1 lần ngay khi gắn nếu lưới đã có sẵn dữ liệu. Gắn 1 lần
    // cho mỗi lưới (ConditionalWeakTable chống gắn trùng), gọi từ AutoFadeScroll.Attach
    // (phủ mọi lưới trong các UC) và Theme.StyleGrid.
    internal static class GridAutoAlign
    {
        private const int ShortMax = 12;   // <= 12 ký tự coi là "ít dữ liệu" -> căn giữa
        private const int SampleRows = 60;

        private static readonly ConditionalWeakTable<DataGridView, object> _wired = new();

        public static void Enable(DataGridView dgv)
        {
            if (dgv == null || _wired.TryGetValue(dgv, out _)) return;
            _wired.Add(dgv, new object());

            dgv.DataBindingComplete += (_, _) => Apply(dgv);
            if (dgv.RowCount > 0) Apply(dgv); // lưới đã có dữ liệu sẵn lúc gắn
        }

        public static void Apply(DataGridView dgv)
        {
            if (dgv == null || dgv.Columns.Count == 0) return;
            try
            {
                foreach (DataGridViewColumn col in dgv.Columns)
                {
                    if (!col.Visible) continue;

                    // Cột tiền canh phải tường minh: cho header canh phải theo (số nằm
                    // ngay dưới tiêu đề) và chừa khe phải để số không dính cột kế bên.
                    // Cột cuối đã có right-rail 18px của AutoFadeScroll nên không chèn thêm.
                    var align = col.DefaultCellStyle.Alignment;
                    if (align is DataGridViewContentAlignment.MiddleRight
                              or DataGridViewContentAlignment.TopRight
                              or DataGridViewContentAlignment.BottomRight)
                    {
                        col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                        bool isLast = IsLastVisible(dgv, col);
                        var cp = col.DefaultCellStyle.Padding;
                        var hp = col.HeaderCell.Style.Padding;
                        int pad = isLast ? 18 : 14;
                        if (cp.Right < pad && !isLast)
                            col.DefaultCellStyle.Padding = new Padding(cp.Left, cp.Top, pad, cp.Bottom);
                        if (hp.Right < pad)
                            col.HeaderCell.Style.Padding = new Padding(hp.Left, hp.Top, pad, hp.Bottom);
                        continue;
                    }

                    // Bỏ qua cột đã canh tường minh kiểu khác; chỉ xử lý cột mặc định.
                    if (align != DataGridViewContentAlignment.NotSet) continue;

                    if (MaxLen(dgv, col) <= ShortMax)
                    {
                        col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        col.DefaultCellStyle.Padding    = Padding.Empty; // canh giữa thật, bỏ lề trái mặc định
                        col.HeaderCell.Style.Alignment  = DataGridViewContentAlignment.MiddleCenter;
                        // Giữ lề phải đang có: cột cuối được AutoFadeScroll chừa right-rail
                        // và DgvRefresh chừa chỗ cho chip 🔄 — xóa sạch sẽ làm chip đè chữ.
                        col.HeaderCell.Style.Padding = new Padding(0, 0, col.HeaderCell.Style.Padding.Right, 0);
                    }
                    else
                    {
                        col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                        col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                    }
                }
            }
            catch
            {
                // Canh lề chỉ là tô điểm — không bao giờ để nó làm sập UI.
            }
        }

        private static bool IsLastVisible(DataGridView dgv, DataGridViewColumn col)
        {
            for (int i = dgv.Columns.Count - 1; i >= 0; i--)
                if (dgv.Columns[i].Visible) return dgv.Columns[i] == col;
            return false;
        }

        // Độ dài nội dung lớn nhất (mẫu vài chục dòng); rỗng thì lấy theo tiêu đề cột.
        private static int MaxLen(DataGridView dgv, DataGridViewColumn col)
        {
            int max = 0, seen = 0;
            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (row.IsNewRow) continue;
                object? v = row.Cells[col.Index].FormattedValue ?? row.Cells[col.Index].Value;
                int len = v?.ToString()?.Trim().Length ?? 0;
                if (len > max) max = len;
                if (++seen >= SampleRows) break;
            }
            return max > 0 ? max : (col.HeaderText?.Trim().Length ?? 0);
        }
    }
}
