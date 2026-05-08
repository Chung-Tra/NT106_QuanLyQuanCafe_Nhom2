using BUS;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class ucSettings_Manager : UserControl
    {
        private List<EmployeeDTO> _allEmployees = [];

        private readonly ChatManager _chatManager;

        public ucSettings_Manager()
        {
            InitializeComponent();

            // 2. GIAO PHÓ LISTBOX CHO ÔNG MANAGER
            _chatManager = new ChatManager(this, lstChatHistory);

            this.Load += async (s, e) =>
            {
                await LoadEmployeeData();
                await _chatManager.ConnectToChatServer(); // CHỈ 1 DÒNG
            };

            btnSend.Click += BtnSend_Click;
            btnOpenChatWindow.Click += BtnOpenChatWindow_Click;
            btnChangePassword.Click += BtnChangePassword_Click;
            btnUpdateProfile.Click += BtnUpdateProfile_Click;

            // CHỈ 1 DÒNG ĐỂ ĐỔI PHÒNG
            cmbChatTarget.SelectedIndexChanged += async (s, e) => await _chatManager.SwitchChatRoom(GetIdFromCombo());
        }

        private async Task LoadEmployeeData()
        {
            try
            {
                _allEmployees = await EmployeeBUS.GetAllEmployeesAsync();
                if (_allEmployees == null || _allEmployees.Count == 0) return;

                cmbChatTarget.Items.Clear();
                cmbChatTarget.Items.Add("--- Gửi cho tất cả (Chat nhóm) ---");

                foreach (var emp in _allEmployees.Where(x => x.Status == "active"))
                {
                    cmbChatTarget.Items.Add($"[{emp.EmployeeId}] {emp.FullName} ({emp.Role})");
                }

                if (cmbChatTarget.Items.Count > 0) cmbChatTarget.SelectedIndex = 0;

                lstChatHistory.Items.Clear();
                lstChatHistory.Items.Add("[Hệ thống]: Đã kết nối thành công kênh truyền tin nội bộ.");
                lstChatHistory.Items.Add("");
            }
            catch (Exception ex)
            {
                MsgBox.Show(MsgBox.OwnerWindow(this), $"Không thể tải danh sách nhân viên: {ex.Message}", "Lỗi hệ thống", MsgBox.MessageBoxType.Error);
            }
        }

        private async void BtnSend_Click(object? sender, EventArgs e)
        {
            string message = txtMessage.Text.Trim();
            if (string.IsNullOrEmpty(message)) return;

            // 3. ĐẨY MESSAGE CHO MANAGER GỬI ĐI
            await _chatManager.SendMessageAsync(message);

            txtMessage.Clear();
            txtMessage.Focus();
        }

        private void BtnOpenChatWindow_Click(object? sender, EventArgs e)
        {
            MsgBox.Show(MsgBox.OwnerWindow(this), "Tính năng này sẽ mở cửa sổ chat riêng (kiểu Messenger).", "Chat nổi", MsgBox.MessageBoxType.Info);
        }

        private void BtnChangePassword_Click(object? sender, EventArgs e)
        {
            MsgBox.Show(MsgBox.OwnerWindow(this), "Đang mở form đổi mật khẩu...", "Bảo mật", MsgBox.MessageBoxType.Info);
        }

        private void BtnUpdateProfile_Click(object? sender, EventArgs e)
        {
            MsgBox.Show(MsgBox.OwnerWindow(this), "Đang mở form chỉnh sửa hồ sơ...", "Cài đặt tài khoản", MsgBox.MessageBoxType.Info);
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

        private void ucSettings_Manager_Load(object sender, EventArgs e)
        {
        }
    }
}