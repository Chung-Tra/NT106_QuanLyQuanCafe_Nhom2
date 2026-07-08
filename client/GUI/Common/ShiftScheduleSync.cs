using BUS;
using DTO;
using System;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace GUI
{
    // Cầu nối "đăng ký/đổi ca" (node dang_ky_ca) ↔ "lịch tuần" (node lich_lam_viec):
    // khi quản lý DUYỆT một yêu cầu ca, lịch tuần phải đổi theo — vì lịch tuần (qua chấm
    // công → chốt ngày công) là thứ quyết định tính lương.
    internal static class ShiftScheduleSync
    {
        // Ngày trong dang_ky_ca là chuỗi nhập/seed nhiều định dạng.
        public static bool TryParseDate(string? s, out DateTime date)
        {
            date = default;
            if (string.IsNullOrWhiteSpace(s)) return false;
            string[] formats = { "dd/MM/yyyy", "d/M/yyyy", "yyyy-MM-dd", "dd/MM", "d/M" };
            if (!DateTime.TryParseExact(s.Trim(), formats, CultureInfo.InvariantCulture,
                                        DateTimeStyles.None, out date)) return false;
            if (date.Year == 1) date = new DateTime(DateTime.Today.Year, date.Month, date.Day); // dạng thiếu năm
            return true;
        }

        // "Ca sáng (6–14h)" → "S", "Ca chiều" → "C", "Ca đêm/tối" → "N" (mã ô lịch tuần).
        public static string? ShiftCode(string? ca)
        {
            string s = (ca ?? "").ToLowerInvariant();
            if (s.Contains("sáng")) return "S";
            if (s.Contains("chiều")) return "C";
            if (s.Contains("đêm") || s.Contains("tối")) return "N";
            return null;
        }

        private static DateTime Monday(DateTime d)
        {
            int dow = (int)d.DayOfWeek;
            return d.AddDays(-(dow == 0 ? 6 : dow - 1)).Date;
        }

        private static string DayField(DateTime d) => ((int)d.DayOfWeek) switch
        {
            1 => "t2", 2 => "t3", 3 => "t4", 4 => "t5", 5 => "t6", 6 => "t7", _ => "cn",
        };

        private static string? DayValue(ScheduleDTO s, DateTime d) => ((int)d.DayOfWeek) switch
        {
            1 => s.T2, 2 => s.T3, 3 => s.T4, 4 => s.T5, 5 => s.T6, 6 => s.T7, _ => s.CN,
        };

        // Gán ca cho nhân viên vào đúng ô (tuần, thứ) — tạo dòng lịch tuần nếu chưa có.
        public static async Task<(bool ok, string msg)> AssignAsync(string empId, string empName, DateTime date, string code)
        {
            string week = Monday(date).ToString("dd/MM/yyyy");
            var all = await ScheduleBUS.GetAll();
            var row = all.FirstOrDefault(x => x.Value.Tuan == week && x.Value.EmployeeId == empId);

            if (row.Key != null)
                return await ScheduleBUS.Update(row.Key, new System.Collections.Generic.Dictionary<string, object>
                {
                    [DayField(date)] = code
                });

            var dto = new ScheduleDTO { EmployeeId = empId, Ten = empName, Tuan = week };
            switch (DayField(date))
            {
                case "t2": dto.T2 = code; break;
                case "t3": dto.T3 = code; break;
                case "t4": dto.T4 = code; break;
                case "t5": dto.T5 = code; break;
                case "t6": dto.T6 = code; break;
                case "t7": dto.T7 = code; break;
                default: dto.CN = code; break;
            }
            var (ok, msg, _) = await ScheduleBUS.Add(dto);
            return (ok, msg);
        }

        // Bỏ ca của nhân viên tại ô (tuần, thứ) — chỉ xoá khi ô đang đúng mã ca đó
        // (tránh xoá nhầm ca khác nếu lịch đã bị sửa tay sau khi gửi yêu cầu).
        public static async Task<(bool ok, string msg)> ClearAsync(string empId, DateTime date, string code)
        {
            string week = Monday(date).ToString("dd/MM/yyyy");
            var all = await ScheduleBUS.GetAll();
            var row = all.FirstOrDefault(x => x.Value.Tuan == week && x.Value.EmployeeId == empId);
            if (row.Key == null) return (true, "Chưa có dòng lịch — bỏ qua");
            if (DayValue(row.Value, date) != code) return (true, "Ô lịch đã khác mã ca — giữ nguyên");

            return await ScheduleBUS.Update(row.Key, new System.Collections.Generic.Dictionary<string, object>
            {
                [DayField(date)] = ""
            });
        }
    }
}
