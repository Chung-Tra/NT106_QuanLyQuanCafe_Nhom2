using BUS;
using DTO;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace GUI
{
#pragma warning disable IDE1006
    public partial class ucKDS_Barista : UserControl
#pragma warning restore IDE1006
    {
        private Dictionary<string, string> _foodNames = new();

        public ucKDS_Barista()
        {
            InitializeComponent();
        }

        private async void UcKDS_Barista_Load(object? sender, EventArgs e)
        {
            // Thẻ đơn giãn theo cột kanban khi phóng to cửa sổ
            foreach (var flp in new[] { flpPendingOrders, flpInProgressOrders, flpDoneOrders })
            {
                var panel = flp;
                void FitCards(object? s, EventArgs ev)
                {
                    int w = Math.Max(220, panel.ClientSize.Width - 10);
                    foreach (Control c in panel.Controls) c.Width = w;
                }
                panel.ClientSizeChanged += FitCards;
            }

            await LoadOrders();
        }

        private async Task LoadOrders()
        {
            flpPendingOrders.Controls.Clear();
            flpInProgressOrders.Controls.Clear();
            flpDoneOrders.Controls.Clear();

            Dictionary<string, OrderDTO> orders;
            Dictionary<string, TableDTO> tables;
            try
            {
                _foodNames = (await FoodBUS.GetListFoods())
                    .Where(f => f.Id != null)
                    .ToDictionary(f => f.Id!, f => f.Name ?? f.Id!);
                orders = await OrderBUS.GetAll();
                tables = await TableBUS.GetAll();
            }
            catch
            {
                lblPending.Text = "Không tải được đơn (kiểm tra server)";
                return;
            }

            int pend = 0, prog = 0, done = 0;
            foreach (var kv in orders.OrderBy(o => o.Value.CreatedAt))
            {
                var ord = kv.Value;
                if (ord.Status == "huy") continue;

                string table = (ord.TableId != null && tables.TryGetValue(ord.TableId, out var tb))
                    ? (tb.Name ?? ord.TableId) : "Mang đi";
                var items = (ord.Items?.Values ?? Enumerable.Empty<OrderItemDTO>())
                    .Select(it => $"{it.Quantity}x {FoodName(it.FoodId)}").ToArray();
                string time = ord.CreatedAt > 0
                    ? DateTimeOffset.FromUnixTimeMilliseconds(ord.CreatedAt).LocalDateTime.ToString("HH:mm")
                    : "";

                switch (ord.Status)
                {
                    case "hoan_thanh":
                        AddOrderCard(flpDoneOrders, kv.Key, table, items, time, Color.MediumSeaGreen, null);
                        done++;
                        break;
                    case "dang_phuc_vu":
                        AddOrderCard(flpInProgressOrders, kv.Key, table, items, time, Color.SteelBlue, "hoan_thanh");
                        prog++;
                        break;
                    default: // pending / khác
                        AddOrderCard(flpPendingOrders, kv.Key, table, items, time, Color.Orange, "dang_phuc_vu");
                        pend++;
                        break;
                }
            }

            lblPending.Text = $"Chờ: {pend}";
            lblInProgress.Text = $"Đang pha: {prog}";
            lblDone.Text = $"Hoàn thành: {done}";
        }

        private string FoodName(string? id)
            => (id != null && _foodNames.TryGetValue(id, out var n)) ? n : (id ?? "Món");

        private void BtnReport_Click(object? sender, EventArgs e)
        {
            string report =
                "BÁO CÁO KDS\n" +
                $"Thời gian: {DateTime.Now:HH:mm dd/MM/yyyy}\n" +
                "──────────────────\n" +
                $"• {lblPending.Text}\n" +
                $"• {lblInProgress.Text}\n" +
                $"• {lblDone.Text}\n" +
                "──────────────────\n" +
                "Gửi báo cáo cho quản lý?";

            if (MsgBox.Show(MsgBox.OwnerWindow(this), report, "Báo cáo KDS", MsgBox.MessageBoxType.Warning) == DialogResult.Yes)
                MsgBox.Show(MsgBox.OwnerWindow(this), "Đã gửi báo cáo KDS cho quản lý!", "Thành công", MsgBox.MessageBoxType.Success);
        }

        private void AddOrderCard(FlowLayoutPanel panel, string orderId, string table, string[] items, string time, Color accentColor, string? nextStatus)
        {
            Panel card = new()
            {
                Size = new Size(220, 120),
                BackColor = Color.FromArgb(45, 45, 50),
                Margin = new Padding(5),
                Cursor = Cursors.Hand
            };

            Label lblOrder = new()
            {
                Text = $"{orderId} - {table}",
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                ForeColor = accentColor,
                Location = new Point(8, 5),
                AutoSize = true
            };

            Label lblTime = new()
            {
                Text = time,
                Font = new Font("Segoe UI", 8F),
                ForeColor = Color.Gray,
                Location = new Point(170, 8),
                AutoSize = true,
                Anchor = AnchorStyles.Top | AnchorStyles.Right
            };

            Label lblItems = new()
            {
                Text = items.Length > 0 ? string.Join("\n", items) : "(không có món)",
                Font = new Font("Segoe UI", 9F),
                ForeColor = Color.White,
                Location = new Point(8, 30),
                Size = new Size(210, 60),
                AutoSize = false,
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right
            };

            Guna2Button btnAction = new()
            {
                Text = nextStatus == "dang_phuc_vu" ? "Bắt đầu pha" : nextStatus == "hoan_thanh" ? "Hoàn thành" : "✓",
                Font = new Font("Segoe UI", 8F, FontStyle.Bold),
                ForeColor = Color.White,
                FillColor = accentColor,
                BorderRadius = 6,
                Size = new Size(nextStatus == null ? 30 : 90, 22),
                Location = new Point(8, 92),
                Cursor = Cursors.Hand,
                Enabled = nextStatus != null
            };
            btnAction.Click += async (s, e) =>
            {
                if (nextStatus == null) return;
                btnAction.Enabled = false;
                var (ok, msg) = await OrderBUS.Update(orderId, new { trang_thai = nextStatus });
                if (ok) await LoadOrders();
                else
                {
                    btnAction.Enabled = true;
                    MsgBox.Show(MsgBox.OwnerWindow(this), msg, "Lỗi cập nhật", MsgBox.MessageBoxType.Error);
                }
            };

            card.Controls.AddRange(new Control[] { lblOrder, lblTime, lblItems, btnAction });
            panel.Controls.Add(card);
            card.Width = Math.Max(220, panel.ClientSize.Width - 10);
        }
    }
}
