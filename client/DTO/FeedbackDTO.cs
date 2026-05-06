using Newtonsoft.Json;

namespace DTO
{
    /// <summary>
    /// Ánh xạ node Firebase: /feedback/{fb_id}
    /// Node MỚI — chưa có trong DB cũ
    /// </summary>
    public class PhanHoiDTO
    {
        [JsonIgnore]
        public string? FeedbackId { get; set; }

        [JsonProperty("ten_khach")]
        public string? TenKhach { get; set; }

        [JsonProperty("so_sao")]
        public int SoSao { get; set; }  // 1-5

        [JsonProperty("noi_dung")]
        public string? NoiDung { get; set; }

        [JsonProperty("thoi_gian")]
        public long ThoiGian { get; set; }

        [JsonProperty("da_xu_ly")]
        public bool DaXuLy { get; set; }

        [JsonProperty("nguoi_xu_ly_id")]
        public string? NguoiXuLyId { get; set; }

        [JsonProperty("phan_hoi")]
        public string? PhanHoi { get; set; }  // Nội dung trả lời từ QL

        [JsonProperty("thoi_gian_phan_hoi")]
        public long ThoiGianPhanHoi { get; set; }

        [JsonProperty("don_hang_id")]
        public string? DonHangId { get; set; }  // Liên kết đơn hàng (nếu có)
    }

    public class FeedbackDTO : PhanHoiDTO
    {
    }
}
