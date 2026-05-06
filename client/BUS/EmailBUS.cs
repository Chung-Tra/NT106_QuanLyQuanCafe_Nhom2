using System;
using System.Threading.Tasks;
using DAL;

namespace BUS
{
    public class EmailBUS
    {
        public static async Task<(bool IsSuccess, string? Code, string Message)> ProcessPasswordResetAsync(string email)
        {
            try
            {
                if (Validation.IsAnyEmpty(email))
                    return (false, "", "Vui lòng nhập địa chỉ email!");

                if (!Validation.IsValidEmail(email))
                    return (false, "", "Email không hợp lệ.\nVui lòng nhập lại địa chỉ email!");

                var (exists, checkMsg) = await EmailDAL.CheckEmailAsync(email);
                if (!exists)
                    return (false, "", checkMsg);

                var (success, code, sendMsg) = await EmailDAL.SendOtpAsync(email);
                return (success, code, sendMsg);
            }
            catch (Exception ex)
            {
                return (false, "", "Lỗi trong quá trình gửi mã xác thực: " + ex.Message);
            }
        }
    }
}
