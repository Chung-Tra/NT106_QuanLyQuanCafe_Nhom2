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
            ["admin"] = new()
            {
                new("  Tổng quan",           "Tổng quan",              () => new ucDashboard_Admin()),
                new("  Thông báo",           "Trung tâm Thông báo",    () => new ucNotification_Admin()),
                new("  Quản lý Nhân viên",   "Quản lý Nhân viên",      () => new ucStaff_Manager()),
                new("  Quản trị viên",       "Quản trị viên",           () => new ucAdmin_Managers()),
                new("  Feedback",            "Kiểm soát Feedback",      () => new ucFeedback_Admin()),
                new("  Tiền lương",          "Tiền lương tự động",      () => new ucPayroll_Admin()),
                new("  Cài đặt và Chat",     "Cài đặt và Chat nội bộ", () => new ucSettings_Manager()),
                new("  Profile",             "Thông tin cá nhân",       () => new ucProfile()),
                new("  Điểm danh",           "Điểm danh",              () => new ucWorkTracking()),
            },
            ["manager"] = new()
            {
                new("  Tổng quan",              "Tổng quan ca làm",       () => new ucOverview_Manager()),
                new("  Sản phẩm và Thực đơn",   "Sản phẩm và Thực đơn",  () => new ucProducts_Manager()),
                new("  Đơn hàng và Hóa đơn",    "Đơn hàng và Hóa đơn",   () => new ucOrders_Manager()),
                new("  Quản lý Nhân viên",       "Quản lý Nhân viên",     () => new ucStaff_Manager()),
                new("  Thông báo",               "Xử lý Thông báo",       () => new ucNotification_Manager()),
                new("  Feedback",                "Chăm sóc Khách hàng",   () => new ucFeedback_Manager()),
                new("  Xin nghỉ",               "Xin nghỉ",              () => new ucLeaveRequest()),
                new("  Điểm danh",               "Điểm danh",             () => new ucWorkTracking()),
                new("  Chat nội bộ",             "Chat nội bộ",           () => new ucInternalChat()),
                new("  Profile",                 "Thông tin cá nhân",     () => new ucProfile()),
            },
            ["order staff"] = new()
            {
                new("  Lên đơn / POS",          "Lên đơn / POS",         () => new ucPOS_OrStaff()),
                new("  Khách hàng (CRM)",        "Quản lý Khách hàng",   () => new ucCRM_OrderStaff()),
                new("  Tiền mặt",               "Quản lý Tiền mặt",      () => new ucCashManagement_OrderStaff()),
                new("  Chat nội bộ",             "Chat nội bộ",           () => new ucInternalChat()),
                new("  Xin nghỉ",               "Xin nghỉ",              () => new ucLeaveRequest()),
                new("  Điểm danh",               "Điểm danh",            () => new ucWorkTracking()),
                new("  Profile",                 "Thông tin cá nhân",     () => new ucProfile()),
            },
            ["barista"] = new()
            {
                new("  Màn hình Bếp (KDS)",      "Màn hình Bếp",         () => new ucKDS_Barista()),
                new("  Cẩm nang Pha chế",        "Cẩm nang Pha chế",     () => new ucRecipe_Barista()),
                new("  Báo động Nguyên liệu",    "Báo động Đỏ",          () => new ucAlert_Barista()),
                new("  Chat nội bộ",             "Chat",                  () => new ucInternalChat()),
                new("  Xin nghỉ",               "Xin nghỉ",              () => new ucLeaveRequest()),
                new("  Điểm danh",               "Điểm danh",            () => new ucWorkTracking()),
                new("  Profile",                 "Thông tin cá nhân",     () => new ucProfile()),
            },
            ["stockkeeper"] = new()
            {
                new("  Kiểm soát Kho",           "Kiểm soát Kho",        () => new ucStockControl_Warehouse()),
                new("  Đề xuất Nhập kho",        "Nhập kho thông minh",  () => new ucSmartRestock_Warehouse()),
                new("  Chat nội bộ",             "Chat nội bộ",           () => new ucInternalChat()),
                new("  Xin nghỉ",               "Xin nghỉ",              () => new ucLeaveRequest()),
                new("  Điểm danh",               "Điểm danh",            () => new ucWorkTracking()),
                new("  Profile",                 "Thông tin cá nhân",     () => new ucProfile()),
            },
            ["security"] = new()
            {
                new("  Bãi xe",                  "Kiểm soát Bãi xe",     () => new ucParking_Security()),
                new("  SOS An ninh",             "Hệ thống An ninh",      () => new ucSOS_Security()),
                new("  Chat nội bộ",             "Chat nội bộ",           () => new ucInternalChat()),
                new("  Xin nghỉ",               "Xin nghỉ",              () => new ucLeaveRequest()),
                new("  Điểm danh",               "Điểm danh",            () => new ucWorkTracking()),
                new("  Profile",                 "Thông tin cá nhân",     () => new ucProfile()),
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

        private void BuildSidebar(string role)
        {
            if (RoleStyles.TryGetValue(role, out var style))
            {
                lblLogo.Text = style.LogoText;
                lblLogo.ForeColor = style.LogoColor;
            }

            if (!RoleMenus.TryGetValue(role, out var menuItems)) return;

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
