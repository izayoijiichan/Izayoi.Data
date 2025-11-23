# BindParameter

[Top](../../../../README.md) / [Documentation](../../../Documentation.md)

## Definition

|||
|---|---|
|Namespace|Izayoi.Data.Query|
|Assembly|Izayoi.Data.Query.dll|

Represents a bind parameter.

~~~csharp
public class BindParameter : DbParameter, IDbParameter
~~~

### Inheritance
Object -> MarshalByRefObject -> DbParameter -> BindParameter

### Implements

IDbParameter, IDbDataParameter, IDataParameter

## Constructors

|Name|Summary|
|---|---|
|BindParameter()|Initializes a new instance of the BindParameter class.|
|BindParameter(string parameterName, object value)|Initializes a new instance of the BindParameter class with the specified parameterName and value.|
|BindParameter(string parameterName, object value, DbType dbType)|Initializes a new instance of the BindParameter class with the specified parameterName, value and dbType.|
|BindParameter(DbParameter dbParameter)|Initializes a new instance of the BindParameter class with the specified dbParameter.|

## Properties

#### `DbType` DbType

Gets or sets the System.Data.DbType of the parameter.

#### `Direction` ParameterDirection

Gets or sets a value indicating whether the parameter is input-only, output-only, bidirectional, or a stored procedure return value parameter.

#### `IsNullable` bool

Gets or sets a value indicating whether the parameter accepts null values.

#### `ParameterName` string

Gets or sets the name of the System.Data.IDataParameter.

#### `Precision` byte

Gets or sets the precision of numeric parameters.

#### `Scale` byte

Gets or sets the scale of numeric parameters.

#### `Size` int

Gets or sets the size of the parameter.

#### `SourceColumn` string

Gets or sets the name of the source column that is mapped to the System.Data.DataSet and used for loading or returning the System.Data.IDataParameter.Value.

#### `SourceColumnNullMapping` bool

Gets or sets a value which indicates whether the source column is nullable.

#### `SourceVersion` DataRowVersion

Gets or sets the System.Data.DataRowVersion to use when loading System.Data.IDataParameter.Value.

#### `Value` object?

Gets or sets the value of the parameter.

## Methods

|Name|Returns|Summary|
|---|---|---|
|ResetDbType()|void|Resets the DbType property to its original settings.|

## Applies to

|Product|Versions|
|---|---|
|.NET|8, 9, 10|
|.NET Standard|2.1|
