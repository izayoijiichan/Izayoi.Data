# Izayoi.Data

This is a database operation support library that includes a fast micro O/R mapper (ORM).

![.net](https://img.shields.io/badge/.NET-8%2c9%2c10-2196F3.svg?logo=.net&style=flat)
![license](https://img.shields.io/github/license/izayoijiichan/Izayoi.Data)
[![wiki](https://img.shields.io/badge/GitHub-wiki-181717.svg?logo=github&style=flat)](https://github.com/izayoijiichan/Izayoi.Data/wiki)

## Feature

It has 9 functions.

1. `DbDataMapper`: This is a micro O/R mapper.
2. `QueryBuilder`: This helps construct the query and parameters.
3. `DbCommandAdapter`: The above two functions are combined to support command execution.
4. `DbRepositoryBase`: It provides basic CRUD operations on table.
5. `DataValidator`: It provides fast model validation.
6. `ComparableEnum`: This is a comparable enumlation.
7. `ComparableNullable`: This is a comparable nullable value.
8. `ComparableStructPack`: This is a comparable structure pack.
9. `TimestampedObject`: This is a timestamped object.

## Documentation

[Documantation](Documentation/Documentation.md)

## Wiki

[Wiki](https://github.com/izayoijiichan/Izayoi.Data/wiki)

## Available Databases

A Database with a package that implements classes that inherit from the `DbCommand` and `DbDataReader` classes.

|Database|NuGet|GitHub|Project|
|---|---|---|---|
|MySQL|[MySqlConnector](https://www.nuget.org/packages/MySqlConnector/)|[MySqlConnector](https://github.com/mysql-net/MySqlConnector)|[mysqlconnector.net](https://mysqlconnector.net/)|
|PostgreSQL|[Npgsql](https://www.nuget.org/packages/Npgsql/)|[Npgsql](https://github.com/npgsql/npgsql)|[Npgsql](https://www.npgsql.org/)|
|SQL Server|[Microsoft.Data.Sqlclient](https://www.nuget.org/packages/Microsoft.Data.Sqlclient/)|-|-|
|SQLite|[Microsoft.Data.Sqlite](https://www.nuget.org/packages/Microsoft.Data.Sqlite)|-|-|

## Installation

|Package Name|NuGet|GitHub|
|---|---|---|
|Izayoi.Data.Comparable|[Izayoi.Data.Comparable](https://www.nuget.org/packages/Izayoi.Data.Comparable)|[Izayoi.Data](https://github.com/izayoijiichan/Izayoi.Data)|
|Izayoi.Data.DbCommandAdapter|[Izayoi.Data.DbCommandAdapter](https://www.nuget.org/packages/Izayoi.Data.DbCommandAdapter)|[Izayoi.Data](https://github.com/izayoijiichanIzayoi.Data)|
|Izayoi.Data.DbDataMapper|[Izayoi.Data.DbDataMapper](https://www.nuget.org/packages/Izayoi.Data.DbDataMapper)|[Izayoi.Data](https://github.com/izayoijiichan/Izayoi.Data)|
|Izayoi.Data.Packs|[Izayoi.Data.Packs](https://www.nuget.org/packages/Izayoi.Data.Packs)|[Izayoi.Data](https://github.com/izayoijiichan/Izayoi.Data)|
|Izayoi.Data.Query|[Izayoi.Data.Query](https://www.nuget.org/packages/Izayoi.Data.Query)|[Izayoi.Data](https://github.com/izayoijiichan/Izayoi.Data)|
|Izayoi.Data.Repository|[Izayoi.Data.Repository](https://www.nuget.org/packages/Izayoi.Data.Repository)|[Izayoi.Data](https://github.com/izayoijiichan/Izayoi.Data)|
|Izayoi.Data.TimestampedObjects|[Izayoi.Data.TimestampedObjects](https://www.nuget.org/packages/Izayoi.Data.TimestampedObjects)|[Izayoi.Data](https://github.com/izayoijiichan/Izayoi.Data)|
|Izayoi.Data.Validation|[Izayoi.Data.Validation](https://www.nuget.org/packages/Izayoi.Data.Validation)|[Izayoi.Data](https://github.com/izayoijiichan/Izayoi.Data)|

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
using System.Linq;
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

    public async Task<User> AddUser(string name, byte age, GenderType gender, CancellationToken cancellationToken)
    {
        using SqlConnection dbConnection = new(dbConnectionString);

        using SqlCommand dbCommand = dbConnection.CreateCommand();

        dbConnection.Open();

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

        dbConnection.Close();

        user.Id = userId;

        return user;
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
}
~~~
## Unity

`manifest.json`

~~~json
{
  "dependencies": {
    "com.izayoi.data.comparable": "1.1.0",
    "com.izayoi.data.dbcommandadapter": "1.3.0",
    "com.izayoi.data.dbdatamapper": "1.2.0",
    "com.izayoi.data.packs": "1.1.0",
    "com.izayoi.data.query": "1.3.0",
    "com.izayoi.data.repository": "1.2.0",
    "com.izayoi.data.timestampedobjects": "1.1.0",
    "com.izayoi.data.validation": "1.3.0",
    "org.nuget.microsoft.bcl.hashcode": "6.0.0",
    "org.nuget.system.componentmodel.annotations": "4.4.0"
  },
  "scopedRegistries": [
    {
      "name": "OpenUPM",
      "url": "https://package.openupm.com",
      "scopes": [
        "com.izayoi"
      ]
    }
  ]
}
~~~
or
~~~json
{
  "dependencies": {
    "com.izayoi.data.comparable": "https://github.com/izayoijiichan/Izayoi.Data.git?path=Izayoi.Data.Comparable",
    "com.izayoi.data.dbcommandadapter": "https://github.com/izayoijiichan/Izayoi.Data.git?path=Izayoi.Data.DbCommandAdapter",
    "com.izayoi.data.dbdatamapper": "https://github.com/izayoijiichan/Izayoi.Data.git?path=Izayoi.Data.DbDataMapper",
    "com.izayoi.data.packs": "https://github.com/izayoijiichan/Izayoi.Data.git?path=Izayoi.Data.Packs",
    "com.izayoi.data.query": "https://github.com/izayoijiichan/Izayoi.Data.git?path=Izayoi.Data.Query",
    "com.izayoi.data.repository": "https://github.com/izayoijiichan/Izayoi.Data.git?path=Izayoi.Data.Repository",
    "com.izayoi.data.timestampedobjects": "https://github.com/izayoijiichan/Izayoi.Data.git?path=Izayoi.Data.TimestampedObjects",
    "com.izayoi.data.validation": "https://github.com/izayoijiichan/Izayoi.Data.git?path=Izayoi.Data.Validation",
    "org.nuget.microsoft.bcl.hashcode": "6.0.0",
    "org.nuget.system.componentmodel.annotations": "4.4.0"
  }
}
~~~
___
Last updated: 24 November, 2025  
Editor: Izayoi Jiichan

*Copyright (C) 2024 Izayoi Jiichan. All Rights Reserved.*
