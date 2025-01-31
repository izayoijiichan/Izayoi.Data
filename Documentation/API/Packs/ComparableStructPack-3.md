# ComparableStructPack&lt;TValue1, TValue2, TValue3&gt;

[Top](../../../README.md) / [Documentation](../../Documentation.md)

## Definition

|||
|--|--|
|Namespace|Izayoi.Data.Packs|
|Assembly|Izayoi.Data.Packs.dll|

Represents a comparable structure pack.

~~~csharp
public readonly struct ComparableStructPack<TValue1, TValue2, TValue3> :
    IComparableStructPack<TValue1, TValue2, TValue3>,
    IComparable<ComparableStructPack<TValue1, TValue2, TValue3>>,
    IEquatable<ComparableStructPack<TValue1, TValue2, TValue3>>
    where TValue1 : struct, IComparable<TValue1>, IEquatable<TValue1>
    where TValue2 : struct, IComparable<TValue2>, IEquatable<TValue2>
    where TValue3 : struct, IComparable<TValue3>, IEquatable<TValue3>
~~~

## Type Parameters
`TValue1`

`TValue2`

`TValue3`

[IComparable\<TVable>](https://learn.microsoft.com/en-us/dotnet/api/system.icomparable-1)  
[IEquatable\<TVable>](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable-1)

### Inheritance
Object -> [ValueType](https://learn.microsoft.com/en-us/dotnet/api/system.valuetype) -> ComparableStructPack&lt;TValue1, TValue2, TValue3&gt;

## Constructors

|Name|Summary|
|--|--|
|ComparableStructPack&lt;TValue1, TValue2, TValue3&gt;(in TValue1 value1, in TValue2 value2, in TValue3 value3)|Initializes an instance of the ComparableStructPack&lt;TValue1, TValue2, TValue3&gt; structure to the specified value.|

## Properties

|Name|Type|Summary|
|--|--|--|
|Value1|TValue1|Gets the value1 of the current object.|
|Value2|TValue2|Gets the value2 of the current object.|
|Value3|TValue3|Gets the value3 of the current object.|

## Methods

|Name|Returns|Summary|
|--|--|--|
|CompareTo(ComparableStructPack&lt;TValue1, TValue2, TValue3&gt; other)|int|Compares this instance to a specified ComparableStructPack&lt;TValue1, TValue2, TValue3&gt; and returns an indication of their relative values.|
|CompareTo(IComparableStructPack&lt;TValue1, TValue2, TValue3&gt; other)|int|Compares this instance to a specified IComparableStructPack&lt;TValue1, TValue2, TValue3&gt; and returns an indication of their relative values.|
|CompareTo(object? other)|int|Compares this instance to a specified object and returns an indication of their relative values.|
|Deconstruct(out TValue1 value1, out TValue2 value2)|void|Deconstructs this ComparableStructPack&lt;TValue1, TValue2, TValue3&gt; instance by value1 and value2.|
|Deconstruct(out TValue1 value1, out TValue2 value2, out TValue3 value3)|void|Deconstructs this ComparableStructPack&lt;TValue1, TValue2, TValue3&gt; instance by value1, value2 and value3.|
|Equals(ComparableStructPack&lt;TValue1, TValue2, TValue3&gt; other)|bool|Indicates whether the current ComparableStructPack&lt;TValue1, TValue2, TValue3&gt; object is equal to a specified ComparableStructPack&lt;TValue1, TValue2, TValue3&gt;.|
|Equals(IComparableStructPack&lt;TValue1, TValue2, TValue3&gt; other)|bool|Indicates whether the current IComparableStructPack&lt;TValue1, TValue2, TValue3&gt; object is equal to a specified ComparableStructPack&lt;TValue1, TValue2, TValue3&gt;.|
|Equals(object? other)|bool|Indicates whether the current ComparableStructPack&lt;TValue1, TValue2, TValue3&gt; object is equal to a specified object.|
|Equals(object? other, IEqualityComparer comparer)|bool|Indicates whether the current ComparableStructPack&lt;TValue1, TValue2, TValue3&gt; object is equal to a specified object.|
|GetHashCode()|string|Returns the hash code for this instance.|
|GetHashCode(IEqualityComparer comparer)|string|Returns the hash code for this instance.|
|ToString()|string?|Returns the text representation of the value of the current ComparableStructPack&lt;TValue1, TValue2, TValue3&gt; object.|

## Operators

|Operator|Returns|Left|Right|
|--|--|--|--|
|==|bool|ComparableStructPack&lt;TValue1, TValue2, TValue3&gt;|ComparableStructPack&lt;TValue1, TValue2, TValue3&gt;|
|!=|bool|ComparableStructPack&lt;TValue1, TValue2, TValue3&gt;|ComparableStructPack&lt;TValue1, TValue2, TValue3&gt;|
|<|bool|ComparableStructPack&lt;TValue1, TValue2, TValue3&gt;|ComparableStructPack&lt;TValue1, TValue2, TValue3&gt;|
|<=|bool|ComparableStructPack&lt;TValue1, TValue2, TValue3&gt;|ComparableStructPack&lt;TValue1, TValue2, TValue3&gt;|
|>|bool|ComparableStructPack&lt;TValue1, TValue2, TValue3&gt;|ComparableStructPack&lt;TValue1, TValue2, TValue3&gt;|
|>=|bool|ComparableStructPack&lt;TValue1, TValue2, TValue3&gt;|ComparableStructPack&lt;TValue1, TValue2, TValue3&gt;|

## Examples

~~~csharp
using Izayoi.Data.Comparable;
using Izayoi.Data.Packs;
using System;

public class Example()
{
    public void Method1()
    {
        ComparableStructPack<int, int, int> pack1 = new(1, 2, 3);

        ComparableStructPack<bool, byte, short> pack2 = new(true, 2, 3);
    }

    public void Method2()
    {
        // NG
        //ComparableStructPack<int, int, int?> pack = new(1, 2, null);

        // NG
        //ComparableStructPack<int, int, System.Nullable<int>> pack = new(1, 2, null);

        // OK
        ComparableStructPack<int, int, ComparableNullable<int>> pack = new(1, 2, null);
    }

    public void Method3()
    {
        ComparableStructPack<int, int, ComparableNullable<int>> pack1 = new(1, 2, null);

        ComparableStructPack<int, int, ComparableNullable<int>> pack2 = new(1, 2, 0);

        ComparableStructPack<int, int, ComparableNullable<int>> pack3 = new(1, 2, 1);

        // pack1.Value3.HasValue: false

        // pack2.Value3.HasValue: true
        // pack2.Value3.Value: 0

        // pack3.Value3.HasValue: true
        // pack3.Value3.Value: 1

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
