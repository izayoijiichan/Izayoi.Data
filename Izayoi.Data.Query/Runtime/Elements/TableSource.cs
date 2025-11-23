// ----------------------------------------------------------------------
// @Namespace : Izayoi.Data.Query
// @Class     : TableSource
// ----------------------------------------------------------------------
#nullable enable
namespace Izayoi.Data.Query
{
    /// <summary>
    /// Table Source
    /// </summary>
    public class TableSource
    {
        #region Fields

        private string _schemaName;

        private string _tableName;

        private string _tableAlias;

        private readonly Joins _joins;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the TableSource class.
        /// </summary>
        public TableSource()
            : this(string.Empty, string.Empty, string.Empty) { }

        /// <summary>
        /// Initializes a new instance of the TableSource class with the specified tableName.
        /// </summary>
        /// <param name="tableName">The table name.</param>
        public TableSource(string tableName)
            : this(string.Empty, tableName, string.Empty) { }

        /// <summary>
        /// Initializes a new instance of the TableSource class with the specified tableName and tableAlias.
        /// </summary>
        /// <param name="tableName">The table name.</param>
        /// <param name="tableAlias">The table alias.</param>
        public TableSource(string tableName, string tableAlias)
            : this(string.Empty, tableName, tableAlias) { }

        /// <summary>
        /// Initializes a new instance of the TableSource class with the specified schemaName, tableName and tableAlias.
        /// </summary>
        /// <param name="schemaName">The schema name.</param>
        /// <param name="tableName">The table name.</param>
        /// <param name="tableAlias">The table alias.</param>
        public TableSource(string schemaName, string tableName, string tableAlias)
        {
            _schemaName = schemaName;
            _tableName = tableName;
            _tableAlias = tableAlias;

            _joins = new Joins(2);
        }

        #endregion

        #region Properties

        /// <summary>The schema name.</summary>
        public string SchemaName
        {
            get => _schemaName;
            set => _schemaName = value;
        }

        /// <summary>The table name.</summary>
        public string TableName
        {
            get => _tableName;
            set => _tableName = value;
        }

        /// <summary>The table alias.</summary>
        public string TableAlias
        {
            get => _tableAlias;
            set => _tableAlias = value;
        }

        /// <summary>JOIN clause</summary>
        public Joins Joins => _joins;

        #endregion

        #region Methods

        public virtual void Clear()
        {
            _schemaName = string.Empty;
            _tableName = string.Empty;
            _tableAlias = string.Empty;

            _joins.Clear();
        }

        public string GetSchemaDotTable(QuotationMarkSet quotationMarks)
        {
            string schema = quotationMarks.Enclose(_schemaName, excludeEmpty: true);

            string table = quotationMarks.Enclose(_tableName, excludeEmpty: true);

            if (schema.Length == 0)
            {
                return table;
            }

            return $"{schema}.{table}";
        }

        public string GetSchemaDotTableAsAlias(QuotationMarkSet quotationMarks)
        {
            string schemaTable = GetSchemaDotTable(quotationMarks);

            string alias = quotationMarks.Enclose(_tableAlias, excludeEmpty: true);

            return (alias.Length == 0)
                ? $"{schemaTable}"
                : $"{schemaTable} AS {alias}";
        }

        public string GetSchemaDotTableOrAlias(QuotationMarkSet quotationMarks)
        {
            string alias = quotationMarks.Enclose(_tableAlias, excludeEmpty: true);

            if (alias.Length > 0)
            {
                return alias;
            }

            return GetSchemaDotTable(quotationMarks);
        }

        public override string ToString()
        {
            return $"{nameof(SchemaName)}: {_schemaName}, {nameof(TableName)}: {_tableName}, {nameof(TableAlias)}: {_tableAlias}";
        }

        #endregion
    }
}
