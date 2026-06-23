using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace GUI
{
    /// <summary>
    /// Áp dụng dark-mode scrollbar (Windows 10/11) cho DGV và các Control chứa scrollbar.
    /// Dùng UxTheme.SetWindowTheme với chủ đề "DarkMode_Explorer" — không vẽ lại scrollbar,
    /// chỉ chuyển sang chủ đề tối built-in của Windows.
    /// </summary>
    internal static class DgvDarkScroll
    {
        [DllImport("uxtheme.dll", CharSet = CharSet.Unicode)]
        private static extern int SetWindowTheme(IntPtr hwnd, string pszSubAppName, string pszSubIdList);

        /// <summary>
        /// Gọi sau khi DGV (hoặc Control) đã tạo handle.
        /// Nếu handle chưa có, hàm sẽ tự gắn event để áp dụng khi handle được tạo.
        /// </summary>
        public static void Apply(Control? control)
        {
            if (control == null) return;

            if (control.IsHandleCreated)
            {
                TryApply(control.Handle);
            }
            else
            {
                control.HandleCreated += (s, e) =>
                {
                    if (s is Control c) TryApply(c.Handle);
                };
            }
        }

        private static void TryApply(IntPtr handle)
        {
            try { SetWindowTheme(handle, "DarkMode_Explorer", null); }
            catch { /* fallback im lặng nếu API không hỗ trợ */ }
        }
    }
}
