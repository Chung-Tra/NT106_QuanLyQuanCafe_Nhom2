using BUS;
using DTO;
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
    public partial class ucProducts_Manager : UserControl
    {

        public ucProducts_Manager()
        {
            InitializeComponent();
            this.Load += async (s, e) => await LoadRealData();
        }

        private async Task LoadRealData()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                dgvMenu.DataSource = null;

                // Lấy danh sách món ăn 
                List<FoodDTO> fullList = await FoodBUS.GetListFoods();

                if (fullList == null || fullList.Count == 0)
                    return;

                // Tạo cấu trúc bảng (Giữ nguyên để code xử lý bên dưới không bị lỗi)
                DataTable dt = new();
                dt.Columns.Add("Mã món");
                dt.Columns.Add("Tên món ăn");
                dt.Columns.Add("Giá bán", typeof(decimal));
                dt.Columns.Add("Loại");
                dt.Columns.Add("Trạng thái");
                dt.Columns.Add("MoTa");
                dt.Columns.Add("HinhAnhUrl");
                dt.Columns.Add("ConHang", typeof(bool));

                // Đổ dữ liệu (Giữ nguyên fullList để sau này cần lấy Id/Giá vẫn có sẵn trong DataTable)
                foreach (var food in fullList)
                {
                    dt.Rows.Add(
                        food.Id,
                        food.TenMon,
                        food.Gia,
                        food.Loai,
                        food.ConHang ? "Đang kinh doanh" : "Ngừng bán",
                        food.MoTa,
                        food.HinhAnhUrl,
                        food.ConHang
                    );
                }

                dgvMenu.DataSource = dt;

                // Thiết lập hiển thị - Đưa "Mã món" và "Giá bán" vào danh sách ẩn
                string[] hideCols = ["Mã món", "MoTa", "HinhAnhUrl", "ConHang"];
                foreach (var col in hideCols)
                {
                    if (dgvMenu.Columns.Contains(col)) dgvMenu.Columns[col].Visible = false;
                }

                dgvMenu.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                dgvMenu.Columns["Tên món ăn"].FillWeight = 35;
                dgvMenu.Columns["Giá bán"].FillWeight = 20;
                dgvMenu.Columns["Loại"].FillWeight = 25;
                dgvMenu.Columns["Trạng thái"].FillWeight = 20;

                dgvMenu.Columns["Giá bán"].DefaultCellStyle.Format = "N0";
                dgvMenu.Columns["Giá bán"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                dgvMenu.Columns["Loại"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvMenu.Columns["Trạng thái"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                // Khóa Grid để nhìn sạch sẽ
                dgvMenu.ReadOnly = true;
                dgvMenu.RowHeadersVisible = false;
                dgvMenu.AllowUserToAddRows = false;
            }
            catch (Exception ex)
            {
                MsgBox.Show(MsgBox.OwnerWindow(this), $"Lỗi tải thực đơn: {ex.Message}", "Lỗi hệ thống", MsgBox.MessageBoxType.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private async void BtnAddMenu_Click(object sender, EventArgs e)
        {
            FoodForm frmAdd = new();
            if (frmAdd.ShowDialog(MsgBox.OwnerWindow(this)) == DialogResult.OK)
            {
                await LoadRealData();
                MsgBox.Show(MsgBox.OwnerWindow(this), "Món ăn mới đã được thêm vào thực đơn!", "Thành công", MsgBox.MessageBoxType.Success);
            }
        }

        private async void BtnEditMenu_Click(object sender, EventArgs e)
        {
            if (dgvMenu.CurrentRow == null || dgvMenu.CurrentRow.Index < 0)
            {
                MsgBox.Show(MsgBox.OwnerWindow(this), "Vui lòng chọn món ăn cần chỉnh sửa!", "Thông báo", MsgBox.MessageBoxType.Warning);
                return;
            }

            // Lấy dữ liệu từ dòng đang chọn
            DataGridViewRow row = dgvMenu.CurrentRow;
            FoodDTO foodToEdit = new()
            {
                Id = row.Cells["Mã món"].Value?.ToString() ?? string.Empty,
                TenMon = row.Cells["Tên món ăn"].Value?.ToString() ?? string.Empty,
                Gia = Convert.ToDecimal(row.Cells["Giá bán"].Value),
                Loai = row.Cells["Loại"].Value?.ToString() ?? string.Empty,
                MoTa = row.Cells["MoTa"].Value?.ToString() ?? string.Empty,
                HinhAnhUrl = row.Cells["HinhAnhUrl"].Value?.ToString() ?? string.Empty,
                ConHang = Convert.ToBoolean(row.Cells["ConHang"].Value)
            };

            FoodEditForm frmEdit = new(foodToEdit);
            if (frmEdit.ShowDialog(MsgBox.OwnerWindow(this)) == DialogResult.OK)
            {
                await LoadRealData();
                MsgBox.Show(MsgBox.OwnerWindow(this), "Đã cập nhật thông tin món ăn!", "Thông báo", MsgBox.MessageBoxType.Success);
            }
        }

        // Sự kiện Click đúp để xem chi tiết + tùy chọn xóa
        private async void DgvMenu_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dgvMenu.Rows[e.RowIndex];
            FoodDTO food = new()
            {
                Id = row.Cells["Mã món"].Value?.ToString() ?? string.Empty,
                TenMon = row.Cells["Tên món ăn"].Value?.ToString(),
                Gia = Convert.ToDecimal(row.Cells["Giá bán"].Value),
                Loai = row.Cells["Loại"].Value?.ToString(),
                MoTa = row.Cells["MoTa"].Value?.ToString(),
                ConHang = Convert.ToBoolean(row.Cells["ConHang"].Value),
            };

            using FoodDetail dlg = new(food);
            if (dlg.ShowDialog(MsgBox.OwnerWindow(this)) == DialogResult.Yes)
                await LoadRealData();
        }

        private void BtnImportMaterial_Click(object sender, EventArgs e)
        {
            using WarehouseManagerForm frm = new();
            frm.ShowDialog(MsgBox.OwnerWindow(this));
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            // Lấy DataTable đang chứa dữ liệu của lưới dgvMenu
            DataTable? dt = dgvMenu.DataSource as DataTable;
            if (dt == null) return;

            // Tạo một danh sách (List) để gom các điều kiện lọc lại với nhau
            List<string> filterParts = new ();

            // TÌM THEO TÊN HOẶC DANH MỤC (LOẠI) ---
            string keyword = txtSearch.Text.Trim().Replace("'", "''"); // Tránh lỗi SQL Injection nội bộ
            if (!string.IsNullOrEmpty(keyword))
            {
                // Sửa [Mã món] thành cột [Loại]
                filterParts.Add($"([Tên món ăn] LIKE '%{keyword}%' OR [Loại] LIKE '%{keyword}%')");
            }

            // GIÁ TỪ ) ---
            string minText = txtMinPrice.Text.Replace(",", "").Replace(".", "").Trim();
            if (decimal.TryParse(minText, out decimal minPrice))
            {
                filterParts.Add($"[Giá bán] >= {minPrice}");
            }

            // GIÁ ĐẾN 
            string maxText = txtMaxPrice.Text.Replace(",", "").Replace(".", "").Trim();
            if (decimal.TryParse(maxText, out decimal maxPrice))
            {
                filterParts.Add($"[Giá bán] <= {maxPrice}");
            }

            // GHÉP CÁC ĐIỀU KIỆN LẠI VỚI NHAU (Bằng chữ AND)
            string finalFilter = string.Join(" AND ", filterParts);

            try
            {
                // Áp dụng thẳng bộ lọc vào DataGridView 
                dt.DefaultView.RowFilter = finalFilter;
            }
            catch (Exception ex)
            {
                MsgBox.Show(MsgBox.OwnerWindow(this), "Lỗi khi áp dụng bộ lọc: " + ex.Message, "Lỗi", MsgBox.MessageBoxType.Error);
            }
        }

        private void btnClearFilter_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            txtMinPrice.Clear();
            txtMaxPrice.Clear();

            if (dgvMenu.DataSource is DataTable dt)
            {
                dt.DefaultView.RowFilter = string.Empty;
            }
        }

        private async void BtnDeleteMenu_Click(object sender, EventArgs e)
        {
            if (dgvMenu.CurrentRow == null || dgvMenu.CurrentRow.Index < 0)
            {
                MsgBox.Show(MsgBox.OwnerWindow(this), "Vui lòng chọn món ăn cần xóa!", "Thông báo", MsgBox.MessageBoxType.Warning);
                return;
            }

            string tenMon = dgvMenu.CurrentRow.Cells["Tên món ăn"].Value?.ToString() ?? "";
            string maMonId = dgvMenu.CurrentRow.Cells["Mã món"].Value?.ToString() ?? "";

            var result = MsgBox.Show(
                MsgBox.OwnerWindow(this),
                $"Bạn có chắc chắn muốn xóa món \"{tenMon}\"?",
                "Xác nhận xóa",
                MsgBox.MessageBoxType.Warning);

            if (result == DialogResult.Yes)
            {
                try
                {
                    var (deleted, errorMessage) = await FoodBUS.DeleteFood(maMonId);
                    if (deleted)
                    {
                        await LoadRealData();
                        MsgBox.Show(MsgBox.OwnerWindow(this), "Đã xóa món ăn thành công!", "Thành công", MsgBox.MessageBoxType.Success);
                    }
                    else
                    {
                        MsgBox.Show(MsgBox.OwnerWindow(this), "Không thể xóa món ăn!", "Lỗi", MsgBox.MessageBoxType.Error);
                    }
                }
                catch (Exception ex)
                {
                    MsgBox.Show(MsgBox.OwnerWindow(this), $"Lỗi khi xóa: {ex.Message}", "Lỗi hệ thống", MsgBox.MessageBoxType.Error);
                }
            }
        }
    }
}
