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
                MsgBox.Show("Bạn có 5 tin nhắn chưa đọc trong Chat nội bộ.\nHãy mở Chat để xem chi tiết.", "Tin nhắn", MsgBox.MessageBoxType.Info);

            btnDetailWorkingDays.Click += (s, e) =>
                MsgBox.Show("Tháng này bạn đã đi làm 23/26 ngày.\n• Đủ giờ: 21 ngày\n• Đi muộn: 2 lần\n• Tăng ca: 1 ngày", "Ngày công", MsgBox.MessageBoxType.Info);

            btnDetailDaysOff.Click += (s, e) =>
                MsgBox.Show("Nghỉ phép còn lại: 7 ngày\n• Đã dùng: 5 ngày\n• Chờ duyệt: 1 đơn", "Ngày nghỉ", MsgBox.MessageBoxType.Info);
        }

        private void LoadMockData()
        {
            lblUnreadMsgValue.Text = "5 tin";
            lblWorkingDaysValue.Text = "23 ngày";
            lblDaysOffValue.Text = "7 ngày";
        }
    }
}
