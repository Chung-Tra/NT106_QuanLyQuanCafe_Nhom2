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

        public EditFood(FoodDTO food)
        {
            InitializeComponent();
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
                    IsVisible = true
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
