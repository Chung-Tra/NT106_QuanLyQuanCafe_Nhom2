using BUS;
using DTO;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class EditFood : Form
    {
        private string _currentFoodId = string.Empty;
        private string _imageUrl = string.Empty;

        public EditFood(FoodDTO food)
        {
            InitializeComponent();
            WindowChrome.Apply(this, host: panel1);
            LoadCategories();
            BindData(food);
        }

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
            cmLoai.DisplayMember = "Value";
            cmLoai.ValueMember = "Key";
        }

        private void BindData(FoodDTO food)
        {
            _currentFoodId = food.Id ?? "";
            _imageUrl = food.ImageUrl ?? "";
            if (!string.IsNullOrWhiteSpace(_imageUrl))
                btnChooseImage.Text = "Đổi ảnh (đã có ảnh)";

            txtTenMon.Text = food.Name ?? "";
            txtGia.Text = food.Price.ToString("N0");
            txtMoTa.Text = food.Description ?? "";

            if (!string.IsNullOrEmpty(food.Category))
            {
                try
                {
                    cmLoai.SelectedValue = food.Category;
                }
                catch
                {
                    cmLoai.SelectedIndex = 0;
                }
            }
            else
            {
                cmLoai.SelectedIndex = 0;
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
                    btnChooseImage.Text = "Đã đổi ảnh ✓";
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

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private async void BtnUpdate_Click(object sender, EventArgs e)
        {
            btnUpdate.Enabled = false;
            btnUpdate.Text = "Đang lưu...";

            try
            {
                decimal giaMoi = -1;
                if (decimal.TryParse(txtGia.Text.Replace(",", "").Replace(".", ""), out decimal parsedVal))
                {
                    giaMoi = parsedVal;
                }

                FoodDTO foodUpdate = new()
                {
                    Id = _currentFoodId,
                    Name = txtTenMon.Text.Trim(),
                    Price = giaMoi,
                    Category = cmLoai.SelectedValue?.ToString() ?? "other",
                    Description = txtMoTa.Text.Trim(),
                    InStock = true,
                    IsVisible = true,
                    ImageUrl = _imageUrl
                };

                // Gọi tầng BUS thực hiện cập nhật qua Cloud Function
                var result = await FoodBUS.UpdateFood(foodUpdate);

                if (result.Success)
                {
                    MsgBox.Show(this, "Cập nhật thực đơn thành công!", "Thành công", MsgBox.MessageBoxType.Success);
                    this.DialogResult = DialogResult.OK; // Trả về OK để ucProducts load lại bảng
                    this.Close();
                }
                else
                {
                    MsgBox.Show(this, result.Message, "Lỗi Server", MsgBox.MessageBoxType.Error);
                    btnUpdate.Enabled = true;
                    btnUpdate.Text = "Cập nhật";
                }
            }
            catch (Exception ex)
            {
                MsgBox.Show(this, $"Lỗi hệ thống: {ex.Message}", "Lỗi", MsgBox.MessageBoxType.Error);
                btnUpdate.Enabled = true;
                btnUpdate.Text = "Cập nhật";
            }
        }
    }
}
