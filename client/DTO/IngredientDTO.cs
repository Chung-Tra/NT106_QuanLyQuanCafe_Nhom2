using Newtonsoft.Json;

namespace DTO
{
    public class IngredientDTO
    {
        public string? Id { get; set; }

        [JsonProperty("ten_nguyen_lieu")]
        public string? TenNguyenLieu { get; set; }

        [JsonProperty("gia_nhap")]
        public long GiaNhap { get; set; }

        [JsonProperty("don_vi")]
        public string? DonVi { get; set; }

        // double để chứa được số lẻ (2.2 kg, 1.5 lít...)
        [JsonProperty("ton_kho")]
        public double TonKho { get; set; }

        [JsonProperty("ton_kho_toi_thieu")]
        public double TonKhoToiThieu { get; set; }
    }
}
