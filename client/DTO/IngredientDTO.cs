using Newtonsoft.Json;

namespace DTO
{
    public class IngredientDTO
    {
        public string? Id { get; set; }

        [JsonProperty("ten_nguyen_lieu")]
        public string? Name { get; set; }

        [JsonProperty("gia_nhap")]
        public long ImportPrice { get; set; }

        [JsonProperty("don_vi")]
        public string? Unit { get; set; }

        // double để chứa được số lẻ (2.2 kg, 1.5 lít...)
        [JsonProperty("ton_kho")]
        public double Stock { get; set; }

        [JsonProperty("ton_kho_toi_thieu")]
        public double MinStock { get; set; }
    }
}
