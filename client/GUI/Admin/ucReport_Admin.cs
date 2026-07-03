using System;
using System.Data;
using System.Drawing;
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

        private void ShowPreview(string type)
        {
            _currentType = type;
            // Bỏ cột mặc định khai trong Designer để AutoGenerateColumns sinh lại đúng schema từng loại
            dgvPreview.DataSource = null;
            dgvPreview.Columns.Clear();
            var dt = new DataTable();

            switch (type)
            {
                case "revenue":
                    lblPreviewTitle.Text = "Xem trước — Báo cáo doanh thu";
                    dt.Columns.Add("Ngày");
                    dt.Columns.Add("Số đơn", typeof(int));
                    dt.Columns.Add("Doanh thu", typeof(long));
                    dt.Columns.Add("Giảm giá", typeof(long));
                    dt.Columns.Add("Thực thu", typeof(long));
                    dt.Columns.Add("Hình thức TT");
                    dt.Rows.Add("01/06", 28, 4200000L, 210000L, 3990000L, "Tiền mặt 70%, VietQR 30%");
                    dt.Rows.Add("02/06", 32, 5100000L, 0L,      5100000L, "Tiền mặt 65%, Thẻ 35%");
                    dt.Rows.Add("03/06", 25, 3800000L, 380000L, 3420000L, "Tiền mặt 80%, VietQR 20%");
                    dt.Rows.Add("04/06", 41, 6500000L, 0L,      6500000L, "Tiền mặt 55%, VietQR 45%");
                    dt.Rows.Add("05/06", 38, 5900000L, 295000L, 5605000L, "Tiền mặt 60%, Thẻ 40%");
                    dgvPreview.DataSource = dt;
                    FormatCurrencyColumns(dt, "Doanh thu", "Giảm giá", "Thực thu");
                    // "Hình thức TT" chứa chuỗi dài -> nhường bề ngang cho nó
                    dgvPreview.Columns["Ngày"].FillWeight         = 10;
                    dgvPreview.Columns["Số đơn"].FillWeight       = 9;
                    dgvPreview.Columns["Doanh thu"].FillWeight    = 15;
                    dgvPreview.Columns["Giảm giá"].FillWeight     = 13;
                    dgvPreview.Columns["Thực thu"].FillWeight     = 15;
                    dgvPreview.Columns["Hình thức TT"].FillWeight = 38;
                    break;

                case "payroll":
                    lblPreviewTitle.Text = "Xem trước — Bảng lương";
                    dt.Columns.Add("Mã NV");
                    dt.Columns.Add("Họ tên");
                    dt.Columns.Add("Bộ phận");
                    dt.Columns.Add("Ngày công", typeof(int));
                    dt.Columns.Add("Tổng lương", typeof(long));
                    dt.Columns.Add("Trạng thái");
                    dt.Rows.Add("NV001", "Nguyễn Văn An",  "Quản lý",    26, 18500000L, "Đã thanh toán");
                    dt.Rows.Add("NV002", "Trần Thị Bích",  "Pha chế",    24,  8200000L, "Đã thanh toán");
                    dt.Rows.Add("NV003", "Lê Hoàng Nam",   "Order Staff",25,  7100000L, "Đã thanh toán");
                    dt.Rows.Add("NV004", "Phạm Minh Tuấn", "Bảo vệ",     28,  6800000L, "Chờ duyệt");
                    dgvPreview.DataSource = dt;
                    FormatCurrencyColumns(dt, "Tổng lương");
                    break;

                case "inventory":
                    lblPreviewTitle.Text = "Xem trước — Báo cáo kho hàng";
                    dt.Columns.Add("Nguyên liệu");
                    dt.Columns.Add("Tồn đầu", typeof(int));
                    dt.Columns.Add("Nhập thêm", typeof(int));
                    dt.Columns.Add("Đã dùng", typeof(int));
                    dt.Columns.Add("Tồn cuối", typeof(int));
                    dt.Columns.Add("Đơn vị");
                    dt.Columns.Add("Trạng thái");
                    dt.Rows.Add("Cà phê Arabica",   50, 30, 62, 18, "kg",  "Cần nhập thêm");
                    dt.Rows.Add("Sữa tươi",         80, 60, 90, 50, "lít", "Bình thường");
                    dt.Rows.Add("Đường trắng",      20, 10, 18, 12, "kg",  "Bình thường");
                    dt.Rows.Add("Ly nhựa 500ml",   500,200,480,220, "cái", "Cần nhập thêm");
                    dgvPreview.DataSource = dt;
                    break;

                case "feedback":
                    lblPreviewTitle.Text = "Xem trước — Báo cáo Feedback";
                    dt.Columns.Add("Tuần");
                    dt.Columns.Add("Tổng FB", typeof(int));
                    dt.Columns.Add("Tốt", typeof(int));
                    dt.Columns.Add("Trung bình", typeof(int));
                    dt.Columns.Add("Xấu", typeof(int));
                    dt.Columns.Add("Điểm TB", typeof(double));
                    dt.Rows.Add("W1 (01–07/6)", 42, 35, 5, 2, 4.6);
                    dt.Rows.Add("W2 (08–14/6)", 38, 30, 6, 2, 4.5);
                    dt.Rows.Add("W3 (15–21/6)", 51, 44, 4, 3, 4.7);
                    dt.Rows.Add("W4 (22–28/6)", 29, 26, 2, 1, 4.8);
                    dgvPreview.DataSource = dt;
                    break;
            }

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
