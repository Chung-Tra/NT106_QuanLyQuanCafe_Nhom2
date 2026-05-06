# start-multi-client.ps1
# Khởi chạy nhiều instance GUI.exe để test đa user (chat, đồng thời...)
#
# Usage:
#   .\scripts\start-multi-client.ps1            # mặc định 3 client
#   .\scripts\start-multi-client.ps1 -Count 2   # 2 client
#   .\scripts\start-multi-client.ps1 -Count 5   # 5 client (test stress)

param(
    [int]$Count = 3,
    [int]$DelayMs = 500
)

chcp 65001 > $null
$OutputEncoding = [System.Text.UTF8Encoding]::new()
[Console]::OutputEncoding = [System.Text.UTF8Encoding]::new()

if ($Count -lt 1 -or $Count -gt 10) {
    Write-Host "  Số lượng client phải từ 1 đến 10." -ForegroundColor Red
    exit 1
}

$root = Split-Path $PSScriptRoot -Parent
$clientPath = Join-Path $root 'client\GUI'
$exePath = Join-Path $clientPath 'bin\Debug\net8.0-windows7.0\GUI.exe'

Write-Host "========================================" -ForegroundColor Cyan
Write-Host "  Multi-Client Launcher (x$Count)" -ForegroundColor Cyan
Write-Host "========================================" -ForegroundColor Cyan

# Build nếu chưa có exe
if (-not (Test-Path $exePath)) {
    Write-Host "[BUILD] Chưa có GUI.exe — đang build..." -ForegroundColor Yellow
    Push-Location $clientPath
    dotnet build -c Debug -nologo -v quiet
    if ($LASTEXITCODE -ne 0) {
        Write-Host "  Build thất bại!" -ForegroundColor Red
        Pop-Location
        exit 1
    }
    Pop-Location
}

# Launch nhiều instance
$pids = @()
for ($i = 1; $i -le $Count; $i++) {
    Write-Host "[$i/$Count] Khởi chạy client #$i..." -ForegroundColor Magenta
    $proc = Start-Process -FilePath $exePath -PassThru
    $pids += $proc.Id
    Start-Sleep -Milliseconds $DelayMs
}

Write-Host "`nĐã khởi chạy $Count client." -ForegroundColor Green
Write-Host "PID: $($pids -join ', ')" -ForegroundColor Gray
Write-Host "`nĐể đóng tất cả: Stop-Process -Id $($pids -join ',')" -ForegroundColor Gray
Write-Host "Hoặc:           Get-Process GUI | Stop-Process" -ForegroundColor Gray
