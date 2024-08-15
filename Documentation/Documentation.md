# Izayoi.Data

[Top](../README.md)

## Assemblies

|Assembly|
|--|
|Izayoi.Data.DbCommandAdapter.dll|
|Izayoi.Data.DbDataMapper.dll|
|Izayoi.Data.Query.dll|

## Namespaces

|Namespace|
|--|
|Izayoi.Data|
|Izayoi.Data.Query|

## Classes

### Izayoi.Data

|Class|Cateogory|Remarks|
|--|--|--|
|[DbCommandAdapter](API/DbCommandAdapter/DbCommandAdapter.md)|Command|A DB command adapter.|
|[DbDataMapper](API/DbDataMapper/DbDataMapper.md)|Mapper|A DB data mapper.|
|[DbDataMapperOption](API/DbDataMapper/DbDataMapperOption.md)|Mapper|A DB data mapper option.|

### Izayoi.Data.Query

|Class|Cateogory|Remarks|
|--|--|--|
|[QueryBuilder](API/Query/Builders/QueryBuilder.md)|Builder|A query builder.|
|[QueryOption](API/Query/QueryOption.md)|Option|A build option.|
|[BindParameter](API/Query/Parameters/BindParameter.md)|Parameter|A bind paremeter.|
|[BindParameterCollection](API/Query/Parameters/BindParameterCollection.md)|Parameter|List of the bind parameters.|
|[Select](API/Query/Dml/Select.md)|DML|A select source.|
|[Insert](API/Query/Dml/Insert.md)|DML|An insert source.|
|[Update](API/Query/Dml/Update.md)|DML|An update source.|
|[Delete](API/Query/Dml/Delete.md)|DML|A delete source.|

## Available Databases

A Database with a package that implements classes that inherit from the `DbCommand` and `DbDataReader` classes.

|Database|Nuget|GitHub|Project|
|--|--|--|--|
|MySQL|[MySqlConnector](https://www.nuget.org/packages/MySqlConnector/)|[MySqlConnector](https://github.com/mysql-net/MySqlConnector)|[mysqlconnector.net](https://mysqlconnector.net/)|
|PostgreSQL|[Npgsql](https://www.nuget.org/packages/Npgsql/)|[Npgsql](https://github.com/npgsql/npgsql)|[Npgsql](https://www.npgsql.org/)|
|SQL Server|[Microsoft.Data.Sqlclient](https://www.nuget.org/packages/Microsoft.Data.Sqlclient/)|-|-|
|SQLite|[Microsoft.Data.Sqlite](https://www.nuget.org/packages/Microsoft.Data.Sqlite)|-|-|
