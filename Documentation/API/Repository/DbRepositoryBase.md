# DbRepositoryBase

[Top](../../../README.md) / [Documentation](../../Documentation.md)

## Definition

|||
|--|--|
|Namespace|Izayoi.Data.Repository|
|Assembly|Izayoi.Data.Repository.dll|

Represents a DB repository base.

~~~csharp
public abstract class DbRepositoryBase<TData, TKey>
~~~

### Type Parameters

#### `TData`

The map class.

#### `TKey`

The data type of the key column.

### Inheritance
Object -> DbRepositoryBase\<TData, TKey>

## Constructors

|Name|Summary|
|--|--|
|DbRepositoryBase(IDbDataMapper dbDataMapper, QueryOption queryOption)|Initializes a new instance of the DbRepositoryBase class with the specified dbDataMapper and queryOption.|
|DbRepositoryBase(IDbCommandAdapter dbCommandAdapter)|Initializes a new instance of the DbRepositoryBase class with the specified dbCommandAdapter.|

## Methods

|Name|Returns|Summary|
|--|--|--|
|GetCountAsync(DbConnection dbConnection, CancellationToken cancellationToken)|Task\<int>|Gets the count of records.|
|FetchAsync(DbConnection dbConnection, TKey id, CancellationToken cancellationToken)|Task\<TData?>|Gets the data for the specified ID.|
|FetchAsync(DbConnection dbConnection, IEnumerable\<TKey> ids, CancellationToken cancellationToken)|Task\<List\<TData>>|Gets the data for the specified IDs.|
|FetchAllAsync(DbConnection dbConnection, CancellationToken cancellationToken)|Task\<List\<TData>>|Gets all the data.|
|InsertAsync(DbConnection dbConnection, TData data, CancellationToken cancellationToken)|Task\<int>|Executes an INSERT query.|
|InsertReturnAsync(DbConnection dbConnection, TData data, CancellationToken cancellationToken)|Task\<int>|Execute the INSERT query, get the inserted identity value, and set it in the data.|
|UpdateAsync(DbConnection dbConnection, TData data, CancellationToken cancellationToken)|Task\<int>|Executes an UPDATE query.|
|DeleteAsync(DbConnection dbConnection, TKey id, CancellationToken cancellationToken)|Task\<int>|Executes a DELETE query.|
|DeleteAsync(DbConnection dbConnection, TData data, CancellationToken cancellationToken)|Task\<int>|Executes a DELETE query.|
|GetCommandTimeout(int queryType)|int|Get command timeout.|
|SetCommandTimeout(int queryType, int timeout)|void|Set command timeout.|

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
~~~

- If the `[Table]` attribute is not defined, the class name is used as the table name.
- If the `[Column]` attribute is not defined, the property name is used as the column name.
- If the `[NotMapped]` attribute is defined, the property is excluded from the mapping.
- The `[Key]` attribute is set to the primary key. It is used for update or delete methods.

### Repository Class

~~~csharp
using Izayoi.Data;
using Izayoi.Data.Repository;
using Izayoi.Data.Query;

public class UserRepository : DbRepositoryBase<User, int>
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

## Applies to

|Product|Versions|
|--|--|
|.NET|8|
