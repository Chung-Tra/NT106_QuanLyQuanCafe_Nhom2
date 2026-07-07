using BUS;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
#pragma warning disable IDE1006
    public partial class ucNotification_Admin : UserControl
#pragma warning restore IDE1006
    {
        private DataTable _dtNotif = new();

        public ucNotification_Admin()
        {
            InitializeComponent();
            DgvRefresh.Attach(dgvNotifications, () => _ = LoadRealNotifications());
        }

        private void UcNotification_Admin_Load(object? sender, EventArgs e) => _ = LoadRealNotifications();

        private static string TypeDisplay(string? t) => t switch
        {
            "xin_nghi" => "Xin nghỉ",
            "feedback_xau" => "Feedback xấu",
            "cham_cong" => "Chấm công",
            "sua_nguyen_lieu" => "Sửa nguyên liệu",
            "don_moi" => "Đơn mới",
            "sos" => "SOS",
            "tin_nhan" => "Tin nhắn",
            _ => t ?? "Khác"
        };

        private async Task LoadRealNotifications()
        {
            _dtNotif = new DataTable();
            _dtNotif.Columns.Add("ID");
            _dtNotif.Columns.Add("Loại");
            _dtNotif.Columns.Add("Từ");
            _dtNotif.Columns.Add("Nội dung");
            _dtNotif.Columns.Add("Thời gian");
            _dtNotif.Columns.Add("Đã đọc", typeof(bool));
            _dtNotif.Columns.Add("Trang liên quan");

            string myId = GlobalSession.CurrentUser?.EmployeeId ?? "";
            try
            {
                var notifs = await NotificationBUS.GetAll();
                var emps = (await EmployeeBUS.GetAllEmployeesAsync())
                    .Where(x => x.EmployeeId != null)
                    .ToDictionary(x => x.EmployeeId!, x => x.FullName ?? x.EmployeeId!);

                foreach (var kv in notifs.Where(n => n.Value.ReceiverId == myId)
                                         .OrderByDescending(n => n.Value.Timestamp))
                {
                    var n = kv.Value;
                    string from = n.SenderId == "system" ? "Hệ thống"
                        : (n.SenderId != null && emps.TryGetValue(n.SenderId, out var name) ? name : (n.SenderId ?? ""));
                    string time = n.Timestamp > 0
                        ? DateTimeOffset.FromUnixTimeMilliseconds(n.Timestamp).LocalDateTime.ToString("dd/MM HH:mm")
                        : "";
                    _dtNotif.Rows.Add(kv.Key, TypeDisplay(n.Type), from, n.Content, time, n.IsRead, n.RelatedPage);
                }
            }
            catch { /* offline */ }

            dgvNotifications.DataSource = _dtNotif;
            dgvNotifications.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            if (dgvNotifications.Columns.Contains("ID")) dgvNotifications.Columns["ID"].Visible = false;
            if (dgvNotifications.Columns.Contains("Trang liên quan")) dgvNotifications.Columns["Trang liên quan"].Visible = false;
            if (dgvNotifications.Columns.Contains("Đã đọc")) dgvNotifications.Columns["Đã đọc"].Visible = false;
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

            btnAccept.Visible = type == "Xin nghỉ";
            btnReject.Visible = type == "Xin nghỉ";

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
        }

        private void DgvNotifications_SelectionChanged(object? sender, EventArgs e)
        {
            if (dgvNotifications.CurrentRow == null) return;
            var row = dgvNotifications.CurrentRow;

            lblNotifType.Text = "Loại: " + (row.Cells["Loại"].Value?.ToString() ?? "");
            lblNotifFrom.Text = "Từ: " + (row.Cells["Từ"].Value?.ToString() ?? "");
            lblNotifTime.Text = row.Cells["Thời gian"].Value?.ToString() ?? "";
            txtNotifContent.Text = row.Cells["Nội dung"].Value?.ToString() ?? "";

            string type = row.Cells["Loại"].Value?.ToString() ?? "";
            string content = row.Cells["Nội dung"].Value?.ToString() ?? "";
            if (type == "Feedback xấu" && !content.Contains("CHƯA XỬ LÝ"))
            {
                lblNotifType.ForeColor = Color.MediumSeaGreen;
                lblNotifType.Text = "Loại: Feedback xấu (ĐÃ XỬ LÝ)";
            }
            else if (type == "Feedback xấu")
                lblNotifType.ForeColor = Color.IndianRed;
            else
                lblNotifType.ForeColor = Color.Orange;

            UpdateDetailButtons();
        }

        private async Task MarkRead(int rowIndex)
        {
            if (rowIndex < 0 || rowIndex >= _dtNotif.Rows.Count) return;
            var dataRow = _dtNotif.Rows[rowIndex];
            if ((bool)dataRow["Đã đọc"]) return;
            string id = dataRow["ID"].ToString() ?? "";
            dataRow["Đã đọc"] = true;
            ColorRows();
            UpdateUnreadCount();
            if (!string.IsNullOrEmpty(id))
                await NotificationBUS.Update(id, new { da_doc = true });
        }

        private async void DgvNotifications_CellDoubleClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            await MarkRead(e.RowIndex);

            var dataRow = _dtNotif.Rows[e.RowIndex];
            string type = dataRow["Loại"].ToString() ?? "";
            string content = dataRow["Nội dung"].ToString() ?? "";

            if (type == "Feedback xấu" && content.Contains("CHƯA XỬ LÝ"))
            {
                MsgBox.Show(MsgBox.OwnerWindow(this),
                    "Feedback xấu chưa được quản lý xử lý!\nHãy mở mục Feedback để phản hồi khách hàng.",
                    "Cảnh báo", MsgBox.MessageBoxType.Warning);
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
                    "order" => "Đơn hàng",
                    "security" => "An ninh",
                    "chat" => "Chat nội bộ",
                    _ => "Trang chủ"
                };
                MsgBox.Show(MsgBox.OwnerWindow(this),
                    $"Đã đọc thông báo.\nLiên quan: {pageName}",
                    "Thông báo", MsgBox.MessageBoxType.Info);
            }
        }

        private async void BtnAccept_Click(object? sender, EventArgs e)
        {
            if (dgvNotifications.CurrentRow == null) return;
            await MarkRead(dgvNotifications.CurrentRow.Index);
            MsgBox.Show(MsgBox.OwnerWindow(this), "Đã ghi nhận. Vui lòng vào mục Nhân sự để duyệt đơn nghỉ chính thức.", "Thông báo", MsgBox.MessageBoxType.Info);
        }

        private async void BtnReject_Click(object? sender, EventArgs e)
        {
            if (dgvNotifications.CurrentRow == null) return;
            await MarkRead(dgvNotifications.CurrentRow.Index);
            MsgBox.Show(MsgBox.OwnerWindow(this), "Đã ghi nhận. Vui lòng vào mục Nhân sự để xử lý đơn nghỉ.", "Thông báo", MsgBox.MessageBoxType.Warning);
        }

        private async void BtnGoToChat_Click(object? sender, EventArgs e)
        {
            if (dgvNotifications.CurrentRow == null) return;
            await MarkRead(dgvNotifications.CurrentRow.Index);
            string from = dgvNotifications.CurrentRow.Cells["Từ"].Value?.ToString() ?? "";
            MsgBox.Show(MsgBox.OwnerWindow(this), $"Hãy mở mục Chat nội bộ để trao đổi với {from}.", "Chat", MsgBox.MessageBoxType.Info);
        }

        private async void BtnMarkAllRead_Click(object? sender, EventArgs e)
        {
            var ids = new List<string>();
            foreach (DataRow row in _dtNotif.Rows)
                if (!(bool)row["Đã đọc"]) { ids.Add(row["ID"].ToString() ?? ""); row["Đã đọc"] = true; }

            ColorRows();
            UpdateUnreadCount();
            foreach (var id in ids.Where(x => !string.IsNullOrEmpty(x)))
                await NotificationBUS.Update(id, new { da_doc = true });

            MsgBox.Show(MsgBox.OwnerWindow(this), "Đã đọc tất cả thông báo!", "Thành công", MsgBox.MessageBoxType.Success);
        }
    }
}
