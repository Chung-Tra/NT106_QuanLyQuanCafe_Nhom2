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
        public string? Id { get; set; }

        [JsonProperty("ten_mon")]
        public string? Name { get; set; }

        [JsonProperty("loai")]
        public string? Category { get; set; }  // "ca_phe", "tra", "sinh_to", "khac"

        [JsonProperty("mon_id")]
        public string? FoodId { get; set; }  // Liên kết với mon_uong

        [JsonProperty("cac_buoc")]
        public string? Steps { get; set; }  // Các bước pha chế (text)

        [JsonProperty("nguyen_lieu")]
        public Dictionary<string, RecipeIngredientDTO>? Ingredients { get; set; }
    }

    /// <summary>
    /// Sub-node: /cong_thuc/{ct_id}/nguyen_lieu/{nl_key}
    /// </summary>
    public class RecipeIngredientDTO
    {
        [JsonProperty("ten")]
        public string? Name { get; set; }

        [JsonProperty("dinh_luong")]
        public string? Quantity { get; set; }  // "25ml", "200g", "2 cây"

        [JsonProperty("loai")]
        public string? Type { get; set; }  // "chinh", "phu", "topping", "trang_tri"

        [JsonProperty("nguyen_lieu_id")]
        public string? IngredientId { get; set; }  // Liên kết với nguyen_lieu (nếu có)
    }
}
