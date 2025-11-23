# DeleteQueryBuilder

[Top](../../../../README.md) / [Documentation](../../../Documentation.md)

## Definition

|||
|---|---|
|Namespace|Izayoi.Data.Query|
|Assembly|Izayoi.Data.Query.dll|

Represents a delete query builder.

~~~csharp
public class DeleteQueryBuilder : SelectQueryBuilderBase, IDeleteQueryBuilder
~~~

### Inheritance
Object -> QueryBuilderBase -> SelectQueryBuilderBase -> DeleteQueryBuilder

### Implements

IDeleteQueryBuilder

## Constructors

|Name|Summary|
|---|---|
|DeleteQueryBuilder()|Initializes an instance of the DeleteQueryBuilder class.|
|DeleteQueryBuilder(QueryOption queryOption)|Initializes a new instance of the DeleteQueryBuilder class the specified queryOption.|
|DeleteQueryBuilder(QueryOption queryOption, StringBuilder stringBuilder, BindParameterCollection bindParameters)|Initializes an instance of the DeleteQueryBuilder class with the specified queryOption, stringBuilder and bindParameters.|

## Properties

#### `QueryOption` [QueryOption](../QueryOption.md)

Gets the query option.

#### `Parameters` [BindParameterCollection](../Parameters/BindParameterCollection.md)

Gets the bind parameters.

## Methods

|Name|Returns|Summary|
|---|---|---|
|Build(in Delete delete)|bool|Builds the specified [delete](../Dml/Delete.md).|
|Clean()|bool|Clear the query and parameters.|
|GetQuery()|string|Get the query.|
|GetParameters()|BindParameterCollection|Get the parameters.|

## Applies to

|Product|Versions|
|---|---|
|.NET|8, 9, 10|
|.NET Standard|2.1|
