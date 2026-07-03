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
        public string? Id { get; set; }

        [JsonProperty("nhanvien_id")]
        public string? EmployeeId { get; set; }

        [JsonProperty("thang")]
        public int Month { get; set; }  // 1-12

        [JsonProperty("nam")]
        public int Year { get; set; }

        [JsonProperty("ngay_cong")]
        public int WorkDays { get; set; }

        [JsonProperty("luong_co_ban")]
        public decimal BaseSalary { get; set; }

        [JsonProperty("phu_cap")]
        public decimal Allowance { get; set; }

        [JsonProperty("thuong_feedback")]
        public decimal FeedbackBonus { get; set; }

        [JsonProperty("thuong_le")]
        public decimal HolidayBonus { get; set; }

        [JsonProperty("tru_luong")]
        public decimal Deduction { get; set; }

        [JsonProperty("ly_do_tru")]
        public string? DeductionReason { get; set; }

        [JsonProperty("tong_luong")]
        public decimal TotalSalary { get; set; }

        [JsonProperty("trang_thai")]
        public string? Status { get; set; }  // "chua_duyet", "da_duyet", "da_tra"

        [JsonProperty("ngay_tinh")]
        public long CalculatedAt { get; set; }
    }
}
