// ----------------------------------------------------------------------
// @Namespace : Izayoi.Data.Query.Test.MySql
// @Class     : MySqlUpdateTest
// ----------------------------------------------------------------------
namespace Izayoi.Data.Query.Test.MySql
{
    using Izayoi.Data.Query;
    using System;
    using System.Data;
    using Xunit;

    public class MySqlUpdateTest : MySqlTestBase
    {
        #region Fields

        private Update _update;

        #endregion

        #region Constructors

        public MySqlUpdateTest(): base()
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
                .AppendLine("UPDATE `users`")
                .AppendLine("SET `name` = @s_0, `age` = @s_1, `updated_at` = @s_2")
                .Append("WHERE `id` = @w_0");

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
                .AppendLine("    `users`")
                .AppendLine("SET")
                .AppendLine("    `name` = @s_0,")
                .AppendLine("    `age` = @s_1,")
                .AppendLine("    `updated_at` = @s_2")
                .AppendLine("WHERE")
                .Append("    `id` = @w_0");

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
                .AppendLine("    `users`")
                .AppendLine("SET")
                .AppendLine("    `name` = @s_0")
                .AppendLine("  , `age` = @s_1")
                .AppendLine("  , `updated_at` = @s_2")
                .AppendLine("WHERE")
                .Append("    `id` = @w_0");

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

        #region Join Methods

        [Fact]
        public void Test_BuildUpdate_From_Join()
        {
            QueryBuilder queryBuilder = new(_queryOption);

            DateTimeOffset utcNow = DateTimeOffset.UtcNow;

            _update
                .SetTable("posts", "p")
                .AddJoin(JType.LEFT_JOIN, "users", "u", "u.id = p.user_id")
                .AddSet("comment", "comment2")
                .AddSet("updated_at", utcNow)
                .AddWhere("u.name", "=", "name1");

            _expectedQueryBuilder
                .AppendLine("UPDATE `posts` AS `p`")
                .AppendLine("LEFT JOIN `users` AS `u` ON (u.id = p.user_id)")
                .AppendLine("SET `comment` = @s_0, `updated_at` = @s_1")
                .Append("WHERE `u`.`name` = @w_0");

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
                .SetTable("posts", "p")
                .AddJoin(JType.LEFT_JOIN, "users", "u", "u.id = p.user_id")
                .AddSet("comment", "comment2")
                .AddSet("updated_at", utcNow)
                .AddWhere("u.name", "=", "name1");

            _expectedQueryBuilder
                .AppendLine("UPDATE")
                .AppendLine("    `posts` AS `p`")
                .AppendLine("    LEFT JOIN `users` AS `u`")
                .AppendLine("        ON (u.id = p.user_id)")
                .AppendLine("SET")
                .AppendLine("    `comment` = @s_0,")
                .AppendLine("    `updated_at` = @s_1")
                .AppendLine("WHERE")
                .Append("    `u`.`name` = @w_0");

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
                .SetTable("posts", "p")
                .AddJoin(JType.LEFT_JOIN, "users", "u", "u.id = p.user_id")
                .AddSet("comment", "comment2")
                .AddSet("updated_at", utcNow)
                .AddWhere("u.name", "=", "name1");

            _expectedQueryBuilder
                .AppendLine("UPDATE")
                .AppendLine("    `posts` AS `p`")
                .AppendLine("    LEFT JOIN `users` AS `u`")
                .AppendLine("        ON (u.id = p.user_id)")
                .AppendLine("SET")
                .AppendLine("    `comment` = @s_0")
                .AppendLine("  , `updated_at` = @s_1")
                .AppendLine("WHERE")
                .Append("    `u`.`name` = @w_0");


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