// ----------------------------------------------------------------------
// @Namespace : Izayoi.Data.TimestampedObjects
// @Interface : IUncomparableTimestampedClass
// ----------------------------------------------------------------------
#nullable enable
namespace Izayoi.Data.TimestampedObjects
{
    using System;

    /// <summary>
    /// Generic Uncomparable Timestamped Class Interface
    /// </summary>
    public interface IUncomparableTimestampedClass<TValue> :
        ITimestamped,
        ITimestampedBase<TValue>,
        IUncomparableTimestampedBase<TValue>,
        IEquatable<IUncomparableTimestampedClass<TValue>>
        where TValue : class
    {
        #region Properties

        ///// <summary>Gets Unix timestamp milliseconds.</summary>
        //public long Timestamp { get; }

        ///// <summary>Gets the value of the current object if it has been assigned a valid underlying value.</summary>
        //TValue? Value { get; }

        #endregion

        #region Methods

        //void Deconstruct(out long timestamp, out TValue? value);

        //bool Equals(ITimestampedClass<TValue> other);

        //bool Equals(object? other);

        //int GetHashCode();

        //string? ToString();

        #endregion
    }
}
