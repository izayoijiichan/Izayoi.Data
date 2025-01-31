# UncomparableTimestampedObject&lt;TValue&gt;

[Top](../../../README.md) / [Documentation](../../Documentation.md)

## Definition

|||
|--|--|
|Namespace|Izayoi.Data.TimestampedObjects|
|Assembly|Izayoi.Data.TimestampedObjects.dll|

Represents a uncomparable timestamped class that can be assigned uncomparable object.

~~~csharp
public class UncomparableTimestampedObject<TValue> :
    IUncomparableTimestampedObject<TValue>
~~~

## Type Parameters
`TValue`  
The underlying value type of the UncomparableTimestampedObject&lt;TValue&gt; generic type.

### Inheritance
Object -> [ValueType](https://learn.microsoft.com/en-us/dotnet/api/system.valuetype) -> UncomparableTimestampedObject&lt;TValue&gt;

## Constructors

|Name|Summary|
|--|--|
|UncomparableTimestampedObject&lt;TValue&gt;()|Initializes an instance of the UncomparableTimestampedObject&lt;TValue&gt; class.|
|UncomparableTimestampedObject&lt;TValue&gt;(in long timestamp, in TValue? value)|Initializes an instance of the UncomparableTimestampedObject&lt;TValue&gt; class to the specified timestamp and value.|
|UncomparableTimestampedObject&lt;TValue&gt;(in TValue? value)|Initializes an instance of the UncomparableTimestampedObject&lt;TValue&gt; class to the specified value.|

## Properties

|Name|Type|Summary|
|--|--|--|
|Timestamp|long|Gets Unix timestamp milliseconds.|
|Value|TValue?|Gets the value of the current object if it has been assigned a valid underlying value.|

## Methods

|Name|Returns|Summary|
|--|--|--|
|Deconstruct(out long timestamp, out TValue value)|void|Deconstructs this UncomparableTimestampedObject&lt;TValue&gt; instance by timestamp and value.|
|Equals(UncomparableTimestampedObject&lt;TValue&gt;? other)|bool|Indicates whether the current UncomparableTimestampedObject&lt;TValue&gt; object is equal to a specified UncomparableTimestampedObject&lt;TValue&gt;.|
|Equals(IUncomparableTimestampedObject&lt;TValue&gt;? other)|bool|Indicates whether the current UncomparableTimestampedObject&lt;TValue&gt; object is equal to a specified IUncomparableTimestampedObject&lt;TValue&gt;.|
|Equals(object? other)|bool|Indicates whether the current UncomparableTimestampedObject&lt;TValue&gt; object is equal to a specified object.|
|GetHashCode()|string|Returns the hash code for this instance.|
|ToString()|string?|Returns the text representation of the value of the current UncomparableTimestampedObject&lt;TValue&gt; object.|

## Operators

|Operator|Returns|Left|Right|
|--|--|--|--|
|==|bool|UncomparableTimestampedObject&lt;TValue&gt;|UncomparableTimestampedObject&lt;TValue&gt;|
|!=|bool|UncomparableTimestampedObject&lt;TValue&gt;|UncomparableTimestampedObject&lt;TValue&gt;|

## Examples

~~~csharp
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
        UncomparableTimestampedObject<SampleEnum> uto0 = new();

        // uto0.Timestamp: 0
        // uto0.Value: SampleEnum.None

        UncomparableTimestampedObject<SampleEnum> uto1 = new(SampleEnum.Num1);

        // uto1.Timestamp: (1234567890)
        // uto1.Value: SampleEnum.Num1

        long utcNow = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();

        UncomparableTimestampedObject<SampleEnum> uto2 = new(utcNow, SampleEnum.Num2);

        // uto2.Timestamp: (utcNow)
        // uto2.Value: SampleEnum.Num2

        UncomparableTimestampedObject<SampleEnum> uto3 = new(utcNow, SampleEnum.Num2);

        // uto3.Timestamp: (utcNow)
        // uto3.Value: SampleEnum.Num2

        if (uto2 == uto3)
        {
            // true
        }
    }

    public void Method2()
    {
        UncomparableTimestampedObject<int?> uto0 = new();

        // uto0.Timestamp: 0
        // uto0.Value: SampleEnum.None

        UncomparableTimestampedObject<int?> uto1 = new(1);

        // uto1.Timestamp: (1234567890)
        // uto1.Value.HasValue: true
        // uto1.Value.Value: 1

        long utcNow = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();

        UncomparableTimestampedObject<int?> uto2 = new(utcNow, 1);

        // uto2.Timestamp: (utcNow)
        // uto2.Value.HasValue: true
        // uto2.Value.Value: 1

        UncomparableTimestampedObject<int?> uto3 = new(utcNow, 1);

        // uto2.Timestamp: (utcNow)
        // uto2.Value.HasValue: true
        // uto2.Value.Value: 1

        UncomparableTimestampedObject<int?> uto4 = new(utcNow, null);

        // uto3.Timestamp: (utcNow)
        // uto3.Value.HasValue: false

        if (uto2 == uto3)
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
