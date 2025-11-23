// ----------------------------------------------------------------------
// @Namespace : Izayoi.Data
// @Interface : IDbCommand
// ----------------------------------------------------------------------
#nullable enable
namespace Izayoi.Data
{
    using Izayoi.Data.Query;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data;
    using System.Data.Common;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// DB Command Interface
    /// </summary>
    public interface IDbCommand : IDisposable //System.Data.IDbCommand
    {
        #region Properties

        /// <summary>Gets or sets the text command to run against the data source.</summary>
        /// <value>The text command to execute. The default value is an empty string ("").</value>
        string CommandText { get; set; }

        /// <summary>Gets or sets the wait time (in seconds) before terminating the attempt to execute a command and generating an error.</summary>
        /// <value>The time (in seconds) to wait for the command to execute. The default value is 30 seconds.</value>
        /// <exception cref="ArgumentException">The property value assigned is less than 0.</exception>
        int CommandTimeout { get; set; }

        /// <summary>Indicates or specifies how the System.Data.IDbCommand.CommandText property is interpreted.</summary>
        /// <value>One of the System.Data.CommandType values. The default is Text.</value>
        CommandType CommandType { get; set; }

        /// <summary>Gets or sets the System.Data.IDbConnection used by this instance of the System.Data.IDbCommand.</summary>
        /// <value>The connection to the data source.</value>
        DbConnection? Connection { get; set; }
        //IDbConnection? Connection { get; set; }

        /// <summary>Gets the System.Data.IDataParameterCollection.</summary>
        /// <value>The parameters of the SQL statement or stored procedure.</value>
        DbParameterCollection Parameters { get; }
        //IDataParameterCollection Parameters { get; }

        /// <summary>Gets or sets the transaction within which the Command object of a .NET data provider executes.</summary>
        /// <value>the Command object of a .NET Framework data provider executes. The default value is null.</value>
        DbTransaction? Transaction { get; set; }
        //IDbTransaction? Transaction { get; set; }

        bool DesignTimeVisible { get; set; }

        /// <summary>
        /// Gets or sets how command results are applied to the System.Data.DataRow when
        /// used by the System.Data.IDataAdapter.Update(System.Data.DataSet) method of a
        /// System.Data.Common.DbDataAdapter.
        /// </summary>
        /// <value>
        /// One of the System.Data.UpdateRowSource values.
        /// The default is Both unless the command is automatically generated.
        /// Then the default is None.
        /// </value>
        /// <exception cref="ArgumentException">The value entered was not one of the System.Data.UpdateRowSource values.</exception>
        UpdateRowSource UpdatedRowSource { get; set; }

        /// <summary>Gets or sets the delete source.</summary>
        Delete? Delete { get; set; }

        /// <summary>Gets or sets the insert source.</summary>
        Insert? Insert { get; set; }

        /// <summary>Gets or sets the select source.</summary>
        Select? Select { get; set; }

        /// <summary>Gets or sets the update source.</summary>
        Update? Update { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Attempts to cancels the execution of an System.Data.IDbCommand.
        /// </summary>
        /// <remarks>
        /// If there is nothing to cancel, nothing happens.
        /// However, if there is a command in process, and the attempt to cancel fails, no exception is generated.
        /// </remarks>
        void Cancel();

        /// <summary>
        /// Create a new Delete class.
        /// </summary>
        /// <param name="setProperty">If <see langword="true" /> is specified, the created Delete will be set to the Delete property.</param>
        /// <returns>A new Delete class.</returns>
        Delete CreateDelete(bool setProperty = true);

        /// <summary>
        /// Create a new Insert class.
        /// </summary>
        /// <param name="setProperty">If <see langword="true" /> is specified, the created Insert will be set to the Insert property.</param>
        /// <returns>A new Insert class.</returns>
        Insert CreateInsert(bool setProperty = true);

        /// <summary>
        /// Create a new Select class.
        /// </summary>
        /// <param name="setProperty">If <see langword="true" /> is specified, the created Select will be set to the Select property.</param>
        /// <returns>A new Select class.</returns>
        Select CreateSelect(bool setProperty = true);

        /// <summary>
        /// Create a new Update class.
        /// </summary>
        /// <param name="setProperty">If <see langword="true" /> is specified, the created Update will be set to the Update property.</param>
        /// <returns>A new Update class.</returns>
        Update CreateUpdate(bool setProperty = true);

        /// <summary>
        /// Creates a new instance of an System.Data.IDbDataParameter object.
        /// </summary>
        /// <returns>An IDbDataParameter object.</returns>
        DbParameter CreateParameter();
        //IDbDataParameter CreateParameter();

        /// <summary>
        /// Builds a DELETE command using Delete property.
        /// </summary>
        /// <returns><see langword="true" /> if the query and parameter was successfully built; otherwise, <see langword="false" />.</returns>
        bool BuildDelete();

        /// <summary>
        /// Builds a DELETE command using the specified data.
        /// </summary>
        /// <typeparam name="T">
        /// The type of data.
        /// It is recommended to define the <see cref="TableAttribute">[Table]</see> and <see cref="ColumnAttribute">[Column]</see> attribute.
        /// The <see cref="KeyAttribute">[Key]</see> attribute must be defined.
        /// </typeparam>
        /// <param name="data">The data you want to delete.</param>
        /// <returns><see langword="true" /> if the query and parameter was successfully built; otherwise, <see langword="false" />.</returns>
        /// <exception cref="Exception"><see cref="KeyAttribute">[Key]</see> attribute is not found in <typeparamref name="T"/> class.</exception>
        bool BuildDelete<T>(T data);

        /// <summary>
        /// Builds a INSERT command using Insert property.
        /// </summary>
        /// <returns><see langword="true" /> if the query and parameter was successfully built; otherwise, <see langword="false" />.</returns>
        bool BuildInsert();

        /// <summary>
        /// Builds a INSERT command using the specified data.
        /// </summary>
        /// <typeparam name="T">
        /// The type of data.
        /// It is recommended to define the <see cref="TableAttribute">[Table]</see> and <see cref="ColumnAttribute">[Column]</see> attribute.
        /// </typeparam>
        /// <param name="data">The data you want to register.</param>
        /// <param name="excludeKey">If <see langword="true" /> is specified, the <see cref="KeyAttribute">[Key]</see> attributed property will be excluded.</param>
        /// <returns><see langword="true" /> if the query and parameter was successfully built; otherwise, <see langword="false" />.</returns>
        bool BuildInsert<T>(T data, bool excludeKey = false);

        /// <summary>
        /// Builds a SELECT command using Insert property.
        /// </summary>
        /// <returns><see langword="true" /> if the query and parameter was successfully built; otherwise, <see langword="false" />.</returns>
        bool BuildSelect();

        /// <summary>
        /// Builds a UPDATE command using Insert property.
        /// </summary>
        /// <returns><see langword="true" /> if the query and parameter was successfully built; otherwise, <see langword="false" />.</returns>
        bool BuildUpdate();

        /// <summary>
        /// Builds a UPDATE command using the specified data.
        /// </summary>
        /// <typeparam name="T">
        /// The type of data.
        /// It is recommended to define the <see cref="TableAttribute">[Table]</see> and <see cref="ColumnAttribute">[Column]</see> attribute.
        /// The <see cref="KeyAttribute">[Key]</see> attribute must be defined.
        /// </typeparam>
        /// <param name="data">The data you want to update.</param>
        /// <param name="excludeColumns">Specify the column names (property names) you want to exclude from updating.</param>
        /// <returns><see langword="true" /> if the query and parameter was successfully built; otherwise, <see langword="false" />.</returns>
        /// <exception cref="Exception"><see cref="KeyAttribute">[Key]</see> attribute is not found in <typeparamref name="T"/> class.</exception>
        bool BuildUpdate<T>(T data, string[]? excludeColumns = null);

        //void Dispose();

        /// <summary>
        /// Asynchronously disposes the command object.
        /// </summary>
        /// <returns>A ValueTask representing the asynchronous operation.</returns>
        ValueTask DisposeAsync();

        /// <summary>
        /// Executes SELECT command using Select property, and returns the records.
        /// </summary>
        /// <typeparam name="T">The class you want to convert the record to.</typeparam>
        /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
        /// <returns>A list of records.</returns>
        Task<List<T>> ExecuteQueryAsync<T>(CancellationToken cancellationToken);

        /// <summary>
        /// Executes an SQL statement against the Connection object of a .NET data provider, and returns the number of rows affected.
        /// </summary>
        /// <returns>The number of rows affected.</returns>
        /// <exception cref="InvalidOperationException">The connection does not exist. -or- The connection is not open.</exception>
        int ExecuteNonQuery();

        ///// <summary>
        ///// Executes SELECT command using Select property, and returns the records.
        ///// </summary>
        ///// <returns>The number of rows affected.</returns>
        //Task<int> ExecuteNonQueryAsync();

        /// <summary>
        /// Executes SELECT command using Select property, and returns the records.
        /// </summary>
        /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
        /// <returns>The number of rows affected.</returns>
        Task<int> ExecuteNonQueryAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Executes the System.Data.IDbCommand.CommandText against the System.Data.IDbCommand.Connection and builds an System.Data.IDataReader.
        /// </summary>
        /// <returns>An System.Data.IDataReader object.</returns>
        DbDataReader ExecuteReader();
        //IDataReader ExecuteReader();

        /// <summary>
        /// Executes the System.Data.IDbCommand.CommandText against the System.Data.IDbCommand.Connection,
        /// and builds an System.Data.IDataReader using one of the System.Data.CommandBehavior values.
        /// </summary>
        /// <param name="behavior">One of the System.Data.CommandBehavior values.</param>
        /// <returns>An System.Data.IDataReader object.</returns>
        DbDataReader ExecuteReader(CommandBehavior behavior);
        //IDataReader ExecuteReader(CommandBehavior behavior);

        ///// <summary>
        ///// Executes the System.Data.IDbCommand.CommandText against the System.Data.IDbCommand.Connection,
        ///// and builds an System.Data.IDataReader using one of the System.Data.CommandBehavior values.
        ///// </summary>
        ///// <returns>An System.Data.IDataReader object.</returns>
        //Task<DbDataReader> ExecuteReaderAsync();

        ///// <summary>
        ///// Executes the System.Data.IDbCommand.CommandText against the System.Data.IDbCommand.Connection,
        ///// and builds an System.Data.IDataReader using one of the System.Data.CommandBehavior values.
        ///// </summary>
        ///// <param name="behavior">One of the enumeration values that specifies the command behavior.</param>
        ///// <returns>An System.Data.IDataReader object.</returns>
        //Task<DbDataReader> ExecuteReaderAsync(CommandBehavior behavior);

        /// <summary>
        /// Executes the System.Data.IDbCommand.CommandText against the System.Data.IDbCommand.Connection,
        /// and builds an System.Data.IDataReader using one of the System.Data.CommandBehavior values.
        /// </summary>
        /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
        /// <returns>An System.Data.IDataReader object.</returns>
        Task<DbDataReader> ExecuteReaderAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Executes the System.Data.IDbCommand.CommandText against the System.Data.IDbCommand.Connection,
        /// and builds an System.Data.IDataReader using one of the System.Data.CommandBehavior values.
        /// </summary>
        /// <param name="behavior">One of the enumeration values that specifies the command behavior.</param>
        /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
        /// <returns>An System.Data.IDataReader object.</returns>
        Task<DbDataReader> ExecuteReaderAsync(CommandBehavior behavior, CancellationToken cancellationToken);

        /// <summary>
        /// Executes the query, and returns the first column of the first row in the resultset returned by the query.
        /// Extra columns or rows are ignored.
        /// </summary>
        /// <returns>The first column of the first row in the resultset.</returns>
        object? ExecuteScalar();

        /// <summary>
        /// Executes SELECT command using Select property, and returns the first columns of the first row in the first returned result set.
        /// </summary>
        /// <typeparam name="T">Type of the first columns.</typeparam>
        /// <returns>The first columns of the first row in the first result set.</returns>
        T? ExecuteScalar<T>();

        //Task<object?> ExecuteScalarAsync();

        /// <summary>
        /// Executes SELECT command using Select property, and returns the first columns of the first row in the first returned result set.
        /// </summary>
        /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
        /// <returns>The first columns of the first row in the first result set.</returns>
        Task<object?> ExecuteScalarAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Executes SELECT command using Select property, and returns the first columns of the first row in the first returned result set.
        /// </summary>
        /// <typeparam name="T">Type of the first columns.</typeparam>
        /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
        /// <returns>The first columns of the first row in the first result set.</returns>
        Task<T?> ExecuteScalarAsync<T>(CancellationToken cancellationToken);

        /// <summary>
        /// Creates a prepared (or compiled) version of the command on the data source.
        /// </summary>
        /// <exception cref="InvalidOperationException">
        /// The System.Data.OleDb.OleDbCommand.Connection is not set. -or- The System.Data.OleDb.OleDbCommand.Connection is not System.Data.OleDb.OleDbConnection.Open.
        /// </exception>
        void Prepare();

        /// <summary>
        /// Asynchronously creates a prepared (or compiled) version of the command on the data source.
        /// </summary>
        /// <param name="cancellationToken">An optional token to cancel the asynchronous operation. The default value is None.</param>
        /// <returns>A Task representing the asynchronous operation.</returns>
        /// <exception cref="OperationCanceledException">The cancellation token was canceled. This exception is stored into the returned task.</exception>
        Task PrepareAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Executes a DELETE command using Delete property.
        /// </summary>
        /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
        /// <returns>The number of rows affected.</returns>
        Task<int> DeleteAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Executes a DELETE command using the specified data.
        /// </summary>
        /// <typeparam name="T">
        /// The type of data.
        /// It is recommended to define the <see cref="TableAttribute">[Table]</see>.
        /// The <see cref="KeyAttribute">[Key]</see> attribute must be defined.
        /// </typeparam>
        /// <param name="data">The data you want to delete.</param>
        /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
        /// <returns>The number of rows affected.</returns>
        /// <exception cref="Exception"><see cref="KeyAttribute">[Key]</see> attribute is not found in <typeparamref name="T"/> class.</exception>
        Task<int> DeleteAsync<T>(T data, CancellationToken cancellationToken);

        /// <summary>
        /// Executes an INSERT command using Insert property.
        /// </summary>
        /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
        /// <returns>The number of rows affected.</returns>
        Task<int> InsertAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Executes an INSERT command using the specified data.
        /// </summary>
        /// <param name="data">The data you want to register.</param>
        /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
        /// <returns>The number of rows affected.</returns>
        Task<int> InsertAsync<T>(T data, CancellationToken cancellationToken);

        /// <summary>
        /// Executes an INSERT command using the specified data.
        /// </summary>
        /// <param name="data">The data you want to register.</param>
        /// <param name="excludeKey">If <see langword="true" /> is specified, the <see cref="KeyAttribute">[Key]</see> attributed property will be excluded.</param>
        /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
        /// <returns>The number of rows affected.</returns>
        Task<int> InsertAsync<T>(T data, bool excludeKey, CancellationToken cancellationToken);

        /// <summary>
        /// Executes an INSERT command using the specified data, and returns an inserted identity value.
        /// </summary>
        /// <typeparam name="TReturn">The data type of identity column (primary key).</typeparam>
        /// <typeparam name="TData">
        /// The type of data.
        /// It is recommended to define the <see cref="TableAttribute">[Table]</see> and <see cref="ColumnAttribute">[Column]</see> attribute.
        /// </typeparam>
        /// <param name="data">The data you want to register.</param>
        /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
        /// <returns>Inserted identity value.</returns>
        Task<TReturn?> InsertReturnAsync<TReturn, TData>(TData data, CancellationToken cancellationToken);

        /// <summary>
        /// Executes an INSERT command using the specified data, and returns an inserted identity value.
        /// </summary>
        /// <typeparam name="TReturn">The data type of identity column (primary key).</typeparam>
        /// <typeparam name="TData">
        /// The type of data.
        /// It is recommended to define the <see cref="TableAttribute">[Table]</see> and <see cref="ColumnAttribute">[Column]</see> attribute.
        /// </typeparam>
        /// <param name="data">The data you want to register.</param>
        /// <param name="excludeKey">If <see langword="true" /> is specified, the <see cref="KeyAttribute">[Key]</see> attributed property will be excluded.</param>
        /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
        /// <returns>Inserted identity value.</returns>
        Task<TReturn?> InsertReturnAsync<TReturn, TData>(TData data, bool excludeKey, CancellationToken cancellationToken);

        /// <summary>
        /// Executes an INSERT command using Insert property, and returns an inserted identity value.
        /// </summary>
        /// <typeparam name="T">The data type of identity column (primary key).</typeparam>
        /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
        /// <returns>Inserted identity value.</returns>
        /// <remarks>Use this if the primary key is auto increment.</remarks>
        Task<T?> InsertReturnAsync<T>(CancellationToken cancellationToken);

        /// <summary>
        /// Executes an INSERT command using specified data, and returns an inserted specified returnColumnName value.
        /// </summary>
        /// <typeparam name="T">The data type that returnColumnName represents.</typeparam>
        /// <param name="returnColumnName"></param>
        /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
        /// <returns>Inserted specified returnColumnName value.</returns>
        /// <remarks>Use this if the primary key is auto increment.</remarks>
        Task<T?> InsertReturnAsync<T>(string returnColumnName, CancellationToken cancellationToken);

        /// <summary>
        /// Executes an INSERT command using specified data, and returns an inserted specified returnColumnName value.
        /// </summary>
        /// <typeparam name="TReturn">The data type of identity column (primary key).</typeparam>
        /// <typeparam name="TData">
        /// The type of data.
        /// It is recommended to define the <see cref="TableAttribute">[Table]</see> and <see cref="ColumnAttribute">[Column]</see> attribute.
        /// </typeparam>
        /// <param name="data">The data you want to register.</param>
        /// <param name="returnColumnName"></param>
        /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
        /// <returns>Inserted specified returnColumnName value.</returns>
        Task<TReturn?> InsertReturnAsync<TReturn, TData>(TData data, string returnColumnName, CancellationToken cancellationToken);

        /// <summary>
        /// Executes an INSERT command using specified data.
        /// </summary>
        /// <typeparam name="TReturn">The data type of identity column (primary key).</typeparam>
        /// <typeparam name="TData">
        /// The type of data.
        /// It is recommended to define the <see cref="TableAttribute">[Table]</see> and <see cref="ColumnAttribute">[Column]</see> attribute.
        /// </typeparam>
        /// <param name="data">The data you want to register.</param>
        /// <param name="excludeKey">If <see langword="true" /> is specified, the <see cref="KeyAttribute">[Key]</see> attributed property will be excluded.</param>
        /// <param name="returnColumnName"></param>
        /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
        /// <returns>Inserted specified returnColumnName value.</returns>
        /// <remarks>Use this if the primary key is auto increment.</remarks>
        Task<TReturn?> InsertReturnAsync<TReturn, TData>(TData data, bool excludeKey, string returnColumnName, CancellationToken cancellationToken);

        /// <summary>
        /// Executes a SELECT ALL command and returns records.
        /// </summary>
        /// <typeparam name="T">
        /// The class you want to convert the record to.
        /// It is recommended to define the <see cref="TableAttribute">[Table]</see> and <see cref="ColumnAttribute">[Column]</see> attribute.
        /// </typeparam>
        /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
        /// <returns>A list of records.</returns>
        Task<List<T>> SelectAllAsync<T>(CancellationToken cancellationToken);

        /// <summary>
        /// Executes a SELECT command using Select property, and returns records.
        /// </summary>
        /// <typeparam name="T">
        /// The class you want to convert the record to.
        /// It is recommended to define the <see cref="TableAttribute">[Table]</see> and <see cref="ColumnAttribute">[Column]</see> attribute.
        /// </typeparam>
        /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
        /// <returns>A list of records.</returns>
        Task<List<T>> SelectAsync<T>(CancellationToken cancellationToken);

        /// <summary>
        /// Executes an UPDATE command using Update property.
        /// </summary>
        /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
        /// <returns>The number of rows affected.</returns>
        Task<int> UpdateAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Executes an UPDATE command using the specified data.
        /// </summary>
        /// <typeparam name="T">
        /// The type of data.
        /// It is recommended to define the <see cref="TableAttribute">[Table]</see> and <see cref="ColumnAttribute">[Column]</see> attribute.
        /// The <see cref="KeyAttribute">[Key]</see> attribute must be defined.
        /// </typeparam>
        /// <param name="data">The data you want to update.</param>
        /// <returns>The number of rows affected.</returns>
        /// <exception cref="Exception"><see cref="KeyAttribute">[Key]</see> attribute is not found in <typeparamref name="T"/> class.</exception>
        Task<int> UpdateAsync<T>(T data, CancellationToken cancellationToken);

        /// <summary>
        /// Executes an UPDATE command using the specified data.
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
        Task<int> UpdateAsync<T>(T data, string[] excludeColumns, CancellationToken cancellationToken);

        #endregion
    }
}
