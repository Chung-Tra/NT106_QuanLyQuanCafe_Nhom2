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
        public string? SuCoId { get; set; }

        [JsonProperty("loai_su_co")]
        public string? LoaiSuCo { get; set; }  // "an_ninh", "y_te", "chay_no", "sos_khan_cap"

        [JsonProperty("mo_ta")]
        public string? MoTa { get; set; }

        [JsonProperty("nguoi_bao_id")]
        public string? NguoiBaoId { get; set; }

        [JsonProperty("thoi_gian")]
        public long ThoiGian { get; set; }

        [JsonProperty("trang_thai")]
        public string? TrangThai { get; set; }  // "dang_xu_ly", "da_xu_ly"

        [JsonProperty("ghi_chu_xu_ly")]
        public string? GhiChuXuLy { get; set; }

        [JsonProperty("muc_do")]
        public string? MucDo { get; set; }  // "thuong", "khan_cap", "nghiem_trong"
    }
}
