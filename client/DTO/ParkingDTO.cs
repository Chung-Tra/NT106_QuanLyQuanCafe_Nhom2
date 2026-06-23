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
        public string? Id { get; set; }

        [JsonProperty("bien_so")]
        public string? LicensePlate { get; set; }

        [JsonProperty("loai_xe")]
        public string? VehicleType { get; set; }  // "xe_may", "o_to", "xe_dap"

        [JsonProperty("gio_vao")]
        public long EntryTime { get; set; }

        [JsonProperty("gio_ra")]
        public long ExitTime { get; set; }  // 0 = chưa ra

        [JsonProperty("trang_thai")]
        public string? Status { get; set; }  // "dang_gui", "da_ra"

        [JsonProperty("nhanvien_id")]
        public string? EmployeeId { get; set; }  // Bảo vệ ghi nhận

        [JsonProperty("phi_gui")]
        public decimal Fee { get; set; }
    }
}
