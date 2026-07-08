using BUS;
using DTO;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class ucOrders_Manager : UserControl
    {
        // Chỉ giữ các trạng thái thực sự được sinh ra ở LoadRealData ("Đang phục vụ"/"Chờ lên món").
        private static readonly string[] TableStatusOptions = { "Tất cả", "Đang phục vụ", "Chờ lên món" };

        // Món vào danh sách cảnh báo khi đơn chờ bếp quá ngưỡng này (DisplayText gắn 🔥 từ 20').
        private const int WarnAfterMinutes = 15;

        // Đơn bếp treo quá ngưỡng này coi như bị bỏ quên (quên đóng/quên thanh toán) —
        // nút "Dọn đơn treo" sẽ huỷ và trả bàn, sau khi quản lý xác nhận.
        private const int StaleOrderHours = 12;
        private List<TableModelDTO>? _originalTableData;
        private List<WarningWaitModelDTO> _kitchenWarnings = new();

        // Poll giống KDS: POS thanh toán / gửi bếp xong thì tình trạng bàn ở đây tự cập nhật.
        private readonly System.Windows.Forms.Timer _pollTimer = new() { Interval = 8000 };
        private string _lastSig = "";
        private bool _loading;

        public ucOrders_Manager()
        {
            InitializeComponent();
            GridColumnGuard.SyncColumnNames(dgvTableStatus);
            DgvRefresh.Attach(dgvTableStatus, () => _ = LoadRealData(force: true));

            cboTableStatus.Items.Clear();
            cboTableStatus.Items.AddRange(TableStatusOptions);
            cboTableStatus.SelectedIndex = 0;

            _pollTimer.Tick += (s, e) => { if (Visible) _ = LoadRealData(); };
            Disposed += (s, e) => _pollTimer.Dispose();
            _pollTimer.Start();

            _ = LoadRealData(force: true);
        }

        // Tải tình trạng bàn/bếp thật từ Firebase: các đơn đang xử lý (pending/đang phục vụ).
        // force = false (tick nền): dữ liệu không đổi thì bỏ qua, khỏi rebind làm mất chọn/cuộn.
        private async Task LoadRealData(bool force = false)
        {
            if (_loading) return;
            _loading = true;
            try { await LoadRealDataCore(force); }
            finally { _loading = false; }
        }

        private async Task LoadRealDataCore(bool force)
        {
            Dictionary<string, DTO.TableDTO> tables;
            Dictionary<string, DTO.OrderDTO> orders;
            Dictionary<string, PaymentDTO> payments;
            Dictionary<string, string> foodNames;
            List<FoodDTO> foods;
            try
            {
                tables = await TableBUS.GetAll();
                orders = await OrderBUS.GetAll();
                payments = await PaymentBUS.GetAll();
                foods = await FoodBUS.GetListFoods();
                foodNames = foods.Where(f => f.Id != null).ToDictionary(f => f.Id!, f => f.Name ?? f.Id!);
            }
            catch
            {
                _originalTableData = new();
                dgvTableStatus.DataSource = _originalTableData;
                lblEmptyTablesValue.Text = "0 / 0 bàn";
                lblPendingValue.Text = "0 bàn";
                lblSoldOutValue.Text = "0 món";
                return;
            }

            string FoodName(string? id) => (id != null && foodNames.TryGetValue(id, out var n)) ? n : (id ?? "Món");
            long now = DateTimeOffset.Now.ToUnixTimeMilliseconds();

            // Đơn "đang phục vụ tại bàn" gồm cả đơn bếp đã pha xong (hoan_thanh) nhưng CHƯA
            // thanh toán: phân biệt bằng phiếu thu (payments) — thanh toán xong mới có phiếu
            // và bàn mới được trả về "trong". Nếu chỉ lấy pending/dang_phuc_vu thì số bàn
            // trống (đếm theo tables) và danh sách phục vụ sẽ lệch nhau.
            var paidOrderIds = payments.Values.Where(p => p.OrderId != null)
                                              .Select(p => p.OrderId!).ToHashSet();
            bool TableOccupied(string? tid) =>
                tid != null && tables.TryGetValue(tid, out var t) && t.Status != "trong";

            var list = new List<TableModelDTO>();
            _kitchenWarnings = new();
            int idx = 0;

            foreach (var kv in orders.Where(o =>
                         o.Value.Status == "pending" || o.Value.Status == "dang_phuc_vu" ||
                         (o.Value.Status == "hoan_thanh" && !paidOrderIds.Contains(o.Key) && TableOccupied(o.Value.TableId)))
                                     .OrderBy(o => o.Value.CreatedAt))
            {
                var ord = kv.Value;
                string tableName = (ord.TableId != null && tables.TryGetValue(ord.TableId, out var tb))
                    ? (tb.Name ?? ord.TableId) : "Mang đi";

                var itemList = (ord.Items?.Values ?? Enumerable.Empty<OrderItemDTO>()).ToList();
                long total = itemList.Sum(it => (long)it.UnitPrice * it.Quantity);

                // KDS chuyển trạng thái ở CẤP ĐƠN (pending → dang_phuc_vu → hoan_thanh);
                // trạng thái từng món (trang_thai_che_bien) chỉ đổi khi thanh toán/manager
                // can thiệp — nên tiến độ phải suy từ trạng thái đơn, không đếm món mù quáng.
                string status, progress;
                if (ord.Status == "hoan_thanh")
                {
                    status = "Đang phục vụ";
                    progress = "Đã lên đủ";
                }
                else
                {
                    status = "Chờ lên món";
                    int doneItems = itemList.Count(it => it.CookingStatus == "hoan_thanh");
                    progress = ord.Status == "pending"
                        ? "Chờ bếp nhận"
                        : (doneItems > 0 ? $"Thiếu {itemList.Count - doneItems} món" : "Đang pha chế");
                }

                list.Add(new TableModelDTO
                {
                    TableId = ++idx,
                    TableName = tableName,
                    Status = status,
                    Progress = progress,
                    TotalAmount = total.ToString("N0") + " đ"
                });

                // Cảnh báo món chờ lâu: chỉ đơn bếp chưa xong (pending/dang_phuc_vu) và chỉ
                // khi vượt ngưỡng — panel này là CẢNH BÁO, không phải danh sách mọi món.
                if (ord.Status == "hoan_thanh" || ord.Items == null) continue;
                int waitMin = ord.CreatedAt > 0 ? (int)((now - ord.CreatedAt) / 60000) : 0;
                if (waitMin < WarnAfterMinutes) continue;
                foreach (var it in ord.Items.Where(it => it.Value.CookingStatus != "hoan_thanh"))
                    _kitchenWarnings.Add(new WarningWaitModelDTO
                    {
                        OrderId = kv.Key,
                        ItemKey = it.Key,
                        TableName = tableName,
                        DrinkName = FoodName(it.Value.FoodId),
                        WaitTimeMinutes = waitMin
                    });
            }
            _kitchenWarnings = _kitchenWarnings.OrderByDescending(w => w.WaitTimeMinutes).ToList();

            // Chữ ký dữ liệu — poll nền không đổi thì bỏ qua, khỏi rebind gây giật/mất dòng chọn
            string sig = string.Join("|", list.Select(x => $"{x.TableName}:{x.Status}:{x.Progress}:{x.TotalAmount}"))
                       + "#" + tables.Values.Count(t => t.Status == "trong") + "/" + tables.Count
                       + "#" + foods.Count(f => !f.InStock)
                       + "#" + string.Join(",", _kitchenWarnings.Select(w => $"{w.OrderId}/{w.ItemKey}:{w.WaitTimeMinutes}"));
            if (!force && sig == _lastSig) return;
            _lastSig = sig;

            _originalTableData = list;
            // Giữ bộ lọc trạng thái đang chọn khi tự làm mới
            string? sel = cboTableStatus.SelectedItem?.ToString();
            var shown = (sel != null && sel != "Tất cả") ? list.Where(t => t.Status == sel).ToList() : list;
            dgvTableStatus.DataSource = null;
            dgvTableStatus.DataSource = shown;
            if (dgvTableStatus.Columns["TableId"] != null)
            {
                dgvTableStatus.Columns["TableId"].Visible = false;
                dgvTableStatus.Columns["TableName"].HeaderText = "Bàn";
                dgvTableStatus.Columns["Status"].HeaderText = "Trạng Thái";
                dgvTableStatus.Columns["Progress"].HeaderText = "Tiến độ món";
                dgvTableStatus.Columns["TotalAmount"].HeaderText = "Tạm Tính";
            }
            dgvTableStatus.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTableStatus.RowHeadersVisible = false;

            lstKitchenWarning.DataSource = null;
            lstKitchenWarning.Items.Clear();
            if (_kitchenWarnings.Count > 0)
            {
                lstKitchenWarning.DataSource = _kitchenWarnings;
                lstKitchenWarning.DisplayMember = "DisplayText";
            }
            else
            {
                lstKitchenWarning.Items.Add("(Không có món chờ quá lâu — bếp đang ổn)");
            }

            // Món hết hàng (con_hang = false)
            lstSoldOut.Items.Clear();
            foreach (var f in foods.Where(f => !f.InStock))
                lstSoldOut.Items.Add($"{f.Name} — tạm hết");
            if (lstSoldOut.Items.Count == 0)
                lstSoldOut.Items.Add("(Không có món nào hết hàng)");

            int totalTables = tables.Count;
            int emptyTables = tables.Values.Count(t => t.Status == "trong");
            int pendingTables = list.Count(x => x.Status == "Chờ lên món");
            int soldOutCount = foods.Count(f => !f.InStock);

            lblEmptyTablesValue.Text = $"{emptyTables} / {totalTables} bàn";
            lblPendingValue.Text = $"{pendingTables} bàn";
            lblSoldOutValue.Text = $"{soldOutCount} món";
        }

        // Double-click 1 bàn -> form chi tiết read-only đủ field (kể cả TableId ẩn)
        private void DgvTableStatus_CellDoubleClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            RecordDetail.FromRow(dgvTableStatus.Rows[e.RowIndex], "Chi tiết bàn")
                        .ShowDialog(MsgBox.OwnerWindow(this));
        }

        // "Chi tiết" bàn đang chọn. (Trước đây là "Sửa" qua RecordEdit — chỉ sửa dòng grid
        // in-memory, không lưu DB, poll 8s sau ghi đè lại → logic giả, đã bỏ. Trạng thái ở
        // đây là dữ liệu suy ra từ đơn hàng, tự cập nhật theo POS/KDS, không sửa tay.)
        private void BtnEditTable_Click(object? sender, EventArgs e)
        {
            if (dgvTableStatus.CurrentRow == null || dgvTableStatus.CurrentRow.Index < 0)
            {
                MsgBox.Show(MsgBox.OwnerWindow(this), "Vui lòng chọn một bàn để xem!", "Thông báo", MsgBox.MessageBoxType.Warning);
                return;
            }
            RecordDetail.FromRow(dgvTableStatus.CurrentRow, "Chi tiết bàn")
                        .ShowDialog(MsgBox.OwnerWindow(this));
        }

        private void btnFilterTable_Click(object sender, EventArgs e)
        {
            if (cboTableStatus.SelectedItem == null || _originalTableData == null) return;

            string? selectedStatus = cboTableStatus.SelectedItem.ToString();

            if (selectedStatus == "Tất cả")
            {
                dgvTableStatus.DataSource = _originalTableData;
            }
            else
            {
                var filteredData = _originalTableData
                                    .Where(table => table.Status == selectedStatus)
                                    .ToList();

                dgvTableStatus.DataSource = filteredData;
            }
        }

        private void lstSoldOut_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        // "Cập nhật" → mở bảng quản lý còn/hết hàng cho TOÀN BỘ món (tick = còn bán).
        // Lưu các thay đổi qua FoodBUS.UpdateFood rồi tải lại tình trạng bàn/bếp/hết món.
        private async void BtnUpdateSoldOut_Click(object? sender, EventArgs e)
        {
            List<FoodDTO> foods;
            try { foods = await Task.Run(FoodBUS.GetListFoods); }
            catch (Exception ex)
            {
                MsgBox.Show(MsgBox.OwnerWindow(this), $"Không tải được danh sách món: {ex.Message}", "Lỗi", MsgBox.MessageBoxType.Error);
                return;
            }
            if (foods.Count == 0)
            {
                MsgBox.Show(MsgBox.OwnerWindow(this), "Chưa có món nào trong thực đơn.", "Thông báo", MsgBox.MessageBoxType.Info);
                return;
            }
            foods = foods.OrderBy(f => f.Name).ToList();

            var owner = MsgBox.OwnerWindow(this);
            using var form = WindowChrome.CreateDialog("Cập nhật tình trạng món", new Size(420, 470), out var content, owner);

            var clb = new CheckedListBox
            {
                Dock = DockStyle.Fill,
                BorderStyle = BorderStyle.None,
                BackColor = Color.FromArgb(31, 31, 34),
                ForeColor = Color.White,
                CheckOnClick = true,
                IntegralHeight = false,
                Font = Theme.F(10.5F),
            };
            foreach (var f in foods) clb.Items.Add(f.Name ?? f.Id ?? "(?)", f.InStock);

            var lblHint = new Label
            {
                Text = "Tích ô = còn bán · bỏ tích = tạm hết",
                Dock = DockStyle.Top,
                Height = 36,
                BackColor = Color.Transparent,
                ForeColor = Theme.TextMuted,
                Font = Theme.F(9F),
                TextAlign = ContentAlignment.MiddleLeft,
                Padding = new Padding(14, 0, 0, 0),
            };

            var btnSave = new Guna2Button
            {
                Text = "Lưu thay đổi",
                Size = new Size(150, 38),
                BorderRadius = 8,
                FillColor = Theme.Teal,
                ForeColor = Color.White,
                Font = Theme.F(9.5F, FontStyle.Bold),
                Cursor = Cursors.Hand,
                Anchor = AnchorStyles.Top | AnchorStyles.Right,
            };
            btnSave.HoverState.FillColor = Theme.TealHover;
            var pnlBtn = new Panel { Dock = DockStyle.Bottom, Height = 58, BackColor = Color.Transparent };
            pnlBtn.Controls.Add(btnSave);

            content.Controls.Add(clb);      // Fill trước
            content.Controls.Add(lblHint);  // Top
            content.Controls.Add(pnlBtn);   // Bottom
            form.Shown += (s, ev) => btnSave.Location = new Point(pnlBtn.ClientSize.Width - btnSave.Width - 16, 10);

            int changedCount = 0;
            btnSave.Click += async (s, ev) =>
            {
                btnSave.Enabled = false;
                btnSave.Text = "Đang lưu...";
                var errors = new List<string>();
                for (int i = 0; i < foods.Count; i++)
                {
                    bool inStock = clb.GetItemChecked(i);
                    if (inStock == foods[i].InStock) continue;
                    var food = foods[i];
                    food.InStock = inStock;
                    try
                    {
                        var (ok, msg) = await FoodBUS.UpdateFood(food);
                        if (ok) changedCount++;
                        else errors.Add($"• {food.Name}: {msg}");
                    }
                    catch (Exception ex) { errors.Add($"• {food.Name}: {ex.Message}"); }
                }
                if (errors.Count > 0)
                    MsgBox.Show(form, "Một số món chưa cập nhật được:\n" + string.Join("\n", errors), "Lỗi", MsgBox.MessageBoxType.Warning);
                form.DialogResult = DialogResult.OK;
                form.Close();
            };

            if (form.ShowDialog(owner) == DialogResult.OK)
            {
                await LoadRealData();
                if (changedCount > 0)
                    MsgBox.Show(owner, $"Đã cập nhật tình trạng {changedCount} món.", "Thành công", MsgBox.MessageBoxType.Success);
            }
        }

        private void cboTableStatus_TextChanged(object sender, EventArgs e)
        {

        }

        // "Dọn đơn treo": huỷ các đơn bếp (pending/dang_phuc_vu) treo quá StaleOrderHours
        // và trả các bàn "co_khach" không còn đơn hoạt động về "trong". Xử lý tình huống
        // thực tế: ca trước quên đóng đơn/quên thanh toán làm sơ đồ bàn và cảnh báo bếp kẹt rác.
        private async void BtnCleanStale_Click(object? sender, EventArgs e)
        {
            var owner = MsgBox.OwnerWindow(this);
            btnCleanStale.Enabled = false;
            try
            {
                var orders = await Task.Run(OrderBUS.GetAll);
                var tables = await Task.Run(TableBUS.GetAll);
                var payments = await Task.Run(PaymentBUS.GetAll);

                long now = DateTimeOffset.Now.ToUnixTimeMilliseconds();
                long staleBefore = now - StaleOrderHours * 3600_000L;
                var paidIds = payments.Values.Where(p => p.OrderId != null).Select(p => p.OrderId!).ToHashSet();

                // 1) Đơn bếp treo quá hạn
                var stale = orders.Where(o => (o.Value.Status == "pending" || o.Value.Status == "dang_phuc_vu")
                                              && o.Value.CreatedAt > 0 && o.Value.CreatedAt < staleBefore)
                                  .ToList();

                // 2) Bàn "co_khach" không còn đơn hoạt động (sau khi huỷ nhóm trên)
                var staleIds = stale.Select(x => x.Key).ToHashSet();
                var activeTables = orders
                    .Where(o => !staleIds.Contains(o.Key) && o.Value.TableId != null)
                    .Where(o => o.Value.Status == "pending" || o.Value.Status == "dang_phuc_vu"
                             || (o.Value.Status == "hoan_thanh" && !paidIds.Contains(o.Key) && o.Value.CreatedAt >= staleBefore))
                    .Select(o => o.Value.TableId!).ToHashSet();
                var freeable = tables.Where(t => t.Value.Status == "co_khach" && !activeTables.Contains(t.Key)).ToList();

                if (stale.Count == 0 && freeable.Count == 0)
                {
                    MsgBox.Show(owner, "Không có đơn treo hay bàn kẹt nào — dữ liệu đang sạch.", "Dọn đơn treo", MsgBox.MessageBoxType.Info);
                    return;
                }

                string detail = string.Join("\n", stale.Take(8).Select(x =>
                {
                    string tName = (x.Value.TableId != null && tables.TryGetValue(x.Value.TableId, out var tb)) ? (tb.Name ?? x.Value.TableId) : "Mang đi";
                    int ageMin = (int)((now - x.Value.CreatedAt) / 60000);
                    return $"  • {tName} — treo {WarningWaitModelDTO.FormatWait(ageMin)}";
                }));
                if (stale.Count > 8) detail += $"\n  … và {stale.Count - 8} đơn nữa";

                if (MsgBox.Show(owner,
                        $"Tìm thấy {stale.Count} đơn bếp treo quá {StaleOrderHours} giờ và {freeable.Count} bàn kẹt \"có khách\".\n\n" +
                        (detail.Length > 0 ? detail + "\n\n" : "") +
                        "Huỷ các đơn treo (giữ lịch sử, đánh dấu \"huy\") và trả bàn về trống?",
                        "Dọn đơn treo", MsgBox.MessageBoxType.Warning) != DialogResult.Yes)
                    return;

                int okOrders = 0, okTables = 0;
                var errors = new List<string>();
                foreach (var (id, ord) in stale)
                {
                    var (ok, msg) = await OrderBUS.Update(id, new
                    {
                        trang_thai = "huy",
                        ghi_chu = (string.IsNullOrEmpty(ord.Note) ? "" : ord.Note + " | ") +
                                  $"Huỷ bởi quản lý: đơn treo quá {StaleOrderHours} giờ"
                    });
                    if (ok) okOrders++; else errors.Add($"• Đơn {id}: {msg}");
                }
                foreach (var (tid, _) in freeable)
                {
                    var (ok, msg) = await TableBUS.Update(tid, new { trang_thai = "trong" });
                    if (ok) okTables++; else errors.Add($"• Bàn {tid}: {msg}");
                }

                await LoadRealData(force: true);
                string result = $"Đã huỷ {okOrders} đơn treo, trả {okTables} bàn về trống.";
                if (errors.Count > 0) result += "\n\nLỗi:\n" + string.Join("\n", errors);
                MsgBox.Show(owner, result, "Dọn đơn treo",
                            errors.Count == 0 ? MsgBox.MessageBoxType.Success : MsgBox.MessageBoxType.Warning);
            }
            catch (Exception ex)
            {
                MsgBox.Show(owner, $"Không dọn được: {ex.Message}", "Lỗi", MsgBox.MessageBoxType.Error);
            }
            finally { btnCleanStale.Enabled = true; }
        }

        // Double-click 1 cảnh báo -> đánh dấu món ĐÃ LÊN thật trong DB (trước đây chỉ xoá
        // khỏi UI nên poll kế tiếp lại hiện, và bếp/POS không hề biết).
        private async void lstKitchenWarning_DoubleClick(object sender, EventArgs e)
        {
            if (lstKitchenWarning.SelectedItem is not WarningWaitModelDTO w
                || w.OrderId == null || w.ItemKey == null) return;

            var owner = MsgBox.OwnerWindow(this);
            if (MsgBox.Show(owner, $"Đánh dấu \"{w.DrinkName}\" ({w.TableName}) đã lên món cho khách?",
                            "Xác nhận", MsgBox.MessageBoxType.Warning) != DialogResult.Yes) return;

            try
            {
                var orders = await Task.Run(OrderBUS.GetAll);
                if (!orders.TryGetValue(w.OrderId, out var ord) || ord.Items == null
                    || !ord.Items.ContainsKey(w.ItemKey))
                {
                    // Đơn đã bị đóng/sửa ở màn khác — tải lại cho khớp thực tế
                    await LoadRealData(force: true);
                    return;
                }

                ord.Items[w.ItemKey].CookingStatus = "hoan_thanh";
                bool allDone = ord.Items.Values.All(it => it.CookingStatus == "hoan_thanh");
                object payload = allDone
                    ? new { chi_tiet_don = ord.Items, trang_thai = "hoan_thanh" } // món cuối → cả đơn xong, KDS tự chuyển cột
                    : new { chi_tiet_don = ord.Items };

                var (ok, msg) = await OrderBUS.Update(w.OrderId, payload);
                if (!ok)
                {
                    MsgBox.Show(owner, $"Không cập nhật được: {msg}", "Lỗi", MsgBox.MessageBoxType.Error);
                    return;
                }
                await LoadRealData(force: true);
            }
            catch (Exception ex)
            {
                MsgBox.Show(owner, $"Không cập nhật được: {ex.Message}", "Lỗi", MsgBox.MessageBoxType.Error);
            }
        }
    }
}