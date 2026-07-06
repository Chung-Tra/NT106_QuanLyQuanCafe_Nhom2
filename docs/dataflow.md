# Luồng dữ liệu hệ thống

Tài liệu mô tả chi tiết luồng dữ liệu của từng chức năng chính trong hệ thống QLCafe.

---

## Mục lục

1. [Đăng nhập](#1-đăng-nhập)
2. [Quên mật khẩu (OTP)](#2-quên-mật-khẩu-otp)
3. [Quản lý nhân viên (CRUD)](#3-quản-lý-nhân-viên-crud)
4. [Quản lý thực đơn (CRUD)](#4-quản-lý-thực-đơn-crud)
5. [Chat nội bộ (realtime)](#5-chat-nội-bộ-realtime)
6. [Tải lịch sử chat](#6-tải-lịch-sử-chat)
7. [Quản lý nguyên liệu (kho)](#7-quản-lý-nguyên-liệu-kho)
8. [Nhập kho](#8-nhập-kho)
9. [Phân quyền mỗi request](#9-phân-quyền-mỗi-request)

> Trên đây là sơ đồ chi tiết các luồng **lõi**. Danh mục **đầy đủ mọi luồng** của từng màn hình client
> (30+ màn, 14 dialog, ma trận BUS → endpoint → node) xem tại **[client-flows.md](client-flows.md)**.

---

## 1. Đăng nhập

```
GUI (Login.cs)
    │
    │  Nhập email + password
    ▼
BUS (AuthBUS.LoginBUS)
    │  Validate định dạng email, độ mạnh password
    ▼
DAL (AuthDAL.LoginAsync)
    │  POST /api/auth/login  { email, password }
    ▼
Backend (auth.controller.js → firebase-auth.service.js)
    │  signInWithEmailAndPassword(Firebase Auth REST API)
    │  Lấy thông tin nhân viên từ /nhan_vien
    ▼
Firebase Auth + Realtime DB
    │  Trả về: idToken, thông tin nhân viên
    ▼
Backend
    │  Response: { token, user }
    ▼
DAL → BUS
    │  Kiểm tra user.trang_thai == "active"
    │  Lưu GlobalSession.Token, GlobalSession.CurrentUser
    │  Set ExpiryTime = Now + 60 phút
    ▼
GUI
    │  Chuyển sang Dashboard tương ứng (Admin / Manager / ...)
    └──────────────────────────────────────────────────────────
```

---

## 2. Quên mật khẩu (OTP)

```
GUI (Auth/ConfirmEmail.cs)
    │  Nhập email
    ▼
BUS (EmailBUS) → DAL (EmailDAL)
    ├─▶ POST /api/auth/check-email  { email }
    │       Backend → Firebase DB /nhan_vien
    │       200: tồn tại · 404: không tồn tại → dừng
    └─▶ POST /api/auth/otp/generate  { toEmail }
            Backend (email.service.js + otp.service.js)
            │  Tạo mã OTP 8 số, gửi email (Nodemailer + Gmail)
            │  Lưu HASH của mã ở server — KHÔNG trả mã về client
            ▼  Response: { message: "Verification code sent!" }
GUI (Auth/VerifyCode.cs)
    │  Nhập mã OTP
    ▼
    POST /api/auth/otp/verify  { email, code }
    │  Server so khớp hash → phát reset-token dùng 1 lần
    ▼  Response: { resetToken }
GUI (Auth/ResetPassword.cs)
    │  Nhập mật khẩu mới + xác nhận (client kiểm sơ bộ)
    ▼
    PUT /api/auth/password  { email, newPassword, resetToken }
    │  Backend: kiểm độ mạnh Ở SERVER → tiêu reset-token
    │  auth.updateUser(uid, { password: newPassword })
    ▼
Firebase Auth cập nhật mật khẩu → quay lại Login
```

> 🔒 Toàn bộ so khớp OTP diễn ra **ở server**; mã không bao giờ rời khỏi email của người dùng.
> Đổi mật khẩu khi đã đăng nhập (biết mật khẩu cũ) dùng `PUT /api/auth/change-password` — xem [api.md](api.md).

---

## 3. Quản lý nhân viên (CRUD)

### 3a. Lấy danh sách

```
GUI (ucStaff_Manager.cs)
    │  Load sự kiện
    ▼
BUS (EmployeeBUS.GetAllEmployeesAsync)
    ▼
DAL (EmployeeDAL.GetAllAsync)
    │  GET /api/employees
    │  Header: Authorization: Bearer <token>
    ▼
Backend (auth.middleware → employees.controller)
    │  verifyIdToken → kiểm tra vai trò
    │  db.ref('nhan_vien').once('value')
    ▼
Firebase Realtime DB → /nhan_vien
    │  Trả về Dictionary<string, EmployeeDTO>
    ▼
BUS → Map EmployeeId = Firebase Key
    ▼
GUI → Hiển thị lên DataGridView
```

### 3b. Thêm nhân viên

```
GUI (AddEmployee.cs)
    │  Nhập thông tin
    ▼
BUS (EmployeeBUS.AddEmployeeAsync)
    │  Validate: email, password, phone, hireDate
    ▼
DAL (EmployeeDAL.AddAsync)
    │  POST /api/employees  { EmployeeDTO }
    │  Header: Authorization: Bearer <token>
    ▼
Backend
    │  auth.createUser({ email, password })     → Firebase Auth
    │  db.ref('nhan_vien/nv_xxx').set(data)     → Firebase DB
    │  Response: { success: true, employeeId }
    ▼
GUI → Reload danh sách
```

### 3c. Cập nhật / Khóa / Xóa

```
GUI → BUS (validate) → DAL
    │
    ├─ PUT  /api/employees/:id         → Cập nhật field có giá trị (partial update)
    ├─ PATCH /api/employees/:id/lock   → Disable Firebase Auth user
    └─ DELETE /api/employees/:id       → Xóa Auth user + xóa DB node
```

---

## 4. Quản lý thực đơn (CRUD)

```
GUI (ucProducts_Manager.cs)
    │
    ├─ GET    /api/foods                → Lấy danh sách món
    ├─ POST   /api/foods                → Thêm món mới
    ├─ PUT    /api/foods/:id            → Sửa thông tin món
    └─ DELETE /api/foods/:id            → Xóa món

Backend → db.ref('mon_uong')
```

Validate phía BUS:

- Tên món không được để trống
- Giá bán phải > 0

---

## 5. Chat nội bộ (realtime)

Luồng **GỬI** tin nhắn (phiên bản mới — server tự lưu):

```
GUI (Shared/ucInternalChat.cs)
    │  Nhập tin nhắn, nhấn Gửi
    ▼
ChatManager.SendMessageAsync
    │
    ▼
SignalR HubConnection
    │  InvokeAsync("SendMessageWithRoom", senderId, message, roomId)
    ▼
ChatServer (ChatHub.SendMessageWithRoom)
    │
    ├──▶ Clients.Group(roomId).SendAsync("ReceiveMessageWithRoom", ...)
    │        │
    │        ▼  (tới TẤT CẢ client trong room, kể cả người gửi)
    │    GUI (ReceiveMessageWithRoom handler)
    │        └── Hiển thị tin nhắn lên ListBox
    │
    └──▶ SaveMessageAsync (fire-and-forget, không block broadcast)
             │  POST http://localhost:3000/api/chat/messages
             │  Header: X-Server-Secret: <APP_SECRET_KEY>
             │  Body: { roomId, chatData: { senderId, message, timestamp } }
             ▼
         Backend (chat.controller.saveMessage)
             │  db.ref('tin_nhan/{roomId}').push(chatData)
             ▼
         Firebase Realtime DB → /tin_nhan/{roomId}
```

> **Lưu ý:** Client KHÔNG gọi API để lưu tin nhắn. ChatServer đảm nhận toàn bộ việc lưu.

---

## 6. Tải lịch sử chat

```
GUI → ChatManager.SwitchChatRoom(targetId)
    │
    ├─ SignalR LeaveRoom(currentRoomId)    → Server: Groups.Remove
    ├─ SignalR JoinRoom(newRoomId)         → Server: Groups.Add
    │
    ▼
BUS (ChatBUS.GetHistory)
    ▼
DAL (ChatDAL.GetHistoryAsync)
    │  GET /api/chat/messages?roomId={roomId}
    │  Header: Authorization: Bearer <token>
    ▼
Backend
    │  db.ref('tin_nhan/{roomId}').once('value')
    ▼
Firebase DB → trả về mảng tin nhắn
    ▼
GUI → Render từng dòng vào ListBox theo thứ tự thời gian
```

Quy tắc tạo `roomId` (trong `ChatBUS.GetRoomId`):

- Chat toàn công ty: `room_global`
- Chat riêng 2 người: `room_{minId}_{maxId}` (sắp xếp ID để đảm bảo duy nhất)

---

## 7. Quản lý nguyên liệu (kho)

```
GUI (`ucProducts_Manager.cs` — lưới tồn kho của **Manager**; nút "Nhập kho" mở dialog `WarehouseManager`)
    │  Load → IngredientBUS.GetAll()
    ▼
DAL (IngredientDAL.GetAllAsync)
    │  GET /api/ingredients
    │  Header: Authorization: Bearer <token>
    ▼
Backend → db.ref('nguyen_lieu').once('value')
    ▼
Firebase DB → /nguyen_lieu
    │  Trả về Dictionary<string, IngredientDTO>
    ▼
GUI → Tô đỏ dòng có TonKho < TonKhoToiThieu
```

Các thao tác CRUD:

```
POST   /api/ingredients         → Thêm nguyên liệu mới
PUT    /api/ingredients/:id     → Cập nhật (chỉ field có giá trị)
DELETE /api/ingredients/:id     → Xóa nguyên liệu
```

---

## 8. Nhập kho

```
GUI (Dialogs/AddInventoryImport.cs)
    │
    ├─ Load: InventoryImportBUS.GetIngredients()  → GET /api/ingredients
    ├─ Load: InventoryImportBUS.GetEmployees()    → GET /api/employees
    │
    │  Người dùng chọn NV, thêm từng dòng nguyên liệu
    ▼
BUS (InventoryImportBUS.AddImport)
    │  Validate: NhanVienId, DanhSachNL không rỗng
    │  Tính ThanhTien = GiaNhap × SoLuong cho từng dòng
    │  Tính TongTien = Σ ThanhTien
    ▼
DAL (InventoryImportDAL.AddAsync)
    │  POST /api/inventory  { InventoryImportDTO }
    │  Header: Authorization: Bearer <token>
    ▼
Backend (inventory.controller.js)
    │  Tạo ID tự động: nk_001, nk_002, ...
    │  db.ref('nhap_kho/{id}').set(phieu)
    │  Cập nhật TonKho trong /nguyen_lieu (cộng thêm SoLuong)
    ▼
Firebase DB → /nhap_kho + cập nhật /nguyen_lieu
    ▼
GUI → Hiển thị thông báo thành công, reload bảng
```

---

## 9. Phân quyền mỗi request

```
Client gửi request
    │
    ▼
auth.middleware.js (verifyAndGetUser)
    │
    ├─ Lấy Bearer token từ header Authorization
    ├─ auth.verifyIdToken(token)           → Firebase Auth xác thực
    ├─ Lấy thông tin từ db.ref('nhan_vien') theo email
    └─ Gán req.user = { EmployeeId, vai_tro, ... }
    │
    ▼
Route handler
    │
    ├─ Nếu cần Manager/Admin:
    │    verifyManagerRole → kiểm tra req.user.vai_tro
    │    403 nếu không đủ quyền
    │
    └─ Controller xử lý logic, trả kết quả

Trường hợp đặc biệt — ChatServer gọi nội bộ:
    │
    ├─ Header: X-Server-Secret: <APP_SECRET_KEY>
    ├─ verifyServerSecret → so sánh với process.env.APP_SECRET_KEY
    └─ Cho phép POST /chat/messages mà không cần JWT
```

---

## Tổng quan các luồng

```
┌──────────────────────────────────────────────────────────────┐
│                     CLIENT (WinForms)                        │
│                                                              │
│  GUI → BUS (validate) → DAL (HTTP) → DalHelper (BuildReq)  │
└─────────────────┬─────────────────────────────┬─────────────┘
                  │ REST HTTP (port 3000)         │ SignalR WS (port 8080)
                  ▼                               ▼
    ┌─────────────────────┐         ┌───────────────────────┐
    │  EXPRESS BACKEND    │         │   CHAT SERVER         │
    │                     │◀────────│  (ASP.NET SignalR)    │
    │  controllers/       │ POST    │                       │
    │  services/          │ /chat/  │  - Broadcast rooms    │
    │  middlewares/       │ messages│  - Lưu tin nhắn       │
    └──────────┬──────────┘ secret  └───────────────────────┘
               │ Firebase Admin SDK
               ▼
    ┌─────────────────────┐
    │  FIREBASE           │
    │  Realtime Database  │
    │  + Auth             │
    └─────────────────────┘
```

