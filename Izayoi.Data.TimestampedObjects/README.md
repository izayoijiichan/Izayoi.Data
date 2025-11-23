# Izayoi.Data.TimestampedObjects

This is timestamped objects.

## Definition

|Class/Structure|Cateogory|Remarks|
|---|---|---|
|ComparableTimestampedStruct&lt;TValue&gt;|comparable|A comparable timestamped structure that can be assigned comparable structure.|
|ComparableTimestampedClass&lt;TValue&gt;|comparable|A comparable timestamped class that can be assigned comparable class.|
|ComparableTimestampedObject&lt;TValue&gt;|comparable|A comparable timestamped class that can be assigned comparable object.|
|TimestampedString|comparable|A comparable timestamped string.|
|UncomparableTimestampedStruct&lt;TValue&gt;|uncomparable|A uncomparable timestamped structure that can be assigned uncomparable structure.|
|UncomparableTimestampedClass&lt;TValue&gt;|uncomparable|A uncomparable timestamped class that can be assigned uncomparable class.|
|UncomparableTimestampedObject&lt;TValue&gt;|uncomparable|A uncomparable timestamped class that can be assigned uncomparable object.|

## Remarks

The order of comparison is `Timestamp` first, `Value` second.

It is recommended that libraries `Izayoi.Data.Comparable` and `Izayoi.Data.Packs` be used together.

## Examples

### ComparableTimestampedStruct&lt;TValue&gt;

~~~csharp
using Izayoi.Data.Comparable;
using Izayoi.Data.Packs;
using Izayoi.Data.TimestampedObjects;
using System;

public class Example
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

    public void Method2()
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

    public void Method3()
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
    public void Method4()
    {
        ComparableTimestampedStruct<ComparableNullable<int>> cts1 = new(1);

        // cts1.Timestamp: (1234567890)
        // cts1.Value.HasValue: true
        // cts1.Value.Value: 1

        ComparableTimestampedStruct<ComparableNullable<int>> ctsNull = new(null);

        // ctsNull.Timestamp: (1234567890)
        // ctsNull.Value.HasValue: false
    }

    public void Method5()
    {
        long utcNow = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();

        ComparableTimestampedStruct<ComparableNullable<int>> ctsNull = new(utcNow, null);

        ComparableTimestampedStruct<ComparableNullable<int>> ctsM1 = new(utcNow, -1);

        ComparableTimestampedStruct<ComparableNullable<int>> cts0 = new(utcNow, 0);

        ComparableTimestampedStruct<ComparableNullable<int>> cts1 = new(utcNow, 1);

        if (ctsNull < ctsM1)
        {
            // true (null < -1)
        }

        // ctsNull < ctsM1 < cts0 < cts1
    }

    // Izayoi.Data.Comparable.ComparableStructPack<TValue1, ...>
    public void Method6()
    {
        long utcNow = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();

        ComparableTimestampedStruct<ComparableStructPack<int, long, int>> cts111 = new(utcNow, new(1, 1, 1));
        ComparableTimestampedStruct<ComparableStructPack<int, long, int>> cts112 = new(utcNow, new(1, 1, 2));

        if (cts111 < cts112)
        {
            // true
        }
    }

    // @see Documentation or Wiki
    public void Method7()
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
~~~

### ComparableTimestampedClass&lt;TValue&gt;

~~~csharp
using Izayoi.Data.Comparable;
using Izayoi.Data.TimestampedObjects;
using System;

public class Example
{
    // @see Documentation or Wiki
    public void Method1()
    {
        long utcNow1 = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();

        ComparableTimestampedClass<ComparableSample2Class> ctc1 = new(utcNow1, new(1, 1));

        long utcNow2 = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();

        ComparableTimestampedClass<ComparableSample2Class> ctc2 = new(utcNow2, new(1, 1));

        if (ctc1 < ctc2)
        {
            // true (ctc1.Timestamp < ctc2.Timestamp)
        }
    }

    public void Method2()
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

    public enum SampleEnum
    {
        None = 0,
        Num1 = 1,
        Num2 = 2,
    }

    // Izayoi.Data.Comparable.ComparableEnum<TEnum>
    public void Method3()
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
~~~

### TimestampedString

~~~csharp
using Izayoi.Data.TimestampedObjects;
using System;

public class Example
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

        TimestampedString tsN = new(utcNow, default(string?));
        TimestampedString tsE = new(utcNow, "");
        TimestampedString tsA = new(utcNow, "A");
        TimestampedString tsB = new(utcNow, "B");

        if (tsN < tsE)
        {
            // true (null < "")
        }

        if (tsE < tsA)
        {
            // true ("" < "A")
        }

        if (tsA < tsB)
        {
            // true ("A" < "B")
        }

        // tsN <  tsE < tsA < tsB
    }
}
~~~

## Applies to

|Product|Versions|
|---|---|
|.NET|8, 9, 10|
|.NET Standard|2.0, 2.1|
|Unity|2021, 2022, 6000|

## Wiki

[Wiki](https://github.com/izayoijiichan/Izayoi.Data/wiki)

___
Last updated: 24 November, 2025  
Editor: Izayoi Jiichan

*Copyright (C) 2025 Izayoi Jiichan. All Rights Reserved.*
