# Izayoi.Data.Comparable

This is a collection of comparable objects.

## Structures

|Structure|Remarks|
|---|---|
|ComparableEnum&lt;TEnum&gt;|A comparable enumulation.|
|ComparableNullable&lt;TValue&gt;|A comparable nullable value.|

## Examples

### ComparableEnum&lt;TEnum&gt;

~~~csharp
using Izayoi.Data.Comparable;
using System;

public class Example
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

        ComparableEnum<SampleEnum> ce2 = new(SampleEnum.Num2);

        // ce2.HasValue: true
        // ce2.Value: Num2

        if (ce < ce0)
        {
            // true (null < None)
        }

        if (ce0 < ce1)
        {
            // true (None < Num1)
        }

        if (ce1 < ce2)
        {
            // true (Num1 < Num2)
        }

        // null < None < Num1 < Num2
    }

    public void Method2()
    {
        ComparableEnum<SampleEnum> ceNew1 = new(SampleEnum.Num1);

        ComparableEnum<SampleEnum> ce1 = SampleEnum.Num1;

        if (ceNew1 == ce1)
        {
            // true
        }

        ComparableEnum<SampleEnum> ceNewNull = new();

        // NG
        //ComparableEnum<SampleEnum> ceNull = null;
    }
}
~~~

### ComparableNullable&lt;TValue&gt;

~~~csharp
using Izayoi.Data.Comparable;
using System;

public class Example
{
    public void Method1()
    {
        ComparableNullable<int> cniNull = new();

        // cniNull.HasValue: false

        ComparableNullable<int> cniMinus1 = new(-1);

        // cniMinus1.HasValue: true
        // cniMinus1.Value: -1

        ComparableNullable<int> cni0 = new(0);

        // cni0.HasValue: true
        // cni0.Value: 0

        ComparableNullable<int> cni1 = new(1);

        // cni1.HasValue: true
        // cni1.Value: 1

        if (cniNull < cniMinus1)
        {
            // true (null < -1)
        }

        if (cniMinus1 < cni0)
        {
            // true (-1 < 0)
        }

        if (cni0 < cni1)
        {
            // true (0 < 1)
        }

        // null < -1 < 0 < 1
    }

    public void Method2()
    {
        ComparableNullable<int> cniNewNull = new();

        ComparableNullable<int> cniNull = null;

        if (cniNewNull == cniNull)
        {
            // true
        }

        ComparableNullable<int> cniNew1 = new(1);

        ComparableNullable<int> cni1 = 1;

        if (cniNew1 == cni1)
        {
            // true
        }
    }
}
~~~

## Remarks

These are mainly used as generic parameters for `ComparableStructPack<TValue1, ...>` and `ComparableTimestampedObject<TValue>`.

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
