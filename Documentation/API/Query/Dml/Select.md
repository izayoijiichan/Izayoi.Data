# Select

[Top](../../../../README.md) / [Documentation](../../../Documentation.md)

## Definition

|||
|--|--|
|Namespace|Izayoi.Data.Query|
|Assembly|Izayoi.Data.Query.dll|

Represents a Select source.

~~~csharp
public class Select
~~~

### Inheritance
Object -> Select

## Constructors

|Name|Summary|
|--|--|
|Select()|Initializes an instance of the Select class.|

## Properties

#### `Type` SType

Gets or sets the select type.

ALL, DISTINCT

#### `Fields` Fields

select list (SELECT clause)

#### `From` From

FROM clause

#### `Joins` Joins

JOIN clause

It is under From.

#### `Wheres` Wheres

WHERE clause

#### `Groups` Groups

GROUP BY clause

#### `Havings` Havings

HAVING clause

#### `Orders` Orders

ORDER BY clause

#### `Offset` int

OFFSET clause

#### `Limit` int

LIMIT clause

#### `For` For

FOR clause

Use only in SQL Server.

#### `With` With

WITH clause

## Methods

|Name|Returns|
|--|--|
|Clear()|Select|
|SetType(SType type)|Select|
|SetFrom(string tableName)|Select|
|SetFrom(string tableName, string tableAlias)|Select|
|SetFrom(string schemaName, string tableName, string tableAlias)|Select|
|ClearFrom()|Select|
|AddJoin(Join item)|Select|
|AddJoin(JType type, string tableName, string condition)|Select|
|AddJoin(JType type, string tableName, string tableAlias, string condition)|Select|
|AddJoin(JType type, string schemaName, string tableName, string tableAlias, string condition)|Select|
|ClearJoin()|Select|
|AddField(Field field)|Select|
|AddField(string fieldName, bool? isExpression = null)|Select|
|Select AddField(string fieldName, string fieldAlias, bool? isExpression = null)|Select|
|ClearFields()|Select|
|AddWhere(SearchCondition searchCondition)|Select|
|AddWhere(string fieldName, string operate, object? value = null)|Select|
|AddWhere(string fieldName, string operate, object? value, DbType dbType)|Select|
|AddWhere(string fieldName, string operate, object? value, bool isExpression)|Select|
|AddWhere(char enclosureL, string fieldName, string operate, object? value = null)|Select|
|AddWhere(char enclosureL, string fieldName, string operate, object? value, DbType dbType)|Select|
|AddWhere(char enclosureL, string fieldName, string operate, object? value, bool isExpression)|Select|
|AddWhere(CType connector, string fieldName, string operate, object? value = null)|Select|
|AddWhere(CType connector, string fieldName, string operate, object? value, char enclosureR)|Select|
|AddWhere(CType connector, string fieldName, string operate, object? value, DbType dbType, char? enclosureR = null)|Select|
|AddWhere(CType connector, string fieldName, string operate, object? value, bool isExpression, char? enclosureR = null)|Select|
|AddWhere(CType connector, char enclosureL, string fieldName, string operate, object? value = null)|Select|
|AddWhere(CType connector, char enclosureL, string fieldName, string operate, object? value, DbType dbType, char? enclosureR = null)|Select|
|AddWhere(CType connector, char enclosureL, string fieldName, string operate, object? value, bool isExpression, char? enclosureR = null)|Select|
|AddWhere(CType connector, char enclosureL, string fieldName, string operate, object? value, DbType? dbType, bool isExpression, char? enclosureR)|Select|
|AddWhere(string fieldName, OpType operate, object? value = null)|Select|
|AddWhere(string fieldName, OpType operate, object? value, DbType dbType)|Select|
|AddWhere(string fieldName, OpType operate, object? value, bool isExpression)|Select|
|AddWhere(char enclosureL, string fieldName, OpType operate, object? value = null)|Select|
|AddWhere(char enclosureL, string fieldName, OpType operate, object? value, DbType dbType)|Select|
|AddWhere(char enclosureL, string fieldName, OpType operate, object? value, bool isExpression)|Select|
|AddWhere(CType connector, string fieldName, OpType operate, object? value = null)|Select|
|AddWhere(CType connector, string fieldName, OpType operate, object? value, char enclosureR)|Select|
|AddWhere(CType connector, string fieldName, OpType operate, object? value, DbType dbType, char? enclosureR = null)|Select|
|AddWhere(CType connector, string fieldName, OpType operate, object? value, bool isExpression, char? enclosureR = null)|Select|
|AddWhere(CType connector, char enclosureL, string fieldName, OpType operate, object? value = null)|Select|
|AddWhere(CType connector, char enclosureL, string fieldName, OpType operate, object? value, DbType dbType, char? enclosureR = null)|Select|
|AddWhere(CType connector, char enclosureL, string fieldName, OpType operate, object? value, bool isExpression, char? enclosureR = null)|Select|
|AddWhere(CType connector, char enclosureL, string fieldName, OpType operate, object? value, DbType? dbType, bool isExpression, char? enclosureR)|Select|
|ClearWhere()|Select|
|AddGroup(string fieldExpression)|Select|
|ClearGroup()|Select|
|AddHaving(SearchCondition searchCondition)|Select|
|AddHaving(string fieldName, string operate, object? value = null)|Select|
|AddHaving(string fieldName, string operate, object? value, DbType dbType)|Select|
|AddHaving(string fieldName, string operate, object? value, bool isExpression)|Select|
|AddHaving(char enclosureL, string fieldName, string operate, object? value = null)|Select|
|AddHaving(char enclosureL, string fieldName, string operate, object? value, DbType dbType)|Select|
|AddHaving(char enclosureL, string fieldName, string operate, object? value, bool isExpression)|Select|
|AddHaving(CType connector, string fieldName, string operate, object? value = null)|Select|
|AddHaving(CType connector, string fieldName, string operate, object? value, char enclosureR)|Select|
|AddHaving(CType connector, string fieldName, string operate, object? value, DbType dbType, char? enclosureR = null)|Select|
|AddHaving(CType connector, string fieldName, string operate, object? value, bool isExpression, char? enclosureR = null)|Select|
|AddHaving(CType connector, char enclosureL, string fieldName, string operate, object? value = null)|Select|
|AddHaving(CType connector, char enclosureL, string fieldName, string operate, object? value, DbType dbType, char? enclosureR = null)|Select|
|AddHaving(CType connector, char enclosureL, string fieldName, string operate, object? value, bool isExpression, char? enclosureR = null)|Select|
|AddHaving(CType connector, char enclosureL, string fieldName, string operate, object? value, DbType? dbType, bool isExpression, char? enclosureR)|Select|
|AddHaving(string fieldName, OpType operate, object? value = null)|Select|
|AddHaving(string fieldName, OpType operate, object? value, DbType dbType)|Select|
|AddHaving(string fieldName, OpType operate, object? value, bool isExpression)|Select|
|AddHaving(char enclosureL, string fieldName, OpType operate, object? value = null)|Select|
|AddHaving(char enclosureL, string fieldName, OpType operate, object? value, DbType dbType)|Select|
|AddHaving(char enclosureL, string fieldName, OpType operate, object? value, bool isExpression)|Select|
|AddHaving(CType connector, string fieldName, OpType operate, object? value = null)|Select|
|AddHaving(CType connector, string fieldName, OpType operate, object? value, char enclosureR)|Select|
|AddHaving(CType connector, string fieldName, OpType operate, object? value, DbType dbType, char? enclosureR = null)|Select|
|AddHaving(CType connector, string fieldName, OpType operate, object? value, bool isExpression, char? enclosureR = null)|Select|
|AddHaving(CType connector, char enclosureL, string fieldName, OpType operate, object? value = null)|Select|
|AddHaving(CType connector, char enclosureL, string fieldName, OpType operate, object? value, DbType dbType, char? enclosureR = null)|Select|
|AddHaving(CType connector, char enclosureL, string fieldName, OpType operate, object? value, bool isExpression, char? enclosureR = null)|Select|
|AddHaving(CType connector, char enclosureL, string fieldName, OpType operate, object? value, DbType? dbType, bool isExpression, char? enclosureR)|Select|
|ClearHaving()|Select|
|AddOrder(Order order)|Select|
|AddOrder(string orderExpression)|Select|
|AddOrder(string orderExpression, OType type)|Select|
|ClearOrder()|Select|
|SetLimit(int limit)|Select|
|SetOffset(int offset)|Select|
|SetFor(Json json)|Select|
|SetFor(JsonMode mode, string? rootName = null, bool includeNullValues = false, bool withoutArrayWrapper = false)|Select|
|ClearFor()|Select|
|SetWith(bool recursive)|Select|
|ClearWith()|Select|

## Applies to

|Product|Versions|
|--|--|
|.NET|8, 9|
