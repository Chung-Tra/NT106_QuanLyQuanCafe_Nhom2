using BUS;
using DTO;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace GUI
{
    public partial class ucAttendanceHistory : UserControl
    {
        public ucAttendanceHistory()
        {
            InitializeComponent();

            this.Load += ucAttendanceHistory_Load;

            btnFilter.Click += btnFilter_Click;

            btnReport.Click += BtnReport_Click;
        }

        private async void ucAttendanceHistory_Load(object sender, EventArgs e) => await InitFilterAsync();
        private void btnFilter_Click(object sender, EventArgs e) => LoadData();

        // ──────────────────────────────────────────────
        // KHỞI TẠO BỘ LỌC
        // ──────────────────────────────────────────────
        private async Task InitFilterAsync()
        {
            var user = GlobalSession.CurrentUser;
            bool isPrivileged = user?.Role?.ToLower() is "admin" or "manager";

            if (isPrivileged)
            {
                // Admin/Manager: hiện ComboBox, ẩn label tên
                cboEmployee.Visible = true;
                lblEmployeeName.Visible = false;
                btnFilter.Visible = true;

                try
                {
                    // 1. Gọi BUS lấy danh sách nhân viên từ Database
                    // Chú ý: Thay 'InventoryImportBUS' bằng tên BUS quản lý nhân viên thực tế của bạn nếu khác
                    var dsNhanVien = await InventoryImportBUS.GetEmployees();

                    // 2. Format lại hiển thị thành dạng "Mã - Tên" giống code cũ của bạn
                    var comboData = dsNhanVien.Select(nv => new
                    {
                        Id = nv.EmployeeId,
                        Display = $"{nv.EmployeeId} - {nv.FullName}"
                    }).ToList();

                    // 3. Chèn mục "Tất cả" lên vị trí đầu tiên (Index 0)
                    comboData.Insert(0, new { Id = "ALL", Display = "Tất cả" });

                    // 4. Gán Data cho ComboBox
                    cboEmployee.DataSource = comboData;
                    cboEmployee.DisplayMember = "Display";
                    cboEmployee.ValueMember = "Id";
                }
                catch (Exception ex)
                {
                    MsgBox.Show(MsgBox.OwnerWindow(this), "Lỗi tải nhân viên: " + ex.Message, "Lỗi", MsgBox.MessageBoxType.Error);
                }
            }
            else
            {
                // Nhân viên: ẩn ComboBox, hiện label tên + ẩn nút lọc
                cboEmployee.Visible = false;
                btnFilter.Visible = false;
                lblEmployeeName.Visible = true;

                string display = string.IsNullOrWhiteSpace(user?.FullName)
                    ? "Nhân viên"
                    : $"{user!.EmployeeId} - {user.FullName}";

                lblEmployeeName.Text = display;

                // Tạo 1 list ảo chỉ chứa user hiện tại để ComboBox ẩn vẫn có giá trị lọc đúng
                var singleUserList = new List<object> { new { Id = user?.EmployeeId ?? "", Display = display } };
                cboEmployee.DataSource = singleUserList;
                cboEmployee.DisplayMember = "Display";
                cboEmployee.ValueMember = "Id";
            }

            dtpFrom.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtpTo.Value = DateTime.Now;

            LoadData();
        }

        // ──────────────────────────────────────────────
        // TẢI DỮ LIỆU
        // ──────────────────────────────────────────────
        private void LoadData()
        {
            if (dtpFrom.Value.Date > dtpTo.Value.Date)
            {
                MsgBox.Show(MsgBox.OwnerWindow(this), "Ngày bắt đầu phải trước ngày kết thúc!", "Thông báo", MsgBox.MessageBoxType.Warning);
                return;
            }

            // 2. Lấy điều kiện lọc hiện tại trên giao diện
            DateTime tuNgay = dtpFrom.Value.Date;
            DateTime denNgay = dtpTo.Value.Date;
            string nhanVienDuocChon = cboEmployee.Text ?? "Tất cả";

            // 3. TẠO DỮ LIỆU (Ở đây mình dùng code tạo bảng ảo như bạn đã làm)
            // Nếu sau này có Database, bạn chỉ cần thay đoạn này thành:
            // DataTable dt = ChamCongBUS.LayDanhSach(tuNgay, denNgay, nhanVienDuocChon);
            DataTable dt = new DataTable();
            // ... (Thêm cột và thêm các dòng dữ liệu ảo y hệt code cũ của bạn) ...

            // 4. ÁP DỤNG BỘ LỌC VÀO BẢNG
            if (nhanVienDuocChon != "Tất cả")
            {
                DataTable filtered = dt.Clone(); // Tạo bảng trống giữ nguyên cấu trúc cột
                foreach (DataRow row in dt.Rows)
                {
                    if (row["Nhân viên"].ToString() == nhanVienDuocChon)
                    {
                        filtered.ImportRow(row); // Nhét dòng thỏa mãn điều kiện vào bảng mới
                    }
                }
                dt = filtered; // Cập nhật lại dt bằng bảng đã lọc
            }

            // 5. ĐỔ DỮ LIỆU LÊN BẢNG (dgvAttendance)
            dgvAttendance.DataSource = dt;
        }

        // ──────────────────────────────────────────────
        // NÚT BÁO CÁO SAI SÓT
        // ──────────────────────────────────────────────
        private void BtnReport_Click(object? sender, EventArgs e)
        {
            string report =
                "BÁO CÁO CHẤM CÔNG\n" +
                $"Từ: {dtpFrom.Value:dd/MM/yyyy}  →  Đến: {dtpTo.Value:dd/MM/yyyy}\n" +
                "──────────────────\n" +
                $"• Ngày công : {lblShiftsValue.Text}\n" +
                $"• Nghỉ phép : {lblAbsentValue.Text}\n" +
                $"• Đi muộn  : {lblLateValue.Text}\n" +
                "──────────────────\n" +
                "Gửi báo cáo này cho quản lý qua Chat?";

            var result = MsgBox.Show(
                MsgBox.OwnerWindow(this), report,
                "Báo cáo chấm công", MsgBox.MessageBoxType.Warning);

            if (result == DialogResult.Yes)
            {
                MsgBox.Show(
                    MsgBox.OwnerWindow(this),
                    "Đã gửi báo cáo chấm công cho quản lý!\nQuản lý sẽ duyệt và phản hồi qua Chat nội bộ.",
                    "Thành công", MsgBox.MessageBoxType.Success);
            }
        }

        private void cboEmployee_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
