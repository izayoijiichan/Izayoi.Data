// ----------------------------------------------------------------------
// @Namespace : Izayoi.Data.Query
// @Class     : QueryBuilder
// ----------------------------------------------------------------------
namespace Izayoi.Data.Query
{
    /// <summary>
    /// Query Builder
    /// </summary>
    public class QueryBuilder : QueryBuilderBase, IQueryBuilder
    {
        #region Fields

        /// <summary>The delete query builder.</summary>
        protected DeleteQueryBuilder? _deleteQueryBuilder;

        /// <summary>The insert query builder.</summary>
        protected InsertQueryBuilder? _insertQueryBuilder;

        /// <summary>The select query builder.</summary>
        protected SelectQueryBuilder? _selectQueryBuilder;

        /// <summary>The update query builder.</summary>
        protected UpdateQueryBuilder? _updateQueryBuilder;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the QueryBuilder class.
        /// </summary>
        public QueryBuilder() : base() { }

        /// <summary>
        /// Initializes a new instance of the QueryBuilder class with the specified queryOption.
        /// </summary>
        /// <param name="queryOption">The query option.</param>
        public QueryBuilder(QueryOption queryOption) : base(queryOption) { }

        #endregion

        #region Public Methods

        /// <summary>
        /// Builds the specified delete.
        /// </summary>
        /// <param name="delete">A delete source.</param>
        /// <returns><see langword="true" /> if the query and parameter was successfully built; otherwise, <see langword="false" />.</returns>
        public virtual bool Build(in Delete delete)
        {
            _deleteQueryBuilder ??= new DeleteQueryBuilder(_option, _stringBuilder, _bindParameters);

            return _deleteQueryBuilder.Build(delete);
        }

        /// <summary>
        /// Builds the specified insert.
        /// </summary>
        /// <param name="insert">An insert source.</param>
        /// <returns><see langword="true" /> if the query and parameter was successfully built; otherwise, <see langword="false" />.</returns>
        public virtual bool Build(in Insert insert)
        {
            _insertQueryBuilder ??= new InsertQueryBuilder(_option, _stringBuilder, _bindParameters);

            return _insertQueryBuilder.Build(insert);
        }

        /// <summary>
        /// Builds the specified select.
        /// </summary>
        /// <param name="select">A select source.</param>
        /// <returns><see langword="true" /> if the query and parameter was successfully built; otherwise, <see langword="false" />.</returns>
        public virtual bool Build(in Select select)
        {
            _selectQueryBuilder ??= new SelectQueryBuilder(_option, _stringBuilder, _bindParameters);

            return _selectQueryBuilder.Build(select);
        }

        /// <summary>
        /// Builds the specified update.
        /// </summary>
        /// <param name="update">An update source.</param>
        /// <returns><see langword="true" /> if the query and parameter was successfully built; otherwise, <see langword="false" />.</returns>
        public virtual bool Build(in Update update)
        {
            _updateQueryBuilder ??= new UpdateQueryBuilder(_option, _stringBuilder, _bindParameters);

            return _updateQueryBuilder.Build(update);
        }

        #endregion
    }
}
