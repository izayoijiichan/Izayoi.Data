// ----------------------------------------------------------------------
// @Namespace : Izayoi.Data.Query
// @Class     : QueryOption
// ----------------------------------------------------------------------
namespace Izayoi.Data.Query
{
    /// <summary>
    /// Query Option
    /// </summary>
    public class QueryOption
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the QueryOption class.
        /// </summary>
        public QueryOption()
            : this(RdbKind.None, rdbVersion: 0) { }

        /// <summary>
        /// Initializes a new instance of the QueryOption class with the specified rdbKind.
        /// </summary>
        /// <param name="rdbKind">The relational database kind.</param>
        public QueryOption(RdbKind rdbKind)
            : this(rdbKind, rdbVersion: 0) { }

        /// <summary>
        /// Initializes a new instance of the QueryOption class with the specified rdbKind and rdbVersion.
        /// </summary>
        /// <param name="rdbKind">The relational database kind.</param>
        /// <param name="rdbVersion">The relational database version.</param>
        public QueryOption(RdbKind rdbKind, int rdbVersion)
        {
            RdbKind = rdbKind;

            RdbVersion = rdbVersion;

            if (rdbKind == RdbKind.Mysql)
            {
                QuotationMarks = new('`', '`');
            }
            else if (rdbKind == RdbKind.Pgsql)
            {
                QuotationMarks = new('"', '"');
            }
            else if (rdbKind == RdbKind.SqlServer)
            {
                QuotationMarks = new('[', ']');
            }
        }

        #endregion

        #region Properties

        /// <summary>Gets or sets the relational database kind.</summary>
        public RdbKind RdbKind { get; set; } = RdbKind.None;

        /// <summary>Gets or sets the relational database version.</summary>
        public int RdbVersion { get; set; }

        /// <summary>Gets or sets the initial buffer size.</summary>
        /// <remarks>StringBuilder(capacity)</remarks>
        public int InitialBufferSize { get; set; } = 256;

        /// <summary>Gets or sets the quotation marks.</summary>
        public QuotationMarkSet QuotationMarks { get; set; }

        /// <summary>Gets or sets whether to enable query formatting.</summary>
        public bool EnableFormat { get; set; } = false;

        /// <summary>Gets or sets the number of spaces for indentation.</summary>
        /// <remarks>It is referenced if EnableFormat is <see langword="true" />.</remarks>
        public int IndentSpace { get; set; } = 2;

        /// <summary>Gets or sets whether to place the comma before or after the concatenation.</summary>
        /// <remarks><see langword="true" /> means before; <see langword="false" /> means after.</remarks>
        public bool BeforeComma { get; set; } = false;

        #endregion
    }
}
