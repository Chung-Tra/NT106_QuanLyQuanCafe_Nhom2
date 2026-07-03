using System;
using System.Drawing;
using System.Windows.Forms;

namespace GUI
{
    // Làm cho mọi UserControl nội dung "vừa khít" khi cửa sổ phóng to / thu nhỏ.
    //
    // Các màn hình được vẽ ở Designer với toạ độ tuyệt đối; một số panel/lưới quên
    // gắn Anchor nên khi UC được Dock=Fill vào khung lớn hơn chúng vẫn nằm yên ở
    // góc trái-trên (để lại khoảng trống bên phải/đáy). Helper này CHỈ BỔ SUNG
    // Anchor (không bao giờ gỡ):
    //   • control trải gần hết bề ngang        -> thêm Left|Right  (giãn ngang),
    //   • panel cao & mép dưới đã sát cạnh đáy  -> thêm Top|Bottom  (giãn xuống đáy).
    // Rồi đệ quy vào panel "chạm đáy" để kéo giãn lưới bên trong.
    //
    // QUAN TRỌNG: chỉ giãn xuống panel ĐÃ chạm đáy → không bao giờ kéo một panel ở
    // trên đè lên panel bên dưới (tránh lỗi "hai panel chồng nhau" khi xếp dọc).
    //
    // Bỏ qua các container TableLayoutPanel: chúng tự lo bố cục theo % nên không
    // được can thiệp Anchor (giữ nguyên các màn hình đã chuyển sang TableLayoutPanel).
    //
    // Gọi 1 lần trong MainDashboard.ShowUserControl, TRƯỚC khi Dock=Fill (lúc UC vẫn
    // ở kích thước thiết kế) nên áp dụng đồng nhất cho tất cả màn hình mà không phải
    // sửa từng .Designer.cs.
    internal static class ResponsiveLayout
    {
        public static void Apply(UserControl uc)
        {
            if (uc == null) return;
            try
            {
                Size s = uc.ClientSize;
                if (s.Width <= 0 || s.Height <= 0) s = uc.Size;
                FillChildren(uc, s.Width, s.Height);
            }
            catch
            {
                // Bố cục chỉ là tô điểm — không bao giờ để nó làm sập UI.
            }
        }

        private static void FillChildren(Control container, int w, int h)
        {
            if (w <= 0 || h <= 0) return;
            if (container is TableLayoutPanel) return; // TLP tự lo bố cục của nó

            int sideTol = Math.Max(40, w / 18);   // dung sai "chạm mép phải"
            int bottomTol = Math.Max(48, h / 8);   // dung sai "chạm cạnh đáy"

            foreach (Control c in container.Controls)
            {
                if (c.Dock != DockStyle.None) continue;

                bool spansWidth = c.Left <= sideTol
                               && (w - (c.Left + c.Width)) <= sideTol
                               && c.Width >= w * 0.5;

                // Chỉ panel cao đáng kể VÀ mép dưới đã sát đáy mới được giãn xuống.
                // Chỉ áp cho control dạng chứa (panel/lưới/danh sách) — không bao giờ
                // kéo giãn nút bấm/label/combobox theo chiều dọc.
                bool reachesBottom = IsVerticallyStretchable(c)
                                  && (h - (c.Top + c.Height)) <= bottomTol
                                  && c.Height >= h * 0.20;

                if (spansWidth)
                    c.Anchor |= AnchorStyles.Left | AnchorStyles.Right;
                if (reachesBottom)
                    c.Anchor |= AnchorStyles.Top | AnchorStyles.Bottom;

                // Đệ quy vào panel giãn cả hai chiều để kéo lưới/nội dung bên trong.
                if (spansWidth && reachesBottom)
                    Recurse(c);
            }

            // Đệ quy vào panel đang Dock=Fill (vd. root panel của một số màn hình).
            foreach (Control c in container.Controls)
                if (c.Dock == DockStyle.Fill)
                    Recurse(c);
        }

        // Control "dạng chứa" mới được giãn xuống đáy: panel, lưới, danh sách,
        // hoặc bất kỳ control nào đang chứa control con (vd. Guna2Panel bọc chart).
        // Nút bấm/label/picturebox đứng lẻ thì không (từng làm nút "Lưu khách hàng"
        // của ucCRM_Order phình cao ~250px khi phóng to).
        private static bool IsVerticallyStretchable(Control c) =>
            c is Panel
            || c is GroupBox
            || c is DataGridView
            || c is ListBox
            || c is ListView
            || c is TreeView
            || c is ScrollableControl
            || c.Controls.Count > 0;

        private static void Recurse(Control c)
        {
            if (c is TableLayoutPanel) return;
            Size cs = c.ClientSize;
            FillChildren(c, cs.Width > 0 ? cs.Width : c.Width, cs.Height > 0 ? cs.Height : c.Height);
        }
    }
}
