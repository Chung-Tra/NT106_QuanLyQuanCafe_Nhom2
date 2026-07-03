using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace GUI
{
    public partial class ucReservation_Order : UserControl
    {
        private DataTable _dt = null!;

        public ucReservation_Order()
        {
            InitializeComponent();

            // Runtime styling for the grid (declared in Designer)
            Theme.StyleGrid(dgv);

            // Default selection + dynamic event subscriptions
            cmbStatus.SelectedIndex = 0;
            txtSearch.TextChanged += (s, e) => ApplyFilter();
            cmbStatus.SelectedIndexChanged += (s, e) => ApplyFilter();
            btnSendReminder.Click += (s, e) => MsgBox.Show(MsgBox.OwnerWindow(this), "Đã gửi email nhắc đến 3 khách có đặt bàn hôm nay!", "Gửi nhắc thành công", MsgBox.MessageBoxType.Success);

            DgvRefresh.Attach(dgv, LoadData);

            Load += (s, e) => LoadData();
        }

        private void LoadData()
        {
            _dt = new DataTable();
            _dt.Columns.Add("Mã đặt");
            _dt.Columns.Add("Họ tên");
            _dt.Columns.Add("SĐT");
            _dt.Columns.Add("Ngày & Giờ");
            _dt.Columns.Add("Bàn");
            _dt.Columns.Add("Số khách", typeof(int));
            _dt.Columns.Add("Ghi chú");
            _dt.Columns.Add("Trạng thái");

            _dt.Rows.Add("RES-001", "Nguyễn Thị Lan",  "0912345678", "24/06/2026 18:00", "Bàn 05 (4 chỗ)", 3, "Cần ghế cao cho bé",    "Đã xác nhận");
            _dt.Rows.Add("RES-002", "Trần Văn Bảo",    "0987654321", "24/06/2026 19:30", "Bàn 08 (6 chỗ)", 5, "Kỷ niệm ngày cưới",     "Chờ xác nhận");
            _dt.Rows.Add("RES-003", "Lê Quốc Hùng",    "0901111222", "25/06/2026 12:00", "Bàn 02 (2 chỗ)", 2, "",                       "Đã xác nhận");
            _dt.Rows.Add("RES-004", "Phạm Thị Ngọc",   "0933445566", "25/06/2026 15:00", "Bàn 10 (8 chỗ)", 7, "Tiệc sinh nhật — bánh", "Chờ xác nhận");
            _dt.Rows.Add("RES-005", "Đinh Minh Quân",  "0977889900", "26/06/2026 11:30", "Bàn 03 (4 chỗ)", 4, "",                       "Đã xác nhận");
            _dt.Rows.Add("RES-006", "Hoàng Thu Trang",  "0905551234", "23/06/2026 17:00", "Bàn 06 (4 chỗ)", 3, "Ăn trưa làm việc",      "Đã đến");
            _dt.Rows.Add("RES-007", "Vũ Thế Anh",       "0966778899", "22/06/2026 19:00", "Bàn 01 (2 chỗ)", 2, "",                       "Hủy");

            ApplyFilter();
        }

        private void ApplyFilter()
        {
            if (_dt == null) return;
            string status = cmbStatus.SelectedIndex > 0 ? cmbStatus.SelectedItem?.ToString() ?? "" : "";

            var parts = new System.Collections.Generic.List<string>();
            // Từ khóa quét mọi cột: mã đặt, họ tên, SĐT, ngày giờ, bàn, số khách, ghi chú, trạng thái
            string kwFilter = SearchFilter.AllColumnsFilter(_dt, txtSearch.Text);
            if (!string.IsNullOrEmpty(kwFilter))
                parts.Add(kwFilter);
            if (!string.IsNullOrEmpty(status))
                parts.Add($"[Trạng thái] = '{status}'");

            try { _dt.DefaultView.RowFilter = string.Join(" AND ", parts); }
            catch { _dt.DefaultView.RowFilter = ""; }

            dgv.DataSource = _dt.DefaultView.ToTable();

            if (dgv.Columns.Count > 0)
            {
                dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                if (dgv.Columns.Contains("Mã đặt"))      dgv.Columns["Mã đặt"].FillWeight      = 7;
                if (dgv.Columns.Contains("Họ tên"))      dgv.Columns["Họ tên"].FillWeight      = 14;
                if (dgv.Columns.Contains("SĐT"))         dgv.Columns["SĐT"].FillWeight         = 10;
                if (dgv.Columns.Contains("Ngày & Giờ"))  dgv.Columns["Ngày & Giờ"].FillWeight  = 14;
                if (dgv.Columns.Contains("Bàn"))         dgv.Columns["Bàn"].FillWeight         = 11;
                if (dgv.Columns.Contains("Số khách"))    dgv.Columns["Số khách"].FillWeight    = 7;
                if (dgv.Columns.Contains("Ghi chú"))     dgv.Columns["Ghi chú"].FillWeight     = 20;
                if (dgv.Columns.Contains("Trạng thái"))  dgv.Columns["Trạng thái"].FillWeight  = 12;

                ColorStatusColumn();
            }

            lblCount.Text = $"{dgv.Rows.Count} lượt đặt";
        }

        private void ColorStatusColumn()
        {
            foreach (DataGridViewRow row in dgv.Rows)
            {
                string s = row.Cells["Trạng thái"].Value?.ToString() ?? "";
                row.Cells["Trạng thái"].Style.ForeColor = s switch
                {
                    "Đã xác nhận"  => Theme.Green,
                    "Chờ xác nhận" => Theme.Amber,
                    "Đã đến"       => Theme.Teal,
                    "Hủy"          => Theme.Red,
                    _              => Theme.TextPri,
                };
            }
        }

        // Double-click 1 dòng -> form chi tiết read-only đủ field
        private void DgvRes_CellDoubleClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            RecordDetail.FromRow(dgv.Rows[e.RowIndex], "Chi tiết đặt bàn")
                        .ShowDialog(MsgBox.OwnerWindow(this));
        }

        // Sửa đặt bàn đang chọn (khoá Mã đặt). Ghi ngược về nguồn _dt rồi lọc lại.
        private void BtnEditRes_Click(object? sender, EventArgs e)
        {
            if (dgv.CurrentRow == null || dgv.CurrentRow.Index < 0)
            {
                MsgBox.Show(MsgBox.OwnerWindow(this), "Vui lòng chọn một lượt đặt để sửa!", "Thông báo", MsgBox.MessageBoxType.Warning);
                return;
            }

            string code = dgv.CurrentRow.Cells["Mã đặt"].Value?.ToString() ?? "";
            if (!RecordEdit.EditRow(dgv.CurrentRow, "Sửa đặt bàn", MsgBox.OwnerWindow(this))) return;

            // Bảng đang bind là bản sao (ToTable) -> đồng bộ giá trị đã sửa về _dt theo Mã đặt
            foreach (DataRow r in _dt.Rows)
            {
                if ((r["Mã đặt"]?.ToString() ?? "") != code) continue;
                foreach (DataColumn c in _dt.Columns)
                {
                    if (c.ColumnName == "Mã đặt") continue;
                    if (!dgv.Columns.Contains(c.ColumnName)) continue;
                    try { r[c.ColumnName] = dgv.CurrentRow.Cells[c.ColumnName].Value ?? DBNull.Value; }
                    catch { /* bỏ qua nếu sai kiểu */ }
                }
                break;
            }
            ApplyFilter();
        }

        private void BtnAdd_Click(object? sender, EventArgs e)
        {
            string? name = InputDialog.Show(MsgBox.OwnerWindow(this), "Đặt bàn mới", "Họ tên khách hàng", "VD: Nguyễn Văn A");
            if (string.IsNullOrEmpty(name)) return;
            string id = "RES-" + (_dt.Rows.Count + 1).ToString("000");
            _dt.Rows.Add(id, name, "---", DateTime.Now.AddHours(2).ToString("dd/MM/yyyy HH:mm"), "Chọn bàn", 2, "", "Chờ xác nhận");
            ApplyFilter();
            MsgBox.Show(MsgBox.OwnerWindow(this), $"Đã tạo đặt bàn {id} cho {name}. Vui lòng bổ sung SĐT và giờ trong bảng.", "Thành công", MsgBox.MessageBoxType.Success);
        }
    }
}
