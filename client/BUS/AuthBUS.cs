using System.Threading.Tasks;
using DAL;
using DTO;

namespace BUS
{
    public class AuthBUS
    {
        //Hàm xử lý nghiệp vụ đăng nhập, trả về 3 giá trị: Thành công hay không, Thông báo lỗi (nếu có), Dữ liệu người dùng (nếu thành công)
        public static async Task<(bool IsSuccess, string Message, EmployeeDTO? UserData)> LoginBUS(string email, string password)
        {
            try
            {
                //Kiểm tra định dạng email nếu người dùng nhập
                if (!Validation.IsAnyEmpty(email))
                {
                    if (!Validation.IsValidEmail(email))
                        return (false, "Email không hợp lệ.\nVui lòng nhập lại địa chỉ email!", null);
                }
                else
                {
                    return (false, "Vui lòng nhập địa chỉ email của bạn.", null);
                }
                // Đăng nhập chỉ kiểm tra CÓ NHẬP mật khẩu hay không — KHÔNG kiểm tra độ mạnh.
                // (Độ mạnh chỉ áp khi ĐẶT mật khẩu: đăng ký / reset. Nếu chặn ở đây, tài khoản
                //  có mật khẩu không đạt quy tắc sẽ không đăng nhập được dù gõ đúng.)
                if (Validation.IsAnyEmpty(password))
                {
                    return (false, "Vui lòng nhập mật khẩu của bạn.", null);
                }
                //Gọi DAL thực hiện đăng nhập
                var (user, token) = await AuthDAL.LoginAsync(email, password);
                //Xử lý các nghiệp vụ sau khi có kết quả từ Database
                if (user == null)
                {
                    return (false, "Email hoặc mật khẩu không đúng.", null);
                }

                //Kiểm tra nghiệp vụ: Trạng thái tài khoản
                if (user.Status != "active")
                {
                    return (false, "Tài khoản của bạn đã bị khóa hoặc bị vô hiệu hóa.\nVui lòng liên hệ với Quản lý của bạn.", null);
                }
                GlobalSession.Token = token;
                GlobalSession.CurrentUser = user;
                // Thiết lập phiên làm việc kéo dài 60 phút. Trừ hao 1 phút (còn 59 phút) để app văng ra trước khi token thực sự chết
                GlobalSession.ExpiryTime = DateTime.Now.AddMinutes(60);
                //GlobalSession.ExpiryTime = DateTime.Now.AddSeconds(20); // Chờ 10 giây là văng
                // 5. Nếu vượt qua mọi cửa ải -> Thành công
                return (true, "Đăng nhập thành công.", user);
            }
            catch (System.Exception ex)
            {
                // 4. Xử lý lỗi hệ thống
                return (false, $"Đã xảy ra lỗi trong quá trình đăng nhập: {ex.Message}", null);
            }
        }
        // Hàm xử lý nghiệp vụ đặt lại mật khẩu, trả về 2 giá trị: Thành công hay không, Thông báo lỗi (nếu có)
        public static async Task<(bool IsValid, string Message)> HandlePasswordReset(string email, string newPass, string confirmPass, string resetToken)
        {
            if (Validation.IsAnyEmpty(newPass, confirmPass))
                return (false, "Vui lòng nhập đầy đủ mật khẩu mới và xác nhận mật khẩu.");

            if (Validation.IsAnyEmpty(resetToken))
                return (false, "Phiên đặt lại mật khẩu không hợp lệ. Vui lòng xác thực OTP lại.");

            if (!Validation.IsValidPassword(newPass))
                return (false, "Mật khẩu phải dài ít nhất 8 ký tự, bao gồm chữ hoa, chữ thường, chữ số và một ký tự đặc biệt.");

            if (newPass != confirmPass)
            {
                return (false, "Mật khẩu không khớp.\nVui lòng thử lại.");
            }
            else
                // Kèm reset-token (đã xác thực OTP ở server) để được phép đổi mật khẩu
                return await AuthDAL.UpdatePasswordAsync(email, newPass, resetToken);
        }
    }
}
