using DTO;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace GUI
{
    public partial class MainDashboard : Form
    {
        private readonly BaseDashboard _dashboardManager;
        private readonly List<Button> _menuButtons = new();

        private record MenuItemConfig(string ButtonText, string TitleText, Func<UserControl> CreateUC);

        private static readonly Dictionary<string, List<MenuItemConfig>> RoleMenus = new()
        {
            // Quy ước thứ tự menu:
            //   1. Tổng quan / Dashboard
            //   2. Công việc chính (theo vai trò)
            //   3. Báo cáo / phân tích / thông báo
            //   4. Tiện ích (chat, xin nghỉ, lịch sử chấm công)
            //   5. Profile / Cài đặt (luôn cuối cùng)
            ["admin"] = new()
            {
                new("  Tổng quan",            "Tổng quan toàn quán",     () => new ucDashboard_Admin()),
                new("  Quản trị viên",        "Quản lý các Manager",      () => new ucAdmin_Managers()),
                new("  Quản lý Nhân viên",    "Danh sách nhân viên",      () => new ucStaff_Manager()),
                new("  Tiền lương",           "Tiền lương tự động",       () => new ucPayroll_Admin()),
                new("  Feedback",             "Kiểm soát Feedback",       () => new ucFeedback_Admin()),
                new("  Thông báo",            "Trung tâm Thông báo",     () => new ucNotification_Admin()),
                new("  Gửi thông báo",        "Phát thông báo nội bộ",   () => new ucBroadcastCenter()),
                new("  Điểm danh",            "Điểm danh nhân viên",     () => new ucWorkTracking()),
                new("  Chat nội bộ",           "Chat nội bộ",              () => new ucInternalChat()),
                new("  Profile",              "Thông tin cá nhân",        () => new ucProfile()),
                new("  Cài đặt",              "Cài đặt hệ thống",         () => new ucSettings_Manager()),
            },
            ["manager"] = new()
            {
                new("  Tổng quan",            "Tổng quan ca làm",         () => new ucOverview_Manager()),
                new("  Sản phẩm & Thực đơn",  "Quản lý món + nhập kho",   () => new ucProducts_Manager()),
                new("  Đơn hàng & Hóa đơn",   "Đơn hàng và Hóa đơn",      () => new ucOrders_Manager()),
                new("  Quản lý Nhân viên",    "Danh sách nhân viên",      () => new ucStaff_Manager()),
                new("  Thất thoát",           "Thất thoát & Hao phí",     () => new ucLoss_Manager()),
                new("  Feedback",             "Chăm sóc Khách hàng",      () => new ucFeedback_Manager()),
                new("  Thông báo",            "Xử lý Thông báo",          () => new ucNotification_Manager()),
                new("  Gửi thông báo",        "Phát thông báo nội bộ",   () => new ucBroadcastCenter()),
                new("  Xin nghỉ",             "Duyệt đơn xin nghỉ",       () => new ucLeaveRequest()),
                new("  Điểm danh",            "Điểm danh nhân viên",     () => new ucWorkTracking()),
                new("  Chat nội bộ",           "Chat nội bộ",              () => new ucInternalChat()),
                new("  Profile",              "Thông tin cá nhân",        () => new ucProfile()),
            },
            ["order staff"] = new()
            {
                new("  Tổng quan",            "Tổng quan cá nhân",        () => new ucOverview_Staff()),
                new("  Lên đơn / POS",        "Lên đơn / POS",            () => new ucPOS_OrderStaff()),
                new("  Khách hàng (CRM)",     "Quản lý Khách hàng",       () => new ucCRM_OrderStaff()),
                new("  Tiền mặt",             "Quản lý Tiền mặt",         () => new ucCashManagement_OrderStaff()),
                new("  Lịch sử chấm công",   "Xem lịch sử + báo cáo",    () => new ucAttendanceHistory()),
                new("  Xin nghỉ",             "Đơn xin nghỉ phép",        () => new ucLeaveRequest()),
                new("  Chat nội bộ",           "Chat nội bộ",              () => new ucInternalChat()),
                new("  Profile",              "Thông tin cá nhân",        () => new ucProfile()),
            },
            ["barista"] = new()
            {
                new("  Tổng quan",            "Tổng quan cá nhân",        () => new ucOverview_Staff()),
                new("  Màn hình Bếp (KDS)",   "Màn hình Bếp realtime",    () => new ucKDS_Barista()),
                new("  Cẩm nang Pha chế",     "Công thức pha chế",        () => new ucRecipe_Barista()),
                new("  Báo động Nguyên liệu", "Cảnh báo NL sắp hết",      () => new ucAlert_Barista()),
                new("  Lịch sử chấm công",   "Xem lịch sử + báo cáo",    () => new ucAttendanceHistory()),
                new("  Xin nghỉ",             "Đơn xin nghỉ phép",        () => new ucLeaveRequest()),
                new("  Chat nội bộ",           "Chat nội bộ",              () => new ucInternalChat()),
                new("  Profile",              "Thông tin cá nhân",        () => new ucProfile()),
            },
            ["stockkeeper"] = new()
            {
                new("  Tổng quan",            "Tổng quan cá nhân",        () => new ucOverview_Staff()),
                new("  Kiểm soát Kho",         "Tồn kho realtime",         () => new ucStockControl_Warehouse()),
                new("  Đề xuất Nhập kho",      "Nhập kho thông minh",      () => new ucSmartRestock_Warehouse()),
                new("  Dự kiến Sản xuất",      "Số ly có thể pha",        () => new ucEstimatedProduction_Warehouse()),
                new("  Lịch sử chấm công",   "Xem lịch sử + báo cáo",    () => new ucAttendanceHistory()),
                new("  Xin nghỉ",             "Đơn xin nghỉ phép",        () => new ucLeaveRequest()),
                new("  Chat nội bộ",           "Chat nội bộ",              () => new ucInternalChat()),
                new("  Profile",              "Thông tin cá nhân",        () => new ucProfile()),
            },
            ["security"] = new()
            {
                new("  Tổng quan",            "Tổng quan cá nhân",        () => new ucOverview_Staff()),
                new("  Bãi xe",                "Kiểm soát Bãi xe",        () => new ucParking_Security()),
                new("  SOS An ninh",           "Hệ thống cảnh báo SOS",  () => new ucSOS_Security()),
                new("  Lịch sử chấm công",   "Xem lịch sử + báo cáo",    () => new ucAttendanceHistory()),
                new("  Xin nghỉ",             "Đơn xin nghỉ phép",        () => new ucLeaveRequest()),
                new("  Chat nội bộ",           "Chat nội bộ",              () => new ucInternalChat()),
                new("  Profile",              "Thông tin cá nhân",        () => new ucProfile()),
            },
        };

        private static readonly Dictionary<string, (string LogoText, Color LogoColor)> RoleStyles = new()
        {
            ["admin"]       = ("Quản trị viên",     Color.Goldenrod),
            ["manager"]     = ("Quản lý",           Color.Firebrick),
            ["order staff"] = ("Nhân viên Order",   Color.MediumSeaGreen),
            ["barista"]     = ("Pha chế",           Color.SteelBlue),
            ["stockkeeper"] = ("Thủ kho",           Color.Peru),
            ["security"]    = ("Bảo vệ",           Color.SlateGray),
        };

        public MainDashboard()
        {
            InitializeComponent();
            _dashboardManager = new BaseDashboard(this);

            string role = GlobalSession.CurrentUser?.Role?.ToLower() ?? "security";
            BuildSidebar(role);

            this.Load += (s, e) =>
            {
                if (_menuButtons.Count > 0)
                    _menuButtons[0].PerformClick();
            };
        }

        private readonly ToolTip _menuTooltip = new()
        {
            BackColor = Color.FromArgb(30, 30, 30),
            ForeColor = Color.White,
            OwnerDraw = true,
            AutoPopDelay = 5000,
            InitialDelay = 400,
            ReshowDelay = 200
        };

        private void BuildSidebar(string role)
        {
            if (RoleStyles.TryGetValue(role, out var style))
            {
                lblLogo.Text = style.LogoText;
                lblLogo.ForeColor = style.LogoColor;
            }

            if (!RoleMenus.TryGetValue(role, out var menuItems)) return;

            // Tooltip dùng OwnerDraw để giữ theme dark
            _menuTooltip.Draw += (s, e) =>
            {
                e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(30, 30, 30)), e.Bounds);
                e.Graphics.DrawRectangle(Pens.Gray, 0, 0, e.Bounds.Width - 1, e.Bounds.Height - 1);
                using var f = new Font("Segoe UI", 9F);
                e.Graphics.DrawString(e.ToolTipText, f, Brushes.White, 6, 4);
            };
            _menuTooltip.Popup += (s, e) => e.ToolTipSize = new Size(e.ToolTipSize.Width + 10, e.ToolTipSize.Height + 4);

            for (int i = menuItems.Count - 1; i >= 0; i--)
            {
                var item = menuItems[i];
                Button btn = new()
                {
                    Text = item.ButtonText,
                    Dock = DockStyle.Top,
                    Height = 50,
                    FlatStyle = FlatStyle.Flat,
                    ForeColor = Color.White,
                    Font = new Font("Segoe UI", 11F),
                    Cursor = Cursors.Hand,
                    TextAlign = ContentAlignment.MiddleLeft,
                    UseVisualStyleBackColor = true,
                };
                btn.FlatAppearance.BorderSize = 0;

                // Tooltip giải thích chức năng (đọc từ TitleText config)
                _menuTooltip.SetToolTip(btn, item.TitleText);

                var config = item;
                btn.Click += (s, e) =>
                {
                    UserControl uc = config.CreateUC();
                    AddUserControl(uc);
                    lblTitle.Text = config.TitleText;
                    HighlightActiveButton((Button)s!);
                };

                pnlSidebar.Controls.Add(btn);
                btn.BringToFront();
                _menuButtons.Insert(0, btn);
            }
        }

        private void AddUserControl(UserControl uc)
        {
            uc.Dock = DockStyle.Fill;
            pnlMainContent.Controls.Clear();
            pnlMainContent.Controls.Add(uc);
            uc.BringToFront();
        }

        private void HighlightActiveButton(Button activeBtn)
        {
            foreach (var btn in _menuButtons)
            {
                btn.BackColor = Color.FromArgb(30, 30, 30);
                btn.ForeColor = Color.White;
            }
            activeBtn.BackColor = Color.FromArgb(50, 50, 50);
            activeBtn.ForeColor = Color.Orange;
        }

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
