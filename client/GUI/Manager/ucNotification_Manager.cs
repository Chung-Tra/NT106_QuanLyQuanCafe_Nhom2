using BUS;
using DTO;
using System;
using System.Collections.Generic;
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

        // ================== DUYỆT NHẬN CA / ĐỔI CA ==================
        // Duyệt = cập nhật dang_ky_ca VÀ ghi vào lịch tuần (lich_lam_viec). Lịch tuần là căn
        // cứ đi làm → chấm công → chốt ngày công → lương, nên đây là mắt xích nối "đổi ca"
        // vào tính lương. Trước đây yêu cầu ca tạo ra rồi treo "Chờ duyệt" mãi, không ai xử lý.
        private async void BtnShiftRequests_Click(object? sender, EventArgs e)
        {
            var owner = MsgBox.OwnerWindow(this);
            Dictionary<string, ShiftDTO> all;
            List<EmployeeDTO> emps;
            try
            {
                all = await Task.Run(ShiftBUS.GetAll);
                emps = await Task.Run(EmployeeBUS.GetAllEmployeesAsync);
            }
            catch (Exception ex)
            {
                MsgBox.Show(owner, $"Không tải được yêu cầu ca: {ex.Message}", "Lỗi", MsgBox.MessageBoxType.Error);
                return;
            }
            var empName = emps.Where(x => x.EmployeeId != null)
                              .ToDictionary(x => x.EmployeeId!, x => x.FullName ?? x.EmployeeId!);
            string NameOf(string? id) => (id != null && empName.TryGetValue(id, out var n)) ? n : (id ?? "?");

            var pending = all.Where(x => (x.Value.Loai == "mine" && x.Value.TrangThai == "Chờ xác nhận")
                                      || (x.Value.Loai == "swap" && x.Value.TrangThai == "Chờ duyệt"))
                             .OrderBy(x => x.Value.Ngay).ToList();
            if (pending.Count == 0)
            {
                MsgBox.Show(owner, "Không có yêu cầu nhận ca / đổi ca nào chờ duyệt.", "Duyệt ca", MsgBox.MessageBoxType.Info);
                return;
            }

            using var form = WindowChrome.CreateDialog($"Duyệt ca — {pending.Count} yêu cầu chờ", new Size(760, 480), out var content, owner);

            var dt = new DataTable();
            foreach (var c in new[] { "Mã", "Loại", "Ngày", "Ca", "Người yêu cầu", "Đổi cho" }) dt.Columns.Add(c);
            foreach (var kv in pending)
                dt.Rows.Add(kv.Key, kv.Value.Loai == "swap" ? "Đổi ca" : "Nhận ca",
                            kv.Value.Ngay, kv.Value.Ca, NameOf(kv.Value.EmployeeId),
                            kv.Value.Loai == "swap" ? (kv.Value.DoiCho ?? "") : "—");

            var dgv = new Guna.UI2.WinForms.Guna2DataGridView { Dock = DockStyle.Fill, DataSource = dt, ReadOnly = true, AllowUserToAddRows = false };
            Theme.StyleGrid(dgv);
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            var btnOk = new Guna.UI2.WinForms.Guna2Button
            {
                Text = "Duyệt", Size = new Size(130, 38), BorderRadius = 8,
                FillColor = Color.FromArgb(34, 197, 94), ForeColor = Color.White,
                Font = Theme.F(9.5F, FontStyle.Bold), Cursor = Cursors.Hand,
            };
            var btnNo = new Guna.UI2.WinForms.Guna2Button
            {
                Text = "Từ chối", Size = new Size(130, 38), BorderRadius = 8,
                FillColor = Color.FromArgb(63, 63, 70), ForeColor = Color.FromArgb(220, 80, 80),
                Font = Theme.F(9.5F, FontStyle.Bold), Cursor = Cursors.Hand,
            };
            var pnlBtn = new Panel { Dock = DockStyle.Bottom, Height = 56, BackColor = Color.Transparent };
            pnlBtn.Controls.Add(btnOk);
            pnlBtn.Controls.Add(btnNo);
            content.Controls.Add(dgv);
            content.Controls.Add(pnlBtn);
            form.Shown += (s, ev) =>
            {
                btnOk.Location = new Point(pnlBtn.ClientSize.Width - btnOk.Width - 16, 9);
                btnNo.Location = new Point(btnOk.Left - btnNo.Width - 10, 9);
                if (dgv.Columns.Contains("Mã")) dgv.Columns["Mã"].Visible = false;
            };

            ShiftDTO? Selected(out string id)
            {
                id = "";
                if (dgv.CurrentRow == null) return null;
                id = dgv.CurrentRow.Cells["Mã"].Value?.ToString() ?? "";
                return all.TryGetValue(id, out var req) ? req : null;
            }
            void RemoveCurrentRow()
            {
                if (dgv.CurrentRow?.DataBoundItem is DataRowView drv) drv.Row.Delete();
                if (dt.Rows.Count == 0) { form.DialogResult = DialogResult.OK; form.Close(); }
            }

            btnOk.Click += async (s, ev) =>
            {
                if (Selected(out string id) is not ShiftDTO req) return;
                btnOk.Enabled = btnNo.Enabled = false;
                var (ok, msg) = await ApproveShiftAsync(id, req, all, emps, NameOf);
                btnOk.Enabled = btnNo.Enabled = true;
                if (!ok) { MsgBox.Show(form, msg, "Không duyệt được", MsgBox.MessageBoxType.Error); return; }
                RemoveCurrentRow();
            };
            btnNo.Click += async (s, ev) =>
            {
                if (Selected(out string id) is not ShiftDTO req) return;
                btnOk.Enabled = btnNo.Enabled = false;
                await RejectShiftAsync(id, req, all);
                btnOk.Enabled = btnNo.Enabled = true;
                RemoveCurrentRow();
            };

            form.ShowDialog(owner);
            await LoadScheduleAsync(); // lịch tuần trên màn này có thể vừa đổi
        }

        private async Task<(bool ok, string msg)> ApproveShiftAsync(
            string id, ShiftDTO req, Dictionary<string, ShiftDTO> all,
            List<EmployeeDTO> emps, Func<string?, string> nameOf)
        {
            bool hasDate = ShiftScheduleSync.TryParseDate(req.Ngay, out var date);
            string? code = ShiftScheduleSync.ShiftCode(req.Ca);

            if (req.Loai == "mine")
            {
                var (ok, msg) = await ShiftBUS.Update(id, new { trang_thai = "Đã xác nhận" });
                if (!ok) return (false, msg);
                if (hasDate && code != null && req.EmployeeId != null)
                    await ShiftScheduleSync.AssignAsync(req.EmployeeId, nameOf(req.EmployeeId), date, code);
                await NotifyShiftAsync(req.EmployeeId, $"Yêu cầu nhận {req.Ca} ngày {req.Ngay} đã được duyệt — lịch tuần đã cập nhật.");
                return (true, "");
            }

            // swap: cần mã NV người nhận để sửa lịch — yêu cầu cũ gõ tay có thể chỉ có tên
            string? targetId = req.DoiChoId
                ?? emps.FirstOrDefault(x => x.FullName == req.DoiCho)?.EmployeeId;
            if (string.IsNullOrEmpty(targetId))
                return (false, $"Yêu cầu này không có mã NV của \"{req.DoiCho}\" (bản cũ nhập tay).\nHãy Từ chối và nhờ nhân viên gửi lại từ màn Đăng ký ca.");
            string targetName = nameOf(targetId);

            var (ok2, msg2) = await ShiftBUS.Update(id, new { trang_thai = "Đã duyệt" });
            if (!ok2) return (false, msg2);

            // Dòng ca gốc của người xin đổi → chuyển sang tên người nhận
            var mine = all.FirstOrDefault(x => x.Value.Loai == "mine" && x.Value.EmployeeId == req.EmployeeId
                                            && x.Value.Ngay == req.Ngay && x.Value.Ca == req.Ca);
            if (mine.Key != null)
                await ShiftBUS.Update(mine.Key, new { nhanvien_id = targetId, trang_thai = "Đã xác nhận" });

            // LỊCH TUẦN: bỏ ca người xin, gán ca người nhận — từ đây chấm công/ngày công/lương theo người mới
            if (hasDate && code != null && req.EmployeeId != null)
            {
                await ShiftScheduleSync.ClearAsync(req.EmployeeId, date, code);
                await ShiftScheduleSync.AssignAsync(targetId, targetName, date, code);
            }

            await NotifyShiftAsync(req.EmployeeId, $"Đổi {req.Ca} ngày {req.Ngay} cho {targetName}: ĐÃ DUYỆT — lịch tuần đã cập nhật.");
            await NotifyShiftAsync(targetId, $"Bạn nhận {req.Ca} ngày {req.Ngay} từ {nameOf(req.EmployeeId)} (đổi ca đã duyệt).");
            return (true, "");
        }

        private async Task RejectShiftAsync(string id, ShiftDTO req, Dictionary<string, ShiftDTO> all)
        {
            if (req.Loai == "mine")
            {
                // trả ca về pool ca trống cho người khác nhận
                await ShiftBUS.Update(id, new { loai = "open", nhanvien_id = "", trang_thai = "" });
                await NotifyShiftAsync(req.EmployeeId, $"Yêu cầu nhận {req.Ca} ngày {req.Ngay} bị TỪ CHỐI.");
                return;
            }
            await ShiftBUS.Update(id, new { trang_thai = "Từ chối" });
            // ca gốc đang "Chờ đổi" → trả lại trạng thái đã xếp cho người xin
            var mine = all.FirstOrDefault(x => x.Value.Loai == "mine" && x.Value.EmployeeId == req.EmployeeId
                                            && x.Value.Ngay == req.Ngay && x.Value.Ca == req.Ca
                                            && x.Value.TrangThai == "Chờ đổi");
            if (mine.Key != null)
                await ShiftBUS.Update(mine.Key, new { trang_thai = "Đã xác nhận" });
            await NotifyShiftAsync(req.EmployeeId, $"Đổi {req.Ca} ngày {req.Ngay} cho {req.DoiCho}: bị TỪ CHỐI — bạn vẫn làm ca này.");
        }

        private static async Task NotifyShiftAsync(string? receiverId, string content)
        {
            if (string.IsNullOrEmpty(receiverId)) return;
            try
            {
                await NotificationBUS.Add(new NotificationDTO
                {
                    Type = "doi_ca",
                    Content = content,
                    ReceiverId = receiverId,
                    SenderId = GlobalSession.CurrentUser?.EmployeeId,
                    Timestamp = DateTimeOffset.Now.ToUnixTimeMilliseconds(),
                    IsRead = false,
                    RelatedPage = "schedule"
                });
            }
            catch { /* best-effort */ }
        }
    }
}
