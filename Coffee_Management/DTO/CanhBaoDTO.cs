using Newtonsoft.Json;

namespace DTO
{
    /// <summary>
    /// Ánh xạ node Firebase: /canh_bao/{cb_id}
    /// Node MỚI — chưa có trong DB cũ
    /// Dùng cho Báo động Nguyên liệu (ucAlert_Barista)
    /// </summary>
    public class CanhBaoDTO
    {
        [JsonIgnore]
        public string? CanhBaoId { get; set; }

        [JsonProperty("loai")]
        public string? Loai { get; set; }  // "het_nguyen_lieu", "sap_het", "thiet_bi_hong", "khac"

        [JsonProperty("noi_dung")]
        public string? NoiDung { get; set; }

        [JsonProperty("nguoi_gui_id")]
        public string? NguoiGuiId { get; set; }

        [JsonProperty("thoi_gian")]
        public long ThoiGian { get; set; }

        [JsonProperty("trang_thai")]
        public string? TrangThai { get; set; }  // "cho_xu_ly", "da_xu_ly"

        [JsonProperty("nguyen_lieu_id")]
        public string? NguyenLieuId { get; set; }  // Liên kết NL bị ảnh hưởng (nếu có)
    }
}
