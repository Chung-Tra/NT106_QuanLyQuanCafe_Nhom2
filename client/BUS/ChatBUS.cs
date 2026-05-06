using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class ChatBUS
    {
        public static async Task SaveMessage(string roomId, ChatMessageDTO msg)
        {
            await ChatDAL.SaveMessageAsync(roomId, msg);
        }

        public static async Task<List<ChatMessageDTO>> GetHistory(string roomId)
        {
            return await ChatDAL.GetHistoryAsync(roomId);
        }

        public static string GetRoomId(string id1, string id2)
        {
            // Nếu chat chung thì vào phòng global
            if (string.IsNullOrEmpty(id2) || id2 == "Everyone")
            {
                return "room_global";
            }

            // Sắp xếp ID để đảm bảo: dù là (NV01, NV02) hay (NV02, NV01) 
            // thì kết quả trả về luôn là "chat_NV01_NV02"
            List<string> ids = [id1, id2];
            ids.Sort();

            return $"chat_{ids[0]}_{ids[1]}";
        }
    }
}
