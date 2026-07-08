using BUS;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
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
            // Click đánh dấu đã đọc trong feed -> lưu xuống Firebase để không mất khi làm mới
            _feed.ItemMarkedRead += it =>
            {
                if (!string.IsNullOrEmpty(it.Id))
                    _ = NotificationBUS.Update(it.Id, new { da_doc = true });
            };
            btnRefreshFeed.Click += (s, e) => _ = RefreshAll();
            this.Load += (s, e) => _ = RefreshAll();
        }

        private async Task RefreshAll()
        {
            await LoadStats();
            await LoadFeed();
        }

        private static string IconFor(string? type) => type switch
        {
            "sos" => "🚨",
            "feedback_xau" => "⚠️",
            "xin_nghi" => "📩",
            "don_moi" => "🛎️",
            "cham_cong" => "🕐",
            "sua_nguyen_lieu" => "📦",
            "tin_nhan" => "💬",
            _ => "🔔"
        };

        private async Task LoadStats()
        {
            decimal todayRev = 0, monthRev = 0;
            int todayGood = 0, monthGood = 0;
            var today = DateTime.Today;

            try
            {
                foreach (var p in (await PaymentBUS.GetAll()).Values.Where(p => p.Timestamp > 0))
                {
                    var d = DateTimeOffset.FromUnixTimeMilliseconds(p.Timestamp).LocalDateTime;
                    if (d.Date == today) todayRev += p.ActualReceived;
                    if (d.Month == today.Month && d.Year == today.Year) monthRev += p.ActualReceived;
                }

                foreach (var f in (await FeedbackBUS.GetAll()).Values.Where(f => f.Timestamp > 0 && f.Rating >= 4))
                {
                    var d = DateTimeOffset.FromUnixTimeMilliseconds(f.Timestamp).LocalDateTime;
                    if (d.Date == today) todayGood++;
                    if (d.Month == today.Month && d.Year == today.Year) monthGood++;
                }
            }
            catch { /* offline */ }

            lblDailyRevValue.Text = Theme.Vnd((long)todayRev);
            lblMonthlyRevValue.Text = Theme.Vnd((long)monthRev);
            lblDailyFeedValue.Text = todayGood.ToString();
            lblMonthlyFeedValue.Text = monthGood.ToString();
        }

        private async Task LoadFeed()
        {
            string myId = GlobalSession.CurrentUser?.EmployeeId ?? "";
            var items = new List<NotificationFeed.Item>();
            try
            {
                var notifs = await NotificationBUS.GetAll();
                foreach (var kv in notifs
                    .Where(x => x.Value.ReceiverId == myId)
                    .OrderByDescending(x => x.Value.Timestamp)
                    .Take(30))
                {
                    var n = kv.Value;
                    items.Add(new NotificationFeed.Item
                    {
                        Id = kv.Key,
                        Icon = IconFor(n.Type),
                        Time = n.Timestamp > 0 ? DateTimeOffset.FromUnixTimeMilliseconds(n.Timestamp).LocalDateTime.ToString("HH:mm") : "",
                        Text = n.Content ?? "",
                        IsRead = n.IsRead
                    });
                }
            }
            catch { /* offline */ }

            if (items.Count == 0)
                items.Add(new NotificationFeed.Item { Icon = "🔔", Time = "", Text = "Chưa có thông báo mới.", IsRead = true });

            _feed.SetItems(items);
        }

        private void lblNotifTitle_Click(object sender, EventArgs e) => _ = RefreshAll();

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
