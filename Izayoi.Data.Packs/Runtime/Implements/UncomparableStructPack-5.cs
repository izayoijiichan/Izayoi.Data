// ----------------------------------------------------------------------
// @Namespace : Izayoi.Data.Packs
// @Struct    : UncomparableStructPack<TValue1, TValue2, TValue3, TValue4, TValue5>
// ----------------------------------------------------------------------
#nullable enable
namespace Izayoi.Data.Packs
{
    using System;
    using System.Diagnostics;
    using System.Runtime.InteropServices;

    /// <summary>
    /// Uncomparable Struct Pack
    /// </summary>
    /// <typeparam name="TValue1"></typeparam>
    /// <typeparam name="TValue2"></typeparam>
    /// <typeparam name="TValue3"></typeparam>
    /// <typeparam name="TValue4"></typeparam>
    /// <typeparam name="TValue5"></typeparam>
    [DebuggerDisplay("{value1}, {value2}, {value3}, {value4}, {value5}")]
    [StructLayout(LayoutKind.Sequential)]
    public readonly struct UncomparableStructPack<TValue1, TValue2, TValue3, TValue4, TValue5> :
        IStructPack<TValue1, TValue2, TValue3, TValue4, TValue5>
        where TValue1 : struct
        where TValue2 : struct
        where TValue3 : struct
        where TValue4 : struct
        where TValue5 : struct
    {
        #region Fields

        private readonly TValue1 value1;

        private readonly TValue2 value2;

        private readonly TValue3 value3;

        private readonly TValue4 value4;

        private readonly TValue5 value5;

        #endregion

        #region Constructors

        public UncomparableStructPack(
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

        public bool Equals(UncomparableStructPack<TValue1, TValue2, TValue3, TValue4, TValue5> other)
        {
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

            if (other is UncomparableStructPack<TValue1, TValue2, TValue3, TValue4, TValue5> typedOther)
            {
                return Equals(typedOther);
            }

            return false;
        }

        #endregion

        #region Methods (GetHashCode)

        public override int GetHashCode()
        {
            return HashCode.Combine(value1, value2, value3, value4, value5);
        }

        #endregion

        #region Operators

        public static bool operator ==(
            in UncomparableStructPack<TValue1, TValue2, TValue3, TValue4, TValue5> left,
            in UncomparableStructPack<TValue1, TValue2, TValue3, TValue4, TValue5> right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(
            in UncomparableStructPack<TValue1, TValue2, TValue3, TValue4, TValue5> left,
            in UncomparableStructPack<TValue1, TValue2, TValue3, TValue4, TValue5> right)
        {
            return !left.Equals(right);
        }

        #endregion
    }
}
