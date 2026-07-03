using System.Data;

namespace GUI
{
    // Dựng RowFilter tìm từ khóa trên MỌI cột của DataTable (cột số bọc Convert
    // để LIKE được). Dùng chung cho các thanh tìm kiếm trên dgv để không màn nào
    // chỉ lọc được vài trường.
    public static class SearchFilter
    {
        // '%', '*', '[' là wildcard của DataView LIKE — escape để tìm literal, tránh EvaluateException
        public static string EscapeLike(string raw) =>
            raw.Trim()
               .Replace("'", "''")
               .Replace("[", "[[]")
               .Replace("%", "[%]")
               .Replace("*", "[*]");

        // Trả về mệnh đề "(col1 LIKE ... OR col2 LIKE ...)" trên mọi cột trừ excludeCols
        // (cột kỹ thuật: AuthUid, URL ảnh, cờ bool…). Từ khóa rỗng -> chuỗi rỗng (bỏ lọc).
        public static string AllColumnsFilter(DataTable dt, string rawKeyword, params string[] excludeCols)
        {
            string kw = EscapeLike(rawKeyword);
            if (kw.Length == 0) return string.Empty;

            List<string> parts = new();
            foreach (DataColumn col in dt.Columns)
            {
                if (excludeCols.Contains(col.ColumnName)) continue;
                parts.Add(col.DataType == typeof(string)
                    ? $"[{col.ColumnName}] LIKE '%{kw}%'"
                    : $"Convert([{col.ColumnName}], 'System.String') LIKE '%{kw}%'");
            }
            return parts.Count == 0 ? string.Empty : "(" + string.Join(" OR ", parts) + ")";
        }
    }
}
