# TỔNG HỢP TOÀN BỘ ĐỒ ÁN — QLCafe (Phần mềm Quản lý Quán Cà Phê)

> **Môn:** NT106 — Lập trình mạng cơ bản · **Trường:** UIT — Đại học Công nghệ Thông tin, ĐHQG-HCM
> **Nhóm 2:** Đào Quốc Huy (24520655) · Trà Chí Chung (24520229)
> **Nhánh hiện tại:** `final-backend` — toàn bộ màn hình đã nối dữ liệu thật từ Firebase.

Tài liệu này gom **tất cả mọi thứ có trong đồ án** về một chỗ: từ ý tưởng ban đầu, lý do chọn kiến trúc, công nghệ, cấu trúc mã nguồn, thiết kế cơ sở dữ liệu, toàn bộ API, chi tiết từng màn hình của từng vai trò (kèm code thật), cho tới bảo mật, hiệu năng, kiểm thử và cách chạy. Đọc xong tài liệu này, một người **chưa từng mở repo** có thể hiểu hệ thống làm gì, vì sao làm như vậy, và code nằm ở đâu.

---

## Mục lục

1. [Ý tưởng & bài toán](#1-ý-tưởng--bài-toán)
2. [Bức tranh kiến trúc tổng thể](#2-bức-tranh-kiến-trúc-tổng-thể)
3. [Công nghệ sử dụng (đầy đủ phiên bản)](#3-công-nghệ-sử-dụng-đầy-đủ-phiên-bản)
4. [Cấu trúc repo — cái gì nằm ở đâu](#4-cấu-trúc-repo--cái-gì-nằm-ở-đâu)
5. [Cơ sở dữ liệu Firebase Realtime Database](#5-cơ-sở-dữ-liệu-firebase-realtime-database)
6. [Backend Express — chi tiết từng tầng](#6-backend-express--chi-tiết-từng-tầng)
7. [API Reference — toàn bộ 116 endpoint](#7-api-reference--toàn-bộ-116-endpoint)
8. [Client WinForms — chi tiết từng tầng, từng màn hình](#8-client-winforms--chi-tiết-từng-tầng-từng-màn-hình)
9. [Chat Server SignalR](#9-chat-server-signalr)
10. [Thiết kế bảo mật](#10-thiết-kế-bảo-mật)
11. [Tối ưu hiệu năng & trải nghiệm](#11-tối-ưu-hiệu-năng--trải-nghiệm)
12. [Kiểm thử & chất lượng mã](#12-kiểm-thử--chất-lượng-mã)
13. [Cài đặt, cấu hình & vận hành](#13-cài-đặt-cấu-hình--vận-hành)
14. [Trạng thái hiện tại, hạn chế & hướng phát triển](#14-trạng-thái-hiện-tại-hạn-chế--hướng-phát-triển)
15. [Phụ lục — thống kê mã nguồn](#15-phụ-lục--thống-kê-mã-nguồn)

---

## 1. Ý tưởng & bài toán

### 1.1. Bối cảnh nghiệp vụ

Một quán cà phê thực tế không phải là "một người bán hàng + một cái máy tính". Nó là **nhiều con người với vai trò khác nhau làm việc đồng thời**, và dữ liệu của người này là đầu vào của người kia:

- **Nhân viên order** đứng quầy lên đơn → đơn phải **hiện ngay** trên màn hình của **pha chế** (barista) ở khu bếp.
- **Pha chế** thấy sắp hết sữa → bấm cảnh báo → **quản lý** nhận thông báo để đi nhập hàng.
- **Quản lý** nhập kho, xếp lịch ca, duyệt đơn xin nghỉ của mọi người.
- **Bảo vệ** ghi nhận xe vào/ra và có nút SOS khi có sự cố.
- **Quản trị viên (chủ quán)** nhìn số liệu tổng: doanh thu, chi phí, thất thoát, lương, feedback khách.

Từ đó rút ra 3 yêu cầu kỹ thuật mà một ứng dụng offline chạy đơn lẻ **không thể** đáp ứng:

1. **Dữ liệu tập trung, nhiều máy cùng đọc/ghi** — máy POS ở quầy, máy KDS ở bếp, máy quản lý ở văn phòng phải nhìn cùng một nguồn dữ liệu.
2. **Xác thực & phân quyền** — nhân viên order không được xem lương, pha chế không được xóa nhân viên.
3. **Realtime** — chat nội bộ, đơn đẩy xuống bếp, cảnh báo SOS cần server **chủ động đẩy** dữ liệu về client (push), không thể bắt người dùng bấm F5.

Đây chính là các trọng tâm của môn **Lập trình mạng**: HTTP request/response, WebSocket, xác thực, client–server nhiều tầng.

### 1.2. Ý tưởng giải quyết

Nhóm quyết định xây hệ thống theo mô hình **client – server tách 3 tiến trình độc lập**, mỗi tiến trình đảm nhiệm đúng một loại giao tiếp mạng:

| Nhu cầu | Giải pháp | Vì sao chọn |
| --- | --- | --- |
| CRUD nghiệp vụ (request/response) | **REST API** — Express.js trên Node.js, port 3000 | Chuẩn công nghiệp, dễ test bằng curl/Postman/Jest, tách hoàn toàn backend khỏi UI; client nào (WinForms, web, mobile) cũng gọi được |
| Realtime (push) | **WebSocket** — ASP.NET Core **SignalR**, port 8080 | Chat cần server đẩy tin về mọi client trong phòng; HTTP polling vừa chậm vừa tốn tài nguyên; SignalR có sẵn cơ chế room/group, auto-reconnect |
| Lưu trữ + xác thực | **Firebase Realtime Database + Firebase Auth + Firebase Storage** | Miễn phí cho quy mô đồ án, không phải tự dựng SQL server; Auth phát sẵn JWT (ID Token) dùng làm Bearer token; Storage lưu ảnh món/avatar |
| Giao diện | **WinForms .NET 8 + Guna.UI2** | Yêu cầu môn học là ứng dụng desktop; Guna.UI2 cho control bo góc, dark theme hiện đại thay vì giao diện WinForms cổ điển |
| Tổ chức code client | Phân lớp **GUI → BUS → DAL → DTO** (4 project riêng) | GUI chỉ hiển thị, BUS validate + nghiệp vụ, DAL gọi HTTP, DTO là object truyền dữ liệu — dễ test, dễ bảo trì, không cho phép GUI "đi tắt" gọi thẳng mạng |

### 1.3. Phạm vi tính năng (8 phân hệ)

1. **Xác thực & phân quyền** — đăng nhập, ghi nhớ đăng nhập (mã hóa DPAPI), quên mật khẩu qua OTP email, phiên 60 phút, RBAC 5 vai trò.
2. **Bán hàng (POS)** — sơ đồ bàn, lên đơn theo card món, giảm giá, thanh toán tiền mặt/thẻ/**VietQR thật (quét được)**, đặt bàn trước, QR tự đặt món tại bàn, quản lý tiền mặt theo ca.
3. **Thực đơn & Kho** — CRUD món (kèm **upload ảnh lên Firebase Storage**), CRUD nguyên liệu, phiếu nhập kho (tay hoặc **đọc từ Excel/CSV**), server tự cộng tồn kho, cảnh báo tồn thấp, công thức pha chế, theo dõi thất thoát.
4. **Nhân sự** — CRUD nhân viên (tạo kèm tài khoản Firebase Auth, có rollback), khóa tài khoản, chấm công, lịch sử chấm công, xếp lịch ca tuần, đăng ký/đổi ca, đơn xin nghỉ & duyệt, tính lương tự động.
5. **Khách hàng (CRM)** — hồ sơ khách, tích điểm & hạng thành viên (có nhật ký điểm), khuyến mãi (happy hour / combo / voucher), feedback & phản hồi.
6. **Báo cáo & tài chính** — dashboard doanh thu/lợi nhuận/chi phí/thất thoát từ dữ liệu thật, biểu đồ 12 tháng, tiền chi, **xuất Excel (ClosedXML) và PDF thật**.
7. **Truyền thông nội bộ** — chat realtime 1-1 và phòng chung, thông báo hệ thống, phát thông báo broadcast, báo lỗi ứng dụng gửi Admin.
8. **An ninh** — kiểm soát bãi xe (vào/ra, phí, đếm chỗ), báo sự cố SOS theo mức độ.

---

## 2. Bức tranh kiến trúc tổng thể

### 2.1. Sơ đồ

```
                  ┌─────────────────────────────────────────────┐
                  │       CLIENT — WinForms .NET 8 (nhiều máy)   │
                  │  Admin · Manager · Order · Barista · Security│
                  │                                             │
                  │   GUI ──▶ BUS ──▶ DAL ──▶ DalHelper          │
                  │    │                        │  HttpClient    │
                  │    └──▶ ChatManager (SignalR Client)         │
                  └───────────┬──────────────────────┬──────────┘
              HTTP REST + Bearer│                     │ WebSocket
                 (port 3000)    │                     │ (port 8080)
                  ┌─────────────▼──────────┐   ┌──────▼───────────────┐
                  │  BACKEND — Express.js  │   │ CHAT SERVER          │
                  │  helmet·cors·morgan    │◀──│ ASP.NET Core SignalR │
                  │  routes → middlewares  │   │ Hub /chathub         │
                  │  → controllers →       │   │ POST /chat/messages  │
                  │  services              │   │ + X-Server-Secret    │
                  └─────┬──────┬───────┬───┘   └──────────────────────┘
                        │      │       │
          Firebase Admin SDK   │       └── Nodemailer ──▶ Gmail SMTP (gửi OTP)
                        │      │
              ┌─────────▼──┐ ┌─▼──────────────┐ ┌────────────────────┐
              │ Firebase   │ │ Firebase       │ │ Firebase Storage   │
              │ Auth (JWT) │ │ Realtime DB    │ │ (ảnh món / avatar) │
              └────────────┘ └────────────────┘ └────────────────────┘
```

### 2.2. Vai trò từng khối

| Khối | Thư mục | Công nghệ | Trách nhiệm | KHÔNG được làm |
| --- | --- | --- | --- | --- |
| Client | `client/` | C# WinForms .NET 8 | Hiển thị, bắt sự kiện, validate UX, gọi API | Truy cập Firebase trực tiếp |
| Backend | `backend/` | Node.js 20 + Express | REST API, xác thực JWT, RBAC, email OTP, upload Storage, tính toán tiền phía server | Render giao diện |
| Chat Server | `server/` | ASP.NET Core + SignalR | Broadcast tin nhắn realtime theo room; gọi ngược Backend để lưu tin | Ghi Firebase trực tiếp |
| Firebase | (cloud) | RTDB + Auth + Storage | Nguồn dữ liệu duy nhất, phát/xác thực token, chứa file ảnh | — |

### 2.3. Các đường giao tiếp mạng (điểm ăn điểm của môn học)

| Từ → Đến | Giao thức | Cổng | Nội dung |
| --- | --- | --- | --- |
| Client → Backend | HTTP/1.1 REST, JSON, header `Authorization: Bearer <idToken>` | 3000 | Toàn bộ CRUD nghiệp vụ + upload ảnh (multipart/form-data) |
| Client → ChatServer | WebSocket (SignalR, fallback SSE/long-polling) | 8080 | `JoinRoom` / `LeaveRoom` / `SendMessageWithRoom` / nhận `ReceiveMessageWithRoom` |
| ChatServer → Backend | HTTP POST + header `X-Server-Secret` | 3000 | Lưu tin nhắn vào DB (server-to-server, không dùng JWT) |
| Backend → Firebase Auth | HTTPS (Admin SDK + REST `signInWithPassword`) | 443 | Đăng nhập, verify token, tạo/khóa/xóa user |
| Backend → Firebase RTDB | HTTPS (Admin SDK) | 443 | Đọc/ghi mọi node dữ liệu |
| Backend → Firebase Storage | HTTPS (Admin SDK) | 443 | Ghi file ảnh, phát download token |
| Backend → Gmail | SMTP (Nodemailer) | 587 | Gửi mã OTP 8 số |

**Chạy nhiều máy trong LAN:** ChatServer khi khởi động tự dò IP LAN của máy (qua `Dns.GetHostEntry`) và in ra màn hình dòng `<add key="ChatServerIP" value="192.168.x.x"/>` để dán vào `App.config` của các máy client khác. `ApiBaseUrl` cũng đổi tương tự khi backend nằm trên máy khác.

---

## 3. Công nghệ sử dụng (đầy đủ phiên bản)

### 3.1. Client (`client/GUI/GUI.csproj`)

| Package | Phiên bản | Dùng để |
| --- | --- | --- |
| .NET / WinForms | `net8.0-windows7.0`, Nullable enable | Nền tảng UI |
| **Guna.UI2.WinForms** | 2.0.4.4 | Control bo góc, dark theme, DataGridView đẹp |
| **Guna.Charts.WinForms** | 1.1.0 (bản free) | Biểu đồ dashboard |
| **Microsoft.AspNetCore.SignalR.Client** | 10.0.6 | Kết nối ChatHub qua WebSocket |
| **ClosedXML** | 0.104.2 | Xuất báo cáo **.xlsx** thật; (kèm bộ đọc Excel/CSV cho nhập kho) |
| **QRCoder** | 1.6.0 | Sinh mã QR: **VietQR chuyển khoản chuẩn EMVCo/Napas 247** + QR link tự đặt món |
| FirebaseAuthentication.net / FirebaseDatabase.net | 4.1.0 / 5.0.0 | Còn tham chiếu trong csproj (giai đoạn thử nghiệm đầu); luồng chính thức đi qua backend REST |
| Newtonsoft.Json | (theo BUS/DAL) | Serialize/deserialize JSON, `[JsonProperty]` mapping |

Client chia **4 project**: `GUI.csproj` (WinExe) → tham chiếu `BUS.csproj` + `DTO.csproj`; `BUS` → `DAL` + `DTO`; `DAL` → `DTO`. Solution: `client/Coffee_Management.sln`.

### 3.2. Backend (`backend/package.json`)

| Package | Phiên bản | Dùng để |
| --- | --- | --- |
| Node.js | engines **20** | Runtime |
| **express** | ^4.21.0 | HTTP server + router |
| **firebase-admin** | ^13.8.0 | Auth + RTDB + Storage với quyền admin |
| **firebase-functions** | ^7.2.5 | Deploy chính app Express lên Cloud Functions v2 (region `asia-southeast1`) |
| **multer** | ^2.2.0 | Nhận file multipart (upload ảnh) — memoryStorage, giới hạn 5 MB, chỉ `image/*` |
| **nodemailer** | ^8.0.5 | Gửi OTP qua Gmail SMTP |
| **helmet** | ^8.0.0 | Header bảo mật HTTP |
| **cors** | ^2.8.5 | Cho client khác origin gọi API |
| **morgan** | ^1.10.0 | Log request dạng `dev` |
| **winston** | ^3.19.0 | Logger ra `logs/combined.log`, `logs/error.log` |
| dotenv / axios | ^16 / ^1.15 | Đọc `.env`; HTTP client nội bộ |
| **jest** | ^29.7.0 (dev) | Unit test controller/middleware |
| nodemon / eslint | dev | Hot-reload khi dev; lint theo eslint-config-google |

### 3.3. Chat Server (`server/ChatServer`)

ASP.NET Core (SDK web), SignalR built-in. Cấu hình đáng chú ý trong `Program.cs`: `KeepAliveInterval = 15s`, `ClientTimeoutInterval = 60s`, `MaximumReceiveMessageSize = 64KB`, `EnableDetailedErrors = true`; CORS mở (`SetIsOriginAllowed(_ => true) + AllowCredentials`) vì client WinForms không có origin cố định; `IHttpClientFactory` đăng ký client tên `"ChatApi"` trỏ về backend kèm sẵn header `X-Server-Secret` đọc từ `appsettings.json`.

---

## 4. Cấu trúc repo — cái gì nằm ở đâu

```
NT106_QuanLyQuanCafe_Nhom2/
├── client/                          # ỨNG DỤNG DESKTOP (WinForms .NET 8)
│   ├── Coffee_Management.sln
│   ├── GUI/                         # Project giao diện (WinExe)
│   │   ├── Program.cs               #   Main → mở Login
│   │   ├── App.config               #   ApiBaseUrl, ChatServerIP, SavedEmail/Password
│   │   ├── Auth/                    #   Login, ConfirmEmail, VerifyCode, ResetPassword
│   │   ├── Admin/                   #   7 màn: Dashboard, Managers, Payroll, Expenses, Report, Feedback, Notification
│   │   ├── Manager/                 #   9 màn: Overview, Products(+Kho), Orders, Staff, Schedule, Promotion, Loss, Feedback, Notification
│   │   ├── Order/                   #   6 màn: POS, CRM, Loyalty, Reservation, SelfOrder(QR), CashManagement
│   │   ├── Barista/                 #   3 màn: KDS, Recipe, Alert
│   │   ├── Shared/                  #   11 màn dùng chung: InternalChat, Profile, LeaveRequest, WorkTracking,
│   │   │                            #   AttendanceHistory, AuditLog, BroadcastCenter, ShiftRegister,
│   │   │                            #   Overview_Staff, Parking_Security, SOS_Security
│   │   ├── Dialogs/                 #   20 dialog: AddEmployee/EditEmployee/EmployeeDetail, AddFood/EditFood/FoodDetail,
│   │   │                            #   AddInventoryImport, WarehouseManager, PaymentDialog, RecordDetail/RecordEdit,
│   │   │                            #   LeaveRequestDetail, ReplyFeedback, SendBroadcast, ReportBug, ReportIncident,
│   │   │                            #   ChartDetail, MetricDetail, ManagerProfileDetail, AuditLogDetail
│   │   ├── Common/                  #   ~25 helper hạ tầng UI (xem §8.9)
│   │   └── Helpers/                 #   GridExporter (Excel/PDF), InventoryImportExcelReader (đọc Excel/CSV)
│   ├── BUS/                         # Project nghiệp vụ: AuthBUS, EmployeeBUS, FoodBUS, IngredientBUS,
│   │                                #   InventoryImportBUS, ChatBUS, EmailBUS, UploadBUS, Validation, Audit,
│   │                                #   ResourceBUS.cs (23 BUS generic — xem §8.3)
│   ├── DAL/                         # Project truy cập dữ liệu: DalHelper, AuthDAL, EmployeeDAL, FoodDAL,
│   │                                #   IngredientDAL, InventoryImportDAL, ChatDAL, EmailDAL, UploadDAL,
│   │                                #   ResourceDAL.cs (CRUD generic — xem §8.2)
│   └── DTO/                         # Project object dữ liệu: 22 file DTO + GlobalSession + SecondaryDTOs (10 DTO mới)
│
├── backend/                         # REST API (Node.js/Express)
│   ├── server.js                    #   Entry chạy local (nghe PORT 3000)
│   ├── index.js                     #   Entry deploy Firebase Functions v2 (onRequest, asia-southeast1)
│   ├── src/
│   │   ├── app.js                   #   Lắp middleware: helmet → cors → json → morgan → /health → /api → error
│   │   ├── config/firebase.js       #   Khởi tạo Admin SDK (local: serviceAccountKey.json; prod: default credentials)
│   │   ├── routes/                  #   auth, employees, foods, ingredients, inventory, chat, upload, resources, index
│   │   ├── controllers/             #   auth, employees, foods, ingredients, inventory, chat, upload, resources(factory)
│   │   ├── middlewares/             #   auth.middleware (verifyAndGetUser / verifyManagerRole / verifyServerSecret), error.middleware
│   │   ├── services/                #   firebase-auth.service, email.service, otp.service
│   │   ├── utils/logger.js          #   Winston
│   │   └── api/                     #   (bộ file cũ theo từng endpoint — đã thay bằng controllers/, giữ tham khảo)
│   └── tests/                       #   Jest: auth.controller, chat.controller, employees.controller,
│                                    #   foods.controller, auth.middleware + mockFirebase.js
│
├── server/                          # CHAT SERVER (ASP.NET Core SignalR)
│   ├── Server.sln
│   └── ChatServer/
│       ├── Program.cs               #   Cấu hình SignalR + CORS + tự dò IP LAN, map /chathub
│       ├── Hubs/ChatHub.cs          #   JoinRoom/LeaveRoom/SendMessageWithRoom + tự lưu tin qua backend
│       └── appsettings.json         #   ChatApi:BaseUrl + ChatApi:ServerSecret
│
├── docs/                            # architecture.md, api.md, database.md, dataflow.md, forms.md, setup.md,
│                                    #   BAO_CAO_TONG_HOP.md (báo cáo chi tiết)
├── scripts/                         # setup.ps1, start-all.ps1, start-backend.ps1, start-server.ps1,
│                                    #   start-client.ps1, start-multi-client.ps1 (UTF-8 BOM cho PowerShell 5.1)
├── qlcafe-rtdb-import-full.json     # Bộ dữ liệu mẫu ĐẦY ĐỦ import vào RTDB (19 node — xem §5.4)
├── qlcafe-b621b-default-rtdb-export.json  # Bản export dữ liệu thật từ Firebase
├── firebase.json / .firebaserc      # Cấu hình deploy Functions
├── HUONG_DAN_TEST_UI.md             # Kịch bản test UI theo role (viết ở giai đoạn trước khi nối full backend)
└── README.md
```

---

## 5. Cơ sở dữ liệu Firebase Realtime Database

### 5.1. Tư duy thiết kế trên NoSQL

RTDB là **một cây JSON duy nhất** — không có bảng, không có JOIN, không có khóa ngoại. Nhóm quy ước:

- Mỗi **node gốc** đóng vai một "bảng" (`/nhan_vien`, `/mon_uong`…).
- **Key của phần tử = khóa chính**, đặt theo tiền tố nghiệp vụ: `nv_001`, `mon_012`, `dh_003`… Backend sinh key mới theo công thức `max(số hiện có) + 1` (đệm 3 chữ số) — nhờ vậy **xóa bản ghi không phải đánh số lại** cả node.
- **Quan hệ n-1**: lưu key của node kia làm giá trị — ví dụ `don_hang.ban_id = "ban_001"`, `thanh_toan.don_hang_id = "dh_001"`. Client tự join trong bộ nhớ (đã có sẵn dictionary từ API).
- **Quan hệ 1-n "sở hữu chặt"**: lồng (nested) thẳng vào cha để đọc 1 lần được cả cụm — `don_hang.chi_tiet_don.{ctd_001}`, `nhap_kho.ds_nl.{nl_001}`, `cong_thuc.nguyen_lieu.{...}`.
- **Thời gian sự kiện** lưu **Unix timestamp mili-giây** (số `long`) để so sánh/sắp xếp chính xác, không phụ thuộc định dạng chuỗi. Ngày "logic" hiển thị (`cham_cong.ngay`) lưu chuỗi `yyyy-MM-dd`.
- **Tiền** lưu số nguyên VND, không format sẵn.

### 5.2. Danh mục đầy đủ 30 node

**Nhóm có sẵn dữ liệu mẫu (19 node trong `qlcafe-rtdb-import-full.json`):**

| Node | Prefix | DTO client | Nội dung | Số bản ghi mẫu |
| --- | --- | --- | --- | :-: |
| `/nhan_vien` | `nv_` | `EmployeeDTO` | Hồ sơ nhân viên + `AuthUid` + `vai_tro` | 10 |
| `/mon_uong` | `mon_` | `FoodDTO` | Thực đơn: tên, giá, loại, mô tả, `hinh_anh_url`, `con_hang`, `hien_thi` | 30 |
| `/ban` | `ban_` | `TableDTO` | Bàn: tên, số chỗ, `trang_thai` (trong/co_khach/dat_truoc), vị trí | 20 |
| `/don_hang` | `dh_` | `OrderDTO`+`OrderItemDTO` | Đơn + chi tiết lồng `chi_tiet_don`; có field `nguon` ("qr" = khách tự đặt) | 12 |
| `/thanh_toan` | `tt_` | `PaymentDTO` | Phiếu thanh toán: phương thức, tổng, giảm, thực thu | 7 |
| `/nguyen_lieu` | `nl_` | `IngredientDTO` | Nguyên liệu: đơn vị, giá nhập, `ton_kho`, `ton_kho_toi_thieu` | 18 |
| `/nhap_kho` | `nk_` | `InventoryImportDTO` | Phiếu nhập + dòng lồng `ds_nl`; `ngay_nhap` = timestamp ms | 6 |
| `/cham_cong` | `cc_` | `AttendanceDTO` | Chấm công: giờ vào/ra (ms), số giờ, trạng thái | 27 |
| `/xin_nghi` | `xn_` | `LeaveRequestDTO` | Đơn xin nghỉ: khoảng ngày, lý do, `cho_duyet/da_duyet/tu_choi`, người duyệt | 7 |
| `/luong` | `luong_` | `SalaryDTO` | Bảng lương tháng: công, lương CB, phụ cấp, thưởng, trừ, tổng | 10 |
| `/thong_bao` | `tb_` | `NotificationDTO` | Thông báo hệ thống theo loại + màn liên quan | 12 |
| `/tin_nhan` | room/`msg_` | `ChatMessageDTO` | Tin chat theo phòng: `room_global` hoặc `chat_{idA}_{idB}` | 3 phòng |
| `/danh_sach_chat` | — | (index) | Index hội thoại của từng người (tin cuối, đã đọc) | 4 |
| `/khach_hang` | `kh_` | `CustomerDTO` | CRM: tên, SĐT, email, `diem_tich_luy`, `tong_don` | 10 |
| `/feedback` | `fb_` | `FeedbackDTO` | Feedback: sao 1-5, nội dung, đã xử lý, phản hồi | 10 |
| `/cong_thuc` | `ct_` | `RecipeDTO` | Công thức: các bước + nguyên liệu lồng (định lượng, loại chính/phụ/topping) | 10 |
| `/canh_bao` | `cb_` | `WarningDTO` | Cảnh báo nguyên liệu sắp/đã hết, thiết bị hỏng | 7 |
| `/bai_xe` | `bx_` | `ParkingDTO` | Xe gửi: biển số, loại, giờ vào/ra, phí, trạng thái | 10 |
| `/su_co` | `sc_` | `IncidentDTO` | Sự cố an ninh/y tế/kỹ thuật/SOS theo mức độ | 6 |

**Nhóm node MỚI (sinh tự động khi dùng, phục vụ các màn phụ — thêm ở nhánh `final-backend`):**

| Node | Prefix | DTO client | Phục vụ màn |
| --- | --- | --- | --- |
| `/khuyen_mai` | `km_` | `PromotionDTO` | Khuyến mãi Manager — gộp 3 loại `happy_hour` / `combo` / `voucher` phân biệt bằng field `loai` |
| `/chi_phi` | `cp_` | `ExpenseDTO` | Tiền chi (Admin) |
| `/that_thoat` | `loss_` | `LossDTO` | Thất thoát & hao phí (Manager) |
| `/dat_ban` | `db_` | `ReservationDTO` | Đặt bàn trước (Order) |
| `/nhat_ky` | `log_` | `AuditLogDTO` | Nhật ký kiểm toán (ai làm gì, lúc nào, IP) |
| `/thong_bao_chung` | `bc_` | `BroadcastDTO` | Broadcast nội bộ |
| `/lich_lam_viec` | `sch_` | `ScheduleDTO` | Lịch ca tuần: 1 dòng/NV với 7 cột `t2..cn` |
| `/dang_ky_ca` | `sr_` | `ShiftDTO` | Chọn ca / đổi ca (`loai`: open/mine/swap) |
| `/bao_loi` | `bug_` | `BugReportDTO` | Báo lỗi ứng dụng gửi Admin (mở từ nút trên header dashboard) |
| `/diem_log` | `pl_` | `PointLogDTO` | Nhật ký tích/đổi điểm (delta +/−) của khách |

**Node kỹ thuật:** `/password_reset/{sha256(email)}` — chứa hash mã OTP hoặc hash reset-token + hạn dùng + số lần thử (xem §10.3). Không có DTO vì client không bao giờ đọc node này.

### 5.3. Ví dụ cấu trúc bản ghi tiêu biểu

```jsonc
// /don_hang/dh_001 — đơn hàng với chi tiết lồng
{
  "ban_id": "ban_001",
  "nhanvien_id": "nv_003",
  "thoi_gian_tao": 1711900000000,      // timestamp ms
  "trang_thai": "pending",              // pending | dang_phuc_vu | hoan_thanh | huy
  "nguon": "qr",                        // "qr" = khách tự đặt qua QR (field mới)
  "ghi_chu": "",
  "chi_tiet_don": {
    "ctd_001": {
      "mon_id": "mon_001", "so_luong": 2, "don_gia": 25000,
      "ghi_chu_mon": "ít đá",
      "trang_thai_che_bien": "cho"      // cho | dang_lam | hoan_thanh — dữ liệu màn KDS
    }
  }
}

// /thanh_toan/tt_001
{
  "don_hang_id": "dh_001", "nhanvien_id": "nv_003",
  "phuong_thuc": "tien_mat",            // tien_mat | the | vietqr (POS mới) — dữ liệu cũ có momo/vnpay
  "thoi_gian": 1711903600000,
  "tong_tien": 50000, "tien_giam": 0, "tien_thuc_thu": 50000
}

// /lich_lam_viec/sch_001 — 1 nhân viên × 1 tuần
{
  "nhanvien_id": "nv_004", "ten": "Phạm Thị D",
  "tuan": "30/06/2026",                 // ngày đầu tuần
  "t2": "Ca sáng", "t3": "Ca sáng", "t4": "OFF", "t5": "Ca chiều",
  "t6": "Ca chiều", "t7": "Ca tối", "cn": "OFF"
}
```

### 5.4. Ánh xạ tên field: Firebase (snake_case tiếng Việt) ↔ C# (PascalCase)

Mọi DTO gắn `[JsonProperty]` để hai bên gọi theo tên tự nhiên của mình:

```csharp
public class OrderDTO {
    [JsonIgnore]                      public string? Id { get; set; }   // = key node, gán sau khi GET
    [JsonProperty("ban_id")]          public string? TableId { get; set; }
    [JsonProperty("nhanvien_id")]     public string? EmployeeId { get; set; }
    [JsonProperty("thoi_gian_tao")]   public long CreatedAt { get; set; }
    [JsonProperty("trang_thai")]      public string? Status { get; set; }
    [JsonProperty("nguon")]           public string? Source { get; set; }
    [JsonProperty("chi_tiet_don")]    public Dictionary<string, OrderItemDTO>? Items { get; set; }
}
```

`Id` đánh dấu `[JsonIgnore]` vì nó **không nằm trong** body JSON — nó là key của node; `ResourceDAL.GetAllAsync` sau khi parse sẽ dùng reflection gán key vào thuộc tính `Id` để GUI có sẵn khi cần update/delete.

---

## 6. Backend Express — chi tiết từng tầng

### 6.1. Pipeline một request

```
Request ──▶ helmet (header an toàn) ──▶ cors ──▶ express.json ──▶ morgan (log)
        ──▶ [GET /health → {"status":"ok"}]
        ──▶ /api router ──▶ (middleware xác thực theo route) ──▶ controller ──▶ service ──▶ Firebase
        ──▶ error.middleware (bắt mọi lỗi, trả { error } + ghi winston)
```

Hai chế độ chạy **cùng một `src/app.js`**:
- **Local:** `server.js` → `app.listen(PORT=3000)`.
- **Cloud:** `index.js` → `exports.api = onRequest({ region: 'asia-southeast1' }, app)` — deploy bằng `firebase deploy --only functions`, URL dạng `https://asia-southeast1-<project>.cloudfunctions.net/api`.

`config/firebase.js` cũng phân nhánh theo môi trường: local đọc `serviceAccountKey.json` (đã gitignore), production dùng **default credentials** của Google Cloud (không cần file key trong container). Storage bucket lấy từ `FIREBASE_STORAGE_BUCKET` hoặc suy ra `{project_id}.appspot.com`.

### 6.2. Ba middleware xác thực (`middlewares/auth.middleware.js`)

| Middleware | Ai dùng | Cách hoạt động |
| --- | --- | --- |
| `verifyAndGetUser` | Mọi endpoint nghiệp vụ | Lấy `Bearer <idToken>` → `auth.verifyIdToken` (Firebase kiểm chữ ký JWT) → tra `/nhan_vien` theo email lấy hồ sơ + vai trò → gắn `req.user` → `next()`. Thiếu/sai token → **401** |
| `verifyManagerRole` | Endpoint ghi nhạy cảm (employees, foods, ingredients, inventory) | Chạy `verifyAndGetUser` trước, rồi kiểm `req.user.vai_tro ∈ {manager, admin}` — sai → **403** |
| `verifyServerSecret` | `POST /chat/messages` khi ChatServer gọi | So header `X-Server-Secret` với `APP_SECRET_KEY`; đúng thì coi là "user hệ thống" — server nội bộ không có JWT của người dùng nào |

### 6.3. Controllers chuyên biệt (nghiệp vụ có logic riêng)

**`auth.controller.js`** — 4 endpoint:
- `login`: gọi Firebase Auth REST `signInWithPassword` bằng `FIREBASE_API_KEY` → nhận `idToken` → tra hồ sơ `/nhan_vien` theo email → trả `{ token, user }`. Sai mật khẩu/khóa → 401.
- `checkEmail`: tra email trong `/nhan_vien` → 200/404 (bước 1 của quên mật khẩu).
- OTP generate/verify → xem §10.3.
- `updatePassword`: kiểm **mật khẩu mạnh trước** (regex ≥8 ký tự, hoa+thường+số+ký tự đặc biệt — cùng pattern với client), **rồi mới** tiêu reset-token (nếu ngược lại, người dùng nhập mật khẩu yếu sẽ mất token oan), cuối cùng `auth.updateUser(uid, { password })`.

**`employees.controller.js`** — CRUD nhân viên "2 hệ thống song song" (Auth + DB):
```js
let createdUser = null;
try {
    createdUser = await auth.createUser({ email, password, displayName: employeeData.ho_ten });
    employeeData.AuthUid = createdUser.uid;
    delete employeeData.Password;                    // KHÔNG BAO GIỜ lưu mật khẩu vào DB
    await ref.child(nextId).set(employeeData);
    res.status(201).json({ success: true, employeeId: nextId });
} catch (err) {
    if (createdUser) await auth.deleteUser(createdUser.uid).catch(() => {});  // rollback "user mồ côi"
    next(err);
}
```
Ngoài ra: `getAll` **lọc theo quyền** — Admin/Manager thấy tất cả, nhân viên thường chỉ nhận nhóm manager/admin (đủ để chat, không lộ danh bạ); `PATCH /:id/lock` disable Firebase Auth user + set `trang_thai=inactive`; `DELETE` xóa cả Auth user lẫn node DB.

**`inventory.controller.js`** — nguyên tắc "không tin số tiền client gửi": server **tính lại** `thanh_tien = gia_nhap × so_luong` từng dòng + tổng phiếu, ghi `/nhap_kho/nk_XXX`, rồi **cộng dồn `ton_kho`** cho từng nguyên liệu trong `/nguyen_lieu`.

**`chat.controller.js`** — `GET messages?roomId=` đọc `tin_nhan/{roomId}`, lọc object hợp lệ, **sort theo `thoi_gian`** rồi trả mảng; `POST` push tin mới với key `msg_{serverTime}`.

**`upload.controller.js`** — upload ảnh lên **Firebase Storage** (mới):
```js
const token = crypto.randomUUID();
const objectPath = `${folder}/${Date.now()}_${crypto.randomBytes(4).toString('hex')}.${ext}`;
await bucket.file(objectPath).save(req.file.buffer, {
    resumable: false,
    metadata: { contentType: req.file.mimetype,
                metadata: { firebaseStorageDownloadTokens: token } }   // download token
});
const url = `https://firebasestorage.googleapis.com/v0/b/${bucket.name}` +
            `/o/${encodeURIComponent(objectPath)}?alt=media&token=${token}`;
```
Điểm hay: dùng **download token** của Firebase thay vì `makePublic()`/ACL → hoạt động cả khi bucket bật *Uniform bucket-level access*; `folder` bị lọc ký tự lạ (chỉ còn chữ/số/`_-`) chống path traversal; multer chỉ nhận `image/*`, tối đa 5 MB, giữ file trong RAM (memoryStorage) không ghi đĩa.

### 6.4. Generic Resource API — "một controller phục vụ 23 nhóm endpoint"

Vấn đề: hệ thống có ~30 node dữ liệu, đa số chỉ cần đúng 4 thao tác GET/POST/PUT/DELETE giống hệt nhau. Viết 30 controller lặp lại là vi phạm DRY. Giải pháp là một **factory**:

```js
// controllers/resources.controller.js
function makeResource(node, prefix) {
    const nextId = (val) => {                         // "prefixNNN" = max hiện có + 1
        let max = 0;
        for (const key of Object.keys(val || {})) {
            if (!key.startsWith(prefix)) continue;
            const n = parseInt(key.slice(prefix.length), 10);
            if (!Number.isNaN(n) && n > max) max = n;
        }
        return `${prefix}${(max + 1).toString().padStart(3, '0')}`;
    };
    return {
        getAll: async (req, res, next) => { ... res.json(snapshot.val() || {}); },
        add:    async (req, res, next) => { const id = nextId(...); await db.ref(`${node}/${id}`).set(req.body);
                                            res.status(201).json({ success: true, id }); },
        update: async (req, res, next) => { delete req.body.Id;                 // chặn ghi field kỹ thuật
                                            await db.ref(`${node}/${id}`).update(req.body); ... },
        remove: async (req, res, next) => { await db.ref(`${node}/${id}`).remove(); ... },
    };
}
```

```js
// routes/resources.routes.js — bảng khai báo là TOÀN BỘ phần việc phải làm khi thêm node mới
const RESOURCES = {
    'tables':          ['ban', 'ban_'],        'orders':        ['don_hang', 'dh_'],
    'payments':        ['thanh_toan', 'tt_'],  'customers':     ['khach_hang', 'kh_'],
    'feedback':        ['feedback', 'fb_'],    'attendance':    ['cham_cong', 'cc_'],
    'salaries':        ['luong', 'luong_'],    'leave-requests':['xin_nghi', 'xn_'],
    'notifications':   ['thong_bao', 'tb_'],   'parking':       ['bai_xe', 'bx_'],
    'incidents':       ['su_co', 'sc_'],       'warnings':      ['canh_bao', 'cb_'],
    'recipes':         ['cong_thuc', 'ct_'],   'promotions':    ['khuyen_mai', 'km_'],
    'expenses':        ['chi_phi', 'cp_'],     'losses':        ['that_thoat', 'loss_'],
    'reservations':    ['dat_ban', 'db_'],     'audit-logs':    ['nhat_ky', 'log_'],
    'broadcasts':      ['thong_bao_chung','bc_'], 'schedules':  ['lich_lam_viec', 'sch_'],
    'shift-registers': ['dang_ky_ca', 'sr_'],  'bug-reports':   ['bao_loi', 'bug_'],
    'point-logs':      ['diem_log', 'pl_'],
};
for (const [path, [node, prefix]] of Object.entries(RESOURCES)) {
    const ctrl = makeResource(node, prefix);
    const r = express.Router();
    r.get('/', verifyAndGetUser, ctrl.getAll);   r.post('/', verifyAndGetUser, ctrl.add);
    r.put('/:id', verifyAndGetUser, ctrl.update); r.delete('/:id', verifyAndGetUser, ctrl.remove);
    router.use(`/${path}`, r);
}
```

Kết quả: **23 nhóm × 4 = 92 endpoint** sinh ra từ ~100 dòng code; mọi endpoint đều bắt buộc đăng nhập (`verifyAndGetUser`); contract giống hệt nhóm `foods` nên client tái dùng được một DAL duy nhất (§8.2). Muốn thêm node mới chỉ cần **thêm 1 dòng** vào bảng `RESOURCES` + 1 DTO ở client.

### 6.5. Services

- **`firebase-auth.service.js`** — bọc thao tác với Firebase Auth: `signInWithPassword` (REST), `updateUser`, tra cứu user.
- **`email.service.js`** — Nodemailer + Gmail SMTP: sinh mã OTP 8 số, gửi mail template tiếng Việt; tài khoản gửi lấy từ `EMAIL_USER`/`EMAIL_PASS` (App Password).
- **`otp.service.js`** — trung tâm bảo mật quên mật khẩu (chi tiết §10.3).
- **`utils/logger.js`** — Winston: console có màu khi dev, JSON khi production; file `logs/combined.log` + `logs/error.log`.

---

## 7. API Reference — toàn bộ 116 endpoint

**Base URL:** local `http://localhost:3000/api` · production `https://asia-southeast1-<project>.cloudfunctions.net/api`
**Xác thực:** `Authorization: Bearer <Firebase ID Token>` cho mọi endpoint trừ nhóm Auth và `/health`. Riêng `/chat/messages` nhận thêm `X-Server-Secret`. **Content-Type:** `application/json` (riêng upload là `multipart/form-data`).

### 7.1. Nhóm chuyên biệt (24 endpoint)

| # | Method | Endpoint | Quyền | Mô tả |
| --- | --- | --- | --- | --- |
| 1 | GET | `/health` | Không | Kiểm tra server sống → `{"status":"ok"}` |
| 2 | POST | `/auth/login` | Không | Đăng nhập → `{ token, user }` |
| 3 | POST | `/auth/check-email` | Không | Email có tồn tại? → 200/404 |
| 4 | POST | `/auth/otp/generate` | Không | Sinh + gửi OTP 8 số qua email (mã KHÔNG trả về client) |
| 5 | POST | `/auth/otp/verify` | Không | Xác OTP → cấp `resetToken` dùng 1 lần |
| 6 | PUT | `/auth/password` | resetToken | Đổi mật khẩu (kiểm mạnh trước, tiêu token sau) |
| 7–11 | GET/POST/PUT/DELETE/PATCH | `/employees[/:id][/lock]` | Bearer / Manager+ | CRUD + khóa nhân viên (tạo kèm Auth user, có rollback) |
| 12–15 | GET/POST/PUT/DELETE | `/foods[/:id]` | Bearer / Manager+ | CRUD thực đơn |
| 16–19 | GET/POST/PUT/DELETE | `/ingredients[/:id]` | Bearer / Manager+ | CRUD nguyên liệu |
| 20–21 | GET/POST | `/inventory` | Bearer / Manager+ | Danh sách + tạo phiếu nhập (server tính lại tiền, cộng tồn) |
| 22–23 | GET/POST | `/chat/messages` | Bearer **hoặc** Secret | Lịch sử phòng chat / lưu tin nhắn |
| 24 | POST | `/upload` | Bearer | Upload ảnh (multipart `file` + `folder`) → `{ url }` |

### 7.2. Nhóm generic (23 tài nguyên × 4 = 92 endpoint, tất cả yêu cầu Bearer)

| Endpoint gốc | Node RTDB | Endpoint gốc | Node RTDB |
| --- | --- | --- | --- |
| `/tables` | `ban` | `/promotions` | `khuyen_mai` |
| `/orders` | `don_hang` | `/expenses` | `chi_phi` |
| `/payments` | `thanh_toan` | `/losses` | `that_thoat` |
| `/customers` | `khach_hang` | `/reservations` | `dat_ban` |
| `/feedback` | `feedback` | `/audit-logs` | `nhat_ky` |
| `/attendance` | `cham_cong` | `/broadcasts` | `thong_bao_chung` |
| `/salaries` | `luong` | `/schedules` | `lich_lam_viec` |
| `/leave-requests` | `xin_nghi` | `/shift-registers` | `dang_ky_ca` |
| `/notifications` | `thong_bao` | `/bug-reports` | `bao_loi` |
| `/parking` | `bai_xe` | `/point-logs` | `diem_log` |
| `/incidents` | `su_co` | `/warnings` | `canh_bao` |
| `/recipes` | `cong_thuc` | | |

Mỗi tài nguyên có đúng 4 thao tác, contract thống nhất:
```jsonc
GET    /tables        → 200 { "ban_001": {...}, "ban_002": {...} }
POST   /tables {body} → 201 { "success": true, "id": "ban_021" }     // id server tự sinh
PUT    /tables/ban_001 {field cần đổi} → 200 { "success": true }     // partial update
DELETE /tables/ban_001 → 200 { "success": true }
```

### 7.3. Mã trạng thái sử dụng

| Code | Ý nghĩa | Code | Ý nghĩa |
| --- | --- | --- | --- |
| 200/201 | Thành công / Tạo mới | 403 | Không đủ quyền; reset-token sai/hết hạn |
| 400 | Thiếu/sai dữ liệu; OTP sai/hết hạn; file không phải ảnh | 404 | Không tìm thấy (email, bản ghi) |
| 401 | Chưa đăng nhập / token hỏng | 429 | Nhập OTP sai quá 5 lần |
| | | 500 | Lỗi server (đã qua error.middleware + ghi log) |

---

## 8. Client WinForms — chi tiết từng tầng, từng màn hình

### 8.1. Luồng chuẩn xuyên lớp (lặp lại ở mọi tính năng)

```
Người dùng thao tác trên GUI (uc*.cs / dialog)
   → BUS (validate dữ liệu, tính toán nghiệp vụ)
      → DAL (dựng HttpRequestMessage qua DalHelper.Build, đính Bearer token)
         → Backend (middleware → controller → service) → Firebase
      ← JSON ← DAL parse về DTO/Dictionary
   ← BUS trả (bool Success, string Message, ...) 
← GUI bind DataGridView / hiện MsgBox
```

**`DalHelper`** là điểm hẹp duy nhất mọi request đi qua:
```csharp
internal static readonly HttpClient Client = new();          // MỘT instance cho toàn app
internal static HttpRequestMessage Build(HttpMethod m, string relativeUrl, object? body = null) {
    var req = new HttpRequestMessage(m, BaseUrl + relativeUrl);       // BaseUrl đọc App.config
    if (!string.IsNullOrEmpty(GlobalSession.Token))
        req.Headers.Authorization = new AuthenticationHeaderValue("Bearer", GlobalSession.Token);
    if (body != null)
        req.Content = new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8, "application/json");
    return req;
}
```
Dùng **một** `HttpClient` static để tránh lỗi kinh điển *socket exhaustion* của .NET khi mỗi lần gọi lại `new HttpClient()`.

### 8.2. `ResourceDAL` — một DAL generic cho 23 nhóm API

Đối xứng với generic API phía backend (§6.4), client chỉ cần **một** lớp DAL dùng generics:

```csharp
public static async Task<Dictionary<string, T>> GetAllAsync<T>(string path) {
    var response = await DalHelper.Client.SendAsync(DalHelper.Build(HttpMethod.Get, path));
    if (!response.IsSuccessStatusCode) return [];
    var dict = JsonConvert.DeserializeObject<Dictionary<string, T>>(await response.Content.ReadAsStringAsync()) ?? [];
    var idProp = typeof(T).GetProperty("Id");        // gán key node vào DTO.Id bằng reflection
    if (idProp != null && idProp.CanWrite)
        foreach (var kv in dict) if (kv.Value != null) idProp.SetValue(kv.Value, kv.Key);
    return dict;
}
public static Task<(bool, string, string? Id)> AddAsync<T>(string path, T dto)   // POST, đọc id server sinh
public static Task<(bool, string)> UpdateAsync(string path, string id, object data)  // PUT partial —
    // "data" có thể là object ẩn danh chỉ chứa field cần đổi: new { trang_thai = "trong" }
public static Task<(bool, string)> DeleteAsync(string path, string id)
```

Ba chi tiết đáng chú ý:
1. **Chịu lỗi offline**: `GetAllAsync` bọc try/catch trả `[]` — backend chưa bật thì màn hình trống chứ không crash; nhiều màn còn fallback dữ liệu mẫu.
2. **Partial update tự nhiên**: nhờ tham số `object data`, GUI truyền object ẩn danh đúng field muốn sửa → PUT không ghi đè `null` lên field khác (Firebase `update()` chỉ chạm field gửi lên).
3. **Reflection gán `Id`** giúp mọi DTO chỉ cần khai `public string? Id` là dùng được với lưới + update/delete.

### 8.3. Tầng BUS

- **BUS chuyên biệt:** `AuthBUS` (đăng nhập, phiên, đổi mật khẩu), `EmailBUS` (điều phối quên mật khẩu), `EmployeeBUS`, `FoodBUS`, `IngredientBUS`, `InventoryImportBUS` (tính `Subtotal`/`TotalAmount` trước khi gửi), `ChatBUS` (lịch sử + quy tắc roomId), `UploadBUS`, `Audit` (ghi nhật ký thao tác fire-and-forget vào `/nhat_ky`), `Validation`.
- **`ResourceBUS.cs`** chứa **23 lớp BUS mỏng** (TableBUS, OrderBUS, PaymentBUS, CustomerBUS, FeedbackBUS, AttendanceBUS, PointLogBUS, SalaryBUS, LeaveRequestBUS, NotificationBUS, ParkingBUS, IncidentBUS, WarningBUS, RecipeBUS, PromotionBUS, ExpenseBUS, LossBUS, ReservationBUS, AuditLogBUS, BroadcastBUS, ScheduleBUS, ShiftBUS, BugReportBUS) — mỗi lớp chỉ khai `const string P = "<path>"` rồi ủy quyền 4 method cho `ResourceDAL`:

```csharp
public static class TableBUS {
    const string P = "tables";
    public static Task<Dictionary<string, TableDTO>> GetAll() => ResourceDAL.GetAllAsync<TableDTO>(P);
    public static Task<(bool, string, string?)> Add(TableDTO d) => ResourceDAL.AddAsync(P, d);
    public static Task<(bool, string)> Update(string id, object d) => ResourceDAL.UpdateAsync(P, id, d);
    public static Task<(bool, string)> Delete(string id) => ResourceDAL.DeleteAsync(P, id);
}
```

- **`Validation.cs`** — bộ regex dùng chung: mật khẩu mạnh (`≥8, hoa, thường, số, ký tự đặc biệt` — **cùng pattern với server**), email, SĐT Việt Nam `^0[35789]\d{8}$`, `IsAnyEmpty(params string?[])`.

### 8.4. Đăng nhập & phiên làm việc

- `Login.cs`: nhập email/mật khẩu → `AuthBUS.LoginBUS` validate → `AuthDAL` POST `/auth/login` → lưu `GlobalSession.Token/CurrentUser/ExpiryTime = Now + 60'` → mở `MainDashboard` (menu dựng theo `Role`). Ngay khi form mở còn chạy **một request warm-up nền** (`_ = Task.Run(...)`) để trả trước chi phí JIT + bắt tay TCP của lần gọi HTTP đầu tiên.
- **Ghi nhớ đăng nhập:** mật khẩu mã hóa **DPAPI** (`ProtectedData.Protect`, scope `CurrentUser` — chỉ đúng tài khoản Windows đó giải mã được) rồi lưu Base64 vào `Properties.Settings` (`SavedEmail`/`SavedPassword` trong App.config). Hàm `Decrypt` nuốt exception trả chuỗi rỗng để settings hỏng không làm crash app lúc khởi động.
- **Quên mật khẩu:** chuỗi 3 form `ConfirmEmail → VerifyCode → ResetPassword` khớp với pipeline OTP server-side (§10.3).

### 8.5. `MainDashboard` — khung chính & menu động theo vai trò

- Menu khai báo bằng `record MenuItemConfig(string Group, string ButtonText, string TitleText, Func<UserControl> CreateUC)` trong dictionary `RoleMenus`; sidebar dựng động bằng vòng lặp (không thể đặt trong Designer vì mỗi role một danh sách). `Func<UserControl>` = **lazy factory** — chỉ `new` UserControl khi người dùng bấm lần đầu.
- **Cache màn hình:** `Dictionary<MenuItemConfig, UserControl> _ucCache` — mỗi màn dựng đúng 1 lần, các lần sau chỉ ẩn/hiện (`ShowUserControl`), chuyển màn ~20 ms và không rò rỉ handle.
- **Chống lệch layout khi minimize:** override `OnResize` bỏ qua khi `WindowState == Minimized` (WinForms tính lại Anchor theo client size ~0×0 gây chồng control khi phóng to lại).
- Header có nút **Báo lỗi** (mở `ReportBug` kèm sẵn tên màn hình đang mở → ghi node `/bao_loi`) và nút Đăng xuất (quay về `Login`, `GlobalSession.Logout()`, đóng các form khác).

**Menu đầy đủ theo 5 vai trò (đúng `RoleMenus` trong code):**

| Nhóm | Admin (13) | Manager (15) | Order Staff (12) | Barista (9) | Security (8) |
| --- | --- | --- | --- | --- | --- |
| CHÍNH | Tổng quan · Quản lý · Nhân viên · Tiền lương · Tiền chi · Xuất báo cáo | Tổng quan · Sản phẩm & Thực đơn · Đơn hàng & Hóa đơn · Nhân viên · Lịch ca làm · Khuyến mãi · Thất thoát | Tổng quan · Lên đơn/POS · Khách hàng (CRM) · Tích điểm · Đặt bàn · Đặt tại bàn QR · Tiền mặt | Tổng quan · Màn hình Bếp · Công thức pha chế · Cảnh báo NL | Tổng quan · Bãi xe · SOS An ninh |
| KHÁCH HÀNG | Feedback · Thông báo · Gửi thông báo | Feedback · Thông báo · Gửi thông báo | — | — | — |
| CÁ NHÂN | Điểm danh · Nhật ký · Chat nội bộ · Hồ sơ cá nhân | Xin nghỉ · Điểm danh · Nhật ký · Chat nội bộ · Hồ sơ cá nhân | Lịch sử chấm công · Xin nghỉ · Chọn ca/Đổi ca · Chat nội bộ · Hồ sơ cá nhân | (như Order Staff) | (như Order Staff) |

### 8.6. Chi tiết từng màn hình (dữ liệu đọc/ghi thật)

**Nhóm ADMIN**

| Màn | Đọc từ | Ghi vào | Nghiệp vụ chính |
| --- | --- | --- | --- |
| `ucDashboard_Admin` | payments, parking, expenses, losses, feedback | — | 4 thẻ KPI **tính từ dữ liệu thật**: Doanh thu = Σ`tien_thuc_thu` + phí xe đã ra; Lợi nhuận = DT − chi phí − thất thoát; tỷ lệ feedback tốt/xấu. Nút "Chi tiết →" mở `ChartDetail` (biểu đồ cột 12 tháng, gom nhóm client-side theo timestamp) và `MetricDetail` (cấu thành từng khoản theo tháng) |
| `ucManagers_Admin` | employees, leave-requests, audit-logs | leave-requests | Quản trị riêng nhóm Manager: hồ sơ, đơn nghỉ của manager, nhật ký thao tác; duyệt/từ chối đơn |
| `ucPayroll_Admin` | salaries, employees | salaries | Bảng lương: lương cứng suy theo bộ phận, sửa dòng qua `RecordEdit` → `SalaryBUS.Update`, tổng quỹ lương tính lại ngay |
| `ucExpenses_Admin` | expenses, employees | expenses | Tiền chi: thêm/sửa khoản chi (ngày, danh mục, số tiền, người chi, chứng từ) |
| `ucReport_Admin` | payments, salaries+employees, ingredients, feedback | — | 1 lưới đổi 4 schema báo cáo (doanh thu/lương/tồn kho/feedback) — `AutoGenerateColumns=true` + `Columns.Clear()`; **xuất Excel/PDF thật** qua `GridExporter` |
| `ucFeedback_Admin` | feedback | feedback | Gắn cờ đã xử lý, phản hồi (`ReplyFeedback`), xóa |
| `ucNotification_Admin` | notifications, employees | notifications | Trung tâm thông báo: lọc theo loại, đánh dấu đã đọc |
| `ucAuditLog` (Shared) | audit-logs | — | Nhật ký: thời gian, nhân viên, vai trò, thao tác, đối tượng, lý do, IP; double-click mở `AuditLogDetail` |

**Nhóm MANAGER**

| Màn | Đọc từ | Ghi vào | Nghiệp vụ chính |
| --- | --- | --- | --- |
| `ucOverview_Manager` | payments, feedback, notifications | — | Tổng quan ca: doanh thu hôm nay, cảnh báo, feedback mới |
| `ucProducts_Manager` | foods, ingredients, inventory, payments | foods | Card món theo danh mục; thêm (`AddFood`) / sửa (`EditFood`) / chi tiết-xóa (`FoodDetail`) — **2 dialog Add/Edit có nút chọn ảnh → `UploadBUS.UploadImage(file, "mon_uong")` → lưu URL vào `hinh_anh_url`**; nút "Quản lý kho" mở `WarehouseManager` (tồn kho, tô đỏ dưới định mức) → `AddInventoryImport` lập phiếu nhập (tay hoặc **đọc Excel/CSV** qua `InventoryImportExcelReader`) |
| `ucOrders_Manager` | tables, orders, foods | — | Join 3 nguồn hiển thị đơn + món + bàn, trạng thái chế biến từng dòng, tạm tính |
| `ucStaff_Manager` | employees, salaries, leave-requests | employees, leave-requests | CRUD nhân viên (dialog Add/Edit/Detail — tạo qua backend kèm Auth user), khóa tài khoản, xem lương + duyệt nghỉ của từng người |
| `ucSchedule_Manager` | schedules, employees, leave-requests | schedules | Lịch tuần dạng ma trận NV × T2..CN (node `lich_lam_viec`), tô màu ca, cảnh báo trùng người nghỉ đã duyệt |
| `ucPromotion_Manager` | promotions | promotions | 3 tab happy-hour/combo/voucher trên cùng node `khuyen_mai` (phân biệt field `loai`) |
| `ucLoss_Manager` | losses, employees | losses | Ghi nhận thất thoát: khoản mục, số lượng, giá trị, nguyên nhân, người phát hiện |
| `ucFeedback_Manager` / `ucNotification_Manager` | feedback / leave-requests, schedules, employees | feedback / leave-requests, schedules | Phản hồi khách; xử lý thông báo — duyệt đơn nghỉ ngay trong màn thông báo, khi duyệt tự cập nhật lịch ca (`ScheduleBUS.Add/Update` đánh dấu OFF) |

**Nhóm ORDER STAFF**

| Màn | Đọc từ | Ghi vào | Nghiệp vụ chính |
| --- | --- | --- | --- |
| `ucPOS_Order` | foods, tables, payments, orders, employees | **orders, payments, tables** | Trái: card món theo danh mục (giá + nút "+", badge số lượng); giữa: giỏ hàng (`Dictionary<string,(qty,price)>` cộng dồn O(1) rồi dựng lại DataTable bind lưới); thanh toán qua `PaymentDialog` (tiền mặt / thẻ / **VietQR sinh mã thật**). Khi chốt: `PersistOrderAndPayment` ghi `don_hang` (chi tiết `ctd_XXX`) → `thanh_toan` → giải phóng bàn `TableBUS.Update(id, new { trang_thai = "trong" })`. Tab "Sơ đồ bàn" đọc node `ban` + các thao tác gộp/tách/chuyển bàn, tách hóa đơn; tab "Lịch sử" join payments+orders+tables+employees. Hủy đơn bắt buộc nhập lý do |
| `ucCRM_Order` | customers | customers | Hồ sơ khách: thêm/sửa; tìm kiếm tại chỗ bằng `DataView.RowFilter` (escape `'` → `''`) |
| `ucLoyalty_Order` | customers, point-logs | customers, point-logs | Tích/đổi điểm: mỗi giao dịch vừa `CustomerBUS.Update(diem_tich_luy)` vừa ghi 1 dòng `PointLogBUS.Add(delta ±)` làm nhật ký; xếp hạng thành viên theo điểm |
| `ucReservation_Order` | reservations | reservations | Đặt bàn trước: khách, SĐT, ngày giờ, bàn, số khách; đổi trạng thái xác nhận/hủy |
| `ucSelfOrder_Order` | orders, tables, foods | orders | Sinh **QR link** `SelfOrderBaseUrl?table=...` cho từng bàn (`Qr.Url`); bảng "đơn tự đặt" lọc `don_hang.nguon == "qr"`; nút *Giả lập khách quét QR* tạo **đơn thật** `Source="qr", Status="pending"` vào Firebase → đơn xuất hiện đồng thời ở POS và KDS của Barista (demo luồng realtime end-to-end nhiều máy) |
| `ucCashManagement_Order` | payments | — | Quỹ tiền mặt theo ca: tổng thu tiền mặt từ node thật, nhập quỹ đầu/cuối ca, đối soát chênh lệch |

**Nhóm BARISTA**

| Màn | Đọc từ | Ghi vào | Nghiệp vụ chính |
| --- | --- | --- | --- |
| `ucKDS_Barista` | orders, tables, foods | orders | Kanban 3 cột **Chờ / Đang pha / Hoàn thành** (3 FlowLayoutPanel); card đơn hiện bàn + danh sách món; bấm nút → `OrderBUS.Update` đổi `trang_thai`/`trang_thai_che_bien` — máy khác thấy khi refresh |
| `ucRecipe_Barista` | recipes | — | Cẩm nang công thức: các bước + bảng nguyên liệu (định lượng, loại chính/phụ/topping/trang trí) |
| `ucAlert_Barista` | warnings, employees | **warnings + notifications** | Barista bấm "Báo hết/sắp hết NL" → ghi `canh_bao` **và** bắn `thong_bao` đến Manager |

**Nhóm SECURITY**

| Màn | Đọc từ | Ghi vào | Nghiệp vụ chính |
| --- | --- | --- | --- |
| `ucParking_Security` | parking | parking | Xe vào: `ParkingBUS.Add` (biển số, loại, giờ vào); xe ra: `Update` (giờ ra, phí, trạng thái `da_ra`); đếm chỗ trống realtime, nhãn đỏ khi ≤ 5 chỗ |
| `ucSOS_Security` | incidents, employees | **incidents + notifications** | Báo sự cố theo loại + mức độ (`ReportIncident`); SOS khẩn bắn thông báo cho quản lý |

**Nhóm DÙNG CHUNG (Shared)**

| Màn | Đọc từ | Ghi vào | Nghiệp vụ chính |
| --- | --- | --- | --- |
| `ucInternalChat` | employees (danh bạ), chat history REST | (gửi qua SignalR) | Chat 1-1 + phòng chung; chi tiết §9 |
| `ucProfile` | schedules | employees | Xem/sửa hồ sơ bản thân (partial update), **đổi avatar → upload Storage folder `avatar`**, xem lịch tuần của mình |
| `ucLeaveRequest` | leave-requests | leave-requests | NV gửi đơn (`Add`, trạng thái `cho_duyet`); Manager mở cùng màn thấy nút duyệt (`LeaveRequestDetail` → `Update` trạng thái + người duyệt + thời gian) |
| `ucWorkTracking` (Admin/Manager) | attendance | — | Bảng công mọi NV + thẻ tổng hợp (tổng ca/giờ/muộn/nghỉ), tô màu theo trạng thái |
| `ucAttendanceHistory` | attendance, employees | — | Lịch sử chấm công có lọc tháng/nhân viên, xuất báo cáo |
| `ucShiftRegister` | shift-registers | shift-registers | Ca trống đăng ký (`open`), ca của tôi (`mine`), yêu cầu đổi ca (`swap`) trên node `dang_ky_ca` |
| `ucBroadcastCenter` | broadcasts | broadcasts | Soạn + phát thông báo nội bộ (`SendBroadcast`), mức độ, người nhận |
| `ucOverview_Staff` | notifications, attendance, leave-requests | — | Tổng quan cá nhân của Order/Barista/Security: giờ công tháng, thông báo mới, trạng thái đơn nghỉ |

### 8.7. QR & VietQR — sinh mã thanh toán quét được thật

`GUI/Common/Qr.cs` không dùng ảnh giả: nó **tự dựng payload chuẩn EMVCo / VietQR (Napas 247)** rồi render bằng QRCoder:

```csharp
string merchant = Tlv("00", "A000000727")                                  // GUID Napas
                + Tlv("01", Tlv("00", bankBin) + Tlv("01", accountNo))     // BIN ngân hàng + số TK
                + Tlv("02", "QRIBFTTA");                                   // chuyển tới tài khoản
sb.Append(Tlv("00", "01"));                    // Payload Format Indicator
sb.Append(Tlv("01", amount > 0 ? "12" : "11"));// 12 = QR động (kèm số tiền)
sb.Append(Tlv("38", merchant));
sb.Append(Tlv("53", "704"));                   // VND
if (amount > 0) sb.Append(Tlv("54", amount.ToString()));
sb.Append(Tlv("58", "VN"));
if (info.Length > 0) sb.Append(Tlv("62", Tlv("08", info)));   // nội dung CK (đã bỏ dấu tiếng Việt)
sb.Append("6304");
sb.Append(Crc16(sb.ToString()).ToString("X4"));                // CRC-16/CCITT-FALSE — checksum EMVCo
```

App ngân hàng quét mã trong `PaymentDialog` sẽ **điền sẵn số tài khoản + số tiền + nội dung**. Cấu hình BIN/số tài khoản nằm trong `QrConfig.cs`. Hàm `Qr.Url()` tái dùng cho QR tự đặt món. Render qua `PngByteQRCode` (thuần managed, không phụ thuộc GDI).

### 8.8. Upload ảnh & hiển thị ảnh

- **Gửi:** `UploadDAL.UploadImageAsync(filePath, folder)` dựng `MultipartFormDataContent` (bytes + content-type đoán theo đuôi file + field `folder`), POST `/api/upload` kèm Bearer → nhận `{ url }`. `UploadBUS.UploadImage` là facade cho GUI; nơi dùng: `AddFood`/`EditFood` (folder `mon_uong`), `ucProfile` (folder `avatar`).
- **Nhận:** `ImageLoader` (Common) tải ảnh từ URL về `PictureBox` bất đồng bộ + cache, để card món/avatar không chặn UI.

### 8.9. Bộ helper hạ tầng UI (`GUI/Common`) — "viết một lần, mọi màn hưởng"

| Helper | Nhiệm vụ |
| --- | --- |
| `Theme` | Bảng màu dark tập trung (nền `#252526`, panel surface, teal `31,138,154`, Green/Red/Amber/Blue/Purple), font helper `Theme.F()`, format tiền `Theme.Vnd()` |
| `WindowChrome` | Thanh tiêu đề tùy biến (min/max/close), kéo thả cửa sổ; điểm gắn tập trung của `MnemonicFix`; `ShowUc`/`CreateDialog` host UserControl thành popup đúng theme |
| `FormCorners` | Bo góc form bằng API `DwmSetWindowAttribute` |
| `MsgBox` | Hộp thoại thay thế `MessageBox`: 4 loại Info/Success/Warning/Error, bo góc, dark; `MsgBox.OwnerWindow(control)` tìm form cha (`FindForm()` hoặc `TopLevelControl`) để modal neo đúng cửa sổ |
| `RecordDetail` / `RecordEdit` | Dialog xem/sửa **mọi** dòng lưới — `RecordDetail.FromRow(row, title)` tự liệt kê đủ cột; dùng chung cho tất cả màn (double-click) |
| `InputDialog` | Hỏi một chuỗi (vd lý do hủy đơn) |
| `MnemonicFix` | Tắt xử lý mnemonic toàn app để ký tự `&` hiển thị đúng (Label/ButtonBase `UseMnemonic=false`; Guna2 qua reflection `TextFormatNoPrefix`, có cache `PropertyInfo`) |
| `AutoFadeScroll` | Giấu scrollbar trắng của Windows **tận gốc**: subclass `NativeWindow`, gỡ style `WS_VSCROLL` ngay tại `WM_NCCALCSIZE`; vẽ thanh chỉ báo teal 4px tự mờ; `AttachAll` quét mọi Panel/FlowLayoutPanel AutoScroll |
| `DgvDarkScroll` / `ThemedScroll` | Scrollbar teal cho DataGridView / panel cuộn dọc theo bước |
| `GridColumnGuard` | `SyncColumnNames`: ép `Column.Name = DataPropertyName` — chống Visual Studio designer đổi Name làm `Columns["..."]` trả null |
| `GridAutoAlign` | Căn lề cột theo nội dung: chuỗi ngắn → giữa, dài → trái, tiền → phải |
| `SearchFilter` | `AllColumnsFilter`: ô tìm kiếm lọc **mọi cột** của DataTable (escape ký tự đặc biệt) |
| `DgvRefresh` | Gắn nút 🔄 nổi bên trong góc lưới, chỉ reload đúng lưới đó |
| `ResponsiveLayout` | Tự bổ sung Anchor cho cây control khi UC còn ở kích thước thiết kế → phóng to không vỡ layout |
| `NotificationFeed` | Khung danh sách thông báo dạng feed dùng chung |
| `EmployeeText` | Dịch role/status sang tiếng Việt cho hiển thị (giữ giá trị thô cho dialog) |
| `ImageLoader` | Tải ảnh URL bất đồng bộ + cache cho PictureBox |
| `BaseDashboard`, `DragPanel`, `ControlExtensions`, `DialogAutosizeHelper`, `FormCorners`, `QrConfig`, `AgentDebugLog` | Kéo panel, extension, autosize dialog có cuộn, cấu hình QR, log chẩn đoán khi debug |

### 8.10. Xuất file & nhập file

- **`GridExporter.ExportExcel`** — ghi `.xlsx` thật bằng ClosedXML: header in đậm nền teal, `AdjustToContents`, luôn mở `SaveFileDialog` cho người dùng chọn nơi lưu.
- **`GridExporter.ExportPdf`** — vẽ lưới ra bitmap rồi **tự dựng file PDF tối giản** nhúng ảnh (không cần thư viện PDF ngoài, tiếng Việt hiển thị đúng vì là ảnh render sẵn).
- **`InventoryImportExcelReader`** — đọc file Excel (ClosedXML) hoặc CSV thành các dòng `InventoryImportPrefillLine` để prefill dialog `AddInventoryImport` — nhập kho hàng chục dòng không phải gõ tay.

---

## 9. Chat Server SignalR

### 9.1. Phía server (`server/ChatServer`)

`ChatHub` có 3 method chính và 2 override:

```csharp
public async Task JoinRoom(string roomId)  => Groups.AddToGroupAsync(Context.ConnectionId, roomId);
public async Task LeaveRoom(string roomId) => Groups.RemoveFromGroupAsync(Context.ConnectionId, roomId);

public async Task SendMessageWithRoom(string senderId, string senderName, string message, string roomId) {
    await Clients.Group(roomId).SendAsync("ReceiveMessageWithRoom", senderId, senderName, message, roomId);
    _ = SaveMessageAsync(roomId, senderId, senderName, message);   // fire-and-forget: lưu DB KHÔNG chặn broadcast
}
public override async Task OnConnectedAsync() {                     // ai kết nối cũng vào phòng chung
    await Groups.AddToGroupAsync(Context.ConnectionId, "room_global");
}
```

`SaveMessageAsync` POST về backend `chat/messages` bằng `HttpClient` "ChatApi" (đã cài sẵn header `X-Server-Secret`) — **client không bao giờ tự lưu tin nhắn**, tránh mất đồng bộ giữa broadcast và DB.

### 9.2. Phía client (`ChatManager` + `ucInternalChat`)

- Kết nối: `HubConnectionBuilder().WithUrl($"http://{ChatServerIP}:8080/chathub").WithAutomaticReconnect([0s, 2s, 5s, 10s])`; `StartAsync` bọc `CancellationTokenSource(5s)` để không treo 21 giây TCP timeout khi sai IP; toàn bộ connect chạy `Task.Run` ngoài luồng UI.
- **Sự kiện `Reconnected` phải `JoinRoom` lại** — SignalR không giữ group sau khi rớt mạng; thiếu bước này thì "online mà không nhận được tin".
- Callback `ReceiveMessageWithRoom` chạy trên thread nền → mọi thao tác UI bọc `uiControl.Invoke(...)` + kiểm `IsDisposed/IsHandleCreated` tránh lỗi cross-thread.
- Đổi người chat: `ChatBUS.GetRoomId(id1, id2)` — phòng chung `room_global`, chat riêng `chat_{idNhỏ}_{idLớn}` (sort 2 ID để 2 chiều ra cùng một phòng) → `LeaveRoom` cũ + `JoinRoom` mới + tải lịch sử REST `GET /chat/messages?roomId=`.

---

## 10. Thiết kế bảo mật

1. **JWT mỗi request** — mọi endpoint nghiệp vụ đòi Firebase ID Token; token sống ~60 phút; client đặt hạn phiên đúng 60 phút để chủ động đăng xuất trước khi token chết.
2. **RBAC thực thi ở server** — UI ẩn menu chỉ là tiện lợi; quyền thật nằm ở `verifyManagerRole` (403) và lọc dữ liệu trong controller (NV thường gọi `GET /employees` chỉ nhận nhóm lãnh đạo).
3. **Mật khẩu không bao giờ chạm DB** — tạo nhân viên: mật khẩu chỉ đi tới Firebase Auth, server `delete employeeData.Password` trước khi ghi hồ sơ; đăng nhập qua `signInWithPassword` (Firebase tự so hash).
4. **Pipeline OTP** (`otp.service.js`): mã 8 số **chỉ tồn tại trong email** — DB lưu `sha256(code + APP_SECRET_KEY)` (pepper server-side, chống brute-force offline 10⁸ tổ hợp); TTL **60 giây**; tối đa **5 lần** thử sai (429); key node là `sha256(email)` (vừa hợp lệ key RTDB vừa không lộ email); xác thực xong cấp **reset-token 32 byte ngẫu nhiên, lưu hash, TTL 1 phút, dùng đúng 1 lần** (`consumeResetToken` xóa node).
5. **Thứ tự đổi mật khẩu:** kiểm tra mật khẩu mạnh **trước**, tiêu token **sau** — tránh người dùng mất token vì nhập mật khẩu yếu.
6. **Server-to-server bằng `X-Server-Secret`** — ChatServer không có JWT người dùng; secret chung `APP_SECRET_KEY` chỉ nằm trong `.env` và `appsettings.json` (cả hai gitignore/không commit giá trị thật).
7. **Rollback "user mồ côi"** — tạo Auth xong mà ghi DB lỗi thì `deleteUser` ngay, tránh email bị chiếm không có hồ sơ.
8. **Server tính lại tiền** — `thanh_tien`, tổng phiếu nhập tính ở controller, không tin client.
9. **Ghi nhớ đăng nhập bằng DPAPI** — mật khẩu local mã hóa theo tài khoản Windows, không plaintext trong file settings.
10. **Upload an toàn** — multer chỉ nhận `image/*` ≤ 5 MB; tên folder bị sanitize; file phát hành qua download-token URL, không mở public toàn bucket.
11. **Vệ sinh secrets** — `serviceAccountKey.json`, `.env` gitignore; `helmet` bật header an toàn; hai lớp validate (client UX + server bắt buộc) dùng **cùng một pattern** mật khẩu để không lệch hành vi.

---

## 11. Tối ưu hiệu năng & trải nghiệm

Đợt rà soát trước khi nộp (07/2026) xử lý 4 nhóm vấn đề, tất cả theo một công thức: **viết helper dùng chung rồi cắm vào điểm gắn tập trung** (`WindowChrome.Apply`, `MainDashboard.ShowUserControl`, `AutoFadeScroll.AttachAll`) — 28 màn của 5 vai trò được sửa đồng loạt mà diff chỉ chạm ~10 file.

| Vấn đề | Nguyên nhân gốc | Cách sửa | Kết quả đo được |
| --- | --- | --- | --- |
| Ký tự `&` thành `_` ("Sản phẩm _Thực đơn") | WinForms coi `&` là mnemonic (Alt+phím) | `MnemonicFix` quét cây control: `UseMnemonic=false`, Guna2 `TextFormatNoPrefix=true` (reflection + cache) | Viết `&` tự nhiên trong mọi Text, không cần escape `&&` |
| Scrollbar trắng lạc dark theme, lóe khi cuộn nhanh | Windows vẽ lại scrollbar gốc giữa hai event | `VScrollStripper` gỡ `WS_VSCROLL` ngay tại `WM_NCCALCSIZE` (trước khi kịp vẽ) + thanh teal 4px tự mờ | Thanh gốc không bao giờ xuất hiện; cuộn chuột vẫn hoạt động |
| Mở màn Chat treo ~20 giây | `ChatServerIP` LAN không tồn tại → chờ đủ TCP connect timeout ~21s trên luồng UI | Timeout 5s bằng `CancellationTokenSource` + connect trong `Task.Run` | 20,1 s → **22–48 ms** |
| Màn dữ liệu chiếm luồng UI; mở lại màn chậm; rò rỉ bộ nhớ | HTTP + parse JSON chạy trong handler `Load`; mỗi click dựng lại UC không dispose | `await Task.Run(BUS...)` cho mọi màn dữ liệu; cache UC trong `MainDashboard`; warm-up HTTP ở form Login; DoubleBuffered | Mở màn dữ liệu 0,9–2,4 s → 60–160 ms; mở lại ~20–25 ms; khoảng đơ UI dài nhất ≤ 265 ms |

Kèm quy ước chống crash: **mọi handler `async void` phải tự try/catch** (exception lọt ra ngoài sẽ bật hộp thoại JIT-debug của WinForms).

---

## 12. Kiểm thử & chất lượng mã

- **Backend — Jest** (`backend/tests/`, chạy `npm test` với `--runInBand --forceExit`): 5 file test + 1 mock — `auth.controller.test.js` (login sai/đúng, check-email, luồng OTP), `employees.controller.test.js` (CRUD + rollback + lọc quyền), `foods.controller.test.js`, `chat.controller.test.js` (sort lịch sử, validate roomId), `auth.middleware.test.js` (401/403); `mockFirebase.js` giả lập Admin SDK để test không chạm Firebase thật.
- **Client:** kiểm thử thủ công theo kịch bản trong `HUONG_DAN_TEST_UI.md` (liệt kê từng role, từng màn, thao tác kỳ vọng — lưu ý file viết ở giai đoạn trước nên nhãn REAL/MOCK trong đó đã cũ: hiện **mọi màn đã REAL**); kỹ thuật kiểm layout bằng harness `DrawToBitmap` chụp render off-screen + stopwatch đo thời gian mở màn (số liệu §11). Thư mục test xUnit cũ của client đã gỡ khỏi repo trong đợt tái cấu trúc.
- **Kịch bản hồi quy quan trọng:** đăng nhập sai → 401; tài khoản khóa → chặn từ BUS; OTP sai 5 lần → 429; reset-token dùng lần 2 → 403; Barista `POST /employees` → 403; nhập kho xong `ton_kho` tăng đúng; mở màn "Điểm danh" không ném `NullReferenceException` (bug lưới `AutoGenerateColumns=false` đã sửa — xem báo cáo §11).

---

## 13. Cài đặt, cấu hình & vận hành

### 13.1. Yêu cầu & cài lần đầu

Node.js ≥ 18 (khuyến nghị 20), .NET 8 SDK, Visual Studio 2022, tài khoản Firebase (bật RTDB + Auth Email/Password + Storage).

```powershell
.\scripts\setup.ps1        # kiểm tra môi trường + npm install + dotnet restore
```

### 13.2. Cấu hình

```env
# backend/.env  (tạo từ .env.example)
PORT=3000
FIREBASE_DATABASE_URL=https://<project>-default-rtdb.asia-southeast1.firebasedatabase.app
FIREBASE_API_KEY=<Web API Key>          # cho signInWithPassword
FIREBASE_STORAGE_BUCKET=<project>.appspot.com   # cho upload ảnh (có thể suy tự động)
APP_SECRET_KEY=<chuỗi bí mật mạnh>      # pepper OTP + X-Server-Secret
EMAIL_USER=<gmail> / EMAIL_PASS=<app password>  # gửi OTP
```
- `backend/serviceAccountKey.json`: tải từ Firebase Console → Service Accounts (đã gitignore).
- `server/ChatServer/appsettings.json`: `ChatApi:BaseUrl` + `ChatApi:ServerSecret` (= `APP_SECRET_KEY`).
- `client/GUI/App.config`: `ApiBaseUrl` (đổi khi backend ở máy khác/cloud), `ChatServerIP` (ChatServer in sẵn giá trị cần điền khi khởi động).
- Import dữ liệu mẫu: Firebase Console → Realtime Database → Import JSON → chọn `qlcafe-rtdb-import-full.json`.

### 13.3. Chạy

```powershell
.\scripts\start-all.ps1 -WithClient    # Backend + ChatServer + Client
.\scripts\start-all.ps1                # Backend + ChatServer
.\scripts\start-backend.ps1            # riêng backend (3000)
.\scripts\start-server.ps1             # riêng ChatServer (8080, tự in IP LAN)
.\scripts\start-client.ps1             # build + chạy GUI.exe
.\scripts\start-multi-client.ps1       # mở nhiều client cùng lúc (demo chat/realtime nhiều máy)
```
Script lưu **UTF-8 có BOM** để Windows PowerShell 5.1 đọc đúng tiếng Việt (hoặc dùng `pwsh`). Kiểm tra nhanh: `curl http://localhost:3000/health`. Deploy backend: `firebase deploy --only functions`.

---

## 14. Trạng thái hiện tại, hạn chế & hướng phát triển

**Đã hoàn thành (nhánh `final-backend`):**
- 100% màn hình nối dữ liệu thật qua BUS → REST → Firebase (kiểm chứng bằng grep: mọi `uc*` đều gọi `*BUS.GetAll/Add/Update/Delete`).
- Backend generic 23 tài nguyên + 24 endpoint chuyên biệt = **116 endpoint**; upload ảnh Firebase Storage; deploy được lên Cloud Functions.
- VietQR chuẩn EMVCo quét được bằng app ngân hàng; QR tự đặt món tạo đơn thật chảy xuyên POS → KDS.
- Bộ helper UI dùng chung + đợt tối ưu hiệu năng có số đo trước/sau.

**Hạn chế biết trước (trade-off có chủ đích):**
- Màn dữ liệu **refresh theo thao tác** (nút 🔄 / mở lại màn) thay vì tự động — realtime hiện chỉ áp dụng cho chat qua SignalR; có thể mở rộng đẩy sự kiện đơn hàng/cảnh báo qua chính ChatHub.
- `GET` các node trả **toàn bộ** rồi lọc client-side — chấp nhận được ở quy mô quán (vài trăm bản ghi), muốn scale cần query/pagination phía server.
- Chưa có refresh-token — hết 60 phút phải đăng nhập lại (chọn giải pháp đơn giản, an toàn).
- `docs/dataflow.md` mục OTP và `HUONG_DAN_TEST_UI.md` viết ở giai đoạn trước, một số mô tả đã cũ so với code (`BAO_CAO_TONG_HOP.md` là bản chuẩn mới nhất).

**Hướng phát triển:** đẩy realtime cho đơn hàng/KDS qua SignalR group theo vai trò; trang web self-order thật cho khách quét QR; báo cáo nâng cao (top món, giờ cao điểm); refresh-token + đăng nhập đa thiết bị; Firebase Security Rules chặt cho môi trường production.

---

## 15. Phụ lục — thống kê mã nguồn

| Khối | Số file | Số dòng | Ghi chú |
| --- | --- | --- | --- |
| Client C# (`client/`) | 198 file `.cs` | ~37.000 dòng | trong đó 64 file `.Designer.cs` (layout khai báo); 4 project GUI/BUS/DAL/DTO |
| Backend JS (`backend/`) | 48 file `.js` | ~1.800 dòng | gồm cả 5 file test Jest + mock |
| Chat Server C# (`server/`) | 2 file `.cs` | ~157 dòng | Program + ChatHub — nhỏ đúng chủ đích |
| Tài liệu (`docs/` + gốc) | 10 file `.md` | — | báo cáo tổng hợp, kiến trúc, API, DB, dataflow, forms, setup, hướng dẫn test |
| Dữ liệu mẫu | 19 node / ~240 bản ghi | — | `qlcafe-rtdb-import-full.json` |
| REST API | **116 endpoint** | — | 24 chuyên biệt + 92 generic |
| Màn hình | 36 UserControl + 20 dialog + 5 form Auth/khung | — | phục vụ 5 vai trò, 57 mục menu |

> *Tài liệu tổng hợp từ mã nguồn thực tế trên nhánh `final-backend` (đã đối chiếu từng con số với code/route/DTO). Chi tiết dạng "báo cáo học thuật" — sơ đồ BFD/Use Case/Sequence/DFD/ERD, đặc tả use case, chẩn đoán lỗi — xem [docs/BAO_CAO_TONG_HOP.md](docs/BAO_CAO_TONG_HOP.md).*
