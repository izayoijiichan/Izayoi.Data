// ----------------------------------------------------------------------
// @Namespace : Izayoi.Data.Query
// @Class     : Orders
// ----------------------------------------------------------------------
#nullable enable
namespace Izayoi.Data.Query
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Orders
    /// </summary>
    public class Orders : List<Order>
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the Orders class.
        /// </summary>
        public Orders() { }

        /// <summary>
        /// Initializes a new instance of the Orders class with the specified initial capacity.
        /// </summary>
        /// <param name="capacity">The number of elements that the new list can initially store.</param>
        public Orders(int capacity) : base(capacity) { }

        #endregion

        #region Methods

        public new Orders Add(Order order)
        {
            base.Add(order);

            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="orderExpression">The order expression.</param>
        /// <returns></returns>
        public Orders Add(string orderExpression)
        {
            base.Add(new Order(orderExpression));

            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="orderExpression">The order expression.</param>
        /// <param name="type">The order type.</param>
        /// <returns></returns>
        public Orders Add(string orderExpression, OType type)
        {
            base.Add(new Order(orderExpression, type));

            return this;
        }

        public string ToQuery(QuotationMarkSet quotationMarks)
        {
            return Count == 0
                ? string.Empty
                : "ORDER BY " + string.Join(", ", this.Select(x => x.ToQuery(quotationMarks)));
        }

        #endregion
    }
}
