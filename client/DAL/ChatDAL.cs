using DTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace DAL
{
    public static class ChatDAL
    {
        public static async Task<List<ChatMessageDTO>> GetHistoryAsync(string roomId)
        {
            try
            {
                var response = await DalHelper.Client.SendAsync(
                    DalHelper.Build(HttpMethod.Get, $"chat/messages?roomId={Uri.EscapeDataString(roomId)}"));
                if (!response.IsSuccessStatusCode) return [];

                var json = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<ChatMessageDTO>>(json) ?? [];
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi tải lịch sử chat: " + ex.Message);
            }
        }

        public static async Task SaveMessageAsync(string roomId, ChatMessageDTO msg)
        {
            try
            {
                var response = await DalHelper.Client.SendAsync(
                    DalHelper.Build(HttpMethod.Post, "chat/messages", new { roomId, chatData = msg }));
                response.EnsureSuccessStatusCode();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi lưu tin nhắn: " + ex.Message);
            }
        }
    }
}
