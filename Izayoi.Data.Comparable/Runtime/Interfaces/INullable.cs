// ----------------------------------------------------------------------
// @Namespace : Izayoi.Data.Comparable
// @Interface : INullable
// ----------------------------------------------------------------------
#nullable enable
namespace Izayoi.Data.Comparable
{
    /// <summary>
    /// Nullable Value Interface
    /// </summary>
    public interface INullable<TValue>
        //where TValue : struct
    {
        #region Properties

        bool HasValue { get; }

        TValue Value { get; }

        #endregion

        #region Methods ValueType

        bool Equals(object? other);

        int GetHashCode();

        string? ToString();

        #endregion

        #region INullable

        //void Deconstruct(out bool hasValue, out TValue value);

        TValue GetValueOrDefault();

        TValue GetValueOrDefault(TValue defaultValue);

        #endregion
    }
}
