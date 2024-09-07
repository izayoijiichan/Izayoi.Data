# Izayoi.Data.DbDataMapper

This is a fast micro O/R mapper (ORM) that stores data retrieved from a DB into any object.

## Available Databases

A Database with a package that implements classes that inherit from the `DbCommand` and `DbDataReader` classes.

|Database|NuGet|GitHub|Project|
|--|--|--|--|
|MySQL|[MySqlConnector](https://www.nuget.org/packages/MySqlConnector/)|[MySqlConnector](https://github.com/mysql-net/MySqlConnector)|[mysqlconnector.net](https://mysqlconnector.net/)|
|PostgreSQL|[Npgsql](https://www.nuget.org/packages/Npgsql/)|[Npgsql](https://github.com/npgsql/npgsql)|[Npgsql](https://www.npgsql.org/)|
|SQL Server|[Microsoft.Data.Sqlclient](https://www.nuget.org/packages/Microsoft.Data.Sqlclient/)|-|-|
|SQLite|[Microsoft.Data.Sqlite](https://www.nuget.org/packages/Microsoft.Data.Sqlite)|-|-|

## Wiki

[Wiki](https://github.com/izayoijiichan/Izayoi.Data.DbCommandAdapter/wiki)

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
- The `[Key]` attribute is set to the primary key, but is not used by the `DbDataMapper` alone. (It is used when combined with the `DbCommandAdapter` class.)

### DbDataMapper

~~~csharp
using System.Collections.Generic;
using System.Threading.Tasks;
using Izayoi.Data;
using Microsoft.Data.SqlClient;  // for SQL Server
//using Microsoft.Data.Sqlite;   // for SQLite
//using MySqlConnector;          // for MySQL
//using Npgsql;                  // for PostgreSQL

public class Example()
{
    private readonly dbConnectionString;

    private readonly DbDataMapper dbDataMapper = new();

    public async Task Method(CancellationToken cancellationToken)
    {
        using SqlConnection dbConnection = new(dbConnectionString);

        using SqlCommand dbCommand = dbConnection.CreateCommand();

        dbConnection.Open();

        List<User> users;

        // Select method A
        {
            dbCommand.CommandText = "SELECT * FROM dbo.users";

            using SqlDataReader dbDataReader = await dbCommand.ExecuteReaderAsync(cancellationToken);

            users = await dbDataMapper.ReadToObjectsAsync<User>(dbDataReader, cancellationToken);
        }
        // Select method B
        {
            dbCommand.CommandText = "SELECT * FROM dbo.users";

            users = await dbDataMapper.ExecuteQueryAsync<User>(dbCommand, cancellationToken);
        }
        // Select method C
        {
            users = await dbDataMapper.SelectAllAsync<User>(dbCommand, cancellationToken);
        }

        dbConnection.Close();
    }
}
~~~

## Remarks

Reuse a `DbDataMapper` object whenever possible.

## For a better experience

This library really shines when used in conjunction with the `Izayoi.Data.DbCommandAdapter`.

___
Last updated: 16 August, 2024  
Editor: Izayoi Jiichan

*Copyright (C) 2024 Izayoi Jiichan. All Rights Reserved.*
