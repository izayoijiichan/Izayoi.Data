// ----------------------------------------------------------------------
// @Namespace : Izayoi.Data.TimestampedObjects
// @Interface : ITimestampedBase
// ----------------------------------------------------------------------
#nullable enable
namespace Izayoi.Data.TimestampedObjects
{
    /// <summary>
    /// Generic Timestamped Base Interface
    /// </summary>
    public interface ITimestampedBase<TValue> : ITimestamped
    {
        #region Properties

        ///// <summary>Gets Unix timestamp milliseconds.</summary>
        //public long Timestamp { get; }

        /// <summary>Gets the value of the current object if it has been assigned a valid underlying value.</summary>
        TValue? Value { get; }

        #endregion

        #region Methods

        void Deconstruct(out long timestamp, out TValue? value);

        //bool Equals(ITimestampedBase<TValue> other);

        bool Equals(object? other);

        int GetHashCode();

        string? ToString();

        #endregion
    }
}
