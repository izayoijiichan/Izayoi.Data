// ----------------------------------------------------------------------
// @Namespace : Izayoi.Data.Packs
// @Interface : IEqualableStructPack
// ----------------------------------------------------------------------
#nullable enable
namespace Izayoi.Data.Packs
{
    using System.Collections;

    public interface IEqualableStructPack :
        IStructPack,
        IStructuralEquatable
    {
        #region Methods IStructPack

        //int GetHashCode();

        //string? ToString();

        #endregion

        #region Methods ValueType

        bool Equals(object? other);

        #endregion

        #region Methods IStructuralEquatable

        //bool Equals(object? other, IEqualityComparer comparer);

        //int GetHashCode(IEqualityComparer comparer);

        #endregion
    }
}
