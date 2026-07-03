using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace GUI
{
    public partial class ucSelfOrder_Order : UserControl
    {
        private DataTable _dtIncoming = null!;
        private int _orderCounter = 0;

        private static readonly string[] SimItems =
        {
            "Cà phê đen × 1",
            "Latte × 2, Bánh flan × 1",
            "Trà sữa trân châu × 2",
            "Sinh tố xoài × 1, Nước cam × 1",
            "Cappuccino × 3",
        };

        private static readonly string[] SimTables =
        {
            "Bàn 02", "Bàn 05", "Bàn 09", "Bàn 12", "Bàn 14",
        };

        public ucSelfOrder_Order()
        {
            InitializeComponent();

            // Populate table combo (dynamic loop) + initial selection
            for (int i = 1; i <= 15; i++)
                _cmbTable.Items.Add($"Bàn {i:00}");
            _cmbTable.SelectedIndex = 0;
            lblQRTable.Text = $"Bàn: {_cmbTable.SelectedItem}";

            DgvRefresh.Attach(_dgvIncoming, LoadIncoming);

            // Double-click 1 đơn đến -> form chi tiết read-only đủ field
            _dgvIncoming.CellDoubleClick += (s, e) =>
            {
                if (e.RowIndex < 0) return;
                RecordDetail.FromRow(_dgvIncoming.Rows[e.RowIndex], "Chi tiết đơn tự đặt")
                            .ShowDialog(MsgBox.OwnerWindow(this));
            };

            // Runtime QR painting + combo change wiring
            _pnlQR.Paint += PnlQR_Paint;
            _cmbTable.SelectedIndexChanged += (s, e) =>
            {
                _pnlQR.Invalidate();
                lblQRTable.Text = $"Bàn: {_cmbTable.SelectedItem}";
            };

            // Print button (uses runtime selection + owner window)
            btnPrint.Click += (s, e) =>
                MsgBox.Show(MsgBox.OwnerWindow(this), $"Đã in QR cho {_cmbTable.SelectedItem}!", "In thành công", MsgBox.MessageBoxType.Success);

            // Runtime grid styling (declared in Designer, styled here so appearance is identical)
            Theme.StyleGrid(_dgvIncoming);

            Load += (s, e) => LoadIncoming();
        }

        private void PnlQR_Paint(object? sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            g.Clear(Color.White);
            string table = _cmbTable.SelectedItem?.ToString() ?? "Bàn 01";
            int cell = 240 / 21;
            var rng = new System.Random(table.GetHashCode());
            using var blackBrush = new SolidBrush(Color.Black);
            DrawQRFinder(g, blackBrush, cell, 0, 0);
            DrawQRFinder(g, blackBrush, cell, 14, 0);
            DrawQRFinder(g, blackBrush, cell, 0, 14);
            for (int row = 0; row < 21; row++)
            {
                for (int col = 0; col < 21; col++)
                {
                    if ((row < 8 && col < 8) || (row < 8 && col >= 13) || (row >= 13 && col < 8))
                        continue;
                    if (rng.Next(2) == 1)
                        g.FillRectangle(blackBrush, col * cell, row * cell, cell, cell);
                }
            }
        }

        private static void DrawQRFinder(Graphics g, Brush b, int cell, int ox, int oy)
        {
            g.FillRectangle(b, ox * cell, oy * cell, 7 * cell, 7 * cell);
            using var w = new SolidBrush(Color.White);
            g.FillRectangle(w, (ox + 1) * cell, (oy + 1) * cell, 5 * cell, 5 * cell);
            g.FillRectangle(b, (ox + 2) * cell, (oy + 2) * cell, 3 * cell, 3 * cell);
        }

        private void LoadIncoming()
        {
            _dtIncoming = new DataTable();
            _dtIncoming.Columns.Add("Thời gian");
            _dtIncoming.Columns.Add("Bàn");
            _dtIncoming.Columns.Add("Món đặt");
            _dtIncoming.Columns.Add("SL", typeof(int));
            _dtIncoming.Columns.Add("Trạng thái");

            _dtIncoming.Rows.Add("08:41", "Bàn 03", "Cà phê sữa × 2, Bánh croissant × 1", 3, "Đã nhận");
            _dtIncoming.Rows.Add("09:05", "Bàn 07", "Trà đào cam sả × 3",                  3, "Đã nhận");
            _dtIncoming.Rows.Add("10:28", "Bàn 11", "Matcha latte × 1, Latte × 2",         3, "Đã nhận");

            _dgvIncoming.DataSource = _dtIncoming;
            _dgvIncoming.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            _dgvIncoming.Columns["Thời gian"].FillWeight = 14;
            _dgvIncoming.Columns["Bàn"].FillWeight       = 12;
            _dgvIncoming.Columns["Món đặt"].FillWeight   = 46;
            _dgvIncoming.Columns["SL"].FillWeight        = 8;
            _dgvIncoming.Columns["Trạng thái"].FillWeight = 20;

            ColorRows();
            UpdateCount();
        }

        private void ColorRows()
        {
            foreach (DataGridViewRow row in _dgvIncoming.Rows)
            {
                string status = row.Cells["Trạng thái"].Value?.ToString() ?? "";
                row.Cells["Trạng thái"].Style.ForeColor = status == "Đã nhận" ? Theme.Green : Theme.Amber;
                if (status == "Mới!")
                    row.DefaultCellStyle.BackColor = Theme.Fade(Theme.Teal, 30);
            }
        }

        private void UpdateCount()
        {
            _lblIncomingCount.Text = $"{_dtIncoming.Rows.Count} đơn hôm nay";
        }

        private void BtnSimulate_Click(object? sender, EventArgs e)
        {
            _orderCounter++;
            string newTable = SimTables[_orderCounter % SimTables.Length];
            string newItems = SimItems[_orderCounter % SimItems.Length];
            int qty = (_orderCounter % 4) + 1;

            var row = _dtIncoming.NewRow();
            row["Thời gian"] = DateTime.Now.ToString("HH:mm");
            row["Bàn"]       = newTable;
            row["Món đặt"]   = newItems;
            row["SL"]        = qty;
            row["Trạng thái"] = "Mới!";
            _dtIncoming.Rows.InsertAt(row, 0);

            ColorRows();
            UpdateCount();

            MsgBox.Show(MsgBox.OwnerWindow(this),
                $"Đơn mới từ {newTable}!\n\n{newItems}\n\nĐơn đã vào POS — KDS sẽ hiển thị ngay.",
                "Đơn vào realtime", MsgBox.MessageBoxType.Success);
        }
    }
}
