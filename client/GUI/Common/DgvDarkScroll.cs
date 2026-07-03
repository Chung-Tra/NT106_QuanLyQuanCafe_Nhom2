using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace GUI
{
    // Áp dụng dark-mode scrollbar (Windows 10/11) cho DGV và các control chứa scrollbar.
    internal static class DgvDarkScroll
    {
        [DllImport("uxtheme.dll", CharSet = CharSet.Unicode)]
        private static extern int SetWindowTheme(IntPtr hwnd, string pszSubAppName, string pszSubIdList);

        // Gọi sau khi DGV (hoặc control) đã tạo handle, hoặc tự gắn event nếu handle chưa có.
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
            try { 
                SetWindowTheme(handle, "DarkMode_Explorer", null); 
            }
            catch { /* fallback im lặng nếu API không hỗ trợ */ }
        }
    }
}
