# Kiến trúc hệ thống

## Tổng quan

```
┌─────────────────────────────────────────────────────────┐
│                      CLIENT (WinForms)                   │
│                                                          │
│  Admin | Manager | Barista | OrderStaff | Security       │
└────────────────────────┬────────────────────────────────┘
                         │
            ┌────────────┴────────────┐
            │ HTTP REST (port 3000)   │ SignalR WebSocket
            ▼                         ▼
┌───────────────────┐    ┌──────────────────────┐
│  BACKEND          │    │  CHAT SERVER          │
│  Express.js       │    │  ASP.NET Core         │
│  Node.js          │    │  SignalR              │
│                   │    │                       │
│  - Auth           │    │  - /chathub           │
│  - Employees      │    │  - Broadcast message  │
│  - Foods          │    │  - Online users       │
│  - Chat history   │    │                       │
└────────┬──────────┘    └──────────────────────┘
         │
         ▼
┌─────────────────────┐
│  FIREBASE           │
│  Realtime Database  │
│                     │
│  /nhan_vien         │
│  /mon_uong          │
│  /tin_nhan          │
│  /don_hang          │
│  /ban               │
└─────────────────────┘
```

## Phân chia trách nhiệm


| Layer       | Công nghệ              | Trách nhiệm                            |
| ----------- | ---------------------- | -------------------------------------- |
| Client      | C# WinForms .NET 8     | Giao diện, nghiệp vụ UI, gọi API       |
| Backend     | Node.js + Express      | REST API, xác thực Firebase, gửi email |
| Chat Server | ASP.NET Core + SignalR | Realtime messaging giữa nhân viên      |
| Database    | Firebase Realtime DB   | Lưu trữ dữ liệu toàn bộ hệ thống       |

**UI / thông báo modal:** dùng `MsgBox` tùy chỉnh, `MsgBox.OwnerWindow` cho owner từ UserControl, `ShowDialog` neo cùng owner — chi tiết trong [`docs/forms.md`](forms.md#msgbox-và-dialog-modal).


## Luồng xác thực

```
Client                    Backend                   Firebase Auth
  │                          │                           │
  │── POST /api/auth/login ──▶│                           │
  │                          │── signInWithPassword ────▶│
  │                          │◀─ idToken ────────────────│
  │◀─ { token, user } ───────│                           │
  │                          │                           │
  │ (lưu token vào memory)   │                           │
  │                          │                           │
  │── GET /api/employees ───▶│                           │
  │   Authorization: Bearer  │                           │
  │   <token>                │── verifyIdToken ─────────▶│
  │                          │◀─ decoded user ───────────│
  │◀─ [employee list] ───────│                           │
```

## Phân quyền (RBAC)


| Vai trò    | Quyền truy cập                            |
| ---------- | ----------------------------------------- |
| Admin      | Toàn quyền                                |
| Manager    | Quản lý nhân viên, thực đơn **và kho / phiếu nhập**, xem báo cáo (module kho trong `GUI/Warehouse/`, không role đăng nhập riêng) |
| Barista    | Xem đơn hàng (KDS), recipe                |
| OrderStaff | Tạo đơn, thanh toán, CRM                  |
| Security   | Bãi giữ xe, SOS                           |


## Giao tiếp giữa components


| Từ         | Đến           | Giao thức                       | Mục đích                   |
| ---------- | ------------- | ------------------------------- | -------------------------- |
| Client     | Backend       | HTTP REST + Bearer token        | CRUD nghiệp vụ, auth       |
| Client     | ChatServer    | SignalR WebSocket               | Gửi/nhận tin nhắn realtime |
| ChatServer | Backend       | HTTP + `X-Server-Secret` header | Lưu tin nhắn vào database  |
| Backend    | Firebase Auth | Firebase Admin SDK              | Xác thực, tạo/xóa user     |
| Backend    | Firebase DB   | Firebase Admin SDK              | Đọc/ghi dữ liệu            |
| Backend    | Gmail SMTP    | Nodemailer                      | Gửi OTP đặt lại mật khẩu   |


> Xem chi tiết từng luồng tại [docs/dataflow.md](./dataflow.md).

