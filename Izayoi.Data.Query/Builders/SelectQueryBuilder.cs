// ----------------------------------------------------------------------
// @Namespace : Izayoi.Data.Query
// @Class     : SelectQueryBuilder
// ----------------------------------------------------------------------
namespace Izayoi.Data.Query
{
    using System.Text;

    /// <summary>
    /// Select Query Builder
    /// </summary>
    public class SelectQueryBuilder : SelectQueryBuilderBase, ISelectQueryBuilder
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the SelectQueryBuilder class.
        /// </summary>
        public SelectQueryBuilder() : base() { }

        /// <summary>
        /// Initializes a new instance of the SelectQueryBuilder class with the specified queryOption.
        /// </summary>
        /// <param name="queryOption">The query option.</param>
        public SelectQueryBuilder(QueryOption queryOption) : base(queryOption) { }

        /// <summary>
        /// Initializes a new instance of the SelectQueryBuilder class with the specified queryOption, stringBuilder and bindParameters.
        /// </summary>
        /// <param name="queryOption">The query option.</param>
        /// <param name="stringBuilder">The string builder.</param>
        /// <param name="bindParameters">The bind parameters.</param>
        public SelectQueryBuilder(QueryOption queryOption, StringBuilder stringBuilder, BindParameterCollection bindParameters)
            : base(queryOption, stringBuilder, bindParameters) { }

        #endregion

        #region Public Methods

        /// <summary>
        /// Builds the specified select.
        /// </summary>
        /// <param name="select">A select source.</param>
        /// <returns><see langword="true" /> if the query and parameter was successfully built; otherwise, <see langword="false" />.</returns>
        public virtual bool Build(in Select select)
        {
            Clean();

            return BuildQuery(select);
        }

        #endregion
    }
}
