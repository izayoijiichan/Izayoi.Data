// ----------------------------------------------------------------------
// @Namespace : Izayoi.Data.Comparable
// @Interface : IComparableEnum<TEnum>
// ----------------------------------------------------------------------
#nullable enable
namespace Izayoi.Data.Comparable
{
    using System;

    /// <summary>
    /// Comparable Nullable Enumeration Interface
    /// </summary>
    public interface IComparableEnum<TEnum> :
        INullable<TEnum>,
        IComparable,
        //IComparable<TEnum>,
        IComparable<ComparableEnum<TEnum>>,
        //IEquatable<TEnum>,
        IEquatable<ComparableEnum<TEnum>>
        where TEnum : Enum
    {
        #region Properties

        //bool HasValue { get; }

        //TEnum Value { get; }

        #endregion

        #region Methods IComparable

        //int CompareTo(object? other);

        #endregion

        #region Methods IComparable<ComparableNullable<TEnum>>

        //int CompareTo(ComparableEnum<TEnum>? other);

        #endregion

        #region Methods IEquatable<ComparableNullable<TEnum>>

        //bool Equals(ComparableEnum<TEnum>? other);

        #endregion

        #region Methods ValueType

        //bool Equals(object? other);

        //int GetHashCode();

        //string ToString();

        #endregion

        #region Methods INullable

        //TEnum GetValueOrDefault();

        //TEnum GetValueOrDefault(TEnum defaultValue);

        #endregion

        #region Methods IComparableEnum

        void Deconstruct(out bool hasValue, out TEnum value);

        #endregion
    }
}
