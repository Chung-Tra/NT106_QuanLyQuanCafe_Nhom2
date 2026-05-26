using Newtonsoft.Json;

namespace DTO
{
    /// <summary>
    /// Ánh xạ node Firebase: /cham_cong/{cc_id}
    /// </summary>
    public class AttendanceDTO
    {
        [JsonIgnore]
        public string? ChamCongId { get; set; }

        [JsonProperty("nhanvien_id")]
        public string? NhanVienId { get; set; }

        [JsonProperty("ngay")]
        public string? Ngay { get; set; }  // "2024-03-31"

        [JsonProperty("gio_vao")]
        public long GioVao { get; set; }  // Unix timestamp ms

        [JsonProperty("gio_ra")]
        public long GioRa { get; set; }

        [JsonProperty("so_gio_lam")]
        public double SoGioLam { get; set; }

        [JsonProperty("ghi_chu")]
        public string? GhiChu { get; set; }  // "Ca sáng", "Ca tối"

        [JsonProperty("trang_thai")]
        public string? TrangThai { get; set; }  // "du_gio", "di_muon", "nghi_phep", "nua_ca"
    }
}