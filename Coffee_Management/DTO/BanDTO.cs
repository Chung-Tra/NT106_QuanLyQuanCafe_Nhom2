using Newtonsoft.Json;

namespace DTO
{
    /// <summary>
    /// Ánh xạ node Firebase: /ban/{ban_id}
    /// </summary>
    public class BanDTO
    {
        [JsonIgnore]
        public string? BanId { get; set; }

        [JsonProperty("ten_ban")]
        public string? TenBan { get; set; }

        [JsonProperty("so_cho")]
        public int SoCho { get; set; }

        [JsonProperty("trang_thai")]
        public string? TrangThai { get; set; }  // "trong", "co_khach", "dat_truoc"

        [JsonProperty("vi_tri")]
        public string? ViTri { get; set; }
    }
}
