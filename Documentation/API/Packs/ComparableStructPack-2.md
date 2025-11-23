# ComparableStructPack&lt;TValue1, TValue2&gt;

[Top](../../../README.md) / [Documentation](../../Documentation.md)

## Definition

|||
|---|---|
|Namespace|Izayoi.Data.Packs|
|Assembly|Izayoi.Data.Packs.dll|

Represents a comparable structure pack.

~~~csharp
public readonly struct ComparableStructPack<TValue1, TValue2> :
    IComparableStructPack<TValue1, TValue2>,
    IComparable<ComparableStructPack<TValue1, TValue2>>,
    IEquatable<ComparableStructPack<TValue1, TValue2>>
    where TValue1 : struct, IComparable<TValue1>, IEquatable<TValue1>
    where TValue2 : struct, IComparable<TValue2>, IEquatable<TValue2>
~~~

## Type Parameters
`TValue1`

`TValue2`

[IComparable\<TVable>](https://learn.microsoft.com/en-us/dotnet/api/system.icomparable-1)  
[IEquatable\<TVable>](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable-1)

### Inheritance
Object -> [ValueType](https://learn.microsoft.com/en-us/dotnet/api/system.valuetype) -> ComparableStructPack&lt;TValue1, TValue2&gt;

## Constructors

|Name|Summary|
|---|---|
|ComparableStructPack&lt;TValue1, TValue2&gt;(in TValue1 value1, in TValue2 value2)|Initializes an instance of the ComparableStructPack&lt;TValue1, TValue2&gt; structure to the specified value.|

## Properties

|Name|Type|Summary|
|---|---|---|
|Value1|TValue1|Gets the value1 of the current object.|
|Value2|TValue2|Gets the value2 of the current object.|

## Methods

|Name|Returns|Summary|
|---|---|---|
|CompareTo(ComparableStructPack&lt;TValue1, TValue2&gt; other)|int|Compares this instance to a specified ComparableStructPack&lt;TValue1, TValue2&gt; and returns an indication of their relative values.|
|CompareTo(IComparableStructPack&lt;TValue1, TValue2&gt; other)|int|Compares this instance to a specified IComparableStructPack&lt;TValue1, TValue2&gt; and returns an indication of their relative values.|
|CompareTo(object? other)|int|Compares this instance to a specified object and returns an indication of their relative values.|
|Deconstruct(out TValue1 value1, out TValue2 value2)|void|Deconstructs this ComparableStructPack&lt;TValue1, TValue2&gt; instance by value1 and value2.|
|Equals(ComparableStructPack&lt;TValue1, TValue2&gt; other)|bool|Indicates whether the current ComparableStructPack&lt;TValue1, TValue2&gt; object is equal to a specified ComparableStructPack&lt;TValue1, TValue2&gt;.|
|Equals(IComparableStructPack&lt;TValue1, TValue2&gt; other)|bool|Indicates whether the current IComparableStructPack&lt;TValue1, TValue2&gt; object is equal to a specified ComparableStructPack&lt;TValue1, TValue2&gt;.|
|Equals(object? other)|bool|Indicates whether the current ComparableStructPack&lt;TValue1, TValue2&gt; object is equal to a specified object.|
|Equals(object? other, IEqualityComparer comparer)|bool|Indicates whether the current ComparableStructPack&lt;TValue1, TValue2&gt; object is equal to a specified object.|
|GetHashCode()|string|Returns the hash code for this instance.|
|GetHashCode(IEqualityComparer comparer)|string|Returns the hash code for this instance.|
|ToString()|string?|Returns the text representation of the value of the current ComparableStructPack&lt;TValue1, TValue2&gt; object.|

## Operators

|Operator|Returns|Left|Right|
|---|---|---|---|
|==|bool|ComparableStructPack&lt;TValue1, TValue2&gt;|ComparableStructPack&lt;TValue1, TValue2&gt;|
|!=|bool|ComparableStructPack&lt;TValue1, TValue2&gt;|ComparableStructPack&lt;TValue1, TValue2&gt;|
|<|bool|ComparableStructPack&lt;TValue1, TValue2&gt;|ComparableStructPack&lt;TValue1, TValue2&gt;|
|<=|bool|ComparableStructPack&lt;TValue1, TValue2&gt;|ComparableStructPack&lt;TValue1, TValue2&gt;|
|>|bool|ComparableStructPack&lt;TValue1, TValue2&gt;|ComparableStructPack&lt;TValue1, TValue2&gt;|
|>=|bool|ComparableStructPack&lt;TValue1, TValue2&gt;|ComparableStructPack&lt;TValue1, TValue2&gt;|

## Examples

~~~csharp
using Izayoi.Data.Comparable;
using Izayoi.Data.Packs;
using System;

public class Example()
{
    public void Method1()
    {
        ComparableStructPack<int, int> pack1 = new(1, 2);

        ComparableStructPack<bool, byte> pack2 = new(true, 2);
    }

    public void Method2()
    {
        // NG
        //ComparableStructPack<int, int?> pack = new(1, null);

        // NG
        //ComparableStructPack<int, System.Nullable<int>> pack = new(1, null);

        // OK
        ComparableStructPack<int, ComparableNullable<int>> pack = new(1, null);
    }

    public void Method3()
    {
        ComparableStructPack<int, ComparableNullable<int>> pack1 = new(1, null);

        ComparableStructPack<int, ComparableNullable<int>> pack2 = new(1, 0);

        ComparableStructPack<int, ComparableNullable<int>> pack3 = new(1, 1);

        // pack1.Value2.HasValue: false

        // pack2.Value2.HasValue: true
        // pack2.Value2.Value: 0

        // pack3.Value2.HasValue: true
        // pack3.Value2.Value: 1

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
|---|---|
|.NET|8, 9, 10|
|.NET Standard|2.0, 2.1|
