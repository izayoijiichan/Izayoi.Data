// ----------------------------------------------------------------------
// @Namespace : Izayoi.Data.Query
// @Class     : Update
// ----------------------------------------------------------------------
namespace Izayoi.Data.Query
{
    using System.Data;

    /// <summary>
    /// Update
    /// </summary>
    public class Update
    {
        #region Fields

        private readonly TableSource _tableSource;

        private readonly Sets _sets;

        private From? _from;

        private readonly Wheres _wheres;

        private readonly With _with;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the Update class.
        /// </summary>
        public Update()
        {
            _tableSource = new TableSource();

            _sets = new Sets();

            _wheres = new Wheres(1);

            _with = new With();
        }

        /// <summary>
        /// Initializes a new instance of the Update class with the specified tableName.
        /// </summary>
        /// <param name="tableName">The table name.</param>
        public Update(string tableName)
        {
            _tableSource = new TableSource(string.Empty, tableName, string.Empty);

            _sets = new Sets();

            _wheres = new Wheres(1);

            _with = new With();
        }

        /// <summary>
        /// Initializes a new instance of the Update class with the specified tableName and tableAlias.
        /// </summary>
        /// <param name="tableName">The table name.</param>
        /// <param name="tableAlias">The table alias.</param>
        public Update(string tableName, string tableAlias)
        {
            _tableSource = new TableSource(string.Empty, tableName, tableAlias);

            _sets = new Sets();

            _wheres = new Wheres(1);

            _with = new With();
        }

        /// <summary>
        /// Initializes a new instance of the Update class with the specified schemaName, tableName and tableAlias.
        /// </summary>
        /// <param name="schemaName">The schema name.</param>
        /// <param name="tableName">The table name.</param>
        /// <param name="tableAlias">The table alias.</param>
        public Update(string schemaName, string tableName, string tableAlias)
        {
            _tableSource = new TableSource(schemaName, tableName, tableAlias);

            _sets = new Sets();

            _wheres = new Wheres(1);

            _with = new With();
        }

        #endregion

        #region Properties

        /// <summary>UPDATE clause and JOIN clause</summary>
        public TableSource TableSource => _tableSource;

        /// <summary>SET clause</summary>
        public Sets Sets => _sets;

        /// <summary>FROM clause and JOIN clause</summary>
        /// <remarks>Used when using a JOIN clause in PostgreSQL, SQLite and SQL Server.</remarks>
        public From? From
        {
            get => _from;
            set => _from = value;
        }

        /// <summary>WHERE clause</summary>
        public Wheres Wheres => _wheres;

        /// <summary>With clause</summary>
        public With With => _with;

        #endregion

        #region Methods

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tableName">The table name.</param>
        /// <returns></returns>
        public Update SetTable(string tableName)
        {
            _tableSource.TableName = tableName;

            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tableName">The table name.</param>
        /// <param name="tableAlias">The table alias.</param>
        /// <returns></returns>
        public Update SetTable(string tableName, string tableAlias)
        {
            return SetTable(schemaName: string.Empty, tableName, tableAlias);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="schemaName">The schema name.</param>
        /// <param name="tableName">The table name.</param>
        /// <param name="tableAlias">The table alias.</param>
        /// <returns></returns>
        public Update SetTable(string schemaName, string tableName, string tableAlias)
        {
            _tableSource.SchemaName = schemaName;
            _tableSource.TableName = tableName;
            _tableSource.TableAlias = tableAlias;

            return this;
        }

        #endregion

        #region Set Methods

        public Update AddSet(Set set)
        {
            _sets.Add(set);

            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="columnName">The column name.</param>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public Update AddSet(string columnName, object? value)
        {
            _sets.Add(columnName, value);

            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="columnName">The column name.</param>
        /// <param name="value">The value.</param>
        /// <param name="dbType">The DB type of value.</param>
        /// <returns></returns>
        public Update AddSet(string columnName, object? value, DbType dbType)
        {
            _sets.Add(columnName, value, dbType);

            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="columnName">The column name.</param>
        /// <param name="value">The value.</param>
        /// <param name="isExpression">Whether value is expression.</param>
        /// <returns></returns>
        public Update AddSet(string columnName, object? value, bool isExpression)
        {
            _sets.Add(columnName, value, isExpression);

            return this;
        }

        public Update ClearSets()
        {
            _sets.Clear();

            return this;
        }

        #endregion

        #region From Methods

        //public Update SetFrom(From from)
        //{
        //    _from = from;

        //    return this;
        //}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tableName">The table name.</param>
        /// <returns></returns>
        public Update SetFrom(string tableName)
        {
            return SetFrom(schemaName: string.Empty, tableName, tableAlias: string.Empty);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tableName">The table name.</param>
        /// <param name="tableAlias">The table alias.</param>
        /// <returns></returns>
        public Update SetFrom(string tableName, string tableAlias)
        {
            return SetFrom(schemaName: string.Empty, tableName, tableAlias);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="schemaName">The schema name.</param>
        /// <param name="tableName">The table name.</param>
        /// <param name="tableAlias">The table alias.</param>
        /// <returns></returns>
        public Update SetFrom(string schemaName, string tableName, string tableAlias)
        {
            if (_from is null)
            {
                _from = new From(schemaName, tableName, tableAlias);
            }
            else
            {
                _from.SchemaName = schemaName;
                _from.TableName = tableName;
                _from.TableAlias = tableAlias;
            }

            return this;
        }

        #endregion

        #region Join Methods

        public Update AddJoin(Join item)
        {
            if (_from is null)
            {
                _tableSource.Joins.Add(item);
            }
            else
            {
                _from.Joins.Add(item);
            }

            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type">The join type.</param>
        /// <param name="tableName">The table name.</param>
        /// <param name="condition">The search condition.</param>
        /// <returns></returns>
        public Update AddJoin(JType type, string tableName, string condition)
        {
            if (_from is null)
            {
                _tableSource.Joins.Add(new Join(type, tableName, condition));
            }
            else
            {
                _from.Joins.Add(new Join(type, tableName, condition));
            }

            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type">The join type.</param>
        /// <param name="tableName">The table name.</param>
        /// <param name="tableAlias">The table alias.</param>
        /// <param name="condition">The search condition.</param>
        /// <returns></returns>
        public Update AddJoin(JType type, string tableName, string tableAlias, string condition)
        {
            if (_from is null)
            {
                _tableSource.Joins.Add(new Join(type, tableName, tableAlias, condition));
            }
            else
            {
                _from.Joins.Add(new Join(type, tableName, tableAlias, condition));
            }

            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type">The join type.</param>
        /// <param name="schemaName">The schema name.</param>
        /// <param name="tableName">The table name.</param>
        /// <param name="tableAlias">The table alias.</param>
        /// <param name="condition">The search condition.</param>
        /// <returns></returns>
        public Update AddJoin(JType type, string schemaName, string tableName, string tableAlias, string condition)
        {
            if (_from is null)
            {
                _tableSource.Joins.Add(new Join(type, schemaName, tableName, tableAlias, condition));
            }
            else
            {
                _from.Joins.Add(new Join(type, schemaName, tableName, tableAlias, condition));
            }

            return this;
        }

        public Update ClearJoin()
        {
            if (_from is null)
            {
                _tableSource.Joins.Clear();
            }
            else
            {
                _from.Joins.Clear();
            }

            return this;
        }

        #endregion

        #region Where Methods

        public Update AddWhere(SearchCondition searchCondition)
        {
            _wheres.Add(searchCondition);

            return this;
        }

        public Update AddWhere(string fieldName, string operate, object? value = null)
        {
            if (Wheres.Count > 0)
            {
                _wheres.Add(new SearchCondition(CType.AND, fieldName, operate, value));

                return this;
            }

            _wheres.Add(new SearchCondition(fieldName, operate, value));

            return this;
        }

        public Update AddWhere(string fieldName, string operate, object? value, DbType dbType)
        {
            if (Wheres.Count > 0)
            {
                _wheres.Add(new SearchCondition(CType.AND, fieldName, operate, value, dbType));

                return this;
            }

            _wheres.Add(new SearchCondition(fieldName, operate, value, dbType));

            return this;
        }

        public Update AddWhere(string fieldName, string operate, object? value, bool isExpression)
        {
            if (Wheres.Count > 0)
            {
                _wheres.Add(new SearchCondition(CType.AND, fieldName, operate, value, isExpression));

                return this;
            }

            _wheres.Add(new SearchCondition(fieldName, operate, value, isExpression));

            return this;
        }

        public Update AddWhere(char enclosureL, string fieldName, string operate, object? value = null)
        {
            if (Wheres.Count > 0)
            {
                _wheres.Add(new SearchCondition(CType.AND, enclosureL, fieldName, operate, value));

                return this;
            }

            _wheres.Add(new SearchCondition(enclosureL, fieldName, operate, value));

            return this;
        }

        public Update AddWhere(char enclosureL, string fieldName, string operate, object? value, DbType dbType)
        {
            if (Wheres.Count > 0)
            {
                _wheres.Add(new SearchCondition(CType.AND, enclosureL, fieldName, operate, value, dbType));

                return this;
            }

            _wheres.Add(new SearchCondition(enclosureL, fieldName, operate, value, dbType));

            return this;
        }

        public Update AddWhere(char enclosureL, string fieldName, string operate, object? value, bool isExpression)
        {
            if (Wheres.Count > 0)
            {
                _wheres.Add(new SearchCondition(CType.AND, enclosureL, fieldName, operate, value, isExpression));

                return this;
            }

            _wheres.Add(new SearchCondition(enclosureL, fieldName, operate, value, isExpression));

            return this;
        }

        public Update AddWhere(CType connector, string fieldName, string operate, object? value = null)
        {
            _wheres.Add(new SearchCondition(connector, fieldName, operate, value));

            return this;
        }

        public Update AddWhere(CType connector, string fieldName, string operate, object? value, char enclosureR)
        {
            _wheres.Add(new SearchCondition(connector, fieldName, operate, value, enclosureR));

            return this;
        }

        public Update AddWhere(CType connector, string fieldName, string operate, object? value, DbType dbType, char? enclosureR = null)
        {
            _wheres.Add(new SearchCondition(connector, fieldName, operate, value, dbType, enclosureR));

            return this;
        }

        public Update AddWhere(CType connector, string fieldName, string operate, object? value, bool isExpression, char? enclosureR = null)
        {
            _wheres.Add(new SearchCondition(connector, fieldName, operate, value, isExpression, enclosureR));

            return this;
        }

        public Update AddWhere(CType connector, char enclosureL, string fieldName, string operate, object? value = null)
        {
            _wheres.Add(new SearchCondition(connector, enclosureL, fieldName, operate, value));

            return this;
        }

        public Update AddWhere(CType connector, char enclosureL, string fieldName, string operate, object? value, DbType dbType, char? enclosureR = null)
        {
            _wheres.Add(new SearchCondition(connector, enclosureL, fieldName, operate, value, dbType, enclosureR));

            return this;
        }

        public Update AddWhere(CType connector, char enclosureL, string fieldName, string operate, object? value, bool isExpression, char? enclosureR = null)
        {
            _wheres.Add(new SearchCondition(connector, enclosureL, fieldName, operate, value, isExpression, enclosureR));

            return this;
        }

        public Update AddWhere(CType connector, char enclosureL, string fieldName, string operate, object? value, DbType? dbType, bool isExpression, char? enclosureR)
        {
            _wheres.Add(new SearchCondition(connector, enclosureL, fieldName, operate, value, dbType, isExpression, enclosureR));

            return this;
        }

        public Update AddWhere(string fieldName, OpType operate, object? value = null)
        {
            if (Wheres.Count > 0)
            {
                _wheres.Add(new SearchCondition(CType.AND, fieldName, operate, value));

                return this;
            }

            _wheres.Add(new SearchCondition(fieldName, operate, value));

            return this;
        }

        public Update AddWhere(string fieldName, OpType operate, object? value, DbType dbType)
        {
            if (Wheres.Count > 0)
            {
                _wheres.Add(new SearchCondition(CType.AND, fieldName, operate, value, dbType));

                return this;
            }

            _wheres.Add(new SearchCondition(fieldName, operate, value, dbType));

            return this;
        }

        public Update AddWhere(string fieldName, OpType operate, object? value, bool isExpression)
        {
            if (Wheres.Count > 0)
            {
                _wheres.Add(new SearchCondition(CType.AND, fieldName, operate, value, isExpression));

                return this;
            }

            _wheres.Add(new SearchCondition(fieldName, operate, value, isExpression));

            return this;
        }

        public Update AddWhere(char enclosureL, string fieldName, OpType operate, object? value = null)
        {
            if (Wheres.Count > 0)
            {
                _wheres.Add(new SearchCondition(CType.AND, enclosureL, fieldName, operate, value));

                return this;
            }

            _wheres.Add(new SearchCondition(enclosureL, fieldName, operate, value));

            return this;
        }

        public Update AddWhere(char enclosureL, string fieldName, OpType operate, object? value, DbType dbType)
        {
            if (Wheres.Count > 0)
            {
                _wheres.Add(new SearchCondition(CType.AND, enclosureL, fieldName, operate, value, dbType));

                return this;
            }

            _wheres.Add(new SearchCondition(enclosureL, fieldName, operate, value, dbType));

            return this;
        }

        public Update AddWhere(char enclosureL, string fieldName, OpType operate, object? value, bool isExpression)
        {
            if (Wheres.Count > 0)
            {
                _wheres.Add(new SearchCondition(CType.AND, enclosureL, fieldName, operate, value, isExpression));

                return this;
            }

            _wheres.Add(new SearchCondition(enclosureL, fieldName, operate, value, isExpression));

            return this;
        }

        public Update AddWhere(CType connector, string fieldName, OpType operate, object? value = null)
        {
            _wheres.Add(new SearchCondition(connector, fieldName, operate, value));

            return this;
        }

        public Update AddWhere(CType connector, string fieldName, OpType operate, object? value, char enclosureR)
        {
            _wheres.Add(new SearchCondition(connector, fieldName, operate, value, enclosureR));

            return this;
        }

        public Update AddWhere(CType connector, string fieldName, OpType operate, object? value, DbType dbType, char? enclosureR = null)
        {
            _wheres.Add(new SearchCondition(connector, fieldName, operate, value, dbType, enclosureR));

            return this;
        }

        public Update AddWhere(CType connector, string fieldName, OpType operate, object? value, bool isExpression, char? enclosureR = null)
        {
            _wheres.Add(new SearchCondition(connector, fieldName, operate, value, isExpression, enclosureR));

            return this;
        }

        public Update AddWhere(CType connector, char enclosureL, string fieldName, OpType operate, object? value = null)
        {
            _wheres.Add(new SearchCondition(connector, enclosureL, fieldName, operate, value));

            return this;
        }

        public Update AddWhere(CType connector, char enclosureL, string fieldName, OpType operate, object? value, DbType dbType, char? enclosureR = null)
        {
            _wheres.Add(new SearchCondition(connector, enclosureL, fieldName, operate, value, dbType, enclosureR));

            return this;
        }

        public Update AddWhere(CType connector, char enclosureL, string fieldName, OpType operate, object? value, bool isExpression, char? enclosureR = null)
        {
            _wheres.Add(new SearchCondition(connector, enclosureL, fieldName, operate, value, isExpression, enclosureR));

            return this;
        }

        public Update AddWhere(CType connector, char enclosureL, string fieldName, OpType operate, object? value, DbType? dbType, bool isExpression, char? enclosureR)
        {
            _wheres.Add(new SearchCondition(connector, enclosureL, fieldName, operate, value, dbType, isExpression, enclosureR));

            return this;
        }

        public Update ClearWhere()
        {
            _wheres.Clear();

            return this;
        }

        #endregion

        #region With Methods

        public Update SetWith(bool recursive)
        {
            _with.SetRecursive(recursive);

            return this;
        }

        public Update ClearWith()
        {
            _with.Clear();

            return this;
        }

        #endregion
    }
}
