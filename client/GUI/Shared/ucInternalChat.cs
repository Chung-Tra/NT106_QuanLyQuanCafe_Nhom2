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

        // 1. GỌI ÔNG QUẢN LÝ CHAT LÊN
        private readonly ChatManager _chatManager;

        public ucInternalChat()
        {
            InitializeComponent();

            // 2. GIAO PHÓ LISTBOX CHO ÔNG MANAGER
            _chatManager = new ChatManager(this, lstChatHistory);

            this.Load += async (s, e) =>
            {
                // Tạm tắt sự kiện để LoadStaffData không kích hoạt SwitchChatRoom sớm
                cmbChatTarget.SelectedIndexChanged -= OnChatTargetChanged;
                await LoadStaffData();
                await _chatManager.ConnectToChatServer();
                cmbChatTarget.SelectedIndexChanged += OnChatTargetChanged;

                // Sau khi kết nối xong mới JoinRoom và tải lịch sử
                var emp = GetEmployeeFromCombo();
                await _chatManager.SwitchChatRoom(emp.EmployeeId ?? "", emp.FullName ?? "Chat nhóm");
            };

            btnSend.Click += BtnSend_Click;
            btnOpenChatWindow.Click += (s, e) => MsgBox.Show(MsgBox.OwnerWindow(this), "Đang mở cửa sổ Messenger...", "Thông báo", MsgBox.MessageBoxType.Info);
            btnBroadcast.Click += BtnBroadcast_Click;

            // Hiện nút Thông báo toàn bộ cho admin/manager
            string role = GlobalSession.CurrentUser?.Role?.ToLower() ?? "";
            if (role == "admin" || role == "manager")
                btnBroadcast.Visible = true;

            txtMessage.KeyDown += (s, e) => { if (e.KeyCode == Keys.Enter) { e.SuppressKeyPress = true; BtnSend_Click(s, e); } };
            cmbChatTarget.SelectedIndexChanged += OnChatTargetChanged;
        }

        private async Task LoadStaffData()
        {
            try
            {
                List<EmployeeDTO> allEmployees = await EmployeeBUS.GetAllEmployeesAsync();

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
            // 3. ĐẨY MESSAGE CHO MANAGER GỬI ĐI
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

        private void BtnBroadcast_Click(object? sender, EventArgs e)
        {
            string msg = txtMessage.Text.Trim();
            if (string.IsNullOrEmpty(msg))
            {
                MsgBox.Show(MsgBox.OwnerWindow(this), "Vui lòng nhập nội dung thông báo!", "Thông báo", MsgBox.MessageBoxType.Warning);
                return;
            }

            var result = MsgBox.Show(
                this,
                $"Gửi thông báo sau cho TOÀN BỘ nhân viên?\n\n\"{msg}\"",
                "Thông báo toàn bộ",
                MsgBox.MessageBoxType.Warning);

            if (result == DialogResult.Yes)
            {
                string sender_name = GlobalSession.CurrentUser?.FullName ?? "Admin";
                string timestamp = DateTime.Now.ToString("HH:mm");
                lstChatHistory.Items.Add($"[{timestamp}] [THÔNG BÁO] {sender_name}: {msg}");
                lstChatHistory.TopIndex = lstChatHistory.Items.Count - 1;
                txtMessage.Clear();
                MsgBox.Show(MsgBox.OwnerWindow(this), "Đã gửi thông báo cho toàn bộ nhân viên!", "Thành công", MsgBox.MessageBoxType.Success);
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
                lblCurrentChat.Text = "🌐  Chat nhóm — Tất cả";
                lblCurrentChat.ForeColor = Color.White;
            }
            else
            {
                string raw = cmbChatTarget.SelectedItem?.ToString() ?? "";
                string name = raw.Contains(']') ? raw.Split(']')[1].Trim().Split('(')[0].Trim() : raw;
                lblCurrentChat.Text = "💬  " + name;
                lblCurrentChat.ForeColor = Color.FromArgb(31, 138, 154);
            }
        }

        private void btnBroadcast_Click_1(object sender, EventArgs e)
        {

        }

        private void lstChatHistory_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbChatTarget_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ucInternalChat_Load(object sender, EventArgs e)
        {

        }
    }
}