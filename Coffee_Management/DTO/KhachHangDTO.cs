using Newtonsoft.Json;

namespace DTO
{
    /// <summary>
    /// Ánh xạ node Firebase: /khach_hang/{kh_id}
    /// Node MỚI — chưa có trong DB cũ
    /// Dùng cho CRM Order Staff (ucCRM_OrderStaff)
    /// </summary>
    public class KhachHangDTO
    {
        [JsonIgnore]
        public string? KhachHangId { get; set; }

        [JsonProperty("ten_khach_hang")]
        public string? TenKhachHang { get; set; }

        [JsonProperty("so_dien_thoai")]
        public string? SoDienThoai { get; set; }

        [JsonProperty("email")]
        public string? Email { get; set; }

        [JsonProperty("diem_tich_luy")]
        public int DiemTichLuy { get; set; }

        [JsonProperty("tong_don")]
        public int TongDon { get; set; }

        [JsonProperty("ngay_tao")]
        public long NgayTao { get; set; }
    }
}
