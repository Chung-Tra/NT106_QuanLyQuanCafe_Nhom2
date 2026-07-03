using System;
using System.Data;
using System.Drawing;
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
            LoadHistory();

            // Double-click 1 dòng -> form chi tiết read-only đủ field
            dgvHistory.CellDoubleClick += (s, e) =>
            {
                if (e.RowIndex < 0) return;
                RecordDetail.FromRow(dgvHistory.Rows[e.RowIndex], "Chi tiết thông báo")
                            .ShowDialog(MsgBox.OwnerWindow(this));
            };
        }

        private void BtnNew_Click(object? sender, EventArgs e)
        {
            using var dlg = new SendBroadcast();
            if (dlg.ShowDialog(MsgBox.OwnerWindow(this)) == DialogResult.OK)
            {
                MsgBox.Show(MsgBox.OwnerWindow(this), "Đã gửi thông báo!", "Thành công", MsgBox.MessageBoxType.Success);
                LoadHistory();
            }
        }

        private void BtnRefresh_Click(object? sender, EventArgs e)
        {
            LoadHistory();
        }

        private void txtSearch_TextChanged(object? sender, EventArgs e)
        {
            ApplyFilter();
        }

        private void LoadHistory()
        {
            var dt = new DataTable();
            dt.Columns.Add("Thời gian");
            dt.Columns.Add("Người nhận");
            dt.Columns.Add("Tiêu đề");
            dt.Columns.Add("Mức độ");
            dt.Columns.Add("Đã đọc");
            dt.Columns.Add("Trạng thái");

            dt.Rows.Add("06/05 19:20", "Toàn bộ NV", "Họp giao ban tuần 5/5",   "Thường",      "5/8",  "Đã gửi");
            dt.Rows.Add("06/05 14:05", "NV002 - Bích",  "Yêu cầu giải trình muộn 05/05", "Quan trọng !", "1/1",  "Đã đọc");
            dt.Rows.Add("06/05 09:15", "Toàn bộ NV", "Cập nhật giờ làm thứ 7",    "Thường",      "7/8",  "Đã gửi");
            dt.Rows.Add("05/05 21:30", "Toàn bộ Pha chế",   "Thay đổi công thức Latte",  "Khẩn cấp !!!", "3/3",  "Đã đọc");
            dt.Rows.Add("05/05 16:50", "NV004 - Tuấn",  "Lịch trực ca tối nay",       "Thường",      "1/1",  "Đã đọc");
            dt.Rows.Add("04/05 11:00", "Toàn bộ NV", "Thông báo nghỉ lễ 30/4-1/5", "Quan trọng !", "8/8",  "Đã đọc");

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
                    "Khẩn cấp !!!" => Color.IndianRed,
                    "Quan trọng !" => Color.Orange,
                    _              => Color.LightGray
                };

                string status = row.Cells["Trạng thái"].Value?.ToString() ?? "";
                row.Cells["Trạng thái"].Style.ForeColor =
                    status == "Đã đọc" ? Color.MediumSeaGreen : Color.SteelBlue;
            }

            lblTotal.Text = $"Tổng đã gửi: {dt.Rows.Count}";
            lblToday.Text = "Hôm nay: 3";
        }

        private void ApplyFilter()
        {
            if (dgvHistory.DataSource is not DataTable dt) return;
            // Quét mọi cột: thời gian, người nhận, tiêu đề, mức độ, đã đọc, trạng thái
            dt.DefaultView.RowFilter = SearchFilter.AllColumnsFilter(dt, txtSearch.Text);
        }
    }
}
