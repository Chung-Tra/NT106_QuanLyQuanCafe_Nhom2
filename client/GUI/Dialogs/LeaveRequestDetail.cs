using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace GUI
{
    public record LeaveItem(string Name, string From, string To, string Reason, string Status);

    public partial class LeaveRequestDetail : Form
    {
        public LeaveRequestDetail(IEnumerable<LeaveItem> items, string title = "🏖  Danh sách đơn xin nghỉ")
        {
            InitializeComponent();
            lblTitle.Text = title;
            foreach (var item in items)
                flpLeaves.Controls.Add(BuildCard(item));
        }

        private Panel BuildCard(LeaveItem item)
        {
            bool pending = item.Status == "Chờ duyệt";

            var card = new Panel
            {
                BackColor = Color.FromArgb(38, 38, 42),
                Width     = flpLeaves.ClientSize.Width - 10,
                Height    = 90,
                Margin    = new Padding(0, 0, 0, 8),
            };

            var lblName   = new Label { Text = "👤  " + item.Name,                     Font = new Font("Segoe UI", 10F, FontStyle.Bold), ForeColor = Color.White,                     AutoSize = true, Location = new Point(14, 10) };
            var lblDate   = new Label { Text = $"📅  {item.From} → {item.To}",          Font = new Font("Segoe UI", 8.5F),               ForeColor = Color.FromArgb(160, 160, 166),   AutoSize = true, Location = new Point(14, 34) };
            var lblReason = new Label { Text = "💬  " + item.Reason,                    Font = new Font("Segoe UI", 8.5F),               ForeColor = Color.FromArgb(200, 200, 205),   AutoSize = true, Location = new Point(14, 54) };
            var lblStatus = new Label { Text = item.Status,                             Font = new Font("Segoe UI", 8.5F, FontStyle.Bold), ForeColor = pending ? Color.FromArgb(245, 158, 11) : Color.MediumSeaGreen, AutoSize = true, Location = new Point(card.Width - 100, 10) };

            card.Controls.AddRange(new Control[] { lblName, lblDate, lblReason, lblStatus });

            if (pending)
            {
                var btn = new Guna.UI2.WinForms.Guna2Button
                {
                    Text = "✔ Duyệt", Size = new Size(80, 28),
                    Location = new Point(card.Width - 100, 52),
                    FillColor = Color.FromArgb(34, 197, 94), ForeColor = Color.White,
                    Font = new Font("Segoe UI", 8.5F, FontStyle.Bold),
                    BorderRadius = 6, Cursor = Cursors.Hand,
                };
                btn.HoverState.FillColor = Color.FromArgb(22, 163, 74);
                btn.Click += (s, e) =>
                {
                    lblStatus.Text      = "Đã duyệt";
                    lblStatus.ForeColor = Color.MediumSeaGreen;
                    card.Controls.Remove(btn);
                };
                card.Controls.Add(btn);
            }

            return card;
        }

        private void btnClose_Click(object sender, EventArgs e) => Close();
    }
}
