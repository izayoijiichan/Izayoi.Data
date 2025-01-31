// ----------------------------------------------------------------------
// @Namespace : Izayoi.Data.Comparable
// @Interface : IComparableNullable<TValue>
// ----------------------------------------------------------------------
#nullable enable
namespace Izayoi.Data.Comparable
{
    using System;

    /// <summary>
    /// Comparable Nullable Value Interface
    /// </summary>
    public interface IComparableNullable<TValue> :
        INullable<TValue>,
        IComparable,
        IComparable<ComparableNullable<TValue>>,
        IEquatable<ComparableNullable<TValue>>
        where TValue : struct, IComparable<TValue>, IEquatable<TValue>
    {
        #region Properties

        //bool HasValue { get; }

        //TValue Value { get; }

        #endregion

        #region Methods IComparable

        //int CompareTo(object? other);

        #endregion

        #region Methods IComparable<ComparableNullable<TValue>>

        //int CompareTo(ComparableNullable<TValue> other);

        #endregion

        #region Methods IEquatable<ComparableNullable<TValue>>

        //bool Equals(ComparableNullable<TValue> other);

        #endregion

        #region Methods ValueType

        //bool Equals(object? other);

        //int GetHashCode();

        //string ToString();

        #endregion

        #region Methods INullable

        //TValue GetValueOrDefault();

        //TValue GetValueOrDefault(TValue defaultValue);

        #endregion

        #region Methods IComparableNullable

        void Deconstruct(out bool hasValue, out TValue value);

        #endregion
    }
}
