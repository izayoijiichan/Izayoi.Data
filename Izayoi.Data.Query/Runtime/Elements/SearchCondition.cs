// ----------------------------------------------------------------------
// @Namespace : Izayoi.Data.Query
// @Class     : SearchCondition
// ----------------------------------------------------------------------
#nullable enable
namespace Izayoi.Data.Query
{
    using System.Data;
    using System.Linq;

    /// <summary>
    /// Search Condition
    /// </summary>
    /// <remarks>
    /// WHERE search condition
    /// HAVING search condition
    /// </remarks>
    public class SearchCondition
    {
        #region Fields

        protected CType _connector;

        protected string _fieldName;

        protected OpType _opType;

        protected string _operator;

        protected object? _value;

        protected DbType _dbType;

        protected bool _isExpression;

        protected char _enclosureL;

        protected char _enclosureR;

        #endregion

        #region Constructors

        public SearchCondition(string fieldName, string operate, object? value = null)
            : this(CType.None, char.MinValue, fieldName, operate, value, null, false, null) { }

        public SearchCondition(string fieldName, string operate, object? value, DbType dbType)
            : this(CType.None, char.MinValue, fieldName, operate, value, dbType, false, null) { }

        public SearchCondition(string fieldName, string operate, object? value, bool isExpression)
            : this(CType.None, char.MinValue, fieldName, operate, value, null, isExpression, null) { }

        public SearchCondition(char enclosureL, string fieldName, string operate, object? value)
            : this(CType.None, enclosureL, fieldName, operate, value, null, false, null) { }

        public SearchCondition(char enclosureL, string fieldName, string operate, object? value, DbType dbType)
            : this(CType.None, enclosureL, fieldName, operate, value, dbType, false, null) { }

        public SearchCondition(char enclosureL, string fieldName, string operate, object? value, bool isExpression)
            : this(CType.None, enclosureL, fieldName, operate, value, null, isExpression, null) { }

        public SearchCondition(CType connector, string fieldName, string operate, object? value = null)
            : this(connector, char.MinValue, fieldName, operate, value, null, false, null) { }

        public SearchCondition(CType connector, string fieldName, string operate, object? value, char enclosureR)
            : this(connector, char.MinValue, fieldName, operate, value, null, false, enclosureR) { }

        public SearchCondition(CType connector, string fieldName, string operate, object? value, DbType dbType, char? enclosureR = null)
            : this(connector, char.MinValue, fieldName, operate, value, dbType, false, enclosureR) { }

        public SearchCondition(CType connector, string fieldName, string operate, object? value, bool isExpression, char? enclosureR = null)
            : this(connector, char.MinValue, fieldName, operate, value, null, isExpression, enclosureR) { }

        public SearchCondition(CType connector, char enclosureL, string fieldName, string operate, object? value = null)
            : this(connector, enclosureL, fieldName, operate, value, null, false, null) { }

        public SearchCondition(CType connector, char enclosureL, string fieldName, string operate, object? value, DbType dbType, char? enclosureR = null)
            : this(connector, enclosureL, fieldName, operate, value, dbType, false, enclosureR) { }

        public SearchCondition(CType connector, char enclosureL, string fieldName, string operate, object? value, bool isExpression, char? enclosureR = null)
            : this(connector, enclosureL, fieldName, operate, value, null, isExpression, enclosureR) { }

        public SearchCondition(CType connector, char enclosureL, string fieldName, string operate, object? value, DbType? dbType, bool isExpression, char? enclosureR)
        {
            _connector = connector;

            _fieldName = fieldName;

            _opType = OpType.None;

            _operator = operate;

            _value = value;

            _isExpression = isExpression;

            _enclosureL = enclosureL;
            _enclosureR = enclosureR ?? char.MinValue;

            if (dbType.HasValue && dbType.Value != DbType.AnsiString)
            {
                _dbType = dbType.Value;
            }
            else if (value is null)
            {
                _dbType = DbType.AnsiString;
            }
            else if (isExpression)
            {
                _dbType = DbType.AnsiString;
            }
            else
            {
                _dbType = DbTypeUtility.JudgeDbType(value);
            }
        }
            
        public SearchCondition(string fieldName, OpType operate, object? value = null)
            : this(CType.None, char.MinValue, fieldName, operate, value, null, false, null) { }

        public SearchCondition(string fieldName, OpType operate, object? value, DbType dbType)
            : this(CType.None, char.MinValue, fieldName, operate, value, dbType, false, null) { }

        public SearchCondition(string fieldName, OpType operate, object? value, bool isExpression)
            : this(CType.None, char.MinValue, fieldName, operate, value, null, isExpression, null) { }

        public SearchCondition(char enclosureL, string fieldName, OpType operate, object? value)
            : this(CType.None, enclosureL, fieldName, operate, value, null, false, null) { }

        public SearchCondition(char enclosureL, string fieldName, OpType operate, object? value, DbType dbType)
            : this(CType.None, enclosureL, fieldName, operate, value, dbType, false, null) { }

        public SearchCondition(char enclosureL, string fieldName, OpType operate, object? value, bool isExpression)
            : this(CType.None, enclosureL, fieldName, operate, value, null, isExpression, null) { }

        public SearchCondition(CType connector, string fieldName, OpType operate, object? value = null)
            : this(connector, char.MinValue, fieldName, operate, value, null, false, null) { }

        public SearchCondition(CType connector, string fieldName, OpType operate, object? value, char enclosureR)
            : this(connector, char.MinValue, fieldName, operate, value, null, false, enclosureR) { }

        public SearchCondition(CType connector, string fieldName, OpType operate, object? value, DbType dbType, char? enclosureR = null)
            : this(connector, char.MinValue, fieldName, operate, value, dbType, false, enclosureR) { }

        public SearchCondition(CType connector, string fieldName, OpType operate, object? value, bool isExpression, char? enclosureR = null)
            : this(connector, char.MinValue, fieldName, operate, value, null, isExpression, enclosureR) { }

        public SearchCondition(CType connector, char enclosureL, string fieldName, OpType operate, object? value = null)
            : this(connector, enclosureL, fieldName, operate, value, null, false, null) { }

        public SearchCondition(CType connector, char enclosureL, string fieldName, OpType operate, object? value, DbType dbType, char? enclosureR = null)
            : this(connector, enclosureL, fieldName, operate, value, dbType, false, enclosureR) { }

        public SearchCondition(CType connector, char enclosureL, string fieldName, OpType operate, object? value, bool isExpression, char? enclosureR = null)
            : this(connector, enclosureL, fieldName, operate, value, null, isExpression, enclosureR) { }

        public SearchCondition(CType connector, char enclosureL, string fieldName, OpType operate, object? value, DbType? dbType, bool isExpression, char? enclosureR)
        {
            _connector = connector;

            _fieldName = fieldName;

            _opType = operate;

            _operator = string.Empty;

            _value = value;

            _isExpression = isExpression;

            _enclosureL = enclosureL;
            _enclosureR = enclosureR ?? char.MinValue;

            if (dbType.HasValue && dbType.Value != DbType.AnsiString)
            {
                _dbType = dbType.Value;
            }
            else if (value is null)
            {
                _dbType = DbType.AnsiString;
            }
            else if (isExpression)
            {
                _dbType = DbType.AnsiString;
            }
            else
            {
                _dbType = DbTypeUtility.JudgeDbType(value);
            }
        }

        #endregion

        #region Properties

        /// <summary>The connector type.</summary>
        /// <remarks>AND, OR</remarks>
        public CType Connector
        {
            get => _connector;
            set => _connector = value;
        }

        /// <summary>The field name.</summary>
        /// <remarks>field_name, table_name.field_name, table_alias.field_name</remarks>
        public string FieldName
        {
            get => _fieldName;
            set => _fieldName = value;
        }

        /// <summary>The operator type.</summary>
        /// <remarks>Set either operator or operator type.</remarks>
        public OpType OpType
        {
            get => _opType;
            set => _opType = value;
        }

        /// <summary>The operator string.</summary>
        /// <remarks>Set either operator or operator type.</remarks>
        public string Operator
        {
            get => _operator;
            set => _operator = value;
        }

        /// <summary>The value.</summary>
        /// <remarks>If <see langword="null" />, set <see cref="System.DBNull"/>.</remarks>
        public object? Value
        {
            get => _value;
            set => _value = value;
        }

        /// <summary>The DB type of value.</summary>
        public DbType DbType
        {
            get => _dbType;
            set => _dbType = value;
        }

        /// <summary>Whether value is expression.</summary>
        /// <remarks>Sets <see langword="true" /> if value is expression.</remarks>
        public bool IsExpression
        {
            get => _isExpression;
            set => _isExpression = value;
        }

        /// <summary>Enclosing character for search condition.</summary>
        /// <remarks>(</remarks>
        public char EnclosureL
        {
            get => _enclosureL;
            set => _enclosureL = value;
        }

        /// <summary>Enclosing character for search condition.</summary>
        /// <remarks>)</remarks>
        public char EnclosureR
        {
            get => _enclosureR;
            set => _enclosureR = value;
        }

        #endregion

        #region Methods

        public string GetFieldName(QuotationMarkSet quotationMarks)
        {
            if (quotationMarks.IsAvailable == false)
            {
                return _fieldName;
            }

            string field;

            if (_fieldName.Contains('.'))
            {
                string[] strs = _fieldName.Split('.');

                field = string.Join('.', strs.Select(str => quotationMarks.Enclose(str)));
            }
            else
            {
                field = quotationMarks.Enclose(_fieldName);
            }

            return field;
        }

        //public string ToQuery()
        //{
        //    throw new NotSupportedException();
        //}

        public override string ToString()
        {
            string l;
            string r;

            if (_enclosureL == char.MinValue)
            {
                l = string.Empty;
            }
            else
            {
                l = _enclosureL.ToString();
            }

            if (_enclosureR == char.MinValue)
            {
                r = string.Empty;
            }
            else
            {
                r = _enclosureR.ToString();
            }

            return _opType == OpType.None
                ? $"{_connector} {l} {_fieldName} {_operator} {_value} {r}"
                : $"{_connector} {l} {_fieldName} {_opType} {_value} {r}";

            //return $"{nameof(Connector)}: {_connector}, L: {l}, {nameof(FieldName)}: {_fieldName}, {nameof(OpType)}: {_opType}, {nameof(Operator)}: {_operator}, {nameof(Value)}: {_value}, R: {r}";
        }

        #endregion
    }
}
