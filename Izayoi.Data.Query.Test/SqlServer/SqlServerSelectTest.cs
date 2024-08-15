// ----------------------------------------------------------------------
// @Namespace : Izayoi.Data.Query.Test.SqlServer
// @Class     : SqlServerSelectTest
// ----------------------------------------------------------------------
namespace Izayoi.Data.Query.Test.SqlServer
{
    using Izayoi.Data.Query;
    using Xunit;

    public class SqlServerSelectTest : SqlServerTestBase
    {
        #region Fields

        private Select _select;

        #endregion

        #region Constructors

        public SqlServerSelectTest(): base()
        {
            _select = new Select();
        }

        #endregion

        #region Top Methods

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        public void Test_BuildSelect_Top(int limit)
        {
            QueryBuilder queryBuilder = new(_queryOption);

            _select
                .SetFrom("users")
                .AddField("*")
                .SetLimit(limit);

            _expectedQueryBuilder
                .AppendLine($"SELECT TOP {limit} *")
                .Append("FROM [users]");

            queryBuilder.Build(_select);

            string actualQuery = queryBuilder.GetQuery();

            string expectedQuery = _expectedQueryBuilder.ToString();

            Assert.Equal(expectedQuery, actualQuery);

            Assert.Empty(queryBuilder.Parameters);
        }

        [Theory]
        [InlineData(false, 1)]
        [InlineData(true, 1)]
        public void Test_BuildSelect_Top_AB(bool beforeComma, int limit)
        {
            QueryOption queryOption = beforeComma
                ? _queryOptionB
                : _queryOptionA;

            QueryBuilder queryBuilder = new(queryOption);

            _select
                .SetFrom("users")
                .AddField("*")
                .SetLimit(limit);

            _expectedQueryBuilder
                .AppendLine($"SELECT")
                .AppendLine($"TOP {limit}")
                .AppendLine($"    *")
                .AppendLine($"FROM")
                .Append("    [users]");

            queryBuilder.Build(_select);

            string actualQuery = queryBuilder.GetQuery();

            string expectedQuery = _expectedQueryBuilder.ToString();

            Assert.Equal(expectedQuery, actualQuery);

            Assert.Empty(queryBuilder.Parameters);
        }
        #endregion

        #region Offset Tetch Methods

        [Theory]
        [InlineData(1)]
        //[InlineData(2)]
        public void Test_BuildSelect_Offset(int offset)
        {
            QueryBuilder queryBuilder = new(_queryOption);

            _select
                .SetFrom("users")
                .AddField("*")
                .AddOrder("id", OType.ASC)
                .SetOffset(offset);

            _expectedQueryBuilder
                .AppendLine("SELECT *")
                .AppendLine("FROM [users]")
                .AppendLine("ORDER BY [id] ASC")
                .Append($"OFFSET {offset} ROWS");

            //.Append($"FETCH NEXT {limit} ROWS ONLY");

            queryBuilder.Build(_select);

            string actualQuery = queryBuilder.GetQuery();

            string expectedQuery = _expectedQueryBuilder.ToString();

            Assert.Equal(expectedQuery, actualQuery);

            Assert.Empty(queryBuilder.Parameters);
        }

        [Theory]
        [InlineData(false, 1)]
        [InlineData(true, 1)]
        public void Test_BuildSelect_Offset_AB(bool beforeComma, int offset)
        {
            QueryOption queryOption = beforeComma
                ? _queryOptionB
                : _queryOptionA;

            QueryBuilder queryBuilder = new(queryOption);

            _select
                .SetFrom("users")
                .AddField("*")
                .AddOrder("id", OType.ASC)
                .SetOffset(offset);

            _expectedQueryBuilder
                .AppendLine("SELECT")
                .AppendLine("    *")
                .AppendLine("FROM")
                .AppendLine("    [users]")
                .AppendLine("ORDER BY")
                .AppendLine("    [id] ASC")
                .Append($"OFFSET {offset} ROWS");

            queryBuilder.Build(_select);

            string actualQuery = queryBuilder.GetQuery();

            string expectedQuery = _expectedQueryBuilder.ToString();

            Assert.Equal(expectedQuery, actualQuery);

            Assert.Empty(queryBuilder.Parameters);
        }

        [Theory]
        [InlineData(1, 2)]
        [InlineData(2, 1)]
        public void Test_BuildSelect_Offset_Fetch(int limit, int offset)
        {
            QueryBuilder queryBuilder = new(_queryOption);

            _select
                .SetFrom("users")
                .AddField("*")
                .AddOrder("id", OType.ASC)
                .SetLimit(limit)
                .SetOffset(offset);

            _expectedQueryBuilder
                .AppendLine("SELECT *")
                .AppendLine("FROM [users]")
                .AppendLine("ORDER BY [id] ASC")
                .AppendLine($"OFFSET {offset} ROWS")
                .Append($"FETCH NEXT {limit} ROWS ONLY");

            queryBuilder.Build(_select);

            string actualQuery = queryBuilder.GetQuery();

            string expectedQuery = _expectedQueryBuilder.ToString();

            Assert.Equal(expectedQuery, actualQuery);

            Assert.Empty(queryBuilder.Parameters);
        }

        [Theory]
        [InlineData(false, 1, 2)]
        [InlineData(true, 1, 2)]
        [InlineData(false, 2, 1)]
        [InlineData(true, 2, 1)]
        public void Test_BuildSelect_Offset_Fetch_AB(bool beforeComma, int limit, int offset)
        {
            QueryOption queryOption = beforeComma
                ? _queryOptionB
                : _queryOptionA;

            QueryBuilder queryBuilder = new(queryOption);

            _select
                .SetFrom("users")
                .AddField("*")
                .AddOrder("id", OType.ASC)
                .SetLimit(limit)
                .SetOffset(offset);

            _expectedQueryBuilder
                .AppendLine("SELECT")
                .AppendLine("    *")
                .AppendLine("FROM")
                .AppendLine("    [users]")
                .AppendLine("ORDER BY")
                .AppendLine("    [id] ASC")
                .AppendLine($"OFFSET {offset} ROWS")
                .Append($"FETCH NEXT {limit} ROWS ONLY");

            queryBuilder.Build(_select);

            string actualQuery = queryBuilder.GetQuery();

            string expectedQuery = _expectedQueryBuilder.ToString();

            Assert.Equal(expectedQuery, actualQuery);

            Assert.Empty(queryBuilder.Parameters);
        }

        #endregion

        #region For Methods

        [Fact]
        public void Test_BuildSelect_For_JSON_Auto()
        {
            QueryBuilder queryBuilder = new(_queryOption);

            _select
                .SetFrom("SalesOrder")
                .AddField("Number", "Order.Number")
                .AddField("Date", "Order.Date")
                .AddField("Customer", "AccountNumber")
                .AddField("Price", "Item.Price")
                .AddField("Quantity", "Item.Quantity")
                .SetFor(JsonMode.Auto);

            _expectedQueryBuilder
                .AppendLine("SELECT [Number] AS [Order.Number], [Date] AS [Order.Date], [Customer] AS [AccountNumber], [Price] AS [Item.Price], [Quantity] AS [Item.Quantity]")
                .AppendLine("FROM [SalesOrder]")
                .Append($"FOR JSON AUTO");

            queryBuilder.Build(_select);

            string actualQuery = queryBuilder.GetQuery();

            string expectedQuery = _expectedQueryBuilder.ToString();

            Assert.Equal(expectedQuery, actualQuery);

            Assert.Empty(queryBuilder.Parameters);
        }

        [Fact]
        public void Test_BuildSelect_For_JSON_Auto_A()
        {
            QueryBuilder queryBuilder = new(_queryOptionA);

            _select
                .SetFrom("SalesOrder")
                .AddField("Number", "Order.Number")
                .AddField("Date", "Order.Date")
                .AddField("Customer", "AccountNumber")
                .AddField("Price", "Item.Price")
                .AddField("Quantity", "Item.Quantity")
                .SetFor(JsonMode.Auto);

            _expectedQueryBuilder
                .AppendLine("SELECT")
                .AppendLine("    [Number] AS [Order.Number],")
                .AppendLine("    [Date] AS [Order.Date],")
                .AppendLine("    [Customer] AS [AccountNumber],")
                .AppendLine("    [Price] AS [Item.Price],")
                .AppendLine("    [Quantity] AS [Item.Quantity]")
                .AppendLine("FROM")
                .AppendLine("    [SalesOrder]")
                .Append($"FOR JSON AUTO");

            queryBuilder.Build(_select);

            string actualQuery = queryBuilder.GetQuery();

            string expectedQuery = _expectedQueryBuilder.ToString();

            Assert.Equal(expectedQuery, actualQuery);

            Assert.Empty(queryBuilder.Parameters);
        }

        [Fact]
        public void Test_BuildSelect_For_JSON_Auto_B()
        {
            QueryBuilder queryBuilder = new(_queryOptionB);

            _select
                .SetFrom("SalesOrder")
                .AddField("Number", "Order.Number")
                .AddField("Date", "Order.Date")
                .AddField("Customer", "AccountNumber")
                .AddField("Price", "Item.Price")
                .AddField("Quantity", "Item.Quantity")
                .SetFor(JsonMode.Auto);

            _expectedQueryBuilder
                .AppendLine("SELECT")
                .AppendLine("    [Number] AS [Order.Number]")
                .AppendLine("  , [Date] AS [Order.Date]")
                .AppendLine("  , [Customer] AS [AccountNumber]")
                .AppendLine("  , [Price] AS [Item.Price]")
                .AppendLine("  , [Quantity] AS [Item.Quantity]")
                .AppendLine("FROM")
                .AppendLine("    [SalesOrder]")
                .Append($"FOR JSON AUTO");

            queryBuilder.Build(_select);

            string actualQuery = queryBuilder.GetQuery();

            string expectedQuery = _expectedQueryBuilder.ToString();

            Assert.Equal(expectedQuery, actualQuery);

            Assert.Empty(queryBuilder.Parameters);
        }

        [Fact]
        public void Test_BuildSelect_For_JSON_Path()
        {
            QueryBuilder queryBuilder = new(_queryOption);

            _select
                .SetFrom("SalesOrder")
                .AddField("Number", "Order.Number")
                .AddField("Date", "Order.Date")
                .AddField("Customer", "AccountNumber")
                .AddField("Price", "Item.Price")
                .AddField("Quantity", "Item.Quantity")
                .SetFor(JsonMode.Path, "Orders");

            _expectedQueryBuilder
                .AppendLine("SELECT [Number] AS [Order.Number], [Date] AS [Order.Date], [Customer] AS [AccountNumber], [Price] AS [Item.Price], [Quantity] AS [Item.Quantity]")
                .AppendLine("FROM [SalesOrder]")
                .Append($"FOR JSON PATH, ROOT('Orders')");

            queryBuilder.Build(_select);

            string actualQuery = queryBuilder.GetQuery();

            string expectedQuery = _expectedQueryBuilder.ToString();

            Assert.Equal(expectedQuery, actualQuery);

            Assert.Empty(queryBuilder.Parameters);
        }

        [Fact]
        public void Test_BuildSelect_For_JSON_Path_A()
        {
            QueryBuilder queryBuilder = new(_queryOptionA);

            _select
                .SetFrom("SalesOrder")
                .AddField("Number", "Order.Number")
                .AddField("Date", "Order.Date")
                .AddField("Customer", "AccountNumber")
                .AddField("Price", "Item.Price")
                .AddField("Quantity", "Item.Quantity")
                .SetFor(JsonMode.Path, "Orders");

            _expectedQueryBuilder
                .AppendLine("SELECT")
                .AppendLine("    [Number] AS [Order.Number],")
                .AppendLine("    [Date] AS [Order.Date],")
                .AppendLine("    [Customer] AS [AccountNumber],")
                .AppendLine("    [Price] AS [Item.Price],")
                .AppendLine("    [Quantity] AS [Item.Quantity]")
                .AppendLine("FROM")
                .AppendLine("    [SalesOrder]")
                .AppendLine($"FOR JSON PATH,")
                .Append($"    ROOT('Orders')");

            queryBuilder.Build(_select);

            string actualQuery = queryBuilder.GetQuery();

            string expectedQuery = _expectedQueryBuilder.ToString();

            Assert.Equal(expectedQuery, actualQuery);

            Assert.Empty(queryBuilder.Parameters);
        }

        [Fact]
        public void Test_BuildSelect_For_JSON_Path_B()
        {
            QueryBuilder queryBuilder = new(_queryOptionB);

            _select
                .SetFrom("SalesOrder")
                .AddField("Number", "Order.Number")
                .AddField("Date", "Order.Date")
                .AddField("Customer", "AccountNumber")
                .AddField("Price", "Item.Price")
                .AddField("Quantity", "Item.Quantity")
                .SetFor(JsonMode.Path, "Orders");

            _expectedQueryBuilder
                .AppendLine("SELECT")
                .AppendLine("    [Number] AS [Order.Number]")
                .AppendLine("  , [Date] AS [Order.Date]")
                .AppendLine("  , [Customer] AS [AccountNumber]")
                .AppendLine("  , [Price] AS [Item.Price]")
                .AppendLine("  , [Quantity] AS [Item.Quantity]")
                .AppendLine("FROM")
                .AppendLine("    [SalesOrder]")
                .AppendLine($"FOR JSON PATH")
                .Append($"  , ROOT('Orders')");

            queryBuilder.Build(_select);

            string actualQuery = queryBuilder.GetQuery();

            string expectedQuery = _expectedQueryBuilder.ToString();

            Assert.Equal(expectedQuery, actualQuery);

            Assert.Empty(queryBuilder.Parameters);
        }

        #endregion
    }
}