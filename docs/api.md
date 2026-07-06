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

Tạo mã OTP 8 số, gửi về email và lưu **hash** của mã ở server.

> 🔒 **Bảo mật:** endpoint **không** trả mã OTP về client — mã chỉ có trong email.

**Body:**

```json
{ "toEmail": "user@example.com" }
```

**Response 200:** `{ "message": "Verification code sent!" }`

---

### POST `/auth/otp/verify`

Xác thực mã OTP. Nếu đúng, server phát một **reset-token dùng một lần** để đổi mật khẩu.

**Body:**

```json
{ "email": "user@cafe.com", "code": "12345678" }
```

**Response 200:** `{ "message": "OTP verified", "resetToken": "<one-time-token>" }`
**Response 4xx:** `{ "error": "Mã không đúng hoặc đã hết hạn" }`

---

### PUT `/auth/password`

Đặt lại mật khẩu **sau khi quên** — yêu cầu `resetToken` hợp lệ từ `/auth/otp/verify`.
Mật khẩu mới được kiểm tra độ mạnh ở server (≥ 8 ký tự, có chữ hoa, chữ thường, số và ký tự đặc biệt).

**Body:**

```json
{
  "email": "user@cafe.com",
  "newPassword": "NewPass@123",
  "resetToken": "<one-time-token>"
}
```

**Response 200:** `{ "message": "Success" }`

---

### PUT `/auth/change-password`

Đổi mật khẩu **khi đã biết mật khẩu cũ** (trong màn hồ sơ). Không cần OTP.

**Body:**

```json
{
  "email": "user@cafe.com",
  "oldPassword": "OldPass@123",
  "newPassword": "NewPass@123"
}
```

**Response 200:** `{ "message": "Success" }`
**Response 401:** `{ "error": "Mật khẩu hiện tại không đúng." }`

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

## Ingredients (Nguyên liệu)

> Cần `Authorization: Bearer <token>`. Thêm/sửa/xóa yêu cầu **Manager/Admin**.

| Method | Path | Mô tả |
|--------|------|-------|
| GET | `/ingredients` | Danh sách nguyên liệu (`/nguyen_lieu`) |
| POST | `/ingredients` | Thêm nguyên liệu mới |
| PUT | `/ingredients/:id` | Cập nhật (tồn kho, giá nhập…) |
| DELETE | `/ingredients/:id` | Xóa nguyên liệu |

**Body (POST/PUT):**

```json
{
  "ten_nguyen_lieu": "Sữa tươi",
  "don_vi": "lít",
  "gia_nhap": 28000,
  "ton_kho": 40,
  "ton_kho_toi_thieu": 10
}
```

---

## Inventory (Phiếu nhập kho)

> Cần `Authorization: Bearer <token>`. Tạo phiếu yêu cầu **Manager/Admin**.

### GET `/inventory`

Danh sách phiếu nhập kho (`/nhap_kho`).

### POST `/inventory`

Tạo phiếu nhập kho mới (tự sinh id `nk_xxx`). Server **tính lại** `thanh_tien` từng dòng + tổng phiếu
(không tin client) và **tự cộng `so_luong` vào `ton_kho`** của từng nguyên liệu trong `/nguyen_lieu` (transaction).

**Body:**

```json
{
  "nhanvien_id": "nv_006",
  "ngay_nhap": 20260706,
  "ghi_chu": "Nhập đầu tháng",
  "thanh_tien": 1500000,
  "ds_nl": {
    "nl_001": { "gia_nhap": 150000, "so_luong": 10, "thanh_tien": 1500000 }
  }
}
```

**Response 201:** `{ "success": true, "id": "nk_007" }`

---

## Upload (Ảnh)

### POST `/upload`

Tải một ảnh lên **Firebase Storage** và nhận URL công khai. Bất kỳ nhân viên đã đăng nhập nào cũng dùng được.

- Header: `Authorization: Bearer <token>`, `Content-Type: multipart/form-data`
- Field file: `file` (chỉ ảnh, tối đa **5 MB**)

**Response 201:**

```json
{ "success": true, "url": "https://firebasestorage.googleapis.com/v0/b/.../o/..." }
```

**Response 400:** `{ "error": "Không có file được tải lên" }` hoặc file không phải ảnh.

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

## Generic Resources (CRUD chung)

Toàn bộ node còn lại của hệ thống được phục vụ bởi **một factory CRUD chung**
([`resources.controller.js`](../backend/src/controllers/resources.controller.js) + [`resources.routes.js`](../backend/src/routes/resources.routes.js)).
Mỗi resource có đủ 4 endpoint, **đều cần** `Authorization: Bearer <token>`:

```
GET    /api/<resource>        → toàn bộ node (object keyed by id)
POST   /api/<resource>        → thêm bản ghi (tự sinh id theo prefix), trả { success, id }
PUT    /api/<resource>/:id    → cập nhật bản ghi
DELETE /api/<resource>/:id    → xóa bản ghi
```

| Resource | Node RTDB | Prefix id |
|----------|-----------|-----------|
| `tables` | `ban` | `ban_` |
| `orders` | `don_hang` | `dh_` |
| `payments` | `thanh_toan` | `tt_` |
| `customers` | `khach_hang` | `kh_` |
| `feedback` | `feedback` | `fb_` |
| `attendance` | `cham_cong` | `cc_` |
| `salaries` | `luong` | `luong_` |
| `leave-requests` | `xin_nghi` | `xn_` |
| `notifications` | `thong_bao` | `tb_` |
| `parking` | `bai_xe` | `bx_` |
| `incidents` | `su_co` | `sc_` |
| `warnings` | `canh_bao` | `cb_` |
| `recipes` | `cong_thuc` | `ct_` |
| `promotions` | `khuyen_mai` | `km_` |
| `expenses` | `chi_phi` | `cp_` |
| `losses` | `that_thoat` | `loss_` |
| `reservations` | `dat_ban` | `db_` |
| `audit-logs` | `nhat_ky` | `log_` |
| `broadcasts` | `thong_bao_chung` | `bc_` |
| `schedules` | `lich_lam_viec` | `sch_` |
| `shift-registers` | `dang_ky_ca` | `sr_` |
| `bug-reports` | `bao_loi` | `bug_` |
| `point-logs` | `diem_log` | `pl_` |

Cấu trúc field của từng node xem trong [database.md](database.md). Ví dụ:

```http
GET /api/promotions        → { "km_001": { ... }, "km_002": { ... } }
POST /api/reservations     → body ReservationDTO → { "success": true, "id": "db_008" }
DELETE /api/audit-logs/log_003
```

---

## Health Check

### GET `/health`

Kiểm tra server đang chạy. **Không** thuộc prefix `/api` (đường dẫn gốc `http://localhost:3000/health`) và không cần token.

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


