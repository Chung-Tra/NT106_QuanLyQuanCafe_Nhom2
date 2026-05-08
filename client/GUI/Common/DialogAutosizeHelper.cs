using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace GUI
{
    /// <summary>
    /// Chiều cao ô nhập / form theo độ dài nội dung (WordWrap); form scroll khi cao quá màn hình.
    /// </summary>
    internal static class DialogAutosizeHelper
    {
        private static readonly TextFormatFlags WrapFlags =
            TextFormatFlags.WordBreak | TextFormatFlags.TextBoxControl | TextFormatFlags.NoPadding;

        internal static int MeasureWrappedHeight(string text, Font font, int contentWidthPx)
        {
            if (contentWidthPx <= 0) contentWidthPx = 200;
            if (string.IsNullOrEmpty(text))
                text = " ";

            string sample = text + "\n";
            Size sz = TextRenderer.MeasureText(sample, font, new Size(contentWidthPx, int.MaxValue), WrapFlags);
            return Math.Max(sz.Height + 10, TextRenderer.MeasureText("Mg", font).Height + 8);
        }

        /// <summary>Với nội dung dài: khóa chiều cao tối đa và bật scrollbar trên TextBox.</summary>
        internal static void SetWrappedTextBoxHeight(TextBox tb, int minHeight, int maxHeight)
        {
            int w = tb.ClientSize.Width > 0 ? tb.ClientSize.Width : tb.Width - SystemInformation.VerticalScrollBarWidth;
            int contentH = MeasureWrappedHeight(tb.Text, tb.Font, w);
            if (contentH > maxHeight)
            {
                tb.Height = maxHeight;
                tb.ScrollBars = ScrollBars.Vertical;
            }
            else
            {
                tb.Height = Math.Max(minHeight, contentH);
                if (tb.Multiline)
                    tb.ScrollBars = ScrollBars.None;
            }
        }

        /// <summary>Giới hạn chiều cao form; phần layout dài hơn được cuộn bằng thanh dọc của form.</summary>
        internal static void CapFormHeightWithAutoScroll(Form form, int layoutBottomY, int preferredWidth, int maxClientHeight)
        {
            preferredWidth = Math.Max(preferredWidth, 320);
            layoutBottomY += 6;

            if (layoutBottomY <= maxClientHeight)
            {
                form.AutoScroll = false;
                form.AutoScrollMinSize = Size.Empty;
                form.ClientSize = new Size(preferredWidth, layoutBottomY);
                return;
            }

            form.SuspendLayout();
            try
            {
                form.AutoScrollMinSize = new Size(preferredWidth, layoutBottomY);
                form.AutoScroll = true;
                form.HorizontalScroll.Enabled = false;
                form.HorizontalScroll.Visible = false;
                form.ClientSize = new Size(preferredWidth, maxClientHeight);
            }
            finally
            {
                form.ResumeLayout(true);
            }
        }

        internal static int MaxDialogClientHeight(Form form, int marginPx = 96)
        {
            try
            {
                Screen s = Screen.FromControl(form);
                return Math.Max(360, s.WorkingArea.Height - marginPx);
            }
            catch
            {
                int h = Screen.PrimaryScreen?.WorkingArea.Height ?? 800;
                return Math.Max(360, h - marginPx);
            }
        }
    }
}
