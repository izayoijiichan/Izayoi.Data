# TimestampedString

[Top](../../../README.md) / [Documentation](../../Documentation.md)

## Definition

|||
|--|--|
|Namespace|Izayoi.Data.TimestampedObjects|
|Assembly|Izayoi.Data.TimestampedObjects.dll|

Represents a comparable timestamped structure that can be assigned comparable class.

~~~csharp
public readonly struct TimestampedString :
    ITimestamped,
    IComparableTimestampedBase<string>,
    IComparable,
    IComparable<TimestampedString>,
    IComparable<ComparableTimestampedClass<string>>,
    IEquatable<TimestampedString>,
    IEquatable<ComparableTimestampedClass<string>>
~~~

### Inheritance
Object -> [ValueType](https://learn.microsoft.com/en-us/dotnet/api/system.valuetype) -> TimestampedString

## Constructors

|Name|Summary|
|--|--|
|TimestampedString(in long timestamp, in string? value)|Initializes an instance of the TimestampedString structure to the specified timestamp and value.|
|TimestampedString(in long timestamp, in char c, in int count)|Initializes an instance of the TimestampedString structure to the specified timestamp, c and count.|
|TimestampedString(in long timestamp, in char[] value)|Initializes an instance of the TimestampedString structure to the specified timestamp and value.|
|TimestampedString(in long timestamp, in char[] value, in int startIndex, in int length)|Initializes an instance of the TimestampedString structure to the specified timestamp, value, startIndex and length.|
|TimestampedString(in long timestamp, in ReadOnlySpan<char> value)|Initializes an instance of the TimestampedString structure to the specified timestamp and value.|
|TimestampedString(in string? value)|Initializes an instance of the TimestampedString structure to the specified value.|
|TimestampedString(in char c, in int count)|Initializes an instance of the TimestampedString structure to the specified c and count.|
|TimestampedString(in char[] value)|Initializes an instance of the TimestampedString structure to the specified value.|
|TimestampedString(in char[] value, in int startIndex, in int length)|Initializes an instance of the TimestampedString structure to the specified value, startIndex and length.|
|TimestampedString(in ReadOnlySpan<char> value)|Initializes an instance of the TimestampedString structure to the specified timestamp and value.|

## Properties

|Name|Type|Summary|
|--|--|--|
|Timestamp|long|Gets Unix timestamp milliseconds.|
|Value|string?|Gets the string value of the current object.|

## Methods

|Name|Returns|Summary|
|--|--|--|
|CompareTo(TimestampedString other)|int|Compares this instance to a specified TimestampedString and returns an indication of their relative values.|
|CompareTo(ComparableTimestampedClass&lt;string&gt;? other)|int|Compares this instance to a specified ComparableTimestampedClass&lt;string&gt; and returns an indication of their relative values.|
|CompareTo(object? other)|int|Compares this instance to a specified object and returns an indication of their relative values.|
|Deconstruct(out long timestamp, out TValue value)|void|Deconstructs this TimestampedString instance by timestamp and value.|
|Equals(TimestampedString other)|bool|Indicates whether the current TimestampedString object is equal to a specified TimestampedString.|
|Equals(ComparableTimestampedClass&lt;string&gt;? other)|bool|Indicates whether the current TimestampedString object is equal to a specified ComparableTimestampedClass&lt;string&gt;.|
|Equals(object? other)|bool|Indicates whether the current TimestampedString object is equal to a specified object.|
|GetHashCode()|string|Returns the hash code for this instance.|
|ToString()|string?|Returns the text representation of the value of the current TimestampedString object.|

## Operators

|Operator|Returns|Left|Right|
|--|--|--|--|
|==|bool|TimestampedString|TimestampedString|
|!=|bool|TimestampedString|TimestampedString|
|<|bool|TimestampedString|TimestampedString|
|<=|bool|TimestampedString|TimestampedString|
|>|bool|TimestampedString|TimestampedString|
|>=|bool|TimestampedString|TimestampedString|

|Type|From|To|
|--|--|--|
|implicit|TimestampedString|ComparableTimestampedClass&lt;string&gt;|
|implicit|ComparableTimestampedClass&lt;string&gt;|TimestampedString|

## Remarks

The order of comparison is `Timestamp` first, `Value` second.

## Examples

~~~csharp
using Izayoi.Data.TimestampedObjects;
using System;

public class Example()
{
    public void Method1()
    {
        TimestampedString ts0 = new();

        // ts0.Timestamp: 0
        // ts0.Value: null

        TimestampedString ts11 = new(default(string?));

        // ts11.Timestamp: (1234567890)
        // ts11.Value: null

        TimestampedString ts12 = new("");

        // ts12.Timestamp: (1234567890)
        // ts12.Value: ""

        TimestampedString ts13 = new("ab");

        // ts13.Timestamp: (1234567890)
        // ts13.Value: "ab"

        long utcNow = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();

        TimestampedString ts21 = new(utcNow, default(string?));

        // ts21.Timestamp: (utcNow)
        // ts21.Value: null

        TimestampedString ts22 = new(utcNow, "");

        // ts22.Timestamp: (utcNow)
        // ts22.Value: ""

        TimestampedString ts23 = new(utcNow, "ab");

        // ts23.Timestamp: (utcNow)
        // ts23.Value: "ab"

        TimestampedString ts24 = new(utcNow, new char[] {'a', 'b', 'c'});

        // ts24.Timestamp: (utcNow)
        // ts24.Value: "abc"

        TimestampedString ts25 = new(utcNow, new char[] {'a', 'b', 'c'}, startIndex: 1, length: 2);

        // ts25.Timestamp: (utcNow)
        // ts25.Value: "bc"
    }

    public void Method2()
    {
        long utcNow = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();

        TimestampedString ts1 = new(utcNow, "abc");
        TimestampedString ts2 = new(utcNow, "abc");

        if (ts1 == ts2)
        {
            // true
        }
    }

    public void Method3()
    {
        long utcNow1 = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();

        TimestampedString ts1 = new(utcNow1, "abc");

        long utcNow2 = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();

        TimestampedString ts2 = new(utcNow2, "abc");

        if (ts1 < ts2)
        {
            // true (ts1.Timestamp < ts2.Timestamp)
        }
    }

    public void Method4()
    {
        long utcNow = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();

        TimestampedString ts1a = new(utcNow, "a");
        TimestampedString ts1b = new(utcNow, "b");

        if (ts1a < ts1b)
        {
            // true ("a" < "b")
        }
    }

    public void Method5()
    {
        long utcNow = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();

        TimestampedString ts1e = new(utcNow, "");
        TimestampedString ts1a = new(utcNow, "a");

        if (ts1e < ts1a)
        {
            // true ("" < "a")
        }
    }

    public void Method6()
    {
        long utcNow = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();

        TimestampedString ts1n = new(utcNow, default(string?));
        TimestampedString ts1e = new(utcNow, "");

        if (ts1n < ts1e)
        {
            // true (null < "")
        }
    }
}
~~~

## Applies to

|Product|Versions|
|--|--|
|.NET|8, 9|
|.NET Standard|2.0, 2.1|
