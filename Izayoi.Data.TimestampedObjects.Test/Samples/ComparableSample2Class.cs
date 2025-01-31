// ----------------------------------------------------------------------
// @Namespace : Izayoi.Data.TimestampedObjects.Test.Samples
// @Class     : ComparableSample2Class
// ----------------------------------------------------------------------
namespace Izayoi.Data.TimestampedObjects.Test.Samples
{
    using System;

    public class ComparableSample2Class :
        IComparable<ComparableSample2Class>,
        IEquatable<ComparableSample2Class>
    {
        public ComparableSample2Class(int value1, int value2)
        {
            Value1 = value1;
            Value2 = value2;
        }

        public int Value1 { get; set; }
        public int Value2 { get; set; }

        public int CompareTo(ComparableSample2Class? other)
        {
            if (other is null)
            {
                return 1;  // this (not null) > other (null)
            }

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

        public bool Equals(ComparableSample2Class? other)
        {
            if (other is null)
            {
                return false;
            }

            return
                Value1.Equals(other.Value1) &&
                Value2.Equals(other.Value2);
        }
    }
}