# UncomparableTimestampedStruct&lt;TValue&gt;

[Top](../../../README.md) / [Documentation](../../Documentation.md)

## Definition

|||
|---|---|
|Namespace|Izayoi.Data.TimestampedObjects|
|Assembly|Izayoi.Data.TimestampedObjects.dll|

Represents a uncomparable timestamped structure that can be assigned uncomparable structure.

~~~csharp
public readonly struct UncomparableTimestampedStruct<TValue> :
    IUncomparableTimestampedStruct<TValue>,
    where TValue : struct
~~~

## Type Parameters
`TValue`  
The underlying value type of the UncomparableTimestampedStruct&lt;TValue&gt; generic type.

### Inheritance
Object -> [ValueType](https://learn.microsoft.com/en-us/dotnet/api/system.valuetype) -> UncomparableTimestampedStruct&lt;TValue&gt;

## Constructors

|Name|Summary|
|---|---|
|UncomparableTimestampedStruct&lt;TValue&gt;(in long timestamp, in TValue value)|Initializes an instance of the UncomparableTimestampedStruct&lt;TValue&gt; structure to the specified timestamp and value.|
|UncomparableTimestampedStruct&lt;TValue&gt;(in TValue value)|Initializes an instance of the UncomparableTimestampedStruct&lt;TValue&gt; structure to the specified value.|

## Properties

|Name|Type|Summary|
|---|---|---|
|Timestamp|long|Gets Unix timestamp milliseconds.|
|Value|TValue|Gets the value of the current object if it has been assigned a valid underlying value.|

## Methods

|Name|Returns|Summary|
|---|---|---|
|Deconstruct(out long timestamp, out TValue value)|void|Deconstructs this UncomparableTimestampedStruct&lt;TValue&gt; instance by timestamp and value.|
|Equals(UncomparableTimestampedStruct&lt;TValue&gt; other)|bool|Indicates whether the current UncomparableTimestampedStruct&lt;TValue&gt; object is equal to a specified UncomparableTimestampedStruct&lt;TValue&gt;.|
|Equals(IUncomparableTimestampedStruct&lt;TValue&gt;? other)|bool|Indicates whether the current UncomparableTimestampedStruct&lt;TValue&gt; object is equal to a specified IUncomparableTimestampedStruct&lt;TValue&gt;.|
|Equals(object? other)|bool|Indicates whether the current UncomparableTimestampedStruct&lt;TValue&gt; object is equal to a specified object.|
|GetHashCode()|string|Returns the hash code for this instance.|
|ToString()|string?|Returns the text representation of the value of the current UncomparableTimestampedStruct&lt;TValue&gt; object.|

## Operators

|Operator|Returns|Left|Right|
|---|---|---|---|
|==|bool|UncomparableTimestampedStruct&lt;TValue&gt;|UncomparableTimestampedStruct&lt;TValue&gt;|
|!=|bool|UncomparableTimestampedStruct&lt;TValue&gt;|UncomparableTimestampedStruct&lt;TValue&gt;|

## Examples

~~~csharp
using Izayoi.Data.TimestampedObjects;
using System;

public class Example()
{
    public void Method1()
    {
        UncomparableTimestampedStruct<UncomparableSample2Struct> uts1 = new(new(1, 2));

        // uts1.Timestamp: (1234567890)
        // uts1.Value.Value1: 1
        // uts1.Value.Value2: 2

        long utcNow = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();

        UncomparableTimestampedStruct<UncomparableSample2Struct> uts2 = new(utcNow, new(1, 2));

        // uts2.Timestamp: (utcNow)
        // uts2.Value.Value1: 1
        // uts2.Value.Value2: 2
    }

    public void Method2()
    {
        long utcNow = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();

        UncomparableTimestampedStruct<UncomparableSample2Struct> uts1 = new(utcNow, new(1, 1));
        UncomparableTimestampedStruct<UncomparableSample2Struct> uts2 = new(utcNow, new(1, 1));

        if (uts1 == uts2)
        {
            // true (uts1.Value == uts2.Value)
        }
    }

    public void Method3()
    {
        long utcNow1 = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();

        UncomparableTimestampedStruct<UncomparableSample2Struct> uts1 = new(utcNow1, new(1, 1));

        long utcNow2 = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();

        UncomparableTimestampedStruct<UncomparableSample2Struct> uts2 = new(utcNow2, new(1, 1));

        if (uts1 == uts2)
        {
            // false (uts1.Timestamp != uts2.Timestamp)
        }
    }

    public void Method4()
    {
        long utcNow = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();

        UncomparableTimestampedStruct<UncomparableSample2Struct> uts11 = new(utcNow, new(1, 1));
        UncomparableTimestampedStruct<UncomparableSample2Struct> uts12 = new(utcNow, new(1, 2));

        if (uts11 == uts12)
        {
            // false (uts11.Value != uts12.Value)
        }
    }
}

public readonly struct UncomparableSample2Struct
{
    private readonly int value1;

    private readonly int value2;

    public UncomparableSample2Struct(int value1, int value2)
    {
        this.value1 = value1;
        this.value2 = value2;
    }

    public readonly int Value1 => value1;

    public readonly int Value2 => value2;
}
~~~

## Applies to

|Product|Versions|
|---|---|
|.NET|8, 9, 10|
|.NET Standard|2.0, 2.1|
