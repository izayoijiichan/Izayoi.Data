// ----------------------------------------------------------------------
// @Namespace : Izayoi.Data.Query.Test.QuotationMark
// @Class     : QuotationMarkInsertTest
// ----------------------------------------------------------------------
namespace Izayoi.Data.Query.Test.QuotationMark
{
    using Izayoi.Data.Query;
    using System;
    using System.Data;
    using Xunit;

    public class QuotationMarkInsertTest : TestBase
    {
        #region Fields

        private Insert _insert;

        #endregion

        #region Constructors

        public QuotationMarkInsertTest() : base()
        {
            _insert = new Insert();
        }

        #endregion

        #region Value Methods

        [Fact]
        public void Test_BuildInsert_Value()
        {
            QueryBuilder queryBuilder = new(_queryOption);

            DateTimeOffset utcNow = DateTimeOffset.UtcNow;

            _insert.SetInto("users")
                .Values
                    .Add("id", 1)
                    .Add("name", "name1")
                    .Add("age", 20)
                    .Add("created_at", utcNow)
                    .Add("updated_at", utcNow)
                    .Add("deleted", false);

            _expectedQueryBuilder
                .AppendLine("INSERT INTO [users]")
                .AppendLine("([id], [name], [age], [created_at], [updated_at], [deleted])")
                .AppendLine("VALUES")
                .Append("(@v_0, @v_1, @v_2, @v_3, @v_4, @v_5)");

            queryBuilder.Build(_insert);

            string expectedQuery = _expectedQueryBuilder.ToString();

            string actualQuery = queryBuilder.GetQuery();

            Assert.Equal(expectedQuery, actualQuery);

            Assert.Equal(6, queryBuilder.Parameters.Count);

            Assert.All(queryBuilder.Parameters,
                (p, index) =>
                {
                    Assert.Equal($"@v_{index}", p.ParameterName);
                }
            );

            Assert.Collection(queryBuilder.Parameters,
                p =>
                {
                    Assert.Equal(DbType.Int32, p.DbType);
                    Assert.Equal(1, p.Value);
                },
                p =>
                {
                    Assert.Equal(DbType.String, p.DbType);
                    Assert.Equal("name1", p.Value);
                },
                p =>
                {
                    Assert.Equal(DbType.Int32, p.DbType);
                    Assert.Equal(20, p.Value);
                },
                p =>
                {
                    Assert.Equal(DbType.DateTimeOffset, p.DbType);
                    Assert.Equal(utcNow, p.Value);
                },
                p =>
                {
                    Assert.Equal(DbType.DateTimeOffset, p.DbType);
                    Assert.Equal(utcNow, p.Value);
                },
                p =>
                {
                    Assert.Equal(DbType.Boolean, p.DbType);
                    Assert.Equal(false, p.Value);
                }
            );
        }

        [Fact]
        public void Test_BuildInsert_Value_A()
        {
            QueryBuilder queryBuilder = new(_queryOptionA);

            DateTimeOffset utcNow = DateTimeOffset.UtcNow;

            _insert.SetInto("users")
                .Values
                    .Add("id", 1)
                    .Add("name", "name1")
                    .Add("age", 20)
                    .Add("created_at", utcNow)
                    .Add("updated_at", utcNow)
                    .Add("deleted", false);

            _expectedQueryBuilder
                .AppendLine("INSERT")
                .AppendLine("INTO [users]")
                .AppendLine("(")
                .AppendLine("    [id],")
                .AppendLine("    [name],")
                .AppendLine("    [age],")
                .AppendLine("    [created_at],")
                .AppendLine("    [updated_at],")
                .AppendLine("    [deleted]")
                .AppendLine(")")
                .AppendLine("VALUES")
                .AppendLine("(")
                .AppendLine("    @v_0,")
                .AppendLine("    @v_1,")
                .AppendLine("    @v_2,")
                .AppendLine("    @v_3,")
                .AppendLine("    @v_4,")
                .AppendLine("    @v_5")
                .Append(')');

            queryBuilder.Build(_insert);

            string expectedQuery = _expectedQueryBuilder.ToString();

            string actualQuery = queryBuilder.GetQuery();

            Assert.Equal(expectedQuery, actualQuery);

            Assert.Equal(6, queryBuilder.Parameters.Count);

            Assert.All(queryBuilder.Parameters,
                (p, index) =>
                {
                    Assert.Equal($"@v_{index}", p.ParameterName);
                }
            );

            Assert.Collection(queryBuilder.Parameters,
                p =>
                {
                    Assert.Equal(DbType.Int32, p.DbType);
                    Assert.Equal(1, p.Value);
                },
                p =>
                {
                    Assert.Equal(DbType.String, p.DbType);
                    Assert.Equal("name1", p.Value);
                },
                p =>
                {
                    Assert.Equal(DbType.Int32, p.DbType);
                    Assert.Equal(20, p.Value);
                },
                p =>
                {
                    Assert.Equal(DbType.DateTimeOffset, p.DbType);
                    Assert.Equal(utcNow, p.Value);
                },
                p =>
                {
                    Assert.Equal(DbType.DateTimeOffset, p.DbType);
                    Assert.Equal(utcNow, p.Value);
                },
                p =>
                {
                    Assert.Equal(DbType.Boolean, p.DbType);
                    Assert.Equal(false, p.Value);
                }
            );
        }

        [Fact]
        public void Test_BuildInsert_Value_B()
        {
            QueryBuilder queryBuilder = new(_queryOptionB);

            DateTimeOffset utcNow = DateTimeOffset.UtcNow;

            _insert.SetInto("users")
                .Values
                    .Add("id", 1)
                    .Add("name", "name1")
                    .Add("age", 20)
                    .Add("created_at", utcNow)
                    .Add("updated_at", utcNow)
                    .Add("deleted", false);

            _expectedQueryBuilder
                .AppendLine("INSERT")
                .AppendLine("INTO [users]")
                .AppendLine("(")
                .AppendLine("    [id]")
                .AppendLine("  , [name]")
                .AppendLine("  , [age]")
                .AppendLine("  , [created_at]")
                .AppendLine("  , [updated_at]")
                .AppendLine("  , [deleted]")
                .AppendLine(")")
                .AppendLine("VALUES")
                .AppendLine("(")
                .AppendLine("    @v_0")
                .AppendLine("  , @v_1")
                .AppendLine("  , @v_2")
                .AppendLine("  , @v_3")
                .AppendLine("  , @v_4")
                .AppendLine("  , @v_5")
                .Append(')');

            queryBuilder.Build(_insert);

            string expectedQuery = _expectedQueryBuilder.ToString();

            string actualQuery = queryBuilder.GetQuery();

            Assert.Equal(expectedQuery, actualQuery);

            Assert.Equal(6, queryBuilder.Parameters.Count);

            Assert.All(queryBuilder.Parameters,
                (p, index) =>
                {
                    Assert.Equal($"@v_{index}", p.ParameterName);
                }
            );

            Assert.Collection(queryBuilder.Parameters,
                p =>
                {
                    Assert.Equal(DbType.Int32, p.DbType);
                    Assert.Equal(1, p.Value);
                },
                p =>
                {
                    Assert.Equal(DbType.String, p.DbType);
                    Assert.Equal("name1", p.Value);
                },
                p =>
                {
                    Assert.Equal(DbType.Int32, p.DbType);
                    Assert.Equal(20, p.Value);
                },
                p =>
                {
                    Assert.Equal(DbType.DateTimeOffset, p.DbType);
                    Assert.Equal(utcNow, p.Value);
                },
                p =>
                {
                    Assert.Equal(DbType.DateTimeOffset, p.DbType);
                    Assert.Equal(utcNow, p.Value);
                },
                p =>
                {
                    Assert.Equal(DbType.Boolean, p.DbType);
                    Assert.Equal(false, p.Value);
                }
            );
        }

        #endregion

        #region Select Methods

        [Fact]
        public void Test_BuildInsert_Select()
        {
            QueryBuilder queryBuilder = new(_queryOption);

            _insert
                .SetInto("users")
                .Select ??= new Select()
                    .SetFrom("users2")
                    .AddField("id")
                    .AddField("name")
                    .AddField("age")
                    .AddField("created_at")
                    .AddField("updated_at")
                    .AddField("deleted");

            _expectedQueryBuilder
                .AppendLine("INSERT INTO [users]")
                .AppendLine("SELECT [id], [name], [age], [created_at], [updated_at], [deleted]")
                .Append("FROM [users2]");

            queryBuilder.Build(_insert);

            string expectedQuery = _expectedQueryBuilder.ToString();

            string actualQuery = queryBuilder.GetQuery();

            Assert.Equal(expectedQuery, actualQuery);

            Assert.Empty(queryBuilder.Parameters);
        }

        [Fact]
        public void Test_BuildInsert_Select_A()
        {
            QueryBuilder queryBuilder = new(_queryOptionA);

            _insert
                .SetInto("users")
                .Select ??= new Select()
                    .SetFrom("users2")
                    .AddField("id")
                    .AddField("name")
                    .AddField("age")
                    .AddField("created_at")
                    .AddField("updated_at")
                    .AddField("deleted");

            _expectedQueryBuilder
                .AppendLine("INSERT")
                .AppendLine("INTO [users]")
                .AppendLine("SELECT")
                .AppendLine("    [id],")
                .AppendLine("    [name],")
                .AppendLine("    [age],")
                .AppendLine("    [created_at],")
                .AppendLine("    [updated_at],")
                .AppendLine("    [deleted]")
                .AppendLine("FROM")
                .Append("    [users2]");

            queryBuilder.Build(_insert);

            string expectedQuery = _expectedQueryBuilder.ToString();

            string actualQuery = queryBuilder.GetQuery();

            Assert.Equal(expectedQuery, actualQuery);

            Assert.Empty(queryBuilder.Parameters);
        }

        [Fact]
        public void Test_BuildInsert_Select_B()
        {
            QueryBuilder queryBuilder = new(_queryOptionB);

            _insert
                .SetInto("users")
                .Select ??= new Select()
                    .SetFrom("users2")
                    .AddField("id")
                    .AddField("name")
                    .AddField("age")
                    .AddField("created_at")
                    .AddField("updated_at")
                    .AddField("deleted");

            _expectedQueryBuilder
                .AppendLine("INSERT")
                .AppendLine("INTO [users]")
                .AppendLine("SELECT")
                .AppendLine("    [id]")
                .AppendLine("  , [name]")
                .AppendLine("  , [age]")
                .AppendLine("  , [created_at]")
                .AppendLine("  , [updated_at]")
                .AppendLine("  , [deleted]")
                .AppendLine("FROM")
                .Append("    [users2]");

            queryBuilder.Build(_insert);

            string expectedQuery = _expectedQueryBuilder.ToString();

            string actualQuery = queryBuilder.GetQuery();

            Assert.Equal(expectedQuery, actualQuery);

            Assert.Empty(queryBuilder.Parameters);
        }

        [Fact]
        public void Test_BuildInsert_Select_ColumnList()
        {
            QueryBuilder queryBuilder = new(_queryOption);

            _insert
                .SetInto("users")
                    .AddColumn("id")
                    .AddColumn("name")
                    .AddColumn("age")
                    .AddColumn("created_at")
                    .AddColumn("updated_at")
                    .AddColumn("deleted")
                .Select ??= new Select()
                    .SetFrom("users2", "u2")
                    .AddField("u2.id")
                    .AddField("u2.name")
                    .AddField("u2.age")
                    .AddField("u2.created_at")
                    .AddField("u2.updated_at")
                    .AddField("u2.deleted");

            _expectedQueryBuilder
                .AppendLine("INSERT INTO [users]")
                .AppendLine("([id], [name], [age], [created_at], [updated_at], [deleted])")
                .AppendLine("SELECT [u2].[id], [u2].[name], [u2].[age], [u2].[created_at], [u2].[updated_at], [u2].[deleted]")
                .Append("FROM [users2] AS [u2]");

            queryBuilder.Build(_insert);

            string expectedQuery = _expectedQueryBuilder.ToString();

            string actualQuery = queryBuilder.GetQuery();

            Assert.Equal(expectedQuery, actualQuery);

            Assert.Empty(queryBuilder.Parameters);
        }

        [Fact]
        public void Test_BuildInsert_Select_ColumnList_A()
        {
            QueryBuilder queryBuilder = new(_queryOptionA);

            _insert
                .SetInto("users")
                    .AddColumn("id")
                    .AddColumn("name")
                    .AddColumn("age")
                    .AddColumn("created_at")
                    .AddColumn("updated_at")
                    .AddColumn("deleted")
                .Select ??= new Select()
                    .SetFrom("users2", "u2")
                    .AddField("u2.id")
                    .AddField("u2.name")
                    .AddField("u2.age")
                    .AddField("u2.created_at")
                    .AddField("u2.updated_at")
                    .AddField("u2.deleted");

            _expectedQueryBuilder
                .AppendLine("INSERT")
                .AppendLine("INTO [users]")
                .AppendLine("(")
                .AppendLine("    [id],")
                .AppendLine("    [name],")
                .AppendLine("    [age],")
                .AppendLine("    [created_at],")
                .AppendLine("    [updated_at],")
                .AppendLine("    [deleted]")
                .AppendLine(")")
                .AppendLine("SELECT")
                .AppendLine("    [u2].[id],")
                .AppendLine("    [u2].[name],")
                .AppendLine("    [u2].[age],")
                .AppendLine("    [u2].[created_at],")
                .AppendLine("    [u2].[updated_at],")
                .AppendLine("    [u2].[deleted]")
                .AppendLine("FROM")
                .Append("    [users2] AS [u2]");

            queryBuilder.Build(_insert);

            string expectedQuery = _expectedQueryBuilder.ToString();

            string actualQuery = queryBuilder.GetQuery();

            Assert.Equal(expectedQuery, actualQuery);

            Assert.Empty(queryBuilder.Parameters);
        }

        [Fact]
        public void Test_BuildInsert_Select_ColumnList_B()
        {
            QueryBuilder queryBuilder = new(_queryOptionB);

            _insert
                .SetInto("users")
                    .AddColumn("id")
                    .AddColumn("name")
                    .AddColumn("age")
                    .AddColumn("created_at")
                    .AddColumn("updated_at")
                    .AddColumn("deleted")
                .Select ??= new Select()
                    .SetFrom("users2", "u2")
                    .AddField("u2.id")
                    .AddField("u2.name")
                    .AddField("u2.age")
                    .AddField("u2.created_at")
                    .AddField("u2.updated_at")
                    .AddField("u2.deleted");

            _expectedQueryBuilder
                .AppendLine("INSERT")
                .AppendLine("INTO [users]")
                .AppendLine("(")
                .AppendLine("    [id]")
                .AppendLine("  , [name]")
                .AppendLine("  , [age]")
                .AppendLine("  , [created_at]")
                .AppendLine("  , [updated_at]")
                .AppendLine("  , [deleted]")
                .AppendLine(")")
                .AppendLine("SELECT")
                .AppendLine("    [u2].[id]")
                .AppendLine("  , [u2].[name]")
                .AppendLine("  , [u2].[age]")
                .AppendLine("  , [u2].[created_at]")
                .AppendLine("  , [u2].[updated_at]")
                .AppendLine("  , [u2].[deleted]")
                .AppendLine("FROM")
                .Append("    [users2] AS [u2]");


            queryBuilder.Build(_insert);

            string expectedQuery = _expectedQueryBuilder.ToString();

            string actualQuery = queryBuilder.GetQuery();

            Assert.Equal(expectedQuery, actualQuery);

            Assert.Empty(queryBuilder.Parameters);
        }

        #endregion
    }
}