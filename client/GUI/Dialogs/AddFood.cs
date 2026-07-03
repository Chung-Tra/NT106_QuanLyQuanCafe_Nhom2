using BUS;
using DTO;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace GUI
{
    public partial class AddFood : Form
    {
        public event Action? FoodAdded;
        private readonly string _currentFoodId = string.Empty;
        private string _imageUrl = string.Empty;

        public AddFood()
        {
            InitializeComponent();
            WindowChrome.Apply(this, host: panel1);
            LoadCategories();
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
                    Name = txtTenMon.Text.Trim(),
                    Price = giaThuc,
                    Description = txtMoTa.Text.Trim(),
                    Category = cmLoai.SelectedValue?.ToString() ?? "other",
                    IsVisible = true,
                    InStock = true,
                    ImageUrl = _imageUrl
                };

                // Quyết định Thêm hay Sửa dựa trên ID
                var result = await FoodBUS.AddFood(food);
                bool success = result.Success;
                string message = result.Message;

                // Xử lý kết quả
                if (success)
                {
                    MsgBox.Show(this, $"Thêm món [{food.Name}] thành công!", "Thông báo", MsgBox.MessageBoxType.Success);
                    FoodAdded?.Invoke();
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MsgBox.Show(this, message, "Lỗi xác thực", MsgBox.MessageBoxType.Warning);
                }
            }
            catch (Exception ex)
            {
                MsgBox.Show(this, ex.Message, "Lỗi hệ thống", MsgBox.MessageBoxType.Error);
            }
            finally
            {
                btnAdd.Enabled = true;
                btnAdd.Text = string.IsNullOrEmpty(_currentFoodId) ? "Thêm món" : "Cập nhật";
            }
        }

        private async void BtnChooseImage_Click(object sender, EventArgs e)
        {
            using OpenFileDialog ofd = new()
            {
                Title = "Chọn ảnh món",
                Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif;*.webp"
            };
            if (ofd.ShowDialog(this) != DialogResult.OK) return;

            btnChooseImage.Enabled = false;
            btnChooseImage.Text = "Đang tải ảnh...";
            try
            {
                var (ok, msg, url) = await UploadBUS.UploadImage(ofd.FileName, "mon_uong");
                if (ok && !string.IsNullOrEmpty(url))
                {
                    _imageUrl = url;
                    btnChooseImage.Text = "Đã chọn ảnh ✓";
                }
                else
                {
                    btnChooseImage.Text = "Chọn ảnh món...";
                    MsgBox.Show(this, msg, "Lỗi tải ảnh", MsgBox.MessageBoxType.Error);
                }
            }
            catch (Exception ex)
            {
                btnChooseImage.Text = "Chọn ảnh món...";
                MsgBox.Show(this, ex.Message, "Lỗi", MsgBox.MessageBoxType.Error);
            }
            finally { btnChooseImage.Enabled = true; }
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
