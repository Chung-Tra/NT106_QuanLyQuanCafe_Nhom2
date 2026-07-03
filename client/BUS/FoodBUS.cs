using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL;

namespace BUS
{
    public class FoodBUS
    {
        public static async Task<List<FoodDTO>> GetListFoods()
        {
            var dict = await FoodDAL.GetAllAsync();
            var list = new List<FoodDTO>();
            foreach (var kvp in dict)
            {
                kvp.Value.Id = kvp.Key;
                list.Add(kvp.Value);
            }
            return list;
        }

        public static async Task<(bool Success, string Message)> DeleteFood(string id)
        {
            if (Validation.IsAnyEmpty(id))
                return (false, "Không tìm thấy mã món ăn!");
            var r = await FoodDAL.DeleteAsync(id);
            if (r.Success) Audit.Log("Xóa", "Món " + id);
            return r;
        }

        public static async Task<(bool Success, string Message)> UpdateFood(FoodDTO food)
        {
            if (Validation.IsAnyEmpty(food.Id))
                return (false, "Không tìm thấy mã món ăn cần cập nhật!");
            if (Validation.IsAnyEmpty(food.Name))
                return (false, "Tên món không được để trống!");
            if (food.Price <= 0)
                return (false, "Giá món ăn phải lớn hơn 0!");

            var r = await FoodDAL.UpdateAsync(food.Id!, food);
            if (r.Success) Audit.Log("Sửa thông tin", "Món " + food.Name);
            return r;
        }

        public static async Task<(bool Success, string Message)> AddFood(FoodDTO food)
        {
            if (Validation.IsAnyEmpty(food.Name))
                return (false, "Tên món không được để trống!");
            if (food.Price <= 0)
                return (false, "Giá món ăn phải lớn hơn 0!");

            var r = await FoodDAL.AddAsync(food);
            if (r.Success) Audit.Log("Thêm", "Món " + food.Name);
            return r;
        }
    }
}
