# ComparableTimestampedObject&lt;TValue&gt;

[Top](../../../README.md) / [Documentation](../../Documentation.md)

## Definition

|||
|--|--|
|Namespace|Izayoi.Data.TimestampedObjects|
|Assembly|Izayoi.Data.TimestampedObjects.dll|

Represents a comparable timestamped class that can be assigned comparable object.

~~~csharp
public class ComparableTimestampedObject<TValue> :
    IComparableTimestampedObject<TValue>,
    IComparable<ComparableTimestampedObject<TValue>>,
    IEquatable<ComparableTimestampedObject<TValue>>
    where TValue : IComparable<TValue>, IEquatable<TValue>
~~~

## Type Parameters
`TValue`  
The underlying value type of the ComparableTimestampedObject&lt;TValue&gt; generic type.

[IComparable\<TVable>](https://learn.microsoft.com/en-us/dotnet/api/system.icomparable-1)  
[IEquatable\<TVable>](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable-1)

### Inheritance
Object -> [ValueType](https://learn.microsoft.com/en-us/dotnet/api/system.valuetype) -> ComparableTimestampedObject&lt;TValue&gt;

## Constructors

|Name|Summary|
|--|--|
|ComparableTimestampedObject&lt;TValue&gt;()|Initializes an instance of the ComparableTimestampedObject&lt;TValue&gt; class.|
|ComparableTimestampedObject&lt;TValue&gt;(in long timestamp, in TValue? value)|Initializes an instance of the ComparableTimestampedObject&lt;TValue&gt; class to the specified timestamp and value.|
|ComparableTimestampedObject&lt;TValue&gt;(in TValue? value)|Initializes an instance of the ComparableTimestampedObject&lt;TValue&gt; class to the specified value.|

## Properties

|Name|Type|Summary|
|--|--|--|
|Timestamp|long|Gets Unix timestamp milliseconds.|
|Value|TValue?|Gets the value of the current object if it has been assigned a valid underlying value.|

## Methods

|Name|Returns|Summary|
|--|--|--|
|CompareTo(ComparableTimestampedObject&lt;TValue&gt;? other)|int|Compares this instance to a specified ComparableTimestampedObject&lt;TValue&gt; and returns an indication of their relative values.|
|CompareTo(IComparableTimestampedObject&lt;TValue&gt;? other)|int|Compares this instance to a specified IComparableTimestampedObject&lt;TValue&gt; and returns an indication of their relative values.|
|CompareTo(object? other)|int|Compares this instance to a specified object and returns an indication of their relative values.|
|Deconstruct(out long timestamp, out TValue value)|void|Deconstructs this ComparableTimestampedObject&lt;TValue&gt; instance by timestamp and value.|
|Equals(ComparableTimestampedObject&lt;TValue&gt;? other)|bool|Indicates whether the current ComparableTimestampedObject&lt;TValue&gt; object is equal to a specified ComparableTimestampedObject&lt;TValue&gt;.|
|Equals(IComparableTimestampedObject&lt;TValue&gt;? other)|bool|Indicates whether the current ComparableTimestampedObject&lt;TValue&gt; object is equal to a specified IComparableTimestampedObject&lt;TValue&gt;.|
|Equals(object? other)|bool|Indicates whether the current ComparableTimestampedObject&lt;TValue&gt; object is equal to a specified object.|
|GetHashCode()|string|Returns the hash code for this instance.|
|ToString()|string?|Returns the text representation of the value of the current ComparableTimestampedObject&lt;TValue&gt; object.|

## Operators

|Operator|Returns|Left|Right|
|--|--|--|--|
|==|bool|ComparableTimestampedObject&lt;TValue&gt;|ComparableTimestampedObject&lt;TValue&gt;|
|!=|bool|ComparableTimestampedObject&lt;TValue&gt;|ComparableTimestampedObject&lt;TValue&gt;|
|<|bool|ComparableTimestampedObject&lt;TValue&gt;|ComparableTimestampedObject&lt;TValue&gt;|
|<=|bool|ComparableTimestampedObject&lt;TValue&gt;|ComparableTimestampedObject&lt;TValue&gt;|
|>|bool|ComparableTimestampedObject&lt;TValue&gt;|ComparableTimestampedObject&lt;TValue&gt;|
|>=|bool|ComparableTimestampedObject&lt;TValue&gt;|ComparableTimestampedObject&lt;TValue&gt;|

## Remarks

The order of comparison is `Timestamp` first, `Value` second.

## Applies to

|Product|Versions|
|--|--|
|.NET|8, 9|
|.NET Standard|2.0, 2.1|
