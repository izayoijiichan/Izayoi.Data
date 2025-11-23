// ----------------------------------------------------------------------
// @Namespace : Izayoi.Data.Query
// @Interface  : IInsertQueryBuilder
// ----------------------------------------------------------------------
#nullable enable
namespace Izayoi.Data.Query
{
    /// <summary>
    /// Insert Query Builder Interface
    /// </summary>
    public interface IInsertQueryBuilder
    {
        #region Properties

        /// <summary>Gets the query option.</summary>
        QueryOption QueryOption { get; }

        /// <summary>Gets the bind parameters.</summary>
        BindParameterCollection Parameters { get; }

        #endregion

        #region Methods

        /// <summary>
        /// Builds the specified insert.
        /// </summary>
        /// <param name="insert">An insert source.</param>
        /// <returns><see langword="true" /> if the query and parameter was successfully built; otherwise, <see langword="false" />.</returns>
        bool Build(in Insert insert);

        /// <summary>
        /// Clear the query and parameters.
        /// </summary>
        /// <returns><see langword="true" /> if the query and parameter was cleared successfully; otherwise, <see langword="false" />.</returns>
        bool Clean();

        /// <summary>
        /// Get the query.
        /// </summary>
        /// <returns>The query.</returns>
        /// <remarks>Use after the build method.</remarks>
        string GetQuery();

        /// <summary>
        /// Get the parameters.
        /// </summary>
        /// <returns>The parameters.</returns>
        /// <remarks>Use after the build method.</remarks>
        BindParameterCollection GetParameters();

        #endregion
    }
}
