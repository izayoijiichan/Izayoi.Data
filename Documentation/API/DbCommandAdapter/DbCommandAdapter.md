# DbCommandAdapter

[Top](../../../README.md) / [Documentation](../../Documentation.md)

## Definition

|||
|--|--|
|Namespace|Izayoi.Data|
|Assembly|Izayoi.Data.DbCommandAdapter.dll|

Represents a DB command adapter.

~~~csharp
public class DbCommandAdapter : IDbCommandAdapter
~~~

### Inheritance
Object -> DbCommandAdapter

## Constructors

|Name|Summary|
|--|--|
|DbCommandAdapter(IDbDataMapper dbDataMapper)|Initializes a new instance of the DbCommandAdapter class with the specified dbDataMapper.|
|DbCommandAdapter(IDbDataMapper dbDataMapper, QueryOption queryOption)|Initializes a new instance of the DbCommandAdapter class with the specified dbDataMapper and queryOption.|

## Properties

#### `DbDataMapper` [IDbDataMapper](../DbDataMapper/DbDataMapper.md)

Gets the DB data mapper.

#### `QueryOption` [QueryOption](../Query/QueryOption.md)

Gets the query option.

## Methods (Build Command)

|Name|Returns|Summary|
|--|--|--|
|BuildDeleteCommand(DbCommand dbCommand, Delete delete)|bool|Builds a DELETE query for the specified DB command using specified delete source.|
|BuildDeleteCommand\<T>(DbCommand dbCommand, T data)|bool|Builds a DELETE query for the specified DB command using specified data.|
|BuildInsertCommand(DbCommand dbCommand, Insert insert)|bool|Builds an INSERT query for the specified DB command using specified insert source.|
|BuildInsertCommand\<T>(DbCommand dbCommand, T data, bool excludeKey = false)|bool|Builds an INSERT query for the specified DB command using specified data.|
|BuildSelectCommand(DbCommand dbCommand, Select select)|bool|Builds a SELECT query for the specified DB command using specified select source.|
|BuildUpdateCommand(DbCommand dbCommand, Update update)|bool|Builds an UPDATE query for the specified DB command using specified update source.|
|BuildUpdateCommand\<T>(DbCommand dbCommand, T data, string[]? excludeColumns = null)|bool|Builds an UPDATE query for the specified DB command using specified data.|

## Methods (Execute)

|Name|Returns|Summary|
|--|--|--|
|ExecuteQueryAsync\<T>(DbCommand dbCommand, CancellationToken cancellationToken)|Task\<List\<T>>|Executes specified DB command, and returns the records.|
|ExecuteScalar\<T>(DbCommand dbCommand)|T?|Executes specified DB command, and returns the first columns of the first row in the first returned result set.|
|ExecuteScalarAsync\<T>(DbCommand dbCommand, CancellationToken cancellationToken)|Task\<T?>|Executes specified DB command, and returns the first columns of the first row in the first returned result set.|
|ExecuteScalarAsync\<T>(DbCommand dbCommand, Select select, CancellationToken cancellationToken)|Task\<T?>|Executes specified DB command using specified select source, and returns the first columns of the first row in the first returned result set.|

## Methods (Select)

|Name|Returns|Summary|
|--|--|--|
|SelectAllAsync\<T>(DbCommand dbCommand, CancellationToken cancellationToken)|Task\<List\<T>>|Executes a SELECT ALL query for the specified DB command, and returns the records.|
|SelectAsync\<T>(DbCommand dbCommand, Select select, CancellationToken cancellationToken)|Task\<List\<T>>|Executes a SELECT query for the specified DB command using specified select source, and returns the records.|

## Methods (Insert)

|Name|Returns|Summary|
|--|--|--|
|InsertAsync\<T>(DbCommand dbCommand, T data, CancellationToken cancellationToken)|Task\<int>|Executes an INSERT query for the specified DB command using specified data.|
|InsertAsync\<T>(DbCommand dbCommand, T data, bool excludeKey, CancellationToken cancellationToken)|Task\<int>|Executes an INSERT query for the specified DB command using specified data.|
|InsertAsync(DbCommand dbCommand, Insert insert, CancellationToken cancellationToken)|Task\<int>|Builds an INSERT query for the specified DB command using specified insert source.|
|InsertReturnAsync\<TReturn, TData>(DbCommand dbCommand, TData data, CancellationToken cancellationToken)|Task\<TReturn?>|Executes an INSERT query for the specified DB command using specified data, and returns an inserted identity value.|
|InsertReturnAsync\<TReturn, TData>(DbCommand dbCommand, TData data, bool excludeKey, CancellationToken cancellationToken)|Task\<TReturn?>|Executes an INSERT query for the specified DB command using specified data, and returns an inserted identity value.|
|InsertReturnAsync\<T>(DbCommand dbCommand, Insert insert, CancellationToken cancellationToken)|Task\<T?>|Executes an INSERT query for the specified DB command using specified insert source, and returns an inserted identity value.|
|InsertReturnAsync\<T>(DbCommand dbCommand, Insert insert, string returnColumnName, CancellationToken cancellationToken)|Task\<T?>|Executes an INSERT query for the specified DB command using specified insert source, and returns an inserted specified returnColumnName value.|
|InsertReturnAsync\<TReturn, TData>(DbCommand dbCommand, TData data, string returnColumnName, CancellationToken cancellationToken)|Task\<TReturn?>|Executes an INSERT query for the specified DB command using specified data, and returns an inserted specified returnColumnName value.|

## Methods (Update)

|Name|Returns|Summary|
|--|--|--|
|UpdateAsync(DbCommand dbCommand, Update update, CancellationToken cancellationToken)|Task\<int>|Executes an UPDATE query for the specified DB command using specified update source.|
|UpdateAsync\<T>(DbCommand dbCommand, T data, CancellationToken cancellationToken)|Task\<int>|Executes an UPDATE query for the specified DB command using specified data.|
|UpdateAsync\<T>(DbCommand dbCommand, T data, string[] excludeColumns, CancellationToken cancellationToken)|Task\<int>|Executes an UPDATE query for the specified DB command using specified data.|

## Methods (Delete)

|Name|Returns|Summary|
|--|--|--|
|DeleteAsync(DbCommand dbCommand, Delete delete, CancellationToken cancellationToken)|Task\<int>|Executes a DELETE query for the specified DB command using specified delete source.|
|DeleteAsync\<T>(DbCommand dbCommand, T data, CancellationToken cancellationToken)|Task\<int>|Executes a DELETE query for the specified DB command using specified data.|

## Remarks

A `DbCommandAdapter` object can be reused. (Recommend)

## Examples

### Database

~~~sql
-- SQL Server Example
CREATE TABLE [dbo].[users] (
    [id]         INT           IDENTITY (1, 1) NOT NULL,
    [name]       NVARCHAR (50) NOT NULL,
    [age]        TINYINT       NOT NULL,
    [gender]     TINYINT       NOT NULL,
    [created_at] DATETIME2 (7) NOT NULL,
    [updated_at] DATETIME2 (7) NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);

CREATE TABLE [dbo].[posts] (
    [id]        INT            IDENTITY (1, 1) NOT NULL,
    [posted_at] DATETIME2 (7)  NOT NULL,
    [user_id]   INT            NOT NULL,
    [comment]   NVARCHAR (100) NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);
~~~

### Map Classes

~~~csharp
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

//[Table("users")]
[Table("users", Schema = "dbo")]
public class User
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("name")]
    public string Name { get; set; } = string.Empty;

    [Column("age")]
    public byte Age { get; set; }

    [Column("gender")]
    public GenderType Gender { get; set; }

    [Column("created_at")]
    public DateTime CreatedAt { get; set; }

    [Column("updated_at")]
    public DateTime UpdatedAt { get; set; }

    [NotMapped]
    public int IgnoreProperty { get; set; }
}

//[Table("posts")]
[Table("posts", Schema = "dbo")]
public class Post
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("posted_at")]
    public DateTime PostedAt { get; set; }

    [Column("user_id")]
    public int UserId { get; set; }

    [Column("comment")]
    public string Comment { get; set; } = string.Empty;
}

public class PostCount
{
    [Column("user_id")]
    public int UserId { get; set; }

    [Column("user_name")]
    public string UserName { get; set; } = string.Empty;

    [Column("count")]
    public int Count { get; set; }
}
~~~

- If the `[Table]` attribute is not defined, the class name is used as the table name.
- If the `[Column]` attribute is not defined, the property name is used as the column name.
- If the `[NotMapped]` attribute is defined, the property is excluded from the mapping.
- The `[Key]` attribute is set to the primary key. It is used for update or delete methods.

### Data Access

~~~csharp
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Izayoi.Data;
using Izayoi.Data.Query;
using Microsoft.Data.SqlClient;  // for SQL Server
//using Microsoft.Data.Sqlite;   // for SQLite
//using MySqlConnector;          // for MySQL
//using Npgsql;                  // for PostgreSQL

public class UserRepository
{
    private readonly string dbConnectionString;

    private readonly DbCommandAdapter dbCommandAdapter;

    private readonly DbDataMapper dbDataMapper;

    private readonly QueryOption queryOption;

    public UserRepository()
    {
        queryOption = new QueryOption(RdbKind.SqlServer);

        dbDataMapper = new DbDataMapper();

        dbCommandAdapter = new DbCommandAdapter(dbDataMapper, queryOption);

        dbConnectionString = GetDbConnectionString();
    }

    public async Task<List<User>> GetAllUserAsync(CancellationToken cancellationToken)
    {
        using SqlConnection dbConnection = new(dbConnectionString);

        using SqlCommand dbCommand = dbConnection.CreateCommand();

        dbConnection.Open();

        List<User> users;

        // Select method A (Command Text)
        {
            dbCommand.CommandText = "SELECT * FROM dbo.users";

            users = await dbCommandAdapter.ExecuteQueryAsync<User>(dbCommand, cancellationToken);
        }
        // Select method B (Query Builder)
        {
            var select = new Select()
                .SetFrom("dbo", "users", "")
                .AddField("*");

            users = await dbCommandAdapter.SelectAsync<User>(dbCommand, select, cancellationToken);
        }
        // Select method C (Auto Mapper)
        {
            users = await dbCommandAdapter.SelectAllAsync<User>(dbCommand, cancellationToken);
        }

        dbConnection.Close();

        return users;
    }

    public async Task<User?> GetUserAsync(int userId, CancellationToken cancellationToken)
    {
        // CreateConnection -> CreateCommand -> Connection.Open

        List<User> users;

        // Select method A (Command Text)
        {
            dbCommand.CommandText = "SELECT * FROM dbo.users WHERE id = @id";

            var parameter = new SqlParameter("@id", System.Data.SqlDbType.Int)
            {
                Value = userId,
            };

            dbCommand.Parameters.Add(parameter);

            users = await dbCommandAdapter.ExecuteQueryAsync<User>(dbCommand, cancellationToken);
        }
        // Select method B (Query Builder)
        {
            var select = new Select()
                .SetFrom("dbo", "users", "")
                .AddField("*")
                .AddWhere("id", "=", userId);

            // SELECT *
            // FROM dbo.users
            // WHERE id = @w_0

            users = await dbCommandAdapter.SelectAsync<User>(dbCommand, select, cancellationToken);
        }

        dbConnection.Close();

        return users.FirstOrDefault();
    }

    public async Task<User> AddUserAsync(string name, byte age, GenderType gender, CancellationToken cancellationToken)
    {
        // CreateConnection -> CreateCommand -> Connection.Open

        var user = new User()
        {
            Id = 0,
            Name = name,
            Age = age,
            Gender = gender,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow,
        };

        int userId = await dbCommandAdapter.InsertReturnAsync<int, User>(dbCommand, user, excludeKey: true, cancellationToken);

        user.Id = userId;

        return user;
    }

    public async Task<bool> UpdateUserAsync(User user, CancellationToken cancellationToken)
    {
        // CreateConnection -> CreateCommand -> Connection.Open

        int affectedRowCount;

        // Update method A (Auto Mapper)
        {
            user.UpdatedAt = DateTime.UtcNow;

            var excludeColumns = new string[] { "created_at" };

            affectedRowCount = await dbCommandAdapter.UpdateAsync<User>(dbCommand, user, excludeColumns, cancellationToken);
        }
        // Update method B (Query Builder)
        {
            var update = new Update()
                .SetTable("dbo","users", "")
                .AddWhere("id", "=", user.Id)
                .AddSet("name", user.Name)
                .AddSet("age", user.Age)
                .AddSet("gender", user.Gender)
                .AddSet("updated_at", DateTime.UtcNow);

                //.AddSet("name", null, DbType.String)
                //.AddSet("age", null, DbType.Byte)
                //.AddSet("gender", null, DbType.Byte)
                //.AddSet("updated_at", null, DbType.DateTime2)
                //.AddSet("deleted", null, DbType.Boolean)

            // UPDATE
            //   dbo.users
            // SET
            //   name = @s_0,
            //   age = @s_1,
            //   gender = @s_2,
            //   update_at = @s_3
            // WHERE
            //   id = @w_0

            affectedRowCount = await dbCommandAdapter.UpdateAsync(dbCommand, update, cancellationToken);
        }

        return affectedRowCount == 1;
    }

    public async Task<bool> DeleteUserAsync(User user, CancellationToken cancellationToken)
    {
        // CreateConnection -> CreateCommand -> Connection.Open

        int affectedRowCount;

        // Delete method A (Auto Mapper)
        {
            affectedRowCount = await dbCommandAdapter.DeleteAsync<User>(dbCommand, user, cancellationToken);
        }
        // Delete method B (Query Builder)
        {
            var delete = new Delete()
                .SetFrom("dbo", "users", "")
                .AddWhere("id", "=", user.Id);

            // DELETE FROM dbo.users
            // WHERE id = @w_0

            affectedRowCount = await dbCommandAdapter.DeleteAsync(dbCommand, delete, cancellationToken);
        }

        return affectedRowCount == 1;
    }

    public async Task<List<User>> GetTeenAgersAsync(CancellationToken cancellationToken)
    {
        // CreateConnection -> CreateCommand -> Connection.Open

        var select = new Select()
            .SetFrom("dbo", "users", "")
            .AddField("*")
            .AddOrder("age", OType.ASC);

        // SELECT method A (BETWEEN)
        {
            select.AddWhere("age", OpType.BETWEEN, new int[] { 13, 19 });

            // SELECT *
            // FROM dbo.users
            // WHERE age BETWEEN @w_0_0 AND @w_0_1
            // ORDER BY age ASC
        }
        // SELECT method B (IN)
        {
            select.AddWhere("age", OpType.IN, new int[] { 13, 14, 15, 16, 17, 18, 19 });

            // SELECT *
            // FROM dbo.users
            // WHERE age IN (@w_0_0, @w_0_1, @w_0_2, @w_0_3, @w_0_4, @w_0_5, @w_0_6)
            // ORDER BY age ASC
        }
        // SELECT method C (AND)
        {
            select
                .AddWhere("age", ">=", 13)
                .AddWhere("age", "<=", 19);

            // SELECT *
            // FROM dbo.users
            // WHERE age >= @w_0
            //   AND age <= @w_1
            // ORDER BY age ASC
        }
        // SELECT method C (OR)
        {
            select
                .AddWhere('(', "age", "=", 13)
                .AddWhere(CType.OR, "age", "=", 14)
                .AddWhere(CType.OR, "age", "=", 15)
                .AddWhere(CType.OR, "age", "=", 16)
                .AddWhere(CType.OR, "age", "=", 17)
                .AddWhere(CType.OR, "age", "=", 18)
                .AddWhere(CType.OR, "age", "=", 19, ')');

            // SELECT *
            // FROM dbo.users
            // WHERE (age = @w_0
            //    OR  age = @w_1
            //    OR  age = @w_2
            //    OR  age = @w_3
            //    OR  age = @w_4
            //    OR  age = @w_5
            //    OR  age = @w_6)
            // ORDER BY age ASC
        }

        List<User> users = await dbCommandAdapter.SelectAsync<User>(dbCommand, select, cancellationToken);

        return users;
    }

    public async Task<int> GetCountAsync(CancellationToken cancellationToken)
    {
        // CreateConnection -> CreateCommand -> Connection.Open

        var select = new Select()
            .SetFrom("users")
            .AddField("COUNT(*)");

        int? count = await dbCommandAdapter.ExecuteScalarAsync<int>(dbCommand, select, cancellationToken);

        return count ?? throw new Exception();
    }
}
~~~

~~~csharp
public class PostRepository
{
    // ...

    public async Task<List<PostCount>> GetUserPostCountsAsync(CancellationToken cancellationToken)
    {
        // CreateConnection -> CreateCommand -> Connection.Open

        var select = new Select();

        select.SetFrom("dbo", "posts", "p")
            .Joins.Add(JType.LEFT_JOIN, "dbo", "users", "u", "u.id = p.user_id");

        select.Fields
            .Add("u.id", "user_id")
            .Add("u.name", "user_name")
            .Add("COUNT(u.id)", "count");

        select.Groups
            .Add("u.id")
            .Add("u.name");

        select.Orders
            .Add("count", OType.DESC);

        // SELECT
        //   u.id AS user_id,
        //   u.name AS user_name,
        //   COUNT(u.id) AS count
        // FROM dbo.posts AS p
        //   LEFT JOIN dbo.users AS u ON (u.id = p.user_id)
        // GROUP BY
        //   u.id,
        //   u.name
        // ORDER BY
        //   count DESC

        List<PostCount> postCounts = await dbCommandAdapter.SelectAsync<PostCount>(dbCommand, select, cancellationToken);

        return postCounts;
    }
}
~~~

## Applies to

|Product|Versions|
|--|--|
|.NET|8|
