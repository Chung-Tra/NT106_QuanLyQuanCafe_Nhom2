using DTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace DAL
{
    public static class LeaveRequestDAL
    {
        public static async Task<List<LeaveRequestDTO>> GetAllRequestsAsync()
        {
            try
            {
                // Gọi API lấy dữ liệu. Nếu bạn dùng Firebase REST API trực tiếp thì thường đuôi sẽ là "xin_nghi.json"
                // Nếu gọi qua Backend riêng thì sửa lại endpoint cho đúng (ví dụ: "xin_nghi" hoặc "api/xin_nghi")
                var response = await DalHelper.Client.SendAsync(
                    DalHelper.Build(HttpMethod.Get, "xin_nghi.json"));

                if (!response.IsSuccessStatusCode)
                    return new List<LeaveRequestDTO>();

                string jsonResponse = await response.Content.ReadAsStringAsync();

                // Tránh lỗi khi Firebase trả về null (node không có dữ liệu)
                if (string.IsNullOrWhiteSpace(jsonResponse) || jsonResponse == "null")
                    return new List<LeaveRequestDTO>();

                // 1. Ép kiểu JSON về dạng Dictionary (Key: ID của node, Value: Dữ liệu xin nghỉ)
                var dict = JsonConvert.DeserializeObject<Dictionary<string, LeaveRequestDTO>>(jsonResponse);
                var list = new List<LeaveRequestDTO>();

                if (dict != null)
                {
                    foreach (var kvp in dict)
                    {
                        var item = kvp.Value;
                        // 2. Gán thủ công Key của Firebase vào biến XinNghiId (vì đã bị JsonIgnore)
                        item.XinNghiId = kvp.Key;
                        list.Add(item);
                    }
                }

                return list;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi kết nối khi lấy dữ liệu xin nghỉ: " + ex.Message);
            }
        }

        public static async Task<bool> CreateRequestAsync(LeaveRequestDTO request)
        {
            try
            {
                // Gọi method POST để thêm vào Firebase
                var response = await DalHelper.Client.SendAsync(
                    DalHelper.Build(HttpMethod.Post, "xin_nghi.json", request));

                return response.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }
    }
}