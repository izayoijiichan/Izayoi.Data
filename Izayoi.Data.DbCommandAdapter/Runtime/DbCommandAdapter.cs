// ----------------------------------------------------------------------
// @Namespace : Izayoi.Data
// @Class     : DbCommandAdapter
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
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// DB Command Adapter
    /// </summary>
    public class DbCommandAdapter : IDbCommandAdapter
    {
        #region Fields

        /// <summary>A DB data mapper.</summary>
        protected readonly IDbDataMapper _dbDataMapper;

        /// <summary>A query option.</summary>
        protected readonly QueryOption _queryOption;

        #endregion

        #region Constructors

        //public DbCommandAdapter() { }

        /// <summary>
        /// Initializes a new instance of the DbCommandAdapter class with the specified dbDataMapper.
        /// </summary>
        /// <param name="dbDataMapper">A DB data mapper.</param>
        public DbCommandAdapter(IDbDataMapper dbDataMapper)
        {
            _dbDataMapper = dbDataMapper;

            _queryOption = new QueryOption();
        }

        /// <summary>
        /// Initializes a new instance of the DbCommandAdapter class with the specified dbDataMapper and queryOption.
        /// </summary>
        /// <param name="dbDataMapper">A DB data mapper.</param>
        /// <param name="queryOption">A query option.</param>
        public DbCommandAdapter(IDbDataMapper dbDataMapper, QueryOption queryOption)
        {
            _dbDataMapper = dbDataMapper;

            _queryOption = queryOption;
        }

        #endregion

        #region Properties

        /// <summary>Gets the DB data mapper.</summary>
        public virtual IDbDataMapper DbDataMapper => _dbDataMapper;

        /// <summary>Gets the query option.</summary>
        public virtual QueryOption QueryOption =>  _queryOption;

        #endregion

        #region Parameter Methods

        /// <summary>
        /// Add specified bind parameters to the specified DB command.
        /// </summary>
        /// <param name="dbCommand">A DB command.</param>
        /// <param name="bindParameters">Bind parameter collection.</param>
        protected virtual void AddBindParameters(DbCommand dbCommand, IBindParameterCollection bindParameters)
        {
            //dbCommand.Parameters.Clear();

            foreach (BindParameter bindParameter in bindParameters)
            {
                DbParameter dbParameter = dbCommand.CreateParameter();

                dbParameter.ParameterName = bindParameter.ParameterName;
                dbParameter.DbType = bindParameter.DbType;
                //dbParameter.Direction = bindParameter.Direction;
                //dbParameter.IsNullable = bindParameter.IsNullable;
                //dbParameter.Precision = bindParameter.Precision;
                //dbParameter.Scale = bindParameter.Scale;
                ////dbParameter.Size = bindParameter.Size;  // @notice
                //dbParameter.SourceColumn = bindParameter.SourceColumn;
                //dbParameter.SourceColumnNullMapping = bindParameter.SourceColumnNullMapping;
                //dbParameter.SourceVersion = bindParameter.SourceVersion;
                dbParameter.Value = bindParameter.Value;

                dbCommand.Parameters.Add(dbParameter);
            }
        }

        #endregion

        #region Build Delete Command Methods

        /// <summary>
        /// Builds a DELETE query for the specified DB command using specified delete source.
        /// </summary>
        /// <param name="dbCommand">A DB command.</param>
        /// <param name="delete">A Delete source.</param>
        /// <returns><see langword="true" /> if the build is successful; <see langword="false" /> otherwise.</returns>
        public virtual bool BuildDeleteCommand(DbCommand dbCommand, Delete delete)
        {
            var queryBuilder = new DeleteQueryBuilder(_queryOption);

            bool buildResult = queryBuilder.Build(delete);

            if (buildResult == false)
            {
                return false;
            }

            dbCommand.CommandType = CommandType.Text;

            dbCommand.CommandText = queryBuilder.GetQuery();

            dbCommand.Parameters.Clear();

            AddBindParameters(dbCommand, queryBuilder.GetParameters());

            return true;
        }

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
        public virtual bool BuildDeleteCommand<T>(DbCommand dbCommand, T data)
        {
            Delete delete = CreateDelete(data);

            return BuildUpdateCommand(dbCommand, delete);
        }

        #endregion

        #region Build Insert Command Methods

        /// <summary>
        /// Builds an INSERT query for the specified DB command using specified insert source.
        /// </summary>
        /// <param name="dbCommand">A DB command.</param>
        /// <param name="insert">An Insert source.</param>
        /// <returns><see langword="true" /> if the build is successful; <see langword="false" /> otherwise.</returns>
        public virtual bool BuildInsertCommand(DbCommand dbCommand, Insert insert)
        {
            var queryBuilder = new InsertQueryBuilder(_queryOption);

            bool buildResult = queryBuilder.Build(insert);

            if (buildResult == false)
            {
                return false;
            }

            dbCommand.CommandType = CommandType.Text;

            dbCommand.CommandText = queryBuilder.GetQuery();

            dbCommand.Parameters.Clear();

            AddBindParameters(dbCommand, queryBuilder.GetParameters());

            return true;
        }

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
        public virtual bool BuildInsertCommand<T>(DbCommand dbCommand, T data, bool excludeKey = false)
        {
            Insert insert = CreateInsert(data, excludeKey);

            return BuildInsertCommand(dbCommand, insert);
        }

        #endregion

        #region Build Select Command Methods

        /// <summary>
        /// Builds a SELECT query for the specified DB command using specified select source.
        /// </summary>
        /// <param name="dbCommand">A DB command.</param>
        /// <param name="select">A Select source.</param>
        /// <returns><see langword="true" /> if the build is successful; <see langword="false" /> otherwise.</returns>
        public virtual bool BuildSelectCommand(DbCommand dbCommand, Select select)
        {
            var queryBuilder = new SelectQueryBuilder(_queryOption);

            bool buildResult = queryBuilder.Build(select);

            if (buildResult == false)
            {
                return false;
            }

            dbCommand.CommandType = CommandType.Text;

            dbCommand.CommandText = queryBuilder.GetQuery();

            dbCommand.Parameters.Clear();

            AddBindParameters(dbCommand, queryBuilder.GetParameters());

            return true;
        }

        #endregion

        #region Build Update Command Methods

        /// <summary>
        /// Builds an UPDATE query for the specified DB command using specified update source.
        /// </summary>
        /// <param name="dbCommand">A DB command.</param>
        /// <param name="update">An Update source.</param>
        /// <returns><see langword="true" /> if the build is successful; <see langword="false" /> otherwise.</returns>
        public virtual bool BuildUpdateCommand(DbCommand dbCommand, Update update)
        {
            var queryBuilder = new UpdateQueryBuilder(_queryOption);

            bool buildResult = queryBuilder.Build(update);

            if (buildResult == false)
            {
                return false;
            }

            dbCommand.CommandType = CommandType.Text;

            dbCommand.CommandText = queryBuilder.GetQuery();

            dbCommand.Parameters.Clear();

            AddBindParameters(dbCommand, queryBuilder.GetParameters());

            return true;
        }

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
        public virtual bool BuildUpdateCommand<T>(DbCommand dbCommand, T data, string[]? excludeColumns = null)
        {
            Update update = CreateUpdate(data, excludeColumns);

            return BuildUpdateCommand(dbCommand, update);
        }

        #endregion

        #region Create Dml Methods

        /// <summary>
        /// Create Insert class using specified data.
        /// </summary>
        /// <typeparam name="T">
        /// The type of data.
        /// It is recommended to define the <see cref="TableAttribute">[Table]</see> and <see cref="ColumnAttribute">[Column]</see> attribute.
        /// </typeparam>
        /// <param name="data">The data you want to register.</param>
        /// <param name="excludeKey">If <see langword="true" /> is specified, the <see cref="KeyAttribute">[Key]</see> attributed property will be excluded.</param>
        /// <returns>An Insert class.</returns>
        protected virtual Insert CreateInsert<T>(T data, bool excludeKey)
        {
            Insert insert = new();

            Type type = typeof(T);

            (string schemaName, string tableName) = _dbDataMapper.GetSchemaAndTable(type);

            insert.SetInto(schemaName, tableName, string.Empty);

            PropertyMapper columnNameMapper = _dbDataMapper.GetColumnNameMapper(type);

            foreach ((string columnName, MapperPropertyInfo property) in columnNameMapper)
            {
                if (property.CanRead == false)
                {
                    continue;
                }

                if (property.IsNotMapped)
                {
                    continue;
                }

                if (excludeKey && property.IsKey)
                {
                    continue;
                }

                if (property.UnderlyingType is null)
                {
                    insert.AddValue(columnName, property.GetValue(data));
                }
                else
                {
                    insert.AddValue(columnName, property.GetValue(data), DbTypeUtility.JudgeDbType(property.UnderlyingType));
                }
            }

            return insert;
        }

        /// <summary>
        /// Create Update class using specified data.
        /// </summary>
        /// <typeparam name="T">
        /// The type of data.
        /// It is recommended to define the <see cref="TableAttribute">[Table]</see> and <see cref="ColumnAttribute">[Column]</see> attribute.
        /// The <see cref="KeyAttribute">[Key]</see> attribute must be defined.
        /// </typeparam>
        /// <param name="data">The data you want to update.</param>
        /// <param name="excludeColumns">Specify the column names (property names) you want to exclude from updating.</param>
        /// <returns>An Update class.</returns>
        /// <exception cref="Exception"><see cref="KeyAttribute">[Key]</see> attribute is not found in <typeparamref name="T"/> class.</exception>
        protected virtual Update CreateUpdate<T>(T data, string[]? excludeColumns = null)
        {
            Update update = new();

            Type type = typeof(T);

            (string schemaName, string tableName) = _dbDataMapper.GetSchemaAndTable(type);

            update.SetTable(schemaName, tableName, string.Empty);

            PropertyMapper columnNameMapper = _dbDataMapper.GetColumnNameMapper(type);

            foreach ((string columnName, MapperPropertyInfo property) in columnNameMapper)
            {
                if (excludeColumns is not null && excludeColumns.Contains(columnName))
                {
                    continue;
                }

                if (property.CanRead == false)
                {
                    continue;
                }

                if (property.IsNotMapped)
                {
                    continue;
                }

                if (property.IsKey)
                {
                    update.AddWhere(columnName, "=", property.GetValue(data));

                    continue;
                }
                else
                {
                    if (property.UnderlyingType is null)
                    {
                        update.AddSet(columnName, property.GetValue(data));
                    }
                    else
                    {
                        update.AddSet(columnName, property.GetValue(data), DbTypeUtility.JudgeDbType(property.UnderlyingType));
                    }
                }
            }

            if (update.Wheres.Count == 0)
            {
                throw new Exception($"{type.Name}: [Key] attribute is not found.");
            }

            return update;
        }

        /// <summary>
        /// Create Delete class using specified data.
        /// </summary>
        /// <typeparam name="T">
        /// The type of data.
        /// It is recommended to define the <see cref="TableAttribute">[Table]</see>.
        /// The <see cref="KeyAttribute">[Key]</see> attribute must be defined.
        /// </typeparam>
        /// <param name="data">The data you want to delete.</param>
        /// <returns>A Delete class.</returns>
        /// <exception cref="Exception"><see cref="KeyAttribute">[Key]</see> attribute is not found in <typeparamref name="T"/> class.</exception>
        protected virtual Delete CreateDelete<T>(T data)
        {
            Delete delete = new();

            Type type = typeof(T);

            (string schemaName, string tableName) = _dbDataMapper.GetSchemaAndTable(type);

            delete.SetFrom(schemaName, tableName, string.Empty);

            PropertyMapper columnNameMapper = _dbDataMapper.GetColumnNameMapper(type);

            foreach ((string columnName, MapperPropertyInfo property) in columnNameMapper)
            {
                if (property.IsKey)
                {
                    delete.AddWhere(columnName, "=", property.GetValue(data));
                }
            }

            if (delete.Wheres.Count == 0)
            {
                throw new Exception($"{type.Name}: [Key] attribute is not found.");
            }

            return delete;
        }

        #endregion

        #region Execute Query Methods

        /// <summary>
        /// Executes specified DB command, and returns the records.
        /// </summary>
        /// <typeparam name="T">The class you want to convert the record to.</typeparam>
        /// <param name="dbCommand">A DB command with a SELECT query.</param>
        /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
        /// <returns>A list of records.</returns>
        public virtual async Task<List<T>> ExecuteQueryAsync<T>(DbCommand dbCommand, CancellationToken cancellationToken)
        {
            using DbDataReader dbDataReader = await dbCommand.ExecuteReaderAsync(cancellationToken);

            cancellationToken.ThrowIfCancellationRequested();

            return await _dbDataMapper.ReadToObjectsAsync<T>(dbDataReader, cancellationToken);
        }

        #endregion

        #region Execute Scalar Methods

        /// <summary>
        /// Executes specified DB command, and returns the first columns of the first row in the first returned result set.
        /// </summary>
        /// <typeparam name="T">Type of the first columns.</typeparam>
        /// <param name="dbCommand">A DB command.</param>
        /// <returns>The first columns of the first row in the first result set.</returns>
        public virtual T? ExecuteScalar<T>(DbCommand dbCommand)
        {
            object? obj = dbCommand.ExecuteScalar();

            if (obj is null)
            {
                return default;
            }

            if (obj is DBNull)
            {
                return default;
            }

            return (T)Convert.ChangeType(obj, typeof(T))!;
        }

        /// <summary>
        /// Executes specified DB command, and returns the first columns of the first row in the first returned result set.
        /// </summary>
        /// <typeparam name="T">Type of the first columns.</typeparam>
        /// <param name="dbCommand">A DB command.</param>
        /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
        /// <returns>The first columns of the first row in the first result set.</returns>
        public virtual async Task<T?> ExecuteScalarAsync<T>(DbCommand dbCommand, CancellationToken cancellationToken)
        {
            object? obj = await dbCommand.ExecuteScalarAsync(cancellationToken);

            if (obj is null)
            {
                return default;
            }

            if (obj is DBNull)
            {
                return default;
            }

            return (T)Convert.ChangeType(obj, typeof(T))!;
        }

        /// <summary>
        /// Executes specified DB command using specified select source, and returns the first columns of the first row in the first returned result set.
        /// </summary>
        /// <typeparam name="T">Type of the first columns.</typeparam>
        /// <param name="dbCommand">A DB command.</param>
        /// <param name="select">A Select class.</param>
        /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
        /// <returns>The first columns of the first row in the first result set.</returns>
        public virtual async Task<T?> ExecuteScalarAsync<T>(DbCommand dbCommand, Select select, CancellationToken cancellationToken)
        {
            BuildSelectCommand(dbCommand, select);

            return await ExecuteScalarAsync<T>(dbCommand, cancellationToken);
        }

        #endregion

        #region Delete Methods

        /// <summary>
        /// Executes a DELETE query for the specified DB command using specified delete source.
        /// </summary>
        /// <param name="dbCommand">A DB command.</param>
        /// <param name="delete">A Delete source.</param>
        /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
        /// <returns>The number of rows affected.</returns>
        public virtual async Task<int> DeleteAsync(DbCommand dbCommand, Delete delete, CancellationToken cancellationToken)
        {
            BuildDeleteCommand(dbCommand, delete);

            int affectedRowsCount = await dbCommand.ExecuteNonQueryAsync(cancellationToken);

            return affectedRowsCount;
        }

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
        public virtual async Task<int> DeleteAsync<T>(DbCommand dbCommand, T data, CancellationToken cancellationToken)
        {
            if (data is Delete delete)
            {
                return await DeleteAsync(dbCommand, delete, cancellationToken);
            }

            delete = CreateDelete(data);

            if (delete.Wheres.Count == 0)
            {
                throw new Exception($"{typeof(T).Name}: [Key] attribute is not found.");
            }

            return await DeleteAsync(dbCommand, delete, cancellationToken);
        }

        #endregion

        #region Insert Methods

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
        public virtual async Task<int> InsertAsync<T>(DbCommand dbCommand, T data, CancellationToken cancellationToken)
        {
            if (data is Insert insert)
            {
                return await InsertAsync(dbCommand, insert, cancellationToken);
            }

            insert = CreateInsert(data, excludeKey: false);

            return await InsertAsync(dbCommand, insert, cancellationToken);
        }

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
        public virtual async Task<int> InsertAsync<T>(DbCommand dbCommand, T data, bool excludeKey, CancellationToken cancellationToken)
        {
            if (data is Insert insert)
            {
                if (excludeKey)
                {
                    throw new Exception();
                }

                return await InsertAsync(dbCommand, insert, cancellationToken);
            }

            insert = CreateInsert(data, excludeKey);

            return await InsertAsync(dbCommand, insert, cancellationToken);
        }

        /// <summary>
        /// Builds an INSERT query for the specified DB command using specified insert source.
        /// </summary>
        /// <param name="dbCommand">A DB command.</param>
        /// <param name="insert">An Insert source.</param>
        /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
        /// <returns>The number of rows affected.</returns>
        public virtual async Task<int> InsertAsync(DbCommand dbCommand, Insert insert, CancellationToken cancellationToken)
        {
            BuildInsertCommand(dbCommand, insert);

            int affectedRowsCount = await dbCommand.ExecuteNonQueryAsync(cancellationToken);

            return affectedRowsCount;
        }

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
        /// <remarks>Use this if the primary key is auto increment.</remarks>
        public virtual async Task<TReturn?> InsertReturnAsync<TReturn, TData>(DbCommand dbCommand, TData data, CancellationToken cancellationToken)
        {
            if (data is Insert insert)
            {
                //
            }
            else
            {
                insert = CreateInsert(data, excludeKey: false);  // @notice
            }

            return await InsertReturnAsync<TReturn>(dbCommand, insert, cancellationToken);
        }

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
        public virtual async Task<TReturn?> InsertReturnAsync<TReturn, TData>(DbCommand dbCommand, TData data, bool excludeKey, CancellationToken cancellationToken)
        {
            if (data is Insert insert)
            {
                if (excludeKey)
                {
                    throw new Exception();
                }
            }
            else
            {
                insert = CreateInsert(data, excludeKey);
            }

            return await InsertReturnAsync<TReturn>(dbCommand, insert, cancellationToken);
        }

        /// <summary>
        /// Executes an INSERT query for the specified DB command using specified insert source, and returns an inserted identity value.
        /// </summary>
        /// <typeparam name="T">The data type of identity column (primary key).</typeparam>
        /// <param name="dbCommand">A DB command.</param>
        /// <param name="insert">An Insert source.</param>
        /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
        /// <returns>Inserted identity value.</returns>
        /// <remarks>Use this if the primary key is auto increment.</remarks>
        public virtual async Task<T?> InsertReturnAsync<T>(DbCommand dbCommand, Insert insert, CancellationToken cancellationToken)
        {
            BuildInsertCommand(dbCommand, insert);

            if (QueryOption.RdbKind == RdbKind.Pgsql)
            {
                throw new NotSupportedException();
            }
            else if (QueryOption.RdbKind == RdbKind.Mysql)
            {
                if (dbCommand.CommandText.EndsWith(';') == false)
                {
                    dbCommand.CommandText += ";";
                }

                dbCommand.CommandText += "SELECT LAST_INSERT_ID();";

                return await ExecuteScalarAsync<T>(dbCommand, cancellationToken);
            }
            else if (QueryOption.RdbKind == RdbKind.Oracle)
            {
                throw new NotSupportedException();
            }
            else if (_queryOption.RdbKind == RdbKind.Sqlite)
            {
                if (dbCommand.CommandText.EndsWith(';') == false)
                {
                    dbCommand.CommandText += ";";
                }

                dbCommand.CommandText += $"SELECT LAST_INSERT_ROWID();";

                return await ExecuteScalarAsync<T>(dbCommand, cancellationToken);
            }
            else if (QueryOption.RdbKind == RdbKind.SqlServer)
            {
                if (dbCommand.CommandText.EndsWith(';') == false)
                {
                    dbCommand.CommandText += ";";
                }

                dbCommand.CommandText += "SELECT SCOPE_IDENTITY();";

                return await ExecuteScalarAsync<T>(dbCommand, cancellationToken);
            }

            throw new NotSupportedException();
        }

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
        public virtual async Task<T?> InsertReturnAsync<T>(DbCommand dbCommand, Insert insert, string returnColumnName, CancellationToken cancellationToken)
        {
            BuildInsertCommand(dbCommand, insert);

            if (QueryOption.RdbKind == RdbKind.Pgsql)
            {
                if (dbCommand.CommandText.EndsWith(';'))
                {
                    dbCommand.CommandText.TrimEnd(';');
                }

                // @notice
                if (returnColumnName.Length == 0)
                {
                    returnColumnName = "id";
                }

                dbCommand.CommandText += $" RETURNING {returnColumnName};";

                return await ExecuteScalarAsync<T>(dbCommand, cancellationToken);
            }
            else if (QueryOption.RdbKind == RdbKind.Mysql)
            {
                throw new NotSupportedException();
            }
            else if (QueryOption.RdbKind == RdbKind.Oracle)
            {
                throw new NotSupportedException();
            }
            else if (QueryOption.RdbKind == RdbKind.Sqlite)
            {
                if (dbCommand.CommandText.EndsWith(';') == false)
                {
                    dbCommand.CommandText += ";";
                }

                dbCommand.CommandText += $"SELECT {returnColumnName} FROM {insert.Into.GetSchemaDotTableOrAlias(_queryOption.QuotationMarks)} WHERE ROWID = LAST_INSERT_ROWID();";

                return await ExecuteScalarAsync<T>(dbCommand, cancellationToken);
            }
            else if (QueryOption.RdbKind == RdbKind.SqlServer)
            {
                throw new NotSupportedException();
            }

            throw new NotSupportedException();
        }

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
        public virtual async Task<TReturn?> InsertReturnAsync<TReturn, TData>(DbCommand dbCommand, TData data, string returnColumnName, CancellationToken cancellationToken)
        {
            if (data is Insert insert)
            {
                //
            }
            else
            {
                insert = CreateInsert(data, excludeKey: false);  // @notice
            }

            return await InsertReturnAsync<TReturn>(dbCommand, insert, returnColumnName, cancellationToken);
        }

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
        public virtual async Task<TReturn?> InsertReturnAsync<TReturn, TData>(DbCommand dbCommand, TData data, bool excludeKey, string returnColumnName, CancellationToken cancellationToken)
        {
            if (data is Insert insert)
            {
                if (excludeKey)
                {
                    throw new Exception();
                }
            }
            else
            {
                insert = CreateInsert(data, excludeKey);
            }

            return await InsertReturnAsync<TReturn>(dbCommand, insert, returnColumnName, cancellationToken);
        }

        #endregion

        #region Select Methods

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
        public virtual async Task<List<T>> SelectAllAsync<T>(DbCommand dbCommand, CancellationToken cancellationToken)
        {
            (string schemaName, string tableName) = _dbDataMapper.GetSchemaAndTable(typeof(T));

            string tableSource;

            if (_queryOption.QuotationMarks.IsAvailable)
            {
                if (schemaName.Length == 0)
                {
                    tableSource = _queryOption.QuotationMarks.Enclose(tableName);
                }
                else
                {
                    tableSource = $"{_queryOption.QuotationMarks.Enclose(schemaName)}.{_queryOption.QuotationMarks.Enclose(tableName)}";
                }
            }
            else
            {
                if (schemaName.Length == 0)
                {
                    tableSource = tableName;
                }
                else
                {
                    tableSource = $"{schemaName}.{tableName}";
                }
            }

            dbCommand.Parameters.Clear();

            dbCommand.CommandType = CommandType.Text;

            dbCommand.CommandText = $"SELECT * FROM {tableSource}";

            return await ExecuteQueryAsync<T>(dbCommand, cancellationToken);
        }

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
        public virtual async Task<List<T>> SelectAsync<T>(DbCommand dbCommand, Select select, CancellationToken cancellationToken)
        {
            // @notice
            if (select.From.TableName.Length == 0)
            {
                (string schemaName, string tableName) = _dbDataMapper.GetSchemaAndTable(typeof(T));

                select.From.SchemaName = schemaName;
                select.From.TableName = tableName;
            }

            BuildSelectCommand(dbCommand, select);

            return await ExecuteQueryAsync<T>(dbCommand, cancellationToken);
        }

        #endregion

        #region Update Methods

        /// <summary>
        /// Executes an UPDATE query for the specified DB command using specified update source.
        /// </summary>
        /// <param name="dbCommand">A DB command.</param>
        /// <param name="update">An Update source.</param>
        /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
        /// <returns>The number of rows affected.</returns>
        public virtual async Task<int> UpdateAsync(DbCommand dbCommand, Update update, CancellationToken cancellationToken)
        {
            if (update.Sets.Count == 0)
            {
                return 0;
            }

            BuildUpdateCommand(dbCommand, update);

            int affectedRowsCount = await dbCommand.ExecuteNonQueryAsync(cancellationToken);

            return affectedRowsCount;
        }

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
        public virtual async Task<int> UpdateAsync<T>(DbCommand dbCommand, T data, CancellationToken cancellationToken)
        {
            if (data is Update update)
            {
                return await UpdateAsync(dbCommand, update, cancellationToken);
            }

            update = CreateUpdate(data, excludeColumns: null);

            if (update.Wheres.Count == 0)
            {
                throw new Exception($"{typeof(T).Name}: [Key] attribute is not found.");
            }

            return await UpdateAsync(dbCommand, update, cancellationToken);
        }

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
        public virtual async Task<int> UpdateAsync<T>(DbCommand dbCommand, T data, string[] excludeColumns, CancellationToken cancellationToken)
        {
            if (data is Update update)
            {
                return await UpdateAsync(dbCommand, update, excludeColumns, cancellationToken);
            }

            update = CreateUpdate(data, excludeColumns);

            if (update.Wheres.Count == 0)
            {
                throw new Exception($"{typeof(T).Name}: [Key] attribute is not found.");
            }

            return await UpdateAsync(dbCommand, update, cancellationToken);
        }

        #endregion
    }
}
