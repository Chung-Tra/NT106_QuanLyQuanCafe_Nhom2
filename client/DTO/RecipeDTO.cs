using Newtonsoft.Json;
using System.Collections.Generic;

namespace DTO
{
    /// <summary>
    /// Ánh xạ node Firebase: /cong_thuc/{ct_id}
    /// Node MỚI — chưa có trong DB cũ
    /// Dùng cho Cẩm nang Pha chế (ucRecipe_Barista)
    /// </summary>
    public class RecipeDTO
    {
        [JsonIgnore]
        public string? CongThucId { get; set; }

        [JsonProperty("ten_mon")]
        public string? TenMon { get; set; }

        [JsonProperty("loai")]
        public string? Loai { get; set; }  // "ca_phe", "tra", "sinh_to", "khac"

        [JsonProperty("mon_id")]
        public string? MonId { get; set; }  // Liên kết với mon_uong

        [JsonProperty("cac_buoc")]
        public string? CacBuoc { get; set; }  // Các bước pha chế (text)

        [JsonProperty("nguyen_lieu")]
        public Dictionary<string, RecipeIngredientDTO>? NguyenLieu { get; set; }
    }

    /// <summary>
    /// Sub-node: /cong_thuc/{ct_id}/nguyen_lieu/{nl_key}
    /// </summary>
    public class RecipeIngredientDTO
    {
        [JsonProperty("ten")]
        public string? Ten { get; set; }

        [JsonProperty("dinh_luong")]
        public string? DinhLuong { get; set; }  // "25ml", "200g", "2 cây"

        [JsonProperty("loai")]
        public string? Loai { get; set; }  // "chinh", "phu", "topping", "trang_tri"

        [JsonProperty("nguyen_lieu_id")]
        public string? NguyenLieuId { get; set; }  // Liên kết với nguyen_lieu (nếu có)
    }
}
