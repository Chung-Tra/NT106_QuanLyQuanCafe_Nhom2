using Microsoft.AspNetCore.SignalR;

namespace QLCafe.ChatServer.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(string senderName, string message)
        {
            Console.WriteLine($"[{DateTime.Now:HH:mm:ss}] {senderName}: {message}");
            await Clients.All.SendAsync("ReceiveMessage", senderName, message);
        }

        public async Task SendMessageWithRoom(string senderName, string message, string roomId)
        {
            Console.WriteLine($"[{DateTime.Now:HH:mm:ss}] [Room: {roomId}] {senderName}: {message}");
            await Clients.All.SendAsync("ReceiveMessageWithRoom", senderName, message, roomId);
        }

        public override Task OnConnectedAsync()
        {
            Console.WriteLine($"Client connected: {Context.ConnectionId}");
            return base.OnConnectedAsync();
        }
    }
}
