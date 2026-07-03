namespace GUI
{
    // Dịch Role/Status nhân viên giữa giá trị hệ thống (tiếng Anh, lưu server)
    // và nhãn tiếng Việt hiển thị trên UI. Grid hiển thị tiếng Việt nhưng các dialog
    // (EditEmployee, EmployeeDetail…) nhận giá trị raw nên cần dịch được 2 chiều.
    public static class EmployeeText
    {
        private static readonly Dictionary<string, string> RoleMap = new()
        {
            ["admin"]       = "Quản trị viên",
            ["manager"]     = "Quản lý",
            ["order staff"] = "Nhân viên Order",
            ["barista"]     = "Pha chế",
            ["security"]    = "Bảo vệ",
        };

        public static string RoleVi(string? raw) =>
            raw != null && RoleMap.TryGetValue(raw, out var vi) ? vi : raw ?? "";

        public static string RoleRaw(string? vi) =>
            RoleMap.FirstOrDefault(kv => kv.Value == vi).Key ?? vi ?? "";

        public static string StatusVi(string? raw) => raw == "active" ? "Đang làm" : "Xin nghỉ";

        public static string StatusRaw(string? vi) => vi == "Đang làm" ? "active" : "inactive";
    }
}
