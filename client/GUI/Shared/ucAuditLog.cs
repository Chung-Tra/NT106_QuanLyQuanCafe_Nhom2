using BUS;
using DTO;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
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

        private async void LoadData()
        {
            _dtFull = new DataTable();
            _dtFull.Columns.Add("Thời gian");
            _dtFull.Columns.Add("Nhân viên");
            _dtFull.Columns.Add("Vai trò");
            _dtFull.Columns.Add("Thao tác");
            _dtFull.Columns.Add("Đối tượng");
            _dtFull.Columns.Add("Lý do");
            _dtFull.Columns.Add("IP");

            // Quy tắc: Manager xem data mọi role TRỪ admin. Admin xem tất cả.
            // -> Người xem là manager thì ẩn mọi dòng nhật ký thao tác của admin.
            bool hideAdmin = GlobalSession.CurrentUser?.Role?.ToLower() == "manager";

            try
            {
                var logs = await AuditLogBUS.GetAll();
                foreach (var kv in logs.OrderByDescending(x => x.Value.Timestamp))
                {
                    var l = kv.Value;
                    if (hideAdmin && l.VaiTro == "Quản trị viên") continue;
                    string time = l.Timestamp > 0
                        ? DateTimeOffset.FromUnixTimeMilliseconds(l.Timestamp).LocalDateTime.ToString("yyyy-MM-dd HH:mm")
                        : "";
                    _dtFull.Rows.Add(time, l.Ten, l.VaiTro, l.ThaoTac, l.DoiTuong, l.LyDo, l.Ip);
                }
            }
            catch { /* offline */ }

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
