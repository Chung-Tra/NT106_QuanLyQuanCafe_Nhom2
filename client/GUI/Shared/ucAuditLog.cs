using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace GUI
{
    public partial class ucAuditLog : UserControl
    {
        private DataTable _dtFull = null!;

        public ucAuditLog()
        {
            InitializeComponent();

            // Runtime styling + dynamic wiring (kept in code-behind)
            Theme.StyleGrid(dgvAudit);
            dgvAudit.CellDoubleClick += DgvAudit_CellDoubleClick;
            DgvRefresh.Attach(dgvAudit, LoadData);

            txtSearch.TextChanged += (s, e) => ApplyFilter();
            cmbAction.SelectedIndexChanged += (s, e) => ApplyFilter();
            cmbUser.SelectedIndexChanged += (s, e) => ApplyFilter();
            btnClear.Click += (s, e) =>
            {
                txtSearch.Clear();
                cmbAction.SelectedIndex = 0;
                cmbUser.SelectedIndex = 0;
                ApplyFilter();
            };

            Load += (s, e) => LoadData();
        }

        private void LoadData()
        {
            _dtFull = new DataTable();
            _dtFull.Columns.Add("Thời gian");
            _dtFull.Columns.Add("Nhân viên");
            _dtFull.Columns.Add("Vai trò");
            _dtFull.Columns.Add("Thao tác");
            _dtFull.Columns.Add("Đối tượng");
            _dtFull.Columns.Add("Lý do");
            _dtFull.Columns.Add("IP");

            _dtFull.Rows.Add("2026-06-24 08:02", "Trần Văn Minh", "Quản trị viên",  "Đăng nhập",    "Hệ thống",         "---",                          "192.168.1.10");
            _dtFull.Rows.Add("2026-06-24 08:15", "Nguyễn Hồng An", "Quản lý",       "Phê duyệt",    "Đơn nghỉ NV007",   "Duyệt nghỉ phép tháng 6",      "192.168.1.11");
            _dtFull.Rows.Add("2026-06-24 09:30", "Lê Thu Hà",     "Quản lý",        "Xóa",          "Nguyên liệu #012", "Nguyên liệu hết hạn sử dụng",  "192.168.1.11");
            _dtFull.Rows.Add("2026-06-24 10:05", "Trần Văn Minh", "Quản trị viên",  "Sửa thông tin","NV002 Lê Thu Hà",  "Cập nhật số điện thoại",        "192.168.1.10");
            _dtFull.Rows.Add("2026-06-24 11:15", "Phạm Bảo Nam",  "Nhân viên Order","Thanh toán",   "Đơn #HD20240624",  "Xác nhận thanh toán khách bàn 3","192.168.1.14");
            _dtFull.Rows.Add("2026-06-24 11:45", "Lê Thu Hà",     "Quản lý",        "Xuất báo cáo", "Doanh thu T6",     "Gửi cho admin cuối ngày",       "192.168.1.11");
            _dtFull.Rows.Add("2026-06-24 13:00", "Trần Văn Minh", "Quản trị viên",  "Xóa",          "NV010 (nghỉ việc)","Nhân viên đã nghỉ việc chính thức","192.168.1.10");
            _dtFull.Rows.Add("2026-06-24 14:20", "Nguyễn Hồng An","Quản lý",        "Sửa thông tin","Giá món CF001",    "Điều chỉnh giá do lạm phát",    "192.168.1.11");
            _dtFull.Rows.Add("2026-06-24 15:00", "Đinh Quốc Bảo", "Pha chế",        "Đăng nhập",    "Hệ thống",         "---",                           "192.168.1.15");
            _dtFull.Rows.Add("2026-06-24 16:30", "Phạm Bảo Nam",  "Nhân viên Order","Phê duyệt",    "Phiếu hủy đơn",    "Khách đổi ý, chưa pha",         "192.168.1.14");

            ApplyFilter();
        }

        private void ApplyFilter()
        {
            if (_dtFull == null) return;

            string action = cmbAction.SelectedIndex > 0 ? cmbAction.SelectedItem?.ToString() ?? "" : "";
            string role   = cmbUser.SelectedIndex > 0 ? cmbUser.SelectedItem?.ToString() ?? "" : "";

            var view = _dtFull.DefaultView;
            var parts = new System.Collections.Generic.List<string>();

            // Từ khóa quét mọi cột (thời gian, nhân viên, vai trò, thao tác, đối tượng, lý do, IP)
            string kwFilter = SearchFilter.AllColumnsFilter(_dtFull, txtSearch.Text);
            if (!string.IsNullOrEmpty(kwFilter))
                parts.Add(kwFilter);
            if (!string.IsNullOrEmpty(action))
                parts.Add($"[Thao tác] = '{action}'");
            if (!string.IsNullOrEmpty(role))
                parts.Add($"[Vai trò] = '{role}'");

            try
            {
                view.RowFilter = string.Join(" AND ", parts);
            }
            catch { view.RowFilter = ""; }

            dgvAudit.DataSource = view.ToTable();

            if (dgvAudit.Columns.Count > 0)
            {
                dgvAudit.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                if (dgvAudit.Columns.Contains("Thời gian"))   dgvAudit.Columns["Thời gian"].FillWeight   = 13;
                if (dgvAudit.Columns.Contains("Nhân viên"))   dgvAudit.Columns["Nhân viên"].FillWeight   = 14;
                if (dgvAudit.Columns.Contains("Vai trò"))     dgvAudit.Columns["Vai trò"].FillWeight     = 10;
                if (dgvAudit.Columns.Contains("Thao tác"))    dgvAudit.Columns["Thao tác"].FillWeight    = 11;
                if (dgvAudit.Columns.Contains("Đối tượng"))   dgvAudit.Columns["Đối tượng"].FillWeight   = 16;
                if (dgvAudit.Columns.Contains("Lý do"))       dgvAudit.Columns["Lý do"].FillWeight       = 26;
                if (dgvAudit.Columns.Contains("IP"))          dgvAudit.Columns["IP"].FillWeight          = 10;

                ColorRows();
            }

            lblCount.Text = $"{dgvAudit.Rows.Count} bản ghi";
        }

        private void ColorRows()
        {
            foreach (DataGridViewRow row in dgvAudit.Rows)
            {
                string action = row.Cells["Thao tác"].Value?.ToString() ?? "";
                row.Cells["Thao tác"].Style.ForeColor = action switch
                {
                    "Xóa"          => Theme.Red,
                    "Phê duyệt"    => Theme.Green,
                    "Thanh toán"   => Theme.Teal,
                    "Xuất báo cáo" => Theme.Blue,
                    _              => Theme.TextPri,
                };
            }
        }

        // Double-click 1 dòng -> form chi tiết read-only đủ field
        private void DgvAudit_CellDoubleClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            RecordDetail.FromRow(dgvAudit.Rows[e.RowIndex], "Chi tiết nhật ký")
                        .ShowDialog(MsgBox.OwnerWindow(this));
        }
    }
}
