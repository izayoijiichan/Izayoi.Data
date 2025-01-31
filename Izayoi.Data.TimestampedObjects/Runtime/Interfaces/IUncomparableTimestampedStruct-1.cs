// ----------------------------------------------------------------------
// @Namespace : Izayoi.Data.TimestampedObjects
// @Interface : IUncomparableTimestampedStruct
// ----------------------------------------------------------------------
#nullable enable
namespace Izayoi.Data.TimestampedObjects
{
    using System;

    /// <summary>
    /// Generic Uncomparable Timestamped Struct Interface
    /// </summary>
    public interface IUncomparableTimestampedStruct<TValue> :
        ITimestamped,
        ITimestampedBase<TValue>,
        IUncomparableTimestampedBase<TValue>,
        IEquatable<IUncomparableTimestampedStruct<TValue>>
        where TValue : struct
    {
        #region Properties

        ///// <summary>Gets Unix timestamp milliseconds.</summary>
        //long Timestamp { get; }

        ///// <summary>Gets the value of the current object if it has been assigned a valid underlying value.</summary>
        //TValue Value { get; }

        #endregion

        #region Methods

        //int CompareValue(ITimestampedStruct<TValue> other);

        //void Deconstruct(out long timestamp, out TValue value);

        //bool Equals(ITimestampedStruct<TValue> other);

        //bool Equals(object? other);

        //int GetHashCode();

        //string? ToString();

        #endregion
    }
}
