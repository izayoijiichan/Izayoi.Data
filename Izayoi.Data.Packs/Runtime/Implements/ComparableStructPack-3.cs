// ----------------------------------------------------------------------
// @Namespace : Izayoi.Data.Packs
// @Struct    : ComparableStructPack<TValue1, TValue2, TValue3>
// ----------------------------------------------------------------------
#nullable enable
namespace Izayoi.Data.Packs
{
    using System;
    using System.Collections;
    using System.Diagnostics;
    using System.Runtime.InteropServices;

    /// <summary>
    /// Comparable Struct Pack
    /// </summary>
    /// <typeparam name="TValue1"></typeparam>
    /// <typeparam name="TValue2"></typeparam>
    /// <typeparam name="TValue3"></typeparam>
    [DebuggerDisplay("{value1}, {value2}, {value3}")]
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    public readonly struct ComparableStructPack<TValue1, TValue2, TValue3> :
        IComparableStructPack<TValue1, TValue2, TValue3>,
        IComparable<ComparableStructPack<TValue1, TValue2, TValue3>>,
        IEquatable<ComparableStructPack<TValue1, TValue2, TValue3>>
        where TValue1 : struct, IComparable<TValue1>, IEquatable<TValue1>
        where TValue2 : struct, IComparable<TValue2>, IEquatable<TValue2>
        where TValue3 : struct, IComparable<TValue3>, IEquatable<TValue3>
    {
        #region Fields

        private readonly TValue1 value1;

        private readonly TValue2 value2;

        private readonly TValue3 value3;

        #endregion

        #region Constructors

        public ComparableStructPack(
            in TValue1 value1,
            in TValue2 value2,
            in TValue3 value3)
        {
            this.value1 = value1;
            this.value2 = value2;
            this.value3 = value3;
        }

        #endregion

        #region Properties

        public readonly TValue1 Value1 => value1;

        public readonly TValue2 Value2 => value2;

        public readonly TValue3 Value3 => value3;

        #endregion

        #region Methods (CompareTo)

        public int CompareTo(ComparableStructPack<TValue1, TValue2, TValue3> other)
        {
            int compared = value1.CompareTo(other.Value1);

            if (compared != 0)
            {
                return compared;
            }

            compared = value2.CompareTo(other.Value2);

            if (compared != 0)
            {
                return compared;
            }

            compared = value3.CompareTo(other.Value3);

            return compared;
        }

        public int CompareTo(IComparableStructPack<TValue1, TValue2, TValue3>? other)
        {
            if (other is null)
            {
                return 1;  // this (not null) > other (null)
            }

            int compared = value1.CompareTo(other.Value1);

            if (compared != 0)
            {
                return compared;
            }

            compared = value2.CompareTo(other.Value2);

            if (compared != 0)
            {
                return compared;
            }

            compared = value3.CompareTo(other.Value3);

            return compared;
        }

        public int CompareTo(object? other)
        {
            if (other is null)
            {
                return 1;  // this (not null) > other (null)
            }

            if (other is ComparableStructPack<TValue1, TValue2, TValue3> typedOther)
            {
                return CompareTo(typedOther);
            }

            if (other is IComparableStructPack<TValue1, TValue2, TValue3> iTypedOther)
            {
                return CompareTo(iTypedOther);
            }

            throw new InvalidCastException();
        }

        public int CompareTo(object? other, IComparer comparer)
        {
            return comparer.Compare(this, other);
        }

        #endregion

        #region Methods (Deconstruct)

        public void Deconstruct(
            out TValue1 value1,
            out TValue2 value2)
        {
            (
                value1,
                value2
            ) = (
                this.value1,
                this.value2
            );
        }

        public void Deconstruct(
            out TValue1 value1,
            out TValue2 value2,
            out TValue3 value3)
        {
            (
                value1,
                value2,
                value3
            ) = (
                this.value1,
                this.value2,
                this.value3
            );
        }

        #endregion

        #region Methods (Equals)

        public bool Equals(ComparableStructPack<TValue1, TValue2, TValue3> other)
        {
            return value1.Equals(other.Value1)
                && value2.Equals(other.Value2)
                && value3.Equals(other.Value3);
        }

        public bool Equals(IComparableStructPack<TValue1, TValue2, TValue3>? other)
        {
            if (other is null)
            {
                return false;
            }

            return value1.Equals(other.Value1)
                && value2.Equals(other.Value2)
                && value3.Equals(other.Value3);
        }

        public override bool Equals(object? other)
        {
            if (other is null)
            {
                return false;
            }

            if (other is ComparableStructPack<TValue1, TValue2, TValue3> typedOther)
            {
                return Equals(typedOther);
            }

            if (other is IComparableStructPack<TValue1, TValue2, TValue3> iTypedOther)
            {
                return Equals(iTypedOther);
            }

            return false;
        }

        public bool Equals(object? other, IEqualityComparer comparer)
        {
            return comparer.Equals(this, other);
        }

        #endregion

        #region Methods (GetHashCode)

        public override int GetHashCode()
        {
            return HashCode.Combine(value1, value2, value3);
        }

        public int GetHashCode(IEqualityComparer comparer)
        {
            return comparer.GetHashCode(this);
        }

        #endregion

        #region Operators

        public static bool operator ==(
            in ComparableStructPack<TValue1, TValue2, TValue3> left,
            in ComparableStructPack<TValue1, TValue2, TValue3> right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(
            in ComparableStructPack<TValue1, TValue2, TValue3> left,
            in ComparableStructPack<TValue1, TValue2, TValue3> right)
        {
            return !left.Equals(right);
        }

        public static bool operator <(
            in ComparableStructPack<TValue1, TValue2, TValue3> left,
            in ComparableStructPack<TValue1, TValue2, TValue3> right)
        {
            return left.CompareTo(right) < 0;
        }

        public static bool operator <=(
            in ComparableStructPack<TValue1, TValue2, TValue3> left,
            in ComparableStructPack<TValue1, TValue2, TValue3> right)
        {
            return left.CompareTo(right) <= 0;
        }

        public static bool operator >(
            in ComparableStructPack<TValue1, TValue2, TValue3> left,
            in ComparableStructPack<TValue1, TValue2, TValue3> right)
        {
            return left.CompareTo(right) > 0;
        }

        public static bool operator >=(
            ComparableStructPack<TValue1, TValue2, TValue3> left,
            ComparableStructPack<TValue1, TValue2, TValue3> right)
        {
            return left.CompareTo(right) >= 0;
        }

        #endregion
    }
}
