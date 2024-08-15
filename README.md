# Izayoi.Data

This is a database operation support library that includes a fast micro O/R mapper (ORM).

## Feature

It has three functions.

1. `DbDataMapper`: This is a micro O/R mapper.
2. `QueryBuilder`: This helps construct the query and parameters.
3. `DbCommandAdapter`: The above two functions are combined to support command execution.

## Documentation

[Documantation](Documentation/Documentation.md)

## Wiki

[Wiki](https://github.com/izayoijiichan/Izayoi.Data.DbCommandAdapter/wiki)

## Available Databases

A Database with a package that implements classes that inherit from the `DbCommand` and `DbDataReader` classes.

|Database|Nuget|GitHub|Project|
|--|--|--|--|
|MySQL|[MySqlConnector](https://www.nuget.org/packages/MySqlConnector/)|[MySqlConnector](https://github.com/mysql-net/MySqlConnector)|[mysqlconnector.net](https://mysqlconnector.net/)|
|PostgreSQL|[Npgsql](https://www.nuget.org/packages/Npgsql/)|[Npgsql](https://github.com/npgsql/npgsql)|[Npgsql](https://www.npgsql.org/)|
|SQL Server|[Microsoft.Data.Sqlclient](https://www.nuget.org/packages/Microsoft.Data.Sqlclient/)|-|-|
|SQLite|[Microsoft.Data.Sqlite](https://www.nuget.org/packages/Microsoft.Data.Sqlite)|-|-|

## Installation

|Package Name|Nuget|GitHub|
|--|--|--|
|Izayoi.Data.DbCommandAdapter|[Izayoi.Data.DbCommandAdapter](https://www.nuget.org/packages/Izayoi.Data.DbCommandAdapter)|[Izayoi.Data](https://github.com/izayoijiichan/Izayoi.Data.DbCommandAdapter)|
|Izayoi.Data.DbDataMapper|[Izayoi.Data.DbDataMapper](https://www.nuget.org/packages/Izayoi.Data.DbDataMapper)|[Izayoi.Data](https://github.com/izayoijiichan/Izayoi.Data.DbCommandAdapter)|
|Izayoi.Data.Query|[Izayoi.Data.Query](https://www.nuget.org/packages/Izayoi.Data.Query)|[Izayoi.Data](https://github.com/izayoijiichan/Izayoi.Data.DbCommandAdapter)|

## Examples

### Map classes

~~~csharp
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("users")]
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
}

[Table("posts")]
public class Post
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("user_id")]
    public int UserId { get; set; }

    [Column("comment")]
    public string Comment { get; set; } = string.Empty;

    [NotMapped]
    public int IgnoreProperty { get; set; }
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

### DbDataMapper

The most important method is `ExecuteQueryAsync<T>`.  
And maybe you'll have an opportunity to use methods `ReadToObjectAsync<T>` and `ReadToObjectsAsync<T>`.

~~~csharp
using System.Collections.Generic;
using System.Threading.Tasks;
using Izayoi.Data;
using Microsoft.Data.SqlClient;  // for SQL Server
//using Microsoft.Data.Sqlite;   // for SQLite
//using MySqlConnector;          // for MySQL
//using Npgsql;                  // for PostgreSQL

public class UserRepository
{
    private readonly string dbConnectionString;

    private readonly DbDataMapper dbDataMapper = new();

    public async Task<List<User>> GetUsers(CancellationToken cancellationToken)
    {
        using SqlConnection dbConnection = new(dbConnectionString);

        using SqlCommand dbCommand = dbConnection.CreateCommand();

        dbCommand.CommandText = "SELECT * FROM users";

        dbConnection.Open();

        // Map DB data to objects.
        List<User> users = await dbDataMapper.ExecuteQueryAsync<User>(dbCommand, cancellationToken);

        dbConnection.Close();

        return users;
    }
}
~~~

### DbCommandAdapter

~~~csharp
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
    }

    public async Task<List<User>> GetUsers(CancellationToken cancellationToken)
    {
        using SqlConnection dbConnection = new(dbConnectionString);

        using SqlCommand dbCommand = dbConnection.CreateCommand();

        dbConnection.Open();

        // SELECT ALL
        List<User> users = await dbCommandAdapter.SelectAllAsync<User>(dbCommand, cancellationToken);

        dbConnection.Close();

        return users;
    }

    public async Task<User?> GetUser(int userId, CancellationToken cancellationToken)
    {
        // CreateConnection -> CreateCommand -> Connection.Open

        var select = new Select()
            .SetFrom("users")
            .AddField("*")
            .AddWhere("id", "=", userId);

        List<User> users = await dbCommandAdapter.SelectAsync<User>(dbCommand, select, cancellationToken);

        return users.FirstOrDefault();
    }

    public async Task<List<User>> GetTeenAgers(CancellationToken cancellationToken)
    {
        // CreateConnection -> CreateCommand -> Connection.Open

        var select = new Select()
            .SetFrom("users")
            .AddField("*")
            .AddWhere("age", OpType.BETWEEN, new int[] { 13, 19 })
            .AddOrder("age", OType.ASC);

        List<User> users = await dbCommandAdapter.SelectAsync<User>(dbCommand, select, cancellationToken);

        return users;
    }

    public async Task<User> AddUser(string name, byte age, GenderType gender, CancellationToken cancellationToken)
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

    public async Task<bool> UpdateUser(User user, CancellationToken cancellationToken)
    {
        // CreateConnection -> CreateCommand -> Connection.Open

        user.UpdatedAt = DateTime.UtcNow;

        var excludeColumns = new string[] { "created_at" };

        int affectedRowCount = await dbCommandAdapter.UpdateAsync<User>(dbCommand, user, excludeColumns, cancellationToken);

        return affectedRowCount == 1;
    }

    public async Task<bool> DeleteUser(User user, CancellationToken cancellationToken)
    {
        // CreateConnection -> CreateCommand -> Connection.Open

        int affectedRowCount = await dbCommandAdapter.DeleteAsync<User>(dbCommand, user, cancellationToken);

        return affectedRowCount == 1;
    }

    public async Task<int> GetCount(CancellationToken cancellationToken)
    {
        // CreateConnection -> CreateCommand -> Connection.Open

        var select = new Select()
            .SetFrom("users")
            .AddField("COUNT(*)");

        int? count = await dbCommandAdapter.ExecuteScalarAsync<int>(dbCommand, select, cancellationToken);

        return count ?? throw new Exception();
    }

    public async Task<List<User>> GetSelectUsers(Select select, CancellationToken cancellationToken)
    {
        // CreateConnection -> CreateCommand -> Connection.Open

        List<User> users = await dbCommandAdapter.SelectAsync<User>(dbCommand, select, cancellationToken);

        return users;
    }

    public async Task<List<User>> GetQueryUsers(string query, Array parameters, CancellationToken cancellationToken)
    {
        // CreateConnection -> CreateCommand -> Connection.Open

        dbCommand.CommandText = query;

        dbCommand.Parameters.AddRange(parameters);

        List<User> users = await dbCommandAdapter.ExecuteQueryAsync<User>(dbCommand, cancellationToken);

        return users;
    }
}
~~~

~~~csharp
public class PostRepository
{
    // ...

    public async Task<List<PostCount>> GetUserPostCounts(CancellationToken cancellationToken)
    {
        // CreateConnection -> CreateCommand -> Connection.Open

        var select = new Select();

        select.SetFrom("posts", "p")
            .Joins.Add(JType.LEFT_JOIN, "users", "u", "u.id = p.user_id");

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
        // FROM posts AS p
        //   LEFT JOIN users AS u ON (u.id = p.user_id)
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

### QueryBuilder

See [QueryBuilder](Documentation/API/Query/Builders/QueryBuilder.md).

___
Last updated: 16 August, 2024  
Editor: Izayoi Jiichan

*Copyright (C) 2024 Izayoi Jiichan. All Rights Reserved.*
