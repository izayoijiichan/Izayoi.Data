// ----------------------------------------------------------------------
// @Namespace : Izayoi.Data.Packs
// @Interface : IStructPack<TValue1, TValue2>
// ----------------------------------------------------------------------
#nullable enable
namespace Izayoi.Data.Packs
{
    public interface IStructPack<TValue1, TValue2> :
        IStructPack
        where TValue1 : struct
        where TValue2 : struct
    {
        #region Properties

        TValue1 Value1 { get; }

        TValue2 Value2 { get; }

        #endregion

        #region Methods

        void Deconstruct(out TValue1 value1, out TValue2 value2);

        #endregion
    }
}
