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
            txtFoodName.Text = food.TenMon;

            txtPrice.Text = food.Gia.ToString("N0") + " VNĐ";

            txtCategory.Text = food.Loai switch
            {
                "cafe" => "Cà phê",
                "tea" => "Trà / Trà sữa",
                "topping" => "Topping",
                "juice" => "Nước ép / Sinh tố",
                "food" => "Đồ ăn vặt",
                "other" => "Khác",
                _ => food.Loai ?? "—"
            };

            if (food.ConHang)
            {
                txtStatus.Text = "Đang kinh doanh";
                txtStatus.ForeColor = Color.LimeGreen;
            }
            else
            {
                txtStatus.Text = "Ngừng kinh doanh";
                txtStatus.ForeColor = Color.IndianRed;
            }

            txtMoTa.Text = string.IsNullOrWhiteSpace(food.MoTa) ? "—" : food.MoTa;
            RecalcFoodDetailLayout();
        }

        private void RecalcFoodDetailLayout()
        {
            const int lx = 30;
            const int fx = 34;
            const int fw = 350;
            const int g = 8;

            int y = lblTitle.Bottom + 14;

            lblFoodId.Location = new Point(lx, y);
            y += lblFoodId.Height + 2;
            txtFoodId.Location = new Point(fx, y);
            txtFoodId.Width = fw;
            y = txtFoodId.Bottom + g;

            lblFoodName.Location = new Point(lx, y);
            y += lblFoodName.Height + 2;
            txtFoodName.Location = new Point(fx, y);
            txtFoodName.Width = fw;
            DialogAutosizeHelper.SetWrappedTextBoxHeight(txtFoodName, 32, 120);
            y = txtFoodName.Bottom + g;

            lblPrice.Location = new Point(lx, y);
            y += lblPrice.Height + 2;
            txtPrice.Location = new Point(fx, y);
            txtPrice.Width = fw;
            y = txtPrice.Bottom + g;

            int rowCatY = y;
            lblCategory.Location = new Point(lx, rowCatY);
            lblStatus.Location = new Point(220, rowCatY);
            rowCatY += Math.Max(lblCategory.Height, lblStatus.Height) + 2;

            txtCategory.Location = new Point(fx, rowCatY);
            txtStatus.Location = new Point(224, rowCatY);
            y = Math.Max(txtCategory.Bottom, txtStatus.Bottom) + g;

            lblMoTa.Location = new Point(lx, y);
            y += lblMoTa.Height + 2;
            txtMoTa.Location = new Point(fx, y);
            txtMoTa.Width = fw;
            DialogAutosizeHelper.SetWrappedTextBoxHeight(txtMoTa, 56, 280);
            y = txtMoTa.Bottom + g + 8;

            BtnRemove.Location = new Point(fx, y);
            btnClose.Location = new Point(Math.Min(fx + 200, fx + fw - btnClose.Width), y);

            int bottom = y + BtnRemove.Height + 32;
            int preferredW = Math.Max(ClientSize.Width, 420);
            int maxH = DialogAutosizeHelper.MaxDialogClientHeight(this);
            DialogAutosizeHelper.CapFormHeightWithAutoScroll(this, bottom, preferredW, maxH);

            lblTitle.Location = new Point(Math.Max(16, (ClientSize.Width - lblTitle.Width) / 2), 22);
        }

        private async void BtnRemove_Click(object sender, EventArgs e)
        {
            // Hiển thị hộp thoại xác nhận "xịn" của sếp
            DialogResult confirm = MsgBox.Show(
                this,
                $"Sếp có chắc chắn muốn XÓA VĨNH VIỄN món [{_currentFood.TenMon}] không?\nHành động này không thể hoàn tác!",
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