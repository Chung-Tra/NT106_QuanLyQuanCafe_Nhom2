using BUS;
using DTO;
using GUI.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class AddInventoryImport : Form
    {
        private List<IngredientDTO> _danhSachNguyenLieu = [];
        private readonly IReadOnlyList<InventoryImportPrefillLine>? _prefillLines;

        public AddInventoryImport() : this(null) { }

        public AddInventoryImport(IReadOnlyList<InventoryImportPrefillLine>? prefillLines)
        {
            _prefillLines = prefillLines;
            InitializeComponent();
            this.Load += AddInventoryImport_Load;
            btnLuu.Click += BtnLuu_Click;
            dgvChiTietNhap.CellEndEdit += DgvChiTietNhap_CellEndEdit;
            dgvChiTietNhap.RowsRemoved += (_, _) => CapNhatTongTien();
            dgvChiTietNhap.UserDeletedRow += (_, _) => CapNhatTongTien();
        }

        private async void AddInventoryImport_Load(object? sender, EventArgs e)
        {
            await KhoiTaoDuLieuForm();
        }

        private async Task KhoiTaoDuLieuForm()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                btnLuu.Enabled = false;

                await TaiDanhSachNhanVien();
                await TaiDanhSachNguyenLieu();

                dtpNgayNhap.Value = DateTime.Now;
                lblTongTien.Text = "Thành tiền: 0 VNĐ";
                cboNhanVien.SelectedIndex = -1;

                DienTuBangNgoai();
            }
            catch (Exception ex)
            {
                MsgBox.Show(this, $"Không thể tải dữ liệu ban đầu: {ex.Message}", "Lỗi hệ thống", MsgBox.MessageBoxType.Error);
            }
            finally
            {
                btnLuu.Enabled = true;
                this.Cursor = Cursors.Default;
            }
        }

        private async Task TaiDanhSachNhanVien()
        {
            List<EmployeeDTO> dsNhanVien = await InventoryImportBUS.GetEmployees();
            cboNhanVien.DataSource = dsNhanVien;
            cboNhanVien.DisplayMember = nameof(EmployeeDTO.FullName);
            cboNhanVien.ValueMember = nameof(EmployeeDTO.EmployeeId);
        }

        private async Task TaiDanhSachNguyenLieu()
        {
            _danhSachNguyenLieu = await InventoryImportBUS.GetIngredients();

            var dsNguonCombo = _danhSachNguyenLieu
                .Select(x => new { x.Id, HienThi = $"{x.Id} - {x.TenNguyenLieu} ({x.DonVi})" })
                .ToList();

            colMaNL.DataSource = dsNguonCombo;
            colMaNL.DisplayMember = "HienThi";
            colMaNL.ValueMember = "Id";
            colMaNL.FlatStyle = FlatStyle.Flat;
        }

        private void DienTuBangNgoai()
        {
            if (_prefillLines == null || _prefillLines.Count == 0)
                return;

            var hopLe = new HashSet<string>(
                _danhSachNguyenLieu.Select(x => x.Id!).Where(s => !string.IsNullOrEmpty(s)),
                StringComparer.OrdinalIgnoreCase);

            dgvChiTietNhap.Rows.Clear();
            int boQua = 0;

            foreach (InventoryImportPrefillLine line in _prefillLines)
            {
                string id = line.NguyenLieuId.Trim();
                if (string.IsNullOrEmpty(id) || !hopLe.Contains(id))
                {
                    boQua++;
                    continue;
                }

                IngredientDTO? nl = _danhSachNguyenLieu.FirstOrDefault(x =>
                    string.Equals(x.Id, id, StringComparison.OrdinalIgnoreCase));
                if (nl == null)
                {
                    boQua++;
                    continue;
                }

                long gia = line.GiaNhap ?? nl.GiaNhap;

                int idx = dgvChiTietNhap.Rows.Add();
                DataGridViewRow row = dgvChiTietNhap.Rows[idx];
                row.Cells[colMaNL.Name].Value = nl.Id;
                row.Cells[colSoLuong.Name].Value = line.SoLuong;
                row.Cells[colGiaNhap.Name].Value = gia;
            }

            if (boQua > 0)
            {
                MsgBox.Show(
                    this,
                    $"Đã bỏ qua {boQua} dòng không khớp mã nguyên liệu trên hệ thống.",
                    "Nhập từ Excel/CSV",
                    MsgBox.MessageBoxType.Warning);
            }

            if (string.IsNullOrWhiteSpace(txtGhiChu.Text) && _prefillLines.Count > 0)
                txtGhiChu.Text = "Nhập từ file Excel/CSV";

            CapNhatTongTien();
        }

        private void DgvChiTietNhap_CellEndEdit(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (dgvChiTietNhap.Columns[e.ColumnIndex].Name == colMaNL.Name)
                GanGiaNhapMacDinh(e.RowIndex);
            CapNhatTongTien();
        }

        private void GanGiaNhapMacDinh(int rowIndex)
        {
            DataGridViewRow row = dgvChiTietNhap.Rows[rowIndex];
            string nguyenLieuId = row.Cells[colMaNL.Name].Value?.ToString() ?? string.Empty;
            if (string.IsNullOrWhiteSpace(nguyenLieuId)) return;

            IngredientDTO? item = _danhSachNguyenLieu.FirstOrDefault(x => x.Id == nguyenLieuId);
            if (item == null) return;

            row.Cells[colGiaNhap.Name].Value = item.GiaNhap;
            if (row.Cells[colSoLuong.Name].Value == null ||
                string.IsNullOrWhiteSpace(row.Cells[colSoLuong.Name].Value?.ToString()))
                row.Cells[colSoLuong.Name].Value = 1;
        }

        private void CapNhatTongTien()
        {
            long tongTien = 0;
            foreach (DataGridViewRow row in dgvChiTietNhap.Rows)
            {
                if (row.IsNewRow) continue;
                if (!TryLaySoLong(row.Cells[colSoLuong.Name].Value, out long soLuong) || soLuong <= 0) continue;
                if (!TryLaySoLong(row.Cells[colGiaNhap.Name].Value, out long giaNhap) || giaNhap < 0) continue;
                tongTien += soLuong * giaNhap;
            }
            lblTongTien.Text = $"Thành tiền: {tongTien:N0} VNĐ";
        }

        private static bool TryLaySoLong(object? value, out long so)
        {
            so = 0;
            string text = value?.ToString()?.Trim() ?? string.Empty;
            if (string.IsNullOrEmpty(text)) return false;
            text = text.Replace(",", "").Replace(".", "");
            return long.TryParse(text, out so);
        }

        private async void BtnLuu_Click(object? sender, EventArgs e)
        {
            try
            {
                string nhanVienId = cboNhanVien.SelectedValue?.ToString() ?? string.Empty;
                if (string.IsNullOrWhiteSpace(nhanVienId))
                {
                    MsgBox.Show(this, "Vui lòng chọn nhân viên thực hiện nhập kho.", "Thiếu dữ liệu", MsgBox.MessageBoxType.Warning);
                    return;
                }

                var danhSachChiTiet = LayDanhSachChiTietNhap();
                if (danhSachChiTiet.Count == 0)
                {
                    MsgBox.Show(this, "Vui lòng nhập ít nhất một dòng nguyên liệu hợp lệ.", "Thiếu dữ liệu", MsgBox.MessageBoxType.Warning);
                    return;
                }

                var phieuNhap = new InventoryImportDTO
                {
                    GhiChu = txtGhiChu.Text.Trim(),
                    NgayNhap = int.Parse(dtpNgayNhap.Value.ToString("yyyyMMdd")),
                    NhanVienId = nhanVienId,
                    DanhSachNL = danhSachChiTiet
                };

                btnLuu.Enabled = false;
                btnLuu.Text = "Đang lưu...";

                var (success, message) = await InventoryImportBUS.AddImport(phieuNhap);

                if (success)
                {
                    MsgBox.Show(this, "Tạo phiếu nhập kho thành công!", "Thành công", MsgBox.MessageBoxType.Success);
                    DialogResult = DialogResult.OK;
                    Close();
                    return;
                }

                MsgBox.Show(this, message, "Không thể lưu", MsgBox.MessageBoxType.Error);
            }
            catch (Exception ex)
            {
                MsgBox.Show(this, $"Lỗi khi tạo phiếu nhập: {ex.Message}", "Lỗi hệ thống", MsgBox.MessageBoxType.Error);
            }
            finally
            {
                btnLuu.Enabled = true;
                btnLuu.Text = "Tạo phiếu nhập";
            }
        }

        private Dictionary<string, InventoryImportItemDTO> LayDanhSachChiTietNhap()
        {
            var ketQua = new Dictionary<string, InventoryImportItemDTO>();

            foreach (DataGridViewRow row in dgvChiTietNhap.Rows)
            {
                if (row.IsNewRow) continue;

                string nguyenLieuId = row.Cells[colMaNL.Name].Value?.ToString() ?? string.Empty;
                if (string.IsNullOrWhiteSpace(nguyenLieuId)) continue;

                if (!TryLaySoLong(row.Cells[colSoLuong.Name].Value, out long soLuong) || soLuong <= 0) continue;
                if (!TryLaySoLong(row.Cells[colGiaNhap.Name].Value, out long giaNhap) || giaNhap < 0) continue;

                if (ketQua.TryGetValue(nguyenLieuId, out InventoryImportItemDTO? chiTiet))
                {
                    chiTiet.SoLuong += (int)soLuong;
                    chiTiet.GiaNhap = giaNhap;
                }
                else
                {
                    ketQua[nguyenLieuId] = new InventoryImportItemDTO
                    {
                        SoLuong = (int)soLuong,
                        GiaNhap = giaNhap
                    };
                }
            }

            return ketQua;
        }
    }
}
