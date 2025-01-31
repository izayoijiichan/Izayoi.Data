// ----------------------------------------------------------------------
// @Namespace : Izayoi.Data.TimestampedObjects
// @Class     : UncomparableTimestampedObject
// ----------------------------------------------------------------------
#nullable enable
namespace Izayoi.Data.TimestampedObjects
{
    using System;
    using System.Diagnostics;
    using System.Runtime.InteropServices;

    /// <summary>
    /// Generic Uncomparable Timestamped Object
    /// </summary>
    [DebuggerDisplay("ts:{timestamp}, value:{value}")]
    [StructLayout(LayoutKind.Sequential)]
    public class UncomparableTimestampedObject<TValue> :
        IUncomparableTimestampedObject<TValue>
    {
        #region Fields

        /// <summary>A Unix timestamp milliseconds.</summary>
        private readonly long timestamp;

        /// <summary>A value.</summary>
        private readonly TValue? value;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the UncomparableTimestampedObject class.
        /// </summary>
        public UncomparableTimestampedObject()
        {
            timestamp = 0;

            value = default;
        }

        /// <summary>
        /// Initializes a new instance of the UncomparableTimestampedObject class with the specified timestamp and value.
        /// </summary>
        /// <param name="timestamp">A Unix timestamp milliseconds.</param>
        /// <param name="value">A value.</param>
        public UncomparableTimestampedObject(in long timestamp, in TValue? value)
        {
            this.timestamp = timestamp;

            this.value = value;
        }

        /// <summary>
        /// Initializes a new instance of the UncomparableTimestampedObject class with the specified value.
        /// </summary>
        /// <param name="value">A value.</param>
        public UncomparableTimestampedObject(in TValue? value)
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

        #region Methods (Deconstruct)

        public void Deconstruct(out long timestamp, out TValue? value)
        {
            (timestamp, value) = (this.timestamp, this.value);
        }

        #endregion

        #region Methods (Equals)

        public bool Equals(in UncomparableTimestampedObject<TValue>? other)
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

        public bool Equals(IUncomparableTimestampedObject<TValue>? other)
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

            if (other is UncomparableTimestampedObject<TValue> typedOther)
            {
                return Equals(typedOther);
            }

            if (other is IUncomparableTimestampedObject<TValue> iTypedOther)
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
            in UncomparableTimestampedObject<TValue> left,
            in UncomparableTimestampedObject<TValue> right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(
            in UncomparableTimestampedObject<TValue> left,
            in UncomparableTimestampedObject<TValue> right)
        {
            return !left.Equals(right);
        }

        #endregion
    }
}
