// ----------------------------------------------------------------------
// @Namespace : Izayoi.Data.Packs
// @Interface : IStructPack
// ----------------------------------------------------------------------
#nullable enable
namespace Izayoi.Data.Packs
{
    public interface IStructPack
    {
        #region Methods ValueType

        //bool Equals(object? other);

        int GetHashCode();

        string? ToString();

        #endregion
    }
}
