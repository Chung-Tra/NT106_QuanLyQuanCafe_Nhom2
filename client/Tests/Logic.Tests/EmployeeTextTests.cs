using GUI;
using Xunit;

namespace Logic.Tests
{
    // Mapping vai trò/trạng thái nhân viên. Các BỘ LỌC ở ucStaff_Manager so sánh
    // giá trị hiển thị (RoleVi/StatusVi) với item combobox ("Nhân viên Order", "Đang làm"…),
    // nên nếu mapping lệch thì lọc sẽ trả rỗng. Test khoá lại đúng cặp giá trị đó.
    public class EmployeeTextTests
    {
        [Theory]
        [InlineData("admin", "Quản trị viên")]
        [InlineData("manager", "Quản lý")]
        [InlineData("order staff", "Nhân viên Order")]
        [InlineData("barista", "Pha chế")]
        [InlineData("security", "Bảo vệ")]
        public void RoleVi_MapsKnownRoles(string raw, string vi)
            => Assert.Equal(vi, EmployeeText.RoleVi(raw));

        [Theory]
        [InlineData(null, "")]
        [InlineData("unknown", "unknown")]
        public void RoleVi_FallsBackToRaw(string? raw, string expected)
            => Assert.Equal(expected, EmployeeText.RoleVi(raw));

        [Theory]
        [InlineData("manager")]
        [InlineData("order staff")]
        [InlineData("barista")]
        [InlineData("security")]
        public void Role_RoundTrips(string raw)
            => Assert.Equal(raw, EmployeeText.RoleRaw(EmployeeText.RoleVi(raw)));

        [Theory]
        [InlineData("active", "Đang làm")]
        [InlineData("inactive", "Xin nghỉ")]
        [InlineData(null, "Xin nghỉ")]
        [InlineData("suspended", "Xin nghỉ")]
        public void StatusVi_Maps(string? raw, string expected)
            => Assert.Equal(expected, EmployeeText.StatusVi(raw));

        [Theory]
        [InlineData("Đang làm", "active")]
        [InlineData("Xin nghỉ", "inactive")]
        public void StatusRaw_Maps(string vi, string expected)
            => Assert.Equal(expected, EmployeeText.StatusRaw(vi));

        [Fact]
        public void Status_ActiveRoundTrips()
            => Assert.Equal("active", EmployeeText.StatusRaw(EmployeeText.StatusVi("active")));
    }
}
