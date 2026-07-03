using System.Reflection;
using System.Windows.Forms;

namespace GUI
{
    // Tiện ích chung cho control. Hiện có: bật double-buffer cho các control không expose
    // sẵn (TableLayoutPanel, Panel, DataGridView…) để giảm nhấp nháy/giật khi vẽ lại nhiều
    // control con — nhất là lưới lịch dựng lại toàn bộ Label mỗi lần đổi tuần.
    internal static class ControlExtensions
    {
        private static readonly PropertyInfo? _doubleBufferedProp =
            typeof(Control).GetProperty("DoubleBuffered",
                BindingFlags.Instance | BindingFlags.NonPublic);

        public static void EnableDoubleBuffer(this Control control)
        {
            if (control == null) return;
            // DoubleBuffered là protected → set qua reflection (an toàn, bỏ qua nếu không được).
            _doubleBufferedProp?.SetValue(control, true, null);
        }
    }
}
