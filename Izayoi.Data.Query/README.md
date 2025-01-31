# Izayoi.Data.Query

This is a library that supports building query (SQL) to manipulate a database.

## Applies to

|Product|Versions|
|--|--|
|.NET|8, 9|

## Wiki

[Wiki](https://github.com/izayoijiichan/Izayoi.Data/wiki)

## Examples

### Query Option

~~~csharp
using Izayoi.Data.Query;

static void Main()
{
    QueryOption queryOption;

    queryOption = new QueryOption(RdbKind.Sqlite, 3);

    queryOption = new QueryOption(RdbKind.SqlServer, 2022)
    {
        QuotationMarks = new QuotationMarkSet('[', ']')
    };

    queryOption = new QueryOption(RdbKind.Mysql, 8)
    {
        QuotationMarks = new QuotationMarkSet('`', '`')
    };

    queryOption = new QueryOption(RdbKind.Pgsql, 16)
    {
        QuotationMarks = new QuotationMarkSet('"', '"')
    };

    queryOption = new QueryOption()
    {
        EnableFormat = true,
        IndentSpace = 4,
        BeforeComma = true,
    }
}
~~~

### Basic

~~~csharp
    using Izayoi.Data.Query;

    static void Main()
    {
        var queryOption = new QueryOption();

        var queryBuilder = new QueryBuilder(queryOption);

        var select = new Select()
            .SetFrom("users")
            .AddField("*");

        queryBuilder.Build(select);

        string query = queryBuilder.GetQuery();

        var parameters = queryBuilder.GetParameters();

        // query:
        //   SELECT *
        //   FROM users
        // parameters:
        //   (Empty)
    }
~~~

### Select

~~~csharp
    // SELECT
    {
        var select1 = new Select()
            .SetFrom("users")
            .AddField("id")
            .AddField("name")
            .AddField("age");

        // query:
        //   SELECT id, name, age
        //   FROM users
    }

    // SELECT DISTINCT
    {
        var select2 = new Select()
            .SetType(SType.DISTINCT)
            .SetFrom("users")
            .AddField("*");

        // query:
        //   SELECT DISTINCT *
        //   FROM users
    }

    // WHERE: AND
    {
        var select3 = new Select()
            .SetFrom("users")
            .AddField("*")
            .AddWhere("age", ">=", 13)
            .AddWhere("age", "<=", 19);        

        // query:
        //   SELECT *
        //   FROM users
        //   WHERE age >= @w_0
        //     AND age <= @w_1
        // parameters:
        //   [0]:
        //     ParameterName: @w_0
        //     DbType: DbType.Int32
        //     Value: 13
        //   [1]:
        //     ParameterName: @w_1
        //     DbType: DbType.Int32
        //     Value: 19
    }

    // WHERE: BETWEEN
    {
        var select4 = new Select()
            .SetFrom("users")
            .AddField("*")
            .AddWhere("age", OpType.BETWEEN, new int[] { 13, 19 });

        // query:
        //   SELECT *
        //   FROM users
        //   WHERE BETWEEN age @w_0_0 AND @w_0_1
        // parameters:
        //   [0]:
        //     ParameterName: @w_0_0
        //     DbType: DbType.Int32
        //     Value: 13
        //   [1]:
        //     ParameterName: @w_0_1
        //     DbType: DbType.Int32
        //     Value: 19
    }

    // WHERE: IN
    {
        var select5 = new Select()
            .SetFrom("users")
            .AddField("*")
            .AddWhere("age", OpType.IN, new int[] { 20, 30, 40 });

        // query:
        //   SELECT *
        //   FROM users
        //   WHERE age IN (@w_0_0, @w_0_1, @w_0_2)
        // parameters:
        //   [0]:
        //     ParameterName: @w_0_0
        //     DbType: DbType.Int32
        //     Value: 20
        //   [1]:
        //     ParameterName: @w_0_1
        //     DbType: DbType.Int32
        //     Value: 30
        //   [2]:
        //     ParameterName: @w_0_2
        //     DbType: DbType.Int32
        //     Value: 40
    }

    // WHERE: IN
    {
        var select6 = new Select()
            .SetFrom("users")
            .AddField("*")
            .AddWhere("age", OpType.IN, new List<int> { 20, 30, 40 });

        // query:
        //   SELECT *
        //   FROM users
        //   WHERE age IN (@w_0_0, @w_0_1, @w_0_2)
        // parameters:
        //   [0]:
        //     ParameterName: @w_0_0
        //     DbType: DbType.Int32
        //     Value: 20
        //   [1]:
        //     ParameterName: @w_0_1
        //     DbType: DbType.Int32
        //     Value: 30
        //   [2]:
        //     ParameterName: @w_0_2
        //     DbType: DbType.Int32
        //     Value: 40
    }

    // WHERE: OR
    {
        var select7 = new Select()
            .SetFrom("users")
            .AddField("*")
            .AddWhere('(', "age", "=", 20)
            .AddWhere(CType.OR, "age", "=", 30)
            .AddWhere(CType.OR, "age", "=", 40)
            .AddWhere(CType.OR, "age", "=", 50, ')'); 

        // query:
        //   SELECT *
        //   FROM users
        //   WHERE (age = @w_0
        //       OR age = @w_1
        //       OR age = @w_2
        //       OR age = @w_3)
        // parameters:
        //   [0]:
        //     ParameterName: @w_0
        //     DbType: DbType.Int32
        //     Value: 20
        //   [1]:
        //     ParameterName: @w_1
        //     DbType: DbType.Int32
        //     Value: 30
        //   [2]:
        //     ParameterName: @w_2
        //     DbType: DbType.Int32
        //     Value: 40
        //   [3]:
        //     ParameterName: @w_3
        //     DbType: DbType.Int32
        //     Value: 50
    }

    // WHERE: IS NULL / IS NOT NULL
    {
        var select8 = new Select()
            .SetFrom("users")
            .AddField("*")
            .AddWhere("name", OpType.IS_NULL);

        // query:
        //   SELECT *
        //   FROM users
        //   WHERE name IS NULL
        // parameters:
        //   (Empty)
    }

    // WHERE: IS NULL
    {
        var select9 = new Select()
            .SetFrom("users")
            .AddField("*")
            .AddWhere("name", "is", null);

        // query:
        //   SELECT *
        //   FROM users
        //   WHERE name IS NULL
        // parameters:
        //   (Empty)
    }

    // WHERE: IS NOT NULL
    {
        var select10 = new Select()
            .SetFrom("users")
            .AddField("*")
            .AddWhere("name", "is not", null);

        // query:
        //   SELECT *
        //   FROM users
        //   WHERE name IS NOT NULL
        // parameters:
        //   (Empty)
    }

    // WHERE: LIKE / NOT LIKE
    {
        var select11 = new Select()
            .SetFrom("users")
            .AddField("*")
            .AddWhere("name", OpType.LIKE, "J%");

        // query:
        //   SELECT *
        //   FROM users
        //   WHERE name LIKE @w_0
        // parameters:
        //   [0]:
        //     ParameterName: @w_0
        //     DbType: DbType.String
        //     Value: "J%"
    }

    // WHERE
    {
        var select12 = new Select()
            .SetFrom("users")
            .AddField("*")
            .AddWhere("age", ">=", 20)
            .AddWhere(Type.AND, "name", OpType.LIKE, "J%")
            .AddWhere(Type.AND, "enabled", "=", true);

        // query:
        //   SELECT *
        //   FROM users
        //   WHERE age >= @w_0
        //     AND name LIKE @w_1
        //     AND enabled = @w_2
        // parameters:
        //   [0]:
        //     ParameterName: @w_0
        //     DbType: DbType.Int32
        //     Value: 20
        //   [1]:
        //     ParameterName: @w_1
        //     DbType: DbType.String
        //     Value: "J%"
        //   [2]:
        //     ParameterName: @w_2
        //     DbType: DbType.Boolean
        //     Value: true
    }

    // JOIN
    {
        var select13 = new Select()
            .SetFrom("posts")
            .AddJoin(JType.LEFT_JOIN, "users", "users.id = posts.user_id")
            .AddField("posts.id")
            .AddField("posts.comment")
            .AddField("posts.user_id")
            .AddField("users.name", "user_name")
            .AddWhere("users.age", "<", 18);

        // query:
        //   SELECT posts.id, posts.comment, posts.user_id, users.name AS user_name
        //   FROM posts
        //   LEFT JOIN users ON (users.id = posts.user_id)
        //   WHERE users.age < @w_0
        // parameters:
        //   [0]:
        //     ParameterName: @w_0
        //     DbType: DbType.Int32
        //     Value: 18
    }

    // JOIN: Table Alias
    {
        var select14 = new Select()
            .SetFrom("posts", "p")
            .AddJoin(JType.LEFT_JOIN, "users", "u", "u.id = p.user_id")
            .AddField("p.id")
            .AddField("p.comment")
            .AddField("p.user_id")
            .AddField("u.name", "user_name")
            .AddWhere("u.age", "<", 18);

        // query:
        //   SELECT p.id, p.comment, p.user_id, u.name AS user_name
        //   FROM posts AS p
        //   LEFT JOIN users AS u ON (u.id = p.user_id)
        //   WHERE u.age < @w_0
        // parameters:
        //   [0]:
        //     ParameterName: @w_0
        //     DbType: DbType.Int32
        //     Value: 18
    }

    // JOIN: Schema
    {
        var select15 = new Select()
            .SetFrom("dbo", "posts", "p")
            .AddJoin(JType.LEFT_JOIN, "dbo", "users", "u", "u.id = p.user_id")
            .AddField("p.id")
            .AddField("p.comment")
            .AddField("p.user_id")
            .AddField("u.name", "user_name")
            .AddWhere("u.age", "<", 18);

        // query:
        //   SELECT p.id, p.comment, p.user_id, u.name AS user_name
        //   FROM dbo.posts AS p
        //   LEFT JOIN dbo.users AS u ON (u.id = p.user_id)
        //   WHERE u.age < @w_0
        // parameters:
        //   [0]:
        //     ParameterName: @w_0
        //     DbType: DbType.Int32
        //     Value: 18
    }

    // GROUP BY
    {
        var select16 = new Select()
            .SetFrom("posts")
            .AddJoin(JType.LEFT_JOIN, "users", "users.id = posts.user_id")
            .AddField("user_id")
            .AddField("users.name", "user_name")
            .AddField("COUNT(comment)", "post_count")
            .AddGroup("user_id")
            .AddGroup("user_name");

        // query:
        //   SELECT user_id, users.name AS user_name, COUNT(comment) AS post_count
        //   FROM posts
        //   LEFT JOIN users ON (users.id = posts.user_id)
        //   GROUP BY user_id, user_name
    }

    // HAVING
    {
        var select17 = new Select()
            .SetFrom("posts")
            .AddField("user_id")
            .AddField("COUNT(comment)", "post_count")
            .AddGroup("user_id")
            .AddHaving("post_count", ">=", 2)
            .AddHaving("post_count", "<=", 4);

        // query:
        //   SELECT user_id, COUNT(comment) AS post_count
        //   FROM posts
        //   LEFT JOIN users ON (users.id = posts.user_id)
        //   GROUP BY user_id
        //   HAVING post_count >= @h_0 AND post_count <= @h_1
        // parameters:
        //   [0]:
        //     ParameterName: @h_0
        //     DbType: DbType.Int32
        //     Value: 2
        //   [1]:
        //     ParameterName: @h_1
        //     DbType: DbType.Int32
        //     Value: 4
    }

    // LIMIT and OFFET
    {
        var select18 = new Select()
            .SetFrom("users")
            .AddField("*")
            .AddOrder("id", OType.ASC)
            .SetLimit(5)
            .SetOffset(10);

        // query:
        //   SELECT *
        //   FROM users
        //   ORDER BY id ASC
        //   LIMIT 5
        //   OFFSET 10

        // queryOption
        //   RdbKind.SqlServer
        // query:
        //   SELECT *
        //   FROM users
        //   ORDER BY id ASC
        //   OFFSET 10 ROWS
        //   FETCH NEXT 5 ROWS ONLY
    }
~~~

### Insert

~~~csharp
    {
        var insert1 = new Insert();

        insert1.SetInto("users")
            .Values
                .Add("id", 1)
                .Add("name", "name1")
                .Add("age", 20)
                .Add("created_at", DateTimeOffset.UtcNow)
                .Add("updated_at", DateTimeOffset.UtcNow);

        // query:
        //   INSERT INTO users
        //   (id, name, age, created_at, updated_at)
        //   VALUES
        //   (@v_0, @v_1, @v_2, @v_3, @v_4)
        // parameters:
        //   [0]:
        //     ParameterName: @v_0
        //     DbType: DbType.Int32
        //     Value: 1
        //   [1]:
        //     ParameterName: @v_1
        //     DbType: DbType.String
        //     Value: "name1"
        //   [2]:
        //     ParameterName: @v_2
        //     DbType: DbType.Int32
        //     Value: 20
        //   [3]:
        //     ParameterName: @v_3
        //     DbType: DbType.DateTime
        //     Value: (2024-08-01 00:00:00)
        //   [4]:
        //     ParameterName: @v_4
        //     DbType: DbType.DateTime
        //     Value: (2024-08-01 00:00:00)
    }

    {
        var insert2 = new Insert();

        insert2.SetInto("users")
            .Select ??= new Select()
                .SetFrom("users2")
                .AddField("id")
                .AddField("name")
                .AddField("age")
                .AddField("created_at")
                .AddField("updated_at");

        // query:
        //   INSERT INTO users
        //   SELECT id, name, age, created_at, updated_at
        //   FROM users2
    }
~~~

### Update

~~~csharp
    {
        var update1 = new Update()
            .SetTable("users")
            .AddSet("age", 21)
            .AddSet("updated_at", DateTime.UtcNow)
            .AddWhere("id", "=", 1);

        // query:
        //   UPDATE users
        //   SET age = @s_0, updated_at = @s_1
        //   WHERE id = @w_0
        // parameters:
        //   [0]:
        //     ParameterName: @s_0
        //     DbType: DbType.Int32
        //     Value: 21
        //   [1]:
        //     ParameterName: @s_1
        //     DbType: DbType.DateTime
        //     Value: (2024-08-01 00:00:00)
        //   [2]:
        //     ParameterName: @w_0
        //     DbType: DbType.Int32
        //     Value: 1
    }

    // JOIN for MySQL
    {
        var update2 = new Update()
            .SetTable("posts", "p")
            .AddJoin(JType.LEFT_JOIN, "users", "u", "u.id = p.user_id")
            .AddSet("comment", "comment1")
            .AddWhere("p.id", "=", 1);

        // query:
        //   UPDATE posts AS p
        //   LEFT JOIN users AS u ON (u.id = p.user_id)
        //   SET comment = @s_0
        //   WHERE id = @w_0
        // parameters:
        //   [0]:
        //     ParameterName: @s_0
        //     DbType: DbType.Int32
        //     Value: "comment1"
        //   [1]:
        //     ParameterName: @w_0
        //     DbType: DbType.Int32
        //     Value: 1
    }

    // JOIN for PostgreSQL, SQLite and SQL Server
    {
        var update3 = new Update()
            .SetTable("posts")
            .AddSet("comment", "comment1")
            .SetFrom("posts", "p")
            .AddJoin(JType.LEFT_JOIN, "users", "u", "u.id = p.user_id")
            .AddWhere("p.id", "=", 1);

        // query:
        //   UPDATE posts
        //   SET comment = @s_0
        //   FROM posts AS p
        //   LEFT JOIN users AS u ON (u.id = p.user_id)
        //   WHERE id = @w_0
        // parameters:
        //   [0]:
        //     ParameterName: @s_0
        //     DbType: DbType.String
        //     Value: "comment1"
        //   [1]:
        //     ParameterName: @w_0
        //     DbType: DbType.Int32
        //     Value: 1
    }

    // JOIN for SQL Server
    {
        var update4 = new Update()
            .SetTable("", "p")
            .AddSet("comment", "comment1")
            .SetFrom("posts", "p")
            .AddJoin(JType.LEFT_JOIN, "users", "u", "u.id = p.user_id")
            .AddWhere("p.id", "=", 1);

        // query:
        //   UPDATE p
        //   SET comment = @s_0
        //   FROM posts AS p
        //   LEFT JOIN users AS u ON (u.id = p.user_id)
        //   WHERE id = @w_0
        // parameters:
        //   [0]:
        //     ParameterName: @s_0
        //     DbType: DbType.String
        //     Value: "comment1"
        //   [1]:
        //     ParameterName: @w_0
        //     DbType: DbType.Int32
        //     Value: 1
    }
~~~

### Delete

~~~csharp
    {
        var delete1 = new Delete()
            .SetFrom("users")
            .AddWhere("id", "=", 1);

        // query:
        //   DELETE
        //   FROM users
        //   WHERE id = @w_0
        // parameters:
        //   [0]:
        //     ParameterName: @w_0
        //     DbType: DbType.Int32
        //     Value: 1
    }
~~~

___
Last updated: 5 January, 2025  
Editor: Izayoi Jiichan

*Copyright (C) 2024 Izayoi Jiichan. All Rights Reserved.*
