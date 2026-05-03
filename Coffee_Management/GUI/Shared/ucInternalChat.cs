using BUS;
using DTO;
using Microsoft.AspNetCore.SignalR.Client; // Thêm thư viện SignalR Client
using System;
using System.Collections.Generic;
using System.Data;
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
                await LoadStaffData();
                await _chatManager.ConnectToChatServer(); // CHỈ 1 DÒNG
            };

            btnSend.Click += BtnSend_Click;
            btnOpenChatWindow.Click += (s, e) => MsgBox.Show("Đang mở cửa sổ Messenger...", "Thông báo", MsgBox.MessageBoxType.Info);
            btnBroadcast.Click += BtnBroadcast_Click;

            // Hiện nút Thông báo toàn bộ cho admin/manager
            string role = GlobalSession.CurrentUser?.Role?.ToLower() ?? "";
            if (role == "admin" || role == "manager")
                btnBroadcast.Visible = true;
            txtMessage.KeyDown += (s, e) => { if (e.KeyCode == Keys.Enter) { e.SuppressKeyPress = true; BtnSend_Click(s, e); } };
            // CHỈ 1 DÒNG ĐỂ ĐỔI PHÒNG
            cmbChatTarget.SelectedIndexChanged += async (s, e) => await _chatManager.SwitchChatRoom(GetIdFromCombo());
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
                    foreach (var emp in allEmployees.Where(x => x.Status == "active"))
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
            if (string.IsNullOrEmpty(message)) return;

            // 3. ĐẨY MESSAGE CHO MANAGER GỬI ĐI
            await _chatManager.SendMessageAsync(message);

            txtMessage.Clear();
            txtMessage.Focus();
        }

        private string GetIdFromCombo()
        {
            if (cmbChatTarget == null || cmbChatTarget.SelectedIndex <= 0)
                return "";

            // Lấy nội dung item an toàn
            string? selectedItem = cmbChatTarget.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(selectedItem) || !selectedItem.Contains(']'))
                return "";

            // Bóc tách [ID]
            return selectedItem.Split(']')[0].Trim('[');
        }

        private void BtnBroadcast_Click(object? sender, EventArgs e)
        {
            string msg = txtMessage.Text.Trim();
            if (string.IsNullOrEmpty(msg))
            {
                MsgBox.Show("Vui lòng nhập nội dung thông báo!", "Thông báo", MsgBox.MessageBoxType.Warning);
                return;
            }

            var result = MessageBox.Show(
                $"Gửi thông báo sau cho TOÀN BỘ nhân viên?\n\n\"{msg}\"",
                "Thông báo toàn bộ",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                string sender_name = GlobalSession.CurrentUser?.FullName ?? "Admin";
                string timestamp = DateTime.Now.ToString("HH:mm");
                lstChatHistory.Items.Add($"[{timestamp}] [THÔNG BÁO] {sender_name}: {msg}");
                lstChatHistory.TopIndex = lstChatHistory.Items.Count - 1;
                txtMessage.Clear();
                MsgBox.Show("Đã gửi thông báo cho toàn bộ nhân viên!", "Thành công", MsgBox.MessageBoxType.Success);
            }
        }

        private void lblChatTitle_Click(object sender, EventArgs e)
        {

        }
    }
}