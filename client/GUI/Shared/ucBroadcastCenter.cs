using BUS;
using DTO;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    // Trung tâm phát thông báo nội bộ.
    // - Hiển thị lịch sử thông báo đã gửi (status, người nhận, thời gian)
    // - Nút "Soạn thông báo mới" mở `SendBroadcast` dialog
    public partial class ucBroadcastCenter : UserControl
    {
        public ucBroadcastCenter()
        {
            InitializeComponent();
            GridColumnGuard.SyncColumnNames(dgvHistory);
            _ = LoadHistory();

            // Double-click 1 dòng -> form chi tiết read-only đủ field
            dgvHistory.CellDoubleClick += (s, e) =>
            {
                if (e.RowIndex < 0) return;
                RecordDetail.FromRow(dgvHistory.Rows[e.RowIndex], "Chi tiết thông báo")
                            .ShowDialog(MsgBox.OwnerWindow(this));
            };
        }

        private async void BtnNew_Click(object? sender, EventArgs e)
        {
            using var dlg = new SendBroadcast();
            if (dlg.ShowDialog(MsgBox.OwnerWindow(this)) != DialogResult.OK) return;

            var dto = new BroadcastDTO
            {
                Timestamp = DateTimeOffset.Now.ToUnixTimeMilliseconds(),
                SenderId = GlobalSession.CurrentUser?.EmployeeId,
                NguoiNhan = dlg.Recipient,
                TieuDe = dlg.Title,
                NoiDung = dlg.Content,
                MucDo = dlg.Priority,
                DaDoc = false,
                TrangThai = "Đã gửi"
            };
            var (ok, msg, _) = await BroadcastBUS.Add(dto);
            if (ok)
            {
                MsgBox.Show(MsgBox.OwnerWindow(this), "Đã gửi thông báo!", "Thành công", MsgBox.MessageBoxType.Success);
                await LoadHistory();
            }
            else MsgBox.Show(MsgBox.OwnerWindow(this), msg, "Lỗi", MsgBox.MessageBoxType.Error);
        }

        private void BtnRefresh_Click(object? sender, EventArgs e) => _ = LoadHistory();

        private void txtSearch_TextChanged(object? sender, EventArgs e) => ApplyFilter();

        private async Task LoadHistory()
        {
            var dt = new DataTable();
            dt.Columns.Add("Thời gian");
            dt.Columns.Add("Người nhận");
            dt.Columns.Add("Tiêu đề");
            dt.Columns.Add("Mức độ");
            dt.Columns.Add("Đã đọc");
            dt.Columns.Add("Trạng thái");

            int today = 0;
            try
            {
                var all = await BroadcastBUS.GetAll();
                foreach (var kv in all.OrderByDescending(x => x.Value.Timestamp))
                {
                    var b = kv.Value;
                    var when = b.Timestamp > 0 ? DateTimeOffset.FromUnixTimeMilliseconds(b.Timestamp).LocalDateTime : DateTime.MinValue;
                    if (when.Date == DateTime.Today) today++;
                    dt.Rows.Add(when == DateTime.MinValue ? "" : when.ToString("dd/MM HH:mm"),
                        b.NguoiNhan, b.TieuDe, b.MucDo, b.DaDoc ? "Đã đọc" : "Chưa", b.TrangThai);
                }
            }
            catch { /* offline */ }

            dgvHistory.DataSource = dt;
            dgvHistory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvHistory.Columns["Thời gian"].FillWeight  = 13;
            dgvHistory.Columns["Người nhận"].FillWeight = 15;
            dgvHistory.Columns["Tiêu đề"].FillWeight    = 36;
            dgvHistory.Columns["Mức độ"].FillWeight     = 12;
            dgvHistory.Columns["Đã đọc"].FillWeight     = 9;
            dgvHistory.Columns["Trạng thái"].FillWeight = 15;

            foreach (DataGridViewRow row in dgvHistory.Rows)
            {
                string level = row.Cells["Mức độ"].Value?.ToString() ?? "";
                row.Cells["Mức độ"].Style.ForeColor = level switch
                {
                    "Khẩn cấp" => Color.IndianRed,
                    "Quan trọng" => Color.Orange,
                    _ => Color.LightGray
                };
                string status = row.Cells["Trạng thái"].Value?.ToString() ?? "";
                row.Cells["Trạng thái"].Style.ForeColor =
                    status == "Đã đọc" ? Color.MediumSeaGreen : Color.SteelBlue;
            }

            lblTotal.Text = $"Tổng đã gửi: {dt.Rows.Count}";
            lblToday.Text = $"Hôm nay: {today}";
        }

        private void ApplyFilter()
        {
            if (dgvHistory.DataSource is not DataTable dt) return;
            // Quét mọi cột: thời gian, người nhận, tiêu đề, mức độ, đã đọc, trạng thái
            dt.DefaultView.RowFilter = SearchFilter.AllColumnsFilter(dt, txtSearch.Text);
        }
    }
}
