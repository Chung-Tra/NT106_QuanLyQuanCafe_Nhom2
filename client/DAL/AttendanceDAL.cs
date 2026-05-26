using DTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace DAL
{
    public static class AttendanceDAL
    {
        /// <summary>
        /// Lấy danh sách chấm công (Tất cả hoặc theo cá nhân tùy vào Token)
        /// </summary>
        public static async Task<Dictionary<string, AttendanceDTO>> GetAllAsync()
        {
            try
            {
                var response = await DalHelper.Client.SendAsync(
                    DalHelper.Build(HttpMethod.Get, "attendance/all"));

                if (!response.IsSuccessStatusCode) return new Dictionary<string, AttendanceDTO>();

                string json = await response.Content.ReadAsStringAsync();

                // Chặn trường hợp Server trả về HTML lỗi
                if (json.TrimStart().StartsWith('<')) return new Dictionary<string, AttendanceDTO>();

                return JsonConvert.DeserializeObject<Dictionary<string, AttendanceDTO>>(json)
                       ?? new Dictionary<string, AttendanceDTO>();
            }
            catch (Exception)
            {
                return new Dictionary<string, AttendanceDTO>();
            }
        }

        /// <summary>
        /// Ví dụ: Thêm một bản ghi chấm công mới (nếu bạn có API này)
        /// </summary>
        public static async Task<(bool Success, string Message)> AddAsync(AttendanceDTO data)
        {
            try
            {
                var response = await DalHelper.Client.SendAsync(
                    DalHelper.Build(HttpMethod.Post, "attendance", data));

                string body = await response.Content.ReadAsStringAsync();

                return response.IsSuccessStatusCode
                    ? (true, "Ghi nhận chấm công thành công!")
                    : (false, DalHelper.ParseErrorMessage(body));
            }
            catch (Exception ex)
            {
                return (false, "Lỗi kết nối hệ thống: " + ex.Message);
            }
        }

        /// <summary>
        /// Cập nhật thông tin chấm công (ví dụ: sửa giờ ra, ghi chú)
        /// </summary>
        public static async Task<(bool Success, string Message)> UpdateAsync(string attendanceId, AttendanceDTO data)
        {
            try
            {
                // Chỉ gửi các trường cần thiết để cập nhật
                var payload = new Dictionary<string, object?>();
                if (data.GioVao != 0) payload["gio_vao"] = data.GioVao;
                if (data.GioRa != 0) payload["gio_ra"] = data.GioRa;
                if (data.GhiChu != null) payload["ghi_chu"] = data.GhiChu;
                if (data.TrangThai != null) payload["trang_thai"] = data.TrangThai;

                var response = await DalHelper.Client.SendAsync(
                    DalHelper.Build(HttpMethod.Put, $"attendance/{attendanceId}", payload));

                string body = await response.Content.ReadAsStringAsync();

                return response.IsSuccessStatusCode
                    ? (true, "Cập nhật dữ liệu chấm công thành công!")
                    : (false, DalHelper.ParseErrorMessage(body));
            }
            catch (Exception ex)
            {
                return (false, "Lỗi kết nối hệ thống: " + ex.Message);
            }
        }
    }
}