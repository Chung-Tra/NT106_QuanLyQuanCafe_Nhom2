using BUS;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class ucOverview_Manager : UserControl
    {
        private readonly NotificationFeed _feed;

        public ucOverview_Manager()
        {
            InitializeComponent();
            _feed = new NotificationFeed(lstNotifications, lblNotifTitle);
            btnRefreshFeed.Click += (s, e) => _ = LoadFeed();
            this.Load += (s, e) => _ = LoadFeed();
        }

        private static string IconFor(string? type) => type switch
        {
            "sos" => "🚨",
            "feedback_xau" => "⚠️",
            "xin_nghi" => "📩",
            "don_moi" => "🛎️",
            "cham_cong" => "🕐",
            "sua_nguyen_lieu" => "📦",
            _ => "🔔"
        };

        private async Task LoadFeed()
        {
            string myId = GlobalSession.CurrentUser?.EmployeeId ?? "";
            var items = new List<NotificationFeed.Item>();
            try
            {
                var notifs = await NotificationBUS.GetAll();
                foreach (var n in notifs.Values
                    .Where(x => x.ReceiverId == myId)
                    .OrderByDescending(x => x.Timestamp)
                    .Take(30))
                {
                    items.Add(new NotificationFeed.Item
                    {
                        Icon = IconFor(n.Type),
                        Time = n.Timestamp > 0 ? DateTimeOffset.FromUnixTimeMilliseconds(n.Timestamp).LocalDateTime.ToString("HH:mm") : "",
                        Text = n.Content ?? "",
                        IsRead = n.IsRead
                    });
                }
            }
            catch { /* offline */ }

            if (items.Count == 0)
                items.Add(new NotificationFeed.Item { Icon = "🔔", Time = "", Text = "Chưa có thông báo mới." });

            _feed.SetItems(items);
        }

        private void lblNotifTitle_Click(object sender, EventArgs e) => _ = LoadFeed();

        private async void lblDailyRevValue_Click(object sender, EventArgs e)
        {
            try
            {
                var payments = await PaymentBUS.GetAll();
                decimal today = payments.Values
                    .Where(p => p.Timestamp > 0 &&
                                DateTimeOffset.FromUnixTimeMilliseconds(p.Timestamp).LocalDateTime.Date == DateTime.Today)
                    .Sum(p => p.ActualReceived);
                int count = payments.Values.Count(p => p.Timestamp > 0 &&
                    DateTimeOffset.FromUnixTimeMilliseconds(p.Timestamp).LocalDateTime.Date == DateTime.Today);
                MsgBox.Show(MsgBox.OwnerWindow(this),
                    $"Doanh thu hôm nay: {today:N0} đ\nSố hóa đơn: {count}",
                    "Doanh thu trong ngày", MsgBox.MessageBoxType.Info);
            }
            catch (Exception ex)
            {
                MsgBox.Show(MsgBox.OwnerWindow(this), "Không tải được doanh thu: " + ex.Message, "Lỗi", MsgBox.MessageBoxType.Error);
            }
        }
    }
}
