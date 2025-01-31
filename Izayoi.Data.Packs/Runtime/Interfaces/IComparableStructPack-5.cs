// ----------------------------------------------------------------------
// @Namespace : Izayoi.Data.Packs
// @Interface : IComparableStructPack<TValue1, TValue2, TValue3, TValue4, TValue5>
// ----------------------------------------------------------------------
#nullable enable
namespace Izayoi.Data.Packs
{
    using System;

    public interface IComparableStructPack<TValue1, TValue2, TValue3, TValue4, TValue5> :
        IStructPack<TValue1, TValue2, TValue3, TValue4, TValue5>,
        IComparableStructPack,
        IComparable<IComparableStructPack<TValue1, TValue2, TValue3, TValue4, TValue5>>,
        IEquatable<IComparableStructPack<TValue1, TValue2, TValue3, TValue4, TValue5>>
        where TValue1 : struct, IComparable<TValue1>, IEquatable<TValue1>
        where TValue2 : struct, IComparable<TValue2>, IEquatable<TValue2>
        where TValue3 : struct, IComparable<TValue3>, IEquatable<TValue3>
        where TValue4 : struct, IComparable<TValue4>, IEquatable<TValue4>
        where TValue5 : struct, IComparable<TValue5>, IEquatable<TValue5>
    {
        #region Properties

        //TValue1 Value1 { get; }

        //TValue2 Value2 { get; }

        //TValue3 Value3 { get; }

        //TValue4 Value4 { get; }

        //TValue5 Value5 { get; }

        #endregion

        #region Methods IComparable<T>

        //int CompareTo(IComparableStructPack<TValue1, TValue2, TValue3, TValue4, TValue5> other);

        #endregion

        #region Methods IEquatable<T>

        //bool Equals(IComparableStructPack<TValue1, TValue2, TValue3, TValue4, TValue5> other);

        #endregion
    }
}
