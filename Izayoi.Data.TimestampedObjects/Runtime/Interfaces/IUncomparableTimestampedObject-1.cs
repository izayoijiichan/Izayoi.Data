// ----------------------------------------------------------------------
// @Namespace : Izayoi.Data.TimestampedObjects
// @Interface : IUncomparableTimestampedObject
// ----------------------------------------------------------------------
#nullable enable
namespace Izayoi.Data.TimestampedObjects
{
    using System;

    /// <summary>
    /// Generic Uncomparable Timestamped Object Interface
    /// </summary>
    public interface IUncomparableTimestampedObject<TValue> :
        ITimestamped,
        ITimestampedBase<TValue>,
        IUncomparableTimestampedBase<TValue>,
        IEquatable<IUncomparableTimestampedObject<TValue>>
    {
        #region Properties

        ///// <summary>Gets Unix timestamp milliseconds.</summary>
        //public long Timestamp { get; }

        ///// <summary>Gets the value of the current object if it has been assigned a valid underlying value.</summary>
        //TValue? Value { get; }

        #endregion

        #region Methods

        //void Deconstruct(out long timestamp, out TValue? value);

        //bool Equals(ITimestampedObject<TValue> other);

        //bool Equals(object? other);

        //int GetHashCode();

        //string? ToString();

        #endregion
    }
}
