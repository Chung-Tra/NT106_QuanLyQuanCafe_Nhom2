using DTO;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace GUI
{
#pragma warning disable IDE1006
    public partial class ucLeaveRequest : UserControl
#pragma warning restore IDE1006
    {
        public ucLeaveRequest()
        {
            InitializeComponent();
            GridColumnGuard.SyncColumnNames(dgvHistory);

            // Double-click 1 đơn -> form chi tiết read-only đủ field
            dgvHistory.CellDoubleClick += (s, e) =>
            {
                if (e.RowIndex < 0) return;
                RecordDetail.FromRow(dgvHistory.Rows[e.RowIndex], "Chi tiết đơn nghỉ phép")
                            .ShowDialog(MsgBox.OwnerWindow(this));
            };

            DgvRefresh.Attach(dgvHistory, LoadMockData);
        }

        private void UcLeaveRequest_Load(object? sender, EventArgs e)
        {
            // 1. Phân quyền hiển thị nút "Quản lý nghỉ"
            var user = GlobalSession.CurrentUser;
            bool isPrivileged = user?.Role?.ToLower() is "admin" or "manager";

            btnManager.Visible = isPrivileged;

            // 2. Tải dữ liệu bảng (Mock Data)
            LoadMockData();
        }

        private void LoadMockData()
        {
            lblRemainingValue.Text = "8 ngày";
            lblPendingValue.Text = "1 đơn";

            DataTable dt = new();
            dt.Columns.Add("Từ ngày");
            dt.Columns.Add("Đến ngày");
            dt.Columns.Add("Số ngày", typeof(int));
            dt.Columns.Add("Lý do");
            dt.Columns.Add("Trạng thái");

            dt.Rows.Add("15/04/2026", "16/04/2026", 2, "Việc gia đình", "Đã duyệt");
            dt.Rows.Add("20/03/2026", "20/03/2026", 1, "Khám bệnh", "Đã duyệt");
            dt.Rows.Add("10/03/2026", "10/03/2026", 1, "Việc cá nhân", "Đã duyệt");
            dt.Rows.Add("05/05/2026", "05/05/2026", 1, "Đi thi", "Chờ duyệt");

            dgvHistory.DataSource = dt;
            dgvHistory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvHistory.RowHeadersVisible = false;
            dgvHistory.ReadOnly = true;
            dgvHistory.AllowUserToAddRows = false;
            // Cân bề rộng mọi cột: "Lý do" cần rộng để không bị cắt ("Việc gia ...").
            dgvHistory.Columns["Từ ngày"].FillWeight    = 18;
            dgvHistory.Columns["Đến ngày"].FillWeight   = 18;
            dgvHistory.Columns["Số ngày"].FillWeight    = 10;
            dgvHistory.Columns["Lý do"].FillWeight      = 34;
            dgvHistory.Columns["Trạng thái"].FillWeight = 20;

            foreach (DataGridViewRow row in dgvHistory.Rows)
            {
                string status = row.Cells["Trạng thái"].Value?.ToString() ?? "";
                if (status == "Đã duyệt")
                    row.DefaultCellStyle.ForeColor = Color.MediumSeaGreen;
                else if (status == "Chờ duyệt")
                    row.DefaultCellStyle.ForeColor = Color.Orange;
                else if (status == "Từ chối")
                    row.DefaultCellStyle.ForeColor = Color.IndianRed;
            }
        }

        private void BtnSubmit_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtReason.Text))
            {
                MsgBox.Show(MsgBox.OwnerWindow(this), "Vui lòng nhập lý do nghỉ phép!", "Thông báo", MsgBox.MessageBoxType.Warning);
                return;
            }

            if (dtpToDate.Value < dtpFromDate.Value)
            {
                MsgBox.Show(MsgBox.OwnerWindow(this), "Ngày kết thúc phải sau ngày bắt đầu!", "Thông báo", MsgBox.MessageBoxType.Warning);
                return;
            }

            int days = (dtpToDate.Value - dtpFromDate.Value).Days + 1;

            if (dgvHistory.DataSource is DataTable dt)
            {
                DataRow newRow = dt.NewRow();
                newRow["Từ ngày"] = dtpFromDate.Value.ToString("dd/MM/yyyy");
                newRow["Đến ngày"] = dtpToDate.Value.ToString("dd/MM/yyyy");
                newRow["Số ngày"] = days;
                newRow["Lý do"] = txtReason.Text;
                newRow["Trạng thái"] = "Chờ duyệt";
                dt.Rows.InsertAt(newRow, 0);
            }

            MsgBox.Show(
                MsgBox.OwnerWindow(this),
                $"Đã gửi đơn xin nghỉ {days} ngày!\nTừ: {dtpFromDate.Value:dd/MM/yyyy}\nĐến: {dtpToDate.Value:dd/MM/yyyy}",
                "Gửi thành công",
                MsgBox.MessageBoxType.Success);
            txtReason.Clear();
        }

        private void BtnReport_Click(object? sender, EventArgs e)
        {
            string report =
                "BÁO CÁO NGHỈ PHÉP\n" +
                "──────────────────\n" +
                $"• Ngày phép còn lại: {lblRemainingValue.Text}\n" +
                $"• Đang chờ duyệt: {lblPendingValue.Text}\n" +
                "──────────────────\n" +
                "Gửi báo cáo cho quản lý qua Chat?";

            var result = MsgBox.Show(MsgBox.OwnerWindow(this), report, "Báo cáo nghỉ phép", MsgBox.MessageBoxType.Warning);

            if (result == DialogResult.Yes)
            {
                MsgBox.Show(
                    MsgBox.OwnerWindow(this),
                    "Đã gửi báo cáo cho quản lý!\nQuản lý sẽ duyệt qua Chat nội bộ.",
                    "Thành công", MsgBox.MessageBoxType.Success);
            }
        }

        private void BtnManager_Click(object sender, EventArgs e)
        {
            Form popupForm = new Form();
            popupForm.Text = "Quản lý nghỉ / Lịch sử chấm công";
            popupForm.Size = new Size(1000, 650); // Kích thước cửa sổ (bạn có thể tự chỉnh lại số này)
            popupForm.StartPosition = FormStartPosition.CenterScreen; // Mở ra ở giữa màn hình

            // Tùy chọn làm đẹp: tắt nút phóng to, để viền cố định
            popupForm.FormBorderStyle = FormBorderStyle.FixedDialog;
            popupForm.MaximizeBox = false;

            // 2. Khởi tạo UserControl ucAttendanceHistory
            ucAttendanceHistory ucHistory = new ucAttendanceHistory();
            ucHistory.Dock = DockStyle.Fill; // Ép UserControl lấp đầy khoảng trống của Form

            // 3. Thêm UserControl vào Form
            popupForm.Controls.Add(ucHistory);

            // 4. Hiển thị cửa sổ lên màn hình (ShowDialog sẽ bắt người dùng phải đóng cửa sổ này mới thao tác được ở form cũ)
            popupForm.ShowDialog();
        }
    }
}
