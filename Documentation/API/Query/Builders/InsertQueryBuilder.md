# InsertQueryBuilder

[Top](../../../../README.md) / [Documentation](../../../Documentation.md)

## Definition

|||
|--|--|
|Namespace|Izayoi.Data.Query|
|Assembly|Izayoi.Data.Query.dll|

Represents a Insert query builder.

~~~csharp
public class InsertQueryBuilder : SelectQueryBuilderBase, IInsertQueryBuilder
~~~

### Inheritance
Object -> QueryBuilderBase -> SelectQueryBuilderBase -> InsertQueryBuilder

### Implements

IInsertQueryBuilder

## Constructors

|Name|Summary|
|--|--|
|InsertQueryBuilder()|Initializes an instance of the InsertQueryBuilder class.|
|InsertQueryBuilder(QueryOption queryOption)|Initializes a new instance of the InsertQueryBuilder class the specified queryOption.|
|InsertQueryBuilder(QueryOption queryOption, StringBuilder stringBuilder, BindParameterCollection bindParameters)|Initializes an instance of the InsertQueryBuilder class with the specified queryOption, stringBuilder and bindParameters.|

## Properties

#### `QueryOption` [QueryOption](../QueryOption.md)

Gets the query option.

#### `Parameters` [BindParameterCollection](../Parameters/BindParameterCollection.md)


Gets the bind parameters.

## Methods

|Name|Returns|Summary|
|--|--|--|
|Build(in Insert Insert)|bool|Builds the specified [Insert](../Dml/Insert.md).|
|Clean()|bool|Clear the query and parameters.|
|GetQuery()|string|Get the query.|
|GetParameters()|BindParameterCollection|Get the parameters.|

## Applies to

|Product|Versions|
|--|--|
|.NET|8, 9|
