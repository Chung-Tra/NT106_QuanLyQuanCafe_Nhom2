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

        // ──────────────────────────────────────────────
        // MÀU SẮC SIDEBAR
        // ──────────────────────────────────────────────
        private static readonly Color SidebarBg = Color.FromArgb(31, 31, 34);
        private static readonly Color MenuFg = Color.FromArgb(200, 200, 205);
        private static readonly Color MenuHoverBg = Color.FromArgb(45, 45, 50);
        private static readonly Color MenuActiveBg = Color.FromArgb(31, 138, 154);
        private static readonly Color MenuActiveFg = Color.White;
        private static readonly Color GroupLabelFg = Color.FromArgb(120, 120, 125);

        // ──────────────────────────────────────────────
        // CẤU HÌNH MENU THEO VAI TRÒ
        // ──────────────────────────────────────────────
        private record MenuItemConfig(string Group, string ButtonText, string TitleText, Func<UserControl> CreateUC);

        private static readonly Dictionary<string, List<MenuItemConfig>> RoleMenus = new()
        {
            ["admin"] = new()
            {
                new("CHÍNH",      "📊  Tổng quan",          "Tổng quan toàn quán",  () => new ucDashboard_Admin()),
                new("CHÍNH",      "👥  Quản trị viên",      "Quản lý các Manager",  () => new ucAdmin_Managers()),
                new("CHÍNH",      "👤  Nhân viên",          "Danh sách nhân viên",  () => new ucStaff_Manager()),
                new("CHÍNH",      "💰  Tiền lương",         "Tiền lương tự động",   () => new ucPayroll_Admin()),
                new("KHÁCH HÀNG", "💬  Feedback",           "Kiểm soát Feedback",   () => new ucFeedback_Admin()),
                new("KHÁCH HÀNG", "🔔  Thông báo",          "Trung tâm Thông báo",  () => new ucNotification_Admin()),
                new("KHÁCH HÀNG", "📢  Gửi thông báo",      "Phát thông báo nội bộ",() => new ucBroadcastCenter()),
                new("CÁ NHÂN",    "✅  Điểm danh",          "Điểm danh nhân viên",  () => new ucWorkTracking()),
                new("CÁ NHÂN",    "💭  Chat nội bộ",        "Chat nội bộ",          () => new ucInternalChat()),
                new("CÁ NHÂN",    "👤  Profile",            "Thông tin cá nhân",    () => new ucProfile())
            },
            ["manager"] = new()
            {
                new("CHÍNH",      "📊  Tổng quan",          "Tổng quan ca làm",       () => new ucOverview_Manager()),
                new("CHÍNH",      "🍽  Sản phẩm & Thực đơn","Quản lý món + nhập kho", () => new ucProducts_Manager()),
                new("CHÍNH",      "📋  Đơn hàng & Hóa đơn", "Đơn hàng và Hóa đơn",    () => new ucOrders_Manager()),
                new("CHÍNH",      "👤  Nhân viên",          "Danh sách nhân viên",    () => new ucStaff_Manager()),
                new("CHÍNH",      "📉  Thất thoát",         "Thất thoát & Hao phí",   () => new ucLoss_Manager()),
                new("KHÁCH HÀNG", "💬  Feedback",           "Chăm sóc Khách hàng",    () => new ucFeedback_Manager()),
                new("KHÁCH HÀNG", "🔔  Thông báo",          "Xử lý Thông báo",        () => new ucNotification_Manager()),
                new("KHÁCH HÀNG", "📢  Gửi thông báo",      "Phát thông báo nội bộ",  () => new ucBroadcastCenter()),
                new("CÁ NHÂN",    "🏖  Xin nghỉ",           "Duyệt đơn xin nghỉ",     () => new ucLeaveRequest()),
                new("CÁ NHÂN",    "✅  Điểm danh",          "Điểm danh nhân viên",    () => new ucWorkTracking()),
                new("CÁ NHÂN",    "💭  Chat nội bộ",        "Chat nội bộ",            () => new ucInternalChat()),
                new("CÁ NHÂN",    "👤  Profile",            "Thông tin cá nhân",      () => new ucProfile()),
            },
            ["order staff"] = new()
            {
                new("CHÍNH",      "📊  Tổng quan",          "Tổng quan cá nhân",      () => new ucOverview_Staff()),
                new("CHÍNH",      "🛒  Lên đơn / POS",      "Lên đơn / POS",          () => new ucPOS_OrderStaff()),
                new("CHÍNH",      "👥  Khách hàng (CRM)",   "Quản lý Khách hàng",     () => new ucCRM_OrderStaff()),
                new("CHÍNH",      "💵  Tiền mặt",           "Quản lý Tiền mặt",       () => new ucCashManagement_OrderStaff()),
                new("CÁ NHÂN",    "📅  Lịch sử chấm công",  "Xem lịch sử + báo cáo",  () => new ucAttendanceHistory()),
                new("CÁ NHÂN",    "🏖  Xin nghỉ",           "Đơn xin nghỉ phép",      () => new ucLeaveRequest()),
                new("CÁ NHÂN",    "💭  Chat nội bộ",        "Chat nội bộ",            () => new ucInternalChat()),
                new("CÁ NHÂN",    "👤  Profile",            "Thông tin cá nhân",      () => new ucProfile()),
            },
            ["barista"] = new()
            {
                new("CHÍNH",      "📊  Tổng quan",          "Tổng quan cá nhân",      () => new ucOverview_Staff()),
                new("CHÍNH",      "🍳  Màn hình Bếp",       "Màn hình Bếp realtime",  () => new ucKDS_Barista()),
                new("CHÍNH",      "📖  Cẩm nang Pha chế",   "Công thức pha chế",      () => new ucRecipe_Barista()),
                new("CHÍNH",      "⚠  Báo động NL",        "Cảnh báo NL sắp hết",    () => new ucAlert_Barista()),
                new("CÁ NHÂN",    "📅  Lịch sử chấm công",  "Xem lịch sử + báo cáo",  () => new ucAttendanceHistory()),
                new("CÁ NHÂN",    "🏖  Xin nghỉ",           "Đơn xin nghỉ phép",      () => new ucLeaveRequest()),
                new("CÁ NHÂN",    "💭  Chat nội bộ",        "Chat nội bộ",            () => new ucInternalChat()),
                new("CÁ NHÂN",    "👤  Profile",            "Thông tin cá nhân",      () => new ucProfile()),
            },
            ["security"] = new()
            {
                new("CHÍNH",      "📊  Tổng quan",          "Tổng quan cá nhân",      () => new ucOverview_Staff()),
                new("CHÍNH",      "🅿  Bãi xe",             "Kiểm soát Bãi xe",       () => new ucParking_Security()),
                new("CHÍNH",      "🚨  SOS An ninh",        "Hệ thống cảnh báo SOS",  () => new ucSOS_Security()),
                new("CÁ NHÂN",    "📅  Lịch sử chấm công",  "Xem lịch sử + báo cáo",  () => new ucAttendanceHistory()),
                new("CÁ NHÂN",    "🏖  Xin nghỉ",           "Đơn xin nghỉ phép",      () => new ucLeaveRequest()),
                new("CÁ NHÂN",    "💭  Chat nội bộ",        "Chat nội bộ",            () => new ucInternalChat()),
                new("CÁ NHÂN",    "👤  Profile",            "Thông tin cá nhân",      () => new ucProfile()),
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

        // ──────────────────────────────────────────────
        // KHỞI TẠO FORM
        // ──────────────────────────────────────────────
        public MainDashboard()
        {
            InitializeComponent();
            FormCorners.Round(this);
            AppFonts.ApplyTo(lblBrand, lblTitle);
            _dashboardManager = new BaseDashboard(this);

            LoadLogo();
            lblDate.Text = FormatVietnameseDate(DateTime.Now);

            string role = GlobalSession.CurrentUser?.Role?.ToLowerInvariant() ?? "";

            string roleLabel = RoleDisplay.TryGetValue(role, out var rl) ? rl : "Người dùng";
            lblUserName.Text = GlobalSession.CurrentUser?.FullName ?? "Người dùng";
            lblUserRole.Text = roleLabel;

            BuildSidebar(role);

        }

        // ──────────────────────────────────────────────
        // ĐỊNH DẠNG NGÀY TIẾNG VIỆT
        // ──────────────────────────────────────────────
        private static string FormatVietnameseDate(DateTime dt)
        {
            string[] dayNames = { "Chủ Nhật", "Thứ Hai", "Thứ Ba", "Thứ Tư", "Thứ Năm", "Thứ Sáu", "Thứ Bảy" };
            return $"{dayNames[(int)dt.DayOfWeek]}, {dt:dd 'tháng' MM 'năm' yyyy}";
        }

        // ──────────────────────────────────────────────
        // TẢI LOGO
        // ──────────────────────────────────────────────
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

        // ──────────────────────────────────────────────
        // XÂY DỰNG SIDEBAR THEO ROLE
        // ──────────────────────────────────────────────
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

        // ──────────────────────────────────────────────
        // SỰ KIỆN FORM
        // ──────────────────────────────────────────────
        private void MainDashboard_Load(object sender, EventArgs e)
        {
            _dashboardManager.ApplyDrag();

            if (_menuButtons.Count > 0)
                _menuButtons[0].PerformClick();
        }

        private void PnlMenuScroll_Resize(object? sender, EventArgs e) =>
            LayoutMenuSidebarButtons();

        private void BtnMenu_Click(object? sender, EventArgs e)
        {
            if (sender is not Guna2Button btn) return;
            if (btn.Tag is not MenuItemConfig config) return;

            UserControl uc = config.CreateUC();
            AddUserControl(uc);
            lblTitle.Text = config.TitleText;
            HighlightActiveButton(btn);
        }

        // ──────────────────────────────────────────────
        // CĂN CHỈNH LAYOUT SIDEBAR
        // ──────────────────────────────────────────────
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

        // ──────────────────────────────────────────────
        // QUẢN LÝ NỘI DUNG CHÍNH
        // ──────────────────────────────────────────────
        private void AddUserControl(UserControl uc)
        {
            uc.Dock = DockStyle.Fill;
            for (int i = pnlContentHost.Controls.Count - 1; i >= 0; i--)
                pnlContentHost.Controls.RemoveAt(i);

            pnlContentHost.Controls.Add(uc);
            uc.BringToFront();
        }

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

        // ──────────────────────────────────────────────
        // ĐĂNG XUẤT & ĐÓNG ỨNG DỤNG
        // ──────────────────────────────────────────────
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

        private void BtnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
