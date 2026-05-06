using Newtonsoft.Json;

namespace DTO
{
    /// <summary>
    /// Ánh xạ node Firebase: /thanh_toan/{tt_id}
    /// </summary>
    public class PaymentDTO
    {
        [JsonIgnore]
        public string? ThanhToanId { get; set; }

        [JsonProperty("don_hang_id")]
        public string? DonHangId { get; set; }

        [JsonProperty("nhanvien_id")]
        public string? NhanVienId { get; set; }

        [JsonProperty("phuong_thuc")]
        public string? PhuongThuc { get; set; }  // "tien_mat", "momo", "chuyen_khoan"

        [JsonProperty("thoi_gian")]
        public long ThoiGian { get; set; }

        [JsonProperty("tong_tien")]
        public decimal TongTien { get; set; }

        [JsonProperty("tien_giam")]
        public decimal TienGiam { get; set; }

        [JsonProperty("tien_thuc_thu")]
        public decimal TienThucThu { get; set; }
    }
}
