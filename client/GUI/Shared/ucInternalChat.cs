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

        public ucInternalChat()
        {
            InitializeComponent();

            // 2. Giao phó listbox cho ông manager
            _chatManager = new ChatManager(this, lstChatHistory);

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
                cmbChatTarget.Items.Add("--- Gửi cho tất cả (Chat nhóm) ---");

                if (allEmployees != null)
                {
                    foreach (var emp in allEmployees.Where(x => x.Status == "active" && x.EmployeeId != GlobalSession.CurrentUser?.EmployeeId))
                    {
                        cmbChatTarget.Items.Add($"[{emp.EmployeeId}] {emp.FullName} ({emp.Role})");
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

            // Lấy nội dung item an toàn
            string? selectedItem = cmbChatTarget.SelectedItem?.ToString();
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
                string raw = cmbChatTarget.SelectedItem?.ToString() ?? "";
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