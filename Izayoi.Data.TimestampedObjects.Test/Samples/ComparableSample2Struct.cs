// ----------------------------------------------------------------------
// @Namespace : Izayoi.Data.TimestampedObjects.Test.Samples
// @Struct    : ComparableSample2Struct
// ----------------------------------------------------------------------
namespace Izayoi.Data.TimestampedObjects.Test.Samples
{
    using System;

    public readonly struct ComparableSample2Struct :
        IComparable<ComparableSample2Struct>,
        IEquatable<ComparableSample2Struct>
    {
        #region Fields

        private readonly int value1;

        private readonly int value2;

        #endregion

        #region Constructors

        public ComparableSample2Struct(int value1, int value2)
        {
            this.value1 = value1;
            this.value2 = value2;
        }

        #endregion

        #region Properties

        public readonly int Value1 => value1;

        public readonly int Value2 => value2;

        #endregion

        #region Methods

        public int CompareTo(ComparableSample2Struct other)
        {
            //if (other is null)
            //{
            //    return 1;  // this (not null) > other (null)
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

        #endregion
    }
}