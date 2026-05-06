using System;
using System.Drawing;
using System.Windows.Forms;

namespace GUI
{
    /// <summary>
    /// Dialog báo cáo sự cố / sai sót từ bất kỳ trang nào.
    /// Sau khi gửi, có nút chuyển thẳng sang chat với Manager để duyệt nhanh.
    /// </summary>
    public class ReportDialog : Form
    {
        private readonly string _sourcePage;

        private ComboBox cboType = null!;
        private TextBox txtSubject = null!;
        private RichTextBox rtxDescription = null!;
        private TextBox txtLocation = null!;
        private CheckBox chkUrgent = null!;
        private Button btnSubmit = null!;
        private Button btnSubmitAndChat = null!;
        private Button btnCancel = null!;
        private Label lblStatus = null!;

        public ReportDialog(string sourcePage = "")
        {
            _sourcePage = sourcePage;
            Text = "Báo cáo sự cố / sai sót";
            Size = new Size(500, 450);
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

            // Header
            var lblHeader = new Label
            {
                Text = "Báo cáo vấn đề",
                Location = new Point(pad, 12),
                Font = new Font("Segoe UI", 13F, FontStyle.Bold),
                ForeColor = Color.White,
                AutoSize = true
            };
            var lblPage = new Label
            {
                Text = string.IsNullOrEmpty(_sourcePage) ? "" : $"Trang: {_sourcePage}",
                Location = new Point(pad, 38),
                ForeColor = Color.DimGray,
                AutoSize = true
            };

            // Loại báo cáo
            var lblType = new Label { Text = "Loại sự cố:", Location = new Point(pad, 68), ForeColor = Color.Silver, AutoSize = true };
            cboType = new ComboBox
            {
                Location = new Point(pad, 88),
                Width = 280,
                BackColor = Color.FromArgb(60, 60, 65),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            cboType.Items.AddRange([
                "Sai sót dữ liệu (chấm công, nguyên liệu, ...)",
                "Thiết bị hỏng / bể vỡ",
                "Hành vi không phù hợp của nhân viên",
                "Sự cố hệ thống phần mềm",
                "Mất mát / thất thoát tài sản",
                "Phàn nàn từ khách hàng",
                "Khác"
            ]);
            cboType.SelectedIndex = 0;

            // Tiêu đề
            var lblSubject = new Label { Text = "Tiêu đề:", Location = new Point(pad, 125), ForeColor = Color.Silver, AutoSize = true };
            txtSubject = new TextBox
            {
                Location = new Point(pad, 145),
                Width = ClientSize.Width - pad * 2,
                BackColor = Color.FromArgb(60, 60, 65),
                ForeColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle,
                PlaceholderText = "Mô tả ngắn gọn vấn đề..."
            };

            // Vị trí / nơi xảy ra
            var lblLocation = new Label { Text = "Nơi xảy ra:", Location = new Point(pad, 178), ForeColor = Color.Silver, AutoSize = true };
            txtLocation = new TextBox
            {
                Location = new Point(pad, 198),
                Width = ClientSize.Width - pad * 2,
                BackColor = Color.FromArgb(60, 60, 65),
                ForeColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle,
                PlaceholderText = "Ví dụ: Quầy bar, bàn số 5, kho A..."
            };

            // Mô tả chi tiết
            var lblDesc = new Label { Text = "Mô tả chi tiết:", Location = new Point(pad, 232), ForeColor = Color.Silver, AutoSize = true };
            rtxDescription = new RichTextBox
            {
                Location = new Point(pad, 252),
                Size = new Size(ClientSize.Width - pad * 2, 90),
                BackColor = Color.FromArgb(60, 60, 65),
                ForeColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle
            };

            // Khẩn cấp
            chkUrgent = new CheckBox
            {
                Text = "Đây là sự cố KHẨN CẤP — cần xử lý ngay",
                Location = new Point(pad, 352),
                ForeColor = Color.IndianRed,
                AutoSize = true
            };

            // Buttons
            btnSubmit = new Button
            {
                Text = "Gửi báo cáo",
                Location = new Point(pad, 385),
                Size = new Size(120, 32),
                BackColor = Color.SteelBlue,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btnSubmitAndChat = new Button
            {
                Text = "Gửi + Chat Manager",
                Location = new Point(pad + 128, 385),
                Size = new Size(148, 32),
                BackColor = Color.FromArgb(80, 130, 80),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btnCancel = new Button
            {
                Text = "Hủy",
                Location = new Point(ClientSize.Width - pad - 80, 385),
                Size = new Size(80, 32),
                BackColor = Color.FromArgb(60, 60, 65),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };

            lblStatus = new Label
            {
                Location = new Point(pad, 422),
                Width = 400,
                ForeColor = Color.MediumSeaGreen,
                AutoSize = true
            };

            btnSubmit.Click        += (s, e) => DialogResult = DialogResult.OK;
            btnSubmitAndChat.Click += (s, e) => DialogResult = DialogResult.Yes;
            btnCancel.Click        += (s, e) => DialogResult = DialogResult.Cancel;

            Controls.AddRange([
                lblHeader, lblPage, lblType, cboType,
                lblSubject, txtSubject, lblLocation, txtLocation,
                lblDesc, rtxDescription, chkUrgent,
                btnSubmit, btnSubmitAndChat, btnCancel, lblStatus
            ]);
        }
    }
}
