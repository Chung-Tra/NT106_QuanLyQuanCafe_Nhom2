using BUS;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace GUI
{
    // Dialog gửi thông báo hàng loạt hoặc nhắn riêng cho một nhân viên.
    public partial class SendBroadcast : Form
    {
        public string Title => txtTitle.Text.Trim();
        public string Content => rtxContent.Text.Trim();
        public string Priority => cboPriority.SelectedItem?.ToString() ?? "Thường";
        public string Recipient => rdoIndividual.Checked
            ? (cboRecipient.SelectedItem?.ToString() ?? "")
            : "Toàn bộ NV";

        public SendBroadcast()
        {
            InitializeComponent();
            WindowChrome.Apply(this, host: panel1);
            cboPriority.SelectedIndex = 0;
            Load += async (s, e) => await LoadRecipients();
        }

        // Nạp danh sách nhân viên THẬT (thay vì tên giả cố định trong Designer).
        private async System.Threading.Tasks.Task LoadRecipients()
        {
            try
            {
                var emps = await EmployeeBUS.GetAllEmployeesAsync();
                cboRecipient.Items.Clear();
                foreach (var emp in emps.Where(x => x.EmployeeId != null).OrderBy(x => x.EmployeeId))
                    cboRecipient.Items.Add($"{emp.EmployeeId} - {emp.FullName} ({EmployeeText.RoleVi(emp.Role)})");
            }
            catch { /* offline → combo trống */ }
        }

        private void RdoIndividual_CheckedChanged(object? sender, EventArgs e)
        {
            cboRecipient.Enabled = rdoIndividual.Checked;
            lblRecipient.ForeColor = rdoIndividual.Checked
                ? Color.White
                : Color.FromArgb(110, 110, 120);
        }

        private void RtxContent_TextChanged(object? sender, EventArgs e)
        {
            int len = rtxContent.Text?.Length ?? 0;
            lblCharCount.Text = $"{len} / 500 ký tự";
            lblCharCount.ForeColor = len > 450
                ? Color.FromArgb(220, 80, 80)
                : Color.FromArgb(110, 110, 120);
        }

        private void BtnSend_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTitle.Text) || string.IsNullOrWhiteSpace(rtxContent.Text))
            {
                MsgBox.Show(this, "Vui lòng nhập tiêu đề và nội dung thông báo!", "Thiếu thông tin", MsgBox.MessageBoxType.Warning);
                return;
            }
            DialogResult = DialogResult.OK;
        }

        private void BtnCancel_Click(object? sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
