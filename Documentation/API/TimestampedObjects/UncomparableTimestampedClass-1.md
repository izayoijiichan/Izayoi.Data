# UncomparableTimestampedClass&lt;TValue&gt;

[Top](../../../README.md) / [Documentation](../../Documentation.md)

## Definition

|||
|--|--|
|Namespace|Izayoi.Data.TimestampedObjects|
|Assembly|Izayoi.Data.TimestampedObjects.dll|

Represents a uncomparable timestamped class that can be assigned uncomparable class.

~~~csharp
public class UncomparableTimestampedClass<TValue> :
    IUncomparableTimestampedClass<TValue>,
    where TValue : class
~~~

## Type Parameters
`TValue`  
The underlying value type of the UncomparableTimestampedClass&lt;TValue&gt; generic type.

### Inheritance
Object -> [ValueType](https://learn.microsoft.com/en-us/dotnet/api/system.valuetype) -> UncomparableTimestampedClass&lt;TValue&gt;

## Constructors

|Name|Summary|
|--|--|
|UncomparableTimestampedClass&lt;TValue&gt;()|Initializes an instance of the UncomparableTimestampedClass&lt;TValue&gt; class.|
|UncomparableTimestampedClass&lt;TValue&gt;(in long timestamp, in TValue? value)|Initializes an instance of the UncomparableTimestampedClass&lt;TValue&gt; class to the specified timestamp and value.|
|UncomparableTimestampedClass&lt;TValue&gt;(in TValue? value)|Initializes an instance of the UncomparableTimestampedClass&lt;TValue&gt; class to the specified value.|

## Properties

|Name|Type|Summary|
|--|--|--|
|Timestamp|long|Gets Unix timestamp milliseconds.|
|Value|TValue?|Gets the value of the current object if it has been assigned a valid underlying value.|

## Methods

|Name|Returns|Summary|
|--|--|--|
|Deconstruct(out long timestamp, out TValue value)|void|Deconstructs this UncomparableTimestampedClass&lt;TValue&gt; instance by timestamp and value.|
|Equals(UncomparableTimestampedClass&lt;TValue&gt;? other)|bool|Indicates whether the current UncomparableTimestampedClass&lt;TValue&gt; object is equal to a specified UncomparableTimestampedClass&lt;TValue&gt;.|
|Equals(IUncomparableTimestampedClass&lt;TValue&gt;? other)|bool|Indicates whether the current UncomparableTimestampedClass&lt;TValue&gt; object is equal to a specified IUncomparableTimestampedClass&lt;TValue&gt;.|
|Equals(object? other)|bool|Indicates whether the current UncomparableTimestampedClass&lt;TValue&gt; object is equal to a specified object.|
|GetHashCode()|string|Returns the hash code for this instance.|
|ToString()|string?|Returns the text representation of the value of the current UncomparableTimestampedClass&lt;TValue&gt; object.|

## Operators

|Operator|Returns|Left|Right|
|--|--|--|--|
|==|bool|UncomparableTimestampedClass&lt;TValue&gt;|UncomparableTimestampedClass&lt;TValue&gt;|
|!=|bool|UncomparableTimestampedClass&lt;TValue&gt;|UncomparableTimestampedClass&lt;TValue&gt;|

## Examples

~~~csharp
using Izayoi.Data.TimestampedObjects;
using System;

public class Example()
{
    public void Method1()
    {
        UncomparableTimestampedClass<UncomparableSample2Class> utc0 = new();

        // uts0.Timestamp: 0
        // uts0.Value: null

        UncomparableTimestampedClass<UncomparableSample2Class> utc1 = new(new(1, 2));

        // utc1.Timestamp: (1234567890)
        // utc1.Value.Value1: 1
        // utc1.Value.Value2: 2

        long utcNow = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();

        UncomparableTimestampedClass<UncomparableSample2Class> utc2 = new(utcNow, new(1, 2));

        // utc2.Timestamp: (utcNow)
        // utc2.Value.Value1: 1
        // utc2.Value.Value2: 2
    }

    public void Method2()
    {
        UncomparableSample2Class sameClass = new(1, 2);

        long utcNow = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();

        UncomparableTimestampedClass<UncomparableSample2Class> utc1 = new(utcNow, sameClass);
        UncomparableTimestampedClass<UncomparableSample2Class> utc2 = new(utcNow, sameClass);

        if (utc1 == utc2)
        {
            // true
        }
    }

    public void Method3()
    {
        long utcNow = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();

        UncomparableSample2Class class1 = new(1, 2);
        UncomparableSample2Class class2 = new(1, 2);

        UncomparableTimestampedClass<UncomparableSample2Class> utc1 = new(utcNow, class1);
        UncomparableTimestampedClass<UncomparableSample2Class> utc2 = new(utcNow, class2);

        if (utc1 == utc2)
        {
            // false (class1 != class2)
        }
    }

    public void Method4()
    {
        UncomparableSample2Class sameClass = new(1, 2);

        long utcNow1 = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();

        UncomparableTimestampedClass<int> utc1 = new(utcNow1, sameClass);

        long utcNow2 = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();

        UncomparableTimestampedClass<int> utc2 = new(utcNow2, sameClass);

        if (utc1 == utc2)
        {
            // false (utc1.Timestamp != utc2.Timestamp)
        }
    }
}

public readonly struct ComparableSample2Class
{
    public ComparableSample2Class(int value1, int value2)
    {
        Value1 = value1;
        Value2 = value2;
    }

    public int Value1 { get; set; }
    public int Value2 { get; set; }
}
~~~

## Applies to

|Product|Versions|
|--|--|
|.NET|8, 9|
|.NET Standard|2.0, 2.1|
