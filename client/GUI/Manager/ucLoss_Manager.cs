using System;
using System.Data;
using System.Drawing;
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
            DgvRefresh.Attach(dgvLossDetail, LoadData);
            LoadData();
        }

        private void BtnDay_Click(object? sender, EventArgs e)
        {
            _mode = "day";
            HighlightBtn(btnDay, btnMonth, btnYear);
            LoadData();
        }

        private void BtnMonth_Click(object? sender, EventArgs e)
        {
            _mode = "month";
            HighlightBtn(btnMonth, btnDay, btnYear);
            LoadData();
        }

        private void BtnYear_Click(object? sender, EventArgs e)
        {
            _mode = "year";
            HighlightBtn(btnYear, btnDay, btnMonth);
            LoadData();
        }

        private void BtnReport_Click(object? sender, EventArgs e)
        {
            var dlg = new ReportIncident("Thất thoát hao phí");
            var dr = dlg.ShowDialog(MsgBox.OwnerWindow(this));
            if (dr == DialogResult.OK || dr == DialogResult.Yes)
                MsgBox.Show(MsgBox.OwnerWindow(this), "Đã gửi báo cáo!", "Thành công", MsgBox.MessageBoxType.Success);
        }

        // Double-click 1 dòng -> form chi tiết read-only đủ field
        private void DgvLossDetail_CellDoubleClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            RecordDetail.FromRow(dgvLossDetail.Rows[e.RowIndex], "Chi tiết khoản thất thoát")
                        .ShowDialog(MsgBox.OwnerWindow(this));
        }

        // Sửa dòng đang chọn (khoá cột mã/ID)
        private void BtnEditLoss_Click(object? sender, EventArgs e)
        {
            if (dgvLossDetail.CurrentRow == null || dgvLossDetail.CurrentRow.Index < 0)
            {
                MsgBox.Show(MsgBox.OwnerWindow(this), "Vui lòng chọn một khoản để sửa!", "Thông báo", MsgBox.MessageBoxType.Warning);
                return;
            }
            RecordEdit.EditRow(dgvLossDetail.CurrentRow, "Sửa khoản thất thoát", MsgBox.OwnerWindow(this));
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

        private void LoadData()
        {
            var dt = new DataTable();
            dt.Columns.Add("Khoản mục");
            dt.Columns.Add("Số lượng");
            dt.Columns.Add("Giá trị", typeof(decimal));
            dt.Columns.Add("Nguyên nhân");
            dt.Columns.Add("Người phát hiện");

            switch (_mode)
            {
                case "day":
                    lblTotalLoss.Text = "Tổng thất thoát: 320,000 đ";
                    dt.Rows.Add("Nguyên liệu hỏng",    "0.5 kg sữa",   80000m,  "Hết hạn",         "Kho A");
                    dt.Rows.Add("Chênh lệch quỹ",       "—",            120000m, "Kiểm quỹ cuối ca","Thu ngân");
                    dt.Rows.Add("Dụng cụ bị vỡ",        "1 ly thủy tinh", 45000m,"Nhân viên đánh vỡ","Quầy bar");
                    dt.Rows.Add("Hao hụt nguyên liệu",  "100g bột cacao",75000m, "Pha sai công thức","Pha chế");
                    break;
                case "year":
                    lblTotalLoss.Text = "Tổng thất thoát: 28,500,000 đ";
                    dt.Rows.Add("Nguyên liệu hết hạn",  "85 kg",        12500000m,"Quản lý kho kém","Kho");
                    dt.Rows.Add("Dụng cụ hỏng / vỡ",   "42 món",       4200000m, "Sử dụng",        "Barista");
                    dt.Rows.Add("Chênh lệch tiền quỹ",  "—",            6800000m, "Kiểm quỹ",       "Thu ngân");
                    dt.Rows.Add("Pha sai công thức",    "~350 ly",      5000000m, "Thiếu đào tạo",  "Barista");
                    break;
                default: // month
                    lblTotalLoss.Text = "Tổng thất thoát: 2,500,000 đ";
                    dt.Rows.Add("Nguyên liệu hỏng",    "3.2 kg",       800000m,  "Hết hạn",         "Kho A");
                    dt.Rows.Add("Chênh lệch quỹ",       "—",            700000m,  "Kiểm quỹ cuối ca","Thu ngân");
                    dt.Rows.Add("Dụng cụ bị vỡ",        "5 ly + 2 đĩa", 450000m, "Nhân viên",       "Quầy bar");
                    dt.Rows.Add("Hao hụt nguyên liệu",  "1.2 kg bột",   350000m, "Pha sai CT",      "Pha chế");
                    dt.Rows.Add("Mất tài sản nhỏ",      "3 muỗng cafe", 200000m,  "Không rõ",        "—");
                    break;
            }

            dgvLossDetail.DataSource = dt;
            dgvLossDetail.Columns["Giá trị"].DefaultCellStyle.Format = "N0";
            dgvLossDetail.Columns["Giá trị"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvLossDetail.Columns["Khoản mục"].FillWeight        = 22;
            dgvLossDetail.Columns["Số lượng"].FillWeight         = 13;
            dgvLossDetail.Columns["Giá trị"].FillWeight          = 14;
            dgvLossDetail.Columns["Nguyên nhân"].FillWeight      = 31;
            dgvLossDetail.Columns["Người phát hiện"].FillWeight  = 20;
            foreach (DataGridViewRow row in dgvLossDetail.Rows)
                row.DefaultCellStyle.ForeColor = Color.FromArgb(220, 80, 80);

            DrawLossChart();
        }

        private void DrawLossChart()
        {
            int[] values = _mode switch
            {
                "day"  => new[] { 320, 280, 410, 190, 350, 320, 300 },
                "year" => new[] { 18500, 22000, 25000, 28500 },
                _      => new[] { 1800, 2100, 2800, 2200, 2500, 2300 }
            };
            string[] labels = _mode switch
            {
                "day"  => new[] { "T2", "T3", "T4", "T5", "T6", "T7", "CN" },
                "year" => new[] { "2023", "2024", "2025", "2026" },
                _      => new[] { "T10", "T11", "T12", "T1", "T2", "T3" }
            };

            var ds = new GunaBarDataset { Label = "Thất thoát (nghìn đ)" };
            for (int i = 0; i < values.Length; i++)
                ds.DataPoints.Add(labels[i], values[i]);
            ds.FillColors.Add(Color.FromArgb(220, 80, 80));

            chartLoss.Datasets.Clear();
            chartLoss.Datasets.Add(ds);
            chartLoss.Update();
        }
    }
}
