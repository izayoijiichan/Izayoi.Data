// ----------------------------------------------------------------------
// @Namespace : Izayoi.Data.Query
// @Class     : Join
// ----------------------------------------------------------------------
namespace Izayoi.Data.Query
{
    /// <summary>
    /// Join
    /// </summary>
    public class Join
    {
        #region Fields

        private readonly JType _type;

        private readonly string _schemaName;

        private readonly string _tableName;

        private readonly string _tableAlias;

        private readonly string _condition;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the Join class with the specified type, tableName and condition.
        /// </summary>
        /// <param name="type">The join type.</param>
        /// <param name="tableName">The table name.</param>
        /// <param name="condition">The search condition.</param>
        public Join(JType type, string tableName, string condition)
            : this(type, string.Empty, tableName, string.Empty, condition) { }

        /// <summary>
        /// Initializes a new instance of the Join class with the specified type, tableName, tableAlias and condition.
        /// </summary>
        /// <param name="type">The join type.</param>
        /// <param name="tableName">The table name.</param>
        /// <param name="tableAlias">The table alias.</param>
        /// <param name="condition">The search condition.</param>
        public Join(JType type, string tableName, string tableAlias, string condition)
            : this(type, string.Empty, tableName, tableAlias, condition) { }

        /// <summary>
        /// Initializes a new instance of the Join class with the specified type, schemaName, tableName, tableAlias and condition.
        /// </summary>
        /// <param name="type">The join type.</param>
        /// <param name="schemaName">The schema name.</param>
        /// <param name="tableName">The table name.</param>
        /// <param name="tableAlias">The table alias.</param>
        /// <param name="condition">The search condition.</param>
        public Join(JType type, string schemaName, string tableName, string tableAlias, string condition)
        {
            _type = type;
            _schemaName = schemaName;
            _tableName = tableName;
            _tableAlias = tableAlias;
            _condition = condition;
        }

        #endregion

        #region Properties

        /// <summary>The join type.</summary>
        public JType Type => _type;

        /// <summary>The schema type.</summary>
        public string SchemaName => _schemaName;

        /// <summary>The table name.</summary>
        public string TableName => _tableName;

        /// <summary>The table alias.</summary>
        public string TableAlias => _tableAlias;

        /// <summary>The search condition.</summary>
        public string Condition => _condition;

        #endregion

        #region Methods

        public string ToQuery(QuotationMarkSet quotationMarks)
        {
            string schemaTable;

            if (_schemaName.Length == 0)
            {
                schemaTable = quotationMarks.Enclose(_tableName);
            }
            else
            {
                string schemaName = quotationMarks.Enclose(_schemaName);

                string tableName = quotationMarks.Enclose(_tableName);

                schemaTable = $"{schemaName}.{tableName}";
            }

            if (_tableAlias.Length == 0)
            {
                return $"{_type.Name()} {schemaTable} ON ({_condition})";
            }
            else
            {
                string alias = quotationMarks.Enclose(_tableAlias);

                return $"{_type.Name()} {schemaTable} AS {alias} ON ({_condition})";
            }
        }

        public override string ToString()
        {
            return $"{nameof(Type)}: {_type}, {nameof(SchemaName)}: {_schemaName}, {nameof(TableName)}: {_tableName}, {nameof(TableAlias)}: {_tableAlias}, {nameof(Condition)}: {_condition}";
        }

        #endregion
    }
}
