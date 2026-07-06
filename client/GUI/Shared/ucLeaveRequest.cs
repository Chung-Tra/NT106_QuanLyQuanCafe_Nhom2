using BUS;
using DTO;
using System;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
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
            DgvRefresh.Attach(dgvHistory, () => _ = LoadRealData());
        }

        // Double-click 1 đơn -> form chi tiết read-only đủ field
        private void dgvHistory_CellDoubleClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            RecordDetail.FromRow(dgvHistory.Rows[e.RowIndex], "Chi tiết đơn nghỉ phép")
                        .ShowDialog(MsgBox.OwnerWindow(this));
        }

        private void UcLeaveRequest_Load(object? sender, EventArgs e)
        {
            var user = GlobalSession.CurrentUser;
            bool isPrivileged = user?.Role?.ToLower() is "admin" or "manager";
            btnManager.Visible = isPrivileged;

            _ = LoadRealData();
        }

        private static string StatusDisplay(string? s) => s switch
        {
            "da_duyet" => "Đã duyệt",
            "tu_choi" => "Từ chối",
            _ => "Chờ duyệt"
        };

        private async Task LoadRealData()
        {
            DataTable dt = new();
            dt.Columns.Add("Từ ngày");
            dt.Columns.Add("Đến ngày");
            dt.Columns.Add("Số ngày", typeof(int));
            dt.Columns.Add("Lý do");
            dt.Columns.Add("Trạng thái");

            int pending = 0, usedThisYear = 0;
            string myId = GlobalSession.CurrentUser?.EmployeeId ?? "";
            try
            {
                var all = await LeaveRequestBUS.GetAll();
                foreach (var l in all.Values.Where(x => x.EmployeeId == myId)
                                            .OrderByDescending(x => x.SentAt))
                {
                    dt.Rows.Add(l.FromDate, l.ToDate, l.DayCount, l.Reason, StatusDisplay(l.Status));
                    if (l.Status == "cho_duyet") pending++;
                    if (l.Status == "da_duyet" &&
                        DateTime.TryParseExact(l.FromDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out var d)
                        && d.Year == DateTime.Now.Year)
                        usedThisYear += l.DayCount;
                }
            }
            catch { /* offline */ }

            lblRemainingValue.Text = $"{Math.Max(0, 12 - usedThisYear)} ngày";
            lblPendingValue.Text = $"{pending} đơn";

            dgvHistory.DataSource = dt;
            dgvHistory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvHistory.RowHeadersVisible = false;
            dgvHistory.ReadOnly = true;
            dgvHistory.AllowUserToAddRows = false;
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

        private async void BtnSubmit_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtReason.Text))
            {
                MsgBox.Show(MsgBox.OwnerWindow(this), "Vui lòng nhập lý do nghỉ phép!", "Thông báo", MsgBox.MessageBoxType.Warning);
                return;
            }
            if (dtpToDate.Value.Date < dtpFromDate.Value.Date)
            {
                MsgBox.Show(MsgBox.OwnerWindow(this), "Ngày kết thúc phải sau ngày bắt đầu!", "Thông báo", MsgBox.MessageBoxType.Warning);
                return;
            }

            int days = (dtpToDate.Value.Date - dtpFromDate.Value.Date).Days + 1;
            var owner = MsgBox.OwnerWindow(this);

            var dto = new LeaveRequestDTO
            {
                EmployeeId = GlobalSession.CurrentUser?.EmployeeId,
                FromDate = dtpFromDate.Value.ToString("dd/MM/yyyy"),
                ToDate = dtpToDate.Value.ToString("dd/MM/yyyy"),
                DayCount = days,
                Reason = txtReason.Text.Trim(),
                Status = "cho_duyet",
                SentAt = DateTimeOffset.Now.ToUnixTimeMilliseconds(),
                ApproverId = "",
                ApprovedAt = 0,
                ApprovalNote = ""
            };

            var (ok, msg, _) = await LeaveRequestBUS.Add(dto);
            if (ok)
            {
                MsgBox.Show(owner,
                    $"Đã gửi đơn xin nghỉ {days} ngày!\nTừ: {dto.FromDate}\nĐến: {dto.ToDate}",
                    "Gửi thành công", MsgBox.MessageBoxType.Success);
                txtReason.Clear();
                await LoadRealData();
            }
            else MsgBox.Show(owner, msg, "Lỗi gửi đơn", MsgBox.MessageBoxType.Error);
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
            // Popup theo theme app (không viền Windows, ẩn scrollbar gốc) thay cho Form thô.
            WindowChrome.ShowUc(new ucAttendanceHistory(), "Quản lý nghỉ / Lịch sử chấm công",
                                new Size(1000, 650), MsgBox.OwnerWindow(this));
        }
    }
}
