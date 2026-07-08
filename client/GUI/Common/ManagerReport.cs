using BUS;
using DTO;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace GUI
{
    // Gửi báo cáo vận hành tới MỌI quản lý + admin qua node thong_bao (NotificationBUS)
    // — hiện trong feed "Thông báo" của họ. Dùng cho các nút "Gửi báo cáo cho quản lý"
    // (trước đây các nút này chỉ MsgBox "Đã gửi!" mà không ghi gì vào DB).
    internal static class ManagerReport
    {
        public static async Task<(bool ok, string msg)> SendAsync(string content, string type = "bao_cao", string? relatedPage = null)
        {
            var me = GlobalSession.CurrentUser;
            var managers = (await EmployeeBUS.GetAllEmployeesAsync())
                .Where(x => (x.Role ?? "").ToLower() is "manager" or "admin")
                .Where(x => x.EmployeeId != null && x.EmployeeId != me?.EmployeeId)
                .ToList();
            if (managers.Count == 0) return (false, "Không tìm thấy quản lý nào để gửi.");

            int sent = 0;
            foreach (var m in managers)
            {
                var (ok, _, _) = await NotificationBUS.Add(new NotificationDTO
                {
                    Type = type,
                    Content = content,
                    ReceiverId = m.EmployeeId,
                    SenderId = me?.EmployeeId,
                    Timestamp = DateTimeOffset.Now.ToUnixTimeMilliseconds(),
                    IsRead = false,
                    RelatedPage = relatedPage
                });
                if (ok) sent++;
            }
            return sent > 0
                ? (true, $"Đã gửi báo cáo tới {sent} quản lý (xem ở mục Thông báo).")
                : (false, "Gửi báo cáo thất bại (kiểm tra server).");
        }
    }
}
