# DbDataMapperOption

[Top](../../../README.md) / [Documentation](../../Documentation.md)

## Definition

|||
|---|---|
|Namespace|Izayoi.Data|
|Assembly|Izayoi.Data.dll|

Represents a DB data mapper option.

~~~csharp
public class DbDataMapperOption
~~~

### Inheritance
Object -> DbDataMapperOption

## Constructors

|Name|Summary|
|---|---|
|DbDataMapperOption()|Initializes an instance of the DbDataMapperOption class.|

## Properties

#### `IgnoreException` bool

Gets or sets whether ignore exception.

If `true`, exceptions raised by `SetPropertyValueAsync` method are ignored.

The dafault is `false`;

#### `InheritColumnAttribute` bool

Gets or sets whether inherit `[Column]` attribute.

The dafault is `true`;

#### `InheritKeyAttribute` bool

Gets or sets whether inherit `[Key]` attribute.

The dafault is `true`;

#### `InheritNotMappedAttribute` bool

Gets or sets whether inherit `[NotMapped]` attribute.

The dafault is `true`;

## Applies to

|Product|Versions|
|---|---|
|.NET|8, 9, 10|
|.NET Standard|2.1|
