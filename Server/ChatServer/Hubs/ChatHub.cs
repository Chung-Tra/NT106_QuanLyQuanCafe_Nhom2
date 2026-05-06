using Microsoft.AspNetCore.SignalR;
using System.Text;
using System.Text.Json;

namespace QLCafe.ChatServer.Hubs
{
    public class ChatHub(IHttpClientFactory httpClientFactory) : Hub
    {
        private readonly HttpClient _api = httpClientFactory.CreateClient("ChatApi");

        /// <summary>Client gọi khi muốn tham gia một room.</summary>
        public async Task JoinRoom(string roomId)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, roomId);
            Console.WriteLine($"[{DateTime.Now:HH:mm:ss}] {Context.ConnectionId} joined room: {roomId}");
        }

        /// <summary>Client gọi khi rời một room.</summary>
        public async Task LeaveRoom(string roomId)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, roomId);
            Console.WriteLine($"[{DateTime.Now:HH:mm:ss}] {Context.ConnectionId} left room: {roomId}");
        }

        /// <summary>
        /// Nhận tin nhắn → broadcast tới room → server tự lưu xuống database.
        /// Client KHÔNG cần gọi API lưu riêng.
        /// </summary>
        public async Task SendMessageWithRoom(string senderId, string message, string roomId)
        {
            Console.WriteLine($"[{DateTime.Now:HH:mm:ss}] [{roomId}] {senderId}: {message}");

            // 1. Broadcast tới tất cả client trong room
            await Clients.Group(roomId).SendAsync("ReceiveMessageWithRoom", senderId, message, roomId);

            // 2. Lưu vào database qua Express backend (fire-and-forget ở server)
            _ = SaveMessageAsync(roomId, senderId, message);
        }

        private async Task SaveMessageAsync(string roomId, string senderId, string message)
        {
            try
            {
                var payload = new
                {
                    roomId,
                    chatData = new
                    {
                        senderId,
                        message,
                        timestamp = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds()
                    }
                };

                var content = new StringContent(
                    JsonSerializer.Serialize(payload),
                    Encoding.UTF8,
                    "application/json");

                var response = await _api.PostAsync("chat/messages", content);
                if (!response.IsSuccessStatusCode)
                {
                    string err = await response.Content.ReadAsStringAsync();
                    Console.WriteLine($"[{DateTime.Now:HH:mm:ss}] [ChatHub] Lỗi lưu tin nhắn: {err}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[{DateTime.Now:HH:mm:ss}] [ChatHub] Exception lưu tin nhắn: {ex.Message}");
            }
        }

        public override async Task OnConnectedAsync()
        {
            Console.WriteLine($"[{DateTime.Now:HH:mm:ss}] Connected: {Context.ConnectionId}");
            await Groups.AddToGroupAsync(Context.ConnectionId, "room_global");
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            Console.WriteLine($"[{DateTime.Now:HH:mm:ss}] Disconnected: {Context.ConnectionId}" +
                (exception != null ? $" | Lý do: {exception.Message}" : ""));
            await base.OnDisconnectedAsync(exception);
        }
    }
}
