using System.Net;
using System.Net.Sockets;
using QLCafe.ChatServer.Hubs;

namespace QLCafe.ChatServer
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Cấu hình SignalR: tăng giới hạn tin nhắn và giữ kết nối ổn định
            // HttpClient để ChatHub gọi Express backend lưu tin nhắn
            builder.Services.AddHttpClient("ChatApi", client =>
            {
                string baseUrl = builder.Configuration["ChatApi:BaseUrl"] ?? "http://localhost:3000/api/";
                string secret  = builder.Configuration["ChatApi:ServerSecret"] ?? "";
                client.BaseAddress = new Uri(baseUrl);
                client.DefaultRequestHeaders.Add("X-Server-Secret", secret);
            });

            builder.Services.AddSignalR(options =>
            {
                options.EnableDetailedErrors = true;
                options.KeepAliveInterval = TimeSpan.FromSeconds(15);
                options.ClientTimeoutInterval = TimeSpan.FromSeconds(60);
                options.MaximumReceiveMessageSize = 64 * 1024; // 64KB
            });

            // Cho phép mọi origin kết nối (client WinForms không có origin cố định)
            builder.Services.AddCors(options =>
            {
                options.AddDefaultPolicy(policy =>
                {
                    policy.AllowAnyHeader()
                          .AllowAnyMethod()
                          .SetIsOriginAllowed(_ => true)
                          .AllowCredentials();
                });
            });

            var app = builder.Build();

            app.UseCors();
            app.MapHub<ChatHub>("/chathub");

            // Lấy IP máy trong mạng LAN để client khác kết nối được
            string serverIp = GetLocalIpAddress();
            int port = 8080;
            string serverUrl = $"http://{serverIp}:{port}";
            app.Urls.Add(serverUrl);
            app.Urls.Add($"http://localhost:{port}"); // fallback cho máy chạy server

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("╔═══════════════════════════════════════╗");
            Console.WriteLine("║    QLCafe — Chat Server (SignalR)     ║");
            Console.WriteLine("╚═══════════════════════════════════════╝");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"  Hub endpoint : {serverUrl}/chathub");
            Console.WriteLine($"  Local fallback: http://localhost:{port}/chathub");
            Console.ResetColor();
            Console.WriteLine("\nĐiền IP sau vào App.config của client:");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"  <add key=\"ChatServerIP\" value=\"{serverIp}\"/>");
            Console.ResetColor();
            Console.WriteLine("\nNhấn Ctrl+C để dừng.\n");

            app.Run();
        }

        private static string GetLocalIpAddress()
        {
            try
            {
                var host = Dns.GetHostEntry(Dns.GetHostName());
                foreach (var ip in host.AddressList)
                {
                    if (ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                        return ip.ToString();
                }
            }
            catch { }
            return "localhost";
        }
    }
}