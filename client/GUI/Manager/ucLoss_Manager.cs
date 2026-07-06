using BUS;
using DTO;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using Guna.Charts.WinForms;

namespace GUI
{
    // Trang xem thất thoát / hao phí của quán cho Manager.
    // Hiển thị theo ngày / tháng / năm, bảng chi tiết từng khoản.
    public partial class ucLoss_Manager : UserControl
    {
        private string _mode = "month";

        public ucLoss_Manager()
        {
            InitializeComponent();
            GridColumnGuard.SyncColumnNames(dgvLossDetail);
            DgvRefresh.Attach(dgvLossDetail, () => _ = LoadData());
            _ = LoadData();
        }

        private void BtnDay_Click(object? sender, EventArgs e)
        {
            _mode = "day";
            HighlightBtn(btnDay, btnMonth, btnYear);
            _ = LoadData();
        }

        private void BtnMonth_Click(object? sender, EventArgs e)
        {
            _mode = "month";
            HighlightBtn(btnMonth, btnDay, btnYear);
            _ = LoadData();
        }

        private void BtnYear_Click(object? sender, EventArgs e)
        {
            _mode = "year";
            HighlightBtn(btnYear, btnDay, btnMonth);
            _ = LoadData();
        }

        // "Báo cáo" = ghi nhận một khoản thất thoát mới (lưu thật vào node that_thoat)
        private async void BtnReport_Click(object? sender, EventArgs e)
        {
            string? khoan = InputDialog.Show(MsgBox.OwnerWindow(this), "Ghi nhận thất thoát", "Khoản mục", "VD: Nguyên liệu hỏng");
            if (string.IsNullOrWhiteSpace(khoan)) return;
            string? sl = InputDialog.Show(MsgBox.OwnerWindow(this), "Ghi nhận thất thoát", "Số lượng", "VD: 0.5 kg");
            string? gtStr = InputDialog.Show(MsgBox.OwnerWindow(this), "Ghi nhận thất thoát", "Giá trị (đồng)", "VD: 80000");
            decimal.TryParse((gtStr ?? "").Replace(",", "").Replace(".", ""), out decimal gt);
            string? ndo = InputDialog.Show(MsgBox.OwnerWindow(this), "Ghi nhận thất thoát", "Nguyên nhân", "VD: Hết hạn");

            var dto = new LossDTO
            {
                KhoanMuc = khoan,
                SoLuong = sl ?? "",
                GiaTri = gt,
                NguyenNhan = ndo ?? "",
                NguoiPhatHien = GlobalSession.CurrentUser?.EmployeeId ?? "",
                Ngay = DateTime.Now.ToString("dd/MM/yyyy"),
                Timestamp = DateTimeOffset.Now.ToUnixTimeMilliseconds()
            };
            var (ok, msg, _) = await LossBUS.Add(dto);
            if (ok)
            {
                MsgBox.Show(MsgBox.OwnerWindow(this), "Đã ghi nhận khoản thất thoát!", "Thành công", MsgBox.MessageBoxType.Success);
                await LoadData();
            }
            else MsgBox.Show(MsgBox.OwnerWindow(this), msg, "Lỗi", MsgBox.MessageBoxType.Error);
        }

        // Double-click 1 dòng -> form chi tiết read-only đủ field
        private void DgvLossDetail_CellDoubleClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            RecordDetail.FromRow(dgvLossDetail.Rows[e.RowIndex], "Chi tiết khoản thất thoát")
                        .ShowDialog(MsgBox.OwnerWindow(this));
        }

        // Sửa dòng đang chọn (lưu thật)
        private async void BtnEditLoss_Click(object? sender, EventArgs e)
        {
            if (dgvLossDetail.CurrentRow == null || dgvLossDetail.CurrentRow.Index < 0)
            {
                MsgBox.Show(MsgBox.OwnerWindow(this), "Vui lòng chọn một khoản để sửa!", "Thông báo", MsgBox.MessageBoxType.Warning);
                return;
            }
            string id = (dgvLossDetail.CurrentRow.DataBoundItem as DataRowView)?["Mã"]?.ToString() ?? "";
            if (RecordEdit.EditRow(dgvLossDetail.CurrentRow, "Sửa khoản thất thoát", MsgBox.OwnerWindow(this)))
            {
                var row = dgvLossDetail.CurrentRow;
                decimal.TryParse(row.Cells["Giá trị"].Value?.ToString(), out decimal gt);
                if (!string.IsNullOrEmpty(id))
                    await LossBUS.Update(id, new
                    {
                        khoan_muc = row.Cells["Khoản mục"].Value?.ToString() ?? "",
                        so_luong = row.Cells["Số lượng"].Value?.ToString() ?? "",
                        gia_tri = gt,
                        nguyen_nhan = row.Cells["Nguyên nhân"].Value?.ToString() ?? ""
                    });
                await LoadData();
            }
        }

        private static void HighlightBtn(Guna2Button active, Guna2Button b1, Guna2Button b2)
        {
            active.FillColor = Color.FromArgb(31, 138, 154);
            active.HoverState.FillColor = Color.FromArgb(45, 158, 174);
            b1.FillColor = Color.FromArgb(45, 45, 48);
            b1.HoverState.FillColor = Color.FromArgb(60, 60, 65);
            b2.FillColor = Color.FromArgb(45, 45, 48);
            b2.HoverState.FillColor = Color.FromArgb(60, 60, 65);
        }

        private async Task LoadData()
        {
            var dt = new DataTable();
            dt.Columns.Add("Mã");   // ẩn (đọc qua DataRowView)
            dt.Columns.Add("Khoản mục");
            dt.Columns.Add("Số lượng");
            dt.Columns.Add("Giá trị", typeof(decimal));
            dt.Columns.Add("Nguyên nhân");
            dt.Columns.Add("Người phát hiện");

            decimal total = 0;
            DateTime now = DateTime.Now;
            var lossList = new System.Collections.Generic.List<LossDTO>();
            try
            {
                var all = await LossBUS.GetAll();
                lossList = all.Values.ToList();
                var emps = (await EmployeeBUS.GetAllEmployeesAsync())
                    .Where(x => x.EmployeeId != null).ToDictionary(x => x.EmployeeId!, x => x.FullName ?? x.EmployeeId!);

                foreach (var kv in all.OrderByDescending(x => x.Value.Timestamp))
                {
                    var l = kv.Value;
                    if (l.Timestamp > 0)
                    {
                        var d = DateTimeOffset.FromUnixTimeMilliseconds(l.Timestamp).LocalDateTime;
                        bool keep = _mode switch
                        {
                            "day" => d.Date == now.Date,
                            "year" => d.Year == now.Year,
                            _ => d.Year == now.Year && d.Month == now.Month
                        };
                        if (!keep) continue;
                    }
                    string finder = l.NguoiPhatHien ?? "";
                    if (finder != null && emps.TryGetValue(finder, out var n)) finder = n;
                    dt.Rows.Add(kv.Key, l.KhoanMuc, l.SoLuong, l.GiaTri, l.NguyenNhan, finder);
                    total += l.GiaTri;
                }
            }
            catch { /* offline */ }

            lblTotalLoss.Text = "Tổng thất thoát: " + Theme.Vnd((long)total);

            dgvLossDetail.DataSource = dt;
            if (dgvLossDetail.Columns.Contains("Mã")) dgvLossDetail.Columns["Mã"].Visible = false;
            dgvLossDetail.Columns["Giá trị"].DefaultCellStyle.Format = "N0";
            dgvLossDetail.Columns["Giá trị"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvLossDetail.Columns["Khoản mục"].FillWeight        = 22;
            dgvLossDetail.Columns["Số lượng"].FillWeight         = 13;
            dgvLossDetail.Columns["Giá trị"].FillWeight          = 14;
            dgvLossDetail.Columns["Nguyên nhân"].FillWeight      = 31;
            dgvLossDetail.Columns["Người phát hiện"].FillWeight  = 20;
            foreach (DataGridViewRow row in dgvLossDetail.Rows)
                row.DefaultCellStyle.ForeColor = Color.FromArgb(220, 80, 80);

            DrawLossChart(lossList);
        }

        private static string DowVi(DateTime d) => d.DayOfWeek switch
        {
            DayOfWeek.Monday => "T2",
            DayOfWeek.Tuesday => "T3",
            DayOfWeek.Wednesday => "T4",
            DayOfWeek.Thursday => "T5",
            DayOfWeek.Friday => "T6",
            DayOfWeek.Saturday => "T7",
            _ => "CN"
        };

        // Biểu đồ dựng từ DỮ LIỆU THẬT: gom giá trị thất thoát theo mốc thời gian, đơn vị nghìn đ.
        //   day  = 7 ngày gần nhất · month = 6 tháng gần nhất · year = 4 năm gần nhất.
        private void DrawLossChart(System.Collections.Generic.IEnumerable<LossDTO> losses)
        {
            DateTime now = DateTime.Now;
            string[] labels;
            decimal[] values;

            if (_mode == "day")
            {
                var days = Enumerable.Range(0, 7).Select(i => now.Date.AddDays(-6 + i)).ToArray();
                labels = days.Select(DowVi).ToArray();
                values = new decimal[days.Length];
                foreach (var l in losses)
                {
                    if (l.Timestamp <= 0) continue;
                    var d = DateTimeOffset.FromUnixTimeMilliseconds(l.Timestamp).LocalDateTime.Date;
                    int idx = Array.IndexOf(days, d);
                    if (idx >= 0) values[idx] += l.GiaTri;
                }
            }
            else if (_mode == "year")
            {
                var years = Enumerable.Range(0, 4).Select(i => now.Year - 3 + i).ToArray();
                labels = years.Select(y => y.ToString()).ToArray();
                values = new decimal[years.Length];
                foreach (var l in losses)
                {
                    if (l.Timestamp <= 0) continue;
                    var d = DateTimeOffset.FromUnixTimeMilliseconds(l.Timestamp).LocalDateTime;
                    int idx = Array.IndexOf(years, d.Year);
                    if (idx >= 0) values[idx] += l.GiaTri;
                }
            }
            else
            {
                var months = Enumerable.Range(0, 6)
                    .Select(i => new DateTime(now.Year, now.Month, 1).AddMonths(-5 + i)).ToArray();
                labels = months.Select(m => $"T{m.Month}").ToArray();
                values = new decimal[months.Length];
                foreach (var l in losses)
                {
                    if (l.Timestamp <= 0) continue;
                    var d = DateTimeOffset.FromUnixTimeMilliseconds(l.Timestamp).LocalDateTime;
                    int idx = Array.FindIndex(months, m => m.Year == d.Year && m.Month == d.Month);
                    if (idx >= 0) values[idx] += l.GiaTri;
                }
            }

            var ds = new GunaBarDataset { Label = "Thất thoát (nghìn đ)" };
            for (int i = 0; i < values.Length; i++)
                ds.DataPoints.Add(labels[i], (double)Math.Round(values[i] / 1000m, 1));
            ds.FillColors.Add(Color.FromArgb(220, 80, 80));

            chartLoss.Datasets.Clear();
            chartLoss.Datasets.Add(ds);
            chartLoss.Update();
        }
    }
}
