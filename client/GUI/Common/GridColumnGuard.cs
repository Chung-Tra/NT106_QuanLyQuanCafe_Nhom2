using System.Windows.Forms;

namespace GUI
{
    // Khi mở .Designer.cs trong Visual Studio, designer hay round-trip và đổi
    // DataGridViewColumn.Name thành tên biến (vd "colMgrId") trong khi DataPropertyName
    // vẫn giữ tên nghiệp vụ ("Mã QL"). Điều này làm các lookup Columns["Mã QL"] /
    // Cells["Mã QL"] trả null -> NullReferenceException.
    //
    // Gọi SyncColumnNames sau khi bind/khởi tạo để khôi phục Name == DataPropertyName,
    // giúp mọi lookup theo tên nghiệp vụ hoạt động ổn định bất kể VS có đổi Name hay không.
    internal static class GridColumnGuard
    {
        public static void SyncColumnNames(DataGridView dgv)
        {
            if (dgv == null) return;
            foreach (DataGridViewColumn c in dgv.Columns)
                if (!string.IsNullOrEmpty(c.DataPropertyName) && c.Name != c.DataPropertyName)
                    c.Name = c.DataPropertyName;
        }
    }
}
