using Newtonsoft.Json;

namespace DTO
{
    /// <summary>
    /// Ánh xạ node Firebase: /xin_nghi/{xn_id}
    /// Node MỚI — chưa có trong DB cũ
    /// </summary>
    public class LeaveRequestDTO
    {
        [JsonIgnore]
        public string? XinNghiId { get; set; }

        [JsonProperty("nhanvien_id")]
        public string? NhanVienId { get; set; }

        [JsonProperty("tu_ngay")]
        public string? TuNgay { get; set; }  // "dd/MM/yyyy"

        [JsonProperty("den_ngay")]
        public string? DenNgay { get; set; }

        [JsonProperty("so_ngay")]
        public int SoNgay { get; set; }

        [JsonProperty("ly_do")]
        public string? LyDo { get; set; }

        [JsonProperty("trang_thai")]
        public string? TrangThai { get; set; }  // "cho_duyet", "da_duyet", "tu_choi"

        [JsonProperty("thoi_gian_gui")]
        public long ThoiGianGui { get; set; }

        [JsonProperty("nguoi_duyet_id")]
        public string? NguoiDuyetId { get; set; }

        [JsonProperty("thoi_gian_duyet")]
        public long ThoiGianDuyet { get; set; }

        [JsonProperty("ghi_chu_duyet")]
        public string? GhiChuDuyet { get; set; }
    }
}
