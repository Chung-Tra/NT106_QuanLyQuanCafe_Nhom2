using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DTO;
using DAL;

namespace BUS
{
    public class AttendanceBUS
    {
        /// <summary>
        /// Lấy toàn bộ danh sách chấm công và chuyển sang dạng List để hiển thị
        /// </summary>
        public static async Task<List<AttendanceDTO>> GetAllAttendanceAsync()
        {
            // 1. Gọi DAL lấy dữ liệu Dictionary từ API
            var dict = await AttendanceDAL.GetAllAsync();
            var list = new List<AttendanceDTO>();

            if (dict == null || dict.Count == 0) return list;

            // 2. Duyệt Dictionary để chuyển sang List và gán ID
            foreach (var kvp in dict)
            {
                // kvp.Key chính là "cc_001", "cc_002"...
                // kvp.Value là đối tượng AttendanceDTO chứa thông tin chi tiết
                kvp.Value.ChamCongId = kvp.Key;
                list.Add(kvp.Value);
            }

            // 3. (Optional) Sắp xếp danh sách theo ngày mới nhất lên đầu
            return list.OrderByDescending(a => a.Ngay).ToList();
        }

        /// <summary>
        /// Logic bổ sung: Lọc chấm công theo mã nhân viên cụ thể
        /// (Hữu ích khi admin muốn xem riêng lịch sử của 1 người)
        /// </summary>
        public static async Task<List<AttendanceDTO>> GetAttendanceByEmployeeAsync(string empId)
        {
            if (string.IsNullOrEmpty(empId)) return new List<AttendanceDTO>();

            var allList = await GetAllAttendanceAsync();
            return allList.Where(a => a.NhanVienId == empId).ToList();
        }
    }
}