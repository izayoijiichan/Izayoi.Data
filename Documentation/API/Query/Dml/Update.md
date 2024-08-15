# Update

[Top](../../../../README.md) / [Documentation](../../../Documentation.md)

## Definition

|||
|--|--|
|Namespace|Izayoi.Data.Query|
|Assembly|Izayoi.Data.Query.dll|

Represents a update source.

~~~csharp
public class Update
~~~

### Inheritance
Object -> Update

## Constructors

|Name|Summary|
|--|--|
|Update()|Initializes an instance of the Update class.|
|Update(string tableName)|Initializes a new instance of the Update class with the specified tableName.|
|Update(string tableName, string tableAlias)|Initializes an instance of the Update class with the specified tableName and tableAlias.|
|Update(string schemaName, string tableName, string tableAlias)|Initializes an instance of the Update class with the specified schemaName, tableName and tableAlias.|

## Properties

#### `TableSource` TableSource

UPDATE clause and JOIN clause

#### `Sets` Sets

SET clause

#### `From` From?

FROM clause and JOIN clause

Used when using a JOIN clause in PostgreSQL, SQLite and SQL Server.

#### `Wheres` Wheres

WHERE clause

## Methods

|Name|Returns|
|--|--|
|SetTable(string tableName)|Update|
|SetTable(string tableName, string tableAlias)|Update|
|SetTable(string schemaName, string tableName, string tableAlias)|Update|
|AddSet(Set set)|Update|
|AddSet(string columnName, object? value)|Update|
|AddSet(string columnName, object? value, DbType dbType)|Update|
|AddSet(string columnName, object? value, bool isExpression)|Update|
|ClearSets()|Update|
|SetFrom(string tableName)|Update|
|SetFrom(string tableName, string tableAlias)|Update|
|SetFrom(string schemaName, string tableName, string tableAlias)|Update|
|AddJoin(Join item)|Update|
|AddJoin(JType type, string tableName, string condition)|Update|
|AddJoin(JType type, string tableName, string tableAlias, string condition)|Update|
|AddJoin(JType type, string schemaName, string tableName, string tableAlias, string condition)|Update|
|ClearJoin()|Update|
|AddWhere(SearchCondition searchCondition)|Update|
|AddWhere(string fieldName, string operate, object? value = null)|Update|
|AddWhere(string fieldName, string operate, object? value, DbType dbType)|Update|
|AddWhere(string fieldName, string operate, object? value, bool isExpression)|Update|
|AddWhere(char enclosureL, string fieldName, string operate, object? value = null)|Update|
|AddWhere(char enclosureL, string fieldName, string operate, object? value, DbType dbType)|Update|
|AddWhere(char enclosureL, string fieldName, string operate, object? value, bool isExpression)|Update|
|AddWhere(CType connector, string fieldName, string operate, object? value = null)|Update|
|AddWhere(CType connector, string fieldName, string operate, object? value, char enclosureR)|Update|
|AddWhere(CType connector, string fieldName, string operate, object? value, DbType dbType, char? enclosureR = null)|Update|
|AddWhere(CType connector, string fieldName, string operate, object? value, bool isExpression, char? enclosureR = null)|Update|
|AddWhere(CType connector, char enclosureL, string fieldName, string operate, object? value = null)|Update|
|AddWhere(CType connector, char enclosureL, string fieldName, string operate, object? value, DbType dbType, char? enclosureR = null)|Update|
|AddWhere(CType connector, char enclosureL, string fieldName, string operate, object? value, bool isExpression, char? enclosureR = null)|Update|
|AddWhere(CType connector, char enclosureL, string fieldName, string operate, object? value, DbType? dbType, bool isExpression, char? enclosureR)|Update|
|AddWhere(string fieldName, OpType operate, object? value = null)|Update|
|AddWhere(string fieldName, OpType operate, object? value, DbType dbType)|Update|
|AddWhere(string fieldName, OpType operate, object? value, bool isExpression)|Update|
|AddWhere(char enclosureL, string fieldName, OpType operate, object? value = null)|Update|
|AddWhere(char enclosureL, string fieldName, OpType operate, object? value, DbType dbType)|Update|
|AddWhere(char enclosureL, string fieldName, OpType operate, object? value, bool isExpression)|Update|
|AddWhere(CType connector, string fieldName, OpType operate, object? value = null)|Update|
|AddWhere(CType connector, string fieldName, OpType operate, object? value, char enclosureR)|Update|
|AddWhere(CType connector, string fieldName, OpType operate, object? value, DbType dbType, char? enclosureR = null)|Update|
|AddWhere(CType connector, string fieldName, OpType operate, object? value, bool isExpression, char? enclosureR = null)|Update|
|AddWhere(CType connector, char enclosureL, string fieldName, OpType operate, object? value = null)|Update|
|AddWhere(CType connector, char enclosureL, string fieldName, OpType operate, object? value, DbType dbType, char? enclosureR = null)|Update|
|AddWhere(CType connector, char enclosureL, string fieldName, OpType operate, object? value, bool isExpression, char? enclosureR = null)|Update|
|AddWhere(CType connector, char enclosureL, string fieldName, OpType operate, object? value, DbType? dbType, bool isExpression, char? enclosureR)|Update|
|ClearWhere()|Update|
