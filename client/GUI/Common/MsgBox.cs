using System.Linq;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace GUI
{
    /// <summary>
    /// Hộp thoại thông báo dùng Guna2MessageDialog (built-in từ Guna.UI2).
    /// Giữ nguyên API MsgBox.Show(...) để 46 call sites không phải đổi.
    /// </summary>
    internal static class MsgBox
    {
        public enum MessageBoxType { Info, Success, Error, Warning }

        public static DialogResult Show(
            string message,
            string title        = "Thông báo",
            MessageBoxType type = MessageBoxType.Info) =>
            Show(null, message, title, type);

        public static DialogResult Show(
            IWin32Window? owner,
            string message,
            string title        = "Thông báo",
            MessageBoxType type = MessageBoxType.Info)
        {
            Form? parent = owner switch
            {
                Form f      => f,
                Control c   => c.FindForm(),
                _           => Application.OpenForms.Cast<Form>().LastOrDefault()
            };

            var dlg = new Guna2MessageDialog
            {
                Parent  = parent,
                Caption = title,
                Text    = message ?? string.Empty,
                Style   = MessageDialogStyle.Dark,
                Icon    = ToIcon(type),
                Buttons = type == MessageBoxType.Warning
                    ? MessageDialogButtons.YesNo
                    : MessageDialogButtons.OK,
            };
            return dlg.Show();
        }

        /// <summary>
        /// Lấy IWin32Window an toàn từ một Control bất kỳ (UC, Form, ...).
        /// </summary>
        public static IWin32Window? OwnerWindow(Control? control)
        {
            if (control == null) return null;
            return control.FindForm() ?? control.TopLevelControl as IWin32Window;
        }

        private static MessageDialogIcon ToIcon(MessageBoxType type) => type switch
        {
            MessageBoxType.Success => MessageDialogIcon.Information,
            MessageBoxType.Error   => MessageDialogIcon.Error,
            MessageBoxType.Warning => MessageDialogIcon.Warning,
            _                      => MessageDialogIcon.Information,
        };
    }
}
