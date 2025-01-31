// ----------------------------------------------------------------------
// @Namespace : Izayoi.Data.TimestampedObjects.Test.Samples
// @Class     : ComparableSample1Class
// ----------------------------------------------------------------------
namespace Izayoi.Data.TimestampedObjects.Test.Samples
{
    using System;

    public class ComparableSample1Class :
        IComparable<ComparableSample1Class>,
        IEquatable<ComparableSample1Class>
    {
        public ComparableSample1Class(int value1)
        {
            Value1 = value1;
        }

        public int Value1 { get; set; }

        public int CompareTo(ComparableSample1Class? other)
        {
            if (other is null)
            {
                return 1;  // this (not null) > other (null)
            }

            return Value1.CompareTo(other.Value1); ;
        }

        public bool Equals(ComparableSample1Class? other)
        {
            if (other is null)
            {
                return false;
            }

            return Value1.Equals(other.Value1);
        }
    }
}