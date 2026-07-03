using Newtonsoft.Json;
using System.Collections.Generic;

namespace DTO
{
    /// <summary>
    /// Ánh xạ node Firebase: /don_hang/{dh_id}
    /// </summary>
    public class OrderDTO
    {
        [JsonIgnore]
        public string? Id { get; set; }

        [JsonProperty("ban_id")]
        public string? TableId { get; set; }

        [JsonProperty("nhanvien_id")]
        public string? EmployeeId { get; set; }

        [JsonProperty("thoi_gian_tao")]
        public long CreatedAt { get; set; }

        [JsonProperty("trang_thai")]
        public string? Status { get; set; }  // "pending", "dang_phuc_vu", "hoan_thanh", "huy"

        [JsonProperty("ghi_chu")]
        public string? Note { get; set; }

        [JsonProperty("nguon")]
        public string? Source { get; set; }  // "qr" = khách tự đặt qua QR bàn; null/"pos" = nhân viên tạo

        [JsonProperty("chi_tiet_don")]
        public Dictionary<string, OrderItemDTO>? Items { get; set; }
    }

    /// <summary>
    /// Ánh xạ sub-node: /don_hang/{dh_id}/chi_tiet_don/{ctd_id}
    /// </summary>
    public class OrderItemDTO
    {
        [JsonIgnore]
        public string? Id { get; set; }

        [JsonProperty("mon_id")]
        public string? FoodId { get; set; }

        [JsonProperty("so_luong")]
        public int Quantity { get; set; }

        [JsonProperty("don_gia")]
        public decimal UnitPrice { get; set; }

        [JsonProperty("ghi_chu_mon")]
        public string? Note { get; set; }

        [JsonProperty("trang_thai_che_bien")]
        public string? CookingStatus { get; set; }  // "cho", "dang_lam", "hoan_thanh"
    }
}
