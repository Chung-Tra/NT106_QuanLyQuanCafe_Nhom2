using BUS;
using DTO;
using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Runtime.Versioning;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    [SupportedOSPlatform("windows")]
    public class ChatManager(Control uiControl, ListBox lstChatHistory)
    {
        private HubConnection? _connection;
        public string CurrentRoomId { get; private set; } = "room_global";
        public string CurrentTargetId { get; private set; } = "";
        public string CurrentTargetName { get; private set; } = "";

        /// <summary>
        /// Bắn khi có tin nhắn RIÊNG đến từ một phòng KHÁC phòng đang mở
        /// (senderId, senderName) — để UI đánh dấu "chưa đọc" cho người gửi đó.
        /// </summary>
        public event Action<string, string>? BackgroundPrivateMessage;

        public async Task ConnectToChatServer()
        {
            try
            {
                string savedIP = ConfigurationManager.AppSettings["ChatServerIP"] ?? "localhost";
                string serverUrl = savedIP.StartsWith("http") ? savedIP : $"http://{savedIP}:8080/chathub";

                _connection = new HubConnectionBuilder()
                    .WithUrl(serverUrl)
                    .WithAutomaticReconnect([
                        TimeSpan.Zero,
                        TimeSpan.FromSeconds(2),
                        TimeSpan.FromSeconds(5),
                        TimeSpan.FromSeconds(10)
                    ])
                    .Build();

                // Nhận 4 tham số: senderId, senderName, message, roomId
                _connection.On<string, string, string, string>("ReceiveMessageWithRoom",
                    (senderId, senderName, message, roomId) =>
                {
                    if (uiControl.IsDisposed || !uiControl.IsHandleCreated) return;
                    uiControl.Invoke(new Action(() =>
                    {
                        string myId = GlobalSession.CurrentUser?.EmployeeId ?? "";

                        if (roomId == CurrentRoomId)
                        {
                            string currentTime = DateTime.Now.ToString("dd/MM HH:mm");
                            if (senderId == myId)
                                lstChatHistory.Items.Add($"[{currentTime}] ▶ Tôi: {message}");
                            else
                                lstChatHistory.Items.Add($"[{currentTime}] 👤 {senderName}: {message}");

                            lstChatHistory.Items.Add("");
                            lstChatHistory.TopIndex = lstChatHistory.Items.Count - 1;
                        }
                        // Tin riêng đến từ phòng KHÁC phòng đang mở → báo "chưa đọc" cho người gửi
                        else if (roomId != "room_global" && senderId != myId)
                        {
                            BackgroundPrivateMessage?.Invoke(senderId, senderName);
                        }
                    }));
                });

                // Fix: sau khi mạng bị ngắt rồi reconnect, client phải JoinRoom lại
                // Vì SignalR Groups không được giữ sau khi mất kết nối
                _connection.Reconnected += async _ =>
                {
                    try
                    {
                        await _connection.InvokeAsync("JoinRoom", CurrentRoomId);
                        if (!uiControl.IsDisposed && uiControl.IsHandleCreated)
                            uiControl.Invoke(() => lstChatHistory.Items.Add("[Hệ thống]: Đã kết nối lại."));
                    }
                    catch { /* bỏ qua nếu JoinRoom lỗi khi reconnect */ }
                };

                _connection.Closed += _ =>
                {
                    if (!uiControl.IsDisposed && uiControl.IsHandleCreated)
                        uiControl.Invoke(() => lstChatHistory.Items.Add("[Hệ thống]: Mất kết nối. Đang thử lại..."));
                    return Task.CompletedTask;
                };

                // Giới hạn 5s: nếu IP chat server sai hoặc server không bật, TCP mặc định
                // chờ tới ~21s mới báo lỗi — cắt sớm để màn hình Chat không treo.
                using var timeout = new System.Threading.CancellationTokenSource(TimeSpan.FromSeconds(5));
                await _connection.StartAsync(timeout.Token);

                if (!uiControl.IsDisposed && uiControl.IsHandleCreated)
                    uiControl.Invoke(() => lstChatHistory.Items.Add($"[Hệ thống]: Đã kết nối tới máy chủ ({savedIP})."));
            }
            catch (OperationCanceledException)
            {
                if (!uiControl.IsDisposed && uiControl.IsHandleCreated)
                    uiControl.Invoke(() => lstChatHistory.Items.Add("[Lỗi]: Không kết nối được server chat (quá 5 giây). Kiểm tra ChatServerIP trong App.config."));
            }
            catch (Exception ex)
            {
                if (!uiControl.IsDisposed && uiControl.IsHandleCreated)
                    uiControl.Invoke(() => lstChatHistory.Items.Add($"[Lỗi]: Mất kết nối server chat - {ex.Message}"));
            }
        }

        /// <summary>
        /// Vào sẵn TẤT CẢ phòng riêng của mình (chat_me_X với mọi đồng nghiệp) ngay sau khi
        /// kết nối, để nhận được tin nhắn riêng kể cả khi đang mở thread khác hoặc chưa từng
        /// mở cuộc trò chuyện đó. Groups.AddToGroup idempotent nên gọi lại nhiều lần không sao.
        /// </summary>
        public async Task JoinAllPrivateRoomsAsync(IEnumerable<string> otherEmployeeIds)
        {
            if (_connection == null || _connection.State != HubConnectionState.Connected) return;
            string myId = GlobalSession.CurrentUser?.EmployeeId ?? "";
            if (string.IsNullOrEmpty(myId)) return;

            foreach (var otherId in otherEmployeeIds)
            {
                if (string.IsNullOrEmpty(otherId) || otherId == myId) continue;
                try { await _connection.InvokeAsync("JoinRoom", ChatBUS.GetRoomId(myId, otherId)); }
                catch { /* bỏ qua 1 phòng lỗi, tiếp tục các phòng còn lại */ }
            }
        }

        public async Task SwitchChatRoom(string targetId, string targetName)
        {
            if (GlobalSession.CurrentUser == null) return;

            string myId = GlobalSession.CurrentUser.EmployeeId ?? "";
            string newRoomId = ChatBUS.GetRoomId(myId, targetId);

            CurrentTargetId = targetId ?? "";
            CurrentTargetName = targetName ?? "";

            // KHÔNG rời phòng cũ nữa: ta chủ động ở lại mọi phòng riêng (đã JoinAll lúc kết nối)
            // để luôn nhận được tin nhắn riêng. Chỉ cần đảm bảo đã ở trong phòng mới —
            // Groups.AddToGroup idempotent nên gọi lại không sao.
            if (_connection != null && _connection.State == HubConnectionState.Connected && CurrentRoomId != newRoomId)
            {
                try { await _connection.InvokeAsync("JoinRoom", newRoomId); } catch { }
            }

            CurrentRoomId = newRoomId;

            lstChatHistory.Items.Clear();
            lstChatHistory.Items.Add($"[Hệ thống]: Đang tải lịch sử...");

            try
            {
                var history = await ChatBUS.GetHistory(CurrentRoomId);

                lstChatHistory.BeginUpdate();
                lstChatHistory.Items.Clear();

                foreach (var msg in history)
                {
                    string content = msg.Message ?? "";
                    DateTime msgTime = DateTimeOffset.FromUnixTimeMilliseconds(msg.Timestamp).LocalDateTime;

                    string displayName = msg.SenderName ?? msg.SenderId ?? "?";
                    if (msg.SenderId == myId)
                        lstChatHistory.Items.Add($"[{msgTime:dd/MM HH:mm}] ▶ Tôi: {content}");
                    else
                        lstChatHistory.Items.Add($"[{msgTime:dd/MM HH:mm}] 👤 {displayName}: {content}");

                    lstChatHistory.Items.Add("");
                }

                if (lstChatHistory.Items.Count > 0)
                    lstChatHistory.TopIndex = lstChatHistory.Items.Count - 1;

                lstChatHistory.EndUpdate();
            }
            catch (Exception ex)
            {
                lstChatHistory.Items.Add("[Lỗi]: Không thể tải lịch sử. " + ex.Message);
            }
        }

        public async Task SendMessageAsync(string message)
        {
            if (string.IsNullOrWhiteSpace(message)) return;

            if (_connection != null && _connection.State == HubConnectionState.Connected)
            {
                string myId = GlobalSession.CurrentUser?.EmployeeId ?? "";

                try
                {
                    string myName = GlobalSession.CurrentUser?.FullName ?? myId;
                    await _connection.InvokeAsync("SendMessageWithRoom", myId, myName, message, CurrentRoomId);

                    // Tin RIÊNG (không phải phòng chung) → tạo 1 thông báo cho người nhận để họ
                    // thấy trong mục "Thông báo"/"Tổng quan" dù chưa mở Chat. Best-effort (fire-and-forget).
                    if (CurrentRoomId != "room_global" && !string.IsNullOrEmpty(CurrentTargetId))
                    {
                        string preview = message.Length > 60 ? message[..60] + "…" : message;
                        _ = NotificationBUS.Add(new NotificationDTO
                        {
                            Type = "tin_nhan",
                            Content = $"{myName}: {preview}",
                            ReceiverId = CurrentTargetId,
                            SenderId = myId,
                            Timestamp = DateTimeOffset.Now.ToUnixTimeMilliseconds(),
                            IsRead = false,
                            RelatedPage = "chat"
                        });
                    }
                }
                catch (Exception ex)
                {
                    MsgBox.Show(MsgBox.OwnerWindow(uiControl), "Không thể gửi tin nhắn: " + ex.Message, "Lỗi kết nối", MsgBox.MessageBoxType.Error);
                }
            }
            else
            {
                MsgBox.Show(MsgBox.OwnerWindow(uiControl), "Mất kết nối server! Vui lòng thử lại sau.", "Lỗi mạng", MsgBox.MessageBoxType.Warning);
            }
        }
    }
}
