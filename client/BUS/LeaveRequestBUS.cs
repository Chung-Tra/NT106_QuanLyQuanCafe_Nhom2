using DAL;
using DTO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BUS
{
    public class LeaveRequestBUS
    {
        // Hàm lấy danh sách xin nghỉ theo ID nhân viên đang đăng nhập
        public async Task<List<LeaveRequestDTO>> GetRequestsByEmployeeAsync(string nhanVienId)
        {
            // 1. Gọi DAL lấy TOÀN BỘ dữ liệu từ Firebase
            var allData = await LeaveRequestDAL.GetAllRequestsAsync();

            // 2. Lọc chỉ lấy đơn của nhân viên đang đăng nhập (nhanVienId)
            var filteredData = allData.Where(x => x.NhanVienId == nhanVienId).ToList();

            // 3. Xử lý logic làm đẹp dữ liệu (Business Logic)
            foreach (var req in filteredData)
            {
                if (req.TrangThai == "da_duyet") req.TrangThai = "Đã duyệt";
                else if (req.TrangThai == "cho_duyet") req.TrangThai = "Chờ duyệt";
                else if (req.TrangThai == "tu_choi") req.TrangThai = "Từ chối";

                // Nếu Firebase không có ngày, gán tạm "N/A"
                if (string.IsNullOrEmpty(req.TuNgay)) req.TuNgay = "N/A";
                if (string.IsNullOrEmpty(req.DenNgay)) req.DenNgay = "N/A";
            }

            return filteredData; // Trả cục dữ liệu đã làm đẹp này lên GUI
        }
    }
}