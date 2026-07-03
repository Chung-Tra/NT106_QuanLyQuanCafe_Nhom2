using BUS;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace GUI
{
    public partial class ucReport_Admin : UserControl
    {
        private Guna2Button _activeType = null!;
        private string _currentType = "revenue";

        public ucReport_Admin()
        {
            InitializeComponent();

            // Runtime styling of the preview grid
            Theme.StyleGrid(dgvPreview);
            // dgvPreview đổi cột theo từng loại báo cáo → cần tự sinh cột lúc bind
            dgvPreview.AutoGenerateColumns = true;

            // Wire up the report-type buttons
            WireTypeButton(btnRevenue, "revenue");
            WireTypeButton(btnPayroll, "payroll");
            WireTypeButton(btnInventory, "inventory");
            WireTypeButton(btnFeedback, "feedback");
            _activeType = btnRevenue;
            MarkActive(btnRevenue);

            // Populate the month combo box
            string[] months = { "Tháng 1","Tháng 2","Tháng 3","Tháng 4","Tháng 5","Tháng 6",
                                 "Tháng 7","Tháng 8","Tháng 9","Tháng 10","Tháng 11","Tháng 12" };
            cmbMonth.Items.AddRange(months);
            cmbMonth.SelectedIndex = DateTime.Now.Month - 1;
            cmbMonth.SelectedIndexChanged += (s, e) => ShowPreview(_currentType);

            // Action buttons
            btnExcelExport.Click += (s, e) => ExportReport("Excel");
            btnPdfExport.Click += (s, e) => ExportReport("PDF");

            // Double-click 1 dòng xem trước -> form chi tiết read-only đủ field
            dgvPreview.CellDoubleClick += DgvPreview_CellDoubleClick;

            DgvRefresh.Attach(dgvPreview, () => ShowPreview(_currentType));

            Load += (s, e) => ShowPreview("revenue");
        }

        private int SelectedMonth() => cmbMonth.SelectedIndex >= 0 ? cmbMonth.SelectedIndex + 1 : DateTime.Now.Month;

        private static string MethodShort(string? code) => code switch
        {
            "tien_mat" => "TM",
            "the" => "Thẻ",
            "vietqr" => "QR",
            "momo" => "Momo",
            "chuyen_khoan" => "CK",
            _ => code ?? "?"
        };

        private void DgvPreview_CellDoubleClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            RecordDetail.FromRow(dgvPreview.Rows[e.RowIndex], "Chi tiết dòng báo cáo")
                        .ShowDialog(MsgBox.OwnerWindow(this));
        }

        private void WireTypeButton(Guna2Button b, string typeKey)
        {
            b.Click += (s, e) =>
            {
                MarkActive(b);
                ShowPreview(typeKey);
            };
        }

        private void MarkActive(Guna2Button btn)
        {
            if (_activeType != null)
            {
                _activeType.FillColor    = Color.Transparent;
                _activeType.ForeColor    = Theme.TextPri;
                _activeType.BorderColor  = Theme.Border;
            }
            btn.FillColor   = Theme.Teal;
            btn.ForeColor   = Color.White;
            btn.BorderColor = Theme.Teal;
            _activeType = btn;
        }

        private async void ShowPreview(string type)
        {
            _currentType = type;
            int month = SelectedMonth();
            int year = DateTime.Now.Year;

            dgvPreview.DataSource = null;
            dgvPreview.Columns.Clear();
            var dt = new DataTable();

            try
            {
                switch (type)
                {
                    case "revenue":
                        lblPreviewTitle.Text = $"Xem trước — Báo cáo doanh thu (Tháng {month})";
                        dt.Columns.Add("Ngày");
                        dt.Columns.Add("Số đơn", typeof(int));
                        dt.Columns.Add("Doanh thu", typeof(long));
                        dt.Columns.Add("Giảm giá", typeof(long));
                        dt.Columns.Add("Thực thu", typeof(long));
                        dt.Columns.Add("Hình thức TT");
                        {
                            var payments = (await PaymentBUS.GetAll()).Values
                                .Where(p => p.Timestamp > 0)
                                .Select(p => new { P = p, D = DateTimeOffset.FromUnixTimeMilliseconds(p.Timestamp).LocalDateTime })
                                .Where(x => x.D.Month == month && x.D.Year == year)
                                .GroupBy(x => x.D.Date)
                                .OrderBy(g => g.Key);
                            foreach (var g in payments)
                            {
                                string httt = string.Join(" · ", g.GroupBy(x => MethodShort(x.P.Method))
                                                                   .Select(m => $"{m.Key} {m.Count()}"));
                                dt.Rows.Add(g.Key.ToString("dd/MM"), g.Count(),
                                    (long)g.Sum(x => x.P.TotalAmount), (long)g.Sum(x => x.P.Discount),
                                    (long)g.Sum(x => x.P.ActualReceived), httt);
                            }
                        }
                        dgvPreview.DataSource = dt;
                        FormatCurrencyColumns(dt, "Doanh thu", "Giảm giá", "Thực thu");
                        dgvPreview.Columns["Ngày"].FillWeight         = 10;
                        dgvPreview.Columns["Số đơn"].FillWeight       = 9;
                        dgvPreview.Columns["Doanh thu"].FillWeight    = 15;
                        dgvPreview.Columns["Giảm giá"].FillWeight     = 13;
                        dgvPreview.Columns["Thực thu"].FillWeight     = 15;
                        dgvPreview.Columns["Hình thức TT"].FillWeight = 38;
                        break;

                    case "payroll":
                        lblPreviewTitle.Text = $"Xem trước — Bảng lương (Tháng {month})";
                        dt.Columns.Add("Mã NV");
                        dt.Columns.Add("Họ tên");
                        dt.Columns.Add("Bộ phận");
                        dt.Columns.Add("Ngày công", typeof(int));
                        dt.Columns.Add("Tổng lương", typeof(long));
                        dt.Columns.Add("Trạng thái");
                        {
                            var salaries = await SalaryBUS.GetAll();
                            var emps = (await EmployeeBUS.GetAllEmployeesAsync())
                                .Where(x => x.EmployeeId != null).ToDictionary(x => x.EmployeeId!, x => x);
                            foreach (var s in salaries.Values.Where(s => s.Month == month).OrderBy(s => s.EmployeeId))
                            {
                                emps.TryGetValue(s.EmployeeId ?? "", out var emp);
                                string st = s.Status switch { "da_duyet" => "Đã duyệt", "da_tra" => "Đã thanh toán", _ => "Chờ duyệt" };
                                dt.Rows.Add(s.EmployeeId, emp?.FullName ?? "", EmployeeText.RoleVi(emp?.Role),
                                    s.WorkDays, (long)s.TotalSalary, st);
                            }
                        }
                        dgvPreview.DataSource = dt;
                        FormatCurrencyColumns(dt, "Tổng lương");
                        break;

                    case "inventory":
                        lblPreviewTitle.Text = "Xem trước — Báo cáo kho hàng";
                        dt.Columns.Add("Nguyên liệu");
                        dt.Columns.Add("Tồn kho", typeof(double));
                        dt.Columns.Add("Tối thiểu", typeof(double));
                        dt.Columns.Add("Đơn vị");
                        dt.Columns.Add("Giá nhập", typeof(long));
                        dt.Columns.Add("Trạng thái");
                        {
                            var ings = await IngredientBUS.GetAll();
                            foreach (var i in ings.OrderBy(x => x.Name))
                                dt.Rows.Add(i.Name, i.Stock, i.MinStock, i.Unit, i.ImportPrice,
                                    i.Stock <= i.MinStock ? "Cần nhập thêm" : "Bình thường");
                        }
                        dgvPreview.DataSource = dt;
                        FormatCurrencyColumns(dt, "Giá nhập");
                        break;

                    case "feedback":
                        lblPreviewTitle.Text = $"Xem trước — Báo cáo Feedback (Tháng {month})";
                        dt.Columns.Add("Tuần");
                        dt.Columns.Add("Tổng FB", typeof(int));
                        dt.Columns.Add("Tốt", typeof(int));
                        dt.Columns.Add("Trung bình", typeof(int));
                        dt.Columns.Add("Xấu", typeof(int));
                        dt.Columns.Add("Điểm TB", typeof(double));
                        {
                            var fbs = (await FeedbackBUS.GetAll()).Values
                                .Where(f => f.Timestamp > 0)
                                .Select(f => new { F = f, D = DateTimeOffset.FromUnixTimeMilliseconds(f.Timestamp).LocalDateTime })
                                .Where(x => x.D.Month == month && x.D.Year == year)
                                .GroupBy(x => (x.D.Day - 1) / 7 + 1)
                                .OrderBy(g => g.Key);
                            foreach (var g in fbs)
                            {
                                int tot = g.Count();
                                int good = g.Count(x => x.F.Rating >= 4);
                                int mid = g.Count(x => x.F.Rating == 3);
                                int bad = g.Count(x => x.F.Rating <= 2);
                                double avg = tot > 0 ? Math.Round(g.Average(x => x.F.Rating), 1) : 0;
                                dt.Rows.Add($"Tuần {g.Key}", tot, good, mid, bad, avg);
                            }
                        }
                        dgvPreview.DataSource = dt;
                        break;
                }
            }
            catch { /* offline: bảng rỗng */ }

            dgvPreview.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void FormatCurrencyColumns(DataTable dt, params string[] cols)
        {
            foreach (string col in cols)
            {
                if (!dgvPreview.Columns.Contains(col)) continue;
                dgvPreview.Columns[col].DefaultCellStyle.Format    = "N0";
                dgvPreview.Columns[col].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
        }

        private void ExportReport(string format)
        {
            string type = _currentType switch
            {
                "revenue"   => "DoanhThu",
                "payroll"   => "BangLuong",
                "inventory" => "KhoHang",
                "feedback"  => "Feedback",
                _           => "BaoCao",
            };
            string baseName = $"BaoCao_{type}_{DateTime.Now:yyyyMM}";

            // Mở hộp thoại để người dùng tự chọn nơi lưu rồi ghi file thật.
            if (format == "PDF")
                GridExporter.ExportPdf(dgvPreview, MsgBox.OwnerWindow(this), baseName, lblPreviewTitle.Text);
            else
                GridExporter.ExportExcel(dgvPreview, MsgBox.OwnerWindow(this), baseName, lblPreviewTitle.Text);
        }
    }
}
