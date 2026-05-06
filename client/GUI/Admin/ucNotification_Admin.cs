using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace GUI
{
    public partial class ucNotification_Admin : UserControl
    {
        private DataTable _dtNotif = new();

        public ucNotification_Admin()
        {
            InitializeComponent();
            this.Load += (s, e) => LoadMockNotifications();
        }

        private void LoadMockNotifications()
        {
            _dtNotif = new DataTable();
            _dtNotif.Columns.Add("ID", typeof(int));
            _dtNotif.Columns.Add("Loại");
            _dtNotif.Columns.Add("Từ");
            _dtNotif.Columns.Add("Nội dung");
            _dtNotif.Columns.Add("Thời gian");
            _dtNotif.Columns.Add("Đã đọc", typeof(bool));
            _dtNotif.Columns.Add("Trang liên quan");

            _dtNotif.Rows.Add(1, "Xin nghỉ", "QL Nguyễn Văn An", "Xin nghỉ ngày 05/05/2026 - Lý do: Việc gia đình cần giải quyết gấp", "02/05 10:30", false, "leave");
            _dtNotif.Rows.Add(2, "Sửa nguyên liệu", "QL Trần Minh", "Đã sửa giá nguyên liệu 'Cà phê Arabica' từ 250,000đ → 280,000đ. Lý do: Nhà cung cấp tăng giá", "02/05 09:15", false, "stock");
            _dtNotif.Rows.Add(3, "Feedback xấu", "Hệ thống", "Khách hàng Lê Phúc đánh giá 1★: 'Ly bị vỡ, nhân viên thái độ'. Quản lý CHƯA XỬ LÝ.", "02/05 08:45", false, "feedback");
            _dtNotif.Rows.Add(4, "Xóa nguyên liệu", "QL Nguyễn Văn An", "Đã xóa nguyên liệu 'Syrup dâu' khỏi kho. Lý do: Ngừng kinh doanh dòng sản phẩm dâu", "01/05 16:20", false, "stock");
            _dtNotif.Rows.Add(5, "Chấm công", "QL Trần Minh", "Đã sửa giờ check-in của NV Đỗ Hương từ 08:30 → 07:55. Lý do: Hệ thống ghi nhận sai", "01/05 14:00", false, "attendance");
            _dtNotif.Rows.Add(6, "Thêm nguyên liệu", "QL Nguyễn Văn An", "Đã thêm nguyên liệu mới 'Bột matcha Nhật'. Lý do: Bổ sung menu mới", "01/05 10:30", true, "stock");
            _dtNotif.Rows.Add(7, "Feedback xấu", "Hệ thống", "Khách hàng Trần Minh đánh giá 2★: 'Đồ uống ngọt quá'. QL đã trả lời xin lỗi và hứa cải thiện.", "30/04 15:00", true, "feedback");
            _dtNotif.Rows.Add(8, "Xin nghỉ", "QL Trần Minh", "Xin nghỉ ngày 28/04/2026. Lý do: Khám sức khỏe định kỳ", "27/04 09:00", true, "leave");

            dgvNotifications.DataSource = _dtNotif;
            dgvNotifications.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvNotifications.Columns["ID"].Visible = false;
            dgvNotifications.Columns["Trang liên quan"].Visible = false;
            dgvNotifications.Columns["Đã đọc"].Visible = false;
            dgvNotifications.Columns["Nội dung"].FillWeight = 40;
            dgvNotifications.Columns["Loại"].FillWeight = 12;
            dgvNotifications.Columns["Từ"].FillWeight = 18;
            dgvNotifications.Columns["Thời gian"].FillWeight = 12;

            ColorRows();
            UpdateUnreadCount();
            UpdateDetailButtons();
        }

        private void ColorRows()
        {
            foreach (DataGridViewRow row in dgvNotifications.Rows)
            {
                bool read = row.Cells["Đã đọc"].Value is bool b && b;
                string type = row.Cells["Loại"].Value?.ToString() ?? "";

                if (!read)
                {
                    row.DefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
                    if (type == "Feedback xấu")
                    {
                        string content = row.Cells["Nội dung"].Value?.ToString() ?? "";
                        row.DefaultCellStyle.ForeColor = content.Contains("CHƯA XỬ LÝ") ? Color.IndianRed : Color.Orange;
                    }
                    else if (type == "Xin nghỉ")
                        row.DefaultCellStyle.ForeColor = Color.SteelBlue;
                    else
                        row.DefaultCellStyle.ForeColor = Color.White;
                }
                else
                {
                    row.DefaultCellStyle.Font = new Font("Segoe UI", 9F);
                    row.DefaultCellStyle.ForeColor = Color.Gray;
                }
            }
        }

        private void UpdateUnreadCount()
        {
            int unread = 0;
            foreach (DataRow row in _dtNotif.Rows)
                if (!(bool)row["Đã đọc"]) unread++;

            lblUnreadCount.Text = unread > 0 ? $"{unread} chưa đọc" : "Đã đọc hết";
            lblUnreadCount.ForeColor = unread > 0 ? Color.IndianRed : Color.MediumSeaGreen;
        }

        private void UpdateDetailButtons()
        {
            if (dgvNotifications.CurrentRow == null)
            {
                btnAccept.Visible = false;
                btnReject.Visible = false;
                btnGoToChat.Visible = false;
                return;
            }

            string type = dgvNotifications.CurrentRow.Cells["Loại"].Value?.ToString() ?? "";
            string content = txtNotifContent.Text;

            // Xin nghỉ → Duyệt / Từ chối + Chat
            btnAccept.Visible = type == "Xin nghỉ";
            btnReject.Visible = type == "Xin nghỉ";

            // Feedback xấu chưa xử lý → Chat QL (đỏ)
            if (type == "Feedback xấu" && content.Contains("CHƯA XỬ LÝ"))
            {
                btnGoToChat.Visible = true;
                btnGoToChat.BackColor = Color.IndianRed;
                btnGoToChat.Text = "Chat QL ngay!";
            }
            else
            {
                btnGoToChat.Visible = type == "Xin nghỉ" || type.Contains("nguyên liệu") || type.Contains("Xóa") || type.Contains("Sửa") || type.Contains("Thêm") || type == "Chấm công";
                btnGoToChat.BackColor = Color.SteelBlue;
                btnGoToChat.Text = "Chat với quản lý";
            }

            btnGoToPage.Visible = true;
        }

        private void dgvNotifications_SelectionChanged(object? sender, EventArgs e)
        {
            if (dgvNotifications.CurrentRow == null) return;
            var row = dgvNotifications.CurrentRow;

            lblNotifType.Text = "Loại: " + (row.Cells["Loại"].Value?.ToString() ?? "");
            lblNotifFrom.Text = "Từ: " + (row.Cells["Từ"].Value?.ToString() ?? "");
            lblNotifTime.Text = row.Cells["Thời gian"].Value?.ToString() ?? "";
            txtNotifContent.Text = row.Cells["Nội dung"].Value?.ToString() ?? "";

            // Feedback xấu đã xử lý → hiện feedback + hướng giải quyết
            string type = row.Cells["Loại"].Value?.ToString() ?? "";
            string content = row.Cells["Nội dung"].Value?.ToString() ?? "";
            if (type == "Feedback xấu" && !content.Contains("CHƯA XỬ LÝ"))
            {
                lblNotifType.ForeColor = Color.MediumSeaGreen;
                lblNotifType.Text = "Loại: Feedback xấu (ĐÃ XỬ LÝ)";
            }
            else if (type == "Feedback xấu")
            {
                lblNotifType.ForeColor = Color.IndianRed;
            }
            else
            {
                lblNotifType.ForeColor = Color.Orange;
            }

            UpdateDetailButtons();
        }

        private void dgvNotifications_CellDoubleClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            // Mark as read
            var dataRow = _dtNotif.Rows[e.RowIndex];
            dataRow["Đã đọc"] = true;
            ColorRows();
            UpdateUnreadCount();

            // Check type for auto-navigation
            string type = dataRow["Loại"].ToString() ?? "";
            string content = dataRow["Nội dung"].ToString() ?? "";

            if (type == "Feedback xấu" && content.Contains("CHƯA XỬ LÝ"))
            {
                MsgBox.Show("Feedback xấu chưa được quản lý xử lý!\nChuyển sang chat với quản lý...", "Cảnh báo", MsgBox.MessageBoxType.Warning);
            }
            else
            {
                string page = dataRow["Trang liên quan"].ToString() ?? "";
                string pageName = page switch
                {
                    "leave" => "Quản lý nghỉ phép",
                    "stock" => "Kiểm soát kho",
                    "feedback" => "Feedback khách hàng",
                    "attendance" => "Chấm công",
                    _ => "Trang chủ"
                };
                MsgBox.Show($"Đã đọc thông báo.\nĐi tới: {pageName}", "Thông báo", MsgBox.MessageBoxType.Info);
            }
        }

        private void btnAccept_Click(object? sender, EventArgs e)
        {
            if (dgvNotifications.CurrentRow == null) return;
            int idx = dgvNotifications.CurrentRow.Index;
            _dtNotif.Rows[idx]["Đã đọc"] = true;
            _dtNotif.Rows[idx]["Nội dung"] = _dtNotif.Rows[idx]["Nội dung"].ToString()?.Replace("Xin nghỉ", "[ĐÃ DUYỆT] Xin nghỉ") ?? "";
            ColorRows();
            UpdateUnreadCount();
            MsgBox.Show("Đã duyệt đơn xin nghỉ!", "Thành công", MsgBox.MessageBoxType.Success);
        }

        private void btnReject_Click(object? sender, EventArgs e)
        {
            if (dgvNotifications.CurrentRow == null) return;
            int idx = dgvNotifications.CurrentRow.Index;
            _dtNotif.Rows[idx]["Đã đọc"] = true;
            _dtNotif.Rows[idx]["Nội dung"] = _dtNotif.Rows[idx]["Nội dung"].ToString()?.Replace("Xin nghỉ", "[TỪ CHỐI] Xin nghỉ") ?? "";
            ColorRows();
            UpdateUnreadCount();
            MsgBox.Show("Đã từ chối đơn xin nghỉ!", "Thông báo", MsgBox.MessageBoxType.Warning);
        }

        private void btnGoToChat_Click(object? sender, EventArgs e)
        {
            if (dgvNotifications.CurrentRow == null) return;
            string from = dgvNotifications.CurrentRow.Cells["Từ"].Value?.ToString() ?? "";
            MsgBox.Show($"Mở cửa sổ chat với {from}...", "Chat", MsgBox.MessageBoxType.Info);
        }

        private void btnGoToPage_Click(object? sender, EventArgs e)
        {
            if (dgvNotifications.CurrentRow == null) return;
            int idx = dgvNotifications.CurrentRow.Index;
            _dtNotif.Rows[idx]["Đã đọc"] = true;
            ColorRows();
            UpdateUnreadCount();

            string page = _dtNotif.Rows[idx]["Trang liên quan"].ToString() ?? "";
            string pageName = page switch
            {
                "leave" => "Quản lý nghỉ phép",
                "stock" => "Kiểm soát kho",
                "feedback" => "Feedback khách hàng",
                "attendance" => "Chấm công",
                _ => "Trang chủ"
            };
            MsgBox.Show($"Chuyển tới trang: {pageName}", "Điều hướng", MsgBox.MessageBoxType.Info);
        }

        private void btnMarkAllRead_Click(object? sender, EventArgs e)
        {
            foreach (DataRow row in _dtNotif.Rows)
                row["Đã đọc"] = true;
            ColorRows();
            UpdateUnreadCount();
            MsgBox.Show("Đã đọc tất cả thông báo!", "Thành công", MsgBox.MessageBoxType.Success);
        }
    }
}
