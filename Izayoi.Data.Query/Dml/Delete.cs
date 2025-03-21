// ----------------------------------------------------------------------
// @Namespace : Izayoi.Data.Query
// @Class     : Delete
// ----------------------------------------------------------------------
namespace Izayoi.Data.Query
{
    using System.Data;

    /// <summary>
    /// Delete
    /// </summary>
    public class Delete
    {
        #region Fields

        private readonly From _from;

        private readonly Wheres _wheres;

        private readonly With _with;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the Delete class.
        /// </summary>
        public Delete()
        {
            _from = new From();

            _wheres = new Wheres(1);

            _with = new With();
        }

        /// <summary>
        /// Initializes a new instance of the Delete class with the specified tableName.
        /// </summary>
        /// <param name="tableName">The table name.</param>
        public Delete(string tableName)
        {
            _from = new From(string.Empty, tableName, string.Empty);

            _wheres = new Wheres(1);

            _with = new With();
        }

        /// <summary>
        /// Initializes a new instance of the Delete class with the specified tableName and tableAlias.
        /// </summary>
        /// <param name="tableName">The table name.</param>
        /// <param name="tableAlias">The table alias.</param>
        public Delete(string tableName, string tableAlias)
        {
            _from = new From(string.Empty, tableName, tableAlias);

            _wheres = new Wheres(1);

            _with = new With();
        }

        /// <summary>
        /// Initializes a new instance of the Delete class with the specified schemaName, tableName and tableAlias.
        /// </summary>
        /// <param name="schemaName">The schema name.</param>
        /// <param name="tableName">The table name.</param>
        /// <param name="tableAlias">The table alias.</param>
        public Delete(string schemaName, string tableName, string tableAlias)
        {
            _from = new From(schemaName, tableName, tableAlias);

            _wheres = new Wheres(1);

            _with = new With();
        }

        #endregion

        #region Properties

        /// <summary>FROM clause and JOIN clause</summary>
        public From From => _from;

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
        public Delete SetFrom(string tableName)
        {
            return SetFrom(schemaName: string.Empty, tableName, string.Empty);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tableName">The table name.</param>
        /// <param name="tableAlias">The table alias.</param>
        /// <returns></returns>
        public Delete SetFrom(string tableName, string tableAlias)
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
        public Delete SetFrom(string schemaName, string tableName, string tableAlias)
        {
            _from.SchemaName = schemaName;
            _from.TableName = tableName;
            _from.TableAlias = tableAlias;

            return this;
        }

        #endregion

        #region Where Methods

        public Delete AddWhere(SearchCondition searchCondition)
        {
            _wheres.Add(searchCondition);

            return this;
        }

        public Delete AddWhere(string fieldName, string operate, object? value = null)
        {
            if (Wheres.Count > 0)
            {
                _wheres.Add(new SearchCondition(CType.AND, fieldName, operate, value));

                return this;
            }

            _wheres.Add(new SearchCondition(fieldName, operate, value));

            return this;
        }

        public Delete AddWhere(string fieldName, string operate, object? value, DbType dbType)
        {
            if (Wheres.Count > 0)
            {
                _wheres.Add(new SearchCondition(CType.AND, fieldName, operate, value, dbType));

                return this;
            }

            _wheres.Add(new SearchCondition(fieldName, operate, value, dbType));

            return this;
        }

        public Delete AddWhere(string fieldName, string operate, object? value, bool isExpression)
        {
            if (Wheres.Count > 0)
            {
                _wheres.Add(new SearchCondition(CType.AND, fieldName, operate, value, isExpression));

                return this;
            }

            _wheres.Add(new SearchCondition(fieldName, operate, value, isExpression));

            return this;
        }

        public Delete AddWhere(char enclosureL, string fieldName, string operate, object? value = null)
        {
            if (Wheres.Count > 0)
            {
                _wheres.Add(new SearchCondition(CType.AND, enclosureL, fieldName, operate, value));

                return this;
            }

            _wheres.Add(new SearchCondition(enclosureL, fieldName, operate, value));

            return this;
        }

        public Delete AddWhere(char enclosureL, string fieldName, string operate, object? value, DbType dbType)
        {
            if (Wheres.Count > 0)
            {
                _wheres.Add(new SearchCondition(CType.AND, enclosureL, fieldName, operate, value, dbType));

                return this;
            }

            _wheres.Add(new SearchCondition(enclosureL, fieldName, operate, value, dbType));

            return this;
        }

        public Delete AddWhere(char enclosureL, string fieldName, string operate, object? value, bool isExpression)
        {
            if (Wheres.Count > 0)
            {
                _wheres.Add(new SearchCondition(CType.AND, enclosureL, fieldName, operate, value, isExpression));

                return this;
            }

            _wheres.Add(new SearchCondition(enclosureL, fieldName, operate, value, isExpression));

            return this;
        }

        public Delete AddWhere(CType connector, string fieldName, string operate, object? value = null)
        {
            _wheres.Add(new SearchCondition(connector, fieldName, operate, value));

            return this;
        }

        public Delete AddWhere(CType connector, string fieldName, string operate, object? value, char enclosureR)
        {
            _wheres.Add(new SearchCondition(connector, fieldName, operate, value, enclosureR));

            return this;
        }

        public Delete AddWhere(CType connector, string fieldName, string operate, object? value, DbType dbType, char? enclosureR = null)
        {
            _wheres.Add(new SearchCondition(connector, fieldName, operate, value, dbType, enclosureR));

            return this;
        }

        public Delete AddWhere(CType connector, string fieldName, string operate, object? value, bool isExpression, char? enclosureR = null)
        {
            _wheres.Add(new SearchCondition(connector, fieldName, operate, value, isExpression, enclosureR));

            return this;
        }

        public Delete AddWhere(CType connector, char enclosureL, string fieldName, string operate, object? value = null)
        {
            _wheres.Add(new SearchCondition(connector, enclosureL, fieldName, operate, value));

            return this;
        }

        public Delete AddWhere(CType connector, char enclosureL, string fieldName, string operate, object? value, DbType dbType, char? enclosureR = null)
        {
            _wheres.Add(new SearchCondition(connector, enclosureL, fieldName, operate, value, dbType, enclosureR));

            return this;
        }

        public Delete AddWhere(CType connector, char enclosureL, string fieldName, string operate, object? value, bool isExpression, char? enclosureR = null)
        {
            _wheres.Add(new SearchCondition(connector, enclosureL, fieldName, operate, value, isExpression, enclosureR));

            return this;
        }

        public Delete AddWhere(CType connector, char enclosureL, string fieldName, string operate, object? value, DbType? dbType, bool isExpression, char? enclosureR)
        {
            _wheres.Add(new SearchCondition(connector, enclosureL, fieldName, operate, value, dbType, isExpression, enclosureR));

            return this;
        }

        public Delete AddWhere(string fieldName, OpType operate, object? value = null)
        {
            if (Wheres.Count > 0)
            {
                _wheres.Add(new SearchCondition(CType.AND, fieldName, operate, value));

                return this;
            }

            _wheres.Add(new SearchCondition(fieldName, operate, value));

            return this;
        }

        public Delete AddWhere(string fieldName, OpType operate, object? value, DbType dbType)
        {
            if (Wheres.Count > 0)
            {
                _wheres.Add(new SearchCondition(CType.AND, fieldName, operate, value, dbType));

                return this;
            }

            _wheres.Add(new SearchCondition(fieldName, operate, value, dbType));

            return this;
        }

        public Delete AddWhere(string fieldName, OpType operate, object? value, bool isExpression)
        {
            if (Wheres.Count > 0)
            {
                _wheres.Add(new SearchCondition(CType.AND, fieldName, operate, value, isExpression));

                return this;
            }

            _wheres.Add(new SearchCondition(fieldName, operate, value, isExpression));

            return this;
        }

        public Delete AddWhere(char enclosureL, string fieldName, OpType operate, object? value = null)
        {
            if (Wheres.Count > 0)
            {
                _wheres.Add(new SearchCondition(CType.AND, enclosureL, fieldName, operate, value));

                return this;
            }

            _wheres.Add(new SearchCondition(enclosureL, fieldName, operate, value));

            return this;
        }

        public Delete AddWhere(char enclosureL, string fieldName, OpType operate, object? value, DbType dbType)
        {
            if (Wheres.Count > 0)
            {
                _wheres.Add(new SearchCondition(CType.AND, enclosureL, fieldName, operate, value, dbType));

                return this;
            }

            _wheres.Add(new SearchCondition(enclosureL, fieldName, operate, value, dbType));

            return this;
        }

        public Delete AddWhere(char enclosureL, string fieldName, OpType operate, object? value, bool isExpression)
        {
            if (Wheres.Count > 0)
            {
                _wheres.Add(new SearchCondition(CType.AND, enclosureL, fieldName, operate, value, isExpression));

                return this;
            }

            _wheres.Add(new SearchCondition(enclosureL, fieldName, operate, value, isExpression));

            return this;
        }

        public Delete AddWhere(CType connector, string fieldName, OpType operate, object? value = null)
        {
            _wheres.Add(new SearchCondition(connector, fieldName, operate, value));

            return this;
        }

        public Delete AddWhere(CType connector, string fieldName, OpType operate, object? value, char enclosureR)
        {
            _wheres.Add(new SearchCondition(connector, fieldName, operate, value, enclosureR));

            return this;
        }

        public Delete AddWhere(CType connector, string fieldName, OpType operate, object? value, DbType dbType, char? enclosureR = null)
        {
            _wheres.Add(new SearchCondition(connector, fieldName, operate, value, dbType, enclosureR));

            return this;
        }

        public Delete AddWhere(CType connector, string fieldName, OpType operate, object? value, bool isExpression, char? enclosureR = null)
        {
            _wheres.Add(new SearchCondition(connector, fieldName, operate, value, isExpression, enclosureR));

            return this;
        }

        public Delete AddWhere(CType connector, char enclosureL, string fieldName, OpType operate, object? value = null)
        {
            _wheres.Add(new SearchCondition(connector, enclosureL, fieldName, operate, value));

            return this;
        }

        public Delete AddWhere(CType connector, char enclosureL, string fieldName, OpType operate, object? value, DbType dbType, char? enclosureR = null)
        {
            _wheres.Add(new SearchCondition(connector, enclosureL, fieldName, operate, value, dbType, enclosureR));

            return this;
        }

        public Delete AddWhere(CType connector, char enclosureL, string fieldName, OpType operate, object? value, bool isExpression, char? enclosureR = null)
        {
            _wheres.Add(new SearchCondition(connector, enclosureL, fieldName, operate, value, isExpression, enclosureR));

            return this;
        }

        public Delete AddWhere(CType connector, char enclosureL, string fieldName, OpType operate, object? value, DbType? dbType, bool isExpression, char? enclosureR)
        {
            _wheres.Add(new SearchCondition(connector, enclosureL, fieldName, operate, value, dbType, isExpression, enclosureR));

            return this;
        }

        public Delete ClearWhere()
        {
            _wheres.Clear();

            return this;
        }

        #endregion

        #region With Methods

        public Delete SetWith(bool recursive)
        {
            _with.SetRecursive(recursive);

            return this;
        }

        public Delete ClearWith()
        {
            _with.Clear();

            return this;
        }

        #endregion
    }
}
