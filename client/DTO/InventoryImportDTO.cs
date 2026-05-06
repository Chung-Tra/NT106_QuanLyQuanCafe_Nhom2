using System.Collections.Generic;
using Newtonsoft.Json;

namespace DTO
{
    public class InventoryImportDTO
    {
        [JsonIgnore]
        public string? Id { get; set; }

        [JsonProperty("ghi_chu")]
        public string? GhiChu { get; set; }

        [JsonProperty("ngay_nhap")]
        public int NgayNhap { get; set; }

        [JsonProperty("nhanvien_id")]
        public string? NhanVienId { get; set; }

        [JsonProperty("thanh_tien")]
        public long TongTien { get; set; }

        [JsonProperty("ds_nl")]
        public Dictionary<string, InventoryImportItemDTO>? DanhSachNL { get; set; }
    }

    public class InventoryImportItemDTO
    {
        [JsonProperty("gia_nhap")]
        public long GiaNhap { get; set; }

        [JsonProperty("so_luong")]
        public int SoLuong { get; set; }

        [JsonProperty("thanh_tien")]
        public long ThanhTien { get; set; }
    }
}
