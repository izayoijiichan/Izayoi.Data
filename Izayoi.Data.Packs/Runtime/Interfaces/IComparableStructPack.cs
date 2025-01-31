// ----------------------------------------------------------------------
// @Namespace : Izayoi.Data.Packs
// @Interface : IComparableStructPack
// ----------------------------------------------------------------------
#nullable enable
namespace Izayoi.Data.Packs
{
    using System;
    using System.Collections;

    public interface IComparableStructPack :
        IStructPack,
        IComparable,
        IStructuralComparable,
        IStructuralEquatable,
        IEqualableStructPack
    {
        #region Methods IStructPack

        //int GetHashCode();

        //string? ToString();

        #endregion

        #region Methods IComparable

        //int CompareTo(object? other);

        #endregion

        #region Methods IStructuralComparable

        //int CompareTo(object? other, IComparer comparer);

        #endregion

        #region Methods IEqualableStructPack

        //bool Equals(object? other);

        //bool Equals(object? other, IEqualityComparer comparer);

        //int GetHashCode(IEqualityComparer comparer);

        #endregion
    }
}
