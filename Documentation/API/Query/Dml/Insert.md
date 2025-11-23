# Insert

[Top](../../../../README.md) / [Documentation](../../../Documentation.md)

## Definition

|||
|---|---|
|Namespace|Izayoi.Data.Query|
|Assembly|Izayoi.Data.Query.dll|

Represents a Insert source.

~~~csharp
public class Insert
~~~

### Inheritance
Object -> Insert

## Constructors

|Name|Summary|
|---|---|
|Insert()|Initializes an instance of the Insert class.|
|Insert(string tableName)|Initializes a new instance of the Insert class with the specified tableName.|
|Insert(string tableName, string tableAlias)|Initializes an instance of the Insert class with the specified tableName and tableAlias.|
|Insert(string schemaName, string tableName, string tableAlias)|Initializes an instance of the Insert class with the specified schemaName, tableName and tableAlias.|

## Properties

#### `Into` TableSource

Insert clause

#### `Values` Values

VALUES clause

It cannot be used when using the SELECT clause.

#### `ColumnList` Fields?

column list

Use only when using a SELECT clause.

#### `Select` Select?

SELECT clause (dml table source)

It cannot be used when using the VALUES clause.

#### `With` With

WITH clause

## Methods

|Name|Returns|
|---|---|
|SetInto(string tableName)|Insert|
|SetInto(string tableName, string tableAlias)|Insert|
|SetInto(string schemaName, string tableName, string tableAlias)|Insert|
|AddColumn(string columnName)|Insert|
|AddValue(Value value)|Insert|
|AddValue(string columnName, object? value)|Insert|
|AddValue(string columnName, object? value, DbType dbType)|Insert|
|AddValue(string columnName, object? value, bool isExpression)|Insert|
|ClearValues()|Insert|
|SetWith(bool recursive)|Insert|
|ClearWith()|Insert|

## Applies to

|Product|Versions|
|---|---|
|.NET|8, 9, 10|
|.NET Standard|2.1|
