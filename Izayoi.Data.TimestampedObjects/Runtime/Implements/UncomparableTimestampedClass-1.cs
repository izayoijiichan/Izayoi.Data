// ----------------------------------------------------------------------
// @Namespace : Izayoi.Data.TimestampedObjects
// @Clas      : UncomparableTimestampedClass
// ----------------------------------------------------------------------
#nullable enable
namespace Izayoi.Data.TimestampedObjects
{
    using System;
    using System.Diagnostics;

    /// <summary>
    /// Generic Uncomparable Timestamped Class
    /// </summary>
    [DebuggerDisplay("ts:{timestamp}, value:{value}")]
    public class UncomparableTimestampedClass<TValue> :
        IUncomparableTimestampedClass<TValue>
        where TValue : class
    {
        #region Fields

        /// <summary>A Unix timestamp milliseconds.</summary>
        private readonly long timestamp;

        /// <summary>A value.</summary>
        private readonly TValue? value;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the UncomparableTimestampedClass class.
        /// </summary>
        public UncomparableTimestampedClass()
        {
            timestamp = 0;

            value = default;
        }

        /// <summary>
        /// Initializes a new instance of the UncomparableTimestampedClass class with the specified timestamp and value.
        /// </summary>
        /// <param name="timestamp">A Unix timestamp milliseconds.</param>
        /// <param name="value">A value.</param>
        public UncomparableTimestampedClass(in long timestamp, in TValue? value)
        {
            this.timestamp = timestamp;

            this.value = value;
        }

        /// <summary>
        /// Initializes a new instance of the UncomparableTimestampedClass class with the specified value.
        /// </summary>
        /// <param name="value">A value.</param>
        public UncomparableTimestampedClass(in TValue? value)
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

        public bool Equals(in UncomparableTimestampedClass<TValue>? other)
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

        public bool Equals(IUncomparableTimestampedClass<TValue>? other)
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

            if (other is UncomparableTimestampedClass<TValue> typedOther)
            {
                return Equals(typedOther);
            }

            if (other is IUncomparableTimestampedClass<TValue> iTypedOther)
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
            in UncomparableTimestampedClass<TValue> left,
            in UncomparableTimestampedClass<TValue> right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(
            in UncomparableTimestampedClass<TValue> left,
            in UncomparableTimestampedClass<TValue> right)
        {
            return !left.Equals(right);
        }

        #endregion
    }
}
