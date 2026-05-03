using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class ucPOS_OrStaff : UserControl
    {
        public ucPOS_OrStaff()
        {
            InitializeComponent();
            btnReport.Click += (s, e) =>
            {
                string report =
                    $"BÁO CÁO BÁN HÀNG\n" +
                    $"Thời gian: {DateTime.Now:HH:mm dd/MM/yyyy}\n" +
                    $"──────────────────\n" +
                    $"• Tổng tiền hiện tại: {lblTotalAmount.Text}\n" +
                    $"──────────────────\n" +
                    $"Gửi báo cáo cho quản lý?";

                if (MessageBox.Show(report, "Báo cáo POS", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    MsgBox.Show("Đã gửi báo cáo cho quản lý!", "Thành công", MsgBox.MessageBoxType.Success);
            };
        }

        private void SetActiveTab(Button activeBtn)
        {
            // 1. Reset màu tất cả các nút về màu trắng (không hoạt động)
            btnTabOrder.ForeColor = Color.White;
            btnTabTables.ForeColor = Color.White;
            btnTabHistory.ForeColor = Color.White;
            // 2. Đổi màu nút đang chọn thành màu xanh (hoạt động)
            activeBtn.ForeColor = Color.MediumSeaGreen;
        }

        private void btnTabTables_Click(object sender, EventArgs e)
        {
            SetActiveTab(btnTabTables);

            // Tạo một FlowLayoutPanel mới để chứa các bàn
            FlowLayoutPanel flpTables = new FlowLayoutPanel();
            flpTables.Dock = DockStyle.Fill;
            flpTables.BackColor = Color.FromArgb(45, 45, 48);
            flpTables.Padding = new Padding(20);

            // Giả lập tạo 15 cái bàn
            for (int i = 1; i <= 15; i++)
            {
                Button btnTable = new Button();
                btnTable.Text = "BÀN " + i;
                btnTable.Size = new Size(100, 100);
                btnTable.BackColor = (i % 3 == 0) ? Color.IndianRed : Color.FromArgb(60, 60, 60); // Đỏ là có khách
                btnTable.ForeColor = Color.White;
                btnTable.FlatStyle = FlatStyle.Flat;
                btnTable.FlatAppearance.BorderSize = 0;

                btnTable.Click += (s, ev) => {
                    MessageBox.Show("Đã chọn " + btnTable.Text);
                    btnTabOrder.PerformClick(); // Bấm vào bàn thì tự quay lại trang Order để gọi món
                };

                flpTables.Controls.Add(btnTable);
            }

            // Hiển thị lên vùng nội dung chính
            pnlMainTabContainer.Controls.Clear();
            pnlMainTabContainer.Controls.Add(flpTables);
        }

        private void btnTabHistory_Click(object sender, EventArgs e)
        {
            SetActiveTab(btnTabHistory);

            // Tạo một DataGridView để hiện lịch sử
            DataGridView dgvHistory = new DataGridView();
            dgvHistory.Dock = DockStyle.Fill;
            dgvHistory.BackgroundColor = Color.FromArgb(45, 45, 48);
            dgvHistory.BorderStyle = BorderStyle.None;
            dgvHistory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvHistory.ForeColor = Color.Black; // Chỉnh lại màu chữ data cho dễ nhìn

            // Giả lập dữ liệu
            DataTable dt = new DataTable();
            dt.Columns.Add("Mã HĐ");
            dt.Columns.Add("Thời gian");
            dt.Columns.Add("Tổng tiền");
            dt.Rows.Add("HD001", "10:30", "150,000 đ");
            dt.Rows.Add("HD002", "11:15", "45,000 đ");

            dgvHistory.DataSource = dt;

            pnlMainTabContainer.Controls.Clear();
            pnlMainTabContainer.Controls.Add(dgvHistory);
        }

    }
}
