using Newtonsoft.Json;

namespace DTO
{
    /// <summary>
    /// Ánh xạ node Firebase: /xin_nghi/{xn_id}
    /// Node MỚI — chưa có trong DB cũ
    /// </summary>
    public class LeaveRequestDTO
    {
        [JsonIgnore]
        public string? Id { get; set; }

        [JsonProperty("nhanvien_id")]
        public string? EmployeeId { get; set; }

        [JsonProperty("tu_ngay")]
        public string? FromDate { get; set; }  // "dd/MM/yyyy"

        [JsonProperty("den_ngay")]
        public string? ToDate { get; set; }

        [JsonProperty("so_ngay")]
        public int DayCount { get; set; }

        [JsonProperty("ly_do")]
        public string? Reason { get; set; }

        [JsonProperty("trang_thai")]
        public string? Status { get; set; }  // "cho_duyet", "da_duyet", "tu_choi"

        [JsonProperty("thoi_gian_gui")]
        public long SentAt { get; set; }

        [JsonProperty("nguoi_duyet_id")]
        public string? ApproverId { get; set; }

        [JsonProperty("thoi_gian_duyet")]
        public long ApprovedAt { get; set; }

        [JsonProperty("ghi_chu_duyet")]
        public string? ApprovalNote { get; set; }
    }
}
