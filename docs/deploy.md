# Hướng dẫn Deploy miễn phí — Backend + Chat Server

Đưa **Backend Express** và **ChatServer SignalR** lên internet để client chạy được từ bất kỳ máy nào (không cần chung mạng LAN).

| Service | Công nghệ | Deploy lên | Cách chạy |
|---------|-----------|-----------|-----------|
| `backend/` | Node.js 20 + Express | **Render** (free) | Native Node |
| `server/ChatServer/` | ASP.NET Core 8 SignalR | **Render** (free) | Docker ([Dockerfile](../server/ChatServer/Dockerfile)) |

> **Vì sao Render?** Miễn phí **không cần thẻ tín dụng**, hỗ trợ WebSocket (bắt buộc cho SignalR),
> deploy thẳng từ GitHub, đã có sẵn blueprint [`render.yaml`](../render.yaml) ở gốc repo.
> Nhược điểm duy nhất: service free **ngủ sau 15 phút không có request** — xem [§5](#5-lưu-ý-cold-start-service-free-tự-ngủ).

---

## 1. Chuẩn bị (làm 1 lần, ~5 phút)

### 1.1 Push repo lên GitHub

Repo phải nằm trên GitHub (public hoặc private đều được). Đã có sẵn thì bỏ qua.

### 1.2 Tạo chuỗi base64 của serviceAccountKey.json

Render không có sẵn credentials của Google như Cloud Functions, nên backend nhận service account
qua biến môi trường `FIREBASE_SERVICE_ACCOUNT_BASE64` (đã hỗ trợ trong
[`backend/src/config/firebase.js`](../backend/src/config/firebase.js)).

Chạy trong PowerShell tại thư mục gốc repo — lệnh này copy chuỗi base64 vào clipboard:

```powershell
[Convert]::ToBase64String([IO.File]::ReadAllBytes("backend\serviceAccountKey.json")) | Set-Clipboard
```

> ⚠️ Chuỗi này chứa private key — chỉ dán vào ô env var trên Render, **không** commit, không gửi qua chat.

### 1.3 Tạo tài khoản Render

[https://render.com](https://render.com) → **Get Started** → đăng nhập bằng GitHub. Không cần thẻ.

---

## 2. Deploy bằng Blueprint (khuyến nghị)

1. Render Dashboard → **New +** → **Blueprint** → chọn repo `NT106_QuanLyQuanCafe_Nhom2`.
2. Render đọc [`render.yaml`](../render.yaml) và hiện 2 service: `qlcafe-backend` + `qlcafe-chat`,
   kèm form điền env vars:

   **`qlcafe-backend`:**

   | Biến | Giá trị |
   |------|---------|
   | `FIREBASE_DATABASE_URL` | `https://<project-id>-default-rtdb.asia-southeast1.firebasedatabase.app` |
   | `FIREBASE_API_KEY` | Web API Key (Firebase Console → Project Settings → General) |
   | `FIREBASE_STORAGE_BUCKET` | để trống (tự suy ra) hoặc `<project-id>.appspot.com` |
   | `FIREBASE_SERVICE_ACCOUNT_BASE64` | dán chuỗi base64 từ bước 1.2 |
   | `APP_SECRET_KEY` | chuỗi ngẫu nhiên mạnh — **nhớ lại để điền cho chat server** |
   | `EMAIL_USER` / `EMAIL_PASS` | Gmail + App Password gửi OTP |

   **`qlcafe-chat`:**

   | Biến | Giá trị |
   |------|---------|
   | `ChatApi__BaseUrl` | `https://qlcafe-backend.onrender.com/api/` (URL backend + `/api/`, **có `/` cuối**) |
   | `ChatApi__ServerSecret` | đúng bằng `APP_SECRET_KEY` ở trên |

   > Tên miền là `<tên-service>.onrender.com`. Nếu tên `qlcafe-backend` đã có người dùng,
   > Render sẽ thêm hậu tố (vd `qlcafe-backend-x7ab`) — sau khi tạo xong, xem URL thật
   > ở đầu trang service rồi sửa lại `ChatApi__BaseUrl` cho khớp (Environment → Edit).

3. **Apply** → Render tự build + deploy cả hai (backend ~2 phút, chat server build Docker ~5 phút).

### Kiểm tra sau deploy

```bash
# Backend sống?
curl https://qlcafe-backend.onrender.com/health
# → {"status":"ok"}

# Chat server sống? (xem tab Logs của qlcafe-chat, phải thấy dòng:)
# [CLOUD] QLCafe Chat Server (SignalR) — listening on 0.0.0.0:10000, hub: /chathub
```

Muốn chắc chắn chat lưu được tin nhắn: gửi 1 tin trong app rồi xem node `/tin_nhan` trên Firebase Console.

---

## 3. Trỏ client vào server đã deploy

Sửa [`client/GUI/App.config`](../client/GUI/App.config):

```xml
<appSettings>
    <!-- Backend REST -->
    <add key="ApiBaseUrl" value="https://qlcafe-backend.onrender.com/api/"/>
    <!-- Chat: điền URL ĐẦY ĐỦ kèm /chathub (client tự nhận dạng giá trị bắt đầu bằng http) -->
    <add key="ChatServerIP" value="https://qlcafe-chat.onrender.com/chathub"/>
</appSettings>
```

Build lại client (`.\scripts\start-client.ps1`). Xong — client chạy được ở bất kỳ đâu có internet.

> Quay về chạy local/LAN: đổi lại `http://localhost:3000/api/` và `ChatServerIP` = IP LAN như cũ.

---

## 4. Deploy thủ công từng service (nếu không dùng Blueprint)

<details>
<summary>Bấm mở nếu cần tạo tay từng service</summary>

**Backend:** New + → Web Service → chọn repo →
Root Directory `backend` · Runtime `Node` · Build `npm ci --omit=dev` · Start `node server.js` ·
Instance Type **Free** · Health Check Path `/health` → thêm env vars như bảng §2 → Create.

**Chat server:** New + → Web Service → chọn repo →
Root Directory `server/ChatServer` · Runtime `Docker` (tự nhận Dockerfile) ·
Instance Type **Free** → thêm 2 env vars `ChatApi__BaseUrl`, `ChatApi__ServerSecret` → Create.

> ASP.NET Core đọc `ChatApi__BaseUrl` (2 dấu gạch dưới) thành config `ChatApi:BaseUrl` —
> ghi đè giá trị trong `appsettings.json`, không cần sửa code.

</details>

### Chạy thử Dockerfile ở local (tùy chọn — cần Docker Desktop)

Không bắt buộc (Render tự build trên cloud), nhưng hữu ích để kiểm tra trước khi deploy:

```powershell
cd server\ChatServer

# Build image (lần đầu tải base image .NET, ~2-5 phút)
docker build -t qlcafe-chat .

# Chạy container — PORT giả lập môi trường cloud
docker run --rm -p 8080:8080 -e PORT=8080 `
    -e ChatApi__BaseUrl=http://host.docker.internal:3000/api/ `
    -e ChatApi__ServerSecret=<APP_SECRET_KEY trong backend\.env> `
    qlcafe-chat
```

- Log phải hiện: `[CLOUD] QLCafe Chat Server (SignalR) — listening on 0.0.0.0:8080, hub: /chathub`
- `host.docker.internal` = localhost của máy thật (để container gọi được backend đang chạy ngoài Docker).
- Test nhanh hub sống: `curl -X POST "http://localhost:8080/chathub/negotiate?negotiateVersion=1"` → nhận JSON `connectionId` (HTTP 200).
- Client trỏ vào: `ChatServerIP` = `http://localhost:8080/chathub`. Dừng: `Ctrl+C`.

---

## 5. Lưu ý cold start (service free tự ngủ)

- Service free **ngủ sau 15 phút** không có request; request đầu tiên đánh thức mất **~30–60 giây**
  (client có thể báo timeout lần đầu — thử lại là được).
- **Trước khi demo cho cô**: mở `https://qlcafe-backend.onrender.com/health` và đợi chat server
  wake (mở URL bất kỳ của nó) khoảng **2–3 phút trước** — cả hệ chạy mượt suốt buổi demo.
- Muốn không bao giờ ngủ: dùng [UptimeRobot](https://uptimerobot.com) (free) ping `/health`
  mỗi 10 phút. Lưu ý quota free của Render là **750 giờ chạy/tháng cho cả workspace** —
  giữ thức 24/7 cả 2 service sẽ vượt (~1.440h); chỉ nên bật monitor vài ngày quanh lúc nộp/demo.

---

## 6. Phương án khác

| Phương án | Miễn phí? | Ghi chú |
|-----------|-----------|---------|
| **Firebase Cloud Functions** (backend) | Cần gói **Blaze** (nhập thẻ, có quota free lớn) | Đã cấu hình sẵn: [`backend/index.js`](../backend/index.js) + `firebase.json`. Chạy `cd backend && npm run deploy`. URL: `https://asia-southeast1-<project>.cloudfunctions.net/api`. **Không** host được ChatServer (Functions không giữ WebSocket) — chat vẫn cần Render hoặc chạy LAN. |
| **Koyeb** | 1 web service free, không cần thẻ | Chỉ đủ cho 1 trong 2 service; hỗ trợ Docker → hợp với ChatServer nếu Render hết quota. |
| **Railway** | Trial $5 một lần | Hết credit thì dừng — không bền cho đồ án. |
| **Azure for Students** | $100 credit, xác thực email sinh viên (UIT được), không cần thẻ | App Service chạy .NET native — lựa chọn tốt thứ hai cho ChatServer. |

---

## 7. Sự cố thường gặp

| Triệu chứng | Nguyên nhân / cách sửa |
|-------------|------------------------|
| Backend log: `Cannot find module 'serviceAccountKey.json'` | Thiếu/sai `FIREBASE_SERVICE_ACCOUNT_BASE64` (hoặc `NODE_ENV` ≠ `production`). Kiểm tra lại chuỗi base64 — phải là **một dòng liền**, không xuống dòng. |
| Chat gửi được nhưng tin nhắn **không lưu** vào Firebase | `ChatApi__ServerSecret` ≠ `APP_SECRET_KEY` (backend trả 401), hoặc `ChatApi__BaseUrl` sai/thiếu `/api/`. Xem tab Logs của `qlcafe-chat`: có dòng `[ChatHub] Lỗi lưu tin nhắn`. |
| Client báo "Không kết nối được server chat (quá 5 giây)" | Chat server đang ngủ (đợi ~1 phút rồi mở lại màn chat), hoặc `ChatServerIP` thiếu `/chathub` ở cuối. |
| Login lần đầu rất chậm / timeout | Cold start backend — mở `/health` trước. |
| OTP không gửi được email | Render chặn? Không — Gmail SMTP (587) hoạt động bình thường; kiểm tra `EMAIL_PASS` là **App Password** (không phải mật khẩu Gmail). |
| Ảnh upload lỗi `FIREBASE_STORAGE_BUCKET chưa được cấu hình` | Đặt env `FIREBASE_STORAGE_BUCKET=<project-id>.appspot.com` (hoặc `.firebasestorage.app` nếu project mới) rồi redeploy. |
