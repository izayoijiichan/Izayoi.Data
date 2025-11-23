// ----------------------------------------------------------------------
// @Namespace : Izayoi.Data.Query
// @Class     : Sets
// ----------------------------------------------------------------------
#nullable enable
namespace Izayoi.Data.Query
{
    using System.Collections.ObjectModel;
    using System.Data;

    /// <summary>
    /// Sets
    /// </summary>
    public class Sets : KeyedCollection<string, Set>
    {
        #region Protected Methods

        protected override string GetKeyForItem(Set item)
        {
            return item.ColumnName;
        }

        #endregion

        #region Public Methods

        public new Sets Add(Set set)
        {
            base.Add(set);

            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="columnName">The column name.</param>
        /// <param name="value">The value.</param>
        public Sets Add(string columnName, object? value)
        {
            Add(new Set(columnName, value));

            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="columnName">The column name.</param>
        /// <param name="value">The value.</param>
        /// <param name="dbType">The DB type of value.</param>
        /// <returns></returns>
        public Sets Add(string columnName, object? value, DbType dbType)
        {
            Add(new Set(columnName, value, dbType));

            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="columnName">The column name.</param>
        /// <param name="value">The value.</param>
        /// <param name="isExpression">Whether value is expression.</param>
        /// <returns></returns>
        public Sets Add(string columnName, object? value, bool isExpression)
        {
            Add(new Set(columnName, value, isExpression));

            return this;
        }

        #endregion
    }
}
