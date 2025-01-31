# ComparableNullable&lt;TValue&gt;

[Top](../../../README.md) / [Documentation](../../Documentation.md)

## Definition

|||
|--|--|
|Namespace|Izayoi.Data.Comparable|
|Assembly|Izayoi.Data.Comparable.dll|

Represents a comparable value type that can be assigned null.

~~~csharp
public readonly struct ComparableNullable<TValue> :
    IComparableNullable<TValue>
    where TValue : struct, IComparable<TValue>, IEquatable<TValue>
~~~

## Type Parameters
`TValue`  
The underlying value type of the ComparableNullable&lt;TValue&gt; generic type.

[IComparable\<TVable>](https://learn.microsoft.com/en-us/dotnet/api/system.icomparable-1)  
[IEquatable\<TVable>](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable-1)

### Inheritance
Object -> [ValueType](https://learn.microsoft.com/en-us/dotnet/api/system.valuetype) -> ComparableNullable&lt;TValue&gt;

## Constructors

|Name|Summary|
|--|--|
|ComparableNullable&lt;TValue&gt;(in TValue value)|Initializes an instance of the ComparableNullable&lt;TValue&gt; structure to the specified value.|

## Properties

|Name|Type|Summary|
|--|--|--|
|HasValue|bool|Gets a value indicating whether the current ComparableNullable&lt;TValue&gt; object has a valid value of its underlying type.|
|Value|TValue|Gets the value of the current ComparableNullable&lt;TValue&gt; object if it has been assigned a valid underlying value.|

## Methods

|Name|Returns|Summary|
|--|--|--|
|CompareTo(ComparableNullable&lt;TValue&gt; other)|int|Compares this instance to a specified ComparableNullable&lt;TValue&gt; and returns an indication of their relative values.|
|CompareTo(object? other)|int|Compares this instance to a specified object and returns an indication of their relative values.|
|Deconstruct(out bool hasValue, out TValue value)|void|Deconstructs this ComparableNullable&lt;TValue&gt; instance by hasValue and value.|
|Equals(ComparableNullable&lt;TValue&gt; other)|bool|Indicates whether the current ComparableNullable&lt;TValue&gt; object is equal to a specified ComparableNullable&lt;TValue&gt;.|
|Equals(object? other)|bool|Indicates whether the current ComparableNullable&lt;TValue&gt; object is equal to a specified object.|
|GetHashCode()|string|Returns the hash code for this instance.|
|GetValueOrDefault()|TValue|Retrieves the value of the current ComparableNullable&lt;TValue&gt; object, or the default value of the underlying type.|
|GetValueOrDefault(TValue defaultValue)|TValue|Retrieves the value of the current ComparableNullable&lt;TValue&gt; object, or the specified default value.|
|ToString()|string?|Returns the text representation of the value of the current ComparableNullable&lt;TValue&gt; object.|

## Operators

|Operator|Returns|Left|Right|
|--|--|--|--|
|==|bool|ComparableNullable&lt;TValue&gt;|ComparableNullable&lt;TValue&gt;|
|!=|bool|ComparableNullable&lt;TValue&gt;|ComparableNullable&lt;TValue&gt;|
|<|bool|ComparableNullable&lt;TValue&gt;|ComparableNullable&lt;TValue&gt;|
|<=|bool|ComparableNullable&lt;TValue&gt;|ComparableNullable&lt;TValue&gt;|
|>|bool|ComparableNullable&lt;TValue&gt;|ComparableNullable&lt;TValue&gt;|
|>=|bool|ComparableNullable&lt;TValue&gt;|ComparableNullable&lt;TValue&gt;|

|Type|From|To|
|--|--|--|
|implicit|ComparableNullable&lt;TValue&gt;|System.Nullable&lt;TValue&gt;|
|implicit|System.Nullable&lt;TValue&gt;|System.Nullable&lt;TValue&gt;|
|implicit|TValue|ComparableNullable&lt;TValue&gt;|
|explicit|ComparableNullable&lt;TValue&gt;|TValue|

## Examples

~~~csharp
using Izayoi.Data.Comparable;
using System;

public class Example()
{
    public void Method1()
    {
        ComparableNullable<bool> nullableBool = new();
        ComparableNullable<byte> nullableByte = new();
        ComparableNullable<int> nullableInt = new();

        // nullableBool.HasValue: false
        // nullableByte.HasValue: false
        // nullableInt.HasValue: false
    }

    public void Method2()
    {
        ComparableNullable<bool> nullableBool = new(false);
        ComparableNullable<byte> nullableByte = new(255);
        ComparableNullable<int> nullableInt = new(1);

        // nullableBool.HasValue: true
        // nullableBool.Value: false

        // nullableByte.HasValue: true
        // nullableByte.Value: 255

        // nullableInt.HasValue: true
        // nullableInt.Value: 1
    }

    public void Method3()
    {
        ComparableNullable<bool> nullableBool = false;
        ComparableNullable<byte> nullableByte = 255;
        ComparableNullable<int> nullableInt = 1;

        // nullableBool.HasValue: true
        // nullableBool.Value: false

        // nullableByte.HasValue: true
        // nullableByte.Value: 255

        // nullableInt.HasValue: true
        // nullableInt.Value: 1
    }

    public void Method4()
    {
        ComparableNullable<bool> nullableBool = null;
        ComparableNullable<byte> nullableByte = null;
        ComparableNullable<int> nullableInt = null;

        // nullableBool.HasValue: false
        // nullableByte.HasValue: false
        // nullableInt.HasValue: false
    }

    public void Method5()
    {
        ComparableNullable<int> nullableInt1 = 1;
        ComparableNullable<int> nullableInt2 = 2;

        if (nullable1 < nullable2)
        {
            // true
        }
    }

    public void Method6()
    {
        ComparableNullable<int> nullableIntN = null;
        ComparableNullable<int> nullableInt0 = 0;
        ComparableNullable<int> nullableIntMinus = -1;

        if (nullableN < nullable0)
        {
            // true
        }

        if (nullableN < nullableMinus)
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
