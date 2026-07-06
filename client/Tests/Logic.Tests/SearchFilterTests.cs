using System.Data;
using GUI;
using Xunit;

namespace Logic.Tests
{
    // Kiểm thử LÕI của MỌI thanh tìm kiếm trong app (SearchFilter.AllColumnsFilter được
    // dùng ở ucStaff, ucCRM, ucProducts, ucReservation, ucManagers, ucFeedback…).
    // Test bằng cách áp RowFilter thật vào DataTable rồi đếm dòng khớp — vừa kiểm công thức
    // vừa đảm bảo chuỗi filter không ném EvaluateException.
    public class SearchFilterTests
    {
        private static DataTable People()
        {
            var dt = new DataTable();
            dt.Columns.Add("Tên", typeof(string));
            dt.Columns.Add("Tuổi", typeof(int));
            dt.Columns.Add("Mã", typeof(string));
            dt.Rows.Add("An", 30, "NV01");
            dt.Rows.Add("Bình", 25, "NV02");
            dt.Rows.Add("An Nhiên", 40, "NV03");
            return dt;
        }

        private static int CountMatches(DataTable dt, string keyword, params string[] exclude)
        {
            string filter = SearchFilter.AllColumnsFilter(dt, keyword, exclude);
            dt.DefaultView.RowFilter = filter;   // sẽ ném nếu filter dựng sai
            return dt.DefaultView.Count;
        }

        [Fact]
        public void EmptyKeyword_ReturnsEmptyFilter_ShowsAllRows()
        {
            var dt = People();
            Assert.Equal(string.Empty, SearchFilter.AllColumnsFilter(dt, "   "));
            Assert.Equal(3, CountMatches(dt, ""));
        }

        [Fact]
        public void Keyword_MatchesStringColumn_Substring()
            => Assert.Equal(2, CountMatches(People(), "An")); // "An" + "An Nhiên"

        [Fact]
        public void Keyword_MatchesNumericColumn_ViaConvert()
            => Assert.Equal(1, CountMatches(People(), "30")); // Tuổi = 30

        [Fact]
        public void ExcludedColumn_IsNotSearched()
            => Assert.Equal(0, CountMatches(People(), "30", "Tuổi")); // loại cột Tuổi -> "30" không còn khớp đâu

        [Fact]
        public void Keyword_MatchesIdColumn()
            => Assert.Equal(1, CountMatches(People(), "NV02"));

        // ---------- Escape ký tự đặc biệt của LIKE (%, [, *, ') ----------
        private static DataTable Notes()
        {
            var dt = new DataTable();
            dt.Columns.Add("Ghi chú", typeof(string));
            dt.Rows.Add("Giảm 50%");
            dt.Rows.Add("Giảm 50 phần trăm");
            dt.Rows.Add("O'Brien");
            dt.Rows.Add("Mảng [x]");
            return dt;
        }

        [Fact]
        public void PercentSign_IsTreatedLiterally_NotWildcard()
            // Nếu không escape "%", nó là wildcard và khớp CẢ 2 dòng "Giảm 50…". Escape đúng -> chỉ 1.
            => Assert.Equal(1, CountMatches(Notes(), "50%"));

        [Fact]
        public void Apostrophe_DoesNotBreakFilter()
            => Assert.Equal(1, CountMatches(Notes(), "O'Brien"));

        [Fact]
        public void SquareBracket_IsTreatedLiterally()
            => Assert.Equal(1, CountMatches(Notes(), "[x]"));

        [Fact]
        public void NoMatch_ReturnsZero()
            => Assert.Equal(0, CountMatches(People(), "Zzz"));
    }
}
