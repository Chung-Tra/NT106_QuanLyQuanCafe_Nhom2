using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class WarningWaitModelDTO
    {
        public string? TableName { get; set; }
        public string? DrinkName { get; set; }
        public int WaitTimeMinutes { get; set; }
        public string DisplayText
        {
            get
            {
                if (WaitTimeMinutes >= 20)
                {
                    return $"🔥 {TableName}: {DrinkName} (Đợi {WaitTimeMinutes} phút - Quá lâu!)";
                }
                return $"⚠️ {TableName}: {DrinkName} (Đợi {WaitTimeMinutes} phút)";
            }
        }
    }
}
