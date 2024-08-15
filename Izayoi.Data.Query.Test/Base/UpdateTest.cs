// ----------------------------------------------------------------------
// @Namespace : Izayoi.Data.Query.Test
// @Class     : UpdateTest
// ----------------------------------------------------------------------
namespace Izayoi.Data.Query.Test
{
    using Izayoi.Data.Query;
    using System;
    using System.Data;
    using Xunit;

    public class UpdateTest : TestBase
    {
        #region Fields

        private Update _update;

        #endregion

        #region Constructors

        public UpdateTest() : base()
        {
            _update = new Update();
        }

        #endregion

        #region Value Methods

        [Fact]
        public void Test_BuildUpdate()
        {
            QueryBuilder queryBuilder = new(_queryOption);

            DateTimeOffset utcNow = DateTimeOffset.UtcNow;

            _update
                .SetTable("users")
                .AddSet("name", "name1")
                .AddSet("age", 20)
                .AddSet("updated_at", utcNow)
                .AddWhere("id", "=", 1);

            _expectedQueryBuilder
                .AppendLine("UPDATE users")
                .AppendLine("SET name = @s_0, age = @s_1, updated_at = @s_2")
                .Append("WHERE id = @w_0");

            queryBuilder.Build(_update);

            string expectedQuery = _expectedQueryBuilder.ToString();

            string actualQuery = queryBuilder.GetQuery();

            Assert.Equal(expectedQuery, actualQuery);

            Assert.Equal(4, queryBuilder.Parameters.Count);

            Assert.Collection(queryBuilder.Parameters,
                p =>
                {
                    Assert.Equal($"@s_0", p.ParameterName);
                    Assert.Equal(DbType.String, p.DbType);
                    Assert.Equal("name1", p.Value);
                },
                p =>
                {
                    Assert.Equal($"@s_1", p.ParameterName);
                    Assert.Equal(DbType.Int32, p.DbType);
                    Assert.Equal(20, p.Value);
                },
                p =>
                {
                    Assert.Equal($"@s_2", p.ParameterName);
                    Assert.Equal(DbType.DateTimeOffset, p.DbType);
                    Assert.Equal(utcNow, p.Value);
                },
                p =>
                {
                    Assert.Equal($"@w_0", p.ParameterName);
                    Assert.Equal(DbType.Int32, p.DbType);
                    Assert.Equal(1, p.Value);
                }
            );
        }

        [Fact]
        public void Test_BuildUpdate_A()
        {
            QueryBuilder queryBuilder = new(_queryOptionA);

            DateTimeOffset utcNow = DateTimeOffset.UtcNow;

            _update
                .SetTable("users")
                .AddSet("name", "name1")
                .AddSet("age", 20)
                .AddSet("updated_at", utcNow)
                .AddWhere("id", "=", 1);

            _expectedQueryBuilder
                .AppendLine("UPDATE")
                .AppendLine("    users")
                .AppendLine("SET")
                .AppendLine("    name = @s_0,")
                .AppendLine("    age = @s_1,")
                .AppendLine("    updated_at = @s_2")
                .AppendLine("WHERE")
                .Append("    id = @w_0");

            queryBuilder.Build(_update);

            string expectedQuery = _expectedQueryBuilder.ToString();

            string actualQuery = queryBuilder.GetQuery();

            Assert.Equal(expectedQuery, actualQuery);

            Assert.Equal(4, queryBuilder.Parameters.Count);

            Assert.Collection(queryBuilder.Parameters,
                p =>
                {
                    Assert.Equal($"@s_0", p.ParameterName);
                    Assert.Equal(DbType.String, p.DbType);
                    Assert.Equal("name1", p.Value);
                },
                p =>
                {
                    Assert.Equal($"@s_1", p.ParameterName);
                    Assert.Equal(DbType.Int32, p.DbType);
                    Assert.Equal(20, p.Value);
                },
                p =>
                {
                    Assert.Equal($"@s_2", p.ParameterName);
                    Assert.Equal(DbType.DateTimeOffset, p.DbType);
                    Assert.Equal(utcNow, p.Value);
                },
                p =>
                {
                    Assert.Equal($"@w_0", p.ParameterName);
                    Assert.Equal(DbType.Int32, p.DbType);
                    Assert.Equal(1, p.Value);
                }
            );
        }

        [Fact]
        public void Test_BuildUpdate_B()
        {
            QueryBuilder queryBuilder = new(_queryOptionB);

            DateTimeOffset utcNow = DateTimeOffset.UtcNow;

            _update
                .SetTable("users")
                .AddSet("name", "name1")
                .AddSet("age", 20)
                .AddSet("updated_at", utcNow)
                .AddWhere("id", "=", 1);

            _expectedQueryBuilder
                .AppendLine("UPDATE")
                .AppendLine("    users")
                .AppendLine("SET")
                .AppendLine("    name = @s_0")
                .AppendLine("  , age = @s_1")
                .AppendLine("  , updated_at = @s_2")
                .AppendLine("WHERE")
                .Append("    id = @w_0");

            queryBuilder.Build(_update);

            string expectedQuery = _expectedQueryBuilder.ToString();

            string actualQuery = queryBuilder.GetQuery();

            Assert.Equal(expectedQuery, actualQuery);

            Assert.Equal(4, queryBuilder.Parameters.Count);

            Assert.Collection(queryBuilder.Parameters,
                p =>
                {
                    Assert.Equal($"@s_0", p.ParameterName);
                    Assert.Equal(DbType.String, p.DbType);
                    Assert.Equal("name1", p.Value);
                },
                p =>
                {
                    Assert.Equal($"@s_1", p.ParameterName);
                    Assert.Equal(DbType.Int32, p.DbType);
                    Assert.Equal(20, p.Value);
                },
                p =>
                {
                    Assert.Equal($"@s_2", p.ParameterName);
                    Assert.Equal(DbType.DateTimeOffset, p.DbType);
                    Assert.Equal(utcNow, p.Value);
                },
                p =>
                {
                    Assert.Equal($"@w_0", p.ParameterName);
                    Assert.Equal(DbType.Int32, p.DbType);
                    Assert.Equal(1, p.Value);
                }
            );
        }

        #endregion
    }
}