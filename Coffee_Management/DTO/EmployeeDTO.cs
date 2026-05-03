using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class NhanVienDTO
    {
        [JsonProperty("employeeId")]
        public string? EmployeeId { get; set; }
        // Ánh xạ các thuộc tính JSON với tên khác nhau
        [JsonProperty("avatar_url")]
        public string? AvatarUrl { get; set; }

        public string? Password { get; set; }

        [JsonProperty("email")]
        public string? Email { get; set; }

        [JsonProperty("ho_ten")]
        public string? FullName { get; set; }

        [JsonProperty("ngay_vao_lam")]
        public string? HireDate { get; set; }

        [JsonProperty("so_dien_thoai")]
        public string? PhoneNumber { get; set; }

        [JsonProperty("trang_thai")]
        public string? Status { get; set; }

        [JsonProperty("vai_tro")]
        public string? Role { get; set; }

        // Dùng để liên kết với Firebase Auth (giúp xóa/khóa tài khoản sau này)
        public string? AuthUid { get; set; }
    }

    public class EmployeeDTO : NhanVienDTO
    {
    }
}
