// ----------------------------------------------------------------------
// @Namespace : Izayoi.Data
// @Class     : DataType
// ----------------------------------------------------------------------
#nullable enable
namespace Izayoi.Data
{
    using System;

    /// <summary>
    /// Data Type
    /// </summary>
    public class DataType
    {
        /// <summary>string</summary>
        public static readonly Type Object = typeof(object);

        /// <summary>string</summary>
        public static readonly Type String = typeof(string);

        /// <summary>bool</summary>
        public static readonly Type Boolean = typeof(bool);

        /// <summary>char</summary>
        public static readonly Type Char = typeof(char);

        /// <summary>sbyte or Int8</summary>
        public static readonly Type SByte = typeof(sbyte);

        /// <summary>byte or UInt8</summary>
        public static readonly Type Byte = typeof(byte);

        /// <summary>short or Int16</summary>
        public static readonly Type Short = typeof(short);

        /// <summary>ushort or UInt16</summary>
        public static readonly Type UShort = typeof(ushort);

        /// <summary>int or Int32</summary>
        public static readonly Type Int = typeof(int);

        /// <summary>uint or UInt32</summary>
        public static readonly Type UInt = typeof(uint);

        /// <summary>long or Int64</summary>
        public static readonly Type Long = typeof(long);

        /// <summary>ulong or UInt64</summary>
        public static readonly Type ULong = typeof(ulong);

        /// <summary>float or Single</summary>
        public static readonly Type Float = typeof(float);

        /// <summary>double or Double</summary>
        public static readonly Type Double = typeof(double);

        /// <summary>decimal or Decimal</summary>
        public static readonly Type Decimal = typeof(decimal);

        /// <summary>DateTime</summary>
        public static readonly Type DateTime = typeof(DateTime);

        /// <summary>DateTimeOffset</summary>
        public static readonly Type DateTimeOffset = typeof(DateTimeOffset);

# if NET6_0_OR_GREATER
        /// <summary>DateOnly</summary>
        public static readonly Type DateOnly = typeof(DateOnly);

        /// <summary>TimeOnly</summary>
        public static readonly Type TimeOnly = typeof(TimeOnly);
#endif

        /// <summary>GUID</summary>
        public static readonly Type Guid = typeof(Guid);

        /// <summary>Nullable</summary>
        public static readonly Type Nullable = typeof(Nullable);

        /// <summary>Nullable&lt;&gt;</summary>
        public static readonly Type GenericNullable = typeof(Nullable<>);
    }
}
