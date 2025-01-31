// ----------------------------------------------------------------------
// @Namespace : Izayoi.Data.TimestampedObjects.Test.Samples
// @Struct    : UncomparableSample2Struct
// ----------------------------------------------------------------------
namespace Izayoi.Data.TimestampedObjects.Test.Samples
{
    public readonly struct UncomparableSample2Struct
    {
        #region Fields

        private readonly int value1;

        private readonly int value2;

        #endregion

        #region Constructors

        public UncomparableSample2Struct(int value1, int value2)
        {
            this.value1 = value1;
            this.value2 = value2;
        }

        #endregion

        #region Properties

        public readonly int Value1 => value1;

        public readonly int Value2 => value2;

        #endregion
    }
}