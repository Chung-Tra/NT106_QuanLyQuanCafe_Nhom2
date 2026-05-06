using BUS;
using DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class FoodEditForm : Form
    {
        private string _currentFoodId = string.Empty;

        public FoodEditForm(FoodDTO food)
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

            txtTenMon.Text = food.TenMon;
            txtGia.Text = food.Gia.ToString("N0"); 
            txtMoTa.Text = food.MoTa;

            if (cmLoai.Items.Contains(food.Loai))
            {
                cmLoai.SelectedItem = food.Loai;
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
                    TenMon = txtTenMon.Text.Trim(),
                    Gia = giaMoi,
                    Loai = cmLoai.SelectedItem?.ToString() ?? "",
                    MoTa = txtMoTa.Text.Trim(),
                    ConHang = true, 
                    HienThi = true
                };

                // Gọi tầng BUS thực hiện cập nhật qua Cloud Function
                var result = await FoodBUS.UpdateFood(foodUpdate);

                if (result.Success)
                {
                    MsgBox.Show("Cập nhật thực đơn thành công!", "Thành công", MsgBox.MessageBoxType.Success);
                    this.DialogResult = DialogResult.OK; // Trả về OK để ucProducts load lại bảng
                    this.Close();
                }
                else
                {
                    MsgBox.Show(result.Message, "Lỗi Server", MsgBox.MessageBoxType.Error);
                    btnUpdate.Enabled = true;
                    btnUpdate.Text = "Cập nhật";
                }
            }
            catch (Exception ex)
            {
                MsgBox.Show($"Lỗi hệ thống: {ex.Message}", "Lỗi", MsgBox.MessageBoxType.Error);
                btnUpdate.Enabled = true;
                btnUpdate.Text = "Cập nhật";
            }
        }
    }
}