// ----------------------------------------------------------------------
// @Namespace : Izayoi.Data.Query
// @Class     : QueryBuilderBase
// ----------------------------------------------------------------------
#nullable enable
namespace Izayoi.Data.Query
{
    using System.Text;

    /// <summary>
    /// Base Query Builder
    /// </summary>
    public abstract class QueryBuilderBase
    {
        #region Fields

        /// <summary>The query option.</summary>
        protected readonly QueryOption _option;

        /// <summary>The string builder for query.</summary>
        protected readonly StringBuilder _stringBuilder;

        /// <summary>The bind parameters.</summary>
        protected readonly BindParameterCollection _bindParameters;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the QueryBuilderBase class.
        /// </summary>
        public QueryBuilderBase() : this(new QueryOption()) { }

        /// <summary>
        /// Initializes a new instance of the QueryBuilderBase class with the specified queryOption.
        /// </summary>
        /// <param name="queryOption">The query option.</param>
        public QueryBuilderBase(QueryOption queryOption)
        {
            _option = queryOption;

            _stringBuilder = new StringBuilder(queryOption.InitialBufferSize);

            _bindParameters = new BindParameterCollection();
        }

        /// <summary>
        /// Initializes a new instance of the QueryBuilderBase class with the specified queryOption, stringBuilder and bindParameters.
        /// </summary>
        /// <param name="queryOption">The query option.</param>
        /// <param name="stringBuilder">The string builder.</param>
        /// <param name="bindParameters">The bind parameters.</param>
        public QueryBuilderBase(QueryOption queryOption, StringBuilder stringBuilder, BindParameterCollection bindParameters)
        {
            _option = queryOption;

            _stringBuilder = stringBuilder;

            _bindParameters = bindParameters;
        }

        #endregion

        #region Properties

        /// <summary>Gets the query option.</summary>
        public QueryOption QueryOption => _option;

        /// <summary>Gets the bind parameters.</summary>
        public BindParameterCollection Parameters => _bindParameters;

        #endregion

        #region Public Methods

        /// <summary>
        /// Clear the query and parameters.
        /// </summary>
        /// <returns><see langword="true" /> if the query and parameter was cleared successfully; otherwise, <see langword="false" />.</returns>
        public virtual bool Clean()
        {
            _stringBuilder.Length = 0;

            _bindParameters.Clear();

            return true;
        }

        /// <summary>
        /// Get the query.
        /// </summary>
        /// <returns>The query.</returns>
        /// <remarks>Use after the build method.</remarks>
        public virtual string GetQuery()
        {
            return _stringBuilder.ToString();
        }

        /// <summary>
        /// Get the parameters.
        /// </summary>
        /// <returns>The parameters.</returns>
        /// <remarks>Use after the build method.</remarks>
        public virtual BindParameterCollection GetParameters()
        {
            return _bindParameters;
        }

        #endregion

        #region Protected Methods

        protected virtual int GetFixedIndentCount()
        {
            if (_option.BeforeComma)
            {
                if (_option.IndentSpace <= 1)
                {
                    return 2;
                }
            }
            else
            {
                if (_option.IndentSpace <= 0)
                {
                    return 1;
                }
            }

            return _option.IndentSpace;
        }

        #endregion
    }
}
