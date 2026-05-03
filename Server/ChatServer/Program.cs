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

            builder.Services.AddSignalR();
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

            string myIP = "localhost";
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    myIP = ip.ToString();
                    break;
                }
            }

            string serverUrl = $"http://{myIP}:8080";
            app.Urls.Add(serverUrl);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Starting server...");
            Console.WriteLine($"Server started at: {serverUrl}");
            Console.ResetColor();

            app.Run();
        }
    }
}