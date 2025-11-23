// ----------------------------------------------------------------------
// @Namespace : Izayoi.Data.Repository
// @Class     : DbRepositoryBase
// ----------------------------------------------------------------------
#nullable enable
namespace Izayoi.Data.Repository
{
    using Izayoi.Data.Query;
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.Common;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Basic DB Repository
    /// </summary>
    public abstract class DbRepositoryBase<TData, TKey> //: IDbRepository
    {
        #region Fields

        /// <summary>The DB data mapper.</summary>
        protected readonly IDbDataMapper _dbDataMapper;

        /// <summary>The DB command adapter.</summary>
        protected readonly IDbCommandAdapter _dbCommandAdapter;

        /// <summary>The dictionary of the command timeout.</summary>
        protected ConcurrentDictionary<int, int> _commandTimeoutDictionary;

        /// <summary>The data type.</summary>
        protected readonly Type _dataType;

        /// <summary>The schema name.</summary>
        protected readonly string _schemaName;

        /// <summary>The table name.</summary>
        protected readonly string _tableName;

        /// <summary>The table source.</summary>
        protected readonly string _tableSource;

        /// <summary>The key name.</summary>
        protected readonly string _keyName;

        /// <summary>The key property.</summary>
        protected readonly MapperPropertyInfo _keyProperty;

        /// <summary>The type of the key.</summary>
        protected readonly Type _keyType;

        /// <summary>The DB type of the key.</summary>
        protected readonly DbType _keyDbType;

        /// <summary>The parameter name of the key.</summary>
        protected readonly string _keyParameterName;

        /// <summary>The count command text.</summary>
        protected readonly string _countCommandText;

        /// <summary>The select all command text.</summary>
        protected readonly string _selectAllCommandText;

        /// <summary>The select command text.</summary>
        protected readonly string _selectCommandText;

        /// <summary>The delete command text.</summary>
        protected readonly string _deleteCommandText;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the DbRepositoryBase class with the specified dbDataMapper and queryOption.
        /// </summary>
        /// <param name="dbDataMapper">A DB data mapper.</param>
        /// <param name="queryOption">A query option.</param>
        public DbRepositoryBase(IDbDataMapper dbDataMapper, QueryOption queryOption)
            : this(new DbCommandAdapter(dbDataMapper, queryOption)) { }

        /// <summary>
        /// Initializes a new instance of the DbRepositoryBase class with the specified dbCommandAdapter.
        /// </summary>
        /// <param name="dbCommandAdapter">A DB command adapter.</param>
        public DbRepositoryBase(IDbCommandAdapter dbCommandAdapter)
        {
            _dbDataMapper = dbCommandAdapter.DbDataMapper;

            _dbCommandAdapter = dbCommandAdapter;

            _commandTimeoutDictionary = new ConcurrentDictionary<int, int>();

            _dataType = typeof(TData);

            (_schemaName, _tableName) = _dbDataMapper.GetSchemaAndTable(_dataType);

            if (string.IsNullOrEmpty(_tableName))
            {
                throw new FormatException("[Table] attribute Name is empty.");
            }

            QueryOption queryOption = dbCommandAdapter.QueryOption;

            _tableSource = GetTableSource(_schemaName, _tableName, queryOption.QuotationMarks);

            PropertyMapper propertyMapper = _dbDataMapper.GetColumnNameMapper(_dataType);

            var key = propertyMapper.FirstOrDefault(p => p.Value.IsKey);

            _keyName = key.Key;

            _keyProperty = key.Value;

            _keyType = typeof(TKey);

            _keyDbType = DbTypeUtility.JudgeDbType(_keyType);

            _keyParameterName = "@key";

            _countCommandText = $"SELECT COUNT(*) FROM {_tableSource}";

            _selectAllCommandText = $"SELECT * FROM {_tableSource}";

            _selectCommandText = $"SELECT * FROM {_tableSource} WHERE {_keyName} = {_keyParameterName}";

            _deleteCommandText = $"DELETE FROM {_tableSource} WHERE {_keyName} = {_keyParameterName}";
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Gets the count of records.
        /// </summary>
        /// <param name="dbConnection">A DB connection.</param>
        /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
        /// <returns>The count of records.</returns>
        public virtual async Task<int> GetCountAsync(DbConnection dbConnection, CancellationToken cancellationToken)
        {
            using DbCommand dbCommand = dbConnection.CreateCommand();

            SetCommandTimeout(dbCommand, QueryType.Count);

            dbCommand.CommandText = _countCommandText;

            return await _dbCommandAdapter.ExecuteScalarAsync<int>(dbCommand, cancellationToken);
        }

        /// <summary>
        /// Gets the data for the specified ID.
        /// </summary>
        /// <param name="dbConnection">A DB connection.</param>
        /// <param name="id">The id.</param>
        /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
        /// <returns>The data.</returns>
        public virtual async Task<TData?> FetchAsync(DbConnection dbConnection, TKey id, CancellationToken cancellationToken)
        {
            using DbCommand dbCommand = dbConnection.CreateCommand();

            SetCommandTimeout(dbCommand, QueryType.SelectOne);

            dbCommand.CommandText = _selectCommandText;

            DbParameter dbParameter = dbCommand.CreateParameter();

            dbParameter.ParameterName = _keyParameterName;
            dbParameter.DbType = _keyDbType;
            dbParameter.Value = id;

            dbCommand.Parameters.Add(dbParameter);

            using DbDataReader dbDataReader = await dbCommand.ExecuteReaderAsync(cancellationToken);

            TData? data = await _dbDataMapper.ReadToObjectAsync<TData>(dbDataReader, cancellationToken);

            return data;
        }

        /// <summary>
        /// Gets the data for the specified IDs.
        /// </summary>
        /// <param name="dbConnection">A DB connection.</param>
        /// <param name="ids">A list of the id.</param>
        /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
        /// <returns>A list of data.</returns>
        public virtual async Task<List<TData>> FetchAsync(DbConnection dbConnection, IEnumerable<TKey> ids, CancellationToken cancellationToken)
        {
            using DbCommand dbCommand = dbConnection.CreateCommand();

            SetCommandTimeout(dbCommand, QueryType.SelectMany);

            var select = new Select()
                .SetFrom(_schemaName, _tableName, string.Empty)
                .AddWhere(_keyName, OpType.IN, ids)
                .AddField("*");

            List<TData> dataList = await _dbCommandAdapter.SelectAsync<TData>(dbCommand, select, cancellationToken);

            return dataList;
        }

        /// <summary>
        /// Gets all the data.
        /// </summary>
        /// <param name="dbConnection">A DB connection.</param>
        /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
        /// <returns>A list of data.</returns>
        public virtual async Task<List<TData>> FetchAllAsync(DbConnection dbConnection, CancellationToken cancellationToken)
        {
            using DbCommand dbCommand = dbConnection.CreateCommand();

            SetCommandTimeout(dbCommand, QueryType.SelectAll);

            dbCommand.CommandText = _selectAllCommandText;

            List<TData> dataList = await _dbCommandAdapter.ExecuteQueryAsync<TData>(dbCommand, cancellationToken);

            return dataList;
        }

        /// <summary>
        /// Executes an INSERT query.
        /// </summary>
        /// <param name="dbConnection">A DB connection.</param>
        /// <param name="data">The data you want to register.</param>
        /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
        /// <returns>The number of rows affected.</returns>
        public virtual async Task<int> InsertAsync(DbConnection dbConnection, TData data, CancellationToken cancellationToken)
        {
            using DbCommand dbCommand = dbConnection.CreateCommand();

            SetCommandTimeout(dbCommand, QueryType.InsertOne);

            int affectedRowCount = await _dbCommandAdapter.InsertAsync(dbCommand, data, cancellationToken);

            return affectedRowCount;
        }

        //public virtual async Task<int> InsertAsync(DbConnection dbConnection, IEnumerable<TData> dataList, CancellationToken cancellationToken)
        //{
        //    using DbCommand dbCommand = dbConnection.CreateCommand();

        //    SetCommandTimeout(dbCommand, QueryType.InsertMany);

        //    int insertedTotalCount = 0;

        //    foreach (TData data in dataList)
        //    {
        //        int affectedRowCount = await _dbCommandAdapter.InsertAsync(dbCommand, data, cancellationToken);

        //        if (affectedRowCount == 1)
        //        {
        //            insertedTotalCount++;
        //        }
        //    }

        //    return insertedTotalCount;
        //}

        /// <summary>
        /// Execute the INSERT query, get the inserted identity value, and set it in the data.
        /// </summary>
        /// <param name="dbConnection">A DB connection.</param>
        /// <param name="data">The data you want to register.</param>
        /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
        /// <returns>Inserted identity value.</returns>
        /// <remarks>Use this if the primary key is auto increment.</remarks>
        public virtual async Task<int> InsertReturnAsync(DbConnection dbConnection, TData data, CancellationToken cancellationToken)
        {
            using DbCommand dbCommand = dbConnection.CreateCommand();

            SetCommandTimeout(dbCommand, QueryType.InsertOne);

            TKey? keyValue = await _dbCommandAdapter.InsertReturnAsync<TKey, TData>(dbCommand, data, excludeKey: true, cancellationToken);

            if (keyValue is null)
            {
                return 0;  // @notice
            }

            _keyProperty.SetValue(data, keyValue);

            return 1;
        }

        //public virtual async Task<int> InsertReturnAsync(DbConnection dbConnection, IEnumerable<TData> dataList, CancellationToken cancellationToken)
        //{
        //    using DbCommand dbCommand = dbConnection.CreateCommand();

        //    SetCommandTimeout(dbCommand, QueryType.InsertMany);

        //    int insertedTotalCount = 0;

        //    foreach (TData data in dataList)
        //    {
        //        TKey? keyValue = await _dbCommandAdapter.InsertReturnAsync<TKey, TData>(dbCommand, data, excludeKey: true, cancellationToken);

        //        if (keyValue is null)
        //        {
        //            continue;
        //        }

        //        _keyProperty.SetValue(data, keyValue);

        //        insertedTotalCount++;
        //    }

        //    return insertedTotalCount;
        //}

        /// <summary>
        /// Executes an UPDATE query.
        /// </summary>
        /// <param name="dbConnection">A DB connection.</param>
        /// <param name="data">The data you want to update.</param>
        /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
        /// <returns>The number of rows affected.</returns>
        public virtual async Task<int> UpdateAsync(DbConnection dbConnection, TData data, CancellationToken cancellationToken)
        {
            using DbCommand dbCommand = dbConnection.CreateCommand();

            SetCommandTimeout(dbCommand, QueryType.UpdateOne);

            int affectedRowCount = await _dbCommandAdapter.UpdateAsync(dbCommand, data, cancellationToken);

            return affectedRowCount;
        }

        //public virtual async Task<int> UpdateAsync(DbConnection dbConnection, IEnumerable<TData> dataList, CancellationToken cancellationToken)
        //{
        //    using DbCommand dbCommand = dbConnection.CreateCommand();

        //    SetCommandTimeout(dbCommand, QueryType.UpdateMany);

        //    int updatedTotalCount = 0;

        //    foreach (TData data in dataList)
        //    {
        //        int affectedRowCount = await _dbCommandAdapter.UpdateAsync(dbCommand, data, cancellationToken);

        //        if (affectedRowCount == 1)
        //        {
        //            updatedTotalCount++;
        //        }
        //    }

        //    return updatedTotalCount;
        //}

        /// <summary>
        /// Executes a DELETE query.
        /// </summary>
        /// <param name="dbConnection">A DB connection.</param>
        /// <param name="id">The key value you want to delete.</param>
        /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
        /// <returns>The number of rows affected.</returns>
        public virtual async Task<int> DeleteAsync(DbConnection dbConnection, TKey id, CancellationToken cancellationToken)
        {
            using DbCommand dbCommand = dbConnection.CreateCommand();

            SetCommandTimeout(dbCommand, QueryType.DeleteOne);

            dbCommand.CommandText = _deleteCommandText;

            DbParameter dbParameter = dbCommand.CreateParameter();

            dbParameter.ParameterName = _keyParameterName;
            dbParameter.DbType = _keyDbType;
            dbParameter.Value = id;

            dbCommand.Parameters.Add(dbParameter);

            int affectedRowCount = await dbCommand.ExecuteNonQueryAsync(cancellationToken);

            return affectedRowCount;
        }

        //public virtual async Task<int> DeleteAsync(DbConnection dbConnection, IEnumerable<TKey> ids, CancellationToken cancellationToken)
        //{
        //    using DbCommand dbCommand = dbConnection.CreateCommand();

        //    SetCommandTimeout(dbCommand, QueryType.DeleteMany);

        //    dbCommand.CommandText = _deleteCommandText;

        //    await dbCommand.PrepareAsync(cancellationToken);

        //    DbParameter dbParameter = dbCommand.CreateParameter();

        //    dbParameter.ParameterName = _keyParameterName;
        //    dbParameter.DbType = _keyDbType;

        //    dbCommand.Parameters.Add(dbParameter);

        //    int deletedTotalCount = 0;

        //    foreach (TKey id in ids)
        //    {
        //        dbParameter.Value = id;

        //        int affectedRowCount = await dbCommand.ExecuteNonQueryAsync(cancellationToken);

        //        if (affectedRowCount == 1)
        //        {
        //            deletedTotalCount++;
        //        }
        //    }

        //    return deletedTotalCount;
        //}

        /// <summary>
        /// Executes a DELETE query.
        /// </summary>
        /// <param name="dbConnection">A DB connection.</param>
        /// <param name="data">The data you want to delete.</param>
        /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
        /// <returns>The number of rows affected.</returns>
        public virtual async Task<int> DeleteAsync(DbConnection dbConnection, TData data, CancellationToken cancellationToken)
        {
            using DbCommand dbCommand = dbConnection.CreateCommand();

            SetCommandTimeout(dbCommand, QueryType.DeleteOne);

            int affectedRowCount = await _dbCommandAdapter.DeleteAsync(dbCommand, data, cancellationToken);

            return affectedRowCount;
        }

        //public virtual async Task<int> DeleteAsync(DbConnection dbConnection, IEnumerable<TData> dataList, CancellationToken cancellationToken)
        //{
        //    using DbCommand dbCommand = dbConnection.CreateCommand();

        //    SetCommandTimeout(dbCommand, QueryType.DeleteMany);

        //    int deletedTotalCount = 0;

        //    foreach (TData data in dataList)
        //    {
        //        int affectedRowCount = await _dbCommandAdapter.DeleteAsync(dbCommand, data, cancellationToken);

        //        if (affectedRowCount == 1)
        //        {
        //            deletedTotalCount++;
        //        }
        //    }

        //    return deletedTotalCount;
        //}

        #endregion

        #region Timeout Methods

        //public enum QueryType
        protected enum QueryType
        {
            None = 0,
            Count = 1,
            SelectOne = 2,
            SelectMany = 3,
            SelectAll = 4,
            InsertOne = 5,
            InsertMany = 6,
            UpdateOne = 7,
            UpdateMany = 8,
            DeleteOne = 9,
            DeleteMany = 10,
        }

        //public virtual int GetCommandTimeout(QueryType queryType)
        //{
        //    return GetCommandTimeout((int)queryType);
        //}

        /// <summary>
        /// Get command timeout.
        /// </summary>
        /// <param name="queryType">A query type.</param>
        /// <returns>The time in seconds to wait for the command to execute.</returns>
        public virtual int GetCommandTimeout(int queryType)
        {
            if (_commandTimeoutDictionary.TryGetValue(queryType, out int timeout))
            {
                return timeout;
            }
            else
            {
                return 0;
            }
        }

        //public virtual void SetCommandTimeout(QueryType queryType, int timeout)
        //{
        //    SetCommandTimeout((int)queryType, timeout);
        //}

        /// <summary>
        /// Set command timeout.
        /// </summary>
        /// <param name="queryType">A query type.</param>
        /// <param name="timeout">The time in seconds to wait for the command to execute.</param>
        public virtual void SetCommandTimeout(int queryType, int timeout)
        {
            if (_commandTimeoutDictionary.TryGetValue(queryType, out int comparisonValue))
            {
                if (timeout < 0)
                {
                    _commandTimeoutDictionary.TryRemove(queryType, out _);
                }
                else
                {
                    if (timeout == comparisonValue)
                    {
                        return;
                    }

                    _commandTimeoutDictionary.TryUpdate(queryType, timeout, comparisonValue);
                }
            }
            else
            {
                _commandTimeoutDictionary.TryAdd(queryType, timeout);
            }
        }

        protected virtual void SetCommandTimeout(DbCommand dbCommand, QueryType queryType)
        {
            SetCommandTimeout(dbCommand, (int)queryType);
        }

        protected virtual void SetCommandTimeout(DbCommand dbCommand, int queryType)
        {
            if (_commandTimeoutDictionary.TryGetValue(queryType, out int timeout))
            {
                if (dbCommand.CommandTimeout == timeout)
                {
                    return;
                }

                dbCommand.CommandTimeout = timeout;
            }
        }

        #endregion

        #region Protected Methods

        protected virtual string GetTableSource(string schemaName, string tableName, QuotationMarkSet quotationMarks)
        {
            string tableSource;

            if (quotationMarks.IsAvailable)
            {
                if (_schemaName.Length == 0)
                {
                    tableSource = quotationMarks.Enclose(tableName);
                }
                else
                {
                    tableSource = $"{quotationMarks.Enclose(schemaName)}.{quotationMarks.Enclose(tableName)}";
                }
            }
            else
            {
                if (_schemaName.Length == 0)
                {
                    tableSource = tableName;
                }
                else
                {
                    tableSource = $"{schemaName}.{tableName}";
                }
            }

            return tableSource;
        }

        #endregion
    }
}
