using Newtonsoft.Json;

namespace DTO
{
    /// <summary>
    /// Ánh xạ node Firebase: /danh_sach_chat/{nv_id}/{chat_key}
    /// </summary>
    public class ChatListDTO
    {
        [JsonIgnore]
        public string? ChatKey { get; set; }

        [JsonProperty("nguoi_nhan_id")]
        public string? NguoiNhanId { get; set; }

        [JsonProperty("tin_nhan_cuoi")]
        public string? TinNhanCuoi { get; set; }

        [JsonProperty("thoi_gian_cuoi")]
        public long ThoiGianCuoi { get; set; }

        [JsonProperty("da_doc")]
        public bool DaDoc { get; set; }
    }
}
