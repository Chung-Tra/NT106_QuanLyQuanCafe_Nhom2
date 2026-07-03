using System;
using System.Windows.Forms;
using DTO;

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

        private void BtnSubmit_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSubject.Text) ||
                string.IsNullOrWhiteSpace(rtxDescription.Text))
            {
                MsgBox.Show(MsgBox.OwnerWindow(this),
                    "Vui lòng nhập Tiêu đề và Mô tả chi tiết của lỗi!",
                    "Thiếu thông tin", MsgBox.MessageBoxType.Warning);
                return;
            }

            string ticket   = $"BUG-{DateTime.Now:yyyyMMdd-HHmmss}";
            string severity = chkUrgent.Checked ? "NGHIÊM TRỌNG" : "Bình thường";

            MsgBox.Show(MsgBox.OwnerWindow(this),
                $"Đã gửi báo cáo lỗi đến Admin (Quản trị viên)!\n\n" +
                $"Mã phiếu: {ticket}\n" +
                $"Loại: {cboType.SelectedItem}\n" +
                $"Mức độ: {severity}",
                "Gửi báo cáo thành công", MsgBox.MessageBoxType.Success);

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
