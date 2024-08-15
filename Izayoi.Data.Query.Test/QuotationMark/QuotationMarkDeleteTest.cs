// ----------------------------------------------------------------------
// @Namespace : Izayoi.Data.Query.Test.QuotationMark
// @Class     : QuotationMarkDeleteTest
// ----------------------------------------------------------------------
namespace Izayoi.Data.Query.Test.QuotationMark
{
    using Izayoi.Data.Query;
    using System.Data;
    using Xunit;

    public class QuotationMarkDeleteTest : TestBase
    {
        #region Fields

        private Delete _delete;

        #endregion

        #region Constructors

        public QuotationMarkDeleteTest() : base()
        {
            _delete = new Delete();
        }

        #endregion

        #region Delete From Methods

        [Fact]
        public void Test_BuildDelete_From()
        {
            QueryBuilder queryBuilder = new(_queryOption);

            _delete.SetFrom("users");

            _expectedQueryBuilder
                .Append("DELETE FROM [users]");

            queryBuilder.Build(_delete);

            string expectedQuery = _expectedQueryBuilder.ToString();

            string actualQuery = queryBuilder.GetQuery();

            Assert.Equal(expectedQuery, actualQuery);

            Assert.Empty(queryBuilder.Parameters);
        }

        [Theory]
        [InlineData(false)]
        [InlineData(true)]
        public void Test_BuildDelete_From_AB(bool beforeComma)
        {
            QueryOption queryOption = beforeComma
                ? _queryOptionB
                : _queryOptionA;

            QueryBuilder queryBuilder = new(queryOption);

            _delete.SetFrom("users");

            _expectedQueryBuilder
                .AppendLine("DELETE")
                .AppendLine("FROM")
                .Append("    [users]");

            queryBuilder.Build(_delete);

            string expectedQuery = _expectedQueryBuilder.ToString();

            string actualQuery = queryBuilder.GetQuery();

            Assert.Equal(expectedQuery, actualQuery);

            Assert.Empty(queryBuilder.Parameters);
        }

        #endregion

        #region Delete Where Methods

        [Fact]
        public void Test_BuildDelete_Where()
        {
            QueryBuilder queryBuilder = new(_queryOption);

            _delete
                .SetFrom("users")
                .AddWhere("id", "=", 1);

            _expectedQueryBuilder
                .AppendLine("DELETE")
                .AppendLine("FROM [users]")
                .Append("WHERE [id] = @w_0");

            queryBuilder.Build(_delete);

            string expectedQuery = _expectedQueryBuilder.ToString();

            string actualQuery = queryBuilder.GetQuery();

            Assert.Equal(expectedQuery, actualQuery);

            Assert.Equal(1, queryBuilder.Parameters.Count);

            Assert.All(queryBuilder.Parameters,
                (p, index) =>
                {
                    Assert.Equal($"@w_{index}", p.ParameterName);
                }
            );

            Assert.Collection(queryBuilder.Parameters,
                p =>
                {
                    Assert.Equal(DbType.Int32, p.DbType);
                    Assert.Equal(1, p.Value);
                }
            );
        }

        [Theory]
        [InlineData(false)]
        [InlineData(true)]
        public void Test_BuildDelete_Where_AB(bool beforeComma)
        {
            QueryOption queryOption = beforeComma
                ? _queryOptionB
                : _queryOptionA;

            QueryBuilder queryBuilder = new(queryOption);

            _delete
                .SetFrom("users")
                .AddWhere("id", "=", 1);

            _expectedQueryBuilder
                .AppendLine("DELETE")
                .AppendLine("FROM")
                .AppendLine("    [users]")
                .AppendLine("WHERE")
                .Append("    [id] = @w_0");

            queryBuilder.Build(_delete);

            string expectedQuery = _expectedQueryBuilder.ToString();

            string actualQuery = queryBuilder.GetQuery();

            Assert.Equal(expectedQuery, actualQuery);

            Assert.Equal(1, queryBuilder.Parameters.Count);

            Assert.All(queryBuilder.Parameters,
                (p, index) =>
                {
                    Assert.Equal($"@w_{index}", p.ParameterName);
                }
            );

            Assert.Collection(queryBuilder.Parameters,
                p =>
                {
                    Assert.Equal(DbType.Int32, p.DbType);
                    Assert.Equal(1, p.Value);
                }
            );
        }

        #endregion
    }
}