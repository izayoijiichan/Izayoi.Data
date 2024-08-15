// ----------------------------------------------------------------------
// @Namespace : Izayoi.Data.Query
// @Class     : Wheres
// ----------------------------------------------------------------------
namespace Izayoi.Data.Query
{
    public class Wheres : SearchConditions
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the Wheres class.
        /// </summary>
        public Wheres() : base() { }

        /// <summary>
        /// Initializes a new instance of the Wheres class with the specified initial capacity.
        /// </summary>
        /// <param name="capacity">The number of elements that the new list can initially store.</param>
        public Wheres(int capacity) : base(capacity) { }

        #endregion
    }
}