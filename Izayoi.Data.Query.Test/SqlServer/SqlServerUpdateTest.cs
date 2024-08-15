// ----------------------------------------------------------------------
// @Namespace : Izayoi.Data.Query.Test.SqlServer
// @Class     : SqlServerUpdateTest
// ----------------------------------------------------------------------
namespace Izayoi.Data.Query.Test.SqlServer
{
    using Izayoi.Data.Query;
    using System;
    using System.Data;
    using Xunit;

    public class SqlServerUpdateTest : SqlServerTestBase
    {
        #region Fields

        private Update _update;

        #endregion

        #region Constructors

        public SqlServerUpdateTest(): base()
        {
            _update = new Update();
        }

        #endregion

        #region From and Join Methods

        [Fact]
        public void Test_BuildUpdate_From_Join()
        {
            QueryBuilder queryBuilder = new(_queryOption);

            DateTimeOffset utcNow = DateTimeOffset.UtcNow;

            _update
                .SetTable("posts")
                .AddSet("comment", "comment2")
                .AddSet("updated_at", utcNow)
                .SetFrom("posts", "p")
                .AddJoin(JType.LEFT_JOIN, "users", "u", "u.id = p.user_id")
                .AddWhere("u.name", "=", "name1");

            _expectedQueryBuilder
                .AppendLine("UPDATE [posts]")
                .AppendLine("SET [comment] = @s_0, [updated_at] = @s_1")
                .AppendLine("FROM [posts] AS [p]")
                .AppendLine("LEFT JOIN [users] AS [u] ON (u.id = p.user_id)")
                .Append("WHERE [u].[name] = @w_0");

            queryBuilder.Build(_update);

            string actualQuery = queryBuilder.GetQuery();

            string expectedQuery = _expectedQueryBuilder.ToString();

            Assert.Equal(expectedQuery, actualQuery);

            Assert.Equal(3, queryBuilder.Parameters.Count);

            Assert.Collection(queryBuilder.Parameters,
                p =>
                {
                    Assert.Equal($"@s_0", p.ParameterName);
                    Assert.Equal(DbType.String, p.DbType);
                    Assert.Equal("comment2", p.Value);
                },
                p =>
                {
                    Assert.Equal($"@s_1", p.ParameterName);
                    Assert.Equal(DbType.DateTimeOffset, p.DbType);
                    Assert.Equal(utcNow, p.Value);
                },
                p =>
                {
                    Assert.Equal($"@w_0", p.ParameterName);
                    Assert.Equal(DbType.String, p.DbType);
                    Assert.Equal("name1", p.Value);
                }
            );
        }

        [Fact]
        public void Test_BuildUpdate_From_Join_A()
        {
            QueryBuilder queryBuilder = new(_queryOptionA);

            DateTimeOffset utcNow = DateTimeOffset.UtcNow;

            _update
                .SetTable("posts")
                .AddSet("comment", "comment2")
                .AddSet("updated_at", utcNow)
                .SetFrom("posts", "p")
                .AddJoin(JType.LEFT_JOIN, "users", "u", "u.id = p.user_id")
                .AddWhere("u.name", "=", "name1");

            _expectedQueryBuilder
                .AppendLine("UPDATE")
                .AppendLine("    [posts]")
                .AppendLine("SET")
                .AppendLine("    [comment] = @s_0,")
                .AppendLine("    [updated_at] = @s_1")
                .AppendLine("FROM")
                .AppendLine("    [posts] AS [p]")
                .AppendLine("    LEFT JOIN [users] AS [u]")
                .AppendLine("        ON (u.id = p.user_id)")
                .AppendLine("WHERE")
                .Append("    [u].[name] = @w_0");

            queryBuilder.Build(_update);

            string actualQuery = queryBuilder.GetQuery();

            string expectedQuery = _expectedQueryBuilder.ToString();

            Assert.Equal(expectedQuery, actualQuery);

            Assert.Equal(3, queryBuilder.Parameters.Count);

            Assert.Collection(queryBuilder.Parameters,
                p =>
                {
                    Assert.Equal($"@s_0", p.ParameterName);
                    Assert.Equal(DbType.String, p.DbType);
                    Assert.Equal("comment2", p.Value);
                },
                p =>
                {
                    Assert.Equal($"@s_1", p.ParameterName);
                    Assert.Equal(DbType.DateTimeOffset, p.DbType);
                    Assert.Equal(utcNow, p.Value);
                },
                p =>
                {
                    Assert.Equal($"@w_0", p.ParameterName);
                    Assert.Equal(DbType.String, p.DbType);
                    Assert.Equal("name1", p.Value);
                }
            );
        }

        [Fact]
        public void Test_BuildUpdate_From_Join_B()
        {
            QueryBuilder queryBuilder = new(_queryOptionB);

            DateTimeOffset utcNow = DateTimeOffset.UtcNow;

            _update
                .SetTable("posts")
                .AddSet("comment", "comment2")
                .AddSet("updated_at", utcNow)
                .SetFrom("posts", "p")
                .AddJoin(JType.LEFT_JOIN, "users", "u", "u.id = p.user_id")
                .AddWhere("u.name", "=", "name1");

            _expectedQueryBuilder
                .AppendLine("UPDATE")
                .AppendLine("    [posts]")
                .AppendLine("SET")
                .AppendLine("    [comment] = @s_0")
                .AppendLine("  , [updated_at] = @s_1")
                .AppendLine("FROM")
                .AppendLine("    [posts] AS [p]")
                .AppendLine("    LEFT JOIN [users] AS [u]")
                .AppendLine("        ON (u.id = p.user_id)")
                .AppendLine("WHERE")
                .Append("    [u].[name] = @w_0");

            queryBuilder.Build(_update);

            string actualQuery = queryBuilder.GetQuery();

            string expectedQuery = _expectedQueryBuilder.ToString();

            Assert.Equal(expectedQuery, actualQuery);

            Assert.Equal(3, queryBuilder.Parameters.Count);

            Assert.Collection(queryBuilder.Parameters,
                p =>
                {
                    Assert.Equal($"@s_0", p.ParameterName);
                    Assert.Equal(DbType.String, p.DbType);
                    Assert.Equal("comment2", p.Value);
                },
                p =>
                {
                    Assert.Equal($"@s_1", p.ParameterName);
                    Assert.Equal(DbType.DateTimeOffset, p.DbType);
                    Assert.Equal(utcNow, p.Value);
                },
                p =>
                {
                    Assert.Equal($"@w_0", p.ParameterName);
                    Assert.Equal(DbType.String, p.DbType);
                    Assert.Equal("name1", p.Value);
                }
            );
        }

        [Fact]
        public void Test_BuildUpdate_From_Join_Alias()
        {
            QueryBuilder queryBuilder = new(_queryOption);

            DateTimeOffset utcNow = DateTimeOffset.UtcNow;

            _update
                .SetTable("", "p")
                .AddSet("comment", "comment2")
                .AddSet("updated_at", utcNow)
                .SetFrom("posts", "p")
                .AddJoin(JType.LEFT_JOIN, "users", "u", "u.id = p.user_id")
                .AddWhere("u.name", "=", "name1");

            _expectedQueryBuilder
                .AppendLine("UPDATE [p]")
                .AppendLine("SET [comment] = @s_0, [updated_at] = @s_1")
                .AppendLine("FROM [posts] AS [p]")
                .AppendLine("LEFT JOIN [users] AS [u] ON (u.id = p.user_id)")
                .Append("WHERE [u].[name] = @w_0");

            queryBuilder.Build(_update);

            string actualQuery = queryBuilder.GetQuery();

            string expectedQuery = _expectedQueryBuilder.ToString();

            Assert.Equal(expectedQuery, actualQuery);

            Assert.Equal(3, queryBuilder.Parameters.Count);

            Assert.Collection(queryBuilder.Parameters,
                p =>
                {
                    Assert.Equal($"@s_0", p.ParameterName);
                    Assert.Equal(DbType.String, p.DbType);
                    Assert.Equal("comment2", p.Value);
                },
                p =>
                {
                    Assert.Equal($"@s_1", p.ParameterName);
                    Assert.Equal(DbType.DateTimeOffset, p.DbType);
                    Assert.Equal(utcNow, p.Value);
                },
                p =>
                {
                    Assert.Equal($"@w_0", p.ParameterName);
                    Assert.Equal(DbType.String, p.DbType);
                    Assert.Equal("name1", p.Value);
                }
            );
        }

        [Fact]
        public void Test_BuildUpdate_From_Join_Alias_A()
        {
            QueryBuilder queryBuilder = new(_queryOptionA);

            DateTimeOffset utcNow = DateTimeOffset.UtcNow;

            _update
                .SetTable("", "p")
                .AddSet("comment", "comment2")
                .AddSet("updated_at", utcNow)
                .SetFrom("posts", "p")
                .AddJoin(JType.LEFT_JOIN, "users", "u", "u.id = p.user_id")
                .AddWhere("u.name", "=", "name1");

            _expectedQueryBuilder
                .AppendLine("UPDATE")
                .AppendLine("    [p]")
                .AppendLine("SET")
                .AppendLine("    [comment] = @s_0,")
                .AppendLine("    [updated_at] = @s_1")
                .AppendLine("FROM")
                .AppendLine("    [posts] AS [p]")
                .AppendLine("    LEFT JOIN [users] AS [u]")
                .AppendLine("        ON (u.id = p.user_id)")
                .AppendLine("WHERE")
                .Append("    [u].[name] = @w_0");

            queryBuilder.Build(_update);

            string actualQuery = queryBuilder.GetQuery();

            string expectedQuery = _expectedQueryBuilder.ToString();

            Assert.Equal(expectedQuery, actualQuery);

            Assert.Equal(3, queryBuilder.Parameters.Count);

            Assert.Collection(queryBuilder.Parameters,
                p =>
                {
                    Assert.Equal($"@s_0", p.ParameterName);
                    Assert.Equal(DbType.String, p.DbType);
                    Assert.Equal("comment2", p.Value);
                },
                p =>
                {
                    Assert.Equal($"@s_1", p.ParameterName);
                    Assert.Equal(DbType.DateTimeOffset, p.DbType);
                    Assert.Equal(utcNow, p.Value);
                },
                p =>
                {
                    Assert.Equal($"@w_0", p.ParameterName);
                    Assert.Equal(DbType.String, p.DbType);
                    Assert.Equal("name1", p.Value);
                }
            );
        }

        [Fact]
        public void Test_BuildUpdate_From_Join_Alias_B()
        {
            QueryBuilder queryBuilder = new(_queryOptionB);

            DateTimeOffset utcNow = DateTimeOffset.UtcNow;

            _update
                .SetTable("", "p")
                .AddSet("comment", "comment2")
                .AddSet("updated_at", utcNow)
                .SetFrom("posts", "p")
                .AddJoin(JType.LEFT_JOIN, "users", "u", "u.id = p.user_id")
                .AddWhere("u.name", "=", "name1");

            _expectedQueryBuilder
                .AppendLine("UPDATE")
                .AppendLine("    [p]")
                .AppendLine("SET")
                .AppendLine("    [comment] = @s_0")
                .AppendLine("  , [updated_at] = @s_1")
                .AppendLine("FROM")
                .AppendLine("    [posts] AS [p]")
                .AppendLine("    LEFT JOIN [users] AS [u]")
                .AppendLine("        ON (u.id = p.user_id)")
                .AppendLine("WHERE")
                .Append("    [u].[name] = @w_0");

            queryBuilder.Build(_update);

            string actualQuery = queryBuilder.GetQuery();

            string expectedQuery = _expectedQueryBuilder.ToString();

            Assert.Equal(expectedQuery, actualQuery);

            Assert.Equal(3, queryBuilder.Parameters.Count);

            Assert.Collection(queryBuilder.Parameters,
                p =>
                {
                    Assert.Equal($"@s_0", p.ParameterName);
                    Assert.Equal(DbType.String, p.DbType);
                    Assert.Equal("comment2", p.Value);
                },
                p =>
                {
                    Assert.Equal($"@s_1", p.ParameterName);
                    Assert.Equal(DbType.DateTimeOffset, p.DbType);
                    Assert.Equal(utcNow, p.Value);
                },
                p =>
                {
                    Assert.Equal($"@w_0", p.ParameterName);
                    Assert.Equal(DbType.String, p.DbType);
                    Assert.Equal("name1", p.Value);
                }
            );
        }

        #endregion
    }
}