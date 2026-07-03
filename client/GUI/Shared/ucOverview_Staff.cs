using BUS;
using DTO;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class ucOverview_Staff : UserControl
    {
        private readonly NotificationFeed _feed;
        private int _unread, _workingDays, _lateCount, _daysOffRemaining, _pendingLeave, _usedLeave;

        public ucOverview_Staff()
        {
            InitializeComponent();
            _feed = new NotificationFeed(lstNotifications, lblNotifTitle);
            btnRefreshFeed.Click += (s, e) => _ = LoadRealData();
            this.Load += (s, e) => _ = LoadRealData();

            btnDetailMsg.Click += (s, e) =>
                MsgBox.Show(MsgBox.OwnerWindow(this),
                    $"Bạn có {_unread} thông báo chưa đọc.\nHãy mở Chat / Thông báo để xem chi tiết.",
                    "Thông báo", MsgBox.MessageBoxType.Info);

            btnDetailWorkingDays.Click += (s, e) =>
                MsgBox.Show(MsgBox.OwnerWindow(this),
                    $"Tháng này bạn đã đi làm {_workingDays} ngày.\n• Đi muộn: {_lateCount} lần",
                    "Ngày công", MsgBox.MessageBoxType.Info);

            btnDetailDaysOff.Click += (s, e) =>
                MsgBox.Show(MsgBox.OwnerWindow(this),
                    $"Nghỉ phép còn lại: {_daysOffRemaining} ngày\n• Đã dùng: {_usedLeave} ngày\n• Chờ duyệt: {_pendingLeave} đơn",
                    "Ngày nghỉ", MsgBox.MessageBoxType.Info);
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

        private async Task LoadRealData()
        {
            string myId = GlobalSession.CurrentUser?.EmployeeId ?? "";
            var items = new List<NotificationFeed.Item>();
            _unread = _workingDays = _lateCount = _pendingLeave = _usedLeave = 0;

            try
            {
                var notifs = await NotificationBUS.GetAll();
                foreach (var n in notifs.Values.Where(x => x.ReceiverId == myId)
                                               .OrderByDescending(x => x.Timestamp).Take(30))
                {
                    if (!n.IsRead) _unread++;
                    items.Add(new NotificationFeed.Item
                    {
                        Icon = IconFor(n.Type),
                        Time = n.Timestamp > 0 ? DateTimeOffset.FromUnixTimeMilliseconds(n.Timestamp).LocalDateTime.ToString("HH:mm") : "",
                        Text = n.Content ?? "",
                        IsRead = n.IsRead
                    });
                }

                var att = await AttendanceBUS.GetAll();
                foreach (var a in att.Values.Where(x => x.EmployeeId == myId))
                {
                    if (!DateTime.TryParse(a.Date, out var d)) continue;
                    if (d.Month != DateTime.Now.Month || d.Year != DateTime.Now.Year) continue;
                    if (a.Status != "nghi_phep") _workingDays++;
                    if (a.Status == "di_muon") _lateCount++;
                }

                var leaves = await LeaveRequestBUS.GetAll();
                foreach (var l in leaves.Values.Where(x => x.EmployeeId == myId))
                {
                    if (l.Status == "cho_duyet") _pendingLeave++;
                    if (l.Status == "da_duyet" &&
                        DateTime.TryParseExact(l.FromDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out var fd)
                        && fd.Year == DateTime.Now.Year)
                        _usedLeave += l.DayCount;
                }
            }
            catch { /* offline */ }

            _daysOffRemaining = Math.Max(0, 12 - _usedLeave);

            lblUnreadMsgValue.Text   = $"{_unread} tin";
            lblWorkingDaysValue.Text = $"{_workingDays} ngày";
            lblDaysOffValue.Text     = $"{_daysOffRemaining} ngày";

            if (items.Count == 0)
                items.Add(new NotificationFeed.Item { Icon = "🔔", Time = "", Text = "Chưa có thông báo mới." });
            _feed.SetItems(items);
        }
    }
}
