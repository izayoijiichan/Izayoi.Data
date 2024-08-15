// ----------------------------------------------------------------------
// @Namespace : Izayoi.Data.Query.Test
// @Class     : SelectTest
// ----------------------------------------------------------------------
namespace Izayoi.Data.Query.Test
{
    using Izayoi.Data.Query;
    using System.Data;
    using Xunit;

    public class SelectTest : TestBase
    {
        #region Fields

        private Select _select;

        #endregion

        #region Constructors

        public SelectTest(): base()
        {
            _select = new Select();
        }

        #endregion

        #region Select Methods

        [Fact]
        public void Test_BuildSelect_Type_None()
        {
            QueryBuilder queryBuilder = new(_queryOption);

            _select
                .SetType(SType.None)
                .SetFrom("users")
                .AddField("*");

            _expectedQueryBuilder
                .AppendLine("SELECT *")
                .Append("FROM users");

            queryBuilder.Build(_select);

            string expectedQuery = _expectedQueryBuilder.ToString();

            string actualQuery = queryBuilder.GetQuery();

            Assert.Equal(expectedQuery, actualQuery);

            Assert.Empty(queryBuilder.Parameters);
        }

        [Theory]
        [InlineData(false)]
        [InlineData(true)]
        public void Test_BuildSelect_Type_None_AB(bool beforeComma)
        {
            QueryOption queryOption = beforeComma
                ? _queryOptionB
                : _queryOptionA;

            QueryBuilder queryBuilder = new(queryOption);

            _select
                .SetType(SType.None)
                .SetFrom("users")
                .AddField("*");

            _expectedQueryBuilder
                .AppendLine("SELECT")
                .AppendLine("    *")
                .AppendLine("FROM")
                .Append("    users");

            queryBuilder.Build(_select);

            string actualQuery = queryBuilder.GetQuery();

            string expectedQuery = _expectedQueryBuilder.ToString();

            Assert.Equal(expectedQuery, actualQuery);

            Assert.Empty(queryBuilder.Parameters);
        }

        [Fact]
        public void Test_BuildSelect_Type_All()
        {
            QueryBuilder queryBuilder = new(_queryOption);

            _select
                .SetType(SType.ALL)
                .SetFrom("users")
                .AddField("*");

            _expectedQueryBuilder
                .AppendLine("SELECT ALL *")
                .Append("FROM users");

            queryBuilder.Build(_select);

            string expectedQuery = _expectedQueryBuilder.ToString();

            string actualQuery = queryBuilder.GetQuery();

            Assert.Equal(expectedQuery, actualQuery);

            Assert.Empty(queryBuilder.Parameters);
        }

        [Theory]
        [InlineData(false)]
        [InlineData(true)]
        public void Test_BuildSelect_Type_All_AB(bool beforeComma)
        {
            QueryOption queryOption = beforeComma
                ? _queryOptionB
                : _queryOptionA;

            QueryBuilder queryBuilder = new(queryOption);

            _select
                .SetType(SType.ALL)
                .SetFrom("users")
                .AddField("*");

            _expectedQueryBuilder
                .AppendLine("SELECT ALL")
                .AppendLine("    *")
                .AppendLine("FROM")
                .Append("    users");

            queryBuilder.Build(_select);

            string actualQuery = queryBuilder.GetQuery();

            string expectedQuery = _expectedQueryBuilder.ToString();

            Assert.Equal(expectedQuery, actualQuery);

            Assert.Empty(queryBuilder.Parameters);
        }

        [Fact]
        public void Test_BuildSelect_Type_Distinct()
        {
            QueryBuilder queryBuilder = new(_queryOption);

            _select
                .SetType(SType.DISTINCT)
                .SetFrom("users")
                .AddField("*");

            _expectedQueryBuilder
                .AppendLine("SELECT DISTINCT *")
                .Append("FROM users");

            queryBuilder.Build(_select);

            string expectedQuery = _expectedQueryBuilder.ToString();

            string actualQuery = queryBuilder.GetQuery();

            Assert.Equal(expectedQuery, actualQuery);

            Assert.Empty(queryBuilder.Parameters);
        }

        [Theory]
        [InlineData(false)]
        [InlineData(true)]
        public void Test_BuildSelect_Type_Distinct_AB(bool beforeComma)
        {
            QueryOption queryOption = beforeComma
                ? _queryOptionB
                : _queryOptionA;

            QueryBuilder queryBuilder = new(queryOption);

            _select
                .SetType(SType.DISTINCT)
                .SetFrom("users")
                .AddField("*");

            _expectedQueryBuilder
                .AppendLine("SELECT DISTINCT")
                .AppendLine("    *")
                .AppendLine("FROM")
                .Append("    users");

            queryBuilder.Build(_select);

            string actualQuery = queryBuilder.GetQuery();

            string expectedQuery = _expectedQueryBuilder.ToString();

            Assert.Equal(expectedQuery, actualQuery);

            Assert.Empty(queryBuilder.Parameters);
        }

        #endregion

        #region Fields Methods

        [Fact]
        public void Test_BuildSelect_Asterisk()
        {
            QueryBuilder queryBuilder = new(_queryOption);

            _select
                .SetFrom("users")
                .AddField("*");

            _expectedQueryBuilder
                .AppendLine("SELECT *")
                .Append("FROM users");

            queryBuilder.Build(_select);

            string expectedQuery = _expectedQueryBuilder.ToString();

            string actualQuery = queryBuilder.GetQuery();

            Assert.Equal(expectedQuery, actualQuery);

            Assert.Empty(queryBuilder.Parameters);
        }

        [Theory]
        [InlineData(false)]
        [InlineData(true)]
        public void Test_BuildSelect_Asterisk_AB(bool beforeComma)
        {
            QueryOption queryOption = beforeComma
                ? _queryOptionB
                : _queryOptionA;

            QueryBuilder queryBuilder = new(queryOption);

            _select
                .SetFrom("users")
                .AddField("*");

            _expectedQueryBuilder
                .AppendLine("SELECT")
                .AppendLine("    *")
                .AppendLine("FROM")
                .Append("    users");

            queryBuilder.Build(_select);

            string actualQuery = queryBuilder.GetQuery();

            string expectedQuery = _expectedQueryBuilder.ToString();

            Assert.Equal(expectedQuery, actualQuery);

            Assert.Empty(queryBuilder.Parameters);
        }

        [Fact]
        public void Test_BuildSelect_Fields()
        {
            QueryBuilder queryBuilder = new(_queryOption);

            _select
                .SetFrom("users")
                .AddField("id")
                .AddField("name")
                .AddField("age");

            _expectedQueryBuilder
                .AppendLine("SELECT id, name, age")
                .Append("FROM users");

            queryBuilder.Build(_select);

            string actualQuery = queryBuilder.GetQuery();

            string expectedQuery = _expectedQueryBuilder.ToString();

            Assert.Equal(expectedQuery, actualQuery);

            Assert.Empty(queryBuilder.Parameters);
        }

        [Fact]
        public void Test_BuildSelect_Fields_A()
        {
            QueryBuilder queryBuilder = new(_queryOptionA);

            _select
                .SetFrom("users")
                .AddField("id")
                .AddField("name")
                .AddField("age");

            _expectedQueryBuilder
                .AppendLine("SELECT")
                .AppendLine("    id,")
                .AppendLine("    name,")
                .AppendLine("    age")
                .AppendLine("FROM")
                .Append("    users");

            queryBuilder.Build(_select);

            string actualQuery = queryBuilder.GetQuery();

            string expectedQuery = _expectedQueryBuilder.ToString();

            Assert.Equal(expectedQuery, actualQuery);

            Assert.Empty(queryBuilder.Parameters);
        }

        [Fact]
        public void Test_BuildSelect_Fields_B()
        {
            QueryBuilder queryBuilder = new(_queryOptionB);

            _select
                .SetFrom("users")
                .AddField("id")
                .AddField("name")
                .AddField("age");

            _expectedQueryBuilder
                .AppendLine("SELECT")
                .AppendLine("    id")
                .AppendLine("  , name")
                .AppendLine("  , age")
                .AppendLine("FROM")
                .Append("    users");

            queryBuilder.Build(_select);

            string actualQuery = queryBuilder.GetQuery();

            string expectedQuery = _expectedQueryBuilder.ToString();

            Assert.Equal(expectedQuery, actualQuery);

            Assert.Empty(queryBuilder.Parameters);
        }

        #endregion

        #region From Methods

        [Fact]
        public void Test_BuildSelect_From_Alias()
        {
            QueryBuilder queryBuilder = new(_queryOption);

            _select
                .SetFrom("users", "u")
                .AddField("u.*");

            _expectedQueryBuilder
                .AppendLine("SELECT u.*")
                .Append("FROM users AS u");

            queryBuilder.Build(_select);

            string expectedQuery = _expectedQueryBuilder.ToString();

            string actualQuery = queryBuilder.GetQuery();

            Assert.Equal(expectedQuery, actualQuery);

            Assert.Empty(queryBuilder.Parameters);
        }

        [Theory]
        [InlineData(false)]
        [InlineData(true)]
        public void Test_BuildSelect_From_Alias_AB(bool beforeComma)
        {
            QueryOption queryOption = beforeComma
                ? _queryOptionB
                : _queryOptionA;

            QueryBuilder queryBuilder = new(queryOption);

            _select
                .SetFrom("users", "u")
                .AddField("u.*");

            _expectedQueryBuilder
                .AppendLine("SELECT")
                .AppendLine("    u.*")
                .AppendLine("FROM")
                .Append("    users AS u");

            queryBuilder.Build(_select);

            string actualQuery = queryBuilder.GetQuery();

            string expectedQuery = _expectedQueryBuilder.ToString();

            Assert.Equal(expectedQuery, actualQuery);

            Assert.Empty(queryBuilder.Parameters);
        }

        [Fact]
        public void Test_BuildSelect_From_Schema()
        {
            QueryBuilder queryBuilder = new(_queryOption);

            _select
                .SetFrom("schema1", "users", string.Empty)
                .AddField("schema1.users.*");

            _expectedQueryBuilder
                .AppendLine("SELECT schema1.users.*")
                .Append("FROM schema1.users");

            queryBuilder.Build(_select);

            string expectedQuery = _expectedQueryBuilder.ToString();

            string actualQuery = queryBuilder.GetQuery();

            Assert.Equal(expectedQuery, actualQuery);

            Assert.Empty(queryBuilder.Parameters);
        }

        [Theory]
        [InlineData(false)]
        [InlineData(true)]
        public void Test_BuildSelect_From_Schema_AB(bool beforeComma)
        {
            QueryOption queryOption = beforeComma
                ? _queryOptionB
                : _queryOptionA;

            QueryBuilder queryBuilder = new(queryOption);

            _select
                .SetFrom("schema1", "users", string.Empty)
                .AddField("schema1.users.*");

            _expectedQueryBuilder
                .AppendLine("SELECT")
                .AppendLine("    schema1.users.*")
                .AppendLine("FROM")
                .Append("    schema1.users");

            queryBuilder.Build(_select);

            string actualQuery = queryBuilder.GetQuery();

            string expectedQuery = _expectedQueryBuilder.ToString();

            Assert.Equal(expectedQuery, actualQuery);

            Assert.Empty(queryBuilder.Parameters);
        }

        [Fact]
        public void Test_BuildSelect_From_Schema_and_Alias()
        {
            QueryBuilder queryBuilder = new(_queryOption);

            _select
                .SetFrom("schema1", "users", "s1u")
                .AddField("s1u.*");

            _expectedQueryBuilder
                .AppendLine("SELECT s1u.*")
                .Append("FROM schema1.users AS s1u");

            queryBuilder.Build(_select);

            string expectedQuery = _expectedQueryBuilder.ToString();

            string actualQuery = queryBuilder.GetQuery();

            Assert.Equal(expectedQuery, actualQuery);

            Assert.Empty(queryBuilder.Parameters);
        }

        [Theory]
        [InlineData(false)]
        [InlineData(true)]
        public void Test_BuildSelect_From_Schema_and_Alias_AB(bool beforeComma)
        {
            QueryOption queryOption = beforeComma
                ? _queryOptionB
                : _queryOptionA;

            QueryBuilder queryBuilder = new(queryOption);

            _select
                .SetFrom("schema1", "users", "s1u")
                .AddField("s1u.*");

            _expectedQueryBuilder
                .AppendLine("SELECT")
                .AppendLine("    s1u.*")
                .AppendLine("FROM")
                .Append("    schema1.users AS s1u");

            queryBuilder.Build(_select);

            string actualQuery = queryBuilder.GetQuery();

            string expectedQuery = _expectedQueryBuilder.ToString();

            Assert.Equal(expectedQuery, actualQuery);

            Assert.Empty(queryBuilder.Parameters);
        }

        #endregion

        #region Join Methods

        [Fact]
        public void Test_BuildSelect_Join()
        {
            QueryBuilder queryBuilder = new(_queryOption);

            _select
                .SetFrom("posts")
                .AddJoin(JType.LEFT_JOIN, "users", "users.id = posts.user_id")
                .AddField("posts.id")
                .AddField("posts.posted_at")
                .AddField("posts.comment")
                .AddField("posts.user_id")
                .AddField("users.name", "user_name");

            _expectedQueryBuilder
                .AppendLine("SELECT posts.id, posts.posted_at, posts.comment, posts.user_id, users.name AS user_name")
                .AppendLine("FROM posts")
                .Append("LEFT JOIN users ON (users.id = posts.user_id)");

            queryBuilder.Build(_select);

            string actualQuery = queryBuilder.GetQuery();

            string expectedQuery = _expectedQueryBuilder.ToString();

            Assert.Equal(expectedQuery, actualQuery);

            Assert.Empty(queryBuilder.Parameters);
        }

        [Fact]
        public void Test_BuildSelect_Join_A()
        {
            QueryBuilder queryBuilder = new(_queryOptionA);

            _select
                .SetFrom("posts")
                .AddJoin(JType.LEFT_JOIN, "users", "users.id = posts.user_id")
                .AddField("posts.id")
                .AddField("posts.posted_at")
                .AddField("posts.comment")
                .AddField("posts.user_id")
                .AddField("users.name", "user_name");

            _expectedQueryBuilder
                .AppendLine("SELECT")
                .AppendLine("    posts.id,")
                .AppendLine("    posts.posted_at,")
                .AppendLine("    posts.comment,")
                .AppendLine("    posts.user_id,")
                .AppendLine("    users.name AS user_name")
                .AppendLine("FROM")
                .AppendLine("    posts")
                .AppendLine("    LEFT JOIN users")
                .Append("        ON (users.id = posts.user_id)");

            queryBuilder.Build(_select);

            string actualQuery = queryBuilder.GetQuery();

            string expectedQuery = _expectedQueryBuilder.ToString();

            Assert.Equal(expectedQuery, actualQuery);

            Assert.Empty(queryBuilder.Parameters);
        }

        [Fact]
        public void Test_BuildSelect_Join_B()
        {
            QueryBuilder queryBuilder = new(_queryOptionB);

            _select
                .SetFrom("posts")
                .AddJoin(JType.LEFT_JOIN, "users", "users.id = posts.user_id")
                .AddField("posts.id")
                .AddField("posts.posted_at")
                .AddField("posts.comment")
                .AddField("posts.user_id")
                .AddField("users.name", "user_name");

            _expectedQueryBuilder
                .AppendLine("SELECT")
                .AppendLine("    posts.id")
                .AppendLine("  , posts.posted_at")
                .AppendLine("  , posts.comment")
                .AppendLine("  , posts.user_id")
                .AppendLine("  , users.name AS user_name")
                .AppendLine("FROM")
                .AppendLine("    posts")
                .AppendLine("    LEFT JOIN users")
                .Append("        ON (users.id = posts.user_id)");

            queryBuilder.Build(_select);

            string actualQuery = queryBuilder.GetQuery();

            string expectedQuery = _expectedQueryBuilder.ToString();

            Assert.Equal(expectedQuery, actualQuery);

            Assert.Empty(queryBuilder.Parameters);
        }

        #endregion

        #region Where Methods

        [Fact]
        public void Test_BuildSelect_Where()
        {
            QueryBuilder queryBuilder = new(_queryOption);

            _select
                .SetFrom("users")
                .AddField("*")
                .AddWhere("age", "=", 20);

            _expectedQueryBuilder
                .AppendLine("SELECT *")
                .AppendLine("FROM users")
                .Append("WHERE age = @w_0");

            queryBuilder.Build(_select);

            string actualQuery = queryBuilder.GetQuery();

            string expectedQuery = _expectedQueryBuilder.ToString();

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
                    Assert.Equal(20, p.Value);
                }
            );
        }

        [Theory]
        [InlineData(false)]
        [InlineData(true)]
        public void Test_BuildSelect_Where_AB(bool beforeComma)
        {
            QueryOption queryOption = beforeComma
                ? _queryOptionB
                : _queryOptionA;

            QueryBuilder queryBuilder = new(queryOption);

            _select
                .SetFrom("users")
                .AddField("*")
                .AddWhere("age", "=", 20);

            _expectedQueryBuilder
                .AppendLine("SELECT")
                .AppendLine("    *")
                .AppendLine("FROM")
                .AppendLine("    users")
                .AppendLine("WHERE")
                .Append("    age = @w_0");

            queryBuilder.Build(_select);

            string actualQuery = queryBuilder.GetQuery();

            string expectedQuery = _expectedQueryBuilder.ToString();

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
                    Assert.Equal(20, p.Value);
                }
            );
        }

        [Fact]
        public void Test_BuildSelect_Where_between()
        {
            QueryBuilder queryBuilder = new(_queryOption);

            _select
                .SetFrom("users")
                .AddField("*")
                .AddWhere("age", OpType.BETWEEN, new int[] { 20, 30 });

            _expectedQueryBuilder
                .AppendLine("SELECT *")
                .AppendLine("FROM users")
                .Append("WHERE age BETWEEN @w_0_0 AND @w_0_1");

            queryBuilder.Build(_select);

            string actualQuery = queryBuilder.GetQuery();

            string expectedQuery = _expectedQueryBuilder.ToString();

            Assert.Equal(expectedQuery, actualQuery);

            Assert.Equal(2, queryBuilder.Parameters.Count);

            Assert.Collection(queryBuilder.Parameters,
                p =>
                {
                    Assert.Equal("@w_0_0", p.ParameterName);
                    Assert.Equal(DbType.Int32, p.DbType);
                    Assert.Equal(20, p.Value);
                },
                p =>
                {
                    Assert.Equal("@w_0_1", p.ParameterName);
                    Assert.Equal(DbType.Int32, p.DbType);
                    Assert.Equal(30, p.Value);
                }
            );
        }

        [Fact]
        public void Test_BuildSelect_Where_not_between()
        {
            QueryBuilder queryBuilder = new(_queryOption);

            _select
                .SetFrom("users")
                .AddField("*")
                .AddWhere("age", OpType.NOT_BETWEEN, new int[] { 20, 30 });

            _expectedQueryBuilder
                .AppendLine("SELECT *")
                .AppendLine("FROM users")
                .Append("WHERE age NOT BETWEEN @w_0_0 AND @w_0_1");

            queryBuilder.Build(_select);

            string actualQuery = queryBuilder.GetQuery();

            string expectedQuery = _expectedQueryBuilder.ToString();

            Assert.Equal(expectedQuery, actualQuery);

            Assert.Equal(2, queryBuilder.Parameters.Count);

            Assert.Collection(queryBuilder.Parameters,
                p =>
                {
                    Assert.Equal("@w_0_0", p.ParameterName);
                    Assert.Equal(DbType.Int32, p.DbType);
                    Assert.Equal(20, p.Value);
                },
                p =>
                {
                    Assert.Equal("@w_0_1", p.ParameterName);
                    Assert.Equal(DbType.Int32, p.DbType);
                    Assert.Equal(30, p.Value);
                }
            );
        }

        [Fact]
        public void Test_BuildSelect_Where_in()
        {
            QueryBuilder queryBuilder = new(_queryOption);

            _select
                .SetFrom("users")
                .AddField("*")
                .AddWhere("age", OpType.IN, new int[] { 20, 30, 40 });

            _expectedQueryBuilder
                .AppendLine("SELECT *")
                .AppendLine("FROM users")
                .Append("WHERE age IN (@w_0_0, @w_0_1, @w_0_2)");

            queryBuilder.Build(_select);

            string actualQuery = queryBuilder.GetQuery();

            string expectedQuery = _expectedQueryBuilder.ToString();

            Assert.Equal(expectedQuery, actualQuery);

            Assert.Equal(3, queryBuilder.Parameters.Count);

            Assert.Collection(queryBuilder.Parameters,
                p =>
                {
                    Assert.Equal("@w_0_0", p.ParameterName);
                    Assert.Equal(DbType.Int32, p.DbType);
                    Assert.Equal(20, p.Value);
                },
                p =>
                {
                    Assert.Equal("@w_0_1", p.ParameterName);
                    Assert.Equal(DbType.Int32, p.DbType);
                    Assert.Equal(30, p.Value);
                },
                p =>
                {
                    Assert.Equal("@w_0_2", p.ParameterName);
                    Assert.Equal(DbType.Int32, p.DbType);
                    Assert.Equal(40, p.Value);
                }
            );
        }

        [Fact]
        public void Test_BuildSelect_Where_not_in()
        {
            QueryBuilder queryBuilder = new(_queryOption);

            _select
                .SetFrom("users")
                .AddField("*")
                .AddWhere("age", OpType.NOT_IN, new int[] { 20, 30, 40 });

            _expectedQueryBuilder
                .AppendLine("SELECT *")
                .AppendLine("FROM users")
                .Append("WHERE age NOT IN (@w_0_0, @w_0_1, @w_0_2)");

            queryBuilder.Build(_select);

            string actualQuery = queryBuilder.GetQuery();

            string expectedQuery = _expectedQueryBuilder.ToString();

            Assert.Equal(expectedQuery, actualQuery);

            Assert.Equal(3, queryBuilder.Parameters.Count);

            Assert.Collection(queryBuilder.Parameters,
                p =>
                {
                    Assert.Equal("@w_0_0", p.ParameterName);
                    Assert.Equal(DbType.Int32, p.DbType);
                    Assert.Equal(20, p.Value);
                },
                p =>
                {
                    Assert.Equal("@w_0_1", p.ParameterName);
                    Assert.Equal(DbType.Int32, p.DbType);
                    Assert.Equal(30, p.Value);
                },
                p =>
                {
                    Assert.Equal("@w_0_2", p.ParameterName);
                    Assert.Equal(DbType.Int32, p.DbType);
                    Assert.Equal(40, p.Value);
                }
            );
        }

        [Fact]
        public void Test_BuildSelect_Where_is_null()
        {
            QueryBuilder queryBuilder = new(_queryOption);

            _select
                .SetFrom("users")
                .AddField("*")
                .AddWhere("name", OpType.IS_NULL);

            _expectedQueryBuilder
                .AppendLine("SELECT *")
                .AppendLine("FROM users")
                .Append("WHERE name IS NULL");

            queryBuilder.Build(_select);

            string actualQuery = queryBuilder.GetQuery();

            string expectedQuery = _expectedQueryBuilder.ToString();

            Assert.Equal(expectedQuery, actualQuery);

            Assert.Empty(queryBuilder.Parameters);
        }

        [Fact]
        public void Test_BuildSelect_Where_is_null_value()
        {
            QueryBuilder queryBuilder = new(_queryOption);

            _select
                .SetFrom("users")
                .AddField("*")
                .AddWhere("name", "is", null);

            _expectedQueryBuilder
                .AppendLine("SELECT *")
                .AppendLine("FROM users")
                .Append("WHERE name IS NULL");

            queryBuilder.Build(_select);

            string actualQuery = queryBuilder.GetQuery();

            string expectedQuery = _expectedQueryBuilder.ToString();

            Assert.Equal(expectedQuery, actualQuery);

            Assert.Empty(queryBuilder.Parameters);
        }

        [Fact]
        public void Test_BuildSelect_Where_is_not_null()
        {
            QueryBuilder queryBuilder = new(_queryOption);

            _select
                .SetFrom("users")
                .AddField("*")
                .AddWhere("name", OpType.IS_NOT_NULL);

            _expectedQueryBuilder
                .AppendLine("SELECT *")
                .AppendLine("FROM users")
                .Append("WHERE name IS NOT NULL");

            queryBuilder.Build(_select);

            string actualQuery = queryBuilder.GetQuery();

            string expectedQuery = _expectedQueryBuilder.ToString();

            Assert.Equal(expectedQuery, actualQuery);

            Assert.Empty(queryBuilder.Parameters);
        }

        [Fact]
        public void Test_BuildSelect_Where_is_not_null_value()
        {
            QueryBuilder queryBuilder = new(_queryOption);

            _select
                .SetFrom("users")
                .AddField("*")
                .AddWhere("name", "is not", null);

            _expectedQueryBuilder
                .AppendLine("SELECT *")
                .AppendLine("FROM users")
                .Append("WHERE name IS NOT NULL");

            queryBuilder.Build(_select);

            string actualQuery = queryBuilder.GetQuery();

            string expectedQuery = _expectedQueryBuilder.ToString();

            Assert.Equal(expectedQuery, actualQuery);

            Assert.Empty(queryBuilder.Parameters);
        }

        [Fact]
        public void Test_BuildSelect_Where_like()
        {
            QueryBuilder queryBuilder = new(_queryOption);

            _select
                .SetFrom("users")
                .AddField("*")
                .AddWhere("name", OpType.LIKE, "name%");

            _expectedQueryBuilder
                .AppendLine("SELECT *")
                .AppendLine("FROM users")
                .Append("WHERE name LIKE @w_0");

            queryBuilder.Build(_select);

            string actualQuery = queryBuilder.GetQuery();

            string expectedQuery = _expectedQueryBuilder.ToString();

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
                    Assert.Equal(DbType.String, p.DbType);
                    Assert.Equal("name%", p.Value);
                }
            );
        }

        [Fact]
        public void Test_BuildSelect_Where_not_like()
        {
            QueryBuilder queryBuilder = new(_queryOption);

            _select
                .SetFrom("users")
                .AddField("*")
                .AddWhere("name", OpType.NOT_LIKE, "name%");

            _expectedQueryBuilder
                .AppendLine("SELECT *")
                .AppendLine("FROM users")
                .Append("WHERE name NOT LIKE @w_0");

            queryBuilder.Build(_select);

            string actualQuery = queryBuilder.GetQuery();

            string expectedQuery = _expectedQueryBuilder.ToString();

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
                    Assert.Equal(DbType.String, p.DbType);
                    Assert.Equal("name%", p.Value);
                }
            );
        }

        [Fact]
        public void Test_BuildSelect_Where_2()
        {
            QueryBuilder queryBuilder = new(_queryOption);

            _select
                .SetFrom("users")
                .AddField("*")
                .AddWhere("age", "=", 20)
                .AddWhere("deleted", "=", false);

            _expectedQueryBuilder
                .AppendLine("SELECT *")
                .AppendLine("FROM users")
                .Append("WHERE age = @w_0 AND deleted = @w_1");

            queryBuilder.Build(_select);

            string actualQuery = queryBuilder.GetQuery();

            string expectedQuery = _expectedQueryBuilder.ToString();

            Assert.Equal(expectedQuery, actualQuery);

            Assert.Equal(2, queryBuilder.Parameters.Count);

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
                    Assert.Equal(20, p.Value);
                },
                p =>
                {
                    Assert.Equal(DbType.Boolean, p.DbType);
                    Assert.Equal(false, p.Value);
                }
            );
        }

        [Theory]
        [InlineData(false)]
        [InlineData(true)]
        public void Test_BuildSelect_Where_2_AB(bool beforeComma)
        {
            QueryOption queryOption = beforeComma
                ? _queryOptionB
                : _queryOptionA;

            QueryBuilder queryBuilder = new(queryOption);

            _select
                .SetFrom("users")
                .AddField("*")
                .AddWhere("age", "=", 20)
                .AddWhere("deleted", "=", false);

            _expectedQueryBuilder
                .AppendLine("SELECT")
                .AppendLine("    *")
                .AppendLine("FROM")
                .AppendLine("    users")
                .AppendLine("WHERE")
                .AppendLine("    age = @w_0")
                .AppendLine("  AND")
                .Append("    deleted = @w_1");

            queryBuilder.Build(_select);

            string actualQuery = queryBuilder.GetQuery();

            string expectedQuery = _expectedQueryBuilder.ToString();

            Assert.Equal(expectedQuery, actualQuery);

            Assert.Equal(2, queryBuilder.Parameters.Count);

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
                    Assert.Equal(20, p.Value);
                },
                p =>
                {
                    Assert.Equal(DbType.Boolean, p.DbType);
                    Assert.Equal(false, p.Value);
                }
            );
        }

        [Fact]
        public void Test_BuildSelect_Where_and_3()
        {
            QueryBuilder queryBuilder = new(_queryOption);

            _select
                .SetFrom("users")
                .AddField("*")
                .AddWhere("name", "=", "name1")
                .AddWhere(CType.AND, "age", "=", 20)
                .AddWhere(CType.AND, "deleted", "=", false);

            _expectedQueryBuilder
                .AppendLine("SELECT *")
                .AppendLine("FROM users")
                .Append("WHERE name = @w_0 AND age = @w_1 AND deleted = @w_2");

            queryBuilder.Build(_select);

            string actualQuery = queryBuilder.GetQuery();

            string expectedQuery = _expectedQueryBuilder.ToString();

            Assert.Equal(expectedQuery, actualQuery);

            Assert.Equal(3, queryBuilder.Parameters.Count);

            Assert.All(queryBuilder.Parameters,
                (p, index) =>
                {
                    Assert.Equal($"@w_{index}", p.ParameterName);
                }
            );

            Assert.Collection(queryBuilder.Parameters,
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
                    Assert.Equal(DbType.Boolean, p.DbType);
                    Assert.Equal(false, p.Value);
                }
            );
        }

        [Theory]
        [InlineData(false)]
        [InlineData(true)]
        public void Test_BuildSelect_Where_and_3_AB(bool beforeComma)
        {
            QueryOption queryOption = beforeComma
                ? _queryOptionB
                : _queryOptionA;

            QueryBuilder queryBuilder = new(queryOption);

            _select
                .SetFrom("users")
                .AddField("*")
                .AddWhere("name", "=", "name1")
                .AddWhere(CType.AND, "age", "=", 20)
                .AddWhere(CType.AND, "deleted", "=", false);

            _expectedQueryBuilder
                .AppendLine("SELECT")
                .AppendLine("    *")
                .AppendLine("FROM")
                .AppendLine("    users")
                .AppendLine("WHERE")
                .AppendLine("    name = @w_0")
                .AppendLine("  AND")
                .AppendLine("    age = @w_1")
                .AppendLine("  AND")
                .Append("    deleted = @w_2");

            queryBuilder.Build(_select);

            string actualQuery = queryBuilder.GetQuery();

            string expectedQuery = _expectedQueryBuilder.ToString();

            Assert.Equal(expectedQuery, actualQuery);

            Assert.Equal(3, queryBuilder.Parameters.Count);

            Assert.All(queryBuilder.Parameters,
                (p, index) =>
                {
                    Assert.Equal($"@w_{index}", p.ParameterName);
                }
            );

            Assert.Collection(queryBuilder.Parameters,
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
                    Assert.Equal(DbType.Boolean, p.DbType);
                    Assert.Equal(false, p.Value);
                }
            );
        }

        [Fact]
        public void Test_BuildSelect_Where_or_2()
        {
            QueryBuilder queryBuilder = new(_queryOption);

            _select
                .SetFrom("users")
                .AddField("*")
                .AddWhere('(', "age", "=", 20)
                .AddWhere(CType.OR, "age", "=", 30, ')');

            _expectedQueryBuilder
                .AppendLine("SELECT *")
                .AppendLine("FROM users")
                .Append("WHERE (age = @w_0 OR age = @w_1)");

            queryBuilder.Build(_select);

            string actualQuery = queryBuilder.GetQuery();

            string expectedQuery = _expectedQueryBuilder.ToString();

            Assert.Equal(expectedQuery, actualQuery);

            Assert.Equal(2, queryBuilder.Parameters.Count);

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
                    Assert.Equal(20, p.Value);
                },
                p =>
                {
                    Assert.Equal(DbType.Int32, p.DbType);
                    Assert.Equal(30, p.Value);
                }
            );
        }

        [Theory]
        [InlineData(false)]
        [InlineData(true)]
        public void Test_BuildSelect_Where_or_2_AB(bool beforeComma)
        {
            QueryOption queryOption = beforeComma
                ? _queryOptionB
                : _queryOptionA;

            QueryBuilder queryBuilder = new(queryOption);

            _select
                .SetFrom("users")
                .AddField("*")
                .AddWhere('(', "age", "=", 20)
                .AddWhere(CType.OR, "age", "=", 30, ')');

            _expectedQueryBuilder
                .AppendLine("SELECT")
                .AppendLine("    *")
                .AppendLine("FROM")
                .AppendLine("    users")
                .AppendLine("WHERE")
                .AppendLine("    (")
                .AppendLine("    age = @w_0")
                .AppendLine("  OR")
                .AppendLine("    age = @w_1")
                .Append("    )");

            queryBuilder.Build(_select);

            string actualQuery = queryBuilder.GetQuery();

            string expectedQuery = _expectedQueryBuilder.ToString();

            Assert.Equal(expectedQuery, actualQuery);

            Assert.Equal(2, queryBuilder.Parameters.Count);

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
                    Assert.Equal(20, p.Value);
                },
                p =>
                {
                    Assert.Equal(DbType.Int32, p.DbType);
                    Assert.Equal(30, p.Value);
                }
            );
        }

        [Fact]
        public void Test_BuildSelect_Where_or_3()
        {
            QueryBuilder queryBuilder = new(_queryOption);

            _select
                .SetFrom("users")
                .AddField("*")
                .AddWhere('(', "age", "=", 20)
                .AddWhere(CType.OR, "age", "=", 30)
                .AddWhere(CType.OR, "age", "=", 40, ')');

            _expectedQueryBuilder
                .AppendLine("SELECT *")
                .AppendLine("FROM users")
                .Append("WHERE (age = @w_0 OR age = @w_1 OR age = @w_2)");

            queryBuilder.Build(_select);

            string actualQuery = queryBuilder.GetQuery();

            string expectedQuery = _expectedQueryBuilder.ToString();

            Assert.Equal(expectedQuery, actualQuery);

            Assert.Equal(3, queryBuilder.Parameters.Count);

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
                    Assert.Equal(20, p.Value);
                },
                p =>
                {
                    Assert.Equal(DbType.Int32, p.DbType);
                    Assert.Equal(30, p.Value);
                },
                p =>
                {
                    Assert.Equal(DbType.Int32, p.DbType);
                    Assert.Equal(40, p.Value);
                }
            );
        }

        [Theory]
        [InlineData(false)]
        [InlineData(true)]
        public void Test_BuildSelect_Where_or_3_AB(bool beforeComma)
        {
            QueryOption queryOption = beforeComma
                ? _queryOptionB
                : _queryOptionA;

            QueryBuilder queryBuilder = new(queryOption);

            _select
                .SetFrom("users")
                .AddField("*")
                .AddWhere('(', "age", "=", 20)
                .AddWhere(CType.OR, "age", "=", 30)
                .AddWhere(CType.OR, "age", "=", 40, ')');

            _expectedQueryBuilder
                .AppendLine("SELECT")
                .AppendLine("    *")
                .AppendLine("FROM")
                .AppendLine("    users")
                .AppendLine("WHERE")
                .AppendLine("    (")
                .AppendLine("    age = @w_0")
                .AppendLine("  OR")
                .AppendLine("    age = @w_1")
                .AppendLine("  OR")
                .AppendLine("    age = @w_2")
                .Append("    )");

            queryBuilder.Build(_select);

            string actualQuery = queryBuilder.GetQuery();

            string expectedQuery = _expectedQueryBuilder.ToString();

            Assert.Equal(expectedQuery, actualQuery);

            Assert.Equal(3, queryBuilder.Parameters.Count);

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
                    Assert.Equal(20, p.Value);
                },
                p =>
                {
                    Assert.Equal(DbType.Int32, p.DbType);
                    Assert.Equal(30, p.Value);
                },
                p =>
                {
                    Assert.Equal(DbType.Int32, p.DbType);
                    Assert.Equal(40, p.Value);
                }
            );
        }

        #endregion

        #region Where with Join Methods

        [Fact]
        public void Test_BuildSelect_Where_with_Join()
        {
            QueryBuilder queryBuilder = new(_queryOption);

            _select
                .SetFrom("posts")
                .AddJoin(JType.LEFT_JOIN, "users", "users.id = posts.user_id")
                .AddField("posts.id")
                .AddField("posts.posted_at")
                .AddField("posts.comment")
                .AddField("posts.user_id")
                .AddField("users.name", "user_name")
                .AddWhere("users.age", "<", 18);

            _expectedQueryBuilder
                .AppendLine("SELECT posts.id, posts.posted_at, posts.comment, posts.user_id, users.name AS user_name")
                .AppendLine("FROM posts")
                .AppendLine("LEFT JOIN users ON (users.id = posts.user_id)")
                .Append("WHERE users.age < @w_0");

            queryBuilder.Build(_select);

            string actualQuery = queryBuilder.GetQuery();

            string expectedQuery = _expectedQueryBuilder.ToString();

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
                    Assert.Equal(18, p.Value);
                }
            );
        }

        [Fact]
        public void Test_BuildSelect_Where_with_Join_A()
        {
            QueryBuilder queryBuilder = new(_queryOptionA);

            _select
                .SetFrom("posts")
                .AddJoin(JType.LEFT_JOIN, "users", "users.id = posts.user_id")
                .AddField("posts.id")
                .AddField("posts.posted_at")
                .AddField("posts.comment")
                .AddField("posts.user_id")
                .AddField("users.name", "user_name")
                .AddWhere("users.age", "<", 18);

            _expectedQueryBuilder
                .AppendLine("SELECT")
                .AppendLine("    posts.id,")
                .AppendLine("    posts.posted_at,")
                .AppendLine("    posts.comment,")
                .AppendLine("    posts.user_id,")
                .AppendLine("    users.name AS user_name")
                .AppendLine("FROM")
                .AppendLine("    posts")
                .AppendLine("    LEFT JOIN users")
                .AppendLine("        ON (users.id = posts.user_id)")
                .AppendLine("WHERE")
                .Append("    users.age < @w_0");

            queryBuilder.Build(_select);

            string actualQuery = queryBuilder.GetQuery();

            string expectedQuery = _expectedQueryBuilder.ToString();

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
                    Assert.Equal(18, p.Value);
                }
            );
        }

        [Fact]
        public void Test_BuildSelect_Where_with_Join_B()
        {
            QueryBuilder queryBuilder = new(_queryOptionB);

            _select
                .SetFrom("posts")
                .AddJoin(JType.LEFT_JOIN, "users", "users.id = posts.user_id")
                .AddField("posts.id")
                .AddField("posts.posted_at")
                .AddField("posts.comment")
                .AddField("posts.user_id")
                .AddField("users.name", "user_name")
                .AddWhere("users.age", "<", 18);

            _expectedQueryBuilder
                .AppendLine("SELECT")
                .AppendLine("    posts.id")
                .AppendLine("  , posts.posted_at")
                .AppendLine("  , posts.comment")
                .AppendLine("  , posts.user_id")
                .AppendLine("  , users.name AS user_name")
                .AppendLine("FROM")
                .AppendLine("    posts")
                .AppendLine("    LEFT JOIN users")
                .AppendLine("        ON (users.id = posts.user_id)")
                .AppendLine("WHERE")
                .Append("    users.age < @w_0");

            queryBuilder.Build(_select);

            string actualQuery = queryBuilder.GetQuery();

            string expectedQuery = _expectedQueryBuilder.ToString();

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
                    Assert.Equal(18, p.Value);
                }
            );
        }

        #endregion

        #region Group Methods

        [Fact]
        public void Test_BuildSelect_Group_1()
        {
            QueryBuilder queryBuilder = new(_queryOption);

            _select
                .SetFrom("posts")
                .AddField("user_id")
                .AddField("COUNT(comment)", "post_count")
                .AddGroup("user_id");

            _expectedQueryBuilder
                .AppendLine("SELECT user_id, COUNT(comment) AS post_count")
                .AppendLine("FROM posts")
                .Append("GROUP BY user_id");

            queryBuilder.Build(_select);

            string actualQuery = queryBuilder.GetQuery();

            string expectedQuery = _expectedQueryBuilder.ToString();

            Assert.Equal(expectedQuery, actualQuery);

            Assert.Empty(queryBuilder.Parameters);
        }

        [Fact]
        public void Test_BuildSelect_Group_1_A()
        {
            QueryBuilder queryBuilder = new(_queryOptionA);

            _select
                .SetFrom("posts")
                .AddField("user_id")
                .AddField("COUNT(comment)", "post_count")
                .AddGroup("user_id");

            _expectedQueryBuilder
                .AppendLine("SELECT")
                .AppendLine("    user_id,")
                .AppendLine("    COUNT(comment) AS post_count")
                .AppendLine("FROM")
                .AppendLine("    posts")
                .AppendLine("GROUP BY")
                .Append("    user_id");

            queryBuilder.Build(_select);

            string actualQuery = queryBuilder.GetQuery();

            string expectedQuery = _expectedQueryBuilder.ToString();

            Assert.Equal(expectedQuery, actualQuery);

            Assert.Empty(queryBuilder.Parameters);
        }

        [Fact]
        public void Test_BuildSelect_Group_1_B()
        {
            QueryBuilder queryBuilder = new(_queryOptionB);

            _select
                .SetFrom("posts")
                .AddField("user_id")
                .AddField("COUNT(comment)", "post_count")
                .AddGroup("user_id");

            _expectedQueryBuilder
                .AppendLine("SELECT")
                .AppendLine("    user_id")
                .AppendLine("  , COUNT(comment) AS post_count")
                .AppendLine("FROM")
                .AppendLine("    posts")
                .AppendLine("GROUP BY")
                .Append("    user_id");

            queryBuilder.Build(_select);

            string actualQuery = queryBuilder.GetQuery();

            string expectedQuery = _expectedQueryBuilder.ToString();

            Assert.Equal(expectedQuery, actualQuery);

            Assert.Empty(queryBuilder.Parameters);
        }

        [Fact]
        public void Test_BuildSelect_Group_2()
        {
            QueryBuilder queryBuilder = new(_queryOption);

            _select
                .SetFrom("posts")
                .AddJoin(JType.LEFT_JOIN, "users", "users.id = posts.user_id")
                .AddField("user_id")
                .AddField("users.name", "user_name")
                .AddField("COUNT(comment)", "post_count")
                .AddGroup("user_id")
                .AddGroup("user_name");

            _expectedQueryBuilder
                .AppendLine("SELECT user_id, users.name AS user_name, COUNT(comment) AS post_count")
                .AppendLine("FROM posts")
                .AppendLine("LEFT JOIN users ON (users.id = posts.user_id)")
                .Append("GROUP BY user_id, user_name");

            queryBuilder.Build(_select);

            string actualQuery = queryBuilder.GetQuery();

            string expectedQuery = _expectedQueryBuilder.ToString();

            Assert.Equal(expectedQuery, actualQuery);

            Assert.Empty(queryBuilder.Parameters);
        }

        [Fact]
        public void Test_BuildSelect_Group_2_A()
        {
            QueryBuilder queryBuilder = new(_queryOptionA);

            _select
                .SetFrom("posts")
                .AddJoin(JType.LEFT_JOIN, "users", "users.id = posts.user_id")
                .AddField("user_id")
                .AddField("users.name", "user_name")
                .AddField("COUNT(comment)", "post_count")
                .AddGroup("user_id")
                .AddGroup("user_name");

            _expectedQueryBuilder
                .AppendLine("SELECT")
                .AppendLine("    user_id,")
                .AppendLine("    users.name AS user_name,")
                .AppendLine("    COUNT(comment) AS post_count")
                .AppendLine("FROM")
                .AppendLine("    posts")
                .AppendLine("    LEFT JOIN users")
                .AppendLine("        ON (users.id = posts.user_id)")
                .AppendLine("GROUP BY")
                .AppendLine("    user_id,")
                .Append("    user_name");

            queryBuilder.Build(_select);

            string actualQuery = queryBuilder.GetQuery();

            string expectedQuery = _expectedQueryBuilder.ToString();

            Assert.Equal(expectedQuery, actualQuery);

            Assert.Empty(queryBuilder.Parameters);
        }

        [Fact]
        public void Test_BuildSelect_Group_2_B()
        {
            QueryBuilder queryBuilder = new(_queryOptionB);

            _select
                .SetFrom("posts")
                .AddJoin(JType.LEFT_JOIN, "users", "users.id = posts.user_id")
                .AddField("user_id")
                .AddField("users.name", "user_name")
                .AddField("COUNT(comment)", "post_count")
                .AddGroup("user_id")
                .AddGroup("user_name");

            _expectedQueryBuilder
                .AppendLine("SELECT")
                .AppendLine("    user_id")
                .AppendLine("  , users.name AS user_name")
                .AppendLine("  , COUNT(comment) AS post_count")
                .AppendLine("FROM")
                .AppendLine("    posts")
                .AppendLine("    LEFT JOIN users")
                .AppendLine("        ON (users.id = posts.user_id)")
                .AppendLine("GROUP BY")
                .AppendLine("    user_id")
                .Append("  , user_name");

            queryBuilder.Build(_select);

            string actualQuery = queryBuilder.GetQuery();

            string expectedQuery = _expectedQueryBuilder.ToString();

            Assert.Equal(expectedQuery, actualQuery);

            Assert.Empty(queryBuilder.Parameters);
        }

        #endregion

        #region Having Methods

        [Fact]
        public void Test_BuildSelect_Having_1()
        {
            QueryBuilder queryBuilder = new(_queryOption);

            _select
                .SetFrom("posts")
                .AddField("user_id")
                .AddField("COUNT(comment)", "post_count")
                .AddGroup("user_id")
                .AddHaving("post_count", ">=", 2);

            _expectedQueryBuilder
                .AppendLine("SELECT user_id, COUNT(comment) AS post_count")
                .AppendLine("FROM posts")
                .AppendLine("GROUP BY user_id")
                .Append("HAVING post_count >= @h_0");

            queryBuilder.Build(_select);

            string actualQuery = queryBuilder.GetQuery();

            string expectedQuery = _expectedQueryBuilder.ToString();

            Assert.Equal(expectedQuery, actualQuery);

            Assert.Equal(1, queryBuilder.Parameters.Count);

            Assert.All(queryBuilder.Parameters,
                (p, index) =>
                {
                    Assert.Equal($"@h_{index}", p.ParameterName);
                }
            );

            Assert.Collection(queryBuilder.Parameters,
                p =>
                {
                    Assert.Equal(DbType.Int32, p.DbType);
                    Assert.Equal(2, p.Value);
                }
            );
        }

        [Fact]
        public void Test_BuildSelect_Having_1_A()
        {
            QueryBuilder queryBuilder = new(_queryOptionA);

            _select
                .SetFrom("posts")
                .AddField("user_id")
                .AddField("COUNT(comment)", "post_count")
                .AddGroup("user_id")
                .AddHaving("post_count", ">=", 2);

            _expectedQueryBuilder
                .AppendLine("SELECT")
                .AppendLine("    user_id,")
                .AppendLine("    COUNT(comment) AS post_count")
                .AppendLine("FROM")
                .AppendLine("    posts")
                .AppendLine("GROUP BY")
                .AppendLine("    user_id")
                .AppendLine("HAVING")
                .Append("    post_count >= @h_0");

            queryBuilder.Build(_select);

            string actualQuery = queryBuilder.GetQuery();

            string expectedQuery = _expectedQueryBuilder.ToString();

            Assert.Equal(expectedQuery, actualQuery);

            Assert.Equal(1, queryBuilder.Parameters.Count);

            Assert.All(queryBuilder.Parameters,
                (p, index) =>
                {
                    Assert.Equal($"@h_{index}", p.ParameterName);
                }
            );

            Assert.Collection(queryBuilder.Parameters,
                p =>
                {
                    Assert.Equal(DbType.Int32, p.DbType);
                    Assert.Equal(2, p.Value);
                }
            );
        }

        [Fact]
        public void Test_BuildSelect_Having_1_B()
        {
            QueryBuilder queryBuilder = new(_queryOptionB);

            _select
                .SetFrom("posts")
                .AddField("user_id")
                .AddField("COUNT(comment)", "post_count")
                .AddGroup("user_id")
                .AddHaving("post_count", ">=", 2);

            _expectedQueryBuilder
                .AppendLine("SELECT")
                .AppendLine("    user_id")
                .AppendLine("  , COUNT(comment) AS post_count")
                .AppendLine("FROM")
                .AppendLine("    posts")
                .AppendLine("GROUP BY")
                .AppendLine("    user_id")
                .AppendLine("HAVING")
                .Append("    post_count >= @h_0");

            queryBuilder.Build(_select);

            string actualQuery = queryBuilder.GetQuery();

            string expectedQuery = _expectedQueryBuilder.ToString();

            Assert.Equal(expectedQuery, actualQuery);

            Assert.Equal(1, queryBuilder.Parameters.Count);

            Assert.All(queryBuilder.Parameters,
                (p, index) =>
                {
                    Assert.Equal($"@h_{index}", p.ParameterName);
                }
            );

            Assert.Collection(queryBuilder.Parameters,
                p =>
                {
                    Assert.Equal(DbType.Int32, p.DbType);
                    Assert.Equal(2, p.Value);
                }
            );
        }

        [Fact]
        public void Test_BuildSelect_Having_2()
        {
            QueryBuilder queryBuilder = new(_queryOption);

            _select
                .SetFrom("posts")
                .AddField("user_id")
                .AddField("COUNT(comment)", "post_count")
                .AddGroup("user_id")
                .AddHaving("post_count", ">=", 2)
                .AddHaving("post_count", "<=", 4);

            _expectedQueryBuilder
                .AppendLine("SELECT user_id, COUNT(comment) AS post_count")
                .AppendLine("FROM posts")
                .AppendLine("GROUP BY user_id")
                .Append("HAVING post_count >= @h_0 AND post_count <= @h_1");

            queryBuilder.Build(_select);

            string actualQuery = queryBuilder.GetQuery();

            string expectedQuery = _expectedQueryBuilder.ToString();

            Assert.Equal(expectedQuery, actualQuery);

            Assert.Equal(2, queryBuilder.Parameters.Count);

            Assert.All(queryBuilder.Parameters,
                (p, index) =>
                {
                    Assert.Equal($"@h_{index}", p.ParameterName);
                }
            );

            Assert.Collection(queryBuilder.Parameters,
                p =>
                {
                    Assert.Equal(DbType.Int32, p.DbType);
                    Assert.Equal(2, p.Value);
                },
                p =>
                {
                    Assert.Equal(DbType.Int32, p.DbType);
                    Assert.Equal(4, p.Value);
                }
            );
        }

        [Fact]
        public void Test_BuildSelect_Having_2_A()
        {
            QueryBuilder queryBuilder = new(_queryOptionA);

            _select
                .SetFrom("posts")
                .AddField("user_id")
                .AddField("COUNT(comment)", "post_count")
                .AddGroup("user_id")
                .AddHaving("post_count", ">=", 2)
                .AddHaving("post_count", "<=", 4);

            _expectedQueryBuilder
                .AppendLine("SELECT")
                .AppendLine("    user_id,")
                .AppendLine("    COUNT(comment) AS post_count")
                .AppendLine("FROM")
                .AppendLine("    posts")
                .AppendLine("GROUP BY")
                .AppendLine("    user_id")
                .AppendLine("HAVING")
                .AppendLine("    post_count >= @h_0")
                .AppendLine("  AND")
                .Append("    post_count <= @h_1");

            queryBuilder.Build(_select);

            string actualQuery = queryBuilder.GetQuery();

            string expectedQuery = _expectedQueryBuilder.ToString();

            Assert.Equal(expectedQuery, actualQuery);

            Assert.Equal(2, queryBuilder.Parameters.Count);

            Assert.All(queryBuilder.Parameters,
                (p, index) =>
                {
                    Assert.Equal($"@h_{index}", p.ParameterName);
                }
            );

            Assert.Collection(queryBuilder.Parameters,
                p =>
                {
                    Assert.Equal(DbType.Int32, p.DbType);
                    Assert.Equal(2, p.Value);
                },
                p =>
                {
                    Assert.Equal(DbType.Int32, p.DbType);
                    Assert.Equal(4, p.Value);
                }
            );
        }

        [Fact]
        public void Test_BuildSelect_Having_2_B()
        {
            QueryBuilder queryBuilder = new(_queryOptionB);

            _select
                .SetFrom("posts")
                .AddField("user_id")
                .AddField("COUNT(comment)", "post_count")
                .AddGroup("user_id")
                .AddHaving("post_count", ">=", 2)
                .AddHaving("post_count", "<=", 4);

            _expectedQueryBuilder
                .AppendLine("SELECT")
                .AppendLine("    user_id")
                .AppendLine("  , COUNT(comment) AS post_count")
                .AppendLine("FROM")
                .AppendLine("    posts")
                .AppendLine("GROUP BY")
                .AppendLine("    user_id")
                .AppendLine("HAVING")
                .AppendLine("    post_count >= @h_0")
                .AppendLine("  AND")
                .Append("    post_count <= @h_1");

            queryBuilder.Build(_select);

            string actualQuery = queryBuilder.GetQuery();

            string expectedQuery = _expectedQueryBuilder.ToString();

            Assert.Equal(expectedQuery, actualQuery);

            Assert.Equal(2, queryBuilder.Parameters.Count);

            Assert.All(queryBuilder.Parameters,
                (p, index) =>
                {
                    Assert.Equal($"@h_{index}", p.ParameterName);
                }
            );

            Assert.Collection(queryBuilder.Parameters,
                p =>
                {
                    Assert.Equal(DbType.Int32, p.DbType);
                    Assert.Equal(2, p.Value);
                },
                p =>
                {
                    Assert.Equal(DbType.Int32, p.DbType);
                    Assert.Equal(4, p.Value);
                }
            );
        }

        #endregion

        #region Order Methods

        [Fact]
        public void Test_BuildSelect_Order_1()
        {
            QueryBuilder queryBuilder = new(_queryOption);

            _select
                .SetFrom("users")
                .AddField("*")
                .AddOrder("id");

            _expectedQueryBuilder
                .AppendLine("SELECT *")
                .AppendLine("FROM users")
                .Append("ORDER BY id");

            queryBuilder.Build(_select);

            string actualQuery = queryBuilder.GetQuery();

            string expectedQuery = _expectedQueryBuilder.ToString();

            Assert.Equal(expectedQuery, actualQuery);

            Assert.Empty(queryBuilder.Parameters);
        }

        [Theory]
        [InlineData(false)]
        [InlineData(true)]
        public void Test_BuildSelect_Order_1_AB(bool beforeComma)
        {
            QueryOption queryOption = beforeComma
                ? _queryOptionB
                : _queryOptionA;

            QueryBuilder queryBuilder = new(queryOption);

            _select
                .SetFrom("users")
                .AddField("*")
                .AddOrder("id");

            _expectedQueryBuilder
                .AppendLine("SELECT")
                .AppendLine("    *")
                .AppendLine("FROM")
                .AppendLine("    users")
                .AppendLine("ORDER BY")
                .Append("    id");

            queryBuilder.Build(_select);

            string actualQuery = queryBuilder.GetQuery();

            string expectedQuery = _expectedQueryBuilder.ToString();

            Assert.Equal(expectedQuery, actualQuery);

            Assert.Empty(queryBuilder.Parameters);
        }

        [Fact]
        public void Test_BuildSelect_Order_1_asc()
        {
            QueryBuilder queryBuilder = new(_queryOption);

            _select
                .SetFrom("users")
                .AddField("*")
                .AddOrder("id", OType.ASC);

            _expectedQueryBuilder
                .AppendLine("SELECT *")
                .AppendLine("FROM users")
                .Append("ORDER BY id ASC");

            queryBuilder.Build(_select);

            string actualQuery = queryBuilder.GetQuery();

            string expectedQuery = _expectedQueryBuilder.ToString();

            Assert.Equal(expectedQuery, actualQuery);

            Assert.Empty(queryBuilder.Parameters);
        }

        [Theory]
        [InlineData(false)]
        [InlineData(true)]
        public void Test_BuildSelect_Order_1_asc_AB(bool beforeComma)
        {
            QueryOption queryOption = beforeComma
                ? _queryOptionB
                : _queryOptionA;

            QueryBuilder queryBuilder = new(queryOption);

            _select
                .SetFrom("users")
                .AddField("*")
                .AddOrder("id", OType.ASC);

            _expectedQueryBuilder
                .AppendLine("SELECT")
                .AppendLine("    *")
                .AppendLine("FROM")
                .AppendLine("    users")
                .AppendLine("ORDER BY")
                .Append("    id ASC");

            queryBuilder.Build(_select);

            string actualQuery = queryBuilder.GetQuery();

            string expectedQuery = _expectedQueryBuilder.ToString();

            Assert.Equal(expectedQuery, actualQuery);

            Assert.Empty(queryBuilder.Parameters);
        }

        [Fact]
        public void Test_BuildSelect_Order_1_desc()
        {
            QueryBuilder queryBuilder = new(_queryOption);

            _select
                .SetFrom("users")
                .AddField("*")
                .AddOrder("id", OType.DESC);

            _expectedQueryBuilder
                .AppendLine("SELECT *")
                .AppendLine("FROM users")
                .Append("ORDER BY id DESC");

            queryBuilder.Build(_select);

            string actualQuery = queryBuilder.GetQuery();

            string expectedQuery = _expectedQueryBuilder.ToString();

            Assert.Equal(expectedQuery, actualQuery);

            Assert.Empty(queryBuilder.Parameters);
        }

        [Theory]
        [InlineData(false)]
        [InlineData(true)]
        public void Test_BuildSelect_Order_1_desc_AB(bool beforeComma)
        {
            QueryOption queryOption = beforeComma
                ? _queryOptionB
                : _queryOptionA;

            QueryBuilder queryBuilder = new(queryOption);

            _select
                .SetFrom("users")
                .AddField("*")
                .AddOrder("id", OType.DESC);

            _expectedQueryBuilder
                .AppendLine("SELECT")
                .AppendLine("    *")
                .AppendLine("FROM")
                .AppendLine("    users")
                .AppendLine("ORDER BY")
                .Append("    id DESC");

            queryBuilder.Build(_select);

            string actualQuery = queryBuilder.GetQuery();

            string expectedQuery = _expectedQueryBuilder.ToString();

            Assert.Equal(expectedQuery, actualQuery);

            Assert.Empty(queryBuilder.Parameters);
        }

        [Fact]
        public void Test_BuildSelect_Order_3()
        {
            QueryBuilder queryBuilder = new(_queryOption);

            _select
                .SetFrom("users")
                .AddField("*")
                .AddOrder("age", OType.DESC)
                .AddOrder("name", OType.ASC)
                .AddOrder("id");

            _expectedQueryBuilder
                .AppendLine("SELECT *")
                .AppendLine("FROM users")
                .Append("ORDER BY age DESC, name ASC, id");

            queryBuilder.Build(_select);

            string actualQuery = queryBuilder.GetQuery();

            string expectedQuery = _expectedQueryBuilder.ToString();

            Assert.Equal(expectedQuery, actualQuery);

            Assert.Empty(queryBuilder.Parameters);
        }

        [Fact]
        public void Test_BuildSelect_Order_3_A()
        {
            QueryBuilder queryBuilder = new(_queryOptionA);

            _select
                .SetFrom("users")
                .AddField("*")
                .AddOrder("age", OType.DESC)
                .AddOrder("name", OType.ASC)
                .AddOrder("id");

            _expectedQueryBuilder
                .AppendLine("SELECT")
                .AppendLine("    *")
                .AppendLine("FROM")
                .AppendLine("    users")
                .AppendLine("ORDER BY")
                .AppendLine("    age DESC,")
                .AppendLine("    name ASC,")
                .Append("    id");

            queryBuilder.Build(_select);

            string actualQuery = queryBuilder.GetQuery();

            string expectedQuery = _expectedQueryBuilder.ToString();

            Assert.Equal(expectedQuery, actualQuery);

            Assert.Empty(queryBuilder.Parameters);
        }

        [Fact]
        public void Test_BuildSelect_Order_3_B()
        {
            QueryBuilder queryBuilder = new(_queryOptionB);

            _select
                .SetFrom("users")
                .AddField("*")
                .AddOrder("age", OType.DESC)
                .AddOrder("name", OType.ASC)
                .AddOrder("id");

            _expectedQueryBuilder
                .AppendLine("SELECT")
                .AppendLine("    *")
                .AppendLine("FROM")
                .AppendLine("    users")
                .AppendLine("ORDER BY")
                .AppendLine("    age DESC")
                .AppendLine("  , name ASC")
                .Append("  , id");

            queryBuilder.Build(_select);

            string actualQuery = queryBuilder.GetQuery();

            string expectedQuery = _expectedQueryBuilder.ToString();

            Assert.Equal(expectedQuery, actualQuery);

            Assert.Empty(queryBuilder.Parameters);
        }

        #endregion

        #region Limit Methods

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void Test_BuildSelect_Unlimited(int limit)
        {
            QueryBuilder queryBuilder = new(_queryOption);

            _select
                .SetFrom("users")
                .AddField("*")
                .SetLimit(limit);

            _expectedQueryBuilder
                .AppendLine("SELECT *")
                .Append("FROM users");

            queryBuilder.Build(_select);

            string actualQuery = queryBuilder.GetQuery();

            string expectedQuery = _expectedQueryBuilder.ToString();

            Assert.Equal(expectedQuery, actualQuery);

            Assert.Empty(queryBuilder.Parameters);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        public void Test_BuildSelect_Limit(int limit)
        {
            QueryBuilder queryBuilder = new(_queryOption);

            _select
                .SetFrom("users")
                .AddField("*")
                .SetLimit(limit);

            _expectedQueryBuilder
                .AppendLine("SELECT *")
                .AppendLine("FROM users")
                .Append($"LIMIT {limit}");

            queryBuilder.Build(_select);

            string actualQuery = queryBuilder.GetQuery();

            string expectedQuery = _expectedQueryBuilder.ToString();

            Assert.Equal(expectedQuery, actualQuery);

            Assert.Empty(queryBuilder.Parameters);
        }

        [Theory]
        [InlineData(false, 1)]
        [InlineData(true, 1)]
        public void Test_BuildSelect_Limit_AB(bool beforeComma, int limit)
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
                .AppendLine("SELECT")
                .AppendLine("    *")
                .AppendLine("FROM")
                .AppendLine("    users")
                .AppendLine("LIMIT")
                .Append($"    {limit}");

            queryBuilder.Build(_select);

            string actualQuery = queryBuilder.GetQuery();

            string expectedQuery = _expectedQueryBuilder.ToString();

            Assert.Equal(expectedQuery, actualQuery);

            Assert.Empty(queryBuilder.Parameters);
        }

        #endregion

        #region Offset Methods

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void Test_BuildSelect_NoOffset(int offset)
        {
            QueryBuilder queryBuilder = new(_queryOption);

            _select
                .SetFrom("users")
                .AddField("*")
                .SetOffset(offset);

            _expectedQueryBuilder
                .AppendLine("SELECT *")
                .Append("FROM users");

            queryBuilder.Build(_select);

            string actualQuery = queryBuilder.GetQuery();

            string expectedQuery = _expectedQueryBuilder.ToString();

            Assert.Equal(expectedQuery, actualQuery);

            Assert.Empty(queryBuilder.Parameters);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        public void Test_BuildSelect_Offset(int offset)
        {
            QueryBuilder queryBuilder = new(_queryOption);

            _select
                .SetFrom("users")
                .AddField("*")
                .SetOffset(offset);

            _expectedQueryBuilder
                .AppendLine("SELECT *")
                .AppendLine("FROM users")
                .Append($"OFFSET {offset}");

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
                .SetOffset(offset);

            _expectedQueryBuilder
                .AppendLine("SELECT")
                .AppendLine("    *")
                .AppendLine("FROM")
                .AppendLine("    users")
                .AppendLine("OFFSET")
                .Append($"    {offset}");

            queryBuilder.Build(_select);

            string actualQuery = queryBuilder.GetQuery();

            string expectedQuery = _expectedQueryBuilder.ToString();

            Assert.Equal(expectedQuery, actualQuery);

            Assert.Empty(queryBuilder.Parameters);
        }

        #endregion

        #region Limit and Offset Methods

        [Theory]
        [InlineData(1, 2)]
        [InlineData(2, 1)]
        public void Test_BuildSelect_Limit_and_Offset(int limit, int offset)
        {
            QueryBuilder queryBuilder = new(_queryOption);

            _select
                .SetFrom("users")
                .AddField("*")
                .SetLimit(limit)
                .SetOffset(offset);

            _expectedQueryBuilder
                .AppendLine("SELECT *")
                .AppendLine("FROM users")
                .AppendLine($"LIMIT {limit}")
                .Append($"OFFSET {offset}");

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
        public void Test_BuildSelect_Limit_and_Offset_AB(bool beforeComma, int limit, int offset)
        {
            QueryOption queryOption = beforeComma
                ? _queryOptionB
                : _queryOptionA;

            QueryBuilder queryBuilder = new(queryOption);

            _select
                .SetFrom("users")
                .AddField("*")
                .SetLimit(limit)
                .SetOffset(offset);

            _expectedQueryBuilder
                .AppendLine("SELECT")
                .AppendLine("    *")
                .AppendLine("FROM")
                .AppendLine("    users")
                .AppendLine("LIMIT")
                .AppendLine($"    {limit}")
                .AppendLine("OFFSET")
                .Append($"    {offset}");

            queryBuilder.Build(_select);

            string actualQuery = queryBuilder.GetQuery();

            string expectedQuery = _expectedQueryBuilder.ToString();

            Assert.Equal(expectedQuery, actualQuery);

            Assert.Empty(queryBuilder.Parameters);
        }

        #endregion
    }
}