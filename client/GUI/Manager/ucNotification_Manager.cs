using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace GUI
{
    public partial class ucNotification_Manager : UserControl
    {
        public ucNotification_Manager()
        {
            InitializeComponent();
            this.Load += (s, e) => LoadMockData();
        }

        private void LoadMockData()
        {
            // Pending leave requests
            DataTable dtLeave = new();
            dtLeave.Columns.Add("Nhân viên");
            dtLeave.Columns.Add("Chức vụ");
            dtLeave.Columns.Add("Ngày nghỉ");
            dtLeave.Columns.Add("Lý do");
            dtLeave.Columns.Add("Trạng thái");

            dtLeave.Rows.Add("Trần Thị Bích", "Pha chế", "05/05/2026", "Việc gia đình", "Chờ duyệt");
            dtLeave.Rows.Add("Lê Hoàng Nam", "Order Staff", "06/05/2026 - 07/05/2026", "Khám bệnh", "Chờ duyệt");
            dtLeave.Rows.Add("Đỗ Thị Hương", "Pha chế", "08/05/2026", "Việc cá nhân", "Chờ duyệt");

            dgvPendingLeave.DataSource = dtLeave;
            dgvPendingLeave.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPendingLeave.RowHeadersVisible = false;
            dgvPendingLeave.ReadOnly = true;
            dgvPendingLeave.AllowUserToAddRows = false;
            dgvPendingLeave.Columns["Lý do"].FillWeight = 30;

            // Schedule grid
            DataTable dtSchedule = new();
            dtSchedule.Columns.Add("Nhân viên");
            dtSchedule.Columns.Add("T2");
            dtSchedule.Columns.Add("T3");
            dtSchedule.Columns.Add("T4");
            dtSchedule.Columns.Add("T5");
            dtSchedule.Columns.Add("T6");
            dtSchedule.Columns.Add("T7");
            dtSchedule.Columns.Add("CN");

            dtSchedule.Rows.Add("Trần Thị Bích", "S", "S", "C", "C", "S", "OFF", "OFF");
            dtSchedule.Rows.Add("Lê Hoàng Nam", "S", "C", "S", "C", "S", "S", "OFF");
            dtSchedule.Rows.Add("Phạm Minh Tuấn", "C", "C", "S", "S", "C", "OFF", "S");
            dtSchedule.Rows.Add("Đỗ Thị Hương", "S", "S", "S", "OFF", "C", "C", "OFF");
            dtSchedule.Rows.Add("Hoàng Thị Mai", "C", "S", "C", "S", "S", "OFF", "OFF");

            dgvSchedule.DataSource = dtSchedule;
            dgvSchedule.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSchedule.RowHeadersVisible = false;
            dgvSchedule.AllowUserToAddRows = false;
            dgvSchedule.Columns["Nhân viên"].FillWeight = 25;
            dgvSchedule.Columns["Nhân viên"].ReadOnly = true;

            // Color schedule cells
            foreach (DataGridViewRow row in dgvSchedule.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell.ColumnIndex == 0) continue;
                    string val = cell.Value?.ToString() ?? "";
                    if (val == "S") cell.Style.ForeColor = Color.MediumSeaGreen;
                    else if (val == "C") cell.Style.ForeColor = Color.SteelBlue;
                    else if (val == "OFF") cell.Style.ForeColor = Color.IndianRed;
                }
            }
        }

        private void btnApprove_Click(object sender, EventArgs e)
        {
            if (dgvPendingLeave.CurrentRow == null) return;
            string name = dgvPendingLeave.CurrentRow.Cells["Nhân viên"].Value?.ToString() ?? "";
            dgvPendingLeave.CurrentRow.Cells["Trạng thái"].Value = "Đã duyệt";
            dgvPendingLeave.CurrentRow.DefaultCellStyle.ForeColor = Color.MediumSeaGreen;
            MsgBox.Show($"Đã duyệt đơn nghỉ phép của {name}!", "Thành công", MsgBox.MessageBoxType.Success);
        }

        private void btnReject_Click(object sender, EventArgs e)
        {
            if (dgvPendingLeave.CurrentRow == null) return;
            string name = dgvPendingLeave.CurrentRow.Cells["Nhân viên"].Value?.ToString() ?? "";
            dgvPendingLeave.CurrentRow.Cells["Trạng thái"].Value = "Từ chối";
            dgvPendingLeave.CurrentRow.DefaultCellStyle.ForeColor = Color.IndianRed;
            MsgBox.Show($"Đã từ chối đơn nghỉ phép của {name}!", "Thông báo", MsgBox.MessageBoxType.Warning);
        }

        private void btnChatStaff_Click(object sender, EventArgs e)
        {
            if (dgvPendingLeave.CurrentRow == null) return;
            string name = dgvPendingLeave.CurrentRow.Cells["Nhân viên"].Value?.ToString() ?? "";
            MsgBox.Show($"Mở chat với {name}...", "Chat", MsgBox.MessageBoxType.Success);
        }

        private void btnSaveSchedule_Click(object sender, EventArgs e)
        {
            MsgBox.Show("Đã lưu lịch làm việc thành công!", "Thành công", MsgBox.MessageBoxType.Success);
        }

        private void dgvPendingLeave_SelectionChanged(object sender, EventArgs e)
        {
        }

        private void dgvSchedule_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
        }
    }
}
