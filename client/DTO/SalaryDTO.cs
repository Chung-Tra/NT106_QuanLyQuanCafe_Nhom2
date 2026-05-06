using Newtonsoft.Json;

namespace DTO
{
    /// <summary>
    /// Ánh xạ node Firebase: /luong/{luong_id}
    /// Node MỚI — chưa có trong DB cũ
    /// </summary>
    public class SalaryDTO
    {
        [JsonIgnore]
        public string? LuongId { get; set; }

        [JsonProperty("nhanvien_id")]
        public string? NhanVienId { get; set; }

        [JsonProperty("thang")]
        public int Thang { get; set; }  // 1-12

        [JsonProperty("nam")]
        public int Nam { get; set; }

        [JsonProperty("ngay_cong")]
        public int NgayCong { get; set; }

        [JsonProperty("luong_co_ban")]
        public decimal LuongCoBan { get; set; }

        [JsonProperty("phu_cap")]
        public decimal PhuCap { get; set; }

        [JsonProperty("thuong_feedback")]
        public decimal ThuongFeedback { get; set; }

        [JsonProperty("thuong_le")]
        public decimal ThuongLe { get; set; }

        [JsonProperty("tru_luong")]
        public decimal TruLuong { get; set; }

        [JsonProperty("ly_do_tru")]
        public string? LyDoTru { get; set; }

        [JsonProperty("tong_luong")]
        public decimal TongLuong { get; set; }

        [JsonProperty("trang_thai")]
        public string? TrangThai { get; set; }  // "chua_duyet", "da_duyet", "da_tra"

        [JsonProperty("ngay_tinh")]
        public long NgayTinh { get; set; }
    }
}
