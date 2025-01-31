// ----------------------------------------------------------------------
// @Namespace : Izayoi.Data.TimestampedObjects
// @Struct    : UncomparableTimestampedStruct
// ----------------------------------------------------------------------
#nullable enable
namespace Izayoi.Data.TimestampedObjects
{
    using System;
    using System.Diagnostics;
    using System.Runtime.InteropServices;

    /// <summary>
    /// Generic Uncomparable Timestamped Struct
    /// </summary>
    [DebuggerDisplay("ts:{timestamp}, value:{value}")]
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    public readonly struct UncomparableTimestampedStruct<TValue> :
        IUncomparableTimestampedStruct<TValue>
        where TValue : struct
    {
        #region Fields

        /// <summary>A Unix timestamp milliseconds.</summary>
        private readonly long timestamp;

        /// <summary>A value.</summary>
        private readonly TValue value;

        #endregion

        #region Constructors

        //public UncomparableTimestampedStruct()
        //{
        //    timestamp = 0;

        //    value = default;
        //}

        /// <summary>
        /// Initializes a new instance of the UncomparableTimestampedStruct structure with the specified timestamp and value.
        /// </summary>
        /// <param name="timestamp">A Unix timestamp milliseconds.</param>
        /// <param name="value">A value.</param>
        public UncomparableTimestampedStruct(in long timestamp, in TValue value)
        {
            this.timestamp = timestamp;

            this.value = value;
        }

        /// <summary>
        /// Initializes a new instance of the UncomparableTimestampedStruct structure with the specified value.
        /// </summary>
        /// <param name="value">A value.</param>
        public UncomparableTimestampedStruct(in TValue value)
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

        #region Methods (Deconstruct)

        public void Deconstruct(out long timestamp, out TValue value)
        {
            (timestamp, value) = (this.timestamp, this.value);
        }

        #endregion

        #region Methods (Equals)

        public bool Equals(in UncomparableTimestampedStruct<TValue> other)
        {
            return
                timestamp.Equals(other.Timestamp)
                && value.Equals(other.Value);
        }

        public bool Equals(IUncomparableTimestampedStruct<TValue>? other)
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

            if (other is UncomparableTimestampedStruct<TValue> typedOther)
            {
                return Equals(typedOther);
            }

            if (other is IUncomparableTimestampedStruct<TValue> iTypedOther)
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
            in UncomparableTimestampedStruct<TValue> left,
            in UncomparableTimestampedStruct<TValue> right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(
            in UncomparableTimestampedStruct<TValue> left,
            in UncomparableTimestampedStruct<TValue> right)
        {
            return !left.Equals(right);
        }

        #endregion
    }
}
