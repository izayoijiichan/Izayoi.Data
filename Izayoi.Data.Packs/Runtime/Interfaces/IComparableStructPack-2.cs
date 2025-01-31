// ----------------------------------------------------------------------
// @Namespace : Izayoi.Data.Packs
// @Interface : IComparableStructPack<TValue1, TValue2>
// ----------------------------------------------------------------------
#nullable enable
namespace Izayoi.Data.Packs
{
    using System;

    public interface IComparableStructPack<TValue1, TValue2> :
        IStructPack<TValue1, TValue2>,
        IComparableStructPack,
        IComparable<IComparableStructPack<TValue1, TValue2>>,
        IEquatable<IComparableStructPack<TValue1, TValue2>>
        where TValue1 : struct, IComparable<TValue1>, IEquatable<TValue1>
        where TValue2 : struct, IComparable<TValue2>, IEquatable<TValue2>
    {
        #region Properties

        //TValue1 Value1 { get; }

        //TValue2 Value2 { get; }

        #endregion

        #region Methods IComparable<T>

        //int CompareTo(IComparableStructPack<TValue1, TValue2> other);

        #endregion

        #region Methods IEquatable<T>

        //bool Equals(IComparableStructPack<TValue1, TValue2> other);

        #endregion
    }
}
