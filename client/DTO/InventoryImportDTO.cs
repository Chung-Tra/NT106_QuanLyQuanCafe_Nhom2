using System.Collections.Generic;
using Newtonsoft.Json;

namespace DTO
{
    public class InventoryImportDTO
    {
        [JsonIgnore]
        public string? Id { get; set; }

        [JsonProperty("ghi_chu")]
        public string? Note { get; set; }

        [JsonProperty("ngay_nhap")]
        public int ImportDate { get; set; }

        [JsonProperty("nhanvien_id")]
        public string? EmployeeId { get; set; }

        [JsonProperty("thanh_tien")]
        public long TotalAmount { get; set; }

        [JsonProperty("ds_nl")]
        public Dictionary<string, InventoryImportItemDTO>? Items { get; set; }
    }

    public class InventoryImportItemDTO
    {
        [JsonProperty("gia_nhap")]
        public long ImportPrice { get; set; }

        [JsonProperty("so_luong")]
        public int Quantity { get; set; }

        [JsonProperty("thanh_tien")]
        public long Subtotal { get; set; }
    }
}
