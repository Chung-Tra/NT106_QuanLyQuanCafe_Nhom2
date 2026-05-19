using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace GUI
{
    /// <summary>
    /// Bo góc form (FormBorderStyle.None). Gọi 1 dòng trong constructor:
    ///   FormCorners.Round(this);
    /// </summary>
    internal static class FormCorners
    {
        public static void Round(Form form, int radius = 18)
        {
            ApplyRegion(form, radius);
            form.Resize += (s, e) => ApplyRegion(form, radius);
            form.HandleCreated += (s, e) => ApplyRegion(form, radius);
        }

        private static void ApplyRegion(Form form, int radius)
        {
            if (form.IsDisposed || form.ClientSize.Width < 10 || form.ClientSize.Height < 10)
                return;

            form.Region?.Dispose();
            form.Region = BuildRegion(form.ClientRectangle, radius);
        }

        private static Region BuildRegion(Rectangle bounds, float radius)
        {
            using GraphicsPath path = CreateRoundRect(bounds, radius);
            return new Region(path);
        }

        private static GraphicsPath CreateRoundRect(Rectangle b, float r)
        {
            float diameter = Math.Min(Math.Min(Math.Abs(r) * 2, b.Width), b.Height);
            var path = new GraphicsPath();

            RectangleF arc = new(b.X, b.Y, diameter, diameter);
            path.AddArc(arc, 180, 90);

            arc.X = b.Right - diameter;
            path.AddArc(arc, 270, 90);

            arc.Y = b.Bottom - diameter;
            path.AddArc(arc, 0, 90);

            arc.X = b.X;
            path.AddArc(arc, 90, 90);
            path.CloseFigure();
            return path;
        }
    }
}
