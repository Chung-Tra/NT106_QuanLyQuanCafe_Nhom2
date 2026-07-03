using Newtonsoft.Json;

namespace DTO
{
    /// <summary>
    /// Ánh xạ node Firebase: /thanh_toan/{tt_id}
    /// </summary>
    public class PaymentDTO
    {
        [JsonIgnore]
        public string? Id { get; set; }

        [JsonProperty("don_hang_id")]
        public string? OrderId { get; set; }

        [JsonProperty("nhanvien_id")]
        public string? EmployeeId { get; set; }

        [JsonProperty("phuong_thuc")]
        public string? Method { get; set; }  // "tien_mat", "momo", "chuyen_khoan"

        [JsonProperty("thoi_gian")]
        public long Timestamp { get; set; }

        [JsonProperty("tong_tien")]
        public decimal TotalAmount { get; set; }

        [JsonProperty("tien_giam")]
        public decimal Discount { get; set; }

        [JsonProperty("tien_thuc_thu")]
        public decimal ActualReceived { get; set; }
    }
}
