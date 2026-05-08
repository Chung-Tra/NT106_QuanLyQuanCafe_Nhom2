using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace GUI
{
    /// <summary>
    /// Trung tâm phát thông báo nội bộ.
    /// - Hiển thị lịch sử thông báo đã gửi (status, người nhận, thời gian)
    /// - Nút "Soạn thông báo mới" mở `BroadcastMessage` dialog
    /// </summary>
    public class ucBroadcastCenter : UserControl
    {
        private DataGridView dgvHistory = null!;
        private Button btnNew = null!;
        private Button btnRefresh = null!;
        private Label lblTitle = null!;
        private Label lblTotal = null!;
        private Label lblToday = null!;
        private TextBox txtSearch = null!;

        public ucBroadcastCenter()
        {
            BackColor = Color.FromArgb(37, 37, 38);
            ForeColor = Color.White;
            Font = new Font("Segoe UI", 9F);
            Dock = DockStyle.Fill;

            BuildUI();
            LoadHistory();
        }

        private void BuildUI()
        {
            int pad = 16;

            lblTitle = new Label
            {
                Text = "Trung tâm phát thông báo",
                Location = new Point(pad, 12),
                Font = new Font("Segoe UI", 13F, FontStyle.Bold),
                ForeColor = Color.White,
                AutoSize = true
            };

            lblTotal = new Label
            {
                Text = "Tổng đã gửi: 0",
                Location = new Point(pad, 46),
                ForeColor = Color.MediumSeaGreen,
                AutoSize = true
            };
            lblToday = new Label
            {
                Text = "Hôm nay: 0",
                Location = new Point(pad + 160, 46),
                ForeColor = Color.SteelBlue,
                AutoSize = true
            };

            // Tìm kiếm
            txtSearch = new TextBox
            {
                Location = new Point(pad, 78),
                Width = 280,
                BackColor = Color.FromArgb(60, 60, 65),
                ForeColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle,
                PlaceholderText = "Tìm theo tiêu đề / nội dung..."
            };
            txtSearch.TextChanged += (s, e) => ApplyFilter();

            // Buttons
            btnNew = new Button
            {
                Text = "+ Soạn thông báo mới",
                Location = new Point(pad + 300, 75),
                Size = new Size(180, 32),
                BackColor = Color.SteelBlue,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 9.5F, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            btnNew.Click += BtnNew_Click;

            btnRefresh = new Button
            {
                Text = "Làm mới",
                Location = new Point(pad + 488, 75),
                Size = new Size(90, 32),
                BackColor = Color.FromArgb(60, 60, 65),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btnRefresh.Click += (s, e) => LoadHistory();

            // Grid
            dgvHistory = new DataGridView
            {
                Location = new Point(pad, 120),
                Size = new Size(900, 380),
                BackgroundColor = Color.FromArgb(45, 45, 48),
                ForeColor = Color.White,
                ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle
                {
                    BackColor = Color.FromArgb(30, 30, 30),
                    ForeColor = Color.White,
                    Font = new Font("Segoe UI", 9F, FontStyle.Bold)
                },
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    BackColor = Color.FromArgb(45, 45, 48),
                    ForeColor = Color.White,
                    SelectionBackColor = Color.SteelBlue
                },
                ReadOnly = true,
                AllowUserToAddRows = false,
                RowHeadersVisible = false,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect
            };

            Controls.AddRange([
                lblTitle, lblTotal, lblToday,
                txtSearch, btnNew, btnRefresh, dgvHistory
            ]);
        }

        private void BtnNew_Click(object? sender, EventArgs e)
        {
            using var dlg = new BroadcastMessage();
            if (dlg.ShowDialog(MsgBox.OwnerWindow(this)) == DialogResult.OK)
            {
                MsgBox.Show(MsgBox.OwnerWindow(this), "Đã gửi thông báo!", "Thành công", MsgBox.MessageBoxType.Success);
                LoadHistory();
            }
        }

        private void LoadHistory()
        {
            var dt = new DataTable();
            dt.Columns.Add("Thời gian");
            dt.Columns.Add("Người nhận");
            dt.Columns.Add("Tiêu đề");
            dt.Columns.Add("Mức độ");
            dt.Columns.Add("Đã đọc");
            dt.Columns.Add("Trạng thái");

            dt.Rows.Add("06/05 19:20", "Toàn bộ NV", "Họp giao ban tuần 5/5",   "Thường",      "5/8",  "Đã gửi");
            dt.Rows.Add("06/05 14:05", "NV002 - Bích",  "Yêu cầu giải trình muộn 05/05", "Quan trọng !", "1/1",  "Đã đọc");
            dt.Rows.Add("06/05 09:15", "Toàn bộ NV", "Cập nhật giờ làm thứ 7",    "Thường",      "7/8",  "Đã gửi");
            dt.Rows.Add("05/05 21:30", "Toàn bộ Pha chế",   "Thay đổi công thức Latte",  "Khẩn cấp !!!", "3/3",  "Đã đọc");
            dt.Rows.Add("05/05 16:50", "NV004 - Tuấn",  "Lịch trực ca tối nay",       "Thường",      "1/1",  "Đã đọc");
            dt.Rows.Add("04/05 11:00", "Toàn bộ NV", "Thông báo nghỉ lễ 30/4-1/5", "Quan trọng !", "8/8",  "Đã đọc");

            dgvHistory.DataSource = dt;

            foreach (DataGridViewRow row in dgvHistory.Rows)
            {
                string level = row.Cells["Mức độ"].Value?.ToString() ?? "";
                row.Cells["Mức độ"].Style.ForeColor = level switch
                {
                    "Khẩn cấp !!!" => Color.IndianRed,
                    "Quan trọng !" => Color.Orange,
                    _              => Color.LightGray
                };

                string status = row.Cells["Trạng thái"].Value?.ToString() ?? "";
                row.Cells["Trạng thái"].Style.ForeColor =
                    status == "Đã đọc" ? Color.MediumSeaGreen : Color.SteelBlue;
            }

            lblTotal.Text = $"Tổng đã gửi: {dt.Rows.Count}";
            lblToday.Text = "Hôm nay: 3";
        }

        private void ApplyFilter()
        {
            if (dgvHistory.DataSource is not DataTable dt) return;
            string keyword = txtSearch.Text.Trim().Replace("'", "''");
            dt.DefaultView.RowFilter = string.IsNullOrEmpty(keyword)
                ? string.Empty
                : $"[Tiêu đề] LIKE '%{keyword}%' OR [Người nhận] LIKE '%{keyword}%'";
        }
    }
}
