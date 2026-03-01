# QLCafe — Phần mềm Quản lý Quán Cà Phê

> Đồ án môn NT106 — Lập trình mạng cơ bản | UIT

Hệ thống quản lý quán cà phê gồm ứng dụng desktop WinForms, REST API backend Express.js và realtime chat server SignalR, kết nối với Firebase Realtime Database.

---

## Nhóm phát triển


| STT |   Họ và tên   |   MSSV   |  Vai trò  |
| --- | ------------- | -------- | --------- |
| 1   | Đào Quốc Huy  | 24520655 | Fullstack |
| 2   | Trà Chí Chung | 24520229 | Fullstack |


---

## Kiến trúc hệ thống

```
client/ (WinForms C#)
    │
    ├── HTTP REST ──────▶ backend/ (Express.js + Firebase Admin SDK)
    │                           │
    └── SignalR ────────▶ server/ (ASP.NET Core SignalR)
                                │
                         Firebase Realtime Database
```


| Component  | Công nghệ              | Vai trò                              |
| ---------- | ---------------------- | ------------------------------------ |
| `client/`  | C# WinForms (.NET 8)   | Giao diện desktop cho tất cả vai trò |
| `backend/` | Node.js + Express      | REST API, xác thực, gửi email        |
| `server/`  | ASP.NET Core + SignalR | Realtime chat giữa nhân viên         |


---

## Tính năng theo vai trò

### Dùng chung (mọi vai trò)

- Đăng nhập / Quên mật khẩu (OTP qua email) / Xác thực email
- Chat nội bộ thời gian thực (SignalR)
- Trang cá nhân: xem/sửa thông tin, đổi ảnh đại diện, đổi mật khẩu
- Đơn xin nghỉ phép
- Lịch sử chấm công
- Check-in / check-out chấm công
- Trung tâm thông báo realtime qua SignalR (click → điều hướng đúng trang)
- Nhật ký kiểm toán (audit log) cho thao tác nhạy cảm — bắt buộc nhập lý do

### Admin

- Quản lý nhân viên (thêm / sửa / khóa tài khoản)
- Dashboard doanh thu / lợi nhuận / KPI
- Quản lý Manager, bảng lương, feedback, thông báo, broadcast, điểm danh
- Tiền chi chi tiết; kích hoạt quyền quản lý khi Manager nghỉ
- Xuất báo cáo Excel / PDF + tự gửi email cuối ngày
- Nhận audit log từ Manager

### Manager

- Quản lý món (CRUD theo danh mục)
- Quản lý kho / phiếu nhập (nhập tay hoặc từ Excel·CSV)
- Quản lý nhân viên trong ca
- Tổng quan ca, đơn hàng & hóa đơn, thất thoát, feedback, thông báo
- Duyệt đơn xin nghỉ; khóa món khi hết nguyên liệu; duyệt phiếu hủy nguyên liệu
- Tự trừ nguyên liệu theo công thức (BOM) mỗi khi bán
- Happy hour / combo / khuyến mãi theo khung giờ
- Xếp lịch ca làm (scheduling) + cảnh báo thiếu người

### Order Staff (nhân viên order)

- POS bán hàng
- CRM khách hàng, quản lý tiền mặt đầu/cuối ca, tổng quan ca
- Bill kèm QR feedback (độc nhất theo orderId)
- POS nâng cao: gộp / tách / chuyển bàn, tách hóa đơn, voucher
- Thanh toán VietQR động (Momo / VNPay / ngân hàng)
- Loyalty: tích điểm theo SĐT, hạng thành viên, đổi quà
- Đặt bàn trước (reservation) + nhắc qua email
- Đặt món tại bàn bằng QR → đơn bay realtime vào POS

### Barista (pha chế)

- Màn hình bếp (KDS), cẩm nang pha chế, báo động nguyên liệu
- KDS nhận đơn realtime xuyên suốt (nối Self-Ordering qua SignalR), tick "xong" cập nhật ngay

### Security (bảo vệ)

- Quản lý bãi xe, SOS an ninh + log sự cố
- Sơ đồ bãi xe realtime đồng bộ đa thiết bị (SignalR)

---

## Tài liệu
