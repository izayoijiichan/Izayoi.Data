// ----------------------------------------------------------------------
// @Namespace : Izayoi.Data.Query
// @Class     : Values
// ----------------------------------------------------------------------
namespace Izayoi.Data.Query
{
    using System.Collections.ObjectModel;
    using System.Data;

    /// <summary>
    /// Values
    /// </summary>
    public class Values : KeyedCollection<string, Value>
    {
        #region Protected Methods

        protected override string GetKeyForItem(Value item)
        {
            return item.ColumnName;
        }

        #endregion

        #region Public Methods

        public new Values Add(Value value)
        {
            base.Add(value);

            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="columnName">The column name.</param>
        /// <param name="value">The value.</param>
        public Values Add(string columnName, object? value)
        {
            Add(new Value(columnName, value));

            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="columnName">The column name.</param>
        /// <param name="value">The value.</param>
        /// <param name="dbType">The DB type of value.</param>
        /// <returns></returns>
        public Values Add(string columnName, object? value, DbType dbType)
        {
            Add(new Value(columnName, value, dbType));

            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="columnName">The column name.</param>
        /// <param name="value">The value.</param>
        /// <param name="isExpression">Whether value is expression.</param>
        /// <returns></returns>
        public Values Add(string columnName, object? value, bool isExpression)
        {
            Add(new Value(columnName, value, isExpression));

            return this;
        }

        #endregion
    }
}
