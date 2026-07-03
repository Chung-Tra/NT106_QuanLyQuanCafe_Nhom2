using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Text;
using System.Windows.Forms;
using ClosedXML.Excel;

namespace GUI
{
    // Xuất dữ liệu của một DataGridView ra file THẬT, luôn mở SaveFileDialog để
    // người dùng tự chọn nơi lưu (thay cho kiểu báo "đã lưu ở Desktop" giả lập cũ).
    //   • Excel (.xlsx) – ghi bằng ClosedXML.
    //   • PDF   (.pdf)  – vẽ lưới ra ảnh rồi nhúng vào một file PDF tối giản,
    //                      hiển thị tốt cả tiếng Việt mà không cần thư viện PDF ngoài.
    internal static class GridExporter
    {
        public static void ExportExcel(DataGridView dgv, IWin32Window? owner, string baseName, string title)
        {
            List<DataGridViewColumn> cols = VisibleColumns(dgv);
            if (cols.Count == 0)
            {
                MsgBox.Show(owner, "Không có dữ liệu để xuất.", "Xuất Excel", MsgBox.MessageBoxType.Warning);
                return;
            }

            string? path = AskSavePath(owner, "Chọn nơi lưu file Excel",
                "Excel Workbook (*.xlsx)|*.xlsx", "xlsx", baseName);
            if (path == null) return;

            try
            {
                using var wb = new XLWorkbook();
                IXLWorksheet ws = wb.AddWorksheet(SheetName(title));

                for (int i = 0; i < cols.Count; i++)
                    ws.Cell(1, i + 1).Value = cols[i].HeaderText ?? $"Cột {i + 1}";

                int r = 2;
                foreach (DataGridViewRow row in dgv.Rows)
                {
                    if (row.IsNewRow) continue;
                    for (int i = 0; i < cols.Count; i++)
                        ApplyValue(ws.Cell(r, i + 1), row.Cells[cols[i].Index].Value);
                    r++;
                }

                IXLRange header = ws.Range(1, 1, 1, cols.Count);
                header.Style.Font.Bold = true;
                header.Style.Fill.BackgroundColor = XLColor.FromArgb(31, 138, 154);
                header.Style.Font.FontColor = XLColor.White;
                ws.Columns().AdjustToContents();

                wb.SaveAs(path);
                Saved(owner, path, "Excel");
            }
            catch (Exception ex)
            {
                MsgBox.Show(owner, "Không thể lưu file Excel:\n" + ex.Message, "Lỗi xuất file", MsgBox.MessageBoxType.Error);
            }
        }

        public static void ExportPdf(DataGridView dgv, IWin32Window? owner, string baseName, string title)
        {
            List<DataGridViewColumn> cols = VisibleColumns(dgv);
            if (cols.Count == 0)
            {
                MsgBox.Show(owner, "Không có dữ liệu để xuất.", "Xuất PDF", MsgBox.MessageBoxType.Warning);
                return;
            }

            string? path = AskSavePath(owner, "Chọn nơi lưu file PDF",
                "PDF (*.pdf)|*.pdf", "pdf", baseName);
            if (path == null) return;

            try
            {
                using Bitmap bmp = RenderGrid(dgv, cols, title);
                WriteImagePdf(path, bmp);
                Saved(owner, path, "PDF");
            }
            catch (Exception ex)
            {
                MsgBox.Show(owner, "Không thể lưu file PDF:\n" + ex.Message, "Lỗi xuất file", MsgBox.MessageBoxType.Error);
            }
        }

        // ----- Hộp thoại + thông báo dùng chung -----

        private static string? AskSavePath(IWin32Window? owner, string dlgTitle, string filter, string ext, string baseName)
        {
            using var sfd = new SaveFileDialog
            {
                Title = dlgTitle,
                Filter = filter,
                FileName = $"{SafeFileName(baseName)}_{DateTime.Now:yyyyMMdd}.{ext}",
                DefaultExt = ext,
                AddExtension = true,
                OverwritePrompt = true,
                RestoreDirectory = true,
            };

            DialogResult dr = owner != null ? sfd.ShowDialog(owner) : sfd.ShowDialog();
            if (dr != DialogResult.OK || string.IsNullOrWhiteSpace(sfd.FileName)) return null;
            return sfd.FileName;
        }

        private static void Saved(IWin32Window? owner, string path, string kind) =>
            MsgBox.Show(owner, $"Đã lưu file {kind} tại:\n{path}", $"Xuất {kind} thành công", MsgBox.MessageBoxType.Success);

        private static List<DataGridViewColumn> VisibleColumns(DataGridView dgv)
        {
            var list = new List<DataGridViewColumn>();
            if (dgv == null) return list;
            foreach (DataGridViewColumn c in dgv.Columns)
                if (c.Visible) list.Add(c);
            list.Sort((a, b) => a.DisplayIndex.CompareTo(b.DisplayIndex));
            return list;
        }

        private static void ApplyValue(IXLCell cell, object? v)
        {
            switch (v)
            {
                case null:
                case DBNull:
                    return;
                case bool b:
                    cell.Value = b;
                    return;
                case DateTime dt:
                    cell.Value = dt;
                    return;
            }

            if (v is long or int or short or byte or decimal or double or float)
            {
                double d = Convert.ToDouble(v, CultureInfo.InvariantCulture);
                cell.Value = d;
                if ((v is long or int or short or byte or decimal) && d == Math.Floor(d))
                    cell.Style.NumberFormat.Format = "#,##0";
                return;
            }

            cell.Value = v.ToString() ?? string.Empty;
        }

        // ----- Vẽ lưới ra ảnh để nhúng vào PDF -----

        private static Bitmap RenderGrid(DataGridView dgv, List<DataGridViewColumn> cols, string title)
        {
            var rows = new List<string[]>();
            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (row.IsNewRow) continue;
                var arr = new string[cols.Count];
                for (int i = 0; i < cols.Count; i++)
                {
                    DataGridViewCell cell = row.Cells[cols[i].Index];
                    arr[i] = (cell.FormattedValue ?? cell.Value)?.ToString() ?? string.Empty;
                }
                rows.Add(arr);
            }

            const int padX = 12, minW = 64, maxW = 300;
            const int marginL = 28, marginR = 28, marginT = 24, marginB = 28;
            const int rowH = 28, headH = 32, titleH = 48;

            using var measure = new Bitmap(1, 1);
            using Graphics gm = Graphics.FromImage(measure);
            using var titleFont = new Font("Segoe UI", 15f, FontStyle.Bold);
            using var headFont = new Font("Segoe UI", 9.5f, FontStyle.Bold);
            using var cellFont = new Font("Segoe UI", 9.5f);

            var widths = new int[cols.Count];
            for (int i = 0; i < cols.Count; i++)
            {
                int wmax = (int)Math.Ceiling(gm.MeasureString(cols[i].HeaderText ?? "", headFont).Width);
                int sampled = 0;
                foreach (string[] r in rows)
                {
                    int wv = (int)Math.Ceiling(gm.MeasureString(r[i], cellFont).Width);
                    if (wv > wmax) wmax = wv;
                    if (++sampled >= 80) break;
                }
                widths[i] = Math.Min(maxW, Math.Max(minW, wmax + padX * 2));
            }

            int tableW = 0;
            foreach (int w in widths) tableW += w;

            int width = Math.Max(520, marginL + tableW + marginR);
            int height = marginT + titleH + headH + rows.Count * rowH + marginB;

            var bmp = new Bitmap(width, height);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
                g.Clear(Color.White);

                using var titleBrush = new SolidBrush(Color.FromArgb(31, 31, 34));
                g.DrawString(title, titleFont, titleBrush, marginL, marginT);

                int x0 = marginL;
                int y = marginT + titleH;

                using var headBg = new SolidBrush(Color.FromArgb(31, 138, 154));
                using var headBrush = new SolidBrush(Color.White);
                using var cellBrush = new SolidBrush(Color.FromArgb(40, 40, 46));
                using var altBg = new SolidBrush(Color.FromArgb(244, 247, 248));
                using var linePen = new Pen(Color.FromArgb(223, 226, 229));
                using var fmt = new StringFormat
                {
                    Trimming = StringTrimming.EllipsisCharacter,
                    FormatFlags = StringFormatFlags.NoWrap,
                    LineAlignment = StringAlignment.Center,
                };

                g.FillRectangle(headBg, x0, y, tableW, headH);
                int cx = x0;
                for (int i = 0; i < cols.Count; i++)
                {
                    g.DrawString(cols[i].HeaderText, headFont, headBrush,
                        new RectangleF(cx + padX, y, widths[i] - padX * 2, headH), fmt);
                    cx += widths[i];
                }
                y += headH;

                for (int r = 0; r < rows.Count; r++)
                {
                    if (r % 2 == 1) g.FillRectangle(altBg, x0, y, tableW, rowH);
                    cx = x0;
                    for (int i = 0; i < cols.Count; i++)
                    {
                        g.DrawString(rows[r][i], cellFont, cellBrush,
                            new RectangleF(cx + padX, y, widths[i] - padX * 2, rowH), fmt);
                        cx += widths[i];
                    }
                    g.DrawLine(linePen, x0, y, x0 + tableW, y);
                    y += rowH;
                }

                g.DrawRectangle(linePen, x0, marginT + titleH, tableW, headH + rows.Count * rowH);
            }
            return bmp;
        }

        // ----- Trình ghi PDF tối giản: 1 trang A4, nhúng ảnh JPEG -----

        private static void WriteImagePdf(string path, Bitmap bmp)
        {
            byte[] jpeg = EncodeJpeg(bmp, 85L);
            int iw = bmp.Width, ih = bmp.Height;

            const double pageW = 595.0, pageH = 842.0; // A4 theo điểm (1/72 inch)
            double scale = Math.Min(pageW / iw, pageH / ih);
            double dispW = iw * scale, dispH = ih * scale;
            double offX = (pageW - dispW) / 2.0;
            double offY = (pageH - dispH) / 2.0;

            byte[] content = Encoding.ASCII.GetBytes(string.Format(CultureInfo.InvariantCulture,
                "q\n{0:0.##} 0 0 {1:0.##} {2:0.##} {3:0.##} cm\n/Im0 Do\nQ\n", dispW, dispH, offX, offY));

            var off = new long[6];
            using var fs = new FileStream(path, FileMode.Create, FileAccess.Write);

            void Ascii(string s)
            {
                byte[] b = Encoding.ASCII.GetBytes(s);
                fs.Write(b, 0, b.Length);
            }

            Ascii("%PDF-1.4\n");

            off[1] = fs.Position;
            Ascii("1 0 obj\n<< /Type /Catalog /Pages 2 0 R >>\nendobj\n");

            off[2] = fs.Position;
            Ascii("2 0 obj\n<< /Type /Pages /Kids [3 0 R] /Count 1 >>\nendobj\n");

            off[3] = fs.Position;
            Ascii(string.Format(CultureInfo.InvariantCulture,
                "3 0 obj\n<< /Type /Page /Parent 2 0 R /MediaBox [0 0 {0:0.##} {1:0.##}] " +
                "/Resources << /XObject << /Im0 4 0 R >> >> /Contents 5 0 R >>\nendobj\n", pageW, pageH));

            off[4] = fs.Position;
            Ascii($"4 0 obj\n<< /Type /XObject /Subtype /Image /Width {iw} /Height {ih} " +
                  $"/ColorSpace /DeviceRGB /BitsPerComponent 8 /Filter /DCTDecode /Length {jpeg.Length} >>\nstream\n");
            fs.Write(jpeg, 0, jpeg.Length);
            Ascii("\nendstream\nendobj\n");

            off[5] = fs.Position;
            Ascii($"5 0 obj\n<< /Length {content.Length} >>\nstream\n");
            fs.Write(content, 0, content.Length);
            Ascii("endstream\nendobj\n");

            long xref = fs.Position;
            var sb = new StringBuilder();
            sb.Append("xref\n0 6\n0000000000 65535 f \n");
            for (int i = 1; i <= 5; i++)
                sb.Append(off[i].ToString("0000000000", CultureInfo.InvariantCulture)).Append(" 00000 n \n");
            sb.Append("trailer\n<< /Size 6 /Root 1 0 R >>\nstartxref\n")
              .Append(xref.ToString(CultureInfo.InvariantCulture)).Append("\n%%EOF\n");
            Ascii(sb.ToString());
        }

        private static byte[] EncodeJpeg(Bitmap bmp, long quality)
        {
            ImageCodecInfo? enc = null;
            foreach (ImageCodecInfo c in ImageCodecInfo.GetImageEncoders())
                if (c.FormatID == ImageFormat.Jpeg.Guid) { enc = c; break; }

            using var ms = new MemoryStream();
            if (enc != null)
            {
                using var ps = new EncoderParameters(1);
                ps.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, quality);
                bmp.Save(ms, enc, ps);
            }
            else
            {
                bmp.Save(ms, ImageFormat.Jpeg);
            }
            return ms.ToArray();
        }

        // ----- Tiện ích tên file / tên sheet -----

        private static string SafeFileName(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) return "BaoCao";
            foreach (char c in Path.GetInvalidFileNameChars())
                name = name.Replace(c, '_');
            return name.Trim();
        }

        private static string SheetName(string title)
        {
            string s = title ?? "Báo cáo";
            foreach (char c in new[] { ':', '\\', '/', '?', '*', '[', ']' })
                s = s.Replace(c, ' ');
            s = s.Trim();
            if (s.Length == 0) s = "Báo cáo";
            return s.Length > 31 ? s[..31] : s;
        }
    }
}
