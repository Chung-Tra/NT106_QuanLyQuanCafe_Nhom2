using Newtonsoft.Json;

namespace DTO
{
    /// <summary>
    /// Ánh xạ node Firebase: /canh_bao/{cb_id}
    /// Node MỚI — chưa có trong DB cũ
    /// Dùng cho Báo động Nguyên liệu (ucAlert_Barista)
    /// </summary>
    public class WarningDTO
    {
        [JsonIgnore]
        public string? Id { get; set; }

        [JsonProperty("loai")]
        public string? Type { get; set; }  // "het_nguyen_lieu", "sap_het", "thiet_bi_hong", "khac"

        [JsonProperty("noi_dung")]
        public string? Content { get; set; }

        [JsonProperty("nguoi_gui_id")]
        public string? SenderId { get; set; }

        [JsonProperty("thoi_gian")]
        public long Timestamp { get; set; }

        [JsonProperty("trang_thai")]
        public string? Status { get; set; }  // "cho_xu_ly", "da_xu_ly"

        [JsonProperty("nguyen_lieu_id")]
        public string? IngredientId { get; set; }  // Liên kết NL bị ảnh hưởng (nếu có)
    }
}
