using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace GUI
{
    // Dialog xem CHI TIẾT read-only dùng chung cho mọi DataGridView.
    // Hiển thị toàn bộ field của 1 bản ghi (kể cả những cột đã đặt Visible=false để bảng gọn)
    // dưới dạng cặp "Nhãn - Giá trị". Logic dựng field nằm ở .cs, phần khung ở Designer.
    public partial class RecordDetail : Form
    {
        public RecordDetail(string title, IEnumerable<KeyValuePair<string, string>> fields)
        {
            InitializeComponent();
            WindowChrome.Apply(this, host: panel1);

            if (!string.IsNullOrWhiteSpace(title))
                lblTitle.Text = title;

            BuildFields(fields);
        }

        // Dựng nhanh từ 1 dòng DataGridView: lấy MỌI cột (kể cả cột ẩn) theo thứ tự khai báo.
        // skipColumns: tên cột muốn bỏ qua (vd cột kỹ thuật như AuthUid) — tùy chọn.
        public static RecordDetail FromRow(DataGridViewRow row, string title, params string[] skipColumns)
        {
            var skip = new HashSet<string>(skipColumns ?? Array.Empty<string>(), StringComparer.OrdinalIgnoreCase);
            var fields = new List<KeyValuePair<string, string>>();

            foreach (DataGridViewColumn col in row.DataGridView.Columns)
            {
                if (skip.Contains(col.Name)) continue;

                string label = !string.IsNullOrEmpty(col.HeaderText) ? col.HeaderText : col.Name;
                var cell = row.Cells[col.Index];
                string value = cell.FormattedValue?.ToString() ?? cell.Value?.ToString() ?? "";
                fields.Add(new KeyValuePair<string, string>(label, value));
            }
            return new RecordDetail(title, fields);
        }

        private void BuildFields(IEnumerable<KeyValuePair<string, string>> fields)
        {
            pnlScroll.SuspendLayout();
            pnlScroll.Controls.Clear();

            int y = 0;
            int width = pnlScroll.Width - 24; // chừa chỗ cho thanh cuộn dọc

            foreach (var f in fields)
            {
                var lbl = new Label
                {
                    AutoSize = false,
                    BackColor = Color.Transparent,
                    Font = new Font("Segoe UI", 9.5F),
                    ForeColor = Color.FromArgb(160, 160, 166),
                    Location = new Point(0, y),
                    Size = new Size(width, 18),
                    Text = f.Key + ":",
                };
                pnlScroll.Controls.Add(lbl);
                y += 20;

                var txt = new Guna2TextBox
                {
                    BorderColor = Color.FromArgb(63, 63, 70),
                    BorderRadius = 10,
                    FillColor = Color.FromArgb(45, 45, 48),
                    Font = new Font("Segoe UI", 10.5F),
                    ForeColor = Color.White,
                    Location = new Point(0, y),
                    Size = new Size(width, 40),
                    ReadOnly = true,
                    Text = string.IsNullOrWhiteSpace(f.Value) ? "—" : f.Value,
                };
                txt.DisabledState.FillColor = Color.FromArgb(45, 45, 48);
                txt.HoverState.BorderColor = Color.FromArgb(63, 63, 70);
                txt.FocusedState.BorderColor = Color.FromArgb(31, 138, 154);
                pnlScroll.Controls.Add(txt);
                y += 50;
            }

            pnlScroll.ResumeLayout();
        }

        private void btnClose_Click(object sender, EventArgs e) => this.Close();
    }
}
