// ----------------------------------------------------------------------
// @Namespace : Izayoi.Data.Query.Test
// @Class     : TestBase
// ----------------------------------------------------------------------
namespace Izayoi.Data.Query.Test
{
    using Izayoi.Data.Query;
    using System.Text;

    public abstract class TestBase
    {
        #region Fields

        protected readonly QueryOption _queryOption;

        protected readonly QueryOption _queryOptionA;

        protected readonly QueryOption _queryOptionB;

        protected readonly StringBuilder _expectedQueryBuilder;

        #endregion

        #region Constructors

        public TestBase()
        {
            _queryOption = new QueryOption(RdbKind.None)
            {
                EnableFormat = false,
                IndentSpace = 2,
                BeforeComma = false,
            };

            _queryOptionA = new QueryOption(RdbKind.None)
            {
                EnableFormat = true,
                IndentSpace = 4,
                BeforeComma = false,
            };

            _queryOptionB = new QueryOption(RdbKind.None)
            {
                EnableFormat = true,
                IndentSpace = 4,
                BeforeComma = true,
            };

            _expectedQueryBuilder = new StringBuilder(256);
        }

        #endregion
    }
}