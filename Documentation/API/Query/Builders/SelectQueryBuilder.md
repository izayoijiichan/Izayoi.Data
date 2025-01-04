# SelectQueryBuilder

[Top](../../../../README.md) / [Documentation](../../../Documentation.md)

## Definition

|||
|--|--|
|Namespace|Izayoi.Data.Query|
|Assembly|Izayoi.Data.Query.dll|

Represents a Select query builder.

~~~csharp
public class SelectQueryBuilder : SelectQueryBuilderBase, ISelectQueryBuilder
~~~

### Inheritance
Object -> QueryBuilderBase -> SelectQueryBuilderBase -> SelectQueryBuilder

### Implements

ISelectQueryBuilder

## Constructors

|Name|Summary|
|--|--|
|SelectQueryBuilder()|Initializes an instance of the SelectQueryBuilder class.|
|SelectQueryBuilder(QueryOption queryOption)|Initializes a new instance of the SelectQueryBuilder class the specified queryOption.|
|SelectQueryBuilder(QueryOption queryOption, StringBuilder stringBuilder, BindParameterCollection bindParameters)|Initializes an instance of the SelectQueryBuilder class with the specified queryOption, stringBuilder and bindParameters.|

## Properties

#### `QueryOption` [QueryOption](../QueryOption.md)

Gets the query option.

#### `Parameters` [BindParameterCollection](../Parameters/BindParameterCollection.md)

Gets the bind parameters.

## Methods

|Name|Returns|Summary|
|--|--|--|
|Build(in Select Select)|bool|Builds the specified [Select](../Dml/Select.md).|
|Clean()|bool|Clear the query and parameters.|
|GetQuery()|string|Get the query.|
|GetParameters()|BindParameterCollection|Get the parameters.|

## Applies to

|Product|Versions|
|--|--|
|.NET|8, 9|
