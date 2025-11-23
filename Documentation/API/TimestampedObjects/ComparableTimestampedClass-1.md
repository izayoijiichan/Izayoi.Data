# ComparableTimestampedClass&lt;TValue&gt;

[Top](../../../README.md) / [Documentation](../../Documentation.md)

## Definition

|||
|---|---|
|Namespace|Izayoi.Data.TimestampedObjects|
|Assembly|Izayoi.Data.TimestampedObjects.dll|

Represents a comparable timestamped class that can be assigned comparable class.

~~~csharp
public class ComparableTimestampedClass<TValue> :
    IComparableTimestampedClass<TValue>,
    IComparable<ComparableTimestampedClass<TValue>>,
    IEquatable<ComparableTimestampedClass<TValue>>
    where TValue : class, IComparable<TValue>, IEquatable<TValue>
~~~

## Type Parameters
`TValue`  
The underlying value type of the ComparableTimestampedClass&lt;TValue&gt; generic type.

[IComparable\<TVable>](https://learn.microsoft.com/en-us/dotnet/api/system.icomparable-1)  
[IEquatable\<TVable>](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable-1)

### Inheritance
Object -> [ValueType](https://learn.microsoft.com/en-us/dotnet/api/system.valuetype) -> ComparableTimestampedClass&lt;TValue&gt;

## Constructors

|Name|Summary|
|---|---|
|ComparableTimestampedClass&lt;TValue&gt;()|Initializes an instance of the ComparableTimestampedClass&lt;TValue&gt; class.|
|ComparableTimestampedClass&lt;TValue&gt;(in long timestamp, in TValue? value)|Initializes an instance of the ComparableTimestampedClass&lt;TValue&gt; class to the specified timestamp and value.|
|ComparableTimestampedClass&lt;TValue&gt;(in TValue? value)|Initializes an instance of the ComparableTimestampedClass&lt;TValue&gt; class to the specified value.|

## Properties

|Name|Type|Summary|
|---|---|---|
|Timestamp|long|Gets Unix timestamp milliseconds.|
|Value|TValue?|Gets the value of the current object if it has been assigned a valid underlying value.|

## Methods

|Name|Returns|Summary|
|---|---|---|
|CompareTo(ComparableTimestampedClass&lt;TValue&gt;? other)|int|Compares this instance to a specified ComparableTimestampedClass&lt;TValue&gt; and returns an indication of their relative values.|
|CompareTo(IComparableTimestampedClass&lt;TValue&gt;? other)|int|Compares this instance to a specified IComparableTimestampedClass&lt;TValue&gt; and returns an indication of their relative values.|
|CompareTo(object? other)|int|Compares this instance to a specified object and returns an indication of their relative values.|
|Deconstruct(out long timestamp, out TValue value)|void|Deconstructs this ComparableTimestampedClass&lt;TValue&gt; instance by timestamp and value.|
|Equals(ComparableTimestampedClass&lt;TValue&gt;? other)|bool|Indicates whether the current ComparableTimestampedClass&lt;TValue&gt; object is equal to a specified ComparableTimestampedClass&lt;TValue&gt;.|
|Equals(IComparableTimestampedClass&lt;TValue&gt;? other)|bool|Indicates whether the current ComparableTimestampedClass&lt;TValue&gt; object is equal to a specified IComparableTimestampedClass&lt;TValue&gt;.|
|Equals(object? other)|bool|Indicates whether the current ComparableTimestampedClass&lt;TValue&gt; object is equal to a specified object.|
|GetHashCode()|string|Returns the hash code for this instance.|
|ToString()|string?|Returns the text representation of the value of the current ComparableTimestampedClass&lt;TValue&gt; object.|

## Operators

|Operator|Returns|Left|Right|
|---|---|---|---|
|==|bool|ComparableTimestampedClass&lt;TValue&gt;|ComparableTimestampedClass&lt;TValue&gt;|
|!=|bool|ComparableTimestampedClass&lt;TValue&gt;|ComparableTimestampedClass&lt;TValue&gt;|
|<|bool|ComparableTimestampedClass&lt;TValue&gt;|ComparableTimestampedClass&lt;TValue&gt;|
|<=|bool|ComparableTimestampedClass&lt;TValue&gt;|ComparableTimestampedClass&lt;TValue&gt;|
|>|bool|ComparableTimestampedClass&lt;TValue&gt;|ComparableTimestampedClass&lt;TValue&gt;|
|>=|bool|ComparableTimestampedClass&lt;TValue&gt;|ComparableTimestampedClass&lt;TValue&gt;|

## Remarks

The order of comparison is `Timestamp` first, `Value` second.

## Examples

~~~csharp
using Izayoi.Data.Comparable;
using Izayoi.Data.TimestampedObjects;
using System;

public class Example()
{
    public enum SampleEnum
    {
        None = 0,
        Num1 = 1,
        Num2 = 2,
    }

    public void Method1()
    {
        ComparableTimestampedClass<ComparableSample2Class> ctc0 = new();

        // ctc0.Timestamp: 0
        // ctc0.Value: null

        ComparableTimestampedClass<ComparableSample2Class> ctc1 = new(new(1, 2));

        // ctc1.Timestamp: (1234567890)
        // ctc1.Value.Value1: 1
        // ctc1.Value.Value2: 2

        long utcNow = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();

        ComparableTimestampedClass<ComparableSample2Class> ctc2 = new(utcNow, new(1, 2));

        // ctc2.Timestamp: (utcNow)
        // ctc2.Value.Value1: 1
        // ctc2.Value.Value2: 2
    }

    public void Method2()
    {
        long utcNow = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();

        ComparableTimestampedClass<ComparableSample2Class> ctc1 = new(utcNow, new(1, 2));
        ComparableTimestampedClass<ComparableSample2Class> ctc2 = new(utcNow, new(1, 2));

        if (ctc1 == ctc2)
        {
            // true
        }
    }

    public void Method3()
    {
        long utcNow1 = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();

        ComparableTimestampedClass<ComparableSample2Class> ctc1 = new(utcNow1, new(1, 2));

        long utcNow2 = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();

        ComparableTimestampedClass<ComparableSample2Class> ctc2 = new(utcNow2, new(1, 2));

        if (ctc1 < ctc2)
        {
            // true
        }
    }

    public void Method4()
    {
        long utcNow = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();

        ComparableTimestampedClass<ComparableSample2Class> ctcNull = new(utcNow, null);
        ComparableTimestampedClass<ComparableSample2Class> ctc00 = new(utcNow, new(0, 0));
        ComparableTimestampedClass<ComparableSample2Class> ctc01 = new(utcNow, new(0, 1));

        if (ctcNull < ctc00)
        {
            // true
        }

        if (ctc00 < ctc01)
        {
            // true
        }

        // ctcNull < ctc00 < ctc01
    }

    // Izayoi.Data.Comparable.ComparableEnum<TEnum>
    public void Method5()
    {
        ComparableTimestampedClass<ComparableEnum<SampleEnum>> ctc0 = new();

        // ctc0.Timestamp: 0
        // ctc0.Value: null

        ComparableTimestampedClass<ComparableEnum<SampleEnum>> ctc1 = new(SampleEnum.Num1);

        // ctc1.Timestamp: (1234567890)
        // ctc1.Value.Value: Num1

        long utcNow = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();

        ComparableTimestampedClass<ComparableEnum<SampleEnum>> ctc2 = new(utcNow, SampleEnum.Num1);

        // ctc2.Timestamp: (utcNow)
        // ctc2.Value.Value: Num1
    }

    public void Method6()
    {
        long utcNow = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();

        ComparableTimestampedClass<ComparableEnum<SampleEnum>> ctc1 = new(utcNow, SampleEnum.Num1);
        ComparableTimestampedClass<ComparableEnum<SampleEnum>> ctc2 = new(utcNow, SampleEnum.Num1);

        if (ctc1 == ctc2)
        {
            // true
        }
    }

    public void Method7()
    {
        long utcNow = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();

        ComparableTimestampedClass<ComparableEnum<SampleEnum>> ctcNull = new(utcNow, new());
        ComparableTimestampedClass<ComparableEnum<SampleEnum>> ctc0 = new(utcNow, SampleEnum.None);
        ComparableTimestampedClass<ComparableEnum<SampleEnum>> ctc1 = new(utcNow, SampleEnum.Num1);
        ComparableTimestampedClass<ComparableEnum<SampleEnum>> ctc2 = new(utcNow, SampleEnum.Num2);

        if (ctcNull < ctc0)
        {
            // true (null < SampleEnum.None)
        }

        // ctcNull < ctc0 < ctc1 < ctc2
    }
}

public readonly struct ComparableSample2Class :
    IComparable<ComparableSample2Struct>,
    IEquatable<ComparableSample2Struct>
{
    public ComparableSample2Class(int value1, int value2)
    {
        Value1 = value1;
        Value2 = value2;
    }

    public int Value1 { get; set; }
    public int Value2 { get; set; }

    public int CompareTo(ComparableSample2Class? other)
    {
        if (other is null)
        {
            return 1;
        }

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

    public bool Equals(ComparableSample2Class? other)
    {
        if (other is null)
        {
            return false;
        }

        return
            Value1.Equals(other.Value1) &&
            Value2.Equals(other.Value2);
    }
}
~~~

## Applies to

|Product|Versions|
|---|---|
|.NET|8, 9, 10|
|.NET Standard|2.0, 2.1|
