using Newtonsoft.Json;

namespace DTO
{
    /// <summary>
    /// Ánh xạ node Firebase: /bai_xe/{bx_id}
    /// Node MỚI — chưa có trong DB cũ
    /// </summary>
    public class ParkingDTO
    {
        [JsonIgnore]
        public string? BaiXeId { get; set; }

        [JsonProperty("bien_so")]
        public string? BienSo { get; set; }

        [JsonProperty("loai_xe")]
        public string? LoaiXe { get; set; }  // "xe_may", "o_to", "xe_dap"

        [JsonProperty("gio_vao")]
        public long GioVao { get; set; }

        [JsonProperty("gio_ra")]
        public long GioRa { get; set; }  // 0 = chưa ra

        [JsonProperty("trang_thai")]
        public string? TrangThai { get; set; }  // "dang_gui", "da_ra"

        [JsonProperty("nhanvien_id")]
        public string? NhanVienId { get; set; }  // Bảo vệ ghi nhận

        [JsonProperty("phi_gui")]
        public decimal PhiGui { get; set; }
    }
}
