// ----------------------------------------------------------------------
// @Namespace : Izayoi.Data.TimestampedObjects
// @Interface : IComparableTimestampedStruct
// ----------------------------------------------------------------------
#nullable enable
namespace Izayoi.Data.TimestampedObjects
{
    using System;

    /// <summary>
    /// Generic Comparable Timestamped Struct Interface
    /// </summary>
    public interface IComparableTimestampedStruct<TValue> :
        ITimestamped,
        ITimestampedBase<TValue>,
        IComparableTimestampedBase<TValue>,
        IComparable,
        IComparable<IComparableTimestampedStruct<TValue>>,
        IEquatable<IComparableTimestampedStruct<TValue>>
        where TValue : struct, IComparable<TValue>, IEquatable<TValue>
    {
        #region Properties

        ///// <summary>Gets Unix timestamp milliseconds.</summary>
        //long Timestamp { get; }

        ///// <summary>Gets the value of the current object if it has been assigned a valid underlying value.</summary>
        //TValue Value { get; }

        #endregion

        #region Methods

        //int CompareTo(IComparableTimestampedStruct<TValue> other);

        //int CompareTo(object? other);

        //void Deconstruct(out long timestamp, out TValue value);

        //bool Equals(IComparableTimestampedStruct<TValue> other);

        //bool Equals(object? other);

        //int GetHashCode();

        //string? ToString();

        #endregion
    }
}
