using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace GUI
{
    internal sealed partial class PaymentDialog : Form
    {
        public string Method { get; private set; } = "Tiền mặt";

        private readonly long _total;
        private long _received;
        private string _mode = "cash"; // cash | card | qr

        public PaymentDialog(long total, string table, string customer)
        {
            _total = total;
            InitializeComponent();
            WindowChrome.Apply(this, host: cardRoot);

            KeyPreview = true;
            KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Escape) { DialogResult = DialogResult.Cancel; Close(); }
            };

            // Runtime-data labels
            lblSub.Text        = $"{table}  ·  {customer}";
            lblTotalValue.Text = Theme.Vnd(_total);

            // Method-toggle buttons
            _btnCash.Click += (s, e) => SetMode("cash");
            _btnCard.Click += (s, e) => SetMode("card");
            _btnQr.Click   += (s, e) => SetMode("qr");

            // Cash panel — wire quick-amount buttons (amounts depend on _total)
            _txtReceived.TextChanged += (s, e) => { _received = ParseMoney(_txtReceived.Text); UpdateChange(); };
            _btnQk0.Click += (s, e) => _txtReceived.Text = _total.ToString("#,##0");
            _btnQk1.Click += (s, e) => _txtReceived.Text = (50000L).ToString("#,##0");
            _btnQk2.Click += (s, e) => _txtReceived.Text = (100000L).ToString("#,##0");
            _btnQk3.Click += (s, e) => _txtReceived.Text = (200000L).ToString("#,##0");
            _btnQk4.Click += (s, e) => _txtReceived.Text = (500000L).ToString("#,##0");

            // QR panel — runtime reference + amount
            _qrBox.Paint += (s, e) => DrawMockQr(e.Graphics, _qrBox.ClientRectangle);
            _lblQrInfo.Text   = $"Ngân hàng:  Vietcombank\r\nChủ TK:  QUAN CAFE NHOM2\r\nSố TK:  0123 456 789\r\nNội dung:  TT {DateTime.Now:HHmmss}";
            _lblQrAmount.Text = "Số tiền:  " + Theme.Vnd(_total);

            // Footer
            btnCancel.HoverState.FillColor   = Theme.SurfaceHover;
            btnCancel.HoverState.BorderColor = Theme.Lighten(Theme.Border, 40);
            btnCancel.Click += (s, e) => { DialogResult = DialogResult.Cancel; Close(); };
            _btnConfirm.HoverState.FillColor = Theme.Lighten(Theme.Green, 16);

            SetMode("cash");
            try { FormCorners.Round(this); } catch { }
        }

        private void SetMode(string mode)
        {
            _mode = mode;
            foreach (var (b, m) in new[] { (_btnCash, "cash"), (_btnCard, "card"), (_btnQr, "qr") })
            {
                bool on = m == mode;
                b.FillColor            = on ? Theme.Teal : Theme.SurfaceAlt;
                b.ForeColor            = on ? Color.White : Theme.TextPri;
                b.HoverState.FillColor = on ? Theme.TealHover : Theme.SurfaceHover;
            }
            _pnlCash.Visible = mode == "cash";
            _pnlCard.Visible = mode == "card";
            _pnlQr.Visible   = mode == "qr";
            Method = mode == "cash" ? "Tiền mặt" : mode == "card" ? "Thẻ" : "VietQR";
        }

        private void DrawMockQr(Graphics g, Rectangle r)
        {
            g.SmoothingMode = SmoothingMode.None;
            int pad = 14, modules = 21;
            int cell = (r.Width - pad * 2) / modules;
            int ox = pad, oy = pad;
            var rng = new Random((int)(_total % int.MaxValue) + 7);
            using var black = new SolidBrush(Color.Black);
            for (int y = 0; y < modules; y++)
                for (int x = 0; x < modules; x++)
                    if (rng.Next(100) < 48)
                        g.FillRectangle(black, ox + x * cell, oy + y * cell, cell, cell);
            DrawFinder(g, ox, oy, cell);
            DrawFinder(g, ox + (modules - 7) * cell, oy, cell);
            DrawFinder(g, ox, oy + (modules - 7) * cell, cell);
        }

        private static void DrawFinder(Graphics g, int x, int y, int cell)
        {
            using var black = new SolidBrush(Color.Black);
            using var white = new SolidBrush(Color.White);
            g.FillRectangle(black, x, y, cell * 7, cell * 7);
            g.FillRectangle(white, x + cell, y + cell, cell * 5, cell * 5);
            g.FillRectangle(black, x + cell * 2, y + cell * 2, cell * 3, cell * 3);
        }

        private void UpdateChange()
        {
            long change = _received - _total;
            _lblChange.Text      = change >= 0 ? $"Tiền thối:  {Theme.Vnd(change)}" : $"Còn thiếu:  {Theme.Vnd(-change)}";
            _lblChange.ForeColor = change >= 0 ? Theme.Green : Theme.Red;
        }

        private void Confirm_Click(object? sender, EventArgs e)
        {
            if (_mode == "cash" && _received < _total)
            {
                MsgBox.Show(this, "Số tiền khách đưa chưa đủ.", "Thanh toán", MsgBox.MessageBoxType.Error);
                return;
            }
            DialogResult = DialogResult.OK;
            Close();
        }

        private static long ParseMoney(string s)
        {
            long v = 0;
            foreach (char c in s) if (char.IsDigit(c)) v = v * 10 + (c - '0');
            return v;
        }

        // Mở hộp thanh toán; trả về true nếu xác nhận, kèm phương thức đã chọn.
        public static bool Pay(IWin32Window? owner, long total, string table, string customer, out string method)
        {
            using var d = new PaymentDialog(total, table, customer);
            bool ok = d.ShowDialog(owner) == DialogResult.OK;
            method = d.Method;
            return ok;
        }
    }
}
