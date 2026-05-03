using BUS;
using DTO;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace GUI
{
    public partial class AddDrink : Form
    {
        // Event để thông báo cho Form cha load lại Grid (Nếu dùng Show)
        public event Action? FoodAdded;
        private readonly string _currentFoodId = string.Empty;

        public AddDrink()
        {
            InitializeComponent();
            LoadCategories();
        }

        // 2. Constructor dùng để CẬP NHẬT (Sửa)
        public AddDrink(FoodDTO food)
        {
            InitializeComponent();
            LoadCategories();

            // Đổi giao diện sang chế độ chỉnh sửa
            lblTitle.Text = "CẬP NHẬT THỰC ĐƠN";
            btnAdd.Text = "Cập nhật";
            _currentFoodId = food.Id ?? "";
            txtTenMon.Text = food.TenMon;
            txtGia.Text = food.Gia.ToString();
            txtMoTa.Text = food.MoTa;

            // Chọn đúng loại trong ComboBox dựa trên Key
            if (!string.IsNullOrEmpty(food.Loai))
                cmLoai.SelectedValue = food.Loai;
        }

        // Hàm nạp danh sách Loại món uống
        private void LoadCategories()
        {
            Dictionary<string, string> categoryData = new()
            {
                { "cafe", "Cà phê" },
                { "tea", "Trà / Trà sữa" },
                { "topping", "Topping" },
                { "juice", "Nước ép / Sinh tố" },
                { "food", "Đồ ăn vặt" },
                { "other", "Khác" }
            };

            cmLoai.DataSource = new BindingSource(categoryData, null);
            cmLoai.DisplayMember = "Value"; // Hiển thị tiếng Việt
            cmLoai.ValueMember = "Key";     // Lưu xuống DB tiếng Anh/Mã
        }

        private async void BtnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                // Khóa nút tránh double click
                btnAdd.Enabled = false;
                btnAdd.Text = "Đang lưu...";

                // Kiểm tra giá tiền có hợp lệ không
                decimal giaThuc = -1;
                if (decimal.TryParse(txtGia.Text.Replace(",", "").Replace(".", ""), out decimal parsedVal))
                {
                    giaThuc = parsedVal;
                }

                // Thu thập dữ liệu
                FoodDTO food = new()
                {
                    Id = _currentFoodId, // Nếu thêm mới thì cái này sẽ trống
                    TenMon = txtTenMon.Text.Trim(),
                    Gia = giaThuc,
                    MoTa = txtMoTa.Text.Trim(),
                    Loai = cmLoai.SelectedValue?.ToString() ?? "other",
                    HienThi = true,
                    ConHang = true,
                    HinhAnhUrl = ""
                };

                // Quyết định Thêm hay Sửa dựa trên ID
                var result = await FoodBUS.AddFood(food);
                bool success = result.Success;
                string message = result.Message;

                // Xử lý kết quả
                if (success)
                {
                    MsgBox.Show($"Thêm món [{food.TenMon}] thành công!", "Thông báo", MsgBox.MessageBoxType.Success);
                    FoodAdded?.Invoke();
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MsgBox.Show(message, "Lỗi xác thực", MsgBox.MessageBoxType.Warning);
                }
            }
            catch (Exception ex)
            {
                MsgBox.Show(ex.Message, "Lỗi hệ thống", MsgBox.MessageBoxType.Error);
            }
            finally
            {
                btnAdd.Enabled = true;
                btnAdd.Text = string.IsNullOrEmpty(_currentFoodId) ? "Thêm món" : "Cập nhật";
            }
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}