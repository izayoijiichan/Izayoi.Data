// ----------------------------------------------------------------------
// @Namespace : Izayoi.Data.TimestampedObjects
// @Struct    : ComparableTimestampedStruct
// ----------------------------------------------------------------------
#nullable enable
namespace Izayoi.Data.TimestampedObjects
{
    using System;
    using System.Diagnostics;
    using System.Runtime.InteropServices;

    /// <summary>
    /// Generic Comparable Timestamped Struct
    /// </summary>
    [DebuggerDisplay("ts:{timestamp}, value:{value}")]
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    public readonly struct ComparableTimestampedStruct<TValue> :
        IComparableTimestampedStruct<TValue>,
        IComparable<ComparableTimestampedStruct<TValue>>,
        IEquatable<ComparableTimestampedStruct<TValue>>
        where TValue : struct, IComparable<TValue>, IEquatable<TValue>
    {
        #region Fields

        /// <summary>A Unix timestamp milliseconds.</summary>
        private readonly long timestamp;

        /// <summary>A value.</summary>
        private readonly TValue value;

        #endregion

        #region Constructors

        //public ComparableTimestampedStruct()
        //{
        //    timestamp = 0;

        //    value = default;
        //}

        /// <summary>
        /// Initializes a new instance of the ComparableTimestampedStruct structure with the specified timestamp and value.
        /// </summary>
        /// <param name="timestamp">A Unix timestamp milliseconds.</param>
        /// <param name="value">A value.</param>
        public ComparableTimestampedStruct(in long timestamp, in TValue value)
        {
            this.timestamp = timestamp;

            this.value = value;
        }

        /// <summary>
        /// Initializes a new instance of the ComparableTimestampedStruct structure with the specified value.
        /// </summary>
        /// <param name="value">A value.</param>
        public ComparableTimestampedStruct(in TValue value)
        {
            timestamp = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();

            this.value = value;
        }

        #endregion

        #region Properties

        /// <summary>Gets Unix timestamp milliseconds.</summary>
        public readonly long Timestamp => timestamp;

        /// <summary>Gets the value of the current object if it has been assigned a valid underlying value.</summary>
        public readonly TValue Value => value;

        #endregion

        #region Methods (CompareTo)

        public int CompareTo(ComparableTimestampedStruct<TValue> other)
        {
            int compared = timestamp.CompareTo(other.Timestamp);

            if (compared == 0)
            {
                return value.CompareTo(other.Value);
            }

            return compared;
        }

        public int CompareTo(IComparableTimestampedStruct<TValue>? other)
        {
            if (other is null)
            {
                return 1;  // this (not null) > other (null)
            }

            int compared = timestamp.CompareTo(other.Timestamp);

            if (compared == 0)
            {
                return value.CompareTo(other.Value);
            }

            return compared;
        }

        public int CompareTo(object? other)
        {
            if (other is null)
            {
                return 1;  // this (not null) > other (null)
            }

            if (other is ComparableTimestampedStruct<TValue> typedOther)
            {
                return CompareTo(typedOther);
            }

            if (other is IComparableTimestampedStruct<TValue> iTypedOther)
            {
                return CompareTo(iTypedOther);
            }

            throw new InvalidCastException();
        }

        #endregion

        #region Methods (Deconstruct)

        public void Deconstruct(out long timestamp, out TValue value)
        {
            (timestamp, value) = (this.timestamp, this.value);
        }

        #endregion

        #region Methods (Equals)

        public bool Equals(ComparableTimestampedStruct<TValue> other)
        {
            return
                timestamp.Equals(other.Timestamp)
                && value.Equals(other.Value);
        }

        public bool Equals(IComparableTimestampedStruct<TValue>? other)
        {
            if (other is null)
            {
                return false;
            }

            return
                timestamp.Equals(other.Timestamp)
                && value.Equals(other.Value);
        }

        public override bool Equals(object? other)
        {
            if (other is null)
            {
                return false;
            }

            if (other is ComparableTimestampedStruct<TValue> typedOther)
            {
                return Equals(typedOther);
            }

            if (other is IComparableTimestampedStruct<TValue> iTypedOther)
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
            in ComparableTimestampedStruct<TValue> left,
            in ComparableTimestampedStruct<TValue> right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(
            in ComparableTimestampedStruct<TValue> left,
            in ComparableTimestampedStruct<TValue> right)
        {
            return !left.Equals(right);
        }

        public static bool operator <(
            in ComparableTimestampedStruct<TValue> left,
            in ComparableTimestampedStruct<TValue> right)
        {
            return left.CompareTo(right) < 0;
        }

        public static bool operator <=(
            in ComparableTimestampedStruct<TValue> left,
            in ComparableTimestampedStruct<TValue> right)
        {
            return left.CompareTo(right) <= 0;
        }

        public static bool operator >(
            in ComparableTimestampedStruct<TValue> left,
            in ComparableTimestampedStruct<TValue> right)
        {
            return left.CompareTo(right) > 0;
        }

        public static bool operator >=(
            in ComparableTimestampedStruct<TValue> left,
            in ComparableTimestampedStruct<TValue> right)
        {
            return left.CompareTo(right) >= 0;
        }

        #endregion
    }
}
