using BUS;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace GUI
{
    public partial class ucPOS_Order : UserControl
    {
        // Đơn hàng hiện tại: key = tên món, value = (số lượng, đơn giá)
        private readonly Dictionary<string, (int qty, long price)> _orderItems = new();
        // Huy hiệu SL trên mỗi thẻ món (key = tên món) để cập nhật khi thêm vào đơn
        private readonly Dictionary<string, Guna2Button> _cardQtyBadges = new();
        // Menu thật đã tải + tra cứu FoodDTO theo tên/id món (lấy mon_id khi tạo đơn, tên khi mở đơn cũ)
        private List<FoodDTO> _menu = new();
        private readonly Dictionary<string, FoodDTO> _foodByName = new();
        private readonly Dictionary<string, FoodDTO> _foodById = new();

        // ----- Bàn & đơn đang phục vụ -----
        // _currentTableId = null nghĩa là bán mang đi / chưa chọn bàn.
        private string? _currentTableId;
        private string _currentTable = "Mang đi";
        // Đơn đã "Gửi pha chế" nhưng CHƯA thanh toán (id trên node orders).
        private string? _currentOrderId;
        // true = chính mình vừa chuyển bàn trống → có khách (để trả bàn nếu đổi ý/hủy).
        private bool _tableClaimed;

        // ----- Sơ đồ bàn -----
        private FlowLayoutPanel? _tableMapFlp;
        private string _tableMapSig = "";
        private bool _mapLoading;
        // Poll giống KDS: bàn đổi trạng thái từ máy khác (QR, quản lý, POS khác) tự hiện lại.
        private readonly System.Windows.Forms.Timer _tableMapTimer = new() { Interval = 7000 };

        public ucPOS_Order()
        {
            InitializeComponent();
            Load += async (s, e) => await InitPOS();

            // Double-click 1 món trong đơn -> form chi tiết read-only
            dgvCurrentOrder.CellDoubleClick += (s, e) =>
            {
                if (e.RowIndex < 0) return;
                RecordDetail.FromRow(dgvCurrentOrder.Rows[e.RowIndex], "Chi tiết món trong đơn")
                            .ShowDialog(MsgBox.OwnerWindow(this));
            };
            WireCartContextMenu();

            _tableMapTimer.Tick += async (s, e) =>
            {
                if (Visible && _tableMapFlp is { IsDisposed: false, Visible: true } flp)
                    await ReloadTableMap(flp, force: false);
            };
            Disposed += (s, e) => _tableMapTimer.Dispose();
            _tableMapTimer.Start();

            UpdateTableLabels();
        }

        private void BtnTabOrder_Click(object? sender, EventArgs e) => ShowOrderTab();
        private void TxtDiscount_TextChanged(object? sender, EventArgs e) => UpdateTotal();

        private async Task InitPOS()
        {
            try
            {
                List<FoodDTO> menu = await Task.Run(FoodBUS.GetListFoods);
                if (menu == null || menu.Count == 0)
                {
                    LoadMockProducts();
                    return;
                }

                _menu = menu;
                _foodByName.Clear();
                _foodById.Clear();
                foreach (var f in menu)
                {
                    if (!string.IsNullOrWhiteSpace(f.Name)) _foodByName[f.Name!] = f;
                    if (!string.IsNullOrWhiteSpace(f.Id)) _foodById[f.Id!] = f;
                }

                flpProducts.Controls.Clear();
                _cardQtyBadges.Clear();
                foreach (var food in menu.Where(f => f.InStock))
                    flpProducts.Controls.Add(CreateProductCard(food.Name ?? "---", (long)food.Price, food.Category ?? "", food.ImageUrl));

                SetupOrderGrid();
            }
            catch
            {
                LoadMockProducts();
            }
        }

        private void LoadMockProducts()
        {
            var mocks = new[]
            {
                ("Cà phê đen",       25000L, "Cà phê"),
                ("Cà phê sữa",       30000L, "Cà phê"),
                ("Latte",            45000L, "Cà phê"),
                ("Cappuccino",       45000L, "Cà phê"),
                ("Americano",        35000L, "Cà phê"),
                ("Trà đào cam sả",   45000L, "Trà"),
                ("Trà sữa trân châu",40000L, "Trà sữa"),
                ("Matcha latte",     50000L, "Đặc biệt"),
                ("Sinh tố xoài",     45000L, "Sinh tố"),
                ("Nước cam tươi",    35000L, "Nước trái cây"),
                ("Bánh croissant",   25000L, "Bánh"),
                ("Bánh flan",        20000L, "Bánh"),
            };

            flpProducts.Controls.Clear();
            _cardQtyBadges.Clear();
            foreach (var (name, price, cat) in mocks)
                flpProducts.Controls.Add(CreateProductCard(name, price, cat));

            SetupOrderGrid();
        }

        // Thẻ món dạng đứng: ô ảnh (icon theo loại + màu, hoặc ảnh thật nếu có file) →
        // tên món → giá nổi bật + nút "+". Có chip loại và huy hiệu SL khi món đã trong đơn.
        private Guna2Panel CreateProductCard(string name, long price, string cat, string? imageUrl = null)
        {
            var (icon, accent) = CategoryStyle(cat);

            var card = new Guna2Panel
            {
                FillColor       = Theme.Surface,
                BorderRadius    = 14,
                BorderColor     = Theme.Border,
                BorderThickness = 1,
                Size            = new Size(156, 198),
                Margin          = new Padding(7),
                Cursor          = Cursors.Hand,
            };

            // ----- Ô ảnh / icon -----
            var tile = new Guna2Panel
            {
                FillColor       = Theme.Fade(accent, 46),
                BorderRadius    = 10,
                Location        = new Point(10, 10),
                Size            = new Size(136, 96),
                BackgroundImageLayout = ImageLayout.Zoom,
            };
            var lblIcon = new Label
            {
                Text      = icon,
                Font      = new Font("Segoe UI Emoji", 30F),
                ForeColor = Theme.TextHi,
                BackColor = Color.Transparent,
                Dock      = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter,
            };
            tile.Controls.Add(lblIcon);
            // Ảnh thật: file cục bộ tồn tại, hoặc URL Firebase Storage (tải nền, không chặn UI)
            if (TryLoadLocalImage(imageUrl, out Image? realImg))
            {
                tile.BackgroundImage = realImg;
                lblIcon.Visible = false;
            }
            else if (!string.IsNullOrWhiteSpace(imageUrl) &&
                     imageUrl!.StartsWith("http", StringComparison.OrdinalIgnoreCase))
            {
                LoadTileImageAsync(tile, lblIcon, imageUrl);
            }
            card.Controls.Add(tile);

            // ----- Chip loại (góc trên-trái ô ảnh) -----
            if (!string.IsNullOrWhiteSpace(cat))
            {
                var chip = new Guna2Panel
                {
                    FillColor    = Theme.Fade(accent, 150),
                    BorderRadius = 8,
                    Location     = new Point(16, 16),
                    AutoSize     = false,
                    Size         = new Size(Math.Min(96, 16 + cat.Length * 7), 20),
                };
                chip.Controls.Add(new Label
                {
                    Text      = cat,
                    Font      = Theme.F(7.5F, FontStyle.Bold),
                    ForeColor = Color.White,
                    BackColor = Color.Transparent,
                    Dock      = DockStyle.Fill,
                    TextAlign = ContentAlignment.MiddleCenter,
                });
                tile.Controls.Add(chip);
                chip.BringToFront();
            }

            // ----- Tên món (tối đa 2 dòng) -----
            var lblName = new Label
            {
                Text      = name,
                Font      = Theme.F(9.5F, FontStyle.Bold),
                ForeColor = Theme.TextHi,
                BackColor = Color.Transparent,
                Location  = new Point(12, 114),
                Size      = new Size(132, 38),
            };
            card.Controls.Add(lblName);

            // ----- Giá -----
            card.Controls.Add(new Label
            {
                Text      = Theme.Vnd(price),
                Font      = Theme.F(11.5F, FontStyle.Bold),
                ForeColor = Theme.Lighten(accent, 55),
                BackColor = Color.Transparent,
                Location  = new Point(12, 160),
                AutoSize  = true,
            });

            // ----- Nút "+" tròn -----
            var btnAdd = new Guna2Button
            {
                Text         = "+",
                Font         = new Font("Segoe UI", 14F, FontStyle.Bold),
                FillColor    = accent,
                ForeColor    = Color.White,
                BorderRadius = 15,
                Size         = new Size(30, 30),
                Location     = new Point(116, 158),
                Cursor       = Cursors.Hand,
            };
            btnAdd.HoverState.FillColor = Theme.Lighten(accent, 24);
            card.Controls.Add(btnAdd);
            btnAdd.BringToFront();

            // ----- Huy hiệu SL (ẩn cho tới khi món có trong đơn) -----
            var badge = new Guna2Button
            {
                Font          = Theme.F(8.5F, FontStyle.Bold),
                FillColor     = Theme.Green,
                ForeColor     = Color.White,
                BorderRadius  = 11,
                Size          = new Size(24, 22),
                Location      = new Point(120, 14),
                Visible       = false,
                Enabled       = false,
                DisabledState = { FillColor = Theme.Green, ForeColor = Color.White, BorderColor = Color.Transparent },
            };
            card.Controls.Add(badge);
            badge.BringToFront();
            _cardQtyBadges[name] = badge;

            WireCardInteractions(card, accent, () => AddToOrder(name, price));
            return card;
        }

        // Gắn click "thêm vào đơn" + hiệu ứng hover cho cả thẻ và mọi control con
        private void WireCardInteractions(Guna2Panel card, Color accent, Action onClick)
        {
            void Enter(object? s, EventArgs e)
            {
                card.BorderColor = accent;
                card.FillColor   = Theme.SurfaceHover;
            }
            void Leave(object? s, EventArgs e)
            {
                Point p = card.PointToClient(Cursor.Position);
                if (!card.ClientRectangle.Contains(p))
                {
                    card.BorderColor = Theme.Border;
                    card.FillColor   = Theme.Surface;
                }
            }

            void Hook(Control c)
            {
                c.MouseEnter += Enter;
                c.MouseLeave += Leave;
                c.Click      += (s, e) => onClick();
                foreach (Control child in c.Controls) Hook(child);
            }
            Hook(card);
        }

        // Icon + màu nhấn theo loại món (không có ảnh vẫn nhìn phong phú, đúng tông app)
        private static (string icon, Color accent) CategoryStyle(string category)
        {
            string c = (category ?? "").ToLowerInvariant();
            if (c.Contains("cà phê") || c.Contains("ca phe") || c.Contains("coffee")) return ("☕", Color.FromArgb(181, 136, 99));
            if (c.Contains("trà sữa") || c.Contains("tra sua"))                        return ("🧋", Theme.Purple);
            if (c.Contains("trà")     || c.Contains("tra")   || c.Contains("tea"))     return ("🍵", Theme.Green);
            if (c.Contains("sinh tố") || c.Contains("smoothie"))                       return ("🥤", Theme.Red);
            if (c.Contains("nước")    || c.Contains("juice") || c.Contains("trái"))    return ("🍹", Theme.Blue);
            if (c.Contains("bánh")    || c.Contains("cake")  || c.Contains("dessert")) return ("🍰", Color.FromArgb(236, 128, 168));
            if (c.Contains("đặc biệt")|| c.Contains("special"))                        return ("⭐", Theme.Amber);
            return ("🍽️", Theme.Teal);
        }

        // Tải ảnh từ Firebase Storage (URL http) ở nền rồi gán làm nền ô ảnh.
        private static async void LoadTileImageAsync(Guna2Panel tile, Label icon, string url)
        {
            var img = await ImageLoader.FromUrlAsync(url);
            if (img != null && !tile.IsDisposed)
            {
                tile.BackgroundImage = img;
                icon.Visible = false;
            }
        }

        // Chỉ nạp ảnh từ file cục bộ tồn tại; bỏ qua URL http để không chặn luồng UI
        private static bool TryLoadLocalImage(string? path, out Image? image)
        {
            image = null;
            try
            {
                if (!string.IsNullOrWhiteSpace(path) && System.IO.File.Exists(path))
                {
                    image = Image.FromFile(path);
                    return true;
                }
            }
            catch { }
            return false;
        }

        private void SetupOrderGrid()
        {
            dgvCurrentOrder.Columns.Clear();
            dgvCurrentOrder.DataSource = null;

            var dt = new DataTable();
            dt.Columns.Add("Món");
            dt.Columns.Add("SL", typeof(int));
            dt.Columns.Add("Đơn giá", typeof(long));
            dt.Columns.Add("Thành tiền", typeof(long));
            // StyleGrid/ConfigureGrid tắt AutoGenerateColumns (cho lưới khai cột ở Designer).
            // Lưới này lại Clear cột rồi bind DataTable → phải bật auto-gen, nếu không sẽ
            // KHÔNG sinh cột nào và Columns["Món"] = null → NullReferenceException.
            dgvCurrentOrder.AutoGenerateColumns = true;
            dgvCurrentOrder.DataSource = dt;

            dgvCurrentOrder.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCurrentOrder.Columns["Món"].FillWeight         = 40;
            dgvCurrentOrder.Columns["SL"].FillWeight          = 12;
            dgvCurrentOrder.Columns["Đơn giá"].FillWeight     = 24;
            dgvCurrentOrder.Columns["Thành tiền"].FillWeight  = 24;
            dgvCurrentOrder.Columns["Đơn giá"].DefaultCellStyle.Format    = "N0";
            dgvCurrentOrder.Columns["Đơn giá"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvCurrentOrder.Columns["Thành tiền"].DefaultCellStyle.Format    = "N0";
            dgvCurrentOrder.Columns["Thành tiền"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvCurrentOrder.Columns["SL"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        // Chuột phải 1 dòng trong đơn: tăng/giảm SL hoặc xóa món (POS phải sửa được lỗi bấm nhầm).
        private void WireCartContextMenu()
        {
            var menu = new ContextMenuStrip
            {
                BackColor       = Color.FromArgb(31, 31, 34),
                ForeColor       = Color.White,
                ShowImageMargin = false,
                Font            = Theme.F(9F),
            };
            menu.Items.Add("Tăng SL (+1)", null, (s, e) => AdjustSelectedQty(+1));
            menu.Items.Add("Giảm SL (−1)", null, (s, e) => AdjustSelectedQty(-1));
            menu.Items.Add("Xóa món khỏi đơn", null, (s, e) => AdjustSelectedQty(int.MinValue));
            foreach (ToolStripItem it in menu.Items) { it.BackColor = menu.BackColor; it.ForeColor = menu.ForeColor; }
            dgvCurrentOrder.ContextMenuStrip = menu;

            // Chuột phải cũng chọn dòng dưới con trỏ (mặc định chỉ click trái mới chọn).
            dgvCurrentOrder.MouseDown += (s, e) =>
            {
                if (e.Button != MouseButtons.Right) return;
                var hit = dgvCurrentOrder.HitTest(e.X, e.Y);
                if (hit.RowIndex >= 0) dgvCurrentOrder.CurrentCell = dgvCurrentOrder.Rows[hit.RowIndex].Cells[0];
            };
        }

        private void AdjustSelectedQty(int delta)
        {
            var row = dgvCurrentOrder.CurrentRow;
            if (row == null || row.Index < 0) return;
            string? name = row.Cells["Món"].Value?.ToString();
            if (name == null || !_orderItems.TryGetValue(name, out var item)) return;

            long newQty = delta == int.MinValue ? 0 : (long)item.qty + delta;
            if (newQty <= 0) _orderItems.Remove(name);
            else _orderItems[name] = ((int)newQty, item.price);
            RefreshOrderGrid();
        }

        private void AddToOrder(string name, long price)
        {
            if (_orderItems.ContainsKey(name))
            {
                var (qty, p) = _orderItems[name];
                _orderItems[name] = (qty + 1, p);
            }
            else
            {
                _orderItems[name] = (1, price);
            }
            RefreshOrderGrid();
        }

        private void RefreshOrderGrid()
        {
            if (dgvCurrentOrder.DataSource is not DataTable dt) return;
            dt.Rows.Clear();
            foreach (var (name, (qty, price)) in _orderItems)
                dt.Rows.Add(name, qty, price, qty * price);
            UpdateTotal();
            UpdateCardBadges();
        }

        // Cập nhật huy hiệu SL trên thẻ món: hiện số khi món đã có trong đơn, ẩn khi = 0
        private void UpdateCardBadges()
        {
            foreach (var (name, badge) in _cardQtyBadges)
            {
                if (_orderItems.TryGetValue(name, out var item) && item.qty > 0)
                {
                    badge.Text    = item.qty.ToString();
                    badge.Visible = true;
                }
                else
                {
                    badge.Visible = false;
                }
            }
        }

        private void UpdateTotal()
        {
            long sub = _orderItems.Sum(kv => kv.Value.qty * kv.Value.price);
            long total = AppMath.OrderTotal(sub, AppMath.ParseVndDigits(txtDiscount.Text));
            lblTotalAmount.Text = Theme.Vnd(total);
        }

        // =========================================================================
        //  BÀN & ĐƠN HIỆN TẠI
        // =========================================================================

        // Huy hiệu bàn (góc phải panel hóa đơn) + dòng nhân viên: luôn cho biết
        // đang order cho bàn nào và đơn đã gửi pha chế hay chưa.
        private void UpdateTableLabels()
        {
            lblCurrentStaff.Text = $"Nhân viên: {GlobalSession.CurrentUser?.FullName ?? "Staff"}";

            bool hasTable = _currentTableId != null;
            string sent = _currentOrderId != null ? " · đã gửi bếp" : "";
            btnTableBadge.Text = hasTable ? _currentTable + sent : "Mang đi (chưa chọn bàn)";
            btnTableBadge.FillColor = hasTable || _currentOrderId != null
                ? Color.FromArgb(31, 138, 154)
                : Color.FromArgb(45, 45, 48);

            btnSendKitchen.Text = _currentOrderId == null ? "Gửi pha chế" : "Gửi bổ sung pha chế";
        }

        // Đơn CHƯA thanh toán mới nhất của một bàn (chưa có phiếu payments, chưa hủy).
        private static async Task<(string id, OrderDTO dto)?> FindOpenOrderAsync(string tableId)
        {
            var orders   = await OrderBUS.GetAll();
            var payments = await PaymentBUS.GetAll();
            var paid = payments.Values.Select(p => p.OrderId).Where(x => x != null).ToHashSet();

            var open = orders.Where(o => o.Value.TableId == tableId
                                      && o.Value.Status != "huy"
                                      && !paid.Contains(o.Key))
                             .OrderByDescending(o => o.Value.CreatedAt)
                             .FirstOrDefault();
            return open.Key == null ? null : (open.Key, open.Value);
        }

        // Đổ món của một đơn trên server vào giỏ (mở đơn của bàn có khách để thêm món/thanh toán).
        private void LoadOrderIntoCart(OrderDTO ord)
        {
            _orderItems.Clear();
            foreach (var it in ord.Items?.Values ?? Enumerable.Empty<OrderItemDTO>())
            {
                string name = (it.FoodId != null && _foodById.TryGetValue(it.FoodId, out var f))
                    ? (f.Name ?? it.FoodId) : (it.FoodId ?? "Món");
                long price = (long)it.UnitPrice;
                if (_orderItems.TryGetValue(name, out var cur)) _orderItems[name] = (cur.qty + it.Quantity, price);
                else _orderItems[name] = (it.Quantity, price);
            }
            RefreshOrderGrid();
        }

        // Giỏ hiện tại → dict chi_tiet_don cho node orders. "cho" = chờ pha chế (KDS sẽ xử lý).
        private Dictionary<string, OrderItemDTO> BuildItemsDict()
        {
            var items = new Dictionary<string, OrderItemDTO>();
            int i = 1;
            foreach (var (name, (qty, price)) in _orderItems)
            {
                _foodByName.TryGetValue(name, out var f);
                items[$"ctd_{i:000}"] = new OrderItemDTO
                {
                    FoodId = f?.Id,
                    Quantity = qty,
                    UnitPrice = price,
                    Note = "",
                    CookingStatus = "cho"
                };
                i++;
            }
            return items;
        }

        // Nếu mình vừa giữ một bàn (trống → có khách) mà chưa gửi đơn nào thì trả bàn về Trống.
        private async Task ReleaseClaimedTableAsync()
        {
            if (_tableClaimed && _currentTableId != null && _currentOrderId == null)
                try { await TableBUS.Update(_currentTableId, new { trang_thai = "trong" }); } catch { }
            _tableClaimed = false;
        }

        // Chọn bàn từ sơ đồ — có kiểm tra trạng thái + chuyển trạng thái bàn:
        //  · Trống      → giữ bàn (co_khach) và bắt đầu order.
        //  · Đặt trước  → xác nhận khách đã đến rồi mới nhận bàn.
        //  · Có khách   → mở đơn chưa thanh toán của bàn (thêm món / thanh toán),
        //                 hoặc lên đơn mới nếu bàn chưa có đơn.
        private async Task SelectTableAsync(string tid, string tname, string status)
        {
            if (tid == _currentTableId) { ShowOrderTab(); return; }
            var owner = MsgBox.OwnerWindow(this);
            bool hadSentOrder = _currentOrderId != null;

            // Đang có đơn đã gửi bếp ở bàn cũ → không mang đơn đó theo sang bàn mới.
            if (hadSentOrder && MsgBox.Show(owner,
                    $"{_currentTable} đang có đơn đã gửi pha chế (chưa thanh toán).\n" +
                    $"Chuyển sang {tname}? Đơn cũ vẫn giữ ở {_currentTable} — bấm lại bàn đó để mở.",
                    "Đổi bàn", MsgBox.MessageBoxType.Warning) != DialogResult.Yes)
                return;

            try
            {
                switch (status)
                {
                    case "co_khach":
                    {
                        var open = await FindOpenOrderAsync(tid);
                        if (open != null)
                        {
                            int n = open.Value.dto.Items?.Values.Sum(x => x.Quantity) ?? 0;
                            if (MsgBox.Show(owner,
                                    $"{tname} đang có khách với đơn chưa thanh toán ({n} món).\nMở đơn này để thêm món / thanh toán?",
                                    "Bàn có khách", MsgBox.MessageBoxType.Warning) != DialogResult.Yes)
                                return;
                            await ReleaseClaimedTableAsync();
                            LoadOrderIntoCart(open.Value.dto);
                            _currentOrderId = open.Value.id;
                        }
                        else
                        {
                            if (MsgBox.Show(owner,
                                    $"{tname} đang có khách nhưng chưa có đơn.\nLên đơn mới cho bàn này?",
                                    "Bàn có khách", MsgBox.MessageBoxType.Warning) != DialogResult.Yes)
                                return;
                            await ReleaseClaimedTableAsync();
                            if (hadSentOrder) _orderItems.Clear();
                            _currentOrderId = null;
                        }
                        _tableClaimed = false;
                        break;
                    }
                    case "dat_truoc":
                        if (MsgBox.Show(owner,
                                $"{tname} đã được ĐẶT TRƯỚC.\nXác nhận khách đặt bàn đã đến và nhận bàn?",
                                "Bàn đặt trước", MsgBox.MessageBoxType.Warning) != DialogResult.Yes)
                            return;
                        await ReleaseClaimedTableAsync();
                        if (hadSentOrder) _orderItems.Clear();
                        try { await TableBUS.Update(tid, new { trang_thai = "co_khach" }); } catch { }
                        _currentOrderId = null;
                        _tableClaimed = true;
                        break;
                    default: // trống — giỏ đang chọn (chưa gửi) đi theo bàn mới
                        await ReleaseClaimedTableAsync();
                        if (hadSentOrder) _orderItems.Clear();
                        try { await TableBUS.Update(tid, new { trang_thai = "co_khach" }); } catch { }
                        _currentOrderId = null;
                        _tableClaimed = true;
                        break;
                }
            }
            catch
            {
                MsgBox.Show(owner, "Không cập nhật được trạng thái bàn (kiểm tra server).", "Lỗi", MsgBox.MessageBoxType.Error);
                return;
            }

            _currentTableId = tid;
            _currentTable = tname;
            _tableMapSig = "";        // vẽ lại sơ đồ với trạng thái + highlight mới
            RefreshOrderGrid();
            UpdateTableLabels();
            ShowOrderTab();
        }

        // =========================================================================
        //  GỬI PHA CHẾ / THANH TOÁN / HỦY ĐƠN
        // =========================================================================

        // Gửi đơn cho quầy pha chế (KDS): tạo đơn "pending" (hoặc cập nhật món nếu gửi bổ sung).
        // Đây là bước đưa đơn vào luồng Order → Barista; thanh toán có thể làm sau.
        private async void BtnSendKitchen_Click(object? sender, EventArgs e)
        {
            var owner = MsgBox.OwnerWindow(this);
            if (_orderItems.Count == 0)
            {
                MsgBox.Show(owner, "Chưa có món nào để gửi pha chế.", "Thông báo", MsgBox.MessageBoxType.Warning);
                return;
            }

            btnSendKitchen.Enabled = false;
            try
            {
                var items = BuildItemsDict();
                int soMon = _orderItems.Sum(kv => kv.Value.qty);

                if (_currentOrderId == null)
                {
                    var order = new OrderDTO
                    {
                        TableId    = _currentTableId,
                        EmployeeId = GlobalSession.CurrentUser?.EmployeeId,
                        CreatedAt  = DateTimeOffset.Now.ToUnixTimeMilliseconds(),
                        Status     = "pending",
                        Note       = "",
                        Source     = "pos",
                        Items      = items
                    };
                    var (ok, msg, id) = await OrderBUS.Add(order);
                    if (!ok || id == null)
                    {
                        MsgBox.Show(owner, $"Không gửi được đơn: {msg}", "Lỗi", MsgBox.MessageBoxType.Error);
                        return;
                    }
                    _currentOrderId = id;
                    if (_currentTableId != null)
                    {
                        try { await TableBUS.Update(_currentTableId, new { trang_thai = "co_khach" }); } catch { }
                        _tableClaimed = true;
                        _tableMapSig = "";
                    }
                    MsgBox.Show(owner, $"Đã gửi {soMon} món tới quầy pha chế — {_currentTable}.",
                                "Đã gửi pha chế", MsgBox.MessageBoxType.Success);
                }
                else
                {
                    // Gửi bổ sung: thay toàn bộ chi_tiet_don + đưa đơn về hàng chờ để pha chế thấy món mới.
                    var (ok, msg) = await OrderBUS.Update(_currentOrderId, new { chi_tiet_don = items, trang_thai = "pending" });
                    if (ok)
                        MsgBox.Show(owner, "Đã cập nhật đơn — quầy pha chế sẽ thấy các món mới.",
                                    "Đã gửi bổ sung", MsgBox.MessageBoxType.Success);
                    else
                        MsgBox.Show(owner, $"Không cập nhật được đơn: {msg}", "Lỗi", MsgBox.MessageBoxType.Error);
                }
                UpdateTableLabels();
            }
            finally { btnSendKitchen.Enabled = true; }
        }

        private async void BtnPay_Click(object? sender, EventArgs e)
        {
            if (_orderItems.Count == 0)
            {
                MsgBox.Show(MsgBox.OwnerWindow(this), "Đơn hàng trống! Vui lòng chọn món trước.", "Thông báo", MsgBox.MessageBoxType.Warning);
                return;
            }

            long subtotal = _orderItems.Sum(kv => kv.Value.qty * kv.Value.price);
            long discount = AppMath.ParseVndDigits(txtDiscount.Text);
            long total = AppMath.OrderTotal(subtotal, discount);

            string customer = "Khách lẻ";
            bool paid = PaymentDialog.Pay(MsgBox.OwnerWindow(this), total, _currentTable, customer, out string method);
            if (!paid) return;

            // Lưu đơn hàng + phiếu thanh toán lên Firebase (qua backend), trả bàn về Trống
            btnPay.Enabled = false;
            string? savedId;
            try { savedId = await PersistOrderAndPayment(subtotal, discount, total, method); }
            finally { btnPay.Enabled = true; }

            if (savedId == null)
                MsgBox.Show(MsgBox.OwnerWindow(this),
                    "Không lưu được đơn lên server (kiểm tra kết nối) — hóa đơn chỉ hiển thị cục bộ.",
                    "Cảnh báo", MsgBox.MessageBoxType.Error);

            string orderId = savedId ?? $"HD{DateTime.Now:yyyyMMddHHmm}{_orderItems.Count:00}";
            ShowReceipt(orderId, total, method);
            ResetAfterPayment();
        }

        // Lưu đơn + thanh toán; trả về mã đơn nếu thành công (null nếu offline/lỗi).
        //  · Đơn đã gửi pha chế: chỉ đồng bộ món lần cuối, KHÔNG đụng trạng thái (bếp quản lý).
        //  · Chưa gửi (bán nhanh/mang đi): tạo đơn "pending" để pha chế vẫn nhận được món.
        private async Task<string?> PersistOrderAndPayment(long subtotal, long discount, long total, string methodDisplay)
        {
            try
            {
                var items = BuildItemsDict();
                string? orderId = _currentOrderId;

                if (orderId == null)
                {
                    var order = new OrderDTO
                    {
                        TableId    = _currentTableId,
                        EmployeeId = GlobalSession.CurrentUser?.EmployeeId,
                        CreatedAt  = DateTimeOffset.Now.ToUnixTimeMilliseconds(),
                        Status     = "pending",
                        Note       = "",
                        Source     = "pos",
                        Items      = items
                    };
                    var (ok, _, newId) = await OrderBUS.Add(order);
                    if (!ok || newId == null) return null;
                    orderId = newId;
                }
                else
                {
                    await OrderBUS.Update(orderId, new { chi_tiet_don = items });
                }

                var payment = new PaymentDTO
                {
                    OrderId = orderId,
                    EmployeeId = GlobalSession.CurrentUser?.EmployeeId,
                    Method = MapMethod(methodDisplay),
                    Timestamp = DateTimeOffset.Now.ToUnixTimeMilliseconds(),
                    TotalAmount = subtotal,
                    Discount = discount,
                    ActualReceived = total
                };
                var (pok, _, _) = await PaymentBUS.Add(payment);
                if (!pok) return null;

                // Bàn được giải phóng sau khi thanh toán → mọi sơ đồ bàn (POS/QL) thấy Trống
                if (!string.IsNullOrEmpty(_currentTableId))
                    await TableBUS.Update(_currentTableId, new { trang_thai = "trong" });

                return orderId;
            }
            catch { return null; }
        }

        private void ResetAfterPayment()
        {
            _orderItems.Clear();
            RefreshOrderGrid();
            txtDiscount.Clear();
            lblTotalAmount.Text = "0 đ";
            _currentOrderId = null;
            _currentTableId = null;
            _currentTable = "Mang đi";
            _tableClaimed = false;
            _tableMapSig = "";
            UpdateTableLabels();
        }

        private static string MapMethod(string display) => display switch
        {
            "Tiền mặt" => "tien_mat",
            "Thẻ" => "the",
            "VietQR" => "vietqr",
            _ => "tien_mat"
        };

        // Hủy đơn: nếu đã gửi pha chế thì chuyển đơn sang "huy" (KDS tự bỏ), và hỏi trả bàn về Trống.
        private async void BtnVoidOrder_Click(object? sender, EventArgs e)
        {
            var owner = MsgBox.OwnerWindow(this);
            if (_orderItems.Count == 0 && _currentOrderId == null)
            {
                MsgBox.Show(owner, "Không có đơn nào để hủy.", "Thông báo", MsgBox.MessageBoxType.Info);
                return;
            }

            string? reason = InputDialog.Show(owner, "Hủy đơn hàng", "Lý do hủy (bắt buộc)", "VD: Khách đổi ý...");
            if (string.IsNullOrEmpty(reason)) return;

            if (_currentOrderId != null)
            {
                var (ok, msg) = await OrderBUS.Update(_currentOrderId, new { trang_thai = "huy", ghi_chu = $"Hủy: {reason}" });
                if (!ok)
                {
                    MsgBox.Show(owner, $"Không hủy được đơn trên server: {msg}", "Lỗi", MsgBox.MessageBoxType.Error);
                    return;
                }
            }

            if (_currentTableId != null &&
                MsgBox.Show(owner, $"Trả {_currentTable} về trạng thái Trống?", "Trả bàn", MsgBox.MessageBoxType.Warning) == DialogResult.Yes)
            {
                try { await TableBUS.Update(_currentTableId, new { trang_thai = "trong" }); } catch { }
            }

            _orderItems.Clear();
            RefreshOrderGrid();
            txtDiscount.Clear();
            lblTotalAmount.Text = "0 đ";
            _currentOrderId = null;
            _currentTableId = null;
            _currentTable = "Mang đi";
            _tableClaimed = false;
            _tableMapSig = "";
            UpdateTableLabels();
            MsgBox.Show(owner, $"Đã hủy đơn. Lý do: {reason}", "Hủy đơn thành công", MsgBox.MessageBoxType.Info);
        }

        // =========================================================================
        //  CÁC TAB
        // =========================================================================

        private void ShowOrderTab()
        {
            SetActiveTab(btnTabOrder);
            SwapTabContent(pnlCenterMenu);
        }

        // Gỡ nội dung tab cũ và dispose (Controls.Clear KHÔNG dispose → rò handle);
        // riêng pnlCenterMenu (tab Order) được dùng lại nên không dispose.
        private void SwapTabContent(Control content)
        {
            for (int i = pnlMainTabContainer.Controls.Count - 1; i >= 0; i--)
            {
                var c = pnlMainTabContainer.Controls[i];
                pnlMainTabContainer.Controls.RemoveAt(i);
                if (c != pnlCenterMenu && c != content) c.Dispose();
            }
            pnlMainTabContainer.Controls.Add(content);
        }

        private void SetActiveTab(Guna2Button activeBtn)
        {
            // Đổi CẢ nền: tab đang mở = nền teal, tab khác = nền tối. Trước đây chỉ đổi
            // ForeColor nên nền tĩnh của Designer (Order luôn teal) làm tab active nhìn
            // "không cập nhật" khi bấm sang tab khác.
            var teal = Color.FromArgb(31, 138, 154);
            var dark = Color.FromArgb(31, 31, 34);
            foreach (var b in new[] { btnTabOrder, btnTabTables, btnTabHistory })
            {
                bool active = b == activeBtn;
                b.FillColor = active ? teal : dark;
                b.ForeColor = Color.White;
                b.HoverState.FillColor = active ? teal : Color.FromArgb(45, 45, 48);
            }
        }

        // ----- Tab SƠ ĐỒ BÀN: layout dock (giãn hết không gian khi phóng to) + tự làm mới -----
        private async void btnTabTables_Click(object sender, EventArgs e)
        {
            SetActiveTab(btnTabTables);

            var host = new Panel { Dock = DockStyle.Fill, BackColor = Color.Transparent, Padding = new Padding(12) };

            // Sơ đồ bàn chiếm toàn bộ phần còn lại (thẻ tự reflow theo bề rộng thật).
            var flp = new FlowLayoutPanel { Dock = DockStyle.Fill, BackColor = Color.Transparent, AutoScroll = true };
            host.Controls.Add(flp);

            // Thanh thao tác bàn (trên cùng)
            var topWrap = new Panel { Dock = DockStyle.Top, Height = 56, BackColor = Color.Transparent, Padding = new Padding(0, 0, 0, 12) };
            var actionBar = new Guna2Panel { Dock = DockStyle.Fill, FillColor = Theme.Surface, BorderRadius = 10 };
            actionBar.Controls.Add(new Label { Text = "Thao tác nâng cao:", AutoSize = true, Font = Theme.F(9F), ForeColor = Theme.TextMuted, Location = new Point(8, 13), BackColor = Color.Transparent });

            var btnMerge     = MakeActionBtn("Gộp bàn",    Theme.Blue,   120);
            var btnSplit     = MakeActionBtn("Tách bàn",   Theme.Amber,  220);
            var btnTransfer  = MakeActionBtn("Chuyển bàn", Theme.Purple, 320);
            var btnSplitBill = MakeActionBtn("Tách HĐ",    Theme.Green,  420);
            btnMerge.Click     += async (s2, e2) => await MergeTableAsync();
            btnSplit.Click     += async (s2, e2) => await SplitTableAsync();
            btnTransfer.Click  += async (s2, e2) => await TransferTableAsync();
            btnSplitBill.Click += (s2, e2) => ShowSplitBillDialog();
            actionBar.Controls.Add(btnMerge);
            actionBar.Controls.Add(btnSplit);
            actionBar.Controls.Add(btnTransfer);
            actionBar.Controls.Add(btnSplitBill);
            topWrap.Controls.Add(actionBar);
            host.Controls.Add(topWrap);

            var legend = new Label
            {
                Dock = DockStyle.Bottom,
                Height = 26,
                Text = "🔴 Có khách   🟡 Đặt trước   ⬛ Trống   — Click để chọn bàn (viền teal = bàn đang order)",
                Font = Theme.F(8.5F),
                ForeColor = Theme.TextMuted,
                BackColor = Color.Transparent,
                TextAlign = ContentAlignment.MiddleLeft,
            };
            host.Controls.Add(legend);

            _tableMapFlp = flp;
            SwapTabContent(host);
            // Sơ đồ bàn (flp AutoScroll) tạo động SAU khi UC đã AttachAll lúc mở màn →
            // phải theme lại thanh cuộn cho nó (ẩn thanh trắng, thay bằng thanh teal fade).
            AutoFadeScroll.AttachAll(pnlMainTabContainer);

            await ReloadTableMap(flp, force: true);
        }

        // Nạp sơ đồ bàn từ Firebase; chữ ký trạng thái tránh vẽ lại khi không đổi
        // (poll 7s không gây giật/mất hover). force = true: luôn vẽ lại.
        private async Task ReloadTableMap(FlowLayoutPanel flp, bool force)
        {
            if (_mapLoading) return;
            _mapLoading = true;
            try
            {
                Dictionary<string, TableDTO> tables;
                try { tables = await TableBUS.GetAll(); }
                catch { tables = new(); }
                if (flp.IsDisposed) return;

                string sig = string.Join("|", tables.OrderBy(t => t.Key).Select(t => $"{t.Key}:{t.Value.Status}"))
                           + "#" + _currentTableId;
                if (!force && sig == _tableMapSig) return;
                _tableMapSig = sig;

                flp.SuspendLayout();
                for (int i = flp.Controls.Count - 1; i >= 0; i--)
                {
                    var c = flp.Controls[i];
                    flp.Controls.RemoveAt(i);
                    c.Dispose();
                }

                if (tables.Count == 0)
                {
                    flp.Controls.Add(new Label { Text = "Chưa có dữ liệu bàn.", AutoSize = true, Font = Theme.F(9F), ForeColor = Theme.TextMuted });
                }
                else
                {
                    foreach (var kv in tables.OrderBy(t => t.Key))
                        flp.Controls.Add(CreateTableCard(kv.Key, kv.Value));
                }
                flp.ResumeLayout();
            }
            finally { _mapLoading = false; }
        }

        private Guna2Panel CreateTableCard(string tid, TableDTO table)
        {
            string status = table.Status ?? "trong";
            (Color accent, string label) = status switch
            {
                "co_khach"  => (Theme.Red, "Có khách"),
                "dat_truoc" => (Theme.Amber, "Đặt trước"),
                _           => (Theme.Green, "Trống"),
            };
            bool free = status == "trong";
            bool isCurrent = tid == _currentTableId;

            var card = new Guna2Panel
            {
                FillColor       = free ? Theme.Surface : Theme.Fade(accent, 60),
                BorderRadius    = 10,
                Size            = new Size(104, 86),
                Margin          = new Padding(5),
                Cursor          = Cursors.Hand,
                BorderColor     = isCurrent ? Theme.Teal : accent,
                BorderThickness = isCurrent ? 2 : 1,
            };
            card.Controls.Add(new Label
            {
                Text      = table.Name ?? tid,
                Font      = Theme.F(10F, FontStyle.Bold),
                ForeColor = isCurrent ? Theme.Teal : (free ? Theme.TextHi : accent),
                BackColor = Color.Transparent,
                Location  = new Point(8, 12),
                AutoSize  = true,
            });
            card.Controls.Add(new Label
            {
                Text      = isCurrent ? "Đang order" : label,
                Font      = Theme.F(8F),
                ForeColor = isCurrent ? Theme.Teal : accent,
                BackColor = Color.Transparent,
                Location  = new Point(8, 40),
                AutoSize  = true,
            });
            card.Controls.Add(new Label
            {
                Text      = $"{table.Capacity} chỗ · {table.Location}",
                Font      = Theme.F(7F),
                ForeColor = Theme.TextMuted,
                BackColor = Color.Transparent,
                Location  = new Point(8, 62),
                AutoSize  = true,
            });

            string tname = table.Name ?? tid;
            async void OnClick(object? s2, EventArgs e2)
            {
                try { await SelectTableAsync(tid, tname, status); }
                catch { }
            }
            card.Click += OnClick;
            foreach (Control child in card.Controls) child.Click += OnClick;   // label phủ gần hết thẻ
            return card;
        }

        private static Guna2Button MakeActionBtn(string text, Color color, int x)
        {
            var b = new Guna2Button
            {
                Text         = text,
                Font         = Theme.F(8.5F, FontStyle.Bold),
                FillColor    = Theme.Fade(color, 40),
                ForeColor    = Theme.Lighten(color, 20),
                BorderRadius = 8,
                Cursor       = Cursors.Hand,
                Size         = new Size(94, 30),
                Location     = new Point(x, 7),
            };
            b.HoverState.FillColor = Theme.Fade(color, 70);
            return b;
        }

        // =========================================================================
        //  THAO TÁC NÂNG CAO TRÊN BÀN (làm thật trên node tables/orders)
        // =========================================================================

        // Dialog chọn 1 bàn theo điều kiện (bàn trống để chuyển/tách, bàn có khách để gộp...).
        private async Task<(string tid, string tname)?> PickTableAsync(string title, Func<TableDTO, bool> filter, string? excludeId = null)
        {
            var owner = MsgBox.OwnerWindow(this);
            Dictionary<string, TableDTO> tables;
            try { tables = await TableBUS.GetAll(); }
            catch { tables = new(); }

            var choices = tables.Where(kv => kv.Key != excludeId && filter(kv.Value))
                                .OrderBy(kv => kv.Key)
                                .ToList();
            if (choices.Count == 0)
            {
                MsgBox.Show(owner, "Không có bàn phù hợp.", "Thông báo", MsgBox.MessageBoxType.Info);
                return null;
            }

            var frm = WindowChrome.CreateDialog(title, new Size(480, 400), out var content, owner);
            var flp = new FlowLayoutPanel { Dock = DockStyle.Fill, AutoScroll = true, BackColor = Color.Transparent, Padding = new Padding(12) };
            content.Controls.Add(flp);
            AutoFadeScroll.AttachAll(content);

            (string, string)? result = null;
            foreach (var kv in choices)
            {
                string tname = kv.Value.Name ?? kv.Key;
                bool free = (kv.Value.Status ?? "trong") == "trong";
                var accent = free ? Theme.Green : Theme.Red;
                var b = new Guna2Button
                {
                    Text         = $"{tname}\n{kv.Value.Capacity} chỗ · {kv.Value.Location}",
                    Font         = Theme.F(9F, FontStyle.Bold),
                    FillColor    = Theme.Fade(accent, 40),
                    ForeColor    = Theme.Lighten(accent, 30),
                    BorderRadius = 10,
                    Size         = new Size(136, 62),
                    Margin       = new Padding(5),
                    Cursor       = Cursors.Hand,
                };
                b.HoverState.FillColor = Theme.Fade(accent, 80);
                string tid = kv.Key;
                b.Click += (s, e) => { result = (tid, tname); frm.DialogResult = DialogResult.OK; frm.Close(); };
                flp.Controls.Add(b);
            }
            frm.ShowDialog(owner);
            return result;
        }

        // CHUYỂN BÀN: dời đơn/khách của bàn hiện tại sang một bàn trống.
        private async Task TransferTableAsync()
        {
            var owner = MsgBox.OwnerWindow(this);
            if (_currentTableId == null)
            {
                MsgBox.Show(owner, "Chưa chọn bàn hiện tại — bấm vào một bàn trên sơ đồ trước.", "Chuyển bàn", MsgBox.MessageBoxType.Warning);
                return;
            }
            var target = await PickTableAsync("Chuyển bàn — chọn bàn đích (trống)", t => (t.Status ?? "trong") == "trong");
            if (target == null) return;

            string oldName = _currentTable, oldId = _currentTableId;
            try
            {
                if (_currentOrderId != null)
                    await OrderBUS.Update(_currentOrderId, new { ban_id = target.Value.tid });
                await TableBUS.Update(target.Value.tid, new { trang_thai = "co_khach" });
                await TableBUS.Update(oldId, new { trang_thai = "trong" });
            }
            catch
            {
                MsgBox.Show(owner, "Không chuyển được bàn (kiểm tra server).", "Lỗi", MsgBox.MessageBoxType.Error);
                return;
            }

            _currentTableId = target.Value.tid;
            _currentTable = target.Value.tname;
            _tableClaimed = true;
            _tableMapSig = "";
            UpdateTableLabels();
            if (_tableMapFlp is { IsDisposed: false } flp) await ReloadTableMap(flp, force: true);
            MsgBox.Show(owner, $"Đã chuyển {oldName} → {target.Value.tname}.", "Chuyển bàn", MsgBox.MessageBoxType.Success);
        }

        // GỘP BÀN: dồn đơn chưa thanh toán của một bàn khác vào bàn hiện tại; bàn nguồn về Trống.
        private async Task MergeTableAsync()
        {
            var owner = MsgBox.OwnerWindow(this);
            if (_currentTableId == null)
            {
                MsgBox.Show(owner, "Chưa chọn bàn hiện tại (bàn sẽ nhận đơn gộp) — bấm vào một bàn trước.", "Gộp bàn", MsgBox.MessageBoxType.Warning);
                return;
            }
            var src = await PickTableAsync("Gộp bàn — chọn bàn nguồn (có khách)", t => t.Status == "co_khach", excludeId: _currentTableId);
            if (src == null) return;

            var open = await FindOpenOrderAsync(src.Value.tid);
            if (open == null)
            {
                MsgBox.Show(owner, $"{src.Value.tname} không có đơn chưa thanh toán để gộp.", "Gộp bàn", MsgBox.MessageBoxType.Info);
                return;
            }

            // Cộng món của bàn nguồn vào giỏ hiện tại
            foreach (var it in open.Value.dto.Items?.Values ?? Enumerable.Empty<OrderItemDTO>())
            {
                string name = (it.FoodId != null && _foodById.TryGetValue(it.FoodId, out var f))
                    ? (f.Name ?? it.FoodId) : (it.FoodId ?? "Món");
                long price = (long)it.UnitPrice;
                if (_orderItems.TryGetValue(name, out var cur)) _orderItems[name] = (cur.qty + it.Quantity, price);
                else _orderItems[name] = (it.Quantity, price);
            }
            RefreshOrderGrid();

            try
            {
                if (_currentOrderId == null)
                {
                    // Nhận luôn đơn của bàn nguồn làm đơn của bàn này (kèm món đang có trong giỏ)
                    await OrderBUS.Update(open.Value.id, new { ban_id = _currentTableId, chi_tiet_don = BuildItemsDict() });
                    _currentOrderId = open.Value.id;
                }
                else
                {
                    await OrderBUS.Update(_currentOrderId, new { chi_tiet_don = BuildItemsDict(), trang_thai = "pending" });
                    await OrderBUS.Update(open.Value.id, new { trang_thai = "huy", ghi_chu = $"Gộp vào {_currentTable}" });
                }
                await TableBUS.Update(src.Value.tid, new { trang_thai = "trong" });
                await TableBUS.Update(_currentTableId, new { trang_thai = "co_khach" });
                _tableClaimed = true;
            }
            catch
            {
                MsgBox.Show(owner, "Không gộp được bàn (kiểm tra server).", "Lỗi", MsgBox.MessageBoxType.Error);
                return;
            }

            _tableMapSig = "";
            UpdateTableLabels();
            if (_tableMapFlp is { IsDisposed: false } flp) await ReloadTableMap(flp, force: true);
            MsgBox.Show(owner, $"Đã gộp {src.Value.tname} vào {_currentTable}.", "Gộp bàn", MsgBox.MessageBoxType.Success);
        }

        // TÁCH BÀN: chuyển một phần món của bàn hiện tại sang bàn trống khác (tạo đơn mới cho bàn đó).
        private async Task SplitTableAsync()
        {
            var owner = MsgBox.OwnerWindow(this);
            if (_orderItems.Count == 0)
            {
                MsgBox.Show(owner, "Giỏ hàng trống — không có món để tách bàn.", "Tách bàn", MsgBox.MessageBoxType.Warning);
                return;
            }
            var target = await PickTableAsync("Tách bàn — chọn bàn đích (trống)", t => (t.Status ?? "trong") == "trong", excludeId: _currentTableId);
            if (target == null) return;

            var moved = PickItemsDialog($"Tách món sang {target.Value.tname}",
                                        "Tick + nhập SL tách. Phần còn lại ở lại bàn hiện tại.");
            if (moved == null || moved.Count == 0) return;

            // Tạo đơn mới cho bàn đích (vào thẳng hàng chờ pha chế)
            var items2 = new Dictionary<string, OrderItemDTO>();
            int i = 1;
            foreach (var (name, (qty, price)) in moved)
            {
                _foodByName.TryGetValue(name, out var f);
                items2[$"ctd_{i:000}"] = new OrderItemDTO { FoodId = f?.Id, Quantity = qty, UnitPrice = price, Note = "", CookingStatus = "cho" };
                i++;
            }
            var order2 = new OrderDTO
            {
                TableId    = target.Value.tid,
                EmployeeId = GlobalSession.CurrentUser?.EmployeeId,
                CreatedAt  = DateTimeOffset.Now.ToUnixTimeMilliseconds(),
                Status     = "pending",
                Note       = $"Tách từ {_currentTable}",
                Source     = "pos",
                Items      = items2
            };

            try
            {
                var (ok, msg, id2) = await OrderBUS.Add(order2);
                if (!ok || id2 == null)
                {
                    MsgBox.Show(owner, $"Không tạo được đơn cho bàn đích: {msg}", "Lỗi", MsgBox.MessageBoxType.Error);
                    return;
                }
                await TableBUS.Update(target.Value.tid, new { trang_thai = "co_khach" });

                // Trừ món đã tách khỏi giỏ hiện tại
                foreach (var (name, (qty, _)) in moved)
                {
                    if (!_orderItems.TryGetValue(name, out var cur)) continue;
                    if (qty >= cur.qty) _orderItems.Remove(name);
                    else _orderItems[name] = (cur.qty - qty, cur.price);
                }

                if (_orderItems.Count == 0)
                {
                    // Tách hết → bàn cũ trống, chuyển sang theo dõi bàn đích
                    if (_currentOrderId != null)
                        await OrderBUS.Update(_currentOrderId, new { trang_thai = "huy", ghi_chu = $"Tách toàn bộ sang {target.Value.tname}" });
                    if (_currentTableId != null)
                        try { await TableBUS.Update(_currentTableId, new { trang_thai = "trong" }); } catch { }
                    _currentOrderId = id2;
                    _currentTableId = target.Value.tid;
                    _currentTable = target.Value.tname;
                    _tableClaimed = true;
                    foreach (var (name, v) in moved) _orderItems[name] = v;
                }
                else if (_currentOrderId != null)
                {
                    await OrderBUS.Update(_currentOrderId, new { chi_tiet_don = BuildItemsDict() });
                }
            }
            catch
            {
                MsgBox.Show(owner, "Không tách được bàn (kiểm tra server).", "Lỗi", MsgBox.MessageBoxType.Error);
                return;
            }

            RefreshOrderGrid();
            _tableMapSig = "";
            UpdateTableLabels();
            if (_tableMapFlp is { IsDisposed: false } flp) await ReloadTableMap(flp, force: true);
            long movedTotal = moved.Sum(kv => kv.Value.qty * kv.Value.price);
            MsgBox.Show(owner, $"Đã tách {moved.Sum(kv => kv.Value.qty)} món sang {target.Value.tname} ({Theme.Vnd(movedTotal)}).",
                        "Tách bàn", MsgBox.MessageBoxType.Success);
        }

        // ----- Tab LỊCH SỬ -----
        private async void btnTabHistory_Click(object sender, EventArgs e)
        {
            SetActiveTab(btnTabHistory);

            var dgv = new Guna2DataGridView { Dock = DockStyle.Fill };
            Theme.StyleGrid(dgv);
            dgv.BindingContext = new BindingContext();

            var dt = new DataTable();
            dt.Columns.Add("Mã đơn");
            dt.Columns.Add("Thời gian");
            dt.Columns.Add("Bàn");
            dt.Columns.Add("Số món", typeof(int));
            dt.Columns.Add("Tổng tiền", typeof(long));
            dt.Columns.Add("Hình thức TT");
            dt.Columns.Add("NV Order");
            dgv.AutoGenerateColumns = true;
            dgv.DataSource = dt;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.Columns["Tổng tiền"].DefaultCellStyle.Format    = "N0";
            dgv.Columns["Tổng tiền"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            SwapTabContent(dgv);
            // Lưới lịch sử tạo động → theme lại thanh cuộn (ẩn thanh trắng, thay teal fade).
            AutoFadeScroll.AttachAll(pnlMainTabContainer);

            try
            {
                var payments = await PaymentBUS.GetAll();
                var orders   = await OrderBUS.GetAll();
                var tables   = await TableBUS.GetAll();
                var emps     = (await EmployeeBUS.GetAllEmployeesAsync())
                                .ToDictionary(x => x.EmployeeId ?? "", x => x.FullName ?? "");

                foreach (var p in payments.Values.OrderByDescending(x => x.Timestamp))
                {
                    orders.TryGetValue(p.OrderId ?? "", out var ord);
                    string tableName = "Mang đi";
                    if (ord?.TableId != null && tables.TryGetValue(ord.TableId, out var tb))
                        tableName = tb.Name ?? ord.TableId;
                    int itemCount = ord?.Items?.Values.Sum(it => it.Quantity) ?? 0;
                    string time = p.Timestamp > 0
                        ? DateTimeOffset.FromUnixTimeMilliseconds(p.Timestamp).LocalDateTime.ToString("HH:mm dd/MM")
                        : "";
                    string nv = emps.TryGetValue(p.EmployeeId ?? "", out var n) ? n : (p.EmployeeId ?? "");
                    dt.Rows.Add(p.OrderId, time, tableName, itemCount, (long)p.ActualReceived, MethodDisplay(p.Method), nv);
                }
                if (dt.Rows.Count == 0)
                    dt.Rows.Add("", "Chưa có hóa đơn nào", "", 0, 0L, "", "");
            }
            catch
            {
                dt.Rows.Add("", "Không tải được lịch sử (kiểm tra server)", "", 0, 0L, "", "");
            }
        }

        private static string MethodDisplay(string? code) => code switch
        {
            "tien_mat" => "Tiền mặt",
            "the" => "Thẻ",
            "vietqr" => "VietQR",
            "momo" => "Momo",
            "chuyen_khoan" => "Chuyển khoản",
            _ => code ?? ""
        };

        // BÁO CÁO: số liệu bán hàng THẬT trong ngày từ node payments/orders.
        private async void BtnReport_Click(object? sender, EventArgs e)
        {
            var owner = MsgBox.OwnerWindow(this);
            try
            {
                var payments = await PaymentBUS.GetAll();
                var orders   = await OrderBUS.GetAll();
                var today = DateTime.Today;

                var todays = payments.Values
                    .Where(p => p.Timestamp > 0 &&
                                DateTimeOffset.FromUnixTimeMilliseconds(p.Timestamp).LocalDateTime.Date == today)
                    .ToList();
                long revenue = todays.Sum(p => (long)p.ActualReceived);
                var byMethod = todays.GroupBy(p => MethodDisplay(p.Method))
                                     .Select(g => $"    – {g.Key}: {Theme.Vnd(g.Sum(x => (long)x.ActualReceived))} ({g.Count()} HĐ)");
                int active = orders.Values.Count(o => o.Status == "pending" || o.Status == "dang_phuc_vu");

                string report =
                    $"BÁO CÁO BÁN HÀNG — {today:dd/MM/yyyy}\n" +
                    "──────────────────\n" +
                    $"• Hóa đơn hôm nay: {todays.Count}\n" +
                    $"• Doanh thu: {Theme.Vnd(revenue)}\n" +
                    (todays.Count > 0 ? string.Join("\n", byMethod) + "\n" : "") +
                    $"• Đơn đang chờ / đang pha chế: {active}";

                MsgBox.Show(owner, report, "Báo cáo POS", MsgBox.MessageBoxType.Info);
            }
            catch
            {
                MsgBox.Show(owner, "Không tải được dữ liệu báo cáo (kiểm tra server).", "Lỗi", MsgBox.MessageBoxType.Error);
            }
        }

        // Hiển thị hóa đơn sau khi thanh toán + mã QR feedback độc nhất theo orderId
        private void ShowReceipt(string orderId, long total, string method)
        {
            var frm = WindowChrome.CreateDialog($"Hóa đơn {orderId}", new Size(440, 560),
                                                out var content, MsgBox.OwnerWindow(this));

            content.Controls.Add(new Label { Text = "☕  QUÁN CÀ PHÊ NHÓM 2", AutoSize = true, Font = Theme.F(13F, FontStyle.Bold), ForeColor = Theme.TextHi, Location = new Point(20, 16), BackColor = Color.Transparent });
            content.Controls.Add(new Label { Text = $"Mã HĐ: {orderId}", AutoSize = true, Font = Theme.F(9.5F, FontStyle.Bold), ForeColor = Theme.Teal, Location = new Point(20, 48), BackColor = Color.Transparent });
            content.Controls.Add(new Label { Text = $"Bàn: {_currentTable}   ·   {DateTime.Now:HH:mm dd/MM/yyyy}", AutoSize = true, Font = Theme.F(9F), ForeColor = Theme.TextPri, Location = new Point(20, 68), BackColor = Color.Transparent });
            content.Controls.Add(new Label { Text = $"Nhân viên: {GlobalSession.CurrentUser?.FullName ?? "Staff"}   ·   {method}", AutoSize = true, Font = Theme.F(9F), ForeColor = Theme.TextMuted, Location = new Point(20, 88), BackColor = Color.Transparent });

            var dgv = new Guna2DataGridView { Location = new Point(16, 112), Size = new Size(400, 166) };
            Theme.StyleGrid(dgv);
            dgv.BindingContext = new BindingContext();   // sinh cột ngay khi bind (lưới chưa gắn parent)
            var dtItems = new DataTable();
            dtItems.Columns.Add("Món");
            dtItems.Columns.Add("SL", typeof(int));
            dtItems.Columns.Add("Đơn giá", typeof(long));
            dtItems.Columns.Add("Thành tiền", typeof(long));
            foreach (var (name, (qty, price)) in _orderItems)
                dtItems.Rows.Add(name, qty, price, qty * price);
            dgv.AutoGenerateColumns = true;   // StyleGrid tắt auto-gen; lưới tạo trong code cần bật lại để sinh cột từ DataTable
            dgv.DataSource = dtItems;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.Columns["Đơn giá"].DefaultCellStyle.Format    = "N0";
            dgv.Columns["Đơn giá"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv.Columns["Thành tiền"].DefaultCellStyle.Format    = "N0";
            dgv.Columns["Thành tiền"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            content.Controls.Add(dgv);

            content.Controls.Add(new Label { Text = $"TỔNG CỘNG:  {Theme.Vnd(total)}", AutoSize = true, Font = Theme.F(11F, FontStyle.Bold), ForeColor = Theme.TextHi, Location = new Point(20, 286), BackColor = Color.Transparent });
            content.Controls.Add(new Label { Text = "Quét QR để đánh giá dịch vụ:", AutoSize = true, Font = Theme.F(9F), ForeColor = Theme.TextMuted, Location = new Point(20, 310), BackColor = Color.Transparent });

            var pnlQR = new Panel { Location = new Point(144, 336), Size = new Size(140, 140), BackColor = Color.White };
            pnlQR.Paint += (s, e) => DrawFeedbackQR(e.Graphics, orderId, 140);
            content.Controls.Add(pnlQR);

            content.Controls.Add(new Label { Text = $"cafe.vn/feedback?order={orderId}", AutoSize = true, Font = Theme.F(7.5F), ForeColor = Theme.TextMuted, Location = new Point(96, 482), BackColor = Color.Transparent });

            var btnClose = Theme.PrimaryButton("Đóng");
            btnClose.Size     = new Size(110, 36);
            btnClose.Location = new Point(310, 480);
            btnClose.Click   += (s, e) => frm.Close();
            content.Controls.Add(btnClose);

            frm.ShowDialog(MsgBox.OwnerWindow(this));
        }

        private static void DrawFeedbackQR(Graphics g, string seed, int size)
        {
            g.Clear(Color.White);
            int cell = size / 21;
            var rng = new System.Random(seed.GetHashCode() ^ 0x3A7F9C);
            using var b = new SolidBrush(Color.Black);
            DrawQRFinder(g, b, cell, 0, 0);
            DrawQRFinder(g, b, cell, 14, 0);
            DrawQRFinder(g, b, cell, 0, 14);
            for (int row = 0; row < 21; row++)
            {
                for (int col = 0; col < 21; col++)
                {
                    if ((row < 8 && col < 8) || (row < 8 && col >= 13) || (row >= 13 && col < 8))
                        continue;
                    if (rng.Next(2) == 1)
                        g.FillRectangle(b, col * cell, row * cell, cell, cell);
                }
            }
        }

        private static void DrawQRFinder(Graphics g, Brush b, int cell, int ox, int oy)
        {
            g.FillRectangle(b, ox * cell, oy * cell, 7 * cell, 7 * cell);
            using var w = new SolidBrush(Color.White);
            g.FillRectangle(w, (ox + 1) * cell, (oy + 1) * cell, 5 * cell, 5 * cell);
            g.FillRectangle(b, (ox + 2) * cell, (oy + 2) * cell, 3 * cell, 3 * cell);
        }

        // Dialog chọn món + SL từ giỏ hiện tại (dùng cho Tách HĐ và Tách bàn).
        // Trả về null nếu hủy; dict rỗng nếu không chọn gì hợp lệ.
        private Dictionary<string, (int qty, long price)>? PickItemsDialog(string title, string hint)
        {
            var owner = MsgBox.OwnerWindow(this);
            var frm = WindowChrome.CreateDialog(title, new Size(500, 420), out var content, owner);

            content.Controls.Add(new Label { Text = title, AutoSize = true, Font = Theme.F(10F, FontStyle.Bold), ForeColor = Theme.TextHi, Location = new Point(20, 16), BackColor = Color.Transparent });
            content.Controls.Add(new Label { Text = hint, AutoSize = true, Font = Theme.F(9F), ForeColor = Theme.TextMuted, Location = new Point(20, 40), BackColor = Color.Transparent });

            var dgv = new Guna2DataGridView { Location = new Point(16, 70), Size = new Size(460, 240) };
            Theme.StyleGrid(dgv);
            // StyleGrid đặt ReadOnly=true → phải mở lại, nếu không sẽ KHÔNG tick/nhập SL được
            dgv.ReadOnly = false;
            dgv.EditMode = DataGridViewEditMode.EditOnEnter;
            dgv.BindingContext = new BindingContext();   // sinh cột ngay khi bind (frm chưa hiển thị)
            content.Controls.Add(dgv);

            var dt = new DataTable();
            dt.Columns.Add("Tách", typeof(bool));
            dt.Columns.Add("Món");
            dt.Columns.Add("SL hiện", typeof(int));
            dt.Columns.Add("SL tách", typeof(int));
            dt.Columns.Add("Đơn giá", typeof(long));

            foreach (var (name, (qty, price)) in _orderItems)
                dt.Rows.Add(false, name, qty, qty, price);

            dgv.AutoGenerateColumns = true;   // StyleGrid tắt auto-gen; lưới tạo trong code cần bật lại để sinh cột từ DataTable
            dgv.DataSource = dt;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.Columns["Tách"].FillWeight    = 10;
            dgv.Columns["Món"].FillWeight     = 34;
            dgv.Columns["SL hiện"].FillWeight = 14;
            dgv.Columns["SL tách"].FillWeight = 14;
            dgv.Columns["Đơn giá"].FillWeight = 18;
            dgv.Columns["Món"].ReadOnly     = true;
            dgv.Columns["SL hiện"].ReadOnly = true;
            dgv.Columns["Đơn giá"].ReadOnly = true;
            dgv.Columns["Đơn giá"].DefaultCellStyle.Format    = "N0";
            dgv.Columns["Đơn giá"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            Dictionary<string, (int qty, long price)>? result = null;

            var btnConfirm = Theme.PrimaryButton("Xác nhận");
            btnConfirm.Size     = new Size(150, 36);
            btnConfirm.Location = new Point(210, 330);
            btnConfirm.Click   += (s2, e2) =>
            {
                dgv.EndEdit();
                var picked = new Dictionary<string, (int qty, long price)>();
                foreach (DataRow row in dt.Rows)
                {
                    if (row["Tách"] is not bool ticked || !ticked) continue;
                    int splitQty = row["SL tách"] is int v ? v : 0;
                    if (splitQty <= 0) continue;
                    string itemName = row["Món"].ToString()!;
                    if (!_orderItems.TryGetValue(itemName, out var orig)) continue;
                    picked[itemName] = (Math.Min(splitQty, orig.qty), orig.price);
                }
                if (picked.Count == 0)
                {
                    MsgBox.Show(frm, "Chưa tick món nào hoặc SL tách = 0!", "Thông báo", MsgBox.MessageBoxType.Warning);
                    return;
                }
                result = picked;
                frm.DialogResult = DialogResult.OK;
                frm.Close();
            };
            content.Controls.Add(btnConfirm);

            var btnCancel = Theme.GhostButton("Hủy");
            btnCancel.Size     = new Size(90, 36);
            btnCancel.Location = new Point(374, 330);
            btnCancel.Click   += (s2, e2) => frm.Close();
            content.Controls.Add(btnCancel);

            frm.ShowDialog(owner);
            return result;
        }

        // TÁCH HÓA ĐƠN: chọn món → THANH TOÁN RIÊNG phần tách ngay (tạo đơn + phiếu thu riêng),
        // phần còn lại ở lại hóa đơn của bàn.
        private async void ShowSplitBillDialog()
        {
            var owner = MsgBox.OwnerWindow(this);
            if (_orderItems.Count == 0)
            {
                MsgBox.Show(owner, "Đơn hàng trống, không thể tách hóa đơn.", "Thông báo", MsgBox.MessageBoxType.Warning);
                return;
            }

            var bill2 = PickItemsDialog("Tách hóa đơn — thanh toán riêng phần tách",
                                        "Tick + nhập SL tách. Phần tách sẽ thanh toán ngay, phần còn lại ở lại đơn.");
            if (bill2 == null || bill2.Count == 0) return;

            long bill2Total = bill2.Sum(kv => kv.Value.qty * kv.Value.price);
            bool paid = PaymentDialog.Pay(owner, bill2Total, _currentTable, "Khách lẻ (tách HĐ)", out string method);
            if (!paid) return;

            // Đơn riêng cho phần tách: món coi như đã phục vụ (không đưa lại hàng chờ pha chế)
            var items2 = new Dictionary<string, OrderItemDTO>();
            int i = 1;
            foreach (var (name, (qty, price)) in bill2)
            {
                _foodByName.TryGetValue(name, out var f);
                items2[$"ctd_{i:000}"] = new OrderItemDTO { FoodId = f?.Id, Quantity = qty, UnitPrice = price, Note = "", CookingStatus = "hoan_thanh" };
                i++;
            }

            string orderId2;
            try
            {
                var order2 = new OrderDTO
                {
                    TableId    = _currentTableId,
                    EmployeeId = GlobalSession.CurrentUser?.EmployeeId,
                    CreatedAt  = DateTimeOffset.Now.ToUnixTimeMilliseconds(),
                    Status     = "hoan_thanh",
                    Note       = $"Tách hóa đơn từ {_currentTable}",
                    Source     = "pos",
                    Items      = items2
                };
                var (ok, msg, id2) = await OrderBUS.Add(order2);
                if (!ok || id2 == null)
                {
                    MsgBox.Show(owner, $"Không lưu được hóa đơn tách: {msg}", "Lỗi", MsgBox.MessageBoxType.Error);
                    return;
                }
                orderId2 = id2;

                await PaymentBUS.Add(new PaymentDTO
                {
                    OrderId = orderId2,
                    EmployeeId = GlobalSession.CurrentUser?.EmployeeId,
                    Method = MapMethod(method),
                    Timestamp = DateTimeOffset.Now.ToUnixTimeMilliseconds(),
                    TotalAmount = bill2Total,
                    Discount = 0,
                    ActualReceived = bill2Total
                });
            }
            catch
            {
                MsgBox.Show(owner, "Không lưu được hóa đơn tách (kiểm tra server).", "Lỗi", MsgBox.MessageBoxType.Error);
                return;
            }

            // Trừ phần đã tách khỏi giỏ; đồng bộ lại đơn gốc nếu đã gửi bếp
            foreach (var (name, (qty, _)) in bill2)
            {
                if (!_orderItems.TryGetValue(name, out var cur)) continue;
                if (qty >= cur.qty) _orderItems.Remove(name);
                else _orderItems[name] = (cur.qty - qty, cur.price);
            }
            RefreshOrderGrid();
            if (_currentOrderId != null)
            {
                try
                {
                    if (_orderItems.Count == 0)
                    {
                        // tách hết & đã thanh toán → đơn gốc đóng, trả bàn
                        await OrderBUS.Update(_currentOrderId, new { trang_thai = "huy", ghi_chu = "Đã tách toàn bộ sang hóa đơn riêng" });
                        if (_currentTableId != null)
                            await TableBUS.Update(_currentTableId, new { trang_thai = "trong" });
                        ResetAfterPayment();
                    }
                    else
                    {
                        await OrderBUS.Update(_currentOrderId, new { chi_tiet_don = BuildItemsDict() });
                    }
                }
                catch { }
            }

            string items2Text = string.Join("\n", bill2.Select(kv => $"  • {kv.Key} × {kv.Value.qty}   {Theme.Vnd(kv.Value.qty * kv.Value.price)}"));
            MsgBox.Show(owner,
                $"Đã tách & thanh toán riêng!\n\nHÓA ĐƠN TÁCH ({MethodDisplay(MapMethod(method))}):\n{items2Text}\n\nTổng: {Theme.Vnd(bill2Total)}\nMã HĐ: {orderId2}",
                "Tách hóa đơn", MsgBox.MessageBoxType.Success);
        }
    }
}
