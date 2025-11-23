// ----------------------------------------------------------------------
// @Namespace : Izayoi.Data.Query
// @Class     : DbTypeUtility
// ----------------------------------------------------------------------
#nullable enable
namespace Izayoi.Data.Query
{
    using System;
    using System.Data;

    /// <summary>
    /// DB Type Utility
    /// </summary>
    public static class DbTypeUtility
    {
        #region Public Methods

        /// <summary>
        /// Judges the DB type of the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>The DB type of the value.</returns>
        public static DbType JudgeDbType(object value)
        {
            Type valueType = value.GetType();

            return JudgeDbType(valueType);
        }

        /// <summary>
        /// Judges the DB type of the specified type.
        /// </summary>
        /// <param name="dataType">The type of the data.</param>
        /// <returns>The DB type of the type.</returns>
        public static DbType JudgeDbType(Type dataType)
        {
            if (dataType == DataType.DBNull)
            {
                return DbType.Object;  // @notice
            }

            if (dataType.IsArray)
            {
                Type? elementType = dataType.GetElementType();

                if (elementType is null)
                {
                    return DbType.String;
                }

                return JudgeDbType(elementType);
            }

            if (dataType.IsGenericType)
            {
                if (dataType.GetGenericTypeDefinition() == typeof(Nullable<>))
                {
                    Type argumentType = dataType.GenericTypeArguments[0];

                    return JudgeDbType(argumentType);
                }
                else
                {
                    return DbType.String;
                }
            }

            if (dataType.IsEnum)
            {
                Type enumUnderlyingType = dataType.GetEnumUnderlyingType();

                return JudgeDbType(enumUnderlyingType);
            }

            DbType dbType;

            if (dataType == DataType.String)
            {
                dbType = DbType.String;
            }
            else if (dataType == DataType.Char)
            {
                dbType = DbType.UInt16;  // @notice
            }
            else if (dataType == DataType.Long)
            {
                dbType = DbType.Int64;
            }
            else if (dataType == DataType.ULong)
            {
                dbType = DbType.UInt64;
            }
            else if (dataType == DataType.Int)
            {
                dbType = DbType.Int32;
            }
            else if (dataType == DataType.UInt)
            {
                dbType = DbType.UInt32;
            }
            else if (dataType == DataType.Short)
            {
                dbType = DbType.Int16;
            }
            else if (dataType == DataType.UShort)
            {
                dbType = DbType.UInt16;
            }
            else if (dataType == DataType.SByte)
            {
                dbType = DbType.SByte;
            }
            else if (dataType == DataType.Byte)
            {
                dbType = DbType.Byte;
            }
            else if (dataType == DataType.Boolean)
            {
                dbType = DbType.Boolean;
            }
            else if (dataType == DataType.Float)
            {
                dbType = DbType.Single;
            }
            else if (dataType == DataType.Double)
            {
                dbType = DbType.Double;
            }
            else if (dataType == DataType.Decimal)
            {
                dbType = DbType.Decimal;
            }
            else if (dataType == DataType.DateTime)
            {
                dbType = DbType.DateTime;
            }
            else if (dataType == DataType.DateTimeOffset)
            {
                dbType = DbType.DateTimeOffset;
            }
#if NET6_0_OR_GREATER
            else if (dataType == DataType.DateOnly)
            {
                dbType = DbType.Date;
            }
            else if (dataType == DataType.TimeOnly)
            {
                dbType = DbType.Time;
            }
#endif
            else if (dataType == DataType.Guid)
            {
                dbType = DbType.Guid;
            }
            else
            {
                dbType = DbType.String;
            }

            return dbType;
        }

#endregion

        #region Protected Class

        /// <summary>
        /// Data Type
        /// </summary>
        protected class DataType
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

#if NET6_0_OR_GREATER
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

            /// <summary>DBNull</summary>
            public static readonly Type DBNull = typeof(DBNull);
        }

#endregion
    }
}
