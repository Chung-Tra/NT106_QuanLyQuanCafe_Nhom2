using DTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace DAL
{
    public static class IngredientDAL
    {
        public static async Task<List<IngredientDTO>> GetAllAsync()
        {
            var response = await DalHelper.Client.SendAsync(
                DalHelper.Build(HttpMethod.Get, "ingredients"));
            if (!response.IsSuccessStatusCode) return [];

            var json = await response.Content.ReadAsStringAsync();
            var dict = JsonConvert.DeserializeObject<Dictionary<string, IngredientDTO>>(json) ?? [];

            var list = new List<IngredientDTO>();
            foreach (var kvp in dict)
            {
                kvp.Value.Id = kvp.Key;
                list.Add(kvp.Value);
            }
            return list;
        }

        public static async Task<(bool Success, string Message)> AddAsync(IngredientDTO data)
        {
            try
            {
                var response = await DalHelper.Client.SendAsync(
                    DalHelper.Build(HttpMethod.Post, "ingredients", data));
                string body = await response.Content.ReadAsStringAsync();
                return response.IsSuccessStatusCode
                    ? (true, "Thêm nguyên liệu thành công!")
                    : (false, DalHelper.ParseErrorMessage(body));
            }
            catch (Exception ex) { return (false, "Lỗi kết nối: " + ex.Message); }
        }

        public static async Task<(bool Success, string Message)> UpdateAsync(string id, IngredientDTO data)
        {
            try
            {
                var payload = new Dictionary<string, object?>();
                if (data.TenNguyenLieu != null) payload["ten_nguyen_lieu"] = data.TenNguyenLieu;
                if (data.DonVi != null)          payload["don_vi"] = data.DonVi;
                payload["gia_nhap"] = data.GiaNhap;
                payload["ton_kho"] = data.TonKho;
                payload["ton_kho_toi_thieu"] = data.TonKhoToiThieu;

                var response = await DalHelper.Client.SendAsync(
                    DalHelper.Build(HttpMethod.Put, $"ingredients/{id}", payload));
                string body = await response.Content.ReadAsStringAsync();
                return response.IsSuccessStatusCode
                    ? (true, "Cập nhật thành công!")
                    : (false, DalHelper.ParseErrorMessage(body));
            }
            catch (Exception ex) { return (false, "Lỗi kết nối: " + ex.Message); }
        }

        public static async Task<(bool Success, string Message)> DeleteAsync(string id)
        {
            try
            {
                var response = await DalHelper.Client.SendAsync(
                    DalHelper.Build(HttpMethod.Delete, $"ingredients/{id}"));
                string body = await response.Content.ReadAsStringAsync();
                return response.IsSuccessStatusCode
                    ? (true, "Đã xóa nguyên liệu!")
                    : (false, DalHelper.ParseErrorMessage(body));
            }
            catch (Exception ex) { return (false, "Lỗi kết nối: " + ex.Message); }
        }
    }
}
