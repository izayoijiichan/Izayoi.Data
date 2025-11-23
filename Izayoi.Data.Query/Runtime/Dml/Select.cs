// ----------------------------------------------------------------------
// @Namespace : Izayoi.Data.Query
// @Class     : Select
// ----------------------------------------------------------------------
#nullable enable
namespace Izayoi.Data.Query
{
    using System.Data;

    /// <summary>
    /// Select
    /// </summary>
    public class Select
    {
        #region Fields

        private SType _type;

        private readonly Fields _fields;

        private readonly From _from;

        private readonly Wheres _wheres;

        private readonly Groups _groups;

        private readonly Havings _havings;

        private readonly Orders _orders;

        private int _offset;

        private int _limit;

        private readonly For _for;

        private With _with;

        #endregion

        #region Constructors

        public Select()
        {
            _fields = new Fields(4);

            _from = new From();

            _wheres = new Wheres(4);

            _groups = new Groups(2);

            _havings = new Havings(1);

            _orders = new Orders(2);

            _offset = 0;

            _limit = 0;

            _for = new For();

            _with = new With();
        }

        #endregion

        #region Properties

        /// <summary>Gets or sets the select type.</summary>
        /// <remarks>ALL, DISTINCT</remarks>
        public SType Type { get => _type; set => _type = value; }

        /// <summary>select list (SELECT clause)</summary>
        public Fields Fields => _fields;

        /// <summary>FROM clause</summary>
        public From From => _from;

        /// <summary>JOIN clause</summary>
        /// <remarks>It is under From.</remarks>
        public Joins Joins => _from.Joins;

        /// <summary>WHERE clause</summary>
        public Wheres Wheres => _wheres;

        /// <summary>GROUP BY clause</summary>
        public Groups Groups => _groups;

        /// <summary>HAVING clause</summary>
        public Havings Havings => _havings;

        /// <summary>ORDER BY clause</summary>
        public Orders Orders => _orders;

        /// <summary>OFFSET clause</summary>
        public int Offset { get => _offset; set => _offset = value; }

        /// <summary>LIMIT clause</summary>
        public int Limit { get => _limit; set => _limit = value; }

        /// <summary>FOR clause</summary>
        /// <remarks>Use only in SQL Server.</remarks>
        public For For => _for;

        /// <summary>With clause</summary>
        public With With => _with;

        #endregion

        #region Methods

        public void Clear()
        {
            _type = SType.None;

            _fields.Clear();

            _from.Clear();

            _wheres.Clear();

            _groups.Clear();

            _havings.Clear();

            _orders.Clear();

            _offset = 0;

            _limit = 0;

            _for.Clear();

            _with.Clear();
        }

        #endregion

        #region Type Methods

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type">The select type.</param>
        /// <returns></returns>
        public Select SetType(SType type)
        {
            _type = type;

            return this;
        }

        #endregion

        #region From Methods

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tableName">The table name.</param>
        /// <returns></returns>
        public Select SetFrom(string tableName)
        {
            return SetFrom(string.Empty, tableName, string.Empty);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tableName">The table name.</param>
        /// <param name="tableAlias">The table alias.</param>
        /// <returns></returns>
        public Select SetFrom(string tableName, string tableAlias)
        {
            return SetFrom(string.Empty, tableName, tableAlias);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="schemaName">The schema name.</param>
        /// <param name="tableName">The table name.</param>
        /// <param name="tableAlias">The table alias.</param>
        /// <returns></returns>
        public Select SetFrom(string schemaName, string tableName, string tableAlias)
        {
            _from.SchemaName = schemaName;
            _from.TableName = tableName;
            _from.TableAlias = tableAlias;

            return this;
        }

        public Select ClearFrom()
        {
            _from.Clear();

            return this;
        }

        #endregion

        #region Join Methods

        public Select AddJoin(Join item)
        {
            _from.Joins.Add(item);

            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type">The join type.</param>
        /// <param name="tableName">The table name.</param>
        /// <param name="condition">The search condition.</param>
        /// <returns></returns>
        public Select AddJoin(JType type, string tableName, string condition)
        {
            _from.Joins.Add(new Join(type, tableName, condition));

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
        public Select AddJoin(JType type, string tableName, string tableAlias, string condition)
        {
            _from.Joins.Add(new Join(type, tableName, tableAlias, condition));

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
        public Select AddJoin(JType type, string schemaName, string tableName, string tableAlias, string condition)
        {
            _from.Joins.Add(new Join(type, schemaName, tableName, tableAlias, condition));

            return this;
        }

        public Select ClearJoin()
        {
            _from.Joins.Clear();

            return this;
        }

        #endregion

        #region Field Methods

        public Select AddField(Field field)
        {
            _fields.Add(field);

            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fieldName">The field name or expression.</param>
        /// <param name="isExpression">Whether the field name is expression.</param>
        /// <returns></returns>
        public Select AddField(string fieldName, bool? isExpression = null)
        {
            _fields.Add(new Field(fieldName, isExpression));

            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fieldName">The field name or expression.</param>
        /// <param name="fieldAlias">The field alias.</param>
        /// <param name="isExpression">Whether the field name is expression.</param>
        /// <returns></returns>
        public Select AddField(string fieldName, string fieldAlias, bool? isExpression = null)
        {
            _fields.Add(new Field(fieldName, fieldAlias, isExpression));

            return this;
        }

        public Select ClearFields()
        {
            _fields.Clear();

            return this;
        }

        #endregion

        #region Where Methods

        public Select AddWhere(SearchCondition searchCondition)
        {
            _wheres.Add(searchCondition);

            return this;
        }

        public Select AddWhere(string fieldName, string operate, object? value = null)
        {
            if (Wheres.Count > 0)
            {
                _wheres.Add(new SearchCondition(CType.AND, fieldName, operate, value));

                return this;
            }

            _wheres.Add(new SearchCondition(fieldName, operate, value));

            return this;
        }

        public Select AddWhere(string fieldName, string operate, object? value, DbType dbType)
        {
            if (Wheres.Count > 0)
            {
                _wheres.Add(new SearchCondition(CType.AND, fieldName, operate, value, dbType));

                return this;
            }

            _wheres.Add(new SearchCondition(fieldName, operate, value, dbType));

            return this;
        }

        public Select AddWhere(string fieldName, string operate, object? value, bool isExpression)
        {
            if (Wheres.Count > 0)
            {
                _wheres.Add(new SearchCondition(CType.AND, fieldName, operate, value, isExpression));

                return this;
            }

            _wheres.Add(new SearchCondition(fieldName, operate, value, isExpression));

            return this;
        }

        public Select AddWhere(char enclosureL, string fieldName, string operate, object? value = null)
        {
            if (Wheres.Count > 0)
            {
                _wheres.Add(new SearchCondition(CType.AND, enclosureL, fieldName, operate, value));

                return this;
            }

            _wheres.Add(new SearchCondition(enclosureL, fieldName, operate, value));

            return this;
        }

        public Select AddWhere(char enclosureL, string fieldName, string operate, object? value, DbType dbType)
        {
            if (Wheres.Count > 0)
            {
                _wheres.Add(new SearchCondition(CType.AND, enclosureL, fieldName, operate, value, dbType));

                return this;
            }

            _wheres.Add(new SearchCondition(enclosureL, fieldName, operate, value, dbType));

            return this;
        }

        public Select AddWhere(char enclosureL, string fieldName, string operate, object? value, bool isExpression)
        {
            if (Wheres.Count > 0)
            {
                _wheres.Add(new SearchCondition(CType.AND, enclosureL, fieldName, operate, value, isExpression));

                return this;
            }

            _wheres.Add(new SearchCondition(enclosureL, fieldName, operate, value, isExpression));

            return this;
        }

        public Select AddWhere(CType connector, string fieldName, string operate, object? value = null)
        {
            _wheres.Add(new SearchCondition(connector, fieldName, operate, value));

            return this;
        }

        public Select AddWhere(CType connector, string fieldName, string operate, object? value, char enclosureR)
        {
            _wheres.Add(new SearchCondition(connector, fieldName, operate, value, enclosureR));

            return this;
        }

        public Select AddWhere(CType connector, string fieldName, string operate, object? value, DbType dbType, char? enclosureR = null)
        {
            _wheres.Add(new SearchCondition(connector, fieldName, operate, value, dbType, enclosureR));

            return this;
        }

        public Select AddWhere(CType connector, string fieldName, string operate, object? value, bool isExpression, char? enclosureR = null)
        {
            _wheres.Add(new SearchCondition(connector, fieldName, operate, value, isExpression, enclosureR));

            return this;
        }

        public Select AddWhere(CType connector, char enclosureL, string fieldName, string operate, object? value = null)
        {
            _wheres.Add(new SearchCondition(connector, enclosureL, fieldName, operate, value));

            return this;
        }

        public Select AddWhere(CType connector, char enclosureL, string fieldName, string operate, object? value, DbType dbType, char? enclosureR = null)
        {
            _wheres.Add(new SearchCondition(connector, enclosureL, fieldName, operate, value, dbType, enclosureR));

            return this;
        }

        public Select AddWhere(CType connector, char enclosureL, string fieldName, string operate, object? value, bool isExpression, char? enclosureR = null)
        {
            _wheres.Add(new SearchCondition(connector, enclosureL, fieldName, operate, value, isExpression, enclosureR));

            return this;
        }

        public Select AddWhere(CType connector, char enclosureL, string fieldName, string operate, object? value, DbType? dbType, bool isExpression, char? enclosureR)
        {
            _wheres.Add(new SearchCondition(connector, enclosureL, fieldName, operate, value, dbType, isExpression, enclosureR));

            return this;
        }

        public Select AddWhere(string fieldName, OpType operate, object? value = null)
        {
            if (Wheres.Count > 0)
            {
                _wheres.Add(new SearchCondition(CType.AND, fieldName, operate, value));

                return this;
            }

            _wheres.Add(new SearchCondition(fieldName, operate, value));

            return this;
        }

        public Select AddWhere(string fieldName, OpType operate, object? value, DbType dbType)
        {
            if (Wheres.Count > 0)
            {
                _wheres.Add(new SearchCondition(CType.AND, fieldName, operate, value, dbType));

                return this;
            }

            _wheres.Add(new SearchCondition(fieldName, operate, value, dbType));

            return this;
        }

        public Select AddWhere(string fieldName, OpType operate, object? value, bool isExpression)
        {
            if (Wheres.Count > 0)
            {
                _wheres.Add(new SearchCondition(CType.AND, fieldName, operate, value, isExpression));

                return this;
            }

            _wheres.Add(new SearchCondition(fieldName, operate, value, isExpression));

            return this;
        }

        public Select AddWhere(char enclosureL, string fieldName, OpType operate, object? value = null)
        {
            if (Wheres.Count > 0)
            {
                _wheres.Add(new SearchCondition(CType.AND, enclosureL, fieldName, operate, value));

                return this;
            }

            _wheres.Add(new SearchCondition(enclosureL, fieldName, operate, value));

            return this;
        }

        public Select AddWhere(char enclosureL, string fieldName, OpType operate, object? value, DbType dbType)
        {
            if (Wheres.Count > 0)
            {
                _wheres.Add(new SearchCondition(CType.AND, enclosureL, fieldName, operate, value, dbType));

                return this;
            }

            _wheres.Add(new SearchCondition(enclosureL, fieldName, operate, value, dbType));

            return this;
        }

        public Select AddWhere(char enclosureL, string fieldName, OpType operate, object? value, bool isExpression)
        {
            if (Wheres.Count > 0)
            {
                _wheres.Add(new SearchCondition(CType.AND, enclosureL, fieldName, operate, value, isExpression));

                return this;
            }

            _wheres.Add(new SearchCondition(enclosureL, fieldName, operate, value, isExpression));

            return this;
        }

        public Select AddWhere(CType connector, string fieldName, OpType operate, object? value = null)
        {
            _wheres.Add(new SearchCondition(connector, fieldName, operate, value));

            return this;
        }

        public Select AddWhere(CType connector, string fieldName, OpType operate, object? value, char enclosureR)
        {
            _wheres.Add(new SearchCondition(connector, fieldName, operate, value, enclosureR));

            return this;
        }

        public Select AddWhere(CType connector, string fieldName, OpType operate, object? value, DbType dbType, char? enclosureR = null)
        {
            _wheres.Add(new SearchCondition(connector, fieldName, operate, value, dbType, enclosureR));

            return this;
        }

        public Select AddWhere(CType connector, string fieldName, OpType operate, object? value, bool isExpression, char? enclosureR = null)
        {
            _wheres.Add(new SearchCondition(connector, fieldName, operate, value, isExpression, enclosureR));

            return this;
        }

        public Select AddWhere(CType connector, char enclosureL, string fieldName, OpType operate, object? value = null)
        {
            _wheres.Add(new SearchCondition(connector, enclosureL, fieldName, operate, value));

            return this;
        }

        public Select AddWhere(CType connector, char enclosureL, string fieldName, OpType operate, object? value, DbType dbType, char? enclosureR = null)
        {
            _wheres.Add(new SearchCondition(connector, enclosureL, fieldName, operate, value, dbType, enclosureR));

            return this;
        }

        public Select AddWhere(CType connector, char enclosureL, string fieldName, OpType operate, object? value, bool isExpression, char? enclosureR = null)
        {
            _wheres.Add(new SearchCondition(connector, enclosureL, fieldName, operate, value, isExpression, enclosureR));

            return this;
        }

        public Select AddWhere(CType connector, char enclosureL, string fieldName, OpType operate, object? value, DbType? dbType, bool isExpression, char? enclosureR)
        {
            _wheres.Add(new SearchCondition(connector, enclosureL, fieldName, operate, value, dbType, isExpression, enclosureR));

            return this;
        }

        public Select ClearWhere()
        {
            _wheres.Clear();

            return this;
        }

        #endregion

        #region Group Methods

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fieldExpression">The field name or expression.</param>
        /// <returns></returns>
        public Select AddGroup(string fieldExpression)
        {
            _groups.Add(fieldExpression);

            return this;
        }

        public Select ClearGroup()
        {
            _groups.Clear();

            return this;
        }

        #endregion

        #region Having Methods

        public Select AddHaving(SearchCondition searchCondition)
        {
            _wheres.Add(searchCondition);

            return this;
        }

        public Select AddHaving(string fieldName, string operate, object? value = null)
        {
            if (Havings.Count > 0)
            {
                _havings.Add(new SearchCondition(CType.AND, fieldName, operate, value));

                return this;
            }

            _havings.Add(new SearchCondition(fieldName, operate, value));

            return this;
        }

        public Select AddHaving(string fieldName, string operate, object? value, DbType dbType)
        {
            if (Havings.Count > 0)
            {
                _havings.Add(new SearchCondition(CType.AND, fieldName, operate, value, dbType));

                return this;
            }

            _havings.Add(new SearchCondition(fieldName, operate, value, dbType));

            return this;
        }

        public Select AddHaving(string fieldName, string operate, object? value, bool isExpression)
        {
            if (Havings.Count > 0)
            {
                _havings.Add(new SearchCondition(CType.AND, fieldName, operate, value, isExpression));

                return this;
            }

            _havings.Add(new SearchCondition(fieldName, operate, value, isExpression));

            return this;
        }

        public Select AddHaving(char enclosureL, string fieldName, string operate, object? value = null)
        {
            if (Havings.Count > 0)
            {
                _havings.Add(new SearchCondition(CType.AND, enclosureL, fieldName, operate, value));

                return this;
            }

            _havings.Add(new SearchCondition(enclosureL, fieldName, operate, value));

            return this;
        }

        public Select AddHaving(char enclosureL, string fieldName, string operate, object? value, DbType dbType)
        {
            if (Havings.Count > 0)
            {
                _havings.Add(new SearchCondition(CType.AND, enclosureL, fieldName, operate, value, dbType));

                return this;
            }

            _havings.Add(new SearchCondition(enclosureL, fieldName, operate, value, dbType));

            return this;
        }

        public Select AddHaving(char enclosureL, string fieldName, string operate, object? value, bool isExpression)
        {
            if (Havings.Count > 0)
            {
                _havings.Add(new SearchCondition(CType.AND, enclosureL, fieldName, operate, value, isExpression));

                return this;
            }

            _havings.Add(new SearchCondition(enclosureL, fieldName, operate, value, isExpression));

            return this;
        }

        public Select AddHaving(CType connector, string fieldName, string operate, object? value = null)
        {
            _havings.Add(new SearchCondition(connector, fieldName, operate, value));

            return this;
        }

        public Select AddHaving(CType connector, string fieldName, string operate, object? value, char enclosureR)
        {
            _havings.Add(new SearchCondition(connector, fieldName, operate, value, enclosureR));

            return this;
        }

        public Select AddHaving(CType connector, string fieldName, string operate, object? value, DbType dbType, char? enclosureR = null)
        {
            _havings.Add(new SearchCondition(connector, fieldName, operate, value, dbType, enclosureR));

            return this;
        }

        public Select AddHaving(CType connector, string fieldName, string operate, object? value, bool isExpression, char? enclosureR = null)
        {
            _havings.Add(new SearchCondition(connector, fieldName, operate, value, isExpression, enclosureR));

            return this;
        }

        public Select AddHaving(CType connector, char enclosureL, string fieldName, string operate, object? value = null)
        {
            _havings.Add(new SearchCondition(connector, enclosureL, fieldName, operate, value));

            return this;
        }

        public Select AddHaving(CType connector, char enclosureL, string fieldName, string operate, object? value, DbType dbType, char? enclosureR = null)
        {
            _havings.Add(new SearchCondition(connector, enclosureL, fieldName, operate, value, dbType, enclosureR));

            return this;
        }

        public Select AddHaving(CType connector, char enclosureL, string fieldName, string operate, object? value, bool isExpression, char? enclosureR = null)
        {
            _havings.Add(new SearchCondition(connector, enclosureL, fieldName, operate, value, isExpression, enclosureR));

            return this;
        }

        public Select AddHaving(CType connector, char enclosureL, string fieldName, string operate, object? value, DbType? dbType, bool isExpression, char? enclosureR)
        {
            _havings.Add(new SearchCondition(connector, enclosureL, fieldName, operate, value, dbType, isExpression, enclosureR));

            return this;
        }

        public Select AddHaving(string fieldName, OpType operate, object? value = null)
        {
            if (Havings.Count > 0)
            {
                _havings.Add(new SearchCondition(CType.AND, fieldName, operate, value));

                return this;
            }

            _havings.Add(new SearchCondition(fieldName, operate, value));

            return this;
        }

        public Select AddHaving(string fieldName, OpType operate, object? value, DbType dbType)
        {
            if (Havings.Count > 0)
            {
                _havings.Add(new SearchCondition(CType.AND, fieldName, operate, value, dbType));

                return this;
            }

            _havings.Add(new SearchCondition(fieldName, operate, value, dbType));

            return this;
        }

        public Select AddHaving(string fieldName, OpType operate, object? value, bool isExpression)
        {
            if (Havings.Count > 0)
            {
                _havings.Add(new SearchCondition(CType.AND, fieldName, operate, value, isExpression));

                return this;
            }

            _havings.Add(new SearchCondition(fieldName, operate, value, isExpression));

            return this;
        }

        public Select AddHaving(char enclosureL, string fieldName, OpType operate, object? value = null)
        {
            if (Havings.Count > 0)
            {
                _havings.Add(new SearchCondition(CType.AND, enclosureL, fieldName, operate, value));

                return this;
            }

            _havings.Add(new SearchCondition(enclosureL, fieldName, operate, value));

            return this;
        }

        public Select AddHaving(char enclosureL, string fieldName, OpType operate, object? value, DbType dbType)
        {
            if (Havings.Count > 0)
            {
                _havings.Add(new SearchCondition(CType.AND, enclosureL, fieldName, operate, value, dbType));

                return this;
            }

            _havings.Add(new SearchCondition(enclosureL, fieldName, operate, value, dbType));

            return this;
        }

        public Select AddHaving(char enclosureL, string fieldName, OpType operate, object? value, bool isExpression)
        {
            if (Havings.Count > 0)
            {
                _havings.Add(new SearchCondition(CType.AND, enclosureL, fieldName, operate, value, isExpression));

                return this;
            }

            _havings.Add(new SearchCondition(enclosureL, fieldName, operate, value, isExpression));

            return this;
        }

        public Select AddHaving(CType connector, string fieldName, OpType operate, object? value = null)
        {
            _havings.Add(new SearchCondition(connector, fieldName, operate, value));

            return this;
        }

        public Select AddHaving(CType connector, string fieldName, OpType operate, object? value, char enclosureR)
        {
            _havings.Add(new SearchCondition(connector, fieldName, operate, value, enclosureR));

            return this;
        }

        public Select AddHaving(CType connector, string fieldName, OpType operate, object? value, DbType dbType, char? enclosureR = null)
        {
            _havings.Add(new SearchCondition(connector, fieldName, operate, value, dbType, enclosureR));

            return this;
        }

        public Select AddHaving(CType connector, string fieldName, OpType operate, object? value, bool isExpression, char? enclosureR = null)
        {
            _havings.Add(new SearchCondition(connector, fieldName, operate, value, isExpression, enclosureR));

            return this;
        }

        public Select AddHaving(CType connector, char enclosureL, string fieldName, OpType operate, object? value = null)
        {
            _havings.Add(new SearchCondition(connector, enclosureL, fieldName, operate, value));

            return this;
        }

        public Select AddHaving(CType connector, char enclosureL, string fieldName, OpType operate, object? value, DbType dbType, char? enclosureR = null)
        {
            _havings.Add(new SearchCondition(connector, enclosureL, fieldName, operate, value, dbType, enclosureR));

            return this;
        }

        public Select AddHaving(CType connector, char enclosureL, string fieldName, OpType operate, object? value, bool isExpression, char? enclosureR = null)
        {
            _havings.Add(new SearchCondition(connector, enclosureL, fieldName, operate, value, isExpression, enclosureR));

            return this;
        }

        public Select AddHaving(CType connector, char enclosureL, string fieldName, OpType operate, object? value, DbType? dbType, bool isExpression, char? enclosureR)
        {
            _havings.Add(new SearchCondition(connector, enclosureL, fieldName, operate, value, dbType, isExpression, enclosureR));

            return this;
        }

        public Select ClearHaving()
        {
            _havings.Clear();

            return this;
        }

        #endregion

        #region Order Methods

        public Select AddOrder(Order order)
        {
            _orders.Add(order);

            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="orderExpression">The order expression.</param>
        /// <returns></returns>
        public Select AddOrder(string orderExpression)
        {
            _orders.Add(new Order(orderExpression));

            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="orderExpression">The order expression.</param>
        /// <param name="type">The order type.</param>
        /// <returns></returns>
        public Select AddOrder(string orderExpression, OType type)
        {
            _orders.Add(new Order(orderExpression, type));

            return this;
        }

        public Select ClearOrder()
        {
            _orders.Clear();

            return this;
        }

        #endregion

        #region Limit Methods

        public Select SetLimit(int limit)
        {
            _limit = limit;

            return this;
        }

        #endregion

        #region Offet Methods

        public Select SetOffset(int offset)
        {
            _offset = offset;

            return this;
        }

        #endregion

        #region For Methods

        public Select SetFor(Json json)
        {
            _for.SetJson(json);

            return this;
        }

        public Select SetFor(JsonMode mode, string? rootName = null, bool includeNullValues = false, bool withoutArrayWrapper = false)
        {
            _for.SetJson(mode, rootName, includeNullValues, withoutArrayWrapper);

            return this;
        }

        public Select ClearFor()
        {
            _for.Clear();

            return this;
        }

        #endregion

        #region With Methods

        public Select SetWith(bool recursive)
        {
            _with.SetRecursive(recursive);

            return this;
        }

        public Select ClearWith()
        {
            _with.Clear();

            return this;
        }

        #endregion
    }
}
