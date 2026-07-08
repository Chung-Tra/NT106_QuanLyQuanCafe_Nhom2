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
    // Nhân viên tự phục vụ lịch ca (node dang_ky_ca):
    //   • Chọn ca  — nhận một ca còn trống (open -> mine, chờ xác nhận).
    //   • Đổi ca   — xin đổi một ca của mình cho đồng nghiệp (tạo yêu cầu swap).
    public partial class ucShiftRegister : UserControl
    {
        public ucShiftRegister()
        {
            InitializeComponent();
        }

        private async void UcShiftRegister_Load(object? sender, EventArgs e)
        {
            DateTime monday = StartOfWeek(DateTime.Today);
            lblWeek.Text = $"Tuần {monday:dd/MM} – {monday.AddDays(6):dd/MM/yyyy}";
            await LoadAll();
        }

        private string MyId => GlobalSession.CurrentUser?.EmployeeId ?? "";

        private async Task LoadAll()
        {
            System.Collections.Generic.Dictionary<string, ShiftDTO> all;
            try { all = await ShiftBUS.GetAll(); }
            catch { all = new(); }

            // ----- Ca trống -----
            var dtOpen = new DataTable();
            dtOpen.Columns.Add("Mã"); dtOpen.Columns.Add("Ngày"); dtOpen.Columns.Add("Ca"); dtOpen.Columns.Add("Giờ");
            foreach (var kv in all.Where(x => x.Value.Loai == "open"))
                dtOpen.Rows.Add(kv.Key, kv.Value.Ngay, kv.Value.Ca, kv.Value.Gio);
            dgvOpen.DataSource = dtOpen;
            GridColumnGuard.SyncColumnNames(dgvOpen);
            if (dgvOpen.Columns.Contains("Mã")) dgvOpen.Columns["Mã"].Visible = false;
            dgvOpen.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            if (dgvOpen.Columns.Contains("Ngày")) dgvOpen.Columns["Ngày"].FillWeight = 30;
            if (dgvOpen.Columns.Contains("Ca")) dgvOpen.Columns["Ca"].FillWeight = 30;
            if (dgvOpen.Columns.Contains("Giờ")) dgvOpen.Columns["Giờ"].FillWeight = 40;

            // ----- Ca của tôi -----
            var dtMine = new DataTable();
            dtMine.Columns.Add("Mã"); dtMine.Columns.Add("Ngày"); dtMine.Columns.Add("Ca"); dtMine.Columns.Add("Giờ"); dtMine.Columns.Add("Trạng thái");
            foreach (var kv in all.Where(x => x.Value.Loai == "mine" && x.Value.EmployeeId == MyId))
                dtMine.Rows.Add(kv.Key, kv.Value.Ngay, kv.Value.Ca, kv.Value.Gio, kv.Value.TrangThai);
            dgvMine.DataSource = dtMine;
            GridColumnGuard.SyncColumnNames(dgvMine);
            if (dgvMine.Columns.Contains("Mã")) dgvMine.Columns["Mã"].Visible = false;
            dgvMine.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            if (dgvMine.Columns.Contains("Ngày")) dgvMine.Columns["Ngày"].FillWeight = 24;
            if (dgvMine.Columns.Contains("Ca")) dgvMine.Columns["Ca"].FillWeight = 22;
            if (dgvMine.Columns.Contains("Giờ")) dgvMine.Columns["Giờ"].FillWeight = 32;
            if (dgvMine.Columns.Contains("Trạng thái")) dgvMine.Columns["Trạng thái"].FillWeight = 22;

            // ----- Yêu cầu đổi ca -----
            var dtSwap = new DataTable();
            dtSwap.Columns.Add("Mã"); dtSwap.Columns.Add("Ngày"); dtSwap.Columns.Add("Ca"); dtSwap.Columns.Add("Đổi cho"); dtSwap.Columns.Add("Trạng thái");
            foreach (var kv in all.Where(x => x.Value.Loai == "swap" && x.Value.EmployeeId == MyId))
                dtSwap.Rows.Add(kv.Key, kv.Value.Ngay, kv.Value.Ca, kv.Value.DoiCho, kv.Value.TrangThai);
            dgvSwap.DataSource = dtSwap;
            GridColumnGuard.SyncColumnNames(dgvSwap);
            if (dgvSwap.Columns.Contains("Mã")) dgvSwap.Columns["Mã"].Visible = false;
            dgvSwap.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            if (dgvSwap.Columns.Contains("Ngày")) dgvSwap.Columns["Ngày"].FillWeight = 22;
            if (dgvSwap.Columns.Contains("Ca")) dgvSwap.Columns["Ca"].FillWeight = 20;
            if (dgvSwap.Columns.Contains("Đổi cho")) dgvSwap.Columns["Đổi cho"].FillWeight = 36;
            if (dgvSwap.Columns.Contains("Trạng thái")) dgvSwap.Columns["Trạng thái"].FillWeight = 22;

            RecolorStatuses();
            lblMineValue.Text = $"{dtMine.Rows.Count} ca";
            lblOpenValue.Text = $"{dtOpen.Rows.Count} ca";
            lblSwapPendingValue.Text = $"{dtSwap.AsEnumerable().Count(r => (r.Field<string>("Trạng thái") ?? "") == "Chờ duyệt")} yêu cầu";
        }

        private static string RowId(DataGridView dgv) =>
            (dgv.CurrentRow?.DataBoundItem as DataRowView)?["Mã"]?.ToString() ?? "";

        private async void BtnPickShift_Click(object? sender, EventArgs e)
        {
            if (dgvOpen.CurrentRow == null || dgvOpen.CurrentRow.Index < 0)
            {
                MsgBox.Show(MsgBox.OwnerWindow(this), "Vui lòng chọn một ca trống để nhận!", "Thông báo", MsgBox.MessageBoxType.Warning);
                return;
            }
            string id = RowId(dgvOpen);
            string ngay = dgvOpen.CurrentRow.Cells["Ngày"].Value?.ToString() ?? "";
            string ca = dgvOpen.CurrentRow.Cells["Ca"].Value?.ToString() ?? "";
            string gio = dgvOpen.CurrentRow.Cells["Giờ"].Value?.ToString() ?? "";

            if (MsgBox.Show(MsgBox.OwnerWindow(this), $"Nhận ca {ca} ngày {ngay} ({gio})?", "Xác nhận nhận ca", MsgBox.MessageBoxType.Warning) != DialogResult.Yes)
                return;

            var (ok, msg) = await ShiftBUS.Update(id, new { loai = "mine", nhanvien_id = MyId, trang_thai = "Chờ xác nhận" });
            if (ok) { await LoadAll(); MsgBox.Show(MsgBox.OwnerWindow(this), "Đã gửi yêu cầu nhận ca!", "Thành công", MsgBox.MessageBoxType.Success); }
            else MsgBox.Show(MsgBox.OwnerWindow(this), msg, "Lỗi", MsgBox.MessageBoxType.Error);
        }

        private async void BtnSwap_Click(object? sender, EventArgs e)
        {
            if (dgvMine.CurrentRow == null || dgvMine.CurrentRow.Index < 0)
            {
                MsgBox.Show(MsgBox.OwnerWindow(this), "Vui lòng chọn một ca của bạn để xin đổi!", "Thông báo", MsgBox.MessageBoxType.Warning);
                return;
            }
            string mineId = RowId(dgvMine);
            string ngay = dgvMine.CurrentRow.Cells["Ngày"].Value?.ToString() ?? "";
            string ca = dgvMine.CurrentRow.Cells["Ca"].Value?.ToString() ?? "";
            string gio = dgvMine.CurrentRow.Cells["Giờ"].Value?.ToString() ?? "";

            // Chọn đồng nghiệp từ danh sách nhân viên THẬT (kèm mã NV) — trước đây gõ tay
            // tự do nên khi duyệt không biết đổi cho ai, lịch tuần/lương không cập nhật được.
            var (targetId, targetName) = await PickColleagueAsync(ca, ngay);
            if (targetId == null || targetName == null) return;

            var (ok, msg, _) = await ShiftBUS.Add(new ShiftDTO
            {
                Loai = "swap", Ngay = ngay, Ca = ca, Gio = gio,
                EmployeeId = MyId, DoiCho = targetName, DoiChoId = targetId, TrangThai = "Chờ duyệt"
            });
            if (!ok)
            {
                MsgBox.Show(MsgBox.OwnerWindow(this), msg, "Lỗi", MsgBox.MessageBoxType.Error);
                return;
            }
            if (!string.IsNullOrEmpty(mineId)) await ShiftBUS.Update(mineId, new { trang_thai = "Chờ đổi" });

            // Báo cho người nhận ca + các quản lý (best-effort, hiện ở feed Thông báo)
            var me = GlobalSession.CurrentUser;
            string noiDung = $"{me?.FullName ?? MyId} xin đổi {ca} ngày {ngay} ({gio}) cho {targetName}. Chờ quản lý duyệt.";
            try
            {
                await NotificationBUS.Add(new NotificationDTO
                {
                    Type = "doi_ca", Content = noiDung, ReceiverId = targetId, SenderId = MyId,
                    Timestamp = DateTimeOffset.Now.ToUnixTimeMilliseconds(), IsRead = false, RelatedPage = "schedule"
                });
                await ManagerReport.SendAsync(noiDung, "doi_ca", "schedule");
            }
            catch { }

            await LoadAll();
            MsgBox.Show(MsgBox.OwnerWindow(this),
                $"Đã gửi yêu cầu đổi ca cho {targetName}.\nQuản lý duyệt xong, lịch tuần sẽ tự đổi tên người làm.",
                "Thành công", MsgBox.MessageBoxType.Success);
        }

        // Hộp chọn đồng nghiệp (active, không phải admin, khác mình) — trả về (mã NV, tên).
        private async Task<(string? id, string? name)> PickColleagueAsync(string ca, string ngay)
        {
            System.Collections.Generic.List<EmployeeDTO> emps;
            try
            {
                emps = (await Task.Run(EmployeeBUS.GetAllEmployeesAsync))
                    .Where(x => x.EmployeeId != null && x.EmployeeId != MyId
                             && (x.Role ?? "").ToLower() != "admin" && x.Status == "active")
                    .OrderBy(x => x.FullName).ToList();
            }
            catch { emps = new(); }
            if (emps.Count == 0)
            {
                MsgBox.Show(MsgBox.OwnerWindow(this), "Không tải được danh sách đồng nghiệp (kiểm tra server).", "Lỗi", MsgBox.MessageBoxType.Error);
                return (null, null);
            }

            var owner = MsgBox.OwnerWindow(this);
            using var form = WindowChrome.CreateDialog($"Đổi {ca} ({ngay}) cho ai?", new Size(400, 430), out var content, owner);

            var lst = new ListBox
            {
                Dock = DockStyle.Fill,
                BorderStyle = BorderStyle.None,
                BackColor = Color.FromArgb(31, 31, 34),
                ForeColor = Color.White,
                Font = Theme.F(10.5F),
                ItemHeight = 24,
            };
            foreach (var emp in emps)
                lst.Items.Add($"{emp.FullName}  —  {EmployeeText.RoleVi(emp.Role)}");

            var btnOk = new Guna.UI2.WinForms.Guna2Button
            {
                Text = "Chọn",
                Size = new Size(120, 38),
                BorderRadius = 8,
                FillColor = Theme.Teal,
                ForeColor = Color.White,
                Font = Theme.F(9.5F, FontStyle.Bold),
                Cursor = Cursors.Hand,
            };
            btnOk.HoverState.FillColor = Theme.TealHover;
            var pnlBtn = new Panel { Dock = DockStyle.Bottom, Height = 56, BackColor = Color.Transparent };
            pnlBtn.Controls.Add(btnOk);
            content.Controls.Add(lst);
            content.Controls.Add(pnlBtn);
            form.Shown += (s, ev) => btnOk.Location = new Point(pnlBtn.ClientSize.Width - btnOk.Width - 16, 9);

            btnOk.Click += (s, ev) =>
            {
                if (lst.SelectedIndex < 0)
                {
                    MsgBox.Show(form, "Chọn một đồng nghiệp trong danh sách.", "Thông báo", MsgBox.MessageBoxType.Warning);
                    return;
                }
                form.DialogResult = DialogResult.OK;
                form.Close();
            };
            lst.DoubleClick += (s, ev) => { if (lst.SelectedIndex >= 0) { form.DialogResult = DialogResult.OK; form.Close(); } };

            if (form.ShowDialog(owner) != DialogResult.OK || lst.SelectedIndex < 0) return (null, null);
            var picked = emps[lst.SelectedIndex];
            return (picked.EmployeeId, picked.FullName ?? picked.EmployeeId);
        }

        private void RecolorStatuses()
        {
            foreach (DataGridViewRow row in dgvMine.Rows)
                if (row.Cells["Trạng thái"] != null)
                    row.Cells["Trạng thái"].Style.ForeColor = StatusColor(row.Cells["Trạng thái"].Value?.ToString());
            foreach (DataGridViewRow row in dgvSwap.Rows)
                if (row.Cells["Trạng thái"] != null)
                    row.Cells["Trạng thái"].Style.ForeColor = StatusColor(row.Cells["Trạng thái"].Value?.ToString());
        }

        private static Color StatusColor(string? status) => status switch
        {
            "Đã xếp" or "Đã xác nhận" or "Đã duyệt" => Color.FromArgb(34, 197, 94),
            "Chờ xác nhận" or "Chờ duyệt" or "Chờ đổi" => Color.FromArgb(245, 158, 11),
            "Từ chối" => Color.FromArgb(220, 80, 80),
            _ => Color.FromArgb(220, 220, 225),
        };

        private static DateTime StartOfWeek(DateTime d)
        {
            int dow = (int)d.DayOfWeek;
            int back = dow == 0 ? 6 : dow - 1;
            return d.AddDays(-back).Date;
        }
    }
}
