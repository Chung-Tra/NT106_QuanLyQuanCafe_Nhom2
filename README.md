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

## Tính năng

### Bán hàng (POS)

- Tạo và quản lý đơn hàng, cập nhật trạng thái realtime
- Sơ đồ bàn trực quan (trống / đang phục vụ / đã đặt)
- Thanh toán đa phương thức: tiền mặt, thẻ, QR (Momo, VNPay)

### Thực đơn & Kho

- Quản lý món (thêm, sửa, xóa theo danh mục)
- Nhập kho & phiếu nhập (Manager: màn **Sản phẩm & Thực đơn** → **Quản lý kho**, phiếu nhập tay hoặc nhập chi tiết từ Excel/CSV)
- Nguyên liệu / tồn kho / cảnh báo thấp — module UI trong `GUI/Warehouse/` vẫn dùng được khi gắn vào màn quản lý
- Tự động gợi ý nhập hàng (Smart Restock) — theo thiết kế module kho

### Nhân sự

- Phân quyền RBAC: **Admin / Manager / Barista / OrderStaff / Security** — **không** còn tài khoản đăng nhập riêng “thủ kho”; tài khoản cũ `stockkeeper` được app xử lý như **Manager** để không mất menu (nên cập nhật `role` trong Firebase cho đồng bộ).
- Chấm công, xin nghỉ, tính lương
- Chat nội bộ giữa nhân viên

### Báo cáo

- Dashboard doanh thu theo ngày/tháng
- Thống kê món bán chạy, chi phí nguyên liệu

### Khách hàng (CRM)

- Quản lý hồ sơ khách hàng, tích điểm đổi quà
- Ghi nhận và phản hồi feedback

---

## Tài liệu