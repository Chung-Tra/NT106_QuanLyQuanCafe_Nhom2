# setup.ps1
# Cài đặt toàn bộ dependencies lần đầu cho tất cả project

chcp 65001 > $null
$OutputEncoding = [System.Text.UTF8Encoding]::new()
[Console]::OutputEncoding = [System.Text.UTF8Encoding]::new()

$root = Split-Path $PSScriptRoot -Parent

Write-Host "========================================" -ForegroundColor Cyan
Write-Host "  QLCafe — Cài đặt dependencies" -ForegroundColor Cyan
Write-Host "========================================`n" -ForegroundColor Cyan

# 1. Kiểm tra Node.js
Write-Host "[1/5] Kiểm tra Node.js..." -ForegroundColor Yellow
if (-not (Get-Command node -ErrorAction SilentlyContinue)) {
    Write-Host "  Node.js chưa được cài. Tải tại: https://nodejs.org" -ForegroundColor Red
    exit 1
}
Write-Host "  Node.js $(node -v) - OK" -ForegroundColor Green

# 2. Kiểm tra .NET SDK
Write-Host "[2/5] Kiểm tra .NET SDK..." -ForegroundColor Yellow
if (-not (Get-Command dotnet -ErrorAction SilentlyContinue)) {
    Write-Host "  .NET SDK chưa được cài. Tải tại: https://dotnet.microsoft.com/download" -ForegroundColor Red
    exit 1
}
Write-Host "  .NET $(dotnet --version) - OK" -ForegroundColor Green

# 3. Cài npm packages cho backend
Write-Host "[3/5] Cài dependencies cho backend..." -ForegroundColor Yellow
Set-Location "$root\backend"
npm install
if ($LASTEXITCODE -ne 0) { Write-Host "  npm install thất bại!" -ForegroundColor Red; exit 1 }
Write-Host "  Backend dependencies - OK" -ForegroundColor Green

# 4. Tải font Lora cho client UI
Write-Host "[4/5] Tải font Lora..." -ForegroundColor Yellow
$fontsDir = "$root\client\GUI\Resources\Fonts"
if (-not (Test-Path $fontsDir)) { New-Item -ItemType Directory -Path $fontsDir -Force | Out-Null }

# PowerShell 5.1 mặc định TLS 1.0 - GitHub yêu cầu TLS 1.2+
[Net.ServicePointManager]::SecurityProtocol = [Net.ServicePointManager]::SecurityProtocol -bor [Net.SecurityProtocolType]::Tls12

$loraBase = "https://raw.githubusercontent.com/google/fonts/main/ofl/lora"
# Lora là variable font: 1 file chứa nhiều weight
$loraFiles = @(
    @{ Remote = "Lora[wght].ttf";        Local = "Lora.ttf" },
    @{ Remote = "Lora-Italic[wght].ttf"; Local = "Lora-Italic.ttf" }
)

foreach ($item in $loraFiles) {
    $dest = Join-Path $fontsDir $item.Local
    if (Test-Path -LiteralPath $dest) {
        Write-Host "  $($item.Local) - đã có" -ForegroundColor Gray
        continue
    }
    try {
        $url = "$loraBase/$([uri]::EscapeDataString($item.Remote))"
        Invoke-WebRequest -Uri $url -OutFile $dest -UseBasicParsing -ErrorAction Stop
        Write-Host "  $($item.Local) - OK" -ForegroundColor Green
    } catch {
        Write-Host "  $($item.Local) - lỗi tải, bỏ qua (font fallback Segoe UI)" -ForegroundColor DarkYellow
    }
}

# 5. Restore .NET packages
Write-Host "[5/5] Restore .NET packages..." -ForegroundColor Yellow
Set-Location "$root"
dotnet restore "client\Coffee_Management.sln"
dotnet restore "server\Server.sln"
Write-Host "  .NET packages - OK" -ForegroundColor Green

# Kiểm tra .env
Write-Host "`n----------------------------------------" -ForegroundColor Gray
if (-not (Test-Path "$root\backend\.env")) {
    Write-Host "  Chưa có file .env! Chạy lệnh sau để tạo:" -ForegroundColor Red
    Write-Host "  cp backend\.env.example backend\.env" -ForegroundColor White
    Write-Host "  Sau đó điền thông tin Firebase vào backend\.env" -ForegroundColor White
} else {
    Write-Host "  File .env đã tồn tại - OK" -ForegroundColor Green
}

Write-Host "`nSetup hoàn tất! Chạy .\scripts\start-all.ps1 để khởi động." -ForegroundColor Cyan
