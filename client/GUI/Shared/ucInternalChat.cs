using BUS;
using DTO;
using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class ucInternalChat : UserControl
    {

        // 1. Gọi ông quản lý chat lên
        private readonly ChatManager _chatManager;

        // Danh bạ (đúng thứ tự item trong combo, lệch 1 vì item[0] là "Gửi cho tất cả")
        private readonly List<EmployeeDTO> _contacts = new();
        // Những người đang có tin nhắn riêng CHƯA đọc (để hiện dấu ● trong combo)
        private readonly HashSet<string> _unreadFrom = new();

        public ucInternalChat()
        {
            InitializeComponent();

            // 2. Giao phó listbox cho ông manager
            _chatManager = new ChatManager(this, lstChatHistory);
            _chatManager.BackgroundPrivateMessage += OnBackgroundPrivateMessage;

            this.Load += async (s, e) =>
            {
                // try/catch bắt buộc: handler async void — exception lọt ra ngoài sẽ
                // bật hộp thoại crash của WinForms và có thể sập app.
                try
                {
                    // Tạm tắt sự kiện để LoadStaffData không kích hoạt SwitchChatRoom sớm
                    cmbChatTarget.SelectedIndexChanged -= OnChatTargetChanged;
                    await LoadStaffData();
                    // Kết nối SignalR ở luồng nền — mọi cập nhật UI trong ChatManager đều qua Invoke
                    await Task.Run(_chatManager.ConnectToChatServer);
                    // Vào sẵn mọi phòng riêng để nhận tin nhắn riêng kể cả khi đang mở thread khác
                    await _chatManager.JoinAllPrivateRoomsAsync(_contacts.Select(c => c.EmployeeId ?? ""));
                    cmbChatTarget.SelectedIndexChanged += OnChatTargetChanged;

                    // Sau khi kết nối xong mới JoinRoom và tải lịch sử
                    var emp = GetEmployeeFromCombo();
                    await _chatManager.SwitchChatRoom(emp.EmployeeId ?? "", emp.FullName ?? "Chat nhóm");
                }
                catch (Exception ex)
                {
                    if (!IsDisposed) lstChatHistory.Items.Add($"[Lỗi]: Không khởi tạo được chat - {ex.Message}");
                }
            };

            btnOpenChatWindow.Click += (s, e) =>
            {
                // Mở cửa sổ chat nổi (pop-out) dùng lại chính UserControl này — theo theme app.
                WindowChrome.ShowUc(new ucInternalChat(), "QLCafe Chat", new Size(920, 640), modal: false);
            };

            // Hiện nút Thông báo toàn bộ cho admin/manager
            string role = GlobalSession.CurrentUser?.Role?.ToLower() ?? "";
            if (role == "admin" || role == "manager")
                btnBroadcast.Visible = true;

            txtMessage.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                {
                    e.SuppressKeyPress = true;
                    BtnSend_Click(s, e);
                }
            };
        }

        private async Task LoadStaffData()
        {
            try
            {
                // Task.Run: gọi HTTP + parse JSON ở thread pool, UI chỉ nhận kết quả
                List<EmployeeDTO> allEmployees = await Task.Run(EmployeeBUS.GetAllEmployeesAsync);

                cmbChatTarget.Items.Clear();
                _contacts.Clear();
                cmbChatTarget.Items.Add("--- Gửi cho tất cả (Chat nhóm) ---");

                if (allEmployees != null)
                {
                    foreach (var emp in allEmployees.Where(x => x.Status == "active" && x.EmployeeId != GlobalSession.CurrentUser?.EmployeeId))
                    {
                        _contacts.Add(emp);
                        cmbChatTarget.Items.Add(FormatContact(emp));
                    }
                }

                if (cmbChatTarget.Items.Count > 0) cmbChatTarget.SelectedIndex = 0;

                lstChatHistory.Items.Clear();
                lstChatHistory.Items.Add("[Hệ thống]: Đã kết nối vào QLCafe Chat.");
            }
            catch (Exception ex)
            {
                lstChatHistory.Items.Add($"[Lỗi]: Không thể tải danh sách nhân viên. {ex.Message}");
            }
        }

        // Đổi thành async void để gửi tin
        private async void BtnSend_Click(object? sender, EventArgs e)
        {
            string message = txtMessage.Text.Trim();
            if (string.IsNullOrEmpty(message))
            {
                MsgBox.Show(MsgBox.OwnerWindow(this), "Vui lòng nhập nội dung tin nhắn!", "Thông báo", MsgBox.MessageBoxType.Warning);
                return;
            }
            // 3. Đẩy message cho manager gửi đi
            await _chatManager.SendMessageAsync(message);

            txtMessage.Clear();
            txtMessage.Focus();
        }

        private EmployeeDTO GetEmployeeFromCombo()
        {
            EmployeeDTO em = new();
            if (cmbChatTarget == null || cmbChatTarget.SelectedIndex <= 0)
            {
                em.EmployeeId = "";
                return em;
            }

            // Lấy nội dung item an toàn (bỏ dấu "● " chưa đọc nếu có)
            string? selectedItem = cmbChatTarget.SelectedItem?.ToString()?.TrimStart('●', ' ');
            if (string.IsNullOrEmpty(selectedItem) || !selectedItem.Contains(']'))
            {
                em.EmployeeId = "";
                return em;
            }

            // Bóc tách [ID]
            em.EmployeeId = selectedItem.Split(']')[0].Trim('[') ?? "nv_000";
            em.FullName = selectedItem.Split(']')[1].Trim().Split('(')[0].Trim() ?? "Unknown";
            return em;
        }

        // Định dạng 1 dòng liên hệ trong combo; thêm "● " nếu còn tin chưa đọc từ người đó.
        private string FormatContact(EmployeeDTO emp)
        {
            string mark = _unreadFrom.Contains(emp.EmployeeId ?? "") ? "● " : "";
            return $"{mark}[{emp.EmployeeId}] {emp.FullName} ({emp.Role})";
        }

        // Có tin riêng đến khi đang mở thread khác → đánh dấu "● " cho người gửi trong combo.
        // Chạy trên UI thread (ChatManager đã Invoke) nên thao tác combo an toàn.
        private void OnBackgroundPrivateMessage(string senderId, string senderName)
        {
            if (string.IsNullOrEmpty(senderId)) return;
            if (senderId == _chatManager.CurrentTargetId) return; // đang mở đúng thread thì thôi
            if (_unreadFrom.Add(senderId))
                RefreshContactMarker(senderId);
        }

        // Vẽ lại đúng 1 item trong combo (không đụng SelectedIndex).
        private void RefreshContactMarker(string empId)
        {
            int idx = _contacts.FindIndex(c => c.EmployeeId == empId);
            if (idx < 0) return;
            int itemIndex = idx + 1; // +1 vì item[0] là "--- Gửi cho tất cả ---"
            if (itemIndex < cmbChatTarget.Items.Count)
                cmbChatTarget.Items[itemIndex] = FormatContact(_contacts[idx]);
        }

        private async void BtnBroadcast_Click(object? sender, EventArgs e)
        {
            string msg = txtMessage.Text.Trim();
            if (string.IsNullOrEmpty(msg))
            {
                MsgBox.Show(MsgBox.OwnerWindow(this), "Vui lòng nhập nội dung thông báo!", "Thông báo", MsgBox.MessageBoxType.Warning);
                return;
            }

            var result = MsgBox.Show(
                this,
                $"Gửi thông báo sau cho TOÀN BỘ nhân viên (phòng chat chung)?\n\n\"{msg}\"",
                "Thông báo toàn bộ",
                MsgBox.MessageBoxType.Warning);

            if (result != DialogResult.Yes) return;

            try
            {
                // Chuyển về phòng chung rồi gửi -> mọi nhân viên online đều nhận + lưu Firebase
                cmbChatTarget.SelectedIndexChanged -= OnChatTargetChanged;
                if (cmbChatTarget.Items.Count > 0) cmbChatTarget.SelectedIndex = 0;
                await _chatManager.SwitchChatRoom("", "Chat nhóm");
                cmbChatTarget.SelectedIndexChanged += OnChatTargetChanged;
                UpdateChatHeader();

                await _chatManager.SendMessageAsync("📢 [THÔNG BÁO] " + msg);
                txtMessage.Clear();
                MsgBox.Show(MsgBox.OwnerWindow(this), "Đã gửi thông báo cho toàn bộ nhân viên!", "Thành công", MsgBox.MessageBoxType.Success);
            }
            catch (Exception ex)
            {
                MsgBox.Show(MsgBox.OwnerWindow(this), "Lỗi gửi thông báo: " + ex.Message, "Lỗi", MsgBox.MessageBoxType.Error);
            }
        }

        private async void OnChatTargetChanged(object? sender, EventArgs e)
        {
            var emp = GetEmployeeFromCombo();
            // Mở thread của ai thì xóa dấu "● chưa đọc" của người đó
            if (!string.IsNullOrEmpty(emp.EmployeeId) && _unreadFrom.Remove(emp.EmployeeId))
                RefreshContactMarker(emp.EmployeeId);
            await _chatManager.SwitchChatRoom(emp.EmployeeId ?? "", emp.FullName ?? "Chat nhóm");
            UpdateChatHeader();
        }

        private void UpdateChatHeader()
        {
            if (cmbChatTarget.SelectedIndex <= 0)
            {
                lblCurrentChat.Text = "Chat nhóm — Tất cả";
                lblCurrentChat.ForeColor = Color.White;
            }
            else
            {
                string raw = (cmbChatTarget.SelectedItem?.ToString() ?? "").TrimStart('●', ' ');
                string name = raw.Contains(']') ? raw.Split(']')[1].Trim().Split('(')[0].Trim() : raw;
                lblCurrentChat.Text = name;
                lblCurrentChat.ForeColor = Color.FromArgb(31, 138, 154);
            }
        }

        private void lstChatHistory_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ucInternalChat_Load(object sender, EventArgs e)
        {

        }
    }
}