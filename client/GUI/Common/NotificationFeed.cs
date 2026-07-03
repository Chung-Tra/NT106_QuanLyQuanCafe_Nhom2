using System.Drawing;
using System.Windows.Forms;

namespace GUI
{
    // Bảng tin & Thông báo (ListBox owner-draw) dùng chung cho các màn Tổng quan:
    //   • Tin CHƯA ĐỌC nổi bật (nền ánh teal, chữ đậm, chấm teal) và luôn xếp lên đầu.
    //   • Click 1 tin -> chuyển sang đã đọc (mờ đi, tụt xuống nhóm dưới).
    //   • Tiêu đề panel tự đếm "— N chưa đọc".
    // Control (ListBox, Label, nút Làm mới) vẫn khai ở Designer; class này chỉ gắn hành vi.
    public sealed class NotificationFeed
    {
        public sealed class Item
        {
            public string Icon = "🔔";
            public string Time = "";
            public string Text = "";
            public bool IsRead;
        }

        private readonly ListBox _lst;
        private readonly Label _title;
        private readonly string _baseTitle;
        private readonly List<Item> _items = new();
        private readonly Font _fontUnread = Theme.F(10F, FontStyle.Bold);
        private readonly Font _fontRead   = Theme.F(10F);

        public NotificationFeed(ListBox lst, Label title)
        {
            _lst = lst;
            _title = title;
            _baseTitle = title.Text;

            _lst.DrawMode      = DrawMode.OwnerDrawFixed;
            _lst.ItemHeight    = 34;
            _lst.SelectionMode = SelectionMode.None;
            _lst.Cursor        = Cursors.Hand;
            _lst.DrawItem  += OnDrawItem;
            _lst.MouseDown += OnMouseDown;
            new ToolTip().SetToolTip(_lst, "Click một tin để đánh dấu đã đọc");
        }

        public void SetItems(IEnumerable<Item> items)
        {
            _items.Clear();
            _items.AddRange(items);
            Render();
        }

        // Tin mới nhận (khi làm mới / realtime sau này): chèn lên đầu, mặc định chưa đọc
        public void AddIncoming(Item item)
        {
            _items.Insert(0, item);
            Render();
        }

        public int UnreadCount => _items.Count(i => !i.IsRead);

        // Chưa đọc trước, đã đọc sau; trong mỗi nhóm giữ nguyên thứ tự nguồn (OrderBy ổn định)
        private void Render()
        {
            _lst.BeginUpdate();
            _lst.Items.Clear();
            foreach (var it in _items.OrderBy(i => i.IsRead ? 1 : 0))
                _lst.Items.Add(it);
            _lst.EndUpdate();

            int unread = UnreadCount;
            _title.Text = unread > 0 ? $"{_baseTitle}  —  {unread} chưa đọc"
                                     : $"{_baseTitle}  —  đã đọc hết ✓";
        }

        private void OnMouseDown(object? sender, MouseEventArgs e)
        {
            int idx = _lst.IndexFromPoint(e.Location);
            if (idx < 0 || idx >= _lst.Items.Count) return;
            if (_lst.Items[idx] is Item it && !it.IsRead)
            {
                it.IsRead = true;
                Render();
            }
        }

        private void OnDrawItem(object? sender, DrawItemEventArgs e)
        {
            if (e.Index < 0 || e.Index >= _lst.Items.Count || _lst.Items[e.Index] is not Item it) return;
            bool unread = !it.IsRead;

            using (var bg = new SolidBrush(unread ? Theme.Fade(Theme.Teal, 26) : Theme.SurfaceAlt))
                e.Graphics.FillRectangle(bg, e.Bounds);

            // Chấm trạng thái bên trái
            using (var dot = new SolidBrush(unread ? Theme.Teal : Theme.Border))
                e.Graphics.FillEllipse(dot, e.Bounds.X + 8, e.Bounds.Y + e.Bounds.Height / 2 - 4, 8, 8);

            string text = $"{it.Icon}  [{it.Time}]  {it.Text}";
            TextRenderer.DrawText(
                e.Graphics, text,
                unread ? _fontUnread : _fontRead,
                new Rectangle(e.Bounds.X + 26, e.Bounds.Y, e.Bounds.Width - 30, e.Bounds.Height),
                unread ? Theme.TextHi : Theme.TextMuted,
                TextFormatFlags.VerticalCenter | TextFormatFlags.Left | TextFormatFlags.EndEllipsis);
        }
    }
}
