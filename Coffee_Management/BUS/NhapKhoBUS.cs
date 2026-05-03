using DAL;
using DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BUS
{
    public class NhapKhoBUS
    {
        private readonly NhapKhoDAL _dal = new NhapKhoDAL();
        private readonly NguyenLieuDAL _nguyenLieuDal = new NguyenLieuDAL();

        // Thêm hàm này vào class NhapKhoBUS
        public async Task<List<NguyenLieuDTO>> LayDanhSachNguyenLieu()
        {
            return await _nguyenLieuDal.GetAllNguyenLieuAsync();
        }
        // 1. Hàm lấy danh sách nhân viên cho ComboBox
        public async Task<List<NhanVienDTO>> LấyDanhSachNhanVien()
        {
            // Giả sử dưới NhapKhoDAL bạn đã viết hàm GetAllNhanVienAsync() 
            // đọc từ node "nhan_vien" trên Firebase
            return await _dal.GetAllNhanVienAsync();
        }

        // 2. Hàm xử lý nghiệp vụ tạo phiếu nhập
        public async Task<string> TaoPhieuNhap(NhapKhoDTO phieu)
        {
            // Kiểm tra dữ liệu đầu vào
            if (string.IsNullOrEmpty(phieu.NhanVienId))
                return "Vui lòng chọn nhân viên thực hiện!";

            if (phieu.DanhSachNL == null || phieu.DanhSachNL.Count == 0)
                return "Vui lòng nhập ít nhất một nguyên liệu!";

            // Tính toán thành tiền từng món và tổng tiền phiếu
            long tongTienPhieu = 0;
            foreach (var kvp in phieu.DanhSachNL)
            {
                var chiTiet = kvp.Value;
                chiTiet.ThanhTien = chiTiet.GiaNhap * chiTiet.SoLuong;
                tongTienPhieu += chiTiet.ThanhTien;
            }
            phieu.TongTien = tongTienPhieu;

            // Gọi DAL đẩy lên Firebase
            bool kq = await _dal.ThemPhieuNhapAsync(phieu);
            return kq ? "Thành công" : "Lỗi: Không thể kết nối hoặc lưu dữ liệu lên Firebase.";
        }
    }
}