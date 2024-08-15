// ----------------------------------------------------------------------
// @Namespace : Izayoi.Data.Query.Test.MySql
// @Class     : MySqlTestBase
// ----------------------------------------------------------------------
namespace Izayoi.Data.Query.Test.MySql
{
    using Izayoi.Data.Query;
    using System.Text;

    public abstract class MySqlTestBase
    {
        #region Fields

        protected readonly QueryOption _queryOption;

        protected readonly QueryOption _queryOptionA;

        protected readonly QueryOption _queryOptionB;

        protected readonly StringBuilder _expectedQueryBuilder;

        #endregion

        #region Constructors

        public MySqlTestBase()
        {
            _queryOption = new QueryOption(RdbKind.Mysql)
            {
                QuotationMarks = new QuotationMarkSet('`', '`'),
                EnableFormat = false,
                IndentSpace = 2,
                BeforeComma = false,
            };

            _queryOptionA = new QueryOption(RdbKind.Mysql)
            {
                QuotationMarks = new QuotationMarkSet('`', '`'),
                EnableFormat = true,
                IndentSpace = 4,
                BeforeComma = false,
            };

            _queryOptionB = new QueryOption(RdbKind.Mysql)
            {
                QuotationMarks = new QuotationMarkSet('`', '`'),
                EnableFormat = true,
                IndentSpace = 4,
                BeforeComma = true,
            };

            _expectedQueryBuilder = new StringBuilder(256);
        }

        #endregion
    }
}