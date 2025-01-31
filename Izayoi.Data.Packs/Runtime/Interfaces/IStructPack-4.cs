// ----------------------------------------------------------------------
// @Namespace : Izayoi.Data.Packs
// @Interface : IStructPack<TValue1, TValue2, TValue3, TValue4>
// ----------------------------------------------------------------------
#nullable enable
namespace Izayoi.Data.Packs
{
    public interface IStructPack<TValue1, TValue2, TValue3, TValue4> :
        IStructPack
        //IStructPack<TValue1, TValue2>,
        //IStructPack<TValue1, TValue2, TValue3>
        where TValue1 : struct
        where TValue2 : struct
        where TValue3 : struct
        where TValue4 : struct
    {
        #region Properties

        TValue1 Value1 { get; }

        TValue2 Value2 { get; }

        TValue3 Value3 { get; }

        TValue4 Value4 { get; }

        #endregion

        #region Methods

        void Deconstruct(out TValue1 value1, out TValue2 value2);

        void Deconstruct(out TValue1 value1, out TValue2 value2, out TValue3 value3);

        void Deconstruct(out TValue1 value1, out TValue2 value2, out TValue3 value3, out TValue4 value4);

        #endregion
    }
}
