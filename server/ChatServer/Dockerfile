# QLCafe Chat Server (ASP.NET Core SignalR, .NET 8)
# Build context: server/ChatServer

# ---- Build ----
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ChatServer.csproj .
RUN dotnet restore ChatServer.csproj
COPY . .
RUN dotnet publish ChatServer.csproj -c Release -o /app/publish /p:UseAppHost=false

# ---- Runtime ----
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .
# Hosting (Render/Railway) cấp biến PORT lúc chạy; Program.cs tự bind 0.0.0.0:$PORT
ENTRYPOINT ["dotnet", "ChatServer.dll"]
