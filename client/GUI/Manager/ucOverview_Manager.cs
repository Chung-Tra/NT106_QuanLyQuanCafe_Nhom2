using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class ucOverview_Manager : UserControl
    {
        private readonly NotificationFeed _feed;
        private bool _simulatedIncoming;

        public ucOverview_Manager()
        {
            InitializeComponent();

            // Bảng tin: chưa đọc xếp trước + click để đánh dấu đã đọc (helper dùng chung)
            _feed = new NotificationFeed(lstNotifications, lblNotifTitle);
            btnRefreshFeed.Click += (s, e) => RefreshFeed();
            this.Load += (s, e) => LoadFeed();
        }

        private void LoadFeed()
        {
            _feed.SetItems(new[]
            {
                new NotificationFeed.Item { Icon = "🔴", Time = "08:30", Text = "Nhân viên phục vụ Nguyễn Văn A xin phép nghỉ ốm ngày hôm nay." },
                new NotificationFeed.Item { Icon = "⭐", Time = "09:15", Text = "Feedback Bàn số 5: \"Cà phê muối rất ngon, nhân viên nhiệt tình, 5 sao!\"" },
                new NotificationFeed.Item { Icon = "⚠️", Time = "10:00", Text = "Kho hàng cảnh báo: Hết nguyên liệu Sữa tươi, cần nhập gấp." },
                new NotificationFeed.Item { Icon = "⭐", Time = "11:20", Text = "Feedback Bàn số 12: \"Quán decor đẹp, đồ uống lên nhanh.\"", IsRead = true },
                new NotificationFeed.Item { Icon = "🟢", Time = "12:00", Text = "Quản lý đã duyệt đơn xin nghỉ của Nguyễn Văn A.", IsRead = true },
            });
        }

        // Làm mới bảng tin: khi có API thật thì fetch tại đây; mock mô phỏng nhận 1 tin mới
        private void RefreshFeed()
        {
            if (!_simulatedIncoming)
            {
                _simulatedIncoming = true;
                _feed.AddIncoming(new NotificationFeed.Item
                {
                    Icon = "📩",
                    Time = DateTime.Now.ToString("HH:mm"),
                    Text = "Đơn xin nghỉ mới của Trần Thị Bích đang chờ duyệt.",
                });
            }
        }

        private void lblNotifTitle_Click(object sender, EventArgs e)
        {

        }

        private void lblDailyRevValue_Click(object sender, EventArgs e)
        {

        }
    }
}
