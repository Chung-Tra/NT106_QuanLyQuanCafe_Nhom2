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
    public partial class ucSOS_Security : UserControl
    {
        public ucSOS_Security()
        {
            InitializeComponent();
            GridColumnGuard.SyncColumnNames(dgvIncidents);
            DgvRefresh.Attach(dgvIncidents, () => _ = LoadRealData());
            this.Load += (s, e) => _ = LoadRealData();

            dgvIncidents.CellDoubleClick += (s, e) =>
            {
                if (e.RowIndex < 0) return;
                RecordDetail.FromRow(dgvIncidents.Rows[e.RowIndex], "Chi tiết sự cố")
                            .ShowDialog(MsgBox.OwnerWindow(this));
            };
        }

        private static string TypeDisplay(string? t) => t switch
        {
            "an_ninh" => "An ninh",
            "y_te" => "Y tế",
            "chay_no" => "Cháy nổ",
            "sos_khan_cap" => "SOS Khẩn cấp",
            _ => "Khác"
        };
        private static string StatusDisplay(string? s) => s == "da_xu_ly" ? "Đã xử lý" : "Đang xử lý";

        private async Task LoadRealData()
        {
            DataTable dt = new();
            dt.Columns.Add("Mã");
            dt.Columns.Add("Thời gian");
            dt.Columns.Add("Loại sự cố");
            dt.Columns.Add("Mô tả");
            dt.Columns.Add("Người báo");
            dt.Columns.Add("Trạng thái");

            try
            {
                var all = await IncidentBUS.GetAll();
                var emps = (await EmployeeBUS.GetAllEmployeesAsync())
                    .Where(x => x.EmployeeId != null)
                    .ToDictionary(x => x.EmployeeId!, x => x.FullName ?? x.EmployeeId!);

                foreach (var kv in all.OrderByDescending(i => i.Value.Timestamp))
                {
                    var i = kv.Value;
                    string time = i.Timestamp > 0
                        ? DateTimeOffset.FromUnixTimeMilliseconds(i.Timestamp).LocalDateTime.ToString("dd/MM/yyyy HH:mm") : "";
                    string reporter = (i.ReporterId != null && emps.TryGetValue(i.ReporterId, out var n)) ? n : (i.ReporterId ?? "");
                    dt.Rows.Add(kv.Key, time, TypeDisplay(i.Type), i.Description, reporter, StatusDisplay(i.Status));
                }
            }
            catch { /* offline */ }

            dgvIncidents.DataSource = dt;
            dgvIncidents.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvIncidents.RowHeadersVisible = false;
            if (dgvIncidents.Columns.Contains("Mã")) dgvIncidents.Columns["Mã"].Visible = false;
            dgvIncidents.Columns["Thời gian"].FillWeight  = 18;
            dgvIncidents.Columns["Loại sự cố"].FillWeight = 12;
            dgvIncidents.Columns["Mô tả"].FillWeight      = 38;
            dgvIncidents.Columns["Người báo"].FillWeight  = 18;
            dgvIncidents.Columns["Trạng thái"].FillWeight = 14;

            foreach (DataGridViewRow row in dgvIncidents.Rows)
                row.DefaultCellStyle.ForeColor =
                    row.Cells["Trạng thái"].Value?.ToString() == "Đang xử lý" ? Color.Orange : Color.Gray;
        }

        private void btnReport_Click(object? sender, EventArgs e)
        {
            int total = 0, active = 0;
            if (dgvIncidents.DataSource is DataTable dt)
            {
                total = dt.Rows.Count;
                foreach (DataRow row in dt.Rows)
                    if (row["Trạng thái"]?.ToString() == "Đang xử lý") active++;
            }

            string report =
                "BÁO CÁO AN NINH\n" +
                $"Thời gian: {DateTime.Now:HH:mm dd/MM/yyyy}\n" +
                "──────────────────\n" +
                $"• Tổng sự cố: {total}\n" +
                $"• Đang xử lý: {active}\n" +
                $"• Đã xử lý: {total - active}\n" +
                "──────────────────\n" +
                "Gửi báo cáo cho quản lý qua Chat?";

            if (MsgBox.Show(MsgBox.OwnerWindow(this), report, "Báo cáo an ninh", MsgBox.MessageBoxType.Warning) == DialogResult.Yes)
                MsgBox.Show(MsgBox.OwnerWindow(this), "Đã gửi báo cáo cho quản lý!", "Thành công", MsgBox.MessageBoxType.Success);
        }

        private async void btnSOS_Click(object sender, EventArgs e)
        {
            var confirm = MsgBox.Show(
                MsgBox.OwnerWindow(this),
                "BẠN CÓ CHẮC MUỐN GỬI TÍN HIỆU KHẨN CẤP?\n\n" +
                "Thao tác này sẽ thông báo ngay đến:\n- Quản lý\n- Hệ thống giám sát",
                "XÁC NHẬN SOS", MsgBox.MessageBoxType.Warning);
            if (confirm != DialogResult.Yes) return;

            string desc = InputDialog.Show(MsgBox.OwnerWindow(this), "Mô tả sự cố khẩn cấp",
                "Nội dung (ngắn gọn)", "VD: Nghi trộm xe khu bãi giữ") ?? "Tín hiệu SOS được kích hoạt";
            if (string.IsNullOrWhiteSpace(desc)) desc = "Tín hiệu SOS được kích hoạt";

            var me = GlobalSession.CurrentUser;
            var dto = new IncidentDTO
            {
                Type = "sos_khan_cap",
                Description = desc,
                ReporterId = me?.EmployeeId,
                Timestamp = DateTimeOffset.Now.ToUnixTimeMilliseconds(),
                Status = "dang_xu_ly",
                HandleNote = "",
                Severity = "khan_cap"
            };

            var (ok, msg, _) = await IncidentBUS.Add(dto);
            if (!ok)
            {
                MsgBox.Show(MsgBox.OwnerWindow(this), msg, "Lỗi", MsgBox.MessageBoxType.Error);
                return;
            }

            // Gửi thông báo SOS tới tất cả quản lý/admin (best-effort)
            try
            {
                var managers = (await EmployeeBUS.GetAllEmployeesAsync())
                    .Where(x => (x.Role ?? "").ToLower() is "manager" or "admin");
                foreach (var m in managers)
                {
                    await NotificationBUS.Add(new NotificationDTO
                    {
                        Type = "sos",
                        Content = $"Bảo vệ {me?.FullName ?? me?.EmployeeId} kích hoạt SOS: {desc}",
                        ReceiverId = m.EmployeeId,
                        SenderId = me?.EmployeeId,
                        Timestamp = DateTimeOffset.Now.ToUnixTimeMilliseconds(),
                        IsRead = false,
                        RelatedPage = "security"
                    });
                }
            }
            catch { /* thông báo là best-effort */ }

            MsgBox.Show(MsgBox.OwnerWindow(this),
                "ĐÃ GỬI TÍN HIỆU KHẨN CẤP!\n\nQuản lý đã được thông báo.",
                "SOS", MsgBox.MessageBoxType.Warning);
            await LoadRealData();
        }
    }
}
