// ----------------------------------------------------------------------
// @Namespace : Izayoi.Data.Packs
// @Struct    : UncomparableStructPack<TValue1, TValue2>
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
    [DebuggerDisplay("{value1}, {value2}")]
    [StructLayout(LayoutKind.Sequential)]
    public readonly struct UncomparableStructPack<TValue1, TValue2> :
        IStructPack<TValue1, TValue2>
        where TValue1 : struct
        where TValue2 : struct
    {
        #region Fields

        private readonly TValue1 value1;

        private readonly TValue2 value2;

        #endregion

        #region Constructors

        public UncomparableStructPack(
            in TValue1 value1,
            in TValue2 value2)
        {
            this.value1 = value1;
            this.value2 = value2;
        }

        #endregion

        #region Properties

        public readonly TValue1 Value1 => value1;

        public readonly TValue2 Value2 => value2;

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

        #endregion

        #region Methods (Equals)

        public bool Equals(UncomparableStructPack<TValue1, TValue2> other)
        {
            return value1.Equals(other.Value1)
                && value2.Equals(other.Value2);
        }

        public override bool Equals(object? other)
        {
            if (other is null)
            {
                return false;
            }

            if (other is UncomparableStructPack<TValue1, TValue2> typedOther)
            {
                return Equals(typedOther);
            }

            return false;
        }

        #endregion

        #region Methods (GetHashCode)

        public override int GetHashCode()
        {
            return HashCode.Combine(value1, value2);
        }

        #endregion

        #region Operators

        public static bool operator ==(
            in UncomparableStructPack<TValue1, TValue2> left,
            in UncomparableStructPack<TValue1, TValue2> right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(
            in UncomparableStructPack<TValue1, TValue2> left,
            in UncomparableStructPack<TValue1, TValue2> right)
        {
            return !left.Equals(right);
        }

        #endregion
    }
}
