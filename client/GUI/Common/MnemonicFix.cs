using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Forms;

namespace GUI
{
    // WinForms mặc định coi '&' trong Text là phím tắt (mnemonic) → vẽ thành gạch dưới,
    // nên "Sản phẩm & Thực đơn" hiển thị thành "Sản phẩm _Thực đơn". Helper này quét toàn
    // bộ cây control và tắt xử lý mnemonic để '&' hiển thị đúng nguyên văn:
    //   • Label / Button / CheckBox / RadioButton  → UseMnemonic = false
    //   • Guna2Button và các control Guna có TextFormatNoPrefix → true
    // Được gọi tập trung từ WindowChrome.Apply (mọi Form) và MainDashboard (mọi UC),
    // nên KHÔNG cần sửa từng chuỗi "&" rải rác trong từng màn hình.
    internal static class MnemonicFix
    {
        // Cache PropertyInfo theo Type để không reflection lặp lại cho từng control.
        private static readonly Dictionary<Type, PropertyInfo?> _noPrefixProps = new();

        public static void Apply(Control root)
        {
            if (root == null || root.IsDisposed) return;

            switch (root)
            {
                case Label lbl:
                    lbl.UseMnemonic = false;
                    break;
                case ButtonBase btn: // Button / CheckBox / RadioButton chuẩn WinForms
                    btn.UseMnemonic = false;
                    break;
                default:
                    TrySetNoPrefix(root); // Guna2Button, Guna2GradientButton, ...
                    break;
            }

            foreach (Control child in root.Controls)
                Apply(child);
        }

        private static void TrySetNoPrefix(Control c)
        {
            var type = c.GetType();
            if (!_noPrefixProps.TryGetValue(type, out var prop))
            {
                prop = type.GetProperty("TextFormatNoPrefix", BindingFlags.Public | BindingFlags.Instance);
                if (prop != null && (prop.PropertyType != typeof(bool) || !prop.CanWrite)) prop = null;
                _noPrefixProps[type] = prop;
            }
            try { prop?.SetValue(c, true); } catch { }
        }
    }
}
