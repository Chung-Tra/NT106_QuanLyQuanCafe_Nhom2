using System;
using System.Drawing;
using System.Windows.Forms;

namespace GUI
{
    public partial class ucOverview_Staff : UserControl
    {
        public ucOverview_Staff()
        {
            InitializeComponent();
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

            lstNotifications.Items.Clear();
            lstNotifications.Items.AddRange(new object[]
            {
                "🔴  [08:30]  Nhân viên phục vụ Nguyễn Văn A xin phép nghỉ ốm ngày hôm nay.",
                "⭐  [09:15]  Feedback Bàn số 5: \"Cà phê muối rất ngon, nhân viên nhiệt tình, 5 sao!\"",
                "⚠️  [10:00]  Kho hàng cảnh báo: Hết nguyên liệu Sữa tươi, cần nhập gấp.",
                "⭐  [11:20]  Feedback Bàn số 12: \"Quán decor đẹp, đồ uống lên nhanh.\"",
                "🟢  [12:00]  Quản lý đã duyệt đơn xin nghỉ của Nguyễn Văn A."
            });
        }
    }
}
