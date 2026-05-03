# NT106_QuanLyQuanCafe_Nhom2
Phần mềm Quản lý Quán Cà Phê
<div align="center">

# ☕ Phần mềm Quản lý Quán Cà Phê
### NT106_QuanLyQuanCafe_Nhom2

<p><b>Mục tiêu:</b> Hệ thống phần mềm toàn diện giúp tối ưu hóa quy trình bán hàng (POS), quản lý bàn, theo dõi kho nguyên liệu, chăm sóc khách hàng và thống kê doanh thu cho mô hình quán cà phê.</p>

</div>

---

## 🔸 Tóm tắt nhanh
- **Hệ thống 2 thành phần**: 
- **Nghiệp vụ Bán hàng (POS)**: Quản lý order, sơ đồ bàn, thanh toán đa phương thức (Tiền mặt, Thẻ, QR, Hóa đơn ĐT).
- **Quản lý Vận hành**: Quản lý menu, kho nguyên liệu (nhập/xuất/kiểm kê), khách hàng (tích điểm).
- **Quản lý Nhân sự**: Phân quyền chi tiết (Admin, Thu ngân, Pha chế), chấm công, tính lương.
- **Báo cáo & Thống kê**: Báo cáo doanh thu, lợi nhuận, tồn kho nguyên liệu trực quan.

## Nhóm phát triển (NT106 - UIT)
| STT | Họ và tên | MSSV | Vai trò |
|:---:|:---:|:---:|:---|
| 1 | **24520655** | Đào Quốc Huy |
| 2 | **24520229** | Trà Chí Chung |

## Tính năng chính

### Quản lý Bán hàng & Đơn hàng (POS)
- Tạo order nhanh chóng, tùy chỉnh món (thêm topping, size, mức đá/đường).
- Chỉnh sửa, cập nhật trạng thái hoặc hủy đơn hàng (có ghi nhận log).
- In bill thanh toán và gửi lệnh in trực tiếp đến quầy pha chế.

### Quản lý Bàn & Không gian
- Hiển thị sơ đồ bàn trực quan theo khu vực (Tầng 1, Tầng 2, Sân vườn...).
- Cập nhật trạng thái bàn realtime (Trống, Đang phục vụ, Đã đặt trước).
- Hỗ trợ thao tác: Ghép bàn, chuyển bàn, tách bill dễ dàng.

### Quản lý Thực đơn (Menu)
- Thêm, sửa, xóa các món nước/bánh.
- Quản lý danh mục (Cà phê, Trà sữa, Nước ép...).
- Cập nhật giá bán linh hoạt, cài đặt định mức nguyên liệu (Recipe/BOM) cho từng món.

### Quản lý Kho nguyên liệu
- Quản lý danh mục nguyên liệu (Cà phê hạt, sữa, đường, ly, ống hút...).
- Lập phiếu nhập/xuất kho, theo dõi tồn kho theo thời gian thực.
- Tự động trừ kho nguyên liệu khi có đơn hàng hoàn tất.
- Tính năng kiểm kê kho định kỳ, cảnh báo nguyên liệu sắp hết.

### Thanh toán & Khách hàng
- Hỗ trợ đa dạng thanh toán: Tiền mặt, Thẻ ngân hàng, quét mã QR (Momo, VNPay).
- Tích hợp xuất hóa đơn điện tử.
- **CRM mini:** Quản lý thông tin khách hàng, hạng thẻ, tích điểm đổi quà, áp dụng mã ưu đãi (Voucher/Coupon) và ghi nhận phản hồi.

### Quản lý Nhân viên
- Phân quyền (RBAC) chặt chẽ: Quản lý (Admin), Thu ngân (Cashier), Pha chế (Barista).
- Quản lý ca làm việc, theo dõi lịch sử thao tác của từng nhân viên.
- Chấm công, tính lương cơ bản dựa trên ca làm việc.

### Báo cáo & Thống kê
- Dashboard trực quan về doanh thu, lợi nhuận theo ngày/tháng/năm.
- Thống kê các món bán chạy nhất (Best-sellers).
- Báo cáo chi phí nguyên liệu, chênh lệch kho.
- Xuất báo cáo ra file Excel/PDF.

---

## Kiến trúc hệ thống
- `Coffee_Management`: Ứng dụng desktop WinForms cho POS và nghiệp vụ vận hành.
- `Server/ChatServer`: ASP.NET Core SignalR server cho chat/realtime event.
- `backend`: Firebase Cloud Functions cho API và các tác vụ backend.

### Ranh giới trách nhiệm
- **Desktop app**: giao diện, thao tác nghiệp vụ, gửi/nhận tín hiệu realtime.
- **ChatServer**: nhận broadcast từ client qua `/chathub`.
- **Firebase Functions**: xác thực, API quản lý dữ liệu, xử lý tác vụ nền.

## Chạy local

### 1) Desktop app
- Mở `Coffee_Management/Coffee_Management.sln` bằng Visual Studio và chạy project `GUI`.

### 2) Chat server
- Mở terminal tại `Server/ChatServer` và chạy:
  - `dotnet run`

### 3) Firebase Functions
- Mở terminal tại `backend` và chạy:
  - `npm install`
  - `npm run serve`

## Cấu hình bảo mật
- Không hardcode secret trong mã nguồn.
- Lưu các key/Firebase credential bằng biến môi trường hoặc secret manager, không commit trực tiếp vào repo.
