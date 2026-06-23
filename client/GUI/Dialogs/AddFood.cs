using BUS;
using DTO;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace GUI
{
    public partial class FoodForm : Form
    {
        public event Action? FoodAdded;
        private readonly string _currentFoodId = string.Empty;

        private const int ColLeftFood = 49;
        private const int FoodFieldWidth = 228;
        private const int GapY = 8;

        public FoodForm()
        {
            InitializeComponent();
            LoadCategories();
            txtTenMon.TextChanged += (_, _) => RecalcFoodAddLayout();
            txtMoTa.TextChanged += (_, _) => RecalcFoodAddLayout();
            RecalcFoodAddLayout();
        }

        /// <summary>Đặt lại chiều cao các ô và form theo độ dài chữ.</summary>
        private void RecalcFoodAddLayout()
        {
            DialogAutosizeHelper.SetWrappedTextBoxHeight(txtTenMon, 32, 100);
            DialogAutosizeHelper.SetWrappedTextBoxHeight(txtMoTa, 52, 220);

            int y = txtTenMon.Location.Y;
            txtTenMon.Location = new Point(ColLeftFood, y);
            y = txtTenMon.Bottom + GapY;

            txtGia.Location = new Point(ColLeftFood, y);
            y = txtGia.Bottom + GapY;

            cmLoai.Location = new Point(ColLeftFood, y);
            y = cmLoai.Bottom + GapY;

            txtMoTa.Location = new Point(ColLeftFood, y);
            y = txtMoTa.Bottom + GapY + 4;

            btnAdd.Location = new Point(ColLeftFood, y);
            bttnClose.Location = new Point(172, y);

            int needH = y + btnAdd.Height + 36;
            if (needH != ClientSize.Height || ClientSize.Width < 323)
                ClientSize = new Size(Math.Max(ClientSize.Width, 323), needH);

            lblTitle.Location = new Point(
                Math.Max(12, (ClientSize.Width - lblTitle.Width) / 2), lblTitle.Location.Y);
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
                    MsgBox.Show(this, $"Thêm món [{food.TenMon}] thành công!", "Thông báo", MsgBox.MessageBoxType.Success);
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

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}