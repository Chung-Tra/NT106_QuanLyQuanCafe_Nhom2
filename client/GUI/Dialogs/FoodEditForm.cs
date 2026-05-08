using BUS;
using DTO;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class FoodEditForm : Form
    {
        private string _currentFoodId = string.Empty;

        private const int ColLeftFoodEdit = 36;
        private const int GapYEdit = 8;

        public FoodEditForm(FoodDTO food)
        {
            InitializeComponent();
            LoadCategories();
            BindData(food);
            txtTenMon.TextChanged += (_, _) => RecalcFoodEditLayout();
            txtMoTa.TextChanged += (_, _) => RecalcFoodEditLayout();
            RecalcFoodEditLayout();
        }

        private void RecalcFoodEditLayout()
        {
            DialogAutosizeHelper.SetWrappedTextBoxHeight(txtTenMon, 32, 100);
            DialogAutosizeHelper.SetWrappedTextBoxHeight(txtMoTa, 56, 220);

            int y = txtTenMon.Location.Y;
            txtTenMon.Location = new Point(ColLeftFoodEdit, y);
            y = txtTenMon.Bottom + GapYEdit;

            txtGia.Location = new Point(ColLeftFoodEdit, y);
            y = txtGia.Bottom + GapYEdit;

            cmLoai.Location = new Point(ColLeftFoodEdit, y);
            y = cmLoai.Bottom + GapYEdit;

            txtMoTa.Location = new Point(ColLeftFoodEdit, y);
            y = txtMoTa.Bottom + GapYEdit + 4;

            btnUpdate.Location = new Point(ColLeftFoodEdit, y);
            btnCancel.Location = new Point(164, y);

            int needH = y + btnUpdate.Height + 40;
            int needW = Math.Max(ClientSize.Width, 300);
            ClientSize = new Size(needW, needH);

            lblTitle.Location = new Point(
                Math.Max(12, (ClientSize.Width - lblTitle.Width) / 2), lblTitle.Location.Y);
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

            txtTenMon.Text = food.TenMon ?? "";
            txtGia.Text = food.Gia.ToString("N0");
            txtMoTa.Text = food.MoTa ?? "";

            if (!string.IsNullOrEmpty(food.Loai))
            {
                try
                {
                    cmLoai.SelectedValue = food.Loai;
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
                    TenMon = txtTenMon.Text.Trim(),
                    Gia = giaMoi,
                    Loai = cmLoai.SelectedValue?.ToString() ?? "other",
                    MoTa = txtMoTa.Text.Trim(),
                    ConHang = true, 
                    HienThi = true
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