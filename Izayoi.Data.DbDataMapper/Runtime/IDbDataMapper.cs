// ----------------------------------------------------------------------
// @Namespace : Izayoi.Data
// @Interface : IDbDataMapper
// ----------------------------------------------------------------------
#nullable enable
namespace Izayoi.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Common;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// DB Data Mapper Interface
    /// </summary>
    public interface IDbDataMapper
    {
        #region Properties

        /// <summary>Gets the DB data mapper option.</summary>
        DbDataMapperOption Option { get; }

        #endregion

        #region Methods

        /// <summary>
        /// Gets the column name mapper of the specified object type.
        /// </summary>
        /// <param name="objectType">The object type for which you want to get the column name mapper.</param>
        /// <returns>The column name mapper of the specified object type.</returns>
        PropertyMapper GetColumnNameMapper(Type objectType);

        /// <summary>
        /// Gets the schema and table name of the specified object type.
        /// </summary>
        /// <param name="objectType">The object type for which you want to get the table name.</param>
        /// <returns>
        /// The schema name of the specified object type.
        /// The table name of the specified object type.
        /// </returns>
        (string schemaName, string tableName) GetSchemaAndTable(Type objectType);

        /// <summary>
        /// Gets the schema name of the specified object type.
        /// </summary>
        /// <param name="objectType">The object type for which you want to get the table name.</param>
        /// <returns>The schema name of the specified object type.</returns>
        string GetSchemaName(Type objectType);

        /// <summary>
        /// Gets the table name of the specified object type.
        /// </summary>
        /// <param name="objectType">The object type for which you want to get the table name.</param>
        /// <returns>The table name of the specified object type.</returns>
        string GetTableName(Type objectType);

        /// <summary>
        /// Sets the table name for the specified object type in the cache.
        /// </summary>
        /// <param name="objectType">The object type for which you want to set the table name.</param>
        /// <param name="tableName">The name of the table to be set.</param>
        void SetTableName(Type objectType, string tableName);

        /// <summary>
        /// Sets the table and schema name for the specified object type in the cache.
        /// </summary>
        /// <param name="objectType">The object type for which you want to set the table name.</param>
        /// <param name="tableName">The name of the table to be set.</param>
        /// <param name="schemaName">The name of the schema to be set.</param>
        void SetTableAndSchema(Type objectType, string tableName, string schemaName);

        /// <summary>
        /// Gets the first record from the DB data reader's record set, sets the values ​​for the specified T class, and returns it.
        /// </summary>
        /// <typeparam name="T">The class you want to convert the record to.</typeparam>
        /// <param name="dbDataReader">A DB data reader resulting from executing a DB command.</param>
        /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
        /// <returns>The first record converted from the DB reader's record set into T class.</returns>
        Task<T?> ReadToObjectAsync<T>(DbDataReader dbDataReader, CancellationToken cancellationToken);

        /// <summary>
        /// Gets the records from the DB data reader's record set, sets the values ​​for the specified T class, and returns it.
        /// </summary>
        /// <typeparam name="T">The class you want to convert the record to.</typeparam>
        /// <param name="dbDataReader">A DB data reader resulting from executing a DB command.</param>
        /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
        /// <returns>A list of records converted from the DB reader's record set into T class.</returns>
        Task<List<T>> ReadToObjectsAsync<T>(DbDataReader dbDataReader, CancellationToken cancellationToken);

        /// <summary>
        /// Executes a DB command and returns the record set in an object.
        /// </summary>
        /// <typeparam name="T">The class you want to convert the record to.</typeparam>
        /// <param name="dbCommand">A DB command with a SELECT query.</param>
        /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
        /// <returns>A list of records.</returns>
        Task<List<T>> ExecuteQueryAsync<T>(DbCommand dbCommand, CancellationToken cancellationToken);

        /// <summary>
        /// Executes a SELECT query and returns the record set in an object.
        /// </summary>
        /// <typeparam name="T">
        /// The class you want to convert the record to.
        /// It is recommended to define the <see cref="TableAttribute">[Table]</see> and <see cref="ColumnAttribute">[Column]</see> attribute.
        /// </typeparam>
        /// <param name="dbCommand">A DB command.</param>
        /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
        /// <returns>A list of records.</returns>
        Task<List<T>> SelectAllAsync<T>(DbCommand dbCommand, CancellationToken cancellationToken);

        #endregion
    }
}
