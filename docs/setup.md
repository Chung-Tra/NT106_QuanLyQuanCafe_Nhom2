# Hướng dẫn cài đặt môi trường phát triển

## Yêu cầu hệ thống


| Phần mềm      | Phiên bản tối thiểu | Link tải                                                                       |
| ------------- | ------------------- | ------------------------------------------------------------------------------ |
| Node.js       | 18+                 | [https://nodejs.org](https://nodejs.org)                                       |
| .NET SDK      | 8.0                 | [https://dotnet.microsoft.com/download](https://dotnet.microsoft.com/download) |
| Visual Studio | 2022                | [https://visualstudio.microsoft.com](https://visualstudio.microsoft.com)       |
| Git           | Bất kỳ              | [https://git-scm.com](https://git-scm.com)                                     |


---

## Bước 1: Clone repo

```bash
git clone https://github.com/<org>/NT106_QuanLyQuanCafe_Nhom2.git
cd NT106_QuanLyQuanCafe_Nhom2
```

---

## Bước 2: Cài dependencies

```powershell
.\scripts\setup.ps1
```

Script tự động:

- Kiểm tra Node.js và .NET SDK
- Chạy `npm install` cho backend
- Chạy `dotnet restore` cho client và server

---

## Bước 3: Cấu hình Firebase

### 3.1 Tạo project Firebase

1. Vào [Firebase Console](https://console.firebase.google.com)
2. Tạo project mới hoặc chọn project có sẵn
3. Bật **Realtime Database** (chế độ test mode khi dev)
4. Bật **Authentication** → Email/Password

### 3.2 Lấy Web API Key

Firebase Console → Project Settings → General → Web API Key

### 3.3 Tạo Service Account (cho backend local)

Firebase Console → Project Settings → Service Accounts → Generate new private key  
→ Lưu file JSON vào `backend/serviceAccountKey.json`

> File này đã được gitignore, không bao giờ commit lên repo.

### 3.4 Tạo file `.env`

```powershell
cp backend\.env.example backend\.env
```

Mở `backend/.env` và điền:

```env
PORT=3000
FIREBASE_DATABASE_URL=https://<project-id>-default-rtdb.firebaseio.com
FIREBASE_API_KEY=<web-api-key>
APP_SECRET_KEY=<tự đặt chuỗi ngẫu nhiên mạnh>
EMAIL_USER=<gmail của bạn>
EMAIL_PASS=<gmail app password>
NODE_ENV=development
```

### 3.5 Gmail App Password

1. Bật 2-Factor Authentication cho Gmail
2. Google Account → Security → App Passwords
3. Tạo App Password cho "Mail" → "Windows Computer"
4. Dán vào `EMAIL_PASS`

---

## Bước 4: Chạy ứng dụng

### Chạy tất cả (Backend + ChatServer + Client) — khuyến nghị

```powershell
.\scripts\start-all.ps1 -WithClient
```

### Chỉ Backend + ChatServer (mặc định)

```powershell
.\scripts\start-all.ps1
```

### Tùy chọn khác

```powershell
.\scripts\start-all.ps1 -BackendOnly   # chỉ backend
.\scripts\start-all.ps1 -NoBackend     # chỉ chat + (client nếu -WithClient)
```

### Chạy riêng từng service


| Lệnh                          | Tác dụng                              |
| ----------------------------- | ------------------------------------- |
| `.\scripts\start-backend.ps1` | Backend Express (port 3000)           |
| `.\scripts\start-server.ps1`  | ChatServer SignalR                    |
| `.\scripts\start-client.ps1`  | Client WinForms (build + run GUI.exe) |


### Mở trong Visual Studio (debug)

Mở `client\Coffee_Management.sln` → F5

---

## Bước 5: Kiểm tra

```bash
# Kiểm tra backend
curl http://localhost:3000/health
# Kết quả: {"status":"ok"}

# Test đăng nhập
curl -X POST http://localhost:3000/api/auth/login \
  -H "Content-Type: application/json" \
  -d "{\"email\":\"test@cafe.com\",\"password\":\"123456\"}"
```

---

## Deploy lên Firebase

### Cài Firebase CLI

```bash
npm install -g firebase-tools
firebase login
```

### Deploy

```bash
firebase deploy --only functions
```

URL sau deploy: `https://asia-southeast1-<project>.cloudfunctions.net/api`

---

## Cấu trúc biến môi trường


| Biến                    | Bắt buộc | Mô tả                            |
| ----------------------- | -------- | -------------------------------- |
| `PORT`                  | Không    | Port local (default: 3000)       |
| `FIREBASE_DATABASE_URL` | Có       | URL Realtime Database            |
| `FIREBASE_API_KEY`      | Có       | Web API Key cho signIn           |
| `APP_SECRET_KEY`        | Có       | Key bảo vệ endpoint đổi mật khẩu |
| `EMAIL_USER`            | Có       | Gmail gửi OTP                    |
| `EMAIL_PASS`            | Có       | Gmail App Password               |
| `NODE_ENV`              | Không    | `development` / `production`     |


---

## Troubleshooting

**Lỗi: `Cannot find module 'serviceAccountKey.json'`**  
→ Chưa tạo file `backend/serviceAccountKey.json`. Xem Bước 3.3.

**Lỗi: `Firebase: Error (auth/invalid-api-key)`**  
→ `FIREBASE_API_KEY` trong `.env` chưa đúng. Kiểm tra lại Web API Key.

**Lỗi: `Error: Missing credentials`**  
→ `FIREBASE_DATABASE_URL` để trống. Điền đầy đủ vào `.env`.

**Lỗi CORS khi client gọi API**  
→ Backend đã cấu hình `cors()` mặc định, kiểm tra URL trong client có đúng port 3000 không.

**Port 3000 đã bị dùng**  
→ Đổi `PORT=3001` trong `backend/.env`.