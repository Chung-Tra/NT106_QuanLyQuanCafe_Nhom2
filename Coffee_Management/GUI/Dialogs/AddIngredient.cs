using BUS;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class AddIngredient : Form
    {
        private readonly NhapKhoBUS _nhapKhoBUS = new();
        private List<NguyenLieuDTO> _danhSachNguyenLieu = [];

        public AddIngredient()
        {
            InitializeComponent();
            this.Load += AddIngredient_Load;
            btnLuu.Click += BtnLuu_Click;
            dgvChiTietNhap.CellEndEdit += DgvChiTietNhap_CellEndEdit;
            dgvChiTietNhap.RowsRemoved += (_, _) => CapNhatTongTien();
            dgvChiTietNhap.UserDeletedRow += (_, _) => CapNhatTongTien();
        }

        private async void AddIngredient_Load(object? sender, EventArgs e)
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
            }
            catch (Exception ex)
            {
                MsgBox.Show($"Không thể tải dữ liệu ban đầu: {ex.Message}", "Lỗi hệ thống", MsgBox.MessageBoxType.Error);
            }
            finally
            {
                btnLuu.Enabled = true;
                this.Cursor = Cursors.Default;
            }
        }

        private async Task TaiDanhSachNhanVien()
        {
            List<NhanVienDTO> dsNhanVien = await _nhapKhoBUS.LấyDanhSachNhanVien();
            cboNhanVien.DataSource = dsNhanVien;
            cboNhanVien.DisplayMember = nameof(NhanVienDTO.FullName);
            cboNhanVien.ValueMember = nameof(NhanVienDTO.EmployeeId);
        }

        private async Task TaiDanhSachNguyenLieu()
        {
            _danhSachNguyenLieu = await _nhapKhoBUS.LayDanhSachNguyenLieu();

            var dsNguonCombo = _danhSachNguyenLieu
                .Select(x => new
                {
                    x.Id,
                    HienThi = $"{x.Id} - {x.TenNguyenLieu} ({x.DonVi})"
                })
                .ToList();

            colMaNL.DataSource = dsNguonCombo;
            colMaNL.DisplayMember = "HienThi";
            colMaNL.ValueMember = "Id";
            colMaNL.FlatStyle = FlatStyle.Flat;
        }

        private void DgvChiTietNhap_CellEndEdit(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (dgvChiTietNhap.Columns[e.ColumnIndex].Name == colMaNL.Name)
            {
                GanGiaNhapMacDinh(e.RowIndex);
            }

            CapNhatTongTien();
        }

        private void GanGiaNhapMacDinh(int rowIndex)
        {
            DataGridViewRow row = dgvChiTietNhap.Rows[rowIndex];
            string nguyenLieuId = row.Cells[colMaNL.Name].Value?.ToString() ?? string.Empty;

            if (string.IsNullOrWhiteSpace(nguyenLieuId))
                return;

            NguyenLieuDTO? nguyenLieu = _danhSachNguyenLieu.FirstOrDefault(x => x.Id == nguyenLieuId);
            if (nguyenLieu == null)
                return;

            row.Cells[colGiaNhap.Name].Value = nguyenLieu.GiaNhap;

            if (row.Cells[colSoLuong.Name].Value == null || string.IsNullOrWhiteSpace(row.Cells[colSoLuong.Name].Value.ToString()))
            {
                row.Cells[colSoLuong.Name].Value = 1;
            }
        }

        private void CapNhatTongTien()
        {
            long tongTien = 0;

            foreach (DataGridViewRow row in dgvChiTietNhap.Rows)
            {
                if (row.IsNewRow) continue;

                if (!TryLaySoLong(row.Cells[colSoLuong.Name].Value, out long soLuong) || soLuong <= 0)
                    continue;

                if (!TryLaySoLong(row.Cells[colGiaNhap.Name].Value, out long giaNhap) || giaNhap < 0)
                    continue;

                tongTien += soLuong * giaNhap;
            }

            lblTongTien.Text = $"Thành tiền: {tongTien:N0} VNĐ";
        }

        private static bool TryLaySoLong(object? value, out long so)
        {
            so = 0;
            string text = value?.ToString()?.Trim() ?? string.Empty;
            if (string.IsNullOrEmpty(text))
                return false;

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
                    MsgBox.Show("Vui lòng chọn nhân viên thực hiện nhập kho.", "Thiếu dữ liệu", MsgBox.MessageBoxType.Warning);
                    return;
                }

                Dictionary<string, ChiTietNhapDTO> danhSachChiTiet = LayDanhSachChiTietNhap();
                if (danhSachChiTiet.Count == 0)
                {
                    MsgBox.Show("Vui lòng nhập ít nhất một dòng nguyên liệu hợp lệ.", "Thiếu dữ liệu", MsgBox.MessageBoxType.Warning);
                    return;
                }

                int ngayNhap = int.Parse(dtpNgayNhap.Value.ToString("yyyyMMdd"));
                NhapKhoDTO phieuNhap = new()
                {
                    GhiChu = txtGhiChu.Text.Trim(),
                    NgayNhap = ngayNhap,
                    NhanVienId = nhanVienId,
                    DanhSachNL = danhSachChiTiet
                };

                btnLuu.Enabled = false;
                btnLuu.Text = "Đang lưu...";
                string ketQua = await _nhapKhoBUS.TaoPhieuNhap(phieuNhap);

                if (ketQua == "Thành công")
                {
                    MsgBox.Show("Tạo phiếu nhập kho thành công!", "Thành công", MsgBox.MessageBoxType.Success);
                    DialogResult = DialogResult.OK;
                    Close();
                    return;
                }

                MsgBox.Show(ketQua, "Không thể lưu", MsgBox.MessageBoxType.Error);
            }
            catch (Exception ex)
            {
                MsgBox.Show($"Lỗi khi tạo phiếu nhập: {ex.Message}", "Lỗi hệ thống", MsgBox.MessageBoxType.Error);
            }
            finally
            {
                btnLuu.Enabled = true;
                btnLuu.Text = "Tạo nhập kho";
            }
        }

        private Dictionary<string, ChiTietNhapDTO> LayDanhSachChiTietNhap()
        {
            Dictionary<string, ChiTietNhapDTO> ketQua = [];

            foreach (DataGridViewRow row in dgvChiTietNhap.Rows)
            {
                if (row.IsNewRow) continue;

                string nguyenLieuId = row.Cells[colMaNL.Name].Value?.ToString() ?? string.Empty;
                if (string.IsNullOrWhiteSpace(nguyenLieuId))
                    continue;

                if (!TryLaySoLong(row.Cells[colSoLuong.Name].Value, out long soLuong) || soLuong <= 0)
                    continue;

                if (!TryLaySoLong(row.Cells[colGiaNhap.Name].Value, out long giaNhap) || giaNhap < 0)
                    continue;

                if (ketQua.TryGetValue(nguyenLieuId, out ChiTietNhapDTO? chiTiet))
                {
                    chiTiet.SoLuong += (int)soLuong;
                    chiTiet.GiaNhap = giaNhap;
                }
                else
                {
                    ketQua[nguyenLieuId] = new ChiTietNhapDTO
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