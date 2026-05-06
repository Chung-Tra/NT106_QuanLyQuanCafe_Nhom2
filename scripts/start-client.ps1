# start-client.ps1
# Build và chạy WinForms Client (GUI.exe)

chcp 65001 > $null
$OutputEncoding = [System.Text.UTF8Encoding]::new()
[Console]::OutputEncoding = [System.Text.UTF8Encoding]::new()

$root = Split-Path $PSScriptRoot -Parent
$clientPath = Join-Path $root 'client\GUI'

if (-not (Test-Path $clientPath)) {
    Write-Host "  Không tìm thấy thư mục: $clientPath" -ForegroundColor Red
    exit 1
}

Write-Host "[CLIENT] Build dự án WinForms..." -ForegroundColor Magenta
Set-Location $clientPath
dotnet build -c Debug -nologo -v minimal

if ($LASTEXITCODE -ne 0) {
    Write-Host "  Build thất bại!" -ForegroundColor Red
    exit 1
}

Write-Host "[CLIENT] Khởi chạy GUI.exe..." -ForegroundColor Magenta

$exePath = Join-Path $clientPath 'bin\Debug\net8.0-windows7.0\GUI.exe'
if (Test-Path $exePath) {
    Start-Process -FilePath $exePath
    Write-Host "  Đã khởi chạy client. Cửa sổ đăng nhập sẽ hiện ra." -ForegroundColor Green
} else {
    Write-Host "  Không tìm thấy GUI.exe ở: $exePath" -ForegroundColor Red
    Write-Host "  Đang fallback sang 'dotnet run'..." -ForegroundColor Yellow
    dotnet run --no-build
}
