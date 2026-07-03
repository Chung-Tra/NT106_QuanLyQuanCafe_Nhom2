using Newtonsoft.Json;

namespace DTO
{
    /// <summary>
    /// Ánh xạ node Firebase: /thong_bao/{tb_id}
    /// </summary>
    public class NotificationDTO
    {
        [JsonIgnore]
        public string? Id { get; set; }

        [JsonProperty("loai")]
        public string? Type { get; set; }  // "don_moi", "xin_nghi", "sua_nguyen_lieu", "feedback_xau", "cham_cong", "sos"

        [JsonProperty("noi_dung")]
        public string? Content { get; set; }

        [JsonProperty("nguoi_nhan_id")]
        public string? ReceiverId { get; set; }

        [JsonProperty("nguoi_gui_id")]
        public string? SenderId { get; set; }

        [JsonProperty("thoi_gian")]
        public long Timestamp { get; set; }

        [JsonProperty("da_doc")]
        public bool IsRead { get; set; }

        [JsonProperty("don_hang_id")]
        public string? OrderId { get; set; }

        [JsonProperty("trang_lien_quan")]
        public string? RelatedPage { get; set; }  // "leave", "stock", "feedback", "attendance", "order"
    }
}
