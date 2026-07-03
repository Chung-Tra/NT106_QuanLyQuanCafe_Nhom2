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
        private string _currentTable = "Bàn 01";

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

            lblCurrentStaff.Text = $"Nhân viên: {GlobalSession.CurrentUser?.FullName ?? "Staff"}  ·  {_currentTable}";
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
            // Ảnh thật nếu ImageUrl là file cục bộ tồn tại (không tải http để tránh treo UI)
            if (TryLoadLocalImage(imageUrl, out Image? realImg))
            {
                tile.BackgroundImage = realImg;
                lblIcon.Visible = false;
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
            long disc = 0;
            if (long.TryParse(txtDiscount.Text.Replace(",", "").Replace(".", "").Trim(), out long d))
                disc = d;
            long total = Math.Max(0, sub - disc);
            lblTotalAmount.Text = Theme.Vnd(total);
        }

        private void BtnPay_Click(object? sender, EventArgs e)
        {
            if (_orderItems.Count == 0)
            {
                MsgBox.Show(MsgBox.OwnerWindow(this), "Đơn hàng trống! Vui lòng chọn món trước.", "Thông báo", MsgBox.MessageBoxType.Warning);
                return;
            }

            long sub = _orderItems.Sum(kv => kv.Value.qty * kv.Value.price);
            if (long.TryParse(txtDiscount.Text.Replace(",", "").Replace(".", "").Trim(), out long disc))
                sub = Math.Max(0, sub - disc);

            string customer = "Khách lẻ";
            bool paid = PaymentDialog.Pay(MsgBox.OwnerWindow(this), sub, _currentTable, customer, out string method);

            if (!paid) return;

            // Hiện hóa đơn + QR feedback trước khi xóa đơn
            string orderId = $"HD{DateTime.Now:yyyyMMddHHmm}{_orderItems.Count:00}";
            ShowReceipt(orderId, sub, method);

            _orderItems.Clear();
            RefreshOrderGrid();
            txtDiscount.Clear();
            lblTotalAmount.Text = "0 đ";
        }

        private void BtnVoidOrder_Click(object? sender, EventArgs e)
        {
            if (_orderItems.Count == 0)
            {
                MsgBox.Show(MsgBox.OwnerWindow(this), "Không có đơn nào để hủy.", "Thông báo", MsgBox.MessageBoxType.Info);
                return;
            }

            string? reason = InputDialog.Show(MsgBox.OwnerWindow(this), "Hủy đơn hàng", "Lý do hủy (bắt buộc)", "VD: Khách đổi ý...");
            if (string.IsNullOrEmpty(reason)) return;

            _orderItems.Clear();
            RefreshOrderGrid();
            txtDiscount.Clear();
            lblTotalAmount.Text = "0 đ";
            MsgBox.Show(MsgBox.OwnerWindow(this), $"Đã hủy đơn. Lý do: {reason}", "Hủy đơn thành công", MsgBox.MessageBoxType.Info);
        }

        private void ShowOrderTab()
        {
            SetActiveTab(btnTabOrder);
            pnlMainTabContainer.Controls.Clear();
            pnlMainTabContainer.Controls.Add(pnlCenterMenu);
        }

        private void SetActiveTab(Control activeBtn)
        {
            btnTabOrder.ForeColor   = Color.White;
            btnTabTables.ForeColor  = Color.White;
            btnTabHistory.ForeColor = Color.White;
            activeBtn.ForeColor = Color.MediumSeaGreen;
        }

        private void btnTabTables_Click(object sender, EventArgs e)
        {
            SetActiveTab(btnTabTables);

            var host = new Panel { Dock = DockStyle.Fill, BackColor = Color.Transparent, Padding = new Padding(12) };

            // Thanh thao tác bàn
            var actionBar = new Guna2Panel { FillColor = Theme.Surface, BorderRadius = 10, Location = new Point(12, 12), Size = new Size(540, 44) };
            actionBar.Controls.Add(new Label { Text = "Thao tác nâng cao:", AutoSize = true, Font = Theme.F(9F), ForeColor = Theme.TextMuted, Location = new Point(8, 13), BackColor = Color.Transparent });

            var btnMerge     = MakeActionBtn("🔗 Gộp bàn",   Theme.Blue,   120);
            var btnSplit     = MakeActionBtn("✂ Tách bàn",   Theme.Amber,  220);
            var btnTransfer  = MakeActionBtn("↔ Chuyển bàn", Theme.Purple, 320);
            var btnSplitBill = MakeActionBtn("🧾 Tách HĐ",   Theme.Green,  418);
            btnMerge.Click    += (s2, e2) => AdvancedTableAction("Gộp bàn");
            btnSplit.Click    += (s2, e2) => AdvancedTableAction("Tách bàn");
            btnTransfer.Click += (s2, e2) => AdvancedTableAction("Chuyển bàn");
            btnSplitBill.Click += (s2, e2) => ShowSplitBillDialog();
            actionBar.Controls.Add(btnMerge);
            actionBar.Controls.Add(btnSplit);
            actionBar.Controls.Add(btnTransfer);
            actionBar.Controls.Add(btnSplitBill);
            host.Controls.Add(actionBar);

            // Sơ đồ bàn
            var flp = new FlowLayoutPanel { Location = new Point(12, 66), Size = new Size(450, 360), BackColor = Color.Transparent, AutoScroll = true };

            string[] tableNames = Enumerable.Range(1, 15).Select(i => $"Bàn {i:00}").ToArray();
            bool[] occupied = { false, true, false, true, false, false, true, false, true, false, true, false, false, true, false };

            for (int i = 0; i < tableNames.Length; i++)
            {
                int idx = i;
                var card = new Guna2Panel
                {
                    FillColor    = occupied[i] ? Theme.Fade(Theme.Red, 60) : Theme.Surface,
                    BorderRadius = 10,
                    Size         = new Size(98, 82),
                    Margin       = new Padding(4),
                    Cursor       = Cursors.Hand,
                    BorderColor  = occupied[i] ? Theme.Red : Theme.Border,
                    BorderThickness = 1,
                };

                card.Controls.Add(new Label
                {
                    Text      = tableNames[i],
                    Font      = Theme.F(10F, FontStyle.Bold),
                    ForeColor = occupied[i] ? Theme.Red : Theme.TextHi,
                    BackColor = Color.Transparent,
                    Location  = new Point(8, 14),
                    AutoSize  = true,
                });
                card.Controls.Add(new Label
                {
                    Text      = occupied[i] ? "Có khách" : "Trống",
                    Font      = Theme.F(8F),
                    ForeColor = occupied[i] ? Theme.Red : Theme.Green,
                    BackColor = Color.Transparent,
                    Location  = new Point(8, 40),
                    AutoSize  = true,
                });

                card.Click += (s2, e2) =>
                {
                    _currentTable = tableNames[idx];
                    lblCurrentStaff.Text = $"Nhân viên: {GlobalSession.CurrentUser?.FullName ?? "Staff"}  ·  {_currentTable}";
                    MsgBox.Show(MsgBox.OwnerWindow(this), $"Đã chọn {_currentTable}. Quay về tab Order để gọi món.", "Chọn bàn", MsgBox.MessageBoxType.Info);
                };

                flp.Controls.Add(card);
            }

            // Legend
            host.Controls.Add(flp);

            var legend = new Label { Text = "🔴 Có khách   ⬛ Trống   — Click để chọn bàn", AutoSize = true, Font = Theme.F(8.5F), ForeColor = Theme.TextMuted, Location = new Point(12, 434), BackColor = Color.Transparent };
            host.Controls.Add(legend);

            pnlMainTabContainer.Controls.Clear();
            pnlMainTabContainer.Controls.Add(host);
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

        private void AdvancedTableAction(string action)
        {
            string? detail = InputDialog.Show(MsgBox.OwnerWindow(this), action, $"{action}: Nhập số bàn đích", "VD: Bàn 03");
            if (string.IsNullOrEmpty(detail)) return;
            MsgBox.Show(MsgBox.OwnerWindow(this), $"Đã thực hiện {action}: {_currentTable} → {detail}", "Thành công", MsgBox.MessageBoxType.Success);
        }

        private void btnTabHistory_Click(object sender, EventArgs e)
        {
            SetActiveTab(btnTabHistory);

            var dgv = new Guna2DataGridView { Dock = DockStyle.Fill };
            Theme.StyleGrid(dgv);
            // Lưới chưa gắn vào parent nên chưa có BindingContext → auto-gen cột không chạy,
            // Columns["..."] sẽ null. Gán BindingContext để cột sinh ngay khi bind DataTable.
            dgv.BindingContext = new BindingContext();

            var dt = new DataTable();
            dt.Columns.Add("Mã HĐ");
            dt.Columns.Add("Thời gian");
            dt.Columns.Add("Bàn");
            dt.Columns.Add("Số món", typeof(int));
            dt.Columns.Add("Tổng tiền", typeof(long));
            dt.Columns.Add("Hình thức TT");
            dt.Columns.Add("NV Order");
            dt.Rows.Add("HD001", "08:35", "Bàn 02", 3, 135000L, "Tiền mặt",  GlobalSession.CurrentUser?.FullName ?? "Staff");
            dt.Rows.Add("HD002", "09:10", "Bàn 05", 2,  80000L, "VietQR",    GlobalSession.CurrentUser?.FullName ?? "Staff");
            dt.Rows.Add("HD003", "10:05", "Bàn 08", 5, 210000L, "Tiền mặt",  GlobalSession.CurrentUser?.FullName ?? "Staff");
            dt.Rows.Add("HD004", "11:22", "Bàn 01", 1,  45000L, "Thẻ",       GlobalSession.CurrentUser?.FullName ?? "Staff");
            dt.Rows.Add("HD005", "12:40", "Bàn 03", 4, 175000L, "Tiền mặt",  GlobalSession.CurrentUser?.FullName ?? "Staff");
            dgv.AutoGenerateColumns = true;   // StyleGrid tắt auto-gen; lưới tạo trong code cần bật lại để sinh cột từ DataTable
            dgv.DataSource = dt;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.Columns["Tổng tiền"].DefaultCellStyle.Format    = "N0";
            dgv.Columns["Tổng tiền"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            pnlMainTabContainer.Controls.Clear();
            pnlMainTabContainer.Controls.Add(dgv);
        }

        private void BtnReport_Click(object? sender, EventArgs e)
        {
            long total = _orderItems.Sum(kv => kv.Value.qty * kv.Value.price);
            string report =
                $"BÁO CÁO BÁN HÀNG\n" +
                $"Thời gian: {DateTime.Now:HH:mm dd/MM/yyyy}\n" +
                "──────────────────\n" +
                $"• Tổng tiền hiện tại: {Theme.Vnd(total)}\n" +
                $"• Số món: {_orderItems.Sum(kv => kv.Value.qty)}\n" +
                "──────────────────\n" +
                "Gửi báo cáo cho quản lý?";

            if (MsgBox.Show(MsgBox.OwnerWindow(this), report, "Báo cáo POS", MsgBox.MessageBoxType.Warning) == DialogResult.Yes)
                MsgBox.Show(MsgBox.OwnerWindow(this), "Đã gửi báo cáo cho quản lý!", "Thành công", MsgBox.MessageBoxType.Success);
        }

        // Hiển thị hóa đơn sau khi thanh toán + mã QR feedback độc nhất theo orderId
        private void ShowReceipt(string orderId, long total, string method)
        {
            var frm = new Form
            {
                Text             = $"Hóa đơn {orderId}",
                Size             = new Size(440, 560),
                StartPosition    = FormStartPosition.CenterParent,
                FormBorderStyle  = FormBorderStyle.FixedDialog,
                MaximizeBox      = false,
                MinimizeBox      = false,
                BackColor        = Theme.AppBg,
            };

            frm.Controls.Add(new Label { Text = "☕  QUÁN CÀ PHÊ NHÓM 2", AutoSize = true, Font = Theme.F(13F, FontStyle.Bold), ForeColor = Theme.TextHi, Location = new Point(20, 16), BackColor = Color.Transparent });
            frm.Controls.Add(new Label { Text = $"Mã HĐ: {orderId}", AutoSize = true, Font = Theme.F(9.5F, FontStyle.Bold), ForeColor = Theme.Teal, Location = new Point(20, 48), BackColor = Color.Transparent });
            frm.Controls.Add(new Label { Text = $"Bàn: {_currentTable}   ·   {DateTime.Now:HH:mm dd/MM/yyyy}", AutoSize = true, Font = Theme.F(9F), ForeColor = Theme.TextPri, Location = new Point(20, 68), BackColor = Color.Transparent });
            frm.Controls.Add(new Label { Text = $"Nhân viên: {GlobalSession.CurrentUser?.FullName ?? "Staff"}   ·   {method}", AutoSize = true, Font = Theme.F(9F), ForeColor = Theme.TextMuted, Location = new Point(20, 88), BackColor = Color.Transparent });

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
            frm.Controls.Add(dgv);

            frm.Controls.Add(new Label { Text = $"TỔNG CỘNG:  {Theme.Vnd(total)}", AutoSize = true, Font = Theme.F(11F, FontStyle.Bold), ForeColor = Theme.TextHi, Location = new Point(20, 286), BackColor = Color.Transparent });
            frm.Controls.Add(new Label { Text = "Quét QR để đánh giá dịch vụ:", AutoSize = true, Font = Theme.F(9F), ForeColor = Theme.TextMuted, Location = new Point(20, 310), BackColor = Color.Transparent });

            var pnlQR = new Panel { Location = new Point(144, 336), Size = new Size(140, 140), BackColor = Color.White };
            pnlQR.Paint += (s, e) => DrawFeedbackQR(e.Graphics, orderId, 140);
            frm.Controls.Add(pnlQR);

            frm.Controls.Add(new Label { Text = $"cafe.vn/feedback?order={orderId}", AutoSize = true, Font = Theme.F(7.5F), ForeColor = Theme.TextMuted, Location = new Point(96, 482), BackColor = Color.Transparent });

            var btnClose = Theme.PrimaryButton("Đóng");
            btnClose.Size     = new Size(110, 36);
            btnClose.Location = new Point(310, 480);
            btnClose.Click   += (s, e) => frm.Close();
            frm.Controls.Add(btnClose);

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

        // Dialog tách hóa đơn: chọn món → tách sang HĐ2, phần còn lại ở HĐ1
        private void ShowSplitBillDialog()
        {
            if (_orderItems.Count == 0)
            {
                MsgBox.Show(MsgBox.OwnerWindow(this), "Đơn hàng trống, không thể tách hóa đơn.", "Thông báo", MsgBox.MessageBoxType.Warning);
                return;
            }

            var frm = new Form
            {
                Text            = "Tách hóa đơn",
                Size            = new Size(500, 420),
                StartPosition   = FormStartPosition.CenterParent,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox     = false,
                BackColor       = Theme.AppBg,
            };

            frm.Controls.Add(new Label { Text = "Chọn món cần tách sang Hóa đơn 2:", AutoSize = true, Font = Theme.F(10F, FontStyle.Bold), ForeColor = Theme.TextHi, Location = new Point(20, 16), BackColor = Color.Transparent });
            frm.Controls.Add(new Label { Text = "Tick + nhập SL tách. Phần còn lại ở lại Hóa đơn 1.", AutoSize = true, Font = Theme.F(9F), ForeColor = Theme.TextMuted, Location = new Point(20, 40), BackColor = Color.Transparent });

            var dgv = new Guna2DataGridView { Location = new Point(16, 70), Size = new Size(460, 240) };
            Theme.StyleGrid(dgv);
            dgv.BindingContext = new BindingContext();   // sinh cột ngay khi bind (frm chưa hiển thị)
            frm.Controls.Add(dgv);

            var dt = new DataTable();
            dt.Columns.Add("Tách", typeof(bool));
            dt.Columns.Add("Món");
            dt.Columns.Add("SL hiện", typeof(int));
            dt.Columns.Add("SL tách", typeof(int));
            dt.Columns.Add("Đơn giá", typeof(long));

            foreach (var (name, (qty, price)) in _orderItems)
                dt.Rows.Add(false, name, qty, 0, price);

            dgv.AutoGenerateColumns = true;   // StyleGrid tắt auto-gen; lưới tạo trong code cần bật lại để sinh cột từ DataTable
            dgv.DataSource = dt;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.Columns["Tách"].FillWeight    = 8;
            dgv.Columns["Món"].FillWeight     = 36;
            dgv.Columns["SL hiện"].FillWeight = 14;
            dgv.Columns["SL tách"].FillWeight = 14;
            dgv.Columns["Đơn giá"].FillWeight = 18;
            dgv.Columns["Đơn giá"].DefaultCellStyle.Format    = "N0";
            dgv.Columns["Đơn giá"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            var btnConfirm = Theme.PrimaryButton("✂  Xác nhận tách");
            btnConfirm.Size     = new Size(160, 36);
            btnConfirm.Location = new Point(200, 330);
            btnConfirm.Click   += (s2, e2) =>
            {
                var bill2 = new Dictionary<string, (int qty, long price)>();
                foreach (DataRow row in dt.Rows)
                {
                    if (!(bool)row["Tách"]) continue;
                    int splitQty = (int)row["SL tách"];
                    if (splitQty <= 0) continue;
                    string itemName = row["Món"].ToString()!;
                    if (!_orderItems.ContainsKey(itemName)) continue;
                    var (origQty, origPrice) = _orderItems[itemName];
                    if (splitQty >= origQty)
                        _orderItems.Remove(itemName);
                    else
                        _orderItems[itemName] = (origQty - splitQty, origPrice);
                    bill2[itemName] = (splitQty, origPrice);
                }
                if (bill2.Count == 0)
                {
                    MsgBox.Show(frm, "Chưa chọn món nào hoặc SL tách = 0!", "Thông báo", MsgBox.MessageBoxType.Warning);
                    return;
                }
                RefreshOrderGrid();
                frm.Close();
                long bill2Total = bill2.Sum(kv => kv.Value.qty * kv.Value.price);
                string items2   = string.Join("\n", bill2.Select(kv => $"  • {kv.Key} × {kv.Value.qty}   {Theme.Vnd(kv.Value.qty * kv.Value.price)}"));
                MsgBox.Show(MsgBox.OwnerWindow(this), $"Tách thành công!\n\nHÓA ĐƠN 2:\n{items2}\n\nTổng HĐ2: {Theme.Vnd(bill2Total)}", "Tách hóa đơn", MsgBox.MessageBoxType.Success);
            };
            frm.Controls.Add(btnConfirm);

            var btnCancel = Theme.GhostButton("Hủy");
            btnCancel.Size     = new Size(90, 36);
            btnCancel.Location = new Point(374, 330);
            btnCancel.Click   += (s2, e2) => frm.Close();
            frm.Controls.Add(btnCancel);

            frm.ShowDialog(MsgBox.OwnerWindow(this));
        }
    }
}
