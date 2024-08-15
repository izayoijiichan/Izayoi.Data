// ----------------------------------------------------------------------
// @Namespace : Izayoi.Data.Query
// @Class     : Joins
// ----------------------------------------------------------------------
namespace Izayoi.Data.Query
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Joins
    /// </summary>
    public class Joins : List<Join>
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the Joins class.
        /// </summary>
        public Joins() { }

        /// <summary>
        /// Initializes a new instance of the Joins class with the specified initial capacity.
        /// </summary>
        /// <param name="capacity">The number of elements that the new list can initially store.</param>
        public Joins(int capacity) : base(capacity) { }

        #endregion

        #region Methods

        public new Joins Add(Join item)
        {
            base.Add(item);

            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type">The join type.</param>
        /// <param name="tableName">The table name.</param>
        /// <param name="condition">The search condition.</param>
        /// <returns></returns>
        public Joins Add(JType type, string tableName, string condition)
        {
            base.Add(new Join(type, tableName, condition));

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
        public Joins Add(JType type, string tableName, string tableAlias, string condition)
        {
            base.Add(new Join(type, tableName, tableAlias, condition));

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
        public Joins Add(JType type, string schemaName, string tableName, string tableAlias, string condition)
        {
            base.Add(new Join(type, schemaName, tableName, tableAlias, condition));

            return this;
        }

        public string ToQuery(QuotationMarkSet quotationMarks)
        {
            return Count == 0
                ? string.Empty
                : string.Join(Environment.NewLine, this.Select(x => x.ToQuery(quotationMarks)));
        }

        #endregion
    }
}
