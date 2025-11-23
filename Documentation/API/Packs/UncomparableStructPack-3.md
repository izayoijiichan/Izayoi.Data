# UncomparableStructPack&lt;TValue1, TValue2, TValue3&gt;

[Top](../../../README.md) / [Documentation](../../Documentation.md)

## Definition

|||
|---|---|
|Namespace|Izayoi.Data.Packs|
|Assembly|Izayoi.Data.Packs.dll|

Represents a comparable structure pack.

~~~csharp
public readonly struct UncomparableStructPack<TValue1, TValue2, TValue3> :
    IStructPack<TValue1, TValue2, TValue3>
    where TValue1 : struct
    where TValue2 : struct
    where TValue3 : struct
~~~

## Type Parameters
`TValue1`

`TValue2`

`TValue3`

### Inheritance
Object -> [ValueType](https://learn.microsoft.com/en-us/dotnet/api/system.valuetype) -> UncomparableStructPack&lt;TValue1, TValue2, TValue3&gt;

## Constructors

|Name|Summary|
|---|---|
|UncomparableStructPack&lt;TValue1, TValue2, TValue3&gt;(in TValue1 value1, in TValue2 value2, in TValue3 value3)|Initializes an instance of the UncomparableStructPack&lt;TValue1, TValue2, TValue3&gt; structure to the specified value.|

## Properties

|Name|Type|Summary|
|---|---|---|
|Value1|TValue1|Gets the value1 of the current object.|
|Value2|TValue2|Gets the value2 of the current object.|
|Value3|TValue3|Gets the value3 of the current object.|

## Methods

|Name|Returns|Summary|
|---|---|---|
|Deconstruct(out TValue1 value1, out TValue2 value2)|void|Deconstructs this UncomparableStructPack&lt;TValue1, TValue2, TValue3&gt; instance by value1 and value2.|
|Deconstruct(out TValue1 value1, out TValue2 value2, out TValue3 value3)|void|Deconstructs this UncomparableStructPack&lt;TValue1, TValue2, TValue3&gt; instance by value1, value2 and value3.|
|Equals(UncomparableStructPack&lt;TValue1, TValue2, TValue3&gt; other)|bool|Indicates whether the current UncomparableStructPack&lt;TValue1, TValue2, TValue3&gt; object is equal to a specified UncomparableStructPack&lt;TValue1, TValue2, TValue3&gt;.|
|Equals(object? other)|bool|Indicates whether the current UncomparableStructPack&lt;TValue1, TValue2, TValue3&gt; object is equal to a specified object.|
|GetHashCode()|string|Returns the hash code for this instance.|
|ToString()|string?|Returns the text representation of the value of the current UncomparableStructPack&lt;TValue1, TValue2, TValue3&gt; object.|

## Operators

|Operator|Returns|Left|Right|
|---|---|---|---|
|==|bool|UncomparableStructPack&lt;TValue1, TValue2, TValue3&gt;|UncomparableStructPack&lt;TValue1, TValue2, TValue3&gt;|
|!=|bool|UncomparableStructPack&lt;TValue1, TValue2, TValue3&gt;|UncomparableStructPack&lt;TValue1, TValue2, TValue3&gt;|

## Examples

~~~csharp
using Izayoi.Data.Packs;
using System;

public class Example()
{
    public void Method1()
    {
        UncomparableStructPack<int, int, int> pack1 = new(1, 2, 3);

        UncomparableStructPack<bool, byte, short> pack2 = new(true, 2, 3);
    }

    public void Method2()
    {
        // NG
        //UncomparableStructPack<int, int, int?> pack = new(1, 2, null);

        // NG
        //UncomparableStructPack<int, int, System.Nullable<int>> pack = new(1, 2, null);
    }

    public void Method3()
    {
        UncomparableStructPack<int, int, int> pack1 = new(1, 2, 3);
        UncomparableStructPack<int, int, int> pack2 = new(1, 2, 3);

        // deprecated
        if (pack1 == pack2)
        {
            // true
        }
    }
}
~~~

## Applies to

|Product|Versions|
|---|---|
|.NET|8, 9, 10|
|.NET Standard|2.0, 2.1|
