# Delete

[Top](../../../../README.md) / [Documentation](../../../Documentation.md)

## Definition

|||
|--|--|
|Namespace|Izayoi.Data.Query|
|Assembly|Izayoi.Data.Query.dll|

Represents a delete source.

~~~csharp
public class Delete
~~~

### Inheritance
Object -> Delete

## Constructors

|Name|Summary|
|--|--|
|Delete()|Initializes an instance of the Delete class.|
|Delete(string tableName)|Initializes a new instance of the Delete class with the specified tableName.|
|Delete(string tableName, string tableAlias)|Initializes an instance of the Delete class with the specified tableName and tableAlias.|
|Delete(string schemaName, string tableName, string tableAlias)|Initializes an instance of the Delete class with the specified schemaName, tableName and tableAlias.|

## Properties

#### `From` From

FROM clause and JOIN clause

#### `Wheres` Wheres

WHERE clause

## Methods

|Name|Returns|
|--|--|
|SetFrom(string tableName)|Delete|
|SetFrom(string tableName, string tableAlias)|Delete|
|SetFrom(string schemaName, string tableName, string tableAlias)|Delete|
|AddWhere(SearchCondition searchCondition)|Delete|
|AddWhere(string fieldName, string operate, object? value = null)|Delete|
|AddWhere(string fieldName, string operate, object? value, DbType dbType)|Delete|
|AddWhere(string fieldName, string operate, object? value, bool isExpression)|Delete|
|AddWhere(char enclosureL, string fieldName, string operate, object? value = null)|Delete|
|AddWhere(char enclosureL, string fieldName, string operate, object? value, DbType dbType)|Delete|
|AddWhere(char enclosureL, string fieldName, string operate, object? value, bool isExpression)|Delete|
|AddWhere(CType connector, string fieldName, string operate, object? value = null)|Delete|
|AddWhere(CType connector, string fieldName, string operate, object? value, char enclosureR)|Delete|
|AddWhere(CType connector, string fieldName, string operate, object? value, DbType dbType, char? enclosureR = null)|Delete|
|AddWhere(CType connector, string fieldName, string operate, object? value, bool isExpression, char? enclosureR = null)|Delete|
|AddWhere(CType connector, char enclosureL, string fieldName, string operate, object? value = null)|Delete|
|AddWhere(CType connector, char enclosureL, string fieldName, string operate, object? value, DbType dbType, char? enclosureR = null)|Delete|
|AddWhere(CType connector, char enclosureL, string fieldName, string operate, object? value, bool isExpression, char? enclosureR = null)|Delete|
|AddWhere(CType connector, char enclosureL, string fieldName, string operate, object? value, DbType? dbType, bool isExpression, char? enclosureR)|Delete|
|AddWhere(string fieldName, OpType operate, object? value = null)|Delete|
|AddWhere(string fieldName, OpType operate, object? value, DbType dbType)|Delete|
|AddWhere(string fieldName, OpType operate, object? value, bool isExpression)|Delete|
|AddWhere(char enclosureL, string fieldName, OpType operate, object? value = null)|Delete|
|AddWhere(char enclosureL, string fieldName, OpType operate, object? value, DbType dbType)|Delete|
|AddWhere(char enclosureL, string fieldName, OpType operate, object? value, bool isExpression)|Delete|
|AddWhere(CType connector, string fieldName, OpType operate, object? value = null)|Delete|
|AddWhere(CType connector, string fieldName, OpType operate, object? value, char enclosureR)|Delete|
|AddWhere(CType connector, string fieldName, OpType operate, object? value, DbType dbType, char? enclosureR = null)|Delete|
|AddWhere(CType connector, string fieldName, OpType operate, object? value, bool isExpression, char? enclosureR = null)|Delete|
|AddWhere(CType connector, char enclosureL, string fieldName, OpType operate, object? value = null)|Delete|
|AddWhere(CType connector, char enclosureL, string fieldName, OpType operate, object? value, DbType dbType, char? enclosureR = null)|Delete|
|AddWhere(CType connector, char enclosureL, string fieldName, OpType operate, object? value, bool isExpression, char? enclosureR = null)|Delete|
|AddWhere(CType connector, char enclosureL, string fieldName, OpType operate, object? value, DbType? dbType, bool isExpression, char? enclosureR)|Delete|
|ClearWhere()|Delete|
