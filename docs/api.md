# API Reference

Base URL (local): `http://localhost:3000/api`  
Base URL (production): `https://asia-southeast1-<project>.cloudfunctions.net/api`

---

## Auth

### POST `/auth/login`

Đăng nhập nhân viên.

**Body:**

```json
{
  "email": "admin@cafe.com",
  "password": "123456"
}
```

**Response 200:**

```json
{
  "token": "<firebase-id-token>",
  "user": {
    "EmployeeId": "nv_001",
    "ho_ten": "Nguyễn Văn A",
    "email": "admin@cafe.com",
    "vai_tro": "admin",
    "trang_thai": "active"
  }
}
```

---

### POST `/auth/check-email`

Kiểm tra email đã tồn tại trong hệ thống chưa.

**Body:**

```json
{ "email": "test@cafe.com" }
```

**Response 200:** `{ "exists": true }`  
**Response 404:** `{ "exists": false }`

---

### POST `/auth/otp/generate`

Tạo mã OTP 8 số và gửi về email.

**Body:**

```json
{ "toEmail": "user@example.com" }
```

**Response 200:**

```json
{
  "message": "Verification code sent!",
  "code": "12345678"
}
```

---

### PUT `/auth/password`

Đổi mật khẩu (yêu cầu `APP_SECRET_KEY`).

**Body:**

```json
{
  "email": "user@cafe.com",
  "newPassword": "newpass123",
  "secretKey": "<APP_SECRET_KEY>"
}
```

---

## Employees

> Tất cả endpoint cần header: `Authorization: Bearer <token>`

### GET `/employees`

Lấy danh sách nhân viên.

- Admin/Manager: trả toàn bộ danh sách
- Vai trò khác: chỉ trả danh sách Manager

**Response 200:**

```json
{
  "nv_001": { "ho_ten": "Nguyễn Văn A", "vai_tro": "admin", ... },
  "nv_002": { "ho_ten": "Trần Thị B", "vai_tro": "barista", ... }
}
```

---

### POST `/employees`

Thêm nhân viên mới. *(Yêu cầu Manager/Admin)*

**Body:**

```json
{
  "ho_ten": "Lê Văn C",
  "email": "levanc@cafe.com",
  "Password": "init123",
  "vai_tro": "barista",
  "so_dien_thoai": "0909123456"
}
```

**Response 201:**

```json
{ "success": true, "employeeId": "nv_003" }
```

---

### PUT `/employees/:id`

Cập nhật thông tin nhân viên. *(Yêu cầu Manager/Admin)*

**Body:** Các field cần cập nhật (không bao gồm `email`, `AuthUid`)

---

### DELETE `/employees/:id`

Xóa nhân viên. *(Yêu cầu Manager/Admin)*

**Body:**

```json
{ "authUid": "<firebase-auth-uid>" }
```

---

### PATCH `/employees/:id/lock`

Khóa tài khoản nhân viên. *(Yêu cầu Manager/Admin)*

**Body:**

```json
{ "authUid": "<firebase-auth-uid>" }
```

---

## Foods

> Tất cả endpoint cần header: `Authorization: Bearer <token>`

### GET `/foods`

Lấy danh sách món.

**Response 200:**

```json
{
  "mon_001": { "TenMon": "Cà phê đen", "GiaBan": 25000, "DanhMuc": "cafe" },
  "mon_002": { "TenMon": "Trà sữa trân châu", "GiaBan": 45000, "DanhMuc": "tea" }
}
```

---

### POST `/foods`

Thêm món mới. *(Yêu cầu Manager/Admin)*

**Body:**

```json
{
  "TenMon": "Bạc xỉu",
  "GiaBan": 30000,
  "DanhMuc": "cafe",
  "MoTa": "Cà phê sữa đặc"
}
```

**Response 201:**

```json
{ "success": true, "foodId": "mon_003" }
```

---

### PUT `/foods/:id`

Cập nhật món. *(Yêu cầu Manager/Admin)*

**Body:** Các field cần cập nhật (không bao gồm `Id`)

---

### DELETE `/foods/:id`

Xóa món và tự động đánh lại số thứ tự. *(Yêu cầu Manager/Admin)*

---

## Chat

> Tất cả endpoint cần header: `Authorization: Bearer <token>`

### GET `/chat/messages?roomId=<roomId>`

Lấy lịch sử tin nhắn của một phòng.

**Query:** `roomId` — ID phòng chat (vd: `room_all`, `room_nv001_nv002`)

**Response 200:**

```json
[
  { "nguoi_gui": "nv_001", "noi_dung": "Hello!", "thoi_gian": 1746536400000 },
  { "nguoi_gui": "nv_002", "noi_dung": "Hi!", "thoi_gian": 1746536410000 }
]
```

---

### POST `/chat/messages`

Lưu tin nhắn vào database.

**Body:**

```json
{
  "roomId": "room_all",
  "chatData": {
    "nguoi_gui": "nv_001",
    "noi_dung": "Xin chào mọi người!"
  }
}
```

---

## Health Check

### GET `/health`

Kiểm tra server đang chạy.

**Response 200:** `{ "status": "ok" }`

---

## HTTP Status Codes


| Code | Ý nghĩa                             |
| ---- | ----------------------------------- |
| 200  | Thành công                          |
| 201  | Tạo mới thành công                  |
| 400  | Request thiếu/sai dữ liệu           |
| 401  | Chưa đăng nhập / token không hợp lệ |
| 403  | Không đủ quyền                      |
| 404  | Không tìm thấy                      |
| 500  | Lỗi server                          |


