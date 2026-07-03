using DAL;
using DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BUS
{
    public class IngredientBUS
    {
        public static async Task<List<IngredientDTO>> GetAll() =>
            await IngredientDAL.GetAllAsync();

        public static async Task<(bool Success, string Message)> Add(IngredientDTO data)
        {
            if (string.IsNullOrWhiteSpace(data.Name))
                return (false, "Tên nguyên liệu không được để trống!");
            if (data.ImportPrice <= 0)
                return (false, "Giá nhập phải lớn hơn 0!");
            if (data.MinStock < 0)
                return (false, "Mức tối thiểu không được âm!");

            return await IngredientDAL.AddAsync(data);
        }

        public static async Task<(bool Success, string Message)> Update(string id, IngredientDTO data)
        {
            if (string.IsNullOrEmpty(id))
                return (false, "Không tìm thấy mã nguyên liệu!");
            if (string.IsNullOrWhiteSpace(data.Name))
                return (false, "Tên nguyên liệu không được để trống!");

            return await IngredientDAL.UpdateAsync(id, data);
        }

        public static async Task<(bool Success, string Message)> Delete(string id)
        {
            if (string.IsNullOrEmpty(id))
                return (false, "Không tìm thấy mã nguyên liệu!");
            return await IngredientDAL.DeleteAsync(id);
        }
    }
}
