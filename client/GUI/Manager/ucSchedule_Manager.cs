using BUS;
using DTO;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace GUI
{
#pragma warning disable IDE1006
    public partial class ucSchedule_Manager : UserControl
#pragma warning restore IDE1006
    {
        private readonly string[] _days   = { "T2", "T3", "T4", "T5", "T6", "T7", "CN" };
        private readonly string[] _shifts = { "Ca sáng (6–14h)", "Ca chiều (14–22h)", "Ca đêm (22–6h)" };

        private DateTime _weekStart;

        public ucSchedule_Manager()
        {
            InitializeComponent();

            _weekStart = GetMonday(DateTime.Today);

            // Column / row styles for the schedule grid (runtime-derived from _days/_shifts).
            // Xoá style do Designer sinh sẵn (8 cột Absolute 20px + 4 hàng Absolute 20px) trước
            // khi thêm style đúng — nếu không, TableLayoutPanel dùng 8 style ĐẦU (Designer, 20px)
            // cho 8 cột → mọi cột chỉ rộng 20px, chữ xổ dọc từng ký tự.
            grid.ColumnStyles.Clear();
            grid.RowStyles.Clear();
            for (int i = 0; i <= _days.Length; i++)
                grid.ColumnStyles.Add(new ColumnStyle(i == 0 ? SizeType.Absolute : SizeType.Percent, i == 0 ? 130F : 100F / _days.Length));
            for (int i = 0; i <= _shifts.Length; i++)
                grid.RowStyles.Add(new RowStyle(SizeType.Percent, i == 0 ? 15F : 85F / _shifts.Length));

            // Giảm nhấp nháy/giật: lưới dựng lại toàn bộ Label mỗi lần đổi tuần.
            grid.EnableDoubleBuffer();
        }

        // ---------------- Sự kiện (khai báo ở Designer, xử lý ở đây) ----------------
        private void ucSchedule_Manager_Load(object? sender, EventArgs e) => _ = ReloadWeekAsync();

        private void BtnPrev_Click(object? sender, EventArgs e)
        {
            _weekStart = _weekStart.AddDays(-7);
            _ = ReloadWeekAsync();
        }

        private void BtnNext_Click(object? sender, EventArgs e)
        {
            _weekStart = _weekStart.AddDays(7);
            _ = ReloadWeekAsync();
        }

        private void BtnPublish_Click(object? sender, EventArgs e) =>
            MsgBox.Show(MsgBox.OwnerWindow(this), "Lịch ca tuần này lấy trực tiếp từ dữ liệu phân ca (node schedules) — đã đồng bộ cho toàn bộ nhân viên!", "Đăng lịch", MsgBox.MessageBoxType.Success);

        // Ma trận ca × ngày: _cells[shift][day] = danh sách tên NV (đã ghép chuỗi).
        // shift 0=Ca sáng(S) · 1=Ca chiều(C) · 2=Ca đêm(N).
        private string[][] _cells = Array.Empty<string[]>();

        private static string DayCode(ScheduleDTO s, int day) => (day switch
        {
            0 => s.T2, 1 => s.T3, 2 => s.T4, 3 => s.T5, 4 => s.T6, 5 => s.T7, _ => s.CN
        })?.Trim().ToUpperInvariant() ?? "";

        // Nạp lịch THẬT của tuần đang xem từ node schedules, gộp NV theo (ca, ngày).
        private async Task ReloadWeekAsync()
        {
            // #region agent log
            var sw = Stopwatch.StartNew();
            AgentDebugLog.Write("D", "ucSchedule_Manager.ReloadWeekAsync", "start", null);
            // #endregion
            string weekKey = _weekStart.ToString("dd/MM/yyyy");
            var names   = new string[_shifts.Length][];
            for (int s = 0; s < _shifts.Length; s++) names[s] = new string[_days.Length];

            var buckets = new List<string>[_shifts.Length, _days.Length];
            for (int s = 0; s < _shifts.Length; s++)
                for (int d = 0; d < _days.Length; d++)
                    buckets[s, d] = new List<string>();

            // Tập nhân viên có phân ca tuần này — thu thập ngay ở đây để UpdateStatCards
            // không phải gọi lại ScheduleBUS.GetAll() lần nữa.
            var staffIds = new HashSet<string>();

            try
            {
                var scheds = (await ScheduleBUS.GetAll()).Values.Where(x => x.Tuan == weekKey);
                var emps = (await Task.Run(EmployeeBUS.GetAllEmployeesAsync))
                           .Where(x => x.EmployeeId != null)
                           .ToDictionary(x => x.EmployeeId!, x => x.FullName ?? x.EmployeeId!);

                foreach (var sc in scheds)
                {
                    if (!string.IsNullOrEmpty(sc.EmployeeId)) staffIds.Add(sc.EmployeeId);
                    string who = (sc.EmployeeId != null && emps.TryGetValue(sc.EmployeeId, out var n))
                        ? n : (sc.Ten ?? sc.EmployeeId ?? "?");
                    for (int d = 0; d < _days.Length; d++)
                    {
                        int shift = DayCode(sc, d) switch { "S" => 0, "C" => 1, "N" => 2, _ => -1 };
                        if (shift >= 0) buckets[shift, d].Add(who);
                    }
                }
            }
            catch { /* offline → lưới trống */ }

            for (int s = 0; s < _shifts.Length; s++)
                for (int d = 0; d < _days.Length; d++)
                    names[s][d] = string.Join(" + ", buckets[s, d]);

            _cells = names;
            if (!IsDisposed)
            {
                UpdateStatCards(buckets, staffIds);
                RenderGrid();
            }
            // #region agent log
            sw.Stop();
            AgentDebugLog.Write("D", "ucSchedule_Manager.ReloadWeekAsync", "done", new
            {
                ms = sw.ElapsedMilliseconds,
                lblStaff = lblCardStaffVal.Text,
                lblShortage = lblCardShortageVal.Text
            });
            // #endregion
        }

        private async void UpdateStatCards(List<string>[,] buckets, HashSet<string> staffIds)
        {
            // #region agent log
            AgentDebugLog.Write("A", "ucSchedule_Manager.UpdateStatCards", "start_extra_fetch", null);
            // #endregion
            int shortage = 0;
            for (int s = 0; s < _shifts.Length; s++)
                for (int d = 0; d < _days.Length; d++)
                {
                    if (buckets[s, d].Count == 0) shortage++;
                }

            DateTime weekEnd = _weekStart.AddDays(6);
            int onLeave = 0;
            try
            {
                var leaveIds = new HashSet<string>();
                foreach (var l in (await LeaveRequestBUS.GetAll()).Values.Where(x => x.Status == "da_duyet"))
                {
                    if (string.IsNullOrEmpty(l.EmployeeId)) continue;
                    if (!DateTime.TryParseExact(l.FromDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture,
                            System.Globalization.DateTimeStyles.None, out var from)) continue;
                    if (!DateTime.TryParseExact(l.ToDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture,
                            System.Globalization.DateTimeStyles.None, out var to)) to = from;
                    if (to.Date >= _weekStart && from.Date <= weekEnd)
                        leaveIds.Add(l.EmployeeId);
                }
                onLeave = leaveIds.Count;
            }
            catch { /* offline */ }

            lblCardStaffVal.Text = staffIds.Count.ToString();
            lblCardShortageVal.Text = $"{shortage} ca";
            lblCardLeaveVal.Text = $"{onLeave} NV";
            lblCardShortageVal.ForeColor = shortage > 0 ? Theme.Red : Theme.Green;

            if (shortage > 0)
            {
                lblWarn.Text = $"Cảnh báo: Còn {shortage} ca trong tuần chưa đủ người — vui lòng phân công thêm nhân viên.";
                pnlWarn.Visible = true;
            }
            else
            {
                // Đủ người → ẩn hẳn banner cảnh báo (trước đây vẫn hiện dù không có cảnh báo).
                pnlWarn.Visible = false;
            }
        }

        private static DateTime GetMonday(DateTime d)
        {
            int dow  = (int)d.DayOfWeek;        // Chủ nhật=0, Thứ 2=1, … Thứ 7=6
            int back = dow == 0 ? 6 : dow - 1;  // số ngày lùi về Thứ 2 đầu tuần
            return d.AddDays(-back).Date;
        }

        private void RenderGrid()
        {
            lblWeek.Text = $"Tuần {_weekStart:dd/MM} – {_weekStart.AddDays(6):dd/MM/yyyy}";
            grid.SuspendLayout();   // gom mọi thay đổi thành 1 lần layout thay vì layout mỗi lần Add
            grid.Controls.Clear();

            // Header hàng (trống ô góc)
            grid.Controls.Add(new Label { Text = "", BackColor = Color.Transparent }, 0, 0);

            // Header cột ngày
            for (int d = 0; d < _days.Length; d++)
            {
                DateTime day = _weekStart.AddDays(d);
                bool isToday = day.Date == DateTime.Today;
                var lbl = new Label
                {
                    Text      = $"{_days[d]}\n{day:dd/MM}",
                    TextAlign = ContentAlignment.MiddleCenter,
                    Font      = Theme.F(9F, isToday ? FontStyle.Bold : FontStyle.Regular),
                    ForeColor = isToday ? Theme.Teal : Theme.TextMuted,
                    BackColor = Color.Transparent,
                    Dock      = DockStyle.Fill,
                };
                grid.Controls.Add(lbl, d + 1, 0);
            }

            for (int s = 0; s < _shifts.Length; s++)
            {
                var shiftLbl = new Label
                {
                    Text      = _shifts[s],
                    TextAlign = ContentAlignment.MiddleLeft,
                    Font      = Theme.F(8.5F, FontStyle.Bold),
                    ForeColor = Theme.TextMuted,
                    Padding   = new Padding(8, 0, 0, 0),
                    BackColor = Color.Transparent,
                    Dock      = DockStyle.Fill,
                };
                grid.Controls.Add(shiftLbl, 0, s + 1);

                for (int d = 0; d < _days.Length; d++)
                {
                    bool has     = s < _cells.Length && d < _cells[s].Length && !string.IsNullOrEmpty(_cells[s][d]);
                    string names = has ? _cells[s][d] : "";
                    bool empty   = !has;
                    string cell  = has ? names : "⚠ Thiếu";
                    bool warn    = !has;
                    var cellLbl = new Label
                    {
                        Text      = cell,
                        TextAlign = ContentAlignment.MiddleCenter,
                        Font      = Theme.F(8F),
                        ForeColor = warn ? Theme.Red : (empty ? Theme.TextFaint : Theme.TextPri),
                        BackColor = Color.Transparent,
                        Dock      = DockStyle.Fill,
                        Cursor    = Cursors.Hand,
                    };
                    cellLbl.Click += (sender, e) =>
                    {
                        if (warn)
                        {
                            MsgBox.Show(MsgBox.OwnerWindow(this), "Ca này chưa đủ người! Vui lòng phân công thêm nhân viên.", "Cảnh báo lịch ca", MsgBox.MessageBoxType.Warning);
                        }
                        else
                        {
                            MsgBox.Show(MsgBox.OwnerWindow(this), $"Nhân viên: {cell}\nClick 2 lần để chỉnh sửa phân công.", "Thông tin ca", MsgBox.MessageBoxType.Info);
                        }
                    };
                    grid.Controls.Add(cellLbl, d + 1, s + 1);
                }
            }

            grid.ResumeLayout();   // layout 1 lần cho toàn bộ ô vừa thêm
        }
    }
}
