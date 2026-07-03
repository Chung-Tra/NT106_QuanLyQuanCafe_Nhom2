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
    public partial class ucSelfOrder_Order : UserControl
    {
        private DataTable _dtIncoming = null!;

        public ucSelfOrder_Order()
        {
            InitializeComponent();

            // Populate table combo (dynamic loop) + initial selection
            for (int i = 1; i <= 15; i++)
                _cmbTable.Items.Add($"Bàn {i:00}");
            _cmbTable.SelectedIndex = 0;
            lblQRTable.Text = $"Bàn: {_cmbTable.SelectedItem}";
            RenderTableQr();

            DgvRefresh.Attach(_dgvIncoming, () => LoadIncoming());

            // Double-click 1 đơn đến -> form chi tiết read-only đủ field
            _dgvIncoming.CellDoubleClick += (s, e) =>
            {
                if (e.RowIndex < 0) return;
                RecordDetail.FromRow(_dgvIncoming.Rows[e.RowIndex], "Chi tiết đơn tự đặt")
                            .ShowDialog(MsgBox.OwnerWindow(this));
            };

            // Đổi bàn → sinh lại QR tự đặt món (URL kèm mã bàn) cho bàn mới.
            _cmbTable.SelectedIndexChanged += (s, e) =>
            {
                RenderTableQr();
                lblQRTable.Text = $"Bàn: {_cmbTable.SelectedItem}";
            };

            // Print button (uses runtime selection + owner window)
            btnPrint.Click += (s, e) =>
                MsgBox.Show(MsgBox.OwnerWindow(this), $"Đã in QR cho {_cmbTable.SelectedItem}!", "In thành công", MsgBox.MessageBoxType.Success);

            // Runtime grid styling (declared in Designer, styled here so appearance is identical)
            Theme.StyleGrid(_dgvIncoming);

            Load += (s, e) => _ = LoadIncoming();
        }

        // QR tự đặt món THẬT: mã hoá URL trang đặt món kèm mã bàn (khách quét mở menu online).
        private void RenderTableQr()
        {
            string table = _cmbTable.SelectedItem?.ToString() ?? "Bàn 01";
            string url = $"{QrConfig.SelfOrderBaseUrl}?table={Uri.EscapeDataString(table)}";
            try
            {
                _pnlQR.BackColor = Color.White;
                _pnlQR.BackgroundImage?.Dispose();
                _pnlQR.BackgroundImage = Qr.Url(url, 8);
                _pnlQR.BackgroundImageLayout = ImageLayout.Zoom;
            }
            catch { /* để trống nếu không sinh được */ }
        }

        private static string StatusVi(string? s) => s switch
        {
            "pending"      => "Mới!",
            "dang_phuc_vu" => "Đã nhận",
            "hoan_thanh"   => "Hoàn thành",
            "huy"          => "Huỷ",
            _              => s ?? ""
        };

        // Đơn tự đặt THẬT từ node orders (nguon == "qr"), map tên bàn + tên món từ Firebase.
        private async Task LoadIncoming()
        {
            _dtIncoming = new DataTable();
            _dtIncoming.Columns.Add("Thời gian");
            _dtIncoming.Columns.Add("Bàn");
            _dtIncoming.Columns.Add("Món đặt");
            _dtIncoming.Columns.Add("SL", typeof(int));
            _dtIncoming.Columns.Add("Trạng thái");

            try
            {
                var orders = await OrderBUS.GetAll();
                var tables = await TableBUS.GetAll();
                var foods  = (await Task.Run(FoodBUS.GetListFoods))
                             .Where(f => f.Id != null).ToDictionary(f => f.Id!, f => f.Name ?? f.Id!);

                foreach (var kv in orders.Where(o => o.Value.Source == "qr")
                                         .OrderByDescending(o => o.Value.CreatedAt))
                {
                    var o = kv.Value;
                    string time = o.CreatedAt > 0
                        ? DateTimeOffset.FromUnixTimeMilliseconds(o.CreatedAt).LocalDateTime.ToString("HH:mm")
                        : "";
                    string tableName = (o.TableId != null && tables.TryGetValue(o.TableId, out var tb))
                        ? (tb.Name ?? o.TableId) : (o.TableId ?? "");

                    var items = o.Items?.Values ?? Enumerable.Empty<OrderItemDTO>();
                    string monDat = string.Join(", ", items.Select(it =>
                        $"{(it.FoodId != null && foods.TryGetValue(it.FoodId, out var n) ? n : it.FoodId)} × {it.Quantity}"));
                    int qty = items.Sum(it => it.Quantity);

                    _dtIncoming.Rows.Add(time, tableName, monDat, qty, StatusVi(o.Status));
                }
            }
            catch { /* offline */ }

            _dgvIncoming.DataSource = _dtIncoming;
            _dgvIncoming.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            _dgvIncoming.Columns["Thời gian"].FillWeight = 14;
            _dgvIncoming.Columns["Bàn"].FillWeight       = 12;
            _dgvIncoming.Columns["Món đặt"].FillWeight   = 46;
            _dgvIncoming.Columns["SL"].FillWeight        = 8;
            _dgvIncoming.Columns["Trạng thái"].FillWeight = 20;

            ColorRows();
            UpdateCount();
        }

        private void ColorRows()
        {
            foreach (DataGridViewRow row in _dgvIncoming.Rows)
            {
                string status = row.Cells["Trạng thái"].Value?.ToString() ?? "";
                row.Cells["Trạng thái"].Style.ForeColor =
                    status is "Đã nhận" or "Hoàn thành" ? Theme.Green : Theme.Amber;
                if (status == "Mới!")
                    row.DefaultCellStyle.BackColor = Theme.Fade(Theme.Teal, 30);
            }
        }

        private void UpdateCount()
        {
            _lblIncomingCount.Text = $"{_dtIncoming.Rows.Count} đơn hôm nay";
        }

        // "Giả lập" = tạo 1 đơn tự đặt THẬT (nguon=qr) vào node orders để test luồng end-to-end:
        // đơn sẽ hiện ở đây, ở lịch sử POS và KDS pha chế.
        private async void BtnSimulate_Click(object? sender, EventArgs e)
        {
            try
            {
                var menu = (await Task.Run(FoodBUS.GetListFoods)).Where(f => f.InStock && f.Id != null).ToList();
                if (menu.Count == 0)
                {
                    MsgBox.Show(MsgBox.OwnerWindow(this), "Chưa có món trong thực đơn để tạo đơn thử.", "Thông báo", MsgBox.MessageBoxType.Warning);
                    return;
                }

                var tables = await TableBUS.GetAll();
                var tableEntry = tables.OrderBy(_ => Guid.NewGuid()).FirstOrDefault();
                string? tableId = tableEntry.Key;
                string tableName = tableEntry.Value?.Name ?? _cmbTable.SelectedItem?.ToString() ?? "Bàn";

                var rnd = new Random();
                var picks = menu.OrderBy(_ => Guid.NewGuid()).Take(rnd.Next(1, 3)).ToList();
                var items = new Dictionary<string, OrderItemDTO>();
                int i = 1;
                foreach (var f in picks)
                    items[$"ct{i++}"] = new OrderItemDTO
                    {
                        FoodId = f.Id, Quantity = rnd.Next(1, 4), UnitPrice = f.Price, CookingStatus = "cho"
                    };

                var dto = new OrderDTO
                {
                    TableId    = tableId,
                    EmployeeId = GlobalSession.CurrentUser?.EmployeeId,
                    CreatedAt  = DateTimeOffset.Now.ToUnixTimeMilliseconds(),
                    Status     = "pending",
                    Source     = "qr",
                    Items      = items
                };

                var (ok, msg, _) = await OrderBUS.Add(dto);
                if (!ok) { MsgBox.Show(MsgBox.OwnerWindow(this), msg, "Lỗi", MsgBox.MessageBoxType.Error); return; }

                await LoadIncoming();
                string tomTat = string.Join(", ", picks.Select((f, k) => $"{f.Name} × {items[$"ct{k + 1}"].Quantity}"));
                MsgBox.Show(MsgBox.OwnerWindow(this),
                    $"Đơn tự đặt mới từ {tableName}!\n\n{tomTat}\n\nĐơn đã vào Firebase — POS & KDS pha chế sẽ thấy ngay.",
                    "Đơn vào realtime", MsgBox.MessageBoxType.Success);
            }
            catch (Exception ex)
            {
                MsgBox.Show(MsgBox.OwnerWindow(this), "Lỗi tạo đơn thử: " + ex.Message, "Lỗi", MsgBox.MessageBoxType.Error);
            }
        }
    }
}
