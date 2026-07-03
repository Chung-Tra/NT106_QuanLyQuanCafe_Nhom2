using Newtonsoft.Json;

namespace DTO
{
    /// <summary>
    /// Ánh xạ node Firebase: /cham_cong/{cc_id}
    /// </summary>
    public class AttendanceDTO
    {
        [JsonIgnore]
        public string? Id { get; set; }

        [JsonProperty("nhanvien_id")]
        public string? EmployeeId { get; set; }

        [JsonProperty("ngay")]
        public string? Date { get; set; }  // "2024-03-31"

        [JsonProperty("gio_vao")]
        public long CheckIn { get; set; }  // Unix timestamp ms

        [JsonProperty("gio_ra")]
        public long CheckOut { get; set; }

        [JsonProperty("so_gio_lam")]
        public double WorkHours { get; set; }

        [JsonProperty("ghi_chu")]
        public string? Note { get; set; }  // "Ca sáng", "Ca tối"

        [JsonProperty("trang_thai")]
        public string? Status { get; set; }  // "du_gio", "di_muon", "nghi_phep", "nua_ca"
    }
}
