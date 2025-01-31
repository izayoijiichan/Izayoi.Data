// ----------------------------------------------------------------------
// @Namespace : Izayoi.Data.TimestampedObjects
// @Interface : ITimestamped
// ----------------------------------------------------------------------
#nullable enable
namespace Izayoi.Data.TimestampedObjects
{
    /// <summary>
    /// Timestamped Interface
    /// </summary>
    public interface ITimestamped
    {
        #region Properties

        /// <summary>Gets Unix timestamp milliseconds.</summary>
        long Timestamp { get; }

        #endregion
    }
}
