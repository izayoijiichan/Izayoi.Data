// ----------------------------------------------------------------------
// @Namespace : Izayoi.Data.Comparable
// @Struct    : ComparableEnum<TEnum>
// ----------------------------------------------------------------------
#nullable enable
namespace Izayoi.Data.Comparable
{
    using System;
    using System.Diagnostics;

    /// <summary>
    /// Represents a comparable enumeration type that can be assigned null.
    /// </summary>
    [DebuggerDisplay("{ToDebuggerDisplay()}")]
    public class ComparableEnum<TEnum> :
        IComparableEnum<TEnum>
        where TEnum : Enum
    {
        #region Fields

        private readonly bool hasValue;

        private readonly TEnum value;

        #endregion

        #region Constructors

#pragma warning disable CS8601
#pragma warning disable CS8618
        public ComparableEnum()
        {
            hasValue = false;

            value = default;
        }
#pragma warning restore CS8618
#pragma warning restore CS8601

        /// <summary>
        /// Initializes an instance of the ComparableEnum&lt;TEnum&gt; structure to the specified value.
        /// </summary>
        /// <param name="value"></param>
        public ComparableEnum(in TEnum value)
        {
            hasValue = true;

            this.value = value;
        }

        #endregion

        #region Properties

        /// <summary>Gets a value indicating whether the current ComparableEnum&lt;TEnum&gt; object has a valid value of its underlying type.</summary>
        public bool HasValue => hasValue;

        /// <summary>Gets the value of the current ComparableEnum&lt;TEnum&gt; object if it has been assigned a valid underlying value.</summary>
        public TEnum Value => value;

        #endregion

        #region Methods

        /// <summary>
        /// Compares this instance to a specified ComparableEnum&lt;TEnum&gt; and returns an indication of their relative values.
        /// </summary>
        /// <param name="other">A value to compare.</param>
        /// <returns>A signed number indicating the relative values of this instance and value.</returns>
        public int CompareTo(ComparableEnum<TEnum>? other)
        {
            if (other is null)
            {
                return 1;  // this (not null) > other (null)
            }

            if (hasValue)
            {
                if (other.hasValue)
                {
                    return CompareTo(other.Value);
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
        /// Compares this instance to a specified TEnum and returns an indication of their relative values.
        /// </summary>
        /// <param name="other">A value to compare.</param>
        /// <returns>A signed number indicating the relative values of this instance and value.</returns>
        private int CompareTo(TEnum other)
        {
            if (value is int intValue)
            {
                if (other is int intOtherValue)
                {
                    return intValue.CompareTo(intOtherValue);
                }
            }
            else if (value is uint uintValue)
            {
                if (other is uint otherValue)
                {
                    return uintValue.CompareTo(otherValue);
                }
            }
            else if (value is sbyte sbyteValue)
            {
                if (other is sbyte otherValue)
                {
                    return sbyteValue.CompareTo(otherValue);
                }
            }
            else if (value is byte byteValue)
            {
                if (other is byte otherValue)
                {
                    return byteValue.CompareTo(otherValue);
                }
            }
            else if (value is short shortValue)
            {
                if (other is short otherValue)
                {
                    return shortValue.CompareTo(otherValue);
                }
            }
            else if (value is ushort ushortValue)
            {
                if (other is ushort otherValue)
                {
                    return ushortValue.CompareTo(otherValue);
                }
            }
            else if (value is long longValue)
            {
                if (other is long otherValue)
                {
                    return longValue.CompareTo(otherValue);
                }
            }
            else if (value is ulong ulongValue)
            {
                if (other is ulong otherValue)
                {
                    return ulongValue.CompareTo(otherValue);
                }
            }

            return value.CompareTo(other);
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

            if (other is ComparableEnum<TEnum> typedOther)
            {
                return CompareTo(typedOther);
            }

            if (other is TEnum enumOther)
            {
                return CompareTo(enumOther);
            }

            throw new InvalidCastException();
        }

        /// <summary>
        /// Deconstructs this ComparableEnum&lt;TEnum&gt; instance by hasValue and value.
        /// </summary>
        /// <param name="hasValue"></param>
        /// <param name="value"></param>
        public void Deconstruct(out bool hasValue, out TEnum value)
        {
            (hasValue, value) = (this.hasValue, this.value);
        }

        /// <summary>
        /// Indicates whether the current ComparableEnum&lt;TEnum&gt; object is equal to a specified ComparableEnum&lt;TEnum&gt;.
        /// </summary>
        /// <param name="other">A value.</param>
        /// <returns>true if the other parameter is equal to the current ComparableEnum&lt;TEnum&gt; object; otherwise, false.</returns>
        public bool Equals(ComparableEnum<TEnum>? other)
        {
            if (other is null)
            {
                return false;
            }

            if (hasValue)
            {
                if (other.hasValue)
                {
                    return Equals(other.Value);
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
        /// Indicates whether the current ComparableEnum&lt;TEnum&gt; object is equal to a specified TEnum.
        /// </summary>
        /// <param name="other">A value.</param>
        /// <returns>true if the other parameter is equal to the current ComparableEnum&lt;TEnum&gt; object; otherwise, false.</returns>
        private bool Equals(TEnum other)
        {
            if (value is int intValue)
            {
                if (other is int intOtherValue)
                {
                    return intValue.Equals(intOtherValue);
                }
            }
            else if (value is uint uintValue)
            {
                if (other is uint otherValue)
                {
                    return uintValue.Equals(otherValue);
                }
            }
            else if (value is sbyte sbyteValue)
            {
                if (other is sbyte otherValue)
                {
                    return sbyteValue.Equals(otherValue);
                }
            }
            else if (value is byte byteValue)
            {
                if (other is byte otherValue)
                {
                    return byteValue.Equals(otherValue);
                }
            }
            else if (value is short shortValue)
            {
                if (other is short otherValue)
                {
                    return shortValue.Equals(otherValue);
                }
            }
            else if (value is ushort ushortValue)
            {
                if (other is ushort otherValue)
                {
                    return ushortValue.Equals(otherValue);
                }
            }
            else if (value is long longValue)
            {
                if (other is long otherValue)
                {
                    return longValue.Equals(otherValue);
                }
            }
            else if (value is ulong ulongValue)
            {
                if (other is ulong otherValue)
                {
                    return ulongValue.Equals(otherValue);
                }
            }

            return value.Equals(other);
        }

        /// <summary>
        /// Indicates whether the current ComparableEnum&lt;TEnum&gt; object is equal to a specified object.
        /// </summary>
        /// <param name="other">An object.</param>
        /// <returns>true if the other parameter is equal to the current ComparableEnum&lt;TEnum&gt; object; otherwise, false.</returns>
        public override bool Equals(object? other)
        {
            if (other is null)
            {
                return false;
            }

            if (other is ComparableEnum<TEnum> typedOther)
            {
                return Equals(typedOther);
            }

            if (other is TEnum enumOther)
            {
                return Equals(enumOther);
            }

            return false;
        }

        //public Type GetType()
        //{
        //    return value.GetType();
        //}

        public TypeCode GetTypeCode()
        {
            return hasValue
                ? TypeCode.Empty
                : value.GetTypeCode();
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(hasValue, value);
        }

        /// <summary>
        /// Retrieves the value of the current ComparableEnum&lt;TEnum&gt; object, or the default value of the underlying type.
        /// </summary>
        /// <returns>The value of the Value property if the HasValue property is true; otherwise, the default value of the underlying type.</returns>
        public TEnum GetValueOrDefault()
        {
            return value;
        }

        /// <summary>
        /// Retrieves the value of the current ComparableEnum&lt;TEnum&gt; object, or the specified default value.
        /// </summary>
        /// <param name="defaulTEnum">A value to return if the HasValue property is false.</param>
        /// <returns>The value of the Value property if the HasValue property is true; otherwise, the defaulTEnum parameter.</returns>
        public TEnum GetValueOrDefault(TEnum defaultEnum)
        {
            return hasValue
                ? value
                : defaultEnum;
        }

        public bool HasFlag(TEnum flag)
        {
            return value.HasFlag(flag);
        }

        public override string ToString()
        {
            return hasValue
                ? value.ToString()
                : $"({value})";
        }

        #endregion

        #region Private Methods

        private string ToDebuggerDisplay()
        {
            return hasValue
                ? value.ToString()
                : string.Empty;
        }

        #endregion

        #region Operators

        public static bool operator ==(
            in ComparableEnum<TEnum> left,
            in ComparableEnum<TEnum> right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(
            in ComparableEnum<TEnum> left,
            in ComparableEnum<TEnum> right)
        {
            return !left.Equals(right);
        }

        public static bool operator <(
            in ComparableEnum<TEnum> left,
            in ComparableEnum<TEnum> right)
        {
            return left.CompareTo(right) < 0;
        }

        public static bool operator <=(
            in ComparableEnum<TEnum> left,
            in ComparableEnum<TEnum> right)
        {
            return left.CompareTo(right) <= 0;
        }

        public static bool operator >(
            in ComparableEnum<TEnum> left,
            in ComparableEnum<TEnum> right)
        {
            return left.CompareTo(right) > 0;
        }

        public static bool operator >=(
            in ComparableEnum<TEnum> left,
            in ComparableEnum<TEnum> right)
        {
            return left.CompareTo(right) >= 0;
        }

        #endregion

        #region Implicit

        public static implicit operator ComparableEnum<TEnum>(in TEnum value)
        {
            return new ComparableEnum<TEnum>(value);
        }

        #endregion

        #region Explicit

        public static explicit operator TEnum(in ComparableEnum<TEnum> comparableNullableEnum)
        {
            return comparableNullableEnum.HasValue
                ? comparableNullableEnum.Value
                : throw new InvalidCastException();
        }

        #endregion
    }
}
