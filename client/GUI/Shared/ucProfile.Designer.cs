using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace GUI
{
    partial class ucProfile
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        // Controls khai báo ở Designer (VS thấy được); style/data set trong .cs.
        private void InitializeComponent()
        {
            pnlLeft        = new Guna2Panel();
            pnlAvatarRing  = new Guna2Panel();
            picAvatar      = new Guna2CirclePictureBox();
            lblUserName    = new Label();
            lblUserRole    = new Label();
            pnlDivider     = new Panel();
            lblJoinLabel   = new Label();
            lblJoinValue   = new Label();
            lblShiftLabel  = new Label();
            lblShiftValue  = new Label();
            btnChangeAvatar = new Guna2Button();

            pnlRight       = new Panel();
            pnlInfo        = new Guna2Panel();
            barInfo        = new Guna2Panel();
            lblInfoTitle   = new Label();
            lblEmployeeId  = new Label();
            txtEmployeeId  = new Guna2TextBox();
            lblFullName    = new Label();
            txtFullName    = new Guna2TextBox();
            lblEmail       = new Label();
            txtEmail       = new Guna2TextBox();
            lblPhone       = new Label();
            txtPhone       = new Guna2TextBox();
            lblAddress     = new Label();
            txtAddress     = new Guna2TextBox();
            btnUpdateInfo  = new Guna2Button();

            pnlSecurity    = new Guna2Panel();
            barSec         = new Guna2Panel();
            lblSecTitle    = new Label();
            lblOldPass     = new Label();
            txtOldPass     = new Guna2TextBox();
            lblNewPass     = new Label();
            txtNewPass     = new Guna2TextBox();
            lblConfirmPass = new Label();
            txtConfirmPass = new Guna2TextBox();
            btnChangePass  = new Guna2Button();

            pnlLeft.SuspendLayout();
            pnlAvatarRing.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picAvatar).BeginInit();
            pnlRight.SuspendLayout();
            pnlInfo.SuspendLayout();
            pnlSecurity.SuspendLayout();
            SuspendLayout();
            //
            // pnlLeft
            //
            pnlLeft.BackColor = Color.Transparent;
            pnlLeft.Controls.Add(pnlAvatarRing);
            pnlLeft.Controls.Add(lblUserName);
            pnlLeft.Controls.Add(lblUserRole);
            pnlLeft.Controls.Add(pnlDivider);
            pnlLeft.Controls.Add(lblJoinLabel);
            pnlLeft.Controls.Add(lblJoinValue);
            pnlLeft.Controls.Add(lblShiftLabel);
            pnlLeft.Controls.Add(lblShiftValue);
            pnlLeft.Controls.Add(btnChangeAvatar);
            pnlLeft.Dock = DockStyle.Left;
            pnlLeft.FillColor = Color.FromArgb(24, 24, 27);
            pnlLeft.Location = new Point(0, 0);
            pnlLeft.Name = "pnlLeft";
            pnlLeft.Size = new Size(260, 780);
            pnlLeft.TabIndex = 0;
            //
            // pnlAvatarRing
            //
            pnlAvatarRing.BackColor = Color.Transparent;
            pnlAvatarRing.BorderRadius = 80;
            pnlAvatarRing.Controls.Add(picAvatar);
            pnlAvatarRing.FillColor = Color.FromArgb(31, 138, 154);
            pnlAvatarRing.Location = new Point(50, 44);
            pnlAvatarRing.Name = "pnlAvatarRing";
            pnlAvatarRing.Size = new Size(160, 160);
            pnlAvatarRing.TabIndex = 0;
            //
            // picAvatar
            //
            picAvatar.BackColor = Color.Transparent;
            picAvatar.FillColor = Color.FromArgb(45, 45, 50);
            picAvatar.ImageRotate = 0F;
            picAvatar.Location = new Point(5, 5);
            picAvatar.Name = "picAvatar";
            picAvatar.Size = new Size(150, 150);
            picAvatar.SizeMode = PictureBoxSizeMode.Zoom;
            picAvatar.TabIndex = 0;
            picAvatar.TabStop = false;
            //
            // lblUserName
            //
            lblUserName.BackColor = Color.Transparent;
            lblUserName.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblUserName.ForeColor = Color.FromArgb(240, 240, 245);
            lblUserName.Location = new Point(10, 222);
            lblUserName.Name = "lblUserName";
            lblUserName.Size = new Size(240, 30);
            lblUserName.TabIndex = 1;
            lblUserName.Text = "NGUYỄN VĂN AN";
            lblUserName.TextAlign = ContentAlignment.MiddleCenter;
            //
            // lblUserRole
            //
            lblUserRole.BackColor = Color.Transparent;
            lblUserRole.Font = new Font("Segoe UI", 9.5F);
            lblUserRole.ForeColor = Color.FromArgb(31, 138, 154);
            lblUserRole.Location = new Point(10, 254);
            lblUserRole.Name = "lblUserRole";
            lblUserRole.Size = new Size(240, 20);
            lblUserRole.TabIndex = 2;
            lblUserRole.Text = "Barista / Staff";
            lblUserRole.TextAlign = ContentAlignment.MiddleCenter;
            //
            // pnlDivider
            //
            pnlDivider.BackColor = Color.FromArgb(50, 50, 56);
            pnlDivider.Location = new Point(30, 296);
            pnlDivider.Name = "pnlDivider";
            pnlDivider.Size = new Size(200, 1);
            pnlDivider.TabIndex = 3;
            //
            // lblJoinLabel
            //
            lblJoinLabel.AutoSize = true;
            lblJoinLabel.BackColor = Color.Transparent;
            lblJoinLabel.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            lblJoinLabel.ForeColor = Color.FromArgb(110, 110, 120);
            lblJoinLabel.Location = new Point(30, 320);
            lblJoinLabel.Name = "lblJoinLabel";
            lblJoinLabel.Size = new Size(90, 13);
            lblJoinLabel.TabIndex = 4;
            lblJoinLabel.Text = "NGÀY VÀO LÀM";
            //
            // lblJoinValue
            //
            lblJoinValue.AutoSize = true;
            lblJoinValue.BackColor = Color.Transparent;
            lblJoinValue.Font = new Font("Segoe UI", 11F);
            lblJoinValue.ForeColor = Color.FromArgb(220, 220, 225);
            lblJoinValue.Location = new Point(30, 338);
            lblJoinValue.Name = "lblJoinValue";
            lblJoinValue.Size = new Size(70, 20);
            lblJoinValue.TabIndex = 5;
            lblJoinValue.Text = "--/--/----";
            //
            // lblShiftLabel
            //
            lblShiftLabel.AutoSize = true;
            lblShiftLabel.BackColor = Color.Transparent;
            lblShiftLabel.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            lblShiftLabel.ForeColor = Color.FromArgb(110, 110, 120);
            lblShiftLabel.Location = new Point(30, 380);
            lblShiftLabel.Name = "lblShiftLabel";
            lblShiftLabel.Size = new Size(82, 13);
            lblShiftLabel.TabIndex = 6;
            lblShiftLabel.Text = "CA LÀM VIỆC";
            //
            // lblShiftValue
            //
            lblShiftValue.AutoSize = true;
            lblShiftValue.BackColor = Color.Transparent;
            lblShiftValue.Font = new Font("Segoe UI", 11F);
            lblShiftValue.ForeColor = Color.FromArgb(220, 220, 225);
            lblShiftValue.Location = new Point(30, 398);
            lblShiftValue.Name = "lblShiftValue";
            lblShiftValue.Size = new Size(60, 20);
            lblShiftValue.TabIndex = 7;
            lblShiftValue.Text = "Ca sáng";
            //
            // btnChangeAvatar
            //
            btnChangeAvatar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnChangeAvatar.BorderRadius = 10;
            btnChangeAvatar.Cursor = Cursors.Hand;
            btnChangeAvatar.FillColor = Color.FromArgb(31, 138, 154);
            btnChangeAvatar.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnChangeAvatar.ForeColor = Color.White;
            btnChangeAvatar.HoverState.FillColor = Color.FromArgb(45, 158, 174);
            btnChangeAvatar.Location = new Point(30, 614);
            btnChangeAvatar.Name = "btnChangeAvatar";
            btnChangeAvatar.Size = new Size(200, 42);
            btnChangeAvatar.TabIndex = 8;
            btnChangeAvatar.Text = "Đổi ảnh đại diện";
            //
            // pnlRight
            //
            pnlRight.BackColor = Color.FromArgb(39, 39, 42);
            pnlRight.Controls.Add(pnlInfo);
            pnlRight.Controls.Add(pnlSecurity);
            pnlRight.Dock = DockStyle.Fill;
            pnlRight.Location = new Point(260, 0);
            pnlRight.Name = "pnlRight";
            pnlRight.Size = new Size(740, 780);
            pnlRight.TabIndex = 1;
            //
            // pnlInfo
            //
            pnlInfo.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlInfo.BackColor = Color.Transparent;
            pnlInfo.BorderRadius = 14;
            pnlInfo.Controls.Add(barInfo);
            pnlInfo.Controls.Add(lblInfoTitle);
            pnlInfo.Controls.Add(lblEmployeeId);
            pnlInfo.Controls.Add(txtEmployeeId);
            pnlInfo.Controls.Add(lblFullName);
            pnlInfo.Controls.Add(txtFullName);
            pnlInfo.Controls.Add(lblEmail);
            pnlInfo.Controls.Add(txtEmail);
            pnlInfo.Controls.Add(lblPhone);
            pnlInfo.Controls.Add(txtPhone);
            pnlInfo.Controls.Add(lblAddress);
            pnlInfo.Controls.Add(txtAddress);
            pnlInfo.Controls.Add(btnUpdateInfo);
            pnlInfo.FillColor = Color.FromArgb(31, 31, 34);
            pnlInfo.Location = new Point(24, 20);
            pnlInfo.Name = "pnlInfo";
            pnlInfo.Size = new Size(692, 348);
            pnlInfo.TabIndex = 0;
            //
            // barInfo
            //
            barInfo.BackColor = Color.Transparent;
            barInfo.BorderRadius = 2;
            barInfo.FillColor = Color.FromArgb(31, 138, 154);
            barInfo.Location = new Point(20, 20);
            barInfo.Name = "barInfo";
            barInfo.Size = new Size(4, 22);
            barInfo.TabIndex = 0;
            //
            // lblInfoTitle
            //
            lblInfoTitle.AutoSize = true;
            lblInfoTitle.BackColor = Color.Transparent;
            lblInfoTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblInfoTitle.ForeColor = Color.FromArgb(240, 240, 245);
            lblInfoTitle.Location = new Point(34, 19);
            lblInfoTitle.Name = "lblInfoTitle";
            lblInfoTitle.Size = new Size(133, 20);
            lblInfoTitle.TabIndex = 1;
            lblInfoTitle.Text = "Thông tin cá nhân";
            //
            // lblEmployeeId
            //
            lblEmployeeId.AutoSize = true;
            lblEmployeeId.BackColor = Color.Transparent;
            lblEmployeeId.Font = new Font("Segoe UI", 9.5F);
            lblEmployeeId.ForeColor = Color.FromArgb(160, 160, 166);
            lblEmployeeId.Location = new Point(24, 68);
            lblEmployeeId.Name = "lblEmployeeId";
            lblEmployeeId.Size = new Size(82, 17);
            lblEmployeeId.TabIndex = 2;
            lblEmployeeId.Text = "Mã nhân viên";
            //
            // txtEmployeeId
            //
            txtEmployeeId.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtEmployeeId.BorderColor = Color.FromArgb(55, 55, 60);
            txtEmployeeId.BorderRadius = 8;
            txtEmployeeId.Enabled = false;
            txtEmployeeId.FillColor = Color.FromArgb(38, 38, 42);
            txtEmployeeId.Font = new Font("Segoe UI", 10F);
            txtEmployeeId.ForeColor = Color.FromArgb(160, 160, 166);
            txtEmployeeId.Location = new Point(170, 58);
            txtEmployeeId.Name = "txtEmployeeId";
            txtEmployeeId.PlaceholderText = "";
            txtEmployeeId.Size = new Size(498, 36);
            txtEmployeeId.TabIndex = 0;
            //
            // lblFullName
            //
            lblFullName.AutoSize = true;
            lblFullName.BackColor = Color.Transparent;
            lblFullName.Font = new Font("Segoe UI", 9.5F);
            lblFullName.ForeColor = Color.FromArgb(160, 160, 166);
            lblFullName.Location = new Point(24, 114);
            lblFullName.Name = "lblFullName";
            lblFullName.Size = new Size(63, 17);
            lblFullName.TabIndex = 3;
            lblFullName.Text = "Họ và tên";
            //
            // txtFullName
            //
            txtFullName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtFullName.BorderColor = Color.FromArgb(60, 60, 66);
            txtFullName.BorderRadius = 8;
            txtFullName.FillColor = Color.FromArgb(45, 45, 50);
            txtFullName.FocusedState.BorderColor = Color.FromArgb(31, 138, 154);
            txtFullName.Font = new Font("Segoe UI", 10F);
            txtFullName.ForeColor = Color.White;
            txtFullName.Location = new Point(170, 104);
            txtFullName.Name = "txtFullName";
            txtFullName.PlaceholderForeColor = Color.FromArgb(90, 90, 98);
            txtFullName.PlaceholderText = "Nhập họ và tên...";
            txtFullName.Size = new Size(498, 36);
            txtFullName.TabIndex = 1;
            //
            // lblEmail
            //
            lblEmail.AutoSize = true;
            lblEmail.BackColor = Color.Transparent;
            lblEmail.Font = new Font("Segoe UI", 9.5F);
            lblEmail.ForeColor = Color.FromArgb(160, 160, 166);
            lblEmail.Location = new Point(24, 160);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(39, 17);
            lblEmail.TabIndex = 5;
            lblEmail.Text = "Email";
            //
            // txtEmail
            //
            txtEmail.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtEmail.BorderColor = Color.FromArgb(55, 55, 60);
            txtEmail.BorderRadius = 8;
            txtEmail.Enabled = false;
            txtEmail.FillColor = Color.FromArgb(38, 38, 42);
            txtEmail.Font = new Font("Segoe UI", 10F);
            txtEmail.ForeColor = Color.FromArgb(160, 160, 166);
            txtEmail.Location = new Point(170, 150);
            txtEmail.Name = "txtEmail";
            txtEmail.PlaceholderText = "";
            txtEmail.Size = new Size(498, 36);
            txtEmail.TabIndex = 2;
            //
            // lblPhone
            //
            lblPhone.AutoSize = true;
            lblPhone.BackColor = Color.Transparent;
            lblPhone.Font = new Font("Segoe UI", 9.5F);
            lblPhone.ForeColor = Color.FromArgb(160, 160, 166);
            lblPhone.Location = new Point(24, 206);
            lblPhone.Name = "lblPhone";
            lblPhone.Size = new Size(82, 17);
            lblPhone.TabIndex = 7;
            lblPhone.Text = "Số điện thoại";
            //
            // txtPhone
            //
            txtPhone.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtPhone.BorderColor = Color.FromArgb(60, 60, 66);
            txtPhone.BorderRadius = 8;
            txtPhone.FillColor = Color.FromArgb(45, 45, 50);
            txtPhone.FocusedState.BorderColor = Color.FromArgb(31, 138, 154);
            txtPhone.Font = new Font("Segoe UI", 10F);
            txtPhone.ForeColor = Color.White;
            txtPhone.Location = new Point(170, 196);
            txtPhone.Name = "txtPhone";
            txtPhone.PlaceholderForeColor = Color.FromArgb(90, 90, 98);
            txtPhone.PlaceholderText = "Nhập số điện thoại...";
            txtPhone.Size = new Size(498, 36);
            txtPhone.TabIndex = 3;
            //
            // lblAddress
            //
            lblAddress.AutoSize = true;
            lblAddress.BackColor = Color.Transparent;
            lblAddress.Font = new Font("Segoe UI", 9.5F);
            lblAddress.ForeColor = Color.FromArgb(160, 160, 166);
            lblAddress.Location = new Point(24, 252);
            lblAddress.Name = "lblAddress";
            lblAddress.Size = new Size(48, 17);
            lblAddress.TabIndex = 9;
            lblAddress.Text = "Địa chỉ";
            //
            // txtAddress
            //
            txtAddress.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtAddress.BorderColor = Color.FromArgb(60, 60, 66);
            txtAddress.BorderRadius = 8;
            txtAddress.FillColor = Color.FromArgb(45, 45, 50);
            txtAddress.FocusedState.BorderColor = Color.FromArgb(31, 138, 154);
            txtAddress.Font = new Font("Segoe UI", 10F);
            txtAddress.ForeColor = Color.White;
            txtAddress.Location = new Point(170, 242);
            txtAddress.Name = "txtAddress";
            txtAddress.PlaceholderForeColor = Color.FromArgb(90, 90, 98);
            txtAddress.PlaceholderText = "Nhập địa chỉ...";
            txtAddress.Size = new Size(498, 36);
            txtAddress.TabIndex = 4;
            //
            // btnUpdateInfo
            //
            btnUpdateInfo.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnUpdateInfo.BorderRadius = 8;
            btnUpdateInfo.Cursor = Cursors.Hand;
            btnUpdateInfo.FillColor = Color.FromArgb(22, 163, 74);
            btnUpdateInfo.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnUpdateInfo.ForeColor = Color.White;
            btnUpdateInfo.HoverState.FillColor = Color.FromArgb(34, 197, 94);
            btnUpdateInfo.Location = new Point(508, 296);
            btnUpdateInfo.Name = "btnUpdateInfo";
            btnUpdateInfo.Size = new Size(160, 38);
            btnUpdateInfo.TabIndex = 5;
            btnUpdateInfo.Text = "Lưu thay đổi";
            //
            // pnlSecurity
            //
            pnlSecurity.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlSecurity.BackColor = Color.Transparent;
            pnlSecurity.BorderRadius = 14;
            pnlSecurity.Controls.Add(barSec);
            pnlSecurity.Controls.Add(lblSecTitle);
            pnlSecurity.Controls.Add(lblOldPass);
            pnlSecurity.Controls.Add(txtOldPass);
            pnlSecurity.Controls.Add(lblNewPass);
            pnlSecurity.Controls.Add(txtNewPass);
            pnlSecurity.Controls.Add(lblConfirmPass);
            pnlSecurity.Controls.Add(txtConfirmPass);
            pnlSecurity.Controls.Add(btnChangePass);
            pnlSecurity.FillColor = Color.FromArgb(31, 31, 34);
            pnlSecurity.Location = new Point(24, 388);
            pnlSecurity.Name = "pnlSecurity";
            pnlSecurity.Size = new Size(692, 256);
            pnlSecurity.TabIndex = 1;
            //
            // barSec
            //
            barSec.BackColor = Color.Transparent;
            barSec.BorderRadius = 2;
            barSec.FillColor = Color.FromArgb(220, 80, 80);
            barSec.Location = new Point(20, 20);
            barSec.Name = "barSec";
            barSec.Size = new Size(4, 22);
            barSec.TabIndex = 0;
            //
            // lblSecTitle
            //
            lblSecTitle.AutoSize = true;
            lblSecTitle.BackColor = Color.Transparent;
            lblSecTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblSecTitle.ForeColor = Color.FromArgb(220, 80, 80);
            lblSecTitle.Location = new Point(34, 19);
            lblSecTitle.Name = "lblSecTitle";
            lblSecTitle.Size = new Size(104, 20);
            lblSecTitle.TabIndex = 1;
            lblSecTitle.Text = "Đổi mật khẩu";
            //
            // lblOldPass
            //
            lblOldPass.AutoSize = true;
            lblOldPass.BackColor = Color.Transparent;
            lblOldPass.Font = new Font("Segoe UI", 9.5F);
            lblOldPass.ForeColor = Color.FromArgb(160, 160, 166);
            lblOldPass.Location = new Point(24, 68);
            lblOldPass.Name = "lblOldPass";
            lblOldPass.Size = new Size(78, 17);
            lblOldPass.TabIndex = 2;
            lblOldPass.Text = "Mật khẩu cũ";
            //
            // txtOldPass
            //
            txtOldPass.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtOldPass.BorderColor = Color.FromArgb(60, 60, 66);
            txtOldPass.BorderRadius = 8;
            txtOldPass.FillColor = Color.FromArgb(45, 45, 50);
            txtOldPass.FocusedState.BorderColor = Color.FromArgb(220, 80, 80);
            txtOldPass.Font = new Font("Segoe UI", 10F);
            txtOldPass.ForeColor = Color.White;
            txtOldPass.Location = new Point(170, 58);
            txtOldPass.Name = "txtOldPass";
            txtOldPass.PasswordChar = '●';
            txtOldPass.PlaceholderForeColor = Color.FromArgb(90, 90, 98);
            txtOldPass.PlaceholderText = "Nhập mật khẩu hiện tại...";
            txtOldPass.Size = new Size(498, 36);
            txtOldPass.TabIndex = 0;
            //
            // lblNewPass
            //
            lblNewPass.AutoSize = true;
            lblNewPass.BackColor = Color.Transparent;
            lblNewPass.Font = new Font("Segoe UI", 9.5F);
            lblNewPass.ForeColor = Color.FromArgb(160, 160, 166);
            lblNewPass.Location = new Point(24, 114);
            lblNewPass.Name = "lblNewPass";
            lblNewPass.Size = new Size(86, 17);
            lblNewPass.TabIndex = 3;
            lblNewPass.Text = "Mật khẩu mới";
            //
            // txtNewPass
            //
            txtNewPass.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtNewPass.BorderColor = Color.FromArgb(60, 60, 66);
            txtNewPass.BorderRadius = 8;
            txtNewPass.FillColor = Color.FromArgb(45, 45, 50);
            txtNewPass.FocusedState.BorderColor = Color.FromArgb(220, 80, 80);
            txtNewPass.Font = new Font("Segoe UI", 10F);
            txtNewPass.ForeColor = Color.White;
            txtNewPass.Location = new Point(170, 104);
            txtNewPass.Name = "txtNewPass";
            txtNewPass.PasswordChar = '●';
            txtNewPass.PlaceholderForeColor = Color.FromArgb(90, 90, 98);
            txtNewPass.PlaceholderText = "Tối thiểu 6 ký tự...";
            txtNewPass.Size = new Size(498, 36);
            txtNewPass.TabIndex = 1;
            //
            // lblConfirmPass
            //
            lblConfirmPass.AutoSize = true;
            lblConfirmPass.BackColor = Color.Transparent;
            lblConfirmPass.Font = new Font("Segoe UI", 9.5F);
            lblConfirmPass.ForeColor = Color.FromArgb(160, 160, 166);
            lblConfirmPass.Location = new Point(24, 160);
            lblConfirmPass.Name = "lblConfirmPass";
            lblConfirmPass.Size = new Size(116, 17);
            lblConfirmPass.TabIndex = 5;
            lblConfirmPass.Text = "Xác nhận mật khẩu";
            //
            // txtConfirmPass
            //
            txtConfirmPass.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtConfirmPass.BorderColor = Color.FromArgb(60, 60, 66);
            txtConfirmPass.BorderRadius = 8;
            txtConfirmPass.FillColor = Color.FromArgb(45, 45, 50);
            txtConfirmPass.FocusedState.BorderColor = Color.FromArgb(220, 80, 80);
            txtConfirmPass.Font = new Font("Segoe UI", 10F);
            txtConfirmPass.ForeColor = Color.White;
            txtConfirmPass.Location = new Point(170, 150);
            txtConfirmPass.Name = "txtConfirmPass";
            txtConfirmPass.PasswordChar = '●';
            txtConfirmPass.PlaceholderForeColor = Color.FromArgb(90, 90, 98);
            txtConfirmPass.PlaceholderText = "Nhập lại mật khẩu mới...";
            txtConfirmPass.Size = new Size(498, 36);
            txtConfirmPass.TabIndex = 2;
            //
            // btnChangePass
            //
            btnChangePass.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnChangePass.BorderRadius = 8;
            btnChangePass.Cursor = Cursors.Hand;
            btnChangePass.FillColor = Color.FromArgb(180, 50, 50);
            btnChangePass.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnChangePass.ForeColor = Color.White;
            btnChangePass.HoverState.FillColor = Color.FromArgb(210, 70, 70);
            btnChangePass.Location = new Point(508, 204);
            btnChangePass.Name = "btnChangePass";
            btnChangePass.Size = new Size(160, 38);
            btnChangePass.TabIndex = 3;
            btnChangePass.Text = "Đổi mật khẩu";
            //
            // ucProfile
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(39, 39, 42);
            Controls.Add(pnlRight);
            Controls.Add(pnlLeft);
            Name = "ucProfile";
            // Chừa ~120px dưới pnlSecurity để ResponsiveLayout coi nó là thẻ GIỮA
            // (không kéo giãn xuống đáy như pnlInfo). Nhờ vậy nút "Đổi mật khẩu" giữ
            // đúng khoảng cách với mép dưới panel — giống nút "Lưu thay đổi".
            Size = new Size(1000, 780);
            this.Load += UcProfile_Load;
            btnUpdateInfo.Click += BtnUpdateInfo_Click;
            btnChangePass.Click += BtnChangePass_Click;
            btnChangeAvatar.Click += BtnChangeAvatar_Click;
            pnlLeft.ResumeLayout(false);
            pnlLeft.PerformLayout();
            pnlAvatarRing.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picAvatar).EndInit();
            pnlRight.ResumeLayout(false);
            pnlInfo.ResumeLayout(false);
            pnlInfo.PerformLayout();
            pnlSecurity.ResumeLayout(false);
            pnlSecurity.PerformLayout();
            ResumeLayout(false);
        }

        private Guna2Panel           pnlLeft;
        private Guna2Panel           pnlAvatarRing;
        private Guna2CirclePictureBox picAvatar;
        private Label                lblUserName;
        private Label                lblUserRole;
        private Panel                pnlDivider;
        private Label                lblJoinLabel;
        private Label                lblJoinValue;
        private Label                lblShiftLabel;
        private Label                lblShiftValue;
        private Guna2Button          btnChangeAvatar;

        private Panel                pnlRight;
        private Guna2Panel           pnlInfo;
        private Guna2Panel           barInfo;
        private Label                lblInfoTitle;
        private Label                lblEmployeeId;
        private Guna2TextBox         txtEmployeeId;
        private Label                lblFullName;
        private Guna2TextBox         txtFullName;
        private Label                lblEmail;
        private Guna2TextBox         txtEmail;
        private Label                lblPhone;
        private Guna2TextBox         txtPhone;
        private Label                lblAddress;
        private Guna2TextBox         txtAddress;
        private Guna2Button          btnUpdateInfo;

        private Guna2Panel           pnlSecurity;
        private Guna2Panel           barSec;
        private Label                lblSecTitle;
        private Label                lblOldPass;
        private Guna2TextBox         txtOldPass;
        private Label                lblNewPass;
        private Guna2TextBox         txtNewPass;
        private Label                lblConfirmPass;
        private Guna2TextBox         txtConfirmPass;
        private Guna2Button          btnChangePass;
    }
}
