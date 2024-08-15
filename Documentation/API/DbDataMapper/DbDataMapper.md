# DbDataMapper

[Top](../../../README.md) / [Documentation](../../Documentation.md)

## Definition

|||
|--|--|
|Namespace|Izayoi.Data|
|Assembly|Izayoi.Data.DbDataMapper.dll|

Represents a DB data mapper.

~~~csharp
public class DbDataMapper : IDbDataMapper
~~~

### Inheritance
Object -> DbDataMapper

## Constructors

|Name|Summary|
|--|--|
|DbDataMapper()|Initializes an instance of the DbDataMapper class.|
|DbDataMapper(DbDataMapperOption option)|Initializes an instance of the DbDataMapper class with the specified option.|

## Properties

#### `Option` [DbDataMapperOption](DbDataMapperOption.md)

Gets the DB data mapper option.

## Methods

|Name|Returns|Summary|
|--|--|--|
|ReadToObjectAsync\<T>(DbDataReader dbDataReader, CancellationToken cancellationToken)|Task<T?>|Gets the first record from the DB data reader's record set, sets the values ​​for the specified T class, and returns it.|
|ReadToObjectsAsync\<T>(DbDataReader dbDataReader, CancellationToken cancellationToken)|Task<List\<T>>|Gets the records from the DB data reader's record set, sets the values ​​for the specified T class, and returns it.|
|ExecuteQueryAsync\<T>(DbCommand dbCommand, CancellationToken cancellationToken)|Task<List\<T>>|Executes a DB command and returns the record set in an object.|
|SelectAllAsync\<T>(DbCommand dbCommand, CancellationToken cancellationToken)|Task<List\<T>>|Executes a SELECT query and returns the record set in an object.|
|GetColumnNameMapper(Type objectType)|PropertyMapper|Gets the column name mapper of the specified object type.|
|GetSchemaAndTable(Type objectType)|(string schemaName, string tableName)|Gets the schema and table name of the specified object type.|
|GetSchemaName(Type objectType)|string|Gets the schema name of the specified object type.|
|GetTableName(Type objectType)|string|Gets the table name of the specified object type.|
|SetTableName(Type objectType, string tableName)|void|Sets the table name for the specified object type in the cache.|
|SetTableAndSchema(Type objectType, string tableName, string schemaName)|void|Sets the table and schema name for the specified object type in the cache.|

## Remarks

Reuse a `DbDataMapper` object whenever possible.

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

### Mapping Class


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

### Data Access


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

## Available Databases

A Database with a package that implements classes that inherit from the `DbCommand` and `DbDataReader` classes.

|Database|Nuget|GitHub|Project|
|--|--|--|--|
|MySQL|[MySqlConnector](https://www.nuget.org/packages/MySqlConnector/)|[MySqlConnector](https://github.com/mysql-net/MySqlConnector)|[mysqlconnector.net](https://mysqlconnector.net/)|
|PostgreSQL|[Npgsql](https://www.nuget.org/packages/Npgsql/)|[Npgsql](https://github.com/npgsql/npgsql)|[Npgsql](https://www.npgsql.org/)|
|SQL Server|[Microsoft.Data.Sqlclient](https://www.nuget.org/packages/Microsoft.Data.Sqlclient/)|-|-|
|SQLite|[Microsoft.Data.Sqlite](https://www.nuget.org/packages/Microsoft.Data.Sqlite)|-|-|

## Applies to

|Product|Versions|
|--|--|
|.NET|8|
