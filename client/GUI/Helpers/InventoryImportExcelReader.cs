using System.Globalization;
using System.Linq;
using System.Text;

namespace GUI
{
    // Đọc chi tiết phiếu từ Excel (.xlsx) hoặc CSV (UTF-8); nhận dạng cột theo tiêu đề.
    internal static class InventoryImportExcelReader
    {
        public static IReadOnlyList<InventoryImportPrefillLine> Read(string path)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(path);
            if (!File.Exists(path))
                throw new FileNotFoundException("Không thấy file.", path);

            string ext = Path.GetExtension(path).ToLowerInvariant();
            return ext == ".csv" ? ReadCsv(path) : ReadXlsx(path);
        }

        private static List<InventoryImportPrefillLine> ReadCsv(string path)
        {
            string raw = File.ReadAllText(path, Encoding.UTF8);
            if (raw.Length > 0 && raw[0] == '﻿')
                raw = raw[1..];

            string[] lines = raw.Split(["\r\n", "\n", "\r"], StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
            if (lines.Length == 0)
                return [];

            string delim = GuessDelim(lines[0]);
            string[][] rows = [.. lines.Select(l => SplitCsvLine(l, delim))];
            return ParseMatrix(rows);
        }

        private static string GuessDelim(string firstLine) =>
            firstLine.Count(c => c == ';') > firstLine.Count(c => c == ',') ? ";" : ",";

        private static string[] SplitCsvLine(string line, string delim)
        {
            if (delim == ";")
                return line.Split(';', StringSplitOptions.TrimEntries);
            return line.Split(',', StringSplitOptions.TrimEntries);
        }

        private static List<InventoryImportPrefillLine> ReadXlsx(string path)
        {
            using var wb = new ClosedXML.Excel.XLWorkbook(path);
            ClosedXML.Excel.IXLWorksheet ws = wb.Worksheet(1);
            ClosedXML.Excel.IXLRange? used = ws.RangeUsed();
            if (used == null)
                return [];

            int r0 = used.FirstRow().RowNumber();
            int r1 = used.LastRow().RowNumber();
            int c0 = used.FirstColumn().ColumnNumber();
            int c1 = used.LastColumn().ColumnNumber();

            List<string[]> rows = [];
            for (int r = r0; r <= r1; r++)
            {
                List<string> cells = [];
                for (int c = c0; c <= c1; c++)
                {
                    ClosedXML.Excel.IXLCell cell = ws.Cell(r, c);
                    string s = cell.DataType == ClosedXML.Excel.XLDataType.Number
                        ? cell.GetDouble().ToString(CultureInfo.InvariantCulture)
                        : cell.GetString().Trim();
                    cells.Add(s);
                }
                if (cells.All(string.IsNullOrWhiteSpace))
                    continue;
                rows.Add([.. cells]);
            }

            if (rows.Count == 0)
                return [];

            return ParseMatrix([.. rows]);
        }

        private static List<InventoryImportPrefillLine> ParseMatrix(string[][] rows)
        {
            bool header = RowLooksLikeHeader(rows[0]);
            int start = header ? 1 : 0;

            int colId, colQty, colPrice;
            if (header)
            {
                (colId, colQty, colPrice) = MapHeaderColumns(rows[0]);
                if (colId < 0 || colQty < 0)
                {
                    colId = 0;
                    colQty = 1;
                    colPrice = rows[0].Length > 2 ? 2 : -1;
                }
            }
            else
            {
                colId = 0;
                colQty = 1;
                colPrice = rows[0].Length > 2 ? 2 : -1;
            }

            List<InventoryImportPrefillLine> list = [];
            for (int i = start; i < rows.Length; i++)
            {
                string[] row = rows[i];
                if (row.Length <= Math.Max(colId, colQty))
                    continue;

                string id = row[colId].Trim();
                if (string.IsNullOrEmpty(id))
                    continue;

                if (!TryLong(row[colQty], out long qty) || qty <= 0)
                    continue;

                long? price = null;
                if (colPrice >= 0 && row.Length > colPrice && TryLong(row[colPrice], out long p))
                    price = p;

                list.Add(new InventoryImportPrefillLine(id, qty, price));
            }

            return list;
        }

        private static bool RowLooksLikeHeader(string[] row)
        {
            if (row.Length == 0 || NguyenIdLike(row[0]))
                return false;

            foreach (var cell in row)
            {
                string n = Norm(cell);
                if (LooksLikeMaNlHeader(n) || LooksLikeSlHeader(n))
                    return true;
            }

            return false;
        }

        private static bool NguyenIdLike(string s)
        {
            string t = s.Trim();
            return t.StartsWith("nl_", StringComparison.OrdinalIgnoreCase)
                || t.StartsWith("ngl_", StringComparison.OrdinalIgnoreCase);
        }

        private static (int colId, int colQty, int colPrice) MapHeaderColumns(string[] headerCells)
        {
            int colId = -1, colQty = -1, colPrice = -1;
            for (int i = 0; i < headerCells.Length; i++)
            {
                string n = Norm(headerCells[i]);
                if (colId < 0 && LooksLikeMaNlHeader(n))
                    colId = i;
                else if (colQty < 0 && LooksLikeSlHeader(n))
                    colQty = i;
                else if (colPrice < 0 && LooksLikeGiaHeader(n))
                    colPrice = i;
            }

            return (colId, colQty, colPrice);
        }

        private static bool LooksLikeMaNlHeader(string n)
        {
            return n.Contains("manl") || n.Contains("ma_nl")
                || (n.Contains("ma") && n.Contains("nl"))
                || (n.Contains("ma") && n.Contains("nguyen"))
                || n == "id";
        }

        private static bool LooksLikeSlHeader(string n) =>
            n.Contains("so_luong") || n.Contains("soluong") || n == "sl"
            || n.Contains("qty") || n.Contains("quantity");

        private static bool LooksLikeGiaHeader(string n) =>
            (n.Contains("gia") && n.Contains("nhap"))
            || n.Contains("don_gia")
            || (n.StartsWith("gia", StringComparison.Ordinal) && !n.StartsWith("giam", StringComparison.Ordinal));

        private static string Norm(string s)
        {
            s = s.Trim().ToLowerInvariant().Replace("đ", "d");
            var sb = new StringBuilder(s.Length);
            foreach (char c in s.Normalize(NormalizationForm.FormD))
            {
                if (CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
                    sb.Append(c);
            }
            return sb.ToString().Normalize(NormalizationForm.FormC)
                .Replace(" ", "_")
                .Replace("-", "_");
        }

        private static bool TryLong(string? s, out long v)
        {
            v = 0;
            if (string.IsNullOrWhiteSpace(s))
                return false;
            s = s.Trim().Replace(",", "").Replace(".", "");
            return long.TryParse(s, NumberStyles.Integer, CultureInfo.InvariantCulture, out v);
        }
    }
}
