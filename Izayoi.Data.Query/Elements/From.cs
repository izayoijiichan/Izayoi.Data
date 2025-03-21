// ----------------------------------------------------------------------
// @Namespace : Izayoi.Data.Query
// @Class     : From
// ----------------------------------------------------------------------
namespace Izayoi.Data.Query
{
    using System;

    /// <summary>
    /// From
    /// </summary>
    public class From : TableSource
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the From class.
        /// </summary>
        public From()
            : base() { }

        /// <summary>
        /// Initializes a new instance of the From class with the specified tableName.
        /// </summary>
        /// <param name="tableName">The table name.</param>
        public From(string tableName)
            : base(tableName) { }

        /// <summary>
        /// Initializes a new instance of the From class with the specified tableName and tableAlias.
        /// </summary>
        /// <param name="tableName">The table name.</param>
        /// <param name="tableAlias">The table alias.</param>
        public From(string tableName, string tableAlias)
            : base(tableName, tableAlias) { }

        /// <summary>
        /// Initializes a new instance of the From class with the specified schemaName, tableName and tableAlias.
        /// </summary>
        /// <param name="schemaName">The schema name.</param>
        /// <param name="tableName">The table name.</param>
        /// <param name="tableAlias">The table alias.</param>
        public From(string schemaName, string tableName, string tableAlias)
            : base(schemaName, tableName, tableAlias) { }

        /// <summary>
        /// Initializes a new instance of the From class with the specified tableSource.
        /// </summary>
        /// <param name="tableSource">The table source.</param>
        public From(TableSource tableSource)
            : base(tableSource.SchemaName, tableSource.TableName, tableSource.TableAlias) { }

        #endregion

        #region Methods

        public string ToQuery(QuotationMarkSet quotationMarks, bool excludeJoin = false)
        {
            string schemaDotTableAsAlias = GetSchemaDotTableAsAlias(quotationMarks);

            if (string.IsNullOrEmpty(schemaDotTableAsAlias))
            {
                return string.Empty;
            }

            if (excludeJoin)
            {
                return $"FROM {schemaDotTableAsAlias}";
            }
            else
            {
                return $"FROM {schemaDotTableAsAlias}" + Environment.NewLine + Joins.ToQuery(quotationMarks);
            }
        }

        #endregion
    }
}
