using DTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace DAL
{
    public static class FoodDAL
    {
        // --- HÀM 1: LẤY DANH SÁCH MÓN ĂN ---
        public static async Task<Dictionary<string, FoodDTO>> GetAllAsync()
        {
            var response = await DalHelper.Client.SendAsync(
                DalHelper.Build(HttpMethod.Get, "foods"));
            if (!response.IsSuccessStatusCode) return [];

            var json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Dictionary<string, FoodDTO>>(json) ?? [];
        }

        public static async Task<(bool Success, string Message)> AddAsync(FoodDTO food)
        {
            try
            {
                var response = await DalHelper.Client.SendAsync(
                    DalHelper.Build(HttpMethod.Post, "foods", food));
                string body = await response.Content.ReadAsStringAsync();
                return response.IsSuccessStatusCode
                    ? (true, "Thêm món thành công!")
                    : (false, DalHelper.ParseErrorMessage(body));
            }
            catch (Exception ex) { return (false, "Lỗi kết nối: " + ex.Message); 
        }

        public static async Task<(bool Success, string Message)> UpdateAsync(string foodId, FoodDTO food)
        {
            try
            {
                var response = await DalHelper.Client.SendAsync(
                    DalHelper.Build(HttpMethod.Put, $"foods/{foodId}", food));
                string body = await response.Content.ReadAsStringAsync();
                return response.IsSuccessStatusCode
                    ? (true, "Cập nhật món thành công!")
                    : (false, DalHelper.ParseErrorMessage(body));
            }
            catch (Exception ex) { return (false, "Lỗi kết nối: " + ex.Message); }
        }

        public static async Task<(bool Success, string Message)> DeleteAsync(string foodId)
        {
            try
            {
                var response = await DalHelper.Client.SendAsync(
                    DalHelper.Build(HttpMethod.Delete, $"foods/{foodId}"));
                string body = await response.Content.ReadAsStringAsync();
                return response.IsSuccessStatusCode
                    ? (true, "Đã xóa món thành công!")
                    : (false, DalHelper.ParseErrorMessage(body));
            }
            catch (Exception ex) { return (false, "Lỗi kết nối: " + ex.Message); }
        }
    }
}
