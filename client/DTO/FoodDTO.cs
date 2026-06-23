using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class FoodDTO
    {
        [JsonIgnore]
        public string? Id { get; set; }

        [JsonProperty("con_hang")]
        public bool InStock { get; set; }

        [JsonProperty("gia")]
        public decimal Price { get; set; }

        [JsonProperty("hien_thi")]
        public bool? IsVisible { get; set; }

        [JsonProperty("hinh_anh_url")]
        public string? ImageUrl { get; set; }

        [JsonProperty("loai")]
        public string? Category { get; set; }

        [JsonProperty("mo_ta")]
        public string? Description { get; set; }

        [JsonProperty("ten_mon")]
        public string? Name { get; set; }
    }
}
