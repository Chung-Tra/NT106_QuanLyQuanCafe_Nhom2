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
        // Font dùng chung cho mọi thẻ — tạo 1 lần, KHÔNG cấp phát lại mỗi lần dựng thẻ.
        // (Trước đây mỗi thẻ new 4 Font, Controls.Clear() không dispose -> rò rỉ GDI handle,
        //  dựng lại nhiều lần là treo/đơ.)
        private static readonly Font FontOrder = new("Segoe UI", 10F, FontStyle.Bold);
        private static readonly Font FontTime  = new("Segoe UI", 8F);
        private static readonly Font FontItems = new("Segoe UI", 9F);
        private static readonly Font FontBtn   = new("Segoe UI", 8F, FontStyle.Bold);

        // Cột "Hoàn thành" chỉ giữ N đơn xong gần nhất; đơn cũ không cần nằm trên bảng bếp.
        // (Đơn hoàn thành tích lũy mãi theo thời gian nên nếu vẽ hết sẽ phình vô hạn.)
        private const int MaxDoneCards = 6;

        // Tự làm mới (realtime): 6s/lần, chỉ dựng lại khi dữ liệu thực sự đổi.
        private readonly System.Windows.Forms.Timer _refreshTimer = new() { Interval = 6000 };
        private bool _loading;
        private string _lastSignature = "";

        private Dictionary<string, string> _foodNames = new();
        private Dictionary<string, TableDTO> _tables = new();

        public ucKDS_Barista()
        {
            InitializeComponent();
        }

        private async void UcKDS_Barista_Load(object? sender, EventArgs e)
        {
            // Lưới 3 cột phải LẤP ĐẦY pnlOrders theo cả chiều cao (không chỉ Anchor +
            // Size thiết kế — khi phóng to, Anchor giãn không đủ nên cột chỉ cao nửa
            // trên, để trống phần đáy). Dock=Fill + Padding giữ khoảng đệm bo góc.
            pnlOrders.Padding = new Padding(18, 14, 18, 14);
            tblCols.Dock = DockStyle.Fill;

            // Thẻ giãn theo cột kanban khi phóng to cửa sổ.
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

            // Realtime: chỉ fetch/dựng khi màn đang hiển thị (UC được cache khi rời màn).
            _refreshTimer.Tick += async (s, ev) => { if (Visible) await LoadOrders(); };
            VisibleChanged     += async (s, ev) => { if (Visible) await LoadOrders(force: true); };
            Disposed           += (s, ev) => _refreshTimer.Dispose();
            _refreshTimer.Start();

            await LoadOrders(force: true);
        }

        // force = true: nạp lại foods/tables và luôn dựng lại (mở màn / hiện lại / sau khi bấm nút).
        // force = false (timer tick): chỉ fetch orders, và bỏ qua nếu không có gì đổi.
        private async Task LoadOrders(bool force = false)
        {
            if (_loading) return;   // chặn chồng lần tải khi timer trùng thao tác người dùng
            _loading = true;
            try
            {
                Dictionary<string, OrderDTO> orders;
                try
                {
                    if (force || _foodNames.Count == 0 || _tables.Count == 0)
                    {
                        _foodNames = (await FoodBUS.GetListFoods())
                            .Where(f => f.Id != null)
                            .ToDictionary(f => f.Id!, f => f.Name ?? f.Id!);
                        _tables = await TableBUS.GetAll();
                    }
                    orders = await OrderBUS.GetAll();
                }
                catch
                {
                    lblPending.Text = "Không tải được đơn (kiểm tra server)";
                    return;
                }

                // Bỏ đơn huỷ, sắp theo thời gian tạo.
                var active = orders.Where(o => o.Value.Status != "huy")
                                   .OrderBy(o => o.Value.CreatedAt)
                                   .ToList();

                // Chữ ký nhẹ để phát hiện thay đổi — không đổi thì khỏi dựng lại (tránh giật, mất vị trí cuộn).
                string sig = string.Join("|", active.Select(o => $"{o.Key}:{o.Value.Status}"));
                if (!force && sig == _lastSignature) return;
                _lastSignature = sig;

                // Chỉ giữ N đơn "hoàn thành" mới nhất để hiển thị.
                var doneShown = active.Where(o => o.Value.Status == "hoan_thanh")
                                      .OrderByDescending(o => o.Value.CreatedAt)
                                      .Take(MaxDoneCards)
                                      .Select(o => o.Key)
                                      .ToHashSet();

                flpPendingOrders.SuspendLayout();
                flpInProgressOrders.SuspendLayout();
                flpDoneOrders.SuspendLayout();
                ClearCards(flpPendingOrders);
                ClearCards(flpInProgressOrders);
                ClearCards(flpDoneOrders);

                int pend = 0, prog = 0, done = 0;
                foreach (var kv in active)
                {
                    var ord = kv.Value;

                    string table = (ord.TableId != null && _tables.TryGetValue(ord.TableId, out var tb))
                        ? (tb.Name ?? ord.TableId) : "Mang đi";
                    var items = (ord.Items?.Values ?? Enumerable.Empty<OrderItemDTO>())
                        .Select(it => $"{it.Quantity}x {FoodName(it.FoodId)}").ToArray();
                    string time = ord.CreatedAt > 0
                        ? DateTimeOffset.FromUnixTimeMilliseconds(ord.CreatedAt).LocalDateTime.ToString("HH:mm")
                        : "";

                    switch (ord.Status)
                    {
                        case "hoan_thanh":
                            done++;
                            if (doneShown.Contains(kv.Key))   // chỉ vẽ đơn xong gần nhất
                                AddOrderCard(flpDoneOrders, kv.Key, table, items, time, Color.MediumSeaGreen, null);
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

                flpDoneOrders.ResumeLayout();
                flpInProgressOrders.ResumeLayout();
                flpPendingOrders.ResumeLayout();

                // Mở màn / hiện lại / sau thao tác: cuộn về đầu để không cắt thẻ đầu cột.
                // (Không reset ở tick nền để khỏi giật vị trí cuộn của người đang xem.)
                if (force)
                    foreach (var flp in new[] { flpPendingOrders, flpInProgressOrders, flpDoneOrders })
                        flp.AutoScrollPosition = new Point(0, 0);

                lblPending.Text = $"Chờ: {pend}";
                lblInProgress.Text = $"Đang pha: {prog}";
                lblDone.Text = $"Hoàn thành: {done}";
            }
            finally { _loading = false; }
        }

        // Controls.Clear() KHÔNG dispose control con -> phải tự dispose để trả handle/bộ nhớ.
        private static void ClearCards(FlowLayoutPanel panel)
        {
            for (int i = panel.Controls.Count - 1; i >= 0; i--)
            {
                var c = panel.Controls[i];
                panel.Controls.RemoveAt(i);
                c.Dispose();
            }
        }

        private string FoodName(string? id)
            => (id != null && _foodNames.TryGetValue(id, out var n)) ? n : (id ?? "Món");

        private async void BtnReport_Click(object? sender, EventArgs e)
        {
            string report =
                "BÁO CÁO KDS\n" +
                $"Thời gian: {DateTime.Now:HH:mm dd/MM/yyyy}\n" +
                "──────────────────\n" +
                $"• {lblPending.Text}\n" +
                $"• {lblInProgress.Text}\n" +
                $"• {lblDone.Text}";

            if (MsgBox.Show(MsgBox.OwnerWindow(this), report + "\n──────────────────\nGửi báo cáo cho quản lý?",
                            "Báo cáo KDS", MsgBox.MessageBoxType.Warning) != DialogResult.Yes) return;

            var (ok, msg) = await ManagerReport.SendAsync(report, "bao_cao", "kds");
            MsgBox.Show(MsgBox.OwnerWindow(this), msg, ok ? "Thành công" : "Lỗi",
                        ok ? MsgBox.MessageBoxType.Success : MsgBox.MessageBoxType.Error);
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
                Font = FontOrder,
                ForeColor = accentColor,
                Location = new Point(8, 5),
                AutoSize = true
            };

            Label lblTime = new()
            {
                Text = time,
                Font = FontTime,
                ForeColor = Color.Gray,
                Location = new Point(170, 8),
                AutoSize = true,
                Anchor = AnchorStyles.Top | AnchorStyles.Right
            };

            Label lblItems = new()
            {
                Text = items.Length > 0 ? string.Join("\n", items) : "(không có món)",
                Font = FontItems,
                ForeColor = Color.White,
                Location = new Point(8, 30),
                Size = new Size(210, 60),
                AutoSize = false,
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right
            };

            Guna2Button btnAction = new()
            {
                Text = nextStatus == "dang_phuc_vu" ? "Bắt đầu pha" : nextStatus == "hoan_thanh" ? "Hoàn thành" : "✓",
                Font = FontBtn,
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
                if (ok) await LoadOrders(force: true);
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
