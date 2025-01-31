// ----------------------------------------------------------------------
// @Namespace : Izayoi.Data.Packs
// @Struct    : UncomparableStructPack<TValue1, TValue2, TValue3>
// ----------------------------------------------------------------------
#nullable enable
namespace Izayoi.Data.Packs
{
    using System;
    using System.Diagnostics;
    using System.Runtime.InteropServices;

    /// <summary>
    /// Struct Pack
    /// </summary>
    /// <typeparam name="TValue1"></typeparam>
    /// <typeparam name="TValue2"></typeparam>
    /// <typeparam name="TValue3"></typeparam>
    [DebuggerDisplay("{value1}, {value2}, {value3}")]
    [StructLayout(LayoutKind.Sequential)]
    public readonly struct UncomparableStructPack<TValue1, TValue2, TValue3> :
        IStructPack<TValue1, TValue2, TValue3>
        where TValue1 : struct
        where TValue2 : struct
        where TValue3 : struct
    {
        #region Fields

        private readonly TValue1 value1;

        private readonly TValue2 value2;

        private readonly TValue3 value3;

        #endregion

        #region Constructors

        public UncomparableStructPack(
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

        public bool Equals(UncomparableStructPack<TValue1, TValue2, TValue3> other)
        {
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

            if (other is UncomparableStructPack<TValue1, TValue2, TValue3> typedOther)
            {
                return Equals(typedOther);
            }

            return false;
        }

        #endregion

        #region Methods (GetHashCode)

        public override int GetHashCode()
        {
            return HashCode.Combine(value1, value2, value3);
        }

        #endregion

        #region Operators

        public static bool operator ==(
            in UncomparableStructPack<TValue1, TValue2, TValue3> left,
            in UncomparableStructPack<TValue1, TValue2, TValue3> right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(
            in UncomparableStructPack<TValue1, TValue2, TValue3> left,
            in UncomparableStructPack<TValue1, TValue2, TValue3> right)
        {
            return !left.Equals(right);
        }

        #endregion
    }
}
