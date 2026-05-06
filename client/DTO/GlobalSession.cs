using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public static class GlobalSession
    {
        //Lưu trữ Token để gửi kèm các API sau này
        public static string? Token { get; set; }

        //Lưu trữ toàn bộ thông tin của người đang đăng nhập (Tên, Email, Quyền...)
        public static EmployeeDTO? CurrentUser { get; set; }
        // Lưu thời điểm "chết" của phiên làm việc
        public static DateTime ExpiryTime { get; set; }

        // Hàm gọi khi người dùng bấm ĐĂNG XUẤT (Xóa sạch trí nhớ)
        public static void Logout()
        {
            Token = null;
            CurrentUser = null;
            ExpiryTime = DateTime.MinValue;
        }
        // Hàm tiện ích để kiểm tra trạng thái đăng nhập/ Phiên làm việc có còn hợp lệ hay không
        public static bool IsLoggedIn()
        {
            return !string.IsNullOrEmpty(Token) && CurrentUser != null;
        }
    }
}
