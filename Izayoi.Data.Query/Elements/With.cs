// ----------------------------------------------------------------------
// @Namespace : Izayoi.Data.Query
// @Class     : With
// ----------------------------------------------------------------------
namespace Izayoi.Data.Query
{
    using System.Collections.Generic;

    /// <summary>
    /// With
    /// </summary>
    public class With
    {
        #region Fields

        private bool _recursive;

        private List<CommonTableExpression> _cteList;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the With class.
        /// </summary>
        public With()
        {
            _recursive = false;

            _cteList = new List<CommonTableExpression>();
        }

        /// <summary>
        /// Initializes a new instance of the With class with the specified recursive.
        /// </summary>
        /// <param name="recursive"></param>
        public With(bool recursive)
        {
            _recursive = recursive;

            _cteList = new List<CommonTableExpression>();
        }

        ///// <summary>
        ///// Initializes a new instance of the With class with the specified recursive and cteList.
        ///// </summary>
        ///// <param name="recursive"></param>
        //public With(bool recursive, IEnumerable<CommonTableExpression> cteList)
        //{
        //    _recursive = recursive;

        //    _cteList = new List<CommonTableExpression>(cteList);
        //}

        #endregion

        #region Properties

        /// <summary></summary>
        public bool IsEnable => _cteList.Count > 0;

        /// <summary></summary>
        public bool IsRecursive => _recursive;

        /// <summary></summary>
        public List<CommonTableExpression> CteList => _cteList;

        #endregion

        #region Methods

        public With Add(in CommonTableExpression commonTableExpression)
        {
            _cteList.Add(commonTableExpression);

            return this;
        }

        public With Clear()
        {
            _recursive = false;

            _cteList.Clear();

            return this;
        }

        public With SetRecursive(bool recursive)
        {
            _recursive = recursive;

            return this;
        }

        public override string ToString()
        {
            return $"Recursive: {_recursive}, CteList.Count: {_cteList.Count}";
        }

        #endregion
    }
}
