using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class MonAnDTO
    {
        [JsonIgnore]
        public string? Id { get; set; }

        [JsonProperty("con_hang")]
        public bool ConHang { get; set; }

        [JsonProperty("gia")]
        public decimal Gia { get; set; }

        [JsonProperty("hien_thi")]
        public bool? HienThi { get; set; }

        [JsonProperty("hinh_anh_url")]
        public string? HinhAnhUrl { get; set; }

        [JsonProperty("loai")]
        public string? Loai { get; set; }

        [JsonProperty("mo_ta")]
        public string? MoTa { get; set; }

        [JsonProperty("ten_mon")]
        public string? TenMon { get; set; }
    }

    public class FoodDTO : MonAnDTO
    {
    }
}
