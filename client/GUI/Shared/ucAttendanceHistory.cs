using BUS;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class ucAttendanceHistory : UserControl
    {
        public ucAttendanceHistory()
        {
            InitializeComponent();

            // Đăng ký sự kiện hệ thống
            this.Load += ucAttendanceHistory_Load;
            btnFilter.Click += btnFilter_Click;
            btnReport.Click += BtnReport_Click;
        }

        private async void ucAttendanceHistory_Load(object sender, EventArgs e) => await InitFilterAsync();

        // TRUYỀN TRUE KHI BẤM NÚT LỌC
        private async void btnFilter_Click(object sender, EventArgs e) => await LoadDataAsync(true);

        // ──────────────────────────────────────────────
        // KHỞI TẠO BỘ LỌC KHI MỞ FORM
        // ──────────────────────────────────────────────
        private async Task InitFilterAsync()
        {
            // Giả định GlobalSession.CurrentUser là biến toàn cục lưu user đang đăng nhập
            var user = GlobalSession.CurrentUser;
            bool isPrivileged = user?.Role?.ToLower() is "admin" or "manager";

            if (isPrivileged)
            {
                cboEmployee.Visible = true;
                lblEmployeeName.Visible = false;
                btnFilter.Visible = true;

                try
                {
                    // Lấy danh sách nhân viên từ BUS
                    var dsNhanVien = await InventoryImportBUS.GetEmployees();

                    var comboData = dsNhanVien.Select(nv => new
                    {
                        Id = nv.EmployeeId,
                        Display = $"{nv.EmployeeId} - {nv.FullName}"
                    }).ToList();

                    // Thêm lựa chọn "Tất cả" lên đầu
                    comboData.Insert(0, new { Id = "ALL", Display = "Tất cả" });

                    cboEmployee.DataSource = new BindingSource(comboData, null);
                    cboEmployee.DisplayMember = "Display";
                    cboEmployee.ValueMember = "Id";
                    cboEmployee.SelectedIndex = 0;
                }
                catch (Exception ex)
                {
                    MsgBox.Show(MsgBox.OwnerWindow(this), "Lỗi tải danh sách nhân viên: " + ex.Message, "Lỗi", MsgBox.MessageBoxType.Error);
                }
            }
            else
            {
                cboEmployee.Visible = false;
                btnFilter.Visible = false;
                lblEmployeeName.Visible = true;

                string display = string.IsNullOrWhiteSpace(user?.FullName)
                    ? "Nhân viên"
                    : $"{user!.EmployeeId} - {user.FullName}";

                lblEmployeeName.Text = display;

                var singleUserList = new List<object> { new { Id = user?.EmployeeId ?? "", Display = display } };
                cboEmployee.DataSource = new BindingSource(singleUserList, null);
                cboEmployee.DisplayMember = "Display";
                cboEmployee.ValueMember = "Id";
            }

            // Mặc định thiết lập thời gian
            dtpFrom.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1); // Đầu tháng hiện tại
            dtpTo.Value = DateTime.Now.Date; // Ngày hiện tại

            // MẶC ĐỊNH LÀ FALSE (KHÔNG LỌC) KHI MỚI VÀO FORM
            await LoadDataAsync(false);
        }

        // ──────────────────────────────────────────────
        // TẢI VÀ XỬ LÝ DỮ LIỆU LÊN GRIDVIEW
        // ──────────────────────────────────────────────

        // THÊM THAM SỐ isFiltering (Mặc định = false)
        private async Task LoadDataAsync(bool isFiltering = false)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                // 1. Lấy dữ liệu từ BUS
                var allData = await AttendanceBUS.GetAllAttendanceAsync();

                // 2. Kiểm tra xem có dữ liệu không
                if (allData == null || allData.Count == 0)
                {
                    // Nếu vào đây nghĩa là API trả về rỗng hoặc lỗi 401
                    // Hãy đặt một Breakpoint ở đây để kiểm tra
                    dgvAttendance.DataSource = null;
                }
                else
                {
                    // 3. Đổ thẳng vào Grid (Không lọc ngày, không lọc ID)
                    dgvAttendance.DataSource = allData.Select(a => new {
                        MaNV = a.NhanVienId,
                        Ngay = a.Ngay,
                        GioVao = FormatTime(a.GioVao),
                        GioRa = FormatTime(a.GioRa),
                        Cong = a.SoGioLam,
                        TrangThai = MapStatus(a.TrangThai),
                        GhiChu = a.GhiChu
                    }).ToList();

                    FormatGridView();
                }

                // Cập nhật thống kê dựa trên tất cả dữ liệu
                lblShiftsValue.Text = allData.Count.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tại GUI: " + ex.Message);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void FormatGridView()
        {
            if (dgvAttendance.Columns.Count > 0)
            {
                if (dgvAttendance.Columns["MaNV"] != null) dgvAttendance.Columns["MaNV"].HeaderText = "Mã NV";
                if (dgvAttendance.Columns["Ngay"] != null) dgvAttendance.Columns["Ngay"].HeaderText = "Ngày";
                if (dgvAttendance.Columns["GioVao"] != null) dgvAttendance.Columns["GioVao"].HeaderText = "Giờ Vào";
                if (dgvAttendance.Columns["GioRa"] != null) dgvAttendance.Columns["GioRa"].HeaderText = "Giờ Ra";

                if (dgvAttendance.Columns["Cong"] != null)
                {
                    dgvAttendance.Columns["Cong"].HeaderText = "Số Giờ";
                    dgvAttendance.Columns["Cong"].DefaultCellStyle.Format = "N1";
                }

                if (dgvAttendance.Columns["TrangThai"] != null) dgvAttendance.Columns["TrangThai"].HeaderText = "Trạng Thái";
                if (dgvAttendance.Columns["GhiChu"] != null) dgvAttendance.Columns["GhiChu"].HeaderText = "Ghi Chú";

                dgvAttendance.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
        }

        // ──────────────────────────────────────────────
        // HÀM TRỢ GIÚP
        // ──────────────────────────────────────────────
        private string FormatTime(long unixMs)
        {
            if (unixMs <= 0) return "--:--";
            return DateTimeOffset.FromUnixTimeMilliseconds(unixMs).ToLocalTime().ToString("HH:mm");
        }

        private string MapStatus(string? status)
        {
            return status switch
            {
                "du_gio" => "Đủ giờ",
                "di_muon" => "Đi muộn",
                "nghi_phep" => "Nghỉ phép",
                "nua_ca" => "Nửa ca",
                _ => status ?? "Chưa rõ"
            };
        }

        private void BtnReport_Click(object? sender, EventArgs e)
        {
            string report = $"BÁO CÁO CHẤM CÔNG\n" +
                           $"Từ: {dtpFrom.Value:dd/MM/yyyy} → Đến: {dtpTo.Value:dd/MM/yyyy}\n" +
                           "──────────────────\n" +
                           $"• Tổng số ca : {lblShiftsValue.Text}\n" +
                           $"• Nghỉ phép  : {lblAbsentValue.Text}\n" +
                           $"• Đi muộn    : {lblLateValue.Text}\n" +
                           "──────────────────\n" +
                           "Gửi báo cáo này cho quản lý?";

            var result = MsgBox.Show(MsgBox.OwnerWindow(this), report, "Báo cáo", MsgBox.MessageBoxType.Warning);
            if (result == DialogResult.Yes)
            {
                MsgBox.Show(MsgBox.OwnerWindow(this), "Đã gửi báo cáo thành công!", "Thành công", MsgBox.MessageBoxType.Success);
            }
        }
    }
}