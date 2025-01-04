# UpdateQueryBuilder

[Top](../../../../README.md) / [Documentation](../../../Documentation.md)

## Definition

|||
|--|--|
|Namespace|Izayoi.Data.Query|
|Assembly|Izayoi.Data.Query.dll|

Represents a Update query builder.

~~~csharp
public class UpdateQueryBuilder : SelectQueryBuilderBase, IUpdateQueryBuilder
~~~

### Inheritance
Object -> QueryBuilderBase -> SelectQueryBuilderBase -> UpdateQueryBuilder

### Implements

IUpdateQueryBuilder

## Constructors

|Name|Summary|
|--|--|
|UpdateQueryBuilder()|Initializes an instance of the UpdateQueryBuilder class.|
|UpdateQueryBuilder(QueryOption queryOption)|Initializes a new instance of the UpdateQueryBuilder class the specified queryOption.|
|UpdateQueryBuilder(QueryOption queryOption, StringBuilder stringBuilder, BindParameterCollection bindParameters)|Initializes an instance of the UpdateQueryBuilder class with the specified queryOption, stringBuilder and bindParameters.|

## Properties

#### `QueryOption` [QueryOption](../QueryOption.md)

Gets the query option.

#### `Parameters` [BindParameterCollection](../Parameters/BindParameterCollection.md)

Gets the bind parameters.

## Methods

|Name|Returns|Summary|
|--|--|--|
|Build(in Update Update)|bool|Builds the specified [Update](../Dml/Update.md).|
|Clean()|bool|Clear the query and parameters.|
|GetQuery()|string|Get the query.|
|GetParameters()|BindParameterCollection|Get the parameters.|

## Applies to

|Product|Versions|
|--|--|
|.NET|8, 9|
