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
        /// <param name="senderName">Tên hiển thị của người gửi (client tự truyền lên).</param>
        public async Task SendMessageWithRoom(string senderId, string senderName, string message, string roomId)
        {
            Console.WriteLine($"[{DateTime.Now:HH:mm:ss}] [{roomId}] {senderName} ({senderId}): {message}");

            // 1. Broadcast kèm tên người gửi để client hiển thị luôn
            await Clients.Group(roomId).SendAsync("ReceiveMessageWithRoom", senderId, senderName, message, roomId);

            // 2. Lưu vào database (fire-and-forget)
            _ = SaveMessageAsync(roomId, senderId, senderName, message);
        }

        private async Task SaveMessageAsync(string roomId, string senderId, string senderName, string message)
        {
            try
            {
                var payload = new
                {
                    roomId,
                    chatData = new
                    {
                        nguoi_gui_id  = senderId,
                        ten_nguoi_gui = senderName,
                        noi_dung      = message,
                        thoi_gian     = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds(),
                        loai_tin_nhan = "text"
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
