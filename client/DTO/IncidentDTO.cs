using Newtonsoft.Json;

namespace DTO
{
    /// <summary>
    /// Ánh xạ node Firebase: /su_co/{sc_id}
    /// Node MỚI — chưa có trong DB cũ
    /// </summary>
    public class IncidentDTO
    {
        [JsonIgnore]
        public string? Id { get; set; }

        [JsonProperty("loai_su_co")]
        public string? Type { get; set; }  // "an_ninh", "y_te", "chay_no", "sos_khan_cap"

        [JsonProperty("mo_ta")]
        public string? Description { get; set; }

        [JsonProperty("nguoi_bao_id")]
        public string? ReporterId { get; set; }

        [JsonProperty("thoi_gian")]
        public long Timestamp { get; set; }

        [JsonProperty("trang_thai")]
        public string? Status { get; set; }  // "dang_xu_ly", "da_xu_ly"

        [JsonProperty("ghi_chu_xu_ly")]
        public string? HandleNote { get; set; }

        [JsonProperty("muc_do")]
        public string? Severity { get; set; }  // "thuong", "khan_cap", "nghiem_trong"
    }
}
