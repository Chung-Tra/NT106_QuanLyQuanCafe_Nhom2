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
#pragma warning disable IDE1006
    public partial class ucAlert_Barista : UserControl
#pragma warning restore IDE1006
    {
        public ucAlert_Barista()
        {
            InitializeComponent();
            GridColumnGuard.SyncColumnNames(dgvAlertHistory);
            DgvRefresh.Attach(dgvAlertHistory, () => _ = LoadRealData());

            dgvAlertHistory.CellDoubleClick += (s, e) =>
            {
                if (e.RowIndex < 0) return;
                RecordDetail.FromRow(dgvAlertHistory.Rows[e.RowIndex], "Chi tiết cảnh báo")
                            .ShowDialog(MsgBox.OwnerWindow(this));
            };
        }

        private void UcAlert_Barista_Load(object? sender, EventArgs e) => _ = LoadRealData();

        private static string TypeVi(string? t) => t switch
        {
            "het_nguyen_lieu" => "Hết nguyên liệu",
            "sap_het" => "Sắp hết nguyên liệu",
            "thiet_bi_hong" => "Thiết bị hỏng",
            _ => "Khác"
        };
        private static string TypeCode(string display) => display switch
        {
            "Hết nguyên liệu" => "het_nguyen_lieu",
            "Sắp hết nguyên liệu" => "sap_het",
            "Thiết bị hỏng" => "thiet_bi_hong",
            _ => "khac"
        };

        private async Task LoadRealData()
        {
            if (cmbAlertType.Items.Count > 0 && cmbAlertType.SelectedIndex < 0)
                cmbAlertType.SelectedIndex = 0;

            DataTable dt = new();
            dt.Columns.Add("Thời gian");
            dt.Columns.Add("Loại");
            dt.Columns.Add("Nội dung");
            dt.Columns.Add("Trạng thái");

            try
            {
                var all = await WarningBUS.GetAll();
                foreach (var kv in all.OrderByDescending(w => w.Value.Timestamp))
                {
                    var w = kv.Value;
                    string time = w.Timestamp > 0
                        ? DateTimeOffset.FromUnixTimeMilliseconds(w.Timestamp).LocalDateTime.ToString("dd/MM/yyyy HH:mm") : "";
                    dt.Rows.Add(time, TypeVi(w.Type), w.Content, w.Status == "da_xu_ly" ? "Đã xử lý" : "Chờ xử lý");
                }
            }
            catch { /* offline */ }

            dgvAlertHistory.DataSource = dt;
            dgvAlertHistory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvAlertHistory.RowHeadersVisible = false;
            dgvAlertHistory.Columns["Thời gian"].FillWeight  = 20;
            dgvAlertHistory.Columns["Loại"].FillWeight       = 22;
            dgvAlertHistory.Columns["Nội dung"].FillWeight   = 42;
            dgvAlertHistory.Columns["Trạng thái"].FillWeight = 16;
        }

        private async void BtnReport_Click(object? sender, EventArgs e)
        {
            int totalAlerts = 0, pendingAlerts = 0;
            if (dgvAlertHistory.DataSource is DataTable dt)
            {
                totalAlerts = dt.Rows.Count;
                foreach (DataRow row in dt.Rows)
                    if (row["Trạng thái"]?.ToString() == "Chờ xử lý") pendingAlerts++;
            }

            string report =
                "BÁO CÁO CẢNH BÁO\n" +
                $"Thời gian: {DateTime.Now:HH:mm dd/MM/yyyy}\n" +
                "──────────────────\n" +
                $"• Tổng cảnh báo: {totalAlerts}\n" +
                $"• Đang chờ xử lý: {pendingAlerts}\n" +
                $"• Đã xử lý: {totalAlerts - pendingAlerts}";

            if (MsgBox.Show(MsgBox.OwnerWindow(this), report + "\n──────────────────\nGửi báo cáo cho quản lý?",
                            "Báo cáo cảnh báo", MsgBox.MessageBoxType.Warning) != DialogResult.Yes) return;

            var (ok, msg) = await ManagerReport.SendAsync(report, "bao_cao", "stock");
            MsgBox.Show(MsgBox.OwnerWindow(this), msg, ok ? "Thành công" : "Lỗi",
                        ok ? MsgBox.MessageBoxType.Success : MsgBox.MessageBoxType.Error);
        }

        private async void BtnSendAlert_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMessage.Text))
            {
                MsgBox.Show(MsgBox.OwnerWindow(this), "Vui lòng nhập nội dung cảnh báo!", "Thông báo", MsgBox.MessageBoxType.Warning);
                return;
            }

            string alertType = cmbAlertType.SelectedItem?.ToString() ?? "Khác";
            string content = txtMessage.Text.Trim();
            var me = GlobalSession.CurrentUser;

            var dto = new WarningDTO
            {
                Type = TypeCode(alertType),
                Content = content,
                SenderId = me?.EmployeeId,
                Timestamp = DateTimeOffset.Now.ToUnixTimeMilliseconds(),
                Status = "cho_xu_ly",
                IngredientId = ""
            };
            var (ok, msg, _) = await WarningBUS.Add(dto);
            if (!ok)
            {
                MsgBox.Show(MsgBox.OwnerWindow(this), msg, "Lỗi", MsgBox.MessageBoxType.Error);
                return;
            }

            // Thông báo cho quản lý (best-effort)
            try
            {
                var managers = (await EmployeeBUS.GetAllEmployeesAsync())
                    .Where(x => (x.Role ?? "").ToLower() is "manager" or "admin");
                foreach (var m in managers)
                    await NotificationBUS.Add(new NotificationDTO
                    {
                        Type = "sua_nguyen_lieu",
                        Content = $"Cảnh báo [{alertType}] từ {me?.FullName ?? me?.EmployeeId}: {content}",
                        ReceiverId = m.EmployeeId,
                        SenderId = me?.EmployeeId,
                        Timestamp = DateTimeOffset.Now.ToUnixTimeMilliseconds(),
                        IsRead = false,
                        RelatedPage = "stock"
                    });
            }
            catch { }

            MsgBox.Show(MsgBox.OwnerWindow(this),
                $"Đã gửi cảnh báo [{alertType}] đến quản lý!", "Gửi thành công", MsgBox.MessageBoxType.Success);
            txtMessage.Clear();
            await LoadRealData();
        }
    }
}
