# Izayoi.Data

[Top](../README.md)

## Assemblies

|Assembly|
|--|
|Izayoi.Data.Comparable.dll|
|Izayoi.Data.DbCommandAdapter.dll|
|Izayoi.Data.DbDataMapper.dll|
|Izayoi.Data.Packs.dll|
|Izayoi.Data.Query.dll|
|Izayoi.Data.Repository.dll|
|Izayoi.Data.TimestampedObjects.dll|
|Izayoi.Data.Validation.dll|

## Namespaces

|Namespace|
|--|
|Izayoi.Data|
|Izayoi.Data.Comparable|
|Izayoi.Data.Packs|
|Izayoi.Data.Query|
|Izayoi.Data.Repository|
|Izayoi.Data.TimestampedObjects|
|Izayoi.Data.Validation|

## Classes

### Izayoi.Data

|Class|Cateogory|Remarks|
|---|---|---|
|[DbCommandAdapter](API/DbCommandAdapter/DbCommandAdapter.md)|Command|A DB command adapter.|
|[DbDataMapper](API/DbDataMapper/DbDataMapper.md)|Mapper|A DB data mapper.|
|[DbDataMapperOption](API/DbDataMapper/DbDataMapperOption.md)|Mapper|A DB data mapper option.|

### Izayoi.Data.Query

|Class|Cateogory|Remarks|
|---|---|---|
|[QueryBuilder](API/Query/Builders/QueryBuilder.md)|Builder|A query builder.|
|[QueryOption](API/Query/QueryOption.md)|Option|A build option.|
|[BindParameter](API/Query/Parameters/BindParameter.md)|Parameter|A bind paremeter.|
|[BindParameterCollection](API/Query/Parameters/BindParameterCollection.md)|Parameter|List of the bind parameters.|
|[Select](API/Query/Dml/Select.md)|DML|A select source.|
|[Insert](API/Query/Dml/Insert.md)|DML|An insert source.|
|[Update](API/Query/Dml/Update.md)|DML|An update source.|
|[Delete](API/Query/Dml/Delete.md)|DML|A delete source.|

### Izayoi.Data.Repository

|Class|Cateogory|Remarks|
|---|---|---|
|[DbRepositoryBase](API/Repository/DbRepositoryBase.md)|Repository|A DB repository base.|

### Izayoi.Data.Comparable

|Class / Structure|Cateogory|Remarks|
|---|---|---|
|[ComparableEnum&lt;TEnum&gt;](API/Comparable/ComparableEnum-1.md)|Enum|A comparable enumulation.|
|[ComparableNullable&lt;TValue&gt;](API/Comparable/ComparableNullable-1.md)|Nullable|A comparable nullable value.|

### Izayoi.Data.Packs

|Structure|Cateogory|Remarks|
|---|---|---|
|[ComparableStructPack&lt;TValue1, TValue2&gt;](API/Packs/ComparableStructPack-2.md)|comparable|A comparable struct pack.|
|[ComparableStructPack&lt;TValue1, TValue2, TValue3&gt;](API/Packs/ComparableStructPack-3.md)|comparable|A comparable struct pack.|
|[ComparableStructPack&lt;TValue1, TValue2, TValue3, TValue4&gt;](API/Packs/ComparableStructPack-4.md)|comparable|A comparable struct pack.|
|[ComparableStructPack&lt;TValue1, TValue2, TValue3, TValue4, TValue5&gt;](API/Packs/ComparableStructPack-5.md)|comparable|A comparable struct pack.|
|[UncomparableStructPack&lt;TValue1, TValue2&gt;](API/Packs/UncomparableStructPack-2.md)|uncomarable|A uncomparable struct pack.|
|[UncomparableStructPack&lt;TValue1, TValue2, TValue3&gt;](API/Packs/UncomparableStructPack-3.md)|uncomarable|A uncomparable struct pack.|
|[UncomparableStructPack&lt;TValue1, TValue2, TValue3, TValue4&gt;](API/Packs/UncomparableStructPack-4.md)|uncomarable|A uncomparable struct pack.|
|[UncomparableStructPack&lt;TValue1, TValue2, TValue3, TValue4, TValue5&gt;](API/Packs/UncomparableStructPack-5.md)|uncomarable|A uncomparable struct pack.|

### Izayoi.Data.TimestampedObjects

|Class / Structure|Cateogory|Remarks|
|---|---|---|
|[ComparableTimestampedClass&lt;TValue&gt;](API/TimestampedObjects/ComparableTimestampedClass-1.md)|comparable|A comparable timestamped class that can be assigned comparable class.|
|[ComparableTimestampedObject&lt;TValue&gt;](API/TimestampedObjects/ComparableTimestampedObject-1.md)|comparable|A comparable timestamped class that can be assigned comparable object.|
|[ComparableTimestampedStruct&lt;TValue&gt;](API/TimestampedObjects/ComparableTimestampedStruct-1.md)|comparable|A comparable timestamped structure that can be assigned comparable structure.|
|[UncomparableTimestampedClass&lt;TValue&gt;](API/TimestampedObjects/UncomparableTimestampedClass-1.md)|uncomparable|A uncomparable timestamped class that can be assigned uncomparable class.|
|[UncomparableTimestampedObject&lt;TValue&gt;](API/TimestampedObjects/UncomparableTimestampedObject-1.md)|uncomparable|A uncomparable timestamped class that can be assigned uncomparable object.|
|[UncomparableTimestampedStruct&lt;TValue&gt;](API/TimestampedObjects/UncomparableTimestampedStruct-1.md)|uncomparable|A uncomparable timestamped structure that can be assigned uncomparable structure.|

### Izayoi.Data.Validation

|Class|Cateogory|Remarks|
|---|---|---|
|[DataValidator](API/Validation/DataValidator.md)|Validation|A data validator.|
|[ValidationError](API/Validation/ValidationError.md)|Validation|A validation error.|

## Available Databases

for Izayoi.Data.Query

A Database with a package that implements classes that inherit from the `DbCommand` and `DbDataReader` classes.

|Database|NuGet|GitHub|Project|
|---|---|---|---|
|MySQL|[MySqlConnector](https://www.nuget.org/packages/MySqlConnector/)|[MySqlConnector](https://github.com/mysql-net/MySqlConnector)|[mysqlconnector.net](https://mysqlconnector.net/)|
|PostgreSQL|[Npgsql](https://www.nuget.org/packages/Npgsql/)|[Npgsql](https://github.com/npgsql/npgsql)|[Npgsql](https://www.npgsql.org/)|
|SQL Server|[Microsoft.Data.Sqlclient](https://www.nuget.org/packages/Microsoft.Data.Sqlclient/)|-|-|
|SQLite|[Microsoft.Data.Sqlite](https://www.nuget.org/packages/Microsoft.Data.Sqlite)|-|-|
