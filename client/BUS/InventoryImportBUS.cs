using DAL;
using DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BUS
{
    public class InventoryImportBUS
    {
        public static async Task<List<IngredientDTO>> GetIngredients() =>
            await IngredientDAL.GetAllAsync();

        public static async Task<List<EmployeeDTO>> GetEmployees() =>
            await InventoryImportDAL.GetEmployeesAsync();

        public static async Task<List<InventoryImportDTO>> GetAllImports() =>
            await InventoryImportDAL.GetAllAsync();

        public static async Task<(bool Success, string Message)> AddImport(InventoryImportDTO phieu)
        {
            if (string.IsNullOrEmpty(phieu.NhanVienId))
                return (false, "Vui lòng chọn nhân viên thực hiện!");

            if (phieu.DanhSachNL == null || phieu.DanhSachNL.Count == 0)
                return (false, "Vui lòng nhập ít nhất một nguyên liệu!");

            // Tính thành tiền từng dòng và tổng tiền
            long tongTien = 0;
            foreach (var chiTiet in phieu.DanhSachNL.Values)
            {
                chiTiet.ThanhTien = chiTiet.GiaNhap * chiTiet.SoLuong;
                tongTien += chiTiet.ThanhTien;
            }
            phieu.TongTien = tongTien;

            return await InventoryImportDAL.AddAsync(phieu);
        }
    }
}
