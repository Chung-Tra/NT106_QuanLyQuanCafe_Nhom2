using System;
using System.Drawing;
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

            // Static-control event subscriptions (lambdas -> kept in code-behind)
            btnPrev.Click   += (s, e) => { _weekStart = _weekStart.AddDays(-7); RenderGrid(); };
            btnNext.Click   += (s, e) => { _weekStart = _weekStart.AddDays(7); RenderGrid(); };
            btnPublish.Click += (s, e) => MsgBox.Show(MsgBox.OwnerWindow(this), "Đã đăng lịch ca tuần này cho toàn bộ nhân viên!", "Đăng lịch thành công", MsgBox.MessageBoxType.Success);

            Load += (s, e) => RenderGrid();
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

            // Dữ liệu mẫu mỗi ca
            string[][] mockData =
            {
                // Ca sáng T2..CN
                new[]{ "An + Bích", "An + Nam", "Bích + Hà", "An + Bích", "Nam + Hà", "Bích", "⚠ Thiếu" },
                // Ca chiều T2..CN
                new[]{ "Hà + Tuấn", "Hương + Tùng", "⚠ Thiếu", "Hà + Tuấn", "Hương + Tùng", "Hà + Tuấn", "Nam + Hương" },
                // Ca đêm T2..CN
                new[]{ "Tùng + Mai", "Tuấn + Tùng", "Mai + Tuấn", "Tùng + Mai", "Tuấn + Tùng", "---", "---" },
            };

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
                    string cell = mockData[s][d];
                    bool warn   = cell.StartsWith("⚠");
                    bool empty  = cell == "---";
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
