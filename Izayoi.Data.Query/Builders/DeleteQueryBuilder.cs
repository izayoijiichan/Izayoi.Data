// ----------------------------------------------------------------------
// @Namespace : Izayoi.Data.Query
// @Class     : DeleteQueryBuilder
// ----------------------------------------------------------------------
namespace Izayoi.Data.Query
{
    using System.Text;

    /// <summary>
    /// Delete Query Builder
    /// </summary>
    public class DeleteQueryBuilder : SelectQueryBuilderBase, IDeleteQueryBuilder
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the DeleteQueryBuilder class.
        /// </summary>
        public DeleteQueryBuilder() : base() { }

        /// <summary>
        /// Initializes a new instance of the DeleteQueryBuilder class with the specified queryOption.
        /// </summary>
        /// <param name="queryOption">The query option.</param>
        public DeleteQueryBuilder(QueryOption queryOption) : base(queryOption) { }

        /// <summary>
        /// Initializes a new instance of the DeleteQueryBuilder class with the specified queryOption, stringBuilder and bindParameters.
        /// </summary>
        /// <param name="queryOption">The query option.</param>
        /// <param name="stringBuilder">The string builder.</param>
        /// <param name="bindParameters">The bind parameters.</param>
        public DeleteQueryBuilder(QueryOption queryOption, StringBuilder stringBuilder, BindParameterCollection bindParameters)
            : base(queryOption, stringBuilder, bindParameters) { }

        #endregion

        #region Public Methods

        /// <summary>
        /// Builds the specified delete.
        /// </summary>
        /// <param name="delete">A delete source.</param>
        /// <returns><see langword="true" /> if the query and parameter was successfully built; otherwise, <see langword="false" />.</returns>
        public virtual bool Build(in Delete delete)
        {
            Clean();

            return BuildQuery(delete);
        }

        #endregion

        #region Protected Methods

        protected virtual bool BuildQuery(in Delete delete)
        {
            // WITH
            AppendWith(delete.With);

            // DELETE
            AppendDelete();

            // FROM
            AppendFrom(delete.From, hasWhere: delete.Wheres.Count > 0);

            // WHERE
            AppendWhere(delete.Wheres);

            return true;
        }

        protected virtual void AppendDelete()
        {
            _stringBuilder.Append("DELETE");
        }

        protected virtual void AppendFrom(in From from, bool hasWhere)
        {
            if (_option.EnableFormat == false && hasWhere == false)
            {
                _stringBuilder
                    .Append(' ')
                    .Append(from.ToQuery(_option.QuotationMarks, excludeJoin: true));

                return;
            }

            AppendFrom(from);
        }

        #endregion
    }
}
