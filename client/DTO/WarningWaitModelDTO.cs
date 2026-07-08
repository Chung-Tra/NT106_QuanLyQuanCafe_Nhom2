using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class WarningWaitModelDTO
    {
        // Định vị món trong DB để double-click đánh dấu "đã lên món" thật (không chỉ xoá trên UI)
        public string? OrderId { get; set; }
        public string? ItemKey { get; set; }

        public string? TableName { get; set; }
        public string? DrinkName { get; set; }
        public int WaitTimeMinutes { get; set; }

        // Số phút thô hàng nghìn (vd 7699 phút) không đọc được — quy về ngày/giờ/phút.
        public static string FormatWait(int minutes)
        {
            if (minutes < 60) return $"{minutes} phút";
            if (minutes < 24 * 60)
            {
                int h = minutes / 60, m = minutes % 60;
                return m > 0 ? $"{h} giờ {m} phút" : $"{h} giờ";
            }
            int d = minutes / (24 * 60), hh = minutes % (24 * 60) / 60;
            return hh > 0 ? $"{d} ngày {hh} giờ" : $"{d} ngày";
        }

        public string DisplayText
        {
            get
            {
                if (WaitTimeMinutes >= 20)
                {
                    return $"🔥 {TableName}: {DrinkName} (Đợi {FormatWait(WaitTimeMinutes)} - Quá lâu!)";
                }
                return $"⚠️ {TableName}: {DrinkName} (Đợi {FormatWait(WaitTimeMinutes)})";
            }
        }
    }
}
