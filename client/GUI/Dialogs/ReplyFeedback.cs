using System;
using System.Drawing;
using System.Windows.Forms;

namespace GUI
{
    public partial class ReplyFeedback : Form
    {
        public string ReplyText => txtReply.Text;

        public ReplyFeedback(string customerName, string originalContent)
        {
            InitializeComponent();
            lblCustomer.Text = $"Khách hàng: {customerName}";
            txtOriginalContent.Text = originalContent;
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtReply.Text))
            {
                MsgBox.Show("Vui lòng nhập nội dung trả lời!", "Thông báo", MsgBox.MessageBoxType.Warning);
                return;
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
