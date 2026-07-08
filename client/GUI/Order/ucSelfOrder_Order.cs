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

            // Danh sách dự phòng khi offline — sẽ được thay bằng tên bàn THẬT từ DB ở Load.
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

            // In QR thật qua máy in (trước đây chỉ MsgBox "Đã in!" mà không in gì)
            btnPrint.Click += (s, e) => PrintQr();

            // Runtime grid styling (declared in Designer, styled here so appearance is identical)
            Theme.StyleGrid(_dgvIncoming);

            Load += (s, e) => { _ = LoadIncoming(); _ = LoadTablesIntoCombo(); };
        }

        // Nạp tên bàn THẬT từ node tables (danh sách 1..15 chỉ là dự phòng khi offline).
        private async Task LoadTablesIntoCombo()
        {
            try
            {
                var tables = await TableBUS.GetAll();
                // Sắp theo số tự nhiên: "Bàn 2" trước "Bàn 10" (pad các cụm chữ số)
                var names = tables.Values.Select(t => t.Name)
                    .Where(n => !string.IsNullOrWhiteSpace(n))
                    .OrderBy(n => System.Text.RegularExpressions.Regex.Replace(n!, @"\d+", m => m.Value.PadLeft(4, '0')))
                    .Cast<object>().ToArray();
                if (names.Length == 0) return;

                _cmbTable.Items.Clear();
                _cmbTable.Items.AddRange(names);
                _cmbTable.SelectedIndex = 0; // trigger SelectedIndexChanged → QR + nhãn tự cập nhật
            }
            catch { /* offline — giữ danh sách dự phòng */ }
        }

        // In tem QR cho bàn: tiêu đề + mã QR, qua hộp thoại chọn máy in chuẩn Windows.
        private void PrintQr()
        {
            if (_pnlQR.BackgroundImage == null)
            {
                MsgBox.Show(MsgBox.OwnerWindow(this), "Chưa có mã QR để in.", "Thông báo", MsgBox.MessageBoxType.Warning);
                return;
            }
            string table = _cmbTable.SelectedItem?.ToString() ?? "Bàn";

            var doc = new System.Drawing.Printing.PrintDocument { DocumentName = $"QR tự đặt món - {table}" };
            doc.PrintPage += (s, ev) =>
            {
                if (ev.Graphics == null) return;
                var b = ev.MarginBounds;
                using var fTitle = new Font("Segoe UI", 18F, FontStyle.Bold);
                using var fSub = new Font("Segoe UI", 11F);
                var center = new StringFormat { Alignment = StringAlignment.Center };

                ev.Graphics.DrawString($"QUÉT ĐỂ GỌI MÓN — {table.ToUpper()}", fTitle, Brushes.Black,
                                       b.Left + b.Width / 2f, b.Top, center);
                int size = Math.Min(b.Width, 430);
                ev.Graphics.DrawImage(_pnlQR.BackgroundImage, b.Left + (b.Width - size) / 2, b.Top + 60, size, size);
                ev.Graphics.DrawString("Mở camera điện thoại, quét mã và chọn món ngay tại bàn.",
                                       fSub, Brushes.Black, b.Left + b.Width / 2f, b.Top + 60 + size + 20, center);
            };

            using var dlg = new PrintDialog { Document = doc, UseEXDialog = true };
            if (dlg.ShowDialog(FindForm()) != DialogResult.OK) return;
            try
            {
                doc.Print();
                MsgBox.Show(MsgBox.OwnerWindow(this), $"Đã gửi lệnh in QR cho {table} tới máy in.", "In QR", MsgBox.MessageBoxType.Success);
            }
            catch (Exception ex)
            {
                MsgBox.Show(MsgBox.OwnerWindow(this), $"Không in được: {ex.Message}", "Lỗi", MsgBox.MessageBoxType.Error);
            }
            finally { doc.Dispose(); }
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

                // Chỉ lấy đơn QR trong HÔM NAY — nhãn dưới bảng là "… đơn hôm nay".
                foreach (var kv in orders.Where(o => o.Value.Source == "qr"
                                       && o.Value.CreatedAt > 0
                                       && DateTimeOffset.FromUnixTimeMilliseconds(o.Value.CreatedAt).LocalDateTime.Date == DateTime.Today)
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
                // Khách thật quét QR ở bàn TRỐNG — ưu tiên bàn trống, hết mới rơi về bàn bất kỳ
                var pool = tables.Where(t => t.Value.Status == "trong").ToList();
                if (pool.Count == 0) pool = tables.ToList();
                var tableEntry = pool.OrderBy(_ => Guid.NewGuid()).FirstOrDefault();
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

                // Khách đặt qua QR nghĩa là bàn đang có khách → sơ đồ bàn POS/quản lý thấy ngay
                if (!string.IsNullOrEmpty(tableId))
                    try { await TableBUS.Update(tableId, new { trang_thai = "co_khach" }); } catch { }

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
