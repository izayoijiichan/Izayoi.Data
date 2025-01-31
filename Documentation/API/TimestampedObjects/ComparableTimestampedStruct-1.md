# ComparableTimestampedStruct&lt;TValue&gt;

[Top](../../../README.md) / [Documentation](../../Documentation.md)

## Definition

|||
|--|--|
|Namespace|Izayoi.Data.TimestampedObjects|
|Assembly|Izayoi.Data.TimestampedObjects.dll|

Represents a comparable timestamped structure that can be assigned comparable structure.

~~~csharp
public readonly struct ComparableTimestampedStruct<TValue> :
    IComparableTimestampedStruct<TValue>,
    IComparable<ComparableTimestampedStruct<TValue>>,
    IEquatable<ComparableTimestampedStruct<TValue>>
    where TValue : struct, IComparable<TValue>, IEquatable<TValue>
~~~

## Type Parameters
`TValue`  
The underlying value type of the ComparableTimestampedStruct&lt;TValue&gt; generic type.

[IComparable\<TVable>](https://learn.microsoft.com/en-us/dotnet/api/system.icomparable-1)  
[IEquatable\<TVable>](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable-1)

### Inheritance
Object -> [ValueType](https://learn.microsoft.com/en-us/dotnet/api/system.valuetype) -> ComparableTimestampedStruct&lt;TValue&gt;

## Constructors

|Name|Summary|
|--|--|
|ComparableTimestampedStruct&lt;TValue&gt;(in long timestamp, in TValue value)|Initializes an instance of the ComparableTimestampedStruct&lt;TValue&gt; structure to the specified timestamp and value.|
|ComparableTimestampedStruct&lt;TValue&gt;(in TValue value)|Initializes an instance of the ComparableTimestampedStruct&lt;TValue&gt; structure to the specified value.|

## Properties

|Name|Type|Summary|
|--|--|--|
|Timestamp|long|Gets Unix timestamp milliseconds.|
|Value|TValue|Gets the value of the current object if it has been assigned a valid underlying value.|

## Methods

|Name|Returns|Summary|
|--|--|--|
|CompareTo(ComparableTimestampedStruct&lt;TValue&gt; other)|int|Compares this instance to a specified ComparableTimestampedStruct&lt;TValue&gt; and returns an indication of their relative values.|
|CompareTo(IComparableTimestampedStruct&lt;TValue&gt;? other)|int|Compares this instance to a specified IComparableTimestampedStruct&lt;TValue&gt; and returns an indication of their relative values.|
|CompareTo(object? other)|int|Compares this instance to a specified object and returns an indication of their relative values.|
|Deconstruct(out long timestamp, out TValue value)|void|Deconstructs this ComparableTimestampedStruct&lt;TValue&gt; instance by timestamp and value.|
|Equals(ComparableTimestampedStruct&lt;TValue&gt; other)|bool|Indicates whether the current ComparableTimestampedStruct&lt;TValue&gt; object is equal to a specified ComparableTimestampedStruct&lt;TValue&gt;.|
|Equals(IComparableTimestampedStruct&lt;TValue&gt;? other)|bool|Indicates whether the current ComparableTimestampedStruct&lt;TValue&gt; object is equal to a specified IComparableTimestampedStruct&lt;TValue&gt;.|
|Equals(object? other)|bool|Indicates whether the current ComparableTimestampedStruct&lt;TValue&gt; object is equal to a specified object.|
|GetHashCode()|string|Returns the hash code for this instance.|
|ToString()|string?|Returns the text representation of the value of the current ComparableTimestampedStruct&lt;TValue&gt; object.|

## Operators

|Operator|Returns|Left|Right|
|--|--|--|--|
|==|bool|ComparableTimestampedStruct&lt;TValue&gt;|ComparableTimestampedStruct&lt;TValue&gt;|
|!=|bool|ComparableTimestampedStruct&lt;TValue&gt;|ComparableTimestampedStruct&lt;TValue&gt;|
|<|bool|ComparableTimestampedStruct&lt;TValue&gt;|ComparableTimestampedStruct&lt;TValue&gt;|
|<=|bool|ComparableTimestampedStruct&lt;TValue&gt;|ComparableTimestampedStruct&lt;TValue&gt;|
|>|bool|ComparableTimestampedStruct&lt;TValue&gt;|ComparableTimestampedStruct&lt;TValue&gt;|
|>=|bool|ComparableTimestampedStruct&lt;TValue&gt;|ComparableTimestampedStruct&lt;TValue&gt;|

## Examples

~~~csharp
using Izayoi.Data.Comparable;
using Izayoi.Data.Packs;
using Izayoi.Data.TimestampedObjects;
using System;

public class Example()
{
    public void Method1()
    {
        ComparableTimestampedStruct<int> cts0 = new();

        // cts0.Timestamp: 0
        // cts0.Value: 0

        ComparableTimestampedStruct<int> cts1 = new(1);

        // cts1.Timestamp: (1234567890)
        // cts1.Value: 1

        long utcNow = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();

        ComparableTimestampedStruct<int> cts2 = new(utcNow, 2);

        // cts2.Timestamp: (utcNow)
        // cts2.Value: 2
    }

    // Izayoi.Data.Comparable.ComparableNullable<TValue>
    public void Method2()
    {
        // NG
        //ComparableTimestampedStruct<int?> cts1 = new(1);

        // NG
        //ComparableTimestampedStruct<System.Nullable<int>> cts1 = new(1);

        // OK
        ComparableTimestampedStruct<ComparableNullable<int>> cts1 = new(1);

        // cts1.Timestamp: (1234567890)
        // cts1.Value.HasValue: true
        // cts1.Value.Value: 1

        // OK
        ComparableTimestampedStruct<ComparableNullable<int>> ctsNull = new(null);

        // ctsNull.Timestamp: (1234567890)
        // ctsNull.Value.HasValue: false
    }

    public void Method3()
    {
        long utcNow = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();

        ComparableTimestampedStruct<int> cts1 = new(utcNow, 1);
        ComparableTimestampedStruct<int> cts2 = new(utcNow, 1);

        if (cts1 == cts2)
        {
            // true
        }
    }

    public void Method4()
    {
        long utcNow1 = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();

        ComparableTimestampedStruct<int> cts1 = new(utcNow1, 1);

        long utcNow2 = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();

        ComparableTimestampedStruct<int> cts2 = new(utcNow2, 1);

        if (cts1 < cts2)
        {
            // true (cts1.Timestamp < cts2.Timestamp)
        }
    }

    public void Method5()
    {
        long utcNow = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();

        ComparableTimestampedStruct<int> cts1 = new(utcNow, 1);
        ComparableTimestampedStruct<int> cts2 = new(utcNow, 2);

        if (cts1 < cts2)
        {
            // true
        }
    }

    // Izayoi.Data.Comparable.ComparableNullable<TValue>
    public void Method6()
    {
        long utcNow = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();

        ComparableTimestampedStruct<ComparableNullable<int>> cts1 = new(utcNow, null);
        ComparableTimestampedStruct<ComparableNullable<int>> cts2 = new(utcNow, 0);

        if (cts1 < cts2)
        {
            // true (null < 0)
        }
    }

    // Izayoi.Data.Comparable.ComparableStructPack<TValue1, ...>
    public void Method7()
    {
        long utcNow = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();

        ComparableTimestampedStruct<ComparableStructPack<int, long, int>> cts111 = new(utcNow, new(1, 1, 1));
        ComparableTimestampedStruct<ComparableStructPack<int, long, int>> cts112 = new(utcNow, new(1, 1, 2));

        if (cts111 < cts112)
        {
            // true
        }
    }

    public void Method8()
    {
        long utcNow = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();

        ComparableTimestampedStruct<ComparableSample2Struct> cts11 = new(utcNow, new(1, 1));
        ComparableTimestampedStruct<ComparableSample2Struct> cts12 = new(utcNow, new(1, 2));

        if (cts11 < cts12)
        {
            // true
        }
    }
}

public readonly struct ComparableSample2Struct :
    IComparable<ComparableSample2Struct>,
    IEquatable<ComparableSample2Struct>
{
    private readonly int value1;

    private readonly int value2;

    public ComparableSample2Struct(int value1, int value2)
    {
        this.value1 = value1;
        this.value2 = value2;
    }

    public readonly int Value1 => value1;

    public readonly int Value2 => value2;

    public int CompareTo(ComparableSample2Struct other)
    {
        //if (other is null)
        //{
        //    return 1;
        //}

        int compared1 = Value1.CompareTo(other.Value1);

        if (compared1 != 0)
        {
            return compared1;
        }

        int compared2 = Value2.CompareTo(other.Value2);

        if (compared2 != 0)
        {
            return compared2;
        }

        return 0;
    }

    public bool Equals(ComparableSample2Struct other)
    {
        //if (other is null)
        //{
        //    return false;
        //}

        return
            Value1.Equals(other.Value1) &&
            Value2.Equals(other.Value2);
    }
}
~~~

## Remarks

The order of comparison is `Timestamp` first, `Value` second.

## Applies to

|Product|Versions|
|--|--|
|.NET|8, 9|
|.NET Standard|2.0, 2.1|
