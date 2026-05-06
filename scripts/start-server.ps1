# start-server.ps1
# Khởi động ChatServer SignalR

chcp 65001 > $null
$OutputEncoding = [System.Text.UTF8Encoding]::new()
[Console]::OutputEncoding = [System.Text.UTF8Encoding]::new()

$root = Split-Path $PSScriptRoot -Parent
$serverPath = Join-Path $root 'server\ChatServer'

if (-not (Test-Path $serverPath)) {
    Write-Host "  Không tìm thấy thư mục: $serverPath" -ForegroundColor Red
    exit 1
}

Write-Host "[CHATSERVER] Khởi động SignalR server..." -ForegroundColor Green
Set-Location $serverPath
dotnet run
