using Newtonsoft.Json;

namespace DTO
{
    // Các DTO cho node MỚI (màn phụ). Field khớp cột lưới hiện có để wire tối thiểu.

    /// <summary>/point-logs/{pl_id} — 1 giao dịch tích/đổi điểm của 1 khách hàng.</summary>
    public class PointLogDTO
    {
        [JsonIgnore] public string? Id { get; set; }
        [JsonProperty("khach_id")] public string? CustomerId { get; set; }
        [JsonProperty("delta")] public int Delta { get; set; }        // +tích / -đổi
        [JsonProperty("ghi_chu")] public string? Note { get; set; }
        [JsonProperty("thoi_gian")] public long Timestamp { get; set; }
    }

    /// <summary>/khuyen_mai/{km_id} — gộp 3 loại: happy_hour, combo, voucher (phân biệt bằng "loai").</summary>
    public class PromotionDTO
    {
        [JsonIgnore] public string? Id { get; set; }
        [JsonProperty("loai")] public string? Loai { get; set; } // happy_hour | combo | voucher
        [JsonProperty("ten")] public string? Ten { get; set; }
        // Happy hour
        [JsonProperty("khung_gio")] public string? KhungGio { get; set; }
        [JsonProperty("ngay_ap_dung")] public string? NgayApDung { get; set; }
        [JsonProperty("giam_pct")] public string? GiamPct { get; set; }
        // Combo
        [JsonProperty("bao_gom")] public string? BaoGom { get; set; }
        [JsonProperty("gia_goc")] public long GiaGoc { get; set; }
        [JsonProperty("gia_combo")] public long GiaCombo { get; set; }
        [JsonProperty("tiet_kiem")] public long TietKiem { get; set; }
        // Voucher
        [JsonProperty("ma")] public string? Ma { get; set; }
        [JsonProperty("giam")] public string? Giam { get; set; }
        [JsonProperty("han_su_dung")] public string? HanSuDung { get; set; }
        [JsonProperty("da_dung")] public int DaDung { get; set; }
        [JsonProperty("con_lai")] public int ConLai { get; set; }
        [JsonProperty("trang_thai")] public string? TrangThai { get; set; }
    }

    /// <summary>/chi_phi/{cp_id}</summary>
    public class ExpenseDTO
    {
        [JsonIgnore] public string? Id { get; set; }
        [JsonProperty("ngay")] public string? Ngay { get; set; }
        [JsonProperty("danh_muc")] public string? DanhMuc { get; set; }
        [JsonProperty("mo_ta")] public string? MoTa { get; set; }
        [JsonProperty("so_tien")] public long SoTien { get; set; }
        [JsonProperty("nguoi_chi")] public string? NguoiChi { get; set; }
        [JsonProperty("chung_tu")] public string? ChungTu { get; set; }
        [JsonProperty("ghi_chu")] public string? GhiChu { get; set; }
        [JsonProperty("thoi_gian")] public long Timestamp { get; set; }
    }

    /// <summary>/that_thoat/{loss_id}</summary>
    public class LossDTO
    {
        [JsonIgnore] public string? Id { get; set; }
        [JsonProperty("khoan_muc")] public string? KhoanMuc { get; set; }
        [JsonProperty("so_luong")] public string? SoLuong { get; set; }
        [JsonProperty("gia_tri")] public decimal GiaTri { get; set; }
        [JsonProperty("nguyen_nhan")] public string? NguyenNhan { get; set; }
        [JsonProperty("nguoi_phat_hien")] public string? NguoiPhatHien { get; set; }
        [JsonProperty("ngay")] public string? Ngay { get; set; }
        [JsonProperty("thoi_gian")] public long Timestamp { get; set; }
    }

    /// <summary>/dat_ban/{db_id}</summary>
    public class ReservationDTO
    {
        [JsonIgnore] public string? Id { get; set; }
        [JsonProperty("ho_ten")] public string? HoTen { get; set; }
        [JsonProperty("so_dien_thoai")] public string? SoDienThoai { get; set; }
        [JsonProperty("ngay_gio")] public string? NgayGio { get; set; }
        [JsonProperty("ban")] public string? Ban { get; set; }
        [JsonProperty("so_khach")] public int SoKhach { get; set; }
        [JsonProperty("ghi_chu")] public string? GhiChu { get; set; }
        [JsonProperty("trang_thai")] public string? TrangThai { get; set; }
        [JsonProperty("thoi_gian")] public long Timestamp { get; set; }
    }

    /// <summary>/nhat_ky/{log_id}</summary>
    public class AuditLogDTO
    {
        [JsonIgnore] public string? Id { get; set; }
        [JsonProperty("thoi_gian")] public long Timestamp { get; set; }
        [JsonProperty("nhanvien_id")] public string? EmployeeId { get; set; }
        [JsonProperty("ten")] public string? Ten { get; set; }
        [JsonProperty("vai_tro")] public string? VaiTro { get; set; }
        [JsonProperty("thao_tac")] public string? ThaoTac { get; set; }
        [JsonProperty("doi_tuong")] public string? DoiTuong { get; set; }
        [JsonProperty("ly_do")] public string? LyDo { get; set; }
        [JsonProperty("ip")] public string? Ip { get; set; }
    }

    /// <summary>/thong_bao_chung/{bc_id}</summary>
    public class BroadcastDTO
    {
        [JsonIgnore] public string? Id { get; set; }
        [JsonProperty("thoi_gian")] public long Timestamp { get; set; }
        [JsonProperty("nguoi_gui_id")] public string? SenderId { get; set; }
        [JsonProperty("nguoi_nhan")] public string? NguoiNhan { get; set; }
        [JsonProperty("tieu_de")] public string? TieuDe { get; set; }
        [JsonProperty("noi_dung")] public string? NoiDung { get; set; }
        [JsonProperty("muc_do")] public string? MucDo { get; set; }
        [JsonProperty("da_doc")] public bool DaDoc { get; set; }
        [JsonProperty("trang_thai")] public string? TrangThai { get; set; }
    }

    /// <summary>/lich_lam_viec/{sch_id} — 1 dòng/nhân viên cho 1 tuần.</summary>
    public class ScheduleDTO
    {
        [JsonIgnore] public string? Id { get; set; }
        [JsonProperty("nhanvien_id")] public string? EmployeeId { get; set; }
        [JsonProperty("ten")] public string? Ten { get; set; }
        [JsonProperty("tuan")] public string? Tuan { get; set; } // dd/MM/yyyy đầu tuần
        [JsonProperty("t2")] public string? T2 { get; set; }
        [JsonProperty("t3")] public string? T3 { get; set; }
        [JsonProperty("t4")] public string? T4 { get; set; }
        [JsonProperty("t5")] public string? T5 { get; set; }
        [JsonProperty("t6")] public string? T6 { get; set; }
        [JsonProperty("t7")] public string? T7 { get; set; }
        [JsonProperty("cn")] public string? CN { get; set; }
    }

    /// <summary>/dang_ky_ca/{sr_id}</summary>
    public class ShiftDTO
    {
        [JsonIgnore] public string? Id { get; set; }
        [JsonProperty("loai")] public string? Loai { get; set; } // open | mine | swap
        [JsonProperty("ngay")] public string? Ngay { get; set; }
        [JsonProperty("ca")] public string? Ca { get; set; }
        [JsonProperty("gio")] public string? Gio { get; set; }
        [JsonProperty("nhanvien_id")] public string? EmployeeId { get; set; }
        [JsonProperty("doi_cho")] public string? DoiCho { get; set; }
        [JsonProperty("trang_thai")] public string? TrangThai { get; set; }
    }

    /// <summary>/bao_loi/{bug_id}</summary>
    public class BugReportDTO
    {
        [JsonIgnore] public string? Id { get; set; }
        [JsonProperty("tieu_de")] public string? TieuDe { get; set; }
        [JsonProperty("mo_ta")] public string? MoTa { get; set; }
        [JsonProperty("loai")] public string? Loai { get; set; }
        [JsonProperty("muc_do")] public string? MucDo { get; set; }
        [JsonProperty("man_hinh")] public string? ManHinh { get; set; }
        [JsonProperty("nguoi_gui_id")] public string? SenderId { get; set; }
        [JsonProperty("thoi_gian")] public long Timestamp { get; set; }
        [JsonProperty("trang_thai")] public string? TrangThai { get; set; }
    }
}
