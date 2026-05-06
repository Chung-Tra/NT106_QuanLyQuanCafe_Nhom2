using Newtonsoft.Json;

namespace DTO
{
    /// <summary>
    /// Ánh xạ node Firebase: /thong_bao/{tb_id}
    /// </summary>
    public class NotificationDTO
    {
        [JsonIgnore]
        public string? ThongBaoId { get; set; }

        [JsonProperty("loai")]
        public string? Loai { get; set; }  // "don_moi", "xin_nghi", "sua_nguyen_lieu", "feedback_xau", "cham_cong", "sos"

        [JsonProperty("noi_dung")]
        public string? NoiDung { get; set; }

        [JsonProperty("nguoi_nhan_id")]
        public string? NguoiNhanId { get; set; }

        [JsonProperty("nguoi_gui_id")]
        public string? NguoiGuiId { get; set; }

        [JsonProperty("thoi_gian")]
        public long ThoiGian { get; set; }

        [JsonProperty("da_doc")]
        public bool DaDoc { get; set; }

        [JsonProperty("don_hang_id")]
        public string? DonHangId { get; set; }

        [JsonProperty("trang_lien_quan")]
        public string? TrangLienQuan { get; set; }  // "leave", "stock", "feedback", "attendance", "order"
    }
}
