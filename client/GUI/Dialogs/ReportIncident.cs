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

            btnSubmit.Click        += (s, e) => DialogResult = DialogResult.OK;
            btnSubmitAndChat.Click += (s, e) => DialogResult = DialogResult.Yes;
            btnCancel.Click        += (s, e) => DialogResult = DialogResult.Cancel;
        }
    }
}
