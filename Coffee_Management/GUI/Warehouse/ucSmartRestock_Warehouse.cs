using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace GUI
{
    public partial class ucSmartRestock_Warehouse : UserControl
    {
        public ucSmartRestock_Warehouse()
        {
            InitializeComponent();
            this.Load += (s, e) => LoadMockData();
            btnReport.Click += btnReport_Click;
        }

        private void LoadMockData()
        {
            DataTable dt = new();
            dt.Columns.Add("Chọn", typeof(bool));
            dt.Columns.Add("Nguyên liệu");
            dt.Columns.Add("Tồn kho");
            dt.Columns.Add("Mức tối thiểu");
            dt.Columns.Add("Đề xuất nhập");
            dt.Columns.Add("Đơn giá", typeof(decimal));
            dt.Columns.Add("Thành tiền", typeof(decimal));
            dt.Columns.Add("Nhà cung cấp");

            dt.Rows.Add(true, "Sữa tươi", "8 lít", "15 lít", "20 lít", 35000m, 700000m, "Vinamilk");
            dt.Rows.Add(true, "Bột cacao", "2.5 kg", "5 kg", "10 kg", 120000m, 1200000m, "CacaoShare");
            dt.Rows.Add(true, "Sả tươi", "3 bó", "5 bó", "10 bó", 15000m, 150000m, "Chợ Bến Thành");
            dt.Rows.Add(true, "Trân châu", "1.2 kg", "3 kg", "5 kg", 80000m, 400000m, "TrungNguyên");
            dt.Rows.Add(true, "Đá viên", "4 bao", "10 bao", "15 bao", 25000m, 375000m, "Đá Sài Gòn");
            dt.Rows.Add(false, "Cà phê hạt", "25 kg", "10 kg", "20 kg", 250000m, 5000000m, "Highlands");
            dt.Rows.Add(false, "Syrup caramel", "5 chai", "3 chai", "10 chai", 85000m, 850000m, "Monin");

            dgvSuggestions.DataSource = dt;
            dgvSuggestions.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSuggestions.RowHeadersVisible = false;
            dgvSuggestions.Columns["Chọn"].ReadOnly = false;
            dgvSuggestions.ReadOnly = false;
            dgvSuggestions.Columns["Chọn"].FillWeight = 6;
            dgvSuggestions.Columns["Nguyên liệu"].FillWeight = 18;
            dgvSuggestions.Columns["Nhà cung cấp"].FillWeight = 15;

            foreach (string col in new[] { "Đơn giá", "Thành tiền" })
            {
                dgvSuggestions.Columns[col].DefaultCellStyle.Format = "N0";
                dgvSuggestions.Columns[col].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }

            // For non-checkbox columns, make them read-only individually
            foreach (DataGridViewColumn col in dgvSuggestions.Columns)
            {
                if (col.Name != "Chọn") col.ReadOnly = true;
            }

            UpdateSummary(dt);
        }

        private void UpdateSummary(DataTable dt)
        {
            int count = 0;
            decimal total = 0;
            foreach (DataRow row in dt.Rows)
            {
                if ((bool)row["Chọn"])
                {
                    count++;
                    total += (decimal)row["Thành tiền"];
                }
            }
            lblSuggestionsCount.Text = $"{count} mục";
            lblEstimatedCost.Text = total.ToString("N0") + " đ";
        }

        private void btnApproveAll_Click(object sender, EventArgs e)
        {
            if (dgvSuggestions.DataSource is DataTable dt)
            {
                foreach (DataRow row in dt.Rows)
                    row["Chọn"] = true;
                UpdateSummary(dt);
            }
            MsgBox.Show("Đã duyệt tất cả đề xuất nhập kho!", "Thành công", MsgBox.MessageBoxType.Success);
        }

        private void btnApproveSelected_Click(object sender, EventArgs e)
        {
            if (dgvSuggestions.DataSource is not DataTable dt) return;

            int count = 0;
            foreach (DataRow row in dt.Rows)
                if ((bool)row["Chọn"]) count++;

            if (count == 0)
            {
                MsgBox.Show("Vui lòng chọn ít nhất 1 đề xuất!", "Thông báo", MsgBox.MessageBoxType.Warning);
                return;
            }
            MsgBox.Show($"Đã duyệt {count} đề xuất đã chọn!", "Thành công", MsgBox.MessageBoxType.Success);
        }

        private void btnReport_Click(object? sender, EventArgs e)
        {
            string report =
                $"BÁO CÁO ĐỀ XUẤT NHẬP KHO\n" +
                $"Thời gian: {DateTime.Now:HH:mm dd/MM/yyyy}\n" +
                $"──────────────────\n" +
                $"• Số đề xuất: {lblSuggestionsCount.Text}\n" +
                $"• Chi phí ước tính: {lblEstimatedCost.Text}\n" +
                $"──────────────────\n" +
                $"Gửi báo cáo cho quản lý qua Chat?";

            var result = MessageBox.Show(report, "Báo cáo nhập kho",
                MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (result == DialogResult.Yes)
            {
                MsgBox.Show(
                    "Đã gửi báo cáo cho quản lý!\nQuản lý sẽ duyệt qua Chat nội bộ.",
                    "Thành công", MsgBox.MessageBoxType.Success);
            }
        }
    }
}
