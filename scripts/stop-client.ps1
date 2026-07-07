# stop-client.ps1
# Dừng (giết) mọi tiến trình GUI.exe (client WinForms) đang chạy ngầm.
# Chạy trước khi build để giải phóng file-lock trên GUI.exe (tránh lỗi MSB3021/MSB3027
# "cannot access GUI.exe because it is being used by another process"), hoặc chạy độc
# lập để dọn sạch các cửa sổ client còn sót.
#
# Usage:
#   .\scripts\stop-client.ps1            # giết tất cả GUI.exe đang chạy
#   . .\scripts\stop-client.ps1          # dot-source để dùng hàm Stop-GuiClients trong script khác

function Stop-GuiClients {
    <#
      Giết tiến trình GUI.exe. Nếu truyền -ExePath thì chỉ giết đúng tiến trình chạy từ
      đường dẫn đó (không đụng app khác tình cờ tên "GUI"); không truyền thì giết tất cả.
      Trả về số tiến trình đã dừng.
    #>
    param([string]$ExePath)

    $procs = @(Get-Process -Name 'GUI' -ErrorAction SilentlyContinue)
    if ($procs.Count -eq 0) { return 0 }

    if ($ExePath) {
        $matched = @(foreach ($p in $procs) {
            try { if ($p.Path -eq $ExePath) { $p } } catch { }
        })
        # Chỉ thu hẹp khi thực sự khớp được đường dẫn; nếu không đọc được Path thì giữ nguyên list.
        if ($matched.Count -gt 0) { $procs = $matched }
    }

    $count = $procs.Count
    $procs | Stop-Process -Force -ErrorAction SilentlyContinue
    # Đợi OS thả file-lock trên GUI.exe trước khi build ghi đè.
    Start-Sleep -Milliseconds 400
    return $count
}

# Chỉ tự thực thi khi chạy TRỰC TIẾP (dot-source thì $MyInvocation.InvocationName = '.').
if ($MyInvocation.InvocationName -ne '.') {
    chcp 65001 > $null
    $OutputEncoding = [System.Text.UTF8Encoding]::new()
    [Console]::OutputEncoding = [System.Text.UTF8Encoding]::new()

    $stopped = Stop-GuiClients
    if ($stopped -gt 0) {
        Write-Host "  Đã dừng $stopped tiến trình GUI.exe." -ForegroundColor Green
    } else {
        Write-Host "  Không có GUI.exe nào đang chạy." -ForegroundColor Gray
    }
}
