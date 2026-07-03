using DAL;
using System.Threading.Tasks;

namespace BUS
{
    /// <summary>Nghiệp vụ tải ảnh lên Firebase Storage.</summary>
    public static class UploadBUS
    {
        /// <param name="folder">"mon_uong" cho ảnh món, "avatar" cho ảnh nhân viên.</param>
        public static Task<(bool Success, string Message, string? Url)> UploadImage(string filePath, string folder = "misc")
            => UploadDAL.UploadImageAsync(filePath, folder);
    }
}
