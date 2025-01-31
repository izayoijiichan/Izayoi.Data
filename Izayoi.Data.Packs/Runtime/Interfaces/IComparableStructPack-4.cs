// ----------------------------------------------------------------------
// @Namespace : Izayoi.Data.Packs
// @Interface : IComparableStructPack<TValue1, TValue2, TValue3, TValue4>
// ----------------------------------------------------------------------
#nullable enable
namespace Izayoi.Data.Packs
{
    using System;

    public interface IComparableStructPack<TValue1, TValue2, TValue3, TValue4> :
        IStructPack<TValue1, TValue2, TValue3, TValue4>,
        IComparableStructPack,
        IComparable<IComparableStructPack<TValue1, TValue2, TValue3, TValue4>>,
        IEquatable<IComparableStructPack<TValue1, TValue2, TValue3, TValue4>>
        where TValue1 : struct, IComparable<TValue1>, IEquatable<TValue1>
        where TValue2 : struct, IComparable<TValue2>, IEquatable<TValue2>
        where TValue3 : struct, IComparable<TValue3>, IEquatable<TValue3>
        where TValue4 : struct, IComparable<TValue4>, IEquatable<TValue4>
    {
        #region Properties

        //TValue1 Value1 { get; }

        //TValue2 Value2 { get; }

        //TValue3 Value3 { get; }

        //TValue4 Value4 { get; }

        #endregion

        #region Methods IComparable<T>

        //int CompareTo(IComparableStructPack<TValue1, TValue2, TValue3, TValue4> other);

        #endregion

        #region Methods IEquatable<T>

        //bool Equals(IComparableStructPack<TValue1, TValue2, TValue3, TValue4> other);

        #endregion
    }
}
