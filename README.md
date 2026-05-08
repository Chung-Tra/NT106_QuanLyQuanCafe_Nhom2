# QLCafe — Phần mềm Quản lý Quán Cà Phê

> Đồ án môn NT106 — Lập trình mạng cơ bản | UIT

Hệ thống quản lý quán cà phê gồm ứng dụng desktop WinForms, REST API backend Express.js và realtime chat server SignalR, kết nối với Firebase Realtime Database.

---

## Nhóm phát triển


| STT | Họ và tên     | MSSV     | Vai trò |
| --- | ------------- | -------- | ------- |
| 1   | Đào Quốc Huy  | 24520655 |         |
| 2   | Trà Chí Chung | 24520229 |         |


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


| Tài liệu                                   | Mô tả                                       |
| ------------------------------------------ | ------------------------------------------- |
| [Kiến trúc hệ thống](docs/architecture.md) | Sơ đồ kiến trúc, luồng xác thực, phân quyền |
| [API Reference](docs/api.md)               | Toàn bộ endpoint, request/response mẫu      |
| [Database Schema](docs/database.md)        | Cấu trúc Firebase Realtime Database         |
| [Hướng dẫn cài đặt](docs/setup.md)         | Setup môi trường, Firebase, deploy chi tiết |


---

## Cài đặt & Chạy local

### Yêu cầu

- Node.js >= 18
- .NET 8 SDK
- Visual Studio 2022+
- Tài khoản Firebase (Realtime Database)

### Cài đặt lần đầu

```powershell
.\scripts\setup.ps1
```

> Xem hướng dẫn chi tiết tại [docs/setup.md](docs/setup.md)

### Cấu hình môi trường

Tạo file `backend/.env` từ mẫu:

```bash
cp backend/.env.example backend/.env
```

Điền các giá trị vào `backend/.env`:

```env
PORT=3000
FIREBASE_DATABASE_URL=https://<your-project>.firebaseio.com
FIREBASE_API_KEY=<your-api-key>
APP_SECRET_KEY=<your-secret-key>
EMAIL_USER=<gmail-address>
EMAIL_PASS=<gmail-app-password>
```

> Lấy `serviceAccountKey.json` từ Firebase Console → Project Settings → Service Accounts → Generate new private key, đặt vào `backend/` (đã gitignore).

### Chạy tất cả service

```powershell
.\scripts\start-all.ps1 -WithClient    # Backend + ChatServer + Client (full)
.\scripts\start-all.ps1                # Backend + ChatServer (default)
.\scripts\start-backend.ps1            # Chỉ Backend Express
.\scripts\start-server.ps1             # Chỉ ChatServer SignalR
.\scripts\start-client.ps1             # Chỉ Client WinForms (build + run)
```

> Các script `*.ps1` dùng **UTF-8 có BOM** để **Windows PowerShell 5.1** đọc đúng chữ Việt trong comment. Nếu sửa script, lưu UTF-8 BOM hoặc chạy bằng **PowerShell 7** (`pwsh`).

Client cũng có thể mở trong Visual Studio: `client/Coffee_Management.sln` → F5

---

## API Endpoints

Base URL: `http://localhost:3000/api`


| Method | Endpoint                 | Mô tả                  | Auth         |
| ------ | ------------------------ | ---------------------- | ------------ |
| POST   | `/auth/login`            | Đăng nhập              | Không        |
| POST   | `/auth/check-email`      | Kiểm tra email tồn tại | Không        |
| POST   | `/auth/otp/generate`     | Tạo và gửi OTP         | Không        |
| PUT    | `/auth/password`         | Đổi mật khẩu           | Không        |
| GET    | `/employees`             | Danh sách nhân viên    | Bearer token |
| POST   | `/employees`             | Thêm nhân viên         | Manager+     |
| PUT    | `/employees/:id`         | Cập nhật nhân viên     | Manager+     |
| DELETE | `/employees/:id`         | Xóa nhân viên          | Manager+     |
| PATCH  | `/employees/:id/lock`    | Khóa tài khoản         | Manager+     |
| GET    | `/foods`                 | Danh sách món          | Bearer token |
| POST   | `/foods`                 | Thêm món               | Manager+     |
| PUT    | `/foods/:id`             | Cập nhật món           | Manager+     |
| DELETE | `/foods/:id`             | Xóa món                | Manager+     |
| GET    | `/chat/messages?roomId=` | Lịch sử chat           | Bearer token |
| POST   | `/chat/messages`         | Lưu tin nhắn           | Bearer token |
| GET    | `/ingredients`           | Danh sách nguyên liệu  | Bearer token |
| POST   | `/ingredients`           | Thêm nguyên liệu       | Manager+     |
| PUT    | `/ingredients/:id`       | Cập nhật nguyên liệu   | Manager+     |
| DELETE | `/ingredients/:id`       | Xóa nguyên liệu        | Manager+     |
| GET    | `/inventory`             | Danh sách phiếu nhập   | Bearer token |
| POST   | `/inventory`             | Tạo phiếu nhập kho     | Manager+     |


---

## Cấu trúc thư mục

```
NT106_QuanLyQuanCafe_Nhom2/
├── scripts/
│   ├── start-all.ps1              # Chạy tất cả (-WithClient để có client)
│   ├── start-backend.ps1          # Chỉ Backend Express
│   ├── start-server.ps1           # Chỉ ChatServer SignalR
│   ├── start-client.ps1           # Chỉ Client WinForms
│   └── setup.ps1                  # Cài dependencies lần đầu
├── client/                        # WinForms desktop app
│   ├── BUS/                       # Business logic layer
│   ├── DAL/                       # Data access layer
│   ├── DTO/                       # Data transfer objects
│   ├── Services/                  # HTTP & SignalR client services
│   ├── GUI/                       # UI (WinForms)
│   │   ├── Auth/
│   │   ├── Admin/
│   │   ├── Manager/
│   │   ├── Barista/
│   │   ├── OrderStaff/
│   │   ├── Warehouse/
│   │   ├── Shared/                # UC dùng chung nhiều role
│   │   ├── Dialogs/               # Form popup
│   │   └── Common/                # Base classes, utilities
│   └── Tests/                     # xUnit unit tests (BUS layer)
├── server/                        # SignalR chat server
│   ├── Hubs/
│   │   └── ChatHub.cs
│   └── Program.cs
├── backend/                       # Express REST API
│   ├── src/
│   │   ├── config/
│   │   ├── controllers/
│   │   ├── middlewares/
│   │   ├── routes/
│   │   ├── services/
│   │   ├── utils/
│   │   └── app.js
│   ├── tests/                     # Jest unit tests
│   ├── logs/                      # Auto-generated (gitignored)
│   ├── .env.example
│   └── server.js
├── .gitignore
├── firebase.json
└── README.md
```

---

## Chạy Tests

```bash
# Backend (Jest)
cd backend
npm test

# Client (xUnit) — chạy trong Visual Studio Test Explorer
# hoặc:
cd client
dotnet test Tests/Tests.csproj
```

---

## Logging

Backend sử dụng Winston. Log được ghi tại:

- `backend/logs/combined.log` — tất cả log
- `backend/logs/error.log` — chỉ error
- Console — có màu khi chạy dev, JSON khi production

---

## Lưu ý bảo mật

- Không commit `backend/.env` hay `serviceAccountKey.json` vào repo (đã gitignore)
- `APP_SECRET_KEY` dùng để bảo vệ endpoint đổi mật khẩu — đặt giá trị mạnh, không chia sẻ
- Firebase Security Rules cần được cấu hình riêng trên Firebase Console

