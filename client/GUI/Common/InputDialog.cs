using System;
using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace GUI
{
    internal sealed partial class InputDialog : Form
    {
        public string Value => _tb.Text.Trim();

        private InputDialog(string title, string label, string placeholder, string preset)
        {
            InitializeComponent();

            // Nội dung động truyền từ caller
            lblTitle.Text = title;
            lbl.Text = label;
            _tb.PlaceholderText = placeholder;
            _tb.Text = preset;

            btnCancel.Click += (s, e) =>
            {
                DialogResult = DialogResult.Cancel;
                Close();
            };

            btnOk.Click += (s, e) =>
            {
                DialogResult = DialogResult.OK;
                Close();
            };

            KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                {
                    DialogResult = DialogResult.OK;
                    Close();
                }
                else if (e.KeyCode == Keys.Escape)
                {
                    DialogResult = DialogResult.Cancel;
                    Close();
                }
            };

            try
            {
                FormCorners.Round(this);
            }
            catch { }

            WindowChrome.Apply(this, host: card);
        }

        // Trả về chuỗi đã nhập (đã trim, khác rỗng) hoặc null nếu hủy.
        public static string? Show(IWin32Window? owner, string title, string label, string placeholder = "", string preset = "")
        {
            using var d = new InputDialog(title, label, placeholder, preset);
            return d.ShowDialog(owner) == DialogResult.OK && d.Value.Length > 0 ? d.Value : null;
        }
    }
}
