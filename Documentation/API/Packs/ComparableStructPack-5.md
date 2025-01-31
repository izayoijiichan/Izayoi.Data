# ComparableStructPack&lt;TValue1, TValue2, TValue3, TValue4, TValue5&gt;

[Top](../../../README.md) / [Documentation](../../Documentation.md)

## Definition

|||
|--|--|
|Namespace|Izayoi.Data.Packs|
|Assembly|Izayoi.Data.Packs.dll|

Represents a comparable structure pack.

~~~csharp
public readonly struct ComparableStructPack<TValue1, TValue2, TValue3, TValue4, TValue5> :
    IComparableStructPack<TValue1, TValue2, TValue3, TValue4, TValue5>,
    IComparable<ComparableStructPack<TValue1, TValue2, TValue3, TValue4, TValue5>>,
    IEquatable<ComparableStructPack<TValue1, TValue2, TValue3, TValue4, TValue5>>
    where TValue1 : struct, IComparable<TValue1>, IEquatable<TValue1>
    where TValue2 : struct, IComparable<TValue2>, IEquatable<TValue2>
    where TValue3 : struct, IComparable<TValue3>, IEquatable<TValue3>
    where TValue4 : struct, IComparable<TValue4>, IEquatable<TValue4>
    where TValue5 : struct, IComparable<TValue5>, IEquatable<TValue5>
~~~

## Type Parameters
`TValue1`

`TValue2`

`TValue3`

`TValue4`

`TValue5`

[IComparable\<TVable>](https://learn.microsoft.com/en-us/dotnet/api/system.icomparable-1)  
[IEquatable\<TVable>](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable-1)

### Inheritance
Object -> [ValueType](https://learn.microsoft.com/en-us/dotnet/api/system.valuetype) -> ComparableStructPack&lt;TValue1, TValue2, TValue3, TValue4, TValue5&gt;

## Constructors

|Name|Summary|
|--|--|
|ComparableStructPack&lt;TValue1, TValue2, TValue3, TValue4, TValue5&gt;(in TValue1 value1, in TValue2 value2, in TValue3 value3, in TValue4 value4, in TValue5 value5)|Initializes an instance of the ComparableStructPack&lt;TValue1, TValue2, TValue3, TValue4, TValue5&gt; structure to the specified value.|

## Properties

|Name|Type|Summary|
|--|--|--|
|Value1|TValue1|Gets the value1 of the current object.|
|Value2|TValue2|Gets the value2 of the current object.|
|Value3|TValue3|Gets the value3 of the current object.|
|Value4|TValue4|Gets the value4 of the current object.|
|Value5|TValue5|Gets the value5 of the current object.|

## Methods

|Name|Returns|Summary|
|--|--|--|
|CompareTo(ComparableStructPack&lt;TValue1, TValue2, TValue3, TValue4, TValue5&gt; other)|int|Compares this instance to a specified ComparableStructPack&lt;TValue1, TValue2, TValue3, TValue4, TValue5&gt; and returns an indication of their relative values.|
|CompareTo(IComparableStructPack&lt;TValue1, TValue2, TValue3, TValue4, TValue5&gt; other)|int|Compares this instance to a specified IComparableStructPack&lt;TValue1, TValue2, TValue3, TValue4, TValue5&gt; and returns an indication of their relative values.|
|CompareTo(object? other)|int|Compares this instance to a specified object and returns an indication of their relative values.|
|Deconstruct(out TValue1 value1, out TValue2 value2)|void|Deconstructs this ComparableStructPack&lt;TValue1, TValue2, TValue3, TValue4, TValue5&gt; instance by value1 and value2.|
|Deconstruct(out TValue1 value1, out TValue2 value2, out TValue3 value3)|void|Deconstructs this ComparableStructPack&lt;TValue1, TValue2, TValue3, TValue4, TValue5&gt; instance by value1, value2 and value3.|
|Deconstruct(out TValue1 value1, out TValue2 value2, out TValue3 value3, out TValue4 value4)|void|Deconstructs this ComparableStructPack&lt;TValue1, TValue2, TValue3, TValue4, TValue5&gt; instance by value1, value2, value3 and value4.|
|Deconstruct(out TValue1 value1, out TValue2 value2, out TValue3 value3, out TValue4 value4, out TValue5 value5)|void|Deconstructs this ComparableStructPack&lt;TValue1, TValue2, TValue3, TValue4, TValue5&gt; instance by value1, value2, value3, value4 and value5.|
|Equals(ComparableStructPack&lt;TValue1, TValue2, TValue3, TValue4, TValue5&gt; other)|bool|Indicates whether the current ComparableStructPack&lt;TValue1, TValue2, TValue3, TValue4, TValue5&gt; object is equal to a specified ComparableStructPack&lt;TValue1, TValue2, TValue3, TValue4, TValue5&gt;.|
|Equals(IComparableStructPack&lt;TValue1, TValue2, TValue3, TValue4, TValue5&gt; other)|bool|Indicates whether the current IComparableStructPack&lt;TValue1, TValue2, TValue3, TValue4, TValue5&gt; object is equal to a specified ComparableStructPack&lt;TValue1, TValue2, TValue3, TValue4, TValue5&gt;.|
|Equals(object? other)|bool|Indicates whether the current ComparableStructPack&lt;TValue1, TValue2, TValue3, TValue4, TValue5&gt; object is equal to a specified object.|
|Equals(object? other, IEqualityComparer comparer)|bool|Indicates whether the current ComparableStructPack&lt;TValue1, TValue2, TValue3, TValue4, TValue5&gt; object is equal to a specified object.|
|GetHashCode()|string|Returns the hash code for this instance.|
|GetHashCode(IEqualityComparer comparer)|string|Returns the hash code for this instance.|
|ToString()|string?|Returns the text representation of the value of the current ComparableStructPack&lt;TValue1, TValue2, TValue3, TValue4, TValue5&gt; object.|

## Operators

|Operator|Returns|Left|Right|
|--|--|--|--|
|==|bool|ComparableStructPack&lt;TValue1, TValue2, TValue3, TValue4, TValue5&gt;|ComparableStructPack&lt;TValue1, TValue2, TValue3, TValue4, TValue5&gt;|
|!=|bool|ComparableStructPack&lt;TValue1, TValue2, TValue3, TValue4, TValue5&gt;|ComparableStructPack&lt;TValue1, TValue2, TValue3, TValue4, TValue5&gt;|
|<|bool|ComparableStructPack&lt;TValue1, TValue2, TValue3, TValue4, TValue5&gt;|ComparableStructPack&lt;TValue1, TValue2, TValue3, TValue4, TValue5&gt;|
|<=|bool|ComparableStructPack&lt;TValue1, TValue2, TValue3, TValue4, TValue5&gt;|ComparableStructPack&lt;TValue1, TValue2, TValue3, TValue4, TValue5&gt;|
|>|bool|ComparableStructPack&lt;TValue1, TValue2, TValue3, TValue4, TValue5&gt;|ComparableStructPack&lt;TValue1, TValue2, TValue3, TValue4, TValue5&gt;|
|>=|bool|ComparableStructPack&lt;TValue1, TValue2, TValue3, TValue4, TValue5&gt;|ComparableStructPack&lt;TValue1, TValue2, TValue3, TValue4, TValue5&gt;|

## Examples

~~~csharp
using Izayoi.Data.Comparable;
using Izayoi.Data.Packs;
using System;

public class Example()
{
    public void Method1()
    {
        ComparableStructPack<int, int, int, int, int> pack1 = new(1, 2, 3, 4, 5);

        ComparableStructPack<bool, byte, short, int, long> pack2 = new(true, 2, 3, 4, 5);
    }

    public void Method2()
    {
        // NG
        //ComparableStructPack<int, int, int, int, int?> pack = new(1, 2, 3, 4, null);

        // NG
        //ComparableStructPack<int, int, int, int, System.Nullable<int>> pack = new(1, 2, 3, 4, null);

        // OK
        ComparableStructPack<int, int, int, int, ComparableNullable<int>> pack = new(1, 2, 3, 4, null);
    }

    public void Method3()
    {
        ComparableStructPack<int, int, int, int, ComparableNullable<int>> pack1 = new(1, 2, 3, 4, null);

        ComparableStructPack<int, int, int, int, ComparableNullable<int>> pack2 = new(1, 2, 3, 4, 0);

        ComparableStructPack<int, int, int, int, ComparableNullable<int>> pack3 = new(1, 2, 3, 4, 1);

        // pack1.Value5.HasValue: false

        // pack2.Value5.HasValue: true
        // pack2.Value5.Value: 0

        // pack3.Value5.HasValue: true
        // pack3.Value5.Value: 1

        if (pack1 < pack2)
        {
            // true
        }

        if (pack2 < pack3)
        {
            // true
        }
    }
}
~~~

## Applies to

|Product|Versions|
|--|--|
|.NET|8, 9|
|.NET Standard|2.0, 2.1|
