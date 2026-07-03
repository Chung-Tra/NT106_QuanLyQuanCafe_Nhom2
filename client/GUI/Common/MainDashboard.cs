using DTO;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace GUI
{
    public partial class MainDashboard : Form
    {
        private readonly BaseDashboard _dashboardManager;
        private readonly List<Guna2Button> _menuButtons = new();

        // Cache UC theo menu: mỗi màn hình chỉ dựng 1 lần (lần đầu bấm), các lần sau
        // hiện lại ngay lập tức — trước đây mỗi click dựng lại toàn bộ UC (chậm) và
        // UC cũ bị gỡ ra nhưng không dispose (rò rỉ handle).
        private readonly Dictionary<MenuItemConfig, UserControl> _ucCache = new();

        // Màu sắc sidebar
        private static readonly Color SidebarBg = Color.FromArgb(31, 31, 34);
        private static readonly Color MenuFg = Color.FromArgb(200, 200, 205);
        private static readonly Color MenuHoverBg = Color.FromArgb(45, 45, 50);
        private static readonly Color MenuActiveBg = Color.FromArgb(31, 138, 154);
        private static readonly Color MenuActiveFg = Color.White;
        private static readonly Color GroupLabelFg = Color.FromArgb(120, 120, 125);

        // Cấu hình menu theo vai trò
        private record MenuItemConfig(string Group, string ButtonText, string TitleText, Func<UserControl> CreateUC);

        private static readonly Dictionary<string, List<MenuItemConfig>> RoleMenus = new()
        {
            ["admin"] = new()
            {
                new("CHÍNH",      "  Tổng quan",          "Tổng quan",                () => new ucDashboard_Admin()),
                new("CHÍNH",      "  Quản lý",            "Danh sách Quản lý",        () => new ucManagers_Admin()),
                new("CHÍNH",      "  Nhân viên",          "Danh sách Nhân viên",      () => new ucStaff_Manager()),
                new("CHÍNH",      "  Tiền lương",         "Tiền lương tự động",       () => new ucPayroll_Admin()),
                new("CHÍNH",      "  Tiền chi",           "Tiền chi chi tiết",        () => new ucExpenses_Admin()),
                new("CHÍNH",      "  Xuất báo cáo",       "Xuất báo cáo Excel / PDF", () => new ucReport_Admin()),
                new("KHÁCH HÀNG", "  Feedback",           "Kiểm soát Feedback",       () => new ucFeedback_Admin()),
                new("KHÁCH HÀNG", "  Thông báo",          "Trung tâm Thông báo",      () => new ucNotification_Admin()),
                new("KHÁCH HÀNG", "  Gửi thông báo",      "Gửi thông báo nội bộ",     () => new ucBroadcastCenter()),
                new("CÁ NHÂN",    "  Điểm danh",          "Điểm danh nhân viên",      () => new ucAttendanceHistory()),
                new("CÁ NHÂN",    "  Nhật ký",            "Nhật ký hệ thống",         () => new ucAuditLog()),
                new("CÁ NHÂN",    "  Chat nội bộ",        "Chat nội bộ",              () => new ucInternalChat()),
                new("CÁ NHÂN",    "  Hồ sơ cá nhân",      "Hồ sơ cá nhân",            () => new ucProfile()),
            },
            ["manager"] = new()
            {
                new("CHÍNH",      "  Tổng quan",          "Tổng quan ca làm",         () => new ucOverview_Manager()),
                new("CHÍNH",      "  Sản phẩm & Thực đơn","Sản phẩm & Thực đơn",      () => new ucProducts_Manager()),
                new("CHÍNH",      "  Đơn hàng & Hóa đơn", "Đơn hàng & Hóa đơn",       () => new ucOrders_Manager()),
                new("CHÍNH",      "  Nhân viên",          "Danh sách Nhân viên",      () => new ucStaff_Manager()),
                new("CHÍNH",      "  Lịch ca làm",        "Lịch ca làm theo tuần",    () => new ucSchedule_Manager()),
                new("CHÍNH",      "  Khuyến mãi",         "Khuyến mãi & Voucher",     () => new ucPromotion_Manager()),
                new("CHÍNH",      "  Thất thoát",         "Thất thoát & Hao phí",     () => new ucLoss_Manager()),
                new("KHÁCH HÀNG", "  Feedback",           "Feedback Khách hàng",      () => new ucFeedback_Manager()),
                new("KHÁCH HÀNG", "  Thông báo",          "Xử lý Thông báo",          () => new ucNotification_Manager()),
                new("KHÁCH HÀNG", "  Gửi thông báo",      "Gửi thông báo nội bộ",     () => new ucBroadcastCenter()),
                new("CÁ NHÂN",    "  Xin nghỉ",           "Duyệt đơn xin nghỉ",       () => new ucLeaveRequest()),
                new("CÁ NHÂN",    "  Điểm danh",          "Điểm danh nhân viên",      () => new ucWorkTracking()),
                new("CÁ NHÂN",    "  Nhật ký",            "Nhật ký hệ thống",         () => new ucAuditLog()),
                new("CÁ NHÂN",    "  Chat nội bộ",        "Chat nội bộ",              () => new ucInternalChat()),
                new("CÁ NHÂN",    "  Hồ sơ cá nhân",      "Hồ sơ cá nhân",            () => new ucProfile()),
            },
            ["order staff"] = new()
            {
                new("CHÍNH",      "  Tổng quan",          "Tổng quan cá nhân",        () => new ucOverview_Staff()),
                new("CHÍNH",      "  Lên đơn / POS",      "Lên đơn / POS",            () => new ucPOS_Order()),
                new("CHÍNH",      "  Khách hàng (CRM)",   "Khách hàng (CRM)",         () => new ucCRM_Order()),
                new("CHÍNH",      "  Tích điểm",          "Tích điểm & Hạng thành viên",() => new ucLoyalty_Order()),
                new("CHÍNH",      "  Đặt bàn",            "Quản lý Đặt bàn trước",    () => new ucReservation_Order()),
                new("CHÍNH",      "  Đặt tại bàn QR",    "Đặt tại bàn QR & Đơn realtime", () => new ucSelfOrder_Order()),
                new("CHÍNH",      "  Tiền mặt",           "Quản lý Tiền mặt",         () => new ucCashManagement_Order()),
                new("CÁ NHÂN",    "  Lịch sử chấm công",  "Lịch sử chấm công & Báo cáo", () => new ucAttendanceHistory()),
                new("CÁ NHÂN",    "  Xin nghỉ",           "Đơn xin nghỉ phép",        () => new ucLeaveRequest()),
                new("CÁ NHÂN",    "  Chọn ca / Đổi ca",   "Chọn ca & Đổi ca",         () => new ucShiftRegister()),
                new("CÁ NHÂN",    "  Chat nội bộ",        "Chat nội bộ",              () => new ucInternalChat()),
                new("CÁ NHÂN",    "  Hồ sơ cá nhân",      "Hồ sơ cá nhân",            () => new ucProfile()),
            },
            ["barista"] = new()
            {
                new("CHÍNH",      "  Tổng quan",          "Tổng quan cá nhân",      () => new ucOverview_Staff()),
                new("CHÍNH",      "  Màn hình Bếp",       "Màn hình Bếp realtime",  () => new ucKDS_Barista()),
                new("CHÍNH",      "  Công thức pha chế",  "Công thức pha chế",      () => new ucRecipe_Barista()),
                new("CHÍNH",      "  Cảnh báo NL",        "Cảnh báo NL sắp hết",    () => new ucAlert_Barista()),
                new("CÁ NHÂN",    "  Lịch sử chấm công",  "Lịch sử chấm công & Báo cáo", () => new ucAttendanceHistory()),
                new("CÁ NHÂN",    "  Xin nghỉ",           "Đơn xin nghỉ phép",      () => new ucLeaveRequest()),
                new("CÁ NHÂN",    "  Chọn ca / Đổi ca",   "Chọn ca & Đổi ca",       () => new ucShiftRegister()),
                new("CÁ NHÂN",    "  Chat nội bộ",        "Chat nội bộ",            () => new ucInternalChat()),
                new("CÁ NHÂN",    "  Hồ sơ cá nhân",      "Hồ sơ cá nhân",          () => new ucProfile()),
            },
            ["security"] = new()
            {
                new("CHÍNH",      "  Tổng quan",          "Tổng quan cá nhân",      () => new ucOverview_Staff()),
                new("CHÍNH",      "  Bãi xe",             "Kiểm soát Bãi xe",       () => new ucParking_Security()),
                new("CHÍNH",      "  SOS An ninh",        "Hệ thống cảnh báo SOS",  () => new ucSOS_Security()),
                new("CÁ NHÂN",    "  Lịch sử chấm công",  "Lịch sử chấm công & Báo cáo", () => new ucAttendanceHistory()),
                new("CÁ NHÂN",    "  Xin nghỉ",           "Đơn xin nghỉ phép",      () => new ucLeaveRequest()),
                new("CÁ NHÂN",    "  Chọn ca / Đổi ca",   "Chọn ca & Đổi ca",       () => new ucShiftRegister()),
                new("CÁ NHÂN",    "  Chat nội bộ",        "Chat nội bộ",            () => new ucInternalChat()),
                new("CÁ NHÂN",    "  Hồ sơ cá nhân",      "Hồ sơ cá nhân",          () => new ucProfile()),
            },
        };

        private static readonly Dictionary<string, string> RoleDisplay = new()
        {
            ["admin"] = "Quản trị viên",
            ["manager"] = "Quản lý",
            ["order staff"] = "Nhân viên Order",
            ["barista"] = "Pha chế",
            ["security"] = "Bảo vệ",
        };

        // Khởi tạo form
        public MainDashboard()
        {
            InitializeComponent();
            FormCorners.Round(this);
            WindowChrome.Apply(this, minimize: true, maximize: true, close: true,
                               host: pnlHeader, dragHandle: pnlHeader, onClose: () => Application.Exit());
            _dashboardManager = new BaseDashboard(this);

            // Giảm giật/nháy khi chuyển màn hình và khi cuộn sidebar
            DoubleBuffered = true;
            EnableDoubleBuffer(pnlContentHost);
            EnableDoubleBuffer(pnlMenuScroll);

            LoadLogo();
            lblDate.Text = FormatVietnameseDate(DateTime.Now);

            string role = GlobalSession.CurrentUser?.Role?.ToLowerInvariant() ?? "";

            string roleLabel = RoleDisplay.TryGetValue(role, out var rl) ? rl : "Người dùng";
            lblUserName.Text = GlobalSession.CurrentUser?.FullName ?? "Người dùng";
            lblUserRole.Text = roleLabel;

            BuildSidebar(role);

            // Nút menu vừa dựng xong (sau WindowChrome.Apply) → tắt mnemonic ngay
            // để '&' trong "Sản phẩm & Thực đơn"… không lóe thành '_' ở frame đầu.
            MnemonicFix.Apply(pnlSidebar);
        }

        // Định dạng ngày tiếng Việt
        private static string FormatVietnameseDate(DateTime dt)
        {
            string[] dayNames = { "Chủ Nhật", "Thứ Hai", "Thứ Ba", "Thứ Tư", "Thứ Năm", "Thứ Sáu", "Thứ Bảy" };
            return $"{dayNames[(int)dt.DayOfWeek]}, {dt:dd 'tháng' MM 'năm' yyyy}";
        }

        // Tải logo
        private void LoadLogo()
        {
            try
            {
                string path = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "logo.png");
                var pic = pnlLogoBlock.Controls.OfType<PictureBox>().FirstOrDefault();
                if (pic != null && System.IO.File.Exists(path))
                    pic.Image = Image.FromFile(path);
            }
            catch { }
        }

        // Xây dựng sidebar theo role
        private void BuildSidebar(string role)
        {
            if (!RoleMenus.TryGetValue(role, out var menuItems)) return;

            string? lastGroup = null;

            foreach (var item in menuItems)
            {
                if (item.Group != lastGroup)
                {
                    var groupLbl = new Label
                    {
                        Text = item.Group,
                        Font = new Font("Segoe UI", 8F, FontStyle.Bold),
                        ForeColor = GroupLabelFg,
                        AutoSize = false,
                        Height = 28,
                        Padding = new Padding(8, 12, 0, 4),
                        Tag = "group",
                    };
                    pnlMenuScroll.Controls.Add(groupLbl);
                    lastGroup = item.Group;
                }

                //
                // btn (menu item — tạo động, không thể đưa vào Designer.cs)
                //
                var btn = new Guna2Button
                {
                    Text        = item.ButtonText,
                    Height      = 42,
                    BorderRadius = 10,
                    FillColor   = SidebarBg,
                    ForeColor   = MenuFg,
                    Font        = new Font("Segoe UI", 10F),
                    Cursor      = Cursors.Hand,
                    TextAlign   = HorizontalAlignment.Left,
                };
                btn.HoverState.FillColor = MenuHoverBg;
                btn.HoverState.ForeColor = Color.White;
                btn.Tag    = item;
                btn.Click += BtnMenu_Click;

                pnlMenuScroll.Controls.Add(btn);
                _menuButtons.Add(btn);
            }

            LayoutMenuSidebarButtons();
        }

        // Sự kiện form
        private void MainDashboard_Load(object sender, EventArgs e)
        {
            if (_menuButtons.Count > 0)
                _menuButtons[0].PerformClick();
        }

        private void PnlMenuScroll_Resize(object? sender, EventArgs e) =>
            LayoutMenuSidebarButtons();

        private void BtnMenu_Click(object? sender, EventArgs e)
        {
            if (sender is not Guna2Button btn) return;
            if (btn.Tag is not MenuItemConfig config) return;

            if (!_ucCache.TryGetValue(config, out var uc) || uc.IsDisposed)
            {
                // Lần đầu mở màn hình: dựng UC (phần nặng) — hiện con trỏ chờ
                Cursor.Current = Cursors.WaitCursor;
                try
                {
                    uc = config.CreateUC();
                    _ucCache[config] = uc;
                }
                finally { Cursor.Current = Cursors.Default; }
            }

            ShowUserControl(uc);
            lblTitle.Text = config.TitleText;
            HighlightActiveButton(btn);
        }

        // Căn chỉnh layout sidebar
        private void LayoutMenuSidebarButtons()
        {
            if (pnlMenuScroll.IsDisposed) return;

            int padX = pnlMenuScroll.Padding.Left;
            int padY = pnlMenuScroll.Padding.Top;
            int innerW = Math.Max(pnlMenuScroll.ClientSize.Width - pnlMenuScroll.Padding.Horizontal, 1);
            int gap = 3;
            int y = padY;

            foreach (Control c in pnlMenuScroll.Controls)
            {
                if (c is Label && (string?)c.Tag == "group")
                {
                    c.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
                    c.Location = new Point(padX, y);
                    c.Size = new Size(innerW, c.Height);
                    y += c.Height + 2;
                }
                else if (c is Guna2Button && c.Tag is MenuItemConfig)
                {
                    c.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
                    c.Location = new Point(padX, y);
                    c.Size = new Size(innerW, 42);
                    y += 42 + gap;
                }
            }

        }

        // Quản lý nội dung chính: UC được giữ lại trong host và ẩn/hiện thay vì
        // gỡ ra dựng lại — chuyển màn hình gần như tức thì từ lần mở thứ hai.
        private void ShowUserControl(UserControl uc)
        {
            pnlContentHost.SuspendLayout();

            if (!pnlContentHost.Controls.Contains(uc))
            {
                // Bổ sung Anchor khi UC còn ở kích thước thiết kế → khi Dock=Fill vào
                // khung lớn hơn, các panel/lưới sẽ giãn vừa khít thay vì nằm yên góc trái.
                ResponsiveLayout.Apply(uc);
                uc.Dock = DockStyle.Fill;
                pnlContentHost.Controls.Add(uc);
            }

            uc.Visible = true;
            uc.BringToFront();
            foreach (Control c in pnlContentHost.Controls)
                if (c != uc) c.Visible = false;

            pnlContentHost.ResumeLayout(true);

            // Tự động gắn AutoFadeScroll (thanh teal) cho mọi DGV/panel bên trong UC
            // và tắt mnemonic để '&' không bị vẽ thành '_'. Cả hai đều idempotent.
            AutoFadeScroll.AttachAll(uc);
            MnemonicFix.Apply(uc);
        }

        private static void EnableDoubleBuffer(Control c) =>
            typeof(Control).GetProperty("DoubleBuffered",
                System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic)
                ?.SetValue(c, true);

        private void HighlightActiveButton(Guna2Button activeBtn)
        {
            foreach (var btn in _menuButtons)
            {
                btn.FillColor = SidebarBg;
                btn.ForeColor = MenuFg;
                btn.HoverState.FillColor = MenuHoverBg;
                btn.HoverState.ForeColor = Color.White;
            }
            activeBtn.FillColor = MenuActiveBg;
            activeBtn.ForeColor = MenuActiveFg;
            activeBtn.HoverState.FillColor = MenuActiveBg;
            activeBtn.HoverState.ForeColor = MenuActiveFg;
        }

        // Mở hộp thoại Báo lỗi gửi Admin (kèm tên màn hình đang mở để dễ truy vết)
        private void BtnReport_Click(object? sender, EventArgs e)
        {
            using var dlg = new ReportBug(lblTitle.Text);
            dlg.ShowDialog(this);
        }

        // Đăng xuất & đóng ứng dụng
        private void BtnLogout_Click(object? sender, EventArgs e)
        {
            Form? loginForm = Application.OpenForms["Login"];
            if (loginForm != null)
            {
                loginForm.Show();
            }
            else
            {
                Login log = new();
                log.Show();
            }

            GlobalSession.Logout();

            for (int i = Application.OpenForms.Count - 1; i >= 0; i--)
            {
                Form? f = Application.OpenForms[i];
                if (f?.Name != "Login")
                {
                    f?.Close();
                }
            }
        }

        // Khi form bị minimize, vùng client co về ~0×0. WinForms sẽ tính lại
        // vị trí/offset của các control neo (Anchor Top|Right: pnlUserCard và các
        // nút min/max/close) theo kích thước tí hon đó → khi phóng to lại chúng
        // bị lệch và chồng lên nhau. Bỏ qua layout khi đang minimize; layout sẽ
        // chạy lại đúng khi form được khôi phục.
        protected override void OnResize(EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized) return;
            base.OnResize(e);
        }
    }
}
