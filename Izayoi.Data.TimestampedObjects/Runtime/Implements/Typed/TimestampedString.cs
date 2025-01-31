// ----------------------------------------------------------------------
// @Namespace : Izayoi.Data.TimestampedObjects
// @Class     : TimestampedString
// ----------------------------------------------------------------------
#nullable enable
namespace Izayoi.Data.TimestampedObjects
{
    using System;
    using System.Diagnostics;
    using System.Runtime.InteropServices;

    /// <summary>
    /// Timestamped String
    /// </summary>
    [DebuggerDisplay("ts:{timestamp}, value:{value}")]
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    public readonly struct TimestampedString :
        ITimestamped,
        IComparableTimestampedBase<string>,
        IComparable,
        IComparable<TimestampedString>,
        IComparable<ComparableTimestampedClass<string>>,
        IEquatable<TimestampedString>,
        IEquatable<ComparableTimestampedClass<string>>
    {
        // var ts = new TimestampedString(null);
        // CS0121 - The call is ambiguous between the following methods or properties
        // TimestampedString(in string? value)
        // TimestampedString(in char[] value)
        // TimestampedString(in ReadOnlySpan<char> value)

        #region Fields

        private readonly long timestamp;

        private readonly string? value;

        #endregion

        #region Constructors

        //public TimestampedString()
        //{
        //    timestamp = 0;

        //    value = default;
        //}

        /// <summary>
        /// Initializes a new instance of the TimestampedString structure with the specified timestamp and value.
        /// </summary>
        /// <param name="timestamp">A Unix timestamp milliseconds.</param>
        /// <param name="value">A value.</param>
        public TimestampedString(in long timestamp, in string? value)
        {
            this.timestamp = timestamp;

            this.value = value;
        }

        /// <summary>
        /// Initializes a new instance of the TimestampedString structure with the specified timestamp, c and count.
        /// </summary>
        /// <param name="timestamp">A Unix timestamp milliseconds.</param>
        /// <param name="c">A Unicode character.</param>
        /// <param name="count">The number of times c occurs.</param>
        public TimestampedString(in long timestamp, in char c, in int count)
        {
            this.timestamp = timestamp;

            value = new string(c, count);
        }

        /// <summary>
        /// Initializes a new instance of the TimestampedString structure with the specified timestamp and value.
        /// </summary>
        /// <param name="timestamp">A Unix timestamp milliseconds.</param>
        /// <param name="value">An array of Unicode characters.</param>
        public TimestampedString(in long timestamp, in char[] value)
        {
            this.timestamp = timestamp;

            this.value = new string(value);
        }

        /// <summary>
        /// Initializes a new instance of the TimestampedString structure with the specified timestamp, value, startIndex and length.
        /// </summary>
        /// <param name="timestamp">A Unix timestamp milliseconds.</param>
        /// <param name="value">An array of Unicode characters.</param>
        /// <param name="startIndex">The starting position within value.</param>
        /// <param name="length">The number of characters within value to use.</param>
        public TimestampedString(in long timestamp, in char[] value, in int startIndex, in int length)
        {
            this.timestamp = timestamp;

            this.value = new string(value, startIndex, length);
        }

        /// <summary>
        /// Initializes a new instance of the TimestampedString structure with the specified value.
        /// </summary>
        /// <param name="value">A value.</param>
        public TimestampedString(in string? value)
        {
            timestamp = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();

            this.value = value;
        }

        /// <summary>
        /// Initializes a new instance of the TimestampedString structure with the specified c and count.
        /// </summary>
        /// <param name="c">A Unicode character.</param>
        /// <param name="count">The number of times c occurs.</param>
        public TimestampedString(in char c, in int count)
        {
            timestamp = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();

            value = new string(c, count);
        }

        /// <summary>
        /// Initializes a new instance of the TimestampedString structure with the specified value.
        /// </summary>
        /// <param name="value">An array of Unicode characters.</param>
        public TimestampedString(in char[] value)
        {
            timestamp = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();

            this.value = new string(value);
        }

        /// <summary>
        /// Initializes a new instance of the TimestampedString structure with the specified value, startIndex and length.
        /// </summary>
        /// <param name="value">An array of Unicode characters.</param>
        /// <param name="startIndex">The starting position within value.</param>
        /// <param name="length">The number of characters within value to use.</param>
        public TimestampedString(in char[] value, in int startIndex, in int length)
        {
            timestamp = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();

            this.value = new string(value, startIndex, length);
        }

#if NET8_0_OR_GREATER
        /// <summary>
        /// Initializes a new instance of the TimestampedString structure with the specified timestamp and value.
        /// </summary>
        /// <param name="timestamp">A Unix timestamp milliseconds.</param>
        /// <param name="value">An span of Unicode characters.</param>
        public TimestampedString(in long timestamp, in ReadOnlySpan<char> value)
        {
            this.timestamp = timestamp;

            this.value = new string(value);
        }

        /// <summary>
        /// Initializes a new instance of the TimestampedString structure with the specified value.
        /// </summary>
        /// <param name="value">An span of Unicode characters.</param>
        public TimestampedString(in ReadOnlySpan<char> value)
        {
            timestamp = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();

            this.value = new string(value);
        }
#endif

#endregion

        #region Properties

        /// <summary>Gets Unix timestamp milliseconds.</summary>
        public readonly long Timestamp => timestamp;

        /// <summary>Gets the string value of the current object.</summary>
        public readonly string? Value => value;

        #endregion

        #region Methods (CompareTo)

        // null < "" < "a"

        public int CompareTo(TimestampedString other)
        {
            int compared = timestamp.CompareTo(other.Timestamp);

            if (compared != 0)
            {
                return compared;
            }

            if (value == null)
            {
                if (other.Value == null)
                {
                    return 0;
                }

                return -1;
            }

            if (other.Value == null)
            {
                return 1;
            }

            return value.CompareTo(other.Value);
        }

        public int CompareTo(ComparableTimestampedClass<string>? other)
        {
            if (other is null)
            {
                return 1;  // this (not null) > other (null)
            }

            int compared = timestamp.CompareTo(other.Timestamp);

            if (compared != 0)
            {
                return compared;
            }

            if (value == null)
            {
                if (other.Value == null)
                {
                    return 0;
                }

                return -1;
            }

            if (other.Value == null)
            {
                return 1;
            }

            return value.CompareTo(other.Value);
        }

        public int CompareTo(object? other)
        {
            if (other is null)
            {
                return 1;  // this (not null) > other (null)
            }

            if (other is ComparableTimestampedClass<string> typedOther)
            {
                return CompareTo(typedOther);
            }

            throw new InvalidCastException();
        }

        #endregion

        #region Methods (Deconstruct)

        public void Deconstruct(out long timestamp, out string? value)
        {
            (timestamp, value) = (this.timestamp, this.value);
        }

        #endregion

        #region Methods (Equals)

        public bool Equals(TimestampedString other)
        {
            if (timestamp.Equals(other.Timestamp) == false)
            {
                return false;
            }

            if (value == null)
            {
                if (other.Value == null)
                {
                    return true;
                }

                return false;
            }

            if (other.Value == null)
            {
                return false;
            }

            return value.Equals(other.Value);
        }

        public bool Equals(ComparableTimestampedClass<string>? other)
        {
            if (other is null)
            {
                return false;
            }

            if (timestamp.Equals(other.Timestamp) == false)
            {
                return false;
            }

            if (value == null)
            {
                if (other.Value == null)
                {
                    return true;
                }

                return false;
            }

            if (other.Value == null)
            {
                return false;
            }

            return value.Equals(other.Value);
        }

        public override bool Equals(object? other)
        {
            if (other is null)
            {
                return false;
            }

            if (other is TimestampedString timestampedLong)
            {
                return Equals(timestampedLong);
            }

            if (other is ComparableTimestampedClass<string> timestampedStructureLong)
            {
                return Equals(timestampedStructureLong);
            }

            return false;
        }

        #endregion

        #region Methods (GetHashCode)

        public override int GetHashCode()
        {
            return HashCode.Combine(timestamp, value);
        }

        #endregion

        #region Operators

        public static bool operator ==(in TimestampedString left, in TimestampedString right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(in TimestampedString left, in TimestampedString right)
        {
            return !left.Equals(right);
        }

        public static bool operator <(in TimestampedString left, in TimestampedString right)
        {
            return left.CompareTo(right) < 0;
        }

        public static bool operator <=(in TimestampedString left, in TimestampedString right)
        {
            return left.CompareTo(right) <= 0;
        }

        public static bool operator >(in TimestampedString left, in TimestampedString right)
        {
            return left.CompareTo(right) > 0;
        }

        public static bool operator >=(in TimestampedString left, in TimestampedString right)
        {
            return left.CompareTo(right) >= 0;
        }

        #endregion

        #region Implicit

        public static implicit operator ComparableTimestampedClass<string>(in TimestampedString tsString)
        {
            return new ComparableTimestampedClass<string>(tsString.Timestamp, tsString.Value);
        }

        public static implicit operator TimestampedString(in ComparableTimestampedClass<string> tscString)
        {
            return new TimestampedString(tscString.Timestamp, tscString.Value);
        }

        #endregion
    }
}
