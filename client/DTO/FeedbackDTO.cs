using Newtonsoft.Json;

namespace DTO
{
    /// <summary>
    /// Ánh xạ node Firebase: /feedback/{fb_id}
    /// Node MỚI — chưa có trong DB cũ
    /// </summary>
    public class FeedbackDTO
    {
        [JsonIgnore]
        public string? Id { get; set; }

        [JsonProperty("ten_khach")]
        public string? CustomerName { get; set; }

        [JsonProperty("so_sao")]
        public int Rating { get; set; }  // 1-5

        [JsonProperty("noi_dung")]
        public string? Content { get; set; }

        [JsonProperty("thoi_gian")]
        public long Timestamp { get; set; }

        [JsonProperty("da_xu_ly")]
        public bool IsHandled { get; set; }

        [JsonProperty("nguoi_xu_ly_id")]
        public string? HandlerId { get; set; }

        [JsonProperty("phan_hoi")]
        public string? Reply { get; set; }  // Nội dung trả lời từ QL

        [JsonProperty("thoi_gian_phan_hoi")]
        public long ReplyTime { get; set; }

        [JsonProperty("don_hang_id")]
        public string? OrderId { get; set; }  // Liên kết đơn hàng (nếu có)
    }
}
