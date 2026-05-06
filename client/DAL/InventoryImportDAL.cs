using DTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace DAL
{
    public static class InventoryImportDAL
    {
        public static async Task<List<InventoryImportDTO>> GetAllAsync()
        {
            var response = await DalHelper.Client.SendAsync(
                DalHelper.Build(HttpMethod.Get, "inventory"));
            if (!response.IsSuccessStatusCode) return [];

            var json = await response.Content.ReadAsStringAsync();
            var dict = JsonConvert.DeserializeObject<Dictionary<string, InventoryImportDTO>>(json) ?? [];

            var list = new List<InventoryImportDTO>();
            foreach (var kvp in dict)
            {
                kvp.Value.Id = kvp.Key;
                list.Add(kvp.Value);
            }
            return list;
        }

        public static async Task<(bool Success, string Message)> AddAsync(InventoryImportDTO phieu)
        {
            try
            {
                var response = await DalHelper.Client.SendAsync(
                    DalHelper.Build(HttpMethod.Post, "inventory", phieu));
                string body = await response.Content.ReadAsStringAsync();
                return response.IsSuccessStatusCode
                    ? (true, "Tạo phiếu nhập thành công!")
                    : (false, DalHelper.ParseErrorMessage(body));
            }
            catch (Exception ex) { return (false, "Lỗi kết nối: " + ex.Message); }
        }

        /// <summary>Lấy danh sách nhân viên để bind ComboBox trong form nhập kho.</summary>
        public static async Task<List<EmployeeDTO>> GetEmployeesAsync()
        {
            var dict = await EmployeeDAL.GetAllAsync();
            var list = new List<EmployeeDTO>();
            foreach (var kvp in dict)
            {
                kvp.Value.EmployeeId = kvp.Key;
                list.Add(kvp.Value);
            }
            return list;
        }
    }
}
