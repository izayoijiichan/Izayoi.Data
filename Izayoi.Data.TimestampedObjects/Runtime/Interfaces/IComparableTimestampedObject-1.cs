// ----------------------------------------------------------------------
// @Namespace : Izayoi.Data.TimestampedObjects
// @Interface : IComparableTimestampedObject
// ----------------------------------------------------------------------
#nullable enable
namespace Izayoi.Data.TimestampedObjects
{
    using System;

    /// <summary>
    /// Generic Comparable Timestamped Object Interface
    /// </summary>
    public interface IComparableTimestampedObject<TValue> :
        ITimestamped,
        ITimestampedBase<TValue>,
        IComparableTimestampedBase<TValue>,
        IComparable,
        IComparable<IComparableTimestampedObject<TValue>>,
        IEquatable<IComparableTimestampedObject<TValue>>
        where TValue : IComparable<TValue>, IEquatable<TValue>
    {
        #region Properties

        ///// <summary>Gets Unix timestamp milliseconds.</summary>
        //public long Timestamp { get; }

        ///// <summary>Gets the value of the current object if it has been assigned a valid underlying value.</summary>
        //TValue? Value { get; }

        #endregion

        #region Methods

        //int CompareTo(IComparableTimestampedObject<TValue> other);

        //public int CompareTo(object? other);

        //void Deconstruct(out long timestamp, out TValue? value);

        //bool Equals(IComparableTimestampedObject<TValue> other);

        //bool Equals(object? other);

        //int GetHashCode();

        //string? ToString();

        #endregion
    }
}
