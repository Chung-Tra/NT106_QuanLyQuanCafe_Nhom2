# start-backend.ps1
# Khởi động Backend Express với kiểm tra tiên quyết

# Bật UTF-8 cho tiếng Việt trên Windows PowerShell 5.1
chcp 65001 > $null
$OutputEncoding = [System.Text.UTF8Encoding]::new()
[Console]::OutputEncoding = [System.Text.UTF8Encoding]::new()

$root = Split-Path $PSScriptRoot -Parent
$backendPath = Join-Path $root 'backend'

Write-Host "[BACKEND] Kiểm tra cấu hình..." -ForegroundColor Cyan

# 1. Kiểm tra .env
if (-not (Test-Path "$backendPath\.env")) {
    Write-Host ""
    Write-Host "  Thiếu file: backend\.env" -ForegroundColor Red
    Write-Host "  Sửa: Copy-Item backend\.env.example backend\.env" -ForegroundColor Yellow
    Write-Host "  Sau đó mở backend\.env và điền thông tin Firebase + Email." -ForegroundColor Yellow
    exit 1
}

# 2. Kiểm tra serviceAccountKey.json (chỉ bắt buộc khi NODE_ENV != production)
$envContent = Get-Content "$backendPath\.env" -Raw
$isProd = $envContent -match 'NODE_ENV\s*=\s*production'

if (-not $isProd -and -not (Test-Path "$backendPath\serviceAccountKey.json")) {
    Write-Host ""
    Write-Host "  Thiếu file: backend\serviceAccountKey.json" -ForegroundColor Red
    Write-Host "  Cách lấy:" -ForegroundColor Yellow
    Write-Host "    1. Vào Firebase Console -> Project Settings -> Service accounts" -ForegroundColor Yellow
    Write-Host "    2. Bấm 'Generate new private key' -> tải file JSON" -ForegroundColor Yellow
    Write-Host "    3. Đổi tên thành 'serviceAccountKey.json' và đặt vào thư mục backend\" -ForegroundColor Yellow
    Write-Host ""
    Write-Host "  (Hoặc chạy production mode: trong .env đặt NODE_ENV=production)" -ForegroundColor Gray
    exit 1
}

# 3. Kiểm tra node_modules
if (-not (Test-Path "$backendPath\node_modules")) {
    Write-Host "  Chưa có node_modules. Đang cài đặt..." -ForegroundColor Yellow
    Set-Location $backendPath
    npm install
    if ($LASTEXITCODE -ne 0) {
        Write-Host "  npm install thất bại!" -ForegroundColor Red
        exit 1
    }
}

Write-Host "[BACKEND] Khởi động Express server (port 3000)..." -ForegroundColor Cyan
Set-Location $backendPath
npm run dev
