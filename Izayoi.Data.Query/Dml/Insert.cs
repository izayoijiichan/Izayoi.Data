// ----------------------------------------------------------------------
// @Namespace : Izayoi.Data.Query
// @Class     : Insert
// ----------------------------------------------------------------------
namespace Izayoi.Data.Query
{
    using System.Data;

    /// <summary>
    /// Insert
    /// </summary>
    public class Insert
    {
        #region Fields

        private readonly TableSource _into;

        private readonly Values _values;

        private Fields? _columns;

        private Select? _select;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the Insert class.
        /// </summary>
        public Insert()
        {
            _into = new TableSource();

            _values = new Values();

            _select = null;
        }

        /// <summary>
        /// Initializes a new instance of the Insert class with the specified tableName.
        /// </summary>
        /// <param name="tableName">The table name.</param>
        public Insert(string tableName)
        {
            _into = new TableSource(tableName);

            _values = new Values();

            _select = null;
        }

        /// <summary>
        /// Initializes a new instance of the Insert class with the specified tableName and tableAlias.
        /// </summary>
        /// <param name="tableName">The table name.</param>
        /// <param name="tableAlias">The table alias.</param>
        public Insert(string tableName, string tableAlias)
        {
            _into = new TableSource(tableName, tableAlias);

            _values = new Values();

            _select = null;
        }

        /// <summary>
        /// Initializes a new instance of the Insert class with the specified schemaName, tableName and tableAlias.
        /// </summary>
        /// <param name="schemaName">The schema name.</param>
        /// <param name="tableName">The table name.</param>
        /// <param name="tableAlias">The table alias.</param>
        public Insert(string schemaName, string tableName, string tableAlias)
        {
            _into = new TableSource(schemaName, tableName, tableAlias);

            _values = new Values();

            _select = null;
        }

        #endregion

        #region Properties

        /// <summary>INSERT clause</summary>
        public TableSource Into => _into;

        /// <summary>VALUES clause</summary>
        /// <remarks>It cannot be used when using the SELECT clause.</remarks>
        public Values Values => _values;

        /// <summary>column list</summary>
        /// <remarks>Use only when using a SELECT clause.</remarks>
        public Fields? ColumnList
        {
            get => _columns;
            set => _columns = value;
        }

        /// <summary>SELECT clause (dml table source)</summary>
        /// <remarks>It cannot be used when using the VALUES clause.</remarks>
        public Select? Select
        {
            get => _select;
            set => _select = value;
        }

        #endregion

        #region Methods

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tableName">The table name.</param>
        /// <returns></returns>
        public Insert SetInto(string tableName)
        {
            return SetInto(string.Empty, tableName, string.Empty);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tableName">The table name.</param>
        /// <param name="tableAlias">The table alias.</param>
        /// <returns></returns>
        public Insert SetInto(string tableName, string tableAlias)
        {
            return SetInto(string.Empty, tableName, tableAlias);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="schemaName">The schema name.</param>
        /// <param name="tableName">The table name.</param>
        /// <param name="tableAlias">The table alias.</param>
        /// <returns></returns>
        public Insert SetInto(string schemaName, string tableName, string tableAlias)
        {
            _into.SchemaName = schemaName;
            _into.TableName = tableName;
            _into.TableAlias = tableAlias;

            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="columnName">The column name.</param>
        /// <returns></returns>
        public Insert AddColumn(string columnName)
        {
            _columns ??= new Fields(4);

            _columns.Add(columnName);

            return this;
        }

        public Insert AddValue(Value value)
        {
            _values.Add(value);

            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="columnName">The column name.</param>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public Insert AddValue(string columnName, object? value)
        {
            _values.Add(columnName, value);

            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="columnName">The column name.</param>
        /// <param name="value">The value.</param>
        /// <param name="dbType">The DB type of value.</param>
        /// <returns></returns>
        public Insert AddValue(string columnName, object? value, DbType dbType)
        {
            _values.Add(columnName, value, dbType);

            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="columnName">The column name.</param>
        /// <param name="value">The value.</param>
        /// <param name="isExpression">Whether value is expression.</param>
        /// <returns></returns>
        public Insert AddValue(string columnName, object? value, bool isExpression)
        {
            _values.Add(columnName, value, isExpression);

            return this;
        }

        public Insert ClearValues()
        {
            _values.Clear();

            return this;
        }

        #endregion
    }
}
