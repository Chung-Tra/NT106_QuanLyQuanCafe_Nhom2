using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Threading.Tasks;

namespace Services
{
    /// <summary>
    /// Quản lý kết nối SignalR thuần túy — không phụ thuộc vào GUI.
    /// ChatManager trong GUI/Common sử dụng service này.
    /// </summary>
    public class ChatSignalRService : IAsyncDisposable
    {
        private HubConnection? _connection;
        private string _currentRoomId = "room_global";

        public HubConnectionState State => _connection?.State ?? HubConnectionState.Disconnected;
        public string CurrentRoomId => _currentRoomId;

        /// <summary>Sự kiện được raised khi nhận tin nhắn từ server.</summary>
        public event Action<string, string, string>? OnMessageReceived;

        /// <summary>Sự kiện được raised khi trạng thái kết nối thay đổi.</summary>
        public event Action<string>? OnStatusChanged;

        public async Task ConnectAsync(string serverIp)
        {
            if (_connection != null && _connection.State != HubConnectionState.Disconnected)
                return;

            string url = serverIp.StartsWith("http")
                ? serverIp
                : $"http://{serverIp}:8080/chathub";

            _connection = new HubConnectionBuilder()
                .WithUrl(url)
                .WithAutomaticReconnect(new[] { TimeSpan.Zero, TimeSpan.FromSeconds(2), TimeSpan.FromSeconds(5), TimeSpan.FromSeconds(10) })
                .Build();

            // Nhận tin nhắn theo room
            _connection.On<string, string, string>("ReceiveMessageWithRoom",
                (senderId, message, roomId) => OnMessageReceived?.Invoke(senderId, message, roomId));

            _connection.Reconnecting += _ =>
            {
                OnStatusChanged?.Invoke("Đang kết nối lại...");
                return Task.CompletedTask;
            };

            _connection.Reconnected += _ =>
            {
                OnStatusChanged?.Invoke("Đã kết nối lại.");
                // Rejoin room hiện tại sau khi reconnect
                return _connection.InvokeAsync("JoinRoom", _currentRoomId);
            };

            _connection.Closed += _ =>
            {
                OnStatusChanged?.Invoke("Mất kết nối với máy chủ.");
                return Task.CompletedTask;
            };

            await _connection.StartAsync();
            OnStatusChanged?.Invoke($"Đã kết nối tới {url}");
        }

        public async Task JoinRoomAsync(string roomId)
        {
            if (_connection?.State != HubConnectionState.Connected) return;

            if (_currentRoomId != roomId)
            {
                await _connection.InvokeAsync("LeaveRoom", _currentRoomId);
                await _connection.InvokeAsync("JoinRoom", roomId);
                _currentRoomId = roomId;
            }
        }

        public async Task SendMessageAsync(string senderId, string message, string roomId)
        {
            if (_connection?.State != HubConnectionState.Connected)
                throw new InvalidOperationException("Không có kết nối tới máy chủ chat.");

            await _connection.InvokeAsync("SendMessageWithRoom", senderId, message, roomId);
        }

        public async ValueTask DisposeAsync()
        {
            if (_connection != null)
                await _connection.DisposeAsync();
        }
    }
}
