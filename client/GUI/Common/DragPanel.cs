using Guna.UI2.WinForms;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace GUI
{
    internal class DragPanel : Guna2Panel
    {
        private Point _dragStart;
        private bool _dragging;

        private readonly Label _lblTitle;
        private readonly Guna2Button _btnClose;
        private readonly Panel _content;

        public DragPanel(string title, UserControl uc, Size size)
        {
            BackColor = Color.FromArgb(31, 31, 34);
            BorderRadius = 14;
            Size = size;

            // Title bar
            _lblTitle = new Label
            {
                Text = title,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                ForeColor = Color.White,
                AutoSize = true,
                Location = new Point(14, 10),
            };

            // Close button
            _btnClose = new Guna2Button
            {
                Text = "✕",
                Size = new Size(28, 28),
                FillColor = Color.Transparent,
                ForeColor = Color.FromArgb(160, 160, 166),
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                BorderRadius = 6,
                Cursor = Cursors.Hand,
                Location = new Point(size.Width - 38, 6),
                Anchor = AnchorStyles.Top | AnchorStyles.Right,
            };
            _btnClose.HoverState.FillColor = Color.FromArgb(180, 60, 60);
            _btnClose.HoverState.ForeColor = Color.White;
            _btnClose.Click += (s, e) => this.Visible = false;

            // Content area
            _content = new Panel
            {
                BackColor = Color.Transparent,
                Location = new Point(0, 40),
                Size = new Size(size.Width, size.Height - 40),
                Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right,
            };

            uc.Dock = DockStyle.Fill;
            _content.Controls.Add(uc);

            Controls.Add(_lblTitle);
            Controls.Add(_btnClose);
            Controls.Add(_content);

            // Drag via title bar
            _lblTitle.MouseDown += StartDrag;
            _lblTitle.MouseMove += DoDrag;
            _lblTitle.MouseUp   += StopDrag;
            MouseDown += StartDrag;
            MouseMove += DoDrag;
            MouseUp   += StopDrag;
        }

        private void StartDrag(object? s, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            _dragging = true;
            _dragStart = e.Location;
            if (s is Control c && c != this)
                _dragStart = c.PointToClient(this.PointToClient(c.PointToScreen(e.Location)));
            BringToFront();
        }

        private void DoDrag(object? s, MouseEventArgs e)
        {
            if (!_dragging) return;
            Point screenPos = (s is Control c && c != this)
                ? c.PointToScreen(e.Location)
                : this.PointToScreen(e.Location);

            Point parentPos = Parent?.PointToClient(screenPos) ?? screenPos;
            Location = new Point(parentPos.X - _dragStart.X, parentPos.Y - _dragStart.Y);
        }

        private void StopDrag(object? s, MouseEventArgs e) => _dragging = false;

        // Tiện ích: tạo và thêm vào parent
        public static DragPanel Create(Control parent, string title, UserControl uc,
            Size size, Point location)
        {
            var panel = new DragPanel(title, uc, size) { Location = location };
            parent.Controls.Add(panel);
            panel.BringToFront();
            return panel;
        }
    }
}
