# Izayoi.Data.Repository

This is a database operation repository infrastructure with CRUD functionality.

## Available Databases

A Database with a package that implements classes that inherit from the `DbCommand` and `DbDataReader` classes.

|Database|NuGet|GitHub|Project|
|---|---|---|---|
|MySQL|[MySqlConnector](https://www.nuget.org/packages/MySqlConnector/)|[MySqlConnector](https://github.com/mysql-net/MySqlConnector)|[mysqlconnector.net](https://mysqlconnector.net/)|
|PostgreSQL|[Npgsql](https://www.nuget.org/packages/Npgsql/)|[Npgsql](https://github.com/npgsql/npgsql)|[Npgsql](https://www.npgsql.org/)|
|SQL Server|[Microsoft.Data.Sqlclient](https://www.nuget.org/packages/Microsoft.Data.Sqlclient/)|-|-|
|SQLite|[Microsoft.Data.Sqlite](https://www.nuget.org/packages/Microsoft.Data.Sqlite)|-|-|

## Applies to

|Product|Versions|
|---|---|
|.NET|8, 9, 10|
|.NET Standard|2.1|
|Unity|2021, 2022, 6000|

## Wiki

[Wiki](https://github.com/izayoijiichan/Izayoi.Data/wiki)

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
~~~

### Map class

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
~~~

- If the `[Table]` attribute is not defined, the class name is used as the table name.
- If the `[Column]` attribute is not defined, the property name is used as the column name.
- If the `[NotMapped]` attribute is defined, the property is excluded from the mapping.
- The `[Key]` attribute is set to the primary key. It is used for update or delete methods.

### Repository Class

~~~csharp
using Izayoi.Data;
using Izayoi.Data.Query;
using Izayoi.Data.Repository;

public class UserRepository : DbRepositoryBase<User, int>  // <MapClass, KeyDataType>
{
    public UserRepository(IDbDataMapper dbDataMapper, QueryOption queryOption)
        : base(dbDataMapper, queryOption) { }

    public UserRepository(IDbCommandAdapter dbCommandAdapter)
        : base(dbCommandAdapter) { }
}
~~~

### Example Class

~~~csharp
using System.Collections.Generic;
using System.Threading.Tasks;
using Izayoi.Data;
using Izayoi.Data.Query;
using Microsoft.Data.SqlClient;  // for SQL Server
//using Microsoft.Data.Sqlite;   // for SQLite
//using MySqlConnector;          // for MySQL
//using Npgsql;                  // for PostgreSQL

public class Example
{
    private readonly string dbConnectionString;

    private readonly DbCommandAdapter dbCommandAdapter;

    private readonly DbDataMapper dbDataMapper;

    private readonly QueryOption queryOption;

    private readonly UserRepository userRepository;

    public Example()
    {
        queryOption = new QueryOption(RdbKind.SqlServer);

        dbDataMapper = new DbDataMapper();

        dbCommandAdapter = new DbCommandAdapter(dbDataMapper, queryOption);

        userRepository = new UserRepository(dbCommandAdapter);
    }

    public async Task Method1(CancellationToken cancellationToken)
    {
        using SqlConnection dbConnection = new(dbConnectionString);

        dbConnection.Open();

        List<User> users = await userRepository.FetchAllAsync(dbConnection, cancellationToken);

        User? user = await userRepository.FetchAsync(dbConnection, id: 1, cancellationToken);

        dbConnection.Close();
    }

    public async Task Method2(CancellationToken cancellationToken)
    {
        using SqlConnection dbConnection = new(dbConnectionString);

        dbConnection.Open();

        var user = new User()
        {
            Id = 0,
            Name = "name1",
            Age = 20,
            Gender = GenderType.Male,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow,
        };

        int affectedRowCount;

        affectedRowCount = await userRepository.InsertReturnAsync(dbConnection, user, cancellationToken);

        user.Age = 21;
        user.UpdateAt = DateTime.UtcNow;

        affectedRowCount = await userRepository.UpdateAsync(dbConnection, user, cancellationToken);

        affectedRowCount = await userRepository.DeleteAsync(dbConnection, user, cancellationToken);

        dbConnection.Close();
    }
}
~~~

___
Last updated: 24 November, 2025  
Editor: Izayoi Jiichan

*Copyright (C) 2024 Izayoi Jiichan. All Rights Reserved.*
