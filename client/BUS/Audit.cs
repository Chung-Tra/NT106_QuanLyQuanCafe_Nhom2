using DTO;
using System;

namespace BUS
{
    /// <summary>Ghi nhật ký thao tác (fire-and-forget) vào node nhat_ky.</summary>
    public static class Audit
    {
        public static async void Log(string thaoTac, string doiTuong, string lyDo = "")
        {
            try
            {
                var u = GlobalSession.CurrentUser;
                await AuditLogBUS.Add(new AuditLogDTO
                {
                    Timestamp = DateTimeOffset.Now.ToUnixTimeMilliseconds(),
                    EmployeeId = u?.EmployeeId,
                    Ten = u?.FullName,
                    VaiTro = RoleVi(u?.Role),
                    ThaoTac = thaoTac,
                    DoiTuong = doiTuong,
                    LyDo = lyDo,
                    Ip = ""
                });
            }
            catch { /* nhật ký là best-effort */ }
        }

        private static string RoleVi(string? r) => (r ?? "").ToLower() switch
        {
            "admin" => "Quản trị viên",
            "manager" => "Quản lý",
            "barista" => "Pha chế",
            "order staff" => "Nhân viên Order",
            "security" => "Bảo vệ",
            _ => r ?? ""
        };
    }
}
