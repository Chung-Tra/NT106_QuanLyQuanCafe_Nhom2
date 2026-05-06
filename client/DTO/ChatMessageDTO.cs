using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DTO
{
    public class TinNhanChatDTO
    {
        [JsonPropertyName("nguoi_gui_id")] // Ánh xạ với tên trên Firebase
        public string? SenderId { get; set; }

        [JsonPropertyName("noi_dung")]
        public string? Message { get; set; }

        [JsonPropertyName("thoi_gian")]
        public long Timestamp { get; set; }

        [JsonPropertyName("loai_tin_nhan")]
        public string? MessageType { get; set; } = "text";
    }

    public class ChatMessageDTO : TinNhanChatDTO
    {
    }
}
    