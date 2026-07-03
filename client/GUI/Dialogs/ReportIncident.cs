using BUS;
using DTO;
using System;
using System.Windows.Forms;

namespace GUI
{
    // Dialog báo cáo sự cố / sai sót; sau khi gửi có nút chuyển sang chat với Manager.
    public partial class ReportIncident : Form
    {
        private readonly string _sourcePage;

        public ReportIncident(string sourcePage = "")
        {
            _sourcePage = sourcePage;
            InitializeComponent();
            WindowChrome.Apply(this, host: panel1);

            if (string.IsNullOrEmpty(sourcePage))
                lblPage.Visible = false;
            else
                lblPage.Text = $"Trang: {sourcePage}";

            cboType.SelectedIndex = 0;

            btnSubmit.Click        += async (s, e) => { if (await Save()) DialogResult = DialogResult.OK; };
            btnSubmitAndChat.Click += async (s, e) => { if (await Save()) DialogResult = DialogResult.Yes; };
            btnCancel.Click        += (s, e) => DialogResult = DialogResult.Cancel;
        }

        private async System.Threading.Tasks.Task<bool> Save()
        {
            if (string.IsNullOrWhiteSpace(txtSubject.Text) || string.IsNullOrWhiteSpace(rtxDescription.Text))
            {
                MsgBox.Show(this, "Vui lòng nhập tiêu đề và mô tả sự cố!", "Thiếu thông tin", MsgBox.MessageBoxType.Warning);
                return false;
            }
            var dto = new BugReportDTO
            {
                TieuDe = txtSubject.Text.Trim(),
                MoTa = rtxDescription.Text.Trim() + (string.IsNullOrWhiteSpace(txtLocation.Text) ? "" : $"\nVị trí: {txtLocation.Text.Trim()}"),
                Loai = cboType.SelectedItem?.ToString() ?? "Sự cố",
                MucDo = "Sự cố",
                ManHinh = _sourcePage,
                SenderId = GlobalSession.CurrentUser?.EmployeeId,
                Timestamp = DateTimeOffset.Now.ToUnixTimeMilliseconds(),
                TrangThai = "moi"
            };
            var (ok, msg, _) = await BugReportBUS.Add(dto);
            if (!ok) MsgBox.Show(this, msg, "Lỗi", MsgBox.MessageBoxType.Error);
            return ok;
        }
    }
}
