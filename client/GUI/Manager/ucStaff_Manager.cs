using BUS;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class ucStaff_Manager : UserControl
    {
        public ucStaff_Manager()
        {
            InitializeComponent();
            this.Load += async (s, e) => await LoadRealData();
            btnApproveLeave.Click += BtnApproveLeave_Click;
            InitFilterControls();
        }

        private async Task LoadRealData()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                dgvStaff.DataSource = null;
                dgvStaff.Columns.Clear();

                // 1. Lấy TẤT CẢ danh sách từ Server về
                List<EmployeeDTO> fullList = await EmployeeBUS.GetAllEmployeesAsync();

                if (fullList == null || fullList.Count == 0) return;

                // 2. LỌC CHỈ LẤY NHÂN VIÊN "ACTIVE" VÀ KHÔNG PHẢI LÀ "ADMIN"
                var List = fullList.Where(emp => emp.Role != "admin").ToList();

                // 3. Tạo cấu trúc bảng
                DataTable dt = new();
                dt.Columns.Add("Mã NV");
                dt.Columns.Add("Họ và Tên");
                dt.Columns.Add("Vị Trí");
                dt.Columns.Add("Trạng Thái");
                dt.Columns.Add("Số điện thoại");
                dt.Columns.Add("AuthUid");
                dt.Columns.Add("Email");

                // 4. Đổ danh sách ĐÃ LỌC (activeList) vào bảng
                foreach (var emp in List)
                {
                    dt.Rows.Add(
                        emp.EmployeeId,
                        emp.FullName,
                        emp.Role,
                        emp.Status,
                        emp.PhoneNumber,
                        emp.AuthUid,
                        emp.Email
                    );
                }

                dgvStaff.DataSource = dt;
                if (dgvStaff.Columns.Contains("AuthUid"))
                {
                    dgvStaff.Columns["AuthUid"].Visible = false;
                }
                if (dgvStaff.Columns.Contains("Số điện thoại"))
                {
                    dgvStaff.Columns["Số điện thoại"].Visible = false;
                }
                if (dgvStaff.Columns.Contains("Email"))
                {
                    dgvStaff.Columns["Email"].Visible = false;
                }
                dgvStaff.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                // Tổng FillWeight thường là 100 (tương đương 100%), chia tỷ lệ cho các cột:
                dgvStaff.Columns["Mã NV"].FillWeight = 15;
                dgvStaff.Columns["Họ và Tên"].FillWeight = 40;
                dgvStaff.Columns["Vị Trí"].FillWeight = 25;
                dgvStaff.Columns["Trạng Thái"].FillWeight = 20;

                // Căn giữa cho các cột nhìn gọn gàng hơn
                dgvStaff.Columns["Mã NV"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvStaff.Columns["Vị Trí"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvStaff.Columns["Trạng Thái"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                var activeList = fullList.Where(emp => emp.Status == "active" && emp.Role != "admin").ToList();
                // Cập nhật label đếm số lượng nhân viên đang làm
                lblPresentValue.Text = $"{activeList.Count} người";
                dgvStaff.AllowUserToAddRows = false;

                // Tắt cái cột tiêu đề mũi tên ngoài cùng bên trái cho đỡ tốn chỗ
                dgvStaff.RowHeadersVisible = false;
                dgvStaff.ReadOnly = true;
            }
            catch (Exception ex)
            {
                MsgBox.Show(MsgBox.OwnerWindow(this), $"Lỗi tải dữ liệu: {ex.Message}", "Lỗi hệ thống", MsgBox.MessageBoxType.Error);
            }
            finally
            {
                // Trả con trỏ chuột về bình thường
                this.Cursor = Cursors.Default;
            }
        }

        private void BtnCheckIn_Click(object? sender, EventArgs e)
        {
            MsgBox.Show(MsgBox.OwnerWindow(this), "Tính năng Quét thẻ RFID / Vân tay / Nhập mã NV để điểm danh ca làm việc.", "Chấm Công", MsgBox.MessageBoxType.Info);
        }

        private void BtnApproveLeave_Click(object? sender, EventArgs e)
        {
            MsgBox.Show(MsgBox.OwnerWindow(this), "Đã DUYỆT đơn xin nghỉ của [NV03 Lê Văn C]. Dữ liệu đã cập nhật vào tính lương cuối tháng.", "Duyệt Nghỉ Phép", MsgBox.MessageBoxType.Success);
            lstLeaveq.Items.Clear();
            lstLeaveq.Items.Add("✔️ Không còn đơn xin nghỉ nào cần duyệt.");
            btnApproveLeave.Enabled = false;
        }

        private async void btnAddStaff_Click(object sender, EventArgs e)
        {
            AddEmployee frmAdd = new();
            // Mở form lên dưới dạng hộp thoại (người dùng phải đóng form này mới thao tác tiếp được với nền bên dưới)
            if (frmAdd.ShowDialog(MsgBox.OwnerWindow(this)) == DialogResult.OK)
            {
                // Đoạn code này sẽ chạy nếu bên form AddEmployee bạn lưu thành công 
                // và đã gán: this.DialogResult = DialogResult.OK;
                await LoadRealData();
                MsgBox.Show(MsgBox.OwnerWindow(this), "Danh sách nhân viên mới đã được cập nhật!", "Thông báo", MsgBox.MessageBoxType.Success);

                // Gọi hàm load lại dữ liệu lên DataGridView ở đây (nếu có)
                // Ví dụ: LoadStaffData();
            }
        }



        private void lblPresentValue_Click(object sender, EventArgs e)
        {

        }

        private void btnEditStaff_Click(object sender, EventArgs e)
        {
            // 1. Kiểm tra xem người dùng đã chọn dòng nào chưa
            if (dgvStaff.CurrentRow == null || dgvStaff.CurrentRow.Index < 0)
            {
                MsgBox.Show(MsgBox.OwnerWindow(this), "Vui lòng chọn một nhân viên từ danh sách để chỉnh sửa!", "Thông báo", MsgBox.MessageBoxType.Warning);
                return;
            }

            // 2. Lấy dữ liệu từ dòng đang chọn
            DataGridViewRow row = dgvStaff.CurrentRow;

            // 3. Tạo đối tượng DTO chứa dữ liệu
            EmployeeDTO empToEdit = new()
            {
                EmployeeId = row.Cells["Mã NV"].Value?.ToString(),
                FullName = row.Cells["Họ và Tên"].Value?.ToString(),
                Role = row.Cells["Vị Trí"].Value?.ToString(),
                Status = row.Cells["Trạng Thái"].Value?.ToString(),
                PhoneNumber = row.Cells["Số điện thoại"].Value?.ToString(),
                AuthUid = row.Cells["AuthUid"].Value?.ToString(),
                Email = row.Cells["Email"].Value?.ToString(),
            };

            // 4. Mở Form Edit
            EditEmployee frmEdit = new(empToEdit);
            if (frmEdit.ShowDialog(MsgBox.OwnerWindow(this)) == DialogResult.OK)
            {
                // Load lại danh sách nếu lưu thành công
                _ = LoadRealData();
            }
        }

        private async void dgvStaff_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dgvStaff.Rows[e.RowIndex];
            EmployeeDTO emp = new()
            {
                EmployeeId = row.Cells["Mã NV"].Value?.ToString(),
                FullName = row.Cells["Họ và Tên"].Value?.ToString(),
                Role = row.Cells["Vị Trí"].Value?.ToString(),
                Status = row.Cells["Trạng Thái"].Value?.ToString(),
                PhoneNumber = row.Cells["Số điện thoại"].Value?.ToString(),
                AuthUid = row.Cells["AuthUid"].Value?.ToString(),
                Email = row.Cells["Email"].Value?.ToString(),
            };

            using EmployeeDetail dlg = new(emp);
            if (dlg.ShowDialog(MsgBox.OwnerWindow(this)) == DialogResult.OK)
                await LoadRealData();
        }

        private void InitFilterControls()
        {
            // Nạp dữ liệu cho ComboBox Chức danh (Sử dụng ComboBox - sd cb box)
            cbRole.Items.Clear();
            cbRole.Items.AddRange(new string[] { "-- Vị trí --", "manager", "barista", "order staff", "security" });
            cbRole.SelectedIndex = 0;

            // Nạp dữ liệu cho ComboBox Trạng thái
            cbStatus.Items.Clear();
            cbStatus.Items.AddRange(new string[] { "-- Trạng thái --", "active", "inactive" });
            cbStatus.SelectedIndex = 0;

            // Gắn sự kiện Lọc Real-time (Gõ chữ hoặc Xổ ComboBox là lọc ngay lập tức)
            txtSearch.TextChanged += (s, e) => ApplyStaffFilter();
            cbRole.SelectedIndexChanged += (s, e) => ApplyStaffFilter();
            cbStatus.SelectedIndexChanged += (s, e) => ApplyStaffFilter();
        }

        private void ApplyStaffFilter()
        {
            DataTable? dt = dgvStaff.DataSource as DataTable;
            if (dt == null) return;

            List<string> filterParts = new();

            //TÌM THEO TÊN HOẶC MÃ NV  ---
            string keyword = txtSearch.Text.Trim().Replace("'", "''");
            if (!string.IsNullOrEmpty(keyword))
            {
                // LIKE trong RowFilter mặc định là KHÔNG phân biệt hoa/thường
                filterParts.Add($"([Họ và Tên] LIKE '%{keyword}%' OR [Mã NV] LIKE '%{keyword}%')");
            }

            // --- LỌC THEO VỊ TRÍ (ComboBox cbRole) ---
            if (cbRole.SelectedIndex > 0) // Lớn hơn 0 tức là đã chọn manager, staff... bỏ qua dòng "-- Vị trí --"
            {
                string role = cbRole.SelectedItem?.ToString() ?? string.Empty;
                filterParts.Add($"[Vị Trí] = '{role}'");
            }

            // --- LỌC THEO TRẠNG THÁI (ComboBox cbStatus) ---
            if (cbStatus.SelectedIndex > 0)
            {
                string status = cbStatus.SelectedItem?.ToString() ?? string.Empty;
                filterParts.Add($"[Trạng Thái] = '{status}'");
            }

            // GHÉP CÁC ĐIỀU KIỆN LẠI VỚI NHAU
            string finalFilter = string.Join(" AND ", filterParts);

            try
            {
                dt.DefaultView.RowFilter = finalFilter;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi áp dụng bộ lọc: " + ex.Message);
            }
        }

        private void btnClearFilter_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            cbRole.SelectedIndex = 0;
            cbStatus.SelectedIndex = 0;

            // 2. Hủy lệnh lọc, hiện lại Full danh sách
            if (dgvStaff.DataSource is DataTable dt)
            {
                dt.DefaultView.RowFilter = string.Empty;
            }
        }

    }
}