// ----------------------------------------------------------------------
// @Namespace : Izayoi.Data
// @Interface : IDbCommandAdapter
// ----------------------------------------------------------------------
namespace Izayoi.Data
{
    using Izayoi.Data.Query;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Common;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// DB Command Adapter Interface
    /// </summary>
    public interface IDbCommandAdapter
    {
        #region Properties

        /// <summary>Gets the DB data mapper.</summary>
        IDbDataMapper DbDataMapper { get; }

        /// <summary>Gets the query option.</summary>
        QueryOption QueryOption { get; }

        #endregion

        #region Methods

        ///// <summary>
        ///// Adds specified bind parameters to the specified DB command.
        ///// </summary>
        ///// <param name="dbCommand">A DB command.</param>
        ///// <param name="bindParameters">Bind parameter collection.</param>
        //void AddBindParameters(DbCommand dbCommand, BindParameterCollection bindParameters);

        /// <summary>
        /// Builds a DELETE query for the specified DB command using specified delete source.
        /// </summary>
        /// <param name="dbCommand">A DB command.</param>
        /// <param name="delete">A Delete source.</param>
        /// <returns><see langword="true" /> if the build is successful; <see langword="false" /> otherwise.</returns>
        bool BuildDeleteCommand(DbCommand dbCommand, Delete delete);

        /// <summary>
        /// Builds a DELETE query for the specified DB command using specified data.
        /// </summary>
        /// <typeparam name="T">
        /// The type of data.
        /// It is recommended to define the <see cref="TableAttribute">[Table]</see> and <see cref="ColumnAttribute">[Column]</see> attribute.
        /// The <see cref="KeyAttribute">[Key]</see> attribute must be defined.
        /// </typeparam>
        /// <param name="dbCommand">A DB command.</param>
        /// <param name="data">The data you want to delete.</param>
        /// <returns><see langword="true" /> if the build is successful; <see langword="false" /> otherwise.</returns>
        /// <exception cref="Exception"><see cref="KeyAttribute">[Key]</see> attribute is not found in <typeparamref name="T"/> class.</exception>
        bool BuildDeleteCommand<T>(DbCommand dbCommand, T data);

        /// <summary>
        /// Builds an INSERT query for the specified DB command using specified insert source.
        /// </summary>
        /// <param name="dbCommand">A DB command.</param>
        /// <param name="insert">An Insert source.</param>
        /// <returns><see langword="true" /> if the build is successful; <see langword="false" /> otherwise.</returns>
        bool BuildInsertCommand(DbCommand dbCommand, Insert insert);

        /// <summary>
        /// Builds an INSERT query for the specified DB command using specified data.
        /// </summary>
        /// <typeparam name="T">
        /// The type of data.
        /// It is recommended to define the <see cref="TableAttribute">[Table]</see> and <see cref="ColumnAttribute">[Column]</see> attribute.
        /// </typeparam>
        /// <param name="dbCommand">A DB command.</param>
        /// <param name="data">The data you want to register.</param>
        /// <param name="excludeKey">If <see langword="true" /> is specified, the <see cref="KeyAttribute">[Key]</see> attributed property will be excluded.</param>
        /// <returns><see langword="true" /> if the build is successful; <see langword="false" /> otherwise.</returns>
        bool BuildInsertCommand<T>(DbCommand dbCommand, T data, bool excludeKey = false);

        /// <summary>
        /// Builds a SELECT query for the specified DB command using specified select source.
        /// </summary>
        /// <param name="dbCommand">A DB command.</param>
        /// <param name="select">A Select source.</param>
        /// <returns><see langword="true" /> if the build is successful; <see langword="false" /> otherwise.</returns>
        bool BuildSelectCommand(DbCommand dbCommand, Select select);

        /// <summary>
        /// Builds an UPDATE query for the specified DB command using specified update source.
        /// </summary>
        /// <param name="dbCommand">A DB command.</param>
        /// <param name="update">An Update source.</param>
        /// <returns><see langword="true" /> if the build is successful; <see langword="false" /> otherwise.</returns>
        bool BuildUpdateCommand(DbCommand dbCommand, Update update);

        /// <summary>
        /// Builds an UPDATE query for the specified DB command using specified data.
        /// </summary>
        /// <typeparam name="T">
        /// The type of data.
        /// It is recommended to define the <see cref="TableAttribute">[Table]</see> and <see cref="ColumnAttribute">[Column]</see> attribute.
        /// The <see cref="KeyAttribute">[Key]</see> attribute must be defined.
        /// </typeparam>
        /// <param name="dbCommand">A DB command.</param>
        /// <param name="data">The data you want to update.</param>
        /// <param name="excludeColumns">Specify the column names (property names) you want to exclude from updating.</param>
        /// <returns><see langword="true" /> if the build is successful; <see langword="false" /> otherwise.</returns>
        /// <exception cref="Exception"><see cref="KeyAttribute">[Key]</see> attribute is not found in <typeparamref name="T"/> class.</exception>
        bool BuildUpdateCommand<T>(DbCommand dbCommand, T data, string[]? excludeColumns = null);

        /// <summary>
        /// Executes specified DB command, and returns the records.
        /// </summary>
        /// <typeparam name="T">The class you want to convert the record to.</typeparam>
        /// <param name="dbCommand">A DB command with a SELECT query.</param>
        /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
        /// <returns>A list of records.</returns>
        Task<List<T>> ExecuteQueryAsync<T>(DbCommand dbCommand, CancellationToken cancellationToken);

        /// <summary>
        /// Executes specified DB command, and returns the first columns of the first row in the first returned result set.
        /// </summary>
        /// <typeparam name="T">Type of the first columns.</typeparam>
        /// <param name="dbCommand">A DB command.</param>
        /// <returns>The first columns of the first row in the first result set.</returns>
        T? ExecuteScalar<T>(DbCommand dbCommand);

        /// <summary>
        /// Executes specified DB command, and returns the first columns of the first row in the first returned result set.
        /// </summary>
        /// <typeparam name="T">Type of the first columns.</typeparam>
        /// <param name="dbCommand">A DB command.</param>
        /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
        /// <returns>The first columns of the first row in the first result set.</returns>
        Task<T?> ExecuteScalarAsync<T>(DbCommand dbCommand, CancellationToken cancellationToken);

        /// <summary>
        /// Executes specified DB command using specified select source, and returns the first columns of the first row in the first returned result set.
        /// </summary>
        /// <typeparam name="T">Type of the first columns.</typeparam>
        /// <param name="dbCommand">A DB command.</param>
        /// <param name="select">A Select class.</param>
        /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
        /// <returns>The first columns of the first row in the first result set.</returns>
        Task<T?> ExecuteScalarAsync<T>(DbCommand dbCommand, Select select, CancellationToken cancellationToken);

        /// <summary>
        /// Executes a DELETE query for the specified DB command using specified delete source.
        /// </summary>
        /// <param name="dbCommand">A DB command.</param>
        /// <param name="delete">A Delete source.</param>
        /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
        /// <returns>The number of rows affected.</returns>
        Task<int> DeleteAsync(DbCommand dbCommand, Delete delete, CancellationToken cancellationToken);

        /// <summary>
        /// Executes a DELETE query for the specified DB command using specified data.
        /// </summary>
        /// <typeparam name="T">
        /// The type of data.
        /// It is recommended to define the <see cref="TableAttribute">[Table]</see>.
        /// The <see cref="KeyAttribute">[Key]</see> attribute must be defined.
        /// </typeparam>
        /// <param name="data">The data you want to delete.</param>
        /// <returns>The number of rows affected.</returns>
        /// <exception cref="Exception"><see cref="KeyAttribute">[Key]</see> attribute is not found in <typeparamref name="T"/> class.</exception>
        Task<int> DeleteAsync<T>(DbCommand dbCommand, T data, CancellationToken cancellationToken);

        /// <summary>
        /// Executes an INSERT query for the specified DB command using specified data.
        /// </summary>
        /// <typeparam name="T">
        /// The type of data.
        /// It is recommended to define the <see cref="TableAttribute">[Table]</see> and <see cref="ColumnAttribute">[Column]</see> attribute.
        /// </typeparam>
        /// <param name="dbCommand">A DB command.</param>
        /// <param name="data">The data you want to register.</param>
        /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
        /// <returns>The number of rows affected.</returns>
        Task<int> InsertAsync<T>(DbCommand dbCommand, T data, CancellationToken cancellationToken);

        /// <summary>
        /// Executes an INSERT query for the specified DB command using specified data.
        /// </summary>
        /// <typeparam name="T">
        /// The type of data.
        /// It is recommended to define the <see cref="TableAttribute">[Table]</see> and <see cref="ColumnAttribute">[Column]</see> attribute.
        /// </typeparam>
        /// <param name="dbCommand">A DB command.</param>
        /// <param name="data">The data you want to register.</param>
        /// <param name="excludeKey">If <see langword="true" /> is specified, the <see cref="KeyAttribute">[Key]</see> attributed property will be excluded.</param>
        /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
        /// <returns>The number of rows affected.</returns>
        Task<int> InsertAsync<T>(DbCommand dbCommand, T data, bool excludeKey, CancellationToken cancellationToken);

        /// <summary>
        /// Builds an INSERT query for the specified DB command using specified insert source.
        /// </summary>
        /// <param name="dbCommand">A DB command.</param>
        /// <param name="insert">An Insert source.</param>
        /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
        /// <returns>The number of rows affected.</returns>
        Task<int> InsertAsync(DbCommand dbCommand, Insert insert, CancellationToken cancellationToken);

        /// <summary>
        /// Executes an INSERT query for the specified DB command using specified data, and returns an inserted identity value.
        /// </summary>
        /// <typeparam name="TReturn">The data type of identity column (primary key).</typeparam>
        /// <typeparam name="TData">
        /// The type of data.
        /// It is recommended to define the <see cref="TableAttribute">[Table]</see> and <see cref="ColumnAttribute">[Column]</see> attribute.
        /// </typeparam>
        /// <param name="dbCommand">A DB command.</param>
        /// <param name="data">The data you want to register.</param>
        /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
        /// <returns>Inserted identity value.</returns>
        Task<TReturn?> InsertReturnAsync<TReturn, TData>(DbCommand dbCommand, TData data, CancellationToken cancellationToken);

        /// <summary>
        /// Executes an INSERT query for the specified DB command using specified data, and returns an inserted identity value.
        /// </summary>
        /// <typeparam name="TReturn">The data type of identity column (primary key).</typeparam>
        /// <typeparam name="TData">
        /// The type of data.
        /// It is recommended to define the <see cref="TableAttribute">[Table]</see> and <see cref="ColumnAttribute">[Column]</see> attribute.
        /// </typeparam>
        /// <param name="dbCommand">A DB command.</param>
        /// <param name="data">The data you want to register.</param>
        /// <param name="excludeKey">If <see langword="true" /> is specified, the <see cref="KeyAttribute">[Key]</see> attributed property will be excluded.</param>
        /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
        /// <returns>Inserted identity value.</returns>
        /// <remarks>Use this if the primary key is auto increment.</remarks>
        Task<TReturn?> InsertReturnAsync<TReturn, TData>(DbCommand dbCommand, TData data, bool excludeKey, CancellationToken cancellationToken);

        /// <summary>
        /// Executes an INSERT query for the specified DB command using specified insert source, and returns an inserted identity value.
        /// </summary>
        /// <typeparam name="T">The data type of identity column (primary key).</typeparam>
        /// <param name="dbCommand">A DB command.</param>
        /// <param name="insert">An Insert source.</param>
        /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
        /// <returns>Inserted identity value.</returns>
        /// <remarks>Use this if the primary key is auto increment.</remarks>
        Task<T?> InsertReturnAsync<T>(DbCommand dbCommand, Insert insert, CancellationToken cancellationToken);

        /// <summary>
        /// Executes an INSERT query for the specified DB command using specified insert source, and returns an inserted specified returnColumnName value.
        /// </summary>
        /// <typeparam name="T">The data type that returnColumnName represents.</typeparam>
        /// <param name="dbCommand">A DB command.</param>
        /// <param name="insert">An Insert source.</param>
        /// <param name="returnColumnName"></param>
        /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
        /// <returns>Inserted specified returnColumnName value.</returns>
        /// <remarks>Use this if the primary key is auto increment.</remarks>
        Task<T?> InsertReturnAsync<T>(DbCommand dbCommand, Insert insert, string returnColumnName, CancellationToken cancellationToken);

        /// <summary>
        /// Executes an INSERT query for the specified DB command using specified data, and returns an inserted specified returnColumnName value.
        /// </summary>
        /// <typeparam name="TReturn">The data type of identity column (primary key).</typeparam>
        /// <typeparam name="TData">
        /// The type of data.
        /// It is recommended to define the <see cref="TableAttribute">[Table]</see> and <see cref="ColumnAttribute">[Column]</see> attribute.
        /// </typeparam>
        /// <param name="dbCommand">A DB command.</param>
        /// <param name="data">The data you want to register.</param>
        /// <param name="returnColumnName"></param>
        /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
        /// <returns>Inserted specified returnColumnName value.</returns>
        Task<TReturn?> InsertReturnAsync<TReturn, TData>(DbCommand dbCommand, TData data, string returnColumnName, CancellationToken cancellationToken);

        /// <summary>
        /// Executes an INSERT query for the specified DB command using specified data, and returns an inserted specified returnColumnName value.
        /// </summary>
        /// <typeparam name="TReturn">The data type of identity column (primary key).</typeparam>
        /// <typeparam name="TData">
        /// The type of data.
        /// It is recommended to define the <see cref="TableAttribute">[Table]</see> and <see cref="ColumnAttribute">[Column]</see> attribute.
        /// </typeparam>
        /// <param name="dbCommand">A DB command.</param>
        /// <param name="data">The data you want to register.</param>
        /// <param name="excludeKey">If <see langword="true" /> is specified, the <see cref="KeyAttribute">[Key]</see> attributed property will be excluded.</param>
        /// <param name="returnColumnName"></param>
        /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
        /// <returns>Inserted specified returnColumnName value.</returns>
        /// <remarks>Use this if the primary key is auto increment.</remarks>
        Task<TReturn?> InsertReturnAsync<TReturn, TData>(DbCommand dbCommand, TData data, bool excludeKey, string returnColumnName, CancellationToken cancellationToken);

        /// <summary>
        /// Executes a SELECT ALL query for the specified DB command, and returns the records.
        /// </summary>
        /// <typeparam name="T">
        /// The class you want to convert the record to.
        /// It is recommended to define the <see cref="TableAttribute">[Table]</see> and <see cref="ColumnAttribute">[Column]</see> attribute.
        /// </typeparam>
        /// <param name="dbCommand">A DB command.</param>
        /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
        /// <returns>A list of records.</returns>
        Task<List<T>> SelectAllAsync<T>(DbCommand dbCommand, CancellationToken cancellationToken);

        /// <summary>
        /// Executes a SELECT query for the specified DB command using specified select source, and returns the records.
        /// </summary>
        /// <typeparam name="T">
        /// The class you want to convert the record to.
        /// It is recommended to define the <see cref="TableAttribute">[Table]</see> and <see cref="ColumnAttribute">[Column]</see> attribute.
        /// </typeparam>
        /// <param name="dbCommand">A DB command.</param>
        /// <param name="select">A Select source.</param>
        /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
        /// <returns>A list of records.</returns>
        Task<List<T>> SelectAsync<T>(DbCommand dbCommand, Select select, CancellationToken cancellationToken);

        /// <summary>
        /// Executes an UPDATE query for the specified DB command using specified update source.
        /// </summary>
        /// <param name="dbCommand">A DB command.</param>
        /// <param name="update">An Update source.</param>
        /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
        /// <returns>The number of rows affected.</returns>
        Task<int> UpdateAsync(DbCommand dbCommand, Update update, CancellationToken cancellationToken);

        /// <summary>
        /// Executes an UPDATE query for the specified DB command using specified data.
        /// </summary>
        /// <typeparam name="T">
        /// The type of data.
        /// It is recommended to define the <see cref="TableAttribute">[Table]</see> and <see cref="ColumnAttribute">[Column]</see> attribute.
        /// The <see cref="KeyAttribute">[Key]</see> attribute must be defined.
        /// </typeparam>
        /// <param name="data">The data you want to update.</param>
        /// <returns>The number of rows affected.</returns>
        /// <exception cref="Exception"><see cref="KeyAttribute">[Key]</see> attribute is not found in <typeparamref name="T"/> class.</exception>
        Task<int> UpdateAsync<T>(DbCommand dbCommand, T data, CancellationToken cancellationToken);

        /// <summary>
        /// Executes an UPDATE query for the specified DB command using specified data.
        /// </summary>
        /// <typeparam name="T">
        /// The type of data.
        /// It is recommended to define the <see cref="TableAttribute">[Table]</see> and <see cref="ColumnAttribute">[Column]</see> attribute.
        /// The <see cref="KeyAttribute">[Key]</see> attribute must be defined.
        /// </typeparam>
        /// <param name="data">The data you want to update.</param>
        /// <param name="excludeColumns">Specify the column names (property names) you want to exclude from updating.</param>
        /// <returns>The number of rows affected.</returns>
        /// <exception cref="Exception"><see cref="KeyAttribute">[Key]</see> attribute is not found in <typeparamref name="T"/> class.</exception>
        Task<int> UpdateAsync<T>(DbCommand dbCommand, T data, string[] excludeColumns, CancellationToken cancellationToken);

        #endregion
    }
}
