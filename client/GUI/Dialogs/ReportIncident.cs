using System;
using System.Windows.Forms;

namespace GUI
{
    /// <summary>
    /// Dialog báo cáo sự cố / sai sót từ bất kỳ trang nào.
    /// Sau khi gửi, có nút chuyển thẳng sang chat với Manager để duyệt nhanh.
    /// </summary>
    public partial class ReportIncident : Form
    {
        private readonly string _sourcePage;

        public ReportIncident(string sourcePage = "")
        {
            _sourcePage = sourcePage;
            InitializeComponent();

            if (string.IsNullOrEmpty(sourcePage))
                lblPage.Visible = false;
            else
                lblPage.Text = $"Trang: {sourcePage}";

            cboType.SelectedIndex = 0;

            btnSubmit.Click        += (s, e) => DialogResult = DialogResult.OK;
            btnSubmitAndChat.Click += (s, e) => DialogResult = DialogResult.Yes;
            btnCancel.Click        += (s, e) => DialogResult = DialogResult.Cancel;
        }
    }
}
