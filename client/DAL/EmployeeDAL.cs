using DTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace DAL
{
    public static class EmployeeDAL
    {
        public static async Task<Dictionary<string, EmployeeDTO>> GetAllAsync()
        {
            var response = await DalHelper.Client.SendAsync(
                DalHelper.Build(HttpMethod.Get, "employees"));
            if (!response.IsSuccessStatusCode) return [];

            string json = await response.Content.ReadAsStringAsync();
            if (json.TrimStart().StartsWith('<')) return [];
            return JsonConvert.DeserializeObject<Dictionary<string, EmployeeDTO>>(json) ?? [];
        }

        public static async Task<(bool Success, string Message)> AddAsync(EmployeeDTO emp)
        {
            try
            {
                var response = await DalHelper.Client.SendAsync(
                    DalHelper.Build(HttpMethod.Post, "employees", emp));
                string body = await response.Content.ReadAsStringAsync();

                return response.IsSuccessStatusCode
                    ? (true, "Thêm nhân viên thành công!")
                    : (false, DalHelper.ParseErrorMessage(body));
            }
            catch (Exception ex) { return (false, "Lỗi kết nối: " + ex.Message); }
        }

        public static async Task<(bool Success, string Message)> UpdateAsync(string empId, EmployeeDTO data)
        {
            try
            {
                // Chỉ gửi field có giá trị để tránh overwrite null lên Firebase
                var payload = new Dictionary<string, object?>();
                if (data.FullName != null)    payload["ho_ten"] = data.FullName;
                if (data.PhoneNumber != null) payload["so_dien_thoai"] = data.PhoneNumber;
                if (data.Role != null)        payload["vai_tro"] = data.Role;
                if (data.Status != null)      payload["trang_thai"] = data.Status;
                if (data.HireDate != null)    payload["ngay_vao_lam"] = data.HireDate;
                if (data.AvatarUrl != null)   payload["avatar_url"] = data.AvatarUrl;

                var response = await DalHelper.Client.SendAsync(
                    DalHelper.Build(HttpMethod.Put, $"employees/{empId}", payload));
                string body = await response.Content.ReadAsStringAsync();

                return response.IsSuccessStatusCode
                    ? (true, "Cập nhật thành công!")
                    : (false, DalHelper.ParseErrorMessage(body));
            }
            catch (Exception ex) { return (false, "Lỗi kết nối: " + ex.Message); }
        }

        public static async Task<(bool Success, string Message)> DeleteAsync(string empId, string authUid)
        {
            try
            {
                var response = await DalHelper.Client.SendAsync(
                    DalHelper.Build(HttpMethod.Delete, $"employees/{empId}", new { authUid }));
                string body = await response.Content.ReadAsStringAsync();

                return response.IsSuccessStatusCode
                    ? (true, "Đã xóa nhân viên thành công!")
                    : (false, DalHelper.ParseErrorMessage(body));
            }
            catch (Exception ex) { return (false, "Lỗi kết nối: " + ex.Message); }
        }

        public static async Task<(bool Success, string Message)> LockAsync(string empId, string authUid)
        {
            try
            {
                var response = await DalHelper.Client.SendAsync(
                    DalHelper.Build(HttpMethod.Patch, $"employees/{empId}/lock", new { authUid }));
                string body = await response.Content.ReadAsStringAsync();

                return response.IsSuccessStatusCode
                    ? (true, "Tài khoản đã bị khóa!")
                    : (false, DalHelper.ParseErrorMessage(body));
            }
            catch (Exception ex) { return (false, "Lỗi kết nối: " + ex.Message); }
        }
    }
}
