using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DTO;
using DAL;

namespace BUS
{
    public class EmployeeBUS
    {
        public static async Task<bool> AddEmployeeAsync(EmployeeDTO emp)
        {
            if (Validation.IsAnyEmpty(emp.Email, emp.Password, emp.FullName, emp.PhoneNumber, emp.HireDate, emp.Role))
                throw new Exception("Vui lòng nhập đầy đủ thông tin!");

            if (!Validation.IsValidEmail(emp.Email))
                throw new Exception("Địa chỉ email không hợp lệ.\nVui lòng nhập lại địa chỉ email!");

            if (!Validation.IsValidPassword(emp.Password))
                throw new Exception("Mật khẩu phải dài ít nhất 8 ký tự, bao gồm chữ hoa, chữ thường, chữ số và một ký tự đặc biệt.");

            if (!Validation.IsValidPhoneNumber(emp.PhoneNumber))
                throw new Exception("Số điện thoại không hợp lệ.\nVui lòng nhập lại số điện thoại hợp lệ!");

            if (!Validation.IsValidHireDate(emp.HireDate))
                throw new Exception("Ngày bắt đầu làm việc không hợp lệ (ví dụ: YYYY-MM-DD)!");

            var (success, message) = await EmployeeDAL.AddAsync(emp);
            if (!success) throw new Exception(message);
            Audit.Log("Thêm nhân viên", emp.FullName ?? emp.Email ?? "");
            return true;
        }

        public static async Task<List<EmployeeDTO>> GetAllEmployeesAsync()
        {
            var dict = await EmployeeDAL.GetAllAsync();
            var list = new List<EmployeeDTO>();
            foreach (var kvp in dict)
            {
                kvp.Value.EmployeeId = kvp.Key;
                list.Add(kvp.Value);
            }
            return list;
        }

        public static async Task<(bool Success, string Message)> UpdateEmployeeAsync(string empId, EmployeeDTO data)
        {
            if (Validation.IsAnyEmpty(empId))
                return (false, "Không tìm thấy mã nhân viên.");
            if (Validation.IsAnyEmpty(data.FullName, data.PhoneNumber, data.Role, data.Status))
                return (false, "Vui lòng điền đầy đủ thông tin bắt buộc.");
            if (!Validation.IsValidPhoneNumber(data.PhoneNumber))
                return (false, "Số điện thoại không hợp lệ.\nVui lòng nhập lại số điện thoại hợp lệ!");

            var r = await EmployeeDAL.UpdateAsync(empId, data);
            if (r.Success) Audit.Log("Sửa thông tin", "NV " + (data.FullName ?? empId));
            return r;
        }

        // Cập nhật riêng ảnh đại diện (partial) — không yêu cầu đủ các field bắt buộc.
        public static async Task<(bool Success, string Message)> UpdateAvatarAsync(string empId, string avatarUrl)
        {
            if (Validation.IsAnyEmpty(empId))
                return (false, "Không tìm thấy mã nhân viên.");
            return await EmployeeDAL.UpdateAsync(empId, new EmployeeDTO { AvatarUrl = avatarUrl });
        }

        public static async Task<(bool Success, string Message)> LockEmployeeAsync(string empId, string authUid)
        {
            if (Validation.IsAnyEmpty(empId, authUid))
                return (false, "Không tìm thấy mã nhân viên hoặc mã xác thực.");
            var r = await EmployeeDAL.LockAsync(empId, authUid);
            if (r.Success) Audit.Log("Khóa tài khoản", "NV " + empId);
            return r;
        }

        public static async Task<(bool Success, string Message)> DeleteEmployeeAsync(string empId, string authUid)
        {
            if (Validation.IsAnyEmpty(empId, authUid))
                return (false, "Lỗi: Không tìm thấy mã nhân viên hoặc mã xác thực (AuthUid) để xóa.");
            var r = await EmployeeDAL.DeleteAsync(empId, authUid);
            if (r.Success) Audit.Log("Xóa", "NV " + empId);
            return r;
        }
    }
}
