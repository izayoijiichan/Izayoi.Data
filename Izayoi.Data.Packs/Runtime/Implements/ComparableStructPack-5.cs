// ----------------------------------------------------------------------
// @Namespace : Izayoi.Data.Packs
// @Struct    : ComparableStructPack<TValue1, TValue2, TValue3, TValue4, TValue5>
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
    /// <typeparam name="TValue4"></typeparam>
    /// <typeparam name="TValue5"></typeparam>
    [DebuggerDisplay("{value1}, {value2}, {value3}, {value4}, {value5}")]
    [StructLayout(LayoutKind.Sequential)]
    public readonly struct ComparableStructPack<TValue1, TValue2, TValue3, TValue4, TValue5> :
        IComparableStructPack<TValue1, TValue2, TValue3, TValue4, TValue5>,
        IComparable<ComparableStructPack<TValue1, TValue2, TValue3, TValue4, TValue5>>,
        IEquatable<ComparableStructPack<TValue1, TValue2, TValue3, TValue4, TValue5>>
        where TValue1 : struct, IComparable<TValue1>, IEquatable<TValue1>
        where TValue2 : struct, IComparable<TValue2>, IEquatable<TValue2>
        where TValue3 : struct, IComparable<TValue3>, IEquatable<TValue3>
        where TValue4 : struct, IComparable<TValue4>, IEquatable<TValue4>
        where TValue5 : struct, IComparable<TValue5>, IEquatable<TValue5>
    {
        #region Fields

        private readonly TValue1 value1;

        private readonly TValue2 value2;

        private readonly TValue3 value3;

        private readonly TValue4 value4;

        private readonly TValue5 value5;

        #endregion

        #region Constructors

        public ComparableStructPack(
            in TValue1 value1,
            in TValue2 value2,
            in TValue3 value3,
            in TValue4 value4,
            in TValue5 value5)
        {
            this.value1 = value1;
            this.value2 = value2;
            this.value3 = value3;
            this.value4 = value4;
            this.value5 = value5;
        }

        #endregion

        #region Properties

        public readonly TValue1 Value1 => value1;

        public readonly TValue2 Value2 => value2;

        public readonly TValue3 Value3 => value3;

        public readonly TValue4 Value4 => value4;

        public readonly TValue5 Value5 => value5;

        #endregion

        #region Methods (CompareTo)

        public int CompareTo(ComparableStructPack<TValue1, TValue2, TValue3, TValue4, TValue5> other)
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

            if (compared != 0)
            {
                return compared;
            }

            compared = value4.CompareTo(other.Value4);

            if (compared != 0)
            {
                return compared;
            }

            compared = value5.CompareTo(other.Value5);

            return compared;
        }

        public int CompareTo(IComparableStructPack<TValue1, TValue2, TValue3, TValue4, TValue5>? other)
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

            if (compared != 0)
            {
                return compared;
            }

            compared = value4.CompareTo(other.Value4);

            if (compared != 0)
            {
                return compared;
            }

            compared = value5.CompareTo(other.Value5);

            return compared;
        }

        public int CompareTo(object? other)
        {
            if (other is null)
            {
                return 1;  // this (not null) > other (null)
            }

            if (other is ComparableStructPack<TValue1, TValue2, TValue3, TValue4, TValue5> typedOther)
            {
                return CompareTo(typedOther);
            }

            if (other is IComparableStructPack<TValue1, TValue2, TValue3, TValue4, TValue5> iTypedOther)
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

        public void Deconstruct(
            out TValue1 value1,
            out TValue2 value2,
            out TValue3 value3,
            out TValue4 value4)
        {
            (
                value1,
                value2,
                value3,
                value4
            ) = (
                this.value1,
                this.value2,
                this.value3,
                this.value4
            );
        }

        public void Deconstruct(
            out TValue1 value1,
            out TValue2 value2,
            out TValue3 value3,
            out TValue4 value4,
            out TValue5 value5)
        {
            (
                value1,
                value2,
                value3,
                value4,
                value5
            ) = (
                this.value1,
                this.value2,
                this.value3,
                this.value4,
                this.value5
            );
        }

        #endregion

        #region Methods (Equals)

        public bool Equals(ComparableStructPack<TValue1, TValue2, TValue3, TValue4, TValue5> other)
        {
            return value1.Equals(other.Value1)
                && value2.Equals(other.Value2)
                && value3.Equals(other.Value3)
                && value4.Equals(other.Value4)
                && value5.Equals(other.Value5);
        }

        public bool Equals(IComparableStructPack<TValue1, TValue2, TValue3, TValue4, TValue5>? other)
        {
            if (other is null)
            {
                return false;
            }

            return value1.Equals(other.Value1)
                && value2.Equals(other.Value2)
                && value3.Equals(other.Value3)
                && value4.Equals(other.Value4)
                && value5.Equals(other.Value5);
        }

        public override bool Equals(object? other)
        {
            if (other is null)
            {
                return false;
            }

            if (other is ComparableStructPack<TValue1, TValue2, TValue3, TValue4, TValue5> typedOther)
            {
                return Equals(typedOther);
            }

            if (other is IComparableStructPack<TValue1, TValue2, TValue3, TValue4, TValue5> iTypedOther)
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
            return HashCode.Combine(value1, value2, value3, value4, value5);
        }

        public int GetHashCode(IEqualityComparer comparer)
        {
            return comparer.GetHashCode(this);
        }

        #endregion

        #region Operators

        public static bool operator ==(
            in ComparableStructPack<TValue1, TValue2, TValue3, TValue4, TValue5> left,
            in ComparableStructPack<TValue1, TValue2, TValue3, TValue4, TValue5> right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(
            in ComparableStructPack<TValue1, TValue2, TValue3, TValue4, TValue5> left,
            in ComparableStructPack<TValue1, TValue2, TValue3, TValue4, TValue5> right)
        {
            return !left.Equals(right);
        }

        public static bool operator <(
            in ComparableStructPack<TValue1, TValue2, TValue3, TValue4, TValue5> left,
            in ComparableStructPack<TValue1, TValue2, TValue3, TValue4, TValue5> right)
        {
            return left.CompareTo(right) < 0;
        }

        public static bool operator <=(
            in ComparableStructPack<TValue1, TValue2, TValue3, TValue4, TValue5> left,
            in ComparableStructPack<TValue1, TValue2, TValue3, TValue4, TValue5> right)
        {
            return left.CompareTo(right) <= 0;
        }

        public static bool operator >(
            in ComparableStructPack<TValue1, TValue2, TValue3, TValue4, TValue5> left,
            in ComparableStructPack<TValue1, TValue2, TValue3, TValue4, TValue5> right)
        {
            return left.CompareTo(right) > 0;
        }

        public static bool operator >=(
            in ComparableStructPack<TValue1, TValue2, TValue3, TValue4, TValue5> left,
            in ComparableStructPack<TValue1, TValue2, TValue3, TValue4, TValue5> right)
        {
            return left.CompareTo(right) >= 0;
        }

        #endregion
    }
}
