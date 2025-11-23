// ----------------------------------------------------------------------
// @Namespace : Izayoi.Data
// @Class     : DbDataMapper
// ----------------------------------------------------------------------
#nullable enable
namespace Izayoi.Data
{
    //using Microsoft.Extensions.Logging;
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data;
    using System.Data.Common;
    using System.Reflection;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// DB Data Mapper
    /// </summary>
    public class DbDataMapper : IDbDataMapper
    {
        #region Fields

        /// <summary>A DB data mapper option.</summary>
        protected readonly DbDataMapperOption _option;

        /// <summary>A dictionary that caches object mapper.</summary>
        /// <remarks>key: type, value: [ key: PropertyName (ColumnName), value: PropertyInfo ]</remarks>
        protected readonly ConcurrentDictionary<Type, PropertyMapper> _objectMapperCache;

        /// <summary>A dictionary that caches schema and table names.</summary>
        /// <remarks>key: type, value: TableAttribute</remarks>
        protected readonly ConcurrentDictionary<Type, SchemaAndTable> _tableAndSchemaNameCache;

        ///// <summary>A logger.</summary>
        //protected readonly ILogger? _logger;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the DbDataMapper class.
        /// </summary>
        public DbDataMapper()
            : this(new DbDataMapperOption()) { }

        /// <summary>
        /// Initializes a new instance of the DbDataMapper class with the specified option.
        /// </summary>
        /// <param name="option">A DB data mapper option.</param>
        public DbDataMapper(DbDataMapperOption option)
        {
            _option = option;

            _objectMapperCache = new();

            _tableAndSchemaNameCache = new();
        }

        ///// <summary>
        ///// Initializes a new instance of the DbDataMapper class with the specified logger and option.
        ///// </summary>
        ///// <param name="logger">A logger.</param>
        ///// <param name="option"> A DB data mapper option.</param>
        //public DbDataMapper(ILogger<DbDataMapper> logger, DbDataMapperOption option)
        //    : this(option)
        //{
        //    _logger = logger;
        //}

        ///// <summary>
        ///// Initializes a new instance of the DbDataMapper class with the specified loggerFactory and option.
        ///// </summary>
        ///// <param name="loggerFactory">A logger factory.</param>
        ///// <param name="option"> A DB data mapper option.</param>
        //public DbDataMapper(ILoggerFactory loggerFactory, DbDataMapperOption option)
        //    : this(option)
        //{
        //    _logger = loggerFactory.CreateLogger<DbDataMapper>();
        //}

        #endregion

        #region Properties

        /// <summary>Gets the DB data mapper option.</summary>
        public DbDataMapperOption Option => _option;

        #endregion

        #region Public ColumnNameMapper Methods

        /// <summary>
        /// Gets the column name mapper of the specified object type.
        /// </summary>
        /// <param name="objectType">The object type for which you want to get the column name mapper.</param>
        /// <returns>The column name mapper of the specified object type.</returns>
        public virtual PropertyMapper GetColumnNameMapper(Type objectType)
        {
            if (_objectMapperCache.TryGetValue(objectType, out var columnNameMapper) == false)
            {
                columnNameMapper = PropertyMapper.CreateColumnNameMapper(objectType);

                _objectMapperCache.TryAdd(objectType, columnNameMapper);
            }

            return columnNameMapper;
        }

        #endregion

        #region Public TableName Methods

        /// <summary>
        /// Gets the schema and table name of the specified object type.
        /// </summary>
        /// <param name="objectType">The object type for which you want to get the table name.</param>
        /// <returns>
        /// The schema name of the specified object type.
        /// The table name of the specified object type.
        /// </returns>
        public virtual (string schemaName, string tableName) GetSchemaAndTable(Type objectType)
        {
            if (_tableAndSchemaNameCache.TryGetValue(objectType, out var schemaAndTable) == false)
            {
                TableAttribute? tableAttribute = objectType.GetCustomAttribute<TableAttribute>();

                string schemaName;
                string tableName;

                if (tableAttribute is null)
                {
                    schemaName = string.Empty;
                    tableName = objectType.Name;
                }
                else
                {
                    schemaName = tableAttribute.Schema ?? string.Empty;
                    tableName = tableAttribute.Name;
                }

                schemaAndTable = new SchemaAndTable(schemaName, tableName);

                _tableAndSchemaNameCache.TryAdd(objectType, schemaAndTable);
            }

            return (schemaAndTable.SchemaName, schemaAndTable.TableName);
        }

        /// <summary>
        /// Gets the schema name of the specified object type.
        /// </summary>
        /// <param name="objectType">The object type for which you want to get the table name.</param>
        /// <returns>The schema name of the specified object type.</returns>
        public virtual string GetSchemaName(Type objectType)
        {
            if (_tableAndSchemaNameCache.TryGetValue(objectType, out var schemaAndTable) == false)
            {
                TableAttribute? tableAttribute = objectType.GetCustomAttribute<TableAttribute>();

                string schemaName;
                string tableName;

                if (tableAttribute is null)
                {
                    schemaName = string.Empty;
                    tableName = objectType.Name;
                }
                else
                {
                    schemaName = tableAttribute.Schema ?? string.Empty;
                    tableName = tableAttribute.Name;
                }

                schemaAndTable = new SchemaAndTable(schemaName, tableName);

                _tableAndSchemaNameCache.TryAdd(objectType, schemaAndTable);
            }

            return schemaAndTable.SchemaName;
        }

        /// <summary>
        /// Gets the table name of the specified object type.
        /// </summary>
        /// <param name="objectType">The object type for which you want to get the table name.</param>
        /// <returns>The table name of the specified object type.</returns>
        public virtual string GetTableName(Type objectType)
        {
            if (_tableAndSchemaNameCache.TryGetValue(objectType, out var schemaAndTable) == false)
            {
                TableAttribute? tableAttribute = objectType.GetCustomAttribute<TableAttribute>();

                string schemaName;
                string tableName;

                if (tableAttribute is null)
                {
                    schemaName = string.Empty;
                    tableName = objectType.Name;
                }
                else
                {
                    schemaName = tableAttribute.Schema ?? string.Empty;
                    tableName = tableAttribute.Name;
                }

                schemaAndTable = new SchemaAndTable(schemaName, tableName);

                _tableAndSchemaNameCache.TryAdd(objectType, schemaAndTable);
            }

            return schemaAndTable.TableName;
        }

        /// <summary>
        /// Sets the table name for the specified object type in the cache.
        /// </summary>
        /// <param name="objectType">The object type for which you want to set the table name.</param>
        /// <param name="tableName">The name of the table to be set.</param>
        public virtual void SetTableName(Type objectType, string tableName)
        {
            if (_tableAndSchemaNameCache.TryGetValue(objectType, out var cache))
            {
                if (cache.TableName != tableName)
                {
                    cache.TableName = tableName;
                }
            }
            else
            {
                _tableAndSchemaNameCache.TryAdd(objectType, new SchemaAndTable(string.Empty, tableName));
            }
        }

        /// <summary>
        /// Sets the table and schema name for the specified object type in the cache.
        /// </summary>
        /// <param name="objectType">The object type for which you want to set the table name.</param>
        /// <param name="tableName">The name of the table to be set.</param>
        /// <param name="schemaName">The name of the schema to be set.</param>
        public virtual void SetTableAndSchema(Type objectType, string tableName, string schemaName)
        {
            if (_tableAndSchemaNameCache.TryGetValue(objectType, out var cache))
            {
                if (cache.SchemaName != schemaName)
                {
                    cache.SchemaName = schemaName;
                }

                if (cache.TableName != tableName)
                {
                    cache.TableName = tableName;
                }
            }
            else
            {
                _tableAndSchemaNameCache.TryAdd(objectType, new SchemaAndTable(schemaName, tableName));
            }
        }

        #endregion

        #region Public Read Methods

        /// <summary>
        /// Gets the first record from the DB data reader's record set, sets the values ​​for the specified T class, and returns it.
        /// </summary>
        /// <typeparam name="T">The class you want to convert the record to.</typeparam>
        /// <param name="dbDataReader">A DB data reader resulting from executing a DB command.</param>
        /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
        /// <returns>The first record converted from the DB reader's record set into T class.</returns>
        public virtual async Task<T?> ReadToObjectAsync<T>(DbDataReader dbDataReader, CancellationToken cancellationToken)
        {
            List<T> objectList = await ReadToObjectsInnerAsync<T>(dbDataReader, firstRecordOnly: true, cancellationToken);

            return objectList.Count == 0 ? default : objectList[0];
        }

        /// <summary>
        /// Gets the records from the DB data reader's record set, sets the values ​​for the specified T class, and returns it.
        /// </summary>
        /// <typeparam name="T">The class you want to convert the record to.</typeparam>
        /// <param name="dbDataReader">A DB data reader resulting from executing a DB command.</param>
        /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
        /// <returns>A list of records converted from the DB reader's record set into T class.</returns>
        public virtual async Task<List<T>> ReadToObjectsAsync<T>(DbDataReader dbDataReader, CancellationToken cancellationToken)
        {
            return await ReadToObjectsInnerAsync<T>(dbDataReader, firstRecordOnly: false, cancellationToken);
        }

        #endregion

        #region Protected Read Methods

        /// <summary>
        /// Gets the records from the DB data reader's record set, sets the values ​​for the specified T class, and returns it.
        /// </summary>
        /// <typeparam name="T">The class you want to convert the record to.</typeparam>
        /// <param name="dbDataReader">A DB data reader resulting from executing a DB command.</param>
        /// <param name="firstRecordOnly">If true, only the first record will be retrieved.</param>
        /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
        /// <returns>A list of records converted from the DB reader's record set into T class.</returns>
        protected virtual async Task<List<T>> ReadToObjectsInnerAsync<T>(DbDataReader dbDataReader, bool firstRecordOnly, CancellationToken cancellationToken)
        {
            Type objectType = typeof(T);

            PropertyMapper columnNameMapper = GetColumnNameMapper(objectType);

            if (dbDataReader.HasRows == false)
            {
                return new();
            }

            var objectList = new List<T>();

            int rowIndex = 0;

            while (await dbDataReader.ReadAsync(cancellationToken))
            {
                T typedObject = Activator.CreateInstance<T>();

                for (int columnIndex = 0; columnIndex < dbDataReader.FieldCount; columnIndex++)
                {
                    string columnName = dbDataReader.GetName(columnIndex);

                    if (columnNameMapper.TryGetValue(columnName, out var propertyInfo))
                    {
                        await SetPropertyValueAsync(typedObject, propertyInfo, dbDataReader, rowIndex, columnIndex, cancellationToken);
                    }

                    cancellationToken.ThrowIfCancellationRequested();
                }

                objectList.Add(typedObject);

                if (firstRecordOnly)
                {
                    return objectList;
                }

                cancellationToken.ThrowIfCancellationRequested();

                rowIndex++;
            }

            return objectList;
        }

        #endregion

        #region Protected SetValue Methods

        /// <summary>
        /// Sets the value of the record retrieved from the DB data reader to the specified typedObject.
        /// </summary>
        /// <typeparam name="T">The type of the object.</typeparam>
        /// <param name="typedObject">The object whose value you want to set.</param>
        /// <param name="propertyInfo">The Property information for the current column.</param>
        /// <param name="dbDataReader">A DB data reader resulting from executing a DB command.</param>
        /// <param name="rowIndex">The current row index.</param>
        /// <param name="columnIndex">The current column index.</param>
        /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        protected virtual async Task SetPropertyValueAsync<T>(
            T typedObject,
            MapperPropertyInfo propertyInfo,
            DbDataReader dbDataReader,
            int rowIndex,
            int columnIndex,
            CancellationToken cancellationToken)
        {
            Type? dbDataType = null;

            Type? propertyType = null;

            try
            {
                if (propertyInfo.IsNotMapped)
                {
                    return;
                }

                if (propertyInfo.CanWrite == false)
                {
                    return;
                }

                if (await dbDataReader.IsDBNullAsync(columnIndex, cancellationToken))
                {
                    return;
                }

                if (TryGetPropertyType(propertyInfo, out propertyType) == false)
                {
                    return;
                }

                dbDataType = dbDataReader.GetFieldType(columnIndex);

                if (propertyType == DataType.String)
                {
                    if (dbDataType == DataType.String)
                    {
                        string value = await dbDataReader.GetFieldValueAsync<string>(columnIndex, cancellationToken);

                        propertyInfo.SetValue(typedObject, value);

                        return;
                    }
                }
                else if (propertyType == DataType.Double)
                {
                    double value;

                    if (dbDataType == DataType.Double)
                    {
                        value = await dbDataReader.GetFieldValueAsync<double>(columnIndex, cancellationToken);
                    }
                    else if (dbDataType == DataType.Float)
                    {
                        value = await dbDataReader.GetFieldValueAsync<float>(columnIndex, cancellationToken);
                    }
                    else if (dbDataType == DataType.Decimal)
                    {
                        decimal dec = await dbDataReader.GetFieldValueAsync<decimal>(columnIndex, cancellationToken);

                        value = Convert.ToDouble(dec);
                    }
                    else
                    {
                        object objValue = dbDataReader.GetValue(columnIndex);

                        value = Convert.ToDouble(objValue);
                    }

                    propertyInfo.SetValue(typedObject, value);

                    return;
                }
                else if (propertyType == DataType.Float)
                {
                    float value;

                    if (dbDataType == DataType.Float)
                    {
                        value = await dbDataReader.GetFieldValueAsync<float>(columnIndex, cancellationToken);
                    }
                    else if (dbDataType == DataType.Double)
                    {
                        double dbl = await dbDataReader.GetFieldValueAsync<double>(columnIndex, cancellationToken);

                        value = Convert.ToSingle(dbl);
                    }
                    else if (dbDataType == DataType.Decimal)
                    {
                        decimal dec = await dbDataReader.GetFieldValueAsync<decimal>(columnIndex, cancellationToken);

                        value = Convert.ToSingle(dec);
                    }
                    else
                    {
                        object objValue = dbDataReader.GetValue(columnIndex);

                        value = Convert.ToSingle(objValue);
                    }

                    propertyInfo.SetValue(typedObject, value);

                    return;
                }
                else if (propertyType == DataType.Decimal)
                {
                    decimal value;

                    if (dbDataType == DataType.Decimal)
                    {
                        value = await dbDataReader.GetFieldValueAsync<decimal>(columnIndex, cancellationToken);
                    }
                    else if (dbDataType == DataType.Double)
                    {
                        value = Convert.ToDecimal(await dbDataReader.GetFieldValueAsync<double>(columnIndex, cancellationToken));
                    }
                    else if (dbDataType == DataType.Float)
                    {
                        value = Convert.ToDecimal(await dbDataReader.GetFieldValueAsync<float>(columnIndex, cancellationToken));
                    }
                    else
                    {
                        value = Convert.ToDecimal(dbDataReader.GetValue(columnIndex));
                    }

                    propertyInfo.SetValue(typedObject, value);

                    return;
                }
                else if (propertyType == DataType.Long)
                {
                    long value = await dbDataReader.GetFieldValueAsync<long>(columnIndex, cancellationToken);

                    propertyInfo.SetValue(typedObject, value);

                    return;
                }
                else if (propertyType == DataType.ULong)
                {
                    ulong value = await dbDataReader.GetFieldValueAsync<ulong>(columnIndex, cancellationToken);

                    propertyInfo.SetValue(typedObject, value);

                    return;
                }
                else if (propertyType == DataType.Int)
                {
                    int value;

                    if (dbDataType == DataType.Int)
                    {
                        value = await dbDataReader.GetFieldValueAsync<int>(columnIndex, cancellationToken);
                    }
                    else if (dbDataType == DataType.UInt)
                    {
                        value = Convert.ToInt32(await dbDataReader.GetFieldValueAsync<uint>(columnIndex, cancellationToken));
                    }
                    else if (dbDataType == DataType.Long)
                    {
                        value = Convert.ToInt32(await dbDataReader.GetFieldValueAsync<long>(columnIndex, cancellationToken));
                    }
                    else if (dbDataType == DataType.ULong)
                    {
                        value = Convert.ToInt32(await dbDataReader.GetFieldValueAsync<ulong>(columnIndex, cancellationToken));
                    }
                    else
                    {
                        value = Convert.ToInt32(dbDataReader.GetValue(columnIndex));
                    }

                    if (propertyInfo.IsNullable && propertyInfo.IsEnum && propertyInfo.EnumType is not null)
                    {
                        if (Enum.TryParse(propertyInfo.EnumType, value.ToString(), out var enumValue))
                        {
                            propertyInfo.SetValue(typedObject, enumValue);
                        }
                    }
                    else
                    {
                        propertyInfo.SetValue(typedObject, value);
                    }

                    return;
                }
                else if (propertyType == DataType.UInt)
                {
                    uint value;

                    if (dbDataType == DataType.UInt)
                    {
                        value = await dbDataReader.GetFieldValueAsync<uint>(columnIndex, cancellationToken);
                    }
                    else if (dbDataType == DataType.Int)
                    {
                        value = Convert.ToUInt32(await dbDataReader.GetFieldValueAsync<int>(columnIndex, cancellationToken));
                    }
                    else if (dbDataType == DataType.ULong)
                    {
                        value = Convert.ToUInt32(await dbDataReader.GetFieldValueAsync<ulong>(columnIndex, cancellationToken));
                    }
                    else if (dbDataType == DataType.Long)
                    {
                        value = Convert.ToUInt32(await dbDataReader.GetFieldValueAsync<long>(columnIndex, cancellationToken));
                    }
                    else
                    {
                        value = Convert.ToUInt32(dbDataReader.GetValue(columnIndex));
                    }

                    if (propertyInfo.IsNullable && propertyInfo.IsEnum && propertyInfo.EnumType is not null)
                    {
                        if (Enum.TryParse(propertyInfo.EnumType, value.ToString(), out var enumValue))
                        {
                            propertyInfo.SetValue(typedObject, enumValue);
                        }
                    }
                    else
                    {
                        propertyInfo.SetValue(typedObject, value);
                    }

                    return;
                }
                else if (propertyType == DataType.Short)
                {
                    short value;

                    if (dbDataType == DataType.Short)
                    {
                        value = await dbDataReader.GetFieldValueAsync<short>(columnIndex, cancellationToken);
                    }
                    else if (dbDataType == DataType.UShort)
                    {
                        value = Convert.ToInt16(await dbDataReader.GetFieldValueAsync<ushort>(columnIndex, cancellationToken));
                    }
                    else if (dbDataType == DataType.Int)
                    {
                        value = Convert.ToInt16(await dbDataReader.GetFieldValueAsync<int>(columnIndex, cancellationToken));
                    }
                    else if (dbDataType == DataType.UInt)
                    {
                        value = Convert.ToInt16(await dbDataReader.GetFieldValueAsync<uint>(columnIndex, cancellationToken));
                    }
                    else if (dbDataType == DataType.Long)
                    {
                        value = Convert.ToInt16(await dbDataReader.GetFieldValueAsync<long>(columnIndex, cancellationToken));
                    }
                    else if (dbDataType == DataType.ULong)
                    {
                        value = Convert.ToInt16(await dbDataReader.GetFieldValueAsync<ulong>(columnIndex, cancellationToken));
                    }
                    else
                    {
                        value = Convert.ToInt16(dbDataReader.GetValue(columnIndex));
                    }

                    if (propertyInfo.IsNullable && propertyInfo.IsEnum && propertyInfo.EnumType is not null)
                    {
                        if (Enum.TryParse(propertyInfo.EnumType, value.ToString(), out var enumValue))
                        {
                            propertyInfo.SetValue(typedObject, enumValue);
                        }
                    }
                    else
                    {
                        propertyInfo.SetValue(typedObject, value);
                    }

                    return;
                }
                else if (propertyType == DataType.UShort)
                {
                    ushort value;

                    if (dbDataType == DataType.UShort)
                    {
                        value = await dbDataReader.GetFieldValueAsync<ushort>(columnIndex, cancellationToken);
                    }
                    else if (dbDataType == DataType.Short)
                    {
                        value = Convert.ToUInt16(await dbDataReader.GetFieldValueAsync<short>(columnIndex, cancellationToken));
                    }
                    else if (dbDataType == DataType.UInt)
                    {
                        value = Convert.ToUInt16(await dbDataReader.GetFieldValueAsync<uint>(columnIndex, cancellationToken));
                    }
                    else if (dbDataType == DataType.Int)
                    {
                        value = Convert.ToUInt16(await dbDataReader.GetFieldValueAsync<int>(columnIndex, cancellationToken));
                    }
                    else if (dbDataType == DataType.ULong)
                    {
                        value = Convert.ToUInt16(await dbDataReader.GetFieldValueAsync<ulong>(columnIndex, cancellationToken));
                    }
                    else if (dbDataType == DataType.Long)
                    {
                        value = Convert.ToUInt16(await dbDataReader.GetFieldValueAsync<long>(columnIndex, cancellationToken));
                    }
                    else
                    {
                        value = Convert.ToUInt16(dbDataReader.GetValue(columnIndex));
                    }

                    if (propertyInfo.IsNullable && propertyInfo.IsEnum && propertyInfo.EnumType is not null)
                    {
                        if (Enum.TryParse(propertyInfo.EnumType, value.ToString(), out var enumValue))
                        {
                            propertyInfo.SetValue(typedObject, enumValue);
                        }
                    }
                    else
                    {
                        propertyInfo.SetValue(typedObject, value);
                    }

                    return;
                }
                else if (propertyType == DataType.Byte)
                {
                    byte value;

                    if (dbDataType == DataType.Byte)
                    {
                        value = await dbDataReader.GetFieldValueAsync<byte>(columnIndex, cancellationToken);
                    }
                    else if (dbDataType == DataType.SByte)
                    {
                        value = Convert.ToByte(await dbDataReader.GetFieldValueAsync<sbyte>(columnIndex, cancellationToken));
                    }
                    else if (dbDataType == DataType.Short)
                    {
                        value = Convert.ToByte(await dbDataReader.GetFieldValueAsync<short>(columnIndex, cancellationToken));
                    }
                    else if (dbDataType == DataType.UShort)
                    {
                        value = Convert.ToByte(await dbDataReader.GetFieldValueAsync<ushort>(columnIndex, cancellationToken));
                    }
                    else if (dbDataType == DataType.Int)
                    {
                        value = Convert.ToByte(await dbDataReader.GetFieldValueAsync<int>(columnIndex, cancellationToken));
                    }
                    else if (dbDataType == DataType.UInt)
                    {
                        value = Convert.ToByte(await dbDataReader.GetFieldValueAsync<uint>(columnIndex, cancellationToken));
                    }
                    else if (dbDataType == DataType.Long)
                    {
                        value = Convert.ToByte(await dbDataReader.GetFieldValueAsync<long>(columnIndex, cancellationToken));
                    }
                    else if (dbDataType == DataType.ULong)
                    {
                        value = Convert.ToByte(await dbDataReader.GetFieldValueAsync<ulong>(columnIndex, cancellationToken));
                    }
                    else
                    {
                        value = Convert.ToByte(dbDataReader.GetValue(columnIndex));
                    }

                    if (propertyInfo.IsNullable && propertyInfo.IsEnum && propertyInfo.EnumType is not null)
                    {
                        if (Enum.TryParse(propertyInfo.EnumType, value.ToString(), out var enumValue))
                        {
                            propertyInfo.SetValue(typedObject, enumValue);
                        }
                    }
                    else
                    {
                        propertyInfo.SetValue(typedObject, value);
                    }

                    return;
                }
                else if (propertyType == DataType.SByte)
                {
                    sbyte value;

                    if (dbDataType == DataType.SByte)
                    {
                        value = await dbDataReader.GetFieldValueAsync<sbyte>(columnIndex, cancellationToken);
                    }
                    else if (dbDataType == DataType.Byte)
                    {
                        value = Convert.ToSByte(await dbDataReader.GetFieldValueAsync<byte>(columnIndex, cancellationToken));
                    }
                    else if (dbDataType == DataType.Long)
                    {
                        value = Convert.ToSByte(await dbDataReader.GetFieldValueAsync<long>(columnIndex, cancellationToken));
                    }
                    else if (dbDataType == DataType.ULong)
                    {
                        value = Convert.ToSByte(await dbDataReader.GetFieldValueAsync<ulong>(columnIndex, cancellationToken));
                    }
                    else if (dbDataType == DataType.Int)
                    {
                        value = Convert.ToSByte(await dbDataReader.GetFieldValueAsync<int>(columnIndex, cancellationToken));
                    }
                    else if (dbDataType == DataType.UInt)
                    {
                        value = Convert.ToSByte(await dbDataReader.GetFieldValueAsync<uint>(columnIndex, cancellationToken));
                    }
                    else if (dbDataType == DataType.Short)
                    {
                        value = Convert.ToSByte(await dbDataReader.GetFieldValueAsync<short>(columnIndex, cancellationToken));
                    }
                    else if (dbDataType == DataType.UShort)
                    {
                        value = Convert.ToSByte(await dbDataReader.GetFieldValueAsync<ushort>(columnIndex, cancellationToken));
                    }
                    else
                    {
                        value = Convert.ToSByte(dbDataReader.GetValue(columnIndex));
                    }

                    if (propertyInfo.IsNullable && propertyInfo.IsEnum && propertyInfo.EnumType is not null)
                    {
                        if (Enum.TryParse(propertyInfo.EnumType, value.ToString(), out var enumValue))
                        {
                            propertyInfo.SetValue(typedObject, enumValue);
                        }
                    }
                    else
                    {
                        propertyInfo.SetValue(typedObject, value);
                    }

                    return;
                }
                else if (propertyType == DataType.Boolean)
                {
                    bool value;

                    if (dbDataType == DataType.Boolean)
                    {
                        value = dbDataReader.GetBoolean(columnIndex);
                    }
                    else if (dbDataType == DataType.SByte)
                    {
                        value = Convert.ToBoolean(await dbDataReader.GetFieldValueAsync<sbyte>(columnIndex, cancellationToken));
                    }
                    else if (dbDataType == DataType.Byte)
                    {
                        value = Convert.ToBoolean(await dbDataReader.GetFieldValueAsync<byte>(columnIndex, cancellationToken));
                    }
                    else if (dbDataType == DataType.Short)
                    {
                        value = Convert.ToBoolean(await dbDataReader.GetFieldValueAsync<short>(columnIndex, cancellationToken));
                    }
                    else if (dbDataType == DataType.UShort)
                    {
                        value = Convert.ToBoolean(await dbDataReader.GetFieldValueAsync<ushort>(columnIndex, cancellationToken));
                    }
                    else if (dbDataType == DataType.Int)
                    {
                        value = Convert.ToBoolean(await dbDataReader.GetFieldValueAsync<int>(columnIndex, cancellationToken));
                    }
                    else if (dbDataType == DataType.UInt)
                    {
                        value = Convert.ToBoolean(await dbDataReader.GetFieldValueAsync<uint>(columnIndex, cancellationToken));
                    }
                    else if (dbDataType == DataType.Long)
                    {
                        value = Convert.ToBoolean(await dbDataReader.GetFieldValueAsync<long>(columnIndex, cancellationToken));
                    }
                    else if (dbDataType == DataType.ULong)
                    {
                        value = Convert.ToBoolean(await dbDataReader.GetFieldValueAsync<ulong>(columnIndex, cancellationToken));
                    }
                    else
                    {
                        value = Convert.ToBoolean(dbDataReader.GetValue(columnIndex));
                    }

                    if (propertyInfo.IsNullable && propertyInfo.IsEnum && propertyInfo.EnumType is not null)
                    {
                        if (Enum.TryParse(propertyInfo.EnumType, value.ToString(), out var enumValue))
                        {
                            propertyInfo.SetValue(typedObject, enumValue);
                        }
                    }
                    else
                    {
                        propertyInfo.SetValue(typedObject, value);
                    }

                    return;
                }
                else if (propertyType == DataType.Char)
                {
                    char value;

                    if (dbDataType == DataType.Char)
                    {
                        value = dbDataReader.GetChar(columnIndex);
                    }
                    else if (dbDataType == DataType.String)
                    {
                        string str = dbDataReader.GetString(columnIndex);

                        if (str.Length == 0)
                        {
                            return;
                        }

                        if (str.Length == 1)
                        {
                            value = str[0];
                        }
                        else
                        {
                            value = dbDataReader.GetChar(columnIndex);
                        }
                    }
                    else
                    {
                        object objValue = dbDataReader.GetValue(columnIndex);

                        value = Convert.ToChar(objValue);
                    }

                    propertyInfo.SetValue(typedObject, value);

                    return;
                }
                else if (propertyType == DataType.Guid)
                {
                    if (dbDataType == DataType.Guid)
                    {
                        propertyInfo.SetValue(typedObject, dbDataReader.GetGuid(columnIndex));

                        return;
                    }

                    if (dbDataType == DataType.String)
                    {
                        string str = dbDataReader.GetString(columnIndex);

                        if (str.Length == 0)
                        {
                            return;
                        }

                        Guid guid = Guid.Parse(str);

                        propertyInfo.SetValue(typedObject, guid);

                        return;
                    }
                }
                else if (propertyType == DataType.DateTime)
                {
                    DateTime value = dbDataReader.GetDateTime(columnIndex);

                    propertyInfo.SetValue(typedObject, value);

                    return;
                }
                else if (propertyType == DataType.DateTimeOffset)
                {
                    DateTime dateTime = dbDataReader.GetDateTime(columnIndex);

                    DateTimeOffset dateTimeOffset = new(dateTime);

                    propertyInfo.SetValue(typedObject, dateTimeOffset);

                    return;
                }
# if NET6_0_OR_GREATER
                else if (propertyType == DataType.DateOnly)
                {
                    DateTime dateTime = dbDataReader.GetDateTime(columnIndex);

                    DateOnly dateOnly = new(dateTime.Year, dateTime.Month, dateTime.Day);

                    propertyInfo.SetValue(typedObject, dateOnly);

                    return;
                }
#endif

                object dbValue = dbDataReader.GetValue(columnIndex);

                propertyInfo.SetValue(typedObject, dbValue);
            }
            catch (OperationCanceledException)
            {
                throw;
            }
            catch (Exception)
            {
                if (_option.IgnoreException == false)
                {
                    throw;
                }
            }
            //catch (Exception ex)
            //{
            //    string columnName = string.Empty;

            //    object? dbValue = null;

            //    try
            //    {
            //        propertyType ??= propertyInfo.PropertyType;

            //        columnName = dbDataReader.GetName(columnIndex);

            //        dbValue = dbDataReader.GetValue(columnIndex);

            //        string message = $"dbDataReader[{rowIndex}][{columnIndex}], {{ {nameof(columnName)}: {columnName}, {nameof(dbDataType)}: {dbDataType}, {nameof(dbValue)}: {dbValue} }}, propertyName: {propertyInfo.Name}, {nameof(propertyType)}: {propertyType}";

            //        _logger?.LogError(ex, message);

            //        if (_option.IgnoreException == false)
            //        {
            //            throw new Exception(message, ex);
            //        }
            //    }
            //    catch
            //    {
            //        string message = $"dbDataReader[{rowIndex}][{columnIndex}], {{ {nameof(columnName)}: {columnName}, {nameof(dbDataType)}: {dbDataType}, {nameof(dbValue)}: {dbValue} }}, propertyName: {propertyInfo.Name}, {nameof(propertyType)}: {propertyType}";

            //        _logger?.LogError(ex, message);

            //        if (_option.IgnoreException == false)
            //        {
            //            throw new Exception(message, ex);
            //        }
            //    }
            //}
        }

#endregion

        #region Protected Property Methods

        protected virtual bool TryGetPropertyType(MapperPropertyInfo propertyInfo, out Type propertyType)
        {
            Type? underlyingType = propertyInfo.UnderlyingType;

            propertyType = underlyingType ?? DataType.Object;

            return underlyingType is not null;
        }

        #endregion

        #region Public Command Methods

        /// <summary>
        /// Executes specified DB command and returns the records.
        /// </summary>
        /// <typeparam name="T">The class you want to convert the record to.</typeparam>
        /// <param name="dbCommand">A DB command with a SELECT query.</param>
        /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
        /// <returns>A list of records.</returns>
        public virtual async Task<List<T>> ExecuteQueryAsync<T>(DbCommand dbCommand, CancellationToken cancellationToken)
        {
            using DbDataReader dbDataReader = await dbCommand.ExecuteReaderAsync(cancellationToken);

            cancellationToken.ThrowIfCancellationRequested();

            return await ReadToObjectsInnerAsync<T>(dbDataReader, firstRecordOnly: false, cancellationToken);
        }

        /// <summary>
        /// Executes a SELECT query and returns the records.
        /// </summary>
        /// <typeparam name="T">
        /// The class you want to convert the record to.
        /// It is recommended to define the <see cref="TableAttribute">[Table]</see> and <see cref="ColumnAttribute">[Column]</see> attribute.
        /// </typeparam>
        /// <param name="dbCommand">A DB command.</param>
        /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
        /// <returns>A list of records.</returns>
        public virtual async Task<List<T>> SelectAllAsync<T>(DbCommand dbCommand, CancellationToken cancellationToken)
        {
            (string schemaName, string tableName) = GetSchemaAndTable(typeof(T));

            string tableSource;

            if (schemaName.Length == 0)
            {
                tableSource = tableName;
            }
            else
            {
                tableSource = $"{schemaName}.{tableName}";
            }

            dbCommand.Parameters.Clear();

            dbCommand.CommandType = CommandType.Text;

            dbCommand.CommandText = $"SELECT * FROM {tableSource}";

            return await ExecuteQueryAsync<T>(dbCommand, cancellationToken);
        }

        #endregion

        #region Protected Classes

        /// <summary>
        /// Schema and Table
        /// </summary>
        protected class SchemaAndTable
        {
            /// <summary>
            /// Initializes a new instance of the SchemaAndTable class with the specified schemaName and tableName.
            /// </summary>
            /// <param name="schemaName">A schema name.</param>
            /// <param name="tableName">A table name.</param>
            public SchemaAndTable(string schemaName, string tableName)
            {
                SchemaName = schemaName;
                TableName = tableName;
            }

            /// <summary>The schema name.</summary>
            public string SchemaName { get; set; } = string.Empty;

            /// <summary>The table name.</summary>
            public string TableName { get; set; } = string.Empty;

            public override string ToString()
            {
                return $"{nameof(SchemaName)}: {SchemaName}, {nameof(TableName)}: {TableName}";
            }
        }

        #endregion
    }
}