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
    public partial class FoodDetail : Form
    {
        private readonly FoodDTO _currentFood;

        // Constructor nhận dữ liệu món ăn từ ucProducts_Manager truyền sang
        public FoodDetail(FoodDTO food)
        {
            InitializeComponent();
            _currentFood = food;
            BindData(food);
        }

        private void BindData(FoodDTO food)
        {
            txtFoodId.Text = food.Id;
            txtFoodName.Text = food.Name;

            txtPrice.Text = food.Price.ToString("N0") + " VNĐ";

            txtCategory.Text = food.Category switch
            {
                "cafe" => "Cà phê",
                "tea" => "Trà / Trà sữa",
                "topping" => "Topping",
                "juice" => "Nước ép / Sinh tố",
                "food" => "Đồ ăn vặt",
                "other" => "Khác",
                _ => food.Category ?? "—"
            };

            if (food.InStock)
            {
                txtStatus.Text = "Đang kinh doanh";
                txtStatus.ForeColor = Color.FromArgb(34, 197, 94);
            }
            else
            {
                txtStatus.Text = "Ngừng kinh doanh";
                txtStatus.ForeColor = Color.FromArgb(220, 80, 80);
            }

            txtMoTa.Text = string.IsNullOrWhiteSpace(food.Description) ? "—" : food.Description;
        }

        private async void BtnRemove_Click(object sender, EventArgs e)
        {
            // Hiển thị hộp thoại xác nhận "xịn" của sếp
            DialogResult confirm = MsgBox.Show(
                this,
                $"Sếp có chắc chắn muốn XÓA VĨNH VIỄN món [{_currentFood.Name}] không?\nHành động này không thể hoàn tác!",
                "Cảnh báo xóa món",
                MsgBox.MessageBoxType.Warning);

            // Nếu sếp quyết tâm xóa
            if (confirm == DialogResult.Yes)
            {
                // Gọi BUS thực thi xóa qua Cloud Function
                var (Success, Message) = await FoodBUS.DeleteFood(_currentFood.Id ?? "");

                // Xử lý kết quả trả về
                if (Success)
                {
                    // Thông báo thành công màu Xanh
                    MsgBox.Show(this, "Đã xóa món ăn thành công!", "Thông báo", MsgBox.MessageBoxType.Success);

                    // Gán kết quả để ucProducts_Manager biết mà load lại Grid
                    this.DialogResult = DialogResult.Yes;
                    this.Close();
                }
                else
                {
                    // Thông báo lỗi màu Đỏ
                    MsgBox.Show(this, Message, "Lỗi khi xóa", MsgBox.MessageBoxType.Error);
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            // Đóng form khi nhấn nút Đóng
            this.Close();
        }

    }
}
