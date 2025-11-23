# Izayoi.Data.Packs

This is a struct pack.

## Structures

|Structure|Cateogory|Remarks|
|---|---|---|
|ComparableStructPack&lt;TValue1, TValue2&gt;|comparable|A comparable struct pack.|
|ComparableStructPack&lt;TValue1, TValue2, TValue3&gt;|comparable|A comparable struct pack.|
|ComparableStructPack&lt;TValue1, TValue2, TValue3, TValue4&gt;|comparable|A comparable struct pack.|
|ComparableStructPack&lt;TValue1, TValue2, TValue3, TValue4, TValue5&gt;|comparable|A comparable struct pack.|
|UncomparableStructPack&lt;TValue1, TValue2&gt;|uncomarable|A uncomparable struct pack.|
|UncomparableStructPack&lt;TValue1, TValue2, TValue3&gt;|uncomarable|A uncomparable struct pack.|
|UncomparableStructPack&lt;TValue1, TValue2, TValue3, TValue4&gt;|uncomarable|A uncomparable struct pack.|
|UncomparableStructPack&lt;TValue1, TValue2, TValue3, TValue4, TValue5&gt;|uncomarable|A uncomparable struct pack.|

## Examples

### ComparableStructPack

~~~csharp
using Izayoi.Data.Comparable;
using Izayoi.Data.Packs;
using System;

public class Example
{
    public void Method1()
    {
        ComparableStructPack<int, int> csp2 = new(1, 2);

        ComparableStructPack<int, long, int> csp3 = new(1, 2, 3);

        ComparableStructPack<int, byte, byte, short> csp4 = new(1, 2, 3, 4);

        ComparableStructPack<int, byte, byte, short, long> csp5 = new(1, 2, 3, 4, 5);

        // csp5.Value1: 1
        // csp5.Value2: 2
        // csp5.Value3: 3
        // csp5.Value4: 4
        // csp5.Value5: 5

        (int value1, long value2, int value3) = csp3;

        // value1: 1, value2: 2, value3: 3
    }

    public void Method2()
    {
        ComparableStructPack<int, int> csp1 = new(1, 2);
        ComparableStructPack<int, int> csp2 = new(1, 2);

        if (csp1 == csp2)
        {
            // true
        }
    }

    public void Method3()
    {
        ComparableStructPack<int, int> csp00 = new(0, 0);
        ComparableStructPack<int, int> csp01 = new(0, 1);
        ComparableStructPack<int, int> csp10 = new(1, 0);
        ComparableStructPack<int, int> csp11 = new(1, 1);

        if (csp00 < csp01)
        {
            // true
        }

        // csp00 < csp01 < csp10 < csp11
    }

    public void Method4()
    {
        ComparableStructPack<int, bool> csp0f = new(0, false);

        ComparableStructPack<int, bool> csp0t = new(0, true);

        ComparableStructPack<int, bool> csp1f = new(1, false);

        ComparableStructPack<int, bool> csp1t = new(1, true);

        if (csp0f < csp0t)
        {
            // true (false < true)
        }

        // csp0f < csp0t < csp1f < csp1t
    }

    // Izayoi.Data.Comparable.ComparableNullable<TValue>
    public void Method5()
    {
        // NG
        //ComparableStructPack<int, int?> csp1n = new(1, null);

        // NG
        //ComparableStructPack<int, System.Nullable<int>> csp1n = new(1, null);

        // OK
        ComparableStructPack<int, ComparableNullable<int>> csp1n = new(1, null);

        ComparableStructPack<int, ComparableNullable<int>> csp1m1 = new(1, -1);

        ComparableStructPack<int, ComparableNullable<int>> csp10 = new(1, 0);

        ComparableStructPack<int, ComparableNullable<int>> csp11 = new(1, 1);

        ComparableStructPack<int, ComparableNullable<int>> csp2n = new(2, null);

        if (csp1n < csp1m1)
        {
            // true (null < -1)
        }

        // csp1n < csp1m1 < csp10 < csp11 < csp2n
    }

    public void Method6()
    {
        ComparableStructPack<int, ComparableSample2Struct> csp123 = new(1, new(2, 3));

        ComparableStructPack<int, ComparableSample2Struct> csp124 = new(1, new(2, 4));

        if (csp123 < csp124)
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

### UncomparableStructPack

~~~csharp
using Izayoi.Data.Packs;
using System;

public class Example
{
    public void Method1()
    {
        UncomparableStructPack<int, int> usp2 = new(1, 2);

        UncomparableStructPack<int, long, int> usp3 = new(1, 2, 3);

        UncomparableStructPack<int, byte, byte, short> usp4 = new(1, 2, 3, 4);

        UncomparableStructPack<int, byte, byte, short, long> usp5 = new(1, 2, 3, 4, 5);

        // usp5.Value1: 1
        // usp5.Value2: 2
        // usp5.Value3: 3
        // usp5.Value4: 4
        // usp5.Value5: 5

        (int value1, long value2, int value3) = usp3;

        // value1: 1, value2: 2, value3: 3
    }

    public void Method2()
    {
        UncomparableStructPack<int, int> usp1 = new(1, 2);

        UncomparableStructPack<int, int> usp2 = new(1, 2);

        if (usp1 == usp2)
        {
            // true
        }
    }

    public void Method2()
    {
        UncomparableStructPack<int, UncomparableSample2Struct> usp1 = new(1, new(2, 3));

        UncomparableStructPack<int, UncomparableSample2Struct> usp2 = new(1, new(2, 3));

        if (usp1 == usp2)
        {
            // true
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
|.NET|8, 9|
|.NET Standard|2.0, 2.1|
|Unity|2021, 2022, 6000|

## Wiki

[Wiki](https://github.com/izayoijiichan/Izayoi.Data/wiki)

___
Last updated: 24 November, 2025  
Editor: Izayoi Jiichan

*Copyright (C) 2025 Izayoi Jiichan. All Rights Reserved.*
