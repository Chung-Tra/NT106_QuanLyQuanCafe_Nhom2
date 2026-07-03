using System;
using System.Drawing;
using System.Windows.Forms;

namespace GUI
{
    public partial class ucOverview_Staff : UserControl
    {
        private readonly NotificationFeed _feed;
        private bool _simulatedIncoming;

        public ucOverview_Staff()
        {
            InitializeComponent();

            // Bảng tin: chưa đọc xếp trước + click để đánh dấu đã đọc (helper dùng chung)
            _feed = new NotificationFeed(lstNotifications, lblNotifTitle);
            btnRefreshFeed.Click += (s, e) => RefreshFeed();

            this.Load += (s, e) => LoadMockData();

            btnDetailMsg.Click += (s, e) =>
                MsgBox.Show(
                    MsgBox.OwnerWindow(this),
                    "Bạn có 5 tin nhắn chưa đọc trong Chat nội bộ.\nHãy mở Chat để xem chi tiết.",
                    "Tin nhắn", MsgBox.MessageBoxType.Info);

            btnDetailWorkingDays.Click += (s, e) =>
                MsgBox.Show(
                    MsgBox.OwnerWindow(this),
                    "Tháng này bạn đã đi làm 23/26 ngày.\n• Đủ giờ: 21 ngày\n• Đi muộn: 2 lần\n• Tăng ca: 1 ngày",
                    "Ngày công", MsgBox.MessageBoxType.Info);

            btnDetailDaysOff.Click += (s, e) =>
                MsgBox.Show(
                    MsgBox.OwnerWindow(this),
                    "Nghỉ phép còn lại: 7 ngày\n• Đã dùng: 5 ngày\n• Chờ duyệt: 1 đơn",
                    "Ngày nghỉ", MsgBox.MessageBoxType.Info);
        }

        private void LoadMockData()
        {
            lblUnreadMsgValue.Text    = "5 tin";
            lblWorkingDaysValue.Text  = "23 ngày";
            lblDaysOffValue.Text      = "7 ngày";

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
                    Text = "Lịch ca tuần sau đã được xếp — kiểm tra mục Chọn ca / Đổi ca.",
                });
            }
        }
    }
}
