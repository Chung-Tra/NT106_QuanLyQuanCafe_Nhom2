using Newtonsoft.Json;

namespace DTO
{
    /// <summary>
    /// Ánh xạ node Firebase: /khach_hang/{kh_id}
    /// Node MỚI — chưa có trong DB cũ
    /// Dùng cho CRM Order Staff (ucCRM_OrderStaff)
    /// </summary>
    public class CustomerDTO
    {
        [JsonIgnore]
        public string? Id { get; set; }

        [JsonProperty("ten_khach_hang")]
        public string? Name { get; set; }

        [JsonProperty("so_dien_thoai")]
        public string? PhoneNumber { get; set; }

        [JsonProperty("email")]
        public string? Email { get; set; }

        [JsonProperty("diem_tich_luy")]
        public int LoyaltyPoints { get; set; }

        [JsonProperty("tong_don")]
        public int TotalOrders { get; set; }

        [JsonProperty("ngay_tao")]
        public long CreatedAt { get; set; }
    }
}
