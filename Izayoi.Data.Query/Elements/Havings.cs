// ----------------------------------------------------------------------
// @Namespace : Izayoi.Data.Query
// @Class     : Havings
// ----------------------------------------------------------------------
namespace Izayoi.Data.Query
{
    public class Havings : SearchConditions
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the Havings class.
        /// </summary>
        public Havings() : base() { }

        /// <summary>
        /// Initializes a new instance of the Havings class with the specified initial capacity.
        /// </summary>
        /// <param name="capacity">The number of elements that the new list can initially store.</param>
        public Havings(int capacity) : base(capacity) { }

        #endregion
    }
}
