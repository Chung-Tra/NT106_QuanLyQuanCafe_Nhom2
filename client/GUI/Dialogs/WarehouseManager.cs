using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using GUI.Helpers;

namespace GUI
{
    public partial class WarehouseManagerForm : Form
    {
        public WarehouseManagerForm()
        {
            InitializeComponent();
        }

        private void BtnTaoPhieu_Click(object? sender, EventArgs e)
        {
            using var dlg = new AddInventoryImport();
            dlg.ShowDialog(this);
        }

        private void BtnTuExcel_Click(object? sender, EventArgs e)
        {
            using var ofd = new OpenFileDialog
            {
                Filter = "Excel / CSV (*.xlsx;*.csv)|*.xlsx;*.csv|Tất cả|*.*",
                Title = "Chọn file Excel hoặc CSV",
            };

            if (ofd.ShowDialog(this) != DialogResult.OK || string.IsNullOrEmpty(ofd.FileName))
                return;

            try
            {
                string ext = Path.GetExtension(ofd.FileName).ToLowerInvariant();
                if (ext != ".csv" && ext != ".xlsx")
                {
                    MsgBox.Show(this, "Chỉ hỗ trợ .xlsx hoặc .csv (Excel: có thể Lưu dưới dạng CSV UTF-8).", "Định dạng không hỗ trợ", MsgBox.MessageBoxType.Warning);
                    return;
                }

                IReadOnlyList<InventoryImportPrefillLine> lines = InventoryImportExcelReader.Read(ofd.FileName);
                if (lines.Count == 0)
                {
                    MsgBox.Show(this, "Không đọc được dòng chi tiết hợp lệ. Kiểm tra cột Mã NL và Số lượng.", "File trống", MsgBox.MessageBoxType.Warning);
                    return;
                }

                using var dlg = new AddInventoryImport(lines);
                dlg.ShowDialog(this);
            }
            catch (Exception ex)
            {
                MsgBox.Show(this, $"Không đọc được file: {ex.Message}", "Lỗi nhập Excel/CSV", MsgBox.MessageBoxType.Error);
            }
        }
    }
}
