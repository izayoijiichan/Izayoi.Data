// ----------------------------------------------------------------------
// @Namespace : Izayoi.Data.Comparable
// @Struct    : ComparableNullable<TValue>
// ----------------------------------------------------------------------
#nullable enable
namespace Izayoi.Data.Comparable
{
    using System;
    using System.Diagnostics;
    using System.Runtime.InteropServices;

    /// <summary>
    /// Represents a comparable value type that can be assigned null.
    /// </summary>
    [DebuggerDisplay("{ToDebuggerDisplay()}")]
    //[Serializable]
    [StructLayout(LayoutKind.Sequential)]
    public readonly struct ComparableNullable<TValue> :
        IComparableNullable<TValue>
        where TValue : struct, IComparable<TValue>, IEquatable<TValue>
    {
        #region Fields

        private readonly bool hasValue;

        private readonly TValue value;

        #endregion

        #region Constructors

        //public ComparableNullable()
        //{
        //    hasValue = false;

        //    value = default;
        //}

        /// <summary>
        /// Initializes an instance of the ComparableNullable&lt;TValue&gt; structure to the specified value.
        /// </summary>
        /// <param name="value"></param>
        public ComparableNullable(in TValue value)
        {
            hasValue = true;

            this.value = value;
        }

        #endregion

        #region Properties

        /// <summary>Gets a value indicating whether the current ComparableNullable&lt;TValue&gt; object has a valid value of its underlying type.</summary>
        public readonly bool HasValue => hasValue;

        //public readonly bool NotHasValue => !hasValue;

        /// <summary>Gets the value of the current ComparableNullable&lt;TValue&gt; object if it has been assigned a valid underlying value.</summary>
        public readonly TValue Value => value;

        //public readonly TValue Value => hasValue
        //    ? value
        //    : throw new InvalidOperationException();

        #endregion

        #region Methods

        /// <summary>
        /// Compares this instance to a specified ComparableNullable&lt;TValue&gt; and returns an indication of their relative values.
        /// </summary>
        /// <param name="other">A value to compare.</param>
        /// <returns>A signed number indicating the relative values of this instance and value.</returns>
        public int CompareTo(ComparableNullable<TValue> other)
        {
            if (hasValue)
            {
                if (other.hasValue)
                {
                    return value.CompareTo(other.Value);
                }

                return 1;  // this (not null) > other (null)
            }

            if (other.hasValue)
            {
                return -1;  // this (null) > other (not null)
            }

            return 0;  // this (null) == other (null)
        }

        /// <summary>
        /// Compares this instance to a specified object and returns an indication of their relative values.
        /// </summary>
        /// <param name="other">An object to compare.</param>
        /// <returns>A signed number indicating the relative values of this instance and value.</returns>
        /// <exception cref="InvalidCastException"></exception>
        public int CompareTo(object? other)
        {
            if (other is null)
            {
                return 1;  // this (not null) > other (null)
            }

            if (other is ComparableNullable<TValue> typedOther)
            {
                return CompareTo(typedOther);
            }

            throw new InvalidCastException();
        }

        /// <summary>
        /// Deconstructs this ComparableNullable&lt;TValue&gt; instance by hasValue and value.
        /// </summary>
        /// <param name="hasValue"></param>
        /// <param name="value"></param>
        public void Deconstruct(out bool hasValue, out TValue value)
        {
            (hasValue, value) = (this.hasValue, this.value);
        }

        /// <summary>
        /// Indicates whether the current ComparableNullable&lt;TValue&gt; object is equal to a specified ComparableNullable&lt;TValue&gt;.
        /// </summary>
        /// <param name="other">A value.</param>
        /// <returns>true if the other parameter is equal to the current ComparableNullable&lt;TValue&gt; object; otherwise, false.</returns>
        public bool Equals(ComparableNullable<TValue> other)
        {
            if (hasValue)
            {
                if (other.hasValue)
                {
                    return value.Equals(other.Value);
                }

                return false;
            }

            if (other.hasValue)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Indicates whether the current ComparableNullable&lt;TValue&gt; object is equal to a specified object.
        /// </summary>
        /// <param name="other">An object.</param>
        /// <returns>true if the other parameter is equal to the current ComparableNullable&lt;TValue&gt; object; otherwise, false.</returns>
        public override bool Equals(object? other)
        {
            if (other is null)
            {
                return false;
            }

            if (other is ComparableNullable<TValue> typedOther)
            {
                return Equals(typedOther);
            }

            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(hasValue, value);
        }

        /// <summary>
        /// Retrieves the value of the current ComparableNullable&lt;TValue&gt; object, or the default value of the underlying type.
        /// </summary>
        /// <returns>The value of the Value property if the HasValue property is true; otherwise, the default value of the underlying type.</returns>
        public TValue GetValueOrDefault()
        {
            return value;
        }

        /// <summary>
        /// Retrieves the value of the current ComparableNullable&lt;TValue&gt; object, or the specified default value.
        /// </summary>
        /// <param name="defaultValue">A value to return if the HasValue property is false.</param>
        /// <returns>The value of the Value property if the HasValue property is true; otherwise, the defaultValue parameter.</returns>
        public TValue GetValueOrDefault(TValue defaultValue)
        {
            return hasValue
                ? value
                : defaultValue;
        }

        public override string? ToString()
        {
            return hasValue
                ? value.ToString()
                : default;
        }

        #endregion

        #region Private Methods

        private TValue? ToDebuggerDisplay()
        {
            return hasValue
                ? value
                : default;
        }

        #endregion

        #region Operators

        public static bool operator ==(
            in ComparableNullable<TValue> left,
            in ComparableNullable<TValue> right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(
            in ComparableNullable<TValue> left,
            in ComparableNullable<TValue> right)
        {
            return !left.Equals(right);
        }

        public static bool operator <(
            in ComparableNullable<TValue> left,
            in ComparableNullable<TValue> right)
        {
            return left.CompareTo(right) < 0;
        }

        public static bool operator <=(
            in ComparableNullable<TValue> left,
            in ComparableNullable<TValue> right)
        {
            return left.CompareTo(right) <= 0;
        }

        public static bool operator >(
            in ComparableNullable<TValue> left,
            in ComparableNullable<TValue> right)
        {
            return left.CompareTo(right) > 0;
        }

        public static bool operator >=(
            in ComparableNullable<TValue> left,
            in ComparableNullable<TValue> right)
        {
            return left.CompareTo(right) >= 0;
        }

        #endregion

        #region Implicit

        public static implicit operator System.Nullable<TValue>(in ComparableNullable<TValue> comparableNullable)
        {
            return comparableNullable.HasValue
                ? new System.Nullable<TValue>(comparableNullable.Value)
                : new System.Nullable<TValue>();
        }

        public static implicit operator ComparableNullable<TValue>(in System.Nullable<TValue> nullable)
        {
            return nullable.HasValue
                ? new ComparableNullable<TValue>(nullable.Value)
                : new ComparableNullable<TValue>();
        }

        public static implicit operator ComparableNullable<TValue>(in TValue value)
        {
            return new ComparableNullable<TValue>(value);
        }

        #endregion

        #region Explicit

        public static explicit operator TValue(in ComparableNullable<TValue> comparableNullable)
        {
            return comparableNullable.Value;
        }

        #endregion
    }
}
