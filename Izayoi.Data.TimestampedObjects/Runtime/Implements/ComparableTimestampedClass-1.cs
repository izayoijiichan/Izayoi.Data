// ----------------------------------------------------------------------
// @Namespace : Izayoi.Data.TimestampedObjects
// @Class     : ComparableTimestampedClass
// ----------------------------------------------------------------------
#nullable enable
namespace Izayoi.Data.TimestampedObjects
{
    using System;
    using System.Diagnostics;

    /// <summary>
    /// Generic Comparable Timestamped Class
    /// </summary>
    [DebuggerDisplay("ts:{timestamp}, value:{value}")]
    public class ComparableTimestampedClass<TValue> :
        IComparableTimestampedClass<TValue>,
        IComparable<ComparableTimestampedClass<TValue>>,
        IEquatable<ComparableTimestampedClass<TValue>>
        where TValue : class, IComparable<TValue>, IEquatable<TValue>
    {
        #region Fields

        /// <summary>A Unix timestamp milliseconds.</summary>
        private readonly long timestamp;

        /// <summary>A value.</summary>
        private readonly TValue? value;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the ComparableTimestampedClass class.
        /// </summary>
        public ComparableTimestampedClass()
        {
            timestamp = 0;

            value = default;
        }

        /// <summary>
        /// Initializes a new instance of the ComparableTimestampedClass class with the specified timestamp and value.
        /// </summary>
        /// <param name="timestamp">A Unix timestamp milliseconds.</param>
        /// <param name="value">A value.</param>
        public ComparableTimestampedClass(in long timestamp, in TValue? value)
        {
            this.timestamp = timestamp;

            this.value = value;
        }

        /// <summary>
        /// Initializes a new instance of the ComparableTimestampedClass class with the specified value.
        /// </summary>
        /// <param name="value">A value.</param>
        public ComparableTimestampedClass(in TValue? value)
        {
            timestamp = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();

            this.value = value;
        }

        #endregion

        #region Properties

        /// <summary>Gets Unix timestamp milliseconds.</summary>
        public long Timestamp => timestamp;

        /// <summary>Gets the value of the current object if it has been assigned a valid underlying value.</summary>
        public TValue? Value => value;

        #endregion

        #region Methods (CompareTo)

        public int CompareTo(ComparableTimestampedClass<TValue>? other)
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

        public int CompareTo(IComparableTimestampedClass<TValue>? other)
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

            if (other is ComparableTimestampedClass<TValue> typedOther)
            {
                return CompareTo(typedOther);
            }

            if (other is IComparableTimestampedClass<TValue> iTypedOther)
            {
                return CompareTo(iTypedOther);
            }

            throw new InvalidCastException();
        }

        #endregion

        #region Methods (Deconstruct)

        public void Deconstruct(out long timestamp, out TValue? value)
        {
            (timestamp, value) = (this.timestamp, this.value);
        }

        #endregion

        #region Methods (Equals)

        public bool Equals(ComparableTimestampedClass<TValue>? other)
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

        public bool Equals(IComparableTimestampedClass<TValue>? other)
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

            if (other is ComparableTimestampedClass<TValue> typedOther)
            {
                return Equals(typedOther);
            }

            if (other is IComparableTimestampedClass<TValue> iTypedOther)
            {
                return Equals(iTypedOther);
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

        public static bool operator ==(
            in ComparableTimestampedClass<TValue> left,
            in ComparableTimestampedClass<TValue> right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(
            in ComparableTimestampedClass<TValue> left,
            in ComparableTimestampedClass<TValue> right)
        {
            return !left.Equals(right);
        }

        public static bool operator <(
            in ComparableTimestampedClass<TValue> left,
            in ComparableTimestampedClass<TValue> right)
        {
            return left.CompareTo(right) < 0;
        }

        public static bool operator <=(
            in ComparableTimestampedClass<TValue> left,
            in ComparableTimestampedClass<TValue> right)
        {
            return left.CompareTo(right) <= 0;
        }

        public static bool operator >(
            in ComparableTimestampedClass<TValue> left,
            in ComparableTimestampedClass<TValue> right)
        {
            return left.CompareTo(right) > 0;
        }

        public static bool operator >=(
            in ComparableTimestampedClass<TValue> left,
            in ComparableTimestampedClass<TValue> right)
        {
            return left.CompareTo(right) >= 0;
        }

        #endregion
    }
}
