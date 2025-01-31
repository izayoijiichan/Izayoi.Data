# ComparableEnum&lt;TEnum&gt;

[Top](../../../README.md) / [Documentation](../../Documentation.md)

## Definition

|||
|--|--|
|Namespace|Izayoi.Data.Comparable|
|Assembly|Izayoi.Data.Comparable.dll|

Represents a comparable enum type that can be assigned null.

~~~csharp
public class ComparableEnum<TEnum> :
    IComparableEnum<TEnum>
    where TEnum : Enum
~~~

## Type Parameters
`TEnum`  
The underlying value type of the ComparableEnum&lt;TEnum&gt; generic type.

### Inheritance
Object -> ValueType -> [Enum](https://learn.microsoft.com/en-us/dotnet/api/system.enum) -> ComparableEnum&lt;TEnum&gt;

## Constructors

|Name|Summary|
|--|--|
|ComparableEnum&lt;TEnum&gt;()|Initializes an instance of the ComparableEnum&lt;TEnum&gt; class.|
|ComparableEnum&lt;TEnum&gt;(in TEnum value)|Initializes an instance of the ComparableEnum&lt;TEnum&gt; class to the specified value.|

## Properties

|Name|Type|Summary|
|--|--|--|
|Value|TEnum|Gets the value of the current ComparableEnum&lt;TEnum&gt; object if it has been assigned a valid underlying value.|

## Methods

|Name|Returns|Summary|
|--|--|--|
|CompareTo(ComparableEnum&lt;TEnum&gt;? other)|int|Compares this instance to a specified ComparableEnum&lt;TEnum&gt; and returns an indication of their relative values.|
|CompareTo(object? other)|int|Compares this instance to a specified object and returns an indication of their relative values.|
|Equals(ComparableEnum&lt;TEnum&gt;? other)|bool|Indicates whether the current ComparableEnum&lt;TEnum&gt; object is equal to a specified ComparableEnum&lt;TEnum&gt;.|
|Equals(object? other)|bool|Indicates whether the current ComparableEnum&lt;TEnum&gt; object is equal to a specified object.|
|GetHashCode()|string|Returns the hash code for this instance.|
|GetValueOrDefault()|TEnum|Retrieves the value of the current ComparableEnum&lt;TEnum&gt; object, or the default value of the underlying type.|
|GetValueOrDefault(TEnum defaultValue)|TEnum|Retrieves the value of the current ComparableEnum&lt;TEnum&gt; object, or the specified default value.|
|HasFlag(TEnum flag)|bool|Determines whether one or more bit fields are set in the current instance.|
|ToString()|string?|Returns the text representation of the value of the current ComparableEnum&lt;TEnum&gt; object.|

## Operators

|Operator|Returns|Left|Right|
|--|--|--|--|
|==|bool|ComparableEnum&lt;TEnum&gt;|ComparableEnum&lt;TEnum&gt;|
|!=|bool|ComparableEnum&lt;TEnum&gt;|ComparableEnum&lt;TEnum&gt;|
|<|bool|ComparableEnum&lt;TEnum&gt;|ComparableEnum&lt;TEnum&gt;|
|<=|bool|ComparableEnum&lt;TEnum&gt;|ComparableEnum&lt;TEnum&gt;|
|>|bool|ComparableEnum&lt;TEnum&gt;|ComparableEnum&lt;TEnum&gt;|
|>=|bool|ComparableEnum&lt;TEnum&gt;|ComparableEnum&lt;TEnum&gt;|

|Type|From|To|
|--|--|--|
|implicit|TEnum|ComparableEnum&lt;TEnum&gt;|
|explicit|ComparableEnum&lt;TEnum&gt;|TEnum|

## Examples

~~~csharp
using Izayoi.Data.Comparable;
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
        ComparableEnum<SampleEnum> ce = new();

        // ce.HasValue: false
        // ce.Value: Num0

        ComparableEnum<SampleEnum> ce0 = new(SampleEnum.None);

        // ce1.HasValue: true
        // ce1.Value: None

        ComparableEnum<SampleEnum> ce1 = new(SampleEnum.Num1);

        // ce1.HasValue: true
        // ce1.Value: Num1

        ComparableEnum<SampleEnum> ce2 = SampleEnum.Num2;

        // ce2.HasValue: true
        // ce2.Value: Num2

        if (ce < ce0)
        {
            // true (null < None)
        }

        if (ce1 < ce2)
        {
            // true (Num1 < Num2)
        }
    }
}
~~~

## Applies to

|Product|Versions|
|--|--|
|.NET|8, 9|
|.NET Standard|2.0, 2.1|
