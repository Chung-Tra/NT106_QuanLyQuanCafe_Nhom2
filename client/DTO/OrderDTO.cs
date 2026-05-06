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
        public string? DonHangId { get; set; }

        [JsonProperty("ban_id")]
        public string? BanId { get; set; }

        [JsonProperty("nhanvien_id")]
        public string? NhanVienId { get; set; }

        [JsonProperty("thoi_gian_tao")]
        public long ThoiGianTao { get; set; }

        [JsonProperty("trang_thai")]
        public string? TrangThai { get; set; }  // "pending", "dang_phuc_vu", "hoan_thanh", "huy"

        [JsonProperty("ghi_chu")]
        public string? GhiChu { get; set; }

        [JsonProperty("chi_tiet_don")]
        public Dictionary<string, OrderItemDTO>? ChiTietDon { get; set; }
    }

    /// <summary>
    /// Ánh xạ sub-node: /don_hang/{dh_id}/chi_tiet_don/{ctd_id}
    /// </summary>
    public class OrderItemDTO
    {
        [JsonIgnore]
        public string? ChiTietId { get; set; }

        [JsonProperty("mon_id")]
        public string? MonId { get; set; }

        [JsonProperty("so_luong")]
        public int SoLuong { get; set; }

        [JsonProperty("don_gia")]
        public decimal DonGia { get; set; }

        [JsonProperty("ghi_chu_mon")]
        public string? GhiChuMon { get; set; }

        [JsonProperty("trang_thai_che_bien")]
        public string? TrangThaiCheBien { get; set; }  // "cho", "dang_lam", "hoan_thanh"
    }
}
