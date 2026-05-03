using DTO;
using Firebase.Database;
using Firebase.Database.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
// ĐÃ XÓA dòng System.Windows.Forms để hết lỗi đỏ

namespace DAL
{
    public class NhapKhoDAL
    {
        private readonly string FireBaseUrl = "https://qlcafe-b621b-default-rtdb.asia-southeast1.firebasedatabase.app/";
        private readonly FirebaseClient _client;

        public NhapKhoDAL()
        {
            _client = new FirebaseClient(FireBaseUrl);
        }

        public async Task<bool> ThemPhieuNhapAsync(NhapKhoDTO phieuNhap)
        {
            try
            {
                
                string maMoi = await TaoMaNhapKhoMoi();

                
                await _client
                    .Child("nhap_kho")
                    .Child(maMoi) 
                    .PutAsync(phieuNhap); 

                return true;
            }
            catch (Exception ex)
            {
                
                throw new Exception($"Lỗi khi thêm phiếu nhập lên Firebase:\n{ex.Message}");
            }
        }

        public async Task<List<NhanVienDTO>> GetAllNhanVienAsync()
        {
            try
            {
                var nhanViens = await _client.Child("nhan_vien").OnceAsync<NhanVienDTO>();

                return nhanViens.Select(item => new NhanVienDTO
                {
                    EmployeeId = item.Key,
                    FullName = item.Object.FullName
                }).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi lấy danh sách nhân viên Firebase:\n{ex.Message}");
            }
        }

        private async Task<string> TaoMaNhapKhoMoi()
        {
            try
            {
                // Lấy tất cả dữ liệu hiện có trong node "nhap_kho"
                var danhSachPhieu = await _client.Child("nhap_kho").OnceAsync<object>();

                int maxId = 0;

                foreach (var phieu in danhSachPhieu)
                {
                    string key = phieu.Key; // Lấy cái tên (vd: nk_001, nk_002)

                    if (key.StartsWith("nk_"))
                    {
                        // Cắt bỏ chữ "nk_", chỉ lấy phần số "001", "002"
                        string numberPart = key.Substring(3);

                        // Chuyển phần số thành kiểu int để so sánh
                        if (int.TryParse(numberPart, out int currentId))
                        {
                            if (currentId > maxId)
                            {
                                maxId = currentId; // Cập nhật số lớn nhất
                            }
                        }
                    }
                }

                // Cộng thêm 1 để ra mã tiếp theo
                int nextId = maxId + 1;

                // Định dạng lại thành chữ (vd: nếu là 3 thì thành nk_003, nếu 15 thì thành nk_015)
                return $"nk_{nextId:D3}";
            }
            catch
            {
                // Nếu chưa có dữ liệu nào hoặc lỗi mạng, tự động bắt đầu bằng nk_001
                return "nk_001";
            }
        }
    }
}