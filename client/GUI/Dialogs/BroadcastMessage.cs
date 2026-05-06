using System;
using System.Drawing;
using System.Windows.Forms;

namespace GUI
{
    /// <summary>
    /// Dialog gửi thông báo hàng loạt tới toàn bộ nhân viên
    /// hoặc nhắn riêng cho một người.
    /// </summary>
    public class BroadcastMessage : Form
    {
        private RadioButton rdoAll = null!;
        private RadioButton rdoIndividual = null!;
        private ComboBox cboRecipient = null!;
        private Label lblRecipient = null!;
        private ComboBox cboPriority = null!;
        private TextBox txtTitle = null!;
        private RichTextBox rtxContent = null!;
        private CheckBox chkSendChat = null!;
        private Button btnSend = null!;
        private Button btnCancel = null!;
        private Label lblCharCount = null!;

        public BroadcastMessage()
        {
            Text = "Gửi thông báo";
            Size = new Size(540, 480);
            StartPosition = FormStartPosition.CenterParent;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            BackColor = Color.FromArgb(45, 45, 48);
            ForeColor = Color.White;
            Font = new Font("Segoe UI", 9F);

            BuildUI();
        }

        private void BuildUI()
        {
            int pad = 18;

            // --- Người nhận ---
            var grpRecipient = new GroupBox
            {
                Text = "Người nhận",
                ForeColor = Color.Silver,
                Bounds = new Rectangle(pad, 12, ClientSize.Width - pad * 2, 80)
            };

            rdoAll = new RadioButton
            {
                Text = "Toàn bộ nhân viên",
                Location = new Point(12, 22),
                ForeColor = Color.White,
                Checked = true,
                AutoSize = true
            };
            rdoIndividual = new RadioButton
            {
                Text = "Nhắn riêng:",
                Location = new Point(12, 48),
                ForeColor = Color.White,
                AutoSize = true
            };
            lblRecipient = new Label
            {
                Text = "Nhân viên:",
                Location = new Point(170, 50),
                ForeColor = Color.Silver,
                AutoSize = true
            };
            cboRecipient = new ComboBox
            {
                Location = new Point(240, 47),
                Width = 180,
                Enabled = false,
                BackColor = Color.FromArgb(60, 60, 65),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            cboRecipient.Items.AddRange([
                "NV001 - Nguyễn Văn An (Quản lý)",
                "NV002 - Trần Thị Bích (Pha chế)",
                "NV003 - Lê Hoàng Nam (Order Staff)",
                "NV004 - Phạm Minh Tuấn (Bảo vệ)",
                "NV005 - Đỗ Thị Hương (Pha chế)"
            ]);

            rdoIndividual.CheckedChanged += (s, e) =>
            {
                cboRecipient.Enabled = rdoIndividual.Checked;
                lblRecipient.ForeColor = rdoIndividual.Checked ? Color.White : Color.DimGray;
            };

            grpRecipient.Controls.AddRange([rdoAll, rdoIndividual, lblRecipient, cboRecipient]);

            // --- Mức độ ưu tiên ---
            var lblPriority = new Label
            {
                Text = "Mức độ:",
                Location = new Point(pad, 105),
                ForeColor = Color.Silver,
                AutoSize = true
            };
            cboPriority = new ComboBox
            {
                Location = new Point(80, 102),
                Width = 150,
                BackColor = Color.FromArgb(60, 60, 65),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            cboPriority.Items.AddRange(["Thông báo thường", "Quan trọng !", "Khẩn cấp !!!"]);
            cboPriority.SelectedIndex = 0;

            // --- Tiêu đề ---
            var lblTitle = new Label
            {
                Text = "Tiêu đề thông báo:",
                Location = new Point(pad, 138),
                ForeColor = Color.Silver,
                AutoSize = true
            };
            txtTitle = new TextBox
            {
                Location = new Point(pad, 158),
                Width = ClientSize.Width - pad * 2,
                BackColor = Color.FromArgb(60, 60, 65),
                ForeColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle,
                MaxLength = 120,
                PlaceholderText = "Nhập tiêu đề thông báo..."
            };

            // --- Nội dung ---
            var lblContent = new Label
            {
                Text = "Nội dung:",
                Location = new Point(pad, 192),
                ForeColor = Color.Silver,
                AutoSize = true
            };
            rtxContent = new RichTextBox
            {
                Location = new Point(pad, 212),
                Size = new Size(ClientSize.Width - pad * 2, 130),
                BackColor = Color.FromArgb(60, 60, 65),
                ForeColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle
            };
            lblCharCount = new Label
            {
                Text = "0 / 500 ký tự",
                Location = new Point(ClientSize.Width - 110, 346),
                ForeColor = Color.DimGray,
                AutoSize = true
            };
            rtxContent.TextChanged += (s, e) =>
            {
                lblCharCount.Text = $"{rtxContent.TextLength} / 500 ký tự";
                lblCharCount.ForeColor = rtxContent.TextLength > 450 ? Color.IndianRed : Color.DimGray;
            };

            // --- Tuỳ chọn ---
            chkSendChat = new CheckBox
            {
                Text = "Đồng thời gửi vào Chat nội bộ",
                Location = new Point(pad, 356),
                ForeColor = Color.LightGray,
                AutoSize = true
            };

            // --- Buttons ---
            btnSend = new Button
            {
                Text = "Gửi thông báo",
                Location = new Point(ClientSize.Width - 270, 400),
                Size = new Size(130, 34),
                BackColor = Color.SteelBlue,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btnCancel = new Button
            {
                Text = "Hủy",
                Location = new Point(ClientSize.Width - 130, 400),
                Size = new Size(112, 34),
                BackColor = Color.FromArgb(60, 60, 65),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };

            btnSend.Click   += (s, e) => DialogResult = DialogResult.OK;
            btnCancel.Click += (s, e) => DialogResult = DialogResult.Cancel;

            Controls.AddRange([
                grpRecipient, lblPriority, cboPriority,
                lblTitle, txtTitle, lblContent, rtxContent,
                lblCharCount, chkSendChat, btnSend, btnCancel
            ]);
        }
    }
}
