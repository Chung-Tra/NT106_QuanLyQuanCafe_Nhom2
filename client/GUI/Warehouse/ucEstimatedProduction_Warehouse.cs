using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace GUI
{
    /// <summary>
    /// Tính số ly/phần dự kiến bán ra dựa trên:
    ///   TonKho hiện tại + lượng vừa nhập mới
    ///   ÷ Định mức nguyên liệu theo công thức (RecipeDTO)
    /// (Shell UI — logic tính toán sẽ kết nối RecipeDTO + IngredientDTO sau)
    /// </summary>
    public class ucEstimatedProduction_Warehouse : UserControl
    {
        private DataGridView dgvIngredients = null!;
        private DataGridView dgvEstimate = null!;
        private Button btnCalculate = null!;
        private Button btnAddImport = null!;
        private Label lblTitle = null!;
        private Label lblNote = null!;
        private Panel pnlSummary = null!;
        private Label lblTotalDrinks = null!;
        private Label lblBottleneck = null!;

        public ucEstimatedProduction_Warehouse()
        {
            BackColor = Color.FromArgb(37, 37, 38);
            ForeColor = Color.White;
            Font = new Font("Segoe UI", 9F);
            Dock = DockStyle.Fill;

            BuildUI();
            LoadDummyData();
        }

        private void BuildUI()
        {
            int pad = 16;

            lblTitle = new Label
            {
                Text = "Dự kiến sản xuất (ly / phần)",
                Location = new Point(pad, 12),
                Font = new Font("Segoe UI", 13F, FontStyle.Bold),
                ForeColor = Color.White,
                AutoSize = true
            };
            lblNote = new Label
            {
                Text = "Tự động tính lại khi nhập thêm nguyên liệu. Nguyên liệu in đỏ = sẽ là điểm nghẽn sản xuất.",
                Location = new Point(pad, 38),
                ForeColor = Color.DimGray,
                AutoSize = true
            };

            // Left: Current ingredients
            var lblLeft = new Label
            {
                Text = "Tồn kho hiện tại:",
                Location = new Point(pad, 65),
                ForeColor = Color.Silver,
                AutoSize = true
            };
            dgvIngredients = new DataGridView
            {
                Location = new Point(pad, 85),
                Size = new Size(330, 300),
                BackgroundColor = Color.FromArgb(45, 45, 48),
                ForeColor = Color.White,
                ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle
                {
                    BackColor = Color.FromArgb(30, 30, 30),
                    ForeColor = Color.White,
                    Font = new Font("Segoe UI", 8.5F, FontStyle.Bold)
                },
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    BackColor = Color.FromArgb(45, 45, 48),
                    ForeColor = Color.White,
                    SelectionBackColor = Color.SteelBlue
                },
                ReadOnly = true,
                AllowUserToAddRows = false,
                RowHeadersVisible = false,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect
            };

            btnAddImport = new Button
            {
                Text = "+ Nhập thêm nguyên liệu",
                Location = new Point(pad, 394),
                Size = new Size(198, 30),
                BackColor = Color.FromArgb(80, 130, 80),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btnAddImport.Click += (s, e) =>
            {
                var dlg = new AddInventoryImport();
                if (dlg.ShowDialog(MsgBox.OwnerWindow(this)) == DialogResult.OK)
                    LoadDummyData();
            };

            // Right: Estimated production
            var lblRight = new Label
            {
                Text = "Số ly / phần dự kiến:",
                Location = new Point(pad + 360, 65),
                ForeColor = Color.Silver,
                AutoSize = true
            };
            dgvEstimate = new DataGridView
            {
                Location = new Point(pad + 360, 85),
                Size = new Size(380, 300),
                BackgroundColor = Color.FromArgb(45, 45, 48),
                ForeColor = Color.White,
                ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle
                {
                    BackColor = Color.FromArgb(30, 30, 30),
                    ForeColor = Color.White,
                    Font = new Font("Segoe UI", 8.5F, FontStyle.Bold)
                },
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    BackColor = Color.FromArgb(45, 45, 48),
                    ForeColor = Color.White,
                    SelectionBackColor = Color.SteelBlue
                },
                ReadOnly = true,
                AllowUserToAddRows = false,
                RowHeadersVisible = false,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect
            };

            btnCalculate = new Button
            {
                Text = "Tính lại",
                Location = new Point(pad + 360, 394),
                Size = new Size(90, 30),
                BackColor = Color.SteelBlue,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btnCalculate.Click += (s, e) => LoadDummyData();

            // Summary panel
            pnlSummary = new Panel
            {
                Location = new Point(pad, 438),
                Size = new Size(760, 60),
                BackColor = Color.FromArgb(30, 30, 30)
            };
            lblTotalDrinks = new Label
            {
                Text = "Tổng số ly có thể pha: 0",
                Location = new Point(12, 10),
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                ForeColor = Color.MediumSeaGreen,
                AutoSize = true
            };
            lblBottleneck = new Label
            {
                Text = "Điểm nghẽn: —",
                Location = new Point(12, 34),
                ForeColor = Color.IndianRed,
                AutoSize = true
            };
            pnlSummary.Controls.AddRange([lblTotalDrinks, lblBottleneck]);

            Controls.AddRange([
                lblTitle, lblNote, lblLeft, dgvIngredients, btnAddImport,
                lblRight, dgvEstimate, btnCalculate, pnlSummary
            ]);
        }

        private void LoadDummyData()
        {
            var dtIng = new DataTable();
            dtIng.Columns.Add("Nguyên liệu");
            dtIng.Columns.Add("Tồn kho");
            dtIng.Columns.Add("Đơn vị");
            dtIng.Columns.Add("Định mức/ly");

            dtIng.Rows.Add("Cà phê Arabica", "25.5 kg", "kg", "18g");
            dtIng.Rows.Add("Sữa tươi",        "8.0 lít", "lít", "150ml");
            dtIng.Rows.Add("Đường cát",        "12.0 kg", "kg", "20g");
            dtIng.Rows.Add("Sả tươi",          "3.0 bó",  "bó", "1/8 bó");
            dtIng.Rows.Add("Trân châu",        "1.2 kg",  "kg", "40g");
            dtIng.Rows.Add("Bột cacao",        "2.5 kg",  "kg", "25g");
            dtIng.Rows.Add("Đá viên",          "4.0 bao", "bao", "0.05 bao");

            dgvIngredients.DataSource = dtIng;
            foreach (DataGridViewRow row in dgvIngredients.Rows)
            {
                if (row.Cells["Nguyên liệu"].Value?.ToString() == "Sữa tươi" ||
                    row.Cells["Nguyên liệu"].Value?.ToString() == "Trân châu")
                    row.DefaultCellStyle.ForeColor = Color.IndianRed;
            }

            var dtEst = new DataTable();
            dtEst.Columns.Add("Món");
            dtEst.Columns.Add("Loại");
            dtEst.Columns.Add("Ước tính (ly)", typeof(int));
            dtEst.Columns.Add("Giới hạn bởi");

            dtEst.Rows.Add("Cà phê đen", "Cafe", 1416, "Cà phê Arabica");
            dtEst.Rows.Add("Bạc xỉu",    "Cafe",   53, "Sữa tươi ⚠");
            dtEst.Rows.Add("Cacao sữa",  "Nóng",  100, "Bột cacao");
            dtEst.Rows.Add("Trà sữa TC", "Trà",    30, "Trân châu ⚠");
            dtEst.Rows.Add("Trà sả",     "Trà",    24, "Sả tươi");
            dtEst.Rows.Add("Cà phê đá",  "Cafe",   80, "Đá viên");

            dgvEstimate.DataSource = dtEst;
            dgvEstimate.Columns["Ước tính (ly)"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            foreach (DataGridViewRow row in dgvEstimate.Rows)
            {
                string limit = row.Cells["Giới hạn bởi"].Value?.ToString() ?? "";
                if (limit.Contains("⚠"))
                    row.DefaultCellStyle.ForeColor = Color.IndianRed;

                if (row.Cells["Ước tính (ly)"].Value is int val && val < 50)
                    row.DefaultCellStyle.ForeColor = Color.Orange;
            }

            lblTotalDrinks.Text = "Tổng số ly có thể pha: ~1,703 ly";
            lblBottleneck.Text  = "Điểm nghẽn: Sữa tươi (53 ly) · Trân châu (30 ly)";
        }
    }
}
