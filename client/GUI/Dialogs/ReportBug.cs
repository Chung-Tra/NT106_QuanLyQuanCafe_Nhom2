using BUS;
using DTO;
using System;
using System.Windows.Forms;

namespace GUI
{
    // Dialog báo cáo lỗi / sự cố phần mềm gửi lên Admin (Quản trị viên).
    // Mở từ nút "Báo lỗi" trên MainDashboard; sourcePage = màn hình đang mở.
    public partial class ReportBug : Form
    {
        public ReportBug(string sourcePage = "")
        {
            InitializeComponent();
            WindowChrome.Apply(this, host: panel1);

            cboType.SelectedIndex = 0;
            txtScreen.Text = sourcePage;

            var u = GlobalSession.CurrentUser;
            lblReporter.Text = u != null
                ? $"Người gửi: {u.FullName}  ({u.Role})"
                : "Người gửi: (khách)";

            btnSubmit.Click += BtnSubmit_Click;
            btnCancel.Click += (s, e) => Close();
        }

        private async void BtnSubmit_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSubject.Text) ||
                string.IsNullOrWhiteSpace(rtxDescription.Text))
            {
                MsgBox.Show(MsgBox.OwnerWindow(this),
                    "Vui lòng nhập Tiêu đề và Mô tả chi tiết của lỗi!",
                    "Thiếu thông tin", MsgBox.MessageBoxType.Warning);
                return;
            }

            string severity = chkUrgent.Checked ? "NGHIÊM TRỌNG" : "Bình thường";
            btnSubmit.Enabled = false;

            var dto = new BugReportDTO
            {
                TieuDe = txtSubject.Text.Trim(),
                MoTa = rtxDescription.Text.Trim(),
                Loai = cboType.SelectedItem?.ToString() ?? "",
                MucDo = severity,
                ManHinh = txtScreen.Text.Trim(),
                SenderId = GlobalSession.CurrentUser?.EmployeeId,
                Timestamp = DateTimeOffset.Now.ToUnixTimeMilliseconds(),
                TrangThai = "moi"
            };
            var (ok, msg, id) = await BugReportBUS.Add(dto);
            btnSubmit.Enabled = true;

            if (ok)
            {
                MsgBox.Show(MsgBox.OwnerWindow(this),
                    $"Đã gửi báo cáo lỗi đến Admin (Quản trị viên)!\n\n" +
                    $"Mã phiếu: {id ?? "BUG"}\nLoại: {cboType.SelectedItem}\nMức độ: {severity}",
                    "Gửi báo cáo thành công", MsgBox.MessageBoxType.Success);
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MsgBox.Show(MsgBox.OwnerWindow(this), msg, "Lỗi gửi báo cáo", MsgBox.MessageBoxType.Error);
            }
        }
    }
}
