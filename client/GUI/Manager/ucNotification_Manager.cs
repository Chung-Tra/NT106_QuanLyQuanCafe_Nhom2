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
    public partial class ucNotification_Manager : UserControl
    {
        public ucNotification_Manager()
        {
            InitializeComponent();
            GridColumnGuard.SyncColumnNames(dgvPendingLeave);
            GridColumnGuard.SyncColumnNames(dgvSchedule);
            DgvRefresh.Attach(dgvPendingLeave, () => _ = LoadPendingLeaveAsync());
            DgvRefresh.Attach(dgvSchedule, LoadScheduleAsync);
            this.Load += (s, e) => { _ = LoadPendingLeaveAsync(); _ = LoadScheduleAsync(); };
        }

        // Đơn xin nghỉ chờ duyệt (thật, từ Firebase)
        private async Task LoadPendingLeaveAsync()
        {
            DataTable dtLeave = new();
            dtLeave.Columns.Add("Mã đơn");
            dtLeave.Columns.Add("Nhân viên");
            dtLeave.Columns.Add("Chức vụ");
            dtLeave.Columns.Add("Ngày nghỉ");
            dtLeave.Columns.Add("Lý do");
            dtLeave.Columns.Add("Trạng thái");

            try
            {
                var all = await LeaveRequestBUS.GetAll();
                var emps = (await EmployeeBUS.GetAllEmployeesAsync())
                    .Where(x => x.EmployeeId != null)
                    .ToDictionary(x => x.EmployeeId!, x => x);

                foreach (var kv in all.Where(l => l.Value.Status == "cho_duyet")
                                      .OrderBy(l => l.Value.SentAt))
                {
                    var l = kv.Value;
                    string name = l.EmployeeId ?? "";
                    string role = "";
                    if (l.EmployeeId != null && emps.TryGetValue(l.EmployeeId, out var emp))
                    {
                        name = emp.FullName ?? l.EmployeeId;
                        role = EmployeeText.RoleVi(emp.Role);
                    }
                    string ngay = l.FromDate == l.ToDate ? (l.FromDate ?? "") : $"{l.FromDate} - {l.ToDate}";
                    dtLeave.Rows.Add(kv.Key, name, role, ngay, l.Reason, "Chờ duyệt");
                }
            }
            catch { /* offline */ }

            dgvPendingLeave.DataSource = dtLeave;
            dgvPendingLeave.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPendingLeave.RowHeadersVisible = false;
            dgvPendingLeave.ReadOnly = true;
            dgvPendingLeave.AllowUserToAddRows = false;
            if (dgvPendingLeave.Columns.Contains("Mã đơn")) dgvPendingLeave.Columns["Mã đơn"].Visible = false;
            dgvPendingLeave.Columns["Nhân viên"].FillWeight  = 20;
            dgvPendingLeave.Columns["Chức vụ"].FillWeight    = 15;
            dgvPendingLeave.Columns["Ngày nghỉ"].FillWeight  = 25;
            dgvPendingLeave.Columns["Lý do"].FillWeight      = 22;
            dgvPendingLeave.Columns["Trạng thái"].FillWeight = 18;
        }

        private string WeekKey => GetMonday(DateTime.Today).ToString("dd/MM/yyyy");
        private static DateTime GetMonday(DateTime d) { int dow = (int)d.DayOfWeek; return d.AddDays(-(dow == 0 ? 6 : dow - 1)).Date; }

        // Lịch làm việc tuần (node lich_lam_viec): mỗi nhân viên 1 dòng, ô = S / C / OFF.
        private async Task LoadScheduleAsync()
        {
            var dtSchedule = new DataTable();
            dtSchedule.Columns.Add("Mã");
            dtSchedule.Columns.Add("EmpId");
            dtSchedule.Columns.Add("Nhân viên");
            foreach (string d in new[] { "T2", "T3", "T4", "T5", "T6", "T7", "CN" })
                dtSchedule.Columns.Add(d);

            try
            {
                var scheds = (await ScheduleBUS.GetAll()).Where(x => x.Value.Tuan == WeekKey)
                    .ToDictionary(x => x.Value.EmployeeId ?? x.Key, x => x);
                var emps = (await EmployeeBUS.GetAllEmployeesAsync())
                    .Where(x => x.EmployeeId != null && (x.Role ?? "").ToLower() != "admin" && x.Status == "active");

                foreach (var emp in emps)
                {
                    if (scheds.TryGetValue(emp.EmployeeId!, out var kv))
                    {
                        var s = kv.Value;
                        dtSchedule.Rows.Add(kv.Key, emp.EmployeeId, emp.FullName, s.T2, s.T3, s.T4, s.T5, s.T6, s.T7, s.CN);
                    }
                    else
                    {
                        dtSchedule.Rows.Add("", emp.EmployeeId, emp.FullName, "", "", "", "", "", "", "");
                    }
                }
            }
            catch { /* offline */ }

            dgvSchedule.DataSource = dtSchedule;
            dgvSchedule.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSchedule.RowHeadersVisible = false;
            dgvSchedule.AllowUserToAddRows = false;
            if (dgvSchedule.Columns.Contains("Mã")) dgvSchedule.Columns["Mã"].Visible = false;
            if (dgvSchedule.Columns.Contains("EmpId")) dgvSchedule.Columns["EmpId"].Visible = false;
            if (dgvSchedule.Columns.Contains("Nhân viên"))
            {
                dgvSchedule.Columns["Nhân viên"].FillWeight = 30;
                dgvSchedule.Columns["Nhân viên"].ReadOnly = true;
            }
            foreach (string day in new[] { "T2", "T3", "T4", "T5", "T6", "T7", "CN" })
                if (dgvSchedule.Columns.Contains(day)) dgvSchedule.Columns[day].FillWeight = 10;

            foreach (DataGridViewRow row in dgvSchedule.Rows)
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (dgvSchedule.Columns[cell.ColumnIndex].Name is "Mã" or "EmpId" or "Nhân viên") continue;
                    string val = cell.Value?.ToString() ?? "";
                    if (val == "S") cell.Style.ForeColor = Color.MediumSeaGreen;
                    else if (val == "C") cell.Style.ForeColor = Color.SteelBlue;
                    else if (val == "OFF") cell.Style.ForeColor = Color.IndianRed;
                }
        }

        private void DgvPendingLeave_CellDoubleClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            RecordDetail.FromRow(dgvPendingLeave.Rows[e.RowIndex], "Chi tiết đơn xin nghỉ")
                        .ShowDialog(MsgBox.OwnerWindow(this));
        }

        // Sửa lý do đơn đang chọn (lưu thật)
        private async void BtnEditLeave_Click(object? sender, EventArgs e)
        {
            if (dgvPendingLeave.CurrentRow == null || dgvPendingLeave.CurrentRow.Index < 0)
            {
                MsgBox.Show(MsgBox.OwnerWindow(this), "Vui lòng chọn một đơn để sửa!", "Thông báo", MsgBox.MessageBoxType.Warning);
                return;
            }
            string id = (dgvPendingLeave.CurrentRow?.DataBoundItem as DataRowView)?["Mã đơn"]?.ToString() ?? "";
            if (RecordEdit.EditRow(dgvPendingLeave.CurrentRow, "Sửa đơn xin nghỉ", MsgBox.OwnerWindow(this)))
            {
                string reason = dgvPendingLeave.CurrentRow.Cells["Lý do"].Value?.ToString() ?? "";
                await LeaveRequestBUS.Update(id, new { ly_do = reason });
                await LoadPendingLeaveAsync();
            }
        }

        private async void btnApprove_Click(object sender, EventArgs e)
        {
            if (dgvPendingLeave.CurrentRow == null) return;
            string id = (dgvPendingLeave.CurrentRow?.DataBoundItem as DataRowView)?["Mã đơn"]?.ToString() ?? "";
            string name = dgvPendingLeave.CurrentRow.Cells["Nhân viên"].Value?.ToString() ?? "";
            var (ok, msg) = await LeaveRequestBUS.Update(id, new
            {
                trang_thai = "da_duyet",
                nguoi_duyet_id = GlobalSession.CurrentUser?.EmployeeId ?? "",
                thoi_gian_duyet = DateTimeOffset.Now.ToUnixTimeMilliseconds()
            });
            if (ok)
            {
                MsgBox.Show(MsgBox.OwnerWindow(this), $"Đã duyệt đơn nghỉ phép của {name}!", "Thành công", MsgBox.MessageBoxType.Success);
                await LoadPendingLeaveAsync();
            }
            else MsgBox.Show(MsgBox.OwnerWindow(this), msg, "Lỗi", MsgBox.MessageBoxType.Error);
        }

        private async void btnReject_Click(object sender, EventArgs e)
        {
            if (dgvPendingLeave.CurrentRow == null) return;
            string id = (dgvPendingLeave.CurrentRow?.DataBoundItem as DataRowView)?["Mã đơn"]?.ToString() ?? "";
            string name = dgvPendingLeave.CurrentRow.Cells["Nhân viên"].Value?.ToString() ?? "";
            var (ok, msg) = await LeaveRequestBUS.Update(id, new
            {
                trang_thai = "tu_choi",
                nguoi_duyet_id = GlobalSession.CurrentUser?.EmployeeId ?? "",
                thoi_gian_duyet = DateTimeOffset.Now.ToUnixTimeMilliseconds()
            });
            if (ok)
            {
                MsgBox.Show(MsgBox.OwnerWindow(this), $"Đã từ chối đơn nghỉ phép của {name}!", "Thông báo", MsgBox.MessageBoxType.Warning);
                await LoadPendingLeaveAsync();
            }
            else MsgBox.Show(MsgBox.OwnerWindow(this), msg, "Lỗi", MsgBox.MessageBoxType.Error);
        }

        private void btnChatStaff_Click(object sender, EventArgs e)
        {
            if (dgvPendingLeave.CurrentRow == null) return;
            string name = dgvPendingLeave.CurrentRow.Cells["Nhân viên"].Value?.ToString() ?? "";
            MsgBox.Show(MsgBox.OwnerWindow(this), $"Hãy mở mục Chat nội bộ để trao đổi với {name}.", "Chat", MsgBox.MessageBoxType.Info);
        }

        private async void btnSaveSchedule_Click(object sender, EventArgs e)
        {
            if (dgvSchedule.DataSource is not DataTable dt) return;
            int saved = 0;
            try
            {
                foreach (DataRow r in dt.Rows)
                {
                    string id = r["Mã"]?.ToString() ?? "";
                    var payload = new
                    {
                        nhanvien_id = r["EmpId"]?.ToString() ?? "",
                        ten = r["Nhân viên"]?.ToString() ?? "",
                        tuan = WeekKey,
                        t2 = r["T2"]?.ToString() ?? "", t3 = r["T3"]?.ToString() ?? "",
                        t4 = r["T4"]?.ToString() ?? "", t5 = r["T5"]?.ToString() ?? "",
                        t6 = r["T6"]?.ToString() ?? "", t7 = r["T7"]?.ToString() ?? "",
                        cn = r["CN"]?.ToString() ?? ""
                    };
                    if (string.IsNullOrEmpty(id))
                    {
                        var dto = new ScheduleDTO
                        {
                            EmployeeId = payload.nhanvien_id, Ten = payload.ten, Tuan = WeekKey,
                            T2 = payload.t2, T3 = payload.t3, T4 = payload.t4, T5 = payload.t5,
                            T6 = payload.t6, T7 = payload.t7, CN = payload.cn
                        };
                        await ScheduleBUS.Add(dto);
                    }
                    else await ScheduleBUS.Update(id, payload);
                    saved++;
                }
            }
            catch (Exception ex)
            {
                MsgBox.Show(MsgBox.OwnerWindow(this), "Lỗi lưu lịch: " + ex.Message, "Lỗi", MsgBox.MessageBoxType.Error);
                return;
            }
            MsgBox.Show(MsgBox.OwnerWindow(this), $"Đã lưu lịch làm việc tuần {WeekKey} ({saved} nhân viên)!", "Thành công", MsgBox.MessageBoxType.Success);
            await LoadScheduleAsync();
        }

        private void dgvPendingLeave_SelectionChanged(object sender, EventArgs e) { }

        private void dgvSchedule_CellValueChanged(object sender, DataGridViewCellEventArgs e) { }
    }
}
