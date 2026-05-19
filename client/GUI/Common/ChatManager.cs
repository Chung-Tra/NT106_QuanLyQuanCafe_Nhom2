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

        // --- HÀM 1: KẾT NỐI SERVER ---
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
                    if (!uiControl.IsDisposed && uiControl.IsHandleCreated)
                    {
                        uiControl.Invoke(new Action(() =>
                        {
                            if (roomId == CurrentRoomId)
                            {
                                string currentTime = DateTime.Now.ToString("dd/MM HH:mm");
                                string myId = GlobalSession.CurrentUser?.EmployeeId ?? "";

                                if (senderId == myId)
                                    lstChatHistory.Items.Add($"[{currentTime}] ▶ Tôi: {message}");
                                else
                                    lstChatHistory.Items.Add($"[{currentTime}] 👤 {senderName}: {message}");

                                lstChatHistory.Items.Add("");
                                lstChatHistory.TopIndex = lstChatHistory.Items.Count - 1;
                            }
                        }));
                    }
                });

                // FIX: sau khi mạng bị ngắt rồi reconnect, client phải JoinRoom lại
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

                await _connection.StartAsync();

                if (!uiControl.IsDisposed && uiControl.IsHandleCreated)
                    uiControl.Invoke(() => lstChatHistory.Items.Add($"[Hệ thống]: Đã kết nối tới máy chủ ({savedIP})."));
            }
            catch (Exception ex)
            {
                if (!uiControl.IsDisposed && uiControl.IsHandleCreated)
                    uiControl.Invoke(() => lstChatHistory.Items.Add($"[Lỗi]: Mất kết nối server chat - {ex.Message}"));
            }
        }

        // --- HÀM 2: CHUYỂN PHÒNG & TẢI LỊCH SỬ ---
        public async Task SwitchChatRoom(string targetId, string targetName)
        {
            if (GlobalSession.CurrentUser == null) return;

            string myId = GlobalSession.CurrentUser.EmployeeId ?? "";
            string newRoomId = ChatBUS.GetRoomId(myId, targetId);

            // Rời room cũ, join room mới trên SignalR server
            if (_connection != null && _connection.State == HubConnectionState.Connected)
            {
                if (CurrentRoomId != newRoomId)
                {
                    await _connection.InvokeAsync("LeaveRoom", CurrentRoomId);
                    await _connection.InvokeAsync("JoinRoom", newRoomId);
                }
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

        // --- HÀM 3: GỬI TIN NHẮN ---
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
