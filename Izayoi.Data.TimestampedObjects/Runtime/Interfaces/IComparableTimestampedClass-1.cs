// ----------------------------------------------------------------------
// @Namespace : Izayoi.Data.TimestampedObjects
// @Interface : IComparableTimestampedClass
// ----------------------------------------------------------------------
#nullable enable
namespace Izayoi.Data.TimestampedObjects
{
    using System;

    /// <summary>
    /// Generic Comparable Timestamped Class Interface
    /// </summary>
    public interface IComparableTimestampedClass<TValue> :
        ITimestamped,
        ITimestampedBase<TValue>,
        IComparableTimestampedBase<TValue>,
        IComparable,
        IComparable<IComparableTimestampedClass<TValue>>,
        IEquatable<IComparableTimestampedClass<TValue>>
        where TValue : class, IComparable<TValue>, IEquatable<TValue>
    {
        #region Properties

        ///// <summary>Gets Unix timestamp milliseconds.</summary>
        //public long Timestamp { get; }

        ///// <summary>Gets the value of the current object if it has been assigned a valid underlying value.</summary>
        //TValue? Value { get; }

        #endregion

        #region Methods

        //int CompareTo(IComparableTimestampedClass<TValue> other);

        //public int CompareTo(object? other);

        //void Deconstruct(out long timestamp, out TValue? value);

        //bool Equals(IComparableTimestampedClass<TValue>? other);

        //bool Equals(object? other);

        //int GetHashCode();

        //string? ToString();

        #endregion
    }
}
