using System;
using System.Drawing;
using System.Windows.Forms;

namespace GUI
{
    public partial class ucKDS_Barista : UserControl
    {
        public ucKDS_Barista()
        {
            InitializeComponent();
            this.Load += (s, e) => LoadMockOrders();
            btnReport.Click += (s, e) =>
            {
                string report =
                    $"BÁO CÁO KDS\n" +
                    $"Thời gian: {DateTime.Now:HH:mm dd/MM/yyyy}\n" +
                    $"──────────────────\n" +
                    $"• {lblPending.Text}\n" +
                    $"• {lblInProgress.Text}\n" +
                    $"• {lblDone.Text}\n" +
                    $"──────────────────\n" +
                    $"Gửi báo cáo cho quản lý?";

                if (MessageBox.Show(report, "Báo cáo KDS", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    MsgBox.Show("Đã gửi báo cáo KDS cho quản lý!", "Thành công", MsgBox.MessageBoxType.Success);
            };
        }

        private void LoadMockOrders()
        {
            AddOrderCard(flpPendingOrders, "#1008", "Bàn 5", new[] { "1x Cà phê sữa đá", "1x Trà đào cam sả" }, "08:45", Color.Orange);
            AddOrderCard(flpPendingOrders, "#1009", "Mang đi", new[] { "2x Americano", "1x Latte" }, "08:50", Color.IndianRed);
            AddOrderCard(flpPendingOrders, "#1010", "Bàn 2", new[] { "1x Cappuccino" }, "08:55", Color.Orange);

            AddOrderCard(flpInProgressOrders, "#1006", "Bàn 3", new[] { "1x Mocha", "2x Trà sữa trân châu" }, "08:30", Color.SteelBlue);
            AddOrderCard(flpInProgressOrders, "#1007", "Bàn 7", new[] { "1x Espresso", "1x Cà phê đen" }, "08:40", Color.SteelBlue);

            AddOrderCard(flpDoneOrders, "#1004", "Bàn 1", new[] { "1x Latte", "1x Bánh mì" }, "08:10", Color.MediumSeaGreen);
            AddOrderCard(flpDoneOrders, "#1005", "Bàn 4", new[] { "2x Sinh tố bơ" }, "08:20", Color.MediumSeaGreen);

            lblPending.Text = "Chờ: 3";
            lblInProgress.Text = "Đang pha: 2";
            lblDone.Text = "Hoàn thành: 2";
        }

        private void AddOrderCard(FlowLayoutPanel panel, string orderId, string table, string[] items, string time, Color accentColor)
        {
            Panel card = new()
            {
                Size = new Size(220, 120),
                BackColor = Color.FromArgb(50, 50, 55),
                Margin = new Padding(5),
                Cursor = Cursors.Hand
            };

            Label lblOrder = new()
            {
                Text = $"{orderId} - {table}",
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                ForeColor = accentColor,
                Location = new Point(8, 5),
                AutoSize = true
            };

            Label lblTime = new()
            {
                Text = time,
                Font = new Font("Segoe UI", 8F),
                ForeColor = Color.Gray,
                Location = new Point(170, 8),
                AutoSize = true
            };

            Label lblItems = new()
            {
                Text = string.Join("\n", items),
                Font = new Font("Segoe UI", 9F),
                ForeColor = Color.White,
                Location = new Point(8, 30),
                Size = new Size(210, 60),
                AutoSize = false
            };

            Button btnAction = new()
            {
                Text = panel == flpPendingOrders ? "Bắt đầu pha" : panel == flpInProgressOrders ? "Hoàn thành" : "✓",
                Font = new Font("Segoe UI", 8F, FontStyle.Bold),
                ForeColor = Color.White,
                BackColor = accentColor,
                FlatStyle = FlatStyle.Flat,
                Size = new Size(panel == flpDoneOrders ? 30 : 90, 22),
                Location = new Point(8, 92),
                Cursor = Cursors.Hand
            };
            btnAction.FlatAppearance.BorderSize = 0;
            btnAction.Click += (s, e) =>
            {
                MsgBox.Show($"Đã cập nhật trạng thái đơn {orderId}!", "Thành công", MsgBox.MessageBoxType.Success);
            };

            card.Controls.AddRange(new Control[] { lblOrder, lblTime, lblItems, btnAction });
            panel.Controls.Add(card);
        }
    }
}
