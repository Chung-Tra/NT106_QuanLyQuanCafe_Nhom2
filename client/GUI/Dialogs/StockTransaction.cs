using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace GUI
{
    public partial class StockTransaction : Form
    {
        public enum TransactionType { Import, Export, Waste }
        private readonly TransactionType _type;

        public StockTransaction(TransactionType type)
        {
            _type = type;
            InitializeComponent();
            SetupForType();
        }

        private void SetupForType()
        {
            switch (_type)
            {
                case TransactionType.Import:
                    this.Text = "Nhập kho nguyên liệu";
                    lblTitle.Text = "Nhập kho nguyên liệu";
                    btnConfirm.Text = "Xác nhận nhập";
                    btnConfirm.BackColor = Color.MediumSeaGreen;
                    break;
                case TransactionType.Export:
                    this.Text = "Xuất kho nguyên liệu";
                    lblTitle.Text = "Xuất kho nguyên liệu";
                    btnConfirm.Text = "Xác nhận xuất";
                    btnConfirm.BackColor = Color.SteelBlue;
                    break;
                case TransactionType.Waste:
                    this.Text = "Ghi nhận hao phí";
                    lblTitle.Text = "Ghi nhận hao phí";
                    btnConfirm.Text = "Ghi nhận";
                    btnConfirm.BackColor = Color.IndianRed;
                    break;
            }

            // Load items into combobox
            cmbItem.Items.AddRange(new object[]
            {
                "Cà phê hạt Arabica",
                "Sữa tươi",
                "Sữa đặc",
                "Đường",
                "Bột cacao",
                "Trà đào",
                "Sả tươi",
                "Đào ngâm",
                "Trân châu",
                "Syrup vanilla",
                "Đá viên",
                "Bơ"
            });
            if (cmbItem.Items.Count > 0) cmbItem.SelectedIndex = 0;

            cmbUnit.Items.AddRange(new object[] { "kg", "lít", "lon", "gói", "chai", "bao", "hộp", "bó" });
            if (cmbUnit.Items.Count > 0) cmbUnit.SelectedIndex = 0;
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (cmbItem.SelectedIndex < 0)
            {
                MsgBox.Show("Vui lòng chọn nguyên liệu!", "Thông báo", MsgBox.MessageBoxType.Warning);
                return;
            }
            if (nudQuantity.Value <= 0)
            {
                MsgBox.Show("Số lượng phải lớn hơn 0!", "Thông báo", MsgBox.MessageBoxType.Warning);
                return;
            }

            string action = _type switch
            {
                TransactionType.Import => "nhập kho",
                TransactionType.Export => "xuất kho",
                TransactionType.Waste => "ghi nhận hao phí",
                _ => ""
            };

            MsgBox.Show(
                $"Đã {action} thành công!\n{cmbItem.SelectedItem}: {nudQuantity.Value} {cmbUnit.SelectedItem}",
                "Thành công",
                MsgBox.MessageBoxType.Success
            );

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
