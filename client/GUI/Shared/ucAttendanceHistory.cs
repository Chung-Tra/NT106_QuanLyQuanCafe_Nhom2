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
            dgvAttendance.AutoGenerateColumns = false; // cột khai trong Designer; tắt auto-gen ở .cs cho an toàn round-trip
            GridColumnGuard.SyncColumnNames(dgvAttendance);

            // Double-click 1 dòng -> form chi tiết read-only đủ field
            dgvAttendance.CellDoubleClick += (s, e) =>
            {
                if (e.RowIndex < 0) return;
                RecordDetail.FromRow(dgvAttendance.Rows[e.RowIndex], "Chi tiết chấm công")
                            .ShowDialog(MsgBox.OwnerWindow(this));
            };

            DgvRefresh.Attach(dgvAttendance, LoadData);
        }

        private async void ucAttendanceHistory_Load(object sender, EventArgs e) => await InitFilterAsync();
        private void btnFilter_Click(object sender, EventArgs e) => LoadData();

        // Khởi tạo bộ lọc
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
                    // 1. Gọi BUS lấy danh sách nhân viên từ Database (Task.Run: HTTP + parse
                    // JSON chạy ở thread pool để không chiếm luồng UI trong lúc chờ server)
                    var dsNhanVien = await Task.Run(InventoryImportBUS.GetEmployees);

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

        // Tải dữ liệu
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

            // 3. Tạo dữ liệu (Ở đây mình dùng code tạo bảng ảo như bạn đã làm)
            // Nếu sau này có Database, bạn chỉ cần thay đoạn này thành:
            // DataTable dt = ChamCongBUS.LayDanhSach(tuNgay, denNgay, nhanVienDuocChon);
            DataTable dt = new DataTable();
            // ... (Thêm cột và thêm các dòng dữ liệu ảo y hệt code cũ của bạn) ...

            // 4. Áp dụng bộ lọc vào bảng
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

            // 5. Đổ dữ liệu lên bảng (dgvAttendance)
            dgvAttendance.DataSource = dt;
        }

        private void cboEmployee_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
