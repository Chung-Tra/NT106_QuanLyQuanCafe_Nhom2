# start-all.ps1
# Khởi động toàn bộ hệ thống: Backend Express + ChatServer SignalR + Client WinForms
#
# Usage:
#   .\scripts\start-all.ps1                # chạy backend + chatserver (mặc định, không client)
#   .\scripts\start-all.ps1 -WithClient    # chạy cả client luôn
#   .\scripts\start-all.ps1 -BackendOnly   # chỉ chạy backend
#   .\scripts\start-all.ps1 -NoBackend     # bỏ qua backend (chỉ chat + client)

param(
    [switch]$WithClient,
    [switch]$BackendOnly,
    [switch]$NoBackend
)

chcp 65001 > $null
$OutputEncoding = [System.Text.UTF8Encoding]::new()
[Console]::OutputEncoding = [System.Text.UTF8Encoding]::new()

$root = Split-Path $PSScriptRoot -Parent

# Phải chạy từ clone đúng (có thư mục backend + server)
if (-not (Test-Path (Join-Path $root 'backend'))) {
    Write-Host "`n  Lỗi: Không tìm thấy thư mục 'backend' tại: $root" -ForegroundColor Red
    Write-Host "  Mở PowerShell tại thư mục gốc repo rồi chạy: .\scripts\start-all.ps1" -ForegroundColor Yellow
    exit 1
}

Write-Host "========================================" -ForegroundColor Cyan
Write-Host "  QLCafe — Khởi động hệ thống" -ForegroundColor Cyan
Write-Host "========================================" -ForegroundColor Cyan

# ---- Pre-check Backend ----
$missingFiles = @()
if (-not $NoBackend) {
    if (-not (Test-Path "$root\backend\.env")) {
        $missingFiles += "backend\.env (copy từ .env.example)"
    }
    $envContent = if (Test-Path "$root\backend\.env") { Get-Content "$root\backend\.env" -Raw } else { "" }
    $isProd = $envContent -match 'NODE_ENV\s*=\s*production'
    if (-not $isProd -and -not (Test-Path "$root\backend\serviceAccountKey.json")) {
        $missingFiles += "backend\serviceAccountKey.json (tải từ Firebase Console)"
    }
}

if ($missingFiles.Count -gt 0) {
    Write-Host "`n  Thiếu các file cấu hình:" -ForegroundColor Red
    foreach ($f in $missingFiles) {
        Write-Host "    - $f" -ForegroundColor Yellow
    }
    Write-Host "`n  Xem chi tiết trong README.md hoặc docs\setup.md" -ForegroundColor Gray
    exit 1
}

$step = 1
$totalSteps = 0
if (-not $NoBackend)                  { $totalSteps++ }
if (-not $BackendOnly)                { $totalSteps++ }
if ($WithClient -and -not $BackendOnly) { $totalSteps++ }

if ($totalSteps -lt 1) {
    Write-Host "`n  Lỗi: Không có service nào khởi động (xung đột tham số, ví dụ -NoBackend kèm -BackendOnly)." -ForegroundColor Red
    exit 1
}

# ---- 1. Backend Express ----
if (-not $NoBackend) {
    Write-Host "`n[$step/$totalSteps] Khởi động Backend Express (port 3000)..." -ForegroundColor Yellow
    Start-Process powershell -ArgumentList @(
        "-NoExit", "-NoProfile",
        "-Command",
        "[Console]::OutputEncoding=[System.Text.UTF8Encoding]::new(); chcp 65001 > `$null; Set-Location -LiteralPath '$root\backend'; Write-Host '[BACKEND]' -ForegroundColor Cyan; npm run dev"
    )
    Start-Sleep -Seconds 3
    $step++
}

# ---- 2. ChatServer SignalR ----
if (-not $BackendOnly) {
    Write-Host "[$step/$totalSteps] Khởi động ChatServer SignalR..." -ForegroundColor Yellow
    Start-Process powershell -ArgumentList @(
        "-NoExit", "-NoProfile",
        "-Command",
        "[Console]::OutputEncoding=[System.Text.UTF8Encoding]::new(); chcp 65001 > `$null; Set-Location -LiteralPath '$root\server\ChatServer'; Write-Host '[CHATSERVER]' -ForegroundColor Green; dotnet run"
    )
    Start-Sleep -Seconds 2
    $step++
}

# ---- 3. Client WinForms (chỉ khi -WithClient) ----
if ($WithClient -and -not $BackendOnly) {
    Write-Host "[$step/$totalSteps] Build và khởi chạy Client WinForms..." -ForegroundColor Yellow
    Write-Host "  Đợi backend ready (5s)..." -ForegroundColor Gray
    Start-Sleep -Seconds 5

    $clientPath = Join-Path $root 'client\GUI'
    $exePath = Join-Path $clientPath 'bin\Debug\net8.0-windows7.0\GUI.exe'

    # Giết GUI.exe cũ còn chạy ngầm để giải phóng file-lock trước khi build.
    . (Join-Path $PSScriptRoot 'stop-client.ps1')
    $stopped = Stop-GuiClients -ExePath $exePath
    if ($stopped -gt 0) {
        Write-Host "  Đã dừng $stopped GUI.exe đang chạy ngầm." -ForegroundColor DarkYellow
    }

    Push-Location $clientPath

    Write-Host "  Building..." -ForegroundColor Gray
    dotnet build -c Debug -nologo -v quiet
    if ($LASTEXITCODE -ne 0) {
        Write-Host "  Build client thất bại!" -ForegroundColor Red
        Pop-Location
        exit 1
    }

    if (Test-Path $exePath) {
        Start-Process -FilePath $exePath
        Write-Host "  Đã khởi chạy GUI.exe" -ForegroundColor Magenta
    } else {
        Write-Host "  Không tìm thấy GUI.exe!" -ForegroundColor Red
    }
    Pop-Location
}

Write-Host "`n========================================" -ForegroundColor Green
Write-Host "  Hệ thống đã khởi động" -ForegroundColor Green
Write-Host "========================================" -ForegroundColor Green
if (-not $NoBackend)   { Write-Host "  Backend  : http://localhost:3000"          -ForegroundColor White }
if (-not $NoBackend)   { Write-Host "  Health   : http://localhost:3000/health"   -ForegroundColor White }
if (-not $BackendOnly) { Write-Host "  Chat Hub : (xem cửa sổ ChatServer để biết IP)" -ForegroundColor White }
Write-Host "`n  Đóng các cửa sổ PowerShell con để dừng service." -ForegroundColor Gray
Write-Host "  Mẹo: thêm -WithClient để chạy luôn client GUI." -ForegroundColor Gray
