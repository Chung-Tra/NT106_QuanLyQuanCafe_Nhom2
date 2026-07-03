using Newtonsoft.Json;

namespace DTO
{
    /// <summary>
    /// Ánh xạ node Firebase: /ban/{ban_id}
    /// </summary>
    public class TableDTO
    {
        [JsonIgnore]
        public string? Id { get; set; }

        [JsonProperty("ten_ban")]
        public string? Name { get; set; }

        [JsonProperty("so_cho")]
        public int Capacity { get; set; }

        [JsonProperty("trang_thai")]
        public string? Status { get; set; }  // "trong", "co_khach", "dat_truoc"

        [JsonProperty("vi_tri")]
        public string? Location { get; set; }
    }
}
