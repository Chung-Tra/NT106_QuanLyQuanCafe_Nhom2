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
            return [.. dict.Select(x => { x.Value.Id = x.Key; return x.Value; })];
        }

        public static async Task<(bool Success, string Message)> DeleteFood(string id)
        {
            if (Validation.IsAnyEmpty(id))
                return (false, "Không tìm thấy mã món ăn!");
            return await FoodDAL.DeleteAsync(id);
        }

        public static async Task<(bool Success, string Message)> UpdateFood(FoodDTO food)
        {
            if (Validation.IsAnyEmpty(food.Id))
                return (false, "Không tìm thấy mã món ăn cần cập nhật!");
            if (Validation.IsAnyEmpty(food.TenMon))
                return (false, "Tên món không được để trống!");
            if (food.Gia <= 0)
                return (false, "Giá món ăn phải lớn hơn 0!");

            return await FoodDAL.UpdateAsync(food.Id!, food);
        }

        public static async Task<(bool Success, string Message)> AddFood(FoodDTO food)
        {
            if (Validation.IsAnyEmpty(food.TenMon))
                return (false, "Tên món không được để trống!");
            if (food.Gia <= 0)
                return (false, "Giá món ăn phải lớn hơn 0!");

            return await FoodDAL.AddAsync(food);
        }
    }
}
