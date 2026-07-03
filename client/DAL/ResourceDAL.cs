using DTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace DAL
{
    /// <summary>
    /// CRUD chung cho các node RTDB phẳng qua backend generic resource API
    /// (tables, orders, payments, customers, feedback, attendance, salaries,
    /// leave-requests, notifications, parking, incidents, warnings, recipes).
    /// Cùng contract với FoodDAL: GET trả {id:{...}}, POST tự sinh id.
    /// </summary>
    public static class ResourceDAL
    {
        /// <summary>Đọc toàn bộ node, gán Id cho mỗi phần tử nếu DTO có thuộc tính Id.</summary>
        public static async Task<Dictionary<string, T>> GetAllAsync<T>(string path)
        {
            try
            {
                var response = await DalHelper.Client.SendAsync(
                    DalHelper.Build(HttpMethod.Get, path));
                if (!response.IsSuccessStatusCode) return [];

                var json = await response.Content.ReadAsStringAsync();
                var dict = JsonConvert.DeserializeObject<Dictionary<string, T>>(json) ?? [];

                // Gán khóa vào thuộc tính Id (nếu có) để GUI dùng khi update/delete.
                var idProp = typeof(T).GetProperty("Id");
                if (idProp != null && idProp.CanWrite)
                    foreach (var kv in dict)
                        if (kv.Value != null) idProp.SetValue(kv.Value, kv.Key);

                return dict;
            }
            catch { return []; }
        }

        /// <summary>Thêm bản ghi mới; trả về Id do server sinh (nếu thành công).</summary>
        public static async Task<(bool Success, string Message, string? Id)> AddAsync<T>(string path, T dto)
        {
            try
            {
                var response = await DalHelper.Client.SendAsync(
                    DalHelper.Build(HttpMethod.Post, path, dto));
                string body = await response.Content.ReadAsStringAsync();
                if (!response.IsSuccessStatusCode)
                    return (false, DalHelper.ParseErrorMessage(body), null);

                string? newId = null;
                try { dynamic? o = JsonConvert.DeserializeObject(body); newId = (string?)o?.id; } catch { }
                return (true, "Thêm thành công!", newId);
            }
            catch (Exception ex) { return (false, "Lỗi kết nối: " + ex.Message, null); }
        }

        /// <summary>Cập nhật một phần bản ghi. data có thể là DTO hoặc object ẩn danh chỉ chứa field cần đổi.</summary>
        public static async Task<(bool Success, string Message)> UpdateAsync(string path, string id, object data)
        {
            try
            {
                var response = await DalHelper.Client.SendAsync(
                    DalHelper.Build(HttpMethod.Put, $"{path}/{id}", data));
                string body = await response.Content.ReadAsStringAsync();
                return response.IsSuccessStatusCode
                    ? (true, "Cập nhật thành công!")
                    : (false, DalHelper.ParseErrorMessage(body));
            }
            catch (Exception ex) { return (false, "Lỗi kết nối: " + ex.Message); }
        }

        public static async Task<(bool Success, string Message)> DeleteAsync(string path, string id)
        {
            try
            {
                var response = await DalHelper.Client.SendAsync(
                    DalHelper.Build(HttpMethod.Delete, $"{path}/{id}"));
                string body = await response.Content.ReadAsStringAsync();
                return response.IsSuccessStatusCode
                    ? (true, "Đã xóa thành công!")
                    : (false, DalHelper.ParseErrorMessage(body));
            }
            catch (Exception ex) { return (false, "Lỗi kết nối: " + ex.Message); }
        }
    }
}
