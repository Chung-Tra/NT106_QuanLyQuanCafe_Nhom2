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
        private List<TableModelDTO>? _originalTableData;
        private List<WarningWaitModelDTO> _kitchenWarnings = new();

        public ucOrders_Manager()
        {
            InitializeComponent();
            GridColumnGuard.SyncColumnNames(dgvTableStatus);
            DgvRefresh.Attach(dgvTableStatus, () => _ = LoadRealData());

            cboTableStatus.Items.Clear();
            cboTableStatus.Items.AddRange(TableStatusOptions);
            cboTableStatus.SelectedIndex = 0;

            _ = LoadRealData();
        }

        // Tải tình trạng bàn/bếp thật từ Firebase: các đơn đang xử lý (pending/đang phục vụ).
        private async Task LoadRealData()
        {
            Dictionary<string, DTO.TableDTO> tables;
            Dictionary<string, DTO.OrderDTO> orders;
            Dictionary<string, string> foodNames;
            List<FoodDTO> foods;
            try
            {
                tables = await TableBUS.GetAll();
                orders = await OrderBUS.GetAll();
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

            var list = new List<TableModelDTO>();
            _kitchenWarnings = new();
            int idx = 0;

            foreach (var kv in orders.Where(o => o.Value.Status == "pending" || o.Value.Status == "dang_phuc_vu")
                                     .OrderBy(o => o.Value.CreatedAt))
            {
                var ord = kv.Value;
                string tableName = (ord.TableId != null && tables.TryGetValue(ord.TableId, out var tb))
                    ? (tb.Name ?? ord.TableId) : "Mang đi";

                var itemList = ord.Items?.Values ?? Enumerable.Empty<OrderItemDTO>();
                long total = itemList.Sum(it => (long)it.UnitPrice * it.Quantity);
                int pendingItems = itemList.Count(it => it.CookingStatus != "hoan_thanh");

                string status = (ord.Status == "pending" || pendingItems > 0) ? "Chờ lên món" : "Đang phục vụ";
                string progress = pendingItems > 0 ? $"Thiếu {pendingItems} món" : "Đã lên đủ";

                list.Add(new TableModelDTO
                {
                    TableId = ++idx,
                    TableName = tableName,
                    Status = status,
                    Progress = progress,
                    TotalAmount = total.ToString("N0") + " đ"
                });

                // Cảnh báo món chờ lâu
                int waitMin = ord.CreatedAt > 0 ? (int)((now - ord.CreatedAt) / 60000) : 0;
                foreach (var it in itemList.Where(it => it.CookingStatus != "hoan_thanh"))
                    _kitchenWarnings.Add(new WarningWaitModelDTO
                    {
                        TableName = tableName,
                        DrinkName = FoodName(it.FoodId),
                        WaitTimeMinutes = waitMin
                    });
            }

            _originalTableData = list;
            dgvTableStatus.DataSource = null;
            dgvTableStatus.DataSource = _originalTableData;
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
            lstKitchenWarning.DataSource = _kitchenWarnings;
            lstKitchenWarning.DisplayMember = "DisplayText";

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

        // Sửa bàn đang chọn (khoá TableId)
        private void BtnEditTable_Click(object? sender, EventArgs e)
        {
            if (dgvTableStatus.CurrentRow == null || dgvTableStatus.CurrentRow.Index < 0)
            {
                MsgBox.Show(MsgBox.OwnerWindow(this), "Vui lòng chọn một bàn để sửa!", "Thông báo", MsgBox.MessageBoxType.Warning);
                return;
            }
            if (RecordEdit.EditRow(dgvTableStatus.CurrentRow, "Sửa thông tin bàn", MsgBox.OwnerWindow(this)))
                dgvTableStatus.Refresh();
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

        private void lstKitchenWarning_DoubleClick(object sender, EventArgs e)
        {
            // Kiểm tra xem người dùng có đang bấm vào một dòng dữ liệu hợp lệ hay không
            if (lstKitchenWarning.SelectedItem != null)
            {
                // 1. Lấy thông tin dòng vừa được double-click và ép kiểu về WarningWaitModel
                var monDaXong = (WarningWaitModelDTO)lstKitchenWarning.SelectedItem;

                // 2. Xóa món này khỏi danh sách dữ liệu gốc
                _kitchenWarnings.Remove(monDaXong);

                // 3. Cập nhật (Refresh) lại ListBox để dòng chữ biến mất khỏi màn hình
                lstKitchenWarning.DataSource = null;
                lstKitchenWarning.DataSource = _kitchenWarnings;
                lstKitchenWarning.DisplayMember = "DisplayText";
            }
        }
    }
}