using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace GUI
{
    public partial class AuditLogDetail : Form
    {
        public AuditLogDetail(DataTable data, string title = "Lịch sử thao tác")
        {
            InitializeComponent();
            WindowChrome.Apply(this);
            lblTitle.Text = title;

            dgvAuditLog.DataSource          = data;
            dgvAuditLog.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            AutoFadeScroll.Attach(dgvAuditLog);
        }

        private void btnClose_Click(object sender, EventArgs e) => Close();
    }
}
