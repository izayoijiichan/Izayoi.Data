// ----------------------------------------------------------------------
// @Namespace : Izayoi.Data.Query
// @Class     : Value
// ----------------------------------------------------------------------
namespace Izayoi.Data.Query
{
    using System;
    using System.Data;

    /// <summary>
    /// Value
    /// </summary>
    public class Value
    {
        #region Fields

        private readonly string _columnName;

        //private readonly string _operator = "=";

        private object _value;

        private DbType _dbType;

        private bool _isExpression;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the Value class with the specified columnName and value.
        /// </summary>
        /// <param name="columnName">The column name.</param>
        /// <param name="value">The value.</param>
        public Value(string columnName, object? value)
            : this(columnName, value, isExpression: false) { }

        /// <summary>
        /// Initializes a new instance of the Value class with the specified columnName, value and dbType.
        /// </summary>
        /// <param name="columnName">The column name.</param>
        /// <param name="value">The value.</param>
        /// <param name="dbType">The DB type of value.</param>
        public Value(string columnName, object? value, DbType dbType)
        {
            _columnName = columnName;

            _value = value ?? DBNull.Value;

            _isExpression = false;

            _dbType = dbType;
        }

        /// <summary>
        /// Initializes a new instance of the Value class with the specified columnName, value and isExpression.
        /// </summary>
        /// <param name="columnName">The column name.</param>
        /// <param name="value">The value.</param>
        /// <param name="isExpression">Whether value is expression.</param>
        public Value(string columnName, object? value, bool isExpression)
        {
            _columnName = columnName;

            _value = value ?? DBNull.Value;

            _isExpression = isExpression;

            if (_isExpression)
            {
                _dbType = DbType.AnsiString;

            }
            else
            {
                _dbType = DbTypeUtility.JudgeDbType(_value);
            }
        }

        #endregion

        #region Properties

        /// <summary>The column name.</summary>
        public string ColumnName => _columnName;

        /// <summary>The value.</summary>
        /// <remarks>If null, set DBNull.</remarks>
        public object Value_ => _value;

        /// <summary>The DB type of value.</summary>
        public DbType DbType => _dbType;

        /// <summary>Whether value is expression.</summary>
        /// <remarks>Sets true if value is expression.</remarks>
        public bool IsExpression => _isExpression;

        #endregion

        #region Methods

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value">The value.</param>
        public void SetValue(object? value)
        {
            _value = value ?? DBNull.Value;

            _isExpression = false;

            _dbType = DbTypeUtility.JudgeDbType(_value);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="dbType">The DB type of value.</param>
        public void SetValue(object? value, DbType dbType)
        {
            _value = value ?? DBNull.Value;

            _isExpression = false;

            _dbType = dbType;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="isExpression">Whether value is expression.</param>
        public void SetValue(object? value, bool isExpression)
        {
            _value = value ?? DBNull.Value;

            _isExpression = isExpression;

            if (_isExpression)
            {
                _dbType = DbType.AnsiString;
            }
            else
            {
                _dbType = DbTypeUtility.JudgeDbType(_value);
            }
        }

        #endregion
    }
}
