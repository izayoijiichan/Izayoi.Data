// ----------------------------------------------------------------------
// @Namespace : Izayoi.Data.Query
// @Interface : ISelectQueryBuilder
// ----------------------------------------------------------------------
#nullable enable
namespace Izayoi.Data.Query
{
    /// <summary>
    /// Select Query Builder Interface
    /// </summary>
    public interface ISelectQueryBuilder
    {
        #region Properties

        /// <summary>Gets the query option.</summary>
        QueryOption QueryOption { get; }

        /// <summary>Gets the bind parameters.</summary>
        BindParameterCollection Parameters { get; }

        #endregion

        #region Methods

        /// <summary>
        /// Builds the specified select.
        /// </summary>
        /// <param name="select">A select source.</param>
        /// <returns><see langword="true" /> if the query and parameter was successfully built; otherwise, <see langword="false" />.</returns>
        bool Build(in Select select);

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
